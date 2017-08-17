<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClueDisplayScreen
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
        Me.lblClue = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblClue
        '
        Me.lblClue.AutoEllipsis = True
        Me.lblClue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClue.Font = New System.Drawing.Font("Korinna", 40.0!)
        Me.lblClue.ForeColor = System.Drawing.Color.Transparent
        Me.lblClue.Location = New System.Drawing.Point(0, 0)
        Me.lblClue.Name = "lblClue"
        Me.lblClue.Size = New System.Drawing.Size(1932, 1092)
        Me.lblClue.TabIndex = 20
        Me.lblClue.Text = "CLUE"
        Me.lblClue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblClue.UseMnemonic = False
        '
        'ClueDisplayScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Controls.Add(Me.lblClue)
        Me.Name = "ClueDisplayScreen"
        Me.Size = New System.Drawing.Size(1932, 1092)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblClue As Label
End Class
