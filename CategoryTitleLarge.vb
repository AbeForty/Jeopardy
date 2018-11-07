Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class CategoryTitleLarge
    Dim displayBoolean As Boolean = True
    Public Property display As Boolean
        Get
            Return displayBoolean
        End Get
        Set(value As Boolean)
            displayBoolean = value
            If value = False Then
                catBrowser.Navigate(JeopardyController.finalURL & "\Resources\category.html")
            End If
        End Set
    End Property
    Public Property category As String
    Private Sub catBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles catBrowser.DocumentCompleted
        If JeopardyController.roundEnum = JeopardyController.roundType.FinalJeopardy Then
            CType(sender, WebBrowser).Document.GetElementById("category").InnerHtml = category
        End If
    End Sub
End Class
