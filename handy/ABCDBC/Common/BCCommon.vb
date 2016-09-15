''*********************************************************************
''* Copyright Bridgestone Software co.,ltd. 2008
''* ƒVƒXƒeƒ€–¼   :“È–ØƒƒP[ƒVƒ‡ƒ“ƒVƒXƒeƒ€
''* ƒNƒ‰ƒX–¼     :‹¤’ÊƒNƒ‰ƒX
''* ˆ—ŠT—v     :‹¤’ÊƒNƒ‰ƒX
''*********************************************************************
''* —š—ğF
''* NO   “ú•t   Ver  XVÒ          “à—e
#Region "•FªC³—š—ğ"
''* 1  08/01/10 1.00 NCS)CHEN        ‰”Å
#End Region
''* 1  10/11/11 1.00 NCS)NISHIYAMA   SATOƒvƒŠƒ“ƒ^‘Î‰
''*    11/02/04 1.00 NCS)KIKUKAWA    —DæÌ×¸Ş’Ç‰Á‘Î‰
''*    11/02/18 1.00 NCS)OGATA       Web»°ËŞ½Ú‘±Û¸Ş’Ç‰Á
''*********************************************************************

Imports System.Data
Imports jp.co.ait.common
Imports Bt
Imports System.Security.Cryptography

