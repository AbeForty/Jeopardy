<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PodiumScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PodiumScreen))
        Me.Player1ScoreLbl = New System.Windows.Forms.Label()
        Me.Player2ScoreLbl = New System.Windows.Forms.Label()
        Me.Player3ScoreLbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Player1ScoreLbl
        '
        Me.Player1ScoreLbl.AutoSize = True
        Me.Player1ScoreLbl.BackColor = System.Drawing.Color.Transparent
        Me.Player1ScoreLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!)
        Me.Player1ScoreLbl.ForeColor = System.Drawing.Color.White
        Me.Player1ScoreLbl.Location = New System.Drawing.Point(430, 618)
        Me.Player1ScoreLbl.Name = "Player1ScoreLbl"
        Me.Player1ScoreLbl.Size = New System.Drawing.Size(64, 46)
        Me.Player1ScoreLbl.TabIndex = 0
        Me.Player1ScoreLbl.Text = "$0"
        '
        'Player2ScoreLbl
        '
        Me.Player2ScoreLbl.AutoSize = True
        Me.Player2ScoreLbl.BackColor = System.Drawing.Color.Transparent
        Me.Player2ScoreLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!)
        Me.Player2ScoreLbl.ForeColor = System.Drawing.Color.White
        Me.Player2ScoreLbl.Location = New System.Drawing.Point(885, 613)
        Me.Player2ScoreLbl.Name = "Player2ScoreLbl"
        Me.Player2ScoreLbl.Size = New System.Drawing.Size(64, 46)
        Me.Player2ScoreLbl.TabIndex = 1
        Me.Player2ScoreLbl.Text = "$0"
        '
        'Player3ScoreLbl
        '
        Me.Player3ScoreLbl.AutoSize = True
        Me.Player3ScoreLbl.BackColor = System.Drawing.Color.Transparent
        Me.Player3ScoreLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!)
        Me.Player3ScoreLbl.ForeColor = System.Drawing.Color.White
        Me.Player3ScoreLbl.Location = New System.Drawing.Point(1342, 610)
        Me.Player3ScoreLbl.Name = "Player3ScoreLbl"
        Me.Player3ScoreLbl.Size = New System.Drawing.Size(64, 46)
        Me.Player3ScoreLbl.TabIndex = 2
        Me.Player3ScoreLbl.Text = "$0"
        '
        'PodiumScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.Podium
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.Player3ScoreLbl)
        Me.Controls.Add(Me.Player2ScoreLbl)
        Me.Controls.Add(Me.Player1ScoreLbl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PodiumScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Player1ScoreLbl As Label
    Friend WithEvents Player2ScoreLbl As Label
    Friend WithEvents Player3ScoreLbl As Label
End Class
