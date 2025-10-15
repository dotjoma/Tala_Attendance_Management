Imports System.Data.Odbc

Public Class ChangePassword
    Public Property UserID As Integer = 0
    Public Property Username As String = ""

    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties for professional appearance
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent

        ' Clear all password fields
        txtOldPassword.Clear()
        txtNewPassword.Clear()
        txtConfirmPassword.Clear()

        ' Set focus to old password field
        txtOldPassword.Focus()

        ' Update title with username if provided
        If Not String.IsNullOrEmpty(Username) Then
            Me.Text = $"Change Password - {Username}"
        End If
    End Sub

    Private Function ValidateOldPassword(oldPassword As String) As Boolean
        Try
            Dim dbContext As New DatabaseContext()
            Dim logger As ILogger = LoggerFactory.Instance

            ' Trim the password to match how it's stored in the database
            Dim trimmedPassword As String = Trim(oldPassword)

            ' Log the validation attempt
            logger.LogDebug($"Validating password for UserID: {UserID}")

            ' First, let's get the actual password from database for comparison
            Dim getPasswordQuery As String = "SELECT password FROM logins WHERE login_id = ?"
            Dim storedPassword As Object = dbContext.ExecuteScalar(getPasswordQuery, UserID)

            If storedPassword Is Nothing OrElse IsDBNull(storedPassword) Then
                logger.LogWarning($"No password found for UserID: {UserID}")
                Return False
            End If

            Dim storedPasswordStr As String = storedPassword.ToString()
            logger.LogDebug($"Stored password length: {storedPasswordStr.Length}, Input password length (after trim): {trimmedPassword.Length}")
            logger.LogDebug($"Stored password: {storedPasswordStr}")

            ' Direct string comparison
            Dim passwordsMatch As Boolean = (storedPasswordStr = trimmedPassword)
            logger.LogDebug($"Password match result: {passwordsMatch}")

            Return passwordsMatch
        Catch ex As Exception
            Dim logger As ILogger = LoggerFactory.Instance
            logger.LogError($"Error validating old password: {ex.Message}")
            MessageBox.Show("Error validating old password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function ValidatePasswordComplexity(password As String, ByRef errorMessage As String) As Boolean
        Dim missing As New List(Of String)

        ' Check length
        If password.Length < 13 Then
            missing.Add($"at least 13 characters (currently {password.Length})")
        End If

        ' Check for lowercase
        If Not password.Any(AddressOf Char.IsLower) Then
            missing.Add("lowercase letter (a-z)")
        End If

        ' Check for uppercase
        If Not password.Any(AddressOf Char.IsUpper) Then
            missing.Add("uppercase letter (A-Z)")
        End If

        ' Check for digit
        If Not password.Any(AddressOf Char.IsDigit) Then
            missing.Add("number (0-9)")
        End If

        ' Check for special character
        If Not password.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then
            missing.Add("special character (!@#$%^&*()-_=+[]{}|;:,.<>?/`~)")
        End If

        If missing.Count > 0 Then
            errorMessage = "Password is missing: " & String.Join(", ", missing)
            Return False
        End If

        errorMessage = ""
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate all fields are filled
        If String.IsNullOrWhiteSpace(txtOldPassword.Text) Then
            MessageBox.Show("Please enter your current password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOldPassword.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNewPassword.Text) Then
            MessageBox.Show("Please enter a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPassword.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            MessageBox.Show("Please confirm your new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPassword.Focus()
            Return
        End If

        ' Validate old password
        If Not ValidateOldPassword(txtOldPassword.Text) Then
            MessageBox.Show("Current password is incorrect.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtOldPassword.Focus()
            txtOldPassword.SelectAll()
            Return
        End If

        ' Validate new password complexity
        Dim passwordError As String = ""
        If Not ValidatePasswordComplexity(txtNewPassword.Text, passwordError) Then
            MessageBox.Show(passwordError, "Password Requirements", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPassword.Focus()
            Return
        End If

        ' Validate password confirmation
        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("New password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPassword.Focus()
            txtConfirmPassword.SelectAll()
            Return
        End If

        ' Check if new password is different from old password
        If txtOldPassword.Text = txtNewPassword.Text Then
            MessageBox.Show("New password must be different from your current password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPassword.Focus()
            Return
        End If

        ' Update password in database
        Try
            Dim cmd As Odbc.OdbcCommand
            connectDB()

            cmd = New Odbc.OdbcCommand("UPDATE logins SET password = ? WHERE login_id = ?", con)
            cmd.Parameters.AddWithValue("?", Trim(txtNewPassword.Text))
            cmd.Parameters.AddWithValue("?", UserID)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub chkShowPasswords_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPasswords.CheckedChanged
        Dim showPassword As Boolean = chkShowPasswords.Checked

        txtOldPassword.UseSystemPasswordChar = Not showPassword
        txtNewPassword.UseSystemPasswordChar = Not showPassword
        txtConfirmPassword.UseSystemPasswordChar = Not showPassword
    End Sub

    Private Sub txtNewPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNewPassword.TextChanged
        ' Real-time password strength indicator (optional)
        UpdatePasswordStrengthIndicator()
    End Sub

    Private Sub UpdatePasswordStrengthIndicator()
        Dim password As String = txtNewPassword.Text
        Dim strength As Integer = 0

        ' Calculate strength score
        If password.Length >= 13 Then strength += 1
        If password.Any(AddressOf Char.IsLower) Then strength += 1
        If password.Any(AddressOf Char.IsUpper) Then strength += 1
        If password.Any(AddressOf Char.IsDigit) Then strength += 1
        If password.Any(Function(c) Not Char.IsLetterOrDigit(c)) Then strength += 1

        ' Update strength label
        Select Case strength
            Case 0 To 2
                lblPasswordStrength.Text = "Weak"
                lblPasswordStrength.ForeColor = Color.Red
            Case 3 To 4
                lblPasswordStrength.Text = "Medium"
                lblPasswordStrength.ForeColor = Color.Orange
            Case 5
                lblPasswordStrength.Text = "Strong"
                lblPasswordStrength.ForeColor = Color.Green
        End Select

        ' Show/hide strength indicator
        lblPasswordStrength.Visible = password.Length > 0
    End Sub
End Class