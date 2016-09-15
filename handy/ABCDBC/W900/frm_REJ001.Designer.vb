<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_REJ001
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
        Me.pnl_RETURN = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_imp_count = New jp.co.ait.common.forms.ABCDBCLabel
        Me.AbcdbcLabel2 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_msg = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "REJECT W900"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_RETURN
        '
        Me.pnl_RETURN.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_RETURN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_RETURN.BorderWidth = 1
        Me.pnl_RETURN.ClickEnabled = True
        Me.pnl_RETURN.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_RETURN.FontColor = System.Drawing.Color.White
        Me.pnl_RETURN.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_RETURN.LabelText = "F2 : RETURN"
        Me.pnl_RETURN.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_RETURN.Location = New System.Drawing.Point(60, 270)
        Me.pnl_RETURN.Name = "pnl_RETURN"
        Me.pnl_RETURN.PnlLocked = False
        Me.pnl_RETURN.Size = New System.Drawing.Size(120, 40)
        Me.pnl_RETURN.SplitChar = "\n"
        '
        'lbl_imp_count
        '
        Me.lbl_imp_count.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_imp_count.Location = New System.Drawing.Point(0, 80)
        Me.lbl_imp_count.Name = "lbl_imp_count"
        Me.lbl_imp_count.Size = New System.Drawing.Size(240, 35)
        Me.lbl_imp_count.Text = "0"
        Me.lbl_imp_count.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'AbcdbcLabel2
        '
        Me.AbcdbcLabel2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.AbcdbcLabel2.Location = New System.Drawing.Point(0, 40)
        Me.AbcdbcLabel2.Name = "AbcdbcLabel2"
        Me.AbcdbcLabel2.Size = New System.Drawing.Size(240, 35)
        Me.AbcdbcLabel2.Text = "Rejected Count: "
        Me.AbcdbcLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_msg
        '
        Me.lbl_msg.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_msg.Location = New System.Drawing.Point(0, 160)
        Me.lbl_msg.Name = "lbl_msg"
        Me.lbl_msg.Size = New System.Drawing.Size(240, 100)
        Me.lbl_msg.Text = "lbl_msg"
        Me.lbl_msg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frm_REJ001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.lbl_imp_count)
        Me.Controls.Add(Me.AbcdbcLabel2)
        Me.Controls.Add(Me.lbl_msg)
        Me.Controls.Add(Me.pnl_RETURN)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_REJ001"
        Me.Text = "frm_REJ001"
        Me.Controls.SetChildIndex(Me.pnl_RETURN, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_msg, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcLabel2, 0)
        Me.Controls.SetChildIndex(Me.lbl_imp_count, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_RETURN As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_imp_count As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents AbcdbcLabel2 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_msg As jp.co.ait.common.forms.ABCDBCLabel
End Class
