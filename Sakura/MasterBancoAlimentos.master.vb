Public Class MasterBancoAlimentos
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub MostrarMensaje(ByVal texto As String, EsError As Boolean)
        Try
            texto = texto.Replace("'", "")
            Dim funcion As String = "Mensajes('" & texto & "" & "','" & IIf(EsError, "1", "0") & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Mensajes", funcion, True)
        Catch ex As Exception

        End Try
    End Sub



    Public Sub EliminarElemento(ByVal texto As String)
        Try
            Dim llave As New Random(1)
            Dim ValorLlave As String = llave.NextDouble().ToString

            texto = texto.Replace("'", "")
            Dim funcion As String = "EliminarElemento('" & texto & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), ValorLlave, funcion, True)
        Catch ex As Exception
            MostrarMensaje(ex.Message, True)
        End Try
    End Sub


End Class