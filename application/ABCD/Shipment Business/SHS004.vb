''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：SHS004.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   20-AUG-15    1.00     Cuongtk   New
''*********************************************************
Imports ABCD.ABCDService
Imports ABCD.ABCDConst
Imports ABCD.ABCDCommon

Imports System.Configuration.ConfigurationManager

Imports Microsoft.VisualBasic

Public Class SHS004

    Private m_webService As New Service '// Variable get info web service

    ''' <summary>
    ''' Method: initialize screen SHS004
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        m_webService.Url = STRING_URL
        m_webService.Timeout = STRING_TIMEOUT
    End Sub

    ''' <summary>
    ''' Load screen Shipment Inquiry By Invoice No
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SHS004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.infoLoginToday.Text = "UserId: " & UserId & " - Today: " & Date.Now.ToString(DATE_CMN_03)
        ItemCode.Text = String.Empty
        ItemName.Text = String.Empty
        InvoiceNo.Text = String.Empty
        ShipmentDataView.Rows.Clear()
        ItemName.Enabled = False
        ExportFile.Enabled = False
    End Sub

    ''' <summary>
    ''' Leave text box input Item Code
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ItemCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCode.Leave
        Dim dataSet As DataSet = m_webService.GetItemInfoByCd(Trim(ItemCode.Text), UserId)
        Dim rowCount As Integer = dataSet.Tables(0).Rows.Count
        If rowCount = 1 Then
            ItemName.Text = Trim(dataSet.Tables(0).Rows(0)("ITEM_NM").ToString)
        End If
    End Sub

    ''' <summary>
    ''' Event press key [Enter] at Item Code
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ItemCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ItemCode.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim dataSet As DataSet = m_webService.GetItemInfoByCd(Trim(ItemCode.Text), UserId)
            Dim rowCount As Integer = dataSet.Tables(0).Rows.Count
            If rowCount = 1 Then
                ItemName.Text = Trim(dataSet.Tables(0).Rows(0)("ITEM_NM").ToString)
            End If
            PopupItem.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Event press key [Enter] at Invoice No
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InvoiceNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles InvoiceNo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ItemCode.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Event click [Pop-up] to select Item Code to Search
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PopupItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopupItem.Click
        Dim popupItem As New frm_POS001(Me)
        popupItem.ShowDialog()
    End Sub

    ''' <summary>
    ''' Event click [Search] get data from DB
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SearchScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchScreen.Click
        ShipmentDataView.Rows.Clear()
        If String.Empty.Equals(Trim(InvoiceNo.Text)) Then
            Dim errorScreen As New frm_MSG001("Please input Invoice No to Search!", "ERR9004")
            errorScreen.ShowDialog()
            InvoiceNo.Focus()
            Exit Sub
        End If
        Dim dataSet As DataSet = m_webService.GetShipmentInquiryByInvoiceNo(Trim(InvoiceNo.Text), Trim(ItemCode.Text), UserId)
        Dim collectionTable As DataTableCollection = dataSet.Tables
        Dim rowRun As Integer = 0
        Dim rowCount As Integer = 0
        For j As Integer = 0 To collectionTable.Count - 1 Step 1
            rowCount = rowCount + collectionTable(j).Rows.Count
        Next
        If rowCount = 0 Then
            Dim errorScreen As New frm_MSG001("Data is empty!", "ERR9004")
            errorScreen.ShowDialog()
            InvoiceNo.Focus()
            Exit Sub
        End If
        For j As Integer = 0 To collectionTable.Count - 1 Step 1
            Dim dataTable As DataTable = collectionTable(j)
            For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
                ShipmentDataView.Rows.Add()
                ShipmentDataView.Rows(rowRun).Cells(0).Value = Date.Parse(Trim(dataTable.Rows(i)("SHIP_DT").ToString)).ToString("dd/MM/yyyy")
                ShipmentDataView.Rows(rowRun).Cells(1).Value = Trim(dataTable.Rows(i)("SHIP_REQ_NO").ToString)
                ShipmentDataView.Rows(rowRun).Cells(2).Value = Trim(dataTable.Rows(i)("PALLET_NO").ToString)
                ShipmentDataView.Rows(rowRun).Cells(3).Value = Trim(dataTable.Rows(i)("ITEM_CD").ToString)
                ShipmentDataView.Rows(rowRun).Cells(4).Value = Trim(dataTable.Rows(i)("ITEM_NM").ToString)
                '// cuongtk - Change in date 13012016.
                '// reason - Format number on Gridview.
                '// start.
                Dim displayQty As Integer = Integer.Parse(Trim(dataTable.Rows(i)("QTY").ToString))
                ShipmentDataView.Rows(rowRun).Cells(5).Value = displayQty.ToString("#,##0")
                '// end.
                ShipmentDataView.Rows(rowRun).Cells(6).Value = Trim(dataTable.Rows(i)("LOT_NO").ToString)
                ShipmentDataView.Rows(rowRun).Cells(7).Value = Trim(dataTable.Rows(i)("INVOICE_NO").ToString)
                ShipmentDataView.Rows(rowRun).Cells(8).Value = Trim(dataTable.Rows(i)("BC_NO").ToString)
                ShipmentDataView.Rows(rowRun).Cells(9).Value = Trim(dataTable.Rows(i)("CUS_ID").ToString)
                rowRun = rowRun + 1
            Next
        Next
        ItemCode.Enabled = False
        InvoiceNo.Enabled = False
        PopupItem.Enabled = False
        SearchScreen.Enabled = False
        ExportFile.Enabled = True
    End Sub

    ''' <summary>
    ''' Event click [Clear] delete value on screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearScreen.Click
        ItemCode.Text = String.Empty
        ItemName.Text = String.Empty
        InvoiceNo.Text = String.Empty
        ItemCode.Enabled = True
        InvoiceNo.Enabled = True
        PopupItem.Enabled = True
        SearchScreen.Enabled = True
        ExportFile.Enabled = False
        ShipmentDataView.Rows.Clear()
        InvoiceNo.Focus()
    End Sub

    ''' <summary>
    ''' Event click [Exit] return screen Menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExitScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitScreen.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Event press key [Enter] leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PopupItem_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PopupItem.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SearchScreen.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Event change value in TextBox [Item Code]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCode.TextChanged
        ItemName.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Event export file [Export File]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExportFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportFile.Click
        SaveFileBox.Filter = "Excel Files (*.xlsx*) | *.xlsx"
        SaveFileBox.FileName = "SHS004_" & Date.Now.ToString("ddMMyyyyHHmmss")
        If SaveFileBox.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fileName As String = SaveFileBox.FileName
            Dim fileTemplate As String = AppSettings("ShipmentInquiryByInvoiceNo")
            Call ExportShipmentInquiryByInvoiceNo(ShipmentDataView, fileName, fileTemplate)
        End If
    End Sub

End Class