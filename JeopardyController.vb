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
#Region "Instance Variables"
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
    'Private Shared categoryList As New List(Of String)
    'Public Shared categoryListSorted As New SortedList(Of Integer, String)
    'Private Shared clueList As New SortedList(Of String, String)
    'Private Shared interactiveClueList As New SortedList(Of String, String)
    Public Shared lstClues As New SortedList(Of Integer, Clue)
    Public Shared questionMode As Boolean = False
    Public Shared categoryMode As Boolean = False
    Public Shared bypassCategoryReveal As Boolean = False
    Public Shared doubleJeopardyExists As Boolean = False
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
    Public Shared oldImage As Bitmap = New Bitmap(My.Resources.BlankTile, New Size(164, 89))
    Public Shared newImage200 = New Bitmap(My.Resources.Screen200, New Size(164, 89))
    Public Shared newImage400 = New Bitmap(My.Resources.Screen400, New Size(164, 89))
    Public Shared newImage600 = New Bitmap(My.Resources.Screen600, New Size(164, 89))
    Public Shared newImage800 = New Bitmap(My.Resources.Screen800, New Size(164, 89))
    Public Shared newImage1000 = New Bitmap(My.Resources.Screen1000, New Size(164, 89))
    Public Shared newImage1200 = New Bitmap(My.Resources.Screen1200, New Size(164, 89))
    Public Shared newImage1600 = New Bitmap(My.Resources.Screen1600, New Size(164, 89))
    Public Shared newImage2000 = New Bitmap(My.Resources.Screen2000, New Size(164, 89))
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
    Public Shared roundNumber As Integer = 1
    Public Shared finalURL As String = Application.StartupPath
    Public Shared virtualHost As Boolean = False
    Public Shared SAPI As New SpeechLib.SpVoice
    'Public Shared player1Name As String = "PLAYER 1"
    'Public Shared player2Name As String = "PLAYER 2"
    'Public Shared player3Name As String = "PLAYER 3"
    Public Shared roundEnum As roundType = roundType.Jeopardy
    Public Shared finalCheckStarted As Boolean = False
    Public Shared gameID As Integer
    Public Shared cbID As Integer
    'Public Shared player1Id As Integer
    'Public Shared player2Id As Integer
    'Public Shared player3Id As Integer
    Public Shared quickGame As Boolean = True
    Public Shared finalCheckComplete As Boolean = False
    Public Shared seenClues As New List(Of Clue)
    Public Shared loadGame As Boolean = False
    Public Shared Player1List As New List(Of Player)
    Public Shared Player2List As New List(Of Player)
    Public Shared Player3List As New List(Of Player)
    Public Shared teamDisplayInt As Integer = 0
    Public Shared numberOfPlayers As Integer = 0
    Public Enum clueType
        Regular
        Video
        Image
        Audio
    End Enum
#End Region
#Region "Initialize Game Manual"
    Public Shared Sub initializeGameManual(round As roundType)
        If roundForm.Visible = True Then
            roundForm = CType(roundForm, categoryScreen)
        End If
        If round = roundType.Jeopardy Then
            roundNumber = 1
            roundForm.CategoryDisplay1.pboxJeopardyCard.Image = My.Resources.JEOPARDYLogo
            For i As Integer = 1 To 6
                For j As Integer = 200 To 1000 Step 200
                    roundForm.catListBox.Items.Add("Cat" & i & j)
                Next
            Next
        ElseIf round = roundType.DoubleJeopardy Then
            roundNumber = 2
            roundForm.CategoryDisplay1.pboxJeopardyCard.Image = My.Resources.DOUBLEJeopardy
            For i As Integer = 1 To 6
                For j As Integer = 400 To 2000 Step 400
                    roundForm.catListBox.Items.Add("Cat" & i & j)
                Next
            Next
        ElseIf round = roundType.FinalJeopardy Then
            catChooser.Close()
            loadFinalJeopardy()
            roundNumber = 3
            FinalJeopardy.Show()
            categoryScreen.Close()
            Exit Sub
        End If
        If quickGame = False Then
            frmScore.lblPlayer1.contestantID = Player1List(0).ID
            frmScore.lblPlayer2.contestantID = Player2List(0).ID
            frmScore.lblPlayer3.contestantID = Player3List(0).ID
        End If
        'For Each item As PictureBox In roundForm.categoryPanel.Controls
        '    roundForm.catListBox.Items.Add(item.Name)
        'Next
        'If roundForm.Visible = True Then
        '    loadSets()
        'ElseIf djroundForm.Visible = True Then
        'End If
        loadSets()
        'roundForm.Timer3.Start()
        'roundForm.rtbSeenClues.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        'roundForm.rtbPointValues.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
        'loadcategoryXMLManual()
        roundForm.tmrCheckCurrentRound.Start()
        roundForm.tmrCheckIfRungIn.Start()
        'roundForm.wmpCategory.Ctlcontrols.stop()
        roundForm.cat1Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        roundForm.cat2Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        roundForm.cat3Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        roundForm.cat4Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        roundForm.cat5Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        roundForm.cat6Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        roundEnum = round
        If round = roundType.Jeopardy Then
            roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(1200).category
            roundForm.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(2200).category
            roundForm.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(3200).category
            roundForm.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(4200).category
            roundForm.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(5200).category
            roundForm.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(6200).category
        ElseIf round = roundType.DoubleJeopardy Then
            roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(1400).category
            roundForm.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(2400).category
            roundForm.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(3400).category
            roundForm.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(4400).category
            roundForm.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(5400).category
            roundForm.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(6400).category
        End If
        roundForm.tmrCatReveal.Start()
        roundForm.tmrCheckCatCleared.Start()
        roundForm.clue.clueBrowser.Navigate(Application.StartupPath & "/Resources/clue.html")
    End Sub
