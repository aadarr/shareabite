Public Class Dashboard
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim sengo As New SearchNGO()
        sengo.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim ngodet As New NGODetails()
        ngodet.Show()
    End Sub

    Private Sub DonateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateToolStripMenuItem.Click
        Dim sengo As New SearchNGO()
        sengo.Show()
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsernameToolStripMenuItem.Text = Login.uname
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ViewDonationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDonationsToolStripMenuItem.Click
        Dim view As New Form1()
        view.Show()
        Me.Hide()
    End Sub
End Class