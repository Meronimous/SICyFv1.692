Public Class Tesoreria_Conciliacion2
    Dim Datatable_General As New DataTable
    Dim Datatable_Detalles As New DataTable
    Dim Datagridseleccionado As New Flicker_Datagridview
    Dim Banco_libro As New DataTable

    'Private Sub Mouse_datagridview_MouseWheel(ByVal sender As Flicker_Datagridview, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Datagrid_General.MouseWheel, Datagrid_Detalles.MouseWheel
    '    DataGridView_MouseWheel(CType(sender, DataGridView), e)
    'End Sub
    'Private Sub MOUSEDERECHO(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object)
    '    Datagridseleccionado = Nothing
    '    If MOUSE.Button <> MouseButtons.Right Then Return
    '    Datagridseleccionado = datagridgestor
    '    Dim cms = New ContextMenuStrip
    '    Dim item1 = cms.Items.Add("Copiar")
    '    item1.Tag = 0
    '    ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
    '    AddHandler item1.Click, AddressOf Menucontextual_Conciliacion
    '    Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
    '    item2.Tag = 1
    '    AddHandler item2.Click, AddressOf Menucontextual_Conciliacion
    '    Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
    '    item3.Tag = 2
    '    AddHandler item3.Click, AddressOf Menucontextual_Conciliacion
    '    Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
    '    item4.Tag = 3
    '    AddHandler item4.Click, AddressOf Menucontextual_Conciliacion
    '    If Datagridseleccionado.SelectedCells.Count > 0 Then
    '        Dim item5 = cms.Items.Add("Nuevo Expediente")
    '        item5.Tag = 4
    '        AddHandler item5.Click, AddressOf Menucontextual_Conciliacion
    '        Dim item6 = cms.Items.Add("Modificar Expediente seleccionado")
    '        item6.Tag = 5
    '        AddHandler item6.Click, AddressOf Menucontextual_Conciliacion
    '    End If
    '    cms.Show(CONTROL, MOUSE.Location)
    'End Sub
    Private Sub Menucontextual_Conciliacion(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 999
                SeleccionMouse2(sender, e, Descripcion_General_label)
            Case Is = 0
                Clipboard.SetDataObject(Datagridseleccionado.GetClipboardContent())
                Dim objData As DataObject = Datagridseleccionado.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(Datagridseleccionado)
                'Select Case Datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SICYF.FLICKER_DATAGRIDVIEW"
                '        Exportaraexceltest(Datagridseleccionado)
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(Datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        '    Exportaraexceltestkrypton(Datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(Datagridseleccionado.GetType.ToString)
                'End Select
            Case Is = 2
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
            Case Is = 3
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 30
                If Datagridseleccionado.Columns.Contains("Nrotransferencia") Then
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("Nrotransferencia").Value)
                Else
                    'nro_transaccion
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Math.Abs(CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("nro_transaccion").Value, Decimal)))
                End If
                ConsultaSql_dialogo("Select Detalle,Monto,Concat(cod_orden,CFdo,Codinp) as 'MFyV',DATE_FORMAT(Fechadelmovimiento,'%d/%m/%Y') as 'Fecha',Tipoorden as 'tipo de orden',concat (Orden_N,'/',Orden_year) as 'Nº Orden',DATE_FORMAT(Creado_o_modificado,'%d/%m/%Y') as 'Actualizado el'
From Expediente_detalle where NroTransferencia=@Nrotransferencia order by FECHADELMOVIMIENTO desc")
            Case Is = 40
                If Datagridseleccionado.Columns.Contains("Expediente_N") Then
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle_inicio", CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("clave_expediente_detalle").Value.ToString.Substring(0, 13) & "0000", Long))
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle_final", CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("clave_expediente_detalle").Value.ToString.Substring(0, 13) & "9999", Long))
                Else
                    'nro_transaccion
                    '  SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Expediente_N", Math.Abs(CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("nro_transaccion").Value, Decimal)))
                End If
                ConsultaSql_dialogo("Select Detalle,Monto,Concat(cod_orden,CFdo,Codinp) as 'MFyV',DATE_FORMAT(Fechadelmovimiento,'%d/%m/%Y') as 'Fecha',Tipoorden as 'tipo de orden',concat (Orden_N,'/',Orden_year) as 'Nº Orden',DATE_FORMAT(Creado_o_modificado,'%d/%m/%Y') as 'Actualizado el'
From Expediente_detalle where clave_expediente_detalle between @clave_expediente_detalle_inicio and @clave_expediente_detalle_final order by FECHADELMOVIMIENTO desc")
                'If Datagridseleccionado.Name.ToString = "Datagrid_General" Then
                '    Buscador_general.Text = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("EXPEDIENTE_N").Value
                'Else
                '    Buscador_detallado.Text = CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("EXPEDIENTE_N").Value, Date).ToShortDateString
                'End If
            Case Is = 50
                'If Datagridseleccionado.Name.ToString = "Datagrid_General" Then
                '    Buscador_general.Text = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("DETALLE").Value.ToString
                'End If
                Dim Movimientos As New Movimiento With {
                    .Clave_expediente_detalle = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("Clave_expediente_detalle").Value.ToString,
                        .fecha = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("FECHA").Value,
                    .monto = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("Monto").Value,
                    .Transferencia = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("Nrotransferencia").Value
                }
                Dialogo_Movimientoscambio.Modificarmovimiento(Movimientos)
                Dialogo_Movimientoscambio.Location = New Point(MousePosition.X - (Dialogo_Movimientoscambio.Width / 2), MousePosition.Y - (Dialogo_Movimientoscambio.Height / 2))
                If Dialogo_Movimientoscambio.ShowDialog() = DialogResult.OK Then
                    ' myStream = Message.OpenFile()
                    If Datagridseleccionado.Name.ToString = "Datagrid_General" Then
                        'Buscador_general.Text = CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("FECHA").Value, Date).ToShortDateString
                        Refresh_libro(Datatable_General, Datagrid_General, Descripcion_General_label, Imagen_General)
                        'Buscador_general.Text = CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("FECHA").Value, Date).ToShortDateString
                    Else
                        Refresh_libro(Datatable_Detalles, Datagrid_Detalles, Descripcion_Detallado_label, Imagen_detallado)
                    End If
                End If
                Dialogo_Movimientoscambio.Dispose()
            Case Is = 60
                If Datagridseleccionado.Name.ToString = "Datagrid_General" Then
                    Buscador_general.Text = CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("FECHA").Value, Date).ToShortDateString
                End If
            Case Is = 70
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("CUIT").Value)
                ConsultaSql_dialogo("Select Detalle,Monto,Concat(cod_orden,CFdo,Codinp) as 'MFyV',DATE_FORMAT(Fechadelmovimiento,'%d/%m/%Y') as 'Fecha',Tipoorden as 'tipo de orden',concat (Orden_N,'/',Orden_year) as 'Nº Orden',DATE_FORMAT(Creado_o_modificado,'%d/%m/%Y') as 'Actualizado el'
From Expediente_detalle where CUIT=@CUIT order by Fechadelmovimiento desc")
            Case Is = 80
                If Datagridseleccionado.Name.ToString = "Datagrid_General" Then
                    Buscador_general.Text = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("PEDIDO DE FONDO").Value.ToString
                End If
            Case Is = 90
                If Datagridseleccionado.Name.ToString = "Datagrid_General" Then
                    Buscador_general.Text = Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("IMPORTE").Value.ToString
                End If
            Case Is = 99
                If Datagridseleccionado.Columns.Contains("Monto") Then
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Monto", Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("MONTO").Value)
                Else
                    'nro_transaccion
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Monto", Math.Abs(CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("importe mov.").Value, Decimal)))
                End If
                ConsultaSql_dialogo("Select Fecha,EXPEDIENTE_n AS 'Expediente',Detalle,
CASE when not(ingresos=0) and not(codinp=2) then Ingresos else
CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
Concat(cod_orden,Cfdo,CodInp) as 'MFyV',
PedidoFondo_N
From MFyV where (ingresos=@monto or Egresos=@monto) order by Fecha desc")
            Case Is = 100
                If Datagridseleccionado.Columns.Contains("Nrotransferencia") Then
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("Nrotransferencia").Value)
                Else
                    'nro_transaccion
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Math.Abs(CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("nro_transaccion").Value, Decimal)))
                End If
                ConsultaSql_dialogo("Select Fecha,Detalle,
CASE when not(ingresos=0) and not(codinp=2) then Ingresos else
CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
Concat(cod_orden,Cfdo,CodInp) as 'MFyV',
PedidoFondo_N
From MFyV where NroTransferencia=@Nrotransferencia order by Fecha desc")
            Case Is = 101
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@fecha ", String.Format("{0:yyyy-MM-dd}", CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("fecha").Value, Date)))
                ConsultaSql_dialogo("Select Fecha,Detalle,CASE when not(ingresos=0) and not(codinp=2) then Ingresos else CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
Concat(cod_orden,Cfdo,CodInp) as 'MFyV', PedidoFondo_N
From MFyV where Fecha between @fecha and @fecha order by Fecha desc;")
            Case Is = 102
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("Clave_expediente_detalle").Value.ToString.Substring(0, 13))
                ConsultaSql_dialogo("Select Fecha,Detalle,
CASE when not(ingresos=0) and not(codinp=2) then Ingresos else
    CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
    Concat(cod_orden,Cfdo,CodInp) as 'MFyV',
    PedidoFondo_N
    From MFyV where Clave_expediente=@Clave_expediente order by Fecha desc")
            Case Is = 103
        End Select
        '-- etc
    End Sub

    Private Sub ConsultaSql_dialogo(ByVal consultasql As String)
        Dim tabla_datos As New DataTable
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, tabla_datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Dialogo_datos.mostrardatatable(tabla_datos)
    End Sub

    Private Sub Datagrid_Selector_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datagrid_Selector.CellEnter
        If Datagrid_Selector.SelectedCells.Count > 0 Then
            Splitcontainer_Datos.Visible = True
            'Borramos los buscadores para evitar confusiones
            'Buscador_general.Text = ""
            'Buscador_detallado.Text = ""
            'Liberamos los datasource para liberar memoria
            Datagrid_General.DataSource = Nothing
            Datagrid_Detalles.DataSource = Nothing
            'Quitamos el tilde si estuviese colocado a mostrar solo lo conciliado
            Mostrarsolonoconciliado_checkbox.Checked = False
            'hacemos dos nuevas datatables a las variables generales.
            Datatable_General = New DataTable
            Datatable_Detalles = New DataTable
            Select Case Datagrid_Selector.SelectedRows(0).Cells.Item(0).Value.ToString.ToUpper
                Case Is = "BANCO"
                    Refreshbanco(Datatable_General, Datagrid_General, Descripcion_General_label, Imagen_General)
                '    refresh_libro(Datatable_Detalles, Datagrid_Detalles, Descripcion_Detallado_label, Imagen_detallado)
                Case Is = "LIBRO"
                    Refresh_libro(Datatable_General, Datagrid_General, Descripcion_General_label, Imagen_General)
                    '    refreshbanco(Datatable_Detalles, Datagrid_Detalles, Descripcion_Detallado_label, Imagen_detallado)
            End Select
        Else
            Splitcontainer_Datos.Visible = False
        End If
    End Sub

    Private Sub Detalles_esteticos_a_cero()
        'Cuadro de datos generales
        Descripcion_General_label.Text = ""
        Imagen_General.Image = Nothing
        'Cuadro de datos detallados
        Descripcion_Detallado_label.Text = ""
        Imagen_detallado.Image = Nothing
    End Sub

    Private Sub Refreshtotalesbancolibro()
        COMMANDSQL.Parameters.AddWithValue("@Cuenta", Label_Cuentabancaria.Text)
        COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        Inicio.SQLPARAMETROS(Organismotabla, "
SELECT 'BANCO' AS 'ORIGEN',
Count(cuenta) as 'Cant. de movimientos',
Format(Sum(IF (importe >0,(importe),0)),2,'es_AR') AS 'Ingresos',
Format(ABS(Sum(IF (importe <0,(importe),0))),2,'es_AR') AS 'Egresos',
Format(sum(importe),2,'es_AR') AS 'Saldo'
FROM reportebanco
WHERE (FECHA BETWEEN @desde AND @hasta) AND (Cuenta=@cuenta)
union ALL
SELECT 'LIBRO' AS 'ORIGEN',
 CASE WHEN INGRESO <> 0 THEN COUNT(INGRESO) ELSE CASE WHEN EGRESOS <> 0 THEN COUNT(EGRESOS) ELSE 	0 END END AS 'Cant. de movimientos',
 format(SUM(INGRESO),2,'es_AR') AS INGRESO, Format(SUM(EGRESOS),2,'es_AR') AS EGRESOS,format(SUM(INGRESO-EGRESOS),2,'es_AR') AS 'Saldo' FROM
	(SELECT (MONTO) AS 'INGRESO','0' AS EGRESOS	FROM expediente_detalle	WHERE	(	CodInp = 3	OR CodInp = 4	OR CodInp = 9)
		AND Fechadelmovimiento BETWEEN @desde	AND @hasta AND
SUBSTRING(Clave_expediente_detalle	FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
(SELECT Clave_expediente	FROM	expediente WHERE clave_pedidofondo IN (SELECT	clave_pedidofondo	FROM	pedido_fondos	WHERE	Cuenta_pedidofondo = @cuenta))
		UNION ALL
			SELECT '0' AS 'INGRESO',(MONTO) AS EGRESOS FROM	expediente_detalle WHERE (CodInp = 1)	AND Fechadelmovimiento BETWEEN @desde	AND @hasta
			AND SUBSTRING(Clave_expediente_detalle FROM	1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT	Clave_expediente	FROM expediente	WHERE clave_pedidofondo
 IN (SELECT	clave_pedidofondo	FROM pedido_fondos WHERE Cuenta_pedidofondo = @cuenta))) A
", Banco_libro, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_Selector.DataSource = Banco_libro
        Datagrid_Selector.CurrentCell = Nothing
    End Sub

    Private Sub Refreshbanco(ByRef Banco_Datatable As DataTable, ByRef Datagrid_seleccionado As DataGridView, ByRef label_Nombre As Label, ByRef Imagen_seleccionada As PictureBox)
        'Buscador_general.Text = ""
        'Buscador_detallado.Text = ""
        COMMANDSQL.Parameters.AddWithValue("@Cuenta", Label_Cuentabancaria.Text)
        If Datagrid_seleccionado.Name = "Datagrid_Detalles" Then
            If Datagrid_General.Rows(Datagrid_General.SelectedCells(0).RowIndex).Cells.Item("MD5_relacionado").Value.ToString.Length > 0 Then
                COMMANDSQL.Parameters.AddWithValue("@MD5_Banco", Datagrid_General.Rows(Datagrid_General.SelectedCells(0).RowIndex).Cells.Item("MD5_relacionado").Value.ToString())
                COMMANDSQL.Parameters.AddWithValue("@desde", CType(Date.Now.Year & "-" & "01" & "-" & "01", Date))
                COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Date.Now.Year & "-" & "12" & "-" & "31", Date))
            Else
                COMMANDSQL.Parameters.AddWithValue("@MD5_Banco", "  ")
                COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
                COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
            End If
        Else
            COMMANDSQL.Parameters.AddWithValue("@MD5_Banco", "")
            COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
            COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        End If
        Inicio.SQLPARAMETROS(Organismotabla, "Select
MD5HASH,Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,importe As 'Importe mov.',Format(Saldo,2, 'es_AR') as 'Saldo',
format(Libro_Asociado,2, 'es_AR') as Asociado_con_Libro,CASE WHEN ABS(Libro_Asociado) >0 THEN Libro_Asociado ELSE 0 END as 'Libro_Asociado',importe,
(CASE WHEN LIBRO_ASOCIADO-ABS(IMPORTE)=0 THEN 'OK' ELSE
    CASE WHEN ISNULL(LIBRO_ASOCIADO-ABS(IMPORTE))
        THEN 'SIN ASOCIAR' ELSE FORMAT(LIBRO_ASOCIADO-ABS(IMPORTE),2,'es_AR') END
END) as 'Diferencia'
FROM
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH'
,Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,SUM(IMPORTE) AS 'IMPORTE',SALDO as 'Saldo'
FROM reportebanco where (CASE WHEN CHAR_LENGTH(@MD5_BANCO)>0 THEN MD5HASH=@MD5_BANCO ELSE NOT ISNULL(MD5HASH) END) AND (fecha between @DESDE and @HASTA) and Cuenta=@cuenta
 group by nro_transaccion
)A
Left Join
(SELECT SUM(MONTO) AS 'Libro_Asociado',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)B
On A.MD5HASH=B.MD5_RELACIONADO
ORDER BY FECHA DESC, NRO_TRANSACCION DESC", Banco_Datatable, Reflection.MethodBase.GetCurrentMethod.Name)
        '((not (Libro_Asociado=ABS(IMPORTE))) OR ISNULL(Libro_Asociado)) AND
        Datagrid_seleccionado.DataSource = Banco_Datatable
        Datagrid_seleccionado.Columns("MD5HASH").Visible = False
        Datagrid_seleccionado.Columns("Cuenta").Visible = False
        Datagrid_seleccionado.Columns("Saldo").Visible = False
        Datagrid_seleccionado.Columns("importe").Visible = False
        '     Datagrid_seleccionado.Columns("Clave_expediente_detalle").Visible = False
        Datagrid_seleccionado.Columns("Libro_Asociado").Visible = False
        'Verificar utilidad
        'Datagrid_seleccionado.Columns("Orden").Visible = False
        'Datagrid_seleccionado.Columns("Monto").Visible = False
        Datagrid_seleccionado.Columns("FECHA").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datagrid_seleccionado.Columns("Nro_Transaccion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datagrid_seleccionado.Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datagrid_seleccionado.Columns("CATEGORIA").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Datagrid_seleccionado.Columns("Importe mov.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datagrid_seleccionado.Columns("Asociado_con_Libro").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '  Datagrid_seleccionado.Columns("Fechadelmovimiento").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Datagrid_seleccionado.Columns("Importe mov.").DefaultCellStyle.Format = "c"
        label_Nombre.Text = "BANCO"
        Imagen_seleccionada.Image = My.Resources.Banco_Macro
        Datagrid_seleccionado.CurrentCell = Nothing
    End Sub

    Private Sub Refresh_libro(ByRef Libro_datatable As DataTable, ByRef Datagrid_seleccionado As DataGridView, ByRef label_Nombre As Label, ByRef Imagen_seleccionada As PictureBox)
        'Buscador_general.Text = ""
        'Buscador_detallado.Text = ""
        ' AL REALIZAR UNA BUSQUEDA EN LIBRO Y LUEGO SELECCIONAR BANCO PRODUCE UN ERROR DE NO RECONOCER EL NOMBRE DE COLUMNA MD5HASH
        If Descripcion_General_label.Text.ToUpper = "BANCO" Then
            If Datagrid_General.SelectedCells.Count > 0 Then
                Consultar(Libro_datatable, Datagrid_seleccionado, Datagrid_General.Rows(Datagrid_General.SelectedCells(0).RowIndex).Cells.Item("MD5HASH").Value.ToString)
            Else
                Consultar(Libro_datatable, Datagrid_seleccionado, "")
            End If
        Else
            Consultar(Libro_datatable, Datagrid_seleccionado, "")
        End If
        'hacer invisible estas columnas
        Datagrid_seleccionado.Columns("Clave_expediente_detalle").Visible = False
        Datagrid_seleccionado.Columns("MD5_relacionado").Visible = False
        'tipo de ajuste que recibiran las columnas
        'Datagrid_seleccionado.Columns("MD5_relacionado").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid_seleccionado.Columns("Expediente_N").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid_seleccionado.Columns("Detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid_seleccionado.Columns("Monto").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid_seleccionado.Columns("Fechadelmovimiento").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'Datagrid_seleccionado.Columns("CUIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid_seleccionado.Columns("Nrotransferencia").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'Datagrid_seleccionado.Columns("MFyV").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Datagrid_seleccionado.CurrentCell = Nothing
        label_Nombre.Text = "LIBRO"
        Imagen_seleccionada.Image = My.Resources.Logo
    End Sub

    Private Sub Consultar(ByRef Tabladedatos As DataTable, ByRef Datagrid_seleccionado As DataGridView, ByVal MD5ss As String)
        COMMANDSQL.Parameters.AddWithValue("@Cuenta", Label_Cuentabancaria.Text) 'Cuenta Bancaria seleccionada
        COMMANDSQL.Parameters.AddWithValue("@MD5_Banco", MD5ss) 'se especifica para los casos en que debe mostrarse unicamente el valor relacionado con banco, en caso de ser así los valores @desde y @hasta no se utilizan
        COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        '        Dim Consulta As String = "SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento as 'Fecha',CUIT,Nrotransferencia,`MFyV`,Clave_expediente_detalle,`Pedido de Fondo`,A.MD5_relacionado,
        'CASE WHEN ISNULL(Libro_Asociado) THEN 0 ELSE Libro_Asociado END AS 'Libro_Asociado',
        'CASE WHEN ISNULL(IMPORTE) THEN 0 ELSE IMPORTE END AS 'IMPORTE',
        '(CASE WHEN LIBRO_ASOCIADO-ABS(IMPORTE)=0 THEN 'OK' ELSE
        '    CASE WHEN ISNULL(LIBRO_ASOCIADO-ABS(IMPORTE))
        '        THEN 'SIN ASOCIAR' ELSE FORMAT(LIBRO_ASOCIADO-ABS(IMPORTE),2,'es_AR') END
        'END) as 'Diferencia'
        'FROM
        '        (Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV',MD5_relacionado
        '                                    from Expediente_detalle  WHERE "
        '        If MD5ss = "" Then 'en caso de que no exista una relación actual con el hash de banco
        '            Consulta &= " ((FEchadelmovimiento BETWEEN @desde AND @hasta) OR (FEchadelmovimiento=@desde) OR (FEchadelmovimiento=@hasta)) "
        '        Else ' en caso de que si exista una relación la consulta de libro será ligeramente diferente agregando @md5_banco
        '            Consulta &= " MD5_relacionado=@MD5_Banco"
        '        End If
        '        Consulta &= "  AND NOT (CODINP='2')
        ')A  LEFT JOIN
        '(SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,
        'Clave_expediente FROM expediente)B ON B.Clave_expediente=SUBSTRING( A.Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
        'Left Join
        '(SELECT SUM(MONTO) AS 'Libro_Asociado',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)D
        'On A.MD5_relacionado=D.MD5_relacionado
        'Left Join
        '(SELECT SUM(IMPORTE) AS 'Importe',MD5HASH FROM reportebanco GROUP BY MD5HASH)E
        'On A.MD5_relacionado=E.MD5HASH
        '                                    order by Fechadelmovimiento desc,Nrotransferencia asc"
        Dim consulta As String = "
SELECT Expediente_N,
Detalle,
Monto,
CASE WHEN ISNULL(`BANCO IMPORTE`) THEN 0 ELSE `BANCO IMPORTE` END AS IMPORTE,
CASE WHEN ISNULL(Libro_Asociado) THEN 0 ELSE Libro_Asociado END AS 'Libro_Asociado',
(CASE WHEN LIBRO_ASOCIADO-ABS(`BANCO IMPORTE`)=0 THEN 'OK' ELSE
    CASE WHEN ISNULL(LIBRO_ASOCIADO-ABS(`BANCO IMPORTE`))
        THEN 'SIN ASOCIAR' ELSE FORMAT(LIBRO_ASOCIADO-ABS(`BANCO IMPORTE`),2,'es_AR') END
END) as 'Diferencia',
Fechadelmovimiento as 'Fecha',
CUIT,
Nrotransferencia,
`MFyV`,
Clave_expediente_detalle,
`Pedido de Fondo`,MOV_TIPO,
A.MD5_relacionado
FROM
/*
BUSCA TODOS LOS MOVIMIENTOS SIN CONTAR LOS QUE ESTAN COMO IPS
*/
(Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV',MD5_relacionado,MOV_TIPO
from Expediente_detalle  WHERE
((FEchadelmovimiento BETWEEN @desde AND @hasta) OR (FEchadelmovimiento=@desde) OR (FEchadelmovimiento=@hasta)) AND NOT (CODINP='2') AND NOT MOV_TIPO='IPS'
and SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
(SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM
pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
(SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)
)A  LEFT JOIN
/*
DATOS DE PEDIDOS DE FONDO
*/
(SELECT
CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,
Clave_expediente FROM expediente)B ON B.Clave_expediente=SUBSTRING( A.Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
Left Join
/*
DETALLE DE LOS MOVIMIENTOS ASOCIADOS AL REGISTRO BANCARIO
*/
(SELECT SUM(MONTO) AS 'Libro_Asociado',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)D
On A.MD5_relacionado=D.MD5_relacionado
Left Join
/*
DETALLE DE LOS MOVIMIENTOS BANCARIOS.
*/
(SELECT SUM(IMPORTE) AS 'BANCO IMPORTE',
CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH' FROM REPortebanco group by nro_transaccion)E
On A.MD5_relacionado=E.MD5HASH
                                    order by Fechadelmovimiento desc,Nrotransferencia asc"
        Inicio.SQLPARAMETROS(Organismotabla, consulta, Tabladedatos, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_seleccionado.DataSource = Tabladedatos
        Datagrid_seleccionado.Columns("Monto").DefaultCellStyle.Format = "c"
        Datagrid_seleccionado.Columns("Libro_Asociado").DefaultCellStyle.Format = "c"
        Datagrid_seleccionado.Columns("IMPORTE").DefaultCellStyle.Format = "c"
        Datagrid_seleccionado.Columns("Nrotransferencia").DefaultCellStyle.Format = "N0"
        Datagrid_seleccionado.CurrentCell = Nothing
    End Sub

    Private Sub Seleccionarcuenta_boton_Click(sender As Object, e As EventArgs) Handles Seleccionarcuenta_boton.Click
        DialogDialogo_Datagridview.Carga_General(Cuentas, "Seleccione la cuenta bancaria a examinar", "Seleccionar Cuenta", "Cancelar")
        '  Dialogo_listbox.Cargalistboxgeneral(listadecuentasbancarias, "Seleccione la cuenta a ser asignada", "Asignar Cuenta Especial", "Borrar asignación")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            'Número de Cuenta Bancaria
            Label_Cuentabancaria.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
            'Nombre Asignado a la Cuenta Bancaria
            Label_detalleCuentabancaria.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value.ToString
            Refreshtotalesbancolibro()
        Else
            Label_Cuentabancaria.Text = ""
            Label_detalleCuentabancaria.Text = ""
        End If
    End Sub

    Private Sub Desde_monthcalendarA_ValueChanged(sender As Object, e As EventArgs) Handles Desde_monthcalendarA.ValueChanged
        Select Case Label_Cuentabancaria.Text.Length > 10
            Case True
                Refreshtotalesbancolibro()
            Case False
        End Select
    End Sub

    Private Sub Hasta_monthcalendarA_ValueChanged(sender As Object, e As EventArgs) Handles Hasta_monthcalendarA.ValueChanged
        Select Case Label_Cuentabancaria.Text.Length > 10
            Case True
                Refreshtotalesbancolibro()
            Case False
        End Select
    End Sub

    Private Sub Buscador_general_TextChanged(sender As Object, e As EventArgs) Handles Buscador_general.TextChanged
        Buscar_datagrid_TIMER(sender, Datatable_General, Datagrid_General)
    End Sub

    Private Sub Buscador_detallado_TextChanged(sender As Object, e As EventArgs) Handles Buscador_detallado.TextChanged
        Buscar_datagrid_TIMER(sender, Datatable_Detalles, Datagrid_Detalles)
    End Sub

    Private Sub Datagrid_Detalles_MouseUp(sender As Object, e As MouseEventArgs) Handles Datagrid_Detalles.MouseUp
        If e.Button = MouseButtons.Right Then
            SeleccionMouse(sender, e, Datagrid_Detalles, Descripcion_Detallado_label)
        End If
    End Sub

    Private Sub Datagrid_General_MouseUp(sender As Object, e As MouseEventArgs) Handles Datagrid_General.MouseUp
        If e.Button = MouseButtons.Right Then
            SeleccionMouse(sender, e, CType(Datagrid_General, Flicker_Datagridview), Descripcion_General_label)
        End If
    End Sub

    Private Sub SeleccionMouse(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object, ByVal Label_seleccionado As Label)
        Datagridseleccionado = Nothing
        Datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        Select Case Label_seleccionado.Text.ToUpper
            Case Is = "BANCO"
                AddHandler item1.Click, AddressOf Menucontextual_Conciliacion
                Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
                item2.Tag = 1
                AddHandler item2.Click, AddressOf Menucontextual_Conciliacion
                Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
                item3.Tag = 2
                AddHandler item3.Click, AddressOf Menucontextual_Conciliacion
                Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
                item4.Tag = 3
                AddHandler item4.Click, AddressOf Menucontextual_Conciliacion
                'MFyV
                'Monto
                Dim item09 = cms.Items.Add("Buscar en MFyV - Monto Seleccionado.")
                item09.Tag = 99
                AddHandler item09.Click, AddressOf Menucontextual_Conciliacion
                'Nro Transferencia
                Dim item11 = cms.Items.Add("Buscar en MFyV - Nro de Transf. " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("nro_transaccion").Value.ToString)
                item11.Tag = 100
                AddHandler item11.Click, AddressOf Menucontextual_Conciliacion
                'Fecha
                Dim item12 = cms.Items.Add("Buscar en MFyV - Fecha " & CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("FECHA").Value, Date).ToShortDateString)
                item12.Tag = 101
                AddHandler item12.Click, AddressOf Menucontextual_Conciliacion
            Case Is = "LIBRO"
                Dim item00 = cms.Items.Add("MFyV")
                item00.Tag = 999
                AddHandler item00.Click, AddressOf Menucontextual_Conciliacion
                Dim item0 = cms.Items.Add("Exportar toda la tablar a Excel")
                item0.Tag = 0
                AddHandler item0.Click, AddressOf Menucontextual_Conciliacion
                AddHandler item1.Click, AddressOf Menucontextual_Conciliacion
                Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
                item2.Tag = 1
                AddHandler item2.Click, AddressOf Menucontextual_Conciliacion
                Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
                item3.Tag = 2
                AddHandler item3.Click, AddressOf Menucontextual_Conciliacion
                Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
                item4.Tag = 3
                AddHandler item4.Click, AddressOf Menucontextual_Conciliacion
                If Datagridseleccionado.SelectedCells.Count > 0 Then
                    'los tags correspondientes a libro serán por tanto multipos de 10 asaciado al tag principal
                    Dim item6 = cms.Items.Add("MODIFICAR MOVIMIENTO DE EXP." & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("EXPEDIENTE_N").Value.ToString)
                    item6.Tag = 50
                    AddHandler item6.Click, AddressOf Menucontextual_Conciliacion
                    Dim item5 = cms.Items.Add("Buscar por Nro Transferencia " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("nrotransferencia").Value.ToString)
                    item5.Tag = 30
                    AddHandler item5.Click, AddressOf Menucontextual_Conciliacion
                    Dim item51 = cms.Items.Add("Buscar por Expediente " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("EXPEDIENTE_N").Value.ToString)
                    item51.Tag = 40
                    AddHandler item51.Click, AddressOf Menucontextual_Conciliacion
                    Dim item7 = cms.Items.Add("Buscar por fecha " & CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("FECHA").Value, Date).ToShortDateString)
                    item7.Tag = 60
                    AddHandler item7.Click, AddressOf Menucontextual_Conciliacion
                    Dim item8 = cms.Items.Add("Buscar por CUIT " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("CUIT").Value.ToString)
                    item8.Tag = 70
                    AddHandler item8.Click, AddressOf Menucontextual_Conciliacion
                    Dim item9 = cms.Items.Add("Buscar por Pedido de Fondo " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("pedido de fondo").Value.ToString)
                    item9.Tag = 80
                    AddHandler item9.Click, AddressOf Menucontextual_Conciliacion
                    Dim item10 = cms.Items.Add("Buscar por Importe " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("importe").Value.ToString)
                    item10.Tag = 90
                    AddHandler item10.Click, AddressOf Menucontextual_Conciliacion
                    'MFyV
                    'Monto
                    Dim item09 = cms.Items.Add("Buscar en MFyV - Monto Seleccionado.")
                    item09.Tag = 99
                    AddHandler item09.Click, AddressOf Menucontextual_Conciliacion
                    'Nro Transferencia
                    Dim item11 = cms.Items.Add("Buscar en MFyV - Nro de Transf. " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("nrotransferencia").Value.ToString)
                    item11.Tag = 100
                    AddHandler item11.Click, AddressOf Menucontextual_Conciliacion
                    'Fecha
                    Dim item12 = cms.Items.Add("Buscar en MFyV - Fecha " & CType(Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("FECHA").Value, Date).ToShortDateString)
                    item12.Tag = 101
                    AddHandler item12.Click, AddressOf Menucontextual_Conciliacion
                    'Fecha
                    Dim item13 = cms.Items.Add("Buscar en MFyV - Expediente " & Datagridseleccionado.Rows(Datagridseleccionado.SelectedCells(0).RowIndex).Cells.Item("EXPEDIENTE_N").Value.ToString)
                    item13.Tag = 102
                    AddHandler item13.Click, AddressOf Menucontextual_Conciliacion
                End If
        End Select
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub SeleccionMouse2(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByVal Label_seleccionado As Label)
        Dim cms = New ContextMenuStrip
        Dim item00 = cms.Items.Add("Copiar")
        item00.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        Select Case Label_seleccionado.Text.ToUpper
            Case Is = "BANCO"
            Case Is = "LIBRO"
        End Select
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub Datagrid_General_RowPrePaint(sender As DataGridView, e As DataGridViewRowPrePaintEventArgs) Handles Datagrid_General.RowPrePaint
        Select Case Descripcion_General_label.Text.ToUpper
            Case Is = "BANCO"
                Color_Celdabanco(sender, e)
            Case Is = "LIBRO"
                Color_CeldaLibro(sender, e)
        End Select
    End Sub

    Private Sub Color_Celdabanco(ByVal sender As DataGridView, ByVal e As DataGridViewRowPrePaintEventArgs)
        If CType(sender.Rows(e.RowIndex).Cells.Item("Libro_asociado").Value, Decimal) = Math.Abs(CType(sender.Rows(e.RowIndex).Cells.Item("importe").Value, Decimal)) Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Importe mov."), Color.LightGreen)
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Asociado_con_Libro"), Color.LightGreen)
        Else
            If Math.Abs(CType(sender.Rows(e.RowIndex).Cells.Item("Libro_asociado").Value, Decimal)) > 0 Then
                Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Importe mov."), Color.LightCoral)
            Else
                Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Importe mov."), Color.LightGray)
            End If
        End If
    End Sub

    Private Sub Color_CeldaLibro(ByVal sender As DataGridView, ByVal e As DataGridViewRowPrePaintEventArgs)
        If sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value.ToString.ToUpper.Contains("** IPS **") Then
            Colorfila(sender.Rows(e.RowIndex), Color.Yellow)
        Else
            If ((sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value.ToString.ToUpper.Contains("IPS")) _
            Or (sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value.ToString.ToUpper.Contains("JUB.")) _
            Or (sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value.ToString.ToUpper.Contains("OBRA SO")) _
            Or (sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value.ToString.ToUpper.Contains("ESTATAL"))) _
            And Not ((sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value.ToString.ToUpper.Contains("** IPS **"))) Then
                Colorfila(sender.Rows(e.RowIndex), Color.Yellow)
                sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value = "** IPS **" & sender.Rows(e.RowIndex).Cells.Item("DETALLE").Value.ToString
            Else
                If sender.Rows(e.RowIndex).Cells.Item("Libro_asociado").Value.ToString = "0" Or sender.Rows(e.RowIndex).Cells.Item("Libro_asociado").Value.ToString = "0,00" Then
                    'caso de que no exista ningun movimiento sumado
                    Colorcelda(sender.Rows(e.RowIndex).Cells.Item("importe"), Color.LightGray)
                    Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Libro_asociado"), Color.LightGray)
                Else
                    'en caso de que existan movimientos asociados al mismo movimiento
                    If CType(sender.Rows(e.RowIndex).Cells.Item("Libro_asociado").Value.ToString.Replace(".", "").ToString, Decimal) = Math.Abs(CType(sender.Rows(e.RowIndex).Cells.Item("Importe").Value.ToString.Replace(".", "").ToString, Decimal)) Then
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Importe"), Color.LightGreen)
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Libro_asociado"), Color.LightGreen)
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("MONTO"), Color.LightGreen)
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Nrotransferencia"), Color.LightGreen)
                    Else
                        If Math.Abs(CType(sender.Rows(e.RowIndex).Cells.Item("Libro_asociado").Value.ToString.Replace(".", "").ToString, Decimal)) > 0 Then
                            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("importe"), Color.LightCoral)
                            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Nrotransferencia"), Color.LightCoral)
                        Else
                            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("importe"), Color.LightGray)
                            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Nrotransferencia"), Color.LightGray)
                        End If
                    End If
                End If
                Select Case sender.Rows(e.RowIndex).Cells.Item("MFyV").Value.ToString
                    Case Is = "423"
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LightCyan)
                    Case Is = "493"
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LightBlue)
                    Case Is = "121"
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LightGreen)
                    Case Is = "191"
                        Colorcelda(sender.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LawnGreen)
                End Select
            End If
        End If
    End Sub

    Private Sub Datagrid_General_CellEnter(sender As SICyF.Flicker_Datagridview, e As DataGridViewCellEventArgs) Handles Datagrid_General.CellEnter
        If Datagrid_General.SelectedCells.Count > 0 Then
            Dim ingresos As Decimal = 0
            Dim egresos As Decimal = 0
            Dim Movbancario As Decimal = 0
            Dim sumatemporal As Decimal = 0
            Dim filasseleccionadas As New List(Of Integer)()
            Splitcontainer_Datos.Panel2.Visible = True
            Select Case Descripcion_General_label.Text.ToUpper
                Case Is = "BANCO"
                    Refresh_libro(Datatable_Detalles, Datagrid_Detalles, Descripcion_Detallado_label, Imagen_detallado)
                    'Buscador_detallado.Text = Datagrid_General.SelectedRows(0).Cells.Item("MD5HASH").Value.ToString
                    'Buscar_datagrid(Buscador_detallado, Datatable_Detalles, Datagrid_Detalles)
                Case Is = "LIBRO"
                    Refreshbanco(Datatable_Detalles, Datagrid_Detalles, Descripcion_Detallado_label, Imagen_detallado)
                    'Buscador_detallado.Text = Datagrid_General.SelectedRows(0).Cells.Item("MD5HASH").Value.ToString
                    'Buscar_datagrid(Buscador_detallado, Datatable_Detalles, Datagrid_Detalles)
            End Select
            If Not IsNothing(filasseleccionadas) Then
                For x = 0 To sender.SelectedCells.Count - 1
                    If (Not filasseleccionadas.Contains(sender.SelectedCells(x).RowIndex)) Then
                        filasseleccionadas.Add(sender.SelectedCells(x).RowIndex)
                        Select Case sender.Name
                            Case Is = Datagrid_General.Name
                            Case Is = Datagrid_Detalles.Name
                        End Select
                    End If
                Next
                For z = 0 To filasseleccionadas.Count - 1
                    Select Case Descripcion_General_label.Text.ToUpper
                        Case Is = "BANCO"
                            Movbancario += sender.Rows(z).Cells.Item("Importe Mov.").Value
                        Case Is = "LIBRO"
                            Select Case sender.Rows(z).Cells.Item("MFyv").Value.ToString.Substring(2)
                                Case Is = "1"
                                    egresos += sender.Rows(z).Cells.Item("Monto").Value
                                Case Is = "2"
                                    sumatemporal += 0
                                Case Is = "3"
                                    ingresos += sender.Rows(z).Cells.Item("Monto").Value
                            End Select
                    End Select
                Next
                Select Case Descripcion_General_label.Text.ToUpper
                    Case Is = "BANCO"
                        Inicio.ToolStripDebug.Text = "Movimientos Bancarios =" & Movbancario.ToString.Format("C")
                    Case Is = "LIBRO"
                        Inicio.ToolStripDebug.Text = "Ingresos =" & Format(ingresos, ("C")) & " - " & "Egresos =" & Format(egresos, ("C"))
                End Select
            Else
                filasseleccionadas.Add(sender.SelectedCells(0).RowIndex)
                'filasseleccionadas(0) = sender.SelectedCells(0).RowIndex
            End If
        Else
            Splitcontainer_Datos.Panel2.Visible = False
        End If
    End Sub

    Private Sub Sugerencias_Tabcontrol_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Sugerencias_Tabcontrol.DrawItem
        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = sender.TabPages(e.Index)
        tp.BackColor = Color.PaleGreen
        tp.ForeColor = Color.Black
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)
        sf.Alignment = StringAlignment.Center
        Dim strTitle As String = tp.Text
        'If the current index is the Selected Index, change the color
        If sender.SelectedIndex = e.Index Then
            'this is the background color of the tabpage
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.BackColor)
            'this is the background color of the tab page
            g.FillRectangle(br, e.Bounds)
            'this is the background color of the tab page
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.ForeColor)
            g.DrawString(strTitle, sender.Font, br, r, sf)
        Else
            'these are the standard colors for the unselected tab pages
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, sender.Font, br, r, sf)
        End If
    End Sub

    Private Sub Mostrarsolonoconciliado_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles Mostrarsolonoconciliado_checkbox.CheckedChanged
        Select Case Mostrarsolonoconciliado_checkbox.Checked
            Case True
                Datagrid_General.CurrentCell = Nothing
                For x = 0 To Datagrid_General.Rows.Count - 1
                    'primero evalua el caso en el que la suma asociada y lo relacionado en banco con ese hash md5 no sea 0 en ambos casos
                    If Not ((Datagrid_General.Rows(x).Cells.Item("Libro_asociado").Value.ToString = "0") And (Datagrid_General.Rows(x).Cells.Item("importe").Value.ToString = "0")) Then
                        'luego procede la evaluación correspondiente a la igualdad de ambos items
                        If CType(Datagrid_General.Rows(x).Cells.Item("Libro_asociado").Value, Decimal) = Math.Abs(CType(Datagrid_General.Rows(x).Cells.Item("importe").Value, Decimal)) Then
                            Datagrid_General.Rows(x).Visible = False
                        Else
                            If Math.Abs(CType(Datagrid_General.Rows(x).Cells.Item("Libro_asociado").Value, Decimal)) > 0 Then
                                ' Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Importe mov."), Color.LightCoral)
                            Else
                                '  Colorcelda(sender.Rows(e.RowIndex).Cells.Item("Importe mov."), Color.DimGray)
                            End If
                        End If
                    Else
                    End If
                Next
                'Select Case Descripcion_General_label.Text.ToUpper
                '    Case Is = "BANCO"
                '        'Case Is = "LIBRO"
                'End Select
            Case False
                For x = 0 To Datagrid_General.Rows.Count - 1
                    Datagrid_General.Rows(x).Visible = True
                Next
        End Select
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Mouse_datagridview_MouseWheel(sender As Object, e As MouseEventArgs) Handles Datagrid_General.MouseWheel, Datagrid_Detalles.MouseWheel
    End Sub

    Private Sub Datagrid_Selector_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datagrid_Selector.CellContentClick
    End Sub

    Private Sub Tesoreria_Conciliacion2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

End Class