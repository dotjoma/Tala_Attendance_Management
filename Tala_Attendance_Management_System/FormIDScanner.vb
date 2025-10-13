Imports System.IO.Ports
Imports System.Text

Public Class FormIDScanner
    Private port As New SerialPort
    Private deviceID As Integer = 0
    Private Sub FormIDScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTagID.Text = ""
        ChangeCOMPort()
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

                    ' Connection successful, update the port and exit the loop
                    port = tempPort


                    txtComPort.Text = "Connected to port: " + port.PortName
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
                Dim temp As String = buffer.ToString().Trim()
                deviceID = temp.Substring(0, 1)
                temp = temp.Substring(1)
                Invoke(Sub() txtTagID.Text = temp)
            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormIDScanner_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        port.Close()
    End Sub

    Private Sub txtTagID_TextChanged(sender As Object, e As EventArgs) Handles txtTagID.TextChanged
        If txtTagID.TextLength > 7 Then
            If Val(txtFlag.Text) = 1 Then
                AddStudents.txtTagID.Text = txtTagID.Text
            ElseIf Val(txtFlag.Text) = 2 Then
                AddFaculty.txtTagID.Text = txtTagID.Text
            End If
            Me.Close()
        End If
    End Sub

    Private Sub labelButtonClose_Click(sender As Object, e As EventArgs) Handles labelButtonClose.Click
        Me.Close()
        If Val(txtFlag.Text) = 1 Then
            If AddStudents.txtTagID.TextLength > 0 Then
                AddStudents.txtTagID.Text = AddStudents.txtTagID.Text
            Else
                AddStudents.txtTagID.Text = "abcdefg"
            End If
        ElseIf Val(txtFlag.Text) = 2 Then
            If AddFaculty.txtTagID.TextLength > 0 Then
                AddFaculty.txtTagID.Text = AddFaculty.txtTagID.Text
            Else
                AddFaculty.txtTagID.Text = "abcdefg"
            End If
        End If
    End Sub
End Class