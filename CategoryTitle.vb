Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class CategoryTitle
    Dim displayBoolean As Boolean = True
    Public Property display As Boolean
        Get
            Return displayBoolean
        End Get
        Set(value As Boolean)
            displayBoolean = value
            If value = False Then
                'catBrowserSmall.Navigate(Application.StartupPath & "/Resources/category.html")
                catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
            End If
        End Set
    End Property
    'Public Property category As String
    '    Get
    '        Return lblCategory.Text
    '    End Get
    '    Set(value As String)
    '        lblCategory.Text = value
    '        'Dim TheseAreYourWords As String()
    '        'TheseAreYourWords = value.Split(" ")
    '        'For Each item As String In TheseAreYourWords
    '        '    If Not item = TheseAreYourWords.Last Then
    '        '        If item.Length > 13 And item.Length <= 15 Then
    '        '            lblCategory.Font = New Font("Open Sans", 10, FontStyle.Bold)
    '        '        ElseIf item.Length > 15 And item.Length <= 19 Then
    '        '            lblCategory.Font = New Font("Open Sans", 8, FontStyle.Bold)
    '        '        ElseIf item.Length > 19 And item.Length <= 26 Then
    '        '            lblCategory.Font = New Font("Open Sans", 6, FontStyle.Bold)
    '        '        ElseIf item.Length > 26 And item.Length <= 34 Then
    '        '            lblCategory.Font = New Font("Open Sans", 4, FontStyle.Bold)
    '        '        ElseIf item.Length < 13 Then
    '        '            lblCategory.Font = New Font("Open Sans", 12, FontStyle.Bold)
    '        '        End If
    '        '    Else
    '        '    End If
    '        'Next
    '    End Set
    'End Property
    Private Sub lblCategory_TextChanged(sender As Object, e As EventArgs)
        'While 182 < System.Windows.Forms.TextRenderer.MeasureText(Me.Text, New Font(Me.Font.FontFamily, Me.Font.Size, Me.Font.Style)).Width
        '    Me.Font = New Font(Me.Font.FontFamily, Me.Font.Size - 0.5F, Me.Font.Style)
        'End While
        'And lblCategory.Height < System.Windows.Forms.TextRenderer.MeasureText(lblCategory.Text, New Font(lblCategory.Font.FontFamily, lblCategory.Font.Size, lblCategory.Font.Style)).Height
    End Sub
    'Private Sub tmrCheckSize_Tick(sender As Object, e As EventArgs) Handles tmrCheckSize.Tick
    '    'If ScreenTypeEnum = ScreenType.Mini Then
    '    '    lblCategory.Font = New Font(lblCategory.Font.FontFamily, 12, FontStyle.Bold)
    '    'ElseIf ScreenTypeEnum = ScreenType.Large Then
    '    '    lblCategory.Font = New Font(lblCategory.Font.FontFamily, 138, FontStyle.Bold)
    '    'End If
    'End Sub
    Private Sub CategoryTitle_Load(sender As Object, e As EventArgs) Handles Me.Load
        'lblCategory.Font = New Font("Open Sans", .ClientSize.Height / 20)
        'tmrCheckSize.Start()
    End Sub

    Private Sub catBrowserSmall_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles catBrowserSmall.DocumentCompleted
        If display = False Then
            CType(sender, WebBrowser).Document.GetElementById("category").InnerHtml = ""
        End If
    End Sub
End Class