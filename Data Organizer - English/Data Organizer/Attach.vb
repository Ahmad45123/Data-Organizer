Imports System.Data.OleDb
Imports System.IO
Imports System.Text

Public Class Attach

    Public eID As Integer = -1
    Dim DT As New DataTable

    Private Sub Attach_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If eID = -1 Then Throw New Exception("eID is -1." + vbCrLf + "Please set it to the user ID.")

        DT = Withreturn("select name,image from Attach where idx = " + eID.ToString)
        ImgDataGrid.DataSource = DT
        ImgDataGrid.Columns(1).Visible = False
        ImgDataGrid.Columns(0).HeaderText = "Name"
        ImgDataGrid.Columns(1).HeaderText = "Image"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dlg As New OpenFileDialog
        dlg.Title = "Select Image"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            AddPathTextBox.Text = dlg.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Declaring stuff
        Dim cmd As OleDbCommand
        Dim img As New MemoryStream()
        Dim Imgdata As Byte()

        'Get the image binary
        PictureBox1.BackgroundImage = Image.FromFile(AddPathTextBox.Text)
        PictureBox1.BackgroundImage.Save(img, PictureBox1.BackgroundImage.RawFormat)
        Imgdata = img.GetBuffer()

        'Do the cmd
        cmd = New OleDbCommand("INSERT INTO Attach Values(" + eID.ToString + ", ?, ?)", Con)
        Dim nme As New OleDbParameter
        Dim imgs As New OleDbParameter
        nme.Value = AddNameTextBox.Text
        imgs.Value = Imgdata
        cmd.Parameters.Add(nme)
        cmd.Parameters.Add(imgs)
        cmd.ExecuteNonQuery()

        'Add it to the datagrid
        DT.Rows.Add({AddNameTextBox.Text, Imgdata})
    End Sub


    Public Function GetImageFromByteArray(ByVal bytes As Byte()) As Image
        Return CType(Image.FromStream(New IO.MemoryStream(bytes)), Image)
    End Function



    Private Sub ImgDataGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ImgDataGrid.CellClick
        Dim nme As String = ImgDataGrid.Rows(e.RowIndex).Cells(0).Value
        For Each row As DataRow In DT.Rows
            If row(0) = nme Then
                PictureBox1.BackgroundImage = GetImageFromByteArray(row(1))
                Exit For
            End If
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim dlg As New OpenFileDialog
        dlg.Title = "Select Image"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            EditTextBoxPath.Text = dlg.FileName
        End If
    End Sub

    Private Sub ImgDataGrid_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ImgDataGrid.CellEnter
        EditTextBoxName.Text = ImgDataGrid.Rows(e.RowIndex).Cells(0).Value
        EditTextBoxPath.Text = "No Change"
        EditGroupBox.Enabled = True
    End Sub

    Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim img As Image = PictureBox1.BackgroundImage
            img.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox1.BackgroundImage = img
            PictureBox1.Refresh()
        End If
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        ImagePrev.PictureBox1.BackgroundImage = PictureBox1.BackgroundImage
        ImagePrev.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Declaring stuff
        Dim cmd As OleDbCommand
        Dim img As New MemoryStream()
        Dim Imgdata() As Byte = {0, 0} 'To avoid that stupid NULL warning....
        Dim oldname As String = ImgDataGrid.Rows(ImgDataGrid.Rows.IndexOf(ImgDataGrid.SelectedRows.Item(0))).Cells(0).Value()
        Dim imagepath As String = EditTextBoxPath.Text

        'Get the image binary
        If imagepath = "No Change" Then
            For Each row As DataRow In DT.Rows
                If row(0) = oldname Then
                    Imgdata = row(1)
                    Exit For
                End If
            Next
        Else
            PictureBox1.BackgroundImage = Image.FromFile(EditTextBoxPath.Text)
            PictureBox1.BackgroundImage.Save(img, PictureBox1.BackgroundImage.RawFormat)
            Imgdata = img.GetBuffer()
        End If

        'Do the cmd
        cmd = New OleDbCommand("UPDATE Attach SET name = ?, image = ? where idx = " + eID.ToString + " and name = '" + oldname + "'", Con)
        Dim nme As New OleDbParameter
        Dim imgs As New OleDbParameter
        nme.Value = EditTextBoxName.Text
        imgs.Value = Imgdata
        cmd.Parameters.Add(nme)
        cmd.Parameters.Add(imgs)
        cmd.ExecuteNonQuery()

        'Edit data in the datagridview
        Dim idx As Integer = ImgDataGrid.Rows.IndexOf(ImgDataGrid.SelectedRows.Item(0))
        ImgDataGrid.Rows(idx).Cells(0).Value = EditTextBoxName.Text
        ImgDataGrid.Rows(idx).Cells(1).Value = Imgdata
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim newMargins As System.Drawing.Printing.Margins
        newMargins = New System.Drawing.Printing.Margins(0.2, 0.2, 0.2, 0.2)
        PrintDocument1.DefaultPageSettings.Margins = newMargins
        e.Graphics.DrawImage(PictureBox1.BackgroundImage, 0, 0, Convert.ToInt16(TextBox5.Text), Convert.ToInt16(TextBox6.Text))
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub مسحToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles مسحToolStripMenuItem.Click
        Dim idx As String = ImgDataGrid.SelectedCells.Item(0).RowIndex
        Nonreturn("DELETE FROM Attach Where idx = " + eID.ToString + " and name = '" + ImgDataGrid.Rows(idx).Cells(0).Value + "'")
        DT.Rows(ImgDataGrid.SelectedCells.Item(0).RowIndex).Delete()
    End Sub
End Class