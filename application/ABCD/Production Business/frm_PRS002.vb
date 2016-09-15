''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_PRS002.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   10-JAN-16    1.00    Hungtg   New
''*********************************************************
Imports ABCD.My.Resources.Messages
Imports ABCD.ABCDConst
Imports ABCD.ABCDCommon

Imports System.Configuration.ConfigurationManager

Public Class frm_PRS002

    Private webService As ABCDService.Service
    Private dataTable As DataTable
    Private display As Integer
    Private mode As Integer

    Private m_commonDate As String = DateTime.Now.ToString() '// Convert date to string with format

    Private Const NEW_ISSUE As String = "-ISSUEMODE"
    Private Const VAR_CHAR1 As String = "_"
    Private Const RE_ISSUE As String = "-REISSUEMODE"
    Private Const PATTERN_TYPE_7 As String = "7" '20160701 Phungntm start

#Region "New Method"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetSetDisplay() As Integer
        Get
            Return display
        End Get
        Set(ByVal value As Integer)
            display = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetSetMode() As Integer
        Get
            Return mode
        End Get
        Set(ByVal value As Integer)
            mode = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        webService = New ABCDService.Service()
        webService.Url = ABCDConst.STRING_URL
        webService.Timeout = ABCDConst.STRING_TIMEOUT
        dataTable = Nothing
        GetSetDisplay = 0
        GetSetMode = 0
    End Sub

#End Region

