Module ChangeTextColorMod
    Public Sub ChangeColor(rt As RichTextBox, Start As Int16, Optional Length As Byte = 1)

        With rt
            .SelectionAlignment = HorizontalAlignment.Left
            .SelectionStart = Start
            .SelectionLength = Length
            .SelectionColor = Color.Crimson
        End With

    End Sub
End Module