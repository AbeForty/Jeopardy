<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HostToolbox
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
        Me.buttonDock = New System.Windows.Forms.FlowLayoutPanel()
        Me.editScoreBTN = New System.Windows.Forms.Button()
        Me.finalJeopardyBTN = New System.Windows.Forms.Button()
        Me.quitBTN = New System.Windows.Forms.Button()
        Me.buttonDock.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonDock
        '
        Me.buttonDock.BackColor = System.Drawing.Color.White
        Me.buttonDock.Controls.Add(Me.editScoreBTN)
        Me.buttonDock.Controls.Add(Me.finalJeopardyBTN)
        Me.buttonDock.Controls.Add(Me.quitBTN)
        Me.buttonDock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.buttonDock.Location = New System.Drawing.Point(0, 0)
        Me.buttonDock.Name = "buttonDock"
        Me.buttonDock.Size = New System.Drawing.Size(198, 89)
        Me.buttonDock.TabIndex = 0
        '
        'editScoreBTN
        '
        Me.editScoreBTN.BackgroundImage = Global.Jeopardy.My.Resources.Resources.editOptions
        Me.editScoreBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.editScoreBTN.Location = New System.Drawing.Point(3, 3)
        Me.editScoreBTN.Name = "editScoreBTN"
        Me.editScoreBTN.Size = New System.Drawing.Size(46, 46)
        Me.editScoreBTN.TabIndex = 0
        Me.editScoreBTN.UseVisualStyleBackColor = True
        '
        'finalJeopardyBTN
        '
        Me.finalJeopardyBTN.BackgroundImage = Global.Jeopardy.My.Resources.Resources.finalj_570x317
        Me.finalJeopardyBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.finalJeopardyBTN.Location = New System.Drawing.Point(55, 3)
        Me.finalJeopardyBTN.Name = "finalJeopardyBTN"
        Me.finalJeopardyBTN.Size = New System.Drawing.Size(75, 46)
        Me.finalJeopardyBTN.TabIndex = 1
        Me.finalJeopardyBTN.UseVisualStyleBackColor = True
        '
        'quitBTN
        '
        Me.quitBTN.BackgroundImage = Global.Jeopardy.My.Resources.Resources.Delete
        Me.quitBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.quitBTN.Location = New System.Drawing.Point(136, 3)
        Me.quitBTN.Name = "quitBTN"
        Me.quitBTN.Size = New System.Drawing.Size(46, 46)
        Me.quitBTN.TabIndex = 2
        Me.quitBTN.UseVisualStyleBackColor = True
        '
        'HostToolbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(198, 89)
        Me.ControlBox = False
        Me.Controls.Add(Me.buttonDock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HostToolbox"
        Me.Text = "Toolbox"
        Me.TopMost = True
        Me.buttonDock.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents buttonDock As FlowLayoutPanel
    Friend WithEvents editScoreBTN As Button
    Friend WithEvents finalJeopardyBTN As Button
    Friend WithEvents quitBTN As Button
End Class
