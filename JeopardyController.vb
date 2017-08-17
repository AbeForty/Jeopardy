Imports System.Xml
Imports System.IO
Imports System.Threading
Imports System.Globalization
Imports System.Speech
Imports System.Speech.Recognition
Imports System.Data.SqlClient

Public MustInherit Class JeopardyController
    Public Enum TimeOutCommand
        Inactivity
        Player
    End Enum
    Public Enum roundType
        Jeopardy
        DoubleJeopardy
        FinalJeopardy
    End Enum
#Region "Create all instance variables"
    'Stick the following values into an list
    Public Shared currentAnswer As String = ""
    Public Shared currentAlternateAnswer As String = ""
    Public Shared currentAlternateAnswer2 As String = ""
    Public Shared currentAlternateAnswer3 As String = ""
    Public Shared currentAlternateAnswer4 As String = ""
    Public Shared currentPointValue As Integer
    Public Shared currentPlayer As Integer = 1
    Public Shared currentSecond As Integer = 0
    Public Shared clueLocation As String = ""
    Private Shared categoryList As New List(Of String)
    Public Shared categoryListSorted As New SortedList(Of Integer, String)
    Public Shared questionMode As Boolean = False
    Public Shared categoryMode As Boolean = False
    Public Shared bypassCategoryReveal As Boolean = False
    Public Shared WithEvents jSpeechRecog As New JeopardySpeechRecognizer
    Private Shared clueID As String
    Dim xmlstr3 As String
    Dim xmlstr4 As String
    Public Shared _fadeOpacity As Single = 0
    Public Shared _fadeOpacity2 As Single = 0
    Public Shared _fadeOpacity3 As Single = 0
    Public Shared _fadeOpacity4 As Single = 0
    Public Shared _fadeOpacity5 As Single = 0
    Public Shared _fadeOpacity6 As Single = 0
    Public Shared _fadeOpacity7 As Single = 0
    Public Shared _fadeOpacity8 As Single = 0
    Public Shared _fadeOpacity9 As Single = 0
    Public Shared _fadeOpacity10 As Single = 0
    Public Shared oldImage As Bitmap = New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\BlankTile.png"), New Size(164, 89))
    Public Shared newImage200 = New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\200.PNG"), New Size(164, 89))
    Public Shared newImage400 = New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\400.PNG"), New Size(164, 89))
    Public Shared newImage600 = New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\600.PNG"), New Size(164, 89))
    Public Shared newImage800 = New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\800.PNG"), New Size(164, 89))
    Public Shared newImage1000 = New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\1000.PNG"), New Size(164, 89))
    Public Shared set1 As New List(Of String)
    Public Shared set2 As New List(Of String)
    Public Shared set3 As New List(Of String)
    Public Shared set4 As New List(Of String)
    Public Shared set5 As New List(Of String)
    Public Shared set6 As New List(Of String)
    Public Shared set7 As New List(Of String)
    Public Shared set8 As New List(Of String)
    Public Shared set9 As New List(Of String)
    Public Shared set10 As New List(Of String)
    Public Shared roundForm As categoryScreen
    Public Shared packName As String
    Private Shared clueList As New SortedList(Of String, String)
#End Region
#Region "Fade in Code"
    Public Shared Function FadeBitmap(ByVal bmp As Bitmap, ByVal opacity As Single) As Bitmap
        Dim bmp2 As New Bitmap(bmp.Width, bmp.Height, Imaging.PixelFormat.Format32bppArgb)
        opacity = Math.Max(0, Math.Min(opacity, 1.0F))
        Using ia As New Imaging.ImageAttributes
            Dim cm As New Imaging.ColorMatrix
            cm.Matrix33 = opacity
            ia.SetColorMatrix(cm)
            Dim destpoints() As PointF = {New Point(0, 0), New Point(bmp.Width, 0), New Point(0, bmp.Height)}
            Using g As Graphics = Graphics.FromImage(bmp2)
                g.DrawImage(bmp, destpoints,
          New RectangleF(Point.Empty, bmp.Size), GraphicsUnit.Pixel, ia)
            End Using
        End Using
        Return bmp2
    End Function

#End Region
#Region "Load All Categories"
    Private Shared Sub loadcategoryXML()
        Dim xmldoc As New XmlDocument
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim str As String
        Dim str2 As String
        Dim strReplaced As String
        Dim str2Replaced As String
        Dim fs As New FileStream("C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" + "\JeopardyMain.xml", FileMode.Open, FileAccess.Read)
        Dim XMLStringList As New List(Of String)
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName("clue")
        For i = 0 To xmlnode.Count - 1
            jSpeechRecog.RecognizeAsyncCancel()
            str = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
            str2 = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
            strReplaced = str.Replace("_", " ")
            str2Replaced = str2.Replace("_", " ")
            Dim finalcatstring1 = strReplaced + str2Replaced
            Dim finalcatstring2 = strReplaced + "for" + str2Replaced
            Dim finalcatstring3 = str2Replaced + strReplaced
            XMLStringList.Add(finalcatstring1)
            XMLStringList.Add(finalcatstring2)
            XMLStringList.Add(finalcatstring3)
        Next
        jSpeechRecog.addToList(XMLStringList, JeopardySpeechRecognizer.LoadCommand.Category)
        jSpeechRecog.loadGrammarObject(JeopardySpeechRecognizer.LoadCommand.Category)
        jSpeechRecog.RecognizeAsyncCancel()
    End Sub
