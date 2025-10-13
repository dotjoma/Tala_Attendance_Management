Imports System.Data.Odbc
Imports System.Resources
Module myModule
    Public con As Odbc.OdbcConnection
    'Public port As New SerialPort("COM3", 9600) ' Replace "COM3" with the appropriate COM port for your Arduino Uno

    Public btnItemsClicked As Integer = 0 'for Class Schedule form to determine if its for students or teachers
    Public sectionListGradeID As Integer = 0
    Public Sub connectDB()
        Try
            con = New Odbc.OdbcConnection("DSN=tala_ams")
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function IsUsernameUnique(username As String) As Boolean
        Try
            connectDB() ' Call your connection function

            ' Query to check for duplicate user name
            Dim query As String = "SELECT COUNT(*) FROM logins WHERE username = ? AND isActive=1"
            Dim command As New OdbcCommand(query, con)
            command.Parameters.AddWithValue("?", username)

            ' Execute query and check if count > 0 (duplicate found)
            Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
            If result > 0 Then
                Return False ' Duplicate user name found
            Else
                Return True ' user name is unique
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate username: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function
    Public Sub loadDGV(ByVal sql As String, ByVal dgv As DataGridView, Optional ByVal fieldname As String = "", Optional ByVal fieldnametwo As String = "", Optional ByVal fieldnamethree As String = "", Optional ByVal value As String = "")

        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable

        Try
            Call connectDB()
            If fieldname.Length <> 0 Then
                sql = sql + " AND (" + fieldname + " LIKE ? OR " + fieldnametwo + " LIKE ? OR " + fieldnamethree + " LIKE ?)"
                value = "%" + value + "%"
            End If
            cmd = New Odbc.OdbcCommand(sql, con)
            For i As Integer = 1 To 3
                cmd.Parameters.AddWithValue("@", value)
            Next
            da.SelectCommand = cmd
            da.Fill(dt)
            dgv.DataSource = dt
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Public Sub loadCBO(ByVal query As String, ByVal id As String, ByVal display As String, ByVal cbo As ComboBox)
        Dim cmd As OdbcCommand
        Dim da As New OdbcDataAdapter()
        Dim dt As New DataTable()

        Try
            connectDB()
            cmd = New OdbcCommand(query, con)
            da.SelectCommand = cmd
            da.Fill(dt)
            cbo.DataSource = dt
            cbo.ValueMember = id
            cbo.DisplayMember = display
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Function fieldChecker(ByVal pnl As Panel) As Boolean
        For Each obj As Control In pnl.Controls
            If TypeOf obj Is TextBox OrElse TypeOf obj Is ComboBox Then
                If String.IsNullOrEmpty(obj.Text.Trim()) Then
                    fieldChecker = False
                    MsgBox("Please fill up every field in the form.", vbCritical, "Warning")
                    obj.Focus()
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function

    Public Sub ClearFields(ByVal container As Control)
        For Each obj As Control In container.Controls
            If TypeOf obj Is TextBox Then
                DirectCast(obj, TextBox).Text = ""
            ElseIf TypeOf obj Is ComboBox Then
                DirectCast(obj, ComboBox).SelectedIndex = -1
            ElseIf TypeOf obj Is PictureBox Then
                DirectCast(obj, PictureBox).Image = My.Resources.default_image
            End If
        Next
    End Sub

    Public Sub ClickEnter(ByVal e As KeyEventArgs, ByVal btn As Button)
        If e.KeyCode = Keys.Enter Then
            btn.PerformClick()
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True
    End Sub

End Module
