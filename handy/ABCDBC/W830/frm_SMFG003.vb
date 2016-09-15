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
Imports Bt
Imports Microsoft.WindowsCE.Forms
Imports jp.co.ait.ABCDBC.common

Public Class frm_SMFG003 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private smfg005 As frm_SMFG005
    Private smfg004 As frm_SMFG004
    Private smfg003 As frm_SMFG003
    Private smfg002 As frm_SMFG002
    Private smfg001 As frm_SMFG001
    Private rackCd As String = ""
    Private msgListener As MessageListener
    Private barcodeObj As BarcodeObj
    Private webService As ABCDBC.WebService.Service

#End Region

#Region " CONSTRUCTOR "
    Public Sub New(ByVal RackNo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.rackCd = RackNo
    End Sub
#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_SMFG003_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            WriteEventStartLog("frm_SMFG003_Load")
            ' Create message window instance
            Me.msgListener = New MessageListener(Me)
            ' Init barcode Object
            barcodeObj = New BarcodeObj()
            lbl_msg.Text = String.Format(GetMessage("MSG121"), Environment.NewLine)
            lbl_imp_count.Text = BCLoginManager.StockMoveW830Count.ToString()

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
            WriteEventEndLog("frm_SMFG003_Load")
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
                '' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                ShowMessageForm("ERR121", "Stock Move Error ")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If
            '' 2.Check Server
            ' a.
            webService = New ABCDBC.WebService.Service()
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)

            Dim ds As DataSet = webService.ChkStkMvBarcodeExistDestRackNo(barcodeObj.StrCodedata, rackCd, BCLoginManager.GetLoginInfo.UserID)
            ' result
            result = Integer.Parse(ds.Tables(0).Rows(0).Item("RESULT").ToString())

            ' b.
            If result = 0 Then ' check success
                ' get Item Code
                If Not ds.Tables(0).Rows(0).Item("ITEMCODE") Is Nothing Then
                    itemCd = ds.Tables(0).Rows(0).Item("ITEMCODE").ToString()
                End If
                ' get Item Name
                If Not ds.Tables(0).Rows(0).Item("ITEMNAME") Is Nothing Then
                    itemName = ds.Tables(0).Rows(0).Item("ITEMNAME").ToString()
                End If

                '<< 20150228 Phungntm fixed : Not show infomation screen
                ' import barcode
                webService.StockMoveW830(barcodeObj.StrCodedata, itemCd, rackCd, BCLoginManager.GetLoginInfo.UserID)
                BCLoginManager.StockMoveW830Count = BCLoginManager.StockMoveW830Count + 1
                Dim msg As String = String.Format("Stock Move {0} Sucessfully !", Environment.NewLine)
                smfg005 = New frm_SMFG005(msg, rackCd)
                smfg005.Show()
                '>>
                'smfg004 = New frm_SMFG004(barcodeObj.StrCodedata, itemCd, itemName, rackCd)
                'smfg004.Show()
                Me.Close()
            ElseIf result = 1 Then
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR121", "Stock Move Error ")
                Me.Focus()
                msgListener = New MessageListener(Me)
            ElseIf result = 2 Then
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR122", "Stock Move Error ")
                Me.Focus()
                msgListener = New MessageListener(Me)
            ElseIf result = 3 Then
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR124", "Stock Move Error ")
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
            smfg001 = New frm_SMFG001()
            smfg001.Show()
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
    ''' frm_SMFG003_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG003_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            WriteEventStartLog("frm_SMFG003_Closing")
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
            WriteEventEndLog("frm_SMFG003_Closing")
        End Try
    End Sub

    ''' <summary>
    ''' frm_SMFG003_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG003_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = 153 Then ' Keys: Scan
            ' enable scanner
            barcodeObj.ScanEnable()
        ElseIf e.KeyCode = Keys.F2 Then ' Keys: Back
            ' close curren form
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