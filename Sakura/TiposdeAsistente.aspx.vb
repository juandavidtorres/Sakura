Public Class TiposdeAsistente
    Inherits System.Web.UI.Page


    Public Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarValorAsincrono(ByVal Control As String, Valor As String)
        Try

            Dim funcion As String = "CargarValorAsincrono('#" & Control & "" & "','" & Valor & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "CargarValorAsincrono", funcion, True)
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        ActualizarTipoPersona(txtDescripcionEditar.Text.Trim(), HiddenIdTipoPersona.Value)
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub ProcesarInformacion(txtDescripcion As String)
        Dim oDatos As New CapaDatos.DataAcces
        Dim mensaje As String = ""
        Try

            If Not String.IsNullOrEmpty(txtDescripcion.Trim()) Then
                oDatos.InsertarTipoPersona(txtDescripcion.Trim())
            Else
                Throw New Exception("La descripcion es obligatoria")
            End If

        Catch ex As Exception
            Throw New Exception(Fabrica.Utilidades.LimpiarCadena(ex.Message))
        Finally
            oDatos.Dispose()
        End Try
    End Sub



    Protected Sub TiposdeAsistente_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim odatos As New CapaDatos.DataAcces
                If odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Administrador Then
                    GrillaTipoAsistente.DataSource = odatos.RecuperarTiposDeAsistente().Tables(0)
                    GrillaTipoAsistente.DataBind()
                Else
                    Response.Redirect("UsuarioNoPermitido.aspx", True)
                End If

            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub GrillaTipoAsistente_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaTipoAsistente.RowCommand
        Dim sb As New StringBuilder
        Try
            If e.CommandName = "Editar" Then

                Dim lector As IDataReader = Nothing
                Dim oDatos As New CapaDatos.DataAcces
                lector = oDatos.RecuperarTipoDeAsistentePorId(CInt(e.CommandArgument))
                While lector.Read()
                    txtDescripcionEditar.Text = lector.Item("Descripcion").ToString()
                    HiddenIdTipoPersona.Value = lector.Item("IdTipoAsistente").ToString
                End While
                lector.Close()
                lector.Dispose()
                oDatos.Dispose()

                sb.Clear()
                sb.Append("<script type='text/javascript'>")
                sb.Append("$('#form_modal').modal('show');")
                sb.Append("</script>")
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "DetailModalScript", sb.ToString(), False)
            ElseIf (e.CommandName = "Eliminar") Then
                Dim lector As IDataReader = Nothing
                Dim oDatos As New CapaDatos.DataAcces
                lector = oDatos.RecuperarTipoDeAsistentePorId(CInt(e.CommandArgument))
                While lector.Read()
                    lbldescripcion.Text = "Desea eliminar el registro (" & lector.Item("Descripcion").ToString() & ") ?"
                    HiddenIdTipoPersona.Value = lector.Item("IdTipoAsistente")
                End While

                lector.Close()
                lector.Dispose()
                oDatos.Dispose()
                sb.Clear()
                sb.Append("<script type='text/javascript'>")
                sb.Append("$('#form_modalEliminar').modal('show');")
                sb.Append("</script>")
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "BorrarModal", sb.ToString(), False)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ActualizarTipoPersona(txtDescripcion As String, IdPersona As Integer)
        Dim oDatos As New CapaDatos.DataAcces
        Dim mensaje As String = ""
        Try

            If Not String.IsNullOrEmpty(txtDescripcion.Trim()) Then
                oDatos.ActualizarTipoPersona(txtDescripcion.Trim(), IdPersona)
                GrillaTipoAsistente.DataSource = oDatos.RecuperarTiposDeAsistente().Tables(0)
                GrillaTipoAsistente.DataBind()
                MostrarMensaje("Registro actualizado con exito", False)
            Else
                Throw New Exception("La descripcion es obligatoria")
            End If

        Catch ex As Exception
            Throw New Exception(Fabrica.Utilidades.LimpiarCadena(ex.Message))
        Finally
            oDatos.Dispose()
        End Try
    End Sub

    Protected Sub btnActualizar_Click1(sender As Object, e As EventArgs) Handles btnActualizar.Click
        ActualizarTipoPersona(txtDescripcionEditar.Text, CInt(HiddenIdTipoPersona.Value))
    End Sub

    Protected Sub btnEliminar_Click1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Not HiddenIdTipoPersona.Value Is Nothing Then
                Dim oDatos As New CapaDatos.DataAcces
                oDatos.EliminarTipoPersona(CInt(HiddenIdTipoPersona.Value))
                MostrarMensaje("Registro eliminado correctamente", False)
                GrillaTipoAsistente.DataSource = oDatos.RecuperarTiposDeAsistente().Tables(0)
                GrillaTipoAsistente.DataBind()
                oDatos.Dispose()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub


End Class