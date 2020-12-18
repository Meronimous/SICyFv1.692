Public Class OrdenProvision
    Inherits Proveedor
    Public ClaveOrdenProvision As Long 'clave de orden de provisión con una extensión de 13, donde los primero 4 números corresponden al año, luego al codigo de org. del servicio y luego el numero de orden de provisión
    Public OrdenProvisionNumero As Integer 'numero de la orden de provision
    Public OrdenProvisionYear As Integer 'año de la orden de provisión
    Public ClaveExpediente As Long 'clave numerica de la orden asociada
    Public Expediente As String ' Expediente que contiene la orden de provisión
    Public Iniciador As String ' El ente u organismo que inicia el expediente
    Public Destino As String 'Dentro de este Organismo que sector, programa, bien mueble genera el pedido
    Public TipoOrigen As String 'forma de solicitud del pago
    Public NumeroOrigen As Integer 'numero de forma de solicitud del pago
    Public YearOrigen As Integer 'año  de forma de solicitud del pago
    Public FechaOrigen As Date 'fecha de forma de solicitud del pago
    Public TipoInstrumentoLegal As String 'Tipo de Instrumento legal
    Public NumeroInstrumentoLegal As Integer 'numero de Instrumento legal tipo
    Public YearInstrumentoLegal As Integer 'año  Instrumento legal
    Public FechaInstrumentoLegal As Date 'FEcha  Instrumento legal
    Public Total As Decimal ' Totaal acumulado de la orden de provisión
    Public LugarEntrega As String ' Lugar destinado a la entrega total o parcial
    Public ValorTiempoEntrega As Integer 'Cantidad en número de tiempo de entrega
    Public UnidadTiempoEntrega As String 'unidad de tiempo utilizada para el tiempo de entrega
    Public fecharealizada_ordenprovision As Date 'Fecha de comienzo de realización de la orden de provisión
    Public Fechaconfeccionada_ordenprovision As Date 'FEcha de confección efectiva de la orden de provisión
    Public fechaobservaciones_ordenprovision As String 'Fecha de comienzo de realización de la orden de provisión
    Public DATOSORDENPROVISION As DataTable 'Tabla de datos donde se especifican los datos de la orden de provisión
    Public PARTIDA As New PartidaPresupuestaria 'Para colocar en el cuadruplicado de la orden de provisión
    Public USUARIO As Integer 'CREADOR DE LA ORDEN DE PROVISION

    Public Sub New()
        Me.clearprovision()
    End Sub

    Public Sub clearprovision()
        ClaveOrdenProvision = Nothing
        numero = Nothing
        ClaveExpediente = Nothing
        Iniciador = ""
        Destino = ""
        TipoOrigen = ""
        NumeroOrigen = Nothing
        YearOrigen = Date.Now.Year
        FechaOrigen = Date.Now
        TipoInstrumentoLegal = ""
        NumeroInstrumentoLegal = Nothing
        YearInstrumentoLegal = Date.Now.Year
        FechaInstrumentoLegal = Date.Now
        Total = Nothing
        LugarEntrega = ""
        ValorTiempoEntrega = Nothing
        UnidadTiempoEntrega = ""
        fecharealizada_ordenprovision = Date.Now
        Fechaconfeccionada_ordenprovision = Date.Now
        DATOSORDENPROVISION = New DataTable
        fechaobservaciones_ordenprovision = ""
        USUARIO = 0
        PARTIDA.clear()
        Me.clear()
    End Sub

    Public Sub cargar_OP(ByVal Clave_ordenprovisions As Long)
        Dim datos As New DataTable
        Dim datosdetalle As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenprovision", Clave_ordenprovisions)
        Dim consultasql As String = "Select concat(cast(substring(Clave_ordenprovision from 9 for 5) as unsigned),'/',cast(substring(Clave_ordenprovision from 1 for 4) as unsigned)) as 'NUM.OP' ,
