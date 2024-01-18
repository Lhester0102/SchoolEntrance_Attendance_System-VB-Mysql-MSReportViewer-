Public Class barcode_generator

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim Barcode, Check12Digits As String

        If Not (String.IsNullOrEmpty(TextBox1.Text)) Then

            Check12Digits = TextBox1.Text.PadRight(12, CChar("0"))
            Barcode = EAN13(Check12Digits)
            Label1.Text = Barcode

            If Not (String.IsNullOrEmpty(Barcode13Digits)) And
               Not Barcode13Digits = "" Then

                RichTextBox1.Text = Barcode13Digits.Trim.ToString()

                'Change Colour Of Certain Text In A RichTextBox.
                Dim intStart As Int16 = Convert.ToInt16(RichTextBox1.TextLength - 1)
                ChangeColor(RichTextBox1, intStart)

            End If

        End If

    End Sub

    Private Sub barcode_generator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class