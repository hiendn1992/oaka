''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS008.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-15    1.00    Hungtg   New
''*********************************************************
Public Class frm_MSS008
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
        lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat
        ' Set display datagridview.
        grd_rack_inqry.ColumnCount = 4
        grd_rack_inqry.Columns(0).Name = "Rack Code"
        grd_rack_inqry.Columns(0).Width = 260
        grd_rack_inqry.Columns(1).Name = "Rack Name"
        grd_rack_inqry.Columns(1).Width = 290
        grd_rack_inqry.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grd_rack_inqry.Columns(2).Name = "Register User"
        grd_rack_inqry.Columns(2).Width = 100
        grd_rack_inqry.Columns(2).Visible = False
        grd_rack_inqry.Columns(3).Name = "Register Date"
        grd_rack_inqry.Columns(3).Width = 100
        grd_rack_inqry.Columns(3).Visible = False
        'Set full row selection for gridview
        grd_rack_inqry.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'Set control display 
        _dispOpt = 0
        DisplayOption(_dispOpt)
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
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txt_rack_code.Enabled = True
        txt_rack_name.Enabled = True
        btn_search.Enabled = True
        btn_export.Enabled = False
        txt_rack_code.Text = Nothing
        txt_rack_name.Text = Nothing
        grd_rack_inqry.Rows.Clear()
    End Sub
    ''' <summary>
    ''' Event click button Search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim frm As frm_MSG001
        Dim arr(4) As String
        btn_search.Enabled = False
        btn_clear.Enabled = False
        btn_exit.Enabled = False
        grd_rack_inqry.Rows.Clear()
        Try
            Me.ds = Nothing
            Me.ds = ws.RackInquiry(txt_rack_code.Text, txt_rack_name.Text, ABCDCommon.UserId)
            If Me.ds.Tables(0).Rows.Count = 0 Then
                frm = New frm_MSG001(ABCD.My.Resources.Messages.ERR010, "ERR010")
                frm.ShowDialog()
                btn_search.Enabled = True
                btn_clear.Enabled = True
                btn_exit.Enabled = True
                Exit Sub
            End If
            For i As Integer = 0 To Me.ds.Tables(0).Rows.Count - 1 Step 1
                arr(0) = Me.ds.Tables(0).Rows(i)("RACK_CD").ToString
                arr(1) = Me.ds.Tables(0).Rows(i)("RACK_NM").ToString
                grd_rack_inqry.Rows.Add(arr)
            Next
            txt_rack_code.Enabled = False
            txt_rack_name.Enabled = False
            btn_export.Enabled = True
            btn_clear.Enabled = True
            btn_exit.Enabled = True
        Catch ex As Exception
            Me.ds.Dispose()
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' Event export file excel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        sfdDialog.Filter = "Excel File (*.xlsx*) | *.xlsx"
        sfdDialog.FileName = "MSS008_" & Date.Now.ToString("yyyyMMddHHmmss")
        If sfdDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            btn_export.Enabled = False
            btn_clear.Enabled = False
            btn_exit.Enabled = False
            ExportDataToFile(Me.ds.Tables(0), sfdDialog.FileName)
            btn_clear.Enabled = True
            btn_exit.Enabled = True
        End If
    End Sub

#End Region

#Region "Common Method Form"
    ''' <summary>
    ''' Set control display status on screen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DisplayOption(ByVal status As Integer)
        'Empty begining screen
        If status = 0 Then
            txt_rack_code.Enabled = True
            txt_rack_name.Enabled = True
            btn_search.Enabled = True
            btn_export.Enabled = False
            btn_clear.Text = "Clear"
        End If
        'Search result screen
        If status = 1 Then
            txt_rack_code.Enabled = False
            txt_rack_name.Enabled = False
            btn_search.Enabled = False
            btn_export.Enabled = True
            btn_clear.Text = "Cancel"
        End If
        'After export screen
        If status = 2 Then
            btn_search.Enabled = False
            btn_export.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Export data to file Excel.
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
        excelWorkSheet.Range("A1").Value = "Rack Code"
        excelWorkSheet.Range("B1").Value = "Rack Name"
        excelWorkSheet.Range("C1").Value = "Warehouse Code"
        excelWorkSheet.Range("D1").Value = "Registered Id"
        excelWorkSheet.Range("E1").Value = "Registered Date"
        excelWorkSheet.Range("F1").Value = "Updated Id"
        excelWorkSheet.Range("G1").Value = "Updated Date"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                'If k = 2 Then
                '    data = GetNameDestination(data)
                'End If
                excelWorkSheet.Cells(row, col) = data
                col = col + 1
            Next
            excelWorkSheet.Range("A" & row.ToString & ":G" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:G").Font.Name = "Times New Roman"
        excelWorkSheet.Range("A:G").Font.Size = 10
        excelWorkSheet.Range("A1:G1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:G1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:G1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:G").Columns.EntireColumn.AutoFit()
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