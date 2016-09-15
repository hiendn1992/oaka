''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_SHS001.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   15-JAN-15    1.00     Toannn   New
''*********************************************************
Imports ABCD.My.Resources

Public Class frm_SHS001

#Region "Var/Const Form"

    Private Const SHIPMENT_STATUS_IN_COMP As String = "Shipment Status: Incomplete"
    Private Const SHIPMENT_STATUS_COMP As String = "Shipment Status: Completed"
    Private Const SHIPMENT_STATUS As String = "Shipment Status: -"

    Private ws As New ABCDService.Service
    Private loginCode As String = ABCDCommon.UserId
    Private dt As New DataTable("detailDt")
    Private isViewDetailOnly As Boolean = False
    Private _shipReqNoReq As String = String.Empty
    Private barcode As String = String.Empty
    'AIT Hungtg start 05/08/2015
    Private shipInquiryCallFromFlag As Boolean = False
    'AIT Hungtg end 05/08/2015

    Public _mode As Integer = ABCDConst.ModeInit
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
        End Set
    End Property

    Private _display As Integer = ABCDConst.DispInit
    Public Property Display() As Integer
        Get
            Return _display
        End Get
        Set(ByVal value As Integer)
            _display = value
        End Set
    End Property

#End Region

#Region "New Form"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal shipReqNo As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me._shipReqNoReq = shipReqNo

        ''AIT Hungtg start 05/08/2015
        Me.btn_export.Enabled = True
        shipInquiryCallFromFlag = True
        ''AIT Hungtg end 05/08/2015

    End Sub

#End Region

