Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Try
            txtErrror.Text = ""
            Dim odatos As New CapaDatos.DataAcces
            If Membership.ValidateUser(txtusuario.Text.Trim, txtPassword.Text) Then
                FormsAuthentication.RedirectFromLoginPage(txtusuario.Text.Trim, False)
            Else
                txtErrror.Text = "Credenciales Invalidas"
            End If

        Catch ex As Exception
            txtErrror.Text = ex.Message
        End Try
    End Sub
End Class