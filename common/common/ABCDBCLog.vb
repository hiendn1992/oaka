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
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Reflection

Namespace jp.co.ait.common

    ''' <summary>
    ''' ログクラス
    ''' </summary>
    Public Class ABCDBCLog

        ''' <summary>定義ファイルで指定されているlogファイル名の冠</summary>
        Private Shared _LogFileName As String
        ''' <summary>定義ファイルで指定されているlogファイルのパス</summary>
        Private Shared _LogFileDir As String
        ''' <summary>定義ファイルで指定されているログレベル</summary>
        Private Shared _LogLevel As LogLevel


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
        Public Shared Sub WriteLog(ByVal level As LogLevel, _
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

            Dim strLogInfo As String = Nothing

            Select Case level

                Case LogLevel.LevelDump
                    ' 情報(ダンプ)
                    strLogInfo = ABCDBCConst.LOG_LEVEL_DUMP
                Case LogLevel.LevelDebug
                    ' 情報(デバッグ)     
                    strLogInfo = ABCDBCConst.LOG_LEVEL_DEBUG
                Case LogLevel.LevelInformation
                    ' 情報(件数)
                    strLogInfo = ABCDBCConst.LOG_LEVEL_INFOMATION
                Case LogLevel.LevelTrace
                    ' 成功/情報(SQL)
                    strLogInfo = ABCDBCConst.LOG_LEVEL_TRACE
                Case LogLevel.LevelOperation
                    ' 開始/終了
                    strLogInfo = ABCDBCConst.LOG_LEVEL_OPERATION
                Case LogLevel.LevelWarning
                    ' 警告
                    strLogInfo = ABCDBCConst.LOG_LEVEL_WARNING
                Case LogLevel.LevelError
                    ' エラー
                    strLogInfo = ABCDBCConst.LOG_LEVEL_ERROR
            End Select

            ' ログ出力
            WriteLogStrings(strLogInfo, userID, clsName, mtdName, screenId, msg)


        End Sub


        ''' <summary>
        ''' エラーログ出力
        ''' </summary>
        ''' <param name="ex">エラー情報</param>
        ''' <param name="userID">ユーザーID</param>
        ''' <param name="clsName">クラス名</param>
        ''' <param name="mtdName">メソッド名</param>
        ''' <param name="screenId">画面ID</param>
        Public Shared Sub WriteLog(ByVal ex As Exception, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String)

            If ex Is Nothing Then
                Throw New ArgumentNullException("引数が不正です。ex=nothing")
            End If
            WriteLogStrings(ABCDBCConst.LOG_LEVEL_ERROR, userID, clsName, mtdName, screenId, ex.ToString)
        End Sub


        ''' <summary>
        ''' ログレベルの取得
        ''' </summary>
        ''' <returns>ログレベル</returns>
        Public Shared Function GetLoglevel() As ABCDBCLog.LogLevel

            If _LogLevel = 0 Then
                Dim level As String = GetFileData("BC_LOG/LOG_LEVEL").ToString
                Select Case level
                    ' 情報(ダンプ)
                    Case "1"
                        _LogLevel = LogLevel.LevelDump
                        ' 情報(デバッグ)                     
                    Case "2"
                        _LogLevel = LogLevel.LevelDebug
                        ' 情報(件数)
                    Case "3"
                        _LogLevel = LogLevel.LevelInformation
                        ' 成功/情報(SQL)
                    Case "4"
                        _LogLevel = LogLevel.LevelTrace
                        ' 開始/終了
                    Case "5"
                        _LogLevel = LogLevel.LevelOperation
                        ' 警告
                    Case "6"
                        _LogLevel = LogLevel.LevelWarning
                        ' エラー
                    Case "7"
                        _LogLevel = LogLevel.LevelError
                        ' 上記以外
                    Case Else
                        Throw New ApplicationException("ログレベル定義が不正です[1～7のみ有効]。ログレベル定義=" & _LogLevel)
                End Select
            End If
            Return _LogLevel

        End Function

        ''' <summary>
        ''' ログレベルの判定
        ''' </summary>
        ''' <param name="level">ログレベル</param>
        ''' <returns>ログの走行レベルが低い(ture) or ログの走行レベルが高い(false)</returns>
        Public Shared Function IsLoglevel(ByVal level As LogLevel) As Boolean
            If level = 0 Then
                Throw New ArgumentException("引数が不正です。level=" & level.ToString, "level")
            End If


            If GetLoglevel() <= level Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' 構成ファイルより情報取得
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <returns>取得情報</returns>
        Public Shared Function GetFileData(ByVal xPath As String) As String
            Try

                Dim _xmlDoc As New XmlDocument
                Dim dir As String = ABCDBCCommon.GetCurrentDir() & ABCDBCConst.APP_CONFIG_FILE

                _xmlDoc.Load(dir)

                Dim xmlNodeList As XmlNodeList = _xmlDoc.SelectNodes("descendant::" & xPath)
                Dim intCount As Integer = xmlNodeList.Count
                If intCount = 0 Then
                    Return String.Empty
                End If

                Return xmlNodeList(0).InnerText

                'Return ABCDBCXmlManager.GetFileData(xPath)

            Catch ex As Exception
                Return String.Empty
            End Try



        End Function

        ''' <summary>
        ''' ログファイル名を設定
        ''' </summary>
        ''' <value></value>
        Public Shared WriteOnly Property SetLogFileName() As String
            Set(ByVal value As String)
                _LogFileName = value
            End Set
        End Property

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
        Private Shared Sub WriteLogStrings(ByVal level As String, _
                                           ByVal userID As String, _
                                           ByVal clsName As String, _
                                           ByVal mtdName As String, _
                                           ByVal screenId As String, _
                                           ByVal msg As String)


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

            'Dim strLog(5) As String
            Dim strLog(4) As String
            strLog(0) = level
            strLog(1) = userID.PadRight(8)
            strLog(2) = clsName
            strLog(3) = mtdName
            'strLog(4) = screenId
            strLog(4) = msg

            Dim str As String = String.Join(", ", strLog)

            ' ログファイル書き込み
            WriteLog(str)
        End Sub


        ''' <summary>
        ''' ログファイル書き込み
        ''' </summary>
        ''' <param name="msg">文字列</param>
        Private Shared Sub WriteLog(ByVal msg As String)
            Dim time As Date = Now

            If _LogFileName Is Nothing Then
                _LogFileName = GetFileData("BC_LOG/FILE_NAME")
                'FILE_NAMEが取得できない場合
                If _LogFileName Is Nothing OrElse _LogFileName Is String.Empty Then
                    Throw New ApplicationException("ログファイル名が取得できませんでした。ログファイル名=Nothing")
                End If
            End If

            If _LogFileDir Is Nothing Then
                _LogFileDir = GetFileData("BC_LOG/FILE_DIR")
                If _LogFileDir Is Nothing Then
                    Throw New ApplicationException("ログファイルのパス定義が不正です。ログファイルのパス=Nothing")
                End If
            End If

            If _LogFileDir.Length = 0 Then
                _LogFileDir = ABCDBCCommon.GetCurrentDir()
            End If

            Dim newLogFileName As String = _LogFileName & time.ToString("yyyyMMdd") & ".log" 'logファイル名

            ''フォルダ作成
            If File.Exists(_LogFileDir & newLogFileName) = False Then
                Directory.CreateDirectory(_LogFileDir)
            End If

            Dim log As String = time.ToString("yyyy/MM/dd HH:mm:ss fff")                        '出力日時の取得

            '文字列作成
            log += ", " & msg

            'logファイル書き込み処理
            Dim sw As StreamWriter = Nothing
            Try

                '' ファイルへ出力
                sw = New StreamWriter(_LogFileDir & newLogFileName, True, Encoding.Default)
                sw.WriteLine(log)

            Catch ex As Exception
                'Throw ex

            Finally
                If sw IsNot Nothing Then
                    sw.Close()
                    sw = Nothing
                End If
            End Try


        End Sub

#End Region

    End Class
End Namespace
