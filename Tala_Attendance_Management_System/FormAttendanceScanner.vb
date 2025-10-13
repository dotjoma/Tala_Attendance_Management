Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports System.Reflection
Imports System.Text

Public Class FormAttendanceScanner
    Private port As New SerialPort

    Public deviceID As Integer = 0
    Public student_id As String = ""

    Private WithEvents displayTimer As New Timer()
    Private announcementIndex As Integer = 0
    Private announcementCards As New List(Of AnnouncementCard)

    Private Sub FormAttendanceScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeCOMPort()

        displayTimer.Interval = 10000 ' 10 seconds
        displayTimer.Start()

        ' Load announcements from database'
        LoadAnnouncements()

        ' Initially show the first announcement
        ShowNextAnnouncement()

        Timer1.Enabled = True
    End Sub
    Private Sub LoadAnnouncements()
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Try
            connectDB()
            cmd = New Odbc.OdbcCommand("SELECT pictureHeader, header, dayInfo, timeInfo, description, lookFor FROM announcements WHERE isActive = 1", con)
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim announcement As New AnnouncementCard()

                    Dim header As String = reader("header")
                    Dim dayInfo As Date = reader("dayInfo")
                    Dim timeInfo As String = reader("timeInfo")
                    Dim description As String = reader("description")
                    Dim lookFor As String = reader("lookFor")

                    Try
                        Dim profileImg As Byte()
                        profileImg = reader("pictureHeader")
                        Dim ms As New MemoryStream(profileImg)
                        announcement.AnnouncementImage = Image.FromStream(ms)
                    Catch ex As Exception

                    End Try

                    ' Create New AnnouncementCard instance
                    announcement.Header = header
                    announcement.DateInfo = "Date: " + dayInfo.ToString("MMMM dd, yyyy")
                    announcement.DayInfo = "Day: " + dayInfo.DayOfWeek.ToString()
                    announcement.TimeInfo = "Time: " + timeInfo
                    announcement.Description = description
                    announcement.LookFor = "For further information please look for Mr/Ms. " + lookFor
                    ' announcement.AnnouncementImage = Image

                    announcement.Dock = DockStyle.Fill
                    announcementCards.Add(announcement)
                End While

                reader.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading announcements: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub displayTimer_Tick(sender As Object, e As EventArgs) Handles displayTimer.Tick
        ShowNextAnnouncement()
    End Sub
    Private Sub ShowNextAnnouncement()
        ' Check if there are announcements to display
        If announcementIndex < announcementCards.Count Then
            ' Remove previous announcement card, if any
            panelThisAnnouncement.Controls.Clear()

            ' Add new announcement card to the panel
            Dim currentAnnouncement As AnnouncementCard = announcementCards(announcementIndex)
            panelThisAnnouncement.Controls.Add(currentAnnouncement)
            currentAnnouncement.Dock = DockStyle.Fill

            ' Increment index for next announcement
            announcementIndex += 1
        Else
            ' Reset index to loop back to the beginning
            announcementIndex = 0

            ' Clear panel to prepare for the next cycle
            panelThisAnnouncement.Controls.Clear()

            ' Add the first announcement card again
            Dim currentAnnouncement As AnnouncementCard = announcementCards(announcementIndex)
            panelThisAnnouncement.Controls.Add(currentAnnouncement)
            currentAnnouncement.Dock = DockStyle.Fill

            ' Increment index for next announcement
            announcementIndex += 1
        End If
    End Sub
    Private Sub ChangeCOMPort()
        Try
            ' Define the desired baud rate
            Dim baudRate As Integer = 115200

            ' Retrieve the available COM ports
            Dim availablePorts As String() = SerialPort.GetPortNames()

            ' Iterate through the available COM ports
            For Each comPort As String In availablePorts
                ' Create a new SerialPort instance with the current COM port and baud rate
                Dim tempPort As New SerialPort(comPort, baudRate)

                ' Attempt to open the connection
                Try
                    tempPort.Open()

                    ' Connection successful, up date the port and exit the loop
                    port = tempPort

                    Exit For
                Catch ex As Exception
                    ' Connection failed, continue to the next COM port
                    Continue For
                End Try
            Next

            ' Check if a valid port was found
            If port IsNot Nothing AndAlso port.IsOpen Then
                ' Port successfully opened, you can perform further actions
                ' For example, you can subscribe to the DataReceived event to handle incoming data
                'AddHandler port.DataReceived, AddressOf DataReceivedHandler
                Task.Run(AddressOf ReadDataAsync)
            Else
                ' No valid port found, handle the error or display a message
                MessageBox.Show("No available COM port found.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        ' Handle the received data
        ' This method will be called when data is received on the serial port
        ReadDataAsync()
    End Sub
    Public Sub ReadDataAsync()
        Try
            While True
                Dim buffer As New StringBuilder()  ' create a StringBuilder object to store incoming data
                While port.BytesToRead = 0  ' wait until there is data to read
                    Application.DoEvents()  ' allow the application to handle events
                End While
                Do
                    Dim data As Integer = port.ReadByte()  ' read a byte of data from the serial port
                    If data = 10 Then  ' if we've reached the end of a line
                        Exit Do  ' exit the loop
                    Else
                        buffer.Append(Convert.ToChar(data))  ' convert the byte to a character and add it to the StringBuilder
                    End If
                Loop

                Invoke(Sub() txtTagID.Text = buffer.ToString().Trim())
            End While
        Catch ex As Exception

        End Try
    End Sub
    '123CBA029
    '133C85A29
    '1E3B66729
    '1E355E328

    Private Sub AddFacultyCard(ByVal tagID As String)
        Dim cmd As System.Data.Odbc.OdbcCommand
        Dim da As New System.Data.Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        deviceID = tagID.Substring(0, 1)
        tagID = tagID.Substring(1)

        Try
            connectDB()

            ' Check if tag belongs to a teacher
            cmd = New System.Data.Odbc.OdbcCommand("
                            SELECT tagID, 
                            UCase(CONCAT(lastname, ', ', LEFT(firstname, 1), '.', ' ', LEFT(middlename, 1), '.')) AS teacherName, 
                            profileImg, employeeID, teacherID   
                            FROM teacherinformation WHERE tagID=?", con)
            cmd.Parameters.AddWithValue("@", tagID)
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Create a new card for the teacher
                Dim facultyCard As New StudentCard()

                facultyCard.StudentName = dt.Rows(0)("teacherName").ToString()
                facultyCard.LRN = dt.Rows(0)("employeeID").ToString()
                facultyCard.DateTimeInfo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt")

                ' Handle profile image
                If Not IsDBNull(dt.Rows(0)("profileImg")) Then
                    Dim imgData As Byte() = CType(dt.Rows(0)("profileImg"), Byte())
                    Using ms As New System.IO.MemoryStream(imgData)
                        facultyCard.pbPicture.Image = Image.FromStream(ms)
                    End Using
                Else
                    ' Default to a placeholder image if none exists
                    facultyCard.pbPicture.Image = My.Resources.default_image
                End If

                ' Add the card to the grid panel
                AddToGridPanel(facultyCard)

                ' Check if the teacher is already checked ina
                cmd = New System.Data.Odbc.OdbcCommand("SELECT ar.tag_id FROM attendance_record ar 
                                            WHERE ar.tag_id=? AND departureTime IS NULL AND depState = 0", con)
                cmd.Parameters.AddWithValue("@", tagID)
                Dim myreader As OdbcDataReader = cmd.ExecuteReader()

                If myreader.HasRows Then
                    ' Update the departure time
                    cmd = New System.Data.Odbc.OdbcCommand("UPDATE attendance_record SET departureTime=?, depStatus='Successful', depState = 1 WHERE tag_id=? AND arrivalTime IS NOT NULL AND depState = 0", con)
                    Dim departureTime As DateTime = DateTime.Now
                    cmd.Parameters.AddWithValue("@", departureTime)
                    cmd.Parameters.AddWithValue("@", tagID)

                    facultyCard.Status = "Time Out"
                Else
                    ' Insert new attendance record for teacher
                    cmd = New System.Data.Odbc.OdbcCommand("INSERT INTO attendance_record(tag_id, teacherID, logDate, arrivalTime, arrStatus) VALUES(?,?,?,?,?)", con)
                    Dim logDate As Date = Date.Today
                    Dim arrivalTime As DateTime = DateTime.Now
                    Dim arrStatus As String = "Successful"
                    With cmd.Parameters
                        .AddWithValue("@", Trim(tagID))
                        .AddWithValue("@", dt.Rows(0)("teacherID"))
                        .AddWithValue("@", logDate)
                        .AddWithValue("@", arrivalTime)
                        .AddWithValue("@", arrStatus)
                    End With

                    facultyCard.Status = "Time In"
                End If
                cmd.ExecuteNonQuery()
                txtTagID.Clear()
            Else
                txtTagID.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Sub

    Private Sub AddToGridPanel(ByVal facultyCard As StudentCard)
        pnlFacultyCard.SuspendLayout()
        pnlFacultyCard.Controls.Add(facultyCard)

        ' Set card size for two columns
        Dim cardWidth As Integer = (pnlFacultyCard.Width \ 2) - 15 ' ~445 pixels
        Dim cardHeight As Integer = pnlFacultyCard.Height \ 4 - 10 ' Adjust as needed
        facultyCard.Size = New Size(cardWidth, cardHeight)
        facultyCard.Margin = New Padding(5)

        ' Ensure FlowLayoutPanel properties
        pnlFacultyCard.FlowDirection = FlowDirection.LeftToRight
        pnlFacultyCard.WrapContents = True

        ' Timer to remove the card
        Dim removalTimer As New Timer()
        removalTimer.Interval = 2000
        AddHandler removalTimer.Tick,
        Sub(sender As Object, e As EventArgs)
            removalTimer.Stop()
            pnlFacultyCard.Controls.Remove(facultyCard)
            facultyCard.Dispose()
            removalTimer.Dispose()
            pnlFacultyCard.ResumeLayout()
        End Sub
        removalTimer.Start()

        pnlFacultyCard.ResumeLayout()
    End Sub

    'Private Sub AddToGridPanel(ByVal facultyCard As StudentCard)
    '    pnlFacultyCard.SuspendLayout()

    '    ' Ensure FlowLayoutPanel is top-to-bottom
    '    pnlFacultyCard.FlowDirection = FlowDirection.TopDown

    '    pnlFacultyCard.WrapContents = False
    '    pnlFacultyCard.AutoScroll = True

    '    ' Set card size to fit the panel's width with some padding
    '    Dim cardWidth As Integer = pnlFacultyCard.ClientSize.Width - 20 ' Adjust for padding and scrollbar
    '    Dim cardHeight As Integer = 200 ' Or any fixed height you prefer

    '    facultyCard.Size = New Size(cardWidth, cardHeight)
    '    facultyCard.Margin = New Padding(5)

    '    pnlFacultyCard.Controls.Add(facultyCard)

    '    ' Timer to remove the card
    '    Dim removalTimer As New Timer()
    '    removalTimer.Interval = 2000
    '    AddHandler removalTimer.Tick,
    '    Sub(sender As Object, e As EventArgs)
    '        removalTimer.Stop()
    '        pnlFacultyCard.Controls.Remove(facultyCard)
    '        facultyCard.Dispose()
    '        removalTimer.Dispose()
    '        pnlFacultyCard.ResumeLayout()
    '    End Sub
    '    removalTimer.Start()

    '    pnlFacultyCard.ResumeLayout()
    'End Sub



    Private Sub tmrHideCard_Tick(sender As Object, e As EventArgs) Handles tmrHideCard.Tick
        Dim panel As Panel = CType(tmrHideCard.Tag, Panel)
        If panel IsNot Nothing Then
            panel.Controls.Clear() ' Clear the card from the panel
        End If
        tmrHideCard.Stop() ' Stop the timer
        tmrHideCard.Enabled = False ' Disable the timer
    End Sub

    Private Sub FormAttendanceScanner_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LoginForm.Show()
    End Sub

    Private Sub txtTagID_TextChanged(sender As Object, e As EventArgs) Handles txtTagID.TextChanged
        If txtTagID.TextLength > 7 Then
            AddFacultyCard(txtTagID.Text)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = Date.Now.ToString("MMMM-dd-yyyy   hh:mm:ss tt")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label6.Text = TimeOfDay.ToString(" hh:mm:ss tt    ")
        Label7.Text = Date.Now.ToString("MMMM-dd-yyyy    ")

    End Sub
End Class