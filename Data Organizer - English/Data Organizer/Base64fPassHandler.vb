Module Base64fPassHandler

    Public Function Base64Encrypt(ByVal text As String)
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(text)
        Dim enc As String = Convert.ToBase64String(byt)
        Return enc
    End Function

    Public Function CompareText(ByVal text1 As String, ByVal text2 As String)
        If Base64Encrypt(text1) = text2 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
