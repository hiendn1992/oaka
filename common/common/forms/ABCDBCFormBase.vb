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
Namespace jp.co.ait.common.forms

    ''' <summary>
    ''' 共通ﾌｫｰﾑ基盤ｸﾗｽ
    ''' </summary>
    Public Class ABCDBCFormBase

#Region "ログ関連"

        ''' <summary>
        ''' ﾛｸﾞの走行ﾚﾍﾞﾙがDebug以下であるか判定します。
        ''' </summary>
        ''' <returns>ﾛｸﾞの走行ﾚﾍﾞﾙが低い(ture) or ﾛｸﾞの走行ﾚﾍﾞﾙが高い(false)</returns>
        Protected Shared Function IsDebug() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelDebug)
        End Function


        ''' <summary>
        ''' ﾛｸﾞの走行ﾚﾍﾞﾙがTrace以下であるか判定します。
        ''' </summary>
        ''' <returns>ﾛｸﾞの走行ﾚﾍﾞﾙが低い(ture) or ﾛｸﾞの走行ﾚﾍﾞﾙが高い(false)</returns>
        Protected Shared Function IsTrace() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelTrace)
        End Function


        ''' <summary>
        ''' ﾛｸﾞの走行ﾚﾍﾞﾙがDump以下であるか判定します。
        ''' </summary>
        ''' <returns>ﾛｸﾞの走行ﾚﾍﾞﾙが低い(ture) or ﾛｸﾞの走行ﾚﾍﾞﾙが高い(false)</returns>
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
        ''' 終了ﾛｸﾞを出力します。
        ''' </summary>
        Protected Shared Sub WriteEndLog()
            WriteLog(ABCDBCLog.LogLevel.LevelOperation, "終了")
        End Sub


        ''' <summary>
        ''' ﾃﾞﾊﾞｯｸﾞﾛｸﾞを出力します。
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
        ''' ﾜｰﾆﾝｸﾞﾛｸﾞを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Sub WriteWarning(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelWarning, str)
        End Sub


        ''' <summary>
        ''' ｴﾗｰﾛｸﾞを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Shared Sub WriteErrorLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelError, str)
        End Sub


        ''' <summary>
        ''' ｴﾗｰﾛｸﾞを出力します。
        ''' </summary>
        ''' <param name="ex">ｴﾗｰ情報</param>
        Protected Shared Sub WriteErrorLog(ByVal ex As Exception)
            WriteLog(ABCDBCLog.LogLevel.LevelError, ex.ToString)
        End Sub


        ''' <summary>
        ''' ﾛｸﾞ出力情報設定
        ''' </summary>
        ''' <param name="level">ﾛｸﾞﾚﾍﾞﾙ</param>
        ''' <param name="msg">出力文字列</param>
        Private Shared Sub WriteLog(ByVal level As ABCDBCLog.LogLevel, ByVal msg As String)
            If ABCDBCLog.IsLoglevel(level) = False Then
                Return
            End If

            Dim userId As String
            If IsLogin() = False Then
                userId = "-----"
            Else
                userId = GetLoginInfo.UserID
            End If

            ABCDBCLog.WriteLog(level, userId, "", "", "", msg)
        End Sub

#End Region

#Region "汎用関数"

        ''' <summary>
        ''' ﾛｸﾞｲﾝの有無を確認します。
        ''' </summary>
        ''' <returns>True:ﾛｸﾞｲﾝ中　False:非ﾛｸﾞｲﾝ</returns>
        Private Shared Function IsLogin() As Boolean
            Return ABCDBCLoginManager.IsLogin()
        End Function

        ''' <summary>
        ''' ﾛｸﾞｲﾝ情報を取得します。
        ''' </summary>
        ''' <returns>ﾛｸﾞｲﾝ情報。ただし、非ﾛｸﾞｲﾝ時はNothingを返します。</returns>
        Private Shared Function GetLoginInfo() As ABCDBCLoginInfo
            Return ABCDBCLoginManager.GetLoginInfo()
        End Function

#End Region

    End Class
End Namespace