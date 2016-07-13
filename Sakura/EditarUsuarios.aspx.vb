Public Class EditarUsuarios
    Inherits System.Web.UI.Page

    Public Function CustomGetAllUsers() As DataSet
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        dt = ds.Tables.Add("Users")

        Dim muc As MembershipUserCollection
        muc = Membership.GetAllUsers()

        dt.Columns.Add("Usuario", Type.[GetType]("System.String"))
        dt.Columns.Add("Email", Type.[GetType]("System.String"))
        dt.Columns.Add("FechaCreacion", Type.[GetType]("System.DateTime"))

        For Each mu As MembershipUser In muc
            Dim dr As DataRow
            dr = dt.NewRow()
            dr("Usuario") = mu.UserName
            dr("Email") = mu.Email
            dr("FechaCreacion") = mu.CreationDate
            dt.Rows.Add(dr)
        Next
        Return ds
    End Function

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim odatos As New CapaDatos.DataAcces
                If Not odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Administrador Then
                    Response.Redirect("UsuarioNoPermitido.aspx", True)
                Else
                    GrillaUsuarios.DataSource = CustomGetAllUsers().Tables("Users")
                    GrillaUsuarios.DataBind()
                End If

            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub GrillaUsuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaUsuarios.RowCommand
        Try

            If e.CommandName = "Editar" Then
                Txtusuario.Text = e.CommandArgument
                Contenedor.SetActiveView(ViewDetalle)
                ViewState("Usuario") = e.CommandArgument
                UpdateVista.Update()
            ElseIf e.CommandName = "Desbloquear" Then
                Dim usuario As MembershipUser
                Dim allUsers As MembershipUserCollection
                Dim llave As Object
                allUsers = Membership.FindUsersByName(e.CommandArgument)
                For Each var As MembershipUser In allUsers
                    If var.UserName = e.CommandArgument Then
                        llave = var.ProviderUserKey
                        usuario = Membership.GetUser(llave)
                        usuario.UnlockUser()
                    End If
                Next
                MostrarMensaje("Usuario desbloqueado Correctamente", False)
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btncancelarEdicion_Click(sender As Object, e As EventArgs) Handles btncancelarEdicion.Click
        Try

            Contenedor.ActiveViewIndex = -1
            UpdateVista.Update()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Membership.GetUser(ViewState("Usuario").ToString).ChangePassword(Membership.GetUser(ViewState("Usuario").ToString).ResetPassword, txtclave.Text.Trim())
            MostrarMensaje("Actualizacion Correcta", False)
            Contenedor.ActiveViewIndex = -1
            UpVista.Update()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

End Class