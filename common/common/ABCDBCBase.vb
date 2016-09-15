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

Imports System.Diagnostics

Namespace jp.co.ait.common

    ''' <summary>
    ''' BWS共通関数基底クラス
    ''' </summary>
    Public Class ABCDBCBase
        Private Shared _dir As String

#Region "ログ関連"


        ''' <summary>
        ''' ログの走行レベルがDebug以下であるか判定します。
        ''' </summary>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Protected Shared Function IsDebug() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelDebug)
        End Function


        ''' <summary>
        ''' ログの走行レベルがTrace以下であるか判定します。
        ''' </summary>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Protected Shared Function IsTrace() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelTrace)
        End Function


        ''' <summary>
        ''' ログの走行レベルがDump以下であるか判定します。
        ''' </summary>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Protected Shared Function IsDump() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelDump)
        End Function


        ''' <summary>
        ''' 開始ログを出力します。
        ''' </summary>
        Protected Shared Sub WriteStartLog()
            WriteLog(ABCDBCLog.LogLevel.LevelOperation, "開始")
        End Sub


        ''' <summary>
        ''' 終了ログを出力します。
        ''' </summary>
        Protected Shared Sub WriteEndLog()
            WriteLog(ABCDBCLog.LogLevel.LevelOperation, "終了")
        End Sub


        ''' <summary>
        ''' デバッグログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Shared Sub WriteDebugLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelDebug, str)
        End Sub


        ''' <summary>
        ''' トレースログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Shared Sub WriteTraceLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelTrace, str)
        End Sub


        ''' <summary>
        ''' ワーニングログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Sub WriteWarning(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelWarning, str)
        End Sub


        ''' <summary>
        ''' エラーログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Shared Sub WriteErrorLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelError, str)
        End Sub


        ''' <summary>
        ''' エラーログを出力します。
        ''' </summary>
        ''' <param name="ex">エラー情報</param>
        Protected Shared Sub WriteErrorLog(ByVal ex As Exception)
            WriteLog(ABCDBCLog.LogLevel.LevelError, ex.ToString)
        End Sub


        ''' <summary>
        ''' ログ出力情報設定
        ''' </summary>
        ''' <param name="level">ログレベル</param>
        ''' <param name="msg">出力文字列</param>
        Private Shared Sub WriteLog(ByVal level As ABCDBCLog.LogLevel, ByVal msg As String)
            If ABCDBCLog.IsLoglevel(level) = False Then
                Return
            End If

            Dim UserId As String
            If IsLogin() = False Then
                UserId = "-----"
            Else
                UserId = GetLoginInfo.UserID
            End If

            'Try
            '    Throw New ApplicationException("aa")
            'Catch ex As Exception
            '    ex.StackTrace
            '    ex.s()
            'End Try
            'Dim proc As StackFrame
            'Dim history As New StackTrace(True)
            'proc = history.GetFrame(2)
            'ABCDBCLog.WriteLog(level, UserId, proc.GetMethod.ReflectedType.Name, New StackFrame(2).GetMethod.Name, "", msg)
            ABCDBCLog.WriteLog(level, UserId, "", "", "", msg)
        End Sub

#End Region


#Region "汎用関数"


        '''' <summary>
        '''' カレントフォルダパス取得
        '''' </summary>
        '''' <returns>カレントフォルダパス</returns>
        'Protected Shared Function GetCurrentDir() As String
        '    If _dir Is Nothing Then
        '        _dir = My.Computer.FileSystem.CurrentDirectory & "\"
        '    End If
        '    Return _dir
        'End Function


        ''' <summary>
        ''' ログインの有無を確認します。
        ''' </summary>
        ''' <returns>True:ログイン中　False:非ログイン</returns>
        Private Shared Function IsLogin() As Boolean
            Return ABCDBCLoginManager.IsLogin()
        End Function

        ''' <summary>
        ''' ログイン情報を取得します。
        ''' </summary>
        ''' <returns>ログイン情報。ただし、非ログイン時はNothingを返します。</returns>
        Private Shared Function GetLoginInfo() As ABCDBCLoginInfo
            Return ABCDBCLoginManager.GetLoginInfo()
        End Function

        ''' <summary>
        ''' メッセージの取得
        ''' </summary>
        ''' <param name="msgID">メッセージID</param>
        ''' <param name="param">置き換える内容配列</param>
        ''' <returns>メッセージ内容</returns>
        Private Shared Function GetMessage(ByVal msgID As String, Optional ByVal param() As String = Nothing) As String
            Return ABCDBCMessage.GetMessage(msgID, param)
        End Function

        ''' <summary>
        ''' メッセージフォームを表示
        ''' </summary>
        ''' <param name="msgID">メッセージID</param>
        ''' <param name="warnningFlag">置き換える内容配列</param>
        ''' <param name="param">置き換える内容配列</param>
        ''' <remarks></remarks>
        Protected Shared Sub ShowMessageForm(ByVal msgID As String, _
                                      ByVal formTitle As String, _
                                      Optional ByVal warnningFlag As Integer = 0, _
                                      Optional ByVal param() As String = Nothing)
            Dim strMsg As String
            Dim listMsg As New ArrayList

            strMsg = GetMessage(msgID, param)
            listMsg.Add(formTitle)
            listMsg.Add(strMsg)
            listMsg.Add(warnningFlag)

            Dim frmLWHBC000F As New frm_LWHBC000F(listMsg)

            frmLWHBC000F.ShowDialog()

            listMsg = Nothing
            frmLWHBC000F = Nothing

        End Sub

        ''' <summary>
        ''' システムエラーをエラーフォームに表示する
        ''' </summary>
        Protected Shared Sub ShowSystemMessageForm()
            ShowMessageForm("BC902", "システムエラー")
        End Sub

#End Region

    End Class
End Namespace
