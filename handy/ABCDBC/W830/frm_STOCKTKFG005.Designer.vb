<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_STOCKTKFG005
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
        Me.pnl_Continue = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_msg = New jp.co.ait.common.forms.ABCDBCLabel
        Me.pnl_RackNo = New jp.co.ait.common.forms.ABCDBCPanel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Stocktaking W830"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_Continue
        '
        Me.pnl_Continue.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Continue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Continue.BorderWidth = 1
        Me.pnl_Continue.ClickEnabled = True
        Me.pnl_Continue.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Continue.FontColor = System.Drawing.Color.White
        Me.pnl_Continue.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Continue.LabelText = "F1 :CONTINUE"
        Me.pnl_Continue.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Continue.Location = New System.Drawing.Point(5, 270)
        Me.pnl_Continue.Name = "pnl_Continue"
        Me.pnl_Continue.PnlLocked = False
        Me.pnl_Continue.Size = New System.Drawing.Size(120, 40)
        Me.pnl_Continue.SplitChar = "\n"
        '
        'lbl_msg
        '
        Me.lbl_msg.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_msg.Location = New System.Drawing.Point(0, 82)
        Me.lbl_msg.Name = "lbl_msg"
        Me.lbl_msg.Size = New System.Drawing.Size(236, 110)
        Me.lbl_msg.Text = "lbl_Msg"
        Me.lbl_msg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnl_RackNo
        '
        Me.pnl_RackNo.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_RackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_RackNo.BorderWidth = 1
        Me.pnl_RackNo.ClickEnabled = True
        Me.pnl_RackNo.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_RackNo.FontColor = System.Drawing.Color.White
        Me.pnl_RackNo.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_RackNo.LabelText = "F3:RACK NO"
        Me.pnl_RackNo.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_RackNo.Location = New System.Drawing.Point(130, 270)
        Me.pnl_RackNo.Name = "pnl_RackNo"
        Me.pnl_RackNo.PnlLocked = False
        Me.pnl_RackNo.Size = New System.Drawing.Size(100, 40)
        Me.pnl_RackNo.SplitChar = "\n"
        '
        'frm_STOCKTKFG005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.pnl_RackNo)
        Me.Controls.Add(Me.lbl_msg)
        Me.Controls.Add(Me.pnl_Continue)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_STOCKTKFG005"
        Me.Text = "frm_STOCKTKFG005"
        Me.Controls.SetChildIndex(Me.pnl_Continue, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_msg, 0)
        Me.Controls.SetChildIndex(Me.pnl_RackNo, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Continue As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_msg As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents pnl_RackNo As jp.co.ait.common.forms.ABCDBCPanel
End Class
