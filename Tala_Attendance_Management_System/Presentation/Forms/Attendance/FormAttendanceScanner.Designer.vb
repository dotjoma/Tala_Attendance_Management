<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAttendanceScanner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAttendanceScanner))
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTagID = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panelThisAnnouncement = New System.Windows.Forms.Panel()
        Me.AnnouncementCard1 = New Tala_Attendance_Management_System.AnnouncementCard()
        Me.tmrHideCard = New System.Windows.Forms.Timer(Me.components)
        Me.pnlFacultyCard = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataSet_Attendance1 = New Tala_Attendance_Management_System.DataSet_Attendance()
        Me.DataSet_Attendance2 = New Tala_Attendance_Management_System.DataSet_Attendance()
        Me.DataSet_Attendance3 = New Tala_Attendance_Management_System.DataSet_Attendance()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.DataSet_Attendance4 = New Tala_Attendance_Management_System.DataSet_Attendance()
        Me.panelHeader.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.panelThisAnnouncement.SuspendLayout()
        Me.pnlFacultyCard.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataSet_Attendance1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Attendance2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Attendance3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Attendance4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.CornflowerBlue
        Me.panelHeader.Controls.Add(Me.Label1)
        Me.panelHeader.Controls.Add(Me.Label4)
        Me.panelHeader.Controls.Add(Me.PictureBox6)
        Me.panelHeader.Controls.Add(Me.Label2)
        Me.panelHeader.Controls.Add(Me.txtTagID)
        Me.panelHeader.Controls.Add(Me.PictureBox1)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1444, 92)
        Me.panelHeader.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(500, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(948, 39)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "TALA HIGH SCHOOL ATTENDANCE MONITORING SYSTEM "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1368, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(207, 29)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "DATE AND TIME"
        Me.Label4.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(158, 92)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 19
        Me.PictureBox6.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(769, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(459, 29)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Yakal St Bo. San Isidro Tala Caloocan City"
        '
        'txtTagID
        '
        Me.txtTagID.Location = New System.Drawing.Point(144, 64)
        Me.txtTagID.Name = "txtTagID"
        Me.txtTagID.Size = New System.Drawing.Size(211, 26)
        Me.txtTagID.TabIndex = 16
        Me.txtTagID.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1302, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 44)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Timer1
        '
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 92)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1444, 10)
        Me.Panel6.TabIndex = 11
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 798)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1444, 33)
        Me.Panel7.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Label5"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(-147, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 40)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "TAP RFID. . . ."
        Me.Label3.Visible = False
        '
        'panelThisAnnouncement
        '
        Me.panelThisAnnouncement.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelThisAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelThisAnnouncement.Controls.Add(Me.AnnouncementCard1)
        Me.panelThisAnnouncement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelThisAnnouncement.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelThisAnnouncement.Location = New System.Drawing.Point(920, 102)
        Me.panelThisAnnouncement.Name = "panelThisAnnouncement"
        Me.panelThisAnnouncement.Size = New System.Drawing.Size(524, 696)
        Me.panelThisAnnouncement.TabIndex = 6
        '
        'AnnouncementCard1
        '
        Me.AnnouncementCard1.AnnouncementImage = CType(resources.GetObject("AnnouncementCard1.AnnouncementImage"), System.Drawing.Image)
        Me.AnnouncementCard1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.AnnouncementCard1.DateInfo = "Date"
        Me.AnnouncementCard1.DayInfo = "Day"
        Me.AnnouncementCard1.Description = "Letter"
        Me.AnnouncementCard1.Header = """Header"""
        Me.AnnouncementCard1.Location = New System.Drawing.Point(-1, -1)
        Me.AnnouncementCard1.LookFor = "LookFor"
        Me.AnnouncementCard1.Margin = New System.Windows.Forms.Padding(4)
        Me.AnnouncementCard1.Name = "AnnouncementCard1"
        Me.AnnouncementCard1.Size = New System.Drawing.Size(11, 680)
        Me.AnnouncementCard1.TabIndex = 15
        Me.AnnouncementCard1.TimeInfo = "Time"
        '
        'tmrHideCard
        '
        '
        'pnlFacultyCard
        '
        Me.pnlFacultyCard.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFacultyCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFacultyCard.Controls.Add(Me.Panel1)
        Me.pnlFacultyCard.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlFacultyCard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlFacultyCard.Location = New System.Drawing.Point(0, 102)
        Me.pnlFacultyCard.MinimumSize = New System.Drawing.Size(910, 2)
        Me.pnlFacultyCard.Name = "pnlFacultyCard"
        Me.pnlFacultyCard.Size = New System.Drawing.Size(920, 696)
        Me.pnlFacultyCard.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(909, 395)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(51, 126)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(812, 225)
        Me.Panel2.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(150, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(325, 77)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "00:00:00"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(56, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(585, 77)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "MMMM-DD-YYYY"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(68, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(742, 77)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "DAILY TIME TRACKER"
        '
        'DataSet_Attendance1
        '
        Me.DataSet_Attendance1.DataSetName = "DataSet_Attendance"
        Me.DataSet_Attendance1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataSet_Attendance2
        '
        Me.DataSet_Attendance2.DataSetName = "DataSet_Attendance"
        Me.DataSet_Attendance2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataSet_Attendance3
        '
        Me.DataSet_Attendance3.DataSetName = "DataSet_Attendance"
        Me.DataSet_Attendance3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'DataSet_Attendance4
        '
        Me.DataSet_Attendance4.DataSetName = "DataSet_Attendance"
        Me.DataSet_Attendance4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FormAttendanceScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1444, 831)
        Me.Controls.Add(Me.panelThisAnnouncement)
        Me.Controls.Add(Me.pnlFacultyCard)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.panelHeader)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FormAttendanceScanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.panelThisAnnouncement.ResumeLayout(False)
        Me.pnlFacultyCard.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataSet_Attendance1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Attendance2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Attendance3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Attendance4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents panelThisAnnouncement As Panel
    Friend WithEvents tmrHideCard As Timer
    Friend WithEvents pnlFacultyCard As FlowLayoutPanel
    Friend WithEvents txtTagID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents AnnouncementCard1 As AnnouncementCard
    Friend WithEvents DataSet_Attendance1 As DataSet_Attendance
    Friend WithEvents DataSet_Attendance2 As DataSet_Attendance
    Friend WithEvents DataSet_Attendance3 As DataSet_Attendance
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Timer2 As Timer
    Friend WithEvents DataSet_Attendance4 As DataSet_Attendance
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
