Imports MySql.Data.MySqlClient
Public Class Agregar_clasificacion
    Private Sub Agregar_clasificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM tbl_clasificacion", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "tbl_clasificacion")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_clasificacion"
        conn.Close()
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("Clv_clasificacion").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM tbl_clasificacion where Clv_clasificacion=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox2.Text = dt.Rows(0).Item("Clv_clasificacion")
                    TextBox3.Text = dt.Rows(0).Item("clasificacion")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM tbl_clasificacion where clasificacion like '%" & (TextBox1.Text) & "%' or Clv_clasificacion  like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "tbl_clasificacion")
            DataGridView1.DataSource = ds

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql, op As String
        Try
            If TextBox2.Text = "" Or TextBox2.Text = "" Then
                MsgBox("llene todos todo los campos", MessageBoxIcon.Warning)
            Else
                op = "Insert"
                sql = "CALL porcedi_clasificacion('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El registro  se Guardo Exitosamente", MessageBoxIcon.Information)
                mostrar()
            End If
        Catch ex As Exception
            MsgBox("Error el registro ya existe en la base de datos", MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql, op As String
        Try
            If TextBox2.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Selecione un registro para la actualizacion", MessageBoxIcon.Warning)
            Else
                op = "Update"
                sql = "CALL porcedi_clasificacion('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El reg seistro se Actualizo Exitosamente", MessageBoxIcon.Information)
                mostrar()
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar el registro", MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql, op As String
        Try
            If TextBox2.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Seleccione un registro para eliminar", MessageBoxIcon.Warning)
            Else
                op = "Delete"
                sql = "CALL porcedi_clasificacion('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("La Eliminacion Fue Exitosamente", MessageBoxIcon.Information)
                mostrar()
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el registro", MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        catalogos.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
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
End Class