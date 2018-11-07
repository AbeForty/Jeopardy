<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContestantManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContestantManager))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.lblSelectContestant = New System.Windows.Forms.Label()
        Me.lblNoGames = New System.Windows.Forms.Label()
        Me.lblNewContestant = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.splNewGame = New System.Windows.Forms.SplitContainer()
        Me.flpContestants = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlStats = New System.Windows.Forms.Panel()
        Me.pnlTblHeader = New System.Windows.Forms.Panel()
        Me.lblWinnings = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblPackName = New System.Windows.Forms.Label()
        Me.flpStatistics = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblStats = New System.Windows.Forms.Label()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.pnlSettings.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splNewGame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splNewGame.Panel1.SuspendLayout()
        Me.splNewGame.Panel2.SuspendLayout()
        Me.splNewGame.SuspendLayout()
        Me.pnlStats.SuspendLayout()
        Me.pnlTblHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pnlSettings.Controls.Add(Me.lblSelectContestant)
        Me.pnlSettings.Controls.Add(Me.lblNoGames)
        Me.pnlSettings.Controls.Add(Me.lblNewContestant)
        Me.pnlSettings.Controls.Add(Me.btnClose)
        Me.pnlSettings.Controls.Add(Me.splNewGame)
        Me.pnlSettings.Controls.Add(Me.lblSettings)
        Me.pnlSettings.Location = New System.Drawing.Point(181, 121)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(1538, 884)
        Me.pnlSettings.TabIndex = 1
        '
        'lblSelectContestant
        '
        Me.lblSelectContestant.AutoSize = True
        Me.lblSelectContestant.Font = New System.Drawing.Font("Korinna BT", 13.0!)
        Me.lblSelectContestant.ForeColor = System.Drawing.Color.White
        Me.lblSelectContestant.Location = New System.Drawing.Point(588, 220)
        Me.lblSelectContestant.Name = "lblSelectContestant"
        Me.lblSelectContestant.Size = New System.Drawing.Size(428, 26)
        Me.lblSelectContestant.TabIndex = 22
        Me.lblSelectContestant.Text = "SELECT A CONTESTANT FROM THE LEFT"
        '
        'lblNoGames
        '
        Me.lblNoGames.AutoSize = True
        Me.lblNoGames.Font = New System.Drawing.Font("Korinna BT", 13.0!)
        Me.lblNoGames.ForeColor = System.Drawing.Color.White
        Me.lblNoGames.Location = New System.Drawing.Point(588, 245)
        Me.lblNoGames.Name = "lblNoGames"
        Me.lblNoGames.Size = New System.Drawing.Size(334, 26)
        Me.lblNoGames.TabIndex = 21
        Me.lblNoGames.Text = "NO GAMES HAVE BEEN PLAYED."
        Me.lblNoGames.Visible = False
        '
        'lblNewContestant
        '
        Me.lblNewContestant.AutoSize = True
        Me.lblNewContestant.Font = New System.Drawing.Font("Korinna BT", 13.0!)
        Me.lblNewContestant.ForeColor = System.Drawing.Color.White
        Me.lblNewContestant.Location = New System.Drawing.Point(22, 74)
        Me.lblNewContestant.Name = "lblNewContestant"
        Me.lblNewContestant.Size = New System.Drawing.Size(229, 26)
        Me.lblNewContestant.TabIndex = 19
        Me.lblNewContestant.Text = "+ NEW CONTESTANT"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.Jeopardy.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(1484, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 32)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 16
        Me.btnClose.TabStop = False
        '
        'splNewGame
        '
        Me.splNewGame.Location = New System.Drawing.Point(19, 102)
        Me.splNewGame.Name = "splNewGame"
        '
        'splNewGame.Panel1
        '
        Me.splNewGame.Panel1.Controls.Add(Me.flpContestants)
        '
        'splNewGame.Panel2
        '
        Me.splNewGame.Panel2.Controls.Add(Me.pnlStats)
        Me.splNewGame.Size = New System.Drawing.Size(1465, 732)
        Me.splNewGame.SplitterDistance = 433
        Me.splNewGame.TabIndex = 15
        '
        'flpContestants
        '
        Me.flpContestants.AutoScroll = True
        Me.flpContestants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpContestants.Location = New System.Drawing.Point(0, 0)
        Me.flpContestants.Name = "flpContestants"
        Me.flpContestants.Size = New System.Drawing.Size(433, 732)
        Me.flpContestants.TabIndex = 0
        '
        'pnlStats
        '
        Me.pnlStats.Controls.Add(Me.pnlTblHeader)
        Me.pnlStats.Controls.Add(Me.flpStatistics)
        Me.pnlStats.Controls.Add(Me.lblStats)
        Me.pnlStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlStats.Location = New System.Drawing.Point(0, 0)
        Me.pnlStats.Name = "pnlStats"
        Me.pnlStats.Size = New System.Drawing.Size(1028, 732)
        Me.pnlStats.TabIndex = 17
        '
        'pnlTblHeader
        '
        Me.pnlTblHeader.Controls.Add(Me.lblWinnings)
        Me.pnlTblHeader.Controls.Add(Me.lblDate)
        Me.pnlTblHeader.Controls.Add(Me.lblPackName)
        Me.pnlTblHeader.Location = New System.Drawing.Point(14, 63)
        Me.pnlTblHeader.Name = "pnlTblHeader"
        Me.pnlTblHeader.Size = New System.Drawing.Size(1007, 41)
        Me.pnlTblHeader.TabIndex = 23
        '
        'lblWinnings
        '
        Me.lblWinnings.AutoSize = True
        Me.lblWinnings.Font = New System.Drawing.Font("Korinna BT", 13.0!)
        Me.lblWinnings.ForeColor = System.Drawing.Color.White
        Me.lblWinnings.Location = New System.Drawing.Point(731, 6)
        Me.lblWinnings.Name = "lblWinnings"
        Me.lblWinnings.Size = New System.Drawing.Size(117, 26)
        Me.lblWinnings.TabIndex = 20
        Me.lblWinnings.Text = "WINNINGS"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Korinna BT", 13.0!)
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Location = New System.Drawing.Point(442, 6)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(67, 26)
        Me.lblDate.TabIndex = 19
        Me.lblDate.Text = "DATE"
        '
        'lblPackName
        '
        Me.lblPackName.AutoSize = True
        Me.lblPackName.Font = New System.Drawing.Font("Korinna BT", 13.0!)
        Me.lblPackName.ForeColor = System.Drawing.Color.White
        Me.lblPackName.Location = New System.Drawing.Point(3, 6)
        Me.lblPackName.Name = "lblPackName"
        Me.lblPackName.Size = New System.Drawing.Size(131, 26)
        Me.lblPackName.TabIndex = 18
        Me.lblPackName.Text = "PACK NAME"
        '
        'flpStatistics
        '
        Me.flpStatistics.AutoScroll = True
        Me.flpStatistics.Location = New System.Drawing.Point(14, 114)
        Me.flpStatistics.Name = "flpStatistics"
        Me.flpStatistics.Size = New System.Drawing.Size(1007, 624)
        Me.flpStatistics.TabIndex = 22
        '
        'lblStats
        '
        Me.lblStats.AutoSize = True
        Me.lblStats.Font = New System.Drawing.Font("Korinna BT", 16.0!)
        Me.lblStats.ForeColor = System.Drawing.Color.White
        Me.lblStats.Location = New System.Drawing.Point(16, 22)
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(159, 32)
        Me.lblStats.TabIndex = 17
        Me.lblStats.Text = "STATISTICS"
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Font = New System.Drawing.Font("Korinna BT", 16.0!)
        Me.lblSettings.ForeColor = System.Drawing.Color.White
        Me.lblSettings.Location = New System.Drawing.Point(21, 27)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(204, 32)
        Me.lblSettings.TabIndex = 6
        Me.lblSettings.Text = "CONTESTANTS"
        '
        'frmContestantManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardyBoardBlur
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.pnlSettings)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmContestantManager"
        Me.Text = "Wheel of Fortune"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splNewGame.Panel1.ResumeLayout(False)
        Me.splNewGame.Panel2.ResumeLayout(False)
        CType(Me.splNewGame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splNewGame.ResumeLayout(False)
        Me.pnlStats.ResumeLayout(False)
        Me.pnlStats.PerformLayout()
        Me.pnlTblHeader.ResumeLayout(False)
        Me.pnlTblHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents lblSettings As Label
    Friend WithEvents splNewGame As SplitContainer
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents flpContestants As FlowLayoutPanel
    Friend WithEvents lblStats As Label
    Friend WithEvents flpStatistics As FlowLayoutPanel
    Friend WithEvents lblNoGames As Label
    Friend WithEvents pnlStats As Panel
    Friend WithEvents pnlTblHeader As Panel
    Friend WithEvents lblWinnings As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblPackName As Label
    Friend WithEvents lblNewContestant As Label
    Friend WithEvents lblSelectContestant As Label
End Class
