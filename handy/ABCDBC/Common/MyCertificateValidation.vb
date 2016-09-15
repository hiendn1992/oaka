Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Public Class MyCertificateValidation
    Implements ICertificatePolicy

    Public Function CheckValidationResult(ByVal srvPoint As ServicePoint, _
    ByVal cert As X509Certificate, ByVal request As WebRequest, ByVal problem As Integer) _
       As Boolean Implements ICertificatePolicy.CheckValidationResult

        'Return true to specify that certificate is always validated
        Return True

    End Function

End Class
