Imports System.Collections.Specialized.BitVector32

Public Class StudentSchedule
    Public Sub DefaultSettings()
        dgvStudentSchedule.Tag = 0
        dgvStudentSchedule.RowTemplate.Height = 50
        dgvStudentSchedule.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvStudentSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStudentSchedule.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvStudentSchedule.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 12)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        ' Disable alternating row styles to ensure consistent font style
        dgvStudentSchedule.AlternatingRowsDefaultCellStyle = dgvStudentSchedule.DefaultCellStyle

        ' Set row font to Segoe UI for all rows
        dgvStudentSchedule.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvStudentSchedule.DefaultCellStyle.ForeColor = Color.Black

        dgvStudentSchedule.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvStudentSchedule.AutoGenerateColumns = False

        ' Load initial data
        LoadData()

        ' Load sections into the ComboBoxes
        loadCBO("SELECT * FROM sections WHERE isActive = 1 GROUP BY CAST(year_level AS SIGNED) ORDER BY CAST(year_level AS SIGNED);", "section_id", "year_level", cbYearLevel)

        Dim selectedYearLevel As Integer = Convert.ToInt32(DirectCast(cbYearLevel.SelectedItem, DataRowView)("year_level"))
        loadCBO($"SELECT * FROM sections WHERE isActive = 1 AND year_level = {selectedYearLevel} ORDER BY CAST(year_level AS SIGNED)", "section_id", "section_name", cbSection)

        dgvStudentSchedule.ReadOnly = True
        dgvStudentSchedule.AllowUserToAddRows = False
        dgvStudentSchedule.AllowUserToDeleteRows = False
    End Sub

    Private Sub StudentSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub LoadData()
        Dim query As String = "SELECT MIN(cs.schedule_id) AS schedule_id, " &
                              "s.subject_name, " &
                              "CONCAT(sec.year_level, ' ', sec.section_name) AS section, " &
                              "CONCAT(firstname, ' ', lastname) AS teacher_name, " &
                              "c.classroom_name, " &
                              "GROUP_CONCAT(DISTINCT cs.day ORDER BY FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')) AS day, " &
                              "DATE_FORMAT(cs.start_time, '%h:%i %p') AS start_time, " &
                              "DATE_FORMAT(cs.end_time, '%h:%i %p') AS end_time, cs.teacherID " &
                              "FROM class_schedules cs " &
                              "JOIN subjects s ON cs.subject_id = s.subject_id " &
                              "JOIN classrooms c ON cs.classroom_id = c.classroom_id " &
                              "JOIN sections sec ON cs.section_id = sec.section_id " &
                              "JOIN teacherinformation t ON cs.teacherID = t.teacherID " &
                              "WHERE cs.isActive=1 " &
                              "GROUP BY cs.teacherID, cs.subject_id, cs.classroom_id, cs.section_id, start_time, end_time " &
                              "ORDER BY MIN(FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')), cs.start_time"

        loadDGV(query, dgvStudentSchedule)
    End Sub

    Private Sub dgvTeacherSchedule_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvStudentSchedule.DataBindingComplete
        dgvStudentSchedule.CurrentCell = Nothing
    End Sub

    Private Sub dgvStudentSchedule_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvStudentSchedule.CellMouseDown
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            dgvStudentSchedule.ClearSelection()
        End If
    End Sub

    Private Sub dgvStudentSchedule_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvStudentSchedule.KeyDown
        e.Handled = True ' Prevent any key actions
    End Sub

    Private Sub cbYearLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYearLevel.SelectedIndexChanged
        If cbYearLevel.SelectedIndex <> -1 AndAlso cbSection.SelectedIndex <> -1 Then
            Dim selectedYearLevel As Integer = Convert.ToInt32(DirectCast(cbYearLevel.SelectedItem, DataRowView)("year_level"))
            Dim selectedSection As Integer = Convert.ToInt32(DirectCast(cbSection.SelectedItem, DataRowView)("section_id"))

            Dim query As String = $"SELECT MIN(cs.schedule_id) AS schedule_id, s.subject_name, " &
                                  $"CONCAT(sec.year_level, ' ', sec.section_name) AS section, " &
                                  $"CONCAT(firstname, ' ', lastname) AS teacher_name, c.classroom_name, " &
                                  $"GROUP_CONCAT(DISTINCT cs.day ORDER BY FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')) AS day, " &
                                  $"DATE_FORMAT(cs.start_time, '%h:%i %p') AS start_time, " &
                                  $"DATE_FORMAT(cs.end_time, '%h:%i %p') AS end_time, cs.teacherID " &
                                  $"FROM class_schedules cs " &
                                  $"JOIN subjects s ON cs.subject_id = s.subject_id " &
                                  $"JOIN classrooms c ON cs.classroom_id = c.classroom_id " &
                                  $"JOIN sections sec ON cs.section_id = sec.section_id " &
                                  $"JOIN teacherinformation t ON cs.teacherID = t.teacherID " &
                                  $"WHERE cs.isActive=1 AND sec.year_level = {selectedYearLevel} AND sec.section_id = {selectedSection} " &
                                  $"GROUP BY cs.teacherID, cs.subject_id, cs.classroom_id, cs.section_id, start_time, end_time " &
                                  $"ORDER BY MIN(FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')), cs.start_time"

            loadDGV(query, dgvStudentSchedule)

            loadCBO($"SELECT * FROM sections WHERE isActive = 1 AND year_level = {selectedYearLevel} ORDER BY CAST(year_level AS SIGNED)", "section_id", "section_name", cbSection)
        End If
    End Sub

    Private Sub cbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSection.SelectedIndexChanged
        If cbSection.SelectedIndex <> -1 AndAlso cbSection.SelectedIndex <> -1 Then
            Dim selectedYearLevel As Integer = Convert.ToInt32(DirectCast(cbYearLevel.SelectedItem, DataRowView)("year_level"))
            Dim selectedSection As Integer = Convert.ToInt32(DirectCast(cbSection.SelectedItem, DataRowView)("section_id"))

            Dim query As String = $"SELECT MIN(cs.schedule_id) AS schedule_id, s.subject_name, " &
                                  $"CONCAT(sec.year_level, ' ', sec.section_name) AS section, " &
                                  $"CONCAT(firstname, ' ', lastname) AS teacher_name, c.classroom_name, " &
                                  $"GROUP_CONCAT(DISTINCT cs.day ORDER BY FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')) AS day, " &
                                  $"DATE_FORMAT(cs.start_time, '%h:%i %p') AS start_time, " &
                                  $"DATE_FORMAT(cs.end_time, '%h:%i %p') AS end_time, cs.teacherID " &
                                  $"FROM class_schedules cs " &
                                  $"JOIN subjects s ON cs.subject_id = s.subject_id " &
                                  $"JOIN classrooms c ON cs.classroom_id = c.classroom_id " &
                                  $"JOIN sections sec ON cs.section_id = sec.section_id " &
                                  $"JOIN teacherinformation t ON cs.teacherID = t.teacherID " &
                                  $"WHERE cs.isActive=1 AND sec.year_level = {selectedYearLevel} AND sec.section_id = {selectedSection} " &
                                  $"GROUP BY cs.teacherID, cs.subject_id, cs.classroom_id, cs.section_id, start_time, end_time " &
                                  $"ORDER BY MIN(FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')), cs.start_time"

            loadDGV(query, dgvStudentSchedule)
        End If
    End Sub
End Class
