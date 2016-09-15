''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_Menu.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   13-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_PRS001

#Region "Var/Const Form"

    Private ws As New ABCDService.Service
    Private loginCode As String = ABCDCommon.UserId

    Public _mode As Integer = ABCDConst.ModeInit
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
        End Set
    End Property

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

    Public Sub New()
        InitializeComponent()
        Call NewForm()
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat
        'With lb_issue
        '    .Text = Nothing
        'End With
        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
    End Sub

#End Region

#Region "Event Form"

    Private Sub b_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    Private Sub rdo_add_product_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rdo_add_product.CheckedChanged
        Me.Mode = ABCDConst.ModeAdd
        Me.Display = ABCDConst.DispOnce
        Call CheckRadioProduct(Me.Mode)
        tb_wo_no.Focus()
    End Sub

    Private Sub rdo_change_product_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rdo_change_product.CheckedChanged
        Me.Mode = ABCDConst.ModeUpd
        Me.Display = ABCDConst.DispOnce

        Call CheckRadioProduct(Me.Mode)
        tb_wo_no.Focus()
    End Sub

    Private Sub rdo_delete_product_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rdo_delete_product.CheckedChanged
        Me.Mode = ABCDConst.ModeDel
        Me.Display = ABCDConst.DispOnce

        Call CheckRadioProduct(Me.Mode)
        tb_wo_no.Focus()
    End Sub

    Private Sub b_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_cancel.Click
        Call ClickCancel(Me.Display, _
                         Me.Mode)
    End Sub

    Private Sub tb_wo_no_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_wo_no.Leave
        Dim ctrlLst As New List(Of Control)(New Control() {b_popup_wo_no, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlLst) Then
            Return
        End If
        If tb_wo_no.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR063, "ERR063")
            frmMsg001.ShowDialog()
            tb_wo_no.Focus()
            Return
        End If
        If tb_wo_no.Text.Length < 10 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR064, "ERR064")
            frmMsg001.ShowDialog()
            tb_wo_no.Focus()
            tb_wo_no.SelectAll()
            Return
        End If
        If Not CheckDatabase(tb_wo_no.Text, ABCDCommon.UserId, Me.Mode) Then
            Return
        End If
        Call DisplayAfterLeaveWO(Me.Mode)
    End Sub

    Private Sub dtp_wo_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_wo_date.ValueChanged
        Call ABCDCommon.ChangeDateTimePicker(dtp_wo_date)
    End Sub

    Private Sub tb_item_code_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code.Leave
        Dim ctrlLst As New List(Of Control)(New Control() {dtp_wo_date, b_popup_item_code, tb_product_quantity, tb_quantity_box, b_exec, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlLst) Then '' Get event other controls when focused.
            Dim ds As DataSet = ws.GetItemInfoByCd(tb_item_code.Text, ABCDCommon.UserId) '' Get info item if have.
            If ds.Tables(0).Rows.Count > 0 Then
                tb_item_name.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
                If tb_quantity_box.Text.Equals("") Or tb_quantity_box.Text.Equals("0") Then
                    tb_quantity_box.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("QTY").ToString)).ToString(ABCDConst.Format_Number)
                End If
            End If
            Return
        End If
        If tb_item_code.Text.Equals("") Then '' Get event leave item code but value is null or blank.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR047, "ERR047")
            frmMsg001.ShowDialog()
            tb_item_code.Focus()
            Return
        End If
        Call SetValueAfterLeaveItemCode(tb_item_code.Text, ABCDCommon.UserId)
    End Sub

    Private Sub tb_product_quantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_product_quantity.TextChanged
        Call ChangeTextTotalBox()
        Return
    End Sub

    Private Sub tb_quantity_box_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_quantity_box.TextChanged
        If b_cancel.Focused Then
            Return
        End If
        If tb_quantity_box.Text.Equals("") Then
            Return
        End If
        If Integer.Parse(tb_quantity_box.Text.Replace(",", "")).ToString(ABCDConst.Format_Number).Equals("") Then
            tb_quantity_box.Text = "0"
        End If
        Call ChangeTextTotalBox()
    End Sub

    Private Sub tb_wo_no_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles tb_wo_no.KeyPress
        Call ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    Private Sub tb_product_quantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles tb_product_quantity.KeyPress
        Call ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    Private Sub b_exec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exec.Click
        If dtp_wo_date.Text.Equals(" ") Then '' Case value of w/o date is null or blank.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR057, "ERR057")
            frmMsg001.ShowDialog()
            dtp_wo_date.Focus()
            Return
        End If
        Dim ds As DataSet = ws.GetItemInfoByCd(tb_item_code.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count = 0 Then '' Case item code invalid.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR065, "ERR065")
            frmMsg001.ShowDialog()
            tb_item_code.Focus()
            tb_item_code.SelectAll()
            Return
        End If
        If tb_product_quantity.Text.Equals("") Then '' Case product quantity is null or blank.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR058, "ERR058")
            frmMsg001.ShowDialog()
            tb_product_quantity.Focus()
            Return
        End If
        If tb_product_quantity.Text.Equals("0") Then '' Case product quantity is 0.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR059, "ERR059")
            frmMsg001.ShowDialog()
            tb_product_quantity.Focus()
            tb_product_quantity.SelectAll()
            Return
        End If
        If tb_quantity_box.Text.Equals("") Then '' Case quantity box is null or blank.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR060, "ERR060")
            frmMsg001.ShowDialog()
            tb_quantity_box.Focus()
            Return
        End If
        If tb_quantity_box.Text.Equals("0") Then '' Case quantity box is 0.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR061, "ERR061")
            frmMsg001.ShowDialog()
            tb_quantity_box.Focus()
            tb_quantity_box.SelectAll()
            Return
        End If
        If Integer.Parse(tb_total_box.Text.Replace(",", "")) > 9999 Then
            Dim msg001 As New frm_MSG001(Messages.ERR0011, "ERR0011")
            msg001.ShowDialog()
            RemoveHandler tb_product_quantity.Leave, AddressOf tb_product_quantity_Leave
            tb_product_quantity.Focus()
            tb_product_quantity.SelectAll()
            Return
        End If
        Call ClickExecute(Me.Mode)
        Return
    End Sub

    Private Sub b_popup_item_code_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_popup_item_code.Click
        Dim scrPos001 As New frm_POS001(Me)
        scrPos001.ShowDialog()
        tb_item_code.Focus()
        tb_item_code.SelectAll()
        'If Me.Mode = 1 Then
        Dim ds As DataSet = ws.GetItemInfoByCd(tb_item_code.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count > 0 Then
            With tb_from_box_number
                .Text = (Integer.Parse(Trim(ds.Tables(0).Rows(0)("CUR_BOX_NUM").ToString)) + 1).ToString(ABCDConst.Format_Number)
                If Integer.Parse(.Text.Replace(",", "")) > 9999 Then
                    .Text = "1"
                End If
            End With
        End If
        'End If
        Return
    End Sub

    Private Sub b_popup_wo_no_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_popup_wo_no.Click
        Dim frmPos006 As New frm_POS006(Me)
        If frmPos006.ShowDialog = Windows.Forms.DialogResult.Ignore Then
            tb_wo_no.Focus()
            tb_wo_no.SelectAll()
            Return
        End If
        If Not CheckDatabase(tb_wo_no.Text, ABCDCommon.UserId, Me.Mode) Then
            Return
        End If
        Call DisplayAfterLeaveWO(Me.Mode)
    End Sub

    Private Sub tb_product_quantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_product_quantity.Leave
        Dim ctrlLst As New List(Of Control)(New Control() {dtp_wo_date, tb_item_code, b_popup_item_code, tb_quantity_box, b_exec, b_exit})
        If b_cancel.Focused = True Then
            Return
        End If
        If Not ABCDCommon.CheckFocusedControls(ctrlLst) Then '' Get event other controls when focused.
            If Not tb_product_quantity.Text.Equals("") Then '' Case product quantity not null or blank.
                tb_product_quantity.Text = Integer.Parse(tb_product_quantity.Text.Replace(",", "")).ToString(ABCDConst.Format_Number)
                If tb_product_quantity.Text.Equals("") Then '' Convert format is null when input 0.
                    tb_product_quantity.Text = "0"
                End If
            End If
            Return
        End If
        If tb_product_quantity.Text.Equals("") Then '' Check event leave however value of product quantity is null.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR058, "ERR058")
            frmMsg001.ShowDialog()
            tb_product_quantity.Focus()
            Return
        End If
        If tb_product_quantity.Text.Equals("0") Then '' Check event leave however value of product quantity is 0.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR059, "ERR059")
            frmMsg001.ShowDialog()
            tb_product_quantity.Focus()
            tb_product_quantity.SelectAll()
            Return
        End If
        tb_product_quantity.Text = tb_product_quantity.Text.Replace(",", "")
        tb_product_quantity.Text = Integer.Parse(tb_product_quantity.Text.Replace(",", "")).ToString(ABCDConst.Format_Number)
        tb_quantity_box.Text = tb_quantity_box.Text.Replace(",", "")
    End Sub

    Private Sub tb_item_code_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code.TextChanged
        tb_item_name.Text = Nothing
        tb_quantity_box.Text = Nothing
        tb_from_box_number.Text = Nothing
        tb_total_box.Text = Nothing
    End Sub

    Private Sub dtp_wo_date_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_wo_date.Leave
        Dim ctrlLst As New List(Of Control)(New Control() {tb_item_code, b_popup_item_code, tb_product_quantity, tb_quantity_box, b_exec, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlLst) Then '' Get event when other controls focused.
            Return
        End If
        If dtp_wo_date.Text.Equals(" ") Then '' Get event leave date time picker but value is null or blank.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR057, "ERR057")
            frmMsg001.ShowDialog()
            dtp_wo_date.Focus()
            Return
        End If
    End Sub

    Private Sub tb_product_quantity_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_product_quantity.MouseClick
        RemoveHandler tb_item_code.Leave, AddressOf tb_item_code_LostFocus
        RemoveHandler tb_quantity_box.Leave, AddressOf tb_quantity_box_Leave
        tb_product_quantity.Text = tb_product_quantity.Text.Replace(",", "")
        tb_product_quantity.SelectAll()
        AddHandler tb_item_code.Leave, AddressOf tb_item_code_LostFocus
        AddHandler tb_quantity_box.Leave, AddressOf tb_quantity_box_Leave
        Return
    End Sub

    Private Sub tb_quantity_box_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_quantity_box.Leave
        Dim ctrlLst As New List(Of Control)(New Control() {dtp_wo_date, tb_item_code, b_popup_item_code, tb_product_quantity, b_exec, b_cancel, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlLst) Then
            If Not tb_quantity_box.Text.Equals("") Then '' Case product quantity not null or blank.
                If Integer.Parse(tb_quantity_box.Text.Replace(",", "")).ToString(ABCDConst.Format_Number).Equals("") Then '' Convert format is null when input 0.
                    tb_quantity_box.Text = "0"
                    Return
                End If
                tb_quantity_box.Text = Integer.Parse(tb_quantity_box.Text.Replace(",", "")).ToString(ABCDConst.Format_Number)
            End If
            Return
        End If
        If tb_quantity_box.Text.Equals("") Then '' Check event leave however value of product quantity is null.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR060, "ERR060")
            frmMsg001.ShowDialog()
            tb_quantity_box.Focus()
            Return
        End If
        If tb_quantity_box.Text.Equals("0") Then '' Check event leave however value of product quantity is 0.
            Dim frmMsg001 As New frm_MSG001(Messages.ERR061, "ERR061")
            frmMsg001.ShowDialog()
            tb_quantity_box.Focus()
            tb_quantity_box.SelectAll()
            Return
        End If
        tb_quantity_box.Text = tb_quantity_box.Text.Replace(",", "")
        tb_quantity_box.Text = Integer.Parse(tb_quantity_box.Text.Replace(",", "")).ToString(ABCDConst.Format_Number)
        If tb_quantity_box.Text.Equals("") Then
            tb_quantity_box.Text = "0"
            If tb_quantity_box.Text.Equals("0") Then '' Check event leave however value of product quantity is 0.
                Dim frmMsg001 As New frm_MSG001(Messages.ERR061, "ERR061")
                frmMsg001.ShowDialog()
                tb_quantity_box.Focus()
                tb_quantity_box.SelectAll()
                Return
            End If
        End If
    End Sub

    Private Sub tb_quantity_box_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_quantity_box.MouseClick
        RemoveHandler tb_product_quantity.Leave, AddressOf tb_product_quantity_Leave
        tb_quantity_box.Text = tb_quantity_box.Text.Replace(",", "")
        tb_quantity_box.SelectAll()
        AddHandler tb_product_quantity.Leave, AddressOf tb_product_quantity_Leave
        Return
    End Sub

    Private Sub tb_quantity_box_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_quantity_box.KeyPress
        Call ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    Private Sub tb_item_code_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_item_code.MouseClick
        RemoveHandler tb_product_quantity.Leave, AddressOf tb_product_quantity_Leave
        tb_item_code.SelectAll()
        AddHandler tb_product_quantity.Leave, AddressOf tb_product_quantity_Leave
        Return
    End Sub