Clave_ordenprovision,
Clave_expediente,
Iniciador,
Destino,
Tipo_origen,
Numero_origen,
Year_origen,
Fecha_origen,
CUIT,
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumentolegal,
Fecha_instrumentolegal,
Total,
Lugar_entrega,
valor_tiempoentrega,
Unidad_tiempoentrega,
fecha_observaciones,
fecharealizada_ordenprovision,
Fechaconfeccionada_ordenprovision,USUARIO
from suministros_orden_provision where Clave_ordenprovision=@Clave_ordenprovision"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        ClaveOrdenProvision = Clave_ordenprovisions
        OrdenProvisionNumero = Nothing
        OrdenProvisionYear = Nothing
        If datos.Rows.Count > 0 Then
            ClaveExpediente = datos.Rows(0).Item("Clave_expediente")
            If datos.Rows(0).Item("Clave_expediente").ToString.Count > 12 Then
                Expediente = ClaveExpediente.ToString.Substring(4, 4) & "-" &
                    CType(ClaveExpediente.ToString.Substring(8, 5), Long) & "/" & ClaveExpediente.ToString.Substring(0, 4)
            End If
            Iniciador = datos.Rows(0).Item("Iniciador")
            Destino = datos.Rows(0).Item("Destino")
            TipoOrigen = datos.Rows(0).Item("Tipo_origen")
            NumeroOrigen = datos.Rows(0).Item("Numero_origen")
            YearOrigen = datos.Rows(0).Item("Year_origen")
            FechaOrigen = datos.Rows(0).Item("Fecha_origen")
            CUIT = datos.Rows(0).Item("CUIT")
            USUARIO = datos.Rows(0).Item("USUARIO")
            Cargardatos()
            TipoInstrumentoLegal = datos.Rows(0).Item("Tipo_instrumentolegal")
            NumeroInstrumentoLegal = datos.Rows(0).Item("Numero_instrumentolegal")
            YearInstrumentoLegal = datos.Rows(0).Item("Year_instrumentolegal")
            FechaInstrumentoLegal = CType(datos.Rows(0).Item("Fecha_instrumentolegal").ToString, Date)
            LugarEntrega = datos.Rows(0).Item("Lugar_entrega")
            ValorTiempoEntrega = datos.Rows(0).Item("valor_tiempoentrega")
            UnidadTiempoEntrega = datos.Rows(0).Item("Unidad_tiempoentrega")
            If Not IsNothing(datos.Rows(0).Item("fecha_observaciones")) And Not IsDBNull(datos.Rows(0).Item("fecha_observaciones")) Then
                fechaobservaciones_ordenprovision = datos.Rows(0).Item("fecha_observaciones")
            Else
                fechaobservaciones_ordenprovision = ""
            End If
            fecharealizada_ordenprovision = datos.Rows(0).Item("fecharealizada_ordenprovision")
            Fechaconfeccionada_ordenprovision = datos.Rows(0).Item("Fechaconfeccionada_ordenprovision")
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenprovision", Clave_ordenprovisions)
            consultasql = "Select
