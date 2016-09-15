Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt

Public Class frm_STOCKTKFG003 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private stkFG003 As frm_STOCKTKFG003
    Private stkFG001 As frm_STOCKTKFG001
    Private stkFG004 As frm_STOCKTKFG004
    Private webService As ABCDBC.WebService.Service
    Private rackNo As String = ""
    Private stkReqNo As String = ""
    Private msgListener As MessageListener
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
    ''' frm_STOCKTKFG003_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTKFG003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            WriteEventStartLog("frm_STOCKTKFG003_Load")

            lbl_WarehouseCd.Text = rackNo & " ? "

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
            WriteEventEndLog("frm_STOCKTKFG003_Load")
        End Try
    End Sub

    ''' <summary>
    ''' panel_Return_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub panel_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_CANCEL.Click
        Try
            WriteEventStartLog("panel_Return_Click")
            Me.Close()

            ' Show menu form
            stkFG001 = New frm_STOCKTKFG001(stkReqNo)
            stkFG001.Show()
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
            WriteEventEndLog("panel_Return_Click")
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

            ' Modified date 20150901.
            BCLoginManager.StocktakingW830Count = 0 ' Cuongtk modify change rack update count = 0.

            Me.Close()

            stkFG004 = New frm_STOCKTKFG004(rackNo, stkReqNo)
            stkFG004.Show()

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
            WriteEventEndLog("panel_Ok_Click")
        End Try
    End Sub

    ''' <summary>
    ''' frm_STOCKTKFG003_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_STOCKTKFG003_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then

            ' Click panel OK
            panel_Ok_Click(sender, e)
        ElseIf e.KeyCode = Keys.F2 Then

            ' Click panel Return
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