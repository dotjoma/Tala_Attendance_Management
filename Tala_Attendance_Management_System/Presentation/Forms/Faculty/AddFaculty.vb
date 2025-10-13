Imports System.Data.Odbc
Imports System.IO

Public Class AddFaculty
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Public browse As OpenFileDialog = New OpenFileDialog
    Private Sub AddFaculty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mode As String = If(Val(txtID.Text) > 0, "Edit", "Add New")
            _logger.LogInfo($"AddFaculty form opened - Mode: {mode}, Faculty ID: {txtID.Text}")

            ' Load departments when form loads
            LoadDepartments()

            ' If in edit mode, load faculty data including department
            If Val(txtID.Text) > 0 Then
                LoadFacultyData(Val(txtID.Text))
            End If

        Catch ex As Exception
            _logger.LogError("Error in AddFaculty_Load", ex)
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            _logger.LogInfo("AddFaculty - Loading departments into ComboBox")

            ' Create a DataTable for the ComboBox
            Dim dt As New DataTable()
            dt.Columns.Add("department_id", GetType(Integer))
            dt.Columns.Add("department_display", GetType(String))

            ' Add "No Department" option first (required selection)
            Dim noDataRow As DataRow = dt.NewRow()
            noDataRow("department_id") = DBNull.Value
            noDataRow("department_display") = "-- Select Department (Required) --"
            dt.Rows.Add(noDataRow)

            ' Get departments from service
            Dim departmentService As New DepartmentService()
            Dim departments = departmentService.GetActiveDepartments()

            If departments IsNot Nothing AndAlso departments.Count > 0 Then
                ' Add departments to DataTable
                For Each dept As Department In departments
                    Dim row As DataRow = dt.NewRow()
                    row("department_id") = dept.DepartmentId
                    row("department_display") = $"{dept.DepartmentCode} - {dept.DepartmentName}"
                    dt.Rows.Add(row)
                Next

                _logger.LogInfo($"AddFaculty - {departments.Count} departments loaded successfully")
            Else
                ' Add "No departments available" option
                Dim noDeptsRow As DataRow = dt.NewRow()
                noDeptsRow("department_id") = DBNull.Value
                noDeptsRow("department_display") = "-- No Departments Available --"
                dt.Rows.Add(noDeptsRow)

                _logger.LogWarning("AddFaculty - No departments found in database")
            End If

            ' Bind to ComboBox
            cboDepartment.DataSource = dt
            cboDepartment.ValueMember = "department_id"
            cboDepartment.DisplayMember = "department_display"
            cboDepartment.SelectedIndex = 0

            _logger.LogInfo("AddFaculty - Department ComboBox populated successfully")

        Catch ex As Exception
            _logger.LogError($"AddFaculty - Error loading departments: {ex.Message}")

            ' Create fallback DataTable with error message
            Dim errorDt As New DataTable()
            errorDt.Columns.Add("department_id", GetType(Integer))
            errorDt.Columns.Add("department_display", GetType(String))

            Dim errorRow As DataRow = errorDt.NewRow()
            errorRow("department_id") = DBNull.Value
            errorRow("department_display") = "-- Error Loading Departments --"
            errorDt.Rows.Add(errorRow)

            cboDepartment.DataSource = errorDt
            cboDepartment.ValueMember = "department_id"
            cboDepartment.DisplayMember = "department_display"
            cboDepartment.SelectedIndex = 0

            MessageBox.Show("Error loading departments. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub AddFaculty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            _logger.LogInfo("AddFaculty form closing")
            Dim teacher As FormFaculty = TryCast(Application.OpenForms("FormFaculty"), FormFaculty)
            If teacher IsNot Nothing Then
                teacher.DefaultSettings()
            End If
            FormHelper.ClearFields(panelContainer)
            txtID.Text = "0"
        Catch ex As Exception
            _logger.LogError("Error in AddFaculty_FormClosing", ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cmd As System.Data.Odbc.OdbcCommand
        Dim da As New System.Data.Odbc.OdbcDataAdapter
        Dim insertTeacher As String = "INSERT INTO teacherinformation(employeeID, profileImg, tagID, lastname, firstname, middlename, extName, email, gender, birthdate, contactNo, homeadd, brgyID, cityID, provinceID, regionID, emergencyContact, relationship, department_id) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
        Dim updateTeacher As String = "UPDATE teacherinformation SET employeeID=?, profileImg=?, tagID=?, lastname=?, firstname=?, middlename=?, extName=?, email=?, gender=?, birthdate=?, contactNo=?, homeadd=?, brgyID=?, cityID=?, provinceID=?, regionID=?, emergencyContact=?, relationship=?, department_id=? WHERE teacherID=?"

        Dim tmpString = "--"
        Dim ms As New MemoryStream

        ' Format faculty name for logging
        Dim facultyName As String = NameFormatter.FormatFullName(Trim(txtFirstName.Text), Trim(txtMiddleName.Text), Trim(txtLastName.Text), Trim(txtExtName.Text))

        ' Get selected department ID
        Dim selectedDepartmentId = GetSelectedDepartmentId()

        _logger.LogInfo($"Faculty save initiated - Name: '{facultyName}', Employee ID: '{Trim(txtEmployeeID.Text)}', Department ID: {If(selectedDepartmentId.HasValue, selectedDepartmentId.Value.ToString(), "None")}, Mode: {If(Val(txtID.Text) > 0, "Update", "Create")}")

        If Trim(txtExtName.TextLength) <= 0 Then
            txtExtName.Text = tmpString
        End If
        If txtTagID.TextLength <= 0 Then
            txtTagID.Text = tmpString
        End If

        ' Prepare middle name value (NULL if empty, otherwise the actual value)
        Dim middleNameValue As Object = If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, Trim(txtMiddleName.Text))

        ' Validate required fields
        If Not ValidationHelper.ValidateRequiredFields(panelContainer) Then
            _logger.LogWarning($"Faculty save validation failed - Required fields missing for '{facultyName}'")
            Return
        End If

        ' Validate department selection (required for new faculty)
        If Not ValidationHelper.ValidateDepartmentSelection(cboDepartment, isRequired:=True) Then
            _logger.LogWarning($"Faculty save validation failed - Department not selected for '{facultyName}'")
            Return
        End If
        Try
            Call connectDB()
            pbProfile.Image.Save(ms, pbProfile.Image.RawFormat)
            If pbProfile.Image IsNot Nothing Then
                If Val(txtID.Text) > 0 Then
                    _logger.LogInfo($"Updating faculty record - ID: {txtID.Text}, Name: '{facultyName}'")
                    cmd = New System.Data.Odbc.OdbcCommand(updateTeacher, con)
                    With cmd.Parameters
                        .AddWithValue("@", Trim(txtEmployeeID.Text))
                        .AddWithValue("@", ms.ToArray)
                        .AddWithValue("@", Trim(txtTagID.Text))
                        .AddWithValue("@", Trim(txtLastName.Text))
                        .AddWithValue("@", Trim(txtFirstName.Text))
                        .AddWithValue("@", middleNameValue)
                        .AddWithValue("@", Trim(txtExtName.Text))
                        .AddWithValue("@", Trim(txtEmail.Text))
                        .AddWithValue("@", Trim(cbGender.Text))
                        .AddWithValue("@", dtpBirthdate.Text)
                        .AddWithValue("@", Trim(txtContactNo.Text))
                        .AddWithValue("@", Trim(txtHome.Text))
                        .AddWithValue("@", cbBrgy.SelectedValue)
                        .AddWithValue("@", cbCity.SelectedValue)
                        .AddWithValue("@", cbProvince.SelectedValue)
                        .AddWithValue("@", cbRegion.SelectedValue)
                        .AddWithValue("@", Trim(txtEmergencyContact.Text))
                        .AddWithValue("@", cbRelationship.Text)
                        .AddWithValue("@", If(selectedDepartmentId.HasValue, selectedDepartmentId.Value, DBNull.Value))
                        .AddWithValue("@", txtID.Text)
                    End With
                    cmd.ExecuteNonQuery()
                    _logger.LogInfo($"Faculty record updated successfully - ID: {txtID.Text}, Name: '{facultyName}', Employee ID: '{Trim(txtEmployeeID.Text)}'")
                    MsgBox("Record has been updated.", vbInformation, "Updated")
                    Me.Close()
                Else
                    _logger.LogInfo($"Creating new faculty record - Name: '{facultyName}', Employee ID: '{Trim(txtEmployeeID.Text)}'")
                    cmd = New System.Data.Odbc.OdbcCommand(insertTeacher, con)
                    With cmd.Parameters
                        .AddWithValue("@", Trim(txtEmployeeID.Text))
                        .AddWithValue("@", ms.ToArray)
                        .AddWithValue("@", Trim(txtTagID.Text))
                        .AddWithValue("@", Trim(txtLastName.Text))
                        .AddWithValue("@", Trim(txtFirstName.Text))
                        .AddWithValue("@", middleNameValue)
                        .AddWithValue("@", Trim(txtExtName.Text))
                        .AddWithValue("@", Trim(txtEmail.Text))
                        .AddWithValue("@", Trim(cbGender.Text))
                        .AddWithValue("@", dtpBirthdate.Text)
                        .AddWithValue("@", Trim(txtContactNo.Text))
                        .AddWithValue("@", Trim(txtHome.Text))
                        .AddWithValue("@", cbBrgy.SelectedValue)
                        .AddWithValue("@", cbCity.SelectedValue)
                        .AddWithValue("@", cbProvince.SelectedValue)
                        .AddWithValue("@", cbRegion.SelectedValue)
                        .AddWithValue("@", Trim(txtEmergencyContact.Text))
                        .AddWithValue("@", cbRelationship.Text)
                        .AddWithValue("@", If(selectedDepartmentId.HasValue, selectedDepartmentId.Value, DBNull.Value))
                    End With
                    cmd.ExecuteNonQuery()
                    _logger.LogInfo($"Faculty record created successfully - Name: '{facultyName}', Employee ID: '{Trim(txtEmployeeID.Text)}', RFID: '{Trim(txtTagID.Text)}'")
                    MsgBox("New record added successfully", vbInformation, "Success")
                    Me.Close()
                End If
                FormHelper.ClearFields(panelContainer)
            Else
                _logger.LogWarning($"Faculty save failed - Profile picture missing for '{facultyName}'")
                MessageBox.Show("Profile picture should not be empty. Please select a picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            _logger.LogError($"Error saving faculty record - Name: '{facultyName}', Employee ID: '{Trim(txtEmployeeID.Text)}'", ex)
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Sub cbProvince_Click(sender As Object, e As EventArgs) Handles cbProvince.Click
        Dim code As String
        Dim cmd As System.Data.Odbc.OdbcCommand
        Try
            connectDB()
            cmd = New System.Data.Odbc.OdbcCommand("SELECT * FROM refregion WHERE regDesc = ?", con)
            cmd.Parameters.AddWithValue("?", cbRegion.Text)

            Dim myreader As OdbcDataReader = cmd.ExecuteReader
            If myreader.Read Then
                code = myreader("regCode")
                FormHelper.LoadComboBox("SELECT * FROM refprovince WHERE regCode= " & code & " ORDER BY provdesc", "id", "provdesc", cbProvince)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProvince.SelectedIndexChanged
        cbCity.SelectedIndex = -1
        cbBrgy.SelectedIndex = -1
    End Sub

    Private Sub cbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegion.SelectedIndexChanged
        cbProvince.SelectedIndex = -1
        cbCity.SelectedIndex = -1
        cbBrgy.SelectedIndex = -1
    End Sub

    Private Sub cbRegion_Click(sender As Object, e As EventArgs) Handles cbRegion.Click
        FormHelper.LoadComboBox("SELECT * FROM refregion ORDER BY regDesc", "id", "regDesc", cbRegion)
    End Sub

    Private Sub cbCity_Click(sender As Object, e As EventArgs) Handles cbCity.Click
        Dim code As String
        Dim cmd As System.Data.Odbc.OdbcCommand

        Try
            connectDB()
            cmd = New System.Data.Odbc.OdbcCommand("SELECT * FROM refprovince WHERE provdesc = ?", con)
            cmd.Parameters.AddWithValue("?", cbProvince.Text)

            Dim myreader As OdbcDataReader = cmd.ExecuteReader
            If myreader.Read Then
                code = myreader("provCode")
                FormHelper.LoadComboBox("SELECT * FROM refcitymun WHERE provcode = " & code & " ORDER BY citymundesc", "id", "citymundesc", cbCity)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCity.SelectedIndexChanged
        cbBrgy.SelectedIndex = -1
    End Sub

    Private Sub cbBrgy_Click(sender As Object, e As EventArgs) Handles cbBrgy.Click
        Dim code As String
        Dim cmd As System.Data.Odbc.OdbcCommand
        Try
            connectDB()
            cmd = New System.Data.Odbc.OdbcCommand("SELECT * FROM refcitymun WHERE citymundesc = ?", con)
            cmd.Parameters.AddWithValue("?", cbCity.Text)

            Dim myreader As OdbcDataReader = cmd.ExecuteReader
            If myreader.Read Then
                code = myreader("citymuncode")
                FormHelper.LoadComboBox("SELECT * FROM refbrgy WHERE citymuncode = " & code & " ORDER BY brgyDesc", "id", "brgyDesc", cbBrgy)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            browse.FileName = ""
            browse.Filter = "Image Files(*.jpg)|*.jpg;*.png;*.jpeg;"
            If browse.ShowDialog = Windows.Forms.DialogResult.OK Then
                pbProfile.Image = Image.FromFile(browse.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddIDCard_Click(sender As Object, e As EventArgs) Handles btnAddIDCard.Click
        FormIDScanner.txtFlag.Text = "2"
        FormIDScanner.ShowDialog()
    End Sub

    Private Sub btnAddDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        Try
            _logger.LogInfo("AddFaculty - Add Department button clicked")

            ' Open the AddDepartment form
            Using addDeptForm As New AddDepartment()
                Dim result = addDeptForm.ShowDialog()

                If result = DialogResult.OK Then
                    _logger.LogInfo("AddFaculty - Department added successfully, refreshing ComboBox")

                    ' Store the currently selected department (if any) to restore selection
                    Dim currentSelection As Object = cboDepartment.SelectedValue

                    ' Reload departments
                    LoadDepartments()

                    ' Try to restore selection or select the newly added department
                    If currentSelection IsNot Nothing AndAlso Not IsDBNull(currentSelection) Then
                        cboDepartment.SelectedValue = currentSelection
                    End If

                    MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    _logger.LogInfo("AddFaculty - Add Department cancelled by user")
                End If
            End Using

        Catch ex As Exception
            _logger.LogError($"AddFaculty - Error in Add Department: {ex.Message}")
            MessageBox.Show("Error opening Add Department form. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Helper method to get selected department ID
    Private Function GetSelectedDepartmentId() As Integer?
        Try
            If cboDepartment.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cboDepartment.SelectedValue) Then
                Return Convert.ToInt32(cboDepartment.SelectedValue)
            End If
            Return Nothing
        Catch ex As Exception
            _logger.LogWarning($"AddFaculty - Error getting selected department ID: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ' Method to load faculty data when editing
    Private Sub LoadFacultyData(facultyId As Integer)
        Try
            _logger.LogInfo($"AddFaculty - Loading faculty data for ID: {facultyId}")

            Dim cmd As OdbcCommand
            connectDB()

            ' Query to get faculty data including department information
            Dim query As String = "
                SELECT t.*, d.department_id, d.department_code, d.department_name
                FROM teacherinformation t
                LEFT JOIN departments d ON t.department_id = d.department_id
                WHERE t.teacherID = ?"

            cmd = New OdbcCommand(query, con)
            cmd.Parameters.AddWithValue("?", facultyId)

            Dim reader As OdbcDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Load basic faculty information (this might already be loaded by the calling form)
                ' But we specifically need to load the department

                If Not IsDBNull(reader("department_id")) Then
                    Dim departmentId As Integer = Convert.ToInt32(reader("department_id"))
                    Dim departmentCode As String = reader("department_code").ToString()
                    Dim departmentName As String = reader("department_name").ToString()

                    _logger.LogInfo($"AddFaculty - Faculty {facultyId} belongs to department: {departmentCode} - {departmentName} (ID: {departmentId})")

                    ' Set the department selection
                    SetDepartmentSelection(departmentId)
                Else
                    _logger.LogInfo($"AddFaculty - Faculty {facultyId} has no department assigned")
                    SetDepartmentSelection(Nothing)
                End If
            Else
                _logger.LogWarning($"AddFaculty - Faculty with ID {facultyId} not found")
                SetDepartmentSelection(Nothing)
            End If

            reader.Close()

        Catch ex As Exception
            _logger.LogError($"AddFaculty - Error loading faculty data for ID {facultyId}: {ex.Message}")
            SetDepartmentSelection(Nothing)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    ' Method to set department selection (useful when editing faculty)
    Public Sub SetDepartmentSelection(departmentId As Integer?)
        Try
            If departmentId.HasValue Then
                cboDepartment.SelectedValue = departmentId.Value
                _logger.LogInfo($"AddFaculty - Department selection set to ID: {departmentId.Value}")
            Else
                cboDepartment.SelectedIndex = 0 ' Select "-- Select Department (Required) --"
                _logger.LogInfo("AddFaculty - Department selection cleared")
            End If
        Catch ex As Exception
            _logger.LogWarning($"AddFaculty - Error setting department selection: {ex.Message}")
            cboDepartment.SelectedIndex = 0
        End Try
    End Sub
End Class