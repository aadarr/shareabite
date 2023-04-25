Imports System.Data.SqlClient
Imports System.Security.AccessControl

Public Class DonationDetails
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged

    End Sub

    Private Sub DonationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Login.acctype = "Restaurant" Then
            Dim xConn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Dim xComm1 As New SqlCommand()
            xConn1.Open()
            xComm1.Connection = xConn1
            xComm1.CommandText = "SELECT id FROM Restaurants WHERE username=@username"
            xComm1.Parameters.AddWithValue("@username", Login.uname)
            Dim dr2 As SqlDataReader
            dr2 = xComm1.ExecuteReader
            If dr2.HasRows Then
                dr2.Read()
                accid = dr2("id")
            End If
            dr2.Close()
        ElseIf login.acctype = "Individual Donor" Then
            Dim xConn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Dim xComm1 As New SqlCommand()
            xConn1.Open()
            xComm1.Connection = xConn1
            xComm1.CommandText = "SELECT id FROM individual WHERE username=@username"
            xComm1.Parameters.AddWithValue("@username", Login.uname)
            Dim dr2 As SqlDataReader
            dr2 = xComm1.ExecuteReader
            If dr2.HasRows Then
                dr2.Read()
                accid = dr2("id")
            End If
            dr2.Close()
        ElseIf login.acctype = "NGO" Then
            Dim xConn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Dim xComm1 As New SqlCommand()
            Dim xComm2 As New SqlCommand()
            Dim xComm3 As New SqlCommand()
            Dim temp As Integer
            xConn1.Open()
            xComm1.Connection = xConn1
            xComm1.CommandText = "SELECT id, people, contact, type, city FROM NGOs WHERE username=@username"
            xComm1.Parameters.AddWithValue("@username", Login.uname)
            Dim dr2 As SqlDataReader
            dr2 = xComm1.ExecuteReader
            If dr2.HasRows Then
                dr2.Read()
                TextBox1.Text = dr2("id")
                TextBox2.Text = dr2("people")
                TextBox3.Text = dr2("type")
                TextBox4.Text = dr2("contact")
                RichTextBox1.Text = dr2("city")
            End If
            dr2.Close()
            xConn1.Close()
            xComm2.Connection = xConn1
            xConn1.Open()
            xComm1.CommandText = "SELECT did FROM donations WHERE date = (SELECT MAX(date) FROM donations)"
            Dim dr3 As SqlDataReader
            dr3 = xComm1.ExecuteReader
            If dr3.HasRows Then
                dr3.Read()
                TextBox8.Text = dr3("did")
                temp = dr3("did")
            End If
            dr3.Close()
            xConn1.Close()
            xComm3.Connection = xConn1
            xComm3.CommandText = "SELECT  FROM  WHERE date = (SELECT MAX(date) FROM donations)"



            xConn1.Close()



        End If
    End Sub
End Class