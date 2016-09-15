<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PRS006
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PRS006))
        Me.infoUser = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.barcodeNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.partNo = New System.Windows.Forms.TextBox
        Me.partName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.qtyPerBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.curLotNo = New System.Windows.Forms.TextBox
        Me.updateLabel = New System.Windows.Forms.Button
        Me.reissueLabel = New System.Windows.Forms.Button
        Me.returnMenu = New System.Windows.Forms.Button
        Me.cancelData = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'infoUser
        '
        Me.infoUser.Location = New System.Drawing.Point(417, 0)
        Me.infoUser.Name = "infoUser"
        Me.infoUser.Size = New System.Drawing.Size(304, 20)
        Me.infoUser.TabIndex = 0
        Me.infoUser.Text = "User ID: AAAAAAAA - Today: dd/MM/yyyy"
        Me.infoUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Barcode No:"
        '
        'barcodeNo
        '
        Me.barcodeNo.Location = New System.Drawing.Point(109, 27)
        Me.barcodeNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barcodeNo.MaxLength = 14
        Me.barcodeNo.Name = "barcodeNo"
        Me.barcodeNo.Size = New System.Drawing.Size(106, 22)
        Me.barcodeNo.TabIndex = 2
        Me.barcodeNo.Text = "01234567890123"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Item Code:"
        '
        'partNo
        '
        Me.partNo.Location = New System.Drawing.Point(109, 54)
        Me.partNo.MaxLength = 50
        Me.partNo.Name = "partNo"
        Me.partNo.Size = New System.Drawing.Size(182, 22)
        Me.partNo.TabIndex = 4
        Me.partNo.Text = "0123456789012345678901234"
        '
        'partName
        '
        Me.partName.Location = New System.Drawing.Point(297, 54)
        Me.partName.MaxLength = 100
        Me.partName.Name = "partName"
        Me.partName.Size = New System.Drawing.Size(357, 22)
        Me.partName.TabIndex = 5
        Me.partName.Text = "01234567890123456789012345678901234567890123456789"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Qty Per Box:"
        '
        'qtyPerBox
        '
        Me.qtyPerBox.Location = New System.Drawing.Point(109, 82)
        Me.qtyPerBox.MaxLength = 4
        Me.qtyPerBox.Name = "qtyPerBox"
        Me.qtyPerBox.Size = New System.Drawing.Size(68, 22)
        Me.qtyPerBox.TabIndex = 7
        Me.qtyPerBox.Text = "0,000"
        Me.qtyPerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(183, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pcs"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Current Lot No:"
        '
        'curLotNo
        '
        Me.curLotNo.Location = New System.Drawing.Point(109, 110)
        Me.curLotNo.MaxLength = 30
        Me.curLotNo.Name = "curLotNo"
        Me.curLotNo.Size = New System.Drawing.Size(222, 22)
        Me.curLotNo.TabIndex = 10
        Me.curLotNo.Text = "012345678901234567890123456789"
        '
        'updateLabel
        '
        Me.updateLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.updateLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.updateLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.updateLabel.Location = New System.Drawing.Point(403, 138)
        Me.updateLabel.Name = "updateLabel"
        Me.updateLabel.Size = New System.Drawing.Size(75, 22)
        Me.updateLabel.TabIndex = 11
        Me.updateLabel.Text = "Update"
        Me.updateLabel.UseVisualStyleBackColor = False
        '
        'reissueLabel
        '
        Me.reissueLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.reissueLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.reissueLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.reissueLabel.Location = New System.Drawing.Point(484, 138)
        Me.reissueLabel.Name = "reissueLabel"
        Me.reissueLabel.Size = New System.Drawing.Size(75, 22)
        Me.reissueLabel.TabIndex = 12
        Me.reissueLabel.Text = "Reissue"
        Me.reissueLabel.UseVisualStyleBackColor = False
        '
        'returnMenu
        '
        Me.returnMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.returnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.returnMenu.ForeColor = System.Drawing.SystemColors.Control
        Me.returnMenu.Location = New System.Drawing.Point(646, 138)
        Me.returnMenu.Name = "returnMenu"
        Me.returnMenu.Size = New System.Drawing.Size(75, 22)
        Me.returnMenu.TabIndex = 13
        Me.returnMenu.Text = "Exit"
        Me.returnMenu.UseVisualStyleBackColor = False
        '
        'cancelData
        '
        Me.cancelData.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.cancelData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cancelData.ForeColor = System.Drawing.SystemColors.Control
        Me.cancelData.Location = New System.Drawing.Point(565, 137)
        Me.cancelData.Name = "cancelData"
        Me.cancelData.Size = New System.Drawing.Size(75, 23)
        Me.cancelData.TabIndex = 14
        Me.cancelData.Text = "Cancel"
        Me.cancelData.UseVisualStyleBackColor = False
        '
        'frm_PRS006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 169)
        Me.Controls.Add(Me.cancelData)
        Me.Controls.Add(Me.returnMenu)
        Me.Controls.Add(Me.reissueLabel)
        Me.Controls.Add(Me.updateLabel)
        Me.Controls.Add(Me.curLotNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.qtyPerBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.partName)
        Me.Controls.Add(Me.partNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.barcodeNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.infoUser)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_PRS006"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Label Information (Same/Different W/O) "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents infoUser As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents barcodeNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents partNo As System.Windows.Forms.TextBox
    Friend WithEvents partName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents qtyPerBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents curLotNo As System.Windows.Forms.TextBox
    Friend WithEvents updateLabel As System.Windows.Forms.Button
    Friend WithEvents reissueLabel As System.Windows.Forms.Button
    Friend WithEvents returnMenu As System.Windows.Forms.Button
    Friend WithEvents cancelData As System.Windows.Forms.Button
End Class
