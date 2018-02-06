Imports System.Threading
Imports System.Drawing.Printing
Imports System.Data.OleDb

Public Class MainForm
    Dim WithEvents gDT As New DataTable
    Dim IsAppStarted As Boolean = False

    Dim NumbringColumn As Integer

    Public Sub AddRowsNumbering(ByVal grid As DataGridView)
        MainDataGrid.Columns(0).Visible = False
        Dim clm As New DataGridViewTextBoxColumn
        clm.HeaderText = "م"
        clm.ReadOnly = True

        NumbringColumn = grid.Columns.Add(clm)
        grid.Columns(NumbringColumn).DisplayIndex = 0

        Dim num As Integer = 1
        For i = 0 To grid.Rows.Count - 1
            grid.Rows(i).Cells(NumbringColumn).Value = num
            num += 1
        Next
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DBConn.StoredAdap.Update(gDT)
        DBConn.Con.Close()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "منظم البيانات - " + TableDataHandler.Name

        gDT = DBConn.Withreturn("select " + GetAllFeilds() + " from Data", True)
        MainDataGrid.DataSource = gDT

        TableDataHandler.RenameDataGrideViewColoumns(MainDataGrid)

        'Start loading the order by combo
        For Each fld As TableDataHandler.tblclm In TableContents
            If fld.Type = 1 And fld.IsSortAble = 1 Then
                OrderCombo.Items.Add(fld.Title)
            End If
        Next
        If OrderCombo.Items.Count > 0 Then OrderCombo.SelectedIndex = 0

        'Start loading the groups
        For Each grp As TableDataHandler.grps In Groups
            GrpCombo.Items.Add(grp.gname)
        Next
        GrpCombo.Items.Add("الكل")
        GrpCombo.SelectedIndex = GrpCombo.Items.Count - 1

        'Check if the attachments system enabled
        Button1.Visible = SettingsHandler.GetAttachments()

        'Make the app's ID hidden.
        AddRowsNumbering(MainDataGrid)
        IsAppStarted = True
    End Sub


    Public Sub NewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles gDT.TableNewRow
        Try
            e.Row.Item(0) = gDT.Rows(gDT.Rows.Count - 1).Item(0) + 1
        Catch ex As IndexOutOfRangeException
            e.Row.Item(0) = 1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_RowLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MainDataGrid.RowLeave
        If IsAppStarted = False Then Exit Sub

        ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                         Try
                                             DBConn.StoredAdap.Update(gDT)
                                         Catch ex As Exception

                                         End Try
                                     End Sub)

    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles MainDataGrid.CellFormatting
        Try
            Dim nm As Integer = MainDataGrid.RowCount - 1
            For i As Integer = 0 To nm
                For Each grp As TableDataHandler.grps In TableDataHandler.Groups
                    If MainDataGrid.Rows(i).Cells(MainDataGrid.Columns.Count - 2).Value = grp.gname Then
                        MainDataGrid.Rows(i).DefaultCellStyle.ForeColor = grp.color
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MainDataGrid_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MainDataGrid.CellEndEdit
        If IsAppStarted = False Then Exit Sub

        Dim cellID As Integer = MainDataGrid.Columns.Count - 2
        Dim id = MainDataGrid.Rows(e.RowIndex).Cells(0).FormattedValue
        Dim choosenItem As String = MainDataGrid.Rows(e.RowIndex).Cells(cellID).FormattedValue

        If choosenItem = Nothing Then Exit Sub

        Dim gID As Integer = 0
        Dim num As Integer = Groups.Count - 1
        For gID = 0 To num
            If choosenItem = Groups(gID).gname Then
                Exit For
            End If
        Next

        Nonreturn("UPDATE Data SET Grp = " + gID.ToString + " WHERE id = " + id.ToString)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim OrderType As String = Nothing
        Dim sGroup As Integer = GetGrpIDByName(GrpCombo.SelectedItem)
        Dim OrderBy As String = OrderCombo.SelectedItem.ToString.Replace(" ", "_")
        If RadioButton1.Checked Then OrderType = "desc" Else If RadioButton2.Checked Then OrderType = "asc"

        If GrpCombo.SelectedItem = "الكل" Then
            MainDataGrid.Columns.Clear()
            gDT = DBConn.Withreturn("select " + GetAllFeilds() + " from Data order by " + OrderBy + " " + OrderType, True)
            MainDataGrid.DataSource = gDT

            TableDataHandler.RenameDataGrideViewColoumns(MainDataGrid, "order by " + OrderBy + " " + OrderType)
            AddRowsNumbering(MainDataGrid)
            Exit Sub
        End If

        MainDataGrid.Columns.Clear()
        gDT = Withreturn("select " + GetAllFeilds() + " from Data where Grp = '" + sGroup.ToString + "' order by " + OrderBy + " " + OrderType)
        MainDataGrid.DataSource = gDT

        TableDataHandler.RenameDataGrideViewColoumns(MainDataGrid, "where Grp = '" + sGroup.ToString + "' order by " + OrderBy + " " + OrderType)
        AddRowsNumbering(MainDataGrid)
    End Sub

    Public Function GetGrpIDByName(ByVal name As String)
        For i = 0 To Groups.Count - 1
            If Groups(i).gname = name Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub MyPrintDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles MyPrintDocument.PrintPage
        Dim more As Boolean = PrintingHandler.DrawDataGridView(e.Graphics)
        If more = True Then
            e.HasMorePages = True
        End If
    End Sub

    Public Function GetIfIsLandScape()
        Dim sel As String = InputBox("افقي / عمودي ؟" + vbCrLf + vbCrLf + "أفقي = 1 | عمودي = 0")
        If sel = 0 Or sel = 1 Then Return sel Else GetIfIsLandScape()
        Return 0
    End Function

    Private Function SetupThePrinting() As Boolean
        Dim MyPrintDialog As New PrintDialog()
        MyPrintDialog.AllowCurrentPage = False
        MyPrintDialog.AllowPrintToFile = False
        MyPrintDialog.AllowSelection = False
        MyPrintDialog.AllowSomePages = False
        MyPrintDialog.PrintToFile = False
        MyPrintDialog.ShowHelp = False
        MyPrintDialog.ShowNetwork = False

        If MyPrintDialog.ShowDialog() <> DialogResult.OK Then
            Return False
        End If

        MyPrintDocument.DocumentName = SettingsHandler.GetName
        MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings
        MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings

        MyPrintDocument.DefaultPageSettings.Landscape = GetIfIsLandScape()
        MyPrintDocument.DefaultPageSettings.Margins = New Margins(1, 1, 40, 40)

        PrintingHandler.Intial(MainDataGrid, MyPrintDocument, True, True, SettingsHandler.GetName, New Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, True)
        Return True
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If SetupThePrinting() Then
            MyPrintDocument.Print()
        End If
    End Sub

    Private Sub MainDataGrid_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles MainDataGrid.CellBeginEdit
        If DBNull.Value.Equals(MainDataGrid.Rows(e.RowIndex).Cells(NumbringColumn)) Or MainDataGrid.Rows(e.RowIndex).Cells(NumbringColumn).Value = Nothing Then
            If e.RowIndex = 0 Then
                MainDataGrid.Rows(e.RowIndex).Cells(NumbringColumn).Value = 1
            Else
                MainDataGrid.Rows(e.RowIndex).Cells(NumbringColumn).Value = MainDataGrid.Rows(e.RowIndex - 1).Cells(NumbringColumn).Value + 1

            End If
        End If
    End Sub

    Private Sub MainDataGrid_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles MainDataGrid.RowsRemoved
        If IsAppStarted = False Then Exit Sub

        ThreadPool.QueueUserWorkItem(Sub(o As Object)
                                         Try
                                             DBConn.StoredAdap.Update(gDT)
                                         Catch ex As Exception

                                         End Try
                                     End Sub)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Dlg As New Attach
        Dlg.eID = MainDataGrid.Rows(MainDataGrid.SelectedCells.Item(0).RowIndex).Cells(0).Value
        Dlg.ShowDialog()
    End Sub
End Class