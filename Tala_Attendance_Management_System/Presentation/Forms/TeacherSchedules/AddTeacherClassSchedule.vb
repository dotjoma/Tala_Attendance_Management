Imports System.ComponentModel
Imports System.Data.Odbc

Public Class AddTeacherClassSchedule

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

        ' Load schedules for the teacher with time formatted in 12-hour notation
        Dim query As String = "SELECT MIN(cs.schedule_id) AS schedule_id, " &
                      "s.subject_name, " &
                      "CONCAT(sec.year_level, ' ', sec.section_name) AS section, " &
                      "CONCAT(firstname, ' ', lastname) AS teacher_name, " &
                      "CONCAT(c.location, ' ', c.classroom_name) AS classroom_name, " &
                      "GROUP_CONCAT(DISTINCT cs.day ORDER BY FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')) AS day, " &
                      "DATE_FORMAT(cs.start_time, '%h:%i %p') AS start_time, " &
                      "DATE_FORMAT(cs.end_time, '%h:%i %p') AS end_time, " &
                      "cs.teacherID " &
                      "FROM class_schedules cs " &
                      "JOIN subjects s ON cs.subject_id = s.subject_id " &
                      "JOIN classrooms c ON cs.classroom_id = c.classroom_id " &
                      "JOIN sections sec ON cs.section_id = sec.section_id " &
                      "JOIN teacherinformation t ON cs.teacherID = t.teacherID " &
                      "WHERE cs.isActive=1 " &
                      "GROUP BY cs.teacherID, cs.subject_id, cs.classroom_id, cs.section_id, start_time, end_time " &
                      "ORDER BY s.subject_name, MIN(FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')), cs.start_time"

        loadDGV(query, dgvTeacherSchedule)

    End Sub

    Private Function FormatDays(days As String) As String
        Dim daysArray As String() = days.Split(", ")
        Dim distinctDays As List(Of String) = daysArray.Distinct().ToList()

        Select Case distinctDays.Count
            Case 0
                Return String.Empty
            Case 1
                Return distinctDays(0) ' E.g., "Monday"
            Case 2
                Return String.Join(" and ", distinctDays) ' E.g., "Monday and Tuesday"
            Case 3
                Return String.Join(", ", distinctDays.Take(2)) & " and " & distinctDays(2) ' E.g., "Monday, Tuesday, and Wednesday"
            Case Else
                Dim startDay As String = distinctDays.First()
                Dim endDay As String = distinctDays.Last()

                ' Check if they are consecutive
                If IsConsecutive(distinctDays) Then
                    Return $"{startDay} to {endDay}" ' E.g., "Monday to Thursday"
                Else
                    Return String.Join(", ", distinctDays.Take(distinctDays.Count - 1)) & " and " & distinctDays.Last()
                End If
        End Select
    End Function

    Private Function IsConsecutive(days As List(Of String)) As Boolean
        Dim dayOrder As String() = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"}
        Dim indices As New List(Of Integer)

        For Each day As String In days
            indices.Add(Array.IndexOf(dayOrder, day))
        Next

        ' Check if the indices are consecutive
        For i As Integer = 1 To indices.Count - 1
            If indices(i) <> indices(i - 1) + 1 Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub AddTeacherClassSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub EditSchedule(ByVal id As Integer)
        Try
            Dim cmd As OdbcCommand
            Dim da As New OdbcDataAdapter
            Dim dt As New DataTable

            connectDB()
            cmd = New OdbcCommand("SELECT * FROM class_schedules WHERE schedule_id=?", con)
            cmd.Parameters.AddWithValue("?", id)

            da.SelectCommand = cmd
            da.Fill(dt)

            ' Set the current record to the controls
            If dt.Rows.Count > 0 Then
                ' Set ComboBox values based on the retrieved data

                FormAddTeacherSchedule.editDt = dt

                FormAddTeacherSchedule.cbTeacher.SelectedValue = If(dt.Rows(0)("teacherID") Is DBNull.Value, -1, dt.Rows(0)("teacherID"))
                FormAddTeacherSchedule.cbSubject.SelectedValue = If(dt.Rows(0)("subject_id") Is DBNull.Value, -1, dt.Rows(0)("subject_id"))
                FormAddTeacherSchedule.cbClassroom.SelectedValue = If(dt.Rows(0)("classroom_id") Is DBNull.Value, -1, dt.Rows(0)("classroom_id"))
                FormAddTeacherSchedule.cbSection.SelectedValue = If(dt.Rows(0)("section_id") Is DBNull.Value, -1, dt.Rows(0)("section_id"))

                ' Handle class days
                Dim days As String = If(dt.Rows(0)("day") Is DBNull.Value, "", dt.Rows(0)("day").ToString())
                Dim daysArray As String() = days.Split(New String() {", "}, StringSplitOptions.None)

                ' Set the checklist items based on the retrieved days
                For i As Integer = 0 To FormAddTeacherSchedule.chkListBoxClassDay.Items.Count - 1
                    If daysArray.Contains(FormAddTeacherSchedule.chkListBoxClassDay.Items(i).ToString()) Then
                        FormAddTeacherSchedule.chkListBoxClassDay.SetItemChecked(i, True)
                    End If
                Next

                ' Set start and end time
                FormAddTeacherSchedule.dtpStartTime.Value = DateTime.Today.Add(If(dt.Rows(0)("start_time") Is DBNull.Value, TimeSpan.Zero, CType(dt.Rows(0)("start_time"), TimeSpan)))
                FormAddTeacherSchedule.dtpEndTime.Value = DateTime.Today.Add(If(dt.Rows(0)("end_time") Is DBNull.Value, TimeSpan.Zero, CType(dt.Rows(0)("end_time"), TimeSpan)))

                dgvTeacherSchedule.Tag = dt.Rows(0)("schedule_id")
                FormAddTeacherSchedule.id = dt.Rows(0)("schedule_id")

                FormAddTeacherSchedule.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading schedule: " & ex.Message)
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub


    Private Sub dgvTeacherSchedule_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeacherSchedule.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvTeacherSchedule.Rows(e.RowIndex)
            Dim id As Integer = Convert.ToInt32(row.Cells("schedule_id").Value)

            dgvTeacherSchedule.Tag = dgvTeacherSchedule.Item(0, e.RowIndex).Value
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Val(dgvTeacherSchedule.Tag) > 0 Then
            EditSchedule(Val(dgvTeacherSchedule.Tag))
            dgvTeacherSchedule.CurrentCell = Nothing
        Else
            MessageBox.Show("Select a record to edit", "Edit")
            dgvTeacherSchedule.CurrentCell = Nothing
        End If
    End Sub
    Private Sub dgvTeacherSchedule_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTeacherSchedule.DataBindingComplete
        dgvTeacherSchedule.CurrentCell = Nothing
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Check if a schedule is selected for deletion
        If dgvTeacherSchedule.Tag = 0 Then
            MessageBox.Show("Select a schedule to delete.")
            Return
        End If

        Dim scheduleId = dgvTeacherSchedule.Tag ' Get the schedule ID from the Tag

        ' Confirm deletion
        If MessageBox.Show("Are you sure you want to delete this schedule?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                connectDB()
                ' Create a command to update the record
                Dim cmd As New OdbcCommand("UPDATE class_schedules SET isActive = 0 WHERE schedule_id = ?", con)
                cmd.Parameters.AddWithValue("@schedule_id", scheduleId) ' Set the schedule ID parameter
                cmd.ExecuteNonQuery() ' Execute the command to mark as inactive
                MessageBox.Show("Schedule deleted successfully.")
                DefaultSettings() ' Refresh the schedule list in the DataGridView
            Catch ex As Exception
                MessageBox.Show("Error deleting schedule: " & ex.Message) ' Handle any exceptions
            Finally
                GC.Collect()
                con.Close() ' Close the database connection
            End Try
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        dgvTeacherSchedule.Tag = 0
        FormAddTeacherSchedule.id = 0
        FormAddTeacherSchedule.ShowDialog()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            Dim textSearch As String = txtSearch.Text.Trim()

            ' Create your SQL query with parameter placeholders
            Dim query As String = "SELECT 
                         MIN(cs.schedule_id) AS schedule_id, 
                         s.subject_name, 
                         CONCAT(sec.year_level, ' ', sec.section_name) AS section, 
                         CONCAT(firstname, ' ', lastname) AS teacher_name, 
                         CONCAT(c.location, ' ', c.classroom_name) AS classroom_name, 
                         GROUP_CONCAT(DISTINCT cs.day ORDER BY FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')) AS DAY, 
                         DATE_FORMAT(cs.start_time, '%h:%i %p') AS start_time, 
                         DATE_FORMAT(cs.end_time, '%h:%i %p') AS end_time, 
                         cs.teacherID 
                     FROM class_schedules cs 
                     JOIN subjects s ON cs.subject_id = s.subject_id 
                     JOIN classrooms c ON cs.classroom_id = c.classroom_id 
                     JOIN sections sec ON cs.section_id = sec.section_id 
                     JOIN teacherinformation t ON cs.teacherID = t.teacherID 
                     WHERE cs.isActive = 1 
                       AND (CONCAT(firstname, ' ', lastname) LIKE ? 
                       OR CONCAT(sec.year_level, ' ', sec.section_name) LIKE ? 
                       OR subject_name LIKE ? 
                       OR c.classroom_name LIKE ?) 
                     GROUP BY cs.teacherID, cs.subject_id, cs.classroom_id, cs.section_id, start_time, end_time, 
                         s.subject_name, c.classroom_name, 
                         CONCAT(sec.year_level, ' ', sec.section_name), 
                         CONCAT(firstname, ' ', lastname) 
                     ORDER BY MIN(FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')), cs.start_time;"


            Dim dt As New DataTable
            Dim da As New Odbc.OdbcDataAdapter
            ' Initialize connection and command
            connectDB()
            Dim cmd As New OdbcCommand(query, con)

            Try
                ' Add the parameters with wildcards
                cmd.Parameters.AddWithValue("?", OdbcType.VarChar).Value = "%" & textSearch & "%"
                cmd.Parameters.AddWithValue("?", OdbcType.VarChar).Value = "%" & textSearch & "%"
                cmd.Parameters.AddWithValue("?", OdbcType.VarChar).Value = "%" & textSearch & "%"
                cmd.Parameters.AddWithValue("?", OdbcType.VarChar).Value = "%" & textSearch & "%"
                da.SelectCommand = cmd
                da.Fill(dt)

                dgvTeacherSchedule.DataSource = dt

            Catch ex As Exception
                ' Handle any exceptions that occur
                MessageBox.Show("An error occurred: " & ex.Message)
            Finally
                ' Ensure the command and connection are closed properly
                If Command() IsNot Nothing Then cmd.Dispose()
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
            End Try
        Else
            loadDGV("SELECT MIN(cs.schedule_id) AS schedule_id, " &
                     "s.subject_name, " &
                     "CONCAT(sec.year_level, ' ', sec.section_name) AS section, " &
                     "CONCAT(firstname, ' ', lastname) AS teacher_name, " &
                     "CONCAT(c.location, ' ', c.classroom_name) AS classroom_name, " &
                     "GROUP_CONCAT(DISTINCT cs.day ORDER BY FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')) AS day, " &
                     "DATE_FORMAT(cs.start_time, '%h:%i %p') AS start_time, " &
                     "DATE_FORMAT(cs.end_time, '%h:%i %p') AS end_time, " &
                     "cs.teacherID " &
                     "FROM class_schedules cs " &
                     "JOIN subjects s ON cs.subject_id = s.subject_id " &
                     "JOIN classrooms c ON cs.classroom_id = c.classroom_id " &
                     "JOIN sections sec ON cs.section_id = sec.section_id " &
                     "JOIN teacherinformation t ON cs.teacherID = t.teacherID " &
                     "WHERE cs.isActive=1 " &
                     "GROUP BY cs.teacherID, cs.subject_id, cs.classroom_id, cs.section_id, start_time, end_time " &
                     "ORDER BY MIN(FIELD(cs.day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday')), cs.start_time", dgvTeacherSchedule)
        End If
    End Sub
End Class
