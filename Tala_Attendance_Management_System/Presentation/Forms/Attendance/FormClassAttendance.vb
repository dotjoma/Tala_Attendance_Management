Imports System.Data.Odbc

Public Class FormClassAttendance

    Public Sub DefaultSettings()
        dgvAttendanceRecords.Tag = 0
        dgvAttendanceRecords.RowTemplate.Height = 50
        dgvAttendanceRecords.CellBorderStyle = DataGridViewCellBorderStyle.Single
        dgvAttendanceRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAttendanceRecords.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvAttendanceRecords.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 12)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        dgvAttendanceRecords.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvAttendanceRecords.DefaultCellStyle.ForeColor = Color.Black
        dgvAttendanceRecords.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvAttendanceRecords.AutoGenerateColumns = False

        ' Load sections and subjects for the teacher
        Dim sectionQuery As String = "SELECT DISTINCT sec.section_id, CONCAT(sec.year_level, ' ', sec.section_name) AS section " &
                                      "FROM class_schedules cs JOIN sections sec ON cs.section_id = sec.section_id " &
                                      "WHERE cs.isActive = 1 AND cs.teacherID = " & TeacherSchedule.currentUser
        loadCBO(sectionQuery, "section_id", "section", cbSections)

        Dim selectedSectionId As Integer = If(cbSections.SelectedItem IsNot Nothing, CType(cbSections.SelectedItem, DataRowView)("section_id"), -1)
        Dim subjectQuery As String = "SELECT DISTINCT sub.subject_id, sub.subject_name " &
                                      "FROM class_schedules cs JOIN subjects sub ON cs.subject_id = sub.subject_id " &
                                      "WHERE cs.isActive = 1 AND cs.section_id = " & selectedSectionId & " AND cs.teacherID = " & TeacherSchedule.currentUser
        loadCBO(subjectQuery, "subject_id", "subject_name", cbSubjects)

        ApplyFilters()
    End Sub
    Private Sub LoadAttendanceRecords(Optional ByVal sectionId As Integer = -1, Optional ByVal subjectId As Integer = -1, Optional ByVal searchTerm As String = "")
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Try
            connectDB()

            Dim sectionFilter As String = If(sectionId <> -1, "AND sr.section_id = ?", "")
            Dim subjectFilter As String = If(subjectId <> -1, "AND sub.subject_id = ?", "")
            Dim dateFilter As String = "AND logDate = ?"
            Dim searchFilter As String = If(Not String.IsNullOrEmpty(searchTerm), "AND (CONCAT(sr.firstname, ' ', sr.lastname) LIKE ? OR sub.subject_name LIKE ? OR DAYNAME(logDate) LIKE ?)", "")

            Dim query As String = "SELECT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, " &
                              "DATE_FORMAT(ar.logDate, '%M %d, %Y') AS logDate, DAYNAME(ar.logDate) AS day_of_week, " &
                              "sub.subject_name AS subject, cr.classroom_name, " &
                              "DATE_FORMAT(MIN(ar.arrivalTime), '%h:%i:%s %p') AS arrivalTime, " &
                              "DATE_FORMAT(MAX(ar.departureTime), '%h:%i:%s %p') AS departureTime, " &
                              "CASE " &
                              "   WHEN MIN(TIME(ar.arrivalTime)) < TIME(cs.start_time) THEN 'Early' " &
                              "   WHEN MIN(TIME(ar.arrivalTime)) = TIME(cs.start_time) THEN 'On Time' " &
                              "   WHEN TIMESTAMPDIFF(MINUTE, TIME(cs.start_time), MIN(TIME(ar.arrivalTime))) <= 15 THEN 'Late (with grace)' " &
                              "   ELSE 'Late' " &
                              "END AS remarks " &
                              "FROM attendance_record ar " &
                              "JOIN studentrecords sr ON ar.tag_id = sr.tagID " &
                              "JOIN class_schedules cs ON sr.section_id = cs.section_id " &
                              "JOIN subjects sub ON cs.subject_id = sub.subject_id " &
                              "JOIN classrooms cr ON cs.classroom_id = cr.classroom_id " &
                              "WHERE cs.teacherID = ? " & sectionFilter & " " & subjectFilter & " " & dateFilter & " " & searchFilter & " " &
                              "GROUP BY ar.logDate, sr.studID, sub.subject_name, cr.classroom_name " &
                              "ORDER BY ar.logDate"

            cmd = New OdbcCommand(query, con)

            cmd.Parameters.AddWithValue("?", TeacherSchedule.currentUser)
            If sectionId <> -1 Then cmd.Parameters.AddWithValue("?", sectionId)
            If subjectId <> -1 Then cmd.Parameters.AddWithValue("?", subjectId)
            cmd.Parameters.AddWithValue("?", Date.Now.ToString("yyyy-MM-dd"))
            If Not String.IsNullOrEmpty(searchTerm) Then
                cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
            End If

            da.SelectCommand = cmd
            da.Fill(dt)

            dgvAttendanceRecords.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub



    Private Sub ApplyFilters()
        Dim selectedSectionId As Integer = If(cbSections.SelectedItem IsNot Nothing, CType(cbSections.SelectedItem, DataRowView)("section_id"), -1)
        Dim selectedSubjectId As Integer = If(cbSubjects.SelectedItem IsNot Nothing, CType(cbSubjects.SelectedItem, DataRowView)("subject_id"), -1)
        Dim searchTerm As String = txtSearch.Text.Trim()

        LoadAttendanceRecords(selectedSectionId, selectedSubjectId, searchTerm)
    End Sub

    Private Sub cbSections_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSections.SelectedIndexChanged
        If Not chkShowAll.Checked Then
            ApplyFilters()
            Dim selectedSectionId As Integer = If(cbSections.SelectedItem IsNot Nothing, CType(cbSections.SelectedItem, DataRowView)("section_id"), -1)
            Dim subjectQuery As String = "SELECT DISTINCT sub.subject_id, sub.subject_name " &
                                          "FROM class_schedules cs JOIN subjects sub ON cs.subject_id = sub.subject_id " &
                                          "WHERE cs.isActive = 1 AND cs.section_id = " & selectedSectionId & " AND cs.teacherID = " & TeacherSchedule.currentUser
            loadCBO(subjectQuery, "subject_id", "subject_name", cbSubjects)
        Else
            cbSubjects.SelectedIndex = -1
            cbSections.SelectedIndex = -1
        End If
    End Sub

    Private Sub cbSubjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubjects.SelectedIndexChanged
        If Not chkShowAll.Checked Then
            ApplyFilters()
        End If
    End Sub

    Private Sub chkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAll.CheckedChanged
        If chkShowAll.Checked Then
            ' Load all attendance records
            LoadAttendanceRecords()
            ' Clear selections in the ComboBoxes
            cbSections.SelectedIndex = -1
            cbSubjects.SelectedIndex = -1
        Else
            ApplyFilters()
        End If
    End Sub

    Private Sub FormClassAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub
End Class
