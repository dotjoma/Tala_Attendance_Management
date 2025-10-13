Public Class CLassScheduleForm
    Public currentButton As Button
    Public currentChild As Form
    Private Sub OpenForm(ByVal childForm As Form)
        Try
            If currentChild IsNot Nothing Then
                currentChild.Close()
            End If
            currentChild = childForm

            childForm.TopLevel = False
            childForm.FormBorderStyle = FormBorderStyle.None
            childForm.Dock = DockStyle.Fill

            panelContainer.Controls.Add(childForm)

            childForm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Public Sub HighlightButton(selectedButton As Button)
        If currentButton IsNot Nothing Then
            currentButton.BackColor = Color.White
            currentButton.ForeColor = Color.DimGray
        End If

        selectedButton.BackColor = Color.DeepSkyBlue
        selectedButton.ForeColor = Color.White
        currentButton = selectedButton
    End Sub

    Private Sub CLassScheduleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If btnItemsClicked = 1 Then
            btnStudents.PerformClick()
        ElseIf btnItemsClicked = 2 Then
            btnTeachers.PerformClick()
        Else
            btnTeachers.PerformClick()
        End If
    End Sub

    Private Sub btnTeachers_Click(sender As Object, e As EventArgs) Handles btnTeachers.Click
        HighlightButton(btnTeachers)
        OpenForm(New AddTeacherClassSchedule)
    End Sub

    Private Sub btnStudents_Click(sender As Object, e As EventArgs) Handles btnStudents.Click
        HighlightButton(btnStudents)
        OpenForm(New StudentSchedule)
    End Sub

    Private Sub CLassScheduleForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'btnItemsClicked = 0
    End Sub
End Class