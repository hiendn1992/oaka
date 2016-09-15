<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MSG001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MSG001))
        Me.lb_message = New System.Windows.Forms.Label
        Me.btn_agree = New System.Windows.Forms.Button
        Me.btn_disagree = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lb_message
        '
        Me.lb_message.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_message.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lb_message.Location = New System.Drawing.Point(3, 3)
        Me.lb_message.Name = "lb_message"
        Me.lb_message.Size = New System.Drawing.Size(348, 56)
        Me.lb_message.TabIndex = 0
        Me.lb_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_agree
        '
        Me.btn_agree.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_agree.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_agree.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_agree.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agree.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_agree.Location = New System.Drawing.Point(195, 65)
        Me.btn_agree.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_agree.Name = "btn_agree"
        Me.btn_agree.Size = New System.Drawing.Size(75, 24)
        Me.btn_agree.TabIndex = 7
        Me.btn_agree.Text = "Yes"
        Me.btn_agree.UseVisualStyleBackColor = False
        '
        'btn_disagree
        '
        Me.btn_disagree.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btn_disagree.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_disagree.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_disagree.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_disagree.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_disagree.Location = New System.Drawing.Point(276, 65)
        Me.btn_disagree.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_disagree.Name = "btn_disagree"
        Me.btn_disagree.Size = New System.Drawing.Size(75, 24)
        Me.btn_disagree.TabIndex = 8
        Me.btn_disagree.Text = "No"
        Me.btn_disagree.UseVisualStyleBackColor = False
        '
        'frm_MSG001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_disagree)
        Me.Controls.Add(Me.btn_agree)
        Me.Controls.Add(Me.lb_message)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_MSG001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lb_message As System.Windows.Forms.Label
    Friend WithEvents btn_agree As System.Windows.Forms.Button
    Friend WithEvents btn_disagree As System.Windows.Forms.Button
End Class
