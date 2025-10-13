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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelCurrentUser = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.msExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.toolStripNav.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1444, 0)
        Me.Panel1.TabIndex = 11
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
        Me.Panel5.Controls.Add(Me.lblUser)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 712)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1444, 45)
        Me.Panel5.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calisto MT", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(268, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(908, 31)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Tala High School Yakal St. Bo San Isidro, Tala Caloocan City, Philippines"
        '
        'toolStripNav
        '
        Me.toolStripNav.BackColor = System.Drawing.SystemColors.ControlLight
        Me.toolStripNav.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolStripNav.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsBtnFaculty, Me.ToolStripSeparator2, Me.tsBtnAttendance, Me.ToolStripSeparator1, Me.tsManageAccounts, Me.ToolStripSeparator3, Me.tsAnnouncements, Me.ToolStripSeparator4, Me.tsReports})
        Me.toolStripNav.Location = New System.Drawing.Point(0, 24)
        Me.toolStripNav.Name = "toolStripNav"
        Me.toolStripNav.Size = New System.Drawing.Size(1444, 92)
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
        Me.tsLogs.Size = New System.Drawing.Size(180, 28)
        Me.tsLogs.Text = "LOGS"
        '
        'tsFaculty
        '
        Me.tsFaculty.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_cog_48
        Me.tsFaculty.Name = "tsFaculty"
        Me.tsFaculty.Size = New System.Drawing.Size(180, 28)
        Me.tsFaculty.Text = "FACULTY"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 116)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 607.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1444, 596)
        Me.TableLayoutPanel1.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1438, 590)
        Me.Panel2.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources._104274389_103234301447836_7116776018632507257_n1
        Me.PictureBox1.Location = New System.Drawing.Point(419, -5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(600, 600)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1444, 24)
        Me.MenuStrip1.TabIndex = 33
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msLogout, Me.msExit})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'msLogout
        '
        Me.msLogout.Name = "msLogout"
        Me.msLogout.Size = New System.Drawing.Size(180, 22)
        Me.msLogout.Text = "Logout"
        '
        'msExit
        '
        Me.msExit.Name = "msExit"
        Me.msExit.Size = New System.Drawing.Size(180, 22)
        Me.msExit.Text = "Exit"
        '
        'lblUser
        '
        Me.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblUser.Location = New System.Drawing.Point(1, 14)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(221, 16)
        Me.lblUser.TabIndex = 16
        Me.lblUser.Text = "Logged in as: Mark Eliot (Admin)"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1444, 757)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.labelCurrentUser)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toolStripNav)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.toolStripNav.ResumeLayout(False)
        Me.toolStripNav.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents labelCurrentUser As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents toolStripNav As ToolStrip
    Friend WithEvents tsBtnFaculty As ToolStripButton
    Friend WithEvents tsBtnAttendance As ToolStripButton
    Friend WithEvents tsReports As ToolStripMenuItem
    Friend WithEvents tsLogs As ToolStripMenuItem
    Friend WithEvents tsFaculty As ToolStripMenuItem
    Friend WithEvents tsManageAccounts As ToolStripButton
    Friend WithEvents tsAnnouncements As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents msLogout As ToolStripMenuItem
    Friend WithEvents msExit As ToolStripMenuItem
    Friend WithEvents lblUser As Label
End Class
