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

Public Class frm_IMPFG001 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private frm_imp001 As frm_IMPFG001
    Private frm_Imp3 As frm_IMPFG003
    Private frm_Imp2 As frm_IMPFG002
    Private msgListener As MessageListener
    Private barcodeObj As BarcodeObj
    Private webService As ABCDBC.WebService.Service
    Private caseImport As String = String.Empty

#End Region

#Region " CONSTRUCTOR "

    Public Property GetCaseImp() As String
        Get
            Return caseImport
        End Get
        Set(ByVal value As String)
            caseImport = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal paramCaseImp As String)
        InitializeComponent()
        GetCaseImp = paramCaseImp
        'If GetCaseImp.Equals("1") Then
        '    BCLoginManager.ImportFGW830Count = 0
        'ElseIf GetCaseImp.Equals("2") Then
        '    BCLoginManager.SubConCount = 0
        'ElseIf GetCaseImp.Equals("3") Then
        '    BCLoginManager.ShipmentReturnCount = 0
        'End If
    End Sub

#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_IMPFG001_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_IMPFG001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            WriteEventStartLog("frm_IMPFG001_Load")
            ' Create message window instance
            Me.msgListener = New MessageListener(Me)
            ' Init barcode Object
            barcodeObj = New BarcodeObj()
            lbl_msg.Text = String.Format(GetMessage("MSG121"), Environment.NewLine)
            If GetCaseImp.Equals("2") Then
                lbl_imp_count.Text = BCLoginManager.SubConCount.ToString()
                lbl_warehouseCd.Text = " From Subcon "
            ElseIf GetCaseImp.Equals("3") Then
                lbl_imp_count.Text = BCLoginManager.ShipmentReturnCount.ToString()
                lbl_warehouseCd.Text = " From Shipment Return"
            ElseIf GetCaseImp.Equals("1") Then
                lbl_imp_count.Text = BCLoginManager.ImportFGW830Count.ToString()
                lbl_warehouseCd.Text = " From W900"
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
            WriteEventEndLog("frm_IMPFG001_Load")
        End Try
    End Sub

    ''' <summary>
    ''' exeBarcodeInput
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub exeBarcodeInput()
        Select Case GetCaseImp
            Case "1"
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
                        'barcodeObj.ScanDisable()
                        ShowMessageForm("ERR121", "Import W830 Error")
                        Me.Focus()
                        msgListener = New MessageListener(Me)
                        Exit Sub
                    End If
                    '' 2.Check Server
                    ' a.
                    webService = New ABCDBC.WebService.Service()
                    webService.Url = BCCommon.GetWebHttpURL()
                    webService.Timeout = BCCommon.GetWebServiceTimeOut(True)

                    Dim ds As DataSet = webService.CheckBarcodeImportFGExistProcess(barcodeObj.StrCodedata, _
                                                                                    GetCaseImp, _
                                                                                    BCLoginManager.GetLoginInfo.UserID)
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

                        '<< 20150226 Phungntm fixed : Not show infomation screen
                        ' import barcode
                        webService.ImportFGBarcodeIntoQC(barcodeObj.StrCodedata, GetCaseImp, BCLoginManager.GetLoginInfo.UserID, itemCd)
                        BCLoginManager.ImportFGW830Count = BCLoginManager.ImportFGW830Count + 1
                        Dim msg As String = String.Format("Import {0} Sucessfully !", Environment.NewLine)
                        frm_Imp3 = New frm_IMPFG003(msg, GetCaseImp)
                        frm_Imp3.Show()
                        'frm_Imp2 = New frm_IMPFG002(barcodeObj.StrCodedata, itemCd, itemName)
                        'frm_Imp2.Show()
                        '>>20150226

                        Me.Close()
                    ElseIf result = 1 Then
                        ' Dispose listener
                        If Not Me.msgListener Is Nothing Then
                            Me.msgListener.Dispose()
                        End If
                        'barcodeObj.ScanDisable()
                        ShowMessageForm("ERR121", "Import W830 Error")
                        Me.Focus()
                        msgListener = New MessageListener(Me)
                    ElseIf result = 2 Then
                        ' Dispose listener
                        If Not Me.msgListener Is Nothing Then
                            Me.msgListener.Dispose()
                        End If
                        'barcodeObj.ScanDisable()
                        ShowMessageForm("ERR122", "Import W830 Error")
                        Me.Focus()
                        msgListener = New MessageListener(Me)
                    ElseIf result = 3 Then
                        ' Dispose listener
                        If Not Me.msgListener Is Nothing Then
                            Me.msgListener.Dispose()
                        End If
                        'barcodeObj.ScanDisable()
                        ShowMessageForm("ERR124", "Import W830 Error")
                        Me.Focus()
                        msgListener = New MessageListener(Me)
                    End If
                Catch ex As Exception
                    ' Dispose listener
                    If Not Me.msgListener Is Nothing Then
                        Me.msgListener.Dispose()
                    End If
                    ' write log
                    WriteErrorLog(ex)
                    ' show form error system
                    ShowSystemMessageForm()
                    If Me.msgListener Is Nothing Then
                        Me.msgListener = New MessageListener(Me)
                    End If
                Finally
                    WriteEventEndLog("exeBarcodeInput")
                End Try
            Case "2"
                ProcessImport2()
            Case "3"
                ProcessImport3()
        End Select
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
            Dim frm_Return As New frm_IMPFG000()
            frm_Return.Show()
            Me.Close()
            ' show menu form
            'BCLoginManager.ShowMenuForm()
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
    ''' frm_IMPFG001_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_IMPFG001_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            WriteEventStartLog("frm_IMPFG001_Closing")
            'Free memmory
            'barcodeObj.ScanDisable()
            'Dispose Listener
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
            WriteEventEndLog("frm_IMPFG001_Closing")
        End Try
    End Sub

    ''' <summary>
    ''' frm_IMPFG001_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_IMPFG001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

#Region "FUCNTION"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessImport2()
        Try
            WriteEventStartLog("exeBarcodeInput")
            Dim message As String = String.Empty
            Dim result As Integer = 0
            Dim itemCd As String = String.Empty
            Dim itemName As String = String.Empty

            '' 1. Check client.
            If barcodeObj.StrCodedata.Length <> 14 Then
                message = String.Format("Invalid {0} Barcode !", Environment.NewLine)
                'Dispose Listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR121", "Import W830 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If

            '' 2. Check server.
            webService = New ABCDBC.WebService.Service()
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)

            Dim ds As DataSet = Nothing
            ds = webService.CheckBarcodeImportFGExistProcess(barcodeObj.StrCodedata, _
                                                             GetCaseImp, _
                                                             BCLoginManager.GetLoginInfo.UserID)

            result = Integer.Parse(ds.Tables(0).Rows(0).Item("RESULT").ToString())

            If result = 0 Then
                If Not ds.Tables(0).Rows(0).Item("ITEMCODE") Is Nothing Then
                    itemCd = ds.Tables(0).Rows(0).Item("ITEMCODE").ToString()
                End If

                If Not ds.Tables(0).Rows(0).Item("ITEMNAME") Is Nothing Then
                    itemName = ds.Tables(0).Rows(0).Item("ITEMNAME").ToString()
                End If

                webService.ImportFGBarcodeIntoQC(barcodeObj.StrCodedata, _
                                                 GetCaseImp, _
                                                 BCLoginManager.GetLoginInfo.UserID, _
                                                 itemCd)

                BCLoginManager.SubConCount = BCLoginManager.SubConCount + 1
                Dim msg As String = String.Format("Import {0} Sucessfully !", Environment.NewLine)
                frm_Imp3 = New frm_IMPFG003(msg, GetCaseImp)
                frm_Imp3.Show()
                Me.Close()
            ElseIf result = 1 Then
                'Dispose Listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR121", "Import W830 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
            ElseIf result = 2 Then
                'Dispose Listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR122", "Import W830 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
            ElseIf result = 3 Then
                ' Dispose listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR123", "Import W830 Error")
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

    Private Sub ProcessImport3()
        Try
            WriteEventStartLog("exeBarcodeInput")
            Dim message As String = String.Empty
            Dim result As Integer = 0
            Dim itemCd As String = String.Empty
            Dim itemName As String = String.Empty

            '' 1. Check client.
            If barcodeObj.StrCodedata.Length <> 14 Then
                message = String.Format("Invalid {0} Barcode !", Environment.NewLine)
                'Dispose Listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR121", "Import W830 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
                Exit Sub
            End If

            '' 2. Check server.
            webService = New ABCDBC.WebService.Service()
            webService.Url = BCCommon.GetWebHttpURL()
            webService.Timeout = BCCommon.GetWebServiceTimeOut(True)

            Dim ds As DataSet = Nothing
            ds = webService.CheckBarcodeImportFGExistProcess(barcodeObj.StrCodedata, _
                                                             GetCaseImp, _
                                                             BCLoginManager.GetLoginInfo.UserID)

            result = Integer.Parse(ds.Tables(0).Rows(0).Item("RESULT").ToString())

            If result = 0 Then
                Dim rs As Boolean = webService.ShipmentReturn(barcodeObj.StrCodedata, _
                                                              BCLoginManager.GetLoginInfo.UserID)

                If rs = True Then
                    BCLoginManager.ShipmentReturnCount = BCLoginManager.ShipmentReturnCount + 1
                    Dim msg As String = String.Format("Import {0} Sucessfully !", Environment.NewLine)
                    frm_Imp3 = New frm_IMPFG003(msg, GetCaseImp)
                    frm_Imp3.Show()
                Else
                    'Not exist in SHIP_ACT_INFO_TR -->Show Error
                    'Dispose Listener
                    If Not Me.msgListener Is Nothing Then
                        Me.msgListener.Dispose()
                    End If
                    'barcodeObj.ScanDisable()
                    ShowMessageForm("ERR125", "Import W830 Error")
                    Me.Focus()
                    msgListener = New MessageListener(Me)

                    'Dim msg As String = String.Format("Import {0} UnSucessfully !", Environment.NewLine)
                    'frm_Imp3 = New frm_IMPFG003(msg, GetCaseImp)
                    'frm_Imp3.Show()
                End If
                Me.Close()
            ElseIf result = 1 Then
                'Dispose Listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR121", "Import W830 Error")
                Me.Focus()
                msgListener = New MessageListener(Me)
            ElseIf result = 2 Then
                'Dispose Listener
                If Not Me.msgListener Is Nothing Then
                    Me.msgListener.Dispose()
                End If
                'barcodeObj.ScanDisable()
                ShowMessageForm("ERR122", "Import W830 Error")
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

#End Region

End Class