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
Imports jp.co.ait.common
Imports System.Windows.Forms

Public Class frm_LWHBC000F

#Region " 変数/定数 "

    ''' <summary>エラー内容</summary>
    Private _errorMsg As String = String.Empty
    ''' <summary>ワーニングフラグ</summary>
    Private _warningFlag As Integer = 0
    ''' <summary>ボタン表示/非表示</summary>
    Private _buttonVisible As Boolean = True

    ''' <summary>タイトル定数（エラー）</summary>
    Private Const TITLE_NAME_ERR As String = "エラー"

#End Region

#Region " コンストラクタ "

    ''' <summary>
    ''' 初期化
    ''' </summary>
    Public Sub New()

        'この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        'InitializeComponent() 呼び出しの後で初期化を追加します。
    End Sub

    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="lstArray">メッセージ情報</param>
    Public Sub New(ByVal lstArray As ArrayList)
        Me.new()

        Try
            ' タイトル
            If lstArray.Count > 0 Then
                Me.ScreenName = lstArray(0).ToString
            End If

            ' エラー内容
            If lstArray.Count > 1 Then
                Me._errorMsg = lstArray(1).ToString.Replace("$", vbCrLf)
            End If

            ' ワーニングフラグ
            If lstArray.Count > 2 Then
                Me._warningFlag = CInt(lstArray(2))
            End If

            ' ボタン表示/非表示
            If lstArray.Count > 3 Then
                Me._buttonVisible = CBool(lstArray(3))
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
        Finally
            Debug.WriteLine("ｴﾗｰﾌｫｰﾑOK")
        End Try
    End Sub

#End Region

#Region " イベント "

    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender">コンポーネント</param>
    ''' <param name="e">イベント情報</param>
    Private Sub frm_LWHBC000F_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WriteEventStartLog("frm_LWHBC000F_Load")
        Try
            Cursor.Current = Cursors.Default

            ' エラー内容
            Me.lbl_MSG.Text = Me._errorMsg

            If Me._warningFlag = 0 Then
                ' エラー表示の場合、発生したエラー内容(赤字)を表示する
                Me.lbl_MSG.ForeColor = System.Drawing.Color.Red
            Else
                ' ワーニング表示の場合、ワーニング内容(青字)を表示する
                Me.lbl_MSG.ForeColor = System.Drawing.Color.Blue
            End If

            ' ボタン表示/非表示
            Me.pnl_OK.Visible = Me._buttonVisible

        Catch ex As Exception
            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
        End Try
        WriteEventEndLog("frm_LWHBC000F_Load")

    End Sub

    ''' <summary>
    ''' ＯＫ押下
    ''' </summary>
    ''' <param name="sender">コンポーネント</param>
    ''' <param name="e">イベント情報</param>
    Private Sub pnl_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnl_OK.Click

        WriteEventStartLog("OK(ﾎﾞﾀﾝ)押下")
        Try
            ' 当画面を閉じる。
            Me.Close()
            Me.Dispose()

        Catch ex As Exception

            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
        End Try
        WriteEventEndLog("OK(ﾎﾞﾀﾝ)押下")

    End Sub

    ''' <summary>
    ''' frm_LWHBC000F_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>vudh</remarks>
    Private Sub frm_LWHBC000F_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F2 Then
            pnl_OK_Click(sender, e)
        End If
    End Sub

#End Region

End Class
