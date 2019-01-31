
Imports System.Web.Services

Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Private Sub validar_Click(sender As Object, e As EventArgs) Handles validar.Click
        Dim ruta As String = Server.MapPath("~/Handler.ashx")
        Dim client As New Net.WebClient
        Dim Response As String = client.DownloadString(ruta)
    End Sub
End Class
