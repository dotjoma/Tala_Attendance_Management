Imports System.Data.Odbc

Public Class FormSubjects

    Private Sub FormSubjects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    ' Default DataGridView settings
    Public Sub DefaultSettings()
        dgvSubjects.Tag = 0
        dgvSubjects.CurrentCell = Nothing
        dgvSubjects.RowTemplate.Height = 50
        dgvSubjects.CellBorderStyle = DataGridViewCellBorderStyle.None
        With dgvSubjects.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 12)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        dgvSubjects.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvSubjects.AutoGenerateColumns = False

        loadDGV("SELECT subject_id, subject_name FROM subjects WHERE isActive=1", dgvSubjects)
    End Sub

    ' Edit button click event
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvSubjects.SelectedRows.Count > 0 Then
            AddSubjects.id = Val(dgvSubjects.Tag)
            AddSubjects.txtSubject.Text = dgvSubjects.SelectedRows(0).Cells("subject_name").Value.ToString()
            AddSubjects.txtSubject.Focus()
            AddSubjects.ShowDialog()

        Else
            MessageBox.Show("Please select a subject to edit.")
        End If
    End Sub

    ' Delete button click event
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSubjects.SelectedRows.Count > 0 Then
            Dim subjectID = dgvSubjects.SelectedRows(0).Cells("subject_id").Value
            Dim result = MessageBox.Show("Are you sure you want to delete this subject?", "Confirm Delete", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    Dim cmd = New OdbcCommand("UPDATE subjects SET isActive = 0 WHERE subject_id = ?", con)
                    cmd.Parameters.AddWithValue("@", subjectID)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Subject deleted successfully.")

                    ' Refresh data and reset form
                    loadDGV("SELECT subject_id, subject_name FROM subjects WHERE isActive=1", dgvSubjects)
                Catch ex As Exception
                    MessageBox.Show("Error deleting subject: " & ex.Message)
                Finally
                    con.Close()
                End Try
            End If
        Else
            MessageBox.Show("Please select a subject to delete.")
        End If
    End Sub

    ' DataBindingComplete event to reset selection
    Private Sub dgvSubjects_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvSubjects.DataBindingComplete
        dgvSubjects.CurrentCell = Nothing
    End Sub

    ' CellClick event to set the Tag for selected record
    Private Sub dgvSubjects_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubjects.CellClick
        If e.RowIndex >= 0 AndAlso dgvSubjects.Rows(e.RowIndex).Cells("subject_id").Value IsNot Nothing Then
            dgvSubjects.Tag = dgvSubjects.Rows(e.RowIndex).Cells("subject_id").Value
            'txtSubject.Text = dgvSubjects.Rows(e.RowIndex).Cells("subject_name").Value.ToString()
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddSubjects.id = 0
        AddSubjects.ShowDialog()
    End Sub
End Class
