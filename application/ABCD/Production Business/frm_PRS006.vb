Imports ABCD.ABCDCommon
Imports ABCD.ABCDConst
Imports ABCD.ABCDService

''' <summary>
''' Edit Label Another Work Order.
''' </summary>
''' <remarks>
'''  User       Created        Date        Ver
''' cuongtk       new       11-Nov-2015    1.0
''' </remarks>
Public Class frm_PRS006

#Region "Variable."
    Private admsService As Service = Nothing
    Private standardQty As Integer = 0
    Private dataQtyPerBox As Integer = 0
    Private Const PATTERN_TYPE_7 As String = "7" ' LanNT - 20160714
#End Region

#Region "Constructor."
    Public Sub New()
        InitializeComponent()
        Me.admsService = New Service()
        Me.admsService.Url = STRING_URL
        Me.admsService.Timeout = STRING_TIMEOUT
    End Sub
#End Region

#Region "Event."
    ''' <summary>
    ''' Event load screen.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_PRS006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.infoUser.Text = "UserId: " & UserId & " - Today: " & Date.Now.ToString(DATE_CMN_03)
        Call ClearData()
        Call EnableControl()
    End Sub

    ''' <summary>
    ''' Event leave focus barcode no.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub barcodeNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles barcodeNo.Leave
        Dim ds As DataSet = Nothing
        Dim whCd As String = String.Empty
        If Me.cancelData.Focused Then
            Exit Sub
        End If
        If Me.returnMenu.Focused Then
            Exit Sub
        End If
        If "".Equals(Trim(Me.barcodeNo.Text)) Then
            Me.barcodeNo.Text = Trim(Me.barcodeNo.Text)
            Me.barcodeNo.Focus()
            Exit Sub
        End If
        ds = admsService.GetInfoOddBoxByItemCode(Trim(Me.barcodeNo.Text), UserId)
        If ds Is Nothing Or ds.Tables(0).Rows.Count = 0 Then
            Dim errorMsg As New frm_MSG001("Data not found!", "ERRPRS006")
            errorMsg.ShowDialog()
            Me.barcodeNo.Focus()
            Me.barcodeNo.SelectAll()
            Exit Sub
        End If
        whCd = Trim(ds.Tables(0).Rows(0)("WH_CD").ToString())
        If Not "MOLD".Equals(whCd) Then
            Dim errorMsg As New frm_MSG001("Barcode is not existed in MOLD!", "ERRPRS006")
            errorMsg.ShowDialog()
            Me.barcodeNo.Focus()
            Me.barcodeNo.SelectAll()
            Exit Sub
        End If
        Me.dataQtyPerBox = Integer.Parse(Trim(ds.Tables(0).Rows(0)("QTY").ToString()))
        Me.standardQty = Integer.Parse(Trim(ds.Tables(0).Rows(0)("STD_QTY").ToString()))
        'If Me.dataQtyPerBox = Me.standardQty Then
        '    Dim errorMsg As New frm_MSG001("Barcode is not Odd Box!", "ERRPRS006")
        '    errorMsg.ShowDialog()
        '    Me.barcodeNo.Focus()
        '    Me.barcodeNo.SelectAll()
        '    Exit Sub
        'End If
        Me.partNo.Text = Trim(ds.Tables(0).Rows(0)("ITEM_CD").ToString())
        Me.partName.Text = Trim(ds.Tables(0).Rows(0)("ITEM_NM").ToString())
        Me.qtyPerBox.Text = dataQtyPerBox.ToString("#,###")
        If Me.qtyPerBox.Text = String.Empty Then
            Me.qtyPerBox.Text = "0"
        End If
        Me.curLotNo.Text = Trim(ds.Tables(0).Rows(0)("LOT_NO").ToString())
        Me.barcodeNo.Enabled = False
        Me.qtyPerBox.Enabled = True
        Me.curLotNo.Enabled = True
        Me.updateLabel.Enabled = True
        Me.qtyPerBox.Text = Me.qtyPerBox.Text.Replace(",", "")
        Me.qtyPerBox.Focus()
        Me.qtyPerBox.SelectAll()
    End Sub

    ''' <summary>
    ''' Event update information label Odd to Even.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub updateLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateLabel.Click
        If Integer.Parse(Me.qtyPerBox.Text.Replace(",", "")) < 0 Then
            Dim errorMsg As New frm_MSG001("Not allow to input minus quantity!", "ERRPRS006")
            errorMsg.ShowDialog()
            Me.qtyPerBox.Focus()
            Me.qtyPerBox.SelectAll()
            Exit Sub
        End If
        Dim scrQtyPerBox As Integer = Integer.Parse(Me.qtyPerBox.Text.Replace(",", ""))
        If scrQtyPerBox > Me.standardQty Then
            Dim errorMsg As New frm_MSG001("Barcode quantity is larger than quantity per box!", "ERRPRS006")
            errorMsg.ShowDialog()
            Me.qtyPerBox.Text = Me.qtyPerBox.Text.Replace(",", "")
            Me.qtyPerBox.Focus()
            Me.qtyPerBox.SelectAll()
            Exit Sub
        End If
        Dim dataScreen As String = Me.barcodeNo.Text & "," & Me.partNo.Text & "," & Me.partName.Text & "," & Me.qtyPerBox.Text.Replace(",", "") & "," & Me.curLotNo.Text & "," & Me.standardQty.ToString()
        Try
            Dim rowUpd As Integer = admsService.UpdateOddToEvenBox(dataScreen, UserId)
            If rowUpd <> 0 Then
                Dim infoMsg As New frm_MSG001("Update information label is successful!", "INFPRS006")
                infoMsg.ShowDialog()
            ElseIf rowUpd = 0 Then
                Dim errMsg As New frm_MSG001("Update information label is unsuccessful!", "ERRPRS006")
                errMsg.ShowDialog()
                Me.qtyPerBox.Text = Me.qtyPerBox.Text.Replace(",", "")
                Me.qtyPerBox.Focus()
                Me.qtyPerBox.SelectAll()
                Exit Sub
            End If
            '// Print label after edit.
            Dim filePath As String = Configuration.ConfigurationManager.AppSettings(PATH_SAVE_LABEL) & "PRS006_" & Date.Now.ToString(DATE_CMN_02) & ".csv"

            '<< LanNT - 20160713: 
            '   Hide () of PartNo in Template7 only for print Barcode Label
            '   Add Identity character for number string                        

            Dim dataTable As DataTable = admsService.PrintNewLabel(Me.barcodeNo.Text, UserId).Tables(0)
            Dim itemCdStr As String = ""
            'Dim itemTypeStr As String = ""
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

            'dataTable.Columns.Remove("QtyNumber")
            '>>               

            Call ExportDataTableIntoCSV(dataTable, filePath)
            Me.qtyPerBox.Enabled = False
            Me.curLotNo.Enabled = False
            Me.updateLabel.Enabled = False
            Me.reissueLabel.Enabled = True
            '// Me.cancelData.Enabled = False
        Catch ex As Exception
            Dim errorMsg As New frm_MSG001(ex.Message, "ERREXCEP")
            errorMsg.ShowDialog()
        End Try
    End Sub

    ''' <summary>
    ''' Event print label again.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub reissueLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reissueLabel.Click
        Dim filePath As String = Configuration.ConfigurationManager.AppSettings(PATH_SAVE_LABEL) & "PRS006_REISSUE_" & Date.Now.ToString(DATE_CMN_02) & ".csv"

        '<< LanNT - 20160713: 
        '   Hide () of PartNo in Template7 only for print Barcode Label
        '   Add Identity character for number string                        

        Dim dataTable As DataTable = admsService.PrintNewLabel(Me.barcodeNo.Text, UserId).Tables(0)
        Dim itemCdStr As String = ""
        'Dim itemTypeStr As String = ""
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

        'dataTable.Columns.Remove("QtyNumber")
        '>>               

        Call ExportDataTableIntoCSV(dataTable, filePath)
    End Sub

    ''' <summary>
    ''' Event return menu.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub returnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles returnMenu.Click
        Close()
    End Sub

    ''' <summary>
    ''' Event leave focus quantity per box.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub qtyPerBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles qtyPerBox.Leave
        If Me.cancelData.Focused Then
            Exit Sub
        End If
        If Me.returnMenu.Focused Then
            Exit Sub
        End If
        If Me.curLotNo.Focused Then
            Exit Sub
        End If
        If Me.updateLabel.Focused Then
            Exit Sub
        End If
        If Not IsNumeric(Me.qtyPerBox.Text.Replace(",", "")) Then
            Dim errorMsg As New frm_MSG001("Please input number value!", "ERRPRS006")
            errorMsg.ShowDialog()
            Me.qtyPerBox.Focus()
            Me.qtyPerBox.SelectAll()
            Exit Sub
        End If
        If Integer.Parse(Me.qtyPerBox.Text.Replace(",", "")) < 0 Then
            Dim errorMsg As New frm_MSG001("Not allow to input minus quantity!", "ERRPRS006")
            errorMsg.ShowDialog()
            Me.qtyPerBox.Focus()
            Me.qtyPerBox.SelectAll()
            Exit Sub
        End If
        Me.qtyPerBox.Text = Integer.Parse(Me.qtyPerBox.Text.Replace(",", "")).ToString("#,###")
        If Me.qtyPerBox.Text = String.Empty Then
            Me.qtyPerBox.Text = "0"
        End If
    End Sub

    ''' <summary>
    ''' Event leave focus return menu.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub returnMenu_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles returnMenu.Leave
        Me.qtyPerBox.Text = Me.qtyPerBox.Text.Replace(",", "")
        Me.qtyPerBox.Focus()
        Me.qtyPerBox.SelectAll()
    End Sub

    ''' <summary>
    ''' Event mouse click quantity per box.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub qtyPerBox_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles qtyPerBox.MouseClick
        Me.qtyPerBox.Text = Me.qtyPerBox.Text.Replace(",", "")
        Me.qtyPerBox.Focus()
        Me.qtyPerBox.SelectAll()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cancelData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelData.Click
        'Me.barcodeNo.Text = String.Empty
        Me.partNo.Text = String.Empty
        Me.partName.Text = String.Empty
        Me.qtyPerBox.Text = String.Empty
        Me.curLotNo.Text = String.Empty
        Me.updateLabel.Enabled = False
        Me.reissueLabel.Enabled = False
        Me.qtyPerBox.Enabled = False
        Me.curLotNo.Enabled = False
        Me.partNo.Enabled = False
        Me.partName.Enabled = False
        Me.barcodeNo.Enabled = True
        Me.barcodeNo.Focus()
        Me.barcodeNo.SelectAll()
    End Sub

#End Region

#Region "Method."
    ''' <summary>
    ''' Method clear data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearData()
        Me.barcodeNo.Text = String.Empty
        Me.partNo.Text = String.Empty
        Me.partName.Text = String.Empty
        Me.qtyPerBox.Text = String.Empty
        Me.curLotNo.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Method enable control.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableControl()
        Me.partNo.Enabled = False
        Me.partName.Enabled = False
        Me.qtyPerBox.Enabled = False
        Me.curLotNo.Enabled = False
        Me.updateLabel.Enabled = False
        Me.reissueLabel.Enabled = False
    End Sub
#End Region

End Class