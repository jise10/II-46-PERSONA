Namespace Models
    Public Class Persona
        Private _nombre As String
        Private _apellidos As String
        Private _tipoDocummento As String
        Private _numeroDocumento As String
        Private _fechaNacimiento As Date
        Private _correo As String

        '  constructores de la clase Persona
        Public Sub New()
        End Sub



        Public Sub New(nombre As String, apellidos As String, tipoDocummento As String, correo As String)
            Me.Nombre = nombre
            Me.Apellidos = apellidos
            Me.TipoDocummento = tipoDocummento
            Me.Correo = correo
        End Sub

        Public Sub New(nombre As String, apellidos As String)
            Me.Nombre = nombre
            Me.Apellidos = apellidos
        End Sub

        Public Function Resumen() As String
            Return $"Nombre: {Nombre} {Apellidos} - {Correo}"
        End Function

        Public Property Nombre As String
            Get
                Return _nombre
            End Get
            Set(value As String)
                _nombre = value
            End Set
        End Property

        Public Property Apellidos As String
            Get
                Return _apellidos
            End Get
            Set(value As String)
                _apellidos = value
            End Set
        End Property

        Public Property TipoDocummento As String
            Get
                Return _tipoDocummento
            End Get
            Set(value As String)
                _tipoDocummento = value
            End Set
        End Property

        Public Property NumeroDocumento As String
            Get
                Return _numeroDocumento
            End Get
            Set(value As String)
                _numeroDocumento = value
            End Set
        End Property

        Public Property FechaNacimiento As Date
            Get
                Return _fechaNacimiento
            End Get
            Set(value As Date)
                _fechaNacimiento = value
            End Set
        End Property

        Public Property Correo As String
            Get
                Return _correo
            End Get
            Set(value As String)
                _correo = value
            End Set
        End Property
    End Class




End Namespace
