<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS004))
        Me.rdo_mode_add = New System.Windows.Forms.RadioButton
        Me.rdo_mode_change = New System.Windows.Forms.RadioButton
        Me.rdo_mode_delete = New System.Windows.Forms.RadioButton
        Me.lbl_rack_code = New System.Windows.Forms.Label
        Me.lbl_rack_name = New System.Windows.Forms.Label
        Me.txt_rack_code = New System.Windows.Forms.TextBox
        Me.txt_rack_name = New System.Windows.Forms.TextBox
        Me.btn_execute = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_popup_rack = New System.Windows.Forms.Button
        Me.lbl_today_date = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'rdo_mode_add
        '
        Me.rdo_mode_add.AutoSize = True
        Me.rdo_mode_add.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_mode_add.Location = New System.Drawing.Point(16, 23)
        Me.rdo_mode_add.Margin = New System.Windows.Forms.Padding(4)
        Me.rdo_mode_add.Name = "rdo_mode_add"
        Me.rdo_mode_add.Size = New System.Drawing.Size(47, 18)
        Me.rdo_mode_add.TabIndex = 10
        Me.rdo_mode_add.Text = "Add"
        Me.rdo_mode_add.UseVisualStyleBackColor = True
        '
        'rdo_mode_change
        '
        Me.rdo_mode_change.AutoSize = True
        Me.rdo_mode_change.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_mode_change.Location = New System.Drawing.Point(71, 23)
        Me.rdo_mode_change.Margin = New System.Windows.Forms.Padding(4)
        Me.rdo_mode_change.Name = "rdo_mode_change"
        Me.rdo_mode_change.Size = New System.Drawing.Size(66, 18)
        Me.rdo_mode_change.TabIndex = 11
        Me.rdo_mode_change.Text = "Change"
        Me.rdo_mode_change.UseVisualStyleBackColor = True
        '
        'rdo_mode_delete
        '
        Me.rdo_mode_delete.AutoSize = True
        Me.rdo_mode_delete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_mode_delete.Location = New System.Drawing.Point(145, 23)
        Me.rdo_mode_delete.Margin = New System.Windows.Forms.Padding(4)
        Me.rdo_mode_delete.Name = "rdo_mode_delete"
        Me.rdo_mode_delete.Size = New System.Drawing.Size(61, 18)
        Me.rdo_mode_delete.TabIndex = 12
        Me.rdo_mode_delete.Text = "Delete"
        Me.rdo_mode_delete.UseVisualStyleBackColor = True
        '
        'lbl_rack_code
        '
        Me.lbl_rack_code.AutoSize = True
        Me.lbl_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rack_code.Location = New System.Drawing.Point(9, 52)
        Me.lbl_rack_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rack_code.Name = "lbl_rack_code"
        Me.lbl_rack_code.Size = New System.Drawing.Size(64, 14)
        Me.lbl_rack_code.TabIndex = 13
        Me.lbl_rack_code.Text = "Rack Code"
        '
        'lbl_rack_name
        '
        Me.lbl_rack_name.AutoSize = True
        Me.lbl_rack_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rack_name.Location = New System.Drawing.Point(9, 82)
        Me.lbl_rack_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rack_name.Name = "lbl_rack_name"
        Me.lbl_rack_name.Size = New System.Drawing.Size(67, 14)
        Me.lbl_rack_name.TabIndex = 15
        Me.lbl_rack_name.Text = "Rack Name"
        '
        'txt_rack_code
        '
        Me.txt_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_rack_code.Location = New System.Drawing.Point(100, 49)
        Me.txt_rack_code.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_rack_code.MaxLength = 7
        Me.txt_rack_code.Name = "txt_rack_code"
        Me.txt_rack_code.Size = New System.Drawing.Size(89, 22)
        Me.txt_rack_code.TabIndex = 0
        '
        'txt_rack_name
        '
        Me.txt_rack_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_name.Location = New System.Drawing.Point(100, 79)
        Me.txt_rack_name.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_rack_name.MaxLength = 40
        Me.txt_rack_name.Name = "txt_rack_name"
        Me.txt_rack_name.Size = New System.Drawing.Size(250, 22)
        Me.txt_rack_name.TabIndex = 1
        '
        'btn_execute
        '
        Me.btn_execute.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_execute.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_execute.FlatAppearance.BorderSize = 2
        Me.btn_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_execute.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_execute.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_execute.Location = New System.Drawing.Point(191, 110)
        Me.btn_execute.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_execute.Name = "btn_execute"
        Me.btn_execute.Size = New System.Drawing.Size(75, 22)
        Me.btn_execute.TabIndex = 2
        Me.btn_execute.Text = "Execute"
        Me.btn_execute.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_execute.UseVisualStyleBackColor = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_cancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_cancel.FlatAppearance.BorderSize = 2
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_cancel.Location = New System.Drawing.Point(274, 109)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 22)
        Me.btn_cancel.TabIndex = 3
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_exit.FlatAppearance.BorderSize = 2
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(357, 110)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 4
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(76, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(76, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "*"
        '
        'btn_popup_rack
        '
        Me.btn_popup_rack.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_rack.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_popup_rack.FlatAppearance.BorderSize = 2
        Me.btn_popup_rack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_popup_rack.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_popup_rack.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.btn_popup_rack.Location = New System.Drawing.Point(197, 48)
        Me.btn_popup_rack.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_popup_rack.Name = "btn_popup_rack"
        Me.btn_popup_rack.Size = New System.Drawing.Size(24, 22)
        Me.btn_popup_rack.TabIndex = 14
        Me.btn_popup_rack.TabStop = False
        Me.btn_popup_rack.Text = "?"
        Me.btn_popup_rack.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_popup_rack.UseVisualStyleBackColor = False
        '
        'lbl_today_date
        '
        Me.lbl_today_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_today_date.Location = New System.Drawing.Point(184, 2)
        Me.lbl_today_date.Name = "lbl_today_date"
        Me.lbl_today_date.Size = New System.Drawing.Size(249, 16)
        Me.lbl_today_date.TabIndex = 67
        Me.lbl_today_date.Text = "User ID: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_MSS004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 141)
        Me.Controls.Add(Me.lbl_today_date)
        Me.Controls.Add(Me.btn_popup_rack)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_execute)
        Me.Controls.Add(Me.txt_rack_name)
        Me.Controls.Add(Me.txt_rack_code)
        Me.Controls.Add(Me.lbl_rack_name)
        Me.Controls.Add(Me.lbl_rack_code)
        Me.Controls.Add(Me.rdo_mode_delete)
        Me.Controls.Add(Me.rdo_mode_change)
        Me.Controls.Add(Me.rdo_mode_add)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS004"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rack Master Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdo_mode_add As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_mode_change As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_mode_delete As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_rack_code As System.Windows.Forms.Label
    Friend WithEvents lbl_rack_name As System.Windows.Forms.Label
    Friend WithEvents txt_rack_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_rack_name As System.Windows.Forms.TextBox
    Friend WithEvents btn_execute As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_popup_rack As System.Windows.Forms.Button
    Friend WithEvents lbl_today_date As System.Windows.Forms.Label
End Class
