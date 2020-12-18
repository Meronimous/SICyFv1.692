Imports System.Runtime.CompilerServices

Public Class TesGral
End Class

Public Class TesoreriaRespuestaApi
    Public Property codigo As Integer
    Public Property token As String
    Public Property tiempoExpiracion As String
    Public Property permisoSA As String

    Public Sub INSERTARBD()
    End Sub

    Public Function Consultar_Token_Vigente() As String
        Dim TOKEN As String = Nothing
        Dim tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@FECHA", Date.Now)
        consultaasociada = "Select * from contaduria_usuarios.tesgral_token where Creado_o_Modificado > DATE_SUB(NOW(),INTERVAL (3600) second) "
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultaasociada, tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If tablatemporal.Rows.Count > 0 Then
            TOKEN = tablatemporal.Rows(0).Item("token")
        End If
        Return TOKEN
    End Function

    Public Sub InsertarToken(ByVal respuesta As TesoreriaRespuestaApi)
        INSERTCOMMANDSQL.Parameters.AddWithValue("@CODIGO", respuesta.codigo)
        INSERTCOMMANDSQL.Parameters.AddWithValue("@TOKEN", respuesta.token)
        INSERTCOMMANDSQL.Parameters.AddWithValue("@TIEMPOEXPIRACION", respuesta.tiempoExpiracion)
        INSERTCOMMANDSQL.Parameters.AddWithValue("@PERMISOSA", respuesta.permisoSA)
        INSERTCOMMANDSQL.CommandText = "INSERT INTO TESGRAL_TOKEN
(CODIGO,
TOKEN,
TIEMPOEXPIRACION,
PERMISOSA)
VALUES
(@CODIGO,
@TOKEN,
@TIEMPOEXPIRACION,
@PERMISOSA);"
        Inicio.INSERTSQLPARAMETROS("CONTADURIA_USUARIOS", Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

End Class

Public Class Detalle
    Public Property partida As String
    Public Property Proveed_Razonsoc As String
    Public Property Proveed_Cuit As String
    Public Property Monto As Double
    Public Property Expdte_Gral As String
    Public Property Org As String
End Class

Public Class TesoreriaPedidofondo
    Public Property PF As String
    Public Property Origen As Integer
    Public Property Orden_Entrega As String
    Public Property Ejercicio As Integer
    Public Property Expediente As String
    Public Property Fecha As String
    Public Property Cuenta As String
    Public Property Observaciones As String
    Public Detalle As Detalle()
End Class

Module ArrayExtension

    <Extension()>
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        If arr IsNot Nothing Then
            Array.Resize(arr, arr.Length + 1)
            arr(arr.Length - 1) = item
        Else
            ReDim arr(0)
            arr(0) = item
        End If
    End Sub

End Module