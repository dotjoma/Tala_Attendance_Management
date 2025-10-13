Imports System.Data.Odbc
Imports System.IO

Public Class AddStudents
    Public browse As OpenFileDialog = New OpenFileDialog

    Private Sub AddStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cmd As System.Data.Odbc.OdbcCommand
        Dim da As New System.Data.Odbc.OdbcDataAdapter
        Dim insertStudent As String = "INSERT INTO studentrecords(profilepicture,lrn, tagID, lastname, firstname, middlename, gender, birthdate,parentID, contactNo, extName, regionID, provinceID, cityID, brgyID, homeadd, gradeID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
        Dim updateStudent As String = "UPDATE studentrecords SET profilepicture=?, lrn=?, tagID=?, lastname=?, firstname=?, middlename=?, gender=?, birthdate=?,parentID=?, contactNo=?, extName=?, regionID=?, provinceID=?, cityID=?, brgyID=?, homeadd=?, gradeID=? WHERE studID=?"

        Dim insertGuardian As String = "INSERT INTO parentrecords(lastname, firstname, middlename, gender,address, relationship) VALUES(?,?,?,?,?,?)"
        Dim updateGuardian As String = "UPDATE parentrecords SET lastname=?, firstname=?, middlename=?, gender=?, address=?, relationship=? WHERE parentID=?"

        Dim address = txtHome.Text + ". " + cbBrgy.Text + ", " + cbCity.Text

        Dim parentID As Integer = 0

        Dim ms As New MemoryStream

        Dim tmpString As String = "-"
        If txtTagID.TextLength <= 0 Then
            txtTagID.Text = tmpString
        End If
        If txtExtName.TextLength <= 0 Then
            txtExtName.Text = tmpString
        End If
        If txtPExtName.TextLength <= 0 Then
            txtPExtName.Text = tmpString
        End If


        If fieldChecker(panelContainer) = True Then
            Try
                pbProfile.Image.Save(ms, pbProfile.Image.RawFormat)

                connectDB()

                If Val(txtID.Text) > 0 Then
                    cmd = New System.Data.Odbc.OdbcCommand(updateGuardian, con)
                    With cmd.Parameters
                        .AddWithValue("@", Trim(txtPLastName.Text))
                        .AddWithValue("@", Trim(txtPFirstName.Text))
                        .AddWithValue("@", Trim(txtPMiddleName.Text))
                        .AddWithValue("@", Trim(cbPGender.Text))
                        .AddWithValue("@", address)
                        .AddWithValue("@", Trim(cbRelationship.Text))
                        .AddWithValue("@", Trim(txtID.Text))
                    End With
                    cmd.ExecuteNonQuery()

                    cmd = New System.Data.Odbc.OdbcCommand(updateStudent, con)
                    With cmd.Parameters
                        .AddWithValue("@", ms.ToArray())
                        .AddWithValue("@", Trim(txtLrn.Text))
                        .AddWithValue("@", Trim(txtTagID.Text))
                        .AddWithValue("@", Trim(txtLastName.Text))
                        .AddWithValue("@", Trim(txtFirstName.Text))
                        .AddWithValue("@", Trim(txtMiddleName.Text))
                        .AddWithValue("@", Trim(cbGender.Text))
                        .AddWithValue("@", dtpBirthdate.Text)
                        .AddWithValue("@", txtID.Text) 'txtID and ParentID is the same but in update parentID has 0 value so we use txtID
                        .AddWithValue("@", Trim(txtContactNo.Text))
                        .AddWithValue("@", Trim(txtExtName.Text))
                        .AddWithValue("@", cbRegion.SelectedValue)
                        .AddWithValue("@", cbProvince.SelectedValue)
                        .AddWithValue("@", cbCity.SelectedValue)
                        .AddWithValue("@", cbBrgy.SelectedValue)
                        .AddWithValue("@", txtHome.Text)
                        .AddWithValue("@", cbGradeLevel.SelectedValue)
                        .AddWithValue("@", txtID.Text)
                    End With
                    MsgBox("Record has been updated.", vbInformation, "Updated")
                    cmd.ExecuteNonQuery()
                    Me.Close()
                Else
                    cmd = New System.Data.Odbc.OdbcCommand(insertGuardian, con)
                    With cmd.Parameters
                        .AddWithValue("@", Trim(txtPLastName.Text))
                        .AddWithValue("@", Trim(txtPFirstName.Text))
                        .AddWithValue("@", Trim(txtPMiddleName.Text))
                        .AddWithValue("@", Trim(cbPGender.Text))

                        .AddWithValue("@", address)
                        .AddWithValue("@", Trim(cbRelationship.Text))
                    End With
                    cmd.ExecuteNonQuery()

                    Dim parentIDQuery As String = "SELECT LAST_INSERT_ID()"
                    Using parentIDCmd As New OdbcCommand(parentIDQuery, con)
                        parentID = Convert.ToInt32(parentIDCmd.ExecuteScalar())
                    End Using

                    cmd = New System.Data.Odbc.OdbcCommand(insertStudent, con)
                    With cmd.Parameters
                        .AddWithValue("@", ms.ToArray())
                        .AddWithValue("@", Trim(txtLrn.Text))
                        .AddWithValue("@", Trim(txtTagID.Text))
                        .AddWithValue("@", Trim(txtLastName.Text))
                        .AddWithValue("@", Trim(txtFirstName.Text))
                        .AddWithValue("@", Trim(txtMiddleName.Text))
                        .AddWithValue("@", Trim(cbGender.Text))
                        .AddWithValue("@", dtpBirthdate.Text)
                        .AddWithValue("@", parentID)
                        .AddWithValue("@", Trim(txtContactNo.Text))
                        .AddWithValue("@", Trim(txtExtName.Text))
                        .AddWithValue("@", cbRegion.SelectedValue)
                        .AddWithValue("@", cbProvince.SelectedValue)
                        .AddWithValue("@", cbCity.SelectedValue)
                        .AddWithValue("@", cbBrgy.SelectedValue)
                        .AddWithValue("@", txtHome.Text)
                        .AddWithValue("@", cbGradeLevel.SelectedValue)
                    End With
                    MsgBox("New record added successfully", vbInformation, "Success")
                    cmd.ExecuteNonQuery()
                    Me.Close()
                End If
                'cmd.ExecuteNonQuery()
                ClearFields(panelContainer)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            Finally
                con.Close()
                GC.Collect()
            End Try
        End If
    End Sub

    Private Sub cbRegion_Click(sender As Object, e As EventArgs) Handles cbRegion.Click
        loadCBO("SELECT * FROM refregion ORDER BY regDesc", "id", "regDesc", cbRegion)
    End Sub

    Private Sub cbRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRegion.SelectedIndexChanged
        cbProvince.SelectedIndex = -1
        cbCity.SelectedIndex = -1
        cbBrgy.SelectedIndex = -1
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

    Private Sub AddStudents_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim student As FormStudents = TryCast(Application.OpenForms("FormStudents"), FormStudents)
        If student IsNot Nothing Then
            student.DefaultSettings()
            'MainForm.tsStudents.PerformClick()
        End If
        ClearFields(panelContainer)
        txtID.Text = "0"
    End Sub

    Private Sub btnAddIDCard_Click(sender As Object, e As EventArgs) Handles btnAddIDCard.Click
        FormIDScanner.txtFlag.Text = "1"
        FormIDScanner.ShowDialog()
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

    Private Sub cbGradeLevel_Click(sender As Object, e As EventArgs) Handles cbGradeLevel.Click
        loadCBO("SELECT * FROM gradelevel WHERE isActive = 1", "gradeID", "gradelevel", cbGradeLevel)
    End Sub
End Class