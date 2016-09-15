''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_WHS003.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   13-JAN-15    1.00     Toannn   New
''*********************************************************
Imports ABCD.ABCDConst
Imports ABCD.ABCDCommon
Imports ABCD.ABCDService

Imports System.Configuration.ConfigurationManager

Public Class frm_WHS003

#Region "Var/Const Form."

    'Private wbService As New ABCDService.Service
    Private m_webService As New Service

#End Region

#Region "New Form."

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        m_webService.Url = STRING_URL
        m_webService.Timeout = Integer.Parse(STRING_TIMEOUT)
        CurrentInfo.Text = ABCDCommon.GetSystemDateWithFormat
        ' Init combobox Status
        Call InitComboboxByStyle(StatusCode, MODE_WAREHOUSE_STATUS_TR)
        ' Init combobox Warehouse
        Call LoadWarehouseList()
    End Sub

#End Region

#Region "Event Form."

    ''' <summary>
    ''' Load Stock In/Out History
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_WHS003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartStockDate.Value = New DateTime(Date.Now.Year, Date.Now.Month, 1) '// Get first day in month
        EndStockDate.Value = New DateTime(Date.Now.Year, Date.Now.Month, 1).AddMonths(1).AddDays(-1) '// Get last day in month
    End Sub

    ''' <summary>
    ''' Method: Click pop-up selected item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_item_cd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopupItem.Click
        Dim popupItem As New frm_POS001(Me)
        popupItem.ShowDialog()
        ItemCode.Focus()
    End Sub

    ''' <summary>
    ''' Method: Click to exit screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitScreen.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Method: Clear all value display screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelObject.Click
        Call ClearScreen()
    End Sub

    ''' <summary>
    ''' Method: Click export data file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportFile.Click
        If Not IsValidInput() Then
            Exit Sub
        End If
        Dim resultTb As DataTable = ResultSearch()
        '// *************** Cuongtk 20150811 - Start ***************
        If resultTb Is Nothing Then '// In case exception search data
            StartStockDate.Focus()
            Return
        End If
        '// *************** Cuongtk 20150811 - End ***************
        If resultTb.Rows.Count = 0 Then
            Dim msgScreen As New frm_MSG001("Data not found!", "INF052")
            If msgScreen.ShowDialog() = DialogResult.OK Then
                msgScreen.Close()
            End If
            StartStockDate.Focus()
            ExportFile.Enabled = True
        Else
            '// *************** Cuongtk 20150811 - Start ***************
            'Dim pathStockInOutHistory As String = AppSettings(PATH_TEMP_HIST)
            Dim pathStockInOutHistory As String = AppSettings("StockInOutHistory(new)")
            Dim dataTable As DataTable = resultTb
            sfDialog.Filter = FILE_CMN_01
            sfDialog.FileName = STOCK_IO_HIST & STRG_CMN_03 & Date.Now.ToString(DATE_CMN_02)
            If sfDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                ExportFile.Enabled = False
                CancelObject.Enabled = False
                ExitScreen.Enabled = False
                '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - start
                Call ExportStockInOutHistory(dataTable, pathStockInOutHistory, sfDialog.FileName)
                '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - end
                CancelObject.Enabled = True
                ExitScreen.Enabled = True
            End If
            '// *************** Cuongtk 20150811 - End ***************
        End If
    End Sub

    ''' <summary>
    ''' Method: Press tab to leave item code
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_item_cd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCode.Leave
        ItemCode.Text = Trim(ItemCode.Text)
        If Not String.IsNullOrEmpty(ItemCode.Text) Then
            Dim resultItem = m_webService.GetItemInfoByCd(ItemCode.Text, ABCDCommon.UserId)
            If IsNothing(resultItem) OrElse resultItem.Tables(0).Rows.Count = 0 Then
                Dim msgScreen As New frm_MSG001("Code does not exist!", "ERR008")
                If msgScreen.ShowDialog() = DialogResult.OK Then
                    msgScreen.Close()
                End If
                ItemCode.Focus()
                ItemCode.SelectAll()
            Else
                Dim itemNm As String = Trim(resultItem.Tables(0).Rows(0)("ITEM_NM").ToString)
                ItemName.Text = itemNm
            End If
        Else
            ItemName.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Method: Change value warehouse by combobox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmb_wh_cd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WarehouseCode.SelectedIndexChanged
        If String.IsNullOrEmpty(Trim(WarehouseCode.Text)) Then
            WarehouseName.Text = String.Empty
        ElseIf TypeOf WarehouseCode.SelectedValue Is String Then
            WarehouseName.Text = WarehouseCode.SelectedValue
        ElseIf TypeOf WarehouseCode.SelectedValue Is DataRow Then
            WarehouseName.Text = WarehouseCode.SelectedValue.Row("WH_NM")
        End If
    End Sub

    ''' <summary>
    ''' Method: Change to get value date
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartStockDate.ValueChanged, EndStockDate.ValueChanged
        ABCDCommon.ChangeDateTimePicker(sender)
    End Sub

