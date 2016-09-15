''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS009.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   12-JAN-15    1.00     Cuongtk   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_MSS009

#Region "Var/Const Form"

    Private wbService As New ABCDService.Service

    Private dt As DataTable = Nothing

    Private colNames As New List(Of String)(New String() {"Customer Id", "Customer Name", "Email", "Tel No", "Fax No", "Address", "Destination"})
    Private colSizes As New List(Of Integer)(New Integer() {100, 130, 120, 120, 120, 160, 90})
    Private colNameDB As New List(Of String)(New String() {"CUS_ID", "CUS_NM", "MAIL_ADD", "TEL_NO", "FAX_NO", "ADDRESS", "DEST"})

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
        lbl_today.Text = ABCDCommon.GetSystemDateWithFormat
        '' Load data combo box destination.
        cmo_dest.DataSource = wbService.GetCodeMasterMS(ABCDConst.Type_Destination, ABCDCommon.UserId).Tables(0)
        cmo_dest.DisplayMember = "CODE_NAME"
        cmo_dest.ValueMember = "CODE_02"
        '' Create gridview.
        Call ABCDCommon.CreateColumnsInGridView(grd_cus_inqry, colNames, colSizes)
        '' Config web service url and time-out.
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        grd_cus_inqry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        btn_export.Enabled = False
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Event click search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Try
            Dim customerCode As String = txt_cus_id.Text
            Dim customerName As String = txt_cus_name.Text
            Dim customerDestination As Integer = cmo_dest.SelectedValue
            Dim customerEmail As String = txt_email.Text
            Dim customerTelNo As String = txt_tel.Text
            Dim customerAddress As String = txt_address.Text
            Dim loginCode As String = ABCDCommon.UserId
            btn_search.Enabled = False
            Dim ds As DataSet = wbService.CustomerInquiry(customerCode, customerName, customerTelNo, customerAddress, customerEmail, customerDestination, loginCode)
            Me.dt = Nothing
            Me.dt = ds.Tables(0)
            grd_cus_inqry.Rows.Clear()
            If ds.Tables(0).Rows.Count = 0 Then
                Dim frmMsg001 As New frm_MSG001(Messages.ERR010, "ERR010")
                frmMsg001.ShowDialog()
                txt_cus_id.Focus()
                btn_search.Enabled = True
                Return
            End If
            Call ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, grd_cus_inqry, ABCDConst.GRIDVIEW_NORMAL)
            txt_cus_id.Enabled = False
            txt_cus_name.Enabled = False
            txt_address.Enabled = False
            txt_email.Enabled = False
            txt_tel.Enabled = False
            cmo_dest.Enabled = False
            btn_export.Enabled = True
        Catch ex As Exception
            Dim frm As New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            btn_search.Enabled = True
            Exit Try
        End Try
    End Sub

    ''' <summary>
    ''' Event click export csv.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        If Not ABCDCommon.CheckNullOfDataGridView(grd_cus_inqry) Then
            Return
        End If
        With sfDialog
            .Filter = "Excel File (*.xlsx*) | *.xlsx"
            .FileName = "MSS009_" & Date.Now.ToString("yyyyMMddHHmmss")
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                btn_export.Enabled = False
                btn_clear.Enabled = False
                btn_exit.Enabled = False
                ExportDataToExcel(Me.dt, .FileName)
                btn_clear.Enabled = True
                btn_exit.Enabled = True
            End If
        End With
    End Sub

    ''' <summary>
    ''' Event click clear.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txt_cus_id.Enabled = True
        txt_cus_name.Enabled = True
        txt_address.Enabled = True
        txt_email.Enabled = True
        txt_tel.Enabled = True
        cmo_dest.Enabled = True
        txt_cus_id.Text = Nothing
        txt_cus_name.Text = Nothing
        txt_email.Text = Nothing
        txt_tel.Text = Nothing
        txt_address.Text = Nothing
        cmo_dest.SelectedValue = 0
        btn_search.Enabled = True
        btn_export.Enabled = False
        grd_cus_inqry.Rows.Clear()
    End Sub

    ''' <summary>
    ''' Event click exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
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
        '' Set value display Header.
        excelWorkSheet.Range("A1").Value = "Customer Id"
        excelWorkSheet.Range("B1").Value = "Customer Name"
        excelWorkSheet.Range("C1").Value = "Destination"
        excelWorkSheet.Range("D1").Value = "Address"
        excelWorkSheet.Range("E1").Value = "Telephone"
        excelWorkSheet.Range("F1").Value = "Fax"
        excelWorkSheet.Range("G1").Value = "Email"
        excelWorkSheet.Range("H1").Value = "Registered Id"
        excelWorkSheet.Range("I1").Value = "Registered Date"
        excelWorkSheet.Range("J1").Value = "Updated Id"
        excelWorkSheet.Range("K1").Value = "Updated Date"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                If k = 2 Then
                    data = GetNameDestination(data)
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

    Private Function GetNameDestination(ByVal strCode As String) As String
        Dim codeName As String = ""
        Select Case strCode
            Case "1"
                codeName = "Domestic"
            Case "2"
                codeName = "Oversea"
        End Select
        Return codeName
    End Function

#End Region

End Class