Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Public Class SignUp
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username, password, type As String
        username = TextBox1.Text
        password = TextBox2.Text
        type = ComboBox1.SelectedItem
        If usernameExists(username) Then
            MessageBox.Show("Username Taken. Please choose another username.")
        Else
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True"
            cmd.Connection = con
            cmd.CommandText = "insert into Users values(@username, @password, @type)"
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@type", type)
            Try
                con.Open()
                cmd.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox.Show(ex.Message.ToString(), "Error Message")
            End Try
            Login.uname = username
            MessageBox.Show("You have successfully made an account. Please fill in your other details")
            If ComboBox1.SelectedItem Is "Restaurant" Then
                Dim resreg = New RestaurantReg()
                resreg.Show()
            ElseIf ComboBox1.SelectedItem Is "Individual Donor" Then
                Dim donreg = New IndividualReg()
                donreg.Show()
            ElseIf ComboBox1.SelectedItem Is "NGO" Then
                Dim ngoreg = New NGOReg
                ngoreg.Show()
            End If
            Me.Close()
        End If
    End Sub

    Private Function usernameExists(username As String) As Boolean
        Dim returnValue As Boolean = False
        Using xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
            Using xComm As New SqlCommand()
                With xComm
                    .Connection = xConn
                    .CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @xUserName"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@xUserName", username)
                End With
                Try
                    xConn.Open()
                    If CInt(xComm.ExecuteScalar()) > 0 Then
                        returnValue = True
                    End If
                Catch ex As SqlException
                    MsgBox(ex.Message)
                    returnValue = False
                Finally
                    xConn.Close()
                End Try
            End Using
        End Using
        Return returnValue

    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim loginform = New Login()
        loginform.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim login As New Login()
        login.Show()
        Me.Close()
    End Sub
End Class
