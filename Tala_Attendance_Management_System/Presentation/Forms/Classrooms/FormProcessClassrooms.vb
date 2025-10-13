Public Class FormProcessClassrooms
    Public roomID As Integer = 0

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        txtRoom.Clear()
        txtBuilding.Clear()
        txtDeviceID.Clear()
        roomID = 0
    End Sub

    Private Sub FormProcessClassrooms_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' Function to check if the section_name is unique for the given year_level
    Private Function IsDeviceIdUnique(classroom_id As String, Optional excludeDeviceID As Integer = 0) As Boolean
        Try
            connectDB()
            ' Modify the query to check for uniqueness while excluding the current user's username (if updating)
            Dim query As String = "SELECT COUNT(*) FROM classrooms WHERE isActive=1 AND classroom_id = ? AND id <> ?"
            Dim command As New Odbc.OdbcCommand(query, con)
            command.Parameters.AddWithValue("?", classroom_id)
            command.Parameters.AddWithValue("?", excludeDeviceID)

            Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
            Return result = 0 ' If count is 0, the username is unique
        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate device ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function

    Private Function IsClassroomUnique(location As String, classroomName As String, Optional excludeRoomID As Integer = 0) As Boolean
        Try
            connectDB()

            ' Query to check for duplicate location and classroom name
            Dim query As String = "SELECT COUNT(*) FROM classrooms WHERE isActive=1 AND location = ? AND classroom_name = ? AND id <> ?"
            Dim command As New Odbc.OdbcCommand(query, con)
            command.Parameters.AddWithValue("?", location)
            command.Parameters.AddWithValue("?", classroomName)
            command.Parameters.AddWithValue("?", excludeRoomID)

            Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
            Return result = 0 ' If count is 0, the combination is unique
        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate classroom: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim location As String = txtBuilding.Text.Trim()
        Dim classroomName As String = txtRoom.Text.Trim()
        Dim deviceID As String = txtDeviceID.Text.Trim()

        ' Validate input fields
        If String.IsNullOrEmpty(location) Or String.IsNullOrEmpty(classroomName) Or String.IsNullOrEmpty(deviceID) Then
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        If Not IsNumeric(deviceID) Then
            MessageBox.Show("Device ID must be a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not IsDeviceIdUnique(deviceID, If(roomID = 0, 0, roomID)) Then
            MessageBox.Show("Device ID must be unique.", "Duplicate Device ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the classroom is unique for the given location
        If Not IsClassroomUnique(location, classroomName, If(roomID = 0, 0, roomID)) Then
            MessageBox.Show("A classroom with the same name already exists in this location.", "Duplicate Classroom", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            connectDB()

            If roomID = 0 Then
                ' Insert new classroom
                Dim insertCmd As New Odbc.OdbcCommand("INSERT INTO classrooms (classroom_id, location, classroom_name) VALUES (?, ?, ?)", con)
                insertCmd.Parameters.AddWithValue("?", deviceID)
                insertCmd.Parameters.AddWithValue("?", location)
                insertCmd.Parameters.AddWithValue("?", classroomName)
                insertCmd.ExecuteNonQuery()
                MessageBox.Show("Classroom added successfully.", "Success")
            Else
                ' Update existing classroom
                Dim updateCmd As New Odbc.OdbcCommand("UPDATE classrooms SET classroom_id = ?, location = ?, classroom_name = ? WHERE id = ?", con)
                updateCmd.Parameters.AddWithValue("?", deviceID)
                updateCmd.Parameters.AddWithValue("?", location)
                updateCmd.Parameters.AddWithValue("?", classroomName)
                updateCmd.Parameters.AddWithValue("?", roomID)
                updateCmd.ExecuteNonQuery()
                MessageBox.Show("Classroom updated successfully.", "Success")
            End If

            ' Reset form fields
            txtRoom.Clear()
            txtBuilding.Clear()
            txtDeviceID.Clear()
            roomID = 0
            FormClassroom.DefaultSettings()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub


    Private Sub FormProcessClassrooms_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim classroom As FormClassroom = TryCast(Application.OpenForms("FormClassroom"), FormClassroom)
        If classroom IsNot Nothing Then
            classroom.DefaultSettings()
        End If
    End Sub
End Class