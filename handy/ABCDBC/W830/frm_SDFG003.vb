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

Public Class frm_SDFG003

#Region " VARIABLE / CONSTANT "
    Private message As String = ""
    Private sdfg001 As frm_SDFG001
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
    Public Sub New(ByVal message As String)
        ' init
        InitializeComponent()
        '' set params
        Me.message = message
        Me.lbl_msg.TextAlign = ContentAlignment.TopCenter
    End Sub

#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_SDFG003_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SDFG003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    ''' <summary>
    ''' pnl_Action_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_action.Click
        sdfg001 = New frm_SDFG001()
        sdfg001.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' frm_SDFG003_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SDFG003_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Free memmory
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' frm_SDFG003_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SDFG003_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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