Public Class ClueDisplay
    'Dim myClue As Clue
    Public Sub New(clue As Clue)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'RichTextBox1.SelectAll()
        'RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        'myClue = clue
        categorylbl.Text = clue.category
        valuelbl.Text = clue.value
        'answerlbl.Text = clue.answer
        lblCBID.Text = clue.cbID
        imgLabel.Text = clue.interactiveClueLocation
        cboQuestion.DataSource = clue.answer
        formatLabel2.Text = clue.clue
        clueIDlbl.Text = clue.clueID
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
        Customizer.cboQuestion.DataSource = cboQuestion.Items
        Customizer.txtInteractiveClue.Text = imgLabel.Text
        Customizer.txtClue.Text = formatLabel2.Text
        Customizer.clueIDTextBox.Text = clueIDlbl.Text
    End Sub
End Class
