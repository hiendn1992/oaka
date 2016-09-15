Public Class frm_OA_MSS002
#Region "Var/Const Form"
    Private ws As New ABCDService.Service
    Private ds As DataSet = Nothing
    Private _dispOpt As Integer
    Private loginCode As String = ABCDCommon.UserId
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
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        CloseScreen()
    End Sub


    Private Sub rdoModeAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoModeAdd.CheckedChanged
        'Set state of radio: add, change, delete.
        rdoModeAdd.Enabled = False
        rdoModeChange.Enabled = False
        rdoModeDelete.Enabled = False
        ' Set state textbox 
        txtReasonCode.Enabled = True
        txtReasonName.Enabled = True
        If rdoModeAdd.Checked = True Then
            txtReasonCode.Focus()
        End If
        ' Set state button: popup, cancel.
        btnCancel.Enabled = True
        btnExecute.Enabled = True
        Me.DispOpt = 1
        Me.Mode = 1
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        ' Validate
        If "".Equals(txtReasonCode.Text.Trim) Then
            Return
        End If
        ' Process insert, update, delete data in DB.
        Select Case Me.Mode
            Case 1  'Mode Add
                ds = ws.GetReasonByCode(txtReasonCode.Text, loginCode)

                If ds.Tables(0).Rows.Count = 1 Then
                    Return
                End If
                Dim strQuestion As String = "Do you want to add this?"
                Dim msgMsg As New frm_MSG001(strQuestion, "MSG035")
                If msgMsg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim row As Integer = ws.InsertReason(txtReasonCode.Text, _
                                                                   txtReasonName.Text, _
                                                                   ABCDCommon.UserId)

                        If row = 1 Then
                            Dim strInfo As String = "Added successfully!"
                            Dim msgInfo As New frm_MSG001(strInfo, "INF036")
                            If msgInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                                msgInfo.Close()
                                ' Set value of textbox.
                                txtReasonName.Text = ""

                                ' Set state of textbox.
                                txtReasonCode.Enabled = True
                                txtReasonName.Enabled = True

                                btnExecute.Enabled = False
                                ' Set focus.
                                txtReasonCode.Focus()
                                txtReasonCode.SelectAll()
                                Me.DispOpt = 2
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
                Dim strQuestion As String = "Do you want to change this?"
                Dim msgMsg As New frm_MSG001(strQuestion, "MSG037")
                If msgMsg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Dim ws As New ABCDService.Service
                    Dim row As Integer = ws.UpdateReason(txtReasonCode.Text, _
                                                               txtReasonName.Text, _
                                                               ABCDCommon.UserId)
                    Try
                        If row = 1 Then
                            Dim strInfo As String = "Updated successfully!"
                            Dim msgInfo As New frm_MSG001(strInfo, "INF038")
                            If msgInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                                msgInfo.Close()
                                ' Set value of textbox.
                                txtReasonName.Text = ""
                                txtReasonName.Enabled = False
                                txtReasonCode.Enabled = True
                                ' Set state of textbox.


                                ' Set state of button.
                                btnExecute.Enabled = False

                                ' Set focus.
                                txtReasonCode.Focus()
                                txtReasonCode.SelectAll()
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
                Dim strQuestion As String = "Do you want to delete this?"
                Dim msgMsg As New frm_MSG001(strQuestion, "MSG039")
                If msgMsg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Dim row As Integer = ws.DeleteReason(txtReasonCode.Text, _
                                                              ABCDCommon.UserId)
                    Try
                        If row = 1 Then
                            Dim strInfo As String = "Deleted successfully!"
                            Dim msgInfo As New frm_MSG001(strInfo, "INF040")
                            If msgInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
                                msgInfo.Close()
                                ' Set value of textbox.
                                txtReasonCode.Text = ""
                                txtReasonName.Text = ""

                                ' Set state of textbox.

                                txtReasonName.Enabled = False
                                txtReasonCode.Enabled = True

                                btnExecute.Enabled = False
                                ' Set focus.
                                txtReasonCode.Focus()
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

    Private Sub txtReasonCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReasonCode.Leave
        ' Focus cancel.
        If btnCancel.Focused Then
            Return
        End If
        ' Focus exit.
        If btnExit.Focused Then
            Return
        End If
        If "".Equals(txtReasonCode.Text.Trim) Then
            Dim strError As String = "Please Enter Reason code"
            Dim msgError As New frm_MSG001(strError, "OMSG001")
            If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                msgError.Close()
                txtReasonCode.Focus()
                Return
            End If
        End If
        ds = ws.GetReasonByCode(txtReasonCode.Text, loginCode)
        Select Case Me.Mode
            Case 1  'Mode Add
                If ds.Tables(0).Rows.Count = 1 Then
                    Dim strError As String = "Reason code already existed"
                    Dim msgError As New frm_MSG001(strError, "OER001")
                    If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                        msgError.Close()
                        txtReasonCode.Focus()
                        txtReasonCode.SelectAll()
                        Return
                    End If
                Else
                    ' Set state of controls

                    txtReasonName.ReadOnly = False
                    txtReasonName.Enabled = True
                    btnExecute.Enabled = True

                    txtReasonName.Focus()
                    Me.DispOpt = 2
                End If
            Case 2  'Mode Change
                If ds.Tables(0).Rows.Count = 0 Then
                    Dim strError As String = "Reason code is not existed"
                    Dim msgError As New frm_MSG001(strError, "OER002")
                    If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                        msgError.Close()
                        txtReasonCode.Focus()
                        txtReasonCode.SelectAll()
                        Return
                    End If
                Else
                    ' Set state of controls.
                    txtReasonCode.Enabled = False
                    txtReasonName.Enabled = True

                    btnExecute.Enabled = True
                    ' Set value of controls.
                    txtReasonName.Text = Trim(ds.Tables(0).Rows(0)("REASON_NM").ToString)

                    ' Set focus.
                    btnExecute.Focus()
                    Me.DispOpt = 2
                End If
            Case 3  'Mode Delete
                If ds.Tables(0).Rows.Count = 0 Then
                    Dim strError As String = "Reason code is not existed"
                    Dim msgError As New frm_MSG001(strError, "OER002")
                    If msgError.ShowDialog = Windows.Forms.DialogResult.OK Then
                        msgError.Close()
                        txtReasonCode.Focus()
                        txtReasonCode.SelectAll()
                        Return
                    End If
                Else
                    ' Set state of controls.
                    txtReasonCode.Enabled = False
                    txtReasonName.Enabled = False

                    btnExecute.Enabled = True
                    ' Set value of controls.
                    txtReasonName.Text = Trim(ds.Tables(0).Rows(0)("REASON_NM").ToString)

                    ' Set focus.
                    btnExecute.Focus()
                    Me.DispOpt = 2
                End If
        End Select

    End Sub

    Private Sub rdoModeChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoModeChange.CheckedChanged
        'Set state of radio: add, change, delete.
        rdoModeAdd.Enabled = False
        rdoModeChange.Enabled = False
        rdoModeDelete.Enabled = False
        ' Set state textbox
        txtReasonCode.Enabled = True
        If rdoModeChange.Checked = True Then
            txtReasonCode.Focus()
        End If
        ' Set state button: cancel.
        btnCancel.Enabled = True
        Me.DispOpt = 1
        Me.Mode = 2
    End Sub

    Private Sub rdoModeDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoModeDelete.CheckedChanged
        'Set state of radio: add, change, delete.
        'txt_rack_code.Focus()
        rdoModeAdd.Enabled = False
        rdoModeChange.Enabled = False
        rdoModeDelete.Enabled = False
        ' Set state textbox
        txtReasonCode.Enabled = True
        If rdoModeDelete.Checked = True Then
            txtReasonCode.Focus()
        End If
        ' Set state button: cancel.
        btnCancel.Enabled = True
        Me.DispOpt = 1
        Me.Mode = 3
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.DispOpt = 1 Then
            ' Set value and state of radio: add, change, delete.
            rdoModeAdd.Checked = CheckState.Unchecked
            rdoModeChange.Checked = CheckState.Unchecked
            rdoModeDelete.Checked = CheckState.Unchecked
            rdoModeAdd.Enabled = True
            rdoModeChange.Enabled = True
            rdoModeDelete.Enabled = True
            ' Set value and state of textbox:
            txtReasonCode.Text = ""
            txtReasonCode.Text = ""
            ' Set state of button: cancel.
            DispInitForm()
            Me.DispOpt = 0
            Me.Mode = 0
            Return
        End If
        If Me.DispOpt = 2 Then
            ' Set value of controls.
            txtReasonName.Text = ""
            ' Set state of controls.
            txtReasonName.Enabled = True
            If rdoModeAdd.Checked Then
                txtReasonCode.Enabled = True
            ElseIf rdoModeChange.Checked Or rdoModeDelete.Checked Then
                txtReasonCode.Enabled = False
            End If
            btnExecute.Enabled = False
            ' Set focus.
            txtReasonCode.Focus()
            txtReasonCode.SelectAll()
            Me.DispOpt = 1
            Return
        End If
    End Sub
#End Region

#Region "Common Method Form"
    Private Sub DispInitForm()
        ' Set value of radio: add, change, delete.
        rdoModeAdd.Checked = CheckState.Unchecked
        rdoModeChange.Checked = CheckState.Unchecked
        rdoModeDelete.Checked = CheckState.Unchecked
        ' Set state textbox
        txtReasonName.Enabled = False
        txtReasonCode.Enabled = False
        btnExecute.Enabled = False
        btnCancel.Enabled = False
    End Sub

    ''Close current Screen
    Private Sub CloseScreen()
        Me.Close()
    End Sub

    Private Sub ResetValueControls()
        txtReasonCode.Text = ""
        txtReasonName.Text = ""
    End Sub
#End Region

End Class