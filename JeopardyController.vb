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
    Public Shared finalJeopardyExists As Boolean = False
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
    'Public Shared categoryScreen As categoryScreen
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
        categoryScreen.cat1Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        categoryScreen.cat2Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        categoryScreen.cat3Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        categoryScreen.cat4Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        categoryScreen.cat5Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        categoryScreen.cat6Title.catBrowserSmall.Navigate(finalURL & "\Resources\category.html")
        'If categoryScreen.Visible = True Then
        '    categoryScreen = CType(categoryScreen, categoryScreen)
        'End If
        If round = roundType.Jeopardy Then
            roundNumber = 1
            categoryScreen.CategoryDisplay1.pboxJeopardyCard.Image = My.Resources.JEOPARDYLogo
            For i As Integer = 1 To 6
                For j As Integer = 200 To 1000 Step 200
                    categoryScreen.catListBox.Items.Add("Cat" & i & j)
                Next
            Next
        ElseIf round = roundType.DoubleJeopardy Then
            roundNumber = 2
            categoryScreen.CategoryDisplay1.pboxJeopardyCard.Image = My.Resources.DOUBLEJeopardy
            For i As Integer = 1 To 6
                For j As Integer = 400 To 2000 Step 400
                    categoryScreen.catListBox.Items.Add("Cat" & i & j)
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
        'For Each item As PictureBox In categoryScreen.categoryPanel.Controls
        '    categoryScreen.catListBox.Items.Add(item.Name)
        'Next
        'If categoryScreen.Visible = True Then
        '    loadSets()
        'ElseIf djcategoryScreen.Visible = True Then
        'End If
        If round = roundType.Jeopardy Then
            loadSets()
        ElseIf round = roundType.DoubleJeopardy Then
            noAnimation()
        End If
        'categoryScreen.Timer3.Start()
        'categoryScreen.rtbSeenClues.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        'categoryScreen.rtbPointValues.LoadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
        'loadcategoryXMLManual()
        categoryScreen.tmrCheckCurrentRound.Start()
        categoryScreen.tmrCheckIfRungIn.Start()
        'categoryScreen.wmpCategory.Ctlcontrols.stop()
        'If round = roundType.DoubleJeopardy Then
        '    MsgBox(categoryScreen.cat1Title.catBrowserSmall.ReadyState)
        '    MsgBox(categoryScreen.cat2Title.catBrowserSmall.ReadyState)
        '    MsgBox(categoryScreen.cat3Title.catBrowserSmall.ReadyState)
        '    MsgBox(categoryScreen.cat4Title.catBrowserSmall.ReadyState)
        '    MsgBox(categoryScreen.cat5Title.catBrowserSmall.ReadyState)
        '    MsgBox(categoryScreen.cat6Title.catBrowserSmall.ReadyState)
        'End If
        roundEnum = round
        'MsgBox(categoryScreen.cat1Title.catBrowserSmall.Document.Url.ToString())
        'MsgBox(categoryScreen.cat1Title.catBrowserSmall.DocumentText)
        If round = roundType.Jeopardy Then
            categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(1200).category
            categoryScreen.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(2200).category
            categoryScreen.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(3200).category
            categoryScreen.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(4200).category
            categoryScreen.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(5200).category
            categoryScreen.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(6200).category
        ElseIf round = roundType.DoubleJeopardy Then
            categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(1400).category
            categoryScreen.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(2400).category
            categoryScreen.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(3400).category
            categoryScreen.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(4400).category
            categoryScreen.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(5400).category
            categoryScreen.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = lstClues(6400).category
        End If
        categoryScreen.tmrCatReveal.Start()
        categoryScreen.tmrCheckCatCleared.Start()
        categoryScreen.clue.clueBrowser.Navigate(Application.StartupPath & "/Resources/clue.html")
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
    Private Shared Sub noAnimation()
        For Each item As String In categoryScreen.catListBox.Items
            CType(categoryScreen.categoryPanel.Controls(convertClueID(item)), PictureBox).Image = CType(My.Resources.ResourceManager.GetObject("Screen" & item.Remove(0, 4)), Bitmap)
            CType(categoryScreen.categoryPanel.Controls(convertClueID(item)), PictureBox).Enabled = True
        Next
    End Sub
    Private Shared Sub loadSets()
        For Each item As Control In categoryScreen.categoryPanel.Controls
            item.Enabled = True
        Next
        If categoryScreen.Visible = True Then
            For i As Integer = 1 To 3
                Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                set1.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                'categoryScreen.categoryPanel.Controls(categoryScreen.catListBox.Items.Item(RandNumber).ToString()).Show()
                'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                For myi = 1 To categoryScreen.TrackBar1.Maximum
                    'While i <= TrackBar1.Maximum
                    categoryScreen.TrackBar1.Value = myi
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
                CType(categoryScreen.categoryPanel.Controls(convertClueID(categoryScreen.catListBox.Items.Item(RandNumber).ToString())), PictureBox).Image = FadeBitmap(newImage, 0.5)
            Next
            For myI = 1 To 100
                categoryScreen.pbarLoadCat.Value += 1
            Next
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 100 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set2.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set2(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar2.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar2.Value = myi
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
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set2(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 200 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set3.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set3(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar3.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar3.Value = myi
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
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set3(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 300 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set4.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set4(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar4.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar4.Value = myi
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
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set4(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 400 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set5.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set5(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar5.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar5.Value = myi
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
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set5(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 500 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set6.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set6(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar6.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar6.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    'MsgBox(categoryScreen.catListBox.Items.Item(RandNumber - 1).ToString())
                    If set6(i - 1).Length = 8 Then
                        strClueValue = set6(i - 1).Remove(0, 4)
                    ElseIf set6(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set6(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set6(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 600 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set7.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set7(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar7.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar7.Value = myi
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
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set7(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 700 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set8.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set8(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar8.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar8.Value = myi
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
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set8(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 800 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set9.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(categoryScreen.catListBox.Items.Item(RandNumber).ToString()).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar9.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar9.Value = myi
                        'End While
                    Next
                    Dim strClueValue As String
                    If set9(i - 1).Length = 8 Then
                        strClueValue = categoryScreen.catListBox.Items.Item(RandNumber).ToString().Remove(0, 4)
                    ElseIf set9(i - 1).Length = 7 Then
                        Dim strCatNumberPreformatted As String = set9(i - 1).Remove(0, 3)
                        strClueValue = strCatNumberPreformatted.Remove(0, 1)
                    End If
                    'Dim newImage As New Bitmap(Image.FromFile("C:\Users\ac765\Desktop\JeopardyQs\Point Values\" & strClueValue & ".PNG"), New Size(164, 89))
                    Dim newImage As New Bitmap(CType(My.Resources.ResourceManager.GetObject("Screen" & strClueValue), Bitmap), New Size(164, 89))
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(categoryScreen.catListBox.Items.Item(RandNumber).ToString())), PictureBox).Image = FadeBitmap(newImage, 0.5)

                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            If categoryScreen.pbarLoadCat.Value = 900 Then
                For i As Integer = 1 To 3
                    Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count - 1))
                    set10.Add(categoryScreen.catListBox.Items.Item(RandNumber).ToString())
                    'categoryScreen.categoryPanel.Controls(set10(i-1)).Show()
                    'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
                    categoryScreen.catListBox.Items.RemoveAt(RandNumber)
                    For myi = 1 To categoryScreen.TrackBar10.Maximum
                        'While i <= TrackBar1.Maximum
                        categoryScreen.TrackBar10.Value = myi
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
                    CType(categoryScreen.categoryPanel.Controls(convertClueID(set10(i - 1))), PictureBox).Image = FadeBitmap(newImage, 0.5)
                Next
                For myI = 1 To 100
                    categoryScreen.pbarLoadCat.Value += 1
                Next
            End If
            categoryScreen.PerformLayout()
            'Else
            '    For Each control As Control In DJcategoryScreen.categoryPanel.Controls
            '        control.Show()
            '    Next
            'End If
            'If categoryScreen.pbarLoadCat.Value = 1000 Then
            '    For i As Integer = 1 To 3
            '        Dim RandNumber = CInt(Math.Ceiling(Rnd() * categoryScreen.catListBox.Items.Count)) - 1
            '        categoryScreen.categoryPanel.Controls(categoryScreen.catListBox.Items.Item(RandNumber).ToString()).Show()
            '        'MsgBox(RandNumber & " | " & categoryScreen.catListBox.Items.Count)
            '        categoryScreen.catListBox.Items.RemoveAt(RandNumber)
            '    Next
            'End If
            'categoryScreen.PerformLayout()
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
        For Each player As Player In Player3List
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
                    categoryScreen.tmrCheckRecogStopped.Start()
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
                            categoryScreen.tmrRingIn.Stop()
                        End Try
                        'frmScore.ProgressBar1.PerformStep()
                        'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                        'End If
                    End If
                ElseIf My.Computer.Keyboard.AltKeyDown = True And frmScore.Player2RungIn = False Then
                    categoryScreen.tmrCheckRecogStopped.Start()
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
                            categoryScreen.tmrRingIn.Stop()
                            'End Try
                            'frmScore.ProgressBar1.PerformStep()
                            'If frmScore.ProgressBar1.Value = frmScore.ProgressBar1.Maximum Then

                            'End If
                        End Try
                    End If
                ElseIf My.Computer.Keyboard.ShiftKeyDown = True And frmScore.Player3RungIn = False Then
                    categoryScreen.tmrCheckRecogStopped.Start()
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
                            categoryScreen.tmrRingIn.Stop()
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
            categoryScreen.tmrRingIn.Stop()
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
            categoryScreen.tmrRingIn.Stop()
            categoryScreen.clue.Hide()
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
            categoryScreen.tmrRingIn.Stop()
            categoryScreen.clue.Hide()
            currentPointValue = 0
        End If
    End Sub
#End Region
#Region "Ring In Code Manual"
    Public Shared Sub ringInManual()
        If questionMode = True Then
            '    If RecognizerOn = True Then
            If frmScore.txtCurrentPlayer.Text = "" Then
                categoryScreen.playerTimeOutTimer.Start()
                frmScore.btnYes.Hide()
                frmScore.btnNo.Hide()
                If My.Computer.Keyboard.CtrlKeyDown = True And frmScore.Player1RungIn = False Then
                    currentPlayer = 1
                    categoryScreen.clue.wmpClue.Ctlcontrols.stop()
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'frmScore.notifyBar.Text = frmScore.lblPlayer1.Text
                    frmScore.lblPlayer1.BackgroundImage = Nothing
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(175, 233, 253)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    'Timer10.Stop()
                    'Timer11.Start()
                    'categoryScreen.Timer12.Start()
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
                    categoryScreen.clue.wmpClue.Ctlcontrols.stop()
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'categoryScreen.Timer12.Start()
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
                    categoryScreen.clue.wmpClue.Ctlcontrols.stop()
                    frmScore.btnYes.Show()
                    frmScore.btnNo.Show()
                    'categoryScreen.Timer12.Start()
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
            categoryScreen.tmrRingIn.Stop()
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
            categoryScreen.tmrRingIn.Stop()
            categoryScreen.clue.Hide()
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
            categoryScreen.tmrRingIn.Stop()
            categoryScreen.clue.Hide()
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
                    categoryScreen.clue.Hide()
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    currentPointValue = 0
                    currentPlayer = 1
                    categoryScreen.tmrRingIn.Stop()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 2" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                    jSpeechRecog.categoryMode = True
                    jSpeechRecog.QuestionMode = False
                    frmScore.lblPlayer2Score.Text = Integer.Parse(frmScore.lblPlayer2Score.Text) + currentPointValue
                    frmScore.notifyBar.Text = ""
                    categoryScreen.clue.Hide()
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    currentPointValue = 0
                    currentPlayer = 2
                    categoryScreen.tmrRingIn.Stop()
                ElseIf frmScore.txtCurrentPlayer.Text = "Player 3" Then
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                    jSpeechRecog.categoryMode = True
                    jSpeechRecog.QuestionMode = False
                    frmScore.lblPlayer3Score.Text = Integer.Parse(frmScore.lblPlayer3Score.Text) + currentPointValue
                    frmScore.notifyBar.Text = ""
                    categoryScreen.clue.Hide()
                    frmScore.Player1RungIn = False
                    frmScore.Player2RungIn = False
                    frmScore.Player3RungIn = False
                    frmScore.lblPlayer3.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer2.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.lblPlayer1.BackColor = Color.FromArgb(0, 45, 194)
                    frmScore.txtCurrentPlayer.Clear()
                    currentPointValue = 0
                    currentPlayer = 3
                    categoryScreen.tmrRingIn.Stop()
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
            'categoryScreen.Timer4.Start()
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
                    'categoryScreen.PointValueBox.Show()
                    'categoryScreen.PointValueBox.Image = My.Resources.Screen200
                    categoryScreen.clue.Show()
                    'categoryScreen.clue.BringToFront()
                    'categoryScreen.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    categoryScreen.tmrRingIn.Start()
                ElseIf (e.Result.Text.Contains("400")) Then
                    catstring = e.Result.Text.Replace("400", "").Replace("for", "")
                    currentPointValue = 400
                    loadclueBoardXML(catstring, 400)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'categoryScreen.PointValueBox.Show()
                    'categoryScreen.PointValueBox.Image = My.Resources.Screen400
                    categoryScreen.clue.Show()
                    'categoryScreen.clue.BringToFront()
                    'categoryScreen.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    categoryScreen.tmrRingIn.Start()
                ElseIf (e.Result.Text.Contains("600")) Then
                    catstring = e.Result.Text.Replace("600", "").Replace("for", "")
                    currentPointValue = 600
                    loadclueBoardXML(catstring, 600)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'categoryScreen.PointValueBox.Show()
                    'categoryScreen.PointValueBox.Image = My.Resources.Screen600
                    categoryScreen.clue.Show()
                    'categoryScreen.clue.BringToFront()
                    'categoryScreen.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    categoryScreen.tmrRingIn.Start()
                ElseIf (e.Result.Text.Contains("800")) Then
                    catstring = e.Result.Text.Replace("800", "").Replace("for", "")
                    currentPointValue = 800
                    loadclueBoardXML(catstring, 800)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'categoryScreen.PointValueBox.Show()
                    'categoryScreen.PointValueBox.Image = My.Resources.Screen800
                    categoryScreen.clue.Show()
                    'categoryScreen.clue.BringToFront()
                    'categoryScreen.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    categoryScreen.tmrRingIn.Start()
                ElseIf (e.Result.Text.Contains("1000")) Then
                    catstring = e.Result.Text.Replace("1000", "").Replace("for", "")
                    currentPointValue = 1000
                    loadclueBoardXML(catstring, 1000)
                    jSpeechRecog.addToSeenCluesList(catstring, currentPointValue)
                    'categoryScreen.PointValueBox.Show()
                    'categoryScreen.PointValueBox.Image = My.Resources.Screen1000
                    categoryScreen.clue.Show()
                    'categoryScreen.clue.BringToFront()
                    'categoryScreen.clue.Load(clueLocation)
                    'cat5400.display = False
                    'cat5400.Enabled = False
                    jSpeechRecog.RecognizeAsyncCancel()
                    categoryScreen.tmrRingIn.Start()
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
            'CType(categoryScreen.Controls(clueID), PictureBox).Load(blankTilePath)
            'categoryScreen.Controls(clueID).Enabled = False
            If clueID = "Cat1200" Then
                categoryScreen.Cat1200.Load(blankTilePath)
                categoryScreen.Cat1200.Enabled = False
            ElseIf clueID = "Cat1400" Then
                categoryScreen.Cat1400.Load(blankTilePath)
                categoryScreen.Cat1400.Enabled = False
            ElseIf clueID = "Cat1600" Then
                categoryScreen.Cat1600.Load(blankTilePath)
                categoryScreen.Cat1600.Enabled = False
            ElseIf clueID = "Cat1800" Then
                categoryScreen.Cat1800.Load(blankTilePath)
                categoryScreen.Cat1800.Enabled = False
            ElseIf clueID = "Cat11000" Then
                categoryScreen.Cat11000.Load(blankTilePath)
                categoryScreen.Cat11000.Enabled = False
            ElseIf clueID = "Cat2200" Then
                categoryScreen.Cat2200.Load(blankTilePath)
                categoryScreen.Cat2200.Enabled = False
            ElseIf clueID = "Cat2400" Then
                categoryScreen.Cat2400.Load(blankTilePath)
                categoryScreen.Cat2400.Enabled = False
            ElseIf clueID = "Cat2600" Then
                categoryScreen.Cat2600.Load(blankTilePath)
                categoryScreen.Cat2600.Enabled = False
            ElseIf clueID = "Cat2800" Then
                categoryScreen.Cat2800.Load(blankTilePath)
                categoryScreen.Cat2800.Enabled = False
            ElseIf clueID = "Cat21000" Then
                categoryScreen.Cat21000.Load(blankTilePath)
                categoryScreen.Cat21000.Enabled = False
            ElseIf clueID = "Cat3200" Then
                categoryScreen.Cat3200.Load(blankTilePath)
                categoryScreen.Cat3200.Enabled = False
            ElseIf clueID = "Cat3400" Then
                categoryScreen.Cat3400.Load(blankTilePath)
                categoryScreen.Cat3400.Enabled = False
            ElseIf clueID = "Cat3600" Then
                categoryScreen.Cat3600.Load(blankTilePath)
                categoryScreen.Cat3600.Enabled = False
            ElseIf clueID = "Cat3800" Then
                categoryScreen.Cat3800.Load(blankTilePath)
                categoryScreen.Cat3800.Enabled = False
            ElseIf clueID = "Cat31000" Then
                categoryScreen.Cat31000.Load(blankTilePath)
                categoryScreen.Cat31000.Enabled = False
            ElseIf clueID = "Cat4200" Then
                categoryScreen.Cat4200.Load(blankTilePath)
                categoryScreen.Cat4200.Enabled = False
            ElseIf clueID = "Cat4400" Then
                categoryScreen.Cat4400.Load(blankTilePath)
                categoryScreen.Cat4400.Enabled = False
            ElseIf clueID = "Cat4600" Then
                categoryScreen.Cat4600.Load(blankTilePath)
                categoryScreen.Cat4600.Enabled = False
            ElseIf clueID = "Cat4800" Then
                categoryScreen.Cat4800.Load(blankTilePath)
                categoryScreen.Cat4800.Enabled = False
            ElseIf clueID = "Cat41000" Then
                categoryScreen.Cat41000.Load(blankTilePath)
                categoryScreen.Cat41000.Enabled = False
            ElseIf clueID = "Cat5200" Then
                categoryScreen.Cat5200.Load(blankTilePath)
                categoryScreen.Cat5200.Enabled = False
            ElseIf clueID = "Cat5400" Then
                categoryScreen.Cat5400.Load(blankTilePath)
                categoryScreen.Cat5400.Enabled = False
            ElseIf clueID = "Cat5600" Then
                categoryScreen.Cat5600.Load(blankTilePath)
                categoryScreen.Cat5600.Enabled = False
            ElseIf clueID = "Cat5800" Then
                categoryScreen.Cat5800.Load(blankTilePath)
                categoryScreen.Cat5800.Enabled = False
            ElseIf clueID = "Cat51000" Then
                categoryScreen.Cat51000.Load(blankTilePath)
                categoryScreen.Cat51000.Enabled = False
            ElseIf clueID = "Cat6200" Then
                categoryScreen.Cat6200.Load(blankTilePath)
                categoryScreen.Cat6200.Enabled = False
            ElseIf clueID = "Cat6400" Then
                categoryScreen.Cat6400.Load(blankTilePath)
                categoryScreen.Cat6400.Enabled = False
            ElseIf clueID = "Cat6600" Then
                categoryScreen.Cat6600.Load(blankTilePath)
                categoryScreen.Cat6600.Enabled = False
            ElseIf clueID = "Cat6800" Then
                categoryScreen.Cat6800.Load(blankTilePath)
                categoryScreen.Cat6800.Enabled = False
            ElseIf clueID = "Cat61000" Then
                categoryScreen.Cat61000.Load(blankTilePath)
                categoryScreen.Cat61000.Enabled = False
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
        If categoryScreen.Visible = True Then
            roundNumber = 1
            'ElseIf djcategoryScreen.Visible = True Then
            '    roundNumber = 2
        End If
        Dim connClues As SqlConnection
        connClues = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String = "SELECT * FROM Clueboard WHERE packName = @PackName and round = @RoundNumber"
        Dim strDoubleJeopardySQL As String = "SELECT * FROM Clueboard WHERE packName = @PackName and round = 2"
        Dim strFinalJeopardySQL As String = "SELECT * FROM Clueboard WHERE packName = @PackName and round = 3"
        Dim cmd As SqlCommand
        Dim djcmd As SqlCommand
        Dim fjcmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim djrdr As SqlDataReader
        Dim fjrdr As SqlDataReader
        Dim packNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim roundParam As SqlParameter = New SqlParameter("@RoundNumber", roundNumber)
        Dim djpackNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim djroundParam As SqlParameter = New SqlParameter("@RoundNumber", 2)
        Dim fjpackNameParam As SqlParameter = New SqlParameter("@PackName", packName)
        Dim fjroundParam As SqlParameter = New SqlParameter("@RoundNumber", 3)
        connClues.Open()
        If round = roundType.Jeopardy Then
            cmd = New SqlCommand(strSQL, connClues)
        ElseIf round = roundType.DoubleJeopardy Then
            cmd = New SqlCommand(strDoubleJeopardySQL, connClues)
        Else
        End If
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
            '    CType(categoryScreen.categoryPanel.Controls(convertClueID(clueID)), PictureBox).Image = My.Resources.BlankTile
            '    CType(categoryScreen.categoryPanel.Controls(convertClueID(clueID)), PictureBox).Enabled = False
            'End If
            'categoryListSorted.Add(clueID.Replace("Cat", ""), category)
            'clueList.Add(clueID, clue)
            'If Trim(clueLocation) <> "" Then
            '    interactiveClueList.Add(clueID, clueLocation)
            'End If
            'If Not categoryScreen.CategoryDisplay1.categoryList.Contains(category) Then
            '    categoryScreen.CategoryDisplay1.addCategory(category)
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
            connClues.Close()
            connClues.Open()
            fjcmd = New SqlCommand(strFinalJeopardySQL, connClues)
            fjcmd.Parameters.Add(fjpackNameParam)
            fjcmd.Parameters.Add(fjroundParam)
            fjcmd.CommandType = CommandType.Text
            fjrdr = fjcmd.ExecuteReader()
            If fjrdr.HasRows = True Then
                finalJeopardyExists = True
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
                'categoryScreen.clue.Load(str3Replaced)
                categoryScreen.clue.Show()
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
                'categoryScreen.clue.Load(str3Replaced)
                If str6 = "false" Then
                    categoryScreen.clue.Show()
                ElseIf str6 = "true" Then
                    frmScore.IsDailyDouble = True
                    DailyDouble.Show()
                Else
                    categoryScreen.clue.Show()
                End If
            Else

            End If
        Next
        Dim blankTilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\BlankTile.png"
        'MsgBox(clueID)
        CType(categoryScreen.categoryPanel.Controls(clueID), PictureBox).Load(blankTilePath)
        CType(categoryScreen.categoryPanel.Controls(clueID), PictureBox).Enabled = False
        'categoryScreen.rtbSeenClues.AppendText(clueID + vbCrLf)
        'categoryScreen.rtbSeenClues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt", RichTextBoxStreamType.PlainText)
        frmScore.btnGo.Show()
    End Sub
#End Region
#Region "Load Clue Manual without XML"
    Public Shared Sub loadClue(clueID As String)
        'If roundEnum = roundType.Jeopardy Then
        '    clueID = clueID
        'ElseIf roundEnum = roundType.DoubleJeopardy Then
        '    clueID = convertToR2(clueID)
        'End If
        categoryScreen.PointValueBox.Image = My.Resources.ResourceManager.GetObject("Screen" & currentPointValue)
        categoryScreen.PointValueBox.Show()
        'categoryScreen.clue.Load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\" + clueID + ".png")
        If lstClues(Integer.Parse(clueID.Replace("Cat", ""))).dailyDouble = True Then
            frmScore.IsDailyDouble = True
            DailyDouble.Show()
            frmScore.btnGo.Hide()
        Else
            frmScore.btnGo.Show()
            frmScore.IsDailyDouble = False
        End If
        seenClues.Add(lstClues(Integer.Parse(clueID.Replace("Cat", ""))))
        cbID = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).cbID
        categoryScreen.clue.Show()
        categoryScreen.clue.wmpClue.Hide()
        categoryScreen.clue.pboxClue.Hide()
        categoryScreen.clue.MiniClue1.Hide()
        categoryScreen.clue.MiniClue1.Location = New Point(0, 534)
        Dim categoryNumber = clueID.Replace("Cat", "").Substring(0, 1)
        If String.IsNullOrEmpty(lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation) Then
            frmScore.Show()
            categoryScreen.clue.clueBrowser.Navigate(finalURL & "\Resources\clue.html")
            'categoryScreen.clue.clueBrowser.Navigate("localhost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
            'categoryScreen.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
            'categoryScreen.clue.lblClue.Show()
            'categoryScreen.clue.lblClue.Text = clueList.Item(clueID)
            categoryScreen.clue.clueType = clueType.Regular
            'categoryScreen.clue.MiniClue1.Parent = categoryScreen.clue
            'categoryScreen.clue.MiniClue1.BackColor = Color.Black
        Else
            If lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".mp4") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".wmv") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".avi") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".mov") Then
                categoryScreen.clue.clueBrowser.Navigate(finalURL & "\Resources\interactiveClue.html")
                frmScore.Hide()
                categoryScreen.clue.lblClue.Hide()
                'categoryScreen.clue.MiniClue1.lblClue.Text = clueList.Item(clueID)
                'categoryScreen.clue.MiniClue1.Show()
                'categoryScreen.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
                'categoryScreen.clue.wmpClue.Show()
                categoryScreen.clue.videoClueLocation = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation
                categoryScreen.clue.clueType = clueType.Video
                'categoryScreen.clue.MiniClue1.Parent = categoryScreen.clue
                'categoryScreen.clue.MiniClue1.BackColor = Color.Black
            ElseIf lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".m4a") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".mp3") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".wav") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".wma") Then
                categoryScreen.clue.clueBrowser.Navigate(finalURL & "\Resources\clue.html")
                frmScore.Show()
                categoryScreen.clue.wmpClue.Hide()
                categoryScreen.clue.wmpClue.URL = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation
                'categoryScreen.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:none;"
                'categoryScreen.clue.clueBrowser.Navigate("localhost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
                'categoryScreen.clue.lblClue.Text = clueList.Item(clueID)
                categoryScreen.clue.wmpClue.Ctlcontrols.stop()
                categoryScreen.clue.clueType = clueType.Audio
                categoryScreen.clue.MiniClue1.Parent = categoryScreen.clue
                categoryScreen.clue.MiniClue1.BackColor = Color.Black
            ElseIf lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".png") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".jpg") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".bmp") Or lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation.Contains(".gif") Then
                categoryScreen.clue.clueBrowser.Navigate(finalURL & "\Resources\interactiveClue.html")
                frmScore.Hide()
                categoryScreen.clue.lblClue.Hide()
                'categoryScreen.clue.pboxClue.Show()
                categoryScreen.clue.imgClueLocation = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation
                'categoryScreen.clue.clueBrowser.Document.GetElementById("interactiveClueString").SetAttribute("src", lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation)
                'categoryScreen.clue.clueBrowser.Document.GetElementById("interactiveClue").Style = "display:block;"
                'categoryScreen.clue.clueBrowser.Navigost/Jeopardy/Content/clue.aspx?packName=" & packName & "&round=" & roundNumber & "&catNumber=" & categoryNumber & "&pointValue=" & currentPointValue)
                'categoryScreen.clue.MiniClue1.lblClue.Text = clueList.Item(clueID)
                'categoryScreen.clue.MiniClue1.Show()
                'categoryScreen.clue.MiniClue1.Parent = categoryScreen.clue.pboxClue
                'categoryScreen.clue.MiniClue1.BackColor = Color.Transparent
                'categoryScreen.clue.MiniClue1.Location = New Point(0, 534)
                'categoryScreen.clue.pboxClue.BackgroundImage = Image.FromFile(lstClues(Integer.Parse(clueID.Replace("Cat", ""))).interactiveClueLocation)
                categoryScreen.clue.clueType = clueType.Image
            End If
        End If
        'Dim blankTilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\BlankTile.png"
        'MsgBox(clueID)
        categoryScreen.clue.clue = lstClues(Integer.Parse(clueID.Replace("Cat", ""))).clue
        CType(categoryScreen.categoryPanel.Controls(convertClueID(clueID)), PictureBox).Image = My.Resources.BlankTile
        CType(categoryScreen.categoryPanel.Controls(convertClueID(clueID)), PictureBox).Enabled = False
        categoryScreen.timeOutTimer.Start()
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
                    'categoryScreen.Timer13.Stop()
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
                    'categoryScreen.Timer13.Stop()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    jSpeechRecog.RecognizeAsyncCancel()
                    jSpeechRecog.recognizerOn = False
                End Try
            Else
                jSpeechRecog.RecognizeAsyncCancel()
            End If
        ElseIf jSpeechRecog.categoryMode = False And jSpeechRecog.QuestionMode = False And jSpeechRecog.allowCatMode = False Then
            'categoryScreen.Timer13.Stop()
            jSpeechRecog.RecognizeAsyncCancel()
        Else
            jSpeechRecog.RecognizeAsyncCancel()
        End If
    End Sub
