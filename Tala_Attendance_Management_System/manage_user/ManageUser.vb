Imports System.Data.SqlClient

Public Class ManageUser
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

        loadDGV("SELECT login_id, fullname AS full_name, email, address, created_at, role, 
                 username, REPEAT('*', CHAR_LENGTH(password)) AS password  
                 FROM logins
                 WHERE isActive=1", dgvManageUser)

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
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            loadDGV("SELECT login_id, fullname AS full_name, email, address, created_at, role, 
                 username, REPEAT('*', CHAR_LENGTH(password)) AS password  
                 FROM logins
                 WHERE isActive=1 ", dgvManageUser, "username", "CONCAT(firstname, ' ', lastname)", "email", txtSearch.Text.Trim)
        Else
            loadDGV("SELECT login_id, fullname AS full_name, email, address, created_at, role, 
                 username, REPEAT('*', CHAR_LENGTH(password)) AS password  
                 FROM logins 
                 WHERE isActive=1 ", dgvManageUser)
        End If
    End Sub

    Private Sub cbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFilter.SelectedIndexChanged
        If cbFilter.SelectedIndex <> -1 Then
            loadDGV("SELECT login_id, fullname AS full_name, email, address, created_at, role, 
                 username, REPEAT('*', CHAR_LENGTH(password)) AS password  
                 FROM logins 
                 WHERE isActive=1 AND role = '" & LCase(cbFilter.Text) & "'", dgvManageUser)
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

            'AddUser.cbUsers.Enabled = False
            'AddUser.cbUsers.DataSource = Nothing
            'AddUser.cbUsers.Items.Clear()
            'AddUser.cbUsers.Items.Add(dt.Rows(0)("teacher_name").ToString)
            'AddUser.cbUsers.SelectedIndex = 0
            'AddUser.Label3.Visible = False
            AddUser.txtUsername.Text = dt.Rows(0)("username").ToString
            AddUser.txtPassword.Text = dt.Rows(0)("password").ToString
            AddUser.txtName.Text = dt.Rows(0)("fullname").ToString
            AddUser.txtEmail.Text = dt.Rows(0)("email").ToString
            AddUser.txtAddress.Text = dt.Rows(0)("address").ToString
            'AddUser.cbPermission.Text = dt.Rows(0)("role").ToString
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
            dgvManageUser.Tag = dgvManageUser.Item(0, e.RowIndex).Value

            If e.RowIndex < 0 Then Exit Sub ' Ignore clicks on headers

            ' Handle Edit button click
            If dgvManageUser.Columns(e.ColumnIndex).Name = "EditBtn" Then
                Dim loginId As Integer = dgvManageUser.Rows(e.RowIndex).Cells("login_id").Value
                ' Show the EditUserForm with loginId for editing
                loadUserAccount(loginId)
            End If

            ' Handle Delete button click
            If dgvManageUser.Columns(e.ColumnIndex).Name = "deleteBtn" Then
                Dim loginId As Integer = dgvManageUser.Rows(e.RowIndex).Cells("login_id").Value
                ' Confirm before deleting
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    ' Call DeleteUser method
                    DeleteUser(loginId)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteUser(loginId As Integer)
        Dim cmd As Odbc.OdbcCommand

        Try
            connectDB()
            cmd = New Odbc.OdbcCommand("SELECT login_id FROM logins WHERE login_id=?", con)
            cmd.Parameters.AddWithValue("?", loginId)
            Dim myreader As Odbc.OdbcDataReader
            myreader = cmd.ExecuteReader

            Dim excemptedID As Integer = 0

            If myreader.Read Then
                excemptedID = Convert.ToInt32(myreader("login_id"))
            End If

            If excemptedID < 3 Then
                MessageBox.Show("This user cannot be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim query As String = "UPDATE logins SET isActive=0 WHERE login_id = ?"
            ' Execute the delete query with loginId parameter
            cmd = New Odbc.OdbcCommand(query, con)
            cmd.Parameters.AddWithValue("?", loginId)
            cmd.ExecuteNonQuery()

            'cmd = New Odbc.OdbcCommand("SELECT user_id FROM logins WHERE login_id=?", con)
            'cmd.Parameters.AddWithValue("?", loginId)
            'Dim myreader As Odbc.OdbcDataReader
            'myreader = cmd.ExecuteReader

            'Dim user_id As Integer = 0
            '
            'If myreader.Read Then
            '    user_id = Convert.ToInt32(myreader("user_id"))
            'End If

            'Dim sql As String = "UPDATE teacherinformation SET user_id=null WHERE user_id = ?"
            '' Execute the delete query with loginId parameter
            'Dim updateCmd As New Odbc.OdbcCommand(sql, con)
            'updateCmd.Parameters.AddWithValue("?", user_id)
            'updateCmd.ExecuteNonQuery()

            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DefaultSettings()
        Catch ex As Exception
            MessageBox.Show("Error deleting user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            MessageBox.Show("Please select a record that you want to delete", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            DeleteUser(Val(dgvManageUser.Tag))
        End If
    End Sub


End Class