Public Class frm_OA_MSS003

#Region "Var/Const Form"
    Private ws As New ABCDService.Service
    Private ds As DataSet = Nothing
    Private prtForm As Form

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

        Me.prtForm = prtForm

        ' Call load data combobox authority.       
        'lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat

        ' Set display datagridview.
        grdReasonInquiry.ColumnCount = 2
        grdReasonInquiry.Columns(0).Name = "Reason Code"
        grdReasonInquiry.Columns(0).Width = 200
        grdReasonInquiry.Columns(1).Name = "Reason Name"
        grdReasonInquiry.Columns(1).Width = 375
        grdReasonInquiry.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'Set full row selection for gridview
        grdReasonInquiry.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub
#End Region

#Region "Event Form"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        grdReasonInquiry.Rows.Clear()
        Try
            ds = ws.ReasonInquiry(txtReasonCode.Text, _
                                txtReasonName.Text, _
                                ABCDCommon.UserId)

            ' Get data for gridview.
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                Dim arr(2) As String
                arr(0) = ds.Tables(0).Rows(i)("REASON_CD").ToString
                arr(1) = ds.Tables(0).Rows(i)("REASON_NM").ToString
                grdReasonInquiry.Rows.Add(arr)
            Next
        Catch ex As Exception
            ds.Dispose()
            Dim frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
            btnExport.Enabled = True
            ds.Dispose()
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtReasonCode.Text = ""
        txtReasonName.Text = ""
        grdReasonInquiry.Rows.Clear()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Not ABCDCommon.CheckNullOfDataGridView(grdReasonInquiry) Then
            Return
        End If
        If Me.ds.Tables(0).Rows.Count = 0 Then
            Dim frm As New frm_MSG001("Data is empty, please excute inquiry first", "ERR028")
            frm.ShowDialog()
            Return
        End If
        With sfDialog
            .Filter = "Excel File (*.xlsx*) | *.xlsx"
            .FileName = "OA_MSS003_" & Date.Now.ToString("yyyyMMddHHmmss")
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                btnExport.Enabled = False
                btnCancel.Enabled = False
                btnExit.Enabled = False
                ExportDataToExcel(Me.ds.Tables(0), .FileName)
                btnCancel.Enabled = True
                btnExit.Enabled = True
            End If
        End With
    End Sub

#End Region

#Region "Function Form"

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
        Dim codeImg As Image = Nothing
        Dim b As New BarcodeLib.Barcode()
        Dim codeWidth As Integer = 150
        Dim codeHeight As Integer = 22
        '' Set value display Header.
        excelWorkSheet.Range("A1").Value = "Reason Code"
        excelWorkSheet.Range("B1").Value = "Reason Name"
        excelWorkSheet.Range("C1").Value = "Barcode"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 5 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                excelWorkSheet.Cells(row, col) = data
                If (k + 1) > dataTable.Columns.Count - 5 Then
                    codeImg = b.Encode(BarcodeLib.TYPE.CODE39, Trim(dataTable.Rows(i)(0).ToString), codeWidth, codeHeight)
                    System.Windows.Forms.Clipboard.SetDataObject(codeImg, True)
                    excelWorkSheet.Cells(row, col + 1).ColumnWidth = codeWidth / 5
                    excelWorkSheet.Cells(row, col + 1).RowHeight = codeHeight
                    excelWorkSheet.Cells(row, col + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    excelWorkSheet.Cells(row, col + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    excelWorkSheet.Paste(excelWorkSheet.Cells(row, col + 1))
                End If
                col = col + 1
            Next
            excelWorkSheet.Range("A" & row.ToString & ":C" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:C").Font.Name = "Times New Roman"
        excelWorkSheet.Range("A:C").Font.Size = 10
        excelWorkSheet.Range("A1:C1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:C1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:C1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:B").Columns.EntireColumn.AutoFit()
        '' Save file Excel.
        Try
            excelWorkSheet.SaveAs(fileName)
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            btnExport.Enabled = True
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