''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* �V�X�e�����FABCD_Barcode_System
''* �N���X��  �FABCDWebService
''* �����T�v  �FBC�[���̗v�����A�Ɩ����s��
''*********************************************************
''* �����F
''* NO   ���t   Ver  �X�V��          ���e
#Region "�F���C������"
''* 1 14/12/12 1.00  AIT)cuongnc     New
#End Region
''*********************************************************

Imports System.Data
Imports System.Data.SqlClient

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' DB�A�N�Z�X�Ǘ��N���X
    ''' </summary>
    Public Class ABCDWebDBManager
        Inherits ABCDWebBase

#Region "���[�U�錾"

        ''' <summary>ORACLE�ڑ� ���[�U</summary>
        Private _userID As String
        ''' <summary>ORACLE�ڑ� �p�X���[�h</summary>
        Private _password As String
        ''' <summary>ORACLE�ڑ� �f�[�^�\�[�X</summary>
        Private _dataSource As String
        '@@@Oracle -> SQLServer WebService --start  
        '' <summary>�R�l�N�V�������</summary>
        'Private _conn As OracleConnection
        Private _conn As SqlConnection
        ''' <summary>�����SQL���s��ѱ�Ď���(�b)</summary>
        Private _commandTimeout As Integer
        ' <summary>�g�����U�N�V�������</summary>
        'Private _tran As OracleTransaction
        Private _tran As SqlTransaction

        '' <summary>�R�}���h���</summary>
        'Private _cmd As OracleCommand
        Private _cmd As SqlCommand
        '' <summary>�f�[�^�\�[�X���</summary>
        'Public _dataReader As OracleDataReader
        Public _dataReader As SqlDataReader
        ' SQLSERVER CATALOG
        Private Shared _cataLog As String
        '@@@Oracle -> SQLServer WebService --end

#End Region

#Region "���[�U�֐���`"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        Sub New(ByVal userId As String)

            Me.UserId = userId

            ' 1�񂾂��O���t�@�C������ǂݍ���
            Dim xmlMrg As New ABCDWebXmlManager(System.Configuration.ConfigurationManager.AppSettings("XML_FILE_DIR") & "\" & ABCDWebConst.APP_CONFIG_FILE)
            _userID = xmlMrg.ReadString("DB/USER_ID")        ' ORACLE�ڑ� ���[�U
            _password = xmlMrg.ReadString("DB/PASSWORD")     ' ORACLE�ڑ� �p�X���[�h
            _dataSource = xmlMrg.ReadString("DB/DATASORCE")  ' ORACLE�ڑ� �f�[�^�\�[�X
            '@@@Oracle -> SQLServer WebService --start
            _cataLog = xmlMrg.ReadString("DB/CATALOG")       ' SQLSERVER DATABASE NAME
            '@@@Oracle -> SQLServer WebService --end
            Integer.TryParse(xmlMrg.ReadString("DB/COMMAND_TIMEOUT"), _commandTimeout)           ' �����SQL���s��ѱ�Ď���
            '// WriteDebugLog("DB/USER_ID:" & _userID) -- Not used
            '// WriteDebugLog("DB/PASSWORD:" & _password)
            '// WriteDebugLog("DB/DATASORCE:" & _dataSource)
            '@@@Oracle -> SQLServer WebService --start
            '// WriteDebugLog("DB/CATALOG:" & _cataLog)
            '@@@Oracle -> SQLServer WebService --end
        End Sub

        ''' <summary>
        ''' �����ϐ������ׂĔj�����܂��B
        ''' </summary>
        ''' <remarks>
        ''' �@�E�R�l�N�V�������
        ''' �@�E�g�����U�N�V�������
        ''' �@�E�R�}���h���
        ''' �@�E�f�[�^�\�[�X���
        ''' </remarks>
        Public Sub Dispose()

            ' �f�[�^�\�[�X����j��
            If (Me._dataReader IsNot Nothing) Then
                If (Me._dataReader.IsClosed = False) Then
                    Me._dataReader.Close()
                End If
                Me._dataReader.Dispose()
                Me._dataReader = Nothing
            End If

            ' �R�}���h����j��
            If (Me._cmd IsNot Nothing) Then
                Try
                    Me._cmd.Cancel()
                Catch ex As Exception
                End Try
                Me._cmd.Dispose()
                Me._cmd = Nothing
            End If

            ' �g�����U�N�V������j��
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
        ''' �f�[�^�x�[�X�ւ̐ڑ����J��
        ''' </summary>
        Public Sub Connect()
            '// WriteTraceLog("�J�n")
            Try
                ' �����ϐ������ׂĔj�����܂��B
                Dispose()

                If (_conn Is Nothing) Then
                    ' �f�[�^�x�[�X�ւ̐ڑ����J��
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

                    '// WriteDebugLog("OracleConnection.Open() �� ���O")
                    _conn.Open()
                    '// WriteDebugLog("OracleConnection.Open() �� ����")
                    '@@@Oracle -> SQLServer WebService --end
                End If

                ' �g�����U�N�V�����J�n
                Me._tran = _conn.BeginTransaction

            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                WriteDebugLog("DB�֐ڑ����s���܂����B" & ex.ToString)
                Throw New Exception("DB�֐ڑ����s���܂����B", ex)
            End Try
            '// WriteTraceLog("�I��")
        End Sub

        ''' <summary>
        ''' �f�[�^�x�[�X�ւ̐ڑ������
        ''' </summary>
        Public Sub Disconnect()
            ' �����ϐ������ׂĔj�����܂��B
            Dispose()
        End Sub

        ''' <summary>
        ''' SQL �f�[�^�x�[�X �g�����U�N�V�������R�~�b�g���܂��B 
        ''' </summary>
        Public Sub Commit()
            '// WriteDebugLog("OracleTransaction.Commit() �� ���O")
            Me._tran.Commit()
            '// WriteDebugLog("OracleTransaction.Commit() �� ����")
        End Sub

        ''' <summary>
        ''' �g�����U�N�V������ۗ����̏�Ԃ��烍�[���o�b�N���܂��B 
        ''' </summary>
        Public Sub Rollback()
            '// WriteDebugLog("OracleTransaction.Rollback() �� ���O")
            '@@@Oracle -> SQLServer --start  
            'Me._tran.Rollback()
            CloseDataReader()
            If (_tran IsNot Nothing) Then
                '��ݻ޸��݂̺ȸ��݂�Nothing����
                If (_tran.Connection IsNot Nothing) Then
                    _tran.Rollback()
                End If
            End If
            '@@@Oracle -> SQLServer --end
            '// WriteDebugLog("OracleTransaction.Rollback() �� ����")
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
        ''' SQL�X�e�[�g�����g �܂��� �X�g�A�h �v���V�[�W����ݒ肵�܂��B
        ''' </summary>
        ''' <param name="commandText">SQL�X�e�[�g�����g �܂��� �X�g�A�h �v���V�[�W��</param>
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
                Throw New Exception("DB�֐ڑ����s���܂����B", ex)
            End Try
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDBNull�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yChar�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        Public Sub AddParameterChar(ByVal name As String, _
                                    ByVal value As String)
            AddParameterChar(name, value, 0, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yChar�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="size">����̃f�[�^�̍ő�T�C�Y���o�C�g�P�ʂŐݒ�</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yString�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As String)
            AddParameter(name, value, 0, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yString�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="size">����̃f�[�^�̍ő�T�C�Y���o�C�g�P�ʂŐݒ�</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yInteger�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Integer)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yInteger�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Integer, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Int32, value, 0, direction)
            AddParameter(name, SqlDbType.Int, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yLong�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Long)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yLong�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Long, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Int64, value, 0, direction)
            AddParameter(name, SqlDbType.Int, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDecimal�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Decimal)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDecimal�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Decimal, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Decimal, value, 0, direction)
            AddParameter(name, SqlDbType.Decimal, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDouble�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Double)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDouble�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Double, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            AddParameter(name, SqlDbType.Decimal, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDate�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Date)
            AddParameter(name, value, ParameterDirection.Input)
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDate�^�z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
        Public Sub AddParameter(ByVal name As String, _
                                ByVal value As Date, _
                                ByVal direction As ParameterDirection)
            '@@@Oracle -> SQLServer --start
            'AddParameter(name, OracleDbType.Date, value, 0, direction)
            AddParameter(name, SqlDbType.DateTime, value, 0, direction)
            '@@@Oracle -> SQLServer --end
        End Sub

        ''' <summary>
        ''' Command �̃p�����[�^��ݒ肵�܂��B
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="dbType">DB�̃f�[�^�^</param>
        ''' <param name="value">�p�����[�^�l</param>
        ''' <param name="size">����̃f�[�^�̍ő�T�C�Y���o�C�g�P�ʂŐݒ�</param>
        ''' <param name="direction">�N�G�����̃p�����[�^�̌^</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yChar�^ �z��z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="values">�p�����[�^�l</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yString�^ �z��z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="values">�p�����[�^�l</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yInteger�^ �z��z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="values">�p�����[�^�l</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yLong�^ �z��z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="values">�p�����[�^�l</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDecimal�^ �z��z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="values">�p�����[�^�l</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDouble�^ �z��z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="values">�p�����[�^�l</param>
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
        ''' Command �̃p�����[�^��ݒ肵�܂��B�yDate�^ �z��z
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="values">�p�����[�^�l</param>
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
        ''' Command �̃p�����[�^�����O�Ƀ_���v���܂��B
        ''' </summary>
        ''' <param name="name">�p�����[�^�̖��O</param>
        ''' <param name="dbType">DB�̃f�[�^�^</param>
        ''' <param name="obj">�p�����[�^�l</param>
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
        ''' �f�[�^�̎擾(�ڑ��^�j
        ''' </summary>
        Public Sub ExecuteReader()
            '// WriteTraceLog("OracleCommand.ExecuteReader() �� ���O")
            '@@@Oracle -> SQLServer Init before Execute --start
            CloseDataReader()
            '@@@Oracle -> SQLServer Init before Execute --end  
            Me._dataReader = Me._cmd.ExecuteReader
            '// WriteTraceLog("OracleCommand.ExecuteReader() �� ����")
        End Sub

        ''' <summary>
        ''' DataReader�����̃��R�[�h�ɐi�߂܂��B 
        ''' </summary>
        ''' <returns>���̍s�����݂���ꍇ�� true�B����ȊO�̏ꍇ�� false�B </returns>
        Public Function Read() As Boolean
            Return Me._dataReader.Read()
        End Function

        ''' <summary>
        ''' ��̖��O���w�肵�āA��̏������擾���܂��B
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>��� 0 ����n�܂鏘��</returns>
        Public Function GetOrdinal(ByVal name As String) As Integer
            Return Me._dataReader.GetOrdinal(name)
        End Function

        ''' <summary>
        ''' �w�肵����̒l��Null�ł��邩���肵�܂��B
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>True:Null  False:�l����</returns>
        Public Function IsDBNull(ByVal name As String) As Boolean
            Return Me._dataReader.IsDBNull(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' �w�肵����̒l�𕶎���Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>������</returns>
        Public Function GetString(ByVal name As String) As String
            Return GetString(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' �w�肵����̒l�𕶎���Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="index">�J����Index</param>
        ''' <returns>������</returns>
        Public Function GetString(ByVal index As Integer) As String
            If (Me._dataReader.IsDBNull(index) = True) Then
                Return String.Empty
            End If
            Return Me._dataReader.GetString(index)
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� 32 �r�b�g�����t�������Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
        Public Function GetInt32(ByVal name As String) As Integer
            Return GetInt32(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� 32 �r�b�g�����t�������Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="index">�J����Index</param>
        ''' <returns>���l</returns>
        Public Function GetInt32(ByVal index As Integer) As Integer
            Return Me._dataReader.GetInt32(index)
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� 64 �r�b�g�����t�������Ƃ��Ď擾���܂��B  
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
        Public Function GetInt64(ByVal name As String) As Long
            Return GetInt64(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� 64 �r�b�g�����t�������Ƃ��Ď擾���܂��B  
        ''' </summary>
        ''' <param name="index">�J����Index</param>
        ''' <returns>���l</returns>
        Public Function GetInt64(ByVal index As Integer) As Long
            Return Me._dataReader.GetInt64(index)
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� Decimal �I�u�W�F�N�g�Ƃ��Ď擾���܂��B  
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
        Public Function GetDecimal(ByVal name As String) As Decimal
            Return GetDecimal(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� Decimal �I�u�W�F�N�g�Ƃ��Ď擾���܂��B  
        ''' </summary>
        ''' <param name="index">�J����Index</param>
        ''' <returns>���l</returns>
        Public Function GetDecimal(ByVal index As Integer) As Decimal
            Return Me._dataReader.GetDecimal(index)
        End Function

        ''' <summary>
        ''' �w�肵����̒l��{���x���������_���l�Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
        Public Function GetDouble(ByVal name As String) As Double
            Return GetDouble(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' �w�肵����̒l��{���x���������_���l�Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="index">�J����Index</param>
        ''' <returns>���l</returns>
        Public Function GetDouble(ByVal index As Integer) As Double
            Return Me._dataReader.GetDouble(index)
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� DateTime �I�u�W�F�N�g�Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���t</returns>
        Public Function GetDateTime(ByVal name As String) As DateTime
            Return GetDateTime(GetOrdinal(name))
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� DateTime �I�u�W�F�N�g�Ƃ��Ď擾���܂��B 
        ''' </summary>
        ''' <param name="index">�J����Index</param>
        ''' <returns>���t</returns>
        Public Function GetDateTime(ByVal index As Integer) As DateTime
            Return Me._dataReader.GetDateTime(index)
        End Function

        ''' <summary>
        ''' �f�[�^���擾���܂��yDataSet�^�z
        ''' </summary>
        ''' <returns>DataSet</returns>
        Public Function ExecuteDataSetFill() As DataSet
            '// WriteTraceLog("OracleDataAdapter.Fill(DataSet) �� ���O")
            ' �f�[�^�̎擾
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            Dim da As New SqlDataAdapter(_cmd)
            '@@@Oracle -> SQLServer WebService --end
            Dim ds As New DataSet
            da.Fill(ds)
            da.Dispose()
            da = Nothing
            '// WriteTraceLog("OracleDataAdapter.Fill(DataSet) �� ����")
            '// WriteTraceLog("OracleDataAdapter.Fill(DataSet) �� �擾���� = " & ds.Tables(0).Rows.Count & "��")
            Return ds
        End Function

        ''' <summary>
        ''' �f�[�^���擾���܂��yDataTable�^�z
        ''' </summary>
        ''' <returns>DataTable</returns>
        Public Function ExecuteDataTableFill() As DataTable
            '// WriteTraceLog("OracleDataAdapter.Fill(DataTable) �� ���O")
            ' �f�[�^�̎擾
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            Dim da As New SqlDataAdapter(Me._cmd)
            '@@@Oracle -> SQLServer WebService --end
            Dim dt As New DataTable
            da.Fill(dt)
            da.Dispose()
            da = Nothing
            '// WriteTraceLog("OracleDataAdapter.Fill(DataTable) �� ����")
            '// WriteTraceLog("OracleDataAdapter.Fill(DataTable) �� �擾���� = " & dt.Rows.Count & "��")
            Return dt
        End Function

        ''' <summary>
        ''' �f�[�^�x�[�X����P��̒l (�W�v�l�Ȃ�) �� Oracle �ŗL�̃f�[�^�^�Ŏ擾���܂��B �yString�^�z
        ''' </summary>
        ''' <returns>������</returns>
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
        ''' �f�[�^�x�[�X����P��̒l (�W�v�l�Ȃ�) �� Oracle �ŗL�̃f�[�^�^�Ŏ擾���܂��B �yInteger�^�z
        ''' </summary>
        ''' <returns>���l</returns>
        Public Function ExecuteScalarInt32() As Integer
            Return Convert.ToInt32(_cmd.ExecuteScalar())
        End Function

        ''' <summary>
        ''' �f�[�^�x�[�X����P��̒l (�W�v�l�Ȃ�) �� Oracle �ŗL�̃f�[�^�^�Ŏ擾���܂��B �yLong�^�z
        ''' </summary>
        ''' <returns>���l</returns>
        Public Function ExecuteScalarInt64() As Long
            Return Convert.ToInt64(_cmd.ExecuteScalar())
        End Function

        ''' <summary>
        ''' SQL �� INSERT�ADELETE�AUPDATE�ASET �X�e�[�g�����g�Ȃǂ̃R�}���h�����s���܂��B 
        ''' </summary>
        ''' <returns>�X�V������Ԃ��܂��B</returns>
        Public Function ExecuteNonQuery() As Integer
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            '@@@Oracle -> SQLServer WebService --end
            '// WriteTraceLog("OracleCommand.ExecuteNonQuery() �� ���O")
            Dim ret As Integer = _cmd.ExecuteNonQuery()
            '// WriteTraceLog("OracleCommand.ExecuteNonQuery() �� ����")
            '// WriteTraceLog("OracleCommand.ExecuteNonQuery() �� �X�V���� = " & ret.ToString() & "��")
            Return ret
        End Function

        ''' <summary>
        ''' �X�g�A�h�v���V�[�W���^�X�g�A�h�t�@���N�V�����̌Ăяo��
        ''' </summary>
        Public Sub ExecuteStoredProcedure()
            '@@@Oracle -> SQLServer WebService --start
            CloseDataReader()
            '@@@Oracle -> SQLServer WebService --end
            Me._cmd.CommandType = CommandType.StoredProcedure
            Dim ret As Integer = ExecuteNonQuery()
        End Sub

        ''' <summary>
        ''' �w�肵����̒l�𕶎���Ƃ��Ď擾���܂��B �y�X�g�A�h�p�z
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>������</returns>
        Public Function GetParameterString(ByVal name As String) As String
            Return Me._cmd.Parameters(name).Value.ToString()
        End Function

        ''' <summary>
        ''' �w�肵����̒l�� 32 �r�b�g�����t�������Ƃ��Ď擾���܂��B �y�X�g�A�h�p�z
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
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
        ''' �w�肵����̒l�� 64 �r�b�g�����t�������Ƃ��Ď擾���܂��B  �y�X�g�A�h�p�z
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
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
        ''' �w�肵����̒l�� Decimal �I�u�W�F�N�g�Ƃ��Ď擾���܂��B  �y�X�g�A�h�p�z
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
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
        ''' �w�肵����̒l��{���x���������_���l�Ƃ��Ď擾���܂��B �y�X�g�A�h�p�z
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���l</returns>
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
        ''' �w�肵����̒l�� DateTime �I�u�W�F�N�g�Ƃ��Ď擾���܂��B �y�X�g�A�h�p�z
        ''' </summary>
        ''' <param name="name">��̖��O</param>
        ''' <returns>���t</returns>
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
