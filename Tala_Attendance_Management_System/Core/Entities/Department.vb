Public Class Department
    Public Property DepartmentId As Integer
    Public Property DepartmentCode As String
    Public Property DepartmentName As String
    Public Property Description As String
    Public Property HeadTeacherId As Integer?
    Public Property HeadTeacherName As String
    Public Property IsActive As Boolean
    Public Property CreatedAt As DateTime
    Public Property UpdatedAt As DateTime

    Public Sub New()
        IsActive = True
        CreatedAt = DateTime.Now
        UpdatedAt = DateTime.Now
    End Sub

    Public ReadOnly Property DisplayName As String
        Get
            Return $"{DepartmentCode} - {DepartmentName}"
        End Get
    End Property
End Class
