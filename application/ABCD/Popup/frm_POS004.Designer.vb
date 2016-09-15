<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_POS004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_POS004))
        Me.b_exit = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_search = New System.Windows.Forms.Button
        Me.dgv_list_user = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.cb_authority = New System.Windows.Forms.ComboBox
        Me.tb_remark = New System.Windows.Forms.TextBox
        Me.tb_user_id = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgv_list_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(689, 328)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 7
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(608, 328)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 6
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_search
        '
        Me.b_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_search.Location = New System.Drawing.Point(689, 40)
        Me.b_search.Name = "b_search"
        Me.b_search.Size = New System.Drawing.Size(75, 22)
        Me.b_search.TabIndex = 4
        Me.b_search.Text = "Search"
        Me.b_search.UseVisualStyleBackColor = False
        '
        'dgv_list_user
        '
        Me.dgv_list_user.AllowUserToAddRows = False
        Me.dgv_list_user.AllowUserToDeleteRows = False
        Me.dgv_list_user.AllowUserToResizeRows = False
        Me.dgv_list_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_list_user.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_list_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_list_user.Location = New System.Drawing.Point(12, 68)
        Me.dgv_list_user.Name = "dgv_list_user"
        Me.dgv_list_user.ReadOnly = True
        Me.dgv_list_user.RowHeadersVisible = False
        Me.dgv_list_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list_user.Size = New System.Drawing.Size(752, 254)
        Me.dgv_list_user.TabIndex = 5
        Me.dgv_list_user.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(258, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Remark"
        '
        'cb_authority
        '
        Me.cb_authority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_authority.FormattingEnabled = True
        Me.cb_authority.Location = New System.Drawing.Point(76, 40)
        Me.cb_authority.Name = "cb_authority"
        Me.cb_authority.Size = New System.Drawing.Size(134, 22)
        Me.cb_authority.TabIndex = 3
        '
        'tb_remark
        '
        Me.tb_remark.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_remark.Location = New System.Drawing.Point(311, 12)
        Me.tb_remark.MaxLength = 100
        Me.tb_remark.Multiline = True
        Me.tb_remark.Name = "tb_remark"
        Me.tb_remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_remark.Size = New System.Drawing.Size(372, 50)
        Me.tb_remark.TabIndex = 2
        '
        'tb_user_id
        '
        Me.tb_user_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_user_id.Location = New System.Drawing.Point(76, 12)
        Me.tb_user_id.MaxLength = 8
        Me.tb_user_id.Name = "tb_user_id"
        Me.tb_user_id.Size = New System.Drawing.Size(134, 22)
        Me.tb_user_id.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Authority"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "User ID"
        '
        'frm_POS004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 361)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb_authority)
        Me.Controls.Add(Me.tb_remark)
        Me.Controls.Add(Me.tb_user_id)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_list_user)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_search)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_POS004"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup Select User"
        CType(Me.dgv_list_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_search As System.Windows.Forms.Button
    Friend WithEvents dgv_list_user As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_authority As System.Windows.Forms.ComboBox
    Friend WithEvents tb_remark As System.Windows.Forms.TextBox
    Friend WithEvents tb_user_id As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
