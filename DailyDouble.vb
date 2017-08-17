Public Class DailyDouble
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            AxWindowsMediaPlayer1.Hide()
        End If
    End Sub

    Private Sub wagerBox_Click(sender As Object, e As EventArgs) Handles wagerBox.Click
        JeopardyController.currentPointValue = wagerBox.Value
        If wagerBox.Value = wagerBox.Maximum Then
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\wagererror.wav")
        End If
    End Sub
    Private Sub wagerBox_TextChanged(sender As Object, e As EventArgs) Handles wagerBox.TextChanged
        JeopardyController.currentPointValue = wagerBox.Value
        If wagerBox.Value = wagerBox.Maximum Then
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\wagererror.wav")
        End If
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        JeopardyController.currentPointValue = wagerBox.Value
        JeopardyController.jSpeechRecog.QuestionMode = True
        categoryScreen.clue.Show()
        frmScore.btnYes.Show()
        frmScore.btnNo.Show()
        'CategoryScreen.Timer7.Start()
        Me.Close()
    End Sub

    Private Sub DailyDouble_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CategoryScreen.jSpeechRecog..RecognizeAsyncCancel()
        Timer1.Start()
        Timer2.Start()
        If JeopardyController.currentPlayer = 1 Then
            frmScore.Player1RungIn = True
            frmScore.Player2RungIn = True
            frmScore.Player3RungIn = True
            frmScore.IsDailyDouble = True
            frmScore.txtCurrentPlayer.Text = "Player 1"
            If Integer.Parse(frmScore.lblPlayer1Score.Text) > 1000 Then
                wagerBox.Maximum = Integer.Parse(frmScore.lblPlayer1Score.Text)
            Else
                wagerBox.Maximum = 1000
            End If
        ElseIf JeopardyController.currentPlayer = 2 Then
            frmScore.Player1RungIn = True
            frmScore.Player2RungIn = True
            frmScore.Player3RungIn = True
            frmScore.IsDailyDouble = True
            frmScore.txtCurrentPlayer.Text = "Player 2"
            If Integer.Parse(frmScore.lblPlayer2Score.Text) > 1000 Then
                wagerBox.Maximum = Integer.Parse(frmScore.lblPlayer1Score.Text)
            Else
                wagerBox.Maximum = 1000
            End If
        ElseIf JeopardyController.currentPlayer = 3 Then
            frmScore.Player1RungIn = True
            frmScore.Player2RungIn = True
            frmScore.Player3RungIn = True
            frmScore.IsDailyDouble = True
            frmScore.txtCurrentPlayer.Text = "Player 3"
            If Integer.Parse(frmScore.lblPlayer3Score.Text) > 1000 Then
                wagerBox.Maximum = Integer.Parse(frmScore.lblPlayer3Score.Text)
            Else
                wagerBox.Maximum = 1000
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'CategoryScreen.jSpeechRecog..RecognizeAsyncCancel()
    End Sub

    Private Sub btnTrueDailyDouble_Click(sender As Object, e As EventArgs) Handles btnTrueDailyDouble.Click
        wagerBox.Value = wagerBox.Maximum
    End Sub
End Class