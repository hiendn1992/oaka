<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS007
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS007))
        Me.dgv_lst_item_cus = New System.Windows.Forms.DataGridView
        Me.b_search = New System.Windows.Forms.Button
        Me.b_export = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.lbToday = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_item_code_from = New System.Windows.Forms.TextBox
        Me.tb_item_code_to = New System.Windows.Forms.TextBox
        Me.tb_item_name_from = New System.Windows.Forms.TextBox
        Me.tb_item_name_to = New System.Windows.Forms.TextBox
        Me.tb_cus_id = New System.Windows.Forms.TextBox
        Me.tb_cus_nm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tb_quantity = New System.Windows.Forms.TextBox
        Me.b_popup_item_from = New System.Windows.Forms.Button
        Me.b_popup_item_to = New System.Windows.Forms.Button
        Me.b_popup_cus = New System.Windows.Forms.Button
        Me.sfDialog = New System.Windows.Forms.SaveFileDialog
        CType(Me.dgv_lst_item_cus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_lst_item_cus
        '
        Me.dgv_lst_item_cus.AllowUserToAddRows = False
        Me.dgv_lst_item_cus.AllowUserToDeleteRows = False
        Me.dgv_lst_item_cus.AllowUserToResizeRows = False
        Me.dgv_lst_item_cus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_lst_item_cus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lst_item_cus.Location = New System.Drawing.Point(12, 111)
        Me.dgv_lst_item_cus.Name = "dgv_lst_item_cus"
        Me.dgv_lst_item_cus.ReadOnly = True
        Me.dgv_lst_item_cus.RowHeadersVisible = False
        Me.dgv_lst_item_cus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_lst_item_cus.Size = New System.Drawing.Size(855, 254)
        Me.dgv_lst_item_cus.TabIndex = 0
        Me.dgv_lst_item_cus.TabStop = False
        '
        'b_search
        '
        Me.b_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_search.Location = New System.Drawing.Point(792, 83)
        Me.b_search.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_search.Name = "b_search"
        Me.b_search.Size = New System.Drawing.Size(75, 22)
        Me.b_search.TabIndex = 5
        Me.b_search.Text = "Search"
        Me.b_search.UseVisualStyleBackColor = False
        '
        'b_export
        '
        Me.b_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.b_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_export.Location = New System.Drawing.Point(630, 370)
        Me.b_export.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_export.Name = "b_export"
        Me.b_export.Size = New System.Drawing.Size(75, 22)
        Me.b_export.TabIndex = 6
        Me.b_export.Text = "Export"
        Me.b_export.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(711, 370)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 7
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(792, 370)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 8
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'lbToday
        '
        Me.lbToday.Location = New System.Drawing.Point(629, 1)
        Me.lbToday.Name = "lbToday"
        Me.lbToday.Size = New System.Drawing.Size(238, 22)
        Me.lbToday.TabIndex = 22
        Me.lbToday.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbToday.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Item From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Item To"
        '
        'tb_item_code_from
        '
        Me.tb_item_code_from.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_code_from.Location = New System.Drawing.Point(91, 27)
        Me.tb_item_code_from.MaxLength = 50
        Me.tb_item_code_from.Name = "tb_item_code_from"
        Me.tb_item_code_from.Size = New System.Drawing.Size(182, 22)
        Me.tb_item_code_from.TabIndex = 1
        Me.tb_item_code_from.Text = "XXXXXXXXXXXXXXX"
        '
        'tb_item_code_to
        '
        Me.tb_item_code_to.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_code_to.Location = New System.Drawing.Point(91, 55)
        Me.tb_item_code_to.MaxLength = 50
        Me.tb_item_code_to.Name = "tb_item_code_to"
        Me.tb_item_code_to.Size = New System.Drawing.Size(182, 22)
        Me.tb_item_code_to.TabIndex = 2
        Me.tb_item_code_to.Text = "XXXXXXXXXXXXXXX"
        '
        'tb_item_name_from
        '
        Me.tb_item_name_from.Enabled = False
        Me.tb_item_name_from.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_name_from.Location = New System.Drawing.Point(309, 27)
        Me.tb_item_name_from.MaxLength = 100
        Me.tb_item_name_from.Name = "tb_item_name_from"
        Me.tb_item_name_from.Size = New System.Drawing.Size(401, 22)
        Me.tb_item_name_from.TabIndex = 27
        Me.tb_item_name_from.TabStop = False
        Me.tb_item_name_from.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'tb_item_name_to
        '
        Me.tb_item_name_to.Enabled = False
        Me.tb_item_name_to.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_name_to.Location = New System.Drawing.Point(309, 56)
        Me.tb_item_name_to.MaxLength = 100
        Me.tb_item_name_to.Name = "tb_item_name_to"
        Me.tb_item_name_to.Size = New System.Drawing.Size(401, 22)
        Me.tb_item_name_to.TabIndex = 28
        Me.tb_item_name_to.TabStop = False
        Me.tb_item_name_to.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'tb_cus_id
        '
        Me.tb_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_id.Location = New System.Drawing.Point(91, 83)
        Me.tb_cus_id.MaxLength = 10
        Me.tb_cus_id.Name = "tb_cus_id"
        Me.tb_cus_id.Size = New System.Drawing.Size(182, 22)
        Me.tb_cus_id.TabIndex = 3
        Me.tb_cus_id.Text = "XXXXXXXX"
        '
        'tb_cus_nm
        '
        Me.tb_cus_nm.Enabled = False
        Me.tb_cus_nm.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_nm.Location = New System.Drawing.Point(309, 83)
        Me.tb_cus_nm.MaxLength = 50
        Me.tb_cus_nm.Name = "tb_cus_nm"
        Me.tb_cus_nm.Size = New System.Drawing.Size(235, 22)
        Me.tb_cus_nm.TabIndex = 30
        Me.tb_cus_nm.TabStop = False
        Me.tb_cus_nm.Text = "XXXXXXXXXXXXXXXXXXXX"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Customer"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(571, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 14)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Quantity"
        '
        'tb_quantity
        '
        Me.tb_quantity.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_quantity.Location = New System.Drawing.Point(628, 82)
        Me.tb_quantity.MaxLength = 4
        Me.tb_quantity.Name = "tb_quantity"
        Me.tb_quantity.Size = New System.Drawing.Size(82, 22)
        Me.tb_quantity.TabIndex = 4
        Me.tb_quantity.Text = "X,XXX"
        Me.tb_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'b_popup_item_from
        '
        Me.b_popup_item_from.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.b_popup_item_from.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_item_from.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_item_from.Location = New System.Drawing.Point(279, 27)
        Me.b_popup_item_from.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_item_from.Name = "b_popup_item_from"
        Me.b_popup_item_from.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_item_from.TabIndex = 38
        Me.b_popup_item_from.TabStop = False
        Me.b_popup_item_from.Text = "?"
        Me.b_popup_item_from.UseVisualStyleBackColor = False
        '
        'b_popup_item_to
        '
        Me.b_popup_item_to.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.b_popup_item_to.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_item_to.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_item_to.Location = New System.Drawing.Point(279, 55)
        Me.b_popup_item_to.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_item_to.Name = "b_popup_item_to"
        Me.b_popup_item_to.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_item_to.TabIndex = 39
        Me.b_popup_item_to.TabStop = False
        Me.b_popup_item_to.Text = "?"
        Me.b_popup_item_to.UseVisualStyleBackColor = False
        '
        'b_popup_cus
        '
        Me.b_popup_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.b_popup_cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_cus.Location = New System.Drawing.Point(279, 82)
        Me.b_popup_cus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_cus.Name = "b_popup_cus"
        Me.b_popup_cus.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_cus.TabIndex = 40
        Me.b_popup_cus.TabStop = False
        Me.b_popup_cus.Text = "?"
        Me.b_popup_cus.UseVisualStyleBackColor = False
        '
        'frm_MSS007
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 396)
        Me.Controls.Add(Me.b_popup_cus)
        Me.Controls.Add(Me.b_popup_item_to)
        Me.Controls.Add(Me.b_popup_item_from)
        Me.Controls.Add(Me.tb_quantity)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_cus_nm)
        Me.Controls.Add(Me.tb_cus_id)
        Me.Controls.Add(Me.tb_item_name_to)
        Me.Controls.Add(Me.tb_item_name_from)
        Me.Controls.Add(Me.tb_item_code_to)
        Me.Controls.Add(Me.tb_item_code_from)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbToday)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_export)
        Me.Controls.Add(Me.b_search)
        Me.Controls.Add(Me.dgv_lst_item_cus)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS007"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Master Inquiry"
        CType(Me.dgv_lst_item_cus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_lst_item_cus As System.Windows.Forms.DataGridView
    Friend WithEvents b_search As System.Windows.Forms.Button
    Friend WithEvents b_export As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents lbToday As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_item_code_from As System.Windows.Forms.TextBox
    Friend WithEvents tb_item_code_to As System.Windows.Forms.TextBox
    Friend WithEvents tb_item_name_from As System.Windows.Forms.TextBox
    Friend WithEvents tb_item_name_to As System.Windows.Forms.TextBox
    Friend WithEvents tb_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents tb_cus_nm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_quantity As System.Windows.Forms.TextBox
    Friend WithEvents b_popup_item_from As System.Windows.Forms.Button
    Friend WithEvents b_popup_item_to As System.Windows.Forms.Button
    Friend WithEvents b_popup_cus As System.Windows.Forms.Button
    Friend WithEvents sfDialog As System.Windows.Forms.SaveFileDialog
End Class
