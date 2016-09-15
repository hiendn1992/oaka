<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS002))
        Me.b_change = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tb_usr_id = New System.Windows.Forms.TextBox
        Me.tb_usr_name = New System.Windows.Forms.TextBox
        Me.tb_cur_pwd = New System.Windows.Forms.TextBox
        Me.tb_new_pwd = New System.Windows.Forms.TextBox
        Me.tb_conf_new_pwd = New System.Windows.Forms.TextBox
        Me.lb_conf_new_pwd = New System.Windows.Forms.Label
        Me.lb_new_pwd = New System.Windows.Forms.Label
        Me.lb_cur_pwd = New System.Windows.Forms.Label
        Me.lb_user_name = New System.Windows.Forms.Label
        Me.lb_user_id = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'b_change
        '
        Me.b_change.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_change.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_change.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_change.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_change.Location = New System.Drawing.Point(186, 164)
        Me.b_change.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_change.Name = "b_change"
        Me.b_change.Size = New System.Drawing.Size(75, 22)
        Me.b_change.TabIndex = 6
        Me.b_change.Text = "Change"
        Me.b_change.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(267, 164)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 7
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(164, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 14)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(116, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 14)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(134, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 14)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "*"
        '
        'tb_usr_id
        '
        Me.tb_usr_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_usr_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_usr_id.Location = New System.Drawing.Point(186, 10)
        Me.tb_usr_id.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_usr_id.Name = "tb_usr_id"
        Me.tb_usr_id.Size = New System.Drawing.Size(156, 22)
        Me.tb_usr_id.TabIndex = 1
        Me.tb_usr_id.TabStop = False
        '
        'tb_usr_name
        '
        Me.tb_usr_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_usr_name.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_usr_name.Location = New System.Drawing.Point(186, 41)
        Me.tb_usr_name.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_usr_name.Name = "tb_usr_name"
        Me.tb_usr_name.Size = New System.Drawing.Size(156, 22)
        Me.tb_usr_name.TabIndex = 2
        Me.tb_usr_name.TabStop = False
        '
        'tb_cur_pwd
        '
        Me.tb_cur_pwd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cur_pwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cur_pwd.Location = New System.Drawing.Point(186, 72)
        Me.tb_cur_pwd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_cur_pwd.MaxLength = 32
        Me.tb_cur_pwd.Name = "tb_cur_pwd"
        Me.tb_cur_pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_cur_pwd.Size = New System.Drawing.Size(156, 22)
        Me.tb_cur_pwd.TabIndex = 3
        '
        'tb_new_pwd
        '
        Me.tb_new_pwd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_new_pwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_new_pwd.Location = New System.Drawing.Point(186, 103)
        Me.tb_new_pwd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_new_pwd.MaxLength = 32
        Me.tb_new_pwd.Name = "tb_new_pwd"
        Me.tb_new_pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_new_pwd.Size = New System.Drawing.Size(156, 22)
        Me.tb_new_pwd.TabIndex = 4
        '
        'tb_conf_new_pwd
        '
        Me.tb_conf_new_pwd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_conf_new_pwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_conf_new_pwd.Location = New System.Drawing.Point(186, 134)
        Me.tb_conf_new_pwd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_conf_new_pwd.MaxLength = 32
        Me.tb_conf_new_pwd.Name = "tb_conf_new_pwd"
        Me.tb_conf_new_pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_conf_new_pwd.Size = New System.Drawing.Size(156, 22)
        Me.tb_conf_new_pwd.TabIndex = 5
        '
        'lb_conf_new_pwd
        '
        Me.lb_conf_new_pwd.AutoSize = True
        Me.lb_conf_new_pwd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_conf_new_pwd.Location = New System.Drawing.Point(28, 137)
        Me.lb_conf_new_pwd.Name = "lb_conf_new_pwd"
        Me.lb_conf_new_pwd.Size = New System.Drawing.Size(132, 14)
        Me.lb_conf_new_pwd.TabIndex = 20
        Me.lb_conf_new_pwd.Text = "Confirm New Password"
        '
        'lb_new_pwd
        '
        Me.lb_new_pwd.AutoSize = True
        Me.lb_new_pwd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_new_pwd.Location = New System.Drawing.Point(28, 106)
        Me.lb_new_pwd.Name = "lb_new_pwd"
        Me.lb_new_pwd.Size = New System.Drawing.Size(87, 14)
        Me.lb_new_pwd.TabIndex = 19
        Me.lb_new_pwd.Text = "New Password"
        '
        'lb_cur_pwd
        '
        Me.lb_cur_pwd.AutoSize = True
        Me.lb_cur_pwd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_cur_pwd.Location = New System.Drawing.Point(28, 75)
        Me.lb_cur_pwd.Name = "lb_cur_pwd"
        Me.lb_cur_pwd.Size = New System.Drawing.Size(103, 14)
        Me.lb_cur_pwd.TabIndex = 16
        Me.lb_cur_pwd.Text = "Current Password"
        '
        'lb_user_name
        '
        Me.lb_user_name.AutoSize = True
        Me.lb_user_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_user_name.Location = New System.Drawing.Point(28, 44)
        Me.lb_user_name.Name = "lb_user_name"
        Me.lb_user_name.Size = New System.Drawing.Size(66, 14)
        Me.lb_user_name.TabIndex = 15
        Me.lb_user_name.Text = "User Name"
        '
        'lb_user_id
        '
        Me.lb_user_id.AutoSize = True
        Me.lb_user_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_user_id.Location = New System.Drawing.Point(28, 13)
        Me.lb_user_id.Name = "lb_user_id"
        Me.lb_user_id.Size = New System.Drawing.Size(47, 14)
        Me.lb_user_id.TabIndex = 13
        Me.lb_user_id.Text = "User ID"
        '
        'frm_MSS002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 195)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tb_usr_id)
        Me.Controls.Add(Me.tb_usr_name)
        Me.Controls.Add(Me.tb_cur_pwd)
        Me.Controls.Add(Me.tb_new_pwd)
        Me.Controls.Add(Me.tb_conf_new_pwd)
        Me.Controls.Add(Me.lb_conf_new_pwd)
        Me.Controls.Add(Me.lb_new_pwd)
        Me.Controls.Add(Me.lb_cur_pwd)
        Me.Controls.Add(Me.lb_user_name)
        Me.Controls.Add(Me.lb_user_id)
        Me.Controls.Add(Me.b_change)
        Me.Controls.Add(Me.b_exit)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change User Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_change As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_usr_id As System.Windows.Forms.TextBox
    Friend WithEvents tb_usr_name As System.Windows.Forms.TextBox
    Friend WithEvents tb_cur_pwd As System.Windows.Forms.TextBox
    Friend WithEvents tb_new_pwd As System.Windows.Forms.TextBox
    Friend WithEvents tb_conf_new_pwd As System.Windows.Forms.TextBox
    Friend WithEvents lb_conf_new_pwd As System.Windows.Forms.Label
    Friend WithEvents lb_new_pwd As System.Windows.Forms.Label
    Friend WithEvents lb_cur_pwd As System.Windows.Forms.Label
    Friend WithEvents lb_user_name As System.Windows.Forms.Label
    Friend WithEvents lb_user_id As System.Windows.Forms.Label
End Class
