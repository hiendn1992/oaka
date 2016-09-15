<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Menu001
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
        Me.pnl_W900 = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_FG = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Return = New jp.co.ait.common.forms.ABCDBCPanel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Menu"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_W900
        '
        Me.pnl_W900.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_W900.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_W900.BorderWidth = 1
        Me.pnl_W900.ClickEnabled = True
        Me.pnl_W900.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_W900.FontColor = System.Drawing.Color.White
        Me.pnl_W900.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_W900.LabelText = "1 : W900"
        Me.pnl_W900.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_W900.Location = New System.Drawing.Point(20, 60)
        Me.pnl_W900.Name = "pnl_W900"
        Me.pnl_W900.PnlLocked = False
        Me.pnl_W900.Size = New System.Drawing.Size(200, 60)
        Me.pnl_W900.SplitChar = "\n"
        '
        'pnl_FG
        '
        Me.pnl_FG.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_FG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_FG.BorderWidth = 1
        Me.pnl_FG.ClickEnabled = True
        Me.pnl_FG.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_FG.FontColor = System.Drawing.Color.White
        Me.pnl_FG.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_FG.LabelText = "2 : W830"
        Me.pnl_FG.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_FG.Location = New System.Drawing.Point(20, 150)
        Me.pnl_FG.Name = "pnl_FG"
        Me.pnl_FG.PnlLocked = False
        Me.pnl_FG.Size = New System.Drawing.Size(200, 60)
        Me.pnl_FG.SplitChar = "\n"
        '
        'pnl_Return
        '
        Me.pnl_Return.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Return.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Return.BorderWidth = 1
        Me.pnl_Return.ClickEnabled = True
        Me.pnl_Return.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Return.FontColor = System.Drawing.Color.White
        Me.pnl_Return.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Return.LabelText = "F2 : RETURN"
        Me.pnl_Return.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Return.Location = New System.Drawing.Point(60, 260)
        Me.pnl_Return.Name = "pnl_Return"
        Me.pnl_Return.PnlLocked = False
        Me.pnl_Return.Size = New System.Drawing.Size(120, 50)
        Me.pnl_Return.SplitChar = "\n"
        '
        'frm_Menu001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.pnl_Return)
        Me.Controls.Add(Me.pnl_FG)
        Me.Controls.Add(Me.pnl_W900)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_Menu001"
        Me.Controls.SetChildIndex(Me.pnl_W900, 0)
        Me.Controls.SetChildIndex(Me.pnl_FG, 0)
        Me.Controls.SetChildIndex(Me.pnl_Return, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_W900 As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_FG As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Return As jp.co.ait.common.forms.ABCDBCPanel
End Class
