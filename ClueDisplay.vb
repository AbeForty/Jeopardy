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
        lblRoundNumber.Text = clue.round
        lblDailyDouble.Text = clue.dailyDouble.ToString()
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
        Customizer.cboQuestion.Text = ""
        Customizer.cboNewAnswers.Items.Clear()
        Customizer.cboQuestion.Items.Clear()
        Customizer.cboCategory.SelectedItem = categorylbl.Text
        Customizer.numValue.Value = valuelbl.Text
        'Customizer.cboQuestion.DataSource = cboQuestion.Items
        For Each item In cboQuestion.Items
            Customizer.cboQuestion.Items.Add(item)
        Next
        Customizer.txtInteractiveClue.Text = imgLabel.Text
        Customizer.txtClue.Text = formatLabel2.Text
        Customizer.clueIDTextBox.Text = clueIDlbl.Text
        Customizer.cbID = lblCBID.Text
        Select Case lblDailyDouble.Text
            Case "True"
                Customizer.chkDailyDouble.Checked = True
            Case "False"
                Customizer.chkDailyDouble.Checked = False
        End Select
        Select Case lblRoundNumber.Text
            Case 1
                Customizer.cboRound.SelectedItem = "JEOPARDY!"
            Case 2
                Customizer.cboRound.SelectedItem = "DOUBLE JEOPARDY!"
            Case 3
                Customizer.cboRound.SelectedItem = "FINAL JEOPARDY!"
        End Select
    End Sub
End Class