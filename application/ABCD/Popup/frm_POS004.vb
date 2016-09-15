''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_POS004.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   07-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_POS004

#Region "Var/Const Form"
    ''' <summary> Web service. </summary>
    Private wbService As New ABCDService.Service
    ''' <summary> Init grid view: column name, column size, column name in DB. </summary>
    Private colNames As New List(Of String)(New String() {"", "User Id", "User Name", "Authority", "Remark", "Password"})
    Private colSizes As New List(Of Integer)(New Integer() {73, 120, 220, 130, 299, 80})
    Private colNameDB As New List(Of String)(New String() {"", "USER_ID", "USER_NM", "AUTHORITY", "REM", "USER_PWD"})
    ''' <summary> Form parent call. </summary>
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
        dgv_list_user.Columns.Add(button)
        dgv_list_user.Columns(0).Width = 73
        button.Text = "Select"
        button.UseColumnTextForButtonValue = True
        '' Load combo box authority.
        cb_authority.DataSource = wbService.GetCodeMasterMS(ABCDConst.Type_Authority, ABCDCommon.UserId).Tables(0)
        cb_authority.DisplayMember = "CODE_NAME"
        cb_authority.ValueMember = "CODE_02"
        '' Create grid view.
        Call ABCDCommon.CreateColumnsInGridView(dgv_list_user, colNames, colSizes)
        Call ABCDCommon.SetReadOnlyForDataGridView(dgv_list_user, colNames)
        dgv_list_user.Columns(5).Visible = False
        '' Config web service: url and time-out.
        wbService.Url = ABCDConst.STRING_URL
        wbService.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        dgv_list_user.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
#End Region

#Region "Event Form"
    ''' <summary>
    ''' Event click search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_search.Click
        Dim userCode As String = tb_user_id.Text
        Dim userRem As String = tb_remark.Text
        Dim userAuth As Integer = cb_authority.SelectedValue
        Dim loginCode As String = ABCDCommon.UserId
        '' Get data from web service.
        Dim ds As DataSet = wbService.UserInquiry(userCode, userRem, userAuth, loginCode)
        '' Clear grid view before load data.
        dgv_list_user.Rows.Clear()
        '' Check num row data get from web service.
        If ds.Tables(0).Rows.Count = 0 Then
            Dim frmMsg001 As New frm_MSG001(Messages.ERR010, "ERR010")
            frmMsg001.ShowDialog()
            Return
        End If
        '' Call method get data on grid view class ABCDCommon.
        Call ABCDCommon.GetDataForDataGridViewByDataSet(colNameDB, ds, dgv_list_user, ABCDConst.GRIDVIEW_BUTTON)
        dgv_list_user.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_list_user.Columns(5).Visible = False
    End Sub

    ''' <summary>
    ''' Event click cancel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_cancel.Click
        tb_user_id.Text = Nothing
        tb_remark.Text = Nothing
        cb_authority.SelectedValue = 0
        dgv_list_user.Rows.Clear()
    End Sub

    ''' <summary>
    ''' Event click exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Event click cell on grid view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_list_user_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_list_user.CellClick
        '' Click header not process.
        If e.RowIndex < 0 Then
            Return
        End If
        '' Clicl button select process.
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            CType(Me.prtForm, frm_MSS001).tb_user_id.Text = dgv_list_user.Rows(e.RowIndex).Cells(1).Value.ToString
            Me.Close()
            Return
        End If
    End Sub
#End Region

#Region "Function Form"

#End Region

End Class