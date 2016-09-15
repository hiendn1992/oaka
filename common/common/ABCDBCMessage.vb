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
Namespace jp.co.ait.common
    Public Class ABCDBCMessage

#Region "���[�U��`�֐�"

        ''' <summary>
        ''' ү���ޏ����擾���܂�
        ''' </summary>
        ''' <param name="msgId">ү����ID</param>
        ''' <returns>ү���� ���݂��Ȃ��ꍇ:Nothing</returns>
        Public Shared Function GetMessage(ByVal msgId As String) As String
            Return GetMessage(msgId, New String() {})
        End Function

        ''' <summary>
        ''' ү���ޏ����擾���܂�
        ''' </summary>
        ''' <param name="msgId">ү����ID</param>
        ''' <param name="param">�t������</param>
        ''' <returns>ү���� ���݂��Ȃ��ꍇ:Nothing</returns>
        Public Shared Function GetMessage(ByVal msgId As String, ByVal param() As String) As String

            Dim ret As String = String.Empty

            ' xml�ǂݍ���
            Dim xmlMsgFile As String = ABCDBCXmlManager.GetFileData("BC_MSG/FILE_NAME")
            Dim xmlMsgDir As String = ABCDBCXmlManager.GetFileData("BC_MSG/FILE_DIR")

            If xmlMsgDir.Length = 0 Then
                xmlMsgDir = ABCDBCCommon.GetCurrentDir()
            End If

            'XMĻ�ق�ǂݍ���
            Dim message As String = ABCDBCXmlManager.GetFileData(xmlMsgDir & xmlMsgFile, "type/module/message[@id='" + msgId + "']")

            If IsNothing(param) OrElse param.Length = 0 Then
                ret = message
            Else
                ret = String.Format(message, param)
            End If

            Return ret

        End Function

#End Region

    End Class

End Namespace
