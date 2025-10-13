<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentSchedule
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelHome = New System.Windows.Forms.Label()
        Me.leftSidePanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbSection = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbYearLevel = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rightSidePanel = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvStudentSchedule = New System.Windows.Forms.DataGridView()
        Me.schedule_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subject_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.teacher_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.section_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classroom_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.start_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.end_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.rightSidePanel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvStudentSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.Controls.Add(Me.PictureBox5)
        Me.Panel2.Controls.Add(Me.LabelHome)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1538, 82)
        Me.Panel2.TabIndex = 16
        '
        'LabelHome
        '
        Me.LabelHome.AutoSize = True
        Me.LabelHome.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHome.ForeColor = System.Drawing.Color.White
        Me.LabelHome.Location = New System.Drawing.Point(68, 20)
        Me.LabelHome.Name = "LabelHome"
        Me.LabelHome.Size = New System.Drawing.Size(183, 45)
        Me.LabelHome.TabIndex = 5
        Me.LabelHome.Text = "STUDENTS"
        '
        'leftSidePanel
        '
        Me.leftSidePanel.BackColor = System.Drawing.Color.White
        Me.leftSidePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftSidePanel.Location = New System.Drawing.Point(0, 82)
        Me.leftSidePanel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.leftSidePanel.Name = "leftSidePanel"
        Me.leftSidePanel.Size = New System.Drawing.Size(368, 617)
        Me.leftSidePanel.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(304, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 21)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Section:"
        '
        'cbSection
        '
        Me.cbSection.BackColor = System.Drawing.Color.White
        Me.cbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSection.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSection.FormattingEnabled = True
        Me.cbSection.Location = New System.Drawing.Point(308, 47)
        Me.cbSection.Name = "cbSection"
        Me.cbSection.Size = New System.Drawing.Size(283, 33)
        Me.cbSection.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 21)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Year Level:"
        '
        'cbYearLevel
        '
        Me.cbYearLevel.BackColor = System.Drawing.Color.White
        Me.cbYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbYearLevel.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbYearLevel.FormattingEnabled = True
        Me.cbYearLevel.Location = New System.Drawing.Point(6, 47)
        Me.cbYearLevel.Name = "cbYearLevel"
        Me.cbYearLevel.Size = New System.Drawing.Size(283, 33)
        Me.cbYearLevel.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(368, 82)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(61, 617)
        Me.Panel3.TabIndex = 22
        '
        'rightSidePanel
        '
        Me.rightSidePanel.BackColor = System.Drawing.Color.White
        Me.rightSidePanel.Controls.Add(Me.Panel5)
        Me.rightSidePanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightSidePanel.Location = New System.Drawing.Point(1188, 82)
        Me.rightSidePanel.Name = "rightSidePanel"
        Me.rightSidePanel.Size = New System.Drawing.Size(350, 617)
        Me.rightSidePanel.TabIndex = 23
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(61, 617)
        Me.Panel5.TabIndex = 23
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.cbYearLevel)
        Me.Panel4.Controls.Add(Me.cbSection)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(429, 82)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(759, 92)
        Me.Panel4.TabIndex = 24
        '
        'dgvStudentSchedule
        '
        Me.dgvStudentSchedule.AllowUserToAddRows = False
        Me.dgvStudentSchedule.AllowUserToDeleteRows = False
        Me.dgvStudentSchedule.AllowUserToResizeColumns = False
        Me.dgvStudentSchedule.AllowUserToResizeRows = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvStudentSchedule.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvStudentSchedule.BackgroundColor = System.Drawing.Color.White
        Me.dgvStudentSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStudentSchedule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvStudentSchedule.ColumnHeadersHeight = 70
        Me.dgvStudentSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvStudentSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.schedule_id, Me.subject_name, Me.teacher_name, Me.section_name, Me.classroom_name, Me.day, Me.start_time, Me.end_time})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStudentSchedule.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvStudentSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStudentSchedule.EnableHeadersVisualStyles = False
        Me.dgvStudentSchedule.Location = New System.Drawing.Point(429, 174)
        Me.dgvStudentSchedule.MultiSelect = False
        Me.dgvStudentSchedule.Name = "dgvStudentSchedule"
        Me.dgvStudentSchedule.ReadOnly = True
        Me.dgvStudentSchedule.RowHeadersVisible = False
        Me.dgvStudentSchedule.RowHeadersWidth = 51
        Me.dgvStudentSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudentSchedule.Size = New System.Drawing.Size(759, 525)
        Me.dgvStudentSchedule.TabIndex = 25
        Me.dgvStudentSchedule.TabStop = False
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
        Me.classroom_name.Width = 107
        '
        'day
        '
        Me.day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.day.DataPropertyName = "day"
        Me.day.HeaderText = "Day"
        Me.day.Name = "day"
        Me.day.ReadOnly = True
        Me.day.Width = 60
        '
        'start_time
        '
        Me.start_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.start_time.DataPropertyName = "start_time"
        Me.start_time.HeaderText = "Start Time"
        Me.start_time.Name = "start_time"
        Me.start_time.ReadOnly = True
        Me.start_time.Width = 95
        '
        'end_time
        '
        Me.end_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.end_time.DataPropertyName = "end_time"
        Me.end_time.HeaderText = "End Time"
        Me.end_time.Name = "end_time"
        Me.end_time.ReadOnly = True
        Me.end_time.Width = 89
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox5.Image = Global.Tala_Attendance_Management_System.My.Resources.Resources.icons8_student_50
        Me.PictureBox5.Location = New System.Drawing.Point(12, 20)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(50, 41)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 20
        Me.PictureBox5.TabStop = False
        '
        'StudentSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1538, 699)
        Me.Controls.Add(Me.dgvStudentSchedule)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.rightSidePanel)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.leftSidePanel)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "StudentSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StudentSchedule"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.rightSidePanel.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvStudentSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelHome As Label
    Friend WithEvents leftSidePanel As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rightSidePanel As Panel
    Friend WithEvents Panel4 As Panel
    Public WithEvents dgvStudentSchedule As DataGridView
    Friend WithEvents schedule_id As DataGridViewTextBoxColumn
    Friend WithEvents subject_name As DataGridViewTextBoxColumn
    Friend WithEvents teacher_name As DataGridViewTextBoxColumn
    Friend WithEvents section_name As DataGridViewTextBoxColumn
    Friend WithEvents classroom_name As DataGridViewTextBoxColumn
    Friend WithEvents day As DataGridViewTextBoxColumn
    Friend WithEvents start_time As DataGridViewTextBoxColumn
    Friend WithEvents end_time As DataGridViewTextBoxColumn
    Friend WithEvents Label7 As Label
    Friend WithEvents cbYearLevel As ComboBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbSection As ComboBox
    Friend WithEvents PictureBox5 As PictureBox
End Class
