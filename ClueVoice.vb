Public Class ClueVoice
    Dim category As String
    Dim value As Integer
    Dim clue As String
    Dim answer As String
    Dim clueID As String
    Public Sub New(category As String, value As Integer, clue As String, clueID As String, answer As String)
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.answer = answer
        Me.clueID = clueID
    End Sub
    Public Function getCategory() As String
        Return category
    End Function
    Public Function getValue() As Integer
        Return value
    End Function
    Public Function getClue() As String
        Return clue
    End Function
    Public Function getAnswer() As String
        Return answer
    End Function
    Public Function getclueID() As String
        Return clueID
    End Function
End Class
