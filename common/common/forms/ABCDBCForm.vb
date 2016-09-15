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
Imports System.Windows.Forms
Imports System.Drawing

Namespace jp.co.ait.common.forms

    ''' <summary>
    ''' ����̫�ъ�ո׽
    ''' </summary>
    Public Class ABCDBCForm

#Region " հ�ޕϐ���` "

        ''' <summary>
        ''' ̫��Ӱ��
        ''' </summary>
        Enum ScreenMode

            ''' <summary>�w��Ȃ�</summary>
            None

            ''' <summary>���o</summary>
            Haraidashi

            ''' <summary>�݌�</summary>
            Zaiko

            ''' <summary>���</summary>
            Ukeire

        End Enum

        ''' <summary>�J�ڌ����ID</summary>
        Private _motoScreenID As String

        ''' <summary>̫��ID</summary>
        Private _screenID As String = String.Empty

        ''' <summary>̫�і���</summary>
        Private _screenName As String = String.Empty

        ''' <summary>̫��Ӱ�ނȂ�</summary>
        Private _mode As ScreenMode = ScreenMode.None

        ''' <summary>��ʗp���Ұ�����</summary>
        Private _param As DataSet

#End Region

#Region " հ�޲���Ē�` "

        ''' <summary>
        ''' հ�޲���Ē�`
        ''' </summary>
        Public Event TitleClick As EventHandler

#End Region

