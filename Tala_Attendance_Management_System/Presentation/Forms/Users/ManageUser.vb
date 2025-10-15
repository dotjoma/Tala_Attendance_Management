Imports System.Data.SqlClient

Public Class ManageUser
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Public Sub DefaultSettings()
        dgvManageUser.Tag = 0
        dgvManageUser.RowTemplate.Height = 50
        dgvManageUser.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvManageUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvManageUser.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvManageUser.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 15)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        ' Disable alternating row styles to ensure consistent font style
        dgvManageUser.AlternatingRowsDefaultCellStyle = dgvManageUser.DefaultCellStyle

        ' Set row font to Segoe UI for all rows
        dgvManageUser.DefaultCellStyle.Font = New Font("Segoe UI", 14)
        dgvManageUser.DefaultCellStyle.ForeColor = Color.Black

        dgvManageUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvManageUser.AutoGenerateColumns = False

        FormHelper.LoadDataGridView("SELECT login_id, fullname AS full_name, email, address, created_at, role, 
                 username, REPEAT('*', CHAR_LENGTH(password)) AS password, 
                 CASE WHEN isActive = 1 THEN 'Active' ELSE 'Inactive' END AS status, isActive
                 FROM logins", dgvManageUser)

        cbFilter.SelectedIndex = 0

    End Sub
    Private Sub ManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'AddUserButton.ShowDialog()
        AddUser.ShowDialog()
    End Sub

    Private Sub dgvManageUser_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvManageUser.DataBindingComplete
        dgvManageUser.CurrentCell = Nothing
        dgvManageUser.Tag = 0 ' Reset tag when data is reloaded
        btnDelete.BackgroundImage = My.Resources.enable_default_40x40
        btnDelete.Text = "&Set User" ' Reset button text
        btnDelete.ForeColor = Color.Black
    End Sub

    Private Sub dgvManageUser_SelectionChanged(sender As Object, e As EventArgs) Handles dgvManageUser.SelectionChanged
        Try
            If dgvManageUser.SelectedRows.Count > 0 AndAlso dgvManageUser.SelectedRows(0).Cells("login_id").Value IsNot Nothing Then
                ' Update Tag with the login_id of the selected row
                Dim loginIdValue = dgvManageUser.SelectedRows(0).Cells("login_id").Value
                If Not IsDBNull(loginIdValue) Then
                    dgvManageUser.Tag = Convert.ToInt32(loginIdValue)
                End If

                ' Update delete button text based on user status
                UpdateDeleteButtonText()
            Else
                dgvManageUser.Tag = 0
                btnDelete.Text = "&Set User"
                btnDelete.BackgroundImage = My.Resources.enable_default_40x40
                btnDelete.ForeColor = Color.Black
            End If
        Catch ex As Exception
            ' Ignore errors during initial load
            dgvManageUser.Tag = 0
            btnDelete.Text = "&Set User"
            btnDelete.BackgroundImage = My.Resources.enable_default_40x40
            btnDelete.ForeColor = Color.Black
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            loadDGV("SELECT login_id, fullname AS full_name, email, address, created_at, role, 
                 username, REPEAT('*', CHAR_LENGTH(password)) AS password,
                 CASE WHEN isActive = 1 THEN 'Active' ELSE 'Inactive' END AS status, isActive
                 FROM logins", dgvManageUser, "username", "fullname", "email", txtSearch.Text.Trim)
        Else
            loadDGV("SELECT login_id, fullname AS full_name, email, address, created_at, role, 
                 username, REPEAT('*', CHAR_LENGTH(password)) AS password,
                 CASE WHEN isActive = 1 THEN 'Active' ELSE 'Inactive' END AS status, isActive
                 FROM logins", dgvManageUser)
        End If
    End Sub

    Private Sub cbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFilter.SelectedIndexChanged
        If cbFilter.SelectedIndex <> -1 Then
            Dim query As String

            Select Case cbFilter.SelectedIndex
                Case 0 ' All
                    query = "SELECT login_id, fullname AS full_name, email, address, created_at, role, username, REPEAT('*', CHAR_LENGTH(password)) AS password, CASE WHEN isActive = 1 THEN 'Active' ELSE 'Inactive' END AS status, isActive FROM logins"
                Case 1 ' Admin
                    query = "SELECT login_id, fullname AS full_name, email, address, created_at, role, username, REPEAT('*', CHAR_LENGTH(password)) AS password, CASE WHEN isActive = 1 THEN 'Active' ELSE 'Inactive' END AS status, isActive FROM logins WHERE role = 'admin'"
                Case 2 ' HR
                    query = "SELECT login_id, fullname AS full_name, email, address, created_at, role, username, REPEAT('*', CHAR_LENGTH(password)) AS password, CASE WHEN isActive = 1 THEN 'Active' ELSE 'Inactive' END AS status, isActive FROM logins WHERE role = 'hr'"
                Case Else
                    Return
            End Select

            loadDGV(query, dgvManageUser)
        End If
    End Sub

    Private Sub loadUserAccount(id As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim dt As New DataTable
        Dim da As New Odbc.OdbcDataAdapter

        Try
            Call connectDB()
            cmd = New Odbc.OdbcCommand("SELECT login_id, username, password, fullname, email, address,role 
                                        FROM logins 
                                        WHERE login_id=?", con)
            cmd.Parameters.AddWithValue("?", id)
            da.SelectCommand = cmd
            da.Fill(dt)

            ' Load user data into AddUser form
            AddUser.txtUsername.Text = dt.Rows(0)("username").ToString
            AddUser.txtPassword.Text = dt.Rows(0)("password").ToString
            AddUser.txtName.Text = dt.Rows(0)("fullname").ToString
            AddUser.txtEmail.Text = dt.Rows(0)("email").ToString
            AddUser.txtAddress.Text = dt.Rows(0)("address").ToString

            ' Set the role in ComboBox
            Dim userRole As String = dt.Rows(0)("role").ToString().ToLower()
            Dim roleIndex As Integer = AddUser.cboUserRole.FindStringExact(userRole)
            If roleIndex >= 0 Then
                AddUser.cboUserRole.SelectedIndex = roleIndex
            End If

            AddUser.userID = dt.Rows(0)("login_id").ToString
            AddUser.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Sub dgvManageUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManageUser.CellClick
        Try
            _logger.LogDebug($"CellClick Event - RowIndex: {e.RowIndex}, ColumnIndex: {e.ColumnIndex}")

            If e.RowIndex < 0 Then
                _logger.LogDebug("CellClick ignored - header row clicked")
                Exit Sub
            End If

            ' Get login_id from the selected row by column name, not index
            Dim cellValue = dgvManageUser.Rows(e.RowIndex).Cells("login_id").Value

            ' Log detailed information about the cell value
            _logger.LogDebug($"Cell Value Details - IsNothing: {cellValue Is Nothing}, IsDBNull: {IsDBNull(cellValue)}, Value: {If(cellValue Is Nothing, "NULL", cellValue.ToString())}, Type: {If(cellValue Is Nothing, "NULL", cellValue.GetType().Name)}")

            ' Log all cell values in the row for debugging
            Dim rowData As String = ""
            For Each cell As DataGridViewCell In dgvManageUser.Rows(e.RowIndex).Cells
                rowData &= $"{cell.OwningColumn.Name}={If(cell.Value Is Nothing, "NULL", cell.Value.ToString())}; "
            Next
            _logger.LogDebug($"Full Row Data: {rowData}")

            If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) Then
                dgvManageUser.Tag = Convert.ToInt32(cellValue)
                _logger.LogInfo($"Tag set successfully to: {dgvManageUser.Tag}")
            Else
                dgvManageUser.Tag = 0
                _logger.LogWarning($"Cell value is NULL or DBNull, Tag set to 0")
            End If

            ' Handle Edit button click
            If dgvManageUser.Columns(e.ColumnIndex).Name = "EditBtn" Then
                Dim loginId As Integer = dgvManageUser.Rows(e.RowIndex).Cells("login_id").Value
                ' Show the EditUserForm with loginId for editing
                loadUserAccount(loginId)
            End If

            ' Handle Delete/Enable/Disable button click
            If dgvManageUser.Columns(e.ColumnIndex).Name = "deleteBtn" Then
                Dim loginId As Integer = dgvManageUser.Rows(e.RowIndex).Cells("login_id").Value
                Dim isActive As Boolean = Convert.ToBoolean(dgvManageUser.Rows(e.RowIndex).Cells("isActive").Value)

                Dim actionText As String = If(isActive, "disable", "enable")
                Dim result As DialogResult = MessageBox.Show($"Are you sure you want to {actionText} this user?", $"{actionText.Substring(0, 1).ToUpper()}{actionText.Substring(1)} User", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ToggleUserStatus(loginId)
                End If
            End If
        Catch ex As Exception
            _logger.LogError("Error in dgvManageUser_CellClick", ex)
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateDeleteButtonText()
        Try
            If dgvManageUser.SelectedRows.Count > 0 Then
                Dim isActiveValue = dgvManageUser.SelectedRows(0).Cells("isActive").Value
                If Not IsDBNull(isActiveValue) Then
                    Dim isActive As Boolean = Convert.ToBoolean(isActiveValue)
                    If isActive Then
                        btnDelete.BackgroundImage = My.Resources.block_40x40
                        btnDelete.Text = "&Disable User"
                        btnDelete.ForeColor = Color.Red
                        ' Keep existing icon or use default delete icon
                    Else
                        btnDelete.BackgroundImage = My.Resources.enable
                        btnDelete.Text = "&Enable User"
                        btnDelete.ForeColor = Color.Green
                        ' Keep existing icon or use default delete icon
                    End If
                End If
            End If
        Catch ex As Exception
            btnDelete.Text = "&Set User"
            btnDelete.ForeColor = Color.Black
            btnDelete.BackgroundImage = My.Resources.enable_default_40x40
        End Try
    End Sub

    Private Sub ToggleUserStatus(loginId As Integer)
        Dim cmd As Odbc.OdbcCommand

        Try
            connectDB()

            ' Check if this is a protected user (ID < 3)
            cmd = New Odbc.OdbcCommand("SELECT login_id, isActive FROM logins WHERE login_id=?", con)
            cmd.Parameters.AddWithValue("?", loginId)
            Dim myreader As Odbc.OdbcDataReader
            myreader = cmd.ExecuteReader

            Dim excemptedID As Integer = 0
            Dim currentStatus As Boolean = False

            If myreader.Read Then
                excemptedID = Convert.ToInt32(myreader("login_id"))
                currentStatus = Convert.ToBoolean(myreader("isActive"))
            End If
            myreader.Close()

            If excemptedID < 3 Then
                MessageBox.Show("This user cannot be disabled or enabled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Toggle the status
            Dim newStatus As Integer = If(currentStatus, 0, 1)
            Dim actionText As String = If(currentStatus, "disabled", "enabled")

            Dim query As String = "UPDATE logins SET isActive=? WHERE login_id = ?"
            cmd = New Odbc.OdbcCommand(query, con)
            cmd.Parameters.AddWithValue("?", newStatus)
            cmd.Parameters.AddWithValue("?", loginId)
            cmd.ExecuteNonQuery()

            MessageBox.Show($"User {actionText} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DefaultSettings()

        Catch ex As Exception
            MessageBox.Show("Error updating user status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Val(dgvManageUser.Tag) = 0 Then
            MessageBox.Show("Please select a record that you want to edit", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to edit this user?", "Edit User", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            loadUserAccount(Val(dgvManageUser.Tag))
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Val(dgvManageUser.Tag) = 0 Then
            MessageBox.Show("Please select a user to enable/disable", "Enable/Disable User", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow = dgvManageUser.SelectedRows(0)
            Dim isActive As Boolean = Convert.ToBoolean(selectedRow.Cells("isActive").Value)
            Dim actionText As String = If(isActive, "disable", "enable")

            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to {actionText} this user?", $"{actionText.Substring(0, 1).ToUpper()}{actionText.Substring(1)} User", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ToggleUserStatus(Val(dgvManageUser.Tag))
            End If
        Catch ex As Exception
            MessageBox.Show("Error processing request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        If Val(dgvManageUser.Tag) = 0 Then
            MessageBox.Show("Please select a user to change password for.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Get user information for the selected user
            Dim selectedUserID As Integer = Val(dgvManageUser.Tag)
            Dim username As String = ""

            ' Get username from selected row
            If dgvManageUser.SelectedRows.Count > 0 Then
                username = dgvManageUser.SelectedRows(0).Cells("username").Value.ToString()
            End If

            ' Create and show change password form
            Dim changePasswordForm As New ChangePassword()
            changePasswordForm.UserID = selectedUserID
            changePasswordForm.Username = username

            If changePasswordForm.ShowDialog() = DialogResult.OK Then
                ' Password was changed successfully, refresh the grid if needed
                DefaultSettings()
            End If

        Catch ex As Exception
            MessageBox.Show("Error opening change password dialog: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class