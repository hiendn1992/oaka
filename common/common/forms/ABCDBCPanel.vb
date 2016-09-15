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

Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel


Namespace jp.co.ait.common.forms
    ''' <summary>
    ''' ハンディ用パネル(パネルコンポーネット)
    ''' </summary>
    Public Class ABCDBCPanel
        Inherits Panel

#Region " ユーザ定義 "

        ''' <summary>
        ''' 境界線スタイル
        ''' </summary>
        Private _borderStyle As BorderStyle = BorderStyle.None

        ''' <summary>
        ''' 境界線色
        ''' </summary>
        Private _borderColor As Color = SystemColors.WindowFrame

        ''' <summary>
        ''' 境界線幅
        ''' </summary>
        Private _borderWidth As Integer = 1

        ''' <summary>
        ''' パネルロックの値(クリックイベント処理しないように)
        ''' </summary>
        Private _pnlLocked As Boolean = False

        ''' <summary>
        ''' パネル色レベル
        ''' </summary>
        Private _colorLevel As ABCDBCConst.userColorLevel = ABCDBCConst.userColorLevel.LEVEL5

        ''' <summary>
        ''' パネルに表示する文字列
        ''' </summary>
        Private _labelText As String = ""

        ''' <summary>
        ''' パネルに表示する文字列を改行する際の改行文字
        ''' </summary>
        Private _splitChar As String = "\n"

        ''' <summary>
        ''' ﾌｫﾝﾄ色
        ''' </summary>
        Private _fontColor As Color = Color.Black

        ''' <summary>
        ''' パネルに表示する文字列を改行する際の改行文字
        ''' </summary>
        Private _labelFont As Font = New Font("ＭＳ ゴシック", 12, FontStyle.Bold)

        ''' <summary>
        ''' パネルに表示する文字列を左右表示
        ''' </summary>
        Private _labelAlign As HorizontalAlignment = HorizontalAlignment.Center

        ''' <summary>
        ''' ﾊﾟﾈﾙｸﾘｯｸ可否ﾌﾗｸﾞ
        ''' </summary>
        Private _clickEnabled As Boolean = True

#End Region

