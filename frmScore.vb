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
        'numPlayer1.Font = New Font("Open Sans", 24, FontStyle.Bold)
        'numPlayer2.Font = New Font("Open Sans", 24, FontStyle.Bold)
        'numPlayer3.Font = New Font("Open Sans", 24, FontStyle.Bold)
        'lblPlayer1Score.Font = New Font("Open Sans", 24, FontStyle.Bold)
        'lblPlayer2Score.Font = New Font("Open Sans", 24, FontStyle.Bold)
        'lblPlayer3Score.Font = New Font("Open Sans", 24, FontStyle.Bold)
        lblPlayer1.Text = JeopardyController.Player1List(0).PlayerName
        lblPlayer2.Text = JeopardyController.Player2List(0).PlayerName
        lblPlayer3.Text = JeopardyController.Player3List(0).PlayerName
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
            lblPlayer1Score.Text = FormatCurrency(Integer.Parse(lblPlayer1Score.Text.Replace("$", "").Replace(",", "")) + numPlayer1.Value, 0, , TriState.False)
            numPlayer1.Hide()
            IsPlayer1Override = False
        End If
    End Sub

    Private Sub lblPlayer2_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer2.DoubleClick
        If IsPlayer2Override = False Then
            numPlayer2.Show()
            IsPlayer2Override = True
        ElseIf IsPlayer2Override = True Then
            lblPlayer2Score.Text = FormatCurrency(Integer.Parse(lblPlayer2Score.Text.Replace("$", "").Replace(",", "")) + numPlayer2.Value, 0, , TriState.False)
            numPlayer2.Hide()
            IsPlayer2Override = False
        End If
    End Sub

    Private Sub lblPlayer3_DoubleClick(sender As Object, e As EventArgs) Handles lblPlayer3.DoubleClick
        If IsPlayer3Override = False Then
            numPlayer3.Show()
            IsPlayer3Override = True
        ElseIf IsPlayer3Override = True Then
            lblPlayer3Score.Text = FormatCurrency(Integer.Parse(lblPlayer3Score.Text.Replace("$", "").Replace(",", "")) + numPlayer3.Value, 0, , TriState.False)
            numPlayer3.Hide()
            IsPlayer3Override = False
        End If
    End Sub
    Private Sub finalJeopardyBTN_Click(sender As Object, e As EventArgs) Handles btnFinalJeopardy.Click
        JeopardyController.roundNumber = 3
        If JeopardyController.quickGame = False Then
            JeopardyController.saveGame(True)
        End If
        FinalJeopardy.Show()
        categoryScreen.Close()
        tmrCheckWager.Start()
    End Sub
    Private Sub quitBTN_Click(sender As Object, e As EventArgs) Handles quitBTN.Click
        'Dim result As Integer = MessageBox.Show("Do you want to keep your current game save progress?", "Jeopardy!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If result = DialogResult.No Then
        '    Application.Exit()
        'ElseIf result = DialogResult.Yes Then
        '    categoryScreen.rtbSeenClues.Clear()
        '    categoryScreen.rtbPointValues.Clear()
        '    categoryScreen.rtbSeenClues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        '    categoryScreen.rtbPointValues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
        '    Application.Exit()
        'End If
        Try
            Application.Exit()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        JeopardyController.setAnswerValue(True)
        btnClear.Hide()
        If JeopardyController.quickGame = False Then
            JeopardyController.cleared = True
            JeopardyController.saveGame(True)
        End If
        JeopardyController.cleared = False
        JeopardyController.cbID = Nothing
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
            categoryScreen.tmrRingIn.Start()
            categoryScreen.timeOutTimer.Start()
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\rightanswer.wav")
            btnClear.Show()
            btnGo.Hide()
            Dim clueType = categoryScreen.clue.clueType
            If clueType = JeopardyController.clueType.Audio Then
                'JeopardyController.categoryScreen.clue.wmpClue.Show()
                categoryScreen.clue.wmpClue.Ctlcontrols.play()
            End If
        Else
            If FinalJeopardy.revealed = False Then
                FinalJeopardy.startTheme()
                FinalJeopardy.tmrThink.Start()
                lblPlayerWagerMessage.Hide()
                FinalJeopardy.CategoryTitle1.Hide()
                Me.Hide()
            Else
                If JeopardyController.finalCheckStarted = False Then
                    If JeopardyController.determineIfNegative(1) = False Then
                        txtCurrentPlayer.Text = lblPlayer1.Text
                        btnYes.Show()
                        btnNo.Show()
                        JeopardyController.currentPointValue = CInt(txtWager1.Text)
                        JeopardyController.finalCheckStarted = True
                    ElseIf JeopardyController.determineIfNegative(2) = False Then
                        txtCurrentPlayer.Text = lblPlayer2.Text
                        btnYes.Show()
                        btnNo.Show()
                        JeopardyController.currentPointValue = CInt(txtWager2.Text)
                        JeopardyController.finalCheckStarted = True
                    ElseIf JeopardyController.determineIfNegative(3) = False Then
                        txtCurrentPlayer.Text = lblPlayer3.Text
                        btnYes.Show()
                        btnNo.Show()
                        JeopardyController.currentPointValue = CInt(txtWager3.Text)
                        JeopardyController.finalCheckStarted = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnDoubleJeopardy_Click(sender As Object, e As EventArgs) Handles btnDoubleJeopardy.Click
        JeopardyController.roundNumber = 2
        JeopardyController.currentPlayer = JeopardyController.determineLastPlace()
        JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy
        btnDoubleJeopardy.Hide()
        JeopardyController.seenClues.Clear()
        categoryScreen.CategoryDisplay1.displayFinished = False
        categoryScreen.CategoryDisplay1.Show()
        JeopardyController.loadClues(JeopardyController.packName, JeopardyController.roundEnum)
        JeopardyController.initializeGameManual(JeopardyController.roundType.DoubleJeopardy)
        catChooser.finished = False
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
            If Integer.Parse(txtWager1.Text) <= CInt(lblPlayer1Score.Text) Then
                txtWager1.Hide()
            Else
                MsgBox("Please enter a wager less than or equal to your total.", vbExclamation, "JEOPARDY!")
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
            If Integer.Parse(txtWager2.Text) <= CInt(lblPlayer2Score.Text) Then
                txtWager2.Hide()
            Else
                MsgBox("Please enter a wager less than or equal to your total.", vbExclamation, "JEOPARDY!")
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
            If Integer.Parse(txtWager3.Text) <= CInt(lblPlayer3Score.Text) Then
                txtWager3.Hide()
            Else
                MsgBox("Please enter a wager less than or equal to your total.", vbExclamation, "JEOPARDY!")
            End If
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        frmHelp.ShowDialog()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        categoryScreen.clue.Hide()
        My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
        CType(sender, Button).Hide()
        If JeopardyController.quickGame = False Then
            JeopardyController.saveGame(False)
        End If
        JeopardyController.cbID = Nothing
    End Sub

    Private Sub lblPlayerScore_TextChanged(sender As Object, e As EventArgs) Handles lblPlayer1Score.TextChanged, lblPlayer2Score.TextChanged, lblPlayer3Score.TextChanged
        If CType(sender, Label).Text.Contains("-") Then
            CType(sender, Label).ForeColor = Color.Red
        Else
            CType(sender, Label).ForeColor = Color.White
        End If
    End Sub

    Private Sub tmrCheckWager_Tick(sender As Object, e As EventArgs) Handles tmrCheckWager.Tick
        If txtWager1.Visible = False And txtWager2.Visible = False And txtWager3.Visible = False Then
            lblPlayerWagerMessage.Hide()
            FinalJeopardy.CategoryTitle1.Hide()
            btnGo.Show()
            tmrCheckWager.Stop()
        End If
    End Sub
End Class