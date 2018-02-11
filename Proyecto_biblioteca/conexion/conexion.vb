Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Module conexion
    Public cmd As New MySqlCommand

    Public conn As New MySqlConnection
    Public DataAdapter As New MySqlDataAdapter
    Public DataSet As New DataSet
    Public sql As String
    Public cm As New MySqlCommandBuilder
    Public datata As New DataTable
    Public connstr As String
    Public valua As Boolean = False
    Public da As New MySqlDataAdapter
    Public Sub conectar()
        If Not conn Is Nothing Then conn.Close()
        connstr = "server= localhost; user id= root; password=; database=bd_biblioteca_municipal;  pooling= false"
        Try
            conn = New MySqlConnection(connstr)
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Error de conexion con al servidor:" + ex.Message)
        End Try
    End Sub
    Function usuario(ByVal nombre As String, ByVal password As String)
        Dim OPC As Integer = 0
        Try
            conectar()
            sql = "SELECT * FROM vie_empleado  WHERE Nombre='" + nombre + "' and password='" + password + "'"
            DataAdapter = New MySqlDataAdapter(sql, conn)
            DataSet.Clear()
            DataAdapter.Fill(DataSet, "vie_empleado")
            If (DataSet.Tables("vie_empleado").Rows.Count() = 0) Then
                If OPC = 3 Then
                    MessageBox.Show("LOS NUMEROS DE INTENTOS ALCANZADOS.. NO PUEDE INGRESAR AL SISTEMA")
                    Application.Exit()
                Else
                    MessageBox.Show("ERROR.... LOS DATOS NO SON VALIDOS VERIFIQUE")
                End If
                OPC = OPC + 1
                valua = False
            Else
                MessageBox.Show("BIENVENIDO AL SISTEMA")
                valua = True
            End If
        Catch ex As Exception
        End Try
        Return (valua)
    End Function
    Public Function consultarDTsql(ByVal sql As String) As DataTable
        da = New MySqlDataAdapter(sql, conn)
        Dim data = New DataTable
        cm = New MySqlCommandBuilder(Da)
        Da.Fill(data)
        Return data
    End Function
    Public Sub comandosSQL(ByVal cadena As String)
        Dim da As New MySqlDataAdapter(cadena, conn)
        Dim data As New DataTable
        cm = New MySqlCommandBuilder(da)
        da.Fill(data)
    End Sub
    'Public Sub consul(ByRef sql As String, ByVal tabla As String)
    '    DataSet.Tables.Clear()
    '    DataAdapter = New MySqlDataAdapter(sql, conn)
    '    cm = New MySqlCommandBuilder(DataAdapter)
    '    DataAdapter.Fill(DataSet, tabla)
    'End Sub
    'Public Sub cargar(ByVal grid As DataGridView)
    '    grid.Columns.Clear()
    '    Dim check As DataGridViewCheckBoxColumn
    '    check = New DataGridViewCheckBoxColumn
    '    check.HeaderText = "Eliminar"
    '    check.Name = "Eliminar"
    '    check.Width = 60
    '    grid.Columns.Add(check)
    '    grid.Columns(grid.Columns.Count - 1).DisplayIndex = 0
    '    consul("SELECT * FROM  tbl_cliente", "tbl_cliente")
    '    grid.DataSource = DataSet.Tables("tbl_cliente")
    '    grid.Refresh()
    'End Sub
    'Public Sub eliminar(ByVal id As String)
    '    conn.Open()
    '    cmd = New MySqlCommand("Elimiar", conn)
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.Add("id", MySqlDbType.Byte).Value = id
    '    cmd.ExecuteNonQuery()
    '    conn.Close()
    'End Sub

End Module