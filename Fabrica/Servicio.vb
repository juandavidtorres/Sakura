Public Class Servicio
    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _IdHorario As String
    Public Property Horario() As String
        Get
            Return _IdHorario
        End Get
        Set(ByVal value As String)
            _IdHorario = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Private _Comentario As String
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal value As String)
            _Comentario = value
        End Set
    End Property
End Class
