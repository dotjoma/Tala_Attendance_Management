Imports System.Data.Odbc

Public Class UserSettings
    Public currentUserID As Integer = 0
    Private currentUsername As String = String.Empty ' Variable to store the current username

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' Function to check if the username is unique (excluding the current user's ID)
    Private Function getUniqueUser(username As String, Optional excludeUserID As Integer = 0) As Boolean
        Try
            connectDB()
            ' Modify the query to check for uniqueness while excluding the current user's username (if updating)
            Dim query As String = "SELECT COUNT(*) FROM logins WHERE username = ? AND login_id <> ?"
            Dim command As New Odbc.OdbcCommand(query, con)
            command.Parameters.AddWithValue("?", username)
            command.Parameters.AddWithValue("?", excludeUserID)

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

    ' Function to validate the current password
    Private Function ValidateCurrentPassword(currentPassword As String) As Boolean
        Try
            connectDB()
            Dim cmd As New Odbc.OdbcCommand("SELECT password FROM logins WHERE user_id = ?", con)
            cmd.Parameters.AddWithValue("?", TeacherSchedule.currentUserID)
            Dim storedPassword As String = cmd.ExecuteScalar()?.ToString()
            Return (storedPassword = currentPassword) ' Assuming passwords are stored in plain text (Hashing recommended)
        Catch ex As Exception
            MsgBox("An error occurred while validating the current password: " & ex.Message)
            Return False
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function

    ' Function to load account details, including the current username
    Private Sub LoadAccountDetails()
        Try
            connectDB()
            Dim cmd As New Odbc.OdbcCommand("SELECT username FROM logins WHERE user_id = ?", con)
            cmd.Parameters.AddWithValue("?", TeacherSchedule.currentUserID)
            Dim myreader As Odbc.OdbcDataReader = cmd.ExecuteReader()
            If myreader.Read() Then
                txtUsername.Text = myreader("username")
                currentUsername = txtUsername.Text ' Store the current username for later comparison
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    ' Function to update the account settings
    Private Sub UpdateAccountSettings(newPassword As String, username As String)
        Try
            connectDB()
            Dim cmd As New Odbc.OdbcCommand("UPDATE logins SET username = ?, password = ? WHERE user_id = ?", con)
            cmd.Parameters.AddWithValue("?", username)
            cmd.Parameters.AddWithValue("?", newPassword) ' Remember to hash the new password before storing it
            cmd.Parameters.AddWithValue("?", TeacherSchedule.currentUserID)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Function ValidatePasswordComplexity(password As String) As Boolean
        If password.Length < 8 Then Return False

        Dim hasLowercase As Boolean = password.Any(AddressOf Char.IsLower)
        Dim hasUppercase As Boolean = password.Any(AddressOf Char.IsUpper)
        Dim hasDigit As Boolean = password.Any(AddressOf Char.IsDigit)
        Dim hasSpecial As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))

        Return hasLowercase AndAlso hasUppercase AndAlso hasDigit AndAlso hasSpecial
    End Function


    ' The Save button click event handler
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate user input
        If String.IsNullOrWhiteSpace(txtCurrentPassword.Text) Then
            MsgBox("Please enter your current password.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MsgBox("Please enter your username.")
            Return
        End If

        ' Validate username length
        If txtUsername.Text.Length < 8 Then
            MsgBox("Username must be at least 8 characters long.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNewPassword.Text) Then
            MsgBox("Please enter a new password.")
            Return
        End If

        ' Validate password complexity
        If Not ValidatePasswordComplexity(txtNewPassword.Text) Then
            MsgBox("Password must be at least 8 characters long and include at least one lowercase letter, one uppercase letter, one number, and one special character.")
            Return
        End If

        If txtNewPassword.Text <> txtConfirmNewPassword.Text Then
            MsgBox("New password and confirm password do not match.")
            Return
        End If

        ' Validate current password
        If Not ValidateCurrentPassword(txtCurrentPassword.Text) Then
            MsgBox("Current password is incorrect.")
            Return
        End If

        ' Check if the username is unique only if the username is being changed
        If txtUsername.Text <> currentUsername Then
            If Not getUniqueUser(txtUsername.Text, If(currentUserID = 0, 0, currentUserID)) Then
                MessageBox.Show("Username must be unique.", "Duplicate username", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        ' Update the password and username
        Try
            If fieldChecker(Panel6) = True Then
                UpdateAccountSettings(txtNewPassword.Text, txtUsername.Text)
                MsgBox("Account information has been successfully changed.")
                ClearFields(Panel6)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("An error occurred while updating the account information: " & ex.Message)
        End Try
    End Sub


    ' Form load event
    Private Sub UserSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the current account details including the username
        LoadAccountDetails()
    End Sub

    ' Checkbox to show/hide password functionality
    Private Sub chkShow_CheckedChanged(sender As Object, e As EventArgs) Handles chkShow.CheckedChanged
        If chkShow.Checked Then
            If txtNewPassword.UseSystemPasswordChar Then
                txtNewPassword.UseSystemPasswordChar = False
                txtConfirmNewPassword.UseSystemPasswordChar = False
            End If
        Else
            txtConfirmNewPassword.UseSystemPasswordChar = True
            txtNewPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class
