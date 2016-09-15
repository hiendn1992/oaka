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

Imports System.IO
Imports System.Text
Imports System.Xml

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' ���O�N���X
    ''' </summary>
    Public Class ABCDWebLog

#Region "���[�U�錾"

        '''' <summary>��`�t�@�C���Ŏw�肳��Ă���log�t�@�C�����̊�</summary>
        'Private _logFileName As String
        '''' <summary>��`�t�@�C���Ŏw�肳��Ă���log�t�@�C���̃p�X</summary>
        'Private _logFileDir As String
        '''' <summary>��`�t�@�C���Ŏw�肳��Ă��郍�O���x��</summary>
        'Private _logLevel As LogLevel

#End Region

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
        Public Sub WriteLog(ByVal level As LogLevel, _
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

            Dim logInfo As String = Nothing

            Select Case level

                Case LogLevel.LevelDump
                    ' ���(�_���v)
                    logInfo = ABCDWebConst.LOG_LEVEL_DUMP
                Case LogLevel.LevelDebug
                    ' ���(�f�o�b�O)     
                    logInfo = ABCDWebConst.LOG_LEVEL_DEBUG
                Case LogLevel.LevelInformation
                    ' ���(����)
                    logInfo = ABCDWebConst.LOG_LEVEL_INFOMATION
                Case LogLevel.LevelTrace
                    ' ����/���(SQL)
                    logInfo = ABCDWebConst.LOG_LEVEL_TRACE
                Case LogLevel.LevelOperation
                    ' �J�n/�I��
                    logInfo = ABCDWebConst.LOG_LEVEL_OPERATION
                Case LogLevel.LevelWarning
                    ' �x��
                    logInfo = ABCDWebConst.LOG_LEVEL_WARNING
                Case LogLevel.LevelError
                    ' �G���[
                    logInfo = ABCDWebConst.LOG_LEVEL_ERROR
            End Select

            ' ���O�o��
            WriteLogStrings(logInfo, userID, clsName, mtdName, screenId, msg)
        End Sub

        ''' <summary>
        ''' ���O�o��
        ''' </summary>
        ''' <param name="level">���O���x��</param>
        ''' <param name="msg">���b�Z�[�W</param>
        ''' <param name="clsName">�N���X��</param>
        ''' <param name="mtdName">���\�b�h��</param>
        ''' <param name="screenId">���ID</param>
        Public Sub WriteLog(ByVal level As LogLevel, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String, _
                                   ByVal msg As String, _
                                   ByVal exfileName As String)

            If level = 0 Then
                Throw New ArgumentException("�������s���ł��Blevel=" & level.ToString, "level")
            End If

            ' ���O���x������
            If IsLoglevel(level) = False Then
                Return
            End If

            Dim logInfo As String = Nothing

            Select Case level

                Case LogLevel.LevelDump
                    ' ���(�_���v)
                    logInfo = ABCDWebConst.LOG_LEVEL_DUMP
                Case LogLevel.LevelDebug
                    ' ���(�f�o�b�O)     
                    logInfo = ABCDWebConst.LOG_LEVEL_DEBUG
                Case LogLevel.LevelInformation
                    ' ���(����)
                    logInfo = ABCDWebConst.LOG_LEVEL_INFOMATION
                Case LogLevel.LevelTrace
                    ' ����/���(SQL)
                    logInfo = ABCDWebConst.LOG_LEVEL_TRACE
                Case LogLevel.LevelOperation
                    ' �J�n/�I��
                    logInfo = ABCDWebConst.LOG_LEVEL_OPERATION
                Case LogLevel.LevelWarning
                    ' �x��
                    logInfo = ABCDWebConst.LOG_LEVEL_WARNING
                Case LogLevel.LevelError
                    ' �G���[
                    logInfo = ABCDWebConst.LOG_LEVEL_ERROR
            End Select

            ' ���O�o��
            WriteLogStrings(logInfo, userID, clsName, mtdName, screenId, msg, exfileName)

        End Sub

        ''' <summary>
        '''  �G���[���O�o��
        ''' </summary>
        ''' <param name="ex">�G���[���</param>
        ''' <param name="userID">���[�U�[ID</param>
        ''' <param name="clsName">�N���X��</param>
        ''' <param name="mtdName">���\�b�h��</param>
        ''' <param name="screenId">���ID</param>
        Public Sub WriteLog(ByVal ex As Exception, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String)

            If ex Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��Bex=nothing")
            End If
            WriteLogStrings(ABCDWebConst.LOG_LEVEL_ERROR, userID, clsName, mtdName, screenId, ex.ToString)
        End Sub

        ''' <summary>
        ''' �G���[���O�o��
        ''' </summary>
        ''' <param name="ex">�G���[���</param>
        ''' <param name="userID">���[�U�[ID</param>
        ''' <param name="clsName">�N���X��</param>
        ''' <param name="mtdName">���\�b�h��</param>
        ''' <param name="screenId">���ID</param>
        ''' <param name="exfileName">�g�����O�t�@�C������</param>
        Public Sub WriteLog(ByVal ex As Exception, _
                                   ByVal userID As String, _
                                   ByVal clsName As String, _
                                   ByVal mtdName As String, _
                                   ByVal screenId As String, _
                                   ByVal exfileName As String)

            If ex Is Nothing Then
                Throw New ArgumentNullException("�������s���ł��Bex=nothing")
            End If
            WriteLogStrings(ABCDWebConst.LOG_LEVEL_ERROR, userID, clsName, mtdName, screenId, ex.ToString, exfileName)
        End Sub

        ''' <summary>
        ''' ���O���x���̎擾
        ''' </summary>
        ''' <returns>���O���x��</returns>
        Public Function GetLoglevel() As ABCDWebLog.LogLevel
            Dim logLevel As LogLevel

            Dim level As String = GetFileData("LOG/LOG_LEVEL").ToString
            Select Case level
                ' ���(�_���v)
                Case "1"
                    logLevel = logLevel.LevelDump
                    ' ���(�f�o�b�O)                     
                Case "2"
                    logLevel = logLevel.LevelDebug
                    ' ���(����)
                Case "3"
                    logLevel = logLevel.LevelInformation
                    ' ����/���(SQL)
                Case "4"
                    logLevel = logLevel.LevelTrace
                    ' �J�n/�I��
                Case "5"
                    logLevel = logLevel.LevelOperation
                    ' �x��
                Case "6"
                    logLevel = logLevel.LevelWarning
                    ' �G���[
                Case "7"
                    logLevel = logLevel.LevelError
                    ' ��L�ȊO
                Case Else
                    Throw New ApplicationException("���O���x����`���s���ł�[1�`7�̂ݗL��]�B���O���x����`=" & logLevel)
            End Select

            Return logLevel

        End Function

        ''' <summary>
        ''' ���O���x���̔���
        ''' </summary>
        ''' <param name="level">���O���x��</param>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Public Function IsLoglevel(ByVal level As LogLevel) As Boolean
            If level = 0 Then
                Throw New ArgumentException("�������s���ł��Blevel=" & level.ToString, "level")
            End If

            If GetLoglevel() <= level Then
                Return True
            Else
                Return False
            End If
        End Function

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
        Private Sub WriteLogStrings(ByVal level As String, _
                                           ByVal userID As String, _
                                           ByVal clsName As String, _
                                           ByVal mtdName As String, _
                                           ByVal screenId As String, _
                                           ByVal msg As String, _
                                           Optional ByVal exfileName As String = "")


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

            Dim strLog(4) As String
            strLog(0) = level
            strLog(1) = userID
            strLog(2) = clsName
            strLog(3) = mtdName
            strLog(4) = msg

            Dim str As String = String.Join(", ", strLog)

            ' ���O�t�@�C����������
            WriteLog(str, exfileName)
        End Sub

        ''' <summary>
        ''' ���O�t�@�C����������
        ''' </summary>
        ''' <param name="msg">������</param>
        Private Sub WriteLog(ByVal msg As String, Optional ByVal exfileName As String = "")
            Dim time As Date = Now

            Dim logFileName As String
            Dim logFileDir As String

            logFileName = GetFileData("LOG/FILE_NAME")
            ' FILE_NAME���擾�ł��Ȃ��ꍇ
            If String.IsNullOrEmpty(logFileName) Then
                Throw New ApplicationException("���O�t�@�C�������擾�ł��܂���ł����B���O�t�@�C����=Nothing")
            End If

            If Not String.IsNullOrEmpty(exfileName) Then
                logFileName &= "_" & exfileName
            End If

            logFileDir = GetFileData("LOG/FILE_DIR")
            If String.IsNullOrEmpty(logFileDir) Then
                Throw New ApplicationException("���O�t�@�C���̃p�X��`���s���ł��B���O�t�@�C���̃p�X=Nothing")
            End If

            Dim newLogFileName As String = logFileName & "_" & time.ToString("yyyyMMdd") & ".log" 'log�t�@�C����

            ' �t�H���_�쐬
            If File.Exists(logFileDir & newLogFileName) = False Then
                Directory.CreateDirectory(logFileDir)
            End If

            Dim log As String = time.ToString("yyyy/MM/dd HH:mm:ss fff")                        '�o�͓����̎擾

            ' ������쐬
            log += ", " & msg

            ' log�t�@�C���������ݏ���
            Dim sw As StreamWriter = Nothing
            Try

                ' �t�@�C���֏o��
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
        ''' �\���t�@�C�������擾
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>�擾���</returns>
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
