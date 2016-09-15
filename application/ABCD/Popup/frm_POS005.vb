''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_POS005.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   06-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_POS005

#Region "Var/Const Form"

    ''' <summary> Web service. </summary>
    Private wbService As New ABCDService.Service
    ''' <summary> Gridview: column name, column size, column DB. </summary>
    Private colNames As New List(Of String)(New String() {"", "Customer Id", "Customer Name", "Email", "Tel No", "Fax No", "Address", "Destination"})
    Private colSizes As New List(Of Integer)(New Integer() {73, 100, 130, 110, 110, 110, 117, 90})
    Private colNameDB As New List(Of String)(New String() {"", "CUS_ID", "CUS_NM", "MAIL_ADD", "TEL_NO", "FAX_NO", "ADDRESS", "DEST"})
    ''' <summary> Parent form. </summary>
    Private prtForm As Form

#End Region

#Region "New Form"

    ''' <summary>
    ''' New form.
    ''' </summary>
    ''' <param name="prtForm"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal prtForm As Form)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.prtForm = prtForm
        'lb_today.Text = ABCDCommon.GetSystemDateWithFormat

        Dim button As New DataGridViewButtonColumn
        dgv_lst_cus.Columns.Add(button)
        dgv_lst_cus.Columns(0).Width = 73
        button.Text = "Select"
        button.UseColumnTextForButtonValue = True
        '' Load combo box destination.
        cb_dest.DataSource = wbService.GetCodeMasterMS(ABCDConst.Type_Destination, ABCDCommon.UserId).Tables(0)
        cb_dest.DisplayMember = "CODE_NAME"
        cb_dest.ValueMember = "CODE_02"
        '' Create grid view.
        Call ABCDCommon.CreateColumnsInGridView(dgv_lst_cus, colNames, colSizes)
        Call ABCDCommon.SetReadOnlyForDataGridView(dgv_lst_cus, colNames)
        '' Config web service: url and time-out.
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        dgv_lst_cus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Event click search data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_search_Click(sender As System.Object, e As System.EventArgs) Handles b_search.Click
        Dim customerCode As String = tb_cus_id.Text
        Dim customerName As String = tb_cus_name.Text
        Dim customerDestination As Integer = cb_dest.SelectedValue
        Dim customerTelNo As String = tb_tel_no.Text
        Dim customerAddress As String = tb_address.Text
        Dim loginCode As String = ABCDCommon.UserId
        '' Get data from web service.
        Dim ds As DataSet = wbService.CustomerInquiry(customerCode, customerName, customerTelNo, customerAddress, "", customerDestination, loginCode)
        dgv_lst_cus.Rows.Clear()
        If ds.Tables(0).Rows.Count = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR010, "ERR010")
            frmMsg001.ShowDialog()
            tb_cus_id.Focus()
            Return
        End If
        Call ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, dgv_lst_cus, ABCDConst.GRIDVIEW_BUTTON)
    End Sub

    ''' <summary>
    ''' Event click cancel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(sender As System.Object, e As System.EventArgs) Handles b_cancel.Click
        tb_cus_id.Text = Nothing
        tb_cus_name.Text = Nothing
        tb_tel_no.Text = Nothing
        tb_address.Text = Nothing
        cb_dest.SelectedValue = 0
        dgv_lst_cus.Rows.Clear()
    End Sub

    ''' <summary>
    ''' Event click exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(sender As System.Object, e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Event click cell on grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_lst_cus_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_lst_cus.CellClick
        '' Click on header gridview.
        If e.RowIndex < 0 Then
            Return
        End If
        '' Click button select.
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            If TypeOf Me.prtForm Is frm_MSS005 Then '' Return value for form MSS005.
                CType(Me.prtForm, frm_MSS005).tb_cus_id.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(1).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_MSS003 Then '' Return value for form MSS003.
                CType(Me.prtForm, frm_MSS003).tb_cus_id.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_MSS003).tb_cus_name.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_MSS007 Then '' Return value for form MSS007.
                CType(Me.prtForm, frm_MSS007).tb_cus_id.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_MSS007).tb_cus_nm.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_POS001 Then '' Return value for form POS001.
                CType(Me.prtForm, frm_POS001).tb_cus_id.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_POS001).tb_cus_nm.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_SHS001 Then '' Return value for form SHS001.
                CType(Me.prtForm, frm_SHS001).txt_customer_cd.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_SHS001).txt_customer_name.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_POS007 Then '' Return value for form POS007.
                CType(Me.prtForm, frm_POS007).txt_cus_id.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_POS007).txt_cus_name.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

            If TypeOf Me.prtForm Is frm_SHS006 Then
                CType(Me.prtForm, frm_SHS006).txt_cus_id.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_SHS006).txt_cus_name.Text = Trim(dgv_lst_cus.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If

        End If
    End Sub

#End Region

#Region "Function Form"

#End Region

End Class