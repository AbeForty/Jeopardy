Public Class ClueDisplay
    'Dim myClue As Clue
    Public Sub New(clue As Clue)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'RichTextBox1.SelectAll()
        'RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        'myClue = clue
        categorylbl.Text = clue.getCategory()
        valuelbl.Text = clue.getValue()
        'answerlbl.Text = clue.getAnswer()
        formatLabel2.Text = clue.getClue()
        clueIDlbl.Text = clue.getclueID()
    End Sub

    'Private Sub clueBox_Click(sender As Object, e As EventArgs)
    '    ClueWindow.Show()
    '    ClueWindow.PictureBox1.Load(imgLabel.Text)
    'End Sub
    Private Sub formatSelection(clue As String)
        'myClue.getClue()

        'For Each word As String In 
        '        Next
    End Sub
    Private Sub editBTN_Click(sender As Object, e As EventArgs) Handles editBTN.Click
        Customizer.cboCategory.SelectedItem = categorylbl.Text
        Customizer.numValue.Value = valuelbl.Text
        'Customizer.answerTextBox.Text = answerlbl.Text
        'Customizer.clueLocationTextBox.Text = clueBox.ImageLocation
        Customizer.txtClue.Text = formatLabel2.Text
        Customizer.clueIDTextBox.Text = clueIDlbl.Text
    End Sub
End Class
