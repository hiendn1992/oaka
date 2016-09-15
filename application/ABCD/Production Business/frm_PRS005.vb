Imports ABCD.My.Resources

Public Class frm_PRS005

#Region "Variable form"

    Private webService As New ABCDService.Service
    Private listBarcode As New List(Of String)
    Private dataTable As DataTable
    Private dataSet As DataSet
    Private columnName As New List(Of String)(New String() {"Barcode No", "Item Code", "Item Name", "Box Number", "Quantity", "Lot No", "WO No"})
    Private columnDB As New List(Of String)(New String() {"BC_NO", "ITEM_CD", "ITEM_NM", "BOX_NUM", "QTY", "LOT_NO", "WO_NO"})
    Private columnSize As New List(Of Integer)(New Integer() {120, 100, 200, 100, 75, 110, 80})
    Private currentBoxNum As Integer = 0

#End Region

#Region "New form"

    ''' <summary>
    ''' Initialize form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        webService.Url = ABCDConst.STRING_URL
        webService.Timeout = ABCDConst.STRING_TIMEOUT
    End Sub

#End Region

#Region "Event form"

    ''' <summary>
    ''' Load form start.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_PRS005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Set value user id and date, quantity.
        lbl_info_user.Text = ABCDCommon.GetSystemDateWithFormat()
        'txt_quantity.Text = 0
        '' State control is button.
        btn_execute.Enabled = False
        btn_cancel.Enabled = False
        '' Load column in gridview.
        ABCDCommon.CreateColumnsInGridView(dgv_list_label, columnName, columnSize)
        ReadOnlyColumnGridView()
    End Sub

    ''' <summary>
    ''' Only input value is number into textbox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_quantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_quantity.KeyPress
        ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    ''' <summary>
    ''' Format #,### when leave textbox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_quantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_quantity.Leave
        '' Textbox WO No is focused.
        If txt_wo_no.Focused = True Then
            FormatQuantity(txt_quantity.Text)
            Return
        End If
        '' Textbox Barcode From or Barcode To is focused.
        If txt_barcode_from.Focused = True Or txt_barcode_to.Focused = True Then
            FormatQuantity(txt_quantity.Text)
            Return
        End If
        '' Button Search is focused.
        If btn_search.Focused = True Then
            FormatQuantity(txt_quantity.Text)
            Return
        End If
        '' Button Exit is focused.
        If btn_exit.Focused = True Then
            FormatQuantity(txt_quantity.Text)
            Return
        End If
        FormatQuantity(txt_quantity.Text)
    End Sub

    ''' <summary>
    ''' Click into textbox Quantity auto split ",".
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_quantity_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_quantity.MouseClick
        txt_quantity.Text = txt_quantity.Text.Replace(",", "")
        txt_quantity.Focus()
        txt_quantity.SelectAll()
    End Sub

    ''' <summary>
    ''' Close form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Close()
    End Sub

    ''' <summary>
    ''' Search to get data for gridview.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim frm As frm_MSG001
        dataSet = Nothing
        If txt_wo_no.Text = "" Then '' WO No is null.
            frm = New frm_MSG001(Messages.ERR00501, "ERR00501")
            frm.ShowDialog()
            txt_wo_no.Focus()
            Return
        End If
        If txt_barcode_from.Text = "" Then '' Barcode No From is null.
            frm = New frm_MSG001(Messages.ERR00502, "ERR00502")
            frm.ShowDialog()
            txt_barcode_from.Focus()
            Return
        End If

        If Integer.Parse(txt_barcode_from.Text) > Integer.Parse(txt_barcode_to.Text) Then
            frm = New frm_MSG001(Messages.ERR00504, "ERR00504")
            frm.ShowDialog()
            txt_barcode_from.Focus()
            txt_barcode_from.SelectAll()
            Return
        End If
        'If txt_barcode_to.Text = "" Then '' Barcode No To is null.
        '    frm = New frm_MSG001(Messages.ERR00503, "ERR00503")
        '    frm.ShowDialog()
        '    txt_barcode_to.Focus()
        '    Return
        'End If
        Try
            '' Set state of button: Search, Exit.
            btn_search.Enabled = False
            btn_exit.Enabled = False
            dataSet = webService.GetListBarcode(txt_wo_no.Text, txt_barcode_from.Text, txt_barcode_to.Text, Integer.Parse(txt_quantity.Text.Replace(",", "")), ABCDCommon.UserId)
            If dataSet.Tables(0).Rows.Count = 0 Then '' Can not get data from web service.
                frm = New frm_MSG001(Messages.ERR010, "ERR010")
                frm.ShowDialog()
                btn_search.Enabled = True
                btn_exit.Enabled = True
                Exit Sub
            End If
            ABCDCommon.GetDataForDataGridViewByDataSet(columnDB, dataSet, dgv_list_label, ABCDConst.GRIDVIEW_NORMAL)
            dgv_list_label.ClearSelection()
            btn_exit.Enabled = True
            btn_cancel.Enabled = True
            btn_execute.Enabled = True
            txt_wo_no.Enabled = False
            txt_barcode_from.Enabled = False
            txt_barcode_to.Enabled = False
            txt_quantity.Enabled = False
        Catch ex As Exception '' Exception.
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            btn_search.Enabled = True
            btn_exit.Enabled = True
            Return
        End Try
    End Sub

    ''' <summary>
    ''' Update value in DB.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_execute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_execute.Click
        Dim frm As frm_MSG001
        Dim row As Integer = 0
        Dim remainQuantity As Integer = 0

        '// Check list barcode on screen exist in W900, W830. [cuongtk(20150831)]
        Dim barcodeScreen As String = GetListOnGridview(dgv_list_label)
        Dim isExistW900OrW830 As Boolean = webService.IsExistW900OrW830(barcodeScreen, ABCDCommon.UserId)
        If Not isExistW900OrW830 Then
            Dim formError As New frm_MSG001("Can not delete because Barcode is not in MOLD!", "ERR9004")
            formError.ShowDialog()
            Exit Sub
        End If

        listBarcode = ListBarcodeSelected(dgv_list_label)
        currentBoxNum = GetCurrentBoxNum()
        currentBoxNum = currentBoxNum - listBarcode.Count
        remainQuantity = GetRemainQuantity() 'Lấy tổng số lượng còn lại.
        frm = New frm_MSG001(Messages.MSG039, "MSG039")
        If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
            Try
                btn_execute.Enabled = False
                btn_cancel.Enabled = False
                btn_exit.Enabled = False
                row = webService.UpdateItemDetail(listBarcode.ToArray, currentBoxNum, dgv_list_label.Rows(0).Cells(1).Value, _
                                                  remainQuantity, dgv_list_label.Rows(0).Cells(6).Value, ABCDCommon.UserId)
                If row > 0 Then
                    frm = New frm_MSG001(Messages.INF040, "INF040")
                    frm.ShowDialog()
                    btn_cancel.Enabled = True
                    btn_exit.Enabled = True
                    Return
                End If
                btn_execute.Enabled = True
                btn_cancel.Enabled = True
                btn_exit.Enabled = True
            Catch ex As Exception
                frm = New frm_MSG001(ex.Message, "ERR9004")
                frm.ShowDialog()
                btn_execute.Enabled = True
                btn_cancel.Enabled = True
                btn_exit.Enabled = True
                Return
            End Try
        End If
    End Sub

    Private Sub txt_wo_no_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_wo_no.KeyPress
        'ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    Private Sub txt_barcode_from_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_barcode_from.KeyPress
        ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    Private Sub txt_barcode_to_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_barcode_to.KeyPress
        ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        btn_execute.Enabled = False
        btn_cancel.Enabled = False
        btn_search.Enabled = True
        dgv_list_label.Rows.Clear()
        txt_wo_no.Enabled = True
        txt_barcode_from.Enabled = True
        'txt_barcode_to.Enabled = True
        txt_quantity.Enabled = True
        txt_wo_no.Focus()
        txt_wo_no.SelectAll()
    End Sub

    Private Sub txt_wo_no_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_wo_no.Leave
        'Truong hop focus tai Exit.
        If btn_exit.Focused = True Then
            Return
        End If
        'Truong hop focus tai Search.
        If btn_search.Focused = True Then
            Return
        End If
        'Truong hop focus tai Gridview.
        If dgv_list_label.Focused = True Then
            Return
        End If
        Dim frm As frm_MSG001
        If txt_wo_no.Text <> "" Then
            Try
                dataTable = Nothing
                dataTable = webService.GetItemDetailByWorkNo(txt_wo_no.Text, ABCDCommon.UserId).Tables(0)
                If dataTable.Rows.Count = 0 Then
                    frm = New frm_MSG001(Messages.ERR010, "ERR010")
                    frm.ShowDialog()
                    txt_wo_no.Focus()
                    txt_wo_no.SelectAll()
                    Return
                End If
                txt_barcode_to.Text = dataTable.Rows(0)("BOX_NUM").ToString
                txt_quantity.Text = 0
                txt_barcode_from.Enabled = True
                txt_quantity.Enabled = True
                txt_barcode_from.Focus()
            Catch ex As Exception
                frm = New frm_MSG001(ex.Message, "ERR9004")
                frm.ShowDialog()
                Return
            End Try
        Else
            frm = New frm_MSG001(Messages.ERR00501, "ERR00501")
            frm.ShowDialog()
            txt_wo_no.Focus()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Sự kiện sau khi nhập giá trị Current Box From.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_barcode_from_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_barcode_from.Leave
        'Truong hop click Search.
        If btn_search.Focused = True Then
            Return
        End If
        'Truong hop click Exit.
        If btn_exit.Focused = True Then
            Return
        End If
        'Truong hop focus tai Gridview.
        If dgv_list_label.Focused = True Then
            Return
        End If
        Dim frm As frm_MSG001 'Khai báo form để hiển thị message lỗi(thông báo, yêu cầu).
        'Trường hợp Current Box From là rỗng.
        If txt_barcode_from.Text = "" Then
            frm = New frm_MSG001(Messages.ERR00502, "ERR00502")
            frm.ShowDialog()
            txt_barcode_from.Focus()
            Return
        End If
        'Trường hợp Current Bõ From là chữ.
        If IsNumeric(txt_barcode_from.Text) = False Then
            frm = New frm_MSG001(Messages.ERR00504, "ERR00505")
            frm.ShowDialog()
            txt_barcode_from.Focus()
            txt_barcode_from.SelectAll()
            Return
        End If
        txt_barcode_from.Text = Integer.Parse(txt_barcode_from.Text).ToString("0000") 'Chuyển đổi về định dạng (0000).
    End Sub

