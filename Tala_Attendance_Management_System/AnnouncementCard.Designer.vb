<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnouncementCard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtHeader = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.Label()
        Me.txtDay = New System.Windows.Forms.Label()
        Me.txtLookFor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbAnnouncement = New System.Windows.Forms.PictureBox()
        CType(Me.pbAnnouncement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtHeader
        '
        Me.txtHeader.AutoSize = True
        Me.txtHeader.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeader.Location = New System.Drawing.Point(3, 3)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(189, 45)
        Me.txtHeader.TabIndex = 8
        Me.txtHeader.Text = """Header"""
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescription.Enabled = False
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.Location = New System.Drawing.Point(24, 144)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(711, 126)
        Me.txtDescription.TabIndex = 9
        Me.txtDescription.Text = "Letter"
        '
        'txtDate
        '
        Me.txtDate.AutoSize = True
        Me.txtDate.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDate.Location = New System.Drawing.Point(28, 109)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(78, 33)
        Me.txtDate.TabIndex = 10
        Me.txtDate.Text = "Date"
        '
        'txtTime
        '
        Me.txtTime.AutoSize = True
        Me.txtTime.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.Location = New System.Drawing.Point(321, 80)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(82, 33)
        Me.txtTime.TabIndex = 11
        Me.txtTime.Text = "Time"
        '
        'txtDay
        '
        Me.txtDay.AutoSize = True
        Me.txtDay.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDay.Location = New System.Drawing.Point(28, 80)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(67, 33)
        Me.txtDay.TabIndex = 12
        Me.txtDay.Text = "Day"
        '
        'txtLookFor
        '
        Me.txtLookFor.AutoSize = True
        Me.txtLookFor.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLookFor.Location = New System.Drawing.Point(28, 48)
        Me.txtLookFor.Name = "txtLookFor"
        Me.txtLookFor.Size = New System.Drawing.Size(125, 33)
        Me.txtLookFor.TabIndex = 13
        Me.txtLookFor.Text = "LookFor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe Script", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(284, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(442, 80)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Announcement!"
        Me.Label1.Visible = False
        '
        'pbAnnouncement
        '
        Me.pbAnnouncement.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.default_image
        Me.pbAnnouncement.Location = New System.Drawing.Point(23, 291)
        Me.pbAnnouncement.Name = "pbAnnouncement"
        Me.pbAnnouncement.Size = New System.Drawing.Size(712, 372)
        Me.pbAnnouncement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbAnnouncement.TabIndex = 7
        Me.pbAnnouncement.TabStop = False
        '
        'AnnouncementCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Controls.Add(Me.txtHeader)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLookFor)
        Me.Controls.Add(Me.txtDay)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.pbAnnouncement)
        Me.Name = "AnnouncementCard"
        Me.Size = New System.Drawing.Size(803, 696)
        CType(Me.pbAnnouncement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbAnnouncement As PictureBox
    Friend WithEvents txtHeader As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtDate As Label
    Friend WithEvents txtTime As Label
    Friend WithEvents txtDay As Label
    Friend WithEvents txtLookFor As Label
    Friend WithEvents Label1 As Label
End Class
