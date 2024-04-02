Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form5
    Dim connStr As String = "Server=127.0.0.1;port=3307;Database=membership;Uid=root;Pwd=February#04;"
    Dim conn As New MySqlConnection(connStr)

    Private Sub LookupButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim itemName As String = TextBox1.Text
        Dim itemPrice As Double = LookupItemPrice(itemName)
        TextBox3.Text = itemPrice.ToString("0.00")
    End Sub

    Private Function LookupItemPrice(itemName As String) As Double
        Dim price As Double = 0

        Try
            conn.Open()
            Dim query As String = "SELECT price FROM items WHERE item_name = @name"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@name", itemName)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                price = Convert.ToDouble(reader("price"))
            Else
                MessageBox.Show("Item not found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving item price: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return price
    End Function

    Private Sub TotalCostButton_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim quantity As Integer

        If Integer.TryParse(TextBox2.Text, quantity) Then
            Dim itemCode As String = TextBox1.Text
            Dim itemPrice As Double = LookupItemPrice(itemCode)

            If itemPrice > 0 Then
                Dim totalCost As Double = itemPrice * quantity
                TextBox4.Text = totalCost.ToString("0.00")
            End If
        Else
            MessageBox.Show("Please enter a valid quantity.")
        End If
    End Sub

    Private Sub BalanceButton_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim paymentAmount As Double

        If Double.TryParse(TextBox5.Text, paymentAmount) Then
            Dim totalCost As Double = Convert.ToDouble(TextBox4.Text)
            Dim balanceDue As Double = paymentAmount - totalCost
            If balanceDue >= 0 Then
                TextBox6.Text = balanceDue.ToString("0.00")
            Else
                MessageBox.Show("Insufficient payment amount. Please enter a valid payment.")
            End If
        Else
            MessageBox.Show("Please enter a valid payment amount.")
        End If
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

End Class
