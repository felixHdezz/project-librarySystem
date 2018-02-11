Imports System.Data
Imports System.IO
Imports MySql.Data.MySqlClient
Public Class Modulo_libros
    Public imagen As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        MaskedTextBox1.Text = ""
        TextBox5.Text = ""
        TextBox4.Text = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim op As String
        Try

            If TextBox2.Text = "" Or TextBox3.Text = "" Or MaskedTextBox1.Text = "" Or TextBox5.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Advertencia Usted no a llenado todo los campos", MessageBoxIcon.Warning)
            Else
                op = "Insert"
                sql = "CAll porcedi_libros('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & MaskedTextBox1.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "','" & TextBox4.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("El registro se inserto exitosamente", MessageBoxIcon.Information)
                mostrar()
            End If
        Catch ex As MySqlException
            MsgBox("Error al registrar el registro ", MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql, op As String
        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or MaskedTextBox1.Text = "" Or TextBox5.Text = "" Or TextBox4.Text = "" Then
                MsgBox("No a selecionado ningun registro para actualizar", MessageBoxIcon.Warning)
            Else
                op = "Update"
                sql = "CAll porcedi_libros('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & MaskedTextBox1.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "','" & TextBox4.Text & "')"
                conexion.comandosSQL(sql)
                MsgBox("Los datos se actualizaron correctamente", MessageBoxIcon.Information)
                mostrar()
            End If
        Catch ex As MySqlException
            MsgBox("Error al actualizar los datos", MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sql, op As String
        Try
            op = "delete"
            sql = "CAll porcedi_libros('" & op & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & MaskedTextBox1.Text & "','" & TextBox5.Text & "','" & ComboBox1.SelectedValue & "','" & ComboBox2.SelectedValue & "','" & ComboBox3.SelectedValue & "','" & TextBox4.Text & "')"
            conexion.comandosSQL(sql)
            MsgBox("la eliminacion  fue Exitosamente", MessageBoxIcon.Information, )
            mostrar()
        Catch ex As MySqlException
            MsgBox("Error al eliminar los datos", MessageBoxIcon.Error)
        End Try
    End Sub
    Sub LlenarCategoria()
        Dim strsql As String
        conectar()
        strsql = "SELECT * FROM tbl_clasificacion"
        DataAdapter.Fill(DataSet)
        ComboBox1.DataSource = consultarDTsql(strsql)
        ComboBox1.DisplayMember = "clasificacion"
        ComboBox1.ValueMember = "Clv_clasificacion"

    End Sub
    Sub llenar_editorial()
        Dim sql As String
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        sql = "select * from tbl_editorial"
        ComboBox2.DataSource = consultarDTsql(sql)
        ComboBox2.DisplayMember = "Editorial"
        ComboBox2.ValueMember = "Clv_editorial"
    End Sub
    Sub llenar_autor()
        Dim sql As String
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        sql = "select * from tbl_autores"
        ComboBox3.DataSource = consultarDTsql(sql)
        ComboBox3.DisplayMember = "Nombre"
        ComboBox3.ValueMember = "Clv_autor"
    End Sub

    Private Sub Modulo_libros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        llenar_autor()
        llenar_editorial()
        LlenarCategoria()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If
            Dim da As New MySqlDataAdapter("SELECT * FROM vista_libros where nombre_libro like '%" & (TextBox1.Text) & "%' or clv_libro  like '%" & (TextBox1.Text) & "%'", conn)
            Dim ds As New DataSet
            da.Fill(ds, "vista_libros")
            DataGridView1.DataSource = ds
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        catalogos.Show()
    End Sub
    Sub mostrar()
        If Not conn.State = ConnectionState.Open Then
            conn.Open()
        End If
        Dim dt As New MySqlDataAdapter("SELECT	*FROM vista_libros", conn)
        Dim ds As New DataSet
        dt.Fill(ds, "vista_libros")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "vista_libros"
        conn.Close()
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

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
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

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs)
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
    Private Sub DataGridView1_RowHeaderMouseClick1(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If DataGridView1.SelectedRows.Count > 0 Then
                    Dim intid As Integer = DataGridView1.SelectedRows(0).Cells("clv_libro").Value
                    Dim da As New MySqlDataAdapter("SELECT * FROM vista_libros where clv_libro=" & intid, conn)
                    Dim dt As New DataTable
                    da.Fill(dt)
                    TextBox2.Text = dt.Rows(0).Item("clv_libro")
                    TextBox3.Text = dt.Rows(0).Item("nombre_libro")
                    MaskedTextBox1.Text = dt.Rows(0).Item("fecha_edicion")
                    TextBox5.Text = dt.Rows(0).Item("numero_paginas")
                    ComboBox1.Text = dt.Rows(0).Item("clasificacion")
                    ComboBox2.Text = dt.Rows(0).Item("Editorial")
                    ComboBox3.Text = dt.Rows(0).Item("Autor")
                    TextBox4.Text = dt.Rows(0).Item("cantidad")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class