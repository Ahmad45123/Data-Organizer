Module SettingsHandler
    Dim INIRead As New ExtremeINI.Read
    Dim INIWrite As New ExtremeINI.Write

    Public Function IsFirstRun()
        INIRead.LoadINI(Application.StartupPath + "/AppSettings.ini")
        Dim isnew As Integer
        Try
            isnew = INIRead.ReadInt32("FirstRun")
        Catch ex As Exception
            Return True
        End Try
        If isnew = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub EditTableColoumns(ByVal coloumns As String)
        Dim INI As New ExtremeINI.INI
        INI.Path = (Application.StartupPath + "/AppSettings.ini")

        INIWrite.WriteData(INI, "DataColumns", coloumns)
        INIWrite.WriteINI(INI)
    End Sub

    Public Sub EditName(ByVal name As String)
        Dim INI As New ExtremeINI.INI
        INI.Path = (Application.StartupPath + "/AppSettings.ini")

        INIWrite.WriteData(INI, "AppName", name)
        INIWrite.WriteINI(INI)
    End Sub

    Public Sub FirstRunFinsihed()
        Dim INI As New ExtremeINI.INI
        INI.Path = (Application.StartupPath + "/AppSettings.ini")

        INIWrite.WriteData(INI, "FirstRun", 0)
        INIWrite.WriteINI(INI)
    End Sub

    Public Sub EditPassword(ByVal uncyppass As String)
        Dim pass As String = Base64Encrypt(uncyppass)
        Dim INI As New ExtremeINI.INI
        INI.Path = (Application.StartupPath + "/AppSettings.ini")

        INIWrite.WriteData(INI, "Password", pass)
        INIWrite.WriteINI(INI)
    End Sub

    Public Function GetPassword()
        INIRead.LoadINI(Application.StartupPath + "/AppSettings.ini")
        Try
            Return INIRead.ReadString("Password")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetName()
        INIRead.LoadINI(Application.StartupPath + "/AppSettings.ini")
        Try
            Return INIRead.ReadString("AppName")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetTableContenets()
        INIRead.LoadINI(Application.StartupPath + "/AppSettings.ini")
        Try
            Return INIRead.ReadString("DataColumns")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub SetAttachmentsOption(ByVal isrun As Integer)
        Dim INI As New ExtremeINI.INI
        INI.Path = (Application.StartupPath + "/AppSettings.ini")

        INIWrite.WriteData(INI, "Attachments", isrun)
        INIWrite.WriteINI(INI)
    End Sub

    Public Function GetAttachments()
        INIRead.LoadINI(Application.StartupPath + "/AppSettings.ini")
        Try
            Return INIRead.ReadInt32("Attachments")
        Catch ex As Exception
            Return 0
        End Try

    End Function
End Module
