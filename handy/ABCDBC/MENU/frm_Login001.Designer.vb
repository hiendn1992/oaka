<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Login001
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
        Me.txt_USERNM = New jp.co.ait.common.forms.ABCDBCTextBox
        Me.txt_PASSWD = New jp.co.ait.common.forms.ABCDBCTextBox
        Me.pnl_Ok = New jp.co.ait.common.forms.ABCDBCPanel
        Me.pnl_Cancel = New jp.co.ait.common.forms.ABCDBCPanel
        Me.lbl_PASSWD = New jp.co.ait.common.forms.ABCDBCLabel
        Me.lbl_USERNM = New jp.co.ait.common.forms.ABCDBCLabel
        Me.SuspendLayout()
        '
        'pnl_TITLE
        '
        Me.pnl_TITLE.LabelText = "Login"
        Me.pnl_TITLE.LableFont = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        '
        'txt_USERNM
        '
        Me.txt_USERNM.Font = New System.Drawing.Font("MS Gothic", 20.0!, System.Drawing.FontStyle.Regular)
        Me.txt_USERNM.Location = New System.Drawing.Point(25, 90)
        Me.txt_USERNM.Name = "txt_USERNM"
        Me.txt_USERNM.Size = New System.Drawing.Size(180, 33)
        Me.txt_USERNM.TabIndex = 10
        Me.txt_USERNM.Tag = ""
        '
        'txt_PASSWD
        '
        Me.txt_PASSWD.Font = New System.Drawing.Font("MS Gothic", 20.0!, System.Drawing.FontStyle.Regular)
        Me.txt_PASSWD.Location = New System.Drawing.Point(27, 170)
        Me.txt_PASSWD.Name = "txt_PASSWD"
        Me.txt_PASSWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_PASSWD.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txt_PASSWD.Size = New System.Drawing.Size(180, 33)
        Me.txt_PASSWD.TabIndex = 20
        '
        'pnl_Ok
        '
        Me.pnl_Ok.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Ok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Ok.BorderWidth = 1
        Me.pnl_Ok.ClickEnabled = True
        Me.pnl_Ok.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Ok.FontColor = System.Drawing.Color.White
        Me.pnl_Ok.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Ok.LabelText = "F1 : OK"
        Me.pnl_Ok.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Ok.Location = New System.Drawing.Point(10, 270)
        Me.pnl_Ok.Name = "pnl_Ok"
        Me.pnl_Ok.PnlLocked = False
        Me.pnl_Ok.Size = New System.Drawing.Size(105, 40)
        Me.pnl_Ok.SplitChar = "\n"
        '
        'pnl_Cancel
        '
        Me.pnl_Cancel.BorderColor = System.Drawing.SystemColors.WindowFrame
        Me.pnl_Cancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_Cancel.BorderWidth = 1
        Me.pnl_Cancel.ClickEnabled = True
        Me.pnl_Cancel.ColorLevel = jp.co.ait.common.ABCDBCConst.userColorLevel.LEVEL5
        Me.pnl_Cancel.FontColor = System.Drawing.Color.White
        Me.pnl_Cancel.LabelAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.pnl_Cancel.LabelText = "F2 :CANCEL"
        Me.pnl_Cancel.LableFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pnl_Cancel.Location = New System.Drawing.Point(125, 270)
        Me.pnl_Cancel.Name = "pnl_Cancel"
        Me.pnl_Cancel.PnlLocked = False
        Me.pnl_Cancel.Size = New System.Drawing.Size(105, 40)
        Me.pnl_Cancel.SplitChar = "\n"
        '
        'lbl_PASSWD
        '
        Me.lbl_PASSWD.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_PASSWD.Location = New System.Drawing.Point(27, 130)
        Me.lbl_PASSWD.Name = "lbl_PASSWD"
        Me.lbl_PASSWD.Size = New System.Drawing.Size(180, 37)
        Me.lbl_PASSWD.Text = "Password:"
        '
        'lbl_USERNM
        '
        Me.lbl_USERNM.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_USERNM.Location = New System.Drawing.Point(27, 50)
        Me.lbl_USERNM.Name = "lbl_USERNM"
        Me.lbl_USERNM.Size = New System.Drawing.Size(180, 40)
        Me.lbl_USERNM.Text = "User ID:"
        '
        'frm_Login001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.lbl_PASSWD)
        Me.Controls.Add(Me.lbl_USERNM)
        Me.Controls.Add(Me.pnl_Cancel)
        Me.Controls.Add(Me.txt_USERNM)
        Me.Controls.Add(Me.pnl_Ok)
        Me.Controls.Add(Me.txt_PASSWD)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_Login001"
        Me.Text = "Login"
        Me.Controls.SetChildIndex(Me.txt_PASSWD, 0)
        Me.Controls.SetChildIndex(Me.pnl_Ok, 0)
        Me.Controls.SetChildIndex(Me.txt_USERNM, 0)
        Me.Controls.SetChildIndex(Me.pnl_Cancel, 0)
        Me.Controls.SetChildIndex(Me.lbl_USERNM, 0)
        Me.Controls.SetChildIndex(Me.lbl_PASSWD, 0)
        Me.Controls.SetChildIndex(Me.pnl_TITLE, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_USERNM As jp.co.ait.common.forms.ABCDBCTextBox
    Friend WithEvents txt_PASSWD As jp.co.ait.common.forms.ABCDBCTextBox
    Friend WithEvents pnl_Ok As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents pnl_Cancel As jp.co.ait.common.forms.ABCDBCPanel
    Friend WithEvents lbl_PASSWD As jp.co.ait.common.forms.ABCDBCLabel
    Friend WithEvents lbl_USERNM As jp.co.ait.common.forms.ABCDBCLabel
End Class
