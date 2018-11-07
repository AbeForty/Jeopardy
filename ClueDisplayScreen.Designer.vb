<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClueDisplayScreen
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClueDisplayScreen))
        Me.lblClue = New System.Windows.Forms.Label()
        Me.wmpClue = New AxWMPLib.AxWindowsMediaPlayer()
        Me.MiniClue1 = New Jeopardy.MiniClue()
        Me.pboxClue = New System.Windows.Forms.PictureBox()
        Me.clueBrowser = New System.Windows.Forms.WebBrowser()
        CType(Me.wmpClue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxClue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblClue
        '
        Me.lblClue.AutoEllipsis = True
        Me.lblClue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClue.Font = New System.Drawing.Font("Korinna", 40.0!)
        Me.lblClue.ForeColor = System.Drawing.Color.Transparent
        Me.lblClue.Location = New System.Drawing.Point(0, 0)
        Me.lblClue.Name = "lblClue"
        Me.lblClue.Size = New System.Drawing.Size(1932, 1092)
        Me.lblClue.TabIndex = 20
        Me.lblClue.Text = "CLUE"
        Me.lblClue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblClue.UseMnemonic = False
        '
        'wmpClue
        '
        Me.wmpClue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wmpClue.Enabled = True
        Me.wmpClue.Location = New System.Drawing.Point(0, 0)
        Me.wmpClue.Name = "wmpClue"
        Me.wmpClue.OcxState = CType(resources.GetObject("wmpClue.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpClue.Size = New System.Drawing.Size(1932, 1092)
        Me.wmpClue.TabIndex = 21
        Me.wmpClue.Visible = False
        '
        'MiniClue1
        '
        Me.MiniClue1.BackColor = System.Drawing.Color.Black
        Me.MiniClue1.BackgroundImage = Global.Jeopardy.My.Resources.Resources.PictureVideoClueStrip
        Me.MiniClue1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MiniClue1.Location = New System.Drawing.Point(0, 534)
        Me.MiniClue1.Name = "MiniClue1"
        Me.MiniClue1.Size = New System.Drawing.Size(2050, 354)
        Me.MiniClue1.TabIndex = 23
        Me.MiniClue1.Visible = False
        '
        'pboxClue
        '
        Me.pboxClue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pboxClue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pboxClue.Location = New System.Drawing.Point(0, 0)
        Me.pboxClue.Name = "pboxClue"
        Me.pboxClue.Size = New System.Drawing.Size(1932, 1092)
        Me.pboxClue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxClue.TabIndex = 22
        Me.pboxClue.TabStop = False
        Me.pboxClue.Visible = False
        '
        'clueBrowser
        '
        Me.clueBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clueBrowser.IsWebBrowserContextMenuEnabled = False
        Me.clueBrowser.Location = New System.Drawing.Point(0, 0)
        Me.clueBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.clueBrowser.Name = "clueBrowser"
        Me.clueBrowser.Size = New System.Drawing.Size(1932, 1092)
        Me.clueBrowser.TabIndex = 24
        Me.clueBrowser.Url = New System.Uri("", System.UriKind.Relative)
        Me.clueBrowser.WebBrowserShortcutsEnabled = False
        '
        'ClueDisplayScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Controls.Add(Me.clueBrowser)
        Me.Controls.Add(Me.MiniClue1)
        Me.Controls.Add(Me.pboxClue)
        Me.Controls.Add(Me.wmpClue)
        Me.Controls.Add(Me.lblClue)
        Me.Name = "ClueDisplayScreen"
        Me.Size = New System.Drawing.Size(1932, 1092)
        CType(Me.wmpClue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxClue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblClue As Label
    Friend WithEvents wmpClue As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents pboxClue As PictureBox
    Friend WithEvents MiniClue1 As MiniClue
    Friend WithEvents clueBrowser As WebBrowser
End Class
