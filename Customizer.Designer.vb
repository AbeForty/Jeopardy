<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Customizer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Customizer))
        Me.saveBTN = New System.Windows.Forms.Button()
        Me.pnlCustomizer = New System.Windows.Forms.Panel()
        Me.QuestionsPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlAddedSpace2 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.lblPackName = New System.Windows.Forms.Label()
        Me.cboPack = New System.Windows.Forms.ComboBox()
        Me.lblRound = New System.Windows.Forms.Label()
        Me.cboRound = New System.Windows.Forms.ComboBox()
        Me.lblCategoryNumber = New System.Windows.Forms.Label()
        Me.numCategory = New System.Windows.Forms.NumericUpDown()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.numValue = New System.Windows.Forms.NumericUpDown()
        Me.lblDailyDouble = New System.Windows.Forms.Label()
        Me.chkDailyDouble = New System.Windows.Forms.CheckBox()
        Me.lblClue = New System.Windows.Forms.Label()
        Me.flpClue = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtClue = New System.Windows.Forms.TextBox()
        Me.txtInteractiveClue = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.chkOnlineResource = New System.Windows.Forms.CheckBox()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.cboQuestion = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.clueIDTextBox = New System.Windows.Forms.TextBox()
        Me.cboNewAnswers = New System.Windows.Forms.ComboBox()
        Me.cluePanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.pboxAddedSpace1 = New System.Windows.Forms.PictureBox()
        Me.pnlSelectPack = New System.Windows.Forms.Panel()
        Me.lblSelectPack = New System.Windows.Forms.Label()
        Me.cboSelectPack = New System.Windows.Forms.ComboBox()
        Me.dlgClueBrowser = New System.Windows.Forms.OpenFileDialog()
        Me.pnlCustomizer.SuspendLayout()
        Me.QuestionsPanel.SuspendLayout()
        Me.pnlAddedSpace2.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpClue.SuspendLayout()
        Me.cluePanel.SuspendLayout()
        CType(Me.pboxAddedSpace1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSelectPack.SuspendLayout()
        Me.SuspendLayout()
        '
        'saveBTN
        '
        Me.saveBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveBTN.Location = New System.Drawing.Point(1855, 1068)
        Me.saveBTN.Name = "saveBTN"
        Me.saveBTN.Size = New System.Drawing.Size(75, 23)
        Me.saveBTN.TabIndex = 6
        Me.saveBTN.Text = "Save"
        Me.saveBTN.UseVisualStyleBackColor = True
        Me.saveBTN.Visible = False
        '
        'pnlCustomizer
        '
        Me.pnlCustomizer.Controls.Add(Me.QuestionsPanel)
        Me.pnlCustomizer.Controls.Add(Me.cluePanel)
        Me.pnlCustomizer.Location = New System.Drawing.Point(282, 95)
        Me.pnlCustomizer.Name = "pnlCustomizer"
        Me.pnlCustomizer.Size = New System.Drawing.Size(1295, 827)
        Me.pnlCustomizer.TabIndex = 12
        Me.pnlCustomizer.Visible = False
        '
        'QuestionsPanel
        '
        Me.QuestionsPanel.Controls.Add(Me.pnlAddedSpace2)
        Me.QuestionsPanel.Controls.Add(Me.lblInstructions)
        Me.QuestionsPanel.Controls.Add(Me.lblPackName)
        Me.QuestionsPanel.Controls.Add(Me.cboPack)
        Me.QuestionsPanel.Controls.Add(Me.lblRound)
        Me.QuestionsPanel.Controls.Add(Me.cboRound)
        Me.QuestionsPanel.Controls.Add(Me.lblCategoryNumber)
        Me.QuestionsPanel.Controls.Add(Me.numCategory)
        Me.QuestionsPanel.Controls.Add(Me.lblCategory)
        Me.QuestionsPanel.Controls.Add(Me.cboCategory)
        Me.QuestionsPanel.Controls.Add(Me.lblValue)
        Me.QuestionsPanel.Controls.Add(Me.numValue)
        Me.QuestionsPanel.Controls.Add(Me.lblDailyDouble)
        Me.QuestionsPanel.Controls.Add(Me.chkDailyDouble)
        Me.QuestionsPanel.Controls.Add(Me.lblClue)
        Me.QuestionsPanel.Controls.Add(Me.flpClue)
        Me.QuestionsPanel.Controls.Add(Me.lblQuestion)
        Me.QuestionsPanel.Controls.Add(Me.cboQuestion)
        Me.QuestionsPanel.Controls.Add(Me.btnSubmit)
        Me.QuestionsPanel.Controls.Add(Me.clueIDTextBox)
        Me.QuestionsPanel.Controls.Add(Me.cboNewAnswers)
        Me.QuestionsPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.QuestionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.QuestionsPanel.Location = New System.Drawing.Point(723, 0)
        Me.QuestionsPanel.Name = "QuestionsPanel"
        Me.QuestionsPanel.Size = New System.Drawing.Size(572, 827)
        Me.QuestionsPanel.TabIndex = 1
        '
        'pnlAddedSpace2
        '
        Me.pnlAddedSpace2.Controls.Add(Me.btnClose)
        Me.pnlAddedSpace2.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddedSpace2.Name = "pnlAddedSpace2"
        Me.pnlAddedSpace2.Size = New System.Drawing.Size(562, 33)
        Me.pnlAddedSpace2.TabIndex = 19
        '
        'btnClose
        '
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.Image = Global.Jeopardy.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(529, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(33, 33)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 0
        Me.btnClose.TabStop = False
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Font = New System.Drawing.Font("Open Sans", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.ForeColor = System.Drawing.Color.Transparent
        Me.lblInstructions.Location = New System.Drawing.Point(3, 39)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(371, 38)
        Me.lblInstructions.TabIndex = 15
        Me.lblInstructions.Text = "Please select a clue from the left hand side to update. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If there are no previou" &
    "s clues, create a new pack." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPackName
        '
        Me.lblPackName.AutoSize = True
        Me.lblPackName.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackName.ForeColor = System.Drawing.Color.Transparent
        Me.lblPackName.Location = New System.Drawing.Point(3, 77)
        Me.lblPackName.Name = "lblPackName"
        Me.lblPackName.Size = New System.Drawing.Size(111, 23)
        Me.lblPackName.TabIndex = 18
        Me.lblPackName.Text = "PACK NAME"
        '
        'cboPack
        '
        Me.cboPack.Font = New System.Drawing.Font("Korinna BT", 10.2!)
        Me.cboPack.FormattingEnabled = True
        Me.cboPack.Location = New System.Drawing.Point(3, 103)
        Me.cboPack.MaxLength = 100
        Me.cboPack.Name = "cboPack"
        Me.cboPack.Size = New System.Drawing.Size(569, 28)
        Me.cboPack.TabIndex = 17
        '
        'lblRound
        '
        Me.lblRound.AutoSize = True
        Me.lblRound.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRound.ForeColor = System.Drawing.Color.Transparent
        Me.lblRound.Location = New System.Drawing.Point(3, 134)
        Me.lblRound.Name = "lblRound"
        Me.lblRound.Size = New System.Drawing.Size(75, 23)
        Me.lblRound.TabIndex = 21
        Me.lblRound.Text = "ROUND"
        '
        'cboRound
        '
        Me.cboRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRound.Font = New System.Drawing.Font("Korinna BT", 10.2!)
        Me.cboRound.FormattingEnabled = True
        Me.cboRound.Items.AddRange(New Object() {"JEOPARDY!", "DOUBLE JEOPARDY!", "FINAL JEOPARDY!"})
        Me.cboRound.Location = New System.Drawing.Point(3, 160)
        Me.cboRound.Name = "cboRound"
        Me.cboRound.Size = New System.Drawing.Size(569, 28)
        Me.cboRound.TabIndex = 20
        '
        'lblCategoryNumber
        '
        Me.lblCategoryNumber.AutoSize = True
        Me.lblCategoryNumber.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoryNumber.ForeColor = System.Drawing.Color.Transparent
        Me.lblCategoryNumber.Location = New System.Drawing.Point(3, 191)
        Me.lblCategoryNumber.Name = "lblCategoryNumber"
        Me.lblCategoryNumber.Size = New System.Drawing.Size(180, 23)
        Me.lblCategoryNumber.TabIndex = 12
        Me.lblCategoryNumber.Text = "CATEGORY NUMBER"
        '
        'numCategory
        '
        Me.numCategory.Font = New System.Drawing.Font("Korinna BT", 10.2!)
        Me.numCategory.Location = New System.Drawing.Point(3, 217)
        Me.numCategory.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.numCategory.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCategory.Name = "numCategory"
        Me.numCategory.Size = New System.Drawing.Size(570, 28)
        Me.numCategory.TabIndex = 13
        Me.numCategory.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.Transparent
        Me.lblCategory.Location = New System.Drawing.Point(3, 248)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(101, 23)
        Me.lblCategory.TabIndex = 7
        Me.lblCategory.Text = "CATEGORY"
        '
        'cboCategory
        '
        Me.cboCategory.Font = New System.Drawing.Font("Korinna BT", 10.2!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(3, 274)
        Me.cboCategory.MaxLength = 39
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(569, 28)
        Me.cboCategory.TabIndex = 1
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValue.ForeColor = System.Drawing.Color.Transparent
        Me.lblValue.Location = New System.Drawing.Point(3, 305)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(66, 23)
        Me.lblValue.TabIndex = 8
        Me.lblValue.Text = "VALUE"
        '
        'numValue
        '
        Me.numValue.Font = New System.Drawing.Font("Korinna BT", 10.2!)
        Me.numValue.Increment = New Decimal(New Integer() {200, 0, 0, 0})
        Me.numValue.InterceptArrowKeys = False
        Me.numValue.Location = New System.Drawing.Point(3, 331)
        Me.numValue.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numValue.Minimum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.numValue.Name = "numValue"
        Me.numValue.ReadOnly = True
        Me.numValue.Size = New System.Drawing.Size(570, 28)
        Me.numValue.TabIndex = 2
        Me.numValue.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'lblDailyDouble
        '
        Me.lblDailyDouble.AutoSize = True
        Me.lblDailyDouble.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyDouble.ForeColor = System.Drawing.Color.Transparent
        Me.lblDailyDouble.Location = New System.Drawing.Point(3, 362)
        Me.lblDailyDouble.Name = "lblDailyDouble"
        Me.lblDailyDouble.Size = New System.Drawing.Size(137, 23)
        Me.lblDailyDouble.TabIndex = 22
        Me.lblDailyDouble.Text = "DAILY DOUBLE"
        '
        'chkDailyDouble
        '
        Me.chkDailyDouble.AutoSize = True
        Me.chkDailyDouble.Font = New System.Drawing.Font("Korinna BT", 7.8!)
        Me.chkDailyDouble.ForeColor = System.Drawing.Color.White
        Me.chkDailyDouble.Location = New System.Drawing.Point(3, 388)
        Me.chkDailyDouble.Name = "chkDailyDouble"
        Me.chkDailyDouble.Size = New System.Drawing.Size(138, 20)
        Me.chkDailyDouble.TabIndex = 23
        Me.chkDailyDouble.Text = "Daily Double Clue"
        Me.chkDailyDouble.UseVisualStyleBackColor = True
        '
        'lblClue
        '
        Me.lblClue.AutoSize = True
        Me.lblClue.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClue.ForeColor = System.Drawing.Color.Transparent
        Me.lblClue.Location = New System.Drawing.Point(3, 411)
        Me.lblClue.Name = "lblClue"
        Me.lblClue.Size = New System.Drawing.Size(54, 23)
        Me.lblClue.TabIndex = 10
        Me.lblClue.Text = "CLUE"
        '
        'flpClue
        '
        Me.flpClue.Controls.Add(Me.txtClue)
        Me.flpClue.Controls.Add(Me.txtInteractiveClue)
        Me.flpClue.Controls.Add(Me.btnBrowse)
        Me.flpClue.Controls.Add(Me.chkOnlineResource)
        Me.flpClue.Location = New System.Drawing.Point(3, 437)
        Me.flpClue.Name = "flpClue"
        Me.flpClue.Size = New System.Drawing.Size(570, 216)
        Me.flpClue.TabIndex = 11
        '
        'txtClue
        '
        Me.txtClue.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtClue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtClue.Font = New System.Drawing.Font("Korinna", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClue.ForeColor = System.Drawing.Color.White
        Me.txtClue.Location = New System.Drawing.Point(3, 3)
        Me.txtClue.MaxLength = 255
        Me.txtClue.Multiline = True
        Me.txtClue.Name = "txtClue"
        Me.txtClue.Size = New System.Drawing.Size(559, 140)
        Me.txtClue.TabIndex = 0
        Me.txtClue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInteractiveClue
        '
        Me.txtInteractiveClue.Font = New System.Drawing.Font("Korinna BT", 10.8!)
        Me.txtInteractiveClue.Location = New System.Drawing.Point(3, 149)
        Me.txtInteractiveClue.Name = "txtInteractiveClue"
        Me.txtInteractiveClue.ReadOnly = True
        Me.txtInteractiveClue.Size = New System.Drawing.Size(449, 29)
        Me.txtInteractiveClue.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(458, 149)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(106, 32)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'chkOnlineResource
        '
        Me.chkOnlineResource.AutoSize = True
        Me.chkOnlineResource.Font = New System.Drawing.Font("Korinna BT", 7.8!)
        Me.chkOnlineResource.ForeColor = System.Drawing.Color.White
        Me.chkOnlineResource.Location = New System.Drawing.Point(3, 187)
        Me.chkOnlineResource.Name = "chkOnlineResource"
        Me.chkOnlineResource.Size = New System.Drawing.Size(169, 20)
        Me.chkOnlineResource.TabIndex = 3
        Me.chkOnlineResource.Text = "Use an online resource"
        Me.chkOnlineResource.UseVisualStyleBackColor = True
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.ForeColor = System.Drawing.Color.Transparent
        Me.lblQuestion.Location = New System.Drawing.Point(3, 656)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(100, 23)
        Me.lblQuestion.TabIndex = 25
        Me.lblQuestion.Text = "QUESTION"
        '
        'cboQuestion
        '
        Me.cboQuestion.Font = New System.Drawing.Font("Korinna BT", 10.2!)
        Me.cboQuestion.FormattingEnabled = True
        Me.cboQuestion.Location = New System.Drawing.Point(3, 682)
        Me.cboQuestion.MaxLength = 39
        Me.cboQuestion.Name = "cboQuestion"
        Me.cboQuestion.Size = New System.Drawing.Size(569, 28)
        Me.cboQuestion.TabIndex = 24
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Korinna", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(3, 716)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(566, 46)
        Me.btnSubmit.TabIndex = 16
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'clueIDTextBox
        '
        Me.clueIDTextBox.Location = New System.Drawing.Point(3, 768)
        Me.clueIDTextBox.Name = "clueIDTextBox"
        Me.clueIDTextBox.ReadOnly = True
        Me.clueIDTextBox.Size = New System.Drawing.Size(570, 22)
        Me.clueIDTextBox.TabIndex = 14
        Me.clueIDTextBox.Visible = False
        '
        'cboNewAnswers
        '
        Me.cboNewAnswers.Font = New System.Drawing.Font("Open Sans", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNewAnswers.FormattingEnabled = True
        Me.cboNewAnswers.Location = New System.Drawing.Point(579, 3)
        Me.cboNewAnswers.MaxLength = 39
        Me.cboNewAnswers.Name = "cboNewAnswers"
        Me.cboNewAnswers.Size = New System.Drawing.Size(569, 31)
        Me.cboNewAnswers.TabIndex = 26
        Me.cboNewAnswers.Visible = False
        '
        'cluePanel
        '
        Me.cluePanel.AutoScroll = True
        Me.cluePanel.Controls.Add(Me.pboxAddedSpace1)
        Me.cluePanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.cluePanel.Location = New System.Drawing.Point(0, 0)
        Me.cluePanel.Name = "cluePanel"
        Me.cluePanel.Size = New System.Drawing.Size(717, 827)
        Me.cluePanel.TabIndex = 12
        '
        'pboxAddedSpace1
        '
        Me.pboxAddedSpace1.Location = New System.Drawing.Point(3, 3)
        Me.pboxAddedSpace1.Name = "pboxAddedSpace1"
        Me.pboxAddedSpace1.Size = New System.Drawing.Size(691, 33)
        Me.pboxAddedSpace1.TabIndex = 11
        Me.pboxAddedSpace1.TabStop = False
        '
        'pnlSelectPack
        '
        Me.pnlSelectPack.Controls.Add(Me.lblSelectPack)
        Me.pnlSelectPack.Controls.Add(Me.cboSelectPack)
        Me.pnlSelectPack.Location = New System.Drawing.Point(282, 95)
        Me.pnlSelectPack.Name = "pnlSelectPack"
        Me.pnlSelectPack.Size = New System.Drawing.Size(1296, 830)
        Me.pnlSelectPack.TabIndex = 13
        '
        'lblSelectPack
        '
        Me.lblSelectPack.AutoSize = True
        Me.lblSelectPack.Font = New System.Drawing.Font("Open Sans", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblSelectPack.ForeColor = System.Drawing.Color.Transparent
        Me.lblSelectPack.Location = New System.Drawing.Point(428, 269)
        Me.lblSelectPack.Name = "lblSelectPack"
        Me.lblSelectPack.Size = New System.Drawing.Size(439, 46)
        Me.lblSelectPack.TabIndex = 20
        Me.lblSelectPack.Text = "SELECT A PACK TO BEGIN"
        '
        'cboSelectPack
        '
        Me.cboSelectPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelectPack.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.cboSelectPack.FormattingEnabled = True
        Me.cboSelectPack.Items.AddRange(New Object() {"CREATE NEW PACK"})
        Me.cboSelectPack.Location = New System.Drawing.Point(452, 330)
        Me.cboSelectPack.Name = "cboSelectPack"
        Me.cboSelectPack.Size = New System.Drawing.Size(390, 38)
        Me.cboSelectPack.TabIndex = 19
        '
        'dlgClueBrowser
        '
        Me.dlgClueBrowser.FileName = "clue"
        Me.dlgClueBrowser.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.GIF)|*.PNG;*.BMP;*.JPG;*.GIF|Video Files(*.MP4;*." &
    "WMV;*.AVI;*.MOV)|*.MP4;*.WMV;*.AVI;*.MOV|Audio Files(*.M4A;*.MP3;*.WAV;*.WMA)|*." &
    "M4A;*.MP3;*.WAV;*.WMA"
        '
        'Customizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardyBoardBlur
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1942, 1102)
        Me.Controls.Add(Me.saveBTN)
        Me.Controls.Add(Me.pnlSelectPack)
        Me.Controls.Add(Me.pnlCustomizer)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Customizer"
        Me.Text = "Customizer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlCustomizer.ResumeLayout(False)
        Me.QuestionsPanel.ResumeLayout(False)
        Me.QuestionsPanel.PerformLayout()
        Me.pnlAddedSpace2.ResumeLayout(False)
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpClue.ResumeLayout(False)
        Me.flpClue.PerformLayout()
        Me.cluePanel.ResumeLayout(False)
        CType(Me.pboxAddedSpace1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSelectPack.ResumeLayout(False)
        Me.pnlSelectPack.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents saveBTN As Button
    Friend WithEvents pnlCustomizer As Panel
    Friend WithEvents cluePanel As FlowLayoutPanel
    Friend WithEvents QuestionsPanel As FlowLayoutPanel
    Friend WithEvents lblInstructions As Label
    Friend WithEvents lblCategoryNumber As Label
    Friend WithEvents numCategory As NumericUpDown
    Friend WithEvents lblCategory As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblValue As Label
    Friend WithEvents numValue As NumericUpDown
    Friend WithEvents lblClue As Label
    Friend WithEvents flpClue As FlowLayoutPanel
    Friend WithEvents clueIDTextBox As TextBox
    Friend WithEvents txtClue As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblPackName As Label
    Friend WithEvents cboPack As ComboBox
    Friend WithEvents cboSelectPack As ComboBox
    Friend WithEvents pnlSelectPack As Panel
    Friend WithEvents lblSelectPack As Label
    Friend WithEvents pboxAddedSpace1 As PictureBox
    Friend WithEvents pnlAddedSpace2 As Panel
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents lblRound As Label
    Friend WithEvents cboRound As ComboBox
    Friend WithEvents txtInteractiveClue As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents dlgClueBrowser As OpenFileDialog
    Friend WithEvents lblDailyDouble As Label
    Friend WithEvents chkDailyDouble As CheckBox
    Friend WithEvents lblQuestion As Label
    Friend WithEvents cboQuestion As ComboBox
    Friend WithEvents chkOnlineResource As CheckBox
    Friend WithEvents cboNewAnswers As ComboBox
End Class
