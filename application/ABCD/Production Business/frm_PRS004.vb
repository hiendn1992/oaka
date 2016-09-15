''*********************************************************
''* Copyright AIT Software CO.,ltd. 2015
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_PRS004.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   28-MAR-15    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_PRS004

#Region "Bien dung chung."

    ''' <summary>Bien web service dung de lay du lieu tu database.</summary>
    Private webService As New ABCDService.Service()

    ''' <summary>Bien giu gia tri lay duoc web service.</summary>
    Private dataTable1 As DataTable = Nothing
    Private dataTable2 As DataTable = Nothing

    ''' <summary>Bien dung de hien thi man hinh thong bao.</summary>
    Private frmMessage As frm_MSG001

    ''' <summary>Bien dung de lay so luong chuan trong mot thung.</summary>
    Private quantityPerBox As Integer = 0

    Private firstQuantity As Integer = 0
    Private lastQuantity As Integer = 0
    Private firstQuantityChanged As Integer = 0
    Private lastQuantityChanged As Integer = 0

    Private firstLotNo As String = String.Empty

    Private sumQty As Integer = 0

#End Region

#Region "Phuong thuc khoi tao man hinh."

    ''' <summary>
    ''' Phuong thuc khoi tao.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        '' Cap nhat lai Url va Time-out cho web service.
        webService.Url = ABCDConst.STRING_URL
        webService.Timeout = ABCDConst.STRING_TIMEOUT

    End Sub

#End Region

