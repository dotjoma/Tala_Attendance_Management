Imports System.Data.Odbc
Imports System.Data.SqlClient

Public Class AddUser
    Public userID As Integer = 0

    ' Function to get the maximum user ID
    Function GetUserID() As Integer
        Dim cmd As Odbc.OdbcCommand
        Dim maxLoginID As Integer = 0 ' Variable to store the max login_id

        Try
            connectDB()
            cmd = New Odbc.OdbcCommand("SELECT MAX(login_id) FROM logins", con)

            ' Execute the command and store the result in maxLoginID
            Dim result = cmd.ExecuteScalar()

            ' Check if result is not null and assign it to maxLoginID
            If Not IsDBNull(result) Then
                maxLoginID = Convert.ToInt32(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            GC.Collect()
            con.Close()
        End Try

        Return maxLoginID
    End Function

    ' Function to check if the username is unique, with an optional userID to exclude from the check
    Private Function IsUsernameUnique(username As String, Optional excludeUserID As Integer = 0) As Boolean
        Try
            connectDB()
            ' Modify the query to check for uniqueness while excluding the current user's username (if updating)
            Dim query As String = "SELECT COUNT(*) FROM logins WHERE username = ? AND login_id <> ? AND isActive=1"
            Dim command As New Odbc.OdbcCommand(query, con)
            command.Parameters.AddWithValue("?", username)
            command.Parameters.AddWithValue("?", excludeUserID) ' Exclude the current user's login_id when updating

            Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
            Return result = 0 ' If count is 0, the username is unique
        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate username: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function


    ' Method to reset the form state
    Private Sub ResetFormState()
        ' Clear all the textboxes
        txtUsername.Clear()
        txtPassword.Clear()
        txtID.Text = "0"

        ' Optionally, clear the combo box
        'cbUsers.SelectedIndex = -1

        ' Reset any other controls as needed (for example, setting default values)
        'cbPermission.SelectedIndex = 0 ' Set a default permission (if applicable)
        btnCancel.Text = "Cancel"

        ' Set any other flags or controls that need resetting
        userID = 0
    End Sub

    Private Sub AddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        If userID = 0 Then
            'loadCBO("SELECT teacherID, 
            '        CONCAT(firstname, ' ', lastname) AS teacher_name 
            '        FROM teacherinformation 
            '        WHERE isActive=1 AND user_id IS NULL", "teacherID", "teacher_name", cbUsers)
        End If
    End Sub
    Private Function ValidatePasswordComplexity(password As String) As Boolean
        If password.Length < 8 Then Return False

        Dim hasLowercase As Boolean = password.Any(AddressOf Char.IsLower)
        Dim hasUppercase As Boolean = password.Any(AddressOf Char.IsUpper)
        Dim hasDigit As Boolean = password.Any(AddressOf Char.IsDigit)
        Dim hasSpecial As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))

        Return hasLowercase AndAlso hasUppercase AndAlso hasDigit AndAlso hasSpecial
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cmd As Odbc.OdbcCommand
        Dim user_id As Integer = GetUserID()

        ' Check if username is unique
        ' The second parameter (excludeUserID) ensures we don't check the current user's username if updating
        If Not IsUsernameUnique(txtUsername.Text, If(userID = 0, 0, userID)) Then
            MessageBox.Show("Username must be unique.", "Duplicate username", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validate password complexity
        If Not ValidatePasswordComplexity(txtPassword.Text) Then
            MessageBox.Show("Password must be at least 8 characters long and include at least one lowercase letter, one uppercase letter, one number, and one special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If fieldChecker(panelContainer) = True Then
            Try
                connectDB()
                If userID = 0 Then
                    ' Insert a new record into the logins table
                    cmd = New Odbc.OdbcCommand("INSERT INTO logins(fullname, username, password, email, address, role, created_at) VALUES(?,?,?,?,?, 'admin', ?)", con)
                    With cmd.Parameters
                        .AddWithValue("?", Trim(txtName.Text))
                        .AddWithValue("?", Trim(txtUsername.Text))
                        .AddWithValue("?", Trim(txtPassword.Text))
                        .AddWithValue("?", Trim(txtEmail.Text))
                        .AddWithValue("?", Trim(txtAddress.Text))
                        '.AddWithValue("?", user_id)
                        .AddWithValue("?", DateAndTime.Now)
                    End With
                    cmd.ExecuteNonQuery()

                    ' Update the teacherinformation table with the newly created user_id
                    'cmd = New Odbc.OdbcCommand("UPDATE teacherinformation SET user_id=? WHERE teacherID=?", con)
                    'cmd.Parameters.AddWithValue("?", user_id) ' Using the new login ID as the user_id
                    'cmd.Parameters.AddWithValue("?", cbUsers.SelectedValue)
                    'cmd.ExecuteNonQuery()

                    MsgBox("Created user successfully", MsgBoxStyle.Information, "Success")
                Else
                    ' Update existing user record in the logins table
                    cmd = New Odbc.OdbcCommand("UPDATE logins SET fullname=?, username=?, password=?, email=?, address=? WHERE login_id=?", con)
                    With cmd.Parameters
                        .AddWithValue("?", Trim(txtName.Text))
                        .AddWithValue("?", Trim(txtUsername.Text))
                        .AddWithValue("?", Trim(txtPassword.Text))
                        .AddWithValue("?", Trim(txtEmail.Text))
                        .AddWithValue("?", Trim(txtAddress.Text))
                        '.AddWithValue("?", LCase(cbPermission.Text))
                        .AddWithValue("?", userID)
                    End With
                    cmd.ExecuteNonQuery()

                    MsgBox("Updated successfully", MsgBoxStyle.Information, "Success")
                    Me.Close()
                End If

            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                con.Close()
                GC.Collect()
            End Try

            ' Reload the combo box and clear fields after save
            'loadCBO("SELECT teacherID, CONCAT(firstname, ' ', lastname) AS teacher_name FROM teacherinformation WHERE isActive=1 AND user_id IS NULL", "teacherID", "teacher_name", cbUsers)
            ClearFields(panelContainer)
            btnCancel.Text = "Close"
            userID = 0
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim passwordLength As Integer = 10
        Dim lowercase As String = "abcdefghijklmnopqrstuvwxyz"
        Dim uppercase As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim digits As String = "0123456789"
        Dim specialChars As String = "!@#$%^&*()-_=+[]{}|;:,.<>?/`~"
        Dim allChars As String = lowercase & uppercase & digits & specialChars
        Dim random As New Random()
        Dim password As New System.Text.StringBuilder()

        ' Ensure at least one character from each set
        password.Append(lowercase(random.Next(0, lowercase.Length)))
        password.Append(uppercase(random.Next(0, uppercase.Length)))
        password.Append(digits(random.Next(0, digits.Length)))
        password.Append(specialChars(random.Next(0, specialChars.Length)))

        ' Fill the rest of the password with random characters
        For i As Integer = 5 To passwordLength
            Dim index As Integer = random.Next(0, allChars.Length)
            password.Append(allChars(index))
        Next

        ' Shuffle the password to mix the guaranteed characters
        txtPassword.Text = New String(password.ToString().OrderBy(Function() random.Next()).ToArray())
    End Sub

    Private Sub cbUsers_SelectedIndexChanged(sender As Object, e As EventArgs) 
    End Sub

    Private Sub cbUsers_Click(sender As Object, e As EventArgs) 
        Try
            If userID > 0 Then
                'cbUsers.Items.Clear()
            End If
            'loadCBO("SELECT teacherID, 
            '    CONCAT(firstname, ' ', lastname) AS teacher_name 
            '    FROM teacherinformation 
            '    WHERE isActive=1 AND user_id IS NULL", "teacherID", "teacher_name", cbUsers)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub AddUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'cbUsers.Enabled = True
        ClearFields(panelContainer)
        txtID.Text = "0"
        userID = 0
        Dim manageUser As ManageUser = TryCast(Application.OpenForms("ManageUser"), ManageUser)
        If manageUser IsNot Nothing Then
            manageUser.DefaultSettings()
        End If
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If txtPassword.UseSystemPasswordChar = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class
