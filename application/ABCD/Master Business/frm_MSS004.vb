''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_MSS004.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   7-JAN-15    1.00     HungTG   New
''*********************************************************
Public Class frm_MSS004

#Region "Var/Const Form"
    Private ws As New ABCDService.Service
    Private ds As DataSet = Nothing
    Private _dispOpt As Integer
    Public Property DispOpt() As Integer
        Get
            Return _dispOpt
        End Get
        Set(ByVal value As Integer)
            _dispOpt = value
        End Set
    End Property

    ''' <summary>
    ''' Set value click radio.
    ''' </summary>
    ''' <remarks></remarks>
    Private _mode As Integer
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal value As Integer)
            _mode = value
        End Set
    End Property
#End Region

#Region "New Form"
    ''' <summary>
    ''' Initialize form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ws.Url = ABCDConst.STRING_URL
        ws.Timeout = ABCDConst.STRING_TIMEOUT

        ' Add any initialization after the InitializeComponent() call.
        lbl_today_date.Text = ABCDCommon.GetSystemDateWithFormat
        DispInitForm()
        Me.DispOpt = 0
        Me.Mode = 0
    End Sub
#End Region

#Region "Event Form"

    Private Sub rdo_mode_add_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_mode_add.CheckedChanged
        'Set state of radio: add, change, delete.
        rdo_mode_add.Enabled = False
        rdo_mode_change.Enabled = False
        rdo_mode_delete.Enabled = False
        ' Set state textbox 
        txt_rack_code.Enabled = True
        If rdo_mode_add.Checked = True Then
            txt_rack_code.Focus()
        End If
        ' Set state button: popup, cancel.
        btn_cancel.Enabled = True
        Me.DispOpt = 1
        Me.Mode = 1
    End Sub

    Private Sub rdo_mode_change_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_mode_change.CheckedChanged
        'Set state of radio: add, change, delete.
        rdo_mode_add.Enabled = False
        rdo_mode_change.Enabled = False
        rdo_mode_delete.Enabled = False
        ' Set state textbox
        txt_rack_code.Enabled = True
        If rdo_mode_change.Checked = True Then
            txt_rack_code.Focus()
        End If
        ' Set state button: popup, cancel.
        btn_popup_rack.Enabled = True
        btn_cancel.Enabled = True
        Me.DispOpt = 1
        Me.Mode = 2
    End Sub
    Private Sub rdo_mode_delete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_mode_delete.CheckedChanged
        'Set state of radio: add, change, delete.
        'txt_rack_code.Focus()
        rdo_mode_add.Enabled = False
        rdo_mode_change.Enabled = False
        rdo_mode_delete.Enabled = False
        ' Set state textbox
        txt_rack_code.Enabled = True
        If rdo_mode_delete.Checked = True Then
            txt_rack_code.Focus()
        End If
        ' Set state button: popup, cancel.
        btn_popup_rack.Enabled = True
        btn_cancel.Enabled = True
        Me.DispOpt = 1
        Me.Mode = 3
    End Sub

    ''' <summary>
    ''' Event click execute.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_execute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_execute.Click
        ' Check valid of rack name: null.
        If "".Equals(txt_rack_name.Text.Trim) Then
            Dim strError As String = "Please insert value of " & lbl_rack_name.Text & "!"
            Dim msgError As New frm_MSG001(strError, "ERR037")
            If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                msgError.Close()
                txt_rack_name.Focus()
                Return
            End If
        End If

        ' Process insert, update, delete data in DB.
        Select Case Me.Mode
            Case 1
                Dim strQuestion As String = "Do you want to insert info " & lbl_rack_code.Text & ": " & txt_rack_code.Text & "?"
                Dim msgMsg As New frm_MSG001(strQuestion, "MSG028")
                If msgMsg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim row As Integer = ws.InsertRackInfo(txt_rack_code.Text, _
                                                                   txt_rack_name.Text, _
                                                                   ABCDCommon.UserId)

                        If row = 1 Then
                            Dim strInfo As String = "Insert " & lbl_rack_code.Text & ": " & txt_rack_code.Text & " successful!"
                            Dim msgInfo As New frm_MSG001(strInfo, "INF001")
                            If msgInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                                msgInfo.Close()
                                ' Set value of textbox.
                                txt_rack_code.Text = ""
                                txt_rack_name.Text = ""

                                ' Set state of textbox.
                                txt_rack_code.ReadOnly = False
                                txt_rack_name.Enabled = False

                                btn_execute.Enabled = False
                                ' Set focus.
                                txt_rack_code.Focus()
                                Me.DispOpt = 1
                            End If
                        End If
                        Return
                    Catch ex As Exception
                        Dim msgError As New frm_MSG001(ex.Message, "ERRSYS")
                        If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                            msgError.Close()
                            Return
                        End If
                    End Try
                Else
                    msgMsg.Close()
                    Return
                End If
            Case 2
                Dim strQuestion As String = "Do you want to update info " & lbl_rack_code.Text & ": " & txt_rack_code.Text & "?"
                Dim msgMsg As New frm_MSG001(strQuestion, "MSG030")
                If msgMsg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Dim ws As New ABCDService.Service
                    Dim row As Integer = ws.UpdateRackInfo(txt_rack_code.Text, _
                                                               txt_rack_name.Text, _
                                                               ABCDCommon.UserId)
                    Try
                        If row = 1 Then
                            Dim strInfo As String = "Update " & lbl_rack_code.Text & ": " & txt_rack_code.Text & " successful!"
                            Dim msgInfo As New frm_MSG001(strInfo, "INF002")
                            If msgInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                                msgInfo.Close()
                                ' Set value of textbox.
                                txt_rack_name.Text = ""

                                ' Set state of textbox.
                                txt_rack_code.ReadOnly = False

                                ' Set state of button.
                                btn_execute.Enabled = False
                                btn_popup_rack.Enabled = True
                                ' Set focus.
                                txt_rack_code.Focus()
                                txt_rack_code.SelectAll()
                                Me.DispOpt = 1
                            End If
                        End If
                        Return
                    Catch ex As Exception
                        Dim msgError As New frm_MSG001(ex.Message, "ERRSYS")
                        If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                            msgError.Close()
                            Return
                        End If
                    End Try
                Else
                    msgMsg.Close()
                    Return
                End If
            Case 3
                'Check if rack is empty
                If ws.CheckRackIsEmpty(txt_rack_code.Text.Trim, ABCDCommon.UserId) = 1 Then
                    Dim errMsg As String = "Rack Code " & txt_rack_code.Text & " is not empty. Can not delete!"
                    Dim frmMsg As New frm_MSG001(errMsg, "ERR099")
                    If frmMsg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        frmMsg.Close()
                        Return
                    End If
                End If
                Dim strQuestion As String = "Do you want to delete info " & lbl_rack_code.Text & ": " & txt_rack_code.Text & "?"
                Dim msgMsg As New frm_MSG001(strQuestion, "MSG031")
                If msgMsg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Dim row As Integer = ws.DeleteRackInfo(txt_rack_code.Text, _
                                                              ABCDCommon.UserId)
                    Try
                        If row = 1 Then
                            Dim strInfo As String = "Delete " & lbl_rack_code.Text & ": " & txt_rack_code.Text & " successful!"
                            Dim msgInfo As New frm_MSG001(strInfo, "INF003")
                            If msgInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                                msgInfo.Close()
                                ' Set value of textbox.
                                txt_rack_code.Text = ""
                                txt_rack_name.Text = ""

                                ' Set state of textbox.
                                txt_rack_code.ReadOnly = False
                                txt_rack_name.Enabled = False

                                btn_execute.Enabled = False
                                btn_popup_rack.Enabled = True
                                ' Set focus.
                                txt_rack_code.Focus()
                                Me.DispOpt = 1
                            End If
                        End If
                        Return
                    Catch ex As Exception
                        Dim msgError As New frm_MSG001(ex.Message, "ERRSYS")
                        If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                            msgError.Close()
                            Return
                        End If
                    End Try
                Else
                    msgMsg.Close()
                    Return
                End If
        End Select
    End Sub


    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        If Me.DispOpt = 1 Then
            ' Set value and state of radio: add, change, delete.
            rdo_mode_add.Checked = CheckState.Unchecked
            rdo_mode_change.Checked = CheckState.Unchecked
            rdo_mode_delete.Checked = CheckState.Unchecked
            rdo_mode_add.Enabled = True
            rdo_mode_change.Enabled = True
            rdo_mode_delete.Enabled = True
            ' Set value and state of textbox:
            txt_rack_code.Text = ""
            txt_rack_code.Enabled = False
            txt_rack_name.Text = ""
            ' Set state of button: popup, cancel.
            btn_popup_rack.Visible = True
            btn_popup_rack.Enabled = False
            btn_cancel.Enabled = False
            Me.DispOpt = 0
            Me.Mode = 0
            Return
        End If
        If Me.DispOpt = 2 Then
            ' Set value of controls.
            txt_rack_name.Text = ""
            ' Set state of controls.
            txt_rack_name.Enabled = False
            txt_rack_code.ReadOnly = False
            txt_rack_code.Enabled = True
            If Me.Mode <> 1 Then
                btn_popup_rack.Enabled = True
            End If
            btn_execute.Enabled = False
            ' Set focus.
            txt_rack_code.Focus()
            txt_rack_code.SelectAll()
            Me.DispOpt = 1
            Return
        End If
    End Sub
    Private Sub txt_rack_code_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_rack_code.Leave
        ' Focus popup.
        If btn_popup_rack.Focused Then
            Return
        End If
        ' Focus cancel.
        If btn_cancel.Focused Then
            Return
        End If
        ' Focus exit.
        If btn_exit.Focused Then
            Return
        End If
        ' Check valid of rack id: null.
        If "".Equals(txt_rack_code.Text.Trim) Then
            Dim strError As String = "Please insert value of " & lbl_rack_code.Text & "!"
            Dim msgError As New frm_MSG001(strError, "ERR035")
            If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                msgError.Close()
                txt_rack_code.Focus()
                Return
            End If
        End If
        ' Check valid of rack id: less 6 characters.
        'If txt_rack_code.Text.Length < 6 Then
        '    Dim strError As String = lbl_rack_code.Text & " must have least 6 characters!"
        '    Dim msgError As New frm_MSG001(strError, "ERR002")
        '    If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
        '        msgError.Close()
        '        txt_rack_code.Focus()
        '        txt_rack_code.SelectAll()
        '        Return
        '    End If
        'End If
        ' Check valid of rack id: DB.
        ds = ws.GetRackInfoByCd(txt_rack_code.Text, Me.Mode)
        Select Case Me.Mode
            Case 1
                If ds.Tables(0).Rows.Count = 1 Then
                    Dim strError As String = lbl_rack_code.Text & ": " & txt_rack_code.Text & " exists in DB!"
                    Dim msgError As New frm_MSG001(strError, "ERR035")
                    If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                        msgError.Close()
                        txt_rack_code.Focus()
                        txt_rack_code.SelectAll()
                        Return
                    End If
                Else
                    ' Set state of controls
                    txt_rack_code.ReadOnly = True
                    txt_rack_name.ReadOnly = False
                    txt_rack_name.Enabled = True
                    btn_execute.Enabled = True

                    txt_rack_name.Focus()
                    Me.DispOpt = 2
                End If
            Case 2
                If ds.Tables(0).Rows.Count = 0 Then
                    Dim strError As String = lbl_rack_code.Text & ": " & txt_rack_code.Text & " not exists in DB!"
                    Dim msgError As New frm_MSG001(strError, "ERR036")
                    If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                        msgError.Close()
                        txt_rack_code.Focus()
                        txt_rack_code.SelectAll()
                        Return
                    End If
                Else
                    ' Set state of controls
                    txt_rack_code.ReadOnly = True
                    txt_rack_name.Enabled = True
                    btn_popup_rack.Enabled = False
                    btn_execute.Enabled = True
                    ' Set value of controls.
                    txt_rack_name.Text = Trim(ds.Tables(0).Rows(0)("RACK_NM").ToString)

                    ' Set focus.
                    txt_rack_name.Focus()
                    Me.DispOpt = 2
                End If
            Case 3
                If ds.Tables(0).Rows.Count = 0 Then
                    Dim strError As String = lbl_rack_name.Text & ": " & lbl_rack_code.Text & " not exists in DB!"
                    Dim msgError As New frm_MSG001(strError, "ERR036")
                    If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                        msgError.Close()
                        txt_rack_code.Focus()
                        txt_rack_code.SelectAll()
                        Return
                    End If
                Else
                    ' Set state of controls.
                    txt_rack_code.ReadOnly = True
                    txt_rack_name.Enabled = True
                    txt_rack_name.ReadOnly = True

                    btn_popup_rack.Enabled = False
                    btn_execute.Enabled = True
                    ' Set value of controls.
                    txt_rack_name.Text = Trim(ds.Tables(0).Rows(0)("RACK_NM").ToString)

                    ' Set focus.
                    btn_execute.Focus()
                    Me.DispOpt = 2
                End If
        End Select
    End Sub
    Private Sub lbl_rack_name_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_rack_name.Leave
        ' Focus execute.
        If btn_execute.Focused Then
            Return
        End If
        ' Focus cancel.
        If btn_cancel.Focused Then
            Return
        End If
        ' Focus exit.
        If btn_exit.Focused Then
            Return
        End If
        ' Check valid of customer name: null.
        If "".Equals(txt_rack_name.Text.Trim) Then
            Dim strError As String = "Please insert value of " & lbl_rack_name.Text & "!"
            Dim msgError As New frm_MSG001(strError, "ERR037")
            If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                msgError.Close()
                txt_rack_name.Focus()
                Return
            End If
        End If
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        CloseScreen()
    End Sub

    Private Sub btn_popup_rack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_popup_rack.Click
        Dim popupRack As New frm_POS002(Me)
        popupRack.ShowDialog()
        If Mode = 2 Then
            txt_rack_code.Enabled = False
            btn_popup_rack.Enabled = False
            txt_rack_name.Enabled = True
            btn_execute.Enabled = True
            DispOpt = 2
        Else
            txt_rack_code.Enabled = False
            btn_popup_rack.Enabled = False
            txt_rack_name.Enabled = False
            btn_execute.Enabled = True
            DispOpt = 2
        End If
    End Sub
