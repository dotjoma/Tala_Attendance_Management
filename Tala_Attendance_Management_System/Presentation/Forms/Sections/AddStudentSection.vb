Imports System.Data.SqlClient

Public Class AddStudentSection

    Public Sub DefaultSettings()
        dgvStudentSection.Tag = 0
        dgvStudentSection.RowTemplate.Height = 50
        dgvStudentSection.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvStudentSection.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStudentSection.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvStudentSection.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 13)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        ' Disable alternating row styles to ensure consistent font style
        dgvStudentSection.AlternatingRowsDefaultCellStyle = dgvStudentSection.DefaultCellStyle

        ' Set row font to Segoe UI for all rows
        dgvStudentSection.DefaultCellStyle.Font = New Font("Segoe UI", 12)
        dgvStudentSection.DefaultCellStyle.ForeColor = Color.Black

        dgvStudentSection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvStudentSection.AutoGenerateColumns = False

        'loadDGV("SELECT s.section_name, s.year_level FROM sections s INNER JOIN student_sections ss ON s.section_id = ss.section_id", dgvStudentSection)

        loadDGV("SELECT DISTINCT sr.studID, CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, sr.gender, 
                 CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, pr.contactNo AS phone_number, 
                 pr.address, ss.assignment_date, CONCAT(s.year_level, ' ', s.section_name) AS section, sr.gradeID   
                 FROM studentrecords sr 
                 JOIN sections s ON s.section_id = sr.section_id 
                 JOIN student_sections ss ON ss.section_id = sr.section_id 
                 JOIN parentrecords pr ON pr.parentID = sr.parentID 
                 WHERE sr.isActive = 1 
                 GROUP BY sr.studID, sr.firstname, sr.lastname, sr.gender, pr.firstname, pr.lastname, pr.contactNo, pr.address, s.year_level, s.section_name 
                 ORDER BY section, student_name", dgvStudentSection)


        loadCBO("SELECT section_id, CONCAT(year_level, ' ', section_name) AS section 
                 FROM sections 
                 WHERE isActive = 1 
                 ORDER BY CAST(year_level AS UNSIGNED), section_name;
                 ", "section_id", "section", cbFilter)
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

    Private Sub AddStudentClassSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub btnAssignSection_Click(sender As Object, e As EventArgs) Handles btnAssignSection.Click
        AssignSection.ShowDialog()
    End Sub

    Private Sub cbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFilter.SelectedIndexChanged
        Try
            If cbFilter.SelectedIndex <> -1 Then
                ' Cast the selected item to DataRowView to access the section_id
                Dim selectedRow As DataRowView = DirectCast(cbFilter.SelectedItem, DataRowView)
                Dim section_id As Integer = Convert.ToInt32(selectedRow("section_id"))

                ' Load the DataGridView
                loadDGV($"SELECT DISTINCT 
                        sr.studID, 
                        CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, 
                        sr.gender, 
                        CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, 
                        pr.contactNo AS phone_number, 
                        pr.address, 
                        CONCAT(year_level, ' ', section_name) AS section, sr.gradeID, 
                        ss.assignment_date 
                    FROM studentrecords sr 
                    JOIN sections s ON s.section_id = sr.section_id 
                    JOIN student_sections ss ON ss.section_id = sr.section_id 
                    JOIN parentrecords pr ON pr.parentID = sr.parentID 
                    WHERE sr.isActive = 1 AND sr.section_id = {section_id} 
                    GROUP BY sr.studID, sr.firstname, sr.lastname, sr.gender, pr.firstname, pr.lastname, pr.contactNo, pr.address, s.year_level, s.section_name 
                    ORDER BY student_name, section", dgvStudentSection)

                dgvStudentSection.CurrentCell = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Private Sub dgvStudentSection_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        dgvStudentSection.CurrentCell = Nothing
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            Try
                connectDB() ' Ensure your connection is established here

                Dim query As String = "SELECT 
                sr.studID, 
                CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, 
                sr.gender, 
                CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, 
                pr.contactNo AS phone_number, 
                pr.address, 
                CONCAT(s.year_level, ' ', s.section_name) AS section, gradeID,   
                MAX(ss.assignment_date) AS assignment_date 
            FROM studentrecords sr 
            JOIN sections s ON s.section_id = sr.section_id 
            JOIN student_sections ss ON ss.section_id = sr.section_id 
            JOIN parentrecords pr ON pr.parentID = sr.parentID 
            WHERE sr.isActive = 1 
            AND (CONCAT(sr.firstname, ' ', sr.lastname) LIKE ? OR 
                 pr.address LIKE ? OR 
                 CONCAT(pr.firstname, ' ', pr.lastname) LIKE ?) 
            GROUP BY 
                sr.studID, 
                sr.firstname, 
                sr.lastname, 
                sr.gender, 
                pr.firstname, 
                pr.lastname, 
                pr.contactNo, 
                pr.address, 
                s.year_level, 
                s.section_name 
            ORDER BY student_name, section"

                Using cmd As New Odbc.OdbcCommand(query, con)
                    ' Add the parameter for the search input with wildcards for partial matching
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
            ' Load the original data if search box is empty
            DefaultSettings()
        End If
    End Sub

    Private Sub chkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAll.CheckedChanged
        If chkShowAll.Checked Then
            loadDGV($"SELECT DISTINCT 
                        sr.studID, 
                        CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, 
                        sr.gender, 
                        CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, 
                        pr.contactNo AS phone_number, 
                        pr.address, 
                        CONCAT(year_level, ' ', section_name) AS section, gradeID, 
                        ss.assignment_date 
                    FROM studentrecords sr 
                    JOIN sections s ON s.section_id = sr.section_id 
                    JOIN student_sections ss ON ss.section_id = sr.section_id 
                    JOIN parentrecords pr ON pr.parentID = sr.parentID 
                    WHERE sr.isActive = 1 
                    GROUP BY sr.studID, sr.firstname, sr.lastname, sr.gender, pr.firstname, pr.lastname, pr.contactNo, pr.address, s.year_level, s.section_name 
                    ORDER BY student_name, section", dgvStudentSection)
            cbFilter.SelectedIndex = -1
        Else
            cbFilter.SelectedIndex = 0
            If cbFilter.SelectedIndex <> -1 Then
                ' Cast the selected item to DataRowView to access the section_id
                Dim selectedRow As DataRowView = DirectCast(cbFilter.SelectedItem, DataRowView)
                Dim section_id As Integer = Convert.ToInt32(selectedRow("section_id"))

                loadDGV($"SELECT DISTINCT 
                        sr.studID, 
                        CONCAT(sr.firstname, ' ', sr.lastname) AS student_name, 
                        sr.gender, 
                        CONCAT(pr.firstname, ' ', pr.lastname) AS contact_person, 
                        pr.contactNo AS phone_number, 
                        pr.address, 
                        CONCAT(year_level, ' ', section_name) AS section, 
                        ss.assignment_date 
                    FROM studentrecords sr 
                    JOIN sections s ON s.section_id = sr.section_id 
                    JOIN student_sections ss ON ss.section_id = sr.section_id 
                    JOIN parentrecords pr ON pr.parentID = sr.parentID 
                    WHERE sr.isActive = 1 AND sr.section_id = {section_id} 
                    GROUP BY sr.studID, sr.firstname, sr.lastname, sr.gender, pr.firstname, pr.lastname, pr.contactNo, pr.address, s.year_level, s.section_name 
                    ORDER BY student_name, section", dgvStudentSection)
            End If
        End If
        dgvStudentSection.CurrentCell = Nothing
    End Sub

    Private Sub dgvStudentSection_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudentSection.CellClick
        Try
            dgvStudentSection.Tag = dgvStudentSection.Item(1, e.RowIndex).Value
        Catch ex As Exception

        End Try
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
    End Sub

    Private Sub btnRemoveStudents_Click(sender As Object, e As EventArgs) Handles btnRemoveStudents.Click
        ' Check if there are selected students
        Dim selectedRows As Integer = 0

        If Val(dgvStudentSection.Tag) = 0 Then
            MsgBox("No records were selected. Please select a record first.")
            Return
        End If
        ' Start database connection and loop through each row
        Try
            connectDB()

            Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to remove this record?", "Remove Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialogResult = DialogResult.Yes Then
                For Each row As DataGridViewRow In dgvStudentSection.Rows
                    Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("chkSelect").Value)

                    ' If the row is selected
                    If isChecked Then

                        Dim studId As Integer = Convert.ToInt32(row.Cells("studID").Value)

                        ' SQL query to delete from student_sections table
                        Dim cmd As New Odbc.OdbcCommand("DELETE FROM student_sections WHERE id=?", con)
                        cmd.Parameters.AddWithValue("id", studId) ' Parameter should match the placeholder

                        cmd.ExecuteNonQuery()

                        ' SQL query to update studentrecords table
                        Dim updateStudentSectionID As New Odbc.OdbcCommand("UPDATE studentrecords SET section_id=null WHERE studID=?", con)
                        updateStudentSectionID.Parameters.AddWithValue("studID", studId) ' Parameter should match the placeholder

                        updateStudentSectionID.ExecuteNonQuery()

                        selectedRows += 1
                    End If
                Next
            End If

            ' Confirm the addition of selected rows
            If selectedRows > 0 Then
                MessageBox.Show($"{selectedRows} students have been removed to the section successfully.", "Removed Successfully")
            Else
                MessageBox.Show("No students were selected.", "Error")
            End If
            DefaultSettings()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    Private Sub dgvStudentSection_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudentSection.CellContentClick
        ' Check if the clicked cell is in the checkbox column
        If e.ColumnIndex = dgvStudentSection.Columns("chkSelect").Index AndAlso e.RowIndex >= 0 Then
            Dim isChecked As Boolean = Convert.ToBoolean(dgvStudentSection.Rows(e.RowIndex).Cells("chkSelect").Value)
            dgvStudentSection.Rows(e.RowIndex).Cells("chkSelect").Value = Not isChecked ' Toggle the checkbox


            sectionListGradeID = dgvStudentSection.Rows(e.RowIndex).Cells("gradeID").Value
            UpdateChkShowOptionsText()
        End If
    End Sub

    Private Sub btnMoveStudents_Click(sender As Object, e As EventArgs) Handles btnMoveStudents.Click
        Dim selectedStudentIds As New List(Of Integer)

        ' Collect checked student IDs from DataGridView
        For Each row As DataGridViewRow In dgvStudentSection.Rows
            If Convert.ToBoolean(row.Cells("chkSelect").Value) Then
                selectedStudentIds.Add(Convert.ToInt32(row.Cells("studID").Value))
            End If
        Next

        ' Check if any students were selected
        If selectedStudentIds.Count = 0 Then
            MessageBox.Show("Please select at least one student to move.", "No Students Selected")
            Return
        End If


        ' Pass the selected student IDs to SectionLists form
        Dim sectionForm As New SectionLists(selectedStudentIds)
        sectionForm.ShowDialog()

        DefaultSettings()
    End Sub

    Private Sub btnRetainSections_Click(sender As Object, e As EventArgs) Handles btnRetainSections.Click

    End Sub
End Class