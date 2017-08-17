<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScore
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScore))
        Me.tmrCurrentValue = New System.Windows.Forms.Timer(Me.components)
        Me.pnlScore = New System.Windows.Forms.Panel()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnDoubleJeopardy = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.lblConfidence = New System.Windows.Forms.Label()
        Me.txtRecognition = New System.Windows.Forms.TextBox()
        Me.numPlayer1 = New System.Windows.Forms.NumericUpDown()
        Me.numPlayer2 = New System.Windows.Forms.NumericUpDown()
        Me.notifyBar = New System.Windows.Forms.Label()
        Me.lblPlayer2 = New System.Windows.Forms.Label()
        Me.btnFinalJeopardy = New System.Windows.Forms.Button()
        Me.lblPlayer1 = New System.Windows.Forms.Label()
        Me.quitBTN = New System.Windows.Forms.Button()
        Me.txtCurrentPlayer = New System.Windows.Forms.TextBox()
        Me.lblPlayer1Score = New System.Windows.Forms.Label()
        Me.lblCurrentValue = New System.Windows.Forms.Label()
        Me.numPlayer3 = New System.Windows.Forms.NumericUpDown()
        Me.lblPlayer3Score = New System.Windows.Forms.Label()
        Me.lblPlayer2Score = New System.Windows.Forms.Label()
        Me.lblPlayer3 = New System.Windows.Forms.Label()
        Me.txtWager3 = New System.Windows.Forms.TextBox()
        Me.txtWager2 = New System.Windows.Forms.TextBox()
        Me.txtWager1 = New System.Windows.Forms.TextBox()
        Me.lblPlayerWagerMessage = New System.Windows.Forms.Label()
        Me.pnlScore.SuspendLayout()
        CType(Me.numPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPlayer2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPlayer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrCurrentValue
        '
        '
        'pnlScore
        '
        Me.pnlScore.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.pnlScore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlScore.Controls.Add(Me.btnHelp)
        Me.pnlScore.Controls.Add(Me.btnDoubleJeopardy)
        Me.pnlScore.Controls.Add(Me.btnGo)
        Me.pnlScore.Controls.Add(Me.btnNo)
        Me.pnlScore.Controls.Add(Me.btnYes)
        Me.pnlScore.Controls.Add(Me.lblConfidence)
        Me.pnlScore.Controls.Add(Me.txtRecognition)
        Me.pnlScore.Controls.Add(Me.numPlayer1)
        Me.pnlScore.Controls.Add(Me.numPlayer2)
        Me.pnlScore.Controls.Add(Me.notifyBar)
        Me.pnlScore.Controls.Add(Me.lblPlayer2)
        Me.pnlScore.Controls.Add(Me.btnFinalJeopardy)
        Me.pnlScore.Controls.Add(Me.lblPlayer1)
        Me.pnlScore.Controls.Add(Me.quitBTN)
        Me.pnlScore.Controls.Add(Me.txtCurrentPlayer)
        Me.pnlScore.Controls.Add(Me.lblPlayer1Score)
        Me.pnlScore.Controls.Add(Me.lblCurrentValue)
        Me.pnlScore.Controls.Add(Me.numPlayer3)
        Me.pnlScore.Controls.Add(Me.lblPlayer3Score)
        Me.pnlScore.Controls.Add(Me.lblPlayer2Score)
        Me.pnlScore.Controls.Add(Me.lblPlayer3)
        Me.pnlScore.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlScore.Location = New System.Drawing.Point(0, 0)
        Me.pnlScore.Name = "pnlScore"
        Me.pnlScore.Size = New System.Drawing.Size(1932, 125)
        Me.pnlScore.TabIndex = 29
        '
        'btnHelp
        '
        Me.btnHelp.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardyQuiz
        Me.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHelp.Location = New System.Drawing.Point(1663, 39)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(51, 49)
        Me.btnHelp.TabIndex = 33
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnDoubleJeopardy
        '
        Me.btnDoubleJeopardy.BackgroundImage = Global.Jeopardy.My.Resources.Resources.DoubleJeopardyCard
        Me.btnDoubleJeopardy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDoubleJeopardy.Location = New System.Drawing.Point(1720, 41)
        Me.btnDoubleJeopardy.Name = "btnDoubleJeopardy"
        Me.btnDoubleJeopardy.Size = New System.Drawing.Size(75, 46)
        Me.btnDoubleJeopardy.TabIndex = 32
        Me.btnDoubleJeopardy.UseVisualStyleBackColor = True
        Me.btnDoubleJeopardy.Visible = False
        '
        'btnGo
        '
        Me.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGo.Font = New System.Drawing.Font("Wingdings", 7.8!)
        Me.btnGo.Location = New System.Drawing.Point(196, 43)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(32, 42)
        Me.btnGo.TabIndex = 30
        Me.btnGo.Text = ""
        Me.btnGo.UseVisualStyleBackColor = True
        Me.btnGo.Visible = False
        '
        'btnNo
        '
        Me.btnNo.BackgroundImage = Global.Jeopardy.My.Resources.Resources.RedCharacterCircle
        Me.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNo.Location = New System.Drawing.Point(152, 43)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(41, 42)
        Me.btnNo.TabIndex = 31
        Me.btnNo.Text = "N"
        Me.btnNo.UseVisualStyleBackColor = True
        Me.btnNo.Visible = False
        '
        'btnYes
        '
        Me.btnYes.BackgroundImage = Global.Jeopardy.My.Resources.Resources.GreenCharacterCircle
        Me.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnYes.Location = New System.Drawing.Point(108, 43)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(41, 42)
        Me.btnYes.TabIndex = 30
        Me.btnYes.Text = "Y"
        Me.btnYes.UseVisualStyleBackColor = True
        Me.btnYes.Visible = False
        '
        'lblConfidence
        '
        Me.lblConfidence.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblConfidence.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.lblConfidence.ForeColor = System.Drawing.Color.White
        Me.lblConfidence.Location = New System.Drawing.Point(1449, 69)
        Me.lblConfidence.Name = "lblConfidence"
        Me.lblConfidence.Size = New System.Drawing.Size(330, 51)
        Me.lblConfidence.TabIndex = 30
        Me.lblConfidence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblConfidence.UseMnemonic = False
        Me.lblConfidence.Visible = False
        '
        'txtRecognition
        '
        Me.txtRecognition.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtRecognition.Location = New System.Drawing.Point(1453, 23)
        Me.txtRecognition.Name = "txtRecognition"
        Me.txtRecognition.ReadOnly = True
        Me.txtRecognition.Size = New System.Drawing.Size(326, 43)
        Me.txtRecognition.TabIndex = 29
        Me.txtRecognition.Visible = False
        '
        'numPlayer1
        '
        Me.numPlayer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.numPlayer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPlayer1.ForeColor = System.Drawing.Color.Transparent
        Me.numPlayer1.Location = New System.Drawing.Point(519, 5)
        Me.numPlayer1.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numPlayer1.Minimum = New Decimal(New Integer() {50000, 0, 0, -2147483648})
        Me.numPlayer1.Name = "numPlayer1"
        Me.numPlayer1.Size = New System.Drawing.Size(299, 41)
        Me.numPlayer1.TabIndex = 15
        Me.numPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPlayer1.ThousandsSeparator = True
        Me.numPlayer1.Visible = False
        '
        'numPlayer2
        '
        Me.numPlayer2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.numPlayer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPlayer2.ForeColor = System.Drawing.Color.Transparent
        Me.numPlayer2.Location = New System.Drawing.Point(826, 5)
        Me.numPlayer2.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numPlayer2.Minimum = New Decimal(New Integer() {50000, 0, 0, -2147483648})
        Me.numPlayer2.Name = "numPlayer2"
        Me.numPlayer2.Size = New System.Drawing.Size(299, 41)
        Me.numPlayer2.TabIndex = 19
        Me.numPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPlayer2.ThousandsSeparator = True
        Me.numPlayer2.Visible = False
        '
        'notifyBar
        '
        Me.notifyBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.notifyBar.Font = New System.Drawing.Font("Segoe UI Light", 8.0!)
        Me.notifyBar.ForeColor = System.Drawing.Color.White
        Me.notifyBar.Location = New System.Drawing.Point(232, 33)
        Me.notifyBar.Name = "notifyBar"
        Me.notifyBar.Size = New System.Drawing.Size(281, 55)
        Me.notifyBar.TabIndex = 28
        Me.notifyBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.notifyBar.UseMnemonic = False
        '
        'lblPlayer2
        '
        Me.lblPlayer2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayer2.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer2.ForeColor = System.Drawing.Color.White
        Me.lblPlayer2.Location = New System.Drawing.Point(826, 52)
        Me.lblPlayer2.Name = "lblPlayer2"
        Me.lblPlayer2.Size = New System.Drawing.Size(278, 68)
        Me.lblPlayer2.TabIndex = 17
        Me.lblPlayer2.Text = "Player 2"
        Me.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer2.UseMnemonic = False
        '
        'btnFinalJeopardy
        '
        Me.btnFinalJeopardy.BackgroundImage = Global.Jeopardy.My.Resources.Resources.finalj_570x317
        Me.btnFinalJeopardy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFinalJeopardy.Location = New System.Drawing.Point(1801, 42)
        Me.btnFinalJeopardy.Name = "btnFinalJeopardy"
        Me.btnFinalJeopardy.Size = New System.Drawing.Size(75, 46)
        Me.btnFinalJeopardy.TabIndex = 26
        Me.btnFinalJeopardy.UseVisualStyleBackColor = True
        '
        'lblPlayer1
        '
        Me.lblPlayer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayer1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer1.ForeColor = System.Drawing.Color.White
        Me.lblPlayer1.Location = New System.Drawing.Point(524, 52)
        Me.lblPlayer1.Name = "lblPlayer1"
        Me.lblPlayer1.Size = New System.Drawing.Size(278, 68)
        Me.lblPlayer1.TabIndex = 10
        Me.lblPlayer1.Text = "Player 1"
        Me.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer1.UseMnemonic = False
        '
        'quitBTN
        '
        Me.quitBTN.BackgroundImage = Global.Jeopardy.My.Resources.Resources.Delete
        Me.quitBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.quitBTN.Location = New System.Drawing.Point(1882, 42)
        Me.quitBTN.Name = "quitBTN"
        Me.quitBTN.Size = New System.Drawing.Size(46, 46)
        Me.quitBTN.TabIndex = 27
        Me.quitBTN.UseVisualStyleBackColor = True
        '
        'txtCurrentPlayer
        '
        Me.txtCurrentPlayer.Location = New System.Drawing.Point(108, 54)
        Me.txtCurrentPlayer.Name = "txtCurrentPlayer"
        Me.txtCurrentPlayer.ReadOnly = True
        Me.txtCurrentPlayer.Size = New System.Drawing.Size(88, 22)
        Me.txtCurrentPlayer.TabIndex = 24
        Me.txtCurrentPlayer.Visible = False
        '
        'lblPlayer1Score
        '
        Me.lblPlayer1Score.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.lblPlayer1Score.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer1Score.ForeColor = System.Drawing.Color.White
        Me.lblPlayer1Score.Location = New System.Drawing.Point(522, 2)
        Me.lblPlayer1Score.Name = "lblPlayer1Score"
        Me.lblPlayer1Score.Size = New System.Drawing.Size(280, 47)
        Me.lblPlayer1Score.TabIndex = 11
        Me.lblPlayer1Score.Text = "0"
        Me.lblPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentValue
        '
        Me.lblCurrentValue.AutoSize = True
        Me.lblCurrentValue.Font = New System.Drawing.Font("Segoe UI Light", 10.0!)
        Me.lblCurrentValue.ForeColor = System.Drawing.Color.White
        Me.lblCurrentValue.Location = New System.Drawing.Point(20, 52)
        Me.lblCurrentValue.Name = "lblCurrentValue"
        Me.lblCurrentValue.Size = New System.Drawing.Size(82, 23)
        Me.lblCurrentValue.TabIndex = 25
        Me.lblCurrentValue.Text = "PointValue"
        '
        'numPlayer3
        '
        Me.numPlayer3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.numPlayer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPlayer3.ForeColor = System.Drawing.Color.Transparent
        Me.numPlayer3.Location = New System.Drawing.Point(1131, 5)
        Me.numPlayer3.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numPlayer3.Minimum = New Decimal(New Integer() {50000, 0, 0, -2147483648})
        Me.numPlayer3.Name = "numPlayer3"
        Me.numPlayer3.Size = New System.Drawing.Size(299, 41)
        Me.numPlayer3.TabIndex = 23
        Me.numPlayer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPlayer3.ThousandsSeparator = True
        Me.numPlayer3.Visible = False
        '
        'lblPlayer3Score
        '
        Me.lblPlayer3Score.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.lblPlayer3Score.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer3Score.ForeColor = System.Drawing.Color.White
        Me.lblPlayer3Score.Location = New System.Drawing.Point(1129, 2)
        Me.lblPlayer3Score.Name = "lblPlayer3Score"
        Me.lblPlayer3Score.Size = New System.Drawing.Size(280, 47)
        Me.lblPlayer3Score.TabIndex = 22
        Me.lblPlayer3Score.Text = "0"
        Me.lblPlayer3Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPlayer2Score
        '
        Me.lblPlayer2Score.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.lblPlayer2Score.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer2Score.ForeColor = System.Drawing.Color.White
        Me.lblPlayer2Score.Location = New System.Drawing.Point(824, 2)
        Me.lblPlayer2Score.Name = "lblPlayer2Score"
        Me.lblPlayer2Score.Size = New System.Drawing.Size(280, 47)
        Me.lblPlayer2Score.TabIndex = 18
        Me.lblPlayer2Score.Text = "0"
        Me.lblPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPlayer3
        '
        Me.lblPlayer3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPlayer3.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer3.ForeColor = System.Drawing.Color.White
        Me.lblPlayer3.Location = New System.Drawing.Point(1131, 52)
        Me.lblPlayer3.Name = "lblPlayer3"
        Me.lblPlayer3.Size = New System.Drawing.Size(278, 68)
        Me.lblPlayer3.TabIndex = 21
        Me.lblPlayer3.Text = "Player 3"
        Me.lblPlayer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer3.UseMnemonic = False
        '
        'txtWager3
        '
        Me.txtWager3.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtWager3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtWager3.ForeColor = System.Drawing.Color.White
        Me.txtWager3.Location = New System.Drawing.Point(1131, 131)
        Me.txtWager3.Name = "txtWager3"
        Me.txtWager3.Size = New System.Drawing.Size(283, 41)
        Me.txtWager3.TabIndex = 32
        Me.txtWager3.UseSystemPasswordChar = True
        Me.txtWager3.Visible = False
        '
        'txtWager2
        '
        Me.txtWager2.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtWager2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtWager2.ForeColor = System.Drawing.Color.White
        Me.txtWager2.Location = New System.Drawing.Point(826, 131)
        Me.txtWager2.Name = "txtWager2"
        Me.txtWager2.Size = New System.Drawing.Size(283, 41)
        Me.txtWager2.TabIndex = 31
        Me.txtWager2.UseSystemPasswordChar = True
        Me.txtWager2.Visible = False
        '
        'txtWager1
        '
        Me.txtWager1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtWager1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.txtWager1.ForeColor = System.Drawing.Color.White
        Me.txtWager1.Location = New System.Drawing.Point(522, 131)
        Me.txtWager1.Name = "txtWager1"
        Me.txtWager1.Size = New System.Drawing.Size(283, 41)
        Me.txtWager1.TabIndex = 30
        Me.txtWager1.UseSystemPasswordChar = True
        Me.txtWager1.Visible = False
        '
        'lblPlayerWagerMessage
        '
        Me.lblPlayerWagerMessage.AutoSize = True
        Me.lblPlayerWagerMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.lblPlayerWagerMessage.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPlayerWagerMessage.ForeColor = System.Drawing.Color.White
        Me.lblPlayerWagerMessage.Location = New System.Drawing.Point(684, 175)
        Me.lblPlayerWagerMessage.Name = "lblPlayerWagerMessage"
        Me.lblPlayerWagerMessage.Size = New System.Drawing.Size(528, 27)
        Me.lblPlayerWagerMessage.TabIndex = 34
        Me.lblPlayerWagerMessage.Text = "Please hit enter after you have typed in your wager."
        Me.lblPlayerWagerMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayerWagerMessage.UseMnemonic = False
        Me.lblPlayerWagerMessage.Visible = False
        '
        'frmScore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.lblPlayerWagerMessage)
        Me.Controls.Add(Me.txtWager3)
        Me.Controls.Add(Me.txtWager2)
        Me.Controls.Add(Me.txtWager1)
        Me.Controls.Add(Me.pnlScore)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScore"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Green
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlScore.ResumeLayout(False)
        Me.pnlScore.PerformLayout()
        CType(Me.numPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPlayer2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPlayer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPlayer1 As Label
    Friend WithEvents lblPlayer1Score As Label
    Friend WithEvents numPlayer1 As NumericUpDown
    Friend WithEvents numPlayer2 As NumericUpDown
    Friend WithEvents lblPlayer2Score As Label
    Friend WithEvents lblPlayer2 As Label
    Friend WithEvents numPlayer3 As NumericUpDown
    Friend WithEvents lblPlayer3Score As Label
    Friend WithEvents lblPlayer3 As Label
    Friend WithEvents txtCurrentPlayer As TextBox
    Friend WithEvents lblCurrentValue As Label
    Friend WithEvents tmrCurrentValue As Timer
    Friend WithEvents btnFinalJeopardy As Button
    Friend WithEvents quitBTN As Button
    Friend WithEvents notifyBar As Label
    Friend WithEvents pnlScore As Panel
    Friend WithEvents txtRecognition As TextBox
    Friend WithEvents lblConfidence As Label
    Friend WithEvents btnNo As Button
    Friend WithEvents btnYes As Button
    Friend WithEvents btnGo As Button
    Friend WithEvents btnDoubleJeopardy As Button
    Friend WithEvents txtWager3 As TextBox
    Friend WithEvents txtWager2 As TextBox
    Friend WithEvents txtWager1 As TextBox
    Friend WithEvents btnHelp As Button
    Friend WithEvents lblPlayerWagerMessage As Label
End Class