#Region "Clueboard Front-End"
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
#Region "Clueboard Reveal Animation"
    Private Shared Sub loadSets()
        If roundForm.Visible = True Then
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
                'Dim newImage As New Bitmap(), New Size(164, 89))
                Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
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
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
                    CType(roundForm.categoryPanel.Controls(set10(i - 1)), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    roundForm.pbarLoadCat.Value += 1
                Next
            End If
            roundForm.PerformLayout()
            'Else
            '    For Each control As Control In DJroundForm.categoryPanel.Controls
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
#End Region
#End Region
#Region "Team Play Methods"
    Public Shared Sub clearTeams()
        Player1List.Clear()
        Player2List.Clear()
        Player3List.Clear()
    End Sub
    Public Shared Function checkID(ID As Integer) As Boolean
        For Each player As Player In Player1List
            If player.ID = ID Then
                Return True
            End If
        Next
        For Each player As Player In Player2List
            If player.ID = ID Then
                Return True
            End If
        Next
        For Each player As Player In Player3List
            If player.ID = ID Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Shared Sub removeByID(ID As Integer)
        For Each player As Player In Player1List
            If player.ID = ID Then
                Player1List.Remove(player)
                Exit For
            End If
        Next
        For Each player As Player In Player2List
            If player.ID = ID Then
                Player2List.Remove(player)
                Exit For
            End If
        Next
        For Each player As Player In Player1List
            If player.ID = ID Then
                Player3List.Remove(player)
                Exit For
            End If
        Next
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
                    roundForm.tmrCheckRecogStopped.Start()
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
                            roundForm.tmrRingIn.Stop()
                        End Try
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                ElseIf My.Computer.Keyboard.AltKeyDown = True And frmScore.Player2RungIn = False Then
                    roundForm.tmrCheckRecogStopped.Start()
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
                            roundForm.tmrRingIn.Stop()
                            'End Try
                            'frmScore.ProgressBar1.PerformStep()
                            'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                            'End If
                        End Try
                    End If
                ElseIf My.Computer.Keyboard.ShiftKeyDown = True And frmScore.Player3RungIn = False Then
                    roundForm.tmrCheckRecogStopped.Start()
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
                            roundForm.tmrRingIn.Stop()
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
            roundForm.tmrRingIn.Stop()
        End If
        'End If
        If frmScore.txtCurrentPlayer.Text = "" And frmScore.Player1RungIn = True And frmScore.Player2RungIn = True And frmScore.Player3RungIn = True And Not frmScore.IsDailyDouble = True Then
            frmScore.Player1RungIn = False
            frmScore.Player2RungIn = False
            frmScore.Player3RungIn = False
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
            Dim SAPI
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak("The correct response was " + currentAnswer)
            jSpeechRecog.categoryMode = True
            jSpeechRecog.QuestionMode = False
            jSpeechRecog.RecognizeAsyncCancel()
            roundForm.tmrRingIn.Stop()
            roundForm.clue.Hide()
            currentPointValue = 0
        ElseIf frmScore.IsDailyDouble = True Then
            frmScore.Player1RungIn = False
            frmScore.Player2RungIn = False
            frmScore.Player3RungIn = False
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
            'Dim SAPI
            'SAPI = CreateObject("SAPI.spvoice")
            'SAPI.Speak("The correct response was " + currentAnswer)
            jSpeechRecog.RecognizeAsyncCancel()
            jSpeechRecog.categoryMode = True
            jSpeechRecog.QuestionMode = False
            roundForm.tmrRingIn.Stop()
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
                    currentPlayer = 1
                    roundForm.clue.wmpClue.Ctlcontrols.stop()
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer1.Text
                    frmScore.lblPlayer1.BackgroundImage = Nothing
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
                        frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer1.Text
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                    If virtualHost = True Then
                        Try
                            SAPI.Speak(frmScore.lblPlayer1.Text)
                        Catch ex As Exception
                        End Try
                    End If
                ElseIf My.Computer.Keyboard.AltKeyDown = True And frmScore.Player2RungIn = False Then
                    currentPlayer = 2
                    roundForm.clue.wmpClue.Ctlcontrols.stop()
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'roundForm.Timer12.Start()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer2.Text
                    frmScore.lblPlayer2.BackgroundImage = Nothing
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.Player2RungIn = True
                    If frmScore.Player2RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer2.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text
                    End If
                    If virtualHost = True Then
                        Try
                            SAPI.Speak(frmScore.lblPlayer2.Text)
                        Catch ex As Exception
                        End Try
                    End If
                ElseIf My.Computer.Keyboard.ShiftKeyDown = True And frmScore.Player3RungIn = False Then
                    currentPlayer = 3
                    roundForm.clue.wmpClue.Ctlcontrols.stop()
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'roundForm.Timer12.Start()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer3.Text
                    frmScore.lblPlayer3.BackgroundImage = Nothing
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.Player3RungIn = True
                    If frmScore.Player3RungIn = True Then
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")
                        'SAPI.Speak(frmScore.lblPlayer3.Text)
                        'frmScore.Timer2.Start()
                        frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                    If virtualHost = True Then
                        Try
                            SAPI.Speak(frmScore.lblPlayer3.Text)
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
        ElseIf categoryMode = True Then
            roundForm.tmrRingIn.Stop()
        End If
        'End If
        If frmScore.txtCurrentPlayer.Text = "" And frmScore.Player1RungIn = True And frmScore.Player2RungIn = True And frmScore.Player3RungIn = True And Not frmScore.IsDailyDouble = True Then
            frmScore.Player1RungIn = False
            frmScore.Player2RungIn = False
            frmScore.Player3RungIn = False
            My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\timesup.wav")
            'Dim SAPI
            'SAPI = CreateObject("SAPI.spvoice")
            'If virtualHost = True And False = True Then
            '    SAPI.Speak("The correct answer was " + currentAnswer)
            'End If
            categoryMode = True
            questionMode = False
            roundForm.tmrRingIn.Stop()
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
            roundForm.tmrRingIn.Stop()
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
                    roundForm.tmrRingIn.Stop()
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
                    roundForm.tmrRingIn.Stop()
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
                    roundForm.tmrRingIn.Stop()
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
                    roundForm.tmrRingIn.Start()
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
                    roundForm.tmrRingIn.Start()
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
                    roundForm.tmrRingIn.Start()
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
                    roundForm.tmrRingIn.Start()
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
                    roundForm.tmrRingIn.Start()
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
#Region "Seconds Converter +1"
    Public Shared Function convertTimePlus1(time As Integer) As Integer
        'Dim i As Integer = 1
        If time = 59 Then
            Return 1
        Else
            Return time + 1
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
#Region "Load Categories from XML"
    Private Shared Sub loadcategoryXML()
        Dim xmldoc As New XmlDocument
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim str As String
        Dim str2 As String
        Dim strReplaced As String
        Dim str2Replaced As String
        Dim fs As New FileStream("C: \Users\ac765\Documents\Visual Studio 2015\Projects\Jeopardy\Jeopardy\bin\Debug" + "\JeopardyMain.xml", FileMode.Open, FileAccess.Read)
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
#Region "Load Categories from Database"
    Public Shared Sub loadClues(packName As String, round As roundType)
        Dim roundNumber As Integer
        If roundForm.Visible = True Then
            roundNumber = 1
            'ElseIf djroundForm.Visible = True Then
            '    roundNumber = 2
        End If
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String = "SELECT * FROM Clueboard WHERE packName = @PackName and round = @RoundNumber"
        Dim strDoubleJeopardySQL As String = "SELECT * FROM Clueboard WHERE packName = @PackName and round = @RoundNumber"
        Dim cmd As SqlCommand
        Dim djcmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim djrdr As SqlDataReader
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim roundParam As SqlParameter = New SqlParameter("@RoundNumber", roundNumber)
        Dim djpackNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim djroundParam As SqlParameter = New SqlParameter("@RoundNumber", 2)
        connClues.Open()
        cmd = New SqlCommand(strSQL, connClues)
        cmd.Parameters.Add(packNameParam)
        cmd.Parameters.Add(roundParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        lstClues.Clear()
        'categoryListSorted.Clear()
        'clueList.Clear()
        Do While rdr.Read()
            Dim category As String = Trim(rdr("categoryName").ToString())
            Dim clueValue As Integer = rdr("pointValue")
            Dim cbID As Integer = rdr("Id")
            Dim clueID As String = "Cat" & Trim(rdr("categoryNumber").ToString()) & Trim(rdr("pointValue").ToString())
            Dim clue As String = Trim(rdr("clue").ToString()).Replace(vbCrLf, "<br />")
            Dim clueLocation As String = Trim(rdr("interactiveClueLocation").ToString())
            Dim dailyDoubleValue As Integer = Trim(rdr("DailyDouble").ToString())
            Dim dailyDoubleBoolean As Boolean
            If dailyDoubleValue = 0 Then
                dailyDoubleBoolean = False
            Else
                dailyDoubleBoolean = True
            End If
            Dim newClue = New Clue(cbID, category, clueValue, clue, clueID, dailyDoubleBoolean, clueLocation)
            lstClues.Add(clueID.Replace("Cat", ""), newClue)
            'If checkClueList(cbID) = True Then
            '    CType(roundForm.categoryPanel.Controls(convertClueID(clueID)), PictureBox).Image = My.Resources.BlankTile
            '    CType(roundForm.categoryPanel.Controls(convertClueID(clueID)), PictureBox).Enabled = False
            'End If
            'categoryListSorted.Add(clueID.Replace("Cat", ""), category)
            'clueList.Add(clueID, clue)
            'If Trim(clueLocation) <> "" Then
            '    interactiveClueList.Add(clueID, clueLocation)
            'End If
            'If Not roundForm.CategoryDisplay1.categoryList.Contains(category) Then
            '    roundForm.CategoryDisplay1.addCategory(category)
            'End If
        Loop
        connClues.Close()
        If roundEnum = roundType.Jeopardy Then
            connClues.Open()
            djcmd = New SqlCommand(strDoubleJeopardySQL, connClues)
            djcmd.Parameters.Add(djpackNameParam)
            djcmd.Parameters.Add(djroundParam)
            djcmd.CommandType = CommandType.Text
            djrdr = djcmd.ExecuteReader()
            If djrdr.HasRows = True Then
                doubleJeopardyExists = True
            End If
        End If
    End Sub
#End Region
#Region "Load Clue Answers with XML w/ Voice Recognition"
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
        Dim fs As New FileStream(Application.StartupPath + "\JeopardyMain.xml", FileMode.Open, FileAccess.Read)
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
#Region "Load Clue Answers with XML w/o Voice Recognition"
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
        Dim fs As New FileStream(Application.StartupPath + "\JeopardyMain.xml", FileMode.Open, FileAccess.Read)
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
        'roundForm.rtbSeenClues.AppendText(clueID + vbCrLf)
        'roundForm.rtbSeenClues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        frmScore.btnGo.Show()
    End Sub
#End Region
#Region "Load Clue Manual without XML"
    Public Shared Sub loadClue(clueID As String)
        roundForm.PointValueBox.Image = My.Resources.ResourceManager.GetObject("Screen" & currentPointValue)
        roundForm.PointValueBox.Show()
        'roundForm.clue.Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\" + clueID + ".png")
        If lstClues(Integer.Parse(clueID.Replace("Cat", ""))).dailyDouble = True Then
            frmScore.IsDailyDouble = True
            DailyDouble.Show()
            frmScore.btnGo.Hide()
        Else
            frmScore.btnGo.Show()
            frmScore.IsDailyDouble = False
        End If
        cbID = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).cbID
        seenClues.Add(lstClues(Integer.Parse(clueID.Replace("Cat", ""))))
        roundForm.clue.Show()
        roundForm.clue.wmpClue.Hide()
        roundForm.clue.pboxClue.Hide()
        roundForm.clue.MiniClue1.Hide()
        roundForm.clue.MiniClue1.Location = New Point(0, 534)
        Dim categoryNumber = clueID.Replace("Cat", "").Substring(0, 1)
        If String.IsNullOrEmpty(lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation) Then
            frmScore.Show()
            roundForm.clue.clueBrowser.Navigate(finalURL & "\Resources\clue.html")
            'roundForm.clue.clueBrowser.Navigate("localhost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
            'roundForm.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
            'roundForm.clue.lblClue.Show()
            'roundForm.clue.lblClue.Text = clueList.Item(clueID)
            roundForm.clue.clueType = clueType.Regular
            'roundForm.clue.MiniClue1.Parent = roundForm.clue
            'roundForm.clue.MiniClue1.BackColor = Color.Black
        Else
            If lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".mp4") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".wmv") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".avi") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".mov") Then
                roundForm.clue.clueBrowser.Navigate(finalURL & "\Resources\interactiveClue.html")
                frmScore.Hide()
                roundForm.clue.lblClue.Hide()
                'roundForm.clue.MiniClue1.lblClue.Text = clueList.Item(clueID)
                'roundForm.clue.MiniClue1.Show()
                'roundForm.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
                'roundForm.clue.wmpClue.Show()
                roundForm.clue.videoClueLocation = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation
                roundForm.clue.clueType = clueType.Video
                'roundForm.clue.MiniClue1.Parent = roundForm.clue
                'roundForm.clue.MiniClue1.BackColor = Color.Black
            ElseIf lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".m4a") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".mp3") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".wav") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".wma") Then
                roundForm.clue.clueBrowser.Navigate(finalURL & "\Resources\clue.html")
                frmScore.Show()
                roundForm.clue.wmpClue.Hide()
                roundForm.clue.wmpClue.URL = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation
                'roundForm.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
                'roundForm.clue.clueBrowser.Navigate("localhost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
                'roundForm.clue.lblClue.Text = clueList.Item(clueID)
                roundForm.clue.wmpClue.Ctlcontrols.stop()
                roundForm.clue.clueType = clueType.Audio
                roundForm.clue.MiniClue1.Parent = roundForm.clue
                roundForm.clue.MiniClue1.BackColor = Color.Black
            ElseIf lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".png") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".jpg") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".bmp") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".gif") Then
                roundForm.clue.clueBrowser.Navigate(finalURL & "\Resources\interactiveClue.html")
                frmScore.Hide()
                roundForm.clue.lblClue.Hide()
                'roundForm.clue.pboxClue.Show()
                roundForm.clue.imgClueLocation = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation
                'roundForm.clue.clueBrowser.Document.GetElementById("interactiveClueString").SetAttribute("src", lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation)
                'roundForm.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:block;"
                'roundForm.clue.clueBrowser.Navigost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
                'roundForm.clue.MiniClue1.lblClue.Text = clueList.Item(clueID)
                'roundForm.clue.MiniClue1.Show()
                'roundForm.clue.MiniClue1.Parent = roundForm.clue.pboxClue
                'roundForm.clue.MiniClue1.BackColor = Color.Transparent
                'roundForm.clue.MiniClue1.Location = New Point(0, 534)
                'roundForm.clue.pboxClue.BackgroundImage = Image.FromFile(lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation)
                roundForm.clue.clueType = clueType.Image
            End If
        End If
        'Dim blankTilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\BlankTile.png"
        'MsgBox(clueID)
        roundForm.clue.clue = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).clue
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
        'roundForm.rtbSeenClues.AppendText(clueID + vbCrLf)
        'roundForm.rtbSeenClues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        roundForm.timeOutTimer.Start()
    End Sub
