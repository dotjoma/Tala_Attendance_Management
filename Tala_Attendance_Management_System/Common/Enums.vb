''' <summary>
''' User roles in the system
''' </summary>
Public Enum UserRole
    Admin = 1
    HR = 2
    Teacher = 3
    Attendance = 4
End Enum

''' <summary>
''' Attendance status
''' </summary>
Public Enum AttendanceStatus
    Present = 1
    Absent = 2
    Late = 3
    Excused = 4
End Enum

''' <summary>
''' Record status for soft delete
''' </summary>
Public Enum RecordStatus
    Active = 1
    Inactive = 0
    Deleted = -1
End Enum