renglon as 'Reng.',
Cantidad as 'Cant.',
Unidad as 'Un.',
Descripcionart as `Articulos.`,
Precio_unitario as 'Prec.Unit.',
Precio_total as 'Prec.Total',
Detalle as 'Detalle',
Encabezado as 'Encabezado'
from suministros_orden_provision_detalle where Clave_ordenprovision=@Clave_ordenprovision"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datosdetalle, System.Reflection.MethodBase.GetCurrentMethod.Name)
            DATOSORDENPROVISION = datosdetalle
            OrdenProvisionNumero = ClaveOrdenProvision.ToString.Substring(8, 5)
            OrdenProvisionYear = ClaveOrdenProvision.ToString.Substring(0, 4)
            Total = calculartotal(DATOSORDENPROVISION)
        End If
    End Sub

    'Public Shared Function Estructura_Seleccionordenprovision() As DataTable
    '    Dim datos As New DataTable
    '    datos.Columns.Add("Orden_Provisión Nº", System.Type.GetType("System.String"))
    '    datos.Columns.Add("Monto", System.Type.GetType("System.Decimal"))
    '    datos.Columns.Add("Tipo_legal", System.Type.GetType("System.String"))
    '    datos.Columns.Add("Instrumento", System.Type.GetType("System.String"))
    '    datos.Columns.Add("Tipo_origen", System.Type.GetType("System.String"))
    '    datos.Columns.Add("ORIGEN", System.Type.GetType("System.String"))
    '    datos.Columns.Add("CUIT", System.Type.GetType("System.String"))
    '    Return datos
    'End Function
    Public Shared Function Estructura_Seleccionordenprovision(Optional CLAVE_ORDENPAGO As Long = Nothing) As DataTable
        Dim datos As New DataTable
        If IsNothing(CLAVE_ORDENPAGO) Then
            datos.Columns.Add("Orden_Provision", System.Type.GetType("System.String"))
            datos.Columns.Add("Monto", System.Type.GetType("System.Decimal"))
            datos.Columns.Add("Tipo_legal", System.Type.GetType("System.String"))
            datos.Columns.Add("Num_instrumento", System.Type.GetType("System.String"))
            datos.Columns.Add("Tipo_origen", System.Type.GetType("System.String"))
            datos.Columns.Add("Num_origen", System.Type.GetType("System.String"))
            datos.Columns.Add("CUIT", System.Type.GetType("System.String"))
            datos.Columns.Add("ACTA_RECEPCION", System.Type.GetType("System.String"))
            datos.Columns.Add("FECHA_ACTA", System.Type.GetType("System.DateTime"))
            datos.Columns.Add("MONTO_ANTICIPO", System.Type.GetType("System.Decimal"))
            datos.Columns.Add("MONTO_ACTA", System.Type.GetType("System.Decimal"))
            datos.Columns.Add("DETALLE_ACTA", System.Type.GetType("System.String"))
            datos.Columns.Add("EFECTOR", System.Type.GetType("System.String"))
            datos.Columns.Add("PERIODO", System.Type.GetType("System.String"))
            datos.Columns.Add("MULTA_MONTO", System.Type.GetType("System.Decimal"))
            datos.Columns.Add("MULTA_RESOLUCION", System.Type.GetType("System.String"))
        Else
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", CLAVE_ORDENPAGO)
            Dim consultasql As String = "
