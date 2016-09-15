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
    Public Class ABCDBCLoginInfo

        ''' <summary>���O�C�����[�UID</summary>
        Private _userID As String = String.Empty

        ''' <summary>���O�C�����[�U����</summary>
        Private _userName As String = String.Empty

        '' <summary>���O�C���q�ɺ���</summary>
        'Private _sokoCD As String = String.Empty

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        Public Sub New()
            Me._userID = String.Empty
            Me._userName = String.Empty

            'Me._sokoCD = ABCDBCXmlManager.GetFileData("SOKO_CD/JISOKO_CD")
        End Sub

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <param name="userID">���O�C�����[�UID</param>
        Public Sub New(ByVal userID As String)
            Me.New()
            Me._userID = userID
        End Sub

        ''' <summary>
        ''' ���O�C�����[�UID�̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>���O�C�����[�UID�̐ݒ�l</value>
        ''' <returns>���O�C�����[�UID�̖߂�l</returns>
        Public Property UserID() As String
            Get
                Return Me._userID
            End Get
            Set(ByVal value As String)
                Me._userID = value
            End Set
        End Property

        ''' <summary>
        ''' ���O�C�����[�U���̂̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>���O�C�����[�U���̂̐ݒ�l</value>
        ''' <returns>���O�C�����[�U���̖̂߂�l</returns>
        Public Property UserName() As String
            Get
                Return Me._userName
            End Get
            Set(ByVal value As String)
                Me._userName = value
            End Set
        End Property

        '' <summary>
        '' ���O�C���q�ɺ��ނ̐ݒ�Ǝ擾
        '' </summary>
        '' <returns>���O�C���q�ɺ��ނ̖߂�l</returns>
        'Public ReadOnly Property SokoCD() As String
        '   Get
        '      Return Me._sokoCD
        '   End Get
        ' End Property

    End Class
End Namespace
