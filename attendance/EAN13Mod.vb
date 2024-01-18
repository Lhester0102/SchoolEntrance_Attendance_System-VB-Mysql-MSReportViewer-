Imports System.Text.RegularExpressions
Module EAN13Mod
    Public Barcode13Digits As String

    Public Function EAN13(ByVal chaine As String) As String

        Dim i As Int32
        Dim first As Int32
        Dim checksum As Int32 = 0
        Dim EAN13Barcode As String = ""
        Dim tableA As Boolean

        Dim m As Boolean = Regex.IsMatch(chaine, "^\d{12}$")

        If (m) Then

            For i = 1 To (12 - 1) Step 2
                System.Diagnostics.Debug.WriteLine(chaine.Substring(i, 1))
                checksum += Convert.ToInt32(chaine.Substring(i, 1))
            Next

            checksum *= 3

            For i = 0 To (12 - 1) Step 2
                checksum += Convert.ToInt32(chaine.Substring(i, 1))
            Next

            chaine &= (10 - checksum Mod 10) Mod 10
            Barcode13Digits = chaine.ToString()

            EAN13Barcode = chaine.Substring(0, 1) + Convert.ToChar(65 + Convert.ToInt32(chaine.Substring(1, 1)))
            first = Convert.ToInt32(chaine.Substring(0, 1))

            For i = 2 To 6

                tableA = False

                Select Case i
                    Case Is = 2
                        If (first >= 0 And first <= 3) Then tableA = True
                    Case Is = 3
                        If (first = 0 Or first = 4 Or first = 7 Or first = 8) Then tableA = True
                    Case Is = 4
                        If (first = 0 Or first = 1 Or first = 4 Or first = 5 Or first = 9) Then tableA = True
                    Case Is = 5
                        If (first = 0 Or first = 2 Or first = 5 Or first = 6 Or first = 7) Then tableA = True
                    Case Is = 6
                        If (first = 0 Or first = 3 Or first = 6 Or first = 8 Or first = 9) Then tableA = True
                End Select

                If (tableA) Then
                    EAN13Barcode &= Convert.ToChar(65 + Convert.ToInt32(chaine.Substring(i, 1)))
                Else
                    EAN13Barcode &= Convert.ToChar(75 + Convert.ToInt32(chaine.Substring(i, 1)))
                End If

            Next

            EAN13Barcode &= Convert.ToChar("*")

            For i = 7 To 12
                EAN13Barcode += Convert.ToChar(97 + Convert.ToInt32(chaine.Substring(i, 1)))
            Next

            EAN13Barcode += Convert.ToChar("+")

        End If

        Return EAN13Barcode

    End Function
End Module