SELECT
Orden_Provision,
Monto,
Tipo_legal,
Num_instrumento,
Tipo_origen,
Num_origen,
CUIT,
ACTA_RECEPCION,
FECHA_ACTA,
MONTO_ANTICIPO,
MONTO_ACTA,
DETALLE_ACTA,
PERIODO,
EFECTOR,
MULTA_MONTO,
MULTA_RESOLUCION
FROM
(Select  concat(cast(substring(Clave_ordenprovision from 9 for 5) as unsigned),'/',cast(substring(Clave_ordenprovision from 1 for 4) as unsigned)) AS 'Orden_Provision',
TOTAL AS Monto,
Tipo_instrumentolegal as 'Tipo_legal',
concat(Numero_instrumentolegal,'/',Year_instrumentolegal  )as 'Num_instrumento',
tipo_origen as 'Tipo_origen',
concat(numero_origen,'/',Year_origen ) as 'Num_origen',
cuit as 'CUIT',clave_ordenprovision
from suministros_orden_provision where Clave_ordenprovision in (Select Clave_ordenprovision from contabilidad_ordenpago_provision where Clave_Ordenpago=@Clave_ordenpago))OPROV
LEFT JOIN
(SELECT
concat(cast(substring(Clave_ActaRecepcion from 9 for 5) as unsigned),'/',cast(substring(Clave_ActaRecepcion from 1 for 4) as unsigned)) AS 'ACTA_RECEPCION',
FECHA AS 'FECHA_ACTA',
ANTICIPO AS 'MONTO_ANTICIPO',
TOTAL AS 'MONTO_ACTA',
DETALLE AS 'DETALLE_ACTA',
EFECTOR,
PERIODO,
MULTA_MONTO,
MULTA_RESOLUCION,
CLAVE_ORDENPROVISION
FROM contabilidad_actasrecepcion Where Clave_Ordenpago=@Clave_ordenpago )ACTARECEP
ON OPROV.CLAVE_ORDENPROVISION=ACTARECEP.Clave_ordenprovision"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Return datos
    End Function

    Private Function calculartotal(ByVal tabladedatos As DataTable) As Decimal
        Dim sumado As Decimal = 0
        Try
            For x = 0 To tabladedatos.Rows.Count - 1
                'Prec.Total
                sumado += tabladedatos.Rows(x).Item("Prec.Total")
            Next
        Catch ex As Exception
            MessageBox.Show("hay un error con los valores" & vbCrLf & ex.Message)
        End Try
        Return sumado
    End Function

    Public Sub Borrarordenprovision()
        'RENGLONES DE LA TABLA
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenprovision", ClaveOrdenProvision)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM suministros_orden_provision WHERE Clave_ordenprovision= @Clave_ordenprovision;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Public Function Buscarmaximo_ordenprovision(ByRef Year As Integer) As Int16
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Year_ordenprovision", Year)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                             "Select max( cast(substring(Clave_ordenprovision from 9 for 13) as unsigned)) as 'Num' from suministros_orden_provision
where cast(substring(Clave_ordenprovision from 1 for 4) as unsigned)=@Year_ordenprovision",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(temporal.Rows(0).Item(0))
            Case True
                Return 1
            Case False
                Return Convert.ToInt16(temporal.Rows(0).Item(0)) + 1
            Case Else
                Return 1
        End Select
    End Function

    Public Function Verificarexistencia() As Boolean
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Year_ordenprovision", Year)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                             "Select max( cast(substring(Clave_ordenprovision from 9 for 13) as unsigned)) as 'Num' from suministros_orden_provision
where cast(substring(Clave_ordenprovision from 1 for 4) as unsigned)=@Year_ordenprovision",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(temporal.Rows(0).Item(0))
            Case True
                Return 1
            Case False
                Return Convert.ToInt16(temporal.Rows(0).Item(0)) + 1
        End Select
    End Function

    Public Sub INSERTARORDENPROVISION()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenprovision", ClaveOrdenProvision)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", ClaveExpediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Iniciador", Iniciador)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Destino", Destino)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipo_origen", TipoOrigen)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Numero_origen", NumeroOrigen)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_origen", YearOrigen)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_origen", FechaOrigen)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipo_instrumentolegal", TipoInstrumentoLegal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Numero_instrumentolegal", NumeroInstrumentoLegal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_instrumentolegal", YearInstrumentoLegal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_instrumentolegal", FechaInstrumentoLegal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total", Total)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Lugar_entrega", LugarEntrega)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@valor_tiempoentrega", ValorTiempoEntrega)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Unidad_tiempoentrega", UnidadTiempoEntrega)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fecharealizada_ordenprovision", fecharealizada_ordenprovision)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fecha_observaciones", fechaobservaciones_ordenprovision)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fechaconfeccionada_ordenprovision", Fechaconfeccionada_ordenprovision)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `SUMINISTROS_ORDEN_PROVISION` " &
            "(
