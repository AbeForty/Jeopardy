<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CategoryTitleLarge
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
        Me.components = New System.ComponentModel.Container()
        Me.tmrCheckSize = New System.Windows.Forms.Timer(Me.components)
        Me.catBrowser = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'catBrowser
        '
        Me.catBrowser.IsWebBrowserContextMenuEnabled = False
        Me.catBrowser.Location = New System.Drawing.Point(153, 100)
        Me.catBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.catBrowser.Name = "catBrowser"
        Me.catBrowser.Size = New System.Drawing.Size(1722, 911)
        Me.catBrowser.TabIndex = 1
        Me.catBrowser.WebBrowserShortcutsEnabled = False
        '
        'CategoryTitleLarge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.CategoryTVFrame
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.catBrowser)
        Me.DoubleBuffered = True
        Me.Name = "CategoryTitleLarge"
        Me.Size = New System.Drawing.Size(1932, 1092)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrCheckSize As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents catBrowser As WebBrowser
End Class
