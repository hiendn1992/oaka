''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_LGN001.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   14-DEC-14    1.00     CuongTK   New
''*********************************************************
Imports ABCD.My.Resources
Imports System.Net

Public Class frm_LGN001

#Region "Var/Const Form."

    ''' <summary>
    ''' Variable ABCD Web Service.
    ''' </summary>
    ''' <remarks></remarks>
    Private wbService As New ABCDService.Service

#End Region

#Region "New Form."

    ''' <summary>
    ''' New with no param.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        With tb_user_code
            .ImeMode = Windows.Forms.ImeMode.Disable
        End With
        With tb_password
            .ImeMode = Windows.Forms.ImeMode.Disable
        End With
        Me.wbService.Url = ABCDConst.STRING_URL
        Me.wbService.Timeout = ABCDConst.STRING_TIMEOUT

        '' trust all certificates
        ServicePointManager.ServerCertificateValidationCallback = AddressOf ABCDCommon.AcceptAllCertifications
    End Sub

#End Region

#Region "Event Form."

    ''' <summary>
    ''' Event key down text box User ID.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_user_code_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_user_code.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CommonLoginSystem()
        End If
    End Sub

    ''' <summary>
    ''' Event key down text box Password.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_password_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_password.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CommonLoginSystem()
        End If
    End Sub

    ''' <summary>
    ''' Event click button Exit.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Event click button Login.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub b_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b_login.Click
        Call CommonLoginSystem()
    End Sub

    ''' <summary>
    ''' Event leave User ID.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_user_code_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_user_code.Leave
        If Not tb_password.Text.Equals("") Then
            tb_password.Focus()
            tb_password.SelectAll()
        End If
    End Sub

#End Region

#Region "Function Form."

    ''' <summary>
    ''' Function  login system.
    ''' </summary>
    ''' <param name="userCode"></param>
    ''' <param name="userPassword"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LoginSystem(ByVal userCode As String, _
                                 ByVal userPassword As String) As Integer
        Try
            Dim ds As DataSet = wbService.GetUserInfoByID(userCode, ABCDCommon.MODE_LOGIN)
            If ds.Tables(0).Rows.Count = 0 Then
                Dim scrError As New frm_MSG001(Messages.ERR003, "ERR003")
                If scrError.ShowDialog = Windows.Forms.DialogResult.OK Then
                    scrError.Close()
                    Return 1
                End If
            End If
            If ds.Tables(0).Rows.Count = 1 Then
                ABCDCommon.UserId = Trim(ds.Tables(0).Rows(0)("USER_ID").ToString)
                ABCDCommon.UserName = Trim(ds.Tables(0).Rows(0)("USER_NM").ToString)
                ABCDCommon.Password = Trim(ds.Tables(0).Rows(0)("USER_PWD").ToString)
                ABCDCommon.Auhtority = Trim(ds.Tables(0).Rows(0)("AUTHORITY").ToString)

                '' decrypt data after get.
                Dim decryptData As New ABCDCommon.EncryptDecryptVB("password")
                Dim comparePW As String = decryptData.EncryptData(userPassword)

                'CHG START AIT)CUONGTK 20160229 EXCEPTION MAXLENGTH PASSWORD
                If Not ABCDCommon.Password.Equals(comparePW.Substring(0, 6)) Then
                    Dim scrError As New frm_MSG001(Messages.ERR004, "ERR004")
                    If scrError.ShowDialog = Windows.Forms.DialogResult.OK Then
                        scrError.Close()
                        Return 2
                    End If
                End If
                'CHG E N D AIT)CUONGTK 20160229 EXCEPTION MAXLENGTH PASSWORD
                Return 3
            End If
        Catch ex As Exception
            Dim frm As New frm_MSG001(ex.Message, "ERR9004")
            frm.ShowDialog()
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Function login system.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CommonLoginSystem()
        If tb_user_code.Text.Equals("") Then
            Dim frm As New frm_MSG001(Messages.ERR001, "ERR001")
            frm.ShowDialog()
            Return
        End If
        If tb_password.Text.Equals("") Then
            Dim frm As New frm_MSG001(Messages.ERR002, "ERR002")
            frm.ShowDialog()
            Return
        End If
        Dim userCode As String = tb_user_code.Text
        Dim userPassword As String = tb_password.Text
        Dim rsLogin As Integer = LoginSystem(userCode, userPassword)
        If rsLogin = 1 Then
            tb_user_code.Focus()
            tb_user_code.SelectAll()
            Return
        End If
        If rsLogin = 2 Then
            tb_password.Focus()
            tb_password.SelectAll()
            Return
        End If
        If rsLogin = 3 Then
            Dim userAuthority As String = ABCDCommon.Auhtority

            If "036".Equals(tb_user_code.Text.Trim) Then
                ABCDCommon.ComCode = "ABCD"
            End If

            Dim scrMnu001 As New frm_MNU001(Me, userAuthority)
            scrMnu001.Show()
            Me.Hide()
        End If
    End Sub

#End Region

End Class