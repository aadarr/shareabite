Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class NGODetails
    Public ngoid As Integer
    Private Sub NGODetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
        Button2.Enabled = False
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT id, name, people, contact, city, type FROM NGOs WHERE username=@xUserName"
        Dim p1 As New SqlParameter("@xUserName", SqlDbType.VarChar)
        p1.Direction = ParameterDirection.Input
        p1.Value = Login.uname
        Dim dr1 As SqlDataReader
        xComm.Parameters.Add(p1)
        dr1 = xComm.ExecuteReader
        If dr1.HasRows Then
            dr1.Read()
            ngoid = dr1("id")
            TextBox1.Text = dr1("name")
            ComboBox1.Text = dr1("type")
            TextBox2.Text = dr1("people")
            TextBox3.Text = dr1("contact")
            TextBox4.Text = dr1("city")
        End If
        dr1.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
        Button2.Enabled = True
        Button1.Enabled = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = True
        Dim id, name, noofpeeps, contact, address, type As String
        id = ngoid
        name = TextBox1.Text
        noofpeeps = TextBox2.Text
        contact = TextBox3.Text
        address = TextBox4.Text
        type = ComboBox1.SelectedItem
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True"
        cmd.Connection = con
        cmd.CommandText = "UPDATE Ngos SET username=@username, id=@id, name=@name, people=@noofpeeps, contact=@contact, city=@address, type=@type WHERE id=@id"
        cmd.Parameters.AddWithValue("@username", Login.uname)
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@noofpeeps", noofpeeps)
        cmd.Parameters.AddWithValue("@contact", contact)
        cmd.Parameters.AddWithValue("@address", address)
        cmd.Parameters.AddWithValue("@type", type)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show(ex.Message.ToString(), "Error Message")
        End Try
        MessageBox.Show("You have successfully updated your NGO Details")
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dashboard As New Dashboard()
        dashboard.Show()
        Me.Close()
    End Sub
End Class