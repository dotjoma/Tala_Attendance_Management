Imports System.Globalization

Public Class FormClassSchedule
    Public Sub DefaultSettings()
        dgvTeacherSchedule.Tag = 0
        dgvTeacherSchedule.RowTemplate.Height = 50
        dgvTeacherSchedule.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvTeacherSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTeacherSchedule.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvTeacherSchedule.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 12)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        ' Disable alternating row styles to ensure consistent font style
        dgvTeacherSchedule.AlternatingRowsDefaultCellStyle = dgvTeacherSchedule.DefaultCellStyle

        ' Set row font to Segoe UI for all rows
        dgvTeacherSchedule.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvTeacherSchedule.DefaultCellStyle.ForeColor = Color.Black

        dgvTeacherSchedule.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvTeacherSchedule.AutoGenerateColumns = False

        ' Load schedules for the teacher with time formatted in 12-hour notation
        loadDGV("SELECT cs.schedule_id, s.subject_name, CONCAT(sec.year_level, ' ', sec.section_name) AS section, " &
                "c.classroom_name, cs.day, DATE_FORMAT(cs.start_time, '%h:%i %p') AS start_time, " &
                "DATE_FORMAT(cs.end_time, '%h:%i %p') AS end_time " &
                "FROM class_schedules cs " &
                "JOIN subjects s ON cs.subject_id = s.subject_id " &
                "JOIN classrooms c ON cs.classroom_id = c.classroom_id " &
                "JOIN sections sec ON cs.section_id = sec.section_id " &
                "WHERE cs.isActive =1 AND cs.teacherID = " & TeacherSchedule.currentUser & " " &
                "ORDER BY cs.day, cs.start_time", dgvTeacherSchedule)
    End Sub

    Private Sub FormClassSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub dgvTeacherSchedule_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTeacherSchedule.DataBindingComplete
        Dim currentDay As String = DateTime.Now.ToString("dddd", CultureInfo.InvariantCulture).ToLower()
        Dim currentTime As TimeSpan = DateTime.Now.TimeOfDay

        For Each row As DataGridViewRow In dgvTeacherSchedule.Rows
            Try
                ' Get the schedule days and times
                Dim scheduleDays As String = row.Cells("day").Value.ToString().ToLower()
                Dim daysArray As String() = scheduleDays.Split(","c).Select(Function(d) d.Trim()).ToArray()

                Dim startTime As DateTime = DateTime.ParseExact(row.Cells("start_time").Value.ToString(), "h:mm tt", CultureInfo.InvariantCulture)
                Dim endTime As DateTime = DateTime.ParseExact(row.Cells("end_time").Value.ToString(), "h:mm tt", CultureInfo.InvariantCulture)
                Dim startSpan As TimeSpan = startTime.TimeOfDay
                Dim endSpan As TimeSpan = endTime.TimeOfDay

                ' Highlight the row if it matches the current day and time
                If daysArray.Any(Function(day) day.Equals(currentDay, StringComparison.InvariantCultureIgnoreCase)) AndAlso
                   startSpan <= currentTime AndAlso
                   endSpan >= currentTime Then
                    Debug.Print("Row Highlighted")
                    row.DefaultCellStyle.BackColor = Color.DeepSkyBlue
                    row.DefaultCellStyle.ForeColor = Color.White
                Else
                    Debug.Print("Row Not Highlighted")
                    row.DefaultCellStyle.BackColor = dgvTeacherSchedule.DefaultCellStyle.BackColor
                    row.DefaultCellStyle.ForeColor = dgvTeacherSchedule.DefaultCellStyle.ForeColor
                End If
            Catch ex As Exception
                Debug.Print("Error: " & ex.Message)
                row.DefaultCellStyle.BackColor = Color.LightCoral
            End Try
        Next
        dgvTeacherSchedule.ClearSelection()
        dgvTeacherSchedule.Refresh()
    End Sub

End Class
