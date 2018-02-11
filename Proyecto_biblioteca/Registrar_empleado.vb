Imports MySql.Data.MySqlClient
Public Class Registrar_empleado
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SQL, op As String
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
                MsgBox("llene todo los campos", MessageBoxIcon.Warning)
            Else
                op = "Insert"
                SQL = "CALL porcedi_empleado('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox2.SelectedValue & "','" & TextBox8.Text & "')"
                conexion.comandosSQL(SQL)
                MsgBox("El registro se Guardo exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiar()
            End If
        Catch ex As Exception
            MsgBox("Error al guardar el registro", MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SQL, op As String
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
                MsgBox("selecione un registro para actualizar !!!", MessageBoxIcon.Warning)
            Else
                op = "Update"
                SQL = "CALL porcedi_empleado('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox2.SelectedValue & "','" & TextBox8.Text & "')"
                conexion.comandosSQL(SQL)
                MsgBox("El registro se actualizo exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiar()
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar el registro", MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim SQL, op As String
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
                MsgBox("selecione un registro para eliminar", MessageBoxIcon.Warning)
            Else
                op = "delete"
                SQL = "CALL porcedi_empleado('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox2.SelectedValue & "','" & TextBox8.Text & "')"
                conexion.comandosSQL(SQL)
                MsgBox("El registro se elimino exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiar()
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el registro", MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        principal.Show()
    End Sub
    Sub llenar()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_puestos"
        DataAdapter.Fill(DataSet)
        ComboBox2.DataSource = consultarDTsql(strsql)
        ComboBox2.DisplayMember = "Puesto"
        ComboBox2.ValueMember = "Clv_puesto"
    End Sub
    Sub llenardomi()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_domicilio"
        DataAdapter.Fill(DataSet)
        ComboBox1.DataSource = consultarDTsql(strsql)
        ComboBox1.DisplayMember = "domicilio"
        ComboBox1.ValueMember = "clv_domi"
    End Sub

    Private Sub Registrar_empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar()
        llenardomi()
        mostrar()
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM vie_empleado", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "vie_empleado")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "vie_empleado"
        conn.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM vie_empleado where nombre like '%" & (TextBox1.Text) & "%' or clv_empleado  like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "vie_empleado")
            DataGridView1.DataSource = ds

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("clv_empleado").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM vie_empleado where clv_empleado=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox2.Text = dt.Rows(0).Item("clv_empleado")
                    TextBox3.Text = dt.Rows(0).Item("Nombre")
                    TextBox4.Text = dt.Rows(0).Item("A_paterno")
                    TextBox5.Text = dt.Rows(0).Item("A_materno")
                    ComboBox1.Text = dt.Rows(0).Item("Domicilio")
                    TextBox6.Text = dt.Rows(0).Item("Telefono")
                    TextBox7.Text = dt.Rows(0).Item("E_mail")
                    ComboBox2.Text = dt.Rows(0).Item("Puesto")
                    TextBox8.Text = dt.Rows(0).Item("password")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
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
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox2.Text = ""
        TextBox8.Text = ""
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

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
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