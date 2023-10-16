<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menubar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menubar))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.VictimRegistrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComplainDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VictimRegistrationToolStripMenuItem, Me.ComplainDetailsToolStripMenuItem, Me.StatusReportToolStripMenuItem, Me.ChangePasswordToolStripMenuItem, Me.LogOutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(710, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'VictimRegistrationToolStripMenuItem
        '
        Me.VictimRegistrationToolStripMenuItem.Name = "VictimRegistrationToolStripMenuItem"
        Me.VictimRegistrationToolStripMenuItem.Size = New System.Drawing.Size(147, 24)
        Me.VictimRegistrationToolStripMenuItem.Text = "Victim Registration"
        '
        'ComplainDetailsToolStripMenuItem
        '
        Me.ComplainDetailsToolStripMenuItem.Name = "ComplainDetailsToolStripMenuItem"
        Me.ComplainDetailsToolStripMenuItem.Size = New System.Drawing.Size(135, 24)
        Me.ComplainDetailsToolStripMenuItem.Text = "Complain Details"
        '
        'StatusReportToolStripMenuItem
        '
        Me.StatusReportToolStripMenuItem.Name = "StatusReportToolStripMenuItem"
        Me.StatusReportToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.StatusReportToolStripMenuItem.Text = "Status Report"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(136, 24)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(251, 102)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 197)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Menubar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 450)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Menubar"
        Me.Text = "Menubar"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents VictimRegistrationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComplainDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
