Imports System.IO

Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Movimiento
    Inherits Expediente
    Public CUIT As String
    Public Clave_expediente_detalle As Long
    Public Clave_expediente_detalle_principal As Long 'para el caso de retenciones que tienen un expediente original
    Public Descripcion_movimiento As String
    Public expediente_year As Integer
    Public Cod_orden As Integer
    Public Clase_fondo As Integer
    Public cod_inp As Integer
    Public Transferencia As Long
    Public Fecha_movimiento As Date
    Public Orden As Integer
    Public Orden_year As Integer
    Public Monto_movimiento As Decimal
    Public Total_factura As Decimal
    Public Tipo_Movimiento As String
    Public Usuario As Integer
    Public retenciones As New List(Of Retencion)
    Public tablaretenciones As New DataTable
    Public tablapartidas As New DataTable

    ''' <summary>
    ''' Toma el código ingresado y lo desglosa para su fácil y efectiva utilización
    ''' </summary>
    Public Sub Desglose_clave_movimiento(ByVal Clave_expediente_detalle As Long)
        If Clave_expediente_detalle.ToString.Length > 13 Then
            organismo = CType(Clave_expediente_detalle.ToString.Substring(4, 4), Integer)
            numero = CType(Clave_expediente_detalle.ToString.Substring(8, 5), Integer)
            expediente_year = CType(Clave_expediente_detalle.ToString.Substring(0, 4), Integer)
        Else
            organismo = 0
            numero = 0
            expediente_year = Date.Now.Year
        End If
    End Sub

    ''' <summary>
    ''' Devuelve todos los valores a nothing
    ''' </summary>
    Public Sub New()
        clearmovimiento()
    End Sub

    Public Sub New_fromExpediente(ByVal Base As Expediente)
        Tomardatosexpediente(Base, True)
    End Sub

    Public Sub clearmovimiento()
        'moviento
        CUIT = Nothing
        Clave_expediente_detalle = Nothing
        Descripcion_movimiento = Nothing
        Clave_expediente_detalle_principal = Nothing
        Expediente_N = Nothing
        Cod_orden = Nothing
        Clase_fondo = Nothing
        cod_inp = Nothing
        expediente_year = Nothing
        Transferencia = Nothing
        Fecha_movimiento = Nothing
        Orden = Nothing
        Orden_year = Nothing
        Monto_movimiento = Nothing
        Tipo_Movimiento = Nothing
        Usuario = Nothing
        Total_factura = Nothing
    End Sub

    ''' <summary>
    ''' 'agrega o devuelve el numero de movimiento a ser agregado/modificado
    ''' </summary>
    ''' <returns></returns>
    Public Function agregaromodificarmovimiento() As Long
        Return Sumarmovimiento()
    End Function

    Public Function clave_detalle_a__clave_expediente(ByVal Clave_expediente_detalle As Long) As Long
        Dim clave_exp As Long
        clave_exp = Clave_expediente_detalle.ToString.Substring(0, 13)
        Return clave_exp
    End Function

    Private Function Sumarmovimiento() As Long
        Dim maximo As Long = 0
        If (claveexpediente > 0) And (IsNothing(Clave_expediente_detalle) Or (Clave_expediente_detalle = 0)) Then
            Dim temporalus As New DataTable
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@claveindiceminimo", Convert.ToInt64(claveexpediente.ToString & "0000"))
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@claveindicemaximo", Convert.ToInt64(claveexpediente.ToString & "9999"))
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select MAX(Clave_expediente_detalle) from Expediente_detalle where
Clave_expediente_detalle >= @claveindiceminimo and Clave_expediente_detalle <= @claveindicemaximo ",
                                 temporalus, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Select Case temporalus.Rows.Count
                Case = 1
                    Select Case IsDBNull(temporalus.Rows(0).Item(0))
                        Case True
                            Clave_expediente_detalle = Convert.ToInt64(claveexpediente.ToString & "0000")
                        Case False
                            Clave_expediente_detalle = temporalus.Rows(0).Item(0) + 1
                    End Select
                Case = 0
                    Clave_expediente_detalle = Convert.ToInt64(claveexpediente.ToString & "0000")
            End Select
            temporalus.Dispose()
        Else
            maximo = Clave_expediente_detalle
        End If
        Return maximo
    End Function

    Public Function cargarmovimiento(ByVal Clave_expediente_detalle_ As Long) As Movimiento
        Dim movimientoaretornar As New Movimiento
        Dim temporalus As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Clave_expediente_detalle_)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
Select * from Expediente_detalle where
Clave_expediente_detalle=@Clave_expediente_detalle ", temporalus, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If temporalus.Rows.Count > 0 Then
            movimientoaretornar.CUIT = temporalus.Rows(0).Item("CUIT").ToString
            movimientoaretornar.Clave_expediente_detalle = Clave_expediente_detalle_
            movimientoaretornar.claveexpediente = clave_detalle_a__clave_expediente(Clave_expediente_detalle_)
            movimientoaretornar.Usuario = temporalus.Rows(0).Item("USUARIO").ToString
            movimientoaretornar.Cargar_expediente(movimientoaretornar.claveexpediente)
            Desglose_clave_movimiento(Clave_expediente_detalle_)
            Asignarvalores(movimientoaretornar.Descripcion_movimiento, temporalus.Rows(0).Item("Detalle").ToString)
            movimientoaretornar.Expediente_N = temporalus.Rows(0).Item("Expediente_N").ToString
            Asignarvalores(movimientoaretornar.Cod_orden, temporalus.Rows(0).Item("Cod_orden"))
            Asignarvalores(movimientoaretornar.Clase_fondo, temporalus.Rows(0).Item("CFdo"))
            Asignarvalores(movimientoaretornar.cod_inp, temporalus.Rows(0).Item("CodInp"))
            Asignarvalores(movimientoaretornar.Transferencia, temporalus.Rows(0).Item("Nrotransferencia"))
            Asignarvalores(movimientoaretornar.Fecha_movimiento, temporalus.Rows(0).Item("Fechadelmovimiento"))
            'Orden = temporalus.Rows(0).Item("Orden_N").ToString
            Asignarvalores(movimientoaretornar.Orden, temporalus.Rows(0).Item("Orden_N"))
            Select Case movimientoaretornar.cod_inp
                Case = 1
                    Asignarvalores(movimientoaretornar.ordenpago, temporalus.Rows(0).Item("Orden_N"))
                    Asignarvalores(movimientoaretornar.ordenpagoyear, temporalus.Rows(0).Item("Orden_year"))
            End Select
            'Orden_year = temporalus.Rows(0).Item("Orden_year").ToString
            Asignarvalores(movimientoaretornar.Orden_year, temporalus.Rows(0).Item("Orden_year"))
            'Monto_movimiento = temporalus.Rows(0).Item("monto").ToString
            Asignarvalores(movimientoaretornar.Monto_movimiento, temporalus.Rows(0).Item("monto"))
            If Not IsDBNull(temporalus.Rows(0).Item("Total_Factura")) Then
                movimientoaretornar.Total_factura = temporalus.Rows(0).Item("Total_Factura")
            Else
                movimientoaretornar.Total_factura = 0
            End If
            'Tipo_Movimiento = temporalus.Rows(0).Item("Mov_tipo").ToString
            Asignarvalores(movimientoaretornar.Tipo_Movimiento, temporalus.Rows(0).Item("Mov_tipo"))
            movimientoaretornar.Ver_retenciones()
            'Total_factura = Nothing
            '       movimientoaretornar.Desglose_clave_movimiento()
        End If
        Return movimientoaretornar
    End Function

    Private Sub Asignarvalores(ByRef asignar As Object, ByRef valor As Object)
        If Not IsNothing(valor) Then
            If IsDBNull(valor) Then
                Select Case asignar.GetType.ToString
                    Case Is = "System.String"
                        asignar = ""
                    Case Is = "System.Int64"
                        asignar = 0
                    Case Else
                        asignar = 0
                End Select
            Else
                asignar = valor
            End If
        Else
            asignar = valor
        End If
    End Sub

    Public Function NUEVOMOVIMIENTO(ByVal claveexpediente_ As Long) As Long
        Dim maximo As Long = 0
        Dim temporalus As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@claveindiceminimo", CType(claveexpediente_.ToString & "0000", Long))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@claveindicemaximo", CType(claveexpediente_.ToString & "9999", Long))
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select MAX(Clave_expediente_detalle) from Expediente_detalle where
Clave_expediente_detalle >= @claveindiceminimo and Clave_expediente_detalle <= @claveindicemaximo ",
                                 temporalus, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case temporalus.Rows.Count
            Case = 1
                Select Case IsDBNull(temporalus.Rows(0).Item(0))
                    Case True
                        maximo = Convert.ToInt64(claveexpediente_.ToString & "0000")
                    Case False
                        maximo = temporalus.Rows(0).Item(0) + 1
                End Select
            Case = 0
                maximo = Convert.ToInt64(claveexpediente_.ToString & "0000")
        End Select
        temporalus.Dispose()
        Return maximo
    End Function

    Public Function Movimientosasociados(ByVal claveexpediente_principal_detalle As Long, ByVal cod_orden As Integer) As Long
        Dim valorretornado As Long = 0
        Dim temporalus As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@claveexpediente_principal_detalle", claveexpediente_principal_detalle)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@cod_orden", cod_orden)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Clave_expediente_detalle from Expediente_detalle where
