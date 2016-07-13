Imports CapaDatos
Public Class Iglesia
    Inherits System.Web.UI.Page

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub


    <System.Web.Services.WebMethod()> _
    Public Shared Sub CrearIglesia(txtDescripcion As String, txtTelefono As String, IdDirector As Integer, IdCiudad As Integer, txtdireccion As String)
        Dim oDatos As New CapaDatos.DataAcces
        Dim mensaje As String = ""
        Try
            oDatos.InsertarIglesia(txtDescripcion, IdDirector, txtdireccion, txtTelefono, IdCiudad)
        Catch ex As Exception
            Throw New Exception(Fabrica.Utilidades.LimpiarCadena(ex.Message))
        Finally
            oDatos.Dispose()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim odatos As New DataAcces
                If Not odatos.ValidarUsuarioEnRol(Membership.GetUser.UserName) = Fabrica.Enumerados.TipoUsuario.SuperAdministrador Then
                    Response.Redirect("UsuarioNoPermitido.aspx", True)
                Else
                    txtciudad.DataSource = odatos.RecuperarCiudades
                    txtciudad.DataTextField = "Nombre"
                    txtciudad.DataValueField = "IdCiudad"
                    txtciudad.DataBind()
                    txtPastor.DataSource = odatos.RecuperarDirectores
                    txtPastor.DataTextField = "Nombre"
                    txtPastor.DataValueField = "IdPastor"
                    txtPastor.DataBind()
                End If
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Dim odatos As New DataAcces
            odatos.InsertarIglesia(txtnombre.Text.Trim(), CInt(txtPastor.SelectedValue), txtdireccion.Text.Trim, txttelefono.Text.Trim, CInt(txtciudad.SelectedValue))
            MostrarMensaje("Operacion exitosa", False)
            limpiar()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Private Sub limpiar()
        txtdireccion.Text = ""
        txtnombre.Text = ""
        txttelefono.Text = ""
    End Sub
    Protected Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        limpiar()

    End Sub
End Class