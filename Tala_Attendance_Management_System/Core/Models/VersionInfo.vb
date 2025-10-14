Imports System

''' <summary>
''' Model representing version information from remote source
''' </summary>
Public Class VersionInfo
    Public Property Version As String
    Public Property DownloadUrl As String
    Public Property ChangeLog As String

    Public Sub New()
    End Sub

    Public Sub New(version As String, downloadUrl As String, changeLog As String)
        Me.Version = version
        Me.DownloadUrl = downloadUrl
        Me.ChangeLog = changeLog
    End Sub

    ''' <summary>
    ''' Compare this version with another version string
    ''' </summary>
    ''' <param name="otherVersion">Version to compare against</param>
    ''' <returns>True if this version is newer than the other version</returns>
    Public Function IsNewerThan(otherVersion As String) As Boolean
        Try
            Dim currentVer As New Version(Me.Version)
            Dim otherVer As New Version(otherVersion)
            Return currentVer > otherVer
        Catch ex As Exception
            ' If version parsing fails, assume no update needed
            Return False
        End Try
    End Function
End Class