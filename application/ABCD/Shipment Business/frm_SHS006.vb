''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_SHS002.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-16    1.00    Hungtg   New
''*********************************************************
Public Class frm_SHS006

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

    Private ColNames As New List(Of String)(New String() { _
                                                                  "Shipment Req No", _
                                                                  "Customer Name", _
                                                                  "Shipment Req Date", _
                                                                  "Shipment Date", _
                                                                  "Invoice No", _
                                                                  "Invoice Date", _
                                                                  "Customer PO", _
                                                                  "Register User", _
                                                                  "Register Date"})

    Private ColSizes As New List(Of Integer)(New Integer() { _
                                                                    150, _
                                                                    150, _
                                                                    150, _
                                                                    100, _
                                                                    165, _
                                                                    120, _
                                                                    120, _
                                                                    100, _
                                                                    100})

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

        lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat

        'Call DisplayOption to set control display
        _dispOpt = 1
        DisplayOption(_dispOpt)

        ' Set display datagridview.      
        ABCDCommon.CreateColumnsInGridView(grd_shipment_inquiry, _
                                            ColNames, _
                                            ColSizes)
        grd_shipment_inquiry.Columns("Register User").Visible = False
        grd_shipment_inquiry.Columns("Register Date").Visible = False
        grd_shipment_inquiry.Columns("Shipment Req Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grd_shipment_inquiry.Columns("Shipment Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grd_shipment_inquiry.Columns("Invoice Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'grd_shipment_inquiry.Columns("Customer Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        grd_shipment_inquiry.SelectionMode = DataGridViewSelectionMode.FullRowSelect

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
            Dim strError As String = "Please setup at least one condition!"
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
        Try
            Me.Cursor = Cursors.WaitCursor
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
            ''Check if search result is empty
            If ds.Tables(0).Rows.Count = 0 Then
                Dim strError As String = "Data is empty!"
                Dim frm_msg As New frm_MSG001(strError, "ERR099")
                If frm_msg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    frm_msg.Close()
                    Return
                End If
            End If
            ' Get data for gridview.
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                Dim arr(9) As String
                arr(0) = ds.Tables(0).Rows(i)("SHIP_REQ_NO").ToString
                arr(1) = ds.Tables(0).Rows(i)("CUS_NM").ToString
                arr(2) = Date.Parse(ds.Tables(0).Rows(i)("SHIP_REQ_DT")).ToString("dd/MM/yyyy")
                arr(3) = Date.Parse(ds.Tables(0).Rows(i)("SHIP_DT")).ToString("dd/MM/yyyy")
                arr(4) = ds.Tables(0).Rows(i)("INVOICE_NO").ToString
                arr(5) = Date.Parse(ds.Tables(0).Rows(i)("INVOICE_DT")).ToString("dd/MM/yyyy")
                arr(6) = ds.Tables(0).Rows(i)("CUS_PO")
                arr(7) = ds.Tables(0).Rows(i)("REG_USER_CD").ToString
                arr(8) = Date.Parse(ds.Tables(0).Rows(i)("REG_DT")).ToString("dd/MM/yyyy")

                grd_shipment_inquiry.Rows.Add(arr)
            Next
            If ABCDCommon.CheckGridViewIsNothing(grd_shipment_inquiry) = False Then
                Return
            Else
                _dispOpt = 2
                DisplayOption(_dispOpt)
            End If
        Catch ex As Exception
            ds.Dispose()
            Dim frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
            ds.Dispose()
        End Try
    End Sub

    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        sfdDialog.Filter = "Excel File (*.xlsx*) | *.xlsx"
        sfdDialog.FileName = "SHS006_" & Date.Now.ToString("yyyyMMddHHmmss")
        If sfdDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            btn_export.Enabled = False
            btn_cancel.Enabled = False
            btn_exit.Enabled = False
            ExportDataToExcel(Me.ds.Tables(0), sfdDialog.FileName)
            btn_cancel.Enabled = True
            btn_exit.Enabled = True
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

    Private Sub ExportDataToExcel(ByVal dataTable As DataTable, ByVal fileName As String)
        '' Set format(* Important).
        Dim cultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim frm As frm_MSG001
        Dim row As Integer = 2
        Dim col As Integer = 1
        Dim valueMissing As Object = System.Reflection.Missing.Value
        Dim excelApplication As New Microsoft.Office.Interop.Excel.Application
        Dim excelWorkBook As Microsoft.Office.Interop.Excel.Workbook = excelApplication.Workbooks.Add(valueMissing)
        Dim excelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = excelWorkBook.Sheets(1)
        '' Set value display Header.
        excelWorkSheet.Range("A1").Value = "Shipment Request No"
        excelWorkSheet.Range("B1").Value = "Customer Name"
        excelWorkSheet.Range("C1").Value = "Shipment Request Date"
        excelWorkSheet.Range("D1").Value = "Shipment Date"
        excelWorkSheet.Range("E1").Value = "Invoice No"
        excelWorkSheet.Range("F1").Value = "Invoice Date"
        excelWorkSheet.Range("G1").Value = "Customer PO"
        excelWorkSheet.Range("H1").Value = "Registered Id"
        excelWorkSheet.Range("I1").Value = "Registered Date"
        excelWorkSheet.Range("J1").Value = "Updated Id"
        excelWorkSheet.Range("K1").Value = "Updated Date"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                If k = 0 Then
                    data = "'" & data
                End If
                excelWorkSheet.Cells(row, col) = data
                col = col + 1
            Next
            excelWorkSheet.Range("A" & row.ToString & ":K" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:K").Font.Name = "Times New Roman"
        excelWorkSheet.Range("A:K").Font.Size = 10
        excelWorkSheet.Range("A1:K1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:K1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:K1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:K").Columns.EntireColumn.AutoFit()
        '' Save file Excel.
        Try
            excelWorkSheet.SaveAs(fileName)
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            btn_export.Enabled = True
            Exit Sub
        Finally
            excelWorkBook.Close()
            excelApplication.Quit()
            ABCDCommon.ReleaseObject(excelApplication)
            ABCDCommon.ReleaseObject(excelWorkBook)
            ABCDCommon.ReleaseObject(excelWorkSheet)
            frm = New frm_MSG001(ABCD.My.Resources.Messages.MSG002, "MSG002")
            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(fileName)
            End If
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo
        End Try
    End Sub

#End Region

    Private Sub cb_ship_status_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_ship_status.SelectedValueChanged
        txt_ship_req_no.Focus()
    End Sub

    Private Sub grd_shipment_inquiry_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_shipment_inquiry.CellDoubleClick
        Dim rowIndex As Integer = 0
        Dim shipmentRequestEntry As frm_SHS001
        Dim shipmentRequestNo As String = String.Empty
        rowIndex = e.RowIndex
        ''
        If rowIndex < 0 Then
            Exit Sub
        End If
        ''
        shipmentRequestNo = Trim(grd_shipment_inquiry.Rows(rowIndex).Cells(0).Value)
        shipmentRequestEntry = New frm_SHS001(shipmentRequestNo)
        shipmentRequestEntry.ShowDialog()

    End Sub

End Class