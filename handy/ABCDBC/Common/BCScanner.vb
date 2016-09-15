Imports Bt

Public Class BCScanner
    Inherits Microsoft.WindowsCE.Forms.MessageWindow
    Private strBarcode As String = ""
    Public Sub New()
    End Sub

    Protected Overrides Sub WndProc(ByRef msg As Microsoft.WindowsCE.Forms.Message)
        Select Case msg.Msg
            Case CType(LibDef.WM_BT_SCAN, Int32)
                ' When reading is successful
                If msg.WParam.ToInt32() = CType(LibDef.BTMSG_WPARAM.WP_SCN_SUCCESS, Int32) Then
                    GetDataScan()
                End If
                Exit Select
        End Select
        MyBase.WndProc(msg)
    End Sub

    Private Sub GetDataScan()
        strBarcode = "Test"
    End Sub

    Public Property barcode() As String
        Get
            Return StrBarcode
        End Get
        Set(ByVal value As String)
            strBarcode = value
        End Set
    End Property
End Class
