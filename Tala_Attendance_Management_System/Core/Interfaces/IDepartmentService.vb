Public Interface IDepartmentService
    Function GetAllDepartments() As List(Of Department)
    Function GetActiveDepartments() As List(Of Department)
    Function GetDepartmentById(id As Integer) As Department
    Function CreateDepartment(department As Department) As Boolean
    Function UpdateDepartment(department As Department) As Boolean
    Function DeleteDepartment(id As Integer) As Boolean
    Function IsDepartmentCodeUnique(code As String, Optional excludeId As Integer = 0) As Boolean
    Function SearchDepartments(searchTerm As String) As List(Of Department)
End Interface
