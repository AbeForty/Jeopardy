Public Class QuestionBox
    Public WriteOnly Property displayedClue
        Set(value)
            clue.Load(value)
        End Set
    End Property

    Private Sub QuestionBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Bottom
        Me.BringToFront()
    End Sub
End Class