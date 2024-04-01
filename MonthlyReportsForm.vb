Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Close the form if the system user responds Yes
        Dim response As Integer =
        MsgBox("Close the form?", vbYesNo + vbQuestion + vbDefaultButton2, "Quit?")
        If response = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub ComputeButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim VolumeDecimal, ChargeRateDecimal, MonthlyChargesDecimal As Decimal
            If TextBox1.Text.Trim = String.Empty Then
                MessageBox.Show("Item is required", "Item Missing Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
                TextBox1.SelectAll()
            ElseIf IsNumeric(TextBox2.Text) = False OrElse
            (Decimal.Parse(TextBox2.Text,
            Globalization.NumberStyles.Number) <= 0D Or
            Decimal.Parse(TextBox2.Text,
            Globalization.NumberStyles.Number) > 60D) Then
                'Volume must be numeric and within allowable range
                MessageBox.Show("Volume must be numeric between 0 and 60",
                "Volume Value Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error)
                TextBox2.Focus()
                TextBox2.SelectAll()
            ElseIf IsNumeric(TextBox3.Text) = False OrElse
            Decimal.Parse(TextBox3.Text,
            Globalization.NumberStyles.Currency) <= 0D Then

                'Charging rate must be numeric and greater than zero
                MessageBox.Show("Charging rate worked must be greater than zero.",
 "Charging Rate Value Error", MessageBoxButtons.OK,
 MessageBoxIcon.Error)
                TextBox3.Focus()
                TextBox3.SelectAll()
            Else
                VolumeDecimal = Decimal.Parse(TextBox2.Text,
                Globalization.NumberStyles.Number)
                ChargeRateDecimal = Decimal.Parse(TextBox3.Text,
               Globalization.NumberStyles.Currency)
                'Compute gross charges
                If VolumeDecimal <= 40D Then 'charge only regular time
                    MonthlyChargesDecimal = Decimal.Round(VolumeDecimal *
                    ChargeRateDecimal, 2)
                Else 'charge regular + overtime
                    ChargeRateDecimal = Decimal.Round((40D * ChargeRateDecimal) _
                   + ((VolumeDecimal - 40D) * ChargeRateDecimal * 1.5D), 2)
                End If
                TextBox4.Text = ChargeRateDecimal.ToString("C")
            End If
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ControlChars.NewLine &
            ex.Message, "Compute Button Error", MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try
    End Sub

End Class
