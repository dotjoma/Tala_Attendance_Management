<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddAnnouncement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddAnnouncement))
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.panelContainer = New System.Windows.Forms.Panel()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.dtpDateInfo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTimeInfo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.pbHeader = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.panelHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelContainer.SuspendLayout()
        CType(Me.pbHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.panelHeader.Controls.Add(Me.Label9)
        Me.panelHeader.Controls.Add(Me.Label25)
        Me.panelHeader.Controls.Add(Me.txtID)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(842, 67)
        Me.panelHeader.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(7, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(428, 45)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "ANNOUNCEMENT DETAILS"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(750, 29)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 25)
        Me.Label25.TabIndex = 22
        Me.Label25.Text = "ID:"
        Me.Label25.Visible = False
        '
        'txtID
        '
        Me.txtID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtID.AutoSize = True
        Me.txtID.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(787, 29)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(23, 25)
        Me.txtID.TabIndex = 23
        Me.txtID.Text = "0"
        Me.txtID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 453)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(842, 78)
        Me.Panel1.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(657, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(56, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 74
        Me.PictureBox1.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.AutoSize = True
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(715, 26)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 33)
        Me.btnSave.TabIndex = 1
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(492, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(51, 33)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 75
        Me.PictureBox2.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(545, 26)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 33)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'panelContainer
        '
        Me.panelContainer.Controls.Add(Me.btnBrowse)
        Me.panelContainer.Controls.Add(Me.Label5)
        Me.panelContainer.Controls.Add(Me.Label4)
        Me.panelContainer.Controls.Add(Me.txtContactPerson)
        Me.panelContainer.Controls.Add(Me.dtpDateInfo)
        Me.panelContainer.Controls.Add(Me.Label3)
        Me.panelContainer.Controls.Add(Me.txtTimeInfo)
        Me.panelContainer.Controls.Add(Me.Label2)
        Me.panelContainer.Controls.Add(Me.txtDescription)
        Me.panelContainer.Controls.Add(Me.pbHeader)
        Me.panelContainer.Controls.Add(Me.Label1)
        Me.panelContainer.Controls.Add(Me.txtHeader)
        Me.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContainer.Location = New System.Drawing.Point(0, 67)
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Size = New System.Drawing.Size(842, 386)
        Me.panelContainer.TabIndex = 11
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.White
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnBrowse.Location = New System.Drawing.Point(613, 272)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(197, 33)
        Me.btnBrowse.TabIndex = 240
        Me.btnBrowse.TabStop = False
        Me.btnBrowse.Text = "   Browse Image"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(321, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 21)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(321, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 21)
        Me.Label4.TabIndex = 238
        Me.Label4.Text = "Contact Person"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactPerson.Location = New System.Drawing.Point(325, 280)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(268, 25)
        Me.txtContactPerson.TabIndex = 237
        '
        'dtpDateInfo
        '
        Me.dtpDateInfo.CustomFormat = "yyyy-MM-dd"
        Me.dtpDateInfo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateInfo.Location = New System.Drawing.Point(325, 98)
        Me.dtpDateInfo.Name = "dtpDateInfo"
        Me.dtpDateInfo.Size = New System.Drawing.Size(268, 25)
        Me.dtpDateInfo.TabIndex = 236
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 21)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "Time"
        '
        'txtTimeInfo
        '
        Me.txtTimeInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTimeInfo.Location = New System.Drawing.Point(34, 280)
        Me.txtTimeInfo.Name = "txtTimeInfo"
        Me.txtTimeInfo.Size = New System.Drawing.Size(285, 25)
        Me.txtTimeInfo.TabIndex = 234
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 21)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(34, 159)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(559, 82)
        Me.txtDescription.TabIndex = 232
        '
        'pbHeader
        '
        Me.pbHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbHeader.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.default_image
        Me.pbHeader.Location = New System.Drawing.Point(613, 98)
        Me.pbHeader.Name = "pbHeader"
        Me.pbHeader.Size = New System.Drawing.Size(198, 143)
        Me.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbHeader.TabIndex = 231
        Me.pbHeader.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 21)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Header"
        '
        'txtHeader
        '
        Me.txtHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeader.Location = New System.Drawing.Point(34, 98)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(285, 25)
        Me.txtHeader.TabIndex = 229
        '
        'AddAnnouncement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(842, 531)
        Me.Controls.Add(Me.panelContainer)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AddAnnouncement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddAnnouncement"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelContainer.ResumeLayout(False)
        Me.panelContainer.PerformLayout()
        CType(Me.pbHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnSave As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents panelContainer As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnBrowse As Button
    Public WithEvents txtContactPerson As TextBox
    Public WithEvents dtpDateInfo As DateTimePicker
    Public WithEvents txtTimeInfo As TextBox
    Public WithEvents txtDescription As TextBox
    Public WithEvents pbHeader As PictureBox
    Public WithEvents txtHeader As TextBox
    Public WithEvents txtID As Label
End Class
