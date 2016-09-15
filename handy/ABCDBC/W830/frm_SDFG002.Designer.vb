<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SDFG002
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
        Me.lbl_RackNo1 = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_RackNo = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Stock Delete W830"
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
        Me.btn_imp.LabelText = "F1 :DELETE"
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
        Me.lbl_BCNO.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_BCNO.Location = New System.Drawing.Point(10, 65)
        Me.lbl_BCNO.Name = "lbl_BCNO"
        Me.lbl_BCNO.Size = New System.Drawing.Size(230, 25)
        Me.lbl_BCNO.Text = "lbl_BCNO"
        '
        'lbl_ITEMCD
        '
        Me.lbl_ITEMCD.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMCD.Location = New System.Drawing.Point(10, 165)
        Me.lbl_ITEMCD.Name = "lbl_ITEMCD"
        Me.lbl_ITEMCD.Size = New System.Drawing.Size(230, 24)
        Me.lbl_ITEMCD.Text = "lbl_ITEMCD"
        '
        'lbl_ITEMNM
        '
        Me.lbl_ITEMNM.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_ITEMNM.Location = New System.Drawing.Point(10, 215)
        Me.lbl_ITEMNM.Name = "lbl_ITEMNM"
        Me.lbl_ITEMNM.Size = New System.Drawing.Size(230, 24)
        Me.lbl_ITEMNM.Text = "lbl_ITEMNM"
        '
        'lbl_Itm3
        '
        Me.lbl_Itm3.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm3.Location = New System.Drawing.Point(10, 190)
        Me.lbl_Itm3.Name = "lbl_Itm3"
        Me.lbl_Itm3.Size = New System.Drawing.Size(149, 24)
        Me.lbl_Itm3.Text = "Item Name:   "
        '
        'lbl_Itm2
        '
        Me.lbl_Itm2.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm2.Location = New System.Drawing.Point(10, 140)
        Me.lbl_Itm2.Name = "lbl_Itm2"
        Me.lbl_Itm2.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itm2.Text = "Item Code :"
        '
        'lbl_Itm1
        '
        Me.lbl_Itm1.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Itm1.Location = New System.Drawing.Point(10, 40)
        Me.lbl_Itm1.Name = "lbl_Itm1"
        Me.lbl_Itm1.Size = New System.Drawing.Size(230, 25)
        Me.lbl_Itm1.Text = "Barcode No:"
        '
        'lbl_RackNo1
        '
        Me.lbl_RackNo1.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_RackNo1.Location = New System.Drawing.Point(10, 115)
        Me.lbl_RackNo1.Name = "lbl_RackNo1"
        Me.lbl_RackNo1.Size = New System.Drawing.Size(230, 24)
        Me.lbl_RackNo1.Text = "lbl_RackNo"
        '
        'lbl_RackNo
        '
        Me.lbl_RackNo.Font = New System.Drawing.Font("Tahoma", 17.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_RackNo.Location = New System.Drawing.Point(10, 90)
        Me.lbl_RackNo.Name = "lbl_RackNo"
        Me.lbl_RackNo.Size = New System.Drawing.Size(230, 24)
        Me.lbl_RackNo.Text = "Rack No:"
        '
        'frm_SDFG002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.lbl_RackNo1)
        Me.Controls.Add(Me.lbl_RackNo)
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
        Me.Name = "frm_SDFG002"
        Me.Text = "frm_SDFG002"
        Me.Controls.SetChildIndex(Me.btn_cancel, 0)
        Me.Controls.SetChildIndex(Me.btn_imp, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm1, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm2, 0)
        Me.Controls.SetChildIndex(Me.lbl_Itm3, 0)
        Me.Controls.SetChildIndex(Me.lbl_ITEMNM, 0)
        Me.Controls.SetChildIndex(Me.lbl_ITEMCD, 0)
        Me.Controls.SetChildIndex(Me.lbl_BCNO, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.Controls.SetChildIndex(Me.lbl_RackNo, 0)
        Me.Controls.SetChildIndex(Me.lbl_RackNo1, 0)
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
    Friend WithEvents lbl_RackNo1 As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_RackNo As jp.co.ait.common.forms.ABCDBCLabel
End Class
