Public Class acceso
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim indice As Integer
        indice = ComboBox1.SelectedIndex
        If indice = 0 Then
            If (usuario(TextBox1.Text, TextBox2.Text)) Then
                Me.Hide()
                principal.BtnClinte.Visible = False
                principal.BtnEmpleado.Visible = False
                principal.BtnCatalogos.Visible = False
                principal.BtnInventario.Visible = False
                principal.BtnSeguridad.Visible = False
                principal.ToolStripSeparator1.Visible = False
                principal.ToolStripSeparator2.Visible = False
                principal.ToolStripSeparator3.Visible = False
                principal.ToolStripSeparator9.Visible = False
                principal.ToolStripSeparator7.Visible = False
                progressbar.ShowDialog()
            End If
        End If
        If indice = 1 Then
            If (usuario(TextBox1.Text, TextBox2.Text)) Then
                Me.Hide()
                progressbar.ShowDialog()

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class
