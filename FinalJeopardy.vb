Public Class FinalJeopardy
    Public revealed = False
    Private Sub FinalJeopardy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CategoryTitle1.category
        'AxWindowsMediaPlayer1.Ctlcontrols.stop()
        JeopardyController.loadFinalJeopardy()
        finalJeopardyPic.Image = My.Resources.jeopardy_ubicom_screen_03_final_jeopardy_full_size_1280x720_304779
        frmScore.Show()
        frmScore.lblPlayerWagerMessage.Show()
        frmScore.btnGo.Hide()
    End Sub

    Private Sub tmrThink_Tick(sender As Object, e As EventArgs) Handles tmrThink.Tick
        'If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
        '    finalJeopardyPic.Hide()
        '    frmScore.Show()
        'End If
        ProgressBar1.Maximum = 300
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            frmScore.Show()
            'CategoryTitle1.Hide()
            'Timer1.Start()
            'frmScore.Hide()
            tmrThink.Stop()
            'startTheme()
        End If
    End Sub

    Private Sub tmrRevealCategory_Tick(sender As Object, e As EventArgs) Handles tmrRevealCategory.Tick
        If frmScore.txtWager1.Visible = False And frmScore.txtWager2.Visible = False And frmScore.txtWager3.Visible = False Then
            frmScore.lblPlayerWagerMessage.Hide()
            ProgressBar1.Increment(1)
            If ProgressBar1.Value = ProgressBar1.Maximum Then
                CategoryTitle1.Hide()
                'Timer1.Start()
                'frmScore.Hide()
                tmrRevealCategory.Stop()
                'startTheme()
            End If
        Else
        End If
    End Sub

    Private Sub finalJeopardyPic_Click(sender As Object, e As EventArgs) Handles finalJeopardyPic.Click
        finalJeopardyPic.Hide()
        CategoryTitle1.Show()
        My.Computer.Audio.Play(My.Resources.rightanswer, AudioPlayMode.Background)
        JeopardyController.determineIfNegative()
        'tmrRevealCategory.Start()
    End Sub

    Private Sub CategoryTitle1_Click(sender As Object, e As EventArgs) Handles CategoryTitle1.Click
        'If frmScore.Visible = True Then
        'My.Computer.Audio.Play(My.Resources.thinkmusic, AudioPlayMode.Background)
        ''Timer1.Start()
        'CategoryTitle1.Hide()
        'frmScore.Hide()
        'ElseIf frmScore.Visible = False Then
        '    frmScore.Show()
        'End If
    End Sub
    Public Sub startTheme()
        revealed = True
        My.Computer.Audio.Play(My.Resources.thinkmusic, AudioPlayMode.Background)
    End Sub

    Private Sub ClueDisplayScreen1_Click(sender As Object, e As EventArgs) Handles ClueDisplayScreen1.Click
        frmScore.Show()
    End Sub
End Class