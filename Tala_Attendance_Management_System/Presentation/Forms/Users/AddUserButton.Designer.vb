<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUserButton
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
        Me.btnIndividual = New System.Windows.Forms.Button()
        Me.btnBatchGenerate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnIndividual
        '
        Me.btnIndividual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIndividual.AutoSize = True
        Me.btnIndividual.BackColor = System.Drawing.Color.White
        Me.btnIndividual.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIndividual.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndividual.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnIndividual.Location = New System.Drawing.Point(228, 83)
        Me.btnIndividual.Name = "btnIndividual"
        Me.btnIndividual.Size = New System.Drawing.Size(158, 79)
        Me.btnIndividual.TabIndex = 21
        Me.btnIndividual.Text = "&Individual Create"
        Me.btnIndividual.UseVisualStyleBackColor = False
        '
        'btnBatchGenerate
        '
        Me.btnBatchGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBatchGenerate.AutoSize = True
        Me.btnBatchGenerate.BackColor = System.Drawing.Color.White
        Me.btnBatchGenerate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBatchGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBatchGenerate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatchGenerate.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnBatchGenerate.Location = New System.Drawing.Point(42, 83)
        Me.btnBatchGenerate.Name = "btnBatchGenerate"
        Me.btnBatchGenerate.Size = New System.Drawing.Size(158, 79)
        Me.btnBatchGenerate.TabIndex = 20
        Me.btnBatchGenerate.Text = "&Batch Create"
        Me.btnBatchGenerate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label1.Location = New System.Drawing.Point(117, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 30)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Generate user by:"
        '
        'AddUserButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(435, 215)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnIndividual)
        Me.Controls.Add(Me.btnBatchGenerate)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AddUserButton"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnIndividual As Button
    Friend WithEvents btnBatchGenerate As Button
    Friend WithEvents Label1 As Label
End Class
