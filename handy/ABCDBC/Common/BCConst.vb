''*********************************************************************
''* �V�X�e�����F�Ȗ؃��P�[�V�����V�X�e��
''* �N���X��  �F���ʒ萔�N���X
''* �����T�v  �F���ʒ萔�N���X
#Region "�F���C������"
''* 1  2008/01/11 1.00 NCS)CHEN        ����
#End Region
''* 1  2011/01/25 1.00 NCS)NISHIYAMA   �@�ϑ������폜
''*                                    �A����`�ԋ敪�F�����d���ǉ�
''*                                    �B�p�~��ʒ萔�폜
''*********************************************************************

Namespace common

    ''' <summary>
    ''' �萔�N���X
    ''' </summary>
    Public Class BCConst

#Region "���ʒ萔"

        ''' <summary>�������͉�ʂƉp�����͉�ʂɒS���҃R�[�h�̌���</summary>
        Public Const SET_INPUT_MAXLENGTH As Integer = 8

        ''' <summary>����F�^�C��</summary>
        Public Const UCHIWAKE_TIRE As String = "3"

        ''' <summary>���v��F�q�d�o</summary>
        Public Const JUYOSAKI_REP As String = "1"

        ''' <summary>���v��F�n�d</summary>
        Public Const JUYOSAKI_OE As String = "3"

        ''' <summary>���v��F�d�w�o</summary>
        Public Const JUYOSAKI_EXP As String = "5"

        ''' <summary>
        ''' �s�b�L���O��ƒP�ʋ敪
        ''' </summary>
        Public Enum SAGYO_TANI_KUBUN
            ''' <summary>���ԒP��</summary>
            GOSHA_UNIT = 0

            ''' <summary>���P��</summary>
            DAY_UNIT = 1
        End Enum

        ''' <summary>
        ''' �s�b�L���O��Ǝ�ʋ敪
        ''' </summary>
        Public Enum SAGYO_SHUBETSU_KUBUN
            ''' <summary>�o�[�X</summary>
            BERTH = 0

            ''' <summary>�ꏊ</summary>
            BASHO = 1
        End Enum

        ''' <summary>
        ''' �s�b�L���O��ƌ`�ԋ敪
        ''' </summary>
        Public Enum SAGYO_KEITAI_KUBUN
            ''' <summary>���</summary>
            NORMAL = 0

            ''' <summary>�c�q(���)</summary>
            EISO_PLT = 1

            ''' <summary>�c�q(���)</summary>
            EISO_BARA = 2

            ''' <summary>����</summary>
            KOGUCHI = 3

            ''' <summary>�`�t�P��</summary>
            TF_TANTAI = 4

            ''' <summary>�q��</summary>
            KURANAKA = 5

            ''' <summary>�`�t�q��</summary>
            KURANAKA_TF = 6

            ''' <summary>���b�s���O</summary>
            WRAPPING = 7

            ''' <summary>�`�t���b�s���O</summary>
            WRAPPING_TF = 8

        End Enum

        ''' <summary>
        ''' ��Ǝ��уt���O
        ''' </summary>
        Public Enum SAGYO_JISSEKI_FLG
            ''' <summary>�s�b�L���O���X�g�擾</summary>
            PIKKING_LIST = 0

            ''' <summary>��Ǝ���</summary>
            JISSEKI = 1

            ''' <summary>��ƒ��f</summary>
            SAGYO_CHUDAN = 2

            ''' <summary>��ƑS����</summary>
            SAGYO_END = 3
        End Enum

        ''' <summary>
        ''' �s�b�L���O�t���O
        ''' </summary>
        Public Enum PIKKING_FLG
            ''' <summary>�s�b�L���O���X�g�擾</summary>
            PIKKING_LIST = 1

            ''' <summary>���̑�</summary>
            OTHER = 0
        End Enum

        ''' <summary>
        ''' ����^����t���O
        ''' </summary>
        Public Enum CHOKU_HEI_RETSU_FLG
            ''' <summary>����</summary>
            CHOKURETSU = 0

            ''' <summary>�z��</summary>
            HEIRETSU = 1
        End Enum

        ''' <summary>
        ''' ����Ɩ��敪
        ''' </summary>
        Public Enum UKEIRE_GYOMU_KUBUN
            ''' <summary>����</summary>
            SEIZO = 0
            ''' <summary>�ڑ�</summary>
            ISO = 1
        End Enum

        ''' <summary>
        ''' ����`�ԋ敪
        ''' </summary>
        Public Enum UKEIRE_KEITAI_KUBUN

            ''' <summary>�ڑ�</summary>
            ISO = 2

            ''' <summary>�ڊ�</summary>
            IKAN = 3

            ''' <summary>���</summary>
            IPPANHIN = 4

            ''' <summary>SK�i</summary>
            SKHIN = 5

            ''' <summary>W�i</summary>
            WHIN = 6

            ''' <summary>�I���i</summary>
            ENDHIN = 7

            ''' <summary>�����d��</summary>
            JIDOSHIWAKE = 8

        End Enum

        ''' <summary>
        ''' ����󋵃t���O
        ''' </summary>
        Public Enum UKEIRE_JOKYO_FLG

            ''' <summary>�����t</summary>
            MIWARITUKE = 0

            ''' <summary>���t��</summary>
            WARITUKEZUMI = 1

            ''' <summary>�G�t���s��</summary>
            EFUHAKKOZUMI = 2

            ''' <summary>�����Ɗ���</summary>
            UKEIRE_KANRYO = 3

            ''' <summary>���Ɋ���</summary>
            NYUKO_KANRYO = 4

            ''' <summary>�z�X�g�ڑ���</summary>
            HOST_SETUZOKU = 5

        End Enum

        ''' <summary>
        ''' �{�^��
        ''' </summary>
        Public Enum BUTTON
            ''' <summary>�E�{�^��</summary>
            RIGHT = 0
            ''' <summary>���{�^��</summary>
            LEFT = 1
        End Enum

        ''' <summary>
        ''' �ڑ�������݃t���O�i�݌ɋ敪�j
        ''' </summary>
        Public Enum ISO_UKEIRE_EXIST_FLG
            ''' <summary>����</summary>
            EXIST = 1
            ''' <summary>�񑶍�</summary>
            UNEXIST = 0
        End Enum

        

        ''' <summary>
        ''' �����׸ޒl
        ''' </summary>
        Public Enum CommonFlg
            ''' <summary>�I�t</summary>
            OFF = 0

            ''' <summary>�I��</summary>
            [ON] = 1
        End Enum

       

        ''' <summary>���ٖ��̍�ƒ��~�m�F</summary>
        Public Const TITLE_SAGYOSTOP_ERR As String = "��ƒ��~�m�F"

#End Region

    End Class

End Namespace