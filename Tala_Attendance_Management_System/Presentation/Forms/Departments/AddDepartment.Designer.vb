<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddDepartment
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelContainer = New System.Windows.Forms.Panel()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.cboHeadTeacher = New System.Windows.Forms.ComboBox()
        Me.lblHeadTeacher = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDepartmentName = New System.Windows.Forms.TextBox()
        Me.lblDepartmentName = New System.Windows.Forms.Label()
        Me.txtDepartmentCode = New System.Windows.Forms.TextBox()
        Me.lblDepartmentCode = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.panelContainer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 60)
        Me.Panel1.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 17)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(189, 30)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Add Department"
        '
        'panelContainer
        '
        Me.panelContainer.BackColor = System.Drawing.Color.White
        Me.panelContainer.Controls.Add(Me.chkIsActive)
        Me.panelContainer.Controls.Add(Me.cboHeadTeacher)
        Me.panelContainer.Controls.Add(Me.lblHeadTeacher)
        Me.panelContainer.Controls.Add(Me.txtDescription)
        Me.panelContainer.Controls.Add(Me.lblDescription)
        Me.panelContainer.Controls.Add(Me.txtDepartmentName)
        Me.panelContainer.Controls.Add(Me.lblDepartmentName)
        Me.panelContainer.Controls.Add(Me.txtDepartmentCode)
        Me.panelContainer.Controls.Add(Me.lblDepartmentCode)
        Me.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContainer.Location = New System.Drawing.Point(0, 60)
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Padding = New System.Windows.Forms.Padding(30)
        Me.panelContainer.Size = New System.Drawing.Size(500, 390)
        Me.panelContainer.TabIndex = 1
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Checked = True
        Me.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsActive.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.chkIsActive.Location = New System.Drawing.Point(30, 340)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(71, 25)
        Me.chkIsActive.TabIndex = 8
        Me.chkIsActive.Text = "Active"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'cboHeadTeacher
        '
        Me.cboHeadTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHeadTeacher.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cboHeadTeacher.FormattingEnabled = True
        Me.cboHeadTeacher.Location = New System.Drawing.Point(30, 290)
        Me.cboHeadTeacher.Name = "cboHeadTeacher"
        Me.cboHeadTeacher.Size = New System.Drawing.Size(440, 29)
        Me.cboHeadTeacher.TabIndex = 7
        '
        'lblHeadTeacher
        '
        Me.lblHeadTeacher.AutoSize = True
        Me.lblHeadTeacher.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeadTeacher.Location = New System.Drawing.Point(30, 265)
        Me.lblHeadTeacher.Name = "lblHeadTeacher"
        Me.lblHeadTeacher.Size = New System.Drawing.Size(146, 21)
        Me.lblHeadTeacher.TabIndex = 6
        Me.lblHeadTeacher.Text = "Department Head"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtDescription.Location = New System.Drawing.Point(30, 180)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(440, 70)
        Me.txtDescription.TabIndex = 5
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescription.Location = New System.Drawing.Point(30, 155)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(98, 21)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtDepartmentName.Location = New System.Drawing.Point(30, 110)
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(440, 29)
        Me.txtDepartmentName.TabIndex = 3
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.AutoSize = True
        Me.lblDepartmentName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartmentName.Location = New System.Drawing.Point(30, 85)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(163, 21)
        Me.lblDepartmentName.TabIndex = 2
        Me.lblDepartmentName.Text = "Department Name *"
        '
        'txtDepartmentCode
        '
        Me.txtDepartmentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentCode.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtDepartmentCode.Location = New System.Drawing.Point(30, 40)
        Me.txtDepartmentCode.Name = "txtDepartmentCode"
        Me.txtDepartmentCode.Size = New System.Drawing.Size(150, 29)
        Me.txtDepartmentCode.TabIndex = 1
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.AutoSize = True
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartmentCode.Location = New System.Drawing.Point(30, 15)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(156, 21)
        Me.lblDepartmentCode.TabIndex = 0
        Me.lblDepartmentCode.Text = "Department Code *"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 450)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 70)
        Me.Panel2.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(270, 20)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 35)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(380, 20)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 35)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddDepartment
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(500, 520)
        Me.Controls.Add(Me.panelContainer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddDepartment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Department"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelContainer.ResumeLayout(False)
        Me.panelContainer.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents panelContainer As Panel
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents cboHeadTeacher As ComboBox
    Friend WithEvents lblHeadTeacher As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDepartmentName As TextBox
    Friend WithEvents lblDepartmentName As Label
    Friend WithEvents txtDepartmentCode As TextBox
    Friend WithEvents lblDepartmentCode As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
End Class