Clave_expediente_detalle = @claveexpediente_principal_detalle and cod_orden=@cod_orden ",
                             temporalus, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case temporalus.Rows.Count
            Case = 1
                Select Case IsDBNull(temporalus.Rows(0).Item(0))
                    Case True
                        valorretornado = Nothing
                    Case False
                        valorretornado = temporalus.Rows(0).Item(0)
                End Select
            Case = 0
                valorretornado = Nothing
        End Select
        temporalus.Dispose()
        Return valorretornado
    End Function

    Public Sub Tomardatosexpediente(ByVal base As Expediente, ByVal borrardatosmovimiento As Boolean)
        claveexpediente = base.claveexpediente
        organismo = base.organismo
        numero = base.numero
        year = base.year
        monto = base.monto
        fecha = base.fecha
        descripcion = base.descripcion
        ordenpago = base.ordenpago
        ordenpagoyear = base.ordenpagoyear
        ordencargo = base.ordencargo
        ordencargoyear = base.ordencargoyear
        tieneprincipal = base.tieneprincipal
        haberes = base.haberes
        principalclaveexpediente = base.principalclaveexpediente
        principalorganismo = base.principalorganismo
        principalnumero = base.principalnumero
        principalyear = base.principalyear
        principaldescripcion = base.principaldescripcion
        Asignarcuentaespecial = base.Asignarcuentaespecial
        cuentaespecial = base.cuentaespecial
        If borrardatosmovimiento = True Then
            clearmovimiento()
        End If
    End Sub

    Public Function Valoresvalidos() As String
        Dim resultado As String = Nothing
        If CUIT = Nothing Then
            resultado += vbCrLf & "-Error " & " No se ha ingresado un CUIT para este movimiento"
        End If
        If Clave_expediente_detalle = Nothing Then
        End If
        If Descripcion_movimiento = Nothing Then
            resultado += vbCrLf & "-Error " & " Falta Descripción del Movimiento"
        End If
        If Expediente_N = Nothing Then
            resultado += vbCrLf & "-Error " & " en expediente, por favor seleccione nuevamente"
        End If
        If Cod_orden = Nothing Then
            resultado += vbCrLf & "-Error " & " No se seleccionó código de Orden"
        End If
        If Clase_fondo = Nothing Then
            resultado += vbCrLf & "-Error " & " No se seleccionó clase de fondo"
        End If
        If cod_inp = Nothing Then
            resultado += vbCrLf & "-Error " & " No se seleccionó código de imputación"
        End If
        If expediente_year = Nothing Then
            resultado += vbCrLf & "-Error " & " No se encuentra el año del expediente"
        End If
        If Transferencia = Nothing Then
            resultado += vbCrLf & "-Error " & " No se cargo número Movimiento"
        End If
        If Fecha_movimiento = Nothing Then
            resultado += vbCrLf & "-Error " & "Al tomar la fecha"
        End If
        If Orden = Nothing Then
            resultado += vbCrLf & "-Error " & " Debe ingresar Nro de orden"
        End If
        If Orden_year = Nothing Then
            resultado += vbCrLf & "-Error " & " Debe seleccionar año de orden"
        End If
        If Monto_movimiento = Nothing Then
            resultado += vbCrLf & "-Error " & " el Monto no es valido, o se encuentra en un formato no reconocido"
        End If
        If Tipo_Movimiento = Nothing Then
            resultado += vbCrLf & "-Error " & " No se determino el tipo de Movimiento"
        End If
        'BORRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        resultado = Nothing
        'BORRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        Return resultado
    End Function

    Public Sub insertar_movimiento(ByVal Movimiento_ As Movimiento, Optional message As Boolean = True)
        Dim TextoMessage As String = ""
        If message Then
            Select Case Not IsNothing(claveexpediente) ' en caso de que se desee modificar el movimiento
                Case True
                    TextoMessage = "Confirma que desea ACTUALIZAR este Movimiento"
                Case False
                    TextoMessage = "Confirma que desea CARGAR NUEVO Movimiento"
            End Select
        Else
        End If
        If Not message Then
            insertar_movimiento_sql(Movimiento_)
        Else
            If IsNothing(Valoresvalidos) Then
                Select Case MsgBox(TextoMessage, MsgBoxStyle.YesNoCancel, " ")
                    Case MsgBoxResult.Yes
                        insertar_movimiento_sql(Movimiento_)
                    Case MsgBoxResult.No
                End Select
            Else
                MsgBox(Valoresvalidos, MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub insertar_movimiento_sql(ByVal Movimiento_ As Movimiento)
        ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Movimiento_.Clave_expediente_detalle)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle_principal", Movimiento_.Clave_expediente_detalle_principal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", Movimiento_.Expediente_N)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", Movimiento_.Descripcion_movimiento)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Movimiento_.Monto_movimiento)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total_factura", Movimiento_.Total_factura)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cod_orden", Movimiento_.Cod_orden)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CFdo", Movimiento_.Clase_fondo)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CodInp", Movimiento_.cod_inp)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Mov_tipo", Movimiento_.Tipo_Movimiento)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Movimiento_.CUIT)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Movimiento_.Transferencia)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fechadelmovimiento", Movimiento_.Fecha_movimiento)
        For x = 0 To Autocompletetables.SFyV_Codorden.Rows.Count - 1
            If Cod_orden = Autocompletetables.SFyV_Codorden.Rows(x).Item(0) Then
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@tipoorden", Autocompletetables.SFyV_Codorden.Rows(0).Item(1))
                Exit For
            Else
                ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@tipoorden", "Verificar")
            End If
        Next
        If SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("@tipoorden") Then
        Else
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@tipoorden", "Retenciones")
        End If
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_N", Movimiento_.Orden)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_year", Movimiento_.Orden_year)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `Expediente_detalle` " &
"(Clave_expediente_detalle,Clave_expediente_detalle_principal,Expediente_N,Detalle,Monto,Total_factura,Cod_orden,CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Fechadelmovimiento,tipoorden,Orden_N,Orden_year,Usuario) " &
"VALUES (@Clave_expediente_detalle,@Clave_expediente_detalle_principal,@Expediente_N,@Detalle,@Monto,@Total_factura,@Cod_orden,@CFdo,@CodInp,@Mov_tipo,@CUIT,@Nrotransferencia,@Fechadelmovimiento,@tipoorden,@Orden_N,@Orden_year,@Usuario) " &
"ON DUPLICATE KEY UPDATE " &
"Clave_expediente_detalle_principal=@Clave_expediente_detalle_principal,Expediente_N=@Expediente_N,Detalle=@Detalle,Monto=@Monto,Total_factura=@Total_factura,Cod_orden=@Cod_orden,CFdo=@CFdo,CodInp=@CodInp,Mov_tipo=@Mov_tipo,CUIT=@CUIT,Nrotransferencia=@Nrotransferencia,
Fechadelmovimiento=@Fechadelmovimiento,tipoorden=@tipoorden,Orden_N=@Orden_N,Orden_year=@Orden_year,Usuario=@Usuario"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Public Sub Ver_retenciones()
        Dim tabla_resultados As New DataTable
        Dim retenciontemporal As New Retencion
        Dim retenciontemporal_lista As New List(Of Retencion)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", Me.Clave_expediente_detalle)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
Nombre_Retencion as 'Concepto',
Nombre_retencion_detalle as 'Detalle',
Monto_retenido,
Fecha_retencion as 'fecha' ,
minimonoimponible as 'MNI',
alicuota,
situacionfrente_afip as 'IVA',
Total_factura,
neto_factura,
Porc_IVA,
Nro_transaccion,Cuit_recaudador,cod_impuesto,cod_regimen,nrocertificado
from retenciones where clave_expediente_detalle=@clave_expediente_detalle
order by field (Nombre_Retencion,'GANANCIAS','SUSS','IVA','DGR')", tabla_resultados, "Clase Movimiento, Ver Retenciones")
        If tabla_resultados.Rows.Count > 0 Then
            For Each row As DataRow In tabla_resultados.Rows
                retenciontemporal = New Retencion
                retenciontemporal.Nombre_retencion = row.Item("Concepto")
                retenciontemporal.Nombre_retencion_detalle = row.Item("Detalle")
                retenciontemporal.Monto_retenido = row.Item("Monto_retenido")
                retenciontemporal.Fecha = row.Item("fecha")
                retenciontemporal.Minimo_no_imponible = row.Item("MNI")
                retenciontemporal.Alicuota = row.Item("alicuota")
                retenciontemporal.Situacionfrente_afip = row.Item("IVA")
                retenciontemporal.Total_factura = row.Item("Total_Factura")
                retenciontemporal.Neto_IVA = row.Item("Neto_factura")
                retenciontemporal.Porcentaje_iva = row.Item("porc_IVA")
                retenciontemporal.Cuit_recaudador = row.Item("Cuit_recaudador")
                retenciontemporal_lista.Add(retenciontemporal)
            Next
            Me.retenciones = retenciontemporal_lista
        Else
            retenciontemporal = New Retencion
            retenciontemporal.Nombre_retencion = "Sin retenciones"
            retenciontemporal.Nombre_retencion_detalle = ""
            retenciontemporal.Monto_retenido = 0
            retenciontemporal.Fecha = Date.Now
            retenciontemporal.Minimo_no_imponible = 0.00
            retenciontemporal.Alicuota = 0
            retenciontemporal.Situacionfrente_afip = "-"
            retenciontemporal.Total_factura = 0
            retenciontemporal.Neto_IVA = 0
            retenciontemporal.Porcentaje_iva = 0
            retenciontemporal.Cuit_recaudador = ""
            retenciontemporal_lista.Add(retenciontemporal)
        End If
        Me.tablaretenciones = tabla_resultados
    End Sub

    Public Sub Vertotalespornrotransferencia(ByVal nro_transferencia As Long)
        Dialogo_datos.mostrardatatable(Tablatotalespornrotransferencia(nro_transferencia))
    End Sub

    Shared Function Tablatotalespornrotransferencia(ByVal nro_transferencia As Long) As DataTable
        Dim tabla_resultados As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nrotransferencia", nro_transferencia)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Z.expediente_N,ORDEN,CONCAT(N_PEDIDOFONDO,'/',YEAR_PEDIDOFONDO) AS PF,Z.MONTO,GANANCIAS,SUSS,IVA,DGR,TOTAL_FACTURA,
