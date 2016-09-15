<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_STS002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_STS002))
        Me.lbl_stock_date = New System.Windows.Forms.Label
        Me.lbl_item = New System.Windows.Forms.Label
        Me.lbl_wh = New System.Windows.Forms.Label
        Me.btn_print = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.lbl_stock_date_value = New System.Windows.Forms.Label
        Me.lbl_wh_code = New System.Windows.Forms.Label
        Me.lbl_wh_name = New System.Windows.Forms.Label
        Me.lbl_item_code = New System.Windows.Forms.Label
        Me.lbl_item_name = New System.Windows.Forms.Label
        Me.lbl_devide1 = New System.Windows.Forms.Label
        Me.lbl_devide2 = New System.Windows.Forms.Label
        Me.sfdDialog = New System.Windows.Forms.SaveFileDialog
        Me.lbl_today_date = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lbl_stock_date
        '
        Me.lbl_stock_date.AutoSize = True
        Me.lbl_stock_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stock_date.Location = New System.Drawing.Point(40, 27)
        Me.lbl_stock_date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_stock_date.Name = "lbl_stock_date"
        Me.lbl_stock_date.Size = New System.Drawing.Size(105, 14)
        Me.lbl_stock_date.TabIndex = 60
        Me.lbl_stock_date.Text = "Stocktaking Date:"
        '
        'lbl_item
        '
        Me.lbl_item.AutoSize = True
        Me.lbl_item.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_item.Location = New System.Drawing.Point(40, 47)
        Me.lbl_item.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_item.Name = "lbl_item"
        Me.lbl_item.Size = New System.Drawing.Size(37, 14)
        Me.lbl_item.TabIndex = 61
        Me.lbl_item.Text = "Item:"
        '
        'lbl_wh
        '
        Me.lbl_wh.AutoSize = True
        Me.lbl_wh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wh.Location = New System.Drawing.Point(40, 68)
        Me.lbl_wh.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_wh.Name = "lbl_wh"
        Me.lbl_wh.Size = New System.Drawing.Size(73, 14)
        Me.lbl_wh.TabIndex = 62
        Me.lbl_wh.Text = "Warehouse:"
        '
        'btn_print
        '
        Me.btn_print.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_print.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_print.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_print.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_print.Location = New System.Drawing.Point(605, 93)
        Me.btn_print.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(75, 22)
        Me.btn_print.TabIndex = 64
        Me.btn_print.Text = "Print"
        Me.btn_print.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_print.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(688, 93)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 65
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'lbl_stock_date_value
        '
        Me.lbl_stock_date_value.AutoSize = True
        Me.lbl_stock_date_value.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_stock_date_value.Location = New System.Drawing.Point(172, 27)
        Me.lbl_stock_date_value.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_stock_date_value.Name = "lbl_stock_date_value"
        Me.lbl_stock_date_value.Size = New System.Drawing.Size(73, 14)
        Me.lbl_stock_date_value.TabIndex = 60
        Me.lbl_stock_date_value.Text = "dd/MM/yyyy"
        '
        'lbl_wh_code
        '
        Me.lbl_wh_code.AutoSize = True
        Me.lbl_wh_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wh_code.Location = New System.Drawing.Point(172, 68)
        Me.lbl_wh_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_wh_code.Name = "lbl_wh_code"
        Me.lbl_wh_code.Size = New System.Drawing.Size(63, 14)
        Me.lbl_wh_code.TabIndex = 62
        Me.lbl_wh_code.Text = "XXXXXXXX"
        '
        'lbl_wh_name
        '
        Me.lbl_wh_name.AutoSize = True
        Me.lbl_wh_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wh_name.Location = New System.Drawing.Point(380, 68)
        Me.lbl_wh_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_wh_name.Name = "lbl_wh_name"
        Me.lbl_wh_name.Size = New System.Drawing.Size(175, 14)
        Me.lbl_wh_name.TabIndex = 60
        Me.lbl_wh_name.Text = "AAAAAAAAAAAAAAAAAAAAA"
        '
        'lbl_item_code
        '
        Me.lbl_item_code.AutoSize = True
        Me.lbl_item_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_item_code.Location = New System.Drawing.Point(172, 47)
        Me.lbl_item_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_item_code.Name = "lbl_item_code"
        Me.lbl_item_code.Size = New System.Drawing.Size(182, 14)
        Me.lbl_item_code.TabIndex = 62
        Me.lbl_item_code.Text = "0123456789012345678901234"
        '
        'lbl_item_name
        '
        Me.lbl_item_name.AutoSize = True
        Me.lbl_item_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_item_name.Location = New System.Drawing.Point(380, 47)
        Me.lbl_item_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_item_name.Name = "lbl_item_name"
        Me.lbl_item_name.Size = New System.Drawing.Size(357, 14)
        Me.lbl_item_name.TabIndex = 62
        Me.lbl_item_name.Text = "01234567890123456789012340123456789012345678901234"
        '
        'lbl_devide1
        '
        Me.lbl_devide1.AutoSize = True
        Me.lbl_devide1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_devide1.Location = New System.Drawing.Point(360, 68)
        Me.lbl_devide1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_devide1.Name = "lbl_devide1"
        Me.lbl_devide1.Size = New System.Drawing.Size(12, 14)
        Me.lbl_devide1.TabIndex = 60
        Me.lbl_devide1.Text = "|"
        '
        'lbl_devide2
        '
        Me.lbl_devide2.AutoSize = True
        Me.lbl_devide2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_devide2.Location = New System.Drawing.Point(360, 47)
        Me.lbl_devide2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_devide2.Name = "lbl_devide2"
        Me.lbl_devide2.Size = New System.Drawing.Size(12, 14)
        Me.lbl_devide2.TabIndex = 60
        Me.lbl_devide2.Text = "|"
        '
        'lbl_today_date
        '
        Me.lbl_today_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_today_date.Location = New System.Drawing.Point(510, 2)
        Me.lbl_today_date.Name = "lbl_today_date"
        Me.lbl_today_date.Size = New System.Drawing.Size(254, 17)
        Me.lbl_today_date.TabIndex = 66
        Me.lbl_today_date.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_STS002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 124)
        Me.Controls.Add(Me.lbl_today_date)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.lbl_devide2)
        Me.Controls.Add(Me.lbl_devide1)
        Me.Controls.Add(Me.lbl_wh_name)
        Me.Controls.Add(Me.lbl_stock_date_value)
        Me.Controls.Add(Me.lbl_stock_date)
        Me.Controls.Add(Me.lbl_item_name)
        Me.Controls.Add(Me.lbl_item_code)
        Me.Controls.Add(Me.lbl_wh_code)
        Me.Controls.Add(Me.lbl_item)
        Me.Controls.Add(Me.lbl_wh)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_STS002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stocktaking List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_stock_date As System.Windows.Forms.Label
    Friend WithEvents lbl_item As System.Windows.Forms.Label
    Friend WithEvents lbl_wh As System.Windows.Forms.Label
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents lbl_stock_date_value As System.Windows.Forms.Label
    Friend WithEvents lbl_wh_code As System.Windows.Forms.Label
    Friend WithEvents lbl_wh_name As System.Windows.Forms.Label
    Friend WithEvents lbl_item_code As System.Windows.Forms.Label
    Friend WithEvents lbl_item_name As System.Windows.Forms.Label
    Friend WithEvents lbl_devide1 As System.Windows.Forms.Label
    Friend WithEvents lbl_devide2 As System.Windows.Forms.Label
    Friend WithEvents sfdDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl_today_date As System.Windows.Forms.Label
End Class
