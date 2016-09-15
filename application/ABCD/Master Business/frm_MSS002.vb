''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS002.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   05-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_MSS002

#Region "Var/Const Form."

    ''' <summary> Web service. </summary>
    Private wbService As New ABCDService.Service

#End Region

#Region "New Form."

    ''' <summary>
    ''' New form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Call InitForm()
        wbService.Url = ABCDConst.STRING_URL '' If want call web service have ip address.
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT) '' Set time out for web service.
        '' Get focus at current password.
        tb_cur_pwd.Focus()
        tb_cur_pwd.SelectAll()
    End Sub

#End Region

#Region "Event Form."

    ''' <summary>
    ''' Event leave current password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cur_pwd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cur_pwd.Leave
        Dim controls As New List(Of Control)(New Control() {tb_usr_id, _
                                                            tb_usr_name, _
                                                            tb_new_pwd, _
                                                            tb_conf_new_pwd, _
                                                            b_change, _
                                                            b_exit})
        '' Other controls focused.
        If ProcessLeave(controls) = False Then
            Return
        End If

        '' Check current password is null or blank.
        If tb_cur_pwd.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR022, "ERR022")
            scrError.Show()
            tb_cur_pwd.Focus()
            Return
        End If

        '' Check length current password less 6 char.
        If tb_cur_pwd.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.Show()
            tb_cur_pwd.Focus()
            tb_cur_pwd.SelectAll()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event leave new password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_new_pwd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_new_pwd.Leave
        Dim controls As New List(Of Control)(New Control() {tb_usr_id, _
                                                            tb_usr_name, _
                                                            tb_cur_pwd, _
                                                            tb_conf_new_pwd, _
                                                            b_change, _
                                                            b_exit})
        '' Other controls focused.
        If ProcessLeave(controls) = False Then
            Return
        End If

        '' Check new password is null or blank.
        If tb_new_pwd.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR023, "ERR023")
            scrError.Show()
            tb_new_pwd.Focus()
            Return
        End If

        '' Check length new password less 6 char.
        If tb_new_pwd.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.Show()
            tb_new_pwd.Focus()
            tb_new_pwd.SelectAll()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event leave confirm new password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_conf_new_pwd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_conf_new_pwd.Leave
        Dim controls As New List(Of Control)(New Control() {tb_usr_id, _
                                                            tb_usr_name, _
                                                            tb_cur_pwd, _
                                                            tb_new_pwd, _
                                                            b_change, _
                                                            b_exit})
        '' Other controls focused.
        If ProcessLeave(controls) = False Then
            Return
        End If

        '' Check confirm new password is null or blank.
        If tb_conf_new_pwd.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR025, "ERR025")
            scrError.Show()
            tb_conf_new_pwd.Focus()
            Return
        End If

        '' Check length confirm new password less 6 char.
        If tb_conf_new_pwd.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.Show()
            tb_conf_new_pwd.Focus()
            tb_conf_new_pwd.SelectAll()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event click change.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_change.Click
        '' Call method ChangePassword().
        Call ChangePassword()
    End Sub

    ''' <summary>
    ''' Event click exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

#End Region

#Region "Function Form."

    ''' <summary>
    ''' Method new form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitForm()
        tb_usr_id.ReadOnly = True
        tb_usr_name.ReadOnly = True
        tb_usr_id.Text = ABCDCommon.UserId
        tb_usr_name.Text = ABCDCommon.UserName
        '' decrypt data.
        Dim decryptData As New ABCDCommon.EncryptDecryptVB("password")
        tb_cur_pwd.Text = decryptData.DecryptData(ABCDCommon.Password)
    End Sub

    ''' <summary>
    ''' Method check all controls is focused for event leave.
    ''' </summary>
    ''' <param name="controls"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ProcessLeave(ByVal controls As List(Of Control)) As Boolean
        For i As Integer = 0 To controls.Count - 1 Step 1
            If controls(i).Focused Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Method execute change password of login user.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangePassword()
        ''encrypt data.
        Dim encryptData As New ABCDCommon.EncryptDecryptVB("password")

        '' Check current password is null or blank.
        If tb_cur_pwd.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR022, "ERR022")
            scrError.Show()
            tb_cur_pwd.Focus()
            Return
        End If

        '' Check length current password less 6 char.
        If tb_cur_pwd.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.Show()
            tb_cur_pwd.Focus()
            tb_cur_pwd.SelectAll()
            Return
        End If

        '' Check current password input from keyboard same password login.
        If Not tb_cur_pwd.Text.Equals(encryptData.DecryptData(ABCDCommon.Password)) Then
            Dim scrError As New frm_MSG001(Messages.ERR026, "ERR026")
            scrError.Show()
            tb_cur_pwd.Focus()
            tb_cur_pwd.SelectAll()
            Return
        End If

        '' Check new password is null or blank.
        If tb_new_pwd.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR023, "ERR023")
            scrError.Show()
            tb_new_pwd.Focus()
            Return
        End If

        '' Check length new password less 6 char.
        If tb_new_pwd.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.Show()
            tb_new_pwd.Focus()
            tb_new_pwd.SelectAll()
            Return
        End If

        '' Check confirm new password is null or blank.
        If tb_conf_new_pwd.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR025, "ERR025")
            scrError.Show()
            tb_conf_new_pwd.Focus()
            Return
        End If

        '' Check length confirm new password less 6 char.
        If tb_conf_new_pwd.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.Show()
            tb_conf_new_pwd.Focus()
            tb_conf_new_pwd.SelectAll()
            Return
        End If

        '' Check new password same confirm new password.
        If Not tb_new_pwd.Text.Equals(tb_conf_new_pwd.Text) Then
            Dim scrError As New frm_MSG001(Messages.ERR027, "ERR027")
            scrError.Show()
            tb_conf_new_pwd.Focus()
            tb_conf_new_pwd.SelectAll()
            Return
        End If

        Try
            '' Call service execute change password.
            Dim num As Integer = wbService.ChangeUserPassword(ABCDCommon.UserId, encryptData.EncryptData(tb_new_pwd.Text))

            If num = 1 Then '' num = 1: Update password successful.
                Dim scrInfo As New frm_MSG001(Messages.INF028, "INF028")
                If scrInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                    scrInfo.Close()
                    tb_cur_pwd.Text = tb_new_pwd.Text '' Set value current password into value new password.
                    ABCDCommon.Password = tb_new_pwd.Text '' Set value password login user common into new password.
                    tb_new_pwd.Text = Nothing
                    tb_conf_new_pwd.Text = Nothing
                    tb_cur_pwd.Focus()
                    tb_cur_pwd.SelectAll()
                    Return
                End If
            End If
        Catch ex As Exception
            Dim scrErrorSys As New frm_MSG001(ex.Message, "ERRSYS")
            scrErrorSys.Show()
            Return
        End Try
    End Sub

#End Region

End Class