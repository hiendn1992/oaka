Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt
Imports jp.co.ait.ABCDBC.WebService

''' <summary>
''' #No.23: add new method return W900 [cuongtk (20150825)]
''' Screen: Return W900
''' Class: ReturnW900.vb
''' </summary>
''' <remarks></remarks>
Public Class ReturnW900

    Private barcodeObj As BarcodeObj
    Private msgListener As MessageListener
    Private webService As Service

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        webService = New Service
        msgListener = New MessageListener(Me)
        barcodeObj = New BarcodeObj
    End Sub

    Private Sub panel_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            WriteEventStartLog("panel_Return_Click")
            Me.Close()
            BCLoginManager.ShowMenuForm()
        Catch ex As Exception
            WriteErrorLog(ex)
            msgListener.Dispose()
            ShowSystemMessageForm()
        Finally
            WriteEventEndLog("panel_Return_Click")
        End Try
    End Sub

    Private Sub ReturnW900_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            WriteEventStartLog("ReturnW900_Load")
            lbl_msg.Text = String.Format(GetMessage("MSG121"), Environment.NewLine)
            lbl_return_count.Text = BCLoginManager.ReturnW900Count.ToString
        Catch ex As Exception
            WriteErrorLog(ex)
            msgListener.Dispose()
            ShowSystemMessageForm()
        Finally
            WriteEventEndLog("ReturnW900_Load")
        End Try
    End Sub

    Private Sub ReturnW900_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            WriteEventStartLog("ReturnW900_Closing")
            msgListener.Dispose()
            Me.Dispose()
        Catch ex As Exception
            WriteErrorLog(ex)
            msgListener.Dispose()
            ShowSystemMessageForm()
        Finally
            WriteEventEndLog("ReturnW900_Closing")
        End Try
    End Sub

    Private Sub ReturnW900_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = 153 Then
            barcodeObj.ScanEnable()
        ElseIf e.KeyCode = Keys.F2 Then
            Call panel_Return_Click(sender, e)
        ElseIf e.KeyCode = 137 Then
            Me.Close()
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

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

    Private Sub exeBarcodeInput()
        Try
            WriteEventStartLog("exeBarcodeInput")
            Dim scanBarcode As String = barcodeObj.StrCodedata
            Dim message As String = String.Empty
            ' 1. Check data on Client
            If scanBarcode.Length <> 14 Then
                msgListener.Dispose()
                ShowMessageForm("ERR121", "Return W900 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If
            ' 2. Check data on Server
            webService.Url = BCCommon.GetWebHttpURL
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)
            Dim errorCode As String = webService.CheckDataIsValidToReturnW900(scanBarcode, BCLoginManager.GetLoginInfo.UserID)
            If "ERR192".Equals(errorCode) Then '// Barcode is shipment not return W900
                msgListener.Dispose()
                ShowMessageForm("ERR192", "Return W900 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If
            If "ERR193".Equals(errorCode) Then '// Barcode is exits in W900 WH
                msgListener.Dispose()
                ShowMessageForm("ERR193", "Return W900 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If
            If "ERR194".Equals(errorCode) Then '// Barcode is exits in MOLD WH
                msgListener.Dispose()
                ShowMessageForm("ERR194", "Return W900 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If
            '// Not errorCode and Import success
            BCLoginManager.ReturnW900Count = BCLoginManager.ReturnW900Count + 1
            Dim returnW900Ok As New ReturnW900OK
            returnW900Ok.Show()
            Me.Close()
        Catch ex As Exception
            WriteErrorLog(ex)
            msgListener.Dispose()
            ShowSystemMessageForm()
        Finally
            WriteEventEndLog("exeBarcodeInput")
        End Try
    End Sub

End Class