#Region " プロパティ "

        ''' <summary>
        ''' 境界線スタイルの設定と取得(3D対応しません)
        ''' </summary>
        ''' <value>境界線スタイルの設定値</value>
        ''' <returns>境界線スタイルの戻り値</returns>
        Public Shadows Property BorderStyle() As BorderStyle
            Get
                Return Me._borderStyle
            End Get
            Set(ByVal Value As BorderStyle)
                Me._borderStyle = Value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' 境界線色の設定と取得
        ''' </summary>
        ''' <value>境界線色の設定値</value>
        ''' <returns>境界線色の戻り値</returns>
        Public Property BorderColor() As Color
            Get
                Return Me._borderColor
            End Get
            Set(ByVal Value As Color)
                Me._borderColor = Value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' 境界線幅の設定と取得
        ''' </summary>
        ''' <value>境界線幅の設定値</value>
        ''' <returns>境界線幅の戻り値</returns>
        Public Property BorderWidth() As Integer
            Get
                Return Me._borderWidth
            End Get
            Set(ByVal Value As Integer)
                Me._borderWidth = Value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' ロックの設定と取得
        ''' </summary>
        ''' <value>ロックの設定値</value>
        ''' <returns>ロックの戻り値</returns>
        Public Property PnlLocked() As Boolean
            Get
                Return Me._pnlLocked
            End Get
            Set(ByVal Value As Boolean)
                Me._pnlLocked = Value
                SetPanelColor()
            End Set
        End Property

        ''' <summary>
        ''' パネル色レベルの設定と取得
        ''' </summary>
        ''' <value>パネル色レベルの設定値</value>
        ''' <returns>パネル色レベルの戻り値</returns>
        Public Property ColorLevel() As ABCDBCConst.userColorLevel
            Get
                Return Me._colorLevel
            End Get
            Set(ByVal value As ABCDBCConst.userColorLevel)
                Me._colorLevel = value
                SetPanelColor()
            End Set
        End Property

        ''' <summary>
        ''' パネルの文字の設定と取得
        ''' </summary>
        ''' <value>パネルの文字の設定値</value>
        ''' <returns>パネルの文字の戻り値</returns>
        Public Property LabelText() As String
            Get
                Return Me._labelText
            End Get
            Set(ByVal value As String)
                Me._labelText = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' パネルの改行文字の設定と取得
        ''' </summary>
        ''' <value>パネルの改行文字の設定値</value>
        ''' <returns>パネルの改行文字の戻り値</returns>
        Public Property SplitChar() As String
            Get
                Return Me._splitChar
            End Get
            Set(ByVal value As String)
                Me._splitChar = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' パネル文字色の設定と取得
        ''' </summary>
        ''' <value>パネル文字色の設定値</value>
        ''' <returns>パネル文字色の戻り値</returns>
        Public Property FontColor() As Color
            Get
                Return Me._fontColor
            End Get
            Set(ByVal value As Color)
                Me._fontColor = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' パネル文字
        ''' </summary>
        ''' <value>パネル文字の設定値</value>
        ''' <returns>パネル文字の戻り値</returns>
        Public Property LableFont() As Font
            Get
                Return Me._labelFont
            End Get
            Set(ByVal value As Font)
                Me._labelFont = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' パネル文字の水平位置
        ''' </summary>
        ''' <value>パネル文字の水平位置の設定値</value>
        ''' <returns>パネル文字の水平位置の戻り値</returns>
        Public Property LabelAlign() As HorizontalAlignment
            Get
                Return Me._labelAlign
            End Get
            Set(ByVal value As HorizontalAlignment)
                Me._labelAlign = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' ﾊﾟﾈﾙｸﾘｯｸ可否ﾌﾗｸﾞ
        ''' </summary>
        ''' <value>ﾊﾟﾈﾙｸﾘｯｸ可否ﾌﾗｸﾞの設定値</value>
        ''' <returns>ﾊﾟﾈﾙｸﾘｯｸ可否ﾌﾗｸﾞの戻り値</returns>
        Public Property ClickEnabled() As Boolean
            Get
                Return Me._clickEnabled
            End Get
            Set(ByVal value As Boolean)
                Me._clickEnabled = value
            End Set
        End Property

#End Region

#Region " ﾕｰｻﾞ定義関数 "

        ''' <summary>
        ''' ﾊﾟﾈﾙの色を設定
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetPanelColor()
            Me.BorderColor = ABCDBCConst.LST_BORDERCOLOR_LEVEL(Me._colorLevel)
            If Me._pnlLocked Then
                Me.BackColor = ABCDBCConst.LST_LOCK_BACKCOLOR_LEVEL(Me._colorLevel)
                Me.FontColor = ABCDBCConst.LST_LOCK_FONTCOLOR_LEVEL(Me._colorLevel)
            Else
                Me.BackColor = ABCDBCConst.LST_BACKCOLOR_LEVEL(Me._colorLevel)
                Me.FontColor = ABCDBCConst.LST_FONTCOLOR_LEVEL(Me._colorLevel)
            End If
        End Sub

        ''' <summary>
        ''' ﾊﾟﾈﾙにﾌｫﾝﾄを描画する
        ''' </summary>
        ''' <param name="value">色ﾗﾍﾞﾙ</param>
        ''' <param name="e">描画ｲﾍﾞﾝﾄ情報</param>
        Private Sub SetPanelFont(ByVal value As ABCDBCConst.userColorLevel, _
                                 ByVal e As System.Windows.Forms.PaintEventArgs)

            Dim brush As System.Drawing.Brush = New System.Drawing.SolidBrush(Me._fontColor)
            Dim lines As String() = Split(Me._labelText, Me._splitChar)
            Dim h As Single = e.Graphics.MeasureString(lines(0), Me._labelFont).Height

            Const yohaku As Integer = 10

            If Me._labelFont.Name = "ＭＳ ゴシック" Then
                h = Convert.ToInt32(h * 0.9)
            End If

            '上下のセンタリングを行う為、上端の位置を計算する
            Dim top As Single = (Me.Height - h * lines.Length()) / 2
            Dim x As Single

            For Each line As String In lines
                '左右のセンタリングを行う為、左端の位置を計算する
                Select Case Me._labelAlign
                    Case HorizontalAlignment.Left
                        x = yohaku
                    Case HorizontalAlignment.Center
                        x = (Me.Width - e.Graphics.MeasureString(line, Me._labelFont).Width) / 2
                    Case HorizontalAlignment.Right
                        x = (Me.Width - e.Graphics.MeasureString(line, Me._labelFont).Width) - yohaku
                    Case Else

                End Select

                e.Graphics.DrawString(line, Me._labelFont, brush, x, top)
                top = top + h
            Next
        End Sub

        ''' <summary>
        ''' ﾊﾟﾈﾙの罫線を描画する
        ''' </summary>
        ''' <param name="e">描画ｲﾍﾞﾝﾄ情報</param>
        Private Sub SetPanelBorder(ByVal e As System.Windows.Forms.PaintEventArgs)

            ' コントロールのクライアント領域を表す四角形を取得
            Dim rect As System.Drawing.Rectangle = Me.ClientRectangle

            ' コントロールのクライアント領域を表す四角形のサイズの再設定
            If Me.ClientRectangle.Width = 0 Then
                rect.Width += 1
            End If

            If Me.ClientRectangle.Height = 0 Then
                rect.Height += 1
            End If

            rect.Width -= 1
            rect.Height -= 1

            ' コントロールのクライアント領域を表す四角形の境界線を描く
            Select Case Me._borderStyle
                Case System.Windows.Forms.BorderStyle.FixedSingle
                    ' 一重線の境界線
                    Dim borderPen As New System.Drawing.Pen(Me._borderColor, Me._borderWidth * 2)
                    e.Graphics.DrawRectangle(borderPen, rect)
                    borderPen.Dispose()

                Case System.Windows.Forms.BorderStyle.Fixed3D
                    ' 3D 境界線

                Case System.Windows.Forms.BorderStyle.None
                    ' 境界線なし
            End Select

            rect = Nothing

        End Sub

