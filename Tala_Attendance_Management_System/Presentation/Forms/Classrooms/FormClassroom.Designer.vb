<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassroom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormClassroom))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.LabelHome = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panelLeftSide = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelRightSide = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvClassrooms = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classroom_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classroom_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.editBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.deleteBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.panelHeader.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvClassrooms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.Gainsboro
        Me.panelHeader.Controls.Add(Me.PictureBox5)
        Me.panelHeader.Controls.Add(Me.PictureBox4)
        Me.panelHeader.Controls.Add(Me.LabelHome)
        Me.panelHeader.Controls.Add(Me.txtSearch)
        Me.panelHeader.Controls.Add(Me.Label3)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1444, 72)
        Me.panelHeader.TabIndex = 20
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_classroom_50
        Me.PictureBox5.Location = New System.Drawing.Point(12, 18)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(50, 36)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 29
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1210, 30)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(41, 29)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 28
        Me.PictureBox4.TabStop = False
        '
        'LabelHome
        '
        Me.LabelHome.AutoSize = True
        Me.LabelHome.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHome.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelHome.Location = New System.Drawing.Point(68, 13)
        Me.LabelHome.Name = "LabelHome"
        Me.LabelHome.Size = New System.Drawing.Size(234, 45)
        Me.LabelHome.TabIndex = 20
        Me.LabelHome.Text = "CLASSROOMS"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(861, 30)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(250, 29)
        Me.txtSearch.TabIndex = 4
        Me.txtSearch.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(785, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "SEARCH:"
        '
        'panelLeftSide
        '
        Me.panelLeftSide.BackColor = System.Drawing.Color.White
        Me.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeftSide.Location = New System.Drawing.Point(0, 72)
        Me.panelLeftSide.Name = "panelLeftSide"
        Me.panelLeftSide.Size = New System.Drawing.Size(333, 634)
        Me.panelLeftSide.TabIndex = 21
        '
        'btnNew
        '
        Me.btnNew.AutoSize = True
        Me.btnNew.BackColor = System.Drawing.Color.SeaGreen
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.White
        Me.btnNew.Location = New System.Drawing.Point(444, 18)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(250, 43)
        Me.btnNew.TabIndex = 12
        Me.btnNew.TabStop = False
        Me.btnNew.Text = "Create &New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(333, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(111, 634)
        Me.Panel1.TabIndex = 22
        '
        'panelRightSide
        '
        Me.panelRightSide.BackColor = System.Drawing.Color.White
        Me.panelRightSide.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRightSide.Location = New System.Drawing.Point(1111, 72)
        Me.panelRightSide.Name = "panelRightSide"
        Me.panelRightSide.Size = New System.Drawing.Size(333, 634)
        Me.panelRightSide.TabIndex = 23
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1000, 72)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(111, 634)
        Me.Panel2.TabIndex = 24
        '
        'dgvClassrooms
        '
        Me.dgvClassrooms.AllowUserToAddRows = False
        Me.dgvClassrooms.AllowUserToDeleteRows = False
        Me.dgvClassrooms.AllowUserToResizeColumns = False
        Me.dgvClassrooms.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvClassrooms.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvClassrooms.BackgroundColor = System.Drawing.Color.White
        Me.dgvClassrooms.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClassrooms.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvClassrooms.ColumnHeadersHeight = 70
        Me.dgvClassrooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvClassrooms.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.classroom_id, Me.location, Me.classroom_name, Me.editBtn, Me.deleteBtn})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClassrooms.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvClassrooms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClassrooms.EnableHeadersVisualStyles = False
        Me.dgvClassrooms.Location = New System.Drawing.Point(444, 72)
        Me.dgvClassrooms.MultiSelect = False
        Me.dgvClassrooms.Name = "dgvClassrooms"
        Me.dgvClassrooms.ReadOnly = True
        Me.dgvClassrooms.RowHeadersVisible = False
        Me.dgvClassrooms.RowHeadersWidth = 51
        Me.dgvClassrooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClassrooms.Size = New System.Drawing.Size(556, 634)
        Me.dgvClassrooms.TabIndex = 25
        Me.dgvClassrooms.TabStop = False
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'classroom_id
        '
        Me.classroom_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.classroom_id.DataPropertyName = "classroom_id"
        Me.classroom_id.HeaderText = "Device ID"
        Me.classroom_id.Name = "classroom_id"
        Me.classroom_id.ReadOnly = True
        Me.classroom_id.Width = 90
        '
        'location
        '
        Me.location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.location.DataPropertyName = "location"
        Me.location.HeaderText = "Location"
        Me.location.Name = "location"
        Me.location.ReadOnly = True
        '
        'classroom_name
        '
        Me.classroom_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.classroom_name.DataPropertyName = "classroom_name"
        Me.classroom_name.HeaderText = "Room Name"
        Me.classroom_name.Name = "classroom_name"
        Me.classroom_name.ReadOnly = True
        '
        'editBtn
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.editBtn.DefaultCellStyle = DataGridViewCellStyle3
        Me.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editBtn.HeaderText = "Actions"
        Me.editBtn.Name = "editBtn"
        Me.editBtn.ReadOnly = True
        Me.editBtn.Text = "Edit"
        Me.editBtn.UseColumnTextForButtonValue = True
        '
        'deleteBtn
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
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
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.btnNew)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 706)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1444, 73)
        Me.Panel3.TabIndex = 27
        '
        'FormClassroom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 779)
        Me.Controls.Add(Me.dgvClassrooms)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.panelRightSide)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelLeftSide)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormClassroom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormClassroom"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvClassrooms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelLeftSide As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelRightSide As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnNew As Button
    Public WithEvents dgvClassrooms As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents classroom_id As DataGridViewTextBoxColumn
    Friend WithEvents locationColumn As DataGridViewTextBoxColumn
    Friend WithEvents classroom_name As DataGridViewTextBoxColumn
    Friend WithEvents editBtn As DataGridViewButtonColumn
    Friend WithEvents deleteBtn As DataGridViewButtonColumn
    Friend WithEvents LabelHome As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend Shadows WithEvents location As DataGridViewTextBoxColumn
End Class