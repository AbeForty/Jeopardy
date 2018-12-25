Public Class Clue
    Public Property category As String
    Public Property value As Integer
    Public Property clue As String
    Public Property answer As List(Of String)
    Public Property clueID As String
    Public Property interactiveClueLocation As String = ""
    Public Property dailyDouble As Boolean
    Public Property cbID As Integer
    Public Property round As Integer
    Public Sub New(category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean, interactiveClueLocation As String, answer As List(Of String))
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.answer = answer
        Me.clueID = clueID
        Me.interactiveClueLocation = interactiveClueLocation
        Me.dailyDouble = dailyDouble
    End Sub
    Public Sub New(category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean, answer As List(Of String))
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.answer = answer
        Me.clueID = clueID
        Me.interactiveClueLocation = interactiveClueLocation
        Me.dailyDouble = dailyDouble
    End Sub
    Public Sub New(category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean, interactiveClueLocation As String)
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.clueID = clueID
        Me.interactiveClueLocation = interactiveClueLocation
        Me.dailyDouble = dailyDouble
    End Sub
    Public Sub New(category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean)
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.clueID = clueID
        Me.dailyDouble = dailyDouble
    End Sub
    Public Sub New(cbID As Integer, category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean, interactiveClueLocation As String, answer As List(Of String))
        Me.cbID = cbID
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.answer = answer
        Me.clueID = clueID
        Me.interactiveClueLocation = interactiveClueLocation
        Me.dailyDouble = dailyDouble
    End Sub
    Public Sub New(cbID As Integer, round As Integer, category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean, interactiveClueLocation As String, answer As List(Of String))
        Me.cbID = cbID
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.answer = answer
        Me.clueID = clueID
        Me.interactiveClueLocation = interactiveClueLocation
        Me.dailyDouble = dailyDouble
        Me.round = round
    End Sub
    Public Sub New(cbID As Integer, category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean, answer As List(Of String))
        Me.cbID = cbID
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.answer = answer
        Me.clueID = clueID
        Me.interactiveClueLocation = interactiveClueLocation
        Me.dailyDouble = dailyDouble
    End Sub
    Public Sub New(cbID As Integer, category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean, interactiveClueLocation As String)
        Me.cbID = cbID
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.clueID = clueID
        Me.interactiveClueLocation = interactiveClueLocation
        Me.dailyDouble = dailyDouble
    End Sub
    Public Sub New(cbID As Integer, category As String, value As Integer, clue As String, clueID As String, dailyDouble As Boolean)
        Me.cbID = cbID
        Me.category = category
        Me.value = value
        Me.clue = clue
        Me.clueID = clueID
        Me.dailyDouble = dailyDouble
    End Sub
End Class