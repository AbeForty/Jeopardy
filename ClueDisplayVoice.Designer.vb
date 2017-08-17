<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClueDisplayVoice
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.categorylbl = New System.Windows.Forms.Label()
        Me.valuelbl = New System.Windows.Forms.Label()
        Me.answerlbl = New System.Windows.Forms.Label()
        Me.imgLabel = New System.Windows.Forms.Label()
        Me.clueIDlbl = New System.Windows.Forms.Label()
        Me.lblClue = New System.Windows.Forms.Label()
        Me.editBTN = New System.Windows.Forms.PictureBox()
        CType(Me.editBTN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'categorylbl
        '
        Me.categorylbl.AutoEllipsis = True
        Me.categorylbl.Font = New System.Drawing.Font("Open Sans", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categorylbl.ForeColor = System.Drawing.Color.Transparent
        Me.categorylbl.Location = New System.Drawing.Point(154, 16)
        Me.categorylbl.Name = "categorylbl"
        Me.categorylbl.Size = New System.Drawing.Size(345, 40)
        Me.categorylbl.TabIndex = 13
        Me.categorylbl.Text = "CATEGORY"
        '
        'valuelbl
        '
        Me.valuelbl.AutoEllipsis = True
        Me.valuelbl.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valuelbl.ForeColor = System.Drawing.Color.Transparent
        Me.valuelbl.Location = New System.Drawing.Point(158, 64)
        Me.valuelbl.Name = "valuelbl"
        Me.valuelbl.Size = New System.Drawing.Size(345, 23)
        Me.valuelbl.TabIndex = 14
        Me.valuelbl.Text = "VALUE"
        '
        'answerlbl
        '
        Me.answerlbl.AutoEllipsis = True
        Me.answerlbl.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.answerlbl.ForeColor = System.Drawing.Color.Transparent
        Me.answerlbl.Location = New System.Drawing.Point(156, 97)
        Me.answerlbl.Name = "answerlbl"
        Me.answerlbl.Size = New System.Drawing.Size(345, 26)
        Me.answerlbl.TabIndex = 15
        Me.answerlbl.Text = "ANSWER"
        Me.answerlbl.Visible = False
        '
        'imgLabel
        '
        Me.imgLabel.AutoSize = True
        Me.imgLabel.ForeColor = System.Drawing.Color.Transparent
        Me.imgLabel.Location = New System.Drawing.Point(159, 128)
        Me.imgLabel.Name = "imgLabel"
        Me.imgLabel.Size = New System.Drawing.Size(46, 17)
        Me.imgLabel.TabIndex = 17
        Me.imgLabel.Text = "image"
        Me.imgLabel.Visible = False
        '
        'clueIDlbl
        '
        Me.clueIDlbl.AutoSize = True
        Me.clueIDlbl.ForeColor = System.Drawing.Color.Transparent
        Me.clueIDlbl.Location = New System.Drawing.Point(211, 128)
        Me.clueIDlbl.Name = "clueIDlbl"
        Me.clueIDlbl.Size = New System.Drawing.Size(47, 17)
        Me.clueIDlbl.TabIndex = 18
        Me.clueIDlbl.Text = "clueID"
        Me.clueIDlbl.Visible = False
        '
        'lblClue
        '
        Me.lblClue.Font = New System.Drawing.Font("Korinna", 5.0!)
        Me.lblClue.ForeColor = System.Drawing.Color.Transparent
        Me.lblClue.Location = New System.Drawing.Point(7, 12)
        Me.lblClue.Name = "lblClue"
        Me.lblClue.Size = New System.Drawing.Size(145, 92)
        Me.lblClue.TabIndex = 19
        Me.lblClue.Text = "CLUE"
        Me.lblClue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'editBTN
        '
        Me.editBTN.Image = Global.Jeopardy.My.Resources.Resources.editOptions
        Me.editBTN.Location = New System.Drawing.Point(50, 111)
        Me.editBTN.Name = "editBTN"
        Me.editBTN.Size = New System.Drawing.Size(35, 34)
        Me.editBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.editBTN.TabIndex = 16
        Me.editBTN.TabStop = False
        '
        'ClueDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Controls.Add(Me.lblClue)
        Me.Controls.Add(Me.clueIDlbl)
        Me.Controls.Add(Me.imgLabel)
        Me.Controls.Add(Me.editBTN)
        Me.Controls.Add(Me.answerlbl)
        Me.Controls.Add(Me.valuelbl)
        Me.Controls.Add(Me.categorylbl)
        Me.Name = "ClueDisplay"
        Me.Size = New System.Drawing.Size(506, 162)
        CType(Me.editBTN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents categorylbl As Label
    Friend WithEvents valuelbl As Label
    Friend WithEvents answerlbl As Label
    Friend WithEvents editBTN As PictureBox
    Friend WithEvents imgLabel As Label
    Friend WithEvents clueIDlbl As Label
    Friend WithEvents lblClue As Label
End Class
