''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：ABCDCommon.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   14-DEC-14    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources
Imports ABCD.ABCDConst
Imports System.Text
Imports System.IO
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports Excel = Microsoft.Office.Interop.Excel

Public Class ABCDCommon

#Region "Variable/Constant Class"

    ''' <summary>
    ''' Properties user id use to get user login.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _userId As String
    Public Shared Property UserId() As String
        Get
            Return _userId
        End Get
        Set(ByVal value As String)
            _userId = value
        End Set
    End Property

    ''' <summary>
    ''' Properties user name to get name of login user.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _userNm As String
    Public Shared Property UserName() As String
        Get
            Return _userNm
        End Get
        Set(ByVal value As String)
            _userNm = value
        End Set
    End Property

    ''' <summary>
    ''' Properties password use to get password login.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _password As String
    Public Shared Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    ''' <summary>
    ''' Properties authority use to get authority login.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _authority As String
    Public Shared Property Auhtority() As String
        Get
            Return _authority
        End Get
        Set(ByVal value As String)
            _authority = value
        End Set
    End Property

    ''' <summary>
    ''' Properties set company code for ABCD.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared _comCode As String = ""
    Public Shared Property ComCode() As String
        Get
            Return _comCode
        End Get
        Set(ByVal value As String)
            _comCode = value
        End Set
    End Property

    Public Shadows Const MODE_LOGIN As Integer = 4
    Public Shadows Const MODE_AUTHORITY As String = "Authority"
    Public Shadows Const MODE_DESTINATION As String = "Destination"
    Public Shadows Const MODE_WAREHOUSE_STATUS_TR As String = "MODE_WAREHOUSE_STATUS_TR"

    Protected Shared webServiceURL As String = String.Empty

#End Region

#Region "New Class"

#End Region

#Region "Event Class"

    Public Shared Sub txt_number_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objTxt As TextBox = sender
        Dim numValue As Integer = -1
        If Not Integer.TryParse(objTxt.Text, numValue) Then
            objTxt.Text = String.Empty
        Else
            If numValue < 0 Then
                numValue = 0
            End If
            objTxt.Text = numValue.ToString("N0")
        End If
    End Sub

    Public Shared Sub txt_number_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objTxt As TextBox = sender
        objTxt.Text = objTxt.Text.Replace(",", String.Empty)
        objTxt.SelectAll()
    End Sub

#End Region

