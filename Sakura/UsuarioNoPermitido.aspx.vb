Public Class UsuarioNoPermitido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Try
            Response.Redirect("DirectrizSeguridad.aspx", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Try
            Response.Redirect("Inicio.aspx", True)
        Catch ex As Exception

        End Try

    End Sub
End Class