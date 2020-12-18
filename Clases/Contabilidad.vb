Public Class Contabilidad
End Class

Public Class Orden_pagohaberesdetalle
    Public Grupo As String
    Public Subgrupo As String
    Public Monto As Decimal
    Public clave_ordenpagohaberes As Long
End Class

Public Class ACTARECEPCION
    Public ACTARECEPCION_NUMERO As Integer
    Public ACTARECEPCION_YEAR As Integer
    Public ACTARECEPCION_DETALLE As String
    Public ACTARECEPCION_FECHA As Date
    Public ACTARECEPCION_CUIT As String
    Public ACTARECEPCION_ANTICIPO As Decimal
    Public ACTARECEPCION_MONTO As Decimal
    Public ACTARECEPCION_CLAVE_ORDENPROVISION As Long
    Public ACTARECEPCION_EFECTOR As String
    Public ACTARECEPCION_PERIODO As String
    Public ACTARECEPCION_MULTA_RESOLUCION As String
    Public ACTARECEPCION_MULTA_MONTO As Decimal
    Public ACTARECEPCION_TABLA_detalle As New DataTable

    Public Sub New()
        Me.CLEAR()
    End Sub

    Public Sub CLEAR()
        ACTARECEPCION_NUMERO = 0
        ACTARECEPCION_CUIT = ""
        ACTARECEPCION_YEAR = 0
        ACTARECEPCION_DETALLE = ""
        ACTARECEPCION_EFECTOR = ""
        ACTARECEPCION_PERIODO = ""
        ACTARECEPCION_ANTICIPO = 0
        ACTARECEPCION_MONTO = 0
        ACTARECEPCION_FECHA = Date.Now
        ACTARECEPCION_CLAVE_ORDENPROVISION = 0
        ACTARECEPCION_MULTA_RESOLUCION = ""
        ACTARECEPCION_MULTA_MONTO = 0
        ACTARECEPCION_TABLA_detalle.Clear()
        ACTARECEPCION_TABLA = estructuraActaRecepcion_DETALLE()
    End Sub

    Public Shared Function estructuraActaRecepcion_DETALLE() As DataTable
        Dim datos As New DataTable
        datos.Columns.Add("Renglón", System.Type.GetType("System.String"))
        datos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("Unidad", System.Type.GetType("System.String"))
        datos.Columns.Add("Descripcionart", System.Type.GetType("System.String"))
        datos.Columns.Add("Precio_total", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("Detalle", System.Type.GetType("System.String"))
        Return datos
    End Function

    Public Shared Function estructuraActaRecepcion(Optional CLAVE_ORDENPAGO As Long = Nothing) As DataTable
        Dim datos As New DataTable
        If IsNothing(CLAVE_ORDENPAGO) Then
            datos.Columns.Add("NUMERO", System.Type.GetType("System.String"))
            datos.Columns.Add("ANIO", System.Type.GetType("System.Int32"))
            datos.Columns.Add("Detalle", System.Type.GetType("System.String"))
            datos.Columns.Add("FECHA", System.Type.GetType("System.DateTime"))
            datos.Columns.Add("CUIT", System.Type.GetType("System.String"))
            datos.Columns.Add("MONTO", System.Type.GetType("System.Decimal"))
        Else

            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", CLAVE_ORDENPAGO)
            Dim consultasql As String = "Select cast(Substring(Clave_actarecepcion From 9 for 5)AS UNSIGNED) AS 'NUMERO',
cast(substring(Clave_actarecepcion from 1 for 4)AS UNSIGNED) AS `ANIO`,
DETALLE AS DETALLE,
FECHA AS FECHA,
CUIT AS CUIT,
TOTAL AS MONTO
from Contabilidad_ACTASRECEPCION where Clave_ordenpago=@Clave_ordenpago"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Return datos
    End Function

End Class

Public Class SINACTARECEPCION
    Inherits ACTARECEPCION
    Public Clave_Ordenpago As Long
    Public Indice As Integer
    Public Tipo_instrumentolegal As String
    Public Numero_instrumentolegal As Integer
    Public Year_instrumento_legal As Integer
    Public Total As Decimal
    Public Detalle As String
    Public EFECTOR As String
    Public PERIODO As String
    Public CUIT As String
    Public nombre As String
    Public ACTA_RECEPCION As String
    Public RECURSOS As Decimal
    Public GASTOS As Decimal
    Public USUARIO As Long
    Public listadocolumnas As New List(Of String)

    'Public Structure Columnas
    '    Public cantidadcolumnas As Integer
    '    Public nombrescolumnas As String
    'End Structure
    'Public Property Usuario As Long
    '    Get
    '        Return Usuario
    '    End Get
    '    Set(value As Long)
    '        _usuario = value
    '    End Set
    'End Property
    Public Sub New()
    End Sub

    Public Shared Function SINACTARECEPCION() As DataTable
        Dim datos As New DataTable
        'datos.Columns.Add("Indice", System.Type.GetType("System.Int32"))
        datos.Columns.Add("Tipo_instrumentolegal", System.Type.GetType("System.String"))
        datos.Columns.Add("Numero_instrumentolegal", System.Type.GetType("System.Int32"))
        datos.Columns.Add("Year_instrumento_legal", System.Type.GetType("System.Int32"))
        datos.Columns.Add("Total", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("Detalle", System.Type.GetType("System.String"))
        datos.Columns.Add("EFECTOR", System.Type.GetType("System.String"))
        datos.Columns.Add("PERIODO", System.Type.GetType("System.String"))
        datos.Columns.Add("CUIT", System.Type.GetType("System.String"))
        datos.Columns.Add("ACTA_RECEPCION", System.Type.GetType("System.String"))
        datos.Columns.Add("RECURSOS", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("GASTOS", System.Type.GetType("System.Decimal"))
        Return datos
    End Function

    Public Sub Nombresdecolumnas()
        If Tipo_instrumentolegal.Length > 0 Then
            listadocolumnas.Add("Tipo_instrumentolegal")
        End If
        If Numero_instrumentolegal > 0 Then
            listadocolumnas.Add("Numero_instrumentolegal")
        End If
        If Year_instrumento_legal > 0 Then
            listadocolumnas.Add("Year_instrumento_legal")
        End If
        If Total <> 0 Then
            listadocolumnas.Add("Total")
        End If
        If Detalle.Length > 0 Then
            listadocolumnas.Add("Detalle")
        End If
        If EFECTOR.Length > 0 Then
            listadocolumnas.Add("EFECTOR")
        End If
        If PERIODO.Length > 0 Then
            listadocolumnas.Add("PERIODO")
        End If
        If CUIT.Length > 0 Then
            listadocolumnas.Add("CUIT")
        End If
        If ACTA_RECEPCION.Length > 0 Then
            listadocolumnas.Add("ACTA_RECEPCION")
        End If
        If RECURSOS <> 0 Then
            listadocolumnas.Add("RECURSOS")
        End If
        If GASTOS <> 0 Then
            listadocolumnas.Add("GASTOS")
        End If
    End Sub

    Public Function DEVOLVERCANTIDADCOLUMNAS() As Integer
        Dim Valoraretornar As Integer = 0
        Nombresdecolumnas()
        Valoraretornar = listadocolumnas.Count
        Return Valoraretornar
    End Function

    Public Shared Function Estructura_SeleccionSINACTARECEPCION(Optional CLAVE_ORDENPAGO As Long = Nothing, Optional ORDENPAGO As Ordendepago = Nothing) As DataTable
        Dim datos As New DataTable
        Dim consultasql As String = ""
        If IsNothing(CLAVE_ORDENPAGO) Then
            datos = SINACTARECEPCION()
        Else
            If IsNothing(ORDENPAGO) Then
                ORDENPAGO = New Ordendepago
                ORDENPAGO.cargar_ordepago(CLAVE_ORDENPAGO)
            End If
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", CLAVE_ORDENPAGO)
            Select Case ORDENPAGO.Ordenpago_tipo
                Case Is = "ARANCELAMIENTO"
                    consultasql = "SELECT
EFECTOR,
PERIODO,
RECURSOS,
GASTOS
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "TRANSFERENCIA"
                    consultasql = "SELECT
EFECTOR,
Total
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "PAGO MULTIPLES EFECTORES"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                Detalle,
                EFECTOR,
                PERIODO,
                CUIT,
                ACTA_RECEPCION
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "RENDICIÓN"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                EFECTOR,
                PERIODO,
                RECURSOS,
                GASTOS
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "RENDICIÓN FINAL"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                EFECTOR,
                PERIODO,
                RECURSOS,
                GASTOS
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "RENDICIÓN PARCIAL"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                EFECTOR,
                PERIODO,
                RECURSOS,
                GASTOS
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "RECONOCIMIENTO"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                Detalle,
                EFECTOR,
                PERIODO,
                CUIT,
                ACTA_RECEPCION
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                Detalle,
                EFECTOR,
                PERIODO,
                CUIT,
                ACTA_RECEPCION
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "PUBLICIDAD"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                EFECTOR,
                PERIODO,
                ACTA_RECEPCION,CUIT
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "REPOSICIÓN"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                EFECTOR
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "CONTRATOS"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                EFECTOR,
                PERIODO
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "BECAS"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                EFECTOR,
                PERIODO
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Is = "COMISIÓN BANCARIA"
                    consultasql = "SELECT
Tipo_instrumentolegal,
                Numero_instrumentolegal,
                Year_instrumento_legal,
                Total,
                PERIODO
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
                Case Else
                    consultasql = "
SELECT
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumento_legal,
Total,
Detalle,
EFECTOR,
PERIODO,
CUIT,
ACTA_RECEPCION,
RECURSOS,
GASTOS
 FROM contabilidad_sinactarecepcion
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
ORDER BY INDICE ASC"
            End Select
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Return datos
    End Function

End Class

Public Class VIATICO
    Public Beneficiario As String
    Public Documento As Long
    Public Legajo As Long
    Public Periodo As String
    Public Anticipo As Decimal
    Public Devengado As Decimal
    Public Reintegrado As Decimal
    Public Total As Decimal
    Public Tipo_instrumentolegal As String
    Public Numero_instrumentolegal As Integer
    Public Year_instrumento_legal As Integer

    Public Sub New()
        Beneficiario = ""
        Documento = 0
        Legajo = 0
        Periodo = ""
        Anticipo = 0
        Devengado = 0
        Reintegrado = 0
        Total = 0
        Tipo_instrumentolegal = ""
        Numero_instrumentolegal = 0
        Year_instrumento_legal = 0
    End Sub

End Class

Public Class Ordendepago
    ' Inherits OrdenProvision
    Public expediente_op As New Expediente
    Public expediente_op2 As New Expediente
    Public Clave_ordenpago As Long 'Clave de la orden de pago
    Public ordenpago_numero As Integer ' numero de la orden de pago
    Public Ordenpago_Year As Integer ' año de la orden de pago
    Public Ordenpago_tipo As String 'Orden de pago o rendición (ver fondos permanentes)
    Public ordenpago_fecha As Date 'Fecha de la orden de pago
    Public ordenpago_Detalle As String 'descripcion basica
    Public ordenpago_Detalle2 As String ' Descripción correspondiente a los instrumentos legales
    Public ordenpago_montototal As Decimal 'monto total de la orden de pago
    Public novalido As Boolean
    'Public ClaveExpediente As Long
    Public ClaveExpediente_principal As Long
    'Public Expediente_N As String
    'Public Expediente_ORG As Integer
    'Public Expediente_NUM As Integer
    'Public Expediente_YEAR As Integer
    Public Partidas As New List(Of PartidaPresupuestaria)
    Public Partida_datatable As New DataTable
    Public HABERES_DETALLE As New DataTable
    Public VIATICOS_datatable As New DataTable
    Public provision_datatable As New DataTable
    Public SINACTAS_DATATABLE As New DataTable
    Public Haberes_liquidacionapagar As Decimal
    Public Haberes_recuperovarios As Decimal
    Public ordenpago_USUARIO As Integer
    Public DatosOrdenPago As DataTable
    Public ESTADO As String
    Public CLASE_FONDO As String
    Public ACTAS As New List(Of ACTARECEPCION)
    Public SINACTAS As New List(Of SINACTARECEPCION)
    Public ORDENESPROVISION As New List(Of OrdenProvision)
    Public VIATICOS As New List(Of VIATICO)

    Public Sub New()
        Clave_ordenpago = Nothing
        ordenpago_numero = Nothing
        Ordenpago_Year = Date.Now.Year
        ordenpago_Detalle = ""
        Haberes_liquidacionapagar = 0
        Haberes_recuperovarios = 0
        ESTADO = "ACTIVO"
        CLASE_FONDO = "EJERCICIO"
        novalido = False
        expediente_op.clear()
        expediente_op2.clear()
        'ClaveExpediente = Nothing
        'ClaveExpediente_principal = Nothing
        'Expediente_N = ""
        Partidas.Clear()
        DatosOrdenPago = New DataTable
    End Sub

    ''' <summary>
    ''' utilizado para insertar en la base de datos la orden de pago
    ''' </summary>
    Public Sub Insertar_ordenpago()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", expediente_op.claveexpediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_2", expediente_op2.claveexpediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_principal", ClaveExpediente_principal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", ordenpago_Detalle)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle2", ordenpago_Detalle2)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", ordenpago_montototal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Haberes_liquidacionapagar", Haberes_liquidacionapagar)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Haberes_recuperovarios", Haberes_recuperovarios)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", ordenpago_fecha)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipo", Ordenpago_tipo)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ESTADO", ESTADO)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CLASE_FONDO", CLASE_FONDO)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@NOVALIDO", novalido)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `Contabilidad_ordenpago` " &
            "(
clave_Ordenpago,
CLAVE_EXPEDIENTE,
Clave_expediente_2,
Clave_expediente_principal,
Detalle,
Detalle2,
Monto,
Haberes_liquidacionapagar,
Haberes_recuperovarios,
Fecha,
Tipo,
ESTADO,
CLASE_FONDO,
NOVALIDO,
USUARIO
) VALUES (
@clave_Ordenpago,
@CLAVE_EXPEDIENTE,
@Clave_expediente_2,
@Clave_expediente_principal,
@Detalle,
@Detalle2,
@Monto,
@Haberes_liquidacionapagar,
@Haberes_recuperovarios,
@Fecha,
@Tipo,
@ESTADO,
@CLASE_FONDO,
@NOVALIDO,
@USUARIO
            ) ON DUPLICATE KEY UPDATE
clave_Ordenpago=@clave_Ordenpago,
CLAVE_EXPEDIENTE=@CLAVE_EXPEDIENTE,
Clave_expediente_2=@Clave_expediente_2,
Clave_expediente_principal=@Clave_expediente_principal,
Detalle=@Detalle,
Detalle2=@Detalle2,
Monto=@Monto,
Haberes_liquidacionapagar=@Haberes_liquidacionapagar,
Haberes_recuperovarios=@Haberes_recuperovarios,
Fecha=@Fecha,
Tipo=@Tipo,
ESTADO=@ESTADO,
CLASE_FONDO=@CLASE_FONDO,
NOVALIDO=@NOVALIDO,
USUARIO=@USUARIO
"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'BORRADO DE TODAS LAS ACTAS DE RECEPCIÓN RELACIONADAS CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM Contabilidad_actasrecepcion WHERE Clave_ordenpago=@Clave_ordenpagO;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Actas de Recepcion
        If ACTAS.Count > 0 Then
            'cuando en la orden de pago existen actas de recepción
            '   SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
            For Z As Integer = 0 To ACTAS.Count - 1
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_actarecepcion", expediente_op.year & expediente_op.organismo & ACTAS.Item(Z).ACTARECEPCION_NUMERO.ToString("00000"))
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", expediente_op.claveexpediente)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", ACTAS(Z).ACTARECEPCION_CUIT)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@aNTICIPO", ACTAS.Item(Z).ACTARECEPCION_ANTICIPO)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total", ACTAS.Item(Z).ACTARECEPCION_MONTO)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", ACTAS.Item(Z).ACTARECEPCION_FECHA)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DETALLE", ACTAS.Item(Z).ACTARECEPCION_DETALLE)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@EFECTOR", ACTAS.Item(Z).ACTARECEPCION_EFECTOR)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@PERIODO", ACTAS.Item(Z).ACTARECEPCION_PERIODO)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MULTA_RESOLUCION", ACTAS.Item(Z).ACTARECEPCION_MULTA_RESOLUCION)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MULTA_MONTO", ACTAS.Item(Z).ACTARECEPCION_MULTA_MONTO)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenprovision", ACTAS.Item(Z).ACTARECEPCION_CLAVE_ORDENPROVISION)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Factura_N", "S/D")
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO  Contabilidad_actasrecepcion
(
Clave_actarecepcion,
Fecha,
Clave_expediente,
Clave_ordenpago,
Clave_ordenprovision,
DETALLE,
EFECTOR,
PERIODO,
MULTA_RESOLUCION,
MULTA_MONTO,
CUIT,
ANTICIPO,
Total,
Factura_N,
USUARIO
)
 VALUES
(
@Clave_actarecepcion,
@Fecha,
@Clave_expediente,
@Clave_ordenpago,
@Clave_ordenprovision,
@DETALLE,
@EFECTOR,
@PERIODO,
@MULTA_RESOLUCION,
@MULTA_MONTO,
@CUIT,
@ANTICIPO,
@Total,
@Factura_N,
@USUARIO
)
ON DUPLICATE KEY UPDATE
Clave_actarecepcion=@Clave_actarecepcion,
Fecha=@Fecha,
Clave_expediente=@Clave_expediente,
Clave_ordenpago=@Clave_ordenpago,
Clave_ordenprovision=@Clave_ordenprovision,
DETALLE=@DETALLE,
EFECTOR=@EFECTOR,
PERIODO=@PERIODO,
MULTA_RESOLUCION=@MULTA_RESOLUCION,
ANTICIPO=@ANTICIPO,
MULTA_MONTO=@MULTA_MONTO,
CUIT=@CUIT,
Total=@Total,
Factura_N=@Factura_N,
USUARIO=@USUARIO;"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Next
        Else
            'en caso de que no tenga actas de recepción
        End If
        'BORRADO DE TODOS LOS ITEMS DE LAS ORDENES DE PAGO SIN ACTA EN FORMA DETERMINANTE
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_sinactarecepcion WHERE Clave_ordenpago=@Clave_ordenpagO;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If SINACTAS.Count > 0 Then
            For Z As Integer = 0 To SINACTAS.Count - 1
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@INDICE", Z)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipo_instrumentolegal", SINACTAS(Z).Tipo_instrumentolegal)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Numero_instrumentolegal", SINACTAS(Z).Numero_instrumentolegal)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_instrumento_legal", SINACTAS(Z).Year_instrumento_legal)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total", SINACTAS(Z).Total)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", SINACTAS(Z).Detalle)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@EFECTOR", SINACTAS(Z).EFECTOR)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@PERIODO", SINACTAS(Z).PERIODO)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", SINACTAS(Z).CUIT)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ACTA_RECEPCION", SINACTAS(Z).ACTA_RECEPCION)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@RECURSOS", SINACTAS(Z).RECURSOS)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@GASTOS", SINACTAS(Z).GASTOS)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO  contabilidad_sinactarecepcion
(
Clave_Ordenpago,
Indice,
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumento_legal,
Total,
Detalle,
EFECTOR,
PERIODO,
CUIT,
ACTA_RECEPCION,
RECURSOS,
GASTOS,
USUARIO
)
 VALUES
(
@Clave_Ordenpago,
@Indice,
@Tipo_instrumentolegal,
@Numero_instrumentolegal,
@Year_instrumento_legal,
@Total,
@Detalle,
@EFECTOR,
@PERIODO,
@CUIT,
@ACTA_RECEPCION,
@RECURSOS,
@GASTOS,
@USUARIO
)
"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Next
        Else
            'CASO DE QUE ESTE VACIO SINACTAS
        End If
        'BORRADO DE TODOS LOS DETALLES DE HABERES QUE EXISTAN CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_ordenpago_haberesdetalle WHERE Clave_ordenpago=@Clave_ordenpagO;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'DETALLE DE HABERES
        If HABERES_DETALLE.Rows.Count > 0 Then
            'cuando en la orden de pago existen actas de recepción
            For Z As Integer = 0 To HABERES_DETALLE.Rows.Count - 1
                If (Not HABERES_DETALLE.Rows(Z).Item("IMPORTE") = 0) Or
                    (manejonothing(HABERES_DETALLE.Rows(Z).Item("SPL01")) <> 0) Or
                     (manejonothing(HABERES_DETALLE.Rows(Z).Item("SPL02")) <> 0) Or
                     (manejonothing(HABERES_DETALLE.Rows(Z).Item("SPL03")) <> 0) Or
                    (manejonothing(HABERES_DETALLE.Rows(Z).Item("SPL04")) <> 0) Or
                     (manejonothing(HABERES_DETALLE.Rows(Z).Item("SPL05")) <> 0) Or
                     (manejonothing(HABERES_DETALLE.Rows(Z).Item("SPL06")) <> 0) Or
                     (manejonothing(HABERES_DETALLE.Rows(Z).Item("SPL07")) <> 0) Then
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
                    ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_actarecepcion", expediente_op.year & expediente_op.organismo & ACTAS.Item(Z).ACTARECEPCION_NUMERO.ToString("00000"))
                    'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", expediente_op.claveexpediente)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@GRUPO", HABERES_DETALLE.Rows(Z).Item("GRUPO"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SUBGRUPO", HABERES_DETALLE.Rows(Z).Item("SUBGRUPO"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DENOMINACION", HABERES_DETALLE.Rows(Z).Item("DENOMINACION"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MONTO", HABERES_DETALLE.Rows(Z).Item("IMPORTE"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SPL01", HABERES_DETALLE.Rows(Z).Item("SPL01"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SPL02", HABERES_DETALLE.Rows(Z).Item("SPL02"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SPL03", HABERES_DETALLE.Rows(Z).Item("SPL03"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SPL04", HABERES_DETALLE.Rows(Z).Item("SPL04"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SPL05", HABERES_DETALLE.Rows(Z).Item("SPL05"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SPL06", HABERES_DETALLE.Rows(Z).Item("SPL06"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SPL07", HABERES_DETALLE.Rows(Z).Item("SPL07"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO  contabilidad_ordenpago_haberesdetalle
(
Clave_Ordenpago,
GRUPO,
SUBGRUPO,
DENOMINACION,
MONTO,
SPL01,
SPL02,
SPL03,
SPL04,
SPL05,
SPL06,
SPL07,
USUARIO
)
 VALUES
(
@Clave_Ordenpago,
@GRUPO,
@SUBGRUPO,
@DENOMINACION,
@MONTO,
@SPL01,
@SPL02,
@SPL03,
@SPL04,
@SPL05,
@SPL06,
@SPL07,
@USUARIO
)
ON DUPLICATE KEY UPDATE
Clave_Ordenpago=@Clave_Ordenpago,
GRUPO=@GRUPO,
SPL01=@SPL01,
SPL02=@SPL02,
SPL03=@SPL03,
SPL04=@SPL04,
SPL05=@SPL05,
SPL06=@SPL06,
SPL07=@SPL07,
SUBGRUPO=@SUBGRUPO,
DENOMINACION=@DENOMINACION,
MONTO=@MONTO,
USUARIO=@USUARIO;"
                    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                End If
            Next
        Else
            'en caso de que no TENGA HABERES
        End If
        'BORRADO DE TODOS LOS VIATICOS QUE EXISTAN CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_VIATICOS WHERE Clave_ordenpago=@Clave_ordenpagO;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If VIATICOS_datatable.Rows.Count > 0 Then
            For Z As Integer = 0 To VIATICOS.Count - 1
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Beneficiario", VIATICOS(Z).Beneficiario)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Documento", VIATICOS(Z).Documento)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Legajo", VIATICOS(Z).Legajo)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Periodo", VIATICOS(Z).Periodo)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Anticipo", VIATICOS(Z).Anticipo)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Devengado", VIATICOS(Z).Devengado)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Reintegrado", VIATICOS(Z).Reintegrado)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@TOTAL", VIATICOS(Z).Total)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipo_instrumentolegal", VIATICOS(Z).Tipo_instrumentolegal)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Numero_instrumentolegal", VIATICOS(Z).Numero_instrumentolegal)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_instrumento_legal", VIATICOS(Z).Year_instrumento_legal)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO  Contabilidad_viaticos
(
Clave_Ordenpago,
Beneficiario,
Documento,
Legajo,
Periodo,
Anticipo,
Devengado,
Reintegrado,
TOTAL,
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumento_legal
)
 VALUES
(
@Clave_Ordenpago,
@Beneficiario,
@Documento,
@Legajo,
@Periodo,
@Anticipo,
@Devengado,
@Reintegrado,
@TOTAL,
@Tipo_instrumentolegal,
@Numero_instrumentolegal,
@Year_instrumento_legal
)
ON DUPLICATE KEY UPDATE
Beneficiario=@Beneficiario,
Documento=@Documento,
Legajo=@Legajo,
Periodo=@Periodo,
Anticipo=@Anticipo,
Devengado=@Devengado,
Reintegrado=@Reintegrado,
TOTAL=@TOTAL,
Tipo_instrumentolegal=@Tipo_instrumentolegal,
Numero_instrumentolegal=@Numero_instrumentolegal,
Year_instrumento_legal=@Year_instrumento_legal
;"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Next
        Else
            'en caso de que no tenga actas de recepción
        End If
        'BORRADO DE TODAS LAS PARTIDAS PRESUPUESTARIAS RELACIONADAS CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_partidaexpediente WHERE Clave_ordenpago=@Clave_ordenpago and not isnull(Clave_ordenpago);"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If Partidas.Count > 0 Then
            'cuando existen partidas presupuestarias en la orden de pago
            For Each item As PartidaPresupuestaria In Partidas
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", expediente_op.claveexpediente)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@JUR", item.Jur)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@UO", item.UO)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CARAC", item.Caracter)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@FI", item.Fin)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@FUN", item.Fun)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SECC", item.Secc)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SECT", item.Sect)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@PDAPCIAL", item.PdaPcial)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@PDASUBPAR", item.PdaSubpr)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@PDAPPAL", item.PdaPPal)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SCD", item.SCD)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@IMPORTE", item.Montopartida)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO  Contabilidad_partidaexpediente
(
CLAVE_EXPEDIENTE,
Clave_ordenPago,
JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPCIAL,
PDASUBPAR,
PDAPPAL,
SCD,
IMPORTE,
USUARIO
)
 VALUES
(
@CLAVE_EXPEDIENTE,
@Clave_ordenPago,
@JUR,
@UO,
@CARAC,
@FI,
@FUN,
@SECC,
@SECT,
@PDAPPAL,
@PDASUBPAR,
@PDAPCIAL,
@SCD,
@IMPORTE,
@USUARIO
);"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Next
        Else
            'Cuando no existen  partidas presupuestarias en la orden de pago
        End If
    End Sub

    Public Sub Borrar_ORDENPAGO()
        'RENGLONES DE LA TABLA
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM CONTABILIDAD_ORDENPAGO WHERE Clave_ordenpago= @Clave_ordenpago and not isnull(Clave_ordenpago);"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'BORRADO DE TODAS LAS ACTAS DE RECEPCIÓN DE ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM Contabilidad_actasrecepcion WHERE Clave_ordenpago=@Clave_ordenpagO and not isnull(Clave_ordenpago);"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'BORRADO DE TODAS LAS ACTAS DE RECEPCIÓN DE ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_sinactarecepcion WHERE Clave_ordenpago=@Clave_ordenpagO and not isnull(Clave_ordenpago);"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'BORRADO DE TODOS LOS DETALLES DE HABERES QUE EXISTAN CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_ordenpago_haberesdetalle WHERE Clave_ordenpago=@Clave_ordenpagO and not isnull(Clave_ordenpago);"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'BORRADO DE TODOS LOS VIATICOS QUE EXISTAN CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_VIATICOS WHERE Clave_ordenpago=@Clave_ordenpagO;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'BORRADO DE TODAS LAS PARTIDAS RELACIONADAS CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_partidaexpediente WHERE Clave_ordenpago=@Clave_ordenpago and not isnull(Clave_ordenpago);"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'BORRADO DE TODAS LAS ORDENES DE PROVISIÓN RELACIONADAS CON ESTA ORDEN DE PAGO
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM CONTABILIDAD_ORDENPAGO_PROVISION WHERE Clave_ordenpago=@Clave_ordenpago and not isnull(Clave_ordenpago);"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Public Sub cargar_ordepago(ByVal Clave_ordenpagos As Long)
        Dim datos As New DataTable
        Dim datosdetalle As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpagos)
        Dim consultasql As String = "Select
concat(cast(substring(Clave_ordenpago from 9 for 5) as unsigned),'/',cast(substring(Clave_ordenpago from 1 for 4) as unsigned)) as 'ordenpago' ,
clave_Ordenpago,
clave_expediente,
clave_expediente_principal,
clave_expediente_2,
Detalle,
detalle2,
Monto,
Haberes_liquidacionapagar,
Haberes_recuperovarios,
Fecha,
tipo,
ESTADO,
CLASE_FONDO,NOVALIDO,
USUARIO,
Creado_o_modificado,
Tipo
from Contabilidad_ordenpago where Clave_ordenpago=@Clave_ordenpago"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Clave_ordenpago = Clave_ordenpagos
        ordenpago_numero = CType(Clave_ordenpagos.ToString.Substring(8, 5), Int32)
        Ordenpago_Year = CType(Clave_ordenpagos.ToString.Substring(0, 4), UInteger)
        If datos.Rows.Count > 0 Then
            expediente_op.claveexpediente = datos.Rows(0).Item("clave_expediente")
            If Not IsDBNull(datos.Rows(0).Item("clave_expediente_principal")) Then
                ClaveExpediente_principal = datos.Rows(0).Item("clave_expediente_principal")
            Else
                ClaveExpediente_principal = 0
            End If
            If Not IsDBNull(datos.Rows(0).Item("clave_expediente_2")) Then
                expediente_op2.claveexpediente = datos.Rows(0).Item("clave_expediente_2")
            Else
                expediente_op2.claveexpediente = 0
            End If
            If Not IsDBNull(datos.Rows(0).Item("Detalle")) Then
                ordenpago_Detalle = datos.Rows(0).Item("Detalle")
            Else
                ordenpago_Detalle = ""
            End If
            If Not IsDBNull(datos.Rows(0).Item("Detalle2")) Then
                ordenpago_Detalle2 = datos.Rows(0).Item("Detalle2")
            Else
                ordenpago_Detalle2 = ""
            End If
            Haberes_liquidacionapagar = datos.Rows(0).Item("Haberes_liquidacionapagar")
            Haberes_recuperovarios = datos.Rows(0).Item("Haberes_recuperovarios")
            ordenpago_montototal = datos.Rows(0).Item("Monto")
            ordenpago_fecha = datos.Rows(0).Item("fecha")
            ordenpago_USUARIO = datos.Rows(0).Item("usuario")
            Ordenpago_tipo = datos.Rows(0).Item("Tipo")
            ESTADO = datos.Rows(0).Item("ESTADO")
            CLASE_FONDO = datos.Rows(0).Item("CLASE_FONDO")
            novalido = datos.Rows(0).Item("NOVALIDO")
            expediente_op.Cargar_expediente(expediente_op.claveexpediente)
            HABERES_DETALLE = Me.Cargar_Haberes_Estructura_detalles(Me.Clave_ordenpago)
            VIATICOS_datatable = Me.Estructura_SeleccionVIATICOS(Me.Clave_ordenpago)
            Datatable_A_VIATICOS(VIATICOS_datatable)
            Datatable_a_ACTAS(OrdenProvision.Estructura_Seleccionordenprovision(Clave_ordenpago))
            Partida_datatable = (PartidaPresupuestaria.estructurapartidadatatable(Clave_ordenpago))
            DatosOrdenPago = Partida_datatable
            Datatable_A_OPROVISION(OrdenProvision.Estructura_Seleccionordenprovision(Clave_ordenpago))
            'SINACTAS.Clear()
            'Datatable_a_SINACTAS(CType(Datos_Ordenesprovision.DataSource, DataTable))
        End If
    End Sub

    Public Sub dialogo_seleccion_orden()
        Dim datos As New DataTable
        datos.Columns.Add("TIPO DE ORDEN DE PAGO", System.Type.GetType("System.String"))
        datos.Columns.Add("DESCRIPCIÓN", System.Type.GetType("System.String"))
        datos.Rows.Add({"PAGO", "ORDEN DE PAGO PARA PROVEEDORES"})
        datos.Rows.Add({"HABERES", "ORDEN DE PAGO PARA HABERES"})
        datos.Rows.Add({"RENDICIÓN", "***EN CONSTRUCCIÓN***"})
    End Sub

    Public Shared Function Buscarmaximo_ordenpago(ByVal Year As Integer) As Int16
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Year_ordenpago", Year)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                             "Select max( cast(substring(Clave_ordenpago from 9 for 13) as unsigned)) as 'Num' from Contabilidad_ordenpago
where cast(substring(Clave_ordenpago from 1 for 4) as unsigned)=@Year_ordenpago",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(temporal.Rows(0).Item(0))
            Case True
                Return 0
            Case False
                Return Convert.ToInt16(temporal.Rows(0).Item(0))
        End Select
    End Function

    Public Shared Function AGREGARMAXIMO_ordenpago(ByVal Year As Integer) As Int16
        Dim VALOR As Int16 = 0
        VALOR = Buscarmaximo_ordenpago(Year) + 1
        Return VALOR
    End Function

    Public Shared Function verificarexistencia(ByVal Clave_ordenpagos As Long) As Boolean
        Dim temporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Year_ordenpago", Year)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpagos)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                             "Select CLAVE_ORDENPAGO from Contabilidad_ordenpago
where CLAVE_ORDENPAGO=@Clave_ordenpago",
                             temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case temporal.Rows.Count
            Case Is = 0
                Return False
            Case Else
                Return True
        End Select
    End Function

    Public Function Expedientes_hijos(ByVal clave_expediente_principal As Long) As DataTable
        Dim datos As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_principal", clave_expediente_principal)
        Dim consultasql As String = "Select Exp,detalle,Monto,op,tipo from
(Select CLAVE_TO_EXPEDIENTE(clave_expediente) as 'Exp',clave_expediente,detalle,Monto from
Expediente where clave_expediente in
(select clave_expediente from contabilidad_ordenpago where clave_expediente_principal=@clave_expediente_principal))Expedientes
left join
(Select CLAVE_TO_NUMEROYANIO(Clave_Ordenpago) as 'OP',clave_expediente,tipo,usuario from contabilidad_ordenpago)ordenpago
on expedientes.clave_expediente=ordenpago.CLAVE_EXPEDIENTE"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return datos
    End Function

    Public Sub Datatable_a_Partidas()
        Dim partidatemporal As New PartidaPresupuestaria
        Partidas.Clear()
        For x = 0 To Partida_datatable.Rows.Count - 1
            If Not Partida_datatable.Rows(x).RowState = DataRowState.Deleted Then
                partidatemporal = New PartidaPresupuestaria
                partidatemporal.Jur = manejonothing(Partida_datatable.Rows(x).Item(0))
                partidatemporal.UO = manejonothing(Partida_datatable.Rows(x).Item(1))
                partidatemporal.Caracter = manejonothing(Partida_datatable.Rows(x).Item(2))
                partidatemporal.Fin = manejonothing(Partida_datatable.Rows(x).Item(3))
                partidatemporal.Fun = manejonothing(Partida_datatable.Rows(x).Item(4))
                partidatemporal.Secc = manejonothing(Partida_datatable.Rows(x).Item(5))
                partidatemporal.Sect = manejonothing(Partida_datatable.Rows(x).Item(6))
                partidatemporal.PdaPcial = manejonothing(Partida_datatable.Rows(x).Item(7))
                partidatemporal.PdaPPal = manejonothing(Partida_datatable.Rows(x).Item(8))
                partidatemporal.SCD = manejonothing(Partida_datatable.Rows(x).Item(9))
                partidatemporal.PdaSubpr = manejonothing(Partida_datatable.Rows(x).Item(10))
                partidatemporal.Montopartida = Partida_datatable.Rows(x).Item(11)
                Partidas.Add(partidatemporal)
            End If
        Next
        'For Each row In Partida_datatable.Rows
        '    partidatemporal.clear()
        '    partidatemporal.Jur = manejonothing(row(0))
        '    partidatemporal.UO = manejonothing(row(1))
        '    partidatemporal.Caracter = manejonothing(row(2))
        '    partidatemporal.Fin = manejonothing(row(3))
        '    partidatemporal.Fun = manejonothing(row(4))
        '    partidatemporal.Secc = manejonothing(row(5))
        '    partidatemporal.Sect = manejonothing(row(6))
        '    partidatemporal.PdaPcial = manejonothing(row(7))
        '    partidatemporal.PdaPPal = manejonothing(row(8))
        '    partidatemporal.PdaSubpr = manejonothing(row(9))
        '    partidatemporal.Montopartida = row(10)
        '    Partidas.Add(partidatemporal)
        'Next
    End Sub

    Public Sub Datatable_A_OPROVISION(ByVal TABLA As DataTable)
        ORDENESPROVISION.Clear()
        For x = 0 To TABLA.Rows.Count - 1
            If Not TABLA.Rows(x).RowState = DataRowState.Deleted Then
                If Not IsDBNull(TABLA.Rows(x).Item("Orden_Provision")) Then
                    clave = Split(TABLA.Rows(x).Item("Orden_Provision"), "/").Skip(1).FirstOrDefault
                    clave += Autorizaciones.Organismo
                    clave += CType(Split(TABLA.Rows(x).Item("Orden_Provision"), "/").FirstOrDefault, Integer).ToString("00000")
                    ORDENESPROVISION.Add(New OrdenProvision)
                    ORDENESPROVISION.Item(ORDENESPROVISION.Count - 1).cargar_OP(CType(clave, Long))
                End If
            End If
        Next
    End Sub

    Public Sub Datatable_A_VIATICOS(ByVal TABLA As DataTable)
        VIATICOS.Clear()
        Dim VIATICO_TEMPORAL As New VIATICO
        For x = 0 To TABLA.Rows.Count - 1
            VIATICO_TEMPORAL = New VIATICO
            If Not TABLA.Rows(x).RowState = DataRowState.Deleted Then
                If Not IsDBNull(TABLA.Rows(x).Item("DOCUMENTO")) Then
                    VIATICO_TEMPORAL.Beneficiario = TABLA.Rows(x).Item("BENEFICIARIO")
                    VIATICO_TEMPORAL.Documento = TABLA.Rows(x).Item("DOCUMENTO")
                    VIATICO_TEMPORAL.Legajo = TABLA.Rows(x).Item("LEGAJO")
                    VIATICO_TEMPORAL.Periodo = TABLA.Rows(x).Item("PERIODO")
                    VIATICO_TEMPORAL.Anticipo = manejonothing(TABLA.Rows(x).Item("ANTICIPO"))
                    VIATICO_TEMPORAL.Devengado = manejonothing(TABLA.Rows(x).Item("DEVENGADO"))
                    VIATICO_TEMPORAL.Reintegrado = manejonothing(TABLA.Rows(x).Item("REINTEGRADO"))
                    VIATICO_TEMPORAL.Total = manejonothing(TABLA.Rows(x).Item("TOTAL"))
                    VIATICO_TEMPORAL.Tipo_instrumentolegal = manejonothing(TABLA.Rows(x).Item("Tipo_instrumentolegal"))
                    VIATICO_TEMPORAL.Numero_instrumentolegal = manejonothing(TABLA.Rows(x).Item("Numero_instrumentolegal"))
                    VIATICO_TEMPORAL.Year_instrumento_legal = manejonothing(TABLA.Rows(x).Item("Year_instrumento_legal"))
                    VIATICOS.Add(VIATICO_TEMPORAL)
                End If
            End If
        Next
    End Sub

    Public Shared Function VIATICOSVACIO() As DataTable
        Dim datos As New DataTable
        '        Clave_Ordenpago bigint
        datos.Columns.Add("Beneficiario", System.Type.GetType("System.String"))
        datos.Columns.Add("Documento", System.Type.GetType("System.Int32"))
        datos.Columns.Add("Legajo", System.Type.GetType("System.Int32"))
        datos.Columns.Add("Anticipo", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("Devengado", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("Reintegrado", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("TOTAL", System.Type.GetType("System.Decimal"))
        datos.Columns.Add("Tipo_instrumentolegal", System.Type.GetType("System.String"))
        datos.Columns.Add("Numero_instrumentolegal", System.Type.GetType("System.Int32"))
        datos.Columns.Add("Year_instrumento_legal", System.Type.GetType("System.Int32"))
        Return datos
    End Function

    Public Shared Function Estructura_SeleccionVIATICOS(Optional CLAVE_ORDENPAGO As Long = Nothing) As DataTable
        Dim datos As New DataTable
        If IsNothing(CLAVE_ORDENPAGO) Then
            datos = VIATICOSVACIO()
        Else
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", CLAVE_ORDENPAGO)
            Dim consultasql As String = "
SELECT
Beneficiario,
Documento,
Legajo,
Periodo,
Anticipo,
Devengado,
Reintegrado,
TOTAL,
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumento_legal
 FROM contabilidad_viaticos
WHERE Clave_Ordenpago=@CLAVE_ORDENPAGO
order by Beneficiario asc
"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Return datos
    End Function

    Public Sub Datatable_a_insertarordenesprovision(ByVal tabla As DataTable)
        Dim temporal As New DataTable
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Me.Clave_ordenpago)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM contabilidad_ordenpago_provision WHERE Clave_ordenpago= @Clave_ordenpago;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        For x = 0 To tabla.Rows.Count - 1
            If Not tabla.Rows(x).RowState = DataRowState.Deleted Then
                If Not (
                    IsDBNull(tabla.Rows(x).Item("ACTA_RECEPCION")) Or IsDBNull(tabla.Rows(x).Item("Orden_Provision"))
                    ) Then
                    'BORRADO DE TODAS LAS ORDENES DE PROVISIÓN RELACIONADAS CON ESTA ORDEN DE PAGO
                    'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Clave_ordenpago)
                    'SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM CONTABILIDAD_ORDENPAGO_PROVISION WHERE Clave_ordenpago=@Clave_ordenpago and not isnull(Clave_ordenpago);"
                    'Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", Me.Clave_ordenpago)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_ordenprovision", CType(Split(tabla.Rows(x).Item("Orden_Provision"), "/").Skip(1).FirstOrDefault &
                                                                           Autorizaciones.Organismo &
                                                                           CType(Split(CType(tabla.Rows(x).Item("Orden_Provision"), String), "/").FirstOrDefault, Integer).ToString("00000"), String))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_actarecepcion", CType(Split(tabla.Rows(x).Item("ACTA_RECEPCION"), "/").Skip(1).FirstOrDefault &
                                                                           Me.expediente_op.organismo &
                                                                           CType(Split(CType(tabla.Rows(x).Item("ACTA_RECEPCION"), String), "/").FirstOrDefault, Integer).ToString("00000"), String))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", Me.ordenpago_fecha)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `contabilidad_ordenpago_provision` " &
                    "(
Clave_ordenpago,
clave_ordenprovision,
clave_actarecepcion,
Fecha,
usuario)
values
(@Clave_ordenpago,
@clave_ordenprovision,
@clave_actarecepcion,
@Fecha,
@usuario)
 ON DUPLICATE KEY UPDATE
clave_Ordenpago=@clave_Ordenpago,
clave_ordenprovision=@clave_ordenprovision,
clave_actarecepcion=@clave_actarecepcion,
Fecha=@Fecha,
USUARIO=@USUARIO
"
                    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    temporal.Clear()
                    'verificar si esa orden de provisión existe dentro de suministros, si no es así crearla, esta solución debería ser temporal.
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_ordenprovision", CType(Split(tabla.Rows(x).Item("Orden_Provision"), "/").Skip(1).FirstOrDefault &
                                                                           Autorizaciones.Organismo &
                                                                           CType(Split(CType(tabla.Rows(x).Item("Orden_Provision"), String), "/").FirstOrDefault, Integer).ToString("00000"), String))
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                                         "Select clave_ordenprovision from suministros_orden_provision where  clave_ordenprovision=@clave_ordenprovision",
                                         temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    If temporal.Rows.Count = 0 Then
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_ordenprovision", CType(Split(tabla.Rows(x).Item("Orden_Provision"), "/").Skip(1).FirstOrDefault &
                                                                               Autorizaciones.Organismo &
                                                                               CType(Split(CType(tabla.Rows(x).Item("Orden_Provision"), String), "/").FirstOrDefault, Integer).ToString("00000"), String))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Me.expediente_op.claveexpediente)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", Me.ordenpago_fecha)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@INICIADOR", "CARGA AUTOMÁTICA CONTABILIDAD")
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DESTINO", Me.ordenpago_Detalle)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipo_origen", tabla.Rows(x).Item("Tipo_origen"))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Numero_origen", CType(Split(CType(tabla.Rows(x).Item("NUM_ORIGEN"), String), "/").FirstOrDefault, Integer))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_origen", CType(Split(CType(tabla.Rows(x).Item("NUM_ORIGEN"), String), "/").Skip(1).FirstOrDefault, Integer))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_origen", Me.ordenpago_fecha)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", tabla.Rows(0).Item("CUIT"))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipo_instrumentolegal", tabla.Rows(x).Item("TIPO_LEGAL"))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Numero_instrumentolegal", CType(Split(CType(tabla.Rows(x).Item("Num_instrumento"), String), "/").FirstOrDefault, Integer))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_instrumentolegal", CType(Split(CType(tabla.Rows(x).Item("Num_instrumento"), String), "/").Skip(1).FirstOrDefault, Integer))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_instrumentolegal", Me.ordenpago_fecha)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total", CType(tabla.Rows(x).Item("monto"), Decimal))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Lugar_entrega", "DEPTO PATRIMONIO")
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@valor_tiempoentrega", 5)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Unidad_tiempoentrega", "DÍAS")
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fecharealizada_ordenprovision", Me.ordenpago_fecha)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fechaconfeccionada_ordenprovision", Me.ordenpago_fecha)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `suministros_orden_provision` " &
                        "(
Clave_expediente,
Clave_ordenprovision,
INICIADOR,
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
fecharealizada_ordenprovision,
Fechaconfeccionada_ordenprovision,
USUARIO
 )
values
(@Clave_expediente,
@Clave_ordenprovision,
@INICIADOR,
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
@fecharealizada_ordenprovision,
@Fechaconfeccionada_ordenprovision,
@USUARIO)
  "
                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    End If
                End If
            End If
        Next
    End Sub

    Private Function manejonothing(ByVal elemento As Object) As Object
        Dim valorretornado
        If IsNothing(elemento) Then
            If IsDBNull(elemento) Then
                valorretornado = 0
            Else
                valorretornado = ""
            End If
        Else
            If IsNumeric(elemento) Then
                valorretornado = elemento
            Else
                valorretornado = elemento.ToString
            End If
        End If
        Return valorretornado
    End Function

    'Private Function manejonothingdecimal(ByVal elemento As Object) As Decimal
    '    Dim valorretornado As Decimal = 0
    '    If IsNothing(elemento) Or IsDBNull(elemento) Then
    '        valorretornado = 0
    '    Else
    '        valorretornado = elemento
    '    End If
    '    Return valorretornado
    'End Function
    Public Sub Datatable_a_ACTAS(ByVal tablatemporal As DataTable)
        Dim ACTA_TEMPORAL As New ACTARECEPCION
        Dim CLAVE_ORDENPROV As String
        For Each row As DataRow In tablatemporal.Rows
            ACTA_TEMPORAL = New ACTARECEPCION
            If Not row.RowState = DataRowState.Deleted Then
                If Not (IsDBNull(row.Item("ACTA_RECEPCION")) Or IsDBNull(row.Item("FECHA_ACTA")) Or IsDBNull(row.Item("CUIT"))) Then
                    For X = 0 To tablatemporal.Columns.Count - 1
                        Select Case CType(row, DataRow).Item(X).GetType.FullName
                            Case Is = "System.String"
                                If IsDBNull(row(X)) Then
                                    row(X) = ""
                                End If
                            Case Else
                        End Select
                    Next
                    ACTA_TEMPORAL.ACTARECEPCION_CUIT = row.Item("CUIT")
                    ACTA_TEMPORAL.ACTARECEPCION_DETALLE = manejonothing(row.Item("DETALLE_ACTA"))
                    ACTA_TEMPORAL.ACTARECEPCION_FECHA = row.Item("FECHA_ACTA")
                    ACTA_TEMPORAL.ACTARECEPCION_ANTICIPO = manejonothing(row.Item("MONTO_ANTICIPO"))
                    ACTA_TEMPORAL.ACTARECEPCION_MONTO = manejonothing(row.Item("MONTO_ACTA"))
                    ACTA_TEMPORAL.ACTARECEPCION_NUMERO = CType(Split(row.Item("ACTA_RECEPCION"), "/").FirstOrDefault, Integer).ToString("00000")
                    ACTA_TEMPORAL.ACTARECEPCION_YEAR = Split(row.Item("ACTA_RECEPCION"), "/").Skip(1).FirstOrDefault
                    ACTA_TEMPORAL.ACTARECEPCION_EFECTOR = manejonothing(row.Item("EFECTOR"))
                    ACTA_TEMPORAL.ACTARECEPCION_PERIODO = manejonothing(row.Item("PERIODO"))
                    ACTA_TEMPORAL.ACTARECEPCION_MULTA_MONTO = manejonothing(row.Item("MULTA_MONTO"))
                    ACTA_TEMPORAL.ACTARECEPCION_MULTA_RESOLUCION = manejonothing(row.Item("MULTA_RESOLUCION"))
                    If Not IsDBNull(row.Item("Orden_Provision")) Then
                        CLAVE_ORDENPROV = Split(row.Item("Orden_Provision"), "/").Skip(1).FirstOrDefault
                        CLAVE_ORDENPROV += Autorizaciones.Organismo
                        CLAVE_ORDENPROV += CType(Split(row.Item("Orden_Provision"), "/").FirstOrDefault, Integer).ToString("00000")
                    Else
                        CLAVE_ORDENPROV = "0"
                    End If
                    ACTA_TEMPORAL.ACTARECEPCION_CLAVE_ORDENPROVISION = CType(CLAVE_ORDENPROV, Long)
                    ACTAS.Add(ACTA_TEMPORAL)
                End If
            End If
        Next
    End Sub

    Public Function SINACTAS_CANTIDADCOLUMNAS() As Integer
        Dim MAXIMOCOLUMNAS As Integer = 0
        Dim COLUMNASACTUALES As Integer = 0
        For Each SINACTA_ITEM As SINACTARECEPCION In SINACTAS
            COLUMNASACTUALES = SINACTA_ITEM.DEVOLVERCANTIDADCOLUMNAS()
            If COLUMNASACTUALES > MAXIMOCOLUMNAS Then
                MAXIMOCOLUMNAS = COLUMNASACTUALES
            End If
        Next
        Return MAXIMOCOLUMNAS
    End Function

    Public Function SINACTAS_NOMBRESCOLUMNAS() As List(Of String)
        Dim NOMBREDECOLUMNAS As New List(Of String)
        Select Case Me.Ordenpago_tipo
            Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                NOMBREDECOLUMNAS.AddRange({"EFECTOR", "DETALLE", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
            Case Is = "REDETERMINACIÓN"
                NOMBREDECOLUMNAS.AddRange({"EFECTOR", "DETALLE", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
            Case Is = "RECONOCIMIENTO"
                NOMBREDECOLUMNAS.AddRange({"EFECTOR", "DETALLE", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
            Case Is = "REPOSICIÓN"
                'NOMBREDECOLUMNAS.AddRange({"EFECTOR", "DETALLE", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
            Case Is = "PUBLICIDAD"
                NOMBREDECOLUMNAS.AddRange({"EFECTOR", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
            Case Is = "CONTRATOS"
            Case Is = "BECAS"
            Case Is = "COMISIÓN BANCARIA"
            Case Else
        End Select
        For Each SINACTA_ITEM As SINACTARECEPCION In SINACTAS
            '  SINACTA_ITEM.Nombresdecolumnas()
            Select Case Me.Ordenpago_tipo
                Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                    'NOMBREDECOLUMNAS.AddRange({"EFECTOR", "DETALLE", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
                Case Is = "RECONOCIMIENTO"
                Case Is = "PUBLICIDAD"
                    'NOMBREDECOLUMNAS.AddRange({"EFECTOR", "DETALLE", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
                Case Is = "CONTRATOS"
                Case Is = "REPOSICIÓN"
                'NOMBREDECOLUMNAS.AddRange({"EFECTOR", "DETALLE", "PERIODO", "ACTA_RECEPCION", "TOTAL"})
                Case Is = "BECAS"
                Case Is = "COMISIÓN BANCARIA"
                Case Else
                    For Each ITEM As String In SINACTA_ITEM.listadocolumnas
                        If Not NOMBREDECOLUMNAS.Contains(ITEM, StringComparer.OrdinalIgnoreCase) Then
                            NOMBREDECOLUMNAS.Add(ITEM)
                        End If
                    Next
            End Select
        Next
        Return NOMBREDECOLUMNAS
    End Function

    Public Function VIATICOS_NOMBRESCOLUMNAS() As List(Of String)
        Dim NOMBREDECOLUMNAS As New List(Of String)
        NOMBREDECOLUMNAS.Add("Beneficiario")
        NOMBREDECOLUMNAS.Add("Documento")
        NOMBREDECOLUMNAS.Add("Legajo")
        NOMBREDECOLUMNAS.Add("Período")
        NOMBREDECOLUMNAS.Add("Anticipo")
        NOMBREDECOLUMNAS.Add("Devengado")
        NOMBREDECOLUMNAS.Add("Reintegrado")
        NOMBREDECOLUMNAS.Add("Total")
        Return NOMBREDECOLUMNAS
    End Function

    Public Sub Datatable_a_SINACTAS(ByVal tablatemporal As DataTable)
        Dim SINACTA_TEMPORAL As New SINACTARECEPCION
        SINACTAS_DATATABLE = tablatemporal
        Dim INDICES As Integer = 0
        For Each row As DataRow In tablatemporal.Rows
            SINACTA_TEMPORAL = New SINACTARECEPCION
            If Not row.RowState = DataRowState.Deleted Then
                If Me.Ordenpago_tipo = "VIÁTICOS" Then
                    INDICES += 1
                    ' Beneficiario,
                    'Documento,
                    'Legajo,
                    'Periodo,
                    'Anticipo,
                    'Devengado,
                    'Reintegrado,
                    'TOTAL
                    'SINACTA_TEMPORAL.Clave_Ordenpago = Me.Clave_ordenpago
                    'SINACTA_TEMPORAL.Indice = INDICES
                    'SINACTA_TEMPORAL.Tipo_instrumentolegal = ""
                    'SINACTA_TEMPORAL.Numero_instrumentolegal = ""
                    'SINACTA_TEMPORAL.Year_instrumento_legal = ""
                    'SINACTA_TEMPORAL.Total = manejonothing(row.Item("Total"))
                    'SINACTA_TEMPORAL.Detalle = manejonothing(row.Item("Detalle"))
                    'SINACTA_TEMPORAL.EFECTOR = manejonothing(row.Item("EFECTOR"))
                    'SINACTA_TEMPORAL.PERIODO = manejonothing(row.Item("PERIODO"))
                    'SINACTA_TEMPORAL.CUIT = manejonothing(row.Item("cuit"))
                    'SINACTA_TEMPORAL.ACTA_RECEPCION = manejonothing(row.Item("ACTA_RECEPCION"))
                    'SINACTA_TEMPORAL.RECURSOS = manejonothing(row.Item("RECURSOS"))
                    'SINACTA_TEMPORAL.GASTOS = manejonothing(row.Item("GASTOS"))
                    ''SINACTA_TEMPORAL.USUARIO = manejonothing(row.Item("USUARIO"))
                    'SINACTAS.Add(SINACTA_TEMPORAL)
                Else
                    INDICES += 1
                    SINACTA_TEMPORAL.Clave_Ordenpago = Me.Clave_ordenpago
                    SINACTA_TEMPORAL.Indice = INDICES
                    SINACTA_TEMPORAL.Tipo_instrumentolegal = Retornarvalores("Tipo_instrumentolegal", row)
                    ' manejonothing(row.Item("Tipo_instrumentolegal"))
                    SINACTA_TEMPORAL.Numero_instrumentolegal = Retornarvalores("Numero_instrumentolegal", row)
                    ' manejonothing(row.Item("Numero_instrumentolegal"))
                    SINACTA_TEMPORAL.Year_instrumento_legal = Retornarvalores("Year_instrumento_legal", row)
                    '  manejonothing(row.Item("Year_instrumento_legal"))
                    SINACTA_TEMPORAL.Total = Retornarvalores("Total", row)
                    '  manejonothing(row.Item("Total"))
                    SINACTA_TEMPORAL.Detalle = Retornarvalores("Detalle", row)
                    '  manejonothing(row.Item("Detalle"))
                    SINACTA_TEMPORAL.EFECTOR = Retornarvalores("EFECTOR", row)
                    '  manejonothing(row.Item("EFECTOR"))
                    SINACTA_TEMPORAL.PERIODO = Retornarvalores("PERIODO", row)
                    ' manejonothing(row.Item("PERIODO"))
                    SINACTA_TEMPORAL.CUIT = Retornarvalores("cuit", row)
                    ' manejonothing(row.Item("cuit"))
                    SINACTA_TEMPORAL.ACTA_RECEPCION = Retornarvalores("ACTA_RECEPCION", row)
                    '  manejonothing(row.Item("ACTA_RECEPCION"))
                    SINACTA_TEMPORAL.RECURSOS = Retornarvalores("RECURSOS", row)
                    '  manejonothing(row.Item("RECURSOS"))
                    SINACTA_TEMPORAL.GASTOS = Retornarvalores("GASTOS", row)
                    '  manejonothing(row.Item("GASTOS"))
                    'SINACTA_TEMPORAL.USUARIO = manejonothing(row.Item("USUARIO"))
                    SINACTAS.Add(SINACTA_TEMPORAL)
                End If
            End If
        Next
    End Sub

    Private Function Retornarvalores(ByVal nombrecolumna As String, ByVal row As DataRow) As Object
        Dim valor
        If row.Table.Columns.Contains(nombrecolumna) Then
            valor = manejonothing(row.Item(nombrecolumna))
        Else
            valor = vbNull
        End If
        Return valor
    End Function

    Public Sub Datatable_a_SINACTAS_ARANCELAMIENTO(ByVal tablatemporal As DataTable)
        Dim SINACTA_TEMPORAL As New SINACTARECEPCION
        SINACTAS_DATATABLE = tablatemporal
        Dim INDICES As Integer = 0
        For Each row As DataRow In tablatemporal.Rows
            SINACTA_TEMPORAL = New SINACTARECEPCION
            If Not row.RowState = DataRowState.Deleted Then
                INDICES += 1
                SINACTA_TEMPORAL.Clave_Ordenpago = Me.Clave_ordenpago
                SINACTA_TEMPORAL.Indice = INDICES
                SINACTA_TEMPORAL.Tipo_instrumentolegal = ""
                SINACTA_TEMPORAL.Numero_instrumentolegal = Nothing
                SINACTA_TEMPORAL.Year_instrumento_legal = Nothing
                'SINACTA_TEMPORAL.Total = manejonothing(row.Item("Total"))
                'SINACTA_TEMPORAL.Detalle = manejonothing(row.Item("Detalle"))
                'SINACTA_TEMPORAL.EFECTOR = manejonothing(row.Item("EFECTOR"))
                'SINACTA_TEMPORAL.PERIODO = manejonothing(row.Item("PERIODO"))
                'SINACTA_TEMPORAL.CUIT = manejonothing(row.Item("cuit"))
                'SINACTA_TEMPORAL.ACTA_RECEPCION = manejonothing(row.Item("ACTA_RECEPCION"))
                'SINACTA_TEMPORAL.RECURSOS = manejonothing(row.Item("RECURSOS"))
                'SINACTA_TEMPORAL.GASTOS = manejonothing(row.Item("GASTOS"))
                SINACTA_TEMPORAL.Tipo_instrumentolegal = Retornarvalores("Tipo_instrumentolegal", row)
                ' manejonothing(row.Item("Tipo_instrumentolegal"))
                SINACTA_TEMPORAL.Numero_instrumentolegal = Retornarvalores("Numero_instrumentolegal", row)
                ' manejonothing(row.Item("Numero_instrumentolegal"))
                SINACTA_TEMPORAL.Year_instrumento_legal = Retornarvalores("Year_instrumento_legal", row)
                '  manejonothing(row.Item("Year_instrumento_legal"))
                SINACTA_TEMPORAL.Total = Retornarvalores("Total", row)
                '  manejonothing(row.Item("Total"))
                SINACTA_TEMPORAL.Detalle = Retornarvalores("Detalle", row)
                '  manejonothing(row.Item("Detalle"))
                SINACTA_TEMPORAL.EFECTOR = Retornarvalores("EFECTOR", row)
                '  manejonothing(row.Item("EFECTOR"))
                SINACTA_TEMPORAL.PERIODO = Retornarvalores("PERIODO", row)
                ' manejonothing(row.Item("PERIODO"))
                SINACTA_TEMPORAL.CUIT = Retornarvalores("cuit", row)
                ' manejonothing(row.Item("cuit"))
                SINACTA_TEMPORAL.ACTA_RECEPCION = Retornarvalores("ACTA_RECEPCION", row)
                '  manejonothing(row.Item("ACTA_RECEPCION"))
                SINACTA_TEMPORAL.RECURSOS = Retornarvalores("RECURSOS", row)
                '  manejonothing(row.Item("RECURSOS"))
                SINACTA_TEMPORAL.GASTOS = Retornarvalores("GASTOS", row)
                '  manejonothing(row.Item("GASTOS"))
                'SINACTA_TEMPORAL.USUARIO = manejonothing(row.Item("USUARIO"))
                SINACTAS.Add(SINACTA_TEMPORAL)
                'SINACTA_TEMPORAL.USUARIO = manejonothing(row.Item("USUARIO"))
                'SINACTAS.Add(SINACTA_TEMPORAL)
            End If
        Next
    End Sub

    Public Shared Function Cargar_Haberes_Estructura_detalles(Optional ByVal clave_ordenpago As Long = 0) As DataTable
        Dim datos As New DataTable
        If clave_ordenpago = 0 Then
            datos.Columns.Add("GRUPO", System.Type.GetType("System.String"))
            datos.Columns.Add("SUBGRUPO", System.Type.GetType("System.String"))
            datos.Columns.Add("DENOMINACION", System.Type.GetType("System.String"))
            datos.Columns.Add("IMPORTE", System.Type.GetType("System.Decimal"))
        Else
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", clave_ordenpago)
            Dim consultasql As String = "SELECT
a.GRUPO,
a.SUBGRUPO,
a.DENOMINACION,
case when isnull(monto) then 0 else Monto END as 'IMPORTE',
case when isnull(SPL01) then 0 else SPL01 END as 'SPL01',
case when isnull(SPL02) then 0 else SPL02 END as 'SPL02',
case when isnull(SPL03) then 0 else SPL03 END as 'SPL03',
case when isnull(SPL04) then 0 else SPL04 END as 'SPL04',
case when isnull(SPL05) then 0 else SPL05 END as 'SPL05',
case when isnull(SPL06) then 0 else SPL06 END as 'SPL06',
case when isnull(SPL07) then 0 else SPL07 END as 'SPL07'
from
(Select GRUPO,SUBGRUPO,DENOMINACION,INDICE FROM
contabilidad_categoriassueldo
UNION ALL
Select GRUPO,SUBGRUPO,DENOMINACION,999 AS 'INDICE' FROM
contabilidad_ordenpago_haberesdetalle where Clave_Ordenpago=@clave_ordenpago AND
CONCAT(GRUPO,SUBGRUPO,DENOMINACION) NOT IN (Select CONCAT(GRUPO,SUBGRUPO,DENOMINACION) FROM
contabilidad_categoriassueldo)
)A
left  JOIN
(Select * from contabilidad_ordenpago_haberesdetalle where Clave_Ordenpago=@clave_ordenpago )B
on
concat(A.GRUPO, A.SUBGRUPO, A.DENOMINACION)=concat(B.GRUPO, B.SUBGRUPO, B.DENOMINACION)
ORDER BY A.INDICE ASC
"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Return datos
    End Function

    Public Shared Function CargarHaberesCALCULOSAUXILIARES(Optional ByVal clave_ordenpago As Long = 0, Optional ByVal concatpartidas As String = "") As DataTable
        Dim datos As New DataTable
        Dim estructuranueva As Boolean = False
        If clave_ordenpago = 0 Then
            estructuranueva = True
        Else
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", clave_ordenpago)
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_partida", concatpartidas)
            Dim consultasql As String = "SELECT
Concepto,
Monto
FROM
contabilidad_haberescalculosauxiliares
WHERE CLAVE_ORDENPAGO=@CLAVE_ORDENPAGO and clave_partida=@clave_partida
order by concepto asc;
"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
            If datos.Rows.Count = 0 Then
                estructuranueva = True
            End If
        End If
        If estructuranueva Then
            datos.Columns.Add("CONCEPTO", System.Type.GetType("System.String"))
            datos.Columns.Add("IMPORTE", System.Type.GetType("System.Decimal"))
            datos.Rows.Add({"Ajte.Adopcion ", 0})
            datos.Rows.Add({"Ajte.Asig Matrimonio", 0})
            datos.Rows.Add({"Ajte.Ayuda Escolar", 0})
            datos.Rows.Add({"Ajte.Hijos ", 0})
            datos.Rows.Add({"Ajte.Nac.", 0})
            datos.Rows.Add({"Ajte.Prenatal ", 0})
            datos.Rows.Add({"Hijos ", 0})
            datos.Rows.Add({"Hijos Incapac", 0})
            datos.Rows.Add({"Menores en Guarda", 0})
            datos.Rows.Add({"Menores en Guarda Disc", 0})
            datos.Rows.Add({"Prenatal ", 0})
        End If
        Return datos
    End Function

    Public Shared Sub guardarcalculosauxiliareshaberes(ByVal clave_ordenpago As Long, ByVal concatpartidas As String, ByVal datos As DataTable)
        For x = 0 To datos.Rows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", clave_ordenpago)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_partida", concatpartidas)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Concepto", datos.Rows(x).Item("Concepto"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", datos.Rows(x).Item("Monto"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "
INSERT INTO contabilidad_haberescalculosauxiliares
(
clave_ordenpago,
clave_partida,
Concepto,
Monto
)
VALUES
(
@clave_ordenpago,
@clave_partida,
@Concepto,
@Monto
)
ON DUPLICATE KEY UPDATE
Monto=@Monto
;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
    End Sub

    Public Sub Partidas_a_Datatable()
        Dim datos As New DataTable
        datos.Columns.Add("JUR", System.Type.GetType("System.String"))
        datos.Columns.Add("U.O", System.Type.GetType("System.String"))
        datos.Columns.Add("CARAC", System.Type.GetType("System.String"))
        datos.Columns.Add("FIN", System.Type.GetType("System.String"))
        datos.Columns.Add("FUN", System.Type.GetType("System.String"))
        datos.Columns.Add("SECC", System.Type.GetType("System.String"))
        datos.Columns.Add("SECT", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA PPAL", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA PCIAL.", System.Type.GetType("System.String"))
        datos.Columns.Add("SCD", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA SUB PAR", System.Type.GetType("System.String"))
        datos.Columns.Add("IMPORTE", System.Type.GetType("System.Decimal"))
        For Each partidaitem In Partidas
            datos.Rows.Add({partidaitem.Jur, partidaitem.UO, partidaitem.Caracter, partidaitem.Fin, partidaitem.Fun, partidaitem.Secc, partidaitem.Sect, partidaitem.PdaPPal, partidaitem.PdaSubpr, partidaitem.Montopartida})
        Next
        Partida_datatable = datos
    End Sub

    Public Shared Function Fondos_permanentes(Optional datosextendidos As Boolean = False) As DataTable
        Dim datos As New DataTable
        Dim consultasql As String = ""
        If datosextendidos Then
            consultasql = "
SELECT EFECTOR,`ORDEN DE CARGO`,EXPEDIENTE,ORDENCARGO,`INST. LEGAL` FROM (
Select
EFECTOR,
concat(cast(Substring(CLAVE_ORDENCARGO From 9 for 4) as unsigned),'/',Substring(CLAVE_ORDENCARGO From 1 for 4)) AS 'ORDEN DE CARGO',EXPEDIENTE,
cast(Substring(CLAVE_ORDENCARGO From 9 for 4) as unsigned) AS 'ORDENCARGO',CLAVE_ORDENCARGO
from _fondopermanentepartida group by efector order by CLAVE_ORDENCARGO asc)FONDOSPERMANENTES
LEFT JOIN
(SELECT CLAVE_ORDENCARGO,GROUP_CONCAT(CONCAT( ' Dec. ',INSTRUMENTOLEGAL)) AS 'INST. LEGAL' FROM _fondopermanentelegal GROUP BY CLAVE_ORDENCARGO)LEGAL
ON FONDOSPERMANENTES.CLAVE_ORDENCARGO = LEGAL.CLAVE_ORDENCARGO
"
        Else
            consultasql = "Select
EFECTOR,
concat(cast(Substring(CLAVE_ORDENCARGO From 9 for 4) as unsigned),'/',Substring(CLAVE_ORDENCARGO From 1 for 4)) AS 'ORDEN DE CARGO',EXPEDIENTE from _fondopermanentepartida group by efector order by CLAVE_ORDENCARGO asc
"
        End If
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return datos
    End Function

    Private Function calculartotal(ByVal tabladedatos As DataTable) As Decimal
        Dim sumado As Decimal = 0
        For x = 0 To tabladedatos.Rows.Count - 1
            'Prec.Total
            sumado += tabladedatos.Rows(x).Item("Montopartida")
        Next
        Return sumado
    End Function

End Class

Public Class PartidaPresupuestaria
    'Public Ejercicio As Integer
    Public Jur As String
    Public UO As String
    Public Caracter As String
    Public Fin As String
    Public Fun As String
    Public Secc As String
    Public Sect As String
    Public PdaPcial As String
    Public PdaPPal As String
    Public SCD As String
    Public PdaSubpr As String
    Public Montopartida As Decimal

    Public Sub New()
        Jur = ""
        UO = ""
        Caracter = ""
        Fin = 0
        Fun = 0
        Secc = 0
        Sect = 0
        PdaPcial = ""
        PdaPPal = ""
        SCD = ""
        PdaSubpr = 0
        Montopartida = 0
    End Sub

    Public Sub clear()
        Jur = ""
        UO = ""
        Caracter = ""
        Fin = 0
        Fun = 0
        Secc = 0
        Sect = 0
        PdaPcial = ""
        PdaPPal = ""
        SCD = ""
        PdaSubpr = 0
        Montopartida = 0
    End Sub

    Public Shared Function estructurapartidadatatable(Optional CLAVE_ORDENPAGO As Long = Nothing) As DataTable
        Dim datos As New DataTable
        If IsNothing(CLAVE_ORDENPAGO) Then
            datos.Columns.Add("JUR", System.Type.GetType("System.String"))
            datos.Columns.Add("U.O", System.Type.GetType("System.String"))
            datos.Columns.Add("CARAC", System.Type.GetType("System.String"))
            datos.Columns.Add("FIN", System.Type.GetType("System.String"))
            datos.Columns.Add("FUN", System.Type.GetType("System.String"))
            datos.Columns.Add("SECC", System.Type.GetType("System.String"))
            datos.Columns.Add("SECT", System.Type.GetType("System.String"))
            datos.Columns.Add("PDA PPAL", System.Type.GetType("System.String"))
            datos.Columns.Add("PDA PCIAL.", System.Type.GetType("System.String"))
            datos.Columns.Add("SCD", System.Type.GetType("System.String"))
            datos.Columns.Add("PDA SUB PAR", System.Type.GetType("System.String"))
            datos.Columns.Add("IMPORTE", System.Type.GetType("System.Decimal"))
        Else
            'CLAVE_EXPEDIENTE
            'CLAVE_ORDENPAGO
            'Jur
            'UO
            'CARAC
            'FI
            'Fun
            'Secc
            'Sect
            'PdaPcial
            'PDASUBPAR
            'PdaPPal
            'IMPORTE
            'Usuario
            'Creado_o_Modificado
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_ordenpago", CLAVE_ORDENPAGO)
            Dim consultasql As String = "SELECT
Jur as 'JUR',
UO as 'U.O',
CARAC as 'CARAC',
FI as 'FIN',
FUN  as 'FUN',
SECC as 'SECC',
SECT as 'SECT',
PdaPPal as 'PDA PPAL',
PdaPcial as 'PDA PCIAL.',
SCD as 'SCD',
PDASUBPAR as 'PDA SUB PAR',
IMPORTE as 'IMPORTE'
FROM CONTABILIDAD_PARTIDAEXPEDIENTE WHERE CLAVE_ORDENPAGO=@CLAVE_ORDENPAGO
"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Return datos
    End Function

    Public Shared Function estructurapartidadatatable_FONDOSPERMANENTES(ByVal EFECTOR As String) As DataTable
        Dim datos As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@EFECTOR", EFECTOR)
        Dim consultasql As String = "SELECT
Jur as 'JUR',
UO as 'U.O',
CARAC as 'CARAC',
FI as 'FIN',
FUN  as 'FUN',
SECC as 'SECC',
SECT as 'SECT',
PdaPcial as 'PDA PCIAL.',
PdaPPal as 'PDA PPAL',
SCD as 'SCD',
PDASUBPAR as 'PDA SUB PAR',
0.00 as 'IMPORTE'
FROM _fondopermanentepartida WHERE EFECTOR=@EFECTOR
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return datos
    End Function

    Public Shared Function partidasmasutilizadastipo(ByVal ordenpago As Ordendepago) As DataTable
        Dim datos As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Tipo", ordenpago.Ordenpago_tipo)
        Dim consultasql As String = "select JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPPAL,
PDAPCIAL,
PDASUBPAR,
SCD,0.00 as 'IMPORTE'
from
(select tipo,count(ordenpago.clave_ordenpago) as cantidad,JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPPAL,
PDAPCIAL,
PDASUBPAR,
SCD from
(select clave_ordenpago,tipo from contabilidad_ordenpago where tipo=@tipo)ordenpago
left join
(select clave_ordenpago,
concat(JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPCIAL,
PDASUBPAR,
PDAPPAL,
SCD) as partida,JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPPAL,
PDAPCIAL,
PDASUBPAR,
SCD
from contabilidad_partidaexpediente)partidas
on
ordenpago.clave_ordenpago=partidas.clave_ordenpago
group by tipo,partida
order by cantidad desc,JUR,
UO,
CARAC,
FI,
FUN,
SECC,
SECT,
PDAPPAL,
PDAPCIAL,
PDASUBPAR,
SCD desc limit 10)partidas
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return datos
    End Function

End Class