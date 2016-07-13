Imports CapaDatos.DataAcces
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Linq
Imports System.Web.Script.Serialization

Public Class Inicio
    Inherits System.Web.UI.Page


    Public Function RecuperarListaAsistencia() As String
        Dim lista As New List(Of Fabrica.AsistenciaMes)
        Dim cadenaJson As String = ""
        Try
            Dim lector As IDataReader = Nothing
            Dim odatoas As New CapaDatos.DataAcces
            Dim oAsistente As Fabrica.AsistenciaMes
            lector = odatoas.RecuperarInformacionGrafico(Now, 4)

            While lector.Read
                oAsistente = New Fabrica.AsistenciaMes
                oAsistente.Cantidad = lector.Item("Cantidad").ToString
                oAsistente.Mes = Fabrica.Utilidades.MesActual(lector.Item("FechaServicio").ToString)
                lista.Add(oAsistente)
            End While
            lector.Close()
            lector.Dispose()
            Dim sr As New JavaScriptSerializer
            cadenaJson = sr.Serialize(lista)

        Catch ex As Exception
            Throw
        End Try
        Return cadenaJson
    End Function


    Public Function RecuperarDistribuccionServicio(tipo As Integer, rangodemes As Integer) As String
        Dim lista As New List(Of Fabrica.Distribucion)
        Dim cadenaJson As String = ""
        Try
            Dim lector As IDataReader = Nothing
            Dim odatoas As New CapaDatos.DataAcces
            Dim oPorcentaje As Fabrica.Distribucion
            lector = odatoas.RecuperarDiagramaPastelAsistencia(Now, tipo, rangodemes)

            While lector.Read
                oPorcentaje = New Fabrica.Distribucion
                oPorcentaje.Porcentaje = lector.Item("Cantidad").ToString
                oPorcentaje.Servicio = lector.Item("Descripcion").ToString
                lista.Add(oPorcentaje)
            End While
            lector.Close()
            lector.Dispose()
            Dim sr As New JavaScriptSerializer
            cadenaJson = sr.Serialize(lista)

        Catch ex As Exception
            Throw
        End Try
        Return cadenaJson
    End Function


    Public Function RecuperarTotalAsistentes() As String
        Dim TotalAsitentes As Integer = 0
        Try
            Dim odatoas As New CapaDatos.DataAcces
            TotalAsitentes = odatoas.RecuperarAsistenciaPorTipoyFecha(Now, 0)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
        Return TotalAsitentes
    End Function

    Public Function RecuperarTotalInfantes() As String
        Dim TotalAsitentes As Integer = 0
        Try
            Dim odatoas As New CapaDatos.DataAcces
            TotalAsitentes = odatoas.RecuperarAsistenciaPorTipoyFecha(Now, 5)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
        Return TotalAsitentes
    End Function


    Public Function RecuperarTotalVehiculos() As String
        Dim TotalVehiculos As Integer = 0
        Try
            Dim odatoas As New CapaDatos.DataAcces
            TotalVehiculos = odatoas.RecuperarAsistenciaPorTipoyFecha(Now, 1)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
        Return TotalVehiculos
    End Function


    Public Function RecuperarPromedioDominical() As String
        Dim Promedio As Integer = 0
        Try
            Dim odatoas As New CapaDatos.DataAcces
            Promedio = odatoas.RecuperarAsistenciaPorTipoyFecha(Now, 2)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
        Return Promedio
    End Function
    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub
    Public Function RecuperarPromedioSanidad() As String
        Dim Promedio As Integer = 0
        Try
            Dim odatoas As New CapaDatos.DataAcces
            Promedio = odatoas.RecuperarAsistenciaPorTipoyFecha(Now, 3)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
        Return Promedio
    End Function

    Protected Sub Inicio_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Try
        '    If Not Page.IsPostBack Then
        '        Dim funcion As String = "CargarGrafica(" & RecuperarListaAsistencia() & ");"
        '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "CargarGrafica", funcion, True)
        '    End If
        'Catch ex As Exception
        '    MostrarMensaje(ex.Message, True)
        'End Try
    End Sub
End Class