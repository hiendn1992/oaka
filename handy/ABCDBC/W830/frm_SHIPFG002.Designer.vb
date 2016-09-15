<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SHIPFG002
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
        Me.lbl_msg1 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_msg3 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_msg2 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "SHIPMENT"
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
        'lbl_msg1
        '
        Me.lbl_msg1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_msg1.Location = New System.Drawing.Point(0, 50)
        Me.lbl_msg1.Name = "lbl_msg1"
        Me.lbl_msg1.Size = New System.Drawing.Size(240, 40)
        Me.lbl_msg1.Text = "Shipment Req No:"
        Me.lbl_msg1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_msg3
        '
        Me.lbl_msg3.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_msg3.Location = New System.Drawing.Point(0, 160)
        Me.lbl_msg3.Name = "lbl_msg3"
        Me.lbl_msg3.Size = New System.Drawing.Size(240, 100)
        Me.lbl_msg3.Text = "lbl_msg2"
        Me.lbl_msg3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_msg2
        '
        Me.lbl_msg2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_msg2.Location = New System.Drawing.Point(0, 100)
        Me.lbl_msg2.Name = "lbl_msg2"
        Me.lbl_msg2.Size = New System.Drawing.Size(240, 40)
        Me.lbl_msg2.Text = "0"
        Me.lbl_msg2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frm_SHIPFG002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.lbl_msg2)
        Me.Controls.Add(Me.lbl_msg3)
        Me.Controls.Add(Me.lbl_msg1)
        Me.Controls.Add(Me.pnl_RETURN)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_SHIPFG002"
        Me.Text = "frm_SHIPFG002"
        Me.Controls.SetChildIndex(Me.pnl_RETURN, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_msg1, 0)
        Me.Controls.SetChildIndex(Me.lbl_msg3, 0)
        Me.Controls.SetChildIndex(Me.lbl_msg2, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_RETURN As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_msg1 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_msg3 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_msg2 As jp.co.ait.common.forms.ABCDBCLabel
End Class
