Imports System.Data.Odbc

Public Class FormEditAttendance
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    
    Public Property AttendanceId As Integer
    Public Property TeacherName As String
    Public Property AttendanceDate As Date
    Public Property TimeIn As DateTime?
    Public Property TimeOut As DateTime?
    
    Private Sub FormEditAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title and labels
        Me.Text = "Edit Attendance Record"
        lblTeacherName.Text = $"Teacher: {TeacherName}"
        lblDate.Text = $"Date: {AttendanceDate:MMMM dd, yyyy}"
        
        ' Set time pickers
        If TimeIn.HasValue Then
            dtpTimeIn.Value = TimeIn.Value
            dtpTimeIn.Checked = True
        Else
            dtpTimeIn.Checked = False
        End If
        
        If TimeOut.HasValue Then
            dtpTimeOut.Value = TimeOut.Value
            dtpTimeOut.Checked = True
        Else
            dtpTimeOut.Checked = False
        End If
        
        _logger.LogInfo($"FormEditAttendance loaded for attendance ID: {AttendanceId}")
    End Sub
    
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Validate that at least one time is set
            If Not dtpTimeIn.Checked AndAlso Not dtpTimeOut.Checked Then
                MessageBox.Show("Please set at least Time In or Time Out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            
            ' Confirm the edit
            Dim message As String = $"Are you sure you want to update this attendance record?{vbCrLf}{vbCrLf}" &
                                   $"Teacher: {TeacherName}{vbCrLf}" &
                                   $"Date: {AttendanceDate:MMMM dd, yyyy}{vbCrLf}" &
                                   $"Time In: {If(dtpTimeIn.Checked, dtpTimeIn.Value.ToString("hh:mm tt"), "Not Set")}{vbCrLf}" &
                                   $"Time Out: {If(dtpTimeOut.Checked, dtpTimeOut.Value.ToString("hh:mm tt"), "Not Set")}"
            
            If MessageBox.Show(message, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If
            
            ' Update the database
            connectDB()
            
            Dim query As String = "UPDATE attendance_record SET "
            Dim params As New List(Of Object)
            
            If dtpTimeIn.Checked Then
                query &= "arrivalTime = ?"
                params.Add(dtpTimeIn.Value.ToString("HH:mm:ss"))
            Else
                query &= "arrivalTime = NULL"
            End If
            
            If dtpTimeOut.Checked Then
                query &= ", departureTime = ?"
                params.Add(dtpTimeOut.Value.ToString("HH:mm:ss"))
            Else
                query &= ", departureTime = NULL"
            End If
            
            query &= " WHERE attendanceID = ?"
            params.Add(AttendanceId)
            
            Dim cmd As New OdbcCommand(query, con)
            For Each param In params
                cmd.Parameters.AddWithValue("?", param)
            Next
            
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            
            If rowsAffected > 0 Then
                ' Log the audit trail
                Dim userName As String = MainForm.lblUser.Text
                AuditLogger.Instance.LogUpdate(userName, "Attendance",
                    $"Updated attendance record ID {AttendanceId} for {TeacherName} on {AttendanceDate:yyyy-MM-dd}")

                _logger.LogInfo($"Attendance record {AttendanceId} updated successfully by {userName}")
                MessageBox.Show("Attendance record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to update attendance record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            
        Catch ex As Exception
            _logger.LogError($"Error updating attendance record: {ex.Message}")
            MessageBox.Show("Error updating attendance record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
    
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