#Region "Function Class"

    ''' <summary>
    ''' Function check value is valid.
    ''' </summary>
    ''' <param name="_value"></param>
    ''' <param name="_length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckValid(ByVal _value As String, _
                                      ByVal _length As Integer, _
                                      ByVal _label As String) As String
        '' Declare msgerror.
        Dim msgerror As String = ""

        '' Case _value is null or blank.
        If "".Equals(_value) Then
            msgerror = "Please enter " & _label & "!"
            Return msgerror
        End If

        '' Case _value is short.
        If _value.Length() < _length Then
            msgerror = _label & " must be least " & _length & " characters!"
            Return msgerror
        End If

        Return msgerror
    End Function

    ''' <summary>
    ''' Check error common of textbox must be input.
    ''' </summary>
    ''' <param name="_tb"></param>
    ''' <remarks></remarks>
    Public Shared Sub CheckErrorUserAndCustomer(ByVal _lb As Label, _
                                                ByVal _tb As TextBox)
        '' Case textbox have value is null or blank.
        If "".Equals(_tb.Text) Then
            'Dim msgScreen As New frm_MSG001(Messages.ERR021 & _lb.Text & "!", "ERR021")
            'If msgScreen.ShowDialog() = DialogResult.OK Then
            '    msgScreen.Close()
            'End If
            '_tb.Focus()
            'Return
        End If
        '' Case textbox not enough 6 characters.
        If _tb.Text.Length() < 6 Then
            'Dim msgScreen As New frm_MSG001(_lb.Text & Messages.ERR022, "ERR022")
            'If msgScreen.ShowDialog() = DialogResult.OK Then
            '    msgScreen.Close()
            'End If
            '_tb.Focus()
            'Return
        End If
    End Sub

    ''' <summary>
    ''' Check error when not selected combobox.
    ''' </summary>
    ''' <param name="_lb"></param>
    ''' <param name="_cb"></param>
    ''' <remarks></remarks>
    Public Shared Sub CheckErrorNotSelectedComboBox(ByVal _lb As Label, _
                                                    ByVal _cb As ComboBox)
        If _cb.SelectedValue = 0 Then
            Dim msgScreen As New frm_MSG001(Messages.ERR025 & _lb.Text & "!", "ERR025")
            If msgScreen.ShowDialog() = DialogResult.OK Then
                msgScreen.Close()
            End If
            _cb.Focus()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Export CSV.from DataTable
    ''' </summary>
    ''' <param name="tb"></param>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExportDataTableIntoCSV(ByVal tb As DataTable, _
                                            ByVal filePath As String)
        Dim value As String = ""
        Dim row As DataRow
        If tb Is Nothing OrElse tb.Rows.Count = 0 Then
            Exit Sub
        End If
        Try
            Dim fileInfo As FileInfo = New FileInfo(filePath)
            Dim sw As StreamWriter = New StreamWriter(filePath)
            For i As Integer = 0 To tb.Columns.Count - 1 Step 1
                If i > 0 Then
                    sw.Write(",")
                End If
                sw.Write(tb.Columns(i).ColumnName)
            Next
            sw.WriteLine()
            For j As Integer = 0 To tb.Rows.Count - 1 Step 1
                If j > 0 Then
                    sw.WriteLine()
                End If
                row = tb.Rows(j)
                For i As Integer = 0 To tb.Columns.Count - 1 Step 1
                    If i > 0 Then
                        sw.Write(",")
                    End If
                    value = Trim(row(i).ToString())
                    value = value.Replace(",", " ")
                    value = value.Replace(Environment.NewLine, " ")
                    sw.Write(value)
                Next
            Next
            sw.Close()
            'fileInfo.IsReadOnly = True



            If File.Exists(filePath) Then
                Dim msgInfo As String = "File """ & _
                                        System.IO.Path.GetFileName(filePath) & _
                                        """ was exported successfully!"
                msgInfo += System.Environment.NewLine
                msgInfo += "Do you want to open this file?"
                Dim frmMsg As New frm_MSG001(msgInfo, "MSG")
                If frmMsg.ShowDialog = DialogResult.Yes Then
                    System.Diagnostics.Process.Start(filePath)
                Else
                    frmMsg.Close()
                End If
            End If
        Catch ex As Exception
            Dim frmMsg001 As New frm_MSG001(ex.Message, "ERRSYS")
            frmMsg001.ShowDialog()
            Return
        End Try
    End Sub
    'AIT Hungtg start 07/08/2015
    ''' <summary>
    ''' Write current record to csv
    ''' </summary>
    ''' <param name="sw"></param>
    ''' <param name="tb"></param>
    ''' <param name="index"></param>
    ''' <remarks></remarks>
    Public Shared Sub WriteCurrentRecordToCSV(ByVal sw As StreamWriter, ByVal tb As DataTable, ByVal index As Integer)
        Dim value As String = ""
        Dim row As DataRow
        row = tb.Rows(index)

        For j As Integer = 0 To tb.Columns.Count - 1 Step 1
            If j > 0 Then
                sw.Write(",")
            End If
            value = Trim(row(j).ToString())
            value = value.Replace(",", " ")
            value = value.Replace(Environment.NewLine, " ")
            sw.Write(value)
        Next
    End Sub
    ''' <summary>
    ''' Export CSV.from new issue production data
    ''' </summary>
    ''' <param name="tb"></param>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExportNewIssueDataIntoCSV(ByVal tb As DataTable, _
                                            ByVal filePath As String)

        If tb Is Nothing OrElse tb.Rows.Count = 0 Then
            Exit Sub
        End If
        'If (GetSetMode = 1) Then
        Try
            Dim rowCount As Integer = tb.Rows.Count - 1
            Dim itemCd As String = tb.Rows(0).Item(3).ToString.Trim
            Dim webSerice As New ABCDService.Service
            Dim quantity = webSerice.GetItemInfoByCd(itemCd, UserId).Tables(0).Rows(0).Item(3).ToString
            Dim oddFilePath As String = String.Format(filePath, itemCd, "ODD")
            Dim evenFilePath As String = String.Format(filePath, itemCd, "EVEN")

            Dim sw As StreamWriter = New StreamWriter(oddFilePath)

            For i As Integer = 0 To tb.Columns.Count - 1 Step 1
                If i > 0 Then
                    sw.Write(",")
                End If
                sw.Write(tb.Columns(i).ColumnName)
            Next
            sw.WriteLine()

            For j As Integer = 0 To rowCount Step 1
                If j = rowCount Then
                    If Not tb.Rows(rowCount).Item(6).ToString.Trim.Equals(quantity) Then
                        sw.Close()
                        If j = 0 Then
                            System.IO.File.Delete(oddFilePath)
                        End If
                        sw = New StreamWriter(evenFilePath)
                        For k As Integer = 0 To tb.Columns.Count - 1 Step 1
                            If k > 0 Then
                                sw.Write(",")
                            End If
                            sw.Write(tb.Columns(k).ColumnName)
                        Next
                        sw.WriteLine()
                        WriteCurrentRecordToCSV(sw, tb, j)
                        Continue For
                    End If
                End If
                If j > 0 Then
                    sw.WriteLine()
                End If
                WriteCurrentRecordToCSV(sw, tb, j)
            Next
            sw.Close()
            'fileInfo.IsReadOnly = True
            Dim msgInfo As String = "Files :"
            If File.Exists(oddFilePath) Then
                msgInfo += System.Environment.NewLine
                msgInfo += """" & System.IO.Path.GetFileName(oddFilePath) & """"
            End If

            If File.Exists(evenFilePath) Then
                msgInfo += System.Environment.NewLine
                msgInfo += """" & System.IO.Path.GetFileName(evenFilePath) & """"
            End If

            msgInfo += " was exported successfully !"
            msgInfo += System.Environment.NewLine
            msgInfo += "Do you want to open these files?"
            Dim frmMsg As New frm_MSG001(msgInfo, "MSG")
            'frmMsg.Size = New Size(500, 300)

            If frmMsg.ShowDialog = DialogResult.Yes Then
                If File.Exists(oddFilePath) Then
                    System.Diagnostics.Process.Start(oddFilePath)
                End If
                If File.Exists(evenFilePath) Then
                    System.Diagnostics.Process.Start(evenFilePath)
                End If
            Else
                frmMsg.Close()
            End If
        Catch ex As Exception
            Dim frmMsg001 As New frm_MSG001(ex.Message, "ERRSYS")
            frmMsg001.ShowDialog()
            Return
        End Try
        'End If
    End Sub
    'AIT Hungtg end 07/08/2015

    Public Shared Function CheckValueIsNull(ByVal lb As Label, _
                                            ByVal tb As TextBox) As Boolean
        Dim value As String = tb.Text
        '' Check value string input from screen.
        If value.Equals("") Then
            Dim msgError As String = "Please input value for " & lb.Text & "!"
            Dim scrError As New frm_MSG001(msgError, "ERR001")
            If scrError.ShowDialog = DialogResult.OK Then
                '' Focus at position error.
                tb.Focus()
            End If
            Return False
        End If
        ''
        Return True
    End Function

    Public Shared Function CheckLengthOfString(ByVal lb As Label, _
                                               ByVal tb As TextBox, _
                                               ByVal l As Integer) As Boolean
        Dim length As Integer = tb.Text.Length
        '' Check exceed number default characters in DB.
        If length <> l Then
            Dim msgError As String = lb.Text & " equal " & l.ToString & " characters specified!"
            Dim scrError As New frm_MSG001(msgError, "ERR003")
            If scrError.ShowDialog = DialogResult.OK Then
                '' Focus at position error.
                tb.Focus()
                tb.SelectAll()
            End If
            Return False
        End If
        '' 
        Return True
    End Function

    Public Shared Function CheckGridViewIsNothing(ByVal dgv As DataGridView) As Boolean
        If dgv.Rows.Count = 0 Then
            Dim msgError As String = "Data is empty now!" & vbCrLf & _
            "Please click Search to get data export!"
            Dim scrError As New frm_MSG001(msgError, "ERR028")
            If scrError.ShowDialog = DialogResult.OK Then
                scrError.Close()
            End If
            Return False
        End If
        Return True
    End Function

    Public Shared Function CheckFocusedControls(ByVal controls As List(Of Control)) As Boolean
        For Each controlIndex As Control In controls
            If controlIndex.Focused Then
                If TypeOf controlIndex Is TextBox Then
                    CType(controlIndex, TextBox).Focus()
                    CType(controlIndex, TextBox).SelectAll()
                End If
                Return False
            End If
        Next
        Return True
    End Function

#Region "DateTimePicker"

    Public Shared Sub InitDateTimePicker(ByVal ctrlDateTimePicker As DateTimePicker)
        ctrlDateTimePicker.Value = DateTime.Now
        ctrlDateTimePicker.CustomFormat = " "
        ctrlDateTimePicker.Format = DateTimePickerFormat.Custom
    End Sub

    Public Shared Sub ChangeDateTimePicker(ByVal ctrlDateTimePicker As DateTimePicker)
        ctrlDateTimePicker.CustomFormat = ABCDConst.FORMAT_DATE_01
        ctrlDateTimePicker.Format = DateTimePickerFormat.Custom
    End Sub

    Public Shared Function CompareDateFromAndDateTo(ByVal dateTimePickerFrom As DateTimePicker, _
                                                    ByVal dateTimePickerTo As DateTimePicker) As Integer
        Return DateTime.Compare(dateTimePickerFrom.Value, dateTimePickerTo.Value)
    End Function

    Public Shared Function CheckNullDateTimePicker(ByVal ctrlDateTimePicker As DateTimePicker)
        If Trim(ctrlDateTimePicker.Text).Equals("") Then
            Dim msgError As String = "Please input W/O Date!"
            Dim scrError As New frm_MSG001(msgError, "ERR042")

            If scrError.ShowDialog = DialogResult.OK Then
                scrError.Close()
                ctrlDateTimePicker.Focus()

                Return False
            End If
        End If

        Return True
    End Function

#End Region

#Region "TextBox"

    Public Shared Function CheckValueDiffZero(ByVal lb As Label, _
                                              ByVal tb As TextBox) As Boolean
        If tb.Text.Equals("0") Then
            Return False
        End If

        Return True
    End Function

    Public Shared Sub AddZeros(ByVal tb As TextBox, _
                               ByVal l As Integer)
        Dim value As String = tb.Text
        Dim charZeros As String = "0000000000"

        If value.Length < l Then
            Dim cutCharZero As String = charZeros.Substring(0, l - value.Length)
            tb.Text = cutCharZero & value
            Return
        End If

        tb.Text = value
        Return
    End Sub

    Public Shared Function AddZeros(ByVal str As String, _
                                    ByVal l As Integer) As String
        Dim value As String = str
        Dim charZeros As String = "0000000000"

        If value.Length < l Then
            Dim cutCharZero As String = charZeros.Substring(0, l - value.Length)
            value = cutCharZero & value
        End If

        Return value
    End Function

    Public Shared Sub InputNumberFromKeyboard(ByVal e As KeyPressEventArgs)
        If Microsoft.VisualBasic.Asc(e.KeyChar) < 48 _
        Or Microsoft.VisualBasic.Asc(e.KeyChar) > 57 Then
            e.Handled = True
        End If
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If
    End Sub

    Public Shared Sub InputSpecialChar(ByVal ctrl As TextBox)
        Dim input As String = System.Text.RegularExpressions.Regex.Replace(ctrl.Text, "[^a-zA-Z0-9]", "")
        ctrl.Text = input
        ctrl.SelectionStart = input.Length
    End Sub

#End Region

#Region "ComboBox"

    Public Shared Function CheckSelectedComboBox(ByVal lb As Label, _
                                                 ByVal cb As ComboBox) As Boolean
        If cb.SelectedValue = 0 Then
            Dim msgError As String = "Please choose one value of " & lb.Text
            Dim scrError As New frm_MSG001(msgError, "ERR027")

            If scrError.ShowDialog = DialogResult.OK Then
                scrError.Close()

                cb.Focus()

                Return False
            End If
        End If

        Return True
    End Function

    Public Shared Sub InitComboboxByStyle(ByVal combobox As ComboBox, _
                                          ByVal style As String)
        Dim dictionary As New Dictionary(Of Integer, String)
        Select Case style
            Case ABCDConst.STYLE_COMBOBOX_01
                dictionary.Add(0, ABCDConst.VALUE_INIT)
                dictionary.Add(1, ABCDConst.VALUE_ADMIN)
                dictionary.Add(2, ABCDConst.VALUE_QC)
                dictionary.Add(3, ABCDConst.VALUE_FG)
                dictionary.Add(4, ABCDConst.VALUE_SU)
                dictionary.Add(5, "MOLD")
            Case ABCDConst.STYLE_COMBOBOX_02
                dictionary.Add(0, ABCDConst.VALUE_INIT)
                dictionary.Add(1, ABCDConst.VALUE_DOMESTIC)
                dictionary.Add(2, ABCDConst.VALUE_OVERSEA)
            Case MODE_WAREHOUSE_STATUS_TR
                dictionary.Add(-1, "")
                Dim wbService As New ABCDService.Service
                Dim dt As DataTable = wbService.GetWarehouseStatusTr(ABCDCommon.UserId).Tables(0)
                For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                    Dim statusCd As String = Trim(dt.Rows(i)("STATUS_CD").ToString)
                    Dim statusNm As String = dt.Rows(i)("STATUS_NM").ToString
                    dictionary.Add(Integer.Parse(statusCd), statusNm)
                Next
                wbService = Nothing
        End Select
        combobox.DataSource = New BindingSource(dictionary, Nothing)
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
    End Sub

#End Region

#Region "DataGridView"

    Public Shared Sub SetDataForTextBoxByDataSet(ByVal controls As List(Of TextBox), _
                                                 ByVal colNames As List(Of String), _
                                                 ByVal ds As DataSet)
        For i As Integer = 0 To controls.Count - 1 Step 1
            controls(i).Text = Trim(ds.Tables(0).Rows(0)(colNames(i).ToString).ToString)
        Next
    End Sub

    Public Shared Sub SetReadOnlyForDataGridView(ByVal dgv As DataGridView, _
                                                 ByVal colNames As List(Of String))
        For i As Integer = 0 To colNames.Count - 1 Step 1
            If i <> 0 Then
                dgv.Columns(colNames(i)).ReadOnly = True
            End If
        Next
    End Sub

    Public Shared Sub GetDataForDataGridViewByDataSet(ByVal colNamesDB As List(Of String), _
                                                      ByVal ds As DataSet, _
                                                      ByVal dgv As DataGridView, _
                                                      ByVal chk As Integer)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1 Step 1
            Dim list As New List(Of String)
            Dim arrAdd(colNamesDB.Count) As String
            For j As Integer = 0 To colNamesDB.Count - 1 Step 1
                If j = 0 Then
                    If chk = ABCDConst.GRIDVIEW_BUTTON Then
                        list.Add("")
                    End If

                    If chk = ABCDConst.GRIDVIEW_CHECKBOX Then
                        list.Add(True)
                    End If

                    If chk = ABCDConst.GRIDVIEW_NORMAL Then
                        list.Add(Trim(ds.Tables(0).Rows(i)(colNamesDB(j)).ToString))
                    End If
                Else
                    If colNamesDB(j).Equals(ABCDConst.COL_AUTHORITY) Then
                        Select Case Trim(ds.Tables(0).Rows(i)(colNamesDB(j)).ToString)
                            Case "1"
                                list.Add(ABCDConst.VALUE_ADMIN)
                            Case "2"
                                list.Add(ABCDConst.VALUE_QC)
                            Case "3"
                                list.Add(ABCDConst.VALUE_FG)
                            Case "4"
                                list.Add(ABCDConst.VALUE_SU)
                            Case "5"
                                list.Add("MOLD")
                        End Select
                    ElseIf colNamesDB(j).Equals(ABCDConst.COL_DESTINATION) Then
                        Select Case Trim(ds.Tables(0).Rows(i)(colNamesDB(j)).ToString)
                            Case "1"
                                list.Add(ABCDConst.VALUE_DOMESTIC)
                            Case "2"
                                list.Add(ABCDConst.VALUE_OVERSEA)
                        End Select
                    Else
                        list.Add(Trim(ds.Tables(0).Rows(i)(colNamesDB(j)).ToString))
                    End If
                End If
            Next

            For j As Integer = 0 To list.Count - 1 Step 1
                arrAdd(j) = list(j)
            Next

            dgv.Rows.Add(arrAdd)
        Next
    End Sub

    Public Shared Function ReturnListFromDataGridView(ByVal dgv As DataGridView, _
                                                      ByVal colIndex As Integer) As List(Of String)
        Dim arr As New List(Of String)

        For i As Integer = 0 To dgv.Rows.Count - 1 Step 1
            If dgv.Rows(i).Cells(0).Value.ToString.Equals("True") Then
                arr.Add(dgv.Rows(i).Cells(colIndex).Value.ToString)
            End If
        Next

        Return arr
    End Function

    Public Shared Sub SelectAllCheckBox(ByVal dgv As DataGridView, ByVal mode As Integer)
        Select Case mode
            Case 0
                For i As Integer = 0 To dgv.Rows.Count - 1 Step 1
                    dgv.Rows(i).Cells(0).Value = "False"
                Next
            Case 1
                For i As Integer = 0 To dgv.Rows.Count - 1 Step 1
                    dgv.Rows(i).Cells(0).Value = "True"
                Next
        End Select
    End Sub

    Public Shared Function CheckNullOfDataGridView(ByVal dgv As DataGridView) As Boolean
        If dgv.Rows.Count = 0 Then
            Dim msgError As String = "Data is empty, please excute inquiry first!"
            Dim scrError As New frm_MSG001(msgError, "ERR028")

            If scrError.ShowDialog = DialogResult.OK Then
                scrError.Close()
                Return False
            End If
        End If

        Return True
    End Function

    Public Shared Sub ExportGridViewIntoCSV(ByVal dgv As DataGridView, _
                                            ByVal fn As String)
        Dim value As String = ""
        Dim dgrr As DataGridViewRow = New DataGridViewRow
        Dim sw As StreamWriter = New StreamWriter(fn)

        For i As Integer = 0 To dgv.Columns.Count - 1 Step 1
            If i > 0 Then
                sw.Write(",")
            End If
            sw.Write(dgv.Columns(i).HeaderText)
        Next
        sw.WriteLine()

        For j As Integer = 0 To dgv.Rows.Count - 1 Step 1
            If j > 0 Then
                sw.WriteLine()
            End If
            dgrr = dgv.Rows(j)
            For i As Integer = 0 To dgv.Columns.Count - 1 Step 1
                If i > 0 Then
                    sw.Write(",")
                End If
                value = Trim(dgrr.Cells(i).Value.ToString)
                value = value.Replace(",", "")
                value = value.Replace(Environment.NewLine, " ")
                sw.Write(value)
            Next
        Next
        sw.Close()

        If File.Exists(fn) Then
            Dim msgInfo As String = "File """ & _
                                    System.IO.Path.GetFileName(fn) & _
                                    """ was exported successfully!"
            msgInfo += System.Environment.NewLine
            msgInfo += "Do you want to open this file?"
            Dim frmMsg As New frm_MSG001(msgInfo, "MSG")
            If frmMsg.ShowDialog = DialogResult.Yes Then
                System.Diagnostics.Process.Start(fn)
            Else
                frmMsg.Close()
            End If
        End If
    End Sub
    'AIT Hungtg start 10/08/2015
    ''' <summary>
    ''' Write current datagridview row to csv
    ''' </summary>
    ''' <param name="sw"></param>
    ''' <param name="dgv"></param>
    ''' <param name="index"></param>
    ''' <remarks></remarks>
    Public Shared Sub WriteCurrentDgvRowToCSV(ByVal sw As StreamWriter, ByVal dgv As DataGridView, ByVal index As Integer)
        Dim value As String = ""
        Dim row As DataGridViewRow
        row = dgv.Rows(index)

        For j As Integer = 0 To dgv.Columns.Count - 1 Step 1
            If j > 0 Then
                sw.Write(",")
            End If
            value = Trim(row.Cells(j).Value)
            value = value.Replace(",", " ")
            value = value.Replace(Environment.NewLine, " ")
            sw.Write(value)
        Next
    End Sub
    ''' <summary>
    ''' Export CSV.from reissue production data
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExportReIssueDataIntoCSV(ByVal dgv As DataGridView, _
                                            ByVal filePath As String)
        If dgv.RowCount = 0 Then
            Exit Sub
        End If
        Try
            Dim rowCount As Integer = dgv.RowCount - 1
            Dim itemCd As String = dgv.Rows(0).Cells(3).Value.Trim
            Dim webSerice As New ABCDService.Service
            Dim quantity = webSerice.GetItemInfoByCd(itemCd, UserId).Tables(0).Rows(0).Item(3).ToString
            Dim oddFilePath As String = String.Format(filePath, itemCd, "ODD")
            Dim evenFilePath As String = String.Format(filePath, itemCd, "EVEN")

            Dim sw As StreamWriter = New StreamWriter(oddFilePath)

            For i As Integer = 0 To dgv.Columns.Count - 1 Step 1
                If i > 0 Then
                    sw.Write(",")
                End If
                sw.Write(dgv.Columns(i).Name)
            Next
            sw.WriteLine()

            For j As Integer = 0 To rowCount Step 1
                If j = rowCount Then
                    If Not dgv.Rows(rowCount).Cells(6).Value.Trim.Equals(quantity) Then
                        sw.Close()
                        If j = 0 Then
                            System.IO.File.Delete(oddFilePath)
                        End If
                        sw = New StreamWriter(evenFilePath)

                        For k As Integer = 0 To dgv.Columns.Count - 1 Step 1
                            If k > 0 Then
                                sw.Write(",")
                            End If
                            sw.Write(dgv.Columns(k).Name)
                        Next
                        sw.WriteLine()
                        WriteCurrentDgvRowToCSV(sw, dgv, j)
                        Continue For
                    End If
                End If
                If j > 0 Then
                    sw.WriteLine()
                End If
                WriteCurrentDgvRowToCSV(sw, dgv, j)
            Next
            sw.Close()
            'fileInfo.IsReadOnly = True
            Dim msgInfo As String = "Files :"
            If File.Exists(oddFilePath) Then
                msgInfo += System.Environment.NewLine
                msgInfo += """" & System.IO.Path.GetFileName(oddFilePath) & """"
            End If

            If File.Exists(evenFilePath) Then
                msgInfo += System.Environment.NewLine
                msgInfo += """" & System.IO.Path.GetFileName(evenFilePath) & """"
            End If

            msgInfo += " was exported successfully !"
            msgInfo += System.Environment.NewLine
            msgInfo += "Do you want to open these files?"
            Dim frmMsg As New frm_MSG001(msgInfo, "MSG")
            'frmMsg.Size = New Size(500, 300)

            If frmMsg.ShowDialog = DialogResult.Yes Then
                If File.Exists(oddFilePath) Then
                    System.Diagnostics.Process.Start(oddFilePath)
                End If
                If File.Exists(evenFilePath) Then
                    System.Diagnostics.Process.Start(evenFilePath)
                End If
            Else
                frmMsg.Close()
            End If

        Catch ex As Exception
            Dim frmMsg001 As New frm_MSG001(ex.Message, "ERRSYS")
            frmMsg001.ShowDialog()
            Return
        End Try

    End Sub
    'AIT Hungtg end 10/08/2015

    Public Shared Sub CreateColumnsInGridView(ByVal dgv As DataGridView, _
                                              ByVal colNames As List(Of String), _
                                              ByVal colSizes As List(Of Integer))
        dgv.ColumnCount = colNames.Count
        For i As Integer = 0 To colNames.Count - 1 Step 1
            dgv.Columns(i).Name = colNames(i)
            dgv.Columns(i).Width = colSizes(i)
        Next
    End Sub

    Public Shared Function CheckDataExistInGridView(ByVal gridView As DataGridView, ByVal value As String) As Boolean
        For i As Integer = 0 To gridView.Rows.Count - 1 Step 1
            If gridView.Rows(i).Cells(1).Value.ToString.Equals(value) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Sub RemoveValueUncheckOnGridView(ByVal gridView As DataGridView)
        Dim hasChecked As Boolean = False
        For i As Integer = 0 To gridView.RowCount - 1 Step 1
            If gridView.Rows(i).Cells(0).Value = True Then
                hasChecked = True
            End If
        Next

        If hasChecked = False Then
            Dim frm As New frm_MSG001("Please select row !", "ERR")
            frm.ShowDialog()
            Return
        End If

        For i As Integer = gridView.Rows.Count - 1 To 0 Step -1
            If gridView.Rows(i).Cells(0).Value = True Then
                gridView.Rows.RemoveAt(i)
            End If
        Next
        gridView.Refresh()
    End Sub

    Public Shared Function AddGridViewToList(ByVal grid As DataGridView, ByVal list As List(Of String)) As List(Of String)
        list = New List(Of String)
        For i As Integer = 0 To grid.Rows.Count - 1 Step 1
            list.Add(grid.Rows(i).Cells(1).Value.ToString)
        Next
        Return list
    End Function

#End Region

#Region "Label"

    Public Shared Function GetSystemDateWithFormat() As String
        Return "User Id: " & UserId & " - Today: " & DateTime.Now.ToString(ABCDConst.Format_Date_01)
    End Function

#End Region

#End Region

#Region ""
    Public Shared Sub ExportGridviewToExcel(ByVal gridView As DataGridView, ByVal fileName As String, ByVal sheetName As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add(misValue)
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Sheets(1)
        xlWorkSheet.Rows.NumberFormat = "@"
        '' Column header for excel.
        For Each col As DataGridViewColumn In gridView.Columns
            xlWorkSheet.Cells(1, col.Index + 1) = col.Name.ToString
        Next
        '' Loop data on gridview.
        For i = 1 To gridView.RowCount
            xlWorkSheet.Cells(i + 1, 1) = gridView.Rows(i - 1).Cells(0).Value
            For j = 1 To gridView.Columns.Count - 1
                xlWorkSheet.Cells(i + 1, j + 1) = gridView.Rows(i - 1).Cells(j).Value
            Next
        Next
        Try
            '' Save file.
            xlWorkSheet.SaveAs(fileName)
            '' Close work book file excel after save.
            xlWorkBook.Close()
            '' Quit application.
            xlApp.Quit()
            '' Release object.
            ReleaseObject(xlApp)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlWorkSheet)
            Dim msg001 As New frm_MSG001(Messages.MSG002, "MSG002")
            If msg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(fileName)
            End If
        Catch ex As Exception
            Dim msg001 As New frm_MSG001(ex.Message, "ERRSYS")
            msg001.ShowDialog()
        End Try
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Public Shared Sub ExportDatatableToExcel(ByVal dt As DataTable, ByVal fileName As String, ByVal sheetName As String)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add(misValue)
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = xlWorkBook.Sheets(1)

        Try
            xlWorkSheet.Rows.NumberFormat = "@"
            '' Column header for excel.        
            Dim index As Integer = 0
            For Each col As DataColumn In dt.Columns
                xlWorkSheet.Cells(1, index + 1) = col.ColumnName.ToString
                index += 1
            Next
            '' Loop data on gridview.        
            For i = 1 To dt.Rows.Count
                xlWorkSheet.Cells(i + 1, 1) = dt.Rows(i - 1)(0)
                For j = 1 To dt.Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = dt.Rows(i - 1)(j)
                Next
            Next
            xlWorkSheet.Columns.AutoFit()
            '' Save file.
            xlWorkSheet.SaveAs(fileName)

            Dim msg001 As New frm_MSG001(Messages.MSG002, "MSG002")
            If msg001.ShowDialog = Windows.Forms.DialogResult.Yes Then
                System.Diagnostics.Process.Start(fileName)
            End If

        Catch ex As Exception
            Dim frmMsg001 As New frm_MSG001(ex.Message, "ERRSYS")
            frmMsg001.ShowDialog()
        Finally
            '' Close work book file excel after save.
            xlWorkBook.Close()
            '' Quit application.
            xlApp.Quit()
            '' Release object.
            ReleaseObject(xlApp)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlWorkSheet)

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try

    End Sub

    Public Shared Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            Dim msg001 As New frm_MSG001(ex.ToString(), "ERRSYS")
            msg001.ShowDialog()
            Exit Sub
        Finally
            GC.Collect()
        End Try
    End Sub
#End Region

#Region "Export Screen SHS001_Shipment Request Entry"

#End Region

    Public Shared Function ConvertUnit(ByVal numUnit As String) As String
        Dim strUnit As String = ""
        Select Case numUnit
            Case "1"
                strUnit = "Pcs"
        End Select
        Return strUnit
    End Function


#Region "https"

    ''' <summary>
    ''' trust all certification.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="certification"></param>
    ''' <param name="chain"></param>
    ''' <param name="sslPolicyErrors"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AcceptAllCertifications(ByVal sender As Object, _
                                                   ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, _
                                                   ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, _
                                                   ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

#End Region

#Region "class EncryptDecryptVB"

    Public NotInheritable Class EncryptDecryptVB

        '' new variable.
        Private TripleDes As New TripleDESCryptoServiceProvider

        ''' <summary>
        ''' truncate hash.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="length"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
            Dim sha1 As New SHA1CryptoServiceProvider
            '' Hash the key.
            Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
            Dim hash() As Byte = sha1.ComputeHash(keyBytes)
            '' Truncate or pad the hash.
            ReDim Preserve hash(length - 1)
            Return hash
        End Function

        ''' <summary>
        ''' new class.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <remarks></remarks>
        Sub New(ByVal key As String)
            ' Initialize the crypto provider.
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
        End Sub

        ''' <summary>
        ''' encrypt data.
        ''' </summary>
        ''' <param name="plaintext"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function EncryptData(ByVal plaintext As String) As String
            ' Convert the plaintext string to a byte array.
            Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)
            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the encoder to write to the stream.
            Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()
            ' Convert the encrypted stream to a printable string.
            Return Convert.ToBase64String(ms.ToArray)
        End Function

        ''' <summary>
        ''' decrypt data.
        ''' </summary>
        ''' <param name="encryptedtext"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DecryptData(ByVal encryptedtext As String) As String
            ' Convert the encrypted text string to a byte array.
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)
            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream.
            Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()
            ' Convert the plaintext stream to a string.
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
        End Function

    End Class

#End Region

#Region "Export excel"

    ''' <summary>
    ''' Method: Common export file export with template
    ''' Cuongtk - 20150811: Improved to work export StockInOutHistory
    ''' Cuongtk - 20150819: Add column Invoice No to work export StockInOutHistory
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <param name="pathTemplate"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExportStockInOutHistory(ByVal dataTable As DataTable, ByVal pathTemplate As String, ByVal pathFileName As String)
        Dim cultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(CULT_CMN_INF)
        Dim appExcel As New Excel.Application
        Dim workBookExcel As Excel.Workbook = appExcel.Workbooks.Open(pathTemplate)
        Dim sheetExcel As Excel.Worksheet = workBookExcel.Worksheets(1)
        Dim columnIdx As Integer = 1
        Dim rowIdx As Integer = 2
        '// Set value on template excel[Stock In Out History]
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            sheetExcel.Cells(rowIdx, columnIdx) = (i + 1).ToString '// [Stt]
            '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - start
            sheetExcel.Cells(rowIdx, columnIdx + 1) = STRG_CMN_02 & Trim(dataTable.Rows(i)(0).ToString) '// [Shipment Request No]
            sheetExcel.Cells(rowIdx, columnIdx + 2) = STRG_CMN_02 & Trim(dataTable.Rows(i)(1).ToString) '// [Barcode No]
            sheetExcel.Cells(rowIdx, columnIdx + 3) = STRG_CMN_02 & Trim(dataTable.Rows(i)(2).ToString) '// [Invoice No]
            sheetExcel.Cells(rowIdx, columnIdx + 4) = STRG_CMN_02 & Trim(dataTable.Rows(i)(3).ToString) '// [Lot No]
            sheetExcel.Cells(rowIdx, columnIdx + 5) = STRG_CMN_02 & Trim(dataTable.Rows(i)(4).ToString) '// [Item Code]
            sheetExcel.Cells(rowIdx, columnIdx + 6) = STRG_CMN_02 & Trim(dataTable.Rows(i)(5).ToString) '// [Warehouse Code]
            sheetExcel.Cells(rowIdx, columnIdx + 7) = STRG_CMN_02 & Trim(dataTable.Rows(i)(6).ToString) '// [Rack Code]
            sheetExcel.Cells(rowIdx, columnIdx + 8) = STRG_CMN_02 & Trim(dataTable.Rows(i)(7).ToString) '// [Status Name]
            sheetExcel.Cells(rowIdx, columnIdx + 9) = STRG_CMN_02 & Trim(dataTable.Rows(i)(8).ToString) '// [Registered Id]
            sheetExcel.Cells(rowIdx, columnIdx + 10) = STRG_CMN_02 & Trim(dataTable.Rows(i)(9).ToString) '// [Registered Date]
            sheetExcel.Cells(rowIdx, columnIdx + 11) = STRG_CMN_02 & Trim(dataTable.Rows(i)(10).ToString) '// [Updated Id]
            sheetExcel.Cells(rowIdx, columnIdx + 12) = STRG_CMN_02 & Trim(dataTable.Rows(i)(11).ToString) '// [Updated Date]
            '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - end
            'sheetExcel.Cells(rowIdx, columnIdx + 1) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx - 1).ToString) '// [Warehouse Code]
            'sheetExcel.Cells(rowIdx, columnIdx + 2) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx).ToString) '// [Item Code]
            'sheetExcel.Cells(rowIdx, columnIdx + 3) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 1).ToString) '// [Item Name]
            'sheetExcel.Cells(rowIdx, columnIdx + 4) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 2).ToString) '// [Rack Code]
            'sheetExcel.Cells(rowIdx, columnIdx + 5) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 3).ToString) '// [Rack Name]
            'sheetExcel.Cells(rowIdx, columnIdx + 6) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 4).ToString) '// [Barcode No]
            'sheetExcel.Cells(rowIdx, columnIdx + 7) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 5).ToString) '// [Invoice No]
            'sheetExcel.Cells(rowIdx, columnIdx + 7) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 5).ToString) '// [Status Flag]
            'sheetExcel.Cells(rowIdx, columnIdx + 8) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 6).ToString) '// [Status Name]
            'sheetExcel.Cells(rowIdx, columnIdx + 9) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 7).ToString) '// [Registered Id]
            'sheetExcel.Cells(rowIdx, columnIdx + 10) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 8).ToString) '// [Registered Date]
            'sheetExcel.Cells(rowIdx, columnIdx + 11) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 9).ToString) '// [Updated Id]
            'sheetExcel.Cells(rowIdx, columnIdx + 12) = STRG_CMN_02 & Trim(dataTable.Rows(i)(columnIdx + 10).ToString) '// [Updated Date]
            rowIdx = rowIdx + 1
        Next
        '// Save file and open file
        sheetExcel.SaveAs(pathFileName)
        '// Close variable
        workBookExcel.Close()
        appExcel.Quit()
        '// Release object
        ReleaseObject(appExcel)
        ReleaseObject(workBookExcel)
        ReleaseObject(sheetExcel)
        '// Auto open file
        Dim formMessage As New frm_MSG001(Messages.MSG002, MSG_CODE_01)
        If formMessage.ShowDialog = DialogResult.Yes Then
            System.Diagnostics.Process.Start(pathFileName)
        End If
    End Sub

    ''' <summary>
    ''' Method: Common export file export with template
    ''' Cuongtk - 20150819: Improved to work export StocktakingList
    ''' </summary>
    ''' <param name="dataTable"></param>
    ''' <param name="fileTemplate"></param>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExportStocktakingList(ByVal dataTable As DataTable, ByVal fileTemplate As String, ByVal fileName As String)
        Dim cultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(CULT_CMN_INF)
        Dim appExcel As New Excel.Application
        Dim workBookExcel As Excel.Workbook = appExcel.Workbooks.Open(fileTemplate)
        Dim sheetExcel As Excel.Worksheet = workBookExcel.Worksheets(1)
        Dim columnIdx As Integer = 1
        Dim rowIdx As Integer = 2
        '// Set value on template excel[StocktakingList]
        For i As Integer = 0 To dataTable.Rows.Count - 1 Step 1
            sheetExcel.Cells(rowIdx, columnIdx) = (i + 1).ToString '// [Stt]
            sheetExcel.Cells(rowIdx, columnIdx + 1) = Date.Parse(dataTable.Rows(i)("STOCK_DT").ToString).ToString("dd/MM/yyyy") '// [Stocktaking Date]
            sheetExcel.Cells(rowIdx, columnIdx + 2) = "'" & Trim(dataTable.Rows(i)("SYS_WH_CD").ToString) '// [Warehouse Code(System)]
            sheetExcel.Cells(rowIdx, columnIdx + 3) = "'" & Trim(dataTable.Rows(i)("SYS_RACK_CD").ToString) '// [Rack Code(System)]
            sheetExcel.Cells(rowIdx, columnIdx + 4) = "'" & Trim(dataTable.Rows(i)("BC_NO").ToString) '// [Barcode No]
            sheetExcel.Cells(rowIdx, columnIdx + 5) = "'" & Trim(dataTable.Rows(i)("ITEM_CD").ToString) '// [Item Code]
            sheetExcel.Cells(rowIdx, columnIdx + 6) = "'" & Trim(dataTable.Rows(i)("ITEM_NM").ToString) '// [Item Name]
            sheetExcel.Cells(rowIdx, columnIdx + 7) = "'" & Trim(dataTable.Rows(i)("BOX_NUM").ToString) '// [Box No]
            sheetExcel.Cells(rowIdx, columnIdx + 8) = dataTable.Rows(i)("QTY_PER_BOX").ToString '// [Quantity]
            sheetExcel.Cells(rowIdx, columnIdx + 9) = ConvertUnit(Trim(dataTable.Rows(i)("UNIT").ToString)) '// [Unit]
            'sheetExcel.Cells(rowIdx, columnIdx + 10) = "'" & dataTable.Rows(i)("SPEC_FLG").ToString '// [Specific Flag]
            'sheetExcel.Cells(rowIdx, columnIdx + 11) = "'" & dataTable.Rows(i)("SCAN_FLG").ToString '// [Scan Flag]
            sheetExcel.Cells(rowIdx, columnIdx + 12) = "'" & Trim(dataTable.Rows(i)("REG_USER_CD").ToString) '// [Registered Id]
            sheetExcel.Cells(rowIdx, columnIdx + 13) = "'" & Date.Parse(dataTable.Rows(i)("REG_DT").ToString).ToString("dd/MM/yyyy HH:mm:ss") '// [Registered Date]
            sheetExcel.Cells(rowIdx, columnIdx + 14) = "'" & Trim(dataTable.Rows(i)("UPD_USER_CD").ToString) '// [Updated Id]
            sheetExcel.Cells(rowIdx, columnIdx + 15) = "'" & Date.Parse(dataTable.Rows(i)("UPD_DT").ToString).ToString("dd/MM/yyyy HH:mm:ss") '// [Updated Date]
            rowIdx = rowIdx + 1
        Next
        '// Save file and open file
        sheetExcel.SaveAs(fileName)
        '// Close variable
        workBookExcel.Close()
        appExcel.Quit()
        '// Release object
        ReleaseObject(appExcel)
        ReleaseObject(workBookExcel)
        ReleaseObject(sheetExcel)
        '// Auto open file
        Dim formMessage As New frm_MSG001(Messages.MSG002, MSG_CODE_01)
        If formMessage.ShowDialog = DialogResult.Yes Then
            System.Diagnostics.Process.Start(fileName)
        End If
    End Sub

    ''' <summary>
    ''' Method: Export shipment inquiry by invoice no
    ''' Cuongtk - 20150821: export file
    ''' </summary>
    ''' <param name="shipmentGridview"></param>
    ''' <param name="fileName"></param>
    ''' <param name="fileTemplate"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExportShipmentInquiryByInvoiceNo(ByVal shipmentGridview As DataGridView, ByVal fileName As String, ByVal fileTemplate As String)
        Dim cultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(CULT_CMN_INF)
        Dim appExcel As New Excel.Application
        Dim workBookExcel As Excel.Workbook = appExcel.Workbooks.Open(fileTemplate)
        Dim sheetExcel As Excel.Worksheet = workBookExcel.Worksheets(1)
        Dim columnIdx As Integer = 1
        Dim rowIdx As Integer = 2
        '// Set value on template excel[Shipment Inquiry By Invoice No]
        For i As Integer = 0 To shipmentGridview.RowCount - 1 Step 1
            sheetExcel.Cells(rowIdx, columnIdx) = (i + 1).ToString '// [Stt]
            sheetExcel.Cells(rowIdx, columnIdx + 1) = "'" & shipmentGridview.Rows(i).Cells(0).Value.ToString '// Shipment Date
            sheetExcel.Cells(rowIdx, columnIdx + 2) = "'" & shipmentGridview.Rows(i).Cells(1).Value.ToString '// Shipment Request No
            sheetExcel.Cells(rowIdx, columnIdx + 3) = "'" & shipmentGridview.Rows(i).Cells(2).Value.ToString '// Pallet No
            sheetExcel.Cells(rowIdx, columnIdx + 4) = "'" & shipmentGridview.Rows(i).Cells(3).Value.ToString '// Item Code
            sheetExcel.Cells(rowIdx, columnIdx + 5) = "'" & shipmentGridview.Rows(i).Cells(4).Value.ToString '// Item Name
            sheetExcel.Cells(rowIdx, columnIdx + 6) = shipmentGridview.Rows(i).Cells(5).Value.ToString '// Quantity
            sheetExcel.Cells(rowIdx, columnIdx + 7) = "'" & shipmentGridview.Rows(i).Cells(6).Value.ToString '// Lot No
            sheetExcel.Cells(rowIdx, columnIdx + 8) = "'" & shipmentGridview.Rows(i).Cells(7).Value.ToString '// Invoice No
            sheetExcel.Cells(rowIdx, columnIdx + 9) = "'" & shipmentGridview.Rows(i).Cells(8).Value.ToString '// Barcode No
            sheetExcel.Cells(rowIdx, columnIdx + 10) = "'" & shipmentGridview.Rows(i).Cells(9).Value.ToString '// Customer No
            rowIdx = rowIdx + 1
        Next
        '// Save file and open file
        sheetExcel.SaveAs(fileName)
        '// Close variable
        workBookExcel.Close()
        appExcel.Quit()
        '// Release object
        ReleaseObject(appExcel)
        ReleaseObject(workBookExcel)
        ReleaseObject(sheetExcel)
        '// Auto open file
        Dim formMessage As New frm_MSG001(Messages.MSG002, MSG_CODE_01)
        If formMessage.ShowDialog = DialogResult.Yes Then
            System.Diagnostics.Process.Start(fileName)
        End If
    End Sub

    ''' <summary>
    ''' Method: Convert string value to date
    ''' Cuongtk - 20150819: Create method convert string to date have format
    ''' </summary>
    ''' <param name="stringValue"></param>
    ''' <param name="stringFormat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertDate(ByVal stringValue As String, ByVal stringFormat As String) As Date
        Dim dateValue As Date = Nothing
        If Date.TryParseExact(stringValue, stringFormat, Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None, dateValue) Then
            Return dateValue
        End If
        Return dateValue
    End Function

#End Region

End Class