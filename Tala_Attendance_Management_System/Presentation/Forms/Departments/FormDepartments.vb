Imports System.ComponentModel

Public Class FormDepartments
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Private ReadOnly _departmentService As IDepartmentService
    Private _departments As List(Of Department)

    Public Sub New()
        InitializeComponent()
        _departmentService = New DepartmentService()
        _departments = New List(Of Department)()
    End Sub

    Private Sub FormDepartments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _logger.LogInfo("FormDepartments - Form loaded, initializing department list")
            InitializeDataGridView()
            LoadDepartments()
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error in Form_Load: {ex.Message}")
            MessageBox.Show("Error loading departments. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeDataGridView()
        Try
            ' Configure DataGridView appearance
            dgvDepartments.AutoGenerateColumns = False
            dgvDepartments.AllowUserToAddRows = False
            dgvDepartments.AllowUserToDeleteRows = False
            dgvDepartments.ReadOnly = True
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvDepartments.MultiSelect = False
            dgvDepartments.RowHeadersVisible = False
            
            ' Set font and styling
            dgvDepartments.DefaultCellStyle.Font = New Font("Segoe UI", 12)
            dgvDepartments.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 12)
            dgvDepartments.RowTemplate.Height = 40
            
            ' Clear existing columns
            dgvDepartments.Columns.Clear()
            
            ' Add columns
            dgvDepartments.Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "DepartmentId",
                .DataPropertyName = "DepartmentId",
                .HeaderText = "ID",
                .Width = 60,
                .Visible = False
            })
            
            dgvDepartments.Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "DepartmentCode",
                .DataPropertyName = "DepartmentCode",
                .HeaderText = "Code",
                .Width = 100
            })
            
            dgvDepartments.Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "DepartmentName",
                .DataPropertyName = "DepartmentName",
                .HeaderText = "Department Name",
                .Width = 250,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            })
            
            dgvDepartments.Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "Description",
                .DataPropertyName = "Description",
                .HeaderText = "Description",
                .Width = 200
            })
            
            dgvDepartments.Columns.Add(New DataGridViewTextBoxColumn() With {
                .Name = "HeadTeacherName",
                .DataPropertyName = "HeadTeacherName",
                .HeaderText = "Department Head",
                .Width = 180
            })
            
            dgvDepartments.Columns.Add(New DataGridViewCheckBoxColumn() With {
                .Name = "IsActive",
                .DataPropertyName = "IsActive",
                .HeaderText = "Active",
                .Width = 80
            })
            
            _logger.LogInfo("FormDepartments - DataGridView initialized successfully")
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error initializing DataGridView: {ex.Message}")
        End Try
    End Sub

    Private Sub LoadDepartments()
        Try
            _logger.LogInfo("FormDepartments - Loading departments")
            
            _departments = _departmentService.GetAllDepartments()
            dgvDepartments.DataSource = New BindingList(Of Department)(_departments)
            
            ' Update status
            lblStatus.Text = $"Total Departments: {_departments.Count}"
            
            _logger.LogInfo($"FormDepartments - {_departments.Count} departments loaded successfully")
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error loading departments: {ex.Message}")
            MessageBox.Show("Error loading departments. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            _logger.LogInfo("FormDepartments - Add button clicked")
            
            Using addForm As New AddDepartment()
                If addForm.ShowDialog() = DialogResult.OK Then
                    ' Department was added successfully
                    LoadDepartments() ' Refresh the list
                    _logger.LogInfo("FormDepartments - Department added, list refreshed")
                End If
            End Using
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error in Add button: {ex.Message}")
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If dgvDepartments.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a department to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedDepartment As Department = DirectCast(dgvDepartments.SelectedRows(0).DataBoundItem, Department)
            _logger.LogInfo($"FormDepartments - Edit button clicked for Department ID: {selectedDepartment.DepartmentId}")

            Using editForm As New AddDepartment(selectedDepartment.DepartmentId)
                If editForm.ShowDialog() = DialogResult.OK Then
                    ' Department was updated successfully
                    LoadDepartments() ' Refresh the list
                    _logger.LogInfo("FormDepartments - Department edited, list refreshed")
                End If
            End Using
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error in Edit button: {ex.Message}")
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If dgvDepartments.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a department to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim selectedDepartment As Department = DirectCast(dgvDepartments.SelectedRows(0).DataBoundItem, Department)
            _logger.LogInfo($"FormDepartments - Delete button clicked for Department: {selectedDepartment.DepartmentName}")

            Dim result = MessageBox.Show($"Are you sure you want to delete the department '{selectedDepartment.DepartmentName}'?{vbCrLf}{vbCrLf}This action cannot be undone.", 
                                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                If _departmentService.DeleteDepartment(selectedDepartment.DepartmentId) Then
                    _logger.LogInfo($"FormDepartments - Department deleted successfully: {selectedDepartment.DepartmentName}")
                    MessageBox.Show("Department deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadDepartments() ' Refresh the list
                Else
                    _logger.LogWarning($"FormDepartments - Failed to delete department: {selectedDepartment.DepartmentName}")
                    MessageBox.Show("Failed to delete department. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                _logger.LogInfo($"FormDepartments - Delete cancelled for Department: {selectedDepartment.DepartmentName}")
            End If
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error in Delete button: {ex.Message}")
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            _logger.LogInfo("FormDepartments - Refresh button clicked")
            LoadDepartments()
            txtSearch.Clear()
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error in Refresh button: {ex.Message}")
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim searchTerm As String = txtSearch.Text.Trim()
            
            If String.IsNullOrEmpty(searchTerm) Then
                dgvDepartments.DataSource = New BindingList(Of Department)(_departments)
                lblStatus.Text = $"Total Departments: {_departments.Count}"
            Else
                Dim filteredDepartments = _departmentService.SearchDepartments(searchTerm)
                dgvDepartments.DataSource = New BindingList(Of Department)(filteredDepartments)
                lblStatus.Text = $"Found: {filteredDepartments.Count} of {_departments.Count} departments"
                
                _logger.LogInfo($"FormDepartments - Search performed: '{searchTerm}', {filteredDepartments.Count} results")
            End If
        Catch ex As Exception
            _logger.LogError($"FormDepartments - Error in search: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvDepartments_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartments.CellDoubleClick
        If e.RowIndex >= 0 Then
            btnEdit_Click(sender, e)
        End If
    End Sub

    Private Sub dgvDepartments_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDepartments.SelectionChanged
        Try
            ' Enable/disable buttons based on selection
            Dim hasSelection = dgvDepartments.SelectedRows.Count > 0
            btnEdit.Enabled = hasSelection
            btnDelete.Enabled = hasSelection
        Catch ex As Exception
            _logger.LogWarning($"FormDepartments - Error in selection changed: {ex.Message}")
        End Try
    End Sub
End Class