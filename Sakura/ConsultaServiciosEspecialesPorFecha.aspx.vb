Imports Fabrica

Public Class ConsultaServiciosEspecialesPorFecha
    Inherits System.Web.UI.Page

    Dim tablaAsistente As DataTable
    Dim tablaVehiculos As DataTable

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BuscarDatos()
        Try
            If Not String.IsNullOrEmpty(txtFechaServicioInicial.Text.Trim) Then
                If Not String.IsNullOrEmpty(txtFechaServicioFinal.Text.Trim) Then
                    Dim odatos As New CapaDatos.DataAcces
                    GrillaGeneral.DataSource = odatos.RecuperarServiciosEspecialesPorFecha(Fabrica.Utilidades.ConvertirFomato(txtFechaServicioInicial.Text.Trim()), Fabrica.Utilidades.ConvertirFomato(txtFechaServicioFinal.Text.Trim()), -1)
                    GrillaGeneral.DataBind()
                    Contenedor.SetActiveView(ViewDetalle)
                Else
                    MostrarMensaje("La fecha final es obligatoria", True)
                End If
            Else
                MostrarMensaje("La fecha inicial es obligatoria", True)
            End If


        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        BuscarDatos()
    End Sub


    Protected Sub ConsultaServiciosEspecialesPorFecha_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim odatos As New CapaDatos.DataAcces
        If Not IsPostBack Then
            Dim rol As Integer = odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName)
            If Not (rol = Fabrica.Enumerados.TipoUsuario.Administrador Or rol = Fabrica.Enumerados.TipoUsuario.Cordinador) Then
                Response.Redirect("UsuarioNoPermitido.aspx", True)
            End If
        End If
    End Sub

    Protected Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try

            Contenedor.ActiveViewIndex = -1
            UpVista.Update()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnAgregarDetalleVehiculo_Click(sender As Object, e As EventArgs) Handles btnAgregarvehiculos.Click
        Try

            If Not String.IsNullOrEmpty(txtCantidadVehiculo.Text.Trim()) Then
                Page.Validate("Vehiculos")
                AgregarDatosTablas(txtCantidadVehiculo.Text.Trim(), txtTipodevehiculo.SelectedItem.Text, txtTipodevehiculo.SelectedValue, False)
                txtCantidadVehiculo.Text = ""
                GrilladetalleVehiculo.DataSource = tablaVehiculos
                GrilladetalleVehiculo.DataBind()
            Else
                Throw New Exception("Digite la cantidad de vehiculos")
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub GrillaGeneral_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaGeneral.RowCommand
        Try
            If e.CommandName = "Editar" Then
                Dim odatos As New CapaDatos.DataAcces
                Dim oLector As System.Data.IDataReader = odatos.RecuperarServicioEspecialPorId(CInt(e.CommandArgument))
                If oLector.Read() Then


                    txtTipoAsistente.DataSource = odatos.RecuperarTiposDeAsistente.Tables(0)
                    txtTipoAsistente.DataTextField = "Descripcion"
                    txtTipoAsistente.DataValueField = "IdTipoAsistente"
                    txtTipoAsistente.DataBind()

                    txtTipodevehiculo.DataSource = odatos.RecuperarTiposDeVehiculo
                    txtTipodevehiculo.DataTextField = "Descripcion"
                    txtTipodevehiculo.DataValueField = "IdTipoVehiculo"
                    txtTipodevehiculo.DataBind()

                    txtFechaServicio.Text = oLector.Item("FechaServicio").ToString
                    txtComentarioServicio.Text = oLector.Item("Comentario").ToString()

                    txtDescripcionServicio.Text = oLector.Item("Descripcion").ToString

                    tablaAsistente = odatos.RecuperarDetalleAsistenteServicioEspecial(CDbl(e.CommandArgument))
                    tablaVehiculos = odatos.RecuperarDetalleVehiculosServicioEspecial(CDbl(e.CommandArgument))
                    ViewState("IdRegistroActualizar") = e.CommandArgument
                    ViewState("DataTableAsistente") = tablaAsistente
                    ViewState("DataTableVehiculo") = tablaVehiculos

                    GrillaDetalleAsistente.DataSource = tablaAsistente
                    GrillaDetalleAsistente.DataBind()
                    GrilladetalleVehiculo.DataSource = tablaVehiculos
                    GrilladetalleVehiculo.DataBind()


                    ScriptManager.RegisterClientScriptBlock(Me, ScriptManagerCrearServicio.GetType(), "ConfigurarCss", "ConfigurarCss();", True)
                    ScriptManager.RegisterClientScriptBlock(Me, ScriptManagerCrearServicio.GetType(), "SetValue", "SetValue('" & oLector.Item("HoraInicio").ToString() & "','" & oLector.Item("HoraFin").ToString() & "');", True)
                    Contenedor.SetActiveView(ViewAsistentes)
                    UpVista.Update()
                End If
                oLector.Close()
                oLector.Dispose()
                odatos.Dispose()
            ElseIf e.CommandName = "Eliminar" Then
                Dim odatos As New CapaDatos.DataAcces
                odatos.EliminarServicioEspecialPorFecha(e.CommandArgument)
                BuscarDatos()
                MostrarMensaje("Eliminacion exitosa", False)
                Contenedor.SetActiveView(ViewDetalle)
                UpVista.Update()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btncancelarEdicion_Click(sender As Object, e As EventArgs) Handles btnCancelarGeneral.Click
        Try
            Contenedor.ActiveViewIndex = -1
            Contenedor.SetActiveView(ViewDetalle)
            UpVista.Update()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Public Sub AgregarDatosTablas(Cantidad As String, Descripcion As String, IdTipoRegistro As String, EsUnaPersona As Boolean)
        If EsUnaPersona Then
            Try
                Dim existe As Boolean = False
                tablaAsistente = ViewState("DataTableAsistente")
                Dim fila As DataRow = tablaAsistente.NewRow

                For Each filaTabla As DataRow In tablaAsistente.Rows
                    If filaTabla("IdTipoPersona") = IdTipoRegistro.ToString() Then
                        existe = True
                    End If
                Next

                If Not existe Then
                    fila("IdTipoPersona") = IdTipoRegistro
                    fila("Descripcion") = Descripcion
                    fila("Cantidad") = Cantidad
                    tablaAsistente.Rows.Add(fila)
                    ViewState("DataTableAsistente") = tablaAsistente
                Else
                    Throw New Exception("Ya existe un registo para el tipos de asistente que desea agregar")
                End If

            Catch ex As Exception
                MostrarMensaje(ex.Message, True)
            End Try
        Else
            Try
                Dim existe As Boolean = False
                tablaVehiculos = ViewState("DataTableVehiculo")
                Dim fila As DataRow = tablaVehiculos.NewRow

                For Each filaTabla As DataRow In tablaVehiculos.Rows
                    If filaTabla("IdTipoVehiculo") = IdTipoRegistro.ToString() Then
                        existe = True
                    End If
                Next

                If Not existe Then
                    fila("IdTipoVehiculo") = IdTipoRegistro
                    fila("Descripcion") = Descripcion
                    fila("Cantidad") = Cantidad
                    tablaVehiculos.Rows.Add(fila)
                    ViewState("DataTableVehiculo") = tablaVehiculos
                Else
                    Throw New Exception("Ya existe un registo para el tipos de vehiculo que desea agregar")
                End If

            Catch ex As Exception
                MostrarMensaje(ex.Message, True)
            End Try
        End If
    End Sub
    Protected Sub GrillaDetalleAsistente_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaDetalleAsistente.RowCommand
        Try

            If e.CommandName = "Eliminar" Then
                tablaAsistente = ViewState("DataTableAsistente")
                Dim listaux As New List(Of DataRow)

                For Each filaTabla As DataRow In tablaAsistente.Rows
                    If filaTabla("IdTipoPersona") = e.CommandArgument.ToString() Then
                        Dim nuevafila As DataRow = filaTabla
                        listaux.Add(nuevafila)
                    End If
                Next

                For Each filaeliminar As DataRow In listaux
                    tablaAsistente.Rows.Remove(filaeliminar)
                Next

                ViewState("DataTableAsistente") = tablaAsistente
                GrillaDetalleAsistente.DataSource = tablaAsistente
                GrillaDetalleAsistente.DataBind()
            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub
    Protected Sub GrilladetalleVehiculo_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrilladetalleVehiculo.RowCommand
        Try

            If e.CommandName = "Eliminar" Then
                Dim listaux As New List(Of DataRow)
                tablaVehiculos = ViewState("DataTableVehiculo")


                For Each filaTabla As DataRow In tablaVehiculos.Rows
                    If filaTabla("IdTipoVehiculo") = e.CommandArgument.ToString() Then
                        Dim nuevafila As DataRow = filaTabla
                        listaux.Add(nuevafila)
                    End If
                Next

                For Each filaeliminar As DataRow In listaux
                    tablaVehiculos.Rows.Remove(filaeliminar)
                Next

                ViewState("DataTableVehiculo") = tablaVehiculos
                GrilladetalleVehiculo.DataSource = tablaVehiculos
                GrilladetalleVehiculo.DataBind()
            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnAgregarDetalleAsistente_Click(sender As Object, e As EventArgs) Handles btnAgregarDetalleAsistente.Click
        Try

            If Not String.IsNullOrEmpty(txtCantidadAsistente.Text.Trim()) Then
                Page.Validate("Asistentes")
                AgregarDatosTablas(txtCantidadAsistente.Text.Trim(), txtTipoAsistente.SelectedItem.Text, txtTipoAsistente.SelectedValue, True)
                txtCantidadAsistente.Text = String.Empty
                GrillaDetalleAsistente.DataSource = tablaAsistente
                GrillaDetalleAsistente.DataBind()
            Else
                Throw New Exception("Digite la cantidad de asistentes")
            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Dim oDatos As New CapaDatos.DataAcces


            tablaAsistente = ViewState("DataTableAsistente")
            tablaVehiculos = ViewState("DataTableVehiculo")
            If tablaAsistente.Rows.Count > 0 Then
                Dim Identificador As String = Guid.NewGuid.ToString()
                For Each filaTabla As DataRow In tablaVehiculos.Rows
                    oDatos.InsertarVehiculoServicioTmp(Identificador, filaTabla("IdTipoVehiculo"), filaTabla("Cantidad"))
                Next

                For Each filaTabla As DataRow In tablaAsistente.Rows
                    oDatos.InsertarAsistenteServicioTmp(Identificador, filaTabla("IdTipoPersona"), filaTabla("Cantidad"))
                Next

                oDatos.EliminarServicioEspecialPorFecha(CInt(ViewState("IdRegistroActualizar")))

                oDatos.InsertarServicioEspecial(Identificador, Nothing, txtComentarioServicio.Text.Trim(), txtDescripcionServicio.Text.Trim, Utilidades.ConcatenarHora(Utilidades.ConvertirFomato(txtFechaServicio.Text.Trim), txthorainicio.Text.Trim()), Utilidades.ConcatenarHora(Utilidades.ConvertirFomato(txtFechaServicio.Text.Trim), txthorafin.Text.Trim()))
                BuscarDatos()
                MostrarMensaje("Registro exitoso", False)
                Contenedor.SetActiveView(ViewDetalle)
                UpVista.Update()
            Else
                MostrarMensaje("Ingrese el detalle de cantidad de asistentes", True)
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try

    End Sub

End Class