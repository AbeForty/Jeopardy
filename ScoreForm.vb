Public Class ScoreForm
    Private Declare Function BlockInput Lib "user32" Alias "BlockInput" (ByVal fBlock As Integer) As Integer
    Private Declare Function ShowCursor Lib "user32" (ByVal lShow As Long) As Long
    Public Player1RungIn As Boolean = False
    Public Player2RungIn As Boolean = False
    Public Player3RungIn As Boolean = False
    Public IsDailyDouble As Boolean = False
    Dim IsPlayer1Override As Boolean = False
    Dim IsPlayer2Override As Boolean = False
    Dim IsPlayer3Override As Boolean = False
    Private Sub ScoreForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericUpDown1.Font = New Font("Open Sans", 24, FontStyle.Bold)
        NumericUpDown2.Font = New Font("Open Sans", 24, FontStyle.Bold)
        NumericUpDown3.Font = New Font("Open Sans", 24, FontStyle.Bold)
        Timer1.Start()
        Timer4.Start()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Y) Then
            Dim i As Integer
            i += 1
            MsgBox(i)
        End If
    End Sub


    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    If TextBox1.Text = "" Then
    '        If My.Computer.Keyboard.CtrlKeyDown = True Then
    '            Player1RungIn = True
    '            If Player1RungIn = True Then
    '                'Timer2.Start()
    '                Label4.BackColor = Color.FromArgb(175, 233, 253)
    '                PictureBox1.BackColor = Color.FromArgb(175, 233, 253)
    '                Label5.BackColor = Color.FromArgb(0, 45, 192)
    '                PictureBox2.BackColor = Color.FromArgb(0, 45, 192)
    '                Label6.BackColor = Color.FromArgb(0, 45, 192)
    '                PictureBox3.BackColor = Color.FromArgb(0, 45, 192)
    '                TextBox1.Text = "Player 1"
    '                CategoryScreen.jSpeechRecog..SetInputToDefaultAudioDevice()
    '                CategoryScreen.jSpeechRecog..Recognize()
    '                ProgressBar1.Increment(1)
    '                If ProgressBar1.Value = ProgressBar1.Maximum Then

    '                End If
    '            End If
    '        ElseIf My.Computer.Keyboard.AltKeyDown = True Then
    '            Player2RungIn = True
    '            If Player2RungIn = True Then
    '                'Timer2.Start()
    '                Label5.BackColor = Color.FromArgb(175, 233, 253)
    '                PictureBox2.BackColor = Color.FromArgb(175, 233, 253)
    '                Label4.BackColor = Color.FromArgb(0, 45, 192)
    '                PictureBox1.BackColor = Color.FromArgb(0, 45, 192)
    '                Label6.BackColor = Color.FromArgb(0, 45, 192)
    '                PictureBox3.BackColor = Color.FromArgb(0, 45, 192)
    '                TextBox1.Text = "Player 2"
    '                CategoryScreen.jSpeechRecog..SetInputToDefaultAudioDevice()
    '                CategoryScreen.jSpeechRecog..Recognize()
    '                ProgressBar1.Increment(1)
    '                If ProgressBar1.Value = ProgressBar1.Maximum Then

    '                End If
    '            End If
    '        ElseIf My.Computer.Keyboard.ShiftKeyDown = True Then
    '            Player3RungIn = True
    '            If Player3RungIn = True Then
    '                'Timer2.Start()
    '                Label6.BackColor = Color.FromArgb(175, 233, 253)
    '                PictureBox3.BackColor = Color.FromArgb(175, 233, 253)
    '                Label5.BackColor = Color.FromArgb(0, 45, 192)
    '                PictureBox2.BackColor = Color.FromArgb(0, 45, 192)
    '                Label4.BackColor = Color.FromArgb(0, 45, 192)
    '                PictureBox1.BackColor = Color.FromArgb(0, 45, 192)
    '                TextBox1.Text = "Player 3"
    '                CategoryScreen.jSpeechRecog..SetInputToDefaultAudioDevice()
    '                CategoryScreen.jSpeechRecog..Recognize()
    '                ProgressBar1.Increment(1)
    '                If ProgressBar1.Value = ProgressBar1.Maximum Then

    '                End If
    '            End If
    '        End If
    '    End If
    '    If TextBox1.Text = "" And Player1RungIn = True And Player2RungIn = True And Player3RungIn = True And Not IsDailyDouble = True Then
    '        Player1RungIn = False
    '        Player2RungIn = False
    '        Player3RungIn = False
    '        CategoryScreen.CurrentPointValue = 0
    '    ElseIf ProgressBar2.Value = ProgressBar2.Maximum And IsDailyDouble = True Then
    '        Player1RungIn = False
    '        Player2RungIn = False
    '        Player3RungIn = False
    '    End If
    'End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        JeopardyController.setAnswerValue(True)
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        JeopardyController.setAnswerValue(False)
    End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    ProgressBar2.PerformStep()
    '    If ProgressBar2.Value = ProgressBar2.Maximum Then
    '        If TextBox1.Text = "Player 1" Then
    '            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
    '            NumericUpDown1.Value = NumericUpDown1.Value - JeopardyController.currentPointValue
    '            Label6.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox3.BackColor = Color.FromArgb(0, 45, 192)
    '            Label5.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox2.BackColor = Color.FromArgb(0, 45, 192)
    '            Label4.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox1.BackColor = Color.FromArgb(0, 45, 192)
    '            TextBox1.Clear()
    '            ProgressBar2.Value = 0
    '            ProgressBar1.Value = 0
    '            'Timer3.Start()
    '            Timer2.Stop()
    '        ElseIf TextBox1.Text = "Player 2" Then
    '            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
    '            NumericUpDown2.Value = NumericUpDown2.Value - JeopardyController.currentPointValue
    '            Label6.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox3.BackColor = Color.FromArgb(0, 45, 192)
    '            Label5.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox2.BackColor = Color.FromArgb(0, 45, 192)
    '            Label4.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox1.BackColor = Color.FromArgb(0, 45, 192)
    '            TextBox1.Clear()
    '            ProgressBar2.Value = 0
    '            ProgressBar1.Value = 0
    '            'Timer3.Start()
    '            Timer2.Stop()
    '        ElseIf TextBox1.Text = "Player 3" Then
    '            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
    '            NumericUpDown3.Value = NumericUpDown3.Value - JeopardyController.currentPointValue
    '            Label6.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox3.BackColor = Color.FromArgb(0, 45, 192)
    '            Label5.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox2.BackColor = Color.FromArgb(0, 45, 192)
    '            Label4.BackColor = Color.FromArgb(0, 45, 192)
    '            PictureBox1.BackColor = Color.FromArgb(0, 45, 192)
    '            TextBox1.Clear()
    '            ProgressBar2.Value = 0
    '            ProgressBar1.Value = 0
    '            'Timer3.Start()
    '            Timer2.Stop()
    '        End If
    '    End If
    'End Sub

    'Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
    '    ProgressBar1.Increment(1)
    '    If ProgressBar1.Value = ProgressBar1.Maximum Then
    '        My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
    '        Label6.BackColor = Color.FromArgb(0, 45, 192)
    '        PictureBox3.BackColor = Color.FromArgb(0, 45, 192)
    '        Label5.BackColor = Color.FromArgb(0, 45, 192)
    '        PictureBox2.BackColor = Color.FromArgb(0, 45, 192)
    '        Label4.BackColor = Color.FromArgb(0, 45, 192)
    '        PictureBox1.BackColor = Color.FromArgb(0, 45, 192)
    '        TextBox1.Clear()
    '        ProgressBar1.Value = 0
    '        ProgressBar2.Value = 0
    '        Player1RungIn = False
    '        Player2RungIn = False
    '        Player3RungIn = False
    '        CategoryScreen.CurrentPointValue = False
    '        Timer3.Stop()
    '    End If
    'End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Label3.Text = JeopardyController.currentPointValue
    End Sub

    Private Sub Label4_DoubleClick(sender As Object, e As EventArgs) Handles Label4.DoubleClick
        If IsPlayer1Override = False Then
            Button3.Show()
            NumericUpDown4.Show()
            IsPlayer1Override = True
        ElseIf IsPlayer1Override = True Then
            Button3.Hide()
            NumericUpDown4.Hide()
            IsPlayer1Override = False
        End If
    End Sub

    Private Sub Label5_DoubleClick(sender As Object, e As EventArgs) Handles Label5.DoubleClick
        If IsPlayer2Override = False Then
            Button4.Show()
            NumericUpDown5.Show()
            IsPlayer2Override = True
        ElseIf IsPlayer2Override = True Then
            Button4.Hide()
            NumericUpDown5.Hide()
            IsPlayer2Override = False
        End If
    End Sub

    Private Sub Label6_DoubleClick(sender As Object, e As EventArgs) Handles Label6.DoubleClick
        If IsPlayer3Override = False Then
            Button5.Show()
            NumericUpDown6.Show()
            IsPlayer3Override = True
        ElseIf IsPlayer3Override = True Then
            Button5.Hide()
            NumericUpDown6.Hide()
            IsPlayer3Override = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NumericUpDown1.Value = NumericUpDown1.Value + NumericUpDown4.Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NumericUpDown2.Value = NumericUpDown2.Value + NumericUpDown5.Value
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        NumericUpDown3.Value = NumericUpDown3.Value + NumericUpDown6.Value
    End Sub

    Private Sub Label3_DoubleClick(sender As Object, e As EventArgs) Handles Label3.DoubleClick
        JeopardyController.currentPointValue = 0
    End Sub
End Class