#End Region

#Region "Function Form"

    Private Sub NewForm()
        rdo_add_product.Checked = False
        rdo_change_product.Checked = False
        rdo_delete_product.Checked = False

        rdo_add_product.Enabled = True
        rdo_change_product.Enabled = True
        rdo_delete_product.Enabled = True

        tb_wo_no.Text = Nothing
        tb_wo_no.Enabled = False

        Call ABCDCommon.InitDateTimePicker(dtp_wo_date)
        dtp_wo_date.Enabled = False

        tb_item_code.Text = Nothing
        tb_item_code.Enabled = False

        tb_item_name.Text = Nothing
        tb_item_name.Enabled = False

        tb_product_quantity.Text = Nothing
        tb_product_quantity.Enabled = False

        tb_quantity_box.Text = Nothing
        tb_quantity_box.Enabled = False

        tb_total_box.Text = Nothing
        tb_total_box.Enabled = False

        b_popup_wo_no.Enabled = False
        b_popup_item_code.Enabled = False
        b_exec.Enabled = False
        b_cancel.Enabled = False
        b_exit.Enabled = True
    End Sub

    Private Sub CheckRadioProduct(ByVal mode As Integer)
        If mode = 1 Then
            rdo_add_product.Enabled = False
            rdo_change_product.Enabled = False
            rdo_delete_product.Enabled = False
            tb_wo_no.Enabled = True
            b_cancel.Enabled = True
            With lb_issue
                .Text = "-"
            End With
            Return
        End If
        If mode = 2 Then
            rdo_add_product.Enabled = False
            rdo_change_product.Enabled = False
            rdo_delete_product.Enabled = False
            tb_wo_no.Enabled = True
            b_popup_wo_no.Enabled = True
            b_cancel.Enabled = True
            With lb_issue
                .Text = "-"
            End With
            Return
        End If
        If mode = 3 Then
            rdo_add_product.Enabled = False
            rdo_change_product.Enabled = False
            rdo_delete_product.Enabled = False
            tb_wo_no.Enabled = True
            b_popup_wo_no.Enabled = True
            b_cancel.Enabled = True
            With lb_issue
                .Text = "-"
            End With
            Return
        End If
    End Sub

    Private Sub ClickCancel(ByVal display As Integer, ByVal mode As Integer)
        If display = 1 Then
            RemoveHandler rdo_add_product.CheckedChanged, AddressOf rdo_add_product_CheckedChanged
            rdo_add_product.Checked = False
            AddHandler rdo_add_product.CheckedChanged, AddressOf rdo_add_product_CheckedChanged
            RemoveHandler rdo_change_product.CheckedChanged, AddressOf rdo_change_product_CheckedChanged
            rdo_change_product.Checked = False
            AddHandler rdo_change_product.CheckedChanged, AddressOf rdo_change_product_CheckedChanged
            RemoveHandler rdo_delete_product.CheckedChanged, AddressOf rdo_delete_product_CheckedChanged
            rdo_delete_product.Checked = False
            AddHandler rdo_delete_product.CheckedChanged, AddressOf rdo_delete_product_CheckedChanged
            rdo_add_product.Enabled = True
            rdo_change_product.Enabled = True
            rdo_delete_product.Enabled = True
            tb_wo_no.Text = Nothing
            tb_wo_no.Enabled = False
            If mode = 2 Or mode = 3 Then
                b_popup_wo_no.Enabled = False
            End If
            b_cancel.Enabled = False
            With lb_issue
                .Text = "-"
            End With
            Me.Display = 0
            Return
        End If
        If display = 2 Then
            tb_item_code.Text = Nothing
            tb_item_name.Text = Nothing
            tb_total_box.Text = Nothing
            tb_quantity_box.Text = Nothing
            tb_product_quantity.Text = Nothing
            tb_from_box_number.Text = Nothing
            Call ABCDCommon.InitDateTimePicker(dtp_wo_date)
            tb_wo_no.Enabled = True
            If mode = 2 Or mode = 3 Then
                b_popup_wo_no.Enabled = True
            End If
            With lb_issue
                .Text = "-"
            End With
            dtp_wo_date.Enabled = False
            tb_item_code.Enabled = False
            b_popup_item_code.Enabled = False
            tb_product_quantity.Enabled = False
            tb_quantity_box.Enabled = False
            b_exec.Enabled = False
            Me.Display = 1
            tb_wo_no.Focus()
            tb_wo_no.SelectAll()
            Return
        End If
    End Sub

    Private Function CheckDatabase(ByVal woCode As String, ByVal loginCode As String, ByVal mode As Integer) As Boolean
        Dim ds As DataSet = ws.GetWOInfoByWONo(tb_wo_no.Text, ABCDCommon.UserId)
        If Me.Mode = 1 Then
            If ds.Tables(0).Rows.Count = 1 Then
                Dim frmMsg001 As New frm_MSG001(Messages.ERR012, "ERR012")
                frmMsg001.ShowDialog()
                tb_wo_no.Focus()
                tb_wo_no.SelectAll()
                Return False
            End If
            Return True
        End If
        If Me.Mode = 2 Or Me.Mode = 3 Then
            If ds.Tables(0).Rows.Count = 0 Then
                Dim frmMsg001 As New frm_MSG001(Messages.ERR011, "ERR011")
                frmMsg001.ShowDialog()
                tb_wo_no.Focus()
                tb_wo_no.SelectAll()
                Return False
            End If

            If ds.Tables(0).Rows(0)("ISSUE_FLG").ToString.Equals("0") Then
                '// Change source with issue screen PRS002.
                Dim dataSet As DataSet = Nothing '// Check data with issued flag = 0 but have data in item detail.
                dataSet = ws.GetItemDetailByWorkOrderNo(tb_wo_no.Text, ABCDCommon.UserId)
                If dataSet.Tables(0).Rows.Count > 0 Then
                    b_exec.Enabled = False
                    tb_wo_no.Enabled = False
                    b_popup_wo_no.Enabled = False
                    Dim frm As New frm_MSG001("W/O No is being used. Can not modify or delete !", "ERR")
                    frm.ShowDialog()
                    SetDataForControl(dataSet)
                    Display = 2
                    Return False
                End If
            End If

            If ds.Tables(0).Rows(0)("ISSUE_FLG").ToString.Equals("1") Then
                With lb_issue
                    .Text = "Issued"
                End With
                With b_exec
                    .Enabled = False
                End With
                With tb_wo_no
                    .Enabled = False
                End With
                With b_popup_wo_no
                    .Enabled = False
                End With
                Call SetDataForControl(ds)
                Dim frmMsg001 As New frm_MSG001(Messages.ERR062, "ERR062")
                frmMsg001.ShowDialog()
                Me.Display = 2
                Return False
            End If
            Call SetDataForControl(ds)
            Return True
        End If
    End Function

    Private Sub DisplayAfterLeaveWO(ByVal mode As Integer)
        Me.Display = 2

        ABCDCommon.AddZeros(tb_wo_no, 10)
        tb_wo_no.Enabled = False
        b_exec.Enabled = True

        If mode = 1 Then
            dtp_wo_date.Enabled = True

            tb_item_code.Enabled = True
            b_popup_item_code.Enabled = True
            tb_product_quantity.Enabled = True
            '// cuongtk - Change in date 29012015.
            '// reason - Change status and value control.
            '// start.
            tb_quantity_box.Enabled = True
            lb_issue.Text = "Not Issued"
            dtp_wo_date.Focus()
            Return
        End If
        If mode = 2 Then
            b_popup_wo_no.Enabled = False
            dtp_wo_date.Enabled = True
            tb_item_code.Enabled = True
            b_popup_item_code.Enabled = True
            tb_product_quantity.Enabled = True
            '// end.
            tb_quantity_box.Enabled = True
            dtp_wo_date.Focus()
            Return
        End If
        If mode = 3 Then
            b_popup_wo_no.Enabled = False
            Return
        End If
    End Sub

    Private Sub SetValueAfterLeaveItemCode(ByVal itemCode As String, ByVal loginCode As String)
        Dim ds As DataSet = ws.GetItemInfoByCd(itemCode, loginCode)
        Dim rNum As Integer = ds.Tables(0).Rows.Count
        If rNum = 0 Then
            Dim msgError As String = "Item: " & tb_item_code.Text & " is not exist!"
            Dim scrError As New frm_MSG001(msgError, "ERR008")
            If scrError.ShowDialog = Windows.Forms.DialogResult.OK Then
                scrError.Close()
                tb_item_code.Focus()
                tb_item_code.SelectAll()
                Return
            End If
        End If
        tb_item_code.Text = Trim(ds.Tables(0).Rows(0)("ITEM_CD").ToString)
        tb_item_name.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
        tb_quantity_box.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("QTY").ToString)).ToString(ABCDConst.Format_Number)
        If tb_quantity_box.Text.Equals("") Or tb_quantity_box.Text.Equals("0") Then
            tb_quantity_box.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("QTY").ToString)).ToString(ABCDConst.Format_Number)
            Return
        End If
        With tb_from_box_number
            .Text = (Integer.Parse(Trim(ds.Tables(0).Rows(0)("CUR_BOX_NUM").ToString)) + 1).ToString(ABCDConst.Format_Number)
            If Integer.Parse(.Text.Replace(",", "")) > 9999 Then
                .Text = "1"
            End If
        End With
    End Sub

    Private Sub ChangeTextTotalBox()
        If tb_product_quantity.Text.Equals("") Then
            Return
        End If
        If Not tb_product_quantity.Text.Equals("") And (tb_quantity_box.Text.Equals("") Or tb_quantity_box.Text.Equals("0")) Then
            Return
        End If
        Dim modNum As Integer = Integer.Parse(tb_product_quantity.Text.Replace(",", "")) Mod Integer.Parse(tb_quantity_box.Text.Replace(",", ""))
        Dim divNum As Integer = Integer.Parse(tb_product_quantity.Text.Replace(",", "")) \ Integer.Parse(tb_quantity_box.Text.Replace(",", ""))
        tb_total_box.Text = divNum.ToString(ABCDConst.Format_Number)
        If modNum <> 0 Then
            tb_total_box.Text = (divNum + 1).ToString(ABCDConst.Format_Number)
        End If
    End Sub

    Private Function GetLotNo(ByVal woCode As String, _
                              ByVal woDate As Date) As String
        Return woCode.Substring(5, 5) & _
            ABCDConst.CharConnect & _
            woDate.ToString(ABCDConst.FORMAT_DATE_03)
    End Function

    Private Sub ClickExecute(ByVal mode As Integer)
        If Me.Mode = 1 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG035, "MSG035")
            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Dim woNoList As New List(Of String)
                Dim woDtList As New List(Of String)
                Dim itmCdList As New List(Of String)
                Dim prdQtyList As New List(Of String)
                Dim qPerBxList As New List(Of String)
                Dim totalBxList As New List(Of String)
                woNoList.Add(tb_wo_no.Text)
                woDtList.Add(dtp_wo_date.Value.ToString(ABCDConst.Format_Date_04))
                itmCdList.Add(tb_item_code.Text)
                prdQtyList.Add(tb_product_quantity.Text.Replace(",", ""))
                qPerBxList.Add(tb_quantity_box.Text.Replace(",", ""))
                totalBxList.Add(tb_total_box.Text.Replace(",", ""))
                Try
                    Dim num As Integer = ws.InsertWOInfo(woNoList.ToArray, woDtList.ToArray, itmCdList.ToArray, prdQtyList.ToArray, _
                                                         qPerBxList.ToArray, totalBxList.ToArray, ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF036, "INF036")
                        frmMsg001.ShowDialog()
                        tb_wo_no.Text = Nothing
                        tb_wo_no.Focus()
                        Call ClickCancel(Me.Display, Me.Mode)
                        Return
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                    Return
                End Try
            Else
                frmMsg001.Close()
                dtp_wo_date.Focus()
                Return
            End If
        End If
        If Me.Mode = 2 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG037, "MSG037")
            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim num As Integer = ws.UpdateWOInfo(tb_wo_no.Text, dtp_wo_date.Value, tb_item_code.Text, _
                                                         Integer.Parse(tb_product_quantity.Text.Replace(",", "")), _
                                                         Integer.Parse(tb_quantity_box.Text.Replace(",", "")), _
                                                         Integer.Parse(tb_total_box.Text.Replace(",", "")), _
                                                         ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF038, "INF038")
                        frmMsg001.ShowDialog()
                        tb_wo_no.Focus()
                        Call ClickCancel(Me.Display, Me.Mode)
                        Return
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                    Return
                End Try
            Else
                frmMsg001.Close()
                dtp_wo_date.Focus()
                Return
            End If
        End If
        If Me.Mode = 3 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG039, "MSG039")
            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim num As Integer = ws.DeleteWOInfo(tb_wo_no.Text, ABCDCommon.UserId)
                    If num = 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF040, "INF040")
                        tb_wo_no.Text = Nothing
                        tb_wo_no.Focus()
                        Call ClickCancel(Me.Display, Me.Mode)
                        Return
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                    Return
                End Try
            Else
                frmMsg001.ShowDialog()
                Return
            End If
        End If
    End Sub

    Private Sub SetDataForControl(ByVal ds As DataSet)
        dtp_wo_date.Value = Date.Parse(Trim(ds.Tables(0).Rows(0)("WO_DT").ToString))
        tb_item_code.Text = Trim(ds.Tables(0).Rows(0)("ITEM_CD").ToString)
        tb_product_quantity.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("PRODUCT_QTY").ToString)).ToString(ABCDConst.Format_Number)
        tb_quantity_box.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("QTY_PER_BOX").ToString)).ToString(ABCDConst.Format_Number)
        tb_total_box.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("TOTAL_BOX").ToString)).ToString(ABCDConst.Format_Number)
        With lb_issue
            If Integer.Parse(ds.Tables(0).Rows(0)("ISSUE_FLG").ToString) = 0 Then
                .Text = "Not Issued"
            Else
                .Text = "Issued"
            End If
        End With
        Dim ds2 As DataSet = ws.GetItemInfoByCd(tb_item_code.Text, ABCDCommon.UserId)
        If ds2.Tables(0).Rows.Count <> 0 Then
            tb_item_name.Text = Trim(ds2.Tables(0).Rows(0)("ITEM_NM").ToString)
            tb_from_box_number.Text = (Integer.Parse(Trim(ds2.Tables(0).Rows(0)("CUR_BOX_NUM").ToString)) + 1).ToString(ABCDConst.Format_Number)
        End If
    End Sub

#End Region

End Class