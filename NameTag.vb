Public Class NameTag
    Public Property contestantID As Integer
    Public Property score As Integer
    Public Property enableClick As Boolean = True
    Public Overrides Property Text As String
        Get
            Return lblName.Text
        End Get
        Set(value As String)
            'lblName.Font = New Font(Me.lblName.Font.FontFamily, 13)
            Dim graLabel As Graphics = Me.lblName.CreateGraphics
            Dim sngFontSize As Single = 13
            Dim fntText As Font
            Dim dsfRequired As SizeF
            If Not Parent Is frmScore Then
                Do
                    fntText = New Font(Me.lblName.Font.FontFamily, sngFontSize)
                    dsfRequired = graLabel.MeasureString(value, fntText)
                    sngFontSize = 0.99F * sngFontSize '
                Loop Until (dsfRequired.Width <= Me.lblName.ClientSize.Width - 20 And dsfRequired.Height <= Me.lblName.ClientSize.Height)
            Else
                Do
                    fntText = New Font(Me.lblName.Font.FontFamily, sngFontSize)
                    dsfRequired = graLabel.MeasureString(value, fntText)
                    sngFontSize = 0.99F * sngFontSize '
                Loop Until (dsfRequired.Width <= Me.lblName.ClientSize.Width - 50 And dsfRequired.Height <= Me.lblName.ClientSize.Height)
            End If
            'MsgBox("Final font size = " & sngFontSize)
            Me.lblName.Font = fntText
            Me.lblName.Text = value
        End Set
    End Property
    'Dim h As String
    'Dim w As String
    Private Sub lblName_Paint(sender As Object, e As PaintEventArgs) Handles lblName.Paint
        'Dim orgFont As New Font(lblName.Font.Name, lblName.Font.Size, lblName.Font.Style)
        'Dim textSize As New SizeF
        'textSize = e.Graphics.MeasureString(lblName.Text, orgFont)
        'h = textSize.Height
        'w = textSize.Width
    End Sub

    Private Sub lblName_Click(sender As Object, e As EventArgs) Handles lblName.Click
        If ParentForm Is frmNewGame Then
            If enableClick = True Then
                If ContestantControl.ShowDialog() = DialogResult.OK Then
                    'CType(CType(sender, Label).Parent, NameTag)
                    contestantID = ContestantControl.contestantID
                    Text = ContestantControl.contestantName
                    'Dim numOfPlayers As Integer
                    'For i As Integer = 1 To 3
                    '    'If CType(frmNewGame.pnlNewGame.Controls("NameTag" & i), NameTag).contestantID <> Nothing Then
                    '    '    numOfPlayers += 1
                    '    'End If
                    'Next
                    'Try
                    '    'frmNewGame.numPlayers.Value = numOfPlayers
                    'Catch ex As Exception

                    'End Try
                End If
            End If
        ElseIf ParentForm Is ContestantControl Then
            ContestantControl.contestantID = contestantID
            ContestantControl.contestantName = Text
            ContestantControl.score = score
            ContestantControl.DialogResult = DialogResult.OK
        ElseIf TypeOf (Parent) Is ContestantDisplay Then
            OnClick(e)
        End If
    End Sub

    Private Sub lblName_DoubleClick(sender As Object, e As EventArgs) Handles lblName.DoubleClick
        OnDoubleClick(e)
    End Sub
End Class
