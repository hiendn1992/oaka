''*********************************************************************
''* Copyright Bridgestone Software co.,ltd. 2008
''* システム名   :栃木ロケーションシステム
''* クラス名     :共通クラス
''* 処理概要     :共通クラス
''*********************************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1  08/01/10 1.00 NCS)CHEN        初版
#End Region
''* 1  10/11/11 1.00 NCS)NISHIYAMA   SATOプリンタ対応
''*    11/02/04 1.00 NCS)KIKUKAWA    優先ﾌﾗｸﾞ追加対応
''*    11/02/18 1.00 NCS)OGATA       Webｻｰﾋﾞｽ接続ﾛｸﾞ追加
''*********************************************************************

Imports System.Data
Imports jp.co.ait.common
Imports Bt
Imports System.Security.Cryptography

Namespace common

    ''' <summary>
    ''' BC共通クラス
    ''' </summary>
    Public Class BCCommon
        Inherits ABCDBCBase

#Region "定数"

        Private Const XPRINTER_KBN_XML As String = "PRINT_XML/PRINTER_KBN"

#End Region


#Region "共通変数"

        ''' <summary>ウェーブサービスのURLの文字列</summary>
        Protected Shared webServiceURL As String = String.Empty

        ''' <summary>ﾌｫｰﾑｲﾝｽﾀﾝｽ用ﾘｽﾄ</summary>
        Protected Shared frmInstance As Dictionary(Of String, forms.ABCDBCForm)

        ''' <summary>ウェーブサービスタイムアウト時間</summary>
        Private Shared _webServiceTimeOut As String = String.Empty


#End Region


