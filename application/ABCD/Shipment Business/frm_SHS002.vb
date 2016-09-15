''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_SHS002.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-16    1.00    Hungtg   New
''*********************************************************
Public Class frm_SHS002
#Region "Var/Const Form."
    Private ws As New ABCDService.Service
    Private ds As DataSet = Nothing
    ''' <summary>
    ''' Set display for controls when click Cancel.
    ''' </summary>
    ''' <remarks></remarks>
    Private _dispOpt As Integer
    Public Property DispOpt() As Integer
        Get
            Return _dispOpt
        End Get
        Set(ByVal value As Integer)
            _dispOpt = value
        End Set
    End Property

    Private ColNames As New List(Of String)(New String() {"No", _
                                                                "Warehouse Code", _
                                                                  "Warehouse Name", _
                                                                  "Rack No", _
                                                                  "Rack Name", _
                                                                  "Item Code", _
                                                                  "Item Name", _
                                                                  "Barcode No", _
                                                                  "BoxNum", _
                                                                  "Qty"})

    Private ColSizes As New List(Of Integer)(New Integer() {24, _
                                                                    75, _
                                                                    80, _
                                                                    50, _
                                                                    60, _
                                                                    60, _
                                                                    70, _
                                                                    100, _
                                                                    60, _
                                                                    40})

#End Region
#Region "New Form"
    ''' <summary>
    ''' Initialize Form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = ABCDConst.STRING_TIMEOUT

        'Load shipment status
        LoadShipmentStatus()

        lb_today.Text = ABCDCommon.GetSystemDateWithFormat

        'Call DisplayOption to set control display
        _dispOpt = 1
        DisplayOption(_dispOpt)

        ' Set display datagridview.    
        ABCDCommon.CreateColumnsInGridView(grd_shipment_inquiry, _
                                                                                            ColNames, _
                                                                                            ColSizes)

    End Sub
