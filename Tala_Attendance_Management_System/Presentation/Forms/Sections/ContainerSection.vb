Public Class ContainerSection
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
            currentButton.ForeColor = Color.RoyalBlue
        End If

        selectedButton.BackColor = Color.DeepSkyBlue
        selectedButton.ForeColor = Color.White
        currentButton = selectedButton
    End Sub
    Private Sub ContainerSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If btnItemsClicked = 1 Then
            btnSectioning.PerformClick()
        ElseIf btnItemsClicked = 2 Then
            btnSectionLists.PerformClick()
        Else
            btnSectioning.PerformClick()
        End If
    End Sub

    Private Sub btnSectioning_Click(sender As Object, e As EventArgs) Handles btnSectioning.Click
        HighlightButton(btnSectioning)
        OpenForm(New AddStudentSection)
    End Sub

    Private Sub btnSectionLists_Click(sender As Object, e As EventArgs) Handles btnSectionLists.Click
        HighlightButton(btnSectionLists)
        OpenForm(New FormSections)
    End Sub

    Private Sub ContainerSection_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'btnItemsClicked = 0
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class