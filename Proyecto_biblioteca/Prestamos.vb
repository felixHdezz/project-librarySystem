Imports MySql.Data.MySqlClient
Public Class Prestamo
    Private Sub Prestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        Llenarlibros()
        Llenarcliente()
        Llenarempleado()
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM vista_prestamo", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "vista_prestamo")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "vista_prestamo"
        conn.Close()
    End Sub
    Sub Llenarlibros()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_libros"
        DataAdapter.Fill(DataSet)
        ComboBox3.DataSource = consultarDTsql(strsql)
        ComboBox3.DisplayMember = "nombre_libro"
        ComboBox3.ValueMember = "clv_libro"
    End Sub
    Sub Llenarcliente()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM vie_cliente"
        DataAdapter.Fill(DataSet)
        ComboBox1.DataSource = consultarDTsql(strsql)
        ComboBox1.DisplayMember = "nombre"
        ComboBox1.ValueMember = "clv_cliente"
    End Sub
    Sub Llenarempleado()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM vie_empleado"
        DataAdapter.Fill(DataSet)
        ComboBox2.DataSource = consultarDTsql(strsql)
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "clv_empleado"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM vista_prestamo where Clv_prestamo_detalle like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "vista_prestamo")
            DataGridView1.DataSource = ds
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("Clv_prestamo_detalle").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM vista_prestamo where Clv_prestamo_detalle=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox2.Text = dt.Rows(0).Item("Clv_prestamo_detalle")
                    MaskedTextBox1.Text = dt.Rows(0).Item("Fecha_prestamo")
                    MaskedTextBox2.Text = dt.Rows(0).Item("Fecha_limite")
                    ComboBox1.Text = dt.Rows(0).Item("cliente")
                    ComboBox2.Text = dt.Rows(0).Item("empleado")
                    ComboBox3.Text = dt.Rows(0).Item("Libro")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql, op, cantidad As String
        Try
            If MaskedTextBox2.Text < MaskedTextBox1.Text Then
                MsgBox("error")
            Else
                Dim da As New MySqlDataAdapter("SELECT cantidad from tbl_libros where clv_libro=" & ComboBox3.Text, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                cantidad = dt.Rows(0).Item("cantidad")
                If cantidad = 0 Then
                    MsgBox("error")
                Else
                    op = "Insert"
                    sql = "CALL porcedi_prestamo('" & op & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & MaskedTextBox2.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "')"
                    conexion.comandosSQL(sql)
                    MsgBox("El Registro se guardo Exitosamente", MessageBoxIcon.Information)
                    mostrar()
                    limpiar()
                End If
            End If
        Catch ex As MySqlException
            MsgBox("Error al guardar El Registro", MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql, op As String
        Try
                op = "Update"
            sql = "CALL porcedi_prestamo('" & op & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & MaskedTextBox2.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "')"
            conexion.comandosSQL(sql)
                MsgBox("El Registro se actualizo exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiar()

        Catch ex As MySqlException
            MsgBox("Error al Actualizar el Registro", MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql, op As String
        Try
            op = "Delete"
            sql = "CALL porcedi_prestamo('" & op & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & MaskedTextBox2.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "')"
            conexion.comandosSQL(sql)
            MsgBox("La Eliminacion fue exitosamente", MessageBoxIcon.Information)
            mostrar()
            limpiar()
        Catch ex As MySqlException
            MsgBox("Error al eliminar el Registro", MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        principal.Show()
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Sub limpiar()
        TextBox2.Text = ""
        MaskedTextBox1.Text = ""
        MaskedTextBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
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