#End Region
#Region "Check image if same"
    Public Shared Function AreSameImage(ByVal I1 As Image, ByVal I2 As Image) As Boolean
        Dim BM1 As Bitmap = I1
        Dim BM2 As Bitmap = I2
        For X = 0 To BM1.Width - 1
            For y = 0 To BM2.Height - 1
                If Not BM1.GetPixel(X, y) = BM2.GetPixel(X, y) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function
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
        If (roundForm.cat1Title.display = False And roundForm.cat2Title.display = False And roundForm.cat3Title.display = False And roundForm.cat4Title.display = False And roundForm.cat5Title.display = False And roundForm.cat6Title.display = False) And roundEnum = roundType.Jeopardy Then
            'jSpeechRecog.categoryMode = False
            'jSpeechRecog.allowCatMode = False
            'jSpeechRecog.QuestionMode = False
            'jSpeechRecog.RecognizeAsyncCancel()
            frmScore.btnDoubleJeopardy.Show()
        End If
    End Sub
#End Region
#Region "Check if Final Jeopardy"
    Public Shared Sub checkFinalJeopardy()
        If roundForm.cat1Title.display = False And roundForm.cat2Title.display = False And roundForm.cat3Title.display = False And roundForm.cat4Title.display = False And roundForm.cat5Title.display = False And roundForm.cat6Title.display = False Then
            'jSpeechRecog.categoryMode = False
            'jSpeechRecog.allowCatMode = False
            'jSpeechRecog.QuestionMode = False
            'jSpeechRecog.RecognizeAsyncCancel()
            frmScore.btnFinalJeopardy.Show()
        End If
    End Sub
