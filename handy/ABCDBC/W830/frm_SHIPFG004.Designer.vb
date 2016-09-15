<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SHIPFG004
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
        Me.pnl_Shipment = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Return = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_Itm1 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.AbcdbcLabel3 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.AbcdbcLabel5 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_Itm2 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_Itm3 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_ITEMNM = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_ITEMCD = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_BCNO = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_WH = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "SHIPMENT"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'pnl_Shipment
        '
        Me.pnl_Shipment.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Shipment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Shipment.BorderWidth = 1
        Me.pnl_Shipment.ClickEnabled = True
        Me.pnl_Shipment.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Shipment.FontColor = System.Drawing.Color.White
        Me.pnl_Shipment.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Shipment.LabelText = "F1:SHIPMENT"
        Me.pnl_Shipment.LableFont = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Shipment.Location = New System.Drawing.Point(5, 270)
        Me.pnl_Shipment.Name = "pnl_Shipment"
        Me.pnl_Shipment.PnlLocked = False
        Me.pnl_Shipment.Size = New System.Drawing.Size(115, 40)
        Me.pnl_Shipment.SplitChar = "\n"
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
        Me.pnl_Return.LableFont = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Return.Location = New System.Drawing.Point(125, 270)
        Me.pnl_Return.Name = "pnl_Return"
        Me.pnl_Return.PnlLocked = False
        Me.pnl_Return.Size = New System.Drawing.Size(105, 40)
        Me.pnl_Return.SplitChar = "\n"
        '
        'lbl_Itm1
        '
        Me.lbl_Itm1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm1.Location = New System.Drawing.Point(5, 70)
        Me.lbl_Itm1.Name = "lbl_Itm1"
        Me.lbl_Itm1.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm1.Text = "Barcode No :"
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
        Me.lbl_Itm2.Location = New System.Drawing.Point(5, 130)
        Me.lbl_Itm2.Name = "lbl_Itm2"
        Me.lbl_Itm2.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm2.Text = "Item Code :"
        '
        'lbl_Itm3
        '
        Me.lbl_Itm3.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm3.Location = New System.Drawing.Point(5, 190)
        Me.lbl_Itm3.Name = "lbl_Itm3"
        Me.lbl_Itm3.Size = New System.Drawing.Size(225, 24)
        Me.lbl_Itm3.Text = "Item Name:   "
        '
        'lbl_ITEMNM
        '
        Me.lbl_ITEMNM.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMNM.Location = New System.Drawing.Point(5, 220)
        Me.lbl_ITEMNM.Name = "lbl_ITEMNM"
        Me.lbl_ITEMNM.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_ITEMCD
        '
        Me.lbl_ITEMCD.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMCD.Location = New System.Drawing.Point(5, 160)
        Me.lbl_ITEMCD.Name = "lbl_ITEMCD"
        Me.lbl_ITEMCD.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_BCNO
        '
        Me.lbl_BCNO.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_BCNO.Location = New System.Drawing.Point(5, 100)
        Me.lbl_BCNO.Name = "lbl_BCNO"
        Me.lbl_BCNO.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_WH
        '
        Me.lbl_WH.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_WH.Location = New System.Drawing.Point(5, 40)
        Me.lbl_WH.Name = "lbl_WH"
        Me.lbl_WH.Size = New System.Drawing.Size(235, 24)
        Me.lbl_WH.Text = "Warehouse No: W830"
        '
        'frm_SHIPFG004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.lbl_WH)
        Me.Controls.Add(Me.lbl_BCNO)
        Me.Controls.Add(Me.lbl_ITEMCD)
        Me.Controls.Add(Me.lbl_ITEMNM)
        Me.Controls.Add(Me.lbl_Itm3)
        Me.Controls.Add(Me.lbl_Itm2)
        Me.Controls.Add(Me.AbcdbcLabel5)
        Me.Controls.Add(Me.AbcdbcLabel3)
        Me.Controls.Add(Me.lbl_Itm1)
        Me.Controls.Add(Me.pnl_Return)
        Me.Controls.Add(Me.pnl_Shipment)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_SHIPFG004"
        Me.Text = "frm_SHIPFG004"
        Me.Controls.SetChildIndex(Me.pnl_Shipment, 0)
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
        Me.Controls.SetChildIndex(Me.lbl_WH, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Shipment As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Return As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_Itm1 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents AbcdbcLabel3 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents AbcdbcLabel5 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_Itm2 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_Itm3 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_ITEMNM As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_ITEMCD As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_BCNO As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_WH As jp.co.ait.common.forms.ABCDBCLabel
End Class
