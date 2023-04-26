Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Dashboard
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim sengo As New SearchNGO()
        sengo.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim ngodet As New NGODetails()
        ngodet.Show()
        Me.Hide()
    End Sub

    Private Sub DonateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateToolStripMenuItem.Click
        Dim sengo As New SearchNGO()
        sengo.Show()
        Me.Hide()
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsernameToolStripMenuItem.Text = Login.uname
        If Login.acctype = "NGO" Then
            DonateToolStripMenuItem.Visible = False
            RedeemPointsToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ViewDonationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDonationsToolStripMenuItem.Click
        Dim view As New Form1()
        view.Show()
        Me.Hide()
    End Sub

    Private Sub ViewDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailsToolStripMenuItem.Click

    End Sub

    Private Sub ProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProfileToolStripMenuItem.Click

        Dim view As New ProfileDetails()
        view.Show()
        Me.Hide()
    End Sub

    Private Sub OtherDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtherDetailsToolStripMenuItem.Click
        If Login.acctype = "Restaurant" Then
            Dim view As New RestaurantDetails()
            view.Show()
            Me.Hide()

        ElseIf Login.acctype = "Individual Donor" Then
            Dim view As New IndividualDetails()
            view.Show()
            Me.Hide()
        ElseIf Login.acctype = "NGO" Then
            Dim view As New NGODetails()
            view.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim view As New Login()
        view.Show()
        Login.TextBox1.Text = ""
        Login.TextBox2.Text = ""
        Me.Hide()

    End Sub

    Private Sub ViewProfileDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewProfileDetailsToolStripMenuItem.Click
        Dim view As New ProfileDetails()
        view.Show()
        Me.Hide()
    End Sub
End Class