Imports System.Data.Odbc
Imports System.IO

Public Class AddFaculty
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Public browse As OpenFileDialog = New OpenFileDialog
    Private Sub AddFaculty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mode As String = If(Val(txtID.Text) > 0, "Edit", "Add New")
            _logger.LogInfo($"AddFaculty form opened - Mode: {mode}, Faculty ID: {txtID.Text}")
        Catch ex As Exception
            _logger.LogError("Error in AddFaculty_Load", ex)
        End Try
    End Sub

    Private Sub AddFaculty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            _logger.LogInfo("AddFaculty form closing")
            Dim teacher As FormFaculty = TryCast(Application.OpenForms("FormFaculty"), FormFaculty)
            If teacher IsNot Nothing Then
                teacher.DefaultSettings()
            End If
            ClearFields(panelContainer)
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
        Dim insertTeacher As String = "INSERT INTO teacherinformation(employeeID, profileImg, tagID, lastname, firstname, middlename, extName, email, gender, birthdate, contactNo, homeadd, brgyID, cityID, provinceID, regionID,emergencyContact, relationship) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
        Dim updateTeacher As String = "UPDATE teacherinformation SET employeeID=?, profileImg=?, tagID=?, lastname=?, firstname=?, middlename=?, extName=?, email=?, gender=?, birthdate=?, contactNo=?, homeadd=?, brgyID=?, cityID=?, provinceID=?, regionID=?, emergencyContact=?, relationship=? WHERE teacherID=?"

        Dim tmpString = "--"
        Dim ms As New MemoryStream
        
        ' Format faculty name for logging
        Dim facultyName As String = FormatFullName(Trim(txtFirstName.Text), Trim(txtMiddleName.Text), Trim(txtLastName.Text), Trim(txtExtName.Text))
        
        _logger.LogInfo($"Faculty save initiated - Name: '{facultyName}', Employee ID: '{Trim(txtEmployeeID.Text)}', Mode: {If(Val(txtID.Text) > 0, "Update", "Create")}")

        If Trim(txtExtName.TextLength) <= 0 Then
            txtExtName.Text = tmpString
        End If
        If txtTagID.TextLength <= 0 Then
            txtTagID.Text = tmpString
        End If
        
        ' Prepare middle name value (NULL if empty, otherwise the actual value)
        Dim middleNameValue As Object = If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, Trim(txtMiddleName.Text))
        
        ' Validate required fields
        If fieldChecker(panelContainer) = False Then
            _logger.LogWarning($"Faculty save validation failed - Required fields missing for '{facultyName}'")
            Return
        End If
        
        If fieldChecker(panelContainer) = True Then
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
                        End With
                        cmd.ExecuteNonQuery()
                        _logger.LogInfo($"Faculty record created successfully - Name: '{facultyName}', Employee ID: '{Trim(txtEmployeeID.Text)}', RFID: '{Trim(txtTagID.Text)}'")
                        MsgBox("New record added successfully", vbInformation, "Success")
                        Me.Close()
                    End If
                    ClearFields(panelContainer)
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
        End If
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
                loadCBO("SELECT * FROM refprovince WHERE regCode= " & code & " ORDER BY provdesc", "id", "provdesc", cbProvince)
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
        loadCBO("SELECT * FROM refregion ORDER BY regDesc", "id", "regDesc", cbRegion)
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
                loadCBO("SELECT * FROM refcitymun WHERE provcode = " & code & " ORDER BY citymundesc", "id", "citymundesc", cbCity)
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
                loadCBO("SELECT * FROM refbrgy WHERE citymuncode = " & code & " ORDER BY brgyDesc", "id", "brgyDesc", cbBrgy)
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


End Class