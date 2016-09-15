<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_POS002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_POS002))
        Me.btn_exit = New System.Windows.Forms.Button
        Me.txt_rack_name = New System.Windows.Forms.TextBox
        Me.txt_rack_code = New System.Windows.Forms.TextBox
        Me.lbl_rack_name = New System.Windows.Forms.Label
        Me.lbl_rack_code = New System.Windows.Forms.Label
        Me.btn_search = New System.Windows.Forms.Button
        Me.grd_rack_inqry = New System.Windows.Forms.DataGridView
        Me.btn_clear = New System.Windows.Forms.Button
        CType(Me.grd_rack_inqry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(529, 312)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 2
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'txt_rack_name
        '
        Me.txt_rack_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_name.Location = New System.Drawing.Point(87, 34)
        Me.txt_rack_name.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_rack_name.MaxLength = 40
        Me.txt_rack_name.Name = "txt_rack_name"
        Me.txt_rack_name.Size = New System.Drawing.Size(231, 22)
        Me.txt_rack_name.TabIndex = 1
        '
        'txt_rack_code
        '
        Me.txt_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rack_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_rack_code.Location = New System.Drawing.Point(87, 7)
        Me.txt_rack_code.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_rack_code.MaxLength = 7
        Me.txt_rack_code.Name = "txt_rack_code"
        Me.txt_rack_code.Size = New System.Drawing.Size(135, 22)
        Me.txt_rack_code.TabIndex = 0
        '
        'lbl_rack_name
        '
        Me.lbl_rack_name.AutoSize = True
        Me.lbl_rack_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rack_name.Location = New System.Drawing.Point(13, 36)
        Me.lbl_rack_name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rack_name.Name = "lbl_rack_name"
        Me.lbl_rack_name.Size = New System.Drawing.Size(67, 14)
        Me.lbl_rack_name.TabIndex = 21
        Me.lbl_rack_name.Text = "Rack Name"
        '
        'lbl_rack_code
        '
        Me.lbl_rack_code.AutoSize = True
        Me.lbl_rack_code.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rack_code.Location = New System.Drawing.Point(13, 9)
        Me.lbl_rack_code.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_rack_code.Name = "lbl_rack_code"
        Me.lbl_rack_code.Size = New System.Drawing.Size(64, 14)
        Me.lbl_rack_code.TabIndex = 18
        Me.lbl_rack_code.Text = "Rack Code"
        '
        'btn_search
        '
        Me.btn_search.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_search.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_search.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_search.Location = New System.Drawing.Point(529, 34)
        Me.btn_search.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 22)
        Me.btn_search.TabIndex = 23
        Me.btn_search.TabStop = False
        Me.btn_search.Text = "Search"
        Me.btn_search.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_search.UseVisualStyleBackColor = False
        '
        'grd_rack_inqry
        '
        Me.grd_rack_inqry.AllowUserToAddRows = False
        Me.grd_rack_inqry.AllowUserToDeleteRows = False
        Me.grd_rack_inqry.AllowUserToResizeRows = False
        Me.grd_rack_inqry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_rack_inqry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_rack_inqry.Location = New System.Drawing.Point(11, 62)
        Me.grd_rack_inqry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grd_rack_inqry.Name = "grd_rack_inqry"
        Me.grd_rack_inqry.ReadOnly = True
        Me.grd_rack_inqry.RowHeadersVisible = False
        Me.grd_rack_inqry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_rack_inqry.Size = New System.Drawing.Size(593, 244)
        Me.grd_rack_inqry.TabIndex = 25
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_clear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_clear.Location = New System.Drawing.Point(446, 312)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 22)
        Me.btn_clear.TabIndex = 23
        Me.btn_clear.TabStop = False
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'frm_POS002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 340)
        Me.Controls.Add(Me.grd_rack_inqry)
        Me.Controls.Add(Me.btn_search)
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
        Me.Name = "frm_POS002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Popup Select Rack"
        CType(Me.grd_rack_inqry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents txt_rack_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_rack_code As System.Windows.Forms.TextBox
    Friend WithEvents lbl_rack_name As System.Windows.Forms.Label
    Friend WithEvents lbl_rack_code As System.Windows.Forms.Label
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents grd_rack_inqry As System.Windows.Forms.DataGridView
    Friend WithEvents btn_clear As System.Windows.Forms.Button
End Class
