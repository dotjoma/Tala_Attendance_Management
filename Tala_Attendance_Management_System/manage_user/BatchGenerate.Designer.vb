<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BatchGenerate
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtIndicator = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(84, 36)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(441, 45)
        Me.ProgressBar1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtIndicator)
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(605, 134)
        Me.Panel2.TabIndex = 1
        '
        'txtIndicator
        '
        Me.txtIndicator.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtIndicator.AutoSize = True
        Me.txtIndicator.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicator.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtIndicator.Location = New System.Drawing.Point(79, 90)
        Me.txtIndicator.Name = "txtIndicator"
        Me.txtIndicator.Size = New System.Drawing.Size(133, 30)
        Me.txtIndicator.TabIndex = 19
        Me.txtIndicator.Text = "Please wait..."
        '
        'BatchGenerate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(605, 134)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "BatchGenerate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BatchGenerate"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtIndicator As Label
End Class
