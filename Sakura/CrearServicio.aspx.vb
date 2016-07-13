Public Class CrearServicio
    Inherits System.Web.UI.Page

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub


    <System.Web.Services.WebMethod> _
    Public Shared Sub CrearServicio(IdHorario As Integer, Descripcion As String, Codigo As String, Comentario As String, TipoServicio As Integer)
        Try
            Dim odatos As New CapaDatos.DataAcces
            odatos.InsertarServicio(Codigo, Descripcion, Comentario, IdHorario, TipoServicio)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    <System.Web.Services.WebMethod> _
    Public Shared Sub ActualizarServicio(IdHorario As Integer, Descripcion As String, Codigo As String, Comentario As String, IdServicio As Integer, IdTipoServicio As Integer)
        Try
            Dim odatos As New CapaDatos.DataAcces
            odatos.ActualizarServicio(Codigo, Descripcion, Comentario, IdHorario, IdServicio, IdTipoServicio)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ActualizarGrilla()
        Try
            Dim odatos As New CapaDatos.DataAcces
            GrillaServicios.DataSource = odatos.RecuperarServicios().Tables(0)
            GrillaServicios.DataBind()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub


    Protected Sub CrearServicio_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim odatos As New CapaDatos.DataAcces
                If odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Administrador Or odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) Then
                    txtHorario.DataTextField = "Horario"
                    txtHorario.DataValueField = "IdHorario"
                    txtHorario.DataSource = odatos.RecuperarHorarios().Tables(0)
                    txtHorario.DataBind()

                    txtTipoServicio.DataTextField = "Descripcion"
                    txtTipoServicio.DataValueField = "IdTipoServicio"
                    txtTipoServicio.DataSource = odatos.RecuperarTiposdeServicios().Tables(0)
                    txtTipoServicio.DataBind()

                    GrillaServicios.DataSource = odatos.RecuperarServicios().Tables(0)
                    GrillaServicios.DataBind()
                Else
                    Response.Redirect("UsuarioNoPermitido.aspx", True)
                End If

            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub


    Protected Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        ActualizarGrilla()
    End Sub

    Protected Sub GrillaServicios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaServicios.RowCommand
        Try
            If e.CommandName = "Editar" Then
                Dim oDatos As New CapaDatos.DataAcces
                Dim oLector As System.Data.IDataReader = Nothing
                oLector = oDatos.RecuperarServicioPorId(e.CommandArgument)

                txtHorarioActualizar.DataTextField = "Horario"
                txtHorarioActualizar.DataValueField = "IdHorario"
                txtHorarioActualizar.DataSource = oDatos.RecuperarHorarios().Tables(0)
                txtHorarioActualizar.DataBind()

                txtTipoServicioActualizar.DataTextField = "Descripcion"
                txtTipoServicioActualizar.DataValueField = "IdTipoServicio"
                txtTipoServicioActualizar.DataSource = oDatos.RecuperarTiposdeServicios().Tables(0)
                txtTipoServicioActualizar.DataBind()

                While oLector.Read
                    txtTipoServicioActualizar.SelectedValue = oLector.Item("IdTipoServicio")
                    txtHorarioActualizar.SelectedValue = oLector.Item("IdHorario")
                    txtCodigoActualizar.DataBind()
                    txtDescripcionActulizar.Text = oLector.Item("Descripcion")
                    txtCodigoActualizar.Text = oLector.Item("Codigo")
                    txtComentarioEditar.Text = oLector.Item("Comentario")
                    HFIdServicio.Value = oLector.Item("IdServicio")
                End While

                oLector.Close()
                oLector.Dispose()

                updateModalActualizar.Update()
                Dim funcion As String = "OcultarModal('#DivActualizarGrilla','1');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "HideDiv", funcion, True)

            ElseIf e.CommandName = "Eliminar" Then
                Dim oDatos As New CapaDatos.DataAcces
                oDatos.EliminarServicio(CInt(e.CommandArgument))
                MostrarMensaje("Registro eliminado correctamente", False)
                ActualizarGrilla()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub
End Class