Public Class VariableTesting
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = "Player 1: " + ScoreForm.Player1RungIn.ToString
        Label2.Text = "Player 2: " + ScoreForm.Player2RungIn.ToString
        Label3.Text = "Player 3: " + ScoreForm.Player3RungIn.ToString
        Label4.Text = "Daily Double: " + ScoreForm.IsDailyDouble.ToString
        Label5.Text = "Current Player: " + ScoreForm.TextBox1.Text
        Label6.Text = "Current Point Value: " + JeopardyController.currentPointValue.ToString
        Label7.Text = "Answer: " + JeopardyController.currentAnswer
        Label8.Text = "Current Second: " + JeopardyController.currentSecond.ToString
        Label9.Text = "Right Now Second: " + DateTime.Now.Second.ToString
        Label10.Text = "Clue ID: " + JeopardyController.getClueID
    End Sub

    Private Sub VariableTesting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            frmScore.txtRecognition.Show()
        ElseIf CheckBox1.Checked = False Then
            frmScore.txtRecognition.Hide()
        End If
    End Sub
End Class