Namespace jp.co.ait.common
    ''' <summary>
    ''' BC���ʃN���X
    ''' </summary>
    Public Class ABCDBCCommon

#Region "���[�U��`�֐�"

        ''' <summary>
        ''' �J�����g�t�H���_�p�X�擾
        ''' </summary>
        ''' <returns>�J�����g�t�H���_�p�X</returns>
        Public Shared Function GetCurrentDir() As String
            ' ���S�ȃf�B���N�g���� exe �����擾
            Dim fullAppName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase

            ' exe �������O
            Return System.IO.Path.GetDirectoryName(fullAppName) & "\"
        End Function

#End Region

    End Class
End Namespace