#Region "Event Form"

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub rdo_add_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rdo_add.CheckedChanged
        If rdo_add.Checked Then
            Me.Mode = ABCDConst.ModeAdd
            Me.Display = ABCDConst.DispTwice
            SetEnableState()
        End If
    End Sub

    Private Sub rdo_chg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rdo_chg.CheckedChanged
        If rdo_chg.Checked Then
            Me.Mode = ABCDConst.ModeUpd
            Me.Display = ABCDConst.DispOnce
            SetEnableState()
        End If
    End Sub

    Private Sub rdo_del_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rdo_del.CheckedChanged
        If rdo_del.Checked Then
            Me.Mode = ABCDConst.ModeDel
            Me.Display = ABCDConst.DispOnce
            SetEnableState()
        End If
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        ClearAllInput()
    End Sub

    Private Sub txt_shipment_req_no_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_shipment_req_no.Leave
        Dim controlList As New List(Of Control)(New Control() {btn_shipment_req_no, btn_cancel, btn_exit})
        If Not ABCDCommon.CheckFocusedControls(controlList) Then
            Return
        End If
        txt_shipment_req_no.Text = Trim(txt_shipment_req_no.Text)
        If Not String.IsNullOrEmpty(txt_shipment_req_no.Text) Then
            Dim resultItem = ws.GetShipmentInfoByShipmentReqNo(txt_shipment_req_no.Text, loginCode)
            If IsNothing(resultItem) OrElse resultItem.Tables(0).Rows.Count = 0 Then
                Dim msgScreen As New frm_MSG001("This Shipment Request No does not exist!", "ERR081")
                If msgScreen.ShowDialog() = DialogResult.OK Then
                    msgScreen.Close()
                End If
                txt_shipment_req_no.Focus()
                txt_shipment_req_no.SelectAll()
            Else
                SetShipmentReqInfo(resultItem)
                Display = 2
            End If
        Else
            txt_shipment_req_no.Text = String.Empty
            lbl_shipment_status.Text = SHIPMENT_STATUS
            Display = ABCDConst.DispTwice
        End If
    End Sub

    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dat_shipment_req_date.ValueChanged, dat_shipment_date.ValueChanged, dat_invoice_date.ValueChanged
        Call ABCDCommon.ChangeDateTimePicker(sender)
    End Sub

    Private Sub txt_customer_cd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_customer_cd.Leave
        txt_customer_cd.Text = Trim(txt_customer_cd.Text)
        If Not String.IsNullOrEmpty(txt_customer_cd.Text) Then
            Dim resultItem = ws.GetCustomerInfoByID(txt_customer_cd.Text, loginCode)
            If IsNothing(resultItem) OrElse resultItem.Tables(0).Rows.Count = 0 Then
                Dim msgScreen As New frm_MSG001("Customer code does not exist!", "ERR021")
                If msgScreen.ShowDialog() = DialogResult.OK Then
                    msgScreen.Close()
                End If
                txt_customer_cd.Focus()
                txt_customer_cd.SelectAll()
            Else
                Dim cusName As String = Trim(resultItem.Tables(0).Rows(0)("CUS_NM").ToString)
                txt_customer_name.Text = cusName
            End If
        Else
            txt_customer_cd.Text = String.Empty
            txt_customer_name.Text = String.Empty
        End If
    End Sub

    Private Sub btn_execute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_execute.Click

        If Mode = ABCDConst.ModeAdd OrElse Mode = ABCDConst.ModeUpd Then

            If Not IsValidInput() Then
                Exit Sub
            End If

            Dim msgScreen As New frm_MSG001("Are you sure to update shipment data?", "MSG084")
            If Not msgScreen.ShowDialog() = DialogResult.Yes Then
                Exit Sub
            End If

            If Mode = ABCDConst.ModeAdd Then
                Try
                    Dim newShipReqNo As String = ws.InsertShipReqInfoTrWithDetail(dat_shipment_req_date.Value.Date, _
                                                                      dat_shipment_date.Value.Date, _
                                                                      txt_customer_cd.Text, _
                                                                      Trim(txt_po_no.Text), _
                                                                      Trim(txt_invoice_no.Text), _
                                                                      dat_invoice_date.Value.Date, _
                                                                      dt, _
                                                                      loginCode)

                    If Not String.IsNullOrEmpty(newShipReqNo) Then
                        Dim scrInfo As New frm_MSG001("Shipment data was registered.", "INF086")

                        If scrInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                            btn_cancel_Click(btn_cancel, New EventArgs())
                            rdo_add.Checked = CheckState.Checked
                            dat_shipment_req_date.Focus()
                        End If
                    End If

                Catch ex As Exception
                    Dim scrError As New frm_MSG001(ex.Message, "ERRSYS")
                    scrError.ShowDialog()
                End Try

            ElseIf Mode = ABCDConst.ModeUpd Then
                If ExecuteUpdate() > 0 Then
                    Dim scrInfo As New frm_MSG001("Shipment data is updated.", "INF087")

                    If scrInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                        btn_cancel_Click(btn_cancel, New EventArgs())
                        rdo_chg.Checked = CheckState.Checked
                        txt_shipment_req_no.Focus()
                    End If
                End If
            End If

        ElseIf Mode = ABCDConst.ModeDel Then
            Dim msgScreen As New frm_MSG001("Are you sure to delete shipment data?", "MSG085")
            If Not msgScreen.ShowDialog() = DialogResult.Yes Then
                Exit Sub
            End If

            Try
                Dim rowMasterDeleted As Integer = ws.DeleteShipmentReqInfoTrByCd(txt_shipment_req_no.Text, loginCode)

                If rowMasterDeleted > 0 Then
                    Dim scrInfo As New frm_MSG001("Shipment data was deleted.", "INF088")

                    If scrInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                        btn_cancel_Click(btn_cancel, New EventArgs())
                        rdo_del.Checked = CheckState.Checked
                        txt_shipment_req_no.Focus()
                    End If
                End If
            Catch ex As Exception
                Dim scrError As New frm_MSG001(ex.Message, "ERRSYS")
                scrError.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub btn_customer_cd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_customer_cd.Click
        Dim scrPos005 As New frm_POS005(Me)
        scrPos005.ShowDialog()
        txt_customer_cd.Focus()
    End Sub

    Private Sub btn_select_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select_all.Click
        For i As Integer = 0 To grd_ship_list.Rows.Count - 1 Step 1
            grd_ship_list.Rows(i).Cells(0).Value = "True"
        Next
    End Sub

    Private Sub btn_unselect_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_unselect_all.Click
        For i As Integer = 0 To grd_ship_list.Rows.Count - 1 Step 1
            grd_ship_list.Rows(i).Cells(0).Value = "False"
        Next
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        Me.barcode = String.Empty
        If grd_ship_list.RowCount > 0 Then
            For i As Integer = 0 To grd_ship_list.Rows.Count - 1
                If i <> 0 Then
                    barcode = barcode & ","
                End If
                barcode = barcode & grd_ship_list.Rows(i).Cells(2).Value.ToString
            Next
        End If
        Dim scrShs003 As New frm_SHS003(Me, barcode)
        Dim dataTable As DataTable = Nothing
        scrShs003.ShowDialog()
        '// Chg Start Ait)Cuongtk 20160324
        If grd_ship_list.RowCount > 0 Then
            Dim t As DataTable = TryCast(grd_ship_list.DataSource, DataTable)
            Dim dataView As New DataView(t)
            dataView.Sort = "PALLET_NO ASC, BC_NO ASC"
            grd_ship_list.DataSource = dataView.ToTable
        End If
        '// Chg E n d Ait)Cuongtk 20160324
        'Kaidai 183: Set color for row is red. Condition Scan "0".
        grd_ship_list.ClearSelection()
        For i As Integer = 0 To grd_ship_list.Rows.Count - 1 Step 1
            If Integer.Parse(grd_ship_list.Rows(i).Cells(9).Value).Equals(0) = True Then
                grd_ship_list.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim hasScan As Boolean = False
        Dim deleteFlg As Boolean = False
        Dim hasChecked As Boolean = False

        For rowIndex As Integer = 0 To grd_ship_list.RowCount - 1 Step 1
            If grd_ship_list.Rows(rowIndex).Cells(0).Value = True Then
                hasChecked = True
            End If
        Next

        If hasChecked = False Then
            Dim frm As New frm_MSG001("Please select row !", "ERR")
            frm.ShowDialog()
            Return
        End If

        For i As Integer = grd_ship_list.Rows.Count - 1 To 0 Step -1
            Dim valueCheckBox As String = grd_ship_list.Rows(i).Cells(0).Value
            If Not IsNothing(valueCheckBox) AndAlso valueCheckBox.Equals("True") Then
                Dim valueScanFlg As String = Integer.Parse(grd_ship_list.Rows(i).Cells(9).Value).ToString
                If Not valueScanFlg = "0" Then
                    hasScan = True
                    Exit For
                End If
            End If
        Next

        If hasScan Then
            Dim msgScreen As New frm_MSG001("Selected row contains scanned Barcode. Are you sure to delete it?", "MSG083")
            If msgScreen.ShowDialog() = DialogResult.Yes Then
                deleteFlg = True
            End If
            msgScreen.Close()
        End If

        If Not hasScan OrElse (hasScan AndAlso deleteFlg) Then
            ' Do delete
            For i As Integer = grd_ship_list.Rows.Count - 1 To 0 Step -1
                Dim valueCheckBox As String = grd_ship_list.Rows(i).Cells(col_chk.Name).Value
                If Not IsNothing(valueCheckBox) AndAlso valueCheckBox.Equals("True") Then
                    For Each row As DataRow In dt.Rows
                        If row(col_barcode_no.DataPropertyName).Equals(grd_ship_list.Rows(i).Cells(col_barcode_no.Name).Value) Then
                            dt.Rows.Remove(row)
                            Exit For
                        End If
                    Next
                End If
            Next

            grd_ship_list.DataSource = dt
            grd_ship_list.Refresh()
            grd_ship_list.ClearSelection()

            '// Fix kaidai remove barcode still keep red row [cuongtk 20150824] - start
            '// Loop all data on gridview
            For i As Integer = 0 To grd_ship_list.RowCount - 1 Step 1
                '// Check row data is scan or not scan
                If Integer.Parse(grd_ship_list.Rows(i).Cells(9).Value).Equals(0) = True Then
                    grd_ship_list.Rows(i).DefaultCellStyle.BackColor = Color.Red '// Set row color is red
                End If
            Next
            '// Fix kaidai remove barcode still keep red row [cuongtk 20150824] - end
        End If
    End Sub

    Private Sub btn_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click
        'AIT Hungtg start 05/08/2015
        Dim msgScreen As frm_MSG001 = Nothing
        If Not shipInquiryCallFromFlag Then
            If SHIPMENT_STATUS_IN_COMP.Equals(lbl_shipment_status.Text) Then
                msgScreen = New frm_MSG001("Your data will be saved first, Do you want to continue?", "MSGSYS")
                If Not msgScreen.ShowDialog() = DialogResult.Yes Then
                    Exit Sub
                End If

                ExecuteUpdate()
            End If
        End If
        'AIT Hungtg end 05/08/2015
        Dim exportData As DataTable = GetExportData()

        msgScreen = New frm_MSG001("No item to export!", "ERRSYS")
        If exportData Is Nothing OrElse exportData.Rows.Count = 0 Then
            msgScreen.ShowDialog()
            Return
        End If

        sfDialog.Filter = "Excel Files (*.xlsx*) | *.xlsx"
        sfDialog.FileName = "SHS001_" & DateTime.Now.ToString(ABCDConst.Format_Date_03 & "HHmmss")
        If sfDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim filePath As String = sfDialog.FileName
            ExportDataTableToExcel(dataTable:=exportData, fileName:=sfDialog.FileName)
        End If
    End Sub

    Private Sub btn_shipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_shipment.Click

        Dim shipmentRequestNo As String = Trim(txt_shipment_req_no.Text)
        Dim shipmentRequestDate As Date = dat_shipment_req_date.Value
        Dim shipmentDate As Date = dat_shipment_date.Value
        Dim customerId As String = Trim(txt_customer_cd.Text)
        Dim customerPo As String = Trim(txt_po_no.Text)
        Dim invoiceNo As String = Trim(txt_invoice_no.Text)
        Dim invoiceDate As Date = dat_invoice_date.Value
        Dim listData As New List(Of String)

        Dim msgScreen As New frm_MSG001("There's no item to ship.", "ERR082")
        If grd_ship_list.Rows.Count = 0 Then
            msgScreen.ShowDialog()
            Exit Sub
        End If

        msgScreen = New frm_MSG001("Your data will be saved first, Do you want to continue?", "MSGSYS")
        If Not msgScreen.ShowDialog() = DialogResult.Yes Then
            Exit Sub
        End If

        For i As Integer = 0 To grd_ship_list.RowCount - 1 Step 1
            Dim stringData As String = String.Empty
            Dim barcodeNo As String = Trim(grd_ship_list.Rows(i).Cells(2).Value)
            Dim palletNo As String = Trim(grd_ship_list.Rows(i).Cells(1).Value)
            Dim lotNo As String = Trim(grd_ship_list.Rows(i).Cells(3).Value)
            Dim rackNo As String = Trim(grd_ship_list.Rows(i).Cells(4).Value.ToString)
            Dim warehouseNo As String = Trim(grd_ship_list.Rows(i).Cells(5).Value)
            Dim itemCode As String = Trim(grd_ship_list.Rows(i).Cells(6).Value)
            Dim itemName As String = Trim(grd_ship_list.Rows(i).Cells(7).Value)
            Dim quantity As Integer = Integer.Parse(grd_ship_list.Rows(i).Cells(8).Value.ToString.Replace(",", ""))
            Dim scanFlag As Integer = grd_ship_list.Rows(i).Cells(9).Value
            Dim registeredId As String = ABCDCommon.UserId
            Dim registeredDate As Date = DateTime.Now
            stringData = palletNo & "," & barcodeNo & "," & lotNo & "," & rackNo & "," & warehouseNo & "," & itemCode & "," & itemName & "," & quantity & "," & scanFlag
            listData.Add(stringData)
        Next

        ExecuteUpdate()

        Dim hasNotScan As Boolean = False
        Dim deleteFlg As Boolean = False

        For i As Integer = grd_ship_list.Rows.Count - 1 To 0 Step -1
            Dim valueScanFlg As String = grd_ship_list.Rows(i).Cells(col_scan.Name).Value
            If Not valueScanFlg = 1 Then
                hasNotScan = True
                Exit For
            End If
        Next

        If hasNotScan Then
            msgScreen = New frm_MSG001("Scan barcode is not completed.", "ERR082")
            msgScreen.ShowDialog()
            Exit Sub
        End If

        msgScreen = New frm_MSG001("Are you sure to shipment?", "MSG089")
        If Not msgScreen.ShowDialog() = DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Dim rowUpdated As Integer = ws.ExecuteShipment(shipmentRequestNo, listData.ToArray, ABCDCommon.UserId)

            If rowUpdated > 0 Then

                Dim scrInfo As New frm_MSG001("Shipment is completed.", "INF090")

                If scrInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                    btn_cancel_Click(btn_cancel, New EventArgs())
                    rdo_chg.Checked = CheckState.Checked
                    txt_shipment_req_no.Focus()
                End If
            End If
        Catch ex As Exception
            Dim scrError As New frm_MSG001(ex.Message, "ERRSYS")
            scrError.ShowDialog()
        End Try
    End Sub

    Private Sub txt_shipment_req_no_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_shipment_req_no.KeyPress
        ' when press EnterKey, send TabKey to invoke LeaveEvent
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.KeyChar = ChrW(Keys.Tab)
            'send the keystroke to the form.
            SendKeys.Send(e.KeyChar.ToString())
        End If
    End Sub

    Private Sub btn_shipment_req_no_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_shipment_req_no.Click
        Dim scrPos007 As New frm_POS007(Me)
        scrPos007.ShowDialog()
        If txt_shipment_req_no.Text.Equals("") Then
            txt_shipment_req_no.Focus()
            Return
        End If
        'txt_shipment_req_no_Leave(txt_shipment_req_no, New EventArgs())
        txt_shipment_req_no.Text = Trim(txt_shipment_req_no.Text)
        If Not String.IsNullOrEmpty(txt_shipment_req_no.Text) Then
            Dim resultItem = ws.GetShipmentInfoByShipmentReqNo(txt_shipment_req_no.Text, loginCode)
            If IsNothing(resultItem) OrElse resultItem.Tables(0).Rows.Count = 0 Then
                Dim msgScreen As New frm_MSG001("This Shipment Request No does not exist!", "ERR081")
                If msgScreen.ShowDialog() = DialogResult.OK Then
                    msgScreen.Close()
                End If
                txt_shipment_req_no.Focus()
                txt_shipment_req_no.SelectAll()
            Else
                SetShipmentReqInfo(resultItem)
                Display = 2
            End If
        Else
            txt_shipment_req_no.Text = String.Empty
            lbl_shipment_status.Text = SHIPMENT_STATUS
            Display = ABCDConst.DispTwice
        End If
    End Sub

    Private Sub frm_SHS001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me._shipReqNoReq = String.Empty Then
            '' Init data
            InitData()
        Else
            '' Init data
            InitData()
            If Not String.IsNullOrEmpty(Trim(Me._shipReqNoReq)) Then
                isViewDetailOnly = True
                rdo_chg.Checked = CheckState.Checked
                txt_shipment_req_no.Text = _shipReqNoReq
                txt_shipment_req_no_Leave(txt_shipment_req_no, New EventArgs())
                btn_export.Enabled = True
            End If
        End If
    End Sub

