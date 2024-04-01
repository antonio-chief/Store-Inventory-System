Imports MySql.Data.MySqlClient

Public Class Form1
    Dim connectionString As String = "Server=127.0.0.1;port=3307;Database=membership;Uid=root;Pwd=February#04;"

    Private Sub VerifyCustomer(phoneNumber As String)
        Using connection As New MySqlConnection(connectionString)
            Dim query As String = "SELECT * FROM members WHERE member_phone_number = @phone"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@phone", phoneNumber)
                connection.Open()
                Dim reader As MySqlDataReader = command.ExecuteReader()
                If reader.Read() Then
                    MessageBox.Show("Customer Verified: " & reader("member_name").ToString())
                    Dim price As Decimal = InputBox("Enter price:")
                    Dim points As Integer = CInt(price / 100)
                    UpdatePoints(reader("member_no"), points)
                Else 
                    MessageBox.Show("Customer not found.")
                End If
            End Using
        End Using
    End Sub

    Private Sub UpdatePoints(memberNo As Integer, points As Integer)
        Using connection As New MySqlConnection(connectionString)
            Dim query As String = "UPDATE members SET points = points + @points WHERE member_no = @memberNo"
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@points", points)
                command.Parameters.AddWithValue("@memberNo", memberNo)
                connection.Open()
                command.ExecuteNonQuery()
                MessageBox.Show("Points updated successfully.")
            End Using
        End Using
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim phoneNumber As String = InputBox("Enter customer phone number:")
        VerifyCustomer(phoneNumber)
    End Sub
End Class