#Region "ユーザ定義関数"

        ''' <summary>
        ''' ウェーブサービスタイムアウト時間を取得
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetWebServiceTimeOut(ByVal isLogin As Boolean) As Integer
            ' ログインする時だけクリア
            If isLogin Then
                _webServiceTimeOut = String.Empty
            End If
            ' ウェーブサービスタイムアウト時間を取得
            If _webServiceTimeOut.Equals(String.Empty) Then
                _webServiceTimeOut = ABCDBCXmlManager.GetFileData("WEBSVR/TIME_INTERVAL")
            End If
            Return CType(_webServiceTimeOut, Integer)
        End Function

        ''' <summary>
        ''' カレントフォルダパス取得
        ''' </summary>
        ''' <returns>カレントフォルダパス</returns>
        Public Shared Function GetCurrentDir() As String
            ' 完全なディレクトリと exe 名を取得
            Dim fullAppName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
            ' exe 名を除外
            Return System.IO.Path.GetDirectoryName(fullAppName) & "\"
        End Function

        ''' <summary>
        ''' ウェーブサービスのURLを取得する
        ''' </summary>
        ''' <returns>ウェーブサービスのURLの文字列</returns>
        Public Shared Function GetWebHttpURL() As String
            ' ウェーブサービスのURLを取得する
            If webServiceURL.Equals(String.Empty) Then
                webServiceURL = ABCDBCXmlManager.GetFileData("WEBSVR/URL")
            End If
            Return webServiceURL
        End Function

        ''' <summary>
        ''' ﾒｲﾝ画面をﾘｽﾄに追加
        ''' </summary>
        Public Shared Sub AddMainMenuFrmInstance()
            frmInstance = New Dictionary(Of String, forms.ABCDBCForm)
            'frmInstance.Add(BCConst.LWHBC001F, My.Forms.frm_LWHBC001F)
        End Sub

        ''' <summary>
        ''' ﾌｫｰﾑIDより画面を表示する
        ''' </summary>
        ''' <param name="screenID">ﾌｫｰﾑID</param>
        ''' <param name="param">画面のﾊﾟﾗﾒｰﾀﾌﾟﾛﾊﾟﾃｨ(DataSet)</param>
        ''' <param name="motoScreenID">画面の遷移元画面IDﾌﾟﾛﾊﾟﾃｨ</param>
        Public Shared Sub ShowForm(ByVal screenID As String, _
                                   Optional ByVal param As DataSet = Nothing, _
                                   Optional ByVal motoScreenID As String = "")

            Dim frm As Form = GetForm(screenID, param, motoScreenID)
            Application.DoEvents()
            frm.Show()
        End Sub

        ''' <summary>
        ''' ﾌｫｰﾑIDより画面を表示する(ShowDialog)
        ''' </summary>
        ''' <param name="screenID">ﾌｫｰﾑID</param>
        ''' <param name="param">画面のﾊﾟﾗﾒｰﾀﾌﾟﾛﾊﾟﾃｨ(DataSet)</param>
        ''' <param name="motoScreenID">画面の遷移元画面IDﾌﾟﾛﾊﾟﾃｨ</param>
        Public Shared Function ShowDialogForm(ByVal screenID As String, _
                                         Optional ByVal param As DataSet = Nothing, _
                                         Optional ByVal motoScreenID As String = "") As DialogResult

            Dim frm As Form = GetForm(screenID, param, motoScreenID)

            Application.DoEvents()
            Return frm.ShowDialog()

        End Function

        ''' <summary>
        ''' ﾌｫｰﾑIDより画面をｸﾛｰｽﾞ
        ''' </summary>
        ''' <param name="screenID">ﾌｫｰﾑID</param>
        ''' <param name="showFormID">画面を閉じた後、表示する画面のID</param>
        ''' <param name="param">表示画面のﾊﾟﾗﾒｰﾀﾌﾟﾛﾊﾟﾃｨ�(DataSet)</param>
        ''' <param name="motoScreenID">表示画面の遷移元画面IDﾌﾟﾛﾊﾟﾃｨ</param>
        Public Shared Sub CloseForm(ByVal screenID As String, _
                                    Optional ByVal showFormID As String = "", _
                                    Optional ByVal param As DataSet = Nothing, _
                                    Optional ByVal motoScreenID As String = "")

            Dim frm As Form

            If Not showFormID.Equals(String.Empty) Then
                ' ﾌｫｰﾑを表示
                ShowForm(showFormID, param, motoScreenID)
            End If

            If frmInstance.ContainsKey(screenID) Then
                frm = frmInstance.Item(screenID)
                Dim screenName As String = DirectCast(frm, forms.ABCDBCForm).ScreenName

                WriteEventLog(screenID, _
                              screenName, _
                              "開始", _
                              "ﾌｫｰﾑｱﾝﾛｰﾄﾞ")

                frm.Close()
                frm.Dispose()
                frm = Nothing

                WriteEventLog(screenID, _
                              screenName, _
                              "終了", _
                              "ﾌｫｰﾑｱﾝﾛｰﾄﾞ")

                ' 閉じた画面のｲﾝｽﾀﾝｽをﾘｽﾄより削除
                frmInstance.Remove(screenID)

                'If screenID.Equals(BCConst.LWHBC001F) Then
                '    ' ﾒｲﾝ画面を閉じる場合、ﾌﾟﾛｸﾞﾗﾑを終了(基本がない)
                '    Application.Exit()
                'End If

            End If

        End Sub

        ''' <summary>
        ''' ﾌｫｰﾑIDよりﾌｫｰﾑｲﾝｽﾀﾝｽを取得
        ''' </summary>
        ''' <param name="strScreenID">ﾌｫｰﾑID</param>
        ''' <param name="param">表示画面のﾊﾟﾗﾒｰﾀﾌﾟﾛﾊﾟﾃｨ�(DataSet)</param>
        ''' <param name="motoScreenID">画面の遷移元画面IDﾌﾟﾛﾊﾟﾃｨ</param>
        ''' <returns>ﾌｫｰﾑｲﾝｽﾀﾝｽ</returns>
        Private Shared Function GetForm(ByVal strScreenID As String, _
                                        ByVal param As DataSet, _
                                        ByVal motoScreenID As String) As Form

            Dim strType As Type
            Dim frm As forms.ABCDBCForm = Nothing

            If frmInstance.ContainsKey(strScreenID) Then
                frm = frmInstance.Item(strScreenID)
            Else
                ' ﾌｫｰﾑの名称を設定する
                Dim str As String = "jp.co.ait.LWHBC." & strScreenID.Substring(0, 6) & ".frm_" + strScreenID

                strType = Type.GetType(str)
                If (strType Is Nothing) Then
                    str = "jp.co.ait.LWHBC.frm_" & strScreenID
                    strType = Type.GetType(str)
                End If

                If Not (strType Is Nothing) Then
                    frm = CType(Activator.CreateInstance(strType), forms.ABCDBCForm)
                End If

                ' ﾌｫｰﾑｲﾝｽﾀﾝｽをﾘｽﾄに追加
                frmInstance.Add(strScreenID, frm)
            End If

            ' ﾌｫｰﾑのﾌﾟﾛﾊﾟﾃｨをｾｯﾄする
            frm.Param = param
            frm.MotoScreenID = motoScreenID

            Return frm
        End Function

        ''' <summary>
        ''' ﾌｫｰﾑIDよりﾌｫｰﾑｲﾝｽﾀﾝｽを取得
        ''' </summary>
        ''' <param name="strScreenID">ﾌｫｰﾑID</param>
        ''' <returns>ﾌｫｰﾑｲﾝｽﾀﾝｽ</returns>
        Private Shared Function GetForm(ByVal strScreenID As String) As Form

            Dim frm As forms.ABCDBCForm = Nothing

            If frmInstance.ContainsKey(strScreenID) Then
                frm = frmInstance.Item(strScreenID)
            End If

            Return frm
        End Function

        ''' <summary>
        ''' 指定文字列必要文字列分だけカットする
        ''' </summary>
        ''' <param name="expression">対象文字列</param>
        ''' <param name="startPos">開始切り出し文字位置</param>
        ''' <param name="cutLength">必要切り出し文字長さ</param>
        ''' <returns>指定バイトから切り出した文字</returns>
        Public Shared Function GetMidString(ByVal expression As String, _
                                            ByVal startPos As Integer, _
                                            Optional ByVal cutLength As Integer = 0) As String

            If GetLenString(expression) < startPos Or startPos <= 0 Then
                Return String.Empty
            Else
                ' 開始位置までループ
                Dim cnt As Integer = 0
                Dim pos As Integer = 0
                Do While (cnt < startPos)
                    pos += 1
                    cnt += GetLenString(Mid(expression, pos, 1))
                Loop
                ' 文字切り出し
                Dim ret As String = Mid(expression, pos)
                ' 戻り値を戻す
                If cutLength > 0 Then
                    Return GetLeftString(ret, cutLength)
                Else
                    Return ret
                End If
            End If

        End Function

        ''' <summary>
        ''' 指定バイト数以内で返却
        ''' </summary>
        ''' <param name="expression">対象文字列</param>
        ''' <param name="cutLength">必要切り出し文字長さ</param>
        ''' <returns>指定バイトから切り出した文字</returns>
        Public Shared Function GetLeftString(ByVal expression As String, _
                                             ByVal cutLength As Integer) As String

            Dim i As Integer
            Dim tmpByteCnt As Integer

            If GetLenString(expression) < cutLength Then
                Return expression
            Else
                ' 指定バイト数(以内)になる位置を探す
                i = 0
                tmpByteCnt = 0
                Do While (tmpByteCnt < cutLength)
                    i += 1
                    tmpByteCnt += GetLenString(Mid(expression, i, 1))
                Loop
                ' 1バイトオーバー時
                If tmpByteCnt > cutLength Then
                    i -= 1
                End If

                Return expression.Substring(0, i)
            End If

        End Function

        ''' <summary>
        ''' 指定バイト数文字で返却
        ''' </summary>
        ''' <param name="expression">対象文字列</param>
        ''' <param name="cutLength">必要切り出し文字長さ</param>
        ''' <returns>不足分に半角ｽﾍﾟｰｽを増やす</returns>
        Public Shared Function PadRightString(ByVal expression As String, _
                                              ByVal cutLength As Integer) As String

            Dim i As Integer
            Dim tmpByteCnt As Integer
            Dim length As Integer

            length = GetLenString(expression)
            If length < cutLength Then
                Return expression & Space(cutLength - length)
            Else
                ' 指定バイト数(以内)になる位置を探す
                i = 0
                tmpByteCnt = 0
                Do While (tmpByteCnt < cutLength)
                    i += 1
                    tmpByteCnt += GetLenString(Mid(expression, i, 1))
                Loop
                ' 1バイトオーバー時
                If tmpByteCnt > cutLength Then
                    i -= 1
                End If

                Return expression.Substring(0, i)
            End If

        End Function


        ''' <summary>
        ''' 文字列のバイト数計算
        ''' 与えられた文字列のバイト数を返す。
        ''' </summary>
        ''' <param name="expression">文字列</param>
        ''' <returns>文字列のバイト数</returns>
        Public Shared Function GetLenString(ByVal expression As String) As Integer
            ' Shift JISに変換したときに必要なバイト数を返す
            If IsDBNull(expression) Or IsNothing(expression) Then
                Return 0
            Else
                Return System.Text.Encoding.GetEncoding(932).GetByteCount(expression)
            End If
        End Function


        ''' <summary>
        ''' ｲﾍﾞﾝﾄﾛｸﾞ出力
        ''' </summary>
        ''' <param name="screenId">画面ID</param>
        ''' <param name="screenName">画面名称</param>
        ''' <param name="eventTiming">ｲﾍﾞﾝﾄﾀｲﾐﾝｸﾞ</param>
        ''' <param name="eventName">ｲﾍﾞﾝﾄ名称</param>
        ''' <param name="logLevel">ﾛｸﾞﾚﾍﾞﾙ</param>
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
                        ' ﾃﾞﾊﾞｯｸﾞ
                        WriteDebugLog(msg)
                    Case ABCDBCLog.LogLevel.LevelError
                        ' ｴﾗｰ
                        WriteErrorLog(msg)
                    Case ABCDBCLog.LogLevel.LevelTrace
                        ' ﾄﾚｰｽ
                        WriteTraceLog(msg)
                    Case Else
                        ' その他
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
