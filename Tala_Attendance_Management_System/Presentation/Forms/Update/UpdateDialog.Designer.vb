<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateDialog
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblChangeLog = New System.Windows.Forms.Label()
        Me.txtChangeLog = New System.Windows.Forms.TextBox()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(165, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Update Available"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(17, 50)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(350, 17)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "A new version of Tala Attendance Management is available."
        '
        'lblChangeLog
        '
        Me.lblChangeLog.AutoSize = True
        Me.lblChangeLog.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblChangeLog.Location = New System.Drawing.Point(17, 85)
        Me.lblChangeLog.Name = "lblChangeLog"
        Me.lblChangeLog.Size = New System.Drawing.Size(110, 17)
        Me.lblChangeLog.TabIndex = 2
        Me.lblChangeLog.Text = "What's Changed:"
        '
        'txtChangeLog
        '
        Me.txtChangeLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtChangeLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeLog.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChangeLog.Location = New System.Drawing.Point(20, 108)
        Me.txtChangeLog.Multiline = True
        Me.txtChangeLog.Name = "txtChangeLog"
        Me.txtChangeLog.ReadOnly = True
        Me.txtChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChangeLog.Size = New System.Drawing.Size(520, 100)
        Me.txtChangeLog.TabIndex = 3
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYes.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.ForeColor = System.Drawing.Color.White
        Me.btnYes.Location = New System.Drawing.Point(330, 270)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(110, 35)
        Me.btnYes.TabIndex = 4
        Me.btnYes.Text = "Update Now"
        Me.btnYes.UseVisualStyleBackColor = False
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.White
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnNo.Location = New System.Drawing.Point(446, 270)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(94, 35)
        Me.btnNo.TabIndex = 5
        Me.btnNo.Text = "Later"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(20, 230)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(520, 25)
        Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progressBar.TabIndex = 6
        Me.progressBar.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.lblProgress.Location = New System.Drawing.Point(17, 213)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(0, 15)
        Me.lblProgress.TabIndex = 7
        Me.lblProgress.Visible = False
        '
        'UpdateDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(560, 320)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.txtChangeLog)
        Me.Controls.Add(Me.lblChangeLog)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tala Attendance - Update Available"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblChangeLog As Label
    Friend WithEvents txtChangeLog As TextBox
    Friend WithEvents btnYes As Button
    Friend WithEvents btnNo As Button
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents lblProgress As Label
End Class
