Imports System.Data.Odbc
Imports System.IO

Public Class AddSections
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If fieldChecker(panelContainer) Then
            Dim yearLevel As String = txtYearLevel.Text.Trim()
            Dim sectionName As String = txtSection.Text.Trim()

            ' Validate that year_level is numeric
            If Not IsNumeric(yearLevel) Then
                MessageBox.Show("Year Level must be a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Convert year_level to Integer
            Dim intYearLevel As Integer = Convert.ToInt32(yearLevel)

            ' Validate that section_name is unique for the given year_level
            If Not IsSectionNameUnique(intYearLevel, sectionName) Then
                MessageBox.Show("Section Name must be unique for the selected Year Level.", "Duplicate Section", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                ' Check if it's an update or new section
                If Val(txtID.Text) > 0 Then
                    Try
                        ' Update query
                        Dim query As String = "UPDATE sections SET year_level=?, section_name=? WHERE section_id=?"
                        connectDB() ' Call your connection function

                        Dim command As New OdbcCommand(query, con)
                        command.Parameters.AddWithValue("?", intYearLevel)   ' 1st parameter
                        command.Parameters.AddWithValue("?", sectionName)    ' 2nd parameter
                        command.Parameters.AddWithValue("?", Val(txtID.Text)) ' section_id
                        command.ExecuteNonQuery()

                        MessageBox.Show("Section updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        con.Close()
                        GC.Collect()
                    End Try
                Else
                    ' Insert query
                    Try
                        Dim query As String = "INSERT INTO sections (year_level, section_name) VALUES (?, ?)"
                        connectDB() ' Call your connection function

                        Dim command As New OdbcCommand(query, con)
                        command.Parameters.AddWithValue("?", intYearLevel)   ' 1st parameter
                        command.Parameters.AddWithValue("?", sectionName)    ' 2nd parameter
                        command.ExecuteNonQuery()

                        MessageBox.Show("Section added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        con.Close()
                        GC.Collect()
                    End Try
                End If

                ' Clear fields and close
                ClearFields(panelContainer)
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Unexpected error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Function to check if the section_name is unique for the given year_level
    Private Function IsSectionNameUnique(yearLevel As Integer, sectionName As String) As Boolean
        Try
            connectDB() ' Call your connection function

            ' Query to check for duplicate section name for the given year_level
            Dim query As String = "SELECT COUNT(*) FROM sections WHERE year_level = ? AND section_name = ? AND isActive=1"
            Dim command As New OdbcCommand(query, con)
            command.Parameters.AddWithValue("?", yearLevel)
            command.Parameters.AddWithValue("?", sectionName)

            ' Execute query and check if count > 0 (duplicate found)
            Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
            If result > 0 Then
                Return False ' Duplicate section name found
            Else
                Return True ' Section name is unique
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate section: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            con.Close()
            GC.Collect()
        End Try
    End Function

    ' Cancel button click handler
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearFields(panelContainer)
        Me.Close()
    End Sub

    ' Form closing event
    Private Sub AddSections_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            ' Check if the form "FormSections" is open
            Dim formSections As Form = Application.OpenForms("FormSections")
            If formSections IsNot Nothing Then
                CType(formSections, FormSections).DefaultSettings()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class
