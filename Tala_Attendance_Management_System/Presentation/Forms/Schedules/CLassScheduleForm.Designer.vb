<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CLassScheduleForm
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
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.btnStudents = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTeachers = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.panelContainer = New System.Windows.Forms.Panel()
        Me.panelButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelButtons
        '
        Me.panelButtons.BackColor = System.Drawing.Color.Gainsboro
        Me.panelButtons.Controls.Add(Me.btnStudents)
        Me.panelButtons.Controls.Add(Me.Panel1)
        Me.panelButtons.Controls.Add(Me.btnTeachers)
        Me.panelButtons.Controls.Add(Me.Panel4)
        Me.panelButtons.Controls.Add(Me.Panel3)
        Me.panelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelButtons.ForeColor = System.Drawing.Color.DimGray
        Me.panelButtons.Location = New System.Drawing.Point(0, 0)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(1422, 85)
        Me.panelButtons.TabIndex = 2
        '
        'btnStudents
        '
        Me.btnStudents.BackColor = System.Drawing.Color.White
        Me.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStudents.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStudents.ForeColor = System.Drawing.Color.DimGray
        Me.btnStudents.Location = New System.Drawing.Point(165, 20)
        Me.btnStudents.Name = "btnStudents"
        Me.btnStudents.Size = New System.Drawing.Size(156, 65)
        Me.btnStudents.TabIndex = 22
        Me.btnStudents.Text = "Students"
        Me.btnStudents.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(6, 65)
        Me.Panel1.TabIndex = 18
        '
        'btnTeachers
        '
        Me.btnTeachers.BackColor = System.Drawing.Color.White
        Me.btnTeachers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTeachers.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTeachers.ForeColor = System.Drawing.Color.DimGray
        Me.btnTeachers.Location = New System.Drawing.Point(3, 20)
        Me.btnTeachers.Name = "btnTeachers"
        Me.btnTeachers.Size = New System.Drawing.Size(156, 65)
        Me.btnTeachers.TabIndex = 19
        Me.btnTeachers.Text = "Teachers"
        Me.btnTeachers.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1392, 20)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(30, 65)
        Me.Panel4.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1422, 20)
        Me.Panel3.TabIndex = 20
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.SteelBlue
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBottom.Location = New System.Drawing.Point(0, 550)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(1422, 62)
        Me.panelBottom.TabIndex = 3
        '
        'panelContainer
        '
        Me.panelContainer.BackColor = System.Drawing.Color.White
        Me.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelContainer.ForeColor = System.Drawing.Color.DimGray
        Me.panelContainer.Location = New System.Drawing.Point(0, 85)
        Me.panelContainer.Name = "panelContainer"
        Me.panelContainer.Size = New System.Drawing.Size(1422, 465)
        Me.panelContainer.TabIndex = 4
        '
        'CLassScheduleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1422, 612)
        Me.Controls.Add(Me.panelContainer)
        Me.Controls.Add(Me.panelBottom)
        Me.Controls.Add(Me.panelButtons)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "CLassScheduleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLassScheduleForm"
        Me.panelButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelButtons As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnTeachers As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelBottom As Panel
    Friend WithEvents panelContainer As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnStudents As Button
End Class
