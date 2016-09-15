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
Imports System.ComponentModel


Namespace jp.co.ait.common.forms
    ''' <summary>
    ''' �n���f�B�p�p�l��(�p�l���R���|�[�l�b�g)
    ''' </summary>
    Public Class ABCDBCPanel
        Inherits Panel

#Region " ���[�U��` "

        ''' <summary>
        ''' ���E���X�^�C��
        ''' </summary>
        Private _borderStyle As BorderStyle = BorderStyle.None

        ''' <summary>
        ''' ���E���F
        ''' </summary>
        Private _borderColor As Color = SystemColors.WindowFrame

        ''' <summary>
        ''' ���E����
        ''' </summary>
        Private _borderWidth As Integer = 1

        ''' <summary>
        ''' �p�l�����b�N�̒l(�N���b�N�C�x���g�������Ȃ��悤��)
        ''' </summary>
        Private _pnlLocked As Boolean = False

        ''' <summary>
        ''' �p�l���F���x��
        ''' </summary>
        Private _colorLevel As ABCDBCConst.userColorLevel = ABCDBCConst.userColorLevel.LEVEL5

        ''' <summary>
        ''' �p�l���ɕ\�����镶����
        ''' </summary>
        Private _labelText As String = ""

        ''' <summary>
        ''' �p�l���ɕ\�����镶��������s����ۂ̉��s����
        ''' </summary>
        Private _splitChar As String = "\n"

        ''' <summary>
        ''' ̫�ĐF
        ''' </summary>
        Private _fontColor As Color = Color.Black

        ''' <summary>
        ''' �p�l���ɕ\�����镶��������s����ۂ̉��s����
        ''' </summary>
        Private _labelFont As Font = New Font("�l�r �S�V�b�N", 12, FontStyle.Bold)

        ''' <summary>
        ''' �p�l���ɕ\�����镶��������E�\��
        ''' </summary>
        Private _labelAlign As HorizontalAlignment = HorizontalAlignment.Center

        ''' <summary>
        ''' ���ٸد����׸�
        ''' </summary>
        Private _clickEnabled As Boolean = True

#End Region

#Region " �v���p�e�B "

        ''' <summary>
        ''' ���E���X�^�C���̐ݒ�Ǝ擾(3D�Ή����܂���)
        ''' </summary>
        ''' <value>���E���X�^�C���̐ݒ�l</value>
        ''' <returns>���E���X�^�C���̖߂�l</returns>
        Public Shadows Property BorderStyle() As BorderStyle
            Get
                Return Me._borderStyle
            End Get
            Set(ByVal Value As BorderStyle)
                Me._borderStyle = Value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' ���E���F�̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>���E���F�̐ݒ�l</value>
        ''' <returns>���E���F�̖߂�l</returns>
        Public Property BorderColor() As Color
            Get
                Return Me._borderColor
            End Get
            Set(ByVal Value As Color)
                Me._borderColor = Value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' ���E�����̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>���E�����̐ݒ�l</value>
        ''' <returns>���E�����̖߂�l</returns>
        Public Property BorderWidth() As Integer
            Get
                Return Me._borderWidth
            End Get
            Set(ByVal Value As Integer)
                Me._borderWidth = Value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' ���b�N�̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>���b�N�̐ݒ�l</value>
        ''' <returns>���b�N�̖߂�l</returns>
        Public Property PnlLocked() As Boolean
            Get
                Return Me._pnlLocked
            End Get
            Set(ByVal Value As Boolean)
                Me._pnlLocked = Value
                SetPanelColor()
            End Set
        End Property

        ''' <summary>
        ''' �p�l���F���x���̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>�p�l���F���x���̐ݒ�l</value>
        ''' <returns>�p�l���F���x���̖߂�l</returns>
        Public Property ColorLevel() As ABCDBCConst.userColorLevel
            Get
                Return Me._colorLevel
            End Get
            Set(ByVal value As ABCDBCConst.userColorLevel)
                Me._colorLevel = value
                SetPanelColor()
            End Set
        End Property

        ''' <summary>
        ''' �p�l���̕����̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>�p�l���̕����̐ݒ�l</value>
        ''' <returns>�p�l���̕����̖߂�l</returns>
        Public Property LabelText() As String
            Get
                Return Me._labelText
            End Get
            Set(ByVal value As String)
                Me._labelText = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' �p�l���̉��s�����̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>�p�l���̉��s�����̐ݒ�l</value>
        ''' <returns>�p�l���̉��s�����̖߂�l</returns>
        Public Property SplitChar() As String
            Get
                Return Me._splitChar
            End Get
            Set(ByVal value As String)
                Me._splitChar = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' �p�l�������F�̐ݒ�Ǝ擾
        ''' </summary>
        ''' <value>�p�l�������F�̐ݒ�l</value>
        ''' <returns>�p�l�������F�̖߂�l</returns>
        Public Property FontColor() As Color
            Get
                Return Me._fontColor
            End Get
            Set(ByVal value As Color)
                Me._fontColor = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' �p�l������
        ''' </summary>
        ''' <value>�p�l�������̐ݒ�l</value>
        ''' <returns>�p�l�������̖߂�l</returns>
        Public Property LableFont() As Font
            Get
                Return Me._labelFont
            End Get
            Set(ByVal value As Font)
                Me._labelFont = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' �p�l�������̐����ʒu
        ''' </summary>
        ''' <value>�p�l�������̐����ʒu�̐ݒ�l</value>
        ''' <returns>�p�l�������̐����ʒu�̖߂�l</returns>
        Public Property LabelAlign() As HorizontalAlignment
            Get
                Return Me._labelAlign
            End Get
            Set(ByVal value As HorizontalAlignment)
                Me._labelAlign = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' ���ٸد����׸�
        ''' </summary>
        ''' <value>���ٸد����׸ނ̐ݒ�l</value>
        ''' <returns>���ٸد����׸ނ̖߂�l</returns>
        Public Property ClickEnabled() As Boolean
            Get
                Return Me._clickEnabled
            End Get
            Set(ByVal value As Boolean)
                Me._clickEnabled = value
            End Set
        End Property

#End Region

#Region " հ�ޒ�`�֐� "

        ''' <summary>
        ''' ���ق̐F��ݒ�
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetPanelColor()
            Me.BorderColor = ABCDBCConst.LST_BORDERCOLOR_LEVEL(Me._colorLevel)
            If Me._pnlLocked Then
                Me.BackColor = ABCDBCConst.LST_LOCK_BACKCOLOR_LEVEL(Me._colorLevel)
                Me.FontColor = ABCDBCConst.LST_LOCK_FONTCOLOR_LEVEL(Me._colorLevel)
            Else
                Me.BackColor = ABCDBCConst.LST_BACKCOLOR_LEVEL(Me._colorLevel)
                Me.FontColor = ABCDBCConst.LST_FONTCOLOR_LEVEL(Me._colorLevel)
            End If
        End Sub

        ''' <summary>
        ''' ���ق�̫�Ă�`�悷��
        ''' </summary>
        ''' <param name="value">�F����</param>
        ''' <param name="e">�`�����ď��</param>
        Private Sub SetPanelFont(ByVal value As ABCDBCConst.userColorLevel, _
                                 ByVal e As System.Windows.Forms.PaintEventArgs)

            Dim brush As System.Drawing.Brush = New System.Drawing.SolidBrush(Me._fontColor)
            Dim lines As String() = Split(Me._labelText, Me._splitChar)
            Dim h As Single = e.Graphics.MeasureString(lines(0), Me._labelFont).Height

            Const yohaku As Integer = 10

            If Me._labelFont.Name = "�l�r �S�V�b�N" Then
                h = Convert.ToInt32(h * 0.9)
            End If

            '�㉺�̃Z���^�����O���s���ׁA��[�̈ʒu���v�Z����
            Dim top As Single = (Me.Height - h * lines.Length()) / 2
            Dim x As Single

            For Each line As String In lines
                '���E�̃Z���^�����O���s���ׁA���[�̈ʒu���v�Z����
                Select Case Me._labelAlign
                    Case HorizontalAlignment.Left
                        x = yohaku
                    Case HorizontalAlignment.Center
                        x = (Me.Width - e.Graphics.MeasureString(line, Me._labelFont).Width) / 2
                    Case HorizontalAlignment.Right
                        x = (Me.Width - e.Graphics.MeasureString(line, Me._labelFont).Width) - yohaku
                    Case Else

                End Select

                e.Graphics.DrawString(line, Me._labelFont, brush, x, top)
                top = top + h
            Next
        End Sub

        ''' <summary>
        ''' ���ق̌r����`�悷��
        ''' </summary>
        ''' <param name="e">�`�����ď��</param>
        Private Sub SetPanelBorder(ByVal e As System.Windows.Forms.PaintEventArgs)

            ' �R���g���[���̃N���C�A���g�̈��\���l�p�`���擾
            Dim rect As System.Drawing.Rectangle = Me.ClientRectangle

            ' �R���g���[���̃N���C�A���g�̈��\���l�p�`�̃T�C�Y�̍Đݒ�
            If Me.ClientRectangle.Width = 0 Then
                rect.Width += 1
            End If

            If Me.ClientRectangle.Height = 0 Then
                rect.Height += 1
            End If

            rect.Width -= 1
            rect.Height -= 1

            ' �R���g���[���̃N���C�A���g�̈��\���l�p�`�̋��E����`��
            Select Case Me._borderStyle
                Case System.Windows.Forms.BorderStyle.FixedSingle
                    ' ��d���̋��E��
                    Dim borderPen As New System.Drawing.Pen(Me._borderColor, Me._borderWidth * 2)
                    e.Graphics.DrawRectangle(borderPen, rect)
                    borderPen.Dispose()

                Case System.Windows.Forms.BorderStyle.Fixed3D
                    ' 3D ���E��

                Case System.Windows.Forms.BorderStyle.None
                    ' ���E���Ȃ�
            End Select

            rect = Nothing

        End Sub

#End Region

#Region "�R���X�g���N�^�Ə�����"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        Public Sub New()

            MyBase.New()
            Me.customInitialisation()

        End Sub

        ''' <summary>
        ''' ����������
        ''' </summary>
        Private Sub customInitialisation()

            ' �R���g���[���̃��C�A�E�g���W�b�N���ꎞ�I�ɒ��f����B 
            Me.SuspendLayout()

            MyBase.BackColor = Color.Transparent
            Me.BorderStyle = BorderStyle.None

            ' �ʏ�̃��C�A�E�g���W�b�N���ĊJ����B
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " �I�[�o�[���C�h�C�x���g "

        ''' <summary>
        ''' ToolStrip�̔w�i��Paint�C�x���g�𔭐�������B
        ''' </summary>
        ''' <param name="e">Paint�C�x���g���</param>
        Protected Overrides Sub OnPaintBackGround(ByVal e As System.Windows.Forms.PaintEventArgs)

            MyBase.OnPaintBackground(e)

            ' ���E���̕`��
            SetPanelBorder(e)

            If Not Me._labelText.Equals(String.Empty) Then
                ' ̫�Ă̕`��
                SetPanelFont(Me._colorLevel, e)
            End If
        End Sub

        ''' <summary>
        ''' �p�l���̃N���b�N�C�x���g���ްײ�ނ���
        ''' </summary>
        ''' <param name="e">�C�x���g���</param>
        Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
            ' �p�l�����b�N�����Ƃ�(�N���b�N�C�x���g�������Ȃ�)
            If Not Me._pnlLocked AndAlso Me._clickEnabled Then
                MyBase.OnClick(e)
            End If
        End Sub

        '''' <summary>
        '''' ���ق�����ٸد�����Ă𖳗����د�����Ăɍ����ւ���
        '''' </summary>
        '''' <param name="e">����ď��</param>
        'Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        '    If Not Me._pnlLocked Then
        '        MyBase.OnClick(e)
        '    End If
        'End Sub

#End Region

    End Class
End Namespace