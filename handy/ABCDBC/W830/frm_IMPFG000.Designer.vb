<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_IMPFG000
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
        Me.pnl_Subcon = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_ShipReturn = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Return = New jp.co.ait.common.forms.ABCDBCPanel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Import W830"
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
        Me.pnl_W900.LabelText = "1: From W900"
        Me.pnl_W900.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_W900.Location = New System.Drawing.Point(19, 70)
        Me.pnl_W900.Name = "pnl_W900"
        Me.pnl_W900.PnlLocked = False
        Me.pnl_W900.Size = New System.Drawing.Size(200, 25)
        Me.pnl_W900.SplitChar = "\n"
        '
        'pnl_Subcon
        '
        Me.pnl_Subcon.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Subcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Subcon.BorderWidth = 1
        Me.pnl_Subcon.ClickEnabled = True
        Me.pnl_Subcon.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Subcon.FontColor = System.Drawing.Color.White
        Me.pnl_Subcon.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Subcon.LabelText = "2: From Subcon"
        Me.pnl_Subcon.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Subcon.Location = New System.Drawing.Point(19, 122)
        Me.pnl_Subcon.Name = "pnl_Subcon"
        Me.pnl_Subcon.PnlLocked = False
        Me.pnl_Subcon.Size = New System.Drawing.Size(200, 25)
        Me.pnl_Subcon.SplitChar = "\n"
        '
        'pnl_ShipReturn
        '
        Me.pnl_ShipReturn.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_ShipReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_ShipReturn.BorderWidth = 1
        Me.pnl_ShipReturn.ClickEnabled = True
        Me.pnl_ShipReturn.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_ShipReturn.FontColor = System.Drawing.Color.White
        Me.pnl_ShipReturn.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_ShipReturn.LabelText = "3: Shipment Return"
        Me.pnl_ShipReturn.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_ShipReturn.Location = New System.Drawing.Point(19, 175)
        Me.pnl_ShipReturn.Name = "pnl_ShipReturn"
        Me.pnl_ShipReturn.PnlLocked = False
        Me.pnl_ShipReturn.Size = New System.Drawing.Size(200, 25)
        Me.pnl_ShipReturn.SplitChar = "\n"
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
        Me.pnl_Return.Location = New System.Drawing.Point(60, 280)
        Me.pnl_Return.Name = "pnl_Return"
        Me.pnl_Return.PnlLocked = False
        Me.pnl_Return.Size = New System.Drawing.Size(120, 30)
        Me.pnl_Return.SplitChar = "\n"
        '
        'frm_IMPFG000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.pnl_Return)
        Me.Controls.Add(Me.pnl_ShipReturn)
        Me.Controls.Add(Me.pnl_Subcon)
        Me.Controls.Add(Me.pnl_W900)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_IMPFG000"
        Me.Text = "frm_IMPFG000"
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.pnl_W900, 0)
        Me.Controls.SetChildIndex(Me.pnl_Subcon, 0)
        Me.Controls.SetChildIndex(Me.pnl_ShipReturn, 0)
        Me.Controls.SetChildIndex(Me.pnl_Return, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_W900 As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Subcon As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_ShipReturn As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Return As jp.co.ait.common.forms.ABCDBCPanel
End Class
