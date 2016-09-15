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
Imports System.Windows.Forms
Imports System.Drawing

Namespace jp.co.ait.common.forms

    ''' <summary>
    ''' 共通ﾌｫｰﾑ基盤ｸﾗｽ
    ''' </summary>
    Public Class ABCDBCForm

#Region " ﾕｰｻﾞ変数定義 "

        ''' <summary>
        ''' ﾌｫｰﾑﾓｰﾄﾞ
        ''' </summary>
        Enum ScreenMode

            ''' <summary>指定なし</summary>
            None

            ''' <summary>払出</summary>
            Haraidashi

            ''' <summary>在庫</summary>
            Zaiko

            ''' <summary>受入</summary>
            Ukeire

        End Enum

        ''' <summary>遷移元画面ID</summary>
        Private _motoScreenID As String

        ''' <summary>ﾌｫｰﾑID</summary>
        Private _screenID As String = String.Empty

        ''' <summary>ﾌｫｰﾑ名称</summary>
        Private _screenName As String = String.Empty

        ''' <summary>ﾌｫｰﾑﾓｰﾄﾞなし</summary>
        Private _mode As ScreenMode = ScreenMode.None

        ''' <summary>画面用ﾊﾟﾗﾒｰﾀ引数</summary>
        Private _param As DataSet

#End Region

#Region " ﾕｰｻﾞｲﾍﾞﾝﾄ定義 "

        ''' <summary>
        ''' ﾕｰｻﾞｲﾍﾞﾝﾄ定義
        ''' </summary>
        Public Event TitleClick As EventHandler

#End Region

