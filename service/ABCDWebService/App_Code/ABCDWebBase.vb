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
Imports System.Diagnostics
Imports System.Xml

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' BWS���ʊ֐����N���X
    ''' </summary>
    Public Class ABCDWebBase

        Private _userId As String

#Region "���O�֘A"

        ''' <summary>
        ''' ���O�̑��s���x����Debug�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Protected Function IsDebug() As Boolean
            Dim log As New ABCDWebLog
            Return log.IsLoglevel(ABCDWebLog.LogLevel.LevelDebug)
        End Function

        ''' <summary>
        ''' ���O�̑��s���x����Trace�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Protected Function IsTrace() As Boolean
            Dim log As New ABCDWebLog
            Return log.IsLoglevel(ABCDWebLog.LogLevel.LevelTrace)
        End Function

        ''' <summary>
        ''' ���O�̑��s���x����Dump�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Protected Function IsDump() As Boolean
            Dim log As New ABCDWebLog
            Return log.IsLoglevel(ABCDWebLog.LogLevel.LevelDump)
        End Function

        ''' <summary>
        ''' �J�n���O���o�͂��܂��B
        ''' </summary>
        Protected Sub WriteStartLog()
            WriteLog(ABCDWebLog.LogLevel.LevelOperation, "�J�n")
        End Sub

        ''' <summary>
        ''' �I�����O���o�͂��܂��B
        ''' </summary>
        Protected Sub WriteEndLog()
            WriteLog(ABCDWebLog.LogLevel.LevelOperation, "�I��")
        End Sub

        ''' <summary>
        ''' �f�o�b�O���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Sub WriteDebugLog(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelDebug, str)
        End Sub

        ''' <summary>
        ''' �g���[�X���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Sub WriteTraceLog(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelTrace, str)
        End Sub

        ''' <summary>
        ''' ���[�j���O���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Sub WriteWarning(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelWarning, str)
        End Sub

        ''' <summary>
        ''' �G���[���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Sub WriteErrorLog(ByVal str As String)
            WriteLog(ABCDWebLog.LogLevel.LevelError, str)
        End Sub

        ''' <summary>
        ''' �G���[���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="ex">�G���[���</param>
        Protected Sub WriteErrorLog(ByVal ex As Exception)
            WriteLog(ABCDWebLog.LogLevel.LevelError, ex.ToString)
        End Sub

        ''' <summary>
        ''' ���O�o�͏��ݒ�
        ''' </summary>
        ''' <param name="level">���O���x��</param>
        ''' <param name="msg">�o�͕�����</param>
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

#Region "�ėp�֐�"

        ''' <summary>
        ''' XMĻ���߽�擾
        ''' </summary>
        ''' <returns>�J�����g�t�H���_�p�X</returns>
        Protected Function GetXMLDir() As String
            '_dir = My.Computer.FileSystem.CurrentDirectory & "\"
            Return System.Configuration.ConfigurationManager.AppSettings("XML_FILE_DIR") & "\"
        End Function

        ''' <summary>
        ''' ���O�C���̗L�����m�F���܂��B
        ''' </summary>
        ''' <returns>True:���O�C�����@False:�񃍃O�C��</returns>
        Private Function IsLogin() As Boolean
            If String.IsNullOrEmpty(Me._userId) Then
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' ۸�̧���߽���擾���܂�
        ''' </summary>
        Protected Function GetLogFileDir() As String
            Dim logFileDir As String = GetFileData("LOG/FILE_DIR")
            ' FILE_PATH���擾�ł��Ȃ��ꍇ
            If logFileDir Is Nothing OrElse logFileDir Is String.Empty Then
                Throw New ApplicationException("���O�t�@�C���̃p�X��`���s���ł��B���O�t�@�C���̃p�X=Nothing")
            End If

            Return logFileDir

        End Function

        ''' <summary>
        ''' ۸�̧�ٖ����擾���܂�
        ''' </summary>
        Protected Function GetLogFileName() As String
            Dim logFileName As String = GetFileData("LOG/FILE_NAME")
            ' FILE_NAME���擾�ł��Ȃ��ꍇ
            If logFileName Is Nothing OrElse logFileName Is String.Empty Then
                Throw New ApplicationException("���O�t�@�C�������擾�ł��܂���ł����B���O�t�@�C����=Nothing")
            End If
            Return logFileName
        End Function

        ''' <summary>
        ''' �\���t�@�C�������擾
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>�擾���</returns>
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
        ''' հ��ID�̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>հ��ID�̐ݒ�l</value>
        ''' <returns>հ��ID�̖߂�l</returns>
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
