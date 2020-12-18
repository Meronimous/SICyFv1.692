Public Class Tesoreria_recibos_retenciones
    Dim proveedores_datatable As New DataTable
    Dim EXPEDIENTES_Datatable As New DataTable
    Dim Listado_recibo As New DataTable
    Dim Expedientes_seleccionado_datatable As New DataTable
    Dim claves_expedientes_seleccionados As New List(Of Long)
    '  Dim EXPEDIENTES_DATAGRIDVIEW As New DataTable
    Dim consultasql As String = ""
    Dim proveedor As New Proveedor
    Dim RECIBO As New Recibo

    Private Sub Tesoreria_recibos_retenciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
    End Sub

    Private Sub carga_datos_basicos()
        consultasql = "Select * FROM proveedores where cuit in
(SELECT cuit from retenciones group by cuit) or cuit in (Select Cuit from cuit_movimiento) or cuit in (Select Cuit from cuit_expediente)"
        Proveedores_datagrid.DataSource = Nothing
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, proveedores_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Proveedores_datagrid.DataSource = proveedores_datatable
    End Sub

    Private Sub Proveedores_datagrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Proveedores_datagrid.CellEnter
        Fecha_Recibo.Value = Now
        Inicio.OBJETOCARGANDO(RetencionesTab, Me, "CARGANDO",, New Point(Flicker_Split_panel1.SplitterDistance, 0))
        Carga_movimientos_periodo_seleccionado()
        Inicio.OBJETOFINALIZAR(RetencionesTab, Me)
        modificacion()
    End Sub

    Private Sub Carga_movimientos_periodo_seleccionado()
        N_Recibo_numeric.Value = 0
        N_Recibo_numeric2.Value = 0
        If Proveedores_datagrid.SelectedRows.Count > 0 Then
            EXPEDIENTES_DATAGRIDVIEW.DataSource = Nothing
            Listado_recibos_datagridview.DataSource = Nothing
            Datos_recibos_datagridview.DataSource = Nothing
            proveedor.CUIT = Proveedores_datagrid.SelectedRows(0).Cells.Item("CUIT").Value
            proveedor.Cargardatos()
            '     SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
            SERVIDORMYSQL.COMMANDSQL.Parameters.Add("PARAMETRO_CUIT", MySql.Data.MySqlClient.MySqlDbType.VarChar, 13).Value = proveedor.CUIT
            SERVIDORMYSQL.COMMANDSQL.Parameters.Add("PARAMETRO_CUENTA", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
            SERVIDORMYSQL.COMMANDSQL.Parameters.Add("PARAMETRO_DESDE", MySql.Data.MySqlClient.MySqlDbType.Date).Value = New Date(Fecha_Recibo.Value.Date.Year, 1, 1)
            SERVIDORMYSQL.COMMANDSQL.Parameters.Add("PARAMETRO_HASTA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Fecha_Recibo.Value.Date
            Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_RETENCIONES_RECIBOS_DETALLE", EXPEDIENTES_Datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
            EXPEDIENTES_DATAGRIDVIEW.DataSource = Nothing
            EXPEDIENTES_DATAGRIDVIEW.DataSource = EXPEDIENTES_Datatable
            EXPEDIENTES_DATAGRIDVIEW.Columns.Item("MONTO").Visible = True
            EXPEDIENTES_DATAGRIDVIEW.Columns.Item("cuit").Visible = False
            Formatocolumnas(CType(EXPEDIENTES_DATAGRIDVIEW, Flicker_Datagridview), EXPEDIENTES_Datatable)
            Listado_recibos_datagridview_carga()
        End If
        calculo_totales()
    End Sub

    Private Sub Listado_recibos_datagridview_carga()
        Listado_recibos_datagridview.DataSource = Nothing
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuit", proveedor.CUIT)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
select
recibo.Nro_RECIBO,
FECHA_RECIBO,
TOTAL,
count(expediente_N) as 'Cant. Pagos',
`IVA`,
`GANANCIAS`,
`DGR`,
`SUSS`,
GROUP_CONCAT(distinct expediente_N,'  ') as 'Expedientes'
from
(
select Nro_RECIBO,FECHA_RECIBO,TOTAL, TOTAL_IVA AS 'IVA',TOTAL_GANANCIAS AS 'GANANCIAS'
,TOTAL_DGR AS 'DGR', TOTAL_SUSS AS 'SUSS' from tesoreria_recibos where cuit=@cuit)recibo
left join
(Select CLAVE_TO_EXPEDIENTE(Clave_expediente_detalle) as 'Expediente_N',Nrotransferencia,Nro_recibo from expediente_detalle where monto>0)movimientos
on recibo.Nro_RECIBO = movimientos.Nro_RECIBO
group by recibo.Nro_RECIBO
order by FECHA_RECIBO desc", Listado_recibo, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * FROM Expediente_detalle  where Nro_Transaccion=0 and fecha<=@hasta", Retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Listado_recibos_datagridview.DataSource = Listado_recibo
        'Listado_recibos_datagridview.Columns.Item("MONTO").Visible = True
        Listado_recibos_datagridview.Columns.Item("TOTAL").DefaultCellStyle.Format = "C"
        Listado_recibos_datagridview.Columns.Item("GANANCIAS").DefaultCellStyle.Format = "C"
        Listado_recibos_datagridview.Columns.Item("SUSS").DefaultCellStyle.Format = "C"
        Listado_recibos_datagridview.Columns.Item("IVA").DefaultCellStyle.Format = "C"
        Listado_recibos_datagridview.Columns.Item("DGR").DefaultCellStyle.Format = "C"
        'MovimientosNOasociados.Columns("clave_expediente_detalle").Visible = False
        'MovimientosNOasociados.Columns("Cuit_recaudador").Visible = False
        'MovimientosNOasociados.Columns("nombre_retencion_detalle").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
        EXPEDIENTES_DATAGRIDVIEW.CurrentCell = Nothing
    End Sub

    Private Sub Datos_recibos_datagridview_carga()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nro_recibo", Listado_recibos_datagridview.SelectedRows(0).Cells.Item("nro_recibo").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuit", proveedor.CUIT)
        Dim listado_recibo_detalle As New DataTable
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
SELECT
EXPEDIENTE_N,DETALLE,DETALLE.clave_expediente_detalle,
DETALLE.Nrotransferencia  as 'Nº Transferencia',
Fechadelmovimiento as 'Fecha',
MONTO,
CASE WHEN ISNULL(GANANCIAS.Monto_retenido) THEN 0 ELSE GANANCIAS.Monto_retenido END AS 'GANANCIAS',
CASE WHEN ISNULL(GANANCIAS.PAGADO) THEN '-' ELSE GANANCIAS.PAGADO END AS 'GCIAS PAGADO',
CASE WHEN ISNULL(SUSS.Monto_retenido) THEN 0 ELSE SUSS.Monto_retenido END AS 'SUSS',
CASE WHEN ISNULL(SUSS.PAGADO) THEN '-' ELSE SUSS.PAGADO END AS 'SUSS PAGADO',
CASE WHEN ISNULL(IVA.Monto_retenido) THEN 0 ELSE IVA.Monto_retenido END AS 'IVA',
CASE WHEN ISNULL(IVA.PAGADO) THEN '-' ELSE IVA.PAGADO END AS 'IVA PAGADO',
CASE WHEN ISNULL(DGR.Monto_retenido) THEN 0 ELSE DGR.Monto_retenido END AS 'DGR',
CASE WHEN ISNULL(DGR.PAGADO) THEN '-' ELSE DGR.PAGADO END AS 'DGR PAGADO'
from
(SElect CLAVE_TO_EXPEDIENTE(Clave_expediente_detalle) as 'Expediente_N',Detalle,Monto,Nrotransferencia,Fechadelmovimiento ,clave_expediente_detalle from expediente_detalle
where Cuit=@cuit and Nro_recibo=@Nro_recibo)DETALLE
left JOIN
(Select *,CASE WHEN ISNULL(RETENCION_CLAVE_DETALLE)THEN 'NO' ELSE 'SI' END AS `PAGADO`  from retenciones where Nombre_retencion='GANANCIAS' )GANANCIAS
on DETALLE.clave_expediente_detalle=GANANCIAS.clave_expediente_Detalle
left JOIN
(Select *,CASE WHEN ISNULL(RETENCION_CLAVE_DETALLE)THEN 'NO' ELSE 'SI' END AS `PAGADO` from retenciones where Nombre_retencion='SUSS' )SUSS
on DETALLE.clave_expediente_detalle=SUSS.clave_expediente_Detalle
left JOIN
(Select *,CASE WHEN ISNULL(RETENCION_CLAVE_DETALLE)THEN 'NO' ELSE 'SI' END AS `PAGADO` from retenciones where  Nombre_retencion='IVA' )IVA
on DETALLE.clave_expediente_detalle=IVA.clave_expediente_Detalle
left JOIN
(Select *,CASE WHEN ISNULL(RETENCION_CLAVE_DETALLE)THEN 'NO' ELSE 'SI' END AS `PAGADO` from retenciones where  Nombre_retencion='DGR' )DGR
on DETALLE.clave_expediente_detalle=DGR.clave_expediente_Detalle
 ", listado_recibo_detalle, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * FROM Expediente_detalle  where Nro_Transaccion=0 and fecha<=@hasta", Retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_recibos_datagridview.DataSource = listado_recibo_detalle
        Datos_recibos_datagridview.Columns.Item("monto").DefaultCellStyle.Format = "C"
        Datos_recibos_datagridview.Columns.Item("GANANCIAS").DefaultCellStyle.Format = "C"
        Datos_recibos_datagridview.Columns.Item("SUSS").DefaultCellStyle.Format = "C"
        Datos_recibos_datagridview.Columns.Item("IVA").DefaultCellStyle.Format = "C"
        Datos_recibos_datagridview.Columns.Item("DGR").DefaultCellStyle.Format = "C"
        Datos_recibos_datagridview.Columns("clave_expediente_detalle").Visible = False
        'MovimientosNOasociados.Columns("Cuit_recaudador").Visible = False
        'MovimientosNOasociados.Columns("nombre_retencion_detalle").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
    End Sub

    Private Sub calculo_totales()
        Dim Totales_seleccionado_datatable As New DataTable
        Dim Expedientes_seleccionado_datatable As New DataTable
        Dim total_factura As Decimal = 0
        Dim total_apagar As Decimal = 0
        Dim total_ganancias As Decimal = 0
        Dim total_suss As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim Total_DGR As Decimal = 0
        Dim expedientes As New List(Of String)
        Dim expedientesconcat As New List(Of String)
        For x = 0 To EXPEDIENTES_DATAGRIDVIEW.SelectedRows.Count - 1
            'total_apagar += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("").Value
            If expedientes.Contains(EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Expediente_N").Value.ToString) Then
                If Not expedientesconcat.Contains(EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("NROTRANSFERENCIA").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Expediente_N").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString) Then
                    expedientesconcat.Add(EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("NROTRANSFERENCIA").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Expediente_N").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString)
                    total_apagar += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Monto").Value
                    total_factura += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("TOTAL_factura").Value
                    total_ganancias += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("GANANCIAS").Value
                    total_suss += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("SUSS").Value
                    total_iva += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("IVA").Value
                    Total_DGR += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("DGR").Value
                End If
            Else
                expedientes.Add(EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Expediente_N").Value.ToString)
                If Not expedientesconcat.Contains(EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("NROTRANSFERENCIA").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Expediente_N").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString) Then
                    expedientesconcat.Add(EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("NROTRANSFERENCIA").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Expediente_N").Value.ToString & EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString)
                    total_apagar += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("Monto").Value
                    total_factura += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("TOTAL_factura").Value
                    total_ganancias += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("GANANCIAS").Value
                    total_suss += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("SUSS").Value
                    total_iva += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("IVA").Value
                    Total_DGR += EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("DGR").Value
                End If
            End If
        Next
        With Totales_seleccionado_datatable
            .Columns.Add("TOTAL")
            .Columns.Add("MONTO", GetType(System.Decimal))
            If total_factura > 0 Then
                .Rows.Add("Total Facturado", total_factura)
            End If
            If total_apagar > 0 Then
                .Rows.Add("Neto a Pagar", total_apagar)
            End If
            If total_ganancias > 0 Then
                .Rows.Add("GANANCIAS", total_ganancias)
            End If
            If total_suss > 0 Then
                .Rows.Add("SUSS", total_suss)
            End If
            If total_iva > 0 Then
                .Rows.Add("IVA", total_iva)
            End If
            If Total_DGR > 0 Then
                .Rows.Add("DGR", Total_DGR)
            End If
        End With
        With Expedientes_seleccionado_datatable
            .Columns.Add("EXPEDIENTE")
            If Not IsNothing(expedientes) Then
                For X = 0 To expedientes.Count - 1
                    .Rows.Add(expedientes.Item(X))
                Next
            End If
        End With
        TOTALES_SELECCIONADO.DataSource = Totales_seleccionado_datatable
        TOTALES_SELECCIONADO.Columns("MONTO").DefaultCellStyle.Format = "C"
        Expedientes_seleccionado.DataSource = Expedientes_seleccionado_datatable
        modificacion()
        TOTALES_SELECCIONADO.CurrentCell = Nothing
        Expedientes_seleccionado.CurrentCell = Nothing
    End Sub

    Private Sub EXPEDIENTES_DATAGRIDVIEW_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles EXPEDIENTES_DATAGRIDVIEW.CellEnter
        If EXPEDIENTES_DATAGRIDVIEW.SelectedRows.Count > 0 Then
            calculo_totales()
            Seleccion_a_table()
        Else
            Certificadoboton.Visible = False
        End If
    End Sub

    Private Sub Seleccion_a_table()
        claves_expedientes_seleccionados = New List(Of Long)
        For x As Integer = 0 To EXPEDIENTES_DATAGRIDVIEW.SelectedRows.Count - 1
            claves_expedientes_seleccionados.Add(CType(EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value, Long))
        Next
        'Expedientes_seleccionado_datatable = New DataTable
        'For Z As Integer = 0 To EXPEDIENTES_DATAGRIDVIEW.Columns.Count - 1
        '    Expedientes_seleccionado_datatable.Columns.Add(EXPEDIENTES_DATAGRIDVIEW.Columns.Item(Z).Name)
        'Next
        'For Each row As DataGridViewRow In EXPEDIENTES_DATAGRIDVIEW.SelectedRows
        '    Expedientes_seleccionado_datatable.Rows.Add()
        '    For Each cell As DataGridViewCell In row.Cells
        '        Expedientes_seleccionado_datatable.Rows(Expedientes_seleccionado_datatable.Rows.Count - 1)(cell.ColumnIndex) = cell.Value.ToString()
        '    Next
        'Next
        ''For x As Integer = 0 To EXPEDIENTES_DATAGRIDVIEW.SelectedRows.Count - 1
        ''    Expedientes_seleccionado_datatable.Rows.Add(EXPEDIENTES_DATAGRIDVIEW.DataSource.totable.rows((x)))
        ''Next
        Certificadoboton.Visible = True
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
        Buscar_datagrid_TIMER(sender, proveedores_datatable, Proveedores_datagrid)
    End Sub

    Private Sub Tesoreria_recibos_retenciones_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        carga_datos_basicos()
    End Sub

    Private Sub Recibo_boton_Click(sender As Object, e As EventArgs) Handles Recibo_boton.Click
        If N_Recibo_numeric.Value > 0 Or N_Recibo_numeric2.Value > 0 Then
            modificacion()
            RECIBO.insertar_recibo(RECIBO)
            For x = 0 To EXPEDIENTES_DATAGRIDVIEW.SelectedRows.Count - 1
                RECIBO.cargar_recibo(RECIBO, EXPEDIENTES_DATAGRIDVIEW.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value)
            Next
            Carga_movimientos_periodo_seleccionado()
            'MessageBox.Show(RECIBO.Nro_recibo & vbCrLf &
            '                  RECIBO.total & vbCrLf &
            '                  RECIBO.total_ganancias & vbCrLf &
            '                  RECIBO.total_suss & vbCrLf &
            '                  RECIBO.total_iva & vbCrLf &
            '                  RECIBO.total_dgr & vbCrLf
            '                  )
        Else
            MessageBox.Show("El NÚMERO de Recibo debe ser completado, por favor verifique")
        End If
    End Sub

    Private Sub N_Recibo_numeric_ValueChanged(sender As Object, e As EventArgs) Handles N_Recibo_numeric.ValueChanged
        modificacion()
    End Sub

    Private Sub modificacion()
        RECIBO.CUIT = proveedor.CUIT
        RECIBO.Nro_recibo = N_Recibo_numeric.Value.ToString("00000") & "-" & N_Recibo_numeric2.Value.ToString("00000000")
        RECIBO.Fecha_recibo = Fecha_Recibo.Value.Date
        RECIBO.total = 0
        RECIBO.total_ganancias = 0
        RECIBO.total_suss = 0
        RECIBO.total_iva = 0
        RECIBO.total_dgr = 0
        For X = 0 To TOTALES_SELECCIONADO.Rows.Count - 1
            Select Case TOTALES_SELECCIONADO.Rows(X).Cells.Item("TOTAL").Value.ToString.ToUpper
                Case Is = "TOTAL FACTURADO"
                    RECIBO.total = TOTALES_SELECCIONADO.Rows(X).Cells.Item("MONTO").Value
                Case Is = "GANANCIAS"
                    RECIBO.total_ganancias = TOTALES_SELECCIONADO.Rows(X).Cells.Item("MONTO").Value
                Case Is = "SUSS"
                    RECIBO.total_suss = TOTALES_SELECCIONADO.Rows(X).Cells.Item("MONTO").Value
                Case Is = "IVA"
                    RECIBO.total_iva = TOTALES_SELECCIONADO.Rows(X).Cells.Item("MONTO").Value
                Case Is = "DGR"
                    RECIBO.total_dgr = TOTALES_SELECCIONADO.Rows(X).Cells.Item("MONTO").Value
            End Select
        Next
    End Sub

    Private Sub N_Recibo_numeric2_ValueChanged(sender As Object, e As EventArgs) Handles N_Recibo_numeric2.ValueChanged
        modificacion()
    End Sub

    Private Sub Fecha_Recibo_ValueChanged(sender As Object, e As EventArgs) Handles Fecha_Recibo.ValueChanged
        modificacion()
    End Sub

    Private Sub EXPEDIENTES_DATAGRIDVIEW_MouseUp(sender As Object, e As MouseEventArgs) Handles EXPEDIENTES_DATAGRIDVIEW.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub Proveedores_datagrid_MouseUp(sender As Object, e As MouseEventArgs) Handles Proveedores_datagrid.MouseUp, Expedientes_seleccionado.MouseUp, TOTALES_SELECCIONADO.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub Certificadoboton_Click(sender As Object, e As EventArgs) Handles Certificadoboton.Click
        Dim consultasql As String = ""
        Dim tablatemporal As New DataTable
        Dim listaborrar As New List(Of Integer)
        Dim filtro As String = ""
        For x = 0 To claves_expedientes_seleccionados.Count - 1
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave" & x, claves_expedientes_seleccionados(x))
            If x = 0 Then
                filtro = " WHERE (NETO+Ganancias+SUSS+IVA+DGR>0) AND (clave_expediente_Detalle=@" & "clave" & x
            Else
                filtro += "clave_expediente_Detalle=@" & "clave" & x
            End If
            If x = claves_expedientes_seleccionados.Count - 1 Then
                filtro += " ); "
            Else
                filtro += " OR "
            End If
        Next
        consultasql = "Select * from (
SELECT CONCAT(Substring(clave_expediente_detalle From 5 for 4),'-',cast(Substring(clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente_detalle From 1 for 4)) as Expediente_N,
CONCAT(cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) as 'Ped.Fond.',
Monto as 'NETO',
case when isnull(Ganancias) then 0 else Ganancias END as 'GANANCIAS',
case when isnull(SUSS) then 0 else SUSS END as 'SUSS',
case when isnull(IVA) then 0 else IVA END as 'IVA',
case when isnull(DGR) then 0 else DGR END as 'DGR',clave_expediente_detalle FROM
(Select CLAVE_TO_EXPEDIENTE(Clave_expediente_detalle) as 'Expediente_N', monto,Clave_expediente_detalle from expediente_Detalle
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
A.CLAVE_EXPEDIENTE_DETALLE = R4.C4
left join
(Select CLAVE_EXPEDIENTE,Clave_pedidofondo from expediente)exp
ON
substring(A.CLAVE_EXPEDIENTE_DETALLE from 1 for 13) = exp.clave_expediente
)Z   " & filtro
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Expedientes_seleccionado_datatable = New DataTable
        For Z As Integer = 0 To tablatemporal.Columns.Count - 2
            Expedientes_seleccionado_datatable.Columns.Add(tablatemporal.Columns(Z).ToString)
        Next
        For Each row As DataRow In tablatemporal.Rows
            Expedientes_seleccionado_datatable.Rows.Add()
            For C As Integer = 0 To tablatemporal.Columns.Count - 2
                Expedientes_seleccionado_datatable.Rows(Expedientes_seleccionado_datatable.Rows.Count - 1)(C) = row.Item(C)
            Next
        Next
        Movimiento.Generarcertificadopagotabla(Expedientes_seleccionado_datatable, proveedor)
        'Movimiento.Generarrecibo(RECIBO, Expedientes_seleccionado_datatable, proveedor, Fecha_Recibo.Value, 10)
    End Sub

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(sender, EXPEDIENTES_Datatable, EXPEDIENTES_DATAGRIDVIEW)
    End Sub

    Private Sub Listado_recibos_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Listado_recibos_datagridview.CellEnter
        If sender.selectedrows.count > 0 Then
            Datos_recibos_datagridview_carga()
        End If
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        Carga_movimientos_periodo_seleccionado()
        modificacion()
    End Sub

    Private Sub busquedarecibos_TextChanged(sender As Object, e As EventArgs) Handles busquedarecibos.TextChanged
        Buscar_datagrid_TIMER(sender, Listado_recibo, Listado_recibos_datagridview)
    End Sub

    Private Sub Datos_recibos_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_recibos_datagridview.MouseUp
        Inicio.MOUSEDERECHO(sender, e, Datos_recibos_datagridview)
    End Sub

End Class