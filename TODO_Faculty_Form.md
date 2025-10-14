# TODO: Faculty Form Improvements

## Overview

Improvements needed for the Add/Edit Faculty form to enhance data validation, user experience, and data integrity.

---

## 1. Middle Name Field

**Task:** Remove asterisk (required field indicator) from middle name

**Current State:** Middle name is marked as required (\*)
**Expected State:** Middle name should be optional (no asterisk)

**Implementation:**

- [x] Remove asterisk from middle name label ✅ (Done manually in Designer)
- [x] Update validation to allow empty middle name ✅
- [x] Test: Create faculty without middle name should succeed

**Files to Modify:**

- `AddFaculty.Designer.vb` - Remove asterisk from label
- `AddFaculty.vb` - Update validation logic

---

## 2. Department Sorting/Selection

**Task:** Add department dropdown with sorting

**Current State:** No department categorization
**Expected State:** Dropdown with departments (English, Filipino, Math, Science, etc.)

**Implementation:**

- [x] Add ComboBox for department selection
- [x] Populate with departments:
  - English
  - Filipino
  - Mathematics
  - Science
  - Social Studies
  - MAPEH (Music, Arts, PE, Health)
  - TLE (Technology and Livelihood Education)
  - Values Education
  - Computer/ICT
  - Others
- [x] Make it required field

**Database Changes:**

```sql
-- Check if department column exists in teacherinformation table
ALTER TABLE `teacherinformation`
ADD COLUMN `department` VARCHAR(100) DEFAULT NULL;
```

**Files to Modify:**

- `AddFaculty.Designer.vb` - Add ComboBox control
- `AddFaculty.vb` - Add department logic
- `database/tala_ams.sql` - Add department column

---

## 3. Date of Birth Validation

**Task:** Restrict date of birth to valid past dates only

**Current State:** Can input future dates
**Expected State:** Only allow dates in the past, show error for future dates

**Implementation:**

- [x] Add validation: `dateOfBirth <= DateTime.Today`
- [x] Add validation: Minimum age (e.g., 18 years old for faculty)
- [x] Add validation: Maximum age (e.g., not older than 100 years)
- [x] Show error message: "Invalid date of birth. Please enter a valid past date."
- [x] Prevent form submission if date is invalid

**Validation Rules:**

```vb
' Date must be in the past
If dtpDateOfBirth.Value.Date > DateTime.Today Then
    MessageBox.Show("Date of birth cannot be in the future.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    Return False
End If

' Minimum age: 18 years old
If DateTime.Today.Year - dtpDateOfBirth.Value.Year < 18 Then
    MessageBox.Show("Faculty member must be at least 18 years old.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    Return False
End If
```

**Files to Modify:**

- `AddFaculty.vb` - Add date validation in save method

---

## 4. Sex/Gender Field

**Task:** Update sex options to include "Others"

**Current State:** Only Male/Female
**Expected State:** Male, Female, Others

**Implementation:**

- [x] Update ComboBox items:
  - Male
  - Female
  - Others
- [x] Update database enum if needed
- [x] Test all three options

**Database Changes (if using ENUM):**

```sql
ALTER TABLE `teacherinformation`
MODIFY `sex` ENUM('Male', 'Female', 'Others') NOT NULL;
```

**Files to Modify:**

- `AddFaculty.Designer.vb` - Update ComboBox items
- `database/tala_ams.sql` - Update enum if applicable

---

## 5. Address - Region/Province Logic

**Task:** Handle regions without provinces (NCR, etc.)

**Current State:** Province is always required
**Expected State:**

- If region has no provinces (e.g., NCR), hide/disable province field
- Remove asterisk from province (make it conditional)

**Implementation:**

- [x] Add region ComboBox change event
- [x] Check if selected region has provinces
- [x] If NCR or similar: Hide/disable province dropdown
- [x] If regular region: Show/enable province dropdown
- [x] Remove asterisk from province label
- [x] Update validation logic

**Regions without Provinces:**

- NCR (National Capital Region)

**Logic:**

```vb
Private Sub cboRegion_SelectedIndexChanged(sender As Object, e As EventArgs)
    If cboRegion.Text = "NCR" Then
        cboProvince.Enabled = False
        cboProvince.Visible = False
        lblProvince.Text = "Province" ' Remove asterisk
    Else
        cboProvince.Enabled = True
        cboProvince.Visible = True
        LoadProvinces(cboRegion.SelectedValue)
    End If
End Sub
```

**Files to Modify:**

- `AddFaculty.Designer.vb` - Update province label
- `AddFaculty.vb` - Add region change logic

---

## 6. RFID Tag Uniqueness ✅ COMPLETED

**Task:** Ensure RFID tags are unique across all faculty

**Current State:** ✅ RFID uniqueness validation implemented
**Expected State:** ✅ Show error if RFID tag is already in use

**Implementation:**

- [x] Add validation function to check RFID uniqueness ✅
- [x] Query database for existing RFID tag ✅
- [x] Show error: "This RFID tag is already in use by another faculty member." ✅
- [x] Prevent form submission if duplicate ✅
- [x] When editing, exclude current faculty from check ✅
- [x] Add Employee ID uniqueness validation ✅ (Bonus)
- [x] Add real-time validation with visual feedback ✅ (Bonus)

**Features Added:**

- `ValidationHelper.IsRfidTagUnique()` - Validates RFID uniqueness
- `ValidationHelper.IsEmployeeIdUnique()` - Validates Employee ID uniqueness
- Real-time validation on field leave events
- Visual feedback (red background for duplicates)
- Proper exclusion of current faculty during edit mode
- Comprehensive error handling and logging

