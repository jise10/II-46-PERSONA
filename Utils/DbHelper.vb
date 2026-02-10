Imports System.Data.SqlClient

Public Class DbHelper


    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II_46ConnectionString").ConnectionString

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    Public Function CrearPersona(persona As Models.Persona) As Integer
        Dim Sql As String = "INSERT INTO Personas (Nombre, Apellidos, Correo, Fecha_Nacimiento, Numero_Documento, Tipo_Documento) " &
                        "VALUES (@Nombre, @Apellidos, @Correo, @FechaNacimiento, @NumeroDocumento, @TipoDocumento); " &
                        "SELECT SCOPE_IDENTITY();"


        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(Sql, conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre)
                cmd.Parameters.AddWithValue("@Apellidos", persona.Apellidos)
                cmd.Parameters.AddWithValue("@Correo", persona.Correo)
                cmd.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento)
                cmd.Parameters.AddWithValue("@NumeroDocumento", persona.NumeroDocumento)
                cmd.Parameters.AddWithValue("@TipoDocumento", persona.TipoDocummento)

                'Return cmd.ExecuteNonQuery() Devolver la cantidad de lineas insertadas
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
        Return 0


    End Function

End Class
