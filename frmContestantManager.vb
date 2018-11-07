Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmContestantManager
    Private Sub frmContestantManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getContestantNames()
    End Sub
    Private Sub frmContestantManager_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If categoryScreen.Visible = False Then
            WelcomeScreen.Show()
            My.Computer.Audio.Play(My.Resources.theme, AudioPlayMode.BackgroundLoop)
        Else
            'dlgPauseMenu.Show()
            frmScore.Show()
        End If
    End Sub
    Private Sub getContestantNames()
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Player"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        Do While rdr.Read()
            Dim newContestant = New ContestantDisplay
            newContestant.ContestantID = Trim(rdr("Id"))
            newContestant.ContestantName = Trim(rdr("Name")).ToString
            newContestant.Total = Trim(rdr("Total")).ToString
            flpContestants.Controls.Add(newContestant)
        Loop
        connPuzzle.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lblNewContestant_Click(sender As Object, e As EventArgs) Handles lblNewContestant.Click
        flpContestants.Controls.Add(New ContestantDisplay)
    End Sub
End Class