#End Region
#Region "Load Final Jeopardy"
    Public Shared Sub loadFinalJeopardy()
        roundEnum = roundType.FinalJeopardy
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
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
        Dim category As String
        Dim clueStr As String
        Dim interactiveClueLocation As String
        Do While rdr.Read()
            category = Trim(rdr("categoryName").ToString())
            clueStr = Trim(rdr("clue").ToString())
            interactiveClueLocation = Trim(rdr("interactiveClueLocation").ToString())
        Loop
        FinalJeopardy.ClueDisplayScreen1.wmpClue.Hide()
        FinalJeopardy.ClueDisplayScreen1.pboxClue.Hide()
        FinalJeopardy.ClueDisplayScreen1.MiniClue1.Hide()
        FinalJeopardy.ClueDisplayScreen1.MiniClue1.Location = New Point(0, 534)
        If String.IsNullOrEmpty(interactiveClueLocation) Then
            FinalJeopardy.ClueDisplayScreen1.clueBrowser.Navigate(finalURL & "\Resources\clue.html")
            '    FinalJeopardy.ClueDisplayScreen1.clueBrowser.Navigate("localhost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
            'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("clue").InnerHtml = clueStr
            'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
            '    FinalJeopardy.ClueDisplayScreen1.lblClue.Show()
            '    FinalJeopardy.ClueDisplayScreen1.lblClue.Text = clueList.Item(clueID)
            FinalJeopardy.ClueDisplayScreen1.clueType = clueType.Regular
            '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Parent = roundForm.clue
            '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.BackColor = Color.Black
        Else
            If interactiveClueLocation.Contains(".mp4") Or interactiveClueLocation.Contains(".wmv") Or interactiveClueLocation.Contains(".avi") Or interactiveClueLocation.Contains(".mov") Then
                FinalJeopardy.ClueDisplayScreen1.clueBrowser.Navigate(finalURL & "\Resources\interactiveClue.html")
                '    FinalJeopardy.ClueDisplayScreen1.lblClue.Hide()
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.lblClue.Text = clueList.Item(clueID)
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Show()
                'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
                'FinalJeopardy.ClueDisplayScreen1.wmpClue.Show()
                FinalJeopardy.ClueDisplayScreen1.videoClueLocation = interactiveClueLocation
                FinalJeopardy.ClueDisplayScreen1.clueType = clueType.Video
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Parent = roundForm.clue
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.BackColor = Color.Black
            ElseIf interactiveClueLocation.Contains(".m4a") Or interactiveClueLocation.Contains(".mp3") Or interactiveClueLocation.Contains(".wav") Or interactiveClueLocation.Contains(".wma") Then
                FinalJeopardy.ClueDisplayScreen1.clueBrowser.Navigate(finalURL & "\Resources\clue.html")
                FinalJeopardy.ClueDisplayScreen1.wmpClue.Hide()
                FinalJeopardy.ClueDisplayScreen1.wmpClue.URL = interactiveClueLocation
                'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("clue").InnerHtml = clueStr
                'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
                '    FinalJeopardy.ClueDisplayScreen1.clueBrowser.Navigate("localhost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
                '    FinalJeopardy.ClueDisplayScreen1.lblClue.Text = clueList.Item(clueID)
                FinalJeopardy.ClueDisplayScreen1.wmpClue.Ctlcontrols.stop()
                FinalJeopardy.ClueDisplayScreen1.clueType = clueType.Audio
                FinalJeopardy.ClueDisplayScreen1.MiniClue1.Parent = roundForm.clue
                FinalJeopardy.ClueDisplayScreen1.MiniClue1.BackColor = Color.Black
            ElseIf interactiveClueLocation.Contains(".png") Or interactiveClueLocation.Contains(".jpg") Or interactiveClueLocation.Contains(".bmp") Or interactiveClueLocation.Contains(".gif") Then
                FinalJeopardy.ClueDisplayScreen1.clueBrowser.Navigate(finalURL & "\Resources\interactiveClue.html")
                FinalJeopardy.ClueDisplayScreen1.lblClue.Hide()
                FinalJeopardy.ClueDisplayScreen1.pboxClue.Show()
                'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("clue").InnerHtml = clueStr
                'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("interactiveClue").SetAttribute("src", interactiveClueLocation)
                FinalJeopardy.ClueDisplayScreen1.imgClueLocation = interactiveClueLocation
                'FinalJeopardy.ClueDisplayScreen1.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:block;"
                '    FinalJeopardy.ClueDisplayScreen1.clueBrowser.Navigost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.lblClue.Text = clueList.Item(clueID)
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Show()
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Parent =     FinalJeopardy.ClueDisplayScreen1.pboxClue
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.BackColor = Color.Transparent
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Location = New Point(0, 534)
                '    FinalJeopardy.ClueDisplayScreen1.pboxClue.BackgroundImage = Image.FromFile(interactiveClueLocation)
                FinalJeopardy.ClueDisplayScreen1.clueType = clueType.Image
            End If
        End If
        FinalJeopardy.CategoryTitle1.category = category
        FinalJeopardy.ClueDisplayScreen1.clue = clueStr
        FinalJeopardy.CategoryTitle1.catBrowser.Navigate(finalURL & "\Resources\category.html")
        connClues.Close()
    End Sub
