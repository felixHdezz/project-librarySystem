Imports MySql.Data.MySqlClient
Public Class Registrar_cliente
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        principal.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SQL, op As String
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
                MsgBox("Usted no ha llenado todo los campos", MessageBoxIcon.Warning)
            Else
                op = "Insert"
                SQL = "CALL porcedi_cliente('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                conexion.comandosSQL(SQL)
                MsgBox("El registro se Guardo exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiar()
            End If
        Catch ex As Exception
            MsgBox("Error al guardar el registro", MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SQL, op As String
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
                MsgBox("Usted no ha seleccionado ningun registro", MessageBoxIcon.Warning)
            Else
                op = "Update"
                SQL = "CALL porcedi_cliente('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                conexion.comandosSQL(SQL)
                MsgBox("El registro se Actualizo exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiar()
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar el registro", MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim SQL, op As String
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
                MsgBox("Usted no ha seleccionado ningun registro", MessageBoxIcon.Warning)
            Else
                op = "delete"
                SQL = "CALL porcedi_cliente('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                conexion.comandosSQL(SQL)
                MsgBox("El registro se elimino exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiar()
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el registro", MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Llenardomicilio()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_domicilio"
        DataAdapter.Fill(DataSet)
        ComboBox1.DataSource = consultarDTsql(strsql)
        ComboBox1.DisplayMember = "domicilio"
        ComboBox1.ValueMember = "clv_domi"

    End Sub

    Private Sub Registrar_usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Llenardomicilio()
        mostrar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM vie_cliente", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "vie_cliente")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "vie_cliente"
        conn.Close()
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("clv_cliente").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM vie_cliente where clv_cliente=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox2.Text = dt.Rows(0).Item("clv_cliente")
                    TextBox3.Text = dt.Rows(0).Item("Nombre")
                    TextBox4.Text = dt.Rows(0).Item("A_paterno")
                    TextBox5.Text = dt.Rows(0).Item("A_materno")
                    ComboBox1.Text = dt.Rows(0).Item("domicilio")
                    TextBox6.Text = dt.Rows(0).Item("telefono")
                    TextBox7.Text = dt.Rows(0).Item("E-mail")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM vie_cliente where nombre like '%" & (TextBox1.Text) & "%' or A_paterno  like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "vie_cliente")
            DataGridView1.DataSource = ds
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub limpiar()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
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

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
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
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
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
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
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