#End Region
#Region "Check Round"
    Public Shared Sub checkRound()
        If (categoryScreen.cat1Title.display = False And categoryScreen.cat2Title.display = False And categoryScreen.cat3Title.display = False And categoryScreen.cat4Title.display = False And categoryScreen.cat5Title.display = False And categoryScreen.cat6Title.display = False) Then
            'jSpeechRecog.categoryMode = False
            'jSpeechRecog.allowCatMode = False
            'jSpeechRecog.QuestionMode = False
            'jSpeechRecog.RecognizeAsyncCancel()
            If roundEnum = roundType.Jeopardy And doubleJeopardyExists = True Then
                frmScore.btnDoubleJeopardy.Show()
            ElseIf (roundEnum = roundType.Jeopardy And finalJeopardyExists = True) Or (roundEnum = roundType.DoubleJeopardy And finalJeopardyExists = True) Then
                frmScore.btnFinalJeopardy.Show()
            End If
            If quickGame = False Then
                saveGame(True)
            End If
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
            '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Parent = categoryScreen.clue
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
                '    FinalJeopardy.ClueDisplayScreen1.MiniClue1.Parent = categoryScreen.clue
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
                FinalJeopardy.ClueDisplayScreen1.MiniClue1.Parent = categoryScreen.clue
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
        If (checkFinalClueList("Cat1200") = True And checkFinalClueList("Cat1400") = True And checkFinalClueList("Cat1600") = True And checkFinalClueList("Cat1800") = True And checkFinalClueList("Cat11000") = True) = True Or (checkFinalClueList("Cat1400") = True And checkFinalClueList("Cat1800") = True And checkFinalClueList("Cat11200") = True And checkFinalClueList("Cat11600") = True And checkFinalClueList("Cat12000") = True) = True Then
            categoryScreen.cat1Title.display = False
            categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkFinalClueList("Cat2200") = True And checkFinalClueList("Cat2400") = True And checkFinalClueList("Cat2600") = True And checkFinalClueList("Cat2800") = True And checkFinalClueList("Cat21000") = True) = True Or (checkFinalClueList("Cat2400") = True And checkFinalClueList("Cat2800") = True And checkFinalClueList("Cat21200") = True And checkFinalClueList("Cat21600") = True And checkFinalClueList("Cat22000") = True) = True Then
            categoryScreen.cat2Title.display = False
            categoryScreen.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkFinalClueList("Cat3200") = True And checkFinalClueList("Cat3400") = True And checkFinalClueList("Cat3600") = True And checkFinalClueList("Cat3800") = True And checkFinalClueList("Cat31000") = True) = True Or (checkFinalClueList("Cat3400") = True And checkFinalClueList("Cat3800") = True And checkFinalClueList("Cat31200") = True And checkFinalClueList("Cat31600") = True And checkFinalClueList("Cat32000") = True) = True Then
            categoryScreen.cat3Title.display = False
            categoryScreen.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkFinalClueList("Cat4200") = True And checkFinalClueList("Cat4400") = True And checkFinalClueList("Cat4600") = True And checkFinalClueList("Cat4800") = True And checkFinalClueList("Cat41000") = True) = True Or (checkFinalClueList("Cat4400") = True And checkFinalClueList("Cat4800") = True And checkFinalClueList("Cat41200") = True And checkFinalClueList("Cat41600") = True And checkFinalClueList("Cat42000") = True) = True Then
            categoryScreen.cat4Title.display = False
            categoryScreen.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkFinalClueList("Cat5200") = True And checkFinalClueList("Cat5400") = True And checkFinalClueList("Cat5600") = True And checkFinalClueList("Cat5800") = True And checkFinalClueList("Cat51000") = True) = True Or (checkFinalClueList("Cat5400") = True And checkFinalClueList("Cat5800") = True And checkFinalClueList("Cat51200") = True And checkFinalClueList("Cat51600") = True And checkFinalClueList("Cat52000") = True) = True Then
            categoryScreen.cat5Title.display = False
            categoryScreen.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
        If (checkFinalClueList("Cat6200") = True And checkFinalClueList("Cat6400") = True And checkFinalClueList("Cat6600") = True And checkFinalClueList("Cat6800") = True And checkFinalClueList("Cat61000") = True) = True Or (checkFinalClueList("Cat6400") = True And checkFinalClueList("Cat6800") = True And checkFinalClueList("Cat61200") = True And checkFinalClueList("Cat61600") = True And checkFinalClueList("Cat62000") = True) = True Then
            categoryScreen.cat6Title.display = False
            categoryScreen.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = ""
        End If
    End Sub
