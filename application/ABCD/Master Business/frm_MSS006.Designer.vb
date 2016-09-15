<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS006
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS006))
        Me.lb_today = New System.Windows.Forms.Label
        Me.sfdDialog = New System.Windows.Forms.SaveFileDialog
        Me.lb_auth = New System.Windows.Forms.Label
        Me.tb_remark = New System.Windows.Forms.TextBox
        Me.lb_remark = New System.Windows.Forms.Label
        Me.cb_authority = New System.Windows.Forms.ComboBox
        Me.tb_user_id = New System.Windows.Forms.TextBox
        Me.lb_user_id = New System.Windows.Forms.Label
        Me.dgv_lst_user = New System.Windows.Forms.DataGridView
        Me.b_exit = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_export = New System.Windows.Forms.Button
        Me.b_search = New System.Windows.Forms.Button
        CType(Me.dgv_lst_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_today.Location = New System.Drawing.Point(582, 2)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(248, 14)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lb_auth
        '
        Me.lb_auth.AutoSize = True
        Me.lb_auth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_auth.Location = New System.Drawing.Point(7, 52)
        Me.lb_auth.Name = "lb_auth"
        Me.lb_auth.Size = New System.Drawing.Size(58, 14)
        Me.lb_auth.TabIndex = 11
        Me.lb_auth.Text = "Authority"
        '
        'tb_remark
        '
        Me.tb_remark.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_remark.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_remark.Location = New System.Drawing.Point(306, 19)
        Me.tb_remark.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_remark.MaxLength = 100
        Me.tb_remark.Multiline = True
        Me.tb_remark.Name = "tb_remark"
        Me.tb_remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_remark.Size = New System.Drawing.Size(386, 52)
        Me.tb_remark.TabIndex = 9
        '
        'lb_remark
        '
        Me.lb_remark.AutoSize = True
        Me.lb_remark.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_remark.Location = New System.Drawing.Point(248, 22)
        Me.lb_remark.Name = "lb_remark"
        Me.lb_remark.Size = New System.Drawing.Size(47, 14)
        Me.lb_remark.TabIndex = 8
        Me.lb_remark.Text = "Remark"
        '
        'cb_authority
        '
        Me.cb_authority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_authority.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_authority.FormattingEnabled = True
        Me.cb_authority.Location = New System.Drawing.Point(71, 49)
        Me.cb_authority.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cb_authority.Name = "cb_authority"
        Me.cb_authority.Size = New System.Drawing.Size(142, 22)
        Me.cb_authority.TabIndex = 10
        '
        'tb_user_id
        '
        Me.tb_user_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_user_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_user_id.Location = New System.Drawing.Point(71, 19)
        Me.tb_user_id.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_user_id.MaxLength = 8
        Me.tb_user_id.Name = "tb_user_id"
        Me.tb_user_id.Size = New System.Drawing.Size(142, 22)
        Me.tb_user_id.TabIndex = 7
        '
        'lb_user_id
        '
        Me.lb_user_id.AutoSize = True
        Me.lb_user_id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_user_id.Location = New System.Drawing.Point(7, 22)
        Me.lb_user_id.Name = "lb_user_id"
        Me.lb_user_id.Size = New System.Drawing.Size(47, 14)
        Me.lb_user_id.TabIndex = 6
        Me.lb_user_id.Text = "User ID"
        '
        'dgv_lst_user
        '
        Me.dgv_lst_user.AllowUserToAddRows = False
        Me.dgv_lst_user.AllowUserToDeleteRows = False
        Me.dgv_lst_user.AllowUserToResizeRows = False
        Me.dgv_lst_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_lst_user.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_lst_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lst_user.Location = New System.Drawing.Point(10, 79)
        Me.dgv_lst_user.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgv_lst_user.Name = "dgv_lst_user"
        Me.dgv_lst_user.ReadOnly = True
        Me.dgv_lst_user.RowHeadersVisible = False
        Me.dgv_lst_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_lst_user.Size = New System.Drawing.Size(820, 223)
        Me.dgv_lst_user.TabIndex = 12
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(755, 310)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 16
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(674, 310)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 15
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_export
        '
        Me.b_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_export.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_export.Location = New System.Drawing.Point(593, 310)
        Me.b_export.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_export.Name = "b_export"
        Me.b_export.Size = New System.Drawing.Size(75, 22)
        Me.b_export.TabIndex = 14
        Me.b_export.Text = "Export"
        Me.b_export.UseVisualStyleBackColor = False
        '
        'b_search
        '
        Me.b_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_search.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_search.Location = New System.Drawing.Point(755, 47)
        Me.b_search.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.b_search.Name = "b_search"
        Me.b_search.Size = New System.Drawing.Size(75, 22)
        Me.b_search.TabIndex = 13
        Me.b_search.Text = "Search"
        Me.b_search.UseVisualStyleBackColor = False
        '
        'frm_MSS006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 338)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_export)
        Me.Controls.Add(Me.b_search)
        Me.Controls.Add(Me.dgv_lst_user)
        Me.Controls.Add(Me.lb_auth)
        Me.Controls.Add(Me.tb_remark)
        Me.Controls.Add(Me.lb_remark)
        Me.Controls.Add(Me.lb_today)
        Me.Controls.Add(Me.cb_authority)
        Me.Controls.Add(Me.tb_user_id)
        Me.Controls.Add(Me.lb_user_id)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS006"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Master Inquiry"
        CType(Me.dgv_lst_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents sfdDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lb_auth As System.Windows.Forms.Label
    Friend WithEvents tb_remark As System.Windows.Forms.TextBox
    Friend WithEvents lb_remark As System.Windows.Forms.Label
    Friend WithEvents cb_authority As System.Windows.Forms.ComboBox
    Friend WithEvents tb_user_id As System.Windows.Forms.TextBox
    Friend WithEvents lb_user_id As System.Windows.Forms.Label
    Friend WithEvents dgv_lst_user As System.Windows.Forms.DataGridView
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_export As System.Windows.Forms.Button
    Friend WithEvents b_search As System.Windows.Forms.Button
End Class
