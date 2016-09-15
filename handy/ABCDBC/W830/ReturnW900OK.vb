Imports jp.co.ait.ABCDBC.common
Imports Microsoft.WindowsCE.Forms
Imports Bt
Imports jp.co.ait.ABCDBC.WebService

Public Class ReturnW900OK

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub pnl_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim returnW900 As New ReturnW900
        returnW900.Show()
        Me.Close()
    End Sub

    Private Sub ReturnW900OK_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose()
    End Sub

    Private Sub ReturnW900OK_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then
            pnl_Action_Click(sender, e)
        ElseIf e.KeyCode = 137 Then
            Me.Close()
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

End Class