#End Region
#Region "Initialize Game Manual"
    Public Shared Sub initializeGameManual(round As roundType)
        If categoryScreen.Visible = True Then
            roundForm = CType(categoryScreen, categoryScreen)
        End If
        For Each item As PictureBox In roundForm.categoryPanel.Controls
            roundForm.catListBox.Items.Add(item.Name)
        Next
        'If categoryScreen.Visible = True Then
        '    loadSets()
        'ElseIf djcategoryScreen.Visible = True Then
        'End If
        loadSets()
        'roundForm.Timer3.Start()
        roundForm.rtbSeenClues.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        roundForm.rtbPointValues.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
        'loadcategoryXMLManual()
        roundForm.Timer9.Start()
        roundForm.Timer8.Start()
        'roundForm.wmpCategory.Ctlcontrols.stop()
        roundForm.Timer1.Start()
        roundForm.Timer6.Start()
    End Sub
    Private Shared Sub loadSets()
        If categoryScreen.Visible = True Then
            For i As Integer = 1 To 3
                Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                set1.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                'roundForm.categoryPanel.Controls(roundForm.catListBox.Items.Item(RandNumber).ToString()).Show()
                'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                roundForm.catListBox.Items.RemoveAt(RandNumber)
                For myi = 1 To roundForm.TrackBar1.Maximum
                    'While i <= TrackBar1.Maximum
                    roundForm.TrackBar1.Value = myi
                    'End While
                Next
                Dim strClueValue As String
                If set1(i - 1).Length = 8 Then
                    strClueValue = set1(1).Remove(0, 4)
                ElseIf set1(i - 1).Length = 7 Then
                    Dim strCatNumberPreformatted As String = set1(i - 1).Remove(0, 3)
                    'MsgBox(strCatNumberPreformatted)
                    strClueValue = strCatNumberPreformatted.Remove(0, 1)
                End If
                Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                CType(roundForm.categoryPanel.Controls(roundForm.catListBox.Items.Item(RandNumber).ToString()), PictureBox).Image = FadeBitmap(newImage, 0.5)
            Next
            For myI = 1 To 100
                roundForm.pbarLoadCat.Value += 1
            Next
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 100 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set2.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set2(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar2.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar2.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set2(i - 1).Length = 8 Then
                        strClueValue = set2(i - 1).Remove(0, 4)
                    ElseIf set2(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set2(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set2(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 200 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set3.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set3(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar3.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar3.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set3(i - 1).Length = 8 Then
                        strClueValue = set3(i - 1).Remove(0, 4)
                    ElseIf set3(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set3(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set3(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 300 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set4.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set4(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar4.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar4.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set4(i - 1).Length = 8 Then
                        strClueValue = set4(i - 1).Remove(0, 4)
                    ElseIf set4(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set4(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set4(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 400 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set5.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set5(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar5.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar5.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set5(i - 1).Length = 8 Then
                        strClueValue = set5(i - 1).Remove(0, 4)
                    ElseIf set5(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set5(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set5(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 500 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set6.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set6(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar6.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar6.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    'MsgBox(roundForm.catListBox.Items.Item(RandNumber - 1).ToString())
                    If set6(i - 1).Length = 8 Then
                        strClueValue = set6(i - 1).Remove(0, 4)
                    ElseIf set6(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set6(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set6(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 600 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set7.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set7(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar7.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar7.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set7(i - 1).Length = 8 Then
                        strClueValue = set7(i - 1).Remove(0, 4)
                    ElseIf set7(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set7(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set7(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 700 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set8.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set8(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar8.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar8.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set8(i - 1).Length = 8 Then
                        strClueValue = set8(i - 1).Remove(0, 4)
                    ElseIf set8(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set8(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set8(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 800 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set9.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(roundForm.catListBox.Items.Item(RandNumber).ToString()).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar9.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar9.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set9(i - 1).Length = 8 Then
                        strClueValue = roundForm.catListBox.Items.Item(RandNumber).ToString().Remove(0, 4)
                    ElseIf set9(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set9(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(roundForm.catListBox.Items.Item(RandNumber).ToString()), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            If roundForm.pbarLoadCat.Value = 900 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count - 1))
                    set10.Add(roundForm.catListBox.Items.Item(RandNumber).ToString())
                    'roundForm.categoryPanel.Controls(set10(i-1)).Show()
                    'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
                    roundForm.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To roundForm.TrackBar10.Maximum
                        'While i <= TrackBar1.Maximum
                        roundForm.TrackBar10.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set10(i - 1).Length = 8 Then
                        strClueValue = set10(i - 1).Remove(0, 4)
                    ElseIf set10(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set10(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set10(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            'Else
            '    For Each control As Control In DJcategoryScreen.categoryPanel.Controls
            '        control.Show()
            '    Next
            'End If
            'If roundForm.pbarLoadCat.Value = 1000 Then
            '    For i As Integer = 1 To 3
            '        Dim RandNumber = CInt(Math.Ceiling(Rnd() * roundForm.catListBox.Items.Count)) - 1
            '        roundForm.categoryPanel.Controls(roundForm.catListBox.Items.Item(RandNumber).ToString()).Show()
            '        'MsgBox(RandNumber & " | " & roundForm.catListBox.Items.Count)
            '        roundForm.catListBox.Items.RemoveAt(RandNumber)
            '    Next
            'End If
            'roundForm.PerformLayout()
        End If
    End Sub
#End Region
#Region "Ring In Code Voice Activated"
    Public Shared Sub ringIn()
        If jSpeechRecog.QuestionMode = True Then
            '    If RecognizerOn = True Then
            If frmScore.txtCurrentPlayer.Text = "" Then
                If My.Computer.Keyboard.CtrlKeyDown = True And frmScore.Player1RungIn = False Then
                    'frmScore.notifyBar.Text = frmScore.lblPlayer1.Text
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    'Timer10.Stop()
                    'Timer11.Start()
                    roundForm.Timer12.Start()
                    frmScore.Player1RungIn = True
                    If frmScore.Player1RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer1.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = "Player 1"
                        Try
                            jSpeechRecog.SetInputToDefaultAudioDevice()
                            jSpeechRecog.Recognize()
                        Catch ex As Exception
                            MsgBox(ex)
                            jSpeechRecog.RecognizeAsyncCancel()
                            jSpeechRecog.recognizerOn = False
                            roundForm.Timer7.Stop()
                        End Try
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                ElseIf My.Computer.Keyboard.AltKeyDown = True And frmScore.Player2RungIn = False Then
                    roundForm.Timer12.Start()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer2.Text
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.Player2RungIn = True
                    If frmScore.Player2RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer2.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = "Player 2"
                        Try
                            jSpeechRecog.SetInputToDefaultAudioDevice()
                            jSpeechRecog.Recognize()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            jSpeechRecog.RecognizeAsyncCancel()
                            jSpeechRecog.recognizerOn = False
                            roundForm.Timer7.Stop()
                            'End Try
                            'frmScore.ProgressBar1.PerformStep()
                            'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                            'End If
                        End Try
                    End If
                ElseIf My.Computer.Keyboard.ShiftKeyDown = True And frmScore.Player3RungIn = False Then
                    roundForm.Timer12.Start()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer3.Text
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.Player3RungIn = True
                    If frmScore.Player3RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer3.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = "Player 3"
                        Try
                            jSpeechRecog.SetInputToDefaultAudioDevice()
                            jSpeechRecog.Recognize()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            jSpeechRecog.RecognizeAsyncCancel()
                            jSpeechRecog.recognizerOn = False
                            roundForm.Timer7.Stop()
                        End Try
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                End If
            End If
        ElseIf jSpeechRecog.categoryMode = True Then
            jSpeechRecog.RecognizeAsyncCancel()
            'jSpeechRecog..RecognizeAsyncStop()
            roundForm.Timer7.Stop()
        End If
        'End If
        If frmScore.txtCurrentPlayer.Text = "" And frmScore.Player1RungIn = True And frmScore.Player2RungIn = True And frmScore.Player3RungIn = True And Not frmScore.IsDailyDouble = True Then
            frmScore.Player1RungIn = False
            frmScore.Player2RungIn = False
            frmScore.Player3RungIn = False
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
            Dim SAPI
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("The correct answer was " + currentAnswer)
            jSpeechRecog.categoryMode = True
            jSpeechRecog.QuestionMode = False
            jSpeechRecog.RecognizeAsyncCancel()
            roundForm.Timer7.Stop()
            roundForm.clue.Hide()
            currentPointValue = 0
        ElseIf frmScore.IsDailyDouble = True Then
            frmScore.Player1RungIn = False
            frmScore.Player2RungIn = False
            frmScore.Player3RungIn = False
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
            'Dim SAPI
            'SAPI = CreateObject("SAPI.spvoice")
            'SAPI.Speak("The correct answer was " + currentAnswer)
            jSpeechRecog.RecognizeAsyncCancel()
            jSpeechRecog.categoryMode = True
            jSpeechRecog.QuestionMode = False
            roundForm.Timer7.Stop()
            roundForm.clue.Hide()
            currentPointValue = 0
        End If
    End Sub
#End Region
#Region "Ring In Code Manual"
    Public Shared Sub ringInManual()
        If questionMode = True Then
            '    If RecognizerOn = True Then
            If frmScore.txtCurrentPlayer.Text = "" Then
                roundForm.playerTimeOutTimer.Start()
                frmScore.btnYes.Hide()
                frmScore.btnNo.Hide()
                If My.Computer.Keyboard.CtrlKeyDown = True And frmScore.Player1RungIn = False Then
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer1.Text
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    'Timer10.Stop()
                    'Timer11.Start()
                    'roundForm.Timer12.Start()
                    frmScore.Player1RungIn = True
                    If frmScore.Player1RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer1.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = "Player 1"
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                ElseIf My.Computer.Keyboard.AltKeyDown = True And frmScore.Player2RungIn = False Then
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'roundForm.Timer12.Start()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer2.Text
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.Player2RungIn = True
                    If frmScore.Player2RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer2.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = "Player 2"
                    End If
                ElseIf My.Computer.Keyboard.ShiftKeyDown = True And frmScore.Player3RungIn = False Then
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'roundForm.Timer12.Start()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer3.Text
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.Player3RungIn = True
                    If frmScore.Player3RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer3.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = "Player 3"
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                End If
            End If
        ElseIf categoryMode = True Then
            roundForm.Timer7.Stop()
        End If
        'End If
        If frmScore.txtCurrentPlayer.Text = "" And frmScore.Player1RungIn = True And frmScore.Player2RungIn = True And frmScore.Player3RungIn = True And Not frmScore.IsDailyDouble = True Then
            frmScore.Player1RungIn = False
            frmScore.Player2RungIn = False
            frmScore.Player3RungIn = False
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
            Dim SAPI
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("The correct answer was " + currentAnswer)
            categoryMode = True
            questionMode = False
            roundForm.Timer7.Stop()
            roundForm.clue.Hide()
            currentPointValue = 0
        ElseIf frmScore.IsDailyDouble = True Then
            frmScore.Player1RungIn = False
            frmScore.Player2RungIn = False
            frmScore.Player3RungIn = False
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
            'Dim SAPI
            'SAPI = CreateObject("SAPI.spvoice")
            'SAPI.Speak("The correct answer was " + currentAnswer)
            categoryMode = True
            questionMode = False
            roundForm.Timer7.Stop()
            roundForm.clue.Hide()
            currentPointValue = 0
        End If
    End Sub
#End Region
#Region "Voice Recognition Event"
    Private Shared Sub recevent(sender As Object, e As System.Speech.Recognition.RecognitionEventArgs) Handles jSpeechRecog.SpeechRecognized
        frmScore.txtRecognition.Text = e.Result.Text
        frmScore.lblConfidence.Text = e.Result.Confidence
        If jSpeechRecog.QuestionMode = True Then
            frmScore.BringToFront()
            jSpeechRecog.categoryMode = False
            jSpeechRecog.RecognizeAsyncCancel()
            If (jSpeechRecog.cluelist.Contains(e.Result.Text)) And e.Result.Confidence > 0.94 Then
                frmScore.IsDailyDouble = False
                jSpeechRecog.allowCatMode = True
                If frmScore.txtCurrentPlayer.Text = "Player 1" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                    jSpeechRecog.categoryMode = True
                    jSpeechRecog.QuestionMode = False
                    frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) + currentPointValue
                    frmScore.notifyBar.Text = ""
                    roundForm.clue.Hide()
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    currentPointValue = 0
                    currentPlayer = 1
                    roundForm.Timer7.Stop()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                    jSpeechRecog.categoryMode = True
                    jSpeechRecog.QuestionMode = False
                    frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) + currentPointValue
                    frmScore.notifyBar.Text = ""
                    roundForm.clue.Hide()
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    currentPointValue = 0
                    currentPlayer = 2
                    roundForm.Timer7.Stop()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                    jSpeechRecog.categoryMode = True
                    jSpeechRecog.QuestionMode = False
                    frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) + currentPointValue
                    frmScore.notifyBar.Text = ""
                    roundForm.clue.Hide()
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    currentPointValue = 0
                    currentPlayer = 3
                    roundForm.Timer7.Stop()
                End If
            ElseIf (jSpeechRecog.cluelist.Contains(e.Result.Text)) And e.Result.Confidence < 0.94 Then
                frmScore.notifyBar.Text = frmScore.txtCurrentPlayer.Text + ": Speech may have been misinterpreted. Please try again."
                Try
                    jSpeechRecog.SetInputToDefaultAudioDevice()
                    jSpeechRecog.Recognize()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                End Try
            ElseIf Not (jSpeechRecog.cluelist.Contains(e.Result.Text)) And e.Result.Confidence > 0.94 Then
                frmScore.IsDailyDouble = False
                'lblPlayer1.Text = "No player has rung in"
                'RecognizeAsynccancel()
                If frmScore.txtCurrentPlayer.Text = "Player 1" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    frmScore.Player1RungIn = True
                    My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
                    frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) - currentPointValue
                    frmScore.notifyBar.Text = frmScore.lblPlayer1.Text + " lost " + currentPointValue.ToString
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
                    frmScore.Player2RungIn = True
                    frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) - currentPointValue
                    frmScore.notifyBar.Text = frmScore.lblPlayer2.Text + " lost " + currentPointValue.ToString
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    frmScore.Player3RungIn = True
                    My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
                    frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) - currentPointValue
                    frmScore.notifyBar.Text = frmScore.lblPlayer3.Text + " lost " + currentPointValue.ToString
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                End If
            End If
        ElseIf jSpeechRecog.categoryMode = True Then
            jSpeechRecog.RecognizeAsyncCancel()
            frmScore.BringToFront()
            'roundForm.Timer4.Start()
            'jSpeechRecog.categoryMode = True
            jSpeechRecog.QuestionMode = False
            Dim catstring
            If jSpeechRecog.seenclues.Contains(e.Result.Text) Then
                jSpeechRecog.RecognizeAsyncCancel()
                'Try
                '    SetInputToDefaultAudioDevice()
                '    Recognize()
                'catch ex As Exception
                '    MsgBox(ex.Message)
                '    RecognizeAsynccancel()
                '    RecognizerOn = False
                'End Try
            ElseIf Not jSpeechRecog.seenclues.Contains(e.Result.Text) Then
                If (e.Result.Text.Contains("200")) Then
                    catstring = e.Result.Text.Replace("200", "").Replace("for", "")
                    currentPointValue = 200
                    loadclueBoardXML(catstring, 200)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'roundForm.PointValueBox.Show()
                    'roundForm.PointValueBox.Image = My.Resources.Screen200
                    roundForm.clue.Show()
                    'roundForm.clue.BringToFront()
                    'roundForm.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    roundForm.Timer7.Start()
                ElseIf (e.Result.Text.Contains("400")) Then
                    catstring = e.Result.Text.Replace("400", "").Replace("for", "")
                    currentPointValue = 400
                    loadclueBoardXML(catstring, 400)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'roundForm.PointValueBox.Show()
                    'roundForm.PointValueBox.Image = My.Resources.Screen400
                    roundForm.clue.Show()
                    'roundForm.clue.BringToFront()
                    'roundForm.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    roundForm.Timer7.Start()
                ElseIf (e.Result.Text.Contains("600")) Then
                    catstring = e.Result.Text.Replace("600", "").Replace("for", "")
                    currentPointValue = 600
                    loadclueBoardXML(catstring, 600)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'roundForm.PointValueBox.Show()
                    'roundForm.PointValueBox.Image = My.Resources.Screen600
                    roundForm.clue.Show()
                    'roundForm.clue.BringToFront()
                    'roundForm.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    roundForm.Timer7.Start()
                ElseIf (e.Result.Text.Contains("800")) Then
                    catstring = e.Result.Text.Replace("800", "").Replace("for", "")
                    currentPointValue = 800
                    loadclueBoardXML(catstring, 800)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'roundForm.PointValueBox.Show()
                    'roundForm.PointValueBox.Image = My.Resources.Screen800
                    roundForm.clue.Show()
                    'roundForm.clue.BringToFront()
                    'roundForm.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    roundForm.Timer7.Start()
                ElseIf (e.Result.Text.Contains("1000")) Then
                    catstring = e.Result.Text.Replace("1000", "").Replace("for", "")
                    currentPointValue = 1000
                    loadclueBoardXML(catstring, 1000)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'roundForm.PointValueBox.Show()
                    'roundForm.PointValueBox.Image = My.Resources.Screen1000
                    roundForm.clue.Show()
                    'roundForm.clue.BringToFront()
                    'roundForm.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    roundForm.Timer7.Start()
                End If
                'ElseIf Not (jSpeechRecog.seenclues.Contains(e.Result.Text)) And e.Result.Confidence < 0.94 Then
                '    frmScore.notifyBar.Text = "Speech may have been misinterpreted. Please try again."
                '    Try
                '        jSpeechRecog.SetInputToDefaultAudioDevice()
                '        jSpeechRecog.Recognize()
                '    Catch ex As Exception
                '        MsgBox(ex.Message)
                '        jSpeechRecog.RecognizeAsyncCancel()
                '        jSpeechRecog.recognizerOn = False
                '    End Try
            End If
            Dim blankTilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\BlankTile.png"
            'MsgBox(clueID)
            'CType(roundForm.Controls(clueID), PictureBox).Load(blankTilePath)
            'roundForm.Controls(clueID).Enabled = False
            If clueID = "Cat1200" Then
                roundForm.Cat1200.Load(blankTilePath)
                roundForm.Cat1200.Enabled = False
            ElseIf clueID = "Cat1400" Then
                roundForm.Cat1400.Load(blankTilePath)
                roundForm.Cat1400.Enabled = False
            ElseIf clueID = "Cat1600" Then
                roundForm.Cat1600.Load(blankTilePath)
                roundForm.Cat1600.Enabled = False
            ElseIf clueID = "Cat1800" Then
                roundForm.Cat1800.Load(blankTilePath)
                roundForm.Cat1800.Enabled = False
            ElseIf clueID = "Cat11000" Then
                roundForm.Cat11000.Load(blankTilePath)
                roundForm.Cat11000.Enabled = False
            ElseIf clueID = "Cat2200" Then
                roundForm.Cat2200.Load(blankTilePath)
                roundForm.Cat2200.Enabled = False
            ElseIf clueID = "Cat2400" Then
                roundForm.Cat2400.Load(blankTilePath)
                roundForm.Cat2400.Enabled = False
            ElseIf clueID = "Cat2600" Then
                roundForm.Cat2600.Load(blankTilePath)
                roundForm.Cat2600.Enabled = False
            ElseIf clueID = "Cat2800" Then
                roundForm.Cat2800.Load(blankTilePath)
                roundForm.Cat2800.Enabled = False
            ElseIf clueID = "Cat21000" Then
                roundForm.Cat21000.Load(blankTilePath)
                roundForm.Cat21000.Enabled = False
            ElseIf clueID = "Cat3200" Then
                roundForm.Cat3200.Load(blankTilePath)
                roundForm.Cat3200.Enabled = False
            ElseIf clueID = "Cat3400" Then
                roundForm.Cat3400.Load(blankTilePath)
                roundForm.Cat3400.Enabled = False
            ElseIf clueID = "Cat3600" Then
                roundForm.Cat3600.Load(blankTilePath)
                roundForm.Cat3600.Enabled = False
            ElseIf clueID = "Cat3800" Then
                roundForm.Cat3800.Load(blankTilePath)
                roundForm.Cat3800.Enabled = False
            ElseIf clueID = "Cat31000" Then
                roundForm.Cat31000.Load(blankTilePath)
                roundForm.Cat31000.Enabled = False
            ElseIf clueID = "Cat4200" Then
                roundForm.Cat4200.Load(blankTilePath)
                roundForm.Cat4200.Enabled = False
            ElseIf clueID = "Cat4400" Then
                roundForm.Cat4400.Load(blankTilePath)
                roundForm.Cat4400.Enabled = False
            ElseIf clueID = "Cat4600" Then
                roundForm.Cat4600.Load(blankTilePath)
                roundForm.Cat4600.Enabled = False
            ElseIf clueID = "Cat4800" Then
                roundForm.Cat4800.Load(blankTilePath)
                roundForm.Cat4800.Enabled = False
            ElseIf clueID = "Cat41000" Then
                roundForm.Cat41000.Load(blankTilePath)
                roundForm.Cat41000.Enabled = False
            ElseIf clueID = "Cat5200" Then
                roundForm.Cat5200.Load(blankTilePath)
                roundForm.Cat5200.Enabled = False
            ElseIf clueID = "Cat5400" Then
                roundForm.Cat5400.Load(blankTilePath)
                roundForm.Cat5400.Enabled = False
            ElseIf clueID = "Cat5600" Then
                roundForm.Cat5600.Load(blankTilePath)
                roundForm.Cat5600.Enabled = False
            ElseIf clueID = "Cat5800" Then
                roundForm.Cat5800.Load(blankTilePath)
                roundForm.Cat5800.Enabled = False
            ElseIf clueID = "Cat51000" Then
                roundForm.Cat51000.Load(blankTilePath)
                roundForm.Cat51000.Enabled = False
            ElseIf clueID = "Cat6200" Then
                roundForm.Cat6200.Load(blankTilePath)
                roundForm.Cat6200.Enabled = False
            ElseIf clueID = "Cat6400" Then
                roundForm.Cat6400.Load(blankTilePath)
                roundForm.Cat6400.Enabled = False
            ElseIf clueID = "Cat6600" Then
                roundForm.Cat6600.Load(blankTilePath)
                roundForm.Cat6600.Enabled = False
            ElseIf clueID = "Cat6800" Then
                roundForm.Cat6800.Load(blankTilePath)
                roundForm.Cat6800.Enabled = False
            ElseIf clueID = "Cat61000" Then
                roundForm.Cat61000.Load(blankTilePath)
                roundForm.Cat61000.Enabled = False
            End If
            jSpeechRecog.RecognizeAsyncCancel()
        End If
    End Sub
#End Region
#Region "Recongition Failed Event"
    Private Shared Sub recfailed(sender As Object, e As System.Speech.Recognition.RecognitionEventArgs) Handles jSpeechRecog.SpeechRecognitionRejected
        jSpeechRecog.RecognizeAsyncCancel()
    End Sub
#End Region
#Region "Seconds Converter"
    Public Shared Function convertTime(time As Integer) As Integer
        'Dim i As Integer = 1
        If time = 59 Then
            Return 4
        Else
            Return time + 5
        End If
    End Function
#End Region
#Region "Seconds Converter"
    Public Shared Function convertTimeCatChooserAudio(time As Integer) As Integer
        'Dim i As Integer = 1
        If time = 59 Then
            Return 1
        Else
            Return time + 2
        End If
    End Function
#End Region
#Region "Load Categories from Database"
    Public Shared Sub loadClues(packName As String, round As roundType)
        Dim roundNumber As Integer
        If categoryScreen.Visible = True Then
            roundNumber = 1
            'ElseIf djcategoryScreen.Visible = True Then
            '    roundNumber = 2
        End If
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Clueboard WHERE packName = @PackName and round = @RoundNumber"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim roundParam As SqlParameter = New SqlParameter("@RoundNumber", roundNumber)
        connClues.Open()
        cmd = New SqlCommand(strSQL, connClues)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(roundParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        categoryListSorted.Clear()
        clueList.Clear()
        Do While rdr.Read()
            Dim category As String = Trim(rdr("categoryName").ToString())
            Dim clueID As String = "Cat" & Trim(rdr("categoryNumber").ToString()) & Trim(rdr("pointValue").ToString())
            Dim clue As String = Trim(rdr("clue").ToString())
            categoryListSorted.Add(clueID.Replace("Cat", ""), category)
            clueList.Add(clueID, clue)
            If Not roundForm.CategoryDisplay1.categoryList.Contains(category) Then
                roundForm.CategoryDisplay1.addCategory(category)
            End If
        Loop
        connClues.Close()
    End Sub
#End Region
#Region "Load Clue Answers with XML"
    Public Shared Sub loadclueBoardXML(category As String, value As Integer)
        Dim xmldoc As New XmlDocument
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim str As String
        Dim str2 As String
        Dim str3 As String
        Dim str4 As String
        Dim str5 As String
        Dim str6 As String
        Dim str7 As String
        Dim str8 As String
        Dim str9 As String
        Dim strReplaced As String
        Dim str2Replaced As String
        Dim str3Replaced As String
        Dim str4Replaced As String
        Dim str5Replaced As String
        Dim str6Replaced As String
        Dim str7Replaced As String
        Dim str8Replaced As String
        Dim str9Replaced As String
        Dim fs As New FileStream("C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" + "\JeopardyMain.xml", FileMode.Open, FileAccess.Read)
        Dim XMLStringList As New List(Of String)
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName("clue")
        For i = 0 To xmlnode.Count - 1
            If xmlnode(i).ChildNodes.Item(0).InnerText.Trim().Replace("_", " ") = category And xmlnode(i).ChildNodes.Item(1).InnerText.Trim() = value.ToString() Then
                jSpeechRecog.RecognizeAsyncCancel()
                str = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                str2 = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                str3 = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
                str4 = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
                str5 = xmlnode(i).ChildNodes.Item(4).InnerText.Trim()
                Try
                    If Not xmlnode(i).ChildNodes.Item(5).InnerText.Trim() = Nothing Then
                        str6 = xmlnode(i).ChildNodes.Item(5).InnerText.Trim()
                    Else
                    End If
                Catch ex As Exception

                End Try
                Try
                    If Not xmlnode(i).ChildNodes.Item(6).InnerText.Trim() = Nothing Then
                        str7 = xmlnode(i).ChildNodes.Item(6).InnerText.Trim()
                    Else
                    End If
                Catch ex As Exception

                End Try
                Try
                    If Not xmlnode(i).ChildNodes.Item(7).InnerText.Trim() = Nothing Then
                        str8 = xmlnode(i).ChildNodes.Item(7).InnerText.Trim()
                    Else
                    End If
                Catch ex As Exception

                End Try
                Try
                    If Not xmlnode(i).ChildNodes.Item(8).InnerText.Trim() = Nothing Then
                        str9 = xmlnode(i).ChildNodes.Item(8).InnerText.Trim()
                    Else
                    End If
                Catch ex As Exception

                End Try

                strReplaced = str.Replace("_", " ")
                str2Replaced = str2.Replace("_", " ")
                str3Replaced = str3.Replace("_", " ")
                str4Replaced = str4.Replace("_", " ")
                str5Replaced = str5.Replace("_", " ")
                If Not str6 = Nothing Then
                    str6Replaced = str6.Replace("_", " ")
                    XMLStringList.Add(str6Replaced)
                Else
                End If
                If Not str7 = Nothing Then
                    str7Replaced = str7.Replace("_", " ")
                    XMLStringList.Add(str7Replaced)
                Else
                End If
                If Not str8 = Nothing Then
                    str8Replaced = str8.Replace("_", " ")
                    XMLStringList.Add(str8Replaced)
                Else
                End If
                If Not str9 = Nothing Then
                    str9Replaced = str9.Replace("_", " ")
                    XMLStringList.Add(str9Replaced)
                Else
                End If
                currentAnswer = str4Replaced
                clueLocation = str3Replaced
                clueID = str5Replaced
                XMLStringList.Add(currentAnswer)
                jSpeechRecog.addToList(XMLStringList, JeopardySpeechRecognizer.LoadCommand.Clue)
                'roundForm.clue.Load(str3Replaced)
                roundForm.clue.Show()
            Else

            End If
        Next
        VariableTesting.rtbCurrentAnswers.Clear()
        'Dim clueListFromArray As New List(Of String)
        'clueListFromArray = jSpeechRecog.cluelist.ToList()
        'For Each element As String In jSpeechRecog.cluelist
        '    VariableTesting.rtbCurrentAnswers.AppendText(element + Environment.NewLine())
        'Next
        For i = 0 To XMLStringList.Count - 1
            VariableTesting.rtbCurrentAnswers.AppendText(XMLStringList.Item(i).ToString + Environment.NewLine())
        Next
        jSpeechRecog.loadGrammarObject(JeopardySpeechRecognizer.LoadCommand.Clue)
        jSpeechRecog.RecognizeAsyncCancel()
    End Sub
#End Region
#Region "Load Clue Answers Manual with XML"
    Public Shared Sub loadclueBoardXMLManual(category As String, value As Integer)
        Dim xmldoc As New XmlDocument
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim str As String
        Dim str2 As String
        Dim str3 As String
        Dim str4 As String
        Dim str5 As String
        Dim str6 As String
        Dim str7 As String
        Dim str8 As String
        Dim str9 As String
        Dim strReplaced As String
        Dim str2Replaced As String
        Dim str3Replaced As String
        Dim str4Replaced As String
        Dim str5Replaced As String
        Dim str6Replaced As String
        Dim str7Replaced As String
        Dim str8Replaced As String
        Dim str9Replaced As String
        Dim fs As New FileStream("C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" + "\JeopardyMain.xml", FileMode.Open, FileAccess.Read)
        Dim XMLStringList As New List(Of String)
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName("clue")
        For i = 0 To xmlnode.Count - 1
            If xmlnode(i).ChildNodes.Item(0).InnerText.Trim().Replace("_", " ") = category And xmlnode(i).ChildNodes.Item(1).InnerText.Trim() = value.ToString() Then
                jSpeechRecog.RecognizeAsyncCancel()
                str = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                str2 = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                str3 = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
                str4 = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
                str5 = xmlnode(i).ChildNodes.Item(4).InnerText.Trim()
                Try
                    If Not xmlnode(i).ChildNodes.Item(5).InnerText.Trim() = Nothing Then
                        str6 = xmlnode(i).ChildNodes.Item(5).InnerText.Trim()
                    Else
                    End If
                Catch ex As Exception

                End Try
                strReplaced = str.Replace("_", " ")
                str2Replaced = str2.Replace("_", " ")
                str3Replaced = str3.Replace("_", " ")
                str4Replaced = str4.Replace("_", " ")
                str5Replaced = str5.Replace("_", " ")
                'If Not str6 = Nothing Then
                'str6Replaced = str6.Replace("_", " ")
                '    XMLStringList.Add(str6Replaced)
                'Else
                'End If
                'If Not str7 = Nothing Then
                '    str7Replaced = str7.Replace("_", " ")
                '    XMLStringList.Add(str7Replaced)
                'Else
                'End If
                'If Not str8 = Nothing Then
                '    str8Replaced = str8.Replace("_", " ")
                '    XMLStringList.Add(str8Replaced)
                'Else
                'End If
                'If Not str9 = Nothing Then
                '    str9Replaced = str9.Replace("_", " ")
                '    XMLStringList.Add(str9Replaced)
                'Else
                'End If
                currentAnswer = str4Replaced
                clueLocation = str3Replaced
                clueID = str5Replaced
                'XMLStringList.Add(currentAnswer)
                'roundForm.clue.Load(str3Replaced)
                If str6 = "false" Then
                    roundForm.clue.Show()
                ElseIf str6 = "true" Then
                    frmScore.IsDailyDouble = True
                    DailyDouble.Show()
                Else
                    roundForm.clue.Show()
                End If
            Else

            End If
        Next
        Dim blankTilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\BlankTile.png"
        'MsgBox(clueID)
        CType(roundForm.categoryPanel.Controls(clueID), PictureBox).Load(blankTilePath)
        CType(roundForm.categoryPanel.Controls(clueID), PictureBox).Enabled = False
        roundForm.rtbSeenClues.AppendText(clueID + vbCrLf)
        roundForm.rtbSeenClues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        frmScore.btnGo.Show()
    End Sub
#End Region
#Region "Load Clue Manual without XML"
    Public Shared Sub loadClue(clueID As String)
        'roundForm.clue.Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\" + clueID + ".png")
        roundForm.clue.Show()
        roundForm.clue.lblClue.Text = clueList.Item(clueID)
        'Dim blankTilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\BlankTile.png"
        'MsgBox(clueID)
        CType(roundForm.categoryPanel.Controls(clueID), PictureBox).Image = My.Resources.BlankTile
        CType(roundForm.categoryPanel.Controls(clueID), PictureBox).Enabled = False
        'If clueID = "Cat1200" Then
        '    roundForm.Cat1200.Load(blankTilePath)
        '    roundForm.Cat1200.Enabled = False
        'ElseIf clueID = "Cat1400" Then
        '    roundForm.Cat1400.Load(blankTilePath)
        '    roundForm.Cat1400.Enabled = False
        'ElseIf clueID = "Cat1600" Then
        '    roundForm.Cat1600.Load(blankTilePath)
        '    roundForm.Cat1600.Enabled = False
        'ElseIf clueID = "Cat1800" Then
        '    roundForm.Cat1800.Load(blankTilePath)
        '    roundForm.Cat1800.Enabled = False
        'ElseIf clueID = "Cat11000" Then
        '    roundForm.Cat11000.Load(blankTilePath)
        '    roundForm.Cat11000.Enabled = False
        'ElseIf clueID = "Cat2200" Then
        '    roundForm.Cat2200.Load(blankTilePath)
        '    roundForm.Cat2200.Enabled = False
        'ElseIf clueID = "Cat2400" Then
        '    roundForm.Cat2400.Load(blankTilePath)
        '    roundForm.Cat2400.Enabled = False
        'ElseIf clueID = "Cat2600" Then
        '    roundForm.Cat2600.Load(blankTilePath)
        '    roundForm.Cat2600.Enabled = False
        'ElseIf clueID = "Cat2800" Then
        '    roundForm.Cat2800.Load(blankTilePath)
        '    roundForm.Cat2800.Enabled = False
        'ElseIf clueID = "Cat21000" Then
        '    roundForm.Cat21000.Load(blankTilePath)
        '    roundForm.Cat21000.Enabled = False
        'ElseIf clueID = "Cat3200" Then
        '    roundForm.Cat3200.Load(blankTilePath)
        '    roundForm.Cat3200.Enabled = False
        'ElseIf clueID = "Cat3400" Then
        '    roundForm.Cat3400.Load(blankTilePath)
        '    roundForm.Cat3400.Enabled = False
        'ElseIf clueID = "Cat3600" Then
        '    roundForm.Cat3600.Load(blankTilePath)
        '    roundForm.Cat3600.Enabled = False
        'ElseIf clueID = "Cat3800" Then
        '    roundForm.Cat3800.Load(blankTilePath)
        '    roundForm.Cat3800.Enabled = False
        'ElseIf clueID = "Cat31000" Then
        '    roundForm.Cat31000.Load(blankTilePath)
        '    roundForm.Cat31000.Enabled = False
        'ElseIf clueID = "Cat4200" Then
        '    roundForm.Cat4200.Load(blankTilePath)
        '    roundForm.Cat4200.Enabled = False
        'ElseIf clueID = "Cat4400" Then
        '    roundForm.Cat4400.Load(blankTilePath)
        '    roundForm.Cat4400.Enabled = False
        'ElseIf clueID = "Cat4600" Then
        '    roundForm.Cat4600.Load(blankTilePath)
        '    roundForm.Cat4600.Enabled = False
        'ElseIf clueID = "Cat4800" Then
        '    roundForm.Cat4800.Load(blankTilePath)
        '    roundForm.Cat4800.Enabled = False
        'ElseIf clueID = "Cat41000" Then
        '    roundForm.Cat41000.Load(blankTilePath)
        '    roundForm.Cat41000.Enabled = False
        'ElseIf clueID = "Cat5200" Then
        '    roundForm.Cat5200.Load(blankTilePath)
        '    roundForm.Cat5200.Enabled = False
        'ElseIf clueID = "Cat5400" Then
        '    roundForm.Cat5400.Load(blankTilePath)
        '    roundForm.Cat5400.Enabled = False
        'ElseIf clueID = "Cat5600" Then
        '    roundForm.Cat5600.Load(blankTilePath)
        '    roundForm.Cat5600.Enabled = False
        'ElseIf clueID = "Cat5800" Then
        '    roundForm.Cat5800.Load(blankTilePath)
        '    roundForm.Cat5800.Enabled = False
        'ElseIf clueID = "Cat51000" Then
        '    roundForm.Cat51000.Load(blankTilePath)
        '    roundForm.Cat51000.Enabled = False
        'ElseIf clueID = "Cat6200" Then
        '    roundForm.Cat6200.Load(blankTilePath)
        '    roundForm.Cat6200.Enabled = False
        'ElseIf clueID = "Cat6400" Then
        '    roundForm.Cat6400.Load(blankTilePath)
        '    roundForm.Cat6400.Enabled = False
        'ElseIf clueID = "Cat6600" Then
        '    roundForm.Cat6600.Load(blankTilePath)
        '    roundForm.Cat6600.Enabled = False
        'ElseIf clueID = "Cat6800" Then
        '    roundForm.Cat6800.Load(blankTilePath)
        '    roundForm.Cat6800.Enabled = False
        'ElseIf clueID = "Cat61000" Then
        '    roundForm.Cat61000.Load(blankTilePath)
        '    roundForm.Cat61000.Enabled = False
        'End If
        roundForm.rtbSeenClues.AppendText(clueID + vbCrLf)
        roundForm.rtbSeenClues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        roundForm.timeOutTimer.Start()
        frmScore.btnGo.Show()

    End Sub
#End Region
#Region "Check If Cateogry Mode Is True"
    Public Shared Sub checkIfSelectCategory()
        If jSpeechRecog.categoryMode = True Then
            'jSpeechRecog.RecognizeAsyncCancel()
            If My.Computer.Keyboard.CtrlKeyDown = True OrElse My.Computer.Keyboard.AltKeyDown = True OrElse My.Computer.Keyboard.ShiftKeyDown = True Then
                Try
                    jSpeechRecog.SetInputToDefaultAudioDevice()
                    jSpeechRecog.Recognize()
                    'roundForm.Timer13.Stop()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                End Try
            Else
                jSpeechRecog.RecognizeAsyncCancel()
            End If
        ElseIf jSpeechRecog.categoryMode = False And jSpeechRecog.QuestionMode = False And jSpeechRecog.allowCatMode = True Then
            'jSpeechRecog.RecognizeAsyncCancel()
            jSpeechRecog.categoryMode = True
            If My.Computer.Keyboard.CtrlKeyDown = True OrElse My.Computer.Keyboard.AltKeyDown = True OrElse My.Computer.Keyboard.ShiftKeyDown = True Then
                Try
                    jSpeechRecog.SetInputToDefaultAudioDevice()
                    jSpeechRecog.Recognize()
                    'roundForm.Timer13.Stop()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                End Try
            Else
                jSpeechRecog.RecognizeAsyncCancel()
            End If
        ElseIf jSpeechRecog.categoryMode = False And jSpeechRecog.QuestionMode = False And jSpeechRecog.allowCatMode = False Then
            'roundForm.Timer13.Stop()
            jSpeechRecog.RecognizeAsyncCancel()
        Else
            jSpeechRecog.RecognizeAsyncCancel()
        End If
    End Sub
#End Region
#Region "Check if Double Jeopardy"
    Public Shared Sub checkDoubleJeopardy()
        If roundForm.cat1Title.display = False And roundForm.cat2Title.display = False And roundForm.cat3Title.display = False And roundForm.cat4Title.display = False And roundForm.cat5Title.display = False And roundForm.cat6Title.display = False Then
            jSpeechRecog.categoryMode = False
            jSpeechRecog.allowCatMode = False
            jSpeechRecog.QuestionMode = False
            jSpeechRecog.RecognizeAsyncCancel()
            frmScore.btnDoubleJeopardy.Show()
        End If
    End Sub
#End Region
#Region "Check if Final Jeopardy"
    Public Shared Sub checkFinalJeopardy()
        If roundForm.cat1Title.display = False And roundForm.cat2Title.display = False And roundForm.cat3Title.display = False And roundForm.cat4Title.display = False And roundForm.cat5Title.display = False And roundForm.cat6Title.display = False Then
            jSpeechRecog.categoryMode = False
            jSpeechRecog.allowCatMode = False
            jSpeechRecog.QuestionMode = False
            jSpeechRecog.RecognizeAsyncCancel()
            frmScore.btnFinalJeopardy.Show()
        End If
    End Sub
#End Region
#Region "Load Final Jeopardy"
    Public Shared Sub loadFinalJeopardy()
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "C:\Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Clueboard WHERE packName = @PackName and round = @RoundNumber"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim roundParam As SqlParameter = New SqlParameter("@RoundNumber", 3)
        connClues.Open()
        cmd = New SqlCommand(strSQL, connClues)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(roundParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            Dim category As String = Trim(rdr("categoryName").ToString())
            Dim clue As String = Trim(rdr("clue").ToString())
            FinalJeopardy.CategoryTitle1.category = category
            FinalJeopardy.ClueDisplayScreen1.clueDisplay = clue
        Loop
        connClues.Close()
    End Sub
#End Region
#Region "Check if the Category has Been Cleared"
    Public Shared Sub checkIfCategoryCleared()
        jSpeechRecog.RecognizeAsyncCancel()
        If roundForm.Cat1200.Enabled = False And roundForm.Cat1400.Enabled = False And roundForm.Cat1600.Enabled = False And roundForm.Cat1800.Enabled = False And roundForm.Cat11000.Enabled = False Then
            roundForm.cat1Title.display = False
        End If
        If roundForm.Cat2200.Enabled = False And roundForm.Cat2400.Enabled = False And roundForm.Cat2600.Enabled = False And roundForm.Cat2800.Enabled = False And roundForm.Cat21000.Enabled = False Then
            roundForm.cat2Title.display = False
        End If
        If roundForm.Cat3200.Enabled = False And roundForm.Cat3400.Enabled = False And roundForm.Cat3600.Enabled = False And roundForm.Cat3800.Enabled = False And roundForm.Cat31000.Enabled = False Then
            roundForm.cat3Title.display = False
        End If
        If roundForm.Cat4200.Enabled = False And roundForm.Cat4400.Enabled = False And roundForm.Cat4600.Enabled = False And roundForm.Cat4800.Enabled = False And roundForm.Cat41000.Enabled = False Then
            roundForm.cat4Title.display = False
        End If
        If roundForm.Cat5200.Enabled = False And roundForm.Cat5400.Enabled = False And roundForm.Cat5600.Enabled = False And roundForm.Cat5800.Enabled = False And roundForm.Cat51000.Enabled = False Then
            roundForm.cat5Title.display = False
        End If
        If roundForm.Cat6200.Enabled = False And roundForm.Cat6400.Enabled = False And roundForm.Cat6600.Enabled = False And roundForm.Cat6800.Enabled = False And roundForm.Cat61000.Enabled = False Then
            roundForm.cat6Title.display = False
        End If
    End Sub
#End Region
#Region "Check if All Categories Revealed"
    Public Shared Sub checkIfCategoriesRevealed()
        If roundForm.CategoryDisplay1.displayFinished = True Then
            roundForm.CategoryDisplay1.Visible = False
            roundForm.cat1Title.category = roundForm.CategoryDisplay1.categoryList(0)
            roundForm.cat2Title.category = roundForm.CategoryDisplay1.categoryList(1)
            roundForm.cat3Title.category = roundForm.CategoryDisplay1.categoryList(2)
            roundForm.cat4Title.category = roundForm.CategoryDisplay1.categoryList(3)
            roundForm.cat5Title.category = roundForm.CategoryDisplay1.categoryList(4)
            roundForm.cat6Title.category = roundForm.CategoryDisplay1.categoryList(5)
            categoryMode = True
            questionMode = False
            jSpeechRecog.categoryMode = True
            jSpeechRecog.allowCatMode = True
            jSpeechRecog.RecognizeAsyncCancel()
            roundForm.CategoryDisplay1.Visible = False
            roundForm.Timer1.Stop()
            roundForm.Timer2.Stop()
            frmScore.Show()
            frmScore.BringToFront()
        End If
    End Sub
#End Region
#Region "Perform Category Reveal"
    Public Shared Sub performCategoryReveal()
        If catChooser.finished = True Then
            catChooser.Close()
            roundForm.CategoryDisplay1.Show()
            roundForm.ProgressBar1.PerformStep()
            If Not roundForm.CategoryDisplay1.displayFinished = True And Not bypassCategoryReveal = True Then
                jSpeechRecog.allowCatMode = False
                roundForm.ProgressBar1.Value = 0
                roundForm.CategoryDisplay1.Show()
                jSpeechRecog.RecognizeAsyncCancel()
                roundForm.Timer1.Stop()
                roundForm.Timer2.Start()
            ElseIf roundForm.CategoryDisplay1.displayFinished = True Then
                roundForm.CategoryDisplay1.Visible = False
                roundForm.cat1Title.category = roundForm.CategoryDisplay1.categoryList(0)
                roundForm.cat2Title.category = roundForm.CategoryDisplay1.categoryList(1)
                roundForm.cat3Title.category = roundForm.CategoryDisplay1.categoryList(2)
                roundForm.cat4Title.category = roundForm.CategoryDisplay1.categoryList(3)
                roundForm.cat5Title.category = roundForm.CategoryDisplay1.categoryList(4)
                roundForm.cat6Title.category = roundForm.CategoryDisplay1.categoryList(5)
                categoryMode = True
                questionMode = False
                jSpeechRecog.categoryMode = True
                jSpeechRecog.allowCatMode = True
                jSpeechRecog.RecognizeAsyncCancel()
                roundForm.CategoryDisplay1.Visible = False
                roundForm.Timer1.Stop()
                roundForm.Timer2.Stop()
            ElseIf bypassCategoryReveal = True Then
                roundForm.CategoryDisplay1.Visible = False
                'roundForm.wmpCategory.Ctlcontrols.stop()
                Dim fileReader As System.IO.StreamReader
                fileReader = My.Computer.FileSystem.OpenTextFileReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt")
                roundForm.cat1Title.category = roundForm.CategoryDisplay1.categoryList(0)
                roundForm.cat2Title.category = roundForm.CategoryDisplay1.categoryList(1)
                roundForm.cat3Title.category = roundForm.CategoryDisplay1.categoryList(2)
                roundForm.cat4Title.category = roundForm.CategoryDisplay1.categoryList(3)
                roundForm.cat5Title.category = roundForm.CategoryDisplay1.categoryList(4)
                roundForm.cat6Title.category = roundForm.CategoryDisplay1.categoryList(5)
                Do While fileReader.Peek() > -1
                    Dim fileClueID = fileReader.ReadLine()
                    'MsgBox(fileClueID)
                    CType(roundForm.categoryPanel.Controls(fileClueID), PictureBox).Enabled = False
                    CType(roundForm.categoryPanel.Controls(fileClueID), PictureBox).Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\BlankTile.png")
                Loop
                fileReader.Close()
                frmScore.Show()
                frmScore.BringToFront()
            End If
        Else
        End If
    End Sub
#End Region
#Region "Check if Rung In"
    Public Shared Sub checkIfRungIn()
        If frmScore.Player1RungIn = False And frmScore.Player2RungIn = False And frmScore.Player3RungIn Then
            frmScore.notifyBar.Text = ""
            'jSpeechRecog.RecognizeAsyncCancel()
        End If
        'If roundForm.clue.Visible = True Then
        '    frmScore.notifyBar.Show()
        'ElseIf roundForm.clue.Visible = False Then
        '    frmScore.notifyBar.Hide()
        'End If
    End Sub
#End Region
#Region "Show Point Value Box"
    Public Shared Sub showPointValueBox()
        roundForm.ProgressBar2.PerformStep()
        If roundForm.ProgressBar2.Value = roundForm.ProgressBar2.Maximum Then
            roundForm.ProgressBar2.Value = 0
            'roundForm.PointValueBox.Hide()
            roundForm.Timer4.Stop()
        End If
    End Sub
#End Region
#Region "Manually Set Answer"
    Public Shared Sub setAnswerValue(answer As Boolean)
        If FinalJeopardy.Visible = False Then
            If answer = True Then
                frmScore.notifyBar.Text = ""
                questionMode = False
                categoryMode = True
                If frmScore.txtCurrentPlayer.Text = "Player 1" Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.IsDailyDouble = False
                    End If
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) + currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    roundForm.Timer7.Stop()
                    currentPointValue = 0
                    currentPlayer = 1
                    roundForm.clue.Hide()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.IsDailyDouble = False
                    End If
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) + currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    roundForm.Timer7.Stop()
                    currentPointValue = 0
                    currentPlayer = 2
                    roundForm.clue.Hide()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.IsDailyDouble = False
                    End If
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) + currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    roundForm.Timer7.Stop()
                    currentPointValue = 0
                    currentPlayer = 3
                    roundForm.clue.Hide()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                End If
            ElseIf answer = False Then
                frmScore.notifyBar.Text = ""
                If frmScore.txtCurrentPlayer.Text = "Player 1" Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) - currentPointValue
                        frmScore.IsDailyDouble = False
                        frmScore.txtCurrentPlayer.Clear()
                        roundForm.Timer7.Stop()
                        currentPointValue = 0
                        roundForm.clue.Hide()
                        frmScore.btnYes.Hide()
                        frmScore.btnNo.Hide()
                    Else
                        My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                        frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) - currentPointValue
                        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.txtCurrentPlayer.Clear()
                    End If
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) - currentPointValue
                        frmScore.IsDailyDouble = False
                        frmScore.txtCurrentPlayer.Clear()
                        roundForm.Timer7.Stop()
                        currentPointValue = 0
                        roundForm.clue.Hide()
                        frmScore.btnYes.Hide()
                        frmScore.btnNo.Hide()
                    Else
                        My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                        frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) - currentPointValue
                        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.txtCurrentPlayer.Clear()
                    End If
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) - currentPointValue
                        frmScore.IsDailyDouble = False
                        frmScore.txtCurrentPlayer.Clear()
                        roundForm.Timer7.Stop()
                        currentPointValue = 0
                        roundForm.clue.Hide()
                        frmScore.btnYes.Hide()
                        frmScore.btnNo.Hide()
                    Else
                        My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                        frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) - currentPointValue
                        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.txtCurrentPlayer.Clear()
                    End If
                End If
            End If
        Else
            If answer = True Then
                currentPointValue = CInt(frmScore.txtWager1.Text)
                frmScore.notifyBar.Text = ""
                questionMode = False
                categoryMode = True
                If frmScore.txtCurrentPlayer.Text = "Player 1" Then
                    frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) + currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    'roundForm.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 1
                    frmScore.txtCurrentPlayer.Text = "Player 2"
                    'roundForm.clue.Hide()
                    'frmScore.btnYes.Hide()
                    'frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                    currentPointValue = CInt(frmScore.txtWager2.Text)
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) + currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Text = "Player 3"
                    'roundForm.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 2
                    'roundForm.clue.Hide()
                    'frmScore.btnYes.Hide()
                    'frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                    currentPointValue = CInt(frmScore.txtWager3.Text)
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) + currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    'roundForm.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 3
                    'roundForm.clue.Hide()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                End If
            ElseIf answer = False Then
                frmScore.notifyBar.Text = ""
                If frmScore.txtCurrentPlayer.Text = "Player 1" Then
                    My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                    frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) - currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.txtCurrentPlayer.Text = "Player 2"
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                    My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                    frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) - currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.txtCurrentPlayer.Text = "Player 3"
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                    My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                    frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) - currentPointValue
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.txtCurrentPlayer.Clear()
                End If
            End If
        End If
        If FinalJeopardy.Visible = False Then
            roundForm.rtbPointValues.Clear()
            roundForm.rtbPointValues.AppendText(frmScore.lblPlayer1Score.Text + vbCrLf)
            roundForm.rtbPointValues.AppendText(frmScore.lblPlayer2Score.Text + vbCrLf)
            roundForm.rtbPointValues.AppendText(frmScore.lblPlayer3Score.Text)
            roundForm.rtbPointValues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
        Else
        End If
    End Sub
    Public Shared Sub ifNoRingIn()
        frmScore.Player1RungIn = False
        frmScore.Player2RungIn = False
        frmScore.Player3RungIn = False
        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
        frmScore.txtCurrentPlayer.Clear()
        roundForm.Timer7.Stop()
        currentPointValue = 0
        currentPlayer = 1
        roundForm.clue.Hide()
        frmScore.btnYes.Hide()
        frmScore.btnNo.Hide()
    End Sub
#End Region
#Region "Check if the Recognition is Stopped"
    Public Shared Sub ifRecogStopped()
        If jSpeechRecog.AudioState = RecognizerState.Stopped And jSpeechRecog.QuestionMode = True Then
            If frmScore.txtCurrentPlayer.Text = "Player 1" Then
                jSpeechRecog.RecognizeAsyncCancel()
                My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
                frmScore.lblPlayer1Score.Text = Integer.Parse(frmScore.lblPlayer1Score.Text) - currentPointValue
                frmScore.notifyBar.Text = frmScore.lblPlayer1.Text + " lost " + currentPointValue.ToString
                frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.txtCurrentPlayer.Clear()
            ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                jSpeechRecog.RecognizeAsyncCancel()
                My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
                frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) - currentPointValue
                frmScore.notifyBar.Text = frmScore.lblPlayer2.Text + " lost " + currentPointValue.ToString
                frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.txtCurrentPlayer.Clear()
            ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                jSpeechRecog.RecognizeAsyncCancel()
                My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
                frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) - currentPointValue
                frmScore.notifyBar.Text = frmScore.lblPlayer3.Text + " lost " + currentPointValue.ToString
                frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                frmScore.txtCurrentPlayer.Clear()
            End If
            If frmScore.txtCurrentPlayer.Text = "" And frmScore.Player1RungIn = True And frmScore.Player2RungIn = True And frmScore.Player3RungIn = True And Not frmScore.IsDailyDouble = True Then
                frmScore.Player1RungIn = False
                frmScore.Player2RungIn = False
                frmScore.Player3RungIn = False
                roundForm.Timer7.Stop()
                roundForm.clue.Hide()
                My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
                'Dim SAPI
                'SAPI = CreateObject("SAPI.spvoice")
                'SAPI.Speak("The correct answer was " + currentAnswer)
                currentPointValue = 0
                jSpeechRecog.RecognizeAsyncCancel()
                jSpeechRecog.recognizerOn = False
                jSpeechRecog.categoryMode = True
                jSpeechRecog.QuestionMode = False
            End If
            roundForm.Timer12.Stop()
        End If
    End Sub
#End Region
#Region "Get & Set Clue ID"
    Public Shared Function getClueID() As String
        Return clueID
    End Function
    Public Shared Sub setClueID(value As String)
        clueID = value
    End Sub
#End Region
#Region "Confirm Speech"
    'Private Sub recPrompt()
    '    recognized = False
    '    jSpeechRecog..RecognizeAsyncCancel()
    '    Select Case MsgBox("Please confirm your speech: " + txtCurrentPlayer.Text + " Is this what you said?", vbYesNo + vbExclamation, "Jeopardy!")
    '        Case MsgBoxResult.Yes
    '            MsgBox("checking the answer.")
    '        Case MsgBoxResult.No
    '            Try
    '                recognized = False
    '                jSpeechRecog..SetInputToDefaultAudioDevice()
    '                jSpeechRecog..Recognize()
    '            Catch ex As Exception
    '                jSpeechRecog..RecognizeAsyncCancel()
    '                MsgBox(ex.Message)
    '                RecognizerOn = False
    '                recognized = False
    '                Timer7.Stop()
    '            End Try
    '    End Select
    'End Sub

    'Public Sub loadBlankTile(clueID As String)
    '    Dim obj As PictureBox = Activator.createInstance(Type.GetType(clueID))
    '    obj.display = False
    '    obj.Enabled = False
    'End Sub
#End Region
End Class
