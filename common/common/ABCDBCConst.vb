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
Imports System.Drawing

Namespace jp.co.ait.common

    ''' <summary>
    ''' �萔�N���X
    ''' </summary>
    Public Class ABCDBCConst

#Region "���ʒ萔"
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

        ''' <summary>�l�b�g���[�N�̐ڑ��@EXCEPTION</summary>
        Public Const ORA_CON_EXCEPTION As String = "�l�b�g���[�N�ւ̐ڑ����m���ł��܂���ł����B"

        ''' <summary>���ٖ��̴װ</summary>
        Public Const TITLE_ERROR As String = "�G���["

        ''' <summary>
        ''' �F����
        ''' </summary>
        Public Enum userColorLevel

            ''' <summary> �F���قȂ� </summary>
            LEVEL0 = 0

            ''' <summary> �F���� 1 </summary>
            LEVEL1 = 1

            ''' <summary> �F���� 2 </summary>
            LEVEL2 = 2

            ''' <summary> �F���� 3 </summary>
            LEVEL3 = 3

            ''' <summary> �F���� 4 </summary>
            LEVEL4 = 4

            ''' <summary> �F���� 5 </summary>
            LEVEL5 = 5

            ''' <summary> �F���� 6 </summary>
            LEVEL6 = 6

            ''' <summary> �F���� 7 </summary>
            LEVEL7 = 7

            ''' <summary> �F���� 8 </summary>
            LEVEL8 = 8

            ''' <summary> �F���� 9 </summary>
            LEVEL9 = 9

        End Enum

        ''' <summary>
        ''' ���ٔw�i�Fؽ�
        ''' </summary>
        Public Shared LST_BACKCOLOR_LEVEL As Color() = New Color() {Color.LightBlue, SystemColors.Control, _
                                                              Color.Navy, Color.Black, _
                                                              Color.Blue, Color.MediumBlue, _
                                                              Color.SkyBlue, Color.LimeGreen, _
                                                              Color.Red, Color.Indigo}

        ''' <summary>
        ''' ���قɂ�������̫�ĐFؽ�
        ''' </summary>
        Public Shared LST_FONTCOLOR_LEVEL As Color() = New Color() {Color.Black, SystemColors.ControlText, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White}
        ''' <summary>
        ''' ���ً��E���Fؽ�
        ''' </summary>
        Public Shared LST_BORDERCOLOR_LEVEL As Color() = New Color() {SystemColors.WindowFrame, SystemColors.WindowFrame, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White}

        ''' <summary>
        ''' ���ً��E����ؽ�
        ''' </summary>
        Public Shared LST_BORDERWIDTH_LEVEL As Integer() = New Integer() {1, 1, 4, 4, 4, 4, 4, 4, 4, 4}

        ''' <summary>
        ''' ���ٔw�i�Fؽ�(ۯ���)
        ''' </summary>
        Public Shared LST_LOCK_BACKCOLOR_LEVEL As Color() = New Color() {Color.White, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control}

        ''' <summary>
        ''' ���قɂ�������̫�ĐFؽ�(ۯ���)
        ''' </summary>
        Public Shared LST_LOCK_FONTCOLOR_LEVEL As Color() = New Color() {Color.Black, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText}
#End Region

    End Class

End Namespace