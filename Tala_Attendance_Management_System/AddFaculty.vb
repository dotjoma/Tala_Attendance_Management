Imports System.Data.Odbc
Imports System.IO

Public Class AddFaculty
    Public browse As OpenFileDialog = New OpenFileDialog
    Private Sub AddFaculty_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddFaculty_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim teacher As FormFaculty = TryCast(Application.OpenForms("FormFaculty"), FormFaculty)
        If teacher IsNot Nothing Then
            teacher.DefaultSettings()
        End If
        ClearFields(panelContainer)
        txtID.Text = "0"
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
        'pbProfile.Image.Save(ms, pbProfile.Image.RawFormat)

        If Trim(txtExtName.TextLength) <= 0 Then
            txtExtName.Text = tmpString
        End If
        If txtTagID.TextLength <= 0 Then
            txtTagID.Text = tmpString
        End If
        If fieldChecker(panelContainer) = True Then
            Try
                Call connectDB()
                pbProfile.Image.Save(ms, pbProfile.Image.RawFormat)
                If pbProfile.Image IsNot Nothing Then
                    If Val(txtID.Text) > 0 Then
                        cmd = New System.Data.Odbc.OdbcCommand(updateTeacher, con)
                        With cmd.Parameters
                            .AddWithValue("@", Trim(txtEmployeeID.Text))
                            .AddWithValue("@", ms.ToArray)
                            .AddWithValue("@", Trim(txtTagID.Text))
                            .AddWithValue("@", Trim(txtLastName.Text))
                            .AddWithValue("@", Trim(txtFirstName.Text))
                            .AddWithValue("@", Trim(txtMiddleName.Text))
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
                        MsgBox("Record has been updated.", vbInformation, "Updated")
                        cmd.ExecuteNonQuery()
                        Me.Close()
                    Else
                        cmd = New System.Data.Odbc.OdbcCommand(insertTeacher, con)
                        With cmd.Parameters
                            .AddWithValue("@", Trim(txtEmployeeID.Text))
                            .AddWithValue("@", ms.ToArray)
                            .AddWithValue("@", Trim(txtTagID.Text))
                            .AddWithValue("@", Trim(txtLastName.Text))
                            .AddWithValue("@", Trim(txtFirstName.Text))
                            .AddWithValue("@", Trim(txtMiddleName.Text))
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
                        MsgBox("New record added successfully", vbInformation, "Success")
                        Me.Close()
                    End If
                    cmd.ExecuteNonQuery()
                    ClearFields(panelContainer)
                Else
                    MessageBox.Show("Profile picture should not be empty. Please select a picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
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