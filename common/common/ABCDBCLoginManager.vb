''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* システム名：ABCDCommon
''* クラス名  ：
''* 処理概要  ：
''*********************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1 14/12/15 1.00  AIT)cuongnc     New
#End Region
''*********************************************************
Namespace jp.co.ait.common

    ''' <summary>
    ''' ログイン情報クラス
    ''' </summary>
    Public Class ABCDBCLoginManager
        Inherits ABCDBCBase

        ''' <summary>ログイン情報</summary>
        Private Shared _LoginInfo As ABCDBCLoginInfo

        ''' <summary>
        ''' ログイン状態
        ''' </summary>
        ''' <returns>True：ログイン済み　False：未ログイン</returns>
        Public Shared Function IsLogin() As Boolean
            If _LoginInfo Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' ログイン情報の取得
        ''' </summary>
        ''' <returns>ログイン情報</returns>
        Public Shared Function GetLoginInfo() As ABCDBCLoginInfo
            Return _LoginInfo
        End Function

        ''' <summary>
        ''' ログイン情報クラスの作成
        ''' </summary>
        ''' <param name="UserID">登録したユーザID</param>
        ''' <returns>ログイン情報クラスインスタンス</returns>
        Public Shared Function CreateLoginInfo(ByVal UserID As String) As ABCDBCLoginInfo
            If _LoginInfo Is Nothing Then
                _LoginInfo = New ABCDBCLoginInfo(UserID)
            Else
                If UserID.Equals(String.Empty) Then
                    _LoginInfo = Nothing
                    _LoginInfo = New ABCDBCLoginInfo(UserID)
                End If
                _LoginInfo.UserID = UserID
            End If
            Return _LoginInfo
        End Function
    End Class

End Namespace
