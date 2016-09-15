''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_POS002.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-15    1.00     HUNGTG   New
''*********************************************************

Public Class frm_POS002

#Region "Var/Const Form"
    Private ws As New ABCDService.Service
    Private ds As DataSet = Nothing
    Private prtForm As Form
    
#End Region

#Region "New Form"
    ''' <summary>
    ''' Initialize Form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal prtForm As Form)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = ABCDConst.STRING_TIMEOUT

        Me.prtForm = prtForm

        ' Call load data combobox authority.       
        'lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat

        ' Add button datagridview.
        Dim btn As New DataGridViewButtonColumn
        grd_rack_inqry.Columns.Add(btn)
        btn.Text = "Select"
        btn.UseColumnTextForButtonValue = True
        ' Set display datagridview.
        grd_rack_inqry.ColumnCount = 3
        grd_rack_inqry.Columns(0).Name = ""
        grd_rack_inqry.Columns(0).Width = 75
        grd_rack_inqry.Columns(1).Name = "Rack Code"
        grd_rack_inqry.Columns(1).Width = 200
        grd_rack_inqry.Columns(2).Name = "Rack Name"
        grd_rack_inqry.Columns(2).Width = 375
        grd_rack_inqry.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'Set full row selection for gridview
        grd_rack_inqry.SelectionMode = DataGridViewSelectionMode.FullRowSelect

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
        txt_rack_code.Text = ""
        txt_rack_name.Text = ""
        grd_rack_inqry.Rows.Clear()
    End Sub
    ''' <summary>
    ''' Event click button Search.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        grd_rack_inqry.Rows.Clear()
        Try
            ds = ws.RackInquiry(txt_rack_code.Text, _
                                                    txt_rack_name.Text, _
                                                    ABCDCommon.UserId)
            If ds.Tables(0).Rows.Count = 0 Then
                Dim frm As New frm_MSG001(ABCD.My.Resources.Messages.ERR010, "ERR010")
                frm.ShowDialog()
                Return
            End If
            ' Get data for gridview.
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 1
                Dim arr(3) As String
                arr(0) = ""
                arr(1) = ds.Tables(0).Rows(i)("RACK_CD").ToString
                arr(2) = ds.Tables(0).Rows(i)("RACK_NM").ToString
                grd_rack_inqry.Rows.Add(arr)
            Next
        Catch ex As Exception
            ds.Dispose()
            Dim frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
            ds.Dispose()
        End Try
    End Sub
    ''' <summary>
    ''' Event click button Select.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grd_rack_inqry_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_rack_inqry.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            If TypeOf Me.prtForm Is frm_MSS004 Then
                CType(Me.prtForm, frm_MSS004).txt_rack_code.Text = Trim(grd_rack_inqry.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_MSS004).txt_rack_name.Text = Trim(grd_rack_inqry.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If
            If TypeOf Me.prtForm Is frm_WHS002 Then
                CType(Me.prtForm, frm_WHS002).txt_rack_code.Text = Trim(grd_rack_inqry.Rows(e.RowIndex).Cells(1).Value.ToString)
                CType(Me.prtForm, frm_WHS002).txt_rack_name.Text = Trim(grd_rack_inqry.Rows(e.RowIndex).Cells(2).Value.ToString)
                Me.Close()
                Return
            End If
        End If
    End Sub
#End Region

#Region "Function form"
#End Region

End Class