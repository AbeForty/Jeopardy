Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmNewGame
    Dim numOfPlayers As Integer
    Dim player1 As Boolean = False
    Dim player2 As Boolean = False
    Dim player3 As Boolean = False
    Private Sub frmNewGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPlayer1.Text = "PLAYER 1"
        txtPlayer2.Text = "PLAYER 2"
        txtPlayer3.Text = "PLAYER 3"
        ActiveControl = cboPack
        WelcomeScreen.Close()
        TeamDisplay1.enableClick = True
        TeamDisplay2.enableClick = True
        TeamDisplay3.enableClick = True
        pnlNewGame.Top = (Me.ClientSize.Height / 2) - (pnlNewGame.Height / 2)
        pnlNewGame.Left = (Me.ClientSize.Width / 2) - (pnlNewGame.Width / 2)
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuickStart.Click
        If cboPack.SelectedItem <> Nothing Then
            'For i As Integer = 1 To 3
            If (txtPlayer1.Text = "PLAYER 1" Or String.IsNullOrEmpty(txtPlayer1.Text)) And (txtPlayer2.Text = "PLAYER 2" Or String.IsNullOrEmpty(txtPlayer2.Text)) And (txtPlayer3.Text = "PLAYER 3" Or String.IsNullOrEmpty(txtPlayer3.Text)) Then
                If TeamDisplay1.flpContestants.Controls.Count = 0 And TeamDisplay2.flpContestants.Controls.Count = 0 And TeamDisplay3.flpContestants.Controls.Count = 0 Then
                    MsgBox("You need 3 players or teams to play JEOPARDY! Please enter or select three contestants to continue.", vbExclamation, "JEOPARDY!")
                    Exit Sub
                End If
                For Each player In TeamDisplay1.flpContestants.Controls
                    Dim newPlayer As New Player((CType(player, ContestantDisplay).ContestantID), 1, (CType(player, ContestantDisplay).ContestantName))
                    JeopardyController.Player1List.Add(newPlayer)
                Next
                For Each player In TeamDisplay2.flpContestants.Controls
                    Dim newPlayer As New Player((CType(player, ContestantDisplay).ContestantID), 2, (CType(player, ContestantDisplay).ContestantName))
                    JeopardyController.Player2List.Add(newPlayer)
                Next
                For Each player In TeamDisplay3.flpContestants.Controls
                    Dim newPlayer As New Player((CType(player, ContestantDisplay).ContestantID), 3, (CType(player, ContestantDisplay).ContestantName))
                    JeopardyController.Player3List.Add(newPlayer)
                Next
            Else
                If player1 = False OrElse player2 = False OrElse player3 = False Then
                    MsgBox("You need 3 players or teams to play JEOPARDY! Please enter or select three contestants to continue.", vbExclamation, "JEOPARDY!")
                    Exit Sub
                End If
                Dim newPlayer As New Player(1, txtPlayer1.Text)
                JeopardyController.Player1List.Add(newPlayer)
                Dim newPlayer2 As New Player(2, txtPlayer2.Text)
                JeopardyController.Player2List.Add(newPlayer2)
                Dim newPlayer3 As New Player(3, txtPlayer3.Text)
                JeopardyController.Player3List.Add(newPlayer3)
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            JeopardyController.packName = cboPack.SelectedItem.ToString
            WelcomeScreen.Close()
            IntroScreen.Show()
            Me.Close()
        Else
            MsgBox("No pack selected. Please select a pack.", vbExclamation, "JEOPARDY!")
        End If
    End Sub
    Private Sub getPackNames()
        Try
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "SELECT * FROM Clueboard"
            Dim cmd As SqlCommand
            Dim rdr As SqlDataReader
            connPuzzle.Open()
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()
            Do While rdr.Read()
                If Not cboPack.Items.Contains(Trim(rdr("PackName").ToString)) Then
                    cboPack.Items.Add(Trim(rdr("PackName")).ToString)
                Else
                End If
            Loop
            connPuzzle.Close()
        Catch ex As Exception
            MsgBox("Pack names failed to load.", vbCritical, "JEOPARDY!")
            WelcomeScreen.Show()
            Me.Close()
        End Try
    End Sub
    Private Sub dlgSelectPack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getPackNames()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        JeopardyController.clearTeams()
        WelcomeScreen.Show()
        Me.Close()
        My.Computer.Audio.Play(My.Resources.theme, AudioPlayMode.BackgroundLoop)
    End Sub
    Private Sub chkVirtualHost_CheckedChanged(sender As Object, e As EventArgs) Handles chkVirtualHost.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            JeopardyController.virtualHost = True
        Else
            JeopardyController.virtualHost = False
        End If
    End Sub
    Private Sub btnSaveGame_Click(sender As Object, e As EventArgs) Handles btnSaveGame.Click
        If cboPack.SelectedItem <> Nothing Then
            If TeamDisplay1.flpContestants.Controls.Count = 0 And TeamDisplay2.flpContestants.Controls.Count = 0 And TeamDisplay3.flpContestants.Controls.Count = 0 Then
                MsgBox("You need 3 players or teams to play JEOPARDY! Please enter or select three contestants to continue.", vbExclamation, "JEOPARDY!")
                Exit Sub
            End If
            Dim connClues As SqlConnection
            connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
            Dim strSQL As String = "Insert Into Game output INSERTED.ID VALUES (@packName, @virtualHost, 1, GetDate(), 0)"
            Dim cmd As SqlCommand
            connClues.Open()
            cmd = New SqlCommand(strSQL, connClues)
            Dim packNameParam As SqlParameter = New SqlParameter("@packName", cboPack.SelectedItem)
            Dim virtualHost As Integer = 0
            If chkVirtualHost.Checked = True Then
                virtualHost = 1
            Else
                virtualHost = 0
            End If
            Dim virtualHostParam As SqlParameter = New SqlParameter("@virtualHost", virtualHost)
            cmd.Parameters.Add(packNameParam)
            cmd.Parameters.Add(virtualHostParam)
            cmd.CommandType = CommandType.Text
            JeopardyController.gameID = Integer.Parse(cmd.ExecuteScalar())
            connClues.Close()
            For Each player In TeamDisplay1.flpContestants.Controls
                Dim newPlayer As New Player((CType(player, ContestantDisplay).ContestantID), 1, (CType(player, ContestantDisplay).ContestantName))
                JeopardyController.Player1List.Add(newPlayer)
                createGamePlayers(newPlayer.ID, newPlayer.PlayerNumber)
            Next
            For Each player In TeamDisplay2.flpContestants.Controls
                Dim newPlayer As New Player((CType(player, ContestantDisplay).ContestantID), 2, (CType(player, ContestantDisplay).ContestantName))
                JeopardyController.Player2List.Add(newPlayer)
                createGamePlayers(newPlayer.ID, newPlayer.PlayerNumber)
            Next
            For Each player In TeamDisplay3.flpContestants.Controls
                Dim newPlayer As New Player((CType(player, ContestantDisplay).ContestantID), 3, (CType(player, ContestantDisplay).ContestantName))
                JeopardyController.Player3List.Add(newPlayer)
                createGamePlayers(newPlayer.ID, newPlayer.PlayerNumber)
            Next
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            JeopardyController.packName = cboPack.SelectedItem.ToString
            JeopardyController.quickGame = False
            WelcomeScreen.Close()
            IntroScreen.Show()
            Me.Close()
        Else
            MsgBox("No pack selected. Please select a pack.", vbExclamation, "JEOPARDY!")
        End If
    End Sub
    Private Sub createGamePlayers(contestantID As Integer, playerNumber As Integer)
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
        Dim cmdNewGame As SqlCommand
        connClues.Open()
        Dim strNewGameSQL As String = "Insert Into GamePlayer Values (@playerID, @gameID, 0, @playerNumber)"
        cmdNewGame = New SqlCommand(strNewGameSQL, connClues)
        Dim playerIDParam As SqlParameter = New SqlParameter("@playerID", contestantID)
        Dim gameIDParam As SqlParameter = New SqlParameter("@gameID", JeopardyController.gameID)
        Dim playerNumberParam As SqlParameter = New SqlParameter("@playerNumber", playerNumber)
        cmdNewGame.Parameters.Add(playerIDParam)
        cmdNewGame.Parameters.Add(gameIDParam)
        cmdNewGame.Parameters.Add(playerNumberParam)
        cmdNewGame.CommandType = CommandType.Text
        cmdNewGame.ExecuteNonQuery()
        connClues.Close()
    End Sub
    Private Sub lblLoadGame_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLoadGame.LinkClicked
        Me.Hide()
        frmLoadGame.Show()
    End Sub
    Private Sub txtPlayer1_Click(sender As Object, e As EventArgs) Handles txtPlayer1.Click
        TeamDisplay1.enableClick = False
        TeamDisplay2.enableClick = False
        TeamDisplay3.enableClick = False
        If CType(sender, TextBox).Text = "PLAYER 1" Then
            CType(sender, TextBox).Text = ""
        End If
    End Sub
    Private Sub txtPlayer2_Click(sender As Object, e As EventArgs) Handles txtPlayer2.Click
        TeamDisplay1.enableClick = False
        TeamDisplay2.enableClick = False
        TeamDisplay3.enableClick = False
        If CType(sender, TextBox).Text = "PLAYER 2" Then
            CType(sender, TextBox).Text = ""
        End If
    End Sub
    Private Sub txtPlayer3_Click(sender As Object, e As EventArgs) Handles txtPlayer3.Click
        TeamDisplay1.enableClick = False
        TeamDisplay2.enableClick = False
        TeamDisplay3.enableClick = False
        If CType(sender, TextBox).Text = "PLAYER 3" Then
            CType(sender, TextBox).Text = ""
        End If
    End Sub
    Private Sub txtPlayer1_LostFocus(sender As Object, e As EventArgs) Handles txtPlayer1.LostFocus
        If (CType(sender, TextBox).Text.Length <> 0 And Not CType(sender, TextBox).Text = "PLAYER 1") Then
            player1 = True
            checkNumPlayers()
        Else
            CType(sender, TextBox).Text = "PLAYER 1"
        End If
    End Sub
    Private Sub txtPlayer2_LostFocus(sender As Object, e As EventArgs) Handles txtPlayer2.LostFocus
        If (CType(sender, TextBox).Text.Length <> 0 And Not CType(sender, TextBox).Text = "PLAYER 2") Then
            player2 = True
            checkNumPlayers()
        Else
            CType(sender, TextBox).Text = "PLAYER 2"
        End If
    End Sub
    Private Sub txtPlayer3_LostFocus(sender As Object, e As EventArgs) Handles txtPlayer3.LostFocus
        If (CType(sender, TextBox).Text.Length <> 0 And Not CType(sender, TextBox).Text = "PLAYER 3") Then
            player3 = True
            If player1 = True And player2 = True And player3 = True And cboPack.SelectedItem <> Nothing Then
                btnQuickStart.Enabled = True
            End If
        Else
            CType(sender, TextBox).Text = "PLAYER 3"
        End If
    End Sub
    Private Sub txtPlayer1_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer1.TextChanged
        If CType(sender, TextBox).Text = "PLAYER 1" Then
            player1 = False
            CType(sender, TextBox).ForeColor = Color.Gainsboro
            TeamDisplay1.enableClick = True
            TeamDisplay2.enableClick = True
            TeamDisplay3.enableClick = True
        Else
            player1 = True
            CType(sender, TextBox).ForeColor = Color.Black
            checkNumPlayers()
        End If
    End Sub
    Private Sub txtPlayer2_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer2.TextChanged
        If CType(sender, TextBox).Text = "PLAYER 2" Then
            player2 = False
            CType(sender, TextBox).ForeColor = Color.Gainsboro
            TeamDisplay1.enableClick = True
            TeamDisplay2.enableClick = True
            TeamDisplay3.enableClick = True
        Else
            player2 = True
            CType(sender, TextBox).ForeColor = Color.Black
            checkNumPlayers()
        End If
    End Sub
    Private Sub txtPlayer3_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer3.TextChanged
        If CType(sender, TextBox).Text = "PLAYER 3" Then
            player3 = False
            CType(sender, TextBox).ForeColor = Color.Gainsboro
            TeamDisplay1.enableClick = True
            TeamDisplay2.enableClick = True
            TeamDisplay3.enableClick = True
        Else
            player3 = True
            CType(sender, TextBox).ForeColor = Color.Black
            checkNumPlayers()
        End If
    End Sub
    Public Sub checkNumPlayers()
        If player1 = True And player2 = True And player3 = True And cboPack.SelectedItem <> Nothing Then
            btnQuickStart.Enabled = True
        End If
        If TeamDisplay1.flpContestants.Controls.Count > 0 And TeamDisplay2.flpContestants.Controls.Count > 0 And TeamDisplay3.flpContestants.Controls.Count > 0 Then
            btnQuickStart.Enabled = True
            btnSaveGame.Enabled = True
        End If
    End Sub
    Private Sub cboPack_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPack.SelectedValueChanged
        checkNumPlayers()
    End Sub
End Class