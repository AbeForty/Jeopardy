Public Class ScreenBypass
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Welcome Screen" Then
            My.Computer.Audio.Stop()
            WelcomeScreen.Show()
            WelcomeScreen.Close()
            Me.Close()
        ElseIf ComboBox1.SelectedItem = "Intro Screen" Then
            My.Computer.Audio.Stop()
            IntroScreen.Show()
            WelcomeScreen.Close()
            Me.Close()
        ElseIf ComboBox1.SelectedItem = "Category Board" Then
            My.Computer.Audio.Stop()
            catChooser.Show()
            categoryScreen.Show()
            WelcomeScreen.Close()
            Me.Close()
        ElseIf ComboBox1.SelectedItem = "Final Jeopardy" Then
            My.Computer.Audio.Stop()
            FinalJeopardy.Show()
            WelcomeScreen.Close()
            Me.Close()
        ElseIf ComboBox1.SelectedItem = "Variable Testing Fast" Then
            My.Computer.Audio.Stop()
            catChooser.Show()
            VariableTesting.Show()
            categoryScreen.Show()
            WelcomeScreen.Close()
            Me.Close()
        ElseIf ComboBox1.SelectedItem = "Variable Testing Normal" Then
            My.Computer.Audio.Stop()
            VariableTesting.Show()
            IntroScreen.Show()
            WelcomeScreen.Close()
            Me.Close()
        ElseIf ComboBox1.SelectedItem = "Customizer" Then
            My.Computer.Audio.Stop()
            Customizer.Show()
            WelcomeScreen.Close()
            Me.Close()
        End If
    End Sub
End Class