Clave_ordenprovision,
Clave_expediente,
Iniciador,
Destino,
Tipo_origen,
Numero_origen,
Year_origen,
Fecha_origen,
CUIT,
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumentolegal,
Fecha_instrumentolegal,
Total,
Lugar_entrega,
valor_tiempoentrega,
Unidad_tiempoentrega,
fecha_observaciones,
fecharealizada_ordenprovision,
Fechaconfeccionada_ordenprovision,
USUARIO
) VALUES (
@Clave_ordenprovision,
@Clave_expediente,
@Iniciador,
@Destino,
@Tipo_origen,
@Numero_origen,
@Year_origen,
@Fecha_origen,
@CUIT,
@Tipo_instrumentolegal,
@Numero_instrumentolegal,
@Year_instrumentolegal,
@Fecha_instrumentolegal,
@Total,
@Lugar_entrega,
@valor_tiempoentrega,
@Unidad_tiempoentrega,
@fecha_observaciones,
@fecharealizada_ordenprovision,
@Fechaconfeccionada_ordenprovision,
@USUARIO
            ) ON DUPLICATE KEY UPDATE
Clave_ordenprovision=@Clave_ordenprovision,
Clave_expediente=@Clave_expediente,
Iniciador=@Iniciador,
Destino=@Destino,
Tipo_origen=@Tipo_origen,
Numero_origen=@Numero_origen,
Year_origen=@Year_origen,
Fecha_origen=@Fecha_origen,
CUIT=@CUIT,
Tipo_instrumentolegal=@Tipo_instrumentolegal,
Numero_instrumentolegal=@Numero_instrumentolegal,
Year_instrumentolegal=@Year_instrumentolegal,
Fecha_instrumentolegal=@Fecha_instrumentolegal,
Total=@Total,
Lugar_entrega=@Lugar_entrega,
valor_tiempoentrega=@valor_tiempoentrega,
Unidad_tiempoentrega=@Unidad_tiempoentrega,
fecha_observaciones=@fecha_observaciones,
fecharealizada_ordenprovision=@fecharealizada_ordenprovision,
Fechaconfeccionada_ordenprovision=@Fechaconfeccionada_ordenprovision,
USUARIO=@USUARIO
"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'RENGLONES DE LA TABLA
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenprovision", ClaveOrdenProvision)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM suministros_orden_provision_detalle WHERE Clave_ordenprovision= @Clave_ordenprovision;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        For Z As Integer = 0 To DATOSORDENPROVISION.Rows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenprovision", ClaveOrdenProvision)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@renglon", DATOSORDENPROVISION.Rows(Z).Item("Reng."))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cantidad", DATOSORDENPROVISION.Rows(Z).Item("Cant."))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Unidad", DATOSORDENPROVISION.Rows(Z).Item("Un."))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Descripcionart", DATOSORDENPROVISION.Rows(Z).Item("Articulos."))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Precio_unitario", DATOSORDENPROVISION.Rows(Z).Item("Prec.Unit."))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Precio_total", DATOSORDENPROVISION.Rows(Z).Item("Prec.Total"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", DATOSORDENPROVISION.Rows(Z).Item("Detalle"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ENCABEZADO", DATOSORDENPROVISION.Rows(Z).Item("ENCABEZADO"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO  suministros_orden_provision_detalle
(
Clave_ordenprovision,
renglon,
Cantidad,
Unidad,
Descripcionart,
Precio_unitario,
Precio_total,
Detalle,
ENCABEZADO
)
 VALUES
(
@Clave_ordenprovision,
@renglon,
@Cantidad,
@Unidad,
@Descripcionart,
@Precio_unitario,
@Precio_total,
@Detalle,
@ENCABEZADO
)
;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
    End Sub

    Public Shared Function Ordenesprovision_expediente(ByVal clave_expediente As Long) As DataTable
        Dim tabla_temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        consultasql = "Select concat(cast(substring(Clave_ordenprovision from 9 for 5) as unsigned),'/',cast(substring(Clave_ordenprovision from 1 for 4) as unsigned)) as 'NUM.OP',Total,Tipo_instrumentolegal, concat(Numero_instrumentolegal,'/',Year_instrumentolegal) as 'Instrumento',
tipo_origen,concat(numero_origen,'/',Year_origen )as 'Tipo',cuit
from suministros_orden_provision where clave_expediente=@clave_expediente"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, tabla_temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return tabla_temporal
    End Function

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************