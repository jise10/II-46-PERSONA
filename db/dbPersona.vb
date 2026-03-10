Imports System.Data.SqlClient
Imports PERSONA.Utils

Public Class dbPersona

    Private ReadOnly dbHelper As New DbHelper()


    ' CREAR PERSONA (DEVUELVE ID)

    Public Function CrearPersona(persona As Models.Persona) As Integer

        Dim sql As String =
            "INSERT INTO Personas (Nombre, Apellidos, Correo, Fecha_Nacimiento, Numero_Documento, Tipo_Documento)
             VALUES (@Nombre, @Apellidos, @Correo, @FechaNacimiento, @NumeroDocumento, @TipoDocumento);
             SELECT SCOPE_IDENTITY();"

        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", persona.Nombre),
            New SqlParameter("@Apellidos", persona.Apellidos),
            New SqlParameter("@Correo", persona.Correo),
            New SqlParameter("@FechaNacimiento", persona.FechaNacimiento),
            New SqlParameter("@NumeroDocumento", persona.NumeroDocumento),
            New SqlParameter("@TipoDocumento", persona.TipoDocummento)
        }

        ' Ejecutar y obtener ID
        Dim result As Object = dbHelper.ExecuteScalar(sql, parametros)

        Return Convert.ToInt32(result)

    End Function


    ' ELIMINAR PERSONA

    Public Function EliminarPersona(id As Integer) As Boolean

        Dim sql As String = "DELETE FROM Personas WHERE Id_Persona = @Id"

        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Id", id)
        }

        Return dbHelper.ExecuteNonQuery(sql, parametros) > 0

    End Function
    Public Function ConsultarPersona(id As Integer) As Models.Persona
        Dim sql As String = "SELECT * FROM Personas WHERE Id_Persona = @Id"
        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Id", id)
        }
        Dim reader As SqlDataReader = dbHelper.ExecuteReader(sql, parametros)
        If reader.Read() Then
            Dim persona As New Models.Persona() With {
                .Nombre = reader("Nombre").ToString(),
                .Apellidos = reader("Apellidos").ToString(),
                .Correo = reader("Correo").ToString(),
                .FechaNacimiento = Convert.ToDateTime(reader("Fecha_Nacimiento")),
                .NumeroDocumento = reader("Numero_Documento").ToString(),
                .TipoDocummento = reader("Tipo_Documento").ToString()
            }
            Return persona
        End If
        Return Nothing
    End Function



End Class
