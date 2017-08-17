Public Class FormatLabel
    Inherits Label
    Private mGrowing As Boolean
    Public Sub New()
        Me.AutoSize = False
        Font = New Font("Open Sans", 12, FontStyle.Bold)
        ForeColor = Color.White
    End Sub
    Private Sub resizeLabel()
        If mGrowing Then
            Return
        End If
        Try
            mGrowing = True
            Dim sz As New Size(Me.Width, Int32.MaxValue)
            sz = TextRenderer.MeasureText(Me.Text, Me.Font, sz, TextFormatFlags.WordBreak Or TextFormatFlags.TextBoxControl)
            Me.Height = sz.Height
        Finally
            mGrowing = False
        End Try
    End Sub
    Private Sub shrinkText()
        'While Me.Width < System.Windows.Forms.TextRenderer.MeasureText(Me.Text, New Font(Me.Font.FontFamily, Me.Font.Size, Me.Font.Style)).Width
        '    Me.Font = New Font(Me.Font.FontFamily, Me.Font.Size - 0.5F, Me.Font.Style)
        'End While
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        'shrinkText()
        resizeLabel()
    End Sub
    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        'shrinkText()
        resizeLabel()
    End Sub
    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        shrinkText()
        resizeLabel()
    End Sub
End Class