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

        Try
            Call connectDB()

            ' Prepare and execute the command to check login credentials
            cmd = New OdbcCommand("SELECT * FROM Logins WHERE username = ? AND password = ? AND isActive=1", con)
            cmd.Parameters.AddWithValue("@username", Trim(ttxtUser.Text))
            cmd.Parameters.AddWithValue("@password", Trim(ttxtPass.Text))
            da.SelectCommand = cmd
            da.Fill(dt)

            ' Check if user exists
            If dt.Rows.Count > 0 Then
                Dim userRole As String = dt.Rows(0)("role").ToString()
                Dim userID As String = dt.Rows(0)("user_id").ToString()

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
                        
                        ' Show all controls for admin
                        MainForm.ToolStripSeparator1.Visible = True
                        MainForm.tsManageAccounts.Visible = True
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
                        
                        ' Hide Manage Accounts for HR role
                        MainForm.ToolStripSeparator1.Visible = False
                        MainForm.tsManageAccounts.Visible = False
                        MainForm.Show()

                    Case "attendance"
                        FormAttendanceScanner.Show()

                    Case "teacher"
                        ' Prepare command for additional details if user is a teacher
                        cmd = New OdbcCommand("SELECT l.user_id, t.teacherID, CONCAT(t.firstname, ' ', t.lastname) AS teacher_name, profileImg 
                                               FROM logins l JOIN teacherinformation t ON l.user_id = t.user_id 
                                               WHERE l.username = ? AND l.password = ?", con)
                        cmd.Parameters.AddWithValue("@username", Trim(ttxtUser.Text))
                        cmd.Parameters.AddWithValue("@password", Trim(ttxtPass.Text))

                        Using reader As OdbcDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim currentUser As Integer = reader("teacherID")
                                Dim user_id As Integer = reader("user_id")
                                Dim teacherName As String = reader("teacher_name").ToString()
                                Dim profilePic As Byte() = If(Not reader.IsDBNull(reader.GetOrdinal("profileImg")), CType(reader("profileImg"), Byte()), Nothing)

                                ' Display profile picture if available; else use default
                                If profilePic IsNot Nothing Then
                                    Using ms As New MemoryStream(profilePic)
                                        TeacherSchedule.pbProfile.Image = Image.FromStream(ms)
                                    End Using
                                Else
                                    TeacherSchedule.pbProfile.Image = My.Resources.default_image ' Use a default image resource here
                                End If

                                ' Set form variables
                                TeacherSchedule.currentUser = currentUser
                                TeacherSchedule.currentUserID = user_id
                                TeacherSchedule.labelTeacherName.Text = teacherName
                                TeacherSchedule.IsLoggedIn = True
                                TeacherSchedule.Show()
                            End If
                        End Using

                    Case Else
                        MessageBox.Show("User role undefined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select

                ' Clear password field and hide the login form
                ttxtPass.Clear()
                Me.Hide()
            Else
                MessageBox.Show("Incorrect username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ttxtPass.Clear()
                ttxtPass.Focus()
            End If

        Catch ex As Exception
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
