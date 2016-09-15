''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_WHS002.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-15    1.00    Hungtg   New
''* 02   11-AUG-15    1.01    Cuongtk  Modify
''*********************************************************
Public Class frm_WHS002

#Region "Var/Const Form."

    Private ws As New ABCDService.Service '// New web service

    Private ds As DataSet = Nothing '// Dataset to get data from webservice

    ''' <summary>
    ''' Variable: Use to setting display of control on screen
    ''' </summary>
    ''' <remarks></remarks>
    Private m_dispOpt As Integer
    Public Property DispOpt() As Integer
        Get
            Return m_dispOpt
        End Get
        Set(ByVal value As Integer)
            m_dispOpt = value
        End Set
    End Property

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

        'Load warehouse list into combobox
        LoadWarehouseList()

        lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat
        'AIT Hungtg start 04/08/2015
        dtp_import_date_from.CustomFormat = "dd/MM/yyyy"
        dtp_import_date_to.CustomFormat = "dd/MM/yyyy"
        dtp_import_date_from.Value = DateSerial(Today.Year, Today.Month, 1)
        dtp_import_date_to.Value = DateSerial(Today.Year, Today.Month + 1, 0)
        'AIT Hungtg end 04/08/2015
        'Call DisplayOption to set control display
        m_dispOpt = 1
        DisplayOption(m_dispOpt)

        ' Set display datagridview.
        'AIT Hungtg start 04/08/2015
        grd_wh_inquiry.ColumnCount = 12
        grd_wh_inquiry.Columns(0).Name = "Barcode No"
        grd_wh_inquiry.Columns(0).Width = 120
        grd_wh_inquiry.Columns(1).Name = "Lot No"
        grd_wh_inquiry.Columns(1).Width = 115
        grd_wh_inquiry.Columns(2).Name = "Warehouse Code"
        grd_wh_inquiry.Columns(2).Width = 85
        grd_wh_inquiry.Columns(3).Name = "Warehouse Name"
        grd_wh_inquiry.Columns(3).Width = 100
        grd_wh_inquiry.Columns(4).Name = "Rack Code"
        grd_wh_inquiry.Columns(4).Width = 85
        grd_wh_inquiry.Columns(5).Name = "Rack Name"
        grd_wh_inquiry.Columns(5).Width = 80
        grd_wh_inquiry.Columns(6).Name = "Item Code"
        grd_wh_inquiry.Columns(6).Width = 210
        grd_wh_inquiry.Columns(7).Name = "Item Name"
        grd_wh_inquiry.Columns(7).Width = 420
        grd_wh_inquiry.Columns(8).Name = "Box Number"
        grd_wh_inquiry.Columns(8).Width = 60
        grd_wh_inquiry.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grd_wh_inquiry.Columns(9).Name = "Qty"
        grd_wh_inquiry.Columns(9).Width = 60
        grd_wh_inquiry.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grd_wh_inquiry.Columns(10).Name = "Register User"
        grd_wh_inquiry.Columns(10).Width = 80
        grd_wh_inquiry.Columns(10).Visible = False
        grd_wh_inquiry.Columns(11).Name = "Register Date"
        grd_wh_inquiry.Columns(11).Width = 80
        grd_wh_inquiry.Columns(11).Visible = False
        'AIT Hungtg end 04/08/2015
        grd_wh_inquiry.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Method: Event click button Exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Method: Event click button Clear.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        If m_dispOpt = 1 Then
            cb_wh_list.SelectedValue = 0
            cb_wh_list.Focus() '// Cuongtk - 20150820: Modify display clear option = 0
            txt_rack_code.Text = ""
            txt_rack_name.Text = ""
            txt_item_code.Text = ""
            txt_item_name.Text = ""
            txt_barcode.Text = ""
            'AIT Hungtg start 04/08/2015
            dtp_import_date_from.Value = DateSerial(Today.Year, Today.Month, 1)
            dtp_import_date_to.Value = DateSerial(Today.Year, Today.Month + 1, 0)
            'AIT Hungtg end 04/08/2015
            Return
        End If
        m_dispOpt = m_dispOpt - 1
        DisplayOption(m_dispOpt)
        '// Cuongtk - 20150820: Modify display clear option = 1 (Start)
        If m_dispOpt = 1 Then
            If cb_wh_list.SelectedIndex = 2 Then
                txt_rack_code.Enabled = True
                txt_rack_name.Enabled = False
                btn_popup_rack.Enabled = True
                Exit Sub
            End If
            txt_rack_code.Enabled = False
            txt_rack_name.Enabled = False
        End If
        '// Cuongtk - 20150820: Modify display clear option = 1 (End)
    End Sub

    ''' <summary>
    ''' Method: Event click button Search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim cb_selected_value As String = String.Empty 'Error not new object
        If cb_wh_list.SelectedValue Is Nothing Then
            cb_selected_value = String.Empty
        Else
            cb_selected_value = Trim(cb_wh_list.SelectedValue.ToString)
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            'AIT Hungtg start 04/08/2015
            'Set date condition       
            'Dim importDateFrom As String = If(dtp_import_date_from.Checked, _
            '                                                                       dtp_import_date_from.Value.Date.ToString("yyyyMMdd"), _
            '                                                                       "")
            'Dim importDateTo As String = If(dtp_import_date_to.Checked, _
            '                                                                   dtp_import_date_to.Value.Date.ToString("yyyyMMdd"), _
            '                                                                   "")
            Dim conditionStartDate As Date = dtp_import_date_from.Value '// Condition start date
            Dim conditionEndDate As Date = dtp_import_date_to.Value '// Condition end date

            ds = ws.WarehouseTrInquiry(cb_selected_value, _
                                        txt_rack_code.Text, _
                                        txt_item_code.Text, _
                                        txt_barcode.Text, _
                                        conditionStartDate, _
                                        conditionEndDate, _
                                        ABCDCommon.UserId)
            'AIT Hungtg end 04/08/2015
            grd_wh_inquiry.Rows.Clear()
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
                'AIT Hungtg start 04/08/2015
                Dim arr(12) As String
                arr(0) = ds.Tables(0).Rows(i)("BC_NO").ToString
                arr(1) = ds.Tables(0).Rows(i)("LOT_NO").ToString.Trim
                arr(2) = ds.Tables(0).Rows(i)("WH_CD").ToString
                arr(3) = ds.Tables(0).Rows(i)("WH_NM").ToString
                arr(4) = ds.Tables(0).Rows(i)("RACK_CD").ToString
                arr(5) = ds.Tables(0).Rows(i)("RACK_NM").ToString
                arr(6) = ds.Tables(0).Rows(i)("ITEM_CD").ToString
                arr(7) = ds.Tables(0).Rows(i)("ITEM_NM").ToString
                arr(8) = String.Format("{0:#,##0}", ds.Tables(0).Rows(i)("BOX_NUM"))
                arr(9) = String.Format("{0:#,##0}", ds.Tables(0).Rows(i)("QTY"))
                arr(10) = ds.Tables(0).Rows(i)("REG_USER_CD").ToString
                arr(11) = Date.Parse(ds.Tables(0).Rows(i)("REG_DT")).ToString("dd/MM/yyyy")
                'AIT Hungtg end 04/08/2015
                grd_wh_inquiry.Rows.Add(arr)
            Next
            If grd_wh_inquiry.RowCount = 0 Then
                Return
            Else
                m_dispOpt = 2
                DisplayOption(m_dispOpt)
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

    ''' <summary>
    ''' Method: Export file data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        ' '' Check datagrid view is empty.
        'If grd_wh_inquiry.Rows.Count = 0 Then
        '    Dim strError As String = "Data is empty, please excute inquiry first!"
        '    Dim frm_msg As New frm_MSG001(strError, "ERR028")
        '    If frm_msg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        frm_msg.Close()
        '        Return
        '    End If
        'End If
        'btn_export.Enabled = False
        'btn_clear.Enabled = False
        ' '' Execute main: export CSV.
        sfdDialog.Filter = "Excel File (*.xlsx*) | *.xlsx"
        sfdDialog.FileName = "WHS002_" & Date.Now.ToString("yyyyMMddHHmmss")
        If sfdDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            btn_export.Enabled = False
            btn_clear.Enabled = False
            btn_exit.Enabled = False
            Dim filePath As String = sfdDialog.FileName
            ExportDataToExcel(Me.ds.Tables(0), sfdDialog.FileName) 'Kaidai 187: Format export file .xlsx
            btn_clear.Enabled = True
            btn_exit.Enabled = True
        End If
        'If sfdDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Try
        '        Me.Cursor = Cursors.WaitCursor
        '        Dim fn As String = sfdDialog.FileName
        '        ABCDCommon.ExportGridviewToExcel(grd_wh_inquiry, fn, "")
        '    Catch ex As Exception
        '    Finally
        '        Me.Cursor = Cursors.Default
        '    End Try
        'End If
        'btn_clear.Enabled = True
    End Sub

    ''' <summary>
    ''' Method: Change value when selected warehouse condition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cb_wh_list_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_wh_list.SelectedValueChanged
        If m_dispOpt = Nothing Then
            Return
        End If
        Dim cb_selected_value As String
        If cb_wh_list.SelectedValue Is Nothing Then
            cb_selected_value = ""
        Else
            cb_selected_value = Trim(cb_wh_list.SelectedValue.ToString)
        End If
        If cb_selected_value.Equals("W830") Then
            txt_rack_code.Text = ""
            txt_rack_name.Text = ""
            txt_rack_code.Enabled = True
            btn_popup_rack.Enabled = True
            txt_rack_code.Focus()
        Else
            txt_rack_code.Text = ""
            txt_rack_name.Text = ""
            txt_rack_code.Enabled = False
            btn_popup_rack.Enabled = False
            txt_item_code.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Method: Click pop-up to selected rack condition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_popup_rack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_rack.Click
        Dim popupRack As New frm_POS002(Me)
        popupRack.ShowDialog()
        txt_rack_code.Focus()
        txt_rack_code.SelectAll()
    End Sub

    ''' <summary>
    ''' Method: Press tab to leave rack code in condition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_rack_code_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_rack_code.Leave
        ' Focus popup.
        If btn_popup_rack.Focused Then
            Return
        End If
        ' Focus cancel.
        If btn_clear.Focused Then
            Return
        End If
        ' Focus exit.
        If btn_exit.Focused Then
            Return
        End If
        If Not txt_rack_code.Text.Equals("") Then
            Dim ds As DataSet = ws.GetRackInfoByCd(txt_rack_code.Text, 1)
            If ds.Tables(0).Rows.Count <> 0 Then
                txt_rack_name.Text = Trim(ds.Tables(0).Rows(0)("RACK_NM").ToString)
            Else
                txt_rack_name.Text = ""
                Return
            End If
        Else
            txt_rack_name.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Method: Press tab to leave item code in condition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_item_code_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_item_code.Leave
        ' Focus popup.
        If btn_popup_item.Focused Then
            Return
        End If
        ' Focus cancel.
        If btn_clear.Focused Then
            Return
        End If
        ' Focus exit.
        If btn_exit.Focused Then
            Return
        End If
        If Not txt_item_code.Text.Equals("") Then
            Dim ds As DataSet = ws.GetItemInfoByCd(txt_item_code.Text, 1)
            If ds.Tables(0).Rows.Count <> 0 Then
                txt_item_name.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
            Else
                txt_item_name.Text = ""
                Return
            End If
        Else
            txt_item_name.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Method: Click pop-up selected item condtion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_popup_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_item.Click
        Dim popupItem As New frm_POS001(Me)
        popupItem.ShowDialog()
        txt_item_code.Focus()
        txt_item_code.SelectAll()
    End Sub

