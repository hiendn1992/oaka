<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SHS001
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SHS001))
        Me.lb_today = New System.Windows.Forms.Label
        Me.rdo_add = New System.Windows.Forms.RadioButton
        Me.rdo_chg = New System.Windows.Forms.RadioButton
        Me.rdo_del = New System.Windows.Forms.RadioButton
        Me.txt_shipment_req_no = New System.Windows.Forms.TextBox
        Me.txt_customer_cd = New System.Windows.Forms.TextBox
        Me.btn_customer_cd = New System.Windows.Forms.Button
        Me.txt_customer_name = New System.Windows.Forms.TextBox
        Me.lbl_shipment_req_no = New System.Windows.Forms.Label
        Me.lbl_customer_cd = New System.Windows.Forms.Label
        Me.lbl_shipment_req_date = New System.Windows.Forms.Label
        Me.btn_execute = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.dat_shipment_req_date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_export = New System.Windows.Forms.Button
        Me.btn_shipment = New System.Windows.Forms.Button
        Me.lbl_shipment_status = New System.Windows.Forms.Label
        Me.lbl_shipment_date = New System.Windows.Forms.Label
        Me.dat_shipment_date = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_po_no = New System.Windows.Forms.TextBox
        Me.lbl_po_no = New System.Windows.Forms.Label
        Me.txt_invoice_no = New System.Windows.Forms.TextBox
        Me.lbl_invoice_no = New System.Windows.Forms.Label
        Me.lbl_invoice_date = New System.Windows.Forms.Label
        Me.dat_invoice_date = New System.Windows.Forms.DateTimePicker
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_add = New System.Windows.Forms.Button
        Me.grd_ship_list = New System.Windows.Forms.DataGridView
        Me.col_chk = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.col_pallet_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_barcode_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_lot_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_rack_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_wh_cd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_item_cd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_item_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_scan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_select_all = New System.Windows.Forms.Button
        Me.btn_unselect_all = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.sfDialog = New System.Windows.Forms.SaveFileDialog
        Me.btn_shipment_req_no = New System.Windows.Forms.Button
        Me.btn_custom_export = New System.Windows.Forms.Button
        CType(Me.grd_ship_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Location = New System.Drawing.Point(605, 2)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(270, 15)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX  |  Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rdo_add
        '
        Me.rdo_add.AutoSize = True
        Me.rdo_add.Location = New System.Drawing.Point(12, 21)
        Me.rdo_add.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdo_add.Name = "rdo_add"
        Me.rdo_add.Size = New System.Drawing.Size(47, 18)
        Me.rdo_add.TabIndex = 1
        Me.rdo_add.Text = "Add"
        Me.rdo_add.UseVisualStyleBackColor = True
        '
        'rdo_chg
        '
        Me.rdo_chg.AutoSize = True
        Me.rdo_chg.Location = New System.Drawing.Point(65, 21)
        Me.rdo_chg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdo_chg.Name = "rdo_chg"
        Me.rdo_chg.Size = New System.Drawing.Size(66, 18)
        Me.rdo_chg.TabIndex = 2
        Me.rdo_chg.Text = "Change"
        Me.rdo_chg.UseVisualStyleBackColor = True
        '
        'rdo_del
        '
        Me.rdo_del.AutoSize = True
        Me.rdo_del.Location = New System.Drawing.Point(137, 21)
        Me.rdo_del.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdo_del.Name = "rdo_del"
        Me.rdo_del.Size = New System.Drawing.Size(61, 18)
        Me.rdo_del.TabIndex = 3
        Me.rdo_del.Text = "Delete"
        Me.rdo_del.UseVisualStyleBackColor = True
        '
        'txt_shipment_req_no
        '
        Me.txt_shipment_req_no.Enabled = False
        Me.txt_shipment_req_no.Location = New System.Drawing.Point(137, 43)
        Me.txt_shipment_req_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_shipment_req_no.MaxLength = 10
        Me.txt_shipment_req_no.Name = "txt_shipment_req_no"
        Me.txt_shipment_req_no.Size = New System.Drawing.Size(131, 22)
        Me.txt_shipment_req_no.TabIndex = 4
        '
        'txt_customer_cd
        '
        Me.txt_customer_cd.Location = New System.Drawing.Point(137, 95)
        Me.txt_customer_cd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_customer_cd.MaxLength = 10
        Me.txt_customer_cd.Name = "txt_customer_cd"
        Me.txt_customer_cd.Size = New System.Drawing.Size(131, 22)
        Me.txt_customer_cd.TabIndex = 8
        '
        'btn_customer_cd
        '
        Me.btn_customer_cd.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_customer_cd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_customer_cd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_customer_cd.Location = New System.Drawing.Point(274, 95)
        Me.btn_customer_cd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_customer_cd.Name = "btn_customer_cd"
        Me.btn_customer_cd.Size = New System.Drawing.Size(24, 22)
        Me.btn_customer_cd.TabIndex = 9
        Me.btn_customer_cd.Text = "?"
        Me.btn_customer_cd.UseVisualStyleBackColor = False
        '
        'txt_customer_name
        '
        Me.txt_customer_name.Location = New System.Drawing.Point(307, 96)
        Me.txt_customer_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_customer_name.MaxLength = 50
        Me.txt_customer_name.Name = "txt_customer_name"
        Me.txt_customer_name.ReadOnly = True
        Me.txt_customer_name.Size = New System.Drawing.Size(298, 22)
        Me.txt_customer_name.TabIndex = 4
        Me.txt_customer_name.TabStop = False
        '
        'lbl_shipment_req_no
        '
        Me.lbl_shipment_req_no.AutoSize = True
        Me.lbl_shipment_req_no.Location = New System.Drawing.Point(9, 46)
        Me.lbl_shipment_req_no.Name = "lbl_shipment_req_no"
        Me.lbl_shipment_req_no.Size = New System.Drawing.Size(103, 14)
        Me.lbl_shipment_req_no.TabIndex = 9
        Me.lbl_shipment_req_no.Text = "Shipment Req No" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbl_customer_cd
        '
        Me.lbl_customer_cd.AutoSize = True
        Me.lbl_customer_cd.Location = New System.Drawing.Point(9, 98)
        Me.lbl_customer_cd.Name = "lbl_customer_cd"
        Me.lbl_customer_cd.Size = New System.Drawing.Size(59, 14)
        Me.lbl_customer_cd.TabIndex = 10
        Me.lbl_customer_cd.Text = "Customer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbl_shipment_req_date
        '
        Me.lbl_shipment_req_date.AutoSize = True
        Me.lbl_shipment_req_date.Location = New System.Drawing.Point(9, 72)
        Me.lbl_shipment_req_date.Name = "lbl_shipment_req_date"
        Me.lbl_shipment_req_date.Size = New System.Drawing.Size(114, 14)
        Me.lbl_shipment_req_date.TabIndex = 12
        Me.lbl_shipment_req_date.Text = "Shipment Req Date"
        '
        'btn_execute
        '
        Me.btn_execute.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_execute.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_execute.Location = New System.Drawing.Point(476, 477)
        Me.btn_execute.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_execute.Name = "btn_execute"
        Me.btn_execute.Size = New System.Drawing.Size(75, 22)
        Me.btn_execute.TabIndex = 19
        Me.btn_execute.Text = "Execute"
        Me.btn_execute.UseVisualStyleBackColor = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_cancel.Location = New System.Drawing.Point(719, 477)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 22)
        Me.btn_cancel.TabIndex = 22
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(800, 477)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 23
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'dat_shipment_req_date
        '
        Me.dat_shipment_req_date.Cursor = System.Windows.Forms.Cursors.Default
        Me.dat_shipment_req_date.CustomFormat = "dd/MM/yyyy"
        Me.dat_shipment_req_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dat_shipment_req_date.Location = New System.Drawing.Point(137, 69)
        Me.dat_shipment_req_date.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dat_shipment_req_date.Name = "dat_shipment_req_date"
        Me.dat_shipment_req_date.Size = New System.Drawing.Size(131, 22)
        Me.dat_shipment_req_date.TabIndex = 6
        Me.dat_shipment_req_date.Value = New Date(2015, 1, 13, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(108, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 14)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(67, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 14)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(119, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 14)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "*"
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_export.Location = New System.Drawing.Point(557, 477)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 22)
        Me.btn_export.TabIndex = 20
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_shipment
        '
        Me.btn_shipment.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_shipment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_shipment.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_shipment.Location = New System.Drawing.Point(638, 477)
        Me.btn_shipment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_shipment.Name = "btn_shipment"
        Me.btn_shipment.Size = New System.Drawing.Size(75, 22)
        Me.btn_shipment.TabIndex = 21
        Me.btn_shipment.Text = "Shipment"
        Me.btn_shipment.UseVisualStyleBackColor = False
        '
        'lbl_shipment_status
        '
        Me.lbl_shipment_status.AutoSize = True
        Me.lbl_shipment_status.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shipment_status.Location = New System.Drawing.Point(314, 46)
        Me.lbl_shipment_status.Name = "lbl_shipment_status"
        Me.lbl_shipment_status.Size = New System.Drawing.Size(257, 14)
        Me.lbl_shipment_status.TabIndex = 0
        Me.lbl_shipment_status.Text = "Shipment Status:  Complete/Incomplete" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbl_shipment_date
        '
        Me.lbl_shipment_date.AutoSize = True
        Me.lbl_shipment_date.Location = New System.Drawing.Point(314, 72)
        Me.lbl_shipment_date.Name = "lbl_shipment_date"
        Me.lbl_shipment_date.Size = New System.Drawing.Size(89, 14)
        Me.lbl_shipment_date.TabIndex = 12
        Me.lbl_shipment_date.Text = "Shipment Date" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dat_shipment_date
        '
        Me.dat_shipment_date.Cursor = System.Windows.Forms.Cursors.Default
        Me.dat_shipment_date.CustomFormat = "dd/MM/yyyy"
        Me.dat_shipment_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dat_shipment_date.Location = New System.Drawing.Point(419, 69)
        Me.dat_shipment_date.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dat_shipment_date.Name = "dat_shipment_date"
        Me.dat_shipment_date.Size = New System.Drawing.Size(131, 22)
        Me.dat_shipment_date.TabIndex = 7
        Me.dat_shipment_date.Value = New Date(2015, 1, 13, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(399, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 14)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "*"
        '
        'txt_po_no
        '
        Me.txt_po_no.Location = New System.Drawing.Point(137, 121)
        Me.txt_po_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_po_no.MaxLength = 20
        Me.txt_po_no.Name = "txt_po_no"
        Me.txt_po_no.Size = New System.Drawing.Size(131, 22)
        Me.txt_po_no.TabIndex = 10
        '
        'lbl_po_no
        '
        Me.lbl_po_no.AutoSize = True
        Me.lbl_po_no.Location = New System.Drawing.Point(9, 124)
        Me.lbl_po_no.Name = "lbl_po_no"
        Me.lbl_po_no.Size = New System.Drawing.Size(79, 14)
        Me.lbl_po_no.TabIndex = 10
        Me.lbl_po_no.Text = "Customer PO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txt_invoice_no
        '
        Me.txt_invoice_no.Location = New System.Drawing.Point(137, 147)
        Me.txt_invoice_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_invoice_no.MaxLength = 18
        Me.txt_invoice_no.Name = "txt_invoice_no"
        Me.txt_invoice_no.Size = New System.Drawing.Size(131, 22)
        Me.txt_invoice_no.TabIndex = 11
        '
        'lbl_invoice_no
        '
        Me.lbl_invoice_no.AutoSize = True
        Me.lbl_invoice_no.Location = New System.Drawing.Point(9, 150)
        Me.lbl_invoice_no.Name = "lbl_invoice_no"
        Me.lbl_invoice_no.Size = New System.Drawing.Size(65, 14)
        Me.lbl_invoice_no.TabIndex = 10
        Me.lbl_invoice_no.Text = "Invoice No" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbl_invoice_date
        '
        Me.lbl_invoice_date.AutoSize = True
        Me.lbl_invoice_date.Location = New System.Drawing.Point(314, 124)
        Me.lbl_invoice_date.Name = "lbl_invoice_date"
        Me.lbl_invoice_date.Size = New System.Drawing.Size(76, 14)
        Me.lbl_invoice_date.TabIndex = 12
        Me.lbl_invoice_date.Text = "Invoice Date" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'dat_invoice_date
        '
        Me.dat_invoice_date.Cursor = System.Windows.Forms.Cursors.Default
        Me.dat_invoice_date.CustomFormat = "dd/MM/yyyy"
        Me.dat_invoice_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dat_invoice_date.Location = New System.Drawing.Point(419, 121)
        Me.dat_invoice_date.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dat_invoice_date.Name = "dat_invoice_date"
        Me.dat_invoice_date.Size = New System.Drawing.Size(131, 22)
        Me.dat_invoice_date.TabIndex = 12
        Me.dat_invoice_date.Value = New Date(2015, 1, 13, 0, 0, 0, 0)
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_delete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_delete.Location = New System.Drawing.Point(253, 452)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(75, 22)
        Me.btn_delete.TabIndex = 18
        Me.btn_delete.TabStop = False
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'btn_add
        '
        Me.btn_add.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_add.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_add.Location = New System.Drawing.Point(172, 452)
        Me.btn_add.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 22)
        Me.btn_add.TabIndex = 17
        Me.btn_add.TabStop = False
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = False
        '
        'grd_ship_list
        '
        Me.grd_ship_list.AllowUserToAddRows = False
        Me.grd_ship_list.AllowUserToDeleteRows = False
        Me.grd_ship_list.AllowUserToResizeRows = False
        Me.grd_ship_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_ship_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_ship_list.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_chk, Me.col_pallet_no, Me.col_barcode_no, Me.col_lot_no, Me.col_rack_no, Me.col_wh_cd, Me.col_item_cd, Me.col_item_name, Me.col_quantity, Me.col_scan})
        Me.grd_ship_list.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.grd_ship_list.Location = New System.Drawing.Point(10, 186)
        Me.grd_ship_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grd_ship_list.MultiSelect = False
        Me.grd_ship_list.Name = "grd_ship_list"
        Me.grd_ship_list.RowHeadersVisible = False
        Me.grd_ship_list.RowTemplate.Height = 24
        Me.grd_ship_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_ship_list.Size = New System.Drawing.Size(865, 254)
        Me.grd_ship_list.TabIndex = 14
        '
        'col_chk
        '
        Me.col_chk.FalseValue = "False"
        Me.col_chk.FillWeight = 15.0!
        Me.col_chk.HeaderText = ""
        Me.col_chk.Name = "col_chk"
        Me.col_chk.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.col_chk.TrueValue = "True"
        Me.col_chk.Width = 33
        '
        'col_pallet_no
        '
        Me.col_pallet_no.FillWeight = 30.0!
        Me.col_pallet_no.HeaderText = "Pallet No"
        Me.col_pallet_no.Name = "col_pallet_no"
        Me.col_pallet_no.ReadOnly = True
        Me.col_pallet_no.Width = 66
        '
        'col_barcode_no
        '
        Me.col_barcode_no.FillWeight = 53.63805!
        Me.col_barcode_no.HeaderText = "Barcode No"
        Me.col_barcode_no.Name = "col_barcode_no"
        Me.col_barcode_no.ReadOnly = True
        Me.col_barcode_no.Width = 119
        '
        'col_lot_no
        '
        Me.col_lot_no.FillWeight = 53.63805!
        Me.col_lot_no.HeaderText = "Lot No"
        Me.col_lot_no.Name = "col_lot_no"
        Me.col_lot_no.ReadOnly = True
        Me.col_lot_no.Width = 118
        '
        'col_rack_no
        '
        Me.col_rack_no.FillWeight = 30.0!
        Me.col_rack_no.HeaderText = "Rack No"
        Me.col_rack_no.Name = "col_rack_no"
        Me.col_rack_no.ReadOnly = True
        Me.col_rack_no.Width = 66
        '
        'col_wh_cd
        '
        Me.col_wh_cd.FillWeight = 40.0!
        Me.col_wh_cd.HeaderText = "Warehouse Code"
        Me.col_wh_cd.Name = "col_wh_cd"
        Me.col_wh_cd.ReadOnly = True
        Me.col_wh_cd.Width = 89
        '
        'col_item_cd
        '
        Me.col_item_cd.FillWeight = 53.63805!
        Me.col_item_cd.HeaderText = "Item Code"
        Me.col_item_cd.Name = "col_item_cd"
        Me.col_item_cd.ReadOnly = True
        Me.col_item_cd.Width = 118
        '
        'col_item_name
        '
        Me.col_item_name.FillWeight = 53.63805!
        Me.col_item_name.HeaderText = "Item Name"
        Me.col_item_name.Name = "col_item_name"
        Me.col_item_name.ReadOnly = True
        Me.col_item_name.Width = 119
        '
        'col_quantity
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.col_quantity.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_quantity.FillWeight = 40.0!
        Me.col_quantity.HeaderText = "Quantity"
        Me.col_quantity.Name = "col_quantity"
        Me.col_quantity.ReadOnly = True
        Me.col_quantity.Width = 88
        '
        'col_scan
        '
        Me.col_scan.FillWeight = 20.0!
        Me.col_scan.HeaderText = "Scan"
        Me.col_scan.Name = "col_scan"
        Me.col_scan.ReadOnly = True
        Me.col_scan.Width = 44
        '
        'btn_select_all
        '
        Me.btn_select_all.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_select_all.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_select_all.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_select_all.Location = New System.Drawing.Point(10, 452)
        Me.btn_select_all.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_select_all.Name = "btn_select_all"
        Me.btn_select_all.Size = New System.Drawing.Size(75, 22)
        Me.btn_select_all.TabIndex = 15
        Me.btn_select_all.TabStop = False
        Me.btn_select_all.Text = "Select All"
        Me.btn_select_all.UseVisualStyleBackColor = False
        '
        'btn_unselect_all
        '
        Me.btn_unselect_all.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_unselect_all.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_unselect_all.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_unselect_all.Location = New System.Drawing.Point(91, 452)
        Me.btn_unselect_all.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_unselect_all.Name = "btn_unselect_all"
        Me.btn_unselect_all.Size = New System.Drawing.Size(75, 22)
        Me.btn_unselect_all.TabIndex = 16
        Me.btn_unselect_all.TabStop = False
        Me.btn_unselect_all.Text = "Unselect All"
        Me.btn_unselect_all.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(71, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(386, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 14)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "*"
        '
        'btn_shipment_req_no
        '
        Me.btn_shipment_req_no.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_shipment_req_no.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_shipment_req_no.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_shipment_req_no.Location = New System.Drawing.Point(274, 42)
        Me.btn_shipment_req_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_shipment_req_no.Name = "btn_shipment_req_no"
        Me.btn_shipment_req_no.Size = New System.Drawing.Size(24, 22)
        Me.btn_shipment_req_no.TabIndex = 5
        Me.btn_shipment_req_no.Text = "?"
        Me.btn_shipment_req_no.UseVisualStyleBackColor = False
        '
        'btn_custom_export
        '
        Me.btn_custom_export.BackColor = System.Drawing.Color.Green
        Me.btn_custom_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_custom_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_custom_export.Location = New System.Drawing.Point(10, 478)
        Me.btn_custom_export.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_custom_export.Name = "btn_custom_export"
        Me.btn_custom_export.Size = New System.Drawing.Size(102, 22)
        Me.btn_custom_export.TabIndex = 26
        Me.btn_custom_export.Text = "Beta export"
        Me.btn_custom_export.UseVisualStyleBackColor = False
        Me.btn_custom_export.Visible = False
        '
        'frm_SHS001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 505)
        Me.Controls.Add(Me.btn_custom_export)
        Me.Controls.Add(Me.btn_shipment_req_no)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_unselect_all)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_select_all)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.grd_ship_list)
        Me.Controls.Add(Me.btn_shipment)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dat_invoice_date)
        Me.Controls.Add(Me.dat_shipment_date)
        Me.Controls.Add(Me.dat_shipment_req_date)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.lbl_invoice_date)
        Me.Controls.Add(Me.btn_execute)
        Me.Controls.Add(Me.lbl_shipment_date)
        Me.Controls.Add(Me.lbl_shipment_req_date)
        Me.Controls.Add(Me.lbl_invoice_no)
        Me.Controls.Add(Me.lbl_po_no)
        Me.Controls.Add(Me.lbl_customer_cd)
        Me.Controls.Add(Me.lbl_shipment_req_no)
        Me.Controls.Add(Me.txt_customer_name)
        Me.Controls.Add(Me.btn_customer_cd)
        Me.Controls.Add(Me.txt_invoice_no)
        Me.Controls.Add(Me.txt_po_no)
        Me.Controls.Add(Me.txt_customer_cd)
        Me.Controls.Add(Me.txt_shipment_req_no)
        Me.Controls.Add(Me.rdo_del)
        Me.Controls.Add(Me.rdo_chg)
        Me.Controls.Add(Me.rdo_add)
        Me.Controls.Add(Me.lbl_shipment_status)
        Me.Controls.Add(Me.lb_today)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_SHS001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipment Request Entry"
        CType(Me.grd_ship_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents rdo_add As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_chg As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_del As System.Windows.Forms.RadioButton
    Friend WithEvents txt_shipment_req_no As System.Windows.Forms.TextBox
    Friend WithEvents txt_customer_cd As System.Windows.Forms.TextBox
    Friend WithEvents btn_customer_cd As System.Windows.Forms.Button
    Friend WithEvents txt_customer_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_shipment_req_no As System.Windows.Forms.Label
    Friend WithEvents lbl_customer_cd As System.Windows.Forms.Label
    Friend WithEvents lbl_shipment_req_date As System.Windows.Forms.Label
    Friend WithEvents btn_execute As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents dat_shipment_req_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_shipment As System.Windows.Forms.Button
    Friend WithEvents lbl_shipment_status As System.Windows.Forms.Label
    Friend WithEvents lbl_shipment_date As System.Windows.Forms.Label
    Friend WithEvents dat_shipment_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_po_no As System.Windows.Forms.TextBox
    Friend WithEvents lbl_po_no As System.Windows.Forms.Label
    Friend WithEvents txt_invoice_no As System.Windows.Forms.TextBox
    Friend WithEvents lbl_invoice_no As System.Windows.Forms.Label
    Friend WithEvents lbl_invoice_date As System.Windows.Forms.Label
    Friend WithEvents dat_invoice_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_add As System.Windows.Forms.Button
    Friend WithEvents grd_ship_list As System.Windows.Forms.DataGridView
    Friend WithEvents btn_select_all As System.Windows.Forms.Button
    Friend WithEvents btn_unselect_all As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents sfDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btn_shipment_req_no As System.Windows.Forms.Button
    Friend WithEvents col_chk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents col_pallet_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_barcode_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_lot_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_rack_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_wh_cd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_item_cd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_item_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_scan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_custom_export As System.Windows.Forms.Button
End Class