Namespace common

    ''' <summary>
    ''' BC‹¤’ÊƒNƒ‰ƒX
    ''' </summary>
    Public Class BCCommon
        Inherits ABCDBCBase

#Region "’è”"

        Private Const XPRINTER_KBN_XML As String = "PRINT_XML/PRINTER_KBN"

#End Region


#Region "‹¤’Ê•Ï”"

        ''' <summary>ƒEƒF[ƒuƒT[ƒrƒX‚ÌURL‚Ì•¶š—ñ</summary>
        Protected Shared webServiceURL As String = String.Empty

        ''' <summary>Ì«°Ñ²İ½Àİ½—pØ½Ä</summary>
        Protected Shared frmInstance As Dictionary(Of String, forms.ABCDBCForm)

        ''' <summary>ƒEƒF[ƒuƒT[ƒrƒXƒ^ƒCƒ€ƒAƒEƒgŠÔ</summary>
        Private Shared _webServiceTimeOut As String = String.Empty


#End Region


#Region "ƒ†[ƒU’è‹`ŠÖ”"

        ''' <summary>
        ''' ƒEƒF[ƒuƒT[ƒrƒXƒ^ƒCƒ€ƒAƒEƒgŠÔ‚ğæ“¾
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetWebServiceTimeOut(ByVal isLogin As Boolean) As Integer
            ' ƒƒOƒCƒ“‚·‚é‚¾‚¯ƒNƒŠƒA
            If isLogin Then
                _webServiceTimeOut = String.Empty
            End If
            ' ƒEƒF[ƒuƒT[ƒrƒXƒ^ƒCƒ€ƒAƒEƒgŠÔ‚ğæ“¾
            If _webServiceTimeOut.Equals(String.Empty) Then
                _webServiceTimeOut = ABCDBCXmlManager.GetFileData("WEBSVR/TIME_INTERVAL")
            End If
            Return CType(_webServiceTimeOut, Integer)
        End Function

        ''' <summary>
        ''' ƒJƒŒƒ“ƒgƒtƒHƒ‹ƒ_ƒpƒXæ“¾
        ''' </summary>
        ''' <returns>ƒJƒŒƒ“ƒgƒtƒHƒ‹ƒ_ƒpƒX</returns>
        Public Shared Function GetCurrentDir() As String
            ' Š®‘S‚ÈƒfƒBƒŒƒNƒgƒŠ‚Æ exe –¼‚ğæ“¾
            Dim fullAppName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
            ' exe –¼‚ğœŠO
            Return System.IO.Path.GetDirectoryName(fullAppName) & "\"
        End Function

        ''' <summary>
        ''' ƒEƒF[ƒuƒT[ƒrƒX‚ÌURL‚ğæ“¾‚·‚é
        ''' </summary>
        ''' <returns>ƒEƒF[ƒuƒT[ƒrƒX‚ÌURL‚Ì•¶š—ñ</returns>
        Public Shared Function GetWebHttpURL() As String
            ' ƒEƒF[ƒuƒT[ƒrƒX‚ÌURL‚ğæ“¾‚·‚é
            If webServiceURL.Equals(String.Empty) Then
                webServiceURL = ABCDBCXmlManager.GetFileData("WEBSVR/URL")
            End If
            Return webServiceURL
        End Function

        ''' <summary>
        ''' Ò²İ‰æ–Ê‚ğØ½Ä‚É’Ç‰Á
        ''' </summary>
        Public Shared Sub AddMainMenuFrmInstance()
            frmInstance = New Dictionary(Of String, forms.ABCDBCForm)
            'frmInstance.Add(BCConst.LWHBC001F, My.Forms.frm_LWHBC001F)
        End Sub

        ''' <summary>
        ''' Ì«°ÑID‚æ‚è‰æ–Ê‚ğ•\¦‚·‚é
        ''' </summary>
        ''' <param name="screenID">Ì«°ÑID</param>
        ''' <param name="param">‰æ–Ê‚ÌÊß×Ò°ÀÌßÛÊßÃ¨(DataSet)</param>
        ''' <param name="motoScreenID">‰æ–Ê‚Ì‘JˆÚŒ³‰æ–ÊIDÌßÛÊßÃ¨</param>
        Public Shared Sub ShowForm(ByVal screenID As String, _
                                   Optional ByVal param As DataSet = Nothing, _
                                   Optional ByVal motoScreenID As String = "")

            Dim frm As Form = GetForm(screenID, param, motoScreenID)
            Application.DoEvents()
            frm.Show()
        End Sub

        ''' <summary>
        ''' Ì«°ÑID‚æ‚è‰æ–Ê‚ğ•\¦‚·‚é(ShowDialog)
        ''' </summary>
        ''' <param name="screenID">Ì«°ÑID</param>
        ''' <param name="param">‰æ–Ê‚ÌÊß×Ò°ÀÌßÛÊßÃ¨(DataSet)</param>
        ''' <param name="motoScreenID">‰æ–Ê‚Ì‘JˆÚŒ³‰æ–ÊIDÌßÛÊßÃ¨</param>
        Public Shared Function ShowDialogForm(ByVal screenID As String, _
                                         Optional ByVal param As DataSet = Nothing, _
                                         Optional ByVal motoScreenID As String = "") As DialogResult

            Dim frm As Form = GetForm(screenID, param, motoScreenID)

            Application.DoEvents()
            Return frm.ShowDialog()

        End Function

        ''' <summary>
        ''' Ì«°ÑID‚æ‚è‰æ–Ê‚ğ¸Û°½Ş
        ''' </summary>
        ''' <param name="screenID">Ì«°ÑID</param>
        ''' <param name="showFormID">‰æ–Ê‚ğ•Â‚¶‚½ŒãA•\¦‚·‚é‰æ–Ê‚ÌID</param>
        ''' <param name="param">•\¦‰æ–Ê‚ÌÊß×Ò°ÀÌßÛÊßÃ¨€(DataSet)</param>
        ''' <param name="motoScreenID">•\¦‰æ–Ê‚Ì‘JˆÚŒ³‰æ–ÊIDÌßÛÊßÃ¨</param>
        Public Shared Sub CloseForm(ByVal screenID As String, _
                                    Optional ByVal showFormID As String = "", _
                                    Optional ByVal param As DataSet = Nothing, _
                                    Optional ByVal motoScreenID As String = "")

            Dim frm As Form

            If Not showFormID.Equals(String.Empty) Then
                ' Ì«°Ñ‚ğ•\¦
                ShowForm(showFormID, param, motoScreenID)
            End If

            If frmInstance.ContainsKey(screenID) Then
                frm = frmInstance.Item(screenID)
                Dim screenName As String = DirectCast(frm, forms.ABCDBCForm).ScreenName

                WriteEventLog(screenID, _
                              screenName, _
                              "ŠJn", _
                              "Ì«°Ñ±İÛ°ÄŞ")

                frm.Close()
                frm.Dispose()
                frm = Nothing

                WriteEventLog(screenID, _
                              screenName, _
                              "I—¹", _
                              "Ì«°Ñ±İÛ°ÄŞ")

                ' •Â‚¶‚½‰æ–Ê‚Ì²İ½Àİ½‚ğØ½Ä‚æ‚èíœ
                frmInstance.Remove(screenID)

                'If screenID.Equals(BCConst.LWHBC001F) Then
                '    ' Ò²İ‰æ–Ê‚ğ•Â‚¶‚éê‡AÌßÛ¸Ş×Ñ‚ğI—¹(Šî–{‚ª‚È‚¢)
                '    Application.Exit()
                'End If

            End If

        End Sub

        ''' <summary>
        ''' Ì«°ÑID‚æ‚èÌ«°Ñ²İ½Àİ½‚ğæ“¾
        ''' </summary>
        ''' <param name="strScreenID">Ì«°ÑID</param>
        ''' <param name="param">•\¦‰æ–Ê‚ÌÊß×Ò°ÀÌßÛÊßÃ¨€(DataSet)</param>
        ''' <param name="motoScreenID">‰æ–Ê‚Ì‘JˆÚŒ³‰æ–ÊIDÌßÛÊßÃ¨</param>
        ''' <returns>Ì«°Ñ²İ½Àİ½</returns>
        Private Shared Function GetForm(ByVal strScreenID As String, _
                                        ByVal param As DataSet, _
                                        ByVal motoScreenID As String) As Form

            Dim strType As Type
            Dim frm As forms.ABCDBCForm = Nothing

            If frmInstance.ContainsKey(strScreenID) Then
                frm = frmInstance.Item(strScreenID)
            Else
                ' Ì«°Ñ‚Ì–¼Ì‚ğİ’è‚·‚é
                Dim str As String = "jp.co.ait.LWHBC." & strScreenID.Substring(0, 6) & ".frm_" + strScreenID

                strType = Type.GetType(str)
                If (strType Is Nothing) Then
                    str = "jp.co.ait.LWHBC.frm_" & strScreenID
                    strType = Type.GetType(str)
                End If

                If Not (strType Is Nothing) Then
                    frm = CType(Activator.CreateInstance(strType), forms.ABCDBCForm)
                End If

                ' Ì«°Ñ²İ½Àİ½‚ğØ½Ä‚É’Ç‰Á
                frmInstance.Add(strScreenID, frm)
            End If

            ' Ì«°Ñ‚ÌÌßÛÊßÃ¨‚ğ¾¯Ä‚·‚é
            frm.Param = param
            frm.MotoScreenID = motoScreenID

            Return frm
        End Function

        ''' <summary>
        ''' Ì«°ÑID‚æ‚èÌ«°Ñ²İ½Àİ½‚ğæ“¾
        ''' </summary>
        ''' <param name="strScreenID">Ì«°ÑID</param>
        ''' <returns>Ì«°Ñ²İ½Àİ½</returns>
        Private Shared Function GetForm(ByVal strScreenID As String) As Form

            Dim frm As forms.ABCDBCForm = Nothing

            If frmInstance.ContainsKey(strScreenID) Then
                frm = frmInstance.Item(strScreenID)
            End If

            Return frm
        End Function

        ''' <summary>
        ''' w’è•¶š—ñ•K—v•¶š—ñ•ª‚¾‚¯ƒJƒbƒg‚·‚é
        ''' </summary>
        ''' <param name="expression">‘ÎÛ•¶š—ñ</param>
        ''' <param name="startPos">ŠJnØ‚èo‚µ•¶šˆÊ’u</param>
        ''' <param name="cutLength">•K—vØ‚èo‚µ•¶š’·‚³</param>
        ''' <returns>w’èƒoƒCƒg‚©‚çØ‚èo‚µ‚½•¶š</returns>
        Public Shared Function GetMidString(ByVal expression As String, _
                                            ByVal startPos As Integer, _
                                            Optional ByVal cutLength As Integer = 0) As String

            If GetLenString(expression) < startPos Or startPos <= 0 Then
                Return String.Empty
            Else
                ' ŠJnˆÊ’u‚Ü‚Åƒ‹[ƒv
                Dim cnt As Integer = 0
                Dim pos As Integer = 0
                Do While (cnt < startPos)
                    pos += 1
                    cnt += GetLenString(Mid(expression, pos, 1))
                Loop
                ' •¶šØ‚èo‚µ
                Dim ret As String = Mid(expression, pos)
                ' –ß‚è’l‚ğ–ß‚·
                If cutLength > 0 Then
                    Return GetLeftString(ret, cutLength)
                Else
                    Return ret
                End If
            End If

        End Function

        ''' <summary>
        ''' w’èƒoƒCƒg”ˆÈ“à‚Å•Ô‹p
        ''' </summary>
        ''' <param name="expression">‘ÎÛ•¶š—ñ</param>
        ''' <param name="cutLength">•K—vØ‚èo‚µ•¶š’·‚³</param>
        ''' <returns>w’èƒoƒCƒg‚©‚çØ‚èo‚µ‚½•¶š</returns>
        Public Shared Function GetLeftString(ByVal expression As String, _
                                             ByVal cutLength As Integer) As String

            Dim i As Integer
            Dim tmpByteCnt As Integer

            If GetLenString(expression) < cutLength Then
                Return expression
            Else
                ' w’èƒoƒCƒg”(ˆÈ“à)‚É‚È‚éˆÊ’u‚ğ’T‚·
                i = 0
                tmpByteCnt = 0
                Do While (tmpByteCnt < cutLength)
                    i += 1
                    tmpByteCnt += GetLenString(Mid(expression, i, 1))
                Loop
                ' 1ƒoƒCƒgƒI[ƒo[
                If tmpByteCnt > cutLength Then
                    i -= 1
                End If

                Return expression.Substring(0, i)
            End If

        End Function

        ''' <summary>
        ''' w’èƒoƒCƒg”•¶š‚Å•Ô‹p
        ''' </summary>
        ''' <param name="expression">‘ÎÛ•¶š—ñ</param>
        ''' <param name="cutLength">•K—vØ‚èo‚µ•¶š’·‚³</param>
        ''' <returns>•s‘«•ª‚É”¼Šp½Íß°½‚ğ‘‚â‚·</returns>
        Public Shared Function PadRightString(ByVal expression As String, _
                                              ByVal cutLength As Integer) As String

            Dim i As Integer
            Dim tmpByteCnt As Integer
            Dim length As Integer

            length = GetLenString(expression)
            If length < cutLength Then
                Return expression & Space(cutLength - length)
            Else
                ' w’èƒoƒCƒg”(ˆÈ“à)‚É‚È‚éˆÊ’u‚ğ’T‚·
                i = 0
                tmpByteCnt = 0
                Do While (tmpByteCnt < cutLength)
                    i += 1
                    tmpByteCnt += GetLenString(Mid(expression, i, 1))
                Loop
                ' 1ƒoƒCƒgƒI[ƒo[
                If tmpByteCnt > cutLength Then
                    i -= 1
                End If

                Return expression.Substring(0, i)
            End If

        End Function


        ''' <summary>
        ''' •¶š—ñ‚ÌƒoƒCƒg”ŒvZ
        ''' —^‚¦‚ç‚ê‚½•¶š—ñ‚ÌƒoƒCƒg”‚ğ•Ô‚·B
        ''' </summary>
        ''' <param name="expression">•¶š—ñ</param>
        ''' <returns>•¶š—ñ‚ÌƒoƒCƒg”</returns>
        Public Shared Function GetLenString(ByVal expression As String) As Integer
            ' Shift JIS‚É•ÏŠ·‚µ‚½‚Æ‚«‚É•K—v‚ÈƒoƒCƒg”‚ğ•Ô‚·
            If IsDBNull(expression) Or IsNothing(expression) Then
                Return 0
            Else
                Return System.Text.Encoding.GetEncoding(932).GetByteCount(expression)
            End If
        End Function


        ''' <summary>
        ''' ²ÍŞİÄÛ¸Şo—Í
        ''' </summary>
        ''' <param name="screenId">‰æ–ÊID</param>
        ''' <param name="screenName">‰æ–Ê–¼Ì</param>
        ''' <param name="eventTiming">²ÍŞİÄÀ²Ğİ¸Ş</param>
        ''' <param name="eventName">²ÍŞİÄ–¼Ì</param>
        ''' <param name="logLevel">Û¸ŞÚÍŞÙ</param>
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
                        ' ÃŞÊŞ¯¸Ş
                        WriteDebugLog(msg)
                    Case ABCDBCLog.LogLevel.LevelError
                        ' ´×°
                        WriteErrorLog(msg)
                    Case ABCDBCLog.LogLevel.LevelTrace
                        ' ÄÚ°½
                        WriteTraceLog(msg)
                    Case Else
                        ' ‚»‚Ì‘¼
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