#End Region

#Region "Common form"

    ''' <summary>
    ''' Auto convert format of number when leave.
    ''' </summary>
    ''' <param name="quantity"></param>
    ''' <remarks></remarks>
    Private Sub FormatQuantity(ByVal quantity As String)
        '' Value of textbox Quantity is null.
        If quantity.Replace(",", "") = "" Then
            txt_quantity.Text = "0"
        End If
        '' Value of textbox Quantity is not null.
        If quantity.Replace(",", "") <> "" Then
            txt_quantity.Text = Integer.Parse(quantity.Replace(",", "")).ToString("#,###")
            If txt_quantity.Text = "" Then '' After convert format Quantity is null.
                txt_quantity.Text = "0"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Get list barcode.
    ''' </summary>
    ''' <param name="dataGridView"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ListBarcodeSelected(ByVal dataGridView As DataGridView) As List(Of String)
        Dim listBcTemp As New List(Of String)
        For i As Integer = 0 To dataGridView.RowCount - 1 Step 1
            listBcTemp.Add(dataGridView.Rows(i).Cells(0).Value)
        Next
        Return listBcTemp
    End Function

    Private Function GetCurrentBoxNum() As Integer
        Dim itemCode As String = String.Empty
        dataTable = Nothing
        If dgv_list_label.RowCount > 0 Then
            itemCode = dgv_list_label.Rows(0).Cells(1).Value
            dataTable = webService.GetItemInfoByCd(itemCode, ABCDCommon.UserId).Tables(0)
            If dataTable.Rows.Count > 0 Then
                Return Integer.Parse(Trim(dataTable.Rows(0)("CUR_BOX_NUM").ToString))
            End If
        End If
        Return 0
    End Function

    ''' <summary>
    ''' Tổng số lượng của những Label cần delete.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRemainQuantity() As Integer
        Dim remainQuantity As Integer = 0 'Tổng số lượng trước khi chưa xoá.
        dataTable = Nothing
        dataTable = webService.GetWOInfoByWONo(txt_wo_no.Text, ABCDCommon.UserId).Tables(0)
        If dataTable.Rows.Count > 0 Then
            remainQuantity = remainQuantity + Integer.Parse(dataTable.Rows(0)("REMAIN_QTY").ToString)
        End If
        For i As Integer = 0 To dgv_list_label.RowCount - 1 Step 1 'Duyệt qua toàn bộ lưới data grid view.
            remainQuantity = remainQuantity + Integer.Parse(dgv_list_label.Rows(i).Cells(4).Value)
        Next
        Return remainQuantity
    End Function

    Private Sub ReadOnlyColumnGridView()
        For i As Integer = 0 To dgv_list_label.ColumnCount - 1 Step 1
            If i <> 0 Then
                dgv_list_label.Columns(i).ReadOnly = True
            End If
        Next
    End Sub

    ''' <summary>
    ''' Get list barcode on screen.
    ''' Cuongtk[20150831].
    ''' </summary>
    ''' <param name="dgv_list_label"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetListOnGridview(ByVal dgv_list_label As DataGridView) As String
        Dim listBarcode As String = String.Empty
        For i As Integer = 0 To dgv_list_label.RowCount - 1 Step 1
            If i <> 0 Then
                listBarcode = listBarcode & ","
            End If
            listBarcode = listBarcode & "'" & dgv_list_label.Rows(i).Cells(0).Value & "'" 'LanNT - 20160824
        Next
        Return listBarcode
    End Function

#End Region

End Class