#Region " ﾌﾟﾛﾊﾟﾃｨ "

        ''' <summary>
        ''' ﾌｫｰﾑ名称の設定と取得
        ''' </summary>
        ''' <value>ﾌｫｰﾑ名称の設定値</value>
        ''' <returns>ﾌｫｰﾑ名称の戻り値</returns>
        Public Property ScreenName() As String
            Get
                Return Me._screenName
            End Get
            Set(ByVal value As String)
                Me._screenName = value
                Me.SetTitleName(value)
            End Set
        End Property

        ''' <summary>
        ''' ﾌｫｰﾑIDの設定と取得
        ''' </summary>
        ''' <value>ﾌｫｰﾑIDの設定値</value>
        ''' <returns>ﾌｫｰﾑIDの戻り値</returns>
        Public Property ScreenID() As String
            Get
                Return Me._screenID
            End Get
            Set(ByVal value As String)
                Me._screenID = value
            End Set
        End Property

        ''' <summary>
        ''' ﾌｫｰﾑﾓｰﾄﾞの設定と取得
        ''' </summary>
        ''' <value>ﾌｫｰﾑﾓｰﾄﾞの設定値</value>
        ''' <returns>ﾌｫｰﾑﾓｰﾄﾞの戻り値</returns>
        Public Property Mode() As ScreenMode
            Get
                Return Me._mode
            End Get
            Set(ByVal value As ScreenMode)
                Me._mode = value
            End Set
        End Property

        ''' <summary>
        ''' 遷移元ﾌｫｰﾑIDの設定と取得
        ''' </summary>
        ''' <value>遷移元ﾌｫｰﾑIDの設定値</value>
        ''' <returns>遷移元ﾌｫｰﾑIDの戻り値</returns>
        Public Property MotoScreenID() As String
            Get
                Return Me._motoScreenID
            End Get
            Set(ByVal value As String)
                Me._motoScreenID = value
            End Set
        End Property

        ''' <summary>
        ''' 画面用ﾊﾟﾗﾒｰﾀ引数の設定と取得
        ''' </summary>
        ''' <value>画面用ﾊﾟﾗﾒｰﾀ引数の設定値</value>
        ''' <returns>画面用ﾊﾟﾗﾒｰﾀ引数の戻り値</returns>
        Public Property Param() As DataSet
            Get
                Return Me._param
            End Get
            Set(ByVal value As DataSet)
                Me._param = value
            End Set
        End Property

#End Region

#Region " ﾕｰｻﾞ定義関数 "

        ''' <summary>
        ''' ﾀｲﾄﾙﾊﾟﾈﾙにﾌｫｰﾑ名称を設定
        ''' </summary>
        ''' <param name="strTitleName">ﾌｫｰﾑ名称</param>
        Private Sub SetTitleName(ByVal strTitleName As String)
            Me.pnl_TITLE.LabelText = strTitleName
        End Sub

        ''' <summary>
        ''' ﾒｯｾｰｼﾞの取得
        ''' </summary>
        ''' <param name="msgID">ﾒｯｾｰｼﾞID</param>
        ''' <param name="param">置き換える内容配列</param>
        ''' <returns>ﾒｯｾｰｼﾞ内容</returns>
        Protected Function GetMessage(ByVal msgID As String, Optional ByVal param() As String = Nothing) As String
            Return ABCDBCMessage.GetMessage(msgID, param)
        End Function

        ''' <summary>
        ''' ﾒｯｾｰｼﾞﾌｫｰﾑを表示
        ''' </summary>
        ''' <param name="msgID">ﾒｯｾｰｼﾞID</param>
        ''' <param name="formTitle">ﾌｫｰﾑ名称</param>
        ''' <param name="warnningFlag">置き換える内容配列</param>
        ''' <param name="param">置き換える内容配列</param>
        ''' <param name="buttonVisible">ボタン表示/非表示</param>
        Protected Sub ShowMessageForm(ByVal msgID As String, _
                                      ByVal formTitle As String, _
                                      Optional ByVal warnningFlag As Integer = 0, _
                                      Optional ByVal param() As String = Nothing, _
                                      Optional ByVal buttonVisible As Boolean = True)
            Dim strMsg As String
            Dim listMsg As New ArrayList

            strMsg = GetMessage(msgID, param)
            listMsg.Add(formTitle)
            listMsg.Add(strMsg)
            listMsg.Add(warnningFlag)
            listMsg.Add(buttonVisible)

            Dim frmLWHBC000F As New frm_LWHBC000F(listMsg)

            Application.DoEvents()
            frmLWHBC000F.ShowDialog()

            listMsg = Nothing
            frmLWHBC000F = Nothing

        End Sub

        ''' <summary>
        ''' ｼｽﾃﾑｴﾗｰをｴﾗｰﾌｫｰﾑに表示する
        ''' </summary>
        Protected Sub ShowSystemMessageForm()
            ShowMessageForm("BC902", "システムエラー")
        End Sub

        ''' <summary>
        ''' 画面ｺﾝﾄﾛｰﾙ使用可否の一括設定
        ''' </summary>
        Protected Sub SetControlEnabled(ByVal isEnabled As Boolean)

            Try
                If isEnabled Then Application.DoEvents()

                For Each pnl As Control In Me.Controls
                    If TypeOf pnl Is ABCDBCPanel Then
                        ' 使用可否を設定
                        DirectCast(pnl, ABCDBCPanel).ClickEnabled = isEnabled
                    End If

                    If TypeOf pnl Is ABCDBCTextBox Then
                        ' 使用可否を設定
                        pnl.Enabled = isEnabled
                    End If
                Next
            Catch ex As Exception

            End Try

        End Sub

        ''' <summary>
        ''' 画面ｺﾝﾄﾛｰﾙ使用可否の一括設定
        ''' </summary>
        Protected Sub SetControlEnabled(ByVal isEnabled As Boolean, ByVal ActiveControl As Control)

            Try
                SetControlEnabled(isEnabled)

                If isEnabled Then ActiveControl.Focus()

            Catch ex As Exception

            End Try

        End Sub

        ''' <summary>
        ''' 指定バイト数文字で返却
        ''' </summary>
        ''' <param name="expression">対象文字列</param>
        ''' <param name="cutLength">必要切り出し文字長さ</param>
        ''' <returns>不足分に半角ｽﾍﾟｰｽを増やす</returns>
        Private Function PadRightString(ByVal expression As String, _
                                              ByVal cutLength As Integer) As String

            Dim i As Integer
            Dim tmpByteCnt As Integer
            Dim length As Integer

            length = GetLenString(expression)
            If length < cutLength Then
                Return expression & Space(cutLength - length)
            Else
                ' 指定バイト数(以内)になる位置を探す
                i = 0
                tmpByteCnt = 0
                Do While (tmpByteCnt < cutLength)
                    i += 1
                    tmpByteCnt += GetLenString(Mid(expression, i, 1))
                Loop
                ' 1バイトオーバー時
                If tmpByteCnt > cutLength Then
                    i -= 1
                End If

                Return expression.Substring(0, i)
            End If

        End Function

        ''' <summary>
        ''' 文字列のバイト数計算
        ''' 与えられた文字列のバイト数を返す。
        ''' </summary>
        ''' <param name="expression">文字列</param>
        ''' <returns>文字列のバイト数</returns>
        Private Shared Function GetLenString(ByVal expression As String) As Integer
            ' Shift JISに変換したときに必要なバイト数を返す
            If IsDBNull(expression) Or IsNothing(expression) Then
                Return 0
            Else
                Return System.Text.Encoding.GetEncoding(932).GetByteCount(expression)
            End If
        End Function

        ''' <summary>
        ''' ｲﾍﾞﾝﾄの開始ﾛｸﾞ
        ''' </summary>
        ''' <param name="eventName">ｲﾍﾞﾝﾄ名称</param>
        ''' <param name="logLevel">ﾛｸﾞﾗﾍﾞﾙ</param>
        Protected Sub WriteEventStartLog(ByVal eventName As String, _
                                          Optional ByVal logLevel As ABCDBCLog.LogLevel = ABCDBCLog.LogLevel.LevelDebug)

            Try
                Dim msg As String = String.Empty

                msg &= PadRightString(ScreenID, 10) & ", "
                msg &= PadRightString(ScreenName, 24) & ", 開始, "
                msg &= eventName

                Select Case logLevel
                    Case ABCDBCLog.LogLevel.LevelDebug
                        ' ﾃﾞﾊﾞｯｸﾞ
                        WriteDebugLog(msg)
                    Case ABCDBCLog.LogLevel.LevelError
                        ' ｴﾗｰ
                        WriteErrorLog(msg)
                    Case ABCDBCLog.LogLevel.LevelTrace
                        ' ﾄﾚｰｽ
                        WriteTraceLog(msg)
                    Case Else
                        ' その他
                        WriteDebugLog(msg)
                End Select

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' ｲﾍﾞﾝﾄの終了ﾛｸﾞ
        ''' </summary>
        ''' <param name="eventName">ｲﾍﾞﾝﾄ名称</param>
        ''' <param name="logLevel">ﾛｸﾞﾗﾍﾞﾙ</param>
        Protected Sub WriteEventEndLog(ByVal eventName As String, _
                                          Optional ByVal logLevel As ABCDBCLog.LogLevel = ABCDBCLog.LogLevel.LevelDebug)

            Try
                Dim msg As String = String.Empty

                msg &= PadRightString(ScreenID, 10) & ", "
                msg &= PadRightString(ScreenName, 24) & ", 終了, "
                msg &= eventName

                Select Case logLevel
                    Case ABCDBCLog.LogLevel.LevelDebug
                        ' ﾃﾞﾊﾞｯｸﾞ
                        WriteDebugLog(msg)
                    Case ABCDBCLog.LogLevel.LevelError
                        ' ｴﾗｰ
                        WriteErrorLog(msg)
                    Case ABCDBCLog.LogLevel.LevelTrace
                        ' ﾄﾚｰｽ
                        WriteTraceLog(msg)
                    Case Else
                        ' その他
                        WriteDebugLog(msg)
                End Select

            Catch ex As Exception

            End Try
        End Sub

