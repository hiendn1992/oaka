''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* システム名：ABCD_Barcode_System
''* クラス名  ：ABCDWebService
''* 処理概要  ：BC端末の要求より、業務を行う
''*********************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1 14/12/12 1.00  AIT)cuongnc     New
#End Region
''*********************************************************
Imports System.Diagnostics
Imports System.Xml

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' BWS共通関数基底クラス
    ''' </summary>
    Public Class ABCDWebBase

        Private _userId As String

#Region "ログ関連"

        ''' <summary>
        ''' ログの走行レベルがDebug以下であるか判定します。
        ''' </summary>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Protected Function IsDebug() As Boolean
            Dim log As New ABCDWebLog
            Return log.IsLoglevel(ABCDWebLog.LogLevel.LevelDebug)
        End Function

        ''' <summary>
        ''' ログの走行レベルがTrace以下であるか判定します。
        ''' </summary>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Protected Function IsTrace() As Boolean
            Dim log As New ABCDWebLog
            Return log.IsLoglevel(ABCDWebLog.LogLevel.LevelTrace)
        End Function

        ''' <summary>
        ''' ログの走行レベルがDump以下であるか判定します。
        ''' </summary>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Protected Function IsDump() As Boolean
            Dim log As New ABCDWebLog
            Return log.IsLoglevel(ABCDWebLog.LogLevel.LevelDump)
        End Function

        ''' <summary>
        ''' 開始ログを出力します。
        ''' </summary>
        Protected Sub WriteStartLog()
            WriteLog(ABCDWebLog.LogLevel.LevelOperation, "開始")
        End Sub

        ''' <summary>
        ''' 終了ログを出力します。
        ''' </summary>
        Protected Sub WriteEndLog()
            WriteLog(ABCDWebLog.LogLevel.LevelOperation, "終了")
        End Sub

        ''' <summary>
        ''' デバッグログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Sub WriteDebugLog(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelDebug, str)
        End Sub

        ''' <summary>
        ''' トレースログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Sub WriteTraceLog(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelTrace, str)
        End Sub

        ''' <summary>
        ''' ワーニングログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Sub WriteWarning(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelWarning, str)
        End Sub

        ''' <summary>
        ''' エラーログを出力します。
        ''' </summary>
        ''' <param name="str">出力文字列</param>
        Protected Sub WriteErrorLog(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelError, str)
        End Sub

        ''' <summary>
        ''' エラーログを出力します。
        ''' </summary>
        ''' <param name="ex">エラー情報</param>
        Protected Sub WriteErrorLog(ByVal ex As Exception)
            WriteLog(ABCDWebLog.LogLevel.LevelError, ex.ToString)
        End Sub

        ''' <summary>
        ''' ログ出力情報設定
        ''' </summary>
        ''' <param name="level">ログレベル</param>
        ''' <param name="msg">出力文字列</param>
        Private Sub WriteLog(ByVal level As ABCDWebLog.LogLevel, _
                                    ByVal msg As String)
            Dim log As New ABCDWebLog
            If log.IsLoglevel(level) = False Then
                Return
            End If

            Dim userId As String
            If IsLogin() = False Then
                userId = "-----"
            Else
                userId = Me._userId
            End If

            Dim proc As StackFrame
            Dim history As New StackTrace(True)
            proc = history.GetFrame(2)

            log.WriteLog(level, userId, proc.GetMethod.ReflectedType.Name, New StackFrame(2).GetMethod.Name, "", msg)

        End Sub

#End Region

#Region "汎用関数"

        ''' <summary>
        ''' XMLﾌｧｲﾙﾊﾟｽ取得
        ''' </summary>
        ''' <returns>カレントフォルダパス</returns>
        Protected Function GetXMLDir() As String
            '_dir = My.Computer.FileSystem.CurrentDirectory & "\"
            Return System.Configuration.ConfigurationManager.AppSettings("XML_FILE_DIR") & "\"
        End Function

        ''' <summary>
        ''' ログインの有無を確認します。
        ''' </summary>
        ''' <returns>True:ログイン中　False:非ログイン</returns>
        Private Function IsLogin() As Boolean
            If String.IsNullOrEmpty(Me._userId) Then
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' ﾛｸﾞﾌｧｲﾙﾊﾟｽを取得します
        ''' </summary>
        Protected Function GetLogFileDir() As String
            Dim logFileDir As String = GetFileData("LOG/FILE_DIR")
            ' FILE_PATHが取得できない場合
            If logFileDir Is Nothing OrElse logFileDir Is String.Empty Then
                Throw New ApplicationException("ログファイルのパス定義が不正です。ログファイルのパス=Nothing")
            End If

            Return logFileDir

        End Function

        ''' <summary>
        ''' ﾛｸﾞﾌｧｲﾙ名を取得します
        ''' </summary>
        Protected Function GetLogFileName() As String
            Dim logFileName As String = GetFileData("LOG/FILE_NAME")
            ' FILE_NAMEが取得できない場合
            If logFileName Is Nothing OrElse logFileName Is String.Empty Then
                Throw New ApplicationException("ログファイル名が取得できませんでした。ログファイル名=Nothing")
            End If
            Return logFileName
        End Function

        ''' <summary>
        ''' 構成ファイルより情報取得
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <returns>取得情報</returns>
        Private Function GetFileData(ByVal xPath As String) As String
            Try


                'Dim xmlDoc As New XmlDocument
                'Dim dir As String = System.Configuration.ConfigurationManager.AppSettings("XML_FILE_DIR") & "\" & BSWWebConst.APP_CONFIG_FILE
                'xmlDoc.Load(dir)

                'Dim xmlNodeList As XmlNodeList = xmlDoc.SelectNodes("descendant::" & xPath)
                'Dim count As Integer = xmlNodeList.Count
                'If count = 0 Then
                '    Return String.Empty
                'End If

                'Return xmlNodeList(0).InnerText

                Dim xmlManager As New ABCDWebXmlManager

                Return xmlManager.ReadString(xPath)

                xmlManager = Nothing

            Catch ex As Exception
                Return String.Empty
            End Try

        End Function

        ''' <summary>
        ''' ﾕｰｻﾞIDの設定と取得
        ''' </summary>
        ''' <value>ﾕｰｻﾞIDの設定値</value>
        ''' <returns>ﾕｰｻﾞIDの戻り値</returns>
        Protected Property UserId() As String
            Get
                Return Me._userId
            End Get
            Set(ByVal value As String)
                Me._userId = value
            End Set
        End Property

#End Region

    End Class
End Namespace
