Imports jp.co.ait.ABCDBC.common

Public Class frm_STOCKTK003

#Region " VARIABLE / CONSTANT "
    Private barCode As String
    Private itemCode As String
    Private itemName As String
    Private stockReqNo As String
    Private frm_stock004 As frm_STOCKTK004
    Private frm_stock002 As frm_STOCKTK002
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
                    ByVal pStockReqNo As String)

        InitializeComponent()
        Me.barCode = BarCode
        Me.itemCode = ItemCode
        Me.itemName = ItemName
        Me.stockReqNo = pStockReqNo
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
    End Sub

    ''' <summary>
    ''' pnl_Return_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Return.Click

        frm_stock002 = New frm_STOCKTK002(stockReqNo)
        frm_stock002.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' pnl_STOCKTK003_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_STOCKTK003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Export.Click
        Try
            WriteEventStartLog("pnl_STOCKTK003_Click")
            webService = New ABCDBC.WebService.Service
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)

            ' import barcode
            BCLoginManager.ExportW900Count = BCLoginManager.StocktakingW900Count + 1
            Dim message As String = String.Format("Stocktaking {0} Sucessfully !", Environment.NewLine)
            frm_stock004 = New frm_STOCKTK004(message)
            frm_stock004.Show()
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
            WriteEventEndLog("pnl_STOCKTK003_Click")
        End Try
    End Sub

    ''' <summary>
    ''' frm_STOCKTK003_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTK003_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not webService Is Nothing Then
            webService.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' frm_STOCKTK003_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTK003_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F2 Then

            ' close current form
            pnl_Return_Click(sender, e)
        ElseIf e.KeyCode = Keys.F1 Then

            pnl_STOCKTK003_Click(sender, e)
        ElseIf e.KeyCode = Keys.F1 Then ' Keys: Fn

            ' close current form
            Me.Close()

            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub
#End Region

End Class