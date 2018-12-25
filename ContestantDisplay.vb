Imports System.Data.SqlClient
Public Class ContestantDisplay
    Public Property ContestantID As Integer
    Public Property ContestantName As String
        Get
            Return NameTag1.Text
        End Get
        Set(value As String)
            NameTag1.Text = value
        End Set
    End Property
    Public Property Total As Integer
        Get
            Return Integer.Parse(lblTotal.Text.Replace("$", "").Replace(",", ""))
        End Get
        Set(value As Integer)
            lblTotal.Text = FormatCurrency(value, 0)
        End Set
    End Property

    Private Sub txtPlayer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlayer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            CType(sender, TextBox).Hide()
            If checkIfExists() = False And ContestantName.ToLower <> "name" Then
                Dim connPuzzle As SqlConnection
                connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\JeopardyClues.mdf;Integrated Security=True")
                Dim strSQL As String
                strSQL = "INSERT INTO Player VALUES (@Name, @Total)"
                Dim cmd As SqlCommand
                Dim nameParam As SqlParameter = New SqlParameter("@Name", ContestantName)
                Dim winningsParam As SqlParameter = New SqlParameter("@Total", 0)
                connPuzzle.Open()
                cmd = New SqlCommand(strSQL, connPuzzle)
                cmd.Parameters.Add(nameParam)
                cmd.Parameters.Add(winningsParam)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
                connPuzzle.Close()
            Else
                MessageBox.Show("Either a contestant already exists with this name or name is invalid. Please choose another name.", "JEOPARDY!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
    Private Function checkIfExists() As Boolean
        Dim connPuzzle As SqlConnection
        connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\JeopardyClues.mdf;Integrated Security=True")
        Dim strSQL As String
        strSQL = "SELECT * FROM Player WHERE Name = @Name"
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim nameParam As SqlParameter = New SqlParameter("@Name", ContestantName)
        connPuzzle.Open()
        cmd = New SqlCommand(strSQL, connPuzzle)
        cmd.Parameters.Add(nameParam)
        cmd.CommandType = CommandType.Text
        rdr = cmd.ExecuteReader()
        If rdr.HasRows Then
            Return True
        Else
            Return False
        End If
        connPuzzle.Close()
        Return False
    End Function
    Private Sub ContestantDisplay_Load(sender As Object, e As EventArgs) Handles Me.Load
        If NameTag1.lblName.Text = "NAME" Then
            txtPlayer.Show()
        End If
        If ParentForm Is frmContestantManager Or TypeOf (Parent.Parent) Is TeamDisplay Then
            btnDelete.Show()
        End If
    End Sub

    Private Sub txtPlayer_TextChanged(sender As Object, e As EventArgs) Handles txtPlayer.TextChanged
        ContestantName = txtPlayer.Text.ToUpper
    End Sub
    Private Sub loadContestantData()
        If ParentForm Is frmContestantManager Then
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\JeopardyClues.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "SELECT Game.PackName, Game.created_at, GamePlayer.Score FROM GamePlayer JOIN Game ON GamePlayer.GameID = Game.Id WHERE PlayerID = @Contestant_ID"
            Dim cmd As SqlCommand
            Dim rdr As SqlDataReader
            connPuzzle.Open()
            Dim contestantIDParam As SqlParameter = New SqlParameter("@Contestant_ID", ContestantID)
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add(contestantIDParam)
            rdr = cmd.ExecuteReader()
            If rdr.HasRows Then
                frmContestantManager.flpStatistics.Controls.Clear()
                frmContestantManager.lblNoGames.Hide()
                frmContestantManager.lblSelectContestant.Hide()
                Do While rdr.Read()
                    Dim newStat = New StatsControl
                    newStat.packName = Trim(rdr("PackName"))
                    newStat.datePlayed = Trim(rdr("created_at"))
                    newStat.winnings = FormatCurrency(Trim(rdr("Score")), 0)
                    frmContestantManager.flpStatistics.Controls.Add(newStat)
                Loop
            Else
                frmContestantManager.lblNoGames.Show()
                frmContestantManager.lblSelectContestant.Hide()
            End If
            connPuzzle.Close()
        ElseIf ParentForm Is ContestantControl Then
            ContestantControl.DialogResult = DialogResult.OK
            ContestantControl.contestantID = ContestantID
            ContestantControl.contestantName = ContestantName
            ContestantControl.score = Total
        End If
    End Sub
    Private Sub lblTotalContestantDisplay_Click(sender As Object, e As EventArgs) Handles lblTotal.Click, NameTag1.Click, Me.Click
        loadContestantData()
    End Sub
    Private Sub deleteContestant()
        If ParentForm Is frmContestantManager Then
            Dim connPuzzle As SqlConnection
            connPuzzle = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\JeopardyClues.mdf;Integrated Security=True")
            Dim strSQL As String
            strSQL = "Delete From Player WHERE Id = @Contestant_ID"
            Dim cmd As SqlCommand
            Dim gamePlayerCmd As SqlCommand
            connPuzzle.Open()
            Dim contestantIDParam As SqlParameter = New SqlParameter("@Contestant_ID", ContestantID)
            Dim contestantID2Param As SqlParameter = New SqlParameter("@Contestant_ID", ContestantID)
            cmd = New SqlCommand(strSQL, connPuzzle)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add(contestantIDParam)
            cmd.ExecuteNonQuery()
            connPuzzle.Close()
            Dim myStrSQL As String
            myStrSQL = "Delete From GamePlayer WHERE PlayerID = @Contestant_ID"
            Dim gamescmd As SqlCommand
            connPuzzle.Open()
            gamePlayerCmd = New SqlCommand(myStrSQL, connPuzzle)
            gamePlayerCmd.CommandType = CommandType.Text
            gamePlayerCmd.Parameters.Add(contestantID2Param)
            gamePlayerCmd.ExecuteNonQuery()
            connPuzzle.Close()
            frmContestantManager.flpContestants.Controls.Remove(Me)
        Else
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If ParentForm Is frmContestantManager Then
            Dim result As Integer = MessageBox.Show("Are you sure you want to delete this contestant? All winnings will be lost and any current games with this contestant will be deleted. This action cannot be undone.", "JEOPARDY!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                deleteContestant()
            End If
        ElseIf TypeOf (Parent.Parent) Is TeamDisplay Then
            JeopardyController.removeByID(ContestantID)
            CType(Parent.Parent, TeamDisplay).flpContestants.Controls.Remove(Me)
            JeopardyController.numberOfPlayers -= 1
            If JeopardyController.numberOfPlayers = 0 Then
                frmNewGame.lblQuickGame.Show()
                frmNewGame.txtPlayer1.Show()
                frmNewGame.txtPlayer2.Show()
                frmNewGame.txtPlayer3.Show()
            End If
        End If
    End Sub
End Class