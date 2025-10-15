Imports System.IO
Imports System.IO.Ports
Imports System.Data.Odbc

Public Class LoginForm
    Private port As New SerialPort

    Private Sub bbtnLogin_Click(sender As Object, e As EventArgs) Handles bbtnLogin.Click
        Dim cmd As Odbc.OdbcCommand
        Dim da As New OdbcDataAdapter
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim logger As ILogger = LoggerFactory.Instance

        Try
            logger.LogInfo($"Login attempt for username: {Trim(ttxtUser.Text)}")
            Call connectDB()

            ' First check if username and password are correct (regardless of isActive status)
            cmd = New OdbcCommand("SELECT * FROM Logins WHERE username = ? AND password = ?", con)
            cmd.Parameters.AddWithValue("@username", Trim(ttxtUser.Text))
            cmd.Parameters.AddWithValue("@password", Trim(ttxtPass.Text))
            da.SelectCommand = cmd
            da.Fill(dt)

            logger.LogDebug($"Login query returned {dt.Rows.Count} rows")

            ' Check if user exists with correct credentials
            If dt.Rows.Count > 0 Then
                ' Check if account is active
                Dim isActive As Integer = Convert.ToInt32(dt.Rows(0)("isActive"))
                If isActive = 0 Then
                    logger.LogWarning($"Login attempt for inactive account: {Trim(ttxtUser.Text)}")
                    MessageBox.Show("Your account has been deactivated. Please contact the administrator.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ttxtPass.Clear()
                    ttxtPass.Focus()
                    Return
                End If
                Dim userRole As String = dt.Rows(0)("role").ToString()
                Dim userID As String = dt.Rows(0)("user_id").ToString()

                logger.LogInfo($"Login successful for user: {Trim(ttxtUser.Text)}, Role: {userRole}")

                Select Case userRole.ToLower()
                    Case "admin"
                        ' Get user's full name from logins table
                        Dim currentUser As String = dt.Rows(0)("fullname").ToString()

                        ' If fullname is empty, try to get from teacherinformation
                        If String.IsNullOrWhiteSpace(currentUser) AndAlso Not IsDBNull(userID) AndAlso userID <> "0" Then
                            cmd = New OdbcCommand("SELECT CONCAT(firstname, ' ', lastname) AS user_name FROM teacherinformation WHERE user_id = ? AND isActive=1", con)
                            cmd.Parameters.AddWithValue("?", userID)
                            da.SelectCommand = cmd
                            da.Fill(dt2)

                            If dt2.Rows.Count > 0 Then
                                currentUser = dt2.Rows(0)("user_name").ToString()
                            Else
                                currentUser = "Administrator"
                            End If
                        ElseIf String.IsNullOrWhiteSpace(currentUser) Then
                            currentUser = "Administrator"
                        End If

                        ' Set label with format: "Logged in as: Name (Role)"
                        MainForm.currentUserRole = "Admin"
                        MainForm.lblUser.Text = $"Logged in as: {currentUser} (Admin)"

                        ' Set user role and apply access control
                        MainForm.SetUserRole("Admin")

                        ' Show all controls for admin
                        MainForm.ToolStripSeparator1.Visible = True
                        MainForm.tsManageAccounts.Visible = True
                        logger.LogDebug("Opening MainForm for Admin user")
                        MainForm.Show()

                    Case "hr"
                        ' Get user's full name from logins table
                        Dim currentUser As String = dt.Rows(0)("fullname").ToString()

                        ' If fullname is empty, try to get from teacherinformation
                        If String.IsNullOrWhiteSpace(currentUser) AndAlso Not IsDBNull(userID) AndAlso userID <> "0" Then
                            cmd = New OdbcCommand("SELECT CONCAT(firstname, ' ', lastname) AS user_name FROM teacherinformation WHERE user_id = ? AND isActive=1", con)
                            cmd.Parameters.AddWithValue("?", userID)
                            da.SelectCommand = cmd
                            da.Fill(dt2)

                            If dt2.Rows.Count > 0 Then
                                currentUser = dt2.Rows(0)("user_name").ToString()
                            Else
                                currentUser = "HR User"
                            End If
                        ElseIf String.IsNullOrWhiteSpace(currentUser) Then
                            currentUser = "HR User"
                        End If

                        ' Set label with format: "Logged in as: Name (Role)"
                        MainForm.currentUserRole = "HR"
                        MainForm.lblUser.Text = $"Logged in as: {currentUser} (HR)"

                        ' Set user role and apply access control
                        MainForm.SetUserRole("HR")

                        ' Hide Manage Accounts for HR role
                        MainForm.ToolStripSeparator1.Visible = False
                        MainForm.tsManageAccounts.Visible = False
                        logger.LogDebug("Opening MainForm for HR user")
                        MainForm.Show()

                    Case "attendance"
                        logger.LogDebug("Opening FormAttendanceScanner for Attendance user")
                        FormAttendanceScanner.Show()

                    Case Else
                        logger.LogWarning($"Undefined user role: {userRole} for username: {Trim(ttxtUser.Text)}")
                        MessageBox.Show("User role undefined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select

                ' Clear password field and hide the login form
                ttxtPass.Clear()
                Me.Hide()
            Else
                logger.LogWarning($"Failed login attempt for username: {Trim(ttxtUser.Text)}")
                MessageBox.Show("Incorrect username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ttxtPass.Clear()
                ttxtPass.Focus()
            End If

        Catch ex As Exception
            logger.LogError($"Login error for username: {Trim(ttxtUser.Text)} - {ex.Message}")
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Sub ttxtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles ttxtUser.KeyDown
        ClickEnter(e, bbtnLogin)
    End Sub

    Private Sub ttxtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles ttxtPass.KeyDown
        ClickEnter(e, bbtnLogin)
    End Sub

    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If port.IsOpen Then
            port.Write("3")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        AddUser.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        FormAttendanceScanner.Show()
    End Sub
End Class
