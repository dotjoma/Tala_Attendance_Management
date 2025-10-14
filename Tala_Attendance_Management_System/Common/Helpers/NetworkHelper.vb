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
            Using client As New WebClient()
                ' Add browser headers for better compatibility
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36")
                
                If progressCallback IsNot Nothing Then
                    AddHandler client.DownloadProgressChanged, Sub(sender, e) progressCallback(e.ProgressPercentage)
                End If

                client.DownloadFile(url, destinationPath)
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class