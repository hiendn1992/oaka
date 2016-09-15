''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_POS006.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   14-JAN-15    1.00     Toannn   New
''*********************************************************

Public Class frm_POS006

#Region "Var/Const Form."

    Private Shadows parentForm As Form

    Private colNames As New List(Of String)(New String() {"", _
                                                          "W/O No", _
                                                          "W/O Date", _
                                                          "Item Code", _
                                                          "Item Name", _
                                                          "Lot No", _
                                                          "Product Quantity", _
                                                          "Total Box"})

    Private colSizes As New List(Of Integer)(New Integer() {70, _
                                                            120, _
                                                            120, _
                                                            210, _
                                                            420, _
                                                            150, _
                                                            95, _
                                                            80})

    Private wbService As New ABCDService.Service

#End Region

#Region "New Form."

    Public Sub New(ByVal frm As Form)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.parentForm = frm
        'lbl_today.Text = ABCDCommon.GetSystemDateWithFormat
        ' Init gridview
        Dim colButton As New DataGridViewButtonColumn
        colButton.Text = "Select"
        colButton.UseColumnTextForButtonValue = True
        grd_pd_info.Columns.Add(colButton)

        ABCDCommon.CreateColumnsInGridView(grd_pd_info, _
                                           colNames, _
                                           colSizes)
        grd_pd_info.AutoGenerateColumns = False
        grd_pd_info.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grd_pd_info.Columns(2).DefaultCellStyle.Format = ABCDConst.FORMAT_DATE_01
        grd_pd_info.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grd_pd_info.Columns(6).DefaultCellStyle.Format = "N0"
        grd_pd_info.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grd_pd_info.Columns(7).DefaultCellStyle.Format = "N0"
        grd_pd_info.Columns(1).DataPropertyName = "WO_NO"
        grd_pd_info.Columns(2).DataPropertyName = "WO_DT"
        grd_pd_info.Columns(3).DataPropertyName = "ITEM_CD"
        grd_pd_info.Columns(4).DataPropertyName = "ITEM_NM"
        grd_pd_info.Columns(5).DataPropertyName = "LOT_NO"
        grd_pd_info.Columns(6).DataPropertyName = "PRODUCT_QTY"
        grd_pd_info.Columns(7).DataPropertyName = "TOTAL_BOX"

        ' Init datetimePicker control
        dtp_wo_date_from.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_wo_date_from)

        dtp_wo_date_to.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_wo_date_to)

        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)

        ' Event Binding
        AddHandler txt_pd_qty.Leave, AddressOf ABCDCommon.txt_number_Leave
        AddHandler txt_total_box.Leave, AddressOf ABCDCommon.txt_number_Leave
        AddHandler txt_pd_qty.Enter, AddressOf ABCDCommon.txt_number_Enter
        AddHandler txt_total_box.Enter, AddressOf ABCDCommon.txt_number_Enter
    End Sub

#End Region

#Region "Event Form."

    Private Sub txt_number_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pd_qty.KeyPress, txt_total_box.KeyPress
        If Microsoft.VisualBasic.Asc(e.KeyChar) < 48 _
        Or Microsoft.VisualBasic.Asc(e.KeyChar) > 57 Then
            e.Handled = True
        End If
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        Call ClearScreen()
    End Sub

    Private Sub btn_popup_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_item.Click
        Dim scrPos001 As New frm_POS001(Me)
        scrPos001.ShowDialog()
        txt_item_cd.Focus()
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click

        Dim itemCd As String = txt_item_cd.Text
        Dim woNo As String = txt_wo_no.Text
        Dim woDateFrom As Date = Date.MinValue
        If Not dtp_wo_date_from.CustomFormat = " " Then
            woDateFrom = dtp_wo_date_from.Value.Date
        End If
        Dim woDateTo As Date = Date.MinValue
        If Not dtp_wo_date_to.CustomFormat = " " Then
            woDateTo = dtp_wo_date_to.Value.Date
        End If
        Dim productQuantity As Integer = -1
        If Not String.IsNullOrEmpty(Trim(txt_pd_qty.Text)) Then
            Integer.TryParse(txt_pd_qty.Text, Globalization.NumberStyles.AllowThousands, Nothing, productQuantity)
        End If
        Dim totalBox As Integer = -1
        If Not String.IsNullOrEmpty(Trim(txt_total_box.Text)) Then
            Integer.TryParse(txt_total_box.Text, Globalization.NumberStyles.AllowThousands, Nothing, totalBox)
        End If
        Dim loginCode As String = ABCDCommon.UserId
        Call ResultSearch(grd_pd_info, _
                          itemCd, _
                          woNo, _
                          woDateFrom, _
                          woDateTo, _
                          productQuantity, _
                          totalBox, _
                          loginCode)
    End Sub

    Private Sub grd_pd_info_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_pd_info.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
            Exit Sub
        End If

        If e.ColumnIndex = 0 Then
            If TypeOf parentForm Is frm_PRS001 Then
                CType(parentForm, frm_PRS001).tb_wo_no.Text = grd_pd_info.Rows(e.RowIndex).Cells(1).Value.ToString
                CType(parentForm, frm_PRS001).dtp_wo_date.Value = grd_pd_info.Rows(e.RowIndex).Cells(2).Value
            End If
            Me.Close()
        End If
    End Sub

    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_wo_date_from.ValueChanged, dtp_wo_date_to.ValueChanged
        ABCDCommon.ChangeDateTimePicker(sender)
    End Sub

    Private Sub txt_item_cd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_item_cd.Leave
        txt_item_cd.Text = Trim(txt_item_cd.Text)
        If Not String.IsNullOrEmpty(txt_item_cd.Text) Then
            Dim resultItem = wbService.GetItemInfoByCd(txt_item_cd.Text, ABCDCommon.UserId)
            If IsNothing(resultItem) OrElse resultItem.Tables(0).Rows.Count = 0 Then
                txt_item_name.Text = String.Empty
            Else
                Dim itemName As String = Trim(resultItem.Tables(0).Rows(0)("ITEM_NM").ToString)
                txt_item_name.Text = itemName
            End If
        Else
            txt_item_name.Text = String.Empty
        End If
    End Sub

#End Region

#Region "Fucntion Form."

    Private Sub ClearScreen()
        '' Clear all textbox.
        txt_wo_no.Clear()
        txt_item_cd.Clear()
        txt_item_name.Clear()
        dtp_wo_date_from.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_wo_date_from)
        dtp_wo_date_to.Value = DateTime.Now
        ABCDCommon.InitDateTimePicker(dtp_wo_date_to)
        txt_pd_qty.Clear()
        txt_total_box.Clear()
        '' Clear gridview.
        grd_pd_info.DataSource = Nothing
    End Sub

    Private Sub ResultSearch(ByVal dgv As DataGridView, _
                             ByVal itemCodeCondition As String, _
                             ByVal woNoCondition As String, _
                             ByVal woDateFromCondition As Date, _
                             ByVal woDateToCondition As Date, _
                             ByVal productQuantityCondition As Integer, _
                             ByVal totalBoxCondition As Integer, _
                             ByVal loginCode As String)
        Dim ds As DataSet = wbService.GetWOInfoList(itemCodeCondition, _
                                                  woNoCondition, _
                                                  woDateFromCondition, _
                                                  woDateToCondition, _
                                                  productQuantityCondition, _
                                                  totalBoxCondition, _
                                                  2, _
                                                  loginCode)

        dgv.DataSource = ds.Tables(0)
        dgv.Update()
    End Sub
#End Region
End Class