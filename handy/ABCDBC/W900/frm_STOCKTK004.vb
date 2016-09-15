Imports jp.co.ait.ABCDBC.common

Public Class frm_STOCKTK004

#Region " VARIABLE / CONSTANT "
    Private stockReqNo As String = ""
    Private frm_stock002 As frm_STOCKTK002
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
    Public Sub New(ByVal pStockReqNo As String)
        ' init
        InitializeComponent()
        '' set params
        Me.stockReqNo = pStockReqNo
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

        frm_stock002 = New frm_STOCKTK002(stockReqNo)
        frm_stock002.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' frm_STOCKTK004_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTK004_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'Free memmory
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' frm_STOCKTK004_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTK004_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then

            pnl_Action_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: Fn

            ' close current form
            Me.Close()

            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

#End Region

End Class