Imports System.IO
Imports System.Data.Odbc
Imports System.Drawing
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer

Public Class FormFaculty
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance

    Private Sub LoadAddressComboBoxes(regionId As String, provinceId As String, cityId As String, brgyId As String)
        Try
            _logger.LogInfo($"FormFaculty - Loading address ComboBoxes for editing - Region: {regionId}, Province: {provinceId}, City: {cityId}, Barangay: {brgyId}")

            ' Ensure connection is available
            connectDB()

            ' Load Region ComboBox first
            FormHelper.LoadComboBox("SELECT * FROM refregion ORDER BY regDesc", "id", "regDesc", AddFaculty.cbRegion)
            AddFaculty.cbRegion.SelectedValue = regionId

            ' Load Province ComboBox based on selected region (if region has provinces)
            If Not String.IsNullOrEmpty(regionId) Then
                connectDB() ' Ensure fresh connection
                Dim regionCmd As New OdbcCommand("SELECT regCode, regDesc FROM refregion WHERE id = ?", con)
                regionCmd.Parameters.AddWithValue("?", regionId)
                Dim regionReader = regionCmd.ExecuteReader()

                If regionReader.Read() Then
                    Dim regionCode As String = regionReader("regCode")?.ToString()
                    Dim regionName As String = regionReader("regDesc")?.ToString()
                    regionReader.Close()

                    ' Check if region has provinces
                    If ValidationHelper.RegionHasProvinces(regionName, regionCode) Then
                        ' Load provinces for regions that have them
                        If Not String.IsNullOrEmpty(regionCode) Then
                            FormHelper.LoadComboBox($"SELECT * FROM refprovince WHERE regCode = {regionCode} ORDER BY provdesc", "id", "provdesc", AddFaculty.cbProvince)
                            AddFaculty.cbProvince.SelectedValue = provinceId
                        End If
                    Else
                        ' For regions without provinces (like NCR), skip province loading
                        AddFaculty.cbProvince.Visible = False
                        AddFaculty.cbProvince.Enabled = False
                        _logger.LogInfo($"FormFaculty - Province controls hidden for region: {regionName}")
                    End If
                Else
                    regionReader.Close()
                End If
            End If

            ' Load City ComboBox based on selected province
            If Not String.IsNullOrEmpty(provinceId) Then
                connectDB() ' Ensure fresh connection
                Dim provinceCmd As New OdbcCommand("SELECT provCode FROM refprovince WHERE id = ?", con)
                provinceCmd.Parameters.AddWithValue("?", provinceId)
                Dim provinceCode As String = provinceCmd.ExecuteScalar()?.ToString()

                If Not String.IsNullOrEmpty(provinceCode) Then
                    FormHelper.LoadComboBox($"SELECT * FROM refcitymun WHERE provcode = {provinceCode} ORDER BY citymundesc", "id", "citymundesc", AddFaculty.cbCity)
                    AddFaculty.cbCity.SelectedValue = cityId
                End If
            End If

            ' Load Barangay ComboBox based on selected city
            If Not String.IsNullOrEmpty(cityId) Then
                connectDB() ' Ensure fresh connection
                Dim cityCmd As New OdbcCommand("SELECT citymunCode FROM refcitymun WHERE id = ?", con)
                cityCmd.Parameters.AddWithValue("?", cityId)
                Dim cityCode As String = cityCmd.ExecuteScalar()?.ToString()

                If Not String.IsNullOrEmpty(cityCode) Then
                    loadCBO($"SELECT * FROM refbrgy WHERE citymuncode = {cityCode} ORDER BY brgydesc", "id", "brgydesc", AddFaculty.cbBrgy)
                    AddFaculty.cbBrgy.SelectedValue = brgyId
                End If
            End If

            _logger.LogInfo("FormFaculty - Address ComboBoxes loaded successfully for editing")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading address ComboBoxes: {ex.Message}")
        Finally
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try
        End Try
    End Sub
    Public Sub DefaultSettings()
        Try
            _logger.LogInfo("FormFaculty - Loading default settings and faculty list")

            dgvTeachers.Tag = 0
            dgvTeachers.CurrentCell = Nothing

            dgvTeachers.CellBorderStyle = DataGridViewCellBorderStyle.None
            dgvTeachers.RowTemplate.Height = 50
            dgvTeachers.DefaultCellStyle.Font = New Font("Segoe UI", 14)
            dgvTeachers.AlternatingRowsDefaultCellStyle = dgvTeachers.DefaultCellStyle
            dgvTeachers.AutoGenerateColumns = False

            ' Add event handler for row formatting
            AddHandler dgvTeachers.DataBindingComplete, AddressOf dgvTeachers_DataBindingComplete_FormatRows

            ' Initialize status filter
            LoadStatusFilter()

            ' Load departments for filtering
            LoadDepartmentFilter()

            ' Load all faculty initially
            LoadFacultyList()

            ' Initialize toggle button to default state
            ResetToggleButtonToDefault()

            _logger.LogInfo($"FormFaculty - Faculty list loaded successfully, {dgvTeachers.Rows.Count} records displayed")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error in DefaultSettings: {ex.Message}")
            Throw
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _logger.LogInfo("FormFaculty - Add Faculty button clicked, opening AddFaculty form")
        AddFaculty.ShowDialog()
        ' Refresh the list after adding
        DefaultSettings()
        _logger.LogInfo("FormFaculty - Returned from AddFaculty form, faculty list refreshed")
    End Sub

    Private Sub FormFaculty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _logger.LogInfo("FormFaculty - Form loaded, initializing default settings")
        DefaultSettings()
    End Sub

    Private Sub btnToggleStatus_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function GetFacultyStatus(facultyId As Integer) As Integer
        Try
            connectDB()
            Dim cmd As New Odbc.OdbcCommand("SELECT isActive FROM teacherinformation WHERE teacherID = ?", con)
            cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = facultyId
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error getting faculty status (ID: {facultyId}): {ex.Message}")
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
            End Try
            Return 0
        End Try
    End Function

    Private Function GetFacultyName(facultyId As Integer) As String
        Try
            connectDB()
            Dim cmd As New Odbc.OdbcCommand("SELECT CONCAT(firstname, ' ', lastname) AS full_name FROM teacherinformation WHERE teacherID = ?", con)
            cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = facultyId
            Dim result As Object = cmd.ExecuteScalar()
            con.Close()

            Return If(result IsNot Nothing, result.ToString(), "Unknown Faculty")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error getting faculty name (ID: {facultyId}): {ex.Message}")
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
            End Try
            Return "Unknown Faculty"
        End Try
    End Function
    Private Sub EditRecord(ByVal id As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim facultyName As String = ""

        Try
            _logger.LogInfo($"FormFaculty - Loading faculty record for editing - Faculty ID: {id}")

            connectDB()
            cmd = New Odbc.OdbcCommand("SELECT teacherID, profileImg, employeeID,tagID,firstname,middlename,lastname,extName, email, gender,birthdate,homeadd,brgyID, cityID, provinceID, regionID,contactNo, emergencyContact, relationship, department_id FROM teacherinformation WHERE teacherID=?", con)
            cmd.Parameters.AddWithValue("@", id)
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                facultyName = FormatFullName(dt.Rows(0)("firstname").ToString(), dt.Rows(0)("middlename").ToString(), dt.Rows(0)("lastname").ToString(), dt.Rows(0)("extName").ToString())

                AddFaculty.txtID.Text = dt.Rows(0)("teacherID").ToString()
                AddFaculty.txtEmployeeID.Text = dt.Rows(0)("employeeID").ToString()
                AddFaculty.txtTagID.Text = dt.Rows(0)("tagID").ToString()
                AddFaculty.txtFirstName.Text = dt.Rows(0)("firstname").ToString()
                AddFaculty.txtMiddleName.Text = dt.Rows(0)("middlename").ToString()
                AddFaculty.txtLastName.Text = dt.Rows(0)("lastname").ToString()
                AddFaculty.txtExtName.Text = dt.Rows(0)("extName").ToString()
                AddFaculty.txtEmail.Text = dt.Rows(0)("email").ToString()
                AddFaculty.cbGender.Text = dt.Rows(0)("gender").ToString()
                ' Handle birthdate safely
                If Not IsDBNull(dt.Rows(0)("birthdate")) Then
                    Dim birthDate As DateTime
                    If DateTime.TryParse(dt.Rows(0)("birthdate").ToString(), birthDate) Then
                        AddFaculty.dtpBirthdate.Value = birthDate
                    Else
                        ' Set to default if invalid date
                        AddFaculty.dtpBirthdate.Value = DateTime.Today.AddYears(-25)
                        _logger.LogWarning($"FormFaculty - Invalid birthdate for Faculty ID {id}, using default")
                    End If
                Else
                    AddFaculty.dtpBirthdate.Value = DateTime.Today.AddYears(-25)
                End If
                AddFaculty.txtHome.Text = dt.Rows(0)("homeadd").ToString()

                ' Load and set address ComboBoxes in proper cascade order
                LoadAddressComboBoxes(dt.Rows(0)("regionID").ToString(), dt.Rows(0)("provinceID").ToString(), dt.Rows(0)("cityID").ToString(), dt.Rows(0)("brgyID").ToString())

                AddFaculty.txtContactNo.Text = dt.Rows(0)("contactNo").ToString()
                AddFaculty.txtEmergencyContact.Text = dt.Rows(0)("emergencyContact").ToString()
                AddFaculty.cbRelationship.Text = dt.Rows(0)("relationship").ToString()

                ' Load department selection
                If Not IsDBNull(dt.Rows(0)("department_id")) Then
                    Dim departmentId As Integer = Convert.ToInt32(dt.Rows(0)("department_id"))
                    AddFaculty.SetDepartmentSelection(departmentId)
                Else
                    AddFaculty.SetDepartmentSelection(Nothing)
                End If

                Dim myreader As Odbc.OdbcDataReader = cmd.ExecuteReader
                If myreader.Read Then
                    Try
                        Dim profileImg As Byte()
                        profileImg = myreader("profileImg")
                        Dim ms As New MemoryStream(profileImg)
                        If profileImg IsNot Nothing Then
                            AddFaculty.pbProfile.Image = Image.FromStream(ms)
                        End If
                    Catch ex As Exception
                        _logger.LogWarning($"FormFaculty - Could not load profile image for Faculty ID: {id}")
                    End Try
                End If

                _logger.LogInfo($"FormFaculty - Faculty record loaded for editing - Name: '{facultyName}', Employee ID: '{dt.Rows(0)("employeeID")}'")
                AddFaculty.ShowDialog()
                ' Refresh the list after editing
                DefaultSettings()
                _logger.LogInfo("FormFaculty - Returned from edit mode, faculty list refreshed")
            Else
                _logger.LogWarning($"FormFaculty - No faculty record found with ID: {id}")
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading faculty record for editing (ID: {id}): {ex.Message}")
            MessageBox.Show(ex.Message.ToString())
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    Private Sub btnEditRecord_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        Dim facultyId As Integer = CInt(dgvTeachers.Tag)

        If dgvTeachers.Tag > 0 Then
            _logger.LogInfo($"FormFaculty - Edit button clicked for Faculty ID: {facultyId}")
            If MessageBox.Show("Are you sure you want to edit this record?", "Edit Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _logger.LogInfo($"FormFaculty - User confirmed edit for Faculty ID: {facultyId}")
                EditRecord(Val(dgvTeachers.Tag))
            Else
                _logger.LogInfo($"FormFaculty - User cancelled edit for Faculty ID: {facultyId}")
            End If
        Else
            _logger.LogWarning("FormFaculty - Edit attempted with no faculty selected")
            MessageBox.Show("Please select a record you want to edit", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim searchTerm As String = txtSearch.Text.Trim()
            Dim selectedDepartment As String = If(cboDepartment.SelectedValue IsNot Nothing, cboDepartment.SelectedValue.ToString(), "ALL")
            Dim selectedStatus As String = If(cboStatusFilter.SelectedItem IsNot Nothing, cboStatusFilter.SelectedItem.ToString(), "All")

            _logger.LogInfo($"FormFaculty - Search changed to: '{searchTerm}', Department filter: {selectedDepartment}, Status filter: {selectedStatus}")

            ' Reload faculty list with current filters
            LoadFacultyList(selectedDepartment, searchTerm, selectedStatus)

        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error during search operation: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvTeachers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeachers.CellClick
        Try
            If e.RowIndex >= 0 Then
                dgvTeachers.Tag = dgvTeachers.Item(0, e.RowIndex).Value
                _logger.LogInfo($"FormFaculty - Faculty selected - Faculty ID: {dgvTeachers.Tag}")

                ' Update toggle button based on selected row status
                UpdateToggleButtonState(e.RowIndex)
            End If
        Catch ex As Exception
            _logger.LogWarning($"FormFaculty - Error selecting faculty record: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvTeachers_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTeachers.DataBindingComplete
        dgvTeachers.CurrentCell = Nothing
    End Sub

    Private Sub dgvTeachers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTeachers.SelectionChanged
        Try
            If dgvTeachers.SelectedRows.Count > 0 Then
                Dim selectedRowIndex As Integer = dgvTeachers.SelectedRows(0).Index
                UpdateToggleButtonState(selectedRowIndex)
            Else
                ResetToggleButtonToDefault()
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error in selection changed: {ex.Message}")
            ResetToggleButtonToDefault()
        End Try
    End Sub

    Private Sub dgvTeachers_DataBindingComplete_FormatRows(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Try
            ' Format rows based on faculty status
            For Each row As DataGridViewRow In dgvTeachers.Rows
                If row.Cells("ColumnStatus") IsNot Nothing AndAlso row.Cells("ColumnStatus").Value IsNot Nothing Then
                    Dim status As String = row.Cells("ColumnStatus").Value.ToString()

                    If status = "Inactive" Then
                        ' Set light gray background for inactive faculty (not red as requested)
                        row.DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245) ' Very light gray
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(128, 128, 128) ' Medium gray text
                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 180, 180) ' Darker gray for selection
                        row.DefaultCellStyle.SelectionForeColor = Color.White

                        ' Make the status cell more prominent
                        If row.Cells("ColumnStatus") IsNot Nothing Then
                            row.Cells("ColumnStatus").Style.BackColor = Color.FromArgb(220, 220, 220)
                            row.Cells("ColumnStatus").Style.ForeColor = Color.FromArgb(100, 100, 100)
                            row.Cells("ColumnStatus").Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                        End If

                        _logger.LogInfo($"FormFaculty - Row formatted as inactive for Faculty ID: {row.Cells(0).Value}")
                    Else
                        ' Reset to default colors for active faculty
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.DimGray
                        row.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue
                        row.DefaultCellStyle.SelectionForeColor = Color.White

                        ' Make the active status more prominent
                        If row.Cells("ColumnStatus") IsNot Nothing Then
                            row.Cells("ColumnStatus").Style.BackColor = Color.FromArgb(230, 255, 230) ' Very light green
                            row.Cells("ColumnStatus").Style.ForeColor = Color.FromArgb(0, 128, 0) ' Dark green
                            row.Cells("ColumnStatus").Style.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                        End If
                    End If
                End If
            Next

            ' Reset toggle button to default state when data refreshes
            ResetToggleButtonToDefault()

            _logger.LogInfo($"FormFaculty - Row formatting completed for {dgvTeachers.Rows.Count} rows")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error formatting rows: {ex.Message}")
        End Try
    End Sub

    Private Sub UpdateToggleButtonState(rowIndex As Integer)
        Try
            If rowIndex >= 0 AndAlso rowIndex < dgvTeachers.Rows.Count Then
                Dim row As DataGridViewRow = dgvTeachers.Rows(rowIndex)

                If row.Cells("ColumnStatus") IsNot Nothing AndAlso row.Cells("ColumnStatus").Value IsNot Nothing Then
                    Dim status As String = row.Cells("ColumnStatus").Value.ToString()
                    Dim facultyName As String = If(row.Cells("Column3") IsNot Nothing AndAlso row.Cells("Column3").Value IsNot Nothing,
                                                 row.Cells("Column3").Value.ToString(), "Selected Faculty")

                    If status = "Active" Then
                        ' Faculty is active - show disable button
                        btnToggleStat.Text = "&Disable Record"
                        btnToggleStat.ForeColor = Color.Red
                        btnToggleStat.BackgroundImage = GetDisableIcon()
                        'btnToggleStat.ToolTipText = $"Click to disable {facultyName}"
                        _logger.LogInfo($"FormFaculty - Toggle button set to 'Disable' for active faculty: {facultyName}")
                    Else
                        ' Faculty is inactive - show enable button
                        btnToggleStat.Text = "&Enable Record"
                        btnToggleStat.ForeColor = Color.Green
                        btnToggleStat.BackgroundImage = GetEnableIcon()
                        'btnToggleStat.ToolTipText = $"Click to enable {facultyName}"
                        _logger.LogInfo($"FormFaculty - Toggle button set to 'Enable' for inactive faculty: {facultyName}")
                    End If

                    btnToggleStat.Enabled = True
                End If
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error updating toggle button state: {ex.Message}")
            ResetToggleButtonToDefault()
        End Try
    End Sub

    Private Sub ResetToggleButtonToDefault()
        Try
            ' Reset button to default state when no selection
            btnToggleStat.BackgroundImage = My.Resources.enable_default_40x40
            btnToggleStat.Text = "&Select Faculty"
            btnToggleStat.ForeColor = Color.DimGray
            btnToggleStat.Enabled = False
            'btnToggleStat.ToolTipText = "Select a faculty member to enable or disable"
            _logger.LogInfo("FormFaculty - Toggle button reset to default state")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error resetting toggle button: {ex.Message}")
        End Try
    End Sub

    Private Function GetEnableIcon() As Image
        Try
            ' Use the existing enable resource image
            Return My.Resources.enable
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading enable icon from resources: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Private Function GetDisableIcon() As Image
        Try
            ' Use the existing disable resource image
            Return My.Resources.disable_40x40
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading disable icon from resources: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Private Sub LoadStatusFilter()
        Try
            _logger.LogInfo("FormFaculty - Loading status filter")

            ' Initialize status filter ComboBox
            cboStatusFilter.Items.Clear()
            cboStatusFilter.Items.AddRange({"All", "Active", "Inactive"})
            cboStatusFilter.SelectedIndex = 0 ' Default to "All" to show both active and inactive faculty

            _logger.LogInfo("FormFaculty - Status filter initialized successfully")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading status filter: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadDepartmentFilter()
        Try
            _logger.LogInfo("FormFaculty - Loading departments for filtering")

            ' Create a DataTable for the ComboBox
            Dim dt As New DataTable()
            dt.Columns.Add("department_id", GetType(String))
            dt.Columns.Add("department_display", GetType(String))

            ' Add "All Departments" option first
            Dim allRow As DataRow = dt.NewRow()
            allRow("department_id") = "ALL"
            allRow("department_display") = "All Departments"
            dt.Rows.Add(allRow)

            ' Get departments from service
            Dim departmentService As New DepartmentService()
            Dim departments = departmentService.GetActiveDepartments()

            If departments IsNot Nothing AndAlso departments.Count > 0 Then
                ' Add departments to DataTable
                For Each dept As Department In departments
                    Dim row As DataRow = dt.NewRow()
                    row("department_id") = dept.DepartmentId.ToString()
                    row("department_display") = $"{dept.DepartmentCode} - {dept.DepartmentName}"
                    dt.Rows.Add(row)
                Next

                _logger.LogInfo($"FormFaculty - {departments.Count} departments loaded for filtering")
            Else
                _logger.LogWarning("FormFaculty - No departments found for filtering")
            End If

            ' Bind to ComboBox
            cboDepartment.DataSource = dt
            cboDepartment.ValueMember = "department_id"
            cboDepartment.DisplayMember = "department_display"
            cboDepartment.SelectedIndex = 0 ' Select "All Departments" by default

            _logger.LogInfo("FormFaculty - Department filter ComboBox populated successfully")

        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading department filter: {ex.Message}")

            ' Create fallback DataTable with error message
            Dim errorDt As New DataTable()
            errorDt.Columns.Add("department_id", GetType(String))
            errorDt.Columns.Add("department_display", GetType(String))

            Dim errorRow As DataRow = errorDt.NewRow()
            errorRow("department_id") = "ALL"
            errorRow("department_display") = "All Departments"
            errorDt.Rows.Add(errorRow)

            cboDepartment.DataSource = errorDt
            cboDepartment.ValueMember = "department_id"
            cboDepartment.DisplayMember = "department_display"
            cboDepartment.SelectedIndex = 0
        End Try
    End Sub

    Private Sub LoadFacultyList(Optional departmentFilter As String = "ALL", Optional searchTerm As String = "", Optional statusFilter As String = "All")
        Try
            Dim baseQuery As String = "
                SELECT ti.teacherID AS teacherID, 
                       ti.employeeID AS employeeID, 
                       " & GetNameConcatSQL() & " AS teacher_name, 
                       ti.email, 
                       ti.gender AS gender, 
                       ti.birthdate AS birthdate, 
                       ti.contactNo AS contactNo, 
                       CONCAT(ti.homeadd, ' ', COALESCE(rb.brgyDesc, ''), '. ', COALESCE(rc.citymunDesc, '')) AS teacher_address, 
                       ti.emergencyContact AS emergencyContact,
                       COALESCE(d.department_code, 'No Dept') AS department_code,
                       CASE WHEN ti.isActive = 1 THEN 'Active' ELSE 'Inactive' END AS status_text
                FROM teacherinformation ti 
                LEFT JOIN refregion rg ON ti.regionID = rg.id 
                LEFT JOIN refprovince rp ON ti.provinceID = rp.id 
                LEFT JOIN refcitymun rc ON ti.cityID = rc.id 
                LEFT JOIN refbrgy rb ON ti.brgyID = rb.id 
                LEFT JOIN departments d ON ti.department_id = d.department_id
                WHERE 1=1"

            ' Add status filter
            If statusFilter = "Active" Then
                baseQuery &= " AND ti.isActive = 1"
                _logger.LogInfo("FormFaculty - Filtering by status: Active")
            ElseIf statusFilter = "Inactive" Then
                baseQuery &= " AND ti.isActive = 0"
                _logger.LogInfo("FormFaculty - Filtering by status: Inactive")
            Else
                ' "All" - no status filter
                _logger.LogInfo("FormFaculty - Showing all faculty (Active and Inactive)")
            End If

            ' Add department filter
            If departmentFilter <> "ALL" AndAlso IsNumeric(departmentFilter) Then
                baseQuery &= $" AND ti.department_id = {departmentFilter}"
                _logger.LogInfo($"FormFaculty - Filtering by department ID: {departmentFilter}")
            ElseIf departmentFilter <> "ALL" Then
                _logger.LogWarning($"FormFaculty - Invalid department filter: {departmentFilter}")
            End If

            ' Add search filter
            If Not String.IsNullOrWhiteSpace(searchTerm) Then
                baseQuery &= $" AND (ti.lastname LIKE '%{searchTerm}%' OR ti.firstname LIKE '%{searchTerm}%' OR ti.employeeID LIKE '%{searchTerm}%')"
                _logger.LogInfo($"FormFaculty - Applying search filter: '{searchTerm}'")
            End If

            baseQuery &= " ORDER BY ti.lastname, ti.firstname"

            loadDGV(baseQuery, dgvTeachers)

            _logger.LogInfo($"FormFaculty - Faculty list loaded with filters - Department: {departmentFilter}, Status: {statusFilter}, Search: '{searchTerm}', Results: {dgvTeachers.Rows.Count}")

        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading faculty list: {ex.Message}")
            MessageBox.Show("Error loading faculty list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        Try
            If cboDepartment.SelectedValue IsNot Nothing Then
                Dim selectedDepartment As String = cboDepartment.SelectedValue.ToString()
                Dim searchTerm As String = txtSearch.Text.Trim()
                Dim selectedStatus As String = If(cboStatusFilter.SelectedItem IsNot Nothing, cboStatusFilter.SelectedItem.ToString(), "All")

                _logger.LogInfo($"FormFaculty - Department filter changed to: {cboDepartment.Text} (ID: {selectedDepartment})")

                ' Reload faculty list with new department filter
                LoadFacultyList(selectedDepartment, searchTerm, selectedStatus)
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error in department filter change: {ex.Message}")
        End Try
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        Try
            If cboStatusFilter.SelectedItem IsNot Nothing Then
                Dim selectedStatus As String = cboStatusFilter.SelectedItem.ToString()
                Dim selectedDepartment As String = If(cboDepartment.SelectedValue IsNot Nothing, cboDepartment.SelectedValue.ToString(), "ALL")
                Dim searchTerm As String = txtSearch.Text.Trim()

                _logger.LogInfo($"FormFaculty - Status filter changed to: {selectedStatus}")

                ' Reload faculty list with new status filter
                LoadFacultyList(selectedDepartment, searchTerm, selectedStatus)
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error in status filter change: {ex.Message}")
        End Try
    End Sub

    Private Sub btnToggleStat_Click(sender As Object, e As EventArgs) Handles btnToggleStat.Click
        Dim cmd As Odbc.OdbcCommand
        Dim facultyId As Integer = 0

        Try
            If dgvTeachers.Tag IsNot Nothing AndAlso IsNumeric(dgvTeachers.Tag) Then
                facultyId = CInt(dgvTeachers.Tag)
            End If

            _logger.LogInfo($"FormFaculty - Toggle Status button clicked for Faculty ID: {facultyId}")

            If facultyId > 0 Then
                ' Get current status
                Dim currentStatus As Integer = GetFacultyStatus(facultyId)
                Dim action As String = If(currentStatus = 1, "disable", "enable")
                Dim actionTitle As String = If(currentStatus = 1, "Disable", "Enable")

                ' Get faculty name for confirmation message
                Dim facultyName As String = GetFacultyName(facultyId)

                Dim result As DialogResult = MessageBox.Show(
                    $"Are you sure you want to {action} '{facultyName}'?{Environment.NewLine}{Environment.NewLine}" &
                    $"This will {If(currentStatus = 1, "deactivate the faculty member and they will no longer appear in active lists", "reactivate the faculty member and they will appear in active lists again")}.",
                    $"Confirm {actionTitle}",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    _logger.LogInfo($"FormFaculty - User confirmed {action} for Faculty ID: {facultyId}")

                    ' Toggle the status
                    connectDB()
                    cmd = New Odbc.OdbcCommand("UPDATE teacherinformation SET isActive = IF(isActive = 1, 0, 1) WHERE teacherID = ?", con)
                    cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = facultyId
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Dim newStatus As String = If(currentStatus = 1, "disabled", "enabled")
                    _logger.LogInfo($"FormFaculty - Faculty status toggled successfully - Faculty ID: {facultyId}, Status: {newStatus}")
                    MessageBox.Show($"Faculty member has been {newStatus} successfully.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh the list after successful status change
                    DefaultSettings()
                Else
                    _logger.LogInfo($"FormFaculty - User cancelled {action} for Faculty ID: {facultyId}")
                End If
            Else
                _logger.LogWarning("FormFaculty - Toggle Status attempted with no faculty selected")
                MessageBox.Show("Please select a faculty member to change their status.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error toggling faculty status (ID: {facultyId}): {ex.Message}")
            MessageBox.Show("Error updating faculty status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try
            GC.Collect()
        End Try
    End Sub
End Class