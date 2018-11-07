Public Class ClueDisplayVoice
    Public Sub New(clue As ClueVoice)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        categorylbl.Text = clue.getCategory()
        valuelbl.Text = clue.getValue()
        answerlbl.Text = clue.getAnswer()
        lblClue.Text = clue.getClue()
        clueIDlbl.Text = clue.getclueID()
    End Sub

    'Private Sub clueBox_Click(sender As Object, e As EventArgs)
    '    ClueWindow.Show()
    '    ClueWindow.PictureBox1.Load(imgLabel.Text)
    'End Sub

    Private Sub editBTN_Click(sender As Object, e As EventArgs) Handles editBTN.Click
        Customizer.cboCategory.SelectedItem = categorylbl.Text
        Customizer.numValue.Value = valuelbl.Text
        'Customizer.answerTextBox.Text = answerlbl.Text
        'Customizer.clueLocationTextBox.Text = clueBox.ImageLocation
        Customizer.clueIDTextBox.Text = clueIDlbl.Text
    End Sub
End Class
