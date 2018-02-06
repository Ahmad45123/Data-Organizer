Public Module TableDataHandler
    Public Class tblclm
        Public Title As String
        Public Type As Integer
        Public IsSortAble As Integer
    End Class

    Public Class grps
        Public gname As String
        Public color As Color
    End Class

    Public Property TableContents As New List(Of tblclm)
    Public Property Groups As New List(Of grps)

    Private pass As String
    Public ReadOnly Property Password As String
        Get
            Return pass
        End Get
    End Property

    Private nme As String
    Public ReadOnly Property Name As String
        Get
            Return nme
        End Get
    End Property

    Public Sub ReadData()
        Try
            pass = SettingsHandler.GetPassword()
            nme = SettingsHandler.GetName()
            Dim tmpClms As String = SettingsHandler.GetTableContenets()
            Dim Clms() As String = tmpClms.Split("|".ToCharArray)

            For Each Str As String In Clms 'Ahmed(0,-1)
                Dim tmpcls As New tblclm
                tmpcls.Title = Str.Substring(0, Str.IndexOf("("))
                Str = Str.Remove(0, Str.IndexOf("("))

                Str = Str.Replace(")", "")
                Str = Str.Replace("(", "")
                Dim clm As String() = Str.Split(",".ToCharArray)
                tmpcls.Type = clm(0)
                tmpcls.IsSortAble = clm(1)

                TableContents.Add(tmpcls)
            Next

            'Reading the groups
            Dim gdt As New DataTable
            gdt = DBConn.Withreturn("select * from Groups")

            For i = 0 To gdt.Rows.Count - 1
                Dim tempclass As New grps
                tempclass.gname = gdt.Rows(i).Item(1)
                tempclass.color = StartupForm.DecodeColorFromString(gdt.Rows(i).Item(2))
                Groups.Add(tempclass)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RenameDataGrideViewColoumns(ByVal datagrid As DataGridView, Optional ByVal custom As String = "")
        Dim id As Integer = 0
        Dim isfirst As Boolean = True
        For Each colom As DataGridViewColumn In datagrid.Columns
            Try
                If isfirst = True Then
                    colom.HeaderText = "id"
                    colom.ReadOnly = True

                Else
                    colom.HeaderText = TableContents(id).Title
                End If
            Catch ex As ArgumentOutOfRangeException
            End Try
            If isfirst = False Then id = id + 1 Else isfirst = False
        Next

        Dim cboColumn As New DataGridViewComboBoxColumn
        cboColumn.HeaderText = "المجموعة"
        For Each i As grps In Groups
            cboColumn.Items.Add(i.gname)
        Next
        datagrid.Columns.Add(cboColumn)
        ReadGrpInfoAndChange(datagrid, custom)
    End Sub

    Public Function GetAllFeilds()
        Dim output As String = "id, "

        For Each s As tblclm In TableContents
            Dim tmpname As String = s.Title.Replace(" ", "_")
            output = output + tmpname + ", "
        Next

        output = output.Remove(output.LastIndexOf(","), 2)

        Return output
    End Function

    Public Sub ReadGrpInfoAndChange(ByVal datagrid As DataGridView, ByVal custom As String)
        Dim dt As DataTable = DBConn.Withreturn("select Grp from Data " + custom)
        For i = 0 To datagrid.RowCount - 2
            If DBNull.Value.Equals(dt.Rows(i).Item(0)) Then dt.Rows(i).Item(0) = 0
            Dim cellid As Integer = datagrid.Columns.Count - 1
            Dim grp As Integer = Convert.ToInt16(dt.Rows(i).Item(0).ToString())
            datagrid.Rows(i).Cells(cellid).Value = Groups(grp).gname
        Next
    End Sub
End Module
