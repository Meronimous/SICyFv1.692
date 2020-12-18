Public Class Contabilidad_listadoordenespago
    Dim ordenprovision_datatable As New DataTable
    Dim ordenpago As New Ordendepago

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Refresh()
        Datos_ordenpago.SuspendLayout()
        Dim consultasql As String = "
SELECT
concat(cast(substring(ORDENPAGO.CLAVE_ORDENPAGO from 9 for 5) as unsigned),'/',cast(substring(ORDENPAGO.CLAVE_ORDENPAGO from 1 for 4) as unsigned)) AS 'ORDEN DE PAGO Nº',ORDENPAGO.TIPO AS 'TIPO',
ORDENPAGO.FECHA,CONCAT(USUARIOS.APELLIDOS,' ',USUARIOS.NOMBRES) AS 'AUTOR',
ORDENPAGO.ESTADO AS 'ESTADO',
GROUP_CONCAT(DISTINCT PARTIDAPRESUPUESTARIA.CUENTA,' ') AS 'CUENTA',
CASE WHEN ORDENPAGO.TIPO='PAGO' THEN GROUP_CONCAT(DISTINCT PROVEEDORES.PROVEEDOR,' ') ELSE
CASE WHEN ISNULL(ACTARECEPCION.EFECTOR) THEN SINACTARECEPCION.EFECTOR ELSE ACTARECEPCION.EFECTOR END
END as 'EFECTOR',
CASE WHEN ISNULL(ACTARECEPCION.PERIODO) THEN SINACTARECEPCION.PERIODO ELSE ACTARECEPCION.PERIODO END as 'PERIODO',
GROUP_CONCAT(DISTINCT ACTARECEPCION.DETALLE,' ') AS 'PRODUCTO/SERVICIOS',
GROUP_CONCAT(DISTINCT CASE WHEN ORDENPROVISION.INICIADOR='CARGA AUTOMÁTICA CONTABILIDAD' THEN ACTARECEPCION.DETALLE ELSE
 ORDENPROVISION.DESTINO END,' ' )
AS 'DESTINO',
GROUP_CONCAT(DISTINCT ACTARECEPCION.PERIODO,' ') AS 'MES',
GROUP_CONCAT(DISTINCT concat(cast(substring(ORDENPROVISION.CLAVE_ORDENPROVISION from 9 for 5) as unsigned),'/',cast(substring(ORDENPROVISION.CLAVE_ORDENPROVISION from 1 for 4) as unsigned)),' ')  AS 'ORDEN DE PROVISIÓN Nº',
GROUP_CONCAT(DISTINCT concat(ORDENPROVISION.Tipo_origen,' Nº',ORDENPROVISION.Numero_origen,'/',ORDENPROVISION.YEAR_ORIGEN),' ')
 AS 'CONT.DIREC/ LIC. PUBL/ COMPRA. DIR',
