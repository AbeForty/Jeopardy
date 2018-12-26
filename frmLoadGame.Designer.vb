<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoadGame
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoadGame))
        Me.pnlLoadGame = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.btnResumeGame = New System.Windows.Forms.Button()
        Me.lblSelectPack = New System.Windows.Forms.Label()
        Me.cboGame = New System.Windows.Forms.ComboBox()
        Me.lblLoadGame = New System.Windows.Forms.Label()
        Me.pnlLoadGame.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLoadGame
        '
        Me.pnlLoadGame.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.pnlLoadGame.BackgroundImage = Global.Jeopardy.My.Resources.Resources.BlueOverlay
        Me.pnlLoadGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlLoadGame.Controls.Add(Me.btnClose)
        Me.pnlLoadGame.Controls.Add(Me.btnResumeGame)
        Me.pnlLoadGame.Controls.Add(Me.lblSelectPack)
        Me.pnlLoadGame.Controls.Add(Me.cboGame)
        Me.pnlLoadGame.Controls.Add(Me.lblLoadGame)
        Me.pnlLoadGame.Location = New System.Drawing.Point(241, 104)
        Me.pnlLoadGame.Name = "pnlLoadGame"
        Me.pnlLoadGame.Size = New System.Drawing.Size(1405, 808)
        Me.pnlLoadGame.TabIndex = 0
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
        'btnResumeGame
        '
        Me.btnResumeGame.BackColor = System.Drawing.Color.Transparent
        Me.btnResumeGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResumeGame.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.btnResumeGame.ForeColor = System.Drawing.Color.Transparent
        Me.btnResumeGame.Location = New System.Drawing.Point(485, 461)
        Me.btnResumeGame.Name = "btnResumeGame"
        Me.btnResumeGame.Size = New System.Drawing.Size(396, 67)
        Me.btnResumeGame.TabIndex = 18
        Me.btnResumeGame.Text = "RESUME"
        Me.btnResumeGame.UseVisualStyleBackColor = False
        '
        'lblSelectPack
        '
        Me.lblSelectPack.AutoSize = True
        Me.lblSelectPack.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectPack.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblSelectPack.ForeColor = System.Drawing.Color.White
        Me.lblSelectPack.Location = New System.Drawing.Point(510, 342)
        Me.lblSelectPack.Name = "lblSelectPack"
        Me.lblSelectPack.Size = New System.Drawing.Size(344, 30)
        Me.lblSelectPack.TabIndex = 17
        Me.lblSelectPack.Text = "SELECT A GAME TO RESUME"
        Me.lblSelectPack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboGame
        '
        Me.cboGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGame.Font = New System.Drawing.Font("Korinna BT", 19.8!, System.Drawing.FontStyle.Bold)
        Me.cboGame.FormattingEnabled = True
        Me.cboGame.Location = New System.Drawing.Point(55, 394)
        Me.cboGame.Name = "cboGame"
        Me.cboGame.Size = New System.Drawing.Size(1302, 48)
        Me.cboGame.TabIndex = 16
        '
        'lblLoadGame
        '
        Me.lblLoadGame.AutoSize = True
        Me.lblLoadGame.BackColor = System.Drawing.Color.Transparent
        Me.lblLoadGame.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblLoadGame.ForeColor = System.Drawing.Color.White
        Me.lblLoadGame.Location = New System.Drawing.Point(20, 27)
        Me.lblLoadGame.Name = "lblLoadGame"
        Me.lblLoadGame.Size = New System.Drawing.Size(153, 30)
        Me.lblLoadGame.TabIndex = 9
        Me.lblLoadGame.Text = "LOAD GAME"
        '
        'frmLoadGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardyBoardBlur
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.pnlLoadGame)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoadGame"
        Me.Text = "New Game"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlLoadGame.ResumeLayout(False)
        Me.pnlLoadGame.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlLoadGame As Panel
    Friend WithEvents lblSelectPack As Label
    Friend WithEvents cboGame As ComboBox
    Friend WithEvents lblLoadGame As Label
    Friend WithEvents btnResumeGame As Button
    Friend WithEvents btnClose As PictureBox
End Class

