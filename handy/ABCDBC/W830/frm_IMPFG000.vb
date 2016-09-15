Imports jp.co.ait.ABCDBC.common

Public Class frm_IMPFG000

    Private msgListener As MessageListener
    Private barcodeObj As BarcodeObj
    Private webService As ABCDBC.WebService.Service

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BCLoginManager.SubConCount = 0

        BCLoginManager.ShipmentReturnCount = 0

        BCLoginManager.ImportFGW830Count = 0
    End Sub

    Private Sub frm_IMPFG000_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Try
        '    '' WriteEventStartLog("frm_IMPFG001_Closing")
        '    'Free memmory
        '    barcodeObj.ScanDisable()
        '    Me.msgListener.Dispose()
        '    Me.Dispose()
        'Catch ex As Exception
        '    ' write log
        '    '' WriteErrorLog(ex)
        '    ' show form error system
        '    ShowSystemMessageForm()
        'Finally
        '    '' WriteEventEndLog("frm_IMPFG001_Closing")
        'End Try
    End Sub

    Private Sub pnl_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Return.Click
        Try
            '' WriteEventStartLog("panel_Return_Click")
            Me.Close()
            ' show menu form
            BCLoginManager.ShowMenuForm()
        Catch ex As Exception
            ' write log
            '' WriteErrorLog(ex)
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
            '' WriteEventEndLog("panel_Return_Click")
        End Try
    End Sub

    Private Sub frm_IMPFG000_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        'If e.KeyCode = 153 Then ' Keys: Scan
        '    ' enable scanner
        '    barcodeObj.ScanEnable()
        If e.KeyCode = Keys.F2 Then ' Keys: Back
            ' close curren form
            pnl_Return_Click(sender, e)
        ElseIf e.KeyCode = Keys.NumPad1 Then
            Dim frm_Imp As New frm_IMPFG001("1")
            frm_Imp.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad2 Then
            Dim frm_Imp As New frm_IMPFG001("2")
            frm_Imp.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad3 Then
            Dim frm_Imp As New frm_IMPFG001("3")
            frm_Imp.Show()
            Me.Close()
        ElseIf e.KeyCode = 137 Then ' Keys: FN
            ' close current form
            Me.Close()
            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

End Class