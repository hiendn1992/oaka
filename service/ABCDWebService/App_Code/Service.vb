Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports jp.co.ait.WebService
Imports System.Collections.Generic
Imports System.Data

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
    Inherits System.Web.Services.WebService

    Private Const DEFUALT_USERID As String = "-----"

    ''' <summary>
    ''' ﾛｸﾞｲﾝ擾ｿｽ・ｽ・ｽﾞｰ・ｽ・ｽ・ｽ・ｽ
    ''' </summary>
    ''' <param name="userID">ﾕｰ・ｽ・ｽID</param>
    ''' <returns>・ｽﾞｰ・ｽ・ｽ・ｽ・ｽ</returns>
    <WebMethod()> Public Function GetEventsLoginDataSet(ByVal userID As String) As DataSet
        Dim oEvents As New ActiveEvents(userID)
        Return Nothing 'oEvents.GetLoginDataSet(userID)
    End Function

    ''' <summary>
    ''' GetDataInUserMasterMS
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetDataInUserMasterMS(ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.GetDataInUserMasterMS(userId)
    End Function

    ''' <summary>
    ''' Login user
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="passWord"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetUserInfoProccess(ByVal userId As String, _
                                        ByVal passWord As String) As Integer
        Dim activeEvents As New ActiveEvents(userId)
        Return activeEvents.GetUserInfoProccess(userId, passWord)
    End Function

    ''' <summary> 
    ''' </summary>
    ''' <param name="userid"></param>
    ''' <param name="password"></param>
    ''' <param name="username"></param>
    ''' <param name="authority"></param>
    ''' <param name="remark"></param>
    ''' <param name="loginid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function InsertUserInfo(ByVal userid As String, _
                                       ByVal password As String, _
                                       ByVal username As String, _
                                       ByVal authority As Integer, _
                                       ByVal remark As String, _
                                       ByVal loginid As String) As Integer
        Dim oEvent As New ActiveEvents(loginid)
        Return oEvent.InsertUserInfo(userid, password, username, authority, remark, loginid)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="userid"></param>
    ''' <param name="password"></param>
    ''' <param name="username"></param>
    ''' <param name="authority"></param>
    ''' <param name="remark"></param>
    ''' <param name="loginid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function UpdateUserInfo(ByVal userid As String, _
                                       ByVal password As String, _
                                       ByVal username As String, _
                                       ByVal authority As Integer, _
                                       ByVal remark As String, _
                                       ByVal loginid As String) As Integer
        Dim oEvent As New ActiveEvents(userid)
        Return oEvent.UpdateUserInfo(userid, password, username, authority, remark, loginid)
    End Function

    ''' <summary>
    ''' Delete data table: update value DEL_FLG = '1'
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function DeleteUserInfo(ByVal userId As String, _
                                   ByVal loginId As String) As Integer
        '' Declare active event
        Dim ae As New ActiveEvents(loginId)
        '' Return value proccess
        Return ae.DeleteUserInfo(userId, loginId)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_userId"></param>
    ''' <param name="_remark"></param>
    ''' <param name="_authority"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function UserInquiry(ByVal _userId As String, _
                                        ByVal _remark As String, _
                                        ByVal _authority As Integer, _
                                        ByVal loginCode As String) As DataSet
        Dim oEvent As New ActiveEvents(loginCode)
        Return oEvent.UserInquiry(_userId, _remark, _authority)
    End Function

    ''' <summary>
    ''' GetWarehouseStatusTr
    ''' Created 2015/01/13 toannn
    ''' </summary>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetWarehouseStatusTr(ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetWarehouseStatusTr()
    End Function

#Region "BAT001_UserProcess"

    <WebMethod()> _
    Public Function ChangeUserPassword(ByVal userid As String, _
                                       ByVal password As String) As Integer
        Dim activeEvents As New ActiveEvents(userid)
        Return activeEvents.ChangeUserPassword(userid, password)
    End Function

    <WebMethod()> _
    Public Function GetUserInfoByID(ByVal userCode As String, _
                                    ByVal loginCode As String) As DataSet
        '' Declare activeevents.
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.GetUserInfoByID(userCode)
    End Function

#End Region

#Region "Batch 002 Product Process."
    <WebMethod()> _
    Public Function GetWOInfoByWONo(ByVal woCode As String, _
                                    ByVal loginCode As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetWOInfoByWONo(woCode)
    End Function

    ''' <summary>
    ''' Get list w/o join table item master.
    ''' </summary>
    ''' <param name="woCode"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetWOInfoByWONoJoinItem(ByVal woCode As String, ByVal loginId As String) As DataSet
        Dim ae As New ActiveEvents(loginId)
        Return ae.GetWOInfoByWONoJoinItem(woCode)
    End Function

    <WebMethod()> _
    Public Function InsertWOInfo(ByVal woNoList As List(Of String), ByVal woDateList As List(Of String), _
                                 ByVal itemCdList As List(Of String), ByVal proQtyList As List(Of String), _
                                 ByVal qtyPerBoxList As List(Of String), ByVal totalBoxList As List(Of String), _
                                 ByVal loginId As String) As Integer
        Dim activeEvent As New ActiveEvents(loginId)
        Return activeEvent.InsertWOInfo(woNoList, woDateList, itemCdList, proQtyList, qtyPerBoxList, totalBoxList, loginId)
    End Function

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
    <WebMethod()> _
    Public Function GetWOInfoList(ByVal itemCode As String, _
                                        ByVal woNo As String, _
                                        ByVal woDateFrom As Date, _
                                        ByVal woDateTo As Date, _
                                        ByVal productQuantity As Integer, _
                                        ByVal totalBox As Integer, _
                                        ByVal issueFlag As Integer, _
                                        ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetWOInfoList(itemCode, woNo, woDateFrom, woDateTo, productQuantity, totalBox, issueFlag)
    End Function

    <WebMethod()> _
    Public Function UpdateWOInfo(ByVal woCode As String, _
                                 ByVal woDate As Date, _
                                 ByVal itemCode As String, _
                                 ByVal prodQty As Integer, _
                                 ByVal qtyPerBox As Integer, _
                                 ByVal totalBox As Integer, _
                                 ByVal loginCode As String) As Integer
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.UpdateWOInfo(woCode, _
                                        woDate, _
                                        itemCode, _
                                        prodQty, _
                                        qtyPerBox, _
                                        totalBox, _
                                        loginCode)
    End Function

    <WebMethod()> _
    Public Function DeleteWOInfo(ByVal woCode As String, _
                                 ByVal loginCode As String) As Integer
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.DeleteWOInfo(woCode)
    End Function

    <WebMethod()> _
    Public Function UpdateIssueFlag(ByVal woNo As String, _
                                                                           ByVal issueFlag As Integer, _
                                                                           ByVal loginId As String) As Integer
        Dim activeEvent As New ActiveEvents(loginId)
        Return activeEvent.UpdateIssueFlag(woNo, issueFlag)
    End Function

    <WebMethod()> _
    Public Function UpdateIssueFlagToString(ByVal woNo As String, _
                                                                           ByVal issueFlag As Integer, _
                                                                           ByVal loginId As String) As String
        Dim activeEvent As New ActiveEvents(loginId)
        Return activeEvent.UpdateIssueFlagToString(woNo, issueFlag)
    End Function
#End Region

#Region "BAT003_SetRackFGProcess"

    ''' <summary>
    ''' ChkRackNoExistProcess
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkRackNoExistProcess(ByVal barcodeNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkRackNoExistProcess(barcodeNo)
    End Function

    ''' <summary>
    ''' ChkBarcodeExistSelectedRack
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkBarcodeExistSelectedRack(ByVal barcodeNo As String, ByVal userId As String, ByVal rackNo As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkBarcodeExistSelectedRack(barcodeNo, rackNo)
    End Function

    ''' <summary>
    ''' SetRackToW830
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function SetRackToW830(ByVal barcodeNo As String, ByVal userId As String, ByVal itemCode As String, ByVal rackNo As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.SetRackToW830(barcodeNo, itemCode, rackNo)
    End Function

#End Region

#Region "BAT004_ImportQCProcess"

    ''' <summary>
    ''' CheckBarcodeExistProcess
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckBarcodeExistProcess(ByVal barcodeNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.CheckBarcodeExistProcess(barcodeNo)
    End Function

    ''' <summary>
    ''' ImportBarcodeIntoQC
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ImportBarcodeIntoQC(ByVal barcodeNo As String, ByVal userId As String, ByVal itemCode As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ImportBarcodeIntoQC(barcodeNo, itemCode)
    End Function

#End Region

#Region "BAT005_StockMoveFGProcess"

    ''' <summary>
    ''' CheckBarcodeExistProcess
    ''' </summary>
    ''' <param name="rackNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStkMvRackNoExistProcess(ByVal rackNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkStkMvRackNoExistProcess(rackNo)
    End Function

    ''' <summary>
    ''' ChkStkMvBarcodeExistDestRackNo
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="rackNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStkMvBarcodeExistDestRackNo(ByVal barcodeNo As String, ByVal rackNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkStkMvBarcodeExistDestRackNo(barcodeNo, rackNo)
    End Function

    ''' <summary>
    ''' StockMoveW830
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function StockMoveW830(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackNo As String, ByVal userId As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.StockMoveW830(barcodeNo, itemCode, rackNo)
    End Function

#End Region

#Region "BAT006_RejectQCProcess"
    ''' <summary>
    ''' CheckRejectBarcodeExistProcess
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckRejectBarcodeExistProcess(ByVal barcodeNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.CheckRejectBarcodeExistProcess(barcodeNo)
    End Function

    ''' <summary>
    ''' RejectBarcodeIntoW9902
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function RejectBarcodeIntoW9902(ByVal barcodeNo As String, ByVal userId As String, ByVal itemCode As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.RejectBarcodeIntoW9902(barcodeNo, itemCode)
    End Function
#End Region

#Region "BAT007_RetrieveQCProcess"
    ''' <summary>
    ''' CheckRetrieveRackCDExistProcess
    ''' </summary>
    ''' <param name="rackCD"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckRetrieveRackCDExistProcess(ByVal rackCD As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.CheckRetrieveRackCDExistProcess(rackCD)
    End Function

    ''' <summary>
    ''' CheckRetrieveBarcodeExistSelectedRack
    ''' </summary>
    ''' <param name="rackCD"></param>
    ''' <param name="barcodeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckRetrieveBarcodeExistSelectedRack(ByVal barcodeNo As String, ByVal rackCD As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.CheckRetrieveBarcodeExistSelectedRack(barcodeNo, rackCD)
    End Function

    ''' <summary>
    ''' RetrieveBarcodeIntoQC
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function RetrieveBarcodeIntoQC(ByVal barcodeNo As String, ByVal userId As String, ByVal itemCode As String, ByVal rackCD As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.RetrieveBarcodeIntoQC(barcodeNo, itemCode, rackCD)
    End Function
#End Region

#Region "BAT008_StocktakingQCProcess"
    ''' <summary>
    ''' ChkStocktkReqDateExist
    ''' </summary>
    ''' <param name="stockReqDate"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStocktkReqDateExist(ByVal stockReqDate As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkStocktkReqDateExist(stockReqDate)
    End Function

    ''' <summary>
    ''' ChkStocktkBarcodeExistSelectedReqDate
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStocktkBarcodeExistSelectedReqDate(ByVal barcodeNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkStocktkBarcodeExistSelectedReqDate(barcodeNo)
    End Function

    ''' <summary>
    ''' StocktakingBarcodeQC
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function StocktakingBarcodeQC(ByVal barcodeNo As String, ByVal userId As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.StocktakingBarcodeQC(barcodeNo)
    End Function

#End Region

#Region "BATCH 009 W900 (QC WH)"

    ''' <summary>
    ''' CheckBarcodeImportFGExistProcess
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckBarcodeImportFGExistProcess(ByVal barcodeNo As String, _
                                                     ByVal caseImp As String, _
                                                     ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.CheckBarcodeImportFGExistProcess(barcodeNo, caseImp)
    End Function

    ''' <summary>
    ''' ImportFGBarcodeIntoQC
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ImportFGBarcodeIntoQC(ByVal barcodeNo As String, _
                                          ByVal caseImp As String, _
                                          ByVal userId As String, ByVal itemCode As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ImportFGBarcodeIntoQC(barcodeNo, caseImp, itemCode)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="paramBarcode"></param>
    ''' <param name="paramUserId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ShipmentReturn(ByVal paramBarcode As String, _
                                   ByVal paramUserId As String) As Boolean
        Dim actEvent As New ActiveEvents(paramUserId)
        Return actEvent.ShipmentReturn(paramBarcode)
    End Function
#End Region

#Region "BAT010_RejectFGProcess"

    ''' <summary>
    ''' ChkRejFGBarcodeExistW830
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkRejFGBarcodeExistW830(ByVal barcodeNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkRejFGBarcodeExistW830(barcodeNo)
    End Function

    ''' <summary>
    ''' RejectFGBarcodeIntoW9902
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <param name="itemCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function RejectFGBarcodeIntoW9902(ByVal barcodeNo As String, ByVal userId As String, ByVal itemCode As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.RejectFGBarcodeIntoW9902(barcodeNo, itemCode)
    End Function
#End Region

#Region "BAT011_ShipFGProcess"

    ''' <summary>
    ''' ChkShipReqNoExist
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkShipReqNoExist(ByVal shipNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkShipReqNoExist(shipNo)
    End Function

    ''' <summary>
    ''' ChkPalletNoExistShipReqNo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkPalletNoExistShipReqNo(ByVal shipNo As String, ByVal palletNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkPalletNoExistShipReqNo(shipNo, palletNo)
    End Function


    ''' <summary>
    ''' CheckBarcodeExistShipReqNo
    ''' </summary>
    ''' <param name="palletNo"></param>
    ''' <param name="shipNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckBarcodeExistShipReqNo(ByVal barcodeNo As String, ByVal shipNo As String, ByVal palletNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.CheckBarcodeExistShipReqNo(barcodeNo, shipNo, palletNo)
    End Function

    ''' <summary>
    ''' ShipmentBarcode
    ''' </summary>
    ''' <param name="palletNo"></param>
    ''' <param name="shipNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ShipmentBarcode(ByVal barcodeNo As String, ByVal shipNo As String, ByVal palletNo As String, ByVal userId As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ShipmentBarcode(barcodeNo, shipNo, palletNo)
    End Function




#End Region

#Region "BAT012 Rack Process"
    <WebMethod()> _
    Public Function GetRackInfoByCd(ByVal _rackCd As String, _
                                    ByVal _mode As Integer) As DataSet
        '' Declare activeevents.
        Dim activeEvents As New ActiveEvents(_rackCd)
        Return activeEvents.GetRackInfoByCd(_rackCd, _mode)
    End Function

    <WebMethod()> _
    Public Function InsertRackInfo(ByVal rackCd As String, _
                                                                            ByVal rackName As String, _
                                                                            ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertRackInfo(rackCd, rackName, loginId)
    End Function

    <WebMethod()> _
    Public Function UpdateRackInfo(ByVal rackCd As String, _
                                       ByVal rackName As String, _
                                       ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.UpdateRackInfo(rackCd, rackName, loginId)
    End Function

    <WebMethod()> _
    Public Function DeleteRackInfo(ByVal rackCd As String, _
                                       ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.DeleteRackInfo(rackCd)
    End Function
    ''' <summary>
    ''' RackInuqiry
    ''' </summary>
    ''' <param name="_rackCd"></param>
    ''' <param name="_rackName"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function RackInquiry(ByVal _rackCd As String, _
                                        ByVal _rackName As String, _
                                        ByVal loginId As String) As DataSet
        Dim oEvent As New ActiveEvents(loginId)
        Return oEvent.RackInquiry(_rackCd, _rackName)
    End Function
    ''' <summary>
    ''' Check if rack is empty.
    ''' </summary>
    ''' <param name="_rackCd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckRackIsEmpty(ByVal _rackCd As String, _
                                     ByVal loginId As String) As Integer
        Dim oEvent As New ActiveEvents(loginId)
        Return oEvent.CheckRackIsEmpty(_rackCd)
    End Function
#End Region

#Region "BAT013 Customer Process"
    <WebMethod()> _
    Public Function GetNextCusId(ByVal LoginId As String) As String
        Dim activeEvents As New ActiveEvents(LoginId)
        Return activeEvents.GetNextCusId()
    End Function

    <WebMethod()> _
    Public Function InsertCustomerInfo(ByVal cusId As String, _
                                       ByVal cusNm As String, _
                                       ByVal dest As Integer, _
                                       ByVal address As String, _
                                       ByVal telNo As String, _
                                       ByVal faxNo As String, _
                                       ByVal mail As String, _
                                       ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertCustomerInfo(cusId, cusNm, dest, address, telNo, faxNo, mail, loginId)
    End Function

    <WebMethod()> _
    Public Function GetCustomerInfoByID(ByVal cusId As String, _
                                        ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetCustomerInfoByID(cusId)
    End Function

    <WebMethod()> _
    Public Function UpdateCustomerInfo(ByVal cusId As String, _
                                       ByVal cusName As String, _
                                       ByVal address As String, _
                                       ByVal dest As Integer, _
                                       ByVal email As String, _
                                       ByVal faxNo As String, _
                                       ByVal telNo As String, _
                                       ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.UpdateCustomerInfo(cusId, cusName, address, dest, email, faxNo, telNo, loginId)
    End Function

    <WebMethod()> _
    Public Function DeleteCustomerInfo(ByVal cusId As String, _
                                       ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.DeleteCustomerInfo(cusId)
    End Function

    <WebMethod()> _
    Public Function CustomerInquiry(ByVal cusId As String, _
                                    ByVal cusName As String, _
                                    ByVal telNo As String, _
                                    ByVal address As String, _
                                    ByVal email As String, _
                                    ByVal dest As Integer, _
                                    ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.CustomerInquiry(cusId, cusName, telNo, address, email, dest)
    End Function

#End Region

#Region "BAT012_StocktakingFGProcess"

    ''' <summary>
    ''' ChkStocktFGkReqDateExist
    ''' </summary>
    ''' <param name="stkReqDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStocktFGkReqDateExist(ByVal stkReqDate As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkStocktFGkReqDateExist(stkReqDate)
    End Function

    ''' <summary>
    ''' ChkStockFGRackNoExistProcess
    ''' </summary>
    ''' <param name="rackNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStockFGRackNoExistProcess(ByVal rackNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkStockFGRackNoExistProcess(rackNo)
    End Function


    ''' <summary>
    ''' ChkStockFGValidBarcode
    ''' </summary>
    ''' <param name="barcode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStockFGValidBarcode(ByVal barcode As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ChkStockFGValidBarcode(barcode)
    End Function

    ''' <summary>
    ''' StocktakingBarcodeFG
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="rackNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function StocktakingBarcodeFG(ByVal barcodeNo As String, ByVal userId As String, ByVal rackNo As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.StocktakingBarcodeFG(barcodeNo, rackNo)
    End Function

#End Region

#Region "BATCH 014 Item Process"
    <WebMethod()> _
    Public Function GetItemInfoByCd(ByVal itemCode As String, _
                                    ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetItemInfoByCd(itemCode)
    End Function

    <WebMethod()> _
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
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertItemInfo(itemCode, itemName, quantity, unit, temp, orotexNo, path01, _
                                           path02, path03, path04, path05, customerList, loginId)
    End Function

    <WebMethod()> _
    Public Function UpdateItemInfo(ByVal itemCode As String, _
                                   ByVal itemName As String, _
                                   ByVal quantity As String, _
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
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.UpdateItemInfo(itemCode, itemName, quantity, unit, temp, orotexNo, path01, path02, path03, path04, path05, customerList, loginCode)
    End Function

    <WebMethod()> _
    Public Function DeleteItemInfo(ByVal itemCode As String, _
                                   ByVal loginCode As String) As Integer
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.DeleteItemInfo(itemCode)
    End Function

    <WebMethod()> _
    Public Function ItemInquiry(ByVal itemCodeFrom As String, _
                                ByVal itemCodeTo As String, _
                                ByVal itemName As String, _
                                ByVal customerCode As String, _
                                ByVal customerName As String, _
                                ByVal quantity As Integer, _
                                ByVal loginCode As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.ItemInquiry(itemCodeFrom, itemCodeTo, itemName, customerCode, customerName, quantity)
    End Function

    ''' <summary>
    ''' Get product info by item code.
    ''' </summary>
    ''' <param name="itemCode"></param>
    ''' <param name="loginCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetProductInfoByItemCode(ByVal itemCode As String, ByVal loginCode As String) As DataSet
        Dim actEvent As New ActiveEvents(loginCode)
        Return actEvent.GetProductInfoTrByItemCode(itemCode)
    End Function

    <WebMethod()> _
    Public Function GetItemCustomerInfoByCd(ByVal itemCode As String, _
                                            ByVal loginCode As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.GetItemCustomerInfoByCd(itemCode)
    End Function
    <WebMethod()> _
    Public Function GetItemDetailInfoByBCFromTo(ByVal barcodeFrom As String, _
                                                                                                ByVal barcodeTo As String, _
                                                                                                ByVal loginCode As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.GetItemDetailInfoByBCFromTo(barcodeFrom, barcodeTo)
    End Function
    <WebMethod()> _
    Public Function GetCurrentBoxNumber(ByVal itemCode As String, ByVal userId As String) As String
        Dim activeEvents As New ActiveEvents(userId)
        Return activeEvents.GetCurrentBoxNumber(itemCode)
    End Function
    <WebMethod()> _
Public Function UpdateCurrentBoxNumber(ByVal itemCode As String, _
                                                                                    ByVal curBoxNum As String, _
                                                                                    ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.UpdateCurrentBoxNumber(itemCode, curBoxNum)
    End Function
    <WebMethod()> _
Public Function UpdateCurrentBoxNumberToString(ByVal itemCode As String, _
                                                                                ByVal curBoxNum As String, _
                                                                                ByVal loginId As String) As String
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.UpdateCurrentBoxNumberToString(itemCode, curBoxNum)
    End Function
#End Region

#Region "BATCH 017 Warehouse Hist Tr Process"

    ''' <summary>
    ''' Get GetWarehouseHistTr info
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="warehouseCd"></param>
    ''' <param name="itemCd"></param>
    ''' <param name="stockDateFrom">stockDateFrom = Date.MinValue : Ignore condition</param>
    ''' <param name="stockDateTo">stockDateTo = Date.MinValue : Ignore condition</param>
    ''' <param name="statusFlg">statusFlg = -1 : Ignore condition</param>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetWarehouseHistTr(ByVal barcodeNo As String, _
                                        ByVal warehouseCd As String, _
                                        ByVal itemCd As String, _
                                        ByVal stockDateFrom As String, _
                                        ByVal stockDateTo As String, _
                                        ByVal statusFlg As Integer, _
                                        ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetWarehouseHistTr(barcodeNo, warehouseCd, itemCd, stockDateFrom, stockDateTo, statusFlg)
    End Function

    <WebMethod()> _
    Public Function InsertWarehouseHistTrInfo(ByVal barcodeNo As String, _
                                        ByVal warehouseCd As String, _
                                        ByVal itemCd As String, _
                                        ByVal statusFlg As Integer, _
                                        ByVal rackCd As String, _
                                        ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertWarehouseHistTrInfo(barcodeNo, warehouseCd, itemCd, statusFlg, rackCd)
    End Function

    <WebMethod()> _
    Public Function InsertWarehouseHistTrInfoToString(ByVal barcodeNo As String, _
                                        ByVal warehouseCd As String, _
                                        ByVal itemCd As String, _
                                        ByVal statusFlg As Integer, _
                                        ByVal rackCd As String, _
                                        ByVal loginId As String) As String
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertWarehouseHistTrInfoToString(barcodeNo, warehouseCd, itemCd, statusFlg, rackCd)
    End Function

#End Region

#Region "BATCH 018 Shipment Req Detail Process"

    ''' <summary>
    ''' Func Name: GetShipmentReqDetailByCd
    ''' </summary>
    ''' <param name="shipmentReqNo"></param>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetShipmentReqDetailByCd(ByVal shipmentReqNo As String, _
                                    ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetShipmentReqDetailByCd(shipmentReqNo)
    End Function

    ''' <summary>
    ''' Delete data table: SHIP_REQ_DTL_INFO_TR
    ''' </summary>
    ''' <param name="shipReqNo"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function DeleteShipmentReqDtlInfoTrByCd(ByVal shipReqNo As String, _
                                   ByVal loginId As String) As Integer
        '' Declare active event
        Dim ae As New ActiveEvents(loginId)
        '' Return value proccess
        Return ae.DeleteShipmentReqDtlInfoTrByCd(shipReqNo)
    End Function

    ''' <summary>
    ''' Insert SHIP_REQ_DTL_INFO_TR data
    ''' </summary>
    ''' <param name="shipReqNo"></param>
    ''' <param name="barcodeNo"></param>
    ''' <param name="palletNo"></param>
    ''' <param name="scanFlag"></param>
    ''' <param name="loginCode"></param>
    ''' <returns>Rows inserted</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function InsertShipmentReqDtlInfoTr(ByVal shipReqNo As String, _
                                     ByVal barcodeNo As String, _
                                     ByVal palletNo As String, _
                                     ByVal scanFlag As Integer, _
                                     ByVal loginCode As String) As String
        '' Declare active event
        Dim ae As New ActiveEvents(loginCode)
        '' Return value proccess
        Return ae.InsertShipmentReqDtlInfoTr(shipReqNo, barcodeNo, palletNo, scanFlag)
    End Function

#End Region

#Region "BATCH 019 Shipment Act Detail Process"

    ''' <summary>
    ''' Func Name: GetShipmentActDetailByCd
    ''' </summary>
    ''' <param name="shipmentReqNo"></param>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetShipmentActDetailByCd(ByVal shipmentReqNo As String, _
                                    ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetShipmentActDetailByCd(shipmentReqNo)
    End Function

    <WebMethod()> _
    Public Function GetAvaiableBarcodeByItemCd(ByVal itemCode As String, ByVal loginCode As String,ByVal barcode As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetAvaiableBarcodeByItemCd(itemCode,barcode)
    End Function

    <WebMethod()> _
    Public Function InsertShipmentActDtlInfoTr(ByVal shipReqNo As String, _
                                        ByVal barcodeNo As String, _
                                        ByVal palletNo As String, _
                                        ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertShipmentActDtlInfoTr(shipReqNo, barcodeNo, palletNo)
    End Function

#End Region

#Region "BAT020_StockDeleteFGProcess"
    ''' <summary>
    ''' Func Name: ChkStkDelBarcodeExist
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ChkStkDelBarcodeExist(ByVal barcodeNo As String, _
                                          ByVal whCd As String, _
                                    ByVal userId As String) As DataSet
        Dim activeEvents As New ActiveEvents(userId)
        Return activeEvents.ChkStkDelBarcodeExist(barcodeNo, whCd)
    End Function
    <WebMethod()> _
   Public Function StockDeleteW900(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackNo As String, ByVal userId As String) As Boolean
        Dim activeEvent As New ActiveEvents(userId)
        Return activeEvent.StockDeleteW900(barcodeNo, itemCode, rackNo)
    End Function

    ''' <summary>
    ''' Func Name: StockDeleteW830
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="itemCode"></param>
    ''' <param name="rackNo"></param>
    ''' <param name="userId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function StockDeleteW830(ByVal barcodeNo As String, ByVal itemCode As String, ByVal rackNo As String, ByVal userId As String) As Boolean
        Dim activeEvent As New ActiveEvents(userId)
        Return activeEvent.StockDeleteW830(barcodeNo, itemCode, rackNo)
    End Function

#End Region

#Region "BATCH 022 Warehouse Process"

    ''' <summary>
    ''' Get WH_MASTER_MS by warehouseCode
    ''' </summary>
    ''' <param name="whCode"></param>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetWarehouseInfoByCd(ByVal whCode As String, _
                                    ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetWarehouseInfoByCd(whCode)
    End Function

#End Region

#Region "BATCH 023 Item Detail Process"
    ''' <summary>
    ''' Sub Name: InsertItemDtlInfo
    ''' </summary>
    ''' <param name="itemCode"></param>
    ''' <param name=" barcodeNo"></param>
    ''' <param name=" boxNumber"></param>
    ''' <param name=" lotNo"></param>
    ''' <param name=" woNo"></param>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function InsertItemDtlInfo(ByVal itemCode As String, _
                                                            ByVal boxNumber As String, _
                                                            ByVal barcodeNo As String, _
                                                            ByVal qty As String, _
                                                            ByVal lotNo As String, _
                                                            ByVal woNo As String, _
                                                            ByVal woDate As String, _
                                                            ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertItemDtlInfo(itemCode, boxNumber, barcodeNo, qty, lotNo, woNo, woDate, loginId)
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
    <WebMethod()> _
    Public Function InsertItemDtlInfoToString(ByVal itemCode As String, _
                                                            ByVal boxNumber As String, _
                                                            ByVal barcodeNo As String, _
                                                            ByVal qty As String, _
                                                            ByVal lotNo As String, _
                                                            ByVal woNo As String, _
                                                            ByVal woDate As String, _
                                                            ByVal loginId As String) As String
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertItemDtlInfoToString(itemCode, boxNumber, barcodeNo, qty, lotNo, woNo, woDate, loginId)
    End Function
    <WebMethod()> _
    Public Function GetNewBoxList(ByVal exportedWoNoCount As Integer, _
                                  ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetNewBoxList(exportedWoNoCount)
    End Function
#End Region

#Region "BATCH 024 Shipment Process"

    ''' <summary>
    ''' Func Name: GetShipmentInfoByShipmentReqNo by shipmentReqNo
    ''' </summary>
    ''' <param name="shipmentReqNo">shipmentReqNo = Empty: Ignore condition</param>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetShipmentInfoByShipmentReqNo(ByVal shipmentReqNo As String, _
                                                   ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetShipmentInfoByShipmentReqNo(shipmentReqNo, _
                                                           String.Empty, _
                                                           Date.MinValue, _
                                                           Date.MinValue)
    End Function

    ''' <summary>
    ''' Search ShipmentInfo by customerId and shipmentDate
    ''' </summary>
    ''' <param name="customerId">customerId = Empty: Ignore condition</param>
    ''' <param name="shipmentDateFrom">shipmentDateFrom = Date.MinValue : Ignore condition</param>
    ''' <param name="shipmentDateTo">shipmentDateTo = Date.MinValue : Ignore condition</param>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetShipmentInfo(ByVal customerId As String, _
                                                   ByVal shipmentDateFrom As Date, _
                                                   ByVal shipmentDateTo As Date, _
                                                   ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetShipmentInfoByShipmentReqNo(String.Empty, _
                                                           customerId, _
                                                           shipmentDateFrom, _
                                                           shipmentDateTo)
    End Function

    ''' <summary>
    ''' Delete data table: SHIP_REQ_INFO_TR, SHIP_REQ_DTL_INFO_TR
    ''' </summary>
    ''' <param name="shipReqNo"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function DeleteShipmentReqInfoTrByCd(ByVal shipReqNo As String, _
                                   ByVal loginId As String) As Integer
        '' Declare active event
        Dim ae As New ActiveEvents(loginId)
        '' Return value proccess
        Return ae.DeleteShipmentReqInfoTrByCd(shipReqNo)
    End Function

    ''' <summary>
    ''' Insert SHIP_REQ_INFO_TR data
    ''' </summary>
    ''' <param name="shipReqDate"></param>
    ''' <param name="shipDate"></param>
    ''' <param name="cusID"></param>
    ''' <param name="cusPo"></param>
    ''' <param name="invoiceNo"></param>
    ''' <param name="invoiceDate"></param>
    ''' <param name="loginCode"></param>
    ''' <returns>Inserted shipReqNo</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function InsertShipReqInfoTr(ByVal shipReqDate As Date, _
                                     ByVal shipDate As Date, _
                                     ByVal cusID As String, _
                                     ByVal cusPo As String, _
                                     ByVal invoiceNo As String, _
                                     ByVal invoiceDate As Date, _
                                     ByVal loginCode As String) As String
        '' Declare active event
        Dim ae As New ActiveEvents(loginCode)
        '' Return value proccess
        Return ae.InsertShipReqInfoTr(shipReqDate, shipDate, cusID, cusPo, invoiceNo, invoiceDate)
    End Function

    ''' <summary>
    ''' Insert SHIP_REQ_INFO_TR data
    ''' </summary>
    ''' <param name="shipReqDate"></param>
    ''' <param name="shipDate"></param>
    ''' <param name="cusID"></param>
    ''' <param name="cusPo"></param>
    ''' <param name="invoiceNo"></param>
    ''' <param name="invoiceDate"></param>
    ''' <param name="loginCode"></param>
    ''' <param name="detailDt">table detail have columns {BC_NO, PALLET_NO, SCAN_FLG}</param>
    ''' <returns>Inserted shipReqNo</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function InsertShipReqInfoTrWithDetail(ByVal shipReqDate As Date, _
                                     ByVal shipDate As Date, _
                                     ByVal cusID As String, _
                                     ByVal cusPo As String, _
                                     ByVal invoiceNo As String, _
                                     ByVal invoiceDate As Date, _
                                     ByVal detailDt As DataTable, _
                                     ByVal loginCode As String) As String
        '' Declare active event
        Dim ae As New ActiveEvents(loginCode)
        '' Return value proccess
        If detailDt Is Nothing OrElse detailDt.Rows.Count = 0 Then
            Return ae.InsertShipReqInfoTr(shipReqDate, shipDate, cusID, cusPo, invoiceNo, invoiceDate)
        Else
            Return ae.InsertShipReqInfoTrWithDetail(shipReqDate, shipDate, cusID, cusPo, invoiceNo, invoiceDate, detailDt)
        End If
    End Function

    <WebMethod()> _
    Public Function UpdateShipReqInfoTr(ByVal shipReqNo As String, _
                                     ByVal shipReqDate As Date, _
                                     ByVal shipDate As Date, _
                                     ByVal cusID As String, _
                                     ByVal cusPo As String, _
                                     ByVal invoiceNo As String, _
                                     ByVal invoiceDate As Date, _
                                     ByVal loginCode As String) As Integer
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.UpdateShipReqInfoTr(shipReqNo, shipReqDate, shipDate, cusID, cusPo, invoiceNo, invoiceDate)
    End Function

    ''' <summary>
    ''' UpdateShipReqInfoTrWithDetail
    ''' </summary>
    ''' <param name="shipReqNo"></param>
    ''' <param name="shipReqDate"></param>
    ''' <param name="shipDate"></param>
    ''' <param name="cusID"></param>
    ''' <param name="cusPo"></param>
    ''' <param name="invoiceNo"></param>
    ''' <param name="invoiceDate"></param>
    ''' <param name="detailDt">table detail have columns {BC_NO, PALLET_NO, SCAN_FLG}</param>
    ''' <param name="loginCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function UpdateShipReqInfoTrWithDetail(ByVal shipmentRequestNo As String, ByVal shipmentRequestDate As Date, ByVal shipmentDate As Date, ByVal customerId As String, ByVal customerPo As String, ByVal invoiceNo As String, ByVal invoiceDate As Date, ByVal listData As List(Of String), ByVal registeredId As String) As Integer
        Dim activeEvents As New ActiveEvents(registeredId)
        Return activeEvents.UpdateShipReqInfoTrWithDetail(shipmentRequestNo, shipmentRequestDate, shipmentDate, customerId, customerPo, invoiceNo, invoiceDate, listData, registeredId)
    End Function

    <WebMethod()> _
    Public Function SetShipReqInfoTrComplete(ByVal shipReqNo As String, _
                                     ByVal loginCode As String) As Integer
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.SetShipReqInfoTrComplete(shipReqNo)
    End Function

    <WebMethod()> _
    Public Function ShipmentInquiry(ByVal shipStatus As String, _
                                                                    ByVal shipReqNo As String, _
                                                                    ByVal shipReqDateFrom As String, _
                                                                    ByVal shipReqDateTo As String, _
                                                                    ByVal shipDateFrom As String, _
                                                                    ByVal shipDateTo As String, _
                                                                    ByVal cusId As String, _
                                                                    ByVal cusPO As String, _
                                                                    ByVal invoiceNo As String, _
                                                                    ByVal invoiceDate As String, _
                                                                    ByVal loginID As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginID)
        Return activeEvents.ShipmentInquiry(shipStatus, _
                                                                                    shipReqNo, _
                                                                                    shipReqDateFrom, _
                                                                                    shipReqDateTo, _
                                                                                    shipDateFrom, _
                                                                                    shipDateTo, _
                                                                                    cusId, _
                                                                                    cusPO, _
                                                                                    invoiceNo, _
                                                                                    invoiceDate)
    End Function

    ''' <summary>
    ''' ExecuteShipment
    ''' </summary>
    ''' <param name="shipmentRequestNo"></param>
    ''' <param name="listData">table detail have columns {BC_NO, WH_CD, ITEM_CD, PALLET_NO}</param>
    ''' <param name="registeredId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ExecuteShipment(ByVal shipmentRequestNo As String, ByVal listData As List(Of String), ByVal registeredId As String) As Integer
        Dim activeEvents As New ActiveEvents(registeredId)
        Return activeEvents.ExecuteShipment(shipmentRequestNo, listData, registeredId)
    End Function

#End Region

#Region "BATCH 023 Item Detail Process"

    ''' <summary>
    ''' UpdateItemDtlInfoShipFlag
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="shipFlg"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function UpdateItemDtlInfoShipFlag(ByVal barcodeNo As String, _
                                              ByVal shipFlg As Integer, _
                                              ByVal loginId As String) As Integer
        '' Declare active event
        Dim ae As New ActiveEvents(loginId)
        '' Return value proccess
        Return ae.UpdateItemDtlInfoShipFlag(barcodeNo, shipFlg)
    End Function

#End Region

#Region "BATCH 025 Warehouse Tr Process"

    ''' <summary>
    ''' Get WH_INFO_TR by warehouseCode
    ''' </summary>
    ''' <param name="barCd"></param>
    ''' <param name="loginId"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetWarehouseTrByBarcodeNo(ByVal barCd As String, _
                                    ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetWarehouseTrByBarcodeNo(barCd)
    End Function

    <WebMethod()> _
    Public Function GetWarehouseTrByCd(ByVal whCode As String, _
                                    ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetWarehouseTrByCd(whCode)
    End Function

    <WebMethod()> _
    Public Function WarehouseTrInquiry(ByVal _whCd As String, _
                                                                            ByVal _rackCd As String, _
                                                                            ByVal _itemCd As String, _
                                                                            ByVal _barcode As String, _
                                                                            ByVal _importDateFrom As Date, _
                                                                            ByVal _importDateTo As Date, _
                                                                            ByVal loginId As String) As DataSet
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.WarehouseTrInquiry(_whCd, _rackCd, _itemCd, _barcode, _importDateFrom, _importDateTo)
    End Function
    <WebMethod()> _
    Public Function GetWarehouseList(ByVal loginId As String) As DataSet
        '' Declare activeevents.
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.GetWarehouseList()
    End Function

    <WebMethod()> _
    Public Function DeleteWarehouseTrByBarcode(ByVal barcodeNo As String, _
                                     ByVal loginCode As String) As Integer
        Dim activeEvents As New ActiveEvents(loginCode)
        Return activeEvents.DeleteWarehouseTrByBarcode(barcodeNo)
    End Function

    <WebMethod()> _
    Public Function InsertWarehouseTrInfo(ByVal barcodeNo As String, _
                                                                                        ByVal whCd As String, _
                                                                                        ByVal rackCd As String, _
                                                                                        ByVal itemCd As String, _
                                                                                        ByVal loginId As String) As Integer
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertWarehouseTrInfo(barcodeNo, whCd, rackCd, itemCd, loginId)
    End Function

    <WebMethod()> _
    Public Function InsertWarehouseTrInfoToString(ByVal barcodeNo As String, _
                                                                                        ByVal whCd As String, _
                                                                                        ByVal rackCd As String, _
                                                                                        ByVal itemCd As String, _
                                                                                        ByVal loginId As String) As String
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.InsertWarehouseTrInfoToString(barcodeNo, whCd, rackCd, itemCd, loginId)
    End Function
#End Region

#Region "Export"
    ''' <summary>
    ''' CheckBarcodeExportExistProcess
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckBarcodeExportExistProcess(ByVal barcodeNo As String, ByVal userId As String) As DataSet
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.CheckBarcodeExportExistProcess(barcodeNo)
    End Function

    ''' <summary>
    ''' ExportBarcodeIntoTemp
    ''' </summary>
    ''' <param name="barcodeNo"></param>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ExportBarcodeIntoMold(ByVal barcodeNo As String, ByVal userId As String, ByVal itemCode As String) As Boolean
        Dim oEvents As New ActiveEvents(userId)
        Return oEvents.ExportBarcodeIntoMold(barcodeNo, itemCode)
    End Function
#End Region

#Region "BATCH 026 Stocktaking Proces"

    <WebMethod()> _
    Public Function GetWhInfoTrList(ByVal warehouseCode As String, ByVal itemCode As String, ByVal loginCode As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetWhInfoTrList(warehouseCode, itemCode)
    End Function

    <WebMethod()> _
    Public Function GetStockReqInfoTr(ByVal loginCode As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetStockReqInfoTr()
    End Function

    <WebMethod()> _
    Public Function GetStockReqDtlInfoTr(ByVal loginCode As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetStockReqDtlInfoTr()
    End Function

    <WebMethod()> _
    Public Function GetStockResultDtlInfoTr(ByVal loginCode As String) As DataSet
        Dim actEvent As New ActiveEvents(loginCode)
        Return actEvent.GetStockResultDtlInfoTr
    End Function

    <WebMethod()> _
    Public Function InsertStockReqDtlInfoTr(ByVal stockDate As Date, ByVal warehouseCode As String, _
                                            ByVal itemCode As String, ByVal bcNoList As List(Of String), _
                                            ByVal whSysCdList As List(Of String), ByVal rackSysCdList As List(Of String), _
                                            ByVal whActCdList As List(Of String), ByVal rackActCdList As List(Of String), _
                                            ByVal loginCode As String) As Integer
        Dim actEvent As New ActiveEvents(loginCode)
        Return actEvent.InsertStockReqDtlInfoTr(stockDate, warehouseCode, itemCode, bcNoList, whSysCdList, rackSysCdList, _
                                                whActCdList, rackActCdList, loginCode)
    End Function
    <WebMethod()> _
    Public Function CheckStocktakingIsEmpty(ByVal loginId As String) As Integer
        Dim actEvent As New ActiveEvents(loginId)
        Return actEvent.CheckStocktakingIsEmpty()
    End Function

#End Region

#Region "Code Master MS"

    ''' <summary>
    ''' Get data table Code Master.
    ''' </summary>
    ''' <param name="code1"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetCodeMasterMS(ByVal code1 As Integer, ByVal loginId As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginId)
        Return activeEvent.GetCodeMasterMS(code1)
    End Function
    ''' <summary>
    ''' Get unit by code 2.
    ''' </summary>
    ''' <param name="code2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetUnitByCode2(ByVal code2 As Integer, ByVal loginId As String) As String
        Dim activeEvent As New ActiveEvents(loginId)
        Return activeEvent.GetUnitByCode2(code2)
    End Function
#End Region

    <WebMethod()> _
    Public Function ProductInfoInquiry(ByVal itemCdList As List(Of String), ByVal woNoList As List(Of String), _
                                           ByVal woDateList As List(Of String), ByVal totalBoxList As List(Of String), _
                                           ByVal qtyPerBoxList As List(Of String), ByVal productQuantityList As List(Of String), _
                                           ByVal loginCode As String) As String
        Dim actEvent As New ActiveEvents(loginCode)
        Return actEvent.ProductInfoInquiry(itemCdList, woNoList, woDateList, totalBoxList, qtyPerBoxList, productQuantityList, loginCode)
    End Function

    <WebMethod()> _
    Public Function GetItemDetailByItemCd(ByVal itemCd As String, ByVal loginCd As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCd)
        Return activeEvent.GetItemDetailByItemCd(itemCd)
    End Function

    <WebMethod()> _
    Public Function ImproveScreenProductInquiry(ByVal workOrderList As List(Of String), ByVal itemCodeList As List(Of String), _
                                                ByVal totalBoxList As List(Of String), ByVal currentNumberBoxList As List(Of String), _
                                                ByVal workOrderDateList As List(Of String), ByVal quantityList As List(Of String), _
                                                ByVal userCode As String) As DataSet
        Dim activeEvents As New ActiveEvents(userCode)
        Return activeEvents.ImproveScreenProductInquiry(workOrderList, itemCodeList, totalBoxList, currentNumberBoxList, workOrderDateList, quantityList, userCode)
    End Function

    <WebMethod()> _
    Public Function GetDataProductInfoInquiryWithModeNew(ByVal itemCode As String, ByVal workOrderNo As String, _
                                                         ByVal dateFrom As String, ByVal dateTo As String, _
                                                         ByVal loginId As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginId)
        Return activeEvent.GetDataProductInfoInquiryWithModeNew(itemCode, workOrderNo, dateFrom, dateTo, loginId)
    End Function

    <WebMethod()> _
    Public Function InsertScreenProductInfoInquiry(ByVal workOrderNo As List(Of String), ByVal workOrderDate As List(Of String), _
                                                   ByVal itemCode As List(Of String), ByVal remainProduct As List(Of String), _
                                                   ByVal productQuantity As List(Of String), ByVal productDate As List(Of String), _
                                                   ByVal quantityPerBox As List(Of String), ByVal totalBox As List(Of String), _
                                                   ByVal currentBoxNumber As List(Of String), ByVal loginCode As String, _
                                                   ByVal itemName As List(Of String)) As Integer
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.InsertScreenProductInfoInquiry(workOrderNo, workOrderDate, _
                                                          itemCode, remainProduct, _
                                                          productQuantity, productDate, _
                                                          quantityPerBox, totalBox, _
                                                          currentBoxNumber, loginCode, _
                                                          itemName)
    End Function

    <WebMethod()> _
    Public Function GetBarcode(ByVal loginCode As String, ByVal limitData As Integer, _
                               ByVal barcodeFrom As String, ByVal barcodeTo As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetBarcode(loginCode, limitData, barcodeFrom, barcodeTo)
    End Function

    <WebMethod()> _
    Public Function GetItemDetailByWorkOrderNo(ByVal workOrderNo As String, ByVal loginCode As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetItemDetailByWorkOrderNo(workOrderNo, loginCode)
    End Function

    <WebMethod()> _
    Public Function GetItemDetailByBarcode(ByVal barcodeNo As String, ByVal loginCode As String) As DataSet
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.GetItemDetailByBarcode(barcodeNo, loginCode)
    End Function

    <WebMethod()> _
    Public Function UpdateItemDetailByBarcode(ByVal barcodeNo As String, ByVal quantity As Integer, _
                                              ByVal productQuantity As Integer, _
                                              ByVal woNo As String, _
                                              ByVal lotNo As String, ByVal loginCode As String) As Integer
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.UpdateItemDetailByBarcode(barcodeNo, quantity, productQuantity, woNo, lotNo, loginCode)
    End Function

    <WebMethod()> _
    Public Function GetListBarcode(ByVal paramWoNo As String, _
                                   ByVal paramBcFrom As String, ByVal paramBcTo As String, _
                                   ByVal paramQuantity As Integer, _
                                   ByVal paramLoginCode As String) As DataSet
        Dim activeEvent As New ActiveEvents(paramLoginCode)
        Return activeEvent.GetListBarcode(paramWoNo, paramBcFrom, paramBcTo, paramQuantity, paramLoginCode)
    End Function

    <WebMethod()> _
    Public Function UpdateItemDetail(ByVal listBarcode As List(Of String), _
                                     ByVal currentBoxNum As Integer, _
                                     ByVal itemCode As String, _
                                     ByVal remainQuantity As Integer, _
                                     ByVal woNo As String, _
                                     ByVal loginCode As String) As Integer
        Dim activeEvent As New ActiveEvents(loginCode)
        Return activeEvent.UpdateItemDetail(listBarcode, currentBoxNum, itemCode, remainQuantity, woNo, loginCode)
    End Function

    <WebMethod()> _
    Public Function GetItemDetailByWorkNo(ByVal woNo As String, ByVal login As String) As DataSet
        Dim actEvent As New ActiveEvents(login)
        Return actEvent.GetItemDetailByWorkNo(woNo, login)
    End Function

#Region "Cap nhat ngay 2015-03-27"

    ''' <summary>
    ''' Lay toan bo du lieu Item Detail ung voi W/O truyen vao.
    ''' Sap xep theo Barcode tang dan.
    ''' </summary>
    ''' <param name="woNo">Du lieu nhan tu man hinh.</param>
    ''' <param name="login">Du lieu nhan tu man hinh.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetItemDetailByWorkNoOrderBarcodeAsc(ByVal woNo As String, ByVal login As String) As DataSet
        Dim actEvent As New ActiveEvents(login)
        Return actEvent.GetItemDetailByWorkNoOrderBarcodeAsc(woNo, login)
    End Function

#End Region

#Region "Cap nhat ngay 2015-03-29"

    <WebMethod()> _
    Public Function UpdateQuantityInBoxByBarcode(ByVal barcodeFrom As String, ByVal lotNoFrom As String, ByVal quantityFrom As Integer, _
                                                 ByVal barcodeTo As String, ByVal lotNoTo As String, ByVal quantityTo As Integer, _
                                                 ByVal itemCode As String, ByVal currentBoxNum As Integer, _
                                                 ByVal loginCode As String) As Integer
        Dim actEvent As New ActiveEvents(loginCode)
        Return actEvent.UpdateQuantityInBoxByBarcode(barcodeFrom, lotNoFrom, quantityFrom, _
                                                     barcodeTo, lotNoTo, quantityTo, _
                                                     itemCode, currentBoxNum, _
                                                     loginCode)
    End Function

    <WebMethod()> _
    Public Function GetPrintBarcode(ByVal qtyTo As String, ByVal lgCd As String) As DataSet
        Dim actEvent As New ActiveEvents(lgCd)
        Return actEvent.GetPrintBarcode(qtyTo, lgCd)
    End Function

#End Region

#Region "Add source (charge)"

    ''' <summary>
    ''' Get shipment inquiry by invoice no
    ''' </summary>
    ''' <param name="invoiceNo"></param>
    ''' <param name="itemCode"></param>
    ''' <param name="registeredId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetShipmentInquiryByInvoiceNo(ByVal invoiceNo As String, ByVal itemCode As String, ByVal registeredId As String) As DataSet
        Dim activeEvents As New ActiveEvents(registeredId)
        Return activeEvents.GetShipmentInquiryByInvoiceNo(invoiceNo, itemCode)
    End Function

    ''' <summary>
    ''' #No.23: Method return W900[cuongtk (20150825)]
    ''' </summary>
    ''' <param name="scanBarcode"></param>
    ''' <param name="loginId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function CheckDataIsValidToReturnW900(ByVal scanBarcode As String, ByVal loginId As String) As String
        Dim activeEvents As New ActiveEvents(loginId)
        Return activeEvents.CheckDataIsValidToReturnW900(scanBarcode, loginId)
    End Function

#End Region

    <WebMethod()> _
    Public Function IsExistW900OrW830(ByVal listBarcode As String, ByVal loginUser As String) As Boolean
        Dim actEvent As New ActiveEvents(loginUser)
        Return actEvent.IsExistW900OrW830(listBarcode)
    End Function

    <WebMethod()> _
    Public Function GetInfoOddBoxByItemCode(ByVal barcodeNo As String, ByVal loginId As String) As DataSet
        Dim actEvents As New ActiveEvents(loginId)
        Return actEvents.GetInfoOddBoxByItemCode(barcodeNo)
    End Function

    <WebMethod()> _
    Public Function UpdateOddToEvenBox(ByVal infoStr As String, ByVal infoLogin As String) As Integer
        Dim acEvents As New ActiveEvents(infoLogin)
        Return acEvents.UpdateOddToEvenBox(infoStr, infoLogin)
    End Function

    <WebMethod()> _
    Public Function PrintNewLabel(ByVal barcodeNo As String, ByVal infoLogin As String) As DataSet
        Dim actEvents As New ActiveEvents(infoLogin)
        Return actEvents.PrintNewLabel(barcodeNo, infoLogin)
    End Function

    ''' <summary>
    ''' Import danh sach Barcode doc Offline.
    ''' </summary>
    ''' <param name="vListBarcode">Danh sach duoc lay tu file doc tu man hinh.</param>
    ''' <param name="vWarehouseCode">Duoc lay tu viec checked radio.</param>
    ''' <param name="vLoginInfo">Thong tin nguoi dung dang su dung he thong.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function ImportWarehouseOffline(ByVal vListBarcode As List(Of String), _
                                           ByVal vWarehouseCode As String, _
                                           ByVal vLoginInfo As String) As String
        Dim aeExecute As New ActiveEvents(vLoginInfo)
        Return aeExecute.ImportWarehouseOffline(vListBarcode, vWarehouseCode, vLoginInfo)
    End Function

#Region "OA_BAT004_ReasonProcess"
    ''' <summary>
    ''' Find reason master by reason code
    ''' </summary>
    ''' <param name="reasonCode">Nguoi dung nhap</param>
    ''' <param name="loginCode">Thong tin nguoi dung dang su dung he thong.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetReasonByCode(ByVal reasonCode As String, _
                                           ByVal loginCode As String) As DataSet
        Dim aeExecute As New ActiveEvents(loginCode)
        Return aeExecute.GetReasonByCode(reasonCode)
    End Function

    <WebMethod()> _
    Public Function InsertReason(ByVal reasonCode As String, _
                                ByVal reasonName As String, _
                                ByVal curUser As String) As Integer
        Dim activeEvents As New ActiveEvents(curUser)
        Return activeEvents.InsertReason(reasonCode, reasonName, curUser)
    End Function

    <WebMethod()> _
    Public Function UpdateReason(ByVal reasonCode As String, _
                                 ByVal reasonName As String, _
                                 ByVal curUser As String) As Integer
        Dim activeEvents As New ActiveEvents(curUser)
        Return activeEvents.UpdateReason(reasonCode, reasonName, curUser)
    End Function

    <WebMethod()> _
    Public Function DeleteReason(ByVal reasonCode As String, _
                                 ByVal curUser As String) As Integer
        Dim activeEvents As New ActiveEvents(curUser)
        Return activeEvents.DeleteReason(reasonCode, curUser)
    End Function

    <WebMethod()> _
    Public Function ReasonInquiry(ByVal reasonCode As String, _
                                  ByVal reasonName As String, _
                                 ByVal curUser As String) As DataSet
        Dim activeEvents As New ActiveEvents(curUser)
        Return activeEvents.ReasonInquiry(reasonCode, reasonName, curUser)
    End Function

#End Region
End Class
