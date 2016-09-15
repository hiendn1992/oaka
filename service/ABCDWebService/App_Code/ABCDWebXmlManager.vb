''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* �V�X�e�����FABCD_Barcode_System
''* �N���X��  �FABCDWebService
''* �����T�v  �FBC�[���̗v�����A�Ɩ����s��
''*********************************************************
''* �����F
''* NO   ���t   Ver  �X�V��          ���e
#Region "�F���C������"
''* 1 14/12/12 1.00  AIT)cuongnc     New
#End Region
''*********************************************************

Imports System.IO
Imports System.Xml

Namespace jp.co.ait.WebService

    ''' <summary>
    ''' xml�t�@�C���Ǘ��N���X
    ''' </summary>
    Public Class ABCDWebXmlManager
        Inherits ABCDWebBase

#Region "���[�U�錾"

        ''' <summary>xml�t�@�C��</summary>
        Private _xmlDoc As XmlDocument

#End Region

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        Public Sub New()
            Dim xmlFileName As String = GetXMLDir() & ABCDWebConst.APP_CONFIG_FILE

            CreateXMLDoc(xmlFileName)
        End Sub

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <param name="xmlFileName">xml�t�@�C���̃p�X</param>
        Public Sub New(ByVal xmlFileName As String)

            If String.IsNullOrEmpty(xmlFileName) Then
                Throw New ArgumentException("xml�t�@�C���p�X���s���ł��BxmlFileName= " & xmlFileName, "xmlFileName")
            End If

            CreateXMLDoc(xmlFileName)

        End Sub

#End Region

#Region "���[�U�֐���`"

        ''' <summary>
        ''' XmlDocument���쐬
        ''' </summary>
        Private Sub CreateXMLDoc(ByVal xmlFileName As String)
            '' �����o�ϐ��ɃZ�b�g
            Me._xmlDoc = New XmlDocument
            Me._xmlDoc.Load(xmlFileName)

        End Sub

        ''' <summary>
        ''' xml�t�@�C������text�̒l���擾���܂��B
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>text�̒l</returns>
        Public Function ReadString(ByVal xPath As String) As String

            Dim list() As String = ReadStringList(xPath)
            If list.Length = 0 Then
                Return String.Empty
            End If

            Return list(0)

        End Function

        ''' <summary>
        ''' xml�t�@�C������text�̒l���擾���܂�(����)
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>text�̒l</returns>
        Public Function ReadStringList(ByVal xPath As String) As String()

            If String.IsNullOrEmpty(xPath) Then
                Throw New ArgumentException("xPath���s���ł��BxPath=" & xPath, "xPath")
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
        '''  xml�t�@�C�����瑮���l���擾
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <param name="name">������</param>
        ''' <returns>�����l(������)</returns>
        Public Function ReadAttribute(ByVal xPath As String, _
                                      ByVal name As String) As String

            Dim list() As String = ReadAttributeList(xPath, name)
            If list.Length = 0 Then
                Return String.Empty
            End If

            Return list(0)

        End Function

        ''' <summary>
        ''' xml�t�@�C�����瑮���l���擾(����)
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <param name="name">������</param>
        ''' <returns>�����l(������)</returns>
        Public Function ReadAttributeList(ByVal xPath As String, _
                                          ByVal name As String) As String()

            If String.IsNullOrEmpty(xPath) Then
                Throw New ArgumentException("xPath���s���ł��BxPath=" & xPath, "xPath")
            End If

            If String.IsNullOrEmpty(name) Then
                Throw New ArgumentException("name���s���ł��Bname= " & name, "name")
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
        '''  xml�t�@�C������l���擾(�����l����擾)
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <param name="name">������</param>
        ''' <returns>�����l(���l)</returns>
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
        ''' xml�t�@�C������l���擾(�����l����擾)
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <param name="name">������</param>
        ''' <returns>�����l(Boolean)</returns>
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