Imports jp.co.ait.ABCDBC.common

''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* システム名：ABCDCommon
''* クラス名  ：
''* 処理概要  ：
''*********************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1 14/12/15 1.00  AIT)cuongnc     New
#End Region
''*********************************************************

Public Class frm_IMPFG003

#Region " VARIABLE / CONSTANT "
    Private message As String = ""
    Private frm_imp001 As frm_IMPFG001

    Private caseImp As String = String.Empty
#End Region

#Region " CONSTRUCTOR "

    Public Property GetCaseImp() As String
        Get
            Return caseImp
        End Get
        Set(ByVal value As String)
            caseImp = value
        End Set
    End Property

    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    Public Sub New()
        ' この呼び出しは、Windows ﾌｫｰﾑ ﾃﾞｻﾞｲﾅで必要です
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Constructor with params
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal message As String)
        ' init
        InitializeComponent()
        '' set params
        Me.message = message
        Me.lbl_msg.TextAlign = ContentAlignment.TopCenter
    End Sub

    Public Sub New(ByVal message As String, _
                   ByVal paramCaseImp As String)
        ' init
        InitializeComponent()
        '' set params
        Me.message = message
        Me.lbl_msg.Text = message
        Me.lbl_msg.TextAlign = ContentAlignment.TopCenter
        GetCaseImp = paramCaseImp
    End Sub

#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_ImportW902_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_ImportW902_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    ''' <summary>
    ''' pnl_Action_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_action.Click
        frm_imp001 = New frm_IMPFG001(GetCaseImp)
        frm_imp001.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' frm_ImportW902_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_ImportW902_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Free memmory
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' frm_ImportW902_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_ImportW902_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then

            pnl_Action_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: Fn

            ' close current form
            Me.Close()

            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

#End Region

End Class