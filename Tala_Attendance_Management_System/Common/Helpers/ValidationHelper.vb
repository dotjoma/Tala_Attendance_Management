Public Class ValidationHelper
    Private Shared ReadOnly _logger As ILogger = LoggerFactory.Instance

    ''' <summary>
    ''' Validates that all required fields in a panel are filled
    ''' </summary>
    ''' <param name="panel">Panel containing controls to validate</param>
    ''' <param name="logErrors">Whether to log validation errors</param>
    ''' <param name="excludeFields">Array of field names to exclude from validation</param>
    ''' <returns>True if all required fields are valid</returns>
    Public Shared Function ValidateRequiredFields(panel As Panel, Optional logErrors As Boolean = True, Optional excludeFields As String() = Nothing) As Boolean
        ' Default excluded fields (optional fields)
        Dim defaultExcluded As String() = {"txtMiddleName", "txtExtName"}

        ' Combine default excluded fields with any additional ones passed in
        Dim allExcluded As New List(Of String)(defaultExcluded)
        If excludeFields IsNot Nothing Then
            allExcluded.AddRange(excludeFields)
        End If

        For Each obj As Control In panel.Controls
            If TypeOf obj Is TextBox OrElse TypeOf obj Is ComboBox Then
                ' Skip validation for excluded fields
                If allExcluded.Contains(obj.Name) Then
                    Continue For
                End If

                If String.IsNullOrEmpty(obj.Text.Trim()) Then
                    ' Log validation failure
                    If logErrors Then
                        _logger.LogWarning($"Field validation failed - Empty field: '{obj.Name}' in panel '{panel.Name}'")
                    End If

                    MessageBox.Show("Please fill up every required field in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    obj.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Validates username uniqueness
    ''' </summary>
    ''' <param name="username">Username to check</param>
    ''' <returns>True if username is unique</returns>
    Public Shared Function IsUsernameUnique(username As String) As Boolean
        Try
            Dim dbContext As New DatabaseContext()
            Dim query As String = "SELECT COUNT(*) FROM logins WHERE username = ? AND isActive=1"
            Dim result As Integer = Convert.ToInt32(dbContext.ExecuteScalar(query, username))

            Return result = 0 ' True if no duplicates found
        Catch ex As Exception
            _logger.LogError($"Error checking username uniqueness for '{username}': {ex.Message}")
            MessageBox.Show("Error checking for duplicate username: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validates email format
    ''' </summary>
    ''' <param name="email">Email to validate</param>
    ''' <returns>True if email format is valid</returns>
    Public Shared Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False

        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Validates that a department is selected from ComboBox
    ''' </summary>
    ''' <param name="departmentComboBox">Department ComboBox to validate</param>
    ''' <param name="isRequired">Whether department selection is required</param>
    ''' <param name="logErrors">Whether to log validation errors</param>
    ''' <returns>True if department selection is valid</returns>
    Public Shared Function ValidateDepartmentSelection(departmentComboBox As ComboBox, Optional isRequired As Boolean = True, Optional logErrors As Boolean = True) As Boolean
        Try
            If Not isRequired Then
                Return True ' Department is optional
            End If

            ' Check if a department is selected
            If departmentComboBox.SelectedValue Is Nothing OrElse IsDBNull(departmentComboBox.SelectedValue) Then
                If logErrors Then
                    _logger.LogWarning($"Department validation failed - No department selected in '{departmentComboBox.Name}'")
                End If
                MessageBox.Show("Please select a department for this faculty member.", "Department Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                departmentComboBox.Focus()
                Return False
            End If

            ' Check if the selected value is valid (not the default "-- Select Department --" option)
            Dim selectedValue As String = departmentComboBox.SelectedValue.ToString()
            If String.IsNullOrWhiteSpace(selectedValue) OrElse selectedValue = "0" OrElse selectedValue.ToUpper() = "NULL" Then
                If logErrors Then
                    _logger.LogWarning($"Department validation failed - Invalid department selection: '{selectedValue}' in '{departmentComboBox.Name}'")
                End If
                MessageBox.Show("Please select a valid department for this faculty member.", "Invalid Department Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                departmentComboBox.Focus()
                Return False
            End If

            ' Check if selected value is numeric (valid department ID)
            If Not IsNumeric(selectedValue) Then
                If logErrors Then
                    _logger.LogWarning($"Department validation failed - Non-numeric department ID: '{selectedValue}' in '{departmentComboBox.Name}'")
                End If
                MessageBox.Show("Please select a valid department for this faculty member.", "Invalid Department Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                departmentComboBox.Focus()
                Return False
            End If

            If logErrors Then
                _logger.LogInfo($"Department validation passed - Selected department ID: {selectedValue}")
            End If

            Return True

        Catch ex As Exception
            If logErrors Then
                _logger.LogError($"Error validating department selection: {ex.Message}")
            End If
            MessageBox.Show("Error validating department selection. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
