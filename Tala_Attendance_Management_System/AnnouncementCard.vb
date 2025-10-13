Public Class AnnouncementCard
    ' Properties for the AnnouncementCard
    Public Property Header As String
        Get
            Return txtHeader.Text
        End Get
        Set(ByVal value As String)
            txtHeader.Text = value
        End Set
    End Property

    Public Property DateInfo As String
        Get
            Return txtDate.Text
        End Get
        Set(ByVal value As String)
            txtDate.Text = value
        End Set
    End Property

    Public Property DayInfo As String
        Get
            Return txtDay.Text
        End Get
        Set(ByVal value As String)
            txtDay.Text = value
        End Set
    End Property

    Public Property TimeInfo As String
        Get
            Return txtTime.Text
        End Get
        Set(ByVal value As String)
            txtTime.Text = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return txtDescription.Text
        End Get
        Set(ByVal value As String)
            txtDescription.Text = value
        End Set
    End Property
    Public Property LookFor As String
        Get
            Return txtLookFor.Text
        End Get
        Set(ByVal value As String)
            txtLookFor.Text = value
        End Set
    End Property

    ' Optionally, you can add a PictureBox property
    Public Property AnnouncementImage As Image
        Get
            Return pbAnnouncement.Image
        End Get
        Set(ByVal value As Image)
            pbAnnouncement.Image = value
        End Set
    End Property

    ' Method to reset the AnnouncementCard
    Public Sub Reset()
        Me.Header = String.Empty
        Me.DateInfo = String.Empty
        Me.DayInfo = String.Empty
        Me.TimeInfo = String.Empty
        Me.Description = String.Empty
        Me.AnnouncementImage = Nothing
    End Sub

    Private Sub txtLookFor_Click(sender As Object, e As EventArgs) Handles txtLookFor.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtTime_Click(sender As Object, e As EventArgs) Handles txtTime.Click

    End Sub
End Class