#End Region
#Region "Check if the Category has Been Cleared"
    Public Shared Sub checkIfCategoryCleared()
        jSpeechRecog.RecognizeAsyncCancel()
        If (checkClueList("Cat1200") = True And checkClueList("Cat1400") = True And checkClueList("Cat1600") = True And checkClueList("Cat1800") = True And checkClueList("Cat11000") = True) = True Or (checkClueList("Cat1400") = True And checkClueList("Cat1800") = True And checkClueList("Cat11200") = True And checkClueList("Cat11600") = True And checkClueList("Cat12000") = True) = True Then
            roundForm.cat1Title.display = False
            roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkClueList("Cat2200") = True And checkClueList("Cat2400") = True And checkClueList("Cat2600") = True And checkClueList("Cat2800") = True And checkClueList("Cat21000") = True) = True Or (checkClueList("Cat2400") = True And checkClueList("Cat2800") = True And checkClueList("Cat21200") = True And checkClueList("Cat21600") = True And checkClueList("Cat22000") = True) = True Then
            roundForm.cat2Title.display = False
            roundForm.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkClueList("Cat3200") = True And checkClueList("Cat3400") = True And checkClueList("Cat3600") = True And checkClueList("Cat3800") = True And checkClueList("Cat31000") = True) = True Or (checkClueList("Cat3400") = True And checkClueList("Cat3800") = True And checkClueList("Cat31200") = True And checkClueList("Cat31600") = True And checkClueList("Cat32000") = True) = True Then
            roundForm.cat3Title.display = False
            roundForm.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkClueList("Cat4200") = True And checkClueList("Cat4400") = True And checkClueList("Cat4600") = True And checkClueList("Cat4800") = True And checkClueList("Cat41000") = True) = True Or (checkClueList("Cat4400") = True And checkClueList("Cat4800") = True And checkClueList("Cat41200") = True And checkClueList("Cat41600") = True And checkClueList("Cat42000") = True) = True Then
            roundForm.cat4Title.display = False
            roundForm.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkClueList("Cat5200") = True And checkClueList("Cat5400") = True And checkClueList("Cat5600") = True And checkClueList("Cat5800") = True And checkClueList("Cat51000") = True) = True Or (checkClueList("Cat5400") = True And checkClueList("Cat5800") = True And checkClueList("Cat51200") = True And checkClueList("Cat51600") = True And checkClueList("Cat52000") = True) = True Then
            roundForm.cat5Title.display = False
            roundForm.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkClueList("Cat6200") = True And checkClueList("Cat6400") = True And checkClueList("Cat6600") = True And checkClueList("Cat6800") = True And checkClueList("Cat61000") = True) = True Or (checkClueList("Cat6400") = True And checkClueList("Cat6800") = True And checkClueList("Cat61200") = True And checkClueList("Cat61600") = True And checkClueList("Cat62000") = True) = True Then
            roundForm.cat6Title.display = False
            roundForm.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
    End Sub
