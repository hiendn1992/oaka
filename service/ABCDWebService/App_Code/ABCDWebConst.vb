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

Namespace jp.co.ait.WebService

    Public Class ABCDWebConst

        ''' <summary>�����l��`�pXML�t�@�C������</summary>
        Public Const APP_CONFIG_FILE As String = "ABCD_SV.xml"

        ''' <summary>���O�o�̓��x���萔�@DUMP</summary>
        Public Const LOG_LEVEL_DUMP As String = "Dump"

        ''' <summary>���O�o�̓��x���萔�@DEBUG</summary>
        Public Const LOG_LEVEL_DEBUG As String = "Debug"

        ''' <summary>���O�o�̓��x���萔�@INFOMATION</summary>
        Public Const LOG_LEVEL_INFOMATION As String = "Infomation"

        ''' <summary>���O�o�̓��x���萔�@TRACE</summary>
        Public Const LOG_LEVEL_TRACE As String = "Trace"

        ''' <summary>���O�o�̓��x���萔�@OPERATION</summary>
        Public Const LOG_LEVEL_OPERATION As String = "Operation"

        ''' <summary>���O�o�̓��x���萔�@WARNING</summary>
        Public Const LOG_LEVEL_WARNING As String = "Warning"

        ''' <summary>���O�o�̓��x���萔�@ERROR</summary>
        Public Const LOG_LEVEL_ERROR As String = "Error"


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
        ''' ���Ɋ����׸�
        ''' </summary>
        Public Enum NYUKO_KANRYO_FLG
            ''' <summary>������</summary>
            NYUKO_MI = 0

            ''' <summary>���Ɋ���</summary>
            NYUKO_OK = 1

            ''' <summary>����NG</summary>
            NYUKO_NG = 2
        End Enum

        ''' <summary>�ް�����޲Đ�</summary>
        Public Enum BarCodeLength
            ''' <summary>���^BC 7�޲�</summary>
            SeikeiBC_1 = 7

            ''' <summary>���^BC 8�޲�</summary>
            SeikeiBC_2 = 8

            ''' <summary>��BC 32�޲�</summary>
            EfuBC = 32

            ''' <summary>Jan���� 13�޲�</summary>
            JANCd = 13

        End Enum

        ''' <summary>
        ''' ��ƌ`�ԋ敪
        ''' </summary>
        Public Enum SAGYO_KEITAI_KUBUN

            ''' <summary>���</summary>
            IPPAN = 0

            ''' <summary>�c�q(���)</summary>
            EISO_P = 1

            ''' <summary>�c�q(���)</summary>
            EISO_B = 2

            ''' <summary>����</summary>
            KOGUCHI = 3

        End Enum

    End Class

End Namespace