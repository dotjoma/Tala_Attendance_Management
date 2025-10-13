Imports System.IO

Public Class FormStudents
    Public Sub DefaultSettings()
        dgvStudents.Tag = 0
        dgvStudents.CurrentCell = Nothing
        loadDGV("SELECT studID, lrn, CONCAT(sr.firstname, ' ', sr.middlename, ' ', sr.lastname) AS student_name, sr.gender, sr.birthdate, CONCAT(pr.firstname, ' ', pr.middlename, ' ', pr.lastname) AS parent_name, sr.contactNo, CONCAT(homeadd,' ', brgyDesc, '. ', citymunDesc) AS sAddress FROM studentrecords sr JOIN parentrecords pr ON sr.parentID=pr.parentID JOIN refregion rg ON sr.regionID=rg.id JOIN refprovince rp ON sr.provinceID=rp.id JOIN refcitymun rc ON sr.cityID=rc.id JOIN refbrgy rb ON sr.brgyID=rb.id WHERE sr.isActive=1 ORDER BY sr.lastname ", dgvStudents)

        dgvStudents.RowTemplate.Height = 35
        dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgvStudents.AutoGenerateColumns = False
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddStudents.ShowDialog()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            loadDGV("SELECT studID, lrn, CONCAT(sr.firstname, ' ', sr.middlename, ' ', sr.lastname) AS student_name, sr.gender, sr.birthdate, CONCAT(pr.firstname, ' ', pr.middlename, ' ', pr.lastname) AS parent_name, sr.contactNo, CONCAT(homeadd,' ', brgyDesc, '. ', citymunDesc) AS sAddress FROM studentrecords sr JOIN parentrecords pr ON sr.parentID=pr.parentID JOIN refregion rg ON sr.regionID=rg.id JOIN refprovince rp ON sr.provinceID=rp.id JOIN refcitymun rc ON sr.cityID=rc.id JOIN refbrgy rb ON sr.brgyID=rb.id WHERE sr.isActive=1 ", dgvStudents, "sr.lastname", "sr.firstname", "lrn", txtSearch.Text)
        Else
            loadDGV("SELECT studID, lrn, CONCAT(sr.firstname, ' ', sr.middlename, ' ', sr.lastname) AS student_name, sr.gender, sr.birthdate, CONCAT(pr.firstname, ' ', pr.middlename, ' ', pr.lastname) AS parent_name, sr.contactNo, CONCAT(homeadd,' ', brgyDesc, '. ', citymunDesc) AS sAddress FROM studentrecords sr JOIN parentrecords pr ON sr.parentID=pr.parentID JOIN refregion rg ON sr.regionID=rg.id JOIN refprovince rp ON sr.provinceID=rp.id JOIN refcitymun rc ON sr.cityID=rc.id JOIN refbrgy rb ON sr.brgyID=rb.id WHERE sr.isActive=1 ORDER BY sr.lastname ", dgvStudents)
        End If
    End Sub

    Private Sub FormStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub dgvStudents_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvStudents.DataBindingComplete
        dgvStudents.CurrentCell = Nothing
    End Sub

    Private Sub btnDeleteRecord_Click(sender As Object, e As EventArgs) Handles btnDeleteRecord.Click
        Dim cmd As Odbc.OdbcCommand
        Try
            connectDB()
            If dgvStudents.Tag > 0 Then
                If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    cmd = New Odbc.OdbcCommand("UPDATE studentrecords SET isActive=0 WHERE studID=?", con)
                    cmd.Parameters.AddWithValue("@", dgvStudents.Tag)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Record has been deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please select a record you want to delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
            DefaultSettings()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    Private Sub EditRecord(ByVal id As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Try
            connectDB()
            cmd = New Odbc.OdbcCommand("SELECT profilepicture, sr.studID, tagID, sr.lrn, sr.firstname AS sFirstName, gradeID, sr.middlename AS sMiddleName, 
                                        sr.lastname AS sLastName, sr.gender AS sGender, sr.birthdate AS sBirthdate, pr.firstname AS pFirstName, pr.middlename AS pMiddleName, 
                                        pr.lastname AS pLastName, sr.contactNo AS sContactNo, extName, pr.gender AS pGender, pr.relationship, pr.birthdate AS pBirthdate, 
                                        regionID, provinceID, cityID, brgyID, homeadd 
                                        FROM studentrecords sr 
                                        JOIN parentrecords pr ON sr.parentID=pr.parentID 
                                        JOIN refregion rg ON sr.regionID=rg.id 
                                        JOIN refprovince rp ON sr.provinceID=rp.id 
                                        JOIN refcitymun rc ON sr.cityID=rc.id 
                                        JOIN refbrgy rb ON sr.brgyID=rb.id 
                                        WHERE studID=?", con)
            cmd.Parameters.AddWithValue("@", id)
            da.SelectCommand = cmd
            da.Fill(dt)

            Dim myreader As Odbc.OdbcDataReader = cmd.ExecuteReader
            If myreader.Read Then
                AddStudents.txtID.Text = dt.Rows(0)("studID").ToString()
                AddStudents.txtFirstName.Text = dt.Rows(0)("sFirstName").ToString()
                AddStudents.txtMiddleName.Text = dt.Rows(0)("sMiddleName").ToString()
                AddStudents.txtLastName.Text = dt.Rows(0)("sLastName").ToString()
                AddStudents.txtLrn.Text = dt.Rows(0)("lrn").ToString()
                AddStudents.cbGradeLevel.SelectedValue = dt.Rows(0)("gradeID").ToString()
                AddStudents.txtTagID.Text = dt.Rows(0)("tagID").ToString()
                AddStudents.txtHome.Text = dt.Rows(0)("homeadd").ToString()
                AddStudents.cbGender.Text = dt.Rows(0)("sGender").ToString()
                AddStudents.txtContactNo.Text = dt.Rows(0)("sContactNo").ToString()
                AddStudents.txtExtName.Text = dt.Rows(0)("extName").ToString()
                AddStudents.dtpBirthdate.Text = dt.Rows(0)("sBirthdate").ToString()
                AddStudents.cbRegion.Text = dt.Rows(0)("regionID").ToString()
                AddStudents.cbProvince.Text = dt.Rows(0)("provinceID").ToString()
                AddStudents.cbCity.Text = dt.Rows(0)("cityID").ToString()
                AddStudents.cbBrgy.Text = dt.Rows(0)("brgyID").ToString()
                AddStudents.txtPFirstName.Text = dt.Rows(0)("pFirstName").ToString()
                AddStudents.txtPMiddleName.Text = dt.Rows(0)("pMiddleName").ToString()
                AddStudents.txtPLastName.Text = dt.Rows(0)("pLastName").ToString()
                AddStudents.cbPGender.Text = dt.Rows(0)("pGender").ToString()
                AddStudents.cbRelationship.Text = dt.Rows(0)("relationship").ToString()

                Try
                    Dim profileImg As Byte()
                    profileImg = myreader("profilepicture")
                    Dim ms As New MemoryStream(profileImg)
                    AddStudents.pbProfile.Image = Image.FromStream(ms)
                Catch ex As Exception

                End Try
            End If


            AddStudents.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    Private Sub btnEditRecord_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        If dgvStudents.Tag > 0 Then
            If MessageBox.Show("Are you sure you want to edit this record?", "Edit Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                EditRecord(Val(dgvStudents.Tag))
            End If
        Else
            MessageBox.Show("Please select a record you want to edit", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgvStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellClick
        Try
            dgvStudents.Tag = dgvStudents.Item(0, e.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub
End Class