Public Class AddUserButton
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnIndividual_Click(sender As Object, e As EventArgs) Handles btnIndividual.Click
        AddUser.ShowDialog()
        Me.Close()
    End Sub

    Private Sub AddUserButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBatchGenerate_Click(sender As Object, e As EventArgs) Handles btnBatchGenerate.Click
        If MsgBox("This will create a user role of teacher. All of the teachers that don't have an account yet will be processed. Do still want to proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Batch Create") = MsgBoxResult.Yes Then
            BatchGenerate.ShowDialog()
            Me.Close()
        End If
    End Sub
End Class