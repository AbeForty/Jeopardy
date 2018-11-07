<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContestantDisplay
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
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtPlayer = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.PictureBox()
        Me.NameTag1 = New Jeopardy.NameTag()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Korinna BT", 16.0!)
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(169, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(255, 90)
        Me.lblTotal.TabIndex = 7
        Me.lblTotal.Text = "$0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPlayer
        '
        Me.txtPlayer.Font = New System.Drawing.Font("Korinna BT", 13.8!)
        Me.txtPlayer.Location = New System.Drawing.Point(169, 29)
        Me.txtPlayer.Name = "txtPlayer"
        Me.txtPlayer.Size = New System.Drawing.Size(225, 35)
        Me.txtPlayer.TabIndex = 23
        Me.txtPlayer.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.Jeopardy.My.Resources.Resources.Delete
        Me.btnDelete.Location = New System.Drawing.Point(402, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(24, 23)
        Me.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.TabStop = False
        Me.btnDelete.Visible = False
        '
        'NameTag1
        '
        Me.NameTag1.BackColor = System.Drawing.Color.Transparent
        Me.NameTag1.BackgroundImage = Global.Jeopardy.My.Resources.Resources.PodiumNameBKG
        Me.NameTag1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NameTag1.contestantID = 0
        Me.NameTag1.enableClick = True
        Me.NameTag1.Location = New System.Drawing.Point(3, 3)
        Me.NameTag1.Name = "NameTag1"
        Me.NameTag1.Size = New System.Drawing.Size(160, 84)
        Me.NameTag1.TabIndex = 0
        '
        'ContestantDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.txtPlayer)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.NameTag1)
        Me.Name = "ContestantDisplay"
        Me.Size = New System.Drawing.Size(426, 90)
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NameTag1 As NameTag
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtPlayer As TextBox
    Friend WithEvents btnDelete As PictureBox
End Class
