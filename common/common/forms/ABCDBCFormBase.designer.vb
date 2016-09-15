Namespace jp.co.ait.common.forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ABCDBCFormBase
        Inherits System.Windows.Forms.Form

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
            Me.SuspendLayout()
            '
            'BSWBCFormBase
            '
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(240, 320)
            Me.ControlBox = False
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "ABCDBCFormBase"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub

    End Class
End Namespace