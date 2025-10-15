<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
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
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.Label()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.panelContainer = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboUserRole = New System.Windows.Forms.ComboBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelHeader.SuspendLayout()
        Me.panelBottom.SuspendLayout()
        Me.panelContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.panelHeader.Controls.Add(Me.Label5)
        Me.panelHeader.Controls.Add(Me.txtID)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(517, 73)
        Me.panelHeader.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(209, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 25)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Add User"
        '
        'txtID
        '
        Me.txtID.AutoSize = True
        Me.txtID.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.DimGray
        Me.txtID.Location = New System.Drawing.Point(6, 27)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(17, 19)
        Me.txtID.TabIndex = 39
        Me.txtID.Text = "0"
        Me.txtID.Visible = False
        '
        'panelBottom
        '
        Me.panelBottom.Controls.Add(Me.btnCancel)
        Me.panelBottom.Controls.Add(Me.btnSave)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 447)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(517, 68)
        Me.panelBottom.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.BackgroundImage = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_delete_40__1_
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Location = New System.Drawing.Point(261, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(171, 40)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.AutoSize = True
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.BackgroundImage = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_plus_40
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Green
        Me.btnSave.Location = New System.Drawing.Point(77, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(171, 40)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'panelContainer
        '
        Me.panelContainer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelContainer.Controls.Add(Me.Label7)
        Me.panelContainer.Controls.Add(Me.cboUserRole)
        Me.panelContainer.Controls.Add(Me.txtAddress)
        Me.panelContainer.Controls.Add(Me.Label4)
        Me.panelContainer.Controls.Add(Me.txtEmail)
        Me.panelContainer.Controls.Add(Me.Label3)
        Me.panelContainer.Controls.Add(Me.txtName)
        Me.panelContainer.Controls.Add(Me.Label6)
        Me.panelContainer.Controls.Add(Me.chkShowPassword)
        Me.panelContainer.Controls.Add(Me.btnGenerate)
        Me.panelContainer.Controls.Add(Me.txtPassword)
        Me.panelContainer.Controls.Add(Me.Label2)
        Me.panelContainer.Controls.Add(Me.txtUsername)
        Me.panelContainer.Controls.Add(Me.Label1)
        Me.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContainer.Location = New System.Drawing.Point(0, 73)
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Size = New System.Drawing.Size(517, 374)
        Me.panelContainer.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(50, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 19)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "User Role:"
        '
        'cboUserRole
        '
        Me.cboUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserRole.FormattingEnabled = True
        Me.cboUserRole.Items.AddRange(New Object() {"Hr", "Admin"})
        Me.cboUserRole.Location = New System.Drawing.Point(128, 236)
        Me.cboUserRole.Name = "cboUserRole"
        Me.cboUserRole.Size = New System.Drawing.Size(138, 29)
        Me.cboUserRole.TabIndex = 48
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.ForeColor = System.Drawing.Color.DimGray
        Me.txtAddress.Location = New System.Drawing.Point(128, 134)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(268, 29)
        Me.txtAddress.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(61, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 19)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Address:"
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.Color.DimGray
        Me.txtEmail.Location = New System.Drawing.Point(128, 83)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(268, 29)
        Me.txtEmail.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(76, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 19)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Email:"
        '
        'txtName
        '
        Me.txtName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.DimGray
        Me.txtName.Location = New System.Drawing.Point(128, 32)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(268, 29)
        Me.txtName.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(73, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 19)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Name:"
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowPassword.Location = New System.Drawing.Point(128, 326)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(58, 21)
        Me.chkShowPassword.TabIndex = 41
        Me.chkShowPassword.Text = "Show"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.AutoSize = True
        Me.btnGenerate.BackColor = System.Drawing.Color.White
        Me.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnGenerate.Location = New System.Drawing.Point(402, 287)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(66, 29)
        Me.btnGenerate.TabIndex = 18
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.DimGray
        Me.txtPassword.Location = New System.Drawing.Point(128, 287)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(268, 29)
        Me.txtPassword.TabIndex = 33
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(51, 291)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 19)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.DimGray
        Me.txtUsername.Location = New System.Drawing.Point(128, 185)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(268, 29)
        Me.txtUsername.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(48, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 19)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Username:"
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(517, 515)
        Me.Controls.Add(Me.panelContainer)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "AddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add User"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelBottom.ResumeLayout(False)
        Me.panelBottom.PerformLayout()
        Me.panelContainer.ResumeLayout(False)
        Me.panelContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelBottom As Panel
    Friend WithEvents panelContainer As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnGenerate As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtID As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboUserRole As ComboBox
    Friend WithEvents Label7 As Label
End Class
