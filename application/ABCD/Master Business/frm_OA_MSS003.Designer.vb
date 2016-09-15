<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_OA_MSS003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_OA_MSS003))
        Me.lblReasonCode = New System.Windows.Forms.Label
        Me.lblReasonName = New System.Windows.Forms.Label
        Me.txtReasonCode = New System.Windows.Forms.TextBox
        Me.txtReasonName = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grdReasonInquiry = New System.Windows.Forms.DataGridView
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.sfDialog = New System.Windows.Forms.SaveFileDialog
        CType(Me.grdReasonInquiry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblReasonCode
        '
        Me.lblReasonCode.AutoSize = True
        Me.lblReasonCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReasonCode.Location = New System.Drawing.Point(13, 9)
        Me.lblReasonCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReasonCode.Name = "lblReasonCode"
        Me.lblReasonCode.Size = New System.Drawing.Size(78, 14)
        Me.lblReasonCode.TabIndex = 0
        Me.lblReasonCode.Text = "Reason Code"
        '
        'lblReasonName
        '
        Me.lblReasonName.AutoSize = True
        Me.lblReasonName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReasonName.Location = New System.Drawing.Point(13, 36)
        Me.lblReasonName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReasonName.Name = "lblReasonName"
        Me.lblReasonName.Size = New System.Drawing.Size(81, 14)
        Me.lblReasonName.TabIndex = 2
        Me.lblReasonName.Text = "Reason Name"
        '
        'txtReasonCode
        '
        Me.txtReasonCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReasonCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtReasonCode.Location = New System.Drawing.Point(97, 7)
        Me.txtReasonCode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtReasonCode.MaxLength = 7
        Me.txtReasonCode.Name = "txtReasonCode"
        Me.txtReasonCode.Size = New System.Drawing.Size(135, 22)
        Me.txtReasonCode.TabIndex = 1
        '
        'txtReasonName
        '
        Me.txtReasonName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReasonName.Location = New System.Drawing.Point(97, 34)
        Me.txtReasonName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtReasonName.MaxLength = 40
        Me.txtReasonName.Name = "txtReasonName"
        Me.txtReasonName.Size = New System.Drawing.Size(231, 22)
        Me.txtReasonName.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSearch.Location = New System.Drawing.Point(529, 34)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 22)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'grdReasonInquiry
        '
        Me.grdReasonInquiry.AllowUserToAddRows = False
        Me.grdReasonInquiry.AllowUserToDeleteRows = False
        Me.grdReasonInquiry.AllowUserToResizeRows = False
        Me.grdReasonInquiry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdReasonInquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdReasonInquiry.Location = New System.Drawing.Point(11, 62)
        Me.grdReasonInquiry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grdReasonInquiry.Name = "grdReasonInquiry"
        Me.grdReasonInquiry.ReadOnly = True
        Me.grdReasonInquiry.RowHeadersVisible = False
        Me.grdReasonInquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdReasonInquiry.Size = New System.Drawing.Size(593, 244)
        Me.grdReasonInquiry.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(446, 312)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 22)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExit.Location = New System.Drawing.Point(529, 312)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 22)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExport.Location = New System.Drawing.Point(363, 312)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 22)
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'frm_OA_MSS003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 340)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.grdReasonInquiry)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtReasonName)
        Me.Controls.Add(Me.txtReasonCode)
        Me.Controls.Add(Me.lblReasonName)
        Me.Controls.Add(Me.lblReasonCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_OA_MSS003"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reason Master Inquiry"
        CType(Me.grdReasonInquiry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblReasonCode As System.Windows.Forms.Label
    Friend WithEvents lblReasonName As System.Windows.Forms.Label
    Friend WithEvents txtReasonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReasonName As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grdReasonInquiry As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents sfDialog As System.Windows.Forms.SaveFileDialog
End Class
