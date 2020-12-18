Module Personal
End Module

''' <summary>
''' La clase persona contiene los valores básicos que conciernen a una persona, no incluye ningún tipo de dato laboral
''' </summary>
Public Class Persona
    Public Nombres As String
    Public Apellido As String
    Public DNI As Long
    Public CUIT As String
    Public SEXO As String
    Public Fecha_Nacimiento As Date
    Public Domicilio As String
    Public Email As New List(Of String)
    Public Telefono As New List(Of String)
End Class

''' <summary>
''' La clas empleado Contiene a la clase persona y agrega datos laborales relevantes
''' </summary>
Public Class Empleado
    Inherits Persona
    Public Legajo As String
    Public Categoria As String
    Public Función As String
    Public Cargo As String
    Public Situacion_revista As String
    Public Organismo As String
    Public Dirección As String
    Public Depto As String
    Public Tareas As String
    Public Horario As String
End Class