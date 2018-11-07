<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class categoryScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(categoryScreen))
        Me.catPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.cat1Title = New Jeopardy.CategoryTitle()
        Me.cat2Title = New Jeopardy.CategoryTitle()
        Me.cat3Title = New Jeopardy.CategoryTitle()
        Me.cat4Title = New Jeopardy.CategoryTitle()
        Me.cat5Title = New Jeopardy.CategoryTitle()
        Me.cat6Title = New Jeopardy.CategoryTitle()
        Me.Cat1200 = New System.Windows.Forms.PictureBox()
        Me.Cat2200 = New System.Windows.Forms.PictureBox()
        Me.Cat3200 = New System.Windows.Forms.PictureBox()
        Me.Cat4200 = New System.Windows.Forms.PictureBox()
        Me.Cat5200 = New System.Windows.Forms.PictureBox()
        Me.Cat6200 = New System.Windows.Forms.PictureBox()
        Me.Cat1400 = New System.Windows.Forms.PictureBox()
        Me.Cat2400 = New System.Windows.Forms.PictureBox()
        Me.Cat3400 = New System.Windows.Forms.PictureBox()
        Me.Cat4400 = New System.Windows.Forms.PictureBox()
        Me.Cat5400 = New System.Windows.Forms.PictureBox()
        Me.Cat6400 = New System.Windows.Forms.PictureBox()
        Me.Cat1600 = New System.Windows.Forms.PictureBox()
        Me.Cat2600 = New System.Windows.Forms.PictureBox()
        Me.Cat3600 = New System.Windows.Forms.PictureBox()
        Me.Cat4600 = New System.Windows.Forms.PictureBox()
        Me.Cat5600 = New System.Windows.Forms.PictureBox()
        Me.Cat6600 = New System.Windows.Forms.PictureBox()
        Me.Cat1800 = New System.Windows.Forms.PictureBox()
        Me.Cat2800 = New System.Windows.Forms.PictureBox()
        Me.Cat3800 = New System.Windows.Forms.PictureBox()
        Me.Cat4800 = New System.Windows.Forms.PictureBox()
        Me.Cat5800 = New System.Windows.Forms.PictureBox()
        Me.Cat6800 = New System.Windows.Forms.PictureBox()
        Me.Cat11000 = New System.Windows.Forms.PictureBox()
        Me.Cat21000 = New System.Windows.Forms.PictureBox()
        Me.Cat31000 = New System.Windows.Forms.PictureBox()
        Me.Cat41000 = New System.Windows.Forms.PictureBox()
        Me.Cat51000 = New System.Windows.Forms.PictureBox()
        Me.Cat61000 = New System.Windows.Forms.PictureBox()
        Me.pbarCatReveal = New System.Windows.Forms.ProgressBar()
        Me.tmrCatReveal = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckReveal = New System.Windows.Forms.Timer(Me.components)
        Me.tmrPointValueBox = New System.Windows.Forms.Timer(Me.components)
        Me.pbarPVB = New System.Windows.Forms.ProgressBar()
        Me.tmrCheckCatCleared = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRingIn = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckIfRungIn = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckCurrentRound = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckRecogStopped = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckIfSelectCategory = New System.Windows.Forms.Timer(Me.components)
        Me.rtbSeenClues = New System.Windows.Forms.RichTextBox()
        Me.rtbPointValues = New System.Windows.Forms.RichTextBox()
        Me.categoryPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.catListBox = New System.Windows.Forms.ListBox()
        Me.loadCatProgressBar = New System.Windows.Forms.ProgressBar()
        Me.pbarLoadCat = New System.Windows.Forms.ProgressBar()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.TrackBar3 = New System.Windows.Forms.TrackBar()
        Me.TrackBar4 = New System.Windows.Forms.TrackBar()
        Me.TrackBar5 = New System.Windows.Forms.TrackBar()
        Me.TrackBar6 = New System.Windows.Forms.TrackBar()
        Me.TrackBar7 = New System.Windows.Forms.TrackBar()
        Me.TrackBar8 = New System.Windows.Forms.TrackBar()
        Me.TrackBar9 = New System.Windows.Forms.TrackBar()
        Me.TrackBar10 = New System.Windows.Forms.TrackBar()
        Me.timeOutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.playerTimeOutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.clue = New Jeopardy.ClueDisplayScreen()
        Me.CategoryDisplay1 = New Jeopardy.CategoryDisplay()
        Me.PointValueBox = New System.Windows.Forms.PictureBox()
        Me.catPanel.SuspendLayout()
        CType(Me.Cat1200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat2200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat3200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat4200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat5200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat6200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat1400, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat2400, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat3400, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat4400, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat5400, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat6400, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat1600, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat2600, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat3600, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat4600, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat5600, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat6600, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat1800, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat2800, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat3800, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat4800, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat5800, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat6800, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat11000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat21000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat31000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat41000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat51000, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cat61000, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.categoryPanel.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PointValueBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'catPanel
        '
        Me.catPanel.BackColor = System.Drawing.Color.Black
        Me.catPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.catPanel.Controls.Add(Me.cat1Title)
        Me.catPanel.Controls.Add(Me.cat2Title)
        Me.catPanel.Controls.Add(Me.cat3Title)
        Me.catPanel.Controls.Add(Me.cat4Title)
        Me.catPanel.Controls.Add(Me.cat5Title)
        Me.catPanel.Controls.Add(Me.cat6Title)
        Me.catPanel.Location = New System.Drawing.Point(357, 194)
        Me.catPanel.Name = "catPanel"
        Me.catPanel.Size = New System.Drawing.Size(1349, 128)
        Me.catPanel.TabIndex = 0
        '
        'cat1Title
        '
        Me.cat1Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cat1Title.BackgroundImage = CType(resources.GetObject("cat1Title.BackgroundImage"), System.Drawing.Image)
        Me.cat1Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cat1Title.display = True
        Me.cat1Title.Location = New System.Drawing.Point(3, 3)
        Me.cat1Title.Name = "cat1Title"
        Me.cat1Title.Size = New System.Drawing.Size(218, 125)
        Me.cat1Title.TabIndex = 6
        '
        'cat2Title
        '
        Me.cat2Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cat2Title.BackgroundImage = CType(resources.GetObject("cat2Title.BackgroundImage"), System.Drawing.Image)
        Me.cat2Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cat2Title.display = True
        Me.cat2Title.Location = New System.Drawing.Point(227, 3)
        Me.cat2Title.Name = "cat2Title"
        Me.cat2Title.Size = New System.Drawing.Size(218, 125)
        Me.cat2Title.TabIndex = 7
        '
        'cat3Title
        '
        Me.cat3Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cat3Title.BackgroundImage = CType(resources.GetObject("cat3Title.BackgroundImage"), System.Drawing.Image)
        Me.cat3Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cat3Title.display = True
        Me.cat3Title.Location = New System.Drawing.Point(451, 3)
        Me.cat3Title.Name = "cat3Title"
        Me.cat3Title.Size = New System.Drawing.Size(218, 125)
        Me.cat3Title.TabIndex = 8
        '
        'cat4Title
        '
        Me.cat4Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cat4Title.BackgroundImage = CType(resources.GetObject("cat4Title.BackgroundImage"), System.Drawing.Image)
        Me.cat4Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cat4Title.display = True
        Me.cat4Title.Location = New System.Drawing.Point(675, 3)
        Me.cat4Title.Name = "cat4Title"
        Me.cat4Title.Size = New System.Drawing.Size(218, 125)
        Me.cat4Title.TabIndex = 9
        '
        'cat5Title
        '
        Me.cat5Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cat5Title.BackgroundImage = CType(resources.GetObject("cat5Title.BackgroundImage"), System.Drawing.Image)
        Me.cat5Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cat5Title.display = True
        Me.cat5Title.Location = New System.Drawing.Point(899, 3)
        Me.cat5Title.Name = "cat5Title"
        Me.cat5Title.Size = New System.Drawing.Size(218, 125)
        Me.cat5Title.TabIndex = 10
        '
        'cat6Title
        '
        Me.cat6Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.cat6Title.BackgroundImage = CType(resources.GetObject("cat6Title.BackgroundImage"), System.Drawing.Image)
        Me.cat6Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cat6Title.display = True
        Me.cat6Title.Location = New System.Drawing.Point(1123, 3)
        Me.cat6Title.Name = "cat6Title"
        Me.cat6Title.Size = New System.Drawing.Size(218, 125)
        Me.cat6Title.TabIndex = 11
        '
        'Cat1200
        '
        Me.Cat1200.Image = CType(resources.GetObject("Cat1200.Image"), System.Drawing.Image)
        Me.Cat1200.Location = New System.Drawing.Point(3, 3)
        Me.Cat1200.Name = "Cat1200"
        Me.Cat1200.Size = New System.Drawing.Size(218, 110)
        Me.Cat1200.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat1200.TabIndex = 1
        Me.Cat1200.TabStop = False
        Me.Cat1200.Visible = False
        '
        'Cat2200
        '
        Me.Cat2200.Image = CType(resources.GetObject("Cat2200.Image"), System.Drawing.Image)
        Me.Cat2200.Location = New System.Drawing.Point(227, 3)
        Me.Cat2200.Name = "Cat2200"
        Me.Cat2200.Size = New System.Drawing.Size(218, 110)
        Me.Cat2200.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat2200.TabIndex = 2
        Me.Cat2200.TabStop = False
        Me.Cat2200.Visible = False
        '
        'Cat3200
        '
        Me.Cat3200.Image = CType(resources.GetObject("Cat3200.Image"), System.Drawing.Image)
        Me.Cat3200.Location = New System.Drawing.Point(451, 3)
        Me.Cat3200.Name = "Cat3200"
        Me.Cat3200.Size = New System.Drawing.Size(218, 110)
        Me.Cat3200.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat3200.TabIndex = 3
        Me.Cat3200.TabStop = False
        Me.Cat3200.Visible = False
        '
        'Cat4200
        '
        Me.Cat4200.Image = CType(resources.GetObject("Cat4200.Image"), System.Drawing.Image)
        Me.Cat4200.Location = New System.Drawing.Point(675, 3)
        Me.Cat4200.Name = "Cat4200"
        Me.Cat4200.Size = New System.Drawing.Size(218, 110)
        Me.Cat4200.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat4200.TabIndex = 4
        Me.Cat4200.TabStop = False
        Me.Cat4200.Visible = False
        '
        'Cat5200
        '
        Me.Cat5200.Image = CType(resources.GetObject("Cat5200.Image"), System.Drawing.Image)
        Me.Cat5200.Location = New System.Drawing.Point(899, 3)
        Me.Cat5200.Name = "Cat5200"
        Me.Cat5200.Size = New System.Drawing.Size(218, 110)
        Me.Cat5200.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat5200.TabIndex = 5
        Me.Cat5200.TabStop = False
        Me.Cat5200.Visible = False
        '
        'Cat6200
        '
        Me.Cat6200.Image = CType(resources.GetObject("Cat6200.Image"), System.Drawing.Image)
        Me.Cat6200.Location = New System.Drawing.Point(1123, 3)
        Me.Cat6200.Name = "Cat6200"
        Me.Cat6200.Size = New System.Drawing.Size(218, 110)
        Me.Cat6200.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat6200.TabIndex = 6
        Me.Cat6200.TabStop = False
        Me.Cat6200.Visible = False
        '
        'Cat1400
        '
        Me.Cat1400.Image = CType(resources.GetObject("Cat1400.Image"), System.Drawing.Image)
        Me.Cat1400.Location = New System.Drawing.Point(3, 119)
        Me.Cat1400.Name = "Cat1400"
        Me.Cat1400.Size = New System.Drawing.Size(218, 110)
        Me.Cat1400.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat1400.TabIndex = 7
        Me.Cat1400.TabStop = False
        Me.Cat1400.Visible = False
        '
        'Cat2400
        '
        Me.Cat2400.Image = CType(resources.GetObject("Cat2400.Image"), System.Drawing.Image)
        Me.Cat2400.Location = New System.Drawing.Point(227, 119)
        Me.Cat2400.Name = "Cat2400"
        Me.Cat2400.Size = New System.Drawing.Size(218, 110)
        Me.Cat2400.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat2400.TabIndex = 8
        Me.Cat2400.TabStop = False
        Me.Cat2400.Visible = False
        '
        'Cat3400
        '
        Me.Cat3400.Image = CType(resources.GetObject("Cat3400.Image"), System.Drawing.Image)
        Me.Cat3400.Location = New System.Drawing.Point(451, 119)
        Me.Cat3400.Name = "Cat3400"
        Me.Cat3400.Size = New System.Drawing.Size(218, 110)
        Me.Cat3400.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat3400.TabIndex = 9
        Me.Cat3400.TabStop = False
        Me.Cat3400.Visible = False
        '
        'Cat4400
        '
        Me.Cat4400.Image = CType(resources.GetObject("Cat4400.Image"), System.Drawing.Image)
        Me.Cat4400.Location = New System.Drawing.Point(675, 119)
        Me.Cat4400.Name = "Cat4400"
        Me.Cat4400.Size = New System.Drawing.Size(218, 110)
        Me.Cat4400.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat4400.TabIndex = 10
        Me.Cat4400.TabStop = False
        Me.Cat4400.Visible = False
        '
        'Cat5400
        '
        Me.Cat5400.Image = CType(resources.GetObject("Cat5400.Image"), System.Drawing.Image)
        Me.Cat5400.Location = New System.Drawing.Point(899, 119)
        Me.Cat5400.Name = "Cat5400"
        Me.Cat5400.Size = New System.Drawing.Size(218, 110)
        Me.Cat5400.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat5400.TabIndex = 11
        Me.Cat5400.TabStop = False
        Me.Cat5400.Visible = False
        '
        'Cat6400
        '
        Me.Cat6400.Image = CType(resources.GetObject("Cat6400.Image"), System.Drawing.Image)
        Me.Cat6400.Location = New System.Drawing.Point(1123, 119)
        Me.Cat6400.Name = "Cat6400"
        Me.Cat6400.Size = New System.Drawing.Size(218, 110)
        Me.Cat6400.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat6400.TabIndex = 12
        Me.Cat6400.TabStop = False
        Me.Cat6400.Visible = False
        '
        'Cat1600
        '
        Me.Cat1600.Image = CType(resources.GetObject("Cat1600.Image"), System.Drawing.Image)
        Me.Cat1600.Location = New System.Drawing.Point(3, 235)
        Me.Cat1600.Name = "Cat1600"
        Me.Cat1600.Size = New System.Drawing.Size(218, 110)
        Me.Cat1600.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat1600.TabIndex = 13
        Me.Cat1600.TabStop = False
        Me.Cat1600.Visible = False
        '
        'Cat2600
        '
        Me.Cat2600.Image = CType(resources.GetObject("Cat2600.Image"), System.Drawing.Image)
        Me.Cat2600.Location = New System.Drawing.Point(227, 235)
        Me.Cat2600.Name = "Cat2600"
        Me.Cat2600.Size = New System.Drawing.Size(218, 110)
        Me.Cat2600.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat2600.TabIndex = 14
        Me.Cat2600.TabStop = False
        Me.Cat2600.Visible = False
        '
        'Cat3600
        '
        Me.Cat3600.Image = CType(resources.GetObject("Cat3600.Image"), System.Drawing.Image)
        Me.Cat3600.Location = New System.Drawing.Point(451, 235)
        Me.Cat3600.Name = "Cat3600"
        Me.Cat3600.Size = New System.Drawing.Size(218, 110)
        Me.Cat3600.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat3600.TabIndex = 15
        Me.Cat3600.TabStop = False
        Me.Cat3600.Visible = False
        '
        'Cat4600
        '
        Me.Cat4600.Image = CType(resources.GetObject("Cat4600.Image"), System.Drawing.Image)
        Me.Cat4600.Location = New System.Drawing.Point(675, 235)
        Me.Cat4600.Name = "Cat4600"
        Me.Cat4600.Size = New System.Drawing.Size(218, 110)
        Me.Cat4600.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat4600.TabIndex = 16
        Me.Cat4600.TabStop = False
        Me.Cat4600.Visible = False
        '
        'Cat5600
        '
        Me.Cat5600.Image = CType(resources.GetObject("Cat5600.Image"), System.Drawing.Image)
        Me.Cat5600.Location = New System.Drawing.Point(899, 235)
        Me.Cat5600.Name = "Cat5600"
        Me.Cat5600.Size = New System.Drawing.Size(218, 110)
        Me.Cat5600.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat5600.TabIndex = 17
        Me.Cat5600.TabStop = False
        Me.Cat5600.Visible = False
        '
        'Cat6600
        '
        Me.Cat6600.Image = CType(resources.GetObject("Cat6600.Image"), System.Drawing.Image)
        Me.Cat6600.Location = New System.Drawing.Point(1123, 235)
        Me.Cat6600.Name = "Cat6600"
        Me.Cat6600.Size = New System.Drawing.Size(218, 110)
        Me.Cat6600.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat6600.TabIndex = 18
        Me.Cat6600.TabStop = False
        Me.Cat6600.Visible = False
        '
        'Cat1800
        '
        Me.Cat1800.Image = CType(resources.GetObject("Cat1800.Image"), System.Drawing.Image)
        Me.Cat1800.Location = New System.Drawing.Point(3, 351)
        Me.Cat1800.Name = "Cat1800"
        Me.Cat1800.Size = New System.Drawing.Size(218, 110)
        Me.Cat1800.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat1800.TabIndex = 19
        Me.Cat1800.TabStop = False
        Me.Cat1800.Visible = False
        '
        'Cat2800
        '
        Me.Cat2800.Image = CType(resources.GetObject("Cat2800.Image"), System.Drawing.Image)
        Me.Cat2800.Location = New System.Drawing.Point(227, 351)
        Me.Cat2800.Name = "Cat2800"
        Me.Cat2800.Size = New System.Drawing.Size(218, 110)
        Me.Cat2800.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat2800.TabIndex = 20
        Me.Cat2800.TabStop = False
        Me.Cat2800.Visible = False
        '
        'Cat3800
        '
        Me.Cat3800.Image = CType(resources.GetObject("Cat3800.Image"), System.Drawing.Image)
        Me.Cat3800.Location = New System.Drawing.Point(451, 351)
        Me.Cat3800.Name = "Cat3800"
        Me.Cat3800.Size = New System.Drawing.Size(218, 110)
        Me.Cat3800.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat3800.TabIndex = 21
        Me.Cat3800.TabStop = False
        Me.Cat3800.Visible = False
        '
        'Cat4800
        '
        Me.Cat4800.Image = CType(resources.GetObject("Cat4800.Image"), System.Drawing.Image)
        Me.Cat4800.Location = New System.Drawing.Point(675, 351)
        Me.Cat4800.Name = "Cat4800"
        Me.Cat4800.Size = New System.Drawing.Size(218, 110)
        Me.Cat4800.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat4800.TabIndex = 22
        Me.Cat4800.TabStop = False
        Me.Cat4800.Visible = False
        '
        'Cat5800
        '
        Me.Cat5800.Image = CType(resources.GetObject("Cat5800.Image"), System.Drawing.Image)
        Me.Cat5800.Location = New System.Drawing.Point(899, 351)
        Me.Cat5800.Name = "Cat5800"
        Me.Cat5800.Size = New System.Drawing.Size(218, 110)
        Me.Cat5800.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat5800.TabIndex = 23
        Me.Cat5800.TabStop = False
        Me.Cat5800.Visible = False
        '
        'Cat6800
        '
        Me.Cat6800.Image = CType(resources.GetObject("Cat6800.Image"), System.Drawing.Image)
        Me.Cat6800.Location = New System.Drawing.Point(1123, 351)
        Me.Cat6800.Name = "Cat6800"
        Me.Cat6800.Size = New System.Drawing.Size(218, 110)
        Me.Cat6800.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat6800.TabIndex = 24
        Me.Cat6800.TabStop = False
        Me.Cat6800.Visible = False
        '
        'Cat11000
        '
        Me.Cat11000.Image = CType(resources.GetObject("Cat11000.Image"), System.Drawing.Image)
        Me.Cat11000.Location = New System.Drawing.Point(3, 467)
        Me.Cat11000.Name = "Cat11000"
        Me.Cat11000.Size = New System.Drawing.Size(218, 110)
        Me.Cat11000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat11000.TabIndex = 25
        Me.Cat11000.TabStop = False
        Me.Cat11000.Visible = False
        '
        'Cat21000
        '
        Me.Cat21000.Image = CType(resources.GetObject("Cat21000.Image"), System.Drawing.Image)
        Me.Cat21000.Location = New System.Drawing.Point(227, 467)
        Me.Cat21000.Name = "Cat21000"
        Me.Cat21000.Size = New System.Drawing.Size(218, 110)
        Me.Cat21000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat21000.TabIndex = 26
        Me.Cat21000.TabStop = False
        Me.Cat21000.Visible = False
        '
        'Cat31000
        '
        Me.Cat31000.Image = CType(resources.GetObject("Cat31000.Image"), System.Drawing.Image)
        Me.Cat31000.Location = New System.Drawing.Point(451, 467)
        Me.Cat31000.Name = "Cat31000"
        Me.Cat31000.Size = New System.Drawing.Size(218, 110)
        Me.Cat31000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat31000.TabIndex = 27
        Me.Cat31000.TabStop = False
        Me.Cat31000.Visible = False
        '
        'Cat41000
        '
        Me.Cat41000.Image = CType(resources.GetObject("Cat41000.Image"), System.Drawing.Image)
        Me.Cat41000.Location = New System.Drawing.Point(675, 467)
        Me.Cat41000.Name = "Cat41000"
        Me.Cat41000.Size = New System.Drawing.Size(218, 110)
        Me.Cat41000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat41000.TabIndex = 28
        Me.Cat41000.TabStop = False
        Me.Cat41000.Visible = False
        '
        'Cat51000
        '
        Me.Cat51000.Image = CType(resources.GetObject("Cat51000.Image"), System.Drawing.Image)
        Me.Cat51000.Location = New System.Drawing.Point(899, 467)
        Me.Cat51000.Name = "Cat51000"
        Me.Cat51000.Size = New System.Drawing.Size(218, 110)
        Me.Cat51000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat51000.TabIndex = 29
        Me.Cat51000.TabStop = False
        Me.Cat51000.Visible = False
        '
        'Cat61000
        '
        Me.Cat61000.Image = CType(resources.GetObject("Cat61000.Image"), System.Drawing.Image)
        Me.Cat61000.Location = New System.Drawing.Point(1123, 467)
        Me.Cat61000.Name = "Cat61000"
        Me.Cat61000.Size = New System.Drawing.Size(218, 110)
        Me.Cat61000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cat61000.TabIndex = 30
        Me.Cat61000.TabStop = False
        Me.Cat61000.Visible = False
        '
        'pbarCatReveal
        '
        Me.pbarCatReveal.Location = New System.Drawing.Point(824, 165)
        Me.pbarCatReveal.Maximum = 60
        Me.pbarCatReveal.Name = "pbarCatReveal"
        Me.pbarCatReveal.Size = New System.Drawing.Size(100, 23)
        Me.pbarCatReveal.TabIndex = 3
        Me.pbarCatReveal.Visible = False
        '
        'tmrCatReveal
        '
        '
        'tmrCheckReveal
        '
        '
        'tmrPointValueBox
        '
        '
        'pbarPVB
        '
        Me.pbarPVB.Location = New System.Drawing.Point(705, 96)
        Me.pbarPVB.Maximum = 10
        Me.pbarPVB.Name = "pbarPVB"
        Me.pbarPVB.Size = New System.Drawing.Size(100, 23)
        Me.pbarPVB.TabIndex = 7
        Me.pbarPVB.Visible = False
        '
        'tmrCheckCatCleared
        '
        '
        'tmrRingIn
        '
        Me.tmrRingIn.Interval = 1
        '
        'tmrCheckIfRungIn
        '
        '
        'tmrCheckCurrentRound
        '
        '
        'tmrCheckRecogStopped
        '
        '
        'tmrCheckIfSelectCategory
        '
        '
        'rtbSeenClues
        '
        Me.rtbSeenClues.Location = New System.Drawing.Point(806, 263)
        Me.rtbSeenClues.Name = "rtbSeenClues"
        Me.rtbSeenClues.Size = New System.Drawing.Size(139, 121)
        Me.rtbSeenClues.TabIndex = 18
        Me.rtbSeenClues.Text = ""
        Me.rtbSeenClues.Visible = False
        '
        'rtbPointValues
        '
        Me.rtbPointValues.Location = New System.Drawing.Point(951, 263)
        Me.rtbPointValues.Name = "rtbPointValues"
        Me.rtbPointValues.Size = New System.Drawing.Size(139, 121)
        Me.rtbPointValues.TabIndex = 19
        Me.rtbPointValues.Text = ""
        Me.rtbPointValues.Visible = False
        '
        'categoryPanel
        '
        Me.categoryPanel.BackColor = System.Drawing.Color.Black
        Me.categoryPanel.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardySeason35
        Me.categoryPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.categoryPanel.ColumnCount = 6
        Me.categoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.categoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.categoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.categoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.categoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.categoryPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.categoryPanel.Controls.Add(Me.Cat61000, 5, 4)
        Me.categoryPanel.Controls.Add(Me.Cat51000, 4, 4)
        Me.categoryPanel.Controls.Add(Me.Cat41000, 3, 4)
        Me.categoryPanel.Controls.Add(Me.Cat31000, 2, 4)
        Me.categoryPanel.Controls.Add(Me.Cat21000, 1, 4)
        Me.categoryPanel.Controls.Add(Me.Cat11000, 0, 4)
        Me.categoryPanel.Controls.Add(Me.Cat6800, 5, 3)
        Me.categoryPanel.Controls.Add(Me.Cat5800, 4, 3)
        Me.categoryPanel.Controls.Add(Me.Cat4800, 3, 3)
        Me.categoryPanel.Controls.Add(Me.Cat3800, 2, 3)
        Me.categoryPanel.Controls.Add(Me.Cat2800, 1, 3)
        Me.categoryPanel.Controls.Add(Me.Cat1800, 0, 3)
        Me.categoryPanel.Controls.Add(Me.Cat6600, 5, 2)
        Me.categoryPanel.Controls.Add(Me.Cat5600, 4, 2)
        Me.categoryPanel.Controls.Add(Me.Cat4600, 3, 2)
        Me.categoryPanel.Controls.Add(Me.Cat3600, 2, 2)
        Me.categoryPanel.Controls.Add(Me.Cat2600, 1, 2)
        Me.categoryPanel.Controls.Add(Me.Cat1600, 0, 2)
        Me.categoryPanel.Controls.Add(Me.Cat6400, 5, 1)
        Me.categoryPanel.Controls.Add(Me.Cat5400, 4, 1)
        Me.categoryPanel.Controls.Add(Me.Cat4400, 3, 1)
        Me.categoryPanel.Controls.Add(Me.Cat3400, 2, 1)
        Me.categoryPanel.Controls.Add(Me.Cat2400, 1, 1)
        Me.categoryPanel.Controls.Add(Me.Cat1400, 0, 1)
        Me.categoryPanel.Controls.Add(Me.Cat6200, 5, 0)
        Me.categoryPanel.Controls.Add(Me.Cat5200, 4, 0)
        Me.categoryPanel.Controls.Add(Me.Cat4200, 3, 0)
        Me.categoryPanel.Controls.Add(Me.Cat3200, 2, 0)
        Me.categoryPanel.Controls.Add(Me.Cat2200, 1, 0)
        Me.categoryPanel.Controls.Add(Me.Cat1200, 0, 0)
        Me.categoryPanel.Location = New System.Drawing.Point(357, 328)
        Me.categoryPanel.Name = "categoryPanel"
        Me.categoryPanel.RowCount = 6
        Me.categoryPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.categoryPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.categoryPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.categoryPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.categoryPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.categoryPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.categoryPanel.Size = New System.Drawing.Size(1349, 600)
        Me.categoryPanel.TabIndex = 22
        '
        'catListBox
        '
        Me.catListBox.FormattingEnabled = True
        Me.catListBox.ItemHeight = 16
        Me.catListBox.Location = New System.Drawing.Point(1564, 359)
        Me.catListBox.Name = "catListBox"
        Me.catListBox.Size = New System.Drawing.Size(98, 84)
        Me.catListBox.TabIndex = 24
        Me.catListBox.Visible = False
        '
        'loadCatProgressBar
        '
        Me.loadCatProgressBar.Location = New System.Drawing.Point(1216, 526)
        Me.loadCatProgressBar.Name = "loadCatProgressBar"
        Me.loadCatProgressBar.Size = New System.Drawing.Size(41, 19)
        Me.loadCatProgressBar.Step = 5
        Me.loadCatProgressBar.TabIndex = 25
        Me.loadCatProgressBar.Visible = False
        '
        'pbarLoadCat
        '
        Me.pbarLoadCat.Location = New System.Drawing.Point(433, 286)
        Me.pbarLoadCat.Maximum = 2500
        Me.pbarLoadCat.Name = "pbarLoadCat"
        Me.pbarLoadCat.Size = New System.Drawing.Size(53, 21)
        Me.pbarLoadCat.TabIndex = 27
        Me.pbarLoadCat.Visible = False
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(455, 496)
        Me.TrackBar1.Maximum = 2000
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar1.TabIndex = 29
        Me.TrackBar1.Visible = False
        '
        'TrackBar2
        '
        Me.TrackBar2.Location = New System.Drawing.Point(914, 518)
        Me.TrackBar2.Maximum = 2000
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar2.TabIndex = 30
        Me.TrackBar2.Visible = False
        '
        'TrackBar3
        '
        Me.TrackBar3.Location = New System.Drawing.Point(922, 526)
        Me.TrackBar3.Maximum = 2000
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar3.TabIndex = 31
        Me.TrackBar3.Visible = False
        '
        'TrackBar4
        '
        Me.TrackBar4.Location = New System.Drawing.Point(930, 534)
        Me.TrackBar4.Maximum = 2000
        Me.TrackBar4.Name = "TrackBar4"
        Me.TrackBar4.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar4.TabIndex = 32
        Me.TrackBar4.Visible = False
        '
        'TrackBar5
        '
        Me.TrackBar5.Location = New System.Drawing.Point(938, 542)
        Me.TrackBar5.Maximum = 2000
        Me.TrackBar5.Name = "TrackBar5"
        Me.TrackBar5.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar5.TabIndex = 33
        Me.TrackBar5.Visible = False
        '
        'TrackBar6
        '
        Me.TrackBar6.Location = New System.Drawing.Point(946, 550)
        Me.TrackBar6.Maximum = 2000
        Me.TrackBar6.Name = "TrackBar6"
        Me.TrackBar6.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar6.TabIndex = 34
        Me.TrackBar6.Visible = False
        '
        'TrackBar7
        '
        Me.TrackBar7.Location = New System.Drawing.Point(954, 558)
        Me.TrackBar7.Maximum = 2000
        Me.TrackBar7.Name = "TrackBar7"
        Me.TrackBar7.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar7.TabIndex = 35
        Me.TrackBar7.Visible = False
        '
        'TrackBar8
        '
        Me.TrackBar8.Location = New System.Drawing.Point(962, 566)
        Me.TrackBar8.Maximum = 2000
        Me.TrackBar8.Name = "TrackBar8"
        Me.TrackBar8.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar8.TabIndex = 36
        Me.TrackBar8.Visible = False
        '
        'TrackBar9
        '
        Me.TrackBar9.Location = New System.Drawing.Point(970, 574)
        Me.TrackBar9.Maximum = 2000
        Me.TrackBar9.Name = "TrackBar9"
        Me.TrackBar9.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar9.TabIndex = 37
        Me.TrackBar9.Visible = False
        '
        'TrackBar10
        '
        Me.TrackBar10.Location = New System.Drawing.Point(978, 582)
        Me.TrackBar10.Maximum = 2000
        Me.TrackBar10.Name = "TrackBar10"
        Me.TrackBar10.Size = New System.Drawing.Size(104, 56)
        Me.TrackBar10.TabIndex = 38
        Me.TrackBar10.Visible = False
        '
        'clue
        '
        Me.clue.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.clue.clue = Nothing
        Me.clue.clueDisplay = "CLUE"
        Me.clue.clueType = Jeopardy.JeopardyController.clueType.Regular
        Me.clue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clue.imgClueLocation = Nothing
        Me.clue.Location = New System.Drawing.Point(0, 0)
        Me.clue.Name = "clue"
        Me.clue.Size = New System.Drawing.Size(1932, 1092)
        Me.clue.TabIndex = 39
        Me.clue.videoClueLocation = Nothing
        '
        'CategoryDisplay1
        '
        Me.CategoryDisplay1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.CategoryDisplay1.BackgroundImage = CType(resources.GetObject("CategoryDisplay1.BackgroundImage"), System.Drawing.Image)
        Me.CategoryDisplay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CategoryDisplay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CategoryDisplay1.Location = New System.Drawing.Point(0, 0)
        Me.CategoryDisplay1.Name = "CategoryDisplay1"
        Me.CategoryDisplay1.Size = New System.Drawing.Size(1932, 1092)
        Me.CategoryDisplay1.TabIndex = 40
        '
        'PointValueBox
        '
        Me.PointValueBox.BackColor = System.Drawing.Color.Transparent
        Me.PointValueBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PointValueBox.Location = New System.Drawing.Point(0, 0)
        Me.PointValueBox.Name = "PointValueBox"
        Me.PointValueBox.Size = New System.Drawing.Size(1932, 1092)
        Me.PointValueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PointValueBox.TabIndex = 42
        Me.PointValueBox.TabStop = False
        Me.PointValueBox.Visible = False
        '
        'categoryScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.JeopardyBoardBlank
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1932, 1092)
        Me.Controls.Add(Me.PointValueBox)
        Me.Controls.Add(Me.CategoryDisplay1)
        Me.Controls.Add(Me.clue)
        Me.Controls.Add(Me.pbarCatReveal)
        Me.Controls.Add(Me.TrackBar10)
        Me.Controls.Add(Me.TrackBar9)
        Me.Controls.Add(Me.TrackBar8)
        Me.Controls.Add(Me.TrackBar7)
        Me.Controls.Add(Me.TrackBar6)
        Me.Controls.Add(Me.TrackBar5)
        Me.Controls.Add(Me.TrackBar4)
        Me.Controls.Add(Me.TrackBar3)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.pbarLoadCat)
        Me.Controls.Add(Me.loadCatProgressBar)
        Me.Controls.Add(Me.catListBox)
        Me.Controls.Add(Me.rtbPointValues)
        Me.Controls.Add(Me.rtbSeenClues)
        Me.Controls.Add(Me.pbarPVB)
        Me.Controls.Add(Me.categoryPanel)
        Me.Controls.Add(Me.catPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "categoryScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.catPanel.ResumeLayout(False)
        CType(Me.Cat1200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat2200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat3200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat4200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat5200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat6200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat1400, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat2400, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat3400, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat4400, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat5400, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat6400, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat1600, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat2600, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat3600, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat4600, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat5600, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat6600, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat1800, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat2800, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat3800, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat4800, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat5800, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat6800, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat11000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat21000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat31000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat41000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat51000, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cat61000, System.ComponentModel.ISupportInitialize).EndInit()
        Me.categoryPanel.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PointValueBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents catPanel As FlowLayoutPanel
    Friend WithEvents Cat1200 As PictureBox
    Friend WithEvents Cat2200 As PictureBox
    Friend WithEvents Cat3200 As PictureBox
    Friend WithEvents Cat4200 As PictureBox
    Friend WithEvents Cat5200 As PictureBox
    Friend WithEvents Cat6200 As PictureBox
    Friend WithEvents Cat1400 As PictureBox
    Friend WithEvents Cat2400 As PictureBox
    Friend WithEvents Cat3400 As PictureBox
    Friend WithEvents Cat4400 As PictureBox
    Friend WithEvents Cat5400 As PictureBox
    Friend WithEvents Cat6400 As PictureBox
    Friend WithEvents Cat1600 As PictureBox
    Friend WithEvents Cat2600 As PictureBox
    Friend WithEvents Cat3600 As PictureBox
    Friend WithEvents Cat4600 As PictureBox
    Friend WithEvents Cat5600 As PictureBox
    Friend WithEvents Cat6600 As PictureBox
    Friend WithEvents Cat1800 As PictureBox
    Friend WithEvents Cat2800 As PictureBox
    Friend WithEvents Cat3800 As PictureBox
    Friend WithEvents Cat4800 As PictureBox
    Friend WithEvents Cat5800 As PictureBox
    Friend WithEvents Cat6800 As PictureBox
    Friend WithEvents Cat11000 As PictureBox
    Friend WithEvents Cat21000 As PictureBox
    Friend WithEvents Cat31000 As PictureBox
    Friend WithEvents Cat41000 As PictureBox
    Friend WithEvents Cat51000 As PictureBox
    Friend WithEvents Cat61000 As PictureBox
    Friend WithEvents pbarCatReveal As ProgressBar
    Friend WithEvents tmrCatReveal As Timer
    Friend WithEvents tmrCheckReveal As Timer
    Friend WithEvents tmrPointValueBox As Timer
    Friend WithEvents pbarPVB As ProgressBar
    Friend WithEvents tmrCheckCatCleared As Timer
    Friend WithEvents tmrRingIn As Timer
    Friend WithEvents tmrCheckIfRungIn As Timer
    Friend WithEvents tmrCheckCurrentRound As Timer
    Friend WithEvents tmrCheckRecogStopped As Timer
    Friend WithEvents tmrCheckIfSelectCategory As Timer
    Friend WithEvents rtbSeenClues As RichTextBox
    Friend WithEvents rtbPointValues As RichTextBox
    Friend WithEvents categoryPanel As TableLayoutPanel
    Friend WithEvents catListBox As ListBox
    Friend WithEvents loadCatProgressBar As ProgressBar
    Friend WithEvents pbarLoadCat As ProgressBar
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents TrackBar2 As TrackBar
    Friend WithEvents TrackBar3 As TrackBar
    Friend WithEvents TrackBar4 As TrackBar
    Friend WithEvents TrackBar5 As TrackBar
    Friend WithEvents TrackBar6 As TrackBar
    Friend WithEvents TrackBar7 As TrackBar
    Friend WithEvents TrackBar8 As TrackBar
    Friend WithEvents TrackBar9 As TrackBar
    Friend WithEvents TrackBar10 As TrackBar
    Friend WithEvents timeOutTimer As Timer
    Friend WithEvents playerTimeOutTimer As Timer
    Friend WithEvents clue As ClueDisplayScreen
    Friend WithEvents CategoryDisplay1 As CategoryDisplay
    Friend WithEvents cat1Title As CategoryTitle
    Friend WithEvents cat2Title As CategoryTitle
    Friend WithEvents cat3Title As CategoryTitle
    Friend WithEvents cat4Title As CategoryTitle
    Friend WithEvents cat5Title As CategoryTitle
    Friend WithEvents cat6Title As CategoryTitle
    Friend WithEvents PointValueBox As PictureBox
End Class