#End Region

#Region "コンストラクタと初期化"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        Public Sub New()

            MyBase.New()
            Me.customInitialisation()

        End Sub

        ''' <summary>
        ''' 初期化処理
        ''' </summary>
        Private Sub customInitialisation()

            ' コントロールのレイアウトロジックを一時的に中断する。 
            Me.SuspendLayout()

            MyBase.BackColor = Color.Transparent
            Me.BorderStyle = BorderStyle.None

            ' 通常のレイアウトロジックを再開する。
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " オーバーライドイベント "

        ''' <summary>
        ''' ToolStripの背景のPaintイベントを発生させる。
        ''' </summary>
        ''' <param name="e">Paintイベント情報</param>
        Protected Overrides Sub OnPaintBackGround(ByVal e As System.Windows.Forms.PaintEventArgs)

            MyBase.OnPaintBackground(e)

            ' 境界線の描画
            SetPanelBorder(e)

            If Not Me._labelText.Equals(String.Empty) Then
                ' ﾌｫﾝﾄの描画
                SetPanelFont(Me._colorLevel, e)
            End If
        End Sub

        ''' <summary>
        ''' パネルのクリックイベントをｵｰﾊﾞｰﾗｲﾄﾞする
        ''' </summary>
        ''' <param name="e">イベント情報</param>
        Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
            ' パネルロックしたとき(クリックイベント発生しない)
            If Not Me._pnlLocked AndAlso Me._clickEnabled Then
                MyBase.OnClick(e)
            End If
        End Sub

        '''' <summary>
        '''' ﾊﾟﾈﾙのﾀﾞﾌﾞﾙｸﾘｯｸｲﾍﾞﾝﾄを無理やりｸﾘｯｸｲﾍﾞﾝﾄに差し替える
        '''' </summary>
        '''' <param name="e">ｲﾍﾞﾝﾄ情報</param>
        'Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        '    If Not Me._pnlLocked Then
        '        MyBase.OnClick(e)
        '    End If
        'End Sub

#End Region

    End Class
End Namespace