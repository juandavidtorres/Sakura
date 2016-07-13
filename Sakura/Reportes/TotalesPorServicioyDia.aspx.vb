Imports Microsoft.Reporting.WebForms

Public Class TotalesPorServicioyDia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ConfigurarReporte()
        End If
    End Sub

    Private Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub

    
    Public Sub ConfigurarReporte()
        Try
            Dim finicial As String = Session("Finicial")
            Dim ffinal As String = Session("Ffinal")
            Dim TipoServicio As String = Session("TipoServicio")
            Dim Texto As String = Session("Texto")


            Dim parametros(2) As ReportParameter
            parametros(0) = New ReportParameter("FInicial", finicial)
            parametros(1) = New ReportParameter("FFinal", ffinal)
            parametros(2) = New ReportParameter("TipoServicio", Texto)

            Dim objRpt As LocalReport = Visor.LocalReport
            Visor.LocalReport.ReportPath = "Reportes\RecuperarAsistenciaTotalDominical.rdlc"
            ObjectDataSource1.SelectParameters("FechaInicio").DefaultValue = finicial.Trim
            ObjectDataSource1.SelectParameters("FechaFin").DefaultValue = ffinal.Trim
            ObjectDataSource1.SelectParameters("IdTipoServicio").DefaultValue = TipoServicio
            Dim rds As New ReportDataSource("DataSetPromedio", ObjectDataSource1)
            Visor.LocalReport.ReportPath = "Reportes\RecuperarAsistenciaTotalDominical.rdlc"
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
            Response.AddHeader("content-disposition", "attachment; filename=" + "Totalasistenciapordia" + "." + extension)
            Response.BinaryWrite(data)
            Response.Flush()
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub

End Class