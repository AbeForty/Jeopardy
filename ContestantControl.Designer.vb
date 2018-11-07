<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContestantControl
    Inherits System.Windows.Forms.Form
    'UserControl overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContestantControl))
        Me.flpContestants = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.lblNoContestants = New System.Windows.Forms.Label()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flpContestants
        '
        Me.flpContestants.AutoScroll = True
        Me.flpContestants.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.flpContestants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpContestants.Location = New System.Drawing.Point(0, 0)
        Me.flpContestants.Name = "flpContestants"
        Me.flpContestants.Size = New System.Drawing.Size(413, 407)
        Me.flpContestants.TabIndex = 33
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Image = Global.Jeopardy.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(379, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(34, 34)
        Me.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnClose.TabIndex = 34
        Me.btnClose.TabStop = False
        '
        'lblNoContestants
        '
        Me.lblNoContestants.BackColor = System.Drawing.Color.Transparent
        Me.lblNoContestants.Font = New System.Drawing.Font("Korinna BT", 15.0!)
        Me.lblNoContestants.ForeColor = System.Drawing.Color.White
        Me.lblNoContestants.Location = New System.Drawing.Point(40, 123)
        Me.lblNoContestants.Name = "lblNoContestants"
        Me.lblNoContestants.Size = New System.Drawing.Size(333, 157)
        Me.lblNoContestants.TabIndex = 35
        Me.lblNoContestants.Text = "NO CONTESTANTS HAVE BEEN CREATED YET. GO TO THE CONTESTANT MANAGER TO CREATE ONE." &
    ""
        Me.lblNoContestants.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblNoContestants.Visible = False
        '
        'ContestantControl
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(413, 407)
        Me.Controls.Add(Me.lblNoContestants)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.flpContestants)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ContestantControl"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpContestants As FlowLayoutPanel
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents lblNoContestants As Label
End Class