#End Region
#Region "Check if All Categories Revealed"
    Public Shared Sub checkIfCategoriesRevealed()
        If roundForm.CategoryDisplay1.displayFinished = True Or roundForm.CategoryDisplay1.Visible = False Then
            roundForm.CategoryDisplay1.Visible = False
            'roundForm.cat1Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
            'roundForm.cat2Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
            'roundForm.cat3Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
            'roundForm.cat4Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
            'roundForm.cat5Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
            'roundForm.cat6Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
            'roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(1200)
            'roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(2200)
            'roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(3200)
            'roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(4200)
            'roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(5200)
            'roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(6200)
            categoryMode = True
            questionMode = False
            jSpeechRecog.categoryMode = True
            jSpeechRecog.allowCatMode = True
            jSpeechRecog.RecognizeAsyncCancel()
            roundForm.CategoryDisplay1.Visible = False
            frmScore.Show()
            frmScore.BringToFront()
            roundForm.tmrCatReveal.Stop()
            roundForm.tmrCheckReveal.Stop()
        End If
    End Sub
#End Region
#Region "Perform Category Reveal"
    Public Shared Sub performCategoryReveal()
        'roundForm.cat1Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        'roundForm.cat2Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        'roundForm.cat3Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        'roundForm.cat4Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        'roundForm.cat5Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        'roundForm.cat6Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        Do
            If (roundForm.cat1Title.catBrowserSmall.IsBusy = False And roundForm.cat2Title.catBrowserSmall.IsBusy = False And roundForm.cat3Title.catBrowserSmall.IsBusy = False And roundForm.cat4Title.catBrowserSmall.IsBusy = False And roundForm.cat5Title.catBrowserSmall.IsBusy = False And roundForm.cat6Title.catBrowserSmall.IsBusy = False) And roundEnum = roundType.Jeopardy Then
                roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(1200).category
                roundForm.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(2200).category
                roundForm.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(3200).category
                roundForm.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(4200).category
                roundForm.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(5200).category
                roundForm.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(6200).category
                Exit Do
            ElseIf (roundForm.cat1Title.catBrowserSmall.IsBusy = False And roundForm.cat2Title.catBrowserSmall.IsBusy = False And roundForm.cat3Title.catBrowserSmall.IsBusy = False And roundForm.cat4Title.catBrowserSmall.IsBusy = False And roundForm.cat5Title.catBrowserSmall.IsBusy = False And roundForm.cat6Title.catBrowserSmall.IsBusy = False) And roundEnum = roundType.DoubleJeopardy Then
                roundForm.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(1400).category
                roundForm.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(2400).category
                roundForm.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(3400).category
                roundForm.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(4400).category
                roundForm.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(5400).category
                roundForm.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(6400).category
                Exit Do
            End If
        Loop
        'roundForm.cat1Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=1")
        'roundForm.cat2Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=2")
        'roundForm.cat3Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=3")
        'roundForm.cat4Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=4")
        'roundForm.cat5Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=5")
        'roundForm.cat6Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=6")
        If catChooser.finished = True Then
            catChooser.Close()
            roundForm.CategoryDisplay1.Show()
            roundForm.pbarCatReveal.PerformStep()
            If roundForm.CategoryDisplay1.displayFinished = False And bypassCategoryReveal = False Then
                jSpeechRecog.allowCatMode = False
                roundForm.pbarCatReveal.Value = 0
                roundForm.CategoryDisplay1.Show()
                jSpeechRecog.RecognizeAsyncCancel()
                roundForm.tmrCatReveal.Stop()
                roundForm.tmrCheckReveal.Start()
            ElseIf roundForm.CategoryDisplay1.displayFinished = True Then
                roundForm.CategoryDisplay1.Visible = False
                categoryMode = True
                questionMode = False
                jSpeechRecog.categoryMode = True
                jSpeechRecog.allowCatMode = True
                jSpeechRecog.RecognizeAsyncCancel()
                roundForm.CategoryDisplay1.Visible = False
                frmScore.Show()
                frmScore.BringToFront()
                roundForm.tmrCatReveal.Stop()
                roundForm.tmrCheckReveal.Stop()
            ElseIf bypassCategoryReveal = True Then
                roundForm.CategoryDisplay1.Visible = False
                'roundForm.wmpCategory.Ctlcontrols.stop()
                'Dim fileReader As System.IO.StreamReader
                'fileReader = My.Computer.FileSystem.OpenTextFileReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt")
                'Do While fileReader.Peek() > -1
                '    Dim fileClueID = fileReader.ReadLine()
                '    'MsgBox(fileClueID)
                '    CType(roundForm.categoryPanel.Controls(fileClueID), PictureBox).Enabled = False
                '    CType(roundForm.categoryPanel.Controls(fileClueID), PictureBox).Image = My.Resources.BlankTile
                'Loop
                'fileReader.Close()
                frmScore.Show()
                frmScore.BringToFront()
            End If
            frmScore.Show()
            frmScore.BringToFront()
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
#Region "Save Game"
    Public Shared Sub saveGame(correct As Boolean)
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
        Dim cmdFinalGame As SqlCommand
        Dim cmdUpdateRound As SqlCommand
        If roundEnum <> roundType.FinalJeopardy And frmScore.btnDoubleJeopardy.Visible = False And frmScore.btnFinalJeopardy.Visible = False Then
            If (frmScore.Player1RungIn = True And frmScore.Player2RungIn = True And frmScore.Player3RungIn = True) Or correct = True Then
                Dim strSQL As String = "Insert Into SeenClues VALUES (@clueID, @gameID)"
                Dim cmd As SqlCommand
                connClues.Open()
                cmd = New SqlCommand(strSQL, connClues)
                Dim cbIDParam As SqlParameter = New SqlParameter("@clueID", cbID)
                Dim gameIDParam As SqlParameter = New SqlParameter("@gameID", gameID)
                cmd.Parameters.Add(cbIDParam)
                cmd.Parameters.Add(gameIDParam)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                connClues.Close()
            End If
        End If
        For Each player In Player1List
            player.saveCurrentScore()
        Next
        For Each player In Player2List
            player.saveCurrentScore()
        Next
        For Each player In Player3List
            player.saveCurrentScore()
        Next
        connClues.Open()
        Dim strUpdateRound As String = "Update Game SET Round = @round WHERE Id = @gameID"
        cmdUpdateRound = New SqlCommand(strUpdateRound, connClues)
        Dim gameID2Param As SqlParameter = New SqlParameter("@gameID", gameID)
        Dim roundParam As SqlParameter = New SqlParameter("@round", roundNumber)
        cmdUpdateRound.Parameters.Add(gameID2Param)
        cmdUpdateRound.Parameters.Add(roundParam)
        cmdUpdateRound.CommandType = CommandType.Text
        cmdUpdateRound.ExecuteNonQuery()
        connClues.Close()
        If finalCheckComplete = True Then
            connClues.Open()
            Dim strFinalGameSQL As String = "Update Game SET Final = 1 WHERE Id = @gameID"
            cmdFinalGame = New SqlCommand(strFinalGameSQL, connClues)
            Dim gameIDParam As SqlParameter = New SqlParameter("@gameID", gameID)
            cmdFinalGame.Parameters.Add(gameIDParam)
            cmdFinalGame.CommandType = CommandType.Text
            cmdFinalGame.ExecuteNonQuery()
            connClues.Close()
            For Each player In Player1List
                player.saveTotal()
            Next
            For Each player In Player2List
                player.saveTotal()
            Next
            For Each player In Player3List
                player.saveTotal()
            Next
        End If
    End Sub
