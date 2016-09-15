<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS001))
        Me.lb_today = New System.Windows.Forms.Label
        Me.b_execute = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.b_popup_user = New System.Windows.Forms.Button
        Me.lb_remark = New System.Windows.Forms.Label
        Me.lb_authority = New System.Windows.Forms.Label
        Me.lb_password = New System.Windows.Forms.Label
        Me.lb_user_name = New System.Windows.Forms.Label
        Me.tb_remark = New System.Windows.Forms.TextBox
        Me.tb_password = New System.Windows.Forms.TextBox
        Me.cb_authority = New System.Windows.Forms.ComboBox
        Me.tb_user_name = New System.Windows.Forms.TextBox
        Me.tb_user_id = New System.Windows.Forms.TextBox
        Me.lb_user_id = New System.Windows.Forms.Label
        Me.rb_delete_user = New System.Windows.Forms.RadioButton
        Me.rb_change_user = New System.Windows.Forms.RadioButton
        Me.rb_add_user = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_today.Location = New System.Drawing.Point(508, 3)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(256, 16)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX  |  Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'b_execute
        '
        Me.b_execute.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_execute.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_execute.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_execute.Location = New System.Drawing.Point(527, 145)
        Me.b_execute.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_execute.Name = "b_execute"
        Me.b_execute.Size = New System.Drawing.Size(75, 22)
        Me.b_execute.TabIndex = 10
        Me.b_execute.Text = "Execute"
        Me.b_execute.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(608, 145)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 11
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(689, 145)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 12
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(73, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 14)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(73, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 14)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(60, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 14)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "*"
        '
        'b_popup_user
        '
        Me.b_popup_user.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_popup_user.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_popup_user.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_popup_user.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_popup_user.Location = New System.Drawing.Point(243, 52)
        Me.b_popup_user.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_popup_user.Name = "b_popup_user"
        Me.b_popup_user.Size = New System.Drawing.Size(24, 22)
        Me.b_popup_user.TabIndex = 5
        Me.b_popup_user.TabStop = False
        Me.b_popup_user.Text = "?"
        Me.b_popup_user.UseVisualStyleBackColor = False
        '
        'lb_remark
        '
        Me.lb_remark.AutoSize = True
        Me.lb_remark.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_remark.Location = New System.Drawing.Point(288, 85)
        Me.lb_remark.Name = "lb_remark"
        Me.lb_remark.Size = New System.Drawing.Size(47, 14)
        Me.lb_remark.TabIndex = 23
        Me.lb_remark.Text = "Remark"
        '
        'lb_authority
        '
        Me.lb_authority.AutoSize = True
        Me.lb_authority.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_authority.Location = New System.Drawing.Point(15, 116)
        Me.lb_authority.Name = "lb_authority"
        Me.lb_authority.Size = New System.Drawing.Size(58, 14)
        Me.lb_authority.TabIndex = 22
        Me.lb_authority.Text = "Authority"
        '
        'lb_password
        '
        Me.lb_password.AutoSize = True
        Me.lb_password.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_password.Location = New System.Drawing.Point(15, 85)
        Me.lb_password.Name = "lb_password"
        Me.lb_password.Size = New System.Drawing.Size(58, 14)
        Me.lb_password.TabIndex = 21
        Me.lb_password.Text = "Password"
        '
        'lb_user_name
        '
        Me.lb_user_name.AutoSize = True
        Me.lb_user_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_user_name.Location = New System.Drawing.Point(288, 56)
        Me.lb_user_name.Name = "lb_user_name"
        Me.lb_user_name.Size = New System.Drawing.Size(66, 14)
        Me.lb_user_name.TabIndex = 20
        Me.lb_user_name.Text = "User Name"
        '
        'tb_remark
        '
        Me.tb_remark.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_remark.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_remark.Location = New System.Drawing.Point(378, 84)
        Me.tb_remark.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_remark.MaxLength = 100
        Me.tb_remark.Multiline = True
        Me.tb_remark.Name = "tb_remark"
        Me.tb_remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_remark.Size = New System.Drawing.Size(386, 53)
        Me.tb_remark.TabIndex = 8
        '
        'tb_password
        '
        Me.tb_password.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_password.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_password.Location = New System.Drawing.Point(95, 84)
        Me.tb_password.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_password.MaxLength = 32
        Me.tb_password.Name = "tb_password"
        Me.tb_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_password.Size = New System.Drawing.Size(142, 22)
        Me.tb_password.TabIndex = 7
        '
        'cb_authority
        '
        Me.cb_authority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_authority.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_authority.FormattingEnabled = True
        Me.cb_authority.Location = New System.Drawing.Point(95, 113)
        Me.cb_authority.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb_authority.Name = "cb_authority"
        Me.cb_authority.Size = New System.Drawing.Size(142, 22)
        Me.cb_authority.TabIndex = 9
        '
        'tb_user_name
        '
        Me.tb_user_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_user_name.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_user_name.Location = New System.Drawing.Point(379, 52)
        Me.tb_user_name.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_user_name.MaxLength = 50
        Me.tb_user_name.Name = "tb_user_name"
        Me.tb_user_name.Size = New System.Drawing.Size(385, 22)
        Me.tb_user_name.TabIndex = 6
        '
        'tb_user_id
        '
        Me.tb_user_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_user_id.Location = New System.Drawing.Point(95, 52)
        Me.tb_user_id.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_user_id.MaxLength = 8
        Me.tb_user_id.Name = "tb_user_id"
        Me.tb_user_id.Size = New System.Drawing.Size(142, 22)
        Me.tb_user_id.TabIndex = 4
        '
        'lb_user_id
        '
        Me.lb_user_id.AutoSize = True
        Me.lb_user_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_user_id.Location = New System.Drawing.Point(15, 55)
        Me.lb_user_id.Name = "lb_user_id"
        Me.lb_user_id.Size = New System.Drawing.Size(47, 14)
        Me.lb_user_id.TabIndex = 14
        Me.lb_user_id.Text = "User ID"
        '
        'rb_delete_user
        '
        Me.rb_delete_user.AutoSize = True
        Me.rb_delete_user.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_delete_user.Location = New System.Drawing.Point(142, 22)
        Me.rb_delete_user.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rb_delete_user.Name = "rb_delete_user"
        Me.rb_delete_user.Size = New System.Drawing.Size(61, 18)
        Me.rb_delete_user.TabIndex = 3
        Me.rb_delete_user.Text = "Delete"
        Me.rb_delete_user.UseVisualStyleBackColor = True
        '
        'rb_change_user
        '
        Me.rb_change_user.AutoSize = True
        Me.rb_change_user.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_change_user.Location = New System.Drawing.Point(70, 22)
        Me.rb_change_user.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rb_change_user.Name = "rb_change_user"
        Me.rb_change_user.Size = New System.Drawing.Size(66, 18)
        Me.rb_change_user.TabIndex = 2
        Me.rb_change_user.Text = "Change"
        Me.rb_change_user.UseVisualStyleBackColor = True
        '
        'rb_add_user
        '
        Me.rb_add_user.AutoSize = True
        Me.rb_add_user.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_add_user.Location = New System.Drawing.Point(17, 22)
        Me.rb_add_user.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rb_add_user.Name = "rb_add_user"
        Me.rb_add_user.Size = New System.Drawing.Size(47, 18)
        Me.rb_add_user.TabIndex = 1
        Me.rb_add_user.Text = "Add"
        Me.rb_add_user.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(356, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 14)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "*"
        '
        'frm_MSS001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 172)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rb_delete_user)
        Me.Controls.Add(Me.rb_change_user)
        Me.Controls.Add(Me.rb_add_user)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.b_popup_user)
        Me.Controls.Add(Me.lb_remark)
        Me.Controls.Add(Me.lb_authority)
        Me.Controls.Add(Me.lb_password)
        Me.Controls.Add(Me.lb_user_name)
        Me.Controls.Add(Me.tb_remark)
        Me.Controls.Add(Me.tb_password)
        Me.Controls.Add(Me.cb_authority)
        Me.Controls.Add(Me.tb_user_name)
        Me.Controls.Add(Me.tb_user_id)
        Me.Controls.Add(Me.lb_user_id)
        Me.Controls.Add(Me.b_execute)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.lb_today)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Master Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents b_execute As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents b_popup_user As System.Windows.Forms.Button
    Friend WithEvents lb_remark As System.Windows.Forms.Label
    Friend WithEvents lb_authority As System.Windows.Forms.Label
    Friend WithEvents lb_password As System.Windows.Forms.Label
    Friend WithEvents lb_user_name As System.Windows.Forms.Label
    Friend WithEvents tb_remark As System.Windows.Forms.TextBox
    Friend WithEvents tb_password As System.Windows.Forms.TextBox
    Friend WithEvents cb_authority As System.Windows.Forms.ComboBox
    Friend WithEvents tb_user_name As System.Windows.Forms.TextBox
    Friend WithEvents tb_user_id As System.Windows.Forms.TextBox
    Friend WithEvents lb_user_id As System.Windows.Forms.Label
    Friend WithEvents rb_delete_user As System.Windows.Forms.RadioButton
    Friend WithEvents rb_change_user As System.Windows.Forms.RadioButton
    Friend WithEvents rb_add_user As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
