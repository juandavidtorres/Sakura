
Partial Class MasterPagePrincipal
    Inherits System.Web.UI.MasterPage
    Public Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub



    Public Sub EliminarElemento(ByVal texto As String)
        Try
            Dim llave As New Random(1)
            Dim ValorLlave As String = llave.NextDouble().ToString

            texto = texto.Replace("'", "")
            Dim funcion As String = "EliminarElemento('" & texto & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), ValorLlave, funcion, True)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub
   
    Protected Sub MasterPagePrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim oDatos As New CapaDatos.DataAcces
                If Not oDatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Administrador Then
                    If oDatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Cordinador Then
                        EliminarElemento("Administracion|Usuarios")

                    ElseIf oDatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Usuario Then
                        EliminarElemento("Administracion|Ingresos|Usuarios")

                    End If
                End If
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class

