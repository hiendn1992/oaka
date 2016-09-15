Imports jp.co.ait.ABCDBC.common

Public Class frm_REJFG003

#Region " VARIABLE / CONSTANT "
    Private rackNo As String = ""
    Private rejfg001 As frm_REJFG001
#End Region

#Region " CONSTRUCTOR "

    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    Public Sub New()
        ' この呼び出しは、Windows ﾌｫｰﾑ ﾃﾞｻﾞｲﾅで必要です
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Constructor with params
    ''' </summary>
    ''' <param name="pMessage"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal pMessage As String, ByVal pRackNo As String)
        ' init
        InitializeComponent()
        '' set params
        lbl_msg.Text = pMessage
        Me.rackNo = pRackNo
        Me.lbl_msg.TextAlign = ContentAlignment.TopCenter
    End Sub

#End Region

#Region " MENTHODS "


    ''' <summary>
    ''' pnl_Action_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Continue.Click

        rejfg001 = New frm_REJFG001()
        rejfg001.Show()
        Me.Close()
    End Sub

    ''' <summary>
    ''' frm_REJFG003_Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_REJFG003_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        'Free memmory
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' frm_REJFG003_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_REJFG003_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then

            pnl_Action_Click(sender, e)
        ElseIf e.KeyCode = 137 Then ' Keys: Fn

            ' close current form
            Me.Close()

            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

#End Region

End Class