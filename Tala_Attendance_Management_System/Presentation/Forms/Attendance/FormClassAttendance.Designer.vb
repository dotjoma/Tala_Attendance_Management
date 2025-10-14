<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassAttendance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormClassAttendance))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkShowAll = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSubjects = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbSections = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvAttendanceRecords = New System.Windows.Forms.DataGridView()
        Me.studID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.student_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.logDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.day_of_week = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classroom_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.chkShowAll)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbSubjects)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cbSections)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1185, 107)
        Me.Panel1.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(3, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(232, 25)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Daily Attendance Records"
        '
        'chkShowAll
        '
        Me.chkShowAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowAll.AutoSize = True
        Me.chkShowAll.Location = New System.Drawing.Point(775, 58)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.Size = New System.Drawing.Size(76, 21)
        Me.chkShowAll.TabIndex = 27
        Me.chkShowAll.Text = "Show All"
        Me.chkShowAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(546, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 19)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Subjects:"
        '
        'cbSubjects
        '
        Me.cbSubjects.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSubjects.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubjects.FormattingEnabled = True
        Me.cbSubjects.Location = New System.Drawing.Point(550, 53)
        Me.cbSubjects.Name = "cbSubjects"
        Me.cbSubjects.Size = New System.Drawing.Size(219, 33)
        Me.cbSubjects.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(316, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 19)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Section:"
        '
        'cbSections
        '
        Me.cbSections.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSections.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSections.FormattingEnabled = True
        Me.cbSections.Items.AddRange(New Object() {"All", "Teachers", "Students"})
        Me.cbSections.Location = New System.Drawing.Point(320, 53)
        Me.cbSections.Name = "cbSections"
        Me.cbSections.Size = New System.Drawing.Size(219, 33)
        Me.cbSections.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(947, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.Color.DimGray
        Me.txtSearch.Location = New System.Drawing.Point(951, 53)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(229, 33)
        Me.txtSearch.TabIndex = 8
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAttendanceRecords.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAttendanceRecords.ColumnHeadersHeight = 70
        Me.dgvAttendanceRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvAttendanceRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.studID, Me.student_name, Me.logDate, Me.day_of_week, Me.classroom_name, Me.subject, Me.arrivalTime, Me.departureTime, Me.remarks})
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
        Me.dgvAttendanceRecords.Location = New System.Drawing.Point(0, 107)
        Me.dgvAttendanceRecords.MultiSelect = False
        Me.dgvAttendanceRecords.Name = "dgvAttendanceRecords"
        Me.dgvAttendanceRecords.ReadOnly = True
        Me.dgvAttendanceRecords.RowHeadersVisible = False
        Me.dgvAttendanceRecords.RowHeadersWidth = 51
        Me.dgvAttendanceRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAttendanceRecords.Size = New System.Drawing.Size(1185, 437)
        Me.dgvAttendanceRecords.TabIndex = 22
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
        'classroom_name
        '
        Me.classroom_name.DataPropertyName = "classroom_name"
        Me.classroom_name.HeaderText = "Classroom"
        Me.classroom_name.Name = "classroom_name"
        Me.classroom_name.ReadOnly = True
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
        'FormClassAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1185, 544)
        Me.Controls.Add(Me.dgvAttendanceRecords)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormClassAttendance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormClassAttendance"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvAttendanceRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbSections As ComboBox
    Public WithEvents dgvAttendanceRecords As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cbSubjects As ComboBox
    Friend WithEvents chkShowAll As CheckBox
    Friend WithEvents studID As DataGridViewTextBoxColumn
    Friend WithEvents student_name As DataGridViewTextBoxColumn
    Friend WithEvents logDate As DataGridViewTextBoxColumn
    Friend WithEvents day_of_week As DataGridViewTextBoxColumn
    Friend WithEvents classroom_name As DataGridViewTextBoxColumn
    Friend WithEvents subject As DataGridViewTextBoxColumn
    Friend WithEvents arrivalTime As DataGridViewTextBoxColumn
    Friend WithEvents departureTime As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
End Class
