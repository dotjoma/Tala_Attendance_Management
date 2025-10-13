Imports System.Data.Odbc
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MainForm
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Public currentChild As Form
    Public currentButton As Button
    Public currentUserRole As String = "" ' Store the user's role
    Private Sub OpenForm(ByVal childForm As Form, ByVal isMaximized As Boolean)
        Try
            If currentChild IsNot Nothing Then
                currentChild.Close()
            End If
            currentChild = childForm
            Me.IsMdiContainer = True
            childForm.MdiParent = Me
            childForm.FormBorderStyle = FormBorderStyle.None
            childForm.Dock = DockStyle.Fill
            childForm.WindowState = If(isMaximized, FormWindowState.Maximized, FormWindowState.Normal)
            'PictureBox1.Hide()
            childForm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Public Sub HighlightButton(selectedButton As Button)
        If currentButton IsNot Nothing Then
            currentButton.BackColor = Color.White
            currentButton.ForeColor = Color.DimGray
        End If

        selectedButton.BackColor = Color.DeepSkyBlue
        selectedButton.ForeColor = Color.White
        currentButton = selectedButton
    End Sub

    Private Sub AttendanceToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        FormReportsAttendance.ShowDialog()
    End Sub

    Public Sub FacultyAttendanceLineGraph()
        ' Prepare dictionary for the last 7 days with default count = 0
        Dim attendanceDict As New Dictionary(Of Date, Integer)
        For i As Integer = 8 To 0 Step -1
            attendanceDict.Add(Date.Today.AddDays(-i), 0)
        Next

        ' SQL to get attendance for the past 7 days
        Dim sql As String = "SELECT `logDate`, COUNT(DISTINCT teacherID) AS count " &
                        "FROM attendance_record " &
                        "WHERE `logDate` >= ? " &
                        "GROUP BY `logDate`"

        Try
            connectDB()
            Using cmd As New OdbcCommand(sql, con)
                cmd.Parameters.AddWithValue("?", Date.Today.AddDays(-6))

                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim logDate As Date = Convert.ToDateTime(reader("logDate"))
                        Dim count As Integer = Convert.ToInt32(reader("count"))

                        ' Update only if date is in our range
                        If attendanceDict.ContainsKey(logDate) Then
                            attendanceDict(logDate) = count
                        End If
                    End While
                End Using
            End Using

            ' Clear chart
            'attendanceChart.Series.Clear()
            'attendanceChart.ChartAreas.Clear()

            ' Set up chart area
            Dim chartArea As New ChartArea("MainArea")
            chartArea.AxisX.LabelStyle.Format = "MMM dd"
            chartArea.AxisX.Interval = 1
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray
            'attendanceChart.ChartAreas.Add(chartArea)

            ' Create series
            Dim series As New Series("Weekly Attendance")
            series.ChartType = SeriesChartType.Line
            series.XValueType = ChartValueType.Date
            series.BorderWidth = 3
            series.IsValueShownAsLabel = True ' ✅ Show data labels
            series.MarkerStyle = MarkerStyle.Circle
            series.MarkerSize = 6

            ' Add points
            For Each kvp In attendanceDict
                series.Points.AddXY(kvp.Key, kvp.Value)
            Next

            'attendanceChart.Series.Add(series)

        Catch ex As Exception
            MessageBox.Show("Error loading chart: " & ex.Message)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub
    Function FacultyCount() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM teacherinformation WHERE isActive > 0"

        Try
            connectDB()
            Using cmd As New Odbc.OdbcCommand(sql, con)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching faculty count: " & ex.Message)
            Return -1
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function

    Function AttendanceCount() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM attendance_record WHERE DATE(logDate) = CURDATE()"

        Try
            connectDB()
            Using cmd As New Odbc.OdbcCommand(sql, con)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching attendance count: " & ex.Message)
            Return -1
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function



    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ' Extract user name for logging
            Dim userName As String = lblUser.Text.Replace("Logged in as: ", "")
            If userName.Contains("(") Then
                userName = userName.Substring(0, userName.IndexOf("(")).Trim()
            End If

            _logger.LogInfo($"MainForm closing - User: '{userName}' ({currentUserRole})")

            ' If user is closing via X button, ask for confirmation to exit application
            If e.CloseReason = CloseReason.UserClosing Then
                Dim result As DialogResult = MessageBox.Show(
                    "Are you sure you want to exit the application?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)

                If result = DialogResult.No Then
                    e.Cancel = True
                    _logger.LogInfo($"User '{userName}' ({currentUserRole}) cancelled application exit")
                    Return
                End If

                _logger.LogInfo($"User '{userName}' ({currentUserRole}) exited application via X button")
            End If

            ' Close database connection if open
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try

            ' Close all child forms
            If currentChild IsNot Nothing Then
                currentChild.Close()
                currentChild = Nothing
            End If

            _logger.LogInfo("MainForm closed successfully - Application exiting")
            
            ' Exit the application completely
            Application.Exit()
        Catch ex As Exception
            _logger.LogError("Error during MainForm closing", ex)
            ' Force exit even if there's an error
            Application.Exit()
        End Try
    End Sub

    'Private Sub btnFac_Click(sender As Object, e As EventArgs)
    'HighlightButton(btnFac)
    '0penForm(New FormFaculty, True)
    'AttendanceToolStripMenuIt.Hide()
    ' btnMngUser.Hide()
    '  btnFac.Hide()
    '   btnBTR.Hide()
    'End Sub

    ' Private Sub btnBTR_Click(sender As Object, e As EventArgs)
    'HighlightButton(btnBTR)
    'OpenForm(New FormAttendace, True)
    ' AttendanceToolStripMenuIt.Hide()
    ' btnMngUser.Hide()
    '  btnFac.Hide()
    '   btnBTR.Hide()
    'End Sub

    Private Sub btnAnnouncement_Click(sender As Object, e As EventArgs)
        OpenForm(New FormAnnouncement, True)
    End Sub

    Private Sub SubjectsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenForm(New FormSubjects, False)
    End Sub

    Private Sub ManageUserToolStripMenuItem_Click(sender As Object, e As EventArgs)
        OpenForm(New ManageUser, True)
    End Sub

    Private Sub LogOut()
        Try
            _logger.LogInfo($"User '{labelCurrentUser.Text}' initiated logout (legacy method)")

            If MsgBox("Are you sure you want to Log Out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Log Out") = DialogResult.Yes Then
                _logger.LogInfo($"User '{labelCurrentUser.Text}' logged out successfully")

                ' Close all child forms
                If currentChild IsNot Nothing Then
                    currentChild.Close()
                    currentChild = Nothing
                End If

                ' Hide and show login
                Me.Hide()
                LoginForm.Show()
                LoginForm.ttxtUser.Clear()
                LoginForm.ttxtPass.Clear()
                LoginForm.ttxtUser.Focus()
            Else
                _logger.LogInfo($"User '{labelCurrentUser.Text}' cancelled logout")
            End If
        Catch ex As Exception
            _logger.LogError("Error in LogOut method", ex)
            MessageBox.Show($"An error occurred during logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        LogOut()
    End Sub

    'Private Sub btnMngUser_Click(sender As Object, e As EventArgs)
    'HighlightButton(btnMngUser)
    'OpenForm(New ManageUser, True)
    ' AttendanceToolStripMenuIt.Hide()
    '  btnMngUser.Hide()
    '   btnFac.Hide()
    '    btnBTR.Hide()
    ' End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Label4.Text = Date.Now.ToString("MMMM-dd-yyyy   hh:mm:ss tt")

        Dim faculty As Integer = FacultyCount()
        Dim attendance As Integer = AttendanceCount()

        'labelFacultyCount.Text = faculty.ToString()
        'labelAttendanceCount.Text = attendance.ToString()
        FacultyAttendanceLineGraph()
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    ' Private Sub AttendanceToolStripMenuIt_Click(sender As Object, e As EventArgs)
    ' FormReportsAttendance.ShowDialog()
    'AttendanceToolStripMenuIt.Hide()
    'btnMngUser.Hide()
    'btnFac.Hide()
    'btnBTR.Hide()
    'End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
        FormFaculty.Close()
        FormAttendace.Close()
        ManageUser.Close()
        LoginForm.Show()
    End Sub

    Private Sub AnnouncementToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FormAnnouncement.Show()
    End Sub

    Private Sub FacultyDataToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Dim modalForm As New FormFaculty()
        modalForm.ShowDialog(Me)
        FormAttendace.Close()
        ManageUser.Close()
    End Sub

    Private Sub ManageAccountsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ManageUser.Show()
        FormFaculty.Close()
        FormAttendace.Close()
    End Sub

    Private Sub AttendanceRecordsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        FormAttendace.Show()
        FormFaculty.Close()
        ManageUser.Close()
    End Sub

    Private Sub GenerateReportsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        FormReportsAttendance.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        FormAttendace.Show()
        FormReportsAttendance.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        FormReportsAttendance.ShowDialog()
        FormAttendace.Close()
    End Sub

    Private Sub tsBtnFaculty_Click(sender As Object, e As EventArgs) Handles tsBtnFaculty.Click
        Dim modalForm As New FormFaculty()
        modalForm.ShowDialog(Me)
        FormAttendace.Close()
        ManageUser.Close()
    End Sub

    Private Sub tsBtnAttendance_Click(sender As Object, e As EventArgs) Handles tsBtnAttendance.Click
        FormAttendace.Show()
        FormFaculty.Close()
        ManageUser.Close()
    End Sub

    Private Sub tsLogs_Click(sender As Object, e As EventArgs) Handles tsLogs.Click
        FormReportsAttendance.ShowDialog()
    End Sub

    Private Sub tsFaculty_Click(sender As Object, e As EventArgs) Handles tsFaculty.Click
        'FormReportsFaculty.ShowDialog()
    End Sub

    Private Sub tsManageAccounts_Click(sender As Object, e As EventArgs) Handles tsManageAccounts.Click
        ManageUser.Show()
        FormFaculty.Close()
        FormAttendace.Close()
    End Sub

    Private Sub tsAnnouncements_Click(sender As Object, e As EventArgs) Handles tsAnnouncements.Click
        FormAnnouncement.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub labelAttendanceCount_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles Label1.ContextMenuStripChanged

    End Sub

    Private Sub tsReports_Click(sender As Object, e As EventArgs) Handles tsReports.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub attendanceChart_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub msLogout_Click(sender As Object, e As EventArgs) Handles msLogout.Click
        Try
            ' Extract just the user name from the label (remove "Logged in as: " and role)
            Dim userName As String = lblUser.Text.Replace("Logged in as: ", "")
            If userName.Contains("(") Then
                userName = userName.Substring(0, userName.IndexOf("(")).Trim()
            End If

            _logger.LogInfo($"User '{userName}' ({currentUserRole}) initiated logout")

            Dim result As DialogResult = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                _logger.LogInfo($"User '{userName}' ({currentUserRole}) logged out successfully")

                ' Close all open child forms
                If currentChild IsNot Nothing Then
                    currentChild.Close()
                    currentChild = Nothing
                End If

                ' Close any other open forms
                For Each frm As Form In Application.OpenForms.Cast(Of Form).ToList()
                    If frm IsNot Me AndAlso frm IsNot LoginForm Then
                        frm.Close()
                    End If
                Next

                ' Hide main form and show login form
                Me.Hide()
                LoginForm.Show()
                LoginForm.ttxtUser.Clear()
                LoginForm.ttxtPass.Clear()
                LoginForm.ttxtUser.Focus()
            Else
                _logger.LogInfo($"User '{userName}' ({currentUserRole}) cancelled logout")
            End If
        Catch ex As Exception
            _logger.LogError("Error during logout", ex)
            MessageBox.Show($"An error occurred during logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub msExit_Click(sender As Object, e As EventArgs) Handles msExit.Click
        Try
            ' Extract just the user name from the label (remove "Logged in as: " and role)
            Dim userName As String = lblUser.Text.Replace("Logged in as: ", "")
            If userName.Contains("(") Then
                userName = userName.Substring(0, userName.IndexOf("(")).Trim()
            End If

            _logger.LogInfo($"User '{userName}' ({currentUserRole}) initiated application exit")

            Dim result As DialogResult = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                _logger.LogInfo($"User '{userName}' ({currentUserRole}) exited application")

                ' Close database connection if open
                Try
                    If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                Catch
                    ' Ignore connection close errors
                End Try

                ' Exit application
                Application.Exit()
            Else
                _logger.LogInfo($"User '{userName}' ({currentUserRole}) cancelled exit")
            End If
        Catch ex As Exception
            _logger.LogError("Error during application exit", ex)
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
End Class
