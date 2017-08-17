Imports System.ComponentModel
<DefaultEvent("Click")>
Public Class CategoryTitleLarge
    Dim displayBoolean As Boolean = True
    Public Property display As Boolean
        Get
            Return displayBoolean
        End Get
        Set(value As Boolean)
            displayBoolean = value
            If value = False Then
                lblCategory.Text = ""
            End If
        End Set
    End Property
    Public Property category As String
        Get
            Return lblCategory.Text
        End Get
        Set(value As String)
            lblCategory.Text = value
        End Set
    End Property
End Class
