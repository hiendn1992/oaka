Imports jp.co.ait.ABCDBC.common

Public Class frm_Menu003

#Region "CONSTRUCTOR"
    ''' <summary>
    ''' Constructor without params
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        BCLoginManager.MenuW900OrFG = "3"

        'BCLoginManager.ImportFGW830Count = 0

        BCLoginManager.RejectW830Count = 0

        BCLoginManager.StockDeleteW830Count = 0

        BCLoginManager.StockMoveW830Count = 0

        BCLoginManager.SetRackW830Count = 0

        BCLoginManager.StocktakingW830Count = 0

        'BCLoginManager.SubConCount = 0

        'BCLoginManager.ShipmentReturnCount = 0

    End Sub
#End Region

#Region "VARIABLES"

#End Region

#Region "EVENTS"
    ''' <summary>
    ''' pnl_Return_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnl_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnl_Return.Click
        Me.Close()
        If ("1").Equals(BCLoginManager.GetLoginInfo.Authority) Then
            Dim menu001 As New frm_Menu001
            menu001.Show()
        End If
    End Sub

    ''' <summary>
    ''' frm_Menu003_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_Menu003_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.NumPad1 Then
            'Dim frm_Imp As New frm_IMPFG001()
            'frm_Imp.Show()
            'Me.Close()
            Dim frm_Imp As New frm_IMPFG000()
            frm_Imp.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad2 Then
            Dim frm_Srfg001 As New frm_SRFG001()
            frm_Srfg001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad3 Then
            Dim rejfg001 As New frm_REJFG001()
            rejfg001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad4 Then
            Dim ship001 As New frm_SHIPFG001()
            ship001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad5 Then
            Dim stkFG001 As New frm_STOCKTKFG001()
            stkFG001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad6 Then
            Dim smfg001 As New frm_SMFG001()
            smfg001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad7 Then
            Dim sdfg001 As New frm_SDFG001()
            sdfg001.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.NumPad8 Then '// #No.23: add new method return from W830 to W900
            Dim returnW900 As New ReturnW900
            BCLoginManager.ReturnW900Count = 0 '// Go to Menu 003
            returnW900.Show()
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            pnl_Return_Click(sender, e)
        End If
    End Sub
#End Region

#Region "METHODS"

#End Region

End Class