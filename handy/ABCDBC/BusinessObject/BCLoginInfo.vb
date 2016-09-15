Imports jp.co.ait.common

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
Namespace common
    Public Class BCLoginInfo
        Inherits ABCDBCBase
        ''' <summary>ログインユーザID</summary>
        Private _userID As String = String.Empty

        ''' <summary>ログインユーザ名称</summary>
        Private _authority As String = String.Empty

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        Public Sub New()

            Me._userID = String.Empty
            Me._authority = String.Empty
        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="userID">ログインユーザID</param>
        Public Sub New(ByVal userID As String, ByVal authority As String)
            Me.New()
            Me._userID = userID
            Me._authority = authority
        End Sub

        ''' <summary>
        ''' ログインユーザIDの設定と取得
        ''' </summary>
        ''' <value>ログインユーザIDの設定値</value>
        ''' <returns>ログインユーザIDの戻り値</returns>
        Public Property UserID() As String
            Get
                Return Me._userID
            End Get
            Set(ByVal value As String)
                Me._userID = value
            End Set
        End Property

        ''' <summary>
        ''' ログインユーザ名称の設定と取得
        ''' </summary>
        ''' <value>ログインユーザ名称の設定値</value>
        ''' <returns>ログインユーザ名称の戻り値</returns>
        Public Property Authority() As String
            Get
                Return Me._authority
            End Get
            Set(ByVal value As String)
                Me._authority = value
            End Set
        End Property
    End Class
End Namespace
