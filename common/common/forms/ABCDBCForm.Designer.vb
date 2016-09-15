Namespace jp.co.ait.common.forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ABCDBCForm
        Inherits ABCDBCFormBase

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
            Me.pnl_TITLE = New jp.co.ait.common.forms.ABCDBCPanel
            Me.SuspendLayout()
            '
            'pnl_TITLE
            '
            Me.pnl_TITLE.BorderColor = System.Drawing.SystemColors.WindowFrame
            Me.pnl_TITLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnl_TITLE.BorderWidth = 1
            Me.pnl_TITLE.ClickEnabled = True
            Me.pnl_TITLE.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL0
            Me.pnl_TITLE.FontColor = System.Drawing.Color.Black
            Me.pnl_TITLE.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.pnl_TITLE.LabelText = "Name"
            Me.pnl_TITLE.LableFont = New System.Drawing.Font("ＭＳ ゴシック", 14.0!, System.Drawing.FontStyle.Bold)
            Me.pnl_TITLE.Location = New System.Drawing.Point(0, 0)
            Me.pnl_TITLE.Name = "pnl_TITLE"
            Me.pnl_TITLE.PnlLocked = False
            Me.pnl_TITLE.Size = New System.Drawing.Size(240, 24)
            Me.pnl_TITLE.SplitChar = "\n"
            '
            'ABCDBCForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(240, 320)
            Me.Controls.Add(Me.pnl_TITLE)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "ABCDBCForm"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub
        Public WithEvents pnl_TITLE As ABCDBCPanel

    End Class
End Namespace