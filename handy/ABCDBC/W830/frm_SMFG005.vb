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

Public Class frm_SMFG005

#Region " VARIABLE / CONSTANT "
    Private message As String = ""
    Private rackCd As String = ""
    Private smfg003 As frm_SMFG003
#End Region

#Region " CONSTRUCTOR "

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
    Public Sub New(ByVal message As String, ByVal RackCd As String)
        ' init
        InitializeComponent()
        '' set params
        Me.message = message
        Me.rackCd = RackCd
        Me.lbl_msg.TextAlign = ContentAlignment.TopCenter
    End Sub

#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_SMFG005_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    ''' <summary>
    ''' pnl_Action_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_action.Click
        smfg003 = New frm_SMFG003(rackCd)
        smfg003.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' frm_ImportW902_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG005_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Free memmory
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' frm_ImportW902_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG005_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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