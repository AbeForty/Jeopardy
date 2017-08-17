Public Class scoreHolder
    Private Sub scoreHolder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmScore.MdiParent = Me
        frmScore.Dock = DockStyle.Top
        frmScore.Show()
    End Sub
End Class