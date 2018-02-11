Imports MySql.Data.MySqlClient
Imports System.IO.StreamWriter
Imports System.IO
Public Class Seguridad
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim desea_respaldar As Boolean
        desea_respaldar = True
        Cursor.Current = Cursors.WaitCursor
        If (Directory.Exists("c:\ Respaldo")) Then
            If (File.Exists("c:\ Respaldo\prueba.sql")) Then
                If (MessageBox.Show("Ya existe un respaldo desea sobreescribir el respaldo? ", "Respaldo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    File.Delete("c:\ Respaldo\prueba.bak")
                End If
            Else
                desea_respaldar = False
            End If
        End If
        Directory.CreateDirectory("c:\ Respaldo")
        If (desea_respaldar) Then
            Dim connect As New MySqlConnection
            Dim con As String
            Dim command As New MySqlCommand
            con = "server= localhost; user id= root; password=; database=bd_biblioteca_municipal;  pooling= false"
            connect = New MySqlConnection(con)
            connect.Open()
            command = New MySqlCommand("backup database  bd_biblioteca_municipal to disk =N'c:\ Respaldo\bd_biblioteca_municipal.sql' with Description=N'respaldo de la base de datos' noformat  init, name=n'bd_biblioteca_municipal, skip,norewind, nounload,stats=10", connect)
            command.ExecuteNonQuery()
            connect.Close()
            MessageBox.Show("El Respaldo de la base de datos fue realizado satisfactoriamente", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class