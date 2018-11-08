<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DailyDouble
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailyDouble))
        Me.wagerBox = New System.Windows.Forms.NumericUpDown()
        Me.lblWagerTitle = New System.Windows.Forms.Label()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblWagerRules = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnTrueDailyDouble = New System.Windows.Forms.Button()
        CType(Me.wagerBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wagerBox
        '
        Me.wagerBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.wagerBox.Font = New System.Drawing.Font("Univers LT Std 55", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wagerBox.ForeColor = System.Drawing.Color.Transparent
        Me.wagerBox.Location = New System.Drawing.Point(786, 484)
        Me.wagerBox.Name = "wagerBox"
        Me.wagerBox.Size = New System.Drawing.Size(451, 156)
        Me.wagerBox.TabIndex = 0
        '
        'lblWagerTitle
        '
        Me.lblWagerTitle.AutoSize = True
        Me.lblWagerTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblWagerTitle.Font = New System.Drawing.Font("Korinna", 36.0!)
        Me.lblWagerTitle.ForeColor = System.Drawing.Color.Transparent
        Me.lblWagerTitle.Location = New System.Drawing.Point(753, 345)
        Me.lblWagerTitle.Name = "lblWagerTitle"
        Me.lblWagerTitle.Size = New System.Drawing.Size(523, 76)
        Me.lblWagerTitle.TabIndex = 4
        Me.lblWagerTitle.Text = "Enter your wager"
        Me.lblWagerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 0)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(1932, 1092)
        Me.AxWindowsMediaPlayer1.TabIndex = 5
        '
        'btnGo
        '
        Me.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGo.Font = New System.Drawing.Font("Korinna", 36.0!)
        Me.btnGo.ForeColor = System.Drawing.Color.Transparent
        Me.btnGo.Location = New System.Drawing.Point(1068, 666)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(172, 97)
        Me.btnGo.TabIndex = 6
        Me.btnGo.Text = "GO"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'lblWagerRules
        '
        Me.lblWagerRules.AutoSize = True
        Me.lblWagerRules.Font = New System.Drawing.Font("Korinna", 13.8!)
        Me.lblWagerRules.ForeColor = System.Drawing.Color.Transparent
        Me.lblWagerRules.Location = New System.Drawing.Point(718, 437)
        Me.lblWagerRules.Name = "lblWagerRules"
        Me.lblWagerRules.Size = New System.Drawing.Size(606, 30)
        Me.lblWagerRules.TabIndex = 7
        Me.lblWagerRules.Text = "You can bet up to $1000 if you have $0 in your bank"
        '
        'Timer2
        '
        '
        'btnTrueDailyDouble
        '
        Me.btnTrueDailyDouble.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTrueDailyDouble.Font = New System.Drawing.Font("Korinna", 19.8!)
        Me.btnTrueDailyDouble.ForeColor = System.Drawing.Color.Transparent
        Me.btnTrueDailyDouble.Location = New System.Drawing.Point(786, 666)
        Me.btnTrueDailyDouble.Name = "btnTrueDailyDouble"
        Me.btnTrueDailyDouble.Size = New System.Drawing.Size(276, 97)
        Me.btnTrueDailyDouble.TabIndex = 8
        Me.btnTrueDailyDouble.Text = "True Daily Double"
        Me.btnTrueDailyDouble.UseVisualStyleBackColor = True
        '
        'DailyDouble
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.btnTrueDailyDouble)
        Me.Controls.Add(Me.lblWagerRules)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.lblWagerTitle)
        Me.Controls.Add(Me.wagerBox)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DailyDouble"
        Me.Text = "Daily Double"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.wagerBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents wagerBox As NumericUpDown
    Friend WithEvents lblWagerTitle As Label
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnGo As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblWagerRules As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnTrueDailyDouble As Button
End Class