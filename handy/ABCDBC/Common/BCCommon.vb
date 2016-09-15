''*********************************************************************
''* Copyright Bridgestone Software co.,ltd. 2008
''* �V�X�e����   :�Ȗ؃��P�[�V�����V�X�e��
''* �N���X��     :���ʃN���X
''* �����T�v     :���ʃN���X
''*********************************************************************
''* �����F
''* NO   ���t   Ver  �X�V��          ���e
#Region "�F���C������"
''* 1  08/01/10 1.00 NCS)CHEN        ����
#End Region
''* 1  10/11/11 1.00 NCS)NISHIYAMA   SATO�v�����^�Ή�
''*    11/02/04 1.00 NCS)KIKUKAWA    �D���׸ޒǉ��Ή�
''*    11/02/18 1.00 NCS)OGATA       Web���޽�ڑ�۸ޒǉ�
''*********************************************************************

Imports System.Data
Imports jp.co.ait.common
Imports Bt
Imports System.Security.Cryptography

Namespace common

    ''' <summary>
    ''' BC���ʃN���X
    ''' </summary>
    Public Class BCCommon
        Inherits ABCDBCBase

#Region "�萔"

        Private Const XPRINTER_KBN_XML As String = "PRINT_XML/PRINTER_KBN"

#End Region


#Region "���ʕϐ�"

        ''' <summary>�E�F�[�u�T�[�r�X��URL�̕�����</summary>
        Protected Shared webServiceURL As String = String.Empty

        ''' <summary>̫�Ѳݽ�ݽ�pؽ�</summary>
        Protected Shared frmInstance As Dictionary(Of String, forms.ABCDBCForm)

        ''' <summary>�E�F�[�u�T�[�r�X�^�C���A�E�g����</summary>
        Private Shared _webServiceTimeOut As String = String.Empty


#End Region


#Region "���[�U��`�֐�"

        ''' <summary>
        ''' �E�F�[�u�T�[�r�X�^�C���A�E�g���Ԃ��擾
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetWebServiceTimeOut(ByVal isLogin As Boolean) As Integer
            ' ���O�C�����鎞�����N���A
            If isLogin Then
                _webServiceTimeOut = String.Empty
            End If
            ' �E�F�[�u�T�[�r�X�^�C���A�E�g���Ԃ��擾
            If _webServiceTimeOut.Equals(String.Empty) Then
                _webServiceTimeOut = ABCDBCXmlManager.GetFileData("WEBSVR/TIME_INTERVAL")
            End If
            Return CType(_webServiceTimeOut, Integer)
        End Function

        ''' <summary>
        ''' �J�����g�t�H���_�p�X�擾
        ''' </summary>
        ''' <returns>�J�����g�t�H���_�p�X</returns>
        Public Shared Function GetCurrentDir() As String
            ' ���S�ȃf�B���N�g���� exe �����擾
            Dim fullAppName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
            ' exe �������O
            Return System.IO.Path.GetDirectoryName(fullAppName) & "\"
        End Function

        ''' <summary>
        ''' �E�F�[�u�T�[�r�X��URL���擾����
        ''' </summary>
        ''' <returns>�E�F�[�u�T�[�r�X��URL�̕�����</returns>
        Public Shared Function GetWebHttpURL() As String
            ' �E�F�[�u�T�[�r�X��URL���擾����
            If webServiceURL.Equals(String.Empty) Then
                webServiceURL = ABCDBCXmlManager.GetFileData("WEBSVR/URL")
            End If
            Return webServiceURL
        End Function

        ''' <summary>
        ''' Ҳ݉�ʂ�ؽĂɒǉ�
        ''' </summary>
        Public Shared Sub AddMainMenuFrmInstance()
            frmInstance = New Dictionary(Of String, forms.ABCDBCForm)
            'frmInstance.Add(BCConst.LWHBC001F, My.Forms.frm_LWHBC001F)
        End Sub

        ''' <summary>
        ''' ̫��ID����ʂ�\������
        ''' </summary>
        ''' <param name="screenID">̫��ID</param>
        ''' <param name="param">��ʂ����Ұ������è(DataSet)</param>
        ''' <param name="motoScreenID">��ʂ̑J�ڌ����ID�����è</param>
        Public Shared Sub ShowForm(ByVal screenID As String, _
                                   Optional ByVal param As DataSet = Nothing, _
                                   Optional ByVal motoScreenID As String = "")

            Dim frm As Form = GetForm(screenID, param, motoScreenID)
            Application.DoEvents()
            frm.Show()
        End Sub

        ''' <summary>
        ''' ̫��ID����ʂ�\������(ShowDialog)
        ''' </summary>
        ''' <param name="screenID">̫��ID</param>
        ''' <param name="param">��ʂ����Ұ������è(DataSet)</param>
        ''' <param name="motoScreenID">��ʂ̑J�ڌ����ID�����è</param>
        Public Shared Function ShowDialogForm(ByVal screenID As String, _
                                         Optional ByVal param As DataSet = Nothing, _
                                         Optional ByVal motoScreenID As String = "") As DialogResult

            Dim frm As Form = GetForm(screenID, param, motoScreenID)

            Application.DoEvents()
            Return frm.ShowDialog()

        End Function

        ''' <summary>
        ''' ̫��ID����ʂ�۰��
        ''' </summary>
        ''' <param name="screenID">̫��ID</param>
        ''' <param name="showFormID">��ʂ������A�\�������ʂ�ID</param>
        ''' <param name="param">�\����ʂ����Ұ������è�(DataSet)</param>
        ''' <param name="motoScreenID">�\����ʂ̑J�ڌ����ID�����è</param>
        Public Shared Sub CloseForm(ByVal screenID As String, _
                                    Optional ByVal showFormID As String = "", _
                                    Optional ByVal param As DataSet = Nothing, _
                                    Optional ByVal motoScreenID As String = "")

            Dim frm As Form

            If Not showFormID.Equals(String.Empty) Then
                ' ̫�т�\��
                ShowForm(showFormID, param, motoScreenID)
            End If

            If frmInstance.ContainsKey(screenID) Then
                frm = frmInstance.Item(screenID)
                Dim screenName As String = DirectCast(frm, forms.ABCDBCForm).ScreenName

                WriteEventLog(screenID, _
                              screenName, _
                              "�J�n", _
                              "̫�ѱ�۰��")

                frm.Close()
                frm.Dispose()
                frm = Nothing

                WriteEventLog(screenID, _
                              screenName, _
                              "�I��", _
                              "̫�ѱ�۰��")

                ' ������ʂ̲ݽ�ݽ��ؽĂ��폜
                frmInstance.Remove(screenID)

                'If screenID.Equals(BCConst.LWHBC001F) Then
                '    ' Ҳ݉�ʂ����ꍇ�A��۸��т��I��(��{���Ȃ�)
                '    Application.Exit()
                'End If

            End If

        End Sub

        ''' <summary>
        ''' ̫��ID���̫�Ѳݽ�ݽ���擾
        ''' </summary>
        ''' <param name="strScreenID">̫��ID</param>
        ''' <param name="param">�\����ʂ����Ұ������è�(DataSet)</param>
        ''' <param name="motoScreenID">��ʂ̑J�ڌ����ID�����è</param>
        ''' <returns>̫�Ѳݽ�ݽ</returns>
        Private Shared Function GetForm(ByVal strScreenID As String, _
                                        ByVal param As DataSet, _
                                        ByVal motoScreenID As String) As Form

            Dim strType As Type
            Dim frm As forms.ABCDBCForm = Nothing

            If frmInstance.ContainsKey(strScreenID) Then
                frm = frmInstance.Item(strScreenID)
            Else
                ' ̫�т̖��̂�ݒ肷��
                Dim str As String = "jp.co.ait.LWHBC." & strScreenID.Substring(0, 6) & ".frm_" + strScreenID

                strType = Type.GetType(str)
                If (strType Is Nothing) Then
                    str = "jp.co.ait.LWHBC.frm_" & strScreenID
                    strType = Type.GetType(str)
                End If

                If Not (strType Is Nothing) Then
                    frm = CType(Activator.CreateInstance(strType), forms.ABCDBCForm)
                End If

                ' ̫�Ѳݽ�ݽ��ؽĂɒǉ�
                frmInstance.Add(strScreenID, frm)
            End If

            ' ̫�т������è��Ă���
            frm.Param = param
            frm.MotoScreenID = motoScreenID

            Return frm
        End Function

        ''' <summary>
        ''' ̫��ID���̫�Ѳݽ�ݽ���擾
        ''' </summary>
        ''' <param name="strScreenID">̫��ID</param>
        ''' <returns>̫�Ѳݽ�ݽ</returns>
        Private Shared Function GetForm(ByVal strScreenID As String) As Form

            Dim frm As forms.ABCDBCForm = Nothing

            If frmInstance.ContainsKey(strScreenID) Then
                frm = frmInstance.Item(strScreenID)
            End If

            Return frm
        End Function

        ''' <summary>
        ''' �w�蕶����K�v�����񕪂����J�b�g����
        ''' </summary>
        ''' <param name="expression">�Ώە�����</param>
        ''' <param name="startPos">�J�n�؂�o�������ʒu</param>
        ''' <param name="cutLength">�K�v�؂�o����������</param>
        ''' <returns>�w��o�C�g����؂�o��������</returns>
        Public Shared Function GetMidString(ByVal expression As String, _
                                            ByVal startPos As Integer, _
                                            Optional ByVal cutLength As Integer = 0) As String

            If GetLenString(expression) < startPos Or startPos <= 0 Then
                Return String.Empty
            Else
                ' �J�n�ʒu�܂Ń��[�v
                Dim cnt As Integer = 0
                Dim pos As Integer = 0
                Do While (cnt < startPos)
                    pos += 1
                    cnt += GetLenString(Mid(expression, pos, 1))
                Loop
                ' �����؂�o��
                Dim ret As String = Mid(expression, pos)
                ' �߂�l��߂�
                If cutLength > 0 Then
                    Return GetLeftString(ret, cutLength)
                Else
                    Return ret
                End If
            End If

        End Function

        ''' <summary>
        ''' �w��o�C�g���ȓ��ŕԋp
        ''' </summary>
        ''' <param name="expression">�Ώە�����</param>
        ''' <param name="cutLength">�K�v�؂�o����������</param>
        ''' <returns>�w��o�C�g����؂�o��������</returns>
        Public Shared Function GetLeftString(ByVal expression As String, _
                                             ByVal cutLength As Integer) As String

            Dim i As Integer
            Dim tmpByteCnt As Integer

            If GetLenString(expression) < cutLength Then
                Return expression
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
        ''' �w��o�C�g�������ŕԋp
        ''' </summary>
        ''' <param name="expression">�Ώە�����</param>
        ''' <param name="cutLength">�K�v�؂�o����������</param>
        ''' <returns>�s�����ɔ��p��߰��𑝂₷</returns>
        Public Shared Function PadRightString(ByVal expression As String, _
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
        Public Shared Function GetLenString(ByVal expression As String) As Integer
            ' Shift JIS�ɕϊ������Ƃ��ɕK�v�ȃo�C�g����Ԃ�
            If IsDBNull(expression) Or IsNothing(expression) Then
                Return 0
            Else
                Return System.Text.Encoding.GetEncoding(932).GetByteCount(expression)
            End If
        End Function


        ''' <summary>
        ''' �����۸ޏo��
        ''' </summary>
        ''' <param name="screenId">���ID</param>
        ''' <param name="screenName">��ʖ���</param>
        ''' <param name="eventTiming">��������ݸ�</param>
        ''' <param name="eventName">����Ė���</param>
        ''' <param name="logLevel">۸�����</param>
        Private Shared Sub WriteEventLog(ByVal screenId As String, _
                                        ByVal screenName As String, _
                                        ByVal eventTiming As String, _
                                        ByVal eventName As String, _
                                        Optional ByVal logLevel As ABCDBCLog.LogLevel = ABCDBCLog.LogLevel.LevelDebug)

            Try
                Dim msg As String = String.Empty

                msg &= PadRightString(screenId, 10) & ", "
                msg &= PadRightString(screenName, 24) & ", "
                msg &= PadRightString(eventTiming, 4) & ", "
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

#Region "Barcode system"
        Public Sub ScanData_ikkatu()

            Dim ret As Int32 = 0
            Dim disp As [String] = ""

            Dim codedataGet As [Byte]()
            Dim strCodedata As [String] = ""
            Dim codeLen As Int32 = 0
            Dim symbolGet As UInt16 = 0

            Try
                '-----------------------------------------------------------
                ' Reading (batch)
                '-----------------------------------------------------------
                codeLen = Bt.ScanLib.Control.btScanGetStringSize()
                If codeLen <= 0 Then
                    disp = "btScanGetStringSize error ret[" & codeLen & "]"
                    MessageBox.Show(disp, "Error")
                    GoTo L_END
                End If
                codedataGet = New [Byte](codeLen - 1) {}

                ret = Bt.ScanLib.Control.btScanGetString(codedataGet, symbolGet)
                If ret <> LibDef.BT_OK Then
                    disp = "btScanGetString error ret[" & ret & "]"
                    MessageBox.Show(disp, "Error")
                    GoTo L_END
                End If
                strCodedata = System.Text.Encoding.GetEncoding(932).GetString(codedataGet, 0, codeLen)
                disp = "Data size:" & codeLen & vbCr & vbLf & "Code classification:" & symbolGet & vbCr & vbLf & "Code character string:" & strCodedata & vbCr & vbLf
                MessageBox.Show(disp, "Reading (batch)")
L_END:
                ret = Bt.ScanLib.Control.btScanDisable()
                If ret <> LibDef.BT_OK Then
                    disp = "btScanDisable error ret[" & ret & "]"
                    MessageBox.Show(disp, "Error")
                End If
            Catch e As Exception
                MessageBox.Show(e.ToString())
            End Try
        End Sub
#End Region
    End Class

#Region "class EncryptDecryptVB"

    Public NotInheritable Class EncryptDecryptVB

        '' new variable.
        Private TripleDes As New TripleDESCryptoServiceProvider

        ''' <summary>
        ''' truncate hash.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="length"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
            Dim sha1 As New SHA1CryptoServiceProvider
            '' Hash the key.
            Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
            Dim hash() As Byte = sha1.ComputeHash(keyBytes)
            '' Truncate or pad the hash.
            ReDim Preserve hash(length - 1)
            Return hash
        End Function

        ''' <summary>
        ''' new class.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <remarks></remarks>
        Sub New(ByVal key As String)
            ' Initialize the crypto provider.
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
        End Sub

        ''' <summary>
        ''' encrypt data.
        ''' </summary>
        ''' <param name="plaintext"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function EncryptData(ByVal plaintext As String) As String
            ' Convert the plaintext string to a byte array.
            Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)
            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the encoder to write to the stream.
            Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()
            ' Convert the encrypted stream to a printable string.
            Return Convert.ToBase64String(ms.ToArray)
        End Function

        ''' <summary>
        ''' decrypt data.
        ''' </summary>
        ''' <param name="encryptedtext"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DecryptData(ByVal encryptedtext As String) As String
            ' Convert the encrypted text string to a byte array.
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)
            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream.
            Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()
            ' Convert the plaintext stream to a string.
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray, Nothing, Nothing)
        End Function

    End Class

#End Region


End Namespace
