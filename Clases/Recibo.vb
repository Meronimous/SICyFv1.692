Public Class Recibo
    Public Nro_recibo As String
    Public CUIT As String
    Public Fecha_recibo As Date
    Public total As Decimal
    Public total_suss As Decimal
    Public total_iva As Decimal
    Public total_ganancias As Decimal
    Public total_dgr As Decimal
    Public total_otros As Decimal

    Public Sub New()
        CLEAR()
    End Sub

    Public Sub CLEAR()
        NRORECIBO = ""
        CUIT = ""
        Fecha_recibo = Date.Now
        total = 0
        total_suss = 0
        total_iva = 0
        total_ganancias = 0
        total_dgr = 0
        total_otros = 0
    End Sub

    Public Sub insertar_recibo(ByVal recibos As Recibo)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
        ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", clave_expediente_detalle_recibo)
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Retencion_Clave_detalle", vbNull)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_recibo", Nro_recibo)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_recibo", Fecha_recibo)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_recibo", Fecha_recibo.Year)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total", total)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_suss", total_suss)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_iva", total_iva)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_ganancias", total_ganancias)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_dgr", total_dgr)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_otros", total_otros)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Insert into Tesoreria_recibos (
CUIT,
Nro_recibo,
Year_recibo,
Fecha_recibo,
total,
total_iva,
total_ganancias,
total_dgr,
total_otros,usuario)
values
(
@CUIT,
@Nro_recibo,
@Year_recibo,
@Fecha_recibo,
@total,
@total_iva,
@total_ganancias,
@total_dgr,
@total_otros,
@usuario)"
        'prueba que no exista anteriormente un recibo
        Try
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, "insertar_recibo")
            MessageBox.Show("Recibo " & Nro_recibo & vbCrLf & "de " & CUIT & vbCrLf & " guardado exitosamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cargar_recibo(ByVal recibos As Recibo, Optional clave_expediente_detalle_recibo As Long = 0)
        If clave_expediente_detalle_recibo > 0 Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", clave_expediente_detalle_recibo)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Retencion_Clave_detalle", vbNull)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_recibo", Nro_recibo)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_recibo", Fecha_recibo)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total", total)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_suss", total_suss)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_iva", total_iva)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_ganancias", total_ganancias)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_dgr", total_dgr)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_otros", total_otros)
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "update Expediente_Detalle set Nro_recibo=@Nro_recibo
 Where clave_expediente_detalle=@clave_expediente_Detalle"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, "cargar_recibo")
        End If
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", clave_expediente_detalle_recibo)
        '       'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Retencion_Clave_detalle", vbNull)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_recibo", Nro_recibo)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_recibo", Fecha_recibo)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total", total)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_suss", total_suss)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_iva", total_iva)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_ganancias", total_ganancias)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_dgr", total_dgr)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@total_otros", total_otros)
        '       SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "update retenciones set Nro_recibo=@Nro_recibo
        'Where clave_expediente_detalle=@clave_expediente_Detalle"
        '       Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, "cargar_recibo")
        'Este comando actualiza todos los que
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE retenciones INNER JOIN expediente_detalle
    ON retenciones.Clave_expediente_detalle = expediente_detalle.Clave_expediente_detalle
SET retenciones.Nro_Recibo = expediente_detalle.Nro_Recibo
where isnull(retenciones.Nro_recibo) and   LENGTH(expediente_detalle.Nro_Recibo)>5"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, "cargar_recibo")
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************