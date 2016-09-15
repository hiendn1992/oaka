Public Class frm_SCANERR

    Private m_msgError As String = String.Empty

    Public Sub New(ByVal msgError As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.m_msgError = msgError
    End Sub

    Private Sub frm_SCANERR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_msg.Text = Me.m_msgError
    End Sub

    Private Sub panel_Return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class