Public Class Form1
    Dim ItemsCode As New List(Of String)
    Dim ItemsQuantity As New List(Of Integer)
    Dim quantity As Integer
    Dim TotalCost As Double = 0
    Dim price As Double
    Private Sub LookupButton_Click(sender As Object, e As EventArgs) Handles LookupButton.Click
        Dim itemscode As String = ProductCodeTextBox.Text
        Dim itemPrice As Double = LookupItemPrice(itemscode)
        price = LookupItemPrice(itemscode)
        ItemCostTextBox.Text = price.ToString("0.00")
    End Sub
    Private Function LookupItemPrice(itemCode As String) As Double
        Select Case itemCode
            Case "A123"
                Return 100.35
            Case "B123"
                Return 75.25
            Case "C123"
                Return 50.25
            Case Else
                Return 0 ' Return 0 for unknown items
        End Select
        ItemCostTextBox.Text = LookupItemPrice
    End Function

    Private Sub TotalCostButton_Click(sender As Object, e As EventArgs) Handles TotalCostButton.Click
        Dim total As Double = 0
        Dim quantity As Integer
        If Integer.TryParse(QuantityTextBox.Text, quantity) Then
            ItemsQuantity.Add(quantity)
            TotalCost += price * quantity
            TotalCostTextBox.Text = TotalCost.ToString("0.00")
        Else
        MessageBox.Show("Please enter a valid quantity.")
        End If
    End Sub
    Private Sub BalanceButton_Click(sender As Object, e As EventArgs) Handles BalanceButton.Click
        Dim paymentAmount As Double
        If Double.TryParse(PayTextBox.Text, paymentAmount) Then
            Dim BalanceDue As Double = paymentAmount - TotalCost
            If BalanceDue >= 0 Then
                BalanceTextbox.Text = BalanceDue
            Else
                MessageBox.Show("Insufficient payment amount. Please enter a valid payment.")
            End If
        Else
            MessageBox.Show("Please enter a valid payment amount.")
        End If
    End Sub
    Private Sub Clearbutton_Click(sender As Object, e As EventArgs) Handles Clearbutton.Click
        TotalCostTextBox.Clear()
        ItemsQuantity.Clear()
        PayTextBox.Clear()
        ItemCostTextBox.Clear()
        QuantityTextBox.Clear()
        ProductCodeTextBox.Clear()
        BalanceTextbox.Clear()
    End Sub

    Private Sub Exitbutton_Click(sender As Object, e As EventArgs) Handles Exitbutton.Click
        Me.Close()
    End Sub
End Class
