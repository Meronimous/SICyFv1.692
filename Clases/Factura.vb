Public Class Factura
    Public CUIT As String
    Public Numero_factura As Long
    Public Fecha As Date
    Public Empleador As Boolean = False
    Public Total_factura As Decimal 'Monto Total de la Factura
    Public Situacionfrente_afip As String 'Responsable Inscripto, no inscripto, Monotributista, Exento
    Public Porcentaje_iva As Decimal 'Tasa de retención de iva aplicada
    Public Neto_IVA As Decimal 'Monto total despues de aplicar el IVA
    Public total12meses As Decimal = 0 ' Total acumulado en los ultimos 12 meses
    Public totalaniocalendario As Decimal = 0 'Total acumulado desde el inicio del año
    Public totalmesencurso As Decimal = 0 'total acumulado en el mes en curso

    Public Function Calculo12meses(Optional clave_expediente_Detalle As Long = 0) As Decimal 'calculo de los 12 meses anteriores
        total12meses = Retornaracumulado(Fecha.AddYears(-1), Fecha, clave_expediente_Detalle)
        Return total12meses
    End Function

    Public Function mesencurso(Optional clave_expediente_Detalle As Long = 0) As Decimal 'Calculo del mes en curso, desde el 01 a la fecha de la factura
        totalmesencurso = Retornaracumulado((New Date(Fecha.Year, Fecha.Month, 1)), Fecha, clave_expediente_Detalle)
        Return totalmesencurso
    End Function

    Public Function calculocalendario(Optional clave_expediente_Detalle As Long = 0) As Decimal 'calculo del 01/01 al día de la fecha de la factura
        totalaniocalendario = Retornaracumulado((New Date(Fecha.Year, 1, 1)), Fecha, clave_expediente_Detalle)
        Return totalaniocalendario
    End Function

    Public Function mesencursodesglose() As DataTable 'Calculo del mes en curso, desde el 01 a la fecha de la factura
        Return Retornardesglose((New Date(Fecha.Year, Fecha.Month, 1)), Fecha)
    End Function

    Public Function Calculo12mesesdesglose() As DataTable 'Calculo del mes en curso, desde el 01 a la fecha de la factura
        Return Retornardesglose(Fecha.AddYears(-1), Fecha)
    End Function

    Public Function calculocalendariodesglose() As DataTable 'Calculo del mes en curso, desde el 01 a la fecha de la factura
        Return Retornardesglose((New Date(Fecha.Year, 1, 1)), Fecha)
    End Function

    Private Function Retornaracumulado(ByVal sd As DateTime, ByVal ed As DateTime, ByVal clave_expediente_detalle As Long) As Decimal
        Dim acumulado As Decimal = 0
        Dim detalle_acumulado As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", ed)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", sd)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", clave_expediente_detalle)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select case when sum(monto)>0 then sum(monto) else 0 end as 'Suma' from expediente_detalle where cuit=@cuit and fechadelmovimiento between @SD and @ED and CODINP=1 and not clave_expediente_detalle =@clave_expediente_detalle", detalle_acumulado, "Mesencurso")
        If detalle_acumulado.Rows.Count > 0 Then
            acumulado = CType(detalle_acumulado.Rows(0).Item(0), Decimal)
        Else
            acumulado = 0
        End If
        Return acumulado
    End Function

    'Public Shared Sub Retornaracumulado_solofecha(ByVal mes As Label, ByVal mes12 As Label, ByVal anio As Label, ByVal cuit As String, ByVal fecha As Date)
    '    Dim acumulado As Decimal = 0
    '    Dim detalle_acumulado As New DataTable
    '    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", cuit)
    '    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", ed)
    '    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", sd)
    '    ' SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", clave_expediente_detalle)
    '    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select case when sum(monto)>0 then sum(monto) else 0 end as 'Suma' from expediente_detalle where cuit=@cuit and fechadelmovimiento between @SD and @ED and CODINP=1 and not clave_expediente_detalle =@clave_expediente_detalle", detalle_acumulado, "Mesencurso")
    '    If detalle_acumulado.Rows.Count > 0 Then
    '        acumulado = CType(detalle_acumulado.Rows(0).Item(0), Decimal)
    '    Else
    '        acumulado = 0
    '    End If
    '    '  anio.Text = Retornaracumulado((New Date(fecha.Year, 1, 1)), fecha, clave_expediente_Detalle)
    '    'Return acumulado
    'End Sub
    Private Function Retornardesglose(ByVal sd As Date, ByVal ed As Date) As DataTable
        Dim acumulado As Decimal = 0
        Dim Tabla_temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", ed)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", sd)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select CONCAT(Substring(clave_expediente_detalle From 5 for 4),'-',cast(Substring(clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente_detalle From 1 for 4)) as Expediente_N, Fechadelmovimiento, Detalle, Monto  FROM expediente_detalle where cuit=@cuit and fechadelmovimiento between @SD and @ED and CODINP=1  ", Tabla_temporal, "retornardesglose")
        Return Tabla_temporal
    End Function

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************