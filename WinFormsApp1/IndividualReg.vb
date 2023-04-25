Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class IndividualReg
    Public previd As Integer
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Function ResNoCal() As Integer
        Dim a As Integer
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT id FROM individual ORDER BY id DESC"
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
        Dim id, name, contact, address As String
        id = ResNoCal() + 1
        name = TextBox1.Text
        contact = TextBox2.Text
        address = RichTextBox1.Text
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True"
        cmd.Connection = con
        cmd.CommandText = "insert into individual values(@username, @id, 0, @contact, @address, @name)"
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
        MessageBox.Show("You have successfully registered as an individual donor")
        Me.Close()
    End Sub
End Class