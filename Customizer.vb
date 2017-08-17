Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Public Class Customizer
    Public cluefs
    Public writer
    Public clueExists As Boolean = False
    Private Sub Customizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loadClueBoardXML()
        loadPacks()
    End Sub
    Private Sub Customizer_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Select Case MsgBox("Do you want to return to the main screen?", vbYesNo + vbQuestion, "Jeopardy!")
            Case MsgBoxResult.Yes
                WelcomeScreen.Show()
            Case MsgBoxResult.No
        End Select
    End Sub
    Private Function checkIfExists(packName As String, categoryNumber As Integer, pointValue As Integer, round As Integer) As Boolean
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Clueboard WHERE packName = @PackName and categoryNumber = @CategoryNumber and pointValue = @PointValue and round = @Round"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim categoryNumberParam As SqlParameter = New SqlParameter("@CategoryNumber", categoryNumber)
        Dim pointValueParam As SqlParameter = New SqlParameter("@PointValue", pointValue)
        Dim roundParam As SqlParameter = New SqlParameter("@Round", round)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(categoryNumberParam)
        cmd.Parameters.Add(pointValueParam)
        cmd.Parameters.Add(roundParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        If rdr.HasRows() Then
            Return True
        Else
            Return False
        End If
        connPuzzle.Close()
        Return False
    End Function
#Region "Load and Insert Clues from/to Database"
    Private Sub loadClues(packName As String)
        For Each item As Control In cluePanel.Controls
            If item.GetType() Is GetType(ClueDisplay) Then
                cluePanel.Controls.Remove(item)
            Else
            End If
        Next
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Clueboard WHERE packName = @PackName"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        connClues.Open()
        cmd = New SqlCommand(strSQL, connClues)
        cmd.Parameters.Add(packNameParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            Dim category As String = Trim(rdr("categoryName").ToString())
            Dim clue As String = Trim(rdr("clue").ToString())
            Dim value As Integer = Trim(rdr("pointValue").ToString())
            Dim clueID As String = "Cat" & Trim(rdr("categoryNumber").ToString()) & Trim(rdr("pointValue")).ToString()
            Dim clue1 As New Clue(category, value, clue, clueID)
            Dim clueDisplay1 As New ClueDisplay(clue1)
            clueDisplay1.Parent = cluePanel
            cluePanel.Controls.Add(clueDisplay1)
        Loop
        connClues.Close()
    End Sub
    Private Sub updateClue(packName As String, categoryName As String, categoryNumber As Integer, pointValue As Integer, clue As String, round As Integer)
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "Update Clueboard Set categoryName = @CategoryName, clue = @Clue WHERE packName = @PackName and categoryNumber = @CategoryNumber and pointValue = @PointValue and round = @Round"
        Dim cmd As SqlCommand
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim categoryNumberParam As SqlParameter = New SqlParameter("@CategoryNumber", categoryNumber)
        Dim pointValueParam As SqlParameter = New SqlParameter("@PointValue", pointValue)
        Dim categoryNameParam As SqlParameter = New SqlParameter("@CategoryName", categoryName)
        Dim clueParam As SqlParameter = New SqlParameter("@Clue", clue)
        Dim roundParam As SqlParameter = New SqlParameter("@Round", round)
        connClues.Open()
        cmd = New SqlCommand(strSQL, connClues)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(categoryNumberParam)
        cmd.Parameters.Add(pointValueParam)
        cmd.Parameters.Add(categoryNameParam)
        cmd.Parameters.Add(clueParam)
        cmd.Parameters.Add(roundParam)
        cmd.CommandType = CommandType.Text
        cmd.ExecuteNonQuery()
        connClues.Close()
    End Sub
    Private Sub insertClue(packName As String, categoryName As String, categoryNumber As Integer, pointValue As Integer, clue As String, round As Integer)
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "Insert Into Clueboard Values (@CategoryNumber ,@CategoryName, @PointValue, @Clue, @PackName, @Round)"
        Dim cmd As SqlCommand
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim categoryNumberParam As SqlParameter = New SqlParameter("@CategoryNumber", categoryNumber)
        Dim pointValueParam As SqlParameter = New SqlParameter("@PointValue", pointValue)
        Dim categoryNameParam As SqlParameter = New SqlParameter("@CategoryName", categoryName)
        Dim clueParam As SqlParameter = New SqlParameter("@Clue", clue)
        Dim roundParam As SqlParameter = New SqlParameter("@Round", round)
        connClues.Open()
        cmd = New SqlCommand(strSQL, connClues)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(categoryNumberParam)
        cmd.Parameters.Add(pointValueParam)
        cmd.Parameters.Add(categoryNameParam)
        cmd.Parameters.Add(clueParam)
        cmd.Parameters.Add(roundParam)
        cmd.CommandType = CommandType.Text
        cmd.ExecuteNonQuery()
        connClues.Close()
    End Sub
#End Region
#Region "Load Packs from Database"
    Private Sub loadPacks()
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Clueboard"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        connClues.Open()
        cmd = New SqlCommand(strSQL, connClues)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            Dim packName As String = Trim(rdr("packName").ToString())
            Dim categoryName As String = Trim(rdr("categoryName").ToString)
            If Not cboPack.Items.Contains(packName) And Not cboSelectPack.Items.Contains(packName) Then
                cboSelectPack.Items.Add(packName)
                cboPack.Items.Add(packName)
            Else
            End If
            If Not cboCategory.Items.Contains(categoryName) Then
                cboCategory.Items.Add(categoryName)
            End If
        Loop
        connClues.Close()
    End Sub
#End Region
#Region "XML Code"
    Private Sub loadClueBoardXML()
        Try
            cluePanel.Controls.Clear()
            cboCategory.Items.Clear()
            Dim xmldoc As New XmlDocument
            Dim xmlnode As XmlNodeList
            Dim i As Integer
            Dim str As String
            Dim str2 As String
            Dim str3 As String
            Dim str4 As String
            Dim str5 As String
            Dim strReplaced As String
            Dim str2Replaced As String
            Dim str3Replaced As String
            Dim str4Replaced As String
            Dim str5Replaced As String
            cluefs = New FileStream("C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" + "\JeopardyMain.xml", FileMode.Open, FileAccess.Read)
            Dim XMLStringList As New List(Of String)
            xmldoc.Load(cluefs)
            xmlnode = xmldoc.GetElementsByTagName("clue")
            For i = 0 To xmlnode.Count - 1
                str = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                str2 = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                str3 = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
                str4 = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
                str5 = xmlnode(i).ChildNodes.Item(4).InnerText.Trim()
                strReplaced = str.Replace("_", " ")
                str2Replaced = str2.Replace("_", " ")
                str3Replaced = str3.Replace("_", " ")
                str4Replaced = str4.Replace("_", " ")
                str5Replaced = str5.Replace("_", " ")
                Dim clue1 As New ClueVoice(strReplaced, str2, str3Replaced, str4Replaced, str5Replaced)
                Dim clueDisplay1 As New ClueDisplayVoice(clue1)
                clueDisplay1.Parent = cluePanel
                cluePanel.Controls.Add(clueDisplay1)
                clueDisplay1.Show()
                'clueDisplay1.clueBox.Load(clue1.getimgLocation())
                If Not cboCategory.Items.Contains(strReplaced) Then
                    cboCategory.Items.Add(strReplaced)
                Else
                End If
            Next
            cluefs.close()
        Catch ex As Exception
            cluefs.Close()
        End Try
    End Sub
    Public Sub writeXML()
        writer = New XmlTextWriter("C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" + "\JeopardyMain.xml", System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartDocument(True)
        writer.WriteStartElement("clueboard")
        For Each item As ClueDisplay In cluePanel.Controls
            Dim category = item.categorylbl.Text.Replace(" ", "_")
            Dim value = item.valuelbl.Text.Replace(" ", "_")
            Dim imgLocation = item.imgLabel.Text.Replace(" ", "_")
            Dim answer = item.answerlbl.Text.Replace(" ", "_")
            Dim clueID = item.clueIDlbl.Text.Replace(" ", "_")
            createNode(category, value, imgLocation, answer, clueID, writer)
        Next
        writer.WriteEndDocument()
        writer.Close()
        loadClueBoardXML()
        clueExists = False
    End Sub
    Private Sub createNode(ByVal category As String, ByVal value As String, ByVal imgLocation As String, ByVal answer As String, ByVal clueID As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("clue")
        writer.WriteStartElement("category")
        writer.WriteString(category)
        writer.WriteEndElement()
        writer.WriteStartElement("value")
        writer.WriteString(value)
        writer.WriteEndElement()
        writer.WriteStartElement("imgLocation")
        writer.WriteString(imgLocation)
        writer.WriteEndElement()
        writer.WriteStartElement("answer")
        writer.WriteString(answer)
        writer.WriteEndElement()
        writer.WriteStartElement("clueid")
        writer.WriteString(clueID)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub
    'Private Sub saveBTN_Click(sender As Object, e As EventArgs) Handles saveBTN.Click
    '    Try
    '        For Each item As ClueDisplay In cluePanel.Controls
    '            If item.categorylbl.Text = cboCategory.SelectedItem.ToString() Then
    '                clueExists = True
    '                item.categorylbl.Text = cboCategory.SelectedItem.ToString()
    '                If item.clueIDlbl.Text = clueIDTextBox.Text Then
    '                    item.valuelbl.Text = numValue.Value.ToString()
    '                    'item.imgLabel.Text = clueLocationTextBox.Text
    '                    'item.answerlbl.Text = answerTextBox.Text
    '                    item.clueIDlbl.Text = clueIDTextBox.Text
    '                End If
    '            End If
    '        Next
    '        writeXML()
    '        loadClueBoardXML()
    '    Catch ex As Exception
    '        MsgBox("An error occurred while writing to the XML file. Check to make sure that all fields have been filled out.")
    '        writer.Close()
    '    End Try
    'End Sub 
    'Private Sub deleteBTN_Click(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub replaceBTN_Click(sender As Object, e As EventArgs) Handles replaceBTN.Click
    '    Dim originalCategory As String = categoryComboBox.SelectedItem
    '    Dim originalCategoryIndex As Integer = categoryComboBox.SelectedIndex
    '    Select Case MsgBox("Are you sure you want to replace this category? Please note that the category isn't replaced until you hit the save button, but once you hit the save button, the action cannot be undone.", vbYesNo + vbQuestion, "Jeopardy!")
    '        Case MsgBoxResult.Yes
    '            'Try
    '            categoryComboBox.Items.Insert(categoryComboBox.SelectedIndex, categoryReplaceTextBox.Text)
    '            categoryComboBox.Items.Remove(categoryComboBox.SelectedItem)
    '            categoryComboBox.SelectedItem = categoryReplaceTextBox.Text
    '            For Each item As ClueDisplay In cluePanel.Controls
    '                If item.categorylbl.Text = categoryReplaceTextBox.Text Then
    '                    item.categorylbl.Text = categoryReplaceTextBox.Text
    '                Else
    '                End If
    '            Next
    '            'Catch ex As Exception
    '            '    MsgBox("An error occurred when replacing the category. Try restarting the app.", vbCritical, "Jeopardy!")
    '            'End Try
    '        Case MsgBoxResult.No
    '    End Select
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles clueLocationOpenButton.Click
    '    If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
    '        clueLocationTextBox.Text = OpenFileDialog1.FileName
    '    End If
    'End Sub

    'Private Sub developcheckbox_checkedchanged(sender As Object, e As EventArgs)
    '    If developCheckBox.Checked Then
    '        clueLocationTextBox.Enabled = True
    '        clueLocationOpenButton.Enabled = True
    '    Else
    '        clueLocationTextBox.Enabled = False
    '        clueLocationOpenButton.Enabled = False
    '    End If
    'End Sub
    'Public Sub writeXML()
    '    writer = New XmlTextWriter("C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" + "\JeopardyMainTested.xml", System.Text.Encoding.UTF8)
    '    writer.Formatting = Formatting.Indented
    '    writer.Indentation = 2
    '    writer.WriteStartDocument(True)
    '    writer.WriteStartElement("clueboard")
    '    For Each item As ClueDisplay In cluePanel.Controls
    '        Dim category = item.categorylbl.Text.Replace(" ", "_")
    '        Dim value = item.valuelbl.Text.Replace(" ", "_")
    '        Dim imgLocation = item.imgLabel.Text.Replace(" ", "_")
    '        Dim answer = item.answerlbl.Text.Replace(" ", "_")
    '        Dim clueID = item.clueIDlbl.Text.Replace(" ", "_")
    '        createNode(category, value, imgLocation, answer, clueID, writer)
    '    Next
    '    Dim categoryStr = categoryComboBox.SelectedItem.ToString()
    '    Dim valueStr = valueUpDown.Value.ToString()
    '    Dim imgLocationStr = clueLocationTextBox.Text
    '    Dim answerStr = answerTextBox.Text
    '    Dim clueIDStr = clueIDTextBox.Text
    '    createNode(categoryStr, valueStr, imgLocationStr, answerStr, clueIDStr, writer)
    '    writer.WriteEndElement()
    '    writer.WriteEndDocument()
    '    writer.Close()
    '    loadClueBoardXML()
    '    clueExists = False
    'End Sub
    'Private Sub createNode(ByVal category As String, ByVal value As String, ByVal imgLocation As String, ByVal answer As String, ByVal clueID As String, ByVal writer As XmlTextWriter)
    '    writer.WriteStartElement("clue")
    '    writer.WriteStartElement("category")
    '    writer.WriteString(category)
    '    writer.WriteEndElement()
    '    writer.WriteStartElement("value")
    '    writer.WriteString(value)
    '    writer.WriteEndElement()
    '    writer.WriteStartElement("imgLocation")
    '    writer.WriteString(imgLocation)
    '    writer.WriteEndElement()
    '    writer.WriteStartElement("answer")
    '    writer.WriteString(answer)
    '    writer.WriteEndElement()
    '    writer.WriteStartElement("clueid")
    '    writer.WriteString(clueID)
    '    writer.WriteEndElement()
    '    writer.WriteEndElement()
    'End Sub

    'Private Sub saveBTN_Click(sender As Object, e As EventArgs) Handles saveBTN.Click
    '    Try
    '        For Each item As ClueDisplay In cluePanel.Controls
    '            If item.categorylbl.Text = categoryComboBox.SelectedItem.ToString() Then
    '                clueExists = True
    '                item.categorylbl.Text = categoryComboBox.SelectedItem.ToString()
    '                item.valuelbl.Text = valueUpDown.Value.ToString()
    '                item.imgLabel.Text = clueLocationTextBox.Text
    '                item.answerlbl.Text = answerTextBox.Text
    '                item.clueIDlbl.Text = clueIDTextBox.Text
    '            End If
    '        Next
    '        writeXML()
    '        loadClueBoardXML()
    '    Catch ex As Exception
    '        MsgBox("An error occurred while writing to the XML file. Check to make sure that all fields have been filled out. Also, check to make sure the file isn't in use by another application.")
    '    End Try
    'End Sub
#End Region
    Private Sub replaceBTN_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboSelectPack_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectPack.SelectedIndexChanged
        If cboSelectPack.SelectedItem.ToString = "CREATE NEW PACK" Then
            pnlSelectPack.Hide()
        Else
            loadClues(cboSelectPack.SelectedItem.ToString)
            cboPack.Text = cboSelectPack.SelectedItem.ToString()
            pnlSelectPack.Hide()
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim round As Integer
        If cboRound.SelectedItem.ToString = "JEOPARDY!" Then
            round = 1
        ElseIf cboRound.SelectedItem.ToString = "DOUBLE JEOPARDY!" Then
            round = 2
        ElseIf cboRound.SelectedItem.ToString = "FINAL JEOPARDY!" Then
            round = 3
        End If
        If checkIfExists(cboPack.Text, numCategory.Value, numValue.Value, round) = False Then
            insertClue(cboPack.Text, cboCategory.Text, numCategory.Value, numValue.Value, txtClue.Text, round)
            loadClues(cboPack.Text)
        Else
            updateClue(cboPack.Text, cboCategory.Text, numCategory.Value, numValue.Value, txtClue.Text, round)
            loadClues(cboPack.Text)
        End If
    End Sub

    Private Sub cboCategory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCategory.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cboCategory.Items.Contains(cboCategory.Text) Then
                Dim originalCategory As String = cboCategory.SelectedItem
                Dim originalCategoryIndex As Integer = cboCategory.SelectedIndex
                Select Case MsgBox("Are you sure you want to replace this category? Please note that the category isn't officially replaced in the file until you hit the submit button, but once you hit the submit button, the action cannot be undone.", vbYesNo + vbQuestion, "Jeopardy!")
                    Case MsgBoxResult.Yes
                        'Try
                        For Each item As ClueDisplay In cluePanel.Controls
                            If item.categorylbl.Text = originalCategory Then
                                'item.categorylbl.Text = categoryReplaceTextBox.Text
                            Else
                                'MsgBox("Category doesn't exist.", vbInformation, "Jeopardy!")
                            End If
                        Next
                'categoryComboBox.Items.Insert(categoryComboBox.SelectedIndex, categoryReplaceTextBox.Text)
                'categoryComboBox.Items.Remove(categoryComboBox.SelectedItem)
                'categoryComboBox.SelectedItem = categoryReplaceTextBox.Text

                    'Catch ex As Exception
                    '    MsgBox("An error occurred when replacing the category. Try restarting the app.", vbCritical, "Jeopardy!")
                    'End Try
                    Case MsgBoxResult.No
                End Select
            Else
                cboCategory.Items.Add(cboCategory.Text)
            End If
        End If
    End Sub

    Private Sub cboPack_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPack.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cboPack.Items.Add(cboPack.Text)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class