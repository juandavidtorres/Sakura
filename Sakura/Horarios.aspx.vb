Public Class Horarios
    Inherits System.Web.UI.Page


    Dim sb As New StringBuilder

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Try

            If Not String.IsNullOrEmpty(Request("HoraInicial")) Then
                If Not String.IsNullOrEmpty(Request("HoraFinal")) Then
                    Dim FechaInicial As DateTime = CDate(Request("HoraInicial"))
                    Dim FechaFinal As DateTime = CDate(Request("HoraFinal"))
                    If FechaFinal < FechaInicial Then
                        MostrarMensaje("La hora hora final debe ser mayor a la inicial", True)
                    Else
                        Dim oDatos As New CapaDatos.DataAcces
                        FechaFinal = "01/01/1900 " & FechaFinal
                        FechaInicial = "01/01/1900 " & FechaInicial
                        oDatos.InsertarHorario(FechaInicial, FechaFinal)
                        MostrarMensaje("Horario registrado correctamente", False)
                    End If

                Else
                    MostrarMensaje("La hora final es obligatoria", True)
                End If
            Else
                MostrarMensaje("La hora inicial es obligatoria", True)
            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim oDatos As New CapaDatos.DataAcces
                If oDatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Administrador Or oDatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Cordinador Then
                    GrillaHorario.DataSource = oDatos.RecuperarHorarios().Tables(0)
                    GrillaHorario.DataBind()
                Else
                    Response.Redirect("UsuarioNoPermitido.aspx", True)
                End If

            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub


    Protected Sub GrillaHorario_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaHorario.RowCommand
        Try

            If e.CommandName = "Editar" Then

                Dim lector As IDataReader = Nothing
                Dim oDatos As New CapaDatos.DataAcces
                lector = oDatos.RecuperarHorarioPorId(CInt(e.CommandArgument))
                While lector.Read()
                    HoraIncioAct.Text = lector.Item("HoraInicio")
                    HoraFinalAct.Text = lector.Item("HoraFin")
                    HiddenIdHorario.Value = lector.Item("IdHorario")
                End While
                lector.Close()
                lector.Dispose()
                oDatos.Dispose()


                ScriptManager.RegisterClientScriptBlock(Me, ScriptManager1.GetType(), "ConfigurarCss", "ConfigurarCss();", True)

                sb.Clear()
                sb.Append("<script type='text/javascript'>")
                sb.Append("$('#form_modal').modal('show');")
                sb.Append("</script>")
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "DetailModalScript", sb.ToString(), False)


            ElseIf (e.CommandName = "Eliminar") Then
                Dim lector As IDataReader = Nothing
                Dim oDatos As New CapaDatos.DataAcces
                lector = oDatos.RecuperarHorarioPorId(CInt(e.CommandArgument))
                While lector.Read()
                    lblHorasaBorrar.Text = "Desea eliminar el horario que va desde las : " & lector.Item("HoraInicio").ToString() & " hasta las:  " & lector.Item("HoraFin") & " ?"
                    HiddenIdHorario.Value = lector.Item("IdHorario")
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
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub


    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs)
        Try
            If Not HiddenIdHorario.Value Is Nothing Then
                Dim oDatos As New CapaDatos.DataAcces
                oDatos.EliminarHorario(CInt(HiddenIdHorario.Value))
                MostrarMensaje("Horario eliminado correctamente", False)
                GrillaHorario.DataSource = oDatos.RecuperarHorarios().Tables(0)
                GrillaHorario.DataBind()
                sb.Clear()
                oDatos.Dispose()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(HoraIncioAct.Text) Then
                If Not String.IsNullOrEmpty(HoraFinalAct.Text) Then
                    Dim FechaInicial As DateTime
                    Dim FechaFinal As DateTime

                    If DateTime.TryParse(HoraIncioAct.Text, FechaInicial) Then
                        FechaInicial = HoraIncioAct.Text
                        If DateTime.TryParse(HoraFinalAct.Text, FechaFinal) Then
                            FechaFinal = HoraFinalAct.Text
                        Else
                            MostrarMensaje("Por favor digite una hora final valida en formato HH:MM AM/PM", True)
                            Return
                        End If
                    Else
                        MostrarMensaje("Por favor digite una hora incial valida en formato HH:MM AM/PM", True)
                        Return
                    End If


                    If FechaFinal < FechaInicial Then
                        MostrarMensaje("La hora hora final debe ser mayor a la inicial", True)
                    Else
                        Dim oDatos As New CapaDatos.DataAcces
                        FechaFinal = "01/01/1900 " & FechaFinal
                        FechaInicial = "01/01/1900 " & FechaInicial
                        oDatos.ActualizarHorario(FechaInicial, FechaFinal, CInt(HiddenIdHorario.Value))
                        oDatos.Dispose()
                        GrillaHorario.DataSource = oDatos.RecuperarHorarios().Tables(0)
                        GrillaHorario.DataBind()
                        sb.Clear()
                        MostrarMensaje("Actualizacion existosa", False)
                    End If
                Else
                    MostrarMensaje("La hora final es obligatoria", True)
                End If
            Else
                MostrarMensaje("La hora inicial es obligatoria", True)
            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

End Class