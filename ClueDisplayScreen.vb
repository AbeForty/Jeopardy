Public Class ClueDisplayScreen
    Public Property clueDisplay As String
        Get
            Return lblClue.Text
        End Get
        Set(value As String)
            lblClue.Text = value
        End Set
    End Property
End Class
