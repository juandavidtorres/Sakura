Public Class RegistrarServicioPorFecha
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

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Tipo">Tipo 1 para crear grilla de Asistentes, un valor diferente de cero para la grilla vehiculos </param>
    ''' <remarks></remarks>
    Public Sub CrearTablaTemporal(Tipo As Integer)
        If Tipo = 1 Then
            tablaAsistente.Columns.Add("IdTipoAsistente")
            tablaAsistente.Columns.Add("Descripcion")
            tablaAsistente.Columns.Add("Cantidad")
        Else
            tablaVehiculos.Columns.Add("IdTipoVehiculo")
            tablaVehiculos.Columns.Add("Descripcion")
            tablaVehiculos.Columns.Add("Cantidad")
        End If
    End Sub

    Public Sub AgregarDatosTablas(Cantidad As String, Descripcion As String, IdTipoRegistro As String, EsUnVehiculo As Boolean)
        If EsUnVehiculo Then
            Try
                Dim existe As Boolean = False
                Dim fila As DataRow = tablaAsistente.NewRow

                For Each filaTabla As DataRow In tablaAsistente.Rows
                    If filaTabla("IdTipoAsistente") = IdTipoRegistro.ToString() Then
                        existe = True
                    End If
                Next

                If Not existe Then
                    fila("IdTipoAsistente") = IdTipoRegistro
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


    Protected Sub RegistrarServicioPorFecha_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim odatos As New CapaDatos.DataAcces
                If odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Administrador Or odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.Cordinador Then
                    txtTipoAsistente.DataSource = odatos.RecuperarTiposDeAsistente.Tables(0)
                    txtTipoAsistente.DataTextField = "Descripcion"
                    txtTipoAsistente.DataValueField = "IdTipoAsistente"
                    txtTipoAsistente.DataBind()

                    txtServicio.DataSource = odatos.RecuperarServicios
                    txtServicio.DataTextField = "Descripcion"
                    txtServicio.DataValueField = "IdServicio"
                    txtServicio.DataBind()

                    txtServidores.DataSource = odatos.RecuperarGrupoServidor().Tables(0)
                    txtServidores.DataTextField = "Nombre"
                    txtServidores.DataValueField = "Id"
                    txtServidores.DataBind()

                    txtTipodevehiculo.DataSource = odatos.RecuperarTiposDeVehiculo
                    txtTipodevehiculo.DataTextField = "Descripcion"
                    txtTipodevehiculo.DataValueField = "IdTipoVehiculo"
                    txtTipodevehiculo.DataBind()

                    tablaAsistente = New DataTable
                    tablaVehiculos = New DataTable
                    CrearTablaTemporal(1) ''Configuro el datatable de asistentes
                    CrearTablaTemporal(0) ''Configuro el datatable de vehiculos
                    ScriptManager.RegisterClientScriptBlock(Me, ScriptManagerCrearServicio.GetType(), "ConfigurarCss", "ConfigurarCss();", True)
                Else
                    Response.Redirect("UsuarioNoPermitido.aspx", True)
                End If
            Else
                tablaAsistente = ViewState("DataTableAsistente")
                tablaVehiculos = ViewState("DataTableVehiculo")
                ScriptManager.RegisterClientScriptBlock(Me, ScriptManagerCrearServicio.GetType(), "ConfigurarCss", "ConfigurarCss();", True)
            End If
            ViewState("DataTableAsistente") = tablaAsistente
            ViewState("DataTableVehiculo") = tablaVehiculos

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

    Protected Sub GrillaDetalleAsistente_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaDetalleAsistente.RowCommand
        Try

            If e.CommandName = "Eliminar" Then
                Dim listaux As New List(Of DataRow)

                For Each filaTabla As DataRow In tablaAsistente.Rows
                    If filaTabla("IdTipoAsistente") = e.CommandArgument.ToString() Then
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

    Protected Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Dim oDatos As New CapaDatos.DataAcces


            tablaAsistente = ViewState("DataTableAsistente")
            tablaVehiculos = ViewState("DataTableVehiculo")


            If tablaAsistente.Rows.Count > 0 Then
                If tablaVehiculos.Rows.Count > 0 Then
                    Dim Identificador As String = Guid.NewGuid.ToString()
                    For Each filaTabla As DataRow In tablaVehiculos.Rows
                        oDatos.InsertarVehiculoServicioTmp(Identificador, filaTabla("IdTipoVehiculo"), filaTabla("Cantidad"))
                    Next

                    For Each filaTabla As DataRow In tablaAsistente.Rows
                        oDatos.InsertarAsistenteServicioTmp(Identificador, filaTabla("IdTipoAsistente"), filaTabla("Cantidad"))
                    Next

                    Dim fecha As DateTime = Fabrica.Utilidades.ConvertirFomato(txtFechaServicio.Text.Trim)
                    oDatos.InsertarServicioPorFecha(Identificador, fecha, txtServicio.SelectedValue, txtComentarioServicio.Text.Trim(), Membership.GetUser().UserName, CInt(txtServidores.SelectedValue))
                    LimpiarControles()
                    MostrarMensaje("Registro exitoso", False)
                Else
                    MostrarMensaje("Ingrese el detalle de cantidad de vehiculos", True)
                End If
            Else
                MostrarMensaje("Ingrese el detalle de cantidad de asistentes", True)
            End If


        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Private Sub LimpiarControles()
        Try
            txtCantidadAsistente.Text = String.Empty
            txtCantidadVehiculo.Text = String.Empty
            tablaAsistente.Clear()
            tablaVehiculos.Clear()
            GrilladetalleVehiculo.DataSource = Nothing
            GrillaDetalleAsistente.DataSource = Nothing
            GrillaDetalleAsistente.DataBind()
            GrilladetalleVehiculo.DataBind()
            txtComentarioServicio.Text = String.Empty

        Catch ex As Exception
            MostrarMensaje(ex.Message, 1)
        End Try
    End Sub

    Protected Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            LimpiarControles()
        Catch ex As Exception
            MostrarMensaje(ex.Message, 1)
        End Try
    End Sub


End Class