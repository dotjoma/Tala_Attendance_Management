<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManageUser))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelLeftSide = New System.Windows.Forms.Panel()
        Me.panelRightSide = New System.Windows.Forms.Panel()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFilter = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.dgvManageUser = New System.Windows.Forms.DataGridView()
        Me.login_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.full_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.created_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.role = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EditBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.deleteBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.panelHeader.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelBottom.SuspendLayout()
        CType(Me.dgvManageUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelLeftSide
        '
        Me.panelLeftSide.BackColor = System.Drawing.Color.White
        Me.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeftSide.Location = New System.Drawing.Point(0, 77)
        Me.panelLeftSide.Name = "panelLeftSide"
        Me.panelLeftSide.Size = New System.Drawing.Size(331, 581)
        Me.panelLeftSide.TabIndex = 0
        '
        'panelRightSide
        '
        Me.panelRightSide.BackColor = System.Drawing.Color.White
        Me.panelRightSide.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRightSide.Location = New System.Drawing.Point(1266, 77)
        Me.panelRightSide.Name = "panelRightSide"
        Me.panelRightSide.Size = New System.Drawing.Size(331, 581)
        Me.panelRightSide.TabIndex = 1
        '
        'panelHeader
        '
        Me.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelHeader.Controls.Add(Me.PictureBox4)
        Me.panelHeader.Controls.Add(Me.Label2)
        Me.panelHeader.Controls.Add(Me.Label3)
        Me.panelHeader.Controls.Add(Me.cbFilter)
        Me.panelHeader.Controls.Add(Me.txtSearch)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(331, 77)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(935, 83)
        Me.panelHeader.TabIndex = 4
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(844, 39)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(41, 29)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 33
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(34, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 19)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Role:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(575, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 21)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Search:"
        '
        'cbFilter
        '
        Me.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilter.FormattingEnabled = True
        Me.cbFilter.Items.AddRange(New Object() {"Admin", "Teacher"})
        Me.cbFilter.Location = New System.Drawing.Point(38, 38)
        Me.cbFilter.Name = "cbFilter"
        Me.cbFilter.Size = New System.Drawing.Size(235, 29)
        Me.cbFilter.TabIndex = 30
        Me.cbFilter.Visible = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.Location = New System.Drawing.Point(644, 39)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(273, 29)
        Me.txtSearch.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(66, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "USER MANAGEMENT"
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.SteelBlue
        Me.panelBottom.Controls.Add(Me.btnDelete)
        Me.panelBottom.Controls.Add(Me.btnEdit)
        Me.panelBottom.Controls.Add(Me.btnNew)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 658)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(1597, 69)
        Me.panelBottom.TabIndex = 5
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDelete.AutoSize = True
        Me.btnDelete.BackColor = System.Drawing.Color.White
        Me.btnDelete.BackgroundImage = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_delete_40
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(874, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(160, 50)
        Me.btnDelete.TabIndex = 34
        Me.btnDelete.Text = "&Delete User"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEdit.AutoSize = True
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.BackgroundImage = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_edit_40
        Me.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnEdit.Location = New System.Drawing.Point(694, 7)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(160, 50)
        Me.btnEdit.TabIndex = 33
        Me.btnEdit.Text = "&Edit User"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNew.AutoSize = True
        Me.btnNew.BackColor = System.Drawing.Color.White
        Me.btnNew.BackgroundImage = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_plus_40
        Me.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.Green
        Me.btnNew.Location = New System.Drawing.Point(518, 7)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(160, 50)
        Me.btnNew.TabIndex = 16
        Me.btnNew.Text = "&New User"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'dgvManageUser
        '
        Me.dgvManageUser.AllowUserToAddRows = False
        Me.dgvManageUser.AllowUserToDeleteRows = False
        Me.dgvManageUser.AllowUserToResizeColumns = False
        Me.dgvManageUser.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvManageUser.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvManageUser.BackgroundColor = System.Drawing.Color.White
        Me.dgvManageUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvManageUser.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvManageUser.ColumnHeadersHeight = 70
        Me.dgvManageUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvManageUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.login_id, Me.full_name, Me.username, Me.password, Me.email, Me.locationColumn, Me.created_at, Me.role, Me.EditBtn, Me.deleteBtn})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvManageUser.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvManageUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvManageUser.EnableHeadersVisualStyles = False
        Me.dgvManageUser.Location = New System.Drawing.Point(331, 160)
        Me.dgvManageUser.MultiSelect = False
        Me.dgvManageUser.Name = "dgvManageUser"
        Me.dgvManageUser.ReadOnly = True
        Me.dgvManageUser.RowHeadersVisible = False
        Me.dgvManageUser.RowHeadersWidth = 51
        Me.dgvManageUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvManageUser.Size = New System.Drawing.Size(935, 498)
        Me.dgvManageUser.TabIndex = 21
        Me.dgvManageUser.TabStop = False
        '
        'login_id
        '
        Me.login_id.DataPropertyName = "login_id"
        Me.login_id.HeaderText = "ID"
        Me.login_id.Name = "login_id"
        Me.login_id.ReadOnly = True
        Me.login_id.Visible = False
        '
        'full_name
        '
        Me.full_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.full_name.DataPropertyName = "full_name"
        Me.full_name.HeaderText = "Full Name"
        Me.full_name.Name = "full_name"
        Me.full_name.ReadOnly = True
        '
        'username
        '
        Me.username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.username.DataPropertyName = "username"
        Me.username.HeaderText = "Username"
        Me.username.Name = "username"
        Me.username.ReadOnly = True
        '
        'password
        '
        Me.password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.password.DataPropertyName = "password"
        Me.password.HeaderText = "Password"
        Me.password.Name = "password"
        Me.password.ReadOnly = True
        Me.password.Visible = False
        '
        'email
        '
        Me.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.email.DataPropertyName = "email"
        Me.email.HeaderText = "Email Address"
        Me.email.Name = "email"
        Me.email.ReadOnly = True
        '
        'locationColumn
        '
        Me.locationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.locationColumn.DataPropertyName = "address"
        Me.locationColumn.HeaderText = "Location"
        Me.locationColumn.Name = "location"
        Me.locationColumn.ReadOnly = True
        '
        'created_at
        '
        Me.created_at.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.created_at.DataPropertyName = "created_at"
        Me.created_at.HeaderText = "Created"
        Me.created_at.Name = "created_at"
        Me.created_at.ReadOnly = True
        '
        'role
        '
        Me.role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.role.DataPropertyName = "role"
        Me.role.HeaderText = "Role"
        Me.role.Name = "role"
        Me.role.ReadOnly = True
        Me.role.Width = 64
        '
        'EditBtn
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.EditBtn.DefaultCellStyle = DataGridViewCellStyle3
        Me.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditBtn.HeaderText = "Actions"
        Me.EditBtn.Name = "EditBtn"
        Me.EditBtn.ReadOnly = True
        Me.EditBtn.Text = "Edit"
        Me.EditBtn.UseColumnTextForButtonValue = True
        Me.EditBtn.Visible = False
        '
        'deleteBtn
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.deleteBtn.DefaultCellStyle = DataGridViewCellStyle4
        Me.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteBtn.HeaderText = ""
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.ReadOnly = True
        Me.deleteBtn.Text = "Delete"
        Me.deleteBtn.UseColumnTextForButtonValue = True
        Me.deleteBtn.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1597, 77)
        Me.Panel1.TabIndex = 22
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.SteelBlue
        Me.PictureBox6.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_manage_50
        Me.PictureBox6.Location = New System.Drawing.Point(12, 17)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(51, 47)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 16
        Me.PictureBox6.TabStop = False
        '
        'ManageUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1597, 727)
        Me.Controls.Add(Me.dgvManageUser)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.panelRightSide)
        Me.Controls.Add(Me.panelLeftSide)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelBottom)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ManageUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManageUser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelBottom.ResumeLayout(False)
        Me.panelBottom.PerformLayout()
        CType(Me.dgvManageUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelLeftSide As Panel
    Friend WithEvents panelRightSide As Panel
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelBottom As Panel
    Public WithEvents dgvManageUser As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbFilter As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents login_id As DataGridViewTextBoxColumn
    Friend WithEvents full_name As DataGridViewTextBoxColumn
    Friend WithEvents username As DataGridViewTextBoxColumn
    Friend WithEvents password As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents locationColumn As DataGridViewTextBoxColumn
    Friend WithEvents created_at As DataGridViewTextBoxColumn
    Friend WithEvents role As DataGridViewTextBoxColumn
    Friend WithEvents EditBtn As DataGridViewButtonColumn
    Friend WithEvents deleteBtn As DataGridViewButtonColumn
    Friend WithEvents btnNew As Button
End Class