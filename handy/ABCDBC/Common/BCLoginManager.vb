Imports jp.co.ait.common

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
Namespace common

    ''' <summary>
    ''' ���O�C�����N���X
    ''' </summary>
    Public Class BCLoginManager
        Inherits ABCDBCBase

        ''' <summary>���O�C�����</summary>
        Private Shared _LoginInfo As BCLoginInfo

        Private Shared _ImportW900Count As Integer = 0

        Private Shared _ImportFGW830Count As Integer = 0

        Private Shared _ExportW900Count As Integer = 0

        Private Shared _SetRackW830Count As Integer = 0

        Private Shared _RejectW900Count As Integer = 0

        Private Shared _RejectW830Count As Integer = 0

        Private Shared _RetrieveW900Count As Integer = 0

        Private Shared _StocktakingW900Count As Integer = 0

        Private Shared _StocktakingW830Count As Integer = 0

        Private Shared _StockDeleteW830Count As Integer = 0

        Private Shared _StockMoveW830Count As Integer = 0

        Private Shared _ShipmentCount As Integer = 0

        Private Shared _SubConCount As Integer = 0

        Private Shared _ShipmentReturnCount As Integer = 0

        Private Shared m_returnW900Count As Integer = 0 '// #No.23: count item return W900

        Private Shared _MenuW900OrFG As String = ""

        ''' <summary>
        ''' ���O�C�����
        ''' </summary>
        ''' <returns>True�F���O�C���ς݁@False�F�����O�C��</returns>
        Public Shared Function IsLogin() As Boolean
            If _LoginInfo Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Function

        ''' <summary>
        ''' ���O�C�����̎擾
        ''' </summary>
        ''' <returns>���O�C�����</returns>
        Public Shared Function GetLoginInfo() As BCLoginInfo
            Return _LoginInfo
        End Function

        ''' <summary>
        ''' ���O�C�����N���X�̍쐬
        ''' </summary>
        ''' <param name="UserID">�o�^�������[�UID</param>
        ''' <returns>���O�C�����N���X�C���X�^���X</returns>
        Public Shared Function CreateLoginInfo(ByVal UserID As String, ByVal authority As String) As BCLoginInfo
            _LoginInfo = New BCLoginInfo(UserID, authority)
            Return _LoginInfo
        End Function

        ''' <summary>
        ''' Show menu form with authority
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub ShowMenuForm()
            Dim strAuthority As String = BCLoginManager.GetLoginInfo.Authority
            If ("1".Equals(strAuthority) And "2".Equals(_MenuW900OrFG)) Or "2".Equals(strAuthority) Then
                Dim frm_Menu002 As New frm_Menu002
                frm_Menu002.Show()
            ElseIf ("1".Equals(strAuthority) And "3".Equals(_MenuW900OrFG)) Or "3".Equals(strAuthority) Then
                Dim frm_Menu003 As New frm_Menu003
                frm_Menu003.Show()
            End If
        End Sub

        ''' <summary>
        ''' ImportFGW830Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ImportFGW830Count() As Integer
            Get
                Return _ImportFGW830Count
            End Get
            Set(ByVal value As Integer)
                _ImportFGW830Count = value
            End Set
        End Property

        ''' <summary>
        ''' SetRackW830Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property SetRackW830Count() As Integer
            Get
                Return _SetRackW830Count
            End Get
            Set(ByVal value As Integer)
                _SetRackW830Count = value
            End Set
        End Property


        ''' <summary>
        ''' ImportW900Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ImportW900Count() As Integer
            Get
                Return _ImportW900Count
            End Get
            Set(ByVal value As Integer)
                _ImportW900Count = value
            End Set
        End Property

        ''' <summary>
        ''' ExportW900Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ExportW900Count() As Integer
            Get
                Return _ExportW900Count
            End Get
            Set(ByVal value As Integer)
                _ExportW900Count = value
            End Set
        End Property

        ''' <summary>
        ''' RejectW900Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property RejectW900Count() As Integer
            Get
                Return _RejectW900Count
            End Get
            Set(ByVal value As Integer)
                _RejectW900Count = value
            End Set
        End Property

        ''' <summary>
        ''' RejectW830Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property RejectW830Count() As Integer
            Get
                Return _RejectW830Count
            End Get
            Set(ByVal value As Integer)
                _RejectW830Count = value
            End Set
        End Property


        ''' <summary>
        ''' RetrieveW900Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property RetrieveW900Count() As Integer
            Get
                Return _RetrieveW900Count
            End Get
            Set(ByVal value As Integer)
                _RetrieveW900Count = value
            End Set
        End Property

        ''' <summary>
        ''' RetrieveW900Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property MenuW900OrFG() As String
            Get
                Return _MenuW900OrFG
            End Get
            Set(ByVal value As String)
                _MenuW900OrFG = value
            End Set
        End Property

        ''' <summary>
        ''' StocktakingW900Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property StocktakingW900Count() As Integer
            Get
                Return _StocktakingW900Count
            End Get
            Set(ByVal value As Integer)
                _StocktakingW900Count = value
            End Set
        End Property

        ''' <summary>
        ''' StocktakingW830Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property StocktakingW830Count() As Integer
            Get
                Return _StocktakingW830Count
            End Get
            Set(ByVal value As Integer)
                _StocktakingW830Count = value
            End Set
        End Property

        ''' <summary>
        ''' ShipmentCount
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ShipmentCount() As Integer
            Get
                Return _ShipmentCount
            End Get
            Set(ByVal value As Integer)
                _ShipmentCount = value
            End Set
        End Property

        ''' <summary>
        ''' StockDeleteW830Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property StockDeleteW830Count() As Integer
            Get
                Return _StockDeleteW830Count
            End Get
            Set(ByVal value As Integer)
                _StockDeleteW830Count = value
            End Set
        End Property

        ''' <summary>
        ''' StockMoveW830Count
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property StockMoveW830Count() As Integer
            Get
                Return _StockMoveW830Count
            End Get
            Set(ByVal value As Integer)
                _StockMoveW830Count = value
            End Set
        End Property

        Public Shared Property SubConCount() As Integer
            Get
                Return _SubConCount
            End Get
            Set(ByVal value As Integer)
                _SubConCount = value
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ShipmentReturnCount() As Integer
            Get
                Return _ShipmentReturnCount
            End Get
            Set(ByVal value As Integer)
                _ShipmentReturnCount = value
            End Set
        End Property

        ''' <summary>
        ''' Get and set count W900 #No.23 [cuongtk (20150825)]
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ReturnW900Count() As Integer
            Get
                Return m_returnW900Count
            End Get
            Set(ByVal value As Integer)
                m_returnW900Count = value
            End Set
        End Property

    End Class
End Namespace
