<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_POS005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_POS005))
        Me.b_exit = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.b_search = New System.Windows.Forms.Button
        Me.dgv_lst_cus = New System.Windows.Forms.DataGridView
        Me.tb_tel_no = New System.Windows.Forms.TextBox
        Me.lb_tel_no = New System.Windows.Forms.Label
        Me.cb_dest = New System.Windows.Forms.ComboBox
        Me.lb_dest = New System.Windows.Forms.Label
        Me.tb_address = New System.Windows.Forms.TextBox
        Me.lb_address = New System.Windows.Forms.Label
        Me.tb_cus_name = New System.Windows.Forms.TextBox
        Me.lb_cus_name = New System.Windows.Forms.Label
        Me.tb_cus_id = New System.Windows.Forms.TextBox
        Me.lb_cus_id = New System.Windows.Forms.Label
        CType(Me.dgv_lst_cus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(734, 369)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 9
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(653, 369)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 8
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'b_search
        '
        Me.b_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_search.Location = New System.Drawing.Point(734, 68)
        Me.b_search.Name = "b_search"
        Me.b_search.Size = New System.Drawing.Size(75, 22)
        Me.b_search.TabIndex = 6
        Me.b_search.Text = "Search"
        Me.b_search.UseVisualStyleBackColor = False
        '
        'dgv_lst_cus
        '
        Me.dgv_lst_cus.AllowUserToAddRows = False
        Me.dgv_lst_cus.AllowUserToDeleteRows = False
        Me.dgv_lst_cus.AllowUserToResizeRows = False
        Me.dgv_lst_cus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_lst_cus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_lst_cus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_lst_cus.Location = New System.Drawing.Point(12, 96)
        Me.dgv_lst_cus.Name = "dgv_lst_cus"
        Me.dgv_lst_cus.ReadOnly = True
        Me.dgv_lst_cus.RowHeadersVisible = False
        Me.dgv_lst_cus.RowHeadersWidth = 60
        Me.dgv_lst_cus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_lst_cus.Size = New System.Drawing.Size(797, 267)
        Me.dgv_lst_cus.TabIndex = 7
        Me.dgv_lst_cus.TabStop = False
        '
        'tb_tel_no
        '
        Me.tb_tel_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_tel_no.Location = New System.Drawing.Point(90, 68)
        Me.tb_tel_no.Name = "tb_tel_no"
        Me.tb_tel_no.Size = New System.Drawing.Size(115, 22)
        Me.tb_tel_no.TabIndex = 5
        '
        'lb_tel_no
        '
        Me.lb_tel_no.AutoSize = True
        Me.lb_tel_no.Location = New System.Drawing.Point(12, 71)
        Me.lb_tel_no.Name = "lb_tel_no"
        Me.lb_tel_no.Size = New System.Drawing.Size(43, 14)
        Me.lb_tel_no.TabIndex = 18
        Me.lb_tel_no.Text = "Tel No"
        '
        'cb_dest
        '
        Me.cb_dest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_dest.FormattingEnabled = True
        Me.cb_dest.Location = New System.Drawing.Point(90, 40)
        Me.cb_dest.Name = "cb_dest"
        Me.cb_dest.Size = New System.Drawing.Size(115, 22)
        Me.cb_dest.TabIndex = 3
        '
        'lb_dest
        '
        Me.lb_dest.AutoSize = True
        Me.lb_dest.Location = New System.Drawing.Point(12, 43)
        Me.lb_dest.Name = "lb_dest"
        Me.lb_dest.Size = New System.Drawing.Size(68, 14)
        Me.lb_dest.TabIndex = 16
        Me.lb_dest.Text = "Destination"
        '
        'tb_address
        '
        Me.tb_address.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_address.Location = New System.Drawing.Point(399, 40)
        Me.tb_address.Multiline = True
        Me.tb_address.Name = "tb_address"
        Me.tb_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_address.Size = New System.Drawing.Size(329, 50)
        Me.tb_address.TabIndex = 4
        '
        'lb_address
        '
        Me.lb_address.AutoSize = True
        Me.lb_address.Location = New System.Drawing.Point(299, 43)
        Me.lb_address.Name = "lb_address"
        Me.lb_address.Size = New System.Drawing.Size(50, 14)
        Me.lb_address.TabIndex = 14
        Me.lb_address.Text = "Address"
        '
        'tb_cus_name
        '
        Me.tb_cus_name.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tb_cus_name.Location = New System.Drawing.Point(399, 12)
        Me.tb_cus_name.MaxLength = 50
        Me.tb_cus_name.Name = "tb_cus_name"
        Me.tb_cus_name.Size = New System.Drawing.Size(220, 22)
        Me.tb_cus_name.TabIndex = 2
        '
        'lb_cus_name
        '
        Me.lb_cus_name.AutoSize = True
        Me.lb_cus_name.Location = New System.Drawing.Point(299, 15)
        Me.lb_cus_name.Name = "lb_cus_name"
        Me.lb_cus_name.Size = New System.Drawing.Size(94, 14)
        Me.lb_cus_name.TabIndex = 12
        Me.lb_cus_name.Text = "Customer Name"
        '
        'tb_cus_id
        '
        Me.tb_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_cus_id.Location = New System.Drawing.Point(90, 12)
        Me.tb_cus_id.MaxLength = 10
        Me.tb_cus_id.Name = "tb_cus_id"
        Me.tb_cus_id.Size = New System.Drawing.Size(115, 22)
        Me.tb_cus_id.TabIndex = 1
        '
        'lb_cus_id
        '
        Me.lb_cus_id.AutoSize = True
        Me.lb_cus_id.Location = New System.Drawing.Point(9, 15)
        Me.lb_cus_id.Name = "lb_cus_id"
        Me.lb_cus_id.Size = New System.Drawing.Size(75, 14)
        Me.lb_cus_id.TabIndex = 10
        Me.lb_cus_id.Text = "Customer ID"
        '
        'frm_POS005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 396)
        Me.Controls.Add(Me.tb_tel_no)
        Me.Controls.Add(Me.lb_tel_no)
        Me.Controls.Add(Me.cb_dest)
        Me.Controls.Add(Me.lb_dest)
        Me.Controls.Add(Me.tb_address)
        Me.Controls.Add(Me.lb_address)
        Me.Controls.Add(Me.tb_cus_name)
        Me.Controls.Add(Me.lb_cus_name)
        Me.Controls.Add(Me.tb_cus_id)
        Me.Controls.Add(Me.lb_cus_id)
        Me.Controls.Add(Me.dgv_lst_cus)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_search)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frm_POS005"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup Select Customer"
        CType(Me.dgv_lst_cus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents b_search As System.Windows.Forms.Button
    Friend WithEvents dgv_lst_cus As System.Windows.Forms.DataGridView
    Friend WithEvents tb_tel_no As System.Windows.Forms.TextBox
    Friend WithEvents lb_tel_no As System.Windows.Forms.Label
    Friend WithEvents cb_dest As System.Windows.Forms.ComboBox
    Friend WithEvents lb_dest As System.Windows.Forms.Label
    Friend WithEvents tb_address As System.Windows.Forms.TextBox
    Friend WithEvents lb_address As System.Windows.Forms.Label
    Friend WithEvents tb_cus_name As System.Windows.Forms.TextBox
    Friend WithEvents lb_cus_name As System.Windows.Forms.Label
    Friend WithEvents tb_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents lb_cus_id As System.Windows.Forms.Label
End Class
