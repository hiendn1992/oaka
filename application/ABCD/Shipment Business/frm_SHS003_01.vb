Public Class frm_SHS003_01

    Public Sub New(ByVal palletNo As String, _
                   ByVal quantitySum As String, _
                   ByVal boxSum As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        lb_pallet_no.Text = palletNo
        lb_quantity_sum.Text = quantitySum
        lb_box_sum.Text = boxSum
    End Sub
End Class