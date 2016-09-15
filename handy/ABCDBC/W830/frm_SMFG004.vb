Imports jp.co.ait.ABCDBC.common

''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* システム名：ABCDCommon
''* クラス名  ：
''* 処理概要  ：
''*********************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1 14/12/15 1.00  AIT)cuongnc     New
#End Region
''*********************************************************
Public Class frm_SMFG004

#Region " VARIABLE / CONSTANT "
    Private barCode As String = ""
    Private itemCode As String = ""
    Private itemName As String = ""
    Private rackCd As String = ""
    Private smfg003 As frm_SMFG003
    Private smfg005 As frm_SMFG005
    Private smfg001 As frm_SMFG001
    Private msgListener As MessageListener
    Private webService As ABCDBC.WebService.Service
#End Region

#Region " CONSTRUCTOR "
    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' Constructor with params
    ''' </summary>
    ''' <param name="BarCode"></param>
    ''' <param name="ItemCode"></param>
    ''' <param name="ItemName"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal BarCode As String, _
                   ByVal ItemCode As String, _
                   ByVal ItemName As String, _
                   ByVal RackCd As String)

        InitializeComponent()
        Me.barCode = BarCode
        Me.itemCode = ItemCode
        Me.itemName = ItemName
        Me.rackCd = RackCd
        msgListener = New MessageListener(Me)
    End Sub

#End Region

#Region " MENTHODS "

    ''' <summary>
    ''' frm_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_BCNO.Text = Me.barCode
        lbl_ITEMCD.Text = Me.itemCode
        lbl_ITEMNM.Text = Me.itemName
        lbl_warehouseCd.Text = GetMessage("MSG155", New String() {rackCd})
    End Sub

    ''' <summary>
    ''' pnl_Return_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        smfg003 = New frm_SMFG003(rackCd)
        smfg003.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' pnl_SMFG004_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_SMFG004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imp.Click
        Try
            WriteEventStartLog("pnl_SMFG004_Click")
            webService = New ABCDBC.WebService.Service
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)
            ' import barcode
            webService.StockMoveW830(barCode, itemCode, rackCd, BCLoginManager.GetLoginInfo.UserID)
            BCLoginManager.StockMoveW830Count = BCLoginManager.StockMoveW830Count + 1
            Dim message As String = String.Format("Stock Move {0} Sucessfully !", Environment.NewLine)
            smfg005 = New frm_SMFG005(message, rackCd)
            smfg005.Show()
            Me.Close()
        Catch ex As Exception
            ' write log
            WriteErrorLog(ex)
            ' Dispose listener
            If Not Me.msgListener Is Nothing Then
                Me.msgListener.Dispose()
            End If
            ' show form error system
            ShowSystemMessageForm()
            If Me.msgListener Is Nothing Then
                Me.msgListener = New MessageListener(Me)
            End If
        Finally
            WriteEventEndLog("pnl_SMFG004_Click")
        End Try
    End Sub

    ''' <summary>
    ''' frm_SMFG004_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG004_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not webService Is Nothing Then
            webService.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' frm_SMFG004_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG004_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F2 Then
            ' close curren form
            pnl_Return_Click(sender, e)
        ElseIf e.KeyCode = Keys.F1 Then
            pnl_SMFG004_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: Fn
            ' close current form
            Me.Close()
            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub
#End Region

End Class