#Region "Phuong thuc chung."

    ''' <summary>
    ''' Phuong thuc clear tat ca cac gia tri o TextBox.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearValueInTextBox()

        txt_wo_no.Clear() '' 1. Clear w/o no.
        txt_part_no.Clear() '' 2. Clear item code(Part No).
        txt_part_name.Clear() '' 3. Clear item name(Part Name).
        txt_barcode_no.Clear() '' 4. Clear barcode no(barcode cua thung le dau tien).
        txt_lot_no.Clear() '' 5. Clear lot no(lot no cua thung le dau tien ung voi barcode).
        txt_quantity.Clear() '' 6. Clear quantity(quantity cua thung le dau tien ung voi barcode).
        txt_barcode_to.Clear() '' 7. Clear barcode no(barcode cua thung le cuoi cung).
        txt_lot_no_to.Clear() '' 8. Clear lot no(lot no cua thung le cuoi cung ung voi barcode).
        txt_quantity_to.Clear() '' 9. Clear quantity(quantity cua thung le cuoi cung ung voi barcode).

    End Sub

    ''' <summary>
    ''' Phuong thuc enable/disable cac nut Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableButtonAndTextBox()

        btn_execute.Enabled = False '' 1. Disable execute.
        btn_cancel.Enabled = False '' 2. Disable cancel.
        btn_reissue.Enabled = False '' 3. Disable reissue.

        txt_part_no.Enabled = False '' 1. Disable item code(part no).
        txt_part_name.Enabled = False '' 2. Disable item name(part name).

        txt_barcode_no.Enabled = False '' 1. Disable barcode no from.
        txt_lot_no.Enabled = False '' 2. Disable lot no of barcode no from.
        txt_quantity.Enabled = False '' 3. Disable quantity of barcode no from.

        txt_barcode_to.Enabled = False '' 1. Disable barcode no to.
        txt_lot_no_to.Enabled = False '' 2. Disable lot no of barcode no to.
        txt_quantity_to.Enabled = False '' 3. Disable quantity of barcode no to.

    End Sub

    ''' <summary>
    ''' Phuong thuc lay thong tin cua so thung le dau tien ung voi W/O No.
    ''' </summary>
    ''' <param name="dataTable">Du lieu duoc lay tu web service.</param>
    ''' <param name="quantityPerBox">So luong chuan trong mot thung.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFirstBoxByWorkOrder(ByVal dataTable As DataTable, ByVal quantityPerBox As Integer) As Boolean

        '' Duyet qua toan bo cac dong du lieu lay duoc tu web service.
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1

            '' Neu so luong cua dong du lieu it hon so luong chuan trong mot thung thi lam nhu sau:
            If Integer.Parse(Trim(dataTable.Rows(i)("QTY").ToString)) < quantityPerBox Then

                '' Thiet lap thong tin cua Item: PartNo, PartName.
                txt_part_no.Text = Trim(dataTable.Rows(0)("ITEM_CD").ToString())
                txt_part_name.Text = Trim(dataTable.Rows(0)("ITEM_NM").ToString())

                '' Cap nhat gia tri hien thi cho so thung bi le dau tien: Barcode, LotNo, Quantity.
                txt_barcode_no.Text = Trim(dataTable.Rows(i)("BC_NO").ToString)
                txt_lot_no.Text = Trim(dataTable.Rows(i)("LOT_NO").ToString)
                firstLotNo = txt_lot_no.Text '' Gan gia tri LotNo cua thung le dau tien cho firstLotNo.
                txt_quantity.Text = Trim(dataTable.Rows(i)("QTY").ToString)
                firstQuantity = Integer.Parse(txt_quantity.Text)
                firstQuantityChanged = Integer.Parse(txt_quantity.Text)

                Return False '' Co thung le so luong.

            End If

        Next

        Return True '' Khong co thung le so luong.

    End Function

    ''' <summary>
    ''' Phuong thuc lay thong tin cua so thung le cuoi cung ung voi W/O No.
    ''' </summary>
    ''' <param name="dataTable">Du lieu duoc lay tu web service.</param>
    ''' <param name="quantityPerBox">So luong chuan trong mot thung.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLastBoxByWorkOrder(ByVal dataTable As DataTable, ByVal quantityPerBox As Integer) As Boolean

        '' Duyet qua toan bo cac dong du lieu lay duoc tu web service.
        'For i As Integer = dataTable.Rows.Count - 1 To 0 Step -1

        '' Neu so luong cua dong du lieu it hon so luong chuan trong mot thung thi lam nhu sau:
        If Integer.Parse(Trim(dataTable.Rows(dataTable.Rows.Count - 1)("QTY").ToString)) < quantityPerBox Then

            '' Cap nhat gia tri hien thi cho so thung bi le dau tien: Barcode, LotNo, Quantity.
            txt_barcode_to.Text = Trim(dataTable.Rows(dataTable.Rows.Count - 1)("BC_NO").ToString)
            txt_lot_no_to.Text = Trim(dataTable.Rows(dataTable.Rows.Count - 1)("LOT_NO").ToString)
            txt_quantity_to.Text = Trim(dataTable.Rows(dataTable.Rows.Count - 1)("QTY").ToString)
            lastQuantity = Integer.Parse(Trim(dataTable.Rows(dataTable.Rows.Count - 1)("QTY").ToString))

            Return False '' Co thung le so luong.

        End If

        'Next

        Return True '' Khong co thung le so luong.

    End Function

    ''' <summary>
    ''' Phuong thuc cap nhat lai so luong cua thung cuoi cung.
    ''' </summary>
    ''' <param name="quantityFirst">So luong cua thung dau.</param>
    ''' <param name="quantityLast">So luong cua thung cuoi.</param>
    ''' <remarks></remarks>
    Private Sub UpdatePieceLastBox(ByVal quantityFirst As String, ByVal quantityLast As String)
        If quantityFirst.Equals("") Then
            quantityFirst = "0"
        End If
        '' Thuc hien tinh toan cap nhat lai so luong cua thung cuoi cung.
        'txt_quantity_to.Text = Math.Abs(Integer.Parse(quantityFirst) - firstQuantity - quantityLast).ToString
        'lastQuantity = Integer.Parse(txt_quantity_to.Text.Replace(",", ""))
        Dim fst As Integer = Integer.Parse(txt_quantity.Text.Replace(",", ""))
        Dim lst As Integer = sumQty - fst
        txt_quantity_to.Text = lst.ToString("#,###")
        '' Error 20150403: txt_quantity_to sau khi convert la rong.
        If txt_quantity_to.Text.Equals(String.Empty) Then
            txt_quantity_to.Text = "0"
        End If
    End Sub

#End Region

