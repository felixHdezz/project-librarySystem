Imports System.Diagnostics
Public Class ayuda

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(e.Link.LinkData)
    End Sub

    Private Sub ayuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New LinkLabel.Link
        enlace = New LinkLabel.Link
        enlace.LinkData = "C:\Users\usuario\Documents\Visual Studio 2012\Projects\Proyecto_biblioteca\manual.pdf"
        LinkLabel1.Links.Add(enlace)
    End Sub
End Class