#Region " �����è "

        ''' <summary>
        ''' ̫�і��̂̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>̫�і��̂̐ݒ�l</value>
        ''' <returns>̫�і��̖̂߂�l</returns>
        Public Property ScreenName() As String
            Get
                Return Me._screenName
            End Get
            Set(ByVal value As String)
                Me._screenName = value
                Me.SetTitleName(value)
            End Set
        End Property

        ''' <summary>
        ''' ̫��ID�̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>̫��ID�̐ݒ�l</value>
        ''' <returns>̫��ID�̖߂�l</returns>
        Public Property ScreenID() As String
            Get
                Return Me._screenID
            End Get
            Set(ByVal value As String)
                Me._screenID = value
            End Set
        End Property

        ''' <summary>
        ''' ̫��Ӱ�ނ̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>̫��Ӱ�ނ̐ݒ�l</value>
        ''' <returns>̫��Ӱ�ނ̖߂�l</returns>
        Public Property Mode() As ScreenMode
            Get
                Return Me._mode
            End Get
            Set(ByVal value As ScreenMode)
                Me._mode = value
            End Set
        End Property

        ''' <summary>
        ''' �J�ڌ�̫��ID�̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>�J�ڌ�̫��ID�̐ݒ�l</value>
        ''' <returns>�J�ڌ�̫��ID�̖߂�l</returns>
        Public Property MotoScreenID() As String
            Get
                Return Me._motoScreenID
            End Get
            Set(ByVal value As String)
                Me._motoScreenID = value
            End Set
        End Property

        ''' <summary>
        ''' ��ʗp���Ұ������̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>��ʗp���Ұ������̐ݒ�l</value>
        ''' <returns>��ʗp���Ұ������̖߂�l</returns>
        Public Property Param() As DataSet
            Get
                Return Me._param
            End Get
            Set(ByVal value As DataSet)
                Me._param = value
            End Set
        End Property

#End Region

#Region " հ�ޒ�`�֐� "

        ''' <summary>
        ''' �������ق�̫�і��̂�ݒ�
        ''' </summary>
        ''' <param name="strTitleName">̫�і���</param>
        Private Sub SetTitleName(ByVal strTitleName As String)
            Me.pnl_TITLE.LabelText = strTitleName
        End Sub

        ''' <summary>
        ''' ү���ނ̎擾
        ''' </summary>
        ''' <param name="msgID">ү����ID</param>
        ''' <param name="param">�u����������e�z��</param>
        ''' <returns>ү���ޓ��e</returns>
        Protected Function GetMessage(ByVal msgID As String, Optional ByVal param() As String = Nothing) As String
            Return ABCDBCMessage.GetMessage(msgID, param)
        End Function

        ''' <summary>
        ''' ү����̫�т�\��
        ''' </summary>
        ''' <param name="msgID">ү����ID</param>
        ''' <param name="formTitle">̫�і���</param>
        ''' <param name="warnningFlag">�u����������e�z��</param>
        ''' <param name="param">�u����������e�z��</param>
        ''' <param name="buttonVisible">�{�^���\��/��\��</param>
        Protected Sub ShowMessageForm(ByVal msgID As String, _
                                      ByVal formTitle As String, _
                                      Optional ByVal warnningFlag As Integer = 0, _
                                      Optional ByVal param() As String = Nothing, _
                                      Optional ByVal buttonVisible As Boolean = True)
            Dim strMsg As String
            Dim listMsg As New ArrayList

            strMsg = GetMessage(msgID, param)
            listMsg.Add(formTitle)
            listMsg.Add(strMsg)
            listMsg.Add(warnningFlag)
            listMsg.Add(buttonVisible)

            Dim frmLWHBC000F As New frm_LWHBC000F(listMsg)

            Application.DoEvents()
            frmLWHBC000F.ShowDialog()

            listMsg = Nothing
            frmLWHBC000F = Nothing

        End Sub

        ''' <summary>
        ''' ���Ѵװ��װ̫�тɕ\������
        ''' </summary>
        Protected Sub ShowSystemMessageForm()
            ShowMessageForm("BC902", "�V�X�e���G���[")
        End Sub

        ''' <summary>
        ''' ��ʺ��۰َg�p�ۂ̈ꊇ�ݒ�
        ''' </summary>
        Protected Sub SetControlEnabled(ByVal isEnabled As Boolean)

            Try
                If isEnabled Then Application.DoEvents()

                For Each pnl As Control In Me.Controls
                    If TypeOf pnl Is ABCDBCPanel Then
                        ' �g�p�ۂ�ݒ�
                        DirectCast(pnl, ABCDBCPanel).ClickEnabled = isEnabled
                    End If

                    If TypeOf pnl Is ABCDBCTextBox Then
                        ' �g�p�ۂ�ݒ�
                        pnl.Enabled = isEnabled
                    End If
                Next
            Catch ex As Exception

            End Try

        End Sub

        ''' <summary>
        ''' ��ʺ��۰َg�p�ۂ̈ꊇ�ݒ�
        ''' </summary>
        Protected Sub SetControlEnabled(ByVal isEnabled As Boolean, ByVal ActiveControl As Control)

            Try
                SetControlEnabled(isEnabled)

                If isEnabled Then ActiveControl.Focus()

            Catch ex As Exception

            End Try

        End Sub

        ''' <summary>
        ''' �w��o�C�g�������ŕԋp
        ''' </summary>
        ''' <param name="expression">�Ώە�����</param>
        ''' <param name="cutLength">�K�v�؂�o����������</param>
        ''' <returns>�s�����ɔ��p��߰��𑝂₷</returns>
        Private Function PadRightString(ByVal expression As String, _
                                              ByVal cutLength As Integer) As String

            Dim i As Integer
            Dim tmpByteCnt As Integer
            Dim length As Integer

            length = GetLenString(expression)
            If length < cutLength Then
                Return expression & Space(cutLength - length)
            Else
                ' �w��o�C�g��(�ȓ�)�ɂȂ�ʒu��T��
                i = 0
                tmpByteCnt = 0
                Do While (tmpByteCnt < cutLength)
                    i += 1
                    tmpByteCnt += GetLenString(Mid(expression, i, 1))
                Loop
                ' 1�o�C�g�I�[�o�[��
                If tmpByteCnt > cutLength Then
                    i -= 1
                End If

                Return expression.Substring(0, i)
            End If

        End Function

        ''' <summary>
        ''' ������̃o�C�g���v�Z
        ''' �^����ꂽ������̃o�C�g����Ԃ��B
        ''' </summary>
        ''' <param name="expression">������</param>
        ''' <returns>������̃o�C�g��</returns>
        Private Shared Function GetLenString(ByVal expression As String) As Integer
            ' Shift JIS�ɕϊ������Ƃ��ɕK�v�ȃo�C�g����Ԃ�
            If IsDBNull(expression) Or IsNothing(expression) Then
                Return 0
            Else
                Return System.Text.Encoding.GetEncoding(932).GetByteCount(expression)
            End If
        End Function

        ''' <summary>
        ''' ����Ă̊J�n۸�
        ''' </summary>
        ''' <param name="eventName">����Ė���</param>
        ''' <param name="logLevel">۸�����</param>
        Protected Sub WriteEventStartLog(ByVal eventName As String, _
                                          Optional ByVal logLevel As ABCDBCLog.LogLevel = ABCDBCLog.LogLevel.LevelDebug)

            Try
                Dim msg As String = String.Empty

                msg &= PadRightString(ScreenID, 10) & ", "
                msg &= PadRightString(ScreenName, 24) & ", �J�n, "
                msg &= eventName

                Select Case logLevel
                    Case ABCDBCLog.LogLevel.LevelDebug
                        ' ���ޯ��
                        WriteDebugLog(msg)
                    Case ABCDBCLog.LogLevel.LevelError
                        ' �װ
                        WriteErrorLog(msg)
                    Case ABCDBCLog.LogLevel.LevelTrace
                        ' �ڰ�
                        WriteTraceLog(msg)
                    Case Else
                        ' ���̑�
                        WriteDebugLog(msg)
                End Select

            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' ����Ă̏I��۸�
        ''' </summary>
        ''' <param name="eventName">����Ė���</param>
        ''' <param name="logLevel">۸�����</param>
        Protected Sub WriteEventEndLog(ByVal eventName As String, _
                                          Optional ByVal logLevel As ABCDBCLog.LogLevel = ABCDBCLog.LogLevel.LevelDebug)

            Try
                Dim msg As String = String.Empty

                msg &= PadRightString(ScreenID, 10) & ", "
                msg &= PadRightString(ScreenName, 24) & ", �I��, "
                msg &= eventName

                Select Case logLevel
                    Case ABCDBCLog.LogLevel.LevelDebug
                        ' ���ޯ��
                        WriteDebugLog(msg)
                    Case ABCDBCLog.LogLevel.LevelError
                        ' �װ
                        WriteErrorLog(msg)
                    Case ABCDBCLog.LogLevel.LevelTrace
                        ' �ڰ�
                        WriteTraceLog(msg)
                    Case Else
                        ' ���̑�
                        WriteDebugLog(msg)
                End Select

            Catch ex As Exception

            End Try
        End Sub

