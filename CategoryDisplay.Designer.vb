﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.tmrRevealCategory = New System.Windows.Forms.Timer(Me.components)
        Me.catBrowser = New System.Windows.Forms.WebBrowser()
        CType(Me.pboxJeopardyCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pboxJeopardyCard
        '
        Me.pboxJeopardyCard.Image = Global.Jeopardy.My.Resources.Resources.JEOPARDYLogo
        Me.pboxJeopardyCard.Location = New System.Drawing.Point(151, 99)
        Me.pboxJeopardyCard.Name = "pboxJeopardyCard"
        Me.pboxJeopardyCard.Size = New System.Drawing.Size(1745, 892)
        Me.pboxJeopardyCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxJeopardyCard.TabIndex = 0
        Me.pboxJeopardyCard.TabStop = False
        '
        'tmrRevealCategory
        '
        '
        'catBrowser
        '
        Me.catBrowser.Location = New System.Drawing.Point(151, 99)
        Me.catBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.catBrowser.Name = "catBrowser"
        Me.catBrowser.ScrollBarsEnabled = False
        Me.catBrowser.Size = New System.Drawing.Size(1745, 892)
        Me.catBrowser.TabIndex = 22
        '
        'CategoryDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.CategoryScreenBKG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.pboxJeopardyCard)
        Me.Controls.Add(Me.catBrowser)
        Me.DoubleBuffered = True
        Me.Name = "CategoryDisplay"
        Me.Size = New System.Drawing.Size(1932, 1092)
        CType(Me.pboxJeopardyCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pboxJeopardyCard As PictureBox
    Friend WithEvents tmrRevealCategory As Timer
    Friend WithEvents catBrowser As WebBrowser
End Class
