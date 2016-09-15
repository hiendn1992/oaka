''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_POS001.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_POS001

#Region "Var/Const Form"

    Private wbService As New ABCDService.Service

    Private colNames As New List(Of String)(New String() {"", "Item Code", "Item Name", "Current SEQ", "Quantity", "Unit", "Template", "Orotex No"})
    Private colSizes As New List(Of Integer)(New Integer() {73, 210, 420, 110, 110, 50, 130, 97})
    Private colNameDB As New List(Of String)(New String() {"", "ITEM_CD", "ITEM_NM", "CUR_BOX_NUM", "QTY", "UNIT", "TEMP_TYPE", "OROTEX_NO"})

    Private prtForm As Form
    Private vlWhere As String

#End Region

#Region "New Form"

    Public Sub New(ByVal prtForm As Form)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.prtForm = prtForm
        'lb_today.Text = ABCDCommon.GetSystemDateWithFormat

        Dim button As New DataGridViewButtonColumn
        dgv_lst_item.Columns.Add(button)
        dgv_lst_item.Columns(0).Width = 73
        button.Text = "Select"
        button.UseColumnTextForButtonValue = True

        Call ABCDCommon.CreateColumnsInGridView(dgv_lst_item, colNames, colSizes)
        Call ABCDCommon.SetReadOnlyForDataGridView(dgv_lst_item, colNames)
        dgv_lst_item.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_lst_item.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        dgv_lst_item.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

    Public Sub New(ByVal prtForm As Form, ByVal valueWhere As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.prtForm = prtForm
        Me.vlWhere = valueWhere

        'lb_today.Text = ABCDCommon.GetSystemDateWithFormat

        Dim button As New DataGridViewButtonColumn
        dgv_lst_item.Columns.Add(button)
        dgv_lst_item.Columns(0).Width = 73
        button.Text = "Select"
        button.UseColumnTextForButtonValue = True

        Call ABCDCommon.CreateColumnsInGridView(dgv_lst_item, colNames, colSizes)
        Call ABCDCommon.SetReadOnlyForDataGridView(dgv_lst_item, colNames)
        dgv_lst_item.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Event click search data form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_search_Click(sender As System.Object, e As System.EventArgs) Handles b_search.Click
        Dim customerCode As String = tb_cus_id.Text
        Dim itemCode As String = tb_item_code.Text
        Dim itemName As String = tb_item_name.Text
        Dim quantity As Integer = 0
        If Not tb_quantity.Text.Equals("") Then
            quantity = Integer.Parse(tb_quantity.Text.Replace(",", ""))
        End If
        Dim loginCode As String = ABCDCommon.UserId
        '' Get data from web service.
        Dim ds As DataSet = wbService.ItemInquiry(itemCode, "", itemName, customerCode, "", quantity, loginCode)
        '' Delete all data display on gridview.
        dgv_lst_item.Rows.Clear()
        If ds.Tables(0).Rows.Count = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR010, "ERR010")
            frmMsg001.ShowDialog()
            tb_item_code.Focus()
            tb_item_code.SelectAll()
            Return
        End If
        Call ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, dgv_lst_item, ABCDConst.GRIDVIEW_BUTTON)
        '' Config format current_box, quantity.
        For i As Integer = 0 To dgv_lst_item.Rows.Count - 1 Step 1
            dgv_lst_item.Rows(i).Cells("Quantity").Value = Integer.Parse(dgv_lst_item.Rows(i).Cells("Quantity").Value).ToString(ABCDConst.Format_Number)
            dgv_lst_item.Rows(i).Cells("Unit").Value = ConvertIntToString01(Integer.Parse(dgv_lst_item.Rows(i).Cells("Unit").Value))
            dgv_lst_item.Rows(i).Cells("Template").Value = ConvertIntToString02(Integer.Parse(dgv_lst_item.Rows(i).Cells("Template").Value))
        Next
    End Sub

    ''' <summary>
    ''' Event click cancel value form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(sender As System.Object, e As System.EventArgs) Handles b_cancel.Click
        tb_cus_id.Text = Nothing
        tb_cus_nm.Text = Nothing
        tb_item_code.Text = Nothing
        tb_item_name.Text = Nothing
        tb_quantity.Text = Nothing
        dgv_lst_item.Rows.Clear()
    End Sub

    ''' <summary>
    ''' Event click exit form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(sender As System.Object, e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Event click cell on gridview.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_lst_item_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_lst_item.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            If TypeOf Me.prtForm Is SHS004 Then
                CType(Me.prtForm, SHS004).ItemCode.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, SHS004).ItemName.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Exit Sub
            End If

            If TypeOf Me.prtForm Is frm_MSS003 Then
                CType(Me.prtForm, frm_MSS003).tb_item_code.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                Me.Close()
                Return
            ElseIf TypeOf ParentForm Is frm_PRS002 Then
                CType(ParentForm, frm_PRS002).txt_item_code.Text = dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString
                CType(ParentForm, frm_PRS002).txt_item_name.Text = dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString
                Return
            End If

            If TypeOf Me.prtForm Is frm_MSS007 Then
                Select Case Me.vlWhere
                    Case ABCDConst.MSS007_FROM
                        CType(Me.prtForm, frm_MSS007).tb_item_code_from.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                        CType(Me.prtForm, frm_MSS007).tb_item_name_from.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                        Me.Close()
                        Return
                    Case ABCDConst.MSS007_TO
                        CType(Me.prtForm, frm_MSS007).tb_item_code_to.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                        CType(Me.prtForm, frm_MSS007).tb_item_name_to.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                        Me.Close()
                        Return
                End Select
            End If

            If TypeOf Me.prtForm Is frm_PRS001 Then
                CType(Me.prtForm, frm_PRS001).tb_item_code.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_PRS001).tb_item_name.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                If CType(Me.prtForm, frm_PRS001).tb_quantity_box.Text.Equals("") Or CType(Me.prtForm, frm_PRS001).tb_quantity_box.Text.Equals("0") Then
                    CType(Me.prtForm, frm_PRS001).tb_quantity_box.Text = Integer.Parse(Trim(dgv_lst_item.Rows(e.RowIndex).Cells(4).Value.ToString).Replace(",", "")).ToString(ABCDConst.Format_Number)
                End If
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_PRS002 Then
                CType(Me.prtForm, frm_PRS002).txt_item_code.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_PRS002).txt_item_name.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_SHS003 Then
                CType(Me.prtForm, frm_SHS003).tb_item_code.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_SHS003).tb_item_name.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_STS001 Then
                CType(Me.prtForm, frm_STS001).tb_item_code.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_STS001).tb_item_name.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_WHS003 Then
                CType(Me.prtForm, frm_WHS003).ItemCode.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_WHS003).ItemName.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If
            If TypeOf Me.prtForm Is frm_WHS002 Then
                CType(Me.prtForm, frm_WHS002).txt_item_code.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_WHS002).txt_item_name.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_POS006 Then
                CType(Me.prtForm, frm_POS006).txt_item_cd.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_POS006).txt_item_name.Text = Trim(dgv_lst_item.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If
        End If
    End Sub

    ''' <summary>
    ''' Event click popup customer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_popup_cus_Click(sender As System.Object, e As System.EventArgs) Handles b_popup_cus.Click
        Dim scrPos005 As New frm_POS005(Me)
        scrPos005.ShowDialog()
        tb_quantity.Focus()
    End Sub

    ''' <summary>
    ''' Event leave quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_quantity.Leave
        If Not tb_quantity.Text.Equals("") Then
            tb_quantity.Text = Integer.Parse(tb_quantity.Text).ToString(ABCDConst.Format_Number)
            If tb_quantity.Text.Equals("") Then
                tb_quantity.Text = "0"
            End If
        Else
            tb_quantity.Text = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Event mouse move quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tb_quantity.MouseClick
        tb_quantity.Text = tb_quantity.Text.Replace(",", "")
        tb_quantity.SelectAll()
    End Sub

    ''' <summary>
    ''' Event keypress quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_quantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_quantity.KeyPress
        Call ABCDCommon.InputNumberFromKeyboard(e)
    End Sub

    ''' <summary>
    ''' Leave customer (customer code).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.Leave
        Dim ds As DataSet = Nothing
        ds = wbService.GetCustomerInfoByID(tb_cus_id.Text, ABCDCommon.UserId)
        If ds.Tables(0).Rows.Count > 0 Then
            tb_cus_nm.Text = ds.Tables(0).Rows(0)("CUS_NM").ToString
        Else
            tb_cus_nm.Text = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Changed customer (customer code).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_cus_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cus_id.TextChanged
        tb_cus_nm.Text = Nothing
    End Sub

#End Region

#Region "Function Form"

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

#End Region

End Class