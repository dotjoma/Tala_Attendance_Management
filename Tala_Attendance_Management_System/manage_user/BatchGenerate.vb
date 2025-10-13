Public Class BatchGenerate
    Function GetNextUserID() As Integer
        Dim cmd As Odbc.OdbcCommand
        Dim maxLoginID As Integer = 0 ' Variable to store the max login_id

        Try
            'connectDB()
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
            'con.Close()
            GC.Collect()
        End Try

        ' Return the next user ID (incremented)
        Return maxLoginID + 1
    End Function
    Private Sub BatchCreate()
        Dim cmd As Odbc.OdbcCommand

        Try
            connectDB()
            ' Load active users into a DataTable
            Dim userTable As New DataTable()
            Dim adapter As New Odbc.OdbcDataAdapter("SELECT teacherID, firstname AS teacher_name, email FROM teacherinformation WHERE isActive=1 AND user_id IS NULL", con)
            adapter.Fill(userTable)

            ' Check if there are no users available
            If userTable.Rows.Count = 0 Then
                MsgBox("No active users available to generate accounts.", MsgBoxStyle.Information, "No Users")
                Me.Close()
                Return ' Exit the method early
            End If

            ProgressBar1.Maximum = userTable.Rows.Count
            ProgressBar1.Value = 0

            Dim userID As Integer = GetNextUserID() ' Get the next available user ID

            For Each row As DataRow In userTable.Rows
                Dim teacherId As String = row("teacherID").ToString()
                Dim teacherName As String = row("teacher_name").ToString()
                Dim temp As String = teacherName.Replace(" ", "")
                teacherName = temp
                Dim email As String = row("email").ToString
                Dim password As String = GenerateRandomPassword() ' Call your password generation method

                ' Insert a new record into the logins table
                cmd = New Odbc.OdbcCommand("INSERT INTO logins(username, password, role, user_id, created_at) VALUES(?,?,?,?,?)", con)
                With cmd.Parameters
                    .AddWithValue("?", Trim(LCase(teacherName))) ' Using the teacher's name as the username
                    .AddWithValue("?", Trim(password))
                    .AddWithValue("?", "teacher") ' Set role as needed
                    .AddWithValue("?", userID) ' Use the incremented userID
                    .AddWithValue("?", DateAndTime.Now)
                End With
                cmd.ExecuteNonQuery()

                ' Update the teacherinformation table with the newly created user_id
                cmd = New Odbc.OdbcCommand("UPDATE teacherinformation SET user_id=? WHERE teacherID=?", con)
                cmd.Parameters.AddWithValue("?", userID) ' Using the new login ID as the user_id
                cmd.Parameters.AddWithValue("?", teacherId)
                cmd.ExecuteNonQuery()

                ProgressBar1.Value += 1
                userID += 1 ' Increment the user ID for the next user
            Next

            MsgBox("Created users successfully", MsgBoxStyle.Information, "Success")
            Me.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            con.Close()
            GC.Collect()
        End Try

    End Sub
    Private Sub BatchGenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BatchCreate()
    End Sub

    Private Function GenerateRandomPassword() As String
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
        Return New String(password.ToString().OrderBy(Function() random.Next()).ToArray())
    End Function

    Private Sub BatchGenerate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ' Check if the form "AddStudentSection" is open
            Dim manageUser As Form = Application.OpenForms("ManageUser")

            If manageUser IsNot Nothing Then
                ' Call the DefaultSettings method on the open form
                CType(manageUser, ManageUser).DefaultSettings()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class
