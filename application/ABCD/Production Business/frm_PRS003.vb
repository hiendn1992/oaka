''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* System Name：ABCD_Barcode_System
''* Class Name ：frm_PRS003.vb
''*********************************************************
''* History:
''* No.    Date      Version    User    Action
''* 01   13-JAN-15    1.00     CuongTK   New
''*********************************************************
Imports System.Globalization
Imports ABCD.My.Resources

Public Class frm_PRS003

#Region "Var/Const Form"

    ''' <summary>
    ''' Web service connect between client and server.
    ''' </summary>
    ''' <remarks></remarks>
    Private ws As New ABCDService.Service

    ''' <summary>
    ''' Variable contains user login.
    ''' </summary>
    ''' <remarks></remarks>
    Private loginId As String = ABCDCommon.UserId

#End Region

#Region "New Form"

#End Region

#Region "Event Form"

    ''' <summary>
    ''' Load frm_PRS003.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frm_PRS003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Get system date.
        Me.lbToday.Text = ABCDCommon.GetSystemDateWithFormat
        '' Enable tbTotal, tbImport, tbError.
        tbTotal.Enabled = False
        tbImport.Enabled = False
        tbError.Enabled = False
        '' Config to call web service by ip address.
        Me.ws.Url = ABCDConst.STRING_URL
        Me.ws.Timeout = ABCDConst.STRING_TIMEOUT
    End Sub

    ''' <summary>
    ''' Exit frm_PRS003.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Import data frm_PRS003.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImport.Click
        Dim sr As IO.StreamReader = Nothing
        Dim newLine() As String = Nothing
        Dim totalRecord As Integer = 0
        Dim importRecord As Integer = 0
        Dim errorRecord As Integer = 0
        Dim nameLog As String = "impErrLog_" & DateTime.Now.ToString("ddMMyyHHmmss") & ".log"
        Dim contentLog As String = ""

        Dim woNoList As New List(Of String)
        Dim itemCdList As New List(Of String)
        Dim proQtyList As New List(Of String)
        Dim woDateList As New List(Of String)
        Dim totalBoxList As New List(Of String)
        Dim qtyPerBoxList As New List(Of String)

        ''3.1 Check file is null or blank.
        If Not CheckFileInDirect(tbCSVFile.Text) Then
            Dim scrError As New frm_MSG001("Please specify CSV files", "ERR053")
            scrError.ShowDialog()
            btBrowse.Focus()
            Return
        End If

        '' 3.2 Check format file import.
        Try
            sr = New IO.StreamReader(Me.tbCSVFile.Text)
            newLine = sr.ReadLine.Split(","c)
        Catch ex As Exception
            Dim scrErrSys As New frm_MSG001(ex.Message, "ERRSYS")
            scrErrSys.ShowDialog()
            Return
        End Try
        If newLine.Count <> 5 _
        Or Not newLine(0).Equals("W/O No") Or Not newLine(1).Equals("W/O Date") _
        Or Not newLine(2).Equals("Item Code") Or Not newLine(3).Equals("Product Qty") _
        Or Not newLine(4).Equals("Qty Per Box") Then
            Dim scrError As New frm_MSG001("File's format is invalid", "ERR054")
            scrError.ShowDialog()
            btBrowse.Focus()
            Return
        End If

        '' 3.3
        '' 3.3.2 Read each line.
        While Not sr.EndOfStream
            totalRecord += 1
            newLine = sr.ReadLine.Split(","c)
            contentLog = ""

            '' 3.3.2.1 Check W/O No registered.
            If newLine(0).Length < 10 Then
                contentLog = "Record: " & totalRecord.ToString & ". Error: W/O No not enough 10 character."
                errorRecord = errorRecord + 1
            Else
                If Not IsNumeric(newLine(0)) Then
                    contentLog = "Record: " & totalRecord.ToString & ". Error: W/O No not enough 10 character."
                    errorRecord = errorRecord + 1
                Else
                    Dim ds As DataSet = ws.GetWOInfoByWONo(newLine(0), ABCDCommon.UserId)
                    If ds.Tables(0).Rows.Count = 1 Then
                        contentLog = "Record: " & totalRecord.ToString & ". Error: W/O No is exist in DB."
                        errorRecord = errorRecord + 1
                    Else
                        ' 3.3.2.2 Check W/O Date is valid.
                        If newLine(1).Equals("") Or Not DateTime.TryParseExact(newLine(1), "yyyy/MM/dd", CultureInfo.InvariantCulture, _
                                                                               DateTimeStyles.None, Nothing) Then
                            contentLog = "Record: " & totalRecord.ToString & ". Error: W/O Date is invalid."
                            errorRecord += 1
                        Else
                            '' 3.3.2.3 Check Item Code exist.
                            Dim dsItemCd As DataSet = ws.GetItemInfoByCd(newLine(2), loginId)
                            If dsItemCd.Tables(0).Rows.Count = 0 Then
                                contentLog = "Record: " & totalRecord.ToString & ". Error: Item Code is not exist."
                                errorRecord += 1
                            Else
                                '' 3.3.2.4 Check Product Quantity valid.
                                Dim n1 As Integer
                                If IsNumeric(newLine(3)) = False Or Integer.TryParse(newLine(3), n1) = False Then
                                    contentLog = "Record: " & totalRecord.ToString & ". Error: Product Quantity is invalid."
                                    errorRecord += 1
                                Else
                                    Dim n As Integer
                                    If IsNumeric(newLine(4)) = False Or Integer.TryParse(newLine(4), n) = False Then
                                        contentLog = "Record: " & totalRecord.ToString & ". Error: Quantity Per Box is invalid."
                                        errorRecord += 1
                                    Else
                                        Dim totalBox As String = CalculateTotalBox(newLine(3), n.ToString)
                                        importRecord += 1
                                        If woNoList.Count = 0 Then
                                            woNoList.Add(ABCDCommon.AddZeros(newLine(0), 10)) '' Add value W/O No list.
                                            itemCdList.Add(newLine(2)) '' Add value Item Cd list.
                                            proQtyList.Add(newLine(3)) '' Add value Product Quantity list.
                                            woDateList.Add(newLine(1)) '' Add value W/O Date list.
                                            totalBoxList.Add(totalBox) '' Add value Total Box list.
                                            qtyPerBoxList.Add(n.ToString) '' Add value Quantity Per Box list.
                                        Else
                                            If CheckDuplicateDate(ABCDCommon.AddZeros(newLine(0), 10), woNoList) Then
                                                woNoList.Add(ABCDCommon.AddZeros(newLine(0), 10)) '' Add value W/O No list.
                                                itemCdList.Add(newLine(2)) '' Add value Item Cd list.
                                                proQtyList.Add(newLine(3)) '' Add value Product Quantity list.
                                                woDateList.Add(newLine(1)) '' Add value W/O Date list.
                                                totalBoxList.Add(totalBox) '' Add value Total Box list.
                                                qtyPerBoxList.Add(n.ToString) '' Add value Quantity Per Box list.
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If Not contentLog.Equals("") Then
                contentLog = contentLog & vbCrLf
                '' Write error log.
                My.Computer.FileSystem.WriteAllText(Configuration.ConfigurationManager.AppSettings("Dir") & nameLog, contentLog, True)
            End If
        End While

        '' Close file reading.
        sr.Close()

        '' 3.3.2.5 Execute insert data from csv.
        tbTotal.Text = totalRecord
        tbError.Text = errorRecord
        tbImport.Text = importRecord
        Dim num As Integer = ws.InsertWOInfo(woNoList.ToArray, woDateList.ToArray, itemCdList.ToArray, proQtyList.ToArray, _
                                             qtyPerBoxList.ToArray, totalBoxList.ToArray, loginId)

        '' 3.5 Notice: Import successful.
        If num <> 0 Then
            Dim scrInfo As New frm_MSG001(Messages.INF067, "INF067")
            scrInfo.ShowDialog()
            Return
        Else
            Dim scrInfo As New frm_MSG001(Messages.ERR068, "ERR068")
            scrInfo.ShowDialog()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Open dialog select CSV file frm_PRS003.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowse.Click
        '' Set file need filter.
        Me.ofDialog.Filter = ABCDConst.Name_Open_File
        Me.ofDialog.FileName = Nothing
        '' Show dialog to get file csv.
        If Me.ofDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.tbCSVFile.Text = Me.ofDialog.FileName
        End If
    End Sub

