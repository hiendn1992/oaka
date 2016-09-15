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

Imports System.Diagnostics

Namespace jp.co.ait.common

    ''' <summary>
    ''' BWS���ʊ֐����N���X
    ''' </summary>
    Public Class ABCDBCBase
        Private Shared _dir As String

#Region "���O�֘A"


        ''' <summary>
        ''' ���O�̑��s���x����Debug�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Protected Shared Function IsDebug() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelDebug)
        End Function


        ''' <summary>
        ''' ���O�̑��s���x����Trace�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Protected Shared Function IsTrace() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelTrace)
        End Function


        ''' <summary>
        ''' ���O�̑��s���x����Dump�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>���O�̑��s���x�����Ⴂ(ture) or ���O�̑��s���x��������(false)</returns>
        Protected Shared Function IsDump() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelDump)
        End Function


        ''' <summary>
        ''' �J�n���O���o�͂��܂��B
        ''' </summary>
        Protected Shared Sub WriteStartLog()
            WriteLog(ABCDBCLog.LogLevel.LevelOperation, "�J�n")
        End Sub


        ''' <summary>
        ''' �I�����O���o�͂��܂��B
        ''' </summary>
        Protected Shared Sub WriteEndLog()
            WriteLog(ABCDBCLog.LogLevel.LevelOperation, "�I��")
        End Sub


        ''' <summary>
        ''' �f�o�b�O���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Shared Sub WriteDebugLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelDebug, str)
        End Sub


        ''' <summary>
        ''' �g���[�X���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Shared Sub WriteTraceLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelTrace, str)
        End Sub


        ''' <summary>
        ''' ���[�j���O���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Sub WriteWarning(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelWarning, str)
        End Sub


        ''' <summary>
        ''' �G���[���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Shared Sub WriteErrorLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelError, str)
        End Sub


        ''' <summary>
        ''' �G���[���O���o�͂��܂��B
        ''' </summary>
        ''' <param name="ex">�G���[���</param>
        Protected Shared Sub WriteErrorLog(ByVal ex As Exception)
            WriteLog(ABCDBCLog.LogLevel.LevelError, ex.ToString)
        End Sub


        ''' <summary>
        ''' ���O�o�͏��ݒ�
        ''' </summary>
        ''' <param name="level">���O���x��</param>
        ''' <param name="msg">�o�͕�����</param>
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


#Region "�ėp�֐�"


        '''' <summary>
        '''' �J�����g�t�H���_�p�X�擾
        '''' </summary>
        '''' <returns>�J�����g�t�H���_�p�X</returns>
        'Protected Shared Function GetCurrentDir() As String
        '    If _dir Is Nothing Then
        '        _dir = My.Computer.FileSystem.CurrentDirectory & "\"
        '    End If
        '    Return _dir
        'End Function


        ''' <summary>
        ''' ���O�C���̗L�����m�F���܂��B
        ''' </summary>
        ''' <returns>True:���O�C�����@False:�񃍃O�C��</returns>
        Private Shared Function IsLogin() As Boolean
            Return ABCDBCLoginManager.IsLogin()
        End Function

        ''' <summary>
        ''' ���O�C�������擾���܂��B
        ''' </summary>
        ''' <returns>���O�C�����B�������A�񃍃O�C������Nothing��Ԃ��܂��B</returns>
        Private Shared Function GetLoginInfo() As ABCDBCLoginInfo
            Return ABCDBCLoginManager.GetLoginInfo()
        End Function

        ''' <summary>
        ''' ���b�Z�[�W�̎擾
        ''' </summary>
        ''' <param name="msgID">���b�Z�[�WID</param>
        ''' <param name="param">�u����������e�z��</param>
        ''' <returns>���b�Z�[�W���e</returns>
        Private Shared Function GetMessage(ByVal msgID As String, Optional ByVal param() As String = Nothing) As String
            Return ABCDBCMessage.GetMessage(msgID, param)
        End Function

        ''' <summary>
        ''' ���b�Z�[�W�t�H�[����\��
        ''' </summary>
        ''' <param name="msgID">���b�Z�[�WID</param>
        ''' <param name="warnningFlag">�u����������e�z��</param>
        ''' <param name="param">�u����������e�z��</param>
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
        ''' �V�X�e���G���[���G���[�t�H�[���ɕ\������
        ''' </summary>
        Protected Shared Sub ShowSystemMessageForm()
            ShowMessageForm("BC902", "�V�X�e���G���[")
        End Sub

#End Region

    End Class
End Namespace
