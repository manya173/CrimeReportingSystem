Imports System.Data.OleDb

Public Class ChangePassword
    Dim read As String
    Dim datafile As String
    Dim dr As OleDbDataReader
    Dim cmd As OleDbCommand
    Dim dbcon As New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_changepass.Click
        dbcon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hp\source\repos\WindowsApp2\dbCrime1.mdb"
        dbcon.Open()
        Dim sqlUpdate As String
        Dim sqlUpdatePass As DialogResult
        sqlUpdate = "UPDATE tb_Login SET [Password] = '" & txtNewPass.Text & "' WHERE [Username] = '" & txtUser.Text & "'"
        cmd = New OleDbCommand(sqlUpdate, dbcon)
        Try
            sqlUpdatePass = MessageBox.Show("Are you sure to save this changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If sqlUpdatePass = vbYes Then
                cmd.ExecuteNonQuery()
                MsgBox("Changes are now saved", MsgBoxStyle.Information, "New password has been set.")

                Me.Hide()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Could not perform this task because " & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
        cmd = Nothing
        dbcon.Close()
    End Sub

    Private Sub ChangePassword_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If dbcon.State = ConnectionState.Open Then
            MessageBox.Show("open")
        Else
            MessageBox.Show("closed")
        End If
        dbcon.Close()
        MsgBox("closed")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtNewPass_TextChanged(sender As Object, e As EventArgs) Handles txtNewPass.TextChanged
        txtNewPass.PasswordChar = ""
    End Sub

    Private Sub txtConfirmPass_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPass.TextChanged
        txtConfirmPass.PasswordChar = ""
    End Sub
End Class
