''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS007.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_MSS007

#Region "Var/Const Form."

    ''' <summary> Column name display grid view. </summary>
    Private colNames As New List(Of String)(New String() {"Item Code", _
                                                          "Item Name", _
                                                          "Current Box Num", _
                                                          "Quantity", _
                                                          "Unit", _
                                                          "Template", _
                                                          "Orotex No"})
    ''' <summary> Column size display grid view. </summary>
    Private colSizes As New List(Of Integer)(New Integer() {210, 420, 90, 80, 80, 130, 80})
    ''' <summary> Web service. </summary>
    Private wbService As New ABCDService.Service
    Private dt As DataTable = Nothing

#End Region

#Region "New Form."

    ''' <summary>
    ''' New form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        lbToday.Text = ABCDCommon.GetSystemDateWithFormat
        ABCDCommon.CreateColumnsInGridView(dgv_lst_item_cus, colNames, colSizes)
        '' Align value display columns: CurSEQ, Quantity.
        dgv_lst_item_cus.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_lst_item_cus.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '' Config url and time-out.
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        '' Focus.
        tb_item_code_from.Focus()
        'dgv_lst_item_cus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        tb_item_code_from.Text = Nothing
        tb_item_name_from.Text = Nothing
        tb_item_code_to.Text = Nothing
        tb_item_name_to.Text = Nothing
        tb_cus_id.Text = Nothing
        tb_cus_nm.Text = Nothing
        tb_quantity.Text = Nothing
        b_export.Enabled = False
    End Sub

#End Region

#Region "Event Form."

    ''' <summary>
    ''' Keypress quantity. Only input number.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_quantity.KeyPress
        Call ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    ''' <summary>
    ''' Click popup item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_item_from_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_popup_item_from.Click
        Dim scrPos001 As New frm_POS001(Me, ABCDConst.MSS007_FROM)
        scrPos001.ShowDialog()
        tb_item_code_to.Focus()
    End Sub

    ''' <summary>
    ''' Click popup item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_item_to_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_popup_item_to.Click
        Dim scrPos001 As New frm_POS001(Me, ABCDConst.MSS007_TO)
        scrPos001.ShowDialog()
        tb_cus_id.Focus()
    End Sub

    ''' <summary>
    ''' Click popup customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_cus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_popup_cus.Click
        Dim scrPos005 As New frm_POS005(Me)
        scrPos005.ShowDialog()
        tb_quantity.Focus()
    End Sub

    ''' <summary>
    ''' Click exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Click cancel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_cancel.Click
        Call ClearScreen()
    End Sub

    ''' <summary>
    ''' Click export into csv file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_export.Click
        sfDialog.Filter = "Excel File (*.xlsx*) | *.xlsx"
        sfDialog.FileName = "MSS009_" & Date.Now.ToString("yyyyMMddHHmmss")
        If sfDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            b_export.Enabled = False
            b_cancel.Enabled = False
            b_exit.Enabled = False
            ExportDataToFile(Me.dt, sfDialog.FileName)
            b_cancel.Enabled = True
            b_exit.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Click search data display grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_search.Click
        Dim itemCodeFromConditon As String = tb_item_code_from.Text
        Dim itemCodeToCondition As String = tb_item_code_to.Text
        Dim customerCodeCondition As String = tb_cus_id.Text
        Dim quantityCondition As Integer = 0
        If Not tb_quantity.Text.Equals("") Then
            quantityCondition = Integer.Parse(tb_quantity.Text.Replace(",", ""))
        End If
        Dim loginCode As String = ABCDCommon.UserId
        b_search.Enabled = False
        Call ResultSearch(dgv_lst_item_cus, _
                          itemCodeFromConditon, _
                          itemCodeToCondition, _
                          customerCodeCondition, _
                          quantityCondition, _
                          loginCode)
        dgv_lst_item_cus.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgv_lst_item_cus.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    ''' <summary>
    ''' Leave quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_quantity.Leave
        If Not tb_quantity.Text.Equals("") Then '' Case quantity is null or blank.
            tb_quantity.Text = Integer.Parse(tb_quantity.Text).ToString(ABCDConst.Format_Number)
            If tb_quantity.Text.Equals("") Then
                tb_quantity.Text = "0"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Changed text customer code.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.TextChanged
        tb_cus_nm.Text = Nothing
    End Sub

    ''' <summary>
    ''' Changed text item code from.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_code_from_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code_from.TextChanged
        tb_item_name_from.Text = Nothing '' Change contains item code from.
    End Sub

    ''' <summary>
    ''' Changed text item code to.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_code_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code_to.TextChanged
        tb_item_name_to.Text = Nothing '' Change contains item code to.
    End Sub

    ''' <summary>
    ''' Event mouse click quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_quantity.MouseClick
        If Not tb_quantity.Text.Equals("") Then
            tb_quantity.Text = tb_quantity.Text.Replace(",", "")
            tb_quantity.SelectAll()
        End If
    End Sub

    ''' <summary>
    ''' Event leave item code from.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_code_from_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code_from.Leave
        Dim ds As DataSet = wbService.GetItemInfoByCd(tb_item_code_from.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count = 1 Then
            tb_item_name_from.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
        End If
    End Sub

    ''' <summary>
    ''' Event leave item code to.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_item_code_to_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_item_code_to.Leave
        Dim ds As DataSet = wbService.GetItemInfoByCd(tb_item_code_to.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count = 1 Then
            tb_item_name_to.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString)
        End If
    End Sub

    ''' <summary>
    ''' Event leave customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.Leave
        Dim ds As DataSet = wbService.GetCustomerInfoByID(tb_cus_id.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count = 1 Then
            tb_cus_nm.Text = Trim(ds.Tables(0).Rows(0)("CUS_NM").ToString)
        End If
    End Sub

#End Region

#Region "Fucntion Form."

    ''' <summary>
    ''' Method init form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearScreen()
        tb_item_code_from.Enabled = True
        tb_item_code_to.Enabled = True
        tb_cus_id.Enabled = True
        tb_quantity.Enabled = True
        b_export.Enabled = False
        b_search.Enabled = True
        '' Clear all textbox.
        tb_item_code_from.Clear()
        tb_item_name_from.Clear()
        tb_item_code_to.Clear()
        tb_item_name_to.Clear()
        tb_cus_id.Clear()
        tb_cus_nm.Clear()
        tb_quantity.Text = Nothing
        b_search.Enabled = True
        '' Clear gridview.
        dgv_lst_item_cus.Rows.Clear()
    End Sub

    ''' <summary>
    ''' Method export csv file and display save dialog box.
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <remarks></remarks>
    Private Sub ExportCSV(ByVal dgv As DataGridView)
        'If ABCDCommon.CheckGridViewIsNothing(dgv) = False Then
        '    b_search.Focus()
        '    Return
        'End If
        'b_export.Enabled = False
        'With sfDialog
        '    .Filter = "Excel Files (*.xlsx*) | *.xlsx"
        '    .FileName = "MSS007_" & Date.Now.ToString(ABCDConst.Format_Date_03 & "HHmmss")
        '    If .ShowDialog = Windows.Forms.DialogResult.OK Then
        '        Try
        '            Me.Cursor = Cursors.WaitCursor
        '            'ExportDataToExcel(Me.dt, .FileName)
        '        Catch ex As Exception
        '        Finally
        '            Me.Cursor = Cursors.Default
        '        End Try
        '    Else
        '        b_export.Enabled = True
        '    End If
        'End With
    End Sub

    ''' <summary>
    ''' Method execute search with condition.
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="itemCodeFromCondition"></param>
    ''' <param name="itemCodeToCondition"></param>
    ''' <param name="customerCodeCondition"></param>
    ''' <param name="quantityCondition"></param>
    ''' <param name="loginCode"></param>
    ''' <remarks></remarks>
    Private Sub ResultSearch(ByVal dgv As DataGridView, _
                             ByVal itemCodeFromCondition As String, _
                             ByVal itemCodeToCondition As String, _
                             ByVal customerCodeCondition As String, _
                             ByVal quantityCondition As Integer, _
                             ByVal loginCode As String)
        Dim ds As DataSet = Nothing
        Dim frm As frm_MSG001
        Try
            Me.Cursor = Cursors.WaitCursor
            ds = wbService.ItemInquiry(itemCodeFromCondition, itemCodeToCondition, "", customerCodeCondition, "", quantityCondition, loginCode)
            Me.dt = Nothing
            Me.dt = ds.Tables(0)
            dgv.Rows.Clear()
            If ds.Tables(0).Rows.Count = 0 Then
                frm = New frm_MSG001(ABCD.My.Resources.Messages.ERR010, "ERR010")
                frm.ShowDialog()
                b_search.Enabled = True
                Return
            End If
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                Dim itemCode As String = Trim(ds.Tables(0).Rows(i)("ITEM_CD").ToString)
                Dim itemName As String = Trim(ds.Tables(0).Rows(i)("ITEM_NM").ToString)
                Dim curSeq As String = Integer.Parse(ds.Tables(0).Rows(i)("CUR_BOX_NUM").ToString).ToString(ABCDConst.Format_Number)
                If curSeq.Equals("") Then
                    curSeq = "0"
                End If
                Dim qty As String = Integer.Parse(ds.Tables(0).Rows(i)("QTY").ToString).ToString(ABCDConst.Format_Number)
                If qty.Equals("") Then
                    qty = "0"
                End If
                Dim unit As String = ConvertIntToString01(Trim(ds.Tables(0).Rows(i)("UNIT").ToString))
                Dim tempType As String = ConvertIntToString02(Trim(ds.Tables(0).Rows(i)("TEMP_TYPE").ToString))
                Dim orotexNo As String = Trim(ds.Tables(0).Rows(i)("OROTEX_NO").ToString)
                Dim arrData As String() = New String() {itemCode, itemName, curSeq, qty, unit, tempType, orotexNo}
                dgv.Rows.Add(arrData)
            Next
            tb_item_code_from.Enabled = False
            tb_item_code_to.Enabled = False
            tb_cus_id.Enabled = False
            tb_quantity.Enabled = False
            b_export.Enabled = True
        Catch ex As Exception
            ds.Dispose()
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            b_search.Enabled = True
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
            ds.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Convert value to display on gridview: Unit.
    ''' </summary>
    ''' <param name="int"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertIntToString01(ByVal int As Integer) As String
        Dim unit As String = ""
        Select Case int
            Case 1
                unit = "Pcs"
        End Select
        Return unit
    End Function

    ''' <summary>
    ''' Convert value to display on gridview: Template.
    ''' </summary>
    ''' <param name="int"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertIntToString02(ByVal int As Integer) As String
        Dim template As String = ""
        Select Case int
            Case 1
                template = "Template 01"
            Case 2
                template = "Template 02"
            Case 3
                template = "Template 03"
            Case 4
                template = "Template 04"
            Case 5
                template = "Template 05"
        End Select
        Return template
    End Function

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
        excelWorkSheet.Range("A1").Value = "Item Code"
        excelWorkSheet.Range("B1").Value = "Item Name"
        excelWorkSheet.Range("C1").Value = "Current Box Num"
        excelWorkSheet.Range("D1").Value = "Quantity"
        excelWorkSheet.Range("E1").Value = "Unit"
        excelWorkSheet.Range("F1").Value = "Template"
        excelWorkSheet.Range("G1").Value = "Orotex No"
        excelWorkSheet.Range("H1").Value = "Path 1"
        excelWorkSheet.Range("I1").Value = "Path 2"
        excelWorkSheet.Range("J1").Value = "Path 3"
        excelWorkSheet.Range("K1").Value = "Path 4"
        excelWorkSheet.Range("L1").Value = "Path 5"
        excelWorkSheet.Range("M1").Value = "Registered Id"
        excelWorkSheet.Range("N1").Value = "Registered Date"
        excelWorkSheet.Range("O1").Value = "Updated Id"
        excelWorkSheet.Range("P1").Value = "Updated Date"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                If k = 2 Then
                    data = "'" & data
                End If
                If k = 4 Then
                    data = ConvertIntToString01(Integer.Parse(data))
                End If
                If k = 5 Then
                    data = ConvertIntToString02(Integer.Parse(data))
                End If
                excelWorkSheet.Cells(row, col) = data
                col = col + 1
            Next
            excelWorkSheet.Range("A" & row.ToString & ":P" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:P").Font.Name = "Times New Roman"
        excelWorkSheet.Range("A:P").Font.Size = 10
        excelWorkSheet.Range("A1:P1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:P1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:P1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:P").Columns.EntireColumn.AutoFit()
        '' Save file Excel.
        Try
            excelWorkSheet.SaveAs(fileName)
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            b_export.Enabled = True
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