Public Class Retenciones
    Dim proveedores_datatable As New DataTable
    Dim Movimiento_datatable As New DataTable
    Dim Retenciones As New DataTable
    Dim movimiento_retenciones As New DataTable
    Dim Retencionesasociadas As New DataTable
    Dim Iniciando As Boolean = True
    Dim Dataview_noasociados As New DataView
    Dim tipo_impuesto As New DataTable
    Dim Listado_recibo As New DataTable
    Dim listado_recibo_detalle As New DataTable

    Private Sub Liquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargadetablas()
    End Sub

    Private Sub Cargadetablas()
        tipo_impuesto.Columns.Add("Tipo")
        tipo_impuesto.Columns.Add("Descripción")
        tipo_impuesto.Rows.Add("GANANCIAS", " IMPUESTO A LAS GANANCIAS ")
        tipo_impuesto.Rows.Add("SUSS", " SISTEMA UNICO DE SEGURIDAD SOCIAL ")
        tipo_impuesto.Rows.Add("DGR", " RENTAS PROVINCIA DE MISIONES ")
        tipo_impuesto.Rows.Add("IVA", "IMPUESTO AL VALOR AGREGADO")
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
    End Sub

    Private Sub Refresh_proveedores()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_datetimepicker.Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_datetimepicker.Value)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT A.CUIT,PROVEEDOR FROM (
(SELECT * FROM RETENCIONES GROUP BY CUIT)A
LEFT JOIN
(SELECT * FROM PROVEEDORES)B
ON A.CUIT=B.CUIT
)", proveedores_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Proveedores_datagridview.DataSource = proveedores_datatable
    End Sub

    Private Sub refresh_expedientes()
        Select Case Proveedores_datagridview.SelectedRows.Count > 0
            Case True
                Dim Sumatotal As Decimal = 0
                Dim SumaGANANCIAS As Decimal = 0
                Dim SumaIVA As Decimal = 0
                Dim SumaSUSS As Decimal = 0
                Select Case Proveedores_datagridview.SelectedRows.Count > 0
                    Case True
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_datetimepicker.Value)
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_datetimepicker.Value)
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuit", Proveedores_datagridview.SelectedRows(0).Cells.Item("CUIT").Value)
                        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * from retenciones where Cuit=@CUIT AND concat(CUIT,Nro_recibo) in (select concat(cuit,nro_recibo) from tesoreria_recibos where  FECHA_RECIBO BETWEEN @DESDE AND @HASTA)", Movimiento_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                        Movimientos_datagridview.DataSource = Movimiento_datatable
                        'For x = 0 To Movimientos_datagridview.Rows.Count - 1
                        '    Sumatotal = Sumatotal + CType(Movimientos_datagridview.Rows(x).Cells.Item("EGRESOS").Value, Decimal)
                        '    SumaGANANCIAS = SumaGANANCIAS + CType(Movimientos_datagridview.Rows(x).Cells.Item("GANANCIAS").Value, Decimal)
                        '    SumaIVA = SumaIVA + CType(Movimientos_datagridview.Rows(x).Cells.Item("IVA").Value, Decimal)
                        '    SumaSUSS = SumaSUSS + CType(Movimientos_datagridview.Rows(x).Cells.Item("SUSS").Value, Decimal)
                        'Next
                        'Sumatotalbruto.Text = Sumatotal.ToString
                        'Total_ganancias.Text = SumaGANANCIAS.ToString
                        'Total_IVA.Text = SumaIVA.ToString
                        'Total_SUSS.Text = SumaSUSS.ToString
                    Case False
                End Select
            Case False
                Movimientos_datagridview.DataSource = Nothing
        End Select
    End Sub

    Private Sub Liquidacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Desde_datetimepicker.Value = CType("01" & "-" & Date.Now.Month & "-" & Date.Now.Year, Date)
        Hasta_datetimepicker.Value = CType(Date.DaysInMonth(Date.Now.Year, Date.Now.Month) & "-" & Date.Now.Month & "-" & Date.Now.Year, Date)
        Iniciando = False
        visibilidad_retencion(False)
        '    Refresh_proveedores()
        Sql_Cargamovimientos_sinnumero()
        Sql_Cargamovimientos_connumero()
    End Sub

    Private Sub Liquidacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '  proveedores_datatable.Dispose()
        ' proveedores_datatable = Nothing
    End Sub

    Private Sub Proveedores_datagridview_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Proveedores_datagridview.RowPrePaint
        'If (Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("INGRESOS").Value.ToString = Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("EGRESOS").Value.ToString) And (Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("EGRESOS").Value.ToString = Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("RENDIDO").Value.ToString) Then
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.DarkGreen
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Black
        'ElseIf (Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("INGRESOS").Value.ToString = Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("EGRESOS").Value.ToString) Then
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightYellow
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.DarkGoldenrod
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Black
        'ElseIf CType(Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("INGRESOS").Value, Decimal) > CType(Proveedores_datagridview.Rows(e.RowIndex).Cells.Item("EGRESOS").Value, Decimal) Then
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightCoral
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.DarkRed
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Black
        'Else
        '    Proveedores_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        'End If
    End Sub

    Private Sub Proveedores_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Proveedores_datagridview.CellEnter
        refresh_expedientes()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles Calculo_tab.Click
    End Sub

    Private Sub Desde_datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles Desde_datetimepicker.ValueChanged, Hasta_datetimepicker.ValueChanged
        Select Case Iniciando
            Case True
                'la primer carga de la página, no debería provocar un refresh
            Case False
                Refresh_proveedores()
                refresh_expedientes()
        End Select
    End Sub

    'Private Sub Consultaretencionesasociadas()
    '    'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_datetimepicker.Value)
    '    ' SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Fechadia_datetimepicker.Value)
    '    Dim busquedasql As String
    '    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nro_Transaccion", Nrotransferencia_textbox.Text)
    '    'Select Case Nro_Transaccion_textbox.TextLength = 0
    '    '    Case True
    '    '        busquedasql = " Where NOT (Nro_Transaccion=0) "
    '    '    Case Else
    '    '        busquedasql = " Where Nro_Transaccion=@Nro_Transaccion"
    '    'End Select
    '    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * FROM retenciones " & busquedasql, Retencionesasociadas, System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    Movimientoasociado.DataSource = Retencionesasociadas
    '    'Movimientoasociado.Columns("MD5HASH").Visible = False
    '    'Movimientoasociado.Columns("Clave_expediente_detalle").Visible = False
    '    'Movimientoasociado.Columns("CUIT_enterecaudador").Visible = False
    'End Sub
    Private Sub Fechadia_datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles Fechadia_datetimepicker.ValueChanged
        Sql_Cargamovimientos_connumero()
    End Sub

    Private Sub Asociarexpediente_boton_Click(sender As Object, e As EventArgs) Handles Asociartransferencia_boton.Click
        AsociarMovimiento()
    End Sub

    Private Sub AsociarMovimiento()
        Dim movimiento_temp As New Movimiento
        Dim movimiento_recreado As New Movimiento
        If Nrotransferencia_textbox.Value > 0 Then
            For x = 0 To MovimientosNOasociados.SelectedRows.Count - 1
                movimiento_temp = movimiento_temp.cargarmovimiento(CType(MovimientosNOasociados.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value, Long))
                movimiento_recreado = movimiento_temp
                With movimiento_recreado
                    .Desglose_clave()
                    .Clave_expediente_detalle = .NUEVOMOVIMIENTO(.clave_detalle_a__clave_expediente((CType(MovimientosNOasociados.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value, Long)))) 'obtiene el número del nuevo movimiento
                    .Clave_expediente_detalle_principal = movimiento_temp.Clave_expediente_detalle 'clave del movimiento al cual está relacionado
                    .Descripcion_movimiento = "Pago (" & IMPUESTO_tipo_boton.Text & ")" 'Descripción utilizando el nombre principal de la retención
                    .Monto_movimiento = CType(MovimientosNOasociados.SelectedRows(x).Cells.Item("monto_retenido").Value, Decimal) 'Monto retenido como parte del Movimiento
                    .Tipo_Movimiento = IMPUESTO_tipo_boton.Text 'Tipo de Movimiento, utilizando el nombre principal de la retención
                    .Transferencia = CType(Nrotransferencia_textbox.Value, Long) 'Nro de transferencia utilizado
                    .Fecha_movimiento = Fechadia_datetimepicker.Value 'Fecha del movimiento /cheque
                    .Total_factura = MovimientosNOasociados.SelectedRows(x).Cells.Item("Total_Factura").Value
                    .CUIT = MovimientosNOasociados.SelectedRows(x).Cells.Item("Cuit_recaudador").Value
                    .insertar_movimiento(movimiento_recreado, False) 'Completados los datos se procede a la carga
                End With
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_Transaccion", Nrotransferencia_textbox.Value)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fecha", Fechadia_datetimepicker.Value)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nombre_retencion", IMPUESTO_tipo_boton.Text)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Retencion_clave_detalle", movimiento_recreado.Clave_expediente_detalle)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", MovimientosNOasociados.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString)
                'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@retencion_clave_detalle", MovimientosNOasociados.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE Retenciones SET Nro_Transaccion=@Nro_Transaccion, retencion_clave_detalle=@retencion_clave_detalle Where Nombre_retencion=@Nombre_retencion  and clave_expediente_Detalle=@clave_expediente_detalle;"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Next
            Sql_Cargamovimientos_sinnumero()
            Sql_Cargamovimientos_connumero()
        Else
            MessageBox.Show("El número de Transferencia debe ser distinto de 0 (cero), por favor verifique")
        End If
    End Sub

    Private Sub Quitarasociacion_boton_Click(sender As Object, e As EventArgs) Handles Quitartransferencia_boton.Click
        Dim movimiento_temp As New Movimiento
        For x = 0 To Movimientoasociado.SelectedRows.Count - 1
            movimiento_temp.clear()
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_Transaccion", 0)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fecha", Fechadia_datetimepicker.Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nombre_retencion", Movimientoasociado.SelectedRows(x).Cells.Item("mov_tipo").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", Movimientoasociado.SelectedRows(x).Cells.Item("clave_original").Value.ToString)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@retencion_clave_detalle", Movimientoasociado.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString)
            ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@nombre_retencion_detalle", Movimientoasociado.Rows(x).Cells.Item("nombre_retencion_detalle").Value.ToString)
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE Retenciones SET Nro_Transaccion=@Nro_Transaccion Where Nombre_retencion=@Nombre_retencion and retencion_clave_detalle=@retencion_clave_detalle and clave_expediente_Detalle=@clave_expediente_detalle;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            'Borrar Movimiento
            movimiento_temp.Borrarmovimiento(CType(Movimientoasociado.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString, Long))
        Next
        Sql_Cargamovimientos_sinnumero()
        Sql_Cargamovimientos_connumero()
        Movimientoasociado.CurrentCell = Nothing
    End Sub

    Private Sub Nro_Transaccion_textbox_TextChanged(sender As Object, e As EventArgs)
        Inicio.OBJETOCARGANDO(Control_general, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Sql_Cargamovimientos_connumero()
        Inicio.OBJETOFINALIZAR(Control_general, Me)
    End Sub

    Private Sub Busqueda_Transferencias_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_movimientos.TextChanged
        MovimientosNOasociados.DataSource = Buscar_datatable(Busqueda_movimientos, Retenciones)
        columnas_ocultar(MovimientosNOasociados)
    End Sub

    Private Sub Desde_movimientos_ValueChanged(sender As Object, e As EventArgs) Handles Desde_movimientos.ValueChanged
        MovimientosNOasociados.DataSource = Nothing
        Inicio.OBJETOCARGANDO(Control_general, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Sql_Cargamovimientos_sinnumero()
        Inicio.OBJETOFINALIZAR(Control_general, Me)
    End Sub

    Private Sub Hasta_movimientos_ValueChanged(sender As Object, e As EventArgs) Handles Hasta_movimientos.ValueChanged
        MovimientosNOasociados.DataSource = Nothing
        Inicio.OBJETOCARGANDO(Control_general, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Sql_Cargamovimientos_sinnumero()
        Inicio.OBJETOFINALIZAR(Control_general, Me)
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        Inicio.OBJETOCARGANDO(Control_general, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Sql_Cargamovimientos_sinnumero()
        Inicio.OBJETOFINALIZAR(Control_general, Me)
    End Sub

    Private Sub IMPUESTO_tipo_boton_Click(sender As Object, e As EventArgs) Handles IMPUESTO_tipo_boton.Click
        mostrardialogo_tipoimpuesto()
    End Sub

    Private Sub mostrardialogo_tipoimpuesto()
        DialogDialogo_Datagridview.Carga_General(tipo_impuesto, "SELECCIONE IMPUESTO", "Seleccionar", "Cancelar", 10)
        DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            IMPUESTO_tipo_boton.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
        Else
            IMPUESTO_tipo_boton.Text = ""
            MovimientosNOasociados.DataSource = Nothing
        End If
    End Sub

    Private Sub IMPUESTO_tipo_boton_TextChanged(sender As Object, e As EventArgs) Handles IMPUESTO_tipo_boton.TextChanged
        If IMPUESTO_tipo_boton.Text = "" Then
            visibilidad_retencion(False)
        Else
            visibilidad_retencion(True)
            Inicio.OBJETOCARGANDO(Control_general, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
            Sql_Cargamovimientos_sinnumero()
            Inicio.OBJETOFINALIZAR(Control_general, Me)
        End If
    End Sub

    Private Sub visibilidad_retencion(ByVal estado As Boolean)
        Dim lista As New List(Of Control)
        With lista
            .Add(Totalesnoretenidos)
            .Add(Label20)
            .Add(Busqueda_movimientos)
            .Add(Refresh_boton)
            .Add(MovimientosNOasociados)
            .Add(Asociartransferencia_boton)
            .Add(SplitContainer_retenciones.Panel2)
        End With
        For Each item As Control In lista
            item.Visible = estado
        Next
    End Sub

    Private Sub Sql_Cargamovimientos_sinnumero()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_movimientos.Value.Date)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_movimientos.Value.Date)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nombre_retencion", IMPUESTO_tipo_boton.Text)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT
A.clave_expediente_detalle,
b.proveedor,A.fecha_retencion as 'Fecha',
concat(N_pedidofondo,'/',Year_pedidofondo) as 'Pedido fondo',
CONCAT(Substring(c.clave_expediente From 5 for 4),'-',cast(Substring(c.clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(c.clave_expediente From 1 for 4)) as Expediente_N,
CONCAT(AA.Orden_N,'/',AA.Orden_year) as 'OP.',
a.monto_retenido,
a.total_factura,
nombre_retencion_detalle,
nombre_retencion,
mov_tipo,
Cuit_recaudador ,
Retencion_clave_detalle,recibo.nro_recibo,Fecha_recibo
FROM
(select * FROM retenciones
where Nro_Transaccion=0  AND
concat(CUIT,Nro_recibo) in (select concat(cuit,nro_recibo) from tesoreria_recibos where  FECHA_RECIBO BETWEEN @DESDE AND @HASTA)
and Nombre_retencion=@nombre_retencion
and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
)A
left JOIN
(select * from expediente_detalle)AA
ON A.clave_Expediente_Detalle=AA.clave_Expediente_Detalle
left JOIN
(select * from proveedores)B
on a.cuit=b.cuit
left JOIN
(select * from expediente)C
ON SUBSTRING(A.clave_Expediente_Detalle FROM 1 FOR 13)=C.clave_expediente
left JOIN
(select nro_recibo,cuit,Fecha_recibo from Tesoreria_recibos)Recibo
ON concat(A.cuit,A.nro_recibo)=concat(Recibo.cuit,Recibo.nro_recibo)
left JOIN
(select * from pedido_fondos)D
ON C.clave_pedidofondo=D.Clave_pedidofondo
", Retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * FROM Expediente_detalle  where Nro_Transaccion=0 and fecha<=@hasta", Retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
        MovimientosNOasociados.DataSource = Retenciones
        MovimientosNOasociados.CurrentCell = Nothing
        columnas_ocultar(MovimientosNOasociados)
    End Sub

    Private Sub columnas_ocultar(ByVal datagrid_seleccionado As DataGridView)
        If datagrid_seleccionado.Rows.Count > 0 Then
            Select Case datagrid_seleccionado.Name.ToUpper
                Case Is = "MOVIMIENTOSNOASOCIADOS"
                    datagrid_seleccionado.Columns("clave_expediente_detalle").Visible = False
                    datagrid_seleccionado.Columns("Cuit_recaudador").Visible = False
                    datagrid_seleccionado.Columns("nombre_retencion_detalle").Visible = False
                    datagrid_seleccionado.Columns("total_factura").Visible = False
                    datagrid_seleccionado.Columns("Retencion_clave_detalle").Visible = False
                Case Is = "MOVIMIENTOASOCIADO"
                    datagrid_seleccionado.Columns("clave_expediente_detalle").Visible = False
                    datagrid_seleccionado.Columns("clave_expediente_detalle_principal").Visible = False
                    datagrid_seleccionado.Columns("mov_tipo").Visible = False
                    datagrid_seleccionado.Columns("Clave_original").Visible = False
                    datagrid_seleccionado.Columns("Retencion_clave_detalle").Visible = False
            End Select
        End If
    End Sub

    Private Sub Sql_Cargamovimientos_connumero()
        If Not Nrotransferencia_textbox.Value = 0 Then
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nro_transaccion", Nrotransferencia_textbox.Value)
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nombre_retencion", IMPUESTO_tipo_boton.Text)
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * from
(select clave_expediente_detalle,clave_expediente_detalle_principal,CONCAT(Substring(Clave_expediente_detalle From 5 for 4),'-',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(Clave_expediente_detalle From 1 for 4)) as Expediente,
mov_tipo,Detalle,fechadelmovimiento,monto from expediente_detalle
where
nrotransferencia=@nro_transaccion
and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
)A
				LEFT JOIN
				(select clave_expediente_detalle as 'clave_original', Retencion_Clave_detalle from retenciones)B
				on a.clave_expediente_detalle=b.Retencion_Clave_detalle
GROUP BY clave_expediente_detalle", movimiento_retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
            'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * FROM Expediente_detalle  where Nro_Transaccion=0 and fecha<=@hasta", Retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Else
            movimiento_retenciones = Nothing
        End If
        Movimientoasociado.DataSource = movimiento_retenciones
        If Not IsNothing(movimiento_retenciones) Then
            If movimiento_retenciones.Rows.Count > 0 Then
                columnas_ocultar(Movimientoasociado)
            End If
        End If
    End Sub

    Private Sub Nrotransferencia_textbox_ValueChanged(sender As Object, e As EventArgs) Handles Nrotransferencia_textbox.ValueChanged
        Sql_Cargamovimientos_connumero()
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Control_general.SelectedIndexChanged
        Select Case Control_general.SelectedIndex
            Case Is = 0
            Case Is = 1
                Refresh_proveedores()
            Case Is = 2
                Listado_recibos_datagridview_carga()
        End Select
    End Sub

    Private Sub Listado_recibos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Listado_recibos_datagridview.CellEnter
        If sender.selectedrows.count > 0 Then
            Datos_recibos_datagridview_carga()
        End If
    End Sub

    Private Sub Datos_recibos_datagridview_carga()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nro_recibo", Listado_recibos_datagridview.SelectedRows(0).Cells.Item("nro_recibo").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Listado_recibos_datagridview.SelectedRows(0).Cells.Item("CUIT").Value)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SElect Expediente_N,Detalle,Monto,Fechadelmovimiento from expediente_detalle
where Cuit=@cuit and Nro_recibo=@Nro_recibo", listado_recibo_detalle, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * FROM Expediente_detalle  where Nro_Transaccion=0 and fecha<=@hasta", Retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_recibos_datagridview.DataSource = listado_recibo_detalle
        'MovimientosNOasociados.Columns("clave_expediente_detalle").Visible = False
        'MovimientosNOasociados.Columns("Cuit_recaudador").Visible = False
        'MovimientosNOasociados.Columns("nombre_retencion_detalle").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
    End Sub

    Private Sub Listado_recibos_datagridview_carga()
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select a.nro_recibo,total,b.proveedor,a.cuit from
(select Nro_recibo,CUIT ,total from tesoreria_recibos)A
left join
(select * from proveedores)B
on a.CUIT=B.CUIT
", Listado_recibo, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT * FROM Expediente_detalle  where Nro_Transaccion=0 and fecha<=@hasta", Retenciones, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Listado_recibos_datagridview.DataSource = Listado_recibo
        'MovimientosNOasociados.Columns("clave_expediente_detalle").Visible = False
        'MovimientosNOasociados.Columns("Cuit_recaudador").Visible = False
        'MovimientosNOasociados.Columns("nombre_retencion_detalle").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
        'MovimientosNOasociados.Columns("total_factura").Visible = False
    End Sub

    Private Sub Buscar_recibos_TextChanged(sender As Object, e As EventArgs) Handles Buscar_recibos.TextChanged
        Buscar_datagrid(sender, Listado_recibo, Listado_recibos_datagridview)
    End Sub

    Private Sub Buttonafiptest_Click(sender As Object, e As EventArgs) Handles Buttonafiptest.Click
        Dim xc As New AFIP_lote
        xc.Carga_intermedia(Desde_movimientos.Value.Date, Hasta_movimientos.Value.Date, Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
    End Sub

    Private Sub MovimientosNOasociados_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles MovimientosNOasociados.CellEnter
        calculo_totales(sender, Totalesnoretenidos)
    End Sub

    Private Sub calculo_totales(ByVal datagridseleccionado As DataGridView, ByRef totales As DataGridView)
        Dim Totales_seleccionado_datatable As New DataTable
        Dim total_apagar As Decimal = 0
        Dim totalunificado As Decimal = 0
        'For x = 0 To datagridseleccionado.SelectedRows.Count - 1
        '    Select Case datagridseleccionado.Name
        '        Case Is = "MovimientosNOasociados"
        '            total_apagar += datagridseleccionado.SelectedRows(x).Cells.Item("Monto_retenido").Value
        '        Case Is = ""
        '            total_apagar += datagridseleccionado.SelectedRows(x).Cells.Item("monto").Value
        '    End Select
        'Next
        For x = 0 To datagridseleccionado.Rows.Count - 1
            Select Case datagridseleccionado.Rows(x).Selected
                Case True
                    Select Case datagridseleccionado.Name
                        Case Is = "MovimientosNOasociados"
                            total_apagar += datagridseleccionado.Rows(x).Cells.Item("Monto_retenido").Value
                            totalunificado += datagridseleccionado.Rows(x).Cells.Item("Monto_retenido").Value
                        Case Else
                            total_apagar += datagridseleccionado.Rows(x).Cells.Item("monto").Value
                            totalunificado += datagridseleccionado.Rows(x).Cells.Item("monto").Value
                    End Select
                Case False
                    Select Case datagridseleccionado.Name
                        Case Is = "MovimientosNOasociados"
                            totalunificado += datagridseleccionado.Rows(x).Cells.Item("Monto_retenido").Value
                        Case Else
                            totalunificado += datagridseleccionado.Rows(x).Cells.Item("monto").Value
                    End Select
            End Select
        Next
        With Totales_seleccionado_datatable
            .Columns.Add("TOTAL")
            .Columns.Add("MONTO", GetType(System.Decimal))
            If totalunificado > 0 Then
                .Rows.Add("Total sin discriminar", totalunificado)
            End If
            If total_apagar > 0 Then
                .Rows.Add("TOTAL Seleccionado", total_apagar)
            End If
        End With
        totales.DataSource = Totales_seleccionado_datatable
        totales.Columns("MONTO").DefaultCellStyle.Format = "C"
    End Sub

    Private Sub Movimientoasociado_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Movimientoasociado.CellEnter
        calculo_totales(sender, Totalesretenidos)
    End Sub

    Private Sub Busqueda_movimientos_asociados_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_movimientos_asociados.TextChanged
        Movimientoasociado.DataSource = Buscar_datatable(Busqueda_movimientos_asociados, movimiento_retenciones)
        columnas_ocultar(Movimientoasociado)
    End Sub

    Private Sub MovimientosNOasociados_MouseUp(sender As Object, e As MouseEventArgs) Handles MovimientosNOasociados.MouseUp, Movimientoasociado.MouseUp, Totalesnoretenidos.MouseUp, Totalesretenidos.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub Boton_excel_Click(sender As Object, e As EventArgs) Handles Boton_excel.Click
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_movimientos.Value.Date)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_movimientos.Value.Date)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@nombre_retencion", IMPUESTO_tipo_boton.Text)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        Dim excel_datatable As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("start_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Desde_movimientos.Value.Date
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("last_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Hasta_movimientos.Value.Date
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "Tesoreria_retenciones_cheques_excel", excel_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        DialogDialogo_Datagridview.Carga_General(excel_datatable, "Retenciones", "Exportar a Excel", "Cancelar", 10)
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Exportaraexceltest(DialogDialogo_Datagridview.Datosdialogo_datagridview)
            ' Cuentabancaria = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value
        Else
        End If
    End Sub

    Private Sub Movimientoasociado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Movimientoasociado.DataError
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        Inicio.OBJETOCARGANDO(Control_general, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Sql_Cargamovimientos_sinnumero()
        Inicio.OBJETOFINALIZAR(Control_general, Me)
        Movimientoasociado.DataSource = Nothing
        Nrotransferencia_textbox.Value = 0
    End Sub

    Private Sub Modificar_numero_boton_Click(sender As Object, e As EventArgs) Handles Modificar_numero_boton.Click
        Dialogo_Solicitarnumero.Numerodetransaccionnuevo_numeric.Value = Nrotransferencia_textbox.Value
        If (Dialogo_Solicitarnumero.ShowDialog() = DialogResult.OK) Then
            If Not (Nrotransferencia_textbox.Value = Dialogo_Solicitarnumero.Numeroretorno) Then
                Dim dr As DialogResult = MessageBox.Show("Desea modificar el número de transferencia/transacción" &
                                                         vbCrLf & " DE:" & Nrotransferencia_textbox.Value &
                                                         vbCrLf & " A:" & Dialogo_Solicitarnumero.Numeroretorno, "Modificar movimiento", MessageBoxButtons.OKCancel)
                If (System.Windows.Forms.DialogResult.OK = dr) Then
                    Dim movimiento_temp As New Movimiento
                    For x = 0 To Movimientoasociado.SelectedRows.Count - 1
                        movimiento_temp.clear()
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Clear()
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nro_Transaccion", Dialogo_Solicitarnumero.Numeroretorno)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fecha", Fechadia_datetimepicker.Value)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nombre_retencion", Movimientoasociado.SelectedRows(x).Cells.Item("mov_tipo").Value)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", Movimientoasociado.SelectedRows(x).Cells.Item("clave_original").Value.ToString)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@retencion_clave_detalle", Movimientoasociado.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString)
                        ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@nombre_retencion_detalle", Movimientoasociado.Rows(x).Cells.Item("nombre_retencion_detalle").Value.ToString)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE Retenciones SET Nro_Transaccion=@Nro_Transaccion Where Nombre_retencion=@Nombre_retencion and retencion_clave_detalle=@retencion_clave_detalle and clave_expediente_Detalle=@clave_expediente_detalle;"
                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                        'Borrar Movimiento
                        movimiento_temp = movimiento_temp.cargarmovimiento(CType(Movimientoasociado.SelectedRows(x).Cells.Item("clave_expediente_detalle").Value.ToString, Long))
                        movimiento_temp.Transferencia = Dialogo_Solicitarnumero.Numeroretorno
                        movimiento_temp.INSERTARMOVIMIENTO(movimiento_temp)
                    Next
                    Sql_Cargamovimientos_sinnumero()
                    Sql_Cargamovimientos_connumero()
                    Movimientoasociado.CurrentCell = Nothing
                End If
            End If
        Else
            MessageBox.Show("Modificación Cancelada")
        End If
    End Sub

End Class