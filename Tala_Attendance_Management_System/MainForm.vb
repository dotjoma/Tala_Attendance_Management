Imports System.Data.Odbc
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MainForm
    Public currentChild As Form
    Public currentButton As Button
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
            attendanceChart.Series.Clear()
            attendanceChart.ChartAreas.Clear()

            ' Set up chart area
            Dim chartArea As New ChartArea("MainArea")
            chartArea.AxisX.LabelStyle.Format = "MMM dd"
            chartArea.AxisX.Interval = 1
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray
            attendanceChart.ChartAreas.Add(chartArea)

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

            attendanceChart.Series.Add(series)

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
        'LogOut()
        LoginForm.Show()
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
        If MsgBox("Are you sure you want to Log Out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Log Out") = DialogResult.Yes Then
            LoginForm.Show()
            Me.Close()
        End If
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

        labelFacultyCount.Text = faculty.ToString()
        labelAttendanceCount.Text = attendance.ToString()
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

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub labelAttendanceCount_Click(sender As Object, e As EventArgs) Handles labelAttendanceCount.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles Label1.ContextMenuStripChanged

    End Sub

    Private Sub tsReports_Click(sender As Object, e As EventArgs) Handles tsReports.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub attendanceChart_Click(sender As Object, e As EventArgs) Handles attendanceChart.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
