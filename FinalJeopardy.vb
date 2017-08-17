Public Class FinalJeopardy
    Public revealed = False
    Private Sub FinalJeopardy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CategoryTitle1.category
        'AxWindowsMediaPlayer1.Ctlcontrols.stop()
        JeopardyController.loadFinalJeopardy()
        finalJeopardyPic.Image = My.Resources.finalj_570x317
        frmScore.Show()
        frmScore.txtWager1.Show()
        frmScore.txtWager2.Show()
        frmScore.txtWager3.Show()
        frmScore.lblPlayerWagerMessage.Show()
        frmScore.btnGo.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
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
            Timer1.Stop()
            'startTheme()
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If frmScore.txtWager1.Visible = False And frmScore.txtWager2.Visible = False And frmScore.txtWager3.Visible = False Then
            ProgressBar1.Increment(1)
            If ProgressBar1.Value = ProgressBar1.Maximum Then
                CategoryTitle1.Hide()
                'Timer1.Start()
                'frmScore.Hide()
                Timer3.Stop()
                'startTheme()
            End If
        Else
        End If
    End Sub

    Private Sub finalJeopardyPic_Click(sender As Object, e As EventArgs) Handles finalJeopardyPic.Click
        finalJeopardyPic.Hide()
        My.Computer.Audio.Play(My.Resources.rightanswer, AudioPlayMode.Background)
        Timer3.Start()
    End Sub

    Private Sub CategoryTitle1_Click(sender As Object, e As EventArgs) Handles CategoryTitle1.Click
        'If frmScore.Visible = True Then
        My.Computer.Audio.Play(My.Resources.thinkmusic, AudioPlayMode.Background)
        'Timer1.Start()
        CategoryTitle1.Hide()
        frmScore.Hide()
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