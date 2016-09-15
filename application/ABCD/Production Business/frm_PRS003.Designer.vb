<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PRS003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PRS003))
        Me.lbToday = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btBrowse = New System.Windows.Forms.Button
        Me.tbCSVFile = New System.Windows.Forms.TextBox
        Me.tbTotal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbError = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbImport = New System.Windows.Forms.TextBox
        Me.btImport = New System.Windows.Forms.Button
        Me.btExit = New System.Windows.Forms.Button
        Me.ofDialog = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'lbToday
        '
        Me.lbToday.Location = New System.Drawing.Point(525, 2)
        Me.lbToday.Name = "lbToday"
        Me.lbToday.Size = New System.Drawing.Size(239, 19)
        Me.lbToday.TabIndex = 0
        Me.lbToday.Text = "User Id: XXXXXXXX - Today: dd/MM/yyyy"
        Me.lbToday.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CSV File"
        '
        'btBrowse
        '
        Me.btBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btBrowse.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btBrowse.Location = New System.Drawing.Point(608, 25)
        Me.btBrowse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btBrowse.Name = "btBrowse"
        Me.btBrowse.Size = New System.Drawing.Size(75, 22)
        Me.btBrowse.TabIndex = 2
        Me.btBrowse.Text = "Browse"
        Me.btBrowse.UseVisualStyleBackColor = False
        '
        'tbCSVFile
        '
        Me.tbCSVFile.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tbCSVFile.Location = New System.Drawing.Point(95, 25)
        Me.tbCSVFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbCSVFile.Name = "tbCSVFile"
        Me.tbCSVFile.Size = New System.Drawing.Size(507, 22)
        Me.tbCSVFile.TabIndex = 1
        '
        'tbTotal
        '
        Me.tbTotal.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tbTotal.Location = New System.Drawing.Point(95, 51)
        Me.tbTotal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(66, 22)
        Me.tbTotal.TabIndex = 3
        Me.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Total Record"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(228, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Import Record"
        '
        'tbError
        '
        Me.tbError.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tbError.Location = New System.Drawing.Point(536, 51)
        Me.tbError.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbError.Name = "tbError"
        Me.tbError.Size = New System.Drawing.Size(66, 22)
        Me.tbError.TabIndex = 5
        Me.tbError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(455, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Error Record"
        '
        'tbImport
        '
        Me.tbImport.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tbImport.Location = New System.Drawing.Point(320, 51)
        Me.tbImport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbImport.Name = "tbImport"
        Me.tbImport.Size = New System.Drawing.Size(66, 22)
        Me.tbImport.TabIndex = 4
        Me.tbImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btImport
        '
        Me.btImport.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btImport.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btImport.Location = New System.Drawing.Point(608, 91)
        Me.btImport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btImport.Name = "btImport"
        Me.btImport.Size = New System.Drawing.Size(75, 22)
        Me.btImport.TabIndex = 6
        Me.btImport.Text = "Import"
        Me.btImport.UseVisualStyleBackColor = False
        '
        'btExit
        '
        Me.btExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btExit.Location = New System.Drawing.Point(689, 91)
        Me.btExit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(75, 22)
        Me.btExit.TabIndex = 7
        Me.btExit.Text = "Exit"
        Me.btExit.UseVisualStyleBackColor = False
        '
        'ofDialog
        '
        Me.ofDialog.FileName = "OpenFileDialog1"
        '
        'frm_PRS003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 124)
        Me.Controls.Add(Me.btExit)
        Me.Controls.Add(Me.btImport)
        Me.Controls.Add(Me.tbImport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbError)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbTotal)
        Me.Controls.Add(Me.tbCSVFile)
        Me.Controls.Add(Me.btBrowse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbToday)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_PRS003"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Production Information Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbToday As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btBrowse As System.Windows.Forms.Button
    Friend WithEvents tbCSVFile As System.Windows.Forms.TextBox
    Friend WithEvents tbTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbError As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbImport As System.Windows.Forms.TextBox
    Friend WithEvents btImport As System.Windows.Forms.Button
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents ofDialog As System.Windows.Forms.OpenFileDialog
End Class
