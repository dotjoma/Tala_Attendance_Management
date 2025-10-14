<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TeacherSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TeacherSchedule))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.panelContainer = New System.Windows.Forms.Panel()
        Me.updateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtDay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rightSidePanel = New System.Windows.Forms.Panel()
        Me.leftSidePanel = New System.Windows.Forms.Panel()
        Me.btnClassSchedule = New System.Windows.Forms.Button()
        Me.btnAttendanceReports = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnUploadProfile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelTeacherName = New System.Windows.Forms.Label()
        Me.pbProfile = New System.Windows.Forms.PictureBox()
        Me.btnAttendance = New System.Windows.Forms.Button()
        Me.btnMyStudents = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.leftSidePanel.SuspendLayout()
        CType(Me.pbProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.btnLogout)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1444, 101)
        Me.Panel2.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_graph_96
        Me.PictureBox1.Location = New System.Drawing.Point(50, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 69)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(-97, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(510, 30)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "TALA HIGH SCHOOL ATTENDANCE MONITORING "
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(32, 10)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(5, 81)
        Me.Panel4.TabIndex = 30
        '
        'btnLogout
        '
        Me.btnLogout.AutoSize = True
        Me.btnLogout.BackColor = System.Drawing.Color.Crimson
        Me.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(1785, 30)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(120, 40)
        Me.btnLogout.TabIndex = 20
        Me.btnLogout.Text = "Log Out"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1431, 10)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(13, 81)
        Me.Panel3.TabIndex = 29
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel9.Location = New System.Drawing.Point(27, 10)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(5, 81)
        Me.Panel9.TabIndex = 28
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(22, 10)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(5, 81)
        Me.Panel8.TabIndex = 27
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(22, 91)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1422, 10)
        Me.Panel7.TabIndex = 24
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(22, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1422, 10)
        Me.Panel6.TabIndex = 23
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(22, 101)
        Me.Panel5.TabIndex = 22
        '
        'panelContainer
        '
        Me.panelContainer.BackColor = System.Drawing.Color.White
        Me.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContainer.Location = New System.Drawing.Point(368, 101)
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Size = New System.Drawing.Size(757, 660)
        Me.panelContainer.TabIndex = 20
        '
        'updateTimer
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.txtDate, Me.ToolStripStatusLabel2, Me.txtTime, Me.ToolStripStatusLabel4, Me.txtDay})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1442, 67)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(55, 62)
        Me.ToolStripStatusLabel1.Text = "Date:"
        '
        'txtDate
        '
        Me.txtDate.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(48, 62)
        Me.txtDate.Text = "Null"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(57, 62)
        Me.ToolStripStatusLabel2.Text = "Time:"
        '
        'txtTime
        '
        Me.txtTime.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(48, 62)
        Me.txtTime.Text = "Null"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(48, 62)
        Me.ToolStripStatusLabel4.Text = "Day:"
        '
        'txtDay
        '
        Me.txtDay.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDay.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(48, 62)
        Me.txtDay.Text = "Null"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 761)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1444, 69)
        Me.Panel1.TabIndex = 16
        '
        'rightSidePanel
        '
        Me.rightSidePanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rightSidePanel.BackgroundImage = Global.Tala_Attendance_Management_System.My.Resources.Resources.Screenshot_2025_01_05_224517
        Me.rightSidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.rightSidePanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightSidePanel.Location = New System.Drawing.Point(1125, 101)
        Me.rightSidePanel.Name = "rightSidePanel"
        Me.rightSidePanel.Size = New System.Drawing.Size(319, 660)
        Me.rightSidePanel.TabIndex = 19
        '
        'leftSidePanel
        '
        Me.leftSidePanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.leftSidePanel.BackgroundImage = Global.Tala_Attendance_Management_System.My.Resources.Resources.Screenshot_2025_01_05_224618
        Me.leftSidePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.leftSidePanel.Controls.Add(Me.btnClassSchedule)
        Me.leftSidePanel.Controls.Add(Me.btnAttendanceReports)
        Me.leftSidePanel.Controls.Add(Me.btnSettings)
        Me.leftSidePanel.Controls.Add(Me.btnUploadProfile)
        Me.leftSidePanel.Controls.Add(Me.Label1)
        Me.leftSidePanel.Controls.Add(Me.labelTeacherName)
        Me.leftSidePanel.Controls.Add(Me.pbProfile)
        Me.leftSidePanel.Controls.Add(Me.btnAttendance)
        Me.leftSidePanel.Controls.Add(Me.btnMyStudents)
        Me.leftSidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftSidePanel.Location = New System.Drawing.Point(0, 101)
        Me.leftSidePanel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.leftSidePanel.Name = "leftSidePanel"
        Me.leftSidePanel.Size = New System.Drawing.Size(368, 660)
        Me.leftSidePanel.TabIndex = 18
        '
        'btnClassSchedule
        '
        Me.btnClassSchedule.AutoSize = True
        Me.btnClassSchedule.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnClassSchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClassSchedule.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClassSchedule.FlatAppearance.BorderSize = 0
        Me.btnClassSchedule.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClassSchedule.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnClassSchedule.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClassSchedule.Location = New System.Drawing.Point(50, 304)
        Me.btnClassSchedule.Name = "btnClassSchedule"
        Me.btnClassSchedule.Size = New System.Drawing.Size(250, 50)
        Me.btnClassSchedule.TabIndex = 3
        Me.btnClassSchedule.Text = "Class Schedule"
        Me.btnClassSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClassSchedule.UseVisualStyleBackColor = False
        '
        'btnAttendanceReports
        '
        Me.btnAttendanceReports.AutoSize = True
        Me.btnAttendanceReports.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAttendanceReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAttendanceReports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAttendanceReports.FlatAppearance.BorderSize = 0
        Me.btnAttendanceReports.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttendanceReports.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnAttendanceReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAttendanceReports.Location = New System.Drawing.Point(50, 508)
        Me.btnAttendanceReports.Name = "btnAttendanceReports"
        Me.btnAttendanceReports.Size = New System.Drawing.Size(250, 50)
        Me.btnAttendanceReports.TabIndex = 31
        Me.btnAttendanceReports.Text = "Attendance Reports"
        Me.btnAttendanceReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAttendanceReports.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.AutoSize = True
        Me.btnSettings.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.DimGray
        Me.btnSettings.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.gears
        Me.btnSettings.Location = New System.Drawing.Point(274, 238)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(48, 48)
        Me.btnSettings.TabIndex = 23
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnUploadProfile
        '
        Me.btnUploadProfile.AutoSize = True
        Me.btnUploadProfile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnUploadProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUploadProfile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUploadProfile.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadProfile.ForeColor = System.Drawing.Color.DimGray
        Me.btnUploadProfile.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.image
        Me.btnUploadProfile.Location = New System.Drawing.Point(220, 238)
        Me.btnUploadProfile.Name = "btnUploadProfile"
        Me.btnUploadProfile.Size = New System.Drawing.Size(48, 48)
        Me.btnUploadProfile.TabIndex = 22
        Me.btnUploadProfile.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(29, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 21)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Hello,"
        '
        'labelTeacherName
        '
        Me.labelTeacherName.AutoSize = True
        Me.labelTeacherName.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTeacherName.ForeColor = System.Drawing.Color.SteelBlue
        Me.labelTeacherName.Location = New System.Drawing.Point(58, 261)
        Me.labelTeacherName.Name = "labelTeacherName"
        Me.labelTeacherName.Size = New System.Drawing.Size(105, 25)
        Me.labelTeacherName.TabIndex = 18
        Me.labelTeacherName.Text = "Guess User"
        '
        'pbProfile
        '
        Me.pbProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbProfile.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.download
        Me.pbProfile.Location = New System.Drawing.Point(50, 24)
        Me.pbProfile.Name = "pbProfile"
        Me.pbProfile.Size = New System.Drawing.Size(237, 196)
        Me.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbProfile.TabIndex = 4
        Me.pbProfile.TabStop = False
        '
        'btnAttendance
        '
        Me.btnAttendance.AutoSize = True
        Me.btnAttendance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAttendance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAttendance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAttendance.FlatAppearance.BorderSize = 0
        Me.btnAttendance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttendance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnAttendance.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAttendance.Location = New System.Drawing.Point(50, 436)
        Me.btnAttendance.Name = "btnAttendance"
        Me.btnAttendance.Size = New System.Drawing.Size(250, 50)
        Me.btnAttendance.TabIndex = 1
        Me.btnAttendance.Text = "Daily Attendance"
        Me.btnAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAttendance.UseVisualStyleBackColor = False
        '
        'btnMyStudents
        '
        Me.btnMyStudents.AutoSize = True
        Me.btnMyStudents.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnMyStudents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMyStudents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMyStudents.FlatAppearance.BorderSize = 0
        Me.btnMyStudents.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMyStudents.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnMyStudents.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMyStudents.Location = New System.Drawing.Point(50, 370)
        Me.btnMyStudents.Name = "btnMyStudents"
        Me.btnMyStudents.Size = New System.Drawing.Size(250, 50)
        Me.btnMyStudents.TabIndex = 21
        Me.btnMyStudents.Text = "My Students"
        Me.btnMyStudents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMyStudents.UseVisualStyleBackColor = False
        '
        'TeacherSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 830)
        Me.Controls.Add(Me.panelContainer)
        Me.Controls.Add(Me.rightSidePanel)
        Me.Controls.Add(Me.leftSidePanel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "TeacherSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Teacher Schedule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.leftSidePanel.ResumeLayout(False)
        Me.leftSidePanel.PerformLayout()
        CType(Me.pbProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents leftSidePanel As Panel
    Friend WithEvents rightSidePanel As Panel
    Friend WithEvents btnAttendance As Button
    Friend WithEvents panelContainer As Panel
    Friend WithEvents btnClassSchedule As Button
    Friend WithEvents pbProfile As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents labelTeacherName As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnMyStudents As Button
    Friend WithEvents btnUploadProfile As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents updateTimer As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents txtDate As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents txtTime As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents txtDay As ToolStripStatusLabel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnAttendanceReports As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
