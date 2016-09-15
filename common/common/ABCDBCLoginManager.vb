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

    ''' <summary>
    ''' ���O�C�����N���X
    ''' </summary>
    Public Class ABCDBCLoginManager
        Inherits ABCDBCBase

        ''' <summary>���O�C�����</summary>
        Private Shared _LoginInfo As ABCDBCLoginInfo

        ''' <summary>
        ''' ���O�C�����
        ''' </summary>
        ''' <returns>True�F���O�C���ς݁@False�F�����O�C��</returns>
        Public Shared Function IsLogin() As Boolean
            If _LoginInfo Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' ���O�C�����̎擾
        ''' </summary>
        ''' <returns>���O�C�����</returns>
        Public Shared Function GetLoginInfo() As ABCDBCLoginInfo
            Return _LoginInfo
        End Function

        ''' <summary>
        ''' ���O�C�����N���X�̍쐬
        ''' </summary>
        ''' <param name="UserID">�o�^�������[�UID</param>
        ''' <returns>���O�C�����N���X�C���X�^���X</returns>
        Public Shared Function CreateLoginInfo(ByVal UserID As String) As ABCDBCLoginInfo
            If _LoginInfo Is Nothing Then
                _LoginInfo = New ABCDBCLoginInfo(UserID)
            Else
                If UserID.Equals(String.Empty) Then
                    _LoginInfo = Nothing
                    _LoginInfo = New ABCDBCLoginInfo(UserID)
                End If
                _LoginInfo.UserID = UserID
            End If
            Return _LoginInfo
        End Function
    End Class

End Namespace
