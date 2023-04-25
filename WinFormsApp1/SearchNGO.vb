Imports System.Data.SqlClient

Public Class SearchNGO
    Public Shared nid As Integer
    Public Shared donid As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MessageBox.Show("Please fill in all the details")
            Exit Sub
        End If
        If ComboBox2.SelectedItem = "0-10" Then
            DataGridView1.DataSource = GetNGOs(ComboBox1.SelectedItem, 1, 10, ComboBox3.SelectedItem)
        ElseIf ComboBox2.SelectedItem = "10-25" Then
            DataGridView1.DataSource = GetNGOs(ComboBox1.SelectedItem, 11, 25, ComboBox3.SelectedItem)
        ElseIf ComboBox2.SelectedItem = "25-50" Then
            DataGridView1.DataSource = GetNGOs(ComboBox1.SelectedItem, 26, 50, ComboBox3.SelectedItem)
        ElseIf ComboBox2.SelectedItem = "50-100" Then
            DataGridView1.DataSource = GetNGOs(ComboBox1.SelectedItem, 51, 100, ComboBox3.SelectedItem)
        ElseIf ComboBox2.SelectedItem = "100-250" Then
            DataGridView1.DataSource = GetNGOs(ComboBox1.SelectedItem, 101, 250, ComboBox3.SelectedItem)
        Else
            DataGridView1.DataSource = GetNGOs(ComboBox1.SelectedItem, 251, 10000, ComboBox3.SelectedItem)
        End If
    End Sub

    Private Function GetNGOs(City As String, lower As Integer, higher As Integer, Type As String) As Object
        Dim NGOs As New DataTable
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT id AS 'NGO ID', name AS 'NAME', people as 'No of People', contact AS 'Phone Number', city as 'City' FROM NGOS WHERE City=@City AND Type=@type AND people BETWEEN @lower and @higher"
        Dim p1 As New SqlParameter("@city", SqlDbType.VarChar)
        Dim p2 As New SqlParameter("@lower", SqlDbType.Int)
        Dim p3 As New SqlParameter("@higher", SqlDbType.Int)
        Dim p4 As New SqlParameter("@type", SqlDbType.VarChar)
        p1.Direction = ParameterDirection.Input
        p2.Direction = ParameterDirection.Input
        p3.Direction = ParameterDirection.Input
        p4.Direction = ParameterDirection.Input
        p1.Value = City
        p2.Value = lower
        p3.Value = higher
        p4.Value = Type
        Dim dr1 As SqlDataReader
        xComm.Parameters.Add(p1)
        xComm.Parameters.Add(p2)
        xComm.Parameters.Add(p3)
        xComm.Parameters.Add(p4)
        dr1 = xComm.ExecuteReader
        NGOs.Load(dr1)
        Return NGOs
    End Function

    Private Sub SearchNGO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xConn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AADAR\Desktop\shareabite\WinFormsApp1\WinFormsApp1\shareabite.mdf;Integrated Security=True")
        Dim xComm As New SqlCommand()
        xConn.Open()
        xComm.Connection = xConn
        xComm.CommandText = "SELECT DISTINCT city FROM NGOs"
        Dim dr1 As SqlDataReader
        dr1 = xComm.ExecuteReader
        Do While dr1.Read
            ComboBox1.Items.Add(dr1("city"))
        Loop
        dr1.Close()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        nid = DataGridView1.CurrentRow.Cells(0).Value
        Dim md As New MakeDonation()
        md.Show()
        Me.Close()
    End Sub
End Class