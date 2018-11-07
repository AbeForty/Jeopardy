Imports System.Data.SqlClient

Public Class Player
    Public Property ID As Integer
    Public Property PlayerNumber As Integer
    Public Property PlayerName As String
    Public Property Score As Integer
    Dim connClues As SqlConnection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
    Public Sub New(ID As Integer, PlayerNumber As Integer, PlayerName As String, Optional Score As Integer = 0)
        Me.ID = ID
        Me.PlayerNumber = PlayerNumber
        Me.PlayerName = PlayerName
        Me.Score = Score
    End Sub
    Public Sub New(PlayerNumber As Integer, PlayerName As String, Optional Score As Integer = 0)
        Me.PlayerNumber = PlayerNumber
        Me.PlayerName = PlayerName
        Me.Score = Score
    End Sub
    Public Sub saveCurrentScore()
        Dim cmdGamePlayer As SqlCommand
        connClues.Open()
        Dim strUpdateScoreSQL As String = "Update GamePlayer Set Score = @score WHERE GameID = @gameID And PlayerID = @playerID"
        cmdGamePlayer = New SqlCommand(strUpdateScoreSQL, connClues)
        Dim scoreParam As SqlParameter = New SqlParameter("@score", Score)
        Dim playerIDParam As SqlParameter = New SqlParameter("@playerID", ID)
        Dim gameIDParam As SqlParameter = New SqlParameter("@gameID", JeopardyController.gameID)
        cmdGamePlayer.Parameters.Add(scoreParam)
        cmdGamePlayer.Parameters.Add(playerIDParam)
        cmdGamePlayer.Parameters.Add(gameIDParam)
        cmdGamePlayer.CommandType = CommandType.Text
        cmdGamePlayer.ExecuteNonQuery()
        connClues.Close()
    End Sub
    Public Sub saveTotal()
        Dim cmdUpdatePlayerTotal As SqlCommand
        connClues.Open()
        Dim strUpdatePlayerTotal As String = "Update Player SET Total += @total WHERE Id = @playerID"
        cmdUpdatePlayerTotal = New SqlCommand(strUpdatePlayerTotal, connClues)
        Dim totalParam As SqlParameter = New SqlParameter("@total", Score)
        Dim playerIDParam As SqlParameter = New SqlParameter("@playerID", ID)
        cmdUpdatePlayerTotal.Parameters.Add(totalParam)
        cmdUpdatePlayerTotal.Parameters.Add(playerIDParam)
        cmdUpdatePlayerTotal.CommandType = CommandType.Text
        cmdUpdatePlayerTotal.ExecuteNonQuery()
        connClues.Close()
    End Sub
End Class
