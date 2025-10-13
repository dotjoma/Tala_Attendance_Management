Imports System.Data.Odbc

Public Class FormStudentAttendance
    Public student_id As Integer

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

        ' Set default date values
        dtpFrom.Value = Date.Today
        dtpTo.Value = Date.Today

        LoadAttendanceRecords()
    End Sub

    Private Sub LoadAttendanceRecords(Optional ByVal fromDate As Date? = Nothing, Optional ByVal toDate As Date? = Nothing)
        Dim dateFilter As String = ""

        If fromDate.HasValue AndAlso toDate.HasValue Then
            dateFilter = "AND logDate BETWEEN '" & fromDate.Value.ToString("yyyy-MM-dd") & "' AND '" & toDate.Value.ToString("yyyy-MM-dd") & "'"
        End If

        loadDGV("SELECT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, " &
                "DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, " &
                "DAYNAME(logDate) AS day_of_week, " &
                "sub.subject_name AS subject, " &
                "MIN(DATE_FORMAT(arrivalTime, '%h:%i:%s %p')) AS arrivalTime, " &
                "MAX(DATE_FORMAT(departureTime, '%h:%i:%s %p')) AS departureTime, " &
                "CASE " &
                "    WHEN MIN(DATE_FORMAT(arrivalTime, '%H:%i:%s')) < cs.start_time THEN 'Early' " &
                "    WHEN MIN(DATE_FORMAT(arrivalTime, '%H:%i:%s')) = cs.start_time THEN 'On Time' " &
                "    ELSE 'Late' " &
                "END AS remarks " &
                "FROM attendance_record ar " &
                "JOIN studentrecords sr ON ar.tag_id = sr.tagID " &
                "JOIN class_schedules cs ON sr.section_id = cs.section_id " &
                "JOIN subjects sub ON cs.subject_id = sub.subject_id " &
                "WHERE sr.studID = " & student_id & " " &
                "AND cs.teacherID = " & TeacherSchedule.currentUser & " " &
                dateFilter & " " &
                "GROUP BY logDate, sr.studID " &
                "ORDER BY logDate", dgvAttendanceRecords)
    End Sub

    Private Sub FormStudentAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub dgvAttendanceRecords_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvAttendanceRecords.DataBindingComplete
        dgvAttendanceRecords.CurrentCell = Nothing
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim fromDate As Date = dtpFrom.Value
        Dim toDate As Date = dtpTo.Value
        LoadAttendanceRecords(fromDate, toDate)
    End Sub
End Class
