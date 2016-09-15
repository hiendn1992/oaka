<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_STS001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_STS001))
        Me.lb_today = New System.Windows.Forms.Label
        Me.tb_item_code = New System.Windows.Forms.TextBox
        Me.b_popup_item = New System.Windows.Forms.Button
        Me.tb_item_name = New System.Windows.Forms.TextBox
        Me.lb_stock_date = New System.Windows.Forms.Label
        Me.dtp_stock_date = New System.Windows.Forms.DateTimePicker
        Me.lb_warehouse_code = New System.Windows.Forms.Label
        Me.lb_item_code = New System.Windows.Forms.Label
        Me.b_execute = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.cb_warehouse = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Location = New System.Drawing.Point(548, 2)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(239, 15)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tb_item_code
        '
        Me.tb_item_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_code.Location = New System.Drawing.Point(119, 44)
        Me.tb_item_code.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_code.MaxLength = 25
        Me.tb_item_code.Name = "tb_item_code"
        Me.tb_item_code.Size = New System.Drawing.Size(130, 22)
        Me.tb_item_code.TabIndex = 2
        '
        'b_popup_item
        '
        Me.b_popup_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_popup_item.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_item.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_item.Location = New System.Drawing.Point(255, 44)
        Me.b_popup_item.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_item.Name = "b_popup_item"
        Me.b_popup_item.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_item.TabIndex = 3
        Me.b_popup_item.Text = "?"
        Me.b_popup_item.UseVisualStyleBackColor = False
        '
        'tb_item_name
        '
        Me.tb_item_name.Enabled = False
        Me.tb_item_name.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_name.Location = New System.Drawing.Point(285, 44)
        Me.tb_item_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_name.MaxLength = 50
        Me.tb_item_name.Name = "tb_item_name"
        Me.tb_item_name.Size = New System.Drawing.Size(340, 22)
        Me.tb_item_name.TabIndex = 4
        '
        'lb_stock_date
        '
        Me.lb_stock_date.AutoSize = True
        Me.lb_stock_date.Location = New System.Drawing.Point(12, 24)
        Me.lb_stock_date.Name = "lb_stock_date"
        Me.lb_stock_date.Size = New System.Drawing.Size(101, 14)
        Me.lb_stock_date.TabIndex = 9
        Me.lb_stock_date.Text = "Stocktaking Date"
        '
        'dtp_stock_date
        '
        Me.dtp_stock_date.CustomFormat = " "
        Me.dtp_stock_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_stock_date.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtp_stock_date.Location = New System.Drawing.Point(119, 18)
        Me.dtp_stock_date.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtp_stock_date.Name = "dtp_stock_date"
        Me.dtp_stock_date.Size = New System.Drawing.Size(130, 22)
        Me.dtp_stock_date.TabIndex = 1
        '
        'lb_warehouse_code
        '
        Me.lb_warehouse_code.AutoSize = True
        Me.lb_warehouse_code.Location = New System.Drawing.Point(12, 73)
        Me.lb_warehouse_code.Name = "lb_warehouse_code"
        Me.lb_warehouse_code.Size = New System.Drawing.Size(101, 14)
        Me.lb_warehouse_code.TabIndex = 11
        Me.lb_warehouse_code.Text = "Warehouse Code"
        '
        'lb_item_code
        '
        Me.lb_item_code.AutoSize = True
        Me.lb_item_code.Location = New System.Drawing.Point(12, 49)
        Me.lb_item_code.Name = "lb_item_code"
        Me.lb_item_code.Size = New System.Drawing.Size(33, 14)
        Me.lb_item_code.TabIndex = 12
        Me.lb_item_code.Text = "Item"
        '
        'b_execute
        '
        Me.b_execute.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_execute.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_execute.Location = New System.Drawing.Point(631, 99)
        Me.b_execute.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_execute.Name = "b_execute"
        Me.b_execute.Size = New System.Drawing.Size(75, 22)
        Me.b_execute.TabIndex = 6
        Me.b_execute.Text = "Execute"
        Me.b_execute.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(712, 99)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 7
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'cb_warehouse
        '
        Me.cb_warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_warehouse.FormattingEnabled = True
        Me.cb_warehouse.Location = New System.Drawing.Point(119, 70)
        Me.cb_warehouse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cb_warehouse.Name = "cb_warehouse"
        Me.cb_warehouse.Size = New System.Drawing.Size(130, 22)
        Me.cb_warehouse.TabIndex = 5
        '
        'frm_STS001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 127)
        Me.Controls.Add(Me.cb_warehouse)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_execute)
        Me.Controls.Add(Me.lb_item_code)
        Me.Controls.Add(Me.lb_warehouse_code)
        Me.Controls.Add(Me.dtp_stock_date)
        Me.Controls.Add(Me.lb_stock_date)
        Me.Controls.Add(Me.tb_item_name)
        Me.Controls.Add(Me.b_popup_item)
        Me.Controls.Add(Me.tb_item_code)
        Me.Controls.Add(Me.lb_today)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_STS001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stocktaking Condition Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents tb_item_code As System.Windows.Forms.TextBox
    Friend WithEvents b_popup_item As System.Windows.Forms.Button
    Friend WithEvents tb_item_name As System.Windows.Forms.TextBox
    Friend WithEvents lb_stock_date As System.Windows.Forms.Label
    Friend WithEvents dtp_stock_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents lb_warehouse_code As System.Windows.Forms.Label
    Friend WithEvents lb_item_code As System.Windows.Forms.Label
    Friend WithEvents b_execute As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents cb_warehouse As System.Windows.Forms.ComboBox
End Class
