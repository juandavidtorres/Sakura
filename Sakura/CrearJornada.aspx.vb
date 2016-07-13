Public Class CrearJornada
    Inherits System.Web.UI.Page
    Dim TablaCantidad As DataTable

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CrearTablaTemporal()
        TablaCantidad.Columns.Add("IdServicio")
        TablaCantidad.Columns.Add("Descripcion")
        TablaCantidad.Columns.Add("Cantidad")
    End Sub


    Public Sub AgregarDatosTablas(Cantidad As String, Descripcion As String, IdServicio As Integer)

        Try
            Dim existe As Boolean = False
            Dim fila As DataRow = TablaCantidad.NewRow

            For Each filaTabla As DataRow In TablaCantidad.Rows
                If filaTabla("IdServicio") = IdServicio.ToString() Then
                    existe = True
                End If
            Next

            If Not existe Then
                fila("IdServicio") = IdServicio
                fila("Descripcion") = Descripcion
                fila("Cantidad") = Cantidad
                TablaCantidad.Rows.Add(fila)
                ViewState("DataTableCantidad") = TablaCantidad
            Else
                Throw New Exception("Ya existe un registo para el servicio que desea agregar")
            End If

        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                TablaCantidad = New DataTable
                CrearTablaTemporal()
                Dim odatos As New CapaDatos.DataAcces
                txtServicio.DataSource = odatos.RecuperarServicios
                txtServicio.DataTextField = "Descripcion"
                txtServicio.DataValueField = "IdServicio"
                txtServicio.DataBind()
                ScriptManager.RegisterClientScriptBlock(Me, ScriptManagerJornada.GetType(), "ConfigurarCss", "ConfigurarCss();", True)
            Else
                TablaCantidad = ViewState("DataTableCantidad")
            End If
            ViewState("DataTableCantidad") = TablaCantidad
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnguardarCantidad_Click(sender As Object, e As EventArgs) Handles btnguardarCantidad.Click
        Try
            If Not String.IsNullOrEmpty(txtcantidad.Text.Trim()) Then
                Page.Validate("Asistentes")
                AgregarDatosTablas(txtcantidad.Text.Trim(), txtServicio.SelectedItem.Text, CInt(txtServicio.SelectedValue))
                txtcantidad.Text = String.Empty
                GrillaDetalleAsistente.DataSource = TablaCantidad
                GrillaDetalleAsistente.DataBind()
            Else
                Throw New Exception("Digite la cantidad de asistentes")
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub
End Class