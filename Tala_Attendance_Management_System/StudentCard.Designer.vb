<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentCard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.panelContainer = New System.Windows.Forms.Panel()
        Me.txtLrn = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.Label()
        Me.txtDateTime = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.Label()
        Me.pbPicture = New System.Windows.Forms.PictureBox()
        Me.panelContainer.SuspendLayout()
        CType(Me.pbPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelContainer
        '
        Me.panelContainer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelContainer.Controls.Add(Me.txtLrn)
        Me.panelContainer.Controls.Add(Me.txtStatus)
        Me.panelContainer.Controls.Add(Me.txtDateTime)
        Me.panelContainer.Controls.Add(Me.txtName)
        Me.panelContainer.Controls.Add(Me.pbPicture)
        Me.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContainer.Location = New System.Drawing.Point(0, 0)
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Size = New System.Drawing.Size(450, 224)
        Me.panelContainer.TabIndex = 3
        '
        'txtLrn
        '
        Me.txtLrn.AutoSize = True
        Me.txtLrn.Font = New System.Drawing.Font("Segoe UI Light", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLrn.Location = New System.Drawing.Point(233, 116)
        Me.txtLrn.Name = "txtLrn"
        Me.txtLrn.Size = New System.Drawing.Size(52, 37)
        Me.txtLrn.TabIndex = 6
        Me.txtLrn.Text = "Lrn"
        '
        'txtStatus
        '
        Me.txtStatus.AutoSize = True
        Me.txtStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtStatus.Location = New System.Drawing.Point(233, 12)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(93, 37)
        Me.txtStatus.TabIndex = 5
        Me.txtStatus.Text = "Status"
        '
        'txtDateTime
        '
        Me.txtDateTime.AutoSize = True
        Me.txtDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateTime.Location = New System.Drawing.Point(5, 179)
        Me.txtDateTime.Name = "txtDateTime"
        Me.txtDateTime.Size = New System.Drawing.Size(105, 30)
        Me.txtDateTime.TabIndex = 4
        Me.txtDateTime.Text = "DateTime"
        '
        'txtName
        '
        Me.txtName.AutoSize = True
        Me.txtName.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(235, 68)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(70, 30)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = "Name"
        '
        'pbPicture
        '
        Me.pbPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPicture.Location = New System.Drawing.Point(10, 12)
        Me.pbPicture.Name = "pbPicture"
        Me.pbPicture.Size = New System.Drawing.Size(217, 164)
        Me.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPicture.TabIndex = 0
        Me.pbPicture.TabStop = False
        '
        'StudentCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.panelContainer)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "StudentCard"
        Me.Size = New System.Drawing.Size(450, 224)
        Me.panelContainer.ResumeLayout(False)
        Me.panelContainer.PerformLayout()
        CType(Me.pbPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelContainer As Panel
    Friend WithEvents txtLrn As Label
    Friend WithEvents txtStatus As Label
    Friend WithEvents txtDateTime As Label
    Friend WithEvents txtName As Label
    Friend WithEvents pbPicture As PictureBox
End Class
