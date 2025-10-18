Imports Microsoft.Reporting.WinForms

Public Class FormTeacherAttendanceReports
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance

    Private Sub rvAttendance_Load(sender As Object, e As EventArgs) Handles rvAttendance.Load
        Try
            ' Load sections for the current teacher
            Dim currentUserID As String = TeacherSchedule.currentUser
            _logger.LogDebug($"Loading sections for teacher ID: {currentUserID}")
            
            Dim sectionQuery As String = "
                SELECT DISTINCT sc.section_id, CONCAT(sc.year_level, ' ', sc.section_name) AS section_name
                FROM sections sc
                JOIN class_schedules cs ON sc.section_id = cs.section_id
                WHERE cs.teacherID = '" & currentUserID & "' AND sc.isActive = 1 AND cs.isActive=1 
                ORDER BY CAST(sc.year_level AS SIGNED), sc.section_name"
            loadCBO(sectionQuery, "section_id", "section_name", cbSection)
            
            _logger.LogInfo($"Loaded {cbSection.Items.Count} sections for teacher ID: {currentUserID}")
        Catch ex As Exception
            _logger.LogError($"Error loading sections: {ex.Message}")
            MessageBox.Show("Error loading sections: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Validate that all inputs are provided
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(dtpFrom.Text) OrElse String.IsNullOrEmpty(dtpTo.Text) Then
            _logger.LogWarning("Validation failed: Date range not selected")
            MessageBox.Show("Please select a valid date range.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cbSection.SelectedIndex = -1 Then
            _logger.LogWarning("Validation failed: Section not selected")
            MessageBox.Show("Please select a section.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        ' Validate input
        If Not ValidateInputs() Then Exit Sub

        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Try
            _logger.LogInfo("Generating teacher attendance report")
            connectDB()

            ' Get selected values from ComboBoxes
            Dim selectedSectionID As String = cbSection.SelectedValue.ToString()
            Dim selectedTeacherID As String = TeacherSchedule.currentUser
            
            _logger.LogDebug($"Report parameters - Teacher ID: {selectedTeacherID}, Section ID: {selectedSectionID}, Date From: {dtpFrom.Text}, Date To: {dtpTo.Text}")

            ' Modify SQL query to include filtering by teacherID and section_id
            cmd = New Odbc.OdbcCommand("
                SELECT CONCAT(sr.firstname, ' ', sr.lastname) AS firstname,
                       cr.classroom_name AS attendanceID,
                       CONCAT(ti.firstname, ' ', ti.lastname) AS lastname, 
                       DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                       DATE_FORMAT(MAX(departureTime), '%h:%i:%s %p') AS departureTime, 
                       DATE_FORMAT(MIN(arrivalTime), '%h:%i:%s %p') AS arrivalTime, 
                       CONCAT(sc.year_level, ' ', sc.section_name) AS arrStatus,
                       CASE WHEN MIN(TIME(ar.arrivalTime)) < TIME(cs.start_time) THEN 'Early' 
                            WHEN MIN(TIME(ar.arrivalTime)) = TIME(cs.start_time) THEN 'On Time' 
                            WHEN TIMESTAMPDIFF(MINUTE, TIME(cs.start_time), MIN(TIME(ar.arrivalTime))) <= 15 THEN 'Late (with grace)' 
                            ELSE 'Late' 
                       END AS depStatus  
                FROM attendance_record ar 
                JOIN studentrecords sr ON ar.tag_id = sr.tagID 
                JOIN classrooms cr ON ar.classroom_id = cr.classroom_id 
                JOIN subjects s ON ar.subject_id = s.subject_id 
                JOIN sections sc ON sr.section_id=sc.section_id 
                JOIN class_schedules cs ON sr.section_id = cs.section_id 
                JOIN teacherinformation ti ON ar.teacherID = ti.teacherID 
                WHERE ar.logDate BETWEEN ? AND ? 
                  AND sc.section_id = ? 
                  AND ti.teacherID = ? AND cs.isActive = 1 
                GROUP BY ar.logDate, sr.studID, cr.classroom_name", con)

            ' Add parameters to the SQL command
            cmd.Parameters.AddWithValue("?", dtpFrom.Text)
            cmd.Parameters.AddWithValue("?", dtpTo.Text)
            cmd.Parameters.AddWithValue("?", selectedSectionID)
            cmd.Parameters.AddWithValue("?", selectedTeacherID)

            ' Execute query and fill DataTable
            da.SelectCommand = cmd
            da.Fill(dt)
            
            _logger.LogInfo($"Report generated successfully with {dt.Rows.Count} attendance records")

            ' Set up the report viewer with the data
            Dim reportPath As String = System.IO.Path.Combine(Application.StartupPath, "ReportAttendance.rdlc")
            _logger.LogDebug($"Report path: {reportPath}")
            
            If Not System.IO.File.Exists(reportPath) Then
                _logger.LogError($"Report file not found at: {reportPath}")
                MessageBox.Show($"Report file not found at: {reportPath}", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            
            With Me.rvAttendance.LocalReport
                .DataSources.Clear()
                .ReportPath = reportPath
                .DataSources.Add(New ReportDataSource("DataSet1", dt))
            End With
            Me.rvAttendance.Dock = DockStyle.Fill
            Me.rvAttendance.RefreshReport()
            
            _logger.LogDebug("Report viewer refreshed successfully")
        Catch ex As Exception
            _logger.LogError($"Error generating attendance report: {ex.Message}")
            MessageBox.Show("Error generating report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    Private Sub FormTeacherAttendanceReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class