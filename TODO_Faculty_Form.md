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

- [ ] Add validation: `dateOfBirth <= DateTime.Today`
- [ ] Add validation: Minimum age (e.g., 18 years old for faculty)
- [ ] Add validation: Maximum age (e.g., not older than 100 years)
- [ ] Show error message: "Invalid date of birth. Please enter a valid past date."
- [ ] Prevent form submission if date is invalid

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

- [ ] Update ComboBox items:
  - Male
  - Female
  - Others
- [ ] Update database enum if needed
- [ ] Test all three options

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

- [ ] Add region ComboBox change event
- [ ] Check if selected region has provinces
- [ ] If NCR or similar: Hide/disable province dropdown
- [ ] If regular region: Show/enable province dropdown
- [ ] Remove asterisk from province label
- [ ] Update validation logic

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

## 6. RFID Tag Uniqueness

**Task:** Ensure RFID tags are unique across all faculty

**Current State:** No uniqueness check
**Expected State:** Show error if RFID tag is already in use

**Implementation:**

- [ ] Add validation function to check RFID uniqueness
- [ ] Query database for existing RFID tag
- [ ] Show error: "This RFID tag is already in use by another faculty member."
- [ ] Prevent form submission if duplicate
- [ ] When editing, exclude current faculty from check

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

- [ ] Add "Spouse" to emergency contact relationship ComboBox
- [ ] Update items:
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

## 8. Replace Delete with Enable/Disable Toggle

**Task:** Replace "Delete Records" with "Enable/Disable" toggle

**Current State:** Delete button permanently removes records
**Expected State:** Toggle button to enable/disable faculty (soft delete)

**Implementation:**

- [ ] Remove "Delete" button
- [ ] Add "Enable/Disable" toggle button or switch
- [ ] Update to set `isActive = 0` (disable) or `isActive = 1` (enable)
- [ ] Show confirmation: "Are you sure you want to disable this faculty member?"
- [ ] Update grid to show status (Active/Inactive)
- [ ] Add filter to show Active/Inactive/All

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

- [ ] 1. Remove asterisk from middle name
- [ ] 2. Add department dropdown with sorting
- [ ] 3. Add date of birth validation (no future dates)
- [ ] 4. Add "Others" to sex/gender options
- [ ] 5. Handle regions without provinces (NCR)
- [ ] 6. Add RFID tag uniqueness validation
- [ ] 7. Add "Spouse" to emergency contact relationship
- [ ] 8. Replace Delete with Enable/Disable toggle

### Database Changes Needed:

- [ ] Add `department` column to `teacherinformation`
- [ ] Update `sex` enum to include 'Others'

### Testing Required:

- [ ] Test middle name as optional
- [ ] Test department selection and sorting
- [ ] Test date validation (past, future, age limits)
- [ ] Test all sex/gender options
- [ ] Test NCR region (no province)
- [ ] Test RFID uniqueness (new and edit)
- [ ] Test spouse relationship option
- [ ] Test enable/disable toggle
- [ ] Test grid filtering (Active/Inactive/All)

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
