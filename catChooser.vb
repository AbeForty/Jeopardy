Public Class catChooser
    Public finished As Boolean = False
    Private Sub catChooser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.categorychooser, AudioPlayMode.Background)
        'catChooserPlayer.settings.volume = 100
        'catChooserPlayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\categorychooser.wav"
        timeStart = DateTime.Now.Second
        tmrCheckIfDone.Start()
    End Sub
    Dim timeStart As Integer
    Private Sub tmrCheckIfDone_Tick(sender As Object, e As EventArgs) Handles tmrCheckIfDone.Tick
        If DateTime.Now.Second = JeopardyController.convertTimeCatChooserAudio(timeStart) Then
            finished = True
            tmrCheckIfDone.Stop()
        Else
            finished = False
        End If
    End Sub
End Class