Namespace jp.co.ait.common
    ''' <summary>
    ''' BC共通クラス
    ''' </summary>
    Public Class ABCDBCCommon

#Region "ユーザ定義関数"

        ''' <summary>
        ''' カレントフォルダパス取得
        ''' </summary>
        ''' <returns>カレントフォルダパス</returns>
        Public Shared Function GetCurrentDir() As String
            ' 完全なディレクトリと exe 名を取得
            Dim fullAppName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase

            ' exe 名を除外
            Return System.IO.Path.GetDirectoryName(fullAppName) & "\"
        End Function

#End Region

    End Class
End Namespace
