<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssignSection
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
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSections = New System.Windows.Forms.ComboBox()
        Me.chkShowOptions = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbYearLevel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvStudentSection = New System.Windows.Forms.DataGridView()
        Me.chkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.studID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.student_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contact_person = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.phone_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.panelHeader.SuspendLayout()
        CType(Me.dgvStudentSection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.White
        Me.panelHeader.Controls.Add(Me.Label3)
        Me.panelHeader.Controls.Add(Me.cbSections)
        Me.panelHeader.Controls.Add(Me.chkShowOptions)
        Me.panelHeader.Controls.Add(Me.Label1)
        Me.panelHeader.Controls.Add(Me.cbYearLevel)
        Me.panelHeader.Controls.Add(Me.Label2)
        Me.panelHeader.Controls.Add(Me.txtSearch)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(868, 87)
        Me.panelHeader.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(308, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 19)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Assign to section:"
        '
        'cbSections
        '
        Me.cbSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSections.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSections.FormattingEnabled = True
        Me.cbSections.Location = New System.Drawing.Point(312, 41)
        Me.cbSections.Name = "cbSections"
        Me.cbSections.Size = New System.Drawing.Size(219, 29)
        Me.cbSections.TabIndex = 31
        '
        'chkShowOptions
        '
        Me.chkShowOptions.AutoSize = True
        Me.chkShowOptions.Location = New System.Drawing.Point(12, 64)
        Me.chkShowOptions.Name = "chkShowOptions"
        Me.chkShowOptions.Size = New System.Drawing.Size(69, 17)
        Me.chkShowOptions.TabIndex = 30
        Me.chkShowOptions.Text = "Select all"
        Me.chkShowOptions.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(83, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 19)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Select year level:"
        '
        'cbYearLevel
        '
        Me.cbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYearLevel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbYearLevel.FormattingEnabled = True
        Me.cbYearLevel.Location = New System.Drawing.Point(87, 41)
        Me.cbYearLevel.Name = "cbYearLevel"
        Me.cbYearLevel.Size = New System.Drawing.Size(219, 29)
        Me.cbYearLevel.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(584, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.Location = New System.Drawing.Point(588, 42)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(268, 29)
        Me.txtSearch.TabIndex = 25
        '
        'dgvStudentSection
        '
        Me.dgvStudentSection.AllowUserToAddRows = False
        Me.dgvStudentSection.AllowUserToDeleteRows = False
        Me.dgvStudentSection.AllowUserToResizeColumns = False
        Me.dgvStudentSection.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvStudentSection.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStudentSection.BackgroundColor = System.Drawing.Color.White
        Me.dgvStudentSection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStudentSection.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStudentSection.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStudentSection.ColumnHeadersHeight = 70
        Me.dgvStudentSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvStudentSection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSelect, Me.studID, Me.student_name, Me.gender, Me.contact_person, Me.phone_number, Me.address})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStudentSection.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStudentSection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStudentSection.EnableHeadersVisualStyles = False
        Me.dgvStudentSection.Location = New System.Drawing.Point(0, 87)
        Me.dgvStudentSection.Margin = New System.Windows.Forms.Padding(15, 3, 15, 3)
        Me.dgvStudentSection.MultiSelect = False
        Me.dgvStudentSection.Name = "dgvStudentSection"
        Me.dgvStudentSection.ReadOnly = True
        Me.dgvStudentSection.RowHeadersVisible = False
        Me.dgvStudentSection.RowHeadersWidth = 51
        Me.dgvStudentSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudentSection.Size = New System.Drawing.Size(868, 572)
        Me.dgvStudentSection.TabIndex = 28
        Me.dgvStudentSection.TabStop = False
        '
        'chkSelect
        '
        Me.chkSelect.HeaderText = ""
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.ReadOnly = True
        Me.chkSelect.Width = 50
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
        Me.gender.Width = 84
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
        Me.phone_number.Width = 135
        '
        'address
        '
        Me.address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.address.DataPropertyName = "address"
        Me.address.HeaderText = "Address"
        Me.address.Name = "address"
        Me.address.ReadOnly = True
        Me.address.Width = 89
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 593)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 66)
        Me.Panel1.TabIndex = 29
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnCancel.Location = New System.Drawing.Point(581, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(121, 39)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.AutoSize = True
        Me.btnAdd.BackColor = System.Drawing.Color.SeaGreen
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(708, 15)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(121, 39)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "&Save"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'AssignSection
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 659)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvStudentSection)
        Me.Controls.Add(Me.panelHeader)
        Me.Name = "AssignSection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AssignSection"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.dgvStudentSection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelHeader As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbYearLevel As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearch As TextBox
    Public WithEvents dgvStudentSection As DataGridView
    Friend WithEvents chkShowOptions As CheckBox
    Friend WithEvents chkSelect As DataGridViewCheckBoxColumn
    Friend WithEvents studID As DataGridViewTextBoxColumn
    Friend WithEvents student_name As DataGridViewTextBoxColumn
    Friend WithEvents gender As DataGridViewTextBoxColumn
    Friend WithEvents contact_person As DataGridViewTextBoxColumn
    Friend WithEvents phone_number As DataGridViewTextBoxColumn
    Friend WithEvents address As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbSections As ComboBox
End Class
