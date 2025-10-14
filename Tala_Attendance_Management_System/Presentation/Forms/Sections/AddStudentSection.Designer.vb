<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddStudentSection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddStudentSection))
        Me.panelLeftSide = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRemoveStudents = New System.Windows.Forms.Button()
        Me.btnMoveStudents = New System.Windows.Forms.Button()
        Me.btnRetainSections = New System.Windows.Forms.Button()
        Me.btnAssignSection = New System.Windows.Forms.Button()
        Me.panelRightSide = New System.Windows.Forms.Panel()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.chkShowAll = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFilter = New System.Windows.Forms.ComboBox()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.dgvStudentSection = New System.Windows.Forms.DataGridView()
        Me.chkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.studID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.student_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.section = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contact_person = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.phone_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assignement_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gradeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelLeftSide.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.panelBottom.SuspendLayout()
        CType(Me.dgvStudentSection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelLeftSide
        '
        Me.panelLeftSide.BackColor = System.Drawing.Color.White
        Me.panelLeftSide.Controls.Add(Me.PictureBox6)
        Me.panelLeftSide.Controls.Add(Me.Label1)
        Me.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeftSide.Location = New System.Drawing.Point(0, 0)
        Me.panelLeftSide.Name = "panelLeftSide"
        Me.panelLeftSide.Size = New System.Drawing.Size(220, 679)
        Me.panelLeftSide.TabIndex = 1
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_cog_48
        Me.PictureBox6.Location = New System.Drawing.Point(12, 29)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(44, 42)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 16
        Me.PictureBox6.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(61, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 37)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Sectioning"
        '
        'btnRemoveStudents
        '
        Me.btnRemoveStudents.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnRemoveStudents.AutoSize = True
        Me.btnRemoveStudents.BackColor = System.Drawing.Color.Crimson
        Me.btnRemoveStudents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveStudents.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveStudents.ForeColor = System.Drawing.Color.White
        Me.btnRemoveStudents.Location = New System.Drawing.Point(584, 26)
        Me.btnRemoveStudents.Name = "btnRemoveStudents"
        Me.btnRemoveStudents.Size = New System.Drawing.Size(160, 50)
        Me.btnRemoveStudents.TabIndex = 16
        Me.btnRemoveStudents.Text = "&Remove students"
        Me.btnRemoveStudents.UseVisualStyleBackColor = False
        '
        'btnMoveStudents
        '
        Me.btnMoveStudents.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMoveStudents.AutoSize = True
        Me.btnMoveStudents.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnMoveStudents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMoveStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMoveStudents.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveStudents.ForeColor = System.Drawing.Color.White
        Me.btnMoveStudents.Location = New System.Drawing.Point(408, 26)
        Me.btnMoveStudents.Name = "btnMoveStudents"
        Me.btnMoveStudents.Size = New System.Drawing.Size(160, 50)
        Me.btnMoveStudents.TabIndex = 15
        Me.btnMoveStudents.Text = "&Move Students"
        Me.btnMoveStudents.UseVisualStyleBackColor = False
        '
        'btnRetainSections
        '
        Me.btnRetainSections.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnRetainSections.AutoSize = True
        Me.btnRetainSections.BackColor = System.Drawing.Color.White
        Me.btnRetainSections.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRetainSections.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRetainSections.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetainSections.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnRetainSections.Location = New System.Drawing.Point(799, 20)
        Me.btnRetainSections.Name = "btnRetainSections"
        Me.btnRetainSections.Size = New System.Drawing.Size(140, 60)
        Me.btnRetainSections.TabIndex = 14
        Me.btnRetainSections.Text = "Retain &previous"
        Me.btnRetainSections.UseVisualStyleBackColor = False
        Me.btnRetainSections.Visible = False
        '
        'btnAssignSection
        '
        Me.btnAssignSection.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAssignSection.AutoSize = True
        Me.btnAssignSection.BackColor = System.Drawing.Color.SeaGreen
        Me.btnAssignSection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAssignSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssignSection.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssignSection.ForeColor = System.Drawing.Color.White
        Me.btnAssignSection.Location = New System.Drawing.Point(226, 26)
        Me.btnAssignSection.Name = "btnAssignSection"
        Me.btnAssignSection.Size = New System.Drawing.Size(160, 50)
        Me.btnAssignSection.TabIndex = 12
        Me.btnAssignSection.Text = "Assign &new"
        Me.btnAssignSection.UseVisualStyleBackColor = False
        '
        'panelRightSide
        '
        Me.panelRightSide.BackColor = System.Drawing.Color.White
        Me.panelRightSide.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRightSide.Location = New System.Drawing.Point(1165, 0)
        Me.panelRightSide.Name = "panelRightSide"
        Me.panelRightSide.Size = New System.Drawing.Size(220, 679)
        Me.panelRightSide.TabIndex = 2
        '
        'panelHeader
        '
        Me.panelHeader.Controls.Add(Me.chkShowAll)
        Me.panelHeader.Controls.Add(Me.Label2)
        Me.panelHeader.Controls.Add(Me.txtSearch)
        Me.panelHeader.Controls.Add(Me.Label3)
        Me.panelHeader.Controls.Add(Me.cbFilter)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(220, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(945, 82)
        Me.panelHeader.TabIndex = 3
        '
        'chkShowAll
        '
        Me.chkShowAll.AutoSize = True
        Me.chkShowAll.Location = New System.Drawing.Point(285, 39)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.Size = New System.Drawing.Size(88, 25)
        Me.chkShowAll.TabIndex = 34
        Me.chkShowAll.Text = "Show all"
        Me.chkShowAll.UseVisualStyleBackColor = True
        Me.chkShowAll.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(622, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.Location = New System.Drawing.Point(626, 37)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(268, 29)
        Me.txtSearch.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(46, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 19)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Filter by section:"
        '
        'cbFilter
        '
        Me.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilter.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFilter.FormattingEnabled = True
        Me.cbFilter.Items.AddRange(New Object() {"All", "Teachers", "Students"})
        Me.cbFilter.Location = New System.Drawing.Point(50, 37)
        Me.cbFilter.Name = "cbFilter"
        Me.cbFilter.Size = New System.Drawing.Size(219, 29)
        Me.cbFilter.TabIndex = 30
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelBottom.Controls.Add(Me.btnRetainSections)
        Me.panelBottom.Controls.Add(Me.btnRemoveStudents)
        Me.panelBottom.Controls.Add(Me.btnAssignSection)
        Me.panelBottom.Controls.Add(Me.btnMoveStudents)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(220, 579)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(945, 100)
        Me.panelBottom.TabIndex = 4
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
        Me.dgvStudentSection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSelect, Me.studID, Me.student_name, Me.gender, Me.section, Me.contact_person, Me.phone_number, Me.address, Me.assignement_date, Me.gradeID})
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
        Me.dgvStudentSection.Location = New System.Drawing.Point(220, 82)
        Me.dgvStudentSection.MultiSelect = False
        Me.dgvStudentSection.Name = "dgvStudentSection"
        Me.dgvStudentSection.ReadOnly = True
        Me.dgvStudentSection.RowHeadersVisible = False
        Me.dgvStudentSection.RowHeadersWidth = 51
        Me.dgvStudentSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudentSection.Size = New System.Drawing.Size(945, 497)
        Me.dgvStudentSection.TabIndex = 22
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
        'section
        '
        Me.section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.section.DataPropertyName = "section"
        Me.section.HeaderText = "Section"
        Me.section.Name = "section"
        Me.section.ReadOnly = True
        Me.section.Width = 84
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
        'assignement_date
        '
        Me.assignement_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.assignement_date.DataPropertyName = "assignment_date"
        Me.assignement_date.HeaderText = "Assigned Date"
        Me.assignement_date.Name = "assignement_date"
        Me.assignement_date.ReadOnly = True
        Me.assignement_date.Width = 121
        '
        'gradeID
        '
        Me.gradeID.DataPropertyName = "gradeID"
        Me.gradeID.HeaderText = "Grade ID"
        Me.gradeID.Name = "gradeID"
        Me.gradeID.ReadOnly = True
        Me.gradeID.Visible = False
        '
        'AddStudentSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1385, 679)
        Me.Controls.Add(Me.dgvStudentSection)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.panelRightSide)
        Me.Controls.Add(Me.panelLeftSide)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "AddStudentSection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddStudentClassSchedule"
        Me.panelLeftSide.ResumeLayout(False)
        Me.panelLeftSide.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelBottom.ResumeLayout(False)
        Me.panelBottom.PerformLayout()
        CType(Me.dgvStudentSection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelLeftSide As Panel
    Friend WithEvents btnAssignSection As Button
    Friend WithEvents panelRightSide As Panel
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelBottom As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRetainSections As Button
    Friend WithEvents btnRemoveStudents As Button
    Friend WithEvents btnMoveStudents As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbFilter As ComboBox
    Public WithEvents dgvStudentSection As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents chkShowAll As CheckBox
    Friend WithEvents chkSelect As DataGridViewCheckBoxColumn
    Friend WithEvents studID As DataGridViewTextBoxColumn
    Friend WithEvents student_name As DataGridViewTextBoxColumn
    Friend WithEvents gender As DataGridViewTextBoxColumn
    Friend WithEvents section As DataGridViewTextBoxColumn
    Friend WithEvents contact_person As DataGridViewTextBoxColumn
    Friend WithEvents phone_number As DataGridViewTextBoxColumn
    Friend WithEvents address As DataGridViewTextBoxColumn
    Friend WithEvents assignement_date As DataGridViewTextBoxColumn
    Friend WithEvents gradeID As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox6 As PictureBox
End Class
