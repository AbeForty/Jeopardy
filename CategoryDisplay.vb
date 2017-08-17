Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class CategoryDisplay
    Dim timeStart As Integer = DateTime.Now.Second
    Public displayFinished As Boolean = False
    Public categoryList As New List(Of String)
    Dim i As Integer = 0
    Public Property Category As String
        Get
            Return lblCategory.Text
        End Get
        Set(value As String)
            lblCategory.Text = value
        End Set
    End Property
    Public Sub addCategory(category As String)
        categoryList.Add(category)
    End Sub
    Private Sub tmrRevealCategory_Tick(sender As Object, e As EventArgs) Handles tmrRevealCategory.Tick
        'Do While categoryList.Count > 0
        '    If DateTime.Now.Second = JeopardyController.convertTime(timeStart) Then
        '        lblCategory.Text = categoryList(i)

        '    End If
        'Loop
    End Sub

    Private Sub CategoryDisplay_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        'If Me.Visible = False Then
        '    displayFinished = True
        'End If
        'tmrRevealCategory.Start()
    End Sub

    Private Sub pboxJeopardyCard_Click(sender As Object, e As EventArgs) Handles pboxJeopardyCard.Click
        'Try
        If i <= categoryList.Count - 1 Then
            lblCategory.Text = categoryList(i)
            pboxJeopardyCard.Hide()
        Else
            Me.Hide()
            displayFinished = True
        End If
        'Catch ex As Exception
        '    Me.Hide()
        'End Try
    End Sub

    Private Sub lblCategory_Click(sender As Object, e As EventArgs) Handles lblCategory.Click
        If i < categoryList.Count - 1 Then
            pboxJeopardyCard.Show()
            'categoryList.Remove(lblCategory.Text)
            i += 1
        Else
            Me.Hide()
            displayFinished = True
        End If

    End Sub
End Class