#End Region
#Region "Check if All Categories Revealed"
    Public Shared Sub checkIfCategoriesRevealed()
        If categoryScreen.CategoryDisplay1.displayFinished = True Or categoryScreen.CategoryDisplay1.Visible = False Then
            categoryScreen.CategoryDisplay1.Visible = False
            'categoryScreen.cat1Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
            'categoryScreen.cat2Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
            'categoryScreen.cat3Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
            'categoryScreen.cat4Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
            'categoryScreen.cat5Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
            'categoryScreen.cat6Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
            'categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(1200)
            'categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(2200)
            'categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(3200)
            'categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(4200)
            'categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(5200)
            'categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerHtml = categoryListSorted(6200)
            categoryMode = True
            questionMode = False
            jSpeechRecog.categoryMode = True
            jSpeechRecog.allowCatMode = True
            jSpeechRecog.RecognizeAsyncCancel()
            categoryScreen.CategoryDisplay1.Visible = False
            frmScore.Show()
            frmScore.BringToFront()
            categoryScreen.tmrCatReveal.Stop()
            categoryScreen.tmrCheckReveal.Stop()
        End If
    End Sub
#End Region
#Region "Perform Category Reveal"
    Public Shared Sub performCategoryReveal()
        'categoryScreen.cat1Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
        'categoryScreen.cat2Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
        'categoryScreen.cat3Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
        'categoryScreen.cat4Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
        'categoryScreen.cat5Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
        'categoryScreen.cat6Title.catBrowserSmall.Navigate(Application.StartupPath & "\Resources\category.html")
        Do
            If (categoryScreen.cat1Title.catBrowserSmall.IsBusy = False And categoryScreen.cat2Title.catBrowserSmall.IsBusy = False And categoryScreen.cat3Title.catBrowserSmall.IsBusy = False And categoryScreen.cat4Title.catBrowserSmall.IsBusy = False And categoryScreen.cat5Title.catBrowserSmall.IsBusy = False And categoryScreen.cat6Title.catBrowserSmall.IsBusy = False) And roundEnum = roundType.Jeopardy Then
                categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(1200).category
                categoryScreen.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(2200).category
                categoryScreen.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(3200).category
                categoryScreen.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(4200).category
                categoryScreen.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(5200).category
                categoryScreen.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(6200).category
                Exit Do
            ElseIf (categoryScreen.cat1Title.catBrowserSmall.IsBusy = False And categoryScreen.cat2Title.catBrowserSmall.IsBusy = False And categoryScreen.cat3Title.catBrowserSmall.IsBusy = False And categoryScreen.cat4Title.catBrowserSmall.IsBusy = False And categoryScreen.cat5Title.catBrowserSmall.IsBusy = False And categoryScreen.cat6Title.catBrowserSmall.IsBusy = False) And roundEnum = roundType.DoubleJeopardy Then
                categoryScreen.cat1Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(1400).category
                categoryScreen.cat2Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(2400).category
                categoryScreen.cat3Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(3400).category
                categoryScreen.cat4Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(4400).category
                categoryScreen.cat5Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(5400).category
                categoryScreen.cat6Title.catBrowserSmall.Document.GetElementById("category").InnerText = lstClues(6400).category
                Exit Do
            End If
        Loop
        'categoryScreen.cat1Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=1")
        'categoryScreen.cat2Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=2")
        'categoryScreen.cat3Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=3")
        'categoryScreen.cat4Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=4")
        'categoryScreen.cat5Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=5")
        'categoryScreen.cat6Title.catBrowserSmall.Navigate("localhost/Jeopardy/Content/categorySmall.aspx?packName=" & packName & "&roundNumber=" & roundNumber & "&categoryNumber=6")
        If catChooser.finished = True Then
            catChooser.Close()
            categoryScreen.CategoryDisplay1.Show()
            categoryScreen.pbarCatReveal.PerformStep()
            If categoryScreen.CategoryDisplay1.displayFinished = False And bypassCategoryReveal = False Then
                jSpeechRecog.allowCatMode = False
                categoryScreen.pbarCatReveal.Value = 0
                categoryScreen.CategoryDisplay1.Show()
                jSpeechRecog.RecognizeAsyncCancel()
                categoryScreen.tmrCatReveal.Stop()
                categoryScreen.tmrCheckReveal.Start()
            ElseIf categoryScreen.CategoryDisplay1.displayFinished = True Then
                categoryScreen.CategoryDisplay1.Visible = False
                categoryMode = True
                questionMode = False
                jSpeechRecog.categoryMode = True
                jSpeechRecog.allowCatMode = True
                jSpeechRecog.RecognizeAsyncCancel()
                categoryScreen.CategoryDisplay1.Visible = False
                frmScore.Show()
                frmScore.BringToFront()
                categoryScreen.tmrCatReveal.Stop()
                categoryScreen.tmrCheckReveal.Stop()
            ElseIf bypassCategoryReveal = True Then
                categoryScreen.CategoryDisplay1.Visible = False
                'categoryScreen.wmpCategory.Ctlcontrols.stop()
                'Dim fileReader As System.IO.StreamReader
                'fileReader = My.Computer.FileSystem.OpenTextFileReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\seenClues.txt")
                'Do While fileReader.Peek() > -1
                '    Dim fileClueID = fileReader.ReadLine()
                '    'MsgBox(fileClueID)
                '    CType(categoryScreen.categoryPanel.Controls(fileClueID), PictureBox).Enabled = False
                '    CType(categoryScreen.categoryPanel.Controls(fileClueID), PictureBox).Image = My.Resources.BlankTile
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
        'If categoryScreen.clue.Visible = True Then
        '    frmScore.notifyBar.Show()
        'ElseIf categoryScreen.clue.Visible = False Then
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
        categoryScreen.pbarPVB.PerformStep()
        If categoryScreen.pbarPVB.Value = categoryScreen.pbarPVB.Maximum Then
            categoryScreen.pbarPVB.Value = 0
            categoryScreen.PointValueBox.Hide()
            categoryScreen.tmrPointValueBox.Stop()
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
                    categoryScreen.tmrRingIn.Stop()
                    currentPointValue = 0
                    currentPlayer = 1
                    categoryScreen.clue.Hide()
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
                    categoryScreen.tmrRingIn.Stop()
                    currentPointValue = 0
                    currentPlayer = 2
                    categoryScreen.clue.Hide()
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
                    categoryScreen.tmrRingIn.Stop()
                    currentPointValue = 0
                    currentPlayer = 3
                    categoryScreen.clue.Hide()
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
                        categoryScreen.tmrRingIn.Stop()
                        currentPointValue = 0
                        categoryScreen.clue.Hide()
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
                        categoryScreen.tmrRingIn.Stop()
                        currentPointValue = 0
                        categoryScreen.clue.Hide()
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
                        categoryScreen.tmrRingIn.Stop()
                        currentPointValue = 0
                        categoryScreen.clue.Hide()
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
                frmScore.notifyBar.Text = ""
                questionMode = False
                categoryMode = True
                If frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer1.Text Then
                    currentPointValue = CInt(frmScore.txtWager1.Text)
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
                    'categoryScreen.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 1
                    If determineIfNegative(2) = False Then
                        frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text
                        currentPointValue = CInt(frmScore.txtWager2.Text)
                    End If
                    'categoryScreen.clue.Hide()
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
                    If determineIfNegative(3) = False Then
                        frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text
                        currentPointValue = CInt(frmScore.txtWager3.Text)
                    End If
                    'categoryScreen.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 2
                    'categoryScreen.clue.Hide()
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
                    'categoryScreen.Timer7.Stop()
                    'currentPointValue = 0
                    'currentPlayer = 3
                    'categoryScreen.clue.Hide()
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
                    If determineIfNegative(2) = False Then
                        frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer2.Text
                        currentPointValue = CInt(frmScore.txtWager2.Text)
                    End If
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
                    If determineIfNegative(3) = False Then
                        frmScore.txtCurrentPlayer.Text = frmScore.lblPlayer3.Text
                        currentPointValue = CInt(frmScore.txtWager3.Text)
                    End If
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
                End If
                frmScore.txtCurrentPlayer.Clear()
                frmScore.btnYes.Hide()
                frmScore.btnNo.Hide()
                frmScore.btnGo.Enabled = False
                finalCheckComplete = True
                determineFinalWinner()
                If quickGame = False Then
                    saveGame(True)
                End If
            End If
        End If
        'If FinalJeopardy.Visible = False Then
        '    categoryScreen.rtbPointValues.Clear()
        '    categoryScreen.rtbPointValues.AppendText(frmScore.lblPlayer1Score.Text + vbCrLf)
        '    categoryScreen.rtbPointValues.AppendText(frmScore.lblPlayer2Score.Text + vbCrLf)
        '    categoryScreen.rtbPointValues.AppendText(frmScore.lblPlayer3Score.Text)
        '    categoryScreen.rtbPointValues.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\JeopardyQs\pointValues.txt", RichTextBoxStreamType.PlainText)
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
        categoryScreen.tmrRingIn.Stop()
        currentPointValue = 0
        currentPlayer = 1
        categoryScreen.clue.Hide()
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
                categoryScreen.tmrRingIn.Stop()
                categoryScreen.clue.Hide()
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
            categoryScreen.tmrCheckRecogStopped.Stop()
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
            If item.clueID = convertClueIDToR2(clueID) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Shared Function checkFinalClueList(clueID As String) As Boolean
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
            If clueID.Contains("400") Then
                Return clueID.Replace("400", "200")
            ElseIf clueID.Contains("800") Then
                Return clueID.Replace("800", "400")
            ElseIf clueID.Contains("2000") Then
                Return clueID.Replace("2000", "1000")
            ElseIf clueID.Contains("1200") Then
                Return clueID.Replace("1200", "600")
            ElseIf clueID.Contains("1600") Then
                Return clueID.Replace("1600", "800")
            Else
                Return clueID
            End If
        End If
        Return clueID
    End Function
    Public Shared Function convertClueIDToR2(clueID As String) As String
        If roundEnum = roundType.DoubleJeopardy Then
            If clueID.Contains("200") Then
                Return clueID.Replace("200", "400")
            ElseIf clueID.Contains("400") Then
                Return clueID.Replace("400", "800")
            ElseIf clueID.Contains("600") Then
                Return clueID.Replace("600", "1200")
            ElseIf clueID.Contains("800") Then
                Return clueID.Replace("800", "1600")
            ElseIf clueID.Contains("1000") Then
                Return clueID.Replace("1000", "2000")
                End If
                ElseIf roundEnum = roundType.Jeopardy Then
                Return clueID
        Else
            Return clueID
        End If
        Return clueID
    End Function
    Public Shared Function convertToR2(clueID As String) As String
        If clueID.Contains("200") Then
            Return clueID.Replace("200", "400")
        ElseIf clueID.Contains("400") Then
            Return clueID.Replace("400", "800")
        ElseIf clueID.Contains("600") Then
            Return clueID.Replace("600", "1200")
        ElseIf clueID.Contains("800") Then
            Return clueID.Replace("800", "1600")
        ElseIf clueID.Contains("1000") Then
            Return clueID.Replace("1000", "2000")
        Else
            Return clueID
        End If
    End Function
