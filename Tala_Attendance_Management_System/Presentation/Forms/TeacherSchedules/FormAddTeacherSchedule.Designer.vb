<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddTeacherSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddTeacherSchedule))
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.LabelHome = New System.Windows.Forms.Label()
        Me.panelContainer = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbSection = New System.Windows.Forms.ComboBox()
        Me.dtpEndTime = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkListBoxClassDay = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbClassroom = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSubject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbTeacher = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.panelHeader.SuspendLayout()
        Me.panelContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.panelHeader.Controls.Add(Me.LabelHome)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(757, 88)
        Me.panelHeader.TabIndex = 0
        '
        'LabelHome
        '
        Me.LabelHome.AutoSize = True
        Me.LabelHome.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHome.ForeColor = System.Drawing.Color.White
        Me.LabelHome.Location = New System.Drawing.Point(229, 22)
        Me.LabelHome.Name = "LabelHome"
        Me.LabelHome.Size = New System.Drawing.Size(298, 45)
        Me.LabelHome.TabIndex = 16
        Me.LabelHome.Text = "Teacher's Schedule"
        '
        'panelContainer
        '
        Me.panelContainer.Controls.Add(Me.btnCancel)
        Me.panelContainer.Controls.Add(Me.Label7)
        Me.panelContainer.Controls.Add(Me.cbSection)
        Me.panelContainer.Controls.Add(Me.dtpEndTime)
        Me.panelContainer.Controls.Add(Me.Label6)
        Me.panelContainer.Controls.Add(Me.dtpStartTime)
        Me.panelContainer.Controls.Add(Me.Label5)
        Me.panelContainer.Controls.Add(Me.Label4)
        Me.panelContainer.Controls.Add(Me.chkListBoxClassDay)
        Me.panelContainer.Controls.Add(Me.Label3)
        Me.panelContainer.Controls.Add(Me.cbClassroom)
        Me.panelContainer.Controls.Add(Me.Label2)
        Me.panelContainer.Controls.Add(Me.cbSubject)
        Me.panelContainer.Controls.Add(Me.Label1)
        Me.panelContainer.Controls.Add(Me.cbTeacher)
        Me.panelContainer.Controls.Add(Me.btnSave)
        Me.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContainer.Location = New System.Drawing.Point(0, 88)
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Size = New System.Drawing.Size(757, 447)
        Me.panelContainer.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnCancel.Location = New System.Drawing.Point(82, 339)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(284, 53)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(390, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 21)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Section"
        '
        'cbSection
        '
        Me.cbSection.BackColor = System.Drawing.Color.White
        Me.cbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSection.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSection.FormattingEnabled = True
        Me.cbSection.Location = New System.Drawing.Point(393, 131)
        Me.cbSection.Name = "cbSection"
        Me.cbSection.Size = New System.Drawing.Size(283, 29)
        Me.cbSection.TabIndex = 27
        '
        'dtpEndTime
        '
        Me.dtpEndTime.CalendarFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndTime.Location = New System.Drawing.Point(392, 265)
        Me.dtpEndTime.Name = "dtpEndTime"
        Me.dtpEndTime.Size = New System.Drawing.Size(284, 29)
        Me.dtpEndTime.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(389, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 21)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "End time"
        '
        'dtpStartTime
        '
        Me.dtpStartTime.CalendarFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartTime.Location = New System.Drawing.Point(393, 194)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.Size = New System.Drawing.Size(283, 29)
        Me.dtpStartTime.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(388, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 21)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Start time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 21)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Class day"
        '
        'chkListBoxClassDay
        '
        Me.chkListBoxClassDay.FormattingEnabled = True
        Me.chkListBoxClassDay.Items.AddRange(New Object() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.chkListBoxClassDay.Location = New System.Drawing.Point(84, 194)
        Me.chkListBoxClassDay.MultiColumn = True
        Me.chkListBoxClassDay.Name = "chkListBoxClassDay"
        Me.chkListBoxClassDay.Size = New System.Drawing.Size(283, 100)
        Me.chkListBoxClassDay.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 21)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Classroom"
        '
        'cbClassroom
        '
        Me.cbClassroom.BackColor = System.Drawing.Color.White
        Me.cbClassroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbClassroom.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbClassroom.FormattingEnabled = True
        Me.cbClassroom.Location = New System.Drawing.Point(83, 131)
        Me.cbClassroom.Name = "cbClassroom"
        Me.cbClassroom.Size = New System.Drawing.Size(283, 29)
        Me.cbClassroom.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(390, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 21)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Subject"
        '
        'cbSubject
        '
        Me.cbSubject.BackColor = System.Drawing.Color.White
        Me.cbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSubject.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubject.FormattingEnabled = True
        Me.cbSubject.Location = New System.Drawing.Point(393, 62)
        Me.cbSubject.Name = "cbSubject"
        Me.cbSubject.Size = New System.Drawing.Size(283, 29)
        Me.cbSubject.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(80, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 21)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Teacher"
        '
        'cbTeacher
        '
        Me.cbTeacher.BackColor = System.Drawing.Color.White
        Me.cbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTeacher.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTeacher.FormattingEnabled = True
        Me.cbTeacher.Location = New System.Drawing.Point(83, 62)
        Me.cbTeacher.Name = "cbTeacher"
        Me.cbTeacher.Size = New System.Drawing.Size(283, 29)
        Me.cbTeacher.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.AutoSize = True
        Me.btnSave.BackColor = System.Drawing.Color.SeaGreen
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(392, 339)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(284, 53)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'FormAddTeacherSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(757, 535)
        Me.Controls.Add(Me.panelContainer)
        Me.Controls.Add(Me.panelHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormAddTeacherSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAddTeacherSchedule"
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelContainer.ResumeLayout(False)
        Me.panelContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents panelContainer As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cbSection As ComboBox
    Friend WithEvents dtpEndTime As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkListBoxClassDay As CheckedListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbClassroom As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbSubject As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbTeacher As ComboBox
    Friend WithEvents LabelHome As Label
End Class
