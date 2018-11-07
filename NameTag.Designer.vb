<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NameTag
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Korinna BT", 13.0!)
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(0, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(191, 78)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "NAME"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NameTag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.PodiumNameBKG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.lblName)
        Me.DoubleBuffered = True
        Me.Name = "NameTag"
        Me.Size = New System.Drawing.Size(191, 78)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblName As Label
End Class
