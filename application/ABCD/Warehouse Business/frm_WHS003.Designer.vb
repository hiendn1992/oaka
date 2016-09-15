<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_WHS003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_WHS003))
        Me.ExportFile = New System.Windows.Forms.Button
        Me.CancelObject = New System.Windows.Forms.Button
        Me.ExitScreen = New System.Windows.Forms.Button
        Me.CurrentInfo = New System.Windows.Forms.Label
        Me.lbl_stock_in_out_date = New System.Windows.Forms.Label
        Me.sfDialog = New System.Windows.Forms.SaveFileDialog
        Me.BarcodeNo = New System.Windows.Forms.TextBox
        Me.ItemCode = New System.Windows.Forms.TextBox
        Me.lbl_item_cd = New System.Windows.Forms.Label
        Me.lbl_barcode_no = New System.Windows.Forms.Label
        Me.StatusCode = New System.Windows.Forms.ComboBox
        Me.lbl_status_flg = New System.Windows.Forms.Label
        Me.lbl_wh_cd = New System.Windows.Forms.Label
        Me.StartStockDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.EndStockDate = New System.Windows.Forms.DateTimePicker
        Me.WarehouseName = New System.Windows.Forms.TextBox
        Me.PopupItem = New System.Windows.Forms.Button
        Me.ItemName = New System.Windows.Forms.TextBox
        Me.WarehouseCode = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ExportFile
        '
        Me.ExportFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.ExportFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExportFile.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ExportFile.Location = New System.Drawing.Point(520, 169)
        Me.ExportFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ExportFile.Name = "ExportFile"
        Me.ExportFile.Size = New System.Drawing.Size(75, 22)
        Me.ExportFile.TabIndex = 8
        Me.ExportFile.Text = "Export"
        Me.ExportFile.UseVisualStyleBackColor = False
        '
        'CancelObject
        '
        Me.CancelObject.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.CancelObject.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CancelObject.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CancelObject.Location = New System.Drawing.Point(601, 169)
        Me.CancelObject.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CancelObject.Name = "CancelObject"
        Me.CancelObject.Size = New System.Drawing.Size(75, 22)
        Me.CancelObject.TabIndex = 9
        Me.CancelObject.Text = "Cancel"
        Me.CancelObject.UseVisualStyleBackColor = False
        '
        'ExitScreen
        '
        Me.ExitScreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.ExitScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExitScreen.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ExitScreen.Location = New System.Drawing.Point(682, 169)
        Me.ExitScreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ExitScreen.Name = "ExitScreen"
        Me.ExitScreen.Size = New System.Drawing.Size(75, 22)
        Me.ExitScreen.TabIndex = 10
        Me.ExitScreen.Text = "Exit"
        Me.ExitScreen.UseVisualStyleBackColor = False
        '
        'CurrentInfo
        '
        Me.CurrentInfo.AutoSize = True
        Me.CurrentInfo.Location = New System.Drawing.Point(526, 1)
        Me.CurrentInfo.Name = "CurrentInfo"
        Me.CurrentInfo.Size = New System.Drawing.Size(231, 14)
        Me.CurrentInfo.TabIndex = 22
        Me.CurrentInfo.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        '
        'lbl_stock_in_out_date
        '
        Me.lbl_stock_in_out_date.AutoSize = True
        Me.lbl_stock_in_out_date.Location = New System.Drawing.Point(14, 30)
        Me.lbl_stock_in_out_date.Name = "lbl_stock_in_out_date"
        Me.lbl_stock_in_out_date.Size = New System.Drawing.Size(114, 14)
        Me.lbl_stock_in_out_date.TabIndex = 31
        Me.lbl_stock_in_out_date.Text = "Stock IN/OUT Date" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'BarcodeNo
        '
        Me.BarcodeNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.BarcodeNo.Location = New System.Drawing.Point(143, 109)
        Me.BarcodeNo.MaxLength = 14
        Me.BarcodeNo.Name = "BarcodeNo"
        Me.BarcodeNo.Size = New System.Drawing.Size(112, 22)
        Me.BarcodeNo.TabIndex = 6
        '
        'ItemCode
        '
        Me.ItemCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ItemCode.Location = New System.Drawing.Point(143, 82)
        Me.ItemCode.MaxLength = 50
        Me.ItemCode.Name = "ItemCode"
        Me.ItemCode.Size = New System.Drawing.Size(198, 22)
        Me.ItemCode.TabIndex = 4
        '
        'lbl_item_cd
        '
        Me.lbl_item_cd.AutoSize = True
        Me.lbl_item_cd.Location = New System.Drawing.Point(14, 86)
        Me.lbl_item_cd.Name = "lbl_item_cd"
        Me.lbl_item_cd.Size = New System.Drawing.Size(33, 14)
        Me.lbl_item_cd.TabIndex = 53
        Me.lbl_item_cd.Text = "Item"
        '
        'lbl_barcode_no
        '
        Me.lbl_barcode_no.AutoSize = True
        Me.lbl_barcode_no.Location = New System.Drawing.Point(14, 111)
        Me.lbl_barcode_no.Name = "lbl_barcode_no"
        Me.lbl_barcode_no.Size = New System.Drawing.Size(70, 14)
        Me.lbl_barcode_no.TabIndex = 52
        Me.lbl_barcode_no.Text = "Barcode No" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'StatusCode
        '
        Me.StatusCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StatusCode.FormattingEnabled = True
        Me.StatusCode.Location = New System.Drawing.Point(143, 136)
        Me.StatusCode.Name = "StatusCode"
        Me.StatusCode.Size = New System.Drawing.Size(155, 22)
        Me.StatusCode.TabIndex = 7
        '
        'lbl_status_flg
        '
        Me.lbl_status_flg.AutoSize = True
        Me.lbl_status_flg.Location = New System.Drawing.Point(14, 138)
        Me.lbl_status_flg.Name = "lbl_status_flg"
        Me.lbl_status_flg.Size = New System.Drawing.Size(42, 14)
        Me.lbl_status_flg.TabIndex = 51
        Me.lbl_status_flg.Text = "Status"
        '
        'lbl_wh_cd
        '
        Me.lbl_wh_cd.AutoSize = True
        Me.lbl_wh_cd.Location = New System.Drawing.Point(14, 59)
        Me.lbl_wh_cd.Name = "lbl_wh_cd"
        Me.lbl_wh_cd.Size = New System.Drawing.Size(69, 14)
        Me.lbl_wh_cd.TabIndex = 44
        Me.lbl_wh_cd.Text = "Warehouse"
        '
        'StartStockDate
        '
        Me.StartStockDate.CustomFormat = "dd/MM/yyyy"
        Me.StartStockDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartStockDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.StartStockDate.Location = New System.Drawing.Point(143, 27)
        Me.StartStockDate.Name = "StartStockDate"
        Me.StartStockDate.Size = New System.Drawing.Size(145, 22)
        Me.StartStockDate.TabIndex = 1
        Me.StartStockDate.Value = New Date(2015, 1, 13, 8, 56, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(291, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 14)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "~"
        '
        'EndStockDate
        '
        Me.EndStockDate.CustomFormat = "dd/MM/yyyy"
        Me.EndStockDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndStockDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.EndStockDate.Location = New System.Drawing.Point(311, 27)
        Me.EndStockDate.Name = "EndStockDate"
        Me.EndStockDate.Size = New System.Drawing.Size(145, 22)
        Me.EndStockDate.TabIndex = 2
        Me.EndStockDate.Value = New Date(2015, 1, 13, 8, 56, 2, 0)
        '
        'WarehouseName
        '
        Me.WarehouseName.Location = New System.Drawing.Point(292, 55)
        Me.WarehouseName.MaxLength = 40
        Me.WarehouseName.Name = "WarehouseName"
        Me.WarehouseName.ReadOnly = True
        Me.WarehouseName.Size = New System.Drawing.Size(308, 22)
        Me.WarehouseName.TabIndex = 56
        '
        'PopupItem
        '
        Me.PopupItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.PopupItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PopupItem.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.PopupItem.Location = New System.Drawing.Point(347, 82)
        Me.PopupItem.Name = "PopupItem"
        Me.PopupItem.Size = New System.Drawing.Size(24, 22)
        Me.PopupItem.TabIndex = 5
        Me.PopupItem.Text = "?"
        Me.PopupItem.UseVisualStyleBackColor = False
        '
        'ItemName
        '
        Me.ItemName.Location = New System.Drawing.Point(377, 82)
        Me.ItemName.MaxLength = 100
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Size = New System.Drawing.Size(381, 22)
        Me.ItemName.TabIndex = 56
        '
        'WarehouseCode
        '
        Me.WarehouseCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WarehouseCode.FormattingEnabled = True
        Me.WarehouseCode.Location = New System.Drawing.Point(143, 55)
        Me.WarehouseCode.Name = "WarehouseCode"
        Me.WarehouseCode.Size = New System.Drawing.Size(145, 22)
        Me.WarehouseCode.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(124, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 14)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "*"
        '
        'frm_WHS003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 198)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.WarehouseCode)
        Me.Controls.Add(Me.ItemName)
        Me.Controls.Add(Me.PopupItem)
        Me.Controls.Add(Me.WarehouseName)
        Me.Controls.Add(Me.EndStockDate)
        Me.Controls.Add(Me.StartStockDate)
        Me.Controls.Add(Me.BarcodeNo)
        Me.Controls.Add(Me.ItemCode)
        Me.Controls.Add(Me.lbl_item_cd)
        Me.Controls.Add(Me.lbl_barcode_no)
        Me.Controls.Add(Me.StatusCode)
        Me.Controls.Add(Me.lbl_status_flg)
        Me.Controls.Add(Me.lbl_wh_cd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_stock_in_out_date)
        Me.Controls.Add(Me.CurrentInfo)
        Me.Controls.Add(Me.ExitScreen)
        Me.Controls.Add(Me.CancelObject)
        Me.Controls.Add(Me.ExportFile)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_WHS003"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock In Out History Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExportFile As System.Windows.Forms.Button
    Friend WithEvents CancelObject As System.Windows.Forms.Button
    Friend WithEvents ExitScreen As System.Windows.Forms.Button
    Friend WithEvents CurrentInfo As System.Windows.Forms.Label
    Friend WithEvents lbl_stock_in_out_date As System.Windows.Forms.Label
    Friend WithEvents sfDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BarcodeNo As System.Windows.Forms.TextBox
    Friend WithEvents ItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_item_cd As System.Windows.Forms.Label
    Friend WithEvents lbl_barcode_no As System.Windows.Forms.Label
    Friend WithEvents StatusCode As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_status_flg As System.Windows.Forms.Label
    Friend WithEvents lbl_wh_cd As System.Windows.Forms.Label
    Friend WithEvents StartStockDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EndStockDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents WarehouseName As System.Windows.Forms.TextBox
    Friend WithEvents PopupItem As System.Windows.Forms.Button
    Friend WithEvents ItemName As System.Windows.Forms.TextBox
    Friend WithEvents WarehouseCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
