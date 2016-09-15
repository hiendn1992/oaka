''*********************************************************
''* Copyright AIT Software CO.,ltd. 2014
''* システム名：ABCDCommon
''* クラス名  ：
''* 処理概要  ：
''*********************************************************
''* 履歴：
''* NO   日付   Ver  更新者          内容
#Region "彦根修正履歴"
''* 1 14/12/17 1.00  AIT)cuongnc     New
#End Region
''*********************************************************
Imports Bt
Imports jp.co.ait.common.forms

Public Class MessageListener
    Inherits Microsoft.WindowsCE.Forms.MessageWindow

#Region " VARIABLE / CONSTANT "
    ' Create an instance of the form.
    Private msgform As ABCDBCForm
#End Region

#Region " CONSTRUCTOR "
    ''' <summary>
    ''' Constructor with param
    ''' </summary>
    ''' <param name="msgform"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal msgform As ABCDBCForm)
        Me.msgform = msgform
    End Sub
#End Region

    Public Sub initObj()
        Me.msgform = Nothing
        Me.Dispose()
    End Sub

#Region " MENTHOD "
    ''' <summary>
    ''' Override the default WndProc behavior to examine messages.
    ''' </summary>
    ''' <param name="msg">Microsoft.WindowsCE.Forms.Message</param>
    ''' <remarks></remarks>
    Protected Overrides Sub WndProc(ByRef msg As Microsoft.WindowsCE.Forms.Message)
        Me.msgform.RespondToMessage(msg.HWnd, msg.LParam, msg.Msg, msg.Result, msg.WParam)
        MyBase.WndProc(msg)
    End Sub
#End Region
End Class
