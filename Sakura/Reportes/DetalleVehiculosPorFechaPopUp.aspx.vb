Imports Microsoft.Reporting.WebForms

Public Class DetalleVehiculosPorFechaPopUp
    Inherits System.Web.UI.Page

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Reportes_AsistentesPorServicioPopUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ConfigurarReporte()
        End If
    End Sub
    Public Sub ConfigurarReporte()
        Try
            Dim finicial As String = Session("Finicial")
            Dim ffinal As String = Session("Ffinal")
            Dim Servicio As String = Session("TipoServicio")
            Dim Descripcion As String = Session("Texto")

            Dim objRpt As LocalReport = Visor.LocalReport
            Dim parametros(2) As ReportParameter
            parametros(0) = New ReportParameter("Finicial", finicial)
            parametros(1) = New ReportParameter("FFinal", ffinal)
            parametros(2) = New ReportParameter("TipoServicio", Descripcion)

            Visor.LocalReport.ReportPath = "Reportes\DetalleVehiculosPorFecha.rdlc"
            ObjectDataSource1.SelectParameters("FInicial").DefaultValue = finicial.Trim
            ObjectDataSource1.SelectParameters("FFinal").DefaultValue = ffinal.Trim
            ObjectDataSource1.SelectParameters("Servicio").DefaultValue = Servicio
            Dim rds As New ReportDataSource("DataSetVehiculos", ObjectDataSource1)
            Visor.LocalReport.ReportPath = "Reportes\DetalleVehiculosPorFecha.rdlc"
            Visor.ProcessingMode = ProcessingMode.Local
            Visor.LocalReport.DataSources.Clear()
            Visor.LocalReport.DataSources.Add(rds)
            objRpt.SetParameters(parametros)
            Dim formato As String = Session("Formato")
            Dim mimeType As String = String.Empty
            Dim encoding As String = String.Empty
            Dim extension As String = String.Empty
            Dim data() As Byte = Visor.LocalReport.Render(formato, Nothing, mimeType, encoding, extension, Nothing, Nothing)
            Response.Buffer = True
            Response.Clear()
            Response.ContentType = mimeType
            Response.AddHeader("content-disposition", "attachment; filename=" + "DetalleVehiculosPorFecha" + "." + extension)
            Response.BinaryWrite(data)
            Response.Flush()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

End Class