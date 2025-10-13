Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms

Public Class FormReportsAttendance
    Private Sub FormReportsAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate sections ComboBox on form load
        Dim sectionQuery As String = "
            SELECT DISTINCT sc.section_id, CONCAT(sc.year_level, ' ', sc.section_name) AS section_name 
            FROM sections sc
            JOIN class_schedules cs ON sc.section_id = cs.section_id
            WHERE sc.isActive = 1 AND cs.isActive = 1 
            ORDER BY CAST(sc.year_level AS SIGNED), sc.section_name"
        loadCBO(sectionQuery, "section_id", "section_name", cbSection)

        ' Initially, set teachers ComboBox to empty
        cbTeacher.DataSource = Nothing
    End Sub

    Private Sub cbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSection.SelectedIndexChanged
        If cbSection.SelectedValue IsNot Nothing Then
            ' Get the selected section ID
            Dim selectedSectionID = cbSection.SelectedValue.ToString()

            ' Dynamically load teachers for the selected section
            Dim teacherQuery As String = "
                SELECT DISTINCT ti.teacherID, CONCAT(ti.firstname, ' ', ti.lastname) AS teacher_name
                FROM teacherinformation ti
                JOIN class_schedules cs ON ti.teacherID = cs.teacherID
                WHERE cs.section_id = '" & selectedSectionID & "' AND ti.isActive = 1 AND cs.isActive=1  
                ORDER BY ti.lastname, ti.firstname"
            loadCBO(teacherQuery, "teacherID", "teacher_name", cbTeacher)
        Else
            ' Clear teacher ComboBox if no section is selected
            cbTeacher.DataSource = Nothing
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        ' Validate input
        If Not ValidateInputs() Then Exit Sub

        Dim cmd As OdbcCommand
        Dim da As New OdbcDataAdapter
        Dim dt As New DataTable
        Try
            connectDB()

            ' Get selected values from ComboBoxes
            'Dim selectedSectionID As String = cbSection.SelectedValue.ToString()
            'Dim selectedTeacherID As String = cbTeacher.SelectedValue.ToString()

            ' SQL query for the report      
            cmd = New Odbc.OdbcCommand("
                        SELECT 
                            CONCAT(ti.firstname, ' ', ti.lastname) AS firstname,
                            ti.employeeID AS lastname,
                            DATE_FORMAT(ar.logDate, '%M %d, %Y') AS logDate,
                            DATE_FORMAT(ar.departureTime, '%h:%i:%s %p') AS departureTime,
                            DATE_FORMAT(ar.arrivalTime, '%h:%i:%s %p') AS arrivalTime,
                            CASE 
                                WHEN ar.arrivalTime IS NULL THEN 'No record'
                                WHEN TIME(ar.arrivalTime) > '08:00:00' THEN 'Late'
                                WHEN TIME(ar.arrivalTime) < '07:59:00' THEN 'Early' 
                                ELSE 'On time'
                            END AS depStatus
                        FROM attendance_record ar 
                        JOIN teacherinformation ti ON ar.tag_id = ti.tagID
                        WHERE ar.logDate BETWEEN ? AND ?
                        GROUP BY ar.logDate, ti.lastname, ti.firstname", con)


            'cmd = New Odbc.OdbcCommand("
            '    SELECT CONCAT(ti.firstname, ' ', ti.lastname) AS firstname,
            '           CONCAT(ti.firstname, ' ', ti.lastname) AS lastname,
            '           DATE_FORMAT(ar.logDate, '%M %d, %Y') AS logDate,
            '           DATE_FORMAT(ar.departureTime, '%h:%i:%s %p') AS departureTime,
            '           DATE_FORMAT(ar.arrivalTime, '%h:%i:%s %p') AS arrivalTime, 
            '           CASE WHEN MIN(TIME(ar.arrivalTime)) < TIME(cs.start_time) THEN 'Early'
            '                WHEN MIN(TIME(ar.arrivalTime)) = TIME(cs.start_time) THEN 'On Time'
            '                WHEN TIMESTAMPDIFF(MINUTE, TIME(cs.start_time), MIN(TIME(ar.arrivalTime))) <= 15 THEN 'Late (with grace)'
            '                ELSE 'Late'
            '           END AS depStatus
            '    FROM attendance_record ar 
            '    JOIN teacherinformation ti ON ar.tag_id = ti.tagID
            '    WHERE ar.logDate BETWEEN ? AND ?
            '    GROUP BY ar.logDate, ti.lastname, ti.firstname", con)

            ' Add parameters to the query
            cmd.Parameters.AddWithValue("?", dtpFrom.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("?", dtpTo.Value.ToString("yyyy-MM-dd"))
            'cmd.Parameters.AddWithValue("?", selectedSectionID)
            'cmd.Parameters.AddWithValue("?", selectedTeacherID)

            ' Execute query and fill DataTable
            da.SelectCommand = cmd
            da.Fill(dt)

            ' Configure report viewer
            With Me.rvAttendance.LocalReport
                .DataSources.Clear()
                .ReportPath = "ReportAttendance.rdlc"
                .DataSources.Add(New ReportDataSource("DataSet1", dt))
            End With
            Me.rvAttendance.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    ' Validate user inputs
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(dtpFrom.Text) OrElse String.IsNullOrEmpty(dtpTo.Text) Then
            MessageBox.Show("Please select a valid date range.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        'If cbSection.SelectedIndex = -1 Then
        '    MessageBox.Show("Please select a section.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return False
        'End If
        '
        'If cbTeacher.SelectedIndex = -1 Then
        '    MessageBox.Show("Please select a teacher.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return False
        'End If

        Return True
    End Function
End Class
