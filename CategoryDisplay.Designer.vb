<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoryDisplay
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
        Me.components = New System.ComponentModel.Container()
        Me.pboxJeopardyCard = New System.Windows.Forms.PictureBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.tmrRevealCategory = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pboxJeopardyCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pboxJeopardyCard
        '
        Me.pboxJeopardyCard.Image = Global.Jeopardy.My.Resources.Resources.JeopardyTitle1
        Me.pboxJeopardyCard.Location = New System.Drawing.Point(159, 99)
        Me.pboxJeopardyCard.Name = "pboxJeopardyCard"
        Me.pboxJeopardyCard.Size = New System.Drawing.Size(1737, 887)
        Me.pboxJeopardyCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxJeopardyCard.TabIndex = 0
        Me.pboxJeopardyCard.TabStop = False
        '
        'lblCategory
        '
        Me.lblCategory.AutoEllipsis = True
        Me.lblCategory.Font = New System.Drawing.Font("Swiss911W01-Compressed", 124.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.Color.Transparent
        Me.lblCategory.Location = New System.Drawing.Point(159, 99)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(1737, 887)
        Me.lblCategory.TabIndex = 21
        Me.lblCategory.Text = "CLUE"
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrRevealCategory
        '
        '
        'CategoryDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.CategoryScreenBKG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.pboxJeopardyCard)
        Me.Controls.Add(Me.lblCategory)
        Me.DoubleBuffered = True
        Me.Name = "CategoryDisplay"
        Me.Size = New System.Drawing.Size(1932, 1092)
        CType(Me.pboxJeopardyCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pboxJeopardyCard As PictureBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents tmrRevealCategory As Timer
End Class
