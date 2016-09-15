''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_SHS003.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   15-JAN-15    1.00     CuongTK   New
''*********************************************************


Public Class frm_SHS003

#Region "Var/Const Form"

    Private ws As New ABCDService.Service
    Private loginCode As String = ABCDCommon.UserId

    Private scrParent As Form
    Private colNames As New List(Of String)(New String() {"", "Barcode No", "Lot No", "Rack No", "Warehouse Code", "Item Code", "Quantity"})
    Private colSizes As New List(Of Integer)(New Integer() {60, 130, 180, 86, 160, 210, 87})
    Private colNameDB As New List(Of String)(New String() {"", "BC_NO", "LOT_NO", "RACK_CD", "WH_CD", "ITEM_CD", "QTY"})

    Private dataTable As DataTable = Nothing 'Kaidai 182: Add "RACK NO" in Gridview.
    Private barcode As String = String.Empty
#End Region

#Region "New Form"

    Public Sub New(ByVal scrParent As Form, ByVal barcode As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat
        tb_item_name.ReadOnly = True

        tb_pallet_no.Enabled = False

        b_add.Enabled = False
        b_select_all.Enabled = False
        b_unselect_all.Enabled = False

        Me.barcode = barcode

        Dim checkBox As New DataGridViewCheckBoxColumn
        checkBox.Name = "checkSelect"
        checkBox.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv_shipment_request.Columns.Insert(0, checkBox)

        ABCDCommon.CreateColumnsInGridView(dgv_shipment_request, colNames, colSizes)
        ABCDCommon.SetReadOnlyForDataGridView(dgv_shipment_request, colNames)
        dgv_shipment_request.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Me.scrParent = scrParent
    End Sub

#End Region

#Region "Event Form"

    Private Sub tb_item_code_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_item_code.TextChanged
        tb_item_name.Text = Nothing
    End Sub

    Private Sub tb_item_code_Leave(sender As System.Object, e As System.EventArgs) Handles tb_item_code.Leave
        Dim controls As New List(Of Control)(New Control() {b_pop_item, _
                                                            dgv_shipment_request, _
                                                            b_search, _
                                                            tb_item_name, _
                                                            b_exit})
        Dim focused As Boolean = ABCDCommon.CheckFocusedControls(controls)
        If Not focused Then
            Return
        End If

        If Not LeaveItemCode() Then
            Return
        End If

    End Sub

    Private Sub b_pop_item_Click(sender As System.Object, e As System.EventArgs) Handles b_pop_item.Click
        Dim scrPos001 As New frm_POS001(Me)
        scrPos001.ShowDialog()

        tb_item_code.Focus()
        tb_item_code.SelectAll()
    End Sub

    Private Sub b_search_Click(sender As System.Object, e As System.EventArgs) Handles b_search.Click
        dgv_shipment_request.Rows.Clear()

        If Not LeaveItemCode() Then
            Return
        End If

        Dim itemCode As String = tb_item_code.Text

        Dim ds As DataSet = ws.GetAvaiableBarcodeByItemCd(itemCode, loginCode, barcode)
        Me.dataTable = ds.Tables(0) 'Kaidai 182: Add "RACK NO" in Gridview.

        If ds.Tables(0).Rows.Count > 0 Then
            Call ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, dgv_shipment_request, ABCDConst.GRIDVIEW_CHECKBOX)

            For i As Integer = 0 To dgv_shipment_request.Rows.Count - 1 Step 1
                Dim qtyTmp As Integer = Integer.Parse(dgv_shipment_request.Rows(i).Cells("Quantity").Value)
                dgv_shipment_request.Rows(i).Cells("Quantity").Value = qtyTmp.ToString(ABCDConst.Format_Number)
            Next

            b_add.Enabled = True
            b_select_all.Enabled = True
            b_unselect_all.Enabled = True
            tb_pallet_no.Enabled = True
        Else
            Dim frm As frm_MSG001
            frm = New frm_MSG001(ABCD.My.Resources.Messages.ERR010, "ERR010")
            frm.ShowDialog()
            Exit Sub
        End If
    End Sub

    Private Sub b_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_add.Click
        '
        Dim listQuantity As List(Of String) = ABCDCommon.ReturnListFromDataGridView(dgv_shipment_request, 6)

        If listQuantity.Count = 0 Then
            Me.Close()
            Return
        ElseIf Not ABCDCommon.CheckValueIsNull(lb_pallet_no, tb_pallet_no) Then
            tb_pallet_no.Focus()
            Return
        End If

        Dim quantitySum As String = ProcessNumberToDisplay(listQuantity)
        Dim palletNo As String = tb_pallet_no.Text
        Dim boxSum As String = listQuantity.Count.ToString(ABCDConst.Format_Number)

        Dim scrSHS00301 As New frm_SHS003_01(palletNo, quantitySum, boxSum)
        If scrSHS00301.ShowDialog = Windows.Forms.DialogResult.OK Then
            scrSHS00301.Close()

            If TypeOf scrParent Is frm_SHS001 Then

                Dim listResult As New List(Of Dictionary(Of String, Object))
                Dim rowDict As Dictionary(Of String, Object) = Nothing

                For i As Integer = 0 To Me.dgv_shipment_request.Rows.Count - 1 Step 1 'Kaidai 182: Add "RACK NO" in Gridview.
                    If dgv_shipment_request.Rows(i).Cells(0).Value.ToString.Equals("True") Then
                        '// Add Start Ait)Cuongtk 20160323
                        If i <> 0 And Not "".Equals(barcode) Then
                            barcode = barcode & CChar(",")
                        End If
                        '// Add E n d Ait)Cuongtk 20160323
                        '//20160606 Phungntm start 
                        '//Issue No6: file ABCD-HD_Barcode System Issue_List For Live Run(20160606).xls
                        If i = 0 And Not "".Equals(barcode) Then
                            barcode = barcode & CChar(",")
                        End If
                        '>>
                        '
                        rowDict = New Dictionary(Of String, Object)
                        rowDict.Add(CType(scrParent, frm_SHS001).col_barcode_no.DataPropertyName, _
                                    Me.dgv_shipment_request.Rows(i).Cells(1).Value)
                        '// Add Start Ait)Cuongtk 20160323
                        barcode = barcode & Me.dgv_shipment_request.Rows(i).Cells(1).Value
                        '// Add Start Ait)Cuongtk 20160323
                        rowDict.Add(CType(scrParent, frm_SHS001).col_lot_no.DataPropertyName, _
                                    Me.dgv_shipment_request.Rows(i).Cells(2).Value)
                        rowDict.Add(CType(scrParent, frm_SHS001).col_rack_no.DataPropertyName, _
                                    Me.dgv_shipment_request.Rows(i).Cells(3).Value)
                        rowDict.Add(CType(scrParent, frm_SHS001).col_wh_cd.DataPropertyName, _
                                    Me.dgv_shipment_request.Rows(i).Cells(4).Value)
                        rowDict.Add(CType(scrParent, frm_SHS001).col_quantity.DataPropertyName, _
                                    Me.dgv_shipment_request.Rows(i).Cells(6).Value)
                        listResult.Add(rowDict)
                    End If
                Next

                CType(scrParent, frm_SHS001).AddToGrid(listResult, tb_pallet_no.Text, tb_item_code.Text, tb_item_name.Text)

            End If

            '// Chg Start Ait)Cuongtk 2016/03/23
            'Me.Close()
            tb_item_code.Text = ""
            tb_item_name.Text = ""
            dgv_shipment_request.Rows.Clear()
            tb_pallet_no.Text = ""
            '// Chg E n d Ait)Cuongtk 2016/03/23
        Else
            scrSHS00301.Close()

        End If
    End Sub

    Private Sub b_exit_Click(sender As System.Object, e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    Private Sub b_select_all_Click(sender As System.Object, e As System.EventArgs) Handles b_select_all.Click
        Call ABCDCommon.SelectAllCheckBox(dgv_shipment_request, ABCDConst.SELECTED)
    End Sub

    Private Sub b_unselect_all_Click(sender As System.Object, e As System.EventArgs) Handles b_unselect_all.Click
        Call ABCDCommon.SelectAllCheckBox(dgv_shipment_request, ABCDConst.UN_SELECTED)
    End Sub

    Private Sub tb_pallet_no_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pallet_no.Leave
        tb_pallet_no.Text = Trim(tb_pallet_no.Text)
        b_add.Focus()
    End Sub

#End Region

#Region "Function Form"

    Private Function LeaveItemCode() As Boolean
        Dim itemCode As String = tb_item_code.Text
        Dim ds As New DataSet
        ds = ws.GetItemInfoByCd(itemCode, loginCode)

        If tb_item_code.Text.Equals("") Then
            Dim frm As New frm_MSG001("Please input Item Code!", "ERR047")
            frm.ShowDialog()
            Return False
        End If

        If ds.Tables(0).Rows.Count <> 1 Then
            Dim msgError As String = "Item code does not exist."
            Dim scrError As New frm_MSG001(msgError, "ERR")

            If scrError.ShowDialog = Windows.Forms.DialogResult.OK Then
                scrError.Close()
                tb_item_code.Focus()
                tb_item_code.SelectAll()
                Return False
            End If
        End If

        Dim controls As New List(Of TextBox)(New TextBox() {tb_item_code, tb_item_name})
        Dim colNames As New List(Of String)(New String() {"ITEM_CD", "ITEM_NM"})

        Call ABCDCommon.SetDataForTextBoxByDataSet(controls, colNames, ds)
        Return True
    End Function

    Private Function ProcessNumberToDisplay(ByVal listQuantity As List(Of String)) As String
        Dim total As Integer = 0

        For i As Integer = 0 To listQuantity.Count - 1 Step 1
            total = total + Integer.Parse(listQuantity(i),Globalization.NumberStyles.AllowThousands)
        Next

        Return total.ToString(ABCDConst.Format_Number)
    End Function

#End Region

End Class