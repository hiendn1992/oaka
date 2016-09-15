''*********************************************************************
''* システム名：栃木ロケーションシステム
''* クラス名  ：共通定数クラス
''* 処理概要  ：共通定数クラス
#Region "彦根修正履歴"
''* 1  2008/01/11 1.00 NCS)CHEN        初版
#End Region
''* 1  2011/01/25 1.00 NCS)NISHIYAMA   ①積送処理削除
''*                                    ②受入形態区分：自動仕分追加
''*                                    ③廃止画面定数削除
''*********************************************************************

Namespace common

    ''' <summary>
    ''' 定数クラス
    ''' </summary>
    Public Class BCConst

#Region "共通定数"

        ''' <summary>数字入力画面と英字入力画面に担当者コードの限定</summary>
        Public Const SET_INPUT_MAXLENGTH As Integer = 8

        ''' <summary>内訳：タイヤ</summary>
        Public Const UCHIWAKE_TIRE As String = "3"

        ''' <summary>需要先：ＲＥＰ</summary>
        Public Const JUYOSAKI_REP As String = "1"

        ''' <summary>需要先：ＯＥ</summary>
        Public Const JUYOSAKI_OE As String = "3"

        ''' <summary>需要先：ＥＸＰ</summary>
        Public Const JUYOSAKI_EXP As String = "5"

        ''' <summary>
        ''' ピッキング作業単位区分
        ''' </summary>
        Public Enum SAGYO_TANI_KUBUN
            ''' <summary>号車単位</summary>
            GOSHA_UNIT = 0

            ''' <summary>日単位</summary>
            DAY_UNIT = 1
        End Enum

        ''' <summary>
        ''' ピッキング作業種別区分
        ''' </summary>
        Public Enum SAGYO_SHUBETSU_KUBUN
            ''' <summary>バース</summary>
            BERTH = 0

            ''' <summary>場所</summary>
            BASHO = 1
        End Enum

        ''' <summary>
        ''' ピッキング作業形態区分
        ''' </summary>
        Public Enum SAGYO_KEITAI_KUBUN
            ''' <summary>一般</summary>
            NORMAL = 0

            ''' <summary>営倉(ﾊﾟﾚ)</summary>
            EISO_PLT = 1

            ''' <summary>営倉(ﾊﾞﾗ)</summary>
            EISO_BARA = 2

            ''' <summary>小口</summary>
            KOGUCHI = 3

            ''' <summary>チフ単体</summary>
            TF_TANTAI = 4

            ''' <summary>倉中</summary>
            KURANAKA = 5

            ''' <summary>チフ倉中</summary>
            KURANAKA_TF = 6

            ''' <summary>ラッピング</summary>
            WRAPPING = 7

            ''' <summary>チフラッピング</summary>
            WRAPPING_TF = 8

        End Enum

        ''' <summary>
        ''' 作業実績フラグ
        ''' </summary>
        Public Enum SAGYO_JISSEKI_FLG
            ''' <summary>ピッキングリスト取得</summary>
            PIKKING_LIST = 0

            ''' <summary>作業実績</summary>
            JISSEKI = 1

            ''' <summary>作業中断</summary>
            SAGYO_CHUDAN = 2

            ''' <summary>作業全完了</summary>
            SAGYO_END = 3
        End Enum

        ''' <summary>
        ''' ピッキングフラグ
        ''' </summary>
        Public Enum PIKKING_FLG
            ''' <summary>ピッキングリスト取得</summary>
            PIKKING_LIST = 1

            ''' <summary>其の他</summary>
            OTHER = 0
        End Enum

        ''' <summary>
        ''' 直列／並列フラグ
        ''' </summary>
        Public Enum CHOKU_HEI_RETSU_FLG
            ''' <summary>直列</summary>
            CHOKURETSU = 0

            ''' <summary>配列</summary>
            HEIRETSU = 1
        End Enum

        ''' <summary>
        ''' 受入業務区分
        ''' </summary>
        Public Enum UKEIRE_GYOMU_KUBUN
            ''' <summary>製造</summary>
            SEIZO = 0
            ''' <summary>移送</summary>
            ISO = 1
        End Enum

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
        ''' 受入状況フラグ
        ''' </summary>
        Public Enum UKEIRE_JOKYO_FLG

            ''' <summary>未割付</summary>
            MIWARITUKE = 0

            ''' <summary>割付済</summary>
            WARITUKEZUMI = 1

            ''' <summary>エフ発行済</summary>
            EFUHAKKOZUMI = 2

            ''' <summary>受入作業完了</summary>
            UKEIRE_KANRYO = 3

            ''' <summary>入庫完了</summary>
            NYUKO_KANRYO = 4

            ''' <summary>ホスト接続済</summary>
            HOST_SETUZOKU = 5

        End Enum

        ''' <summary>
        ''' ボタン
        ''' </summary>
        Public Enum BUTTON
            ''' <summary>右ボタン</summary>
            RIGHT = 0
            ''' <summary>左ボタン</summary>
            LEFT = 1
        End Enum

        ''' <summary>
        ''' 移送受入存在フラグ（在庫区分）
        ''' </summary>
        Public Enum ISO_UKEIRE_EXIST_FLG
            ''' <summary>存在</summary>
            EXIST = 1
            ''' <summary>非存在</summary>
            UNEXIST = 0
        End Enum

        

        ''' <summary>
        ''' 共通ﾌﾗｸﾞ値
        ''' </summary>
        Public Enum CommonFlg
            ''' <summary>オフ</summary>
            OFF = 0

            ''' <summary>オン</summary>
            [ON] = 1
        End Enum

       

        ''' <summary>ﾀｲﾄﾙ名称作業中止確認</summary>
        Public Const TITLE_SAGYOSTOP_ERR As String = "作業中止確認"

#End Region

    End Class

End Namespace