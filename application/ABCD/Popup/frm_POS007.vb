''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_POS007.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   03-FEB-15    1.00     Toannn   New
''*********************************************************

Public Class frm_POS007

#Region "Var/Const Form."

    Private Shadows parentForm As Form

    Private colNames As New List(Of String)(New String() {"", _
                                                          "Request No", _
                                                          "Shipment Date", _
                                                          "Request Date", _
                                                          "Invoice No", _
                                                          "Invoice Date", _
                                                          "Customer PO", _
                                                          "Complete Flag"})

    Private colSizes As New List(Of Integer)(New Integer() {70, _
                                                            130, _
                                                            120, _
                                                            120, _
                                                            165, _
                                                            120, _
                                                            150, _
                                                            80})

    Private wbService As New ABCDService.Service

#End Region

#Region "New Form."

    Public Sub New(ByVal frm As Form)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.parentForm = frm
        'lbl_today.Text = ABCDCommon.GetSystemDateWithFormat
        ' Init gridview
        Dim colButton As New DataGridViewButtonColumn
        colButton.Text = "Select"
        colButton.UseColumnTextForButtonValue = True
        grd_pd_info.Columns.Add(colButton)

        ABCDCommon.CreateColumnsInGridView(grd_pd_info, _
                                           colNames, _
                                           colSizes)
        grd_pd_info.AutoGenerateColumns = False
        grd_pd_info.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grd_pd_info.Columns(2).DefaultCellStyle.Format = ABCDConst.Format_Date_01
        grd_pd_info.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grd_pd_info.Columns(3).DefaultCellStyle.Format = ABCDConst.Format_Date_01
        grd_pd_info.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grd_pd_info.Columns(5).DefaultCellStyle.Format = ABCDConst.Format_Date_01
        grd_pd_info.Columns(1).DataPropertyName = "SHIP_REQ_NO"
        grd_pd_info.Columns(2).DataPropertyName = "SHIP_DT"
        grd_pd_info.Columns(3).DataPropertyName = "SHIP_REQ_DT"
        grd_pd_info.Columns(4).DataPropertyName = "INVOICE_NO"
        grd_pd_info.Columns(5).DataPropertyName = "INVOICE_DT"
        grd_pd_info.Columns(6).DataPropertyName = "CUS_PO"
        grd_pd_info.Columns(7).DataPropertyName = "COMP_FLG"

        ' Init datetimePicker control
        dtp_shipment_date_from.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_shipment_date_from)

        dtp_shipment_date_to.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_shipment_date_to)

        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
    End Sub

#End Region

#Region "Event Form."

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        Call ClearScreen()
    End Sub

    Private Sub btn_popup_cus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_cus.Click
        Dim scrPos005 As New frm_POS005(Me)
        scrPos005.ShowDialog()
        txt_cus_id.Focus()
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click

        Dim cusId As String = txt_cus_id.Text
        If String.IsNullOrEmpty(cusId) Then
            Dim msgScreen As New frm_MSG001("Please input customer id!", "ERR")
            If msgScreen.ShowDialog() = DialogResult.OK Then
                txt_cus_id.Focus()
            End If
            Exit Sub
        ElseIf String.IsNullOrEmpty(txt_cus_name.Text) Then
            Dim msgScreen As New frm_MSG001("This customer id does not exist!", "ERR")
            If msgScreen.ShowDialog() = DialogResult.OK Then
                txt_cus_id.Focus()
            End If
            Exit Sub
        End If

        'If dtp_shipment_date_from.CustomFormat = " " And dtp_shipment_date_to.CustomFormat = " " Then
        '    Dim msgScreen As New frm_MSG001("Please select one condition of shipdate.", "ERR")
        '    If msgScreen.ShowDialog() = DialogResult.OK Then
        '        dtp_shipment_date_from.Focus()
        '    End If
        '    Exit Sub
        'End If

        'If Not dtp_shipment_date_from.CustomFormat = " " AndAlso _
        '            Not dtp_shipment_date_to.CustomFormat = " " AndAlso _
        '            dtp_shipment_date_from.Value.Date.CompareTo(dtp_shipment_date_to.Value.Date) > 0 Then
        '    Dim msgScreen As New frm_MSG001("From-date can not be great than To-date!", "ERR")
        '    If msgScreen.ShowDialog() = DialogResult.OK Then
        '        dtp_shipment_date_from.Focus()
        '    End If
        '    Exit Sub
        'End If

        Dim shipDateFrom As Date = Date.MinValue
        If Not dtp_shipment_date_from.CustomFormat = " " Then
            shipDateFrom = dtp_shipment_date_from.Value.Date
        End If

        Dim shipDateTo As Date = Date.MinValue
        If Not dtp_shipment_date_to.CustomFormat = " " Then
            shipDateTo = dtp_shipment_date_to.Value.Date
        End If

        Dim loginCode As String = ABCDCommon.UserId

        Call ResultSearch(grd_pd_info, _
                          cusId, _
                          shipDateFrom, _
                          shipDateTo, _
                          loginCode)
    End Sub

    Private Sub grd_pd_info_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_pd_info.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = 0 Then
            If TypeOf parentForm Is frm_SHS001 Then
                CType(parentForm, frm_SHS001).txt_shipment_req_no.Text = _
                                    grd_pd_info.Rows(e.RowIndex).Cells(1).Value.ToString
            End If
            Me.Close()
        End If
    End Sub

    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_shipment_date_from.ValueChanged, dtp_shipment_date_to.ValueChanged
        ABCDCommon.ChangeDateTimePicker(sender)
    End Sub

    Private Sub txt_cus_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cus_id.Leave
        txt_cus_id.Text = Trim(txt_cus_id.Text)
        If Not String.IsNullOrEmpty(txt_cus_id.Text) Then
            Dim resultItem = wbService.GetCustomerInfoByID(txt_cus_id.Text, ABCDCommon.UserId)
            If IsNothing(resultItem) OrElse resultItem.Tables(0).Rows.Count = 0 Then
                txt_cus_name.Text = String.Empty
            Else
                Dim itemName As String = Trim(resultItem.Tables(0).Rows(0)("CUS_NM").ToString)
                txt_cus_name.Text = itemName
            End If
        Else
            txt_cus_name.Text = String.Empty
        End If
    End Sub

#End Region

#Region "Fucntion Form."

    Private Sub ClearScreen()
        ' Clear all textbox.
        txt_cus_id.Clear()
        txt_cus_name.Clear()
        dtp_shipment_date_from.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_shipment_date_from)
        dtp_shipment_date_to.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_shipment_date_to)
        ' Clear gridview.
        grd_pd_info.DataSource = Nothing
    End Sub

    Private Sub ResultSearch(ByVal dgv As DataGridView, _
                             ByVal cusId As String, _
                             ByVal shipDateFromCondition As Date, _
                             ByVal shipDateToCondition As Date, _
                             ByVal loginCode As String)
        Dim ds As DataSet = wbService.GetShipmentInfo(cusId, _
                                                      shipDateFromCondition, _
                                                      shipDateToCondition, _
                                                      loginCode)
        If ds.Tables(0).Rows.Count <= 0 Then
            Dim frm As frm_MSG001
            frm = New frm_MSG001(ABCD.My.Resources.Messages.ERR010, "ERR010")
            frm.ShowDialog()
            Exit Sub
        End If
        dgv.DataSource = ds.Tables(0)
        dgv.Update()
    End Sub
#End Region
End Class