<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddTeacherClassSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddTeacherClassSchedule))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LabelHome = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.dgvTeacherSchedule = New System.Windows.Forms.DataGridView()
        Me.schedule_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subject_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.teacher_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.section_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classroom_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.start_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.end_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.teacherID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelRightSide = New System.Windows.Forms.Panel()
        Me.panelLeftSide = New System.Windows.Forms.Panel()
        Me.panelHeader.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelBottom.SuspendLayout()
        CType(Me.dgvTeacherSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelHome
        '
        Me.LabelHome.AutoSize = True
        Me.LabelHome.BackColor = System.Drawing.Color.SteelBlue
        Me.LabelHome.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHome.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabelHome.Location = New System.Drawing.Point(68, 21)
        Me.LabelHome.Name = "LabelHome"
        Me.LabelHome.Size = New System.Drawing.Size(180, 45)
        Me.LabelHome.TabIndex = 15
        Me.LabelHome.Text = "TEACHERS"
        '
        'btnNew
        '
        Me.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNew.AutoSize = True
        Me.btnNew.BackColor = System.Drawing.Color.SeaGreen
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.White
        Me.btnNew.Location = New System.Drawing.Point(508, 7)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(160, 50)
        Me.btnNew.TabIndex = 16
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEdit.AutoSize = True
        Me.btnEdit.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(688, 6)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(160, 50)
        Me.btnEdit.TabIndex = 14
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDelete.AutoSize = True
        Me.btnDelete.BackColor = System.Drawing.Color.Crimson
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(865, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(160, 50)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.panelHeader.Controls.Add(Me.PictureBox4)
        Me.panelHeader.Controls.Add(Me.PictureBox5)
        Me.panelHeader.Controls.Add(Me.LabelHome)
        Me.panelHeader.Controls.Add(Me.Label8)
        Me.panelHeader.Controls.Add(Me.txtSearch)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1566, 82)
        Me.panelHeader.TabIndex = 2
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1522, 30)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(41, 36)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 20
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox5.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_admin_50__1_
        Me.PictureBox5.Location = New System.Drawing.Point(12, 25)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(50, 41)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 19
        Me.PictureBox5.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Location = New System.Drawing.Point(1211, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 21)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.Location = New System.Drawing.Point(1280, 33)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(286, 33)
        Me.txtSearch.TabIndex = 10
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelBottom.Controls.Add(Me.btnNew)
        Me.panelBottom.Controls.Add(Me.btnDelete)
        Me.panelBottom.Controls.Add(Me.btnEdit)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(20, 610)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(1526, 69)
        Me.panelBottom.TabIndex = 3
        '
        'dgvTeacherSchedule
        '
        Me.dgvTeacherSchedule.AllowUserToAddRows = False
        Me.dgvTeacherSchedule.AllowUserToDeleteRows = False
        Me.dgvTeacherSchedule.AllowUserToResizeColumns = False
        Me.dgvTeacherSchedule.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTeacherSchedule.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTeacherSchedule.BackgroundColor = System.Drawing.Color.White
        Me.dgvTeacherSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTeacherSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTeacherSchedule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTeacherSchedule.ColumnHeadersHeight = 70
        Me.dgvTeacherSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTeacherSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.schedule_id, Me.subject_name, Me.teacher_name, Me.section_name, Me.classroom_name, Me.day, Me.start_time, Me.end_time, Me.teacherID})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTeacherSchedule.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTeacherSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTeacherSchedule.EnableHeadersVisualStyles = False
        Me.dgvTeacherSchedule.Location = New System.Drawing.Point(20, 82)
        Me.dgvTeacherSchedule.MultiSelect = False
        Me.dgvTeacherSchedule.Name = "dgvTeacherSchedule"
        Me.dgvTeacherSchedule.ReadOnly = True
        Me.dgvTeacherSchedule.RowHeadersVisible = False
        Me.dgvTeacherSchedule.RowHeadersWidth = 51
        Me.dgvTeacherSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTeacherSchedule.Size = New System.Drawing.Size(1526, 528)
        Me.dgvTeacherSchedule.TabIndex = 20
        Me.dgvTeacherSchedule.TabStop = False
        '
        'schedule_id
        '
        Me.schedule_id.DataPropertyName = "schedule_id"
        Me.schedule_id.HeaderText = "ID"
        Me.schedule_id.Name = "schedule_id"
        Me.schedule_id.ReadOnly = True
        Me.schedule_id.Visible = False
        '
        'subject_name
        '
        Me.subject_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.subject_name.DataPropertyName = "subject_name"
        Me.subject_name.HeaderText = "Subject"
        Me.subject_name.MinimumWidth = 200
        Me.subject_name.Name = "subject_name"
        Me.subject_name.ReadOnly = True
        '
        'teacher_name
        '
        Me.teacher_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.teacher_name.DataPropertyName = "teacher_name"
        Me.teacher_name.HeaderText = "Teacher"
        Me.teacher_name.Name = "teacher_name"
        Me.teacher_name.ReadOnly = True
        '
        'section_name
        '
        Me.section_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.section_name.DataPropertyName = "section"
        Me.section_name.HeaderText = "Section"
        Me.section_name.Name = "section_name"
        Me.section_name.ReadOnly = True
        '
        'classroom_name
        '
        Me.classroom_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.classroom_name.DataPropertyName = "classroom_name"
        Me.classroom_name.HeaderText = "Classroom"
        Me.classroom_name.Name = "classroom_name"
        Me.classroom_name.ReadOnly = True
        Me.classroom_name.Width = 93
        '
        'day
        '
        Me.day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.day.DataPropertyName = "day"
        Me.day.HeaderText = "Day"
        Me.day.Name = "day"
        Me.day.ReadOnly = True
        Me.day.Width = 53
        '
        'start_time
        '
        Me.start_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.start_time.DataPropertyName = "start_time"
        Me.start_time.HeaderText = "Start Time"
        Me.start_time.Name = "start_time"
        Me.start_time.ReadOnly = True
        Me.start_time.Width = 83
        '
        'end_time
        '
        Me.end_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.end_time.DataPropertyName = "end_time"
        Me.end_time.HeaderText = "End Time"
        Me.end_time.Name = "end_time"
        Me.end_time.ReadOnly = True
        Me.end_time.Width = 78
        '
        'teacherID
        '
        Me.teacherID.DataPropertyName = "teacherID"
        Me.teacherID.HeaderText = "Teacher ID"
        Me.teacherID.Name = "teacherID"
        Me.teacherID.ReadOnly = True
        Me.teacherID.Visible = False
        '
        'panelRightSide
        '
        Me.panelRightSide.BackColor = System.Drawing.Color.White
        Me.panelRightSide.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRightSide.Location = New System.Drawing.Point(1546, 82)
        Me.panelRightSide.Name = "panelRightSide"
        Me.panelRightSide.Size = New System.Drawing.Size(20, 597)
        Me.panelRightSide.TabIndex = 1
        '
        'panelLeftSide
        '
        Me.panelLeftSide.BackColor = System.Drawing.Color.White
        Me.panelLeftSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeftSide.Location = New System.Drawing.Point(0, 82)
        Me.panelLeftSide.Name = "panelLeftSide"
        Me.panelLeftSide.Size = New System.Drawing.Size(20, 597)
        Me.panelLeftSide.TabIndex = 0
        '
        'AddTeacherClassSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1566, 679)
        Me.Controls.Add(Me.dgvTeacherSchedule)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelRightSide)
        Me.Controls.Add(Me.panelLeftSide)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AddTeacherClassSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddTeacherClassSchedule"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelBottom.ResumeLayout(False)
        Me.panelBottom.PerformLayout()
        CType(Me.dgvTeacherSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelBottom As Panel
    Public WithEvents dgvTeacherSchedule As DataGridView
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents LabelHome As Label
    Friend WithEvents panelRightSide As Panel
    Friend WithEvents panelLeftSide As Panel
    Friend WithEvents schedule_id As DataGridViewTextBoxColumn
    Friend WithEvents subject_name As DataGridViewTextBoxColumn
    Friend WithEvents teacher_name As DataGridViewTextBoxColumn
    Friend WithEvents section_name As DataGridViewTextBoxColumn
    Friend WithEvents classroom_name As DataGridViewTextBoxColumn
    Friend WithEvents day As DataGridViewTextBoxColumn
    Friend WithEvents start_time As DataGridViewTextBoxColumn
    Friend WithEvents end_time As DataGridViewTextBoxColumn
    Friend WithEvents teacherID As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
End Class