#End Region

#Region "Common Method Form"
    ''Check client warhouse info that is entered
    Private Function FieldClientCheck(ByVal txtValue, ByVal charNum, ByVal txtName)
        Dim msgerror As String = ""
        msgerror = ABCDCommon.CheckValid(txtValue, charNum, txtName)
        If Not "".Equals(msgerror) Then
            MessageBox.Show(msgerror)
        Else : SendKeys.Send("{Tab}")
        End If
        Return msgerror
    End Function
    ''Check server warhouse info that is entered
    Private Function WarehouseInfoServerCheck(ByVal _whCd) As Integer
        '' Declare webservice, datatable.
        Dim ws As New ABCDService.Service()
        Dim dt As DataTable = Nothing

        '' Get dataset from webservice and get datatable.
        dt = ws.GetRackInfoByCd(_whCd, 1).Tables(0)

        '' Check datatable have row data.
        If dt.Rows.Count <> 0 Then
            Return 1
        Else : Return 0
        End If
    End Function
    Private Sub DispInitForm()
        ' Set value of radio: add, change, delete.
        rdo_mode_add.Checked = CheckState.Unchecked
        rdo_mode_change.Checked = CheckState.Unchecked
        rdo_mode_delete.Checked = CheckState.Unchecked
        ' Set state textbox
        txt_rack_code.Enabled = False
        txt_rack_name.Enabled = False
        ' Set state button: Exec, Cancel, Popup.
        btn_popup_rack.Enabled = False
        btn_execute.Enabled = False
        btn_cancel.Enabled = False
    End Sub
    Private Sub ResetStateControls()
        ' Enable textbox
        txt_rack_code.Enabled = True
        txt_rack_name.Enabled = True
        ' Enable button
        btn_popup_rack.Show()
        btn_popup_rack.Enabled = True
        btn_execute.Enabled = True
        btn_cancel.Enabled = True
        btn_exit.Enabled = True
    End Sub
    Private Sub ResetValueControls()
        txt_rack_code.Text = ""
        txt_rack_name.Text = ""
    End Sub
    ''Close current Screen
    Private Sub CloseScreen()
        Me.Close()
    End Sub
#End Region

End Class


