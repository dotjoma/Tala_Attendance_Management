Public Class DepartmentSelector
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Private ReadOnly _departmentService As IDepartmentService
    Private _selectedDepartment As Department

    Public ReadOnly Property SelectedDepartment As Department
        Get
            Return _selectedDepartment
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        _departmentService = New DepartmentService()
    End Sub

    Private Sub DepartmentSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _logger.LogInfo("DepartmentSelector - Form loaded")
            LoadDepartments()
        Catch ex As Exception
            _logger.LogError($"DepartmentSelector - Error in Form_Load: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            Dim departments = _departmentService.GetActiveDepartments()
            
            lstDepartments.Items.Clear()
            For Each dept In departments
                lstDepartments.Items.Add(dept)
            Next
            
            lstDepartments.DisplayMember = "DisplayName"
            
            _logger.LogInfo($"DepartmentSelector - {departments.Count} departments loaded")
        Catch ex As Exception
            _logger.LogError($"DepartmentSelector - Error loading departments: {ex.Message}")
        End Try
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            If lstDepartments.SelectedItem IsNot Nothing Then
                _selectedDepartment = DirectCast(lstDepartments.SelectedItem, Department)
                _logger.LogInfo($"DepartmentSelector - Department selected: {_selectedDepartment.DepartmentName}")
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Please select a department.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            _logger.LogError($"DepartmentSelector - Error in Select button: {ex.Message}")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            _logger.LogInfo("DepartmentSelector - Cancel button clicked")
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            _logger.LogError($"DepartmentSelector - Error in Cancel button: {ex.Message}")
            Me.Close()
        End Try
    End Sub

    Private Sub lstDepartments_DoubleClick(sender As Object, e As EventArgs) Handles lstDepartments.DoubleClick
        btnSelect_Click(sender, e)
    End Sub

    Private Sub lstDepartments_KeyDown(sender As Object, e As KeyEventArgs) Handles lstDepartments.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect_Click(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            btnCancel_Click(sender, e)
        End If
    End Sub
End Class