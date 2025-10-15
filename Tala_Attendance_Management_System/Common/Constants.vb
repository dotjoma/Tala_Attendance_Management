''' <summary>
''' Application-wide constants - SINGLE SOURCE OF TRUTH
''' </summary>
Public Module Constants
    ' Application Info - UPDATE VERSION HERE ONLY!
    Public Const APP_NAME As String = "Tala Attendance Management System"
    Public Const APP_VERSION As String = "2.3.2" 

    ' Database
    Public Const DB_DSN As String = "tala_ams"

    ' Date/Time Formats
    Public Const DATE_FORMAT As String = "yyyy-MM-dd"
    Public Const TIME_FORMAT As String = "HH:mm:ss"
    Public Const DATETIME_FORMAT As String = "yyyy-MM-dd HH:mm:ss"
    Public Const DISPLAY_DATE_FORMAT As String = "MMMM dd, yyyy"
    Public Const DISPLAY_TIME_FORMAT As String = "hh:mm:ss tt"

    ' File Paths
    Public Const LOGS_FOLDER As String = "Logs"
    Public Const REPORTS_FOLDER As String = "Reports"

    ' User Roles
    Public Const ROLE_ADMIN As String = "admin"
    Public Const ROLE_HR As String = "hr"
    Public Const ROLE_TEACHER As String = "teacher"
    Public Const ROLE_ATTENDANCE As String = "attendance"

    ' Validation
    Public Const MIN_PASSWORD_LENGTH As Integer = 8
    Public Const MAX_USERNAME_LENGTH As Integer = 50
    
    ' Age Validation
    Public Const MIN_FACULTY_AGE As Integer = 18
    Public Const MAX_FACULTY_AGE As Integer = 100
    Public Const MIN_BIRTH_YEAR As Integer = 1900
    
    ' Address Validation - Regions without provinces
    Public Const NCR_REGION_NAME As String = "NATIONAL CAPITAL REGION (NCR)"
    Public Const NCR_REGION_CODE As String = "130000000"

    ' UI
    Public Const DEFAULT_GRID_ROW_HEIGHT As Integer = 50
    Public Const DEFAULT_FONT_SIZE As Single = 12.0F
End Module
