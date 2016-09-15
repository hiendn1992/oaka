<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_STS003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_STS003))
        Me.lbToday = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbStockDate = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbWarehouseCode = New System.Windows.Forms.Label
        Me.lbItemCode = New System.Windows.Forms.Label
        Me.btPrint = New System.Windows.Forms.Button
        Me.btExit = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbWarehouseName = New System.Windows.Forms.Label
        Me.lbItemName = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'lbToday
        '
        Me.lbToday.Location = New System.Drawing.Point(528, 2)
        Me.lbToday.Name = "lbToday"
        Me.lbToday.Size = New System.Drawing.Size(236, 18)
        Me.lbToday.TabIndex = 0
        Me.lbToday.Text = "User Id: XXXXXXXX - Today: dd/MM/yyyy"
        Me.lbToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Stocktaking Date:"
        '
        'lbStockDate
        '
        Me.lbStockDate.AutoSize = True
        Me.lbStockDate.Location = New System.Drawing.Point(145, 26)
        Me.lbStockDate.Name = "lbStockDate"
        Me.lbStockDate.Size = New System.Drawing.Size(73, 14)
        Me.lbStockDate.TabIndex = 2
        Me.lbStockDate.Text = "dd/MM/yyyy"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Warehouse:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Item:"
        '
        'lbWarehouseCode
        '
        Me.lbWarehouseCode.AutoSize = True
        Me.lbWarehouseCode.Location = New System.Drawing.Point(145, 67)
        Me.lbWarehouseCode.Name = "lbWarehouseCode"
        Me.lbWarehouseCode.Size = New System.Drawing.Size(63, 14)
        Me.lbWarehouseCode.TabIndex = 5
        Me.lbWarehouseCode.Text = "XXXXXXXX"
        '
        'lbItemCode
        '
        Me.lbItemCode.AutoSize = True
        Me.lbItemCode.Location = New System.Drawing.Point(145, 47)
        Me.lbItemCode.Name = "lbItemCode"
        Me.lbItemCode.Size = New System.Drawing.Size(182, 14)
        Me.lbItemCode.TabIndex = 6
        Me.lbItemCode.Text = "0123456789012345678901234"
        '
        'btPrint
        '
        Me.btPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btPrint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btPrint.Location = New System.Drawing.Point(608, 91)
        Me.btPrint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(75, 22)
        Me.btPrint.TabIndex = 7
        Me.btPrint.Text = "Print"
        Me.btPrint.UseVisualStyleBackColor = False
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
        Me.btExit.TabIndex = 8
        Me.btExit.Text = "Exit"
        Me.btExit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(333, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "|"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(333, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "|"
        '
        'lbWarehouseName
        '
        Me.lbWarehouseName.AutoSize = True
        Me.lbWarehouseName.Location = New System.Drawing.Point(351, 67)
        Me.lbWarehouseName.Name = "lbWarehouseName"
        Me.lbWarehouseName.Size = New System.Drawing.Size(175, 14)
        Me.lbWarehouseName.TabIndex = 11
        Me.lbWarehouseName.Text = "AAAAAAAAAAAAAAAAAAAAA"
        '
        'lbItemName
        '
        Me.lbItemName.AutoSize = True
        Me.lbItemName.Location = New System.Drawing.Point(351, 47)
        Me.lbItemName.Name = "lbItemName"
        Me.lbItemName.Size = New System.Drawing.Size(357, 14)
        Me.lbItemName.TabIndex = 12
        Me.lbItemName.Text = "01234567890123456789012340123456789012345678901234"
        '
        'frm_STS003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 124)
        Me.Controls.Add(Me.lbItemName)
        Me.Controls.Add(Me.lbWarehouseName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btExit)
        Me.Controls.Add(Me.btPrint)
        Me.Controls.Add(Me.lbItemCode)
        Me.Controls.Add(Me.lbWarehouseCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbStockDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbToday)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_STS003"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stocktaking Result Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbToday As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbStockDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbWarehouseCode As System.Windows.Forms.Label
    Friend WithEvents lbItemCode As System.Windows.Forms.Label
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbWarehouseName As System.Windows.Forms.Label
    Friend WithEvents lbItemName As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
