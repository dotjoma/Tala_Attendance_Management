### **ADMIN LOGIN**
- [x] Dapat may restrictions per log in like for Admin (whole system access) HR (lahat maliban sa user management form)

### **Main interface**
- [x] Aalisin ang dashboard papalitan ng logo ng tala high school na buo

### **Faculty form**
- [x] middle name is hindi naka asterisk
- [x] lagyan ng sorting kung anong department ba 
ito kasali (English, filipino, etc..)
- [x] sa date of birth dapat may restrictions sa date na ilalagay (halimbawa mag iinput ako ng birthday pero future katulad ng December 2025 e wala pa naming December ngayon, maglalagay dapat ng invalid entry)
- [x] sex – male female others
- [x] Address – pa indicate na dapat yung mga region na walang province at hindi lalabas sa province at tanggalin ang asterisk sa province
- [x] RFID tag dapat unique pag nagamit na yung tag hindi na dapat sya magagamit ulit (pag nag add ng faculty at same RFID TAG dapat may prompt na lalabas “this tag is already used”)
- [x] Incase of emergency – relationship dadagdagan ng spouse
- [x] Tanggalin ang delete records – palitan ng enable disable toggle

---

### 📁 **Clean Architecture Implementation**

```
Tala_Attendance_Management_System/
├── 📁 Core/                           # Business Logic Layer
│   ├── 📁 Entities/                   # Domain Entities
│   │   └── Department.vb
│   ├── 📁 Interfaces/                 # Contracts & Abstractions
│   │   ├── IDepartmentService.vb
│   │   └── ILogger.vb
│   ├── 📁 Models/                     # Data Models
│   │   └── VersionInfo.vb
│   └── 📁 Services/                   # Business Services
│       ├── DepartmentService.vb
│       ├── UpdateManager.vb
│       └── UpdateService.vb
│
├── 📁 Infrastructure/                 # External Concerns
│   ├── 📁 Data/                       # Data Access Layer
│   │   ├── 📁 Context/
│   │   └── 📁 Repositories/
│   │       └── DepartmentRepository.vb
│   └── 📁 Logging/                    # Logging Implementation
│       ├── FileLogger.vb
│       ├── LoggerFactory.vb
│       └── README.md
│
├── 📁 Presentation/                   # UI Layer
│   ├── 📁 Forms/                      # Application Forms
│   │   ├── 📁 Authentication/
│   │   │   └── LoginForm.vb
│   │   ├── 📁 Main/
│   │   │   └── MainForm.vb
│   │   ├── 📁 Faculty/
│   │   │   ├── FormFaculty.vb
│   │   │   ├── FormFaculty.Designer.vb
│   │   │   ├── AddFaculty.vb
│   │   │   └── AddFaculty.Designer.vb
│   │   ├── 📁 Users/
│   │   │   ├── ManageUser.vb
│   │   │   └── ManageUser.Designer.vb
│   │   ├── 📁 Departments/
│   │   │   ├── FormDepartments.vb
│   │   │   ├── AddDepartment.vb
│   │   │   └── DepartmentSelector.vb
│   │   ├── 📁 Update/                 # Auto-Update System
│   │   │   ├── UpdateDialog.vb
│   │   │   ├── UpdateDialog.Designer.vb
│   │   │   └── UpdateDialog.resx
│   │   ├── 📁 Classrooms/
│   │   ├── 📁 Students/
│   │   ├── 📁 Subjects/
│   │   ├── 📁 Sections/
│   │   ├── 📁 Schedules/
│   │   ├── 📁 Attendance/
│   │   └── 📁 Announcements/
│   └── 📁 Helpers/                    # UI Helper Classes
│       └── FormHelper.vb
│
├── 📁 Common/                         # Shared Utilities
│   ├── AppConfig.vb                   # Configuration Management
│   ├── Constants.vb                   # Application Constants
│   ├── Enums.vb                       # Common Enumerations
│   ├── Extensions.vb                  # Extension Methods
│   ├── LogLevel.vb                    # Logging Levels
│   └── 📁 Helpers/                    # Helper Classes
│       ├── NetworkHelper.vb           # Network Operations
│       ├── ValidationHelper.vb        # Data Validation
│       └── NameFormatter.vb           # Name Formatting
│
├── 📁 Config/                         # Configuration Files
│   ├── config.dev.json               # Development Settings
│   ├── config.staging.json           # Staging Settings
│   └── config.prod.json              # Production Settings
│
├── 📁 BuildScripts/                   # Build Automation
│   ├── EmbedDlls.bat                 # DLL Embedding Script
│   └── SetEnvironment.bat            # Environment Setup
│
├── 📁 Legacy/                         # Legacy Code
│   └── myModule.vb                   # Original Module
│
├── 📁 Resources/                      # Application Resources
│   ├── 📁 icons/                     # Icon Files
│   └── [Various Image Files]         # UI Images & Assets
│
├── 📁 Build/                          # Build Output
│   └── TalaSystem/                   # Deployment Package
│
├── 📁 Project_Release/                # Release Build
│   ├── TalaAMS.exe                   # Main Executable
│   ├── 📁 Config/                    # Runtime Configuration
│   └── 📁 Logs/                      # Application Logs
│
├── 📁 bin/                           # Compiled Output
│   ├── 📁 Debug/                     # Debug Build
│   └── 📁 Release/                   # Release Build
│
├── App.config                        # Application Configuration
├── Tala_Attendance_Management_System.vbproj  # Project File
├── logo.ico                          # Application Icon
├── CHANGELOG.md                      # Change History
└── ACCOMPLISHED.md                   # This File
```