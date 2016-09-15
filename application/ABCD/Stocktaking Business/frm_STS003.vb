''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_STS003.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   28-JAN-15    1.00     Cuongtk   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_STS003

#Region "Var/Const Form."

    ''' <summary> delcare web service to get data. </summary>
    Private ws As New ABCDService.Service
    ''' <summary> declare dataset to get data process. </summary>
    Private ds As DataSet = Nothing

#End Region

#Region "New Form."

    ''' <summary>
    ''' New form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal _ds As DataSet)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = ABCDConst.STRING_TIMEOUT
        ' Set value dataset.
        ds = _ds
    End Sub

#End Region

#Region "Event Form."

    ''' <summary>
    ''' Event load form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STS003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Get system date format dd/MM/yyyy.
        lbToday.Text = ABCDCommon.GetSystemDateWithFormat
        '' Get dataset from tables: STOCK_REQ_INFO_TR, ITEM_MASTER_MS, WH_MASTER_MS.
        'ds = ws.GetStockReqInfoTr(ABCDCommon.UserId) 'Change check data on screen Menu.
        '' Config data for control on screen.
        If ds.Tables(0).Rows.Count <> 0 Then
            lbStockDate.Text = DateTime.Parse(Trim(ds.Tables(0).Rows(0)("STOCK_DT").ToString)).ToString(ABCDConst.Format_Date_01)

            '// Warehouse code null
            If "".Equals(Trim(ds.Tables(0).Rows(0)("WH_CD").ToString)) Then
                Label2.Text = String.Empty
            End If
            lbWarehouseCode.Text = Trim(ds.Tables(0).Rows(0)("WH_CD").ToString)
            lbWarehouseName.Text = Trim(ds.Tables(0).Rows(0)("WH_NM").ToString)

            '// Item code null
            If "".Equals(Trim(ds.Tables(0).Rows(0)("ITEM_CD").ToString)) Then
                Label5.Text = String.Empty
            End If
            lbItemCode.Text = Trim(ds.Tables(0).Rows(0)("ITEM_CD").ToString)
            lbItemName.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)

            'lbWarehouseCode.Text = Trim(ds.Tables(0).Rows(0)("WH_CD").ToString)
            'lbItemCode.Text = Trim(ds.Tables(0).Rows(0)("ITEM_CD").ToString)
            ' '' Get warehouse name.
            'ds = Nothing
            'If Not lbWarehouseCode.Text.Equals("") Then
            '    ds = ws.GetWarehouseInfoByCd(lbWarehouseCode.Text, ABCDCommon.UserId)
            '    lbWarehouseName.Text = Trim(ds.Tables(0).Rows(0)("WH_NM").ToString)
            'Else
            '    lbWarehouseName.Text = Nothing
            '    Label2.Text = Nothing 'Kaidai 197: Delete "|".
            'End If
            ' '' Get item name.
            'ds = Nothing
            'If Not lbItemCode.Text.Equals("") Then
            '    ds = ws.GetItemInfoByCd(lbItemCode.Text, ABCDCommon.UserId)
            '    lbItemName.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
            'Else
            '    lbItemName.Text = Nothing
            '    Label5.Text = Nothing 'Kaidai 197: Delete "|".
            'End If
        Else
            Me.Close()
            Dim frm As New frm_MSG001(Messages.ERR010, "ERR010")
            frm.ShowDialog()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event click print.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        ds = Nothing
        '' Get data table STOCK_REQ_DTL_INFO.
        ds = ws.GetStockResultDtlInfoTr(ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count > 0 Then
            SaveFileDialog1.Filter = "Excel File (*.xlsx*) | *.xlsx"
            SaveFileDialog1.FileName = "STS003_" & Date.Now.ToString("yyyyMMddHHmmss")
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then '' Open dialog save file.
                btPrint.Enabled = False
                btExit.Enabled = False
                ExportDataToFile(ds.Tables(0), SaveFileDialog1.FileName)
                btPrint.Enabled = True
                btExit.Enabled = True
            End If
        Else '' Not data
            Dim frmMsg001 As New frm_MSG001(Messages.ERR010, "ERR010")
            frmMsg001.ShowDialog()
            btPrint.Focus()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Event click exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

#End Region

#Region "Function Form."

    ''' <summary>
    ''' Kaidai 201: Change display column name header export.
    ''' Example: SYS_WH_CD -> System Warehouse.
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Private Sub ExportDataToFile(ByVal dataTable As DataTable, ByVal fileName As String)
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
        excelWorkSheet.Range("A1").Value = "Barcode No"
        excelWorkSheet.Range("B1").Value = "System Warehouse"
        excelWorkSheet.Range("C1").Value = "System Rack"
        excelWorkSheet.Range("D1").Value = "Actual Warehouse"
        excelWorkSheet.Range("E1").Value = "Actual Rack"
        '--AIT Hungtg start 04/08/2015
        excelWorkSheet.Range("F1").Value = "Item Code"
        excelWorkSheet.Range("G1").Value = "Item Name"
        excelWorkSheet.Range("H1").Value = "Lot No"
        excelWorkSheet.Range("I1").Value = "Specified Flag"
        excelWorkSheet.Range("J1").Value = "Scanned Flag"
        excelWorkSheet.Range("K1").Value = "Registered Id"
        excelWorkSheet.Range("L1").Value = "Registered Date"
        excelWorkSheet.Range("M1").Value = "Updated Id"
        excelWorkSheet.Range("N1").Value = "Updated Date"
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
            excelWorkSheet.Range("A" & row.ToString & ":N" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:N").Font.Name = "Times New Roman"
        excelWorkSheet.Range("A:N").Font.Size = 10
        excelWorkSheet.Range("A1:N1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:N1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:N1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:N").Columns.EntireColumn.AutoFit()
        '--AIT Hungtg end 04/08/2015
        '' Save file Excel.
        Try
            excelWorkSheet.SaveAs(fileName)
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            btPrint.Enabled = True
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