Imports System.Data.Odbc

Public Class FormAttendace
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Public strFilter As String = ""
    Private selectedAttendanceId As Integer = 0

    Public Sub DefaultSettings()
        dgvAttendance.CurrentCell = Nothing
        'loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS studentName, DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, arrStatus, DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, depStatus FROM attendance_record ar JOIN studentrecords sr ON ar.tag_id = sr.tagID WHERE logDate = CURDATE()", dgvAttendance)
        'loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS NAME, 
        '         DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
        '         DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
        '         arrStatus, 
        '         DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
        '         depStatus,'Student' AS TYPE, 
        '         CONCAT(cr.location, ' ', cr.classroom_name) AS classroom, 
        '         s.subject_name 
        '         FROM attendance_record ar 
        '         JOIN studentrecords sr ON ar.tag_id = sr.tagID 
        '         JOIN classrooms cr ON ar.classroom_id=cr.classroom_id 
        '         JOIN subjects s ON ar.subject_id=s.subject_id 
        '         WHERE logDate = CURDATE() 
        '         UNION ALL 
        '         SELECT CONCAT(firstname, ' ', lastname) AS NAME, 
        '         DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
        '         DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, arrStatus, 
        '         DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, depStatus,'Teacher' AS TYPE,
        '         CONCAT(cr.location, ' ', cr.classroom_name) AS classroom, 
        '         s.subject_name  
        '         FROM attendance_record ar 
        '         JOIN teacherinformation ti ON ar.tag_id = ti.tagID 
        '         JOIN classrooms cr ON ar.classroom_id=cr.classroom_id 
        '         JOIN subjects s ON ar.subject_id=s.subject_id 
        '         WHERE logDate = CURDATE()", dgvAttendance)

        dgvAttendance.DefaultCellStyle.Font = New Font("Segoe UI", 14)
        dgvAttendance.AlternatingRowsDefaultCellStyle = dgvAttendance.DefaultCellStyle

        dgvAttendance.RowTemplate.Height = 50
        dgvAttendance.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvAttendance.AutoGenerateColumns = False

        LoadAttendanceData()

        cbFilter.SelectedIndex = 0
    End Sub
    
    Private Sub LoadAttendanceData()
        Try
            Dim dateFrom As String = dtpDateFrom.Value.ToString("yyyy-MM-dd")
            Dim dateTo As String = dtpDateTo.Value.ToString("yyyy-MM-dd")
            
            Dim query As String = "SELECT ar.attendanceID, CONCAT(firstname, ' ', lastname) AS NAME, 
                     DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                     DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, arrStatus, 
                     DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, depStatus 
                     FROM attendance_record ar 
                     JOIN teacherinformation ti ON ar.tag_id = ti.tagID 
                     WHERE logDate BETWEEN '" & dateFrom & "' AND '" & dateTo & "'"
            
            ' Add search filter if provided
            If txtSearch.Text.Trim().Length > 0 Then
                query &= " AND (ti.firstname LIKE '%" & txtSearch.Text.Trim() & "%' OR ti.lastname LIKE '%" & txtSearch.Text.Trim() & "%')"
            End If
            
            query &= " ORDER BY logDate DESC, arrivalTime DESC"
            
            loadDGV(query, dgvAttendance)
            
            _logger.LogInfo($"Loaded {dgvAttendance.Rows.Count} attendance records from {dateFrom} to {dateTo}")
        Catch ex As Exception
            _logger.LogError($"Error loading attendance data: {ex.Message}")
            MessageBox.Show("Error loading attendance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FormAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default date range to today
        dtpDateFrom.Value = DateTime.Today
        dtpDateTo.Value = DateTime.Today
        
        DefaultSettings()
        ApplyRoleBasedAccess()
        
        _logger.LogInfo("FormAttendance loaded")
    End Sub
    
    Private Sub ApplyRoleBasedAccess()
        ' Only Admin and HR can edit attendance records
        Dim userRole As String = MainForm.currentUserRole.ToLower()
        btnEdit.Visible = (userRole = "admin" OrElse userRole = "hr")
        
        _logger.LogInfo($"Role-based access applied - User role: {userRole}, Edit button visible: {btnEdit.Visible}")
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        UpdateDataBasedOnFilterAndSearch()
    End Sub

    Private Sub dgvAttendance_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvAttendance.DataBindingComplete
        dgvAttendance.CurrentCell = Nothing
    End Sub

    Private Sub cbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFilter.SelectedIndexChanged
        UpdateDataBasedOnFilterAndSearch()
    End Sub
    Private Sub UpdateDataBasedOnFilterAndSearch()
        Dim strFilter As String = cbFilter.SelectedItem.ToString()

        Try
            Select Case strFilter
                Case "All"
                    LoadAllRecords()
                Case "Teachers"
                    LoadTeachersRecords()
                Case "Students"
                    LoadStudentsRecords()
                Case Else
                    DefaultSettings()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub SearchAllRecords()
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable

        Dim sql As String = ""

        ' Construct the SQL query with parameters
        sql = "SELECT CONCAT(firstname, ' ', lastname) AS Name, DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, " &
           "DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, arrStatus, " &
           "DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, depStatus  " &
           "FROM attendance_record ar JOIN teacherinformation ti ON ar.tag_id = ti.tagID " &
           "WHERE logDate = CURDATE() AND (ti.lastname LIKE ? OR ti.firstname LIKE ? OR DATE_FORMAT(ar.logDate, '%Y-%m-%d') LIKE ?)"

        Try
            connectDB()
            cmd = New Odbc.OdbcCommand(sql, con)

            cmd.Parameters.AddWithValue("@lastname", "%" & txtSearch.Text.Trim() & "%")
            cmd.Parameters.AddWithValue("@firstname", "%" & txtSearch.Text.Trim() & "%")
            cmd.Parameters.AddWithValue("@logDate", "%" & txtSearch.Text.Trim() & "%")

            da.SelectCommand = cmd
            da.Fill(dt)
            dgvAttendance.DataSource = dt
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Sub LoadAllRecords()
        If txtSearch.TextLength > 0 Then
            SearchAllRecords()
        Else
            'loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS Name, 
            '         DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
            '         DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
            '         arrStatus, DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
            '         depStatus,'Student' AS TYPE, 
            '         CONCAT(cr.location, ' ', cr.classroom_name) AS classroom, 
            '         s.subject_name 
            '         FROM attendance_record ar 
            '         JOIN studentrecords sr ON ar.tag_id = sr.tagID 
            '         JOIN classrooms cr ON ar.classroom_id=cr.classroom_id 
            '         JOIN subjects s ON ar.subject_id=s.subject_id 
            '         WHERE logDate = CURDATE() 
            '         UNION ALL 
            '         SELECT CONCAT(firstname, ' ', lastname) AS NAME, 
            '         DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
            '         DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
            '         arrStatus, DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
            '         depStatus,'Teacher' AS TYPE, 
            '         CONCAT(cr.location, ' ', cr.classroom_name) AS classroom, 
            '         s.subject_name 
            '         FROM attendance_record ar 
            '         JOIN teacherinformation ti ON ar.tag_id = ti.tagID 
            '         JOIN classrooms cr ON ar.classroom_id=cr.classroom_id 
            '         JOIN subjects s ON ar.subject_id=s.subject_id 
            '         WHERE logDate = CURDATE()", dgvAttendance)

            loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS NAME, 
                     DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                     DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
                     arrStatus, DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
                     depStatus 
                     FROM attendance_record ar 
                     JOIN teacherinformation ti ON ar.tag_id = ti.tagID 
                     WHERE logDate = CURDATE()", dgvAttendance)
        End If
    End Sub

    Private Sub LoadTeachersRecords()
        If txtSearch.TextLength > 0 Then
            loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS Name, 
                     DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                     DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
                     arrStatus, DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
                     depStatus 
                     FROM attendance_record ar 
                     JOIN teacherinformation ti ON ar.tag_id = ti.tagID  
                     WHERE logDate = CURDATE()", dgvAttendance, "lastname", "firstname", "logDate", txtSearch.Text.Trim())
        Else
            loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS Name, 
                     DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                     DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
                     arrStatus, DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
                     depStatus 
                     FROM attendance_record ar 
                     JOIN teacherinformation ti ON ar.tag_id = ti.tagID  
                     WHERE logDate = CURDATE()", dgvAttendance)
        End If
    End Sub

    Private Sub LoadStudentsRecords()
        If txtSearch.TextLength > 0 Then
            loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS Name, 
                     DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                     DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
                     arrStatus, 
                     DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
                     depStatus,'Student' AS TYPE,
                     CONCAT(cr.location, ' ', cr.classroom_name) AS classroom, 
                     s.subject_name 
                     FROM attendance_record ar 
                     JOIN studentrecords sr ON ar.tag_id = sr.tagID 
                     JOIN classrooms cr ON ar.classroom_id=cr.classroom_id 
                     JOIN subjects s ON ar.subject_id=s.subject_id 
                     WHERE logDate = CURDATE()", dgvAttendance, "lastname", "firstname", "logDate", txtSearch.Text.Trim())
        Else
            loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS Name, 
                     DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                     DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
                     arrStatus, DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, 
                     depStatus,'Student' AS TYPE,
                     CONCAT(cr.location, ' ', cr.classroom_name) AS classroom, 
                     s.subject_name 
                     FROM attendance_record ar 
                     JOIN studentrecords sr ON ar.tag_id = sr.tagID 
                     JOIN classrooms cr ON ar.classroom_id=cr.classroom_id 
                     JOIN subjects s ON ar.subject_id=s.subject_id 
                     WHERE logDate = CURDATE()", dgvAttendance)
        End If
    End Sub
    
    Private Sub dtpDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateFrom.ValueChanged
        LoadAttendanceData()
    End Sub
    
    Private Sub dtpDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateTo.ValueChanged
        LoadAttendanceData()
    End Sub
    
    Private Sub dgvAttendance_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAttendance.CellClick
        Try
            If e.RowIndex >= 0 AndAlso dgvAttendance.Rows(e.RowIndex).Cells("attendanceID").Value IsNot Nothing Then
                selectedAttendanceId = Convert.ToInt32(dgvAttendance.Rows(e.RowIndex).Cells("attendanceID").Value)
                _logger.LogDebug($"Selected attendance ID: {selectedAttendanceId}")
            End If
        Catch ex As Exception
            _logger.LogError($"Error selecting attendance record: {ex.Message}")
        End Try
    End Sub
    
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedAttendanceId = 0 Then
            MessageBox.Show("Please select an attendance record to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        
        Try
            _logger.LogInfo($"Opening edit dialog for attendance ID: {selectedAttendanceId}")
            
            ' Get current values
            Dim cmd As New OdbcCommand("SELECT arrivalTime, departureTime, CONCAT(ti.firstname, ' ', ti.lastname) AS teacher_name, logDate 
                                        FROM attendance_record ar 
                                        JOIN teacherinformation ti ON ar.tag_id = ti.tagID 
                                        WHERE ar.attendanceID = ?", con)
            cmd.Parameters.AddWithValue("?", selectedAttendanceId)
            
            connectDB()
            Dim reader = cmd.ExecuteReader()
            
            If reader.Read() Then
                Dim teacherName As String = reader("teacher_name").ToString()
                Dim logDate As Date = Convert.ToDateTime(reader("logDate"))
                Dim currentTimeIn As Object = reader("arrivalTime")
                Dim currentTimeOut As Object = reader("departureTime")
                
                reader.Close()
                
                ' Show edit dialog
                Using editForm As New FormEditAttendance()
                    editForm.AttendanceId = selectedAttendanceId
                    editForm.TeacherName = teacherName
                    editForm.AttendanceDate = logDate
                    editForm.TimeIn = If(IsDBNull(currentTimeIn), Nothing, Convert.ToDateTime(currentTimeIn))
                    editForm.TimeOut = If(IsDBNull(currentTimeOut), Nothing, Convert.ToDateTime(currentTimeOut))
                    
                    If editForm.ShowDialog() = DialogResult.OK Then
                        LoadAttendanceData()
                        _logger.LogInfo($"Attendance record {selectedAttendanceId} updated successfully")
                    End If
                End Using
            Else
                reader.Close()
                MessageBox.Show("Attendance record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            
        Catch ex As Exception
            _logger.LogError($"Error editing attendance record: {ex.Message}")
            MessageBox.Show("Error editing attendance record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
    
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvAttendance.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (*.csv)|*.csv"
            saveDialog.FileName = $"TeacherAttendance_{dtpDateFrom.Value:yyyyMMdd}_to_{dtpDateTo.Value:yyyyMMdd}.csv"
            
            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
                MessageBox.Show("Report exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _logger.LogInfo($"Attendance report exported to: {saveDialog.FileName}")
            End If
            
        Catch ex As Exception
            _logger.LogError($"Error exporting report: {ex.Message}")
            MessageBox.Show("Error exporting report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub ExportToCSV(filePath As String)
        Using writer As New System.IO.StreamWriter(filePath, False, System.Text.Encoding.UTF8)
            ' Write headers
            Dim headers As New List(Of String)
            For Each column As DataGridViewColumn In dgvAttendance.Columns
                If column.Visible AndAlso column.Name <> "attendanceID" Then
                    headers.Add(column.HeaderText)
                End If
            Next
            writer.WriteLine(String.Join(",", headers))
            
            ' Write data
            For Each row As DataGridViewRow In dgvAttendance.Rows
                Dim values As New List(Of String)
                For Each column As DataGridViewColumn In dgvAttendance.Columns
                    If column.Visible AndAlso column.Name <> "attendanceID" Then
                        Dim cellValue = row.Cells(column.Index).Value
                        Dim value As String = If(cellValue Is Nothing, "", cellValue.ToString().Replace(",", ";"))
                        values.Add($"""{value}""")
                    End If
                Next
                writer.WriteLine(String.Join(",", values))
            Next
        End Using
    End Sub
    
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvAttendance.Rows.Count = 0 Then
                MessageBox.Show("No data to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            
            ' Create a simple print preview
            Dim printDoc As New Printing.PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintDocument_PrintPage
            
            Dim printPreview As New PrintPreviewDialog()
            printPreview.Document = printDoc
            printPreview.ShowDialog()
            
            _logger.LogInfo("Attendance report printed")
            
        Catch ex As Exception
            _logger.LogError($"Error printing report: {ex.Message}")
            MessageBox.Show("Error printing report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim font As New Font("Arial", 10)
        Dim headerFont As New Font("Arial", 12, FontStyle.Bold)
        Dim y As Integer = 50
        Dim x As Integer = 50
        
        ' Print title
        e.Graphics.DrawString("Teacher Daily Attendance Report", headerFont, Brushes.Black, x, y)
        y += 30
        e.Graphics.DrawString($"Period: {dtpDateFrom.Value:MM/dd/yyyy} to {dtpDateTo.Value:MM/dd/yyyy}", font, Brushes.Black, x, y)
        y += 40
        
        ' Print headers
        Dim colX As Integer = x
        For Each column As DataGridViewColumn In dgvAttendance.Columns
            If column.Visible AndAlso column.Name <> "attendanceID" Then
                e.Graphics.DrawString(column.HeaderText, New Font("Arial", 9, FontStyle.Bold), Brushes.Black, colX, y)
                colX += 120
            End If
        Next
        y += 25
        
        ' Print rows (limited to fit on page)
        Dim rowCount As Integer = 0
        For Each row As DataGridViewRow In dgvAttendance.Rows
            If y > e.PageBounds.Height - 100 Then Exit For ' Stop if near bottom of page
            
            colX = x
            For Each column As DataGridViewColumn In dgvAttendance.Columns
                If column.Visible AndAlso column.Name <> "attendanceID" Then
                    Dim cellValue = row.Cells(column.Index).Value
                    Dim value As String = If(cellValue Is Nothing, "", cellValue.ToString())
                    e.Graphics.DrawString(value, font, Brushes.Black, colX, y)
                    colX += 120
                End If
            Next
            y += 20
            rowCount += 1
        Next
        
        ' Print footer
        y = e.PageBounds.Height - 50
        e.Graphics.DrawString($"Printed: {DateTime.Now:MM/dd/yyyy hh:mm tt} | Total Records: {dgvAttendance.Rows.Count}", New Font("Arial", 8), Brushes.Gray, x, y)
    End Sub
End Class