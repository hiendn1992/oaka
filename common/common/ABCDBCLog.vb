''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* �V�X�e�����FABCDCommon
''* �N���X��  �F
''* �����T�v  �F
''*********************************************************
''* �����F
''* NO   ���t   Ver  �X�V��          ���e
#Region "�F���C������"
''* 1 14/12/15 1.00  AIT)cuongnc     New
#End Region
''*********************************************************
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Reflection

Namespace jp.co.ait.common

    ''' <summary>
    ''' ���O�N���X
    ''' </summary>
    Public Class ABCDBCLog

        ''' <summary>��`�t�@�C���Ŏw�肳��Ă���log�t�@�C�����̊�</summary>
        Private Shared _LogFileName As String
        ''' <summary>��`�t�@�C���Ŏw�肳��Ă���log�t�@�C���̃p�X</summary>
        Private Shared _LogFileDir As String
        ''' <summary>��`�t�@�C���Ŏw�肳��Ă��郍�O���x��</summary>
        Private Shared _LogLevel As LogLevel


#Region "�񋓗�"
        ''' <summary>
        ''' ���O���x����`��
        ''' </summary>

        Public Enum LogLevel
            '''<summary>���(�_���v)</summary>
            LevelDump = 1
            '''<summary>���(�f�o�b�O)</summary>
            LevelDebug
            '''<summary>���(����)</summary>
            LevelInformation
            '''<summary>����/���(SQL)</summary>
            LevelTrace
            '''<summary>�J�n/�I��</summary>
            LevelOperation
            '''<summary>�x��</summary>
            LevelWarning
            '''<summary>�G���[</summary>
            LevelError

        End Enum
#End Region


#Region "���J���\�b�h"


        ''' <summary>
        ''' ���O�o��
        ''' </summary>
        ''' <param name="level">���O���x��</param>
        ''' <param name="msg">���b�Z�[�W</param>
        ''' <param name="clsName">�N���X��</param>
        ''' <param name="mtdName">���\�b�h��</param>
        ''' <param name="screenId">���ID</param>
        Public Shared Sub WriteLog(ByVal level As LogLevel, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String, _
                                   ByVal msg As String)

            If level = 0 Then
                Throw New ArgumentException("�������s���ł��Blevel=" & level.ToString, "level")
            End If

            ' ���O���x������
            If IsLoglevel(level) = False Then
                Return
            End If

            Dim strLogInfo As String = Nothing

            Select Case level

                Case LogLevel.LevelDump
                    ' ���(�_���v)
                    strLogInfo = ABCDBCConst.LOG_LEVEL_DUMP
                Case LogLevel.LevelDebug
                    ' ���(�f�o�b�O)     
                    strLogInfo = ABCDBCConst.LOG_LEVEL_DEBUG
                Case LogLevel.LevelInformation
                    ' ���(����)
                    strLogInfo = ABCDBCConst.LOG_LEVEL_INFOMATION
                Case LogLevel.LevelTrace
                    ' ����/���(SQL)
                    strLogInfo = ABCDBCConst.LOG_LEVEL_TRACE
                Case LogLevel.LevelOperation
                    ' �J�n/�I��
                    strLogInfo = ABCDBCConst.LOG_LEVEL_OPERATION
                Case LogLevel.LevelWarning
                    ' �x��
                    strLogInfo = ABCDBCConst.LOG_LEVEL_WARNING
                Case LogLevel.LevelError
                    ' �G���[
                    strLogInfo = ABCDBCConst.LOG_LEVEL_ERROR
            End Select

            ' ���O�o��
            WriteLogStrings(strLogInfo, userID, clsName, mtdName, screenId, msg)


        End Sub


        ''' <summary>
        ''' �G���[���O�o��
        ''' </summary>
        ''' <param name="ex">�G���[���</param>
        ''' <param name="userID">���[�U�[ID</param>
        ''' <param name="clsName">�N���X��</param>
        ''' <param name="mtdName">���\�b�h��</param>
        ''' <param name="screenId">���ID</param>
        Public Shared Sub WriteLog(ByVal ex As Exception, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String)

            If ex Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��Bex=nothing")
            End If
            WriteLogStrings(ABCDBCConst.LOG_LEVEL_ERROR, userID, clsName, mtdName, screenId, ex.ToString)
        End Sub


        ''' <summary>
        ''' ���O���x���̎擾
        ''' </summary>
        ''' <returns>���O���x��</returns>
        Public Shared Function GetLoglevel() As ABCDBCLog.LogLevel

            If _LogLevel = 0 Then
                Dim level As String = GetFileData("BC_LOG/LOG_LEVEL").ToString
                Select Case level
                    ' ���(�_���v)
                    Case "1"
                        _LogLevel = LogLevel.LevelDump
                        ' ���(�f�o�b�O)                     
                    Case "2"
                        _LogLevel = LogLevel.LevelDebug
                        ' ���(����)
                    Case "3"
                        _LogLevel = LogLevel.LevelInformation
                        ' ����/���(SQL)
                    Case "4"
                        _LogLevel = LogLevel.LevelTrace
                        ' �J�n/�I��
                    Case "5"
                        _LogLevel = LogLevel.LevelOperation
                        ' �x��
                    Case "6"
                        _LogLevel = LogLevel.LevelWarning
                        ' �G���[
                    Case "7"
                        _LogLevel = LogLevel.LevelError
                        ' ��L�ȊO
                    Case Else
                        Throw New ApplicationException("���O���x����`���s���ł�[1�`7�̂ݗL��]�B���O���x����`=" & _LogLevel)
                End Select
            End If
            Return _LogLevel

        End Function

        ''' <summary>
        ''' ���O���x���̔���
        ''' </summary>
        ''' <param name="level">���O���x��</param>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Public Shared Function IsLoglevel(ByVal level As LogLevel) As Boolean
            If level = 0 Then
                Throw New ArgumentException("�������s���ł��Blevel=" & level.ToString, "level")
            End If


            If GetLoglevel() <= level Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' �\���t�@�C�������擾
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>�擾���</returns>
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
        ''' ���O�t�@�C������ݒ�
        ''' </summary>
        ''' <value></value>
        Public Shared WriteOnly Property SetLogFileName() As String
            Set(ByVal value As String)
                _LogFileName = value
            End Set
        End Property

#End Region

#Region "�������\�b�h"

        ''' <summary>
        ''' ���O������쐬
        ''' </summary>
        ''' <param name="level">���O���x��</param>
        ''' <param name="userID">���[�U�[ID</param>
        ''' <param name="clsName">�N���X��</param>
        ''' <param name="mtdName">���\�b�h��</param>
        ''' <param name="screenId">���ID</param>
        ''' <param name="msg">���b�Z�[�W</param>
        Private Shared Sub WriteLogStrings(ByVal level As String, _
                                           ByVal userID As String, _
                                           ByVal clsName As String, _
                                           ByVal mtdName As String, _
                                           ByVal screenId As String, _
                                           ByVal msg As String)


            If userID Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��BuserID=Nothing", "userID")
            End If

            If clsName Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��BclsName=Nothing", "clsName")
            End If

            If mtdName Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��BmtdName=Nothing", "mtdName")
            End If

            If screenId Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��BscreenId=Nothing", "screenId")
            End If

            If msg Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��Bmsg=Nothing", "msg")
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

            ' ���O�t�@�C����������
            WriteLog(str)
        End Sub


        ''' <summary>
        ''' ���O�t�@�C����������
        ''' </summary>
        ''' <param name="msg">������</param>
        Private Shared Sub WriteLog(ByVal msg As String)
            Dim time As Date = Now

            If _LogFileName Is Nothing Then
                _LogFileName = GetFileData("BC_LOG/FILE_NAME")
                'FILE_NAME���擾�ł��Ȃ��ꍇ
                If _LogFileName Is Nothing OrElse _LogFileName Is String.Empty Then
                    Throw New ApplicationException("���O�t�@�C�������擾�ł��܂���ł����B���O�t�@�C����=Nothing")
                End If
            End If

            If _LogFileDir Is Nothing Then
                _LogFileDir = GetFileData("BC_LOG/FILE_DIR")
                If _LogFileDir Is Nothing Then
                    Throw New ApplicationException("���O�t�@�C���̃p�X��`���s���ł��B���O�t�@�C���̃p�X=Nothing")
                End If
            End If

            If _LogFileDir.Length = 0 Then
                _LogFileDir = ABCDBCCommon.GetCurrentDir()
            End If

            Dim newLogFileName As String = _LogFileName & time.ToString("yyyyMMdd") & ".log" 'log�t�@�C����

            ''�t�H���_�쐬
            If File.Exists(_LogFileDir & newLogFileName) = False Then
                Directory.CreateDirectory(_LogFileDir)
            End If

            Dim log As String = time.ToString("yyyy/MM/dd HH:mm:ss fff")                        '�o�͓����̎擾

            '������쐬
            log += ", " & msg

            'log�t�@�C���������ݏ���
            Dim sw As StreamWriter = Nothing
            Try

                '' �t�@�C���֏o��
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