#End Region
#Region "Show Point Value Box"
    Public Shared Sub showPointValueBox()
        roundForm.pbarPVB.PerformStep()
        If roundForm.pbarPVB.Value = roundForm.pbarPVB.Maximum Then
            roundForm.pbarPVB.Value = 0
            roundForm.PointValueBox.Hide()
            roundForm.tmrPointValueBox.Stop()
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
                If frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer1.Text Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.IsDailyDouble = False
                    End If
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer1Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")) + currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player1List
                        player.Score = frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    roundForm.tmrRingIn.Stop()
                    currentPointValue = 0
                    currentPlayer = 1
                    roundForm.clue.Hide()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.IsDailyDouble = False
                    End If
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer2Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")) + currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player2List
                        player.Score = frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    roundForm.tmrRingIn.Stop()
                    currentPointValue = 0
                    currentPlayer = 2
                    roundForm.clue.Hide()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.IsDailyDouble = False
                    End If
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")) + currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player3List
                        player.Score = frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    roundForm.tmrRingIn.Stop()
                    currentPointValue = 0
                    currentPlayer = 3
                    roundForm.clue.Hide()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                End If
            ElseIf answer = False Then
                frmScore.notifyBar.Text = ""
                If frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer1.Text Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.lblPlayer1Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                        For Each player As Player In Player1List
                            player.Score = frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")
                        Next
                        frmScore.IsDailyDouble = False
                        frmScore.txtCurrentPlayer.Clear()
                        roundForm.tmrRingIn.Stop()
                        currentPointValue = 0
                        roundForm.clue.Hide()
                        frmScore.btnYes.Hide()
                        frmScore.btnNo.Hide()
                    Else
                        My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                        frmScore.lblPlayer1Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                        For Each player As Player In Player1List
                            player.Score = frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")
                        Next
                        frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.txtCurrentPlayer.Clear()
                    End If
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.lblPlayer2Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                        For Each player As Player In Player2List
                            player.Score = frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")
                        Next
                        frmScore.IsDailyDouble = False
                        frmScore.txtCurrentPlayer.Clear()
                        roundForm.tmrRingIn.Stop()
                        currentPointValue = 0
                        roundForm.clue.Hide()
                        frmScore.btnYes.Hide()
                        frmScore.btnNo.Hide()
                    Else
                        My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                        frmScore.lblPlayer2Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                        For Each player As Player In Player2List
                            player.Score = frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")
                        Next
                        frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.txtCurrentPlayer.Clear()
                    End If
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text Then
                    If frmScore.IsDailyDouble = True Then
                        frmScore.lblPlayer3Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                        For Each player As Player In Player3List
                            player.Score = frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")
                        Next
                        frmScore.IsDailyDouble = False
                        frmScore.txtCurrentPlayer.Clear()
                        roundForm.tmrRingIn.Stop()
                        currentPointValue = 0
                        roundForm.clue.Hide()
                        frmScore.btnYes.Hide()
                        frmScore.btnNo.Hide()
                    Else
                        My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                        frmScore.lblPlayer3Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                        For Each player As Player In Player3List
                            player.Score = frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")
                        Next
                        frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                        frmScore.txtCurrentPlayer.Clear()
                        frmScore.btnYes.Hide()
                        frmScore.btnNo.Hide()
                    End If
                End If
            End If
        Else
            If answer = True Then
                currentPointValue = CInt(frmScore.txtWager1.Text)
                frmScore.notifyBar.Text = ""
                questionMode = False
                categoryMode = True
                If frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer1.Text Then
                    frmScore.lblPlayer1Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")) + currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player1List
                        player.Score = frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    'roundForm.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 1
                    frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text
                    currentPointValue = CInt(frmScore.txtWager2.Text)
                    'roundForm.clue.Hide()
                    'frmScore.btnYes.Hide()
                    'frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text Then
                    currentPointValue = CInt(frmScore.txtWager2.Text)
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer2Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")) + currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player2List
                        player.Score = frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text
                    currentPointValue = CInt(frmScore.txtWager3.Text)
                    'roundForm.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 2
                    'roundForm.clue.Hide()
                    'frmScore.btnYes.Hide()
                    'frmScore.btnNo.Hide()
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text Then
                    currentPointValue = CInt(frmScore.txtWager3.Text)
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")) + currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player3List
                        player.Score = frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
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
                    frmScore.btnGo.Enabled = False
                    finalCheckComplete = True
                End If
            ElseIf answer = False Then
                frmScore.notifyBar.Text = ""
                If frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer1.Text Then
                    My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                    frmScore.lblPlayer1Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player1List
                        player.Score = frmScore.lblPlayer1Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text
                    currentPointValue = CInt(frmScore.txtWager2.Text)
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text Then
                    My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                    frmScore.lblPlayer2Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player2List
                        player.Score = frmScore.lblPlayer2Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text
                    currentPointValue = CInt(frmScore.txtWager3.Text)
                ElseIf frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text Then
                    My.Computer.Audio.Play(My.Resources.timesup, AudioPlayMode.Background)
                    frmScore.lblPlayer3Score.Text = FormatCurrency(Integer.Parse(frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")) - currentPointValue, 0, , TriState.False)
                    For Each player As Player In Player3List
                        player.Score = frmScore.lblPlayer3Score.Text.Replace("$", "").Replace(",", "")
                    Next
                    frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 192)
                    frmScore.txtCurrentPlayer.Clear()
                    frmScore.btnYes.Hide()
                    frmScore.btnNo.Hide()
                    frmScore.btnGo.Enabled = False
                    finalCheckComplete = True
                    If quickGame = False Then
                        saveGame(True)
                    End If
                End If
            End If
        End If
        'If FinalJeopardy.Visible = False Then
        '    roundForm.rtbPointValues.Clear()
        '    roundForm.rtbPointValues.AppendText(frmScore.lblPlayer1Score.Text + vbCrLf)
        '    roundForm.rtbPointValues.AppendText(frmScore.lblPlayer2Score.Text + vbCrLf)
        '    roundForm.rtbPointValues.AppendText(frmScore.lblPlayer3Score.Text)
        '    roundForm.rtbPointValues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
        'Else
        'End If
    End Sub
    Public Shared Sub ifNoRingIn()
        frmScore.Player1RungIn = False
        frmScore.Player2RungIn = False
        frmScore.Player3RungIn = False
        frmScore.lblPlayer1.BackgroundImage = My.Resources.PodiumNameBKG
        frmScore.lblPlayer2.BackgroundImage = My.Resources.PodiumNameBKG
        frmScore.lblPlayer3.BackgroundImage = My.Resources.PodiumNameBKG
        frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
        frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
        frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
        frmScore.txtCurrentPlayer.Clear()
        roundForm.tmrRingIn.Stop()
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
                roundForm.tmrRingIn.Stop()
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
            roundForm.tmrCheckRecogStopped.Stop()
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
#Region "Check if List Contains Clue"
    Public Shared Function checkClueList(cbID As Integer) As Boolean
        For Each item As Clue In seenClues
            If item.cbID = cbID Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Shared Function checkClueList(clueID As String) As Boolean
        For Each item As Clue In seenClues
            If item.clueID = clueID Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region
#Region "Convert Clue ID"
    Public Shared Function convertClueID(clueID As String) As String
        If roundEnum = roundType.Jeopardy Then
            Return clueID
        ElseIf roundEnum = roundType.DoubleJeopardy Then
            Select Case clueID
                Case clueID.Contains("400")
                    Return clueID.Replace("400", "200")
                Case clueID.Contains("800")
                    Return clueID.Replace("800", "400")
                Case clueID.Contains("1200")
                    Return clueID.Replace("1200", "600")
                Case clueID.Contains("1600")
                    Return clueID.Replace("1600", "800")
                Case clueID.Contains("2000")
                    Return clueID.Replace("2000", "1000")
            End Select
        Else
            Return clueID
        End If
        Return clueID
    End Function
    Public Shared Function convertClueIDToR2(clueID As String) As String
        If roundEnum = roundType.Jeopardy Then
            Select Case clueID
                Case clueID.Contains("200")
                    Return clueID.Replace("200", "400")
                Case clueID.Contains("400")
                    Return clueID.Replace("400", "800")
                Case clueID.Contains("600")
                    Return clueID.Replace("600", "1200")
                Case clueID.Contains("800")
                    Return clueID.Replace("800", "1600")
                Case clueID.Contains("1000")
                    Return clueID.Replace("1000", "2000")
            End Select
        ElseIf roundEnum = roundType.DoubleJeopardy Then
            Return clueID
        Else
            Return clueID
        End If
        Return clueID
    End Function
#End Region
End Class
