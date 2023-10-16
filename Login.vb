Imports System.Data.OleDb

Public Class Login
    Dim rdr As OleDbDataReader
    Dim dtable As New DataTable
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dt As New DataTable

    Private Sub Btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        If Len(Trim(txtUserName.Text)) = 0 Then
            MessageBox.Show("Please Enter User Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUserName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPassword.Text)) = 0 Then
            MessageBox.Show("please Enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
            Exit Sub
        End If
        Try
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb")
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand("SELECT UserName,Password FROM tb_Login WHERE UserName=@UserName AND Password=@UPassword", con)
            Dim Uname As New OleDbParameter("@UserName", OleDbType.LongVarWChar)
            Dim Upassword As New OleDbParameter("@Password", OleDbType.LongVarWChar)
            Uname.Value = txtUserName.Text
            Upassword.Value = txtPassword.Text
            cmd.Parameters.Add(Uname)
            cmd.Parameters.Add(Upassword)
            cmd.Connection.Open()
            Dim rdr As OleDbDataReader = cmd.ExecuteReader
            Dim login As Object = 0
            If rdr.HasRows Then
                rdr.Read()
                login = rdr(login)
            End If
            If login = Nothing Then
                MsgBox("Login Is Failed....Try again!!", MsgBoxStyle.Critical, "Login Denied")
                txtUserName.Clear()
                txtPassword.Clear()
                txtUserName.Focus()
            Else
                txtPassword.Clear()
                Menubar.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        txtUserName.Text = ""
        txtPassword.Text = ""
    End Sub

End Class