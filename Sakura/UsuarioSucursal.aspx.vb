
Imports CapaDatos
Public Class UsuarioSucursal
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
            If IsPostBack Then
                Dim odatos As New DataAcces
                txtentidad.DataSource = odatos.RecuperarIglesias
                txtentidad.DataTextField = "Descripcion"
                txtentidad.DataValueField = "IdIglesia"
                txtentidad.DataBind()

                txtusuario.DataSource = odatos.RecuperarUsuarios
                txtusuario.DataTextField = "UserName"
                txtusuario.DataValueField = "UserId"
                txtusuario.DataBind()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class