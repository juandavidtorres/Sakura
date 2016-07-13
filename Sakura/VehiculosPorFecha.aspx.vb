Public Class VehiculosPorFecha
    Inherits System.Web.UI.Page

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub MonstrarPopUp(Pagina As String, Titulo As String)
        Try
            Dim funcion As String = "PopupCenter('" & Pagina & "', " & "'" & Titulo & "',900,500);"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "PopupCenter", funcion, True)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub
    Protected Sub Reportes_VehiculosPorFecha_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim oDatos As New CapaDatos.DataAcces
                Dim oTablas As Data.DataTable = oDatos.RecuperarTiposDeVehiculo().Tables(0)
                Dim filas As Data.DataRow = oTablas.NewRow
                filas(0) = "0"
                filas(1) = "Todos"
                oTablas.Rows.Add(filas)
                txtTipoVehiculo.DataSource = oTablas
                txtTipoVehiculo.DataTextField = "Descripcion"
                txtTipoVehiculo.DataValueField = "IdTipoVehiculo"
                txtTipoVehiculo.DataBind()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Try
            Session("Finicial") = txtFechaServicioInicial.Text.Trim
            Session("FFinal") = txtFechaServicioFinal.Text.Trim
            Session("IdTipoVehiculo") = txtTipoVehiculo.SelectedValue.ToString
            Session("Texto") = txtTipoVehiculo.SelectedItem.Text.ToString()


            If String.IsNullOrEmpty(txtformato.Text) Then
                MostrarMensaje("Debe escoger un formato para exportar la informacion", 1)
                Return
            End If
            Session("Formato") = txtformato.Text

            MonstrarPopUp("Reportes/VehiculosPorFechaPopUp.aspx", "Vehiculos por fecha")
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class