#End Region

#Region " ｺﾝｽﾄﾗｸﾀ "

        ''' <summary>
        ''' ｺﾝｽﾄﾗｸﾀ
        ''' </summary>
        Public Sub New()

            ' この呼び出しは、Windows ﾌｫｰﾑ ﾃﾞｻﾞｲﾅで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            AddHandler pnl_TITLE.Click, AddressOf pnlClick

            Me.Text = Me.ScreenName

        End Sub

        ''' <summary>
        ''' ｺﾝｽﾄﾗｸﾀ
        ''' </summary>
        ''' <param name="strFormName">ﾌｫｰﾑ名称</param>
        Public Sub New(ByVal strFormName As String)
            Me.New()

            ' ﾌｫｰﾑ名称の設定
            Me.ScreenName = strFormName
            Me.Text = Me.ScreenName
        End Sub

#End Region

#Region " ﾕｰｻﾞｲﾍﾞﾝﾄ "

        ''' <summary>
        ''' ﾌｫｰﾑﾀｲﾄﾙｸﾘｯｸｲﾍﾞﾝﾄの作成
        ''' </summary>
        ''' <param name="sender">ﾊﾟﾈﾙｺﾝﾄﾛｰﾙ</param>
        ''' <param name="e">ｲﾍﾞﾝﾄ情報</param>
        Public Sub pnlClick(ByVal sender As Object, ByVal e As System.EventArgs)
            RaiseEvent TitleClick(Me.pnl_TITLE, e)
        End Sub
#End Region

#Region "Barcode Call Back Instant "
        ''' <summary>
        ''' Barcode Call Back Instant
        ''' </summary>
        ''' <param name="HWnd">Microsoft.WindowsCE.Forms.Message HWnd</param>
        ''' <param name="LParam">Microsoft.WindowsCE.Forms.Message LParam</param>
        ''' <param name="Msg">Microsoft.WindowsCE.Forms.Message Msg</param>
        ''' <param name="Result">Microsoft.WindowsCE.Forms.Message Result</param>
        ''' <param name="WParam">Microsoft.WindowsCE.Forms.Message WParam</param>
        ''' <remarks></remarks>
        Public Overridable Sub RespondToMessage(ByRef HWnd As IntPtr, _
                                                ByRef LParam As IntPtr, _
                                                ByVal Msg As Integer, _
                                                ByVal Result As IntPtr, _
                                                ByVal WParam As IntPtr)
        End Sub
#End Region

    End Class

End Namespace
