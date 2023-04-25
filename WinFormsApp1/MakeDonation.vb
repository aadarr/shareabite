Imports System.Data.SqlClient
Imports System.Net
Imports System.Security.Cryptography

Public Class MakeDonation
    Private Sub MakeDonation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT name FROM ngos WHERE id=@nid"
        xComm.Parameters.AddWithValue("@nid", SearchNGO.nid)
        Dim dr1 As SqlDataReader
        dr1 = xComm.ExecuteReader
        If dr1.HasRows Then
            dr1.Read()
            Label19.Text = dr1("name")
        End If
        dr1.Close()
    End Sub
    Private Function DonNoCal() As Integer
        Dim a As Integer
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT id FROM Donations ORDER BY id DESC"
        Dim dr1 As SqlDataReader
        dr1 = xComm.ExecuteReader
        If dr1.HasRows Then
            dr1.Read()
            a = dr1("id")
        End If
        dr1.Close()
        Return a
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id, ngoid, donid As Integer
        Dim type, meal As String
        Dim day As Date
        Dim po As Integer
        id = DonNoCal() + 1
        ngoid = SearchNGO.nid
        donid = Login.accid
        type = Login.acctype
        meal = ComboBox1.SelectedItem
        day = DateTimePicker1.Value
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True"
        cmd.Connection = con
        cmd.CommandText = "insert into donations values(@did, @type, @donid, @nid, @day, @meal)"
        cmd.Parameters.AddWithValue("@did", id)
        cmd.Parameters.AddWithValue("@type", type)
        cmd.Parameters.AddWithValue("@donid", donid)
        cmd.Parameters.AddWithValue("@nid", ngoid)
        cmd.Parameters.AddWithValue("@meal", meal)
        cmd.Parameters.AddWithValue("@day", day)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Error Message")
        End Try
        If TextBox1.Text.ToString IsNot "" Then
            FoodDetails(id, TextBox1.Text, Val(TextBox2.Text))
        End If
        If TextBox4.Text.ToString IsNot "" Then
            FoodDetails(id, TextBox4.Text, Val(TextBox3.Text))
        End If
        If TextBox6.Text.ToString IsNot "" Then
            FoodDetails(id, TextBox6.Text, Val(TextBox5.Text))
        End If
        If TextBox8.Text.ToString IsNot "" Then
            FoodDetails(id, TextBox8.Text, Val(TextBox7.Text))
        End If
        If TextBox10.Text.ToString IsNot "" Then
            FoodDetails(id, TextBox10.Text, Val(TextBox9.Text))
        End If
        MessageBox.Show("You have successfully made the donation!")
        If Login.acctype = "Restaurant" Then
            Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Dim xComm As New SqlCommand()
            xConn.Open()
            xComm.Connection = xConn
            xComm.CommandText = "SELECT points FROM Restaurants WHERE id=@id"
            xComm.Parameters.AddWithValue("@id", Login.accid)
            Dim dr1 As SqlDataReader
            dr1 = xComm.ExecuteReader
            If dr1.HasRows Then
                dr1.Read()
                po = dr1("points")
            End If
            dr1.Close()
        ElseIf Login.acctype = "Individual Donor" Then
            Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Dim xComm As New SqlCommand()
            xConn.Open()
            xComm.Connection = xConn
            xComm.CommandText = "SELECT points FROM Individual WHERE id=@id"
            xComm.Parameters.AddWithValue("@id", Login.accid)
            Dim dr1 As SqlDataReader
            dr1 = xComm.ExecuteReader
            If dr1.HasRows Then
                dr1.Read()
                po = dr1("points")
            End If
            dr1.Close()
        End If
        po = po + (Val(TextBox2.Text) + Val(TextBox3.Text) + Val(TextBox5.Text) + Val(TextBox7.Text) + Val(TextBox9.Text))
        If Login.acctype = "Restaurant" Then
            Dim xConn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Dim xComm1 As New SqlCommand()
            xComm1.Connection = xConn1
            xComm1.CommandText = "Update Restaurants set points=@po"
            xComm1.Parameters.AddWithValue("@po", po)
            xConn1.Close()
            Try
                xConn1.Open()
                xComm1.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox.Show(ex.Message.ToString(), "Error Message")
            End Try
        ElseIf Login.acctype = "Individual Donor" Then
            Dim xConn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Dim xComm1 As New SqlCommand()
            xComm1.Connection = xConn1
            xComm1.CommandText = "Update individual set points=@po"
            xComm1.Parameters.AddWithValue("@po", po)
            xConn1.Close()
            Try
                xConn1.Open()
                xComm1.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox.Show(ex.Message.ToString(), "Error Message")
            End Try
        End If



    End Sub

    Private Sub FoodDetails(id As Integer, item As String, qty As Double)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True"
        cmd.Connection = con
        cmd.CommandText = "insert into food values(@did, @item, @qty)"
        cmd.Parameters.AddWithValue("@did", id)
        cmd.Parameters.AddWithValue("@item", item)
        cmd.Parameters.AddWithValue("@qty", qty)
        con.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Error Message")
        End Try
        con.Close()
    End Sub
End Class