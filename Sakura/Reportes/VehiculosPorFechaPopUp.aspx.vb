Imports Microsoft.Reporting.WebForms
Imports System.Reflection

Public Class VehiculosPorFechaPopUp
    Inherits System.Web.UI.Page

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Reportes_VehiculosPorFechaPopUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''DisableUnwantedExportFormat(Visor, "PDF")
    End Sub

    Public Sub DisableUnwantedExportFormat(ReportViewerID As ReportViewer, strFormatName As String)
        Try
            Dim info As FieldInfo
            For Each extension As RenderingExtension In ReportViewerID.LocalReport.ListRenderingExtensions
                If extension.Name = strFormatName Then
                    info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub
    Public Sub ConfigurarReporte()
        Try
            Dim finicial As String = Session("Finicial")
            Dim ffinal As String = Session("Ffinal")
            Dim TipoVehiculo = Session("IdTipoVehiculo")
            Dim texto As String = Session("Texto")
            Dim objRpt As LocalReport = Visor.LocalReport

            Dim parametros(2) As ReportParameter
            parametros(0) = New ReportParameter("Finicial", finicial)
            parametros(1) = New ReportParameter("FFinal", ffinal)
            parametros(2) = New ReportParameter("TipoVehiculo", texto)

            Visor.LocalReport.ReportPath = "Reportes\VehiculosPorFecha.rdlc"
            ObjectDataSource2.SelectParameters("FInicial").DefaultValue = finicial.Trim
            ObjectDataSource2.SelectParameters("FFinal").DefaultValue = ffinal.Trim
            ObjectDataSource2.SelectParameters("TipoVehiculo").DefaultValue = TipoVehiculo
            Dim rds As New ReportDataSource("DataSetVehiculoGrafico", ObjectDataSource2)
            Visor.LocalReport.ReportPath = "Reportes\VehiculosPorFecha.rdlc"
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
            Response.AddHeader("content-disposition", "attachment; filename=" + "VehiculosPorFecha" + "." + extension)
            Response.BinaryWrite(data)
            Response.Flush()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ConfigurarReporte()
            End If
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

End Class