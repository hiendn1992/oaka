Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt

Public Class frm_SRFG001 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private frm_Srfg2 As frm_SRFG002
    Private frm_Srfg3 As frm_SRFG003
    Private msgListener As MessageListener
    Private barcodeObj As BarcodeObj
    Private webService As ABCDBC.WebService.Service

#End Region

#Region " CONSTRUCTOR "
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        BCLoginManager.SetRackW830Count = 0

    End Sub
#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_SRFG001_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SRFG001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            WriteEventStartLog("frm_SRFG001_Load")

            ' Create message window instance
            Me.msgListener = New MessageListener(Me)

            ' Init barcode Object
            barcodeObj = New BarcodeObj()
            lbl_msg.Text = String.Format(GetMessage("MSG122"), Environment.NewLine, Environment.NewLine)

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
            WriteEventEndLog("frm_SRFG001_Load")
        End Try
    End Sub

    ''' <summary>
    ''' exeBarcodeInput
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub exeBarcodeInput()
        Try
            WriteEventStartLog("exeBarcodeInput")
            'Dim message As String
            Dim result As Integer = 0

            ' 1.Check Client
            '' a. Check barcode length

            'If barcodeObj.StrCodedata.Length <> 6 Then

            'message = String.Format("Invalid {0} Barcode !", Environment.NewLine)
            ''barcodeObj.ScanDisable()
            'Me.msgListener.Dispose()
            'ShowMessageForm("ERR142", "Set Rack W830 Error")
            'Me.Focus()
            'msgListener = New MessageListener(Me)
            'Exit Sub
            'End If

            '' 2.Check Server
            ' a.
            webService = New ABCDBC.WebService.Service()
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)
            Dim ds As DataSet = webService.ChkRackNoExistProcess(barcodeObj.StrCodedata, BCLoginManager.GetLoginInfo.UserID)

            ' result
            If Not ds.Tables(0).Rows(0).Item("RESULT") Is Nothing AndAlso _
                Not String.IsNullOrEmpty(Trim(ds.Tables(0).Rows(0).Item("RESULT").ToString())) Then

                result = Integer.Parse(ds.Tables(0).Rows(0).Item("RESULT").ToString())

            End If


            ' b.
            If result = 0 Then ' check success

                frm_Srfg2 = New frm_SRFG002(barcodeObj.StrCodedata)
                frm_Srfg2.Show()
                Me.Close()
            ElseIf result = 1 Then

                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR142", "Set Rack W830 Error")
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
            WriteEventEndLog("panel_Return_Click")
        End Try
    End Sub

    ''' <summary>
    ''' frm_SRFG001_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SRFG001_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            WriteEventStartLog("frm_SRFG001_Closing")

            'Free memmory
            'barcodeObj.ScanDisable()
            ' Dispose listener
            If Not Me.msgListener Is Nothing Then
                Me.msgListener.Dispose()
            End If
            Me.Dispose()
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
            WriteEventEndLog("frm_SRFG001_Closing")
        End Try
    End Sub

    ''' <summary>
    ''' frm_SRFG001_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SRFG001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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