#End Region
#Region "Event Form"
    ''' <summary>
    ''' Event click button Exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' Event click button Clear.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        If _dispOpt = 1 Then
            ClearScreen()
            Return
        End If
        _dispOpt = _dispOpt - 1
        DisplayOption(_dispOpt)
    End Sub
    ''' <summary>
    ''' Event click button Search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click

        'Check empty condition
        If cb_ship_status.Text = "" And _
            txt_ship_req_no.Text = "" And _
            dtp_ship_req_date_from.CustomFormat = " " And _
            dtp_ship_req_date_to.CustomFormat = " " And _
            dtp_ship_date_from.CustomFormat = " " And _
            dtp_ship_date_to.CustomFormat = " " And _
            txt_cus_id.Text = "" And _
            txt_cus_po.Text = "" And _
            txt_invoice_no.Text = "" And _
            dtp_invoice_date.CustomFormat = " " Then
            Dim strError As String = "Please setup asleast one condition!"
            Dim msgError As New frm_MSG001(strError, "ERR999")
            If msgError.ShowDialog() = DialogResult.OK Then
                msgError.Close()
            End If
            Return
        End If

        'Error message
        Dim errMsg As String = ""

        If dtp_ship_req_date_from.Value.Date > dtp_ship_req_date_to.Value.Date Then
            errMsg = errMsg & "Please input ship request date from value less than or equal to the date to value" & vbLf
        End If
        If dtp_ship_date_from.Value.Date > dtp_ship_date_to.Value.Date Then
            errMsg = errMsg & "Please input ship date from value less than or equal to the ship date to value" & vbLf
        End If

        'Raise message if have errors
        If Not errMsg.Replace(vbLf, "").Equals("") Then
            Dim msgError As New frm_MSG001(errMsg, "ERR999")
            If msgError.ShowDialog() = DialogResult.OK Then
                msgError.Close()
            End If
            Return
        End If


        'Set date condition       
        Dim shipReqDateFrom As String = If(dtp_ship_req_date_from.Checked, _
                                                                               dtp_ship_req_date_from.Value.Date.ToString("yyyyMMdd"), _
                                                                               "")
        Dim shipReqDateTo As String = If(dtp_ship_req_date_to.Checked, _
                                                                           dtp_ship_req_date_to.Value.Date.ToString("yyyyMMdd"), _
                                                                           "")
        Dim shipDateFrom As String = If(dtp_ship_date_from.Checked, _
                                                                       dtp_ship_date_from.Value.Date.ToString("yyyyMMdd"), _
                                                                       "")
        Dim shipDateTo As String = If(dtp_ship_date_to.Checked, _
                                                                   dtp_ship_date_to.Value.Date.ToString("yyyyMMdd"), _
                                                                   "")
        Dim invoiceDate As String = If(dtp_invoice_date.Checked, _
                                                                   dtp_invoice_date.Value.Date.ToString("yyyyMMdd"), _
                                                                   "")
        'Get shipmen list result for gridview
        ds = ws.ShipmentInquiry(DirectCast(cb_ship_status.SelectedItem, KeyValuePair(Of String, String)).Key, _
                                                        txt_ship_req_no.Text, _
                                                        shipReqDateFrom, _
                                                        shipReqDateTo, _
                                                        shipDateFrom, _
                                                        shipDateTo, _
                                                        txt_cus_id.Text, _
                                                        txt_cus_po.Text, _
                                                        txt_invoice_no.Text, _
                                                       invoiceDate, _
                                                        ABCDCommon.UserId)

        grd_shipment_inquiry.Rows.Clear()
        ' Get data for gridview.
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 1
            Dim arr(10) As String
            arr(0) = i + 1.ToString()
            arr(1) = ds.Tables(0).Rows(i)("WH_CD").ToString
            arr(2) = ds.Tables(0).Rows(i)("WH_NM").ToString
            arr(3) = ds.Tables(0).Rows(i)("RACK_CD").ToString
            arr(4) = ds.Tables(0).Rows(i)("RACK_NM").ToString
            arr(5) = ds.Tables(0).Rows(i)("ITEM_CD").ToString
            arr(6) = ds.Tables(0).Rows(i)("ITEM_NM").ToString
            arr(7) = ds.Tables(0).Rows(i)("BC_NO").ToString
            arr(8) = ds.Tables(0).Rows(i)("BOX_NUM").ToString
            arr(9) = ds.Tables(0).Rows(i)("QTY").ToString

            grd_shipment_inquiry.Rows.Add(arr)
        Next
        If ABCDCommon.CheckGridViewIsNothing(grd_shipment_inquiry) = False Then
            Return
        Else
            _dispOpt = 2
            DisplayOption(_dispOpt)
        End If
    End Sub
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        '' Check datagrid view is empty.
        If grd_shipment_inquiry.Rows.Count = 0 Then
            Dim strError As String = "Data is empty, please excute inquiry first!"
            Dim frm_msg As New frm_MSG001(strError, "ERR028")
            If frm_msg.ShowDialog = Windows.Forms.DialogResult.OK Then
                frm_msg.Close()
                Return
            End If
        End If
        '' Execute main: export CSV.
        sfdDialog.Filter = "CSV Files (*.csv*) | *.csv"
        sfdDialog.FileName = "SHS002" & DateTime.Now.ToString("ddMMyyyy")
        If sfdDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fn As String = sfdDialog.FileName
            ABCDCommon.ExportGridViewIntoCSV(grd_shipment_inquiry, fn)
        End If
    End Sub
    Private Sub btn_popup_cus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_cus.Click
        Dim popupCus As New frm_POS005(Me)
        popupCus.ShowDialog()
        txt_cus_id.Focus()
        txt_cus_id.SelectAll()
    End Sub

    Private Sub txt_cus_id_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cus_id.Leave
        ' Focus popup.
        If btn_popup_cus.Focused Then
            Return
        End If
        ' Focus cancel.
        If btn_cancel.Focused Then
            Return
        End If
        ' Focus exit.
        If btn_exit.Focused Then
            Return
        End If
        If Not txt_cus_id.Text.Equals("") Then
            Dim dsCus As DataSet = ws.GetCustomerInfoByID(txt_cus_id.Text, ABCDCommon.UserId)
            If dsCus.Tables(0).Rows.Count <> 0 Then
                txt_cus_name.Text = dsCus.Tables(0).Rows(0)("CUS_NM").ToString
            Else
                txt_cus_name.Text = ""
                Return
            End If
        Else
            txt_cus_name.Text = ""
        End If
    End Sub
    Private Sub dtp_ship_req_date_from_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_ship_req_date_from.ValueChanged
        Call ABCDCommon.ChangeDateTimePicker(dtp_ship_req_date_from)
    End Sub
    Private Sub dtp_ship_req_date_to_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_ship_req_date_to.ValueChanged
        Call ABCDCommon.ChangeDateTimePicker(dtp_ship_req_date_to)
    End Sub
    Private Sub dtp_ship_date_from_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_ship_date_from.ValueChanged
        Call ABCDCommon.ChangeDateTimePicker(dtp_ship_date_from)
    End Sub
    Private Sub dtp_ship_date_to_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_ship_date_to.ValueChanged
        Call ABCDCommon.ChangeDateTimePicker(dtp_ship_date_to)
    End Sub
    Private Sub dtp_invoice_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_invoice_date.ValueChanged
        Call ABCDCommon.ChangeDateTimePicker(dtp_invoice_date)
    End Sub
