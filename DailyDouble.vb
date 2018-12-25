Public Class DailyDouble
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If wmpDailyDouble.playState = WMPLib.WMPPlayState.wmppsStopped Then
            wmpDailyDouble.Hide()
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
        wmpDailyDouble.URL = Application.StartupPath & "\Resources\DailyDoubleSeason35Final.mp4"
        If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
            lblWagerRules.Text = "You can bet up to $1000 if you have $0 in your bank"
        ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
            lblWagerRules.Text = "You can bet up to $2000 if you have $0 in your bank"
        End If
        'CategoryScreen.jSpeechRecog..RecognizeAsyncCancel()
        Timer1.Start()
        Timer2.Start()
        If JeopardyController.currentPlayer = 1 Then
            frmScore.Player1RungIn = True
            frmScore.Player2RungIn = True
            frmScore.Player3RungIn = True
            frmScore.IsDailyDouble = True
            frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer1.Text
            If Integer.Parse(frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")) > 1000 Then
                wagerBox.Maximum = Integer.Parse(frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", ""))
            Else
                If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                    wagerBox.Maximum = 1000
                ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                    wagerBox.Maximum = 2000
                End If
            End If
        ElseIf JeopardyController.currentPlayer = 2 Then
            frmScore.Player1RungIn = True
            frmScore.Player2RungIn = True
            frmScore.Player3RungIn = True
            frmScore.IsDailyDouble = True
            frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text
            If Integer.Parse(frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")) > 1000 Then
                wagerBox.Maximum = Integer.Parse(frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", ""))
            Else
                If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                    wagerBox.Maximum = 1000
                ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                    wagerBox.Maximum = 2000
                End If
            End If
        ElseIf JeopardyController.currentPlayer = 3 Then
            frmScore.Player1RungIn = True
            frmScore.Player2RungIn = True
            frmScore.Player3RungIn = True
            frmScore.IsDailyDouble = True
            frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text
            If Integer.Parse(frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")) > 1000 Then
                wagerBox.Maximum = Integer.Parse(frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", ""))
            Else
                If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                    wagerBox.Maximum = 1000
                ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                    wagerBox.Maximum = 2000
                End If
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