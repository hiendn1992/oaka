Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt

Public Class frm_SRFG002 : Inherits jp.co.ait.common.forms.ABCDBCForm

#Region " VARIABLE / CONSTANT "

    Private srfg003 As frm_SRFG003
    Private srfg001 As frm_SRFG001
    Private srfg004 As frm_SRFG004
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
    ''' frm_RETR002_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_RETR002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            WriteEventStartLog("frm_SRFG003_Load")

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
            WriteEventEndLog("frm_SRFG003_Load")
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
            srfg001 = New frm_SRFG001()
            srfg001.Show()
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

            srfg003 = New frm_SRFG003(rackCd)
            srfg003.Show()

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
    ''' frm_RETR002_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_RETR002_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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