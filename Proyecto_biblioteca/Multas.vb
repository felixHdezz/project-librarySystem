Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class Multas

    Private Sub Multas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        Llenarprestamo()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql, op As String
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("llena todos los campos", MessageBoxIcon.Warning)
            Else
                op = "Insert"
                sql = "CALL porcedi_multas('" & op & "','" & TextBox1.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El Registro se Guardo Exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiarcajadetexto()
            End If
        Catch ex As Exception
            MsgBox("Error el registro ya existe en la base de datos", MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql, op As String
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("llena todos los campos", MessageBoxIcon.Warning)
            Else
                op = "Update"
                sql = "CALL porcedi_multas('" & op & "','" & TextBox1.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El Registro se Guardo Exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiarcajadetexto()
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar el registro", MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql, op As String
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("llena todos los campos", MessageBoxIcon.Warning)
            Else
                op = "delete"
                sql = "CALL porcedi_multas('" & op & "','" & TextBox1.Text & "','" & MaskedTextBox1.Text & "','" & ComboBox1.SelectedValue & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El Registro se Guardo Exitosamente", MessageBoxIcon.Information)
                mostrar()
                limpiarcajadetexto()
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el registro", MessageBoxIcon.Error)
        End Try
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM tbl_multas", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "tbl_multas")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_multas"
        conn.Close()
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("Clv_multa").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM tbl_multas where Clv_multa=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox1.Text = dt.Rows(0).Item("Clv_multa")
                    MaskedTextBox1.Text = dt.Rows(0).Item("Fecha_multa")
                    ComboBox1.Text = dt.Rows(0).Item("Clv_prestamo")
                    TextBox2.Text = dt.Rows(0).Item("Observacion")
                    TextBox3.Text = dt.Rows(0).Item("Monto")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM tbl_multas where Clv_multa like '%" & (TextBox4.Text) & "%' or Fecha_multa  like '%" & (TextBox4.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "tbl_multas")
            DataGridView1.DataSource = ds
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        principal.Show()
    End Sub
    Sub Llenarprestamo()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_prestamo"
        DataAdapter.Fill(DataSet)
        ComboBox1.DataSource = consultarDTsql(strsql)
        ComboBox1.DisplayMember = "Clv_prestamo"
        ComboBox1.ValueMember = "Clv_prestamo"
    End Sub
    Sub limpiarcajadetexto()
        TextBox1.Text = ""
        MaskedTextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class