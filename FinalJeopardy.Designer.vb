<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FinalJeopardy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FinalJeopardy))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.finalJeopardyPic = New System.Windows.Forms.PictureBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.CategoryTitle1 = New Jeopardy.CategoryTitleLarge()
        Me.ClueDisplayScreen1 = New Jeopardy.ClueDisplayScreen()
        CType(Me.finalJeopardyPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'finalJeopardyPic
        '
        Me.finalJeopardyPic.BackColor = System.Drawing.Color.Transparent
        Me.finalJeopardyPic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.finalJeopardyPic.Image = CType(resources.GetObject("finalJeopardyPic.Image"), System.Drawing.Image)
        Me.finalJeopardyPic.Location = New System.Drawing.Point(0, 0)
        Me.finalJeopardyPic.Name = "finalJeopardyPic"
        Me.finalJeopardyPic.Size = New System.Drawing.Size(1932, 1092)
        Me.finalJeopardyPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.finalJeopardyPic.TabIndex = 1
        Me.finalJeopardyPic.TabStop = False
        '
        'Timer2
        '
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(754, 289)
        Me.ProgressBar1.Maximum = 50
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(81, 31)
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Visible = False
        '
        'Timer3
        '
        '
        'CategoryTitle1
        '
        Me.CategoryTitle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.CategoryTitle1.category = "CATEGORY"
        Me.CategoryTitle1.display = True
        Me.CategoryTitle1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CategoryTitle1.Location = New System.Drawing.Point(0, 0)
        Me.CategoryTitle1.Name = "CategoryTitle1"
        Me.CategoryTitle1.Size = New System.Drawing.Size(1932, 1092)
        Me.CategoryTitle1.TabIndex = 3
        '
        'ClueDisplayScreen1
        '
        Me.ClueDisplayScreen1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ClueDisplayScreen1.clueDisplay = "CLUE"
        Me.ClueDisplayScreen1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClueDisplayScreen1.Location = New System.Drawing.Point(0, 0)
        Me.ClueDisplayScreen1.Name = "ClueDisplayScreen1"
        Me.ClueDisplayScreen1.Size = New System.Drawing.Size(1932, 1092)
        Me.ClueDisplayScreen1.TabIndex = 4
        '
        'FinalJeopardy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.BlankTile
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.finalJeopardyPic)
        Me.Controls.Add(Me.CategoryTitle1)
        Me.Controls.Add(Me.ClueDisplayScreen1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FinalJeopardy"
        Me.Text = "Final Jeopardy"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.finalJeopardyPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents finalJeopardyPic As PictureBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer3 As Timer
    Friend WithEvents CategoryTitle1 As CategoryTitleLarge
    Friend WithEvents ClueDisplayScreen1 As ClueDisplayScreen
End Class
