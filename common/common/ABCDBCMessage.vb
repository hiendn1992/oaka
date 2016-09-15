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
    Public Class ABCDBCMessage

#Region "ユーザ定義関数"

        ''' <summary>
        ''' ﾒｯｾｰｼﾞ情報を取得します
        ''' </summary>
        ''' <param name="msgId">ﾒｯｾｰｼﾞID</param>
        ''' <returns>ﾒｯｾｰｼﾞ 存在しない場合:Nothing</returns>
        Public Shared Function GetMessage(ByVal msgId As String) As String
            Return GetMessage(msgId, New String() {})
        End Function

        ''' <summary>
        ''' ﾒｯｾｰｼﾞ情報を取得します
        ''' </summary>
        ''' <param name="msgId">ﾒｯｾｰｼﾞID</param>
        ''' <param name="param">付加文言</param>
        ''' <returns>ﾒｯｾｰｼﾞ 存在しない場合:Nothing</returns>
        Public Shared Function GetMessage(ByVal msgId As String, ByVal param() As String) As String

            Dim ret As String = String.Empty

            ' xml読み込み
            Dim xmlMsgFile As String = ABCDBCXmlManager.GetFileData("BC_MSG/FILE_NAME")
            Dim xmlMsgDir As String = ABCDBCXmlManager.GetFileData("BC_MSG/FILE_DIR")

            If xmlMsgDir.Length = 0 Then
                xmlMsgDir = ABCDBCCommon.GetCurrentDir()
            End If

            'XMLﾌｧｲﾙを読み込む
            Dim message As String = ABCDBCXmlManager.GetFileData(xmlMsgDir & xmlMsgFile, "type/module/message[@id='" + msgId + "']")

            If IsNothing(param) OrElse param.Length = 0 Then
                ret = message
            Else
                ret = String.Format(message, param)
            End If

            Return ret

        End Function

#End Region

    End Class

End Namespace
