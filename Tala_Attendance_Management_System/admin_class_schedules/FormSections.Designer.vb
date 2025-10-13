<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSections
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.leftSidePanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbYearLevel = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rightSidePanel = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.dgvSection = New System.Windows.Forms.DataGridView()
        Me.section_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.year_level = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.section_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.leftSidePanel.SuspendLayout()
        Me.rightSidePanel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvSection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'leftSidePanel
        '
        Me.leftSidePanel.BackColor = System.Drawing.Color.White
        Me.leftSidePanel.Controls.Add(Me.PictureBox6)
        Me.leftSidePanel.Controls.Add(Me.Label1)
        Me.leftSidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftSidePanel.Location = New System.Drawing.Point(0, 0)
        Me.leftSidePanel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.leftSidePanel.Name = "leftSidePanel"
        Me.leftSidePanel.Size = New System.Drawing.Size(429, 698)
        Me.leftSidePanel.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(201, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 37)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Section Lists"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 21)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Year Level:"
        '
        'cbYearLevel
        '
        Me.cbYearLevel.BackColor = System.Drawing.Color.White
        Me.cbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYearLevel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbYearLevel.FormattingEnabled = True
        Me.cbYearLevel.Location = New System.Drawing.Point(6, 59)
        Me.cbYearLevel.Name = "cbYearLevel"
        Me.cbYearLevel.Size = New System.Drawing.Size(198, 29)
        Me.cbYearLevel.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(429, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(61, 698)
        Me.Panel3.TabIndex = 23
        '
        'rightSidePanel
        '
        Me.rightSidePanel.BackColor = System.Drawing.Color.White
        Me.rightSidePanel.Controls.Add(Me.Panel5)
        Me.rightSidePanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightSidePanel.Location = New System.Drawing.Point(1111, 0)
        Me.rightSidePanel.Name = "rightSidePanel"
        Me.rightSidePanel.Size = New System.Drawing.Size(490, 698)
        Me.rightSidePanel.TabIndex = 24
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(61, 698)
        Me.Panel5.TabIndex = 23
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnNew)
        Me.Panel4.Controls.Add(Me.cbYearLevel)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(490, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(621, 94)
        Me.Panel4.TabIndex = 25
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.AutoSize = True
        Me.btnNew.BackColor = System.Drawing.Color.SeaGreen
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.White
        Me.btnNew.Location = New System.Drawing.Point(463, 36)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(150, 52)
        Me.btnNew.TabIndex = 17
        Me.btnNew.Text = "&New Section"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'dgvSection
        '
        Me.dgvSection.AllowUserToAddRows = False
        Me.dgvSection.AllowUserToDeleteRows = False
        Me.dgvSection.AllowUserToResizeColumns = False
        Me.dgvSection.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSection.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSection.BackgroundColor = System.Drawing.Color.White
        Me.dgvSection.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSection.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSection.ColumnHeadersHeight = 70
        Me.dgvSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.section_id, Me.year_level, Me.section_name, Me.btnEdit, Me.btnDelete})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSection.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSection.EnableHeadersVisualStyles = False
        Me.dgvSection.Location = New System.Drawing.Point(490, 94)
        Me.dgvSection.MultiSelect = False
        Me.dgvSection.Name = "dgvSection"
        Me.dgvSection.ReadOnly = True
        Me.dgvSection.RowHeadersVisible = False
        Me.dgvSection.RowHeadersWidth = 51
        Me.dgvSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSection.Size = New System.Drawing.Size(621, 604)
        Me.dgvSection.TabIndex = 26
        Me.dgvSection.TabStop = False
        '
        'section_id
        '
        Me.section_id.DataPropertyName = "section_id"
        Me.section_id.HeaderText = "ID"
        Me.section_id.Name = "section_id"
        Me.section_id.ReadOnly = True
        '
        'year_level
        '
        Me.year_level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.year_level.DataPropertyName = "year_level"
        Me.year_level.HeaderText = "Year Level"
        Me.year_level.Name = "year_level"
        Me.year_level.ReadOnly = True
        '
        'section_name
        '
        Me.section_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.section_name.DataPropertyName = "section_name"
        Me.section_name.HeaderText = "Section"
        Me.section_name.Name = "section_name"
        Me.section_name.ReadOnly = True
        '
        'btnEdit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.btnEdit.DefaultCellStyle = DataGridViewCellStyle3
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.HeaderText = "Actions"
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.ReadOnly = True
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseColumnTextForButtonValue = True
        Me.btnEdit.Width = 150
        '
        'btnDelete
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.btnDelete.DefaultCellStyle = DataGridViewCellStyle4
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.HeaderText = ""
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.ReadOnly = True
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseColumnTextForButtonValue = True
        Me.btnDelete.Width = 150
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_list_64
        Me.PictureBox6.Location = New System.Drawing.Point(108, 20)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(87, 69)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 16
        Me.PictureBox6.TabStop = False
        '
        'FormSections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1601, 698)
        Me.Controls.Add(Me.dgvSection)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.rightSidePanel)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.leftSidePanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormSections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormSections"
        Me.leftSidePanel.ResumeLayout(False)
        Me.leftSidePanel.PerformLayout()
        Me.rightSidePanel.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvSection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents leftSidePanel As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents cbYearLevel As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rightSidePanel As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Public WithEvents dgvSection As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents section_id As DataGridViewTextBoxColumn
    Friend WithEvents year_level As DataGridViewTextBoxColumn
    Friend WithEvents section_name As DataGridViewTextBoxColumn
    Friend WithEvents btnEdit As DataGridViewButtonColumn
    Friend WithEvents btnDelete As DataGridViewButtonColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox6 As PictureBox
End Class
