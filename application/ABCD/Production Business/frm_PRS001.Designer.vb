<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PRS001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PRS001))
        Me.lb_today = New System.Windows.Forms.Label
        Me.rdo_add_product = New System.Windows.Forms.RadioButton
        Me.rdo_change_product = New System.Windows.Forms.RadioButton
        Me.rdo_delete_product = New System.Windows.Forms.RadioButton
        Me.tb_wo_no = New System.Windows.Forms.TextBox
        Me.b_popup_wo_no = New System.Windows.Forms.Button
        Me.tb_item_code = New System.Windows.Forms.TextBox
        Me.b_popup_item_code = New System.Windows.Forms.Button
        Me.tb_item_name = New System.Windows.Forms.TextBox
        Me.lb_wo_no = New System.Windows.Forms.Label
        Me.lb_item_code = New System.Windows.Forms.Label
        Me.lb_wo_date = New System.Windows.Forms.Label
        Me.lb_product_quantity = New System.Windows.Forms.Label
        Me.tb_product_quantity = New System.Windows.Forms.TextBox
        Me.tb_quantity_box = New System.Windows.Forms.TextBox
        Me.lb_quantity_box = New System.Windows.Forms.Label
        Me.tb_total_box = New System.Windows.Forms.TextBox
        Me.lb_total_box = New System.Windows.Forms.Label
        Me.b_exec = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.dtp_wo_date = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tb_from_box_number = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lb_issue = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Location = New System.Drawing.Point(521, 2)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(243, 17)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rdo_add_product
        '
        Me.rdo_add_product.AutoSize = True
        Me.rdo_add_product.Location = New System.Drawing.Point(12, 19)
        Me.rdo_add_product.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdo_add_product.Name = "rdo_add_product"
        Me.rdo_add_product.Size = New System.Drawing.Size(47, 18)
        Me.rdo_add_product.TabIndex = 1
        Me.rdo_add_product.Text = "Add"
        Me.rdo_add_product.UseVisualStyleBackColor = True
        '
        'rdo_change_product
        '
        Me.rdo_change_product.AutoSize = True
        Me.rdo_change_product.Location = New System.Drawing.Point(65, 19)
        Me.rdo_change_product.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdo_change_product.Name = "rdo_change_product"
        Me.rdo_change_product.Size = New System.Drawing.Size(66, 18)
        Me.rdo_change_product.TabIndex = 2
        Me.rdo_change_product.Text = "Change"
        Me.rdo_change_product.UseVisualStyleBackColor = True
        '
        'rdo_delete_product
        '
        Me.rdo_delete_product.AutoSize = True
        Me.rdo_delete_product.Location = New System.Drawing.Point(137, 19)
        Me.rdo_delete_product.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdo_delete_product.Name = "rdo_delete_product"
        Me.rdo_delete_product.Size = New System.Drawing.Size(61, 18)
        Me.rdo_delete_product.TabIndex = 3
        Me.rdo_delete_product.Text = "Delete"
        Me.rdo_delete_product.UseVisualStyleBackColor = True
        '
        'tb_wo_no
        '
        Me.tb_wo_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_wo_no.Location = New System.Drawing.Point(129, 41)
        Me.tb_wo_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_wo_no.MaxLength = 10
        Me.tb_wo_no.Name = "tb_wo_no"
        Me.tb_wo_no.Size = New System.Drawing.Size(131, 22)
        Me.tb_wo_no.TabIndex = 1
        '
        'b_popup_wo_no
        '
        Me.b_popup_wo_no.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_popup_wo_no.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_wo_no.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_wo_no.Location = New System.Drawing.Point(266, 41)
        Me.b_popup_wo_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_wo_no.Name = "b_popup_wo_no"
        Me.b_popup_wo_no.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_wo_no.TabIndex = 2
        Me.b_popup_wo_no.Text = "?"
        Me.b_popup_wo_no.UseVisualStyleBackColor = False
        '
        'tb_item_code
        '
        Me.tb_item_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_code.Location = New System.Drawing.Point(129, 67)
        Me.tb_item_code.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_code.MaxLength = 50
        Me.tb_item_code.Name = "tb_item_code"
        Me.tb_item_code.Size = New System.Drawing.Size(182, 22)
        Me.tb_item_code.TabIndex = 4
        '
        'b_popup_item_code
        '
        Me.b_popup_item_code.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_popup_item_code.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_item_code.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_item_code.Location = New System.Drawing.Point(317, 67)
        Me.b_popup_item_code.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_popup_item_code.Name = "b_popup_item_code"
        Me.b_popup_item_code.Size = New System.Drawing.Size(23, 22)
        Me.b_popup_item_code.TabIndex = 5
        Me.b_popup_item_code.TabStop = False
        Me.b_popup_item_code.Text = "?"
        Me.b_popup_item_code.UseVisualStyleBackColor = False
        '
        'tb_item_name
        '
        Me.tb_item_name.Location = New System.Drawing.Point(346, 67)
        Me.tb_item_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_name.MaxLength = 100
        Me.tb_item_name.Name = "tb_item_name"
        Me.tb_item_name.ReadOnly = True
        Me.tb_item_name.Size = New System.Drawing.Size(417, 22)
        Me.tb_item_name.TabIndex = 5
        Me.tb_item_name.TabStop = False
        '
        'lb_wo_no
        '
        Me.lb_wo_no.AutoSize = True
        Me.lb_wo_no.Location = New System.Drawing.Point(12, 46)
        Me.lb_wo_no.Name = "lb_wo_no"
        Me.lb_wo_no.Size = New System.Drawing.Size(52, 14)
        Me.lb_wo_no.TabIndex = 9
        Me.lb_wo_no.Text = "W/O No"
        '
        'lb_item_code
        '
        Me.lb_item_code.AutoSize = True
        Me.lb_item_code.Location = New System.Drawing.Point(12, 71)
        Me.lb_item_code.Name = "lb_item_code"
        Me.lb_item_code.Size = New System.Drawing.Size(33, 14)
        Me.lb_item_code.TabIndex = 10
        Me.lb_item_code.Text = "Item"
        '
        'lb_wo_date
        '
        Me.lb_wo_date.AutoSize = True
        Me.lb_wo_date.Location = New System.Drawing.Point(314, 44)
        Me.lb_wo_date.Name = "lb_wo_date"
        Me.lb_wo_date.Size = New System.Drawing.Size(63, 14)
        Me.lb_wo_date.TabIndex = 12
        Me.lb_wo_date.Text = "W/O Date"
        '
        'lb_product_quantity
        '
        Me.lb_product_quantity.AutoSize = True
        Me.lb_product_quantity.Location = New System.Drawing.Point(12, 96)
        Me.lb_product_quantity.Name = "lb_product_quantity"
        Me.lb_product_quantity.Size = New System.Drawing.Size(101, 14)
        Me.lb_product_quantity.TabIndex = 13
        Me.lb_product_quantity.Text = "Product Quantity"
        '
        'tb_product_quantity
        '
        Me.tb_product_quantity.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_product_quantity.Location = New System.Drawing.Point(129, 93)
        Me.tb_product_quantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_product_quantity.MaxLength = 9
        Me.tb_product_quantity.Name = "tb_product_quantity"
        Me.tb_product_quantity.Size = New System.Drawing.Size(131, 22)
        Me.tb_product_quantity.TabIndex = 6
        Me.tb_product_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb_quantity_box
        '
        Me.tb_quantity_box.Enabled = False
        Me.tb_quantity_box.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_quantity_box.Location = New System.Drawing.Point(393, 93)
        Me.tb_quantity_box.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_quantity_box.MaxLength = 4
        Me.tb_quantity_box.Name = "tb_quantity_box"
        Me.tb_quantity_box.Size = New System.Drawing.Size(93, 22)
        Me.tb_quantity_box.TabIndex = 7
        Me.tb_quantity_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lb_quantity_box
        '
        Me.lb_quantity_box.AutoSize = True
        Me.lb_quantity_box.Location = New System.Drawing.Point(314, 96)
        Me.lb_quantity_box.Name = "lb_quantity_box"
        Me.lb_quantity_box.Size = New System.Drawing.Size(52, 14)
        Me.lb_quantity_box.TabIndex = 16
        Me.lb_quantity_box.Text = "Qty/Box"
        '
        'tb_total_box
        '
        Me.tb_total_box.Location = New System.Drawing.Point(129, 119)
        Me.tb_total_box.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_total_box.MaxLength = 4
        Me.tb_total_box.Name = "tb_total_box"
        Me.tb_total_box.ReadOnly = True
        Me.tb_total_box.Size = New System.Drawing.Size(131, 22)
        Me.tb_total_box.TabIndex = 8
        Me.tb_total_box.TabStop = False
        Me.tb_total_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lb_total_box
        '
        Me.lb_total_box.AutoSize = True
        Me.lb_total_box.Location = New System.Drawing.Point(12, 122)
        Me.lb_total_box.Name = "lb_total_box"
        Me.lb_total_box.Size = New System.Drawing.Size(59, 14)
        Me.lb_total_box.TabIndex = 18
        Me.lb_total_box.Text = "Total Box"
        '
        'b_exec
        '
        Me.b_exec.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exec.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exec.Location = New System.Drawing.Point(553, 140)
        Me.b_exec.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exec.Name = "b_exec"
        Me.b_exec.Size = New System.Drawing.Size(66, 20)
        Me.b_exec.TabIndex = 9
        Me.b_exec.Text = "Execute"
        Me.b_exec.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(625, 140)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(66, 20)
        Me.b_cancel.TabIndex = 10
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(698, 140)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(66, 20)
        Me.b_exit.TabIndex = 11
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'dtp_wo_date
        '
        Me.dtp_wo_date.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtp_wo_date.CustomFormat = " "
        Me.dtp_wo_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_wo_date.Location = New System.Drawing.Point(393, 41)
        Me.dtp_wo_date.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtp_wo_date.Name = "dtp_wo_date"
        Me.dtp_wo_date.Size = New System.Drawing.Size(131, 22)
        Me.dtp_wo_date.TabIndex = 3
        Me.dtp_wo_date.Value = New Date(2015, 1, 13, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(61, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 14)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(42, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 14)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(373, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 14)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(109, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 14)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(362, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(521, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 14)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "From Box Number"
        '
        'tb_from_box_number
        '
        Me.tb_from_box_number.Enabled = False
        Me.tb_from_box_number.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_from_box_number.Location = New System.Drawing.Point(632, 93)
        Me.tb_from_box_number.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_from_box_number.Name = "tb_from_box_number"
        Me.tb_from_box_number.Size = New System.Drawing.Size(60, 22)
        Me.tb_from_box_number.TabIndex = 26
        Me.tb_from_box_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(550, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 14)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Production Status:"
        '
        'lb_issue
        '
        Me.lb_issue.AutoSize = True
        Me.lb_issue.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_issue.Location = New System.Drawing.Point(680, 43)
        Me.lb_issue.Name = "lb_issue"
        Me.lb_issue.Size = New System.Drawing.Size(13, 18)
        Me.lb_issue.TabIndex = 28
        Me.lb_issue.Text = "-"
        '
        'frm_PRS001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 166)
        Me.Controls.Add(Me.lb_issue)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tb_from_box_number)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_wo_date)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_exec)
        Me.Controls.Add(Me.lb_total_box)
        Me.Controls.Add(Me.tb_total_box)
        Me.Controls.Add(Me.lb_quantity_box)
        Me.Controls.Add(Me.tb_quantity_box)
        Me.Controls.Add(Me.tb_product_quantity)
        Me.Controls.Add(Me.lb_product_quantity)
        Me.Controls.Add(Me.lb_wo_date)
        Me.Controls.Add(Me.lb_item_code)
        Me.Controls.Add(Me.lb_wo_no)
        Me.Controls.Add(Me.tb_item_name)
        Me.Controls.Add(Me.b_popup_item_code)
        Me.Controls.Add(Me.tb_item_code)
        Me.Controls.Add(Me.b_popup_wo_no)
        Me.Controls.Add(Me.tb_wo_no)
        Me.Controls.Add(Me.rdo_delete_product)
        Me.Controls.Add(Me.rdo_change_product)
        Me.Controls.Add(Me.rdo_add_product)
        Me.Controls.Add(Me.lb_today)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_PRS001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Information Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents rdo_add_product As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_change_product As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_delete_product As System.Windows.Forms.RadioButton
    Friend WithEvents tb_wo_no As System.Windows.Forms.TextBox
    Friend WithEvents b_popup_wo_no As System.Windows.Forms.Button
    Friend WithEvents tb_item_code As System.Windows.Forms.TextBox
    Friend WithEvents b_popup_item_code As System.Windows.Forms.Button
    Friend WithEvents tb_item_name As System.Windows.Forms.TextBox
    Friend WithEvents lb_wo_no As System.Windows.Forms.Label
    Friend WithEvents lb_item_code As System.Windows.Forms.Label
    Friend WithEvents lb_wo_date As System.Windows.Forms.Label
    Friend WithEvents lb_product_quantity As System.Windows.Forms.Label
    Friend WithEvents tb_product_quantity As System.Windows.Forms.TextBox
    Friend WithEvents tb_quantity_box As System.Windows.Forms.TextBox
    Friend WithEvents lb_quantity_box As System.Windows.Forms.Label
    Friend WithEvents tb_total_box As System.Windows.Forms.TextBox
    Friend WithEvents lb_total_box As System.Windows.Forms.Label
    Friend WithEvents b_exec As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents dtp_wo_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_from_box_number As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lb_issue As System.Windows.Forms.Label
End Class