#Region "Event Method"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_PRS002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat()
        ABCDCommon.InitDateTimePicker(dtp_wo_date_from)
        ABCDCommon.InitDateTimePicker(dtp_wo_date_to)
        EnableAllControls(GetSetMode)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Close()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        If GetSetDisplay <> 0 Then
            GetSetDisplay = GetSetDisplay - 1
        End If
        If GetSetDisplay = 0 Then
            GetSetMode = 0
        End If
        ClearValueInControl(GetSetDisplay)
        EnableAllControls(GetSetMode)
        Return
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_popup_item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_item.Click
        Dim popupSelectItem As New frm_POS001(Me)
        popupSelectItem.ShowDialog()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim frm As frm_MSG001

        dataTable = Nothing
        grd_product_inquiry.Rows.Clear()

        If GetSetMode = 1 Then
            If CheckInputLeastOneCondition(GetSetMode) = 0 Then
                frm = New frm_MSG001(PRS002_01, "ERROR")
                frm.ShowDialog()
                txt_item_code.Focus()
                Return
            End If

            If CheckDateValid(dtp_wo_date_from.Value, dtp_wo_date_to.Value) = False Then
                frm = New frm_MSG001(PRS002_02, "ERROR")
                frm.ShowDialog()
                dtp_wo_date_from.Focus()
                Return
            End If

            dataTable = webService.GetDataProductInfoInquiryWithModeNew(txt_item_code.Text, txt_wo_no.Text, _
                                                                        dtp_wo_date_from.Text, dtp_wo_date_to.Text, _
                                                                        ABCDCommon.UserId).Tables(0)
            If dataTable.Rows.Count <= 0 Then
                frm = New frm_MSG001(ERR010, "ERROR")
                frm.ShowDialog()
                btn_search.Focus()
                Return
            End If

            GetSetDisplay = 2
            EnableControlAfterClickSearch(GetSetMode, GetSetDisplay)
            GetDataIntoGridviewWithModeNew(dataTable)
            SetBackColorInGridview()
            grd_product_inquiry.ClearSelection()
        End If

        If GetSetMode = 2 Then
            If CheckInputLeastOneCondition(GetSetMode) = 0 Then
                frm = New frm_MSG001(PRS002_01, "ERROR")
                frm.ShowDialog()
                txt_barcode_from.Focus()
                Return
            End If

            dataTable = webService.GetBarcode(ABCDCommon.UserId, 0, txt_barcode_from.Text, txt_barcode_to.Text).Tables(0)
            If dataTable.Rows.Count <= 0 Then
                frm = New frm_MSG001(ERR010, "ERROR")
                frm.ShowDialog()
                btn_search.Focus()
                Return
            End If

            Dim dataView As New DataView(dataTable)
            dataView.Sort = "Barcode No ASC"
            dataTable = dataView.ToTable

            GetSetDisplay = 2
            EnableControlAfterClickSearch(GetSetMode, GetSetDisplay)
            GetDataIntoGridviewWithModeReissue(dataTable)
            grd_product_inquiry.ClearSelection()
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        Dim frm As frm_MSG001

        If GetSetMode = 1 Then
            frm = New frm_MSG001(PRS002_09, "MSG")
            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                btn_cancel.Enabled = False
                btn_exit.Enabled = False
                btn_export.Enabled = False

                Dim workOrderNo As New List(Of String)
                Dim workOrderDate As New List(Of String)
                Dim itemCode As New List(Of String)
                Dim remainProduct As New List(Of String)
                Dim productQuantity As New List(Of String)
                Dim productDate As New List(Of String)
                Dim quantityPerBox As New List(Of String)
                Dim totalBox As New List(Of String)
                Dim currentBoxNumber As New List(Of String)
                Dim itemName As New List(Of String)
                Dim flagSuccess As Boolean = False
                Dim numInsert As Integer = 0
                Dim limitData As Integer = 0

                For i As Integer = 0 To grd_product_inquiry.RowCount - 1 Step 1
                    workOrderNo.Add(grd_product_inquiry.Rows(i).Cells(0).Value.ToString)
                    workOrderDate.Add(grd_product_inquiry.Rows(i).Cells(1).Value.ToString)
                    itemCode.Add(grd_product_inquiry.Rows(i).Cells(2).Value.ToString)
                    itemName.Add(grd_product_inquiry.Rows(i).Cells(3).Value.ToString)
                    remainProduct.Add(grd_product_inquiry.Rows(i).Cells(5).Value.ToString)
                    productQuantity.Add(grd_product_inquiry.Rows(i).Cells(6).Value.ToString)
                    productDate.Add(grd_product_inquiry.Rows(i).Cells(7).Value.ToString)
                    quantityPerBox.Add(grd_product_inquiry.Rows(i).Cells(8).Value.ToString)
                    totalBox.Add(grd_product_inquiry.Rows(i).Cells(9).Value.ToString)
                    currentBoxNumber.Add(dataTable.Rows(i)("CUR_BOX_NUM").ToString)
                    limitData = limitData + Integer.Parse(grd_product_inquiry.Rows(i).Cells(9).Value.ToString.Replace(",", ""))
                Next

                Try
                    '// Notice warning create label have odd box.
                    '// Start.
                    Dim ProductQty As Integer = CInt(grd_product_inquiry.Rows(0).Cells(6).Value.ToString)
                    Dim QtyPerBox As Integer = CInt(grd_product_inquiry.Rows(0).Cells(8).Value.ToString)
                    If ProductQty Mod QtyPerBox <> 0 Then
                        Dim NoticeForm As New frm_MSG001("Now One Label Have Odd Quantity" & vbCrLf & "Do You Print Labels ?", "MSG")
                        If NoticeForm.ShowDialog = Windows.Forms.DialogResult.No Then '// Process button No.
                            btn_export.Enabled = True '// Enabled button export.
                            Exit Sub '// Exit screen.
                        End If
                    End If
                    '// End.

                    numInsert = webService.InsertScreenProductInfoInquiry(workOrderNo.ToArray, workOrderDate.ToArray, _
                                                                          itemCode.ToArray, remainProduct.ToArray, _
                                                                          productQuantity.ToArray, productDate.ToArray, _
                                                                          quantityPerBox.ToArray, totalBox.ToArray, _
                                                                          currentBoxNumber.ToArray, ABCDCommon.UserId, _
                                                                          itemName.ToArray)

                    If numInsert > 0 Then
                        frm = New frm_MSG001(PRS002_10, "INF")
                        frm.ShowDialog()

                        dataTable = Nothing
                        dataTable = webService.GetBarcode(ABCDCommon.UserId, limitData, "", "").Tables(0)
                        Dim dataView As New DataView(dataTable)
                        dataView.Sort = "Barcode No ASC"
                        dataTable = dataView.ToTable

                        'AIT Hungtg start 07/08/2015
                        Dim directPath As String = Configuration.ConfigurationManager.AppSettings(PATH_SAVE_LABEL)
                        If Not IO.Directory.Exists(directPath) Then
                            IO.Directory.CreateDirectory(directPath)
                        End If

                        '// cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN - start
                        Dim itemCd As String = "_" & Trim(dataTable.Rows(0)("Part No").ToString)
                        Dim pathName As String = directPath & PRODUCT_INQUIRY & NEW_ISSUE & VAR_CHAR1 & DateTime.Now.ToString(DATE_CMN_02) & itemCd

                        Dim nextLastQty As Integer = 0 '// Quantity of next last box.
                        Dim lastQty As Integer = 0 '// Quantity of last box.

                        If dataTable.Rows.Count > 1 Then '// List export csv more one rows.
                            nextLastQty = Integer.Parse(dataTable.Rows(dataTable.Rows.Count - 2)("Qty/Box").ToString)
                            lastQty = Integer.Parse(dataTable.Rows(dataTable.Rows.Count - 1)("Qty/Box").ToString)
                            If lastQty < nextLastQty Then
                                pathName = pathName & "_ODD"
                            ElseIf lastQty = nextLastQty Then
                                pathName = pathName & "_EVEN"
                            End If
                        ElseIf dataTable.Rows.Count <= 1 Then '// List export csv only one rows.
                            nextLastQty = Integer.Parse(Trim(quantityPerBox(0).Replace(",", "")))
                            lastQty = Integer.Parse(dataTable.Rows(dataTable.Rows.Count - 1)("Qty/Box").ToString)
                            If lastQty < nextLastQty Then
                                pathName = pathName & "_ODD"
                            ElseIf lastQty = nextLastQty Then
                                pathName = pathName & "_EVEN"
                            End If
                        End If

                        pathName = pathName & FILE_CMN_02
                        '<<20160701 Phungntm Start : Hide () of PartNo in Template7 only for print Barcode Label
                        Dim itemCdStr As String = ""
                        'Dim boxQty As String = ""

                        'Replace Qty/Box column with the StringType one
                        'dataTable.Columns("Qty/Box").ColumnName = "QtyNumber"
                        'dataTable.Columns.Add("Qty/Box", GetType(String)).SetOrdinal(6)

                        Dim itemTypeStr As String = ""
                        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
                            '<<20160706 Phungntm Start : Hide () of PartNo in Template1 and Template 7 only for print Barcode Label
                            itemTypeStr = dataTable.Rows(i)("Pattern Type").ToString

                            itemCdStr = dataTable.Rows(i)("Part No").ToString
                            'boxQty = dataTable.Rows(i)("QtyNumber").ToString

                            If itemCdStr.Contains("(") Then
                                itemCdStr = itemCdStr.Substring(0, itemCdStr.IndexOf("("))
                            End If
                            If PATTERN_TYPE_7.Equals(itemTypeStr) Then
                                If itemCdStr.Contains("-") Then
                                    itemCdStr = itemCdStr.Replace("-", "")
                                End If
                                'dataTable.Rows(i)("Part No") = "*P" + itemCdStr.ToString.Trim + "*"
                                'dataTable.Rows(i)("Qty/Box") = "*Q" + boxQty.ToString + "*"
                            End If

                            dataTable.Rows(i)("Part No") = itemCdStr.ToString
                            'dataTable.Rows(i)("Qty/Box") = boxQty.ToString

                        Next

                        'Remove old type column
                        'dataTable.Columns.Remove("QtyNumber")
                        '>>    
                        '// cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN - end
                        Call ExportDataTableIntoCSV(dataTable, pathName)
                        '// ABCDCommon.ExportNewIssueDataIntoCSV(dataTable, pathName)
                        '// Dim pathName As String = AppSettings(PATH_SAVE_LABEL) & PRODUCT_INQUIRY
                        '// AIT Hungtg end 07/08/2015
                    End If
                Catch ex As Exception
                    frm = New frm_MSG001(ex.Message, "ERROR")
                    frm.ShowDialog()
                    btn_cancel.Enabled = True
                    btn_exit.Enabled = True
                    btn_export.Enabled = True
                    Return
                Finally
                    btn_cancel.Enabled = True
                    btn_exit.Enabled = True
                End Try
            End If
        End If

        If GetSetMode = 2 Then
            frm = New frm_MSG001(PRS002_10, "MSG")

            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                'Dim pathName As String = Configuration.ConfigurationManager.AppSettings(ABCDConst.PATH_SAVE_LABEL) & "PRS002-REISSUEMODE" & DateTime.Now.ToString("_yyyyMMddhhmmss") & "_{0}_{1}" & ".csv" 'AIT Hungtg edit 10/08/2015
                Dim directPath As String = Configuration.ConfigurationManager.AppSettings(PATH_SAVE_LABEL)
                If Not IO.Directory.Exists(directPath) Then
                    IO.Directory.CreateDirectory(directPath)
                End If
                '// cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN - start
                Dim pathName As String = directPath & PRODUCT_INQUIRY & RE_ISSUE & VAR_CHAR1 & DateTime.Now.ToString(DATE_CMN_02) & FILE_CMN_02

                '// cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN - end
                btn_export.Enabled = False
                btn_cancel.Enabled = False
                btn_exit.Enabled = False

                '<<20160701 Phungntm Start : 
                '   Hide () of PartNo in Template7 only for print Barcode Label
                '   Add Identity character for number string                        
                Dim itemCdStr As String = ""
                Dim itemTypeStr As String = ""
                'Dim boxQty As String = ""

                'Replace Qty/Box column with the StringType one
                'dataTable.Columns("Qty/Box").ColumnName = "QtyNumber"
                'dataTable.Columns.Add("Qty/Box", GetType(String)).SetOrdinal(6)

                For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
                    '<<20160706 Phungntm Start : Hide () of PartNo in Template1 and Template 7 only for print Barcode Label
                    itemTypeStr = dataTable.Rows(i)("Pattern Type").ToString

                    itemCdStr = dataTable.Rows(i)("Part No").ToString
                    'boxQty = dataTable.Rows(i)("QtyNumber").ToString
                    
                    If itemCdStr.Contains("(") Then
                        itemCdStr = itemCdStr.Substring(0, itemCdStr.IndexOf("("))
                    End If
                    If PATTERN_TYPE_7.Equals(itemTypeStr) Then
                        If itemCdStr.Contains("-") Then
                            itemCdStr = itemCdStr.Replace("-", "")
                        End If
                    End If
                    'dataTable.Rows(i)("Part No") = "*P" + itemCdStr.ToString.Trim + "*"
                    'dataTable.Rows(i)("Qty/Box") = "*Q" + boxQty.ToString + "*"
                    dataTable.Rows(i)("Part No") = itemCdStr.ToString
                    'dataTable.Rows(i)("Qty/Box") = boxQty.ToString
                Next

                'dataTable.Columns.Remove("QtyNumber")
                '>>               

                Call ExportDataTableIntoCSV(dataTable, pathName)
                'ABCDCommon.ExportReIssueDataIntoCSV(grd_product_inquiry, pathName)
                btn_cancel.Enabled = True
                btn_exit.Enabled = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdo_exp_new_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_exp_new.CheckedChanged
        GetSetMode = 1
        GetSetDisplay = 1
        EnableAllControls(GetSetMode)
        grd_product_inquiry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        CreateColumnInGridviewWithModeNew()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rdo_reissue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_reissue.CheckedChanged
        GetSetMode = 2
        GetSetDisplay = 1
        EnableAllControls(GetSetMode)
        grd_product_inquiry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        CreateColumnInGridviewWithModeReissue()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp_wo_date_from_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_wo_date_from.ValueChanged
        ABCDCommon.ChangeDateTimePicker(dtp_wo_date_from)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp_wo_date_to_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_wo_date_to.ValueChanged
        ABCDCommon.ChangeDateTimePicker(dtp_wo_date_to)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grd_product_inquiry_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_product_inquiry.CellContentClick
        If grd_product_inquiry.Rows.Count > 0 Then
            If e.RowIndex = -1 Then
                grd_product_inquiry.ClearSelection()
                Return
            End If

            Dim data As String = String.Empty
            data = grd_product_inquiry.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If Not data.Equals("") Or data.Equals("") Then
                If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
                    grd_product_inquiry.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = False
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grd_product_inquiry_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_product_inquiry.CellEndEdit
        If grd_product_inquiry.Rows.Count > 0 Then
            Dim workOrderDate As String = String.Empty
            Dim remainedProduct As String = String.Empty
            Dim productQuantity As String = String.Empty
            Dim productDate As String = String.Empty
            Dim quantityPerBox As String = String.Empty
            Dim totalBox As String = String.Empty
            Dim rowIndex As Integer = e.RowIndex
            Dim frm As frm_MSG001
            Dim mainProductQty As String = "" '// cuongtk - add in date 12012016.

            workOrderDate = grd_product_inquiry.Rows(rowIndex).Cells(1).Value
            remainedProduct = grd_product_inquiry.Rows(rowIndex).Cells(5).Value
            productQuantity = grd_product_inquiry.Rows(rowIndex).Cells(6).Value
            productDate = grd_product_inquiry.Rows(rowIndex).Cells(7).Value
            quantityPerBox = grd_product_inquiry.Rows(rowIndex).Cells(8).Value
            totalBox = grd_product_inquiry.Rows(rowIndex).Cells(9).Value
            mainProductQty = grd_product_inquiry.Rows(rowIndex).Cells(4).Value '// cuongtk - add in date 12012016.

            If e.ColumnIndex = 6 Then
                If productQuantity Is Nothing Then
                    frm = New frm_MSG001(PRS002_03, "ERROR")
                    frm.ShowDialog()
                    '// cuongtk - change in date 12012016.
                    '// reason - calculate with minus number.
                    totalBox = CalculateTotalBoxAgain(remainedProduct, quantityPerBox, mainProductQty)
                    grd_product_inquiry.Rows(rowIndex).Cells(6).Value = remainedProduct
                    grd_product_inquiry.Rows(rowIndex).Cells(9).Value = totalBox
                    Return
                End If

                If Not productQuantity.Equals(String.Empty) Then
                    If Not IsNumeric(productQuantity) Then
                        frm = New frm_MSG001(PRS002_04, "ERROR")
                        frm.ShowDialog()
                        grd_product_inquiry.Rows(rowIndex).Cells(6).Value = remainedProduct
                        grd_product_inquiry.Rows(rowIndex).Cells(9).Value = totalBox
                        Return
                    End If
                    '// cuongtk - change in date 12012016.
                    '// reason - calculate with minus number.
                    productQuantity = Math.Abs(Integer.Parse(productQuantity.Replace(",", ""))).ToString
                    totalBox = CalculateTotalBoxAgain(productQuantity, quantityPerBox, mainProductQty)
                    grd_product_inquiry.Rows(rowIndex).Cells(6).Value = Integer.Parse(productQuantity.Replace(",", "")).ToString("#,##0")
                    grd_product_inquiry.Rows(rowIndex).Cells(9).Value = totalBox
                End If
            End If

            If e.ColumnIndex = 7 Then
                If productDate Is Nothing Then
                    frm = New frm_MSG001(PRS002_06, "ERROR")
                    frm.ShowDialog()
                    grd_product_inquiry.Rows(rowIndex).Cells(7).Value = Date.Now.ToString("dd/MM/yyyy")
                    Return
                End If

                If Not productDate.Equals(String.Empty) Then
                    Dim formatDate As Date = Nothing
                    Date.TryParseExact(productDate, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, formatDate)
                    If Not IsDate(formatDate) Then
                        frm = New frm_MSG001(PRS002_07, "ERROR")
                        frm.ShowDialog()
                        Return
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_item_code_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_item_code.Leave
        If Not txt_item_code.Text.Equals("") Then
            dataTable = Nothing
            dataTable = webService.GetItemInfoByCd(txt_item_code.Text, ABCDCommon.UserId).Tables(0)

            If dataTable.Rows.Count > 0 Then
                txt_item_name.Text = Trim(dataTable.Rows(0)("ITEM_NM").ToString)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_item_code_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_item_code.TextChanged
        txt_item_name.Text = Nothing
    End Sub

