<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SHS004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SHS004))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ItemCode = New System.Windows.Forms.TextBox
        Me.InvoiceNo = New System.Windows.Forms.TextBox
        Me.PopupItem = New System.Windows.Forms.Button
        Me.ItemName = New System.Windows.Forms.TextBox
        Me.ShipmentDataView = New System.Windows.Forms.DataGridView
        Me.ShipDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipReqNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemCd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemNm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BarcodeNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cusName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SearchScreen = New System.Windows.Forms.Button
        Me.ExportFile = New System.Windows.Forms.Button
        Me.ClearScreen = New System.Windows.Forms.Button
        Me.ExitScreen = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.SaveFileBox = New System.Windows.Forms.SaveFileDialog
        Me.infoLoginToday = New System.Windows.Forms.Label
        CType(Me.ShipmentDataView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Invoice No"
        '
        'ItemCode
        '
        Me.ItemCode.Location = New System.Drawing.Point(110, 41)
        Me.ItemCode.MaxLength = 50
        Me.ItemCode.Name = "ItemCode"
        Me.ItemCode.Size = New System.Drawing.Size(138, 22)
        Me.ItemCode.TabIndex = 2
        '
        'InvoiceNo
        '
        Me.InvoiceNo.Location = New System.Drawing.Point(110, 17)
        Me.InvoiceNo.MaxLength = 18
        Me.InvoiceNo.Name = "InvoiceNo"
        Me.InvoiceNo.Size = New System.Drawing.Size(138, 22)
        Me.InvoiceNo.TabIndex = 1
        '
        'PopupItem
        '
        Me.PopupItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.PopupItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PopupItem.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupItem.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.PopupItem.Location = New System.Drawing.Point(252, 41)
        Me.PopupItem.Name = "PopupItem"
        Me.PopupItem.Size = New System.Drawing.Size(24, 22)
        Me.PopupItem.TabIndex = 3
        Me.PopupItem.Text = "?"
        Me.PopupItem.UseVisualStyleBackColor = False
        '
        'ItemName
        '
        Me.ItemName.Location = New System.Drawing.Point(280, 41)
        Me.ItemName.MaxLength = 100
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(358, 22)
        Me.ItemName.TabIndex = 4
        '
        'ShipmentDataView
        '
        Me.ShipmentDataView.AllowUserToAddRows = False
        Me.ShipmentDataView.AllowUserToDeleteRows = False
        Me.ShipmentDataView.AllowUserToResizeRows = False
        Me.ShipmentDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ShipmentDataView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ShipmentDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ShipmentDataView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipDate, Me.ShipReqNo, Me.PalletNo, Me.ItemCd, Me.ItemNm, Me.Qty, Me.LotNo, Me.InvNo, Me.BarcodeNo, Me.cusName})
        Me.ShipmentDataView.Location = New System.Drawing.Point(13, 69)
        Me.ShipmentDataView.Name = "ShipmentDataView"
        Me.ShipmentDataView.ReadOnly = True
        Me.ShipmentDataView.RowHeadersVisible = False
        Me.ShipmentDataView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ShipmentDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ShipmentDataView.Size = New System.Drawing.Size(986, 252)
        Me.ShipmentDataView.TabIndex = 6
        '
        'ShipDate
        '
        Me.ShipDate.FillWeight = 75.0!
        Me.ShipDate.HeaderText = "Shipment Date"
        Me.ShipDate.Name = "ShipDate"
        Me.ShipDate.ReadOnly = True
        '
        'ShipReqNo
        '
        Me.ShipReqNo.FillWeight = 70.0!
        Me.ShipReqNo.HeaderText = "Shipment Request No"
        Me.ShipReqNo.Name = "ShipReqNo"
        Me.ShipReqNo.ReadOnly = True
        '
        'PalletNo
        '
        Me.PalletNo.FillWeight = 45.0!
        Me.PalletNo.HeaderText = "Pallet No"
        Me.PalletNo.Name = "PalletNo"
        Me.PalletNo.ReadOnly = True
        '
        'ItemCd
        '
        Me.ItemCd.FillWeight = 85.0!
        Me.ItemCd.HeaderText = "Item Code"
        Me.ItemCd.Name = "ItemCd"
        Me.ItemCd.ReadOnly = True
        '
        'ItemNm
        '
        Me.ItemNm.FillWeight = 120.0!
        Me.ItemNm.HeaderText = "Item Name"
        Me.ItemNm.Name = "ItemNm"
        Me.ItemNm.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.FillWeight = 45.0!
        Me.Qty.HeaderText = "Quantity"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'LotNo
        '
        Me.LotNo.FillWeight = 90.0!
        Me.LotNo.HeaderText = "Lot No"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        '
        'InvNo
        '
        Me.InvNo.FillWeight = 83.94668!
        Me.InvNo.HeaderText = "Invoice No"
        Me.InvNo.Name = "InvNo"
        Me.InvNo.ReadOnly = True
        '
        'BarcodeNo
        '
        Me.BarcodeNo.FillWeight = 90.0!
        Me.BarcodeNo.HeaderText = "Barcode No"
        Me.BarcodeNo.Name = "BarcodeNo"
        Me.BarcodeNo.ReadOnly = True
        '
        'cusName
        '
        Me.cusName.FillWeight = 82.0!
        Me.cusName.HeaderText = "Customer No"
        Me.cusName.Name = "cusName"
        Me.cusName.ReadOnly = True
        '
        'SearchScreen
        '
        Me.SearchScreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.SearchScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SearchScreen.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.SearchScreen.Location = New System.Drawing.Point(923, 41)
        Me.SearchScreen.Name = "SearchScreen"
        Me.SearchScreen.Size = New System.Drawing.Size(75, 22)
        Me.SearchScreen.TabIndex = 5
        Me.SearchScreen.Text = "Search"
        Me.SearchScreen.UseVisualStyleBackColor = False
        '
        'ExportFile
        '
        Me.ExportFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ExportFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExportFile.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ExportFile.Location = New System.Drawing.Point(756, 329)
        Me.ExportFile.Name = "ExportFile"
        Me.ExportFile.Size = New System.Drawing.Size(75, 22)
        Me.ExportFile.TabIndex = 7
        Me.ExportFile.Text = "Export"
        Me.ExportFile.UseVisualStyleBackColor = False
        '
        'ClearScreen
        '
        Me.ClearScreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ClearScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearScreen.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClearScreen.Location = New System.Drawing.Point(840, 329)
        Me.ClearScreen.Name = "ClearScreen"
        Me.ClearScreen.Size = New System.Drawing.Size(75, 22)
        Me.ClearScreen.TabIndex = 8
        Me.ClearScreen.Text = "Clear"
        Me.ClearScreen.UseVisualStyleBackColor = False
        '
        'ExitScreen
        '
        Me.ExitScreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ExitScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExitScreen.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ExitScreen.Location = New System.Drawing.Point(924, 329)
        Me.ExitScreen.Name = "ExitScreen"
        Me.ExitScreen.Size = New System.Drawing.Size(75, 22)
        Me.ExitScreen.TabIndex = 9
        Me.ExitScreen.Text = "Exit"
        Me.ExitScreen.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(71, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "*"
        '
        'infoLoginToday
        '
        Me.infoLoginToday.Location = New System.Drawing.Point(774, 2)
        Me.infoLoginToday.Name = "infoLoginToday"
        Me.infoLoginToday.Size = New System.Drawing.Size(224, 19)
        Me.infoLoginToday.TabIndex = 12
        Me.infoLoginToday.Text = "User Id: AAAAAA - Today: dd/MM/yyyy"
        Me.infoLoginToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SHS004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 360)
        Me.Controls.Add(Me.infoLoginToday)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ExitScreen)
        Me.Controls.Add(Me.ClearScreen)
        Me.Controls.Add(Me.ExportFile)
        Me.Controls.Add(Me.SearchScreen)
        Me.Controls.Add(Me.ShipmentDataView)
        Me.Controls.Add(Me.ItemName)
        Me.Controls.Add(Me.PopupItem)
        Me.Controls.Add(Me.InvoiceNo)
        Me.Controls.Add(Me.ItemCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "SHS004"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipment Inquiry By Invoice No"
        CType(Me.ShipmentDataView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ItemCode As System.Windows.Forms.TextBox
    Friend WithEvents InvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents PopupItem As System.Windows.Forms.Button
    Friend WithEvents ItemName As System.Windows.Forms.TextBox
    Friend WithEvents ShipmentDataView As System.Windows.Forms.DataGridView
    Friend WithEvents SearchScreen As System.Windows.Forms.Button
    Friend WithEvents ExportFile As System.Windows.Forms.Button
    Friend WithEvents ClearScreen As System.Windows.Forms.Button
    Friend WithEvents ExitScreen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SaveFileBox As System.Windows.Forms.SaveFileDialog
    Friend WithEvents infoLoginToday As System.Windows.Forms.Label
    Friend WithEvents ShipDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipReqNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemNm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarcodeNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cusName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
