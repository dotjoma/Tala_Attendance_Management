Imports System.IO
Imports System.Data.Odbc
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer

Public Class FormFaculty
    Private ReadOnly _logger As ILogger = LoggerFactory.Instance

    Private Sub LoadAddressComboBoxes(regionId As String, provinceId As String, cityId As String, brgyId As String)
        Try
            _logger.LogInfo($"FormFaculty - Loading address ComboBoxes for editing - Region: {regionId}, Province: {provinceId}, City: {cityId}, Barangay: {brgyId}")

            ' Ensure connection is available
            connectDB()

            ' Load Region ComboBox first
            loadCBO("SELECT * FROM refregion ORDER BY regDesc", "id", "regDesc", AddFaculty.cbRegion)
            AddFaculty.cbRegion.SelectedValue = regionId

            ' Load Province ComboBox based on selected region
            If Not String.IsNullOrEmpty(regionId) Then
                connectDB() ' Ensure fresh connection
                Dim regionCmd As New OdbcCommand("SELECT regCode FROM refregion WHERE id = ?", con)
                regionCmd.Parameters.AddWithValue("?", regionId)
                Dim regionCode As String = regionCmd.ExecuteScalar()?.ToString()

                If Not String.IsNullOrEmpty(regionCode) Then
                    loadCBO($"SELECT * FROM refprovince WHERE regCode = {regionCode} ORDER BY provdesc", "id", "provdesc", AddFaculty.cbProvince)
                    AddFaculty.cbProvince.SelectedValue = provinceId
                End If
            End If

            ' Load City ComboBox based on selected province
            If Not String.IsNullOrEmpty(provinceId) Then
                connectDB() ' Ensure fresh connection
                Dim provinceCmd As New OdbcCommand("SELECT provCode FROM refprovince WHERE id = ?", con)
                provinceCmd.Parameters.AddWithValue("?", provinceId)
                Dim provinceCode As String = provinceCmd.ExecuteScalar()?.ToString()

                If Not String.IsNullOrEmpty(provinceCode) Then
                    loadCBO($"SELECT * FROM refcitymun WHERE provcode = {provinceCode} ORDER BY citymundesc", "id", "citymundesc", AddFaculty.cbCity)
                    AddFaculty.cbCity.SelectedValue = cityId
                End If
            End If

            ' Load Barangay ComboBox based on selected city
            If Not String.IsNullOrEmpty(cityId) Then
                connectDB() ' Ensure fresh connection
                Dim cityCmd As New OdbcCommand("SELECT citymunCode FROM refcitymun WHERE id = ?", con)
                cityCmd.Parameters.AddWithValue("?", cityId)
                Dim cityCode As String = cityCmd.ExecuteScalar()?.ToString()

                If Not String.IsNullOrEmpty(cityCode) Then
                    loadCBO($"SELECT * FROM refbrgy WHERE citymuncode = {cityCode} ORDER BY brgydesc", "id", "brgydesc", AddFaculty.cbBrgy)
                    AddFaculty.cbBrgy.SelectedValue = brgyId
                End If
            End If

            _logger.LogInfo("FormFaculty - Address ComboBoxes loaded successfully for editing")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading address ComboBoxes: {ex.Message}")
        Finally
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try
        End Try
    End Sub
    Public Sub DefaultSettings()
        Try
            _logger.LogInfo("FormFaculty - Loading default settings and faculty list")

            dgvTeachers.Tag = 0
            dgvTeachers.CurrentCell = Nothing

            dgvTeachers.CellBorderStyle = DataGridViewCellBorderStyle.None
            dgvTeachers.RowTemplate.Height = 50
            dgvTeachers.DefaultCellStyle.Font = New Font("Segoe UI", 14)
            dgvTeachers.AlternatingRowsDefaultCellStyle = dgvTeachers.DefaultCellStyle
            dgvTeachers.AutoGenerateColumns = False

            loadDGV("
                SELECT ti.teacherID AS teacherID, 
                ti.employeeID AS employeeID, 
                " & GetNameConcatSQL() & " AS teacher_name, 
                email, ti.gender AS gender, ti.birthdate AS birthdate, 
                ti.contactNo AS contactNo, 
                CONCAT(ti.homeadd, ' ', rb.brgyDesc, '. ', rc.citymunDesc) AS teacher_address, 
                ti.emergencyContact AS emergencyContact 
                FROM teacherinformation ti JOIN refregion rg ON ti.regionID = rg.id 
                JOIN refprovince rp ON ti.provinceID = rp.id 
                JOIN refcitymun rc ON ti.cityID = rc.id 
                JOIN refbrgy rb ON ti.brgyID = rb.id 
                WHERE ti.isActive = 1", dgvTeachers)

            _logger.LogInfo($"FormFaculty - Faculty list loaded successfully, {dgvTeachers.Rows.Count} records displayed")
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error in DefaultSettings: {ex.Message}")
            Throw
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _logger.LogInfo("FormFaculty - Add Faculty button clicked, opening AddFaculty form")
        AddFaculty.ShowDialog()
        ' Refresh the list after adding
        DefaultSettings()
        _logger.LogInfo("FormFaculty - Returned from AddFaculty form, faculty list refreshed")
    End Sub

    Private Sub FormFaculty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _logger.LogInfo("FormFaculty - Form loaded, initializing default settings")
        DefaultSettings()
    End Sub

    Private Sub btnDeleteRecord_Click(sender As Object, e As EventArgs) Handles btnDeleteRecord.Click
        Dim cmd As Odbc.OdbcCommand
        Dim facultyId As Integer = 0

        Try
            If dgvTeachers.Tag IsNot Nothing AndAlso IsNumeric(dgvTeachers.Tag) Then
                facultyId = CInt(dgvTeachers.Tag)
            End If

            _logger.LogInfo($"FormFaculty - Delete button clicked for Faculty ID: {facultyId}")

            If facultyId > 0 Then
                If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _logger.LogWarning($"FormFaculty - User confirmed deletion of Faculty ID: {facultyId}")

                    ' Ensure fresh connection for delete operation
                    connectDB()
                    cmd = New Odbc.OdbcCommand("UPDATE teacherinformation SET isActive=0 WHERE teacherID=?", con)
                    cmd.Parameters.AddWithValue("@", facultyId)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    _logger.LogInfo($"FormFaculty - Faculty record deleted successfully - Faculty ID: {facultyId}")
                    MessageBox.Show("Record has been deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh the list after successful deletion
                    DefaultSettings()
                Else
                    _logger.LogInfo($"FormFaculty - User cancelled deletion of Faculty ID: {facultyId}")
                End If
            Else
                _logger.LogWarning("FormFaculty - Delete attempted with no faculty selected")
                MessageBox.Show("Please select a record you want to delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error deleting faculty record (ID: {facultyId}): {ex.Message}")
            MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try
            GC.Collect()
        End Try
    End Sub
    Private Sub EditRecord(ByVal id As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim facultyName As String = ""

        Try
            _logger.LogInfo($"FormFaculty - Loading faculty record for editing - Faculty ID: {id}")

            connectDB()
            cmd = New Odbc.OdbcCommand("SELECT teacherID, profileImg, employeeID,tagID,firstname,middlename,lastname,extName, email, gender,birthdate,homeadd,brgyID, cityID, provinceID, regionID,contactNo, emergencyContact, relationship FROM teacherinformation WHERE teacherID=?", con)
            cmd.Parameters.AddWithValue("@", id)
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                facultyName = FormatFullName(dt.Rows(0)("firstname").ToString(), dt.Rows(0)("middlename").ToString(), dt.Rows(0)("lastname").ToString(), dt.Rows(0)("extName").ToString())

                AddFaculty.txtID.Text = dt.Rows(0)("teacherID").ToString()
                AddFaculty.txtEmployeeID.Text = dt.Rows(0)("employeeID").ToString()
                AddFaculty.txtTagID.Text = dt.Rows(0)("tagID").ToString()
                AddFaculty.txtFirstName.Text = dt.Rows(0)("firstname").ToString()
                AddFaculty.txtMiddleName.Text = dt.Rows(0)("middlename").ToString()
                AddFaculty.txtLastName.Text = dt.Rows(0)("lastname").ToString()
                AddFaculty.txtExtName.Text = dt.Rows(0)("extName").ToString()
                AddFaculty.txtEmail.Text = dt.Rows(0)("email").ToString()
                AddFaculty.cbGender.Text = dt.Rows(0)("gender").ToString()
                AddFaculty.dtpBirthdate.Text = dt.Rows(0)("birthdate").ToString()
                AddFaculty.txtHome.Text = dt.Rows(0)("homeadd").ToString()

                ' Load and set address ComboBoxes in proper cascade order
                LoadAddressComboBoxes(dt.Rows(0)("regionID").ToString(), dt.Rows(0)("provinceID").ToString(), dt.Rows(0)("cityID").ToString(), dt.Rows(0)("brgyID").ToString())

                AddFaculty.txtContactNo.Text = dt.Rows(0)("contactNo").ToString()
                AddFaculty.txtEmergencyContact.Text = dt.Rows(0)("emergencyContact").ToString()
                AddFaculty.cbRelationship.Text = dt.Rows(0)("relationship").ToString()

                Dim myreader As Odbc.OdbcDataReader = cmd.ExecuteReader
                If myreader.Read Then
                    Try
                        Dim profileImg As Byte()
                        profileImg = myreader("profileImg")
                        Dim ms As New MemoryStream(profileImg)
                        If profileImg IsNot Nothing Then
                            AddFaculty.pbProfile.Image = Image.FromStream(ms)
                        End If
                    Catch ex As Exception
                        _logger.LogWarning($"FormFaculty - Could not load profile image for Faculty ID: {id}")
                    End Try
                End If

                _logger.LogInfo($"FormFaculty - Faculty record loaded for editing - Name: '{facultyName}', Employee ID: '{dt.Rows(0)("employeeID")}'")
                AddFaculty.ShowDialog()
                ' Refresh the list after editing
                DefaultSettings()
                _logger.LogInfo("FormFaculty - Returned from edit mode, faculty list refreshed")
            Else
                _logger.LogWarning($"FormFaculty - No faculty record found with ID: {id}")
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error loading faculty record for editing (ID: {id}): {ex.Message}")
            MessageBox.Show(ex.Message.ToString())
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    Private Sub btnEditRecord_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        Dim facultyId As Integer = CInt(dgvTeachers.Tag)

        If dgvTeachers.Tag > 0 Then
            _logger.LogInfo($"FormFaculty - Edit button clicked for Faculty ID: {facultyId}")
            If MessageBox.Show("Are you sure you want to edit this record?", "Edit Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _logger.LogInfo($"FormFaculty - User confirmed edit for Faculty ID: {facultyId}")
                EditRecord(Val(dgvTeachers.Tag))
            Else
                _logger.LogInfo($"FormFaculty - User cancelled edit for Faculty ID: {facultyId}")
            End If
        Else
            _logger.LogWarning("FormFaculty - Edit attempted with no faculty selected")
            MessageBox.Show("Please select a record you want to edit", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            If txtSearch.TextLength > 0 Then
                _logger.LogInfo($"FormFaculty - Search performed with term: '{txtSearch.Text.Trim()}'")
                loadDGV("SELECT ti.teacherID AS teacherID, ti.employeeID AS employeeID, " & GetNameConcatSQL() & " AS teacher_name, email, ti.gender AS gender, ti.birthdate AS birthdate, ti.contactNo AS contactNo, CONCAT(ti.homeadd, ' ', rb.brgyDesc, '. ', rc.citymunDesc) AS teacher_address, ti.emergencyContact AS emergencyContact FROM teacherinformation ti JOIN refregion rg ON ti.regionID = rg.id JOIN refprovince rp ON ti.provinceID = rp.id JOIN refcitymun rc ON ti.cityID = rc.id JOIN refbrgy rb ON ti.brgyID = rb.id WHERE ti.isActive=1", dgvTeachers, "ti.lastname", "ti.firstname", "ti.employeeID", txtSearch.Text.Trim)
                _logger.LogInfo($"FormFaculty - Search completed, {dgvTeachers.Rows.Count} results found")
            Else
                _logger.LogInfo("FormFaculty - Search cleared, showing all faculty records")
                loadDGV("SELECT ti.teacherID AS teacherID, ti.employeeID AS employeeID, " & GetNameConcatSQL() & " AS teacher_name, email, ti.gender AS gender, ti.birthdate AS birthdate, ti.contactNo AS contactNo, CONCAT(ti.homeadd, ' ', rb.brgyDesc, '. ', rc.citymunDesc) AS teacher_address, ti.emergencyContact AS emergencyContact FROM teacherinformation ti JOIN refregion rg ON ti.regionID = rg.id JOIN refprovince rp ON ti.provinceID = rp.id JOIN refcitymun rc ON ti.cityID = rc.id JOIN refbrgy rb ON ti.brgyID = rb.id WHERE ti.isActive = 1", dgvTeachers)
            End If
        Catch ex As Exception
            _logger.LogError($"FormFaculty - Error during search operation: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvTeachers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeachers.CellClick
        Try
            If e.RowIndex >= 0 Then
                dgvTeachers.Tag = dgvTeachers.Item(0, e.RowIndex).Value
                _logger.LogInfo($"FormFaculty - Faculty selected - Faculty ID: {dgvTeachers.Tag}")
            End If
        Catch ex As Exception
            _logger.LogWarning($"FormFaculty - Error selecting faculty record: {ex.Message}")
        End Try
    End Sub

    Private Sub dgvTeachers_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTeachers.DataBindingComplete
        dgvTeachers.CurrentCell = Nothing
    End Sub
End Class