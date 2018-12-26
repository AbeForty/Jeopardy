Imports System.Data.SqlClient
Public Class frmLoadGame
    Dim numOfPlayers As Integer
    Dim loadingGame As Boolean = False
    Private Sub getPreviousGames()
        Try
            Dim connPuzzle As SqlConnection
            'connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "http://localhost/Jeopardy/App_Data/" & "JeopardyClues.mdf;Integrated Security=True")
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "SELECT * FROM Game WHERE Final = 0"
            Dim cmd As SqlCommand
            Dim rdr As SqlDataReader
            connPuzzle.Open()
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            If rdr.HasRows() Then
            Else
                MsgBox("You don't have any unfinished saved games.", vbInformation, "JEOPARDY!")
                frmNewGame.Show()
                Me.Close()
                Exit Sub
            End If
            Do While rdr.Read()
                cboGame.Items.Add(Trim(rdr("Id")).ToString & "|" & Trim(rdr("PackName")).ToString & "|" & Trim(rdr("created_at")).ToString)
            Loop
            connPuzzle.Close()
        Catch ex As Exception
            MsgBox("Saved Games failed to load.", vbCritical, "JEOPARDY!")
            frmNewGame.Show()
            Me.Close()
        End Try
    End Sub
    Private Sub dlgSelectPack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlLoadGame.Top = (Me.ClientSize.Height / 2) - (pnlLoadGame.Height / 2)
        pnlLoadGame.Left = (Me.ClientSize.Width / 2) - (pnlLoadGame.Width / 2)
        getPreviousGames()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnResumeGame_Click(sender As Object, e As EventArgs) Handles btnResumeGame.Click
        If cboGame.SelectedItem <> Nothing Then
            Dim gameInfo = cboGame.SelectedItem.ToString.Split("|")
            JeopardyController.gameID = gameInfo(0)
            Dim connClues As SqlConnection
            connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
            Dim strSQL As String = "SELECT * FROM GamePlayer, Player WHERE GameID = @GameID and GamePlayer.PlayerID = Player.Id"
            Dim rdr As SqlDataReader
            Dim seenCluesrdr As SqlDataReader
            Dim cmd As SqlCommand
            Dim cmdSeenClues As SqlCommand
            connClues.Open()
            cmd = New SqlCommand(strSQL, connClues)
            Dim gameIDParam As SqlParameter = New SqlParameter("@GameID", gameInfo(0))
            cmd.Parameters.Add(gameIDParam)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            'Dim playerIDList As New Dictionary(Of KeyValuePair(Of Integer, String), Integer)
            Do While rdr.Read()
                Dim myNewPlayer As Player = New Player(rdr("PlayerID"), rdr("PlayerNumber"), Trim(rdr("Name")), rdr("Score"))
                If rdr("PlayerNumber") = 1 Then
                    JeopardyController.Player1List.Add(myNewPlayer)
                    frmScore.lblPlayer1Score.Text = FormatCurrency(myNewPlayer.Score, 0, , TriState.False)
                ElseIf rdr("PlayerNumber") = 2 Then
                    JeopardyController.Player2List.Add(myNewPlayer)
                    frmScore.lblPlayer2Score.Text = FormatCurrency(myNewPlayer.Score, 0, , TriState.False)
                ElseIf rdr("PlayerNumber") = 3 Then
                    JeopardyController.Player3List.Add(myNewPlayer)
                    frmScore.lblPlayer3Score.Text = FormatCurrency(myNewPlayer.Score, 0, , TriState.False)
                End If
                'Dim playerKVP As KeyValuePair(Of Integer, String) = New KeyValuePair(Of Integer, String)(Trim(rdr("PlayerID")), Trim(rdr("Name")))
                'playerIDList.Add(playerKVP, Integer.Parse(rdr("Score")))
            Loop
            connClues.Close()
            Dim strRoundSQL As String = "SELECT * FROM Game WHERE Id = @GameID"
            Dim roundrdr As SqlDataReader
            Dim cmdRound As SqlCommand
            connClues.Open()
            cmdRound = New SqlCommand(strRoundSQL, connClues)
            Dim gameID3Param As SqlParameter = New SqlParameter("@GameID", gameInfo(0))
            cmdRound.Parameters.Add(gameID3Param)
            cmdRound.CommandType = CommandType.Text
            roundrdr = cmdRound.ExecuteReader()
            Do While roundrdr.Read()
                If roundrdr("VirtualHost") = 0 Then
                    JeopardyController.virtualHost = False
                ElseIf roundrdr("VirtualHost") = 1 Then
                    JeopardyController.virtualHost = True
                End If
                If roundrdr("Round") = 1 Then
                    JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy
                ElseIf roundrdr("Round") = 2 Then
                    JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy
                ElseIf roundrdr("Round") = 3 Then
                    JeopardyController.roundEnum = JeopardyController.roundType.FinalJeopardy
                End If
                JeopardyController.roundNumber = roundrdr("Round")
            Loop
            connClues.Close()
            connClues.Open()
            'Dim newPlayer As New Player((playerIDList.ElementAt(0).Key.Key), 1, (playerIDList.ElementAt(0).Key.Value))
            'JeopardyController.Player1List.Add(newPlayer)
            'Dim newPlayer2 As New Player((playerIDList.ElementAt(1).Key.Key), 2, (playerIDList.ElementAt(1).Key.Value))
            'JeopardyController.Player1List.Add(newPlayer2)
            'Dim newPlayer3 As New Player((playerIDList.ElementAt(2).Key.Key), 3, (playerIDList.ElementAt(2).Key.Value))
            'JeopardyController.Player1List.Add(newPlayer3)
            'JeopardyController.player1Id = playerIDList.ElementAt(0).Key.Key
            'JeopardyController.player2Id = playerIDList.ElementAt(1).Key.Key
            'JeopardyController.player3Id = playerIDList.ElementAt(2).Key.Key
            'JeopardyController.player1Name = playerIDList.ElementAt(0).Key.Value
            'JeopardyController.player2Name = playerIDList.ElementAt(1).Key.Value
            'JeopardyController.player3Name = playerIDList.ElementAt(2).Key.Value
            'frmScore.lblPlayer1Score.Text = FormatCurrency(Integer.Parse(playerIDList.ElementAt(0).Value), 0, , TriState.False)
            'frmScore.lblPlayer2Score.Text = FormatCurrency(Integer.Parse(playerIDList.ElementAt(1).Value), 0, , TriState.False)
            'frmScore.lblPlayer3Score.Text = FormatCurrency(Integer.Parse(playerIDList.ElementAt(2).Value), 0, , TriState.False)
            Dim strSeenCluesSQL As String = "SELECT * FROM SeenClues, Clueboard WHERE GameID = @gameID and SeenClues.ClueID = Clueboard.Id"
            cmdSeenClues = New SqlCommand(strSeenCluesSQL, connClues)
            Dim gameID2Param As SqlParameter = New SqlParameter("@gameID", gameInfo(0))
            cmdSeenClues.Parameters.Add(gameID2Param)
            cmdSeenClues.CommandType = CommandType.Text
            seenCluesrdr = cmdSeenClues.ExecuteReader()
            Do While seenCluesrdr.Read()
                Dim dailyDoubleValue As Boolean = False
                If seenCluesrdr("DailyDouble") = 0 Then
                    dailyDoubleValue = False
                Else
                    dailyDoubleValue = True
                End If
                Dim clueLocation As String
                If IsDBNull(seenCluesrdr("interactiveClueLocation")) = False Then
                    clueLocation = Trim(seenCluesrdr("interactiveClueLocation"))
                Else
                    clueLocation = ""
                End If
                JeopardyController.seenClues.Add(New Clue(seenCluesrdr("ClueId"), Trim(seenCluesrdr("categoryName")), seenCluesrdr("pointValue"), Trim(seenCluesrdr("clue")), ("Cat" & seenCluesrdr("categoryNumber") & seenCluesrdr("pointValue")), dailyDoubleValue, clueLocation))
            Loop
            connClues.Close()
            JeopardyController.packName = gameInfo(1)
            JeopardyController.quickGame = False
            JeopardyController.loadGame = True
            WelcomeScreen.Close()
            IntroScreen.Show()
            loadingGame = True
            Me.Close()
        Else
            MsgBox("No game selected. Please select a game.", vbExclamation, "JEOPARDY!")
        End If
    End Sub

    Private Sub frmLoadGame_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If loadingGame = False Then
            frmNewGame.Show()
        End If
    End Sub
End Class