Imports System.Data.Odbc

Public Class AddSubjects
    Public id As Integer

    Private Sub AddSectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCBO("SELECT * FROM gradelevel WHERE isActive=1", "gradeID", "gradelevel", cbYearLevel)
        txtSubject.Focus()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtSubject.Text) Then
            MessageBox.Show("Please enter a subject name.")
            txtSubject.Focus()
            Return
        End If

        Try
            connectDB()

            Dim subjectName As String = txtSubject.Text.Trim()
            Dim cmdCheck As Odbc.OdbcCommand
            Dim cmd As Odbc.OdbcCommand

            ' Check if the subject name already exists
            Dim isDuplicate As Boolean = False
            cmdCheck = New OdbcCommand("SELECT COUNT(*) FROM subjects WHERE subject_name = ? AND isActive=1" & If(id > 0, " AND subject_id <> ?", ""), con)
            cmdCheck.Parameters.Add("@subject_name", OdbcType.VarChar).Value = subjectName
                If id > 0 Then
                    cmdCheck.Parameters.Add("@subject_id", OdbcType.Int).Value = id
                End If

                isDuplicate = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0

            If isDuplicate Then
                MessageBox.Show("The subject name already exists. Please enter a unique subject name.", "Duplicate Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSubject.Focus()
                Return
            End If

            ' Save or update the subject
            If id = 0 Then
                cmd = New Odbc.OdbcCommand("INSERT INTO subjects (subject_name) VALUES (?)", con)
                cmd.Parameters.AddWithValue("?", subjectName)
                cmd.ExecuteNonQuery()
            Else
                cmd = New Odbc.OdbcCommand("UPDATE subjects SET subject_name = ? WHERE subject_id = ?", con)
                cmd.Parameters.AddWithValue("?", subjectName)
                cmd.Parameters.AddWithValue("?", id)
                cmd.ExecuteNonQuery()
            End If
            MessageBox.Show("Subject saved successfully.")

            txtSubject.Clear()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving subject: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtSubject.Clear()
        Me.Close()
    End Sub

    Private Sub AddSubjects_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim parentForm As FormSubjects = TryCast(Application.OpenForms("FormSubjects"), FormSubjects)
        If parentForm IsNot Nothing Then
            parentForm.DefaultSettings()
        End If
    End Sub
End Class