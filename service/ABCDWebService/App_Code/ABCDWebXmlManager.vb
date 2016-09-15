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

Imports System.IO
Imports System.Xml

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' xmlファイル管理クラス
    ''' </summary>
    Public Class ABCDWebXmlManager
        Inherits ABCDWebBase

#Region "ユーザ宣言"

        ''' <summary>xmlファイル</summary>
        Private _xmlDoc As XmlDocument

#End Region

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        Public Sub New()
            Dim xmlFileName As String = GetXMLDir() & ABCDWebConst.APP_CONFIG_FILE

            CreateXMLDoc(xmlFileName)
        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="xmlFileName">xmlファイルのパス</param>
        Public Sub New(ByVal xmlFileName As String)

            If String.IsNullOrEmpty(xmlFileName) Then
                Throw New ArgumentException("xmlファイルパスが不正です。xmlFileName= " & xmlFileName, "xmlFileName")
            End If

            CreateXMLDoc(xmlFileName)

        End Sub

#End Region

#Region "ユーザ関数定義"

        ''' <summary>
        ''' XmlDocumentを作成
        ''' </summary>
        Private Sub CreateXMLDoc(ByVal xmlFileName As String)
            '' メンバ変数にセット
            Me._xmlDoc = New XmlDocument
            Me._xmlDoc.Load(xmlFileName)

        End Sub

        ''' <summary>
        ''' xmlファイルからtextの値を取得します。
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <returns>textの値</returns>
        Public Function ReadString(ByVal xPath As String) As String

            Dim list() As String = ReadStringList(xPath)
            If list.Length = 0 Then
                Return String.Empty
            End If

            Return list(0)

        End Function

        ''' <summary>
        ''' xmlファイルからtextの値を取得します(複数)
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <returns>textの値</returns>
        Public Function ReadStringList(ByVal xPath As String) As String()

            If String.IsNullOrEmpty(xPath) Then
                Throw New ArgumentException("xPathが不正です。xPath=" & xPath, "xPath")
            End If

            Dim xmlNodeList As XmlNodeList = Me._xmlDoc.SelectNodes("descendant::" & xPath)
            Dim count As Integer = xmlNodeList.Count
            If count = 0 Then
                Return New String() {}
            End If

            Dim i As Integer
            Dim lst As New ArrayList(count)
            For i = 0 To count - 1
                lst.Add(xmlNodeList(i).InnerText)
            Next
            Dim ret(lst.Count - 1) As String
            Array.Copy(lst.ToArray(), ret, lst.Count)
            Return ret

        End Function

        ''' <summary>
        '''  xmlファイルから属性値を取得
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <param name="name">属性名</param>
        ''' <returns>属性値(文字列)</returns>
        Public Function ReadAttribute(ByVal xPath As String, _
                                      ByVal name As String) As String

            Dim list() As String = ReadAttributeList(xPath, name)
            If list.Length = 0 Then
                Return String.Empty
            End If

            Return list(0)

        End Function

        ''' <summary>
        ''' xmlファイルから属性値を取得(複数)
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <param name="name">属性名</param>
        ''' <returns>属性値(文字列)</returns>
        Public Function ReadAttributeList(ByVal xPath As String, _
                                          ByVal name As String) As String()

            If String.IsNullOrEmpty(xPath) Then
                Throw New ArgumentException("xPathが不正です。xPath=" & xPath, "xPath")
            End If

            If String.IsNullOrEmpty(name) Then
                Throw New ArgumentException("nameが不正です。name= " & name, "name")
            End If

            Dim xmlNodeList As XmlNodeList = Me._xmlDoc.SelectNodes("descendant::" & xPath)
            Dim intCount As Integer = xmlNodeList.Count
            If intCount = 0 Then
                Return New String() {}
            End If

            Dim i As Integer
            Dim lst As New ArrayList(intCount)
            For i = 0 To intCount - 1
                Dim attribute As XmlAttribute = xmlNodeList(i).Attributes(name)
                If attribute Is Nothing Then
                    lst.Add(Nothing)
                Else
                    lst.Add(attribute.Value)
                End If

            Next
            Dim ret(lst.Count - 1) As String
            Array.Copy(lst.ToArray(), ret, lst.Count)
            Return ret

        End Function

        ''' <summary>
        '''  xmlファイルから値を取得(属性値から取得)
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <param name="name">属性名</param>
        ''' <returns>属性値(数値)</returns>
        Public Function ReadAttributeInteger(ByVal xPath As String, _
                                             ByVal name As String) As Integer

            Dim list As String = ReadAttribute(xPath, name)

            Dim intValue As Integer

            If IsNumeric(list) = True Then
                intValue = CInt(list)
                Return intValue
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' xmlファイルから値を取得(属性値から取得)
        ''' </summary>
        ''' <param name="xPath">取得したい要素までのパス</param>
        ''' <param name="name">属性名</param>
        ''' <returns>属性値(Boolean)</returns>
        Public Function ReadAttributeBoolean(ByVal xPath As String, _
                                             ByVal name As String) As Boolean

            Dim list As String = ReadAttribute(xPath, name)
            Dim isRet As Boolean
            If Boolean.TryParse(list, isRet) = True Then
                Return isRet
            Else
                Return False
            End If

        End Function

#End Region

    End Class

End Namespace