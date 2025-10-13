<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelCurrentUser = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.toolStripNav = New System.Windows.Forms.ToolStrip()
        Me.tsBtnFaculty = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsBtnAttendance = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsManageAccounts = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsAnnouncements = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsLogs = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFaculty = New System.Windows.Forms.ToolStripMenuItem()
        Me.panelFaculty = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.labelFacultyCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelGraph = New System.Windows.Forms.Panel()
        Me.attendanceChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.panelAttendance = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.labelAttendanceCount = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5.SuspendLayout()
        Me.toolStripNav.SuspendLayout()
        Me.panelFaculty.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelGraph.SuspendLayout()
        CType(Me.attendanceChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelAttendance.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1924, 0)
        Me.Panel1.TabIndex = 11
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1578, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(221, 37)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "USER LOGGED IN:"
        '
        'labelCurrentUser
        '
        Me.labelCurrentUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelCurrentUser.AutoSize = True
        Me.labelCurrentUser.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labelCurrentUser.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCurrentUser.ForeColor = System.Drawing.Color.Black
        Me.labelCurrentUser.Location = New System.Drawing.Point(1805, 25)
        Me.labelCurrentUser.Name = "labelCurrentUser"
        Me.labelCurrentUser.Size = New System.Drawing.Size(98, 37)
        Me.labelCurrentUser.TabIndex = 12
        Me.labelCurrentUser.Text = "Admin"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 780)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1924, 45)
        Me.Panel5.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(565, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(784, 32)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Tala High School Yakal St. Bo San Isidro, Tala Caloocan City, Philippines"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'toolStripNav
        '
        Me.toolStripNav.BackColor = System.Drawing.SystemColors.ControlLight
        Me.toolStripNav.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolStripNav.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsBtnFaculty, Me.ToolStripSeparator2, Me.tsBtnAttendance, Me.ToolStripSeparator1, Me.tsManageAccounts, Me.ToolStripSeparator3, Me.tsAnnouncements, Me.ToolStripSeparator4, Me.tsReports})
        Me.toolStripNav.Location = New System.Drawing.Point(0, 0)
        Me.toolStripNav.Name = "toolStripNav"
        Me.toolStripNav.Size = New System.Drawing.Size(1924, 92)
        Me.toolStripNav.TabIndex = 31
        Me.toolStripNav.Text = "ToolStrip1"
        '
        'tsBtnFaculty
        '
        Me.tsBtnFaculty.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnFaculty.ForeColor = System.Drawing.Color.SteelBlue
        Me.tsBtnFaculty.Image = CType(resources.GetObject("tsBtnFaculty.Image"), System.Drawing.Image)
        Me.tsBtnFaculty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnFaculty.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnFaculty.Name = "tsBtnFaculty"
        Me.tsBtnFaculty.Size = New System.Drawing.Size(111, 89)
        Me.tsBtnFaculty.Text = "&FACULTY"
        Me.tsBtnFaculty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 92)
        '
        'tsBtnAttendance
        '
        Me.tsBtnAttendance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsBtnAttendance.ForeColor = System.Drawing.Color.SteelBlue
        Me.tsBtnAttendance.Image = CType(resources.GetObject("tsBtnAttendance.Image"), System.Drawing.Image)
        Me.tsBtnAttendance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsBtnAttendance.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnAttendance.Name = "tsBtnAttendance"
        Me.tsBtnAttendance.Size = New System.Drawing.Size(145, 89)
        Me.tsBtnAttendance.Text = "&ATTENDANCE"
        Me.tsBtnAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 92)
        '
        'tsManageAccounts
        '
        Me.tsManageAccounts.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsManageAccounts.ForeColor = System.Drawing.Color.SteelBlue
        Me.tsManageAccounts.Image = CType(resources.GetObject("tsManageAccounts.Image"), System.Drawing.Image)
        Me.tsManageAccounts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsManageAccounts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsManageAccounts.Name = "tsManageAccounts"
        Me.tsManageAccounts.Size = New System.Drawing.Size(199, 89)
        Me.tsManageAccounts.Text = "&MANAGE ACCOUNT"
        Me.tsManageAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 92)
        '
        'tsAnnouncements
        '
        Me.tsAnnouncements.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsAnnouncements.ForeColor = System.Drawing.Color.SteelBlue
        Me.tsAnnouncements.Image = CType(resources.GetObject("tsAnnouncements.Image"), System.Drawing.Image)
        Me.tsAnnouncements.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsAnnouncements.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAnnouncements.Name = "tsAnnouncements"
        Me.tsAnnouncements.Size = New System.Drawing.Size(182, 89)
        Me.tsAnnouncements.Text = "&ANNOUNCEMENT"
        Me.tsAnnouncements.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 92)
        '
        'tsReports
        '
        Me.tsReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLogs, Me.tsFaculty})
        Me.tsReports.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsReports.ForeColor = System.Drawing.Color.SteelBlue
        Me.tsReports.Image = CType(resources.GetObject("tsReports.Image"), System.Drawing.Image)
        Me.tsReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsReports.Name = "tsReports"
        Me.tsReports.Size = New System.Drawing.Size(113, 92)
        Me.tsReports.Text = "&REPORTS"
        Me.tsReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsLogs
        '
        Me.tsLogs.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_elective_30
        Me.tsLogs.Name = "tsLogs"
        Me.tsLogs.Size = New System.Drawing.Size(167, 28)
        Me.tsLogs.Text = "LOGS"
        '
        'tsFaculty
        '
        Me.tsFaculty.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_cog_48
        Me.tsFaculty.Name = "tsFaculty"
        Me.tsFaculty.Size = New System.Drawing.Size(167, 28)
        Me.tsFaculty.Text = "FACULTY"
        '
        'panelFaculty
        '
        Me.panelFaculty.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelFaculty.Controls.Add(Me.PictureBox1)
        Me.panelFaculty.Controls.Add(Me.labelFacultyCount)
        Me.panelFaculty.Controls.Add(Me.Label3)
        Me.panelFaculty.Location = New System.Drawing.Point(139, 249)
        Me.panelFaculty.Name = "panelFaculty"
        Me.panelFaculty.Size = New System.Drawing.Size(773, 239)
        Me.panelFaculty.TabIndex = 32
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(505, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(247, 208)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'labelFacultyCount
        '
        Me.labelFacultyCount.AutoSize = True
        Me.labelFacultyCount.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelFacultyCount.ForeColor = System.Drawing.Color.Black
        Me.labelFacultyCount.Location = New System.Drawing.Point(180, 120)
        Me.labelFacultyCount.Name = "labelFacultyCount"
        Me.labelFacultyCount.Size = New System.Drawing.Size(56, 58)
        Me.labelFacultyCount.TabIndex = 37
        Me.labelFacultyCount.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(97, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 58)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "FACULTY" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 45.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(30, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(417, 72)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "DASHBOARD"
        '
        'panelGraph
        '
        Me.panelGraph.BackColor = System.Drawing.Color.SteelBlue
        Me.panelGraph.Controls.Add(Me.attendanceChart)
        Me.panelGraph.ForeColor = System.Drawing.Color.SteelBlue
        Me.panelGraph.Location = New System.Drawing.Point(130, 510)
        Me.panelGraph.Name = "panelGraph"
        Me.panelGraph.Padding = New System.Windows.Forms.Padding(10)
        Me.panelGraph.Size = New System.Drawing.Size(1600, 371)
        Me.panelGraph.TabIndex = 35
        '
        'attendanceChart
        '
        Me.attendanceChart.BorderlineColor = System.Drawing.SystemColors.ControlLight
        ChartArea1.Name = "ChartArea1"
        Me.attendanceChart.ChartAreas.Add(ChartArea1)
        Me.attendanceChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.attendanceChart.Legends.Add(Legend1)
        Me.attendanceChart.Location = New System.Drawing.Point(10, 10)
        Me.attendanceChart.Name = "attendanceChart"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.attendanceChart.Series.Add(Series1)
        Me.attendanceChart.Size = New System.Drawing.Size(1580, 351)
        Me.attendanceChart.TabIndex = 0
        Me.attendanceChart.Text = "Chart1"
        '
        'panelAttendance
        '
        Me.panelAttendance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.panelAttendance.Controls.Add(Me.PictureBox2)
        Me.panelAttendance.Controls.Add(Me.labelAttendanceCount)
        Me.panelAttendance.Controls.Add(Me.Label7)
        Me.panelAttendance.Location = New System.Drawing.Point(946, 250)
        Me.panelAttendance.Name = "panelAttendance"
        Me.panelAttendance.Size = New System.Drawing.Size(774, 237)
        Me.panelAttendance.TabIndex = 34
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources._9928186
        Me.PictureBox2.Location = New System.Drawing.Point(527, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(216, 229)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 39
        Me.PictureBox2.TabStop = False
        '
        'labelAttendanceCount
        '
        Me.labelAttendanceCount.AutoSize = True
        Me.labelAttendanceCount.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAttendanceCount.ForeColor = System.Drawing.Color.Black
        Me.labelAttendanceCount.Location = New System.Drawing.Point(219, 120)
        Me.labelAttendanceCount.Name = "labelAttendanceCount"
        Me.labelAttendanceCount.Size = New System.Drawing.Size(56, 58)
        Me.labelAttendanceCount.TabIndex = 39
        Me.labelAttendanceCount.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(74, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(351, 58)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "ATTENDANCE"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Location = New System.Drawing.Point(130, 241)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(793, 260)
        Me.Panel2.TabIndex = 36
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Panel3.Location = New System.Drawing.Point(937, 240)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(793, 258)
        Me.Panel3.TabIndex = 37
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 825)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.panelGraph)
        Me.Controls.Add(Me.labelCurrentUser)
        Me.Controls.Add(Me.panelAttendance)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.panelFaculty)
        Me.Controls.Add(Me.toolStripNav)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.toolStripNav.ResumeLayout(False)
        Me.toolStripNav.PerformLayout()
        Me.panelFaculty.ResumeLayout(False)
        Me.panelFaculty.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelGraph.ResumeLayout(False)
        CType(Me.attendanceChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelAttendance.ResumeLayout(False)
        Me.panelAttendance.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents labelCurrentUser As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Label6 As Label
    Friend WithEvents toolStripNav As ToolStrip
    Friend WithEvents tsBtnFaculty As ToolStripButton
    Friend WithEvents tsBtnAttendance As ToolStripButton
    Friend WithEvents tsReports As ToolStripMenuItem
    Friend WithEvents tsLogs As ToolStripMenuItem
    Friend WithEvents tsFaculty As ToolStripMenuItem
    Friend WithEvents panelFaculty As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents panelGraph As Panel
    Friend WithEvents panelAttendance As Panel
    Friend WithEvents labelFacultyCount As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents labelAttendanceCount As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents attendanceChart As DataVisualization.Charting.Chart
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tsManageAccounts As ToolStripButton
    Friend WithEvents tsAnnouncements As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
