Public Class FormAttendace
    Public strFilter As String = ""

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

        loadDGV("SELECT CONCAT(firstname, ' ', lastname) AS NAME, 
                 DATE_FORMAT(logDate, '%M %d, %Y') AS logDate, 
                 DATE_FORMAT(arrivalTime, '%h:%i:%s %p') AS arrivalTime, arrStatus, 
                 DATE_FORMAT(departureTime, '%h:%i:%s %p') AS departureTime, depStatus 
                 FROM attendance_record ar 
                 JOIN teacherinformation ti ON ar.tag_id = ti.tagID 
                 WHERE logDate = CURDATE()", dgvAttendance)

        cbFilter.SelectedIndex = 0
    End Sub
    Private Sub FormAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
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
End Class