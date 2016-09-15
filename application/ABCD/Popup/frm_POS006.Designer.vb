<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_POS006
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_POS006))
        Me.grd_pd_info = New System.Windows.Forms.DataGridView
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.txt_wo_no = New System.Windows.Forms.TextBox
        Me.lbl_wo_no = New System.Windows.Forms.Label
        Me.sfDialog = New System.Windows.Forms.SaveFileDialog
        Me.txt_item_name = New System.Windows.Forms.TextBox
        Me.btn_popup_item = New System.Windows.Forms.Button
        Me.txt_item_cd = New System.Windows.Forms.TextBox
        Me.lbl_item_cd = New System.Windows.Forms.Label
        Me.dtp_wo_date_to = New System.Windows.Forms.DateTimePicker
        Me.dtp_wo_date_from = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_wh_code = New System.Windows.Forms.Label
        Me.txt_pd_qty = New System.Windows.Forms.TextBox
        Me.lbl_pd_qty = New System.Windows.Forms.Label
        Me.txt_total_box = New System.Windows.Forms.TextBox
        Me.lbl_total_box = New System.Windows.Forms.Label
        CType(Me.grd_pd_info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd_pd_info
        '
        Me.grd_pd_info.AllowUserToAddRows = False
        Me.grd_pd_info.AllowUserToDeleteRows = False
        Me.grd_pd_info.AllowUserToResizeRows = False
        Me.grd_pd_info.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_pd_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_pd_info.Location = New System.Drawing.Point(12, 124)
        Me.grd_pd_info.Name = "grd_pd_info"
        Me.grd_pd_info.ReadOnly = True
        Me.grd_pd_info.RowHeadersVisible = False
        Me.grd_pd_info.RowTemplate.Height = 24
        Me.grd_pd_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_pd_info.Size = New System.Drawing.Size(805, 283)
        Me.grd_pd_info.TabIndex = 10
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(742, 96)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 9
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_clear.Location = New System.Drawing.Point(661, 417)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 22)
        Me.btn_clear.TabIndex = 11
        Me.btn_clear.Text = "Cancel"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(742, 417)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 12
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'txt_wo_no
        '
        Me.txt_wo_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_wo_no.Location = New System.Drawing.Point(119, 12)
        Me.txt_wo_no.MaxLength = 10
        Me.txt_wo_no.Name = "txt_wo_no"
        Me.txt_wo_no.Size = New System.Drawing.Size(141, 22)
        Me.txt_wo_no.TabIndex = 1
        '
        'lbl_wo_no
        '
        Me.lbl_wo_no.AutoSize = True
        Me.lbl_wo_no.Location = New System.Drawing.Point(9, 15)
        Me.lbl_wo_no.Name = "lbl_wo_no"
        Me.lbl_wo_no.Size = New System.Drawing.Size(47, 14)
        Me.lbl_wo_no.TabIndex = 31
        Me.lbl_wo_no.Text = "WO No" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txt_item_name
        '
        Me.txt_item_name.Location = New System.Drawing.Point(333, 40)
        Me.txt_item_name.MaxLength = 100
        Me.txt_item_name.Name = "txt_item_name"
        Me.txt_item_name.ReadOnly = True
        Me.txt_item_name.Size = New System.Drawing.Size(401, 22)
        Me.txt_item_name.TabIndex = 4
        '
        'btn_popup_item
        '
        Me.btn_popup_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_item.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_popup_item.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_popup_item.Location = New System.Drawing.Point(303, 40)
        Me.btn_popup_item.Name = "btn_popup_item"
        Me.btn_popup_item.Size = New System.Drawing.Size(24, 22)
        Me.btn_popup_item.TabIndex = 3
        Me.btn_popup_item.Text = "?"
        Me.btn_popup_item.UseVisualStyleBackColor = False
        '
        'txt_item_cd
        '
        Me.txt_item_cd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_item_cd.Location = New System.Drawing.Point(119, 40)
        Me.txt_item_cd.MaxLength = 50
        Me.txt_item_cd.Name = "txt_item_cd"
        Me.txt_item_cd.Size = New System.Drawing.Size(178, 22)
        Me.txt_item_cd.TabIndex = 2
        '
        'lbl_item_cd
        '
        Me.lbl_item_cd.AutoSize = True
        Me.lbl_item_cd.Location = New System.Drawing.Point(12, 43)
        Me.lbl_item_cd.Name = "lbl_item_cd"
        Me.lbl_item_cd.Size = New System.Drawing.Size(33, 14)
        Me.lbl_item_cd.TabIndex = 58
        Me.lbl_item_cd.Text = "Item"
        '
        'dtp_wo_date_to
        '
        Me.dtp_wo_date_to.CustomFormat = "dd/MM/yyyy"
        Me.dtp_wo_date_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_wo_date_to.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtp_wo_date_to.Location = New System.Drawing.Point(288, 68)
        Me.dtp_wo_date_to.Name = "dtp_wo_date_to"
        Me.dtp_wo_date_to.Size = New System.Drawing.Size(141, 22)
        Me.dtp_wo_date_to.TabIndex = 6
        Me.dtp_wo_date_to.Value = New Date(2015, 1, 13, 8, 56, 2, 0)
        '
        'dtp_wo_date_from
        '
        Me.dtp_wo_date_from.CustomFormat = "dd/MM/yyyy"
        Me.dtp_wo_date_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_wo_date_from.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtp_wo_date_from.Location = New System.Drawing.Point(119, 68)
        Me.dtp_wo_date_from.Name = "dtp_wo_date_from"
        Me.dtp_wo_date_from.Size = New System.Drawing.Size(141, 22)
        Me.dtp_wo_date_from.TabIndex = 5
        Me.dtp_wo_date_from.Value = New Date(2015, 1, 13, 8, 56, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(266, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 14)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "~"
        '
        'lbl_wh_code
        '
        Me.lbl_wh_code.AutoSize = True
        Me.lbl_wh_code.Location = New System.Drawing.Point(12, 71)
        Me.lbl_wh_code.Name = "lbl_wh_code"
        Me.lbl_wh_code.Size = New System.Drawing.Size(63, 14)
        Me.lbl_wh_code.TabIndex = 62
        Me.lbl_wh_code.Text = "W/O Date" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txt_pd_qty
        '
        Me.txt_pd_qty.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_pd_qty.Location = New System.Drawing.Point(119, 96)
        Me.txt_pd_qty.MaxLength = 9
        Me.txt_pd_qty.Name = "txt_pd_qty"
        Me.txt_pd_qty.Size = New System.Drawing.Size(141, 22)
        Me.txt_pd_qty.TabIndex = 8
        Me.txt_pd_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_pd_qty
        '
        Me.lbl_pd_qty.AutoSize = True
        Me.lbl_pd_qty.Location = New System.Drawing.Point(12, 99)
        Me.lbl_pd_qty.Name = "lbl_pd_qty"
        Me.lbl_pd_qty.Size = New System.Drawing.Size(101, 14)
        Me.lbl_pd_qty.TabIndex = 31
        Me.lbl_pd_qty.Text = "Product Quantity" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txt_total_box
        '
        Me.txt_total_box.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_total_box.Location = New System.Drawing.Point(587, 68)
        Me.txt_total_box.MaxLength = 4
        Me.txt_total_box.Name = "txt_total_box"
        Me.txt_total_box.Size = New System.Drawing.Size(145, 22)
        Me.txt_total_box.TabIndex = 7
        Me.txt_total_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_total_box
        '
        Me.lbl_total_box.AutoSize = True
        Me.lbl_total_box.Location = New System.Drawing.Point(522, 71)
        Me.lbl_total_box.Name = "lbl_total_box"
        Me.lbl_total_box.Size = New System.Drawing.Size(59, 14)
        Me.lbl_total_box.TabIndex = 31
        Me.lbl_total_box.Text = "Total Box" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'frm_POS006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 450)
        Me.Controls.Add(Me.dtp_wo_date_to)
        Me.Controls.Add(Me.dtp_wo_date_from)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_wh_code)
        Me.Controls.Add(Me.txt_item_name)
        Me.Controls.Add(Me.btn_popup_item)
        Me.Controls.Add(Me.txt_item_cd)
        Me.Controls.Add(Me.lbl_item_cd)
        Me.Controls.Add(Me.lbl_total_box)
        Me.Controls.Add(Me.lbl_pd_qty)
        Me.Controls.Add(Me.lbl_wo_no)
        Me.Controls.Add(Me.txt_total_box)
        Me.Controls.Add(Me.txt_pd_qty)
        Me.Controls.Add(Me.txt_wo_no)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.grd_pd_info)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_POS006"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup Select Product Info"
        CType(Me.grd_pd_info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_pd_info As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents txt_wo_no As System.Windows.Forms.TextBox
    Friend WithEvents lbl_wo_no As System.Windows.Forms.Label
    Friend WithEvents sfDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txt_item_name As System.Windows.Forms.TextBox
    Friend WithEvents btn_popup_item As System.Windows.Forms.Button
    Friend WithEvents txt_item_cd As System.Windows.Forms.TextBox
    Friend WithEvents lbl_item_cd As System.Windows.Forms.Label
    Friend WithEvents dtp_wo_date_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_wo_date_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_wh_code As System.Windows.Forms.Label
    Friend WithEvents txt_pd_qty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_pd_qty As System.Windows.Forms.Label
    Friend WithEvents txt_total_box As System.Windows.Forms.TextBox
    Friend WithEvents lbl_total_box As System.Windows.Forms.Label
End Class
