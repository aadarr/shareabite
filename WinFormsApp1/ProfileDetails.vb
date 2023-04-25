Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Logging
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ProfileDetails
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Private Sub ProfileDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Enabled = True
        TextBox1.Enabled = False
        TextBox3.Enabled = False

        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT username, type FROM users WHERE username=@xUserName"
        Dim p1 As New SqlParameter("@xUserName", SqlDbType.VarChar)
        p1.Direction = ParameterDirection.Input
        p1.Value = Login.uname
        Dim dr1 As SqlDataReader
        xComm.Parameters.Add(p1)
        dr1 = xComm.ExecuteReader
        If dr1.HasRows Then
            dr1.Read()
            TextBox1.Text = dr1("username")
            TextBox3.Text = dr1("type")
        End If
        dr1.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True"

        Dim pass As String
        Dim newpass As String
        pass = InputBox("Enter the current password:")


        Dim dr3 As SqlDataReader
        Dim cmd3 As New SqlCommand


        con.Open()
        cmd3.Connection = con
        cmd3.CommandText = "select password from users where username=" & "(@userid)"
        Dim parameterstate As New SqlParameter("@userid", SqlDbType.VarChar)
        parameterstate.Direction = ParameterDirection.Input
        parameterstate.Value = Login.uname
        cmd3.Parameters.Add(parameterstate)
        dr3 = cmd3.ExecuteReader
        dr3.Read()

        If pass = dr3("password") Then
            dr3.Close()
            newpass = InputBox("Enter the new password:")

            Dim qr = "update users set password='" & newpass & "'where username=" & "(@userid)"
            Dim parameterstate1 As New SqlParameter("@userid", SqlDbType.VarChar)
            parameterstate1.Direction = ParameterDirection.Input
            parameterstate1.Value = Login.uname
            cmd3.Parameters.Add(parameterstate1)
            cmd = New SqlCommand(qr, con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("password Updated")

        Else
            MessageBox.Show("Enter correct Password")
        End If
        con.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dashboard As New Dashboard()
        dashboard.Show()
        Me.Close()
    End Sub
End Class