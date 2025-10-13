Imports System.IO

Public Class FormAnnouncement
    Public Sub DefaultSettings()
        dgvAnnouncement.Tag = 0
        dgvAnnouncement.CurrentCell = Nothing

        dgvAnnouncement.RowTemplate.Height = 50
        dgvAnnouncement.ColumnHeadersHeight = 50
        dgvAnnouncement.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvAnnouncement.DefaultCellStyle.Font = New Font("Segoe UI", 14)
        dgvAnnouncement.AlternatingRowsDefaultCellStyle = dgvAnnouncement.DefaultCellStyle
        dgvAnnouncement.AutoGenerateColumns = False

        loadDGV("SELECT id, pictureHeader, header, 
                dayInfo, timeInfo, description, lookFor 
                FROM announcements 
                WHERE isActive = 1", dgvAnnouncement)
    End Sub
    Private Sub FormAnnouncement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub dgvAnnouncement_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnnouncement.CellClick
        Try
            dgvAnnouncement.Tag = dgvAnnouncement.Item(0, e.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAnnouncement_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvAnnouncement.DataBindingComplete
        dgvAnnouncement.CurrentCell = Nothing
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddAnnouncement.ShowDialog()
    End Sub

    Private Sub btnDeleteRecord_Click(sender As Object, e As EventArgs) Handles btnDeleteRecord.Click
        Dim cmd As Odbc.OdbcCommand
        Try
            connectDB()
            If dgvAnnouncement.Tag > 0 Then
                If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    cmd = New Odbc.OdbcCommand("UPDATE announcements SET isActive=0 WHERE id=?", con)
                    cmd.Parameters.AddWithValue("@", dgvAnnouncement.Tag)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Record has been deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please select a record you want to delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
            DefaultSettings()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub
    Private Sub EditRecord(ByVal id As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Try
            connectDB()
            cmd = New Odbc.OdbcCommand("SELECT id, pictureHeader, header, dayInfo, timeInfo, description, lookFor FROM announcements WHERE id=?", con)
            cmd.Parameters.AddWithValue("@", id)
            da.SelectCommand = cmd
            da.Fill(dt)

            Dim myreader As Odbc.OdbcDataReader = cmd.ExecuteReader
            If myreader.Read Then
                AddAnnouncement.txtID.Text = dt.Rows(0)("id").ToString()
                AddAnnouncement.txtHeader.Text = dt.Rows(0)("header").ToString()
                AddAnnouncement.dtpDateInfo.Text = dt.Rows(0)("dayInfo").ToString()
                AddAnnouncement.txtTimeInfo.Text = dt.Rows(0)("timeInfo").ToString()
                AddAnnouncement.txtDescription.Text = dt.Rows(0)("description").ToString()
                AddAnnouncement.txtContactPerson.Text = dt.Rows(0)("lookFor").ToString()

                Try
                    Dim profileImg As Byte()
                    profileImg = myreader("pictureHeader")
                    Dim ms As New MemoryStream(profileImg)
                    AddAnnouncement.pbHeader.Image = Image.FromStream(ms)
                Catch ex As Exception

                End Try
            End If


            AddAnnouncement.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub
    Private Sub btnEditRecord_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        If dgvAnnouncement.Tag > 0 Then
            If MessageBox.Show("Are you sure you want to edit this record?", "Edit Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                EditRecord(Val(dgvAnnouncement.Tag))
            End If
        Else
            MessageBox.Show("Please select a record you want to edit", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class