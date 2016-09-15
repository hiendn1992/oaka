Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt

Public Class frm_STOCKTK001 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private frm_StockTk002 As frm_STOCKTK002
    Private frm_StockTk003 As frm_STOCKTK003
    Private msgListener As MessageListener
    Private barcodeObj As BarcodeObj
    Private webService As ABCDBC.WebService.Service
    Private stockTkReqNo As String = ""

#End Region

#Region " CONSTRUCTOR "
    Public Sub New(Optional ByVal stockReqNo As String = "")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.stockTkReqNo = stockReqNo
    End Sub
#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_STOCKTK001_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTK001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            WriteEventStartLog("frm_STOCKTK001_Load")

            ' Create message window instance
            Me.msgListener = New MessageListener(Me)

            ' Init barcode Object
            barcodeObj = New BarcodeObj()
            txt_stocktk_req_no.Text = stockTkReqNo
            txt_stocktk_req_no.Focus()

        Catch ex As Exception

            WriteErrorLog(ex)
            ' Dispose listener
            If Not Me.msgListener Is Nothing Then
                Me.msgListener.Dispose()
            End If
            ' Show form error system
            ShowSystemMessageForm()
            If Me.msgListener Is Nothing Then
                Me.msgListener = New MessageListener(Me)
            End If
        Finally
            WriteEventEndLog("frm_STOCKTK001_Load")
        End Try
    End Sub

    ''' <summary>
    ''' panel_CANCEL_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub panel_CANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_CANCEL.Click
        Try

            WriteEventStartLog("panel_CANCEL_Click")
            Me.Close()
            ' Show menu form
            BCLoginManager.ShowMenuForm()
        Catch ex As Exception

            WriteErrorLog(ex)
            ' Dispose listener
            If Not Me.msgListener Is Nothing Then
                Me.msgListener.Dispose()
            End If
            ' Show form error system
            ShowSystemMessageForm()
            If Me.msgListener Is Nothing Then
                Me.msgListener = New MessageListener(Me)
            End If
        Finally
            WriteEventEndLog("panel_CANCEL_Click")
        End Try
    End Sub

    ''' <summary>
    ''' panel_Ok_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub panel_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Ok.Click
        Try

            WriteEventStartLog("panel_Ok_Click")

            If txt_stocktk_req_no.Text.Length = 0 Then
                'barcodeObj.ScanDisable()
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                ShowMessageForm("MSG153", "Stocktaking  W900  Error")
                txt_stocktk_req_no.Focus()
                ' Create message window instance
                Me.msgListener = New MessageListener(Me)

                Exit Sub
            End If

            Dim result As Integer
            webService = New ABCDBC.WebService.Service
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)

            ' Check StocktkReqNoExist
            Dim ds As DataSet = webService.ChkStocktkReqDateExist(Trim(txt_stocktk_req_no.Text), BCLoginManager.GetLoginInfo.UserID)

            ' result
            result = Integer.Parse(ds.Tables(0).Rows(0).Item("RESULT").ToString())

            If result > 0 Then
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR144", "Stocktaking  W900  Error")
                ' Create message window instance
                Me.msgListener = New MessageListener(Me)
                txt_stocktk_req_no.Focus()
                Exit Sub
            End If

            Dim stockTk002 As New frm_STOCKTK002(Trim(txt_stocktk_req_no.Text))
            stockTk002.Show()
            Me.Close()
        Catch ex As Exception

            WriteErrorLog(ex)
            ' Dispose listener
            If Not Me.msgListener Is Nothing Then
                Me.msgListener.Dispose()
            End If
            ' Show form error system
            ShowSystemMessageForm()
            If Me.msgListener Is Nothing Then
                Me.msgListener = New MessageListener(Me)
            End If
        Finally
            WriteEventEndLog("panel_Ok_Click")
        End Try
    End Sub

    ''' <summary>
    ''' frm_STOCKTK001_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTK001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp, txt_stocktk_req_no.KeyUp
        If e.KeyCode = Keys.F1 Then

            panel_Ok_Click(sender, e)
        ElseIf e.KeyCode = Keys.F2 Then

            panel_CANCEL_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: FN
            ' close current form
            Me.Close()
            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

#End Region

End Class