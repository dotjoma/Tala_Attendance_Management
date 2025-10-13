Imports System.Data.Odbc

Public Class FormMyStudents

    Public Sub DefaultSettings()
        dgvMyStudents.Tag = 0
        dgvMyStudents.RowTemplate.Height = 50
        dgvMyStudents.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvMyStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMyStudents.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvMyStudents.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 12)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        ' Disable alternating row styles to ensure consistent font style
        dgvMyStudents.AlternatingRowsDefaultCellStyle = dgvMyStudents.DefaultCellStyle

        ' Set row font to Segoe UI for all rows
        dgvMyStudents.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvMyStudents.DefaultCellStyle.ForeColor = Color.Black

        dgvMyStudents.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvMyStudents.AutoGenerateColumns = False

        ' Load sections for the teacher's scheduled classes into the ComboBox
        Dim query As String = "SELECT DISTINCT sec.section_id, CONCAT(sec.year_level, ' ', sec.section_name) AS section " &
                              "FROM class_schedules cs " &
                              "JOIN sections sec ON cs.section_id = sec.section_id " &
                              "WHERE cs.isActive = 1 AND cs.teacherID = " & TeacherSchedule.currentUser & " 
                               ORDER BY sec.year_level, sec.section_name"

        ' Call the loadCBO method to populate the ComboBox
        loadCBO(query, "section_id", "section", cbFilter)
    End Sub

    Private Sub FormMyStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub dgvMyStudents_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvMyStudents.DataBindingComplete
        dgvMyStudents.CurrentCell = Nothing
    End Sub

    Private Sub cbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFilter.SelectedIndexChanged
        Try
            If cbFilter.SelectedIndex <> -1 Then
                ' Cast the selected item to DataRowView to access the section_id
                Dim selectedRow As DataRowView = DirectCast(cbFilter.SelectedItem, DataRowView)
                Dim section_id As Integer = Convert.ToInt32(selectedRow("section_id"))

                loadDGV("SELECT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, sr.gender, " &
                    "CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, pr.contactNo AS phone_number, " &
                    "pr.address FROM studentrecords sr " &
                    "JOIN sections s ON s.section_id = sr.section_id " &
                    "JOIN parentrecords pr ON pr.parentID = sr.parentID " &
                    "WHERE sr.isActive = 1 AND sr.section_id = " & section_id & " ORDER BY student_name", dgvMyStudents)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub dgvMyStudents_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMyStudents.CellDoubleClick
        Try
            FormStudentAttendance.student_id = dgvMyStudents.Tag
            FormStudentAttendance.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub dgvMyStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMyStudents.CellClick
        Try
            dgvMyStudents.Tag = dgvMyStudents.Item(0, e.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            If cbFilter.SelectedIndex <> -1 Then
                ' Cast the selected item to DataRowView to access the section_id
                Dim selectedRow As DataRowView = DirectCast(cbFilter.SelectedItem, DataRowView)
                Dim section_id As Integer = Convert.ToInt32(selectedRow("section_id"))

                If txtSearch.TextLength Then
                    loadDGV("SELECT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, sr.gender, " &
                    "CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, pr.contactNo AS phone_number, " &
                    "pr.address FROM studentrecords sr " &
                    "JOIN sections s ON s.section_id = sr.section_id " &
                    "JOIN parentrecords pr ON pr.parentID = sr.parentID " &
                    "WHERE sr.isActive = 1 AND sr.section_id = " & section_id & " ", dgvMyStudents, "CONCAT(sr.firstname, ' ', sr.lastname)", "pr.address", "pr.contactNo", txtSearch.Text.Trim)
                Else
                    loadDGV("SELECT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, sr.gender, " &
                    "CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, pr.contactNo AS phone_number, " &
                    "pr.address FROM studentrecords sr " &
                    "JOIN sections s ON s.section_id = sr.section_id " &
                    "JOIN parentrecords pr ON pr.parentID = sr.parentID " &
                    "WHERE sr.isActive = 1 AND sr.section_id = " & section_id & " ORDER BY student_name", dgvMyStudents)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class
