<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_REJ002
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
        Me.pnl_Export = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Return = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_Itm1 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.AbcdbcLabel3 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.AbcdbcLabel5 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_Itm2 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_Itm3 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_ITEMNM = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_ITEMCD = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_BCNO = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_warehouseCd = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "REJECT W900"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_Export
        '
        Me.pnl_Export.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Export.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Export.BorderWidth = 1
        Me.pnl_Export.ClickEnabled = True
        Me.pnl_Export.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Export.FontColor = System.Drawing.Color.White
        Me.pnl_Export.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Export.LabelText = "F1 :REJECT"
        Me.pnl_Export.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Export.Location = New System.Drawing.Point(10, 265)
        Me.pnl_Export.Name = "pnl_Export"
        Me.pnl_Export.PnlLocked = False
        Me.pnl_Export.Size = New System.Drawing.Size(105, 40)
        Me.pnl_Export.SplitChar = "\n"
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
        Me.pnl_Return.Location = New System.Drawing.Point(125, 265)
        Me.pnl_Return.Name = "pnl_Return"
        Me.pnl_Return.PnlLocked = False
        Me.pnl_Return.Size = New System.Drawing.Size(105, 40)
        Me.pnl_Return.SplitChar = "\n"
        '
        'lbl_Itm1
        '
        Me.lbl_Itm1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm1.Location = New System.Drawing.Point(10, 70)
        Me.lbl_Itm1.Name = "lbl_Itm1"
        Me.lbl_Itm1.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm1.Text = "Barcode No:"
        '
        'AbcdbcLabel3
        '
        Me.AbcdbcLabel3.Location = New System.Drawing.Point(10, 93)
        Me.AbcdbcLabel3.Name = "AbcdbcLabel3"
        Me.AbcdbcLabel3.Size = New System.Drawing.Size(0, 17)
        '
        'AbcdbcLabel5
        '
        Me.AbcdbcLabel5.Location = New System.Drawing.Point(10, 135)
        Me.AbcdbcLabel5.Name = "AbcdbcLabel5"
        Me.AbcdbcLabel5.Size = New System.Drawing.Size(92, 17)
        '
        'lbl_Itm2
        '
        Me.lbl_Itm2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm2.Location = New System.Drawing.Point(10, 130)
        Me.lbl_Itm2.Name = "lbl_Itm2"
        Me.lbl_Itm2.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm2.Text = "Item Code   :"
        '
        'lbl_Itm3
        '
        Me.lbl_Itm3.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm3.Location = New System.Drawing.Point(10, 190)
        Me.lbl_Itm3.Name = "lbl_Itm3"
        Me.lbl_Itm3.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm3.Text = "Item Name:   "
        '
        'lbl_ITEMNM
        '
        Me.lbl_ITEMNM.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMNM.Location = New System.Drawing.Point(10, 230)
        Me.lbl_ITEMNM.Name = "lbl_ITEMNM"
        Me.lbl_ITEMNM.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_ITEMCD
        '
        Me.lbl_ITEMCD.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMCD.Location = New System.Drawing.Point(10, 160)
        Me.lbl_ITEMCD.Name = "lbl_ITEMCD"
        Me.lbl_ITEMCD.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_BCNO
        '
        Me.lbl_BCNO.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_BCNO.Location = New System.Drawing.Point(10, 100)
        Me.lbl_BCNO.Name = "lbl_BCNO"
        Me.lbl_BCNO.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_warehouseCd
        '
        Me.lbl_warehouseCd.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_warehouseCd.ForeColor = System.Drawing.Color.Blue
        Me.lbl_warehouseCd.Location = New System.Drawing.Point(0, 36)
        Me.lbl_warehouseCd.Name = "lbl_warehouseCd"
        Me.lbl_warehouseCd.Size = New System.Drawing.Size(240, 24)
        '
        'frm_REJ002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.lbl_warehouseCd)
        Me.Controls.Add(Me.lbl_BCNO)
        Me.Controls.Add(Me.lbl_ITEMCD)
        Me.Controls.Add(Me.lbl_ITEMNM)
        Me.Controls.Add(Me.lbl_Itm3)
        Me.Controls.Add(Me.lbl_Itm2)
        Me.Controls.Add(Me.AbcdbcLabel5)
        Me.Controls.Add(Me.AbcdbcLabel3)
        Me.Controls.Add(Me.lbl_Itm1)
        Me.Controls.Add(Me.pnl_Return)
        Me.Controls.Add(Me.pnl_Export)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_REJ002"
        Me.Text = "frm_REJ002"
        Me.Controls.SetChildIndex(Me.pnl_Export, 0)
        Me.Controls.SetChildIndex(Me.pnl_Return, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm1, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcLabel3, 0)
        Me.Controls.SetChildIndex(Me.AbcdbcLabel5, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm2, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm3, 0)
        Me.Controls.SetChildIndex(Me.lbl_ITEMNM, 0)
        Me.Controls.SetChildIndex(Me.lbl_ITEMCD, 0)
        Me.Controls.SetChildIndex(Me.lbl_BCNO, 0)
        Me.Controls.SetChildIndex(Me.lbl_warehouseCd, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Export As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Return As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_Itm1 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents AbcdbcLabel3 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents AbcdbcLabel5 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_Itm2 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_Itm3 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_ITEMNM As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_ITEMCD As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_BCNO As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_warehouseCd As jp.co.ait.common.forms.ABCDBCLabel
End Class