#End Region
#Region "Common Method Form."
    ''' <summary>
    ''' Load shipment status
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadShipmentStatus()

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("", "")
        comboSource.Add("0", "Incomplete")
        comboSource.Add("1", "Complete")

        cb_ship_status.DataSource = New BindingSource(comboSource, Nothing)
        cb_ship_status.DisplayMember = "Value"
        cb_ship_status.ValueMember = "Key"

        cb_ship_status.SelectedItem = cb_ship_status.Items(0)
    End Sub
    ''' <summary>
    ''' Set control display status on screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayOption(ByVal status As Integer)
        'Input condition status
        If status = 1 Then
            cb_ship_status.Enabled = True
            txt_ship_req_no.Enabled = True
            ABCDCommon.InitDateTimePicker(dtp_ship_req_date_from)
            dtp_ship_req_date_from.Enabled = True
            dtp_ship_req_date_from.Checked = False
            ABCDCommon.InitDateTimePicker(dtp_ship_req_date_to)
            dtp_ship_req_date_to.Enabled = True
            dtp_ship_req_date_to.Checked = False
            ABCDCommon.InitDateTimePicker(dtp_ship_date_from)
            dtp_ship_date_from.Enabled = True
            dtp_ship_date_from.Checked = False
            ABCDCommon.InitDateTimePicker(dtp_ship_date_to)
            dtp_ship_date_to.Enabled = True
            dtp_ship_date_to.Checked = False
            txt_cus_id.Enabled = True
            btn_popup_cus.Enabled = True
            txt_cus_name.Enabled = False
            txt_cus_po.Enabled = True
            txt_invoice_no.Enabled = True
            ABCDCommon.InitDateTimePicker(dtp_invoice_date)
            dtp_invoice_date.Enabled = True
            dtp_invoice_date.Checked = False
            btn_search.Enabled = True
            grd_shipment_inquiry.Rows.Clear()
            'btn_cancel.Enabled = True
            btn_cancel.Text = "Clear"
            btn_export.Enabled = False
        End If
        'View result status
        If status = 2 Then
            cb_ship_status.Enabled = False
            txt_ship_req_no.Enabled = False
            dtp_ship_req_date_from.Enabled = False
            dtp_ship_req_date_to.Enabled = False
            dtp_ship_date_from.Enabled = False
            dtp_ship_date_to.Enabled = False
            txt_cus_id.Enabled = False
            btn_popup_cus.Enabled = False
            txt_cus_po.Enabled = False
            txt_invoice_no.Enabled = False
            dtp_invoice_date.Enabled = False
            btn_search.Enabled = False
            'btn_cancel.Enabled = True
            btn_cancel.Text = "Cancel"
            btn_export.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' Clear all fields on screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearScreen()
        cb_ship_status.SelectedIndex = 0
        txt_ship_req_no.Text = ""
        ABCDCommon.InitDateTimePicker(dtp_ship_req_date_from)
        dtp_ship_req_date_from.Checked = False
        ABCDCommon.InitDateTimePicker(dtp_ship_req_date_to)
        dtp_ship_req_date_to.Checked = False
        ABCDCommon.InitDateTimePicker(dtp_ship_date_from)
        dtp_ship_date_from.Checked = False
        ABCDCommon.InitDateTimePicker(dtp_ship_date_to)
        dtp_ship_date_to.Checked = False
        txt_cus_id.Text = ""
        txt_cus_name.Text = ""
        txt_cus_po.Text = ""
        txt_invoice_no.Text = ""
        ABCDCommon.InitDateTimePicker(dtp_invoice_date)
        dtp_invoice_date.Checked = False
    End Sub
#End Region
End Class