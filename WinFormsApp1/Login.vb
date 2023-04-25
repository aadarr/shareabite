Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Public Class Login
    Public Shared uname As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username, password As String
        username = TextBox1.Text
        password = TextBox2.Text
        If usernameCheck(username) And passwordCheck(password) Then
            uname = username
            Dim dashboard = New Dashboard()
            dashboard.Show()
        ElseIf usernameCheck(username) = False Then
            MessageBox.Show("Invalid Username")
        ElseIf passwordCheck(password) = False Then
            MessageBox.Show("Wrong Password")
        End If
    End Sub
    Private Function passwordCheck(password As String) As Boolean
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT COUNT(*) FROM Users WHERE Password = @xPassword"
        xComm.Parameters.AddWithValue("@xPassword", password)
        xConn.Open()
        If CInt(xComm.ExecuteScalar()) > 0 Then
            Return True
        End If
        xConn.Close()
        Return False
    End Function

    Private Function usernameCheck(username As String) As Boolean
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @xUserName"
        xComm.Parameters.AddWithValue("@xUserName", username)
        xConn.Open()
        If CInt(xComm.ExecuteScalar()) > 0 Then
            Return True
        End If
        xConn.Close()
        Return False
    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim signupform = New SignUp()
        signupform.Show()
    End Sub
End Class
