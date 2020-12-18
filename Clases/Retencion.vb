Public Class Retencion
    Inherits Factura
    Public clave_expediente_detalle As Long
    Public nrocertificado As Integer
    Public Retencion_clave_detalle As Long
    Public Nombre_retencion As String 'nombre de la retencion a operar
    Public Nombre_retencion_detalle As String 'Detalle de la retencion a operar
    Public Descripciondelcalculo As String 'Explicación del calculo de retenciones
    Public Cuit_recaudador As String    'Ente que ordena la retención (normalmente AFIP o DGR)
    Public Minimo_no_imponible As Decimal 'Debe superar el monto minimo para ejecutar el calculo de retención
    Public Alicuota As Decimal 'Alicuota aplicada
    Public Nrotransferencia As Long    'Numero de transferencia banco
    Public Regimen As String 'Nombre del Regimen aplicado
    Public Cod_impuesto As Integer 'Codigo del impuesto
    Public cod_regimen As Integer 'Codigo del regimen
    Public Retencion_minima As Decimal  'Minimo a Cobrar por retención
    Public montoparcial As String 'En caso de tener un regimen especial
    Public Monto_retenido As Decimal     'retencionesrealizadas
    Public Retencion_mescurso As Decimal
    Public Retencion_aniocalendario As Decimal
    Public Retencion_12meses As Decimal

    Public Sub New()
        clearretencion()
    End Sub

    Public Sub clearretencion()
        Nombre_retencion = ""
        Cuit_recaudador = ""
        clave_expediente_detalle = Nothing
        Retencion_clave_detalle = Nothing
        Minimo_no_imponible = 0
        Alicuota = 0
        Porc_IVA = 0
        Regimen = ""
        Cod_impuesto = 0
        cod_regimen = 0
        Retencion_minima = 0
        Monto_retenido = 0
        montoparcial = ""
        Retencion_12meses = 0
        Retencion_aniocalendario = 0
        Retencion_mescurso = 0
        nrocertificado = 0
    End Sub

    Public Sub insertarretencion(ByVal Clave_expediente_detalle_ext As Long) ' la insercion requiere la clave del movimiento contenida en movimiento.Clave_expediente_detalle
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Clave_expediente_detalle_ext)
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Retencion_Clave_detalle", vbNull)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nombre_retencion", Nombre_retencion)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nombre_retencion_detalle", Nombre_retencion_detalle)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuit_recaudador", Cuit_recaudador)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fecha_retencion", Fecha)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@minimonoimponible", Minimo_no_imponible)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Alicuota", Alicuota)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Porc_IVA", Porcentaje_iva)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Situacionfrente_afip", Situacionfrente_afip)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Regimen", Regimen)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cod_impuesto", Cod_impuesto)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@cod_regimen", cod_regimen)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Retencion_minima", Retencion_minima)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total_factura", Total_factura)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@neto_factura", Neto_IVA)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto_retenido", Monto_retenido)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto_parcial", montoparcial)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Insert into Retenciones (
Clave_expediente_detalle,
Nombre_retencion,
Nombre_retencion_detalle,
CUIT,
Cuit_recaudador,
fecha_retencion,
minimonoimponible,
alicuota,
porc_IVA,
situacionfrente_afip,
regimen,
cod_impuesto,
cod_regimen,
retencion_minima,
Total_factura,
neto_factura,
Monto_retenido,
Monto_parcial,
nrocertificado,
Usuario)
values
(@Clave_expediente_detalle,
@Nombre_retencion,
@Nombre_retencion_detalle,
@CUIT,
@Cuit_recaudador,
@fecha_retencion,
@minimonoimponible,
@alicuota,
@Porc_IVA,
@situacionfrente_afip,
@regimen,
@cod_impuesto,
@cod_regimen,
@retencion_minima,
@Total_factura,
@neto_factura,
@Monto_retenido,
@Monto_parcial,
/* La razón de la consulta es para buscar si ya existe un nro de certificado para este movimiento, si existe utiliza el formato de maximo +1*/
case when isnull((select * from (select nrocertificado from retenciones where Clave_expediente_detalle= @Clave_expediente_detalle group by nrocertificado limit 1)B)) then
(select * from (select max(nrocertificado)+1 from retenciones limit 1)B)
else
(select * from (select nrocertificado from retenciones where Clave_expediente_detalle= @Clave_expediente_detalle group by nrocertificado limit 1)B)
end,
@Usuario)
ON DUPLICATE KEY UPDATE
CUIT=@CUIT,
Nombre_retencion_detalle=@Nombre_retencion_detalle,
Cuit_recaudador=@Cuit_recaudador,
fecha_retencion=@fecha_retencion,
minimonoimponible=@minimonoimponible,
alicuota=@alicuota,
Porc_IVA=@Porc_IVA,
situacionfrente_afip=@situacionfrente_afip,
regimen=@regimen,
cod_impuesto=@cod_impuesto,
cod_regimen=@cod_regimen,
retencion_minima=@retencion_minima,
Total_factura=@Total_factura,
neto_factura=@neto_factura,
Monto_retenido=@Monto_retenido,
Monto_parcial=@Monto_parcial,
Usuario=@Usuario"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, "Insertarretencion")
    End Sub

    Public Function Retenido() As Decimal
        Dim acumulado As Decimal = 0
        Dim sd As Date = New Date(Fecha.Year, Fecha.Month, 1)
        Dim ed As Date = Fecha
        Dim detalle_acumulado As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nombre_retencion", Nombre_retencion)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", ed)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", sd)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select case when sum(monto_retenido)>0 then sum(monto_retenido) else 0 end as 'Suma' from
Retenciones where cuit=@cuit and nombre_retencion=@nombre_retencion and fecha_retencion  between @SD and @ED ", detalle_acumulado, "retenido")
        If detalle_acumulado.Rows.Count > 0 Then
            acumulado = CType(detalle_acumulado.Rows(0).Item(0), Decimal)
        Else
            acumulado = 0
        End If
        Return acumulado
    End Function

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************