**Validation Function:**

```vb
Private Function IsRFIDUnique(rfidTag As String, Optional excludeFacultyID As Integer = 0) As Boolean
    Try
        connectDB()
        Dim query As String = "SELECT COUNT(*) FROM teacherinformation WHERE tagID = ? AND teacherID <> ? AND isActive = 1"
        Dim cmd As New OdbcCommand(query, con)
        cmd.Parameters.AddWithValue("?", rfidTag)
        cmd.Parameters.AddWithValue("?", excludeFacultyID)

        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        Return count = 0
    Catch ex As Exception
        MessageBox.Show("Error checking RFID uniqueness: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
    Finally
        con.Close()
    End Try
End Function
```

**Files to Modify:**

- `AddFaculty.vb` - Add RFID validation

---

## 7. Emergency Contact - Add Spouse Relationship

**Task:** Add "Spouse" to relationship dropdown

**Current State:** Limited relationship options
**Expected State:** Include Spouse in relationship options

**Implementation:**

- [x] Add "Spouse" to emergency contact relationship ComboBox
- [x] Update items:
  - Parent
  - Sibling
  - Spouse ← NEW
  - Child
  - Guardian
  - Friend
  - Others

**Files to Modify:**

- `AddFaculty.Designer.vb` - Update relationship ComboBox

---

## 8. Replace Delete with Enable/Disable Toggle ✅ COMPLETED

**Task:** Replace "Delete Records" with "Enable/Disable" toggle

**Current State:** ✅ Toggle button implemented with status management
**Expected State:** ✅ Toggle button to enable/disable faculty (soft delete)

**Implementation:**

- [x] Remove "Delete" button ✅
- [x] Add "Enable/Disable" toggle button or switch ✅
- [x] Update to set `isActive = 0` (disable) or `isActive = 1` (enable) ✅
- [x] Show confirmation: "Are you sure you want to disable this faculty member?" ✅
- [x] Update grid to show status (Active/Inactive) ✅
- [x] Add filter to show Active/Inactive/All ✅

**Features Added:**

- `btnToggleStatus` - Toggle button replacing delete functionality
- `cboStatusFilter` - ComboBox to filter by Active/Inactive/All
- `ColumnStatus` - DataGridView column showing faculty status
- Smart confirmation messages with faculty names
- Comprehensive logging for all status changes
- Default filter set to "Active" for better UX

**Toggle Logic:**

```vb
Private Sub btnToggleStatus_Click(sender As Object, e As EventArgs)
    If selectedFacultyID = 0 Then
        MessageBox.Show("Please select a faculty member.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return
    End If

    Dim currentStatus As Integer = GetFacultyStatus(selectedFacultyID)
    Dim action As String = If(currentStatus = 1, "disable", "enable")

    Dim result As DialogResult = MessageBox.Show(
        $"Are you sure you want to {action} this faculty member?",
        $"Confirm {action.ToUpper()}",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

    If result = DialogResult.Yes Then
        ToggleFacultyStatus(selectedFacultyID)
        RefreshGrid()
    End If
End Sub

Private Sub ToggleFacultyStatus(facultyID As Integer)
    Try
        connectDB()
        Dim query As String = "UPDATE teacherinformation SET isActive = IF(isActive = 1, 0, 1) WHERE teacherID = ?"
        Dim cmd As New OdbcCommand(query, con)
        cmd.Parameters.AddWithValue("?", facultyID)
        cmd.ExecuteNonQuery()

        MessageBox.Show("Faculty status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Catch ex As Exception
        MessageBox.Show("Error updating status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Finally
        con.Close()
    End Try
End Sub
```

**Files to Modify:**

- `FormFaculty.Designer.vb` - Replace Delete button with Toggle button
- `FormFaculty.vb` - Add toggle logic
- Add status column to DataGridView

---

## Summary Checklist

### Required Changes:

- [x] 1. Remove asterisk from middle name ✅
- [x] 2. Add department dropdown with sorting ✅
- [x] 3. Add date of birth validation (no future dates) ✅
- [x] 4. Add "Others" to sex/gender options ✅
- [x] 5. Handle regions without provinces (NCR) ✅
- [x] 6. Add RFID tag uniqueness validation ✅
- [x] 7. Add "Spouse" to emergency contact relationship
- [x] 8. Replace Delete with Enable/Disable toggle ✅

### Database Changes Needed:

- [x] Add `department` column to `teacherinformation`
- [x] Update `sex` enum to include 'Others'

### Testing Required:

- [x] Test middle name as optional
- [x] Test department selection and sorting
- [x] Test date validation (past, future, age limits)
- [x] Test all sex/gender options
- [x] Test NCR region (no province)
- [ ] Test RFID uniqueness (new and edit)
- [x] Test spouse relationship option
- [x] Test enable/disable toggle
- [x] Test grid filtering (Active/Inactive/All)

---

## Priority Order:

1. **High Priority:** RFID uniqueness, Date validation, Enable/Disable toggle
2. **Medium Priority:** Department dropdown, Region/Province logic
3. **Low Priority:** Middle name asterisk, Sex options, Spouse relationship

---

## Estimated Time:

- Database changes: 30 minutes
- Form modifications: 2-3 hours
- Validation logic: 1-2 hours
- Testing: 1 hour
- **Total: 4-6 hours**
