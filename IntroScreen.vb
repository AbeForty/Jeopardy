Public Class IntroScreen
    Private Sub IntroScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = JeopardyController.finalURL & "\Resources\JeopardySeason35Intro.mp4"
        AxWindowsMediaPlayer1.uiMode = "none"
        Timer1.Start()
        AxWindowsMediaPlayer1.settings.volume = 100
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
            catChooser.Show()
            categoryScreen.Show()
            Me.Close()
        End If
    End Sub
End Class