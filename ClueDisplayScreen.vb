Public Class ClueDisplayScreen
    Dim clueTypeEnum As JeopardyController.clueType
    Public Property clueDisplay As String
        Get
            Return lblClue.Text
        End Get
        Set(value As String)
            lblClue.Text = value
        End Set
    End Property
    Public Property clueType As JeopardyController.clueType
        Get
            Return clueTypeEnum
        End Get
        Set(value As JeopardyController.clueType)
            clueTypeEnum = value
        End Set
    End Property
    Public Property imgClueLocation As String
    Public Property videoClueLocation As String
    Public Property clue As String
    Private Sub pboxClue_DoubleClick(sender As Object, e As EventArgs) Handles pboxClue.DoubleClick
        frmScore.Show()
    End Sub
    Private Sub wmpClue_DoubleClickEvent(sender As Object, e As AxWMPLib._WMPOCXEvents_DoubleClickEvent) Handles wmpClue.DoubleClickEvent
        frmScore.Show()
    End Sub
    Private Sub clueBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles clueBrowser.DocumentCompleted
        CType(sender, WebBrowser).Document.Body.AttachEventHandler("ondblclick", AddressOf Document_DoubleClick)
        'If JeopardyController.roundEnum = JeopardyController.roundType.FinalJeopardy Then
        'CType(sender, WebBrowser).Document.GetElementById("clue").InnerHtml = clue
        If String.IsNullOrEmpty(imgClueLocation) And String.IsNullOrEmpty(videoClueLocation) Then
            CType(sender, WebBrowser).Document.GetElementById("clue").InnerHtml = clue
            'CType(sender, WebBrowser).Document.GetElementById("interactiveClue").Style = "display:none;"
        ElseIf Not String.IsNullOrEmpty(imgClueLocation) And String.IsNullOrEmpty(videoClueLocation) Then
            CType(sender, WebBrowser).Document.GetElementById("interactiveClueString").InnerHtml = clue
            CType(sender, WebBrowser).Document.GetElementById("interactiveBKG").Style = "background-image:url(" & imgClueLocation & ")"
        ElseIf Not String.IsNullOrEmpty(videoClueLocation) And String.IsNullOrEmpty(imgClueLocation) Then
            CType(sender, WebBrowser).Document.GetElementById("interactiveClueString").InnerHtml = clue
            CType(sender, WebBrowser).Document.GetElementById("bkg-video").SetAttribute("src", videoClueLocation)
        End If
        If JeopardyController.virtualHost = True Then
            Try
                JeopardyController.SAPI.Speak(CType(sender, WebBrowser).Document.GetElementById("clue").InnerText)
            Catch ex As Exception
            End Try
        End If
        'End If
    End Sub
    Private Sub Document_DoubleClick(sender As Object, e As EventArgs)
        frmScore.Show()
    End Sub

    Private Sub ClueDisplayScreen_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            If Not String.IsNullOrEmpty(videoClueLocation) Then
                clueBrowser.Document.GetElementById("bkg-video").SetAttribute("src", "")
                videoClueLocation = ""
            End If
            If Not String.IsNullOrEmpty(imgClueLocation) Then
                imgClueLocation = ""
            End If
        End If
    End Sub
End Class
