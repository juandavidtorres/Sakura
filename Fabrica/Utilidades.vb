Imports System.Reflection

Public Class Utilidades
    Public Shared Function LimpiarCadena(Mensaje As String) As String
        Try

            Mensaje = Mensaje.Replace(")", "")
            Mensaje = Mensaje.Replace("(", "")
            Mensaje = Mensaje.Replace("'", "")

        Catch ex As Exception

        End Try
        Return Mensaje
    End Function


    Public Shared Function ConvertirFomato(s As String) As DateTime
        Try
            Dim culture = System.Globalization.CultureInfo.CurrentCulture
            Dim fecha() As String = s.Split("/")
            If fecha.Length = 3 Then
                Dim fechaValidacion As DateTime = CDate(fecha(1) & "/" & fecha(0) & "/" & fecha(2))
                Return fechaValidacion
            Else
                Throw New Exception("Fecha Invalida, por favor verificar")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function ConcatenarHora(ByVal fecha As DateTime, hora As String) As DateTime
        Try

            Dim fechaSalida As DateTime
            If DateTime.TryParse((fecha & " " & hora).ToString(), fechaSalida) Then
                Return fechaSalida
            Else
                Throw New Exception("Verifique los datos de la fecha o la hora, existen valores invalidos")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function MesActual()
        Dim Numerodelmes As Integer
        Dim name As String
        Numerodelmes = Now.Month
        name = MonthName(Numerodelmes, False)
        Return name
    End Function

    Public Shared Function MesActual(Numerodelmes As Int32)
        Dim name As String
        name = MonthName(Numerodelmes, False)
        If name.Length > 4 Then
            name = name.Substring(0, 4)
        End If
        Return name
    End Function

   

    Public Shared Function DevolverFormatoFecha() As String
        Try
            Dim formato As String = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.Replace("yyyy", "yy")
            Return formato
        Catch ex As Exception
        End Try
    End Function
End Class
