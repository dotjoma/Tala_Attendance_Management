<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnnouncement
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAnnouncement))
        Me.dgvAnnouncement = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnDeleteRecord = New System.Windows.Forms.Button()
        Me.btnEditRecord = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.header = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dayInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timeInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgvAnnouncement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAnnouncement
        '
        Me.dgvAnnouncement.AllowUserToAddRows = False
        Me.dgvAnnouncement.AllowUserToDeleteRows = False
        Me.dgvAnnouncement.AllowUserToResizeColumns = False
        Me.dgvAnnouncement.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAnnouncement.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAnnouncement.BackgroundColor = System.Drawing.Color.White
        Me.dgvAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAnnouncement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAnnouncement.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAnnouncement.ColumnHeadersHeight = 50
        Me.dgvAnnouncement.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.header, Me.description, Me.dayInfo, Me.timeInfo, Me.Column1, Me.Column2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAnnouncement.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAnnouncement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAnnouncement.EnableHeadersVisualStyles = False
        Me.dgvAnnouncement.Location = New System.Drawing.Point(0, 60)
        Me.dgvAnnouncement.MultiSelect = False
        Me.dgvAnnouncement.Name = "dgvAnnouncement"
        Me.dgvAnnouncement.ReadOnly = True
        Me.dgvAnnouncement.RowHeadersVisible = False
        Me.dgvAnnouncement.RowHeadersWidth = 51
        Me.dgvAnnouncement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAnnouncement.Size = New System.Drawing.Size(1724, 399)
        Me.dgvAnnouncement.TabIndex = 19
        Me.dgvAnnouncement.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.btnDeleteRecord)
        Me.Panel1.Controls.Add(Me.btnEditRecord)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 459)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1724, 69)
        Me.Panel1.TabIndex = 18
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(375, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(190, 9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(72, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, 9)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(55, 50)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'btnDeleteRecord
        '
        Me.btnDeleteRecord.AutoSize = True
        Me.btnDeleteRecord.BackColor = System.Drawing.Color.Crimson
        Me.btnDeleteRecord.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteRecord.FlatAppearance.BorderSize = 0
        Me.btnDeleteRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteRecord.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteRecord.ForeColor = System.Drawing.Color.White
        Me.btnDeleteRecord.Location = New System.Drawing.Point(444, 9)
        Me.btnDeleteRecord.Name = "btnDeleteRecord"
        Me.btnDeleteRecord.Size = New System.Drawing.Size(107, 50)
        Me.btnDeleteRecord.TabIndex = 2
        Me.btnDeleteRecord.Text = "&Delete Record"
        Me.btnDeleteRecord.UseVisualStyleBackColor = False
        '
        'btnEditRecord
        '
        Me.btnEditRecord.AutoSize = True
        Me.btnEditRecord.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnEditRecord.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditRecord.FlatAppearance.BorderSize = 0
        Me.btnEditRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditRecord.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditRecord.ForeColor = System.Drawing.Color.White
        Me.btnEditRecord.Location = New System.Drawing.Point(266, 9)
        Me.btnEditRecord.Name = "btnEditRecord"
        Me.btnEditRecord.Size = New System.Drawing.Size(101, 50)
        Me.btnEditRecord.TabIndex = 1
        Me.btnEditRecord.Text = "&Edit Record"
        Me.btnEditRecord.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = True
        Me.btnAdd.BackColor = System.Drawing.Color.SeaGreen
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(64, 9)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 50)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&Add New"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1724, 60)
        Me.Panel2.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(312, 45)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ANNOUNCEMENTS"
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'header
        '
        Me.header.DataPropertyName = "Header"
        Me.header.HeaderText = "Header"
        Me.header.Name = "header"
        Me.header.ReadOnly = True
        Me.header.Width = 200
        '
        'description
        '
        Me.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.description.DataPropertyName = "description"
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'dayInfo
        '
        Me.dayInfo.DataPropertyName = "dayInfo"
        Me.dayInfo.HeaderText = "Date"
        Me.dayInfo.Name = "dayInfo"
        Me.dayInfo.ReadOnly = True
        Me.dayInfo.Width = 150
        '
        'timeInfo
        '
        Me.timeInfo.DataPropertyName = "timeInfo"
        Me.timeInfo.HeaderText = "Time"
        Me.timeInfo.Name = "timeInfo"
        Me.timeInfo.ReadOnly = True
        Me.timeInfo.Width = 150
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "lookFor"
        Me.Column1.HeaderText = "Contact Person"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "pictureHeader"
        Me.Column2.HeaderText = "Background Image"
        Me.Column2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'FormAnnouncement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1724, 528)
        Me.Controls.Add(Me.dgvAnnouncement)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormAnnouncement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAnnouncement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvAnnouncement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents dgvAnnouncement As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnDeleteRecord As Button
    Friend WithEvents btnEditRecord As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents header As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents dayInfo As DataGridViewTextBoxColumn
    Friend WithEvents timeInfo As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewImageColumn
End Class
