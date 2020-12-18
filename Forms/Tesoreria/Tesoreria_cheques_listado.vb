Public Class Tesoreria_cheques_listado
    Dim cargainicial As Boolean = True
    Dim CHEQUES_DATATABLE As New DataTable
    Dim CHEQUES_BANCO_DETALLE_DATATABLE As New DataTable
    Dim CHEQUES_SICyF_DETALLE_DATATABLE As New DataTable
    Dim CHEQUES_DETALLE_DATATABLE As New DataTable
    Dim CHEQUES_MFYV_DETALLE_DATATABLE As New DataTable
    Dim EXPEDIENTES_DATATABLE As New DataTable
    Dim datagridseleccionado As Object

    Private Sub EXPEDIENTES_DATAGRIDVIEW_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles EXPEDIENTES_DATAGRIDVIEW.CellEnter
        refresh_detallado_expedientes()
    End Sub

    Private Sub CHEQUES_DATAGRIDVIEW_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles CHEQUES_DATAGRIDVIEW.CellEnter
        Inicio.OBJETOCARGANDO(Panelsplit_general.Panel2, Me, "Actualizando, por Favor espere",, New Point(Panelsplit_general.SplitterDistance, 0))
        refresh_detallado()
        Inicio.OBJETOFINALIZAR(Panelsplit_general.Panel2, Me)
    End Sub

    Private Sub Busqueda_detallada_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_detallada_textbox.TextChanged
        If Not IsNothing(CHEQUES_DETALLE_DATATABLE) Then
            Buscar_datagrid_TIMER(sender, CHEQUES_DETALLE_DATATABLE, Detalle_Cheques_SICYF)
        End If
    End Sub

    Private Sub Tesoreria_cheques_listado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
        Cuentas_combobox.SelectedIndex = 0
    End Sub

    Private Sub Tesoreria_cheques_listado_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        refresh()
        refresh_detallado()
        cargainicial = False
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        Inicio.OBJETOCARGANDO(CHEQUES_DATAGRIDVIEW, Me, "CARGANDO")
        REFRESH_GENERAL()
        Busqueda_textbox.Text = ""
        Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
            Case "NUMTRANSF_TAB"
                refresh()
            Case "EXPEDIENTES_TAB"
                Expedientes_refresh()
        End Select
        Inicio.OBJETOFINALIZAR(CHEQUES_DATAGRIDVIEW, Me)
        CHEQUES_DATAGRIDVIEW.CurrentCell = Nothing
    End Sub

    Private Sub REFRESH_GENERAL()
        'PARTE DE CHEQUES
        CHEQUES_DATAGRIDVIEW.DataSource = Nothing
        'PARTE DE EXPEDIENTES
        EXPEDIENTES_DATAGRIDVIEW.DataSource = Nothing
        Detalle_Cheques_SICYF.DataSource = Nothing
        Detalle_Cheques_mfyv.DataSource = Nothing
        Detalle_Cheques_banco.DataSource = Nothing
    End Sub

    Private Sub Tesoreria_cheques_listado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode = Keys.F5
            Case True
                Busqueda_textbox.Text = ""
                Busqueda_detallada_textbox.Text = ""
                Inicio.OBJETOCARGANDO(Panelsplit_general, Me, "Actualizando, por Favor espere")
                Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
                    Case "NUMTRANSF_TAB"
                        refresh()
                    Case "EXPEDIENTES_TAB"
                        Expedientes_refresh()
                End Select
                Inicio.OBJETOFINALIZAR(Panelsplit_general, Me)
        End Select
    End Sub

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
            Case "NUMTRANSF_TAB"
                Buscar_datagrid_TIMER(sender, CHEQUES_DATATABLE, CHEQUES_DATAGRIDVIEW)
            Case "EXPEDIENTES_TAB"
                Buscar_datagrid_TIMER(sender, EXPEDIENTES_DATATABLE, EXPEDIENTES_DATAGRIDVIEW)
        End Select
    End Sub

    Private Sub refresh()
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_datetimepicker.Value)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_datetimepicker.Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("start_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Desde_datetimepicker.Value.Date
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("last_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Hasta_datetimepicker.Value.Date
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("primerdia", MySql.Data.MySqlClient.MySqlDbType.Date).Value = CType(Autorizaciones.Year & "-01-01", Date)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("acotado", MySql.Data.MySqlClient.MySqlDbType.String, 1).Value = CType(Modoconciliacion.Checked, Integer)
        CHEQUES_DATAGRIDVIEW.DataSource = Nothing
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_CHEQUES_LISTADO_GENERAL", CHEQUES_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'If Not Modoconciliacion.Checked Then
        '    Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_CHEQUES_LISTADO_ACOTADO", CHEQUES_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Else
        '    Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_CHEQUES_LISTADO_GENERAL", CHEQUES_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'End If
        ' TESORERIA_CHEQUES_LISTADO_v2
        'Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_CHEQUES_LISTADO_v2", CHEQUES_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'TESORERIA_CHEQUES_LISTADO_GENERAL
        '            CONSULTASQL = "SELECT *,
        'CASE WHEN CODINP='1,3' THEN 'IPS' else
        'CASE
        'when (`SICYF-MFYV`)=0  AND  (`BANCO-SICYF`)=0 AND (`BANCO - MFYV`)=0 then 'OK'
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)=0  AND  (`BANCO-SICYF`)<>0  AND (`BANCO - MFYV`)<>0 AND ABS(`INGRESOS BANCO`-`EGRESOS BANCO`)=0 then
        'CASE WHEN `MOV IGUALADOS EN BANCO`='0' THEN 'NO REGISTRADO EN BANCO'
        'ELSE
        'CASE WHEN CODINP='1,3' THEN 'IPS' ELSE
        ''CHEQUE NO COBRADO'
        'END
        'END
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)=0  AND  (`BANCO-SICYF`)<>0  AND (`BANCO - MFYV`)<>0 AND ABS(`INGRESOS BANCO`-`EGRESOS BANCO`)<>0 then
        ' 'DIFERENCIA CON BANCO'
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)<>0  AND  (`BANCO-SICYF`)=0 AND (`BANCO - MFYV`)<>0 then 'VERIFICAR MFYV'
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)<>0  AND  (`BANCO-SICYF`)<>0 AND (`BANCO - MFYV`)=0 then
        'CASE WHEN `MOV IGUALADOS EN BANCO`=movimientoS THEN 'VERIFICAR SICyF'
        'ELSE
        ''VERIFICAR SICyF'
        'END
        'ELSE
        'CASE WHEN CODINP='1,3' THEN 'IPS' ELSE
        ''VERIFICAR'
        'END
        'END
        'END
        'END
        'END
        'end
        'END as 'EVALUACION'
        'FROM
        '(SELECT *,((abs(egreso-ingreso))-ABS(`INGRESOS MFyV`-`EGRESOS MFyV`))AS 'SICYF-MFYV',
        '(ABS(`INGRESOS BANCO`-`EGRESOS BANCO`)-(abs(egreso-ingreso))) AS 'BANCO-SICYF',
        '(ABS(`INGRESOS BANCO`-`EGRESOS BANCO`) - ABS(`INGRESOS MFyV`-`EGRESOS MFyV`)) AS 'BANCO - MFYV' FROM (
        '        SELECT
        '        SICYF.NROTRANSFERENCIA,NROBANCO,CODINP,PROVEEDORES,
        '        INGRESO,EGRESO,RENDIDO,
        '        MOVIMIENTOS,`MOV IGUALADOS EN BANCO`,
        '        (CASE WHEN NOT ISNULL(INGRESOS)  THEN INGRESOS ELSE 0 END ) AS 'INGRESOS MFyV',
        '				  (CASE WHEN NOT ISNULL(EGRESOS)  THEN EGRESOS ELSE 0 END ) AS 'EGRESOS MFyV',
        '        CASE WHEN NOT ISNULL(BANCOMONTO2) THEN
        '				CASE WHEN (BANCOMONTO2>0) THEN ABS(BANCOMONTO2) ELSE 0 END 	ELSE
        '				CASE WHEN NOT ISNULL(BANCOMONTO) THEN
        '				CASE WHEN (BANCOMONTO>0) THEN ABS(BANCOMONTO) ELSE 0 END ELSE 0 END
        '				END AS 'INGRESOS BANCO',
        '				      CASE WHEN NOT ISNULL(BANCOMONTO2) THEN
        '				CASE WHEN (BANCOMONTO2<0) THEN ABS(BANCOMONTO2) ELSE 0 END 	ELSE
        '				CASE WHEN NOT ISNULL(BANCOMONTO) THEN
        '				CASE WHEN (BANCOMONTO<0) THEN ABS(BANCOMONTO) ELSE 0 END ELSE 0 END
        '				END AS 'EGRESOS BANCO',
        '				CASE WHEN (TIPO='IVA' OR TIPO ='SUSS' OR TIPO ='GANANCIAS' OR TIPO ='DGR') THEN CONCAT('RETENCIONES ', TIPO)  ELSE
        '				CASE WHEN (TIPO='TRANSFERENCIA DE FONDOS' OR TIPO ='Orden de Entrega'  ) THEN 'DEPOSITOS' ELSE
        '				CASE WHEN (TIPO='ORDEN DE PAGO' OR TIPO ='PAGO'  ) THEN 'PAGO' ELSE
        '				CASE WHEN (TIPO='ORDEN DE PAGO' OR TIPO ='PAGO'  ) THEN 'PAGO' ELSE
        '				TIPO
        '				END
        '				END
        '				END
        '				END AS
        '				TIPO, EXPEDIENTES,PF
        '        FROM
        '				/*SOLAMENTE EL NRO DE TRANSFERENCIA*/
        '				(SELECT NROTRANSFERENCIA,
        'CASE WHEN BANCO=NROTRANSFERENCIA THEN NROTRANSFERENCIA ELSE
        'BANCO END AS 'NROBANCO',GROUP_CONCAT(DISTINCT MOV_TIPO) AS 'TIPO'
        'FROM (
        'SELECT * FROM
        '((Select NROTRANSFERENCIA,MD5_RELACIONADO AS 'MD5',MOV_TIPO FROM EXPEDIENTE_DETALLE WHERE
        'FECHADELMOVIMIENTO BETWEEN @DESDE AND @HASTA AND
        '        (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '                (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta))
        '        OR (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE CUENTA_ESPECIAL=@CUENTA)))) SOLOSICYF
        '				 LEFT JOIN
        '				(
        'Select Nro_Transaccion AS 'BANCO',
        'CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END AS 'MD52' FROM reportebanco
        '        WHERE FECHA BETWEEN @DESDE AND @HASTA AND
        '         CUENTA = @Cuenta
        'group by nro_transaccion
        ')B
        '				ON SOLOSICYF.MD5=B.MD52)
        '				UNION ALL
        '				Select NROTRANSFERENCIA,'' AS 'MD5','' AS MOV_TIPO,'' AS 'BANCO', '' AS 'MD52' FROM mfyv WHERE
        '				CUENTA_N=@CUENTA AND fecha BETWEEN @DESDE AND @HASTA
        '				)UNIONBANCOSICYF
        '								GROUP BY NROTRANSFERENCIA
        '				ORDER BY NROTRANSFERENCIA DESC
        '								)SICYF
        '				/*DATOS DEL SICYF DENTRO DEL NRO DE TRANSFERENCIA*/
        '				LEFT JOIN
        '	        (
        '						SELECT *,
        '					SUM(INGRESOU) AS INGRESO,
        '					SUM(EGRESOU) AS EGRESO,
        '					SUM(RENDIDOU) AS RENDIDO,
        '					CAST(count(NROTRANSFERENCIA) AS CHAR)  as Movimientos,
        '					GROUP_CONCAT(distinct CODINPDESG) as 'CODINP',
        '					GROUP_CONCAT(distinct CUIT) as 'CUITS',
        '					GROUP_CONCAT(distinct PROVEEDOR, ' ') as 'PROVEEDORES',
        '						GROUP_CONCAT(distinct EXPEDIENTE, ' ') as 'EXPEDIENTES',
        '							GROUP_CONCAT(distinct PFS, ' ') as 'PF',
        '		 SUM(CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE 1 END )   AS 'MOV IGUALADOS EN BANCO'
        '					FROM
        '					(
        '					#Datos de los movimientos
        '					select *,CONCAT(Substring(detalle.clave_expediente From 5 for 4),'-',cast(Substring(detalle.clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(detalle.clave_expediente From 1 for 4)) as 'Expediente' from
        '					(
        '					Select NROTRANSFERENCIA,
        '					case when codinp=1 then (Monto) else 0 end as EgresoU,
        '					case when codinp=3 then (Monto) else 0 end as  IngresoU,
        '					case when codinp=2 then (Monto) else 0 end as  RendidoU,CODINP AS CODINPDESG,CUIT,
        '					MD5_RELACIONADO,SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) as clave_expediente
        '		FROM EXPEDIENTE_DETALLE
        '				WHERE Fechadelmovimiento BETWEEN @DESDE AND @HASTA AND
        '        (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '(SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta))
        'OR (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE CUENTA_ESPECIAL=@CUENTA))))detalle
        'left join
        '(select clave_expediente AS CLAVE_EXPEDIENTE2,CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'PFS' from expediente )expediente
        'on
        'detalle.clave_expediente=expediente.CLAVE_EXPEDIENTE2
        ')TEMP1
        '			LEFT JOIN
        '				(SELECT PROVEEDOR,CUIT AS CUITPROV FROM PROVEEDORES)PROVEEDORES
        '				ON TEMP1.CUIT=PROVEEDORES.CUITPROV
        'GROUP BY NROTRANSFERENCIA
        '				)SICYF2
        '				ON SICYF.NROTRANSFERENCIA=SICYF2.NROTRANSFERENCIA
        '        /*DATOS DE MFYV*/
        '        LEFT JOIN
        '        (SELECT Nrotransferencia,SUM(INGRESOS)AS INGRESOS,SUM(EGRESOS) AS EGRESOS FROM MFYV WHERE CUENTA_N=@CUENTA GROUP BY Nrotransferencia)MFYV
        '        ON
        '        SICYF.Nrotransferencia=MFYV.Nrotransferencia
        '        /*DATOS DE BANCO*/
        '        LEFT JOIN
        '        (SELECT Nro_Transaccion,SUM(Importe) AS 'BANCOMONTO' FROM reportebanco WHERE CUENTA=@CUENTA GROUP BY Nro_Transaccion)BANCO
        '        ON
        '        SICYF.Nrotransferencia=BANCO.Nro_Transaccion
        '				 LEFT JOIN
        '        (SELECT Nro_Transaccion,SUM(Importe) AS 'BANCOMONTO2' FROM reportebanco WHERE CUENTA=@CUENTA GROUP BY Nro_Transaccion)BANCO2
        '        ON
        '        SICYF.nrobanco=BANCO2.Nro_Transaccion
        '				)HG)BG"
        '  Else
        'TESORERIA_CHEQUES_LISTADO_ACOTADO
        '            CONSULTASQL = "
        '       SELECT *,
        'CASE WHEN CODINP='1,3' THEN 'IPS' else
        'CASE
        'when (`SICYF-MFYV`)=0  AND  (`BANCO-SICYF`)=0 AND (`BANCO - MFYV`)=0 then 'OK'
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)=0  AND  (`BANCO-SICYF`)<>0  AND (`BANCO - MFYV`)<>0 AND ABS(`INGRESOS BANCO`-`EGRESOS BANCO`)=0 then
        'CASE WHEN `MOV IGUALADOS EN BANCO`='0' THEN 'NO REGISTRADO EN BANCO'
        'ELSE
        'CASE WHEN CODINP='1,3' THEN 'IPS' ELSE
        ''CHEQUE NO COBRADO'
        'END
        'END
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)=0  AND  (`BANCO-SICYF`)<>0  AND (`BANCO - MFYV`)<>0 AND ABS(`INGRESOS BANCO`-`EGRESOS BANCO`)<>0 then
        ' 'DIFERENCIA CON BANCO'
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)<>0  AND  (`BANCO-SICYF`)=0 AND (`BANCO - MFYV`)<>0 then 'VERIFICAR MFYV'
        'ELSE
        'CASE when
        '(`SICYF-MFYV`)<>0  AND  (`BANCO-SICYF`)<>0 AND (`BANCO - MFYV`)=0 then
        'CASE WHEN `MOV IGUALADOS EN BANCO`=movimientoS THEN 'VERIFICAR SICyF'
        'ELSE
        ''VERIFICAR SICyF'
        'END
        'ELSE
        'CASE WHEN CODINP='1,3' THEN 'IPS' ELSE
        ''VERIFICAR'
        'END
        'END
        'END
        'END
        'END
        'end
        'END as 'EVALUACION'
        'FROM
        '(SELECT *,((abs(egreso-ingreso))-ABS(`INGRESOS MFyV`-`EGRESOS MFyV`))AS 'SICYF-MFYV',
        '(ABS(`INGRESOS BANCO`-`EGRESOS BANCO`)-(abs(egreso-ingreso))) AS 'BANCO-SICYF',
        '(ABS(`INGRESOS BANCO`-`EGRESOS BANCO`) - ABS(`INGRESOS MFyV`-`EGRESOS MFyV`)) AS 'BANCO - MFYV' FROM (
        '        SELECT
        '        SICYF.NROTRANSFERENCIA,NROBANCO,CODINP,PROVEEDORES,
        '        INGRESO,EGRESO,RENDIDO,
        '        MOVIMIENTOS,`MOV IGUALADOS EN BANCO`,
        '        (CASE WHEN NOT ISNULL(INGRESOS)  THEN INGRESOS ELSE 0 END ) AS 'INGRESOS MFyV',
        '				  (CASE WHEN NOT ISNULL(EGRESOS)  THEN EGRESOS ELSE 0 END ) AS 'EGRESOS MFyV',
        '        CASE WHEN NOT ISNULL(BANCOMONTO2) THEN
        '				CASE WHEN (BANCOMONTO2>0) THEN ABS(BANCOMONTO2) ELSE 0 END 	ELSE
        '				CASE WHEN NOT ISNULL(BANCOMONTO) THEN
        '				CASE WHEN (BANCOMONTO>0) THEN ABS(BANCOMONTO) ELSE 0 END ELSE 0 END
        '				END AS 'INGRESOS BANCO',
        '				      CASE WHEN NOT ISNULL(BANCOMONTO2) THEN
        '				CASE WHEN (BANCOMONTO2<0) THEN ABS(BANCOMONTO2) ELSE 0 END 	ELSE
        '				CASE WHEN NOT ISNULL(BANCOMONTO) THEN
        '				CASE WHEN (BANCOMONTO<0) THEN ABS(BANCOMONTO) ELSE 0 END ELSE 0 END
        '				END AS 'EGRESOS BANCO',
        '				CASE WHEN (TIPO='IVA' OR TIPO ='SUSS' OR TIPO ='GANANCIAS' OR TIPO ='DGR') THEN CONCAT('RETENCIONES ', TIPO)  ELSE
        '				CASE WHEN (TIPO='TRANSFERENCIA DE FONDOS' OR TIPO ='Orden de Entrega'  ) THEN 'DEPOSITOS' ELSE
        '				CASE WHEN (TIPO='ORDEN DE PAGO' OR TIPO ='PAGO'  ) THEN 'PAGO' ELSE
        '				CASE WHEN (TIPO='ORDEN DE PAGO' OR TIPO ='PAGO'  ) THEN 'PAGO' ELSE
        '				TIPO
        '				END
        '				END
        '				END
        '				END AS
        '				TIPO, EXPEDIENTES,PF
        '        FROM
        '				/*SOLAMENTE EL NRO DE TRANSFERENCIA*/
        '				(SELECT NROTRANSFERENCIA,
        'CASE WHEN BANCO=NROTRANSFERENCIA THEN NROTRANSFERENCIA ELSE
        'BANCO END AS 'NROBANCO',GROUP_CONCAT(DISTINCT MOV_TIPO) AS 'TIPO'
        'FROM (
        'SELECT * FROM
        '((Select NROTRANSFERENCIA,MD5_RELACIONADO AS 'MD5',MOV_TIPO FROM EXPEDIENTE_DETALLE WHERE
        'FECHADELMOVIMIENTO BETWEEN @DESDE AND @HASTA AND
        '        (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '                (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta))
        '        OR (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE CUENTA_ESPECIAL=@CUENTA)))) SOLOSICYF
        '				 LEFT JOIN
        '				(Select Nro_Transaccion AS 'BANCO',
        'CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END AS 'MD52' FROM reportebanco
        '        WHERE FECHA BETWEEN @DESDE AND @HASTA AND
        '         CUENTA = @Cuenta
        'group by nro_transaccion )B
        '				ON SOLOSICYF.MD5=B.MD52)
        '			  	UNION ALL
        '				Select NROTRANSFERENCIA,'' AS 'MD5','' AS MOV_TIPO,'' AS 'BANCO', '' AS 'MD52' FROM mfyv WHERE
        '				CUENTA_N=@CUENTA AND fecha BETWEEN @DESDE AND @HASTA
        '				)UNIONBANCOSICYF
        '								GROUP BY NROTRANSFERENCIA
        '				ORDER BY NROTRANSFERENCIA DESC
        '								)SICYF
        '				/*DATOS DEL SICYF DENTRO DEL NRO DE TRANSFERENCIA*/
        '				LEFT JOIN
        '	        (
        '						SELECT *,
        '					SUM(INGRESOU) AS INGRESO,
        '					SUM(EGRESOU) AS EGRESO,
        '					SUM(RENDIDOU) AS RENDIDO,
        '					CAST(count(NROTRANSFERENCIA) AS CHAR)  as Movimientos,
        '					GROUP_CONCAT(distinct CODINPDESG) as 'CODINP',
        '					GROUP_CONCAT(distinct CUIT) as 'CUITS',
        '					GROUP_CONCAT(distinct PROVEEDOR, ' ') as 'PROVEEDORES',
        '						GROUP_CONCAT(distinct EXPEDIENTE, ' ') as 'EXPEDIENTES',
        '							GROUP_CONCAT(distinct PFS, ' ') as 'PF',
        '		 SUM(CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE 1 END )   AS 'MOV IGUALADOS EN BANCO'
        '					FROM
        '					(
        '					#Datos de los movimientos
        '					select *,CONCAT(Substring(detalle.clave_expediente From 5 for 4),'-',cast(Substring(detalle.clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(detalle.clave_expediente From 1 for 4)) as 'Expediente' from
        '					(
        '					Select NROTRANSFERENCIA,
        '					case when codinp=1 then (Monto) else 0 end as EgresoU,
        '					case when codinp=3 then (Monto) else 0 end as  IngresoU,
        '					case when codinp=2 then (Monto) else 0 end as  RendidoU,CODINP AS CODINPDESG,CUIT,
        '					MD5_RELACIONADO,SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) as clave_expediente
        '		FROM EXPEDIENTE_DETALLE
        '				WHERE Fechadelmovimiento BETWEEN @DESDE AND @HASTA AND
        '        (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '(SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta))
        'OR (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE CUENTA_ESPECIAL=@CUENTA))))detalle
        'left join
        '(select clave_expediente AS CLAVE_EXPEDIENTE2,CONCAT (CONVERT((SUBSTRING(clave_pedidofondo FROM 9 FOR CHAR_LENGTH(clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(clave_pedidofondo FROM 1 FOR CHAR_LENGTH(clave_pedidofondo) - 9) )AS 'PFS' from expediente )expediente
        'on
        'detalle.clave_expediente=expediente.CLAVE_EXPEDIENTE2
        ')TEMP1
        '			LEFT JOIN
        '				(SELECT PROVEEDOR,CUIT AS CUITPROV FROM PROVEEDORES)PROVEEDORES
        '				ON TEMP1.CUIT=PROVEEDORES.CUITPROV
        'GROUP BY NROTRANSFERENCIA
        '				)SICYF2
        '				ON SICYF.NROTRANSFERENCIA=SICYF2.NROTRANSFERENCIA
        '        /*DATOS DE MFYV*/
        '        LEFT JOIN
        '        (SELECT Nrotransferencia,SUM(INGRESOS)AS INGRESOS,SUM(EGRESOS) AS EGRESOS FROM MFYV WHERE CUENTA_N=@CUENTA
        '				AND FECHA BETWEEN @DESDE AND @HASTA
        '				GROUP BY Nrotransferencia
        '				)MFYV
        '        ON
        '        SICYF.Nrotransferencia=MFYV.Nrotransferencia
        '        /*DATOS DE BANCO*/
        '        LEFT JOIN
        '        (SELECT Nro_Transaccion,SUM(Importe) AS 'BANCOMONTO' FROM reportebanco WHERE CUENTA=@CUENTA AND FECHA BETWEEN @DESDE AND @HASTA GROUP BY Nro_Transaccion)BANCO
        '        ON
        '        SICYF.Nrotransferencia=BANCO.Nro_Transaccion
        '				 LEFT JOIN
        '        (SELECT Nro_Transaccion,SUM(Importe) AS 'BANCOMONTO2' FROM reportebanco WHERE CUENTA=@CUENTA AND FECHA BETWEEN @DESDE AND @HASTA GROUP BY Nro_Transaccion)BANCO2
        '        ON
        '        SICYF.nrobanco=BANCO2.Nro_Transaccion
        '				)HG)BG"
        'End If
        'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, CONSULTASQL, CHEQUES_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        CHEQUES_DATAGRIDVIEW.DataSource = CHEQUES_DATATABLE
        Formatocolumnas(CHEQUES_DATAGRIDVIEW, CType(CHEQUES_DATAGRIDVIEW.DataSource, DataTable))
        ' FastAutoSizeColumns(CHEQUES_DATAGRIDVIEW)
        For X = 0 To CHEQUES_DATAGRIDVIEW.Rows.Count - 1
            pintarfila(X)
        Next
    End Sub

    Private Sub refresh_detallado()
        If CHEQUES_DATAGRIDVIEW.SelectedRows.Count > 0 Then
            detalle_SICyF()
            detalle_MFyV()
            detalle_banco()
        Else
            Detalle_Cheques_SICYF.DataSource = Nothing
            Detalle_Cheques_banco.DataSource = Nothing
        End If
    End Sub

    Private Sub refresh_detallado_expedientes()
        If EXPEDIENTES_DATAGRIDVIEW.SelectedRows.Count > 0 Then
            detalle_SICyF_expediente()
            detalle_MFyV_expedientes()
            ' detalle_banco()
            Detalle_Cheques_banco.DataSource = Nothing
        Else
            Detalle_Cheques_SICYF.DataSource = Nothing
            Detalle_Cheques_banco.DataSource = Nothing
        End If
    End Sub

    Private Sub Expedientes_refresh()
        COMMANDSQL.Parameters.Clear()
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@desde", Desde_datetimepicker.Value)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_datetimepicker.Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("start_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Desde_datetimepicker.Value.Date
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("last_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Hasta_datetimepicker.Value.Date
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("primerdia", MySql.Data.MySqlClient.MySqlDbType.Date).Value = CType(Autorizaciones.Year & "-01-01", Date)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("acotado", MySql.Data.MySqlClient.MySqlDbType.String, 1).Value = Math.Abs(CType(Modoconciliacion.Checked, Integer)).ToString
        EXPEDIENTES_DATAGRIDVIEW.DataSource = Nothing
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_CHEQUES_LISTADO_EXPEDIENTES", EXPEDIENTES_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '        If Not Modoconciliacion.Checked Then
        '            Inicio.SQLPARAMETROS(Organismotabla, "
        'Select expediente,
        'case when isnull(Monto) then 'VERIFICAR VERIFICAR' else dd.detalle end as 'Detalle',
        'sum(dd.ingresos) as Ingresos,
        'sum(dd.egresos) as Egresos,
        'sum(dd.Retenciones) as 'Retenciones pendientes de pago',
        'dd.clave_expediente,
        '(sum(dd.ingresos)- (sum(dd.egresos)+sum(dd.retenciones))) as diferencia,
        'sum(total_recibo) as total_recibo,case when isnull(Monto) then 0 else monto end as 'Total de expediente',
        '`Ped.Fondo`, Monto_pedidofondo AS 'Total Pedido de Fondo',
        'fyv.ingresos as 'Acumulado Ingresos FyV',
        'fyv.egresos as 'Acumulado Egresos FyV',
        'Case when isnull(fyv.ingresos) then (sum(dd.ingresos)) else (sum(dd.ingresos)-fyv.ingresos) end as 'Diferencia Ingresos',
        'Case when isnull(fyv.egresos) then (sum(dd.egresos)) else (sum(dd.egresos)-fyv.egresos) end as 'Diferencia Egresos'
        'FROM
        '(
        'select expediente,
        'CONCAT(cast(Substring(Exped.clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Exped.clave_pedidofondo From 1 for 4)) as 'Ped.Fondo',
        'Monto_pedidofondo,
        'exped.detalle,
        'INGRESOS,EGRESOS,RETENCIONES,
        'recibos.monto as total_recibo,
        'cuenta.descripcion,cuenta.cuenta,
        'SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13) as clave_expediente,exped.monto
        'FROM
        '(SELECT
        'CONCAT(Substring(clave_expedientE_Detalle From 5 for 4),'-',cast(Substring(clave_expedientE_Detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expedientE_Detalle From 1 for 4)) as Expediente,
        'clave_expediente_Detalle
        ' FROM
        '(select clave_expediente_Detalle from expediente_Detalle where (CodInp=1 or codinp=3) and date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
        ' )x
        'group by SUBSTRING(x.clave_expedientE_Detalle FROM 1 FOR 13)
        ' )AA
        'LeFT JOIN
        '(select clave_expedientE_Detalle,0 as ingresos,sum(monto) as egresos,0 as retenciones,codinp from expediente_Detalle where CodInp=1
        'group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
        'union ALL
        'select clave_expedientE_Detalle,sum(monto) as ingresos,0 as egresos,0 as retenciones,codinp from expediente_Detalle where CodInp=3
        'group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
        'union ALL
        'select clave_expedientE_Detalle,0 as ingresos,0 as egresos,sum(monto_retenido) as retenciones,1 as codinp from Retenciones where isnull(Retencion_Clave_detalle)
        'group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
        ')BB
        'ON SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=SUBSTRING(bb.clave_expedientE_Detalle FROM 1 FOR 13)
        '#DATOS DE LOS EXPEDIENTES
        'LEFT JOIN
        '(select * from expediente)Exped
        'on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=Exped.Clave_expediente
        '#EXPEDIENTES CON RECIBOS
        'LEFT JOIN
        '(select * from expediente_Detalle where not isnull(nro_recibo) and nro_recibo<>'')recibos
        'on recibos.clave_expedientE_Detalle=aa.clave_expedientE_Detalle
        '#PEDIDOS DE FONDO
        'LEFT JOIN
        '(select * from pedido_fondos)Pedfondo
        'on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
        '#CUENTA BANCARIA
        'LEFT JOIN
        '(select * From Cuenta_Bancaria)Cuenta
        'on Pedfondo.cuenta_pedidofondo=Cuenta.cuenta)dd
        '# UNION A IZQUIERDA CON FONDOS Y VALORES PARA MOSTRAR VALORES TOTALES
        'LEFT JOIN
        '(select clave_expediente,
        'sum(ingresos) as 'Ingresos',
        'sum(egresos) as 'Egresos' from mfyv group by clave_expediente)fyv
        'on fyv.clave_expediente=dd.Clave_expediente
        'where cuenta=@cuenta
        'group by clave_expediente
        'order by clave_expediente,descripcion
        '", EXPEDIENTES_DATATABLE, Reflection.MethodBase.GetCurrentMethod.Name)
        '        Else
        '            'MODO CONCILIACIÓN, SOLO DATOS DE LAS FECHAS SELECCIONADAS
        '            Inicio.SQLPARAMETROS(Organismotabla, "
        'Select expediente,
        'case when isnull(Monto) then 'VERIFICAR VERIFICAR' else dd.detalle end as 'Detalle',
        'sum(dd.ingresos) as Ingresos,
        'sum(dd.egresos) as Egresos,
        'sum(dd.Retenciones) as 'Retenciones pendientes de pago',
        'dd.clave_expediente,
        '(sum(dd.ingresos)- (sum(dd.egresos)+sum(dd.retenciones))) as diferencia,
        'sum(total_recibo) as total_recibo,case when isnull(Monto) then 0 else monto end as 'Total de expediente',
        '`Ped.Fondo`, Monto_pedidofondo AS 'Total Pedido de Fondo',
        'fyv.ingresos as 'Acumulado Ingresos FyV',
        'fyv.egresos as 'Acumulado Egresos FyV',
        'Case when isnull(fyv.ingresos) then (sum(dd.ingresos)) else (sum(dd.ingresos)-fyv.ingresos) end as 'Diferencia Ingresos',
        'Case when isnull(fyv.egresos) then (sum(dd.egresos)) else (sum(dd.egresos)-fyv.egresos) end as 'Diferencia Egresos'
        'FROM
        '(
        'select expediente,
        'CONCAT(cast(Substring(Exped.clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Exped.clave_pedidofondo From 1 for 4)) as 'Ped.Fondo',
        'Monto_pedidofondo,
        'exped.detalle,
        'INGRESOS,EGRESOS,RETENCIONES,
        'recibos.monto as total_recibo,
        'cuenta.descripcion,cuenta.cuenta,
        'SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13) as clave_expediente,exped.monto
        'FROM
        '(SELECT
        'CONCAT(Substring(clave_expedientE_Detalle From 5 for 4),'-',cast(Substring(clave_expedientE_Detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expedientE_Detalle From 1 for 4)) as Expediente,
        'clave_expediente_Detalle
        ' FROM
        '(select clave_expediente_Detalle from expediente_Detalle where (CodInp=1 or codinp=3) and date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
        ' )x
        'group by SUBSTRING(x.clave_expedientE_Detalle FROM 1 FOR 13)
        ' )AA
        'LeFT JOIN
        '(select clave_expedientE_Detalle,0 as ingresos,sum(monto) as egresos,0 as retenciones,codinp from expediente_Detalle where CodInp=1 and date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
        'group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
        'union ALL
        'select clave_expedientE_Detalle,sum(monto) as ingresos,0 as egresos,0 as retenciones,codinp from expediente_Detalle where CodInp=3 and date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
        'group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
        'union ALL
        'select clave_expedientE_Detalle,0 as ingresos,0 as egresos,sum(monto_retenido) as retenciones,1 as codinp from Retenciones where
        'date(FECHA_RETENCION) BETWEEN DATE(@DESDE) AND DATE(@HASTA)  AND
        '(ISNULL(Retencion_Clave_detalle) OR (
        'Retencion_Clave_detalle NOT IN (SELECT CLAVE_EXPEDIENTE_DETALLE FROM EXPEDIENTE_DETALLE WHERE date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA))))
        'group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
        ')BB
        'ON SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=SUBSTRING(bb.clave_expedientE_Detalle FROM 1 FOR 13)
        '#DATOS DE LOS EXPEDIENTES
        'LEFT JOIN
        '(select * from expediente)Exped
        'on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=Exped.Clave_expediente
        '#EXPEDIENTES CON RECIBOS
        'LEFT JOIN
        '(select * from expediente_Detalle where not isnull(nro_recibo) and nro_recibo<>'')recibos
        'on recibos.clave_expedientE_Detalle=aa.clave_expedientE_Detalle
        '#PEDIDOS DE FONDO
        'LEFT JOIN
        '(select * from pedido_fondos)Pedfondo
        'on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
        '#CUENTA BANCARIA
        'LEFT JOIN
        '(select * From Cuenta_Bancaria)Cuenta
        'on Pedfondo.cuenta_pedidofondo=Cuenta.cuenta)dd
        '# UNION A IZQUIERDA CON FONDOS Y VALORES PARA MOSTRAR VALORES TOTALES
        'LEFT JOIN
        '(select clave_expediente,
        'sum(ingresos) as 'Ingresos',
        'sum(egresos) as 'Egresos' from mfyv group by clave_expediente)fyv
        'on fyv.clave_expediente=dd.Clave_expediente
        'where cuenta=@cuenta
        'group by clave_expediente
        'order by clave_expediente,descripcion
        '", EXPEDIENTES_DATATABLE, Reflection.MethodBase.GetCurrentMethod.Name)
        '        End If
        EXPEDIENTES_DATAGRIDVIEW.DataSource = Nothing
        EXPEDIENTES_DATAGRIDVIEW.DataSource = EXPEDIENTES_DATATABLE
        Formatocolumnas(EXPEDIENTES_DATAGRIDVIEW, CType(EXPEDIENTES_DATAGRIDVIEW.DataSource, DataTable))
        FastAutoSizeColumns(EXPEDIENTES_DATAGRIDVIEW)
        For x = 0 To EXPEDIENTES_DATAGRIDVIEW.Rows.Count - 1
            pintarfila(x)
        Next
        'EXPEDIENTES_DATAGRIDVIEW.Columns("clave_expediente").Visible = False
        'EXPEDIENTES_DATAGRIDVIEW.Columns("INGRESOS").DefaultCellStyle.Format = "c"
        'EXPEDIENTES_DATAGRIDVIEW.Columns("EGRESOS").DefaultCellStyle.Format = "c"
        'EXPEDIENTES_DATAGRIDVIEW.Columns("Retenciones pendientes de pago").DefaultCellStyle.Format = "c"
        'EXPEDIENTES_DATAGRIDVIEW.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        'EXPEDIENTES_DATAGRIDVIEW.Columns("Total de expediente").DefaultCellStyle.Format = "c"
    End Sub

    Private Sub detalle_banco()
        Detalle_Cheques_banco.SuspendLayout()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@NROBANCO", CHEQUES_DATAGRIDVIEW.SelectedRows(0).Cells.Item("NROBANCO").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@NROTRANSFERENCIA", CHEQUES_DATAGRIDVIEW.SelectedRows(0).Cells.Item("NROTRANSFERENCIA").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
MD5HASH,Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,importe As 'Importe mov.',Format(Saldo,2, 'es_AR') as 'Saldo',
format(Libro_Asociado,2, 'es_AR') as Asociado_con_Libro,CASE WHEN ABS(Libro_Asociado) >0 THEN Libro_Asociado ELSE 0 END as 'Libro_Asociado',importe,
(CASE WHEN LIBRO_ASOCIADO-ABS(IMPORTE)=0 THEN 'OK' ELSE
    CASE WHEN ISNULL(LIBRO_ASOCIADO-ABS(IMPORTE))
        THEN 'SIN ASOCIAR' ELSE FORMAT(LIBRO_ASOCIADO-ABS(IMPORTE),2,'es_AR') END
END) as 'Diferencia'
FROM
(select
CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH'
,Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,SUM(IMPORTE) AS IMPORTE,SALDO as 'Saldo'
FROM reportebanco where CASE WHEN LENGTH(@NROBANCO)>0 THEN  Nro_Transaccion=@NROBANCO  ELSE  Nro_Transaccion=@NROTRANSFERENCIA  END and Cuenta=@cuenta
 group by nro_transaccion
)A
Left Join
(SELECT SUM(MONTO) AS 'Libro_Asociado',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)B
On A.MD5HASH=B.MD5_RELACIONADO
ORDER BY FECHA DESC,importe desc, NRO_TRANSACCION DESC", CHEQUES_BANCO_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Detalle_Cheques_banco.DataSource = CHEQUES_BANCO_DETALLE_DATATABLE
        Detalle_Cheques_banco.Columns("Importe mov.").DefaultCellStyle.Format = "C"
        Detalle_Cheques_banco.Columns("MD5HASH").Visible = False
        Detalle_Cheques_banco.Columns("Cuenta").Visible = False
        Detalle_Cheques_banco.Columns("Saldo").Visible = False
        Detalle_Cheques_banco.Columns("importe").Visible = False
        Detalle_Cheques_banco.CurrentCell = Nothing
    End Sub

    Private Sub detalle_MFyV()
        Detalle_Cheques_mfyv.SuspendLayout()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@NROTRANSFERENCIA", CHEQUES_DATAGRIDVIEW.SelectedRows(0).Cells.Item("NROTRANSFERENCIA").Value)
        Dim consulta As Integer = 0
        If Detalle_Cheques_SICYF.SelectedRows.Count > 0 Then
            Select Case SoloSeleccionadoSicyf_checkbox.Checked
                Case True
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Detalle_Cheques_SICYF.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value.ToString.Substring(0, 13))
                    consulta = 1
                Case False
                    consulta = 0
            End Select
        End If
        If consulta = 0 Then
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
CONCAT(Expediente_N,'/',Expediente_year) as 'Expediente_N',Detalle,(Ingresos+Egresos) as 'Monto',Fecha,Cod_orden,Cfdo,Codinp,Nrotransferencia,Clave_expediente,cUENTA_N
from MFyV where Nrotransferencia=@NROTRANSFERENCIA  and (not codinp=2)
order by (Ingresos+Egresos) desc ", CHEQUES_MFYV_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Else
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
CONCAT(Expediente_N,'/',Expediente_year) as 'Expediente_N',Detalle,(Ingresos+Egresos) as 'Monto',Fecha,Cod_orden,Cfdo,Codinp,Nrotransferencia,Clave_expediente,cUENTA_N
from MFyV where Nrotransferencia=@NROTRANSFERENCIA  and (not codinp=2) and clave_expediente = @clave_expediente
order by (Ingresos+Egresos) desc ", CHEQUES_MFYV_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Detalle_Cheques_mfyv.DataSource = CHEQUES_MFYV_DETALLE_DATATABLE
        'Columnas_decimales(Datos_MFyV)
        Detalle_Cheques_mfyv.Columns("Clave_expediente").Visible = False
        Detalle_Cheques_mfyv.CurrentCell = Nothing
        Detalle_Cheques_mfyv.DataSource = CHEQUES_MFYV_DETALLE_DATATABLE
        Detalle_Cheques_mfyv.Columns("Monto").DefaultCellStyle.Format = "C"
        Detalle_Cheques_mfyv.Columns("Clave_expediente").Visible = False
        Detalle_Cheques_mfyv.CurrentCell = Nothing
    End Sub

    Private Sub detalle_MFyV_expedientes()
        Detalle_Cheques_mfyv.SuspendLayout()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", EXPEDIENTES_DATAGRIDVIEW.SelectedRows(0).Cells.Item("clave_expediente").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        Dim consulta As Integer = 0
        If Detalle_Cheques_mfyv.SelectedRows.Count > 0 Then
            Select Case SoloseleccionadoMFyV_checkbox.Checked
                Case True
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Detalle_Cheques_mfyv.SelectedRows(0).Cells.Item("Nrotransferencia").Value & "%")
                    consulta = 1
                Case False
                    consulta = 0
            End Select
        End If
        If consulta = 0 Then
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
CONCAT(Expediente_N,'/',Expediente_year) as 'Expediente_N',Detalle,(Ingresos+Egresos) as 'Monto',Fecha,Cod_orden,Cfdo,Codinp,Nrotransferencia,Clave_expediente,cUENTA_N
from MFyV where   clave_expediente=@clave_expediente  and (not codinp=2)
order by (Ingresos+Egresos) desc ", CHEQUES_MFYV_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Else
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
CONCAT(Expediente_N,'/',Expediente_year) as 'Expediente_N',Detalle,(Ingresos+Egresos) as 'Monto',Fecha,Cod_orden,Cfdo,Codinp,Nrotransferencia,Clave_expediente,cUENTA_N
from MFyV where clave_expediente=@clave_expediente and  Nrotransferencia=@NROTRANSFERENCIA  and (not codinp=2)
order by (Ingresos+Egresos) desc ", CHEQUES_MFYV_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Detalle_Cheques_mfyv.DataSource = CHEQUES_MFYV_DETALLE_DATATABLE
        'Columnas_decimales(Datos_MFyV)
        Detalle_Cheques_mfyv.Columns("Clave_expediente").Visible = False
        Detalle_Cheques_mfyv.CurrentCell = Nothing
        Detalle_Cheques_mfyv.DataSource = CHEQUES_MFYV_DETALLE_DATATABLE
        Detalle_Cheques_mfyv.Columns("Monto").DefaultCellStyle.Format = "C"
        Detalle_Cheques_mfyv.Columns("Clave_expediente").Visible = False
        Detalle_Cheques_mfyv.CurrentCell = Nothing
    End Sub

    Private Sub detalle_SICyF()
        Detalle_Cheques_SICYF.SuspendLayout()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@NROTRANSFERENCIA", CHEQUES_DATAGRIDVIEW.SelectedRows(0).Cells.Item("NROTRANSFERENCIA").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        Dim consulta As Integer = 0
        If Detalle_Cheques_mfyv.SelectedRows.Count > 0 Then
            Select Case SoloseleccionadoMFyV_checkbox.Checked
                Case True
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Detalle_Cheques_mfyv.SelectedRows(0).Cells.Item("Clave_expediente").Value & "%")
                    consulta = 1
                Case False
                    consulta = 0
            End Select
        End If
        If consulta = 0 Then
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where NROTRANSFERENCIA=@NROTRANSFERENCIA )A)A1
  order by Monto desc  ", CHEQUES_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Else
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where NROTRANSFERENCIA=@NROTRANSFERENCIA  and Clave_expediente_detalle like  @clave_expediente  )A)A1
  order by Monto desc  ", CHEQUES_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Detalle_Cheques_SICYF.DataSource = CHEQUES_DETALLE_DATATABLE
        Detalle_Cheques_SICYF.Columns("Monto").DefaultCellStyle.Format = "C"
        Detalle_Cheques_SICYF.Columns("Clave_expediente_detalle").Visible = False
        Detalle_Cheques_SICYF.CurrentCell = Nothing
    End Sub

    Private Sub detalle_SICyF_expediente()
        Detalle_Cheques_SICYF.SuspendLayout()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", EXPEDIENTES_DATAGRIDVIEW.SelectedRows(0).Cells.Item("clave_expediente").Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        Dim consulta As Integer = 0
        If Detalle_Cheques_mfyv.SelectedRows.Count > 0 Then
            Select Case SoloseleccionadoMFyV_checkbox.Checked
                Case True
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Detalle_Cheques_mfyv.SelectedRows(0).Cells.Item("Nrotransferencia").Value & "%")
                    consulta = 1
                Case False
                    consulta = 0
            End Select
        End If
        If consulta = 0 Then
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)=@clave_expediente )A)A1
  order by Monto desc ", CHEQUES_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Else
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido,
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
from Expediente_detalle where
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)=@clave_expediente
and Nrotransferencia=@Nrotransferencia)A)A1
  order by Monto desc  ", CHEQUES_DETALLE_DATATABLE, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Detalle_Cheques_SICYF.DataSource = CHEQUES_DETALLE_DATATABLE
        Detalle_Cheques_SICYF.Columns("Monto").DefaultCellStyle.Format = "C"
        Detalle_Cheques_SICYF.Columns("Clave_expediente_detalle").Visible = False
        Detalle_Cheques_SICYF.CurrentCell = Nothing
    End Sub

    Private Sub Desde_movimientos_ValueChanged(sender As Object, e As EventArgs) Handles Desde_datetimepicker.ValueChanged
        REFRESH_GENERAL()
    End Sub

    Private Sub Hasta_datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles Hasta_datetimepicker.ValueChanged
        REFRESH_GENERAL()
    End Sub

    Private Sub CHEQUES_DATAGRIDVIEW_MouseUp(sender As Object, e As MouseEventArgs) Handles CHEQUES_DATAGRIDVIEW.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                MOUSEDERECHO_cheques(sender, e, sender)
        End Select
    End Sub

    Private Sub Detalle_Cheques_SICYF_MouseUp(sender As Object, e As MouseEventArgs) Handles Detalle_Cheques_SICYF.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub Detalle_Cheques_mfyv_MouseUp(sender As Object, e As MouseEventArgs) Handles Detalle_Cheques_mfyv.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub Detalle_Cheques_banco_MouseUp(sender As Object, e As MouseEventArgs) Handles Detalle_Cheques_banco.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub MOUSEDERECHO_cheques(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object)
        datagridseleccionado = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item0 = cms.Items.Add("Copiar")
        item0.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item0.Click, AddressOf Menucontextualcheques
        Dim item1 = cms.Items.Add("Exportar toda la tablar a Excel")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf Menucontextualcheques
        Dim item2 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item2.Tag = 2
        AddHandler item2.Click, AddressOf Menucontextualcheques
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item3.Tag = 3
        AddHandler item3.Click, AddressOf Menucontextualcheques
        'detalle del reporte
        Dim item4 = cms.Items.Add("Certificado sobre los cheques seleccionados")
        item4.Tag = 4
        AddHandler item4.Click, AddressOf Menucontextualcheques
        cms.Show(CONTROL, MOUSE.Location)
        ''detalle del reporte
        'Dim item5 = cms.Items.Add("Buscar Conciliación")
        'item5.Tag = 5
        'AddHandler item5.Click, AddressOf Menucontextualcheques
        'cms.Show(CONTROL, MOUSE.Location)
        'Dim item3 = cms.Items.Add("VERIFICAR ADICIONALES")
        'item3.Tag = 2
        'AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        '-- etc
        '..
    End Sub

    Private Sub Menucontextualcheques(ByVal sender As Object, ByVal e As EventArgs)
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
                '    Case Is = "SICYF.FLICKER_DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(datagridseleccionado.GetType.ToString)
                'End Select
            Case Is = 2
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
            Case Is = 3
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 4
                Dim movimiento_actual As New Movimiento
                Dim transferencias As New List(Of Double)
                For x = 0 To datagridseleccionado.selectedrows.count - 1
                    transferencias.Add(datagridseleccionado.selectedrows(x).cells.item("nrotransferencia").value)
                Next
                movimiento_actual.Generarcertificadopago(transferencias)
            Case Is = 5
            Case Is = 9
        End Select
        '-- etc
    End Sub

    Private Sub Agregacheques_button_Click(sender As Object, e As EventArgs) Handles Agregacheques_button.Click
        Mostrardialogo(Tesoreria_agregarcheques)
    End Sub

    Private Sub Todosloscheques_checkbox_CheckedChanged(sender As Object, e As EventArgs)
        REFRESH_GENERAL()
    End Sub

    Private Sub SoloSeleccionadoSicyf_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles SoloSeleccionadoSicyf_checkbox.CheckedChanged
        If SoloSeleccionadoSicyf_checkbox.Checked Then
            SoloseleccionadoMFyV_checkbox.Checked = False
        End If
        Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
            Case "NUMTRANSF_TAB"
                detalle_MFyV()
            Case "EXPEDIENTES_TAB"
                detalle_MFyV_expedientes()
        End Select
    End Sub

    Private Sub SoloseleccionadoMFyV_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles SoloseleccionadoMFyV_checkbox.CheckedChanged
        If SoloseleccionadoMFyV_checkbox.Checked Then
            SoloSeleccionadoSicyf_checkbox.Checked = False
        End If
        Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
            Case "NUMTRANSF_TAB"
                detalle_SICyF()
            Case "EXPEDIENTES_TAB"
                detalle_SICyF_expediente()
        End Select
    End Sub

    Private Sub Detalle_Cheques_SICYF_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Detalle_Cheques_SICYF.CellEnter
        If Detalle_Cheques_SICYF.SelectedRows.Count = 1 Then
            Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
                Case "NUMTRANSF_TAB"
                    detalle_MFyV()
                Case "EXPEDIENTES_TAB"
                    detalle_MFyV_expedientes()
            End Select
        End If
    End Sub

    Private Sub Detalle_Cheques_mfyv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Detalle_Cheques_mfyv.CellEnter
        If Detalle_Cheques_mfyv.SelectedRows.Count = 1 Then
            Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
                Case "NUMTRANSF_TAB"
                    detalle_SICyF()
                Case "EXPEDIENTES_TAB"
                    detalle_SICyF_expediente()
            End Select
        End If
    End Sub

    Private Sub Soloseleccionado_CheckedChanged(sender As Object, e As EventArgs) Handles Modoconciliacion.CheckedChanged
        If Modoconciliacion.Checked Then
            Me.Text = "Chequera Modo CONCILIACIÓN"
            '            Me.BackColor = Color.White
            Panelsplit_general.Panel1.BackColor = Color.Gold
            Panelsplit_general.Panel2.BackColor = Color.Gold
        Else
            Me.Text = "Chequera Modo NORMAL"
            Me.BackColor = Color.Gray
            Panelsplit_general.Panel1.BackColor = Color.White
            Panelsplit_general.Panel2.BackColor = Color.White
        End If
        REFRESH_GENERAL()
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        Dim temporal As String = ""
        temporal = Busqueda_textbox.Text
        Inicio.OBJETOCARGANDO(CHEQUES_DATAGRIDVIEW, Me, "CARGANDO")
        REFRESH_GENERAL()
        Busqueda_textbox.Text = ""
        Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
            Case "NUMTRANSF_TAB"
                refresh()
            Case "EXPEDIENTES_TAB"
                Expedientes_refresh()
        End Select
        Inicio.OBJETOFINALIZAR(CHEQUES_DATAGRIDVIEW, Me)
        CHEQUES_DATAGRIDVIEW.CurrentCell = Nothing
        ' CHEQUES_DATAGRIDVIEW.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Busqueda_textbox.Text = temporal
    End Sub

    Private Sub Detalle_Cheques_mfyv_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Detalle_Cheques_mfyv.RowPrePaint
        Select Case SoloSeleccionadoSicyf_checkbox.Checked
            Case True
                If Detalle_Cheques_mfyv.Rows.Count = 1 Then
                    If Detalle_Cheques_SICYF.SelectedRows.Count = 1 Then
                        If Detalle_Cheques_SICYF.SelectedRows(0).Cells.Item("monto").Value = Detalle_Cheques_mfyv.Rows(0).Cells.Item("monto").Value Then
                            Detalle_Cheques_mfyv.Rows(0).Cells.Item("monto").Style.BackColor = Color.LightGreen
                        Else
                            Detalle_Cheques_mfyv.Rows(0).Cells.Item("monto").Style.BackColor = Color.Yellow
                        End If
                    End If
                End If
            Case False
        End Select
    End Sub

    Private Sub Detalle_Cheques_SICYF_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Detalle_Cheques_SICYF.RowPrePaint
        Select Case SoloseleccionadoMFyV_checkbox.Checked
            Case True
                If Detalle_Cheques_SICYF.Rows.Count = 1 Then
                    If Detalle_Cheques_mfyv.SelectedRows.Count = 1 Then
                        If Detalle_Cheques_mfyv.SelectedRows(0).Cells.Item("monto").Value = Detalle_Cheques_SICYF.Rows(0).Cells.Item("monto").Value Then
                            Detalle_Cheques_SICYF.Rows(0).Cells.Item("monto").Style.BackColor = Color.LightGreen
                        Else
                            Detalle_Cheques_SICYF.Rows(0).Cells.Item("monto").Style.BackColor = Color.Yellow
                        End If
                    End If
                End If
            Case False
        End Select
    End Sub

    Private Sub CHEQUES_DATAGRIDVIEW_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles CHEQUES_DATAGRIDVIEW.DataError
    End Sub

    'Private Sub CHEQUES_DATAGRIDVIEW_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles CHEQUES_DATAGRIDVIEW.DataBindingComplete
    '    CHEQUES_DATAGRIDVIEW.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    '    'CHEQUES_DATAGRIDVIEW.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
    'End Sub
    Private Sub pintarfila(ByVal indice As Integer)
        Select Case TABCONTROLGENERAL.SelectedTab.Name.ToUpper
            Case "NUMTRANSF_TAB"
                If Not IsDBNull(CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("SICYF-MFYV").Value) Then
                    Select Case CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("SICYF-MFYV").Value
                        Case Is = "0"
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("SICYF-MFYV").Style.BackColor = Color.LightGreen
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("SICYF-MFYV").Style.ForeColor = Color.Black
                        Case Else
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("SICYF-MFYV").Style.BackColor = Color.LightYellow
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("SICYF-MFYV").Style.ForeColor = Color.Black
                    End Select
                End If
                If Not IsDBNull(CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO-SICYF").Value) Then
                    Select Case CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO-SICYF").Value
                        Case Is = "0"
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO-SICYF").Style.BackColor = Color.LightGreen
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO-SICYF").Style.ForeColor = Color.Black
                        Case Else
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO-SICYF").Style.BackColor = Color.LightYellow
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO-SICYF").Style.ForeColor = Color.Black
                    End Select
                End If
                If Not IsDBNull(CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO - MFYV").Value) Then
                    Select Case CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO - MFYV").Value
                        Case Is = "0"
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO - MFYV").Style.BackColor = Color.LightGreen
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO - MFYV").Style.ForeColor = Color.Black
                        Case Else
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO - MFYV").Style.BackColor = Color.LightYellow
                            CHEQUES_DATAGRIDVIEW.Rows(indice).Cells.Item("BANCO - MFYV").Style.ForeColor = Color.Black
                    End Select
                End If
            Case "EXPEDIENTES_TAB"
                If EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("DIFERENCIA").Value = 0 Then
                    Colorceldaok1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("INGRESOS"))
                    Colorceldaok1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EGRESOS"))
                    Colorceldaok1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Retenciones pendientes de pago"))
                    Colorceldaok1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("DIFERENCIA"))
                    Colorceldaok2(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Total de expediente"))
                    If EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Total de expediente").Value = EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("INGRESOS").Value Then
                        Colorceldaok3(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EXPEDIENTE"))
                    Else
                        Colorceldaok1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EXPEDIENTE"))
                        Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Total de expediente"), Color.LightYellow)
                    End If
                ElseIf EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("DIFERENCIA").Value > 0 Then
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("INGRESOS"), Color.White)
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EGRESOS"), Color.Yellow)
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Retenciones pendientes de pago"), Color.White)
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("DIFERENCIA"), Color.Yellow)
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EXPEDIENTE"), Color.Yellow)
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Total de expediente"), Color.Yellow)
                ElseIf EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("DIFERENCIA").Value < 0 Then
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("INGRESOS"), Color.White)
                    Colorceldano1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EGRESOS"))
                    Colorceldano1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Retenciones pendientes de pago"))
                    Colorceldano1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("DIFERENCIA"))
                    Colorceldano1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EXPEDIENTE"))
                    Colorceldano1(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Total de expediente"))
                Else
                End If
                If EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("Total de expediente").Value < 1 Then
                    Colorcelda(EXPEDIENTES_DATAGRIDVIEW.Rows(indice).Cells.Item("EXPEDIENTE"), Color.DarkRed)
                End If
        End Select
        'End If
    End Sub

    Private Sub EXPEDIENTES_DATAGRIDVIEW_MouseUp(sender As Object, e As MouseEventArgs) Handles EXPEDIENTES_DATAGRIDVIEW.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

End Class