''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS005.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   05-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources
Imports System.Text.RegularExpressions

Public Class frm_MSS005

#Region "Var/Const Form"

    ''' <summary> Web service. </summary>
    Private wbService As New ABCDService.Service
    ''' <summary> Login user. </summary>
    Private loginCode As String = ABCDCommon.UserId
    ''' <summary> Mode. </summary>
    Public _mode As Integer = ABCDConst.ModeInit
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
        End Set
    End Property
    ''' <summary> Display. </summary>
    Private _display As Integer = ABCDConst.DispInit
    Public Property Display() As Integer
        Get
            Return _display
        End Get
        Set(ByVal value As Integer)
            _display = value
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
        '' Call method new form.
        Call NewForm()
        '' Set system date for form.
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat
        '' Config web service: url and time-out.
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Event checked change radio add customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_add_cus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_add_cus.CheckedChanged
        Me.Mode = ABCDConst.ModeAdd
        Me.Display = ABCDConst.DispOnce
        '' Call method CheckRadioCustomer.
        Call CheckRadioCustomer(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event checked change radio change customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_change_cus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_change_cus.CheckedChanged
        Me.Mode = ABCDConst.ModeUpd
        Me.Display = ABCDConst.DispOnce
        '' Call method CheckRadioCustomer.
        Call CheckRadioCustomer(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event checked change radio delete customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_del_cus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_del_cus.CheckedChanged
        Me.Mode = ABCDConst.ModeDel
        Me.Display = ABCDConst.DispOnce
        '' Call method CheckRadioCustomer.
        Call CheckRadioCustomer(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event leave customer code.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {b_pop_up, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check customer code is null and blank.
        If tb_cus_id.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR041, "ERR041")
            frmMsg001.ShowDialog()
            tb_cus_id.Focus()
            Return
        End If

        '' Check length customer code less 6 chars.
        'If tb_cus_id.Text.Length < 6 Then
        '    Dim frmMsg001 As New frm_MSG001(Messages.ERR042, "ERR042")
        '    frmMsg001.ShowDialog()
        '    tb_cus_id.Focus()
        '    tb_cus_id.SelectAll()
        '    Return
        'End If

        '' Check data exist or not exist in DB.
        If Not CheckDatabase(tb_cus_id.Text, ABCDCommon.UserId, Me.Mode) Then
            Return
        End If

        Call DisplayAfterLeaveCustomerId(Me.Mode)
        tb_cus_name.Focus()
    End Sub

    ''' <summary>
    ''' Event leave customer name.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_name_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_name.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {cb_dest, tb_address, tb_fax_no, _
                                                            tb_email, tb_tel_no, b_exec, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            tb_cus_name.Text = RTrim(LTrim(tb_cus_name.Text))
            tb_cus_name.Text = Regex.Replace(tb_cus_name.Text, " {2,}", " ")
            Return
        End If

        '' Check customer name is null or blank.
        If tb_cus_name.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR043, "ERR043")
            frmMsg001.ShowDialog()
            tb_cus_name.Focus()
            Return
        End If

        '' Check length customer name less 6 char.
        If tb_cus_name.Text.Length < 6 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR044, "ERR044")
            frmMsg001.ShowDialog()
            tb_cus_name.Focus()
            tb_cus_name.SelectAll()
            Return
        End If

        tb_cus_name.Text = RTrim(LTrim(tb_cus_name.Text))
        tb_cus_name.Text = Regex.Replace(tb_cus_name.Text, " {2,}", " ")
    End Sub

    ''' <summary>
    ''' Event leave address.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_address_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_address.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {tb_cus_name, cb_dest, tb_email, tb_fax_no, tb_tel_no, _
                                                            b_exec, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            tb_address.Text = RTrim(LTrim(tb_address.Text))
            tb_address.Text = Regex.Replace(tb_address.Text, " {2,}", " ")
            Return
        End If

        '' Check address is null or blank.
        If tb_address.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR045, "ERR045")
            frmMsg001.ShowDialog()
            tb_address.Focus()
            Return
        End If

        tb_address.Text = RTrim(LTrim(tb_address.Text))
        tb_address.Text = Regex.Replace(tb_address.Text, " {2,}", " ")
    End Sub

    ''' <summary>
    ''' Event leave combo box destination.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cb_dest_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_dest.Leave
        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {tb_address, tb_email, tb_fax_no, tb_tel_no, _
                                                            tb_cus_name, b_exec, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check combo box destination selected.
        If cb_dest.SelectedValue = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR046, "ERR046")
            frmMsg001.ShowDialog()
            cb_dest.Focus()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event click popup customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_pop_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_pop_up.Click
        Dim scrPos005 As New frm_POS005(Me)
        If scrPos005.ShowDialog = Windows.Forms.DialogResult.Ignore Then '' Form popup click cancel.
            tb_cus_id.Focus()
            Return
        End If
        If Not tb_cus_id.Text.Equals("") Then '' Check value of customer id not null.
            If Not CheckDatabase(tb_cus_id.Text, loginCode, Me.Mode) Then '' Check value of customer id not exist DB.
                Return
            End If
            Call DisplayAfterLeaveCustomerId(Me.Mode) '' Call method get data for controls on form
            tb_cus_name.Focus()
        End If
        tb_cus_id.Focus() '' Click control box is Close.
        Return
    End Sub

    ''' <summary>
    ''' Event click execute.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exec.Click
        '' Check customer name is null or blank.
        If tb_cus_name.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR043, "ERR043")
            frmMsg001.ShowDialog()
            tb_cus_name.Focus()
            Return
        End If

        '' Check length customer name less 6 char.
        'If tb_cus_name.Text.Length < 6 Then
        '    Dim frmMsg001 As New frm_MSG001(Messages.ERR044, "ERR044")
        '    frmMsg001.ShowDialog()
        '    tb_cus_name.Focus()
        '    tb_cus_name.SelectAll()
        '    Return
        'End If

        '' Check combo box destination selected.
        If cb_dest.SelectedValue = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR046, "ERR046")
            frmMsg001.ShowDialog()
            cb_dest.Focus()
            Return
        End If

        '' Check address is null or blank.
        If tb_address.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR045, "ERR045")
            frmMsg001.ShowDialog()
            tb_address.Focus()
            Return
        End If

        Call ClickExecute(Me.Mode)
        tb_cus_id.Focus()
    End Sub

    ''' <summary>
    ''' Event click cancel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_cancel.Click
        Call ClickCancel(Me.Display, Me.Mode)
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

    ''' <summary>
    ''' Event text changed customer code.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.TextChanged
        'tb_cus_id.Text = Regex.Replace(tb_cus_id.Text, ABCDConst.Special_Char_Add_Space, "") '' Replace all special chars.
        'tb_cus_id.SelectionStart = tb_cus_id.Text.Length '' Set focus last position input.
    End Sub

