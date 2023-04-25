Imports System.Data.SqlClient

Public Class RestaurantDetails
    Public reid As Integer
    Private Sub IndividualDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Enabled = False
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = True

        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT id, name, contact, address FROM restaurants WHERE username=@xUserName"
        Dim p1 As New SqlParameter("@xUserName", SqlDbType.VarChar)
        p1.Direction = ParameterDirection.Input
        p1.Value = Login.uname
        Dim dr1 As SqlDataReader
        xComm.Parameters.Add(p1)
        dr1 = xComm.ExecuteReader
        If dr1.HasRows Then
            dr1.Read()
            reid = dr1("id")
            TextBox1.Text = dr1("name")
            TextBox3.Text = dr1("contact")
            RichTextBox1.Text = dr1("address")
        End If
        dr1.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox1.Enabled = True
        Button2.Enabled = True
        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        RichTextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = True
        Dim id, name, contact, address As String
        id = reid
        name = TextBox1.Text
        contact = TextBox3.Text
        address = RichTextBox1.Text
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True"
        cmd.Connection = con
        cmd.CommandText = "UPDATE restaurants SET name=@name,contact=@contact, address=@address WHERE id=@id"
        cmd.Parameters.AddWithValue("@username", Login.uname)
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@contact", contact)
        cmd.Parameters.AddWithValue("@address", address)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Error Message")
        End Try
        MessageBox.Show("You have successfully updated your Restaurant Details")
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dashboard As New Dashboard()
        dashboard.Show()
        Me.Close()
    End Sub
End Class