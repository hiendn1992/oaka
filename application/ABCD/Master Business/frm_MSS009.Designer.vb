<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS009
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS009))
        Me.grd_cus_inqry = New System.Windows.Forms.DataGridView
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_export = New System.Windows.Forms.Button
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.lbl_today = New System.Windows.Forms.Label
        Me.txt_cus_id = New System.Windows.Forms.TextBox
        Me.lbl_cus_id = New System.Windows.Forms.Label
        Me.sfDialog = New System.Windows.Forms.SaveFileDialog
        Me.txt_email = New System.Windows.Forms.TextBox
        Me.txt_tel = New System.Windows.Forms.TextBox
        Me.lbl_tel = New System.Windows.Forms.Label
        Me.lbl_email = New System.Windows.Forms.Label
        Me.cmo_dest = New System.Windows.Forms.ComboBox
        Me.lbl_dest = New System.Windows.Forms.Label
        Me.lbl_address = New System.Windows.Forms.Label
        Me.txt_address = New System.Windows.Forms.TextBox
        Me.txt_cus_name = New System.Windows.Forms.TextBox
        Me.lbl_cus_name = New System.Windows.Forms.Label
        CType(Me.grd_cus_inqry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd_cus_inqry
        '
        Me.grd_cus_inqry.AllowUserToAddRows = False
        Me.grd_cus_inqry.AllowUserToDeleteRows = False
        Me.grd_cus_inqry.AllowUserToResizeRows = False
        Me.grd_cus_inqry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_cus_inqry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_cus_inqry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_cus_inqry.Location = New System.Drawing.Point(12, 127)
        Me.grd_cus_inqry.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grd_cus_inqry.Name = "grd_cus_inqry"
        Me.grd_cus_inqry.ReadOnly = True
        Me.grd_cus_inqry.RowHeadersVisible = False
        Me.grd_cus_inqry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_cus_inqry.Size = New System.Drawing.Size(792, 254)
        Me.grd_cus_inqry.TabIndex = 8
        Me.grd_cus_inqry.TabStop = False
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(729, 101)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 7
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_export.Location = New System.Drawing.Point(567, 385)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 22)
        Me.btn_export.TabIndex = 9
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_clear.Location = New System.Drawing.Point(648, 385)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 22)
        Me.btn_clear.TabIndex = 10
        Me.btn_clear.Text = "Cancel"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(729, 385)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 11
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'lbl_today
        '
        Me.lbl_today.Location = New System.Drawing.Point(538, 2)
        Me.lbl_today.Name = "lbl_today"
        Me.lbl_today.Size = New System.Drawing.Size(266, 19)
        Me.lbl_today.TabIndex = 22
        Me.lbl_today.Text = "User Id: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_cus_id
        '
        Me.txt_cus_id.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_cus_id.Location = New System.Drawing.Point(112, 23)
        Me.txt_cus_id.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_cus_id.MaxLength = 10
        Me.txt_cus_id.Name = "txt_cus_id"
        Me.txt_cus_id.Size = New System.Drawing.Size(175, 22)
        Me.txt_cus_id.TabIndex = 1
        '
        'lbl_cus_id
        '
        Me.lbl_cus_id.AutoSize = True
        Me.lbl_cus_id.Location = New System.Drawing.Point(12, 26)
        Me.lbl_cus_id.Name = "lbl_cus_id"
        Me.lbl_cus_id.Size = New System.Drawing.Size(75, 14)
        Me.lbl_cus_id.TabIndex = 31
        Me.lbl_cus_id.Text = "Customer ID"
        '
        'txt_email
        '
        Me.txt_email.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_email.Location = New System.Drawing.Point(405, 23)
        Me.txt_email.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_email.MaxLength = 40
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(249, 22)
        Me.txt_email.TabIndex = 2
        '
        'txt_tel
        '
        Me.txt_tel.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_tel.Location = New System.Drawing.Point(112, 75)
        Me.txt_tel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_tel.MaxLength = 20
        Me.txt_tel.Name = "txt_tel"
        Me.txt_tel.Size = New System.Drawing.Size(175, 22)
        Me.txt_tel.TabIndex = 5
        '
        'lbl_tel
        '
        Me.lbl_tel.AutoSize = True
        Me.lbl_tel.Location = New System.Drawing.Point(12, 78)
        Me.lbl_tel.Name = "lbl_tel"
        Me.lbl_tel.Size = New System.Drawing.Size(43, 14)
        Me.lbl_tel.TabIndex = 53
        Me.lbl_tel.Text = "Tel No"
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.Location = New System.Drawing.Point(344, 26)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(34, 14)
        Me.lbl_email.TabIndex = 52
        Me.lbl_email.Text = "Email"
        '
        'cmo_dest
        '
        Me.cmo_dest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmo_dest.FormattingEnabled = True
        Me.cmo_dest.Location = New System.Drawing.Point(112, 101)
        Me.cmo_dest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmo_dest.Name = "cmo_dest"
        Me.cmo_dest.Size = New System.Drawing.Size(145, 22)
        Me.cmo_dest.TabIndex = 6
        '
        'lbl_dest
        '
        Me.lbl_dest.AutoSize = True
        Me.lbl_dest.Location = New System.Drawing.Point(12, 104)
        Me.lbl_dest.Name = "lbl_dest"
        Me.lbl_dest.Size = New System.Drawing.Size(68, 14)
        Me.lbl_dest.TabIndex = 51
        Me.lbl_dest.Text = "Destination"
        '
        'lbl_address
        '
        Me.lbl_address.AutoSize = True
        Me.lbl_address.Location = New System.Drawing.Point(344, 52)
        Me.lbl_address.Name = "lbl_address"
        Me.lbl_address.Size = New System.Drawing.Size(50, 14)
        Me.lbl_address.TabIndex = 47
        Me.lbl_address.Text = "Address"
        '
        'txt_address
        '
        Me.txt_address.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_address.Location = New System.Drawing.Point(405, 50)
        Me.txt_address.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_address.MaxLength = 40
        Me.txt_address.Multiline = True
        Me.txt_address.Name = "txt_address"
        Me.txt_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_address.Size = New System.Drawing.Size(318, 73)
        Me.txt_address.TabIndex = 4
        '
        'txt_cus_name
        '
        Me.txt_cus_name.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_cus_name.Location = New System.Drawing.Point(112, 49)
        Me.txt_cus_name.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_cus_name.MaxLength = 50
        Me.txt_cus_name.Name = "txt_cus_name"
        Me.txt_cus_name.Size = New System.Drawing.Size(175, 22)
        Me.txt_cus_name.TabIndex = 3
        '
        'lbl_cus_name
        '
        Me.lbl_cus_name.AutoSize = True
        Me.lbl_cus_name.Location = New System.Drawing.Point(12, 53)
        Me.lbl_cus_name.Name = "lbl_cus_name"
        Me.lbl_cus_name.Size = New System.Drawing.Size(94, 14)
        Me.lbl_cus_name.TabIndex = 44
        Me.lbl_cus_name.Text = "Customer Name"
        '
        'frm_MSS009
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 414)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_tel)
        Me.Controls.Add(Me.lbl_tel)
        Me.Controls.Add(Me.lbl_email)
        Me.Controls.Add(Me.cmo_dest)
        Me.Controls.Add(Me.lbl_dest)
        Me.Controls.Add(Me.lbl_address)
        Me.Controls.Add(Me.txt_address)
        Me.Controls.Add(Me.txt_cus_name)
        Me.Controls.Add(Me.lbl_cus_name)
        Me.Controls.Add(Me.lbl_cus_id)
        Me.Controls.Add(Me.txt_cus_id)
        Me.Controls.Add(Me.lbl_today)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.grd_cus_inqry)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS009"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Master Inquiry"
        CType(Me.grd_cus_inqry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_cus_inqry As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents lbl_today As System.Windows.Forms.Label
    Friend WithEvents txt_cus_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cus_id As System.Windows.Forms.Label
    Friend WithEvents sfDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_tel As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tel As System.Windows.Forms.Label
    Friend WithEvents lbl_email As System.Windows.Forms.Label
    Friend WithEvents cmo_dest As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_dest As System.Windows.Forms.Label
    Friend WithEvents lbl_address As System.Windows.Forms.Label
    Friend WithEvents txt_address As System.Windows.Forms.TextBox
    Friend WithEvents txt_cus_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cus_name As System.Windows.Forms.Label
End Class
