Imports System.IO.Ports
Imports System.Text

Public Class FormIDScanner
    Private port As New SerialPort
    Private deviceID As Integer = 0
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance
    Private Sub FormIDScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _logger.LogInfo("FormIDScanner loading...")
        txtTagID.Text = ""
        ChangeCOMPort()
        _logger.LogInfo("FormIDScanner loaded successfully")
    End Sub
    Private Sub ChangeCOMPort()
        Try
            _logger.LogInfo("Starting COM port detection for ID Scanner...")
            
            ' Define the desired baud rate
            Dim baudRate As Integer = 115200
            _logger.LogInfo($"Baud rate set to: {baudRate}")

            ' Retrieve the available COM ports
            Dim availablePorts As String() = SerialPort.GetPortNames()
            _logger.LogInfo($"Found {availablePorts.Length} available COM ports: {String.Join(", ", availablePorts)}")

            If availablePorts.Length = 0 Then
                _logger.LogWarning("No COM ports detected on system")
                MessageBox.Show("No COM ports detected. Please check if RFID reader is connected.", "COM Port Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Iterate through the available COM ports
            For Each comPort As String In availablePorts
                _logger.LogDebug($"Attempting to open {comPort}...")
                
                ' Create a new SerialPort instance with the current COM port and baud rate
                Dim tempPort As New SerialPort(comPort, baudRate)

                ' Attempt to open the connection
                Try
                    tempPort.Open()
                    _logger.LogInfo($"✓ Successfully opened {comPort} at {baudRate} baud")

                    ' Connection successful, update the port and exit the loop
                    port = tempPort

                    txtComPort.Text = "Connected to port: " + port.PortName
                    Exit For
                Catch ex As Exception
                    ' Connection failed, continue to the next COM port
                    _logger.LogWarning($"Failed to open {comPort}: {ex.Message}")
                    Continue For
                End Try
            Next

            ' Check if a valid port was found
            If port IsNot Nothing AndAlso port.IsOpen Then
                _logger.LogInfo($"COM port ready: {port.PortName} at {port.BaudRate} baud")
                _logger.LogDebug($"Port settings - DataBits: {port.DataBits}, StopBits: {port.StopBits}, Parity: {port.Parity}")
                
                ' Port successfully opened, you can perform further actions
                Task.Run(AddressOf ReadDataAsync)
                _logger.LogInfo("Started async data reading task for ID Scanner")
            Else
                _logger.LogError("Failed to open any COM port")
                MessageBox.Show("No available COM port found.")
            End If
        Catch ex As Exception
            _logger.LogError($"Error in ChangeCOMPort: {ex.Message}")
            _logger.LogError($"Stack trace: {ex.StackTrace}")
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
            _logger.LogInfo("ReadDataAsync started for ID Scanner - waiting for RFID scans...")
            _logger.LogInfo($"Port status - IsOpen: {port.IsOpen}, PortName: {port.PortName}, BaudRate: {port.BaudRate}")

            Dim loopCount As Integer = 0
            While True
                loopCount += 1
                If loopCount Mod 500 = 0 Then
                    _logger.LogDebug($"ReadDataAsync loop iteration {loopCount}, still waiting for data...")
                End If

                Dim buffer As New StringBuilder()  ' create a StringBuilder object to store incoming data
                
                ' Check if port is still open
                If Not port.IsOpen Then
                    _logger.LogError("Port closed unexpectedly in ReadDataAsync loop")
                    Exit While
                End If
                
                While port.BytesToRead = 0  ' wait until there is data to read
                    Application.DoEvents()  ' allow the application to handle events
                    System.Threading.Thread.Sleep(10)  ' Small delay to prevent CPU spinning
                End While
                
                _logger.LogInfo($"⚡ Data detected on {port.PortName}! Bytes to read: {port.BytesToRead}")
                
                Do
                    Dim data As Integer = port.ReadByte()  ' read a byte of data from the serial port
                    _logger.LogDebug($"Read byte: {data} (char: '{If(data >= 32 And data <= 126, Convert.ToChar(data).ToString(), "[non-printable]")}')")
                    
                    If data = 10 Then  ' if we've reached the end of a line (newline character)
                        _logger.LogDebug("Newline character detected, ending read")
                        Exit Do  ' exit the loop
                    ElseIf data = 13 Then  ' carriage return
                        _logger.LogDebug("Carriage return detected, skipping")
                        ' Skip carriage return
                    Else
                        buffer.Append(Convert.ToChar(data))  ' convert the byte to a character and add it to the StringBuilder
                    End If
                Loop
                
                Dim temp As String = buffer.ToString().Trim()
                _logger.LogInfo($"📋 RFID tag scanned (raw): '{temp}' (length: {temp.Length} chars)")
                
                If String.IsNullOrEmpty(temp) Then
                    _logger.LogWarning("Received empty data, ignoring...")
                    Continue While
                End If
                
                ' Check if data starts with a device ID (single digit)
                If temp.Length > 0 AndAlso Char.IsDigit(temp(0)) AndAlso temp.Length > 8 Then
                    ' Has device ID prefix
                    deviceID = temp.Substring(0, 1)
                    temp = temp.Substring(1)
                    _logger.LogInfo($"✓ Parsed - Device ID: {deviceID}, Tag ID: {temp}")
                Else
                    ' No device ID, use tag as-is
                    deviceID = 0
                    _logger.LogInfo($"✓ No device ID prefix detected, using full tag: {temp}")
                End If
                
                _logger.LogInfo($"Setting txtTagID.Text to: {temp}")
                Invoke(Sub() txtTagID.Text = temp)
                _logger.LogInfo($"✓ Tag ID successfully set in textbox: {temp}")
            End While
        Catch ex As Exception
            _logger.LogError($"❌ Error in ReadDataAsync: {ex.Message}")
            _logger.LogError($"Stack trace: {ex.StackTrace}")
        End Try
    End Sub

    Private Sub FormIDScanner_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        _logger.LogInfo("FormIDScanner closing...")
        
        Try
            If port IsNot Nothing AndAlso port.IsOpen Then
                port.Close()
                _logger.LogInfo($"Closed COM port: {port.PortName}")
            End If
        Catch ex As Exception
            _logger.LogError($"Error closing COM port: {ex.Message}")
        End Try
        
        _logger.LogInfo("FormIDScanner closed")
    End Sub

    Private Sub txtTagID_TextChanged(sender As Object, e As EventArgs) Handles txtTagID.TextChanged
        If txtTagID.TextLength > 7 Then
            _logger.LogDebug($"Tag ID length valid ({txtTagID.TextLength} chars): {txtTagID.Text}")
            
            If Val(txtFlag.Text) = 1 Then
                _logger.LogInfo($"Setting tag ID for Student: {txtTagID.Text}")
                AddStudents.txtTagID.Text = txtTagID.Text
            ElseIf Val(txtFlag.Text) = 2 Then
                _logger.LogInfo($"Setting tag ID for Faculty: {txtTagID.Text}")
                AddFaculty.txtTagID.Text = txtTagID.Text
            End If
            
            _logger.LogDebug("Closing FormIDScanner after successful scan")
            Me.Close()
        Else
            If txtTagID.TextLength > 0 Then
                _logger.LogDebug($"Tag ID too short ({txtTagID.TextLength} chars): {txtTagID.Text}")
            End If
        End If
    End Sub

    Private Sub labelButtonClose_Click(sender As Object, e As EventArgs) Handles labelButtonClose.Click
        _logger.LogInfo("User clicked close button on FormIDScanner")
        
        Me.Close()
        
        If Val(txtFlag.Text) = 1 Then
            If AddStudents.txtTagID.TextLength > 0 Then
                _logger.LogDebug($"Keeping existing student tag ID: {AddStudents.txtTagID.Text}")
                AddStudents.txtTagID.Text = AddStudents.txtTagID.Text
            Else
                _logger.LogDebug("Setting default student tag ID: abcdefg")
                AddStudents.txtTagID.Text = "abcdefg"
            End If
        ElseIf Val(txtFlag.Text) = 2 Then
            If AddFaculty.txtTagID.TextLength > 0 Then
                _logger.LogDebug($"Keeping existing faculty tag ID: {AddFaculty.txtTagID.Text}")
                AddFaculty.txtTagID.Text = AddFaculty.txtTagID.Text
            Else
                _logger.LogDebug("Setting default faculty tag ID: abcdefg")
                AddFaculty.txtTagID.Text = "abcdefg"
            End If
        End If
    End Sub
End Class