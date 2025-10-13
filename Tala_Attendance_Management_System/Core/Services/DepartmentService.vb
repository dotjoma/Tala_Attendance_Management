Public Class DepartmentService
    Implements IDepartmentService

    Private ReadOnly _repository As DepartmentRepository
    Private ReadOnly _logger As ILogger

    Public Sub New()
        _repository = New DepartmentRepository()
        _logger = LoggerFactory.Instance
    End Sub

    Public Function GetAllDepartments() As List(Of Department) Implements IDepartmentService.GetAllDepartments
        Return _repository.GetAll()
    End Function

    Public Function GetActiveDepartments() As List(Of Department) Implements IDepartmentService.GetActiveDepartments
        Return _repository.GetAll().Where(Function(d) d.IsActive).ToList()
    End Function

    Public Function GetDepartmentById(id As Integer) As Department Implements IDepartmentService.GetDepartmentById
        Return _repository.GetById(id)
    End Function

    Public Function CreateDepartment(department As Department) As Boolean Implements IDepartmentService.CreateDepartment
        ' Validate department
        If String.IsNullOrWhiteSpace(department.DepartmentCode) OrElse String.IsNullOrWhiteSpace(department.DepartmentName) Then
            _logger.LogWarning("Department creation failed - Code and Name are required")
            Return False
        End If

        ' Check code uniqueness
        If Not _repository.IsCodeUnique(department.DepartmentCode) Then
            _logger.LogWarning($"Department creation failed - Code '{department.DepartmentCode}' already exists")
            Return False
        End If

        Return _repository.Create(department)
    End Function

    Public Function UpdateDepartment(department As Department) As Boolean Implements IDepartmentService.UpdateDepartment
        ' Validate department
        If String.IsNullOrWhiteSpace(department.DepartmentCode) OrElse String.IsNullOrWhiteSpace(department.DepartmentName) Then
            _logger.LogWarning("Department update failed - Code and Name are required")
            Return False
        End If

        ' Check code uniqueness (excluding current department)
        If Not _repository.IsCodeUnique(department.DepartmentCode, department.DepartmentId) Then
            _logger.LogWarning($"Department update failed - Code '{department.DepartmentCode}' already exists")
            Return False
        End If

        Return _repository.Update(department)
    End Function

    Public Function DeleteDepartment(id As Integer) As Boolean Implements IDepartmentService.DeleteDepartment
        Return _repository.Delete(id)
    End Function

    Public Function IsDepartmentCodeUnique(code As String, Optional excludeId As Integer = 0) As Boolean Implements IDepartmentService.IsDepartmentCodeUnique
        Return _repository.IsCodeUnique(code, excludeId)
    End Function

    Public Function SearchDepartments(searchTerm As String) As List(Of Department) Implements IDepartmentService.SearchDepartments
        Try
            Dim allDepartments = GetActiveDepartments()

            If String.IsNullOrWhiteSpace(searchTerm) Then
                Return allDepartments
            End If

            Dim searchLower = searchTerm.ToLower().Trim()
            Dim filteredDepartments As New List(Of Department)()

            For Each dept As Department In allDepartments
                Dim matchesCode = Not String.IsNullOrEmpty(dept.DepartmentCode) AndAlso dept.DepartmentCode.ToLower().Contains(searchLower)
                Dim matchesName = Not String.IsNullOrEmpty(dept.DepartmentName) AndAlso dept.DepartmentName.ToLower().Contains(searchLower)
                Dim matchesDescription = Not String.IsNullOrEmpty(dept.Description) AndAlso dept.Description.ToLower().Contains(searchLower)

                If matchesCode OrElse matchesName OrElse matchesDescription Then
                    filteredDepartments.Add(dept)
                End If
            Next

            Return filteredDepartments

        Catch ex As Exception
            _logger.LogError($"Error in SearchDepartments: {ex.Message}")
            Return New List(Of Department)()
        End Try
    End Function

End Class
