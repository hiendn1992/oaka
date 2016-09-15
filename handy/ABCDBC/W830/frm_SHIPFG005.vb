Imports jp.co.ait.ABCDBC.common

Public Class frm_SHIPFG005

#Region " VARIABLE / CONSTANT "
    Private message As String = ""
    Private frm_Ship003 As frm_SHIPFG003
    Private frm_Ship002 As frm_SHIPFG002
    Private shipNo As String = ""
    Private palletNo As String = ""
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
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal message As String, ByVal pShipNo As String, ByVal pPalletNo As String)
        ' init
        InitializeComponent()
        '' set params
        Me.message = message
        Me.shipNo = pShipNo
        Me.palletNo = pPalletNo
        Me.lbl_msg.Text = Me.message
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

        frm_Ship003 = New frm_SHIPFG003(shipNo, palletNo)
        frm_Ship003.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' frm_SHIPFG005_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SHIPFG005_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'Free memmory
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' frm_SHIPFG005_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SHIPFG005_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then

            pnl_Action_Click(sender, e)

        ElseIf e.KeyCode = Keys.F3 Then

            pnl_PalletNo_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: Fn


            ' close current form
            Me.Close()

            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub
    ''' <summary>
    ''' pnl_PalletNo_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_PalletNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_PalletNo.Click
        frm_Ship002 = New frm_SHIPFG002(shipNo)
        frm_Ship002.Show()
        Me.Close()
    End Sub

#End Region
    
End Class