
Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection()
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"

        con.Open()

        Dim query As String = "insert into customer values ('" & TextBox1.Text & "', '" & TextBox2.Text & "')"

        Dim cmd As New SqlCommand(query, con)
        cmd.ExecuteNonQuery()

        Label1.Text = "Data Stored Successfully ......! "

        con.Close()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim con1 As New SqlConnection()
        Dim cmd1 As New SqlCommand()
        Dim query1 As String = "Select * from customer"

        con1.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"
        con1.Open()
        cmd1 = New SqlCommand(query1, con1)
        Dim dr As SqlDataReader = cmd1.ExecuteReader()
        While (dr.Read())
            Response.Write("Customer ID : " & dr("customerId") & "<br/>" & "Customer Name : " & dr("customerName") & "<br/>")
        End While

        dr.Close()
        con1.Dispose()
        con1 = Nothing

    End Sub
End Class
