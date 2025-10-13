Imports Microsoft.Reporting.Map.WebForms.BingMaps
Imports System.Data.Odbc
Imports System.IO

Public Class AddAnnouncement
    Public browse As OpenFileDialog = New OpenFileDialog
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            browse.FileName = ""
            browse.Filter = "Image Files(*.jpg)|*.jpg;*.png;*.jpeg;"
            If browse.ShowDialog = Windows.Forms.DialogResult.OK Then
                pbHeader.Image = Image.FromFile(browse.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cmd As System.Data.Odbc.OdbcCommand
        Dim da As New System.Data.Odbc.OdbcDataAdapter

        Dim ms As New MemoryStream

        If fieldChecker(panelContainer) = True Then
            Try
                pbHeader.Image.Save(ms, pbHeader.Image.RawFormat)

                Call connectDB()

                If Val(txtID.Text) > 0 Then
                    cmd = New System.Data.Odbc.OdbcCommand("UPDATE announcements SET pictureHeader=?, header=?, dayInfo=?, timeInfo=?, description=?, lookFor=? WHERE id=?", con)
                    With cmd.Parameters
                        .AddWithValue("@", ms.ToArray())
                        .AddWithValue("@", Trim(txtHeader.Text))
                        .AddWithValue("@", Trim(dtpDateInfo.Text))
                        .AddWithValue("@", Trim(txtTimeInfo.Text))
                        .AddWithValue("@", Trim(txtDescription.Text))
                        .AddWithValue("@", Trim(txtContactPerson.Text))
                        .AddWithValue("@", txtID.Text)
                    End With
                    MsgBox("Record has been updated.", vbInformation, "Updated")
                    'cmd.ExecuteNonQuery()
                    'Me.Close()
                Else
                    cmd = New System.Data.Odbc.OdbcCommand("INSERT INTO announcements(pictureHeader, header, dayInfo, timeInfo, description, lookFor) VALUES(?,?,?,?,?,?)", con)
                    With cmd.Parameters
                        .AddWithValue("@", ms.ToArray())
                        .AddWithValue("@", Trim(txtHeader.Text))
                        .AddWithValue("@", Trim(dtpDateInfo.Text))
                        .AddWithValue("@", Trim(txtTimeInfo.Text))
                        .AddWithValue("@", Trim(txtDescription.Text))
                        .AddWithValue("@", Trim(txtContactPerson.Text))
                    End With
                    MsgBox("New record added successfully", vbInformation, "Success")
                    ' cmd.ExecuteNonQuery()
                    'Me.Close()
                End If
                cmd.ExecuteNonQuery()
                Me.Close()
                txtID.Text = "0"
                FormAnnouncement.DefaultSettings()
                ClearFields(panelContainer)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            Finally
                con.Close()
                GC.Collect()
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtID.Text = "0"
        Me.Close()
    End Sub

    Private Sub AddAnnouncement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddAnnouncement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim announcement As FormAnnouncement = TryCast(Application.OpenForms("FormAnnouncement"), FormAnnouncement)
        If announcement IsNot Nothing Then
            announcement.DefaultSettings()
            'MainForm.tsStudents.PerformClick()
        End If
        ClearFields(panelContainer)
    End Sub

End Class