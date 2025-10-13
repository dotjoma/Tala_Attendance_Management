Public Class DepartmentRepository
    Private ReadOnly _dbContext As DatabaseContext
    Private ReadOnly _logger As ILogger

    Public Sub New()
        _dbContext = New DatabaseContext()
        _logger = LoggerFactory.Instance
    End Sub

    Public Function GetAll() As List(Of Department)
        Try
            Dim query As String = "
                SELECT d.department_id, d.department_code, d.department_name, d.description, 
                       d.head_teacher_id, d.is_active, d.created_at, d.updated_at,
                       CONCAT(COALESCE(t.firstname, ''), ' ', COALESCE(t.lastname, '')) AS head_teacher_name
                FROM departments d
                LEFT JOIN teacherinformation t ON d.head_teacher_id = t.teacherID
                WHERE d.is_active = 1
                ORDER BY d.department_name"

            Dim dt As DataTable = _dbContext.ExecuteQuery(query)
            Return MapDataTableToDepartments(dt)
        Catch ex As Exception
            _logger.LogError($"Error getting all departments: {ex.Message}")
            Return New List(Of Department)()
        End Try
    End Function

    Public Function GetById(id As Integer) As Department
        Try
            Dim query As String = "
                SELECT d.department_id, d.department_code, d.department_name, d.description, 
                       d.head_teacher_id, d.is_active, d.created_at, d.updated_at,
                       CONCAT(COALESCE(t.firstname, ''), ' ', COALESCE(t.lastname, '')) AS head_teacher_name
                FROM departments d
                LEFT JOIN teacherinformation t ON d.head_teacher_id = t.teacherID
                WHERE d.department_id = ?"

            Dim dt As DataTable = _dbContext.ExecuteQuery(query, id)
            Dim departments = MapDataTableToDepartments(dt)
            Return If(departments.Count > 0, departments(0), Nothing)
        Catch ex As Exception
            _logger.LogError($"Error getting department by ID {id}: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Public Function Create(department As Department) As Boolean
        Try
            ' Log the head teacher ID value for debugging
            _logger.LogInfo($"Creating department: {department.DepartmentCode} - {department.DepartmentName}, Head Teacher ID: {If(department.HeadTeacherId.HasValue, department.HeadTeacherId.Value.ToString(), "NULL")}")

            Dim query As String
            Dim result As Integer

            ' Handle NULL head_teacher_id explicitly in the SQL
            If department.HeadTeacherId.HasValue Then
                query = "
                    INSERT INTO departments (department_code, department_name, description, head_teacher_id, is_active)
                    VALUES (?, ?, ?, ?, ?)"

                result = _dbContext.ExecuteNonQuery(query,
                    department.DepartmentCode,
                    department.DepartmentName,
                    department.Description,
                    department.HeadTeacherId.Value,
                    department.IsActive)
            Else
                query = "
                    INSERT INTO departments (department_code, department_name, description, head_teacher_id, is_active)
                    VALUES (?, ?, ?, NULL, ?)"

                result = _dbContext.ExecuteNonQuery(query,
                    department.DepartmentCode,
                    department.DepartmentName,
                    department.Description,
                    department.IsActive)
            End If

            _logger.LogInfo($"Department created successfully: {department.DepartmentCode} - {department.DepartmentName}")
            Return result > 0
        Catch ex As Exception
            _logger.LogError($"Error creating department: {ex.Message}")
            Return False
        End Try
    End Function

    Public Function Update(department As Department) As Boolean
        Try
            _logger.LogInfo($"Updating department: {department.DepartmentCode} - {department.DepartmentName}, Head Teacher ID: {If(department.HeadTeacherId.HasValue, department.HeadTeacherId.Value.ToString(), "NULL")}")

            Dim query As String
            Dim result As Integer

            ' Handle NULL head_teacher_id explicitly in the SQL
            If department.HeadTeacherId.HasValue Then
                query = "
                    UPDATE departments 
                    SET department_code = ?, department_name = ?, description = ?, 
                        head_teacher_id = ?, is_active = ?, updated_at = CURRENT_TIMESTAMP
                    WHERE department_id = ?"

                result = _dbContext.ExecuteNonQuery(query,
                    department.DepartmentCode,
                    department.DepartmentName,
                    department.Description,
                    department.HeadTeacherId.Value,
                    department.IsActive,
                    department.DepartmentId)
            Else
                query = "
                    UPDATE departments 
                    SET department_code = ?, department_name = ?, description = ?, 
                        head_teacher_id = NULL, is_active = ?, updated_at = CURRENT_TIMESTAMP
                    WHERE department_id = ?"

                result = _dbContext.ExecuteNonQuery(query,
                    department.DepartmentCode,
                    department.DepartmentName,
                    department.Description,
                    department.IsActive,
                    department.DepartmentId)
            End If

            _logger.LogInfo($"Department updated: ID {department.DepartmentId}")
            Return result > 0
        Catch ex As Exception
            _logger.LogError($"Error updating department: {ex.Message}")
            Return False
        End Try
    End Function

    Public Function Delete(id As Integer) As Boolean
        Try
            ' Soft delete - set is_active to 0
            Dim query As String = "UPDATE departments SET is_active = 0, updated_at = CURRENT_TIMESTAMP WHERE department_id = ?"
            Dim result = _dbContext.ExecuteNonQuery(query, id)

            _logger.LogInfo($"Department deleted (soft): ID {id}")
            Return result > 0
        Catch ex As Exception
            _logger.LogError($"Error deleting department: {ex.Message}")
            Return False
        End Try
    End Function

    Public Function IsCodeUnique(code As String, Optional excludeId As Integer = 0) As Boolean
        Try
            Dim query As String = "SELECT COUNT(*) FROM departments WHERE department_code = ? AND department_id <> ? AND is_active = 1"
            Dim result = Convert.ToInt32(_dbContext.ExecuteScalar(query, code, excludeId))
            Return result = 0
        Catch ex As Exception
            _logger.LogError($"Error checking department code uniqueness: {ex.Message}")
            Return False
        End Try
    End Function

    Private Function MapDataTableToDepartments(dt As DataTable) As List(Of Department)
        Dim departments As New List(Of Department)()

        For Each row As DataRow In dt.Rows
            departments.Add(New Department() With {
                .DepartmentId = Convert.ToInt32(row("department_id")),
                .DepartmentCode = row("department_code").ToString(),
                .DepartmentName = row("department_name").ToString(),
                .Description = If(IsDBNull(row("description")), "", row("description").ToString()),
                .HeadTeacherId = If(IsDBNull(row("head_teacher_id")), Nothing, Convert.ToInt32(row("head_teacher_id"))),
                .HeadTeacherName = If(IsDBNull(row("head_teacher_name")), "", row("head_teacher_name").ToString()),
                .IsActive = Convert.ToBoolean(row("is_active")),
                .CreatedAt = Convert.ToDateTime(row("created_at")),
                .UpdatedAt = Convert.ToDateTime(row("updated_at"))
            })
        Next

        Return departments
    End Function
End Class
