<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class testFormatting
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
        Me.components = New System.ComponentModel.Container()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.btnGet = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.ShadowLabel1 = New MJW.Guardian.RuntimeComponents.ShadowLabel(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTest
        '
        Me.lblTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTest.Location = New System.Drawing.Point(56, 86)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(404, 228)
        Me.lblTest.TabIndex = 0
        Me.lblTest.Text = "Label"
        Me.lblTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGet
        '
        Me.btnGet.Location = New System.Drawing.Point(209, 330)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(75, 23)
        Me.btnGet.TabIndex = 1
        Me.btnGet.Text = "Get "
        Me.btnGet.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(63, 65)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(397, 259)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = "TEXT"
        '
        'ElementHost1
        '
        Me.ElementHost1.Location = New System.Drawing.Point(55, 63)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(389, 249)
        Me.ElementHost1.TabIndex = 4
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Nothing
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Angle = 0!
        Me.ShadowLabel1.AutoSize = True
        Me.ShadowLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ShadowLabel1.EndColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ShadowLabel1.Font = New System.Drawing.Font("Swiss911W01-Compressed", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShadowLabel1.ForeColor = System.Drawing.Color.White
        Me.ShadowLabel1.Location = New System.Drawing.Point(103, 134)
        Me.ShadowLabel1.Name = "ShadowLabel1"
        Me.ShadowLabel1.ShadowColor = System.Drawing.Color.Black
        Me.ShadowLabel1.Size = New System.Drawing.Size(297, 116)
        Me.ShadowLabel1.StartColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ShadowLabel1.TabIndex = 5
        Me.ShadowLabel1.Text = "ASTRONOMICAL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      FIGURES"
        Me.ShadowLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ShadowLabel1.XOffset = 3.0!
        Me.ShadowLabel1.YOffset = 3.0!
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.PictureBox1.Image = Global.Jeopardy.My.Resources.Resources.CategoryTVFrame
        Me.PictureBox1.Location = New System.Drawing.Point(48, 76)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(401, 226)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(55, 63)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(389, 250)
        Me.WebBrowser1.TabIndex = 3
        '
        'testFormatting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 429)
        Me.Controls.Add(Me.ShadowLabel1)
        Me.Controls.Add(Me.btnGet)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ElementHost1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.lblTest)
        Me.Name = "testFormatting"
        Me.Text = "testFormatting"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTest As Label
    Friend WithEvents btnGet As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents ElementHost1 As Integration.ElementHost
    Friend WithEvents ShadowLabel1 As MJW.Guardian.RuntimeComponents.ShadowLabel
    Friend WithEvents PictureBox1 As PictureBox
End Class
