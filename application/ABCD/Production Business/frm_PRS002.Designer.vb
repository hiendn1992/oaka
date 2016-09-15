<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PRS002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PRS002))
        Me.rdo_reissue = New System.Windows.Forms.RadioButton
        Me.rdo_exp_new = New System.Windows.Forms.RadioButton
        Me.btn_popup_item = New System.Windows.Forms.Button
        Me.txt_item_name = New System.Windows.Forms.TextBox
        Me.txt_item_code = New System.Windows.Forms.TextBox
        Me.lbl_item_code = New System.Windows.Forms.Label
        Me.grd_product_inquiry = New System.Windows.Forms.DataGridView
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_export = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.lbl_wo_no = New System.Windows.Forms.Label
        Me.lbl_wo_date = New System.Windows.Forms.Label
        Me.lbl_barcode = New System.Windows.Forms.Label
        Me.txt_wo_no = New System.Windows.Forms.TextBox
        Me.txt_barcode_from = New System.Windows.Forms.TextBox
        Me.lbl_exp_mode = New System.Windows.Forms.Label
        Me.txt_barcode_to = New System.Windows.Forms.TextBox
        Me.dtp_wo_date_from = New System.Windows.Forms.DateTimePicker
        Me.dtp_wo_date_to = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.sfdDialog = New System.Windows.Forms.SaveFileDialog
        Me.lbl_today_date = New System.Windows.Forms.Label
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        CType(Me.grd_product_inquiry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdo_reissue
        '
        Me.rdo_reissue.AutoSize = True
        Me.rdo_reissue.Enabled = False
        Me.rdo_reissue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_reissue.Location = New System.Drawing.Point(146, 22)
        Me.rdo_reissue.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rdo_reissue.Name = "rdo_reissue"
        Me.rdo_reissue.Size = New System.Drawing.Size(71, 18)
        Me.rdo_reissue.TabIndex = 15
        Me.rdo_reissue.Text = "Reissue"
        Me.rdo_reissue.UseVisualStyleBackColor = True
        '
        'rdo_exp_new
        '
        Me.rdo_exp_new.AutoSize = True
        Me.rdo_exp_new.Enabled = False
        Me.rdo_exp_new.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_exp_new.Location = New System.Drawing.Point(87, 22)
        Me.rdo_exp_new.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.rdo_exp_new.Name = "rdo_exp_new"
        Me.rdo_exp_new.Size = New System.Drawing.Size(51, 18)
        Me.rdo_exp_new.TabIndex = 14
        Me.rdo_exp_new.TabStop = True
        Me.rdo_exp_new.Text = "New"
        Me.rdo_exp_new.UseVisualStyleBackColor = True
        '
        'btn_popup_item
        '
        Me.btn_popup_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_item.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_popup_item.FlatAppearance.BorderSize = 2
        Me.btn_popup_item.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_popup_item.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_popup_item.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_popup_item.Location = New System.Drawing.Point(277, 46)
        Me.btn_popup_item.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_popup_item.Name = "btn_popup_item"
        Me.btn_popup_item.Padding = New System.Windows.Forms.Padding(1)
        Me.btn_popup_item.Size = New System.Drawing.Size(24, 22)
        Me.btn_popup_item.TabIndex = 20
        Me.btn_popup_item.Text = "?"
        Me.btn_popup_item.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_popup_item.UseVisualStyleBackColor = False
        '
        'txt_item_name
        '
        Me.txt_item_name.Enabled = False
        Me.txt_item_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_item_name.Location = New System.Drawing.Point(309, 46)
        Me.txt_item_name.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_item_name.MaxLength = 100
        Me.txt_item_name.Name = "txt_item_name"
        Me.txt_item_name.Size = New System.Drawing.Size(401, 22)
        Me.txt_item_name.TabIndex = 42
        Me.txt_item_name.TabStop = False
        '
        'txt_item_code
        '
        Me.txt_item_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_item_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_item_code.Location = New System.Drawing.Point(87, 46)
        Me.txt_item_code.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_item_code.MaxLength = 50
        Me.txt_item_code.Name = "txt_item_code"
        Me.txt_item_code.Size = New System.Drawing.Size(182, 22)
        Me.txt_item_code.TabIndex = 1
        '
        'lbl_item_code
        '
        Me.lbl_item_code.AutoSize = True
        Me.lbl_item_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_item_code.Location = New System.Drawing.Point(2, 50)
        Me.lbl_item_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_item_code.Name = "lbl_item_code"
        Me.lbl_item_code.Size = New System.Drawing.Size(33, 14)
        Me.lbl_item_code.TabIndex = 41
        Me.lbl_item_code.Text = "Item"
        '
        'grd_product_inquiry
        '
        Me.grd_product_inquiry.AllowUserToAddRows = False
        Me.grd_product_inquiry.AllowUserToDeleteRows = False
        Me.grd_product_inquiry.AllowUserToResizeRows = False
        Me.grd_product_inquiry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_product_inquiry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_product_inquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_product_inquiry.Location = New System.Drawing.Point(5, 158)
        Me.grd_product_inquiry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grd_product_inquiry.Name = "grd_product_inquiry"
        Me.grd_product_inquiry.RowHeadersVisible = False
        Me.grd_product_inquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_product_inquiry.Size = New System.Drawing.Size(884, 254)
        Me.grd_product_inquiry.TabIndex = 49
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_search.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(814, 130)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 8
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
        Me.btn_export.Location = New System.Drawing.Point(648, 416)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 22)
        Me.btn_export.TabIndex = 9
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
        Me.btn_cancel.Location = New System.Drawing.Point(731, 416)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 22)
        Me.btn_cancel.TabIndex = 10
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
        Me.btn_exit.Location = New System.Drawing.Point(814, 416)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 11
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'lbl_wo_no
        '
        Me.lbl_wo_no.AutoSize = True
        Me.lbl_wo_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wo_no.Location = New System.Drawing.Point(2, 77)
        Me.lbl_wo_no.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_wo_no.Name = "lbl_wo_no"
        Me.lbl_wo_no.Size = New System.Drawing.Size(47, 14)
        Me.lbl_wo_no.TabIndex = 41
        Me.lbl_wo_no.Text = "WO No"
        '
        'lbl_wo_date
        '
        Me.lbl_wo_date.AutoSize = True
        Me.lbl_wo_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wo_date.Location = New System.Drawing.Point(2, 108)
        Me.lbl_wo_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_wo_date.Name = "lbl_wo_date"
        Me.lbl_wo_date.Size = New System.Drawing.Size(58, 14)
        Me.lbl_wo_date.TabIndex = 41
        Me.lbl_wo_date.Text = "WO Date"
        '
        'lbl_barcode
        '
        Me.lbl_barcode.AutoSize = True
        Me.lbl_barcode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_barcode.Location = New System.Drawing.Point(2, 133)
        Me.lbl_barcode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_barcode.Name = "lbl_barcode"
        Me.lbl_barcode.Size = New System.Drawing.Size(70, 14)
        Me.lbl_barcode.TabIndex = 41
        Me.lbl_barcode.Text = "Barcode No"
        '
        'txt_wo_no
        '
        Me.txt_wo_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_wo_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_wo_no.Location = New System.Drawing.Point(87, 74)
        Me.txt_wo_no.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_wo_no.MaxLength = 10
        Me.txt_wo_no.Name = "txt_wo_no"
        Me.txt_wo_no.Size = New System.Drawing.Size(157, 22)
        Me.txt_wo_no.TabIndex = 3
        '
        'txt_barcode_from
        '
        Me.txt_barcode_from.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_barcode_from.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_barcode_from.Location = New System.Drawing.Point(87, 130)
        Me.txt_barcode_from.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_barcode_from.MaxLength = 14
        Me.txt_barcode_from.Name = "txt_barcode_from"
        Me.txt_barcode_from.Size = New System.Drawing.Size(157, 22)
        Me.txt_barcode_from.TabIndex = 6
        '
        'lbl_exp_mode
        '
        Me.lbl_exp_mode.AutoSize = True
        Me.lbl_exp_mode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_exp_mode.Location = New System.Drawing.Point(2, 24)
        Me.lbl_exp_mode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_exp_mode.Name = "lbl_exp_mode"
        Me.lbl_exp_mode.Size = New System.Drawing.Size(77, 14)
        Me.lbl_exp_mode.TabIndex = 41
        Me.lbl_exp_mode.Text = "Export Mode"
        '
        'txt_barcode_to
        '
        Me.txt_barcode_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_barcode_to.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_barcode_to.Location = New System.Drawing.Point(277, 130)
        Me.txt_barcode_to.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_barcode_to.MaxLength = 14
        Me.txt_barcode_to.Name = "txt_barcode_to"
        Me.txt_barcode_to.Size = New System.Drawing.Size(157, 22)
        Me.txt_barcode_to.TabIndex = 7
        '
        'dtp_wo_date_from
        '
        Me.dtp_wo_date_from.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_wo_date_from.CustomFormat = "dd-MM-yyyy"
        Me.dtp_wo_date_from.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_wo_date_from.Location = New System.Drawing.Point(87, 102)
        Me.dtp_wo_date_from.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_wo_date_from.Name = "dtp_wo_date_from"
        Me.dtp_wo_date_from.Size = New System.Drawing.Size(157, 22)
        Me.dtp_wo_date_from.TabIndex = 4
        '
        'dtp_wo_date_to
        '
        Me.dtp_wo_date_to.CalendarFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_wo_date_to.CustomFormat = "dd-MM-yyyy"
        Me.dtp_wo_date_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_wo_date_to.Location = New System.Drawing.Point(277, 102)
        Me.dtp_wo_date_to.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_wo_date_to.Name = "dtp_wo_date_to"
        Me.dtp_wo_date_to.Size = New System.Drawing.Size(157, 22)
        Me.dtp_wo_date_to.TabIndex = 5
        Me.dtp_wo_date_to.Value = New Date(2015, 1, 15, 8, 32, 35, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(252, 105)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 19)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "~"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(252, 130)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 19)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "~"
        '
        'lbl_today_date
        '
        Me.lbl_today_date.Location = New System.Drawing.Point(600, 1)
        Me.lbl_today_date.Name = "lbl_today_date"
        Me.lbl_today_date.Size = New System.Drawing.Size(289, 16)
        Me.lbl_today_date.TabIndex = 50
        Me.lbl_today_date.Text = "User ID: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today_date.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frm_PRS002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 442)
        Me.Controls.Add(Me.lbl_today_date)
        Me.Controls.Add(Me.dtp_wo_date_to)
        Me.Controls.Add(Me.dtp_wo_date_from)
        Me.Controls.Add(Me.grd_product_inquiry)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_popup_item)
        Me.Controls.Add(Me.txt_item_name)
        Me.Controls.Add(Me.txt_barcode_to)
        Me.Controls.Add(Me.txt_barcode_from)
        Me.Controls.Add(Me.txt_wo_no)
        Me.Controls.Add(Me.txt_item_code)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_barcode)
        Me.Controls.Add(Me.lbl_wo_date)
        Me.Controls.Add(Me.lbl_wo_no)
        Me.Controls.Add(Me.lbl_exp_mode)
        Me.Controls.Add(Me.lbl_item_code)
        Me.Controls.Add(Me.rdo_reissue)
        Me.Controls.Add(Me.rdo_exp_new)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_PRS002"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Information Inquiry"
        CType(Me.grd_product_inquiry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdo_reissue As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_exp_new As System.Windows.Forms.RadioButton
    Friend WithEvents btn_popup_item As System.Windows.Forms.Button
    Friend WithEvents txt_item_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_item_code As System.Windows.Forms.TextBox
    Friend WithEvents lbl_item_code As System.Windows.Forms.Label
    Friend WithEvents grd_product_inquiry As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents lbl_wo_no As System.Windows.Forms.Label
    Friend WithEvents lbl_wo_date As System.Windows.Forms.Label
    Friend WithEvents lbl_barcode As System.Windows.Forms.Label
    Friend WithEvents txt_wo_no As System.Windows.Forms.TextBox
    Friend WithEvents txt_barcode_from As System.Windows.Forms.TextBox
    Friend WithEvents lbl_exp_mode As System.Windows.Forms.Label
    Friend WithEvents txt_barcode_to As System.Windows.Forms.TextBox
    Friend WithEvents dtp_wo_date_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_wo_date_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents sfdDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl_today_date As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
