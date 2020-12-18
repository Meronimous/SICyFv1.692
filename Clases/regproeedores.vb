Imports System.Reflection

Imports Newtonsoft.Json

Imports RestSharp

Public Class AvailableTicketType
    Public Property id As Integer
    Public Property name As String
End Class

''' <summary>
''' La clase RegProveedores se encarga de manejar la conexión con el registro oficial de proveedores de la provincia de Misiones
''' </summary>
Public Class RegProveedores
    Public Property id As Integer
    Public Property cuit As String
    Public Property companyName As String
    Public Property status As Integer
    Public Property fantasyName As String
    Public Property realAddress As Object()
    Public Property legalAddress As Object()
    Public Property email As String
    Public Property secondaryEmail As String
    Public Property phoneNumber As String
    Public Property startDate As String
    Public Property endDate As String
    Public Property registrationReportUrl As String
    Public Property availableTicketTypes As AvailableTicketType()
    Public Property observation As String

    Public Shared Function CreateDataTable(Of T)(ByVal list As IEnumerable(Of T)) As DataTable
        Dim type As Type = GetType(T)
        Dim properties = type.GetProperties()
        Dim dataTable As DataTable = New DataTable()
        For Each info As PropertyInfo In properties
            dataTable.Columns.Add(New DataColumn(info.Name, If(Nullable.GetUnderlyingType(info.PropertyType), info.PropertyType)))
        Next
        For Each entity As T In list
            Dim values As Object() = New Object(properties.Length - 1) {}
            For i As Integer = 0 To properties.Length - 1
                values(i) = properties(i).GetValue(entity)
            Next
            dataTable.Rows.Add(values)
        Next
        Return dataTable
    End Function

End Class

Public Class RespuestaProveedores
    Public Property page As Integer
    Public Property perPage As String
    Public Property pageCount As Integer
    Public Property totalCount As Integer
    Public Property hasMore As Boolean
    Public Property data As RegProveedores()

    Public Shared Function DevolverRegistroProveedor(ByVal CUIT As String) As RegProveedores()
        Dim proveedorregistrado As RegProveedores() = Nothing
        CUIT = CUIT.Replace("-", "")
        Dim client As New RestClient("https://proveedores.misiones.gob.ar:8080")
        Dim request As New RestRequest()
        Select Case CUIT.Length
            Case = 0
                request.Resource = ("?getListProvider=getListProvider&pageId=1&pageSize=3500&filter=%7B%22cuit%22:%22%22,%22companyName%22:%22%22,%22economicActivityTypeId%22:%22%22,%22economicActivitySubTypeId%22:%22%22,%22statusIds%22:[4]%7D")
            Case Else
                request.Resource = ($"?getListProvider=getListProvider&pageId=1&pageSize=10&filter=%7B%22cuit%22:%22{CUIT}%22,%22companyName%22:%22%22,%22economicActivityTypeId%22:%22%22,%22economicActivitySubTypeId%22:%22%22,%22statusIds%22:[4]%7D")
        End Select
        request.Method = Method.GET
        request.RequestFormat = DataFormat.None
        Dim respuesta As RespuestaProveedores = Nothing
        Try
            Dim response = client.Execute(request)
            If response.IsSuccessful And response.Content.Length > 15 Then
                respuesta = JsonConvert.DeserializeObject(Of RespuestaProveedores)(response.Content)
            End If
            If Not IsNothing(respuesta.data) Then
                proveedorregistrado = respuesta.data
            End If
        Catch ex As Exception
            MessageBox.Show("No se encuentra en el Registro Provincial de Proveedores")
        End Try
        Return proveedorregistrado
    End Function

End Class