#End Region

#Region "Function"

    ''' <summary>
    ''' Check file exist in directory.
    ''' </summary>
    ''' <param name="path">Path name</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckFileInDirect(ByVal path As String) As Boolean
        If My.Computer.FileSystem.FileExists(path) Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' Calculate value total box.
    ''' </summary>
    ''' <param name="number1"></param>
    ''' <param name="number2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CalculateTotalBox(ByVal number1 As String, ByVal number2 As String) As String
        Dim totalBox As Integer = 0
        Dim modNum As Integer = 0
        Dim divNum As Integer = 0

        modNum = Integer.Parse(number1) Mod Integer.Parse(number2)
        divNum = Integer.Parse(number1) \ Integer.Parse(number2)

        totalBox = divNum
        If modNum <> 0 Then
            totalBox += 1
        End If

        Return totalBox.ToString
    End Function

    ''' <summary>
    ''' Check duplicate data in list.
    ''' </summary>
    ''' <param name="val"></param>
    ''' <param name="lst"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDuplicateDate(ByVal val As String, ByVal lst As List(Of String)) As Boolean
        For i As Integer = 0 To lst.Count - 1 Step 1
            If val.Equals(lst(i)) Then
                Return False
            End If
        Next
        Return True
    End Function

#End Region

End Class