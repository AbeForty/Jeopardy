Public Class frmScore
    Public Player1RungIn As Boolean = False
    Public Player2RungIn As Boolean = False
    Public Player3RungIn As Boolean = False
    Public IsDailyDouble As Boolean = False
    Dim IsPlayer1Override As Boolean = False
    Dim IsPlayer2Override As Boolean = False
    Dim IsPlayer3Override As Boolean = False
    Private Sub frmScore_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub frmScore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        numPlayer1.Font = New Font("Open Sans", 24, FontStyle.Bold)
        numPlayer2.Font = New Font("Open Sans", 24, FontStyle.Bold)
        numPlayer3.Font = New Font("Open Sans", 24, FontStyle.Bold)
        lblPlayer1Score.Font = New Font("Open Sans", 24, FontStyle.Bold)
        lblPlayer2Score.Font = New Font("Open Sans", 24, FontStyle.Bold)
        lblPlayer3Score.Font = New Font("Open Sans", 24, FontStyle.Bold)
        tmrCurrentValue.Start()
        Me.Dock = DockStyle.Top
        txtCurrentPlayer.Focus()
        'btnDoubleJeopardy.Hide()
        'btnFinalJeopardy.Hide()
    End Sub
    Private Sub tmrCurrentValue_Tick(sender As Object, e As EventArgs) Handles tmrCurrentValue.Tick
        lblCurrentValue.Text = JeopardyController.currentPointValue
    End Sub
    Private Sub lblPlayer1_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer1.DoubleClick
        If IsPlayer1Override = False Then
            numPlayer1.Show()
            IsPlayer1Override = True
        ElseIf IsPlayer1Override = True Then
            lblPlayer1Score.Text = Integer.Parse(lblPlayer1Score.Text) + numPlayer1.Value
            numPlayer1.Hide()
            IsPlayer1Override = False
        End If
    End Sub

    Private Sub lblPlayer2_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer2.DoubleClick
        If IsPlayer2Override = False Then
            numPlayer2.Show()
            IsPlayer2Override = True
        ElseIf IsPlayer2Override = True Then
            lblPlayer2Score.Text = Integer.Parse(lblPlayer2Score.Text) + numPlayer2.Value
            numPlayer2.Hide()
            IsPlayer2Override = False
        End If
    End Sub

    Private Sub lblPlayer3_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer3.DoubleClick
        If IsPlayer3Override = False Then
            numPlayer3.Show()
            IsPlayer3Override = True
        ElseIf IsPlayer3Override = True Then
            lblPlayer3Score.Text = Integer.Parse(lblPlayer3Score.Text) + numPlayer3.Value
            numPlayer3.Hide()
            IsPlayer3Override = False
        End If
    End Sub
    Private Sub finalJeopardyBTN_Click(sender As Object, e As EventArgs) Handles btnFinalJeopardy.Click
        FinalJeopardy.Show()
        categoryScreen.Close()
    End Sub
    Private Sub quitBTN_Click(sender As Object, e As EventArgs) Handles quitBTN.Click
        Dim result As Integer = MessageBox.Show("Do you want to keep your current game save progress?", "Jeopardy!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            categoryScreen.rtbSeenClues.Clear()
            categoryScreen.rtbPointValues.Clear()
            categoryScreen.rtbSeenClues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
            categoryScreen.rtbPointValues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
            Application.Exit()
        ElseIf result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        JeopardyController.setAnswerValue(True)
    End Sub
    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        JeopardyController.setAnswerValue(False)
        If IsDailyDouble = False Then
        ElseIf IsDailyDouble = True Then
            JeopardyController.ifNoRingIn()
        End If
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        If FinalJeopardy.Visible = False Then
            lblPlayerWagerMessage.Hide()
            categoryScreen.Timer7.Start()
            categoryScreen.timeOutTimer.Start()
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\rightanswer.wav")
            btnGo.Hide()
        Else
            If FinalJeopardy.revealed = False Then
                FinalJeopardy.startTheme()
                FinalJeopardy.Timer1.Start()
                Me.Hide()
            Else
                txtCurrentPlayer.Text = "Player 1"
                btnYes.Show()
                btnNo.Show()
                JeopardyController.currentPointValue = CInt(txtWager1.Text)
            End If
        End If
    End Sub

    Private Sub btnDoubleJeopardy_Click(sender As Object, e As EventArgs) Handles btnDoubleJeopardy.Click
        categoryScreen.Close()
        btnDoubleJeopardy.Hide()
        Me.Hide()
    End Sub

    Private Sub txtWager1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWager1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Try
                Integer.Parse(txtWager1.Text)
            Catch ex As Exception
                MsgBox("Please enter only digits.", vbExclamation, "Jeopardy!")
                Exit Sub
            End Try
            If Integer.Parse(txtWager1.Text) < CInt(lblPlayer1Score.Text) Then
                txtWager1.Hide()
            Else
                MsgBox("Please enter a wager less than or equal to your total.", vbExclamation, "Jeopardy!")
            End If
        End If
    End Sub

    Private Sub txtWager2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWager2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Try
                Integer.Parse(txtWager2.Text)
            Catch ex As Exception
                MsgBox("Please enter only digits.", vbExclamation, "Jeopardy!")
                Exit Sub
            End Try
            If Integer.Parse(txtWager2.Text) < CInt(lblPlayer2Score.Text) Then
                txtWager2.Hide()
            Else
                MsgBox("Please enter a wager less than or equal to your total.", vbExclamation, "Jeopardy!")
            End If
        End If
    End Sub

    Private Sub txtWager3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWager3.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Try
                Integer.Parse(txtWager3.Text)
            Catch ex As Exception
                MsgBox("Please enter only digits.", vbExclamation, "Jeopardy!")
                Exit Sub
            End Try
            If Integer.Parse(txtWager3.Text) < CInt(lblPlayer3Score.Text) Then
                txtWager3.Hide()
            Else
                MsgBox("Please enter a wager less than or equal to your total.", vbExclamation, "Jeopardy!")
            End If
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        frmHelp.ShowDialog()
    End Sub
End Class