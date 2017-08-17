Public Class testFormatting
    Dim myText As String = "Hello <u>World</u>"
    Dim richTextBoxWPF As New System.Windows.Controls.Frame
    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        ShadowLabel1.TextAlign = ContentAlignment.MiddleCenter
        'ElementHost1.Child = richTextBoxWPF
        'richTextBoxWPF.HorizontalAlignment = System.Windows.HorizontalAlignment.Center
        'richTextBoxWPF.VerticalAlignment = System.Windows.VerticalAlignment.Center
        'richTextBoxWPF.
        'richTextBoxWPF.AppendText(myText)
        'lblTest.Se
        'RichTextBox1.Text = "<html><body style=""background-color:#03128a;"" ""#03128a"" <font face=""Korinna"" color=""#FFFFFF"">" & myText & "</font></body></html>"
        'WebBrowser1.DocumentText = RichTextBox1.Text
        'WebBrowser1.Document.BackColor = Color.FromArgb(3, 18, 138)
        'Dim TheseAreYourWords As String()
        'Dim myWords As New List(Of String)
        'TheseAreYourWords = myText.Split(" ")
        'For Each item As String In TheseAreYourWords
        '    If Not item = TheseAreYourWords.Last Then
        '        myWords.Add(item)
        '    Else
        '        myWords.Add(item)
        '    End If
        'Next
    End Sub
End Class