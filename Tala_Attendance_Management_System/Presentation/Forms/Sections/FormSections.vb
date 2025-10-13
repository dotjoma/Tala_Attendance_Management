Public Class FormSections

    Public Sub DefaultSettings()
        dgvSection.Tag = 0
        dgvSection.RowTemplate.Height = 50
        dgvSection.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvSection.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSection.EnableHeadersVisualStyles = False

        ' Set column header font and alignment
        With dgvSection.ColumnHeadersDefaultCellStyle
            .Font = New Font("Segoe UI Semibold", 12)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        ' Set row font to Segoe UI for all rows
        dgvSection.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvSection.DefaultCellStyle.ForeColor = Color.Black

        dgvSection.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        dgvSection.AutoGenerateColumns = False

        ' Load sections into the ComboBoxes
        loadCBO("SELECT * FROM sections WHERE isActive = 1 GROUP BY year_level ORDER BY CAST(year_level AS SIGNED)", "section_id", "year_level", cbYearLevel)
    End Sub
    Private Sub FormSections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub cbYearLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYearLevel.SelectedIndexChanged
        If cbYearLevel.SelectedIndex <> -1 Then
            ' Assuming SelectedValue is a DataRowView, access the field value (e.g., "section_id")
            Dim selectedYearLevel As Integer = Convert.ToInt32(DirectCast(cbYearLevel.SelectedItem, DataRowView)("year_level"))

            ' Use the selectedYearLevel in your query
            loadDGV($"SELECT section_id, 
                     year_level, 
                     section_name 
              FROM sections 
              WHERE isActive = 1 AND year_level = {selectedYearLevel} 
              ORDER BY year_level", dgvSection)
        End If
    End Sub

    Private Sub dgvSection_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSection.CellClick
        Try
            dgvSection.Tag = dgvSection.Item(0, e.RowIndex).Value

            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 3 Then

                    Dim cmd As Odbc.OdbcCommand
                    Dim da As New Odbc.OdbcDataAdapter
                    Dim dt As New DataTable

                    Try
                        connectDB()

                        cmd = New Odbc.OdbcCommand("SELECT * FROM sections WHERE isActive=1 AND section_id=?", con)
                        cmd.Parameters.AddWithValue("?", Val(dgvSection.Tag))
                        da.SelectCommand = cmd
                        da.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            Dim addSections As New AddSections

                            addSections.txtYearLevel.Text = dt.Rows(0)("year_level").ToString()
                            addSections.txtSection.Text = dt.Rows(0)("section_name").ToString()
                            addSections.txtID.Text = dt.Rows(0)("section_id").ToString()

                            addSections.ShowDialog()
                        End If

                    Catch ex As Exception
                        MsgBox("There's an error editing the record: " & ex.Message.ToString)
                    Finally
                        con.Close()
                        GC.Collect()
                    End Try

                ElseIf e.ColumnIndex = 4 Then

                    If MessageBox.Show("Are you sure you want to delete this section?",
                                                                 "Confirm Delete",
                                                                 MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Warning) = DialogResult.Yes Then
                        Dim cmd As Odbc.OdbcCommand
                        Try
                            connectDB()

                            cmd = New Odbc.OdbcCommand("UPDATE sections SET isActive=0 WHERE section_id=?", con)
                            cmd.Parameters.AddWithValue("?", Val(dgvSection.Tag))
                            cmd.ExecuteNonQuery()

                            MessageBox.Show("You have been successfully deleted a section.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            DefaultSettings()
                        Catch ex As Exception
                            MsgBox("There's an error deleting the record: " & ex.Message.ToString)
                        Finally
                            con.Close()
                            GC.Collect()
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvSection_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvSection.DataBindingComplete
        dgvSection.CurrentCell = Nothing
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        AddSections.ShowDialog()
    End Sub
End Class