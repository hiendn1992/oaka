''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS006.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   09-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_MSS006

#Region "Var/Const Form"

    ''' <summary>
    ''' Webservice.
    ''' </summary>
    ''' <remarks></remarks>
    Private wbService As New ABCDService.Service

    Private dt As DataTable = Nothing

    ''' <summary>
    ''' Gridview.
    ''' </summary>
    ''' <remarks></remarks>
    Private colNames As New List(Of String)(New String() {"User Id", "User Name", "Authority", "Remark"})
    Private colSizes As New List(Of Integer)(New Integer() {120, 225, 130, 385})
    Private colNameDB As New List(Of String)(New String() {"USER_ID", "USER_NM", "AUTHORITY", "REM"})

#End Region

#Region "New Form"

    ''' <summary>
    ''' Initialize Form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat
        Call ABCDCommon.InitComboboxByStyle(cb_authority, ABCDConst.STYLE_COMBOBOX_01)
        Call ABCDCommon.CreateColumnsInGridView(dgv_lst_user, colNames, colSizes)
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        b_export.Enabled = False
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Click Search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_search.Click
        Dim ds As DataSet = Nothing
        Dim frm As frm_MSG001 = Nothing
        dgv_lst_user.Rows.Clear()
        b_search.Enabled = False
        Try
            Cursor = Cursors.WaitCursor
            ds = wbService.UserInquiry(tb_user_id.Text, tb_remark.Text, cb_authority.SelectedValue, ABCDCommon.UserId)
            Me.dt = Nothing
            Me.dt = ds.Tables(0)
            If ds.Tables(0).Rows.Count = 0 Then
                frm = New frm_MSG001(ABCD.My.Resources.Messages.ERR010, "ERR010")
                frm.ShowDialog()
                tb_user_id.Focus()
                b_search.Enabled = True
                Return
            End If
            ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, dgv_lst_user, ABCDConst.GRIDVIEW_NORMAL)
            b_export.Enabled = True
            tb_user_id.Enabled = False
            tb_remark.Enabled = False
            cb_authority.Enabled = False
        Catch ex As Exception
            frm = New frm_MSG001(ex.StackTrace, "ERR9004")
            frm.ShowDialog()
            Cursor = Cursors.Default
            b_search.Enabled = True
            ds.Dispose()
            Exit Try
        Finally
            Cursor = Cursors.Default
            ds.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Click Export.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_export.Click
        With sfdDialog
            .Filter = "Excel File (*.xlsx*) | *.xlsx"
            .FileName = "MSS006_" & Date.Now.ToString("yyyyMMddHHmmss")
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                b_export.Enabled = False
                b_cancel.Enabled = False
                b_exit.Enabled = False
                ExportDataToExcel(Me.dt, .FileName)
                b_cancel.Enabled = True
                b_exit.Enabled = True
            End If
        End With
    End Sub

    ''' <summary>
    ''' Click Cancel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_cancel.Click
        tb_user_id.Enabled = True
        tb_remark.Enabled = True
        cb_authority.Enabled = True
        tb_user_id.Text = Nothing
        tb_remark.Text = Nothing
        cb_authority.SelectedValue = 0
        dgv_lst_user.Rows.Clear()
        b_export.Enabled = False
        b_search.Enabled = True
    End Sub

    ''' <summary>
    ''' Click Exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exit.Click
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
        excelWorkSheet.Range("A1").Value = "User Id"
        excelWorkSheet.Range("B1").Value = "User Name"
        excelWorkSheet.Range("C1").Value = "Authority"
        excelWorkSheet.Range("D1").Value = "Remark"
        excelWorkSheet.Range("E1").Value = "Registered Id"
        excelWorkSheet.Range("F1").Value = "Registered Date"
        excelWorkSheet.Range("G1").Value = "Updated Id"
        excelWorkSheet.Range("H1").Value = "Updated Date"
        '' Set value cells under header.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            For k As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = String.Empty
                data = Trim(dataTable.Rows(i)(k).ToString)
                If k = 0 Or k = 5 Or k = 7 Then
                    data = "'" & data
                End If
                If k = 2 Then
                    Continue For
                End If
                If k = 3 Then
                    data = GetNameAuthority(data)
                End If
                excelWorkSheet.Cells(row, col) = data
                col = col + 1
            Next
            excelWorkSheet.Range("A" & row.ToString & ":H" & row.ToString).Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            row = row + 1
            col = 1
        Next
        excelWorkSheet.Range("A:H").Font.Name = "Times New Roman"
        excelWorkSheet.Range("A:H").Font.Size = 10
        excelWorkSheet.Range("A1:H1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        excelWorkSheet.Range("A1:H1").Columns.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        excelWorkSheet.Range("A1:H1").Interior.ColorIndex = 35
        excelWorkSheet.Range("A:H").Columns.EntireColumn.AutoFit()
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

    Private Function GetNameAuthority(ByVal strCode As String) As String
        Dim codeName As String = ""
        Select Case strCode
            Case "1"
                codeName = "Admin"
            Case "2"
                codeName = "QC"
            Case "3"
                codeName = "FG"
            Case "4"
                codeName = "SU"
            Case "5"
                codeName = "MOLD"
        End Select
        Return codeName
    End Function

#End Region

End Class