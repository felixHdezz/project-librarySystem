Imports MySql.Data.MySqlClient
Public Class inventario

    Private Sub inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM vista_invertario", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "vista_invertario")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "vista_invertario"
        conn.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM vista_invertario where Clave like '%" & (TextBox1.Text) & "%' or Libro  like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "vista_invertario")
            DataGridView1.DataSource = ds

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class