Public Class principal
    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        cerrar.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles BtnClinte.Click
        Registrar_cliente.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles BtnEmpleado.Click
        Registrar_empleado.ShowDialog()
    End Sub
    Private Sub BtnCatalogos_Click(sender As Object, e As EventArgs) Handles BtnCatalogos.Click
        catalogos.ShowDialog()
    End Sub

    Private Sub BtnSeguridad_Click(sender As Object, e As EventArgs) Handles BtnSeguridad.Click
        Seguridad.ShowDialog()
    End Sub

    Private Sub BtnPrestamo_Click(sender As Object, e As EventArgs) Handles BtnPrestamo.Click
        Prestamo.ShowDialog()
    End Sub

    Private Sub BtnDevolucion_Click(sender As Object, e As EventArgs) Handles BtnDevolucion.Click
        Devolucion.ShowDialog()
    End Sub
    Private Sub BtnMultas_Click(sender As Object, e As EventArgs) Handles BtnMultas.Click
        Multas.ShowDialog()
    End Sub

    Private Sub BtnInventario_Click(sender As Object, e As EventArgs) Handles BtnInventario.Click
        inventario.ShowDialog()
    End Sub

    Private Sub BtnReportes_Click(sender As Object, e As EventArgs) Handles BtnReportes.Click
        Reportes.ShowDialog()
    End Sub

    Private Sub BtnAyuda_Click(sender As Object, e As EventArgs) Handles BtnAyuda.Click
        ayuda.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = DateTime.Now.ToLongTimeString()
    End Sub

    Private Sub principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = DateTime.Now.ToLongDateString()
        Label3.Text = DateTime.Now.ToLongTimeString
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class