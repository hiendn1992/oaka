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
Imports System.Drawing

Namespace jp.co.ait.common

    ''' <summary>
    ''' 定数クラス
    ''' </summary>
    Public Class ABCDBCConst

#Region "共通定数"
        ''' <summary>初期値定義用XMLファイル名称</summary>
        Public Const APP_CONFIG_FILE As String = "ABCD_SV.xml"

        ''' <summary>ログ出力レベル定数　DUMP</summary>
        Public Const LOG_LEVEL_DUMP As String = "Dump"

        ''' <summary>ログ出力レベル定数　DEBUG</summary>
        Public Const LOG_LEVEL_DEBUG As String = "Debug"

        ''' <summary>ログ出力レベル定数　INFOMATION</summary>
        Public Const LOG_LEVEL_INFOMATION As String = "Infomation"

        ''' <summary>ログ出力レベル定数　TRACE</summary>
        Public Const LOG_LEVEL_TRACE As String = "Trace"

        ''' <summary>ログ出力レベル定数　OPERATION</summary>
        Public Const LOG_LEVEL_OPERATION As String = "Operation"

        ''' <summary>ログ出力レベル定数　WARNING</summary>
        Public Const LOG_LEVEL_WARNING As String = "Warning"

        ''' <summary>ログ出力レベル定数　ERROR</summary>
        Public Const LOG_LEVEL_ERROR As String = "Error"

        ''' <summary>ネットワークの接続　EXCEPTION</summary>
        Public Const ORA_CON_EXCEPTION As String = "ネットワークへの接続を確立できませんでした。"

        ''' <summary>ﾀｲﾄﾙ名称ｴﾗｰ</summary>
        Public Const TITLE_ERROR As String = "エラー"

        ''' <summary>
        ''' 色ﾚﾍﾞﾙ
        ''' </summary>
        Public Enum userColorLevel

            ''' <summary> 色ﾚﾍﾞﾙなし </summary>
            LEVEL0 = 0

            ''' <summary> 色ﾚﾍﾞﾙ 1 </summary>
            LEVEL1 = 1

            ''' <summary> 色ﾚﾍﾞﾙ 2 </summary>
            LEVEL2 = 2

            ''' <summary> 色ﾚﾍﾞﾙ 3 </summary>
            LEVEL3 = 3

            ''' <summary> 色ﾚﾍﾞﾙ 4 </summary>
            LEVEL4 = 4

            ''' <summary> 色ﾚﾍﾞﾙ 5 </summary>
            LEVEL5 = 5

            ''' <summary> 色ﾚﾍﾞﾙ 6 </summary>
            LEVEL6 = 6

            ''' <summary> 色ﾚﾍﾞﾙ 7 </summary>
            LEVEL7 = 7

            ''' <summary> 色ﾚﾍﾞﾙ 8 </summary>
            LEVEL8 = 8

            ''' <summary> 色ﾚﾍﾞﾙ 9 </summary>
            LEVEL9 = 9

        End Enum

        ''' <summary>
        ''' ﾊﾟﾈﾙ背景色ﾘｽﾄ
        ''' </summary>
        Public Shared LST_BACKCOLOR_LEVEL As Color() = New Color() {Color.LightBlue, SystemColors.Control, _
                                                              Color.Navy, Color.Black, _
                                                              Color.Blue, Color.MediumBlue, _
                                                              Color.SkyBlue, Color.LimeGreen, _
                                                              Color.Red, Color.Indigo}

        ''' <summary>
        ''' ﾊﾟﾈﾙにあるﾗﾍﾞﾙﾌｫﾝﾄ色ﾘｽﾄ
        ''' </summary>
        Public Shared LST_FONTCOLOR_LEVEL As Color() = New Color() {Color.Black, SystemColors.ControlText, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White}
        ''' <summary>
        ''' ﾊﾟﾈﾙ境界線色ﾘｽﾄ
        ''' </summary>
        Public Shared LST_BORDERCOLOR_LEVEL As Color() = New Color() {SystemColors.WindowFrame, SystemColors.WindowFrame, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White, _
                                                              Color.White, Color.White}

        ''' <summary>
        ''' ﾊﾟﾈﾙ境界線幅ﾘｽﾄ
        ''' </summary>
        Public Shared LST_BORDERWIDTH_LEVEL As Integer() = New Integer() {1, 1, 4, 4, 4, 4, 4, 4, 4, 4}

        ''' <summary>
        ''' ﾊﾟﾈﾙ背景色ﾘｽﾄ(ﾛｯｸ時)
        ''' </summary>
        Public Shared LST_LOCK_BACKCOLOR_LEVEL As Color() = New Color() {Color.White, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control, _
                                                              SystemColors.Control, SystemColors.Control}

        ''' <summary>
        ''' ﾊﾟﾈﾙにあるﾗﾍﾞﾙﾌｫﾝﾄ色ﾘｽﾄ(ﾛｯｸ時)
        ''' </summary>
        Public Shared LST_LOCK_FONTCOLOR_LEVEL As Color() = New Color() {Color.Black, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText, _
                                                              SystemColors.GrayText, SystemColors.GrayText}
#End Region

    End Class

End Namespace