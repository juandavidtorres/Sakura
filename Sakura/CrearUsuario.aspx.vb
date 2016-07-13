Public Class CrearUsuario
    Inherits System.Web.UI.Page

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Membership.CreateUser(txtusuario.Text, txtClave.Text, txtEmail.Text.Trim)
            Dim odatos As New CapaDatos.DataAcces
            odatos.InsertarUsuarioEnRol(txtusuario.Text.Trim(), txtrol.SelectedValue, txtestado.SelectedValue)
            LImpiarControles()
            MostrarMensaje("Registro exitoso", False)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Private Sub LImpiarControles()
        Try
            txtClave.Text = String.Empty
            txtclaveconfirmacion.Text = String.Empty
            txtEmail.Text = String.Empty
            txtusuario.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CrearUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim odatos As New CapaDatos.DataAcces
                If odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Administrador Then
                    txtrol.DataSource = odatos.RecuperarRoles()
                    txtrol.DataTextField = "Descripcion"
                    txtrol.DataValueField = "IdRol"
                    txtrol.DataBind()
                Else
                    Response.Redirect("UsuarioNoPermitido.aspx", True)
                End If

            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

End Class