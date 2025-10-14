<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStudentAttendance
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStudentAttendance))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.dgvAttendanceRecords = New System.Windows.Forms.DataGridView()
        Me.studID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.student_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.logDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.day_of_week = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arrivalTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departureTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvAttendanceRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.btnGenerate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 79)
        Me.Panel1.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.CustomFormat = "yyyy-MM-dd"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(395, 27)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(134, 25)
        Me.dtpTo.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(363, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "To:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(168, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "From:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.CustomFormat = "yyyy-MM-dd"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(216, 27)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(134, 25)
        Me.dtpFrom.TabIndex = 12
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.AutoSize = True
        Me.btnGenerate.BackColor = System.Drawing.Color.SeaGreen
        Me.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.ForeColor = System.Drawing.Color.White
        Me.btnGenerate.Location = New System.Drawing.Point(533, 23)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(130, 33)
        Me.btnGenerate.TabIndex = 11
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'dgvAttendanceRecords
        '
        Me.dgvAttendanceRecords.AllowUserToAddRows = False
        Me.dgvAttendanceRecords.AllowUserToDeleteRows = False
        Me.dgvAttendanceRecords.AllowUserToResizeColumns = False
        Me.dgvAttendanceRecords.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAttendanceRecords.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAttendanceRecords.BackgroundColor = System.Drawing.Color.White
        Me.dgvAttendanceRecords.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAttendanceRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttendanceRecords.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAttendanceRecords.ColumnHeadersHeight = 70
        Me.dgvAttendanceRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvAttendanceRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.studID, Me.student_name, Me.logDate, Me.day_of_week, Me.subject, Me.arrivalTime, Me.departureTime, Me.remarks})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAttendanceRecords.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAttendanceRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAttendanceRecords.EnableHeadersVisualStyles = False
        Me.dgvAttendanceRecords.Location = New System.Drawing.Point(0, 79)
        Me.dgvAttendanceRecords.MultiSelect = False
        Me.dgvAttendanceRecords.Name = "dgvAttendanceRecords"
        Me.dgvAttendanceRecords.ReadOnly = True
        Me.dgvAttendanceRecords.RowHeadersVisible = False
        Me.dgvAttendanceRecords.RowHeadersWidth = 51
        Me.dgvAttendanceRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAttendanceRecords.Size = New System.Drawing.Size(838, 535)
        Me.dgvAttendanceRecords.TabIndex = 21
        Me.dgvAttendanceRecords.TabStop = False
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
        'logDate
        '
        Me.logDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.logDate.DataPropertyName = "logDate"
        Me.logDate.HeaderText = "Date"
        Me.logDate.Name = "logDate"
        Me.logDate.ReadOnly = True
        Me.logDate.Width = 58
        '
        'day_of_week
        '
        Me.day_of_week.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.day_of_week.DataPropertyName = "day_of_week"
        Me.day_of_week.HeaderText = "Day"
        Me.day_of_week.Name = "day_of_week"
        Me.day_of_week.ReadOnly = True
        Me.day_of_week.Width = 53
        '
        'subject
        '
        Me.subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.subject.DataPropertyName = "subject"
        Me.subject.HeaderText = "Subject"
        Me.subject.Name = "subject"
        Me.subject.ReadOnly = True
        Me.subject.Width = 73
        '
        'arrivalTime
        '
        Me.arrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.arrivalTime.DataPropertyName = "arrivalTime"
        Me.arrivalTime.HeaderText = "Time in"
        Me.arrivalTime.Name = "arrivalTime"
        Me.arrivalTime.ReadOnly = True
        Me.arrivalTime.Width = 59
        '
        'departureTime
        '
        Me.departureTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.departureTime.DataPropertyName = "departureTime"
        Me.departureTime.HeaderText = "Time out"
        Me.departureTime.Name = "departureTime"
        Me.departureTime.ReadOnly = True
        Me.departureTime.Width = 59
        '
        'remarks
        '
        Me.remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.remarks.DataPropertyName = "remarks"
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.ReadOnly = True
        Me.remarks.Width = 81
        '
        'FormStudentAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(838, 614)
        Me.Controls.Add(Me.dgvAttendanceRecords)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormStudentAttendance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student's Attendance"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvAttendanceRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Public WithEvents dgvAttendanceRecords As DataGridView
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents btnGenerate As Button
    Friend WithEvents studID As DataGridViewTextBoxColumn
    Friend WithEvents student_name As DataGridViewTextBoxColumn
    Friend WithEvents logDate As DataGridViewTextBoxColumn
    Friend WithEvents day_of_week As DataGridViewTextBoxColumn
    Friend WithEvents subject As DataGridViewTextBoxColumn
    Friend WithEvents arrivalTime As DataGridViewTextBoxColumn
    Friend WithEvents departureTime As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
End Class
