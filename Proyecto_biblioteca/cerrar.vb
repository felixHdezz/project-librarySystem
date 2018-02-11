Public Class cerrar

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        principal.Hide()
        acceso.Show()
    End Sub

    Private Sub cerrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class