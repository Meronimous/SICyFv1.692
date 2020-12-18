Imports System.Globalization

Public Class Conciliacion_Bancaria
    Dim Banco_datos_datatable As New DataTable
    Dim Bancolibro As New DataTable
    Dim Servicio_administrativo_datatable As New DataTable
    Dim Sugerencias_datatable As New DataTable
    Dim datagridseleccionado As DataGridView
    Dim Verificadordecarga As Boolean = False
    Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    Dim Tiempodetecleobancario As New Windows.Threading.DispatcherTimer()
    Dim Fechamascercana(2) As Date
    Dim Modoautomatico As Boolean = False
    Dim cambiandofecha As Boolean = False

    Private Sub Tiempodetecleo_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Busquedasugerenciastextbox.Enabled = False
        refreshSugerencia()
        'freno de mano al timer
        Busquedasugerenciastextbox.Enabled = True
        Busquedasugerenciastextbox.Select()
        Busquedasugerenciastextbox.BackColor = Color.White
        Tiempodetecleo.Stop()
    End Sub

    Sub Tiempodetecleobancario_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Busquedabancaria.Enabled = False
        RefreshBanco("")
        'freno de mano al timer
        Busquedabancaria.Enabled = True
        Busquedabancaria.Select()
        Busquedabancaria.BackColor = Color.White
        Tiempodetecleobancario.Stop()
    End Sub

    Private Sub Cargarefreshbanco()
        Inicio.OBJETOCARGANDO(Flicker_Split_panel1, Me, "Cargando, por favor Espere")
        RefreshBanco("")
        Inicio.OBJETOFINALIZAR(Flicker_Split_panel1, Me)
    End Sub

    Private Sub RefreshBanco(ByVal acotado As String)
        ' Flicker_Split_panel1.Visible = True
        Verificadordecarga = True
        Dim busquedasql As String = " where ((descripcion like @busqueda)or (Nro_Transaccion like @busqueda) or (importe like @busqueda) or (CATEGORIA like @busqueda)) "
        Dim Columnadebotones As New DataGridViewButtonColumn
        With Columnadebotones
            .HeaderText = "De acuerdo?"
        End With
        Select Case Busquedabancaria.TextLength
            Case = 0
                busquedasql = ""
            Case Else
        End Select
        Banco_datagridview.Columns.Clear()
        Banco_datagridview.DataSource = Nothing
        If Cuentas_combobox.SelectedIndex >= 0 Then
            SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value)
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType(Desde_monthcalendarA.Value.Year & "-01-01", Date))
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value)
            Select Case Controlesbancarios_tab.SelectedTab.Name.ToUpper
                Case "BANCOSINCONCILIAR_TAB"
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Add("start_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Desde_monthcalendarA.Value.Date
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Add("last_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Hasta_monthcalendarA.Value.Date
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Add("primerdia", MySql.Data.MySqlClient.MySqlDbType.Date).Value = CType(Autorizaciones.Year & "-01-01", Date)
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Add("acotado", MySql.Data.MySqlClient.MySqlDbType.VarChar, 20).Value = acotado
                    Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_CONCILIACION_BASICA", Banco_datos_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    '                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
                    'Select
                    'MD5HASH,
                    'Cuenta,
                    'Fecha,
                    'Nro_Transaccion,
                    'Descripcion,
                    'CATEGORIA,
                    'Importe,
                    'CASE WHEN ABS(MONTO_ASOCIADO) >0 THEN monto_asociado ELSE 0 END as 'Monto en Libro',
                    '( (CASE WHEN ABS(MONTO_ASOCIADO) >0 THEN monto_asociado ELSE 0 END)- abs(importe)) as diferencia,
                    '`movimientos`
                    ',Saldo as 'Saldo en Banco'
                    'FROM
                    '(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH',Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,SUM(IMPORTE) AS IMPORTE,SALDO as 'Saldo',
                    'CASE WHEN importe>0 THEN md5(Nro_Transaccion+importe) ELSE md5(Nro_Transaccion+importe *-1) END as 'MD5S',CASE WHEN COUNT(CUENTA)=1 THEN '' ELSE
                    'GROUP_CONCAT(Format(importe,2, 'es_AR'),' (',DATE_FORMAT(FECHA,'%d/%m/%Y'),' ', Descripcion,' ) ') END  as 'movimientos'
                    'FROM reportebanco where Fecha BETWEEN @desde AND @hasta group by nro_transaccion )A
                    'Left Join
                    '(SELECT SUM(MONTO) AS 'MONTO_ASOCIADO',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)B
                    'On A.MD5HASH=B.MD5_RELACIONADO
                    'WHERE ((not (MONTO_ASOCIADO=ABS(IMPORTE))) OR ISNULL(MONTO_ASOCIADO)) AND
                    '(((Fecha BETWEEN @desde AND @hasta)) OR (Fecha=@desde) OR (Fecha=@hasta)) AND
                    'Cuenta=@Cuenta
                    'ORDER BY FECHA asc, NRO_TRANSACCION DESC", Banco_datos_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Banco_datagridview.DataSource = Banco_datos_datatable
                    If Modoautomatico Then
                        'Banco_datagridview.Columns("CATEGORIA").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Formatocolumnas(Banco_datagridview, CType(Banco_datagridview.DataSource, DataTable))
                        'Banco_datagridview.Columns("DESCRIPCION").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Else
                        Banco_datagridview.Columns("CATEGORIA").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Banco_datagridview.Columns("DESCRIPCION").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        Formatocolumnas(Banco_datagridview, CType(Banco_datagridview.DataSource, DataTable))
                        Banco_datagridview.Columns.Add(Columnadebotones)
                        For x = 0 To Banco_datagridview.Rows.Count - 1
                            If IsDBNull(Banco_datagridview.Rows(x).Cells.Item("Monto en Libro").Value) Then
                                Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Value = ""
                                Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.BackColor = Color.White
                            Else
                                Select Case Math.Abs(CType(Banco_datagridview.Rows(x).Cells.Item("importe").Value, Decimal)) = CType(Banco_datagridview.Rows(x).Cells.Item("Monto en Libro").Value, Decimal)
                                    Case True
                                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Value = "OK"
                                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.BackColor = Color.LightGreen
                                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionBackColor = Color.LightGreen
                                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionForeColor = Color.Black
                                    Case False
                                        Select Case CType(Banco_datagridview.Rows(x).Cells.Item("Monto en Libro").Value, Decimal)
                                            Case > 0
                                                Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Value = "VERIFICAR"
                                                Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.BackColor = Color.LightYellow
                                        End Select
                                End Select
                            End If
                            pintarfila(x)
                            Banco_datagridview.Columns("MD5HASH").Visible = False
                            Banco_datagridview.Columns("Cuenta").Visible = False
                            Banco_datagridview.Columns("Fecha").Visible = True
                            Banco_datagridview.Columns("Nro_Transaccion").Visible = True
                            Banco_datagridview.Columns("Descripcion").Visible = True
                            Banco_datagridview.Columns("Saldo en Banco").Visible = False
                        Next
                    End If
                Case "BANCOCONCILIADO_TAB"
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
MD5HASH,
Cuenta,
Fecha,
Nro_Transaccion,
Descripcion,
CATEGORIA,
Importe,
CASE WHEN ABS(MONTO_ASOCIADO) >0 THEN monto_asociado ELSE 0 END as 'Monto en Libro',
`movimientos`
,Saldo as 'Saldo en Banco'
FROM
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH',Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,SUM(IMPORTE) AS IMPORTE,SALDO as 'Saldo',
CASE WHEN importe>0 THEN md5(Nro_Transaccion+importe) ELSE md5(Nro_Transaccion+importe *-1) END as 'MD5S',CASE WHEN COUNT(CUENTA)=1 THEN '' ELSE
GROUP_CONCAT(Format(importe,2, 'es_AR'),' (',DATE_FORMAT(FECHA,'%d/%m/%Y'),' ', Descripcion,' ) ') END  as 'movimientos'
FROM reportebanco where Fecha BETWEEN @desde AND @hasta group by nro_transaccion )A
Left Join
(SELECT SUM(MONTO) AS 'MONTO_ASOCIADO',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)B
On A.MD5HASH=B.MD5_RELACIONADO
WHERE (( (MONTO_ASOCIADO=ABS(IMPORTE))) ) AND
(((Fecha BETWEEN @desde AND @hasta)) OR (Fecha=@desde) OR (Fecha=@hasta)) AND
Cuenta=@Cuenta
ORDER BY FECHA asc, NRO_TRANSACCION DESC", Banco_datos_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Banco_datagridview.DataSource = Banco_datos_datatable
                    Banco_datagridview.Columns.Add(Columnadebotones)
                    For x = 0 To Banco_datagridview.Rows.Count - 1
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Value = "Quitar Movimiento"
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.BackColor = Color.Red
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionBackColor = Color.Red
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionForeColor = Color.White
                        pintarfila(x)
                    Next
                    Banco_datagridview.Columns("MD5HASH").Visible = False
                    Banco_datagridview.Columns("Cuenta").Visible = False
                    Banco_datagridview.Columns("Fecha").Visible = True
                    Banco_datagridview.Columns("Nro_Transaccion").Visible = True
                    Banco_datagridview.Columns("Descripcion").Visible = True
                    Banco_datagridview.Columns("CATEGORIA").Visible = True
                    Banco_datagridview.Columns("Importe").Visible = True
                    Banco_datagridview.Columns("Importe").Visible = False
                    Banco_datagridview.Columns("Saldo en Banco").Visible = True
                    Banco_datagridview.Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("Nro_Transaccion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("Importe").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    'Banco_datagridview.Columns("Saldo").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("CATEGORIA").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.CurrentCell = Nothing
                    Banco_datagridview.Columns("Importe").DefaultCellStyle.Format = "C"
                    Banco_datagridview.Columns("Monto en Libro").DefaultCellStyle.Format = "C"
                Case "BANCOUNIFICADO_TAB"
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
Select
MD5HASH,
Cuenta,
Fecha,
Nro_Transaccion,
Descripcion,
CATEGORIA,
Importe,
CASE WHEN ABS(MONTO_ASOCIADO) >0 THEN monto_asociado ELSE 0 END as 'Monto en Libro',
( (CASE WHEN ABS(MONTO_ASOCIADO) >0 THEN monto_asociado ELSE 0 END)- abs(importe)) as diferencia,
`movimientos`
,Saldo as 'Saldo en Banco'
FROM
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH',Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,SUM(IMPORTE) AS IMPORTE,SALDO as 'Saldo',
CASE WHEN importe>0 THEN md5(Nro_Transaccion+importe) ELSE md5(Nro_Transaccion+importe *-1) END as 'MD5S',CASE WHEN COUNT(CUENTA)=1 THEN '' ELSE
GROUP_CONCAT(Format(importe,2, 'es_AR'),' (',DATE_FORMAT(FECHA,'%d/%m/%Y'),' ', Descripcion,' ) ') END  as 'movimientos'
FROM reportebanco where Fecha BETWEEN @desde AND @hasta group by nro_transaccion )A
Left Join
(SELECT SUM(MONTO) AS 'MONTO_ASOCIADO',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)B
On A.MD5HASH=B.MD5_RELACIONADO
WHERE
(((Fecha BETWEEN @desde AND @hasta)) OR (Fecha=@desde) OR (Fecha=@hasta)) AND
Cuenta=@Cuenta
ORDER BY FECHA asc, NRO_TRANSACCION DESC", Banco_datos_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Banco_datagridview.DataSource = Banco_datos_datatable
                    Banco_datagridview.Columns.Add(Columnadebotones)
                    For x = 0 To Banco_datagridview.Rows.Count - 1
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Value = "Quitar Movimiento"
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.BackColor = Color.Red
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionBackColor = Color.Red
                        Banco_datagridview.Rows(x).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionForeColor = Color.White
                        pintarfila(x)
                    Next
                    Banco_datagridview.Columns("MD5HASH").Visible = False
                    Banco_datagridview.Columns("Cuenta").Visible = False
                    Banco_datagridview.Columns("Fecha").Visible = True
                    Banco_datagridview.Columns("Nro_Transaccion").Visible = True
                    Banco_datagridview.Columns("Descripcion").Visible = True
                    ' Banco_datagridview.Columns("Importe").Visible = True
                    ' Banco_datagridview.Columns("Importe").Visible = False
                    'Banco_datagridview.Columns("Monto en Libro").Visible = False
                    'Banco_datagridview.Columns("Monto_asociar").Visible = True
                    Banco_datagridview.Columns("Saldo en Banco").Visible = False
                    ' Banco_datagridview.Columns("Clave_expediente_detalle").Visible = False
                    Banco_datagridview.Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("Nro_Transaccion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("Importe").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Banco_datagridview.Columns("Saldo en Banco").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("Descripcion").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("movimientos").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("Monto en Libro").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    Banco_datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
                    'Banco_datagridview.Columns("orden").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    'Banco_datagridview.Columns("monto").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Banco_datagridview.Columns("IMPORTE").DefaultCellStyle.Format = "C"
                    Banco_datagridview.Columns("Monto en Libro").DefaultCellStyle.Format = "C"
                    Banco_datagridview.Columns("Saldo en Banco").DefaultCellStyle.Format = "C"
                    Banco_datagridview.Columns("DIFERENCIA").DefaultCellStyle.Format = "C"
                    Banco_datagridview.CurrentCell = Nothing
                Case Else
                    Banco_datagridview.DataSource = Nothing
            End Select
            ' Datosdetallados_label.Text = " Período desde el: " & Desde_monthcalendarA.Value.ToShortDateString & " al: " & Hasta_monthcalendarA.Value.ToShortDateString & " inclusive "
            If Verificadordecarga Then
                refreshtotalesbancolibro()
            End If
        End If
    End Sub

    Private Sub refreshtotalesbancolibro()
        SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType(Desde_monthcalendarA.Value.Year & "-01-01", Date))
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
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
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
		UNION ALL
			SELECT '0' AS 'INGRESO',(MONTO) AS EGRESOS FROM	expediente_detalle WHERE (CodInp = 1)	AND Fechadelmovimiento BETWEEN @desde	AND @hasta
			AND SUBSTRING(Clave_expediente_detalle FROM	1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT	Clave_expediente	FROM expediente	WHERE clave_pedidofondo
 IN (SELECT	clave_pedidofondo	FROM pedido_fondos WHERE Cuenta_pedidofondo = @cuenta))) A