#End Region

#Region "Function Form"

    Private Sub SetEnableState(Optional ByVal isAfterLoadShipment As Boolean = False)

        ' If view detail from SHS006
        If isViewDetailOnly Then
            SetEnableAllInput(False)
            btn_export.Enabled = True
            Exit Sub
        End If

        If Not isAfterLoadShipment Then
            dat_shipment_req_date.Value = DateTime.Now
            ABCDCommon.InitDateTimePicker(dat_shipment_req_date)

            dat_shipment_date.Value = DateTime.Now
            ABCDCommon.InitDateTimePicker(dat_shipment_date)

            dat_invoice_date.Value = DateTime.Now
            ABCDCommon.InitDateTimePicker(dat_invoice_date)
        End If

        ' Init State
        If Display = ABCDConst.DispInit Then

            lbl_shipment_status.Text = SHIPMENT_STATUS

            grd_ship_list.DataSource = Nothing

            SetEnableAllInput(False)

            rdo_add.Checked = CheckState.Unchecked
            rdo_chg.Checked = CheckState.Unchecked
            rdo_del.Checked = CheckState.Unchecked

            rdo_add.Enabled = True
            rdo_chg.Enabled = True
            rdo_del.Enabled = True

        ElseIf Display = ABCDConst.DispTwice Then
            ' Enable state for Add mode

            SetEnableAllInput(True)

            rdo_add.Enabled = False
            rdo_chg.Enabled = False
            rdo_del.Enabled = False

            txt_shipment_req_no.Enabled = False

            btn_export.Enabled = False
            btn_shipment.Enabled = False

        ElseIf Display = ABCDConst.DispOnce Then
            ' Enable state for Change/Delete mode

            If isAfterLoadShipment Then
                ' case after load with ChangeMode
                If Mode = ABCDConst.ModeUpd Then
                    SetEnableAllInput(True)
                    rdo_add.Enabled = False
                    rdo_chg.Enabled = False
                    rdo_del.Enabled = False

                    txt_shipment_req_no.Enabled = False
                ElseIf Mode = ABCDConst.ModeDel Then
                    SetEnableAllInput(False)
                    btn_execute.Enabled = True
                End If
            Else
                SetEnableAllInput(False)
                txt_shipment_req_no.Enabled = True
                txt_shipment_req_no.Focus()
            End If

            btn_cancel.Enabled = True
        End If

        btn_shipment_req_no.Enabled = txt_shipment_req_no.Enabled
    End Sub

    Private Sub SetShipmentReqInfo(ByVal ds As DataSet)
        Dim detailDs As DataSet = Nothing

        ' Set general info
        Dim compFlg As Integer = Integer.Parse(ds.Tables(0).Rows(0)("COMP_FLG").ToString)
        If compFlg = 0 Then
            lbl_shipment_status.Text = SHIPMENT_STATUS_IN_COMP
        Else
            lbl_shipment_status.Text = SHIPMENT_STATUS_COMP
        End If

        dat_shipment_req_date.Value = Date.Parse(ds.Tables(0).Rows(0)("SHIP_REQ_DT").ToString)
        dat_shipment_date.Value = Date.Parse(ds.Tables(0).Rows(0)("SHIP_DT").ToString)
        txt_customer_cd.Text = ds.Tables(0).Rows(0)("CUS_ID").ToString
        txt_customer_name.Text = ws.GetCustomerInfoByID(txt_customer_cd.Text, loginCode).Tables(0).Rows(0)("CUS_NM").ToString
        txt_po_no.Text = ds.Tables(0).Rows(0)("CUS_PO").ToString
        txt_invoice_no.Text = Trim(ds.Tables(0).Rows(0)("INVOICE_NO").ToString)
        dat_invoice_date.Value = Date.Parse(ds.Tables(0).Rows(0)("INVOICE_DT").ToString)

        ' Set detail grid
        If compFlg = 0 Then
            detailDs = ws.GetShipmentReqDetailByCd(txt_shipment_req_no.Text, loginCode)
        Else
            detailDs = ws.GetShipmentActDetailByCd(txt_shipment_req_no.Text, loginCode)
        End If

        If Not IsNothing(detailDs) AndAlso detailDs.Tables(0).Rows.Count > 0 Then
            dt = detailDs.Tables(0)
            dt.TableName = "detailDt"
            FillDataToGrid()
        End If

        If compFlg = 0 Then
            SetEnableState(True)
        Else
            SetEnableAllInput(False)

            If Not isViewDetailOnly Then

                btn_export.Enabled = True
                btn_cancel.Enabled = True

                Dim msgScreen As New frm_MSG001("This shipment is completed!", "ERR082")
                msgScreen.ShowDialog()
            End If
        End If

    End Sub

    Private Sub SetEnableAllInput(Optional ByVal enableValue As Boolean = True)
        rdo_add.Enabled = enableValue
        rdo_chg.Enabled = enableValue
        rdo_del.Enabled = enableValue

        txt_shipment_req_no.Enabled = enableValue
        btn_shipment_req_no.Enabled = enableValue

        dat_shipment_req_date.Enabled = enableValue

        dat_shipment_date.Enabled = enableValue

        txt_customer_cd.Enabled = enableValue
        btn_customer_cd.Enabled = enableValue

        txt_po_no.Enabled = enableValue
        txt_invoice_no.Enabled = enableValue

        dat_invoice_date.Enabled = enableValue

        'grd_ship_list.ReadOnly = Not enableValue
        'For Each col As DataGridViewColumn In grd_ship_list.Columns
        '    If col Is col_chk Then
        '        Continue For
        '    End If
        '    col.ReadOnly = True
        'Next
        col_chk.ReadOnly = Not enableValue

        btn_select_all.Enabled = enableValue
        btn_unselect_all.Enabled = enableValue

        btn_add.Enabled = enableValue
        btn_delete.Enabled = enableValue
        btn_execute.Enabled = enableValue
        btn_export.Enabled = enableValue
        btn_shipment.Enabled = enableValue
        btn_cancel.Enabled = enableValue
    End Sub

    ''' <summary>
    ''' Method: Clear display control [Clear]
    ''' </summary>
    ''' <param name="uncheckRadio"></param>
    ''' <remarks></remarks>
    Private Sub ClearAllInput(Optional ByVal uncheckRadio As Boolean = False)
        If Display = 2 Then
            btn_add.Enabled = False
            btn_delete.Enabled = False
            btn_select_all.Enabled = False
            btn_unselect_all.Enabled = False
            btn_execute.Enabled = False
            btn_export.Enabled = False
            btn_shipment.Enabled = False
            btn_customer_cd.Enabled = False
            If Me.Mode <> 1 Then
                btn_shipment_req_no.Enabled = True
                txt_shipment_req_no.Enabled = True
                txt_shipment_req_no.Focus()
                txt_shipment_req_no.SelectAll()
                Display = 1
            End If
            If Mode = 1 Then
                Display = 0
                rdo_add.Enabled = True
                rdo_chg.Enabled = True
                rdo_del.Enabled = True
                rdo_add.Checked = False
                rdo_chg.Checked = False
                rdo_del.Checked = False
            End If
            txt_invoice_no.Text = Nothing
            txt_invoice_no.Enabled = False
            ABCDCommon.InitDateTimePicker(dat_invoice_date)
            dat_invoice_date.Enabled = False
            txt_po_no.Text = Nothing
            txt_po_no.Enabled = False
            txt_customer_cd.Text = Nothing
            txt_customer_name.Text = Nothing
            txt_customer_cd.Enabled = False
            ABCDCommon.InitDateTimePicker(dat_shipment_date)
            dat_shipment_date.Enabled = False
            ABCDCommon.InitDateTimePicker(dat_shipment_req_date)
            dat_shipment_req_date.Enabled = False
            lbl_shipment_status.Text = "Shipment Status:-"
            dt.Rows.Clear()
            grd_ship_list.DataSource = Nothing
            barcode = String.Empty '// Cuongtk [20150820]
            Return
        End If

        If Display = 1 Then
            If Mode <> 1 Then
                txt_shipment_req_no.Text = Nothing
                txt_shipment_req_no.Enabled = False
                rdo_add.Enabled = True
                rdo_chg.Enabled = True
                rdo_del.Enabled = True
                rdo_add.Checked = False
                rdo_chg.Checked = False
                rdo_del.Checked = False
                btn_add.Enabled = False
                btn_delete.Enabled = False
                btn_select_all.Enabled = False
                btn_unselect_all.Enabled = False
                btn_execute.Enabled = False
                btn_export.Enabled = False
                btn_shipment.Enabled = False
                btn_customer_cd.Enabled = False
                btn_shipment_req_no.Enabled = False
                txt_invoice_no.Text = Nothing
                txt_invoice_no.Enabled = False
                ABCDCommon.InitDateTimePicker(dat_invoice_date)
                dat_invoice_date.Enabled = False
                txt_po_no.Text = Nothing
                txt_po_no.Enabled = False
                txt_customer_cd.Text = Nothing
                txt_customer_cd.Enabled = False
                ABCDCommon.InitDateTimePicker(dat_shipment_date)
                dat_shipment_date.Enabled = False
                ABCDCommon.InitDateTimePicker(dat_shipment_req_date)
                dat_shipment_req_date.Enabled = False
                lbl_shipment_status.Text = "Shipment Status:-"
                dt.Rows.Clear()
                grd_ship_list.DataSource = Nothing
                barcode = String.Empty '// Cuongtk [20150820]
                Display = 0
                Return
            End If
        End If
    End Sub

    Private Sub FillDataToGrid(Optional ByVal addTb As DataTable = Nothing)
        If addTb Is Nothing Then
            ' case create new datasource
            grd_ship_list.DataSource = Nothing
            grd_ship_list.DataSource = dt
        Else
            Dim gridRow As DataRow = Nothing

            For Each row As DataRow In addTb.Rows
                If Not IsExistShipmentInDataTable(dt, row(col_pallet_no.DataPropertyName), _
                                              row(col_barcode_no.DataPropertyName)) Then
                    gridRow = dt.NewRow()
                    gridRow.ItemArray = CType(row.ItemArray.Clone(), Object())
                    dt.Rows.Add(gridRow)
                End If
            Next
            grd_ship_list.DataSource = dt
            grd_ship_list.Update()
        End If
        grd_ship_list.ClearSelection()
        'Kaidai 183: Set color for row is red. Condition Scan "0".
        For i As Integer = 0 To grd_ship_list.Rows.Count - 1 Step 1
            'grd_ship_list.Rows(i).DefaultCellStyle.BackColor = Color.Red
            If Integer.Parse(grd_ship_list.Rows(i).Cells(9).Value).Equals(0) = True Then
                grd_ship_list.Rows(i).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Function IsExistShipmentInDataTable(ByVal dt As DataTable, ByVal palletNo As String, ByVal barcode As String) As Boolean
        Dim isExist As Boolean = False

        For Each row As DataRow In dt.Rows
            If barcode = row(col_barcode_no.DataPropertyName) Then
                isExist = True
                Exit For
            End If
        Next

        Return isExist
    End Function

    Public Sub AddToGrid(ByVal listToAdd As List(Of Dictionary(Of String, Object)), _
                         ByVal palletNo As String, _
                         ByVal itemCd As String, _
                         ByVal itemNm As String)

        Dim addTb As New DataTable

        For Each col As DataColumn In dt.Columns
            addTb.Columns.Add(col.ColumnName)
        Next

        For Each dict As Dictionary(Of String, Object) In listToAdd
            Dim row As DataRow = addTb.NewRow
            row(col_pallet_no.DataPropertyName) = palletNo
            row(col_barcode_no.DataPropertyName) = dict(col_barcode_no.DataPropertyName)
            row(col_lot_no.DataPropertyName) = dict(col_lot_no.DataPropertyName)
            row(col_rack_no.DataPropertyName) = dict(col_rack_no.DataPropertyName) 'Kaidai 182: Add "RACK NO" in Gridview.
            row(col_wh_cd.DataPropertyName) = dict(col_wh_cd.DataPropertyName)
            row(col_item_cd.DataPropertyName) = itemCd
            row(col_item_name.DataPropertyName) = itemNm
            row(col_quantity.DataPropertyName) = Integer.Parse(dict(col_quantity.DataPropertyName).ToString(), _
                                                               Globalization.NumberStyles.AllowThousands)
            row(col_scan.DataPropertyName) = 0

            addTb.Rows.Add(row)
        Next

        FillDataToGrid(addTb)
    End Sub

    Public Function IsValidInput() As Boolean

        If Mode = ABCDConst.ModeUpd AndAlso txt_shipment_req_no.Enabled = True Then
            If String.IsNullOrEmpty(Trim(txt_shipment_req_no.Text)) Then
                Dim scrError As New frm_MSG001("Please input Shipment Req No!", "ERR SHS001")
                If scrError.ShowDialog() = DialogResult.OK Then
                    txt_shipment_req_no.Focus()
                End If
                Return False
            End If
        End If

        If dat_shipment_req_date.CustomFormat = " " Then
            Dim scrError As New frm_MSG001("Please select Shipment Req Date!", "ERR SHS001")
            If scrError.ShowDialog() = DialogResult.OK Then
                dat_shipment_req_date.Focus()
            End If
            Return False
        End If

        If dat_shipment_date.CustomFormat = " " Then
            Dim scrError As New frm_MSG001("Please select Shipment Date!", "ERR SHS001")
            If scrError.ShowDialog() = DialogResult.OK Then
                dat_shipment_date.Focus()
            End If
            Return False
        End If

        If String.IsNullOrEmpty(Trim(txt_customer_cd.Text)) Then
            Dim scrError As New frm_MSG001("Please input Customer!", "ERR SHS001")
            If scrError.ShowDialog() = DialogResult.OK Then
                txt_customer_cd.Focus()
            End If
            Return False
        End If

        If String.IsNullOrEmpty(Trim(txt_invoice_no.Text)) Then
            Dim scrError As New frm_MSG001("Please input Invoice No!", "ERR SHS001")
            If scrError.ShowDialog() = DialogResult.OK Then
                txt_invoice_no.Focus()
            End If
            Return False
        End If

        If dat_invoice_date.CustomFormat = " " Then
            Dim scrError As New frm_MSG001("Please select Invoice Date!", "ERR SHS001")
            If scrError.ShowDialog() = DialogResult.OK Then
                dat_invoice_date.Focus()
            End If
            Return False
        End If

        Dim cusInfo = ws.GetCustomerInfoByID(txt_customer_cd.Text, loginCode)
        If IsNothing(cusInfo) OrElse cusInfo.Tables(0).Rows.Count = 0 Then
            Dim scrError As New frm_MSG001("Customer code does not exist!", "ERR021")
            If scrError.ShowDialog() = DialogResult.OK Then
                txt_customer_cd.Focus()
            End If
            Return False
        End If

        Return True
    End Function

    Private Function GetExportData() As DataTable


        Dim resultDt As New DataTable
        Dim masterInfoDt As DataTable = _
                    ws.GetShipmentInfoByShipmentReqNo(txt_shipment_req_no.Text, loginCode).Tables(0)
        Dim detailDt As DataTable = Nothing

        Dim compFlg As Integer = masterInfoDt.Rows(0)("COMP_FLG")
        If compFlg = 0 Then
            detailDt = ws.GetShipmentReqDetailByCd(txt_shipment_req_no.Text, loginCode).Tables(0)
        Else
            detailDt = ws.GetShipmentActDetailByCd(txt_shipment_req_no.Text, loginCode).Tables(0)
        End If

        If detailDt.Rows.Count = 0 Then
            Return resultDt
        End If

        Dim shipReqNo = Trim(txt_shipment_req_no.Text)
        Dim shipReqDate As Date = masterInfoDt.Rows(0)("SHIP_REQ_DT")
        Dim shipDate As Date = masterInfoDt.Rows(0)("SHIP_DT")
        Dim cusId As String = masterInfoDt.Rows(0)("CUS_ID")
        Dim cusNm As String = ws.GetCustomerInfoByID(cusId, loginCode).Tables(0).Rows(0)("CUS_NM")
        Dim cusPo As String = masterInfoDt.Rows(0)("CUS_PO")
        Dim invoiceNo As String = Trim(masterInfoDt.Rows(0)("INVOICE_NO"))
        Dim invoiceDate As Date = masterInfoDt.Rows(0)("INVOICE_DT")

        resultDt.Columns.Add("Shipment Request No")
        resultDt.Columns.Add("Shipment Request Date")
        resultDt.Columns.Add("Shipment Date")
        resultDt.Columns.Add("Customer Id")
        resultDt.Columns.Add("Customer Name")
        resultDt.Columns.Add("Customer PO")
        resultDt.Columns.Add("Invoice No")
        resultDt.Columns.Add("Invoice Date")
        resultDt.Columns.Add("Complete Flag")
        resultDt.Columns.Add("Pallet No")
        resultDt.Columns.Add("Pallet Code")
        resultDt.Columns.Add("Barcode No")
        resultDt.Columns.Add("Lot No")
        resultDt.Columns.Add("Warehouse Code")
        resultDt.Columns.Add("Item Code")
        resultDt.Columns.Add("Item Name")
        resultDt.Columns.Add("Quantity")
        resultDt.Columns.Add("Scan Flag")
        resultDt.Columns.Add("Rack No")

        For i As Integer = 0 To detailDt.Rows.Count - 1 Step 1
            '// Fix error rack code is null.
            Dim rackCode As String = String.Empty
            If Not IsDBNull(detailDt.Rows(i)("RACK_CD")) Then '// Rack code not null.
                rackCode = Trim(detailDt.Rows(i)("RACK_CD")) '// Set value for rackCode.
            End If

            Dim arr As String() = New String() {shipReqNo, _
                                                shipReqDate.ToString(ABCDConst.Format_Date_01), _
                                                shipDate.ToString(ABCDConst.Format_Date_01), _
                                                cusId, _
                                                cusNm, _
                                                cusPo, _
                                                invoiceNo, _
                                                invoiceDate.ToString(ABCDConst.Format_Date_01), _
                                                compFlg, _
                                                Trim(detailDt.Rows(i)("PALLET_NO")), _
                                                String.Empty, _
                                                Trim(detailDt.Rows(i)("BC_NO")), _
                                                Trim(detailDt.Rows(i)("LOT_NO")), _
                                                Trim(detailDt.Rows(i)("WH_CD")), _
                                                Trim(detailDt.Rows(i)("ITEM_CD")), _
                                                detailDt.Rows(i)("ITEM_NM"), _
                                                detailDt.Rows(i)("QTY"), _
                                                detailDt.Rows(i)("SCAN_FLG"), _
                                                rackCode}
            resultDt.Rows.Add(arr)
        Next
        Return resultDt
    End Function

    Private Function ExecuteUpdate() As Integer
        '// Get data to update.
        Dim listData As New List(Of String)

        Dim shipmentRequestNo As String = Trim(txt_shipment_req_no.Text)
        Dim shipmentRequestDate As Date = dat_shipment_req_date.Value
        Dim shipmentDate As Date = dat_shipment_date.Value
        Dim customerId As String = Trim(txt_customer_cd.Text)
        Dim customerPo As String = Trim(txt_po_no.Text)
        Dim invoiceNo As String = Trim(txt_invoice_no.Text)
        Dim invoiceDate As Date = dat_invoice_date.Value

        For i As Integer = 0 To grd_ship_list.RowCount - 1 Step 1
            Dim stringData As String = String.Empty
            Dim barcodeNo As String = Trim(grd_ship_list.Rows(i).Cells(2).Value)
            Dim palletNo As String = Trim(grd_ship_list.Rows(i).Cells(1).Value)
            Dim scanFlag As Integer = grd_ship_list.Rows(i).Cells(9).Value
            Dim registeredId As String = ABCDCommon.UserId
            Dim registeredDate As Date = DateTime.Now
            stringData = shipmentRequestNo & "," & barcodeNo & "," & palletNo & "," & scanFlag & "," & registeredId & "," & registeredDate
            listData.Add(stringData)
        Next

        '// Execute update.
        Try
            Dim updateNo As Integer = ws.UpdateShipReqInfoTrWithDetail(shipmentRequestNo, shipmentRequestDate, shipmentDate, customerId, customerPo, invoiceNo, invoiceDate, listData.ToArray, ABCDCommon.UserId)
            Return updateNo
        Catch ex As Exception
            Dim formError As New frm_MSG001(ex.ToString, "ERR9004")
            formError.ShowDialog()
        End Try
    End Function

    Private Sub InitData()

        ' Set current date
        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = Integer.Parse(ABCDConst.STRING_TIMEOUT)
        lb_today.Text = ABCDCommon.GetSystemDateWithFormat()

        ' Init gridview
        col_pallet_no.DataPropertyName = "PALLET_NO"
        col_barcode_no.DataPropertyName = "BC_NO"
        col_lot_no.DataPropertyName = "LOT_NO"
        col_rack_no.DataPropertyName = "RACK_CD" 'Kaidai 182: Add "RACK NO" in Gridview.
        col_wh_cd.DataPropertyName = "WH_CD"
        col_item_cd.DataPropertyName = "ITEM_CD"
        col_item_cd.Width = 210
        col_item_name.DataPropertyName = "ITEM_NM"
        col_item_name.Width = 420
        col_quantity.DataPropertyName = "QTY"
        col_scan.DataPropertyName = "SCAN_FLG"

        grd_ship_list.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grd_ship_list.AutoGenerateColumns = False

        dt.Columns.Add("CHK")
        dt.Columns.Add(col_pallet_no.DataPropertyName)
        dt.Columns.Add(col_barcode_no.DataPropertyName)
        dt.Columns.Add(col_lot_no.DataPropertyName)
        dt.Columns.Add(col_rack_no.DataPropertyName) 'Kaidai 182: Add "RACK NO" in Gridview.
        dt.Columns.Add(col_wh_cd.DataPropertyName)
        dt.Columns.Add(col_item_cd.DataPropertyName)
        dt.Columns.Add(col_item_name.DataPropertyName)
        dt.Columns.Add(col_quantity.DataPropertyName)
        dt.Columns.Add(col_scan.DataPropertyName)

        ' Set enable/disable for form's control
        SetEnableState()
    End Sub

    Private Sub ExportExcel(ByVal dt As DataTable, ByVal fileName As String, ByVal sheetName As String)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add(misValue)
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Sheets(1)
        Dim cell As Microsoft.Office.Interop.Excel.Range = Nothing
        Dim b As New BarcodeLib.Barcode()
        Dim codeImg As Image = Nothing

        Try
            Dim codeWidth As Integer = 100
            Dim codeHeight As Integer = 22
            Dim g As Graphics = Me.CreateGraphics()
            Dim excelWidth As Double = (codeWidth + 8) / 7
            g.Dispose()

            xlWorkSheet.Rows.NumberFormat = "@"
            xlWorkSheet.Rows.RowHeight = codeHeight

            '' Column header for excel
            Dim index As Integer = 0
            For Each col As DataColumn In dt.Columns
                cell = xlWorkSheet.Cells(1, index + 1)
                cell.Value = col.ColumnName.ToString
                cell.Font.Bold = True
                index += 1
            Next

            Dim palletNo As String = String.Empty

            '' Loop data 
            For i = 1 To dt.Rows.Count
                xlWorkSheet.Cells(i + 1, 1) = dt.Rows(i - 1)(0)
                For j = 1 To dt.Columns.Count - 1
                    cell = xlWorkSheet.Cells(i + 1, j + 1)
                    If j = 10 Then
                        cell.ColumnWidth = codeWidth / 5
                        cell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

                        palletNo = dt.Rows(i - 1)(9)
                        codeImg = b.Encode(BarcodeLib.TYPE.CODE128, palletNo, codeWidth, codeHeight)
                        System.Windows.Forms.Clipboard.SetDataObject(codeImg, True)

                        xlWorkSheet.Paste(cell)
                    Else
                        cell.Value = dt.Rows(i - 1)(j)
                    End If
                Next
            Next

            xlWorkSheet.Columns.AutoFit()

            CType(xlWorkSheet.Cells(1, 11), Microsoft.Office.Interop.Excel.Range).ColumnWidth = excelWidth

            '// Save file.
            xlWorkSheet.SaveAs(fileName)

            Dim msg001 As New frm_MSG001(Messages.MSG002, "MSG002")
            If msg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(fileName)
            End If

        Catch ex As Exception
            Dim frmMsg001 As New frm_MSG001(ex.Message, "ERRSYS")
            frmMsg001.ShowDialog()
        Finally
            b.Dispose()
            codeImg.Dispose()
            '// Close work book file excel after save.
            xlWorkBook.Close()
            '// Quit application.
            xlApp.Quit()
            '// Release object.
            ABCDCommon.ReleaseObject(xlWorkSheet)
            ABCDCommon.ReleaseObject(xlWorkBook)
            ABCDCommon.ReleaseObject(xlApp)

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    '<< LanNT - 0011
    Private Sub CustomExportDataTableToExcel(ByVal dataTable As DataTable, ByVal fileName As String)

        Dim filePath As String = Configuration.ConfigurationManager.AppSettings("TemplateExcelShort")
        Dim culInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim excelApplication As New Microsoft.Office.Interop.Excel.Application()
        Dim excelWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim excelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim frm As frm_MSG001

        Dim palletNo As String = ""
        Dim indexAddValue As Integer = 15
        Dim countPalletNo As Integer = 0
        Dim sumQuantity As Integer = 0
        Dim codeImage As Image = Nothing
        Dim libBarcode As New BarcodeLib.Barcode
        Dim isShapeLogo As Boolean = False

        Dim startRow(5) As String
        Dim curRow(5) As String
        Dim allowPrint As Boolean = False

        Try
            excelApplication.Workbooks.Open(filePath)
            excelWorkBook = excelApplication.ActiveWorkbook
            excelWorkSheet = excelApplication.Sheets(1)

            '// Setting value for cell on workbook.
            excelWorkSheet.Range("B8").Value = "'" & Trim(txt_shipment_req_no.Text)
            excelWorkSheet.Range("B9").Value = "'" & lbl_shipment_status.Text.Substring(17)
            excelWorkSheet.Range("D8").Value = "'" & Trim(txt_customer_cd.Text) & "-" & txt_customer_name.Text
            excelWorkSheet.Range("D9").Value = "'" & dat_shipment_date.Value.ToString("dd.MM.yyyy")
            excelWorkSheet.Range("D10").Value = "'" & txt_invoice_no.Text
            excelWorkSheet.Range("D11").Value = "'" & dat_invoice_date.Value.ToString("dd.MM.yyyy")

            'Process group by Itemcode, palletnum, qtyperbox, racknum here'
            For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1

                curRow(0) = Trim(dataTable.Rows(i)(14).ToString) 'Item Code'
                curRow(1) = Trim(dataTable.Rows(i)(11).ToString).Substring(10) 'Box Num'
                curRow(2) = Trim(dataTable.Rows(i)(18).ToString) 'Rack Code'
                curRow(3) = Trim(dataTable.Rows(i)(16).ToString) 'Qty per Box'
                curRow(4) = Trim(dataTable.Rows(i)(9).ToString) 'Pallet Num'
                sumQuantity += Integer.Parse(curRow(3))

                If i = 0 Then
                    'remember starting position for begining pallet block'
                    startRow(0) = curRow(0)
                    startRow(1) = curRow(1)
                    startRow(2) = curRow(2)
                    startRow(3) = curRow(3)
                    startRow(4) = curRow(4)
                    Continue For
                End If

                If i = dataTable.Rows.Count - 1 Then
                    allowPrint = True
                    i += 1
                Else
                    For j As Integer = 0 To 4 Step 1
                        If j = 1 Then
                            If Integer.Parse(curRow(1)) - Integer.Parse(Trim(dataTable.Rows(i - 1)(11).ToString).Substring(10)) > 1 Then
                                allowPrint = True
                                Exit For
                            End If
                        End If
                        If j <> 1 And Not curRow(j).Equals(startRow(j)) Then
                            allowPrint = True
                            Exit For
                        End If
                    Next
                End If

                'Print Box line'
                If allowPrint Then
                    excelWorkSheet.Range("A" & (indexAddValue + 1).ToString).Value = "'" & startRow(0)
                    If Integer.Parse(Trim(dataTable.Rows(i - 1)(11).ToString).Substring(10)) = Integer.Parse(startRow(1)) Then
                        excelWorkSheet.Range("B" & (indexAddValue + 1).ToString).Value = "'" & startRow(1)
                    Else
                        excelWorkSheet.Range("B" & (indexAddValue + 1).ToString).Value = "'" & startRow(1) & "~" & Trim(dataTable.Rows(i - 1)(11).ToString).Substring(10)
                    End If

                    excelWorkSheet.Range("C" & (indexAddValue + 1).ToString).Value = "'" & startRow(2)
                    excelWorkSheet.Range("D" & (indexAddValue + 1).ToString).Value = Integer.Parse(startRow(3))

                    startRow(0) = curRow(0)
                    startRow(1) = curRow(1)
                    startRow(2) = curRow(2)
                    startRow(3) = curRow(3)
                    startRow(4) = curRow(4)
                    indexAddValue += 1
                    allowPrint = False

                    'Print Pallet No header to begin new Pallet block'
                    If Not palletNo.Equals(curRow(4).ToString) Then
                        'Generate break space between 2 Pallet block (begin from end of 1st pallet block)'
                        countPalletNo += 1
                        If indexAddValue Mod 2 <> 0 Then
                            indexAddValue += 2
                        Else
                            indexAddValue += 3
                        End If

                        If countPalletNo = 1 Then
                            indexAddValue = 16
                        End If

                        codeImage = libBarcode.Encode(BarcodeLib.TYPE.CODE128, curRow(4), 110, 10)
                        Clipboard.SetDataObject(codeImage)
                        excelWorkSheet.Range("A" & If(countPalletNo = 1, "15", indexAddValue.ToString)).Select()
                        excelWorkSheet.Paste()
                        excelWorkSheet.Range("B" & If(countPalletNo = 1, "15", indexAddValue.ToString)).Value = "'" & Trim(curRow(4))
                        palletNo = curRow(4)
                    End If
                End If

            Next

            If indexAddValue Mod 2 <> 0 Then
                indexAddValue += 3
            Else
                indexAddValue += 2
            End If
            excelWorkSheet.Range("A" & indexAddValue.ToString & ":D" & indexAddValue.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            CleanLineExcel(excelWorkSheet, indexAddValue + 1, 1000)
            'excelWorkSheet.Range("A" & (indexAddValue + 1).ToString & ":B" & (indexAddValue + 1).ToString).Merge()
            'excelWorkSheet.Range("C" & (indexAddValue + 1).ToString & ":D" & (indexAddValue + 1).ToString).Merge()
            'excelWorkSheet.Range("F" & (indexAddValue + 1).ToString & ":D" & (indexAddValue + 1).ToString).Merge()
            excelWorkSheet.Range("A" & (indexAddValue + 1).ToString).Value = "Tổng số pallet"
            excelWorkSheet.Range("B" & (indexAddValue + 1).ToString).Value = countPalletNo.ToString & " PL"
            excelWorkSheet.Range("C" & (indexAddValue + 1).ToString).Value = "Tổng số lượng"
            excelWorkSheet.Range("D" & (indexAddValue + 1).ToString).Value = sumQuantity.ToString("#,##0")
            excelWorkSheet.Range("A" & (indexAddValue + 1).ToString & ":D" & (indexAddValue + 1).ToString).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

            '// Position logo company.
            For Each shapes As Microsoft.Office.Interop.Excel.Shape In excelWorkSheet.Shapes
                If isShapeLogo = False Then
                    isShapeLogo = True
                    Continue For
                Else
                    shapes.Top += 4
                    shapes.Left += 43
                End If
            Next

            '// excelApplication.DisplayAlerts = False
            excelWorkBook.SaveAs(fileName)
            excelWorkBook.Close()
            excelWorkBook = Nothing
            frm = New frm_MSG001("Do you want to open file ?", "MSG001")
            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(fileName)
            End If
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            Return
        End Try
    End Sub
    ' 0011 >>

    Private Sub ExportDataTableToExcel(ByVal dataTable As DataTable, ByVal fileName As String)
        Dim filePath As String = Configuration.ConfigurationManager.AppSettings("TemplateExcel")
        Dim culInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim excelApplication As New Microsoft.Office.Interop.Excel.Application()
        Dim excelWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim excelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim frm As frm_MSG001
        Dim palletNo As String = ""
        Dim indexAddValue As Integer = 14
        Dim sequenceNumber As Integer = 1
        Dim countPalletNo As Integer = 1
        Dim sumQuantity As Integer = 0
        Dim codeImage As Image = Nothing
        Dim libBarcode As New BarcodeLib.Barcode
        Dim isShapeLogo As Boolean = False
        Try
            excelApplication.Workbooks.Open(filePath)
            excelWorkBook = excelApplication.ActiveWorkbook
            excelWorkSheet = excelApplication.Sheets(1)

            '// Setting value for cell on workbook.
            '// excelWorkSheet.Range("C5").Value = "'" & Trim(txt_shipment_req_no.Text)
            '// excelWorkSheet.Range("C6").Value = "'" & lbl_shipment_status.Text.Substring(17)
            '// excelWorkSheet.Range("F5").Value = "'" & Trim(txt_customer_cd.Text) & "-" & txt_customer_name.Text
            '// excelWorkSheet.Range("F6").Value = "'" & txt_po_no.Text
            '// excelWorkSheet.Range("F7").Value = "'" & dat_shipment_date.Value.ToString("dd.MM.yyyy")
            '// excelWorkSheet.Range("F8").Value = "'" & txt_invoice_no.Text
            '// excelWorkSheet.Range("F9").Value = "'" & dat_invoice_date.Value.ToString("dd.MM.yyyy")
            excelWorkSheet.Range("C7").Value = "'" & Trim(txt_shipment_req_no.Text)
            excelWorkSheet.Range("C8").Value = "'" & lbl_shipment_status.Text.Substring(17)
            excelWorkSheet.Range("F7").Value = "'" & Trim(txt_customer_cd.Text) & "-" & txt_customer_name.Text
            excelWorkSheet.Range("F8").Value = "'" & dat_shipment_date.Value.ToString("dd.MM.yyyy")
            excelWorkSheet.Range("F9").Value = "'" & txt_invoice_no.Text
            excelWorkSheet.Range("F10").Value = "'" & dat_invoice_date.Value.ToString("dd.MM.yyyy")
            ''
            For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
                If i <> 0 Then
                    If Not palletNo.Equals(Trim(dataTable.Rows(i)(9).ToString)) Then
                        countPalletNo = countPalletNo + 1
                        If indexAddValue Mod 2 <> 0 Then
                            indexAddValue = indexAddValue + 2
                        Else
                            indexAddValue = indexAddValue + 3
                        End If
                        sequenceNumber = 1
                    End If
                End If
                excelWorkSheet.Range("A" & (indexAddValue + 1).ToString).Value = sequenceNumber.ToString
                If Not palletNo.Equals(Trim(dataTable.Rows(i)(9).ToString)) Then
                    codeImage = libBarcode.Encode(BarcodeLib.TYPE.CODE128, dataTable.Rows(i)(9).ToString, 110, 10)
                    Clipboard.SetDataObject(codeImage)
                    excelWorkSheet.Range("B" & indexAddValue.ToString).Select()
                    excelWorkSheet.Paste()
                    excelWorkSheet.Range("C" & indexAddValue.ToString).Value = "'" & Trim(dataTable.Rows(i)(9).ToString)
                End If
                excelWorkSheet.Range("B" & (indexAddValue + 1).ToString).Value = "'" & Trim(dataTable.Rows(i)(14).ToString)
                excelWorkSheet.Range("C" & (indexAddValue + 1).ToString).Value = "'" & Trim(dataTable.Rows(i)(11).ToString).Substring(10)
                excelWorkSheet.Range("D" & (indexAddValue + 1).ToString).Value = "'" & Trim(dataTable.Rows(i)(11).ToString)
                excelWorkSheet.Range("E" & (indexAddValue + 1).ToString).Value = Integer.Parse(Trim(dataTable.Rows(i)(16).ToString))
                sumQuantity = sumQuantity + Integer.Parse(Trim(dataTable.Rows(i)(16).ToString))
                excelWorkSheet.Range("F" & (indexAddValue + 1).ToString).Value = "'" & Trim(dataTable.Rows(i)(12).ToString)
                palletNo = Trim(dataTable.Rows(i)(9).ToString)
                excelWorkSheet.Range("G" & (indexAddValue + 1).ToString).Value = "'" & Trim(dataTable.Rows(i)(18).ToString)
                sequenceNumber = sequenceNumber + 1
                indexAddValue = indexAddValue + 1
            Next
            If indexAddValue Mod 2 <> 0 Then
                indexAddValue = indexAddValue + 3
            Else
                indexAddValue = indexAddValue + 2
            End If
            excelWorkSheet.Range("A" & indexAddValue.ToString & ":G" & indexAddValue.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            CleanLineExcel(excelWorkSheet, indexAddValue + 1, 1000)
            excelWorkSheet.Range("A" & (indexAddValue + 1).ToString & ":B" & (indexAddValue + 1).ToString).Merge()
            excelWorkSheet.Range("C" & (indexAddValue + 1).ToString & ":D" & (indexAddValue + 1).ToString).Merge()
            excelWorkSheet.Range("F" & (indexAddValue + 1).ToString & ":G" & (indexAddValue + 1).ToString).Merge()
            '// excelWorkSheet.Range("A" & (indexAddValue + 1).ToString).Value = "Sum of Pallet No"
            excelWorkSheet.Range("A" & (indexAddValue + 1).ToString).Value = "Tổng số pallet"
            excelWorkSheet.Range("C" & (indexAddValue + 1).ToString).Value = countPalletNo.ToString & " PL"
            '// excelWorkSheet.Range("E" & (indexAddValue + 1).ToString).Value = "Sum of Quantity"
            excelWorkSheet.Range("E" & (indexAddValue + 1).ToString).Value = "Tổng số lượng"
            excelWorkSheet.Range("F" & (indexAddValue + 1).ToString).Value = sumQuantity.ToString("#,##0")
            excelWorkSheet.Range("A" & (indexAddValue + 1).ToString & ":G" & (indexAddValue + 1).ToString).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            '// excelWorkSheet.Range("B" & (indexAddValue + 2).ToString).Value = "Requested Person"
            '// excelWorkSheet.Range("D" & (indexAddValue + 2).ToString).Value = "Exported Person"
            '// excelWorkSheet.Range("F" & (indexAddValue + 2).ToString).Value = "Approved Person"

            '// Position logo company.
            For Each shapes As Microsoft.Office.Interop.Excel.Shape In excelWorkSheet.Shapes
                If isShapeLogo = False Then
                    isShapeLogo = True
                    Continue For
                Else
                    shapes.Top = shapes.Top + 4
                    shapes.Left = shapes.Left + 43
                End If
            Next

            '// excelApplication.DisplayAlerts = False
            excelWorkBook.SaveAs(fileName)
            excelWorkBook.Close()
            excelWorkBook = Nothing
            frm = New frm_MSG001("Do you want to open file ?", "MSG001")
            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(fileName)
            End If
        Catch ex As Exception
            frm = New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            Return
        End Try
    End Sub

    Private Sub CleanLineExcel(ByVal excelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet, _
                               ByVal startRow As Integer, _
                               ByVal endRow As Integer)
        For i As Integer = startRow To endRow Step 1
            excelWorkSheet.Range("A" & i.ToString & ":G" & i.ToString).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
        Next
    End Sub

#End Region

    ''' <summary>
    ''' Event mouse click Header gridview to Sort
    ''' Cuongtk - 20150818
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grd_ship_list_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_ship_list.ColumnHeaderMouseClick
        '// Loop all data on gridview
        For i As Integer = 0 To grd_ship_list.RowCount - 1 Step 1
            '// Check row data is scan or not scan
            If Integer.Parse(grd_ship_list.Rows(i).Cells(9).Value).Equals(0) = True Then
                grd_ship_list.Rows(i).DefaultCellStyle.BackColor = Color.Red '// Set row color is red
            End If
        Next
    End Sub
    '<< LanNT - 0011
    Private Sub btn_custom_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_custom_export.Click
        Dim msgScreen As frm_MSG001 = Nothing
        If Not shipInquiryCallFromFlag Then
            If SHIPMENT_STATUS_IN_COMP.Equals(lbl_shipment_status.Text) Then
                msgScreen = New frm_MSG001("Your data will be saved first, Do you want to continue?", "MSGSYS")
                If Not msgScreen.ShowDialog() = DialogResult.Yes Then
                    Exit Sub
                End If

                ExecuteUpdate()
            End If
        End If
        'AIT Hungtg end 05/08/2015
        Dim exportData As DataTable = GetExportData()

        msgScreen = New frm_MSG001("No item to export!", "ERRSYS")
        If exportData Is Nothing OrElse exportData.Rows.Count = 0 Then
            msgScreen.ShowDialog()
            Return
        End If

        sfDialog.Filter = "Excel Files (*.xlsx*) | *.xlsx"
        sfDialog.FileName = "SHS001_" & DateTime.Now.ToString(ABCDConst.Format_Date_03 & "HHmmss")
        If sfDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim filePath As String = sfDialog.FileName
            CustomExportDataTableToExcel(dataTable:=exportData, fileName:=sfDialog.FileName)
        End If
    End Sub
    ' 0011 >>
End Class