#End Region
#Region "Determine Winner"
    Public Shared Function determineFirstPlace() As Integer
        Dim winner As Integer
        If Player1List(0).Score > Player2List(0).Score And Player1List(0).Score > Player3List(0).Score Then
            winner = 1
        ElseIf Player2List(0).Score > Player1List(0).Score And Player2List(0).Score > Player3List(0).Score Then
            winner = 2
        ElseIf Player3List(0).Score > Player2List(0).Score And Player3List(0).Score > Player1List(0).Score Then
            winner = 3
        End If
        Return winner
    End Function
    Public Shared Sub determineFinalWinner()
        Dim winner = determineFirstPlace()
        Select Case winner
            Case 1
                If Player3List(0).Score > Player2List(0).Score And Player3List(0).Score < Player1List(0).Score Then
                    frmScore.lblPlayer3Score.Text = FormatCurrency(2000, 0, , TriState.False)
                    frmScore.lblPlayer2Score.Text = FormatCurrency(1000, 0, , TriState.False)
                    For Each myPlayer As Player In Player3List
                        myPlayer.Score = 2000
                    Next
                    For Each myPlayer As Player In Player2List
                        myPlayer.Score = 1000
                    Next
                Else
                    frmScore.lblPlayer2Score.Text = FormatCurrency(2000, 0, , TriState.False)
                    frmScore.lblPlayer3Score.Text = FormatCurrency(1000, 0, , TriState.False)
                    For Each myPlayer As Player In Player2List
                        myPlayer.Score = 2000
                    Next
                    For Each myPlayer As Player In Player3List
                        myPlayer.Score = 1000
                    Next
                End If
                frmScore.lblPlayer3Score.BackColor = Color.FromArgb(175, 233, 253)
                frmScore.lblPlayer3Score.ForeColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer2Score.BackColor = Color.FromArgb(175, 233, 253)
                frmScore.lblPlayer2Score.ForeColor = Color.FromArgb(0, 45, 194)
            Case 2
                If Player3List(0).Score > Player1List(0).Score And Player3List(0).Score < Player2List(0).Score Then
                    frmScore.lblPlayer3Score.Text = FormatCurrency(2000, 0, , TriState.False)
                    frmScore.lblPlayer1Score.Text = FormatCurrency(1000, 0, , TriState.False)
                    For Each myPlayer As Player In Player3List
                        myPlayer.Score = 2000
                    Next
                    For Each myPlayer As Player In Player1List
                        myPlayer.Score = 1000
                    Next
                Else
                    frmScore.lblPlayer1Score.Text = FormatCurrency(2000, 0, , TriState.False)
                    frmScore.lblPlayer3Score.Text = FormatCurrency(1000, 0, , TriState.False)
                    For Each myPlayer As Player In Player1List
                        myPlayer.Score = 2000
                    Next
                    For Each myPlayer As Player In Player3List
                        myPlayer.Score = 1000
                    Next
                End If
                frmScore.lblPlayer3Score.BackColor = Color.FromArgb(175, 233, 253)
                frmScore.lblPlayer3Score.ForeColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer1Score.BackColor = Color.FromArgb(175, 233, 253)
                frmScore.lblPlayer1Score.ForeColor = Color.FromArgb(0, 45, 194)
            Case 3
                If Player2List(0).Score > Player1List(0).Score And Player2List(0).Score < Player3List(0).Score Then
                    frmScore.lblPlayer2Score.Text = FormatCurrency(2000, 0, , TriState.False)
                    frmScore.lblPlayer1Score.Text = FormatCurrency(1000, 0, , TriState.False)
                    For Each myPlayer As Player In Player2List
                        myPlayer.Score = 2000
                    Next
                    For Each myPlayer As Player In Player1List
                        myPlayer.Score = 1000
                    Next
                Else
                    frmScore.lblPlayer1Score.Text = FormatCurrency(2000, 0, , TriState.False)
                    frmScore.lblPlayer2Score.Text = FormatCurrency(1000, 0, , TriState.False)
                    For Each myPlayer As Player In Player1List
                        myPlayer.Score = 2000
                    Next
                    For Each myPlayer As Player In Player2List
                        myPlayer.Score = 1000
                    Next
                End If
                frmScore.lblPlayer2Score.BackColor = Color.FromArgb(175, 233, 253)
                frmScore.lblPlayer2Score.ForeColor = Color.FromArgb(0, 45, 194)
                frmScore.lblPlayer1Score.BackColor = Color.FromArgb(175, 233, 253)
                frmScore.lblPlayer1Score.ForeColor = Color.FromArgb(0, 45, 194)
        End Select
    End Sub
    Public Shared Function determineLastPlace() As Integer
        If Player1List(0).Score < Player2List(0).Score And Player1List(0).Score < Player3List(0).Score Then
            Return 1
        ElseIf Player2List(0).Score < Player1List(0).Score And Player2List(0).Score < Player3List(0).Score Then
            Return 2
        ElseIf Player3List(0).Score < Player2List(0).Score And Player3List(0).Score < Player1List(0).Score Then
            Return 3
        Else
            Static Generator As Random = New System.Random()
            Dim randomPlayers As New List(Of Integer)
            If determineFirstPlace() = 1 Then
                randomPlayers.Add(2)
                randomPlayers.Add(3)
                Return randomPlayers(Generator.Next(randomPlayers.Count))
            ElseIf determineFirstPlace() = 2 Then
                randomPlayers.Add(1)
                randomPlayers.Add(3)
                Return randomPlayers(Generator.Next(randomPlayers.Count))
            ElseIf determineFirstPlace() = 3 Then
                randomPlayers.Add(1)
                randomPlayers.Add(2)
                Return randomPlayers(Generator.Next(randomPlayers.Count))
            End If
        End If
    End Function
    Public Shared Sub determineIfNegative()
        If Player1List(0).Score <= 0 Then
            frmScore.txtWager1.Hide()
        Else
            frmScore.txtWager1.Show()
        End If
        If Player2List(0).Score <= 0 Then
            frmScore.txtWager2.Hide()
        Else
            frmScore.txtWager2.Show()
        End If
        If Player3List(0).Score <= 0 Then
            frmScore.txtWager3.Hide()
        Else
            frmScore.txtWager3.Show()
        End If
    End Sub
    Public Shared Function determineIfNegative(playerNumber As Integer) As Integer
        Select Case playerNumber
            Case 1
                If Player1List(0).Score <= 0 Then
                    Return True
                End If
            Case 2
                If Player2List(0).Score <= 0 Then
                    Return True
                End If
            Case 3
                If Player3List(0).Score <= 0 Then
                    Return True
                End If
        End Select
        Return False
    End Function
#End Region
End Class
