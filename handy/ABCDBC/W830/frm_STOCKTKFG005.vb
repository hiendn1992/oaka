Imports jp.co.ait.ABCDBC.common

Public Class frm_STOCKTKFG005

#Region " VARIABLE / CONSTANT "
    Private stockReqNo As String = ""
    Private rackNo As String = ""
    Private stkFG004 As frm_STOCKTKFG004
    Private stkFG002 As frm_STOCKTKFG002
#End Region

#Region " CONSTRUCTOR "

    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    Public Sub New()
        ' この呼び出しは、Windows ﾌｫｰﾑ ﾃﾞｻﾞｲﾅで必要です
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Constructor with params
    ''' </summary>
    ''' <param name="pStockReqNo"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal pRackNo As String, ByVal pStockReqNo As String)
        ' init
        InitializeComponent()
        '' set params
        Me.stockReqNo = pStockReqNo
        Me.rackNo = pRackNo
        Me.lbl_msg.Text = "Scan " & vbCrLf & "Successfully !"
        Me.lbl_msg.TextAlign = ContentAlignment.TopCenter
    End Sub

#End Region

#Region " MENTHODS "


    ''' <summary>
    ''' pnl_Action_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Continue.Click

        stkFG004 = New frm_STOCKTKFG004(rackNo, stockReqNo)
        stkFG004.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' frm_STOCKTKFG005_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTKFG005_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'Free memmory
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' frm_STOCKTKFG004_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTKFG005_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then

            pnl_Action_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: Fn

            ' close current form
            Me.Close()

            ' show menu form
            BCLoginManager.ShowMenuForm()
        ElseIf e.KeyCode = Keys.F3 Then

            Me.Close()
            stkFG002 = New frm_STOCKTKFG002(stockReqNo)
            stkFG002.Show()
        End If
    End Sub

    ''' <summary>
    ''' pnl_RackNo_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_RackNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_RackNo.Click

        stkFG002 = New frm_STOCKTKFG002(stockReqNo)
        stkFG002.Show()
        Me.Close()
    End Sub

#End Region
    
End Class