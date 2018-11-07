<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClueDisplay
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
        Me.formatLabel2 = New System.Windows.Forms.Label()
        Me.editBTN = New System.Windows.Forms.PictureBox()
        Me.cboQuestion = New System.Windows.Forms.ComboBox()
        Me.lblCBID = New System.Windows.Forms.Label()
        CType(Me.editBTN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'categorylbl
        '
        Me.categorylbl.AutoEllipsis = True
        Me.categorylbl.Font = New System.Drawing.Font("Open Sans", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.categorylbl.ForeColor = System.Drawing.Color.Transparent
        Me.categorylbl.Location = New System.Drawing.Point(214, 16)
        Me.categorylbl.Name = "categorylbl"
        Me.categorylbl.Size = New System.Drawing.Size(427, 40)
        Me.categorylbl.TabIndex = 13
        Me.categorylbl.Text = "CATEGORY"
        Me.categorylbl.UseMnemonic = False
        '
        'valuelbl
        '
        Me.valuelbl.AutoEllipsis = True
        Me.valuelbl.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valuelbl.ForeColor = System.Drawing.Color.Transparent
        Me.valuelbl.Location = New System.Drawing.Point(218, 64)
        Me.valuelbl.Name = "valuelbl"
        Me.valuelbl.Size = New System.Drawing.Size(423, 23)
        Me.valuelbl.TabIndex = 14
        Me.valuelbl.Text = "VALUE"
        Me.valuelbl.UseMnemonic = False
        '
        'answerlbl
        '
        Me.answerlbl.AutoEllipsis = True
        Me.answerlbl.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.answerlbl.ForeColor = System.Drawing.Color.Transparent
        Me.answerlbl.Location = New System.Drawing.Point(216, 97)
        Me.answerlbl.Name = "answerlbl"
        Me.answerlbl.Size = New System.Drawing.Size(425, 26)
        Me.answerlbl.TabIndex = 15
        Me.answerlbl.Text = "ANSWER"
        Me.answerlbl.Visible = False
        '
        'imgLabel
        '
        Me.imgLabel.AutoSize = True
        Me.imgLabel.ForeColor = System.Drawing.Color.Transparent
        Me.imgLabel.Location = New System.Drawing.Point(217, 128)
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
        Me.clueIDlbl.Location = New System.Drawing.Point(269, 128)
        Me.clueIDlbl.Name = "clueIDlbl"
        Me.clueIDlbl.Size = New System.Drawing.Size(47, 17)
        Me.clueIDlbl.TabIndex = 18
        Me.clueIDlbl.Text = "clueID"
        Me.clueIDlbl.Visible = False
        '
        'formatLabel2
        '
        Me.formatLabel2.Font = New System.Drawing.Font("Korinna", 5.0!)
        Me.formatLabel2.ForeColor = System.Drawing.Color.Transparent
        Me.formatLabel2.Location = New System.Drawing.Point(7, 16)
        Me.formatLabel2.Name = "formatLabel2"
        Me.formatLabel2.Size = New System.Drawing.Size(208, 92)
        Me.formatLabel2.TabIndex = 19
        Me.formatLabel2.Text = "CLUE"
        Me.formatLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.formatLabel2.UseMnemonic = False
        '
        'editBTN
        '
        Me.editBTN.Image = Global.Jeopardy.My.Resources.Resources.editOptions
        Me.editBTN.Location = New System.Drawing.Point(89, 111)
        Me.editBTN.Name = "editBTN"
        Me.editBTN.Size = New System.Drawing.Size(35, 34)
        Me.editBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.editBTN.TabIndex = 16
        Me.editBTN.TabStop = False
        '
        'cboQuestion
        '
        Me.cboQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQuestion.Font = New System.Drawing.Font("Korinna BT", 7.8!)
        Me.cboQuestion.FormattingEnabled = True
        Me.cboQuestion.Location = New System.Drawing.Point(220, 97)
        Me.cboQuestion.Name = "cboQuestion"
        Me.cboQuestion.Size = New System.Drawing.Size(406, 24)
        Me.cboQuestion.TabIndex = 20
        '
        'lblCBID
        '
        Me.lblCBID.AutoSize = True
        Me.lblCBID.ForeColor = System.Drawing.Color.White
        Me.lblCBID.Location = New System.Drawing.Point(322, 128)
        Me.lblCBID.Name = "lblCBID"
        Me.lblCBID.Size = New System.Drawing.Size(36, 17)
        Me.lblCBID.TabIndex = 21
        Me.lblCBID.Text = "cbID"
        Me.lblCBID.Visible = False
        '
        'ClueDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Controls.Add(Me.lblCBID)
        Me.Controls.Add(Me.cboQuestion)
        Me.Controls.Add(Me.formatLabel2)
        Me.Controls.Add(Me.clueIDlbl)
        Me.Controls.Add(Me.imgLabel)
        Me.Controls.Add(Me.editBTN)
        Me.Controls.Add(Me.answerlbl)
        Me.Controls.Add(Me.valuelbl)
        Me.Controls.Add(Me.categorylbl)
        Me.Name = "ClueDisplay"
        Me.Size = New System.Drawing.Size(644, 162)
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
    Friend WithEvents formatLabel2 As Label
    Friend WithEvents cboQuestion As ComboBox
    Friend WithEvents lblCBID As Label
End Class
