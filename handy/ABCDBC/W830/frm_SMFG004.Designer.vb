<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SMFG004
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
        Me.btn_imp = New jp.co.ait.common.forms.ABCDBCPanel
        Me.btn_cancel = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_BCNO = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_ITEMCD = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_ITEMNM = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_Itm3 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_Itm2 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_Itm1 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_warehouseCd = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Stock Move "
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'btn_imp
        '
        Me.btn_imp.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_imp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_imp.BorderWidth = 2
        Me.btn_imp.ClickEnabled = True
        Me.btn_imp.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.btn_imp.FontColor = System.Drawing.Color.White
        Me.btn_imp.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btn_imp.LabelText = "F1 :MOVE"
        Me.btn_imp.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_imp.Location = New System.Drawing.Point(10, 270)
        Me.btn_imp.Name = "btn_imp"
        Me.btn_imp.PnlLocked = False
        Me.btn_imp.Size = New System.Drawing.Size(105, 40)
        Me.btn_imp.SplitChar = "\n"
        '
        'btn_cancel
        '
        Me.btn_cancel.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.btn_cancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btn_cancel.BorderWidth = 2
        Me.btn_cancel.ClickEnabled = True
        Me.btn_cancel.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.btn_cancel.FontColor = System.Drawing.Color.White
        Me.btn_cancel.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btn_cancel.LabelText = "F2 :CANCEL"
        Me.btn_cancel.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_cancel.Location = New System.Drawing.Point(125, 270)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.PnlLocked = False
        Me.btn_cancel.Size = New System.Drawing.Size(105, 40)
        Me.btn_cancel.SplitChar = "\n"
        '
        'lbl_BCNO
        '
        Me.lbl_BCNO.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_BCNO.Location = New System.Drawing.Point(10, 104)
        Me.lbl_BCNO.Name = "lbl_BCNO"
        Me.lbl_BCNO.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_ITEMCD
        '
        Me.lbl_ITEMCD.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMCD.Location = New System.Drawing.Point(10, 164)
        Me.lbl_ITEMCD.Name = "lbl_ITEMCD"
        Me.lbl_ITEMCD.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_ITEMNM
        '
        Me.lbl_ITEMNM.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMNM.Location = New System.Drawing.Point(10, 224)
        Me.lbl_ITEMNM.Name = "lbl_ITEMNM"
        Me.lbl_ITEMNM.Size = New System.Drawing.Size(230, 24)
        '
        'lbl_Itm3
        '
        Me.lbl_Itm3.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm3.Location = New System.Drawing.Point(10, 194)
        Me.lbl_Itm3.Name = "lbl_Itm3"
        Me.lbl_Itm3.Size = New System.Drawing.Size(209, 24)
        Me.lbl_Itm3.Text = "Item Name :   "
        '
        'lbl_Itm2
        '
        Me.lbl_Itm2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm2.Location = New System.Drawing.Point(10, 134)
        Me.lbl_Itm2.Name = "lbl_Itm2"
        Me.lbl_Itm2.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm2.Text = "Item Code :"
        '
        'lbl_Itm1
        '
        Me.lbl_Itm1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm1.Location = New System.Drawing.Point(10, 74)
        Me.lbl_Itm1.Name = "lbl_Itm1"
        Me.lbl_Itm1.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm1.Text = "Barcode No:"
        '
        'lbl_warehouseCd
        '
        Me.lbl_warehouseCd.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_warehouseCd.ForeColor = System.Drawing.Color.Blue
        Me.lbl_warehouseCd.Location = New System.Drawing.Point(0, 40)
        Me.lbl_warehouseCd.Name = "lbl_warehouseCd"
        Me.lbl_warehouseCd.Size = New System.Drawing.Size(240, 24)
        '
        'frm_SMFG004
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
        Me.Controls.Add(Me.lbl_Itm1)
        Me.Controls.Add(Me.btn_imp)
        Me.Controls.Add(Me.btn_cancel)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_SMFG004"
        Me.Text = "frm_SMFG004"
        Me.Controls.SetChildIndex(Me.btn_cancel, 0)
        Me.Controls.SetChildIndex(Me.btn_imp, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm1, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm2, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm3, 0)
        Me.Controls.SetChildIndex(Me.lbl_ITEMNM, 0)
        Me.Controls.SetChildIndex(Me.lbl_ITEMCD, 0)
        Me.Controls.SetChildIndex(Me.lbl_BCNO, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_warehouseCd, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_imp As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents btn_cancel As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_BCNO As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_ITEMCD As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_ITEMNM As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_Itm3 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_Itm2 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_Itm1 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_warehouseCd As jp.co.ait.common.forms.ABCDBCLabel
End Class
