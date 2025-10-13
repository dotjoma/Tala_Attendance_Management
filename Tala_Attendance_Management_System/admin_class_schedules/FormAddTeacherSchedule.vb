Imports System.Data.Odbc

Public Class FormAddTeacherSchedule
    Public id As Integer = 0
    Public editDt As New DataTable

    ' Load default settings for ComboBoxes
    Public Sub DefaultSettings()
        loadCBO("SELECT teacherID, CONCAT(firstname, ' ', lastname) AS teacher_name FROM teacherinformation WHERE isActive = 1", "teacherID", "teacher_name", cbTeacher)
        loadCBO("SELECT subject_id, subject_name FROM subjects WHERE isActive = 1", "subject_id", "subject_name", cbSubject)
        loadCBO("SELECT classroom_id, CONCAT(location, ' ', classroom_name) AS classroom_name FROM classrooms WHERE isActive = 1", "classroom_id", "classroom_name", cbClassroom)
        loadCBO("SELECT section_id, CONCAT(year_level, ' ', section_name) AS section_name FROM sections WHERE isActive = 1 ORDER BY CAST(year_level AS SIGNED), section_name", "section_id", "section_name", cbSection)
    End Sub

    Private Sub FormAddTeacherSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure start time DateTimePicker
        dtpStartTime.Format = DateTimePickerFormat.Custom
        dtpStartTime.CustomFormat = "hh:mm tt"
        dtpStartTime.ShowUpDown = True

        ' Configure end time DateTimePicker
        dtpEndTime.Format = DateTimePickerFormat.Custom
        dtpEndTime.CustomFormat = "hh:mm tt"
        dtpEndTime.ShowUpDown = True

        DefaultSettings()

        ' Populate fields for editing
        If editDt.Rows.Count > 0 Then
            cbTeacher.SelectedValue = editDt.Rows(0)("teacherID")
            cbSubject.SelectedValue = editDt.Rows(0)("subject_id")
            cbClassroom.SelectedValue = editDt.Rows(0)("classroom_id")
            cbSection.SelectedValue = editDt.Rows(0)("section_id")
            dtpStartTime.Value = DateTime.Parse(editDt.Rows(0)("start_time").ToString())
            dtpEndTime.Value = DateTime.Parse(editDt.Rows(0)("end_time").ToString())

            Dim days As String() = editDt.Rows(0)("day").ToString().Split(","c)
            For i As Integer = 0 To chkListBoxClassDay.Items.Count - 1
                If days.Contains(chkListBoxClassDay.Items(i).ToString()) Then
                    chkListBoxClassDay.SetItemChecked(i, True)
                End If
            Next
        End If

        If id = 0 Then
            ResetFields()
        End If
    End Sub

    ' Reset all fields to default state
    Public Sub ResetFields()
        cbTeacher.SelectedIndex = -1
        cbSubject.SelectedIndex = -1
        cbClassroom.SelectedIndex = -1
        cbSection.SelectedIndex = -1
        dtpStartTime.Value = DateTime.Now
        dtpEndTime.Value = DateTime.Now

        For i As Integer = 0 To chkListBoxClassDay.Items.Count - 1
            chkListBoxClassDay.SetItemChecked(i, False)
        Next
    End Sub

    ' Validate and format start time
    Private Sub dtpStartTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartTime.ValueChanged
        Dim selectedTime As DateTime = dtpStartTime.Value
        dtpStartTime.Value = New DateTime(selectedTime.Year, selectedTime.Month, selectedTime.Day, selectedTime.Hour, selectedTime.Minute, 0)
    End Sub

    ' Validate and format end time
    Private Sub dtpEndTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndTime.ValueChanged
        Dim selectedTime As DateTime = dtpEndTime.Value
        dtpEndTime.Value = New DateTime(selectedTime.Year, selectedTime.Month, selectedTime.Day, selectedTime.Hour, selectedTime.Minute, 0)
    End Sub

    ' Cancel button to reset and close the form
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ResetFields()
        Me.Close()
    End Sub

    ' Save or update the schedule
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Ensure all required selections are made
        If cbTeacher.SelectedIndex = -1 OrElse cbSubject.SelectedIndex = -1 OrElse cbClassroom.SelectedIndex = -1 OrElse cbSection.SelectedIndex = -1 Then
            MessageBox.Show("Please select a teacher, subject, classroom, and section.")
            Return
        End If

        ' Ensure valid time range
        If dtpEndTime.Value.TimeOfDay <= dtpStartTime.Value.TimeOfDay Then
            MsgBox("End Time must be greater than Start Time.", MsgBoxStyle.OkOnly, "Error")
            Return
        End If

        ' Get selected days
        Dim selectedDays As New List(Of String)
        For Each item In chkListBoxClassDay.CheckedItems
            selectedDays.Add(item.ToString())
        Next

        If selectedDays.Count = 0 Then
            MessageBox.Show("Please select at least one class day.")
            Return
        End If

        ' Prepare data for conflict checking
        Dim teacherID As Integer = Convert.ToInt32(cbTeacher.SelectedValue)
        Dim sectionID As Integer = Convert.ToInt32(cbSection.SelectedValue)
        Dim classroomID As Integer = Convert.ToInt32(cbClassroom.SelectedValue)
        Dim startTime As TimeSpan = dtpStartTime.Value.TimeOfDay
        Dim endTime As TimeSpan = dtpEndTime.Value.TimeOfDay
        Dim days As String = String.Join(",", selectedDays)

        Try
            connectDB()

            ' Conflict check SQL query
            Dim cmdConflict As New OdbcCommand("
                            SELECT COUNT(*)
                            FROM class_schedules
                            WHERE (
                                (classroom_id = ? OR section_id = ? OR teacherID = ?) 
                                AND (
                                    (start_time < ? AND end_time > ?) OR 
                                    (start_time < ? AND end_time > ?) OR 
                                    (start_time >= ? AND end_time <= ?)
                                )
                                AND (
                                    " & String.Join(" OR ", selectedDays.Select(Function(d, i) "FIND_IN_SET(?, day)").ToArray()) & "
                                )
                            )
                            AND isActive = 1 
                            " & If(id > 0, "AND schedule_id <> ?", ""), con)


            ' Add parameters for conflict query
            cmdConflict.Parameters.Add("@classroom_id", OdbcType.Int).Value = classroomID
            cmdConflict.Parameters.Add("@sectionID", OdbcType.Int).Value = sectionID
            cmdConflict.Parameters.Add("@teacherID", OdbcType.Int).Value = teacherID
            cmdConflict.Parameters.Add("@start_time1", OdbcType.Time).Value = endTime
            cmdConflict.Parameters.Add("@end_time1", OdbcType.Time).Value = startTime
            cmdConflict.Parameters.Add("@start_time2", OdbcType.Time).Value = startTime
            cmdConflict.Parameters.Add("@end_time2", OdbcType.Time).Value = endTime
            cmdConflict.Parameters.Add("@start_time3", OdbcType.Time).Value = startTime
            cmdConflict.Parameters.Add("@end_time3", OdbcType.Time).Value = endTime

            For Each day As String In selectedDays
                cmdConflict.Parameters.Add("@day", OdbcType.VarChar).Value = day
            Next

            ' Exclude current schedule during update
            If id > 0 Then
                cmdConflict.Parameters.Add("@schedule_id", OdbcType.Int).Value = id
            End If

            ' Check conflicts
            Dim conflictCount As Integer = Convert.ToInt32(cmdConflict.ExecuteScalar())
            If conflictCount > 0 Then
                MessageBox.Show("The selected schedule conflicts with an existing schedule for the teacher. Please choose a different time or day.", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Insert or update the schedule
            Dim cmd As New OdbcCommand()
            If id = 0 Then
                cmd = New OdbcCommand("INSERT INTO class_schedules (teacherID, subject_id, classroom_id, section_id, day, start_time, end_time, isActive) VALUES (?, ?, ?, ?, ?, ?, ?, 1)", con)
                cmd.Parameters.AddWithValue("@teacherID", cbTeacher.SelectedValue)
                cmd.Parameters.AddWithValue("@subject_id", cbSubject.SelectedValue)
                cmd.Parameters.AddWithValue("@classroom_id", cbClassroom.SelectedValue)
                cmd.Parameters.AddWithValue("@section_id", cbSection.SelectedValue)
                cmd.Parameters.AddWithValue("@days", days)
                cmd.Parameters.AddWithValue("@start_time", dtpStartTime.Value.TimeOfDay)
                cmd.Parameters.AddWithValue("@end_time", dtpEndTime.Value.TimeOfDay)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Schedule added successfully.")
            Else
                Dim scheduleId = id
                cmd = New OdbcCommand("UPDATE class_schedules SET teacherID = ?, subject_id = ?, classroom_id = ?, section_id = ?, day = ?, start_time = ?, end_time = ?, isActive = 1 WHERE schedule_id = ?", con)
                cmd.Parameters.AddWithValue("@teacherID", cbTeacher.SelectedValue)
                cmd.Parameters.AddWithValue("@subject_id", cbSubject.SelectedValue)
                cmd.Parameters.AddWithValue("@classroom_id", cbClassroom.SelectedValue)
                cmd.Parameters.AddWithValue("@section_id", cbSection.SelectedValue)
                cmd.Parameters.AddWithValue("@days", days)
                cmd.Parameters.AddWithValue("@start_time", dtpStartTime.Value.TimeOfDay)
                cmd.Parameters.AddWithValue("@end_time", dtpEndTime.Value.TimeOfDay)
                cmd.Parameters.AddWithValue("@schedule_id", scheduleId)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Schedule updated successfully.")
            End If

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving schedule: " & ex.Message)
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    ' Reset fields and refresh parent form on close
    Private Sub FormAddTeacherSchedule_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ResetFields()
        Dim teacherSchedule As AddTeacherClassSchedule = TryCast(Application.OpenForms("AddTeacherClassSchedule"), AddTeacherClassSchedule)
        If teacherSchedule IsNot Nothing Then
            teacherSchedule.DefaultSettings()
        End If
    End Sub
End Class
