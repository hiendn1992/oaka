Public Class ABCDConst

#Region "Common Constant"
    Public Const ModeInit As Integer = 0
    Public Const ModeAdd As Integer = 1
    Public Const ModeUpd As Integer = 2
    Public Const ModeDel As Integer = 3

    Public Const DispInit As Integer = 0
    Public Const DispOnce As Integer = 1
    Public Const DispTwice As Integer = 2

    Public Const DefaultNumber As Integer = 0

    Public Const FORMAT_DATE_02 As String = "ddMMyyyy"
    Public Const FORMAT_DATE_05 As String = "dd/MM/yyyy HH:mm:ss"

    Public Const CharConnect As String = "-"

    Public Const SELECTED As Integer = 1
    Public Const UN_SELECTED As Integer = 0

    Public Const GRIDVIEW_NORMAL As Integer = 0
    Public Const GRIDVIEW_BUTTON As Integer = 1
    Public Const GRIDVIEW_CHECKBOX As Integer = 2

    Public Const VALUE_INIT As String = ""

    Public Const COL_AUTHORITY As String = "AUTHORITY"
    Public Const VALUE_ADMIN As String = "Admin"
    Public Const VALUE_FG As String = "FG"
    Public Const VALUE_QC As String = "QC"
    Public Const VALUE_SU As String = "SU"

    Public Const COL_DESTINATION As String = "DEST"
    Public Const VALUE_DOMESTIC As String = "Domestic"
    Public Const VALUE_OVERSEA As String = "Oversea"

    Public Const STYLE_COMBOBOX_01 = "Authority"
    Public Const STYLE_COMBOBOX_02 = "Destination"

    Public Const Name_Save_File As String = "CSV Files (*.csv*) | *.csv"
    Public Const Name_Open_File As String = "CSV Files (*.csv*) | *.csv"

    Public Const NAME_EXPORT_FILE_01 As String = "MSS006"
    Public Const NAME_EXPORT_FILE_02 As String = "MSS009"

    Public Const MSS007_FROM As String = "FROM"
    Public Const MSS007_TO As String = "TO"
#End Region

#Region "Url and Timeout of WebService"
    ''' <summary> Get url web servie. </summary>
    Public Shared STRING_URL As String = Configuration.ConfigurationManager.AppSettings("Url")
    ''' <summary> Get time out web service. </summary>
    Public Shared STRING_TIMEOUT As String = Configuration.ConfigurationManager.AppSettings("TimeOut")
#End Region

#Region "Type combobox"
    ''' <summary> Type for combobox template. </summary>
    Public Const Type_Template As Integer = 2
    ''' <summary> Type for combobox template. </summary>
    Public Const Type_Unit As Integer = 1
    ''' <summary> Type for combobox authority. </summary>
    Public Const Type_Authority As Integer = 3
    ''' <summary> Type for combobox destination. </summary>
    Public Const Type_Destination As Integer = 4
#End Region

#Region "Style format"
    ''' <summary> Format number. </summary>
    Public Shadows Const Format_Number As String = "###,###,###,###"
    ''' <summary> Format date: 2015/01/22. </summary>
    Public Shadows Const Format_Date_04 As String = "yyyy/MM/dd"
    ''' <summary> Format date: 22/01/2015. </summary>
    Public Shadows Const Format_Date_01 As String = "dd/MM/yyyy"
    ''' <summary> Format date: 20150122. </summary>
    Public Shadows Const Format_Date_03 As String = "yyyyMMdd"
    ''' <summary> Format character special. </summary>
    Public Shadows Const Special_Char As String = "[^a-zA-Z0-9]"
    Public Shadows Const Special_Char_Add_Space As String = "^[a-zA-Z0-9_ ]*$"
    ''' <summary> Format file Excel. </summary>
    Public Shadows Const Format_File_Excel As String = "CSV Files (*.csv*) | *.csv | Excel WorkBook (*.xlsx) | *.xlsx | Excel 97-2003 WorkBook (*.xls) | *.xls"
    Public Shadows Const Format_Image As String = "All files (*.*) | *.*"
#End Region

#Region "Code screen"
    Public Const PRODUCT_INQUIRY As String = "PRS002" '// Code screen Product Info Inquiry
    Public Const STOCK_IO_HIST As String = "WHS003" '// Code screen Stock In Out History
#End Region

#Region "Attribute in file app.config"
    Public Const PATH_SAVE_LABEL As String = "PathSaveLabel" '// Attribute export file csv to print label
    Public Const PATH_TEMP_HIST As String = "StockInOutHistory" '// Attribute get path file template StockInOutHistory.xlsx
#End Region

#Region "Format common"
    Public Const DATE_CMN_01 As String = "yyyyMMdd" '// Format date [yyyyMMdd]
    Public Const DATE_CMN_02 As String = "yyyyMMddHHmmss" '// Format date [yyyyMMddHHmmss]
    Public Const DATE_CMN_03 As String = "dd/MM/yyyy" '// Cuongtk - 20150818
    Public Const STRG_CMN_01 As String = " "
    Public Const STRG_CMN_02 As String = "'"
    Public Const STRG_CMN_03 As String = "_"
    Public Const FILE_CMN_01 As String = "Excel File (*.xlsx*) | *.xlsx" '// Format to save file
    Public Const FILE_CMN_02 As String = ".csv"
    Public Const CULT_CMN_INF As String = "en-US" '// Local en-US
#End Region

#Region "Code error message"
    Public Const MSG_CODE_01 As String = "MSG002"
#End Region

End Class
