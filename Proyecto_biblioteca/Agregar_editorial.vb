Imports MySql.Data.MySqlClient
Public Class Agregar_editorial
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM tbl_editorial where Editorial like '%" & (TextBox1.Text) & "%' or Clv_editorial  like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "tbl_editorial")
            DataGridView1.DataSource = ds

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("Clv_editorial").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM tbl_editorial where Clv_editorial=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox2.Text = dt.Rows(0).Item("Clv_editorial")
                    TextBox3.Text = dt.Rows(0).Item("Editorial")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql, op As String
        Try
            If TextBox2.Text = "" Or TextBox2.Text = "" Then
                MsgBox("llene todo los Campos", MessageBoxIcon.Warning)
            Else
                op = "Insert"
                sql = "CALL porcedi_editoriales('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El Reistro se Guardo Exitosamente", MessageBoxIcon.Information)
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
                sql = "CALL porcedi_editoriales('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El Registro se Actualizo Exitosamente", MessageBoxIcon.Information)
                mostrar()
            End If
        Catch ex As Exception
            MsgBox("Error al Actualizar el Registro", MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql, op As String
        Try
            If TextBox2.Text = "" Or TextBox2.Text = "" Then
                MsgBox("seleccione un registro para la eliminacion", MessageBoxIcon.Warning)
            Else
                op = "Delete"
                sql = "CALL porcedi_editoriales('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("La Eliminacion Fue Exitosamente", MessageBoxIcon.Information)
                mostrar()
            End If
        Catch ex As Exception
            MsgBox("Error al Elimanar, el registro esta relacionado con otra tabla !", MessageBoxIcon.Error)
        End Try
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM tbl_editorial", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "tbl_editorial")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_editorial"
        conn.Close()
    End Sub

    Private Sub Agregar_editorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        catalogos.Show()
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class