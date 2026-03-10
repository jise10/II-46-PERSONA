Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Namespace Utils

    Public Class DbHelper

        '==============================
        ' CADENA DE CONEXIÓN
        '==============================
        Private ReadOnly connectionString As String =
            ConfigurationManager.ConnectionStrings("II_46ConnectionString").ConnectionString


        '==============================
        ' CONEXIÓN
        '==============================
        Public Function GetConnection() As SqlConnection
            Return New SqlConnection(connectionString)
        End Function


        '==============================
        ' INSERT, UPDATE, DELETE
        '==============================
        Public Function ExecuteNonQuery(query As String,
                                        Optional parameters As List(Of SqlParameter) = Nothing,
                                        Optional isStoredProcedure As Boolean = False) As Integer

            If String.IsNullOrWhiteSpace(query) Then
                Throw New ArgumentException("La consulta no puede estar vacía.")
            End If

            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)

                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    If isStoredProcedure Then
                        cmd.CommandType = CommandType.StoredProcedure
                    End If

                    Try
                        conn.Open()
                        Return cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        Throw New Exception("Error al ejecutar el comando SQL: " & ex.Message)
                    End Try

                End Using
            End Using

        End Function


        '==============================
        ' EXECUTE QUERY (SELECT)
        ' Devuelve DataTable
        '==============================
        Public Function ExecuteQuery(query As String,
                                     Optional parameters As List(Of SqlParameter) = Nothing,
                                     Optional isStoredProcedure As Boolean = False) As DataTable

            If String.IsNullOrWhiteSpace(query) Then
                Throw New ArgumentException("La consulta no puede estar vacía.")
            End If

            Dim dt As New DataTable()

            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)

                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    If isStoredProcedure Then
                        cmd.CommandType = CommandType.StoredProcedure
                    End If

                    Try
                        conn.Open()

                        Using adapter As New SqlDataAdapter(cmd)
                            adapter.Fill(dt)
                        End Using

                    Catch ex As Exception
                        Throw New Exception("Error al ejecutar la consulta SQL: " & ex.Message)
                    End Try

                End Using
            End Using

            Return dt

        End Function


        '==============================
        ' EXECUTE SCALAR
        ' Devuelve un solo valor (Ej: ID)
        '==============================
        Public Function ExecuteScalar(query As String,
                                      Optional parameters As List(Of SqlParameter) = Nothing) As Object

            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)

                    If parameters IsNot Nothing Then
                        cmd.Parameters.AddRange(parameters.ToArray())
                    End If

                    Try
                        conn.Open()
                        Return cmd.ExecuteScalar()

                    Catch ex As Exception
                        Throw New Exception("Error al ejecutar ExecuteScalar: " & ex.Message)
                    End Try

                End Using
            End Using

        End Function


        '==============================
        ' CREAR PARÁMETRO
        '==============================
        Public Function CreateParameter(name As String, value As Object) As SqlParameter
            Return New SqlParameter(name, If(value IsNot Nothing, value, DBNull.Value))
        End Function


        '==============================
        ' EXECUTE READER
        ' Devuelve SqlDataReader
        '==============================
        Public Function ExecuteReader(query As String,
                                      Optional parameters As List(Of SqlParameter) = Nothing,
                                      Optional isStoredProcedure As Boolean = False) As SqlDataReader

            If String.IsNullOrWhiteSpace(query) Then
                Throw New ArgumentException("La consulta no puede estar vacía.")
            End If

            Dim conn As SqlConnection = GetConnection()
            Dim cmd As New SqlCommand(query, conn)

            If parameters IsNot Nothing Then
                cmd.Parameters.AddRange(parameters.ToArray())
            End If

            If isStoredProcedure Then
                cmd.CommandType = CommandType.StoredProcedure
            End If

            Try
                conn.Open()

                ' CommandBehavior.CloseConnection
                ' Hace que la conexión se cierre automáticamente cuando cierres el reader
                Return cmd.ExecuteReader(CommandBehavior.CloseConnection)

            Catch ex As Exception
                conn.Dispose()
                Throw New Exception("Error al ejecutar ExecuteReader: " & ex.Message)
            End Try

        End Function

    End Class


End Namespace
