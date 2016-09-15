<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_POS001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_POS001))
        Me.b_search = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.dgv_lst_item = New System.Windows.Forms.DataGridView
        Me.tb_item_name = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_item_code = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_quantity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tb_cus_id = New System.Windows.Forms.TextBox
        Me.tb_cus_nm = New System.Windows.Forms.TextBox
        Me.b_popup_cus = New System.Windows.Forms.Button
        CType(Me.dgv_lst_item, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'b_search
        '
        Me.b_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_search.Location = New System.Drawing.Point(704, 95)
        Me.b_search.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_search.Name = "b_search"
        Me.b_search.Size = New System.Drawing.Size(75, 22)
        Me.b_search.TabIndex = 5
        Me.b_search.Text = "Search"
        Me.b_search.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(623, 394)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 7
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(704, 394)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 8
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'dgv_lst_item
        '
        Me.dgv_lst_item.AllowUserToAddRows = False
        Me.dgv_lst_item.AllowUserToDeleteRows = False
        Me.dgv_lst_item.AllowUserToResizeRows = False
        Me.dgv_lst_item.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_lst_item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lst_item.Location = New System.Drawing.Point(12, 121)
        Me.dgv_lst_item.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgv_lst_item.Name = "dgv_lst_item"
        Me.dgv_lst_item.ReadOnly = True
        Me.dgv_lst_item.RowHeadersVisible = False
        Me.dgv_lst_item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_lst_item.Size = New System.Drawing.Size(767, 269)
        Me.dgv_lst_item.TabIndex = 6
        Me.dgv_lst_item.TabStop = False
        '
        'tb_item_name
        '
        Me.tb_item_name.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_item_name.Location = New System.Drawing.Point(378, 12)
        Me.tb_item_name.MaxLength = 100
        Me.tb_item_name.Name = "tb_item_name"
        Me.tb_item_name.Size = New System.Drawing.Size(401, 22)
        Me.tb_item_name.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(304, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Item Name"
        '
        'tb_item_code
        '
        Me.tb_item_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_code.Location = New System.Drawing.Point(83, 12)
        Me.tb_item_code.MaxLength = 50
        Me.tb_item_code.Name = "tb_item_code"
        Me.tb_item_code.Size = New System.Drawing.Size(182, 22)
        Me.tb_item_code.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Item Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Quantity"
        '
        'tb_quantity
        '
        Me.tb_quantity.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_quantity.Location = New System.Drawing.Point(83, 68)
        Me.tb_quantity.MaxLength = 4
        Me.tb_quantity.Name = "tb_quantity"
        Me.tb_quantity.Size = New System.Drawing.Size(100, 22)
        Me.tb_quantity.TabIndex = 4
        Me.tb_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Customer"
        '
        'tb_cus_id
        '
        Me.tb_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_id.Location = New System.Drawing.Point(83, 40)
        Me.tb_cus_id.MaxLength = 10
        Me.tb_cus_id.Name = "tb_cus_id"
        Me.tb_cus_id.Size = New System.Drawing.Size(100, 22)
        Me.tb_cus_id.TabIndex = 3
        '
        'tb_cus_nm
        '
        Me.tb_cus_nm.Enabled = False
        Me.tb_cus_nm.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_nm.Location = New System.Drawing.Point(218, 40)
        Me.tb_cus_nm.MaxLength = 50
        Me.tb_cus_nm.Name = "tb_cus_nm"
        Me.tb_cus_nm.Size = New System.Drawing.Size(344, 22)
        Me.tb_cus_nm.TabIndex = 14
        Me.tb_cus_nm.TabStop = False
        '
        'b_popup_cus
        '
        Me.b_popup_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_popup_cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_cus.Location = New System.Drawing.Point(189, 40)
        Me.b_popup_cus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_cus.Name = "b_popup_cus"
        Me.b_popup_cus.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_cus.TabIndex = 25
        Me.b_popup_cus.TabStop = False
        Me.b_popup_cus.Text = "?"
        Me.b_popup_cus.UseVisualStyleBackColor = False
        '
        'frm_POS001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 423)
        Me.Controls.Add(Me.b_popup_cus)
        Me.Controls.Add(Me.tb_cus_nm)
        Me.Controls.Add(Me.tb_cus_id)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tb_quantity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_item_code)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_item_name)
        Me.Controls.Add(Me.dgv_lst_item)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_search)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_POS001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup Select Item Info"
        CType(Me.dgv_lst_item, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_search As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents dgv_lst_item As System.Windows.Forms.DataGridView
    Friend WithEvents tb_item_name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_item_code As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_quantity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents tb_cus_nm As System.Windows.Forms.TextBox
    Friend WithEvents b_popup_cus As System.Windows.Forms.Button
End Class
