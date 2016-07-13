Public Class DirectrizSeguridad
    Inherits System.Web.UI.Page

   
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FormsAuthentication.SignOut()
                Response.Redirect(FormsAuthentication.LoginUrl)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class