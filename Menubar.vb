Public Class Menubar
    Private Sub VictimRegistrationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VictimRegistrationToolStripMenuItem.Click
        Victimregis.Show()
    End Sub

    Private Sub ComplainDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComplainDetailsToolStripMenuItem.Click
        Complain.Show()
    End Sub

    Private Sub StatusReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusReportToolStripMenuItem.Click
        ReportStatus.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        ChangePassword.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Logout.Show()
    End Sub
End Class