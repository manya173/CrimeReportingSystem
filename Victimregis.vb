Imports System.Data.OleDb

Public Class Victimregis
    Dim rdr As OleDbDataReader
    Dim dtable As New DataTable
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable

    Private Sub Victimregis_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Reset()
    End Sub

    Private Sub AutoIdGeneration()
        Dim Num As Integer = 0
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
        con.Open()
        Dim OleDb As String = "SELECT Max(Id+1) FROM tb_Victim"
        cmd = New OleDbCommand(OleDb)
        cmd.Connection = con

        If Convert.IsDBNull(cmd.ExecuteScalar()) Then
            Num = 1
            txtId.Text = Convert.ToString(Num)
            txtVictimId.Text = Convert.ToString("Victim-" & Num)
        Else
            Num = System.Convert.ToInt32((cmd.ExecuteScalar()))
            txtId.Text = Convert.ToString(Num)
            txtVictimId.Text = Convert.ToString("Victim-" & Num)
        End If

        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Public Sub Getdata()
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            cmd = New OleDbCommand("SELECT VictimId, Name, Gender, MobileNumber, EmailId, Dob, Address from tb_Victim order by VictimId", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub Reset()
        AutoIdGeneration()
        Getdata()
        txtAddress.Text = ""
        txtEmailId.Text = ""
        txtMobileNo.Text = ""
        txtName.Text = ""
        cmbGender.Text = ""
        Btn_Add.Enabled = True
        Btn_Dlt.Enabled = False
        Btn_Update.Enabled = False
        dtpDOB.Text = Today
    End Sub

    Private Sub Victimregis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reset()
    End Sub

    Private Sub Btn_Reset_Click(sender As Object, e As EventArgs) Handles Btn_Reset.Click
        Reset()
    End Sub

    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Try
            If txtName.Text = "" Then
                MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtName.Focus()
                Return
            End If
            If cmbGender.Text = "" Then
                MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGender.Focus()
                Return
            End If
            If txtMobileNo.Text = "" Then
                MessageBox.Show("Please enter mobile no", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMobileNo.Focus()
                Return
            End If
            If txtEmailId.Text = "" Then
                MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmailId.Focus()
                Return
            End If
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            Dim ct2 As String = "select MobileNumber from tb_Victim where MobileNumber=@d1"
            cmd = New OleDbCommand(ct2)
            cmd.Parameters.AddWithValue("@d1", txtMobileNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Mobile Number Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            Dim cb As String = "insert into tb_Victim (VictimId,Name,Gender,MobileNumber,EmailId,Dob,Address) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
            cmd = New OleDbCommand(cb, con)
            cmd.Parameters.AddWithValue("@d1", txtVictimId.Text)
            cmd.Parameters.AddWithValue("@d2", txtName.Text)
            cmd.Parameters.AddWithValue("@d3", cmbGender.Text)
            cmd.Parameters.AddWithValue("@d4", txtMobileNo.Text)
            cmd.Parameters.AddWithValue("@d5", txtEmailId.Text)
            cmd.Parameters.AddWithValue("@d6", dtpDOB.Text)
            cmd.Parameters.AddWithValue("@d7", txtAddress.Text)
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Successfully Saved", "Victim Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Btn_Dlt_Click(sender As Object, e As EventArgs) Handles Btn_Dlt.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            Dim cq As String = "delete from tb_Victim where VictimId=@d1"
            cmd = New OleDbCommand(cq)
            cmd.Parameters.AddWithValue("@d1", txtVictimId.Text)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Try
            If txtName.Text = "" Then
                MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtName.Focus()
                Return
            End If
            If cmbGender.Text = "" Then
                MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGender.Focus()
                Return
            End If
            If txtMobileNo.Text = "" Then
                MessageBox.Show("Please enter mobile no", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMobileNo.Focus()
                Return
            End If
            If txtEmailId.Text = "" Then
                MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmailId.Focus()
                Return
            End If
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            Dim cb As String = "update tb_Victim set Name=@d1, Gender=@d2 , MobileNumber=@d3, EmailId=@d4 ,Dob=@d5 ,Address=@d6 where VictimId=@d7"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbGender.Text)
            cmd.Parameters.AddWithValue("@d3", txtMobileNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtEmailId.Text)
            cmd.Parameters.AddWithValue("@d5", dtpDOB.Text)
            cmd.Parameters.AddWithValue("@d6", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d7", txtVictimId.Text)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully Updated", "Victim Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtVictimId.Text = dr.Cells(0).Value.ToString()
                txtName.Text = dr.Cells(1).Value.ToString()
                cmbGender.Text = dr.Cells(2).Value.ToString()
                txtMobileNo.Text = dr.Cells(3).Value.ToString()
                txtEmailId.Text = dr.Cells(4).Value.ToString()
                dtpDOB.Text = dr.Cells(5).Value.ToString()
                txtAddress.Text = dr.Cells(6).Value.ToString()
                Btn_Update.Enabled = True
                Btn_Dlt.Enabled = True
                Btn_Add.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub
End Class