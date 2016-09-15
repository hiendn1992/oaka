Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt

Public Class frm_SMFG002 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private smfg003 As frm_SMFG003
    Private smfg001 As frm_SMFG001
    Private smfg004 As frm_SMFG004
    Private webService As ABCDBC.WebService.Service
    Private rackCd As String
    Private msgListener As MessageListener
#End Region

#Region " CONSTRUCTOR "
    Public Sub New(ByVal pRackCd As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.rackCd = pRackCd
    End Sub
#End Region

#Region " MENTHODS "
    ''' <summary>
    ''' frm_SMFG002_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            WriteEventStartLog("frm_SMFG002_Load")

            lbl_WarehouseCd.Text = rackCd & " ? "

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
            WriteEventEndLog("frm_SMFG002_Load")
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
            smfg001 = New frm_SMFG001()
            smfg001.Show()
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

            Me.Close()

            smfg003 = New frm_SMFG003(rackCd)
            smfg003.Show()

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
    ''' frm_SMFG002_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_SMFG002_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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