<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMyStudents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMyStudents))
        Me.dgvMyStudents = New System.Windows.Forms.DataGridView()
        Me.studID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.student_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contact_person = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.phone_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFilter = New System.Windows.Forms.ComboBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        CType(Me.dgvMyStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMyStudents
        '
        Me.dgvMyStudents.AllowUserToAddRows = False
        Me.dgvMyStudents.AllowUserToDeleteRows = False
        Me.dgvMyStudents.AllowUserToResizeColumns = False
        Me.dgvMyStudents.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMyStudents.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMyStudents.BackgroundColor = System.Drawing.Color.White
        Me.dgvMyStudents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMyStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMyStudents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMyStudents.ColumnHeadersHeight = 70
        Me.dgvMyStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMyStudents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.studID, Me.student_name, Me.gender, Me.contact_person, Me.phone_number, Me.address})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMyStudents.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMyStudents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMyStudents.EnableHeadersVisualStyles = False
        Me.dgvMyStudents.Location = New System.Drawing.Point(0, 87)
        Me.dgvMyStudents.MultiSelect = False
        Me.dgvMyStudents.Name = "dgvMyStudents"
        Me.dgvMyStudents.ReadOnly = True
        Me.dgvMyStudents.RowHeadersVisible = False
        Me.dgvMyStudents.RowHeadersWidth = 51
        Me.dgvMyStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMyStudents.Size = New System.Drawing.Size(1051, 457)
        Me.dgvMyStudents.TabIndex = 20
        Me.dgvMyStudents.TabStop = False
        '
        'studID
        '
        Me.studID.DataPropertyName = "studID"
        Me.studID.HeaderText = "ID"
        Me.studID.Name = "studID"
        Me.studID.ReadOnly = True
        Me.studID.Visible = False
        '
        'student_name
        '
        Me.student_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.student_name.DataPropertyName = "student_name"
        Me.student_name.HeaderText = "Student Name"
        Me.student_name.Name = "student_name"
        Me.student_name.ReadOnly = True
        '
        'gender
        '
        Me.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.gender.DataPropertyName = "gender"
        Me.gender.HeaderText = "Gender"
        Me.gender.Name = "gender"
        Me.gender.ReadOnly = True
        Me.gender.Width = 74
        '
        'contact_person
        '
        Me.contact_person.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.contact_person.DataPropertyName = "contact_person"
        Me.contact_person.HeaderText = "Contact Person"
        Me.contact_person.Name = "contact_person"
        Me.contact_person.ReadOnly = True
        '
        'phone_number
        '
        Me.phone_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.phone_number.DataPropertyName = "phone_number"
        Me.phone_number.HeaderText = "Contact Number"
        Me.phone_number.Name = "phone_number"
        Me.phone_number.ReadOnly = True
        Me.phone_number.Width = 116
        '
        'address
        '
        Me.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.address.DataPropertyName = "address"
        Me.address.HeaderText = "Address"
        Me.address.Name = "address"
        Me.address.ReadOnly = True
        Me.address.Width = 79
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.Label3)
        Me.panelHeader.Controls.Add(Me.cbFilter)
        Me.panelHeader.Controls.Add(Me.PictureBox4)
        Me.panelHeader.Controls.Add(Me.Label1)
        Me.panelHeader.Controls.Add(Me.txtSearch)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1051, 87)
        Me.panelHeader.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(69, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 21)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Section:"
        '
        'cbFilter
        '
        Me.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilter.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilter.FormattingEnabled = True
        Me.cbFilter.Items.AddRange(New Object() {"All", "Teachers", "Students"})
        Me.cbFilter.Location = New System.Drawing.Point(146, 39)
        Me.cbFilter.Name = "cbFilter"
        Me.cbFilter.Size = New System.Drawing.Size(219, 33)
        Me.cbFilter.TabIndex = 28
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(615, 34)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(41, 36)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 27
        Me.PictureBox4.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(662, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 21)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.Location = New System.Drawing.Point(733, 37)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(268, 33)
        Me.txtSearch.TabIndex = 25
        '
        'FormMyStudents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1051, 544)
        Me.Controls.Add(Me.dgvMyStudents)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormMyStudents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMyStudents"
        CType(Me.dgvMyStudents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents dgvMyStudents As DataGridView
    Friend WithEvents panelHeader As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents cbFilter As ComboBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents studID As DataGridViewTextBoxColumn
    Friend WithEvents student_name As DataGridViewTextBoxColumn
    Friend WithEvents gender As DataGridViewTextBoxColumn
    Friend WithEvents contact_person As DataGridViewTextBoxColumn
    Friend WithEvents phone_number As DataGridViewTextBoxColumn
    Friend WithEvents address As DataGridViewTextBoxColumn
End Class
