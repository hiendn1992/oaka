''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSG001.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   01-JAN-15    1.00     CuongTK   New
''*********************************************************

Public Class frm_MSG001

#Region "Variable/Constant Form"

#End Region

#Region "New Form"

    ''' <summary>
    ''' New form with no param.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        '// This call is required by the Windows Form Designer.
        InitializeComponent()
        '// Add any initialization after the InitializeComponent() call.
        '// TODO
    End Sub

    ''' <summary>
    ''' New form with param
    ''' </summary>
    ''' <param name="_content"></param>
    ''' <param name="_title"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _content As String, _
                   ByVal _title As String)
        '// This call is required by the Windows Form Designer.
        InitializeComponent()
        '// Add any initialization after the InitializeComponent() call.
        Dim subString As String = Nothing
        subString = _title.Substring(0, 3) '' Cut to get 3 characters.
        '// Set title, content for screen.
        Me.Text = _title
        lb_message.Text = _content
        Select Case subString
            Case "ERR"
                btn_agree.Visible = False
                btn_disagree.Text = "OK"
                btn_disagree.DialogResult = Windows.Forms.DialogResult.OK
            Case "MSG"
                btn_agree.Text = "Yes"
                btn_disagree.Text = "No"
                btn_agree.DialogResult = Windows.Forms.DialogResult.Yes
                btn_disagree.DialogResult = Windows.Forms.DialogResult.No
            Case "INF"
                btn_agree.Visible = False
                btn_disagree.Text = "OK"
                btn_disagree.DialogResult = Windows.Forms.DialogResult.OK
            Case "OMS"
                btn_agree.Visible = False
                btn_disagree.Text = "OK"
                btn_disagree.DialogResult = Windows.Forms.DialogResult.OK
            Case "OER"
                btn_agree.Visible = False
                btn_disagree.Text = "OK"
                btn_disagree.DialogResult = Windows.Forms.DialogResult.OK
        End Select
    End Sub

#End Region

#Region "Event Form"
    
#End Region

#Region "Function Form"

#End Region

    Private Sub btn_agree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agree.Click

    End Sub
End Class