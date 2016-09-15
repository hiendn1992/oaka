''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* システム名：ABCDCommon
''* クラス名  ：
''* 処理概要  ：
''*********************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1 14/12/17 1.00  AIT)cuongnc     New
#End Region
''*********************************************************
Imports Bt


Public Class BarcodeObj

#Region " VARIABLE / CONSTANT "

    Dim _ret As Int32 = 0
    Dim _disp As [String] = ""

    Dim _codedataGet As [Byte]()
    Dim _strCodedata As [String] = ""
    Dim _codeLen As Int32 = 0
    'classification
    Dim _symbolGet As UInt16 = 0

#End Region

    ''' <summary>
    ''' ScanEnable
    ''' </summary>
    ''' <remarks>enable scan device</remarks>
    Public Sub ScanEnable()
        _ret = Bt.ScanLib.Control.btScanEnable()
        _ret = Bt.ScanLib.Control.btScanSoftTrigger(1)
    End Sub

    ''' <summary>
    ''' ScanDisable
    ''' </summary>
    ''' <remarks>disable device</remarks>
    Public Sub ScanDisable()
        _ret = Bt.ScanLib.Control.btScanDisable()
    End Sub

    ''' <summary>
    ''' ScanData
    ''' </summary>
    ''' <remarks>scan to get value of barcode</remarks>
    Public Sub ScanData()
        Try
            Dim boolError As Boolean = False
            '-----------------------------------------------------------
            ' Reading (batch)
            '-----------------------------------------------------------
            ' set default is 50 chars, because method btScanGetStringSize return (-300)
            _codeLen = Bt.ScanLib.Control.btScanGetStringSize()
            If _codeLen <= 0 Then
                boolError = True
                CodeLen = 50
                '_disp = "btScanGetStringSize error ret[" & _codeLen & "]"
                'MessageBox.Show(_disp, "Error")
                'GoTo L_END
            End If
            _codedataGet = New Byte(CodeLen - 1) {}

            _ret = Bt.ScanLib.Control.btScanGetString(_codedataGet, _symbolGet)
            If _ret <> LibDef.BT_OK Then
                '_disp = "btScanGetString error ret[" & _ret & "]"
                'MessageBox.Show(_disp, "Error")
                Dim ScanError As New frm_SCANERR("Scan barcode" & vbCrLf & "is" & vbCrLf & "unsuccessful!")
                ScanError.ShowDialog()
                Exit Sub
                GoTo L_END
            End If

            If boolError = True Then
                CodeLen = 0
                For Each i As Byte In _codedataGet
                    If Not i.ToString.Equals("0") Then
                        CodeLen = CodeLen + 1
                    End If
                Next
            End If

            StrCodedata = System.Text.Encoding.GetEncoding(932).GetString(_codedataGet, 0, _codeLen)
L_END:
            If _ret <> LibDef.BT_OK Then
                '_disp = "btScanDisable error ret[" & _ret & "]"
                'MessageBox.Show(_disp, "Error")
                Dim ScanError As New frm_SCANERR("Scan barcode" & vbCrLf & "is" & vbCrLf & "unsuccessful!")
                ScanError.ShowDialog()
                Exit Sub
            End If
        Catch e As Exception
            'MessageBox.Show(e.ToString())
            Dim ScanError As New frm_SCANERR(e.ToString)
            ScanError.ShowDialog()
            Exit Sub
        End Try
    End Sub

    Public Property StrCodedata() As [String]
        Get
            Return _strCodedata
        End Get
        Private Set(ByVal value As [String])
            _strCodedata = value
        End Set
    End Property

    Public Property CodeLen() As [Int32]
        Get
            Return _codeLen
        End Get
        Private Set(ByVal value As [Int32])
            _codeLen = value
        End Set
    End Property
End Class
