<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CategoryTitle
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
        Me.catBrowserSmall = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'catBrowserSmall
        '
        Me.catBrowserSmall.IsWebBrowserContextMenuEnabled = False
        Me.catBrowserSmall.Location = New System.Drawing.Point(15, 12)
        Me.catBrowserSmall.MinimumSize = New System.Drawing.Size(20, 20)
        Me.catBrowserSmall.Name = "catBrowserSmall"
        Me.catBrowserSmall.ScrollBarsEnabled = False
        Me.catBrowserSmall.Size = New System.Drawing.Size(190, 101)
        Me.catBrowserSmall.TabIndex = 0
        Me.catBrowserSmall.Url = New System.Uri(JeopardyController.finalURL &
        "Resources\category.html", System.UriKind.Absolute)
        Me.catBrowserSmall.WebBrowserShortcutsEnabled = False
        '
        'CategoryTitle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.BackgroundImage = Global.Jeopardy.My.Resources.Resources.CategoryTVFrame
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.catBrowserSmall)
        Me.DoubleBuffered = True
        Me.Name = "CategoryTitle"
        Me.Size = New System.Drawing.Size(218, 125)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrCheckSize As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents catBrowserSmall As WebBrowser
End Class