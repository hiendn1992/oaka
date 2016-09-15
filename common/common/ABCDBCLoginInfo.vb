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
    Public Class ABCDBCLoginInfo

        ''' <summary>ログインユーザID</summary>
        Private _userID As String = String.Empty

        ''' <summary>ログインユーザ名称</summary>
        Private _userName As String = String.Empty

        '' <summary>ログイン倉庫ｺｰﾄﾞ</summary>
        'Private _sokoCD As String = String.Empty

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        Public Sub New()
            Me._userID = String.Empty
            Me._userName = String.Empty

            'Me._sokoCD = ABCDBCXmlManager.GetFileData("SOKO_CD/JISOKO_CD")
        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="userID">ログインユーザID</param>
        Public Sub New(ByVal userID As String)
            Me.New()
            Me._userID = userID
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
        Public Property UserName() As String
            Get
                Return Me._userName
            End Get
            Set(ByVal value As String)
                Me._userName = value
            End Set
        End Property

        '' <summary>
        '' ログイン倉庫ｺｰﾄﾞの設定と取得
        '' </summary>
        '' <returns>ログイン倉庫ｺｰﾄﾞの戻り値</returns>
        'Public ReadOnly Property SokoCD() As String
        '   Get
        '      Return Me._sokoCD
        '   End Get
        ' End Property

    End Class
End Namespace
