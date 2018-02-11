Imports MySql.Data.MySqlClient 
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Reportes

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cad As String
        cad = "select * from " & ComboBox1.SelectedItem.ToString()
        DataGridView1.DataSource = consultarDTsql(cad)
    End Sub
    Public Function GetColumnasSize() As Single()
        Dim values As Single() = New Single(DataGridView1.ColumnCount - 1) {}
        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            values(i) = CSng(DataGridView1.Columns(i).Width)
        Next
        Return values
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Intentar generar el documento.
            Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
            ' Path que guarda el reporte en el escritorio de windows (Desktop).
            Dim filename As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\Reporte.pdf"
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, file)
            doc.Open()
            ExportarDatosPDF(doc)
            doc.Close()
            Process.Start(filename)
        Catch ex As Exception
            MessageBox.Show("No se puede generar el documento PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ExportarDatosPDF(ByVal document As Document)
        'Se crea un objeto PDFTable con el numero de columnas del DataGridView. 
        Dim datatable As New PdfPTable(DataGridView1.ColumnCount)
        datatable.DefaultCell.Padding = 3
        Dim headerwidths As Single() = GetColumnasSize()
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 80
        datatable.DefaultCell.BorderWidth = 1
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        Dim encabezado As New Paragraph("           Sistema Bibliotecario del Ayuntamiento municiapal                                 REPORTE: " & ComboBox1.SelectedItem, New Font(Font.Name = "Tahoma", 20, Font.Bold))
        Dim texto As New Phrase(" Fecha de Reporte: " + Now.Date(), New Font(Font.Name = "Tahoma", 14, Font.Bold))
        'Se capturan los nombres de las columnas del DataGridView.
        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            datatable.AddCell(DataGridView1.Columns(i).HeaderText)
        Next
        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 1
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                datatable.AddCell((DataGridView1(j, i).Value).ToString)
            Next
            datatable.CompleteRow()
        Next
        'Se agrega etiquetas
        document.Add(encabezado)
        document.Add(texto)
        document.Add(datatable)
    End Sub
End Class
