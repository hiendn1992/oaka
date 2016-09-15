''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* �V�X�e�����FABCDCommon
''* �N���X��  �F
''* �����T�v  �F
''*********************************************************
''* �����F
''* NO   ���t   Ver  �X�V��          ���e
#Region "�F���C������"
''* 1 14/12/15 1.00  AIT)cuongnc     New
#End Region
''*********************************************************

Imports System.IO
Imports System.Xml

Namespace jp.co.ait.common

    ''' <summary>
    ''' xml�t�@�C���Ǘ��N���X
    ''' </summary>
    Public Class ABCDBCXmlManager
        Inherits ABCDBCBase

        Private _xmlDoc As XmlDocument

        ''' <summary>
        ''' xmļ���߽
        ''' </summary>
        Private _strXmlFileName As String

        ''' <summary>
        ''' �R���X�g���N�^
        ''' </summary>
        ''' <param name="strXmlFileName">xml�t�@�C���̃p�X</param>
        Public Sub New(ByVal strXmlFileName As String)

            If String.IsNullOrEmpty(strXmlFileName) Then
                Throw New ArgumentException("xml�t�@�C���p�X���s���ł��BstrXmlFileName= " & strXmlFileName, "strXmlFileName")
            End If

            WriteDebugLog("xml�t�@�C���̃p�X:" & strXmlFileName)

            '' �����o�ϐ��ɃZ�b�g
            _xmlDoc = New XmlDocument

            Try
                _xmlDoc.Load(strXmlFileName)
                _strXmlFileName = strXmlFileName
            Catch ex As XmlException
                WriteErrorLog(ex)
                Throw ex
            End Try


        End Sub


        ''' <summary>
        ''' xml�t�@�C������text�̒l���擾���܂��B
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>text�̒l</returns>
        Public Function ReadString(ByVal xPath As String) As String

            Dim strList() As String = ReadStringList(xPath)
            If strList.Length = 0 Then
                Return String.Empty
            End If

            Return strList(0)

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


            WriteDebugLog("xPath:" & xPath)
            Try
                Dim xmlNodeList As XmlNodeList = _xmlDoc.SelectNodes("descendant::" & xPath)
                Dim intCount As Integer = xmlNodeList.Count
                If intCount = 0 Then
                    Return New String() {}
                End If

                Dim i As Integer
                Dim lst As New ArrayList(intCount)
                For i = 0 To intCount - 1
                    lst.Add(xmlNodeList(i).InnerText)
                Next
                Dim strRet(lst.Count - 1) As String
                Array.Copy(lst.ToArray(), strRet, lst.Count)
                Return strRet

            Catch ex As Exception
                Return New String() {}
            End Try

        End Function


        ''' <summary>
        '''  xml�t�@�C�����瑮���l���擾
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <param name="name">������</param>
        ''' <returns>�����l(������)</returns>
        Public Function ReadAttribute(ByVal xPath As String, ByVal name As String) As String


            Dim strList() As String = ReadAttributeList(xPath, name)
            If strList.Length = 0 Then
                Return String.Empty
            End If

            Return strList(0)

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
            WriteDebugLog("xPath:" & xPath & "name:" & name)

            Dim xmlNodeList As XmlNodeList = _xmlDoc.SelectNodes("descendant::" & xPath)
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
            Dim strRet(lst.Count - 1) As String
            Array.Copy(lst.ToArray(), strRet, lst.Count)
            Return strRet
        End Function


        ''' <summary>
        '''  xml�t�@�C������l���擾(�����l����擾)
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <param name="name">������</param>
        ''' <returns>�����l(���l)</returns>
        Public Function ReadAttributeInteger(ByVal xPath As String, ByVal name As String) As Integer

            Dim strList As String = ReadAttribute(xPath, name)

            Dim intValue As Integer
            'If BSWNumeric.IsNumericValue(strList) = True Then
            '    intValue = BSWNumeric.GetIntegerValue(strList)
            '    Return intValue
            'Else
            '    Return 0
            'End If
            If IsNumeric(strList) = True Then
                intValue = CInt(strList)
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
        Public Function ReadAttributeBoolean(ByVal xPath As String, ByVal name As String) As Boolean

            Dim strList As String = ReadAttribute(xPath, name)
            Dim blnRet As Boolean

            Try
                blnRet = Boolean.Parse(strList)
            Catch ex As Exception
                blnRet = False
            End Try

            If blnRet = True Then
                Return blnRet
            Else
                Return False
            End If

        End Function


        ''' <summary>
        ''' �\���t�@�C�������擾
        ''' </summary>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>�擾���</returns>
        Public Shared Function GetFileData(ByVal xPath As String) As String

            Return GetFileData(ABCDBCCommon.GetCurrentDir() & ABCDBCConst.APP_CONFIG_FILE, xPath)
        End Function


        ''' <summary>
        ''' xml�t�@�C�������擾
        ''' </summary>
        ''' <param name="strFileName">xml�t�@�C���p�X</param>
        ''' <param name="xPath">�擾�������v�f�܂ł̃p�X</param>
        ''' <returns>�擾���</returns>
        Public Shared Function GetFileData(ByVal strFileName As String, ByVal xPath As String) As String

            Dim xmlManager As ABCDBCXmlManager = New ABCDBCXmlManager(strFileName)
            Dim strValue As String = xmlManager.ReadString(xPath)
            Return strValue
        End Function

        ''' <summary>
        ''' xml�t�@�C���ɒl���������݂܂�
        ''' </summary>
        ''' <param name="strFileName">xml�t�@�C���p�X</param>
        ''' <param name="xPath">�ۑ�����v�f�̃p�X</param>
        ''' <param name="val">�����l</param>
        Public Shared Sub WriteString(ByVal strFileName As String, ByVal xPath As String, ByVal val As String)

            Dim xmlManager As ABCDBCXmlManager = New ABCDBCXmlManager(strFileName)
            xmlManager.WriteString(xPath, val)

        End Sub

        ''' <summary>
        ''' xml�t�@�C���ɒl���������݂܂�
        ''' </summary>
        ''' <param name="xPath">�ۑ�����v�f�̃p�X</param>
        ''' <param name="val">�����l</param>
        Public Sub WriteString(ByVal xPath As String, ByVal val As String)

            If String.IsNullOrEmpty(xPath) Then
                Throw New ArgumentException("xPath���s���ł��BxPath=" & xPath, "xPath")
            End If

            Dim strList() As String = xPath.Split("/"c)
            Dim xmlNodeList As XmlNodeList = Nothing
            Dim strSelectList As String = strList(0)
            Dim strParentNode As String = Nothing
            Dim xmlCreateElement As XmlElement = Nothing
            Dim i As Integer

            For i = 0 To strList.Length - 1
                If 0 < i Then
                    strParentNode = strSelectList
                    strSelectList = strSelectList & "/" & strList(i)
                End If
                xmlNodeList = _xmlDoc.SelectNodes("descendant::" & strSelectList)


                If xmlNodeList.Count = 0 Then

                    If i = 0 Then
                        xmlCreateElement = _xmlDoc.CreateElement(strList(i))
                        _xmlDoc.ChildNodes(_xmlDoc.ChildNodes().Count - 1).AppendChild(xmlCreateElement)

                    Else
                        Dim ChildElement As XmlElement = _xmlDoc.CreateElement(strList(i))
                        If xmlCreateElement Is Nothing Then
                            xmlNodeList = _xmlDoc.SelectNodes("descendant::" & strParentNode)

                            xmlNodeList(0).AppendChild(ChildElement)
                        Else
                            xmlCreateElement.AppendChild(ChildElement)
                        End If
                    End If

                End If
            Next

            xmlNodeList = _xmlDoc.SelectNodes("descendant::" & xPath)
            xmlNodeList(0).InnerText = val


        End Sub

        ''' <summary>
        ''' xml�t�@�C���ɒl���������݂܂�
        ''' </summary>
        ''' <param name="xPath">�ۑ�����v�f�̃p�X</param>
        ''' <param name="val">�����l</param>
        Public Sub WriteString(ByVal xPath As String, ByVal val() As String)

            If String.IsNullOrEmpty(xPath) Then
                Throw New ArgumentException("xPath���s���ł��BxPath=" & xPath, "xPath")
            End If

            Dim count As Integer
            Dim strVal As String = String.Empty
            Dim i As Integer

            If val Is Nothing Then
                count = 0
            Else
                count = val.Length - 1
                If IsDump() = True Then
                    For i = 0 To count
                    Next
                End If
            End If

            Dim xmlNodeList As XmlNodeList = Nothing
            Dim strParentNode As String = Nothing
            Dim loginElement As XmlElement = Nothing
            Dim strList() As String = xPath.Split("/"c)


            Dim j As Integer
            For j = 0 To count
                Dim strSelectList As String = strList(0)
                For i = 0 To strList.Length - 1

                    If 0 < i Then
                        strParentNode = strSelectList
                        strSelectList = strSelectList & "/" & strList(i)
                    End If

                    If i <> strList.Length - 1 Then
                        xmlNodeList = _xmlDoc.SelectNodes("descendant::" & strSelectList)
                        If xmlNodeList.Count <> 0 Then
                            Continue For
                        End If
                    End If

                    If i = 0 Then
                        loginElement = _xmlDoc.CreateElement(strList(i))
                        _xmlDoc.ChildNodes(_xmlDoc.ChildNodes().Count - 1).AppendChild(loginElement)
                    Else
                        Dim ChildElement As XmlElement = _xmlDoc.CreateElement(strList(i))
                        If loginElement Is Nothing Then
                            xmlNodeList = _xmlDoc.SelectNodes("descendant::" & strParentNode)
                            xmlNodeList(0).AppendChild(ChildElement)
                        Else
                            loginElement.AppendChild(ChildElement)
                        End If
                    End If
                Next

                xmlNodeList = _xmlDoc.SelectNodes("descendant::" & xPath)

                If Not val Is Nothing Then
                    strVal = val(j)
                End If
                xmlNodeList(xmlNodeList.Count - 1).InnerText = strVal
            Next
        End Sub

        ''' <summary>
        ''' xml�t�@�C���ɒl���������݂܂�
        ''' </summary>
        ''' <param name="xPath">�ۑ�����v�f�̃p�X</param>
        ''' <param name="name">������</param>
        ''' <param name="val">�����l</param>

        Public Sub WriteAttribute(ByVal xPath As String, ByVal name As String, ByVal val As String)
            If String.IsNullOrEmpty(name) Then
                Throw New ArgumentException("name���s���ł��Bname=" & name, "name")
            End If

            WriteString(xPath, String.Empty)
            Dim idAttr As XmlAttribute = _xmlDoc.CreateAttribute(name)
            idAttr.Value = val


            Dim xmlNodeList As XmlNodeList = _xmlDoc.SelectNodes("descendant::" & xPath)
            xmlNodeList(0).Attributes.Append(idAttr)

        End Sub

        ''' <summary>
        ''' xml�t�@�C���ɒl���������݂܂�
        ''' </summary>
        ''' <param name="xPath">�ۑ�����v�f�̃p�X</param>
        ''' <param name="name">������</param>
        ''' <param name="val">�����l</param>

        Public Sub WriteAttribute(ByVal xPath As String, ByVal name As String, ByVal val() As String)
            If String.IsNullOrEmpty(name) Then
                Throw New ArgumentException("name���s���ł��Bname=" & name, "name")
            End If

            Dim str() As String = Nothing
            Dim i As Integer

            For i = 0 To val.Length - 1
                WriteString(xPath, str)

                Dim idAttr As XmlAttribute = _xmlDoc.CreateAttribute(name)
                idAttr.Value = val(i)

                Dim xmlNodeList As XmlNodeList = _xmlDoc.SelectNodes("descendant::" & xPath)
                xmlNodeList(xmlNodeList.Count - 1).Attributes.Append(idAttr)
            Next

        End Sub

        ''' <summary>
        ''' �ǂݍ���xmļ�ق��㏑�����܂��B
        ''' </summary>
        Public Sub Save()
            Save(_strXmlFileName)
        End Sub

        ''' <summary>
        ''' �w�肵��̧�ق�xml�f�[�^���o�͂��܂��B
        ''' </summary>
        ''' <param name="dir">�Z�[�u������xml�t�@�C���܂ł̃t���p�X</param>
        Public Sub Save(ByVal dir As String)

            If String.IsNullOrEmpty(dir) Then
                Throw New ArgumentException("̧���߽���s���ł��Bdir=" & dir, "dir")
            End If

            Try
                _xmlDoc.Save(dir)
            Catch ex As Exception
                WriteErrorLog(ex)
                Throw ex
            End Try
        End Sub

    End Class
End Namespace