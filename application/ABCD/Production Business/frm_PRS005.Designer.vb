<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PRS005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PRS005))
        Me.txt_wo_no = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_barcode_from = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_barcode_to = New System.Windows.Forms.TextBox
        Me.txt_quantity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgv_list_label = New System.Windows.Forms.DataGridView
        Me.btn_exit = New System.Windows.Forms.Button
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_execute = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_info_user = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_cancel = New System.Windows.Forms.Button
        CType(Me.dgv_list_label, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_wo_no
        '
        Me.txt_wo_no.Location = New System.Drawing.Point(80, 23)
        Me.txt_wo_no.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_wo_no.MaxLength = 10
        Me.txt_wo_no.Name = "txt_wo_no"
        Me.txt_wo_no.Size = New System.Drawing.Size(116, 22)
        Me.txt_wo_no.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "WO No:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(273, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Current Box No:"
        '
        'txt_barcode_from
        '
        Me.txt_barcode_from.Enabled = False
        Me.txt_barcode_from.Location = New System.Drawing.Point(388, 23)
        Me.txt_barcode_from.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_barcode_from.MaxLength = 14
        Me.txt_barcode_from.Name = "txt_barcode_from"
        Me.txt_barcode_from.Size = New System.Drawing.Size(116, 22)
        Me.txt_barcode_from.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(511, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "~"
        '
        'txt_barcode_to
        '
        Me.txt_barcode_to.Enabled = False
        Me.txt_barcode_to.Location = New System.Drawing.Point(535, 23)
        Me.txt_barcode_to.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_barcode_to.MaxLength = 14
        Me.txt_barcode_to.Name = "txt_barcode_to"
        Me.txt_barcode_to.Size = New System.Drawing.Size(116, 22)
        Me.txt_barcode_to.TabIndex = 2
        '
        'txt_quantity
        '
        Me.txt_quantity.Enabled = False
        Me.txt_quantity.Location = New System.Drawing.Point(798, 22)
        Me.txt_quantity.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_quantity.MaxLength = 4
        Me.txt_quantity.Name = "txt_quantity"
        Me.txt_quantity.Size = New System.Drawing.Size(116, 22)
        Me.txt_quantity.TabIndex = 3
        Me.txt_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(734, 26)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Quantity:"
        '
        'dgv_list_label
        '
        Me.dgv_list_label.AllowUserToAddRows = False
        Me.dgv_list_label.AllowUserToDeleteRows = False
        Me.dgv_list_label.AllowUserToResizeRows = False
        Me.dgv_list_label.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_list_label.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_list_label.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_list_label.Location = New System.Drawing.Point(14, 74)
        Me.dgv_list_label.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.dgv_list_label.Name = "dgv_list_label"
        Me.dgv_list_label.ReadOnly = True
        Me.dgv_list_label.RowHeadersVisible = False
        Me.dgv_list_label.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list_label.Size = New System.Drawing.Size(901, 254)
        Me.dgv_list_label.TabIndex = 8
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(840, 332)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 9
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(839, 48)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 4
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_execute
        '
        Me.btn_execute.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_execute.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_execute.Location = New System.Drawing.Point(674, 332)
        Me.btn_execute.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btn_execute.Name = "btn_execute"
        Me.btn_execute.Size = New System.Drawing.Size(75, 22)
        Me.btn_execute.TabIndex = 8
        Me.btn_execute.Text = "Execute"
        Me.btn_execute.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(59, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 14)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "*"
        '
        'lbl_info_user
        '
        Me.lbl_info_user.Location = New System.Drawing.Point(679, 2)
        Me.lbl_info_user.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_info_user.Name = "lbl_info_user"
        Me.lbl_info_user.Size = New System.Drawing.Size(235, 14)
        Me.lbl_info_user.TabIndex = 17
        Me.lbl_info_user.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_info_user.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(367, 26)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 14)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "*"
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_cancel.Location = New System.Drawing.Point(757, 332)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 22)
        Me.btn_cancel.TabIndex = 19
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'frm_PRS005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 359)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl_info_user)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_execute)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.dgv_list_label)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_quantity)
        Me.Controls.Add(Me.txt_barcode_to)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_barcode_from)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_wo_no)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_PRS005"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Label Information"
        CType(Me.dgv_list_label, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_wo_no As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_barcode_from As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_barcode_to As System.Windows.Forms.TextBox
    Friend WithEvents txt_quantity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv_list_label As System.Windows.Forms.DataGridView
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_execute As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_info_user As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
End Class
