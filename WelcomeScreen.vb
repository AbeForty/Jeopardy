Public Class WelcomeScreen
    Private Sub playBTN_Click(sender As Object, e As EventArgs) Handles playBTN.Click
        'If RichTextBox2.Text <> "" Then
        '    Dim result As Integer = MessageBox.Show("Do you want to keep your current game save progress?", "Jeopardy!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If result = DialogResult.No Then
        '        dlgSelectPack.Show()
        '        My.Computer.Audio.Stop()
        '        Me.Close()
        '    ElseIf result = DialogResult.Yes Then
        '        My.Computer.Audio.Stop()
        '        catChooser.Show()
        '        categoryScreen.Show()
        '        JeopardyController.bypassCategoryReveal = True
        '        If RichTextBox2.Text <> "" Then
        '            Dim fileReader As System.IO.StreamReader
        '            fileReader = My.Computer.FileSystem.OpenTextFileReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt")
        '            frmScore.lblPlayer1Score.Text = fileReader.ReadLine()
        '            frmScore.lblPlayer2Score.Text = fileReader.ReadLine()
        '            frmScore.lblPlayer3Score.Text = fileReader.ReadLine()
        '            fileReader.Close()
        '        Else
        '            frmScore.lblPlayer1Score.Text = 0
        '            frmScore.lblPlayer2Score.Text = 0
        '            frmScore.lblPlayer3Score.Text = 0
        '        End If
        '        Me.Close()
        '    End If
        'Else
        dlgSelectPack.Show()
        My.Computer.Audio.Stop()
        'Me.Close()
        'End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles settingsBTN.Click
        SettingsScreen.Show()
    End Sub

    Private Sub WelcomeScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        RichTextBox2.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
        My.Computer.Audio.Play(My.Resources.theme, AudioPlayMode.BackgroundLoop)
        If My.Settings.firstRun = True Then
            frmHelp.ShowDialog()
            My.Settings.firstRun = False
        Else

        End If
    End Sub

    Private Sub customizeBTN_Click(sender As Object, e As EventArgs) Handles customizeBTN.Click
        Customizer.Show()
        My.Computer.Audio.Stop()
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        frmHelp.ShowDialog()
    End Sub
End Class