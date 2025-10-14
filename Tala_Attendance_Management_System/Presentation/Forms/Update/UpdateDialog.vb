Imports System
Imports System.Threading.Tasks
Imports System.Windows.Forms

''' <summary>
''' Dialog for handling application updates
''' </summary>
Public Class UpdateDialog
    Private ReadOnly _updateService As UpdateService
    Private ReadOnly _versionInfo As VersionInfo
    Private ReadOnly _logger As ILogger
    
    Public Sub New(updateService As UpdateService, versionInfo As VersionInfo, logger As ILogger)
        InitializeComponent()
        _updateService = updateService
        _versionInfo = versionInfo
        _logger = logger
        
        InitializeDialog()
    End Sub
    
    ''' <summary>
    ''' Initialize the dialog with version information
    ''' </summary>
    Private Sub InitializeDialog()
        Try
            ' Set version information
            lblMessage.Text = $"A new version ({_versionInfo.Version}) of Tala Attendance Management is available."
            txtChangeLog.Text = _versionInfo.ChangeLog
            
            ' Set dialog properties
            Me.TopMost = True
            Me.ShowInTaskbar = False
            
        Catch ex As Exception
            _logger.LogError($"Error initializing update dialog: {ex.Message}")
        End Try
    End Sub
    
    ''' <summary>
    ''' Handle Yes button click - start update process
    ''' </summary>
    Private Async Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Try
            ' Disable buttons and show progress
            btnYes.Enabled = False
            btnNo.Enabled = False
            progressBar.Visible = True
            lblProgress.Visible = True
            lblProgress.Text = "Downloading update..."
            
            ' Start update process with progress callback
            Dim updateSuccess = Await _updateService.DownloadAndInstallUpdateAsync(_versionInfo, AddressOf UpdateProgress)
            
            If Not updateSuccess Then
                MessageBox.Show("Update failed. Please try again later.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
            
        Catch ex As Exception
            _logger.LogError($"Error during update process: {ex.Message}")
            MessageBox.Show($"Update failed: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Try
    End Sub
    
    ''' <summary>
    ''' Handle No button click - cancel update
    ''' </summary>
    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        _logger.LogInfo("User declined update")
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
    
    ''' <summary>
    ''' Update progress callback
    ''' </summary>
    ''' <param name="percentage">Download percentage</param>
    Private Sub UpdateProgress(percentage As Integer)
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New Action(Of Integer)(AddressOf UpdateProgress), percentage)
                Return
            End If
            
            progressBar.Value = Math.Min(percentage, 100)
            lblProgress.Text = $"Downloading update... {percentage}%"
            
        Catch ex As Exception
            ' Ignore progress update errors
        End Try
    End Sub
    
    ''' <summary>
    ''' Handle form closing
    ''' </summary>
    Private Sub UpdateDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' If update is in progress, prevent closing
        If btnYes.Enabled = False AndAlso btnNo.Enabled = False AndAlso progressBar.Visible Then
            If e.CloseReason = CloseReason.UserClosing Then
                e.Cancel = True
                MessageBox.Show("Please wait for the update to complete.", "Update in Progress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    
End Class