Public Class StudentCard
    Public Property StudentName As String
        Get
            Return txtName.Text
        End Get
        Set(ByVal value As String)
            txtName.Text = value
        End Set
    End Property

    Public Property LRN As String
        Get
            Return txtLrn.Text
        End Get
        Set(ByVal value As String)
            txtLrn.Text = value
        End Set
    End Property



    Public Property Status As String
        Get
            Return txtStatus.Text
        End Get
        Set(ByVal value As String)
            txtStatus.Text = value

            ' Change color based on value
            Select Case value
                Case "Time Out"
                    txtStatus.ForeColor = Color.Crimson
                Case "Time In"
                    txtStatus.ForeColor = Color.SeaGreen
                Case Else
                    txtStatus.ForeColor = Color.Gray ' Default or unknown status
            End Select
        End Set
    End Property

    Public Property DateTimeInfo As String
        Get
            Return txtDateTime.Text
        End Get
        Set(ByVal value As String)
            txtDateTime.Text = value
        End Set
    End Property

    Public Sub Reset()
        Me.StudentName = String.Empty
        Me.LRN = String.Empty
        Me.Status = String.Empty
        Me.DateTimeInfo = String.Empty
        Me.pbPicture.Image = Nothing
    End Sub

    Private Sub txtStatus_Click(sender As Object, e As EventArgs) Handles txtStatus.Click

    End Sub
End Class
