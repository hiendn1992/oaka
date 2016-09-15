''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_STS001.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   22-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_STS001

#Region "Var/Const Form"

    ''' <summary> Web service. </summary>
    Private ws As New ABCDService.Service

#End Region

#Region "New Form"

    ''' <summary>
    ''' New form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Event load form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STS001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat
        tb_item_code.Focus()
        ' Set value datetimepicker
        dtp_stock_date.Value = DateTime.Now
        dtp_stock_date.CustomFormat = ABCDConst.Format_Date_01
        dtp_stock_date.Format = DateTimePickerFormat.Custom
        ' Set focus warehouse code
        Call ComboBoxWarehouse()
    End Sub

    ''' <summary>
    ''' Event leave warehouse.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cb_warehouse_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_warehouse.Leave

        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {dtp_stock_date, tb_item_code, b_popup_item, b_execute, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            Return
        End If

        '' Check select one warehouse.
        If cb_warehouse.SelectedValue.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR055, "ERR055")
            frmMsg001.ShowDialog()
            cb_warehouse.Focus()
            Return
        End If

        'b_execute.Focus()

    End Sub

    ''' <summary>
    ''' Event leave item code.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_code_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code.Leave
        Dim ds As DataSet = Nothing

        '' Other controls focused.
        Dim ctrlList As New List(Of Control)(New Control() {dtp_stock_date, b_popup_item, cb_warehouse, b_execute, b_exit})
        If Not ABCDCommon.CheckFocusedControls(ctrlList) Then
            ds = ws.GetItemInfoByCd(tb_item_code.Text, ABCDCommon.UserId)
            If ds.Tables(0).Rows.Count <> 0 Then
                tb_item_name.Text = ds.Tables(0).Rows(0)("ITEM_NM").ToString
            Else
                tb_item_name.Text = Nothing
            End If
            Return
        End If

        '' Check item code is null or blank.
        If tb_item_code.Text.Equals("") Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR054, "ERR054")
            frmMsg001.ShowDialog()
            tb_item_code.Focus()
            Return
        End If

        '' Check item code exist in DB.
        ds = ws.GetItemInfoByCd(tb_item_code.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR011, "ERR011")
            frmMsg001.ShowDialog()
            tb_item_code.Focus()
            tb_item_code.SelectAll()
            Return
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            tb_item_name.Text = ds.Tables(0).Rows(0)("ITEM_NM").ToString
        End If
    End Sub

    ''' <summary>
    ''' Event click popup item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_popup_item.Click
        Dim scrPos001 As New frm_POS001(Me)
        scrPos001.ShowDialog()
        b_execute.Focus()
    End Sub

    ''' <summary>
    ''' Event click execute.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_execute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_execute.Click
        Dim frmMsg001 As frm_MSG001 = Nothing
        Dim ds As DataSet = Nothing

        frmMsg001 = New frm_MSG001(Messages.MSG066, "MSG066")
        If frmMsg001.ShowDialog = Windows.Forms.DialogResult.No Then
            frmMsg001.Close()
            Return
        End If
        '' Get list warehouse info tr.
        ds = Nothing
        ds = ws.GetWhInfoTrList(cb_warehouse.SelectedValue, tb_item_code.Text, ABCDCommon.UserId)

        '' Declare 3 list such as: bcNo, whCd, rckCd.
        Dim bcNoList As New List(Of String)
        Dim whSysCdList As New List(Of String)
        Dim rckSysCdList As New List(Of String)
        Dim whActCdList As New List(Of String)
        Dim rckActCdList As New List(Of String)

        '' Set value for 3 list: bcNo, whCd, rckCd.
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                bcNoList.Add(Trim(ds.Tables(0).Rows(i)("BC_NO").ToString))
                whSysCdList.Add(Trim(ds.Tables(0).Rows(i)("WH_CD").ToString))
                rckSysCdList.Add(Trim(ds.Tables(0).Rows(i)("RACK_CD").ToString))
            Next

            '' Execute insert data into STOCK_REQ_DTL_INFO_TR.
            Try

                Dim num As Integer = ws.InsertStockReqDtlInfoTr(dtp_stock_date.Value, cb_warehouse.SelectedValue, tb_item_code.Text, _
                                                                bcNoList.ToArray, whSysCdList.ToArray, rckSysCdList.ToArray, _
                                                                whActCdList.ToArray, rckActCdList.ToArray, ABCDCommon.UserId)

                If num > 0 Then
                    frmMsg001 = New frm_MSG001(Messages.INF036, "INF036")
                    frmMsg001.ShowDialog()
                    tb_item_code.Text = Nothing
                    cb_warehouse.SelectedValue = ""
                    dtp_stock_date.Focus()
                    Return
                End If
            Catch ex As Exception
                frmMsg001 = New frm_MSG001(ex.Message, "ERRSYS")
                frmMsg001.ShowDialog()
                tb_item_code.Focus()
                tb_item_code.SelectAll()
                Return
            End Try
        Else
            frmMsg001 = New frm_MSG001(Messages.ERR013, "ERR013")
            frmMsg001.ShowDialog()
            dtp_stock_date.Focus()
            Return
        End If
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
    ''' Event text changed item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_code_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code.TextChanged
        tb_item_name.Text = Nothing
    End Sub

#End Region

#Region "Function Form"

    ''' <summary>
    ''' Method load combo box warehouse.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ComboBoxWarehouse()
        Dim dictionary As New Dictionary(Of String, String)
        dictionary.Add("", "")
        dictionary.Add("MOLD", "Production")
        dictionary.Add("W830", "Finish good")
        dictionary.Add("W900", "Quality check")
        dictionary.Add("W9902", "Reject")
        cb_warehouse.DataSource = New BindingSource(dictionary, Nothing)
        cb_warehouse.DisplayMember = "Key"
        cb_warehouse.ValueMember = "Key"
    End Sub

#End Region

End Class