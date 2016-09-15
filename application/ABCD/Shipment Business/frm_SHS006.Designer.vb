<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SHS006
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SHS006))
        Me.cb_ship_status = New System.Windows.Forms.ComboBox
        Me.btn_popup_cus = New System.Windows.Forms.Button
        Me.grd_shipment_inquiry = New System.Windows.Forms.DataGridView
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_export = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.txt_cus_name = New System.Windows.Forms.TextBox
        Me.txt_cus_id = New System.Windows.Forms.TextBox
        Me.lbl_ship_status = New System.Windows.Forms.Label
        Me.lbl_ship_req_no = New System.Windows.Forms.Label
        Me.lbl_ship_req_date = New System.Windows.Forms.Label
        Me.lbl_ship_date = New System.Windows.Forms.Label
        Me.lbl_cus_id = New System.Windows.Forms.Label
        Me.lbl_cus_po = New System.Windows.Forms.Label
        Me.lbl_invoice_no = New System.Windows.Forms.Label
        Me.lbl_invoice_date = New System.Windows.Forms.Label
        Me.txt_ship_req_no = New System.Windows.Forms.TextBox
        Me.dtp_ship_req_date_from = New System.Windows.Forms.DateTimePicker
        Me.dtp_ship_req_date_to = New System.Windows.Forms.DateTimePicker
        Me.dtp_ship_date_from = New System.Windows.Forms.DateTimePicker
        Me.dtp_ship_date_to = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_invoice_no = New System.Windows.Forms.TextBox
        Me.dtp_invoice_date = New System.Windows.Forms.DateTimePicker
        Me.txt_cus_po = New System.Windows.Forms.TextBox
        Me.sfdDialog = New System.Windows.Forms.SaveFileDialog
        Me.lbl_today_date = New System.Windows.Forms.Label
        CType(Me.grd_shipment_inquiry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cb_ship_status
        '
        Me.cb_ship_status.BackColor = System.Drawing.SystemColors.Window
        Me.cb_ship_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ship_status.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_ship_status.FormattingEnabled = True
        Me.cb_ship_status.Location = New System.Drawing.Point(132, 20)
        Me.cb_ship_status.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cb_ship_status.Name = "cb_ship_status"
        Me.cb_ship_status.Size = New System.Drawing.Size(157, 22)
        Me.cb_ship_status.TabIndex = 0
        '
        'btn_popup_cus
        '
        Me.btn_popup_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_cus.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_popup_cus.FlatAppearance.BorderSize = 2
        Me.btn_popup_cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_popup_cus.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_popup_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_popup_cus.Location = New System.Drawing.Point(294, 132)
        Me.btn_popup_cus.Margin = New System.Windows.Forms.Padding(1)
        Me.btn_popup_cus.Name = "btn_popup_cus"
        Me.btn_popup_cus.Size = New System.Drawing.Size(24, 22)
        Me.btn_popup_cus.TabIndex = 8
        Me.btn_popup_cus.TabStop = False
        Me.btn_popup_cus.Text = "?"
        Me.btn_popup_cus.UseVisualStyleBackColor = False
        '
        'grd_shipment_inquiry
        '
        Me.grd_shipment_inquiry.AllowUserToAddRows = False
        Me.grd_shipment_inquiry.AllowUserToDeleteRows = False
        Me.grd_shipment_inquiry.AllowUserToResizeRows = False
        Me.grd_shipment_inquiry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_shipment_inquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_shipment_inquiry.Location = New System.Drawing.Point(13, 216)
        Me.grd_shipment_inquiry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grd_shipment_inquiry.Name = "grd_shipment_inquiry"
        Me.grd_shipment_inquiry.ReadOnly = True
        Me.grd_shipment_inquiry.RowHeadersVisible = False
        Me.grd_shipment_inquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_shipment_inquiry.Size = New System.Drawing.Size(836, 254)
        Me.grd_shipment_inquiry.TabIndex = 55
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_search.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(774, 188)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 10
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_export.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_export.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_export.Location = New System.Drawing.Point(608, 476)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 22)
        Me.btn_export.TabIndex = 11
        Me.btn_export.Text = "Export"
        Me.btn_export.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_cancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_cancel.Location = New System.Drawing.Point(691, 476)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 22)
        Me.btn_cancel.TabIndex = 12
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(774, 476)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 13
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'txt_cus_name
        '
        Me.txt_cus_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cus_name.Location = New System.Drawing.Point(325, 132)
        Me.txt_cus_name.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_cus_name.MaxLength = 50
        Me.txt_cus_name.Name = "txt_cus_name"
        Me.txt_cus_name.Size = New System.Drawing.Size(294, 22)
        Me.txt_cus_name.TabIndex = 9
        Me.txt_cus_name.TabStop = False
        '
        'txt_cus_id
        '
        Me.txt_cus_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_cus_id.Location = New System.Drawing.Point(132, 132)
        Me.txt_cus_id.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_cus_id.MaxLength = 10
        Me.txt_cus_id.Name = "txt_cus_id"
        Me.txt_cus_id.Size = New System.Drawing.Size(157, 22)
        Me.txt_cus_id.TabIndex = 6
        '
        'lbl_ship_status
        '
        Me.lbl_ship_status.AutoSize = True
        Me.lbl_ship_status.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_status.Location = New System.Drawing.Point(10, 25)
        Me.lbl_ship_status.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_status.Name = "lbl_ship_status"
        Me.lbl_ship_status.Size = New System.Drawing.Size(98, 14)
        Me.lbl_ship_status.TabIndex = 52
        Me.lbl_ship_status.Text = "Shipment Status"
        '
        'lbl_ship_req_no
        '
        Me.lbl_ship_req_no.AutoSize = True
        Me.lbl_ship_req_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_req_no.Location = New System.Drawing.Point(10, 53)
        Me.lbl_ship_req_no.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_req_no.Name = "lbl_ship_req_no"
        Me.lbl_ship_req_no.Size = New System.Drawing.Size(103, 14)
        Me.lbl_ship_req_no.TabIndex = 53
        Me.lbl_ship_req_no.Text = "Shipment Req No"
        '
        'lbl_ship_req_date
        '
        Me.lbl_ship_req_date.AutoSize = True
        Me.lbl_ship_req_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_req_date.Location = New System.Drawing.Point(10, 82)
        Me.lbl_ship_req_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_req_date.Name = "lbl_ship_req_date"
        Me.lbl_ship_req_date.Size = New System.Drawing.Size(114, 14)
        Me.lbl_ship_req_date.TabIndex = 53
        Me.lbl_ship_req_date.Text = "Shipment Req Date"
        '
        'lbl_ship_date
        '
        Me.lbl_ship_date.AutoSize = True
        Me.lbl_ship_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_date.Location = New System.Drawing.Point(10, 112)
        Me.lbl_ship_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_date.Name = "lbl_ship_date"
        Me.lbl_ship_date.Size = New System.Drawing.Size(89, 14)
        Me.lbl_ship_date.TabIndex = 53
        Me.lbl_ship_date.Text = "Shipment Date"
        '
        'lbl_cus_id
        '
        Me.lbl_cus_id.AutoSize = True
        Me.lbl_cus_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cus_id.Location = New System.Drawing.Point(10, 137)
        Me.lbl_cus_id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_cus_id.Name = "lbl_cus_id"
        Me.lbl_cus_id.Size = New System.Drawing.Size(59, 14)
        Me.lbl_cus_id.TabIndex = 53
        Me.lbl_cus_id.Text = "Customer"
        '
        'lbl_cus_po
        '
        Me.lbl_cus_po.AutoSize = True
        Me.lbl_cus_po.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cus_po.Location = New System.Drawing.Point(10, 165)
        Me.lbl_cus_po.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_cus_po.Name = "lbl_cus_po"
        Me.lbl_cus_po.Size = New System.Drawing.Size(79, 14)
        Me.lbl_cus_po.TabIndex = 53
        Me.lbl_cus_po.Text = "Customer PO"
        '
        'lbl_invoice_no
        '
        Me.lbl_invoice_no.AutoSize = True
        Me.lbl_invoice_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_invoice_no.Location = New System.Drawing.Point(10, 196)
        Me.lbl_invoice_no.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_invoice_no.Name = "lbl_invoice_no"
        Me.lbl_invoice_no.Size = New System.Drawing.Size(65, 14)
        Me.lbl_invoice_no.TabIndex = 53
        Me.lbl_invoice_no.Text = "Invoice No"
        '
        'lbl_invoice_date
        '
        Me.lbl_invoice_date.AutoSize = True
        Me.lbl_invoice_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_invoice_date.Location = New System.Drawing.Point(322, 191)
        Me.lbl_invoice_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_invoice_date.Name = "lbl_invoice_date"
        Me.lbl_invoice_date.Size = New System.Drawing.Size(76, 14)
        Me.lbl_invoice_date.TabIndex = 53
        Me.lbl_invoice_date.Text = "Invoice Date"
        '
        'txt_ship_req_no
        '
        Me.txt_ship_req_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ship_req_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_ship_req_no.Location = New System.Drawing.Point(132, 48)
        Me.txt_ship_req_no.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_ship_req_no.MaxLength = 10
        Me.txt_ship_req_no.Name = "txt_ship_req_no"
        Me.txt_ship_req_no.Size = New System.Drawing.Size(157, 22)
        Me.txt_ship_req_no.TabIndex = 1
        '
        'dtp_ship_req_date_from
        '
        Me.dtp_ship_req_date_from.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_from.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_req_date_from.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_from.Location = New System.Drawing.Point(132, 76)
        Me.dtp_ship_req_date_from.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_ship_req_date_from.Name = "dtp_ship_req_date_from"
        Me.dtp_ship_req_date_from.Size = New System.Drawing.Size(157, 22)
        Me.dtp_ship_req_date_from.TabIndex = 2
        '
        'dtp_ship_req_date_to
        '
        Me.dtp_ship_req_date_to.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_to.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_req_date_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_to.Location = New System.Drawing.Point(325, 76)
        Me.dtp_ship_req_date_to.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_ship_req_date_to.Name = "dtp_ship_req_date_to"
        Me.dtp_ship_req_date_to.Size = New System.Drawing.Size(157, 22)
        Me.dtp_ship_req_date_to.TabIndex = 3
        '
        'dtp_ship_date_from
        '
        Me.dtp_ship_date_from.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_from.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_date_from.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_from.Location = New System.Drawing.Point(132, 104)
        Me.dtp_ship_date_from.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_ship_date_from.Name = "dtp_ship_date_from"
        Me.dtp_ship_date_from.Size = New System.Drawing.Size(157, 22)
        Me.dtp_ship_date_from.TabIndex = 4
        '
        'dtp_ship_date_to
        '
        Me.dtp_ship_date_to.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_to.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_date_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_to.Location = New System.Drawing.Point(325, 104)
        Me.dtp_ship_date_to.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_ship_date_to.Name = "dtp_ship_date_to"
        Me.dtp_ship_date_to.Size = New System.Drawing.Size(157, 22)
        Me.dtp_ship_date_to.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(298, 110)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 14)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "~"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(298, 80)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 14)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "~"
        '
        'txt_invoice_no
        '
        Me.txt_invoice_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_invoice_no.Location = New System.Drawing.Point(132, 188)
        Me.txt_invoice_no.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_invoice_no.MaxLength = 18
        Me.txt_invoice_no.Name = "txt_invoice_no"
        Me.txt_invoice_no.Size = New System.Drawing.Size(157, 22)
        Me.txt_invoice_no.TabIndex = 8
        '
        'dtp_invoice_date
        '
        Me.dtp_invoice_date.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_invoice_date.CustomFormat = "dd/mm/yyyy"
        Me.dtp_invoice_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_invoice_date.Location = New System.Drawing.Point(406, 188)
        Me.dtp_invoice_date.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_invoice_date.Name = "dtp_invoice_date"
        Me.dtp_invoice_date.Size = New System.Drawing.Size(148, 22)
        Me.dtp_invoice_date.TabIndex = 9
        '
        'txt_cus_po
        '
        Me.txt_cus_po.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cus_po.Location = New System.Drawing.Point(132, 160)
        Me.txt_cus_po.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_cus_po.MaxLength = 20
        Me.txt_cus_po.Name = "txt_cus_po"
        Me.txt_cus_po.Size = New System.Drawing.Size(157, 22)
        Me.txt_cus_po.TabIndex = 7
        '
        'lbl_today_date
        '
        Me.lbl_today_date.Location = New System.Drawing.Point(606, 1)
        Me.lbl_today_date.Name = "lbl_today_date"
        Me.lbl_today_date.Size = New System.Drawing.Size(243, 17)
        Me.lbl_today_date.TabIndex = 59
        Me.lbl_today_date.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_SHS006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 508)
        Me.Controls.Add(Me.lbl_today_date)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtp_invoice_date)
        Me.Controls.Add(Me.dtp_ship_date_to)
        Me.Controls.Add(Me.dtp_ship_date_from)
        Me.Controls.Add(Me.dtp_ship_req_date_to)
        Me.Controls.Add(Me.dtp_ship_req_date_from)
        Me.Controls.Add(Me.cb_ship_status)
        Me.Controls.Add(Me.btn_popup_cus)
        Me.Controls.Add(Me.grd_shipment_inquiry)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.txt_cus_name)
        Me.Controls.Add(Me.txt_ship_req_no)
        Me.Controls.Add(Me.txt_invoice_no)
        Me.Controls.Add(Me.txt_cus_po)
        Me.Controls.Add(Me.txt_cus_id)
        Me.Controls.Add(Me.lbl_ship_status)
        Me.Controls.Add(Me.lbl_invoice_date)
        Me.Controls.Add(Me.lbl_invoice_no)
        Me.Controls.Add(Me.lbl_cus_po)
        Me.Controls.Add(Me.lbl_cus_id)
        Me.Controls.Add(Me.lbl_ship_date)
        Me.Controls.Add(Me.lbl_ship_req_date)
        Me.Controls.Add(Me.lbl_ship_req_no)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_SHS006"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipment Inquiry"
        CType(Me.grd_shipment_inquiry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cb_ship_status As System.Windows.Forms.ComboBox
    Friend WithEvents btn_popup_cus As System.Windows.Forms.Button
    Friend WithEvents grd_shipment_inquiry As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents txt_cus_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ship_status As System.Windows.Forms.Label
    Friend WithEvents lbl_ship_req_no As System.Windows.Forms.Label
    Friend WithEvents lbl_ship_req_date As System.Windows.Forms.Label
    Friend WithEvents lbl_ship_date As System.Windows.Forms.Label
    Friend WithEvents lbl_cus_id As System.Windows.Forms.Label
    Friend WithEvents lbl_cus_po As System.Windows.Forms.Label
    Friend WithEvents lbl_invoice_no As System.Windows.Forms.Label
    Friend WithEvents lbl_invoice_date As System.Windows.Forms.Label
    Friend WithEvents txt_ship_req_no As System.Windows.Forms.TextBox
    Friend WithEvents dtp_ship_req_date_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_ship_req_date_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_ship_date_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_ship_date_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_invoice_no As System.Windows.Forms.TextBox
    Friend WithEvents dtp_invoice_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_cus_po As System.Windows.Forms.TextBox
    Friend WithEvents sfdDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl_today_date As System.Windows.Forms.Label
End Class