#End Region

#Region "Common Method Form."

    ''' <summary>
    ''' Method: Load data for combobox Warehouse.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadWarehouseList()
        Dim dt As DataTable = ws.GetWarehouseList(ABCDCommon.UserId).Tables(0)

        cb_wh_list.DataSource = New BindingSource(dt, Nothing)
        cb_wh_list.DisplayMember = "WH_CD"
        cb_wh_list.ValueMember = "WH_CD"

        dt.Rows.InsertAt(dt.NewRow(), 0)
        cb_wh_list.SelectedValue = 0
    End Sub

    ''' <summary>
    ''' Method: Set control display status on screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayOption(ByVal status As Integer)
        'Input condition status
        If status = 1 Then
            cb_wh_list.Enabled = True
            txt_rack_code.Enabled = True
            btn_popup_rack.Enabled = True
            txt_item_code.Enabled = True
            btn_popup_item.Enabled = True
            txt_barcode.Enabled = True
            btn_search.Enabled = True
            'AIT Hungtg start 04/08/2015
            dtp_import_date_from.Enabled = True
            dtp_import_date_to.Enabled = True
            'AIT Hungtg end 04/08/2015
            grd_wh_inquiry.Rows.Clear()

            btn_clear.Enabled = True
            btn_clear.Text = "Clear"
            btn_export.Enabled = False
            btn_exit.Enabled = True

            txt_rack_code.Enabled = False
            txt_rack_name.Enabled = False
            txt_item_name.Enabled = False
            btn_popup_rack.Enabled = False

        End If
        'View result status
        If status = 2 Then
            cb_wh_list.Enabled = False
            txt_rack_code.Enabled = False
            btn_popup_rack.Enabled = False
            txt_item_code.Enabled = False
            btn_popup_item.Enabled = False
            txt_barcode.Enabled = False
            btn_search.Enabled = False
            'AIT Hungtg start 04/08/2015
            dtp_import_date_from.Enabled = False
            dtp_import_date_to.Enabled = False
            'AIT Hungtg end 04/08/2015

            btn_clear.Enabled = True
            btn_clear.Text = "Cancel"
            btn_export.Enabled = True
            btn_exit.Enabled = True

        End If
    End Sub

    ''' <summary>
    ''' Method: Export warehouse inquiry
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Private Sub ExportDataToExcel(ByVal dataTable As DataTable, _
                                  ByVal fileName As String)
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
        'AIT Hungtg start 05/08/2015
        excelWorkSheet.Range("A1").Value = "Barcode No"
        excelWorkSheet.Range("B1").Value = "Lot No"
        excelWorkSheet.Range("C1").Value = "Warehouse Code"
        excelWorkSheet.Range("D1").Value = "Warehouse Name"
        excelWorkSheet.Range("E1").Value = "Rack Code"
        excelWorkSheet.Range("F1").Value = "Rack Name"
        excelWorkSheet.Range("G1").Value = "Item Code"
        excelWorkSheet.Range("H1").Value = "Item Name"
        excelWorkSheet.Range("I1").Value = "Box Number"
        excelWorkSheet.Range("J1").Value = "Quantity"
        excelWorkSheet.Range("K1").Value = "Registered Id"
        excelWorkSheet.Range("L1").Value = "Registered Date"
        excelWorkSheet.Range("M1").Value = "Updated Id"
        excelWorkSheet.Range("N1").Value = "Updated Date"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                If k = 0 Or k = 8 Then
                    data = "'" & data
                End If
                excelWorkSheet.Cells(row, col) = data
                col = col + 1
            Next
            excelWorkSheet.Range("A" & row.ToString & ":N" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:N").Font.Name = "Arial"
        excelWorkSheet.Range("A:N").Font.Size = 10
        excelWorkSheet.Range("A1:N1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:N1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:N1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:N").Columns.EntireColumn.AutoFit()
        'AIT Hungtg END 05/08/2015
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


End Class