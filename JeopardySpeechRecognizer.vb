Imports System.Speech.Recognition
Public Class JeopardySpeechRecognizer
    Inherits SpeechRecognitionEngine
    ' word list (do not use this object, the program already creates this when reading the XML file.)
    'Dim wordlist As String() = New String() {"Who is Freddie Mercury", "Who is Venus Williams", "Who is Bruno Mars", "What are Neptunes", "Who are Neptunes", "What are The Neptunes", "Who are The Neptunes", "Who is Sun Yat-Sen", "What is Hallmark", "Who is Daryl Hall", "Who is Halle Berry", "What is Halloween", "What is Harry Potter and the Deathly Hallows", "What is The Sound of Music", "What is Sound of Music", "What is the Lord of the Rings", "What is Lord of the Rings", "What is Disneyland", "What is Alice in Wonderland", "What is Back to the Future", "What is covalent bond", "What is a covalent bond", "What is treasury bond", "What is a treasury bond", "Who is Barry Bonds", "What is vagabond", "What is a vagabond", "What is bail bond", "What is a bail bond", "What is obstructionist", "What is an obstructionist", "What is oligarchy", "What is an oligarchy", "What is a patriarchy", "What is patriarchy", "What is petroleum", "What is gospel", "What is a gospel", "What is thermal detonator", "What is a thermal detonator", "What is Tatooine", "What is carbonite", "What is padawan", "What is a padawan", "What is Mos Eisley cantina", "What is the Mos Eisley cantina", "What is a security bond", "Astronomical Figures for 400", "Astronomical Figures 400", "400 Astronomical Figures", "Astronomical Figures for 400", "Astronomical Figures 400", "400 Astronomical Figures", "Astronomical Figures for 600", "Astronomical Figures 600", "600 Astronomical Figures", "Astronomical Figures for 800", "Astronomical Figures 800", "800 Astronomical Figures", "Astronomical Figures for 1000", "Astronomical Figures 1000", "1000 Astronomical Figures", "Deck the Halls for 400", "Deck the Halls 400", "400 Deck the Halls", "Deck the Halls for 400", "Deck the Halls 400", "400 Deck the Halls", "Deck the Halls for 600", "Deck the Halls 600", "600 Deck the Halls", "Deck the Halls for 800", "Deck the Halls 800", "800 Deck the Halls", "Deck the Halls for 1000", "Deck the Halls 1000", "1000 Deck the Halls", "Anniversaries of 4015 for 400", "Anniversaries of 4015 400", "400 Anniversaries of 4015", "Anniversaries of 4015 for 400", "Anniversaries of 4015 400", "400 Anniversaries of 4015", "Anniversaries of 4015 for 600", "Anniversaries of 4015 600", "600 Anniversaries of 4015", "Anniversaries of 4015 for 800", "Anniversaries of 4015 800", "800 Anniversaries of 4015", "Anniversaries of 4015 for 1000", "Anniversaries of 4015 1000", "1000 Anniversaries of 4015", "The Name is Bond for 400", "The Name is Bond 400", "400 The Name is Bond", "The Name is Bond for 400", "The Name is Bond 400", "400 The Name is Bond", "The Name is Bond for 600", "The Name is Bond 600", "600 The Name is Bond", "The Name is Bond for 800", "The Name is Bond 800", "800 The Name is Bond", "The Name is Bond for 1000", "The Name is Bond 1000", "1000 The Name is Bond", "The GOP Party for 400", "The GOP Party 400", "400 The GOP Party", "The GOP Party for 400", "The GOP Party 400", "400 The GOP Party", "The GOP Party for 600", "The GOP Party 600", "600 The GOP Party", "The GOP Party for 800", "The GOP Party 800", "800 The GOP Party", "The GOP Party for 1000", "The GOP Party 1000", "1000 The GOP Party", "May the Force Be With You for 400", "May the Force Be With You 400", "400 May the Force Be With You", "May the Force Be With You for 400", "May the Force Be With You 400", "400 May the Force Be With You", "May the Force Be With You for 600", "May the Force Be With You 600", "600 May the Force Be With You", "May the Force Be With You for 800", "May the Force Be With You 800", "800 May the Force Be With You", "May the Force Be With You for 1000", "May the Force Be With You 1000", "1000 May the Force Be With You"}
    Public Enum LoadCommand
        Clue
        Category
    End Enum
    Public recognizerOn As Boolean = True
    Dim recognized = False
    Dim SAPI
    Dim slp As New SpeechListenerProcess
    'recogniser & grammar
    'Dim jSpeechRecog. As New SpeechRecognitionEngine
    Dim cluesgram As Grammar
    Dim categorygram As Grammar
    ' events
    'Private Shadows Event SpeechRecognized As _
    'EventHandler(Of SpeechRecognizedEventArgs)
    'Private Shadows Event SpeechRecognitionRejected As _
    'EventHandler(Of SpeechRecognitionRejectedEventArgs)
    Public cluelist As String()
    Public categorylist As String()
    Public seenclues As New List(Of String)
    Public QuestionMode As Boolean = False
    Public categoryMode As Boolean = False
    Public allowCatMode As Boolean = False
    Public Sub addToList(myList As List(Of String), myCommand As LoadCommand)
        If myCommand = LoadCommand.Clue Then
            cluelist = myList.ToArray()
        ElseIf myCommand = LoadCommand.Category Then
            categorylist = myList.ToArray()
        Else
        End If
    End Sub
    Public Sub loadGrammarObject(myCommand As LoadCommand)
        If myCommand = LoadCommand.Clue Then
            ' convert the word list into a grammar
            Dim clues As New Choices(cluelist)
            cluesgram = New Grammar(New GrammarBuilder(clues))
            LoadGrammar(cluesgram)
            categoryMode = False
            QuestionMode = True
        ElseIf myCommand = LoadCommand.Category Then
            ' convert the word list into a grammar
            Dim categories As New Choices(categorylist)
            categorygram = New Grammar(New GrammarBuilder(categories))
            LoadGrammar(categorygram)
        End If

    End Sub
    'Public Sub checkRecognition()
    '    'Label4.Text = "No player has rung in"
    '    'TextBox1.Text = e.Result.Text
    '    'If ScoreForm.IsDailyDouble = False Then

    'End Sub
    Public Sub addToSeenCluesList(catstring As String, currentPointValue As Integer)
        Dim finalcatstring1 As String = catstring + currentPointValue.ToString()
        Dim finalcatstring2 As String = catstring + "for" + currentPointValue.ToString()
        Dim finalcatstring3 As String = currentPointValue.ToString() + catstring
        seenclues.Add(finalcatstring1)
        seenclues.Add(finalcatstring2)
        seenclues.Add(finalcatstring3)
    End Sub
End Class
Public Class SpeechListenerProcess
    Private SRProcess As New Process
    Private isRunning As Boolean
    Public Sub [Start]()
        If Not isRunning Then
            SRProcess.StartInfo.FileName = "c:  \Windows\Speech\common\sapisvr.exe"
            SRProcess.StartInfo.Arguments = "-SpeechUX"
            SRProcess.Start()
            isRunning = True
        End If
    End Sub
    Public Sub [Stop]()
        If isRunning Then
            SRProcess.Kill()
            isRunning = False
            SRProcess = New Process
        End If
    End Sub
End Class
