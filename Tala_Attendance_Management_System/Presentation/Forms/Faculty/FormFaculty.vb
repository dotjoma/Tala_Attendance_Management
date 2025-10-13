Imports System.IO
Imports System.Data.Odbc
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

            ' Load Province ComboBox based on selected region
            If Not String.IsNullOrEmpty(regionId) Then
                connectDB() ' Ensure fresh connection
                Dim regionCmd As New OdbcCommand("SELECT regCode FROM refregion WHERE id = ?", con)
                regionCmd.Parameters.AddWithValue("?", regionId)
                Dim regionCode As String = regionCmd.ExecuteScalar()?.ToString()

                If Not String.IsNullOrEmpty(regionCode) Then
                    FormHelper.LoadComboBox($"SELECT * FROM refprovince WHERE regCode = {regionCode} ORDER BY provdesc", "id", "provdesc", AddFaculty.cbProvince)
                    AddFaculty.cbProvince.SelectedValue = provinceId
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

            ' Load departments for filtering
            LoadDepartmentFilter()

            ' Load all faculty initially
            LoadFacultyList()

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

    Private Sub btnDeleteRecord_Click(sender As Object, e As EventArgs) Handles btnDeleteRecord.Click
        Dim cmd As Odbc.OdbcCommand
        Dim facultyId As Integer = 0

        Try
            If dgvTeachers.Tag IsNot Nothing AndAlso IsNumeric(dgvTeachers.Tag) Then
                facultyId = CInt(dgvTeachers.Tag)
            End If

            _logger.LogInfo($"FormFaculty - Delete button clicked for Faculty ID: {facultyId}")

            If facultyId > 0 Then
                If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _logger.LogWarning($"FormFaculty - User confirmed deletion of Faculty ID: {facultyId}")

                    ' Ensure fresh connection for delete operation
                    connectDB()
                    cmd = New Odbc.OdbcCommand("UPDATE teacherinformation SET isActive=0 WHERE teacherID=?", con)
                    cmd.Parameters.AddWithValue("@", facultyId)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    _logger.LogInfo($"FormFaculty - Faculty record deleted successfully - Faculty ID: {facultyId}")
                    MessageBox.Show("Record has been deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh the list after successful deletion
                    DefaultSettings()
                Else
                    _logger.LogInfo($"FormFaculty - User cancelled deletion of Faculty ID: {facultyId}")
                End If
            Else
                _logger.LogWarning("FormFaculty - Delete attempted with no faculty selected")
                MessageBox.Show("Please select a record you want to delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error deleting faculty record (ID: {facultyId}): {ex.Message}")
            MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                AddFaculty.dtpBirthdate.Text = dt.Rows(0)("birthdate").ToString()
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

            _logger.LogInfo($"FormFaculty - Search changed to: '{searchTerm}', Department filter: {selectedDepartment}")

            ' Reload faculty list with current filters
            LoadFacultyList(selectedDepartment, searchTerm)

        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error during search operation: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvTeachers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeachers.CellClick
        Try
            If e.RowIndex >= 0 Then
                dgvTeachers.Tag = dgvTeachers.Item(0, e.RowIndex).Value
                _logger.LogInfo($"FormFaculty - Faculty selected - Faculty ID: {dgvTeachers.Tag}")
            End If
        Catch ex As Exception
            _logger.LogWarning($"FormFaculty - Error selecting faculty record: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvTeachers_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTeachers.DataBindingComplete
        dgvTeachers.CurrentCell = Nothing
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

    Private Sub LoadFacultyList(Optional departmentFilter As String = "ALL", Optional searchTerm As String = "")
        Try
            Dim baseQuery As String = "
                SELECT ti.teacherID AS teacherID, 
                       ti.employeeID AS employeeID, 
                       " & GetNameConcatSQL() & " AS teacher_name, 
                       ti.email, 
                       ti.gender AS gender, 
                       ti.birthdate AS birthdate, 
                       ti.contactNo AS contactNo, 
                       CONCAT(ti.homeadd, ' ', rb.brgyDesc, '. ', rc.citymunDesc) AS teacher_address, 
                       ti.emergencyContact AS emergencyContact,
                       COALESCE(d.department_code, 'No Dept') AS department_code
                FROM teacherinformation ti 
                JOIN refregion rg ON ti.regionID = rg.id 
                JOIN refprovince rp ON ti.provinceID = rp.id 
                JOIN refcitymun rc ON ti.cityID = rc.id 
                JOIN refbrgy rb ON ti.brgyID = rb.id 
                LEFT JOIN departments d ON ti.department_id = d.department_id
                WHERE ti.isActive = 1"

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

            _logger.LogInfo($"FormFaculty - Faculty list loaded with filters - Department: {departmentFilter}, Search: '{searchTerm}', Results: {dgvTeachers.Rows.Count}")

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

                _logger.LogInfo($"FormFaculty - Department filter changed to: {cboDepartment.Text} (ID: {selectedDepartment})")

                ' Reload faculty list with new department filter
                LoadFacultyList(selectedDepartment, searchTerm)
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error in department filter change: {ex.Message}")
        End Try
    End Sub
End Class