#Region "Su kien cua man hinh."

    ''' <summary>
    ''' Su kien load man hinh ban dau.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_PRS004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.infoLoginToday.Text = ABCDCommon.GetSystemDateWithFormat()
        '' Clear tat ca cac gia tri o TextBox.
        ClearValueInTextBox()
        '' Enable/Disable cac nut Button ban dau.
        EnableButtonAndTextBox()
    End Sub

    ''' <summary>
    ''' Su kien leave khoi TextBox W/O No.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_wo_no_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_wo_no.Leave

        '' Khi focus vo nut Button Exit.
        If btn_exit.Focused Then
            Return
        End If

        '' Truong hop khong nhap gia tri vao TextBox W/O No.
        If txt_wo_no.Text.Equals("") Then

            frmMessage = New frm_MSG001(Messages.ERR00501, "ERR00501") '' Message Error: Please insert W/O No !.
            frmMessage.ShowDialog() '' Hien thi man hinh thong bao loi.
            txt_wo_no.Focus()

            Return '' Thoat khoi su kien.

        End If

        dataTable1 = Nothing '' Khoi tao gia tri cua bien dataTable1 la rong.
        '' Goi method GetItemDetailByWorkNoOrderBarcodeAsc tu web service de lay du lieu.
        dataTable1 = webService.GetItemDetailByWorkNoOrderBarcodeAsc(txt_wo_no.Text, ABCDCommon.UserId).Tables(0)

        '' Truong hop khong lay duoc du lieu nao ung voi W/O No duoc nhap trong TextBox.
        If dataTable1.Rows.Count = 0 Then

            frmMessage = New frm_MSG001(Messages.ERR010, "ERR010") '' Message Error: Data not found !.
            frmMessage.ShowDialog() '' Hien thi man hinh thong bao loi.
            txt_wo_no.Focus()
            txt_wo_no.SelectAll()

            Return '' Thoat khoi su kien.

        End If

        dataTable2 = Nothing '' Khoi tao gia tri cua bien dataTable2 la rong.
        '' Goi method GetWOInfoByWONo tu web service de lay du lieu.
        dataTable2 = webService.GetWOInfoByWONo(txt_wo_no.Text, ABCDCommon.UserId).Tables(0)
        quantityPerBox = Integer.Parse(Trim(dataTable2.Rows(0)("QTY_PER_BOX").ToString)) '' Cap nhat gia tri so luong chuan trong mot thung.

        '' Hien thi thong tin so thung le dau tien ung voi W/O No.
        If GetFirstBoxByWorkOrder(dataTable1, quantityPerBox) = True Then

            frmMessage = New frm_MSG001(Messages.INF00408, "INF00408") '' Message Info: Don't have box is not enough quantity !.
            frmMessage.ShowDialog() '' Hien thi man hinh thong bao.
            txt_wo_no.Focus()
            txt_wo_no.SelectAll()

            Return '' Thoat khoi su kien.

        End If

        '' Hien thi thong tin so thung le cuoi cung ung voi W/O No.
        If GetLastBoxByWorkOrder(dataTable1, quantityPerBox) = False Then
            '' Truong hop W/O No chi co dung mot thung bi le.
            If txt_quantity.Text.Equals(txt_quantity_to.Text) Then
                If txt_barcode_no.Text.Equals(txt_barcode_to.Text) Then
                    'frmMessage = New frm_MSG001(Messages.INF00409, "INF00409") '' Message Info: W/O No have only box not enough quantity !
                    'frmMessage.ShowDialog() '' Hien thi thong bao.
                    '' Enable/Disable cac control: TextBox, Button nhu sau:
                    txt_wo_no.Enabled = False
                    btn_cancel.Enabled = True
                    Return '' Thoat khoi su kien.
                End If
            End If
        Else
            txt_barcode_to.Text = Trim(dataTable1.Rows(dataTable1.Rows.Count - 1)("BC_NO").ToString)
            txt_lot_no_to.Text = Trim(dataTable1.Rows(dataTable1.Rows.Count - 1)("LOT_NO").ToString)
            txt_quantity_to.Text = Trim(dataTable1.Rows(dataTable1.Rows.Count - 1)("QTY").ToString)
            txt_quantity_to.Text = Integer.Parse(txt_quantity_to.Text.Replace(",", "")).ToString("#,###")
            If txt_barcode_no.Text.Equals(txt_barcode_to.Text) Then
                btn_cancel.Enabled = True
                txt_wo_no.Enabled = False
                txt_lot_no.Enabled = False
                txt_quantity.Enabled = False
                Return
            End If
        End If

        '' Dinh dang lai format so luong cua thung.
        txt_quantity.Text = Integer.Parse(txt_quantity.Text.Replace(",", "")).ToString("#,###")
        txt_quantity_to.Text = Integer.Parse(txt_quantity_to.Text.Replace(",", "")).ToString("#,###")
        sumQty = Integer.Parse(txt_quantity.Text.Replace(",", "")) + Integer.Parse(txt_quantity_to.Text.Replace(",", ""))

        '' Enable/Disable cac control: TextBox, Button nhu sau:
        btn_execute.Enabled = True
        btn_cancel.Enabled = True
        txt_lot_no.Enabled = True
        txt_quantity.Enabled = True
        txt_wo_no.Enabled = False

        '' Visible "*" doi voi nhung hang muc bat buoc.
        txt_required_1.Visible = True
        txt_required_2.Visible = True

        '' Thiet lap focus o hang muc tiep theo.
        txt_lot_no.Focus()
        txt_lot_no.SelectAll()

    End Sub

    ''' <summary>
    ''' Su kien click Button Exit khoi man hinh.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click

        Close() '' Dong man hinh dang hien thi.

    End Sub

    ''' <summary>
    ''' Su kien click Button Cancel de xoa du lieu lay duoc tu W/O No.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click

        '' Clear tat ca cac gia tri co tren man hinh tru W/O No.
        txt_part_no.Clear() '' PartNo(item code).
        txt_part_name.Clear() '' PartName(item name).

        txt_barcode_no.Clear() '' Barcode From(Barcode thung le dau tien).
        txt_lot_no.Clear() '' Lot No From(LotNo ung voi Barcode thung le dau tien).
        txt_quantity.Clear() '' Quantity From(Quantity ung voi Barcode thung le dau tien).

        txt_barcode_to.Clear() '' Barcode To(Barcode thung le cuoi cung).
        txt_lot_no_to.Clear() '' Lot No To(LotTo ung voi Barcode thung le cuoi cung).
        txt_quantity_to.Clear() '' Quantity To(Quantity ung voi Barcode thung le cuoi cung).

        '' Enable/Disable cac control: TextBox, Button.
        txt_wo_no.Enabled = True

        txt_part_no.Enabled = False
        txt_part_name.Enabled = False

        txt_barcode_no.Enabled = False
        txt_lot_no.Enabled = False
        txt_quantity.Enabled = False

        txt_barcode_to.Enabled = False
        txt_lot_no_to.Enabled = False
        txt_quantity_to.Enabled = False

        btn_cancel.Enabled = False
        btn_execute.Enabled = False
        btn_reissue.Enabled = False

        '' Visible "*" nhung hang muc bat buoc.
        txt_required_1.Visible = False
        txt_required_2.Visible = False

        '' Thiet lap lai focus sau khi click Button Cancel.
        txt_wo_no.Focus()
        txt_wo_no.SelectAll()

    End Sub

    ''' <summary>
    ''' Su kien KeyPress de gia tri nhap tu keyboard vao TextBox W/O No chi duoc nhap so.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_wo_no_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_wo_no.KeyPress

        '' Su dung method InputNumberFromKeyboard duoc viet chung.
        ABCDCommon.InputNumberFromKeyboard(e)

    End Sub

    ''' <summary>
    ''' Su kien Leave khoi TextBox LotNo.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_lot_no_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lot_no.Leave

        '' Khi focus tai Quantity.
        If txt_quantity.Focused Then
            Return
        End If

        '' Khi focus tai Execute.
        If btn_execute.Focused Then
            Return
        End If

        '' Khi focus tai Cancel.
        If btn_cancel.Focused Then
            Return
        End If

        '' Khi focus tai Exit.
        If btn_exit.Focused Then
            Return
        End If

        '' Truong hop LotNo la rong.
        If txt_lot_no.Text.Equals("") Then

            frmMessage = New frm_MSG001(Messages.ERR00405, "ERR00405") '' Message Error: Please insert Lot No !.
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_lot_no.Text = firstLotNo '' Gan lai gia tri LotNo cho TextBox LotNo tren man hinh.
            txt_lot_no.Focus()
            txt_lot_no.SelectAll()

            Return '' Thoat khoi su kien.

        End If

        '' Thiet lap lai dinh dang cua Quantity.
        txt_quantity.Text = txt_quantity.Text.Replace(",", "")

    End Sub

    ''' <summary>
    ''' Su kien Leave khoi TextBox Quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_quantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_quantity.Leave

        '' Khi focus tai LotNo.
        If txt_lot_no.Focused Then
            If Not txt_quantity.Text.Equals("") Then
                txt_quantity.Text = Integer.Parse(txt_quantity.Text.Replace(",", "")).ToString("#,###")
                If txt_quantity.Text.Equals("") Then
                    txt_quantity.Text = "0"
                End If
                UpdatePieceLastBox(txt_quantity.Text.Replace(",", ""), lastQuantity)
            End If
            Return
        End If

        '' Khi focus tai Execute.
        If btn_execute.Focused Then
            If Not txt_quantity.Text.Equals("") Then
                txt_quantity.Text = Integer.Parse(txt_quantity.Text.Replace(",", "")).ToString("#,###")
                If txt_quantity.Text.Equals("") Then
                    txt_quantity.Text = "0"
                End If
                UpdatePieceLastBox(txt_quantity.Text.Replace(",", ""), lastQuantity)
            End If
            Return
        End If

        '' Khi focus tai Cancel.
        If btn_cancel.Focused Then
            Return
        End If

        '' Khi focus tai Exit.
        If btn_exit.Focused Then
            Return
        End If

        '' Truong hop Quantity la rong.
        If txt_quantity.Text.Equals("") Then
            frmMessage = New frm_MSG001(Messages.ERR00403, "ERR00403") '' Message Error: Please insert Quantity !.
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_quantity.Text = firstQuantity.ToString("#,###")
            txt_quantity.Focus()
            txt_quantity.SelectAll()
            Return '' Thoat khoi su kien.
        End If

        '' Truong hop Quantity bi giam.
        If Integer.Parse(txt_quantity.Text.Replace(",", "")) < firstQuantity Then
            frmMessage = New frm_MSG001(Messages.PRS004_04, "ERR00404") '' Message Error: .
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_quantity.Text = (sumQty - Integer.Parse(txt_quantity_to.Text.Replace(",", ""))).ToString("#,###")
            UpdatePieceLastBox(txt_quantity.Text.Replace(",", ""), lastQuantity)
            txt_quantity.Focus()
            txt_quantity.SelectAll()
            Return '' Thoat khoi su kien.
        End If

        '' Truong hop Quantity tang vuot so luong chuan.
        If Integer.Parse(txt_quantity.Text.Replace(",", "")) > quantityPerBox Then
            frmMessage = New frm_MSG001(Messages.PRS004_05, "ERR00405") '' Message Error: .
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_quantity.Text = firstQuantityChanged.ToString()
            txt_quantity.Focus()
            txt_quantity.SelectAll()
            Return '' Thoat khoi su kien.
        End If

        '' Thiet lap lai dinh dang cua Quantity.
        txt_quantity.Text = Integer.Parse(txt_quantity.Text.Replace(",", "")).ToString("#,###")

        '' Cap nhat lai gia tri cua Quantity so thung cua thieu cuoi cung.
        UpdatePieceLastBox(txt_quantity.Text.Replace(",", ""), lastQuantity)

    End Sub

    ''' <summary>
    ''' Su kien thay doi gia tri Quantity.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_quantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_quantity.TextChanged
        '' Truong hop khi gia tri nhap khac rong.
        If Not txt_quantity.Text.Replace(",", "").Equals("") Then
            '' Truong hop gia tri nhap lon gia tri ban dau va nho hon gia tri so luong thung chuan.
            If Integer.Parse(txt_quantity.Text.Replace(",", "")) >= firstQuantity And Integer.Parse(txt_quantity.Text.Replace(",", "")) <= quantityPerBox Then
                '' Cap nhat gia tri
                firstQuantityChanged = Integer.Parse(txt_quantity.Text.Replace(",", ""))
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_execute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_execute.Click
        '' Truong hop LotNo la rong.
        If txt_lot_no.Text.Equals("") Then
            frmMessage = New frm_MSG001(Messages.ERR00405, "ERR00405") '' Message Error: Please insert Lot No !.
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_lot_no.Text = firstLotNo '' Gan lai gia tri LotNo cho TextBox LotNo tren man hinh.
            txt_lot_no.Focus()
            txt_lot_no.SelectAll()
            Return '' Thoat khoi su kien.
        End If

        '' Truong hop Quantity la rong.
        If txt_quantity.Text.Equals("") Then
            frmMessage = New frm_MSG001(Messages.ERR00403, "ERR00403") '' Message Error: Please insert Quantity !.
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_quantity.Text = firstQuantity.ToString("#,###")
            txt_quantity.Focus()
            txt_quantity.SelectAll()
            Return '' Thoat khoi su kien.
        End If

        '' Truong hop Quantity bi giam.
        If Integer.Parse(txt_quantity.Text.Replace(",", "")) < firstQuantity Then
            frmMessage = New frm_MSG001(Messages.PRS004_04, "ERR00404") '' Message Error: .
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_quantity.Text = firstQuantity.ToString()
            UpdatePieceLastBox(txt_quantity.Text.Replace(",", ""), lastQuantity)
            txt_quantity.Focus()
            txt_quantity.SelectAll()
            Return '' Thoat khoi su kien.
        End If

        '' Truong hop Quantity tang vuot so luong chuan.
        If Integer.Parse(txt_quantity.Text.Replace(",", "")) > quantityPerBox Then
            frmMessage = New frm_MSG001(Messages.PRS004_05, "ERR00405") '' Message Error: .
            frmMessage.ShowDialog() '' Hien thi thong bao loi.
            txt_quantity.Text = firstQuantityChanged.ToString()
            txt_quantity.Focus()
            txt_quantity.SelectAll()
            Return '' Thoat khoi su kien.
        End If

        Dim currentBoxNum As Integer = 0
        Dim row As Integer = 0
        '' Neu so luong(quantity) cua thung le cuoi cung hien thi o TextBox la 0.
        If txt_quantity_to.Text.Equals("0") Then
            dataTable2 = Nothing
            dataTable2 = webService.GetItemInfoByCd(txt_part_no.Text, ABCDCommon.UserId).Tables(0)
            currentBoxNum = Integer.Parse(Trim(dataTable2.Rows(0)("CUR_BOX_NUM").ToString))
            currentBoxNum = currentBoxNum - 1 '' Giam so luong thung.
        End If
        '' Xu ly qua trinh cap nhat du lieu.
        Try
            frmMessage = New frm_MSG001(Messages.MSG037, "MSG037")
            If frmMessage.ShowDialog = Windows.Forms.DialogResult.Yes Then
                txt_lot_no.Enabled = False
                txt_quantity.Enabled = False
                btn_execute.Enabled = False
                btn_cancel.Enabled = False
                btn_exit.Enabled = False
                row = webService.UpdateQuantityInBoxByBarcode(txt_barcode_no.Text, txt_lot_no.Text, Integer.Parse(txt_quantity.Text.Replace(",", "")), _
                                                              txt_barcode_to.Text, txt_lot_no_to.Text, Integer.Parse(txt_quantity_to.Text.Replace(",", "")), _
                                                              txt_part_no.Text, currentBoxNum, _
                                                              ABCDCommon.UserId)

                btn_cancel.Enabled = True
                btn_exit.Enabled = True
                If row > 0 Then '' Co hon mot dong du lieu duoc cap nhat.
                    frmMessage = New frm_MSG001(Messages.INF038, "INF038")
                    frmMessage.ShowDialog()
                    btn_reissue.Enabled = True
                    '' Xuat ra file csv de in Label moi chinh sua.
                    dataTable2 = Nothing
                    dataTable2 = webService.GetPrintBarcode(txt_quantity_to.Text, ABCDCommon.UserId).Tables(0)
                    '' Luu file csv.
                    Dim pathNm As String = Configuration.ConfigurationManager.AppSettings("PathSaveLabel") & "PRS004_MERGELOTNO" & Date.Now.ToString("yyyyMMddHHmmss") & ".csv"
                    ABCDCommon.ExportDataTableIntoCSV(dataTable2, pathNm)
                    Return
                End If
                txt_lot_no.Enabled = True
                txt_quantity.Enabled = True
                btn_execute.Enabled = True
            End If
        Catch ex As Exception
            frmMessage = New frm_MSG001(ex.Message, "ERR9004")
            frmMessage.ShowDialog()
            Return
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_reissue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reissue.Click
        Try
            btn_reissue.Enabled = False
            btn_cancel.Enabled = False
            btn_exit.Enabled = False
            '' Xuat ra file csv de in Label moi chinh sua.
            dataTable2 = Nothing
            dataTable2 = webService.GetPrintBarcode(txt_quantity_to.Text, ABCDCommon.UserId).Tables(0)
            '' Luu file csv.
            Dim pathNm As String = Configuration.ConfigurationManager.AppSettings("PathSaveLabel") & "PRS004_REMERGELOTNO" & Date.Now.ToString("yyyyMMddHHmmss") & ".csv"
            ABCDCommon.ExportDataTableIntoCSV(dataTable2, pathNm)
            btn_reissue.Enabled = True
            btn_cancel.Enabled = True
            btn_exit.Enabled = True
        Catch ex As Exception
            frmMessage = New frm_MSG001(ex.Message, "ERR9004")
            frmMessage.ShowDialog()
            btn_reissue.Enabled = True
            btn_cancel.Enabled = True
            btn_exit.Enabled = True
            Return
        End Try
    End Sub

#End Region

End Class