<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SMFG005
    Inherits jp.co.ait.common.forms.ABCDBCForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.btn_action = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_msg = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Stock Move "
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'btn_action
        '
        Me.btn_action.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_action.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_action.BorderWidth = 2
        Me.btn_action.ClickEnabled = True
        Me.btn_action.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.btn_action.FontColor = System.Drawing.Color.White
        Me.btn_action.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btn_action.LabelText = "F1 :CONTINUE"
        Me.btn_action.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_action.Location = New System.Drawing.Point(55, 270)
        Me.btn_action.Name = "btn_action"
        Me.btn_action.PnlLocked = False
        Me.btn_action.Size = New System.Drawing.Size(130, 40)
        Me.btn_action.SplitChar = "\n"
        '
        'lbl_msg
        '
        Me.lbl_msg.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_msg.Location = New System.Drawing.Point(0, 100)
        Me.lbl_msg.Name = "lbl_msg"
        Me.lbl_msg.Size = New System.Drawing.Size(236, 110)
        Me.lbl_msg.Text = "Move  Successfully !"
        Me.lbl_msg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frm_SMFG005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.btn_action)
        Me.Controls.Add(Me.lbl_msg)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_SMFG005"
        Me.Text = "frm_SMFG005"
        Me.Controls.SetChildIndex(Me.lbl_msg, 0)
        Me.Controls.SetChildIndex(Me.btn_action, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_action As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_msg As jp.co.ait.common.forms.ABCDBCLabel
End Class
