<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SHIPFG001
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
        Me.pnl_OK = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_msg = New jp.co.ait.common.forms.ABCDBCLabel
        Me.txt_shipNo = New jp.co.ait.common.forms.ABCDBCTextBox
        Me.pnl_CANCEL = New jp.co.ait.common.forms.ABCDBCPanel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "SHIPMENT"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_OK
        '
        Me.pnl_OK.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_OK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_OK.BorderWidth = 1
        Me.pnl_OK.ClickEnabled = True
        Me.pnl_OK.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_OK.FontColor = System.Drawing.Color.White
        Me.pnl_OK.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_OK.LabelText = "F1 :OK"
        Me.pnl_OK.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_OK.Location = New System.Drawing.Point(10, 270)
        Me.pnl_OK.Name = "pnl_OK"
        Me.pnl_OK.PnlLocked = False
        Me.pnl_OK.Size = New System.Drawing.Size(105, 40)
        Me.pnl_OK.SplitChar = "\n"
        '
        'lbl_msg
        '
        Me.lbl_msg.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_msg.Location = New System.Drawing.Point(0, 70)
        Me.lbl_msg.Name = "lbl_msg"
        Me.lbl_msg.Size = New System.Drawing.Size(240, 40)
        Me.lbl_msg.Text = "lbl_msg"
        Me.lbl_msg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txt_shipNo
        '
        Me.txt_shipNo.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txt_shipNo.Location = New System.Drawing.Point(20, 118)
        Me.txt_shipNo.Name = "txt_shipNo"
        Me.txt_shipNo.Size = New System.Drawing.Size(200, 39)
        Me.txt_shipNo.TabIndex = 6
        '
        'pnl_CANCEL
        '
        Me.pnl_CANCEL.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_CANCEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_CANCEL.BorderWidth = 1
        Me.pnl_CANCEL.ClickEnabled = True
        Me.pnl_CANCEL.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_CANCEL.FontColor = System.Drawing.Color.White
        Me.pnl_CANCEL.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_CANCEL.LabelText = "F2 :CANCEL"
        Me.pnl_CANCEL.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_CANCEL.Location = New System.Drawing.Point(125, 270)
        Me.pnl_CANCEL.Name = "pnl_CANCEL"
        Me.pnl_CANCEL.PnlLocked = False
        Me.pnl_CANCEL.Size = New System.Drawing.Size(105, 40)
        Me.pnl_CANCEL.SplitChar = "\n"
        '
        'frm_SHIPFG001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.pnl_CANCEL)
        Me.Controls.Add(Me.txt_shipNo)
        Me.Controls.Add(Me.lbl_msg)
        Me.Controls.Add(Me.pnl_OK)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_SHIPFG001"
        Me.Text = "frm_SHIPFG001"
        Me.Controls.SetChildIndex(Me.pnl_OK, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_msg, 0)
        Me.Controls.SetChildIndex(Me.txt_shipNo, 0)
        Me.Controls.SetChildIndex(Me.pnl_CANCEL, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_OK As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_msg As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents txt_shipNo As jp.co.ait.common.forms.ABCDBCTextBox
    Friend WithEvents pnl_CANCEL As jp.co.ait.common.forms.ABCDBCPanel
End Class
