<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SHS002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SHS002))
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
        Me.lb_today = New System.Windows.Forms.Label
        CType(Me.grd_shipment_inquiry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cb_ship_status
        '
        Me.cb_ship_status.BackColor = System.Drawing.SystemColors.Window
        Me.cb_ship_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ship_status.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_ship_status.FormattingEnabled = True
        Me.cb_ship_status.Location = New System.Drawing.Point(228, 29)
        Me.cb_ship_status.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_ship_status.Name = "cb_ship_status"
        Me.cb_ship_status.Size = New System.Drawing.Size(179, 26)
        Me.cb_ship_status.TabIndex = 45
        '
        'btn_popup_cus
        '
        Me.btn_popup_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_cus.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_popup_cus.FlatAppearance.BorderSize = 2
        Me.btn_popup_cus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_popup_cus.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_popup_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_popup_cus.Location = New System.Drawing.Point(415, 159)
        Me.btn_popup_cus.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_popup_cus.Name = "btn_popup_cus"
        Me.btn_popup_cus.Size = New System.Drawing.Size(26, 26)
        Me.btn_popup_cus.TabIndex = 47
        Me.btn_popup_cus.TabStop = False
        Me.btn_popup_cus.Text = "?"
        Me.btn_popup_cus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_popup_cus.UseVisualStyleBackColor = False
        '
        'grd_shipment_inquiry
        '
        Me.grd_shipment_inquiry.AllowUserToAddRows = False
        Me.grd_shipment_inquiry.AllowUserToDeleteRows = False
        Me.grd_shipment_inquiry.AllowUserToResizeRows = False
        Me.grd_shipment_inquiry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_shipment_inquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_shipment_inquiry.Location = New System.Drawing.Point(6, 290)
        Me.grd_shipment_inquiry.Margin = New System.Windows.Forms.Padding(4)
        Me.grd_shipment_inquiry.Name = "grd_shipment_inquiry"
        Me.grd_shipment_inquiry.ReadOnly = True
        Me.grd_shipment_inquiry.RowHeadersVisible = False
        Me.grd_shipment_inquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_shipment_inquiry.Size = New System.Drawing.Size(864, 244)
        Me.grd_shipment_inquiry.TabIndex = 55
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_search.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_search.FlatAppearance.BorderSize = 2
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_search.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(795, 256)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 26)
        Me.btn_search.TabIndex = 48
        Me.btn_search.TabStop = False
        Me.btn_search.Text = "Search"
        Me.btn_search.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_export.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_export.FlatAppearance.BorderSize = 2
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_export.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_export.Location = New System.Drawing.Point(629, 542)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 26)
        Me.btn_export.TabIndex = 49
        Me.btn_export.Text = "Export"
        Me.btn_export.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_cancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_cancel.FlatAppearance.BorderSize = 2
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_cancel.Location = New System.Drawing.Point(712, 542)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 26)
        Me.btn_cancel.TabIndex = 50
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_exit.FlatAppearance.BorderSize = 2
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(795, 542)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 26)
        Me.btn_exit.TabIndex = 51
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'txt_cus_name
        '
        Me.txt_cus_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cus_name.Location = New System.Drawing.Point(449, 159)
        Me.txt_cus_name.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cus_name.Name = "txt_cus_name"
        Me.txt_cus_name.Size = New System.Drawing.Size(335, 26)
        Me.txt_cus_name.TabIndex = 54
        Me.txt_cus_name.TabStop = False
        '
        'txt_cus_id
        '
        Me.txt_cus_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cus_id.Location = New System.Drawing.Point(228, 159)
        Me.txt_cus_id.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cus_id.Name = "txt_cus_id"
        Me.txt_cus_id.Size = New System.Drawing.Size(179, 26)
        Me.txt_cus_id.TabIndex = 46
        Me.txt_cus_id.TabStop = False
        '
        'lbl_ship_status
        '
        Me.lbl_ship_status.AutoSize = True
        Me.lbl_ship_status.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_status.Location = New System.Drawing.Point(70, 37)
        Me.lbl_ship_status.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_status.Name = "lbl_ship_status"
        Me.lbl_ship_status.Size = New System.Drawing.Size(109, 18)
        Me.lbl_ship_status.TabIndex = 52
        Me.lbl_ship_status.Text = "Shipment Status"
        '
        'lbl_ship_req_no
        '
        Me.lbl_ship_req_no.AutoSize = True
        Me.lbl_ship_req_no.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_req_no.Location = New System.Drawing.Point(70, 65)
        Me.lbl_ship_req_no.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_req_no.Name = "lbl_ship_req_no"
        Me.lbl_ship_req_no.Size = New System.Drawing.Size(116, 18)
        Me.lbl_ship_req_no.TabIndex = 53
        Me.lbl_ship_req_no.Text = "Shipment Req No"
        '
        'lbl_ship_req_date
        '
        Me.lbl_ship_req_date.AutoSize = True
        Me.lbl_ship_req_date.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_req_date.Location = New System.Drawing.Point(70, 101)
        Me.lbl_ship_req_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_req_date.Name = "lbl_ship_req_date"
        Me.lbl_ship_req_date.Size = New System.Drawing.Size(127, 18)
        Me.lbl_ship_req_date.TabIndex = 53
        Me.lbl_ship_req_date.Text = "Shipment Req Date"
        '
        'lbl_ship_date
        '
        Me.lbl_ship_date.AutoSize = True
        Me.lbl_ship_date.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ship_date.Location = New System.Drawing.Point(70, 132)
        Me.lbl_ship_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ship_date.Name = "lbl_ship_date"
        Me.lbl_ship_date.Size = New System.Drawing.Size(100, 18)
        Me.lbl_ship_date.TabIndex = 53
        Me.lbl_ship_date.Text = "Shipment Date"
        '
        'lbl_cus_id
        '
        Me.lbl_cus_id.AutoSize = True
        Me.lbl_cus_id.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cus_id.Location = New System.Drawing.Point(70, 161)
        Me.lbl_cus_id.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_cus_id.Name = "lbl_cus_id"
        Me.lbl_cus_id.Size = New System.Drawing.Size(68, 18)
        Me.lbl_cus_id.TabIndex = 53
        Me.lbl_cus_id.Text = "Customer"
        '
        'lbl_cus_po
        '
        Me.lbl_cus_po.AutoSize = True
        Me.lbl_cus_po.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cus_po.Location = New System.Drawing.Point(70, 195)
        Me.lbl_cus_po.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_cus_po.Name = "lbl_cus_po"
        Me.lbl_cus_po.Size = New System.Drawing.Size(89, 18)
        Me.lbl_cus_po.TabIndex = 53
        Me.lbl_cus_po.Text = "Customer PO"
        '
        'lbl_invoice_no
        '
        Me.lbl_invoice_no.AutoSize = True
        Me.lbl_invoice_no.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_invoice_no.Location = New System.Drawing.Point(70, 229)
        Me.lbl_invoice_no.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_invoice_no.Name = "lbl_invoice_no"
        Me.lbl_invoice_no.Size = New System.Drawing.Size(74, 18)
        Me.lbl_invoice_no.TabIndex = 53
        Me.lbl_invoice_no.Text = "Invoice No"
        '
        'lbl_invoice_date
        '
        Me.lbl_invoice_date.AutoSize = True
        Me.lbl_invoice_date.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_invoice_date.Location = New System.Drawing.Point(446, 229)
        Me.lbl_invoice_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_invoice_date.Name = "lbl_invoice_date"
        Me.lbl_invoice_date.Size = New System.Drawing.Size(85, 18)
        Me.lbl_invoice_date.TabIndex = 53
        Me.lbl_invoice_date.Text = "Invoice Date"
        '
        'txt_ship_req_no
        '
        Me.txt_ship_req_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ship_req_no.Location = New System.Drawing.Point(228, 63)
        Me.txt_ship_req_no.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_ship_req_no.Name = "txt_ship_req_no"
        Me.txt_ship_req_no.Size = New System.Drawing.Size(179, 26)
        Me.txt_ship_req_no.TabIndex = 46
        Me.txt_ship_req_no.TabStop = False
        '
        'dtp_ship_req_date_from
        '
        Me.dtp_ship_req_date_from.CalendarFont = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_from.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_req_date_from.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_from.Location = New System.Drawing.Point(228, 97)
        Me.dtp_ship_req_date_from.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_ship_req_date_from.Name = "dtp_ship_req_date_from"
        Me.dtp_ship_req_date_from.Size = New System.Drawing.Size(179, 23)
        Me.dtp_ship_req_date_from.TabIndex = 56
        '
        'dtp_ship_req_date_to
        '
        Me.dtp_ship_req_date_to.CalendarFont = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_to.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_req_date_to.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_req_date_to.Location = New System.Drawing.Point(449, 97)
        Me.dtp_ship_req_date_to.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_ship_req_date_to.Name = "dtp_ship_req_date_to"
        Me.dtp_ship_req_date_to.Size = New System.Drawing.Size(179, 23)
        Me.dtp_ship_req_date_to.TabIndex = 56
        '
        'dtp_ship_date_from
        '
        Me.dtp_ship_date_from.CalendarFont = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_from.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_date_from.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_from.Location = New System.Drawing.Point(228, 128)
        Me.dtp_ship_date_from.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_ship_date_from.Name = "dtp_ship_date_from"
        Me.dtp_ship_date_from.Size = New System.Drawing.Size(179, 23)
        Me.dtp_ship_date_from.TabIndex = 56
        '
        'dtp_ship_date_to
        '
        Me.dtp_ship_date_to.CalendarFont = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_to.CustomFormat = "dd/mm/yyyy"
        Me.dtp_ship_date_to.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ship_date_to.Location = New System.Drawing.Point(449, 128)
        Me.dtp_ship_date_to.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_ship_date_to.Name = "dtp_ship_date_to"
        Me.dtp_ship_date_to.Size = New System.Drawing.Size(179, 23)
        Me.dtp_ship_date_to.TabIndex = 56
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(419, 131)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 19)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "~"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(419, 100)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 19)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "~"
        '
        'txt_invoice_no
        '
        Me.txt_invoice_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_invoice_no.Location = New System.Drawing.Point(228, 227)
        Me.txt_invoice_no.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_invoice_no.MaxLength = 18
        Me.txt_invoice_no.Name = "txt_invoice_no"
        Me.txt_invoice_no.Size = New System.Drawing.Size(179, 26)
        Me.txt_invoice_no.TabIndex = 46
        Me.txt_invoice_no.TabStop = False
        '
        'dtp_invoice_date
        '
        Me.dtp_invoice_date.CalendarFont = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_invoice_date.CustomFormat = "dd/mm/yyyy"
        Me.dtp_invoice_date.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_invoice_date.Location = New System.Drawing.Point(539, 225)
        Me.dtp_invoice_date.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_invoice_date.Name = "dtp_invoice_date"
        Me.dtp_invoice_date.Size = New System.Drawing.Size(179, 23)
        Me.dtp_invoice_date.TabIndex = 56
        '
        'txt_cus_po
        '
        Me.txt_cus_po.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cus_po.Location = New System.Drawing.Point(228, 193)
        Me.txt_cus_po.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_cus_po.Name = "txt_cus_po"
        Me.txt_cus_po.Size = New System.Drawing.Size(179, 26)
        Me.txt_cus_po.TabIndex = 46
        Me.txt_cus_po.TabStop = False
        '
        'lb_today
        '
        Me.lb_today.AutoSize = True
        Me.lb_today.Location = New System.Drawing.Point(616, 3)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(258, 18)
        Me.lb_today.TabIndex = 59
        Me.lb_today.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        '
        'frm_SHS002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 576)
        Me.Controls.Add(Me.lb_today)
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
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_SHS002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipment Request Inquiry"
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
    Friend WithEvents lb_today As System.Windows.Forms.Label
End Class
