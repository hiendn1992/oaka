''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_Menu.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   18-DEC-14    1.00     CuongTK   New
''* 02   05-NOV-15    1.00     CuongTK   Modify
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_MNU001

#Region "Var/Const Form."

    ''' <summary>
    ''' Var login form.
    ''' </summary>
    ''' <remarks></remarks>
    Private scrLgn001 As frm_LGN001

    ''' <summary>
    ''' Var web service.
    ''' </summary>
    ''' <remarks></remarks>
    Public ws As New ABCDService.Service

    ''' <summary>
    ''' Var authority of user login.
    ''' </summary>
    ''' <remarks></remarks>
    Private author As String = String.Empty

#End Region

#Region "New Form."

    ''' <summary>
    ''' New form with param.
    ''' </summary>
    ''' <param name="scrLgn001"></param>
    ''' <param name="authority"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal scrLgn001 As frm_LGN001, _
                   ByVal authority As String)
        '// This call is required by the Windows Form Designer.
        InitializeComponent()
        '// Add any initialization after the InitializeComponent() call.
        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = ABCDConst.STRING_TIMEOUT
        Me.scrLgn001 = scrLgn001
        Select Case authority
            Case "1"
                Me.author = "1"
                Dim titles As New List(Of String)(New String() {"MASTER BUSINESS", _
                                                                "PRODUCTION BUSINESS", _
                                                                "WAREHOUSE BUSINESS", _
                                                                "SHIPMENT BUSINESS", _
                                                                "STOCKTAKING BUSINESS"})
                Call GetNameButtonMenuByAuthority(titles)
                Call ResetColorButton()
                Call ResetColorButton()
                b_menu_01.BackColor = Color.FromArgb(249, 194, 148)
                Dim menuName As String = "MASTER BUSINESS"
                Select Case menuName
                    Case "MASTER BUSINESS"
                        EnableButton()
                        Dim processNames As New List(Of String)(New String() {"User Master Setup", "User Master Inquiry", _
                                                                              "Item Master Setup", "Item Master Inquiry", _
                                                                              "Rack Master Setup", "Rack Master Inquiry", _
                                                                              "Customer Master Setup", "Customer Master Inquiry", _
                                                                              "Reason Master Setup", "Reason Master Inquiry", _
                                                                              "Change User Password", ""})
                        Call GetNameButtonProcess(processNames, Me.author, "MASTER BUSINESS")
                End Select
            Case "2"
                Me.author = "2"
                Dim titles As New List(Of String)(New String() {"MASTER BUSINESS", _
                                                                "PRODUCTION BUSINESS", _
                                                                "WAREHOUSE BUSINESS", _
                                                                "SHIPMENT BUSINESS", _
                                                                "STOCKTAKING BUSINESS"})
                Call GetNameButtonMenuByAuthority(titles)
                Call ResetColorButton()
                Call ResetColorButton()
                b_menu_03.BackColor = Color.FromArgb(249, 194, 148)
                Dim menuName As String = b_menu_03.Text
                Select Case menuName
                    Case "WAREHOUSE BUSINESS"
                        EnableButton()
                        Dim processNames As New List(Of String)(New String() {"Warehouse Inquiry", "Stock In/Out History Report", _
                                                                              "", "", "", "", "", "", "", ""})
                        Call GetNameButtonProcess(processNames, Me.author, "WAREHOUSE BUSINESS")
                End Select
                b_menu_01.Enabled = False '// Error 20150404: Only Mr.Thai change user password.
                b_menu_02.Enabled = False
            Case "3"
                Me.author = "3"
                Dim titles As New List(Of String)(New String() {"MASTER BUSINESS", _
                                                                "PRODUCTION BUSINESS", _
                                                                "WAREHOUSE BUSINESS", _
                                                                "SHIPMENT BUSINESS", _
                                                                "STOCKTAKING BUSINESS"})
                Call GetNameButtonMenuByAuthority(titles)
                Call ResetColorButton()
                Call ResetColorButton()
                b_menu_03.BackColor = Color.FromArgb(249, 194, 148)
                Dim menuName As String = b_menu_03.Text
                Select Case menuName
                    Case "WAREHOUSE BUSINESS"
                        EnableButton()
                        Dim processNames As New List(Of String)(New String() {"Warehouse Inquiry", "Stock In/Out History Report", _
                                                                              "", "", "", "", "", "", "", ""})
                        Call GetNameButtonProcess(processNames, Me.author, "WAREHOUSE BUSINESS")
                End Select
                b_menu_01.Enabled = False '// Error 20150404: Only Mr.Thai change user password.
                b_menu_02.Enabled = False
            Case "4"
                Me.author = "4"
                Dim titles As New List(Of String)(New String() {"MASTER BUSINESS", _
                                                                "PRODUCTION BUSINESS", _
                                                                "WAREHOUSE BUSINESS", _
                                                                "SHIPMENT BUSINESS", _
                                                                "STOCKTAKING BUSINESS"})
                Call GetNameButtonMenuByAuthority(titles)
                Call ResetColorButton()
                Call ResetColorButton()
                b_menu_01.BackColor = Color.FromArgb(249, 194, 148)
                Dim menuName As String = "MASTER BUSINESS"
                Select Case menuName
                    Case "MASTER BUSINESS"
                        EnableButton()
                        Dim processNames As New List(Of String)(New String() {"User Master Setup", "User Master Inquiry", _
                                                                              "Item Master Setup", "Item Master Inquiry", _
                                                                              "Rack Master Setup", "Rack Master Inquiry", _
                                                                              "Customer Master Setup", "Customer Master Inquiry", _
                                                                              "Change User Password", ""})
                        Call GetNameButtonProcess(processNames, Me.author, "MASTER BUSINESS")
                End Select
                'CHG START AIT)CUONGTK 20160314
                b_menu_02.Enabled = False
                If "ABCD".Equals(ABCDCommon.ComCode) Then
                    b_menu_02.Enabled = True
                End If
                'CHG E N D AIT)CUONGTK 20160314
                b_menu_03.Enabled = False
                b_menu_04.Enabled = False
                b_menu_05.Enabled = False
            Case "5"
                Me.author = "5"
                Dim titles As New List(Of String)(New String() {"MASTER BUSINESS", _
                                                                "PRODUCTION BUSINESS", _
                                                                "WAREHOUSE BUSINESS", _
                                                                "SHIPMENT BUSINESS", _
                                                                "STOCKTAKING BUSINESS"})
                GetNameButtonMenuByAuthority(titles)
                Call ResetColorButton()
                Call ResetColorButton()
                b_menu_02.BackColor = Color.FromArgb(249, 194, 148)
                Dim menuName As String = b_menu_02.Text
                Select Case menuName
                    Case "PRODUCTION BUSINESS"
                        EnableButton()
                        Dim processNames As New List(Of String)(New String() {"Production Information Entry", _
                                                                              "Production Information Inquiry", _
                                                                              "Import Production Information", _
                                                                              "Edit Label Information", "Delete Label Information", "Edit Label Information (Same/Different W/O)", "", "", "", ""})
                        Call GetNameButtonProcess(processNames, Me.author, "PRODUCTION BUSINESS")
                        Me.b_process_04.Enabled = False
                End Select
                b_menu_01.Enabled = False '// Error 20150404: Only Mr.Thai change user password.
                b_menu_04.Enabled = False
                b_menu_05.Enabled = False
        End Select
    End Sub

#End Region

#Region "Event Form."

    ''' <summary>
    ''' Event click button Master Business.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_menu_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_menu_01.Click
        Call ResetColorButton()
        b_menu_01.BackColor = Color.FromArgb(249, 194, 148)
        Dim menuName As String = b_menu_01.Text
        Select Case menuName
            Case "MASTER BUSINESS"
                EnableButton()
                Dim processNames As New List(Of String)(New String() {"User Master Setup", "User Master Inquiry", _
                                                                      "Item Master Setup", "Item Master Inquiry", _
                                                                      "Rack Master Setup", "Rack Master Inquiry", _
                                                                      "Customer Master Setup", "Customer Master Inquiry", _
                                                                      "Reason Master Setup", "Reason Master Inquiry", _
                                                                      "Change User Password", ""})
                Call GetNameButtonProcess(processNames, Me.author, "MASTER BUSINESS")
        End Select
    End Sub

    ''' <summary>
    ''' Event click button Production Business.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_menu_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_menu_02.Click
        Call ResetColorButton()
        b_menu_02.BackColor = Color.FromArgb(249, 194, 148)
        Dim menuName As String = b_menu_02.Text
        Select Case menuName
            Case "PRODUCTION BUSINESS"
                EnableButton()
                Dim processNames As New List(Of String)(New String() {"Production Information Entry", _
                                                                      "Production Information Inquiry", _
                                                                      "Import Production Information", _
                                                                      "Edit Label Information", "Delete Label Information", "Edit Label Information (Same/Different W/O)", "", "", "", ""})
                Call GetNameButtonProcess(processNames, Me.author, "PRODUCTION BUSINESS")
                Me.b_process_04.Enabled = False
        End Select
    End Sub

    ''' <summary>
    ''' Event click button Warehouse Business.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_menu_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_menu_03.Click
        Call ResetColorButton()
        b_menu_03.BackColor = Color.FromArgb(249, 194, 148)
        Dim menuName As String = b_menu_03.Text
        Select Case menuName
            Case "WAREHOUSE BUSINESS"
                EnableButton()
                Dim processNames As New List(Of String)(New String() {"Warehouse Inquiry", "Stock In/Out History Report", _
                                                                      "", "", "", "", "", "", "", ""})
                Call GetNameButtonProcess(processNames, Me.author, "WAREHOUSE BUSINESS")
        End Select
    End Sub

    ''' <summary>
    ''' Event click button Shipment Business.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_menu_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_menu_04.Click
        Call ResetColorButton()
        b_menu_04.BackColor = Color.FromArgb(249, 194, 148)
        Dim menuName As String = b_menu_04.Text
        Select Case menuName
            Case "SHIPMENT BUSINESS"
                EnableButton()
                Dim processNames As New List(Of String)(New String() {"Shipment Request Entry", "Shipment Inquiry", _
                                                                      "Shipment Inquiry By Invoice No", "", "", "", "", "", "", ""})
                Call GetNameButtonProcess(processNames, Me.author, "SHIPMENT BUSINESS")
        End Select
    End Sub

    ''' <summary>
    ''' Event click button Stocktaking.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_menu_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_menu_05.Click
        Call ResetColorButton()
        b_menu_05.BackColor = Color.FromArgb(249, 194, 148)
        Dim menuName As String = b_menu_05.Text
        Select Case menuName
            Case "STOCKTAKING BUSINESS"
                EnableButton()
                Dim processNames As New List(Of String)(New String() {"Stocktaking Condition Setup", "Stocktaking List", _
                                                                      "Stocktaking Result Report", "", "", "", "", "", "", ""})
                Call GetNameButtonProcess(processNames, Me.author, "STOCKTAKING BUSINESS")
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     User Master Setup.
    '''     Production Information Entry.
    '''     Warehouse Inquiry.
    '''     Shipment Request Entry
    '''     Stocktaking Condition Setup.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_01.Click
        Dim scrName As String = b_process_01.Text
        Select Case scrName
            Case "User Master Setup"
                Dim msUser As New frm_MSS001
                msUser.Show()
            Case "Production Information Entry"
                Dim ieProduction As New frm_PRS001
                ieProduction.Show()
            Case "Warehouse Inquiry"
                Dim iWarehouse As New frm_WHS002
                iWarehouse.Show()
            Case "Shipment Request Entry"
                Dim reShipment As New frm_SHS001
                reShipment.Show()
            Case "Stocktaking Condition Setup"
                Dim csStocktaking As New frm_STS001
                csStocktaking.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     User Master Inquiry.
    '''     Production Information Inquiry.
    '''     Stock In/Out History Report.
    '''     Stocktaking List.
    '''     Shipment Inquiry.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_02.Click
        Dim scrName As String = b_process_02.Text
        Select Case scrName
            Case "User Master Inquiry"
                Dim miUser As New frm_MSS006
                miUser.Show()
            Case "Production Information Inquiry"
                Dim iiProduction As New frm_PRS002
                iiProduction.Show()
            Case "Stock In/Out History Report"
                Dim hrStockInOut As New frm_WHS003
                hrStockInOut.Show()
            Case "Stocktaking List"
                Dim ds As DataSet = Nothing
                ds = ws.GetStockReqInfoTr(ABCDCommon.UserId)
                If ds.Tables(0).Rows.Count = 0 Then
                    Dim strError As String = Messages.ERR013
                    Dim frm_msg As New frm_MSG001(strError, "ERR013")
                    If frm_msg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        frm_msg.Close()
                        Return
                    End If
                End If
                Dim lStocktaking As New frm_STS002
                lStocktaking.Show()
            Case "Shipment Inquiry"
                Dim iShipment As New frm_SHS006
                iShipment.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Item Master Setup.
    '''     Import Production Information.
    '''     Stocktaking Result Report.
    '''     Shipment Inquiry By Invoice No.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_03.Click
        Dim scrName As String = b_process_03.Text
        Select Case scrName
            Case "Item Master Setup"
                Dim msItem As New frm_MSS003
                msItem.Show()
            Case "Import Production Information"
                Dim piImport As New frm_PRS003
                piImport.Show()
            Case "Stocktaking Result Report"
                Dim ds As DataSet = Nothing
                Try
                    ds = ws.GetStockReqInfoTr(ABCDCommon.UserId)
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim frm As New frm_STS003(ds)
                        frm.Show()
                    Else
                        Dim frm As New frm_MSG001(Messages.ERR013, "ERR013")
                        frm.Show()
                    End If
                Catch ex As Exception
                    Dim frm As New frm_MSG001(ex.Message, "ERR9004")
                    frm.Show()
                Finally
                    ws.Dispose()
                    ds.Dispose()
                    ds = Nothing
                End Try
            Case "Shipment Inquiry By Invoice No" '// Cuongtk - 20150820: add new screen [SHS004]
                Dim shipmentInquiryByInvoiceNo As New SHS004
                shipmentInquiryByInvoiceNo.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Item Master Inquiry.
    '''     Edit Label Information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_04.Click
        Dim scrName As String = b_process_04.Text
        Select Case scrName
            Case "Item Master Inquiry"
                Dim miItem As New frm_MSS007
                miItem.Show()

            Case "Edit Label Information"
                Dim editLabelInfo As New frm_PRS004
                editLabelInfo.Show()

        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Rack Master Setup.
    '''     Delete Label Information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_05.Click
        Dim scrName As String = b_process_05.Text
        Select Case scrName
            Case "Rack Master Setup"
                Dim msWarehouse As New frm_MSS004
                msWarehouse.Show()
            Case "Delete Label Information"
                Dim deleteLabelInformation As New frm_PRS005()
                deleteLabelInformation.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Rack Master Inquiry.
    '''     Edit Label Info(Same/Different W/O).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_06.Click
        Dim scrName As String = b_process_06.Text
        Select Case scrName
            Case "Rack Master Inquiry"
                Dim miWarehouse As New frm_MSS008
                miWarehouse.Show()
            Case "Edit Label Information (Same/Different W/O)" '// Click button execute edit label another WO.
                '// 05-NOV-15 - start.
                Dim prs006 As New frm_PRS006()
                prs006.Show()
                '// 05-NOV-15 - end.
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Customer Master Setup.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_07.Click
        Dim scrName As String = b_process_07.Text
        Select Case scrName
            Case "Customer Master Setup"
                Dim msCustomer As New frm_MSS005
                msCustomer.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Customer Master Inquiry.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_08.Click
        Dim scrName As String = b_process_08.Text
        Select Case scrName
            Case "Customer Master Inquiry"
                Dim miCustomer As New frm_MSS009
                miCustomer.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Change User Password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_09.Click
        Dim scrName As String = b_process_09.Text
        Select Case scrName
            Case "Change User Password"
                Dim upChange As New frm_MSS002
                upChange.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button process.
    '''     Change User Password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_09.Click
        Dim scrName As String = b_process_09.Text
        Select Case scrName
            Case "Change User Password"
                Dim upChange As New frm_MSS002
                upChange.Show()
            Case "Reason Master Setup"
                Dim msReason As New frm_OA_MSS002
                msReason.Show()
        End Select
    End Sub

    ''' <summary>
    ''' Event click button for future.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_process_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_process_10.Click
        Dim scrName As String = b_process_10.Text
        Select Case scrName
            Case "Reason Master Inquiry"
                Dim iReason As New frm_OA_MSS003
                iReason.Show()
        End Select
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_return_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_return.Click
        Me.scrLgn001.Visible = True
        Me.Hide()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_MNU001_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.scrLgn001.Visible = True
        Me.Hide()
    End Sub