#End Region

#Region "Function Form"

    ''' <summary>
    ''' Method new form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NewForm()
        rb_add_cus.Checked = CheckState.Unchecked
        rb_change_cus.Checked = CheckState.Unchecked
        rb_del_cus.Checked = CheckState.Unchecked

        rb_add_cus.Enabled = True
        rb_change_cus.Enabled = True
        rb_del_cus.Enabled = True

        tb_cus_id.Text = Nothing
        tb_cus_name.Text = Nothing
        tb_address.Text = Nothing
        cb_dest.Text = Nothing
        tb_email.Text = Nothing
        tb_fax_no.Text = Nothing
        tb_tel_no.Text = Nothing

        tb_cus_id.Enabled = False
        tb_cus_name.Enabled = False
        tb_address.Enabled = False
        cb_dest.Enabled = False
        tb_email.Enabled = False
        tb_fax_no.Enabled = False
        tb_tel_no.Enabled = False

        b_pop_up.Enabled = False
        b_exec.Enabled = False
        b_cancel.Enabled = False
        b_exit.Enabled = True

        cb_dest.DataSource = wbService.GetCodeMasterMS(ABCDConst.Type_Destination, ABCDCommon.UserId).Tables(0)
        cb_dest.DisplayMember = "CODE_NAME"
        cb_dest.ValueMember = "CODE_02"
    End Sub

    ''' <summary>
    ''' Method check radio.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub CheckRadioCustomer(ByVal mode As Integer)
        If mode = 1 Then
            rb_add_cus.Enabled = False
            rb_change_cus.Enabled = False
            rb_del_cus.Enabled = False

            tb_cus_id.Enabled = True

            b_cancel.Enabled = True

            tb_cus_id.Focus()
            Return
        End If

        If mode = 2 Then
            rb_add_cus.Enabled = False
            rb_change_cus.Enabled = False
            rb_del_cus.Enabled = False

            tb_cus_id.Enabled = True
            b_pop_up.Enabled = True

            b_cancel.Enabled = True

            tb_cus_id.Focus()
            Return
        End If

        If mode = 3 Then
            rb_add_cus.Enabled = False
            rb_change_cus.Enabled = False
            rb_del_cus.Enabled = False

            tb_cus_id.Enabled = True
            b_pop_up.Enabled = True

            b_cancel.Enabled = True

            tb_cus_id.Focus()
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
            RemoveHandler rb_add_cus.CheckedChanged, AddressOf rb_add_cus_CheckedChanged
            rb_add_cus.Checked = CheckState.Unchecked
            AddHandler rb_add_cus.CheckedChanged, AddressOf rb_add_cus_CheckedChanged
            RemoveHandler rb_change_cus.CheckedChanged, AddressOf rb_change_cus_CheckedChanged
            rb_change_cus.Checked = CheckState.Unchecked
            AddHandler rb_change_cus.CheckedChanged, AddressOf rb_change_cus_CheckedChanged
            RemoveHandler rb_del_cus.CheckedChanged, AddressOf rb_del_cus_CheckedChanged
            rb_del_cus.Checked = CheckState.Unchecked
            AddHandler rb_del_cus.CheckedChanged, AddressOf rb_del_cus_CheckedChanged

            rb_add_cus.Enabled = True
            rb_change_cus.Enabled = True
            rb_del_cus.Enabled = True

            tb_cus_id.Text = Nothing
            tb_cus_id.Enabled = False

            If mode = 2 Or mode = 3 Then
                b_pop_up.Enabled = False
            End If

            b_cancel.Enabled = False

            Me.Display = 0
            Return
        End If

        If display = 2 Then
            tb_cus_name.Text = Nothing
            tb_address.Text = Nothing
            cb_dest.SelectedValue = 0
            tb_email.Text = Nothing
            tb_fax_no.Text = Nothing
            tb_tel_no.Text = Nothing

            tb_cus_id.Enabled = True

            If mode = 2 Or mode = 3 Then
                b_pop_up.Enabled = True
            End If

            tb_cus_name.Enabled = False
            tb_address.Enabled = False
            cb_dest.Enabled = False
            tb_email.Enabled = False
            tb_fax_no.Enabled = False
            tb_tel_no.Enabled = False

            b_exec.Enabled = False

            Me.Display = 1
            Return
        End If
    End Sub

    ''' <summary>
    ''' Method check data DB.
    ''' </summary>
    ''' <param name="customerCode"></param>
    ''' <param name="loginCode"></param>
    ''' <param name="mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDatabase(ByVal customerCode As String, _
                                   ByVal loginCode As String, _
                                   ByVal mode As Integer) As Boolean
        Dim ds As DataSet = wbService.GetCustomerInfoByID(customerCode, loginCode)
        Dim rNum As Integer = ds.Tables(0).Rows.Count

        If mode = 1 Then
            If rNum = 1 Then
                Dim frmMsg001 As New frm_MSG001(Messages.ERR012, "ERR012")
                frmMsg001.ShowDialog()
                tb_cus_id.Focus()
                tb_cus_id.SelectAll()
                Return False '' Data existed in DB.
            End If
            Return True '' Data not exist in DB.
        End If

        If mode = 2 Or mode = 3 Then
            If rNum = 0 Then
                Dim frmMsg001 As New frm_MSG001(Messages.ERR011, "ERR011")
                frmMsg001.ShowDialog()
                tb_cus_id.Focus()
                tb_cus_id.Select()
                Return False
            End If

            If mode = 3 Then '' Case delete customer.
                Dim ds2 As DataSet = Nothing
                ds2 = wbService.ItemInquiry("", "", "", tb_cus_id.Text, "", 0, ABCDCommon.UserId)
                If ds2.Tables(0).Rows.Count > 0 Then
                    Dim frmMsg001 As New frm_MSG001(Messages.ERR014, "ERR014")
                    frmMsg001.ShowDialog()
                    tb_cus_id.Focus()
                    tb_cus_id.SelectAll()
                    Return False
                End If
            End If

            '' Case mode update and delete.
            If ds.Tables(0).Rows.Count > 0 Then
                Call SetDataForControl(ds)
            End If
            Return True
        End If
    End Function

    ''' <summary>
    ''' Method display after leave customer code.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub DisplayAfterLeaveCustomerId(ByVal mode As Integer)
        Me.Display = 2

        tb_cus_id.Enabled = False
        b_exec.Enabled = True

        If mode = 1 Then
            tb_cus_name.Enabled = True
            tb_address.Enabled = True
            cb_dest.Enabled = True
            tb_email.Enabled = True
            tb_fax_no.Enabled = True
            tb_tel_no.Enabled = True

            Return
        End If

        If mode = 2 Then
            b_pop_up.Enabled = False
            tb_cus_name.Enabled = True
            tb_address.Enabled = True
            cb_dest.Enabled = True
            tb_email.Enabled = True
            tb_fax_no.Enabled = True
            tb_tel_no.Enabled = True

            Return
        End If

        If mode = 3 Then
            b_pop_up.Enabled = False
            tb_cus_name.Enabled = False
            tb_address.Enabled = False
            cb_dest.Enabled = False
            tb_email.Enabled = False
            tb_fax_no.Enabled = False
            tb_tel_no.Enabled = False

            Return
        End If
    End Sub

    ''' <summary>
    ''' Method data control.
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Private Sub SetDataForControl(ByVal ds As DataSet)
        tb_cus_name.Text = Trim(ds.Tables(0).Rows(0)("CUS_NM").ToString)
        tb_address.Text = Trim(ds.Tables(0).Rows(0)("ADDRESS").ToString)
        tb_fax_no.Text = Trim(ds.Tables(0).Rows(0)("FAX_NO").ToString)
        tb_tel_no.Text = Trim(ds.Tables(0).Rows(0)("TEL_NO").ToString)
        tb_email.Text = Trim(ds.Tables(0).Rows(0)("MAIL_ADD").ToString)
        cb_dest.SelectedValue = Integer.Parse(ds.Tables(0).Rows(0)("DEST").ToString)
    End Sub

    ''' <summary>
    ''' Method execute.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub ClickExecute(ByVal mode As Integer)
        '' Case add new customer.
        If Me.Mode = 1 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG035, "MSG035")

            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.No Then '' Get dialog form is No.
                tb_cus_name.Focus()
                tb_cus_name.SelectAll()
                Return
            Else '' Get dialog form is Yes.
                Try
                    Dim num As Integer = wbService.InsertCustomerInfo(tb_cus_id.Text, tb_cus_name.Text, cb_dest.SelectedValue, _
                                                                      tb_address.Text, tb_tel_no.Text, tb_fax_no.Text, tb_email.Text, _
                                                                      ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF036, "INF036")
                        frmMsg001.ShowDialog()
                        tb_cus_id.Text = Nothing
                        Call ClickCancel(Me.Display, Me.Mode)
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                End Try
            End If
        End If

        '' Case update old customer.
        If Me.Mode = 2 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG037, "MSG037")

            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.No Then '' Get dialog form is No.
                tb_cus_name.Focus()
                tb_cus_name.SelectAll()
                Return
            Else '' Get dialog form is Yes.
                Try
                    Dim num As Integer = wbService.UpdateCustomerInfo(tb_cus_id.Text, tb_cus_name.Text, tb_address.Text, _
                                                                      cb_dest.SelectedValue, tb_email.Text, tb_fax_no.Text, _
                                                                      tb_tel_no.Text, ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF038, "INF038")
                        frmMsg001.ShowDialog()
                        Call ClickCancel(Me.Display, Me.Mode)
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                End Try
            End If
        End If

        '' Case delete old customer.
        If Me.Mode = 3 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG039, "MSG039")

            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.No Then '' Get dialog form is No.
                b_exec.Focus()
                Return
            Else '' Get dialog form is Yes.
                Try
                    Dim num As Integer = wbService.DeleteCustomerInfo(tb_cus_id.Text, ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF040, "INF040")
                        frmMsg001.ShowDialog()
                        Call ClickCancel(Me.Display, Me.Mode)
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                End Try
            End If
        End If
    End Sub

#End Region

End Class