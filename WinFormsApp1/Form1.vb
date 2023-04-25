Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Clear()
        Dim i As Integer
        Dim dr1 As SqlDataReader
        Dim cmd1 As New SqlCommand
        Dim dr2 As SqlDataReader
        Dim cmd2 As New SqlCommand
        Dim con As New SqlConnection

        i = 0
        If Login.acctype = "Restaurant" Then
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\SE\LMS\LMS\Database1.mdf;Integrated Security=True")
            con.Open()
            cmd1.Connection = con
            cmd1.CommandText = "select date, did, meal,type from donation order by date desc"
            dr1 = cmd1.ExecuteReader
            Do While dr1.Read()
                Dim rowIndex As Integer = DataGridView1.Rows.Add()
                DataGridView1.Rows(rowIndex).Cells("Column1").Value = dr1("date")
                DataGridView1.Rows(rowIndex).Cells("Column2").Value = dr1("did")
                DataGridView1.Rows(rowIndex).Cells("Column3").Value = dr1("meal")
            Loop
            dr1.Close()
            cmd2.Connection = con
            cmd2.CommandText = "SELECT  id, contact FROM restaurants WHERE username=@username"
            cmd2.Parameters.AddWithValue("@username", Login.uname)
            dr2 = cmd2.ExecuteReader

            Do While dr2.Read()
                Dim contact As String = dr2("contact").ToString()
                Dim did As String = dr2("id").ToString()
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = did Then
                        row.Cells(3).Value = contact
                    End If
                Next
            Loop
            dr2.Close()
            con.Close()
        ElseIf Login.acctype = "Individual" Then
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\SE\LMS\LMS\Database1.mdf;Integrated Security=True")
                con.Open()
                cmd1.Connection = con
                cmd1.CommandText = "select date, did, meal,type from donation order by date desc"
                dr1 = cmd1.ExecuteReader
                Do While dr1.Read()
                    Dim rowIndex As Integer = DataGridView1.Rows.Add()
                    DataGridView1.Rows(rowIndex).Cells("Column1").Value = dr1("date")
                    DataGridView1.Rows(rowIndex).Cells("Column2").Value = dr1("did")
                    DataGridView1.Rows(rowIndex).Cells("Column3").Value = dr1("meal")
                Loop
                dr1.Close()
                cmd2.Connection = con
                cmd2.CommandText = "SELECT  id, contact FROM restaurants WHERE username=@username"
                cmd2.Parameters.AddWithValue("@username", Login.uname)
                dr2 = cmd2.ExecuteReader

                Do While dr2.Read()
                    Dim contact As String = dr2("contact").ToString()
                    Dim did As String = dr2("id").ToString()
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = did Then
                            row.Cells(3).Value = contact
                        End If
                    Next
                Loop
                dr2.Close()
                con.Close()
            End If
    End Sub
End Class