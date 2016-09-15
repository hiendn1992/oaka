<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PRS004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PRS004))
        Me.txt_barcode_no = New System.Windows.Forms.TextBox
        Me.txt_part_no = New System.Windows.Forms.TextBox
        Me.txt_part_name = New System.Windows.Forms.TextBox
        Me.txt_quantity = New System.Windows.Forms.TextBox
        Me.txt_lot_no = New System.Windows.Forms.TextBox
        Me.btn_execute = New System.Windows.Forms.Button
        Me.btn_reissue = New System.Windows.Forms.Button
        Me.btn_exit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_required_1 = New System.Windows.Forms.Label
        Me.txt_required_2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_wo_no = New System.Windows.Forms.TextBox
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.txt_barcode_to = New System.Windows.Forms.TextBox
        Me.txt_lot_no_to = New System.Windows.Forms.TextBox
        Me.txt_quantity_to = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.infoLoginToday = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txt_barcode_no
        '
        Me.txt_barcode_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_barcode_no.Location = New System.Drawing.Point(103, 46)
        Me.txt_barcode_no.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_barcode_no.MaxLength = 14
        Me.txt_barcode_no.Name = "txt_barcode_no"
        Me.txt_barcode_no.Size = New System.Drawing.Size(109, 22)
        Me.txt_barcode_no.TabIndex = 4
        Me.txt_barcode_no.Text = "15032700020019"
        '
        'txt_part_no
        '
        Me.txt_part_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_part_no.Location = New System.Drawing.Point(324, 20)
        Me.txt_part_no.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_part_no.MaxLength = 50
        Me.txt_part_no.Name = "txt_part_no"
        Me.txt_part_no.Size = New System.Drawing.Size(105, 22)
        Me.txt_part_no.TabIndex = 2
        Me.txt_part_no.Text = "7254-0438-3W(3)   "
        '
        'txt_part_name
        '
        Me.txt_part_name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_part_name.Location = New System.Drawing.Point(437, 20)
        Me.txt_part_name.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_part_name.MaxLength = 100
        Me.txt_part_name.Name = "txt_part_name"
        Me.txt_part_name.Size = New System.Drawing.Size(295, 22)
        Me.txt_part_name.TabIndex = 3
        Me.txt_part_name.Text = "LH R/N FRAME ASSEMBLY DIE3 20150327 141756 !"
        '
        'txt_quantity
        '
        Me.txt_quantity.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_quantity.Location = New System.Drawing.Point(677, 46)
        Me.txt_quantity.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_quantity.MaxLength = 4
        Me.txt_quantity.Name = "txt_quantity"
        Me.txt_quantity.Size = New System.Drawing.Size(40, 22)
        Me.txt_quantity.TabIndex = 6
        Me.txt_quantity.Text = "0,000"
        Me.txt_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_lot_no
        '
        Me.txt_lot_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lot_no.Location = New System.Drawing.Point(324, 46)
        Me.txt_lot_no.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_lot_no.MaxLength = 30
        Me.txt_lot_no.Name = "txt_lot_no"
        Me.txt_lot_no.Size = New System.Drawing.Size(200, 22)
        Me.txt_lot_no.TabIndex = 5
        Me.txt_lot_no.Text = "70002-20150327/28/29/30/31/32"
        '
        'btn_execute
        '
        Me.btn_execute.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_execute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_execute.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_execute.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_execute.Location = New System.Drawing.Point(475, 98)
        Me.btn_execute.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btn_execute.Name = "btn_execute"
        Me.btn_execute.Size = New System.Drawing.Size(75, 22)
        Me.btn_execute.TabIndex = 10
        Me.btn_execute.Text = "Execute"
        Me.btn_execute.UseVisualStyleBackColor = False
        '
        'btn_reissue
        '
        Me.btn_reissue.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_reissue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_reissue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reissue.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_reissue.Location = New System.Drawing.Point(558, 98)
        Me.btn_reissue.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btn_reissue.Name = "btn_reissue"
        Me.btn_reissue.Size = New System.Drawing.Size(75, 22)
        Me.btn_reissue.TabIndex = 11
        Me.btn_reissue.Text = "Reissue"
        Me.btn_reissue.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_exit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exit.Location = New System.Drawing.Point(722, 98)
        Me.btn_exit.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(75, 22)
        Me.btn_exit.TabIndex = 13
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Barcode From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(241, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Item Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(574, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Quantity From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(241, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Lot No From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(725, 49)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Pcs"
        '
        'txt_required_1
        '
        Me.txt_required_1.AutoSize = True
        Me.txt_required_1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_required_1.ForeColor = System.Drawing.Color.Red
        Me.txt_required_1.Location = New System.Drawing.Point(655, 48)
        Me.txt_required_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txt_required_1.Name = "txt_required_1"
        Me.txt_required_1.Size = New System.Drawing.Size(14, 14)
        Me.txt_required_1.TabIndex = 15
        Me.txt_required_1.Text = "*"
        Me.txt_required_1.Visible = False
        '
        'txt_required_2
        '
        Me.txt_required_2.AutoSize = True
        Me.txt_required_2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_required_2.ForeColor = System.Drawing.Color.Red
        Me.txt_required_2.Location = New System.Drawing.Point(309, 49)
        Me.txt_required_2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txt_required_2.Name = "txt_required_2"
        Me.txt_required_2.Size = New System.Drawing.Size(14, 14)
        Me.txt_required_2.TabIndex = 16
        Me.txt_required_2.Text = "*"
        Me.txt_required_2.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 23)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 14)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "WO No"
        '
        'txt_wo_no
        '
        Me.txt_wo_no.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_wo_no.Location = New System.Drawing.Point(103, 20)
        Me.txt_wo_no.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.txt_wo_no.MaxLength = 10
        Me.txt_wo_no.Name = "txt_wo_no"
        Me.txt_wo_no.Size = New System.Drawing.Size(109, 22)
        Me.txt_wo_no.TabIndex = 1
        Me.txt_wo_no.Text = "1503270002"
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_cancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_cancel.Location = New System.Drawing.Point(640, 98)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 22)
        Me.btn_cancel.TabIndex = 12
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'txt_barcode_to
        '
        Me.txt_barcode_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_barcode_to.Location = New System.Drawing.Point(103, 72)
        Me.txt_barcode_to.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_barcode_to.MaxLength = 14
        Me.txt_barcode_to.Name = "txt_barcode_to"
        Me.txt_barcode_to.Size = New System.Drawing.Size(109, 22)
        Me.txt_barcode_to.TabIndex = 7
        Me.txt_barcode_to.Text = "15032700020019"
        '
        'txt_lot_no_to
        '
        Me.txt_lot_no_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lot_no_to.Location = New System.Drawing.Point(324, 72)
        Me.txt_lot_no_to.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_lot_no_to.MaxLength = 30
        Me.txt_lot_no_to.Name = "txt_lot_no_to"
        Me.txt_lot_no_to.Size = New System.Drawing.Size(200, 22)
        Me.txt_lot_no_to.TabIndex = 8
        Me.txt_lot_no_to.Text = "70002-20150327/28/29/30/31/32"
        '
        'txt_quantity_to
        '
        Me.txt_quantity_to.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_quantity_to.Location = New System.Drawing.Point(677, 72)
        Me.txt_quantity_to.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_quantity_to.MaxLength = 4
        Me.txt_quantity_to.Name = "txt_quantity_to"
        Me.txt_quantity_to.Size = New System.Drawing.Size(40, 22)
        Me.txt_quantity_to.TabIndex = 9
        Me.txt_quantity_to.Text = "0,000"
        Me.txt_quantity_to.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(725, 75)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Pcs"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 75)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Barcode To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(241, 75)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 14)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Lot No To"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(574, 75)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 14)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Quantity To"
        '
        'infoLoginToday
        '
        Me.infoLoginToday.Location = New System.Drawing.Point(563, 0)
        Me.infoLoginToday.Name = "infoLoginToday"
        Me.infoLoginToday.Size = New System.Drawing.Size(234, 18)
        Me.infoLoginToday.TabIndex = 26
        Me.infoLoginToday.Text = "User ID: XXXXXXXX - Today: dd/MM/yyyy"
        Me.infoLoginToday.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frm_PRS004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 128)
        Me.Controls.Add(Me.infoLoginToday)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_quantity_to)
        Me.Controls.Add(Me.txt_lot_no_to)
        Me.Controls.Add(Me.txt_barcode_to)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.txt_wo_no)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_required_2)
        Me.Controls.Add(Me.txt_required_1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_reissue)
        Me.Controls.Add(Me.btn_execute)
        Me.Controls.Add(Me.txt_lot_no)
        Me.Controls.Add(Me.txt_quantity)
        Me.Controls.Add(Me.txt_part_name)
        Me.Controls.Add(Me.txt_part_no)
        Me.Controls.Add(Me.txt_barcode_no)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.MaximizeBox = False
        Me.Name = "frm_PRS004"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Label Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_barcode_no As System.Windows.Forms.TextBox
    Friend WithEvents txt_part_no As System.Windows.Forms.TextBox
    Friend WithEvents txt_part_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_quantity As System.Windows.Forms.TextBox
    Friend WithEvents txt_lot_no As System.Windows.Forms.TextBox
    Friend WithEvents btn_execute As System.Windows.Forms.Button
    Friend WithEvents btn_reissue As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_required_1 As System.Windows.Forms.Label
    Friend WithEvents txt_required_2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_wo_no As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents txt_barcode_to As System.Windows.Forms.TextBox
    Friend WithEvents txt_lot_no_to As System.Windows.Forms.TextBox
    Friend WithEvents txt_quantity_to As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents infoLoginToday As System.Windows.Forms.Label
End Class
