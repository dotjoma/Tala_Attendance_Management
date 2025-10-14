Imports System
Imports System.Net
Imports System.Net.NetworkInformation

''' <summary>
''' Helper class for network-related operations
''' </summary>
Public Class NetworkHelper

    ''' <summary>
    ''' Check if the machine is connected to the internet
    ''' </summary>
    ''' <returns>True if internet connection is available</returns>
    Public Shared Function IsInternetAvailable() As Boolean
        Try
            ' Try to ping Google's DNS server
            Using ping As New Ping()
                Dim reply = ping.Send("8.8.8.8", 3000)
                If reply.Status = IPStatus.Success Then
                    Return True
                End If
            End Using

            ' Fallback: Try to ping Cloudflare DNS
            Using ping As New Ping()
                Dim reply = ping.Send("1.1.1.1", 3000)
                Return reply.Status = IPStatus.Success
            End Using

        Catch ex As Exception
            ' If ping fails, try HTTP request as fallback
            Return IsInternetAvailableHttp()
        End Try
    End Function

    ''' <summary>
    ''' Alternative method using HTTP request to check internet connectivity
    ''' </summary>
    ''' <returns>True if internet connection is available</returns>
    Private Shared Function IsInternetAvailableHttp() As Boolean
        Try
            Using client As New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Download a file from URL with progress reporting
    ''' </summary>
    ''' <param name="url">URL to download from</param>
    ''' <param name="destinationPath">Local path to save the file</param>
    ''' <param name="progressCallback">Optional callback for progress updates</param>
    ''' <returns>True if download was successful</returns>
    Public Shared Function DownloadFile(url As String, destinationPath As String, Optional progressCallback As Action(Of Integer) = Nothing) As Boolean
        Try
            Dim downloadComplete As Boolean = False
            Dim downloadSuccess As Boolean = False
            
            Using client As New WebClient()
                ' Add browser headers for better compatibility
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36")
                
                If progressCallback IsNot Nothing Then
                    AddHandler client.DownloadProgressChanged, Sub(sender, e) progressCallback(e.ProgressPercentage)
                End If
                
                AddHandler client.DownloadFileCompleted, Sub(sender, e)
                    downloadComplete = True
                    downloadSuccess = Not e.Cancelled AndAlso e.Error Is Nothing
                End Sub

                client.DownloadFileAsync(New Uri(url), destinationPath)
                
                ' Wait for download to complete
                While Not downloadComplete
                    System.Threading.Thread.Sleep(100)
                    System.Windows.Forms.Application.DoEvents()
                End While
                
                Return downloadSuccess
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Download a file with detailed progress reporting including speed and ETA
    ''' </summary>
    ''' <param name="url">URL to download from</param>
    ''' <param name="destinationPath">Local path to save the file</param>
    ''' <param name="progressCallback">Callback with percentage, bytes received, total bytes, speed, ETA</param>
    ''' <returns>True if download was successful</returns>
    Public Shared Function DownloadFileWithProgress(url As String, destinationPath As String, progressCallback As Action(Of Integer, Long, Long, Double, String)) As Boolean
        Try
            Dim startTime As DateTime = DateTime.Now
            Dim lastUpdateTime As DateTime = DateTime.Now
            Dim lastBytesReceived As Long = 0
            
            Using client As New WebClient()
                ' Add browser headers for better compatibility
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36")
                
                AddHandler client.DownloadProgressChanged, Sub(sender, e)
                    Dim currentTime = DateTime.Now
                    Dim timeSinceStart = (currentTime - startTime).TotalSeconds
                    Dim timeSinceLastUpdate = (currentTime - lastUpdateTime).TotalSeconds
                    
                    ' Calculate speed (bytes per second)
                    Dim speed As Double = 0
                    If timeSinceStart > 0 Then
                        speed = e.BytesReceived / timeSinceStart
                    End If
                    
                    ' Calculate ETA
                    Dim eta As String = "Calculating..."
                    If speed > 0 AndAlso e.TotalBytesToReceive > 0 Then
                        Dim remainingBytes = e.TotalBytesToReceive - e.BytesReceived
                        Dim secondsRemaining = remainingBytes / speed
                        eta = FormatTimeSpan(TimeSpan.FromSeconds(secondsRemaining))
                    End If
                    
                    ' Update callback
                    progressCallback(e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive, speed, eta)
                    
                    lastUpdateTime = currentTime
                    lastBytesReceived = e.BytesReceived
                End Sub

                client.DownloadFile(url, destinationPath)
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Format bytes to human-readable format
    ''' </summary>
    Public Shared Function FormatBytes(bytes As Long) As String
        Dim sizes() As String = {"B", "KB", "MB", "GB", "TB"}
        Dim order As Integer = 0
        Dim size As Double = bytes
        
        While size >= 1024 AndAlso order < sizes.Length - 1
            order += 1
            size /= 1024
        End While
        
        Return $"{size:F2} {sizes(order)}"
    End Function
    
    ''' <summary>
    ''' Format TimeSpan to readable string
    ''' </summary>
    Private Shared Function FormatTimeSpan(ts As TimeSpan) As String
        If ts.TotalSeconds < 60 Then
            Return $"{CInt(ts.TotalSeconds)}s"
        ElseIf ts.TotalMinutes < 60 Then
            Return $"{CInt(ts.TotalMinutes)}m {ts.Seconds}s"
        Else
            Return $"{CInt(ts.TotalHours)}h {ts.Minutes}m"
        End If
    End Function

End Class