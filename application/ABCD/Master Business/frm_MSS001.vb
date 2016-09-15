''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS001.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   14-DEC-14    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources
Imports System.Text.RegularExpressions


Public Class frm_MSS001

#Region "Var/Const Form"

    ''' <summary> Web service. </summary>
    Private wbService As New ABCDService.Service
    ''' <summary> Login user. </summary>
    Private loginCode As String = ABCDCommon.UserId
    ''' <summary> Mode process. </summary>
    Public _mode As Integer = ABCDConst.ModeInit
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
        End Set
    End Property
    ''' <summary> Display controls. </summary>
    Private _display As Integer = ABCDConst.DispInit
    Public Property Display() As Integer
        Get
            Return _display
        End Get
        Set(ByVal value As Integer)
            _display = value
        End Set
    End Property

    Private _beforePassword As String = ""
    Public Property BeforePassword() As String
        Get
            Return _beforePassword
        End Get
        Set(ByVal value As String)
            _beforePassword = value
        End Set
    End Property

#End Region

#Region "New Form"

    ''' <summary>
    ''' New form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()
        Call NewForm()
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        With tb_user_id
            .ImeMode = Windows.Forms.ImeMode.Disable
        End With
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Event checked radio add user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_add_user_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rb_add_user.CheckedChanged
        Me.Mode = ABCDConst.ModeAdd '// Set mode process.
        Me.Display = ABCDConst.DispOnce '// Set state display form.
        Call CheckRadioUser(Me.Mode) '// Call method CheckRadioUser.
        tb_user_id.Focus() '// Focus user id.
    End Sub

    ''' <summary>
    ''' Event checked radio change user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_change_user_CheckedChanged(sender As System.Object, e As System.EventArgs) _
        Handles rb_change_user.CheckedChanged
        Me.Mode = ABCDConst.ModeUpd '' Set mode process.
        Me.Display = ABCDConst.DispOnce '' Set state display form.

        Call CheckRadioUser(Me.Mode) '' Call method CheckRadioUser.
        tb_user_id.Focus() '' Focus user id.

    End Sub

    ''' <summary>
    ''' Event checked radio delete user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_delete_user_CheckedChanged(sender As System.Object, e As System.EventArgs) _
        Handles rb_delete_user.CheckedChanged
        Me.Mode = ABCDConst.ModeDel
        Me.Display = ABCDConst.DispOnce

        Call CheckRadioUser(Me.Mode)
        tb_user_id.Focus()
    End Sub

    ''' <summary>
    ''' Event click exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(sender As System.Object, e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Event click cancel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(sender As System.Object, e As System.EventArgs) Handles b_cancel.Click
        Call ClickCancel(Me.Display, _
                         Me.Mode) '' Call method ClickCancel.
    End Sub

    ''' <summary>
    ''' Event click execute.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_execute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_execute.Click
        '' Check user name is null or blank.
        If tb_user_name.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR031, "ERR031")
            scrError.ShowDialog()
            tb_user_name.Focus()
            Return
        End If

        '' Check password is null or blank.
        If Me.tb_password.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR032, "ERR032")
            scrError.ShowDialog()
            tb_password.Focus()
            Return
        End If

        '' Check length password less 6 chars.
        If Me.tb_password.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.ShowDialog()
            tb_password.Focus()
            tb_password.SelectAll()
            Return
        End If

        '' Check value authority diff zero.
        If cb_authority.SelectedValue = 0 Then
            Dim scrError As New frm_MSG001(Messages.ERR033, "ERR033")
            scrError.ShowDialog()
            cb_authority.Focus()
            Return
        End If

        Call Me.ClickExecute(Me.Mode)
    End Sub

    ''' <summary>
    ''' Leave user id.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_user_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_user_id.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {b_popup_user, b_exit, b_cancel})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check user id is null or blank.
        If tb_user_id.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR021, "ERR021")
            scrError.ShowDialog()
            tb_user_id.Focus()
            Return
        End If

        '' Check length user id less 6 char.
        'If tb_user_id.Text.Length < 6 Then
        '    Dim scrError As New frm_MSG001(Messages.ERR029, "ERR029")
        '    scrError.ShowDialog()
        '    tb_user_id.Focus()
        '    tb_user_id.SelectAll()
        '    Return
        'End If

        '' Check user id in case delete user have using by system.
        If Me.Mode = 3 And Me.tb_user_id.Text.Equals(ABCDCommon.UserId) Then
            Dim scrError As New frm_MSG001(Messages.ERR030, "ERR030")
            scrError.ShowDialog()
            tb_user_id.Focus()
            tb_user_id.SelectAll()
            Return
        End If

        '' Check data exist or not exist in DB.
        If Not Me.CheckDatabase(Me.tb_user_id.Text, ABCDCommon.UserId, Me.Mode) Then
            Return
        End If
        
        Call Me.DisplayAfterLeaveUserId(Me.Mode)

        '' Focus user name.
        tb_user_name.Focus()
    End Sub

    ''' <summary>
    ''' Event leave user name.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_user_name_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_user_name.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {tb_password, tb_remark, cb_authority, b_execute, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            tb_user_name.Text = RTrim(LTrim(tb_user_name.Text)) '' Case first chars in string is space.
            tb_user_name.Text = Regex.Replace(tb_user_name.Text, " {2,}", " ")
            Return
        End If

        '' Check user name is null or blank.
        If tb_user_name.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR031, "ERR031")
            scrError.ShowDialog()
            tb_user_name.Focus()
            Return
        End If
        
        tb_user_name.Text = RTrim(LTrim(tb_user_name.Text)) '' Left Trim to cut space char at first string.
        tb_user_name.Text = Regex.Replace(tb_user_name.Text, " {2,}", " ")
        tb_password.Focus()
    End Sub

    ''' <summary>
    ''' Event leave password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_password_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_password.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {tb_user_name, tb_remark, cb_authority, b_execute, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check password is null or blank.
        If Me.tb_password.Text.Equals("") Then
            Dim scrError As New frm_MSG001(Messages.ERR032, "ERR032")
            scrError.ShowDialog()
            tb_password.Focus()
            Return
        End If

        '' Check length password less 6 chars.
        If Me.tb_password.Text.Length < 6 Then
            Dim scrError As New frm_MSG001(Messages.ERR024, "ERR024")
            scrError.ShowDialog()
            tb_password.Focus()
            tb_password.SelectAll()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event leave authority.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cb_authority_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_authority.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {tb_user_name, tb_password, tb_remark, b_execute, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check value authority diff zero.
        If cb_authority.SelectedValue = 0 Then
            Dim scrError As New frm_MSG001(Messages.ERR033, "ERR033")
            scrError.ShowDialog()
            cb_authority.Focus()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event click popup user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_popup_user.Click
        '' Call form Popup Select User.
        Dim frmPOS004 As New frm_POS004(Me)
        If frmPOS004.ShowDialog = Windows.Forms.DialogResult.Ignore Then
            tb_user_id.Focus()
            tb_user_id.SelectAll()
            Return
        End If
        '' Check user id in case delete user have using by system.
        If Me.Mode = 3 And Me.tb_user_id.Text.Equals(ABCDCommon.UserId) Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR030, "ERR030")
            frmMsg001.ShowDialog()
            tb_user_id.Focus()
            tb_user_id.SelectAll()
            Return
        End If
        If Not tb_user_id.Text.Equals("") Then
            '' Check data exist or not exist in DB.
            If Not Me.CheckDatabase(tb_user_id.Text, ABCDCommon.UserId, Me.Mode) Then
                Return
            End If
            Call Me.DisplayAfterLeaveUserId(Me.Mode)
            tb_user_name.Focus()
            tb_user_name.SelectAll()
            Return
        End If
        tb_user_id.Focus()
        tb_user_id.SelectAll()
        Return
    End Sub

    ''' <summary>
    ''' Event changed text: check event input special chars from keyboard.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_user_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_user_id.TextChanged
        tb_user_id.Text = Regex.Replace(tb_user_id.Text, ABCDConst.Special_Char, "") '' Replace all special chars.
        tb_user_id.SelectionStart = tb_user_id.Text.Length '' Set focus last position input.
    End Sub

    ''' <summary>
    ''' Event changed text: check event input special chars from keyboard.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_password.TextChanged
        tb_password.Text = Regex.Replace(tb_password.Text, ABCDConst.Special_Char, "") '' Replace all special chars.
        tb_password.SelectionStart = tb_password.Text.Length '' Set focus last position input.
    End Sub

#End Region

#Region "Function Form"

    ''' <summary>
    ''' Method new form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NewForm()
        rb_add_user.Checked = CheckState.Unchecked
        rb_change_user.Checked = CheckState.Unchecked
        rb_delete_user.Checked = CheckState.Unchecked

        rb_add_user.Enabled = True
        rb_change_user.Enabled = True
        rb_delete_user.Enabled = True

        tb_user_id.Text = Nothing
        tb_user_name.Text = Nothing
        tb_password.Text = Nothing
        cb_authority.Text = Nothing
        tb_remark.Text = Nothing

        tb_user_id.Enabled = False
        tb_user_name.Enabled = False
        tb_password.Enabled = False
        cb_authority.Enabled = False
        tb_remark.Enabled = False

        b_popup_user.Enabled = False
        b_execute.Enabled = False
        b_cancel.Enabled = False
        b_exit.Enabled = True

        cb_authority.DataSource = wbService.GetCodeMasterMS(ABCDConst.Type_Authority, ABCDCommon.UserId).Tables(0)
        cb_authority.DisplayMember = "CODE_NAME"
        cb_authority.ValueMember = "CODE_02"
    End Sub

    ''' <summary>
    ''' Method check radio user: Add, Change, Delete.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub CheckRadioUser(ByVal mode As Integer)
        If mode = 1 Then
            rb_add_user.Enabled = False
            rb_change_user.Enabled = False
            rb_delete_user.Enabled = False

            tb_user_id.Enabled = True

            b_cancel.Enabled = True

            Return
        End If

        If mode = 2 Then
            rb_add_user.Enabled = False
            rb_change_user.Enabled = False
            rb_delete_user.Enabled = False

            tb_user_id.Enabled = True
            b_popup_user.Enabled = True

            b_cancel.Enabled = True

            Return
        End If

        If mode = 3 Then
            rb_add_user.Enabled = False
            rb_change_user.Enabled = False
            rb_delete_user.Enabled = False

            tb_user_id.Enabled = True
            b_popup_user.Enabled = True

            b_cancel.Enabled = True

            Return
        End If
    End Sub

    ''' <summary>
    ''' Method cancel.
    ''' </summary>
    ''' <param name="display"></param>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub ClickCancel(ByVal display As Integer, _
                            ByVal mode As Integer)
        If display = 1 Then
            RemoveHandler rb_add_user.CheckedChanged, AddressOf rb_add_user_CheckedChanged
            rb_add_user.Checked = CheckState.Unchecked
            AddHandler rb_add_user.CheckedChanged, AddressOf rb_add_user_CheckedChanged
            RemoveHandler rb_change_user.CheckedChanged, AddressOf rb_change_user_CheckedChanged
            rb_change_user.Checked = CheckState.Unchecked
            AddHandler rb_change_user.CheckedChanged, AddressOf rb_change_user_CheckedChanged
            RemoveHandler rb_delete_user.CheckedChanged, AddressOf rb_delete_user_CheckedChanged
            rb_delete_user.Checked = CheckState.Unchecked
            AddHandler rb_delete_user.CheckedChanged, AddressOf rb_delete_user_CheckedChanged

            rb_add_user.Enabled = True
            rb_change_user.Enabled = True
            rb_delete_user.Enabled = True

            tb_user_id.Text = Nothing
            tb_user_id.Enabled = False

            If mode = 2 Or mode = 3 Then
                b_popup_user.Enabled = False
            End If

            b_cancel.Enabled = False

            Me.Display = 0
            Return
        End If

        If display = 2 Then
            tb_user_name.Text = Nothing
            tb_password.Text = Nothing
            tb_remark.Text = Nothing
            cb_authority.SelectedValue = 0

            tb_user_id.Enabled = True

            If mode = 2 Or mode = 3 Then
                b_popup_user.Enabled = True
            End If

            tb_user_name.Enabled = False
            tb_password.Enabled = False
            tb_remark.Enabled = False
            cb_authority.Enabled = False

            b_execute.Enabled = False

            Me.Display = 1
            Return
        End If
    End Sub

    ''' <summary>
    ''' Method check DB.
    ''' </summary>
    ''' <param name="userCode"></param>
    ''' <param name="loginCode"></param>
    ''' <param name="mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDatabase(ByVal userCode As String, _
                                   ByVal loginCode As String, _
                                   ByVal mode As Integer) As Boolean
        Dim ds As DataSet = wbService.GetUserInfoByID(userCode, mode)
        Dim rNum As Integer = ds.Tables(0).Rows.Count

        If mode = 1 Then
            If rNum = 1 Then
                Dim msgError As String = "This User Id is exist!"
                Dim scrError As New frm_MSG001(msgError, "ERR011")

                If scrError.ShowDialog = Windows.Forms.DialogResult.OK Then
                    scrError.Close()
                    tb_user_id.Focus()
                    tb_user_id.SelectAll()

                    Return False
                End If
            End If

            Return True
        End If

        If mode = 2 Or mode = 3 Then
            If rNum = 0 Then
                Dim msgError As String = "This User Id is not exist!"
                Dim scrError As New frm_MSG001(msgError, "ERR012")

                If scrError.ShowDialog = Windows.Forms.DialogResult.OK Then
                    scrError.Close()
                    tb_user_id.Focus()
                    tb_user_id.SelectAll()

                    Return False
                End If
            End If

            Call SetDataForControl(ds)

            Return True
        End If
    End Function

    ''' <summary>
    ''' Method display user id.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub DisplayAfterLeaveUserId(ByVal mode As Integer)
        Me.Display = 2

        tb_user_id.Enabled = False
        b_execute.Enabled = True

        If mode = 1 Then
            tb_user_name.Enabled = True
            tb_password.Enabled = True
            tb_remark.Enabled = True

            cb_authority.Enabled = True

            Return
        End If

        If mode = 2 Then
            b_popup_user.Enabled = False

            tb_user_name.Enabled = True
            tb_password.Enabled = True
            tb_remark.Enabled = True

            cb_authority.Enabled = True

            Return
        End If

        If mode = 3 Then
            b_popup_user.Enabled = False

            tb_user_name.Enabled = False
            tb_password.Enabled = False
            tb_remark.Enabled = False

            cb_authority.Enabled = False

            Return
        End If
    End Sub

    ''' <summary>
    ''' Method data for controls.
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Private Sub SetDataForControl(ByVal ds As DataSet)
        tb_user_name.Text = Trim(ds.Tables(0).Rows(0)("USER_NM").ToString)

        '' decrypt data.
        'Dim decryptData As New ABCDCommon.EncryptDecryptVB("password")
        BeforePassword = Trim((ds.Tables(0).Rows(0)("USER_PWD").ToString))
        tb_password.Text = Trim((ds.Tables(0).Rows(0)("USER_PWD").ToString)) 'decryptData.DecryptData(Trim((ds.Tables(0).Rows(0)("USER_PWD").ToString)))

        tb_remark.Text = Trim(ds.Tables(0).Rows(0)("REM").ToString)
        cb_authority.SelectedValue = Integer.Parse(ds.Tables(0).Rows(0)("AUTHORITY").ToString)
    End Sub

    ''' <summary>
    ''' Method execute data belong mode.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub ClickExecute(ByVal mode As Integer)
        Dim userCode As String = tb_user_id.Text
        Dim userName As String = tb_user_name.Text
        '' set encode data is password.
        Dim encryptData As New ABCDCommon.EncryptDecryptVB("password")
        Dim userPass As String = "" 'encryptData.EncryptData(tb_password.Text)
        Dim userAuth As Integer = cb_authority.SelectedValue
        Dim userRem As String = tb_remark.Text

        If Not BeforePassword.Equals(tb_password.Text.Trim) Then
            userPass = encryptData.EncryptData(tb_password.Text)
        Else
            userPass = tb_password.Text.Trim
        End If

        If mode = 1 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG035, "MSG035")
            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.No Then '' Show form and get dialog is No.
                tb_user_name.Focus()
                tb_user_name.SelectAll()
                Return
            Else '' Get dialog is Yes.
                Try
                    Dim num As Integer = wbService.InsertUserInfo(tb_user_id.Text, userPass.Substring(0, 6), tb_user_name.Text, _
                                                                  cb_authority.SelectedValue, Trim(tb_remark.Text), ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF036, "INF036")
                        If frmMsg001.ShowDialog = Windows.Forms.DialogResult.OK Then
                            frmMsg001.Close()
                            tb_user_id.Text = Nothing
                            Call ClickCancel(Me.Display, Me.Mode)
                            tb_user_id.Focus()
                            Return
                        End If
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                    Return
                End Try
            End If
        End If

        If mode = 2 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG037, "MSG037")
            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.No Then '' Show form and get dialog is No.
                tb_user_name.Focus()
                tb_user_name.SelectAll()
                Return
            Else '' Get dialog is Yes.
                Try
                    Dim num As Integer = wbService.UpdateUserInfo(tb_user_id.Text, userPass.Substring(0, 6), tb_user_name.Text, _
                                                                  cb_authority.SelectedValue, Trim(tb_remark.Text), ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF038, "INF038")
                        If frmMsg001.ShowDialog = Windows.Forms.DialogResult.OK Then
                            frmMsg001.Close()
                            tb_user_id.Text = Nothing
                            Call ClickCancel(Me.Display, Me.Mode)
                            tb_user_id.Focus()
                            Return
                        End If
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERR9004")
                    frmMsg001.ShowDialog()
                    Return
                End Try
            End If
        End If

        If mode = 3 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG039, "MSG039")
            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.No Then '' Show form and get dialog is No.
                tb_user_name.Focus()
                tb_user_name.SelectAll()
                Return
            Else '' Get dialog is Yes.
                Try
                    Dim num As Integer = wbService.DeleteUserInfo(tb_user_id.Text, ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF040, "INF040")
                        If frmMsg001.ShowDialog = Windows.Forms.DialogResult.OK Then
                            frmMsg001.Close()
                            tb_user_id.Text = Nothing
                            Call ClickCancel(Me.Display, Me.Mode)
                            tb_user_id.Focus()
                            Return
                        End If
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                    Return
                End Try
            End If
        End If
    End Sub

#End Region

End Class