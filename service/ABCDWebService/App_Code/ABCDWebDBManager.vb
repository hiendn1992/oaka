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

Imports System.Data
Imports System.Data.SqlClient

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' DBアクセス管理クラス
    ''' </summary>
    Public Class ABCDWebDBManager
        Inherits ABCDWebBase

#Region "ユーザ宣言"

        ''' <summary>ORACLE接続 ユーザ</summary>
        Private _userID As String
        ''' <summary>ORACLE接続 パスワード</summary>
        Private _password As String
        ''' <summary>ORACLE接続 データソース</summary>
        Private _dataSource As String
        '@@@Oracle -> SQLServer WebService --start  
        '' <summary>コネクション情報</summary>
        'Private _conn As OracleConnection
        Private _conn As SqlConnection
        ''' <summary>ｺﾏﾝﾄﾞSQL実行ﾀｲﾑｱｳﾄ時間(秒)</summary>
        Private _commandTimeout As Integer
        ' <summary>トランザクション情報</summary>
        'Private _tran As OracleTransaction
        Private _tran As SqlTransaction

        '' <summary>コマンド情報</summary>
        'Private _cmd As OracleCommand
        Private _cmd As SqlCommand
        '' <summary>データソース情報</summary>
        'Public _dataReader As OracleDataReader
        Public _dataReader As SqlDataReader
        ' SQLSERVER CATALOG
        Private Shared _cataLog As String
        '@@@Oracle -> SQLServer WebService --end

#End Region

#Region "ユーザ関数定義"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        Sub New(ByVal userId As String)

            Me.UserId = userId

            ' 1回だけ外部ファイルから読み込む
            Dim xmlMrg As New ABCDWebXmlManager(System.Configuration.ConfigurationManager.AppSettings("XML_FILE_DIR") & "\" & ABCDWebConst.APP_CONFIG_FILE)
            _userID = xmlMrg.ReadString("DB/USER_ID")        ' ORACLE接続 ユーザ
            _password = xmlMrg.ReadString("DB/PASSWORD")     ' ORACLE接続 パスワード
            _dataSource = xmlMrg.ReadString("DB/DATASORCE")  ' ORACLE接続 データソース
            '@@@Oracle -> SQLServer WebService --start
            _cataLog = xmlMrg.ReadString("DB/CATALOG")       ' SQLSERVER DATABASE NAME
            '@@@Oracle -> SQLServer WebService --end
            Integer.TryParse(xmlMrg.ReadString("DB/COMMAND_TIMEOUT"), _commandTimeout)           ' ｺﾏﾝﾄﾞSQL実行ﾀｲﾑｱｳﾄ時間
            '// WriteDebugLog("DB/USER_ID:" & _userID) -- Not used
            '// WriteDebugLog("DB/PASSWORD:" & _password)
            '// WriteDebugLog("DB/DATASORCE:" & _dataSource)
            '@@@Oracle -> SQLServer WebService --start
            '// WriteDebugLog("DB/CATALOG:" & _cataLog)
            '@@@Oracle -> SQLServer WebService --end
        End Sub

        ''' <summary>
        ''' 内部変数をすべて破棄します。
        ''' </summary>
        ''' <remarks>
        ''' 　・コネクション情報
        ''' 　・トランザクション情報
        ''' 　・コマンド情報
        ''' 　・データソース情報
        ''' </remarks>
        Public Sub Dispose()

            ' データソース情報を破棄
            If (Me._dataReader IsNot Nothing) Then
                If (Me._dataReader.IsClosed = False) Then
                    Me._dataReader.Close()
                End If
                Me._dataReader.Dispose()
                Me._dataReader = Nothing
            End If

            ' コマンド情報を破棄
            If (Me._cmd IsNot Nothing) Then
                Try
                    Me._cmd.Cancel()
                Catch ex As Exception
                End Try
                Me._cmd.Dispose()
                Me._cmd = Nothing
            End If

            ' トランザクションを破棄
            If (Me._tran IsNot Nothing) Then
                Try
                    Me._tran.Rollback()
                Catch ex As Exception
                End Try
                Me._tran.Dispose()
                Me._tran = Nothing
            End If

            If (Me._conn IsNot Nothing) Then
                Try
                    Me._conn.Close()
                Catch ex As Exception
                End Try
                Me._conn.Dispose()
                Me._conn = Nothing
                System.GC.Collect()
            End If

        End Sub

        ''' <summary>
        ''' データベースへの接続を開く
        ''' </summary>
        Public Sub Connect()
            '// WriteTraceLog("開始")
            Try
                ' 内部変数をすべて破棄します。
                Dispose()

                If (_conn Is Nothing) Then
                    ' データベースへの接続を開く
                    '@@@Oracle -> SQLServer WebService --start
                    '_conn = New OracleConnection
                    _conn = New SqlConnection


                    ' _conn.ConnectionString = "User ID=" & _userID _
                    '                      & ";Password=" & _password _
                    '                      & ";Data Source=" & _dataSource
                    _conn.ConnectionString = "Data Source=" & _dataSource _
                                           & ";Initial Catalog=" & _cataLog _
                                           & ";User ID=" & _userID _
                                           & ";Password=" & _password _
                                           & ";Persist Security Info=True"

                    '// WriteDebugLog("OracleConnection.Open() ■ 直前")
                    _conn.Open()
                    '// WriteDebugLog("OracleConnection.Open() ■ 直後")
                    '@@@Oracle -> SQLServer WebService --end
                End If

                ' トランザクション開始
                Me._tran = _conn.BeginTransaction

            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                WriteDebugLog("DBへ接続失敗しました。" & ex.ToString)
                Throw New Exception("DBへ接続失敗しました。", ex)
            End Try
            '// WriteTraceLog("終了")
        End Sub

        ''' <summary>
        ''' データベースへの接続を閉じる
        ''' </summary>
        Public Sub Disconnect()
            ' 内部変数をすべて破棄します。
            Dispose()
        End Sub

        ''' <summary>
        ''' SQL データベース トランザクションをコミットします。 
        ''' </summary>
        Public Sub Commit()
            '// WriteDebugLog("OracleTransaction.Commit() ■ 直前")
            Me._tran.Commit()
            '// WriteDebugLog("OracleTransaction.Commit() ■ 直後")
        End Sub

        ''' <summary>
        ''' トランザクションを保留中の状態からロールバックします。 
        ''' </summary>
        Public Sub Rollback()
            '// WriteDebugLog("OracleTransaction.Rollback() ■ 直前")
            '@@@Oracle -> SQLServer --start  
            'Me._tran.Rollback()
            CloseDataReader()
            If (_tran IsNot Nothing) Then
                'ﾄﾗﾝｻﾞｸｼｮﾝのｺﾈｸｼｮﾝのNothingﾁｪｯｸ
                If (_tran.Connection IsNot Nothing) Then
                    _tran.Rollback()
                End If
            End If
            '@@@Oracle -> SQLServer --end
            '// WriteDebugLog("OracleTransaction.Rollback() ■ 直後")
        End Sub

        ''' <summary>
        ''' cuongnc: Close DataReader if it exist
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CloseDataReader()
            '@@@Oracle -> SQLServer --start  
            If (_dataReader IsNot Nothing) Then
                If (_dataReader.IsClosed = False) Then
                    _dataReader.Close()
                End If
                _dataReader.Dispose()
                _dataReader = Nothing
            End If
        End Sub

        ''' <summary>
        ''' SQLステートメント または ストアド プロシージャを設定します。
        ''' </summary>
        ''' <param name="commandText">SQLステートメント または ストアド プロシージャ</param>
        Public Sub SetCommandText(ByVal commandText As String)
            Try
                If Me._cmd IsNot Nothing Then
                    Me._cmd.Dispose()
                    Me._cmd = Nothing
                End If

                '// WriteTraceLog("SQL=" & commandText)
                '@@@Oracle -> SQLServer --start
                'Me._cmd = New OracleCommand
                Me._cmd = New SqlCommand
                '@@@Oracle -> SQLServer --end
                Me._cmd.Connection = _conn
                Me._cmd.CommandTimeout = _commandTimeout
                _cmd.Transaction = _tran
                Me._cmd.CommandText = commandText
            Catch ex As Exception
                WriteErrorLog(ex)
                Throw New Exception("DBへ接続失敗しました。", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【DBNull型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        Public Sub AddParameter(ByVal name As String)
            '@@@Oracle -> SQLServer --start
            'Me._cmd.BindByName = True
            'Me._cmd.ArrayBindCount = 0
            'Me._cmd.Parameters.Add(name, DBNull.Value)
            Me._cmd.Parameters.AddWithValue(name, DBNull.Value)
            '@@@Oracle -> SQLServer --end
            If IsDebug() = True Then
                '// WriteDebugLog("SQL Parameter : " & name & "=DBNull.Value")
            End If
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Char型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        Public Sub AddParameterChar(ByVal name As String, _
                                    ByVal value As String)
            AddParameterChar(name, value, 0, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Char型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="size">列内のデータの最大サイズをバイト単位で設定</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Public Sub AddParameterChar(ByVal name As String, _
                                    ByVal value As String, _
                                    ByVal size As Integer, _
                                    ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Char, value, size, direction)
            AddParameter(name, SqlDbType.Char, value, size, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【String型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As String)
            AddParameter(name, value, 0, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【String型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="size">列内のデータの最大サイズをバイト単位で設定</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As String, _
                                ByVal size As Integer, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Varchar2, value, size, direction)
            AddParameter(name, SqlDbType.NVarChar, value, size, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Integer型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Integer)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Integer型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Integer, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Int32, value, 0, direction)
            AddParameter(name, SqlDbType.Int, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Long型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Long)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Long型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Long, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Int64, value, 0, direction)
            AddParameter(name, SqlDbType.Int, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Decimal型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Decimal)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Decimal型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Decimal, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Decimal, value, 0, direction)
            AddParameter(name, SqlDbType.Decimal, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Double型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Double)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Double型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Double, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            AddParameter(name, SqlDbType.Decimal, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Date型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Date)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Date型】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Date, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Date, value, 0, direction)
            AddParameter(name, SqlDbType.DateTime, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="dbType">DBのデータ型</param>
        ''' <param name="value">パラメータ値</param>
        ''' <param name="size">列内のデータの最大サイズをバイト単位で設定</param>
        ''' <param name="direction">クエリ内のパラメータの型</param>
        Private Sub AddParameter(ByVal name As String, _
                                 ByVal dbType As SqlDbType, _
                                 ByVal value As Object, _
                                 ByVal size As Integer, _
                                 ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'Me._cmd.BindByName = True
            'Me._cmd.ArrayBindCount = 0
            '@@@Oracle -> SQLServer --end
            Me._cmd.Parameters.Add(name, dbType).Value = value
            Me._cmd.Parameters(name).Direction = direction
            If (size > 0) Then
                Me._cmd.Parameters(name).Size = size
            End If
            If IsDebug() = True Then
                Dim strValue As String = Nothing
                If value Is Nothing Then
                    strValue = "Nothing"
                Else
                    strValue = value.ToString()
                End If
                '// WriteDebugLog("SQL Parameter : " & name & "=" & strValue & " dbType=" & dbType.ToString() & " Size=" & size.ToString() & " Direction=" & direction.ToString())
            End If
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Char型 配列】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="values">パラメータ値</param>
        Public Sub AddParameterChar(ByVal name As String, _
                                    ByVal values() As String)
            '@@@Oracle -> SQLServer --start
            'Dim dbType As OracleDbType = OracleDbType.Char
            'Me._cmd.ArrayBindCount = values.Length
            Dim dbType As SqlDbType = SqlDbType.Char
            ' Me._cmd.ArrayBindCount = values.Length
            '@@@Oracle -> SQLServer --end
            Me._cmd.Parameters.Add(name, dbType, ParameterDirection.Input).Value = values
            AddParameterDebugLog(name, dbType, values)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【String型 配列】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="values">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal values() As String)
            '@@@Oracle -> SQLServer --start
            'Dim dbType As OracleDbType = OracleDbType.Varchar2
            'Me._cmd.BindByName = True
            'Me._cmd.ArrayBindCount = values.Length
            Dim dbType As SqlDbType = SqlDbType.VarChar
            'Me._cmd.BindByName = True
            'Me._cmd.ArrayBindCount = values.Length
            '@@@Oracle -> SQLServer --end
            Me._cmd.Parameters.Add(name, dbType, ParameterDirection.Input).Value = values
            AddParameterDebugLog(name, dbType, values)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Integer型 配列】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="values">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal values() As Integer)
            '@@@Oracle -> SQLServer --start
            Dim dbType As SqlDbType = SqlDbType.Int
            'Dim dbType As OracleDbType = OracleDbType.Int32
            'Me._cmd.BindByName = True
            'Me._cmd.ArrayBindCount = values.Length
            '@@@Oracle -> SQLServer --end
            Me._cmd.Parameters.Add(name, dbType, ParameterDirection.Input).Value = values
            AddParameterDebugLog(name, dbType, values)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Long型 配列】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="values">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal values() As Long)
            '@@@Oracle -> SQLServer No.X  --start
            Dim dbType As SqlDbType = SqlDbType.Int
            '_Cmd.BindByName = True
            '_Cmd.ArrayBindCount = values.Length
            '@@@Oracle -> SQLServer No.X  --end
            _cmd.Parameters.Add(name, dbType, ParameterDirection.Input).Value = values
            AddParameterDebugLog(name, dbType, values)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Decimal型 配列】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="values">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal values() As Decimal)
            '@@@Oracle -> SQLServer No.X  --start
            'Dim dbType As SqlDbType = SqlDbType.Decimal
            Dim dbType As SqlDbType = SqlDbType.Decimal
            '_Cmd.BindByName = True
            '_Cmd.ArrayBindCount = values.Length
            '@@@Oracle -> SQLServer No.X  --end
            _cmd.Parameters.Add(name, dbType, ParameterDirection.Input).Value = values
            AddParameterDebugLog(name, dbType, values)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Double型 配列】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="values">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal values() As Double)
            '@@@Oracle -> SQLServer No.X  --start
            Dim dbType As SqlDbType = SqlDbType.Decimal
            '_Cmd.BindByName = True
            '_Cmd.ArrayBindCount = values.Length
            '@@@Oracle -> SQLServer No.X  --end
            _cmd.Parameters.Add(name, dbType, ParameterDirection.Input).Value = values
            AddParameterDebugLog(name, dbType, values)
        End Sub

        ''' <summary>
        ''' Command のパラメータを設定します。【Date型 配列】
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="values">パラメータ値</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal values() As Date)
            '@@@Oracle -> SQLServer No.X  --start
            Dim dbType As SqlDbType = SqlDbType.Date
            '_Cmd.BindByName = True
            '_Cmd.ArrayBindCount = values.Length
            '@@@Oracle -> SQLServer No.X  --end
            _cmd.Parameters.Add(name, dbType, ParameterDirection.Input).Value = values
        End Sub

        ''' <summary>
        ''' Command のパラメータをログにダンプします。
        ''' </summary>
        ''' <param name="name">パラメータの名前</param>
        ''' <param name="dbType">DBのデータ型</param>
        ''' <param name="obj">パラメータ値</param>
        Private Sub AddParameterDebugLog(ByVal name As String, _
                                         ByVal dbType As SqlDbType, _
                                         ByVal obj As Object)
            If IsDump() = True Then
                Dim strOutF As String = "SQL Parameter : " & name & "["
                Dim strOutR As String = " dbType=" & dbType.ToString()
                Dim i As Int32
                If (TypeOf obj Is String()) Then
                    Dim valueArray() As String = CType(obj, String())
                    For i = 0 To valueArray.Length - 1
                        '// WriteDebugLog(strOutF & i & "]=" & valueArray(i) & strOutR)
                    Next
                ElseIf (TypeOf obj Is Integer()) Then
                    Dim valueArray() As Integer = CType(obj, Integer())
                    For i = 0 To valueArray.Length - 1
                        '// WriteDebugLog(strOutF & i & "]=" & valueArray(i).ToString() & strOutR)
                    Next
                ElseIf (TypeOf obj Is Long()) Then
                    Dim valueArray() As Long = CType(obj, Long())
                    For i = 0 To valueArray.Length - 1
                        '// WriteDebugLog(strOutF & i & "]=" & valueArray(i).ToString() & strOutR)
                    Next
                ElseIf (TypeOf obj Is Decimal()) Then
                    Dim valueArray() As Decimal = CType(obj, Decimal())
                    For i = 0 To valueArray.Length - 1
                        '// WriteDebugLog(strOutF & i & "]=" & valueArray(i).ToString() & strOutR)
                    Next
                ElseIf (TypeOf obj Is Double()) Then
                    Dim valueArray() As Double = CType(obj, Double())
                    For i = 0 To valueArray.Length - 1
                        '// WriteDebugLog(strOutF & i & "]=" & valueArray(i).ToString() & strOutR)
                    Next
                ElseIf (TypeOf obj Is Date()) Then
                    Dim valueArray() As Date = CType(obj, Date())
                    For i = 0 To valueArray.Length - 1
                        '// WriteDebugLog(strOutF & i & "]=" & valueArray(i).ToString() & strOutR)
                    Next
                ElseIf (TypeOf obj Is Object()) Then
                    Dim valueArray() As Object = CType(obj, Object())
                    For i = 0 To valueArray.Length - 1
                        '// WriteDebugLog(strOutF & i & "]=" & valueArray(i).ToString() & strOutR)
                    Next
                End If
            End If
        End Sub

        ''' <summary>
        ''' データの取得(接続型）
        ''' </summary>
        Public Sub ExecuteReader()
            '// WriteTraceLog("OracleCommand.ExecuteReader() ■ 直前")
            '@@@Oracle -> SQLServer Init before Execute --start
            CloseDataReader()
            '@@@Oracle -> SQLServer Init before Execute --end  
            Me._dataReader = Me._cmd.ExecuteReader
            '// WriteTraceLog("OracleCommand.ExecuteReader() ■ 直後")
        End Sub

        ''' <summary>
        ''' DataReaderを次のレコードに進めます。 
        ''' </summary>
        ''' <returns>他の行が存在する場合は true。それ以外の場合は false。 </returns>
        Public Function Read() As Boolean
            Return Me._dataReader.Read()
        End Function

        ''' <summary>
        ''' 列の名前を指定して、列の序数を取得します。
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>列の 0 から始まる序数</returns>
        Public Function GetOrdinal(ByVal name As String) As Integer
            Return Me._dataReader.GetOrdinal(name)
        End Function

        ''' <summary>
        ''' 指定した列の値がNullであるか判定します。
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>True:Null  False:値あり</returns>
        Public Function IsDBNull(ByVal name As String) As Boolean
            Return Me._dataReader.IsDBNull(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' 指定した列の値を文字列として取得します。 
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>文字列</returns>
        Public Function GetString(ByVal name As String) As String
            Return GetString(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' 指定した列の値を文字列として取得します。 
        ''' </summary>
        ''' <param name="index">カラムIndex</param>
        ''' <returns>文字列</returns>
        Public Function GetString(ByVal index As Integer) As String
            If (Me._dataReader.IsDBNull(index) = True) Then
                Return String.Empty
            End If
            Return Me._dataReader.GetString(index)
        End Function

        ''' <summary>
        ''' 指定した列の値を 32 ビット符号付き整数として取得します。 
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetInt32(ByVal name As String) As Integer
            Return GetInt32(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' 指定した列の値を 32 ビット符号付き整数として取得します。 
        ''' </summary>
        ''' <param name="index">カラムIndex</param>
        ''' <returns>数値</returns>
        Public Function GetInt32(ByVal index As Integer) As Integer
            Return Me._dataReader.GetInt32(index)
        End Function

        ''' <summary>
        ''' 指定した列の値を 64 ビット符号付き整数として取得します。  
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetInt64(ByVal name As String) As Long
            Return GetInt64(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' 指定した列の値を 64 ビット符号付き整数として取得します。  
        ''' </summary>
        ''' <param name="index">カラムIndex</param>
        ''' <returns>数値</returns>
        Public Function GetInt64(ByVal index As Integer) As Long
            Return Me._dataReader.GetInt64(index)
        End Function

        ''' <summary>
        ''' 指定した列の値を Decimal オブジェクトとして取得します。  
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetDecimal(ByVal name As String) As Decimal
            Return GetDecimal(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' 指定した列の値を Decimal オブジェクトとして取得します。  
        ''' </summary>
        ''' <param name="index">カラムIndex</param>
        ''' <returns>数値</returns>
        Public Function GetDecimal(ByVal index As Integer) As Decimal
            Return Me._dataReader.GetDecimal(index)
        End Function

        ''' <summary>
        ''' 指定した列の値を倍精度浮動小数点数値として取得します。 
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetDouble(ByVal name As String) As Double
            Return GetDouble(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' 指定した列の値を倍精度浮動小数点数値として取得します。 
        ''' </summary>
        ''' <param name="index">カラムIndex</param>
        ''' <returns>数値</returns>
        Public Function GetDouble(ByVal index As Integer) As Double
            Return Me._dataReader.GetDouble(index)
        End Function

        ''' <summary>
        ''' 指定した列の値を DateTime オブジェクトとして取得します。 
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>日付</returns>
        Public Function GetDateTime(ByVal name As String) As DateTime
            Return GetDateTime(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' 指定した列の値を DateTime オブジェクトとして取得します。 
        ''' </summary>
        ''' <param name="index">カラムIndex</param>
        ''' <returns>日付</returns>
        Public Function GetDateTime(ByVal index As Integer) As DateTime
            Return Me._dataReader.GetDateTime(index)
        End Function

        ''' <summary>
        ''' データを取得します【DataSet型】
        ''' </summary>
        ''' <returns>DataSet</returns>
        Public Function ExecuteDataSetFill() As DataSet
            '// WriteTraceLog("OracleDataAdapter.Fill(DataSet) ■ 直前")
            ' データの取得
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            Dim da As New SqlDataAdapter(_cmd)
            '@@@Oracle -> SQLServer WebService --end
            Dim ds As New DataSet
            da.Fill(ds)
            da.Dispose()
            da = Nothing
            '// WriteTraceLog("OracleDataAdapter.Fill(DataSet) ■ 直後")
            '// WriteTraceLog("OracleDataAdapter.Fill(DataSet) ■ 取得件数 = " & ds.Tables(0).Rows.Count & "件")
            Return ds
        End Function

        ''' <summary>
        ''' データを取得します【DataTable型】
        ''' </summary>
        ''' <returns>DataTable</returns>
        Public Function ExecuteDataTableFill() As DataTable
            '// WriteTraceLog("OracleDataAdapter.Fill(DataTable) ■ 直前")
            ' データの取得
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            Dim da As New SqlDataAdapter(Me._cmd)
            '@@@Oracle -> SQLServer WebService --end
            Dim dt As New DataTable
            da.Fill(dt)
            da.Dispose()
            da = Nothing
            '// WriteTraceLog("OracleDataAdapter.Fill(DataTable) ■ 直後")
            '// WriteTraceLog("OracleDataAdapter.Fill(DataTable) ■ 取得件数 = " & dt.Rows.Count & "件")
            Return dt
        End Function

        ''' <summary>
        ''' データベースから単一の値 (集計値など) を Oracle 固有のデータ型で取得します。 【String型】
        ''' </summary>
        ''' <returns>文字列</returns>
        Public Function ExecuteScalar() As String
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            '@@@Oracle -> SQLServer WebService --end
            Dim obj As Object = Me._cmd.ExecuteScalar()
            If obj Is Nothing Then
                Return String.Empty
            Else
                Return obj.ToString()
            End If
        End Function

        ''' <summary>
        ''' データベースから単一の値 (集計値など) を Oracle 固有のデータ型で取得します。 【Integer型】
        ''' </summary>
        ''' <returns>数値</returns>
        Public Function ExecuteScalarInt32() As Integer
            Return Convert.ToInt32(_cmd.ExecuteScalar())
        End Function

        ''' <summary>
        ''' データベースから単一の値 (集計値など) を Oracle 固有のデータ型で取得します。 【Long型】
        ''' </summary>
        ''' <returns>数値</returns>
        Public Function ExecuteScalarInt64() As Long
            Return Convert.ToInt64(_cmd.ExecuteScalar())
        End Function

        ''' <summary>
        ''' SQL の INSERT、DELETE、UPDATE、SET ステートメントなどのコマンドを実行します。 
        ''' </summary>
        ''' <returns>更新件数を返します。</returns>
        Public Function ExecuteNonQuery() As Integer
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            '@@@Oracle -> SQLServer WebService --end
            '// WriteTraceLog("OracleCommand.ExecuteNonQuery() ■ 直前")
            Dim ret As Integer = _cmd.ExecuteNonQuery()
            '// WriteTraceLog("OracleCommand.ExecuteNonQuery() ■ 直後")
            '// WriteTraceLog("OracleCommand.ExecuteNonQuery() ■ 更新件数 = " & ret.ToString() & "件")
            Return ret
        End Function

        ''' <summary>
        ''' ストアドプロシージャ／ストアドファンクションの呼び出し
        ''' </summary>
        Public Sub ExecuteStoredProcedure()
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            '@@@Oracle -> SQLServer WebService --end
            Me._cmd.CommandType = CommandType.StoredProcedure
            Dim ret As Integer = ExecuteNonQuery()
        End Sub

        ''' <summary>
        ''' 指定した列の値を文字列として取得します。 【ストアド用】
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>文字列</returns>
        Public Function GetParameterString(ByVal name As String) As String
            Return Me._cmd.Parameters(name).Value.ToString()
        End Function

        ''' <summary>
        ''' 指定した列の値を 32 ビット符号付き整数として取得します。 【ストアド用】
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetParameterInt32(ByVal name As String) As Integer
            '@@@Oracle -> SQLServer WebService --start
            Dim obj As Object = _cmd.Parameters(name).Value
            If (TypeOf obj Is SqlTypes.SqlDecimal) Then
                Return Decimal.ToInt32(CType(obj, SqlTypes.SqlDecimal).Value)
                'If (TypeOf obj Is OracleDecimal) Then
                '    Return Decimal.ToInt32(CType(obj, OracleDecimal).Value)
            ElseIf (TypeOf obj Is Decimal) Then
                Return Decimal.ToInt32(CType(obj, Decimal))
            ElseIf (TypeOf obj Is Integer) Then
                Return CType(obj, Integer)
            Else
                Return CInt(obj.ToString())
            End If
            '@@@Oracle -> SQLServer WebService --end
        End Function

        ''' <summary>
        ''' 指定した列の値を 64 ビット符号付き整数として取得します。  【ストアド用】
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetParameterInt64(ByVal name As String) As Long
            Dim obj As Object = _cmd.Parameters(name).Value
            '@@@Oracle -> SQLServer WebService --start
            'If (TypeOf obj Is OracleDecimal) Then
            '    Return Decimal.ToInt64(CType(obj, OracleDecimal).Value)
            If (TypeOf obj Is SqlTypes.SqlDecimal) Then
                Return Decimal.ToInt64(CType(obj, SqlTypes.SqlDecimal).Value)
                '@@@Oracle -> SQLServer WebService --end
            ElseIf (TypeOf obj Is Decimal) Then
                Return Decimal.ToInt64(CType(obj, Decimal))
            ElseIf (TypeOf obj Is Long) Then
                Return CType(obj, Long)
            Else
                Return CLng(obj.ToString())
            End If
        End Function

        ''' <summary>
        ''' 指定した列の値を Decimal オブジェクトとして取得します。  【ストアド用】
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetParameterDecimal(ByVal name As String) As Decimal
            Dim obj As Object = Me._cmd.Parameters(name).Value
            '@@@Oracle -> SQLServer WebService --start
            'If (TypeOf obj Is OracleDecimal) Then
            '    Return CType(obj, OracleDecimal).Value
            If (TypeOf obj Is SqlTypes.SqlDecimal) Then
                Return CType(obj, SqlTypes.SqlDecimal).Value
                '@@@Oracle -> SQLServer WebService --end
            ElseIf (TypeOf obj Is Decimal) Then
                Return CType(obj, Decimal)
            ElseIf (TypeOf obj Is Integer) Then
                Return New Decimal(CType(obj, Integer))
            ElseIf (TypeOf obj Is Long) Then
                Return New Decimal(CType(obj, Long))
            ElseIf (TypeOf obj Is Double) Then
                Return New Decimal(CType(obj, Double))
            Else
                Return CDec(obj.ToString())
            End If
        End Function

        ''' <summary>
        ''' 指定した列の値を倍精度浮動小数点数値として取得します。 【ストアド用】
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>数値</returns>
        Public Function GetParameterDouble(ByVal name As String) As Double
            Dim obj As Object = Me._cmd.Parameters(name).Value
            'If (TypeOf obj Is OracleDecimal) Then
            '    Return Decimal.ToDouble(CType(obj, OracleDecimal).Value)
            If (TypeOf obj Is SqlTypes.SqlDecimal) Then
                Return Decimal.ToDouble(CType(obj, SqlTypes.SqlDecimal).Value)
            ElseIf (TypeOf obj Is Decimal) Then
                Return Decimal.ToDouble(CType(obj, Decimal))
            ElseIf (TypeOf obj Is Double) Then
                Return CType(obj, Double)
            Else
                Return CDbl(obj.ToString())
            End If
        End Function

        ''' <summary>
        ''' 指定した列の値を DateTime オブジェクトとして取得します。 【ストアド用】
        ''' </summary>
        ''' <param name="name">列の名前</param>
        ''' <returns>日付</returns>
        Public Function GetParameterDateTime(ByVal name As String) As DateTime
            'If (TypeOf obj Is OracleDecimal) Then
            'If (TypeOf Me._cmd.Parameters(name).Value Is OracleDate) Then
            '    Return CType(Me._cmd.Parameters(name).Value, OracleDate).Value
            If (TypeOf Me._cmd.Parameters(name).Value Is SqlTypes.SqlDateTime) Then
                Return CType(Me._cmd.Parameters(name).Value, SqlTypes.SqlDateTime).Value
                'If (TypeOf obj Is OracleDecimal) end
            Else
                Return CType(Me._cmd.Parameters(name).Value, DateTime)
            End If
        End Function

#End Region

    End Class

End Namespace
