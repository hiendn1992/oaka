Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt

Public Class frm_SHIPFG001 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private frm_Ship2 As frm_SHIPFG002
    Private frm_Ship3 As frm_SHIPFG003
    Private webService As ABCDBC.WebService.Service
    Private shipNo As String = ""
    Private msgListener As MessageListener

#End Region

#Region " CONSTRUCTOR "
    Public Sub New(Optional ByVal ShipNo As String = "")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.shipNo = ShipNo
    End Sub
#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_SHIPFG001_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SHIPFG001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            WriteEventStartLog("frm_SHIPFG001_Load")

            lbl_msg.Text = "Shipment Req No : "
            txt_shipNo.Text = shipNo

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
            WriteEventEndLog("frm_SHIPFG001_Load")
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

            ' show menu form
            BCLoginManager.ShowMenuForm()
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
            WriteEventEndLog("panel_CANCEL_Click")
        End Try
    End Sub

    ''' <summary>
    ''' panel_Ok_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub panel_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_OK.Click
        Try

            WriteEventStartLog("panel_Ok_Click")

            If txt_shipNo.Text.Length = 0 Then
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                ShowMessageForm("MSG162", "Shipment Error")
                ' Create message window instance
                Me.msgListener = New MessageListener(Me)

                txt_shipNo.Focus()
                Exit Sub
            End If

            Dim result As Integer
            webService = New ABCDBC.WebService.Service
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)

            ' Check StocktkReqNoExist
            Dim ds As DataSet = webService.ChkShipReqNoExist(Trim(txt_shipNo.Text), BCLoginManager.GetLoginInfo.UserID)

            ' result
            result = Integer.Parse(ds.Tables(0).Rows(0).Item("RESULT").ToString())

            If result > 0 Then
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                ShowMessageForm("ERR145", "Shipment Error")
                ' Create message window instance
                Me.msgListener = New MessageListener(Me)

                txt_shipNo.Focus()
                Exit Sub
            End If

            frm_Ship2 = New frm_SHIPFG002(Trim(txt_shipNo.Text))
            frm_Ship2.Show()
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
    ''' frm_SHIPFG001_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SHIPFG001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp, txt_shipNo.KeyUp
        If e.KeyCode = Keys.F1 Then

            ' panel_Ok_Click
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