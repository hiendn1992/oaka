<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SHS003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SHS003))
        Me.lb_today = New System.Windows.Forms.Label
        Me.b_search = New System.Windows.Forms.Button
        Me.tb_item_name = New System.Windows.Forms.TextBox
        Me.b_pop_item = New System.Windows.Forms.Button
        Me.tb_item_code = New System.Windows.Forms.TextBox
        Me.lb_item_code = New System.Windows.Forms.Label
        Me.dgv_shipment_request = New System.Windows.Forms.DataGridView
        Me.tb_pallet_no = New System.Windows.Forms.TextBox
        Me.b_add = New System.Windows.Forms.Button
        Me.b_exit = New System.Windows.Forms.Button
        Me.lb_pallet_no = New System.Windows.Forms.Label
        Me.b_select_all = New System.Windows.Forms.Button
        Me.b_unselect_all = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgv_shipment_request, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_today
        '
        Me.lb_today.Location = New System.Drawing.Point(587, 1)
        Me.lb_today.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_today.Name = "lb_today"
        Me.lb_today.Size = New System.Drawing.Size(237, 20)
        Me.lb_today.TabIndex = 0
        Me.lb_today.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lb_today.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'b_search
        '
        Me.b_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_search.Location = New System.Drawing.Point(749, 24)
        Me.b_search.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_search.Name = "b_search"
        Me.b_search.Size = New System.Drawing.Size(75, 22)
        Me.b_search.TabIndex = 3
        Me.b_search.Text = "Search"
        Me.b_search.UseVisualStyleBackColor = False
        '
        'tb_item_name
        '
        Me.tb_item_name.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_name.Location = New System.Drawing.Point(271, 25)
        Me.tb_item_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_name.MaxLength = 100
        Me.tb_item_name.Name = "tb_item_name"
        Me.tb_item_name.Size = New System.Drawing.Size(401, 22)
        Me.tb_item_name.TabIndex = 2
        Me.tb_item_name.TabStop = False
        '
        'b_pop_item
        '
        Me.b_pop_item.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_pop_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.b_pop_item.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_pop_item.Location = New System.Drawing.Point(243, 25)
        Me.b_pop_item.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_pop_item.Name = "b_pop_item"
        Me.b_pop_item.Size = New System.Drawing.Size(24, 22)
        Me.b_pop_item.TabIndex = 2
        Me.b_pop_item.Text = "?"
        Me.b_pop_item.UseVisualStyleBackColor = False
        '
        'tb_item_code
        '
        Me.tb_item_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_item_code.Location = New System.Drawing.Point(58, 25)
        Me.tb_item_code.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_item_code.MaxLength = 50
        Me.tb_item_code.Name = "tb_item_code"
        Me.tb_item_code.Size = New System.Drawing.Size(182, 22)
        Me.tb_item_code.TabIndex = 1
        '
        'lb_item_code
        '
        Me.lb_item_code.AutoSize = True
        Me.lb_item_code.Location = New System.Drawing.Point(10, 28)
        Me.lb_item_code.Name = "lb_item_code"
        Me.lb_item_code.Size = New System.Drawing.Size(33, 14)
        Me.lb_item_code.TabIndex = 6
        Me.lb_item_code.Text = "Item"
        '
        'dgv_shipment_request
        '
        Me.dgv_shipment_request.AllowUserToAddRows = False
        Me.dgv_shipment_request.AllowUserToDeleteRows = False
        Me.dgv_shipment_request.AllowUserToResizeRows = False
        Me.dgv_shipment_request.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_shipment_request.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_shipment_request.Location = New System.Drawing.Point(10, 51)
        Me.dgv_shipment_request.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgv_shipment_request.Name = "dgv_shipment_request"
        Me.dgv_shipment_request.RowHeadersVisible = False
        Me.dgv_shipment_request.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_shipment_request.Size = New System.Drawing.Size(814, 254)
        Me.dgv_shipment_request.TabIndex = 4
        '
        'tb_pallet_no
        '
        Me.tb_pallet_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tb_pallet_no.Location = New System.Drawing.Point(94, 341)
        Me.tb_pallet_no.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tb_pallet_no.MaxLength = 5
        Me.tb_pallet_no.Name = "tb_pallet_no"
        Me.tb_pallet_no.Size = New System.Drawing.Size(120, 22)
        Me.tb_pallet_no.TabIndex = 7
        '
        'b_add
        '
        Me.b_add.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_add.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_add.Location = New System.Drawing.Point(668, 364)
        Me.b_add.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_add.Name = "b_add"
        Me.b_add.Size = New System.Drawing.Size(75, 22)
        Me.b_add.TabIndex = 8
        Me.b_add.Text = "Add"
        Me.b_add.UseVisualStyleBackColor = False
        '
        'b_exit
        '
        Me.b_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_exit.Location = New System.Drawing.Point(749, 364)
        Me.b_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_exit.Name = "b_exit"
        Me.b_exit.Size = New System.Drawing.Size(75, 22)
        Me.b_exit.TabIndex = 9
        Me.b_exit.Text = "Exit"
        Me.b_exit.UseVisualStyleBackColor = False
        '
        'lb_pallet_no
        '
        Me.lb_pallet_no.AutoSize = True
        Me.lb_pallet_no.Location = New System.Drawing.Point(10, 342)
        Me.lb_pallet_no.Name = "lb_pallet_no"
        Me.lb_pallet_no.Size = New System.Drawing.Size(55, 14)
        Me.lb_pallet_no.TabIndex = 12
        Me.lb_pallet_no.Text = "Pallet No"
        '
        'b_select_all
        '
        Me.b_select_all.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_select_all.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_select_all.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_select_all.Location = New System.Drawing.Point(10, 315)
        Me.b_select_all.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_select_all.Name = "b_select_all"
        Me.b_select_all.Size = New System.Drawing.Size(75, 22)
        Me.b_select_all.TabIndex = 5
        Me.b_select_all.Text = "Select All"
        Me.b_select_all.UseVisualStyleBackColor = False
        '
        'b_unselect_all
        '
        Me.b_unselect_all.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_unselect_all.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_unselect_all.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_unselect_all.Location = New System.Drawing.Point(94, 315)
        Me.b_unselect_all.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_unselect_all.Name = "b_unselect_all"
        Me.b_unselect_all.Size = New System.Drawing.Size(75, 22)
        Me.b_unselect_all.TabIndex = 6
        Me.b_unselect_all.Text = "Unselect All"
        Me.b_unselect_all.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(40, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(64, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 14)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "*"
        '
        'frm_SHS003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 393)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.b_unselect_all)
        Me.Controls.Add(Me.b_select_all)
        Me.Controls.Add(Me.lb_pallet_no)
        Me.Controls.Add(Me.b_exit)
        Me.Controls.Add(Me.b_add)
        Me.Controls.Add(Me.tb_pallet_no)
        Me.Controls.Add(Me.dgv_shipment_request)
        Me.Controls.Add(Me.lb_item_code)
        Me.Controls.Add(Me.tb_item_code)
        Me.Controls.Add(Me.b_pop_item)
        Me.Controls.Add(Me.tb_item_name)
        Me.Controls.Add(Me.b_search)
        Me.Controls.Add(Me.lb_today)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_SHS003"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipment Request Add Detail"
        CType(Me.dgv_shipment_request, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_today As System.Windows.Forms.Label
    Friend WithEvents b_search As System.Windows.Forms.Button
    Friend WithEvents tb_item_name As System.Windows.Forms.TextBox
    Friend WithEvents b_pop_item As System.Windows.Forms.Button
    Friend WithEvents tb_item_code As System.Windows.Forms.TextBox
    Friend WithEvents lb_item_code As System.Windows.Forms.Label
    Friend WithEvents dgv_shipment_request As System.Windows.Forms.DataGridView
    Friend WithEvents tb_pallet_no As System.Windows.Forms.TextBox
    Friend WithEvents b_add As System.Windows.Forms.Button
    Friend WithEvents b_exit As System.Windows.Forms.Button
    Friend WithEvents lb_pallet_no As System.Windows.Forms.Label
    Friend WithEvents b_select_all As System.Windows.Forms.Button
    Friend WithEvents b_unselect_all As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
