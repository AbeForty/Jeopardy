Public Class SettingsScreen
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        IntroScreen.Show()
        Me.Close()
    End Sub

    Private Sub SettingsScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Label1.Text = TextBox1.Text
        ScoreForm.Label4.Text = TextBox1.Text
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Label2.Text = TextBox2.Text
        ScoreForm.Label5.Text = TextBox2.Text
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Label3.Text = TextBox3.Text
        ScoreForm.Label6.Text = TextBox3.Text
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class