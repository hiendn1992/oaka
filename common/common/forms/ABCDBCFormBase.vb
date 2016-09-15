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
Namespace jp.co.ait.common.forms

    ''' <summary>
    ''' ����̫�ъ�ո׽
    ''' </summary>
    Public Class ABCDBCFormBase

#Region "���O�֘A"

        ''' <summary>
        ''' ۸ނ̑��s���ق�Debug�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>۸ނ̑��s���ق��Ⴂ(ture) or ۸ނ̑��s���ق�����(false)</returns>
        Protected Shared Function IsDebug() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelDebug)
        End Function


        ''' <summary>
        ''' ۸ނ̑��s���ق�Trace�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>۸ނ̑��s���ق��Ⴂ(ture) or ۸ނ̑��s���ق�����(false)</returns>
        Protected Shared Function IsTrace() As Boolean
            Return ABCDBCLog.IsLoglevel(ABCDBCLog.LogLevel.LevelTrace)
        End Function


        ''' <summary>
        ''' ۸ނ̑��s���ق�Dump�ȉ��ł��邩���肵�܂��B
        ''' </summary>
        ''' <returns>۸ނ̑��s���ق��Ⴂ(ture) or ۸ނ̑��s���ق�����(false)</returns>
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
        ''' �I��۸ނ��o�͂��܂��B
        ''' </summary>
        Protected Shared Sub WriteEndLog()
            WriteLog(ABCDBCLog.LogLevel.LevelOperation, "�I��")
        End Sub


        ''' <summary>
        ''' ���ޯ��۸ނ��o�͂��܂��B
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
        ''' ܰ�ݸ�۸ނ��o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Sub WriteWarning(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelWarning, str)
        End Sub


        ''' <summary>
        ''' �װ۸ނ��o�͂��܂��B
        ''' </summary>
        ''' <param name="str">�o�͕�����</param>
        Protected Shared Sub WriteErrorLog(ByVal str As String)
            WriteLog(ABCDBCLog.LogLevel.LevelError, str)
        End Sub


        ''' <summary>
        ''' �װ۸ނ��o�͂��܂��B
        ''' </summary>
        ''' <param name="ex">�װ���</param>
        Protected Shared Sub WriteErrorLog(ByVal ex As Exception)
            WriteLog(ABCDBCLog.LogLevel.LevelError, ex.ToString)
        End Sub


        ''' <summary>
        ''' ۸ޏo�͏��ݒ�
        ''' </summary>
        ''' <param name="level">۸�����</param>
        ''' <param name="msg">�o�͕�����</param>
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

#Region "�ėp�֐�"

        ''' <summary>
        ''' ۸޲݂̗L�����m�F���܂��B
        ''' </summary>
        ''' <returns>True:۸޲ݒ��@False:��۸޲�</returns>
        Private Shared Function IsLogin() As Boolean
            Return ABCDBCLoginManager.IsLogin()
        End Function

        ''' <summary>
        ''' ۸޲ݏ����擾���܂��B
        ''' </summary>
        ''' <returns>۸޲ݏ��B�������A��۸޲ݎ���Nothing��Ԃ��܂��B</returns>
        Private Shared Function GetLoginInfo() As ABCDBCLoginInfo
            Return ABCDBCLoginManager.GetLoginInfo()
        End Function

#End Region

    End Class
End Namespace