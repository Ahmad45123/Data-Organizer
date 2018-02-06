Imports System.Data.OleDb

Module DBConn
    Public Con As New OleDbConnection("FILE NAME = '" + Application.StartupPath + "\Conn.udl'")
    Public WithEvents StoredAdap As OleDbDataAdapter

    Public Function Withreturn(ByVal sql As String, Optional ByVal store As Boolean = False)
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim dt As New DataTable

        If store = True Then
            StoredAdap = New OleDbDataAdapter(sql, Con)
            Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(StoredAdap)
            StoredAdap.Fill(dt)
        Else
            Dim cmd As New OleDbDataAdapter(sql, Con)
            cmd.Fill(dt)

        End If

        Return dt
    End Function

    Public Sub Nonreturn(ByVal sql As String)
        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Dim dt As New DataTable
        Dim cmd As New OleDbCommand(sql, Con)
        cmd.ExecuteNonQuery()
    End Sub

    Sub OnRowUpdating(ByVal sender As Object, ByVal args As OleDbRowUpdatingEventArgs) Handles StoredAdap.RowUpdating
        If args.StatementType = StatementType.Delete Then
            Dim row As DataRow = args.Row
            Dim idx As String = row(0).ToString
            Nonreturn("DELETE FROM Attach WHERE idx = " + idx)
        End If
    End Sub
End Module
