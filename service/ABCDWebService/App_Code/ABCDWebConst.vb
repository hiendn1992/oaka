''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* システム名：ABCD_Barcode_System
''* クラス名  ：ABCDWebService
''* 処理概要  ：BC端末の要求より、業務を行う
''*********************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1 14/12/12 1.00  AIT)cuongnc     New
#End Region
''*********************************************************

Namespace jp.co.ait.WebService

    Public Class ABCDWebConst

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


        ''' <summary>
        ''' 受入形態区分
        ''' </summary>
        Public Enum UKEIRE_KEITAI_KUBUN

            ''' <summary>移送</summary>
            ISO = 2

            ''' <summary>移管</summary>
            IKAN = 3

            ''' <summary>一般</summary>
            IPPANHIN = 4

            ''' <summary>SK品</summary>
            SKHIN = 5

            ''' <summary>W品</summary>
            WHIN = 6

            ''' <summary>終了品</summary>
            ENDHIN = 7

            ''' <summary>自動仕分</summary>
            JIDOSHIWAKE = 8

        End Enum

        ''' <summary>
        ''' 入庫完了ﾌﾗｸﾞ
        ''' </summary>
        Public Enum NYUKO_KANRYO_FLG
            ''' <summary>未入庫</summary>
            NYUKO_MI = 0

            ''' <summary>入庫完了</summary>
            NYUKO_OK = 1

            ''' <summary>入庫NG</summary>
            NYUKO_NG = 2
        End Enum

        ''' <summary>ﾊﾞｰｺｰﾄﾞﾊﾞｲﾄ数</summary>
        Public Enum BarCodeLength
            ''' <summary>成型BC 7ﾊﾞｲﾄ</summary>
            SeikeiBC_1 = 7

            ''' <summary>成型BC 8ﾊﾞｲﾄ</summary>
            SeikeiBC_2 = 8

            ''' <summary>ｴﾌBC 32ﾊﾞｲﾄ</summary>
            EfuBC = 32

            ''' <summary>Janｺｰﾄﾞ 13ﾊﾞｲﾄ</summary>
            JANCd = 13

        End Enum

        ''' <summary>
        ''' 作業形態区分
        ''' </summary>
        Public Enum SAGYO_KEITAI_KUBUN

            ''' <summary>一般</summary>
            IPPAN = 0

            ''' <summary>営倉(ﾊﾟﾚ)</summary>
            EISO_P = 1

            ''' <summary>営倉(ﾊﾞﾗ)</summary>
            EISO_B = 2

            ''' <summary>小口</summary>
            KOGUCHI = 3

        End Enum

    End Class

End Namespace