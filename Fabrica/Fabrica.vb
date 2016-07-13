Public Class Disposable
    Implements IDisposable

    Private _disposed As Boolean = False

    Public Property Disposed() As Boolean
        Get
            Return _disposed
        End Get
        Set(ByVal value As Boolean)
            _disposed = value
        End Set
    End Property

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.Disposed Then
            If disposing Then
                ' Insert code to free unmanaged resources.
            End If
            ' Insert code to free shared resources.
        End If
        Me.Disposed = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub
End Class
<Serializable()> _
Public Class AsistenciaMes
    Private _Mes As String
    Public Property Mes() As String
        Get
            Return _Mes
        End Get
        Set(ByVal value As String)
            _Mes = value
        End Set
    End Property
    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
        End Set
    End Property

End Class


<Serializable()> _
Public Class Distribucion
    Private _Servicio As String
    Public Property Servicio() As String
        Get
            Return _Servicio
        End Get
        Set(ByVal value As String)
            _Servicio = value
        End Set
    End Property
    Private _Cantidad As Decimal
    Public Property Porcentaje() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

End Class