GROUP_CONCAT(DISTINCT concat(ORDENPROVISION.Tipo_instrumentolegal,' Nº',ORDENPROVISION.Numero_instrumentolegal,'/',ORDENPROVISION.Year_instrumentolegal),' ') AS 'DECRETO/ RESOLUCIÓN',
GROUP_CONCAT(DISTINCT concat(cast(substring(ACTARECEPCION.Clave_actarecepcion from 9 for 5) as unsigned),'/',cast(substring(ACTARECEPCION.ACTARECEPCION.Clave_actarecepcion from 1 for 4) as unsigned))) AS 'ACTA DE RECEPCIÓN',
ORDENPAGO.MONTO AS 'IMPORTE',
partidapresupuestaria.IMPORTE AS 'IMPORTE PARTIDAS',
ORDENPAGO.CLASE_FONDO AS 'OBSERVACIONES',
CASE WHEN ORDENPAGO.TIPO='PAGO' THEN 0 ELSE
CASE WHEN ISNULL(ACTARECEPCION.TOTAL) THEN SINACTARECEPCION.RECURSOS ELSE 0 END
END AS 'RECURSOS',
CASE WHEN ORDENPAGO.TIPO='PAGO' THEN 0 ELSE
CASE WHEN ISNULL(ACTARECEPCION.TOTAL) THEN SINACTARECEPCION.GASTOS ELSE ACTARECEPCION.TOTAL END
END AS 'GASTOS',
ORDENPAGO.CLAVE_ORDENPAGO
FROM
(SELECT * ,
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as 'Expediente N',
CONCAT(Substring(CLAVE_EXPEDIENTE_PRINCIPAL From 5 for 4),'-',cast(Substring(CLAVE_EXPEDIENTE_PRINCIPAL From 9 for 5)AS UNSIGNED),'/',Substring(CLAVE_EXPEDIENTE_PRINCIPAL From 1 for 4)) as 'Expediente Madre Nº'
FROM contabilidad_ordenpago)ORDENPAGO
LEFT JOIN
(SELECT * FROM contabilidad_actasrecepcion)ACTARECEPCION
ON
ORDENPAGO.CLAVE_ORDENPAGO=ACTARECEPCION.CLAVE_ORDENPAGO
LEFT JOIN
(SELECT * FROM contabilidad_sinactarecepcion)SINACTARECEPCION
ON
ORDENPAGO.CLAVE_ORDENPAGO=SINACTARECEPCION.CLAVE_ORDENPAGO
LEFT JOIN
(SELECT *,CONCAT(JUR,'-',
UO,'-',
CARAC,'-',
FI,'-',
FUN,'-',
SECC,'-',
SECT,'-',
PDAPCIAL,'-',
PDASUBPAR,'-',
PDAPPAL,SCD,' (',FORMAT(IMPORTE,2,'es_AR'),') '  )AS 'CUENTA'
FROM contabilidad_partidaexpediente )PARTIDAPRESUPUESTARIA
ON
ORDENPAGO.Clave_Ordenpago=PARTIDAPRESUPUESTARIA.CLAVE_ORDENPAGO
LEFT JOIN
(SELECT * FROM PROVEEDORES)PROVEEDORES
ON
ACTARECEPCION.CUIT=PROVEEDORES.CUIT
LEFT JOIN
(SELECT * FROM contabilidad_ordenpago_provision)OPROVCONTA
ON ORDENPAGO.CLAVE_ORDENPAGO=OPROVCONTA.CLAVE_ORDENPAGO
LEFT JOIN
(SELECT * FROM suministros_orden_provision)ORDENPROVISION
ON OPROVCONTA.clave_ordenprovision= ORDENPROVISION.Clave_ordenprovision
LEFT JOIN
(SELECT * FROM CONTADURIA_USUARIOS.USUARIOS)USUARIOS
ON ORDENPAGO.USUARIO= USUARIOS.USUARIO
GROUP BY ORDENPAGO.CLAVE_ORDENPAGO
ORDER BY ORDENPAGO.CLAVE_ORDENPAGO DESC"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, ordenprovision_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_ordenpago.DataSource = ordenprovision_datatable
        Formatocolumnas(Datos_ordenpago, CType(Datos_ordenpago.DataSource, DataTable))
        Datos_ordenpago.Columns("Clave_ORDENPAGO").Visible = False
        '  Datos_ordenpago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Datos_ordenpago.ResumeLayout()
        ' Datos_ordenprovision.Columns("Clave_expediente").Visible = False
        'Datos_ordenpago.Columns("IMPORTE").DefaultCellStyle.Format = "C"
        'Datos_ordenpago.Columns("IMPORTE PARTIDAS").DefaultCellStyle.Format = "C"
        'Datos_ordenprovision.Columns("Iniciador").Visible = True
        'Datos_ordenprovision.Columns("Destino").Visible = True
        'Datos_ordenprovision.Columns("Tipo_origen").Visible = False
        'Datos_ordenprovision.Columns("Numero_origen").Visible = False
        'Datos_ordenprovision.Columns("Year_origen").Visible = False
        'Datos_ordenprovision.Columns("Fecha_origen").Visible = False
        'Datos_ordenprovision.Columns("CUIT").Visible = False
        'Datos_ordenprovision.Columns("Tipo_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Numero_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Year_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Fecha_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Total").Visible = True
        'Datos_ordenprovision.Columns("Lugar_entrega").Visible = False
        'Datos_ordenprovision.Columns("valor_tiempoentrega").Visible = False
        'Datos_ordenprovision.Columns("Unidad_tiempoentrega").Visible = False
        'Datos_ordenprovision.Columns("fecharealizada_ordenprovision").Visible = False
        'Datos_ordenprovision.Columns("Fechaconfeccionada_ordenprovision").Visible = False
        'Datos_datagrid.Columns("IMPORTE O.P.").DefaultCellStyle.Format = "C"
        'Datos_datagrid.Columns("Monto").DefaultCellStyle.Format = "C"
        'Datos_datagrid.Columns("clave_expediente").Visible = False
        'Datos_datagrid.Columns("clave_ordenprovision").Visible = False
        'Datos_datagrid.Columns("Clave_expediente").Visible = False
        'Datos_datagrid.Columns("Clave_expediente").Visible = False
        'Datos_datagrid.Columns("Cuenta_especial").Visible = False
    End Sub

    Private Sub Refresh_op_Click(sender As Object, e As EventArgs) Handles Refresh_op.Click
        Refresh()
    End Sub

    Private Sub Datos_ordenprovision_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenpago.CellEnter
        cargarordenprovisiondata()
    End Sub

    Private Sub cargarordenprovisiondata()
        If Datos_ordenpago.SelectedRows.Count > 0 Then
            ordenpago.cargar_ordepago(Datos_ordenpago.SelectedRows(0).Cells.Item("CLAVE_ORDENPAGO").Value)
            'ordendeprovision.cargar_OP(ordendeprovision.Clave_ordenprovision)
            Select Case ordenpago.Ordenpago_tipo.ToUpper
                Case Is = "PAGO"
                    Datos_ordenpago_detalle.DataSource = OrdenProvision.Estructura_Seleccionordenprovision(Datos_ordenpago.SelectedRows(0).Cells.Item("CLAVE_ORDENPAGO").Value)
                Case Is = "RECONOCIMIENTO"
                    Datos_ordenpago_detalle.DataSource = Nothing
                Case Is = "HABERES"
                    Datos_ordenpago_detalle.DataSource = ordenpago.HABERES_DETALLE
                Case Is = "RENDICIONES"
                    Datos_ordenpago_detalle.DataSource = Nothing
            End Select
            'Datos_ordenprovision_detalle.Columns("Cant.").DefaultCellStyle.Format = "N2"
            ''Datos_ordenprovision.Columns("Cant.").DefaultCellStyle.Format = "N2"
            'Datos_ordenprovision_detalle.Columns("Prec.Unit.").DefaultCellStyle.Format = "C"
            'Datos_ordenprovision_detalle.Columns("Prec.Total").DefaultCellStyle.Format = "C"
        End If
    End Sub

    Private Sub Datos_ordenprovision_detalle_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_ordenpago_detalle.MouseUp, Datos_ordenpago.MouseUp
        Inicio.MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub Busqueda_OP_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_OP.TextChanged
        Buscar_datagrid_TIMER(sender, ordenprovision_datatable, Datos_ordenpago)
    End Sub

    Private Sub Suministros_listadoordenesprovision_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Inicio.OBJETOCARGANDO(Flicker_Split_panel1, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Refresh()
        Inicio.OBJETOFINALIZAR(Flicker_Split_panel1, Me)
    End Sub

    Private Sub IMPRIMIR_BOTON_Click(sender As Object, e As EventArgs) Handles IMPRIMIR_BOTON.Click
        If Datos_ordenpago.SelectedRows.Count > 0 Then
            Dim ORDENPAGO As New Ordendepago
            For x = 0 To Datos_ordenpago.SelectedRows.Count - 1
                ORDENPAGO = New Ordendepago
                ORDENPAGO.Clave_ordenpago = Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value
                'ORDENPAGO.expediente_op.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value
                ORDENPAGO.cargar_ordepago(Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value)
                ORDENPAGO.SINACTAS_DATATABLE = SINACTARECEPCION.Estructura_SeleccionSINACTARECEPCION(ORDENPAGO.Clave_ordenpago)
                ORDENPAGO.Datatable_a_SINACTAS(ORDENPAGO.SINACTAS_DATATABLE)
                IMPRIMIRTipoordenpago(ORDENPAGO)
            Next
        End If
    End Sub

    Private Sub IMPRIMIRTipoordenpago(ByVal ORDENPAGO As Ordendepago)
        'If nuevo Then
        '    ORDENPAGO.Insertar_ordenpago()
        'End If
        Select Case ORDENPAGO.Ordenpago_tipo.ToUpper
            Case Is = "ARANCELAMIENTO"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "HABERES"
                PDF_ORDENPAGO_HABERESv2(ORDENPAGO)'PDF_ORDENPAGO_HABERES(ORDENPAGO, "LEGAL")
                'Contabilidad_DialogoHaberes.Cargadedatos(ORDENPAGO)
            Case Is = "PAGO"
                PDF_ORDENPAGO_PagoV2(ORDENPAGO) 'PDF_ORDENPAGO_Pago(ORDENPAGO, "LEGAL")
            Case Is = "TRANSFERENCIA"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                'Contabilidad_DialogoOrdenPago.Cargardatosamodificar(ORDENPAGO)
            'Case Is = "PAGO MULTIPLES EFECTORES"
            '    PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "REDETERMINACIÓN"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RENDICIÓN"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RENDICIÓN FINAL"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RENDICIÓN PARCIAL"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RECONOCIMIENTO"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "VIÁTICOS"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "REPOSICIÓN"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "CONTRATOS"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "BECAS"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "COMISIÓN BANCARIA"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
        End Select
    End Sub

End Class