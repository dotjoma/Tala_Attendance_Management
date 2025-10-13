Imports System.Data.Odbc
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer

Public Class FormClassroom
    Public Sub DefaultSettings()
        dgvClassrooms.Tag = 0
        dgvClassrooms.CurrentCell = Nothing
        dgvClassrooms.RowTemplate.Height = 50
        dgvClassrooms.CellBorderStyle = DataGridViewCellBorderStyle.None
        With dgvClassrooms.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 12)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        dgvClassrooms.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvClassrooms.AutoGenerateColumns = False

        loadDGV("SELECT id, classroom_id, location, classroom_name FROM classrooms WHERE isActive=1 ORDER BY location, classroom_name", dgvClassrooms)
    End Sub

    Private Sub FormClassroom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        FormProcessClassrooms.ShowDialog()
        dgvClassrooms.Tag = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        dgvClassrooms.Tag = 0
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            loadDGV("SELECT id, classroom_id, location, classroom_name FROM classrooms WHERE isActive=1", dgvClassrooms, "location", "classroom_name", "classroom_id", txtSearch.Text.Trim)
        Else
            loadDGV("SELECT id, classroom_id, location, classroom_name FROM classrooms WHERE isActive=1", dgvClassrooms)
        End If
    End Sub

    Private Sub dgvClassrooms_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClassrooms.CellClick
        Try
            dgvClassrooms.Tag = dgvClassrooms.Item(0, e.RowIndex).Value

            If e.RowIndex >= 0 Then
                If e.ColumnIndex = dgvClassrooms.Columns("editBtn").Index Then

                    Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to edit this classroom?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                    If dialogResult = DialogResult.Yes Then
                        FormProcessClassrooms.roomID = dgvClassrooms.Item("id", e.RowIndex).Value
                        FormProcessClassrooms.txtDeviceID.Text = dgvClassrooms.Item("classroom_id", e.RowIndex).Value.ToString()
                        FormProcessClassrooms.txtBuilding.Text = dgvClassrooms.Item("location", e.RowIndex).Value.ToString()
                        FormProcessClassrooms.txtRoom.Text = dgvClassrooms.Item("classroom_name", e.RowIndex).Value.ToString()
                        FormProcessClassrooms.ShowDialog()
                    End If

                ElseIf e.ColumnIndex = dgvClassrooms.Columns("deleteBtn").Index Then
                    Dim classId As Integer = Convert.ToInt32(dgvClassrooms.Item("id", e.RowIndex).Value)
                    Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete this classroom?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If dialogResult = DialogResult.Yes Then
                        Try
                            connectDB()
                            Dim deleteCmd As New Odbc.OdbcCommand("UPDATE classrooms SET isActive=0 WHERE id = ?", con)
                            deleteCmd.Parameters.AddWithValue("?", classId)
                            deleteCmd.ExecuteNonQuery()
                            MessageBox.Show("Classroom deleted successfully.", "Success")
                            DefaultSettings()
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        Finally
                            con.Close()
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvClassrooms_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvClassrooms.DataBindingComplete
        dgvClassrooms.CurrentCell = Nothing
    End Sub
End Class