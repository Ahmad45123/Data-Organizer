<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Attach
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ImgDataGrid = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AddNameTextBox = New System.Windows.Forms.TextBox()
        Me.AddGroupBox = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AddPathTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EditGroupBox = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.EditTextBoxPath = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EditTextBoxName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.مسحToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ImgDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AddGroupBox.SuspendLayout()
        Me.EditGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImgDataGrid
        '
        Me.ImgDataGrid.AllowUserToAddRows = False
        Me.ImgDataGrid.AllowUserToDeleteRows = False
        Me.ImgDataGrid.AllowUserToOrderColumns = True
        Me.ImgDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ImgDataGrid.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ImgDataGrid.Location = New System.Drawing.Point(12, 118)
        Me.ImgDataGrid.Name = "ImgDataGrid"
        Me.ImgDataGrid.ReadOnly = True
        Me.ImgDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ImgDataGrid.Size = New System.Drawing.Size(670, 349)
        Me.ImgDataGrid.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(147, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "الإسم :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'AddNameTextBox
        '
        Me.AddNameTextBox.Location = New System.Drawing.Point(6, 13)
        Me.AddNameTextBox.Name = "AddNameTextBox"
        Me.AddNameTextBox.Size = New System.Drawing.Size(135, 20)
        Me.AddNameTextBox.TabIndex = 3
        '
        'AddGroupBox
        '
        Me.AddGroupBox.Controls.Add(Me.Button2)
        Me.AddGroupBox.Controls.Add(Me.AddPathTextBox)
        Me.AddGroupBox.Controls.Add(Me.Button1)
        Me.AddGroupBox.Controls.Add(Me.Label2)
        Me.AddGroupBox.Controls.Add(Me.AddNameTextBox)
        Me.AddGroupBox.Controls.Add(Me.Label1)
        Me.AddGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.AddGroupBox.Name = "AddGroupBox"
        Me.AddGroupBox.Size = New System.Drawing.Size(195, 100)
        Me.AddGroupBox.TabIndex = 4
        Me.AddGroupBox.TabStop = False
        Me.AddGroupBox.Text = "إضافة"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 68)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "تم"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AddPathTextBox
        '
        Me.AddPathTextBox.Location = New System.Drawing.Point(41, 42)
        Me.AddPathTextBox.Name = "AddPathTextBox"
        Me.AddPathTextBox.ReadOnly = True
        Me.AddPathTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AddPathTextBox.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(143, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "المسار :"
        '
        'EditGroupBox
        '
        Me.EditGroupBox.Controls.Add(Me.Button3)
        Me.EditGroupBox.Controls.Add(Me.EditTextBoxPath)
        Me.EditGroupBox.Controls.Add(Me.Button4)
        Me.EditGroupBox.Controls.Add(Me.Label3)
        Me.EditGroupBox.Controls.Add(Me.EditTextBoxName)
        Me.EditGroupBox.Controls.Add(Me.Label4)
        Me.EditGroupBox.Enabled = False
        Me.EditGroupBox.Location = New System.Drawing.Point(213, 12)
        Me.EditGroupBox.Name = "EditGroupBox"
        Me.EditGroupBox.Size = New System.Drawing.Size(195, 100)
        Me.EditGroupBox.TabIndex = 6
        Me.EditGroupBox.TabStop = False
        Me.EditGroupBox.Text = "تعديل"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 68)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "حفظ"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'EditTextBoxPath
        '
        Me.EditTextBoxPath.Location = New System.Drawing.Point(41, 42)
        Me.EditTextBoxPath.Name = "EditTextBoxPath"
        Me.EditTextBoxPath.ReadOnly = True
        Me.EditTextBoxPath.Size = New System.Drawing.Size(100, 20)
        Me.EditTextBoxPath.TabIndex = 5
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 40)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 23)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(143, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "المسار :"
        '
        'EditTextBoxName
        '
        Me.EditTextBoxName.Location = New System.Drawing.Point(6, 13)
        Me.EditTextBoxName.Name = "EditTextBoxName"
        Me.EditTextBoxName.Size = New System.Drawing.Size(135, 20)
        Me.EditTextBoxName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(147, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "الإسم :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(414, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 100)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "طباعة"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(10, 68)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(83, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "طباعة المحدد"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(10, 39)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 20)
        Me.TextBox6.TabIndex = 3
        Me.TextBox6.Text = "297"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(116, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "الطول :"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(10, 13)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 1
        Me.TextBox5.Text = "210"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(116, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "العرض :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(582, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "أنقر مرتين علي الصورة لمعاينة أكبر"
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.مسحToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'مسحToolStripMenuItem
        '
        Me.مسحToolStripMenuItem.Name = "مسحToolStripMenuItem"
        Me.مسحToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.مسحToolStripMenuItem.Text = "مسح"
        '
        'Attach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 479)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.EditGroupBox)
        Me.Controls.Add(Me.AddGroupBox)
        Me.Controls.Add(Me.ImgDataGrid)
        Me.Name = "Attach"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "المرفقات"
        CType(Me.ImgDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AddGroupBox.ResumeLayout(False)
        Me.AddGroupBox.PerformLayout()
        Me.EditGroupBox.ResumeLayout(False)
        Me.EditGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AddGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AddPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents EditGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents EditTextBoxPath As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EditTextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents مسحToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
