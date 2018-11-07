Public Class categoryScreen

    Private Sub tmrRingIn_Tick(sender As Object, e As EventArgs) Handles tmrRingIn.Tick
        'JeopardyController.ringIn()
        JeopardyController.ringInManual()
    End Sub
    Private Sub categoryScreen_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        VariableTesting.Close()
        catChooser.Close()
    End Sub
    Private Sub categoryScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'wmpCategory.Ctlcontrols.stop()
        'My.Computer.Audio.Play(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\categorychooser.wav")
        'catChooserPlayer.URL = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\OneDrive\Jeopardy\categorychooser.wav"
        'catChooserPlayer.Ctlcontrols.play()
        JeopardyController.roundForm = Me
        clue.Hide()
        JeopardyController.loadClues(JeopardyController.packName, JeopardyController.roundEnum)
        cat1Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        cat2Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        cat3Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        cat4Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        cat5Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
        cat6Title.catBrowserSmall.Navigate(JeopardyController.finalURL & "\Resources\category.html")
    End Sub
    Private Sub categoryScreen_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'JeopardyController.initializeGame()
        JeopardyController.initializeGameManual(JeopardyController.roundEnum)
    End Sub
    Private Sub tmrCatReveal_Tick(sender As Object, e As EventArgs) Handles tmrCatReveal.Tick
        JeopardyController.performCategoryReveal()
    End Sub
    'Private Sub clue_Click(sender As Object, e As EventArgs) Handles clue.Click
    '    clue.Hide()
    'End Sub
    Private Sub tmrCheckReveal_Tick(sender As Object, e As EventArgs) Handles tmrCheckReveal.Tick
        JeopardyController.checkIfCategoriesRevealed()
    End Sub
    'Private Sub AxWindowsMediaPlayer1_ClickEvent(sender As Object, e As AxWMPLib._WMPOCXEvents_ClickEvent)
    '    'If wmpCategory.playState = WMPLib.WMPPlayState.wmppsPlaying Then
    '    '    wmpCategory.Ctlcontrols.pause()
    '    'Else
    '    '    wmpCategory.Ctlcontrols.play()
    '    'End If
    'End Sub
    'Private Sub AxWindowsMediaPlayer1_KeyPressEvent(sender As Object, e As AxWMPLib._WMPOCXEvents_KeyPressEvent)
    '    'If e.nKeyAscii = Keys.Space Then
    '    '    If wmpCategory.playState = WMPLib.WMPPlayState.wmppsPlaying Then
    '    '        wmpCategory.Ctlcontrols.pause()
    '    '    Else
    '    '        wmpCategory.Ctlcontrols.play()
    '    '    End If
    '    'Else
    '    'End If
    'End Sub
    Private Sub tmrPointValueBox_Tick(sender As Object, e As EventArgs) Handles tmrPointValueBox.Tick
        JeopardyController.showPointValueBox()
    End Sub
    Private Sub tmrCheckCatCleared_Tick(sender As Object, e As EventArgs) Handles tmrCheckCatCleared.Tick
        JeopardyController.checkIfCategoryCleared()
    End Sub
    Private Sub tmrCheckIfRungIn_Tick(sender As Object, e As EventArgs) Handles tmrCheckIfRungIn.Tick
        JeopardyController.checkIfRungIn()
    End Sub
    'Private Sub FinalJeopardyBox_click(sender As Object, e As EventArgs) Handles FinalJeopardyBox.Click
    '    FinalJeopardy.Show()
    '    Me.Close()
    'End Sub
    Private Sub tmrCheckCurrentRound_Tick(sender As Object, e As EventArgs) Handles tmrCheckCurrentRound.Tick
        If JeopardyController.doubleJeopardyExists = True Then
            JeopardyController.checkDoubleJeopardy()
        End If
        JeopardyController.checkFinalJeopardy()
    End Sub
    Private Sub tmrCheckRecogStopped_Tick(sender As Object, e As EventArgs) Handles tmrCheckRecogStopped.Tick
        JeopardyController.ifRecogStopped()
    End Sub
    Private Sub tmrCheckIfSelectCategory_Tick(sender As Object, e As EventArgs) Handles tmrCheckIfSelectCategory.Tick
        JeopardyController.checkIfSelectCategory()
    End Sub
    Private Sub aClue_Click(sender As Object, e As EventArgs) Handles Cat1200.Click, Cat1400.Click, Cat1600.Click, Cat1800.Click, Cat11000.Click, Cat2200.Click, Cat2400.Click, Cat2600.Click, Cat2800.Click, Cat21000.Click, Cat3200.Click, Cat3400.Click, Cat3600.Click, Cat3800.Click, Cat31000.Click, Cat4200.Click, Cat4400.Click, Cat4600.Click, Cat4800.Click, Cat41000.Click, Cat5200.Click, Cat5400.Click, Cat5600.Click, Cat5800.Click, Cat51000.Click, Cat6200.Click, Cat6400.Click, Cat6600.Click, Cat6800.Click, Cat61000.Click
        CType(sender, PictureBox).Image = My.Resources.BlankTile
        If CType(sender, PictureBox).Name.Length = 8 Then
            Dim strCatNumberPreformatted As String = CType(sender, PictureBox).Name.Remove(0, 3)
            Dim strCatNumber As String = strCatNumberPreformatted.Remove(1, 4)
            'MsgBox(CType(sender, PictureBox).Name)
            Dim catNumber As Integer = Integer.Parse(strCatNumber)
            'MsgBox(strCatNumber)
            '21000
            Dim strclueValue As String = CType(sender, PictureBox).Name.Remove(0, 4)
            JeopardyController.currentPointValue = Integer.Parse(strclueValue)
            If JeopardyController.lstClues.ContainsKey(strCatNumberPreformatted) Then
                For Each clueEntry As KeyValuePair(Of Integer, Clue) In JeopardyController.lstClues
                    Dim categoryNumber As Integer = strCatNumber
                    Dim categoryName As String = JeopardyController.lstClues(strCatNumberPreformatted).category
                    'Dim categoryNumber As Integer = clueEntry.Key
                    'Dim categoryName As String = clueEntry.Value.category
                    ''MsgBox(categoryName & vbCrLf & categoryNumber)
                    'If (catNumber = categoryNumber) Then
                    ''JeopardyController.loadClue(CType(sender, PictureBox).Name)
                    'End If
                Next
            Else
            End If
            JeopardyController.loadClue(CType(sender, PictureBox).Name)
        ElseIf CType(sender, PictureBox).Name.Length = 7 Then
            Dim strCatNumberPreformatted As String = CType(sender, PictureBox).Name.Remove(0, 3)
            'MsgBox(CType(sender, PictureBox).Name)
            Dim strCatNumber As String = strCatNumberPreformatted.Remove(1, 3)
            Dim catNumber As Integer = Integer.Parse(strCatNumber)
            'MsgBox(strCatNumber)
            Dim strclueValue As String = strCatNumberPreformatted.Remove(0, 1)
            JeopardyController.currentPointValue = Integer.Parse(strclueValue)
            If JeopardyController.lstClues.ContainsKey(strCatNumberPreformatted) Then
                Dim categoryNumber As Integer = strCatNumber
                Dim categoryName As String = JeopardyController.lstClues(strCatNumberPreformatted).category
                'For Each clueEntry As KeyValuePair(Of Integer, Clue) In JeopardyController.lstClues
                '    Dim categoryNumber As Integer = clueEntry.Key
                '    Dim categoryName As String = clueEntry.Value.category
                '    'MsgBox(categoryName & vbCrLf & categoryNumber)
                '    If (catNumber = categoryNumber) Then
                '    End If
                'Next
            Else
            End If
            JeopardyController.loadClue(CType(sender, PictureBox).Name)
        End If
        'JeopardyController.loadClue(CType(sender, PictureBox).Name)
        JeopardyController.questionMode = True
        JeopardyController.categoryMode = False
        tmrPointValueBox.Start()
    End Sub
    Private Sub CategoryScreen_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout
        If pbarLoadCat.Value = 100 Then
            categoryPanel.BackgroundImage = Nothing
            For Each item In JeopardyController.set1
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
        If pbarLoadCat.Value = 200 Then
            For Each item In JeopardyController.set2
                If JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(item)) = True Then
                    CType(categoryPanel.Controls(item), PictureBox).Image = My.Resources.BlankTile
                End If
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
        If pbarLoadCat.Value = 300 Then
            For Each item In JeopardyController.set3
                If JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(item)) = True Then
                    CType(categoryPanel.Controls(item), PictureBox).Image = My.Resources.BlankTile
                End If
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
        If pbarLoadCat.Value = 400 Then
            For Each item In JeopardyController.set4
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
        If pbarLoadCat.Value = 500 Then
            For Each item In JeopardyController.set5
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        If pbarLoadCat.Value = 600 Then
            For Each item In JeopardyController.set6
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
        If pbarLoadCat.Value = 700 Then
            For Each item In JeopardyController.set7
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
        If pbarLoadCat.Value = 800 Then
            For Each item In JeopardyController.set8
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        If pbarLoadCat.Value = 900 Then
            For Each item In JeopardyController.set9
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
        If pbarLoadCat.Value = 1000 Then
            For Each item In JeopardyController.set10
                categoryPanel.Controls(item).Show()
                categoryPanel.Controls(item).Refresh()
            Next
        End If
        'For myI = 100 To 200
        '    pbarLoadCat.Value += 1
        'Next
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        JeopardyController._fadeOpacity = CSng(TrackBar1.Value / TrackBar1.Maximum)
    End Sub

    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        JeopardyController._fadeOpacity2 = CSng(TrackBar2.Value / TrackBar2.Maximum)
    End Sub
    Private Sub TrackBar3_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar3.ValueChanged
        JeopardyController._fadeOpacity3 = CSng(TrackBar3.Value / TrackBar3.Maximum)
    End Sub
    Private Sub TrackBar4_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar4.ValueChanged
        JeopardyController._fadeOpacity4 = CSng(TrackBar4.Value / TrackBar4.Maximum)
    End Sub
    Private Sub TrackBar5_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar5.ValueChanged
        JeopardyController._fadeOpacity5 = CSng(TrackBar5.Value / TrackBar5.Maximum)
    End Sub
    Private Sub TrackBar6_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar6.ValueChanged
        JeopardyController._fadeOpacity6 = CSng(TrackBar6.Value / TrackBar6.Maximum)
    End Sub
    Private Sub TrackBar7_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar7.ValueChanged
        JeopardyController._fadeOpacity7 = CSng(TrackBar7.Value / TrackBar7.Maximum)
    End Sub
    Private Sub TrackBar8_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar8.ValueChanged
        JeopardyController._fadeOpacity8 = CSng(TrackBar8.Value / TrackBar8.Maximum)
    End Sub
    Private Sub TrackBar9_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar9.ValueChanged
        JeopardyController._fadeOpacity9 = CSng(TrackBar9.Value / TrackBar9.Maximum)
    End Sub
    Private Sub TrackBar10_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar10.ValueChanged
        JeopardyController._fadeOpacity10 = CSng(TrackBar10.Value / TrackBar10.Maximum)
    End Sub
    Private Sub Cat200_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Cat1200.Paint, Cat2200.Paint, Cat3200.Paint, Cat4200.Paint, Cat5200.Paint, Cat6200.Paint
        If JeopardyController._fadeOpacity < 100 AndAlso JeopardyController.oldImage IsNot Nothing OrElse JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
        End If
        If JeopardyController._fadeOpacity > 0 AndAlso JeopardyController.newImage200 IsNot Nothing Then
            If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage200, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage400, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            End If
        End If
        If JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
            CType(sender, Control).Enabled = False
        End If
    End Sub
    Private Sub Cat400_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Cat1400.Paint, Cat2400.Paint, Cat3400.Paint, Cat4400.Paint, Cat5400.Paint, Cat6400.Paint
        If JeopardyController._fadeOpacity < 100 AndAlso JeopardyController.oldImage IsNot Nothing OrElse JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
        End If
        If JeopardyController._fadeOpacity > 0 AndAlso JeopardyController.newImage400 IsNot Nothing Then
            If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage400, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage800, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            End If
        End If
        If JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
            CType(sender, Control).Enabled = False
        End If
    End Sub
    Private Sub Cat600_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Cat1600.Paint, Cat2600.Paint, Cat3600.Paint, Cat4600.Paint, Cat5600.Paint, Cat6600.Paint
        If JeopardyController._fadeOpacity < 100 AndAlso JeopardyController.oldImage IsNot Nothing OrElse JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
        End If
        If JeopardyController._fadeOpacity > 0 AndAlso JeopardyController.newImage600 IsNot Nothing Then
            If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage600, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage1200, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            End If
        End If
        If JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
            CType(sender, Control).Enabled = False
        End If
    End Sub
    Private Sub Cat800_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Cat1800.Paint, Cat2800.Paint, Cat3800.Paint, Cat4800.Paint, Cat5800.Paint, Cat6800.Paint
        If JeopardyController._fadeOpacity < 100 AndAlso JeopardyController.oldImage IsNot Nothing OrElse JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
        End If
        If JeopardyController._fadeOpacity > 0 AndAlso JeopardyController.newImage800 IsNot Nothing OrElse Not JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) Then
            If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage800, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage1600, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            End If
        End If
        If JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
            CType(sender, Control).Enabled = False
        End If
    End Sub
    Private Sub Cat1000_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Cat11000.Paint, Cat21000.Paint, Cat31000.Paint, Cat41000.Paint, Cat51000.Paint, Cat61000.Paint
        If JeopardyController._fadeOpacity < 100 AndAlso JeopardyController.oldImage IsNot Nothing OrElse JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
        End If
        If JeopardyController._fadeOpacity > 0 AndAlso JeopardyController.newImage1000 IsNot Nothing Then
            If JeopardyController.roundEnum = JeopardyController.roundType.Jeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage1000, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            ElseIf JeopardyController.roundEnum = JeopardyController.roundType.DoubleJeopardy Then
                Using fadedImage As Bitmap = JeopardyController.FadeBitmap(JeopardyController.newImage2000, JeopardyController._fadeOpacity)
                    e.Graphics.DrawImageUnscaled(fadedImage, Point.Empty)
                End Using
            End If
        End If
        If JeopardyController.checkClueList(JeopardyController.convertClueIDToR2(CType(sender, Control).Name)) = True Then
            e.Graphics.DrawImageUnscaled(JeopardyController.oldImage, Point.Empty)
            CType(sender, Control).Enabled = False
        End If
    End Sub
    Private Sub clue_DoubleClick(sender As Object, e As EventArgs)
        JeopardyController.setAnswerValue(False)
        JeopardyController.ifNoRingIn()
    End Sub

    Private Sub Cat_EnabledChanged(sender As Object, e As EventArgs) Handles Cat1200.EnabledChanged, Cat1400.EnabledChanged, Cat1600.EnabledChanged, Cat1800.EnabledChanged, Cat11000.EnabledChanged, Cat2200.EnabledChanged, Cat2400.EnabledChanged, Cat2600.EnabledChanged, Cat2800.EnabledChanged, Cat21000.EnabledChanged, Cat3200.EnabledChanged, Cat3400.EnabledChanged, Cat3600.EnabledChanged, Cat3800.EnabledChanged, Cat31000.EnabledChanged, Cat4200.EnabledChanged, Cat4400.EnabledChanged, Cat4600.EnabledChanged, Cat4800.EnabledChanged, Cat41000.EnabledChanged, Cat5200.EnabledChanged, Cat5400.EnabledChanged, Cat5600.EnabledChanged, Cat5800.EnabledChanged, Cat51000.EnabledChanged, Cat6200.EnabledChanged, Cat6400.EnabledChanged, Cat6600.EnabledChanged, Cat6800.EnabledChanged, Cat61000.EnabledChanged
        CType(sender, PictureBox).Image = My.Resources.BlankTile
    End Sub

    '    Private Sub timeOutTimer_Tick(sender As Object, e As EventArgs) Handles timeOutTimer.Tick
    '        'checkIfTimedOut(JeopardyController.TimeOutCommand.Inactivity)
    '        Dim mySecond
    '        Dim mySecondTwo = 0
    '        If mySecond = mySecondTwo + 10 Then
    '            mySecond = 0
    '            timeOutTimer.Stop()
    '            JeopardyController.setAnswerValue(False)
    '            MsgBox("Times Up")
    '        End If
    '    End Sub

    '    Private Sub playerTimeOutTimer_Tick(sender As Object, e As EventArgs) Handles playerTimeOutTimer.Tick
    '        'checkIfTimedOut(JeopardyController.TimeOutCommand.Player)
    '        Dim mySecond
    '        Dim mySecondTwo = 0
    '        If mySecond = mySecondTwo + 5 Then
    '            mySecond = 0
    '            playerTimeOutTimer.Start()
    '            MsgBox("Times Up")
    '        End If
    '    End Sub
    '#Region "Time Out Code"
    '    'Public Shared Sub checkIfTimedOut(tmOutCmd As TimeOutCommand)

    '    '    mySecond += 1
    '    '    If tmOutCmd = TimeOutCommand.Inactivity Then

    '    '    ElseIf tmOutCmd = TimeOutCommand.Player Then

    '    '    End If
    '    'End Sub
    '#End Region
End Class

