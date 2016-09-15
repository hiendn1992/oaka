<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SMFG002
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
        Me.pnl_CANCEL = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_title1 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_title2 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.pnl_Ok = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_WarehouseCd = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Stock Move "
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
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
        Me.pnl_CANCEL.Size = New System.Drawing.Size(100, 40)
        Me.pnl_CANCEL.SplitChar = "\n"
        '
        'lbl_title1
        '
        Me.lbl_title1.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_title1.Location = New System.Drawing.Point(5, 70)
        Me.lbl_title1.Name = "lbl_title1"
        Me.lbl_title1.Size = New System.Drawing.Size(230, 30)
        Me.lbl_title1.Text = "Confirm "
        Me.lbl_title1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_title2
        '
        Me.lbl_title2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_title2.Location = New System.Drawing.Point(5, 120)
        Me.lbl_title2.Name = "lbl_title2"
        Me.lbl_title2.Size = New System.Drawing.Size(230, 30)
        Me.lbl_title2.Text = "Dest Rack No:"
        Me.lbl_title2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnl_Ok
        '
        Me.pnl_Ok.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Ok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Ok.BorderWidth = 1
        Me.pnl_Ok.ClickEnabled = True
        Me.pnl_Ok.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Ok.FontColor = System.Drawing.Color.White
        Me.pnl_Ok.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Ok.LabelText = "F1 :OK"
        Me.pnl_Ok.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Ok.Location = New System.Drawing.Point(10, 270)
        Me.pnl_Ok.Name = "pnl_Ok"
        Me.pnl_Ok.PnlLocked = False
        Me.pnl_Ok.Size = New System.Drawing.Size(105, 40)
        Me.pnl_Ok.SplitChar = "\n"
        '
        'lbl_WarehouseCd
        '
        Me.lbl_WarehouseCd.Font = New System.Drawing.Font("MS Gothic", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_WarehouseCd.Location = New System.Drawing.Point(5, 170)
        Me.lbl_WarehouseCd.Name = "lbl_WarehouseCd"
        Me.lbl_WarehouseCd.Size = New System.Drawing.Size(230, 30)
        Me.lbl_WarehouseCd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frm_SMFG002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.lbl_WarehouseCd)
        Me.Controls.Add(Me.pnl_Ok)
        Me.Controls.Add(Me.lbl_title2)
        Me.Controls.Add(Me.lbl_title1)
        Me.Controls.Add(Me.pnl_CANCEL)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_SMFG002"
        Me.Text = "frm_SMFG002"
        Me.Controls.SetChildIndex(Me.pnl_CANCEL, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_title1, 0)
        Me.Controls.SetChildIndex(Me.lbl_title2, 0)
        Me.Controls.SetChildIndex(Me.pnl_Ok, 0)
        Me.Controls.SetChildIndex(Me.lbl_WarehouseCd, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_CANCEL As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_title1 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_title2 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents pnl_Ok As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_WarehouseCd As jp.co.ait.common.forms.ABCDBCLabel
End Class
