<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SHS003_01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SHS003_01))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lb_pallet_no = New System.Windows.Forms.Label
        Me.lb_quantity_sum = New System.Windows.Forms.Label
        Me.lb_box_sum = New System.Windows.Forms.Label
        Me.b_ok = New System.Windows.Forms.Button
        Me.b_cancel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(74, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pallet No:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Quantity Sum:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Box Sum:"
        '
        'lb_pallet_no
        '
        Me.lb_pallet_no.AutoSize = True
        Me.lb_pallet_no.Location = New System.Drawing.Point(188, 9)
        Me.lb_pallet_no.Name = "lb_pallet_no"
        Me.lb_pallet_no.Size = New System.Drawing.Size(42, 14)
        Me.lb_pallet_no.TabIndex = 3
        Me.lb_pallet_no.Text = "Label4"
        '
        'lb_quantity_sum
        '
        Me.lb_quantity_sum.AutoSize = True
        Me.lb_quantity_sum.Location = New System.Drawing.Point(188, 40)
        Me.lb_quantity_sum.Name = "lb_quantity_sum"
        Me.lb_quantity_sum.Size = New System.Drawing.Size(42, 14)
        Me.lb_quantity_sum.TabIndex = 4
        Me.lb_quantity_sum.Text = "Label5"
        '
        'lb_box_sum
        '
        Me.lb_box_sum.AutoSize = True
        Me.lb_box_sum.Location = New System.Drawing.Point(188, 73)
        Me.lb_box_sum.Name = "lb_box_sum"
        Me.lb_box_sum.Size = New System.Drawing.Size(42, 14)
        Me.lb_box_sum.TabIndex = 5
        Me.lb_box_sum.Text = "Label6"
        '
        'b_ok
        '
        Me.b_ok.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.b_ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_ok.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_ok.Location = New System.Drawing.Point(127, 95)
        Me.b_ok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_ok.Name = "b_ok"
        Me.b_ok.Size = New System.Drawing.Size(75, 22)
        Me.b_ok.TabIndex = 6
        Me.b_ok.Text = "OK"
        Me.b_ok.UseVisualStyleBackColor = False
        '
        'b_cancel
        '
        Me.b_cancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.b_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.b_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.b_cancel.Location = New System.Drawing.Point(208, 95)
        Me.b_cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.b_cancel.Name = "b_cancel"
        Me.b_cancel.Size = New System.Drawing.Size(75, 22)
        Me.b_cancel.TabIndex = 7
        Me.b_cancel.Text = "Cancel"
        Me.b_cancel.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(256, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pcs"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Box"
        '
        'frm_SHS003_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 124)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.b_cancel)
        Me.Controls.Add(Me.b_ok)
        Me.Controls.Add(Me.lb_box_sum)
        Me.Controls.Add(Me.lb_quantity_sum)
        Me.Controls.Add(Me.lb_pallet_no)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frm_SHS003_01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipment Request Add Detail Confirm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_pallet_no As System.Windows.Forms.Label
    Friend WithEvents lb_quantity_sum As System.Windows.Forms.Label
    Friend WithEvents lb_box_sum As System.Windows.Forms.Label
    Friend WithEvents b_ok As System.Windows.Forms.Button
    Friend WithEvents b_cancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
