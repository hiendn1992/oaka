<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LGN001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_LGN001))
        Me.lb_user_code = New System.Windows.Forms.Label
        Me.lb_password = New System.Windows.Forms.Label
        Me.tb_user_code = New System.Windows.Forms.TextBox
        Me.tb_password = New System.Windows.Forms.TextBox
        Me.b_login = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.bgWorker = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'lb_user_code
        '
        Me.lb_user_code.AutoSize = True
        Me.lb_user_code.Location = New System.Drawing.Point(42, 12)
        Me.lb_user_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_user_code.Name = "lb_user_code"
        Me.lb_user_code.Size = New System.Drawing.Size(51, 14)
        Me.lb_user_code.TabIndex = 0
        Me.lb_user_code.Text = "User ID:"
        '
        'lb_password
        '
        Me.lb_password.AutoSize = True
        Me.lb_password.Location = New System.Drawing.Point(42, 37)
        Me.lb_password.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_password.Name = "lb_password"
        Me.lb_password.Size = New System.Drawing.Size(62, 14)
        Me.lb_password.TabIndex = 1
        Me.lb_password.Text = "Password:"
        '
        'tb_user_code
        '
        Me.tb_user_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tb_user_code.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_user_code.Location = New System.Drawing.Point(109, 9)
        Me.tb_user_code.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tb_user_code.MaxLength = 8
        Me.tb_user_code.Name = "tb_user_code"
        Me.tb_user_code.Size = New System.Drawing.Size(183, 22)
        Me.tb_user_code.TabIndex = 1
        '
        'tb_password
        '
        Me.tb_password.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_password.Location = New System.Drawing.Point(109, 35)
        Me.tb_password.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tb_password.MaxLength = 32
        Me.tb_password.Name = "tb_password"
        Me.tb_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tb_password.Size = New System.Drawing.Size(183, 22)
        Me.tb_password.TabIndex = 2
        '
        'b_login
        '
        Me.b_login.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.b_login.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_login.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_login.Location = New System.Drawing.Point(136, 62)
        Me.b_login.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_login.Name = "b_login"
        Me.b_login.Size = New System.Drawing.Size(75, 24)
        Me.b_login.TabIndex = 3
        Me.b_login.Text = "Login"
        Me.b_login.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.b_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(217, 62)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 24)
        Me.b_exit.TabIndex = 4
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'frm_LGN001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 90)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_login)
        Me.Controls.Add(Me.tb_password)
        Me.Controls.Add(Me.tb_user_code)
        Me.Controls.Add(Me.lb_password)
        Me.Controls.Add(Me.lb_user_code)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_LGN001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_user_code As System.Windows.Forms.Label
    Friend WithEvents lb_password As System.Windows.Forms.Label
    Friend WithEvents tb_user_code As System.Windows.Forms.TextBox
    Friend WithEvents tb_password As System.Windows.Forms.TextBox
    Friend WithEvents b_login As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
End Class
