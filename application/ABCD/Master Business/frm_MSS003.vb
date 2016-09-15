''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS003.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   06-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources
Imports System.Text.RegularExpressions

Public Class frm_MSS003

#Region "Var/Const Form"

    ''' <summary> Web service. </summary>
    Private wbService As New ABCDService.Service
    Private loginCode As String = ABCDCommon.UserId
    Private customerCodes As New List(Of String)
    ''' <summary> Gridview: column name, column size, column in DB. </summary>
    Private colNames As New List(Of String)(New String() {"", "Customer Id", "Customer Name", "Email", "Tel No", "Fax No", "Address"})
    Private colSizes As New List(Of Integer)(New Integer() {73, 120, 150, 110, 110, 110, 170})
    Private colNameDB As New List(Of String)(New String() {"", "CUS_ID", "CUS_NM", "MAIL_ADD", "TEL_NO", "FAX_NO", "ADDRESS"})
    ''' <summary> Mode process: add, update, delete. </summary>
    Public _mode As Integer = ABCDConst.ModeInit
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
        End Set
    End Property
    ''' <summary> Display form: . </summary>
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
        Call NewForm() '' method init form.
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat '' set format login user and  system date.
        '' init gridview contains customer.
        Dim checkBox As New DataGridViewCheckBoxColumn
        checkBox.Name = "checkSelect"
        checkBox.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_lst_cus.Columns.Insert(0, checkBox)
        ABCDCommon.CreateColumnsInGridView(dgv_lst_cus, colNames, colSizes)
        ABCDCommon.SetReadOnlyForDataGridView(dgv_lst_cus, colNames)
        '' config webservice url and time-out.
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        Call ComboTemplate() '' method init combobox template.
        Call ComboUnit() '' method init combobox unit.
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Event checked changed radio add new item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_add_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb_add.CheckedChanged
        Me.Mode = ABCDConst.ModeAdd
        Me.Display = ABCDConst.DispOnce

        tb_item_code.Focus()
        Call CheckRadioItem(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event checked changed radio update old item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_chg_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb_chg.CheckedChanged
        Me.Mode = ABCDConst.ModeUpd
        Me.Display = ABCDConst.DispOnce

        tb_item_code.Focus()
        Call CheckRadioItem(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event checked changed radio delete old item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rb_del_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rb_del.CheckedChanged
        Me.Mode = ABCDConst.ModeDel
        Me.Display = ABCDConst.DispOnce

        tb_item_code.Focus()
        Call CheckRadioItem(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event leave item code.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_code_Leave(sender As System.Object, e As System.EventArgs) Handles tb_item_code.Leave
        '' Other controls focused.
        Dim controls As New List(Of Control)(New Control() {b_popup_item, b_cancel, b_exit, cbTemplate, cbUnit})
        Dim checkFocused As Boolean = ABCDCommon.CheckFocusedControls(controls)
        If Not checkFocused Then
            Return
        End If

        '' Check value item code null or blank.
        If tb_item_code.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR047, "ERR047")
            frmMsg001.ShowDialog()
            tb_item_code.Focus()
            Return
        End If

        '' Check length item code. Modified 150729
        'If tb_item_code.Text.Length < 6 Then
        '    Dim frmMsg001 As New frm_MSG001(Messages.ERR048, "ERR048")
        '    frmMsg001.ShowDialog()
        '    tb_item_code.Focus()
        '    tb_item_code.SelectAll()
        '    Return
        'End If

        '' Check value exist or not exist in DB.
        If Not CheckDatabase(tb_item_code.Text, ABCDCommon.UserId, Me.Mode) Then
            Return
        End If

        '' Call method display when item code valid.
        tb_item_code.Text = RTrim(LTrim(tb_item_code.Text))
        tb_item_code.Text = Regex.Replace(tb_item_code.Text, " {2,}", " ")

        '' Check value item code is null and blank.
        If tb_item_code.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR047, "ERR047")
            frmMsg001.ShowDialog()
            tb_item_code.Focus()
            Return
        End If

        Call DisplayAfterLeaveItemId(Me.Mode)
        tb_item_name.Focus()
        Return
    End Sub

    ''' <summary>
    ''' Event leave item name.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_name_Leave(sender As System.Object, e As System.EventArgs) Handles tb_item_name.Leave
        Dim controls As New List(Of Control)(New Control() {tb_quantity, dgv_lst_cus, b_select_all, b_unselect_all, _
                                                            b_add_cus, b_del_cus, tb_cus_id, b_popup_cus, b_exec, _
                                                            b_cancel, b_exit, cbTemplate, cbUnit})
        '' Other control focused.
        If Not ABCDCommon.CheckFocusedControls(controls) Then
            tb_item_name.Text = Regex.Replace((LTrim(tb_item_name.Text)), " {2,}", "")
            Return
        End If

        '' Check item name null or blank.
        If tb_item_name.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR049, "ERR049")
            frmMsg001.ShowDialog()
            tb_item_name.Focus()
            Return
        End If

        '' Check item name must have least 6 characters.(Modified - 150729: cuongtk)
        'If tb_item_name.Text.Length < 6 Then
        '    Dim frmMsg001 As New frm_MSG001(Messages.ERR050, "ERR050")
        '    frmMsg001.ShowDialog()
        '    tb_item_name.Focus()
        '    tb_item_name.SelectAll()
        '    Return
        'End If

        tb_item_name.Text = Regex.Replace(RTrim(LTrim(tb_item_name.Text)), " {2,}", "")
        tb_quantity.Text = tb_quantity.Text.Replace(",", "")
        tb_quantity.Focus()
    End Sub

    ''' <summary>
    ''' Event leave quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_Leave(sender As System.Object, e As System.EventArgs) Handles tb_quantity.Leave
        Dim controls As New List(Of Control)(New Control() {tb_item_name, dgv_lst_cus, b_select_all, b_unselect_all, _
                                                            b_add_cus, b_del_cus, tb_cus_id, b_popup_cus, b_exec, _
                                                            b_cancel, b_exit, cbTemplate, cbUnit, tb_path_image_01, tb_path_image_02, _
                                                            tb_path_image_03, tb_path_image_04, tb_path_image_05, b_browse_01, _
                                                            b_browse_02, b_browse_03, b_browse_04, b_browse_05, tb_orotex_no})
        '' Other control focused.
        If Not ABCDCommon.CheckFocusedControls(controls) Then
            If Not tb_quantity.Text.Equals("") Then
                tb_quantity.Text = Integer.Parse(tb_quantity.Text).ToString(ABCDConst.Format_Number)
                If tb_quantity.Text.Equals("") Then
                    tb_quantity.Text = "0"
                End If
            Else
                tb_quantity.Text = Nothing
            End If
            Return
        End If

        If tb_quantity.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR069, "ERR069")
            frmMsg001.ShowDialog()
            tb_quantity.Focus()
            Return
        End If

        '' Check value diff zero.
        If Integer.Parse(tb_quantity.Text.Replace(",", "")) = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR051, "ERR051")
            frmMsg001.ShowDialog()
            tb_quantity.Focus()
            tb_quantity.SelectAll()
            Return
        End If

        tb_quantity.Text = Integer.Parse(tb_quantity.Text.Replace(",", "")).ToString(ABCDConst.Format_Number)
    End Sub

    ''' <summary>
    ''' Event keypress quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_quantity.KeyPress
        Call ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    ''' <summary>
    ''' Event click popup customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_cus_Click(sender As System.Object, e As System.EventArgs) Handles b_popup_cus.Click
        Dim scrPos005 As New frm_POS005(Me)
        scrPos005.ShowDialog()
    End Sub

    ''' <summary>
    ''' Event click popup item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_item_Click(sender As System.Object, e As System.EventArgs) Handles b_popup_item.Click
        Dim scrPos001 As New frm_POS001(Me)

        If scrPos001.ShowDialog = Windows.Forms.DialogResult.Ignore Then
            tb_item_code.Focus()
            Return
        End If
        Dim itemCode As String = tb_item_code.Text
        If Not CheckDatabase(itemCode, loginCode, Me.Mode) Then
            Return
        End If
        Call DisplayAfterLeaveItemId(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event click select all customer on grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_select_all_Click(sender As System.Object, e As System.EventArgs) Handles b_select_all.Click
        Call ABCDCommon.SelectAllCheckBox(dgv_lst_cus, ABCDConst.SELECTED)
    End Sub

    ''' <summary>
    ''' Event click unselect all customer on grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_unselect_all_Click(sender As System.Object, e As System.EventArgs) Handles b_unselect_all.Click
        Call ABCDCommon.SelectAllCheckBox(dgv_lst_cus, ABCDConst.UN_SELECTED)
    End Sub

    ''' <summary>
    ''' Event click add customer on grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_add_cus_Click(sender As System.Object, e As System.EventArgs) Handles b_add_cus.Click
        Dim ds As DataSet = wbService.GetCustomerInfoByID(tb_cus_id.Text, loginCode)
        If Not ABCDCommon.CheckDataExistInGridView(dgv_lst_cus, tb_cus_id.Text) Then
            Dim msgError As String = "Data exist on gridview!"
            Dim scrError As New frm_MSG001(msgError, "ERR")
            If scrError.ShowDialog = Windows.Forms.DialogResult.OK Then
                scrError.Close()
                tb_cus_id.Focus()
                tb_cus_id.SelectAll()
                Return
            End If
        End If
        Call ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, dgv_lst_cus, ABCDConst.GRIDVIEW_CHECKBOX)
        tb_cus_id.Text = Nothing
        tb_cus_name.Text = Nothing
        tb_cus_id.Focus()
    End Sub

    ''' <summary>
    ''' Event click delete customer on grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_del_cus_Click(sender As System.Object, e As System.EventArgs) Handles b_del_cus.Click
        Call ABCDCommon.RemoveValueUncheckOnGridView(dgv_lst_cus)
    End Sub

    ''' <summary>
    ''' Event click execute add, change, delete info item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exec.Click
        '' Check item name null or blank.
        If tb_item_name.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR049, "ERR049")
            frmMsg001.ShowDialog()
            tb_item_name.Focus()
            Return
        End If

        '' Check item name must have least 6 characters.
        'If tb_item_name.Text.Length < 6 Then
        '    Dim frmMsg001 As New frm_MSG001(Messages.ERR050, "ERR050")
        '    frmMsg001.ShowDialog()
        '    tb_item_name.Focus()
        '    tb_item_name.SelectAll()
        '    Return
        'End If

        If tb_quantity.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR069, "ERR069")
            frmMsg001.ShowDialog()
            tb_quantity.Focus()
            Return
        End If

        '' Check value diff zero.
        If Integer.Parse(tb_quantity.Text.Replace(",", "")) = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR051, "ERR051")
            frmMsg001.ShowDialog()
            tb_quantity.Focus()
            tb_quantity.SelectAll()
            Return
        End If

        '' Check combo box selected value.
        If cbUnit.SelectedIndex = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR053, "ERR053")
            frmMsg001.ShowDialog()
            cbUnit.Focus()
            Return
        End If

        '' Check value combo box is selected.
        If cbTemplate.SelectedIndex = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR052, "ERR052")
            frmMsg001.ShowDialog()
            cbTemplate.Focus()
            Return
        End If

        If cbTemplate.SelectedIndex = 4 And tb_orotex_no.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR070, "ERR070")
            frmMsg001.ShowDialog()
            tb_orotex_no.Focus()
            Return
        End If

        '' Check list customer null.
        If dgv_lst_cus.RowCount = 0 Then
            Dim frm As New frm_MSG001("Customer information is not found !", "ERR028")
            frm.ShowDialog()
            b_add_cus.Focus()
            Return
        End If

        Call ClickExecute(Me.Mode)
    End Sub

    ''' <summary>
    ''' Event click cancel clear value on form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_cancel.Click
        Call ClickCancel(Me.Display, Me.Mode)
    End Sub

    ''' <summary>
    ''' Event click exit form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(sender As System.Object, e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Leave combo box Template.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbTemplate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTemplate.Leave
        Dim ctrlList As New List(Of Control)(New Control() {tb_item_name, tb_quantity, cbUnit, dgv_lst_cus, b_select_all, b_unselect_all, _
                                                            b_add_cus, b_del_cus, b_popup_cus, tb_cus_id, tb_cus_name, b_exec, b_exit, b_cancel})
        '' Check all controls focused diff control is processing.
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check value combo box is selected.
        If cbTemplate.SelectedIndex = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR052, "ERR052")
            frmMsg001.ShowDialog()
            cbTemplate.Focus()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Leave combo box Unit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbUnit_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUnit.Leave
        Dim ctrlList As New List(Of Control)(New Control() {tb_item_name, tb_quantity, cbTemplate, tb_cus_id, tb_cus_name, dgv_lst_cus, b_select_all, _
                                                            b_unselect_all, b_add_cus, b_del_cus, b_exec, b_cancel, b_exit, b_popup_cus})
        '' Check all diff controls focused.
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check combo box selected value.
        If cbUnit.SelectedIndex = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR053, "ERR053")
            frmMsg001.ShowDialog()
            cbUnit.Focus()
            Return
        End If

        'tb_cus_id.Focus()
    End Sub

    ''' <summary>
    ''' Event mouse click quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_quantity.MouseClick
        tb_quantity.Text = tb_quantity.Text.Replace(",", "")
        tb_quantity.SelectAll()
    End Sub

    ''' <summary>
    ''' Event text changed customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.TextChanged
        tb_cus_name.Text = Nothing
    End Sub

    ''' <summary>
    ''' Event leave customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.Leave
        Dim ds As DataSet = wbService.GetCustomerInfoByID(tb_cus_id.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count = 1 Then
            tb_cus_name.Text = Trim(ds.Tables(0).Rows(0)("CUS_NM").ToString)
        End If
    End Sub

    Private Sub cbTemplate_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTemplate.SelectedValueChanged
        If cbTemplate.SelectedIndex = 0 Then
            tb_orotex_no.Enabled = False
            tb_path_image_01.Enabled = False
            b_browse_01.Enabled = False
            tb_path_image_02.Enabled = False
            b_browse_02.Enabled = False
            tb_path_image_03.Enabled = False
            b_browse_03.Enabled = False
            tb_path_image_04.Enabled = False
            b_browse_04.Enabled = False
            tb_path_image_05.Enabled = False
            b_browse_05.Enabled = False
            Return
        End If
        If cbTemplate.SelectedIndex = 4 Then
            tb_orotex_no.Enabled = True
            tb_path_image_01.Enabled = True
            b_browse_01.Enabled = True
            tb_path_image_02.Enabled = True
            b_browse_02.Enabled = True
            tb_path_image_03.Enabled = True
            b_browse_03.Enabled = True
            tb_path_image_04.Enabled = True
            b_browse_04.Enabled = True
            tb_path_image_05.Enabled = True
            b_browse_05.Enabled = True
            Return
        End If
        tb_orotex_no.Enabled = False
        tb_path_image_01.Enabled = True
        b_browse_01.Enabled = True
        tb_path_image_02.Enabled = True
        b_browse_02.Enabled = True
        tb_path_image_03.Enabled = True
        b_browse_03.Enabled = True
        tb_path_image_04.Enabled = True
        b_browse_04.Enabled = True
        tb_path_image_05.Enabled = True
        b_browse_05.Enabled = True
        Return
    End Sub

    Private Sub b_browse_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_browse_01.Click
        OpenFileDialog1.InitialDirectory = Configuration.ConfigurationManager.AppSettings("MSS003")
        OpenFileDialog1.Filter = ABCDConst.Format_Image
        OpenFileDialog1.FileName = Nothing
        OpenFileDialog1.ShowDialog()
        tb_path_image_01.Focus()
        tb_path_image_01.Text = IO.Path.GetFileName(OpenFileDialog1.FileName)
        tb_path_image_01.SelectAll()
        Return
    End Sub

    Private Sub b_browse_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_browse_02.Click
        OpenFileDialog1.InitialDirectory = Configuration.ConfigurationManager.AppSettings("MSS003")
        OpenFileDialog1.Filter = ABCDConst.Format_Image
        OpenFileDialog1.FileName = Nothing
        OpenFileDialog1.ShowDialog()
        tb_path_image_02.Focus()
        tb_path_image_02.Text = IO.Path.GetFileName(OpenFileDialog1.FileName)
        tb_path_image_02.SelectAll()
    End Sub

    Private Sub b_browse_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_browse_03.Click
        OpenFileDialog1.InitialDirectory = Configuration.ConfigurationManager.AppSettings("MSS003")
        OpenFileDialog1.Filter = ABCDConst.Format_Image
        OpenFileDialog1.FileName = Nothing
        OpenFileDialog1.ShowDialog()
        tb_path_image_03.Focus()
        tb_path_image_03.Text = IO.Path.GetFileName(OpenFileDialog1.FileName)
        tb_path_image_03.SelectAll()
    End Sub

    Private Sub b_browse_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_browse_04.Click
        OpenFileDialog1.InitialDirectory = Configuration.ConfigurationManager.AppSettings("MSS003")
        OpenFileDialog1.Filter = ABCDConst.Format_Image
        OpenFileDialog1.FileName = Nothing
        OpenFileDialog1.ShowDialog()
        tb_path_image_04.Focus()
        tb_path_image_04.Text = IO.Path.GetFileName(OpenFileDialog1.FileName)
        tb_path_image_04.SelectAll()
    End Sub

    Private Sub b_browse_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_browse_05.Click
        OpenFileDialog1.InitialDirectory = Configuration.ConfigurationManager.AppSettings("MSS003")
        OpenFileDialog1.Filter = ABCDConst.Format_Image
        OpenFileDialog1.FileName = Nothing
        OpenFileDialog1.ShowDialog()
        tb_path_image_05.Focus()
        tb_path_image_05.Text = IO.Path.GetFileName(OpenFileDialog1.FileName)
        tb_path_image_05.SelectAll()
    End Sub

#End Region

#Region "Function Form"

    ''' <summary>
    ''' Method new form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub NewForm()
        rb_add.Checked = False
        rb_chg.Checked = False
        rb_del.Checked = False
        rb_add.Enabled = True
        rb_chg.Enabled = True
        rb_del.Enabled = True
        tb_item_code.Text = Nothing
        tb_item_name.Text = Nothing
        tb_quantity.Text = Nothing
        tb_cus_id.Text = Nothing
        tb_cus_name.Text = Nothing
        dgv_lst_cus.Rows.Clear()
        tb_item_code.Enabled = False
        tb_item_name.Enabled = False
        tb_quantity.Enabled = False
        tb_cus_id.Enabled = False
        tb_cus_name.Enabled = False
        dgv_lst_cus.Enabled = False
        cbUnit.Enabled = False
        cbTemplate.Enabled = False
        tb_orotex_no.Enabled = False
        tb_path_image_01.Enabled = False
        tb_path_image_02.Enabled = False
        tb_path_image_03.Enabled = False
        tb_path_image_04.Enabled = False
        tb_path_image_05.Enabled = False
        b_popup_item.Enabled = False
        b_browse_01.Enabled = False
        b_browse_02.Enabled = False
        b_browse_03.Enabled = False
        b_browse_04.Enabled = False
        b_browse_05.Enabled = False
        b_popup_cus.Enabled = False
        b_select_all.Enabled = False
        b_unselect_all.Enabled = False
        b_add_cus.Enabled = False
        b_del_cus.Enabled = False
        b_exec.Enabled = False
        b_cancel.Enabled = False
        b_exit.Enabled = True
    End Sub

    ''' <summary>
    ''' Method checked radio process item: add, update, delete.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub CheckRadioItem(ByVal mode As Integer)
        If mode = 1 Then
            rb_add.Enabled = False
            rb_chg.Enabled = False
            rb_del.Enabled = False

            tb_item_code.Enabled = True

            b_cancel.Enabled = True

            tb_item_code.Focus()

            Return
        End If

        If mode = 2 Then
            rb_add.Enabled = False
            rb_chg.Enabled = False
            rb_del.Enabled = False

            tb_item_code.Enabled = True
            b_popup_item.Enabled = True

            b_cancel.Enabled = True

            tb_item_code.Focus()

            Return
        End If

        If mode = 3 Then
            rb_add.Enabled = False
            rb_chg.Enabled = False
            rb_del.Enabled = False

            tb_item_code.Enabled = True
            b_popup_item.Enabled = True

            b_cancel.Enabled = True

            tb_item_code.Focus()

            Return
        End If
    End Sub

    ''' <summary>
    ''' Method click cancel.
    ''' </summary>
    ''' <param name="display"></param>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub ClickCancel(ByVal display As Integer, _
                            ByVal mode As Integer)
        If display = 1 Then
            RemoveHandler rb_add.CheckedChanged, AddressOf rb_add_CheckedChanged
            rb_add.Checked = False
            AddHandler rb_add.CheckedChanged, AddressOf rb_add_CheckedChanged
            RemoveHandler rb_chg.CheckedChanged, AddressOf rb_chg_CheckedChanged
            rb_chg.Checked = False
            AddHandler rb_chg.CheckedChanged, AddressOf rb_chg_CheckedChanged
            RemoveHandler rb_del.CheckedChanged, AddressOf rb_del_CheckedChanged
            rb_del.Checked = False
            AddHandler rb_del.CheckedChanged, AddressOf rb_del_CheckedChanged

            rb_add.Enabled = True
            rb_chg.Enabled = True
            rb_del.Enabled = True

            tb_item_code.Text = Nothing
            tb_item_code.Enabled = False

            If mode = 2 Or mode = 3 Then
                b_popup_item.Enabled = False
            End If

            b_cancel.Enabled = False

            Me.Display = 0
            Return
        End If

        If display = 2 Then
            tb_item_name.Text = Nothing
            tb_quantity.Text = Nothing
            tb_cus_id.Text = Nothing
            tb_cus_name.Text = Nothing
            tb_path_image_01.Text = Nothing
            tb_path_image_02.Text = Nothing
            tb_path_image_03.Text = Nothing
            tb_path_image_04.Text = Nothing
            tb_path_image_05.Text = Nothing
            tb_orotex_no.Text = Nothing
            cbTemplate.SelectedValue = 0
            cbUnit.SelectedValue = 0
            dgv_lst_cus.Rows.Clear()

            tb_item_code.Enabled = True

            If mode = 2 Or mode = 3 Then
                b_popup_item.Enabled = True
            End If

            tb_item_name.Enabled = False
            tb_quantity.Enabled = False
            tb_cus_id.Enabled = False
            tb_cus_name.Enabled = False
            tb_path_image_01.Enabled = False
            tb_path_image_02.Enabled = False
            tb_path_image_03.Enabled = False
            tb_path_image_04.Enabled = False
            tb_path_image_05.Enabled = False
            tb_orotex_no.Enabled = False
            dgv_lst_cus.Enabled = False
            cbUnit.Enabled = False
            cbTemplate.Enabled = False

            b_browse_01.Enabled = False
            b_browse_02.Enabled = False
            b_browse_03.Enabled = False
            b_browse_04.Enabled = False
            b_browse_05.Enabled = False
            b_exec.Enabled = False
            b_popup_cus.Enabled = False
            b_select_all.Enabled = False
            b_unselect_all.Enabled = False
            b_add_cus.Enabled = False
            b_del_cus.Enabled = False

            tb_item_code.Focus()
            tb_item_code.SelectAll()
            Me.Display = 1
            Return
        End If
    End Sub

    ''' <summary>
    ''' Method check database.
    ''' </summary>
    ''' <param name="itemCode"></param>
    ''' <param name="loginCode"></param>
    ''' <param name="mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDatabase(ByVal itemCode As String, _
                                   ByVal loginCode As String, _
                                   ByVal mode As Integer) As Boolean
        Dim ds As DataSet = wbService.GetItemInfoByCd(itemCode, loginCode)
        Dim rNum As Integer = ds.Tables(0).Rows.Count

        If mode = 1 Then '' Case add item code.
            If rNum >= 1 Then
                Dim frmMsg001 As New frm_MSG001(Messages.ERR012, "ERR012")
                frmMsg001.ShowDialog()
                tb_item_code.Focus()
                tb_item_code.SelectAll()
                Return False
            End If

            Return True
        End If

        If mode <> 1 Then '' Case update and delete item code.
            If rNum = 0 Then
                Dim frmMsg001 As New frm_MSG001(Messages.ERR011, "ERR011")
                frmMsg001.ShowDialog()
                tb_item_code.Focus()
                tb_item_code.SelectAll()
                Return False
            End If

            If mode = 3 Then '' Case item code exist tables.
                ds = Nothing
                ds = wbService.GetProductInfoByItemCode(tb_item_code.Text, ABCDCommon.UserId)
                If Integer.Parse(ds.Tables(0).Rows(0)("NUM_ITEM").ToString) > 0 Then
                    Dim frmMsg001 As New frm_MSG001(Messages.ERR056, "ERR056")
                    frmMsg001.ShowDialog()
                    tb_item_code.Focus()
                    tb_item_code.SelectAll()
                    Return False
                End If
            End If

            '' Get info customer and info item by item code.
            ds = New DataSet
            ds = wbService.GetItemCustomerInfoByCd(itemCode, loginCode)
            dgv_lst_cus.Rows.Clear()
            '// Cuongtk - AIT) START
            If ds.Tables(0).Rows.Count <> 0 Then
                Call SetDataForControl(ds) '' Call method set data for controls.
            Else
                ds = New DataSet
                ds = wbService.GetItemInfoByCd(itemCode, loginCode)
                tb_item_name.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
                tb_quantity.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("QTY").ToString)).ToString(ABCDConst.Format_Number)
                cbUnit.SelectedValue = Integer.Parse(Trim(ds.Tables(0).Rows(0)("UNIT").ToString))
                cbTemplate.SelectedValue = Integer.Parse(Trim(ds.Tables(0).Rows(0)("TEMP_TYPE").ToString))
                tb_orotex_no.Text = Trim(ds.Tables(0).Rows(0)("OROTEX_NO").ToString)
                tb_path_image_01.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH1").ToString)
                tb_path_image_02.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH2").ToString)
                tb_path_image_03.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH3").ToString)
                tb_path_image_04.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH4").ToString)
                tb_path_image_05.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH5").ToString)
            End If
            '// Cuongtk - AIT) E N D
            Return True
        End If
    End Function

    ''' <summary>
    ''' Method display after leave item code.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub DisplayAfterLeaveItemId(ByVal mode As Integer)
        Me.Display = 2

        tb_item_code.Enabled = False
        b_exec.Enabled = True

        If mode = 1 Then
            cbUnit.Enabled = True
            cbTemplate.Enabled = True
            tb_item_name.Enabled = True
            tb_quantity.Enabled = True
            tb_cus_id.Enabled = True
            tb_cus_name.Enabled = False
            dgv_lst_cus.Enabled = True

            b_popup_cus.Enabled = True
            b_select_all.Enabled = True
            b_unselect_all.Enabled = True
            b_add_cus.Enabled = True
            b_del_cus.Enabled = True

            'tb_quantity.Text = "0"
            Return
        End If

        If mode = 2 Then
            cbUnit.Enabled = True
            cbTemplate.Enabled = True
            tb_item_name.Enabled = True
            tb_quantity.Enabled = True
            tb_cus_id.Enabled = True
            tb_cus_name.Enabled = False
            dgv_lst_cus.Enabled = True

            b_popup_item.Enabled = False
            b_popup_cus.Enabled = True
            b_select_all.Enabled = True
            b_unselect_all.Enabled = True
            b_add_cus.Enabled = True
            b_del_cus.Enabled = True

            Return
        End If

        If mode = 3 Then
            cbUnit.Enabled = False
            cbTemplate.Enabled = False
            tb_item_name.Enabled = False
            tb_quantity.Enabled = False
            tb_cus_id.Enabled = False
            tb_cus_name.Enabled = False
            dgv_lst_cus.Enabled = False
            tb_path_image_01.Enabled = False
            tb_path_image_02.Enabled = False
            tb_path_image_03.Enabled = False
            tb_path_image_04.Enabled = False
            tb_path_image_05.Enabled = False
            b_popup_item.Enabled = False
            b_popup_cus.Enabled = False
            b_select_all.Enabled = False
            b_unselect_all.Enabled = False
            b_add_cus.Enabled = False
            b_del_cus.Enabled = False
            b_browse_01.Enabled = False
            b_browse_02.Enabled = False
            b_browse_03.Enabled = False
            b_browse_04.Enabled = False
            b_browse_05.Enabled = False
            Return
        End If
    End Sub

    ''' <summary>
    ''' Method set data for control(Update, Delete).
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Private Sub SetDataForControl(ByVal ds As DataSet)
        tb_item_name.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
        tb_quantity.Text = Integer.Parse(Trim(ds.Tables(0).Rows(0)("QTY").ToString)).ToString(ABCDConst.Format_Number)
        cbUnit.SelectedValue = Integer.Parse(Trim(ds.Tables(0).Rows(0)("UNIT").ToString))
        cbTemplate.SelectedValue = Integer.Parse(Trim(ds.Tables(0).Rows(0)("TEMP_TYPE").ToString))
        tb_orotex_no.Text = Trim(ds.Tables(0).Rows(0)("OROTEX_NO").ToString)
        tb_path_image_01.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH1").ToString)
        tb_path_image_02.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH2").ToString)
        tb_path_image_03.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH3").ToString)
        tb_path_image_04.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH4").ToString)
        tb_path_image_05.Text = Trim(ds.Tables(0).Rows(0)("IMG_PATH5").ToString)
        Call ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, dgv_lst_cus, ABCDConst.GRIDVIEW_CHECKBOX)
        Return
    End Sub

    ''' <summary>
    ''' Method execute data: add, update, delete.
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub ClickExecute(ByVal mode As Integer)
        Dim itemCode As String = tb_item_code.Text
        Dim itemName As String = tb_item_name.Text
        Dim quantity As Integer = Integer.Parse(Replace(tb_quantity.Text, ",", ""))
        customerCodes = ABCDCommon.AddGridViewToList(dgv_lst_cus, customerCodes)

        If mode = 1 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG035, "MSG035")

            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim rNum As Integer = wbService.InsertItemInfo(itemCode, itemName, quantity, cbUnit.SelectedValue, _
                                                                   cbTemplate.SelectedValue, tb_orotex_no.Text, tb_path_image_01.Text, _
                                                                   tb_path_image_02.Text, tb_path_image_03.Text, tb_path_image_04.Text, _
                                                                   tb_path_image_05.Text, customerCodes.ToArray, loginCode)

                    If rNum >= 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF036, "INF036")
                        frmMsg001.ShowDialog()
                        tb_item_code.Text = Nothing
                        tb_item_code.Focus()
                        Call ClickCancel(Me.Display, Me.Mode)
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                End Try
            Else
                frmMsg001.Close()
                Return
            End If
        End If

        If mode = 2 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG037, "MSG037")

            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim rNum As Integer = wbService.UpdateItemInfo(itemCode, itemName, quantity, _
                                                                   cbUnit.SelectedValue, cbTemplate.SelectedValue, _
                                                                   tb_orotex_no.Text, tb_path_image_01.Text, _
                                                                   tb_path_image_02.Text, tb_path_image_03.Text, tb_path_image_04.Text, _
                                                                   tb_path_image_05.Text, _
                                                                   customerCodes.ToArray, loginCode)

                    If rNum >= 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF038, "INF038")
                        frmMsg001.ShowDialog()
                        tb_item_code.Focus()
                        Call ClickCancel(Me.Display, Me.Mode)
                    End If
                Catch ex As Exception
                    frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                    frmMsg001.ShowDialog()
                End Try
            Else
                frmMsg001.Close()
                Return
            End If
        End If

        If mode = 3 Then
            Dim frmMsg001 As New frm_MSG001(Messages.MSG039, "MSG039")

            If frmMsg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim rNum As Integer = wbService.DeleteItemInfo(itemCode, loginCode)

                    If rNum >= 1 Then
                        frmMsg001 = New frm_MSG001(Messages.INF040, "INF040")
                        frmMsg001.ShowDialog()
                        tb_item_code.Text = Nothing
                        tb_item_code.Focus()
                        Call ClickCancel(Me.Display, Me.Mode)
                    End If
                Catch ex As Exception
                    Dim scrError As New frm_MSG001(ex.Message, "ERRSYS")
                    scrError.ShowDialog()
                End Try
            Else
                frmMsg001.Close()
                Return
            End If
        End If
    End Sub

    ''' <summary>
    '''  Method combo box Unit.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ComboUnit()
        '' Get data from web service.
        Dim ds As DataSet = wbService.GetCodeMasterMS(ABCDConst.Type_Unit, ABCDCommon.UserId)
        '' Set data for combobox unit.
        cbUnit.DataSource = ds.Tables(0)
        cbUnit.DisplayMember = "CODE_NAME"
        cbUnit.ValueMember = "CODE_02"
    End Sub

    ''' <summary>
    ''' Method combo box template.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ComboTemplate()
        '' Get data from web service.
        Dim ds As DataSet = wbService.GetCodeMasterMS(ABCDConst.Type_Template, ABCDCommon.UserId)
        '' Set data for combobox template.
        cbTemplate.DataSource = ds.Tables(0)
        cbTemplate.DisplayMember = "CODE_NAME"
        cbTemplate.ValueMember = "CODE_02"
    End Sub

#End Region

End Class