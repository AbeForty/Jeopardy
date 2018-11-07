<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewGame))
        Me.pnlNewGame = New System.Windows.Forms.Panel()
        Me.lblQuickGame = New System.Windows.Forms.Label()
        Me.lblSavedGame = New System.Windows.Forms.Label()
        Me.TeamDisplay3 = New Jeopardy.TeamDisplay()
        Me.TeamDisplay2 = New Jeopardy.TeamDisplay()
        Me.TeamDisplay1 = New Jeopardy.TeamDisplay()
        Me.lblLoadGame = New System.Windows.Forms.LinkLabel()
        Me.chkVoiceRecognition = New System.Windows.Forms.CheckBox()
        Me.chkVirtualHost = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.btnSaveGame = New System.Windows.Forms.Button()
        Me.lblSelectPack = New System.Windows.Forms.Label()
        Me.cboPack = New System.Windows.Forms.ComboBox()
        Me.btnQuickStart = New System.Windows.Forms.Button()
        Me.txtPlayer3 = New System.Windows.Forms.TextBox()
        Me.txtPlayer2 = New System.Windows.Forms.TextBox()
        Me.txtPlayer1 = New System.Windows.Forms.TextBox()
        Me.lblNewGame = New System.Windows.Forms.Label()
        Me.pnlNewGame.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlNewGame
        '
        Me.pnlNewGame.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pnlNewGame.BackgroundImage = Global.Jeopardy.My.Resources.Resources.BlueOverlay
        Me.pnlNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlNewGame.Controls.Add(Me.lblQuickGame)
        Me.pnlNewGame.Controls.Add(Me.lblSavedGame)
        Me.pnlNewGame.Controls.Add(Me.TeamDisplay3)
        Me.pnlNewGame.Controls.Add(Me.TeamDisplay2)
        Me.pnlNewGame.Controls.Add(Me.TeamDisplay1)
        Me.pnlNewGame.Controls.Add(Me.lblLoadGame)
        Me.pnlNewGame.Controls.Add(Me.chkVoiceRecognition)
        Me.pnlNewGame.Controls.Add(Me.chkVirtualHost)
        Me.pnlNewGame.Controls.Add(Me.btnClose)
        Me.pnlNewGame.Controls.Add(Me.btnSaveGame)
        Me.pnlNewGame.Controls.Add(Me.lblSelectPack)
        Me.pnlNewGame.Controls.Add(Me.cboPack)
        Me.pnlNewGame.Controls.Add(Me.btnQuickStart)
        Me.pnlNewGame.Controls.Add(Me.txtPlayer3)
        Me.pnlNewGame.Controls.Add(Me.txtPlayer2)
        Me.pnlNewGame.Controls.Add(Me.txtPlayer1)
        Me.pnlNewGame.Controls.Add(Me.lblNewGame)
        Me.pnlNewGame.Location = New System.Drawing.Point(241, 64)
        Me.pnlNewGame.Name = "pnlNewGame"
        Me.pnlNewGame.Size = New System.Drawing.Size(1405, 907)
        Me.pnlNewGame.TabIndex = 0
        '
        'lblQuickGame
        '
        Me.lblQuickGame.AutoSize = True
        Me.lblQuickGame.BackColor = System.Drawing.Color.Transparent
        Me.lblQuickGame.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblQuickGame.ForeColor = System.Drawing.Color.White
        Me.lblQuickGame.Location = New System.Drawing.Point(296, 650)
        Me.lblQuickGame.Name = "lblQuickGame"
        Me.lblQuickGame.Size = New System.Drawing.Size(806, 30)
        Me.lblQuickGame.TabIndex = 27
        Me.lblQuickGame.Text = "OR PLAY A QUICK GAME BY ENTERING CONTESTANT NAMES BELOW"
        Me.lblQuickGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSavedGame
        '
        Me.lblSavedGame.AutoSize = True
        Me.lblSavedGame.BackColor = System.Drawing.Color.Transparent
        Me.lblSavedGame.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblSavedGame.ForeColor = System.Drawing.Color.White
        Me.lblSavedGame.Location = New System.Drawing.Point(449, 186)
        Me.lblSavedGame.Name = "lblSavedGame"
        Me.lblSavedGame.Size = New System.Drawing.Size(502, 30)
        Me.lblSavedGame.TabIndex = 26
        Me.lblSavedGame.Text = "PLAY A GAME WITH SAVED CONTESTANTS"
        Me.lblSavedGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TeamDisplay3
        '
        Me.TeamDisplay3.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TeamDisplay3.BackgroundImage = CType(resources.GetObject("TeamDisplay3.BackgroundImage"), System.Drawing.Image)
        Me.TeamDisplay3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TeamDisplay3.enableClick = True
        Me.TeamDisplay3.Location = New System.Drawing.Point(939, 231)
        Me.TeamDisplay3.Name = "TeamDisplay3"
        Me.TeamDisplay3.playerNumber = 3
        Me.TeamDisplay3.Size = New System.Drawing.Size(444, 407)
        Me.TeamDisplay3.TabIndex = 25
        '
        'TeamDisplay2
        '
        Me.TeamDisplay2.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TeamDisplay2.BackgroundImage = CType(resources.GetObject("TeamDisplay2.BackgroundImage"), System.Drawing.Image)
        Me.TeamDisplay2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TeamDisplay2.enableClick = True
        Me.TeamDisplay2.Location = New System.Drawing.Point(487, 231)
        Me.TeamDisplay2.Name = "TeamDisplay2"
        Me.TeamDisplay2.playerNumber = 2
        Me.TeamDisplay2.Size = New System.Drawing.Size(444, 407)
        Me.TeamDisplay2.TabIndex = 24
        '
        'TeamDisplay1
        '
        Me.TeamDisplay1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.TeamDisplay1.BackgroundImage = CType(resources.GetObject("TeamDisplay1.BackgroundImage"), System.Drawing.Image)
        Me.TeamDisplay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TeamDisplay1.enableClick = True
        Me.TeamDisplay1.Location = New System.Drawing.Point(34, 231)
        Me.TeamDisplay1.Name = "TeamDisplay1"
        Me.TeamDisplay1.playerNumber = 1
        Me.TeamDisplay1.Size = New System.Drawing.Size(444, 407)
        Me.TeamDisplay1.TabIndex = 23
        '
        'lblLoadGame
        '
        Me.lblLoadGame.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.lblLoadGame.AutoSize = True
        Me.lblLoadGame.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblLoadGame.LinkColor = System.Drawing.Color.White
        Me.lblLoadGame.Location = New System.Drawing.Point(1183, 23)
        Me.lblLoadGame.Name = "lblLoadGame"
        Me.lblLoadGame.Size = New System.Drawing.Size(153, 30)
        Me.lblLoadGame.TabIndex = 22
        Me.lblLoadGame.TabStop = True
        Me.lblLoadGame.Text = "LOAD GAME"
        Me.lblLoadGame.VisitedLinkColor = System.Drawing.Color.White
        '
        'chkVoiceRecognition
        '
        Me.chkVoiceRecognition.AutoSize = True
        Me.chkVoiceRecognition.Enabled = False
        Me.chkVoiceRecognition.Font = New System.Drawing.Font("Korinna BT", 12.0!)
        Me.chkVoiceRecognition.ForeColor = System.Drawing.Color.White
        Me.chkVoiceRecognition.Location = New System.Drawing.Point(612, 772)
        Me.chkVoiceRecognition.Name = "chkVoiceRecognition"
        Me.chkVoiceRecognition.Size = New System.Drawing.Size(372, 28)
        Me.chkVoiceRecognition.TabIndex = 21
        Me.chkVoiceRecognition.Text = "ENABLE VOICE RECOGNITION (BETA)"
        Me.chkVoiceRecognition.UseVisualStyleBackColor = True
        '
        'chkVirtualHost
        '
        Me.chkVirtualHost.AutoSize = True
        Me.chkVirtualHost.Enabled = False
        Me.chkVirtualHost.Font = New System.Drawing.Font("Korinna BT", 12.0!)
        Me.chkVirtualHost.ForeColor = System.Drawing.Color.White
        Me.chkVirtualHost.Location = New System.Drawing.Point(341, 772)
        Me.chkVirtualHost.Name = "chkVirtualHost"
        Me.chkVirtualHost.Size = New System.Drawing.Size(247, 28)
        Me.chkVirtualHost.TabIndex = 20
        Me.chkVirtualHost.Text = "ENABLE VIRTUAL HOST"
        Me.chkVirtualHost.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Image = Global.Jeopardy.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(1351, 20)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 34)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 19
        Me.btnClose.TabStop = False
        '
        'btnSaveGame
        '
        Me.btnSaveGame.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveGame.Enabled = False
        Me.btnSaveGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveGame.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.btnSaveGame.ForeColor = System.Drawing.Color.Transparent
        Me.btnSaveGame.Location = New System.Drawing.Point(316, 817)
        Me.btnSaveGame.Name = "btnSaveGame"
        Me.btnSaveGame.Size = New System.Drawing.Size(396, 67)
        Me.btnSaveGame.TabIndex = 18
        Me.btnSaveGame.Text = "START SAVED GAME"
        Me.btnSaveGame.UseVisualStyleBackColor = False
        '
        'lblSelectPack
        '
        Me.lblSelectPack.AutoSize = True
        Me.lblSelectPack.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectPack.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblSelectPack.ForeColor = System.Drawing.Color.White
        Me.lblSelectPack.Location = New System.Drawing.Point(607, 74)
        Me.lblSelectPack.Name = "lblSelectPack"
        Me.lblSelectPack.Size = New System.Drawing.Size(173, 30)
        Me.lblSelectPack.TabIndex = 17
        Me.lblSelectPack.Text = "SELECT PACK"
        Me.lblSelectPack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPack
        '
        Me.cboPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPack.Font = New System.Drawing.Font("Korinna BT", 19.8!, System.Drawing.FontStyle.Bold)
        Me.cboPack.FormattingEnabled = True
        Me.cboPack.Location = New System.Drawing.Point(34, 119)
        Me.cboPack.Name = "cboPack"
        Me.cboPack.Size = New System.Drawing.Size(1348, 48)
        Me.cboPack.TabIndex = 16
        '
        'btnQuickStart
        '
        Me.btnQuickStart.BackColor = System.Drawing.Color.Transparent
        Me.btnQuickStart.Enabled = False
        Me.btnQuickStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuickStart.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.btnQuickStart.ForeColor = System.Drawing.Color.Transparent
        Me.btnQuickStart.Location = New System.Drawing.Point(739, 817)
        Me.btnQuickStart.Name = "btnQuickStart"
        Me.btnQuickStart.Size = New System.Drawing.Size(275, 67)
        Me.btnQuickStart.TabIndex = 15
        Me.btnQuickStart.Text = "QUICK START"
        Me.btnQuickStart.UseVisualStyleBackColor = False
        '
        'txtPlayer3
        '
        Me.txtPlayer3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlayer3.Font = New System.Drawing.Font("Korinna BT", 23.0!)
        Me.txtPlayer3.ForeColor = System.Drawing.Color.Black
        Me.txtPlayer3.Location = New System.Drawing.Point(938, 692)
        Me.txtPlayer3.Name = "txtPlayer3"
        Me.txtPlayer3.Size = New System.Drawing.Size(444, 53)
        Me.txtPlayer3.TabIndex = 14
        Me.txtPlayer3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPlayer2
        '
        Me.txtPlayer2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlayer2.Font = New System.Drawing.Font("Korinna BT", 23.0!)
        Me.txtPlayer2.ForeColor = System.Drawing.Color.Black
        Me.txtPlayer2.Location = New System.Drawing.Point(485, 692)
        Me.txtPlayer2.Name = "txtPlayer2"
        Me.txtPlayer2.Size = New System.Drawing.Size(444, 53)
        Me.txtPlayer2.TabIndex = 13
        Me.txtPlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPlayer1
        '
        Me.txtPlayer1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlayer1.Font = New System.Drawing.Font("Korinna BT", 23.0!)
        Me.txtPlayer1.ForeColor = System.Drawing.Color.Black
        Me.txtPlayer1.Location = New System.Drawing.Point(33, 692)
        Me.txtPlayer1.Name = "txtPlayer1"
        Me.txtPlayer1.Size = New System.Drawing.Size(443, 53)
        Me.txtPlayer1.TabIndex = 11
        Me.txtPlayer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNewGame
        '
        Me.lblNewGame.AutoSize = True
        Me.lblNewGame.BackColor = System.Drawing.Color.Transparent
        Me.lblNewGame.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblNewGame.ForeColor = System.Drawing.Color.White
        Me.lblNewGame.Location = New System.Drawing.Point(20, 27)
        Me.lblNewGame.Name = "lblNewGame"
        Me.lblNewGame.Size = New System.Drawing.Size(142, 30)
        Me.lblNewGame.TabIndex = 9
        Me.lblNewGame.Text = "NEW GAME"
        '
        'frmNewGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardyBoardBlur
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.pnlNewGame)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewGame"
        Me.Text = "New Game"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlNewGame.ResumeLayout(False)
        Me.pnlNewGame.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlNewGame As Panel
    Friend WithEvents txtPlayer1 As TextBox
    Friend WithEvents txtPlayer3 As TextBox
    Friend WithEvents txtPlayer2 As TextBox
    Friend WithEvents btnQuickStart As Button
    Friend WithEvents lblSelectPack As Label
    Friend WithEvents cboPack As ComboBox
    Friend WithEvents btnSaveGame As Button
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents chkVoiceRecognition As CheckBox
    Friend WithEvents chkVirtualHost As CheckBox
    Friend WithEvents lblLoadGame As LinkLabel
    Friend WithEvents lblNewGame As Label
    Friend WithEvents TeamDisplay3 As TeamDisplay
    Friend WithEvents TeamDisplay2 As TeamDisplay
    Friend WithEvents TeamDisplay1 As TeamDisplay
    Friend WithEvents lblQuickGame As Label
    Friend WithEvents lblSavedGame As Label
End Class
