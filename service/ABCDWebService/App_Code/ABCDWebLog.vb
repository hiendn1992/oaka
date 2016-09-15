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

Imports System.IO
Imports System.Text
Imports System.Xml

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' ログクラス
    ''' </summary>
    Public Class ABCDWebLog

#Region "ユーザ宣言"

        '''' <summary>定義ファイルで指定されているlogファイル名の冠</summary>
        'Private _logFileName As String
        '''' <summary>定義ファイルで指定されているlogファイルのパス</summary>
        'Private _logFileDir As String
        '''' <summary>定義ファイルで指定されているログレベル</summary>
        'Private _logLevel As LogLevel

#End Region

#Region "列挙列"

        ''' <summary>
        ''' ログレベル定義体
        ''' </summary>
        Public Enum LogLevel
            '''<summary>情報(ダンプ)</summary>
            LevelDump = 1
            '''<summary>情報(デバッグ)</summary>
            LevelDebug
            '''<summary>情報(件数)</summary>
            LevelInformation
            '''<summary>成功/情報(SQL)</summary>
            LevelTrace
            '''<summary>開始/終了</summary>
            LevelOperation
            '''<summary>警告</summary>
            LevelWarning
            '''<summary>エラー</summary>
            LevelError

        End Enum
#End Region

#Region "公開メソッド"


        ''' <summary>
        ''' ログ出力
        ''' </summary>
        ''' <param name="level">ログレベル</param>
        ''' <param name="msg">メッセージ</param>
        ''' <param name="clsName">クラス名</param>
        ''' <param name="mtdName">メソッド名</param>
        ''' <param name="screenId">画面ID</param>
        Public Sub WriteLog(ByVal level As LogLevel, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String, _
                                   ByVal msg As String)

            If level = 0 Then
                Throw New ArgumentException("引数が不正です。level=" & level.ToString, "level")
            End If

            ' ログレベル判定
            If IsLoglevel(level) = False Then
                Return
            End If

            Dim logInfo As String = Nothing

            Select Case level

                Case LogLevel.LevelDump
                    ' 情報(ダンプ)
                    logInfo = ABCDWebConst.LOG_LEVEL_DUMP
                Case LogLevel.LevelDebug
                    ' 情報(デバッグ)     
                    logInfo = ABCDWebConst.LOG_LEVEL_DEBUG
                Case LogLevel.LevelInformation
                    ' 情報(件数)
                    logInfo = ABCDWebConst.LOG_LEVEL_INFOMATION
                Case LogLevel.LevelTrace
                    ' 成功/情報(SQL)
                    logInfo = ABCDWebConst.LOG_LEVEL_TRACE
                Case LogLevel.LevelOperation
                    ' 開始/終了
                    logInfo = ABCDWebConst.LOG_LEVEL_OPERATION
                Case LogLevel.LevelWarning
                    ' 警告
                    logInfo = ABCDWebConst.LOG_LEVEL_WARNING
                Case LogLevel.LevelError
                    ' エラー
                    logInfo = ABCDWebConst.LOG_LEVEL_ERROR
            End Select

            ' ログ出力
            WriteLogStrings(logInfo, userID, clsName, mtdName, screenId, msg)
        End Sub

        ''' <summary>
        ''' ログ出力
        ''' </summary>
        ''' <param name="level">ログレベル</param>
        ''' <param name="msg">メッセージ</param>
        ''' <param name="clsName">クラス名</param>
        ''' <param name="mtdName">メソッド名</param>
        ''' <param name="screenId">画面ID</param>
        Public Sub WriteLog(ByVal level As LogLevel, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String, _
                                   ByVal msg As String, _
                                   ByVal exfileName As String)

            If level = 0 Then
                Throw New ArgumentException("引数が不正です。level=" & level.ToString, "level")
            End If

            ' ログレベル判定
            If IsLoglevel(level) = False Then
                Return
            End If

            Dim logInfo As String = Nothing

            Select Case level

                Case LogLevel.LevelDump
                    ' 情報(ダンプ)
                    logInfo = ABCDWebConst.LOG_LEVEL_DUMP
                Case LogLevel.LevelDebug
                    ' 情報(デバッグ)     
                    logInfo = ABCDWebConst.LOG_LEVEL_DEBUG
                Case LogLevel.LevelInformation
                    ' 情報(件数)
                    logInfo = ABCDWebConst.LOG_LEVEL_INFOMATION
                Case LogLevel.LevelTrace
                    ' 成功/情報(SQL)
                    logInfo = ABCDWebConst.LOG_LEVEL_TRACE
                Case LogLevel.LevelOperation
                    ' 開始/終了
                    logInfo = ABCDWebConst.LOG_LEVEL_OPERATION
                Case LogLevel.LevelWarning
                    ' 警告
                    logInfo = ABCDWebConst.LOG_LEVEL_WARNING
                Case LogLevel.LevelError
                    ' エラー
                    logInfo = ABCDWebConst.LOG_LEVEL_ERROR
            End Select

            ' ログ出力
            WriteLogStrings(logInfo, userID, clsName, mtdName, screenId, msg, exfileName)

        End Sub

        ''' <summary>
        '''  エラーログ出力
        ''' </summary>
        ''' <param name="ex">エラー情報</param>
        ''' <param name="userID">ユーザーID</param>
        ''' <param name="clsName">クラス名</param>
        ''' <param name="mtdName">メソッド名</param>
        ''' <param name="screenId">画面ID</param>
        Public Sub WriteLog(ByVal ex As Exception, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String)

            If ex Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。ex=nothing")
            End If
            WriteLogStrings(ABCDWebConst.LOG_LEVEL_ERROR, userID, clsName, mtdName, screenId, ex.ToString)
        End Sub

        ''' <summary>
        ''' エラーログ出力
        ''' </summary>
        ''' <param name="ex">エラー情報</param>
        ''' <param name="userID">ユーザーID</param>
        ''' <param name="clsName">クラス名</param>
        ''' <param name="mtdName">メソッド名</param>
        ''' <param name="screenId">画面ID</param>
        ''' <param name="exfileName">拡張ログファイル名称</param>
        Public Sub WriteLog(ByVal ex As Exception, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String, _
                                   ByVal exfileName As String)

            If ex Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。ex=nothing")
            End If
            WriteLogStrings(ABCDWebConst.LOG_LEVEL_ERROR, userID, clsName, mtdName, screenId, ex.ToString, exfileName)
        End Sub

        ''' <summary>
        ''' ログレベルの取得
        ''' </summary>
        ''' <returns>ログレベル</returns>
        Public Function GetLoglevel() As ABCDWebLog.LogLevel
            Dim logLevel As LogLevel

            Dim level As String = GetFileData("LOG/LOG_LEVEL").ToString
            Select Case level
                ' 情報(ダンプ)
                Case "1"
                    logLevel = logLevel.LevelDump
                    ' 情報(デバッグ)                     
                Case "2"
                    logLevel = logLevel.LevelDebug
                    ' 情報(件数)
                Case "3"
                    logLevel = logLevel.LevelInformation
                    ' 成功/情報(SQL)
                Case "4"
                    logLevel = logLevel.LevelTrace
                    ' 開始/終了
                Case "5"
                    logLevel = logLevel.LevelOperation
                    ' 警告
                Case "6"
                    logLevel = logLevel.LevelWarning
                    ' エラー
                Case "7"
                    logLevel = logLevel.LevelError
                    ' 上記以外
                Case Else
                    Throw New ApplicationException("ログレベル定義が不正です[1～7のみ有効]。ログレベル定義=" & logLevel)
            End Select

            Return logLevel

        End Function

        ''' <summary>
        ''' ログレベルの判定
        ''' </summary>
        ''' <param name="level">ログレベル</param>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Public Function IsLoglevel(ByVal level As LogLevel) As Boolean
            If level = 0 Then
                Throw New ArgumentException("引数が不正です。level=" & level.ToString, "level")
            End If

            If GetLoglevel() <= level Then
                Return True
            Else
                Return False
            End If
        End Function

#End Region

#Region "内部メソッド"

        ''' <summary>
        ''' ログ文字列作成
        ''' </summary>
        ''' <param name="level">ログレベル</param>
        ''' <param name="userID">ユーザーID</param>
        ''' <param name="clsName">クラス名</param>
        ''' <param name="mtdName">メソッド名</param>
        ''' <param name="screenId">画面ID</param>
        ''' <param name="msg">メッセージ</param>
        Private Sub WriteLogStrings(ByVal level As String, _
                                           ByVal userID As String, _
                                           ByVal clsName As String, _
                                           ByVal mtdName As String, _
                                           ByVal screenId As String, _
                                           ByVal msg As String, _
                                           Optional ByVal exfileName As String = "")


            If userID Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。userID=Nothing", "userID")
            End If

            If clsName Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。clsName=Nothing", "clsName")
            End If

            If mtdName Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。mtdName=Nothing", "mtdName")
            End If

            If screenId Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。screenId=Nothing", "screenId")
            End If

            If msg Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。msg=Nothing", "msg")
            End If

            Dim strLog(4) As String
            strLog(0) = level
            strLog(1) = userID
            strLog(2) = clsName
            strLog(3) = mtdName
            strLog(4) = msg

            Dim str As String = String.Join(", ", strLog)

            ' ログファイル書き込み
            WriteLog(str, exfileName)
        End Sub

        ''' <summary>
        ''' ログファイル書き込み
        ''' </summary>
        ''' <param name="msg">文字列</param>
        Private Sub WriteLog(ByVal msg As String, Optional ByVal exfileName As String = "")
            Dim time As Date = Now

            Dim logFileName As String
            Dim logFileDir As String

            logFileName = GetFileData("LOG/FILE_NAME")
            ' FILE_NAMEが取得できない場合
            If String.IsNullOrEmpty(logFileName) Then
                Throw New ApplicationException("ログファイル名が取得できませんでした。ログファイル名=Nothing")
            End If

            If Not String.IsNullOrEmpty(exfileName) Then
                logFileName &= "_" & exfileName
            End If

            logFileDir = GetFileData("LOG/FILE_DIR")
            If String.IsNullOrEmpty(logFileDir) Then
                Throw New ApplicationException("ログファイルのパス定義が不正です。ログファイルのパス=Nothing")
            End If

            Dim newLogFileName As String = logFileName & "_" & time.ToString("yyyyMMdd") & ".log" 'logファイル名

            ' フォルダ作成
            If File.Exists(logFileDir & newLogFileName) = False Then
                Directory.CreateDirectory(logFileDir)
            End If

            Dim log As String = time.ToString("yyyy/MM/dd HH:mm:ss fff")                        '出力日時の取得

            ' 文字列作成
            log += ", " & msg

            ' logファイル書き込み処理
            Dim sw As StreamWriter = Nothing
            Try

                ' ファイルへ出力
                sw = New StreamWriter(logFileDir & newLogFileName, True, Encoding.Default)
                sw.WriteLine(log)
                Console.WriteLine(log)

            Catch ex As Exception
                Throw ex

            Finally
                If sw IsNot Nothing Then
                    sw.Close()
                    sw = Nothing
                End If
            End Try

        End Sub

        ''' <summary>
        ''' 構成ファイルより情報取得
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <returns>取得情報</returns>
        Private Shared Function GetFileData(ByVal xPath As String) As String
            Try


                Dim xmlDoc As New XmlDocument
                Dim dir As String = System.Configuration.ConfigurationManager.AppSettings("XML_FILE_DIR") & "\" & ABCDWebConst.APP_CONFIG_FILE
                xmlDoc.Load(dir)

                Dim xmlNodeList As XmlNodeList = xmlDoc.SelectNodes("descendant::" & xPath)
                Dim count As Integer = xmlNodeList.Count
                If count = 0 Then
                    Return String.Empty
                End If

                Return xmlNodeList(0).InnerText

            Catch ex As Exception
                Return String.Empty
            End Try

        End Function

#End Region

    End Class
End Namespace
