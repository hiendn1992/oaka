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
Imports jp.co.ait.common
Imports System.Windows.Forms

Public Class frm_LWHBC000F

#Region " �ϐ�/�萔 "

    ''' <summary>�G���[���e</summary>
    Private _errorMsg As String = String.Empty
    ''' <summary>���[�j���O�t���O</summary>
    Private _warningFlag As Integer = 0
    ''' <summary>�{�^���\��/��\��</summary>
    Private _buttonVisible As Boolean = True

    ''' <summary>�^�C�g���萔�i�G���[�j</summary>
    Private Const TITLE_NAME_ERR As String = "�G���["

#End Region

#Region " �R���X�g���N�^ "

    ''' <summary>
    ''' ������
    ''' </summary>
    Public Sub New()

        '���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        'InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B
    End Sub

    ''' <summary>
    ''' ������
    ''' </summary>
    ''' <param name="lstArray">���b�Z�[�W���</param>
    Public Sub New(ByVal lstArray As ArrayList)
        Me.new()

        Try
            ' �^�C�g��
            If lstArray.Count > 0 Then
                Me.ScreenName = lstArray(0).ToString
            End If

            ' �G���[���e
            If lstArray.Count > 1 Then
                Me._errorMsg = lstArray(1).ToString.Replace("$", vbCrLf)
            End If

            ' ���[�j���O�t���O
            If lstArray.Count > 2 Then
                Me._warningFlag = CInt(lstArray(2))
            End If

            ' �{�^���\��/��\��
            If lstArray.Count > 3 Then
                Me._buttonVisible = CBool(lstArray(3))
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
        Finally
            Debug.WriteLine("�װ̫��OK")
        End Try
    End Sub

#End Region

#Region " �C�x���g "

    ''' <summary>
    ''' �t�H�[�����[�h
    ''' </summary>
    ''' <param name="sender">�R���|�[�l���g</param>
    ''' <param name="e">�C�x���g���</param>
    Private Sub frm_LWHBC000F_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WriteEventStartLog("frm_LWHBC000F_Load")
        Try
            Cursor.Current = Cursors.Default

            ' �G���[���e
            Me.lbl_MSG.Text = Me._errorMsg

            If Me._warningFlag = 0 Then
                ' �G���[�\���̏ꍇ�A���������G���[���e(�Ԏ�)��\������
                Me.lbl_MSG.ForeColor = System.Drawing.Color.Red
            Else
                ' ���[�j���O�\���̏ꍇ�A���[�j���O���e(��)��\������
                Me.lbl_MSG.ForeColor = System.Drawing.Color.Blue
            End If

            ' �{�^���\��/��\��
            Me.pnl_OK.Visible = Me._buttonVisible

        Catch ex As Exception
            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
        End Try
        WriteEventEndLog("frm_LWHBC000F_Load")

    End Sub

    ''' <summary>
    ''' �n�j����
    ''' </summary>
    ''' <param name="sender">�R���|�[�l���g</param>
    ''' <param name="e">�C�x���g���</param>
    Private Sub pnl_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnl_OK.Click

        WriteEventStartLog("OK(����)����")
        Try
            ' ����ʂ����B
            Me.Close()
            Me.Dispose()

        Catch ex As Exception

            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
        End Try
        WriteEventEndLog("OK(����)����")

    End Sub

    ''' <summary>
    ''' frm_LWHBC000F_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>vudh</remarks>
    Private Sub frm_LWHBC000F_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F2 Then
            pnl_OK_Click(sender, e)
        End If
    End Sub

#End Region

End Class
