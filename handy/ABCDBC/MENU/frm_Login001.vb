Imports jp.co.ait.ABCDBC.common
Imports System.Net
Imports jp.co.ait.common
Imports System.IO

Public Class frm_Login001

#Region "CONSTRUCTOR"
    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        txt_USERNM.Focus()

    End Sub
#End Region

#Region " EVENTS "
    ''' <summary>
    ''' pnl_Ok_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Ok.Click
        Try
            WriteEventStartLog("pnl_Ok_Click")
            login_Pnl_Ok()
        Catch ex As Exception
            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
        Finally
            Cursor.Current = Cursors.Default
            WriteEventEndLog("pnl_Ok_Click")
        End Try
    End Sub

    ''' <summary>
    ''' frm_Login001_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_Login001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp, txt_USERNM.KeyUp, txt_PASSWD.KeyUp
        If e.KeyCode = Keys.F1 Then
            Try
                WriteEventStartLog("frm_Login001_KeyUp")
                login_Pnl_Ok()
            Catch ex As Exception
                WriteDebugLog(ex.Message)
                ShowSystemMessageForm()
            Finally
                Cursor.Current = Cursors.Default
                WriteEventEndLog("frm_Login001_KeyUp")
            End Try
        ElseIf e.KeyCode = Keys.F2 Then
            Me.Close()
        End If
    End Sub


    ''' <summary>
    ''' pnl_Cancel_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Cancel.Click
        Me.Close()
    End Sub
#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' login_Pnl_Ok
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub login_Pnl_Ok()

        Call DeleteLogFiles() 'AIT) cuongtk 2016-Jan-04.

        Dim strTitle As String = "Login Error"
        Dim retData As New DataSet
        Dim webSrv As New WebService.Service
        Dim ret As New Integer
        Dim authority As String = ""
        Dim formAdmin As New frm_Menu001
        Dim formPR As New frm_Menu002
        Dim formFG As New frm_Menu003
        Dim formLG As New frm_Login001

        If Trim(txt_USERNM.Text).Length = 0 Then

            ShowMessageForm("MSG001", strTitle)
            txt_USERNM.Focus()
            Exit Sub
        ElseIf Trim(txt_PASSWD.Text).Length = 0 Then

            ShowMessageForm("MSG002", strTitle)
            txt_USERNM.Focus()
            Exit Sub
            'ElseIf Trim(txt_USERNM.Text).Length < 6 Then
            '    ShowMessageForm("MSG003", strTitle)
            '    txt_USERNM.Focus()
            '    Exit Sub
        ElseIf Trim(txt_PASSWD.Text).Length < 6 Then
            ShowMessageForm("MSG004", strTitle)
            txt_USERNM.Focus()
            Exit Sub
        End If
        Try
            Cursor.Current = Cursors.WaitCursor

            webSrv.Url = BCCommon.GetWebHttpURL()
            webSrv.Timeout = BCCommon.GetWebServiceTimeOut(True)
            ServicePointManager.CertificatePolicy = New MyCertificateValidation()

            Dim decryptData As New EncryptDecryptVB("password") '// Khai bao lop ma hoa va giai ma
            Dim password As String = decryptData.EncryptData(txt_PASSWD.Text) '// Ma hoa gia tri duoc nhap vao

            ret = webSrv.GetUserInfoProccess(txt_USERNM.Text, password.Substring(0, 6))
            If ret = 1 Then
                ShowMessageForm("ERR001", strTitle)
                txt_USERNM.Focus()
                Exit Sub
            ElseIf ret = 2 Then
                ShowMessageForm("ERR002", strTitle)
                txt_USERNM.Focus()
                Exit Sub
            ElseIf ret = 0 Then

                retData = webSrv.GetDataInUserMasterMS(txt_USERNM.Text)
                If retData.Tables(0).Rows.Count > 0 Then
                    authority = retData.Tables(0).Rows(0)("AUTHORITY").ToString
                    BCLoginManager.CreateLoginInfo(txt_USERNM.Text, authority)
                    'txt_USERNM.Visible = False
                    'txt_PASSWD.Visible = False
                    'lbl_PASSWD.Text = txt_USERNM.Text
                    formLG.Hide()
                    If "1".Equals(authority) Then
                        formAdmin.Show()
                        Exit Sub
                    ElseIf "2".Equals(authority) Then
                        formPR.Show()
                        Exit Sub
                    ElseIf "3".Equals(authority) Then
                        formFG.Show()
                        Exit Sub
                    ElseIf "4".Equals(authority) Then
                        ShowMessageForm("ERR003", strTitle)
                        txt_USERNM.Focus()
                        Exit Sub
                    End If
                End If
            End If

        Catch ex As System.Net.WebException

            Cursor.Current = Cursors.Default
            WriteDebugLog(ex.Message)
            ShowMessageForm("BC901", strTitle)
            Me.Activate()
            Exit Sub
        Catch ex As Exception

            Cursor.Current = Cursors.Default
            WriteDebugLog(ex.Message)
            ShowSystemMessageForm()
            Me.Activate()
            Exit Sub

        Finally
            webSrv.Dispose()
            webSrv = Nothing
        End Try
    End Sub


    'AIT) cuongtk 2016-Jan-04 - start
    ''' <summary>
    ''' ﾛｸﾞﾌｧｲﾙの世帯管理
    ''' </summary>
    Private Sub DeleteLogFiles()
        ' ﾌｧｲﾙ削除期間(日数)
        Dim fileDeleteInterval As Integer
        fileDeleteInterval = Convert.ToInt32(ABCDBCXmlManager.GetFileData("BC_LOG/DELETE_INTERVAL"))
        ' ﾛｸﾞﾌｧｲﾙﾊﾟｽを取得
        Dim logFilePath As String = ABCDBCXmlManager.GetFileData("BC_LOG/FILE_DIR")
        If String.IsNullOrEmpty(logFilePath) Then
            logFilePath = ABCDBCCommon.GetCurrentDir
        End If
        ' ﾛｸﾞﾌｧｲﾙﾊﾟｽに時効切れのﾌｧｲﾙを削除する
        For Each fileName As String In Directory.GetFiles(logFilePath)
            If DateDiff(DateInterval.Day, File.GetLastWriteTime(fileName), Now) > fileDeleteInterval Then
                File.Delete(fileName)
            End If
        Next
    End Sub
    'AIT) cuongtk 2016-Jan-04 - end
#End Region

End Class