", Bancolibro, System.Reflection.MethodBase.GetCurrentMethod.Name)
        BancoTOTALES_datagridvieW.DataSource = Bancolibro
    End Sub

    Private Sub pintarfila(ByVal indice As Integer)
        'coincidencia de fechas evaluacion
        If IsDBNull(Banco_datagridview.Rows(indice).Cells.Item("FECHA").Value) Then
            Banco_datagridview.Rows(indice).Cells.Item("FECHA").Style.BackColor = Color.DimGray
        Else
            'SE DESACTIVA LA AYUDA VISUAL POR LOS DATOS NO CORRECTOS DEL SISTEMA DE MOVIMIENTO DE FONDOS Y VALORES MFYV
            'Select Case CType(Banco_datagridview.Rows(indice).Cells.Item("Fecha").Value, Date) <= CType(Banco_datagridview.Rows(indice).Cells.Item("Fechadelmovimiento").Value, Date)
            '    Case True
            '        Banco_datagridview.Rows(indice).Cells.Item("Fechadelmovimiento").Style.BackColor = Color.PaleGreen
            '    Case False
            '        Banco_datagridview.Rows(indice).Cells.Item("Fechadelmovimiento").Style.BackColor = Color.Coral
            'End Select
        End If
        'monto asociado evaluacion
        'Coloreado de Categorias
        Select Case Banco_datagridview.Rows(indice).Cells.Item("CATEGORIA").Value.ToString.ToUpper
            Case "COMISIONES BANCARIAS"
                Banco_datagridview.Rows(indice).DefaultCellStyle.BackColor = Color.PaleGreen
            Case "CHEQUE RECHAZADO"
                Banco_datagridview.Rows(indice).DefaultCellStyle.BackColor = Color.LightYellow
            Case "DEBITO FISCAL IVA BASICO"
                Banco_datagridview.Rows(indice).DefaultCellStyle.BackColor = Color.PaleGreen
            Case "DEPOSITO TESORERIA GRAL."
                Banco_datagridview.Rows(indice).DefaultCellStyle.BackColor = Color.LightSkyBlue
            Case "HABERES"
                Banco_datagridview.Rows(indice).DefaultCellStyle.BackColor = Color.LightPink
        End Select
        Select Case Controlesbancarios_tab.SelectedTab.Name.ToUpper
            Case "BANCOSINCONCILIAR_TAB"
                If IsDBNull(Banco_datagridview.Rows(indice).Cells.Item("importe").Value) Then
                    Banco_datagridview.Rows(indice).Cells.Item("importe").Style.BackColor = Color.DimGray
                Else
                    'Select Case Math.Abs(CType(Banco_datagridview.Rows(indice).Cells.Item("importe").Value, Decimal)) <> CType(Banco_datagridview.Rows(indice).Cells.Item("monto").Value, Decimal)
                    '    Case True
                    '        If Banco_datagridview.Rows(indice).Cells.Item("importe").Value = 0 Then
                    '            Banco_datagridview.Rows(indice).Cells.Item("importe").Style.BackColor = Color.LightGray
                    '            Banco_datagridview.Rows(indice).Cells.Item("importe").Style.BackColor = Color.LightGray
                    '        Else
                    '            Banco_datagridview.Rows(indice).Cells.Item("importe").Style.BackColor = Color.LightYellow
                    '            Banco_datagridview.Rows(indice).Cells.Item("importe").Style.BackColor = Color.LightYellow
                    '        End If
                    '    Case False
                    '        Banco_datagridview.Rows(indice).Cells.Item("Importe").Style.BackColor = Color.LightGreen
                    '        Banco_datagridview.Rows(indice).Cells.Item("monto").Style.BackColor = Color.LightGreen
                    'End Select
                End If
            Case "BANCOCONCILIADO_TAB"
                'If IsDBNull(Banco_datagridview.Rows(indice).Cells.Item("monto").Value) Then
                '    Banco_datagridview.Rows(indice).Cells.Item("monto").Style.BackColor = Color.Yellow
                'Else
                '    Select Case Math.Abs(CType(Banco_datagridview.Rows(indice).Cells.Item("importe").Value, Decimal)) <> CType(Banco_datagridview.Rows(indice).Cells.Item("monto").Value, Decimal)
                '        Case True
                '            Banco_datagridview.Rows(indice).DefaultCellStyle.BackColor = Color.LightCoral
                '            Banco_datagridview.Rows(indice).DefaultCellStyle.SelectionBackColor = Color.Red
                '            Banco_datagridview.Rows(indice).DefaultCellStyle.SelectionForeColor = Color.White
                '        Case False
                '            Banco_datagridview.Rows(indice).Cells.Item("Importe").Style.BackColor = Color.LightGreen
                '            Banco_datagridview.Rows(indice).Cells.Item("monto").Style.BackColor = Color.LightGreen
                '    End Select
                'End If
        End Select
        '
    End Sub

    Private Sub Banco_datagridview_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Banco_datagridview.RowPrePaint
    End Sub

    Private Sub refreshServicioAdministrativo()
        Select Case Banco_datagridview.SelectedRows.Count > 0
            Case True
                If Cuentas_combobox.SelectedIndex >= 0 Then
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType(Desde_monthcalendarA.Value.Year & "-01-01", Date))
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@MD5HASH", Banco_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Value.ToString.Replace("-", ""))
                    '            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
                    'Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia
                    'from Expediente_detalle where (((Fechadelmovimiento BETWEEN @desde AND @hasta)) OR
                    '                           (Fechadelmovimiento=@desde) OR (Fechadelmovimiento=@hasta)) AND
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Expediente_N,Detalle,Monto,`Pedido de Fondo`,`MFyV`,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle
FROM
(select Expediente_N,
Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
from Expediente_detalle where MD5_relacionado=@MD5HASH )A
LEFT JOIN (SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,Clave_expediente FROM expediente)B
ON B.Clave_expediente=SUBSTRING( A.Clave_expediente_detalle
							FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
                            order by Fechadelmovimiento desc,Nrotransferencia asc
", Servicio_administrativo_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Movimientos_asociados_datagridview.DataSource = Servicio_administrativo_datatable
                    If Modoautomatico Then
                        Movimientos_asociados_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    Else
                        Formatocolumnas(Movimientos_asociados_datagridview, CType(Movimientos_asociados_datagridview.DataSource, DataTable))
                    End If
                    'Movimientos_asociados_datagridview.Columns("Monto").DefaultCellStyle.Format = "C"
                    'Movimientos_asociados_datagridview.Columns("Clave_expediente_detalle").Visible = False
                    Movimientos_asociados_datagridview.CurrentCell = Nothing
                    Select Case Movimientos_asociados_datagridview.Rows.Count > 0
                        Case True
                            Quitarasociacion_boton.Visible = True
                        Case False
                            Quitarasociacion_boton.Visible = False
                    End Select
                End If
            Case False
                Movimientos_asociados_datagridview.DataSource = Nothing
        End Select
    End Sub

    Private Sub refreshSugerencia()
        Fechamascercana(0) = Nothing
        Fechamascercana(1) = Nothing
        Fechamascercana(2) = Nothing
        ' Sugerencias_datatable.Clear()
        SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
        AsociarMovimiento_boton.Visible = True
        Dim SUMADO As Decimal = 0
        Select Case Banco_datagridview.SelectedRows.Count > 0
            Case True
                If Cuentas_combobox.SelectedIndex >= 0 Then
                    If Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value > 0 Then
                        If cambiandofecha Then
                        Else
                            Desdesugerencia_datetimepicker.Value = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Fecha").Value, Date).AddDays(-10)
                            Hastasugerencia_datetimepicker.Value = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Fecha").Value, Date).AddDays(+10)
                        End If
                    Else
                        If cambiandofecha Then
                        Else
                            Desdesugerencia_datetimepicker.Value = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Fecha").Value, Date).AddDays(-10)
                            Hastasugerencia_datetimepicker.Value = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Fecha").Value, Date).AddDays(+10)
                        End If
                    End If
                    SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
                    Select Case CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal) > 0
                        Case True
                            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@monto", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
                        Case False
                            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@monto", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value * -1, Decimal))
                    End Select
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Diferencia", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Monto en Libro").Value, Decimal) -
                                        Math.Abs(CType(Banco_datagridview.SelectedRows(0).Cells.Item("importe").Value, Decimal)))
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Busqueda", "%" & Busquedasugerenciastextbox.Text & "%")
                    Select Case Sugerencias_tabcontrol.SelectedTab.Name.ToUpper
                        Case "NROTRANSACCION_TAB"
                            Nrotransaccion_tabsub()
                        Case "MONTOS_TAB"
                            Montos_tabsub()
                        Case "MOVIMIENTOS_AGRUPADOS"
                            Movimientos_agrupadossub()
                        Case "CODIGO_TAB"
                            CODIGO_TABsub()
                        Case "NOASOCIADOS_TAB"
                            Noasociados_tabsub()
                        Case "T_TAB"
                            T_TABsub()
                        Case "DIFERENCIA_TAB"
                            Completo_tabsub()
                        Case "COMPLETO_TAB"
                            Completo_tabsub()
                        Case Else
                            Sugerencias_datatable.Clear()
                    End Select
                    '------------------------------------------------------------------------------------------------------------------------------------------
                    'para poder realizar el movimiento de pintado en el datagrid, en forma anterior debo evaluar los parametros de la datatable.
                    'evaluación de la fecha con menor distancia al movimiento
                    For x = 0 To Sugerencias_datatable.Rows.Count - 1
                        If IsNothing(Fechamascercana(0)) Then
                            Fechamascercana(0) = CType(Sugerencias_datatable.Rows(0).Item("FECHADELMOVIMIENTO"), Date)
                            Fechamascercana(1) = CType(Sugerencias_datatable.Rows(0).Item("FECHADELMOVIMIENTO"), Date)
                            Fechamascercana(2) = CType(Sugerencias_datatable.Rows(0).Item("FECHADELMOVIMIENTO"), Date)
                        End If
                        If Math.Abs(DateDiff(DateInterval.Day, CType(Sugerencias_datatable.Rows(x).Item("FECHADELMOVIMIENTO"), Date), CType(Banco_datagridview.SelectedRows(0).Cells.Item("FECHA").Value, Date))) < Math.Abs(DateDiff(DateInterval.Day, Fechamascercana(0), CType(Banco_datagridview.SelectedRows(0).Cells.Item("FECHA").Value, Date))) Then
                            Fechamascercana(0) = CType(Sugerencias_datatable.Rows(x).Item("FECHADELMOVIMIENTO"), Date)
                        End If
                    Next
                    Sugerencias_datagridview.DataSource = Sugerencias_datatable
                    'Sugerencias_datagridview.Columns("Clave_expediente_detalle").Visible = False
                    'Sugerencias_datagridview.Columns("Monto").DefaultCellStyle.Format = "C"
                    If Modoautomatico Then
                        ' Sugerencias_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    Else
                        Formatocolumnas(Sugerencias_datagridview, CType(Sugerencias_datagridview.DataSource, DataTable))
                    End If
                    Sugerencias_datagridview.CurrentCell = Nothing
                    Select Case Sugerencias_datagridview.Rows.Count > 0
                        Case True
                            AsociarMovimiento_boton.Visible = True
                        Case False
                            AsociarMovimiento_boton.Visible = False
                    End Select
                    For X = 0 To Movimientos_asociados_datagridview.Rows.Count - 1
                        SUMADO += Movimientos_asociados_datagridview.Rows(X).Cells.Item("MONTO").Value
                    Next
                    If SUMADO = Banco_datagridview.SelectedRows(0).Cells.Item("Monto en Libro").Value Then
                    Else
                        Banco_datagridview.SelectedRows(0).Cells.Item("Monto en Libro").Value = SUMADO
                        'Banco_datagridview.SelectedRows(0).Cells.Item("Monto_asociar").Value = SUMADO
                    End If
                    Labelmovimientosasociados_label.Text = "Actualmente asociados $" & SUMADO.ToString("C")
                    Try
                        Select Case Controlesbancarios_tab.SelectedTab.Name.ToUpper
                            Case "BANCOSINCONCILIAR_TAB"
                                If Modoautomatico Then
                                Else
                                    Select Case Math.Abs(CType(Banco_datagridview.SelectedRows(0).Cells.Item("importe").Value, Decimal)) = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Monto en Libro").Value, Decimal)
                                        Case True
                                            Banco_datagridview.SelectedRows(0).Cells.Item(Banco_datagridview.ColumnCount - 1).Value = "OK"
                                            Banco_datagridview.SelectedRows(0).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.BackColor = Color.LightGreen
                                            Banco_datagridview.SelectedRows(0).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionBackColor = Color.LightGreen
                                            Banco_datagridview.SelectedRows(0).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.SelectionForeColor = Color.Black
                                        Case False
                                            Select Case CType(Banco_datagridview.SelectedRows(0).Cells.Item("Monto en Libro").Value, Decimal)
                                                Case > 0
                                                    'Banco_datagridview.SelectedRows(0).Cells.Item(Banco_datagridview.ColumnCount - 1).Value = "VERIFICAR"
                                                    Banco_datagridview.SelectedRows(0).Cells.Item(Banco_datagridview.ColumnCount - 1).Style.BackColor = Color.LightYellow
                                                Case Else
                                            End Select
                                    End Select
                                End If
                            Case "BANCOCONCILIADO_TAB"
                        End Select
                    Catch ex As Exception
                    End Try
                    Calculoposiblemovimientosasociados(CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
                End If
            Case False
                Sugerencias_datagridview.DataSource = Nothing
        End Select
    End Sub

    Private Sub Nrotransaccion_tabsub()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType((Desde_monthcalendarA.Value.Year & "-01-01"), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@montopuro", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,`MFyV`,Clave_expediente_detalle,`Pedido de Fondo` FROM
(Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
                            from Expediente_detalle where
 (ISNUll(MD5_relacionado) or (MD5_relacionado='')) AND Nrotransferencia =@Nrotransferencia AND NOT(CODINP=2) AND NOT(CODINP=0))A
LEFT JOIN (SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,Clave_expediente FROM expediente)B
ON B.Clave_expediente=SUBSTRING(
							A.Clave_expediente_detalle
							FROM
								1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
                            order by Fechadelmovimiento desc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '                            "Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
        'from Expediente_detalle where (Detalle like @Busqueda OR Expediente_N like @Busqueda OR Nrotransferencia like @busqueda) AND
        'order by Fechadelmovimiento desc,Nrotransferencia asc"
        '----------------para la importación de datos del año 2018 debo eliminar el filtro correspondiente a la presencia de pedidos de fondos para poder hacer uso de todos los movimientos-----------------------
        '                            "Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle
        'order by Fechadelmovimiento desc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '----------------para la importación de datos del año 2018 debo eliminar el filtro correspondiente a la presencia de pedidos de fondos para poder hacer uso de todos los movimientos-----------------------
    End Sub

    Private Sub Montos_tabsub()
        '------------------------- ATENCIÓN----------------DEBIDO A LA INCONSISTENCIA DE DATOS DE MFYV DE SALUD PUBLICA DEBO QUITAR EL FILTRO CORRESPONDIENTE CHEQUES, SE URGE RECOMPONERLO PARA LOGRAR UNA MAYOR PRECISIÓN
        'para la importación de datos del año 2018 debo eliminar el filtro correspondiente a la presencia de pedidos de fondos para poder hacer uso de todos los movimientos
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType((Desde_monthcalendarA.Value.Year & "-01-01"), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@montopuro", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("@montopuro", MySql.Data.MySqlClient.MySqlDbType.Decimal, 15, 2).Value = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,
`MFyV`,Clave_expediente_detalle,`Pedido de Fondo` FROM
(Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,
Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
from Expediente_detalle where not (MONTO=0) AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
				and
((Fechadelmovimiento BETWEEN @desde AND @hasta)
and fechadelmovimiento>@primerdia
AND
(ISNUll(MD5_relacionado) or (MD5_RELACIONADO=''))
AND
MONTO =ABS(@montopuro) AND (case when @montopuro>0 then  (CODINP=3) else (CODINP=1) end) AND NOT(CODINP=2) )
OR
(Nrotransferencia in
(Select Nrotransferencia from (select Nrotransferencia,sum(monto) as Sumado from expediente_detalle where isnull(MD5_relacionado) AND (case when @montopuro>0 then  NOT(CODINP=1) else NOT(CODINP=3) end) AND NOT(CODINP=2)
and fechadelmovimiento>@primerdia and (Fechadelmovimiento BETWEEN @desde AND @hasta) and (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
group by Nrotransferencia)temp1
WHERE Sumado=@montopuro ))
)A
LEFT JOIN (SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,Clave_expediente FROM expediente)B
ON B.Clave_expediente=SUBSTRING( A.Clave_expediente_detalle
							FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
                            order by Fechadelmovimiento desc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Private Sub Noasociados_tabsub()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType((Desde_monthcalendarA.Value.Year & "-01-01"), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@montopuro", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
        '                             "Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,`MFyV`,mov_tipo,Clave_expediente_detalle,`Pedido de Fondo` FROM
(Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,mov_tipo,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
                            from Expediente_detalle where  not (MONTO=0) AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
and Fechadelmovimiento > @primerdia
and not (mov_tipo='IPS') and
(case when @montopuro>0 then codinp=3 else codinp=1 end) and
( (ISNUll(MD5_relacionado) OR (MD5_RELACIONADO='')) AND
NOT(CODINP=2) and fechadelmovimiento between @desde and @hasta ))A
LEFT JOIN (SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,Clave_expediente FROM expediente)B
ON B.Clave_expediente=SUBSTRING(
							A.Clave_expediente_detalle
							FROM
								1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
                            order by Fechadelmovimiento asc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Private Sub CODIGO_TABsub()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType((Desde_monthcalendarA.Value.Year & "-01-01"), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@montopuro", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,`MFyV`,Clave_expediente_detalle,`Pedido de Fondo` FROM
(Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
                            from Expediente_detalle  where   not (MONTO=0) AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
and Fechadelmovimiento > @primerdia
and
(concat(Cod_orden,CFdo,CodInp) like @Busqueda)  AND (ISNUll(MD5_relacionado) OR (MD5_RELACIONADO='')) AND (((Fechadelmovimiento BETWEEN @desde AND @hasta)) OR  (Fechadelmovimiento=@desde) OR (Fechadelmovimiento=@hasta)) AND NOT(CODINP=2) )A
LEFT JOIN (SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,Clave_expediente FROM expediente)B
ON B.Clave_expediente=SUBSTRING(
							A.Clave_expediente_detalle
							FROM
								1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
                            order by Fechadelmovimiento desc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '                            "Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
        'from Expediente_detalle where  (concat(Cod_orden,CFdo,CodInp) like @Busqueda) AND
        '(ISNUll(MD5_relacionado)) AND (((Fechadelmovimiento BETWEEN @desde AND @hasta)) OR  (Fechadelmovimiento=@desde) OR (Fechadelmovimiento=@hasta)) AND
    End Sub

    Private Sub T_TABsub()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType((Desde_monthcalendarA.Value.Year & "-01-01"), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@montopuro", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
from Expediente_detalle where  not (MONTO=0) AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
and Fechadelmovimiento > @primerdia
and
(Nrotransferencia like @Busqueda)  AND NOT(CODINP=2) AND (case when @montopuro>0 then codinp=3 else codinp=1 end) and
(ISNUll(MD5_relacionado) OR (MD5_RELACIONADO='') ) AND  /*FILTRO de Busqueda de expedientes en condicione de de ser cargados */
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
order by Fechadelmovimiento desc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Private Sub Completo_tabsub()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType((Desde_monthcalendarA.Value.Year & "-01-01"), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@montopuro", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
        '                             "Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
        'from Expediente_detalle where (Detalle like @Busqueda OR Expediente_N like @Busqueda OR Nrotransferencia like @busqueda) AND
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,`MFyV`,Clave_expediente_detalle,`Pedido de Fondo` FROM
(select * from (Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
from Expediente_detalle where     not (MONTO=0) AND
((ISNUll(MD5_relacionado) or (MD5_RELACIONADO='')) AND MONTO =ABS(@Diferencia)  AND NOT(CODINP=2)
and Fechadelmovimiento > @primerdia
	)
union ALL
Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
from Expediente_detalle where
((ISNUll(MD5_relacionado) or (MD5_RELACIONADO='')) AND Nrotransferencia in
(SELECT Nrotransferencia FROM
( SELECT Nrotransferencia,SUM(MONTO) AS 'TOTAL' FROM expediente_detalle)A1
WHERE TOTAL=ABS(@DIFERENCIA))
  AND NOT(CODINP=2)
	)
	)A1 where
	(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
and Fechadelmovimiento > @primerdia
	)A
LEFT JOIN (SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,Clave_expediente FROM expediente)B
ON B.Clave_expediente=SUBSTRING( A.Clave_expediente_detalle
							FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
                            order by Fechadelmovimiento desc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Private Sub Movimientos_agrupadossub()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType((Desde_monthcalendarA.Value.Year & "-01-01"), Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@montopuro", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
        AsociarMovimiento_boton.Visible = False
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla,
                                                 "SELECT Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,`MFyV`,Clave_expediente_detalle,`Pedido de Fondo` FROM
(Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
from Expediente_detalle where
((ISNUll(MD5_relacionado) or (MD5_RELACIONADO='')) AND MONTO =ABS(@Diferencia)  AND NOT(CODINP=2) )
union ALL
Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
from Expediente_detalle where
                                                 (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
and
((ISNUll(MD5_relacionado) or (MD5_RELACIONADO='')) AND Nrotransferencia in
(SELECT Nrotransferencia FROM
( SELECT Nrotransferencia,SUM(MONTO) AS 'TOTAL' FROM expediente_detalle GROUP BY Nrotransferencia)A1
WHERE TOTAL=ABS(@DIFERENCIA)) and (case when @montopuro>0 then codinp=3 else codinp=1 end) and
  AND NOT(CODINP=2))
)A
LEFT JOIN (SELECT CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,Clave_expediente FROM expediente)B
ON B.Clave_expediente=SUBSTRING( A.Clave_expediente_detalle
							FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
                            order by Fechadelmovimiento desc,Nrotransferencia asc", Sugerencias_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '                               "Select Expediente_N,Detalle,Monto,Fechadelmovimiento,CUIT,Nrotransferencia,Clave_expediente_detalle,concat(Cod_orden,CFdo,CodInp) as 'MFyV'
        'from Expediente_detalle where  (Detalle like @Busqueda OR Expediente_N like @Busqueda OR Nrotransferencia like @busqueda) AND
        '(ISNUll(MD5_relacionado)) AND (((Fechadelmovimiento BETWEEN @desde AND @hasta)) OR  (Fechadelmovimiento=@desde) OR (Fechadelmovimiento=@hasta)) AND
        'order by Fechadelmovimiento desc,Nrotransferencia asc"
    End Sub

    Private Sub Calculoposiblemovimientosasociados(ByVal Monto As Decimal)
        Dim Sumaencontrada As Boolean = False
        Dim Valorexaminado As Decimal = 0
        Dim Listadatagrid As New List(Of DataGridViewRow)
        'Debe salir cuando:
        '                   el valor es igual al monto
        '                   debe sumar todas las variables coincidentes primero
        '                   luego por una sola variable
        '                   luego por todas las variables.
        'SUMA DE UNA VARIABLE
        If Sugerencias_datagridview.Rows.Count > 0 Then
            For x = 0 To Sugerencias_datagridview.Rows.Count - 1
                If Valorexaminado + CType(Sugerencias_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal) = Math.Abs(Monto) Then
                    Listadatagrid.Add(Sugerencias_datagridview.Rows(x))
                    For z = 0 To Listadatagrid.Count - 1
                        Listadatagrid(z).Cells.Item("MONTO").Style.BackColor = Color.LightGreen
                    Next
                    Exit For
                Else
                    If CType(Sugerencias_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal) > Math.Abs(Monto) Then
                    Else
                        Listadatagrid.Add(Sugerencias_datagridview.Rows(x))
                        Valorexaminado += CType(Sugerencias_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal)
                    End If
                End If
            Next
            'Asistencia para fechas,Nro de Transacción, el debe colorear la fecha más cercana con el color verde claro, la siguiente en color amarillo y la ultima en naranja, el resto en gris
            'determinación de la fecha más cercana
        End If
    End Sub

    Private Sub refreshGeneral()
        Banco_datagridview.Enabled = False
        If Verificadordecarga Then
            Cargarefreshbanco()
        End If
        Banco_datagridview.Enabled = True
        Movimientos_asociados_datagridview.Enabled = False
        refreshServicioAdministrativo()
        Movimientos_asociados_datagridview.Enabled = True
    End Sub

    Private Sub Conciliacion_Bancaria_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Cargarefreshbanco()
        'SplitContainer1.Visible = True
        'SplitContainer2.Visible = True
        'Flicker_Split_panel.Visible = True
        'SplitContainer4.Update()
        'SplitContainer1.Update()
    End Sub

    'Valores unicamente validos para la pantalla de conciliación, el menu se compone de opciones básicas y se agrega la posibilidad de determinar categorias correspondientes a la conciliación.
    Private Sub Mousederecho_conciliacion(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As DataGridView)
        datagridseleccionado = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf MenuContextual_conciliacion
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf MenuContextual_conciliacion
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf MenuContextual_conciliacion
        Dim item4 = cms.Items.Add("Categoria")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf MenuContextual_conciliacion
        '-- etc
        '..
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub MenuContextual_conciliacion(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Clipboard.SetDataObject(datagridseleccionado.GetClipboardContent())
                Dim objData As DataObject = datagridseleccionado.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(datagridseleccionado)
                'Select Case datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(datagridseleccionado.GetType.ToString)
                'End Select
            Case Is = 2
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
            Case Is = 3
        End Select
        '-- etc
    End Sub

    'Valores unicamente validos para la pantalla de Movimientos, el menu se compone de opciones básicas y se agrega la posibilidad de buscar el movimiento para modificarlo.
    Private Sub Mousederecho_conciliacionmovimiento(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As DataGridView)
        datagridseleccionado = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf MenuContextual_conciliacionmovimiento
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf MenuContextual_conciliacionmovimiento
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf MenuContextual_conciliacionmovimiento
        Dim item4 = cms.Items.Add("Categoria")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf MenuContextual_conciliacionmovimiento
        Dim item5 = cms.Items.Add("Ver Movimiento")
        item5.Tag = 4
        AddHandler item5.Click, AddressOf MenuContextual_conciliacionmovimiento
        '-- etc
        '..
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub MenuContextual_conciliacionmovimiento(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Clipboard.SetDataObject(datagridseleccionado.GetClipboardContent())
                Dim objData As DataObject = datagridseleccionado.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(datagridseleccionado)
                'Select Case datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(datagridseleccionado.GetType.ToString)
                'End Select
            Case Is = 2
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
            Case Is = 3
                MessageBox.Show("Sin Implementar")
            Case Is = 4
                'Inicio.MENULLAMADO(Movimientos)
                'Movimientos.Busqueda.Text = datagridseleccionado.selectedrows(0).cells.item("Clave_expediente_detalle").value.ToString.Substring(0, datagridseleccionado.selectedrows(0).cells.item("Clave_expediente_detalle").value.ToString.Length - 4)
                Dim Movimientos As New Movimiento With {
                    .Clave_expediente_detalle = datagridseleccionado.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value.ToString,
                        .fecha = datagridseleccionado.SelectedRows(0).Cells.Item("FECHADELMOVIMIENTO").Value,
                    .monto = datagridseleccionado.SelectedRows(0).Cells.Item("Monto").Value,
                    .Transferencia = datagridseleccionado.SelectedRows(0).Cells.Item("Nrotransferencia").Value
                }
                Dialogo_Movimientoscambio.Modificarmovimiento(Movimientos)
                Dialogo_Movimientoscambio.Location = New Point(MousePosition.X - (Dialogo_Movimientoscambio.Width / 2), MousePosition.Y - (Dialogo_Movimientoscambio.Height / 2))
                If Dialogo_Movimientoscambio.ShowDialog() = DialogResult.OK Then
                    ' myStream = Message.OpenFile()
                    refreshServicioAdministrativo()
                    refreshSugerencia()
                End If
                Dialogo_Movimientoscambio.Dispose()
        End Select
        '-- etc
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        If Verificadordecarga Then
            Cargarefreshbanco()
            Select Case Desde_monthcalendarA.Value.Date.AddDays(-10).Year = Autorizaciones.Year
                Case True
                    Desdesugerencia_datetimepicker.Value = Desde_monthcalendarA.Value.Date.AddDays(-10)
                Case Else
                    Desdesugerencia_datetimepicker.Value = DateTime.ParseExact("01/01/" & Desde_monthcalendarA.Value.Year, "MM/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None)
            End Select
            Hastasugerencia_datetimepicker.Value = Hasta_monthcalendarA.Value.Date.AddDays(10)
        End If
    End Sub

    Private Sub Desde_monthcalendarA_ValueChanged(sender As Object, e As EventArgs) Handles Hasta_monthcalendarA.ValueChanged, Desde_monthcalendarA.ValueChanged
        Banco_datagridview.DataSource = Nothing
        Movimientos_asociados_datagridview.DataSource = Nothing
        Sugerencias_datagridview.DataSource = Nothing
        Desdesugerencia_datetimepicker.Value = Desde_monthcalendarA.Value.Date.AddDays(-10)
        Hastasugerencia_datetimepicker.Value = Hasta_monthcalendarA.Value.Date.AddDays(10)
        Cargarefreshbanco()
    End Sub

    Private Sub Conciliacion_Bancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'prueba básica de valores
        Select Case My.Computer.Name.ToUpper
            Case Is = "MERONETBOOK"
                MFyV.Visible = True
            Case Is = "MEROSUPERPC"
                MFyV.Visible = True
            Case Else
        End Select
        Me.CheckForIllegalCrossThreadCalls = False
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
        Desde_monthcalendarA.Value = CType("01-" & Date.Now.AddMonths(-1).Month & "-" & Date.Now.AddMonths(-1).Year, Date)
        Hasta_monthcalendarA.Value = CType(Date.DaysInMonth(Date.Now.AddMonths(-1).Year, Date.Now.AddMonths(-1).Month) & "-" & Date.Now.AddMonths(-1).Month & "-" & Date.Now.AddMonths(-1).Year, Date)
    End Sub

    Private Sub Subirarchivoexcel_boton_Click(sender As Object, e As EventArgs) Handles Subirarchivoexcel_boton.Click
        Inicio.OBJETOCARGANDO(Banco_datagridview, Me, "Cargando archivo Excel")
        Inicio.Abrirarchivoexcel2(Banco_datagridview, 1, 1, Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        If Verificadordecarga Then
            Cargarefreshbanco()
        End If
        ' Inicio.Abrirarchivoexcel(Banco_datagridview, 1, 1)
        Inicio.OBJETOFINALIZAR(Banco_datagridview, Me)
    End Sub

    Private Sub Banco_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Banco_datagridview.CellEnter
        Dim sumatemporal As Decimal = 0
        If Verificadordecarga Then
            Select Case Banco_datagridview.SelectedRows.Count > 0
                Case True
                    Dim cell = Banco_datagridview.CurrentCell
                    Dim cellDisplayRect = Banco_datagridview.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                    refreshServicioAdministrativo()
                    refreshSugerencia()
                    For x = 0 To Banco_datagridview.SelectedRows.Count - 1
                        sumatemporal = sumatemporal + (CType(Banco_datagridview.SelectedRows(x).Cells.Item("importe").Value, Decimal))
                    Next
                    If Modoautomatico = True Then
                        'Banco_datagridview.FirstDisplayedScrollingRowIndex = Banco_datagridview.SelectedRows(0).Index
                    Else
                        Select Case Banco_datagridview.SelectedRows.Count > 1
                        'Calculo y visualización de tooltip-----------------------------------------------------
                            Case True
                                ToolTip1.Show(String.Format("Suma total de los:" & Banco_datagridview.SelectedRows.Count & " movimientos " & vbCrLf & " " & String.Format(sumatemporal.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR")))), e.ColumnIndex, e.RowIndex), Banco_datagridview, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 15500)
                            Case False
                                If Not IsDBNull(Banco_datagridview.SelectedRows(0).Cells.Item("Monto en Libro").Value) Then
                                    Dim Diferencia As Decimal = 0
                                    Diferencia = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Monto en Libro").Value, Decimal) -
                                        Math.Abs(CType(Banco_datagridview.SelectedRows(0).Cells.Item("importe").Value, Decimal))
                                    ToolTip1.BackColor = Color.Gold
                                    Select Case Diferencia = 0
                                        Case True
                                            ToolTip1.BackColor = Color.LightGreen
                                            ToolTip1.Show(String.Format("Monto Asociado Correcto", e.ColumnIndex, e.RowIndex), Banco_datagridview, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 1500)
                                        Case False
                                            'If Diferencia > 0 Then
                                            '    ToolTip1.Show("Diferencia:" & vbCrLf & String.Format(Diferencia.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR"))), e.ColumnIndex, e.RowIndex), Banco_datagridview, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 15500)
                                            'Else
                                            '    ToolTip1.Show("Diferencia:" & vbCrLf & String.Format(Diferencia.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR"))), e.ColumnIndex, e.RowIndex), Banco_datagridview, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 15500)
                                            'End If
                                    End Select
                                    Banco_datagridview.ShowCellToolTips = False
                                End If
                                '/Calculo y visualización de tooltip-----------------------------------------------------
                        End Select
                    End If
                Case False
            End Select
        End If
    End Sub

    Private Sub Quitarasociacion_boton_Click(sender As Object, e As EventArgs) Handles Quitarasociacion_boton.Click
        For X = 0 To Movimientos_asociados_datagridview.SelectedRows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5_Relacionado", DBNull.Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Movimientos_asociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente_detalle").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE `Expediente_detalle` SET MD5_Relacionado=@MD5_Relacionado WHERE Clave_expediente_detalle=@Clave_expediente_detalle;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_rendicion", MovimientosNOrendidos_datagridview.SelectedRows(X).Cells.Item("Clave_expediente_detalle").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidodefondo", "")
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", MovimientosNOrendidos_datagridview.SelectedRows(X).Cells.Item("Monto").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Mes_rendido", Mes_datepicker.SelectedItem.ToString)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nrotransaccion", MovimientosNOrendidos_datagridview.SelectedRows(X).Cells.Item("Nrotransferencia").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO rendiciones (Clave_rendicion,Clave_pedidofondo,Monto,Mes_rendido,Nrotransaccion) " &
            '    " VALUES (@Clave_rendicion,@Clave_pedidodefondo,@Monto,@Mes_rendido,@Nrotransaccion) " &
            '    " ON DUPLICATE KEY UPDATE Clave_rendicion=@Clave_rendicion,Clave_pedidofondo=@Clave_pedidodefondo,Monto=@Monto,Mes_rendido=@Mes_rendido,Nrotransaccion=@Nrotransaccion"
            'Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        refreshServicioAdministrativo()
        refreshSugerencia()
    End Sub

    Private Sub AsociarMovimiento_boton_Click(sender As Object, e As EventArgs) Handles AsociarMovimiento_boton.Click
        'Clave_expediente_detalle
        For X = 0 To Sugerencias_datagridview.SelectedRows.Count - 1
            Asociarmovimiento_sub(Banco_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Value.ToString.Replace("-", ""), Sugerencias_datagridview.SelectedRows(X).Cells.Item("Clave_expediente_detalle").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5_Relacionado", Banco_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Value.ToString.Replace("-", ""))
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Sugerencias_datagridview.SelectedRows(X).Cells.Item("Clave_expediente_detalle").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE `Expediente_detalle` SET MD5_Relacionado=@MD5_Relacionado WHERE Clave_expediente_detalle=@Clave_expediente_detalle;"
            'Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        refreshServicioAdministrativo()
        refreshSugerencia()
    End Sub

    Private Sub Asociarmovimiento_sub(ByVal MD5_relacionado As String, ByVal clave_expediente_detalle As Int64)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5_Relacionado", MD5_relacionado.ToString.Replace("-", ""))
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", clave_expediente_detalle)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE `Expediente_detalle` SET MD5_Relacionado=@MD5_Relacionado WHERE Clave_expediente_detalle=@Clave_expediente_detalle;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Private Sub DesAsociarmovimiento_sub(ByVal MD5_relacionado As String, ByVal clave_expediente_detalle As Int64)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5_Relacionado", MD5_relacionado.ToString.Replace("-", ""))
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", clave_expediente_detalle)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE `Expediente_detalle` SET MD5_Relacionado=@MD5_Relacionado WHERE Clave_expediente_detalle=@Clave_expediente_detalle;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Private Sub Suegerencias_tabcontrol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Sugerencias_tabcontrol.SelectedIndexChanged
        Select Case Banco_datagridview.SelectedRows.Count > 0
            Case True
                Dim tabPageItem As TabPage = Sugerencias_tabcontrol.SelectedTab
                Select Case tabPageItem.Controls.Contains(Sugerencias_datagridview)
                    Case True
                    Case False
                        Sugerencias_datagridview.Parent = tabPageItem
                End Select
                refreshSugerencia()
            Case False
        End Select
    End Sub

    Private Sub Desdesugerencia_datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles Desdesugerencia_datetimepicker.ValueChanged
        cambiandofecha = True
        refreshSugerencia()
        cambiandofecha = False
    End Sub

    Private Sub Hastasugerencia_datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles Hastasugerencia_datetimepicker.ValueChanged
        cambiandofecha = True
        refreshSugerencia()
        cambiandofecha = False
    End Sub

    Private Sub Controlesbancarios_tab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Controlesbancarios_tab.SelectedIndexChanged
        Dim tabPageItem As TabPage = Controlesbancarios_tab.SelectedTab
        Select Case tabPageItem.Controls.Contains(Sugerencias_datagridview)
            Case True
            Case False
                Banco_datagridview.Parent = tabPageItem
                Banco_datagridview.CurrentCell = Nothing
        End Select
        If Verificadordecarga Then
            Cargarefreshbanco()
        End If
    End Sub

    Private Sub Banco_datagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
    End Sub

    Private Sub Banco_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Banco_datagridview.MouseUp
        Mousederecho_conciliacion(sender, e, CType(sender, DataGridView))
    End Sub

    Private Sub Sugerencias_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Sugerencias_datagridview.MouseUp
        Mousederecho_conciliacionmovimiento(sender, e, CType(sender, DataGridView))
    End Sub

    Private Sub ServicioAdministrativo_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Movimientos_asociados_datagridview.MouseUp
        Mousederecho_conciliacionmovimiento(sender, e, CType(sender, DataGridView))
    End Sub

    Private Sub Busquedasugerenciastextbox_TextChanged(sender As Object, e As EventArgs) Handles Busquedasugerenciastextbox.TextChanged
        ''  DispatcherTimer setup
        'Tiempodetecleo.Stop()
        'Busquedasugerenciastextbox.BackColor = Color.Yellow
        'AddHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'Tiempodetecleo.Interval = TimeSpan.FromMilliseconds(500)
        '' = New TimeSpan(0, 0, 1)
        'Inicio.OBJETOCARGANDO(Sugerencias_datagridview, Me, "Sugerencias!")
        'Tiempodetecleo.Start()
        'Inicio.OBJETOFINALIZAR(Sugerencias_datagridview, Me)
        Buscar_datagrid_TIMER(sender, Sugerencias_datatable, Sugerencias_datagridview)
    End Sub

    Private Sub Banco_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Banco_datagridview.DataError
    End Sub

    Private Sub Controlesbancarios_tab_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Controlesbancarios_tab.DrawItem
        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = Controlesbancarios_tab.TabPages(e.Index)
        tp.BackColor = Color.PaleGreen
        tp.ForeColor = Color.Black
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)
        sf.Alignment = StringAlignment.Center
        Dim strTitle As String = tp.Text
        'If the current index is the Selected Index, change the color
        If Controlesbancarios_tab.SelectedIndex = e.Index Then
            'this is the background color of the tabpage
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.BackColor)
            'this is the background color of the tab page
            g.FillRectangle(br, e.Bounds)
            'this is the background color of the tab page
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.ForeColor)
            g.DrawString(strTitle, Controlesbancarios_tab.Font, br, r, sf)
        Else
            'these are the standard colors for the unselected tab pages
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, Controlesbancarios_tab.Font, br, r, sf)
        End If
    End Sub

    Private Sub Sugerencias_tabcontrol_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Sugerencias_tabcontrol.DrawItem
        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = Sugerencias_tabcontrol.TabPages(e.Index)
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)
        sf.Alignment = StringAlignment.Center
        Dim strTitle As String = tp.Text
        'If the current index is the Selected Index, change the color
        If Sugerencias_tabcontrol.SelectedIndex = e.Index Then
            'this is the background color of the tabpage
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.BackColor)
            'this is the background color of the tab page
            g.FillRectangle(br, e.Bounds)
            'this is the background color of the tab page
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.ForeColor)
            g.DrawString(strTitle, Sugerencias_tabcontrol.Font, br, r, sf)
        Else
            'these are the standard colors for the unselected tab pages
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, Sugerencias_tabcontrol.Font, br, r, sf)
        End If
    End Sub

    Private Sub Banco_datagridview_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Banco_datagridview.ColumnHeaderMouseClick
        Click_ordenar_columna_Datagridview(sender, e, "Importe", "Importe")
        'Select Case Banco_datagridview.Columns(e.ColumnIndex).Name.ToUpper
        '    Case = "Importe"
        '        Banco_datagridview.Columns(nombredecolumna(Banco_datagridview, "Importe")).SortMode = DataGridViewColumnSortMode.NotSortable
        '        If Banco_datagridview.SortOrder = SortOrder.Ascending Then
        '            Banco_datagridview.Sort(Banco_datagridview.Columns(nombredecolumna(Banco_datagridview, "Importe")), System.ComponentModel.ListSortDirection.Descending)
        '        Else
        '            Banco_datagridview.Sort(Banco_datagridview.Columns(nombredecolumna(Banco_datagridview, "Importe")), System.ComponentModel.ListSortDirection.Ascending)
        '        End If
        '    Case Else
        'End Select
    End Sub

    Private Sub BancoTOTALES_datagridvieW_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles BancoTOTALES_datagridvieW.DataError
    End Sub

    Private Sub Sugerencias_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Sugerencias_datagridview.CellEnter
        sumadatagridview(CType(sender, DataGridView), e, False)
    End Sub

    Private Sub ServicioAdministrativo_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Movimientos_asociados_datagridview.CellEnter
        sumadatagridview(CType(sender, DataGridView), e, True)
    End Sub

    'Suma de los valores seleccionados en libro------------------------------------'los valores correspondientes a sumas y restas de los movimientos de libro--------------------------------------
    Private Sub sumadatagridview(ByVal Sender As DataGridView, ByVal e As DataGridViewCellEventArgs, ByVal Asociado As Boolean)
        Dim Sumatotal As Decimal = 0
        Dim SUMADO As Decimal = 0
        Dim Diferencia As Decimal = CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal)
        Dim cell = Sender.CurrentCell
        Dim cellDisplayRect = Sender.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
        'Suma total del monto asociado hasta el momento
        If Not Asociado Then
            If Movimientos_asociados_datagridview.Rows.Count > 0 Then
                For X = 0 To Movimientos_asociados_datagridview.Rows.Count - 1
                    SUMADO = SUMADO + CType(Movimientos_asociados_datagridview.Rows(X).Cells.Item("MONTO").Value, Decimal)
                Next
            End If
        Else
            SUMADO = 0
        End If
        Select Case Sender.SelectedRows.Count > 0
            Case True
                For x = 0 To Sender.SelectedRows.Count - 1
                    Sumatotal = Sumatotal + CType(Sender.SelectedRows(x).Cells.Item("MONTO").Value, Decimal)
                Next
                Diferencia = Sumatotal - (Math.Abs(Diferencia) - (SUMADO))
                Select Case Diferencia
                    Case Is > 0
                        With ToolTip1
                            .BackColor = Color.LightYellow
                            .Show(String.Format(Sumatotal.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR"))) & vbCrLf & "difiere por:" & Diferencia.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR"))), e.ColumnIndex, e.RowIndex), Sender, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 2000)
                        End With
                    Case Is = 0
                        With ToolTip1
                            .BackColor = Color.LightGreen
                            .Show(String.Format(Sumatotal.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR"))), e.ColumnIndex, e.RowIndex), Sender, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 5000)
                        End With
                    Case Is < 0
                        With ToolTip1
                            .BackColor = Color.LightCoral
                            .Show(String.Format(Sumatotal.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR"))) & vbCrLf & "difiere por:" & Diferencia.ToString("C", (CultureInfo.CreateSpecificCulture("es-AR"))), e.ColumnIndex, e.RowIndex), Sender, cellDisplayRect.X + cell.Size.Width / 2, cellDisplayRect.Y + cell.Size.Height / 2, 5000)
                        End With
                End Select
                Sender.ShowCellToolTips = False
            Case False
                '   ToolTip1.Hide()
        End Select
    End Sub

    'Suma de los valores seleccionados en libro--------------------------------------------------------------------------
    Private Sub Banco_datagridview_KeyDown(sender As Object, e As KeyEventArgs) Handles Banco_datagridview.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F12
                If Sugerencias_datagridview.Rows.Count = 1 Then
                    Asociarmovimiento_sub(Banco_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Value.ToString.Replace("-", ""), Sugerencias_datagridview.Rows(0).Cells.Item("Clave_expediente_detalle").Value)
                    refreshSugerencia()
                End If
            Case Is = Keys.F11
                If Sugerencias_datagridview.Rows.Count > 0 Then
                    Sugerencias_datagridview.SelectAll()
                    AsociarMovimiento_boton.PerformClick()
                    ' refreshSugerencia()
                End If
            Case Is = Keys.F10
                Select Case Autorizaciones.Usuario.Rows(0).Item("nivel")
                    Case < 11
                        Banco_datagridview.ShowCellToolTips = False
                        Select Case MsgBox("Esto va a buscar todas las opciones correspondientes al número de transacción y asignarlas al movimiento bancario en cuestión", MsgBoxStyle.YesNoCancel, " ")
                            Case MsgBoxResult.Yes
                                Dim SPLITGENERAL As Integer = Flicker_Split_General.Panel1.Height
                                Dim SPLITDETALLE As Integer = SplitContainer2.Panel1.Width
                                ' Movimientos_asociados_datagridview.SuspendLayout()
                                Flicker_Split_General.SplitterDistance = 300
                                SplitContainer2.SplitterDistance = SplitContainer2.Width / 2 - 20
                                Inicio.OBJETOCARGANDO(Flicker_Split_panel1.Panel1, Me, "CONCILIANDO")
                                CONCILIACIONAUTOMATICASUB()
                                Inicio.OBJETOFINALIZAR(Flicker_Split_General.Panel1, Me)
                                'Sugerencias_tabcontrol.CreateControl()
                                Flicker_Split_General.SplitterDistance = SPLITGENERAL
                                SplitContainer2.SplitterDistance = SPLITDETALLE
                                TareaConciliar = Nothing
                                '  Movimientos_asociados_datagridview.ResumeLayout()
                               ' Sugerencias_datagridview.ResumeLayout()
                            Case MsgBoxResult.Cancel
                            Case MsgBoxResult.No
                                MsgBox("Cancelado")
                        End Select
                    Case Else
                        MsgBox("Actualmente no está autorizado para realizar esta acción")
                End Select
        End Select
    End Sub

    Private Sub Sugerencias_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Sugerencias_datagridview.DataError
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
    End Sub

    Private Sub Sugerencias_datagridview_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Sugerencias_datagridview.RowPrePaint
        If Modoautomatico = False Then
            If Banco_datagridview.SelectedRows.Count > 0 Then
                '  en caso de que la fecha sea la más próxima al movimiento
                Select Case CType(Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("FECHADELMOVIMIENTO").Value, Date) = Fechamascercana(0)
                    Case True
                        Colorcelda(Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("FECHADELMOVIMIENTO"), Color.LightGreen)
                    Case False
                End Select
                'en caso de que el número de transferencia coincida con el seleccionado en banco
                Select Case (Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("Nrotransferencia").Value.ToString = Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value.ToString)
                    Case True
                        Colorcelda(Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("Nrotransferencia"), Color.LightGreen)
                    Case False
                End Select
                'Asistencia para MFyV y su codificación
                If Banco_datagridview.SelectedRows(0).Cells.Item("importe").Value > 0 Then
                    If (Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV").Value.ToString.Contains("93")) Or (Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV").Value.ToString.Contains("23")) Then
                        Colorcelda(Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LightGreen)
                    Else
                        Colorcelda(Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LightSlateGray)
                    End If
                Else
                    'inverso de una imputacion 3
                    If (Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV").Value.ToString.Contains("93")) Or (Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV").Value.ToString.Contains("23")) Then
                        Colorcelda(Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LightSlateGray)
                    Else
                        Colorcelda(Sugerencias_datagridview.Rows(e.RowIndex).Cells.Item("MFyV"), Color.LightGreen)
                    End If
                End If
            End If
        End If
        '
    End Sub

    Private Sub Busquedabancaria_TextChanged(sender As Object, e As EventArgs) Handles Busquedabancaria.TextChanged
        Buscar_datagrid_TIMER(sender, Banco_datos_datatable, Banco_datagridview)
        refreshSugerencia()
        ''  DispatcherTimer setup
        'Busquedabancaria.BackColor = Color.Yellow
        'Tiempodetecleobancario.Stop()
        'AddHandler Tiempodetecleobancario.Tick, AddressOf Tiempodetecleobancario_Tick
        'Tiempodetecleobancario.Interval = TimeSpan.FromMilliseconds(700)
        '' = New TimeSpan(0, 0, 1)
        'Inicio.OBJETOCARGANDO(Banco_datagridview, Me, "BANCO!")
        'Tiempodetecleobancario.Start()
        'Inicio.OBJETOFINALIZAR(Banco_datagridview, Me)
    End Sub

    Private Sub Conciliacion_Bancaria_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        Me.SuspendLayout()
    End Sub

    Private Sub Conciliacion_Bancaria_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Me.ResumeLayout()
    End Sub

    Private Sub Conciliacion_automatica_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Conciliacion_automatica.DoWork
        CONCILIACIONAUTOMATICASUB()
    End Sub

    Private Sub Conciliacion_automatica_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Conciliacion_automatica.RunWorkerCompleted
        Me.Enabled = True
    End Sub

    Private Sub ConciliacionAutomatica_NroTransferencia(ByRef Totaldemovimientosasociados As Double, ByRef Totaldefilas As Integer)
        '    Inicio.OBJETOCARGANDO(Flicker_Split_panel1, Me, "Cargando, por favor Espere")
        Banco_datagridview.SuspendLayout()
        RefreshBanco("NROTRANSFERENCIA")
        '   Inicio.OBJETOFINALIZAR(Flicker_Split_panel1, Me)
        '---------Sección de Conciliación automatica basado unicamente en el número de transacción
        For x = 0 To Banco_datagridview.Rows.Count - 1
            Banco_datagridview.CurrentCell = Nothing
            'Control si el movimiento a evaluar es una comsión bancaria, con lo cual lo saltea en caso de serlo
            'If Not Banco_datagridview.Rows(x).Cells.Item("DESCRIPCION").Value.ToString.Contains("COMISION TRANSFERENCIAS") Then
            Banco_datagridview.Rows(x).Selected = True
            'If x + 1 Mod 2 = 0 Then
            'End If
            ' Banco_datagridview.Refresh()
            refreshSugerencia()
            'Sugerencias_datagridview.Refresh()
            Banco_datagridview.FirstDisplayedScrollingRowIndex = Banco_datagridview.SelectedRows(0).Index
            If Sugerencias_datagridview.Rows.Count > 0 Then
                Totaldemovimientosasociados = Totaldemovimientosasociados + Sugerencias_datagridview.Rows.Count
                Sugerencias_datagridview.SelectAll()
                AsociarMovimiento_boton.PerformClick()
                Totaldefilas = Totaldefilas + 1
            End If
            'End If
        Next
    End Sub

    Private Sub ConciliacionAutomatica_montos(ByRef Totaldemovimientosasociados As Double, ByRef Totaldefilas As Integer)
        If Banco_datagridview.Rows.Count > 0 Then
            If CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal) <> 0 Then
                '---------Sección de Conciliación automatica basado en el monto de un único movimiento del libro coincidente con el reporte bancario
                ' Banco_datagridview.SuspendLayout()
                'HACER DOS VECES LA PARTE CONCILIATORIA DE MONTOS----------------------------------------------------
                For s = 1 To 2
                    ' Inicio.OBJETOCARGANDO(Flicker_Split_panel1, Me, "Cargando, por favor Espere")
                    RefreshBanco("")
                    ' Inicio.OBJETOFINALIZAR(Flicker_Split_panel1, Me)
                    ' Controlesbancarios_tab.SelectedIndex = Controlesbancarios_tab.TabPages.Item("Bancosinconciliar_tab").TabIndex
                    Banco_datagridview.CurrentCell = Nothing
                    For z = 0 To Banco_datagridview.Rows.Count - 1
                        Banco_datagridview.CurrentCell = Nothing
                        Banco_datagridview.Rows(z).Selected = True
                        Banco_datagridview.FirstDisplayedScrollingRowIndex = Banco_datagridview.SelectedRows(0).Index
                        'Banco_datagridview.Refresh()
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date).AddMonths(-1))
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date).AddMonths(1))
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
                        Select Case CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal) > 0
                            Case True
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@monto", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
                            Case False
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@monto", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value * -1, Decimal))
                        End Select
                        ' Montos_tabsub()
                        refreshSugerencia()
                        Sugerencias_datagridview.DataSource = Sugerencias_datatable
                        Sugerencias_datagridview.Columns("Monto").DefaultCellStyle.Format = "C"
                        'refreshSugerencia()
                        If Sugerencias_datagridview.Rows.Count = 1 Then
                            Sugerencias_datagridview.SelectAll()
                            Totaldemovimientosasociados = Totaldemovimientosasociados + Sugerencias_datagridview.SelectedRows.Count
                            Totaldefilas = Totaldefilas + 1
                            AsociarMovimiento_boton.PerformClick()
                        Else
                            If Sugerencias_datagridview.Rows.Count > 0 Then
                                SUMA_TEMPORAL = 0
                                For DIFERENCIAS = 0 To Sugerencias_datagridview.Rows.Count - 1
                                    SUMA_TEMPORAL += Sugerencias_datagridview.Rows(DIFERENCIAS).Cells.Item("MONTO").Value
                                Next
                                If SUMA_TEMPORAL = Math.Abs(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value) Then
                                    Sugerencias_datagridview.SelectAll()
                                    Totaldemovimientosasociados = Totaldemovimientosasociados + Sugerencias_datagridview.SelectedRows.Count
                                    Totaldefilas = Totaldefilas + 1
                                    AsociarMovimiento_boton.PerformClick()
                                End If
                            End If
                        End If
                    Next
                Next
                '/---------Sección de Conciliación automatica basado en el monto de un único movimiento del libro coincidente con el reporte bancario
            End If
        End If
    End Sub

    Private Sub ConciliacionAutomatica_Diferencia(ByRef Totaldemovimientosasociados As Double, ByRef Totaldefilas As Integer)
        If Banco_datagridview.Rows.Count > 0 Then
            '  If CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal) <> 0 Then
            '---------Sección de Conciliación automatica basado en el monto de un único movimiento del libro coincidente con el reporte bancario
            ' Banco_datagridview.SuspendLayout()
            'HACER DOS VECES LA PARTE CONCILIATORIA DE MONTOS----------------------------------------------------
            ' Inicio.OBJETOCARGANDO(Flicker_Split_panel1, Me, "Cargando, por favor Espere")
            RefreshBanco("")
            ' Inicio.OBJETOFINALIZAR(Flicker_Split_panel1, Me)
            ' Controlesbancarios_tab.SelectedIndex = Controlesbancarios_tab.TabPages.Item("Bancosinconciliar_tab").TabIndex
            For z = 0 To Banco_datagridview.Rows.Count - 1
                Banco_datagridview.CurrentCell = Nothing
                Banco_datagridview.Rows(z).Selected = True
                Banco_datagridview.FirstDisplayedScrollingRowIndex = Banco_datagridview.SelectedRows(0).Index
                'Banco_datagridview.Refresh()
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", CType(Desdesugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date).AddMonths(-1))
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", CType(Hastasugerencia_datetimepicker.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture), Date).AddMonths(1))
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Banco_datagridview.SelectedRows(0).Cells.Item("Nro_Transaccion").Value)
                Select Case CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal) > 0
                    Case True
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@monto", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value, Decimal))
                    Case False
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@monto", CType(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value * -1, Decimal))
                End Select
                ' Montos_tabsub()
                refreshSugerencia()
                Sugerencias_datagridview.DataSource = Sugerencias_datatable
                Sugerencias_datagridview.Columns("Monto").DefaultCellStyle.Format = "C"
                'refreshSugerencia()
                If Sugerencias_datagridview.Rows.Count > 0 Then
                    'verifica que el movimiento sugerido no tenga mas de 60 mas o menos
                    If Sugerencias_datagridview.Rows.Count = 1 And Not (Math.Abs(DateDiff(DateInterval.Day, CType(Sugerencias_datatable.Rows(0).Item("FECHADELMOVIMIENTO"), Date), CType(Banco_datagridview.SelectedRows(0).Cells.Item("FECHA").Value, Date))) > 60) Then
                        Sugerencias_datagridview.SelectAll()
                        Totaldemovimientosasociados = Totaldemovimientosasociados + Sugerencias_datagridview.SelectedRows.Count
                        Totaldefilas = Totaldefilas + 1
                        AsociarMovimiento_boton.PerformClick()
                    Else
                        'SUMA_TEMPORAL = 0
                        'For DIFERENCIAS = 0 To Sugerencias_datagridview.Rows.Count - 1
                        '    SUMA_TEMPORAL += Sugerencias_datagridview.Rows(DIFERENCIAS).Cells.Item("MONTO").Value
                        'Next
                        'If SUMA_TEMPORAL = Math.Abs(Banco_datagridview.SelectedRows(0).Cells.Item("Importe").Value) Then
                        '    Sugerencias_datagridview.SelectAll()
                        '    Totaldemovimientosasociados = Totaldemovimientosasociados + Sugerencias_datagridview.SelectedRows.Count
                        '    Totaldefilas = Totaldefilas + 1
                        '    AsociarMovimiento_boton.PerformClick()
                        'End If
                    End If
                End If
            Next
            '/---------Sección de Conciliación automatica basado en el monto de un único movimiento del libro coincidente con el reporte bancario
        End If
        'End If
    End Sub

    Private Sub CONCILIACIONAUTOMATICASUB()
        Dim Totaldefilas As Integer = 0
        Dim Totaldemovimientosasociados As Double = 0
        Dim SUMA_TEMPORAL As Decimal = 0
        Banco_datagridview.MultiSelect = False
        Modoautomatico = True
        Sugerencias_tabcontrol.SelectedIndex = Sugerencias_tabcontrol.TabPages.Item("Nrotransaccion_tab").TabIndex
        Sugerencias_tabcontrol.Refresh()
        Banco_datagridview.Columns("DESCRIPCION").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        ConciliacionAutomatica_NroTransferencia(Totaldemovimientosasociados, Totaldefilas)
        'Dim TareaConciliarNroTransferencia As Task = New Task(Sub() ConciliacionAutomatica_NroTransferencia(Totaldemovimientosasociados, Totaldefilas))
        ''      TareaConciliarNroTransferencia.ConfigureAwait(False)
        'TareaConciliarNroTransferencia.Start()
        'TareaConciliarNroTransferencia.Wait()
        '/---------Sección de Conciliación automatica basado unicamente en el número de transacción
        '  MsgBox("Comienza el analisis por monto individual")
        Sugerencias_tabcontrol.SelectedIndex = Sugerencias_tabcontrol.TabPages.Item("Montos_tab").TabIndex
        Sugerencias_tabcontrol.Refresh()
        ConciliacionAutomatica_montos(Totaldemovimientosasociados, Totaldefilas)
        'Dim TareaConciliarMontos As Task = New Task(Sub() ConciliacionAutomatica_montos(Totaldemovimientosasociados, Totaldefilas))
        ''      TareaConciliarMontos.ConfigureAwait(False)
        'TareaConciliarMontos.Start()
        'TareaConciliarMontos.Wait()
        'Sugerencias_tabcontrol.TabPages.Item().
        'Problemas con la seleccion del control por el nombre, se opta por el numero 6 diferencias
        Sugerencias_tabcontrol.SelectedIndex = 6
        'Sugerencias_tabcontrol.TabPages.Item(6).TabIndex
        Sugerencias_tabcontrol.Refresh()
        ConciliacionAutomatica_Diferencia(Totaldemovimientosasociados, Totaldefilas)
        MsgBox("Finalizado " & vbNewLine & Totaldefilas & " filas modificadas" & vbNewLine & Totaldemovimientosasociados & " Registros del Libro fueron asignados")
        Banco_datagridview.MultiSelect = True
        Modoautomatico = False
        Cargarefreshbanco()
    End Sub

    Private Sub Conciliacionautomatica_monto()
        Dim Totaldefilas As Integer = 0
        Dim Totaldemovimientosasociados As Double = 0
        Banco_datagridview.MultiSelect = False
        Modoautomatico = True
        Sugerencias_tabcontrol.SelectedIndex = Sugerencias_tabcontrol.TabPages.Item("Montos_tab").TabIndex
        For x = 0 To Banco_datagridview.Rows.Count - 1
            Banco_datagridview.CurrentCell = Nothing
            Banco_datagridview.Rows(x).Selected = True
            refreshSugerencia()
            If Sugerencias_datagridview.Rows.Count = 1 Then
                Totaldemovimientosasociados = Totaldemovimientosasociados + Sugerencias_datagridview.Rows.Count
                Sugerencias_datagridview.SelectAll()
                AsociarMovimiento_boton.PerformClick()
                Totaldefilas += 1
            End If
            '  Banco_datagridview.CurrentCell = Nothing
        Next
        Banco_datagridview.MultiSelect = True
        Modoautomatico = False
        MsgBox("Finalizado " & vbNewLine & Totaldefilas & " filas modificadas" & vbNewLine & Totaldemovimientosasociados & " Registros del Libro fueron asignados")
    End Sub

    Private Sub MFyV_Click(sender As Object, e As EventArgs) Handles MFyV.Click
        ' MessageBox.Show("nofunciona")
        Inicio.OBJETOCARGANDO(Flicker_Split_General, Me, "Cargando archivo de MFyV," & vbNewLine & " esto suele tardar...")
        'Dialogo_datos.mostrardatatablemfYV(Inicio.AbrirarchivoexcelMFyV(18, 1, Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString))
        'AbrirarchivoexcelMFyV_SAFI
        Dialogo_datos.mostrardatatablemfYV(Inicio.AbrirarchivoexcelMFyV_SAFI())
        ' Inicio.Abrirarchivoexcel(Banco_datagridview, 1, 1)
        Inicio.OBJETOFINALIZAR(Flicker_Split_General, Me)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        If Verificadordecarga Then
            Cargarefreshbanco()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tabla As DataTable = ARCHIVOS.csvToDatatable()
        tabla.Columns.Add("INDICEMD5")
        procesoTablabanco(tabla)
        ' Inicio.Abrirarchivoexcel2(Banco_datagridview, 1, 1, Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        Inicio.Insertarareportebanco(tabla, Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
    End Sub

    Private Sub procesoTablabanco(ByRef tabla As DataTable)
        Dim fecha As String()
        For Each row As DataRow In tabla.Rows
            fecha = Split(row.Item(0), " ")
            Select Case fecha(1).ToUpper
                Case Is = "ENE"
                    fecha(1) = "01"
                Case Is = "FEB"
                    fecha(1) = "02"
                Case Is = "MAR"
                    fecha(1) = "03"
                Case Is = "ABR"
                    fecha(1) = "04"
                Case Is = "MAY"
                    fecha(1) = "05"
                Case Is = "JUN"
                    fecha(1) = "06"
                Case Is = "JUL"
                    fecha(1) = "07"
                Case Is = "AGO"
                    fecha(1) = "08"
                Case Is = "SEP"
                    fecha(1) = "09"
                Case Is = "OCT"
                    fecha(1) = "10"
                Case Is = "NOV"
                    fecha(1) = "11"
                Case Is = "DIC"
                    fecha(1) = "12"
            End Select
            row.Item(0) = ($"{fecha(0)}/{fecha(1)}/{fecha(2)}")
            row.Item(7) = ($"{row.Item(0)}{row.Item(1)}{row.Item(2)}{row.Item(3)}{row.Item(4)}{row.Item(5)}{row.Item(6)}")
        Next
        'tabla.Columns.Item(0).DataType = System.Type.GetType("System.DateTime")
    End Sub

End Class