Public Class Form3
    Private Sub AddItemButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim <> String.Empty Then
            ListBox1.Items.Add(TextBox1.Text)
            TextBox1.Focus()
            TextBox1.Clear()
        Else
            MessageBox.Show("You must  type a new item name.", "Name Missing Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
        End If
    End Sub
    Private Sub RemoveItemButton_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim ResponseDialogResult As DialogResult =
            MessageBox.Show("Remove the selected Item?", "Remove ?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2)
            If ResponseDialogResult = DialogResult.Yes Then
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            End If
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("You must select an item to remove.",
            "No Selection Was Made", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CountStudentsButton_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Display a message box with the count of the number of Items
        Dim MessageString As String = "Number of Items: " &
        ListBox1.Items.Count.ToString()
        MessageBox.Show(MessageString, "Count", MessageBoxButtons.OK,
        MessageBoxIcon.Information)
    End Sub
    Private Sub ItemsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        'Use messagebox to display selected Item
        If ListBox1.SelectedIndex = -1 Then
            MessageBox.Show("You must select an item display.",
           "No Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show(ListBox1.SelectedItem.ToString,
            "Current selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub
End Class
