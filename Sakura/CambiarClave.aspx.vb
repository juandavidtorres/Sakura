Public Class CambiarClave
    Inherits System.Web.UI.Page
    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Txtusuario.Text = Membership.GetUser().UserName
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Membership.GetUser(Txtusuario.Text).ChangePassword(Membership.GetUser(Txtusuario.Text).ResetPassword, txtclaveconfirmar.Text.Trim())

            txtclaveconfirmar.Text = ""
            MostrarMensaje("Actualizacion Correcta", False)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub
End Class