Imports System.Data.OleDb

Public Class ReportStatus
    Dim rdr As OleDbDataReader
    Dim dtable As New DataTable
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable

    Private Sub ReportStatus_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Reset()
    End Sub

    Private Sub AutoIdGeneration()
        Dim Num As Integer = 0
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
        con.Open()
        Dim OleDb As String = "SELECT Max(Id+1) FROM tb_Status"
        cmd = New OleDbCommand(OleDb)
        cmd.Connection = con
        If Convert.IsDBNull(cmd.ExecuteScalar()) Then
            Num = 1
            txtId.Text = Convert.ToString(Num)
            txtStatusId.Text = Convert.ToString("STATUS-" & Num)
        Else
            Num = System.Convert.ToInt32((cmd.ExecuteScalar()))
            txtId.Text = Convert.ToString(Num)
            txtStatusId.Text = Convert.ToString("STATUS-" & Num)
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub

    Public Sub Getdata()
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            cmd = New OleDbCommand("SELECT StatusId, ComplainId, Complain, VictimId, Name, Address, InvestigationOfficerId, OfficerName, RStatus from tb_Status order by StatusId", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Reset()
        AutoIdGeneration()
        GetdataReport()
        Getdata()
        txtAddress.Text = ""
        txtComplain.Text = ""
        txtInvestigationOfficerId.Text = ""
        txtName.Text = ""
        txtOfficeName.Text = ""
        txtStatus.Text = ""
        txtVictimId.Text = ""
        txtComplainId.Text = ""
        Btn_Dlt.Enabled = False
        Btn_Insert.Enabled = True
        btnUpdate.Enabled = False
    End Sub


    Private Sub GetdataReport()
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            cmd = New OleDbCommand("SELECT ComplainId, VictimId, Name, Gender , Mobile, DOB, Address,Complain,RegistrationDate,CrimeDate,InvestigationOffice,OfficeName from tb_Complain order by ComplainId", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Reset()
    End Sub

    Private Sub ReportStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reset()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtComplainId.Text = dr.Cells(0).Value.ToString()
                txtVictimId.Text = dr.Cells(1).Value.ToString()
                txtName.Text = dr.Cells(2).Value.ToString()
                txtAddress.Text = dr.Cells(6).Value.ToString()
                txtComplain.Text = dr.Cells(7).Value.ToString
                txtInvestigationOfficerId.Text = dr.Cells(10).Value.ToString()
                txtOfficeName.Text = dr.Cells(11).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Insert_Click(sender As Object, e As EventArgs) Handles Btn_Insert.Click
        Try
            If txtName.Text = "" Then
                MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtName.Focus()
                Return
            End If
            If txtAddress.Text = "" Then
                MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddress.Focus()
                Return
            End If
            If txtComplain.Text = "" Then
                MessageBox.Show("Please enter complain no", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtComplain.Focus()
                Return
            End If
            If txtInvestigationOfficerId.Text = "" Then
                MessageBox.Show("Please enter investigation officer id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtInvestigationOfficerId.Focus()
                Return
            End If
            If txtOfficeName.Text = "" Then
                MessageBox.Show("Please enter officer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOfficeName.Focus()
                Return
            End If
            If txtStatus.Text = "" Then
                MessageBox.Show("Please enter status", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtStatus.Focus()
                Return
            End If
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            Dim cb As String = "insert into tb_Status(StatusId,ComplainId,Complain,VictimId,Name,Address,InvestigationOfficerId,OfficerName,RStatus) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
            cmd = New OleDbCommand(cb, con)
            cmd.Parameters.AddWithValue("@d1", txtStatusId.Text)
            cmd.Parameters.AddWithValue("@d2", txtComplainId.Text)
            cmd.Parameters.AddWithValue("@d3", txtComplain.Text)
            cmd.Parameters.AddWithValue("@d4", txtVictimId.Text)
            cmd.Parameters.AddWithValue("@d5", txtName.Text)
            cmd.Parameters.AddWithValue("@d6", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d7", txtInvestigationOfficerId.Text)
            cmd.Parameters.AddWithValue("@d8", txtOfficeName.Text)
            cmd.Parameters.AddWithValue("@d9", txtStatus.Text)
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Successfully Saved", "Report Status Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim cq As String = "delete from tb_Status where StatusId=@d1"
            cmd = New OleDbCommand(cq)
            cmd.Parameters.AddWithValue("@d1", txtStatusId.Text)
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If txtName.Text = "" Then
            MessageBox.Show("Please enter name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If
        If txtAddress.Text = "" Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return
        End If
        If txtComplain.Text = "" Then
            MessageBox.Show("Please enter complain no", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComplain.Focus()
            Return
        End If
        If txtInvestigationOfficerId.Text = "" Then
            MessageBox.Show("Please enter investigation officer id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvestigationOfficerId.Focus()
            Return
        End If
        If txtOfficeName.Text = "" Then
            MessageBox.Show("Please enter officer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOfficeName.Focus()
            Return
        End If
        If txtStatus.Text = "" Then
            MessageBox.Show("Please enter status", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStatus.Focus()
            Return
        End If
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            con.Open()
            Dim cb As String = "update tb_Status set ComplainId=@d2, Complain=@d3 , VictimId=@d4, Name=@d5 ,Address=@d6 , InvestigationOfficerId=@d7, OfficerName=@d8, RStatus=@d9  where StatusId=@d1"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d2", txtComplainId.Text)
            cmd.Parameters.AddWithValue("@d3", txtComplain.Text)
            cmd.Parameters.AddWithValue("@d4", txtVictimId.Text)
            cmd.Parameters.AddWithValue("@d5", txtName.Text)
            cmd.Parameters.AddWithValue("@d6", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d7", txtInvestigationOfficerId.Text)
            cmd.Parameters.AddWithValue("@d8", txtOfficeName.Text)
            cmd.Parameters.AddWithValue("@d9", txtStatus.Text)
            cmd.Parameters.AddWithValue("@d1", txtStatusId.Text)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully Updated", "Report Status Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseClick
        Try
            If DataGridView2.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
                txtStatusId.Text = dr.Cells(0).Value.ToString()
                txtComplainId.Text = dr.Cells(1).Value.ToString()
                txtComplain.Text = dr.Cells(2).Value.ToString()
                txtVictimId.Text = dr.Cells(3).Value.ToString()
                txtName.Text = dr.Cells(4).Value.ToString()
                txtAddress.Text = dr.Cells(5).Value.ToString()
                txtInvestigationOfficerId.Text = dr.Cells(6).Value.ToString()
                txtOfficeName.Text = dr.Cells(7).Value.ToString()
                txtStatus.Text = dr.Cells(8).Value.ToString()
                Btn_Insert.Enabled = False
                Btn_Dlt.Enabled = True
                btnUpdate.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged

    End Sub
End Class