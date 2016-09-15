<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_WHS002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_WHS002))
        Me.grd_wh_inquiry = New System.Windows.Forms.DataGridView
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_export = New System.Windows.Forms.Button
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.txt_item_code = New System.Windows.Forms.TextBox
        Me.txt_rack_code = New System.Windows.Forms.TextBox
        Me.lbl_item_name = New System.Windows.Forms.Label
        Me.lbl_rack_code = New System.Windows.Forms.Label
        Me.btn_popup_rack = New System.Windows.Forms.Button
        Me.txt_rack_name = New System.Windows.Forms.TextBox
        Me.btn_popup_item = New System.Windows.Forms.Button
        Me.txt_item_name = New System.Windows.Forms.TextBox
        Me.lbl_barcode = New System.Windows.Forms.Label
        Me.txt_barcode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cb_wh_list = New System.Windows.Forms.ComboBox
        Me.sfdDialog = New System.Windows.Forms.SaveFileDialog
        Me.lbl_today_date = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtp_import_date_to = New System.Windows.Forms.DateTimePicker
        Me.dtp_import_date_from = New System.Windows.Forms.DateTimePicker
        Me.lbl_import_date = New System.Windows.Forms.Label
        CType(Me.grd_wh_inquiry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd_wh_inquiry
        '
        Me.grd_wh_inquiry.AllowUserToAddRows = False
        Me.grd_wh_inquiry.AllowUserToDeleteRows = False
        Me.grd_wh_inquiry.AllowUserToResizeRows = False
        Me.grd_wh_inquiry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_wh_inquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_wh_inquiry.Location = New System.Drawing.Point(11, 160)
        Me.grd_wh_inquiry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grd_wh_inquiry.Name = "grd_wh_inquiry"
        Me.grd_wh_inquiry.ReadOnly = True
        Me.grd_wh_inquiry.RowHeadersVisible = False
        Me.grd_wh_inquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_wh_inquiry.Size = New System.Drawing.Size(816, 254)
        Me.grd_wh_inquiry.TabIndex = 44
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_search.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(752, 132)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 24
        Me.btn_search.TabStop = False
        Me.btn_search.Text = "Search"
        Me.btn_search.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_export.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_export.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_export.Location = New System.Drawing.Point(586, 420)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 22)
        Me.btn_export.TabIndex = 5
        Me.btn_export.TabStop = False
        Me.btn_export.Text = "Export"
        Me.btn_export.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_clear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_clear.Location = New System.Drawing.Point(669, 420)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 22)
        Me.btn_clear.TabIndex = 6
        Me.btn_clear.TabStop = False
        Me.btn_clear.Text = "Cancel"
        Me.btn_clear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(752, 420)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 7
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'txt_item_code
        '
        Me.txt_item_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_item_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_item_code.Location = New System.Drawing.Point(139, 76)
        Me.txt_item_code.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_item_code.MaxLength = 50
        Me.txt_item_code.Name = "txt_item_code"
        Me.txt_item_code.Size = New System.Drawing.Size(157, 22)
        Me.txt_item_code.TabIndex = 2
        '
        'txt_rack_code
        '
        Me.txt_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_rack_code.Location = New System.Drawing.Point(139, 48)
        Me.txt_rack_code.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_rack_code.MaxLength = 7
        Me.txt_rack_code.Name = "txt_rack_code"
        Me.txt_rack_code.Size = New System.Drawing.Size(157, 22)
        Me.txt_rack_code.TabIndex = 1
        '
        'lbl_item_name
        '
        Me.lbl_item_name.AutoSize = True
        Me.lbl_item_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_item_name.Location = New System.Drawing.Point(14, 80)
        Me.lbl_item_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_item_name.Name = "lbl_item_name"
        Me.lbl_item_name.Size = New System.Drawing.Size(33, 14)
        Me.lbl_item_name.TabIndex = 37
        Me.lbl_item_name.Text = "Item"
        '
        'lbl_rack_code
        '
        Me.lbl_rack_code.AutoSize = True
        Me.lbl_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rack_code.Location = New System.Drawing.Point(14, 52)
        Me.lbl_rack_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rack_code.Name = "lbl_rack_code"
        Me.lbl_rack_code.Size = New System.Drawing.Size(32, 14)
        Me.lbl_rack_code.TabIndex = 35
        Me.lbl_rack_code.Text = "Rack"
        '
        'btn_popup_rack
        '
        Me.btn_popup_rack.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_rack.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_popup_rack.FlatAppearance.BorderSize = 2
        Me.btn_popup_rack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_popup_rack.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_popup_rack.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_popup_rack.Location = New System.Drawing.Point(302, 48)
        Me.btn_popup_rack.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_popup_rack.Name = "btn_popup_rack"
        Me.btn_popup_rack.Size = New System.Drawing.Size(24, 21)
        Me.btn_popup_rack.TabIndex = 20
        Me.btn_popup_rack.TabStop = False
        Me.btn_popup_rack.Text = "?"
        Me.btn_popup_rack.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_popup_rack.UseVisualStyleBackColor = False
        '
        'txt_rack_name
        '
        Me.txt_rack_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_name.Location = New System.Drawing.Point(333, 48)
        Me.txt_rack_name.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_rack_name.MaxLength = 40
        Me.txt_rack_name.Name = "txt_rack_name"
        Me.txt_rack_name.Size = New System.Drawing.Size(216, 22)
        Me.txt_rack_name.TabIndex = 21
        Me.txt_rack_name.TabStop = False
        '
        'btn_popup_item
        '
        Me.btn_popup_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_item.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_popup_item.FlatAppearance.BorderSize = 2
        Me.btn_popup_item.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_popup_item.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_popup_item.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_popup_item.Location = New System.Drawing.Point(302, 76)
        Me.btn_popup_item.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_popup_item.Name = "btn_popup_item"
        Me.btn_popup_item.Size = New System.Drawing.Size(24, 22)
        Me.btn_popup_item.TabIndex = 22
        Me.btn_popup_item.TabStop = False
        Me.btn_popup_item.Text = "?"
        Me.btn_popup_item.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_popup_item.UseVisualStyleBackColor = False
        '
        'txt_item_name
        '
        Me.txt_item_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_item_name.Location = New System.Drawing.Point(333, 77)
        Me.txt_item_name.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_item_name.MaxLength = 100
        Me.txt_item_name.Name = "txt_item_name"
        Me.txt_item_name.Size = New System.Drawing.Size(299, 22)
        Me.txt_item_name.TabIndex = 23
        Me.txt_item_name.TabStop = False
        '
        'lbl_barcode
        '
        Me.lbl_barcode.AutoSize = True
        Me.lbl_barcode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_barcode.Location = New System.Drawing.Point(13, 107)
        Me.lbl_barcode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_barcode.Name = "lbl_barcode"
        Me.lbl_barcode.Size = New System.Drawing.Size(70, 14)
        Me.lbl_barcode.TabIndex = 37
        Me.lbl_barcode.Text = "Barcode No"
        '
        'txt_barcode
        '
        Me.txt_barcode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_barcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_barcode.Location = New System.Drawing.Point(139, 104)
        Me.txt_barcode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_barcode.MaxLength = 14
        Me.txt_barcode.Name = "txt_barcode"
        Me.txt_barcode.Size = New System.Drawing.Size(157, 22)
        Me.txt_barcode.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 14)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Warehouse Code"
        '
        'cb_wh_list
        '
        Me.cb_wh_list.BackColor = System.Drawing.SystemColors.Window
        Me.cb_wh_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_wh_list.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_wh_list.FormattingEnabled = True
        Me.cb_wh_list.Location = New System.Drawing.Point(140, 20)
        Me.cb_wh_list.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cb_wh_list.Name = "cb_wh_list"
        Me.cb_wh_list.Size = New System.Drawing.Size(157, 22)
        Me.cb_wh_list.TabIndex = 0
        '
        'lbl_today_date
        '
        Me.lbl_today_date.Location = New System.Drawing.Point(595, 2)
        Me.lbl_today_date.Name = "lbl_today_date"
        Me.lbl_today_date.Size = New System.Drawing.Size(232, 14)
        Me.lbl_today_date.TabIndex = 45
        Me.lbl_today_date.Text = "User ID: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(305, 138)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 14)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "~"
        '
        'dtp_import_date_to
        '
        Me.dtp_import_date_to.CalendarFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_import_date_to.CustomFormat = "dd/mm/yyyy"
        Me.dtp_import_date_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_import_date_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_import_date_to.Location = New System.Drawing.Point(329, 132)
        Me.dtp_import_date_to.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_import_date_to.Name = "dtp_import_date_to"
        Me.dtp_import_date_to.Size = New System.Drawing.Size(157, 22)
        Me.dtp_import_date_to.TabIndex = 60
        '
        'dtp_import_date_from
        '
        Me.dtp_import_date_from.CalendarFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_import_date_from.CustomFormat = "dd/mm/yyyy"
        Me.dtp_import_date_from.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_import_date_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_import_date_from.Location = New System.Drawing.Point(140, 132)
        Me.dtp_import_date_from.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_import_date_from.Name = "dtp_import_date_from"
        Me.dtp_import_date_from.Size = New System.Drawing.Size(157, 22)
        Me.dtp_import_date_from.TabIndex = 59
        '
        'lbl_import_date
        '
        Me.lbl_import_date.AutoSize = True
        Me.lbl_import_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_import_date.Location = New System.Drawing.Point(13, 138)
        Me.lbl_import_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_import_date.Name = "lbl_import_date"
        Me.lbl_import_date.Size = New System.Drawing.Size(74, 14)
        Me.lbl_import_date.TabIndex = 58
        Me.lbl_import_date.Text = "Import Date"
        '
        'frm_WHS002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 451)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtp_import_date_to)
        Me.Controls.Add(Me.dtp_import_date_from)
        Me.Controls.Add(Me.lbl_import_date)
        Me.Controls.Add(Me.lbl_today_date)
        Me.Controls.Add(Me.cb_wh_list)
        Me.Controls.Add(Me.btn_popup_item)
        Me.Controls.Add(Me.btn_popup_rack)
        Me.Controls.Add(Me.grd_wh_inquiry)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.txt_item_name)
        Me.Controls.Add(Me.txt_barcode)
        Me.Controls.Add(Me.txt_item_code)
        Me.Controls.Add(Me.txt_rack_name)
        Me.Controls.Add(Me.txt_rack_code)
        Me.Controls.Add(Me.lbl_barcode)
        Me.Controls.Add(Me.lbl_item_name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_rack_code)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_WHS002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Warehouse Inquiry"
        CType(Me.grd_wh_inquiry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_wh_inquiry As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents txt_item_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_rack_code As System.Windows.Forms.TextBox
    Friend WithEvents lbl_item_name As System.Windows.Forms.Label
    Friend WithEvents lbl_rack_code As System.Windows.Forms.Label
    Friend WithEvents btn_popup_rack As System.Windows.Forms.Button
    Friend WithEvents txt_rack_name As System.Windows.Forms.TextBox
    Friend WithEvents btn_popup_item As System.Windows.Forms.Button
    Friend WithEvents txt_item_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_barcode As System.Windows.Forms.Label
    Friend WithEvents txt_barcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_wh_list As System.Windows.Forms.ComboBox
    Friend WithEvents sfdDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl_today_date As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtp_import_date_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_import_date_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_import_date As System.Windows.Forms.Label
End Class