total_factura-(Z.Monto+ganancias+suss+iva+dgr) as diferencia FROM
(
SELECT expediente_N,ORDEN,Monto,
case when isnull(Ganancias) then 0 else Ganancias END as 'GANANCIAS',
case when isnull(SUSS) then 0 else SUSS END as 'SUSS',
case when isnull(IVA) then 0 else IVA END as 'IVA',
case when isnull(DGR) then 0 else DGR END as 'DGR',
Total_factura,Clave_expedientetrim  FROM
(Select expediente_N, monto,Clave_expediente_detalle,Total_Factura,CONCAT(ORDEN_N,'/',oRDEN_YEAR) AS 'ORDEN',
Substring(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim from expediente_Detalle where nrotransferencia=@nrotransferencia
)A
left join
(Select Clave_expediente_detalle AS 'C1',
CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'GANANCIAS'
 from retenciones  WHERE Nombre_retencion='GANANCIAS')R1
ON
A.CLAVE_EXPEDIENTE_DETALLE = R1.C1
left join
(Select Clave_expediente_detalle AS 'C2',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'SUSS' from retenciones  WHERE Nombre_retencion='SUSS')R2
ON
A.CLAVE_EXPEDIENTE_DETALLE = R2.C2
left join
(Select Clave_expediente_detalle AS 'C3',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'IVA' from retenciones  WHERE Nombre_retencion='IVA')R3
ON
A.CLAVE_EXPEDIENTE_DETALLE = R3.C3
left join
(Select Clave_expediente_detalle AS 'C4',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'DGR' from retenciones  WHERE Nombre_retencion='DGR')R4
ON
A.CLAVE_EXPEDIENTE_DETALLE = R4.C4)Z
LEFT JOIN
(SELECT * FROM EXPEDIENTE )E
On Z.Clave_expedientetrim=E.CLAVE_EXPEDIENTE
LEFT JOIN
(SELECT * FROM pedido_fondos)PF
On E.CLAVE_PEDIDOFONDO=PF.CLAVE_PEDIDOFONDO", tabla_resultados, "Clase Movimiento, Ver Retenciones")
        Return tabla_resultados
    End Function

    ''' <summary>
    ''' Devuelve una tabla donde contiene todos los expedientes con sus retenciones según su número de cheque o transferencia
    ''' </summary>
    ''' <param name="nrotransferencia"> Nro de cheque o transferencia </param>
    ''' <returns></returns>
    Shared Function Tablatotalesconretenciones(ByVal nrotransferencia As Long) As DataTable
        Dim tabla_resultados As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nrotransferencia", nrotransferencia)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@EJERCICIO", Autorizaciones.Year)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT expediente_N,Monto,
case when isnull(Ganancias) then 0 else Ganancias END as 'GANANCIAS',
case when isnull(SUSS) then 0 else SUSS END as 'SUSS',
case when isnull(IVA) then 0 else IVA END as 'IVA',
case when isnull(DGR) then 0 else DGR END as 'DGR' FROM
(Select expediente_N, monto,Clave_expediente_detalle from expediente_Detalle where nrotransferencia=@nrotransferencia
)A
left join
(Select Clave_expediente_detalle AS 'C1',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'GANANCIAS' from retenciones  WHERE Nombre_retencion='GANANCIAS')R1
ON
A.CLAVE_EXPEDIENTE_DETALLE = R1.C1
left join
(Select Clave_expediente_detalle AS 'C2',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'SUSS' from retenciones  WHERE Nombre_retencion='SUSS')R2
ON
A.CLAVE_EXPEDIENTE_DETALLE = R2.C2
left join
(Select Clave_expediente_detalle AS 'C3',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'IVA' from retenciones  WHERE Nombre_retencion='IVA')R3
ON
A.CLAVE_EXPEDIENTE_DETALLE = R3.C3
left join
(Select Clave_expediente_detalle AS 'C4',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'DGR' from retenciones  WHERE Nombre_retencion='DGR')R4
ON
A.CLAVE_EXPEDIENTE_DETALLE = R4.C4", tabla_resultados, "Clase Movimiento, Ver Retenciones")
        Return tabla_resultados
    End Function

    Shared Function Tablatotalesconretenciones2(ByVal nrotransferencia As Long, Optional CUIT As String = "") As DataTable
        Dim tabla_resultados As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nrotransferencia", nrotransferencia)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@EJERCICIO", Autorizaciones.Year)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT
OP,
CONCAT(cast(Substring(exp.clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(exp.clave_pedidofondo From 1 for 4)) as 'PF',
Case when pedf.Clase_fondo=@EJERCICIO then 'EJ' else CONCAT('RP-',pedf.Clase_fondo) END as 'EJ',
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N,
a.Monto,
Case when isnull(Ganancias) then 0 else Ganancias END as 'GANANCIAS',
Case when isnull(SUSS) then 0 else SUSS END as 'SUSS',
Case when isnull(IVA) then 0 else IVA END as 'IVA',
Case when isnull(DGR) then 0 else DGR END as 'DGR',
nrocertificado as 'Certif.'
FROM
(Select expediente_N, monto,Clave_expediente_detalle,concat(Orden_N,'/',Orden_year) as OP from expediente_Detalle where
case when CUIT='' then nrotransferencia=@nrotransferencia else nrotransferencia=@nrotransferencia and CUIT=@CUIT end
)A
/*
Ganancias
*/
left join
(Select Clave_expediente_detalle AS 'C1',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'GANANCIAS' from retenciones  WHERE Nombre_retencion='GANANCIAS')R1
ON
A.CLAVE_EXPEDIENTE_DETALLE = R1.C1
/*
SUSS
*/
left join
(Select Clave_expediente_detalle AS 'C2',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'SUSS' from retenciones  WHERE Nombre_retencion='SUSS')R2
ON
A.CLAVE_EXPEDIENTE_DETALLE = R2.C2
/*
IVa
*/
left join
(Select Clave_expediente_detalle AS 'C3',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'IVA' from retenciones  WHERE Nombre_retencion='IVA')R3
ON
A.CLAVE_EXPEDIENTE_DETALLE = R3.C3
/*
Rentas
*/
left join
(Select Clave_expediente_detalle AS 'C4',CASE WHEN ISNULL(Monto_retenido) THEN 0 ELSE Monto_retenido END AS 'DGR' from retenciones  WHERE Nombre_retencion='DGR')R4
ON
A.CLAVE_EXPEDIENTE_DETALLE = R4.C4
/*
Para sacar pedido de fondo
*/
left join
(Select * from expediente)exp
ON
substring(A.CLAVE_EXPEDIENTE_DETALLE from 1 for 13) = exp.clave_expediente
/*
Para sacar rp o ejercicio
*/
left join
(Select * from pedido_fondos)pedf
ON
exp.clave_pedidofondo= pedf.clave_pedidofondo
/*
Nro Certificado retenciones
*/
left join
(Select nrocertificado,clave_Expediente_detalle from retenciones group by clave_expediente_detalle  )certif
ON
A.CLAVE_EXPEDIENTE_DETALLE = certif.clave_expediente_detalle", tabla_resultados, "Clase Movimiento, Ver Retenciones")
        If tabla_resultados.Rows.Count = 0 Then
            tabla_resultados = Tablatotalespornrotransferencia(nrotransferencia)
        End If
        Return tabla_resultados
    End Function

    Shared Function Tablatotalesporclave_expedientedetalle(ByVal clave_expedientedetalle As Long) As DataTable
        Dim tabla_resultados As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("claveindiceminimo", Convert.ToInt64((clave_expedientedetalle.ToString.Substring(0, 13)).ToString & "0000"))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("claveindicemaximo", Convert.ToInt64((clave_expedientedetalle.ToString.Substring(0, 13)).ToString & "9999"))
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_MOVIMIENTOS_EXPEDIENTES_DETALLADO", tabla_resultados, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expedientedetalles", clave_expedientedetalle)
        '        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT
        'CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as 'Expediente N',
        'CONCAT(Substring(clave_expediente From 5 for 4)) as 'ORGANISMO',
        'CAST(Substring(clave_expediente From 9 for 5)AS UNSIGNED) as 'Numero',
        'Substring(clave_expediente From 1 for 4) as 'Year',
        'Fecha,
        'Detalle,
        'Monto,
        'Clave_pedidofondo,
        'Clave_expediente,
        'CUENTA_ESPECIAL,
        'ClaveExpteprincipal,
        'Ordenpago,
        'OrdenCargo,
        'CONCAT(cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) as 'Pedido Fondo N',
        'Cuenta_especial,HABERES FROM
        'Expediente WHERE clave_expediente=@clave_expediente", tabla_resultados, "Clase Movimiento, Ver Retenciones")
        Return tabla_resultados
    End Function

    Public Shared Sub INSERTARMOVIMIENTO(ByVal MOVIMIENTO As Movimiento)
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle", MOVIMIENTO.Clave_expediente_detalle)
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Clave_expediente_detalle") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle", MOVIMIENTO.Clave_expediente_detalle)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Expediente_N") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Expediente_N", MOVIMIENTO.Expediente_N)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Detalle") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Detalle", MOVIMIENTO.Descripcion_movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Monto") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Monto", MOVIMIENTO.Monto_movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Cod_orden") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Add("_Cod_orden", MySql.Data.MySqlClient.MySqlDbType.Int16, 1).Value = MOVIMIENTO.Cod_orden
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_CFdo") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Add("_CFdo", MySql.Data.MySqlClient.MySqlDbType.Int16, 1).Value = MOVIMIENTO.Clase_fondo
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_CodInp") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Add("_CodInp", MySql.Data.MySqlClient.MySqlDbType.Int16, 1).Value = MOVIMIENTO.cod_inp
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Mov_tipo") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Mov_tipo", MOVIMIENTO.Tipo_Movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Clave_expediente_detalle_principal") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle_principal", MOVIMIENTO.Clave_expediente_detalle_principal)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_CUIT") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_CUIT", MOVIMIENTO.CUIT)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Nrotransferencia") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Nrotransferencia", MOVIMIENTO.Transferencia)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Fechadelmovimiento") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Fechadelmovimiento", MOVIMIENTO.Fecha_movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_tipoorden") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_tipoorden", MOVIMIENTO.Tipo_Movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Orden_N") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Orden_N", MOVIMIENTO.Orden)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Orden_year") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Orden_year", MOVIMIENTO.ordenpagoyear)
        End If
        'EJECUCION DE INSERCION
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "TESORERIA_MOVIMIENTOS_INSERTARMOVIMIENTO"
        Inicio.INSERTSQLPROCEDIMIENTO(Autorizaciones.Organismotabla, "MOVIMIENTO.INSERTARMOVIMIENTO")
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
    End Sub

    Public Shared Sub Fdopermanenteinsertaroactualizar(ByVal MOVIMIENTO As Movimiento)
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle", MOVIMIENTO.Clave_expediente_detalle)
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Clave_expediente_detalle") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle", MOVIMIENTO.Clave_expediente_detalle)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Expediente_N") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Expediente_N", MOVIMIENTO.Expediente_N)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Detalle") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Detalle", MOVIMIENTO.Descripcion_movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Monto") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Monto", MOVIMIENTO.Monto_movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Cod_orden") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Cod_orden", MOVIMIENTO.Cod_orden)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_CFdo") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_CFdo", MOVIMIENTO.Clase_fondo)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_CodInp") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_CodInp", MOVIMIENTO.cod_inp)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Mov_tipo") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Mov_tipo", MOVIMIENTO.Tipo_Movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Clave_expediente_detalle_principal") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle_principal", MOVIMIENTO.Clave_expediente_detalle_principal)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_CUIT") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_CUIT", MOVIMIENTO.CUIT)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Nrotransferencia") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Nrotransferencia", MOVIMIENTO.Transferencia)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Fechadelmovimiento") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Fechadelmovimiento", MOVIMIENTO.Fecha_movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_tipoorden") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_tipoorden", MOVIMIENTO.Tipo_Movimiento)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Orden_N") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Orden_N", MOVIMIENTO.Orden)
        End If
        If Not SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Contains("_Orden_year") Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Orden_year", MOVIMIENTO.ordenpagoyear)
        End If
        'EJECUCION DE INSERCION
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "TESORERIA_MOVIMIENTOS_INSERTARMOVIMIENTO"
        Inicio.INSERTSQLPROCEDIMIENTO(Autorizaciones.Organismotabla, "MOVIMIENTO.Fdopermanenteinsertaroactualizar")
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
    End Sub

    ''' <summary>
    ''' Carga de nros de Cheques en sistema, tengan o no asignados montos
    ''' </summary>
    ''' <param name="cuentabancaria"> Cuenta bancaria de la cual extraer los cheques</param>
    Public Shared Function Cargartransferencias(ByVal cuentabancaria As String) As Long
        Dim numero As Long = 0
        Dim Datostemporales As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@cuentabancaria", cuentabancaria)
        Dim consultasql As String = "
Select NRO_CHEQUE,
case when isnull(Total) then 0 else total end as 'Total',
modificado,
case when isnull(Movimientos) then 0 else Movimientos end as 'Cant. Mov.'
 FROM
(Select NRO_CHEQUE from tesoreria_cheques where CUENTA=@cuentabancaria)cheq
left JOIN
(select
sum(monto) as 'Total',
Nrotransferencia,
Creado_o_modificado as 'Modificado',
Count(monto) as 'Movimientos'
 from expediente_detalle where CodInp=1 group by Nrotransferencia)MOV
on cheq.NRO_CHEQUE=mov.Nrotransferencia
order by nro_cheque desc"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Datostemporales, System.Reflection.MethodBase.GetCurrentMethod.Name)
        DialogDialogo_Datagridview.Carga_General(Datostemporales, "Seleccione el cheque que desea utilizar", "Seleccionar", "Cancelar")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            If Not IsNothing(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value) Then
                numero = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
            End If
        Else
            'numero
        End If
        Return numero
    End Function

    Public Sub Borrarmovimiento(Optional clave_expediente_detalle_ As Long = 0)
        If clave_expediente_detalle_ = 0 Then
            clave_expediente_detalle_ = Clave_expediente_detalle
        Else
        End If
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", clave_expediente_detalle_)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = ("Delete FROM Expediente_detalle where clave_expediente_detalle=@clave_expediente_detalle")
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, "Borrarmovimiento")
    End Sub

    ''' <summary>
    ''' Este formulario de retenciones se adapta a lo requerido por el f2005 y f2004 que consta de 3 partes
    ''' A Datos del agente de percepción
    ''' B Datos del sujeto retenido
    ''' C Datos de la retención practicada
    ''' </summary>
    ''' <param name="movimiento_me"></param>
    ''' <param name="Doc"></param>
    ''' <param name="PROVEEDOR_CERTIFICADO"></param>
    ''' <returns></returns>
    Public Function Certificado(ByVal movimiento_me As Movimiento, ByVal Doc As Document, ByVal PROVEEDOR_CERTIFICADO As Proveedor, Optional impresor As Impresion = Nothing) As PdfPTable
        'Cargar Datos expediente
        movimiento_me.Cargar_expediente(movimiento_me.claveexpediente)
        'Crear tabla General para cargar los bordes
        Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
        'declaración de Fuentes a utilizar en el archivo
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Anchopagina As Single = Doc.PageSize.Width
        Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
        Tabla_total.LockedWidth = True
        Dim tamaniocolumna_total As Single() = New Single(0) {}
        tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
        Tabla_total.SetWidths(tamaniocolumna_total)
        'Creación de la celda que manejaria cada uno de los cuadros
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        Dim Phrasetemporal As New iTextSharp.text.Phrase()
        'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
        Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2) With {
            .TotalWidth = Anchopagina - Doc.LeftMargin,
            .LockedWidth = True
        }
        'Declaración variable de ancho de columnas
        Dim tamaniocolumna As Single() = New Single(1) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
        Encabezadosx.SetWidths(tamaniocolumna)
        'para insertar un espacio entre las celdas
        Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", font10Normal)))
        PdfpCell_espaciovacio.BorderWidth = 0
        PdfpCell_espaciovacio.FixedHeight = 2.0F
        'crear imagen con logo a la izquierda
        Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
        'asignar la imagen itextsharp a la celda
        Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
        PdfPCell.Rowspan = 2
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        PdfPCell.FixedHeight = 70.0F
        Encabezadosx.AddCell(PdfPCell)
        'Encabezado del año
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(movimiento_me.Fecha_movimiento.Year), font10Normal)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper & vbCrLf &
                                                                                                                 "CUIT Nº" & CUIT_servicioadministrativo.ToUpper & vbCrLf &
                                                                                                                 "Domicilio:" & DOMICILIOdelservicioadm, PDF_fuente_variable(10, True))))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        '----------------------AGREGA EL ENCABEZADO Completo------------------------------
        ' Frase_total.Clear()
        PARRAFOCOMPLETO.Add(Encabezadosx)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        Tabla_total.AddCell(PdfpCell_espaciovacio)
        ' Doc.Add(Encabezadosx)
        '----------------------CARGA LOS DATOS DEL CERTIFICADO------------------------------
        PARRAFOCOMPLETO.Clear()
        Encabezadosx = New iTextSharp.text.pdf.PdfPTable(3)
        Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        Encabezadosx.LockedWidth = True
        'Declaración variable de ancho de columnas
        tamaniocolumna = New Single(2) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.25)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.5)
        tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.25)
        Encabezadosx.SetWidths(tamaniocolumna)
        'AGREGA LOS DATOS DEL CERTIFICADO
        'carga las retenciones asociadas al movimiento seleccionado
        Dim retenciones As New DataTable
        movimiento_me.Ver_retenciones()
        retenciones = movimiento_me.tablaretenciones
        Dim porcentajeiva As Decimal
        If retenciones.Rows.Count > 0 Then
            movimiento_me.Total_factura = retenciones.Rows(0).Item("total_factura")
            porcentajeiva = retenciones.Rows(0).Item("porc_IVA")
            With retenciones.Columns
                .Remove("FECHA")
                '.Remove("MNI")
                '.Remove("ALICUOTA")
                .Remove("IVA")
                .Remove("TOTAL_FACTURA")
                .Remove("NETO_FACTURA")
                .Remove("PORC_IVA")
                .Remove("Nro_transaccion")
            End With
        End If
        Dim TEXTOMODIFICABLE0 As New iTextSharp.text.Paragraph
        TEXTOMODIFICABLE0.Add(New iTextSharp.text.Chunk("CERTIFICADO DE RETENCIONES Nº ", font10Normal))
        If retenciones.Rows.Count > 0 Then
            TEXTOMODIFICABLE0.Add(New iTextSharp.text.Chunk(retenciones.Rows(0).Item("nrocertificado").ToString, font12Bold))
        Else
            TEXTOMODIFICABLE0.Add(New iTextSharp.text.Chunk("s/n", font12Bold))
        End If
        'TIPO Y NUMERO DE COMPROBANTE DE PAGO
        '   PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("CERTIFICADO DE RETENCIONES Nº " & retenciones.Rows(0).Item("nrocertificado"), font10Normal)))
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(TEXTOMODIFICABLE0)
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 2
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        'FECHA
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("FECHA:" & movimiento_me.Fecha_movimiento, font10Normal)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        PdfPCell.Colspan = 1
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        ''----------------------ORDEN DE PAGO------------------------------
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" LIQUIDACIÓN ORDEN DE PAGO Nº" & movimiento_me.ordenpago & "/" & movimiento_me.ordenpagoyear & vbCrLf, font10Normal)))
        'PdfPCell.BorderWidth = 0
        'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        'PdfPCell.Colspan = 3
        ''PdfPCell.FixedHeight = 25.0F
        'Encabezadosx.AddCell(PdfPCell)
        'NOMBRE DEL PROVEEDOR
        Dim TEXTOMODIFICABLE As New iTextSharp.text.Paragraph
        With TEXTOMODIFICABLE
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("NOMBRE: ", font10Normal)))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(PROVEEDOR_CERTIFICADO.Nombre, font12Bold)))
        End With
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(TEXTOMODIFICABLE)
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        PdfPCell.Colspan = 2
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        'CUIT DEL PROVEEDOR
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("CUIT: " & PROVEEDOR_CERTIFICADO.CUIT, font12Bold)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
        PdfPCell.Colspan = 1
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        'DOMICILIO DEL PROVEEDOR
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DOMICILIO: " & PROVEEDOR_CERTIFICADO.Domicilio_legal, font10Normal)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        PdfPCell.Colspan = 3
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        'DATOS DEL EXPEDIENTE
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Expediente Nº: " & movimiento_me.organismo & "-" & movimiento_me.numero & "/" & movimiento_me.year)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
        PdfPCell.Colspan = 2
        PdfPCell.Rowspan = 2
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        If movimiento_me.pedidofondo.ToString.Length > 4 Then
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Pedido de Fondo Nº" & movimiento_me.pedidofondo, font10Normal)))
        Else
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("  Asignación Especial  ", font10Normal)))
        End If
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 1
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        '----------------------ORDEN DE PAGO------------------------------
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Orden de Pago Nº " & movimiento_me.ordenpago & "/" & movimiento_me.ordenpagoyear & vbCrLf, font10Normal)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 1
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(movimiento_me.descripcion)))
        'PdfPCell.BorderWidth = 0
        'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        'PdfPCell.Colspan = 1
        ''PdfPCell.FixedHeight = 25.0F
        'Encabezadosx.AddCell(PdfPCell)
        'Nro de Cheque
        If Not movimiento_me.Transferencia = 0 Then
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Nro: Transf./Cheque: " & movimiento_me.Transferencia, PDF_fuente_variable(12, True))))
        Else
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Transferencia Via CBU ", PDF_fuente_variable(12, True))))
        End If
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 3
        Encabezadosx.AddCell(PdfPCell)
        '---------------------------AGREGA A LA TABLA LOS DATOS DEL PROVEEDOR EN EL PARRAFO--------------------
        PARRAFOCOMPLETO.Add(Encabezadosx)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        Tabla_total.AddCell(PdfpCell_espaciovacio)
        ' Doc.Add(Encabezadosx)
        '----------------------CARGA LOS DATOS DEL CERTIFICADO------------------------------
        PARRAFOCOMPLETO.Clear()
        tamaniocolumna = New Single(retenciones.Columns.Count - 1) {}
        Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
        'For x = 0 To retenciones.Columns.Count - 1
        '    tamaniocolumna(x) = Convert.ToSingle(anchoutil / retenciones.Columns.Count)
        'Next
        tamaniocolumna(0) = Convert.ToSingle((anchoutil / 100) * 15)
        tamaniocolumna(1) = Convert.ToSingle((anchoutil / 100) * 46)
        tamaniocolumna(2) = Convert.ToSingle((anchoutil / 100) * 13)
        tamaniocolumna(3) = Convert.ToSingle((anchoutil / 100) * 13)
        tamaniocolumna(4) = Convert.ToSingle((anchoutil / 100) * 13)
        tamaniocolumna(retenciones.Columns.Count - 1) = Convert.ToSingle((anchoutil / 100) * 0)
        tamaniocolumna(retenciones.Columns.Count - 2) = Convert.ToSingle((anchoutil / 100) * 0)
        '---------------------------------------------TABLA CON TODOS LOS DATOS----------------------------------------------------------------------------------------------
        Dim tablaretenciones As iTextSharp.text.pdf.PdfPTable = PDFDatatable_RETENCIONES(retenciones, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9, True)
        '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
        ''label total
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Total Retenciones ", PDF_fuente_variable(12, False))))
        'PdfPCell.BorderWidth = 0.5
        'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        'PdfPCell.Colspan = 2
        'tablaretenciones.AddCell(PdfPCell)
        Dim sumaretenciones As Decimal = 0
        For x = 0 To retenciones.Rows.Count - 1
            sumaretenciones += retenciones.Rows(x).Item("monto_retenido")
        Next
        'label total
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(sumaretenciones, "C"), PDF_fuente_variable(12, True))))
        'PdfPCell.BorderWidth = 0.5
        'PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
        'PdfPCell.Colspan = 3
        'tablaretenciones.AddCell(PdfPCell)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(tablaretenciones, 0)))
        'DATOS DEL EXPEDIENTE
        TEXTOMODIFICABLE = New Paragraph
        With TEXTOMODIFICABLE
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Factura por: ", PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(movimiento_me.Total_factura, "C"), PDF_fuente_variable(12, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" -Retenciones: ", PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(sumaretenciones, "C"), PDF_fuente_variable(12, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Neto a pagar: ", PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(movimiento_me.Monto_movimiento, "C"), PDF_fuente_variable(12, True))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(vbCrLf, PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Respuesta AFIP: ", PDF_fuente_variable(8, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(PROVEEDOR_CERTIFICADO.Respuesta_AFIP, PDF_fuente_variable(8, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(vbCrLf, PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Codigo de Transaccion: ", PDF_fuente_variable(8, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(PROVEEDOR_CERTIFICADO.CAE_AFIP, PDF_fuente_variable(8, False))))
        End With
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(TEXTOMODIFICABLE)
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Factura por:" & Format(movimiento_me.Total_factura, "C") &
        '                                                                                                         " Retenciones " & Format(sumaretenciones, "C") &
        '                                                                                                        "  - Importe Pago Neto Proveedor: " & Format(movimiento_me.Monto_movimiento, "C"), font12Bold)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 1
        'PdfPCell.FixedHeight = 25.0F
        '  Encabezadosx.AddCell(PdfPCell)
        Tabla_total.AddCell(New PdfPCell(PdfPCell))
        '   Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        PARRAFOCOMPLETO.Clear()
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(TABLA_INICIALES(anchoutil, movimiento_me.Usuario), 0, 1, 1, iTextSharp.text.Element.ALIGN_LEFT)))
        With PARRAFOCOMPLETO
            If IsNothing(impresor) Then
                .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", "Tesorero"))
            Else
                .Add(PDFFIRMASv2(Anchopagina - Doc.LeftMargin, , impresor.Sello_Tesoreria))
            End If
        End With
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        '/estructura de Tesorería General de la provincia
        'Agregar Tabla al final de la generación del documento
        Return Tabla_total
    End Function

    ''' <summary>
    ''' Totales por certificado,devuelve una tabla PDFTABLE para ser ubicada en la generación de un PDF
    ''' </summary>
    ''' <param name="nrotransferencia"> numero de cheque/transferencia</param>
    ''' <param name="Doc">Documento </param>
    ''' <returns></returns>
    Shared Function CertificadoTotales(ByVal nrotransferencia As Double, ByVal Doc As Document, Optional encabezado As Boolean = True, Optional CUIT As String = "", Optional impresor As Impresion = Nothing) As PdfPTable
        'Crear tabla General para cargar los bordes
        Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
        'Crea una tabla para cargar los proveedores de este numero de transferencia
        Dim proveedores As New DataTable
        proveedores = Proveedor.Proveedor_de_Nrotransferencia(nrotransferencia, CUIT)
        'declaración de Fuentes a utilizar en el archivo
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Anchopagina As Single = Doc.PageSize.Width
        Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
        Tabla_total.LockedWidth = True
        Dim tamaniocolumna_total As Single() = New Single(0) {}
        tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
        Tabla_total.SetWidths(tamaniocolumna_total)
        'Creación de la celda que manejaria cada uno de los cuadros
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        Dim Phrasetemporal As New iTextSharp.text.Phrase()
        'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
        Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
        Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        Encabezadosx.LockedWidth = True
        'Declaración variable de ancho de columnas
        Dim tamaniocolumna As Single() = New Single(1) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
        Encabezadosx.SetWidths(tamaniocolumna)
        'para insertar un espacio entre las celdas
        Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", font10Normal)))
        PdfpCell_espaciovacio.BorderWidth = 0
        PdfpCell_espaciovacio.FixedHeight = 2.0F
        'crear imagen con logo a la izquierda
        Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
        'asignar la imagen itextsharp a la celda
        Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
        PdfPCell.Rowspan = 2
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        PdfPCell.FixedHeight = 70.0F
        Encabezadosx.AddCell(PdfPCell)
        'Encabezado del año
        PdfPCell = New iTextSharp.text.pdf.PdfPCell((New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(Date.Now.Year), font10Normal))))
        With PdfPCell
            .BorderWidth = 0
            .HorizontalAlignment = Element.ALIGN_CENTER
            .FixedHeight = 25.0F
        End With
        Encabezadosx.AddCell(PdfPCell)
        '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper & vbCrLf &
                                                                                                                 "CUIT Nº" & CUIT_servicioadministrativo.ToUpper, PDF_fuente_variable(10, True))))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        If encabezado = True Then
            '----------------------AGREGA EL ENCABEZADO Completo------------------------------
            ' Frase_total.Clear()
            PARRAFOCOMPLETO.Add(Encabezadosx)
            Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
            Tabla_total.AddCell(PdfpCell_espaciovacio)
            ' Doc.Add(Encabezadosx)
        End If
        '----------------------CARGA LOS DATOS DEL CERTIFICADO------------------------------
        PARRAFOCOMPLETO.Clear()
        Encabezadosx = New iTextSharp.text.pdf.PdfPTable(3)
        Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        Encabezadosx.LockedWidth = True
        'Declaración variable de ancho de columnas
        tamaniocolumna = New Single(2) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.25)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.5)
        tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.25)
        Encabezadosx.SetWidths(tamaniocolumna)
        'AGREGA LOS DATOS DEL CERTIFICADO
        'carga las retenciones asociadas al movimiento seleccionado
        Dim retenciones As New DataTable
        ''DATOS DEL EXPEDIENTE
        retenciones = Tablatotalesconretenciones2(nrotransferencia, CUIT)
        tamaniocolumna = New Single(retenciones.Columns.Count - 1) {}
        Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
        'For x = 0 To retenciones.Columns.Count - 1
        '    tamaniocolumna(x) = Convert.ToSingle(anchoutil / retenciones.Columns.Count)
        'Next
        tamaniocolumna(0) = Convert.ToSingle(anchoutil * (7.9 / 100))
        tamaniocolumna(1) = Convert.ToSingle(anchoutil * (8.2 / 100))
        tamaniocolumna(2) = Convert.ToSingle(anchoutil * (6.7 / 100))
        tamaniocolumna(3) = Convert.ToSingle(anchoutil * (13.1 / 100))
        tamaniocolumna(4) = Convert.ToSingle(anchoutil * (11.8 / 100))
        tamaniocolumna(5) = Convert.ToSingle(anchoutil * (11.8 / 100))
        tamaniocolumna(6) = Convert.ToSingle(anchoutil * (11.8 / 100))
        tamaniocolumna(7) = Convert.ToSingle(anchoutil * (11.8 / 100))
        tamaniocolumna(8) = Convert.ToSingle(anchoutil * (11.8 / 100))
        tamaniocolumna(9) = Convert.ToSingle(anchoutil * (5.1 / 100))
        Dim SumaNeto As Decimal = 0
        Dim SumaRetenciones As Decimal = 0
        Dim sumaganancias As Decimal = 0
        Dim sumasuss As Decimal = 0
        Dim sumaiva As Decimal = 0
        Dim sumadgr As Decimal = 0
        Dim SumaTotal As Decimal = 0
        For x = 0 To retenciones.Rows.Count - 1
            SumaNeto += retenciones.Rows(x).Item("monto")
            sumaganancias += retenciones.Rows(x).Item("Ganancias")
            sumasuss += retenciones.Rows(x).Item("SUSS")
            sumaiva += retenciones.Rows(x).Item("IVA")
            sumadgr += retenciones.Rows(x).Item("DGR")
        Next
        SumaRetenciones = sumaganancias + sumasuss + sumaiva + sumadgr
        SumaTotal = SumaNeto + SumaRetenciones
        Select Case nrotransferencia
            Case Is = 0
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Transferencia via CBU" & vbCrLf & proveedores.Rows(0).Item("PROVEEDOR").ToString, font12Bold)))
            Case Else
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Cheque Nro: " & nrotransferencia & vbCrLf & proveedores.Rows(0).Item("PROVEEDOR").ToString, font12Bold)))
        End Select
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 3
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        '---------------------------AGREGA A LA TABLA LOS DATOS DEL PROVEEDOR EN EL PARRAFO--------------------
        PARRAFOCOMPLETO.Add(Encabezadosx)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        Tabla_total.AddCell(PdfpCell_espaciovacio)
        ' Doc.Add(Encabezadosx)
        '----------------------CARGA LOS DATOS DEL CERTIFICADO------------------------------
        PARRAFOCOMPLETO.Clear()
        'tamaniocolumna(0) = Convert.ToSingle((anchoutil / 100) * 15)
        'tamaniocolumna(1) = Convert.ToSingle((anchoutil / 100) * 35)
        'tamaniocolumna(2) = Convert.ToSingle((anchoutil / 100) * 20)
        'tamaniocolumna(3) = Convert.ToSingle((anchoutil / 100) * 15)
        'tamaniocolumna(4) = Convert.ToSingle((anchoutil / 100) * 15)
        '---------------------------------------------TABLA CON TODOS LOS DATOS----------------------------------------------------------------------------------------------
        Dim tablaretenciones As iTextSharp.text.pdf.PdfPTable = PDFDatatable(retenciones, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9, True)
        '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
        'Agrega tabla de pedido de fondos
        PARRAFOCOMPLETO.Add(tablaretenciones)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        'Agrega los totales
        Encabezadosx = New iTextSharp.text.pdf.PdfPTable(3)
        Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        Encabezadosx.LockedWidth = True
        'Declaración variable de ancho de columnas
        tamaniocolumna = New Single(2) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.34)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.33)
        tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.33)
        Encabezadosx.SetWidths(tamaniocolumna)
        'NETO
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Neto : " & Format(SumaNeto, "C"), font12Bold)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 1
        Encabezadosx.AddCell(PdfPCell)
        'Retenciones
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Retenciones " & Format(SumaRetenciones, "C"), font10Normal)))
        'PdfPCell.BorderWidth = 0
        'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        'PdfPCell.Colspan = 1
        'Encabezadosx.AddCell(PdfPCell)
        TEXTOMODIFICABLE = New Paragraph
        With TEXTOMODIFICABLE
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("GANANCIAS", PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(sumaganancias, "C") & vbCrLf, PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SUSS", PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(sumasuss, "C") & vbCrLf, PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("IVA", PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(sumaiva, "C") & vbCrLf, PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DGR", PDF_fuente_variable(10, False))))
            .Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Format(sumadgr, "C"), PDF_fuente_variable(10, False))))
        End With
        PdfPCell = New iTextSharp.text.pdf.PdfPCell()
        PdfPCell.AddElement(TEXTOMODIFICABLE)
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        PdfPCell.Colspan = 1
        Encabezadosx.AddCell(PdfPCell)
        'TOTAL GENERAL
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Total General " & Format(SumaTotal, "C"), font10Normal)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 1
        Encabezadosx.AddCell(PdfPCell)
        'PdfPCell.FixedHeight = 25.0F
        PARRAFOCOMPLETO.Clear()
        PARRAFOCOMPLETO.Add(Encabezadosx)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        If encabezado = True Then
            PARRAFOCOMPLETO.Clear()
            With PARRAFOCOMPLETO
                If IsNothing(impresor) Then
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", "Tesorero"))
                Else
                    .Add(PDFFIRMASv2(Anchopagina - Doc.LeftMargin, , impresor.Sello_Tesoreria))
                End If
            End With
            Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        End If
        Return Tabla_total
    End Function

    Public Sub Generarcertificado(ByVal movimiento_me As Movimiento)
        Dim PROVEEDOR_CERTIFICADO As New Proveedor
        Dim Total_Factura As Decimal = 0
        PROVEEDOR_CERTIFICADO.CUIT = movimiento_me.CUIT
        PROVEEDOR_CERTIFICADO.Cargardatos()
        movimiento_me.cargarmovimiento(movimiento_me.Clave_expediente_detalle)
        'declaración de Fuentes a utilizar en el archivo
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Doc As New Document(PageSize.A4, 30, 30, 20, 20)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "CERT_RETENCION" & "\" & movimiento_me.Fecha_movimiento.Year & "\" & PROVEEDOR_CERTIFICADO.Nombre & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "CERT_RETENCION" & "\" & movimiento_me.Fecha_movimiento.Year & "\" & PROVEEDOR_CERTIFICADO.Nombre & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = movimiento_me.organismo & "-" & movimiento_me.numero & "-" & movimiento_me.year & "_" & movimiento_me.Transferencia & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "CERT_RETENCION" & "\" & movimiento_me.Fecha_movimiento.Year & "\" & PROVEEDOR_CERTIFICADO.Nombre & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                Doc.Add(Certificado(movimiento_me, Doc, PROVEEDOR_CERTIFICADO))
                ' Doc.Add(PARRAFOCOMPLETO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
                                                     })
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Genera un certificado de pago considerando un datatable de formato compatible, inicialmente usado en recibos
    ''' </summary>
    ''' <param name="tabladedatos">Datatable conteniendo valores compatibles</param>
    Shared Sub Generarcertificadopagotabla(ByVal tabladedatos As DataTable, ByVal proveedors As Proveedor)
        'declaración de Fuentes a utilizar en el archivo
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Doc As New Document(PageSize.A4, 30, 30, 20, 20)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "CERT_RETENCION" & "\Recibos\" & proveedors.Nombre & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "CERT_RETENCION" & "\Recibos\" & proveedors.Nombre & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = "Recibo-0000-00000.pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "CERT_RETENCION" & "\Recibos\" & proveedors.Nombre & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                Doc.Add(CertificadoTotales_tabla(tabladedatos, proveedors, Doc))
                ' Doc.Add(PARRAFOCOMPLETO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
                                                     })
            End Select
        End If
    End Sub

    Shared Sub Generarrecibo(ByVal nro_recibo As Recibo, ByVal tabladedatos As DataTable, ByVal proveedors As Proveedor, ByVal FECHA As Date, ByVal tamaniofuente As Single)
        Dim PdfpCell_ As New iTextSharp.text.pdf.PdfPCell
        Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente + 2, True))))
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        Dim Doc As New Document(PageSize.A4, 30, 30, 20, 20)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Anchoutil As Single = Anchopagina - (Doc.LeftMargin + Doc.RightMargin)
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "RECIBOS\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "RECIBOS\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = nro_recibo.Nro_recibo & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "RECIBOS\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'tabla de encabezado de recibo
                Dim tablaencabezado As New PdfPTable(10)
                tablaencabezado.TotalWidth = Anchoutil
                tablaencabezado.LockedWidth = True
                Dim tamaniocolumna As Single() = New Single(9) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchoutil * 0.15)
                tamaniocolumna(1) = Convert.ToSingle(Anchoutil * 0.1)
                tamaniocolumna(2) = Convert.ToSingle(Anchoutil * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(Anchoutil * 0.1)
                tamaniocolumna(4) = Convert.ToSingle(Anchoutil * 0.05)
                tamaniocolumna(5) = Convert.ToSingle(Anchoutil * 0.05)
                tamaniocolumna(6) = Convert.ToSingle(Anchoutil * 0.1)
                tamaniocolumna(7) = Convert.ToSingle(Anchoutil * 0.1)
                tamaniocolumna(8) = Convert.ToSingle(Anchoutil * 0.1)
                tamaniocolumna(9) = Convert.ToSingle(Anchoutil * 0.15)
                tablaencabezado.SetWidths(tamaniocolumna)
                'nombre proveedor
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(proveedors.Nombre & vbNewLine, PDF_fuente_variable(tamaniofuente + 3, True))))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("C.U.I.T.:" & proveedors.CUIT & vbNewLine, PDF_fuente_variable(tamaniofuente, True))))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("DOMICILIO:" & proveedors.Domicilio_real & vbNewLine, PDF_fuente_variable(tamaniofuente, False))))
                PARRAFOCOMPLETO.Alignment = Element.ALIGN_CENTER
                ' PdfpCell_ = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(proveedors.Nombre, PDF_fuente_variable(tamaniofuente + 3, True))))
                PdfpCell_ = New PdfPCell()
                With PdfpCell_
                    .AddElement(PARRAFOCOMPLETO)
                    .Border = PdfPCell.LEFT_BORDER Or PdfPCell.TOP_BORDER
                    .BorderWidth = 0.5
                    .Indent = 50
                    .Colspan = 4
                    .Rowspan = 6
                End With
                tablaencabezado.AddCell(PdfpCell_)
                ' tablaencabezado.AddCell(Phrasepdf(proveedors.Nombre, tamaniofuente + 3, True, 0.5, 4, 6, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                tablaencabezado.AddCell(Phrasepdf("X", tamaniofuente + 6, True, 1, 2, 3, Element.ALIGN_CENTER, 8, Element.ALIGN_MIDDLE))
                PdfpCell_ = New PdfPCell()
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("RECIBO Nro: " & nro_recibo.Nro_recibo, PDF_fuente_variable(tamaniofuente + 3, True))))
                PdfpCell_ = New PdfPCell(PARRAFOCOMPLETO)
                With PdfpCell_
                    .Border = PdfPCell.RIGHT_BORDER Or PdfPCell.TOP_BORDER
                    .BorderWidth = 0.5
                    .Indent = 50
                    .Colspan = 4
                    .Rowspan = 3
                End With
                tablaencabezado.AddCell(PdfpCell_)
                tablaencabezado.AddCell(Phrasepdf("DOCUMENTO NO VALIDO COMO FACTURA", tamaniofuente - 2, False, 0, 2, 3, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'PdfpCell_ = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente, True))))
                'With PdfpCell_
                '    .Border = PdfPCell.RIGHT_BORDER Or PdfPCell.LEFT_BORDER Or PdfPCell.BOTTOM_BORDER
                '    .BorderWidth = 0.5
                '    .Indent = 0
                '    .Colspan = 5
                '    .Rowspan = 6
                'End With
                'tablaencabezado.AddCell(PdfpCell_)
                PdfpCell_ = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("FECHA", PDF_fuente_variable(tamaniofuente, True))))
                With PdfpCell_
                    .BorderWidth = 0
                    .Indent = 0
                    .Colspan = 2
                    .Rowspan = 3
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                End With
                tablaencabezado.AddCell(PdfpCell_)
                PdfpCell_ = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(FECHA.Day & "/" & FECHA.Month & "/" & FECHA.Year, PDF_fuente_variable(tamaniofuente, True))))
                With PdfpCell_
                    .Border = PdfPCell.RIGHT_BORDER
                    .BorderWidth = 0.5
                    .Indent = 0
                    .Colspan = 2
                    .Rowspan = 3
                    .HorizontalAlignment = Element.ALIGN_LEFT
                End With
                tablaencabezado.AddCell(PdfpCell_)
                '  tablaencabezado.AddCell(Phrasepdf(FECHA.Day & "/" & FECHA.Month & "/" & FECHA.Year, tamaniofuente + 2, False, 0.5, 3, 6, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'tablaencabezado.AddCell(Phrasepdf(, tamaniofuente + 2, False, 0.5, 1, 6, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'tablaencabezado.AddCell(Phrasepdf(FECHA.Year, tamaniofuente + 2, False, 0.5, 1, 6, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                PdfpCell_ = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente, True))))
                With PdfpCell_
                    .Border = PdfPCell.LEFT_BORDER Or PdfPCell.BOTTOM_BORDER
                    .BorderWidth = 0.5
                    .Indent = 0
                    .Colspan = 5
                    .Rowspan = 1
                End With
                tablaencabezado.AddCell(PdfpCell_)
                'tablaencabezado.AddCell(Phrasepdf(" FECHA ", tamaniofuente, True, 0.5, 1, 2, Element.ALIGN_CENTER, 1, Element.ALIGN_MIDDLE))
                'DATOS DEL SERVICIO ADMINISTRATIVO
                PdfpCell_ = New PdfPCell()
                Dim PARRAFO_PARCIAL As Paragraph = New Paragraph()
                PARRAFO_PARCIAL.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("RECIBO de: ", PDF_fuente_variable(tamaniofuente, False))))
                PARRAFO_PARCIAL.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Autorizaciones.Nombrecompletodelservicio.ToUpper & vbNewLine, PDF_fuente_variable(tamaniofuente, True))))
                PARRAFO_PARCIAL.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("C.U.I.T.:" & Autorizaciones.CUIT_servicioadministrativo & vbNewLine, PDF_fuente_variable(tamaniofuente, True))))
                '    PARRAFOCOMPLETO.Add(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Autorizaciones.Nombrecompletodelservicio & vbNewLine, PDF_fuente_variable(tamaniofuente, True))))
                PARRAFO_PARCIAL.Alignment = Element.ALIGN_CENTER
                PdfpCell_ = New PdfPCell()
                With PdfpCell_
                    .AddElement(PARRAFO_PARCIAL)
                    .Border = PdfPCell.RIGHT_BORDER Or PdfPCell.BOTTOM_BORDER Or PdfPCell.LEFT_BORDER
                    .BorderWidth = 0.5
                    .Indent = 50
                    .Colspan = 5
                    .Rowspan = 1
                End With
                tablaencabezado.AddCell(PdfpCell_)
                'tablaencabezado.AddCell(Phrasepdf(Autorizaciones.Nombrecompletodelservicio & vbNewLine, tamaniofuente, False, 0.5, 5, 3, Element.ALIGN_CENTER, 1, Element.ALIGN_TOP))
                'PdfpCell_ = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente, True))))
                'With PdfpCell_
                '    .Border = PdfPCell.LEFT_BORDER
                '    .BorderWidth = 0.5
                '    .Indent = 0
                '    .Colspan = 5
                '    .Rowspan = 1
                'End With
                'tablaencabezado.AddCell(PdfpCell_)
                'tablaencabezado.AddCell(Phrasepdf("C.U.I.T.:" & Autorizaciones.CUIT_servicioadministrativo, tamaniofuente, True, 0.5, 5, 1, Element.ALIGN_LEFT, 1, Element.ALIGN_MIDDLE, 50))
                Doc.Add(tablaencabezado)
                'carga las retenciones asociadas al movimiento seleccionado
                Dim retenciones As New DataTable
                ''DATOS DEL EXPEDIENTE
                retenciones = tabladedatos
                tamaniocolumna = New Single(retenciones.Columns.Count - 1) {}
                For x = 0 To retenciones.Columns.Count - 1
                    tamaniocolumna(x) = Convert.ToSingle(Anchoutil / retenciones.Columns.Count)
                Next
                Dim SumaNeto As Decimal = 0
                Dim SumaGanancias As Decimal = 0
                Dim SumaSUSS As Decimal = 0
                Dim SumaIVA As Decimal = 0
                Dim SumaDGR As Decimal = 0
                Dim SumaTotal As Decimal = 0
                For x = 0 To retenciones.Rows.Count - 1
                    SumaNeto += retenciones.Rows(x).Item("monto")
                    SumaGanancias += retenciones.Rows(x).Item("Ganancias")
                    SumaSUSS += retenciones.Rows(x).Item("SUSS")
                    SumaIVA += retenciones.Rows(x).Item("IVA")
                    SumaDGR += retenciones.Rows(x).Item("DGR")
                Next
                SumaTotal = SumaNeto + SumaGanancias + SumaSUSS + SumaIVA + SumaDGR
                '---------------------------------------------TABLA CON TODOS LOS DATOS----------------------------------------------------------------------------------------------
                Dim tablaretenciones As iTextSharp.text.pdf.PdfPTable = PDFDatatablerecibo(retenciones, tamaniocolumna, 2, Anchoutil, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#ffffff")), 12, True)
                '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
                Doc.Add(tablaretenciones)
                Dim Encabezadosx As PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                Encabezadosx.TotalWidth = Anchoutil
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchoutil * 0.34)
                tamaniocolumna(1) = Convert.ToSingle(Anchoutil * 0.33)
                tamaniocolumna(2) = Convert.ToSingle(Anchoutil * 0.33)
                Encabezadosx.SetWidths(tamaniocolumna)
                'TOTAL GENERAL
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente + 2, False))))
                PdfpCell_.BorderWidth = 0
                PdfpCell_.HorizontalAlignment = Element.ALIGN_CENTER
                PdfpCell_.Colspan = 2
                PdfpCell_.Rowspan = 5
                Encabezadosx.AddCell(PdfpCell_)
                'NETO
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Neto:" & Format(SumaNeto, "C"), PDF_fuente_variable(tamaniofuente + 2, False))))
                PdfpCell_.BorderWidth = 0.5
                PdfpCell_.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfpCell_.Colspan = 1
                PdfpCell_.Rowspan = 1
                Encabezadosx.AddCell(PdfpCell_)
                'RETENCIONES
                If (SumaGanancias > 0) Then
                    'GANANCIAS
                    PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" GANANCIAS: " & Format(SumaGanancias, "C"), PDF_fuente_variable(tamaniofuente + 2, False))))
                    PdfpCell_.BorderWidth = 0.5
                    PdfpCell_.HorizontalAlignment = Element.ALIGN_RIGHT
                    PdfpCell_.Colspan = 1
                    Encabezadosx.AddCell(PdfpCell_)
                End If
                If (SumaSUSS > 0) Then
                    'SUSS
                    PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" SUSS: " & Format(SumaSUSS, "C"), PDF_fuente_variable(tamaniofuente + 2, False))))
                    PdfpCell_.BorderWidth = 0.5
                    PdfpCell_.HorizontalAlignment = Element.ALIGN_RIGHT
                    PdfpCell_.Colspan = 1
                    Encabezadosx.AddCell(PdfpCell_)
                End If
                If (SumaIVA > 0) Then
                    'IVA
                    PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" IVA: " & Format(SumaIVA, "C"), PDF_fuente_variable(tamaniofuente + 2, False))))
                    PdfpCell_.BorderWidth = 0.5
                    PdfpCell_.HorizontalAlignment = Element.ALIGN_RIGHT
                    PdfpCell_.Colspan = 1
                    Encabezadosx.AddCell(PdfpCell_)
                End If
                If (SumaDGR > 0) Then
                    'DGR
                    PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" DGR: " & Format(SumaDGR, "C"), PDF_fuente_variable(tamaniofuente + 2, False))))
                    PdfpCell_.BorderWidth = 0.5
                    PdfpCell_.HorizontalAlignment = Element.ALIGN_RIGHT
                    PdfpCell_.Colspan = 1
                    Encabezadosx.AddCell(PdfpCell_)
                End If
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL: " & Format(Decimal.Round(SumaTotal, 2), "C"), PDF_fuente_variable(tamaniofuente + 3, True))))
                PdfpCell_.BorderWidth = 0.5
                PdfpCell_.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfpCell_.Colspan = 1
                PdfpCell_.Rowspan = 4
                Encabezadosx.AddCell(PdfpCell_)
                Doc.Add(Encabezadosx)
                Dim firma As PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                firma.TotalWidth = Anchoutil
                firma.LockedWidth = True
                'Declaración variable de ancho de columnas
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchoutil * 0.34)
                tamaniocolumna(1) = Convert.ToSingle(Anchoutil * 0.33)
                tamaniocolumna(2) = Convert.ToSingle(Anchoutil * 0.33)
                firma.SetWidths(tamaniocolumna)
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", PDF_fuente_variable(tamaniofuente + 2, False))))
                PdfpCell_.BorderWidth = 0
                PdfpCell_.HorizontalAlignment = Element.ALIGN_CENTER
                PdfpCell_.Colspan = 2
                PdfpCell_.Rowspan = 8
                firma.AddCell(PdfpCell_)
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("_____________________________", PDF_fuente_variable(tamaniofuente, True))))
                PdfpCell_.BorderWidth = 0
                PdfpCell_.HorizontalAlignment = Element.ALIGN_CENTER
                PdfpCell_.VerticalAlignment = Element.ALIGN_BOTTOM
                PdfpCell_.FixedHeight = 45
                PdfpCell_.Colspan = 1
                PdfpCell_.Rowspan = 2
                firma.AddCell(PdfpCell_)
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" FIRMA ", PDF_fuente_variable(tamaniofuente + 2, True))))
                PdfpCell_.BorderWidth = 0
                PdfpCell_.HorizontalAlignment = Element.ALIGN_CENTER
                PdfpCell_.VerticalAlignment = Element.ALIGN_TOP
                PdfpCell_.Colspan = 1
                PdfpCell_.Rowspan = 2
                firma.AddCell(PdfpCell_)
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("................................................................", PDF_fuente_variable(tamaniofuente, False))))
                PdfpCell_.BorderWidth = 0
                PdfpCell_.HorizontalAlignment = Element.ALIGN_CENTER
                PdfpCell_.VerticalAlignment = Element.ALIGN_BOTTOM
                PdfpCell_.FixedHeight = 45
                PdfpCell_.Colspan = 1
                PdfpCell_.Rowspan = 2
                firma.AddCell(PdfpCell_)
                PdfpCell_ = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ACLARACIÓN ", PDF_fuente_variable(tamaniofuente + 2, False))))
                PdfpCell_.BorderWidth = 0
                PdfpCell_.HorizontalAlignment = Element.ALIGN_CENTER
                PdfpCell_.VerticalAlignment = Element.ALIGN_TOP
                PdfpCell_.Colspan = 1
                PdfpCell_.Rowspan = 2
                firma.AddCell(PdfpCell_)
                Doc.Add(firma)
                ' Doc.Add(PARRAFOCOMPLETO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
                                                     })
            End Select
        End If
    End Sub

    Shared Function CertificadoTotales_tabla(ByVal tabladedatos As DataTable, ByVal proveedors As Proveedor, ByVal Doc As Document) As PdfPTable
        'Crear tabla General para cargar los bordes
        Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
        'declaración de Fuentes a utilizar en el archivo
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Anchopagina As Single = Doc.PageSize.Width
        Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
        Tabla_total.LockedWidth = True
        Dim tamaniocolumna_total As Single() = New Single(0) {}
        tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
        Tabla_total.SetWidths(tamaniocolumna_total)
        'Creación de la celda que manejaria cada uno de los cuadros
        Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
        Dim Phrasetemporal As New iTextSharp.text.Phrase()
        'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
        Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
        Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        Encabezadosx.LockedWidth = True
        'Declaración variable de ancho de columnas
        Dim tamaniocolumna As Single() = New Single(1) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
        Encabezadosx.SetWidths(tamaniocolumna)
        'para insertar un espacio entre las celdas
        Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", font10Normal)))
        PdfpCell_espaciovacio.BorderWidth = 0
        PdfpCell_espaciovacio.FixedHeight = 2.0F
        'crear imagen con logo a la izquierda
        Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, System.Drawing.Imaging.ImageFormat.Jpeg)
        'asignar la imagen itextsharp a la celda
        Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
        PdfPCell.Rowspan = 3
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
        PdfPCell.FixedHeight = 70.0F
        Encabezadosx.AddCell(PdfPCell)
        'Encabezado del año
        PdfPCell = New iTextSharp.text.pdf.PdfPCell((New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(Date.Now.Year), font10Normal))))
        With PdfPCell
            .BorderWidth = 0
            .HorizontalAlignment = Element.ALIGN_CENTER
            .FixedHeight = 25.0F
        End With
        Encabezadosx.AddCell(PdfPCell)
        '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(10, True))))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(proveedors.Nombre & " - CUIT: " & proveedors.CUIT, PDF_fuente_variable(10, False))))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.FixedHeight = 15.0F
        'PdfPCell.Colspan = 2
        Encabezadosx.AddCell(PdfPCell)
        '----------------------AGREGA EL ENCABEZADO Completo------------------------------
        ' Frase_total.Clear()
        PARRAFOCOMPLETO.Add(Encabezadosx)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        Tabla_total.AddCell(PdfpCell_espaciovacio)
        ' Doc.Add(Encabezadosx)
        '----------------------CARGA LOS DATOS DEL CERTIFICADO------------------------------
        PARRAFOCOMPLETO.Clear()
        Encabezadosx = New iTextSharp.text.pdf.PdfPTable(3)
        Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        Encabezadosx.LockedWidth = True
        'Declaración variable de ancho de columnas
        tamaniocolumna = New Single(2) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.25)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.5)
        tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.25)
        Encabezadosx.SetWidths(tamaniocolumna)
        'AGREGA LOS DATOS DEL CERTIFICADO
        'carga las retenciones asociadas al movimiento seleccionado
        Dim retenciones As New DataTable
        ''DATOS DEL EXPEDIENTE
        retenciones = tabladedatos
        tamaniocolumna = New Single(retenciones.Columns.Count - 1) {}
        Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
        For x = 0 To retenciones.Columns.Count - 1
            tamaniocolumna(x) = Convert.ToSingle(anchoutil / retenciones.Columns.Count)
        Next
        Dim SumaNeto As Decimal = 0
        Dim SumaGanancias As Decimal = 0
        Dim SumaSUSS As Decimal = 0
        Dim SumaIVA As Decimal = 0
        Dim SumaDGR As Decimal = 0
        Dim SumaTotal As Decimal = 0
        For x = 0 To retenciones.Rows.Count - 1
            SumaNeto += retenciones.Rows(x).Item("Neto")
            SumaGanancias += retenciones.Rows(x).Item("Ganancias")
            SumaSUSS += retenciones.Rows(x).Item("SUSS")
            SumaIVA += retenciones.Rows(x).Item("IVA")
            SumaDGR += retenciones.Rows(x).Item("DGR")
        Next
        SumaTotal = SumaNeto + SumaGanancias + SumaSUSS + SumaIVA + SumaDGR
        'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New Chunk(" Cheque Nro: " & "", font12Bold))) With {
        '    .BorderWidth = 0,
        '    .HorizontalAlignment = Element.ALIGN_CENTER,
        '    .Colspan = 3
        '}
        'PdfPCell.FixedHeight = 25.0F
        Encabezadosx.AddCell(PdfPCell)
        '---------------------------AGREGA A LA TABLA LOS DATOS DEL PROVEEDOR EN EL PARRAFO--------------------
        PARRAFOCOMPLETO.Add(Encabezadosx)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        Tabla_total.AddCell(PdfpCell_espaciovacio)
        ' Doc.Add(Encabezadosx)
        '----------------------CARGA LOS DATOS DEL CERTIFICADO------------------------------
        PARRAFOCOMPLETO.Clear()
        '---------------------------------------------TABLA CON TODOS LOS DATOS----------------------------------------------------------------------------------------------
        Dim tablaretenciones As iTextSharp.text.pdf.PdfPTable = PDFDatatable_certificado(retenciones, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9, True)
        '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
        'Agrega tabla de pedido de fondos
        PARRAFOCOMPLETO.Add(tablaretenciones)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        'Agrega los totales
        Encabezadosx = New iTextSharp.text.pdf.PdfPTable(3)
        Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
        Encabezadosx.LockedWidth = True
        'Declaración variable de ancho de columnas
        tamaniocolumna = New Single(2) {}
        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.34)
        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.33)
        tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.33)
        Encabezadosx.SetWidths(tamaniocolumna)
        'TOTAL GENERAL
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Total Facturado: " & Format(Decimal.Round(SumaTotal, 2), "C"), font10Normal)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 1
        PdfPCell.Rowspan = 4
        Encabezadosx.AddCell(PdfPCell)
        'NETO
        PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" Neto : " & Format(SumaNeto, "C"), font12Bold)))
        PdfPCell.BorderWidth = 0
        PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
        PdfPCell.Colspan = 1
        PdfPCell.Rowspan = 4
        Encabezadosx.AddCell(PdfPCell)
        'RETENCIONES
        If (SumaGanancias > 0) Then
            'GANANCIAS
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" GANANCIAS: " & Format(SumaGanancias, "C"), font10Normal)))
            PdfPCell.BorderWidth = 0
            PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
            PdfPCell.Colspan = 1
            Encabezadosx.AddCell(PdfPCell)
        End If
        If (SumaSUSS > 0) Then
            'SUSS
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" SUSS: " & Format(SumaSUSS, "C"), font10Normal)))
            PdfPCell.BorderWidth = 0
            PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
            PdfPCell.Colspan = 1
            Encabezadosx.AddCell(PdfPCell)
        End If
        If (SumaIVA > 0) Then
            'IVA
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" IVA: " & Format(SumaIVA, "C"), font10Normal)))
            PdfPCell.BorderWidth = 0
            PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
            PdfPCell.Colspan = 1
            Encabezadosx.AddCell(PdfPCell)
        End If
        If (SumaDGR > 0) Then
            'DGR
            PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" DGR: " & Format(SumaDGR, "C"), font10Normal)))
            PdfPCell.BorderWidth = 0
            PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
            PdfPCell.Colspan = 1
            Encabezadosx.AddCell(PdfPCell)
        End If
        'PdfPCell.FixedHeight = 25.0F
        PARRAFOCOMPLETO.Clear()
        PARRAFOCOMPLETO.Add(Encabezadosx)
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        PARRAFOCOMPLETO.Clear()
        With PARRAFOCOMPLETO
            .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", ""))
        End With
        Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
        '/estructura de Tesorería General de la provincia
        'Agregar Tabla al final de la generación del documento
        Return Tabla_total
    End Function

    ''' <summary>
    ''' Genera PDF para un pago que concentre todos los movimientos involucrados por NRO DE TRANSFERENCIA/CHEQUE
    ''' </summary>
    ''' <param name="nro_transferencia"> es el número de transferencia o cheque</param>
    Public Sub Generarcertificadopago(ByVal nro_transferencia As List(Of Double))
        'declaración de Fuentes a utilizar en el archivo
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Doc As New Document(PageSize.A4, 30, 30, 20, 20)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "CERT_RETENCION" & "\multiple\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "CERT_RETENCION" & "\multiple\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            If nro_transferencia.Count > 1 Then
                .FileName = "TOTAL-MULTIPLE.pdf"
            Else
                .FileName = "TOTAL-" & nro_transferencia(0) & ".pdf"
            End If
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "CERT_RETENCION" & "\multiple\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                ' Inserta la tabla o tablas dentro del PDF
                '
                Doc.NewPage()
                For x = 0 To nro_transferencia.Count - 1
                    'Insertar una página en blanco nueva
                    If x > 0 Then
                        Doc.Add(CertificadoTotales(nro_transferencia(x), Doc, False))
                    Else
                        Doc.Add(CertificadoTotales(nro_transferencia(x), Doc))
                    End If
                    ' Doc.Add(PARRAFOCOMPLETO)
                Next
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
                                                     })
            End Select
        End If
    End Sub

    Public Sub Generarcertificadosmultiple(ByVal movimiento_actual As Movimiento)
        Dim nro_transferencia As Long = movimiento_actual.Transferencia
        Dim CUIT As String = movimiento_actual.CUIT
        Dim fecha As Date = movimiento_actual.Fecha_movimiento
        Dim PROVEEDOR_CERTIFICADO As New Proveedor
        Dim Total_Factura As Decimal = 0
        Dim movimientosretenciones As New DataTable
        Dim movimiento_me As New Movimiento
        Select Case nro_transferencia
            Case Is = 0
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nrotransferencia", nro_transferencia)
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", movimiento_actual.CUIT)
                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select clave_expediente_detalle,detalle from expediente_Detalle where nrotransferencia=@nrotransferencia and codinp=1
and CUIT=@cuit", movimientosretenciones, "Generarcertificadosmultiple")
            Case Else
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nrotransferencia", nro_transferencia)
                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select clave_expediente_detalle from expediente_Detalle where nrotransferencia=@nrotransferencia ", movimientosretenciones, "Generarcertificadosmultiple")
        End Select
        'declaración de Fuentes a utilizar en el archivo
        'Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        'Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        'Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        'Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        'Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        'Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        'Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        'Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim Datos As New DataTable
        Dim impresor As New Impresion
        impresor.fecha = movimiento_actual.Fecha_movimiento
        impresor.cargartodoslossellos()
        impresor.tamaniofuente = 11
        impresor.tamaniofuentetitulos = 13
        impresor.hoja = PageSize.A4
        impresor.marginleft = 30
        impresor.marginright = 30
        impresor.margintop = 20
        impresor.marginbottom = 20
        'clase
        'itextsharp.pagesize
        'New iTextSharp.text.Font
        'font size
        Dialogo_impresion.Cargar_impresion(impresor)
        Dim Doc As New Document(impresor.hoja, impresor.marginleft, impresor.marginright, impresor.margintop, impresor.marginbottom)
        'Dim Doc As New Document(PageSize.A4, 30, 30, 20, 20)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "CERT_RETENCION" & "\multiple\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "CERT_RETENCION" & "\multiple\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            If nro_transferencia = 0 Then
                .FileName = "multiple-CBU-" & CUIT & ".pdf"
            Else
                .FileName = "multiple-" & nro_transferencia & ".pdf"
            End If
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "CERT_RETENCION" & "\multiple\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                'Comienzo de la creación del documento
                Dim tablatotal As PdfPTable
                'para insertar un espacio entre las celdas
                Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", PDF_fuente_variable(impresor.tamaniofuente, False))))
                PdfpCell_espaciovacio.BorderWidth = 0
                PdfpCell_espaciovacio.FixedHeight = 2.0F
                'multiple
                For x = 0 To movimientosretenciones.Rows.Count - 1
                    movimiento_me = movimiento_me.cargarmovimiento(movimientosretenciones(x).Item("clave_expediente_detalle"))
                    PROVEEDOR_CERTIFICADO.CUIT = CUIT
                    PROVEEDOR_CERTIFICADO.Cargardatos()
                    tablatotal = Certificado(movimiento_me, Doc, PROVEEDOR_CERTIFICADO, impresor)
                    'Agregar Tabla al final de la generación del documento
                    If x = 0 Or (x Mod 2 = 0) Then
                        Doc.NewPage()
                        If tablatotal.TotalHeight < ((Doc.PageSize.Height / 2) - 30) Then
                            PdfpCell_espaciovacio.FixedHeight = ((Doc.PageSize.Height / 2) - 30) - (tablatotal.TotalHeight)
                            tablatotal.AddCell(PdfpCell_espaciovacio)
                        End If
                        Doc.Add(tablatotal)
                    Else
                        Doc.Add(tablatotal)
                    End If
                    If x = movimientosretenciones.Rows.Count - 1 Then
                        tablatotal = CertificadoTotales(nro_transferencia, Doc,, CUIT, impresor)
                        If x = 0 Or (x Mod 2 = 0) Then
                            Doc.NewPage()
                            Doc.Add(tablatotal)
                        Else
                            'If tablatotal.TotalHeight > ((Doc.PageSize.Height / 2) + 10) Then
                            '    Doc.NewPage()
                            '    Doc.Add(tablatotal)
                            'Else
                            '    tablatotal.AddCell(PdfpCell_espaciovacio)
                            '    Doc.Add(tablatotal)
                            'End If
                            Doc.NewPage()
                            Doc.Add(tablatotal)
                        End If
                    End If
                Next
                ' Doc.Add(PARRAFOCOMPLETO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                        Doc.Left, Doc.Bottom,
                                      Doc.Right, 0,
                                        15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
                                                     })
            End Select
        End If
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************