#End Region

#Region "Function Form."

    ''' <summary>
    ''' Function get name button menu in left form.
    ''' </summary>
    ''' <param name="titles"></param>
    ''' <remarks></remarks>
    Private Sub GetNameButtonMenuByAuthority(ByVal titles As List(Of String))
        b_menu_01.Text = titles(0)
        b_menu_02.Text = titles(1)
        b_menu_03.Text = titles(2)
        b_menu_04.Text = titles(3)
        b_menu_05.Text = titles(4)
    End Sub

    ''' <summary>
    ''' Function get name button menu in right form.
    ''' </summary>
    ''' <param name="titles"></param>
    ''' <param name="paramAuthor"></param>
    ''' <param name="buttonName"></param>
    ''' <remarks></remarks>
    Private Sub GetNameButtonProcess(ByVal titles As List(Of String), ByVal paramAuthor As String, ByVal buttonName As String)
        Call ClearAllNameButtonProcess()
        b_process_01.Text = titles(0)
        b_process_02.Text = titles(1)
        b_process_03.Text = titles(2)
        b_process_04.Text = titles(3)
        b_process_05.Text = titles(4)
        b_process_06.Text = titles(5)
        b_process_07.Text = titles(6)
        b_process_08.Text = titles(7)
        b_process_09.Text = titles(8)
        b_process_10.Text = titles(9)
        If (titles.Count() > 10) Then
            b_process_11.Text = titles(10)
        End If
        If (titles.Count() > 11) Then
            b_process_12.Text = titles(11)
        End If
        If (paramAuthor.Equals("5") Or paramAuthor.Equals("2") Or paramAuthor.Equals("3")) And buttonName.Equals("MASTER BUSINESS") Then
            b_process_01.Enabled = False
            b_process_02.Enabled = False
            b_process_03.Enabled = False
            b_process_04.Enabled = False
            b_process_05.Enabled = False
            b_process_06.Enabled = False
            b_process_07.Enabled = False
            b_process_08.Enabled = False
            b_process_10.Enabled = False
            b_process_11.Enabled = False
            b_process_12.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Function clear all name button menu in right form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllNameButtonProcess()
        b_process_01.Text = ""
        b_process_02.Text = ""
        b_process_03.Text = ""
        b_process_04.Text = ""
        b_process_05.Text = ""
        b_process_06.Text = ""
        b_process_07.Text = ""
        b_process_08.Text = ""
        b_process_09.Text = ""
        b_process_10.Text = ""
        b_process_11.Text = ""
        b_process_12.Text = ""
    End Sub

    ''' <summary>
    ''' Function reset color button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetColorButton()
        b_menu_01.BackColor = Color.FromArgb(179, 219, 229)
        b_menu_02.BackColor = Color.FromArgb(179, 219, 229)
        b_menu_03.BackColor = Color.FromArgb(179, 219, 229)
        b_menu_04.BackColor = Color.FromArgb(179, 219, 229)
        b_menu_05.BackColor = Color.FromArgb(179, 219, 229)
    End Sub

    ''' <summary>
    ''' Function enable button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableButton()
        b_process_01.Enabled = True
        b_process_02.Enabled = True
        b_process_03.Enabled = True
        b_process_04.Enabled = True
        b_process_05.Enabled = True
        b_process_06.Enabled = True
        b_process_07.Enabled = True
        b_process_08.Enabled = True
        b_process_10.Enabled = True
        b_process_11.Enabled = True
        b_process_12.Enabled = True
    End Sub

#End Region

End Class