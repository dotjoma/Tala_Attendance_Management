Imports System.Collections.Specialized.BitVector32

Public Class SectionLists
    Private selectedStudentIds As List(Of Integer)

    ' Constructor to initialize with selected student IDs
    Public Sub New(studentIds As List(Of Integer))
        InitializeComponent()
        selectedStudentIds = studentIds
    End Sub
    Private Sub SectionLists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load year levels into ComboBox
        loadCBO("SELECT * FROM gradelevel WHERE isActive = 1", "gradeID", "gradelevel", cbYearLevel)

        If sectionListGradeID > 0 Then
            cbYearLevel.SelectedValue = sectionListGradeID
        End If
    End Sub

    Private Sub ComboBoxDefault()
        ' Check if a year level is selected
        If cbYearLevel.SelectedIndex <> -1 Then
            ' Get the selected year level by casting SelectedValue to DataRowView and retrieving the "gradeID" field
            Dim selectedYearLevel As String = DirectCast(cbYearLevel.SelectedItem, DataRowView)("gradeID").ToString()

            ' Call the loadCBO method to populate the sections ComboBox based on the selected year level
            loadCBO("SELECT section_id, CONCAT(year_level, ' ', section_name) AS section 
                 FROM sections 
                 WHERE isActive = 1 AND year_level = " & selectedYearLevel, "section_id", "section", cbSections)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Ensure both year level and section are selected
            If cbYearLevel.SelectedIndex = -1 Or cbSections.SelectedIndex = -1 Then
                MessageBox.Show("Please select both a year level and a section.", "Selection Required")
                Return
            End If

            ' Get the selected year_level (gradeID) and section_id
            Dim selectedYearLevel As Integer = Convert.ToInt32(cbYearLevel.SelectedValue)
            Dim selectedSectionId As Integer = Convert.ToInt32(cbSections.SelectedValue)

            ' Connect to the database
            connectDB()

            ' Update each selected student's section_id and gradeID (year_level)
            For Each studentId In selectedStudentIds
                Dim cmd As New Odbc.OdbcCommand("UPDATE studentrecords SET section_id = ?, gradeID = ? WHERE studID = ?", con)
                cmd.Parameters.AddWithValue("@section_id", selectedSectionId)
                cmd.Parameters.AddWithValue("@gradeID", selectedYearLevel)
                cmd.Parameters.AddWithValue("@studID", studentId)
                cmd.ExecuteNonQuery()
            Next

            ' Update each selected student's section_id and gradeID (year_level)
            For Each studentId In selectedStudentIds
                Dim cmd As New Odbc.OdbcCommand("UPDATE student_sections SET section_id = ? WHERE studID = ?", con)
                cmd.Parameters.AddWithValue("@section_id", selectedSectionId)
                cmd.Parameters.AddWithValue("@studID", studentId)
                cmd.ExecuteNonQuery()
            Next

            MessageBox.Show($"{selectedStudentIds.Count} students have been moved to the selected section and year level successfully.", "Update Successful")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cbYearLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYearLevel.SelectedIndexChanged
        Try
            ComboBoxDefault()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, "Year Level")
        End Try
    End Sub

    Private Sub cbSections_Click(sender As Object, e As EventArgs) Handles cbSections.Click

        'Dim selectedYearLevel As String = cbYearLevel.SelectedValue.ToString()

        'loadCBO("SELECT section_id, CONCAT(year_level, ' ',section_name) AS section 
        '                     FROM sections 
        '                     WHERE isActive=1 AND section_id=" & selectedYearLevel, "section_id", "section", cbSections)
    End Sub
End Class
