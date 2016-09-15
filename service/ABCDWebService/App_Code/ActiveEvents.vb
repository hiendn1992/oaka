''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* ÉVÉXÉeÉÄñºÅFABCD_Barcode_System
''* ÉNÉâÉXñº  ÅFABCDWebService
''* èàóùäTóv  ÅFBCí[ññÇÃóvãÅÇÊÇËÅAã∆ñ±ÇçsÇ§
''*********************************************************
''* óöóÅF
''* NO   ì˙ït   Ver  çXêVé“          ì‡óe
#Region "ïFç™èCê≥óöó"
''* 1 14/12/12 1.00  AIT)cuongnc     New
#End Region
''*********************************************************
Imports System.Data
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text
Imports System

Namespace jp.co.ait.WebService

    Public Class ActiveEvents
        Inherits ABCDWebBase

#Region "Constant/Variable"
        Private Const FOR_CMN_01 As String = "yyyyMMdd"
#End Region

#Region "New/Initialize"

        ''' <summary>
        ''' New active event
        ''' </summary>
        ''' <param name="userID"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal userID As String)
            Me.UserId = userID
        End Sub

#End Region

#Region "Get data MASTER"

        ''' <summary>
        ''' Get data in table USER_MASTER_MS to check exist
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataInUserMasterMS(ByVal userId As String) As DataSet
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim dataSet As DataSet = Nothing
            Try
                webDbManager.Connect() '// Open connect DB
                '// Create content SQL query
                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("   * ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   USER_MASTER_MS ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append(" AND ")
                sqlBuilder.Append("   USER_ID = LTRIM(RTRIM(@P1)) ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", userId)
                '// Return for dataSet
                dataSet = webDbManager.ExecuteDataSetFill
                Return dataSet
            Catch ex As Exception
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' Function check password
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <param name="passWord"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function UserConfirmProccess(ByVal userId As String, _
                                             ByVal passWord As String) As Integer
            Dim pw As String = ""
            Dim dt As DataTable = GetDataInUserMasterMS(userId).Tables(0)
            If dt.Rows.Count = 0 Then
                Return 1
            Else
                pw = dt.Rows(0)("USER_PWD").ToString
                If pw.Equals(passWord) Then
                    Return 0
                Else
                    Return 2
                End If
            End If
        End Function

        ''' <summary>
        ''' Get data login to login screen
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <param name="passWord"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserInfoProccess(ByVal userId As String, _
                                            ByVal passWord As String) As Integer
            Dim rs As Integer = UserConfirmProccess(userId, passWord)
            If rs = 1 Then
                Return 1
            End If
            If rs = 2 Then
                Return 2
            End If
            Return 0
        End Function

        ''' <summary>
        ''' GetNextHistoryNo
        ''' </summary>
        ''' <param name="barcodeNo">barcodeNo</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNextHistoryNo(ByVal barcodeNo As String) As Int16
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)
                sqlBuf.Append(" SELECT COUNT(*)")
                sqlBuf.Append("   FROM WH_HIST_INFO_TR TR")
                sqlBuf.Append("  WHERE TR.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim row As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                If row > 0 Then
                    Return row + 1
                Else
                    Return 1
                End If
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try

        End Function

        ''' <summary>
        ''' Check User ID exist
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CheckUserExistProccess(ByVal userId As String) As Integer
            Dim dataSet As DataSet = GetDataInUserMasterMS(userId)
            Return dataSet.Tables(0).Rows.Count
        End Function

        ''' <summary>
        ''' GetWarehouseStatusTr
        ''' Created 2015/01/13 toannn
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWarehouseStatusTr() As DataSet

            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT WS.* ")
                sql.Append(" FROM WH_STATUS_TR AS WS ")

                dbm.SetCommandText(sql.ToString)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

#End Region

#Region "BATCH 001 User Process"

        ''' <summary>
        ''' Change User Password[MSS002]
        ''' </summary>
        ''' <param name="userid"></param>
        ''' <param name="password"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ChangeUserPassword(ByVal userId As String, ByVal passWord As String) As Integer
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim updateNo As Integer = 0
            Try
                webDbManager.Connect() '// Open connect DB
                '// Create content SQL query
                sqlBuilder.Append(" UPDATE ")
                sqlBuilder.Append("   USER_MASTER_MS ")
                sqlBuilder.Append(" SET ")
                sqlBuilder.Append("   USER_PWD = @P2, ")
                sqlBuilder.Append("   UPD_USER_CD = @P1, ")
                sqlBuilder.Append("   UPD_DT = GETDATE() ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   USER_ID = @P1 ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", userId)
                webDbManager.AddParameterChar("P2", passWord)
                '// Return for updateNo
                updateNo = webDbManager.ExecuteNonQuery
                webDbManager.Commit() '// Commit proccess DB
                webDbManager.Disconnect()
                webDbManager.Dispose()
                Return updateNo
            Catch ex As Exception
                webDbManager.Rollback() '// Rollback proccess DB error
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' Login User[LGN001]
        ''' </summary>
        ''' <param name="userCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserInfoByID(ByVal userCode As String) As DataSet
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim dataSet As DataSet = Nothing
            Try
                webDbManager.Connect() '// Open connect DB
                '// Create content SQL query
                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("   * ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   USER_MASTER_MS ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append(" AND ")
                sqlBuilder.Append("   USER_ID = LTRIM(RTRIM(@P1)) ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", userCode)
                '// Return for dataSet
                dataSet = webDbManager.ExecuteDataSetFill
                webDbManager.Disconnect()
                webDbManager.Dispose()
                Return dataSet
            Catch ex As Exception
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' User Master Setup[MSS001 - Add]
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <param name="passWord"></param>
        ''' <param name="userName"></param>
        ''' <param name="authUser"></param>
        ''' <param name="remUser"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertUserInfo(ByVal userId As String, ByVal passWord As String, ByVal userName As String, ByVal authUser As Integer, ByVal remUser As String, ByVal loginId As String) As Integer
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim insertNo As Integer = 0
            Try
                webDbManager.Connect() '// Open connect DB
                '// Check user exist in USER_MASTER_MS
                If CheckUserExistProccess(userId) = 1 Then
                    webDbManager.Disconnect()
                    webDbManager.Dispose()
                    Return 2
                End If
                '// Create content SQL query
                sqlBuilder.Append(" INSERT INTO ")
                sqlBuilder.Append("   USER_MASTER_MS ")
                sqlBuilder.Append("   ( ")
                sqlBuilder.Append("     USER_ID, ")
                sqlBuilder.Append("     USER_NM, ")
                sqlBuilder.Append("     USER_PWD, ")
                sqlBuilder.Append("     AUTHORITY, ")
                If Not "".Equals(remUser) Then
                    sqlBuilder.Append("     REM, ")
                End If
                sqlBuilder.Append("     REG_USER_CD, ")
                sqlBuilder.Append("     REG_DT, ")
                sqlBuilder.Append("     UPD_USER_CD, ")
                sqlBuilder.Append("     UPD_DT ")
                sqlBuilder.Append("   ) ")
                sqlBuilder.Append(" VALUES ")
                sqlBuilder.Append("   ( ")
                sqlBuilder.Append("     @P1, ")
                sqlBuilder.Append("     @P2, ")
                sqlBuilder.Append("     @P3, ")
                sqlBuilder.Append("     @P4, ")
                If Not "".Equals(remUser) Then
                    sqlBuilder.Append("     @P5, ")
                End If
                sqlBuilder.Append("     @P6, ")
                sqlBuilder.Append("     GETDATE(), ")
                sqlBuilder.Append("     @P6, ")
                sqlBuilder.Append("     GETDATE() ")
                sqlBuilder.Append("   ) ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", userId)
                webDbManager.AddParameterChar("P2", userName)
                webDbManager.AddParameterChar("P3", passWord)
                webDbManager.AddParameter("P4", authUser)
                If Not "".Equals(remUser) Then
                    webDbManager.AddParameterChar("P5", remUser)
                End If
                webDbManager.AddParameterChar("P6", loginId)
                '// Return for insertNo
                insertNo = webDbManager.ExecuteNonQuery
                webDbManager.Commit() '// Commit proccess DB
                webDbManager.Disconnect()
                webDbManager.Dispose()
                Return insertNo
            Catch ex As Exception
                webDbManager.Rollback() '// Rollback proccess DB error
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' User Master Setup[MSS001 - Change]
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <param name="passWord"></param>
        ''' <param name="userName"></param>
        ''' <param name="authUser"></param>
        ''' <param name="remUser"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateUserInfo(ByVal userId As String, ByVal passWord As String, ByVal userName As String, ByVal authUser As Integer, ByVal remUser As String, ByVal loginId As String) As Integer
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim updateNo As Integer = 0
            Try
                webDbManager.Connect() '// Open connect DB
                '// Create content SQL query
                sqlBuilder.Append(" UPDATE ")
                sqlBuilder.Append("   USER_MASTER_MS ")
                sqlBuilder.Append(" SET ")
                sqlBuilder.Append("   USER_NM = @P2, ")
                sqlBuilder.Append("   USER_PWD = @P3, ")
                sqlBuilder.Append("   AUTHORITY = @P4, ")
                If Not "".Equals(remUser) Then
                    sqlBuilder.Append("   REM = @P5, ")
                End If
                sqlBuilder.Append("   UPD_USER_CD = @P6, ")
                sqlBuilder.Append("   UPD_DT = GETDATE() ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   USER_ID = @P1 ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", userId)
                webDbManager.AddParameterChar("P2", userName)
                webDbManager.AddParameterChar("P3", passWord)
                webDbManager.AddParameter("P4", authUser)
                If Not "".Equals(remUser) Then
                    webDbManager.AddParameterChar("P5", remUser)
                End If
                webDbManager.AddParameterChar("P6", loginId)
                '// Return for updateNo
                updateNo = webDbManager.ExecuteNonQuery
                webDbManager.Commit() '// Commit proccess DB
                webDbManager.Disconnect()
                webDbManager.Dispose()
                Return updateNo
            Catch ex As Exception
                webDbManager.Rollback() '// Rollback proccess DB error
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' User Master Setup[MSS001 - Delete]
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteUserInfo(ByVal userId As String, ByVal loginId As String) As Integer
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim deleteNo As Integer = 0
            Try
                webDbManager.Connect() '// Open connect DB
                '// Create content SQL query
                sqlBuilder.Append(" DELETE FROM ")
                sqlBuilder.Append("   USER_MASTER_MS ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   USER_ID = @P1 ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", userId)
                '// Return for deleteNo
                deleteNo = webDbManager.ExecuteNonQuery
                webDbManager.Commit() '// Commit proccess DB
                webDbManager.Disconnect()
                webDbManager.Dispose()
                Return deleteNo
            Catch ex As Exception
                webDbManager.Rollback() '// Rollback proccess DB error
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' Get info user by: id, rem, authority.
        ''' </summary>
        ''' <param name="_userId"></param>
        ''' <param name="_remark"></param>
        ''' <param name="_authority"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UserInquiry(ByVal _userId As String, _
                                    ByVal _remark As String, _
                                    ByVal _authority As Integer) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing
            Try
                dbm.Connect()

                Dim ret As Integer = 0

                sqlBuf.Append("SELECT * ")
                sqlBuf.Append("FROM   USER_MASTER_MS ")
                sqlBuf.Append("WHERE  1=1 ")
                If _userId.Equals("") = False Then
                    sqlBuf.Append(" AND USER_ID LIKE @P1 ")
                End If
                If _remark.Equals("") = False Then
                    sqlBuf.Append(" AND REM LIKE @P2 ")
                End If
                If _authority <> 0 Then
                    sqlBuf.Append(" AND AUTHORITY = @P3 ")
                End If

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", ("%" & _userId & "%"))
                dbm.AddParameterChar("P2", ("%" & _remark & "%"))
                dbm.AddParameter("P3", _authority)

                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
#End Region

#Region "Batch 002 Product Process."

        ''' <summary>
        ''' Get list WO info by WONo not join ITEM_MASTER_MS.
        ''' </summary>
        ''' <param name="woCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWOInfoByWONo(ByVal woCode As String) As DataSet
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim ds As DataSet = Nothing

            Try
                dbm.Connect()

                Dim query As String = ""
                query = query & "SELECT A.* "
                query = query & "FROM   PRODUCT_INFO_TR AS A "
                query = query & "WHERE  1 = 1 "
                query = query & "  AND  WO_NO = @P1"
                sqlBuf.Append(query)

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", woCode)
                ds = dbm.ExecuteDataSetFill

                Return ds
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Get list WO info by WONo join ITEM_MASTER_MS.
        ''' </summary>
        ''' <param name="woCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWOInfoByWONoJoinItem(ByVal woCode As String) As DataSet
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim ds As DataSet = Nothing

            Try
                dbm.Connect()

                Dim query As String = ""
                query = query & "SELECT A.*, B.ITEM_NM "
                query = query & "FROM   PRODUCT_INFO_TR AS A, ITEM_MASTER_MS AS B "
                query = query & "WHERE  1 = 1 "
                query = query & "  AND  A.ITEM_CD = B.ITEM_CD "
                query = query & "  AND  WO_NO = @P1 "
                sqlBuf.Append(query)

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", woCode)
                ds = dbm.ExecuteDataSetFill

                Return ds
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Insert info W/O.
        ''' </summary>
        ''' <param name="woNoList"></param>
        ''' <param name="woDateList"></param>
        ''' <param name="itemCdList"></param>
        ''' <param name="proQtyList"></param>
        ''' <param name="qtyPerBoxList"></param>
        ''' <param name="totalBoxList"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertWOInfo(ByVal woNoList As List(Of String), ByVal woDateList As List(Of String), _
                                     ByVal itemCdList As List(Of String), ByVal proQtyList As List(Of String), _
                                     ByVal qtyPerBoxList As List(Of String), ByVal totalBoxList As List(Of String), _
                                     ByVal loginId As String) As Integer
            '// WriteStartLog()
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder
            Dim num As Integer = 0
            Try
                dbm.Connect()
                sql.Append("INSERT PRODUCT_INFO_TR")
                sql.Append("(")
                sql.Append("WO_NO,")
                sql.Append("ITEM_CD,")
                sql.Append("PRODUCT_QTY,")
                sql.Append("REMAIN_QTY,")
                sql.Append("LOT_NO,")
                sql.Append("WO_DT,")
                sql.Append("TOTAL_BOX,")
                sql.Append("QTY_PER_BOX,")
                sql.Append("ISSUE_FLG,")
                sql.Append("REGIST_USER_CD,")
                sql.Append("REGIST_DT,")
                sql.Append("UPD_USER_CD,")
                sql.Append("UPD_DT")
                sql.Append(")")
                If woNoList.Count = 1 Then
                    sql.Append("VALUES")
                    sql.Append("(")
                    sql.Append("@P1,")
                    sql.Append("@P2,")
                    sql.Append("@P3,")
                    sql.Append("@P3,")
                    sql.Append("@P4,")
                    sql.Append("@P5,")
                    sql.Append("@P6,")
                    sql.Append("@P7,")
                    sql.Append("0,")
                    sql.Append("@P8,")
                    sql.Append("GETDATE(),")
                    sql.Append("@P8,")
                    sql.Append("GETDATE()")
                    sql.Append(")")
                    dbm.SetCommandText(sql.ToString)
                    dbm.AddParameterChar("P1", woNoList(0))
                    dbm.AddParameterChar("P2", itemCdList(0))
                    dbm.AddParameter("P3", (Integer.Parse(proQtyList(0))))
                    dbm.AddParameterChar("P4", (woNoList(0).Substring(5, 5) & "-" & DateTime.Parse(woDateList(0)).ToString("yyyyMMdd")))
                    dbm.AddParameter("P5", DateTime.Parse(woDateList(0)))
                    dbm.AddParameter("P6", Integer.Parse(totalBoxList(0)))
                    dbm.AddParameter("P7", Integer.Parse(qtyPerBoxList(0)))
                    dbm.AddParameterChar("P8", loginId)
                    num = dbm.ExecuteNonQuery
                Else
                    If woNoList.Count > 0 Then
                        For i As Integer = 0 To woNoList.Count - 1 Step 1
                            If i <> 0 Then
                                sql.Append(" UNION ALL ")
                            End If
                            sql.Append(" SELECT ")
                            sql.AppendFormat(" '{0}', ", woNoList(i))
                            sql.AppendFormat(" '{0}', ", Trim(itemCdList(i)))
                            sql.AppendFormat(" {0}, ", Integer.Parse(proQtyList(i)))
                            sql.AppendFormat(" {0}, ", Integer.Parse(proQtyList(i)))
                            sql.AppendFormat(" '{0}', ", Trim(woNoList(i).Substring(5, 5) & "-" & DateTime.Parse(woDateList(i)).ToString("yyyyMMdd")))
                            sql.AppendFormat(" CONVERT(DATETIME, '{0}'), ", woDateList(i))
                            sql.AppendFormat(" {0}, ", Integer.Parse(totalBoxList(i)))
                            sql.AppendFormat(" {0}, ", Integer.Parse(qtyPerBoxList(i)))
                            sql.Append(" 0, ")
                            sql.AppendFormat(" '{0}', ", loginId)
                            sql.Append(" GETDATE(), ")
                            sql.AppendFormat(" '{0}', ", loginId)
                            sql.Append(" GETDATE() ")
                        Next
                        dbm.SetCommandText(sql.ToString)
                        num = dbm.ExecuteNonQuery
                    End If
                End If
                dbm.Commit()
                Return num
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function UpdateWOInfo(ByVal woCode As String, _
                                     ByVal woDate As Date, _
                                     ByVal itemCode As String, _
                                     ByVal prodQty As Integer, _
                                     ByVal qtyPerBox As Integer, _
                                     ByVal totalBox As Integer, _
                                     ByVal loginCode As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                dbm.Connect()

                Dim update As String = ""
                update = update & "UPDATE PRODUCT_INFO_TR "
                update = update & "SET "
                update = update & "WO_DT = @P2, "
                update = update & "LOT_NO = @P3, "
                update = update & "ITEM_CD = @P4, "
                update = update & "PRODUCT_QTY = @P5, "
                update = update & "REMAIN_QTY = @P5, "
                update = update & "TOTAL_BOX = @P6, "
                update = update & "QTY_PER_BOX = @P7, "
                update = update & "UPD_USER_CD = @P8, "
                update = update & "UPD_DT = GETDATE() "
                update = update & "WHERE "
                update = update & "WO_NO = @P1"
                sqlBuf.Append(update)

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", woCode)
                dbm.AddParameter("P2", woDate)
                dbm.AddParameterChar("P3", (woCode.Substring(5, 5) & "-" & woDate.ToString("yyyyMMdd")))
                dbm.AddParameterChar("P4", itemCode)
                dbm.AddParameter("P5", prodQty)
                dbm.AddParameter("P6", totalBox)
                dbm.AddParameter("P7", qtyPerBox)
                dbm.AddParameterChar("P8", loginCode)

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function DeleteWOInfo(ByVal woCode As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                dbm.Connect()

                Dim delete As String = ""
                delete = delete & "DELETE FROM PRODUCT_INFO_TR "
                delete = delete & "WHERE WO_NO = @P1"
                sqlBuf.Append(delete)

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", woCode)

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        'Public Function ProductInquiry(ByVal sql As String) As Integer
        '    '// WriteStartLog()

        '    Dim dbm As New ABCDWebDBManager(Me.UserId)
        '    Dim row As Integer

        '    Try
        '        dbm.Connect()
        '        dbm.SetCommandText(sql)

        '        row = dbm.ExecuteNonQuery()
        '        dbm.Commit()
        '        Return row
        '    Catch ex As Exception
        '        dbm.Rollback()
        '        WriteErrorLog(ex.Message)
        '        Throw ex
        '    Finally
        '        dbm.Disconnect()
        '        dbm.Dispose()
        '        '// WriteEndLog()
        '    End Try
        'End Function

        ''' <summary>
        ''' Search PRODUCT_INFO_TR info
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <param name="woNo"></param>
        ''' <param name="woDateFrom">woDateFrom = Date.MinValue : Ignore condition</param>
        ''' <param name="woDateTo">woDateTo = Date.MinValue : Ignore condition</param>
        ''' <param name="productQuantity">productQuantity = -1 : Ignore condition</param>
        ''' <param name="totalBox">totalBox = -1 : Ignore condition</param>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Public Function GetWOInfoList(ByVal itemCode As String, _
                                        ByVal woNo As String, _
                                        ByVal woDateFrom As Date, _
                                        ByVal woDateTo As Date, _
                                        ByVal productQuantity As Integer, _
                                        ByVal totalBox As Integer, _
                                        ByVal issueFlag As Integer) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT PD.*, IT.ITEM_NM ")
                sql.Append(" FROM PRODUCT_INFO_TR AS PD ")
                sql.Append(" LEFT JOIN ITEM_MASTER_MS AS IT ")
                sql.Append(" ON PD.ITEM_CD = IT.ITEM_CD ")
                sql.Append(" WHERE  1 = 1")
                If issueFlag < 2 Then
                    sql.Append(" AND PD.ISSUE_FLG = @P0")
                End If

                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sql.Append(" AND  PD.ITEM_CD = @P1")
                End If

                If Not String.IsNullOrEmpty(Trim(woNo)) Then
                    sql.Append(" AND  PD.WO_NO = @P2")
                End If

                If Not Date.MinValue.Equals(woDateFrom) Then
                    sql.Append(" AND  CONVERT(varchar(8),PD.WO_DT,112) >= @P3")
                End If

                If Not Date.MinValue.Equals(woDateTo) Then
                    sql.Append(" AND  CONVERT(varchar(8),PD.WO_DT,112) <= @P4")
                End If

                If productQuantity >= 0 Then
                    sql.Append(" AND  PD.PRODUCT_QTY = @P5")
                End If

                If totalBox >= 0 Then
                    sql.Append(" AND  PD.TOTAL_BOX = @P6")
                End If

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P0", issueFlag)
                dbm.AddParameterChar("P1", itemCode)
                dbm.AddParameterChar("P2", woNo)
                dbm.AddParameterChar("P3", woDateFrom.ToString("yyyyMMdd"))
                dbm.AddParameterChar("P4", woDateTo.ToString("yyyyMMdd"))
                dbm.AddParameterChar("P5", productQuantity)
                dbm.AddParameterChar("P6", totalBox)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function UpdateIssueFlag(ByVal woNo As String, _
                                                                            ByVal issueFlag As Integer) As Integer
            '// WriteStartLog()
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                Dim ret As Integer = 0

                sql.Append("UPDATE PRODUCT_INFO_TR ")
                sql.AppendFormat("SET ISSUE_FLG = '{0}' ", issueFlag)
                sql.AppendFormat("WHERE WO_NO = '{0}' ", woNo)

                dbm.SetCommandText(sql.ToString)
                ret = dbm.ExecuteNonQuery
                dbm.Commit()
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function UpdateIssueFlagToString(ByVal woNo As String, _
                                                                            ByVal issueFlag As Integer) As String
            Dim sql As New StringBuilder
            sql.Append("UPDATE PRODUCT_INFO_TR ")
            sql.AppendFormat("SET ISSUE_FLG = {0} ", issueFlag)
            sql.AppendFormat("WHERE WO_NO = '{0}' ", woNo)

            Return sql.ToString
        End Function
#End Region

#Region "BAT003_SetRackFGProcess"
        ''' <summary>
        ''' ChkRackNoExistProcess 
        ''' </summary>
        ''' <param name="rackNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkRackNoExistProcess(ByVal rackNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.RACK_CD) ")
                sqlBuf1.Append(" FROM RACK_MASTER_MS AS MS ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append(" MS.RACK_CD = @P1 ")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", rackNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ChkBarcodeExistSelectedRack
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>cuongnc</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkBarcodeExistSelectedRack(ByVal barcodeNo As String, ByVal rackNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check exist barcode in Warehouse W900
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf1.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf1.Append("  WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf1.Append("    AND TR.WH_CD = 'W830'")
                ''<<20150204 Add condition Rack_cd = null
                sqlBuf1.Append("    AND TR.RACK_CD IS NULL")
                sqlBuf1.Append("    AND MS.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "3"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (2) : check exist barcode in warehouse product
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf2 As New StringBuilder(150)
                sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf2.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf2.Append("  WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf2.Append("    AND MS.BC_NO = @P1")
                sqlBuf2.Append("    AND MS.ITEM_CD = TR.ITEM_CD")
                sqlBuf2.Append("    AND TR.RACK_CD = @P2")

                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)
                dbm.AddParameterChar("P2", rackNo)

                Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result2 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append("   FROM ITEM_MASTER_MS MST, ITEM_DTL_MS DTL")
                sqlBuf3.Append("  WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append("    AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' SetRackToW830
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="rackNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetRackToW830(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackNo As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET  TR.WH_CD = 'W830'")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                sqlBuf.Append("     ,TR.RACK_CD = @P4")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = @P3")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                ' update ITEM_DTL_MS
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET  MS.SHIP_FLG = '0'")
                sqlBuf.Append("     ,MS.UPD_USER_CD = @P5")
                sqlBuf.Append("     ,MS.UPD_DT = getdate()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P6")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = @P7")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", itemCode)
                dbm.AddParameter("P4", rackNo)
                dbm.AddParameter("P5", Me.UserId)
                dbm.AddParameter("P6", barcodeNo)
                dbm.AddParameter("P7", itemCode)
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,RACK_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P8")
                sqlBuf.Append(" ,getdate()")

                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 11)
                dbm.AddParameter("P4", "W830")
                dbm.AddParameter("P5", rackNo)
                dbm.AddParameter("P6", itemCode)
                dbm.AddParameter("P7", UserId)
                dbm.AddParameter("P8", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()

                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BAT004_ImportQCProcess"

        ''' <summary>
        ''' CheckBarcodeExistProcess
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>cuongnc</author>
        ''' <returns>DataSet result</returns>
        Public Function CheckBarcodeExistProcess(ByVal barcodeNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check exist barcode in Warehouse W900
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf1.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf1.Append("  WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf1.Append("    AND TR.WH_CD = 'W900'")
                sqlBuf1.Append("    AND MS.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (2) : check exist barcode in warehouse product
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf2 As New StringBuilder(150)
                sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf2.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf2.Append("  WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf2.Append("    AND TR.WH_CD = 'MOLD'")
                sqlBuf2.Append("    AND MS.ITEM_CD = TR.ITEM_CD")
                sqlBuf2.Append("    AND MS.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result2 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "3"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append("   FROM ITEM_MASTER_MS MST, ITEM_DTL_MS DTL")
                sqlBuf3.Append("  WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append("    AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count < 1 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ImportBarcodeIntoQC
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ImportBarcodeIntoQC(ByVal barcodeNo As String, ByVal itemCode As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)
                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET TR.WH_CD = 'W900'")
                sqlBuf.Append("     ,TR.RACK_CD = NULL")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.UPD_DT =    GETDATE()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.ITEM_CD = @P3")

                ' update ITEM_DTL_MS                
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET MS.SHIP_FLG = '0'")
                sqlBuf.Append("    ,MS.UPD_USER_CD = @P4")
                sqlBuf.Append("    ,MS.UPD_DT = GETDATE()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P5")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.ITEM_CD = @P6")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", itemCode)
                dbm.AddParameter("P4", Me.UserId)
                dbm.AddParameter("P5", barcodeNo)
                dbm.AddParameter("P6", itemCode)
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                Dim rackNo As String = "" 'Import into QC --> rackNo= null
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 1)
                dbm.AddParameter("P4", "W900")
                dbm.AddParameter("P5", itemCode)
                dbm.AddParameter("P6", UserId)
                dbm.AddParameter("P7", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BAT005_StockMoveFGProcess"

        ''' <summary>
        ''' ChkStkMvRackNoExistProcess 
        ''' </summary>
        ''' <param name="rackNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStkMvRackNoExistProcess(ByVal rackNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.RACK_CD) ")
                sqlBuf1.Append(" FROM RACK_MASTER_MS AS MS ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append(" MS.RACK_CD = @P1 ")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", rackNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ChkStkMvBarcodeExistDestRackNo
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="rackNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStkMvBarcodeExistDestRackNo(ByVal barcodeNo As String, ByVal rackNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check exist barcode 
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.BC_NO)")
                sqlBuf1.Append("   FROM WH_INFO_TR AS TR")
                sqlBuf1.Append("  WHERE ")
                sqlBuf1.Append("        TR.BC_NO = @P1")
                sqlBuf1.Append("    AND TR.RACK_CD = @P2")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)
                dbm.AddParameterChar("P2", rackNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append("   FROM ITEM_MASTER_MS MST, ITEM_DTL_MS DTL")
                sqlBuf3.Append("  WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append("    AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' StockMoveW830
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="rackNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StockMoveW830(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackNo As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>

            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET  TR.RACK_CD = @P1")
                sqlBuf.Append("     ,TR.ITEM_CD = @P2")
                '<<20150817 Phungntm modify update WH_CD = W830 after stock move
                sqlBuf.Append("     ,TR.WH_CD = @P7")
                '>>20150817 Phungntm
                sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P3")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P4")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                ' update ITEM_DTL_MS
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET  MS.SHIP_FLG = '0'")
                sqlBuf.Append("     ,MS.UPD_USER_CD = @P5")
                sqlBuf.Append("     ,MS.UPD_DT = getdate()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P6")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", rackNo)
                dbm.AddParameter("P2", itemCode)
                dbm.AddParameter("P3", Me.UserId)
                dbm.AddParameter("P4", barcodeNo)
                dbm.AddParameter("P5", Me.UserId)
                dbm.AddParameter("P6", barcodeNo)
                '<<20150817 Phungntm modify update WH_CD = W830 after stock move
                dbm.AddParameter("P7", "W830")
                '>>
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,RACK_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P8")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 8)
                dbm.AddParameter("P4", "W830")
                dbm.AddParameter("P5", rackNo)
                dbm.AddParameter("P6", itemCode)
                dbm.AddParameter("P7", UserId)
                dbm.AddParameter("P8", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BAT006_RejectQCProcess"
        ''' <summary>
        ''' CheckRejectBarcodeExistProcess
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function CheckRejectBarcodeExistProcess(ByVal barcodeNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check reject in Warehouse W9902
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf1.Append(" FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf1.Append(" WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf1.Append(" AND MS.BC_NO = @P1")
                sqlBuf1.Append(" AND TR.WH_CD = 'W9902'")
                sqlBuf1.Append(" AND MS.ITEM_CD = TR.ITEM_CD")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (2) : check exist barcode in warehouse W900
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf2 As New StringBuilder(150)
                sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf2.Append(" FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf2.Append(" WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf2.Append(" AND TR.WH_CD = 'W900'")
                sqlBuf2.Append(" AND MS.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result2 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "3"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append(" FROM ITEM_MASTER_MS AS MST, ITEM_DTL_MS AS DTL")
                sqlBuf3.Append(" WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append(" AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count < 1 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' RejectBarcodeIntoW9902
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RejectBarcodeIntoW9902(ByVal barcodeNo As String, ByVal itemCode As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET  TR.WH_CD = 'W9902'")
                sqlBuf.Append("     ,TR.RACK_CD = NULL")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = @P3")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                ' update ITEM_DTL_MS
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET  MS.SHIP_FLG = '0'")
                sqlBuf.Append("     ,MS.UPD_USER_CD = @P4")
                sqlBuf.Append("     ,MS.UPD_DT = getdate()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P5")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = @P6")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", itemCode)

                dbm.AddParameter("P4", Me.UserId)
                dbm.AddParameter("P5", barcodeNo)
                dbm.AddParameter("P6", itemCode)
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                Dim rackNo As String = "" ' Reject into 9902 --> rackNo =null
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If
                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 3)
                dbm.AddParameter("P4", "W9902")
                dbm.AddParameter("P5", itemCode)
                dbm.AddParameter("P6", UserId)
                dbm.AddParameter("P7", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
#End Region

#Region "BAT007_RetrieveQCProcess"

        ''' <summary>
        ''' CheckRetrieveRackCDExistProcess
        ''' </summary>
        ''' <param name="rackCD"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function CheckRetrieveRackCDExistProcess(ByVal rackCD As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : Check import in Warehouse W9902
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.RACK_CD)")
                sqlBuf1.Append(" FROM RACK_MASTER_MS AS MS")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append(" MS.RACK_CD = @P1")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", rackCD)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' CheckRetrieveBarcodeExistSelectedRack
        ''' </summary>
        ''' <param name="rackCD"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function CheckRetrieveBarcodeExistSelectedRack(ByVal barcodeNo As String, ByVal rackCD As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check import in Warehouse 
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf1.Append(" FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf1.Append(" WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf1.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf1.Append(" AND TR.RACK_CD = @P1")
                sqlBuf1.Append(" AND MS.BC_NO = @P2")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", rackCD)
                dbm.AddParameterChar("P2", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "3"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (2) : check exist barcode in warehouse 
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf2 As New StringBuilder(150)
                sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf2.Append(" FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf2.Append(" WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf1.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf2.Append(" AND TR.WH_CD = 'W900'")
                sqlBuf2.Append(" AND MS.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result2 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append(" FROM ITEM_MASTER_MS AS MST, ITEM_DTL_MS AS DTL")
                sqlBuf3.Append(" WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append(" AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count < 1 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' RetrieveBarcodeIntoQC
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RetrieveBarcodeIntoQC(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackCD As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET  TR.WH_CD = 'W900'")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.RACK_CD = NULL")
                sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.BC_NO   = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD   = @P3")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.RACK_CD   = @P4")

                ' update ITEM_DTL_MS
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET  MS.SHIP_FLG = '0'")
                sqlBuf.Append("     ,MS.UPD_USER_CD = @P5")
                sqlBuf.Append("     ,MS.UPD_DT = getdate()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P6")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD   = @P7")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.RACK_CD   = @P8")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", itemCode)
                dbm.AddParameter("P4", rackCD)
                dbm.AddParameter("P5", Me.UserId)
                dbm.AddParameter("P6", barcodeNo)
                dbm.AddParameter("P7", itemCode)
                dbm.AddParameter("P8", rackCD)

                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                rackCD = ""     'Retrieve into QC --> rackCD = NULL
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackCD)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackCD)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,RACK_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P8")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 4)
                dbm.AddParameter("P4", "W900")
                dbm.AddParameter("P5", rackCD)
                dbm.AddParameter("P6", itemCode)
                dbm.AddParameter("P7", UserId)
                dbm.AddParameter("P8", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try

        End Function


#End Region

#Region "BAT008_StocktakingQCProcess"
        ''' <summary>
        ''' ChkStocktkReqDateExist
        ''' </summary>
        ''' <param name="stockReqDate"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStocktkReqDateExist(ByVal stockReqDate As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.STOCK_REQ_DT) ")
                sqlBuf1.Append(" FROM STOCK_REQ_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append(" TR.STOCK_REQ_DT = @P1 ")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", stockReqDate)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ChkStocktkBarcodeExistSelectedReqDate
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStocktkBarcodeExistSelectedReqDate(ByVal barcodeNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check import in Warehouse 
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.BC_NO) ")
                sqlBuf1.Append(" FROM STOCK_REQ_DTL_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                sqlBuf1.Append(" AND RTRIM(TR.ACT_WH_CD) = 'W900' ")
                sqlBuf1.Append(" AND ISNULL(TR.ACT_RACK_CD, 0) = 0 ")
                sqlBuf1.Append(" AND TR.SCAN_FLG = '1' ")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result1 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' StocktakingBarcodeQC
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StocktakingBarcodeQC(ByVal barcodeNo As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Dim dtTable1 As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("WH_CD")
                ds.Tables(0).Columns.Add("RACK_CD")
                ds.Tables(0).Columns.Add("ITEM_CD")
                Dim sqlBuf As New StringBuilder(1000)

                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.BC_NO) ")
                sqlBuf1.Append(" FROM STOCK_REQ_DTL_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                sqlBuf1 = Nothing
                sqlBuf1 = New StringBuilder(150)
                sqlBuf1.Append(" SELECT WH_CD, RACK_CD, ITEM_CD ")
                sqlBuf1.Append(" FROM WH_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()

                If result1 <> 0 Then
                    ' update ITEM_DTL_MS
                    sqlBuf.Append(" UPDATE TR ")
                    sqlBuf.Append(" SET  TR.ACT_WH_CD = 'W900'")
                    sqlBuf.Append("     ,TR.SPEC_FLG = '1'")
                    sqlBuf.Append("     ,TR.SCAN_FLG = '1'")
                    sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                    sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                    sqlBuf.Append(" FROM STOCK_REQ_DTL_INFO_TR AS TR ")
                    sqlBuf.Append(" WHERE TR.BC_NO = @P2")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameter("P1", UserId)
                    dbm.AddParameter("P2", barcodeNo)
                    dbm.ExecuteNonQuery()

                    sqlBuf = Nothing
                Else
                    If dtTable.Rows.Count <> 0 Then
                        ' update WH_INFO_TR
                        sqlBuf = Nothing
                        sqlBuf = New StringBuilder(1000)
                        sqlBuf.Append(" INSERT STOCK_REQ_DTL_INFO_TR ( ")
                        sqlBuf.Append("   BC_NO")
                        sqlBuf.Append("   ,SYS_WH_CD")
                        sqlBuf.Append("   ,SYS_RACK_CD")
                        sqlBuf.Append("   ,ACT_WH_CD")
                        sqlBuf.Append("   ,SPEC_FLG")
                        sqlBuf.Append("   ,SCAN_FLG")
                        sqlBuf.Append("   ,REG_USER_CD")
                        sqlBuf.Append("   ,REG_DT")
                        sqlBuf.Append("   ,UPD_USER_CD")
                        sqlBuf.Append("   ,UPD_DT")
                        sqlBuf.Append(" ) VALUES (")
                        sqlBuf.Append("  @P1")
                        sqlBuf.Append(" ,@P2")
                        sqlBuf.Append(" ,@P3")
                        sqlBuf.Append(" ,@P4")
                        sqlBuf.Append(" ,@P5")
                        sqlBuf.Append(" ,@P6")
                        sqlBuf.Append(" ,@P7")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" ,@P8")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" )")
                        dbm.SetCommandText(sqlBuf.ToString())
                        dbm.AddParameter("P1", barcodeNo)
                        dbm.AddParameter("P2", dtTable.Rows(0).Item("WH_CD").ToString())
                        dbm.AddParameter("P3", dtTable.Rows(0).Item("RACK_CD").ToString())
                        dbm.AddParameter("P4", "W900")
                        dbm.AddParameter("P5", 0)
                        dbm.AddParameter("P6", 1)
                        dbm.AddParameter("P7", UserId)
                        dbm.AddParameter("P8", UserId)
                        dbm.ExecuteNonQuery()

                        sqlBuf = Nothing
                    Else

                        sqlBuf1 = Nothing
                        sqlBuf1 = New StringBuilder(150)
                        sqlBuf1.Append(" SELECT ITEM_CD ")
                        sqlBuf1.Append(" FROM ITEM_DTL_MS  AS TR ")
                        sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                        dbm.SetCommandText(sqlBuf1.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        dtTable1 = dbm.ExecuteDataTableFill()

                        ' update WH_INFO_TR
                        sqlBuf = Nothing
                        sqlBuf = New StringBuilder(1000)
                        sqlBuf.Append(" INSERT STOCK_REQ_DTL_INFO_TR ( ")
                        sqlBuf.Append("   BC_NO")
                        sqlBuf.Append("   ,ACT_WH_CD")
                        sqlBuf.Append("   ,SPEC_FLG")
                        sqlBuf.Append("   ,SCAN_FLG")
                        sqlBuf.Append("   ,REG_USER_CD")
                        sqlBuf.Append("   ,REG_DT")
                        sqlBuf.Append("   ,UPD_USER_CD")
                        sqlBuf.Append("   ,UPD_DT")
                        sqlBuf.Append(" ) VALUES (")
                        sqlBuf.Append("  @P1")
                        sqlBuf.Append(" ,@P2")
                        sqlBuf.Append(" ,@P3")
                        sqlBuf.Append(" ,@P4")
                        sqlBuf.Append(" ,@P5")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" ,@P6")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" )")
                        dbm.SetCommandText(sqlBuf.ToString())
                        dbm.AddParameter("P1", barcodeNo)
                        dbm.AddParameter("P2", "W900")
                        dbm.AddParameter("P3", 0)
                        dbm.AddParameter("P4", 1)
                        dbm.AddParameter("P5", UserId)
                        dbm.AddParameter("P6", UserId)

                        dbm.ExecuteNonQuery()

                        sqlBuf = Nothing
                    End If
                End If

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try

        End Function

#End Region

#Region "BATCH 009 W900 (QC WH)"

        ''' <summary>
        ''' CheckBarcodeImportFGExistProcess
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function CheckBarcodeImportFGExistProcess(ByVal barcodeNo As String, _
                                                         ByVal caseImp As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                Select Case caseImp
                    Case "1"
                        dbm.Connect()
                        ds.Tables.Add()
                        ds.Tables(0).Columns.Add("RESULT")
                        ds.Tables(0).Columns.Add("ITEMCODE")
                        ds.Tables(0).Columns.Add("ITEMNAME")
                        '' (1) : Check exist barcode in Warehouse W900
                        ' strQuery 1  
                        Dim sqlBuf1 As New StringBuilder(150)
                        sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                        sqlBuf1.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                        sqlBuf1.Append("  WHERE MS.BC_NO = TR.BC_NO")
                        sqlBuf1.Append("    AND TR.WH_CD = 'W900'")
                        sqlBuf1.Append("    AND MS.BC_NO = @P1")

                        dbm.SetCommandText(sqlBuf1.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                        ' add result to dataset
                        If result1 = 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "3"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        End If

                        '' (2) : check exist barcode in warehouse product
                        ' clear rows
                        ds.Tables(0).Rows.Clear()
                        ' strQuery 2
                        Dim sqlBuf2 As New StringBuilder(150)
                        sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                        sqlBuf2.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                        sqlBuf2.Append("  WHERE MS.BC_NO = TR.BC_NO")
                        sqlBuf2.Append("    AND MS.BC_NO = @P1")
                        sqlBuf2.Append("    AND TR.WH_CD = 'W830'")

                        dbm.SetCommandText(sqlBuf2.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                        If result2 <> 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "2"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        End If

                        '' (3): get ItemCD & Item Name

                        ' clear rows
                        ds.Tables(0).Rows.Clear()
                        ' strQuery 2
                        Dim sqlBuf3 As New StringBuilder(150)
                        sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                        sqlBuf3.Append("   FROM ITEM_MASTER_MS MST, ITEM_DTL_MS DTL")
                        sqlBuf3.Append("  WHERE MST.ITEM_CD = DTL.ITEM_CD")
                        sqlBuf3.Append("    AND DTL.BC_NO = @P1")

                        dbm.SetCommandText(sqlBuf3.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        dtTable = dbm.ExecuteDataTableFill()
                        If dtTable.Rows.Count < 1 Then
                            ds.Tables(0).Rows.Add.Item(0) = "1"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        Else
                            ds.Tables(0).Rows.Add.Item(0) = "0"
                            ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                            ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                            Return ds
                        End If

                    Case "2" '' Subcon(Gia cong tu ben ngoai).
                        dbm.Connect()

                        ds.Tables.Add()
                        ds.Tables(0).Columns.Add("RESULT")
                        ds.Tables(0).Columns.Add("ITEMCODE")
                        ds.Tables(0).Columns.Add("ITEMNAME")

                        '' (1) : Check exist barcode in MOLD
                        ' strQuery 1  
                        Dim sqlBuf1 As New StringBuilder(150)
                        sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                        sqlBuf1.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                        sqlBuf1.Append("  WHERE MS.BC_NO = TR.BC_NO")
                        sqlBuf1.Append("    AND TR.WH_CD = 'MOLD'")
                        sqlBuf1.Append("    AND MS.BC_NO = @P1")

                        dbm.SetCommandText(sqlBuf1.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                        ' add result to dataset
                        If result1 = 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "3"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        End If

                        '' 2. Check barcode existed in W830.
                        ds.Tables(0).Rows.Clear()

                        Dim sb As New StringBuilder()
                        sb.Append("SELECT COUNT(MS.BC_NO) ")
                        sb.Append("FROM   ITEM_DTL_MS AS MS, ")
                        sb.Append("       WH_INFO_TR AS TR ")
                        sb.Append("WHERE  MS.BC_NO = TR.BC_NO ")
                        sb.Append("  AND  MS.BC_NO = @P1 ")
                        sb.Append("  AND  TR.WH_CD = 'W830' ")

                        dbm.SetCommandText(sb.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        Dim rs As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                        If rs <> 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "2"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        End If

                        '' 3. Get information barcode.
                        ds.Tables(0).Rows.Clear()

                        sb = New StringBuilder()
                        sb.Append("SELECT MST.ITEM_CD, ")
                        sb.Append("       MST.ITEM_NM ")
                        sb.Append("FROM   ITEM_MASTER_MS AS MST, ")
                        sb.Append("       ITEM_DTL_MS AS DTL ")
                        sb.Append("WHERE  MST.ITEM_CD = DTL.ITEM_CD ")
                        sb.Append("  AND  DTL.BC_NO = @P1")

                        dbm.SetCommandText(sb.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        dtTable = Nothing
                        dtTable = dbm.ExecuteDataTableFill()

                        If dtTable.Rows.Count = 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "1"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        ElseIf dtTable.Rows.Count > 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "0"
                            ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                            ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                            Return ds
                        End If

                    Case "3"
                        dbm.Connect()

                        ds.Tables.Add()
                        ds.Tables(0).Columns.Add("RESULT")
                        ds.Tables(0).Columns.Add("ITEMCODE")
                        ds.Tables(0).Columns.Add("ITEMNAME")

                        '' 1. Check barcode existed in W830.
                        ds.Tables(0).Rows.Clear()

                        Dim sb As New StringBuilder()
                        sb.Append("SELECT COUNT(MS.BC_NO) ")
                        sb.Append("FROM   ITEM_DTL_MS AS MS, ")
                        sb.Append("       WH_INFO_TR AS TR ")
                        sb.Append("WHERE  MS.BC_NO = TR.BC_NO ")
                        sb.Append("  AND  MS.BC_NO = @P1 ")
                        sb.Append("  AND  TR.WH_CD = 'W830' ")

                        dbm.SetCommandText(sb.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        Dim rs As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                        If rs <> 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "2"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        End If

                        '' 2. Get information barcode.
                        ds.Tables(0).Rows.Clear()

                        sb = New StringBuilder()
                        sb.Append("SELECT MST.ITEM_CD, ")
                        sb.Append("       MST.ITEM_NM ")
                        sb.Append("FROM   ITEM_MASTER_MS AS MST, ")
                        sb.Append("       ITEM_DTL_MS AS DTL ")
                        sb.Append("WHERE  MST.ITEM_CD = DTL.ITEM_CD ")
                        sb.Append("  AND  DTL.BC_NO = @P1")

                        dbm.SetCommandText(sb.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        dtTable = Nothing
                        dtTable = dbm.ExecuteDataTableFill()

                        If dtTable.Rows.Count = 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "1"
                            ds.Tables(0).Rows(0).Item(1) = Nothing
                            ds.Tables(0).Rows(0).Item(2) = Nothing
                            Return ds
                        ElseIf dtTable.Rows.Count > 0 Then
                            ds.Tables(0).Rows.Add.Item(0) = "0"
                            ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                            ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                            Return ds
                        End If
                End Select
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
            Return ds '//
        End Function

        ''' <summary>
        ''' ImportFGBarcodeIntoQC
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ImportFGBarcodeIntoQC(ByVal barcodeNo As String, _
                                              ByVal caseImp As String, _
                                              ByVal itemCode As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>

            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)
                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET TR.WH_CD = 'W830'")
                sqlBuf.Append("     ,TR.RACK_CD = NULL")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.UPD_DT =    GETDATE()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.ITEM_CD = @P3")

                ' update ITEM_DTL_MS                
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET MS.SHIP_FLG = '0'")
                sqlBuf.Append("    ,MS.UPD_USER_CD = @P4")
                sqlBuf.Append("    ,MS.UPD_DT = GETDATE()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P5")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.ITEM_CD = @P6")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", itemCode)
                dbm.AddParameter("P4", Me.UserId)
                dbm.AddParameter("P5", barcodeNo)
                dbm.AddParameter("P6", itemCode)
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                Dim rackNo As String = "" ''Import from QC -->rackNo = null
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>


                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                If caseImp.Equals("1") Then
                    dbm.AddParameter("P3", 5)
                ElseIf caseImp.Equals("2") Then
                    dbm.AddParameter("P3", 13)
                End If
                dbm.AddParameter("P4", "W830")
                dbm.AddParameter("P5", itemCode)
                dbm.AddParameter("P6", UserId)
                dbm.AddParameter("P7", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try

        End Function

        Public Function ShipmentReturn(ByVal paramBarcode As String) As Boolean
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim ds As DataSet = Nothing
            Dim dt As DataTable = Nothing
            Dim sb As StringBuilder

            '' Information barcode.
            Dim barcode As String = String.Empty
            Dim itemCode As String = String.Empty
            Dim itemName As String = String.Empty

            Try
                dbm.Connect()
                sb = New StringBuilder()

                '' 1. Get information barcode read.
                sb.Append("SELECT A.BC_NO ")
                sb.Append("      ,B.ITEM_CD ")
                sb.Append("      ,C.ITEM_NM ")
                sb.Append("FROM   SHIP_ACT_DTL_INFO_TR AS A ")
                sb.Append("      ,ITEM_DTL_MS AS B ")
                sb.Append("      ,ITEM_MASTER_MS AS C ")
                sb.Append("WHERE  A.BC_NO = B.BC_NO ")
                sb.Append("  AND  B.ITEM_CD = C.ITEM_CD ")
                sb.Append("  AND  A.BC_NO = @P1 ")

                dbm.SetCommandText(sb.ToString())
                dbm.AddParameterChar("P1", paramBarcode)
                dt = dbm.ExecuteDataTableFill()

                If dt.Rows.Count > 0 Then
                    barcode = Trim(dt.Rows(0)("BC_NO").ToString())
                    itemCode = Trim(dt.Rows(0)("ITEM_CD").ToString())
                    itemName = Trim(dt.Rows(0)("ITEM_NM").ToString())

                    '' 2. Insert information into WH_INFO_TR.
                    sb = New StringBuilder()
                    sb.Append("INSERT INTO WH_INFO_TR ")
                    sb.Append("(")
                    sb.Append(" BC_NO")
                    sb.Append(",WH_CD")
                    sb.Append(",ITEM_CD")
                    sb.Append(",REG_USER_CD")
                    sb.Append(",REG_DT")
                    sb.Append(",UPD_USER_CD")
                    sb.Append(",UPD_DT")
                    sb.Append(")")
                    sb.Append(" VALUES ")
                    sb.Append("(")
                    sb.Append(" @P1")
                    sb.Append(",@P2")
                    sb.Append(",@P3")
                    sb.Append(",@P4")
                    sb.Append(",GETDATE()")
                    sb.Append(",@P4")
                    sb.Append(",GETDATE()")
                    sb.Append(")")

                    dbm.SetCommandText(sb.ToString())
                    dbm.AddParameterChar("P1", barcode)
                    dbm.AddParameterChar("P2", "W830")
                    dbm.AddParameterChar("P3", itemCode)
                    dbm.AddParameterChar("P4", UserId)
                    dbm.ExecuteNonQuery()

                    '' 3. Update shipment flag 0.
                    sb = New StringBuilder()
                    sb.Append("UPDATE ITEM_DTL_MS ")
                    sb.Append("SET    SHIP_FLG = 0 ")
                    sb.Append("      ,UPD_USER_CD = @P2 ")
                    sb.Append("      ,UPD_DT = GETDATE() ")
                    sb.Append("WHERE  BC_NO = @P1 ")

                    dbm.SetCommandText(sb.ToString())
                    dbm.AddParameterChar("P1", barcode)
                    dbm.AddParameterChar("P2", UserId)
                    dbm.ExecuteNonQuery()

                    '' 4. Insert row into table WH_HIST_INFO_TR.
                    sb = New StringBuilder()
                    sb.Append("INSERT INTO WH_HIST_INFO_TR ")
                    sb.Append("(")
                    sb.Append(" BC_NO")
                    sb.Append(",HIST_NO")
                    sb.Append(",STATUS_FLG")
                    sb.Append(",WH_CD")
                    sb.Append(",ITEM_CD")
                    sb.Append(",ITEM_NM")
                    sb.Append(",REG_USER_CD")
                    sb.Append(",REG_DT")
                    sb.Append(",UPD_USER_CD")
                    sb.Append(",UPD_DT")
                    sb.Append(")")
                    sb.Append(" VALUES ")
                    sb.Append("(")
                    sb.Append(" @P1")
                    sb.Append(",@P2")
                    sb.Append(",12")
                    sb.Append(",@P3")
                    sb.Append(",@P4")
                    sb.Append(",@P5")
                    sb.Append(",@P6")
                    sb.Append(",GETDATE()")
                    sb.Append(",@P6")
                    sb.Append(",GETDATE()")
                    sb.Append(")")

                    Dim histNo As Integer = GetNextHistoryNo(barcode)

                    dbm.SetCommandText(sb.ToString())
                    dbm.AddParameterChar("P1", barcode)
                    dbm.AddParameter("P2", histNo)
                    dbm.AddParameterChar("P3", "W830")
                    dbm.AddParameterChar("P4", itemCode)
                    dbm.AddParameterChar("P5", itemName)
                    dbm.AddParameterChar("P6", UserId)
                    dbm.ExecuteNonQuery()

                    '' 5. Commit data after process.
                    dbm.Commit()
                    Return True
                End If

                Return False
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                dt.Dispose()
            Finally
                dt.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
            End Try
        End Function

#End Region

#Region "BAT010_RejectFGProcess"

        ''' <summary>
        ''' ChkRejFGBarcodeExistW830 
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkRejFGBarcodeExistW830(ByVal barcodeNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("result")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check reject in Warehouse W830
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf1.Append(" FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf1.Append(" WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf1.Append(" AND MS.ITEM_CD = TR.ITEM_CD")
                sqlBuf1.Append(" AND MS.BC_NO = @P1")
                sqlBuf1.Append(" AND TR.WH_CD = 'W830'")


                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "3"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (2) : check exist barcode in warehouse W900
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf2 As New StringBuilder(150)
                sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf2.Append(" FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf2.Append(" WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf2.Append(" AND MS.BC_NO = @P1")
                sqlBuf1.Append(" AND MS.ITEM_CD = TR.ITEM_CD")
                sqlBuf2.Append(" AND TR.WH_CD = 'W9902'")


                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result2 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append(" FROM ITEM_MASTER_MS AS MST, ITEM_DTL_MS AS DTL")
                sqlBuf3.Append(" WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append(" AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count < 1 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        '''' <summary>
        '''' RejectFGBarcodeIntoW9902
        '''' </summary>
        '''' <param name="barcodeNo"></param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        Public Function RejectFGBarcodeIntoW9902(ByVal barcodeNo As String, ByVal itemCode As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            ''<<20150130 Phungntm start
            Dim dtTable1 As New DataTable
            ''>>
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RACK_CD")
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET  TR.WH_CD = 'W9902'")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                sqlBuf.Append("     ,TR.RACK_CD = NULL ")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                ' update ITEM_DTL_MS
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET  MS.SHIP_FLG = '0'")
                sqlBuf.Append("     ,MS.UPD_USER_CD = @P3")
                sqlBuf.Append("     ,MS.UPD_DT = getdate()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P4")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", Me.UserId)
                dbm.AddParameter("P4", barcodeNo)

                dbm.ExecuteNonQuery()

                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT RACK_CD")
                sqlBuf1.Append(" FROM WH_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                Dim rackNo As String = "" 'Reject into W9902 --> rackNo = null
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    'dtTable1 = dbm.ExecuteDataTableFill()
                    If dtTable1.Rows.Count <> 0 Then
                        rackName = dtTable1.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable1 = dbm.ExecuteDataTableFill()
                    If dtTable1.Rows.Count <> 0 Then
                        itemName = dtTable1.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append("  BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,RACK_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P8")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 6)
                dbm.AddParameter("P4", "W9902")
                dbm.AddParameter("P5", dtTable.Rows(0).Item("RACK_CD").ToString())
                dbm.AddParameter("P6", itemCode)
                dbm.AddParameter("P7", UserId)
                dbm.AddParameter("P8", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>
                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                dtTable.Dispose()
                ''<<20150130 Phungntm start
                dtTable1.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                dtTable.Dispose()
                ''<<20150130 Phungntm start
                dtTable1.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
#End Region

#Region "BAT011_ShipFGProcess"

        ''' <summary>
        ''' ChkShipReqNoExist 
        ''' </summary>
        ''' <param name="shipNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkShipReqNoExist(ByVal shipNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.SHIP_REQ_NO) ")
                sqlBuf1.Append(" FROM SHIP_REQ_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append("     TR.SHIP_REQ_NO = @P1 ")
                sqlBuf1.Append(" AND TR.COMP_FLG = '0' ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", shipNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ChkPalletNoExistShipReqNo 
        ''' </summary>
        ''' <param name="palletNo"></param>
        ''' <param name="shipNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkPalletNoExistShipReqNo(ByVal shipNo As String, ByVal palletNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.SHIP_REQ_NO) ")
                sqlBuf1.Append(" FROM SHIP_REQ_DTL_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append("     TR.SHIP_REQ_NO = @P1 ")
                sqlBuf1.Append(" AND TR.PALLET_NO = @P2 ")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", shipNo)
                dbm.AddParameterChar("P2", palletNo)


                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' CheckBarcodeExistShipReqNo
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>cuongnc</author>
        ''' <returns>DataSet result</returns>
        Public Function CheckBarcodeExistShipReqNo(ByVal barcodeNo As String, ByVal shipNo As String, ByVal palletNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check exist barcode in Warehouse W900
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.BC_NO)")
                sqlBuf1.Append("   FROM SHIP_REQ_DTL_INFO_TR AS TR")
                sqlBuf1.Append("  WHERE TR.BC_NO = @P1")
                sqlBuf1.Append("    AND TR.SHIP_REQ_NO = @P2")
                sqlBuf1.Append("    AND TR.PALLET_NO = @P3")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)
                dbm.AddParameterChar("P2", shipNo)
                dbm.AddParameterChar("P3", palletNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "3"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (2) : check exist barcode in warehouse product
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf2 As New StringBuilder(150)
                sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf2.Append("   FROM ITEM_DTL_MS AS MS, SHIP_REQ_DTL_INFO_TR AS TR")
                sqlBuf2.Append("  WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf2.Append("    AND MS.BC_NO = @P1")
                sqlBuf2.Append("    AND TR.SHIP_REQ_NO = @P2")
                sqlBuf2.Append("    AND TR.PALLET_NO = @P3")
                sqlBuf2.Append("    AND MS.SHIP_FLG = '1'")

                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)
                dbm.AddParameterChar("P2", shipNo)
                dbm.AddParameterChar("P3", palletNo)

                Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result2 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If


                '' (2)' : check exist barcode in warehouse product
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf4 As New StringBuilder(150)
                sqlBuf4.Append(" SELECT COUNT(TR.BC_NO)")
                sqlBuf4.Append("   FROM SHIP_REQ_DTL_INFO_TR AS TR")
                sqlBuf4.Append("  WHERE ")
                sqlBuf4.Append("    TR.BC_NO = @P1")
                sqlBuf4.Append("    AND TR.SHIP_REQ_NO = @P2")
                sqlBuf4.Append("    AND TR.PALLET_NO = @P3")
                sqlBuf4.Append("    AND TR.SCAN_FLG = '1'")

                dbm.SetCommandText(sqlBuf4.ToString())
                dbm.AddParameterChar("P1", barcodeNo)
                dbm.AddParameterChar("P2", shipNo)
                dbm.AddParameterChar("P3", palletNo)

                Dim result4 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result4 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append("   FROM ITEM_MASTER_MS MST, ITEM_DTL_MS DTL")
                sqlBuf3.Append("  WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append("    AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ShipmentBarcode
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="shipNo"></param>
        ''' <param name="palletNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ShipmentBarcode(ByVal barcodeNo As String, ByVal shipNo As String, ByVal palletNo As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet

            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET  TR.SCAN_FLG = '1'")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                sqlBuf.Append(" FROM SHIP_REQ_DTL_INFO_TR AS TR")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.SHIP_REQ_NO = @P3")
                sqlBuf.Append(" AND TR.PALLET_NO = @P4")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", shipNo)
                dbm.AddParameter("P4", palletNo)
                dbm.ExecuteNonQuery()

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BAT012_StocktakingFGProcess"

        ''' <summary>
        ''' ChkStocktFGkReqDateExist 
        ''' </summary>
        ''' <param name="stkReqDate"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStocktFGkReqDateExist(ByVal stkReqDate As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.STOCK_REQ_DT) ")
                sqlBuf1.Append(" FROM STOCK_REQ_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append("     TR.STOCK_REQ_DT = @P1 ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", stkReqDate)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ChkStockFGRackNoExistProcess 
        ''' </summary>
        ''' <param name="rackNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStockFGRackNoExistProcess(ByVal rackNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.RACK_CD) ")
                sqlBuf1.Append(" FROM RACK_MASTER_MS AS MS ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append("     MS.RACK_CD = @P1 ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", rackNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                ElseIf result1 > 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' ChkStockFGValidBarcode 
        ''' </summary>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStockFGValidBarcode(ByVal barcode As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")

                '' (1) : CHECK STOCKTAKING REQUEST NO EXIST
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.BC_NO) ")
                sqlBuf1.Append(" FROM STOCK_REQ_DTL_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE ")
                sqlBuf1.Append("     TR.BC_NO = @P1 ")
                sqlBuf1.Append(" AND TR.ACT_WH_CD = 'W830' ")
                sqlBuf1.Append(" AND TR.SCAN_FLG = '1' ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcode)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                Return ds
            Catch ex As Exception

                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally

                dtTable.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' StocktakingBarcodeFG
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StocktakingBarcodeFG(ByVal barcodeNo As String, ByVal rackNo As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Dim dtTable1 As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("WH_CD")
                ds.Tables(0).Columns.Add("RACK_CD")
                ds.Tables(0).Columns.Add("ITEM_CD")
                Dim sqlBuf As New StringBuilder(1000)

                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.BC_NO) ")
                sqlBuf1.Append(" FROM STOCK_REQ_DTL_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                sqlBuf1 = Nothing
                sqlBuf1 = New StringBuilder(150)
                sqlBuf1.Append(" SELECT WH_CD, RACK_CD, ITEM_CD ")
                sqlBuf1.Append(" FROM WH_INFO_TR AS TR ")
                sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()

                If result1 <> 0 Then
                    ' update ITEM_DTL_MS
                    sqlBuf.Append(" UPDATE TR ")
                    sqlBuf.Append(" SET  TR.ACT_WH_CD = 'W830'")
                    sqlBuf.Append("     ,TR.SPEC_FLG = '1'")
                    sqlBuf.Append("     ,TR.SCAN_FLG = '1'")
                    sqlBuf.Append("     ,TR.ACT_RACK_CD = @P1")
                    sqlBuf.Append("     ,TR.UPD_USER_CD = @P2")
                    sqlBuf.Append("     ,TR.UPD_DT = getdate()")
                    sqlBuf.Append(" FROM STOCK_REQ_DTL_INFO_TR AS TR ")
                    sqlBuf.Append(" WHERE TR.BC_NO = @P3")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameter("P1", rackNo)
                    dbm.AddParameter("P2", UserId)
                    dbm.AddParameter("P3", barcodeNo)
                    dbm.ExecuteNonQuery()
                    sqlBuf = Nothing

                Else
                    If dtTable.Rows.Count <> 0 Then
                        ' update WH_INFO_TR
                        sqlBuf = Nothing
                        sqlBuf = New StringBuilder(1000)
                        sqlBuf.Append(" INSERT STOCK_REQ_DTL_INFO_TR ( ")
                        sqlBuf.Append("   BC_NO")
                        sqlBuf.Append("   ,SYS_WH_CD")
                        sqlBuf.Append("   ,SYS_RACK_CD")
                        sqlBuf.Append("   ,ACT_WH_CD")
                        sqlBuf.Append("   ,ACT_RACK_CD")
                        sqlBuf.Append("   ,SPEC_FLG")
                        sqlBuf.Append("   ,SCAN_FLG")
                        sqlBuf.Append("   ,REG_USER_CD")
                        sqlBuf.Append("   ,REG_DT")
                        sqlBuf.Append("   ,UPD_USER_CD")
                        sqlBuf.Append("   ,UPD_DT")
                        sqlBuf.Append(" ) VALUES (")
                        sqlBuf.Append("  @P1")
                        sqlBuf.Append(" ,@P2")
                        sqlBuf.Append(" ,@P3")
                        sqlBuf.Append(" ,@P4")
                        sqlBuf.Append(" ,@P5")
                        sqlBuf.Append(" ,@P6")
                        sqlBuf.Append(" ,@P7")
                        sqlBuf.Append(" ,@P8")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" ,@P9")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" )")
                        dbm.SetCommandText(sqlBuf.ToString())
                        dbm.AddParameter("P1", barcodeNo)
                        dbm.AddParameter("P2", dtTable.Rows(0).Item("WH_CD").ToString())
                        dbm.AddParameter("P3", dtTable.Rows(0).Item("RACK_CD").ToString())
                        dbm.AddParameter("P4", "W830")
                        dbm.AddParameter("P5", rackNo)
                        dbm.AddParameter("P6", 0)
                        dbm.AddParameter("P7", 1)
                        dbm.AddParameter("P8", UserId)
                        dbm.AddParameter("P9", UserId)
                        dbm.ExecuteNonQuery()
                        sqlBuf = Nothing

                    Else

                        sqlBuf1 = Nothing
                        sqlBuf1 = New StringBuilder(150)
                        sqlBuf1.Append(" SELECT ITEM_CD ")
                        sqlBuf1.Append(" FROM ITEM_DTL_MS  AS TR ")
                        sqlBuf1.Append(" WHERE TR.BC_NO = @P1 ")
                        dbm.SetCommandText(sqlBuf1.ToString())
                        dbm.AddParameterChar("P1", barcodeNo)

                        dtTable1 = dbm.ExecuteDataTableFill()

                        ' INSERT WH_INFO_TR
                        sqlBuf = Nothing
                        sqlBuf = New StringBuilder(1000)
                        sqlBuf.Append(" INSERT STOCK_REQ_DTL_INFO_TR ( ")
                        sqlBuf.Append("   BC_NO")
                        sqlBuf.Append("   ,ACT_WH_CD")
                        sqlBuf.Append("   ,ACT_RACK_CD")
                        sqlBuf.Append("   ,SPEC_FLG")
                        sqlBuf.Append("   ,SCAN_FLG")
                        sqlBuf.Append("   ,REG_USER_CD")
                        sqlBuf.Append("   ,REG_DT")
                        sqlBuf.Append("   ,UPD_USER_CD")
                        sqlBuf.Append("   ,UPD_DT")
                        sqlBuf.Append(" ) VALUES (")
                        sqlBuf.Append("  @P1")
                        sqlBuf.Append(" ,@P2")
                        sqlBuf.Append(" ,@P3")
                        sqlBuf.Append(" ,@P4")
                        sqlBuf.Append(" ,@P5")
                        sqlBuf.Append(" ,@P6")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" ,@P7")
                        sqlBuf.Append(" ,getdate()")
                        sqlBuf.Append(" )")
                        dbm.SetCommandText(sqlBuf.ToString())
                        dbm.AddParameter("P1", barcodeNo)
                        dbm.AddParameter("P2", "W830")
                        dbm.AddParameter("P3", rackNo)
                        dbm.AddParameter("P4", 0)
                        dbm.AddParameter("P5", 1)
                        dbm.AddParameter("P6", UserId)
                        dbm.AddParameter("P7", UserId)
                        dbm.ExecuteNonQuery()
                        sqlBuf = Nothing
                    End If
                End If

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
        ''' <summary>
        ''' Check if stocktaking is empty.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckStocktakingIsEmpty() As Integer
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing
            Try
                dbm.Connect()

                Dim ret As Integer = 0
                sqlBuf.Append("SELECT * ")
                sqlBuf.Append("FROM STOCK_REQ_INFO_TR ")

                dbm.SetCommandText(sqlBuf.ToString)
                ds = dbm.ExecuteDataSetFill
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Not empty
                    ret = 1
                End If
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BAT012_RackProcess"
        ''' <summary>
        ''' Get rack info in RACK_MASTER_MS.
        ''' </summary>
        ''' <param name="_rackCd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRackInfoByCd(ByVal _rackCd As String, _
                                        ByVal _mode As Integer) As DataSet
            '' Start write file log.
            '// WriteStartLog()
            '' Declare dataset, abcdwebdbmanager, stringbuilder.
            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()
            Try
                '' Open connect to DB.
                dbm.Connect()

                '' Create string query.
                sb.Append("SELECT   A.* ")
                sb.Append("FROM     RACK_MASTER_MS AS A ")
                sb.Append("WHERE    A.RACK_CD = @P1 ")

                dbm.SetCommandText(sb.ToString())

                '' Set value for param.
                dbm.AddParameterChar("P1", _rackCd)

                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                '' An exception error handling.
                '' Time error occurs, always rollback.
                dbm.Rollback()
                ds.Dispose()
                '' Write error into file log.
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                '' Post-processing.
                ds.Dispose()
                '' Disconnect to DB.
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
        ''' <summary>
        ''' Get warehouse list
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWarehouseList() As DataSet
            '' Start write file log.
            '// WriteStartLog()
            '' Declare dataset, abcdwebdbmanager, stringbuilder.
            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()
            Try
                '' Open connect to DB.
                dbm.Connect()

                '' Create string query.
                sb.Append("SELECT   WH_CD, WH_NM ")
                sb.Append("FROM     WH_MASTER_MS ")

                dbm.SetCommandText(sb.ToString())

                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                '' An exception error handling.
                '' Time error occurs, always rollback.
                dbm.Rollback()
                ds.Dispose()
                '' Write error into file log.
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                '' Post-processing.
                ds.Dispose()
                '' Disconnect to DB.
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try

        End Function
        ''' <summary>
        ''' Insert new rack into RACK_MASTER_MS.
        ''' </summary>
        ''' <param name="rackCd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertRackInfo(ByVal rackCd As String, _
                                                                                    ByVal rackName As String, _
                                                                                    ByVal loginId As String) As Integer
            '' Start write file log.
            '// WriteStartLog()
            '' Declare dataset, abcdwebdbmanager, stringbuilder.
            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()
            Try
                dbm.Connect()
                Dim ret As Integer

                '' Create string query.
                sb.Append("INSERT INTO RACK_MASTER_MS( ")
                sb.Append("RACK_CD, RACK_NM, WH_CD,")
                sb.Append("REG_USER_CD,")
                sb.Append("REG_DT) VALUES(")
                sb.Append("@P1,")
                sb.Append(" @P2,")
                sb.Append("'W830',")
                sb.Append("@P3,")
                sb.Append(" GETDATE() ")
                sb.Append(")")
                dbm.SetCommandText(sb.ToString())

                '' Set value for param.
                dbm.AddParameter("P1", rackCd)
                dbm.AddParameter("P2", rackName)
                dbm.AddParameter("P3", loginId)

                ret = dbm.ExecuteNonQuery()
                dbm.Commit()
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
        ''' <summary>
        ''' Function Name: UpdateRackInfo.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateRackInfo(ByVal rackCd As String, _
                                           ByVal rackName As String, _
                                           ByVal loginId As String) As Integer
            '' Start write log
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()

            Try

                '' Open connect DB
                dbm.Connect()

                '' Return number row add
                Dim rs As Integer = 0

                '' String query
                sb.Append("UPDATE RACK_MASTER_MS ")
                sb.Append("SET RACK_NM = @P2, ")
                sb.Append("UPD_USER_CD = @P3,")
                sb.Append("UPD_DT = GETDATE() ")
                sb.Append("WHERE RACK_CD = @P1")

                dbm.SetCommandText(sb.ToString())
                '' Set value parameter
                dbm.AddParameter("P1", rackCd)
                dbm.AddParameter("P2", rackName)
                dbm.AddParameter("P3", loginId)

                rs = dbm.ExecuteNonQuery()
                '' Commit proccess
                dbm.Commit()
                Return rs
            Catch ex As Exception
                '' Rollback proccess
                dbm.Rollback()
                '' Write error log
                WriteErrorLog(ex)
                Throw ex
            Finally
                '' Disconnect DB
                dbm.Disconnect()
                dbm.Dispose()
                '' Finish write log
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Fucntion Name: DeleteRackInfo.
        ''' </summary>
        ''' <param name="rackCd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteRackInfo(ByVal rackCd As String) As Integer
            '' Start write log
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()

            Try

                '' Open connect DB
                dbm.Connect()

                '' Return number row add
                Dim rs As Integer = 0

                '' String query
                sb.Append("DELETE FROM RACK_MASTER_MS ")
                sb.Append("WHERE RACK_CD = @P1")

                dbm.SetCommandText(sb.ToString())
                '' Set value parameter
                dbm.AddParameterChar("P1", rackCd)

                rs = dbm.ExecuteNonQuery()
                '' Commit proccess
                dbm.Commit()
                Return rs
            Catch ex As Exception
                '' Rollback proccess
                dbm.Rollback()
                '' Write error log
                WriteErrorLog(ex)
                Throw ex
            Finally
                '' Disconnect DB
                dbm.Disconnect()
                dbm.Dispose()
                '' Finish write log
                '// WriteEndLog()
            End Try
        End Function
        ''' <summary>
        ''' Rack inqury.
        ''' </summary>
        ''' <param name="_rackCd"></param>
        ''' <param name="_rackName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RackInquiry(ByVal _rackCd As String, _
                                    ByVal _rackName As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing
            Try
                dbm.Connect()

                Dim ret As Integer = 0

                sqlBuf.Append("SELECT * ")
                sqlBuf.Append("FROM   RACK_MASTER_MS ")
                sqlBuf.Append("WHERE  1=1 ")
                If _rackCd.Equals("") = False Then
                    sqlBuf.Append(" AND RACK_CD LIKE '%'+@P1+'%' ")
                End If
                If _rackName.Equals("") = False Then
                    sqlBuf.Append(" AND RACK_NM LIKE '%'+@P2+'%' ")
                End If

                dbm.SetCommandText(sqlBuf.ToString)
                '' Set value parameter
                If _rackCd.Equals("") = False Then
                    dbm.AddParameterChar("P1", _rackCd)
                End If
                If _rackName.Equals("") = False Then
                    dbm.AddParameterChar("P2", _rackName)
                End If

                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
        ''' <summary>
        ''' Check if rack is empty.
        ''' </summary>
        ''' <param name="_rackCd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckRackIsEmpty(ByVal _rackCd As String) As Integer
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing
            Try
                dbm.Connect()

                Dim ret As Integer = 0
                sqlBuf.Append("SELECT TOP 1 * ")
                sqlBuf.Append("FROM WH_INFO_TR ")
                sqlBuf.Append(" WHERE RACK_CD = @P1 ")

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameter("P1", _rackCd)
                ds = dbm.ExecuteDataSetFill
                If ds.Tables(0).Rows.Count <> 0 Then
                    'Not empty
                    ret = 1
                End If
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BATCH 013 Customer Process"
        ''' <summary>
        ''' Get next id for new customer.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNextCusId() As String
            '// WriteStartLog()

            Dim CustomerId As String = ""
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing

            Try
                dbm.Connect()

                Dim ret As Integer = 0

                sqlBuf.Append("SELECT A.* ")
                sqlBuf.Append("FROM   CUS_MASTER_MS AS A ")

                dbm.SetCommandText(sqlBuf.ToString())

                ds = dbm.ExecuteDataSetFill()
                Dim strCusNextId As String = (ds.Tables(0).Rows.Count + 1).ToString()

                Select Case strCusNextId.Length()
                    Case 1 '' Add 0000
                        CustomerId = "CUS0000" & strCusNextId
                    Case 2 '' Add 000
                        CustomerId = "CUS000" & strCusNextId
                    Case 3 '' Add 00
                        CustomerId = "CUS00" & strCusNextId
                    Case 4 '' Add 0
                        CustomerId = "CUS0" & strCusNextId
                    Case 5 '' Not add
                        CustomerId = "CUS" & strCusNextId
                End Select

                Return CustomerId
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Insert info new customer.
        ''' </summary>
        ''' <param name="cusId"></param>
        ''' <param name="cusName"></param>
        ''' <param name="dest"></param>
        ''' <param name="address"></param>
        ''' <param name="telNo"></param>
        ''' <param name="faxNo"></param>
        ''' <param name="mail"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertCustomerInfo(ByVal cusId As String, _
                                            ByVal cusName As String, _
                                            ByVal dest As Integer, _
                                            ByVal address As String, _
                                            ByVal telNo As String, _
                                            ByVal faxNo As String, _
                                            ByVal mail As String, _
                                            ByVal loginId As String) As Integer
            '' Start write log
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()

            Try

                '' Open connect DB
                dbm.Connect()

                '' Return number row add
                Dim rs As Integer = 0

                '' String query
                sb.Append("INSERT CUS_MASTER_MS (")
                sb.Append(" CUS_ID, ")
                sb.Append(" CUS_NM, ")
                sb.Append(" DEST, ")
                sb.Append(" ADDRESS, ")
                If Not "".Equals(telNo) Then
                    sb.Append(" TEL_NO, ")
                End If
                If Not "".Equals(faxNo) Then
                    sb.Append(" FAX_NO, ")
                End If
                If Not "".Equals(mail) Then
                    sb.Append(" MAIL_ADD, ")
                End If
                sb.Append(" REG_USER_CD, ")
                sb.Append(" REG_DT, ")
                sb.Append(" UPD_USER_CD, ")
                sb.Append(" UPD_DT) VALUES (")
                sb.Append(" @P1, ")
                sb.Append(" @P2, ")
                sb.Append(" @P3, ")
                sb.Append(" @P4, ")
                If Not "".Equals(telNo) Then
                    sb.Append(" @P5, ")
                End If
                If Not "".Equals(faxNo) Then
                    sb.Append(" @P6, ")
                End If
                If Not "".Equals(mail) Then
                    sb.Append(" @P7, ")
                End If
                sb.Append(" @P8, ")
                sb.Append(" GETDATE(), ")
                sb.Append(" @P8, ")
                sb.Append(" GETDATE()) ")

                dbm.SetCommandText(sb.ToString())
                '' Set value parameter
                dbm.AddParameterChar("P1", cusId)
                dbm.AddParameterChar("P2", cusName)
                dbm.AddParameter("P3", dest)
                dbm.AddParameterChar("P4", address)
                If Not "".Equals(telNo) Then
                    dbm.AddParameterChar("P5", telNo)
                End If
                If Not "".Equals(faxNo) Then
                    dbm.AddParameterChar("P6", faxNo)
                End If
                If Not "".Equals(mail) Then
                    dbm.AddParameterChar("P7", mail)
                End If
                dbm.AddParameterChar("P8", loginId)

                rs = dbm.ExecuteNonQuery()
                '' Commit proccess
                dbm.Commit()
                Return rs
            Catch ex As Exception
                '' Rollback proccess
                dbm.Rollback()
                '' Write error log
                WriteErrorLog(ex)
                Throw ex
            Finally
                '' Disconnect DB
                dbm.Disconnect()
                dbm.Dispose()
                '' Finish write log
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Get info customer by id.
        ''' </summary>
        ''' <param name="cusId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCustomerInfoByID(ByVal cusId As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT CMM.* ")
                sql.Append("FROM   CUS_MASTER_MS AS CMM ")
                sql.Append("WHERE  CMM.CUS_ID = @P1 ")

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", cusId)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Update info old customer.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateCustomerInfo(ByVal cusId As String, _
                                           ByVal cusName As String, _
                                           ByVal address As String, _
                                           ByVal dest As Integer, _
                                           ByVal email As String, _
                                           ByVal faxNo As String, _
                                           ByVal telNo As String, _
                                           ByVal loginId As String) As Integer
            '' Start write log
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()

            Try

                '' Open connect DB
                dbm.Connect()

                '' Return number row add
                Dim rs As Integer = 0

                '' String query
                sb.Append("UPDATE CUS_MASTER_MS ")
                sb.Append("SET CUS_NM = @P2, ")
                sb.Append("    DEST = @P3, ")
                sb.Append("    ADDRESS = @P4")
                If Not "".Equals(telNo) Then
                    sb.Append("    , TEL_NO = @P5")
                End If
                If Not "".Equals(faxNo) Then
                    sb.Append("    , FAX_NO = @P6")
                End If
                If Not "".Equals(email) Then
                    sb.Append("    , MAIL_ADD = @P7")
                End If
                sb.Append("    , UPD_USER_CD = @P8")
                sb.Append("    , UPD_DT = GETDATE() ")
                sb.Append("WHERE CUS_ID = @P1")

                dbm.SetCommandText(sb.ToString())
                '' Set value parameter
                dbm.AddParameterChar("P1", cusId)
                dbm.AddParameterChar("P2", cusName)
                dbm.AddParameter("P3", dest)
                dbm.AddParameterChar("P4", address)
                If Not "".Equals(telNo) Then
                    dbm.AddParameterChar("P5", telNo)
                End If
                If Not "".Equals(faxNo) Then
                    dbm.AddParameterChar("P6", faxNo)
                End If
                If Not "".Equals(email) Then
                    dbm.AddParameterChar("P7", email)
                End If
                dbm.AddParameterChar("P8", loginId)

                rs = dbm.ExecuteNonQuery()
                '' Commit proccess
                dbm.Commit()
                Return rs
            Catch ex As Exception
                '' Rollback proccess
                dbm.Rollback()
                '' Write error log
                WriteErrorLog(ex)
                Throw ex
            Finally
                '' Disconnect DB
                dbm.Disconnect()
                dbm.Dispose()
                '' Finish write log
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Delete info old customer.
        ''' </summary>
        ''' <param name="cusId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteCustomerInfo(ByVal cusId As String) As Integer
            '' Start write log
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()

            Try

                '' Open connect DB
                dbm.Connect()

                '' Return number row add
                Dim rs As Integer = 0

                '' String query
                sb.Append("DELETE FROM CUS_MASTER_MS ")
                sb.Append("WHERE CUS_ID = @P1")

                dbm.SetCommandText(sb.ToString())
                '' Set value parameter
                dbm.AddParameterChar("P1", cusId)

                rs = dbm.ExecuteNonQuery()
                '' Commit proccess
                dbm.Commit()
                Return rs
            Catch ex As Exception
                '' Rollback proccess
                dbm.Rollback()
                '' Write error log
                WriteErrorLog(ex)
                Throw ex
            Finally
                '' Disconnect DB
                dbm.Disconnect()
                dbm.Dispose()
                '' Finish write log
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Get info customers by: id, name, tel, address, email, dest.
        ''' </summary>
        ''' <param name="cusId"></param>
        ''' <param name="cusName"></param>
        ''' <param name="telNo"></param>
        ''' <param name="address"></param>
        ''' <param name="dest"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CustomerInquiry(ByVal cusId As String, _
                                        ByVal cusName As String, _
                                        ByVal telNo As String, _
                                        ByVal address As String, _
                                        ByVal email As String, _
                                        ByVal dest As Integer) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT CMM.* ")
                sql.Append("FROM   CUS_MASTER_MS AS CMM ")
                sql.Append("WHERE  1=1 ")
                If Not "".Equals(cusId) Then
                    sql.Append(" AND CMM.CUS_ID LIKE @P1 ")
                End If
                If Not "".Equals(cusName) Then
                    sql.Append(" AND CMM.CUS_NM LIKE @P2 ")
                End If
                If Not "".Equals(telNo) Then
                    sql.Append(" AND CMM.TEL_NO LIKE @P3 ")
                End If
                If Not "".Equals(address) Then
                    sql.Append(" AND CMM.ADDRESS LIKE @P4 ")
                End If
                If dest <> 0 Then
                    sql.Append(" AND CMM.DEST = @P5 ")
                End If
                If Not email.Equals("") Then
                    sql.Append(" AND CMM.MAIL_ADD LIKE @P6 ")
                End If

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", ("%" & cusId & "%"))
                dbm.AddParameterChar("P2", ("%" & cusName & "%"))
                dbm.AddParameterChar("P3", ("%" & telNo & "%"))
                dbm.AddParameterChar("P4", ("%" & address & "%"))
                dbm.AddParameter("P5", dest)
                dbm.AddParameterChar("P6", ("%" & email & "%"))

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
#End Region

#Region "BATCH 014 Item Process"
        ''' <summary>
        ''' Get product info by item code.
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetProductInfoTrByItemCode(ByVal itemCode As String) As DataSet
            '// WriteStartLog()
            Dim dbm As New ABCDWebDBManager(Me.UserId) '' New connect to DB.
            Dim sql As New StringBuilder
            Try
                dbm.Connect() '' Open connect.
                '' Create query get data.
                'sql.Append("SELECT * ")
                'sql.Append("FROM   PRODUCT_INFO_TR ")
                'sql.Append("WHERE  ITEM_CD = @P1 ")
                sql.Append("SELECT COUNT(*) AS NUM_ITEM ")
                sql.Append("FROM   WH_INFO_TR AS A,")
                sql.Append("       PRODUCT_INFO_TR AS B,")
                sql.Append("       ITEM_DTL_MS AS C,")
                sql.Append("       ITEM_CUS_MS AS D ")
                sql.Append("WHERE C.ITEM_CD = B.ITEM_CD ")
                sql.Append("  AND  C.ITEM_CD = A.ITEM_CD ")
                sql.Append("  AND  C.ITEM_CD = D.ITEM_CD ")
                sql.Append("  AND  C.ITEM_CD = @P1 ")
                '' Set query.
                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", itemCode) '' Set value param.
                Return dbm.ExecuteDataSetFill
            Catch ex As Exception
                dbm.Rollback() '' Rollback when error.
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect() '' Cut connect.
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Func Name: GetItemInfoByCd
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemInfoByCd(ByVal itemCode As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT IMM.* ")
                sql.Append("FROM   ITEM_MASTER_MS AS IMM ")
                sql.Append("WHERE  IMM.ITEM_CD = @P1")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", itemCode)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Func Name: GetItemInfoByCdDbm
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetItemInfoByCdDbm(ByVal itemCode As String, _
                                           ByVal dbm As ABCDWebDBManager) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim sql As New StringBuilder

            Try
                sql.Append("SELECT IMM.* ")
                sql.Append("FROM   ITEM_MASTER_MS AS IMM ")
                sql.Append("WHERE  IMM.ITEM_CD = @P1")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", itemCode)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
                'Finally
                '    ds.Dispose()
                '    dbm.Disconnect()
                '    dbm.Dispose()
                '    '// WriteEndLog()
                '    dbm = Nothing
            End Try
        End Function
        ''' <summary>
        ''' Func Name: GetItemCustomerInfoByCd
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemCustomerInfoByCd(ByVal itemCode As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT C.CUS_ID, C.CUS_NM, C.MAIL_ADD, C.TEL_NO, C.FAX_NO, C.ADDRESS ")
                sql.Append("       , A.* ")
                sql.Append("FROM   ITEM_MASTER_MS AS A, ")
                sql.Append("       ITEM_CUS_MS AS B, ")
                sql.Append("       CUS_MASTER_MS AS C ")
                sql.Append("WHERE  A.ITEM_CD = B.ITEM_CD ")
                sql.Append("  AND  C.CUS_ID = B.CUS_ID ")
                sql.Append("  AND  A.ITEM_CD = @P1")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", itemCode)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Func Name: ExportItemCheck
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExportItemCheck(ByVal itemCode As String) As DataSet
            Return Nothing
        End Function

        ''' <summary>
        ''' Func Name: InsertItemInfo
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <param name="itemName"></param>
        ''' <param name="quantity"></param>
        ''' <param name="customerList"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertItemInfo(ByVal itemCode As String, _
                                       ByVal itemName As String, _
                                       ByVal quantity As Integer, _
                                       ByVal unit As Integer, _
                                       ByVal temp As Integer, _
                                       ByVal orotexNo As String, _
                                       ByVal path01 As String, _
                                       ByVal path02 As String, _
                                       ByVal path03 As String, _
                                       ByVal path04 As String, _
                                       ByVal path05 As String, _
                                       ByVal customerList As List(Of String), _
                                       ByVal loginId As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                Dim row As Integer = 0

                sql.Append("INSERT ITEM_MASTER_MS (")
                sql.Append(" ITEM_CD, ")
                sql.Append(" ITEM_NM, ")
                sql.Append(" CUR_BOX_NUM, ")
                sql.Append(" QTY, ")
                sql.Append(" UNIT, ")
                sql.Append(" TEMP_TYPE, ")
                sql.Append(" OROTEX_NO, ")
                sql.Append(" IMG_PATH1, ")
                sql.Append(" IMG_PATH2, ")
                sql.Append(" IMG_PATH3, ")
                sql.Append(" IMG_PATH4, ")
                sql.Append(" IMG_PATH5, ")
                sql.Append(" REG_USER_CD, ")
                sql.Append(" REG_DT, ")
                sql.Append(" UPD_USER_CD, ")
                sql.Append(" UPD_DT")
                sql.Append(") VALUES (")
                sql.Append(" @P1, ")
                sql.Append(" @P2, ")
                sql.Append(" 0, ")
                sql.Append(" @P3, ")
                sql.Append(" @P4, ")
                sql.Append(" @P5, ")
                sql.Append(" @P6, ")
                sql.Append(" @P7, ")
                sql.Append(" @P8, ")
                sql.Append(" @P9, ")
                sql.Append(" @P10, ")
                sql.Append(" @P11, ")
                sql.Append(" @P12, ")
                sql.Append(" GETDATE(), ")
                sql.Append(" @P12, ")
                sql.Append(" GETDATE()")
                sql.Append(")")

                Dim insertItem As String = sql.ToString

                sql = New StringBuilder
                sql.Append("INSERT ITEM_CUS_MS (")
                sql.Append(" ITEM_CD, ")
                sql.Append(" CUS_ID, ")
                sql.Append(" REG_USER_CD, ")
                sql.Append(" REG_DT, ")
                sql.Append(" UPD_USER_CD, ")
                sql.Append(" UPD_DT")
                sql.Append(") ")
                For i As Integer = 13 To customerList.Count + 12 Step 1
                    If i <> 13 Then
                        sql.Append(" UNION ALL ")
                    End If
                    sql.Append("SELECT")
                    sql.Append(" @P1, ")
                    sql.Append(" @P" & i.ToString & ", ")
                    sql.Append(" @P12, ")
                    sql.Append(" GETDATE(), ")
                    sql.Append(" @P12, ")
                    sql.Append(" GETDATE() ")
                Next

                Dim insertItemCustomer As String = sql.ToString

                dbm.SetCommandText(insertItem & vbCrLf & insertItemCustomer)
                dbm.AddParameterChar("P1", itemCode)
                dbm.AddParameterChar("P2", itemName)
                dbm.AddParameter("P3", quantity)
                dbm.AddParameter("P4", unit)
                dbm.AddParameter("P5", temp)
                dbm.AddParameter("P6", orotexNo)
                dbm.AddParameter("P7", path01)
                dbm.AddParameter("P8", path02)
                dbm.AddParameter("P9", path03)
                dbm.AddParameter("P10", path04)
                dbm.AddParameter("P11", path05)
                dbm.AddParameterChar("P12", loginId)
                For i As Integer = 0 To customerList.Count - 1 Step 1
                    dbm.AddParameterChar("P" & (i + 13).ToString, customerList(i))
                Next

                row = dbm.ExecuteNonQuery
                dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Update info item.
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <param name="itemName"></param>
        ''' <param name="quantity"></param>
        ''' <param name="unit"></param>
        ''' <param name="temp"></param>
        ''' <param name="customerList"></param>
        ''' <param name="loginCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateItemInfo(ByVal itemCode As String, _
                                       ByVal itemName As String, _
                                       ByVal quantity As Integer, _
                                       ByVal unit As Integer, _
                                       ByVal temp As Integer, _
                                   ByVal orotexNo As String, _
                                   ByVal path01 As String, _
                                   ByVal path02 As String, _
                                   ByVal path03 As String, _
                                   ByVal path04 As String, _
                                   ByVal path05 As String, _
                                       ByVal customerList As List(Of String), _
                                       ByVal loginCode As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()
                Dim row As Integer = 0
                '' Delete table ITEM_CUS_MS.
                sql.Append("DELETE FROM ITEM_CUS_MS ")
                sql.Append("WHERE ITEM_CD = @P1 ")
                '' Update table ITEM_MASTER_MS.
                sql.Append("UPDATE ITEM_MASTER_MS ")
                sql.Append("SET ITEM_NM = @P2, ")
                sql.Append("    QTY = @P3, ")
                sql.Append("    UNIT = @P4, ")
                sql.Append("    TEMP_TYPE = @P5, ")
                sql.Append("    OROTEX_NO = @P6, ")
                sql.Append("    IMG_PATH1 = @P7, ")
                sql.Append("    IMG_PATH2 = @P8, ")
                sql.Append("    IMG_PATH3 = @P9, ")
                sql.Append("    IMG_PATH4 = @P10, ")
                sql.Append("    IMG_PATH5 = @P11, ")
                sql.Append("    UPD_USER_CD = @P12, ")
                sql.Append("    UPD_DT = GETDATE() ")
                sql.Append("WHERE ITEM_CD = @P1 ")
                '' Insert table ITEM_CUS_MS.
                sql.Append("INSERT ITEM_CUS_MS ")
                sql.Append("(")
                sql.Append("ITEM_CD, ")
                sql.Append("CUS_ID, ")
                sql.Append("REG_USER_CD, ")
                sql.Append("REG_DT, ")
                sql.Append("UPD_USER_CD, ")
                sql.Append("UPD_DT")
                sql.Append(") ")
                For i As Integer = 13 To customerList.Count + 12 Step 1
                    If i <> 13 Then
                        sql.Append("UNION ALL ")
                    End If
                    sql.Append("SELECT ")
                    sql.Append("@P1, ")
                    sql.Append("@P" & i.ToString & ", ")
                    sql.Append("@P6, ")
                    sql.Append("GETDATE(), ")
                    sql.Append("@P6, ")
                    sql.Append("GETDATE() ")
                Next
                dbm.SetCommandText(sql.ToString) '' Get contains sql set dbm.
                dbm.AddParameterChar("P1", itemCode)
                dbm.AddParameterChar("P2", itemName)
                dbm.AddParameter("P3", quantity)
                dbm.AddParameter("P4", unit)
                dbm.AddParameter("P5", temp)
                dbm.AddParameter("P6", orotexNo)
                dbm.AddParameter("P7", path01)
                dbm.AddParameter("P8", path02)
                dbm.AddParameter("P9", path03)
                dbm.AddParameter("P10", path04)
                dbm.AddParameter("P11", path05)
                dbm.AddParameterChar("P12", loginCode)
                For i As Integer = 0 To customerList.Count - 1 Step 1
                    dbm.AddParameterChar("P" & (i + 13).ToString, customerList(i))
                Next

                row = dbm.ExecuteNonQuery
                dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Delete info item.
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteItemInfo(ByVal itemCode As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                Dim row As Integer = 0

                sql.Append("DELETE FROM ITEM_CUS_MS ")
                sql.AppendFormat("WHERE ITEM_CD = '{0}'", itemCode)
                Dim deleteItemCustomer As String = sql.ToString

                sql = New StringBuilder
                sql.Append("DELETE FROM ITEM_MASTER_MS ")
                sql.AppendFormat("WHERE ITEM_CD = '{0}'", itemCode)
                Dim deleteItem As String = sql.ToString

                dbm.SetCommandText(deleteItemCustomer & vbCrLf & deleteItem)

                row = dbm.ExecuteNonQuery
                dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Get all info item.
        ''' </summary>
        ''' <param name="itemCodeFrom"></param>
        ''' <param name="itemCodeTo"></param>
        ''' <param name="itemName"></param>
        ''' <param name="customerCode"></param>
        ''' <param name="customerName"></param>
        ''' <param name="quantity"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ItemInquiry(ByVal itemCodeFrom As String, _
                                    ByVal itemCodeTo As String, _
                                    ByVal itemName As String, _
                                    ByVal customerCode As String, _
                                    ByVal customerName As String, _
                                    ByVal quantity As Integer) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT DISTINCT A.* ")
                sql.Append("FROM   ITEM_MASTER_MS AS A, ")
                sql.Append("       ITEM_CUS_MS AS B, ")
                sql.Append("       CUS_MASTER_MS AS C ")
                sql.Append("WHERE  A.ITEM_CD = B.ITEM_CD ")
                sql.Append("  AND  C.CUS_ID = B.CUS_ID ")
                If Not itemCodeFrom.Equals("") Then
                    sql.Append("  AND  A.ITEM_CD >= @P1 ")
                End If
                If Not itemCodeTo.Equals("") Then
                    sql.Append("  AND  A.ITEM_CD <= @P2 ")
                End If
                If Not customerCode.Equals("") Then
                    sql.Append("  AND C.CUS_ID = @P3 ")
                End If
                If quantity <> 0 Then
                    sql.Append("  AND A.QTY = @P4 ")
                End If
                sql.Append("ORDER BY A.ITEM_CD ASC")

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", itemCodeFrom)
                dbm.AddParameterChar("P2", itemCodeTo)
                dbm.AddParameterChar("P3", customerCode)
                dbm.AddParameter("P4", quantity)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function GetItemDetailInfoByBCFromTo(ByVal barcodeFrom As String, ByVal barcodeTo As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT A.WO_NO, A.WO_DT, A.QTY_PER_BOX,C.ITEM_NM, C.*, A.LOT_NO, B.BOX_NUM, B.BC_NO ")

                sql.Append("FROM   PRODUCT_INFO_TR AS A, ")
                sql.Append("ITEM_DTL_MS AS B, ")
                sql.Append("ITEM_MASTER_MS AS C ")

                sql.Append("WHERE  A.WO_NO = B.WO_NO ")
                sql.Append("  AND  B.ITEM_CD = C.ITEM_CD ")
                If Not barcodeFrom.Equals("") And Not barcodeTo.Equals("") Then
                    'sql.AppendFormat("  AND  B.BC_NO BETWEEN CAST('{0}' AS NUMERIC) AND CAST('{1}' AS NUMERIC) ", barcodeFrom, barcodeTo)
                    sql.Append(" AND B.BC_NO BETWEEN CAST(@P1 AS NUMERIC) AND CAST(@P2 AS NUMERIC) ")
                End If

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", barcodeFrom)
                dbm.AddParameterChar("P2", barcodeTo)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function GetCurrentBoxNumber(ByVal itemCode As String) As String
            '// WriteStartLog()

            Dim curBoxNum As String
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT CUR_BOX_NUM ")
                sql.Append("FROM   ITEM_MASTER_MS ")
                sql.Append("WHERE ITEM_CD = @P1 ")

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", itemCode)

                curBoxNum = Trim(dbm.ExecuteScalar)
                Return curBoxNum
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
        Private Function GetCurrentBoxNumberByDbm(ByVal itemCode As String, ByVal dbm As ABCDWebDBManager) As String
            '// WriteStartLog()

            Dim curBoxNum As String
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT CUR_BOX_NUM ")
                sql.Append("FROM   ITEM_MASTER_MS ")
                sql.Append("WHERE ITEM_CD = @P1 ")

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", itemCode)

                curBoxNum = Trim(dbm.ExecuteScalar)
                Return curBoxNum
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            End Try
        End Function

        Public Function UpdateCurrentBoxNumber(ByVal itemCode As String, ByVal curBoxNum As String) As Integer
            '// WriteStartLog()
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()
                Dim ret As Integer = 0

                sql.Append("UPDATE ITEM_MASTER_MS ")
                'sql.AppendFormat("SET CUR_BOX_NUM = '{0}' ", curBoxNum)
                'sql.AppendFormat("WHERE ITEM_CD = '{0}' ", itemCode)
                sql.Append("SET CUR_BOX_NUM = @P2 ")
                sql.Append("WHERE ITEM_CD = @P1 ")

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", itemCode)
                dbm.AddParameterChar("P2", curBoxNum)

                ret = dbm.ExecuteNonQuery()
                dbm.Commit()
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function UpdateCurrentBoxNumberToString(ByVal itemCode As String, ByVal curBoxNum As String) As String

            Dim sql As New StringBuilder
            sql.Append("UPDATE ITEM_MASTER_MS ")
            sql.AppendFormat("SET CUR_BOX_NUM = '{0}' ", curBoxNum)
            sql.AppendFormat("WHERE ITEM_CD = '{0}' ", itemCode)

            Return sql.ToString
        End Function

        Public Function GetItemDetailByItemCd(ByVal itemCd As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT A.*")
                sql.Append("FROM   ITEM_DTL_MS AS A ")
                sql.Append("WHERE  A.ITEM_CD = @P1")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", itemCd)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
#End Region

#Region "BATCH 017 Warehouse Hist Tr Process"

        ''' <summary>
        ''' Stock In/Out History[WHS003]
        ''' Cuongtk - 20150819: Add column INVOICE_NO, just change value to work export
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="warehouseCd"></param>
        ''' <param name="itemCd"></param>
        ''' <param name="startDate"></param>
        ''' <param name="endDate"></param>
        ''' <param name="status"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWarehouseHistTr(ByVal barcodeNo As String, ByVal warehouseCd As String, ByVal itemCd As String, ByVal startDate As String, ByVal endDate As String, ByVal status As Integer) As DataSet
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim dataSet As DataSet = Nothing
            Try
                webDbManager.Connect() '// Open connect DB
                '// Create content SQL query
                sqlBuilder.Append(" SELECT ")
                '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - start
                sqlBuilder.Append("   SRIT.SHIP_REQ_NO, ")
                sqlBuilder.Append("   WH.BC_NO, ")
                sqlBuilder.Append("   SRIT.INVOICE_NO, ")
                sqlBuilder.Append("   IDM.LOT_NO, ")
                sqlBuilder.Append("   WH.ITEM_CD, ")
                sqlBuilder.Append("   WH.WH_CD, ")
                sqlBuilder.Append("   WH.RACK_CD, ")
                sqlBuilder.Append("   SS.STATUS_NM, ")
                '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - end
                'sqlBuilder.Append("   WH.WH_CD, ")
                'sqlBuilder.Append("   WH.ITEM_CD, ")
                'sqlBuilder.Append("   WH.ITEM_NM, ")
                'sqlBuilder.Append("   WH.RACK_CD, ")
                'sqlBuilder.Append("   WH.RACK_NM, ")
                'sqlBuilder.Append("   WH.BC_NO, ")
                'sqlBuilder.Append("   WH.STATUS_FLG, ")
                'sqlBuilder.Append("   SS.STATUS_NM, ")
                sqlBuilder.Append("   WH.REG_USER_CD, ")
                sqlBuilder.Append("   WH.REG_DT, ")
                sqlBuilder.Append("   WH.UPD_USER_CD, ")
                sqlBuilder.Append("   WH.UPD_DT ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   WH_HIST_INFO_TR AS WH ")
                sqlBuilder.Append(" INNER JOIN ")
                sqlBuilder.Append("   WH_STATUS_TR AS SS ")
                sqlBuilder.Append(" ON ")
                sqlBuilder.Append("   WH.STATUS_FLG = SS.STATUS_CD ")
                '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - start
                sqlBuilder.Append(" INNER JOIN ")
                sqlBuilder.Append("   ITEM_DTL_MS AS IDM ")
                sqlBuilder.Append(" ON ")
                sqlBuilder.Append("   WH.BC_NO = IDM.BC_NO ")
                sqlBuilder.Append(" LEFT JOIN ")
                sqlBuilder.Append("   SHIP_REQ_INFO_TR AS SRIT ")
                sqlBuilder.Append(" ON ")
                sqlBuilder.Append("   SRIT.SHIP_REQ_NO = WH.SHIP_REQ_NO ")
                '// cuongtk - 20150821: #No.37 add columns(Ship Req No, Invoice No, Lot No) - end
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append(" AND ")
                sqlBuilder.Append("   CONVERT(VARCHAR(8), WH.REG_DT, 112) >= @P1 ")
                sqlBuilder.Append(" AND ")
                sqlBuilder.Append("   CONVERT(VARCHAR(8), WH.REG_DT, 112) <= @P2 ")
                If Not "".Equals(barcodeNo) Then
                    sqlBuilder.Append(" AND ")
                    sqlBuilder.Append("   WH.BC_NO LIKE @P3 ") '// Find same with barcode input.
                End If
                If Not "".Equals(warehouseCd) Then
                    sqlBuilder.Append(" AND ")
                    sqlBuilder.Append("   WH.WH_CD = @P4 ")
                End If
                If Not "".Equals(itemCd) Then
                    sqlBuilder.Append(" AND ")
                    sqlBuilder.Append("   WH.ITEM_CD = @P5 ")
                End If
                If status <> -1 Then
                    sqlBuilder.Append(" AND ")
                    sqlBuilder.Append("   WH.STATUS_FLG = @P6 ")
                End If
                sqlBuilder.Append(" ORDER BY ")
                sqlBuilder.Append("   REG_DT ASC ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameter("P1", startDate)
                webDbManager.AddParameter("P2", endDate)
                If Not "".Equals(barcodeNo) Then
                    webDbManager.AddParameterChar("P3", ("%" & barcodeNo & "%")) '// Value to find with key 'LIKE' in SQL.
                End If
                If Not "".Equals(warehouseCd) Then
                    webDbManager.AddParameterChar("P4", warehouseCd)
                End If
                If Not "".Equals(itemCd) Then
                    webDbManager.AddParameterChar("P5", itemCd)
                End If
                If status <> -1 Then
                    webDbManager.AddParameter("P6", status)
                End If
                '// Return for dataSet
                dataSet = webDbManager.ExecuteDataSetFill
                webDbManager.Disconnect()
                webDbManager.Dispose()
                Return dataSet
            Catch ex As Exception
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        'Public Function GetWarehouseHistTr(ByVal barcodeNo As String, _
        '                                ByVal warehouseCd As String, _
        '                                ByVal itemCd As String, _
        '                                ByVal stockDateFrom As String, _
        '                                ByVal stockDateTo As String, _
        '                                ByVal statusFlg As Integer) As DataSet
        '    '    '// WriteStartLog()

        '    Dim ds As DataSet = Nothing
        '    Dim dbm As New ABCDWebDBManager(Me.UserId)
        '    Dim sql As New StringBuilder

        '    Try
        '        dbm.Connect()

        '        sql.Append(" SELECT WH.WH_CD, WH.ITEM_CD, WH.ITEM_NM, WH.RACK_CD, WH.RACK_NM, WH.BC_NO, WH.STATUS_FLG, SS.STATUS_NM, WH.REG_USER_CD, ")
        '        sql.Append("        WH.REG_DT, WH.UPD_USER_CD, WH.UPD_DT ")
        '        sql.Append(" FROM WH_HIST_INFO_TR AS WH ")
        '        sql.Append(" LEFT JOIN WH_STATUS_TR AS SS ")
        '        sql.Append(" ON WH.STATUS_FLG = SS.STATUS_CD ")
        '        sql.Append(" WHERE  1 = 1")

        '        If Not String.IsNullOrEmpty(Trim(barcodeNo)) Then
        '            sql.Append(" AND  WH.BC_NO = @P1")
        '        End If

        '        If Not String.IsNullOrEmpty(Trim(warehouseCd)) Then
        '            sql.Append(" AND  WH.WH_CD = @P2")
        '        End If

        '        If Not String.IsNullOrEmpty(Trim(itemCd)) Then
        '            sql.Append(" AND  WH.ITEM_CD = @P3")
        '        End If

        '        If Not Date.MinValue.Equals(stockDateFrom) Then
        '            sql.Append(" AND  CONVERT(varchar(8),WH.REG_DT,112) >= @P4")
        '            'sql.Append(" AND WH.REG_DT >= @P4 ")
        '        End If

        '        If Not Date.MinValue.Equals(stockDateTo) Then
        '            sql.Append(" AND  CONVERT(varchar(8),WH.REG_DT,112) <= @P5")
        '            'sql.Append(" AND WH.REG_DT <= @P5 ")
        '        End If

        '        If Not statusFlg = -1 Then
        '            sql.Append(" AND  WH.STATUS_FLG = @P6")
        '        End If

        '        dbm.SetCommandText(sql.ToString)
        '        dbm.AddParameterChar("P1", barcodeNo)
        '        dbm.AddParameterChar("P2", warehouseCd)
        '        dbm.AddParameterChar("P3", itemCd)
        '        dbm.AddParameterChar("P4", stockDateFrom)
        '        dbm.AddParameterChar("P5", stockDateTo)
        '        dbm.AddParameterChar("P6", statusFlg)

        '        ds = dbm.ExecuteDataSetFill
        '        Return ds
        '    Catch ex As Exception
        '        dbm.Rollback()
        '        ds.Dispose()
        '        WriteErrorLog(ex.Message)
        '        Throw ex
        '    Finally
        '        ds.Dispose()
        '        dbm.Disconnect()
        '        dbm.Dispose()
        '        '// WriteEndLog()
        '        dbm = Nothing
        '    End Try
        'End Function

        ''' <summary>
        ''' InsertWarehouseHistTrInfo
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="warehouseCd"></param>
        ''' <param name="itemCd"></param>
        ''' <param name="statusFlg"></param>
        ''' <param name="rackCd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertWarehouseHistTrInfo(ByVal barcodeNo As String, _
                                        ByVal warehouseCd As String, _
                                        ByVal itemCd As String, _
                                        ByVal statusFlg As Integer, _
                                        ByVal rackCd As String) As Integer
            '// WriteStartLog()

            Dim row As Integer = 0
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()
                'sql.Append(" INSERT INTO WH_HIST_INFO_TR                        ")
                'sql.Append("            ([BC_NO]                                ")
                'sql.Append("            ,[HIST_NO]                              ")
                'sql.Append("            ,[STATUS_FLG]                           ")
                'sql.Append("            ,[WH_CD]                                ")
                'sql.Append("            ,[RACK_CD]                              ")
                'sql.Append("            ,[ITEM_CD]                              ")
                'sql.Append("            ,[REG_USER_CD]                          ")
                'sql.Append("            ,[REG_DT]                               ")
                'sql.Append("            ,[UPD_USER_CD]                          ")
                'sql.Append("            ,[UPD_DT])                              ")
                'sql.Append("      SELECT                                        ")
                'sql.Append("            @P1                                    ")
                'sql.Append("            ,(SELECT (COALESCE(MAX(HIST_NO), 0) + 1)")
                'sql.Append("                 FROM WH_HIST_INFO_TR               ")
                'sql.Append("                 WHERE BC_NO = @P1)                 ")
                'sql.Append("            ,@P4                                    ")
                'sql.Append("            ,@P2                                    ")
                'sql.Append("            ,@P5                                    ")
                'sql.Append("            ,@P3                                    ")
                'sql.Append("            ,@P6                                    ")
                'sql.Append("            ,GETDATE()                              ")
                'sql.Append("            ,@P6                                    ")
                'sql.Append("            ,GETDATE()                            ")

                'dbm.SetCommandText(sql.ToString)
                'dbm.AddParameterChar("P1", barcodeNo)
                'dbm.AddParameterChar("P2", warehouseCd)
                'dbm.AddParameterChar("P3", itemCd)
                'dbm.AddParameterChar("P4", statusFlg)
                'dbm.AddParameterChar("P5", rackCd)
                'dbm.AddParameterChar("P6", Me.UserId)

                'row = dbm.ExecuteNonQuery
                'dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function ProductInfoInquiry(ByVal itemCdList As List(Of String), ByVal woNoList As List(Of String), _
                                           ByVal woDateList As List(Of String), ByVal totalBoxList As List(Of String), _
                                           ByVal qtyPerBoxList As List(Of String), ByVal productQuantityList As List(Of String), _
                                           ByVal loginCode As String) As String
            '// WriteStartLog()
            Dim row As Integer = 0
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As String = ""
            Dim rs As String = ""
            Dim barcodeNo As String = ""
            Dim lotNo As String = ""
            Dim curBox As Integer = 0
            Dim boxNumber As Integer = 0
            Dim quantity As Integer = 0
            Dim da As DataTable
            Dim itemName As String = ""

            Dim unit As String = ""
            Dim tempType As Integer = 0
            Dim orotexNo As String = ""
            Dim imagePath1 As String = ""
            Dim imagePath2 As String = ""
            Dim imagePath3 As String = ""
            Dim imagePath4 As String = ""
            Dim imagePath5 As String = ""

            Try
                dbm.Connect()
                For i As Integer = 0 To woNoList.Count - 1 Step 1
                    da = Nothing
                    da = GetItemInfoByCdDbm(itemCdList(i), dbm).Tables(0)
                    itemName = da.Rows(0)("ITEM_NM").ToString
                    'curBox = GetCurrentBoxNumberByDbm(itemCdList(i), dbm)

                    unit = da.Rows(0)("UNIT").ToString
                    tempType = da.Rows(0)("TEMP_TYPE").ToString
                    orotexNo = da.Rows(0)("OROTEX_NO").ToString
                    imagePath1 = da.Rows(0)("IMG_PATH1").ToString
                    imagePath2 = da.Rows(0)("IMG_PATH2").ToString
                    imagePath3 = da.Rows(0)("IMG_PATH3").ToString
                    imagePath4 = da.Rows(0)("IMG_PATH4").ToString
                    imagePath5 = da.Rows(0)("IMG_PATH5").ToString

                    'Get current box of item of wo no
                    curBox = GetCurrentBoxNumberByDbm(itemCdList(i), dbm)
                    boxNumber = curBox

                    If Not sql.Equals("") Then
                        sql = sql & vbCrLf
                    End If

                    For j As Integer = 1 To Integer.Parse(totalBoxList(i)) Step 1
                        boxNumber += 1
                        If boxNumber = 10000 Then
                            boxNumber = 1
                        End If
                        'Set barcode
                        barcodeNo = woNoList(i) & boxNumber.ToString("0000")

                        'Set Lot No
                        lotNo = woNoList(i).Substring(woNoList(i).Length - 5) & "-" & DateTime.Parse(woDateList(i)).ToString("yyyyMMdd")

                        '' Calculate quantity is mod different zero.
                        quantity = Integer.Parse(qtyPerBoxList(i))
                        If j = Integer.Parse(totalBoxList(i)) Then
                            If Integer.Parse(productQuantityList(i)) Mod Integer.Parse(qtyPerBoxList(i)) <> 0 Then
                                quantity = Integer.Parse(productQuantityList(i)) Mod Integer.Parse(qtyPerBoxList(i))
                            End If
                        End If

                        'Insert new barcode to ITEM DETAIL MASTER
                        sql = sql & vbCrLf & InsertItemDtlInfoToString(itemCdList(i), boxNumber.ToString("0000"), barcodeNo, quantity, lotNo, woNoList(i), woDateList(i), loginCode)

                        'Insert new barcode for MOLD warehouse
                        sql = sql & vbCrLf & InsertWarehouseTrInfoToString(barcodeNo, "MOLD", "", itemCdList(i), Me.UserId)

                        'Insert new into warehouse history with status is 0
                        sql = sql & vbCrLf & InsertWarehouseHistTrInfoToString(barcodeNo, "MOLD", itemCdList(i), 0, "")

                    Next
                    'Update issue flag in PRODUCT INFO TR
                    sql = sql & vbCrLf & UpdateIssueFlagToString(woNoList(i), 1)

                    'Update current box number for item
                    sql = sql & vbCrLf & UpdateCurrentBoxNumberToString(itemCdList(i), boxNumber.ToString("0000"))

                    'Execute product inquiry
                    dbm.SetCommandText(sql)
                    dbm.ExecuteNonQuery()
                Next
                dbm.Commit()
                Return rs
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' InsertWarehouseHistTrInfoToString
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="warehouseCd"></param>
        ''' <param name="itemCd"></param>
        ''' <param name="statusFlg"></param>
        ''' <param name="rackCd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertWarehouseHistTrInfoToString(ByVal barcodeNo As String, _
                                        ByVal warehouseCd As String, _
                                        ByVal itemCd As String, _
                                        ByVal statusFlg As Integer, _
                                        ByVal rackCd As String) As String
            Dim rackName As String
            Dim itemName As String

            If rackCd.Equals("") Then
                rackName = ""
            Else
                rackName = GetRackInfoByCd(rackCd, 1).Tables(0).Rows(0)("RACK_NM").ToString
            End If
            itemName = GetItemInfoByCd(itemCd).Tables(0).Rows(0)("ITEM_NM").ToString
            If itemCd Is Nothing Then
                itemName = ""
            End If
            Dim sql As New StringBuilder
            sql.Append("INSERT INTO WH_HIST_INFO_TR ")
            sql.Append("([BC_NO]")
            sql.Append(" , [HIST_NO]")
            sql.Append(" , [STATUS_FLG] ")
            sql.Append(" , [WH_CD]")
            sql.Append(" , [RACK_CD]")
            sql.Append(" , [RACK_NM]")
            sql.Append(" , [ITEM_CD]")
            sql.Append(" , [ITEM_NM]")
            sql.Append(" , [REG_USER_CD]")
            sql.Append(" , [REG_DT]")
            sql.Append(" , [UPD_USER_CD]")
            sql.Append(" , [UPD_DT]) ")
            sql.Append(" SELECT ")
            sql.AppendFormat("'{0}' ", barcodeNo)
            sql.Append(" ,(SELECT (COALESCE(MAX(HIST_NO), 0) + 1) ")
            sql.Append(" FROM WH_HIST_INFO_TR ")
            sql.AppendFormat("WHERE BC_NO = '{0}') ", barcodeNo)
            sql.AppendFormat(" ,{0} ", statusFlg)
            sql.AppendFormat(" ,'{0}' ", warehouseCd)
            sql.AppendFormat(" ,'{0}' ", rackCd)
            sql.AppendFormat(" ,'{0}' ", rackName)
            sql.AppendFormat(" ,'{0}' ", itemCd)
            sql.AppendFormat(" ,'{0}' ", itemName)
            sql.AppendFormat(" ,'{0}' ", Me.UserId)
            sql.Append(" ,GETDATE() ")
            sql.AppendFormat(" ,'{0}' ", Me.UserId)
            sql.Append(" ,GETDATE() ")

            'dbm.SetCommandText(sql.ToString)
            'dbm.AddParameterChar("P1", barcodeNo)
            'dbm.AddParameterChar("P2", warehouseCd)
            'dbm.AddParameterChar("P3", itemCd)
            'dbm.AddParameterChar("P4", statusFlg)
            'dbm.AddParameterChar("P5", rackCd)
            'dbm.AddParameterChar("P6", Me.UserId)                
            Return sql.ToString
        End Function

#End Region

#Region "BATCH 018 Shipment Req Detail Process"

        ''' <summary>
        ''' Func Name: GetShipmentReqDetailByCd
        ''' </summary>
        ''' <param name="shipmentReqNo"></param>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Public Function GetShipmentReqDetailByCd(ByVal shipmentReqNo As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT A.PALLET_NO")
                sql.Append("       ,A.BC_NO")
                sql.Append("       ,C.LOT_NO")
                sql.Append("       ,B.RACK_CD") 'Kaidai 182: Add "RACK NO" in Gridview.
                sql.Append("       ,B.WH_CD")
                sql.Append("       ,C.ITEM_CD")
                sql.Append("       ,D.ITEM_NM")
                sql.Append("       ,C.QTY")
                sql.Append("       ,A.SCAN_FLG")
                sql.Append(" FROM SHIP_REQ_DTL_INFO_TR AS A")
                sql.Append(" INNER JOIN ITEM_DTL_MS AS C")
                sql.Append("   ON C.BC_NO = A.BC_NO")
                sql.Append(" INNER JOIN WH_INFO_TR AS B")
                sql.Append("   ON B.BC_NO = C.BC_NO")
                sql.Append(" INNER JOIN ITEM_MASTER_MS AS D")
                sql.Append("   ON D.ITEM_CD = C.ITEM_CD")
                sql.Append(" WHERE A.SHIP_REQ_NO = @P1")
                sql.Append(" ORDER BY A.PALLET_NO ASC, A.BC_NO ASC") 'Kaidai 184: Sort Pallet, Barcode Asc.

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", shipmentReqNo)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function DeleteShipmentReqDtlInfoTrByCd(ByVal shipReqNo As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                dbm.Connect()

                sqlBuf.Append(" DELETE FROM SHIP_REQ_DTL_INFO_TR ")
                sqlBuf.Append(" WHERE SHIP_REQ_NO = @P1 ")

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", shipReqNo)

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function InsertShipmentReqDtlInfoTr(ByVal shipReqNo As String, _
                                     ByVal barcodeNo As String, _
                                     ByVal palletNo As String, _
                                     ByVal scanFlag As Integer) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                dbm.Connect()

                sqlBuf.Append(" INSERT INTO SHIP_REQ_DTL_INFO_TR")
                sqlBuf.Append("            ([SHIP_REQ_NO]       ")
                sqlBuf.Append("            ,[BC_NO]             ")
                sqlBuf.Append("            ,[PALLET_NO]         ")
                sqlBuf.Append("            ,[SCAN_FLG]          ")
                sqlBuf.Append("            ,[REG_USER_CD]       ")
                sqlBuf.Append("            ,[REG_DT]            ")
                sqlBuf.Append("            ,[UPD_USER_CD]       ")
                sqlBuf.Append("            ,[UPD_DT])           ")
                sqlBuf.Append("      VALUES                     ")
                sqlBuf.Append("            (@P1                 ")
                sqlBuf.Append("            ,@P2                 ")
                sqlBuf.Append("            ,@P3                 ")
                sqlBuf.Append("            ,@P4                 ")
                sqlBuf.Append("            ,@P5                 ")
                sqlBuf.Append("            ,GETDATE()           ")
                sqlBuf.Append("            ,@P5                 ")
                sqlBuf.Append("            ,GETDATE())          ")

                dbm.SetCommandText(sqlBuf.ToString)

                dbm.AddParameterChar("P1", shipReqNo)
                dbm.AddParameterChar("P2", barcodeNo)
                dbm.AddParameter("P3", palletNo)
                dbm.AddParameterChar("P4", scanFlag)
                dbm.AddParameter("P5", Me.UserId)

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BATCH 019 Shipment Act Detail Process"

        ''' <summary>
        ''' Func Name: GetShipmentActDetailByCd
        ''' </summary>
        ''' <param name="shipmentReqNo"></param>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Public Function GetShipmentActDetailByCd(ByVal shipmentReqNo As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT A.PALLET_NO")
                sql.Append("       ,A.BC_NO")
                sql.Append("       ,C.LOT_NO")
                sql.Append("       ,B.RACK_CD") 'Kaidai 182: Add "RACK NO" in gridview.
                sql.Append("       ,B.WH_CD")
                sql.Append("       ,B.ITEM_CD")
                sql.Append("       ,B.ITEM_NM")
                sql.Append("       ,C.QTY")
                sql.Append("       ,1 AS SCAN_FLG")
                sql.Append(" FROM SHIP_ACT_DTL_INFO_TR AS A")
                sql.Append(" INNER JOIN ITEM_DTL_MS AS C")
                sql.Append("   ON C.BC_NO = A.BC_NO")
                sql.Append(" INNER JOIN WH_HIST_INFO_TR AS B")
                sql.Append("   ON B.BC_NO = A.BC_NO")
                sql.Append(" WHERE A.SHIP_REQ_NO = @P1")
                sql.Append("   AND B.STATUS_FLG = 7")
                sql.Append("   AND A.SHIP_REQ_NO = B.SHIP_REQ_NO")
                sql.Append(" ORDER BY A.PALLET_NO ASC, A.BC_NO ASC") 'Kaidai 184: Sort Pallet, Barcode Asc.

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", shipmentReqNo)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function GetAvaiableBarcodeByItemCd(ByVal itemCode As String, ByVal barcode As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                Dim query As String = ""
                query = query & "SELECT A.BC_NO, A.LOT_NO, A.QTY, C.WH_CD, B.ITEM_CD, C.RACK_CD " 'Kaidai 182: Add "RACK NO" in Gridview.
                query = query & "FROM   ITEM_DTL_MS AS A, "
                query = query & "       ITEM_MASTER_MS AS B, "
                query = query & "       WH_INFO_TR AS C "
                query = query & "WHERE  A.ITEM_CD = B.ITEM_CD "
                query = query & "  AND  A.BC_NO = C.BC_NO "
                query = query & "  AND  C.ITEM_CD = @P1 "
                query = query & "  AND  C.BC_NO NOT IN (SELECT DISTINCT BC_NO FROM SHIP_REQ_DTL_INFO_TR)"
                query = query & "  AND  C.WH_CD = 'W830' "
                If Not barcode.Equals(String.Empty) Then
                    query = query & "  AND  C.BC_NO NOT IN (" & barcode & ")"
                End If
                query = query & "ORDER BY A.BC_NO ASC"
                'query = query & "  AND  C.RACK_CD <> '' " '// Not check rack code is null

                dbm.SetCommandText(query)
                dbm.AddParameterChar("P1", itemCode)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' InsertShipmentActDtlInfoTr
        ''' </summary>
        ''' <param name="shipReqNo"></param>
        ''' <param name="barcodeNo"></param>
        ''' <param name="palletNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertShipmentActDtlInfoTr(ByVal shipReqNo As String, _
                                        ByVal barcodeNo As String, _
                                        ByVal palletNo As String) As Integer
            '// WriteStartLog()

            Dim row As Integer = 0
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()
                sql.Append(" INSERT INTO SHIP_ACT_DTL_INFO_TR")
                sql.Append("            ([SHIP_REQ_NO]       ")
                sql.Append("            ,[BC_NO]             ")
                sql.Append("            ,[PALLET_NO]         ")
                sql.Append("            ,[REG_USER_CD]       ")
                sql.Append("            ,[REG_DT]            ")
                sql.Append("            ,[UPD_USER_CD]       ")
                sql.Append("            ,[UPD_DT])           ")
                sql.Append("      VALUES                     ")
                sql.Append("            (@P1                 ")
                sql.Append("            ,@P2                 ")
                sql.Append("            ,@P3                 ")
                sql.Append("            ,@P4                 ")
                sql.Append("            ,GETDATE()           ")
                sql.Append("            ,@P4                 ")
                sql.Append("            ,GETDATE())          ")

                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", shipReqNo)
                dbm.AddParameterChar("P2", barcodeNo)
                dbm.AddParameterChar("P3", palletNo)
                dbm.AddParameterChar("P4", Me.UserId)

                row = dbm.ExecuteNonQuery
                dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

#End Region

#Region "BAT020_StockDeleteFGProcess"

        ''' <summary>
        ''' ChkStkDelBarcodeExist
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function ChkStkDelBarcodeExist(ByVal barcodeNo As String, _
                                              ByVal whCd As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                ds.Tables(0).Columns.Add("RACKCD")
                '' (1) : Check exist barcode 
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(TR.BC_NO)")
                sqlBuf1.Append("   FROM WH_INFO_TR AS TR")
                sqlBuf1.Append("  WHERE ")
                sqlBuf1.Append("        TR.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' AIT) 2015/03/31 cuongtk - start.
                ds.Tables(0).Rows.Clear()
                Dim sqlBuf2 As New StringBuilder()
                sqlBuf2.Append("SELECT COUNT(TR.BC_NO) ")
                sqlBuf2.Append("FROM   WH_INFO_TR AS TR ")
                sqlBuf2.Append("WHERE  TR.BC_NO = @P1 ")
                sqlBuf2.Append("  AND  TR.WH_CD = @P2 ")
                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)
                dbm.AddParameterChar("P2", whCd)

                Dim rs2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                If rs2 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If
                '' AIT) 2015/03/31 cuongtk - end.

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM, TR.RACK_CD")
                sqlBuf3.Append("   FROM ITEM_MASTER_MS AS MST, ITEM_DTL_MS AS DTL, WH_INFO_TR AS TR")
                sqlBuf3.Append("  WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append("    AND DTL.BC_NO = @P1")
                sqlBuf3.Append("    AND DTL.BC_NO = TR.BC_NO")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    ds.Tables(0).Rows(0).Item(3) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    ds.Tables(0).Rows(0).Item(3) = dtTable.Rows(0).Item("RACK_CD").ToString()
                    Return ds
                End If
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' StockDelete900
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="rackNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StockDeleteW900(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackNo As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" DELETE WH_INFO_TR ")
                sqlBuf.Append(" WHERE BC_NO = @P1")
                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                rackNo = "" 'Stock Delete --> rackNo = null
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,RACK_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P8")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 10)  'Stock Delete W900
                dbm.AddParameter("P4", " ")
                dbm.AddParameter("P5", rackNo)
                dbm.AddParameter("P6", itemCode)
                dbm.AddParameter("P7", UserId)
                dbm.AddParameter("P8", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>>
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function



        ''' <summary>
        ''' StockDeleteW830
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="rackNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StockDeleteW830(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackNo As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            ''<<20150130 Phungntm start
            Dim dtTable As New DataTable
            ''>>
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)

                ' update WH_INFO_TR
                sqlBuf.Append(" DELETE WH_INFO_TR ")
                sqlBuf.Append(" WHERE BC_NO = @P1")
                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                rackNo = "" 'Stock Delete --> rackNo = null
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,RACK_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P8")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 9)   'Stock Delete W830
                dbm.AddParameter("P4", " ")
                dbm.AddParameter("P5", rackNo)
                dbm.AddParameter("P6", itemCode)
                dbm.AddParameter("P7", UserId)
                dbm.AddParameter("P8", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>>
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "BATCH 022 Warehouse Process"

        ''' <summary>
        ''' Func Name: GetWarehouseInfoByCd
        ''' </summary>
        ''' <param name="whCode"></param>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Public Function GetWarehouseInfoByCd(ByVal whCode As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT WH.* ")
                sql.Append(" FROM   WH_MASTER_MS AS WH ")
                sql.Append(" WHERE  WH.WH_CD = @P1")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", whCode)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

#End Region

#Region " BATCH 023 Item Detail Process"
        ''' <summary>
        ''' Sub Name: InsertItemDtlInfo
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <param name=" barcodeNo"></param>
        ''' <param name=" boxNumber"></param>
        ''' <param name=" lotNo"></param>
        ''' <param name=" woNo"></param>
        ''' <remarks></remarks>
        Public Function InsertItemDtlInfo(ByVal itemCode As String, _
                                                                ByVal boxNumber As String, _
                                                                ByVal barcodeNo As String, _
                                                                ByVal qty As String, _
                                                                ByVal lotNo As String, _
                                                                ByVal woNo As String, _
                                                                ByVal woDate As String, _
                                                                ByVal loginId As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder
            Dim ret As Integer = 0

            Try
                dbm.Connect()

                sql.Append("INSERT ITEM_DTL_MS (")
                sql.Append(" ITEM_CD, ")
                sql.Append(" BOX_NUM, ")
                sql.Append(" BC_NO, ")
                sql.Append(" [QTY], ")
                sql.Append(" LOT_NO, ")
                sql.Append(" WO_NO, ")
                sql.Append(" WO_DT, ")
                sql.Append(" SHIP_FLG, ")
                sql.Append(" EXP_FLG, ")
                sql.Append(" REG_USER_CD, ")
                sql.Append(" REG_DT, ")
                sql.Append(" UPD_USER_CD, ")
                sql.Append(" UPD_DT")
                sql.Append(") VALUES (")
                sql.AppendFormat(" '{0}', ", itemCode)
                sql.AppendFormat(" '{0}', ", boxNumber)
                sql.AppendFormat(" '{0}', ", barcodeNo)
                sql.AppendFormat(" {0}, ", qty)
                sql.AppendFormat(" '{0}', ", lotNo)
                sql.AppendFormat(" '{0}', ", woNo)
                sql.AppendFormat("CONVERT(datetime, '{0}', 120) , ", woDate)
                sql.Append("0, ")
                sql.Append("1, ")
                sql.AppendFormat("'{0}', ", loginId)
                sql.Append("GETDATE(), ")
                sql.Append("'' ,")
                sql.Append("'' )")
                dbm.SetCommandText(sql.ToString)

                ret = dbm.ExecuteNonQuery
                dbm.Commit()
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
        ''' <summary>
        ''' Sub Name: InsertItemDtlInfoToString
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <param name=" barcodeNo"></param>
        ''' <param name=" boxNumber"></param>
        ''' <param name=" lotNo"></param>
        ''' <param name=" woNo"></param>
        ''' <remarks></remarks>
        Public Function InsertItemDtlInfoToString(ByVal itemCode As String, _
                                                                ByVal boxNumber As String, _
                                                                ByVal barcodeNo As String, _
                                                                ByVal qty As String, _
                                                                ByVal lotNo As String, _
                                                                ByVal woNo As String, _
                                                                ByVal woDate As String, _
                                                                ByVal loginId As String) As String

            Dim sql As New StringBuilder
            sql.Append("INSERT ITEM_DTL_MS (")
            sql.Append(" ITEM_CD, ")
            sql.Append(" BOX_NUM, ")
            sql.Append(" BC_NO, ")
            sql.Append(" [QTY], ")
            sql.Append(" LOT_NO, ")
            sql.Append(" WO_NO, ")
            sql.Append(" WO_DT, ")
            sql.Append(" SHIP_FLG, ")
            sql.Append(" EXP_FLG, ")
            sql.Append(" REG_USER_CD, ")
            sql.Append(" REG_DT, ")
            sql.Append(" UPD_USER_CD, ")
            sql.Append(" UPD_DT")
            sql.Append(") VALUES (")
            sql.AppendFormat(" '{0}', ", itemCode)
            sql.AppendFormat(" '{0}', ", boxNumber)
            sql.AppendFormat(" '{0}', ", barcodeNo)
            sql.AppendFormat(" {0}, ", qty)
            sql.AppendFormat(" '{0}', ", lotNo)
            sql.AppendFormat(" '{0}', ", woNo)
            'sql.AppendFormat("CONVERT(datetime, '{0}', 120) , ", woDate)
            sql.AppendFormat(" '{0}', ", DateTime.Parse(woDate))
            sql.Append("0, ")
            sql.Append("1, ")
            sql.AppendFormat("'{0}', ", loginId)
            sql.Append("GETDATE(), ")
            sql.AppendFormat("'{0}', ", loginId)
            sql.Append("GETDATE()) ")

            Return sql.ToString
        End Function

        ''' <summary>
        ''' UpdateItemDtlInfoShipFlag
        ''' </summary>
        ''' <param name="shipFlg"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateItemDtlInfoShipFlag(ByVal barcodeNo As String, _
                                                ByVal shipFlg As Integer) As Integer
            '// WriteStartLog()

            Dim row As Integer = 0
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" UPDATE ITEM_DTL_MS          ")
                sql.Append("    SET [SHIP_FLG] = @P2     ")
                sql.Append("       ,[UPD_USER_CD] = @P3  ")
                sql.Append("       ,[UPD_DT] = GETDATE() ")
                sql.Append("  WHERE BC_NO = @P1          ")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", barcodeNo)
                dbm.AddParameterChar("P2", shipFlg)
                dbm.AddParameterChar("P3", Me.UserId)

                row = dbm.ExecuteNonQuery
                dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function GetNewBoxList(ByVal exportedWoNoCount As Integer) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.AppendFormat("SELECT TOP {0} ", exportedWoNoCount)
                sql.Append("B.TEMP_TYPE AS 'Pattern Type', ")
                sql.Append("A.BC_NO AS 'Barcode No', ")
                sql.Append("A.LOT_NO AS 'Lot No', ")
                sql.Append("A.ITEM_CD AS 'Part No', ")
                sql.Append("B.ITEM_NM AS 'Part Name', ")
                sql.Append("A.BOX_NUM AS 'Box No', ")
                sql.Append("A.QTY AS 'Qty/Box', ")
                'sql.Append("B.UNIT AS 'Unit', ")
                sql.Append("CASE WHEN B.UNIT = '1' THEN 'Pcs' END AS 'Unit', ")
                sql.Append("B.OROTEX_NO AS 'OROTEX NO', ")
                sql.Append("B.IMG_PATH1 AS 'Image Path 1', ")
                sql.Append("B.IMG_PATH2 AS 'Image Path 2', ")
                sql.Append("B.IMG_PATH3 AS 'Image Path 3', ")
                sql.Append("B.IMG_PATH4 AS 'Image Path 4', ")
                sql.Append("B.IMG_PATH5 AS 'Image Path 5' ")
                sql.Append("FROM ITEM_DTL_MS A, ITEM_MASTER_MS B ")
                sql.Append("WHERE A.ITEM_CD=B.ITEM_CD ")
                sql.Append("ORDER BY A.REG_DT DESC ")

                dbm.SetCommandText(sql.ToString)
                'dbm.AddParameterChar("P1", exportedWoNoCount)

                ds = dbm.ExecuteDataSetFill
                dbm.Commit()
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try

        End Function
#End Region

#Region "BATCH 024 Shipment Process"

        ''' <summary>
        ''' Func Name: GetShipmentInfoByShipmentReqNo
        ''' </summary>
        ''' <param name="shipmentReqNo">shipmentReqNo = Empty: Ignore condition</param>
        ''' <param name="customerId">customerId = Empty: Ignore condition</param>
        ''' <param name="shipmentDateFrom">shipmentDateFrom = Date.MinValue : Ignore condition</param>
        ''' <param name="shipmentDateTo">shipmentDateTo = Date.MinValue : Ignore condition</param>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Public Function GetShipmentInfoByShipmentReqNo(ByVal shipmentReqNo As String, _
                                                       ByVal customerId As String, _
                                                       ByVal shipmentDateFrom As Date, _
                                                       ByVal shipmentDateTo As Date) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT SH.*, B.CUS_NM ")
                sql.Append(" FROM   SHIP_REQ_INFO_TR AS SH, ")
                sql.Append("        CUS_MASTER_MS AS B ")
                sql.Append(" WHERE  SH.CUS_ID = B.CUS_ID ")

                If Not String.IsNullOrEmpty(shipmentReqNo) Then
                    sql.Append("   AND  SH.SHIP_REQ_NO = @P1")
                End If

                If Not String.IsNullOrEmpty(customerId) Then
                    sql.Append("   AND  SH.CUS_ID = @P2")
                End If

                If Not Date.MinValue.Equals(shipmentDateFrom) Then
                    sql.Append(" AND  CONVERT(varchar(8),SH.SHIP_DT,112) >= @P3")
                End If

                If Not Date.MinValue.Equals(shipmentDateTo) Then
                    sql.Append(" AND  CONVERT(varchar(8),SH.SHIP_DT,112) <= @P4")
                End If

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", shipmentReqNo)
                dbm.AddParameterChar("P2", customerId)
                dbm.AddParameterChar("P3", shipmentDateFrom.ToString("yyyyMMdd"))
                dbm.AddParameterChar("P4", shipmentDateTo.ToString("yyyyMMdd"))

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        Public Function DeleteShipmentReqInfoTrByCd(ByVal shipReqNo As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                dbm.Connect()

                sqlBuf.Append(" DELETE FROM SHIP_REQ_INFO_TR ")
                sqlBuf.Append(" WHERE SHIP_REQ_NO = @P1 ")
                sqlBuf.Append(vbCrLf)
                sqlBuf.Append(" DELETE FROM SHIP_REQ_DTL_INFO_TR ")
                sqlBuf.Append(" WHERE SHIP_REQ_NO = @P1 ")

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", shipReqNo)

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function InsertShipReqInfoTr(ByVal shipReqDate As Date, _
                                     ByVal shipDate As Date, _
                                     ByVal cusID As String, _
                                     ByVal cusPo As String, _
                                     ByVal invoiceNo As String, _
                                     ByVal invoiceDate As Date) As String
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                Dim newShipReqNo As String = GetNextShipReqNo()

                dbm.Connect()

                sqlBuf.Append(" INSERT INTO SHIP_REQ_INFO_TR")
                sqlBuf.Append("            ([SHIP_REQ_NO]     ")
                sqlBuf.Append("            ,[COMP_FLG]        ")
                sqlBuf.Append("            ,[CUS_ID]          ")
                sqlBuf.Append("            ,[PRINT_FLG]       ")
                sqlBuf.Append("            ,[SHIP_REQ_DT]     ")
                sqlBuf.Append("            ,[SHIP_DT]         ")
                sqlBuf.Append("            ,[INVOICE_NO]      ")
                sqlBuf.Append("            ,[INVOICE_DT]      ")
                sqlBuf.Append("            ,[CUS_PO]          ")
                sqlBuf.Append("            ,[REG_USER_CD]     ")
                sqlBuf.Append("            ,[REG_DT]          ")
                sqlBuf.Append("            ,[UPD_USER_CD]     ")
                sqlBuf.Append("            ,[UPD_DT])         ")
                sqlBuf.Append("      VALUES                   ")
                sqlBuf.Append("            (@P1               ")
                sqlBuf.Append("            ,0                 ")
                sqlBuf.Append("            ,@P4               ")
                sqlBuf.Append("            ,0                 ")
                sqlBuf.Append("            ,@P2               ")
                sqlBuf.Append("            ,@P3               ")
                sqlBuf.Append("            ,@P6               ")
                sqlBuf.Append("            ,@P7               ")
                sqlBuf.Append("            ,@P5               ")
                sqlBuf.Append("            ,@P8               ")
                sqlBuf.Append("            ,GETDATE()         ")
                sqlBuf.Append("            ,@P8               ")
                sqlBuf.Append("            ,GETDATE())        ")

                dbm.SetCommandText(sqlBuf.ToString)

                dbm.AddParameterChar("P1", newShipReqNo)
                dbm.AddParameterChar("P2", shipReqDate.Date)
                dbm.AddParameter("P3", shipDate.Date)
                dbm.AddParameterChar("P4", cusID)
                dbm.AddParameter("P5", cusPo)
                dbm.AddParameter("P6", invoiceNo)
                dbm.AddParameter("P7", invoiceDate.Date)
                dbm.AddParameterChar("P8", Me.UserId)

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                If row = 1 Then
                    Return newShipReqNo
                Else
                    Return String.Empty
                End If
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function InsertShipReqInfoTrWithDetail(ByVal shipReqDate As Date, _
                                     ByVal shipDate As Date, _
                                     ByVal cusID As String, _
                                     ByVal cusPo As String, _
                                     ByVal invoiceNo As String, _
                                     ByVal invoiceDate As Date, _
                                     ByVal detailDt As DataTable) As String
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                Dim newShipReqNo As String = GetNextShipReqNo()

                dbm.Connect()

                sqlBuf.Append(" INSERT INTO SHIP_REQ_INFO_TR")
                sqlBuf.Append("            ([SHIP_REQ_NO]     ")
                sqlBuf.Append("            ,[COMP_FLG]        ")
                sqlBuf.Append("            ,[CUS_ID]          ")
                sqlBuf.Append("            ,[PRINT_FLG]       ")
                sqlBuf.Append("            ,[SHIP_REQ_DT]     ")
                sqlBuf.Append("            ,[SHIP_DT]         ")
                sqlBuf.Append("            ,[INVOICE_NO]      ")
                sqlBuf.Append("            ,[INVOICE_DT]      ")
                sqlBuf.Append("            ,[CUS_PO]          ")
                sqlBuf.Append("            ,[REG_USER_CD]     ")
                sqlBuf.Append("            ,[REG_DT]          ")
                sqlBuf.Append("            ,[UPD_USER_CD]     ")
                sqlBuf.Append("            ,[UPD_DT])         ")
                sqlBuf.Append("      VALUES                   ")
                sqlBuf.Append("            (@P1               ")
                sqlBuf.Append("            ,0                 ")
                sqlBuf.Append("            ,@P4               ")
                sqlBuf.Append("            ,0                 ")
                sqlBuf.Append("            ,@P2               ")
                sqlBuf.Append("            ,@P3               ")
                sqlBuf.Append("            ,@P6               ")
                sqlBuf.Append("            ,@P7               ")
                sqlBuf.Append("            ,@P5               ")
                sqlBuf.Append("            ,@P8               ")
                sqlBuf.Append("            ,GETDATE()         ")
                sqlBuf.Append("            ,@P8               ")
                sqlBuf.Append("            ,GETDATE())        ")
                Dim sqlInsertMaster As String = sqlBuf.ToString

                Dim sqlInsertDetail As String = String.Empty
                Dim listDetailParams As New List(Of Dictionary(Of String, Object))
                Dim detailParam As Dictionary(Of String, Object) = Nothing
                Dim rowDetail As DataRow = Nothing
                For i As Integer = 0 To detailDt.Rows.Count - 1 Step 1
                    sqlInsertDetail += vbCrLf
                    sqlBuf = New StringBuilder
                    detailParam = New Dictionary(Of String, Object)
                    rowDetail = detailDt.Rows(i)

                    sqlBuf.Append(" INSERT INTO SHIP_REQ_DTL_INFO_TR")
                    sqlBuf.Append("            ([SHIP_REQ_NO]       ")
                    sqlBuf.Append("            ,[BC_NO]             ")
                    sqlBuf.Append("            ,[PALLET_NO]         ")
                    sqlBuf.Append("            ,[SCAN_FLG]          ")
                    sqlBuf.Append("            ,[REG_USER_CD]       ")
                    sqlBuf.Append("            ,[REG_DT]            ")
                    sqlBuf.Append("            ,[UPD_USER_CD]       ")
                    sqlBuf.Append("            ,[UPD_DT])           ")
                    sqlBuf.Append("      VALUES                     ")
                    sqlBuf.Append("            (@P1                 ")
                    sqlBuf.AppendFormat("      ,@P_BC_NO{0}         ", i)
                    sqlBuf.AppendFormat("      ,@P_PALLET_NO{0}     ", i)
                    sqlBuf.AppendFormat("      ,@P_SCAN_FLG{0}      ", i)
                    sqlBuf.Append("            ,@P8                 ")
                    sqlBuf.Append("            ,GETDATE()           ")
                    sqlBuf.Append("            ,@P8                 ")
                    sqlBuf.Append("            ,GETDATE())          ")

                    sqlInsertDetail += sqlBuf.ToString

                    detailParam.Add(String.Format("P_BC_NO{0}", i), rowDetail("BC_NO"))
                    detailParam.Add(String.Format("P_PALLET_NO{0}", i), rowDetail("PALLET_NO"))
                    detailParam.Add(String.Format("P_SCAN_FLG{0}", i), rowDetail("SCAN_FLG"))
                    listDetailParams.Add(detailParam)
                Next

                dbm.SetCommandText(sqlInsertMaster & sqlInsertDetail)

                dbm.AddParameterChar("P1", newShipReqNo)
                '// dbm.AddParameterChar("P2", shipReqDate.Date)
                dbm.AddParameter("P2", shipReqDate)
                '// dbm.AddParameter("P3", shipDate.Date)
                dbm.AddParameter("P3", shipDate)
                dbm.AddParameterChar("P4", cusID)
                dbm.AddParameter("P5", cusPo)
                dbm.AddParameter("P6", invoiceNo)
                '// dbm.AddParameter("P7", invoiceDate.Date)
                dbm.AddParameter("P7", invoiceDate)
                dbm.AddParameterChar("P8", Me.UserId)
                For Each dictParam As Dictionary(Of String, Object) In listDetailParams
                    For Each param As KeyValuePair(Of String, Object) In dictParam
                        dbm.AddParameterChar(param.Key, param.Value)
                    Next
                Next

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                If row > 0 Then
                    Return newShipReqNo
                Else
                    Return String.Empty
                End If
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' GetNextShipReqNo = yyMMxxxxxx
        ''' </summary>
        ''' <returns>String</returns>
        ''' <remarks></remarks>
        Private Function GetNextShipReqNo() As String
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder()
                sqlBuf.Append(" SELECT SUBSTRING(convert(varchar, getdate(), 112),3,4)")
                sqlBuf.Append("     + (REPLACE(STR(COALESCE(MAX(RIGHT(SHIP_REQ_NO,6)),0)+1, 6), SPACE(1), '0'))")
                sqlBuf.Append(" FROM SHIP_REQ_INFO_TR")
                sqlBuf.Append(" WHERE LEFT(SHIP_REQ_NO,4) = SUBSTRING(convert(varchar, getdate(), 112),3,4)")

                dbm.SetCommandText(sqlBuf.ToString())

                Dim newShipReqNo As String = dbm.ExecuteScalar()

                Return newShipReqNo
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try

        End Function

        Public Function UpdateShipReqInfoTr(ByVal shipReqNo As String, _
                                     ByVal shipReqDate As Date, _
                                     ByVal shipDate As Date, _
                                     ByVal cusID As String, _
                                     ByVal cusPo As String, _
                                     ByVal invoiceNo As String, _
                                     ByVal invoiceDate As Date) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                Dim row As Integer = 0

                sql.Append(" UPDATE SHIP_REQ_INFO_TR     ")
                sql.Append("    SET [SHIP_REQ_DT] = @P2  ")
                sql.Append("       ,[SHIP_DT] = @P3      ")
                sql.Append("       ,[CUS_ID] = @P4       ")
                sql.Append("       ,[CUS_PO] = @P5       ")
                sql.Append("       ,[INVOICE_NO] = @P6   ")
                sql.Append("       ,[INVOICE_DT] = @P7   ")
                sql.Append("       ,[UPD_USER_CD] = @P8  ")
                sql.Append("       ,[UPD_DT] = GETDATE() ")
                sql.Append("  WHERE [SHIP_REQ_NO] = @P1  ")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", shipReqNo)
                dbm.AddParameterChar("P2", shipReqDate.Date)
                dbm.AddParameter("P3", shipDate.Date)
                dbm.AddParameterChar("P4", cusID)
                dbm.AddParameter("P5", cusPo)
                dbm.AddParameter("P6", invoiceNo)
                dbm.AddParameter("P7", invoiceDate.Date)
                dbm.AddParameterChar("P8", Me.UserId)

                row = dbm.ExecuteNonQuery
                dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function UpdateShipReqInfoTrWithDetail(ByVal shipmentRequestNo As String, ByVal shipmentRequestDate As Date, ByVal shipmentDate As Date, ByVal customerId As String, ByVal customerPo As String, ByVal invoiceNo As String, ByVal invoiceDate As Date, ByVal listData As List(Of String), ByVal registeredId As String) As Integer
            Dim webDbmanager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim updateNo As Integer = 0
            Dim deleteNo As Integer = 0
            Dim insertNo As Integer = 0

            Try
                webDbmanager.Connect()

                sqlBuilder.Append(" UPDATE ")
                sqlBuilder.Append("   SHIP_REQ_INFO_TR ")
                sqlBuilder.Append(" SET ")
                sqlBuilder.Append("   SHIP_REQ_DT = @P2, ")
                sqlBuilder.Append("   SHIP_DT = @P3, ")
                sqlBuilder.Append("   CUS_ID = @P4, ")
                sqlBuilder.Append("   CUS_PO = @P5, ")
                sqlBuilder.Append("   INVOICE_NO = @P6, ")
                sqlBuilder.Append("   INVOICE_DT = @P7, ")
                sqlBuilder.Append("   UPD_USER_CD = @P8, ")
                sqlBuilder.Append("   UPD_DT = GETDATE() ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   SHIP_REQ_NO = @P1 ")
                webDbmanager.SetCommandText(sqlBuilder.ToString)
                webDbmanager.AddParameterChar("P1", shipmentRequestNo)
                webDbmanager.AddParameter("P2", shipmentRequestDate)
                webDbmanager.AddParameter("P3", shipmentDate)
                webDbmanager.AddParameterChar("P4", customerId)
                webDbmanager.AddParameterChar("P5", customerPo)
                webDbmanager.AddParameterChar("P6", invoiceNo)
                webDbmanager.AddParameter("P7", invoiceDate)
                webDbmanager.AddParameterChar("P8", registeredId)
                updateNo = webDbmanager.ExecuteNonQuery

                sqlBuilder = New StringBuilder
                sqlBuilder.Append(" DELETE FROM ")
                sqlBuilder.Append("   SHIP_REQ_DTL_INFO_TR ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   SHIP_REQ_NO = @P1 ")
                webDbmanager.SetCommandText(sqlBuilder.ToString)
                webDbmanager.AddParameterChar("P1", shipmentRequestNo)
                deleteNo = webDbmanager.ExecuteNonQuery

                For i As Integer = 0 To listData.Count - 1 Step 1
                    Dim arrayData As String() = listData(i).Split(",")
                    sqlBuilder = New StringBuilder
                    sqlBuilder.Append(" INSERT INTO ")
                    sqlBuilder.Append("   SHIP_REQ_DTL_INFO_TR ")
                    sqlBuilder.Append("   ( ")
                    sqlBuilder.Append("     SHIP_REQ_NO, ")
                    sqlBuilder.Append("     BC_NO, ")
                    sqlBuilder.Append("     PALLET_NO, ")
                    sqlBuilder.Append("     SCAN_FLG, ")
                    sqlBuilder.Append("     REG_USER_CD, ")
                    sqlBuilder.Append("     REG_DT, ")
                    sqlBuilder.Append("     UPD_USER_CD, ")
                    sqlBuilder.Append("     UPD_DT")
                    sqlBuilder.Append("   ) ")
                    sqlBuilder.Append("   VALUES ")
                    sqlBuilder.Append("   ( ")
                    sqlBuilder.Append("     @P1, ")
                    sqlBuilder.Append("     @P2, ")
                    sqlBuilder.Append("     @P3, ")
                    sqlBuilder.Append("     @P4, ")
                    sqlBuilder.Append("     @P5, ")
                    sqlBuilder.Append("     GETDATE(), ")
                    sqlBuilder.Append("     @P6, ")
                    sqlBuilder.Append("     GETDATE() ")
                    sqlBuilder.Append("   ) ")
                    webDbmanager.SetCommandText(sqlBuilder.ToString)
                    webDbmanager.AddParameterChar("P1", Trim(arrayData(0)))
                    webDbmanager.AddParameterChar("P2", Trim(arrayData(1)))
                    webDbmanager.AddParameterChar("P3", Trim(arrayData(2)))
                    webDbmanager.AddParameterChar("P4", Trim(arrayData(3)))
                    webDbmanager.AddParameterChar("P5", registeredId)
                    webDBManager.AddParameterChar("P6", Me.UserId)
                    insertNo = insertNo + webDbmanager.ExecuteNonQuery
                Next

                webDbmanager.Commit()
                webDbmanager.Disconnect()
                webDbmanager.Dispose()
                webDbmanager = Nothing

                Return updateNo + deleteNo + insertNo
            Catch ex As Exception
                webDbmanager.Rollback()
                webDbmanager.Disconnect()
                webDbmanager.Dispose()
                webDbmanager = Nothing
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        Public Function SetShipReqInfoTrComplete(ByVal shipReqNo As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                Dim row As Integer = 0

                sql.Append(" UPDATE SHIP_REQ_INFO_TR     ")
                sql.Append("    SET [COMP_FLG] = @P2  ")
                sql.Append("       ,[UPD_USER_CD] = @P3  ")
                sql.Append("       ,[UPD_DT] = GETDATE() ")
                sql.Append("  WHERE [SHIP_REQ_NO] = @P1  ")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", shipReqNo)
                dbm.AddParameterChar("P2", 1)
                dbm.AddParameter("P3", Me.UserId)

                row = dbm.ExecuteNonQuery
                dbm.Commit()
                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
        ''' <summary>
        ''' Shipment Inquiry
        ''' </summary>
        ''' <param name="cusId"></param>
        ''' <param name="cusPO"></param>
        ''' <param name="invoiceDate"></param>
        ''' <param name="invoiceNo"></param>
        ''' <param name="shipDateFrom"></param>
        ''' <param name="shipDateTo"></param>
        ''' <param name="shipReqDateFrom"></param>
        ''' <param name="shipReqDateTo"></param>
        ''' <param name="shipReqNo"></param>
        ''' <param name="shipStatus"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ShipmentInquiry(ByVal shipStatus As String, _
                                                                            ByVal shipReqNo As String, _
                                                                            ByVal shipReqDateFrom As String, _
                                                                            ByVal shipReqDateTo As String, _
                                                                            ByVal shipDateFrom As String, _
                                                                            ByVal shipDateTo As String, _
                                                                            ByVal cusId As String, _
                                                                            ByVal cusPO As String, _
                                                                            ByVal invoiceNo As String, _
                                                                            ByVal invoiceDate As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing

            Try
                dbm.Connect()

                sqlBuf.Append("SELECT A.SHIP_REQ_NO, ")
                sqlBuf.Append("B.CUS_NM, ")
                sqlBuf.Append("A.SHIP_REQ_DT, ")
                sqlBuf.Append("A.SHIP_DT, ")
                sqlBuf.Append("A.INVOICE_NO, ")
                sqlBuf.Append("A.INVOICE_DT, ")
                sqlBuf.Append("A.CUS_PO, ")
                sqlBuf.Append("A.REG_USER_CD, ")
                sqlBuf.Append("A.REG_DT, ")
                sqlBuf.Append("A.UPD_USER_CD, ")
                sqlBuf.Append("A.UPD_DT ")

                sqlBuf.Append("FROM SHIP_REQ_INFO_TR A, ")
                sqlBuf.Append("CUS_MASTER_MS B ")
                'sqlBuf.Append("WH_INFO_TR C, ")
                'sqlBuf.Append("WH_MASTER_MS D, ")
                'sqlBuf.Append("RACK_MASTER_MS E, ")
                'sqlBuf.Append("ITEM_MASTER_MS F, ")
                'sqlBuf.Append(" ITEM_DTL_MS G ")

                sqlBuf.Append("WHERE A.CUS_ID = B.CUS_ID ")
                'sqlBuf.Append("AND B.BC_NO=C.BC_NO ")
                'sqlBuf.Append("AND C.WH_CD=D.WH_CD ")
                'sqlBuf.Append("AND C.RACK_CD=E.RACK_CD ")
                'sqlBuf.Append("AND C.ITEM_CD=F.ITEM_CD ")
                'sqlBuf.Append("AND C.ITEM_CD=G.ITEM_CD ")

                If Not shipStatus.Equals("") Then
                    sqlBuf.Append("AND A.COMP_FLG = @P1 ")
                End If
                If Not shipReqNo.Equals("") Then
                    sqlBuf.Append("AND A.SHIP_REQ_NO LIKE '%'+@P2+'%' ")
                End If
                If Not shipReqDateFrom.Equals("") Then
                    sqlBuf.Append(" AND  CONVERT(varchar(8),A.SHIP_REQ_DT,112) >= @P3 ")
                End If
                If Not shipReqDateTo.Equals("") Then
                    sqlBuf.Append(" AND  CONVERT(varchar(8),A.SHIP_REQ_DT,112) <= @P4 ")
                End If
                If Not shipDateFrom.Equals("") Then
                    sqlBuf.Append(" AND  CONVERT(varchar(8),A.SHIP_DT,112) >= @P5 ")
                End If
                If Not shipDateTo.Equals("") Then
                    sqlBuf.Append(" AND  CONVERT(varchar(8),A.SHIP_DT,112) <= @P6 ")
                End If
                If Not cusId.Equals("") Then
                    sqlBuf.AppendFormat("AND A.CUS_ID LIKE '%'+@P7+'%' ", cusId)
                End If
                If Not cusPO.Equals("") Then
                    sqlBuf.AppendFormat("AND A.CUS_PO LIKE '%'+@P8+'%' ", cusPO)
                End If
                If Not invoiceNo.Equals("") Then
                    sqlBuf.AppendFormat("AND A.INVOICE_NO LIKE '%'+@P9+'%' ", invoiceNo)
                End If
                If Not invoiceDate.Equals("") Then
                    sqlBuf.AppendFormat(" AND  CONVERT(varchar(8),A.SHIP_DT,112) = @P10 ", invoiceDate)
                End If

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameter("P1", shipStatus)
                dbm.AddParameter("P2", shipReqNo)
                dbm.AddParameter("P3", shipReqDateFrom)
                dbm.AddParameter("P4", shipReqDateTo)
                dbm.AddParameter("P5", shipDateFrom)
                dbm.AddParameter("P6", shipDateTo)
                dbm.AddParameter("P7", cusId)
                dbm.AddParameter("P8", cusPO)
                dbm.AddParameter("P9", invoiceNo)
                dbm.AddParameter("P10", invoiceDate)


                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function ExecuteShipment(ByVal shipmentRequestNo As String, ByVal listData As List(Of String), ByVal registeredId As String) As Integer
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim updateNo As Integer = 0
            Dim insertNo As Integer = 0
            Dim deleteNo As Integer = 0

            Try
                webDbManager.Connect()
                sqlBuilder.Append(" UPDATE ")
                sqlBuilder.Append("   SHIP_REQ_INFO_TR ")
                sqlBuilder.Append(" SET ")
                sqlBuilder.Append("   COMP_FLG = 1, ")
                sqlBuilder.Append("   UPD_USER_CD = @P2, ")
                sqlBuilder.Append("   UPD_DT = GETDATE() ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   SHIP_REQ_NO = @P1 ")
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", shipmentRequestNo)
                webDbManager.AddParameterChar("P2", registeredId)
                updateNo = webDbManager.ExecuteNonQuery

                For i As Integer = 0 To listData.Count - 1 Step 1
                    Dim arrayData As String() = listData(i).Split(",")

                    sqlBuilder = New StringBuilder
                    sqlBuilder.Append(" SELECT ")
                    sqlBuilder.Append("   B.RACK_CD, ")
                    sqlBuilder.Append("   B.RACK_NM ")
                    sqlBuilder.Append(" FROM ")
                    '// sqlBuilder.Append("   WH_INFO_TR AS A, ")
                    sqlBuilder.Append("   RACK_MASTER_MS AS B ")
                    sqlBuilder.Append(" WHERE ")
                    sqlBuilder.Append("   1 = 1 ")
                    sqlBuilder.Append("  AND ")
                    sqlBuilder.Append("   B.RACK_CD = @P1 ")
                    webDbManager.SetCommandText(sqlBuilder.ToString)
                    webDbManager.AddParameterChar("P1", Trim(arrayData(3)))

                    Dim dataSet As DataSet = Nothing
                    dataSet = webDbManager.ExecuteDataSetFill

                    Dim rackCode As String = String.Empty
                    Dim rackName As String = String.Empty
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        rackCode = dataSet.Tables(0).Rows(0)("RACK_CD").ToString
                        rackName = dataSet.Tables(0).Rows(0)("RACK_NM").ToString
                    End If

                    sqlBuilder = New StringBuilder
                    sqlBuilder.Append(" DELETE FROM ")
                    sqlBuilder.Append("   WH_INFO_TR ")
                    sqlBuilder.Append(" WHERE ")
                    sqlBuilder.Append("   BC_NO = @P1 ")
                    webDbManager.SetCommandText(sqlBuilder.ToString)
                    webDbManager.AddParameterChar("P1", Trim(arrayData(1)))
                    deleteNo = deleteNo + webDbManager.ExecuteNonQuery

                    sqlBuilder = New StringBuilder
                    sqlBuilder.Append(" SELECT ")
                    sqlBuilder.Append("   (COALESCE(MAX(HIST_NO), 0) + 1) AS CNT ")
                    sqlBuilder.Append(" FROM ")
                    sqlBuilder.Append("   WH_HIST_INFO_TR ")
                    sqlBuilder.Append(" WHERE ")
                    sqlBuilder.Append("   1 = 1 ")
                    sqlBuilder.Append("  AND ")
                    sqlBuilder.Append("   BC_NO = @P1 ")
                    webDbManager.SetCommandText(sqlBuilder.ToString)
                    webDbManager.AddParameterChar("P1", Trim(arrayData(1)))
                    Dim historyNo As Integer = webDbManager.ExecuteScalar

                    sqlBuilder = New StringBuilder
                    sqlBuilder.Append(" INSERT INTO ")
                    sqlBuilder.Append("   WH_HIST_INFO_TR ")
                    sqlBuilder.Append("   ( ")
                    sqlBuilder.Append("     BC_NO, ")
                    sqlBuilder.Append("     HIST_NO, ")
                    sqlBuilder.Append("     SHIP_REQ_NO, ")
                    sqlBuilder.Append("     STATUS_FLG, ")
                    sqlBuilder.Append("     WH_CD, ")
                    sqlBuilder.Append("     RACK_CD, ")
                    sqlBuilder.Append("     RACK_NM, ")
                    sqlBuilder.Append("     ITEM_CD, ")
                    sqlBuilder.Append("     ITEM_NM, ")
                    sqlBuilder.Append("     REG_USER_CD, ")
                    sqlBuilder.Append("     REG_DT ")
                    sqlBuilder.Append("   ) ")
                    sqlBuilder.Append(" VALUES ")
                    sqlBuilder.Append("   ( ")
                    sqlBuilder.Append("     @P1, ")
                    sqlBuilder.Append("     @P2, ")
                    sqlBuilder.Append("     @P3, ")
                    sqlBuilder.Append("     7, ")
                    sqlBuilder.Append("     @P4, ")
                    sqlBuilder.Append("     @P5, ")
                    sqlBuilder.Append("     @P6, ")
                    sqlBuilder.Append("     @P7, ")
                    sqlBuilder.Append("     @P8, ")
                    sqlBuilder.Append("     @P9, ")
                    sqlBuilder.Append("     GETDATE() ")
                    sqlBuilder.Append("   ) ")
                    webDbManager.SetCommandText(sqlBuilder.ToString)
                    webDbManager.AddParameterChar("P1", Trim(arrayData(1)))
                    webDbManager.AddParameterChar("P2", historyNo)
                    webDbManager.AddParameterChar("P3", shipmentRequestNo)
                    webDbManager.AddParameterChar("P4", Trim(arrayData(4)))
                    webDbManager.AddParameterChar("P5", rackCode)
                    webDbManager.AddParameterChar("P6", rackName)
                    webDbManager.AddParameterChar("P7", Trim(arrayData(5)))
                    webDbManager.AddParameterChar("P8", Trim(arrayData(6)))
                    webDbManager.AddParameterChar("P9", registeredId)
                    insertNo = insertNo + webDbManager.ExecuteNonQuery

                    sqlBuilder = New StringBuilder
                    sqlBuilder.Append(" INSERT INTO ")
                    sqlBuilder.Append("   SHIP_ACT_DTL_INFO_TR ")
                    sqlBuilder.Append("   ( ")
                    sqlBuilder.Append("     SHIP_REQ_NO, ")
                    sqlBuilder.Append("     BC_NO, ")
                    sqlBuilder.Append("     PALLET_NO, ")
                    sqlBuilder.Append("     REG_USER_CD, ")
                    sqlBuilder.Append("     REG_DT ")
                    sqlBuilder.Append("   ) ")
                    sqlBuilder.Append(" VALUES ")
                    sqlBuilder.Append("   ( ")
                    sqlBuilder.Append("     @P1, ")
                    sqlBuilder.Append("     @P2, ")
                    sqlBuilder.Append("     @P3, ")
                    sqlBuilder.Append("     @P4, ")
                    sqlBuilder.Append("     GETDATE() ")
                    sqlBuilder.Append("   ) ")
                    webDbManager.SetCommandText(sqlBuilder.ToString)
                    webDbManager.AddParameterChar("P1", shipmentRequestNo)
                    webDbManager.AddParameterChar("P2", Trim(arrayData(1)))
                    webDbManager.AddParameterChar("P3", Trim(arrayData(0)))
                    webDbManager.AddParameterChar("P4", registeredId)
                    insertNo = insertNo + webDbManager.ExecuteNonQuery

                    sqlBuilder = New StringBuilder
                    sqlBuilder.Append(" UPDATE ")
                    sqlBuilder.Append("   ITEM_DTL_MS ")
                    sqlBuilder.Append(" SET ")
                    sqlBuilder.Append("   SHIP_FLG = 1, ")
                    sqlBuilder.Append("   UPD_USER_CD = @P2, ")
                    sqlBuilder.Append("   UPD_DT = GETDATE() ")
                    sqlBuilder.Append(" WHERE ")
                    sqlBuilder.Append("   BC_NO = @P1 ")
                    webDbManager.SetCommandText(sqlBuilder.ToString)
                    webDbManager.AddParameterChar("P1", Trim(arrayData(1)))
                    webDbManager.AddParameterChar("P2", registeredId)
                    updateNo = updateNo + webDbManager.ExecuteNonQuery
                Next

                sqlBuilder = New StringBuilder
                sqlBuilder.Append(" DELETE FROM ")
                sqlBuilder.Append("   SHIP_REQ_DTL_INFO_TR ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   SHIP_REQ_NO = @P1 ")
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", shipmentRequestNo)
                deleteNo = deleteNo + webDbManager.ExecuteNonQuery

                webDbManager.Commit()
                webDbManager.Disconnect()
                webDbManager.Dispose()
                webDbManager = Nothing

                Return insertNo + updateNo + deleteNo
            Catch ex As Exception
                webDbManager.Rollback()
                webDbManager.Disconnect()
                webDbManager.Dispose()
                webDbManager = Nothing
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

#End Region

#Region "BATCH 025 Warehouse Tr Process"

        ''' <summary>
        ''' Func Name: GetWarehouseTrByCd
        ''' </summary>
        ''' <param name="whCode"></param>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Public Function GetWarehouseTrByCd(ByVal whCode As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT WHTR.* ")
                sql.Append(" FROM   WH_INFO_TR AS WHTR ")
                sql.Append(" WHERE  WHTR.WH_CD = @P1")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", whCode)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Func Name: GetWarehouseTrByBarcodeNo
        ''' </summary>
        ''' <param name="barCd"></param>
        ''' <returns>DataSet</returns>
        ''' <remarks></remarks>
        Public Function GetWarehouseTrByBarcodeNo(ByVal barCd As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append(" SELECT WHTR.* ")
                sql.Append(" FROM   WH_INFO_TR AS WHTR ")
                sql.Append(" WHERE  WHTR.BC_NO = @P1")

                dbm.SetCommandText(sql.ToString)

                dbm.AddParameterChar("P1", barCd)

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
        ''' <summary>
        ''' Warehouse Tr Inqury.
        ''' </summary>
        ''' <param name="_whCd"></param>
        ''' <param name="_rackCd"></param>
        ''' <param name="_itemCd"></param>
        ''' <param name="_barcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function WarehouseTrInquiry(ByVal _whCd As String, _
                                            ByVal _rackCd As String, _
                                            ByVal _itemCd As String, _
                                            ByVal _barcode As String, _
                                            ByVal _importDateFrom As Date, _
                                            ByVal _importDateTo As Date) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing
            _whCd = Trim(_whCd)
            _rackCd = Trim(_rackCd)
            _itemCd = Trim(_itemCd)
            _barcode = Trim(_barcode)

            Try
                dbm.Connect()

                sqlBuf.Append(" SELECT A.BC_NO, ")
                sqlBuf.Append("   E.LOT_NO, ")
                sqlBuf.Append("   B.WH_CD, ")
                sqlBuf.Append("   B.WH_NM, ")
                sqlBuf.Append("   C.RACK_CD, ")
                sqlBuf.Append("   C.RACK_NM, ")
                sqlBuf.Append("   D.ITEM_CD, ")
                sqlBuf.Append("   D.ITEM_NM, ")
                sqlBuf.Append("   E.BOX_NUM, ")
                sqlBuf.Append("   E.QTY, ")
                sqlBuf.Append("   A.REG_USER_CD, ")
                sqlBuf.Append("   A.REG_DT, ")
                sqlBuf.Append("   A.UPD_USER_CD, ")
                sqlBuf.Append("   A.UPD_DT ")

                sqlBuf.Append(" FROM WH_INFO_TR A ")
                sqlBuf.Append(" LEFT JOIN RACK_MASTER_MS C ON A.RACK_CD=C.RACK_CD ")
                sqlBuf.Append(" JOIN WH_MASTER_MS B ON A.WH_CD=B.WH_CD ")
                sqlBuf.Append(" JOIN ITEM_MASTER_MS D ON A.ITEM_CD=D.ITEM_CD ")
                sqlBuf.Append(" JOIN ITEM_DTL_MS E ON A.BC_NO= E.BC_NO ")

                sqlBuf.Append(" WHERE ")
                sqlBuf.Append("   1 = 1 ")

                If Not _whCd.Equals("") Then
                    'sqlBuf.Append("AND A.WH_CD LIKE '%'+@P1+'%' ")
                    sqlBuf.Append(" AND A.WH_CD = @P1 ")
                End If
                If Not _rackCd.Equals("") Then
                    'sqlBuf.Append(" AND A.RACK_CD LIKE '%'+@P2+'%' ")
                    sqlBuf.Append(" AND A.RACK_CD = @P2 ")
                End If
                If Not _itemCd.Equals("") Then
                    'sqlBuf.Append("AND A.ITEM_CD LIKE '%'+@P3+'%' ")
                    sqlBuf.Append(" AND A.ITEM_CD = @P3 ")
                End If
                If Not _barcode.Equals("") Then
                    'sqlBuf.Append("AND A.BC_NO LIKE '%'+@P4+'%' ")
                    sqlBuf.Append(" AND A.BC_NO LIKE '%' + @P4 + '%' ")
                End If
                'AIT Hungtg start 04/08/2015
                'sqlBuf.Append(" AND  CONVERT(varchar(8),A.REG_DT,112) >= @P5 ")
                'sqlBuf.Append(" AND  CONVERT(varchar(8),A.REG_DT,112) <= @P6 ")
                sqlBuf.Append(" AND CONVERT(VARCHAR(8),A.REG_DT,112) >= @P5 ")
                sqlBuf.Append(" AND CONVERT(VARCHAR(8),A.REG_DT,112) <= @P6 ")
                'AIT Hungtg end 04/08/2015
                sqlBuf.Append(" ORDER BY ")
                sqlBuf.Append("    A.BC_NO ASC ")

                dbm.SetCommandText(sqlBuf.ToString)
                ''Add parameter
                dbm.AddParameter("P1", _whCd)
                dbm.AddParameter("P2", _rackCd)
                dbm.AddParameter("P3", _itemCd)
                dbm.AddParameter("P4", _barcode)
                dbm.AddParameter("P5", _importDateFrom.ToString("yyyyMMdd"))
                dbm.AddParameter("P6", _importDateTo.ToString("yyyyMMdd"))


                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function DeleteWarehouseTrByBarcode(ByVal barcodeNo As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder
            Dim row As Integer = 0

            Try
                dbm.Connect()

                sqlBuf.Append(" DELETE FROM WH_INFO_TR ")
                sqlBuf.Append(" WHERE BC_NO = @P1 ")

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", barcodeNo)

                row = dbm.ExecuteNonQuery
                dbm.Commit()

                Return row
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
        ''' <summary>
        ''' Sub Name: InsertWarehouseTrInfo
        ''' </summary>
        ''' <param name="itemCd"></param>
        ''' <param name=" barcodeNo"></param>
        ''' <param name="whCd"></param>
        ''' <param name=" rackCd"></param>
        ''' <param name=" loginId"></param>
        ''' <remarks></remarks>
        Public Function InsertWarehouseTrInfo(ByVal barcodeNo As String, _
                                                                                        ByVal whCd As String, _
                                                                                        ByVal rackCd As String, _
                                                                                        ByVal itemCd As String, _
                                                                                        ByVal loginId As String) As Integer
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder
            Dim ret As Integer = 0

            Try
                dbm.Connect()

                sql.Append("INSERT WH_INFO_TR ( BC_NO, ")
                sql.Append(" WH_CD, ")
                sql.Append(" RACK_CD, ")
                sql.Append(" ITEM_CD, ")
                sql.Append(" REG_USER_CD, ")
                sql.Append(" REG_DT, ")
                sql.Append(" UPD_USER_CD, ")
                sql.Append(" UPD_DT")
                sql.Append(") VALUES (")
                sql.AppendFormat(" '{0}', ", barcodeNo)
                sql.AppendFormat(" '{0}', ", whCd)
                sql.AppendFormat(" '{0}', ", rackCd)
                sql.AppendFormat(" '{0}', ", itemCd)
                sql.AppendFormat("'{0}', ", loginId)
                sql.Append("GETDATE(), ")
                sql.Append("'' ,")
                sql.Append("'' )")
                dbm.SetCommandText(sql.ToString)

                ret = dbm.ExecuteNonQuery
                dbm.Commit()
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
        ''' <summary>
        ''' Sub Name: InsertWarehouseTrInfoToString
        ''' </summary>
        ''' <param name="itemCd"></param>
        ''' <param name=" barcodeNo"></param>
        ''' <param name="whCd"></param>
        ''' <param name=" rackCd"></param>
        ''' <param name=" loginId"></param>
        ''' <remarks></remarks>
        Public Function InsertWarehouseTrInfoToString(ByVal barcodeNo As String, _
                                                                                        ByVal whCd As String, _
                                                                                        ByVal rackCd As String, _
                                                                                        ByVal itemCd As String, _
                                                                                        ByVal loginId As String) As String

            Dim sql As New StringBuilder

            sql.Append("INSERT WH_INFO_TR ( BC_NO, ")
            sql.Append(" WH_CD, ")
            sql.Append(" RACK_CD, ")
            sql.Append(" ITEM_CD, ")
            sql.Append(" REG_USER_CD, ")
            sql.Append(" REG_DT, ")
            sql.Append(" UPD_USER_CD, ")
            sql.Append(" UPD_DT")
            sql.Append(") VALUES (")
            sql.AppendFormat(" '{0}', ", barcodeNo)
            sql.AppendFormat(" '{0}', ", whCd)
            sql.AppendFormat(" '{0}', ", rackCd)
            sql.AppendFormat(" '{0}', ", Trim(itemCd))
            sql.AppendFormat("'{0}', ", loginId)
            sql.Append("GETDATE(), ")
            sql.AppendFormat("'{0}', ", loginId)
            sql.Append("GETDATE()) ")

            Return sql.ToString
        End Function

#End Region

#Region "Batch Export"

        ''' <summary>
        ''' CheckBarcodeExportExistProcess
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <author>vudh</author>
        ''' <returns>DataSet result</returns>
        Public Function CheckBarcodeExportExistProcess(ByVal barcodeNo As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet
            Dim dtTable As New DataTable
            Try
                dbm.Connect()
                ds.Tables.Add()
                ds.Tables(0).Columns.Add("RESULT")
                ds.Tables(0).Columns.Add("ITEMCODE")
                ds.Tables(0).Columns.Add("ITEMNAME")
                '' (1) : Check exist barcode in Warehouse W900
                ' strQuery 1  
                Dim sqlBuf1 As New StringBuilder(150)
                sqlBuf1.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf1.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf1.Append("  WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf1.Append("    AND TR.WH_CD = 'W900'")
                sqlBuf1.Append("    AND MS.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf1.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result1 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())
                ' add result to dataset
                If result1 = 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "3"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (2) : check exist barcode in warehouse product
                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf2 As New StringBuilder(150)
                sqlBuf2.Append(" SELECT COUNT(MS.BC_NO)")
                sqlBuf2.Append("   FROM ITEM_DTL_MS AS MS, WH_INFO_TR AS TR")
                sqlBuf2.Append("  WHERE MS.BC_NO = TR.BC_NO")
                sqlBuf2.Append("    AND MS.BC_NO = @P1")
                sqlBuf2.Append("    AND TR.WH_CD = 'MOLD'")

                dbm.SetCommandText(sqlBuf2.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                Dim result2 As Int16 = Convert.ToInt16(dbm.ExecuteScalar())

                If result2 <> 0 Then
                    ds.Tables(0).Rows.Add.Item(0) = "2"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                End If

                '' (3): get ItemCD & Item Name

                ' clear rows
                ds.Tables(0).Rows.Clear()
                ' strQuery 2
                Dim sqlBuf3 As New StringBuilder(150)
                sqlBuf3.Append(" SELECT MST.ITEM_CD, MST.ITEM_NM")
                sqlBuf3.Append("   FROM ITEM_MASTER_MS MST, ITEM_DTL_MS DTL")
                sqlBuf3.Append("  WHERE MST.ITEM_CD = DTL.ITEM_CD")
                sqlBuf3.Append("    AND DTL.BC_NO = @P1")

                dbm.SetCommandText(sqlBuf3.ToString())
                dbm.AddParameterChar("P1", barcodeNo)

                dtTable = dbm.ExecuteDataTableFill()
                If dtTable.Rows.Count < 1 Then
                    ds.Tables(0).Rows.Add.Item(0) = "1"
                    ds.Tables(0).Rows(0).Item(1) = Nothing
                    ds.Tables(0).Rows(0).Item(2) = Nothing
                    Return ds
                Else
                    ds.Tables(0).Rows.Add.Item(0) = "0"
                    ds.Tables(0).Rows(0).Item(1) = dtTable.Rows(0).Item("ITEM_CD").ToString()
                    ds.Tables(0).Rows(0).Item(2) = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    Return ds
                End If
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex)
                Throw ex
            Finally
                ' Åyå„èàóùÅz
                dtTable.Dispose()
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''<<20150324 Phungntm start
        ''' <summary>
        ''' ExportBarcodeIntoMold
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <param name="itemCode"></param>
        ''' 
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExportBarcodeIntoMold(ByVal barcodeNo As String, ByVal itemCode As String) As Boolean
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim ds As New DataSet

            Dim dtTable As New DataTable
            ''>>
            Try
                dbm.Connect()
                Dim sqlBuf As New StringBuilder(1000)
                ' update WH_INFO_TR
                sqlBuf.Append(" UPDATE TR ")
                sqlBuf.Append(" SET TR.WH_CD = 'MOLD'")
                sqlBuf.Append("     ,TR.RACK_CD = NULL")
                sqlBuf.Append("     ,TR.UPD_USER_CD = @P1")
                sqlBuf.Append("     ,TR.UPD_DT =    GETDATE()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE TR.BC_NO = @P2")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.ITEM_CD = @P3")

                ' update ITEM_DTL_MS                
                sqlBuf.Append(" UPDATE MS ")
                sqlBuf.Append(" SET MS.SHIP_FLG = '0'")
                sqlBuf.Append("    ,MS.UPD_USER_CD = @P4")
                sqlBuf.Append("    ,MS.UPD_DT = GETDATE()")
                sqlBuf.Append(" FROM WH_INFO_TR AS TR , ITEM_DTL_MS AS MS")
                sqlBuf.Append(" WHERE MS.BC_NO = @P5")
                sqlBuf.Append(" AND TR.BC_NO = MS.BC_NO")
                sqlBuf.Append(" AND TR.ITEM_CD = MS.ITEM_CD")
                sqlBuf.Append(" AND TR.ITEM_CD = @P6")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", Me.UserId)
                dbm.AddParameter("P2", barcodeNo)
                dbm.AddParameter("P3", itemCode)
                dbm.AddParameter("P4", Me.UserId)
                dbm.AddParameter("P5", barcodeNo)
                dbm.AddParameter("P6", itemCode)
                dbm.ExecuteNonQuery()

                ' Get Next Hist value with barcodeNo
                Dim histNo As Integer = GetNextHistoryNo(barcodeNo)

                ''<<20150130 Phungntm start
                Dim rackNo As String = "" 'Import into QC --> rackNo= null
                Dim rackName As String = ""
                Dim itemName As String = ""

                '' Get Rack Name from RackCode  
                If Not String.IsNullOrEmpty(Trim(rackNo)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT RACK_NM")
                    sqlBuf.Append("   FROM RACK_MASTER_MS ")
                    sqlBuf.Append("  WHERE RACK_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", rackNo)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        rackName = dtTable.Rows(0).Item("RACK_NM").ToString()
                    End If

                End If

                '' Get Item Name from Item Code                
                If Not String.IsNullOrEmpty(Trim(itemCode)) Then
                    sqlBuf = Nothing
                    sqlBuf = New StringBuilder(1000)
                    sqlBuf.Append(" SELECT ITEM_NM")
                    sqlBuf.Append("   FROM ITEM_MASTER_MS ")
                    sqlBuf.Append("  WHERE ITEM_CD = @P1")

                    dbm.SetCommandText(sqlBuf.ToString())
                    dbm.AddParameterChar("P1", itemCode)

                    dtTable = dbm.ExecuteDataTableFill()
                    If dtTable.Rows.Count <> 0 Then
                        itemName = dtTable.Rows(0).Item("ITEM_NM").ToString()
                    End If
                End If
                ''>>

                ' INSERT WH_HIS_INFO_TR
                sqlBuf = Nothing
                sqlBuf = New StringBuilder(1000)
                sqlBuf.Append(" INSERT WH_HIST_INFO_TR (")
                sqlBuf.Append(" BC_NO")
                sqlBuf.Append(" ,HIST_NO")
                sqlBuf.Append(" ,STATUS_FLG")
                sqlBuf.Append(" ,WH_CD")
                sqlBuf.Append(" ,ITEM_CD")
                sqlBuf.Append(" ,REG_USER_CD")
                sqlBuf.Append(" ,REG_DT")
                sqlBuf.Append(" ,UPD_USER_CD")
                sqlBuf.Append(" ,UPD_DT")
                ''<<''<<20150130 Phungntm start
                sqlBuf.Append(" ,RACK_NM")
                sqlBuf.Append(" ,ITEM_NM")
                ''>>
                sqlBuf.Append(" ) VALUES (")
                sqlBuf.Append(" @P1")
                sqlBuf.Append(" ,@P2")
                sqlBuf.Append(" ,@P3")
                sqlBuf.Append(" ,@P4")
                sqlBuf.Append(" ,@P5")
                sqlBuf.Append(" ,@P6")
                sqlBuf.Append(" ,getdate()")
                sqlBuf.Append(" ,@P7")
                sqlBuf.Append(" ,getdate()")
                ''<<20150130 Phungntm start
                sqlBuf.Append(" ,@P9")
                sqlBuf.Append(" ,@P10")
                ''>>
                sqlBuf.Append(" )")

                dbm.SetCommandText(sqlBuf.ToString())
                dbm.AddParameter("P1", barcodeNo)
                dbm.AddParameter("P2", histNo)
                dbm.AddParameter("P3", 2) ' Return to MOLD
                dbm.AddParameter("P4", "MOLD")
                dbm.AddParameter("P5", itemCode)
                dbm.AddParameter("P6", UserId)
                dbm.AddParameter("P7", UserId)
                ''<<20150130 Phungntm start
                dbm.AddParameter("P9", rackName)
                dbm.AddParameter("P10", itemName)
                ''>>

                Dim ret As Integer = dbm.ExecuteNonQuery()
                sqlBuf = Nothing

                'commit transaction
                dbm.Commit()
                Return True

            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                WriteErrorLog(ex)
                Throw ex
            Finally
                ''<<20150130 Phungntm start
                dtTable.Dispose()
                ''>> 
                ' DBÇ÷ÇÃê⁄ë±ÇÇ´ÇÈ
                dbm.Disconnect()
                ' ì‡ïî≤›Ω¿›ΩÇîjä¸
                dbm.Dispose()
                '// WriteEndLog()
            End Try

        End Function

#End Region

#Region "Batch 026 Stocktaking Process"

        ''' <summary>
        ''' Get info warehoue tr list.
        ''' </summary>
        ''' <param name="warehouseCode"></param>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWhInfoTrList(ByVal warehouseCode As String, ByVal itemCode As String) As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)

            Try
                dbm.Connect()

                Dim query As String = ""
                query = query & "SELECT A.* "
                query = query & "FROM   WH_INFO_TR AS A "
                query = query & "WHERE  1 = 1 "
                If Not warehouseCode.Equals("") Then
                    query = query & "  AND  WH_CD = @P1 "
                End If
                If Not itemCode.Equals("") Then
                    query = query & "  AND  ITEM_CD = @P2"
                End If

                dbm.SetCommandText(query)
                If Not warehouseCode.Equals("") Then
                    dbm.AddParameter("P1", warehouseCode)
                End If
                If Not itemCode.Equals("") Then
                    dbm.AddParameterChar("P2", itemCode)
                End If

                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Insert Stock Req Detail Info Tr.
        ''' </summary>
        ''' <param name="stockDate"></param>
        ''' <param name="warehouseCode"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="bcNoList"></param>
        ''' <param name="whSysCdList"></param>
        ''' <param name="rackSysCdList"></param>
        ''' <param name="whActCdList"></param>
        ''' <param name="rackActCdList"></param>
        ''' <param name="loginCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertStockReqDtlInfoTr(ByVal stockDate As Date, ByVal warehouseCode As String, _
                                                ByVal itemCode As String, ByVal bcNoList As List(Of String), _
                                                ByVal whSysCdList As List(Of String), ByVal rackSysCdList As List(Of String), _
                                                ByVal whActCdList As List(Of String), ByVal rackActCdList As List(Of String), _
                                                ByVal loginCode As String) As Integer
            '// WriteStartLog() '' Start process write log file.
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder()
            Dim num As Integer = 0
            Try
                dbm.Connect()

                '' Delete table STOCK_REQ_INFO_TR.
                sql.Append("DELETE FROM STOCK_REQ_INFO_TR ")
                dbm.SetCommandText(sql.ToString)
                dbm.ExecuteNonQuery()

                '' Delete table STOCK_REQ_DTL_INFO_TR.
                sql = New StringBuilder
                sql.Append("DELETE FROM STOCK_REQ_DTL_INFO_TR ")
                dbm.SetCommandText(sql.ToString)
                dbm.ExecuteNonQuery()

                '' Insert table STOCK_REQ_INFO_TR.
                sql = New StringBuilder
                sql.Append("INSERT STOCK_REQ_INFO_TR")
                sql.Append("(")
                sql.Append("STOCK_REQ_DT,")
                sql.Append("STOCK_DT,")
                sql.Append("REQ_ITEM_CD,")
                sql.Append("REQ_WH_CD,")
                sql.Append("REG_USER_CD,")
                sql.Append("REG_DT,")
                sql.Append("UPD_USER_CD,")
                sql.Append("UPD_DT")
                sql.Append(")")
                sql.Append(" VALUES ")
                sql.Append("(")
                sql.Append("@P1,")
                sql.Append("@P2,")
                sql.Append("@P3,")
                sql.Append("@P4,")
                sql.Append("@P5,")
                sql.Append("GETDATE(),")
                sql.Append("@P5,")
                sql.Append("GETDATE()")
                sql.Append(") ")
                dbm.SetCommandText(sql.ToString)
                dbm.AddParameterChar("P1", stockDate.ToString("yyyyMMdd")) '' Set format [yyyyMMdd].
                dbm.AddParameter("P2", stockDate)
                dbm.AddParameterChar("P3", itemCode)
                dbm.AddParameterChar("P4", warehouseCode)
                dbm.AddParameterChar("P5", loginCode)
                dbm.ExecuteNonQuery()

                '' Insert table STOCK_REQ_DTL_INFO_TR.
                sql = New StringBuilder
                sql.Append("INSERT STOCK_REQ_DTL_INFO_TR")
                sql.Append("(")
                sql.Append("BC_NO,")
                sql.Append("SYS_WH_CD,")
                sql.Append("SYS_RACK_CD,")
                If whActCdList.Count > 0 Then
                    sql.Append("ACT_WH_CD,")
                End If
                If rackActCdList.Count > 0 Then
                    sql.Append("ACT_RACK_CD,")
                End If
                sql.Append("SPEC_FLG,")
                sql.Append("SCAN_FLG,")
                sql.Append("REG_USER_CD,")
                sql.Append("REG_DT,")
                sql.Append("UPD_USER_CD,")
                sql.Append("UPD_DT")
                sql.Append(")")
                sql.Append(" VALUES ")
                sql.Append("(")
                sql.Append("@P1, ")
                sql.Append("@P2, ")
                sql.Append("@P3, ")
                If whActCdList.Count > 0 Then
                    sql.Append("@P4, ")
                End If
                If rackActCdList.Count > 0 Then
                    sql.Append("@P5, ")
                End If
                sql.Append("1, ")
                sql.Append("0, ")
                sql.Append("@P6, ")
                sql.Append("GETDATE(), ")
                sql.Append("@P6, ")
                sql.Append("GETDATE()")
                sql.Append(")")

                'Dim r1 As Integer = 0
                'Dim r2 As Integer = 0
                'Dim r3 As Integer = 0
                'Dim r4 As Integer = 0
                'Dim r5 As Integer = 0
                'For i As Integer = 0 To bcNoList.Count - 1 Step 1
                '    If i <> 0 Then
                '        sql.Append(" UNION ALL ") '' Use key "UNION ALL" to insert multi data.
                '    End If
                '    sql.Append("SELECT ")
                '    sql.Append("@BC" & r1.ToString & ",")
                '    sql.Append("@WS" & r2.ToString & ",")
                '    sql.Append("@RS" & r3.ToString & ",")
                '    If whActCdList.Count > 0 Then
                '        sql.Append("@WA" & r4.ToString & ",")
                '        r4 = r4 + 1
                '    End If
                '    If rackActCdList.Count > 0 Then
                '        sql.Append("@RA" & r5.ToString & ",")
                '        r5 = r5 + 1
                '    End If
                '    sql.Append("1,")
                '    sql.Append("0,")
                '    sql.Append("@P5,")
                '    sql.Append("GETDATE(),")
                '    sql.Append("@P5,")
                '    sql.Append("GETDATE()")
                '    r1 = r1 + 1
                '    r2 = r2 + 1
                '    r3 = r3 + 1
                'Next
                'Dim addStockReqDtlInfTr As String = sql.ToString

                ''dbm.SetCommandText(delStockReqInfTr & vbCrLf & delStockReqDtlInfTr & vbCrLf & addstockReqInfTr & vbCrLf & addStockReqDtlInfTr)
                'dbm.AddParameterChar("P1", stockDate.ToString("yyyyMMdd")) '' Set format [yyyyMMdd].
                'dbm.AddParameter("P2", stockDate)
                'dbm.AddParameterChar("P3", itemCode)
                'dbm.AddParameterChar("P4", warehouseCode)
                'dbm.AddParameterChar("P5", loginCode)

                'r1 = 0
                'r2 = 0
                'r3 = 0
                'r4 = 0
                'r5 = 0
                For i As Integer = 0 To bcNoList.Count - 1 Step 1
                    dbm.SetCommandText(sql.ToString)
                    dbm.AddParameterChar("@P1", bcNoList(i))
                    dbm.AddParameterChar("@P2", whSysCdList(i))
                    dbm.AddParameterChar("@P3", rackSysCdList(i))
                    'dbm.AddParameterChar("BC" & r1.ToString, bcNoList(i))
                    'dbm.AddParameterChar("WS" & r2.ToString, whSysCdList(i))
                    'dbm.AddParameterChar("RS" & r3.ToString, rackSysCdList(i))
                    If whActCdList.Count > 0 Then
                        dbm.AddParameterChar("@P4", whActCdList(i))
                        'r4 = r4 + 1
                    End If
                    If rackActCdList.Count > 0 Then
                        dbm.AddParameterChar("@P5", rackActCdList(i))
                        'r5 = r5 + 1
                    End If
                    dbm.AddParameterChar("@P6", loginCode)
                    num = dbm.ExecuteNonQuery()
                    'r1 = r1 + 1
                    'r2 = r2 + 1
                    'r3 = r3 + 1
                Next
                dbm.Commit()
                Return num
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog() '' End process write log file.
            End Try
        End Function

        ''' <summary>
        ''' Get data stock req info tr.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStockReqInfoTr() As DataSet
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim dataSet As DataSet = Nothing

            Try
                webDbManager.Connect()

                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("   SRIT.STOCK_REQ_DT, ")
                sqlBuilder.Append("   SRIT.STOCK_DT, ")
                sqlBuilder.Append("   IMM.ITEM_CD, ")
                sqlBuilder.Append("   IMM.ITEM_NM, ")
                sqlBuilder.Append("   WMM.WH_CD, ")
                sqlBuilder.Append("   WMM.WH_NM ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   STOCK_REQ_INFO_TR AS SRIT ")
                sqlBuilder.Append("  LEFT JOIN ")
                sqlBuilder.Append("   ITEM_MASTER_MS AS IMM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   SRIT.REQ_ITEM_CD = IMM.ITEM_CD ")
                sqlBuilder.Append("  LEFT JOIN ")
                sqlBuilder.Append("   WH_MASTER_MS AS WMM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   SRIT.REQ_WH_CD = WMM.WH_CD ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")

                webDbManager.SetCommandText(sqlBuilder.ToString)
                dataSet = webDbManager.ExecuteDataSetFill
                webDbManager.Disconnect()
                webDbManager.Dispose()

                Return dataSet
            Catch ex As Exception
                WriteErrorLog(ex.ToString)
                webDbManager.Disconnect()
                webDbManager.Dispose()
                webDbManager = Nothing
                Return Nothing
            End Try
            ''// WriteStartLog()

            'Dim ds As DataSet = Nothing
            'Dim dbm As New ABCDWebDBManager(Me.UserId)
            'Dim sql As New StringBuilder

            'Try
            '    dbm.Connect()

            '    sql.Append("SELECT * ")
            '    sql.Append("FROM   STOCK_REQ_INFO_TR ")

            '    dbm.SetCommandText(sql.ToString)
            '    ds = dbm.ExecuteDataSetFill
            '    Return ds
            'Catch ex As Exception
            '    dbm.Rollback()
            '    ds.Dispose()
            '    WriteErrorLog(ex.Message)
            '    Throw ex
            'Finally
            '    ds.Dispose()
            '    dbm.Disconnect()
            '    dbm.Dispose()
            '    '// WriteEndLog()
            '    dbm = Nothing
            'End Try
        End Function

        ''' <summary>
        ''' Get data stock req detail info tr.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStockReqDtlInfoTr() As DataSet
            '// WriteStartLog()

            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder

            Try
                dbm.Connect()

                sql.Append("SELECT  G.STOCK_DT, A.SYS_WH_CD, A.SYS_RACK_CD, A.BC_NO, ")
                sql.Append("B.ITEM_CD, ")
                sql.Append("B.ITEM_NM, ")
                sql.Append("D.BOX_NUM, ")
                sql.Append("E.QTY_PER_BOX, ")
                sql.Append("B.UNIT, ")
                sql.Append("A.SPEC_FLG, ")
                sql.Append("A.SCAN_FLG, ")
                sql.Append("A.REG_USER_CD, ")
                sql.Append("A.REG_DT, ")
                sql.Append("A.UPD_USER_CD, ")
                sql.Append("A.UPD_DT ")

                sql.Append("FROM STOCK_REQ_DTL_INFO_TR AS A, ")
                sql.Append("     ITEM_MASTER_MS AS B, ")
                sql.Append("     WH_MASTER_MS AS C, ")
                sql.Append("     ITEM_DTL_MS AS D, ")
                sql.Append("     PRODUCT_INFO_TR AS E, ")
                sql.Append("     WH_INFO_TR AS F, ")
                sql.Append("     STOCK_REQ_INFO_TR AS G ")

                sql.Append("WHERE A.BC_NO = D.BC_NO ")
                sql.Append("AND A.BC_NO = F.BC_NO ")
                sql.Append("AND D.WO_NO=E.WO_NO ")
                sql.Append("AND F.WH_CD= C.WH_CD ")
                sql.Append("AND D.ITEM_CD= B.ITEM_CD ")
                sql.Append("AND A.SPEC_FLG=1 ")
                sql.Append("ORDER BY F.WH_CD ")
                sql.Append(", A.BC_NO ")

                dbm.SetCommandText(sql.ToString)
                ds = dbm.ExecuteDataSetFill
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                ds.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                ds.Dispose()
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStockResultDtlInfoTr() As DataSet
            '// WriteStartLog()
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sql As New StringBuilder
            Try
                dbm.Connect()
                'AIT Hungtg start 04/08/2015
                sql.Append("SELECT 																   ")
                sql.Append("	A.BC_NO,                                                           ")
                sql.Append("	A.SYS_WH_CD,                                                       ")
                sql.Append("	A.SYS_RACK_CD,                                                     ")
                sql.Append("	A.ACT_WH_CD,                                                       ")
                sql.Append("	A.ACT_RACK_CD,                                                     ")
                sql.Append("	B.ITEM_CD,                                                         ")
                sql.Append("	B.ITEM_NM,                                                         ")
                sql.Append("	C.LOT_NO,                                                          ")
                sql.Append("	A.SPEC_FLG,                                                        ")
                sql.Append("	A.SCAN_FLG,                                                        ")
                sql.Append("	A.REG_USER_CD,                                                     ")
                sql.Append("	A.REG_DT,                                                          ")
                sql.Append("	A.UPD_USER_CD,                                                     ")
                sql.Append("	A.UPD_DT                                                           ")
                sql.Append("FROM STOCK_REQ_DTL_INFO_TR A,ITEM_MASTER_MS B,ITEM_DTL_MS C            ")
                sql.Append("WHERE   A.BC_NO = C.BC_NO                                              ")
                sql.Append("		AND B.ITEM_CD = C.ITEM_CD                                      ")
                'AIT Hungtg end 04/08/2015
                dbm.SetCommandText(sql.ToString)
                Return dbm.ExecuteDataSetFill
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

#End Region

#Region "Get Code Master."
        ''' <summary>
        ''' Get data from table CODE_MASTER_MS.
        ''' </summary>
        ''' <param name="code1"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCodeMasterMS(ByVal code1 As Integer) As DataSet
            '' Start write file log.
            '// WriteStartLog()
            '' Declare dataset, abcdwebdbmanager, stringbuilder.
            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()
            Try
                '' Open connect to DB.
                dbm.Connect()

                '' Create string query.
                sb.Append("SELECT   A.CODE_02, A.CODE_NAME ")
                sb.Append("FROM     CODE_MASTER_MS AS A ")
                sb.Append("WHERE    A.CODE_01 = @P1 ")

                dbm.SetCommandText(sb.ToString())

                '' Set value for param.
                dbm.AddParameterChar("P1", code1)

                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                '' An exception error handling.
                '' Time error occurs, always rollback.
                dbm.Rollback()
                ds.Dispose()
                '' Write error into file log.
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                '' Post-processing.
                ds.Dispose()
                '' Disconnect to DB.
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
        ''' <summary>
        ''' Get unit by code 2.
        ''' </summary>
        ''' <param name="code2"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUnitByCode2(ByVal code2 As Integer) As String
            '' Start write file log.
            '// WriteStartLog()
            '' Declare dataset, abcdwebdbmanager, stringbuilder.
            Dim unit As String
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()
            Try
                '' Open connect to DB.
                dbm.Connect()

                '' Create string query.
                sb.Append("SELECT   A.CODE_NAME ")
                sb.Append("FROM     CODE_MASTER_MS AS A ")
                sb.Append("WHERE    A.CODE_01 = 1 ")
                sb.Append("AND    A.CODE_02 = @P1 ")

                dbm.SetCommandText(sb.ToString())

                '' Set value for param.
                dbm.AddParameterChar("P1", code2)

                unit = dbm.ExecuteScalar()
                Return unit
            Catch ex As Exception
                '' An exception error handling.
                '' Time error occurs, always rollback.
                dbm.Rollback()
                '' Write error into file log.
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                '' Disconnect to DB.
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
                dbm = Nothing
            End Try
        End Function
#End Region


        Public Function ImproveScreenProductInquiry(ByVal workOrderList As List(Of String), ByVal itemCodeList As List(Of String), _
                                                    ByVal totalBoxList As List(Of String), ByVal currentNumberBoxList As List(Of String), _
                                                    ByVal workOrderDateList As List(Of String), ByVal quantityList As List(Of String), _
                                                    ByVal userCode As String) As DataSet
            Dim dataSet As DataSet = Nothing
            Dim webDbManager As New ABCDWebDBManager(UserId:=userCode)
            Dim stringBuilder As New StringBuilder
            Dim boxNumber As Integer = 0
            Dim currentNumberBox As Integer = 0
            Dim workOrderNo As String = String.Empty
            Dim workOrderDate As String = String.Empty
            Dim barCode As String = String.Empty
            Dim lotNo As String = String.Empty
            Dim quantity As Integer = 0
            Dim itemCode As String = String.Empty
            Dim insertItemDetail As String = String.Empty
            '// WriteStartLog()
            Try
                webDbManager.Connect()
                For i As Integer = 0 To workOrderList.Count - 1 Step 1
                    workOrderNo = workOrderList(i)
                    currentNumberBox = Integer.Parse(currentNumberBoxList(i))
                    itemCode = itemCodeList(i)
                    For j As Integer = 1 To Integer.Parse(totalBoxList(i)) Step 1
                        boxNumber = currentNumberBox + 1
                        If boxNumber = 9999 Then
                            boxNumber = 1
                            currentNumberBox = 1
                        End If
                        barCode = workOrderNo & boxNumber '' Set Barcode.
                        lotNo = workOrderNo.Substring(workOrderNo.Length - 5) & "-" & DateTime.Now.ToString("yyyyMMdd") '' Set LotNo.
                        quantity = Integer.Parse(quantityList(i))
                        workOrderDate = DateTime.Parse(workOrderDateList(i))
                        If j <> 1 Then
                            insertItemDetail = insertItemDetail & vbCrLf
                        End If
                        insertItemDetail = insertItemDetail & ImproveInsertItemDetail(itemCode, boxNumber, barCode, quantity, lotNo, workOrderNo, workOrderDate, userCode)
                    Next
                Next
                Return dataSet
            Catch ex As Exception
                webDbManager.Rollback()
                dataSet.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dataSet.Dispose()
                webDbManager.Disconnect()
                webDbManager.Dispose()
                '// WriteEndLog()
                webDbManager = Nothing
            End Try
        End Function

        Private Function ImproveInsertItemDetail(ByVal itemCode As String, ByVal boxNumber As Integer, _
                                                 ByVal barCode As String, ByVal quantity As Integer, _
                                                 ByVal lotNo As String, ByVal workOrderNo As String, _
                                                 ByVal workOrderDate As DateTime, ByVal userCode As String) As String
            Dim insertItemDetail As String = String.Empty
            insertItemDetail = "Insert Into ITEM_DTL_MS(ITEM_CD, BOX_NUM, BC_NO, QTY, LOT_NO, WO_NO, WO_DT, SHIP_FLG, EXP_FLG, REG_USER_CD, REG_DT, UPD_USER_CD, UPD_DT) "
            insertItemDetail = insertItemDetail & "Values ("
            insertItemDetail = insertItemDetail & "'" & itemCode & "', "
            insertItemDetail = insertItemDetail & "'" & boxNumber.ToString("0000") & "', "
            insertItemDetail = insertItemDetail & "'" & barCode & "', "
            insertItemDetail = insertItemDetail & "" & quantity & ", "
            insertItemDetail = insertItemDetail & "'" & lotNo & "', "
            insertItemDetail = insertItemDetail & "'" & workOrderNo & "', "
            insertItemDetail = insertItemDetail & "'" & workOrderDate & "', "
            insertItemDetail = insertItemDetail & "" & 0 & ", "
            insertItemDetail = insertItemDetail & "" & 1 & ", "
            insertItemDetail = insertItemDetail & "'" & userCode & "', "
            insertItemDetail = insertItemDetail & "GETDATE(), "
            insertItemDetail = insertItemDetail & "'" & userCode & "', "
            insertItemDetail = insertItemDetail & "GETDATE()"
            insertItemDetail = insertItemDetail & ")"
            Return insertItemDetail
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <param name="workOrderNo"></param>
        ''' <param name="dateFrom"></param>
        ''' <param name="dateTo"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataProductInfoInquiryWithModeNew(ByVal itemCode As String, ByVal workOrderNo As String, _
                                                             ByVal dateFrom As String, ByVal dateTo As String, _
                                                             ByVal loginId As String) As DataSet
            Dim webDBManager As New ABCDWebDBManager(UserId)
            Dim dataSet As DataSet = Nothing
            Dim sqlSelect As New StringBuilder()
            '// WriteStartLog()
            Try
                webDBManager.Connect()

                sqlSelect.Append("SELECT A.WO_NO, A.WO_DT, A.ITEM_CD, B.ITEM_NM, A.PRODUCT_QTY, A.REMAIN_QTY, A.QTY_PER_BOX, A.TOTAL_BOX, B.CUR_BOX_NUM ")
                sqlSelect.Append("FROM   PRODUCT_INFO_TR AS A, ")
                sqlSelect.Append("       ITEM_MASTER_MS  AS B  ")
                sqlSelect.Append("WHERE  A.ITEM_CD = B.ITEM_CD ")
                '// sqlSelect.Append("  AND  A.ISSUE_FLG = 0 ") Search not check issue flag.

                If Not itemCode.Equals("") Then
                    sqlSelect.Append("  AND  A.ITEM_CD = @P1       ")
                End If

                If Not workOrderNo.Equals("") Then
                    sqlSelect.Append("  AND  A.WO_NO = @P2         ")
                End If

                If Not dateFrom.Equals(" ") Then
                    sqlSelect.Append("  AND  A.WO_DT >= CONVERT(DATETIME, @P3, 103) ")
                End If

                If Not dateTo.Equals(" ") Then
                    sqlSelect.Append("  AND  A.WO_DT <= CONVERT(DATETIME, @P4, 103) ")
                End If

                sqlSelect.Append("ORDER BY  A.WO_NO ASC ")

                webDBManager.SetCommandText(sqlSelect.ToString)
                webDBManager.AddParameterChar("P1", itemCode)
                webDBManager.AddParameterChar("P2", workOrderNo)

                If Not dateFrom.Equals(" ") Then
                    webDBManager.AddParameter("P3", dateFrom)
                End If

                If Not dateTo.Equals(" ") Then
                    webDBManager.AddParameter("P4", dateTo)
                End If

                dataSet = webDBManager.ExecuteDataSetFill()
                Return dataSet
            Catch ex As Exception
                webDBManager.Rollback()
                dataSet.Dispose()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                dataSet.Dispose()
                webDBManager.Disconnect()
                webDBManager.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="workOrderNo"></param>
        ''' <param name="workOrderDate"></param>
        ''' <param name="itemCode"></param>
        ''' <param name="remainProduct"></param>
        ''' <param name="productQuantity"></param>
        ''' <param name="productDate"></param>
        ''' <param name="quantityPerBox"></param>
        ''' <param name="totalBox"></param>
        ''' <param name="loginCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertScreenProductInfoInquiry(ByVal workOrderNo As List(Of String), ByVal workOrderDate As List(Of String), _
                                                       ByVal itemCode As List(Of String), ByVal remainProduct As List(Of String), _
                                                       ByVal productQuantity As List(Of String), ByVal productDate As List(Of String), _
                                                       ByVal quantityPerBox As List(Of String), ByVal totalBox As List(Of String), _
                                                       ByVal currentBoxNumber As List(Of String), ByVal loginCode As String, _
                                                       ByVal itemName As List(Of String)) As Integer
            Dim numInsert As Integer = 0
            Dim admsDBManager As New ABCDWebDBManager(loginCode)
            Dim sqlInsert As New StringBuilder
            Dim sqlUpdate As New StringBuilder
            Dim lotNo As String = String.Empty
            Dim barcodeNo As String = String.Empty
            Dim boxNumber As Integer = 0
            Dim itemCodeCompare As String = String.Empty
            Dim modBox As Integer = 0

            '// WriteStartLog()

            Try
                admsDBManager.Connect()

                For i As Integer = 0 To workOrderNo.Count - 1 Step 1
                    lotNo = workOrderNo(i).Substring(5, 5) & "-" & ConvertDate(productDate(i)).ToString("yyyyMMdd")

                    If Not itemCode(i).Equals(itemCodeCompare) Then
                        boxNumber = Integer.Parse(currentBoxNumber(i))
                    End If

                    For j As Integer = 1 To Integer.Parse(totalBox(i).Replace(",", "")) Step 1
                        boxNumber = boxNumber + 1

                        If boxNumber > 9999 Then
                            boxNumber = 1
                        End If

                        barcodeNo = workOrderNo(i) & boxNumber.ToString("0000")

                        modBox = Integer.Parse(quantityPerBox(i).Replace(",", ""))

                        If j = Integer.Parse(totalBox(i).Replace(",", "")) Then
                            If Integer.Parse(productQuantity(i).Replace(",", "")) Mod Integer.Parse(quantityPerBox(i).Replace(",", "")) <> 0 Then
                                modBox = Integer.Parse(productQuantity(i).Replace(",", "")) Mod Integer.Parse(quantityPerBox(i).Replace(",", ""))
                            End If
                        End If

                        sqlInsert = New StringBuilder()
                        sqlInsert.Append("INSERT INTO ITEM_DTL_MS")
                        sqlInsert.Append("(")
                        sqlInsert.Append("ITEM_CD, ")
                        sqlInsert.Append("BOX_NUM, ")
                        sqlInsert.Append("BC_NO, ")
                        sqlInsert.Append("QTY, ")
                        sqlInsert.Append("LOT_NO, ")
                        sqlInsert.Append("WO_NO, ")
                        sqlInsert.Append("WO_DT, ")
                        sqlInsert.Append("SHIP_FLG, ")
                        sqlInsert.Append("EXP_FLG, ")
                        sqlInsert.Append("REG_USER_CD, ")
                        sqlInsert.Append("REG_DT, ")
                        sqlInsert.Append("UPD_USER_CD, ")
                        sqlInsert.Append("UPD_DT")
                        sqlInsert.Append(") ")
                        sqlInsert.Append("VALUES ")
                        sqlInsert.Append("(")
                        sqlInsert.Append("@P1, ")
                        sqlInsert.Append("@P2, ")
                        sqlInsert.Append("@P3, ")
                        sqlInsert.Append("@P4, ")
                        sqlInsert.Append("@P5, ")
                        sqlInsert.Append("@P6, ")
                        sqlInsert.Append("@P7, ")
                        sqlInsert.Append("0, ")
                        sqlInsert.Append("1, ")
                        sqlInsert.Append("@P8, ")
                        sqlInsert.Append("GETDATE(), ")
                        sqlInsert.Append("@P8, ")
                        sqlInsert.Append("GETDATE()")
                        sqlInsert.Append(")")
                        admsDBManager.SetCommandText(sqlInsert.ToString)
                        admsDBManager.AddParameterChar("P1", itemCode(i))
                        admsDBManager.AddParameterChar("P2", boxNumber.ToString("0000"))
                        admsDBManager.AddParameterChar("P3", barcodeNo)
                        admsDBManager.AddParameter("P4", modBox)
                        admsDBManager.AddParameterChar("P5", lotNo)
                        admsDBManager.AddParameterChar("P6", workOrderNo(i))
                        admsDBManager.AddParameter("P7", ConvertDate(workOrderDate(i)))
                        admsDBManager.AddParameterChar("P8", loginCode)
                        numInsert = admsDBManager.ExecuteNonQuery()

                        sqlInsert = New StringBuilder()
                        sqlInsert.Append("INSERT INTO WH_INFO_TR")
                        sqlInsert.Append("(")
                        sqlInsert.Append("BC_NO, ")
                        sqlInsert.Append("WH_CD, ")
                        sqlInsert.Append("ITEM_CD, ")
                        sqlInsert.Append("REG_USER_CD, ")
                        sqlInsert.Append("REG_DT, ")
                        sqlInsert.Append("UPD_USER_CD, ")
                        sqlInsert.Append("UPD_DT")
                        sqlInsert.Append(") ")
                        sqlInsert.Append("VALUES ")
                        sqlInsert.Append("(")
                        sqlInsert.Append("@P1, ")
                        sqlInsert.Append("'MOLD', ")
                        sqlInsert.Append("@P2, ")
                        sqlInsert.Append("@P3, ")
                        sqlInsert.Append("GETDATE(), ")
                        sqlInsert.Append("@P3, ")
                        sqlInsert.Append("GETDATE()")
                        sqlInsert.Append(")")
                        admsDBManager.SetCommandText(sqlInsert.ToString)
                        admsDBManager.AddParameterChar("@P1", barcodeNo)
                        admsDBManager.AddParameterChar("@P2", itemCode(i))
                        admsDBManager.AddParameterChar("@P3", loginCode)
                        numInsert = admsDBManager.ExecuteNonQuery()

                        sqlInsert = New StringBuilder()
                        sqlInsert.Append("INSERT INTO WH_HIST_INFO_TR")
                        sqlInsert.Append("(")
                        sqlInsert.Append("BC_NO, ")
                        sqlInsert.Append("HIST_NO, ")
                        sqlInsert.Append("STATUS_FLG, ")
                        sqlInsert.Append("WH_CD, ")
                        sqlInsert.Append("ITEM_CD, ")
                        sqlInsert.Append("ITEM_NM, ")
                        sqlInsert.Append("REG_USER_CD, ")
                        sqlInsert.Append("REG_DT, ")
                        sqlInsert.Append("UPD_USER_CD, ")
                        sqlInsert.Append("UPD_DT")
                        sqlInsert.Append(") ")
                        sqlInsert.Append("VALUES ")
                        sqlInsert.Append("(")
                        sqlInsert.Append("@P1, ")
                        sqlInsert.Append("1, ")
                        sqlInsert.Append("0, ")
                        sqlInsert.Append("'MOLD', ")
                        sqlInsert.Append("@P2, ")
                        sqlInsert.Append("@P3, ")
                        sqlInsert.Append("@P4, ")
                        sqlInsert.Append("GETDATE(), ")
                        sqlInsert.Append("@P4, ")
                        sqlInsert.Append("GETDATE()")
                        sqlInsert.Append(")")
                        admsDBManager.SetCommandText(sqlInsert.ToString)
                        admsDBManager.AddParameterChar("P1", barcodeNo)
                        admsDBManager.AddParameterChar("P2", itemCode(i))
                        admsDBManager.AddParameterChar("P3", itemName(i))
                        admsDBManager.AddParameterChar("P4", loginCode)
                        numInsert = admsDBManager.ExecuteNonQuery()
                    Next

                    Dim remainQuantityCalculate As Integer = 0
                    remainQuantityCalculate = Integer.Parse(remainProduct(i).Replace(",", "")) - Integer.Parse(productQuantity(i).Replace(",", ""))

                    sqlUpdate = New StringBuilder
                    If remainQuantityCalculate <= 0 Then '// Change overload quantity W/O No.
                        sqlUpdate.Append("UPDATE PRODUCT_INFO_TR ")
                        sqlUpdate.Append("SET ISSUE_FLG = 1 ")
                        sqlUpdate.Append("WHERE WO_NO = @P1")
                        admsDBManager.SetCommandText(sqlUpdate.ToString)
                        admsDBManager.AddParameterChar("P1", workOrderNo(i))
                        numInsert = admsDBManager.ExecuteNonQuery()
                    End If

                    sqlUpdate = New StringBuilder()
                    sqlUpdate.Append("UPDATE PRODUCT_INFO_TR ")
                    sqlUpdate.Append("SET REMAIN_QTY = @P2 ")
                    sqlUpdate.Append("WHERE WO_NO = @P1")
                    admsDBManager.SetCommandText(sqlUpdate.ToString)
                    admsDBManager.AddParameterChar("P1", workOrderNo(i))
                    admsDBManager.AddParameter("P2", remainQuantityCalculate)
                    numInsert = admsDBManager.ExecuteNonQuery()

                    sqlUpdate = New StringBuilder()
                    sqlUpdate.Append("UPDATE ITEM_MASTER_MS ")
                    sqlUpdate.Append("SET CUR_BOX_NUM = @P2 ")
                    sqlUpdate.Append("WHERE ITEM_CD = @P1")
                    admsDBManager.SetCommandText(sqlUpdate.ToString)
                    admsDBManager.AddParameterChar("P1", itemCode(i))
                    admsDBManager.AddParameterChar("P2", boxNumber.ToString("0000"))
                    numInsert = admsDBManager.ExecuteNonQuery()

                    itemCodeCompare = itemCode(i)
                Next

                admsDBManager.Commit()
                Return numInsert
            Catch ex As Exception
                admsDBManager.Rollback()
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                admsDBManager.Disconnect()
                admsDBManager.Dispose()
                '// WriteEndLog()
                admsDBManager = Nothing
            End Try
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBarcode(ByVal loginCode As String, ByVal limitData As Integer, _
                                   ByVal barcodeFrom As String, ByVal barcodeTo As String) As DataSet
            Dim admsDBManager As New ABCDWebDBManager(loginCode)
            Dim dataSet As DataSet = Nothing
            Dim sqlSelect As New StringBuilder()

            '// WriteStartLog()

            Try
                admsDBManager.Connect()

                If limitData <> 0 Then
                    sqlSelect.AppendFormat("SELECT TOP {0} A.TEMP_TYPE AS 'Pattern Type', ", limitData)
                End If

                If limitData = 0 Then
                    sqlSelect.Append("SELECT A.TEMP_TYPE AS 'Pattern Type', ")
                End If

                sqlSelect.Append("       B.BC_NO AS 'Barcode No', ")
                sqlSelect.Append("       B.LOT_NO AS 'Lot No', ")
                sqlSelect.Append("       B.ITEM_CD AS 'Part No', ")
                sqlSelect.Append("       A.ITEM_NM AS 'Part Name', ")
                sqlSelect.Append("       B.BOX_NUM AS 'Box No', ")
                sqlSelect.Append("       B.QTY AS 'Qty/Box', ")
                'sqlSelect.Append("      CONVERT(VARCHAR(5),B.QTY) AS 'boxQtyStr', ")

                'sqlSelect.Append("       CASE WHEN A.UNIT = '1' THEN 'Pcs' ELSE '' END AS 'Unit', ")
                '<< LanNT - 20160901: Dynamic Unit query
                sqlSelect.Append("       C.CODE_NAME as 'Unit', ")
                sqlSelect.Append("       A.OROTEX_NO AS 'OROTEX NO', ")
                sqlSelect.Append("       A.IMG_PATH1 AS 'Image Path 1', ")
                sqlSelect.Append("       A.IMG_PATH2 AS 'Image Path 2', ")
                sqlSelect.Append("       A.IMG_PATH3 AS 'Image Path 3', ")
                sqlSelect.Append("       A.IMG_PATH4 AS 'Image Path 4', ")
                sqlSelect.Append("       A.IMG_PATH5 AS 'Image Path 5', ")
                sqlSelect.Append("       1 AS 'Qty' ")
                sqlSelect.Append("FROM   ITEM_MASTER_MS AS A, ")
                sqlSelect.Append("       ITEM_DTL_MS AS B, ")
                sqlSelect.Append("       CODE_MASTER_MS AS C ")
                sqlSelect.Append("WHERE  A.ITEM_CD = B.ITEM_CD ")
                sqlSelect.Append("  AND C.CODE_01 = 1 ")
                sqlSelect.Append("  AND  A.UNIT = C.CODE_02 ")
                '>>

                '// cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN - start
                If Not String.Empty.Equals(barcodeFrom) Or Not String.Empty.Equals(barcodeTo) Then
                    If barcodeFrom.Equals(barcodeTo) Then
                        sqlSelect.Append(" AND ")
                        sqlSelect.Append("   B.BC_NO LIKE '%'+@P1+'%' ")
                    Else
                        If Not String.Empty.Equals(barcodeFrom) Then
                            sqlSelect.Append(" AND ")
                            sqlSelect.Append("   B.BC_NO >= @P1 ")
                        End If
                        If Not String.Empty.Equals(barcodeTo) Then
                            sqlSelect.Append(" AND ")
                            sqlSelect.Append("   B.BC_NO <= @P2 ")
                        End If
                    End If
                End If
                '// cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN - end

                'If Not String.Empty.Equals(barcodeFrom) Then
                '    sqlSelect.Append("  AND B.BC_NO >= @P1 ")
                'End If

                'If Not String.Empty.Equals(barcodeTo) Then
                '    sqlSelect.Append("  AND B.BC_NO <= @P2 ")
                'End If

                sqlSelect.Append("ORDER BY B.REG_DT DESC ")

                admsDBManager.SetCommandText(sqlSelect.ToString)
                admsDBManager.AddParameterChar("P1", barcodeFrom)
                admsDBManager.AddParameterChar("P2", barcodeTo)

                dataSet = admsDBManager.ExecuteDataSetFill
                Return dataSet
            Catch ex As Exception
                WriteErrorLog(ex.Message)
                Throw ex
            Finally
                admsDBManager.Disconnect()
                admsDBManager.Dispose()
                dataSet = Nothing
                '// WriteEndLog()
                admsDBManager = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Get data item detail by work order.
        ''' </summary>
        ''' <param name="workOrderNo"></param>
        ''' <param name="loginCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemDetailByWorkOrderNo(ByVal workOrderNo As String, ByVal loginCode As String) As DataSet
            Dim admsDbManager As New ABCDWebDBManager(loginCode)
            Dim dataSet As DataSet = Nothing
            Dim sqlSelect As New StringBuilder()

            '// WriteStartLog()    '' Start work to write log.

            Try
                admsDbManager.Connect()    '' Open connect to database.

                '' Write query.
                sqlSelect.Append("SELECT  B.* ")
                sqlSelect.Append("FROM    ITEM_DTL_MS AS A, ")
                sqlSelect.Append("        PRODUCT_INFO_TR AS B ")
                sqlSelect.Append("WHERE   A.WO_NO = B.WO_NO ")
                sqlSelect.Append("  AND   A.WO_NO = @P1 ")

                '' Configure for admsDbManager.
                admsDbManager.SetCommandText(sqlSelect.ToString)
                admsDbManager.AddParameterChar("P1", workOrderNo)

                dataSet = admsDbManager.ExecuteDataSetFill()

                Return dataSet
            Catch ex As Exception
                WriteErrorLog(ex)
                Throw ex
            Finally
                admsDbManager.Disconnect()
                admsDbManager.Dispose()
                '// WriteEndLog()
                dataSet.Dispose()
                dataSet = Nothing
                admsDbManager = Nothing
            End Try
        End Function

        Public Function GetItemDetailByWorkNo(ByVal woNo As String, ByVal login As String) As DataSet
            Dim admsDbManager As New ABCDWebDBManager(login)
            Dim dataSet As DataSet = Nothing
            Dim sqlSelect As New StringBuilder()

            '// WriteStartLog()    '' Start work to write log.

            Try
                admsDbManager.Connect()    '' Open connect to database.

                '' Write query.
                sqlSelect.Append("SELECT   A.* ")
                sqlSelect.Append("FROM     ITEM_DTL_MS AS A ")
                sqlSelect.Append("WHERE    A.WO_NO = @P1 ")
                '' sqlSelect.Append("ORDER BY BOX_NUM DESC")
				sqlSelect.Append("ORDER BY REG_DT DESC") '' Sort REG_DT desc 29/03/2016

                '' Configure for admsDbManager.
                admsDbManager.SetCommandText(sqlSelect.ToString)
                admsDbManager.AddParameterChar("P1", woNo)

                dataSet = admsDbManager.ExecuteDataSetFill()

                Return dataSet
            Catch ex As Exception
                WriteErrorLog(ex)
                Throw ex
            Finally
                admsDbManager.Disconnect()
                admsDbManager.Dispose()
                '// WriteEndLog()
                dataSet.Dispose()
                dataSet = Nothing
                admsDbManager = Nothing
            End Try
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="stringDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ConvertDate(ByVal stringDate As String) As Date
            Dim resultDate As Date = Nothing
            Try
                Date.TryParseExact(stringDate, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, resultDate)
                Return resultDate
            Catch ex As Exception
                resultDate = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Function Name: Get information item detail by barcode no.
        ''' </summary>
        ''' <param name="barcodeNo">barcodeNo</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemDetailByBarcode(ByVal barcodeNo As String, ByVal loginCode As String) As DataSet
            Dim dataSet As DataSet = Nothing
            Dim dbManager As New ABCDWebDBManager(loginCode)
            Dim sqlSelect As New StringBuilder()

            Try
                dbManager.Connect()     '' Open connect to DB.

                '' Set query to get data.
                sqlSelect.Append("SELECT A.*, B.ITEM_NM ")
                sqlSelect.Append("FROM   ITEM_DTL_MS AS A, ")
                sqlSelect.Append("       ITEM_MASTER_MS AS B ")
                sqlSelect.Append("WHERE  A.ITEM_CD = B.ITEM_CD ")
                sqlSelect.Append("  AND  A.BC_NO = @P1")

                dbManager.SetCommandText(sqlSelect.ToString)
                dbManager.AddParameterChar("P1", barcodeNo)

                dataSet = dbManager.ExecuteDataSetFill
                Return dataSet
            Catch ex As Exception
                Throw ex
            Finally
                dataSet.Dispose()
                dbManager.Disconnect()
                dbManager.Dispose()
            End Try
        End Function

        ''' <summary>
        ''' Check barcode exist in W900 or W830.
        ''' cuongtk(20150831).
        ''' </summary>
        ''' <param name="listBarcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsExistW900OrW830(ByVal listBarcode As String) As Boolean
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim isExistNum As Integer = 0
            Try
                webDbManager.Connect()
                sqlBuilder.Append(" SELECT COUNT(*) ")
                sqlBuilder.Append(" FROM WH_INFO_TR ")
                sqlBuilder.AppendFormat(" WHERE BC_NO IN ({0}) AND WH_CD != 'MOLD' ", listBarcode)
                webDbManager.SetCommandText(sqlBuilder.ToString)
                isExistNum = webDbManager.ExecuteScalarInt32
                If isExistNum > 0 Then
                    Return False
                End If
                Return True
            Catch ex As Exception
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' Function Name: Update quantity and lot no information item detail by barcode.
        ''' </summary>
        ''' <param name="barcodeNo">barcodeNo</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateItemDetailByBarcode(ByVal barcodeNo As String, ByVal quantity As Integer, _
                                                  ByVal productQuantity As Integer, _
                                                  ByVal woNo As String, _
                                                  ByVal lotNo As String, ByVal loginCode As String) As Integer
            Dim dbManager As New ABCDWebDBManager(loginCode)
            Dim sqlUpdate As New StringBuilder()

            Try
                dbManager.Connect()
                Dim rowUpdate As Integer = 0

                sqlUpdate = New StringBuilder()
                sqlUpdate.Append("UPDATE ITEM_DTL_MS ")
                sqlUpdate.Append("SET    QTY = @P1, LOT_NO = @P2 ")
                sqlUpdate.Append("WHERE  BC_NO = @P3")
                dbManager.SetCommandText(sqlUpdate.ToString)
                dbManager.AddParameter("P1", quantity)
                dbManager.AddParameter("P2", lotNo)
                dbManager.AddParameter("P3", barcodeNo)
                rowUpdate = dbManager.ExecuteNonQuery()

                dbManager.Commit()
                Return rowUpdate
            Catch ex As Exception
                dbManager.Rollback()
                Throw ex
            Finally
                dbManager.Disconnect()
                dbManager.Dispose()
            End Try
        End Function

        Public Function GetListBarcode(ByVal paramWoNo As String, _
                                       ByVal paramBcFrom As String, ByVal paramBcTo As String, _
                                       ByVal paramQuantity As Integer, _
                                       ByVal paramLoginCode As String) As DataSet
            Dim dataSet As DataSet = Nothing
            Dim dbManager As New ABCDWebDBManager(paramLoginCode)
            Dim sqlSelect As New StringBuilder()

            Try
                dbManager.Connect()

                sqlSelect.Append("SELECT A.BC_NO, A.ITEM_CD, B.ITEM_NM, A.BOX_NUM, A.QTY, A.LOT_NO, A.WO_NO ")
                sqlSelect.Append("FROM   ITEM_DTL_MS AS A, ")
                sqlSelect.Append("       ITEM_MASTER_MS AS B, ")
                sqlSelect.Append("       WH_INFO_TR AS C ")
                sqlSelect.Append("WHERE  A.ITEM_CD = B.ITEM_CD ")
                sqlSelect.Append("  AND  A.BC_NO = C.BC_NO ")
                'sqlSelect.Append("  AND  C.WH_CD = 'MOLD' ")
                sqlSelect.Append("  AND  A.WO_NO = @P1 ")
                '' Value barcode from is null.
                If paramBcFrom <> "" Then
                    sqlSelect.Append("  AND  A.BOX_NUM >= @P2 ")
                End If
                '' Value barcode to is null.
                If paramBcTo <> "" Then
                    sqlSelect.Append("  AND  A.BOX_NUM <= @P3 ")
                End If
                '' Value quantity is 0.
                If paramQuantity <> 0 Then
                    sqlSelect.Append("  AND  A.QTY = @P4 ")
                End If
                '' Config param and set query.
                dbManager.SetCommandText(sqlSelect.ToString)
                dbManager.AddParameterChar("P1", paramWoNo)
                dbManager.AddParameterChar("P2", paramBcFrom)
                dbManager.AddParameterChar("P3", paramBcTo)
                dbManager.AddParameterChar("P4", paramQuantity)
                dataSet = dbManager.ExecuteDataSetFill()
                Return dataSet
            Catch ex As Exception
                Throw ex
            Finally
                dataSet.Dispose()
                dbManager.Disconnect()
                dbManager.Dispose()
            End Try
        End Function

        Public Function UpdateItemDetail(ByVal listBarcode As List(Of String), _
                                         ByVal currentBoxNum As Integer, _
                                         ByVal itemCode As String, _
                                         ByVal remainQuantity As Integer, _
                                         ByVal woNo As String, _
                                         ByVal loginCode As String) As Integer
            Dim sqlDelete As New StringBuilder()
            Dim sqlUpdate As New StringBuilder()
            Dim admsDBManager As New ABCDWebDBManager(loginCode)
            Dim row As Integer = 0

            Try
                admsDBManager.Connect()
                'Duyet toan bo danh sach Barcode lay duoc tu man hinh.
                For i As Integer = 0 To listBarcode.Count - 1 Step 1
                    'Xoa du lieu bang ITEM_DTL_MS.
                    sqlDelete = New StringBuilder()
                    sqlDelete.Append("DELETE FROM ITEM_DTL_MS ")
                    sqlDelete.Append("WHERE  BC_NO = @P1")
                    admsDBManager.SetCommandText(sqlDelete.ToString())
                    admsDBManager.AddParameterChar("P1", listBarcode(i))
                    admsDBManager.ExecuteNonQuery()
                    'Xoa du lieu bang WH_HIST_INFO_TR.
                    sqlDelete = New StringBuilder()
                    sqlDelete.Append("DELETE FROM WH_HIST_INFO_TR ")
                    sqlDelete.Append("WHERE  BC_NO = @P1")
                    admsDBManager.SetCommandText(sqlDelete.ToString())
                    admsDBManager.AddParameterChar("P1", listBarcode(i))
                    admsDBManager.ExecuteNonQuery()
                    'Xoa du lieu bang WH_INFO_TR.
                    sqlDelete = New StringBuilder()
                    sqlDelete.Append("DELETE FROM WH_INFO_TR ")
                    sqlDelete.Append("WHERE  BC_NO = @P1")
                    admsDBManager.SetCommandText(sqlDelete.ToString())
                    admsDBManager.AddParameterChar("P1", listBarcode(i))
                    admsDBManager.ExecuteNonQuery()
                Next
                'Cap nhat lai bang ITEM_MASTER_MS.
                sqlUpdate = New StringBuilder()
                sqlUpdate.Append("UPDATE ITEM_MASTER_MS ")
                sqlUpdate.Append("SET    CUR_BOX_NUM = @P2 ")
                sqlUpdate.Append("WHERE  ITEM_CD = @P1")
                admsDBManager.SetCommandText(sqlUpdate.ToString())
                admsDBManager.AddParameterChar("P1", itemCode)
                admsDBManager.AddParameterChar("P2", currentBoxNum.ToString("0000"))
                row = admsDBManager.ExecuteNonQuery()
                'Cap nhat lai bang PRODUCT_INFO_TR.
                sqlUpdate = New StringBuilder()
                sqlUpdate.Append("UPDATE PRODUCT_INFO_TR ")
                sqlUpdate.Append("SET    REMAIN_QTY = @P2, ")
                sqlUpdate.Append("       ISSUE_FLG = 0 ")
                sqlUpdate.Append("WHERE  WO_NO = @P1")
                admsDBManager.SetCommandText(sqlUpdate.ToString())
                admsDBManager.AddParameterChar("P1", woNo)
                admsDBManager.AddParameter("P2", remainQuantity)
                row = admsDBManager.ExecuteNonQuery()
                admsDBManager.Commit()
                Return row
            Catch ex As Exception
                Throw ex
            Finally
                admsDBManager.Disconnect()
                admsDBManager.Dispose()
            End Try
        End Function

#Region "Cap nhat ngay 2015-03-27"

        ''' <summary>
        ''' Lay toan bo du lieu Item Detail ung voi W/O truyen vao.
        ''' Sap xep theo Barcode tang dan.
        ''' </summary>
        ''' <param name="woNo"></param>
        ''' <param name="login"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemDetailByWorkNoOrderBarcodeAsc(ByVal woNo As String, ByVal login As String) As DataSet
            Dim admsDbManager As New ABCDWebDBManager(login)
            Dim dataSet As DataSet = Nothing
            Dim sqlSelect As New StringBuilder()
            '// WriteStartLog()    '' Start work to write log.
            Try
                admsDbManager.Connect()    '' Open connect to database.
                '' Write query.
                sqlSelect.Append("SELECT   A.*, B.ITEM_NM ")
                sqlSelect.Append("FROM     ITEM_DTL_MS AS A, ")
                sqlSelect.Append("         ITEM_MASTER_MS AS B, ")
                sqlSelect.Append("         WH_INFO_TR AS C ") '' Moi them vo ngay 2015-03-29.
                sqlSelect.Append("WHERE    A.WO_NO = @P1 ")
                sqlSelect.Append("  AND    A.ITEM_CD = B.ITEM_CD ")
                sqlSelect.Append("  AND    A.BC_NO = C.BC_NO ") '' Moi them vo ngay 2015-03-29.
                sqlSelect.Append("  AND    C.WH_CD = 'MOLD' ") '' Moi them vo ngay 2015-03-29.
                sqlSelect.Append("ORDER BY BC_NO ASC")
                '' Configure for admsDbManager.
                admsDbManager.SetCommandText(sqlSelect.ToString)
                admsDbManager.AddParameterChar("P1", woNo)
                dataSet = admsDbManager.ExecuteDataSetFill()
                Return dataSet
            Catch ex As Exception
                WriteErrorLog(ex)
                Throw ex
            Finally
                admsDbManager.Disconnect()
                admsDbManager.Dispose()
                '// WriteEndLog()
                dataSet.Dispose()
                dataSet = Nothing
                admsDbManager = Nothing
            End Try
        End Function

#End Region

#Region "Cap nhat ngay 2015-03-29"

        ''' <summary>
        ''' Phuong thuc xu ly: Cap nhat so luong trong mot thung.
        ''' </summary>
        ''' <param name="barcodeFrom">Barcode cua thung le dau tien.</param>
        ''' <param name="quantityFrom">Quantity cua thung le dau tien.</param>
        ''' <param name="barcodeTo">Barcode cua thung le cuoi cung.</param>
        ''' <param name="quantityTo">Quantity cua thung le cuoi cung.</param>
        ''' <param name="loginCode">Nguoi dung dang thao tac.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateQuantityInBoxByBarcode(ByVal barcodeFrom As String, ByVal lotNoFrom As String, ByVal quantityFrom As Integer, _
                                                     ByVal barcodeTo As String, ByVal lotNoTo As String, ByVal quantityTo As Integer, _
                                                     ByVal itemCode As String, ByVal currentBoxNum As Integer, _
                                                     ByVal loginCode As String) As Integer
            Dim dbManager As New ABCDWebDBManager(loginCode)
            Dim strBuilder As New StringBuilder()
            Dim row As Integer = 0

            Try
                '' Mo ket noi den database.
                dbManager.Connect()
                '' 1. Cap nhat lai so luong(quantity) trong thung bi le dau tien.
                strBuilder.Append("UPDATE ITEM_DTL_MS ")
                strBuilder.Append("SET    LOT_NO = @P2 ")
                strBuilder.Append("      ,QTY = @P3 ")
                strBuilder.Append("      ,UPD_DT = GETDATE() ")
                strBuilder.Append("WHERE  BC_NO = @P1 ")
                dbManager.SetCommandText(strBuilder.ToString())
                dbManager.AddParameterChar("P1", barcodeFrom)
                dbManager.AddParameterChar("P2", lotNoFrom)
                dbManager.AddParameter("P3", quantityFrom)
                row = row + dbManager.ExecuteNonQuery() '' Cap nhat so dong duoc thay doi.
                '' 2. Cap nhat lai so luong(quantity) trong thung bi le cuoi cung.
                strBuilder = New StringBuilder()
                If quantityTo = 0 Then
                    strBuilder.Append("DELETE FROM ITEM_DTL_MS ")
                    strBuilder.Append("WHERE       BC_NO = @P1 ")
                Else
                    strBuilder.Append("UPDATE ITEM_DTL_MS ")
                    strBuilder.Append("SET    LOT_NO = @P2 ")
                    strBuilder.Append("      ,QTY = @P3 ")
                    strBuilder.Append("      ,UPD_DT = GETDATE() ")
                    strBuilder.Append("WHERE  BC_NO = @P1 ")
                End If
                dbManager.SetCommandText(strBuilder.ToString())
                dbManager.AddParameterChar("P1", barcodeTo)
                dbManager.AddParameterChar("P2", lotNoTo)
                dbManager.AddParameter("P3", quantityTo)
                row = row + dbManager.ExecuteNonQuery() '' Cap nhat so dong duoc thay doi.
                '' 3. Cap nhat lai so luong thung(neu xoa mot nhan(label) o buoc 2).
                strBuilder = New StringBuilder()
                If quantityTo = 0 Then
                    '' 3.1 Xoa du lieu o bang WH_INFO_TR.
                    strBuilder.Append("DELETE FROM WH_INFO_TR ")
                    strBuilder.Append("WHERE       BC_NO = @P1 ")
                    dbManager.SetCommandText(strBuilder.ToString())
                    dbManager.AddParameterChar("P1", barcodeTo)
                    row = row + dbManager.ExecuteNonQuery()

                    '' 3.2 Xoa du lieu o bang WH_HIST_INFO_TR.
                    strBuilder = New StringBuilder()
                    strBuilder.Append("DELETE FROM WH_HIST_INFO_TR ")
                    strBuilder.Append("WHERE       BC_NO = @P1 ")
                    dbManager.SetCommandText(strBuilder.ToString())
                    dbManager.AddParameterChar("P1", barcodeTo)
                    row = row + dbManager.ExecuteNonQuery()

                    '' 3.3 Cap nhat du lieu bang ITEM_MASTER_MS.
                    strBuilder = New StringBuilder()
                    strBuilder.Append("UPDATE ITEM_MASTER_MS ")
                    strBuilder.Append("SET    CUR_BOX_NUM = @P2 ")
                    strBuilder.Append("WHERE  ITEM_CD = @P1 ")
                    dbManager.SetCommandText(strBuilder.ToString())
                    dbManager.AddParameterChar("P1", itemCode)
                    dbManager.AddParameterChar("P2", currentBoxNum.ToString("0000"))
                    row = row + dbManager.ExecuteNonQuery() '' Cap nhat so dong duoc thay doi.
                End If
                dbManager.Commit()
                Return row '' Tra ve tong so dong duoc thay doi o moi lan thuc hien.
            Catch ex As Exception
                '' Rollback lai qua trinh xu ly du lieu.
                dbManager.Rollback()
                Throw ex
            Finally
                '' Dong ket noi den database.
                dbManager.Disconnect()
                dbManager.Dispose()
            End Try
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="lgCd"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPrintBarcode(ByVal qtyTo As String, ByVal lgCd As String) As DataSet
            Dim dbMng As New ABCDWebDBManager(lgCd)
            Dim ds As DataSet = Nothing
            Dim sb As New StringBuilder()
            Try
                dbMng.Connect()
                sb.Append("SELECT   TOP 2 A.TEMP_TYPE AS 'Pattern Type', ")
                If qtyTo.Equals("0") Then
                    sb = New StringBuilder()
                    sb.Append("SELECT   TOP 1 A.TEMP_TYPE AS 'Pattern Type', ")
                End If
                sb.Append("         B.BC_NO AS 'Barcode No', ")
                sb.Append("         B.LOT_NO AS 'Lot No', ")
                sb.Append("         B.ITEM_CD AS 'Part No', ")
                sb.Append("         A.ITEM_NM AS 'Part Name', ")
                sb.Append("         B.BOX_NUM AS 'Box No', ")
                sb.Append("         B.QTY AS 'Qty/Box', ")
                sb.Append("         CASE WHEN A.UNIT = '1' THEN 'Pcs' ELSE '' END AS 'Unit', ")
                sb.Append("         A.OROTEX_NO AS 'OROTEX NO', ")
                sb.Append("         A.IMG_PATH1 AS 'Image Path 1', ")
                sb.Append("         A.IMG_PATH2 AS 'Image Path 2', ")
                sb.Append("         A.IMG_PATH3 AS 'Image Path 3', ")
                sb.Append("         A.IMG_PATH4 AS 'Image Path 4', ")
                sb.Append("         A.IMG_PATH5 AS 'Image Path 5', ")
                sb.Append("         1 AS 'Qty' ")
                sb.Append("FROM     ITEM_DTL_MS AS B ")
                sb.Append("        ,ITEM_MASTER_MS AS A ")
                sb.Append("WHERE    A.ITEM_CD = B.ITEM_CD ")
                sb.Append("ORDER BY B.UPD_DT DESC ")

                dbMng.SetCommandText(sb.ToString())

                ds = dbMng.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                ds.Dispose()
                dbMng.Disconnect()
                dbMng.Dispose()
            End Try
        End Function

#End Region

#Region "Cap nhat ngay 01/04/2015 - AIT) cuongtk"

#End Region

#Region "Add source (charge)"

        ''' <summary>
        ''' Get data screen Shipment Inquiry By Invoice No
        ''' cuongtk - 20150820: #No.30 add new screen Shipment Inquiry By Invoice No
        ''' </summary>
        ''' <param name="invoiceNo"></param>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetShipmentInquiryByInvoiceNo(ByVal invoiceNo As String, ByVal itemCode As String) As DataSet
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim dataSet As New DataSet
            Try
                webDbManager.Connect()

                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("  DISTINCT ")
                sqlBuilder.Append("   SRIT.SHIP_DT, ")
                sqlBuilder.Append("   SRIT.SHIP_REQ_NO, ")
                sqlBuilder.Append("   SRDIT.PALLET_NO, ")
                sqlBuilder.Append("   IDM.ITEM_CD, ")
                sqlBuilder.Append("   IMM.ITEM_NM, ")
                sqlBuilder.Append("   IDM.QTY, ")
                sqlBuilder.Append("   IDM.LOT_NO, ")
                sqlBuilder.Append("   SRIT.INVOICE_NO, ")
                sqlBuilder.Append("   SRDIT.BC_NO, ")
                sqlBuilder.Append("   CMM.CUS_ID ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   SHIP_REQ_INFO_TR AS SRIT ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   SHIP_REQ_DTL_INFO_TR AS SRDIT ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   SRIT.SHIP_REQ_NO=SRDIT.SHIP_REQ_NO ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   ITEM_DTL_MS AS IDM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   IDM.BC_NO = SRDIT.BC_NO ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   ITEM_MASTER_MS AS IMM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   IMM.ITEM_CD = IDM.ITEM_CD ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   CUS_MASTER_MS AS CMM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   SRIT.CUS_ID = CMM.CUS_ID ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append("  AND ")
                sqlBuilder.Append("   SRIT.INVOICE_NO LIKE '%' + @P1 + '%' ")
                If Not String.Empty.Equals(itemCode) Then
                    sqlBuilder.Append("  AND ")
                    sqlBuilder.Append("   IDM.ITEM_CD LIKE '%' + @P2 + '%'")
                End If

                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", invoiceNo)
                If Not String.Empty.Equals(itemCode) Then
                    webDbManager.AddParameterChar("P2", itemCode)
                End If
                Dim dataTable1 As DataTable = webDbManager.ExecuteDataTableFill

                sqlBuilder = New StringBuilder
                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("  DISTINCT ")
                sqlBuilder.Append("   SRIT.SHIP_DT, ")
                sqlBuilder.Append("   SRIT.SHIP_REQ_NO, ")
                sqlBuilder.Append("   SADIT.PALLET_NO, ")
                sqlBuilder.Append("   IDM.ITEM_CD, ")
                sqlBuilder.Append("   IMM.ITEM_NM, ")
                sqlBuilder.Append("   IDM.QTY, ")
                sqlBuilder.Append("   IDM.LOT_NO, ")
                sqlBuilder.Append("   SRIT.INVOICE_NO, ")
                sqlBuilder.Append("   SADIT.BC_NO, ")
                sqlBuilder.Append("   CMM.CUS_ID ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   SHIP_REQ_INFO_TR AS SRIT ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   SHIP_ACT_DTL_INFO_TR AS SADIT ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   SRIT.SHIP_REQ_NO=SADIT.SHIP_REQ_NO ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   ITEM_DTL_MS AS IDM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   IDM.BC_NO = SADIT.BC_NO ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   ITEM_MASTER_MS AS IMM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   IMM.ITEM_CD = IDM.ITEM_CD ")
                sqlBuilder.Append("  INNER JOIN ")
                sqlBuilder.Append("   CUS_MASTER_MS AS CMM ")
                sqlBuilder.Append("  ON ")
                sqlBuilder.Append("   SRIT.CUS_ID = CMM.CUS_ID ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append("  AND ")
                sqlBuilder.Append("   SRIT.INVOICE_NO LIKE '%' + @P1 + '%' ")
                If Not String.Empty.Equals(itemCode) Then
                    sqlBuilder.Append("  AND ")
                    sqlBuilder.Append("   IDM.ITEM_CD LIKE '%' + @P2 + '%'")
                End If
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", invoiceNo)
                If Not String.Empty.Equals(itemCode) Then
                    webDbManager.AddParameterChar("P2", itemCode)
                End If
                Dim dataTable2 As DataTable = webDbManager.ExecuteDataTableFill

                If dataTable1.Rows.Count > 0 Then
                    dataSet.Tables.Add(dataTable1)
                End If
                If dataTable2.Rows.Count > 0 Then
                    dataSet.Tables.Add(dataTable2)
                End If

                webDbManager.Disconnect()
                webDbManager.Dispose()

                Return dataSet
            Catch ex As Exception
                webDbManager.Disconnect()
                webDbManager.Dispose()
                webDbManager = Nothing
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' Get Quantity With Item Code
        ''' cuongtk - 20150821: #No.31: export csv to print label have ODD and EVEN (Wait confirm)
        ''' </summary>
        ''' <param name="itemCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetQuantityByItemCode(ByVal itemCode As String) As Integer

        End Function

        ''' <summary>
        ''' #No.23: new method return W900
        ''' </summary>
        ''' <param name="scanBarcode"></param>
        ''' <param name="loginId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckDataIsValidToReturnW900(ByVal scanBarcode As String, ByVal loginId As String) As String
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim contentMsg As String = String.Empty
            Try
                webDbManager.Connect()

                '// Get barcode is shipment
                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("   SHIP_FLG ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   ITEM_DTL_MS ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append("  AND ")
                sqlBuilder.Append("   BC_NO = @P1 ")
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", scanBarcode)
                Dim shipFlag As Integer = webDbManager.ExecuteScalarInt32
                If shipFlag = 1 Then
                    contentMsg = "ERR192"
                    Return contentMsg
                End If

                '// Get barcode is existed warehouse
                sqlBuilder = New StringBuilder
                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("   WH_CD ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   WH_HIST_INFO_TR ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append("  AND ")
                sqlBuilder.Append("   BC_NO = @P1 ")
                sqlBuilder.Append("  AND ")
                sqlBuilder.Append("   HIST_NO = ( ")
                sqlBuilder.Append("               SELECT ")
                sqlBuilder.Append("                 MAX(HIST_NO) AS MAX ")
                sqlBuilder.Append("               FROM ")
                sqlBuilder.Append("                 WH_HIST_INFO_TR ")
                sqlBuilder.Append("               WHERE ")
                sqlBuilder.Append("                 1 = 1 ")
                sqlBuilder.Append("                AND ")
                sqlBuilder.Append("                 BC_NO = @P1 ")
                sqlBuilder.Append("             ) ")
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", scanBarcode)
                Dim warehouseCd As String = webDbManager.ExecuteScalar
                If "W900".Equals(Trim(warehouseCd)) Then
                    contentMsg = "ERR193"
                    Return contentMsg
                ElseIf "MOLD".Equals(Trim(warehouseCd)) Then
                    contentMsg = "ERR194"
                    Return contentMsg
                End If

                '// Update table WH_INFO_TR
                sqlBuilder = New StringBuilder
                sqlBuilder.Append(" UPDATE ")
                sqlBuilder.Append("   WH_INFO_TR ")
                sqlBuilder.Append(" SET ")
                sqlBuilder.Append("   WH_CD = 'W900', ")
                sqlBuilder.Append("   RACK_CD = NULL, ")
                sqlBuilder.Append("   UPD_USER_CD = @P2, ")
                sqlBuilder.Append("   UPD_DT = GETDATE() ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   BC_NO = @P1 ")
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", scanBarcode)
                webDbManager.AddParameterChar("P2", loginId)
                webDbManager.ExecuteNonQuery()

                '// Insert table WH_HIST_INFO_TR
                sqlBuilder = New StringBuilder
                sqlBuilder.Append(" INSERT INTO ")
                sqlBuilder.Append("   WH_HIST_INFO_TR ")
                sqlBuilder.Append("   ( ")
                sqlBuilder.Append("     BC_NO, ")
                sqlBuilder.Append("     HIST_NO, ")
                sqlBuilder.Append("     STATUS_FLG, ")
                sqlBuilder.Append("     WH_CD, ")
                sqlBuilder.Append("     ITEM_CD, ")
                sqlBuilder.Append("     ITEM_NM, ")
                sqlBuilder.Append("     REG_USER_CD, ")
                sqlBuilder.Append("     REG_DT, ")
                sqlBuilder.Append("     UPD_USER_CD, ")
                sqlBuilder.Append("     UPD_DT ")
                sqlBuilder.Append("   ) ")
                sqlBuilder.Append(" VALUES ")
                sqlBuilder.Append("   ( ")
                sqlBuilder.Append("     @P1, ")
                sqlBuilder.Append("     ( ")
                sqlBuilder.Append("       SELECT ")
                sqlBuilder.Append("         ISNULL(MAX(HIST_NO), 0) + 1 AS HIST_NO ")
                sqlBuilder.Append("       FROM ")
                sqlBuilder.Append("         WH_HIST_INFO_TR ")
                sqlBuilder.Append("       WHERE ")
                sqlBuilder.Append("         1 = 1 ")
                sqlBuilder.Append("        AND ")
                sqlBuilder.Append("         BC_NO = @P1 ")
                sqlBuilder.Append("     ), ")
                sqlBuilder.Append("     16, ")
                sqlBuilder.Append("     'W900', ")
                sqlBuilder.Append("     ( ")
                sqlBuilder.Append("       SELECT ")
                sqlBuilder.Append("         ITEM_CD ")
                sqlBuilder.Append("       FROM ")
                sqlBuilder.Append("         WH_HIST_INFO_TR ")
                sqlBuilder.Append("       WHERE ")
                sqlBuilder.Append("         1 = 1 ")
                sqlBuilder.Append("        AND ")
                sqlBuilder.Append("         BC_NO = @P1 ")
                sqlBuilder.Append("       GROUP BY ")
                sqlBuilder.Append("         ITEM_CD ")
                sqlBuilder.Append("     ), ")
                sqlBuilder.Append("     ( ")
                sqlBuilder.Append("       SELECT ")
                sqlBuilder.Append("         ITEM_NM ")
                sqlBuilder.Append("       FROM ")
                sqlBuilder.Append("         WH_HIST_INFO_TR ")
                sqlBuilder.Append("       WHERE ")
                sqlBuilder.Append("         1 = 1 ")
                sqlBuilder.Append("        AND ")
                sqlBuilder.Append("         BC_NO = @P1 ")
                sqlBuilder.Append("       GROUP BY ")
                sqlBuilder.Append("         ITEM_NM ")
                sqlBuilder.Append("     ), ")
                sqlBuilder.Append("     @P2, ")
                sqlBuilder.Append("     GETDATE(), ")
                sqlBuilder.Append("     @P2, ")
                sqlBuilder.Append("     GETDATE() ")
                sqlBuilder.Append("   ) ")
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", scanBarcode)
                webDbManager.AddParameterChar("P2", loginId)
                webDbManager.ExecuteNonQuery()

                webDbManager.Commit()

                Return contentMsg
            Catch ex As Exception
                WriteErrorLog(ex)
                webDbManager.Disconnect()
                webDbManager.Dispose()
                Throw New Exception
            Finally
                webDbManager.Disconnect()
                webDbManager.Dispose()
                webDbManager = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Get box quantity is odd with item.
        ''' </summary>
        ''' <param name="barcodeNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetInfoOddBoxByItemCode(ByVal barcodeNo As String) As DataSet
            Dim admsManager As New ABCDWebDBManager(Me.UserId)
            Dim queryStr As New StringBuilder()
            Dim dataSet As DataSet = Nothing
            Try
                admsManager.Connect()

                queryStr.Append(" SELECT ")
                queryStr.Append("    T1.*, T2.WH_CD, T3.ITEM_NM, T4.QTY_PER_BOX AS STD_QTY ")
                queryStr.Append(" FROM ")
                queryStr.Append("    ITEM_DTL_MS AS T1, WH_INFO_TR AS T2, ITEM_MASTER_MS AS T3, PRODUCT_INFO_TR AS T4 ")
                queryStr.Append(" WHERE ")
                queryStr.Append("    T1.BC_NO = T2.BC_NO ")
                queryStr.Append("   AND ")
                queryStr.Append("    T1.ITEM_CD = T3.ITEM_CD ")
                queryStr.Append("   AND ")
                queryStr.Append("    T1.ITEM_CD = T4.ITEM_CD ")
                queryStr.Append("   AND ")
                queryStr.Append("    T1.BC_NO = @P1 ")
                queryStr.Append("   AND ")
                queryStr.Append("    T4.WO_NO = SUBSTRING(@P1, 0, 11) ")

                admsManager.SetCommandText(queryStr.ToString())
                admsManager.AddParameterChar("P1", barcodeNo)

                dataSet = admsManager.ExecuteDataSetFill()

                Return dataSet
            Catch ex As Exception
                WriteErrorLog(ex)
                admsManager.Disconnect()
                admsManager.Dispose()
                Throw New Exception
            Finally
                admsManager.Disconnect()
                admsManager.Dispose()
                admsManager = Nothing
            End Try
        End Function

        ''' <summary>
        ''' Update value quantity of "Odd Box" to "Even Box".
        ''' </summary>
        ''' <param name="infoStr">Contains info box get from screen.</param>
        ''' <param name="infoLogin">Information user is processing.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateOddToEvenBox(ByVal infoStr As String, ByVal infoLogin As String) As Integer
            Dim admsManager As New ABCDWebDBManager(Me.UserId)
            Dim arrData As String() = infoStr.Split(",")
            Dim qtyPerBox As Integer = Integer.Parse(arrData(3))
            Dim stdPerBox As Integer = Integer.Parse(arrData(5))
            Dim diffQtyPerBox As Integer = 0
            Dim rowUpd As Integer = 0
            Dim queryStr As New StringBuilder()
            Dim ds As DataSet = Nothing
            Try
                admsManager.Connect()
                
                queryStr.Append(" UPDATE ITEM_DTL_MS ")
                queryStr.Append(" SET    QTY = @P2, ")
                queryStr.Append("        LOT_NO = @P3, ")
                queryStr.Append("        UPD_USER_CD = @P4, ")
                queryStr.Append("        UPD_DT = GETDATE() ")
                queryStr.Append(" WHERE  BC_NO = @P1 ")
                admsManager.SetCommandText(queryStr.ToString())
                admsManager.AddParameterChar("P1", arrData(0))
                admsManager.AddParameter("P2", qtyPerBox)
                admsManager.AddParameter("P3", arrData(4))
                admsManager.AddParameter("P4", infoLogin)
                rowUpd = rowUpd + admsManager.ExecuteNonQuery()

                queryStr = New StringBuilder()
                queryStr.Append("UPDATE WH_INFO_TR ")
                queryStr.Append("SET UPD_USER_CD = @P2, ")
                queryStr.Append("    UPD_DT = GETDATE() ")
                queryStr.Append("WHERE BC_NO = @P1 ")
                queryStr.Append("AND WH_CD = 'MOLD' ")
                admsManager.SetCommandText(queryStr.ToString())
                admsManager.AddParameter("P1", arrData(0))
                admsManager.AddParameter("P2", infoLogin)
                rowUpd = rowUpd + admsManager.ExecuteNonQuery()

                queryStr = New StringBuilder()
                queryStr.Append("UPDATE WH_HIST_INFO_TR ")
                queryStr.Append("SET UPD_USER_CD = @P2, ")
                queryStr.Append("    UPD_DT = GETDATE() ")
                queryStr.Append("WHERE BC_NO = @P1 ")
                queryStr.Append("AND WH_CD = 'MOLD' ")
                admsManager.SetCommandText(queryStr.ToString())
                admsManager.AddParameter("P1", arrData(0))
                admsManager.AddParameter("P2", infoLogin)
                rowUpd = rowUpd + admsManager.ExecuteNonQuery()

                queryStr = New StringBuilder()
                queryStr = queryStr.Append("SELECT SUM(QTY) AS QTY ")
                queryStr = queryStr.Append("FROM ITEM_DTL_MS ")
                queryStr = queryStr.Append("WHERE WO_NO = @P1 ")
                admsManager.SetCommandText(queryStr.ToString())
                admsManager.AddParameter("P1", arrData(0).Substring(0, 10))
                Dim sumQty As Integer = admsManager.ExecuteScalarInt32()

                queryStr = New StringBuilder()
                queryStr = queryStr.Append("SELECT PRODUCT_QTY ")
                queryStr = queryStr.Append("FROM PRODUCT_INFO_TR ")
                queryStr = queryStr.Append("WHERE WO_NO = @P1 ")
                admsManager.SetCommandText(queryStr.ToString())
                admsManager.AddParameter("P1", arrData(0).Substring(0, 10))
                Dim prodQty As Integer = admsManager.ExecuteScalarInt32()

                queryStr = New StringBuilder()
                queryStr = queryStr.Append("UPDATE PRODUCT_INFO_TR ")
                queryStr = queryStr.Append("SET REMAIN_QTY = @P2 ")
                queryStr = queryStr.Append("WHERE WO_NO = @P1 ")
                admsManager.SetCommandText(queryStr.ToString())
                admsManager.AddParameter("P1", arrData(0).Substring(0, 10))
                admsManager.AddParameter("P2", prodQty - sumQty)
                rowUpd = rowUpd + admsManager.ExecuteNonQuery()

                If rowUpd > 0 Then
                    admsManager.Commit()
                End If
                Return rowUpd
            Catch ex As Exception
                WriteErrorLog(ex.Message)
                admsManager.Rollback()
                admsManager.Disconnect()
                admsManager.Dispose()
                Throw New Exception
            Finally
                admsManager.Disconnect()
                admsManager.Dispose()
            End Try
        End Function

        ''' <summary>
        ''' Print label just update current per box.
        ''' </summary>
        ''' <param name="barcodeNo">Data get from screen.</param>
        ''' <param name="infoLogin">Information user is processing.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PrintNewLabel(ByVal barcodeNo As String, ByVal infoLogin As String) As DataSet
            Dim admsManager As New ABCDWebDBManager(Me.UserId)
            Dim ds As DataSet = Nothing
            Dim strQuery As New StringBuilder()
            Try
                '// Open connect to DB.
                admsManager.Connect()
                '// Content query SQL.
                strQuery.Append(" SELECT ")
                strQuery.Append("    T2.TEMP_TYPE AS 'Pattern Type', ") '20160705 - LanNT
                strQuery.Append("    T1.BC_NO AS 'Barcode No', ")
                strQuery.Append("    T1.LOT_NO AS 'Lot No', ")
                strQuery.Append("    T2.ITEM_CD AS 'Part No', ")
                strQuery.Append("    T2.ITEM_NM AS 'Part Name', ")
                strQuery.Append("    T1.BOX_NUM AS 'Box No', ")
                strQuery.Append("    T1.QTY AS 'Qty/Box', ")
                strQuery.Append("    C.CODE_NAME AS 'Unit', ")
                strQuery.Append("    T2.OROTEX_NO AS 'OROTEX NO', ")
                strQuery.Append("    T2.IMG_PATH1 AS 'Image Path 1', ")
                strQuery.Append("    T2.IMG_PATH2 AS 'Image Path 2', ")
                strQuery.Append("    T2.IMG_PATH3 AS 'Image Path 3', ")
                strQuery.Append("    T2.IMG_PATH4 AS 'Image Path 4', ")
                strQuery.Append("    T2.IMG_PATH5 AS 'Image Path 5', ")
                strQuery.Append("    1 AS 'Qty' ")
                strQuery.Append(" FROM ")
                '<< LanNT - 20160901: Dynamic Unit query
                strQuery.Append("    ITEM_DTL_MS AS T1, ITEM_MASTER_MS AS T2,")
                strQuery.Append("    CODE_MASTER_MS AS C")
                strQuery.Append(" WHERE T1.ITEM_CD = T2.ITEM_CD")
                strQuery.Append("    AND C.CODE_01 = 1")
                strQuery.Append("    AND C.CODE_02 = T2.UNIT")
                strQuery.Append("    AND T1.BC_NO = @P1")
                '>>

                admsManager.SetCommandText(strQuery.ToString())
                admsManager.AddParameterChar("P1", barcodeNo)
                admsManager.AddParameterChar("P2", barcodeNo.Substring(0, 6))
                ds = admsManager.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                WriteErrorLog(ex.Message)
                admsManager.Disconnect()
                admsManager.Dispose()
                Throw New Exception
                ds = Nothing
            Finally
                admsManager.Disconnect()
                admsManager.Dispose()
                admsManager = Nothing
            End Try
        End Function

#End Region

        ''' <summary>
        ''' Xu ly import barcode khi khong co mang wifi.
        ''' </summary>
        ''' <param name="vListBarcode">Duoc lay tu danh sanh.</param>
        ''' <param name="vWarehouseCode">Ung voi check radio o man hinh[W900, W830].</param>
        ''' <returns>Chuoi gom dong loi, thanh cong, tong so dong.</returns>
        ''' <remarks></remarks>
        Public Function ImportWarehouseOffline(ByVal vListBarcode As List(Of String), _
                                               ByVal vWarehouseCode As String, _
                                               ByVal vLoginInfo As String) As String
            Dim totalRows As Integer = vListBarcode.Count ' Tong so dong duoc dung de import.
            Dim successRows As Integer = 0 ' Tong so dong import thanh cong.
            Dim errorRows As Integer = 0 ' Tong so dong import bi loi.
            Dim sbQuery As New StringBuilder()
            Dim cmnConnect As New ABCDWebDBManager(vLoginInfo)
            Try
                cmnConnect.Connect() ' Mo ket noi den DB.

                ' Thuc hien xu ly danh sach barcode.
                For i As Integer = 0 To vListBarcode.Count - 1 Step 1
                    ' Xu ly cat du lieu.
                    Dim arrData As String() = vListBarcode(i).Split(",")

                    ' 1. Check xem barcode trong danh sach da duoc tao hay chua.
                    sbQuery = New StringBuilder()
                    sbQuery.Append(" SELECT ")
                    sbQuery.Append("   COUNT(*) ")
                    sbQuery.Append(" FROM ")
                    sbQuery.Append("   ITEM_DTL_MS AS T ")
                    sbQuery.Append(" WHERE ")
                    sbQuery.Append("   1 = 1 ")
                    sbQuery.Append(" AND ")
                    sbQuery.Append("   BC_NO = @P1 ")
                    cmnConnect.SetCommandText(sbQuery.ToString) ' Thiet lap cau truy van cho cmnConnect.
                    cmnConnect.AddParameterChar("P1", Trim(arrData(1))) ' Xet value cho param P1.
                    Dim existsRow As Integer = cmnConnect.ExecuteScalarInt32()
                    If existsRow = 0 Then ' Truong hop barcode chua duoc tao.
                        errorRows = errorRows + 1 ' Tang so luong dong bi loi.
                        Continue For
                    End If

                    ' 2. Check barcode co dang ton tai o kho:
                    ' 2.1. Neu import W900 thi phai nam o MOLD.
                    ' 2.2. Neu import W830 thi phai nam o W900.
                    sbQuery = New StringBuilder()
                    sbQuery.Append(" SELECT ")
                    sbQuery.Append("   COUNT(*) ")
                    sbQuery.Append(" FROM ")
                    sbQuery.Append("   WH_INFO_TR AS T ")
                    sbQuery.Append(" WHERE ")
                    sbQuery.Append("   1 = 1 ")
                    sbQuery.Append(" AND ")
                    sbQuery.Append("   T.BC_NO = @P1 ")
                    If "W900".Equals(vWarehouseCode) Then ' 2.1
                        sbQuery.Append(" AND ")
                        sbQuery.Append("   T.WH_CD = 'MOLD' ")
                    ElseIf "W830".Equals(vWarehouseCode) Then ' 2.2
                        sbQuery.Append(" AND ")
                        sbQuery.Append("   T.WH_CD = 'W900' ")
                    End If
                    cmnConnect.SetCommandText(sbQuery.ToString)
                    cmnConnect.AddParameterChar("P1", Trim(arrData(1)))
                    Dim existWarehouseRows As Integer = cmnConnect.ExecuteScalarInt32()
                    If existWarehouseRows = 0 Then
                        errorRows = errorRows + 1
                        Continue For
                    End If

                    ' 3. Thuc hien update WH_CD trong WH_INFO_TR.
                    sbQuery = New StringBuilder()
                    sbQuery.Append(" UPDATE ")
                    sbQuery.Append("   WH_INFO_TR ")
                    sbQuery.Append(" SET ")
                    sbQuery.Append("   WH_CD = @P2, ")
                    sbQuery.Append("   UPD_USER_CD = @P3, ")
                    sbQuery.Append("   UPD_DT = GETDATE() ")
                    sbQuery.Append(" WHERE ")
                    sbQuery.Append("   BC_NO = @P1 ")
                    cmnConnect.SetCommandText(sbQuery.ToString)
                    cmnConnect.AddParameterChar("P1", Trim(arrData(1)))
                    cmnConnect.AddParameterChar("P2", vWarehouseCode)
                    cmnConnect.AddParameterChar("P3", vLoginInfo)
                    Dim modifyRows As Integer = cmnConnect.ExecuteNonQuery()
                    If modifyRows <> 0 Then ' Cap nhat thanh cong.
                        successRows = successRows + 1
                    ElseIf modifyRows = 0 Then ' Khong cap nhat thanh cong.
                        errorRows = errorRows + 1
                        Continue For
                    End If

                    ' 4. Thuc hien insert WH_HIST_INFO_TR.
                    sbQuery = New StringBuilder()
                    sbQuery.Append(" INSERT INTO ")
                    sbQuery.Append(" WH_HIST_INFO_TR ")
                    sbQuery.Append(" ( ")
                    sbQuery.Append(" BC_NO, ")
                    sbQuery.Append(" HIST_NO, ")
                    If "W830".Equals(vWarehouseCode) And String.Empty.Equals(arrData(2)) Then ' Phai insert W830 va co chi thi xuat hang.
                        sbQuery.Append(" SHIP_REQ_NO, ")
                    End If
                    sbQuery.Append(" STATUS_FLG, ")
                    sbQuery.Append(" WH_CD, ")
                    If "W830".Equals(vWarehouseCode) And String.Empty.Equals(arrData(4)) Then ' Phai insert W830 va co ke.
                        sbQuery.Append(" RACK_CD, ")
                        sbQuery.Append(" RACK_NM, ")
                    End If
                    sbQuery.Append(" ITEM_CD, ")
                    sbQuery.Append(" ITEM_NM, ")
                    sbQuery.Append(" REG_USER_CD, ")
                    sbQuery.Append(" REG_DT, ")
                    sbQuery.Append(" UPD_USER_CD, ")
                    sbQuery.Append(" UPD_DT ")
                    sbQuery.Append(" ) ")
                    sbQuery.Append(" VALUES ")
                    sbQuery.Append(" ( ")
                    sbQuery.Append(" @P1, ")
                    sbQuery.Append(" (SELECT ")
                    sbQuery.Append("    (MAX(HIST_NO) + 1) ")
                    sbQuery.Append("  FROM ")
                    sbQuery.Append("    WH_HIST_INFO_TR ")
                    sbQuery.Append("  WHERE ")
                    sbQuery.Append("    1 = 1 ")
                    sbQuery.Append("  AND ")
                    sbQuery.Append("    BC_NO = @P1), ")
                    If "W830".Equals(vWarehouseCode) And String.Empty.Equals(arrData(2)) Then
                        sbQuery.Append(" @P2, ")
                    End If
                    sbQuery.Append(" @P3, ")
                    sbQuery.Append(" @P4, ")
                    If "W830".Equals(vWarehouseCode) And String.Empty.Equals(arrData(4)) Then
                        sbQuery.Append(" @P5, ")
                        sbQuery.Append(" (SELECT ")
                        sbQuery.Append("    RACK_NM ")
                        sbQuery.Append("  FROM ")
                        sbQuery.Append("    RACK_MASTER_MS ")
                        sbQuery.Append("  WHERE ")
                        sbQuery.Append("    1 = 1 ")
                        sbQuery.Append("  AND ")
                        sbQuery.Append("    RACK_CD = @P5), ")
                    End If
                    sbQuery.Append(" (SELECT ")
                    sbQuery.Append("    ITEM_CD ")
                    sbQuery.Append("  FROM ")
                    sbQuery.Append("    ITEM_DTL_MS ")
                    sbQuery.Append("  WHERE ")
                    sbQuery.Append("    1 = 1 ")
                    sbQuery.Append("  AND ")
                    sbQuery.Append("    BC_NO = @P1), ")
                    sbQuery.Append(" (SELECT ")
                    sbQuery.Append("    ITEM_NM ")
                    sbQuery.Append("  FROM ")
                    sbQuery.Append("    ITEM_MASTER_MS ")
                    sbQuery.Append("  WHERE ")
                    sbQuery.Append("    1 = 1 ")
                    sbQuery.Append("  AND ")
                    sbQuery.Append("    ITEM_CD = (SELECT ")
                    sbQuery.Append("                 ITEM_CD ")
                    sbQuery.Append("               FROM ")
                    sbQuery.Append("                 ITEM_DTL_MS ")
                    sbQuery.Append("               WHERE ")
                    sbQuery.Append("                 1 = 1 ")
                    sbQuery.Append("               AND ")
                    sbQuery.Append("                 BC_NO = @P1)), ")
                    sbQuery.Append(" @P6, ")
                    sbQuery.Append(" GETDATE(), ")
                    sbQuery.Append(" @P6, ")
                    sbQuery.Append(" GETDATE() ")
                    sbQuery.Append(" ) ")
                    cmnConnect.SetCommandText(sbQuery.ToString)
                    cmnConnect.AddParameterChar("P1", Trim(arrData(1)))
                    If "W830".Equals(vWarehouseCode) And String.Empty.Equals(arrData(2)) Then
                        cmnConnect.AddParameterChar("P2", Trim(arrData(2)))
                    End If
                    cmnConnect.AddParameterChar("P3", Integer.Parse(arrData(3)))
                    cmnConnect.AddParameterChar("P4", Trim(vWarehouseCode))
                    If "W830".Equals(vWarehouseCode) And String.Empty.Equals(arrData(4)) Then
                        cmnConnect.AddParameterChar("P5", Trim(arrData(4)))
                    End If
                    cmnConnect.AddParameterChar("P6", Trim(vLoginInfo))
                    Dim insertRows As Integer = cmnConnect.ExecuteNonQuery()
                    If insertRows <> 0 Then ' Thanh cong.
                        successRows = successRows + 1
                    ElseIf insertRows = 0 Then ' That bai.
                        errorRows = errorRows + 1
                        Continue For
                    End If
                Next
                cmnConnect.Commit()
            Catch ex As Exception
                WriteErrorLog(ex.Message)
                totalRows = -1
                successRows = -1
                errorRows = -1
                cmnConnect.Disconnect()
                cmnConnect.Dispose()
            Finally
                cmnConnect.Disconnect()
                cmnConnect.Dispose()
            End Try
            Return totalRows.ToString & "," & successRows.ToString & "," & errorRows.ToString
        End Function

#Region "OA_BAT004_ReasonProcess"
        ''' <summary>
        ''' Find reason master by reason code
        ''' </summary>
        ''' <param name="reasonCode">Nguoi dung nhap</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReasonByCode(ByVal reasonCode As String) As DataSet
            Dim webDbManager As New ABCDWebDBManager(Me.UserId)
            Dim sqlBuilder As New StringBuilder
            Dim dataSet As DataSet = Nothing
            Try
                webDbManager.Connect() '// Open connect DB
                '// Create content SQL query
                sqlBuilder.Append(" SELECT ")
                sqlBuilder.Append("  REASON_CD, REASON_NM ")
                sqlBuilder.Append(" FROM ")
                sqlBuilder.Append("   REASON_MASTER_MS ")
                sqlBuilder.Append(" WHERE ")
                sqlBuilder.Append("   1 = 1 ")
                sqlBuilder.Append(" AND ")
                sqlBuilder.Append("   REASON_CD = LTRIM(RTRIM(@P1)) ")
                '// Execute SQL query
                webDbManager.SetCommandText(sqlBuilder.ToString)
                webDbManager.AddParameterChar("P1", reasonCode)
                '// Return for dataSet
                dataSet = webDbManager.ExecuteDataSetFill
                Return dataSet
            Catch ex As Exception
                webDbManager.Disconnect()
                webDbManager.Dispose()
                WriteErrorLog(ex.ToString)
                Throw New Exception
            End Try
        End Function

        ''' <summary>
        ''' Insert new reason into REASON_MASTER_MS.
        ''' </summary>
        ''' <param name="reasonCode"></param>
        ''' <param name="reasonName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertReason(ByVal reasonCode As String, _
                                    ByVal reasonName As String, _
                                    ByVal curUser As String) As Integer

            If (reasonCode Is Nothing Or "".Equals(reasonCode.Trim)) Then
                Return -1
            End If

            '' Start write file log.
            '// WriteStartLog()
            '' Declare dataset, abcdwebdbmanager, stringbuilder.
            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()
            Try
                dbm.Connect()
                Dim ret As Integer

                '' Create string query.
                sb.Append("INSERT INTO REASON_MASTER_MS( ")
                sb.Append("REASON_CD, REASON_NM, ")
                sb.Append("REG_USER_CD,")
                sb.Append("REG_DT, UPD_USER_CD, UPD_DT) VALUES(")
                sb.Append("@P1,")
                sb.Append(" @P2,")
                sb.Append("@P3,")
                sb.Append(" GETDATE(), @P4, GETDATE() ")
                sb.Append(")")
                dbm.SetCommandText(sb.ToString())

                '' Set value for param.
                dbm.AddParameter("P1", reasonCode)
                dbm.AddParameter("P2", reasonName)
                dbm.AddParameter("P3", curUser)
                dbm.AddParameter("P4", curUser)

                ret = dbm.ExecuteNonQuery()
                dbm.Commit()
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        ''' <summary>
        ''' Update reason into REASON_MASTER_MS.
        ''' </summary>
        ''' <param name="reasonCode"></param>
        ''' <param name="reasonName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateReason(ByVal reasonCode As String, _
                                    ByVal reasonName As String, _
                                    ByVal curUser As String) As Integer

            If (reasonCode Is Nothing Or "".Equals(reasonCode.Trim)) Then
                Return -1
            End If

            '' Start write file log.
            '// WriteStartLog()
            '' Declare dataset, abcdwebdbmanager, stringbuilder.
            Dim ds As DataSet = Nothing
            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()
            Try
                dbm.Connect()
                Dim ret As Integer

                '' Create string query.
                sb.Append("UPDATE REASON_MASTER_MS ")
                sb.Append("SET REASON_NM = @P1, ")
                sb.Append(" UPD_USER_CD = @P2, UPD_DT = GETDATE() ")
                sb.Append(" WHERE REASON_CD = @P3")
                dbm.SetCommandText(sb.ToString())

                '' Set value for param.
                dbm.AddParameter("P1", reasonName)
                dbm.AddParameter("P2", curUser)
                dbm.AddParameter("P3", reasonCode)
                ret = dbm.ExecuteNonQuery()
                dbm.Commit()
                Return ret
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function

        Public Function DeleteReason(ByVal reasonCode As String, _
                                     ByVal curUser As String) As Integer
            If (reasonCode Is Nothing Or "".Equals(reasonCode.Trim)) Then
                Return -1
            End If
            '' Start write log
            '// WriteStartLog()

            Dim dbm As New ABCDWebDBManager(Me.UserId)
            Dim sb As New StringBuilder()

            Try

                '' Open connect DB
                dbm.Connect()

                '' Return number row add
                Dim rs As Integer = 0

                '' String query
                sb.Append("DELETE FROM REASON_MASTER_MS ")
                sb.Append("WHERE REASON_CD = @P1")

                dbm.SetCommandText(sb.ToString())
                '' Set value parameter
                dbm.AddParameterChar("P1", reasonCode)

                rs = dbm.ExecuteNonQuery()
                '' Commit proccess
                dbm.Commit()
                Return rs
            Catch ex As Exception
                '' Rollback proccess
                dbm.Rollback()
                '' Write error log
                WriteErrorLog(ex)
                Throw ex
            Finally
                '' Disconnect DB
                dbm.Disconnect()
                dbm.Dispose()
                '' Finish write log
                '// WriteEndLog()
            End Try
        End Function


        Public Function ReasonInquiry(ByVal reasonCode As String, _
                                  ByVal reasonName As String, _
                                 ByVal curUser As String) As DataSet
            '// WriteStartLog()
            Dim dbm As ABCDWebDBManager = New ABCDWebDBManager(Me.UserId)
            Dim sqlBuf As New StringBuilder()
            Dim ds As DataSet = Nothing
            Try
                dbm.Connect()

                Dim ret As Integer = 0

                sqlBuf.Append("SELECT * ")
                sqlBuf.Append("FROM   REASON_MASTER_MS ")
                sqlBuf.Append("WHERE  1=1 ")
                If reasonCode.Equals("") = False Then
                    sqlBuf.Append(" AND REASON_CD LIKE @P1 ")
                End If
                If reasonName.Equals("") = False Then
                    sqlBuf.Append(" AND REASON_NM LIKE @P2 ")
                End If

                dbm.SetCommandText(sqlBuf.ToString)
                dbm.AddParameterChar("P1", ("%" & reasonCode & "%"))
                dbm.AddParameterChar("P2", ("%" & reasonName & "%"))

                ds = dbm.ExecuteDataSetFill()
                Return ds
            Catch ex As Exception
                dbm.Rollback()
                WriteErrorLog(ex)
                Throw ex
            Finally
                dbm.Disconnect()
                dbm.Dispose()
                '// WriteEndLog()
            End Try
        End Function
#End Region

    End Class

End Namespace