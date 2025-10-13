<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormClassSchedule
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvTeacherSchedule = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.updateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.schedule_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subject_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.section_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classroom_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.start_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.end_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvTeacherSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTeacherSchedule
        '
        Me.dgvTeacherSchedule.AllowUserToAddRows = False
        Me.dgvTeacherSchedule.AllowUserToDeleteRows = False
        Me.dgvTeacherSchedule.AllowUserToResizeColumns = False
        Me.dgvTeacherSchedule.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTeacherSchedule.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTeacherSchedule.BackgroundColor = System.Drawing.Color.White
        Me.dgvTeacherSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTeacherSchedule.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTeacherSchedule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTeacherSchedule.ColumnHeadersHeight = 70
        Me.dgvTeacherSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTeacherSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.schedule_id, Me.subject_name, Me.section_name, Me.classroom_name, Me.day, Me.start_time, Me.end_time})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTeacherSchedule.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTeacherSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTeacherSchedule.Enabled = False
        Me.dgvTeacherSchedule.EnableHeadersVisualStyles = False
        Me.dgvTeacherSchedule.Location = New System.Drawing.Point(0, 74)
        Me.dgvTeacherSchedule.MultiSelect = False
        Me.dgvTeacherSchedule.Name = "dgvTeacherSchedule"
        Me.dgvTeacherSchedule.ReadOnly = True
        Me.dgvTeacherSchedule.RowHeadersVisible = False
        Me.dgvTeacherSchedule.RowHeadersWidth = 51
        Me.dgvTeacherSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTeacherSchedule.Size = New System.Drawing.Size(1051, 470)
        Me.dgvTeacherSchedule.TabIndex = 19
        Me.dgvTeacherSchedule.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1051, 74)
        Me.Panel1.TabIndex = 20
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
        Me.subject_name.Name = "subject_name"
        Me.subject_name.ReadOnly = True
        '
        'section_name
        '
        Me.section_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.section_name.DataPropertyName = "section"
        Me.section_name.HeaderText = "Section"
        Me.section_name.Name = "section_name"
        Me.section_name.ReadOnly = True
        Me.section_name.Width = 90
        '
        'classroom_name
        '
        Me.classroom_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.classroom_name.DataPropertyName = "classroom_name"
        Me.classroom_name.HeaderText = "Classroom"
        Me.classroom_name.Name = "classroom_name"
        Me.classroom_name.ReadOnly = True
        '
        'day
        '
        Me.day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.day.DataPropertyName = "day"
        Me.day.HeaderText = "Day"
        Me.day.Name = "day"
        Me.day.ReadOnly = True
        Me.day.Width = 63
        '
        'start_time
        '
        Me.start_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.start_time.DataPropertyName = "start_time"
        Me.start_time.HeaderText = "Start Time"
        Me.start_time.Name = "start_time"
        Me.start_time.ReadOnly = True
        Me.start_time.Width = 102
        '
        'end_time
        '
        Me.end_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.end_time.DataPropertyName = "end_time"
        Me.end_time.HeaderText = "End Time"
        Me.end_time.Name = "end_time"
        Me.end_time.ReadOnly = True
        Me.end_time.Width = 95
        '
        'FormClassSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1051, 544)
        Me.Controls.Add(Me.dgvTeacherSchedule)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormClassSchedule"
        Me.Text = "FormClassSchedule"
        CType(Me.dgvTeacherSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents dgvTeacherSchedule As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents updateTimer As Timer
    Friend WithEvents schedule_id As DataGridViewTextBoxColumn
    Friend WithEvents subject_name As DataGridViewTextBoxColumn
    Friend WithEvents section_name As DataGridViewTextBoxColumn
    Friend WithEvents classroom_name As DataGridViewTextBoxColumn
    Friend WithEvents day As DataGridViewTextBoxColumn
    Friend WithEvents start_time As DataGridViewTextBoxColumn
    Friend WithEvents end_time As DataGridViewTextBoxColumn
End Class
