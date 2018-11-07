Public Class HostToolbox
    Private Sub editScoreBTN_Click(sender As Object, e As EventArgs) Handles editScoreBTN.Click
        ScoreForm.BringToFront()
    End Sub

    Private Sub finalJeopardyBTN_Click(sender As Object, e As EventArgs) Handles finalJeopardyBTN.Click
        FinalJeopardy.Show()
        CategoryScreen.Close()
    End Sub

    Private Sub quitBTN_Click(sender As Object, e As EventArgs) Handles quitBTN.Click
        Application.Exit()
    End Sub
End Class