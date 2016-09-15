<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_POS007
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_POS007))
        Me.grd_pd_info = New System.Windows.Forms.DataGridView
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.sfDialog = New System.Windows.Forms.SaveFileDialog
        Me.txt_cus_name = New System.Windows.Forms.TextBox
        Me.btn_popup_cus = New System.Windows.Forms.Button
        Me.txt_cus_id = New System.Windows.Forms.TextBox
        Me.lbl_cus_id = New System.Windows.Forms.Label
        Me.dtp_shipment_date_to = New System.Windows.Forms.DateTimePicker
        Me.dtp_shipment_date_from = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_shipment_date = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.grd_pd_info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd_pd_info
        '
        Me.grd_pd_info.AllowUserToAddRows = False
        Me.grd_pd_info.AllowUserToDeleteRows = False
        Me.grd_pd_info.AllowUserToResizeRows = False
        Me.grd_pd_info.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_pd_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_pd_info.Location = New System.Drawing.Point(12, 69)
        Me.grd_pd_info.Name = "grd_pd_info"
        Me.grd_pd_info.ReadOnly = True
        Me.grd_pd_info.RowHeadersVisible = False
        Me.grd_pd_info.RowTemplate.Height = 24
        Me.grd_pd_info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_pd_info.Size = New System.Drawing.Size(797, 254)
        Me.grd_pd_info.TabIndex = 7
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(734, 41)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 6
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_clear.Location = New System.Drawing.Point(653, 328)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 22)
        Me.btn_clear.TabIndex = 8
        Me.btn_clear.Text = "Cancel"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(734, 328)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 9
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'txt_cus_name
        '
        Me.txt_cus_name.Location = New System.Drawing.Point(267, 13)
        Me.txt_cus_name.MaxLength = 50
        Me.txt_cus_name.Name = "txt_cus_name"
        Me.txt_cus_name.ReadOnly = True
        Me.txt_cus_name.Size = New System.Drawing.Size(277, 22)
        Me.txt_cus_name.TabIndex = 3
        '
        'btn_popup_cus
        '
        Me.btn_popup_cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_popup_cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_popup_cus.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_popup_cus.Location = New System.Drawing.Point(237, 12)
        Me.btn_popup_cus.Name = "btn_popup_cus"
        Me.btn_popup_cus.Size = New System.Drawing.Size(24, 22)
        Me.btn_popup_cus.TabIndex = 2
        Me.btn_popup_cus.Text = "?"
        Me.btn_popup_cus.UseVisualStyleBackColor = False
        '
        'txt_cus_id
        '
        Me.txt_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_cus_id.Location = New System.Drawing.Point(104, 12)
        Me.txt_cus_id.MaxLength = 10
        Me.txt_cus_id.Name = "txt_cus_id"
        Me.txt_cus_id.Size = New System.Drawing.Size(127, 22)
        Me.txt_cus_id.TabIndex = 1
        '
        'lbl_cus_id
        '
        Me.lbl_cus_id.AutoSize = True
        Me.lbl_cus_id.Location = New System.Drawing.Point(9, 15)
        Me.lbl_cus_id.Name = "lbl_cus_id"
        Me.lbl_cus_id.Size = New System.Drawing.Size(59, 14)
        Me.lbl_cus_id.TabIndex = 58
        Me.lbl_cus_id.Text = "Customer"
        '
        'dtp_shipment_date_to
        '
        Me.dtp_shipment_date_to.CustomFormat = "dd/MM/yyyy"
        Me.dtp_shipment_date_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_shipment_date_to.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtp_shipment_date_to.Location = New System.Drawing.Point(277, 41)
        Me.dtp_shipment_date_to.Name = "dtp_shipment_date_to"
        Me.dtp_shipment_date_to.Size = New System.Drawing.Size(145, 22)
        Me.dtp_shipment_date_to.TabIndex = 5
        Me.dtp_shipment_date_to.Value = New Date(2015, 1, 13, 8, 56, 2, 0)
        '
        'dtp_shipment_date_from
        '
        Me.dtp_shipment_date_from.CustomFormat = "dd/MM/yyyy"
        Me.dtp_shipment_date_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_shipment_date_from.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dtp_shipment_date_from.Location = New System.Drawing.Point(104, 41)
        Me.dtp_shipment_date_from.Name = "dtp_shipment_date_from"
        Me.dtp_shipment_date_from.Size = New System.Drawing.Size(145, 22)
        Me.dtp_shipment_date_from.TabIndex = 4
        Me.dtp_shipment_date_from.Value = New Date(2015, 1, 13, 8, 56, 2, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(255, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 14)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "~"
        '
        'lbl_shipment_date
        '
        Me.lbl_shipment_date.AutoSize = True
        Me.lbl_shipment_date.Location = New System.Drawing.Point(9, 46)
        Me.lbl_shipment_date.Name = "lbl_shipment_date"
        Me.lbl_shipment_date.Size = New System.Drawing.Size(89, 14)
        Me.lbl_shipment_date.TabIndex = 62
        Me.lbl_shipment_date.Text = "Shipment Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(66, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 14)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "*"
        '
        'frm_POS007
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 355)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtp_shipment_date_to)
        Me.Controls.Add(Me.dtp_shipment_date_from)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_shipment_date)
        Me.Controls.Add(Me.txt_cus_name)
        Me.Controls.Add(Me.btn_popup_cus)
        Me.Controls.Add(Me.txt_cus_id)
        Me.Controls.Add(Me.lbl_cus_id)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.grd_pd_info)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_POS007"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup Select Shipment Request Info"
        CType(Me.grd_pd_info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_pd_info As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents sfDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txt_cus_name As System.Windows.Forms.TextBox
    Friend WithEvents btn_popup_cus As System.Windows.Forms.Button
    Friend WithEvents txt_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cus_id As System.Windows.Forms.Label
    Friend WithEvents dtp_shipment_date_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_shipment_date_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_shipment_date As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
