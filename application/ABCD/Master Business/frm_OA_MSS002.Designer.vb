<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_OA_MSS002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_OA_MSS002))
        Me.btnExit = New System.Windows.Forms.Button
        Me.rdoModeAdd = New System.Windows.Forms.RadioButton
        Me.rdoModeChange = New System.Windows.Forms.RadioButton
        Me.rdoModeDelete = New System.Windows.Forms.RadioButton
        Me.lblReasonCode = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_Reason_Name = New System.Windows.Forms.Label
        Me.txtReasonCode = New System.Windows.Forms.TextBox
        Me.txtReasonName = New System.Windows.Forms.TextBox
        Me.btnExecute = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lbl_today_date = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnExit.FlatAppearance.BorderSize = 2
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExit.Location = New System.Drawing.Point(357, 110)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 22)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'rdoModeAdd
        '
        Me.rdoModeAdd.AutoSize = True
        Me.rdoModeAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoModeAdd.Location = New System.Drawing.Point(16, 23)
        Me.rdoModeAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoModeAdd.Name = "rdoModeAdd"
        Me.rdoModeAdd.Size = New System.Drawing.Size(47, 18)
        Me.rdoModeAdd.TabIndex = 1
        Me.rdoModeAdd.Text = "Add"
        Me.rdoModeAdd.UseVisualStyleBackColor = True
        '
        'rdoModeChange
        '
        Me.rdoModeChange.AutoSize = True
        Me.rdoModeChange.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoModeChange.Location = New System.Drawing.Point(71, 23)
        Me.rdoModeChange.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoModeChange.Name = "rdoModeChange"
        Me.rdoModeChange.Size = New System.Drawing.Size(66, 18)
        Me.rdoModeChange.TabIndex = 2
        Me.rdoModeChange.Text = "Change"
        Me.rdoModeChange.UseVisualStyleBackColor = True
        '
        'rdoModeDelete
        '
        Me.rdoModeDelete.AutoSize = True
        Me.rdoModeDelete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoModeDelete.Location = New System.Drawing.Point(145, 23)
        Me.rdoModeDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoModeDelete.Name = "rdoModeDelete"
        Me.rdoModeDelete.Size = New System.Drawing.Size(61, 18)
        Me.rdoModeDelete.TabIndex = 3
        Me.rdoModeDelete.Text = "Delete"
        Me.rdoModeDelete.UseVisualStyleBackColor = True
        '
        'lblReasonCode
        '
        Me.lblReasonCode.AutoSize = True
        Me.lblReasonCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReasonCode.Location = New System.Drawing.Point(9, 52)
        Me.lblReasonCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReasonCode.Name = "lblReasonCode"
        Me.lblReasonCode.Size = New System.Drawing.Size(78, 14)
        Me.lblReasonCode.TabIndex = 4
        Me.lblReasonCode.Text = "Reason Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(86, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "*"
        '
        'lbl_Reason_Name
        '
        Me.lbl_Reason_Name.AutoSize = True
        Me.lbl_Reason_Name.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Reason_Name.Location = New System.Drawing.Point(9, 82)
        Me.lbl_Reason_Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Reason_Name.Name = "lbl_Reason_Name"
        Me.lbl_Reason_Name.Size = New System.Drawing.Size(81, 14)
        Me.lbl_Reason_Name.TabIndex = 6
        Me.lbl_Reason_Name.Text = "Reason Name"
        '
        'txtReasonCode
        '
        Me.txtReasonCode.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReasonCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtReasonCode.Location = New System.Drawing.Point(110, 49)
        Me.txtReasonCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReasonCode.MaxLength = 6
        Me.txtReasonCode.Name = "txtReasonCode"
        Me.txtReasonCode.Size = New System.Drawing.Size(89, 22)
        Me.txtReasonCode.TabIndex = 5
        '
        'txtReasonName
        '
        Me.txtReasonName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReasonName.Location = New System.Drawing.Point(110, 79)
        Me.txtReasonName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReasonName.MaxLength = 40
        Me.txtReasonName.Name = "txtReasonName"
        Me.txtReasonName.Size = New System.Drawing.Size(250, 22)
        Me.txtReasonName.TabIndex = 7
        '
        'btnExecute
        '
        Me.btnExecute.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnExecute.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnExecute.FlatAppearance.BorderSize = 2
        Me.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExecute.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExecute.Location = New System.Drawing.Point(191, 110)
        Me.btnExecute.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(75, 22)
        Me.btnExecute.TabIndex = 8
        Me.btnExecute.Text = "Execute"
        Me.btnExecute.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExecute.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(107, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnCancel.FlatAppearance.BorderSize = 2
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Location = New System.Drawing.Point(274, 109)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 22)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lbl_today_date
        '
        Me.lbl_today_date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_today_date.Location = New System.Drawing.Point(184, 2)
        Me.lbl_today_date.Name = "lbl_today_date"
        Me.lbl_today_date.Size = New System.Drawing.Size(249, 16)
        Me.lbl_today_date.TabIndex = 0
        Me.lbl_today_date.Text = "User ID: XXXXXXXX | Today: dd/MM/yyyy"
        Me.lbl_today_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_OA_MSS002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 141)
        Me.Controls.Add(Me.lbl_today_date)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.txtReasonName)
        Me.Controls.Add(Me.txtReasonCode)
        Me.Controls.Add(Me.lbl_Reason_Name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblReasonCode)
        Me.Controls.Add(Me.rdoModeDelete)
        Me.Controls.Add(Me.rdoModeChange)
        Me.Controls.Add(Me.rdoModeAdd)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_OA_MSS002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reason Master Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents rdoModeAdd As System.Windows.Forms.RadioButton
    Friend WithEvents rdoModeChange As System.Windows.Forms.RadioButton
    Friend WithEvents rdoModeDelete As System.Windows.Forms.RadioButton
    Friend WithEvents lblReasonCode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Reason_Name As System.Windows.Forms.Label
    Friend WithEvents txtReasonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReasonName As System.Windows.Forms.TextBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lbl_today_date As System.Windows.Forms.Label
End Class
