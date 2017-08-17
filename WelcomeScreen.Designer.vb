<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeScreen))
        Me.playBTN = New System.Windows.Forms.PictureBox()
        Me.settingsBTN = New System.Windows.Forms.PictureBox()
        Me.screenBypassBTN = New System.Windows.Forms.PictureBox()
        Me.customizeBTN = New System.Windows.Forms.PictureBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        CType(Me.playBTN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.settingsBTN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.screenBypassBTN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.customizeBTN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'playBTN
        '
        Me.playBTN.BackColor = System.Drawing.Color.Transparent
        Me.playBTN.Location = New System.Drawing.Point(447, 895)
        Me.playBTN.Name = "playBTN"
        Me.playBTN.Size = New System.Drawing.Size(184, 107)
        Me.playBTN.TabIndex = 1
        Me.playBTN.TabStop = False
        '
        'settingsBTN
        '
        Me.settingsBTN.BackColor = System.Drawing.Color.Transparent
        Me.settingsBTN.Location = New System.Drawing.Point(1182, 895)
        Me.settingsBTN.Name = "settingsBTN"
        Me.settingsBTN.Size = New System.Drawing.Size(300, 107)
        Me.settingsBTN.TabIndex = 2
        Me.settingsBTN.TabStop = False
        '
        'screenBypassBTN
        '
        Me.screenBypassBTN.BackColor = System.Drawing.Color.Transparent
        Me.screenBypassBTN.Image = Global.Jeopardy.My.Resources.Resources.JeopardyQuiz
        Me.screenBypassBTN.Location = New System.Drawing.Point(30, 1005)
        Me.screenBypassBTN.Name = "screenBypassBTN"
        Me.screenBypassBTN.Size = New System.Drawing.Size(52, 48)
        Me.screenBypassBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.screenBypassBTN.TabIndex = 3
        Me.screenBypassBTN.TabStop = False
        Me.screenBypassBTN.Visible = False
        '
        'customizeBTN
        '
        Me.customizeBTN.BackColor = System.Drawing.Color.Transparent
        Me.customizeBTN.Location = New System.Drawing.Point(741, 895)
        Me.customizeBTN.Name = "customizeBTN"
        Me.customizeBTN.Size = New System.Drawing.Size(378, 107)
        Me.customizeBTN.TabIndex = 4
        Me.customizeBTN.TabStop = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(101, 1005)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(100, 48)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(207, 1005)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(100, 48)
        Me.RichTextBox2.TabIndex = 6
        Me.RichTextBox2.Text = ""
        Me.RichTextBox2.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("Open Sans", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(901, 1004)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(155, 49)
        Me.btnHelp.TabIndex = 7
        Me.btnHelp.Text = "HELP"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'WelcomeScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardyTitle33HD
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.customizeBTN)
        Me.Controls.Add(Me.screenBypassBTN)
        Me.Controls.Add(Me.settingsBTN)
        Me.Controls.Add(Me.playBTN)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WelcomeScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.playBTN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.settingsBTN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.screenBypassBTN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.customizeBTN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents playBTN As PictureBox
    Friend WithEvents settingsBTN As PictureBox
    Friend WithEvents screenBypassBTN As PictureBox
    Friend WithEvents customizeBTN As PictureBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents btnHelp As Button
End Class
