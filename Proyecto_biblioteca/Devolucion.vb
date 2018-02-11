Imports MySql.Data.MySqlClient
Public Class Devolucion

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        principal.Show()
    End Sub

    Private Sub Devolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        Llenarcomboprestamo()
        Llenarcombolibro()
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM vista_devolucion_detalle", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "vista_devolucion_detalle")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "vista_devolucion_detalle"
        conn.Close()
    End Sub
    Sub Llenarcomboprestamo()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_prestamo"
        DataAdapter.Fill(DataSet)
        ComboBox1.DataSource = consultarDTsql(strsql)
        ComboBox1.DisplayMember = "clv_prestamo"
        ComboBox1.ValueMember = "clv_prestamo"
    End Sub
    Sub Llenarcombolibro()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_libros"
        DataAdapter.Fill(DataSet)
        ComboBox2.DataSource = consultarDTsql(strsql)
        ComboBox2.DisplayMember = "nombre_libro"
        ComboBox2.ValueMember = "clv_libro"
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM vista_devolucion_detalle where clv_devolucion like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "vista_devolucion_detalle")
            DataGridView1.DataSource = ds
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("clv_devolucion").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM vista_devolucion_detalle where clv_devolucion=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox2.Text = dt.Rows(0).Item("clv_devolucion")
                    MaskedTextBox1.Text = dt.Rows(0).Item("Fecha_devolucion")
                    ComboBox1.Text = dt.Rows(0).Item("clv_prestamo")
                    ComboBox2.Text = dt.Rows(0).Item("nombre_libro")
                    TextBox4.Text = dt.Rows(0).Item("observacion")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql, op As String
        Try
            op = "Insert"
            sql = "CAll porcedi_devolucion('" & op & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & TextBox4.Text & "')"
            conexion.comandosSQL(sql)
            MsgBox("El Registro se guardo Exitosamente", MessageBoxIcon.Information)
            mostrar()
            limpiar()
        Catch ex As MySqlException
            MsgBox("Error al guardar El Registro", MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql, op As String
        Try
            op = "delete"
            sql = "CAll porcedi_devolucion('" & op & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & TextBox4.Text & "')"
            conexion.comandosSQL(sql)
            MsgBox("El Registro se elimino  Exitosamente", MessageBoxIcon.Information)
            mostrar()
            limpiar()
        Catch ex As MySqlException
            MsgBox("Error al eliminar El Registro", MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql, op As String
        Try
            op = "Update"
            sql = "CAll porcedi_devolucion('" & op & "','" & TextBox2.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & TextBox4.Text & "')"
            conexion.comandosSQL(sql)
            MsgBox("El Registro se actuaizo  Exitosamente", MessageBoxIcon.Information)
            mostrar()
            limpiar()
        Catch ex As MySqlException
            MsgBox("Error al actualizar El Registro", MessageBoxIcon.Warning)
        End Try
    End Sub
    Sub limpiar()
        TextBox2.Text = ""
        MaskedTextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox4.Text = ""
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
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Dim cad As String
        'cad = "select * from " & ComboBox1.SelectedItem.ToString()
        'DataGridView1.DataSource = consultarDTsql(cad)
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
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

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim cad As String
        cad = "select * from " & ComboBox3.SelectedItem.ToString()
        DataGridView1.DataSource = consultarDTsql(cad)
    End Sub
End Class