Public Class AssignSection
    Private isProgrammaticChange As Boolean = False

    Public Sub DefaultSettings()
        dgvStudentSection.Tag = 0
        dgvStudentSection.RowTemplate.Height = 40
        dgvStudentSection.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvStudentSection.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStudentSection.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvStudentSection.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 10)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        ' Disable alternating row styles to ensure consistent font style
        dgvStudentSection.AlternatingRowsDefaultCellStyle = dgvStudentSection.DefaultCellStyle

        ' Set row font to Segoe UI for all rows
        dgvStudentSection.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvStudentSection.DefaultCellStyle.ForeColor = Color.Black

        dgvStudentSection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvStudentSection.AutoGenerateColumns = False

        ' Load year levels into ComboBox
        loadCBO("SELECT * FROM gradelevel WHERE isActive = 1", "gradeID", "gradelevel", cbYearLevel)


        Dim selectedYearLevel As String = If(cbYearLevel.SelectedValue IsNot Nothing, cbYearLevel.SelectedValue.ToString(), "")

        loadCBO($"SELECT section_id, CONCAT(year_level, ' ',section_name) AS section FROM sections WHERE isActive=1", "section_id", "section", cbSections)
        cbSections.SelectedIndex = -1


    End Sub

    Private Function GetStudentSection(ByVal studentID As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            connectDB()
            Dim cmd As New Odbc.OdbcCommand("SELECT s.section_name, s.year_level FROM sections s INNER JOIN student_sections ss ON s.section_id = ss.section_id WHERE ss.student_id = ?", con)
            cmd.Parameters.AddWithValue("@student_id", studentID)
            Dim da As New Odbc.OdbcDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Private Sub AssignSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub
    Private Sub ComboBoxDefault()
        ' Check if a year level is selected
        If cbYearLevel.SelectedIndex <> -1 Then
            ' Get the selected year level
            Dim selectedYearLevel As String = If(cbYearLevel.SelectedValue IsNot Nothing, cbYearLevel.SelectedValue.ToString(), "")

            ' Update the SQL query to filter students based on the selected year level
            Dim query As String = "SELECT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, sr.gender, " &
                                  "CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, pr.contactNo AS phone_number, " &
                                  "pr.address FROM studentrecords sr " &
                                  "JOIN parentrecords pr ON pr.parentID = sr.parentID " &
                                  "WHERE sr.isActive = 1 AND sr.gradeID = '" & selectedYearLevel & "' AND sr.section_id IS NULL " &
                                  "ORDER BY student_name"

            ' Call loadDGV with the updated query
            loadDGV(query, dgvStudentSection)

            cbSections.DataSource = Nothing
            cbSections.Items.Clear()
            cbSections.SelectedValue = 0
            If cbSections.SelectedIndex <> -1 Then
                ' Call the loadCBO method to populate the ComboBox
                loadCBO("SELECT section_id, CONCAT(year_level, ' ',section_name) AS section 
                             FROM sections 
                             WHERE isActive=1 AND year_level=" & selectedYearLevel, "section_id", "section", cbSections)
            End If
        End If
    End Sub
    Private Sub cbYearLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYearLevel.SelectedIndexChanged
        Try
            ComboBoxDefault()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub chkShowOptions_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowOptions.CheckedChanged
        ' Exit if the change was made programmatically
        If isProgrammaticChange Then Exit Sub

        ' Toggle all checkboxes in the DataGridView based on chkShowOptions
        Dim checkAll As Boolean = chkShowOptions.Checked

        ' Update the text of chkShowOptions based on its state
        chkShowOptions.Text = If(checkAll, "Deselect All", "Select All")

        ' Set the checkbox cells in the DataGridView based on chkShowOptions state
        For Each row As DataGridViewRow In dgvStudentSection.Rows
            row.Cells("chkSelect").Value = checkAll
        Next
    End Sub

    Private Sub UpdateChkShowOptionsText()
        Dim allChecked As Boolean = True
        Dim anyChecked As Boolean = False

        ' Check the status of all checkboxes in the DataGridView
        For Each row As DataGridViewRow In dgvStudentSection.Rows
            Dim cell As DataGridViewCheckBoxCell = DirectCast(row.Cells("chkSelect"), DataGridViewCheckBoxCell)
            If Convert.ToBoolean(cell.Value) Then
                anyChecked = True
            Else
                allChecked = False
            End If
        Next

        ' Temporarily set the isProgrammaticChange flag to avoid triggering the CheckedChanged event
        isProgrammaticChange = True
        If allChecked Then
            chkShowOptions.Text = "Deselect All"
            chkShowOptions.Checked = True
        Else
            chkShowOptions.Text = If(anyChecked, "Deselect All", "Select All")
            chkShowOptions.Checked = False
        End If
        isProgrammaticChange = False
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Check if there are selected students
        Dim selectedRows As Integer = 0
        Dim sectionId As Integer = Convert.ToInt32(cbSections.SelectedValue) ' Assuming you are assigning by year level

        ' Ensure a valid section ID is selected
        If sectionId = 0 Then
            MessageBox.Show("Please select a valid section before assigning students.")
            Return
        End If

        ' Start database connection and loop through each row
        Try
            connectDB()
            For Each row As DataGridViewRow In dgvStudentSection.Rows
                Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("chkSelect").Value)

                ' If the row is selected
                If isChecked Then
                    Dim studId As Integer = Convert.ToInt32(row.Cells("studID").Value)
                    Dim assignmentDate As Date = Date.Now

                    ' SQL query to insert into student_sections table
                    Dim cmd As New Odbc.OdbcCommand("INSERT INTO student_sections (studID, section_id, assignment_date) VALUES (?, ?, ?)", con)
                    cmd.Parameters.AddWithValue("@studID", studId)
                    cmd.Parameters.AddWithValue("@section_id", sectionId)
                    cmd.Parameters.AddWithValue("@assignment_date", assignmentDate)

                    cmd.ExecuteNonQuery()

                    ' SQL query to insert into student_sections table
                    Dim updateStudentSectionID As New Odbc.OdbcCommand("UPDATE studentrecords SET section_id=? WHERE studID=?", con)
                    updateStudentSectionID.Parameters.AddWithValue("@section_id", sectionId)
                    updateStudentSectionID.Parameters.AddWithValue("@studID", studId)

                    updateStudentSectionID.ExecuteNonQuery()

                    selectedRows += 1
                End If
            Next

            ' Confirm the addition of selected rows
            If selectedRows > 0 Then
                MessageBox.Show($"{selectedRows} students have been assigned to the section successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No students were selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            chkShowOptions.Checked = False
            dgvStudentSection.CurrentCell = Nothing
            ComboBoxDefault()
            btnCancel.Text = "Close"
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dgvStudentSection_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvStudentSection.DataBindingComplete
        dgvStudentSection.CurrentCell = Nothing
    End Sub

    Private Sub AssignSection_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Check if the form "AddStudentSection" is open
        Dim addStudentForm As Form = Application.OpenForms("AddStudentSection")

        If addStudentForm IsNot Nothing Then
            ' Call the DefaultSettings method on the open form
            CType(addStudentForm, AddStudentSection).DefaultSettings()
        End If
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            Try
                connectDB() ' Ensure your connection is established here

                Dim selectedYearLevel As String = If(cbYearLevel.SelectedValue IsNot Nothing, cbYearLevel.SelectedValue.ToString(), "")
                Dim selectedSection As String = If(cbSections.SelectedValue IsNot Nothing, cbSections.SelectedValue.ToString(), "")

                Dim query As String = "SELECT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, sr.gender, " &
                                      "CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, pr.contactNo AS phone_number, " &
                                      "pr.address FROM studentrecords sr " &
                                      "JOIN parentrecords pr ON pr.parentID = sr.parentID " &
                                      "WHERE sr.isActive = 1 " &
                                      "AND (sr.gradeID = ? OR ? = '') " & ' Filter by selected year level or ignore if not selected
                                      "AND (sr.section_id = ? OR ? = '') " & ' Filter by selected section or ignore if not selected
                                      "AND (CONCAT(sr.firstname, ' ', sr.lastname) LIKE ? OR " &
                                      "pr.address LIKE ? OR " &
                                      "CONCAT(pr.firstname, ' ', pr.lastname) LIKE ?) " & ' Search terms
                                      "ORDER BY student_name"

                Using cmd As New Odbc.OdbcCommand(query, con)
                    ' Add parameters for filtering by year level and section
                    cmd.Parameters.AddWithValue("@year_level", selectedYearLevel)
                    cmd.Parameters.AddWithValue("@year_level_check", selectedYearLevel) ' to handle empty check
                    cmd.Parameters.AddWithValue("@section", selectedSection)
                    cmd.Parameters.AddWithValue("@section_check", selectedSection) ' to handle empty check

                    ' Add parameters for the search input with wildcards for partial matching
                    Dim searchValue As String = "%" & txtSearch.Text.Trim() & "%"
                    cmd.Parameters.AddWithValue("@search1", searchValue) ' For student_name
                    cmd.Parameters.AddWithValue("@search2", searchValue) ' For address
                    cmd.Parameters.AddWithValue("@search3", searchValue) ' For contact_person

                    Dim adapter As New Odbc.OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    ' Load the results into the DataGridView
                    dgvStudentSection.DataSource = dt
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                con.Close() ' Close the connection
            End Try
        Else
            ' Reload original data if search box is empty
            ComboBoxDefault()
        End If
    End Sub

    Private Sub dgvStudentSection_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudentSection.CellClick
        Try

            If e.ColumnIndex = dgvStudentSection.Columns("chkSelect").Index AndAlso e.RowIndex >= 0 Then
                Dim cell As DataGridViewCheckBoxCell = DirectCast(dgvStudentSection.Rows(e.RowIndex).Cells("chkSelect"), DataGridViewCheckBoxCell)
                cell.Value = Not Convert.ToBoolean(cell.Value)

                ' Check the state of all checkboxes to update chkShowOptions text
                UpdateChkShowOptionsText()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbSections_Click(sender As Object, e As EventArgs) Handles cbSections.Click
        Try
            cbSections.DataSource = Nothing
            cbSections.Items.Clear()

            Dim selectedYearLevel As String = If(cbYearLevel.SelectedValue IsNot Nothing, cbYearLevel.SelectedValue.ToString(), "")

            loadCBO("SELECT section_id, CONCAT(year_level, ' ',section_name) AS section 
                             FROM sections 
                             WHERE isActive=1 AND year_level=" & selectedYearLevel, "section_id", "section", cbSections)
        Catch ex As Exception

        End Try
    End Sub
End Class
