Imports System.IO

Public Class FormFaculty
    Public Sub DefaultSettings()
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
            CONCAT(ti.firstname, ' ', ti.middlename, ' ', ti.lastname) AS teacher_name, 
            email, ti.gender AS gender, ti.birthdate AS birthdate, 
            ti.contactNo AS contactNo, 
            CONCAT(ti.homeadd, ' ', rb.brgyDesc, '. ', rc.citymunDesc) AS teacher_address, 
            ti.emergencyContact AS emergencyContact 
            FROM teacherinformation ti JOIN refregion rg ON ti.regionID = rg.id 
            JOIN refprovince rp ON ti.provinceID = rp.id 
            JOIN refcitymun rc ON ti.cityID = rc.id 
            JOIN refbrgy rb ON ti.brgyID = rb.id 
            WHERE ti.isActive = 1", dgvTeachers)
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddFaculty.ShowDialog()
    End Sub

    Private Sub FormFaculty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultSettings()
    End Sub

    Private Sub btnDeleteRecord_Click(sender As Object, e As EventArgs) Handles btnDeleteRecord.Click
        Dim cmd As Odbc.OdbcCommand
        Try
            connectDB()
            If dgvTeachers.Tag > 0 Then
                If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    cmd = New Odbc.OdbcCommand("UPDATE teacherinformation SET isActive=0 WHERE teacherID=?", con)
                    cmd.Parameters.AddWithValue("@", dgvTeachers.Tag)
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
            cmd = New Odbc.OdbcCommand("SELECT teacherID, profileImg, employeeID,tagID,firstname,middlename,lastname,extName, email, gender,birthdate,homeadd,brgyID, cityID, provinceID, regionID,contactNo, emergencyContact, relationship FROM teacherinformation WHERE teacherID=?", con)
            cmd.Parameters.AddWithValue("@", id)
            da.SelectCommand = cmd
            da.Fill(dt)

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
            AddFaculty.cbBrgy.Text = dt.Rows(0)("brgyID").ToString()
            AddFaculty.cbCity.Text = dt.Rows(0)("cityID").ToString()
            AddFaculty.cbProvince.Text = dt.Rows(0)("provinceID").ToString()
            AddFaculty.cbRegion.Text = dt.Rows(0)("regionID").ToString()
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

                End Try
            End If
            AddFaculty.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            GC.Collect()
            con.Close()
        End Try
    End Sub

    Private Sub btnEditRecord_Click(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        If dgvTeachers.Tag > 0 Then
            If MessageBox.Show("Are you sure you want to edit this record?", "Edit Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                EditRecord(Val(dgvTeachers.Tag))
            End If
        Else
            MessageBox.Show("Please select a record you want to edit", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 0 Then
            loadDGV("SELECT ti.teacherID AS teacherID, ti.employeeID AS employeeID, CONCAT(ti.firstname, ' ', ti.middlename, ' ', ti.lastname) AS teacher_name, email, ti.gender AS gender, ti.birthdate AS birthdate, ti.contactNo AS contactNo, CONCAT(ti.homeadd, ' ', rb.brgyDesc, '. ', rc.citymunDesc) AS teacher_address, ti.emergencyContact AS emergencyContact FROM teacherinformation ti JOIN refregion rg ON ti.regionID = rg.id JOIN refprovince rp ON ti.provinceID = rp.id JOIN refcitymun rc ON ti.cityID = rc.id JOIN refbrgy rb ON ti.brgyID = rb.id WHERE ti.isActive=1", dgvTeachers, "ti.lastname", "ti.firstname", "ti.employeeID", txtSearch.Text.Trim)
        Else
            loadDGV("SELECT ti.teacherID AS teacherID, ti.employeeID AS employeeID, CONCAT(ti.firstname, ' ', ti.middlename, ' ', ti.lastname) AS teacher_name, email, ti.gender AS gender, ti.birthdate AS birthdate, ti.contactNo AS contactNo, CONCAT(ti.homeadd, ' ', rb.brgyDesc, '. ', rc.citymunDesc) AS teacher_address, ti.emergencyContact AS emergencyContact FROM teacherinformation ti JOIN refregion rg ON ti.regionID = rg.id JOIN refprovince rp ON ti.provinceID = rp.id JOIN refcitymun rc ON ti.cityID = rc.id JOIN refbrgy rb ON ti.brgyID = rb.id WHERE ti.isActive = 1", dgvTeachers)
        End If
    End Sub

    Private Sub dgvTeachers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeachers.CellClick
        Try
            dgvTeachers.Tag = dgvTeachers.Item(0, e.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvTeachers_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTeachers.DataBindingComplete
        dgvTeachers.CurrentCell = Nothing
    End Sub
End Class