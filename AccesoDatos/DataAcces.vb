Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Data
Public Class DataAcces
    Inherits Fabrica.Disposable

    Public Sub InsertarVehiculoServicioTmp(Guid As String, IdTipoVehiculo As Int32, Cantidad As String)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarVehiculoServicioTmp"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Guid", DbType.String, Guid)
        db.AddInParameter(DataBaseCommand, "IdTipoVehiculo", DbType.Int32, IdTipoVehiculo)
        db.AddInParameter(DataBaseCommand, "Cantidad", DbType.Int32, Cantidad)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Sub InsertarUsuarioIglesia(Usuario As String, IdIglesia As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarUsuarioIglesia"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Usuario", DbType.String, Usuario)
        db.AddInParameter(DataBaseCommand, "IdIglesia", DbType.Int32, IdIglesia)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub



    Public Sub InsertarIglesia(Descripcion As String, IdPastor As Int32, Ubicacion As String, Telefono As String, IdCiudad As Int32)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarIglesia"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdPastor", DbType.Int32, IdPastor)
        db.AddInParameter(DataBaseCommand, "IdCiudad", DbType.Int32, IdCiudad)
        db.AddInParameter(DataBaseCommand, "Ubicacion", DbType.String, Ubicacion)
        db.AddInParameter(DataBaseCommand, "Telefono", DbType.String, Telefono)
        db.AddInParameter(DataBaseCommand, "Descripcion", DbType.String, Descripcion)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Function RecuperarIglesias() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarIglesias"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
       
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarUsuarioIglesia() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarUsuarioIglesia"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarUsuarios() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarUsuarios"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Sub InsertarAsistenteServicioTmp(Guid As String, IdTipoAsistente As Int32, Cantidad As String)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarAsistenteServicioTmp"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Guid", DbType.String, Guid)
        db.AddInParameter(DataBaseCommand, "IdTipoAsistente", DbType.Int32, IdTipoAsistente)
        db.AddInParameter(DataBaseCommand, "Cantidad", DbType.Int32, Cantidad)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub



    Public Sub InsertarServicioPorFecha(Guid As String, FechaServicio As DateTime, IdServicio As Int32, Comentario As String, IdUsuario As String, IdGrupoServidor As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarServicioPorFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Guid", DbType.String, Guid)
        db.AddInParameter(DataBaseCommand, "FechaServicio", DbType.DateTime, FechaServicio)
        db.AddInParameter(DataBaseCommand, "IdServicio", DbType.Int32, IdServicio)
        db.AddInParameter(DataBaseCommand, "IdUsuario ", DbType.String, IdUsuario)
        db.AddInParameter(DataBaseCommand, "Comentario", DbType.String, Comentario)
        db.AddInParameter(DataBaseCommand, "@IdGrupoServidor", DbType.Int32, IdGrupoServidor)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub



    Public Sub InsertarServicioEspecial(Guid As String, IdUsuario As String, Comentario As String, Descripcion As String, FechaInicio As DateTime, FechaFin As DateTime)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarServicioEspecial"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Guid", DbType.String, Guid)
        db.AddInParameter(DataBaseCommand, "FechaFin", DbType.DateTime, FechaFin)
        db.AddInParameter(DataBaseCommand, "FechaInicio", DbType.DateTime, FechaInicio)
        db.AddInParameter(DataBaseCommand, "Descripcion ", DbType.String, Descripcion)
        db.AddInParameter(DataBaseCommand, "IdUsuario ", DbType.String, Nothing)
        db.AddInParameter(DataBaseCommand, "Comentario", DbType.String, Comentario)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Function ValidarUsuarioEnRol(Usuario As String) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "ValidarUsuarioEnRol"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Usuario", DbType.String, Usuario)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteScalar(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Sub InsertarUsuarioEnRol(Usuario As String, IdRol As Integer, EsActivo As Boolean)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarUsuarioEnRol"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Usuario", DbType.String, Usuario)
        db.AddInParameter(DataBaseCommand, "IdRol", DbType.Int32, IdRol)
        db.AddInParameter(DataBaseCommand, "EsActivo", DbType.Boolean, EsActivo)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Sub InsertarHorario(HoraInicial As DateTime, HoraFinal As DateTime)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarHorario"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "HoraInicio", DbType.DateTime, HoraInicial)
        db.AddInParameter(DataBaseCommand, "HoraFin", DbType.DateTime, HoraFinal)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarInformacionGrafico(Fecha As DateTime, Tipo As Integer) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarAsistenciaPorTipoyFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Fecha", DbType.DateTime, Fecha)
        db.AddInParameter(DataBaseCommand, "Tipo", DbType.Int32, Tipo)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteReader(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarCiudades() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarCiudades"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function



    Public Function RecuperarDirectores() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarDirectores"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarDiagramaPastelAsistencia(Fecha As DateTime, Tipo As Integer, RangoMes As Integer) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarDiagramaPastelAsistencia"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Fecha", DbType.DateTime, Fecha)
        db.AddInParameter(DataBaseCommand, "Tipo", DbType.Int32, Tipo)
        db.AddInParameter(DataBaseCommand, "Meses", DbType.Int32, RangoMes)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteReader(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarAsistenciaPorTipoyFecha(Fecha As DateTime, Tipo As Integer) As Int32
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarAsistenciaPorTipoyFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Fecha", DbType.DateTime, Fecha)
        db.AddInParameter(DataBaseCommand, "Tipo", DbType.Int32, Tipo)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return CInt(db.ExecuteScalar(DataBaseCommand))
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Sub InsertarServicio(Codigo As String, Descripcion As String, Comentario As String, IdHorario As Int32, TipoServicio As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarServicio"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Codigo", DbType.String, Codigo)
        db.AddInParameter(DataBaseCommand, "Descripcion", DbType.String, Descripcion)
        db.AddInParameter(DataBaseCommand, "Horario", DbType.Int32, IdHorario)
        db.AddInParameter(DataBaseCommand, "Comentario", DbType.String, Comentario)
        db.AddInParameter(DataBaseCommand, "TipoServicio", DbType.Int32, TipoServicio)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Sub ActualizarServicio(Codigo As String, Descripcion As String, Comentario As String, IdHorario As Int32, IdServicio As Integer, IdTipoServicio As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "ActualizarServicio"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Codigo", DbType.String, Codigo)
        db.AddInParameter(DataBaseCommand, "Descripcion", DbType.String, Descripcion)
        db.AddInParameter(DataBaseCommand, "IdHorario", DbType.Int32, IdHorario)
        db.AddInParameter(DataBaseCommand, "Comentario", DbType.String, Comentario)
        db.AddInParameter(DataBaseCommand, "IdServicio", DbType.Int32, IdServicio)
        db.AddInParameter(DataBaseCommand, "IdTipoServicio", DbType.Int32, IdTipoServicio)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarTipoPersona(Descripcion As String)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "InsertarTipoPersona"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Descripcion", DbType.String, Descripcion)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Sub ActualizarTipoPersona(Descripcion As String, IdTipoPersona As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "ActualizarTipoPersona"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "Descripcion", DbType.String, Descripcion)
        db.AddInParameter(DataBaseCommand, "IdTipoPersona", DbType.Int32, IdTipoPersona)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub



    Public Sub ActualizarHorario(HoraInicial As DateTime, HoraFinal As DateTime, IdHorario As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "ActualizarHorario"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "HoraInicio", DbType.DateTime, HoraInicial)
        db.AddInParameter(DataBaseCommand, "HoraFin", DbType.DateTime, HoraFinal)
        db.AddInParameter(DataBaseCommand, "IdHorario", DbType.Int32, IdHorario)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Sub EliminarHorario(IdHorario As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "EliminarHorario"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdHorario", DbType.Int32, IdHorario)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Sub EliminarTipoPersona(IdHorario As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "EliminarTipoPersona"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdTipoPersona", DbType.Int32, IdHorario)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Public Sub EliminarServicio(IdServicio As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "EliminarServicio"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicio", DbType.Int32, IdServicio)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub



    Public Function RecuperarServicios() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarServicios"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function





    Public Function RecuperarServiciosPorFecha(FechaInicial As DateTime, FechaFinal As DateTime, IdServicio As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarServiciosPorFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        db.AddInParameter(DataBaseCommand, "FInicial", DbType.DateTime, FechaInicial)
        db.AddInParameter(DataBaseCommand, "FFinal", DbType.DateTime, FechaFinal)
        db.AddInParameter(DataBaseCommand, "IdServicio", DbType.Int64, IdServicio)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarServiciosEspecialesPorFecha(FechaInicial As DateTime, FechaFinal As DateTime, IdServicio As Integer) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarServiciosEspecialesPorFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        db.AddInParameter(DataBaseCommand, "FInicial", DbType.DateTime, FechaInicial)
        db.AddInParameter(DataBaseCommand, "FFinal", DbType.DateTime, FechaFinal)
        db.AddInParameter(DataBaseCommand, "IdServicio", DbType.Int64, IdServicio)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarTiposdeServicios() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarTiposdeServicios"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarGrupoServidor() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarGrupoServidor"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarHorarios() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarHorarios"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function



    Public Function RecuperarRoles() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarRoles"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarTiposDeAsistente() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarTiposDeAsistente"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarTiposDeVehiculo() As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarTiposDeVehiculo"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)

        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarHorarioPorId(IdHorario As Integer) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarHorarioPorId"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdHorario", DbType.Int32, IdHorario)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteReader(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarServicioPorId(IdHorario As Integer) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarServicioPorId"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicio", DbType.Int32, IdHorario)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteReader(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function



    Public Function RecuperarDetalleAsistenteServicioFecha(IdServicioFecha As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarDetalleAsistenteServicioFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicioFecha", DbType.Int64, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function



    Public Function RecuperarDetalleAsistenteServicioEspecial(IdServicioFecha As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarDetalleAsistenteServicioEspecial"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicioFecha", DbType.Int64, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarDetalleVehiculosServicioFecha(IdServicioFecha As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarDetalleVehiculosServicioFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicioFecha", DbType.Int64, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function



    Public Function RecuperarDetalleVehiculosServicioEspecial(IdServicioFecha As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarDetalleVehiculosServicioEspecial"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicioFecha", DbType.Int64, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteDataSet(DataBaseCommand).Tables(0)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarTipoDeAsistentePorId(IdHorario As Integer) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarTipoDeAsistentePorId"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdTipoPersona", DbType.Int32, IdHorario)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteReader(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function



    Public Sub EliminarServicioPorFecha(IdServicioFecha As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "EliminarServicioPorFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicioFecha", DbType.Int32, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub


    Public Sub EliminarServicioEspecialPorFecha(IdServicioFecha As Integer)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "EliminarServicioEspecialPorFecha"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicioFecha", DbType.Int32, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                db.ExecuteNonQuery(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Public Function RecuperarServicioFechaPorId(IdServicioFecha As Integer) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarServicioFechaPorId"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicioFecha", DbType.Int32, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteReader(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarServicioEspecialPorId(IdServicioFecha As Integer) As IDataReader
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim SqlCommand As String = "RecuperarServicioEspecialPorId"
        Dim DataBaseCommand As DbCommand = db.GetStoredProcCommand(SqlCommand)
        db.AddInParameter(DataBaseCommand, "IdServicio", DbType.Int32, IdServicioFecha)
        Using Connection As DbConnection = db.CreateConnection()
            Connection.Open()
            Try
                Return db.ExecuteReader(DataBaseCommand)
            Catch ex As Exception
                Throw
            Finally
                Connection.Close()
            End Try
        End Using
    End Function
End Class
