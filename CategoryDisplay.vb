Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class CategoryDisplay
    Dim timeStart As Integer
    Public displayFinished As Boolean = False
    Public categoryList As New List(Of String)
    Public i As Integer = 1
    'Public Property Category As String
    '    Get
    '        Return lblCategory.Text
    '    End Get
    '    Set(value As String)
    '        lblCategory.Text = value
    '    End Set
    'End Property
    'Public Sub addCategory(category As String)
    '    categoryList.Add(category)
    'End Sub
    Private Sub tmrRevealCategory_Tick(sender As Object, e As EventArgs) Handles tmrRevealCategory.Tick
        'Do While categoryList.Count > 0
        '    If DateTime.Now.Second = JeopardyController.convertTimePlus1(timeStart) Then
        '        If pboxJeopardyCard.Visible = False Then
        '            pboxJeopardyCard.Show()
        '            If pboxJeopardyCard.Image.Equals(My.Resources.JeopardyTitlesGIF1) Then
        '                pboxJeopardyCard.Image = My.Resources.JeopardyTitlesGIF
        '            ElseIf pboxJeopardyCard.Image.Equals(My.Resources.JeopardyTitlesGIF) Then
        '                pboxJeopardyCard.Image = My.Resources.JeopardyTitlesGIF1
        '            End If
        '        Else
        '            pboxJeopardyCard.Hide()
        '        End If
        '        timeStart = DateTime.Now.Second + 5
        '    End If
        'Loop
    End Sub

    Private Sub CategoryDisplay_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        'If Me.Visible = False Then
        '    displayFinished = True
        'End If
        'timeStart = DateTime.Now.Second
        'pboxJeopardyCard.Image = My.Resources.JeopardyTitlesGIF
        'tmrRevealCategory.Start()
        If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
            pboxJeopardyCard.Image = My.Resources.JEOPARDYLogo
        ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
            pboxJeopardyCard.Image = My.Resources.DOUBLEJeopardy
        End If
        pboxJeopardyCard.Show()
        i = 1
        catBrowser.Navigate(Application.StartupPath & "\Resources\category.html")
    End Sub

    Private Sub pboxJeopardyCard_Click(sender As Object, e As EventArgs) Handles pboxJeopardyCard.Click
        'Try
        If i <= 6 Then
            'catBrowser.Navigate(Application.StartupPath & "\Resources\category.html")
            If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                catBrowser.Document.GetElementById("category").InnerText = JeopardyController.lstClues(i & 200).category
            ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                catBrowser.Document.GetElementById("category").InnerText = JeopardyController.lstClues(i & 400).category
            End If
            'catBrowser.Update()
            'MsgBox(catBrowser.DocumentText)
            'lblCategory.Text = categoryList(i)
            pboxJeopardyCard.Hide()
        ElseIf i = 1 Then
            'lblCategory.Text = categoryList(i)
            pboxJeopardyCard.Hide()
        ElseIf i > 6 Then
            Me.Hide()
            frmScore.Show()
            displayFinished = True
        End If
        'Catch ex As Exception
        '    Me.Hide()
        'End Try
    End Sub

    'Private Sub catBrowser_MouseClick(sender As Object, e As EventArgs) Handles catBrowser.Click

    'End Sub

    Private Sub CategoryDisplay_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If i < 6 Then
            pboxJeopardyCard.Show()
            'categoryList.Remove(lblCategory.Text)
            i += 1
            VariableTesting.lblCatNumber.Text = i
        Else
            Me.Hide()
            frmScore.Show()
            displayFinished = True
        End If
    End Sub
End Class