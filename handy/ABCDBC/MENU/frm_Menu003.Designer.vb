<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Menu003
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
        Me.pnl_Ship = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Stock = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Return = New jp.co.ait.common.forms.ABCDBCPanel
        Me.AbcdbcPanel1 = New jp.co.ait.common.forms.ABCDBCPanel
        Me.AbcdbcPanel2 = New jp.co.ait.common.forms.ABCDBCPanel
        Me.AbcdbcPanel3 = New jp.co.ait.common.forms.ABCDBCPanel
        Me.AbcdbcPanel4 = New jp.co.ait.common.forms.ABCDBCPanel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Menu W830"
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
        Me.pnl_Imp.Location = New System.Drawing.Point(19, 30)
        Me.pnl_Imp.Name = "pnl_Imp"
        Me.pnl_Imp.PnlLocked = False
        Me.pnl_Imp.Size = New System.Drawing.Size(200, 25)
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
        Me.pnl_Rej.LabelText = "3 : Reject"
        Me.pnl_Rej.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Rej.Location = New System.Drawing.Point(19, 92)
        Me.pnl_Rej.Name = "pnl_Rej"
        Me.pnl_Rej.PnlLocked = False
        Me.pnl_Rej.Size = New System.Drawing.Size(200, 25)
        Me.pnl_Rej.SplitChar = "\n"
        '
        'pnl_Ship
        '
        Me.pnl_Ship.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Ship.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Ship.BorderWidth = 1
        Me.pnl_Ship.ClickEnabled = True
        Me.pnl_Ship.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Ship.FontColor = System.Drawing.Color.White
        Me.pnl_Ship.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Ship.LabelText = "4 : Shipment"
        Me.pnl_Ship.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Ship.Location = New System.Drawing.Point(19, 123)
        Me.pnl_Ship.Name = "pnl_Ship"
        Me.pnl_Ship.PnlLocked = False
        Me.pnl_Ship.Size = New System.Drawing.Size(200, 25)
        Me.pnl_Ship.SplitChar = "\n"
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
        Me.pnl_Stock.LabelText = "5 : Stocktaking"
        Me.pnl_Stock.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Stock.Location = New System.Drawing.Point(19, 154)
        Me.pnl_Stock.Name = "pnl_Stock"
        Me.pnl_Stock.PnlLocked = False
        Me.pnl_Stock.Size = New System.Drawing.Size(200, 25)
        Me.pnl_Stock.SplitChar = "\n"
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
        Me.pnl_Return.LabelText = "F2 :RETURN"
        Me.pnl_Return.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Return.Location = New System.Drawing.Point(55, 278)
        Me.pnl_Return.Name = "pnl_Return"
        Me.pnl_Return.PnlLocked = False
        Me.pnl_Return.Size = New System.Drawing.Size(120, 30)
        Me.pnl_Return.SplitChar = "\n"
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
        Me.AbcdbcPanel1.LabelText = "6 : Stock Move"
        Me.AbcdbcPanel1.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AbcdbcPanel1.Location = New System.Drawing.Point(19, 185)
        Me.AbcdbcPanel1.Name = "AbcdbcPanel1"
        Me.AbcdbcPanel1.PnlLocked = False
        Me.AbcdbcPanel1.Size = New System.Drawing.Size(200, 25)
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
        Me.AbcdbcPanel2.LabelText = "7 : Stock Delete"
        Me.AbcdbcPanel2.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AbcdbcPanel2.Location = New System.Drawing.Point(19, 216)
        Me.AbcdbcPanel2.Name = "AbcdbcPanel2"
        Me.AbcdbcPanel2.PnlLocked = False
        Me.AbcdbcPanel2.Size = New System.Drawing.Size(200, 25)
        Me.AbcdbcPanel2.SplitChar = "\n"
        '
        'AbcdbcPanel3
        '
        Me.AbcdbcPanel3.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.AbcdbcPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AbcdbcPanel3.BorderWidth = 1
        Me.AbcdbcPanel3.ClickEnabled = True
        Me.AbcdbcPanel3.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.AbcdbcPanel3.FontColor = System.Drawing.Color.White
        Me.AbcdbcPanel3.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AbcdbcPanel3.LabelText = "2 :Set Rack"
        Me.AbcdbcPanel3.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AbcdbcPanel3.Location = New System.Drawing.Point(19, 61)
        Me.AbcdbcPanel3.Name = "AbcdbcPanel3"
        Me.AbcdbcPanel3.PnlLocked = False
        Me.AbcdbcPanel3.Size = New System.Drawing.Size(200, 25)
        Me.AbcdbcPanel3.SplitChar = "\n"
        '
        'AbcdbcPanel4
        '
        Me.AbcdbcPanel4.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.AbcdbcPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AbcdbcPanel4.BorderWidth = 1
        Me.AbcdbcPanel4.ClickEnabled = True
        Me.AbcdbcPanel4.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.AbcdbcPanel4.FontColor = System.Drawing.Color.White
        Me.AbcdbcPanel4.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AbcdbcPanel4.LabelText = "8 : Return W900"
        Me.AbcdbcPanel4.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AbcdbcPanel4.Location = New System.Drawing.Point(19, 247)
        Me.AbcdbcPanel4.Name = "AbcdbcPanel4"
        Me.AbcdbcPanel4.PnlLocked = False
        Me.AbcdbcPanel4.Size = New System.Drawing.Size(200, 25)
        Me.AbcdbcPanel4.SplitChar = "\n"
        '
        'frm_Menu003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.AbcdbcPanel4)
        Me.Controls.Add(Me.AbcdbcPanel3)
        Me.Controls.Add(Me.AbcdbcPanel2)
        Me.Controls.Add(Me.AbcdbcPanel1)
        Me.Controls.Add(Me.pnl_Stock)
        Me.Controls.Add(Me.pnl_Return)
        Me.Controls.Add(Me.pnl_Ship)
        Me.Controls.Add(Me.pnl_Rej)
        Me.Controls.Add(Me.pnl_Imp)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_Menu003"
        Me.Controls.SetChildIndex(Me.pnl_Imp, 0)
        Me.Controls.SetChildIndex(Me.pnl_Rej, 0)
        Me.Controls.SetChildIndex(Me.pnl_Ship, 0)
        Me.Controls.SetChildIndex(Me.pnl_Return, 0)
        Me.Controls.SetChildIndex(Me.pnl_Stock, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcPanel1, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcPanel2, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcPanel3, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcPanel4, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Imp As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Rej As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Ship As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Stock As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Return As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents AbcdbcPanel1 As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents AbcdbcPanel2 As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents AbcdbcPanel3 As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents AbcdbcPanel4 As jp.co.ait.common.forms.ABCDBCPanel
End Class
