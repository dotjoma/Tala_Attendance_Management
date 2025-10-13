Imports System.Data.Odbc
Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class TeacherSchedule

    Public currentUser As Integer
    Public currentUserID As Integer
    Public currentChild As Form
    Public currentButton As Button
    Public Shared IsLoggedIn As Boolean = False

    Private Sub OpenForm(ByVal childForm As Form, ByVal isMaximized As Boolean)
        Try
            ' Close the currently open child form if it exists
            If currentChild IsNot Nothing Then
                currentChild.Close()
            End If

            ' Assign the new child form
            currentChild = childForm

            ' Set the form properties
            childForm.FormBorderStyle = FormBorderStyle.None
            childForm.Dock = DockStyle.Fill
            childForm.WindowState = If(isMaximized, FormWindowState.Maximized, FormWindowState.Normal)

            ' Add the child form to the panel
            childForm.TopLevel = False  ' Allow it to be a child form
            panelContainer.Controls.Add(childForm)  ' Add the form to the panel
            childForm.Show()  ' Show the form
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Public Sub HighlightButton(selectedButton As Button)
        ' Unhighlight the previously selected button
        If currentButton IsNot Nothing Then
            currentButton.BackColor = Color.Gainsboro ' Reset to default color
            currentButton.ForeColor = Color.DimGray ' Reset to default text color
        End If

        ' Highlight the currently selected button
        selectedButton.BackColor = Color.DeepSkyBlue ' Highlight color
        selectedButton.ForeColor = Color.White ' Highlight text color
        ' Update the current button reference
        currentButton = selectedButton
    End Sub

    Private Sub TeacherSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnClassSchedule.PerformClick()

        While Not IsLoggedIn
            Me.Close()
            LoginForm.Show()
        End While
        updateTimer.Interval = 1000
        updateTimer.Start() ' Start the timer
        UpdateDateAndTime()
    End Sub

    Private Sub btnClassSchedule_Click(sender As Object, e As EventArgs) Handles btnClassSchedule.Click
        HighlightButton(btnClassSchedule)
        OpenForm(New FormClassSchedule, False)
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        HighlightButton(btnAttendance)
        OpenForm(New FormClassAttendance, False)
    End Sub

    Private Sub TeacherSchedule_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Prompt the user with a confirmation dialog
        Dim result As DialogResult = MessageBox.Show("Are you sure want to exit the application?", "Logout",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            ' If the user selects No, cancel the close operation
            e.Cancel = True
        Else
            LoginForm.Show()
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        IsLoggedIn = False
        Me.Close()
        LoginForm.Show()
    End Sub

    Private Sub btnMyStudents_Click(sender As Object, e As EventArgs) Handles btnMyStudents.Click
        HighlightButton(btnMyStudents)
        OpenForm(New FormMyStudents, False)
    End Sub

    Private Sub btnUploadProfile_Click(sender As Object, e As EventArgs) Handles btnUploadProfile.Click
        ' Initialize an OpenFileDialog to select the image
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        openFileDialog.Title = "Select a Profile Picture"

        ' If user clicks OK
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Load the selected image into the PictureBox
            pbProfile.Image = Image.FromFile(openFileDialog.FileName)


            Dim cmd As Odbc.OdbcCommand

            ' Convert the PictureBox image to binary data using MemoryStream
            Dim ms As New MemoryStream

            pbProfile.Image.Save(ms, pbProfile.Image.RawFormat)

            ' Update the image data in the database
            Try
                connectDB() ' Open the connection
                cmd = New OdbcCommand("UPDATE teacherinformation SET profileImg = ? WHERE teacherID = ?", con)
                cmd.Parameters.AddWithValue("?", ms.ToArray)
                cmd.Parameters.AddWithValue("?", currentUser)
                cmd.ExecuteNonQuery()

                MsgBox("Profile picture updated successfully.", MsgBoxStyle.Information, "Success")
            Catch ex As Exception
                MsgBox("Error updating profile picture: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                con.Close()
                GC.Collect()
            End Try
        End If

    End Sub
    Private Sub UpdateDateAndTime()
        ' Update date in "MMMM d, yyyy" format
        txtDate.Text = DateTime.Now.ToString("MMMM d, yyyy", CultureInfo.InvariantCulture)

        ' Update time in 12-hour format
        txtTime.Text = DateTime.Now.ToString("h:mm:ss tt", CultureInfo.InvariantCulture)
        txtDay.Text = DateTime.Now.ToString("dddd", CultureInfo.InvariantCulture)
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        UserSettings.currentUserID = currentUserID
        UserSettings.ShowDialog()
    End Sub

    Private Sub updateTimer_Tick(sender As Object, e As EventArgs) Handles updateTimer.Tick
        UpdateDateAndTime()
    End Sub

    Private Sub btnAttendanceReports_Click(sender As Object, e As EventArgs) Handles btnAttendanceReports.Click
        HighlightButton(btnAttendanceReports)
        OpenForm(New FormTeacherAttendanceReports, False)
    End Sub


End Class