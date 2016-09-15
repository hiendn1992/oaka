<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS005))
        Me.lb_today = New System.Windows.Forms.Label
        Me.b_exec = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.b_pop_up = New System.Windows.Forms.Button
        Me.tb_email = New System.Windows.Forms.TextBox
        Me.tb_tel_no = New System.Windows.Forms.TextBox
        Me.tb_fax_no = New System.Windows.Forms.TextBox
        Me.lb_tel_no = New System.Windows.Forms.Label
        Me.lb_fax_no = New System.Windows.Forms.Label
        Me.lb_email = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cb_dest = New System.Windows.Forms.ComboBox
        Me.lb_dest = New System.Windows.Forms.Label
        Me.lb_address = New System.Windows.Forms.Label
        Me.tb_address = New System.Windows.Forms.TextBox
        Me.tb_cus_name = New System.Windows.Forms.TextBox
        Me.tb_cus_id = New System.Windows.Forms.TextBox
        Me.lb_cus_name = New System.Windows.Forms.Label
        Me.lb_cus_id = New System.Windows.Forms.Label
        Me.rb_del_cus = New System.Windows.Forms.RadioButton
        Me.rb_change_cus = New System.Windows.Forms.RadioButton
        Me.rb_add_cus = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Location = New System.Drawing.Point(533, 2)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(231, 14)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'b_exec
        '
        Me.b_exec.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exec.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exec.Location = New System.Drawing.Point(527, 154)
        Me.b_exec.Name = "b_exec"
        Me.b_exec.Size = New System.Drawing.Size(75, 24)
        Me.b_exec.TabIndex = 9
        Me.b_exec.Text = "Execute"
        Me.b_exec.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(608, 154)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 24)
        Me.b_cancel.TabIndex = 10
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(689, 154)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 24)
        Me.b_exit.TabIndex = 11
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'b_pop_up
        '
        Me.b_pop_up.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_pop_up.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_pop_up.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_pop_up.Location = New System.Drawing.Point(230, 42)
        Me.b_pop_up.Name = "b_pop_up"
        Me.b_pop_up.Size = New System.Drawing.Size(24, 22)
        Me.b_pop_up.TabIndex = 2
        Me.b_pop_up.TabStop = False
        Me.b_pop_up.Text = "?"
        Me.b_pop_up.UseVisualStyleBackColor = False
        '
        'tb_email
        '
        Me.tb_email.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_email.Location = New System.Drawing.Point(399, 70)
        Me.tb_email.MaxLength = 40
        Me.tb_email.Name = "tb_email"
        Me.tb_email.Size = New System.Drawing.Size(203, 22)
        Me.tb_email.TabIndex = 7
        '
        'tb_tel_no
        '
        Me.tb_tel_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_tel_no.Location = New System.Drawing.Point(109, 126)
        Me.tb_tel_no.MaxLength = 20
        Me.tb_tel_no.Name = "tb_tel_no"
        Me.tb_tel_no.Size = New System.Drawing.Size(115, 22)
        Me.tb_tel_no.TabIndex = 8
        '
        'tb_fax_no
        '
        Me.tb_fax_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_fax_no.Location = New System.Drawing.Point(109, 98)
        Me.tb_fax_no.MaxLength = 20
        Me.tb_fax_no.Name = "tb_fax_no"
        Me.tb_fax_no.Size = New System.Drawing.Size(115, 22)
        Me.tb_fax_no.TabIndex = 6
        '
        'lb_tel_no
        '
        Me.lb_tel_no.AutoSize = True
        Me.lb_tel_no.Location = New System.Drawing.Point(12, 129)
        Me.lb_tel_no.Name = "lb_tel_no"
        Me.lb_tel_no.Size = New System.Drawing.Size(43, 14)
        Me.lb_tel_no.TabIndex = 43
        Me.lb_tel_no.Text = "Tel No"
        '
        'lb_fax_no
        '
        Me.lb_fax_no.AutoSize = True
        Me.lb_fax_no.Location = New System.Drawing.Point(12, 101)
        Me.lb_fax_no.Name = "lb_fax_no"
        Me.lb_fax_no.Size = New System.Drawing.Size(44, 14)
        Me.lb_fax_no.TabIndex = 42
        Me.lb_fax_no.Text = "Fax No"
        '
        'lb_email
        '
        Me.lb_email.AutoSize = True
        Me.lb_email.Location = New System.Drawing.Point(288, 73)
        Me.lb_email.Name = "lb_email"
        Me.lb_email.Size = New System.Drawing.Size(34, 14)
        Me.lb_email.TabIndex = 41
        Me.lb_email.Text = "Email"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(379, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 14)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(76, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 14)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(335, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 14)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(83, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 14)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "*"
        '
        'cb_dest
        '
        Me.cb_dest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_dest.FormattingEnabled = True
        Me.cb_dest.Location = New System.Drawing.Point(109, 70)
        Me.cb_dest.Name = "cb_dest"
        Me.cb_dest.Size = New System.Drawing.Size(115, 22)
        Me.cb_dest.TabIndex = 4
        '
        'lb_dest
        '
        Me.lb_dest.AutoSize = True
        Me.lb_dest.Location = New System.Drawing.Point(12, 73)
        Me.lb_dest.Name = "lb_dest"
        Me.lb_dest.Size = New System.Drawing.Size(68, 14)
        Me.lb_dest.TabIndex = 36
        Me.lb_dest.Text = "Destination"
        '
        'lb_address
        '
        Me.lb_address.AutoSize = True
        Me.lb_address.Location = New System.Drawing.Point(288, 101)
        Me.lb_address.Name = "lb_address"
        Me.lb_address.Size = New System.Drawing.Size(50, 14)
        Me.lb_address.TabIndex = 31
        Me.lb_address.Text = "Address"
        '
        'tb_address
        '
        Me.tb_address.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_address.Location = New System.Drawing.Point(399, 98)
        Me.tb_address.MaxLength = 100
        Me.tb_address.Multiline = True
        Me.tb_address.Name = "tb_address"
        Me.tb_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_address.Size = New System.Drawing.Size(284, 45)
        Me.tb_address.TabIndex = 5
        '
        'tb_cus_name
        '
        Me.tb_cus_name.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_cus_name.Location = New System.Drawing.Point(399, 43)
        Me.tb_cus_name.MaxLength = 50
        Me.tb_cus_name.Name = "tb_cus_name"
        Me.tb_cus_name.Size = New System.Drawing.Size(203, 22)
        Me.tb_cus_name.TabIndex = 3
        '
        'tb_cus_id
        '
        Me.tb_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_id.Location = New System.Drawing.Point(109, 42)
        Me.tb_cus_id.MaxLength = 10
        Me.tb_cus_id.Name = "tb_cus_id"
        Me.tb_cus_id.Size = New System.Drawing.Size(115, 22)
        Me.tb_cus_id.TabIndex = 1
        Me.tb_cus_id.TabStop = False
        '
        'lb_cus_name
        '
        Me.lb_cus_name.AutoSize = True
        Me.lb_cus_name.Location = New System.Drawing.Point(288, 46)
        Me.lb_cus_name.Name = "lb_cus_name"
        Me.lb_cus_name.Size = New System.Drawing.Size(94, 14)
        Me.lb_cus_name.TabIndex = 27
        Me.lb_cus_name.Text = "Customer Name"
        '
        'lb_cus_id
        '
        Me.lb_cus_id.AutoSize = True
        Me.lb_cus_id.Location = New System.Drawing.Point(12, 45)
        Me.lb_cus_id.Name = "lb_cus_id"
        Me.lb_cus_id.Size = New System.Drawing.Size(75, 14)
        Me.lb_cus_id.TabIndex = 25
        Me.lb_cus_id.Text = "Customer ID"
        '
        'rb_del_cus
        '
        Me.rb_del_cus.AutoSize = True
        Me.rb_del_cus.Location = New System.Drawing.Point(137, 18)
        Me.rb_del_cus.Name = "rb_del_cus"
        Me.rb_del_cus.Size = New System.Drawing.Size(61, 18)
        Me.rb_del_cus.TabIndex = 46
        Me.rb_del_cus.Text = "Delete"
        Me.rb_del_cus.UseVisualStyleBackColor = True
        '
        'rb_change_cus
        '
        Me.rb_change_cus.AutoSize = True
        Me.rb_change_cus.Location = New System.Drawing.Point(65, 18)
        Me.rb_change_cus.Name = "rb_change_cus"
        Me.rb_change_cus.Size = New System.Drawing.Size(66, 18)
        Me.rb_change_cus.TabIndex = 45
        Me.rb_change_cus.Text = "Change"
        Me.rb_change_cus.UseVisualStyleBackColor = True
        '
        'rb_add_cus
        '
        Me.rb_add_cus.AutoSize = True
        Me.rb_add_cus.Location = New System.Drawing.Point(12, 18)
        Me.rb_add_cus.Name = "rb_add_cus"
        Me.rb_add_cus.Size = New System.Drawing.Size(47, 18)
        Me.rb_add_cus.TabIndex = 44
        Me.rb_add_cus.Text = "Add"
        Me.rb_add_cus.UseVisualStyleBackColor = True
        '
        'frm_MSS005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 188)
        Me.Controls.Add(Me.rb_del_cus)
        Me.Controls.Add(Me.rb_change_cus)
        Me.Controls.Add(Me.rb_add_cus)
        Me.Controls.Add(Me.b_pop_up)
        Me.Controls.Add(Me.tb_email)
        Me.Controls.Add(Me.tb_tel_no)
        Me.Controls.Add(Me.tb_fax_no)
        Me.Controls.Add(Me.lb_tel_no)
        Me.Controls.Add(Me.lb_fax_no)
        Me.Controls.Add(Me.lb_email)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb_dest)
        Me.Controls.Add(Me.lb_dest)
        Me.Controls.Add(Me.lb_address)
        Me.Controls.Add(Me.tb_address)
        Me.Controls.Add(Me.tb_cus_name)
        Me.Controls.Add(Me.tb_cus_id)
        Me.Controls.Add(Me.lb_cus_name)
        Me.Controls.Add(Me.lb_cus_id)
        Me.Controls.Add(Me.b_exec)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.lb_today)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS005"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Master Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents b_exec As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents b_pop_up As System.Windows.Forms.Button
    Friend WithEvents tb_email As System.Windows.Forms.TextBox
    Friend WithEvents tb_tel_no As System.Windows.Forms.TextBox
    Friend WithEvents tb_fax_no As System.Windows.Forms.TextBox
    Friend WithEvents lb_tel_no As System.Windows.Forms.Label
    Friend WithEvents lb_fax_no As System.Windows.Forms.Label
    Friend WithEvents lb_email As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_dest As System.Windows.Forms.ComboBox
    Friend WithEvents lb_dest As System.Windows.Forms.Label
    Friend WithEvents lb_address As System.Windows.Forms.Label
    Friend WithEvents tb_address As System.Windows.Forms.TextBox
    Friend WithEvents tb_cus_name As System.Windows.Forms.TextBox
    Friend WithEvents tb_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents lb_cus_name As System.Windows.Forms.Label
    Friend WithEvents lb_cus_id As System.Windows.Forms.Label
    Friend WithEvents rb_del_cus As System.Windows.Forms.RadioButton
    Friend WithEvents rb_change_cus As System.Windows.Forms.RadioButton
    Friend WithEvents rb_add_cus As System.Windows.Forms.RadioButton
End Class