#End Region

#Region "Fucntion Form."

    ''' <summary>
    ''' Method: Clear screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearScreen()
        StartStockDate.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(StartStockDate)
        StartStockDate.Value = DateSerial(Today.Year, Today.Month, 1)

        EndStockDate.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(EndStockDate)
        EndStockDate.Value = DateSerial(Today.Year, Today.Month + 1, 0)
        WarehouseCode.SelectedIndex = 0
        ItemCode.Clear()
        ItemName.Clear()
        BarcodeNo.Clear()
        StatusCode.SelectedIndex = 0
        ExportFile.Enabled = True
    End Sub

    ''' <summary>
    ''' Method: Export file excel
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub ExportCSV(ByVal dt As DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            StartStockDate.Focus()
            Return
        End If
        sfDialog.Filter = "Excel File (*.xlsx*) | *.xlsx"
        sfDialog.FileName = "WHS003_" & Date.Now.ToString("yyyyMMddHHmmss") 'Kaidai 187: Format export file .xlsx
        If sfDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            ExportFile.Enabled = False
            CancelObject.Enabled = False
            ExitScreen.Enabled = False
            Dim filePath As String = sfDialog.FileName
            ExportDataToExcel(dt, sfDialog.FileName) 'Kaidai 187: Format export file .xlsx
            CancelObject.Enabled = True
            ExitScreen.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Method: Get data click [Search]
    ''' Cuongtk - 20150814 - Modified
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ResultSearch() As DataTable
        Dim status As Integer = StatusCode.SelectedValue
        Dim warehouse As String = String.Empty
        '// Set value when selected warehouse
        If Not "".Equals(Trim(WarehouseCode.Text)) Then
            warehouse = Trim(WarehouseCode.Text)
        End If
        Try
            Dim dataSet As DataSet = m_webService.GetWarehouseHistTr(BarcodeNo.Text, warehouse, ItemCode.Text, StartStockDate.Value.ToString(DATE_CMN_01), EndStockDate.Value.ToString(DATE_CMN_01), status, UserId)
            Return dataSet.Tables(0)
        Catch ex As Exception
            Dim frm As New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Method: Check data validate[]
    ''' Cuongtk - 20150814 - Modified
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidInput() As Boolean
        '// Check condition search with Date[Start-End] 
        If Not StartStockDate.CustomFormat = " " AndAlso _
                    Not EndStockDate.CustomFormat = " " AndAlso _
                    StartStockDate.Value.Date.CompareTo(EndStockDate.Value.Date) > 0 Then
            Dim msgScreen As New frm_MSG001("From-date can not be great than To-date!", "ERR008")
            If msgScreen.ShowDialog() = DialogResult.OK Then
                msgScreen.Close()
            End If
            StartStockDate.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Load data for combobox Warehouse.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadWarehouseList()
        Dim dt As DataTable = m_webService.GetWarehouseList(ABCDCommon.UserId).Tables(0)

        WarehouseCode.DataSource = New BindingSource(dt, Nothing)
        WarehouseCode.DisplayMember = "WH_CD"
        WarehouseCode.ValueMember = "WH_NM"

        dt.Rows.InsertAt(dt.NewRow(), 0)
        WarehouseCode.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Export data from DataTable into Excel.
    ''' Kaidai 187: Format export file .xlsx
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <remarks></remarks>
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
        excelWorkSheet.Range("A1").Value = "Warehouse Code"
        excelWorkSheet.Range("B1").Value = "Item Code"
        excelWorkSheet.Range("C1").Value = "Item Name"
        excelWorkSheet.Range("D1").Value = "Rack Code"
        excelWorkSheet.Range("E1").Value = "Rack Name"
        excelWorkSheet.Range("F1").Value = "Barcode No"
        excelWorkSheet.Range("G1").Value = "Status Flag"
        excelWorkSheet.Range("H1").Value = "Status Name"
        excelWorkSheet.Range("I1").Value = "Registered Id"
        excelWorkSheet.Range("J1").Value = "Registered Date"
        excelWorkSheet.Range("K1").Value = "Updated Id"
        excelWorkSheet.Range("L1").Value = "Updated Date"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                If k = 5 Then
                    data = "'" & data
                End If
                excelWorkSheet.Cells(row, col) = data
                col = col + 1
            Next
            excelWorkSheet.Range("A" & row.ToString & ":L" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:L").Font.Name = "Times New Roman"
        excelWorkSheet.Range("A:L").Font.Size = 10
        excelWorkSheet.Range("A1:L1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:L1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:L1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:L").Columns.EntireColumn.AutoFit()
        '' Save file Excel.
        Try
            excelWorkSheet.SaveAs(fileName)
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            ExportFile.Enabled = True
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