''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_STS002.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-19    1.00    Hungtg   New
''*********************************************************
Imports System.Configuration.ConfigurationManager
Imports ABCD.ABCDCommon

Public Class frm_STS002

#Region "Var/Const Form."
    Private ws As New ABCDService.Service
    Private ds As DataSet = Nothing
    Dim stocktakingDetail As New DataTable
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

        'Get current date
        lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat()

        InitForm()

        stocktakingDetail.Columns.Add(New DataColumn("NO", GetType(Integer)))
        stocktakingDetail.Columns.Add(New DataColumn("SYS WH CD", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("SYS RACK CD", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("BARCODE NO", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("ITEM CD", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("ITEM NAME", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("BOX NUMBER", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("QUANTITY", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("UNIT", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("CHECK FLAG", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("PIC", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("REG USER", GetType(String)))
        stocktakingDetail.Columns.Add(New DataColumn("REG DATE", GetType(String)))

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
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        Dim frm As frm_MSG001
        Me.ds = Nothing
        Try
            Me.ds = ws.GetStockReqDtlInfoTr(ABCDCommon.UserId)
            If Me.ds.Tables(0).Rows.Count = 0 Then
                frm = New frm_MSG001(ABCD.My.Resources.Messages.ERR013, "ERR013")
                frm.ShowDialog()
                Exit Sub
            End If

            '// Cuongtk - 20150819: Get template to export data
            Dim pathStocktakingList As String = AppSettings("StocktakingList")

            sfdDialog.Filter = "Excel File (*.xlsx*) | *.xlsx"
            sfdDialog.FileName = "STS002_" & Date.Now.ToString("yyyyMMddHHmmss")
            If sfdDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                btn_print.Enabled = False
                btn_exit.Enabled = False
                'ExportDataToFile(Me.ds.Tables(0), sfdDialog.FileName, pathStocktakingList)
                '// Cuongtk - 20150819: Improved export data with template
                ExportStocktakingList(Me.ds.Tables(0), pathStocktakingList, sfdDialog.FileName)
                btn_print.Enabled = True
                btn_exit.Enabled = True
            End If
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Common Method Form."
    ''' <summary>
    ''' Load current stock request info
    ''' Cuongtk - 20150819: Modified call web service many
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitForm()

        Dim dataSet As DataSet = ws.GetStockReqInfoTr(UserId)
        Dim rowData As Integer = dataSet.Tables(0).Rows.Count

        '// Not get row data
        If rowData = 0 Then
            Dim errorForm As New frm_MSG001("Data is Empty!", "ERR9004")
            If errorForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                errorForm.Close()
                lbl_stock_date_value.Text = String.Empty
                lbl_item_code.Text = String.Empty
                lbl_item_name.Text = String.Empty
                lbl_wh_code.Text = String.Empty
                lbl_wh_name.Text = String.Empty
                btn_print.Enabled = False
                Exit Sub
            End If
        End If

        '// Get row data
        lbl_stock_date_value.Text = Date.Parse(dataSet.Tables(0).Rows(0)("STOCK_DT").ToString).ToString("dd/MM/yyyy")

        '// Warehouse code null
        If "".Equals(Trim(dataSet.Tables(0).Rows(0)("WH_CD").ToString)) Then
            lbl_devide1.Text = String.Empty
        End If
        lbl_wh_code.Text = Trim(dataSet.Tables(0).Rows(0)("WH_CD").ToString)
        lbl_wh_name.Text = Trim(dataSet.Tables(0).Rows(0)("WH_NM").ToString)

        '// Item code null
        If "".Equals(Trim(dataSet.Tables(0).Rows(0)("ITEM_CD").ToString)) Then
            lbl_devide2.Text = String.Empty
        End If
        lbl_item_code.Text = Trim(dataSet.Tables(0).Rows(0)("ITEM_CD").ToString)
        lbl_item_name.Text = Trim(dataSet.Tables(0).Rows(0)("ITEM_NM").ToString)

        'ds = ws.GetStockReqInfoTr(ABCDCommon.UserId)
        'If ds.Tables(0).Rows.Count = 0 Then
        '    Dim strError As String = "Data is empty!"
        '    Dim frm_msg As New frm_MSG001(strError, "ERR999")
        '    If frm_msg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        frm_msg.Close()
        '        lbl_stock_date_value.Text = ""
        '        lbl_wh_code.Text = ""
        '        lbl_wh_name.Text = ""
        '        lbl_item_code.Text = ""
        '        lbl_item_name.Text = ""
        '        btn_print.Enabled = False
        '        Return
        '    End If
        'End If
        'lbl_stock_date_value.Text = Date.Parse(ds.Tables(0).Rows(0)("STOCK_DT")).ToString("dd/MM/yyyy")
        'If Trim(ds.Tables(0).Rows(0)("REQ_WH_CD").ToString).Equals("") Then
        '    lbl_wh_code.Text = ""
        '    lbl_wh_name.Text = ""
        '    lbl_devide1.Text = "" 'Kaidai 197: Delete "|"
        'Else
        '    lbl_wh_code.Text = Trim(ds.Tables(0).Rows(0)("REQ_WH_CD").ToString)
        '    lbl_wh_name.Text = ws.GetWarehouseInfoByCd(Trim(ds.Tables(0).Rows(0)("REQ_WH_CD").ToString), _
        '                                               ABCDCommon.UserId).Tables(0).Rows(0)("WH_NM")
        'End If

        'If Trim(ds.Tables(0).Rows(0)("REQ_ITEM_CD").ToString).Equals("") Then
        '    lbl_item_code.Text = ""
        '    lbl_item_name.Text = ""
        '    lbl_devide2.Text = "" 'Kaidai 197: Delete "|"
        'Else
        '    lbl_item_code.Text = Trim(ds.Tables(0).Rows(0)("REQ_ITEM_CD").ToString)
        '    lbl_item_name.Text = ws.GetItemInfoByCd(Trim(ds.Tables(0).Rows(0)("REQ_ITEM_CD").ToString), _
        '                                            ABCDCommon.UserId).Tables(0).Rows(0)("ITEM_NM")
        'End If

    End Sub

    ''' <summary>
    ''' Export data from datatable to file.
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Private Sub ExportDataToFile(ByVal dataTable As DataTable, ByVal fileName As String, ByVal template As String)
        ' '' Set format(* Important).
        'Dim cultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        'Dim frm As frm_MSG001
        'Dim row As Integer = 2
        'Dim col As Integer = 1
        'Dim valueMissing As Object = System.Reflection.Missing.Value
        'Dim excelApplication As New Microsoft.Office.Interop.Excel.Application
        'Dim excelWorkBook As Microsoft.Office.Interop.Excel.Workbook = excelApplication.Workbooks.Add(valueMissing)
        'Dim excelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = excelWorkBook.Sheets(1)
        ' '' Set value display Header.
        'excelWorkSheet.Range("A1").Value = "Stocktaking Date"
        'excelWorkSheet.Range("B1").Value = "System Warehouse"
        'excelWorkSheet.Range("C1").Value = "System Rack"
        'excelWorkSheet.Range("D1").Value = "Barcode No"
        'excelWorkSheet.Range("E1").Value = "Item Code"
        'excelWorkSheet.Range("F1").Value = "Item Name"
        'excelWorkSheet.Range("G1").Value = "Box Number"
        'excelWorkSheet.Range("H1").Value = "Quantity"
        'excelWorkSheet.Range("I1").Value = "Unit"
        'excelWorkSheet.Range("J1").Value = "Check Flag"
        'excelWorkSheet.Range("K1").Value = "Person In Charge"
        'excelWorkSheet.Range("L1").Value = "Registered Id"
        'excelWorkSheet.Range("M1").Value = "Registered Date"
        'excelWorkSheet.Range("N1").Value = "Updated Id"
        'excelWorkSheet.Range("O1").Value = "Updated Date"
        ' '' Set value cells under header.
        'For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
        '    For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
        '        Dim data As String = String.Empty
        '        data = Trim(dataTable.Rows(i)(k).ToString)
        '        If k = 0 Then
        '            data = Date.Parse(data).ToString("dd/MM/yyyy")
        '        End If
        '        If k = 3 Then
        '            data = "'" & data
        '        End If
        '        If k = 6 Then
        '            data = "'" & data
        '        End If
        '        If k = 8 Then
        '            data = ABCDCommon.ConvertUnit(data)
        '        End If
        '        If k = 9 Then
        '            data = ""
        '        End If
        '        If k = 10 Then
        '            data = ""
        '        End If
        '        excelWorkSheet.Cells(row, col) = data
        '        col = col + 1
        '    Next
        '    excelWorkSheet.Range("A" & row.ToString & ":O" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        '    row = row + 1
        '    col = 1
        'Next
        'excelWorkSheet.Range("A:O").Font.Name = "Times New Roman"
        'excelWorkSheet.Range("A:O").Font.Size = 10
        'excelWorkSheet.Range("A1:O1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        'excelWorkSheet.Range("A1:O1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        'excelWorkSheet.Range("A1:O1").Interior.ColorIndex = 35
        'excelWorkSheet.Range("A:O").Columns.EntireColumn.AutoFit()
        ' '' Save file Excel.
        'Try
        '    excelWorkSheet.SaveAs(fileName)
        'Catch ex As Exception
        '    frm = New frm_MSG001(ex.Message, "ERR9004")
        '    frm.ShowDialog()
        '    btn_print.Enabled = True
        '    Exit Sub
        'Finally
        '    excelWorkBook.Close()
        '    excelApplication.Quit()
        '    ABCDCommon.ReleaseObject(excelApplication)
        '    ABCDCommon.ReleaseObject(excelWorkBook)
        '    ABCDCommon.ReleaseObject(excelWorkSheet)
        '    frm = New frm_MSG001(ABCD.My.Resources.Messages.MSG002, "MSG002")
        '    If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
        '        System.Diagnostics.Process.Start(fileName)
        '    End If
        '    System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo
        'End Try
    End Sub

#End Region

End Class