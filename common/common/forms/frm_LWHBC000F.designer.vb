<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LWHBC000F
    Inherits jp.co.ait.common.forms.ABCDBCForm

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnl_OK = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_MSG = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.BackColor = System.Drawing.Color.White
        Me.pnl_TITLE.LabelText = "作業形態選択(日)エラー"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_TITLE.PnlLocked = True
        '
        'pnl_OK
        '
        Me.pnl_OK.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_OK.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_OK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_OK.BorderWidth = 1
        Me.pnl_OK.ClickEnabled = True
        Me.pnl_OK.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_OK.FontColor = System.Drawing.Color.White
        Me.pnl_OK.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_OK.LabelText = "F2 : RETURN"
        Me.pnl_OK.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_OK.Location = New System.Drawing.Point(60, 265)
        Me.pnl_OK.Name = "pnl_OK"
        Me.pnl_OK.PnlLocked = False
        Me.pnl_OK.Size = New System.Drawing.Size(120, 40)
        Me.pnl_OK.SplitChar = "\n"
        '
        'lbl_MSG
        '
        Me.lbl_MSG.Font = New System.Drawing.Font("Tahoma", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_MSG.ForeColor = System.Drawing.Color.Blue
        Me.lbl_MSG.Location = New System.Drawing.Point(3, 32)
        Me.lbl_MSG.Name = "lbl_MSG"
        Me.lbl_MSG.Size = New System.Drawing.Size(234, 223)
        Me.lbl_MSG.Text = "エラー表示領域"
        Me.lbl_MSG.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frm_LWHBC000F
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(240, 320)
        Me.Controls.Add(Me.lbl_MSG)
        Me.Controls.Add(Me.pnl_OK)
        Me.Font = New System.Drawing.Font("MS PGothic", 12.0!, System.Drawing.FontStyle.Regular)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frm_LWHBC000F"
        Me.ScreenID = "LWHBC000F"
        Me.ScreenName = "作業形態選択(日)エラー"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.pnl_OK, 0)
        Me.Controls.SetChildIndex(Me.lbl_MSG, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_OK As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_MSG As jp.co.ait.common.forms.ABCDBCLabel

End Class