#End Region

#Region " �ݽ�׸� "

        ''' <summary>
        ''' �ݽ�׸�
        ''' </summary>
        Public Sub New()

            ' ���̌Ăяo���́AWindows ̫�� �޻޲łŕK�v�ł��B
            InitializeComponent()

            ' InitializeComponent() �Ăяo���̌�ŏ�������ǉ����܂��B

            AddHandler pnl_TITLE.Click, AddressOf pnlClick

            Me.Text = Me.ScreenName

        End Sub

        ''' <summary>
        ''' �ݽ�׸�
        ''' </summary>
        ''' <param name="strFormName">̫�і���</param>
        Public Sub New(ByVal strFormName As String)
            Me.New()

            ' ̫�і��̂̐ݒ�
            Me.ScreenName = strFormName
            Me.Text = Me.ScreenName
        End Sub

#End Region

#Region " հ�޲���� "

        ''' <summary>
        ''' ̫�����ٸد�����Ă̍쐬
        ''' </summary>
        ''' <param name="sender">���ٺ��۰�</param>
        ''' <param name="e">����ď��</param>
        Public Sub pnlClick(ByVal sender As Object, ByVal e As System.EventArgs)
            RaiseEvent TitleClick(Me.pnl_TITLE, e)
        End Sub
#End Region

#Region "Barcode Call Back Instant "
        ''' <summary>
        ''' Barcode Call Back Instant
        ''' </summary>
        ''' <param name="HWnd">Microsoft.WindowsCE.Forms.Message HWnd</param>
        ''' <param name="LParam">Microsoft.WindowsCE.Forms.Message LParam</param>
        ''' <param name="Msg">Microsoft.WindowsCE.Forms.Message Msg</param>
        ''' <param name="Result">Microsoft.WindowsCE.Forms.Message Result</param>
        ''' <param name="WParam">Microsoft.WindowsCE.Forms.Message WParam</param>
        ''' <remarks></remarks>
        Public Overridable Sub RespondToMessage(ByRef HWnd As IntPtr, _
                                                ByRef LParam As IntPtr, _
                                                ByVal Msg As Integer, _
                                                ByVal Result As IntPtr, _
                                                ByVal WParam As IntPtr)
        End Sub
#End Region

    End Class

End Namespace
