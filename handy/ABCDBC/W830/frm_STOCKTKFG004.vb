Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt

Public Class frm_STOCKTKFG004 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private stkFG001 As frm_STOCKTKFG001
    Private stkFG002 As frm_STOCKTKFG002
    Private stkFG005 As frm_STOCKTKFG005
    Private msgListener As MessageListener
    Private barcodeObj As BarcodeObj
    Private webService As ABCDBC.WebService.Service
    Private rackNo As String = ""
    Private stkReqNo As String = ""

#End Region

#Region " CONSTRUCTOR "
    Public Sub New(ByVal pRackNo As String, ByVal pStkReqNo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.rackNo = pRackNo
        Me.stkReqNo = pStkReqNo
    End Sub
#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_STOCKTKFG004_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTKFG004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            WriteEventStartLog("frm_STOCKTKFG004_Load")

            ' Create message window instance
            Me.msgListener = New MessageListener(Me)

            ' Init barcode Object
            barcodeObj = New BarcodeObj()
            lbl_imp_count.Text = BCLoginManager.StocktakingW830Count.ToString()
            lbl_msg.Text = String.Format(GetMessage("MSG121"), Environment.NewLine)
            lbl_stocktk_req_no.Text = stkReqNo

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
            WriteEventEndLog("frm_STOCKTKFG004_Load")
        End Try
    End Sub

    ''' <summary>
    ''' exeBarcodeInput
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub exeBarcodeInput()
        Try
            WriteEventStartLog("exeBarcodeInput")
            Dim message As String
            Dim result As Integer
            Dim itemCd As String = Nothing
            Dim itemName As String = Nothing

            ' 1.Check Client
            '' a. Check barcode length

            If barcodeObj.StrCodedata.Length <> 14 Then

                message = String.Format("Invalid {0} Barcode !", Environment.NewLine)

                ' Disable Scanner
                'barcodeObj.ScanDisable()
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                ShowMessageForm("ERR121", "Stocktaking  W830  Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If

            '' 2.Check Server
            ' a.

            webService = New ABCDBC.WebService.Service()
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)
            Dim ds As DataSet = webService.ChkStockFGValidBarcode(barcodeObj.StrCodedata, BCLoginManager.GetLoginInfo.UserID)

            ' result
            result = Integer.Parse(ds.Tables(0).Rows(0).Item("RESULT").ToString())

            ' b.
            If result = 0 Then ' check success

                webService.StocktakingBarcodeFG(barcodeObj.StrCodedata, BCLoginManager.GetLoginInfo.UserID, rackNo)
                BCLoginManager.StocktakingW830Count = BCLoginManager.StocktakingW830Count + 1
                stkFG005 = New frm_STOCKTKFG005(rackNo, stkReqNo)
                stkFG005.Show()
                Me.Close()
            ElseIf result = 1 Then

                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR122", "Stocktaking  W830  Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
            End If
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

            WriteEventEndLog("exeBarcodeInput")
        End Try
    End Sub

    ''' <summary>
    ''' Respond when press key
    ''' </summary>
    ''' <param name="HWnd"></param>
    ''' <param name="LParam"></param>
    ''' <param name="Msg"></param>
    ''' <param name="Result"></param>
    ''' <param name="WParam"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RespondToMessage(ByRef HWnd As System.IntPtr, ByRef LParam As System.IntPtr, ByVal Msg As Integer, ByVal Result As System.IntPtr, ByVal WParam As System.IntPtr)
        MyBase.RespondToMessage(HWnd, LParam, Msg, Result, WParam)
        Select Case Msg

            ' Press scan button
            Case CType(LibDef.WM_BT_SCAN, Int32)

                ' When reading is successful
                If WParam.ToInt32() = CType(LibDef.BTMSG_WPARAM.WP_SCN_SUCCESS, Int32) Then

                    ' get barcode data
                    barcodeObj.ScanData()

                    ' execute
                    exeBarcodeInput()
                End If
                Exit Select
        End Select
    End Sub

    ''' <summary>
    ''' panel_Return_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub panel_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_RETURN.Click
        Try
            WriteEventStartLog("panel_Return_Click")
            Me.Close()

            ' show menu form
            'BCLoginManager.ShowMenuForm()
            stkFG002 = New frm_STOCKTKFG002(stkReqNo)
            stkFG002.Show()
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
            WriteEventEndLog("panel_Return_Click")
        End Try
    End Sub

    ''' <summary>
    ''' frm_STOCKTKFG002_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTKFG002_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            WriteEventStartLog("frm_STOCKTKFG002_Closing")

            ' Free memmory
            'barcodeObj.ScanDisable()
            ' Dispose listener
            If Not Me.msgListener Is Nothing Then
                Me.msgListener.Dispose()
            End If
            Me.Dispose()
        Catch ex As Exception

            ' Write log
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
            WriteEventEndLog("frm_STOCKTKFG002_Closing")
        End Try
    End Sub

    ''' <summary>
    ''' frm_STOCKTK002_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTK002_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = 153 Then

            ' enable scanner
            barcodeObj.ScanEnable()
        ElseIf e.KeyCode = Keys.F2 Then

            panel_Return_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: FN
            ' close current form
            Me.Close()
            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub
#End Region

End Class