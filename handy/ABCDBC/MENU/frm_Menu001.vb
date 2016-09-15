Imports jp.co.ait.ABCDBC.common

Public Class frm_Menu001

#Region "CONSTRUCTOR"
    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        BCLoginManager.MenuW900OrFG = "1"

    End Sub
#End Region

#Region " EVENTS "

    ''' <summary>
    ''' frm_Menu001_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_Menu001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        If e.KeyCode = Keys.NumPad1 Then

            Dim formMenu002 As New frm_Menu002
            formMenu002.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad2 Then

            Dim formMenu003 As New frm_Menu003
            formMenu003.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then

            Me.Close()

        ElseIf e.KeyCode = 137 Then ' Keys: FN
            ' close current form
            Me.Close()
            ' show menu form
            BCLoginManager.ShowMenuForm()
        End If
    End Sub

    ''' <summary>
    ''' pnl_W900_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_W900_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_W900.Click

        Dim formMenu002 As New frm_Menu002
        formMenu002.Show()
        Me.Close()
        Exit Sub
    End Sub

    ''' <summary>
    ''' pnl_Return_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Return.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' pnl_FG_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_FG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_FG.Click

        Dim formMenu003 As New frm_Menu003
        formMenu003.Show()
        Me.Close()
        Exit Sub
    End Sub


#End Region

#Region " METHODS "

#End Region

End Class