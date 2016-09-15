<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Menu002
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
        Me.pnl_Imp = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Rej = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Ret = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Return = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Stock = New jp.co.ait.common.forms.ABCDBCPanel
        Me.AbcdbcPanel1 = New jp.co.ait.common.forms.ABCDBCPanel
        Me.AbcdbcPanel2 = New jp.co.ait.common.forms.ABCDBCPanel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Menu W900"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_Imp
        '
        Me.pnl_Imp.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Imp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Imp.BorderWidth = 1
        Me.pnl_Imp.ClickEnabled = True
        Me.pnl_Imp.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Imp.FontColor = System.Drawing.Color.White
        Me.pnl_Imp.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Imp.LabelText = "1 : Import"
        Me.pnl_Imp.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Imp.Location = New System.Drawing.Point(20, 44)
        Me.pnl_Imp.Name = "pnl_Imp"
        Me.pnl_Imp.PnlLocked = False
        Me.pnl_Imp.Size = New System.Drawing.Size(200, 30)
        Me.pnl_Imp.SplitChar = "\n"
        '
        'pnl_Rej
        '
        Me.pnl_Rej.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Rej.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Rej.BorderWidth = 1
        Me.pnl_Rej.ClickEnabled = True
        Me.pnl_Rej.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Rej.FontColor = System.Drawing.Color.White
        Me.pnl_Rej.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Rej.LabelText = "2 : Reject"
        Me.pnl_Rej.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Rej.Location = New System.Drawing.Point(20, 79)
        Me.pnl_Rej.Name = "pnl_Rej"
        Me.pnl_Rej.PnlLocked = False
        Me.pnl_Rej.Size = New System.Drawing.Size(200, 30)
        Me.pnl_Rej.SplitChar = "\n"
        '
        'pnl_Ret
        '
        Me.pnl_Ret.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Ret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Ret.BorderWidth = 1
        Me.pnl_Ret.ClickEnabled = True
        Me.pnl_Ret.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Ret.FontColor = System.Drawing.Color.White
        Me.pnl_Ret.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Ret.LabelText = "3 : Retrieve"
        Me.pnl_Ret.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Ret.Location = New System.Drawing.Point(20, 115)
        Me.pnl_Ret.Name = "pnl_Ret"
        Me.pnl_Ret.PnlLocked = False
        Me.pnl_Ret.Size = New System.Drawing.Size(200, 30)
        Me.pnl_Ret.SplitChar = "\n"
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
        Me.pnl_Return.Location = New System.Drawing.Point(60, 270)
        Me.pnl_Return.Name = "pnl_Return"
        Me.pnl_Return.PnlLocked = False
        Me.pnl_Return.Size = New System.Drawing.Size(120, 40)
        Me.pnl_Return.SplitChar = "\n"
        '
        'pnl_Stock
        '
        Me.pnl_Stock.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Stock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Stock.BorderWidth = 1
        Me.pnl_Stock.ClickEnabled = True
        Me.pnl_Stock.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Stock.FontColor = System.Drawing.Color.White
        Me.pnl_Stock.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Stock.LabelText = "4 : Stocktaking"
        Me.pnl_Stock.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Stock.Location = New System.Drawing.Point(20, 151)
        Me.pnl_Stock.Name = "pnl_Stock"
        Me.pnl_Stock.PnlLocked = False
        Me.pnl_Stock.Size = New System.Drawing.Size(200, 30)
        Me.pnl_Stock.SplitChar = "\n"
        '
        'AbcdbcPanel1
        '
        Me.AbcdbcPanel1.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.AbcdbcPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AbcdbcPanel1.BorderWidth = 1
        Me.AbcdbcPanel1.ClickEnabled = True
        Me.AbcdbcPanel1.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.AbcdbcPanel1.FontColor = System.Drawing.Color.White
        Me.AbcdbcPanel1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AbcdbcPanel1.LabelText = "5 : Return MOLD"
        Me.AbcdbcPanel1.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AbcdbcPanel1.Location = New System.Drawing.Point(19, 185)
        Me.AbcdbcPanel1.Name = "AbcdbcPanel1"
        Me.AbcdbcPanel1.PnlLocked = False
        Me.AbcdbcPanel1.Size = New System.Drawing.Size(200, 30)
        Me.AbcdbcPanel1.SplitChar = "\n"
        '
        'AbcdbcPanel2
        '
        Me.AbcdbcPanel2.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.AbcdbcPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AbcdbcPanel2.BorderWidth = 1
        Me.AbcdbcPanel2.ClickEnabled = True
        Me.AbcdbcPanel2.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.AbcdbcPanel2.FontColor = System.Drawing.Color.White
        Me.AbcdbcPanel2.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AbcdbcPanel2.LabelText = "6 : Stock Delete"
        Me.AbcdbcPanel2.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AbcdbcPanel2.Location = New System.Drawing.Point(19, 220)
        Me.AbcdbcPanel2.Name = "AbcdbcPanel2"
        Me.AbcdbcPanel2.PnlLocked = False
        Me.AbcdbcPanel2.Size = New System.Drawing.Size(200, 30)
        Me.AbcdbcPanel2.SplitChar = "\n"
        '
        'frm_Menu002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.AbcdbcPanel2)
        Me.Controls.Add(Me.AbcdbcPanel1)
        Me.Controls.Add(Me.pnl_Stock)
        Me.Controls.Add(Me.pnl_Ret)
        Me.Controls.Add(Me.pnl_Return)
        Me.Controls.Add(Me.pnl_Imp)
        Me.Controls.Add(Me.pnl_Rej)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_Menu002"
        Me.Controls.SetChildIndex(Me.pnl_Rej, 0)
        Me.Controls.SetChildIndex(Me.pnl_Imp, 0)
        Me.Controls.SetChildIndex(Me.pnl_Return, 0)
        Me.Controls.SetChildIndex(Me.pnl_Ret, 0)
        Me.Controls.SetChildIndex(Me.pnl_Stock, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcPanel1, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcPanel2, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Imp As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Rej As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Ret As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Return As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Stock As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents AbcdbcPanel1 As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents AbcdbcPanel2 As jp.co.ait.common.forms.ABCDBCPanel
End Class
