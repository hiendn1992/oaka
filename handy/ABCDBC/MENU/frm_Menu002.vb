Imports jp.co.ait.ABCDBC.common

Public Class frm_Menu002

#Region "CONSTRUCTOR"
    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        BCLoginManager.MenuW900OrFG = "2"

        BCLoginManager.ImportW900Count = 0
        BCLoginManager.RejectW900Count = 0
        BCLoginManager.RetrieveW900Count = 0
        BCLoginManager.StocktakingW830Count = 0

    End Sub
#End Region

    Private Sub pnl_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Return.Click

        Me.Close()
        If ("1").Equals(BCLoginManager.GetLoginInfo.Authority) Then
            Dim menu001 As New frm_Menu001
            menu001.Show()
        End If
    End Sub

    Private Sub pnl_Imp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Imp.Click

        Dim frm_Imp As New frm_IMP001
        frm_Imp.Show()
        Me.Close()
    End Sub

    Private Sub frm_Menu002_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.NumPad1 Then ' Import W900.
            Dim frm_Imp As New frm_IMP001()
            frm_Imp.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad2 Then ' Reject W900.
            Dim rej001 As New frm_REJ001()
            rej001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad3 Then ' Retrieve W900.
            Dim retr001 As New frm_RETR001()
            retr001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad4 Then ' Stocktaking W900.
            Dim stocktk001 As New frm_STOCKTK001
            stocktk001.Show()
            Me.Close()
            '20150324 Phungntm fix Issue corresponding with Issue List        
            'RETURN TO MOLD
        ElseIf e.KeyCode = Keys.NumPad5 Then ' Return MOLD.
            Dim exp001 As New frm_EXP001
            exp001.Show()
            Me.Close()
            '>>
        ElseIf e.KeyCode = Keys.NumPad6 Then ' Stock Delete.
            Dim SDQC001 As New frm_SDQC001()
            SDQC001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            pnl_Return_Click(sender, e)
        End If

    End Sub

End Class