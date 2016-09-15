<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSS008
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSS008))
        Me.grd_rack_inqry = New System.Windows.Forms.DataGridView
        Me.btn_search = New System.Windows.Forms.Button
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.txt_rack_name = New System.Windows.Forms.TextBox
        Me.txt_rack_code = New System.Windows.Forms.TextBox
        Me.lbl_rack_name = New System.Windows.Forms.Label
        Me.lbl_rack_code = New System.Windows.Forms.Label
        Me.btn_export = New System.Windows.Forms.Button
        Me.sfdDialog = New System.Windows.Forms.SaveFileDialog
        Me.lbl_today_date = New System.Windows.Forms.Label
        CType(Me.grd_rack_inqry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd_rack_inqry
        '
        Me.grd_rack_inqry.AllowUserToAddRows = False
        Me.grd_rack_inqry.AllowUserToDeleteRows = False
        Me.grd_rack_inqry.AllowUserToResizeRows = False
        Me.grd_rack_inqry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grd_rack_inqry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_rack_inqry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_rack_inqry.Location = New System.Drawing.Point(13, 75)
        Me.grd_rack_inqry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grd_rack_inqry.Name = "grd_rack_inqry"
        Me.grd_rack_inqry.ReadOnly = True
        Me.grd_rack_inqry.RowHeadersVisible = False
        Me.grd_rack_inqry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_rack_inqry.Size = New System.Drawing.Size(513, 243)
        Me.grd_rack_inqry.TabIndex = 34
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_search.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(451, 45)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 2
        Me.btn_search.Text = "Search"
        Me.btn_search.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_clear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_clear.Location = New System.Drawing.Point(368, 324)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 22)
        Me.btn_clear.TabIndex = 4
        Me.btn_clear.Text = "Cancel"
        Me.btn_clear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(451, 324)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 5
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'txt_rack_name
        '
        Me.txt_rack_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_name.Location = New System.Drawing.Point(114, 47)
        Me.txt_rack_name.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_rack_name.MaxLength = 40
        Me.txt_rack_name.Name = "txt_rack_name"
        Me.txt_rack_name.Size = New System.Drawing.Size(258, 22)
        Me.txt_rack_name.TabIndex = 1
        '
        'txt_rack_code
        '
        Me.txt_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_rack_code.Location = New System.Drawing.Point(114, 19)
        Me.txt_rack_code.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_rack_code.MaxLength = 7
        Me.txt_rack_code.Name = "txt_rack_code"
        Me.txt_rack_code.Size = New System.Drawing.Size(126, 22)
        Me.txt_rack_code.TabIndex = 0
        '
        'lbl_rack_name
        '
        Me.lbl_rack_name.AutoSize = True
        Me.lbl_rack_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rack_name.Location = New System.Drawing.Point(10, 50)
        Me.lbl_rack_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rack_name.Name = "lbl_rack_name"
        Me.lbl_rack_name.Size = New System.Drawing.Size(67, 14)
        Me.lbl_rack_name.TabIndex = 28
        Me.lbl_rack_name.Text = "Rack Name"
        '
        'lbl_rack_code
        '
        Me.lbl_rack_code.AutoSize = True
        Me.lbl_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rack_code.Location = New System.Drawing.Point(10, 22)
        Me.lbl_rack_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rack_code.Name = "lbl_rack_code"
        Me.lbl_rack_code.Size = New System.Drawing.Size(64, 14)
        Me.lbl_rack_code.TabIndex = 26
        Me.lbl_rack_code.Text = "Rack Code"
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_export.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_export.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_export.Location = New System.Drawing.Point(285, 324)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(75, 22)
        Me.btn_export.TabIndex = 3
        Me.btn_export.Text = "Export"
        Me.btn_export.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'lbl_today_date
        '
        Me.lbl_today_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_today_date.Location = New System.Drawing.Point(282, 2)
        Me.lbl_today_date.Name = "lbl_today_date"
        Me.lbl_today_date.Size = New System.Drawing.Size(244, 14)
        Me.lbl_today_date.TabIndex = 46
        Me.lbl_today_date.Text = "User ID: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_MSS008
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 353)
        Me.Controls.Add(Me.lbl_today_date)
        Me.Controls.Add(Me.grd_rack_inqry)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.txt_rack_name)
        Me.Controls.Add(Me.txt_rack_code)
        Me.Controls.Add(Me.lbl_rack_name)
        Me.Controls.Add(Me.lbl_rack_code)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_MSS008"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rack Master Inquiry"
        CType(Me.grd_rack_inqry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_rack_inqry As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents txt_rack_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_rack_code As System.Windows.Forms.TextBox
    Friend WithEvents lbl_rack_name As System.Windows.Forms.Label
    Friend WithEvents lbl_rack_code As System.Windows.Forms.Label
    Friend WithEvents btn_export As System.Windows.Forms.Button
    Friend WithEvents sfdDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbl_today_date As System.Windows.Forms.Label
End Class
