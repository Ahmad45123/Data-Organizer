Public Class StartupForm

    Public Table As New List(Of TableDataHandler.tblclm)
    Public Groups As New List(Of TableDataHandler.grps)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DBConn.Nonreturn("SET DATEFORMAT dmy")
        If SettingsHandler.IsFirstRun = False Then
            Dim InputPassword As String = InputBox("Password : ")
            If Base64fPassHandler.CompareText(InputPassword, SettingsHandler.GetPassword()) = True Then
                TableDataHandler.ReadData()
                MainForm.Show()
                Me.Close()

            Else
                MsgBox("Access Denied !", MsgBoxStyle.Exclamation)
                Me.Close()
            End If
        Else
            clmComboBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("You can edit the connection details by opening the file 'Conn.udl'", MsgBoxStyle.Information)
    End Sub

    Private Sub cmbAddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAddButton.Click
        If clmComboBox.SelectedIndex = 0 Then
            clmListBox.Items.Add(clmTextBox.Text + " - Text/Num")
            Dim tempClm As New TableDataHandler.tblclm
            tempClm.Title = clmTextBox.Text
            tempClm.Type = 0
            tempClm.IsSortAble = -1
            Table.Add(tempClm)

        ElseIf clmComboBox.SelectedIndex = 1 Then
            clmListBox.Items.Add(clmTextBox.Text + " - Date")
            Dim tempClm As New TableDataHandler.tblclm
            tempClm.Title = clmTextBox.Text
            tempClm.Type = 1
            tempClm.IsSortAble = InputBox("Do you wanna add this coloumn to sorting system ?" & vbCrLf & vbCrLf & "No = 0| Yes = 1", "Sort ?", 0)
            Table.Add(tempClm)

        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim tmpname() As String = clmListBox.SelectedItem.ToString.Split("-".ToCharArray, 2)
        Dim name As String = tmpname(0)
        name = name.Remove(name.Count - 1, 1)
        For Each Clm As TableDataHandler.tblclm In Table
            If Clm.Title = name Then
                Table.RemoveAt(Table.IndexOf(Clm))
                Exit For
            End If
        Next

        clmListBox.Items.RemoveAt(clmListBox.SelectedIndex)
    End Sub

    Public Function DecodeColorFromString(ByVal clr As String)
        Dim output As Color
        Dim color As New ColorConverter
        output = color.ConvertFromString(clr)
        Return output
    End Function

    Public Function EncodeColorToString(ByVal clr As Color)
        Dim output As String
        Dim color As New ColorConverter
        output = color.ConvertToString(clr)
        Return output
    End Function

    Private Sub Finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click, Button3.Click, Button2.Click, Button8.Click
        If AppNametext.Text = "" Or AppPassText.Text = Nothing Or grpListBox.Items.Count - 1 <= 0 Or clmListBox.Items.Count - 1 <= 0 Then
            MsgBox("Please review all the data")
            Exit Sub
        End If

        SettingsHandler.EditName(AppNametext.Text)
        SettingsHandler.EditPassword(AppPassText.Text)
        SettingsHandler.SetAttachmentsOption(CheckBox1.Checked)

        Dim query As String = "CREATE TABLE Data([id] [int] NOT NULL Identity(1, 1) PRIMARY KEY, "

        Dim clms As String = Nothing
        For Each clm As TableDataHandler.tblclm In Table
            clms = clms + "|" + clm.Title + "(" + clm.Type.ToString + "," + clm.IsSortAble.ToString + ")"

            'Creating the query
            Dim title2 As String = clm.Title.Replace(" ", "_")
            If clm.Type = 0 Then
                query = query + title2 + " nvarchar(100), "
            Else
                query = query + title2 + " date, "
            End If
        Next
        query = query + "Grp int);" 'Finishing the query
        clms = clms.Substring(1)

        SettingsHandler.EditTableColoumns(clms)
        SettingsHandler.FirstRunFinsihed()
        DBConn.Nonreturn(query) 'Create the DB

        'Creating the groups
        Dim n As Integer = 0
        For Each grp As TableDataHandler.grps In Groups
            Dim colortext As String = EncodeColorToString(grp.color)
            DBConn.Nonreturn("INSERT INTO Groups Values(" + n.ToString + ", '" + grp.gname + "', '" + colortext + "')")
            n = n + 1
        Next

        MsgBox("Program has been configured successfully !", MsgBoxStyle.Information)
        MsgBox("The app will close, You may rerun it.", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim ColorDialog As New ColorDialog
        ColorDialog.ShowDialog()

        grpColorPicture.BackColor = ColorDialog.Color
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        grpListBox.Items.Add(grpNameTextBox.Text + " - " + grpColorPicture.BackColor.G.ToString + grpColorPicture.BackColor.R.ToString + grpColorPicture.BackColor.B.ToString + grpColorPicture.BackColor.A.ToString)
        Dim grp As New TableDataHandler.grps
        grp.gname = grpNameTextBox.Text
        grp.color = grpColorPicture.BackColor
        Groups.Add(grp)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim tmpname() As String = grpListBox.SelectedItem.ToString.Split(" - ".ToCharArray)
        Dim name As String = tmpname(0)

        For Each grp As TableDataHandler.grps In Groups
            If grp.gname = name Then
                Groups.RemoveAt(Groups.IndexOf(grp))
                Exit For
            End If
        Next

        grpListBox.Items.RemoveAt(grpListBox.SelectedIndex)
    End Sub
End Class