#End Region

#Region "Common Method"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Private Sub EnableAllControls(ByVal mode As Integer)
        If mode = 0 Then
            rdo_exp_new.Enabled = True
            rdo_reissue.Enabled = True

            txt_item_code.Enabled = False
            txt_wo_no.Enabled = False
            txt_barcode_from.Enabled = False
            txt_barcode_to.Enabled = False

            btn_search.Enabled = False
            btn_export.Enabled = False
            btn_cancel.Enabled = False
            btn_popup_item.Enabled = False

            dtp_wo_date_from.Enabled = False
            dtp_wo_date_to.Enabled = False
        End If

        If mode = 1 Then
            rdo_exp_new.Enabled = False
            rdo_reissue.Enabled = False

            txt_item_code.Enabled = True
            txt_wo_no.Enabled = True
            txt_barcode_from.Enabled = False
            txt_barcode_to.Enabled = False

            btn_search.Enabled = True
            btn_export.Enabled = False
            btn_cancel.Enabled = True
            btn_popup_item.Enabled = True

            dtp_wo_date_from.Enabled = True
            dtp_wo_date_to.Enabled = True
        End If

        If mode = 2 Then
            rdo_exp_new.Enabled = False
            rdo_reissue.Enabled = False

            txt_item_code.Enabled = False
            txt_wo_no.Enabled = False
            txt_barcode_from.Enabled = True
            txt_barcode_to.Enabled = True

            btn_search.Enabled = True
            btn_export.Enabled = False
            btn_cancel.Enabled = True
            btn_popup_item.Enabled = False

            dtp_wo_date_from.Enabled = False
            dtp_wo_date_to.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="display"></param>
    ''' <remarks></remarks>
    Private Sub ClearValueInControl(ByVal display As Integer)
        If display = 0 Then
            RemoveHandler rdo_exp_new.CheckedChanged, AddressOf rdo_exp_new_CheckedChanged
            rdo_exp_new.Checked = False
            AddHandler rdo_exp_new.CheckedChanged, AddressOf rdo_exp_new_CheckedChanged
            RemoveHandler rdo_reissue.CheckedChanged, AddressOf rdo_reissue_CheckedChanged
            rdo_reissue.Checked = False
            AddHandler rdo_reissue.CheckedChanged, AddressOf rdo_reissue_CheckedChanged

            txt_item_code.Text = Nothing
            txt_item_name.Text = Nothing
            txt_wo_no.Text = Nothing
            txt_barcode_from.Text = Nothing
            txt_barcode_to.Text = Nothing

            ABCDCommon.InitDateTimePicker(dtp_wo_date_from)
            ABCDCommon.InitDateTimePicker(dtp_wo_date_to)

            grd_product_inquiry.Columns.Clear()
        End If

        If display = 1 Then
            grd_product_inquiry.Rows.Clear()
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="display"></param>
    ''' <remarks></remarks>
    Private Sub EnableControlAfterClickSearch(ByVal mode As Integer, ByVal display As Integer)
        If mode = 1 And display = 2 Then
            txt_item_code.Enabled = False
            txt_wo_no.Enabled = False
            txt_barcode_from.Enabled = False
            txt_barcode_to.Enabled = False

            btn_search.Enabled = False
            btn_export.Enabled = True
            btn_cancel.Enabled = True
            btn_popup_item.Enabled = False

            dtp_wo_date_from.Enabled = False
            dtp_wo_date_to.Enabled = False
        End If

        If mode = 2 And display = 2 Then
            txt_item_code.Enabled = False
            txt_wo_no.Enabled = False
            txt_barcode_from.Enabled = False
            txt_barcode_to.Enabled = False

            btn_search.Enabled = False
            btn_export.Enabled = True
            btn_cancel.Enabled = True
            btn_popup_item.Enabled = False

            dtp_wo_date_from.Enabled = False
            dtp_wo_date_to.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckInputLeastOneCondition(ByVal mode As Integer) As Integer
        Dim checkValid As Integer = 0

        If mode = 1 And Not txt_item_code.Text.Equals("") Then
            checkValid = 1
            Return checkValid
        End If

        If mode = 1 And Not txt_wo_no.Text.Equals("") Then
            checkValid = 1
            Return checkValid
        End If

        If mode = 1 And Not dtp_wo_date_from.Text.Equals(" ") Then
            checkValid = 1
            Return checkValid
        End If

        If mode = 1 And Not dtp_wo_date_to.Text.Equals(" ") Then
            checkValid = 1
            Return checkValid
        End If

        If mode = 2 And Not txt_barcode_from.Text.Equals("") Then
            checkValid = 1
            Return checkValid
        End If

        If mode = 2 And Not txt_barcode_to.Text.Equals("") Then
            checkValid = 1
            Return checkValid
        End If

        Return checkValid
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dateFrom"></param>
    ''' <param name="dateTo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDateValid(ByVal dateFrom As Date, ByVal dateTo As Date) As Boolean
        If dateFrom.CompareTo(dateTo) <= 0 Then
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dateFromString"></param>
    ''' <param name="dateToString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDateValid(ByVal dateFromString As String, ByVal dateToString As String) As Boolean
        Dim dateFrom As Date = Nothing
        Dim dateTo As Date = Nothing
        Dim frm As frm_MSG001

        Try
            Date.TryParseExact(dateFromString, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, dateFrom)
            Date.TryParseExact(dateToString, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, dateTo)
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERROR")
            frm.ShowDialog()
            Return False
        End Try

        If dateFrom.CompareTo(dateTo) <= 0 Then
            Return True
        End If

        Return False
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateColumnInGridviewWithModeNew()
        Dim columnName As New List(Of String)(New String() {"W/O No", "W/O Date", "Item Code", "Item Name", _
                                                            "Required Quantity", _
                                                            "Remained Quantity", "Product Quantity", "Product Date", _
                                                             "Quantity Per Box", "Total Box"})
        Dim columnSize As New List(Of Integer)(New Integer() {80, 85, 180, 200, 70, 75, 70, 85, 85, 70})

        grd_product_inquiry.ColumnCount = columnName.Count
        For columnIndex As Integer = 0 To columnName.Count - 1 Step 1
            grd_product_inquiry.Columns(columnIndex).Name = columnName(columnIndex)
            grd_product_inquiry.Columns(columnIndex).Width = columnSize(columnIndex)

            If columnIndex <> 6 And columnIndex <> 7 Then
                grd_product_inquiry.Columns(columnIndex).ReadOnly = True
            End If
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateColumnInGridviewWithModeReissue()
        Dim columnName As New List(Of String)(New String() {"Pattern Type", "Barcode No", "Lot No", "Part No", _
                                                            "Part Name", "Box No", "Qty/Box", _
                                                            "Unit", "OROTEX NO", "Image Path 1", _
                                                            "Image Path 2", "Image Path 3", "Image Path 4", _
                                                            "Image Path 5", "Qty"})
        Dim columnSize As New List(Of Integer)(New Integer() {60, 110, 180, 180, 200, 80, 60, 60, 60, 60, 60, 60, 60, 60, 45})
        grd_product_inquiry.ColumnCount = columnName.Count
        For columnIndex As Integer = 0 To columnName.Count - 1 Step 1
            grd_product_inquiry.Columns(columnIndex).Name = columnName(columnIndex)
            grd_product_inquiry.Columns(columnIndex).Width = columnSize(columnIndex)
            grd_product_inquiry.Columns(columnIndex).ReadOnly = True
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <remarks></remarks>
    Private Sub GetDataIntoGridviewWithModeNew(ByVal dataTable As DataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            Dim dataList As New List(Of String)
            Dim dataArray(grd_product_inquiry.Columns.Count) As String
            Dim productQuantity As String = String.Empty
            Dim quantityPerBox As String = String.Empty
            Dim totalBox As String = String.Empty

            For j As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = Nothing
                data = Trim(dataTable.Rows(i)(j).ToString)

                If j = 1 Then
                    data = DateTime.Parse(data).ToString("dd/MM/yyyy")
                End If

                If j = 4 Then
                    data = Integer.Parse(data).ToString("#,##0")
                End If

                If j = 5 Then
                    productQuantity = If(Integer.Parse(data) < 0, "0", data) 'LanNT - 20160719: negative remained quantity display 0 product quantity
                    data = Integer.Parse(data).ToString("#,##0")
                End If

                If j = 6 Then
                    quantityPerBox = data
                    data = Integer.Parse(data).ToString("#,##0")
                End If

                If j = 7 Then
                    '// cuongtk - change in date 12012016.
                    '// reason - calculate with minus number.
                    totalBox = CalculateTotalBoxAgain(Trim(dataTable.Rows(i)(5).ToString), _
                                                      Trim(dataTable.Rows(i)(6).ToString), _
                                                      Trim(dataTable.Rows(i)(4).ToString))
                    '// cuongtk - change in date 12012016.
                    '// reason - format number "#,###" into "#,##0".
                    '//        - "0" into "" with format "#,###".
                    data = Integer.Parse(data).ToString("#,##0")
                End If

                dataList.Add(data)
            Next

            For k As Integer = 0 To dataList.Count - 1 Step 1
                dataArray(k) = dataList(k)
            Next

            For k As Integer = 0 To dataArray.Count - 1 Step 1
                If k = 6 Then
                    dataArray(k) = Integer.Parse(productQuantity).ToString("#,##0")
                End If

                If k = 7 Then
                    Dim systemHour As Integer = Date.Now.Hour '// Hour.
                    Dim systemDate As Date = Nothing
                    If systemHour >= 6 And systemHour < 24 Then
                        systemDate = Date.Now '// Get date of system.
                    ElseIf systemHour >= 0 And systemHour < 6 Then
                        systemDate = Date.Now.AddDays(-1) '// Get date of system -1 day.
                    End If
                    dataArray(k) = systemDate.ToString("dd/MM/yyyy")
                End If

                If k = 8 Then
                    dataArray(k) = Integer.Parse(quantityPerBox).ToString("#,##0")
                End If

                If k = 9 Then
                    dataArray(k) = Integer.Parse(totalBox.Replace(",", "")).ToString("#,##0")
                End If
            Next

            grd_product_inquiry.Rows.Add(dataArray)
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetDataIntoGridviewWithModeReissue(ByVal dataTable As DataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            Dim dataList As New List(Of String)
            Dim dataArray(grd_product_inquiry.Columns.Count) As String

            For j As Integer = 0 To dataTable.Columns.Count - 1 Step 1
                Dim data As String = Nothing
                data = Trim(dataTable.Rows(i)(j).ToString)

                dataList.Add(data)
            Next

            For k As Integer = 0 To dataList.Count - 1 Step 1
                dataArray(k) = dataList(k)
            Next

            grd_product_inquiry.Rows.Add(dataArray)
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetBackColorInGridview()
        If grd_product_inquiry.Rows.Count <= 0 Then
            Return
        End If

        grd_product_inquiry.Columns(6).DefaultCellStyle.BackColor = Color.Yellow
        grd_product_inquiry.Columns(7).DefaultCellStyle.BackColor = Color.Yellow
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="productQuantity"></param>
    ''' <param name="quantityPerBox"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalculateTotalBoxAgain(ByVal productQuantity As String, _
                                            ByVal quantityPerBox As String, _
                                            ByVal mainProductQuantity As String) As String
        Dim totalBox As String = String.Empty
        Dim modBox As Integer = 0
        Dim divBox As Integer = 0
        '// Kaidai 160111-Format TotalBox. - start
        Dim chgProductQty As Integer = Integer.Parse(productQuantity.Replace(",", ""))
        Dim mainProductQty As Integer = Integer.Parse(mainProductQuantity.Replace(",", ""))
        Dim mainProductQtyPerBox As Integer = Integer.Parse(quantityPerBox.Replace(",", ""))
        '// Step by step calculate total box.
        modBox = chgProductQty Mod mainProductQtyPerBox
        divBox = chgProductQty \ mainProductQtyPerBox
        If chgProductQty < 0 Then
            chgProductQty = Math.Abs(chgProductQty)
            modBox = (chgProductQty + mainProductQty) Mod mainProductQtyPerBox
            divBox = (chgProductQty + mainProductQty) \ mainProductQtyPerBox
        End If
        totalBox = divBox
        If modBox <> 0 Then
            totalBox = (divBox + 1).ToString
        End If
        '// cuongtk - change in date 12012016.
        '// reason - format number "#,###" into "#,##0".
        '//        - "0" into "" with format "#,###".
        Return Integer.Parse(totalBox).ToString("#,##0")
        '// Kaidai 160111-Format TotalBox. - end
    End Function

    ''' <summary>
    ''' Convert string value to date
    ''' Cuongtk - 20150818
    ''' </summary>
    ''' <param name="stringDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertStringToDate(ByVal stringDate As String) As Date
        Dim convertDate As Date = Nothing
        If Date.TryParseExact(stringDate, DATE_CMN_03, Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None, convertDate) Then
            Return convertDate
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Check Item Full Quantity Per Box
    ''' cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckItemOddEven(ByVal dataTable As DataTable) As Boolean

    End Function

#End Region

End Class