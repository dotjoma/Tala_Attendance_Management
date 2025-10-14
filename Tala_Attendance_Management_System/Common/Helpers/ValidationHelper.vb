Imports System.Windows.Forms

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
    ''' Validates date of birth with comprehensive business rules
    ''' </summary>
    ''' <param name="dateOfBirth">Date of birth to validate</param>
    ''' <param name="minimumAge">Minimum age required (default: from Constants.MIN_FACULTY_AGE)</param>
    ''' <param name="maximumAge">Maximum age allowed (default: from Constants.MAX_FACULTY_AGE)</param>
    ''' <param name="logErrors">Whether to log validation errors</param>
    ''' <returns>True if date of birth is valid</returns>
    Public Shared Function ValidateDateOfBirth(dateOfBirth As DateTime, Optional minimumAge As Integer = Constants.MIN_FACULTY_AGE, Optional maximumAge As Integer = Constants.MAX_FACULTY_AGE, Optional logErrors As Boolean = True) As Boolean
        Try
            Dim today As DateTime = DateTime.Today

            ' Check if date is in the future
            If dateOfBirth > today Then
                If logErrors Then
                    _logger.LogWarning($"Date of birth validation failed - Future date: {dateOfBirth:yyyy-MM-dd}")
                End If
                MessageBox.Show("Invalid date of birth. Please enter a valid past date.", "Invalid Date of Birth", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Calculate age
            Dim age As Integer = CalculateAge(dateOfBirth, today)

            ' Check minimum age
            If age < minimumAge Then
                If logErrors Then
                    _logger.LogWarning($"Date of birth validation failed - Too young: Age {age}, Minimum required: {minimumAge}")
                End If
                MessageBox.Show($"Faculty member must be at least {minimumAge} years old. Current age: {age} years.", "Age Requirement Not Met", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Check maximum age
            If age > maximumAge Then
                If logErrors Then
                    _logger.LogWarning($"Date of birth validation failed - Too old: Age {age}, Maximum allowed: {maximumAge}")
                End If
                MessageBox.Show($"Faculty member cannot be older than {maximumAge} years. Current age: {age} years.", "Age Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Check for unrealistic dates (e.g., year 1900 or earlier)
            If dateOfBirth.Year <= Constants.MIN_BIRTH_YEAR Then
                If logErrors Then
                    _logger.LogWarning($"Date of birth validation failed - Unrealistic date: {dateOfBirth:yyyy-MM-dd}")
                End If
                MessageBox.Show("Invalid date of birth. Please enter a realistic date.", "Invalid Date of Birth", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If logErrors Then
                _logger.LogInfo($"Date of birth validation passed - DOB: {dateOfBirth:yyyy-MM-dd}, Age: {age} years")
            End If

            Return True

        Catch ex As Exception
            If logErrors Then
                _logger.LogError($"Error validating date of birth: {ex.Message}")
            End If
            MessageBox.Show("Error validating date of birth. Please check the date format and try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Calculates age based on date of birth and reference date
    ''' </summary>
    ''' <param name="dateOfBirth">Date of birth</param>
    ''' <param name="referenceDate">Reference date (usually today)</param>
    ''' <returns>Age in years</returns>
    Public Shared Function CalculateAge(dateOfBirth As DateTime, referenceDate As DateTime) As Integer
        Try
            Dim age As Integer = referenceDate.Year - dateOfBirth.Year

            ' Adjust if birthday hasn't occurred this year yet
            If referenceDate.Month < dateOfBirth.Month OrElse
               (referenceDate.Month = dateOfBirth.Month AndAlso referenceDate.Day < dateOfBirth.Day) Then
                age -= 1
            End If

            Return age
        Catch ex As Exception
            _logger.LogError($"Error calculating age: {ex.Message}")
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Validates DateTimePicker control for date of birth
    ''' </summary>
    ''' <param name="dateTimePicker">DateTimePicker control to validate</param>
    ''' <param name="minimumAge">Minimum age required (default: from Constants.MIN_FACULTY_AGE)</param>
    ''' <param name="maximumAge">Maximum age allowed (default: from Constants.MAX_FACULTY_AGE)</param>
    ''' <param name="logErrors">Whether to log validation errors</param>
    ''' <returns>True if DateTimePicker value is valid</returns>
    Public Shared Function ValidateDateOfBirthControl(dateTimePicker As DateTimePicker, Optional minimumAge As Integer = Constants.MIN_FACULTY_AGE, Optional maximumAge As Integer = Constants.MAX_FACULTY_AGE, Optional logErrors As Boolean = True) As Boolean
        Try
            If logErrors Then
                _logger.LogInfo($"Validating DateTimePicker '{dateTimePicker.Name}' - Value: {dateTimePicker.Value:yyyy-MM-dd}")
            End If

            Dim isValid As Boolean = ValidateDateOfBirth(dateTimePicker.Value.Date, minimumAge, maximumAge, logErrors)

            If Not isValid Then
                dateTimePicker.Focus()
            End If

            Return isValid

        Catch ex As Exception
            If logErrors Then
                _logger.LogError($"Error validating DateTimePicker control '{dateTimePicker.Name}': {ex.Message}")
            End If
            MessageBox.Show("Error validating date of birth control. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Checks if a region has provinces (e.g., NCR doesn't have provinces)
    ''' </summary>
    ''' <param name="regionName">Name of the region to check</param>
    ''' <param name="regionCode">Code of the region to check</param>
    ''' <returns>True if region has provinces, False if it doesn't (like NCR)</returns>
    Public Shared Function RegionHasProvinces(regionName As String, Optional regionCode As String = "") As Boolean
        Try
            If String.IsNullOrWhiteSpace(regionName) Then
                Return True ' Default to having provinces if region name is empty
            End If

            ' Check for NCR (National Capital Region) - doesn't have provinces
            If regionName.ToUpper().Contains("NATIONAL CAPITAL REGION") OrElse
               regionName.ToUpper().Contains("NCR") OrElse
               regionCode = Constants.NCR_REGION_CODE Then
                _logger.LogInfo($"Region '{regionName}' identified as NCR - no provinces")
                Return False
            End If

            ' Add other special regions here if needed in the future
            ' Example: ARMM, BARMM, etc.

            _logger.LogInfo($"Region '{regionName}' has provinces")
            Return True

        Catch ex As Exception
            _logger.LogError($"Error checking if region has provinces: {ex.Message}")
            Return True ' Default to having provinces on error
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

    ''' <summary>
    ''' Validates required fields with dynamic province validation based on region
    ''' </summary>
    ''' <param name="panel">Panel containing controls to validate</param>
    ''' <param name="regionComboBox">Region ComboBox to check for province requirement</param>
    ''' <param name="logErrors">Whether to log validation errors</param>
    ''' <param name="excludeFields">Array of field names to exclude from validation</param>
    ''' <returns>True if all required fields are valid</returns>
    Public Shared Function ValidateRequiredFieldsWithDynamicProvince(panel As Panel, regionComboBox As ComboBox, Optional logErrors As Boolean = True, Optional excludeFields As String() = Nothing) As Boolean
        Try
            ' Check if region has provinces
            Dim regionHasProvinces As Boolean = True
            If regionComboBox IsNot Nothing AndAlso regionComboBox.SelectedItem IsNot Nothing Then
                regionHasProvinces = ValidationHelper.RegionHasProvinces(regionComboBox.Text)
            End If

            ' Default excluded fields (optional fields)
            Dim defaultExcluded As New List(Of String)({"txtMiddleName", "txtExtName"})

            ' If region doesn't have provinces, exclude province fields from validation
            If Not regionHasProvinces Then
                defaultExcluded.AddRange({"cbProvince", "cbprovince"})
                If logErrors Then
                    _logger.LogInfo($"Province validation excluded for region: {regionComboBox?.Text}")
                End If
            End If

            ' Combine default excluded fields with any additional ones passed in
            If excludeFields IsNot Nothing Then
                defaultExcluded.AddRange(excludeFields)
            End If

            ' Use standard validation with dynamic exclusions
            Return ValidateRequiredFields(panel, logErrors, defaultExcluded.ToArray())

        Catch ex As Exception
            If logErrors Then
                _logger.LogError($"Error in dynamic province validation: {ex.Message}")
            End If
            ' Fall back to standard validation
            Return ValidateRequiredFields(panel, logErrors, excludeFields)
        End Try
    End Function

    ''' <summary>
    ''' Validates RFID tag uniqueness in the database
    ''' </summary>
    ''' <param name="rfidTag">RFID tag to check for uniqueness</param>
    ''' <param name="excludeFacultyId">Faculty ID to exclude from check (for editing existing faculty)</param>
    ''' <param name="logErrors">Whether to log validation errors</param>
    ''' <returns>True if RFID tag is unique or empty, False if duplicate found</returns>
    Public Shared Function IsRfidTagUnique(rfidTag As String, Optional excludeFacultyId As Integer? = Nothing, Optional logErrors As Boolean = True) As Boolean
        Try
            ' Skip validation if RFID tag is empty or default placeholder
            If String.IsNullOrWhiteSpace(rfidTag) OrElse rfidTag.Trim() = "--" Then
                If logErrors Then
                    _logger.LogInfo("RFID validation skipped - Empty or placeholder tag")
                End If
                Return True ' Allow empty RFID tags
            End If

            Dim trimmedTag As String = rfidTag.Trim()

            ' Build query to check for existing RFID tag
            Dim query As String = "SELECT COUNT(*) FROM teacherinformation WHERE tagID = ? AND isActive = 1"
            Dim parameters As New List(Of Object)
            parameters.Add(trimmedTag)

            ' Exclude current faculty when editing
            If excludeFacultyId.HasValue Then
                query &= " AND teacherID != ?"
                parameters.Add(excludeFacultyId.Value)
                If logErrors Then
                    _logger.LogInfo($"RFID validation - Excluding faculty ID {excludeFacultyId.Value} from check")
                End If
            End If

            ' Execute query
            connectDB()
            Dim cmd As New System.Data.Odbc.OdbcCommand(query, con)
            
            ' Add parameters
            For i As Integer = 0 To parameters.Count - 1
                cmd.Parameters.Add("?", System.Data.Odbc.OdbcType.VarChar).Value = parameters(i)
            Next

            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            con.Close()

            Dim isUnique As Boolean = (result = 0)

            If logErrors Then
                If isUnique Then
                    _logger.LogInfo($"RFID validation passed - Tag '{trimmedTag}' is unique")
                Else
                    _logger.LogWarning($"RFID validation failed - Tag '{trimmedTag}' already exists (found {result} matches)")
                End If
            End If

            ' Show error message if duplicate found
            If Not isUnique Then
                MessageBox.Show("This RFID tag is already in use by another faculty member. Please use a different RFID tag or scan a new one.", 
                              "Duplicate RFID Tag", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Return isUnique

        Catch ex As Exception
            If logErrors Then
                _logger.LogError($"Error validating RFID tag uniqueness for '{rfidTag}': {ex.Message}")
            End If
            
            ' Close connection if still open
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try

            MessageBox.Show("Error checking RFID tag uniqueness. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' Fail safe - don't allow save if we can't validate
        End Try
    End Function

    ''' <summary>
    ''' Validates employee ID uniqueness in the database
    ''' </summary>
    ''' <param name="employeeId">Employee ID to check for uniqueness</param>
    ''' <param name="excludeFacultyId">Faculty ID to exclude from check (for editing existing faculty)</param>
    ''' <param name="logErrors">Whether to log validation errors</param>
    ''' <returns>True if employee ID is unique, False if duplicate found</returns>
    Public Shared Function IsEmployeeIdUnique(employeeId As String, Optional excludeFacultyId As Integer? = Nothing, Optional logErrors As Boolean = True) As Boolean
        Try
            ' Employee ID is required, so check for empty
            If String.IsNullOrWhiteSpace(employeeId) Then
                If logErrors Then
                    _logger.LogWarning("Employee ID validation failed - Empty employee ID")
                    MessageBox.Show("Employee ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Return False
            End If

            Dim trimmedId As String = employeeId.Trim()

            ' Build query to check for existing employee ID
            Dim query As String = "SELECT COUNT(*) FROM teacherinformation WHERE employeeID = ? AND isActive = 1"
            Dim parameters As New List(Of Object)
            parameters.Add(trimmedId)

            ' Exclude current faculty when editing
            If excludeFacultyId.HasValue Then
                query &= " AND teacherID != ?"
                parameters.Add(excludeFacultyId.Value)
                If logErrors Then
                    _logger.LogInfo($"Employee ID validation - Excluding faculty ID {excludeFacultyId.Value} from check")
                End If
            End If

            ' Execute query
            connectDB()
            Dim cmd As New System.Data.Odbc.OdbcCommand(query, con)
            
            ' Add parameters
            For i As Integer = 0 To parameters.Count - 1
                cmd.Parameters.Add("?", System.Data.Odbc.OdbcType.VarChar).Value = parameters(i)
            Next

            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            con.Close()

            Dim isUnique As Boolean = (result = 0)

            If logErrors Then
                If isUnique Then
                    _logger.LogInfo($"Employee ID validation passed - ID '{trimmedId}' is unique")
                Else
                    _logger.LogWarning($"Employee ID validation failed - ID '{trimmedId}' already exists (found {result} matches)")
                End If
            End If

            ' Show error message if duplicate found
            If Not isUnique Then
                MessageBox.Show("This Employee ID is already in use by another faculty member. Please use a different Employee ID.", 
                              "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Return isUnique

        Catch ex As Exception
            If logErrors Then
                _logger.LogError($"Error validating Employee ID uniqueness for '{employeeId}': {ex.Message}")
            End If
            
            ' Close connection if still open
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try

            MessageBox.Show("Error checking Employee ID uniqueness. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' Fail safe - don't allow save if we can't validate
        End Try
    End Function
End Class
