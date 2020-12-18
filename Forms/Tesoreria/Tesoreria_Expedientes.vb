Public Class Tesoreria_Expedientes
    Dim Expedientes_datatable As New DataTable
    Dim Tablatemporalexptespedidofondo As New DataTable
    Dim Tablatemporalpartida As New DataTable
    Dim tablatemporalexpedientesrelacionados_hijos As New DataTable
    Dim Tablatemporalpedidofondo As New DataTable
    Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    Dim activartimer As Boolean = False
    Dim Tiempoconsulta As New Windows.Threading.DispatcherTimer()
    Dim Datagridseleccionado As DataGridView
    Dim expediente_seleccionado As New Expediente
    Dim expediente_existente As New Expediente

    'public sub MOUSE DERECHO, sujeto a mejoras
    Private Sub MOUSEDERECHO(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object)
        Datagridseleccionado = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        Datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf Menucontextual_expedientes
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf Menucontextual_expedientes
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf Menucontextual_expedientes
        Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf Menucontextual_expedientes
        If Datagridseleccionado.SelectedRows.Count > 0 Then
            Dim item5 = cms.Items.Add("Nuevo Expediente")
            item5.Tag = 4
            AddHandler item5.Click, AddressOf Menucontextual_expedientes
            Dim item6 = cms.Items.Add("Modificar Expediente seleccionado")
            item6.Tag = 5
            AddHandler item6.Click, AddressOf Menucontextual_expedientes
        End If
        'Dim item3 = cms.Items.Add("VERIFICAR ADICIONALES")
        'item3.Tag = 2
        'AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        'If (My.Computer.Name.ToUpper = "MERONETBOOK") Or (My.Computer.Name.ToUpper = "MEROSUPERPC") Then
        '    Dim item10 = cms.Items.Add("PDF EXPERIMENTAL")
        '    item10.Tag = 10
        '    AddHandler item10.Click, AddressOf Menucontextual_expedientes
        'End If
        '-- etc
        '..
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub Menucontextual_expedientes(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Clipboard.SetDataObject(Datagridseleccionado.GetClipboardContent())
                Dim objData As DataObject = Datagridseleccionado.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(Datagridseleccionado)
                'Select Case Datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(Datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(Datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(Datagridseleccionado.GetType.ToString)
                'End Select
                'MessageBox.Show(datagridseleccionado.GetType.ToString)
                'Select Case
                '    Case Is = "Datagridview"
                '        Exportaraexceltest(datagridseleccionado)
                'End Select
            Case Is = 2
                'Reportesgenerales.ExportDataToPDFTable2(datagridseleccionado, "Reporte Rapido")
                'Reportesgenerales.PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
                'PDFDatagridview()
            Case Is = 3
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 4
                Nuevo()
            Case Is = 5
                Modificar()
                'EXPERIMENTAL DEBE SER CORREGIDO
                'PDFPEDIDODEFONDO(CType(datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
        End Select
        '-- etc
    End Sub

    '/public sub MOUSE DERECHO
    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(Busqueda_textbox, Expedientes_datatable, Listado_)
        'Busqueda_textbox.BackColor = Color.Yellow
        ''  DispatcherTimer setup
        'activartimer = True
        'RemoveHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'AddHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'Tiempodetecleo.Interval = TimeSpan.FromMilliseconds(300)
        '' = New TimeSpan(0, 0, 1)
        'Tiempodetecleo.Start()
    End Sub

    Private Sub Tiempodetecleo_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case activartimer
            Case True
                Busqueda_textbox.Enabled = False
                Inicio.OBJETOCARGANDO(Listado_, Me, "Buscando...")
                refreshgeneral()
                Inicio.OBJETOFINALIZAR(Listado_, Me)
                'freno de mano al timer
                Tiempodetecleo.Stop()
                Busqueda_textbox.Enabled = True
                Busqueda_textbox.BackColor = Color.White
                Busqueda_textbox.Select()
                activartimer = False
            Case False
        End Select
    End Sub

    Private Sub Consulta_tick(ByVal sender As Object, ByVal e As EventArgs)
        'iniciar busqueda de datos
        If Listado_.SelectedRows.Count = 1 Then
            Paneldatosexpedientes.Visible = True
            Datos_expediente_Tabcontrol.Visible = True
            Cargadedatos()
        Else
            Paneldatosexpedientes.Visible = False
            Datos_expediente_Tabcontrol.Visible = False
        End If
        'mostrar en pantalla
        'apagar timer
        'freno de mano al timer
        Tiempoconsulta.Stop()
    End Sub

    Private Sub DataGridView1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Listado_.MouseWheel
        DataGridView_MouseWheel(sender, e)
    End Sub

    Private Sub Tesoreria_Expedientes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        refreshgeneral()
    End Sub

    Public Sub refreshgeneral()
        Dim consultasql As String = ""
        Dim BUSQUEDATEXT As String = Busqueda_textbox.Text
        Dim resultado As Decimal = 0
        Busqueda_textbox.Text = ""
        Select Case Busqueda_textbox.TextLength > 0
            Case True
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@busqueda", "%" & Busqueda_textbox.Text & "%")
                Select Case Decimal.TryParse(Busqueda_textbox.Text, resultado)
                    Case True
                        'se crea la busqueda precisa para habilitar la busqueda de expedientes por monto.
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@busquedaprecisa", resultado)
                        consultasql = " WHERE (detalle like @busqueda) OR ('Expediente N' like @busqueda) OR (Clave_expediente like @busqueda) OR (monto=@busquedaprecisa)  "
                    Case False
                        'en caso de que se busque unicamente por texto
                        consultasql = " WHERE detalle like @busqueda or 'Expediente N' like @busqueda OR (Clave_expediente like @busqueda) "
                End Select
            Case False
                consultasql = ""
        End Select
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "select CLAVE_TO_EXPEDIENTE(CLAVE_EXPEDIENTE) as 'Expediente N',
	Fecha,
	Detalle,
	Monto,
	Clave_pedidofondo,
	Clave_expediente,ClaveExpteprincipal,
	Ordenpago,
	OrdenCargo,
	case when isnull(Clave_pedidofondo) then Pedido_fondo2 else CONCAT(cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) end as 'Pedido Fondo N',
Cuenta_especial,CASE WHEN HABERES>0 THEN 'SUELDO' ELSE '' END AS 'HABERES' from
(
SELECT
	*
FROM
	Expediente  order by Clave_pedidofondo IS NULL desc,Clave_pedidofondo desc, FECHA desc)expediente
	left join
	(select clave_expediente as clave_expediente_cuit,GROUP_CONCAT(DISTINCT cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) as 'Pedido_fondo2' from cuit_movimiento where not isnull(clave_pedidofondo) group by clave_expediente)cuit_movimiento
	on expediente.Clave_expediente=cuit_movimiento.clave_expediente_cuit
	order by actualizacion desc ",
                             Expedientes_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Listado_.DataSource = Expedientes_datatable
        'Datos_datagrid.Columns("MONTO").DefaultCellStyle.Format = "C"
        Listado_.Columns("Claveexpteprincipal").Visible = False
        Listado_.Columns("clave_pedidofondo").Visible = False
        'Datos_datagrid.Columns("Clave_expediente").Visible = False
        Listado_.Columns("Clave_expediente").Visible = False
        Listado_.Columns("Cuenta_especial").Visible = False
        With Listado_
            .Columns("Expediente N").DefaultCellStyle.Font = New Font(Listado_.DefaultCellStyle.Font.Name, Listado_.DefaultCellStyle.Font.Size + 2, FontStyle.Bold)
            .Columns("Expediente N").DefaultCellStyle.BackColor = Color.White
            .Columns("Expediente N").DefaultCellStyle.ForeColor = Color.FromArgb(100, 254, 79, 16)
            '.Columns("O.Prov.").DefaultCellStyle.BackColor = Color.White
            '.Columns("O.Prov.").DefaultCellStyle.ForeColor = Color.Blue
            'Pedido Fondo N
            .Columns("Pedido Fondo N").DefaultCellStyle.Font = New Font(Listado_.DefaultCellStyle.Font.Name, Listado_.DefaultCellStyle.Font.Size + 2, FontStyle.Bold)
            .Columns("Pedido Fondo N").DefaultCellStyle.BackColor = Color.White
            .Columns("Pedido Fondo N").DefaultCellStyle.ForeColor = Color.Green
        End With
        Formatocolumnas(Listado_, Expedientes_datatable)
        Listado_.Columns("Expediente N").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Listado_.CurrentCell = Nothing
        Busqueda_textbox.Text = BUSQUEDATEXT
    End Sub

    Private Sub pintarfila(ByVal indice As Integer)
        Select Case Not IsDBNull(Listado_.Rows(indice).Cells.Item("clave_pedidofondo").Value)
            Case True
                '      Datos_datagrid.Rows(INDICE).DefaultCellStyle.BackColor = Color.LightGreen
                Listado_.Rows(indice).Cells.Item("Pedido Fondo N").Style.BackColor = Color.LightGreen
                Listado_.Rows(indice).Cells.Item("detalle").Style.BackColor = Color.LightGreen
            Case Else
                ' Datos_datagrid.Rows(INDICE).DefaultCellStyle.SelectionForeColor = Color.light
        End Select
        If Listado_.Rows(indice).Cells.Item("Cuenta_Especial").Value.ToString.Length > 0 Then
            Listado_.Rows(indice).Cells.Item("Pedido Fondo N").Style.BackColor = Color.White
            Listado_.Rows(indice).Cells.Item("detalle").Style.BackColor = Color.LightSkyBlue
        End If
        'Select Case Not IsDBNull(Datos_datagrid.Rows(INDICE).Cells.Item("Clave_expediente_p").Value)
        '    Case True
        '        Datos_datagrid.Rows(INDICE).DefaultCellStyle.BackColor = Color.LightBlue
        '        Datos_datagrid.Rows(INDICE).DefaultCellStyle.SelectionForeColor = Color.Maroon
        'End Select
        Select Case Not IsDBNull(Listado_.Rows(indice).Cells.Item("Monto").Value)
            Case True
                Select Case CType(Listado_.Rows(indice).Cells.Item("Monto").Value, Decimal)
                    Case Is = 0
                        Colorcelda(Listado_.Rows(indice).Cells.Item("Monto"), Color.LightCoral)
                        Colorcelda(Listado_.Rows(indice).Cells.Item("Expediente N"), Color.LightCoral)
                    Case Is > 0
                        Colorcelda(Listado_.Rows(indice).Cells.Item("Monto"), Color.LightGreen)
                    Case Else
                        Colorcelda(Listado_.Rows(indice).Cells.Item("Monto"), Color.Red)
                        Colorcelda(Listado_.Rows(indice).Cells.Item("Expediente N"), Color.Red)
                End Select
                'If CType(Datos_datagrid.Rows(INDICE).Cells.Item("Monto").Value.ToString.Replace(",", ""), Decimal) > 0 Then
                '    'Datos_datagrid.Rows(INDICE).DefaultCellStyle.BackColor = Color.LightBlue
                '    '                    Datos_datagrid.Rows(INDICE).DefaultCellStyle.SelectionForeColor = Color.Maroon
                'Else
                '    Datos_datagrid.Rows(INDICE).Cells.Item("Monto").Style.BackColor = Color.LightGoldenrodYellow
                'End If
        End Select
        If Listado_.Rows(indice).Cells.Item("Claveexpteprincipal").Value.ToString.Length > 2 Then
            Colorcelda(Listado_.Rows(indice).Cells.Item("Expediente N"), Color.PaleTurquoise)
        End If
        If Listado_.Rows(indice).Cells.Item("haberes").Value.ToString.Length > 0 Then
            Colorcelda(Listado_.Rows(indice).Cells.Item("haberes"), Color.Lavender)
        End If
    End Sub

    Private Function Textoainteger(ByRef texto As String, ByRef valorminimo As Integer) As Integer
        If Not IsNothing(texto) Then
            If texto.Length > 0 Then
                Select Case IsNumeric(texto)
                    Case True
                        Try
                            Return CType(texto, Integer)
                        Catch ex As Exception
                            Return valorminimo
                        End Try
                    Case False
                        Return valorminimo
                End Select
            Else
                Return valorminimo
            End If
        Else
            Return valorminimo
        End If
    End Function

    Private Sub Cargadedatos()
        Datos_expediente_Tabcontrol.Visible = True
        Dim Informacion_General As New List(Of String)
        Dim ExpedientePrincipal As Claveexpediente_separar
        Dim ExpedientePrincipal_String As String = ""
        Dim TotalEjecutadoExptePrincipal As Decimal = 0
        Dim TablaTemporalPedidofondo As New DataTable
        Dim TablaTemporalExpedientesRelacionados_Principal As New DataTable
        Dim TablaTemporalExpedientesRelacionados_Hijos As New DataTable
        Dim ordenentabcontrol As Integer = 0
        Pedidofondo_tabitem.Visible = False
        Datosexpedientesasociados_datagrid.DataSource = Nothing
        Datospedidofondo_datagrid.DataSource = Nothing
        expediente_seleccionado.clear()
        expediente_seleccionado.claveexpediente = Listado_.SelectedRows(0).Cells.Item("clave_expediente").Value.ToString
        expediente_seleccionado.Desglose_clave()
        'Inicio.Expedientesdividir(Datos_datagrid.SelectedRows(0).Cells.Item("Expediente N").Value.ToString, expediente_seleccionado.organismo, expediente_seleccionado.numero, expediente_seleccionado.year)
        '----------------------------------------------------------------------------------------------------------------
        Select Case Listado_.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString.Length > 0
            Case True
                If Not Listado_.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString.StartsWith("/") Then
                    Try
                        Inicio.divisoruniversal(Listado_.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString, expediente_seleccionado.ordenpago, expediente_seleccionado.ordenpagoyear)
                    Catch ex As Exception
                        expediente_seleccionado.ordenpago = 0
                        expediente_seleccionado.ordenpagoyear = 0
                    End Try
                Else
                    expediente_seleccionado.ordenpago = 0
                    expediente_seleccionado.ordenpagoyear = 0
                End If
            Case False
        End Select
        '----------------------------------------------------------------------------------------------------------------
        Select Case Listado_.SelectedRows(0).Cells.Item("Ordencargo").Value.ToString.Length > 0
            Case True
                Inicio.divisoruniversal(Listado_.SelectedRows(0).Cells.Item("Ordencargo").Value.ToString, expediente_seleccionado.ordencargo, expediente_seleccionado.ordencargoyear)
            Case False
        End Select
        '----------------------------------------------------------------------------------------------------------------
        Select Case Listado_.SelectedRows(0).Cells.Item("Fecha").Value.ToString.Length > 0
            Case True
                expediente_seleccionado.fecha = Convert.ToDateTime(Listado_.SelectedRows(0).Cells.Item("Fecha").Value.ToString).Date
            Case Else
                expediente_seleccionado.fecha = Date.Now
        End Select
        '----------------------------------------------------------------------------------------------------------------
        expediente_seleccionado.principalclaveexpediente = Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString
        'Inicio.Divisordecodigo(Datos_datagrid.SelectedRows(0).Cells.Item("Claveexpteprincipal").Value.ToString, expediente_seleccionado.principalorganismo, expediente_seleccionado.principalnumero, expediente_seleccionado.principalyear)
        expediente_seleccionado.Desglose_clave_principal()
        With expediente_seleccionado
            .descripcion = Listado_.SelectedRows(0).Cells.Item("Detalle").Value.ToString
        End With
        Expediente_seleccionado_label.Text = expediente_seleccionado.organismo & "-" & expediente_seleccionado.numero & "/" & expediente_seleccionado.year
        Ordenpago_seleccionado_label.Text = expediente_seleccionado.ordenpago & "/" & expediente_seleccionado.ordenpagoyear
        Ordencargo_seleccionado_label.Text = expediente_seleccionado.ordencargo & "/" & expediente_seleccionado.ordencargoyear
        Detalleexpediente_textbox.Text = expediente_seleccionado.descripcion
        If expediente_seleccionado.principalclaveexpediente.Length > 7 Then
            Expediente_principal_label.Text = "Expte Principal: " & expediente_seleccionado.principalorganismo & "-" & expediente_seleccionado.principalnumero & "/" & expediente_seleccionado.principalyear
        Else
            Expediente_principal_label.Text = ""
        End If
        Montodelexpediente_textbox.Text = CType(Listado_.SelectedRows(0).Cells.Item("Monto").Value, Decimal).ToString("C")
        If Listado_.SelectedRows(0).Cells.Item("clave_pedidofondo").Value.ToString.Length > 8 Then
            Dim sumadelexpediente As Decimal = 0
            'Datos de los expedientes asociados al pedido de fondo en el que se encuentra el expediente seleccionado
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", Listado_.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString)
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, " Select 0 AS 'N',
CONCAT(Substring(clave_expediente From 5 for 4),'-',
cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',
Substring(clave_expediente From 1 for 4)) as 'Expediente N',Detalle,Monto,
Fecha,Ordenpago,Clave_expediente from Expediente where clave_pedidofondo=@clave_pedidofondo " &
                                 " order by clave_expediente desc,fecha desc", Tablatemporalexptespedidofondo, System.Reflection.MethodBase.GetCurrentMethod.Name)
            For x = 0 To Tablatemporalexptespedidofondo.Rows.Count - 1
                Tablatemporalexptespedidofondo.Rows(x).Item("N") = x + 1
                sumadelexpediente += CType(Tablatemporalexptespedidofondo.Rows(x).Item("MONTO"), Decimal)
            Next
            Labeltotalpedidofondo.Text = "TOTAL Pdo de Fondo " & sumadelexpediente.ToString("C")
            Datospedidofondo_datagrid.DataSource = Tablatemporalexptespedidofondo
            Datospedidofondo_datagrid.Columns("MONTO").DefaultCellStyle.Format = "C"
            Datospedidofondo_datagrid.Columns("Clave_expediente").Visible = False
            'datos del pedido de fondo per se
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", Listado_.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString)
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select * from (Select N_pedidofondo,Year_pedidofondo,FORMAT(Monto_pedidofondo,2, 'es_AR') AS Monto_pedidofondo,N_ordenpago,Year_ordenpago,Cuenta_pedidofondo,Expediente_N,Descripcion,Fecha_pedido,Clase_fondo,Impreso,Clave_pedidofondo from Pedido_fondos where clave_pedidofondo=@clave_pedidofondo)A
LEFT JOIN
(select Descripcion as nombre_cuenta,cuenta From Cuenta_Bancaria)B
on a.Cuenta_pedidofondo=b.cuenta   ", TablaTemporalPedidofondo, System.Reflection.MethodBase.GetCurrentMethod.Name)
            ' Datospedidofondo_datagrid.datasource = Tablatemporalexptespedidofondo.DefaultView
            Select Case TablaTemporalPedidofondo.Rows.Count
                Case = 0
                    Datospedidofondo_fecha.Value = Date.Now
                    Datospedidofondo_label.Text = ""
                    Datosexpediente_pedidofondolabel.Text = ""
                    Informacion_General.Add(" ****el expediente se encuentra asociado " & vbCrLf & "a un pedido de fondos inexistente****")
                    Pedidofondo_tabitem.Visible = False
                Case Else
                    Pedidofondo_tabitem.Visible = True
                    If Not IsNothing(TablaTemporalPedidofondo.Rows(0).Item("Fecha_pedido")) And Not IsDBNull(TablaTemporalPedidofondo.Rows(0).Item("Fecha_pedido")) Then
                        Datospedidofondo_fecha.Value = Convert.ToDateTime(TablaTemporalPedidofondo.Rows(0).Item("Fecha_pedido"))
                    Else
                        Datospedidofondo_fecha.Value = Date.Now
                    End If
                    Informacion_General.Add("-Pedido de Fondos Nº " & Desglose_clave_pedidofondo(Listado_.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString) & vbCrLf & " (" & TablaTemporalPedidofondo.Rows(0).Item("nombre_cuenta").ToString & ")")
                    'Datosexpediente_pedidofondolabel.Text = Informacion_General & vbCrLf & "-Pedido de Fondos N" & Inicio.Unificadordecodigo(Datos_datagrid.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString, "PEDIDOFONDO" & " Iniciado por el Expte N" & Tablatemporalpedidofondo.Rows(0).Item("Expediente_N").ToString)
                    ' Informacion_General.Add(" -Pedido de Fondos N" & Inicio.Unificadordecodigo(Datos_datagrid.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString, "PEDIDOFONDO") & " (" & Tablatemporalpedidofondo.Rows(0).Item("nombre_cuenta").ToString & ")"
            End Select
            'stringinicial = ""
            'stringnumero = ""
            'stringyear = ""
        Else
            If Listado_.SelectedRows(0).Cells.Item("Cuenta_especial").Value.ToString.Length > 3 Then
                Informacion_General.Add("- Asignado a cuenta Especial-")
                Datosexpediente_pedidofondolabel.Text = " No requiere Cuenta Especial"
                Datospedidofondo_datagrid.DataSource = Nothing
                Labeltotalpedidofondo.Text = 0.ToString("C")
            Else
                Informacion_General.Add("--Sin pedido de fondo " & vbCrLf & "asignado actualmente---")
                Datosexpediente_pedidofondolabel.Text = ""
                Datospedidofondo_datagrid.DataSource = Nothing
            End If
        End If
        BotonCUITS.Visible = True
        'expedientes relacionados
        Expedientesrelacionados_tabitem.Visible = False
        If Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString.Length > 8 Then
            Expedientesrelacionados_tabitem.Visible = True
            'DATOS DEL EXPEDIENTE PRINCIPAL ASOCIADO
            ExpedientePrincipal.claveexpediente = Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString
            ExpedientePrincipal.Desglose_clave(Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString)
            Informacion_General.Add("-HIJO de: " & Claveexpedienteaexpediente(Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString))
            'Datos de los expedientes asociados al pedido de fondo en el que se encuentra el expediente seleccionado
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ClaveExpteprincipal", Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString)
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, " Select 0 AS 'N',CLAVE_TO_EXPEDIENTE(clave_expediente) as Expediente_N,Fecha,Detalle,Ordenpago,FORMAT(MONTO,2, 'es_AR') AS MONTO,Clave_expediente from Expediente where ClaveExpteprincipal=@ClaveExpteprincipal " &
                                 " order by clave_expediente desc,fecha desc", TablaTemporalExpedientesRelacionados_Principal, System.Reflection.MethodBase.GetCurrentMethod.Name)
            'Informacion_General = Informacion_General & vbCrLf & " Expte principal: " & Claveexpedienteaexpediente(Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString)
            'datos de los expedientes asociados al expediente, como hijos
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ClaveExpteprincipal", expediente_seleccionado.claveexpediente)
            Dim TablaTemporalExpteshijos As New DataTable
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, " Select CLAVE_TO_EXPEDIENTE(clave_expediente) as Expediente, DATE_FORMAT(fecha,'%d/%m/%Y') as fecha FROM Expediente where
CLAVE_EXPEDIENTE in
(select clave_expediente from contabilidad_ordenpago where contabilidad_ordenpago.clave_expediente_principal=@ClaveExpteprincipal)
 order by expediente.Fecha desc
 ",
            TablaTemporalExpteshijos, System.Reflection.MethodBase.GetCurrentMethod.Name)
            If TablaTemporalExpteshijos.Rows.Count > 0 Then
                Informacion_General.Add("Expediente autorizante de: ")
                For Each row As DataRow In TablaTemporalExpteshijos.Rows
                    Informacion_General.Add(row.Item("Expediente").ToString & " (" & row.Item("Fecha").ToString & ")")
                Next
            End If
            Select Case TablaTemporalExpedientesRelacionados_Principal.Rows.Count
                Case = 0
                    '   Informacion_General = Informacion_General.ToString
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Listado_.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, " Select 0 AS 'N',CLAVE_TO_EXPEDIENTE(clave_expediente) as Expediente_N,Fecha,Detalle,Ordenpago,FORMAT(MONTO,2, 'es_AR') AS Importe,Clave_expediente,Monto from Expediente where ClaveExpteprincipal=@Clave_expediente " &
                                 " order by clave_expediente desc,fecha desc", TablaTemporalExpedientesRelacionados_Hijos, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Select Case TablaTemporalExpedientesRelacionados_Hijos.Rows.Count
                        Case = 0
                            '  Informacion_General = Informacion_General & vbCrLf & "__________"
                        Case Else
                            Expedientesrelacionados_tabitem.Visible = True
                            ExpedientePrincipal_String = "-----EXPEDIENTE PRINCIPAL-----"
                            'Informacion_General.Add("-----EXPEDIENTE PRINCIPAL-----")
                            For x = 0 To TablaTemporalExpedientesRelacionados_Hijos.Rows.Count - 1
                                TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("N") = x + 1
                                ExpedientePrincipal_String = ExpedientePrincipal_String & vbCrLf & TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("Expediente_N").ToString & "- (" & TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("Detalle").ToString & ") por $" & TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("Importe").ToString
                                TotalEjecutadoExptePrincipal = CDec(TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("Monto").ToString) + TotalEjecutadoExptePrincipal
                                Select Case TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("clave_pedidofondo") > 0
                                    Case True
                                        ExpedientePrincipal_String = ExpedientePrincipal_String & vbCrLf & " en el Pedido de Fondo " &
                                        Inicio.Unificadordecodigo(TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("clave_pedidofondo").ToString, "PEDIDOFONDO") & " (" & TablaTemporalPedidofondo.Rows(0).Item("nombre_cuenta").ToString & ")"
                                    Case False
                                End Select
                            Next
                            Informacion_General.Add(ExpedientePrincipal_String)
                            Datosexpedientesasociados_datagrid.DataSource = TablaTemporalExpedientesRelacionados_Hijos
                            Informacion_General.Add("Los expedientes Hijos suman un total de $" & TotalEjecutadoExptePrincipal & " y resta asignar $" & CDec(Listado_.SelectedRows(0).Cells.Item("Monto").Value.ToString))
                            Expedientesrelacionados_tabitem.Visible = True
                    End Select
                Case Else
                    Datosexpedientesasociados_datagrid.DataSource = TablaTemporalExpedientesRelacionados_Principal
                    Expedientesrelacionados_tabitem.Visible = True
                    For x = 0 To TablaTemporalExpedientesRelacionados_Principal.Rows.Count - 1
                        TablaTemporalExpedientesRelacionados_Principal.Rows(x).Item("N") = x + 1
                    Next
            End Select
            'stringinicial = ""
            'stringnumero = ""
            'stringyear = ""
        Else
            Expedientesrelacionados_tabitem.Visible = False
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", expediente_seleccionado.clave)
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, " Select 0 AS 'N',CLAVE_TO_EXPEDIENTE(clave_expediente) as Expediente_N,Fecha,Detalle,Ordenpago,FORMAT(MONTO,2, 'es_AR') AS IMPORTE,Clave_expediente,clave_pedidofondo,MONTO from Expediente where ClaveExpteprincipal=@Clave_expediente " &
                                 " order by clave_expediente desc,fecha desc", TablaTemporalExpedientesRelacionados_Hijos, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Select Case TablaTemporalExpedientesRelacionados_Hijos.Rows.Count
                Case = 0
                    Informacion_General.Add(" No tiene expedientes relacionados")
                Case Else
                    Expedientesrelacionados_tabitem.Visible = True
                    Informacion_General.Add("-----EXPEDIENTE PRINCIPAL-----:")
                    Datosexpedientesasociados_datagrid.DataSource = TablaTemporalExpedientesRelacionados_Hijos
                    For x = 0 To TablaTemporalExpedientesRelacionados_Hijos.Rows.Count - 1
                        TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("N") = x + 1
                        Informacion_General.Add(TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("Expediente_N").ToString & "- (" & TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("Detalle").ToString & ") " & vbCrLf & " por $" & TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("Importe").ToString)
                        TotalEjecutadoExptePrincipal = CDec(TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("MONTO").ToString) + TotalEjecutadoExptePrincipal
                        Try
                            Select Case TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("clave_pedidofondo").ToString.Length > 0
                                Case True
                                    Informacion_General.Add(" en el Pedido de Fondo " & Inicio.Unificadordecodigo(TablaTemporalExpedientesRelacionados_Hijos.Rows(x).Item("clave_pedidofondo").ToString, "PEDIDOFONDO") & vbCrLf & " (" & TablaTemporalPedidofondo.Rows(0).Item("nombre_cuenta").ToString & ")")
                                Case False
                            End Select
                        Catch ex As Exception
                        End Try
                    Next
            End Select
        End If
        '------------------DATOS DE LA PARTIDA PRESUPUESTARIA----------------------
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Listado_.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, " Select * from Partidapresupuestaria  where Clave_expediente=@Clave_expediente " &
                             " order by Partida_presupuestaria desc", Tablatemporalpartida, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'la carga ha finalizado y no se requiere mostrar el boton de nuevo expediente, solo modificación
        Listado_.Select()
        'borrado de los datos en control
        'Informaciongeneral_listbox.Items.Clear()
        ''carga final de todos los datos
        'For x = 0 To Informacion_General.Count - 1
        '    Informaciongeneral_listbox.Items.Add(Informacion_General(x))
        'Next
        'borrado de los datos en control
        Detalle_listado_expedientes.Items.Clear()
        'carga final de todos los datos
        For x = 0 To Informacion_General.Count - 1
            Detalle_listado_expedientes.Items.Add(Informacion_General(x))
        Next
        'Datosgenerales_textbox.Text = Informacion_General
    End Sub

    Private Function Verificacion(ByVal claveexpediente As String) As Boolean
        'última actualización 05-01-2019
        'La función consulta si el expediente ya se encuentra asociado a un pedido de fondos, por lo cual no podrá ser modificado.
        Dim Verificar_datatable As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", claveexpediente)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select clave_pedidofondo from expediente where clave_expediente=@clave_expediente", Verificar_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case Verificar_datatable.Rows.Count
            Case = 0
                Return True
            Case Else
                Select Case IsDBNull(Verificar_datatable.Rows(0).Item("clave_pedidofondo"))
                    Case True
                        Return True
                    Case False
                        MessageBox.Show("Este expediente tiene asignado un pedido de fondos (" & Inicio.Unificadordecodigo(Verificar_datatable.Rows(0).Item("clave_pedidofondo").ToString, "PEDIDOFONDO") & " )" &
                                  vbCrLf & "por lo cual no se podrá modificarlo")
                        Return False
                End Select
        End Select
    End Function

    Private Sub Datos_datagrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Listado_.CellEnter
        Select Case Listado_.SelectedRows.Count = 1
            Case True
                ' DispatcherTimer setup
                Datos_expediente_Tabcontrol.Visible = False
                RemoveHandler Tiempoconsulta.Tick, AddressOf Consulta_tick
                AddHandler Tiempoconsulta.Tick, AddressOf Consulta_tick
                Tiempoconsulta.Interval = TimeSpan.FromMilliseconds(30)
                ' = New TimeSpan(0, 0, 1)
                Tiempoconsulta.Start()
            Case Else
                'Borrar datos anteriores
                Expediente_seleccionado_label.Text = ""
                Ordenpago_seleccionado_label.Text = ""
                Ordencargo_seleccionado_label.Text = ""
                Detalleexpediente_textbox.Text = ""
                Expediente_principal_label.Text = ""
                Montodelexpediente_textbox.Text = ""
        End Select
    End Sub

    Private Sub BotonCUITS_Click(sender As Object, e As EventArgs) Handles BotonCUITS.Click
        If Listado_.SelectedRows.Count = 1 Then
            'Cuit_expedientes.ShowDialog()
            expediente_seleccionado.Cargar_expediente(CType(expediente_seleccionado.year & expediente_seleccionado.organismo & Format(Convert.ToInt32(expediente_seleccionado.numero), "00000"), Long))
            If Listado_.SelectedRows(0).Cells.Item("HABERES").Value.ToString.Length = 0 Then
                Cuit_Expedientes.Asociarcuit(expediente_seleccionado, Listado_, Montodelexpediente_textbox)
            Else
                Cuit_Expedientes.Asociarcuit(expediente_seleccionado, Listado_, Montodelexpediente_textbox, 1)
            End If
        Else
            MessageBox.Show("Debe seleccionar un expediente para agregarle sus proveedores")
        End If
    End Sub

    Private Sub Organismo_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Detalleexpediente_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Agregaromodificar_boton_Click(sender As Object, e As EventArgs) Handles modificar_boton.Click
        Modificar()
        'Agregaromodificar(True)
        'Organismo_textbox.Focus()
    End Sub

    Private Sub Modificar()
        If Listado_.SelectedRows.Count > 0 Then
            'clave general de expediente
            Dim claveexpediente As Claveexpediente_separar
            claveexpediente.claveexpediente = Listado_.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString()
            claveexpediente.Desglose_clave(Listado_.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString())
            'Clave Expediente principal
            Dim expediente_principal As Claveexpediente_separar
            If Not IsDBNull(Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value) Then
                If Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString.Length > 5 Then
                    expediente_principal.claveexpediente = Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString()
                    expediente_principal.Desglose_clave(Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString())
                Else
                    expediente_principal.claveexpediente = "0"
                End If
            Else
                expediente_principal.claveexpediente = "0"
            End If
            'declaracion de orden de pago
            Dim ordenpago_div As String() = Divisordedosvariables(Listado_.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString())
            Dim ordencargo_div As String() = Divisordedosvariables(Listado_.SelectedRows(0).Cells.Item("OrdenCargo").Value.ToString())
            With expediente_existente
                .organismo = claveexpediente.organismo
                .numero = claveexpediente.numero
                .year = claveexpediente.year
                .monto = CType(Listado_.SelectedRows(0).Cells.Item("Monto").Value, Decimal)
                .fecha = CType(Listado_.SelectedRows(0).Cells.Item("Fecha").Value, Date)
                .descripcion = CType(Listado_.SelectedRows(0).Cells.Item("Detalle").Value, String)
                If Not IsNothing(ordenpago_div) Then
                    .ordenpago = CType(ordenpago_div(0), Integer)
                    .ordenpagoyear = CType(ordenpago_div(1), Integer)
                Else
                    .ordenpago = 0
                    .ordenpagoyear = Date.Now.Year
                End If
                Try
                    If Not IsNothing(ordencargo_div) Or Not ordencargo_div(0) = "" Then
                        .ordencargo = CType(ordencargo_div(0), Integer)
                        .ordencargoyear = CType(ordencargo_div(1), Integer)
                    Else
                        .ordencargo = 0
                        .ordencargoyear = Date.Now.Year
                    End If
                Catch ex As Exception
                    .ordencargo = 0
                    .ordencargoyear = Date.Now.Year
                End Try
                If Not IsDBNull(Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value) And Listado_.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString.Length > 8 Then
                    .tieneprincipal = True
                Else
                    .tieneprincipal = False
                End If
                .cuentaespecial = Listado_.SelectedRows(0).Cells.Item("Cuenta_especial").Value.ToString
                If Not IsNothing(ordenpago_div) Then
                    .ordenpago = CType(ordenpago_div(0), Integer)
                    .ordenpagoyear = CType(ordenpago_div(1), Integer)
                Else
                    .ordenpago = 0
                    .ordenpagoyear = Date.Now.Year
                End If
                If Not IsNothing(expediente_principal.claveexpediente) And expediente_principal.claveexpediente.Length > 8 Then
                    .principalorganismo = expediente_principal.organismo
                    .principalnumero = expediente_principal.numero
                    .principalyear = expediente_principal.year
                    .principaldescripcion = ""
                Else
                    .principalorganismo = 0
                    .principalnumero = 0
                    .principalyear = Date.Now.Year
                    .principaldescripcion = ""
                End If
            End With
            Dialogo_Nuevoexpediente.General_cargaexpediente(expediente_seleccionado, Color.LightCyan)
            '
            ' General_nuevoexpediente.ShowDialog()
        Else
            MessageBox.Show("No se encuentra seleccionado ningún expediente")
        End If
    End Sub

    'Private Sub BotonCancelar_Click(sender As Object, e As EventArgs)
    '    Organismo_textbox.Focus()
    'End Sub
    Private Sub Agregaromodificar(ByVal Agregar As Boolean)
        Dim Datos_validos As Boolean = True
        Dim Errores(7) As String
        Dim Total_errores As String = ""
        'verificación
        'Select Case Organismo_textbox.Text.Length > 0
        '    Case True
        '        Select Case IsNumeric(Organismo_textbox.Text)
        '            Case True
        '            Case False
        '                Datos_validos = False
        '                Errores(1) = "El Código de Organismo en El expediente de pedido de fondos es un número de 4 cifras, por favor verifique"
        '        End Select
        '    Case False
        '        Datos_validos = False
        '        Errores(1) = "El Número del organismo esta vacío"
        'End Select
        'Select Case Numeroexpediente_textbox.Text.Length > 0
        '    Case True
        '        Select Case IsNumeric(Numeroexpediente_textbox.Text)
        '            Case True
        '            Case False
        '                Datos_validos = False
        '                Errores(2) = "El número de Expediente solo puede contener números"
        '        End Select
        '    Case False
        '        Datos_validos = False
        '        Errores(2) = "El Número de expediente esta vacío"
        'End Select
        'Select Case Year_textbox.Text.Length > 0
        '    Case True
        '        Select Case IsNumeric(Year_textbox.Text)
        '            Case True
        '            Case False
        '                Datos_validos = False
        '                Errores(3) = "El año se debe representar en números unicamente"
        '        End Select
        '    Case False
        '        Datos_validos = False
        '        Errores(3) = "El año del expediente se debe representar con 4 número ej." & Date.Now.Year
        'End Select
        'Select Case Detalleexpediente_textbox.Text.Length > 0
        '    Case True
        '    Case False
        '        Datos_validos = False
        '        Errores(4) = "Debe ingresar un detalle o descripción del expediente"
        'End Select
        'Select Case Montodelexpediente_textbox.Number > 0
        '    Case True
        '    Case False
        '        Datos_validos = False
        '        Errores(5) = "El monto del expediente debe ser Mayor a 0 (cero)"
        'End Select
        If Datos_validos = True Then
            'If (expediente_seleccionado.organismo.ToString.Length = 4) And (IsNumeric(Numeroexpediente_textbox.Text)) And ((IsNumeric(Year_textbox.Text)) And (Year_textbox.Text.Length = 4)) Then
            '    If Verificacion(Year_textbox.Text & Organismo_textbox.Text & Format(Convert.ToInt32(Numeroexpediente_textbox.Text), "00000")) Then
            Select Case MsgBox(Inicio.Verificacionexistenciaexpediente(expediente_seleccionado.year & expediente_seleccionado.organismo & Format(Convert.ToInt32(expediente_seleccionado.numero), "00000")), MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", expediente_seleccionado.clave)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", expediente_seleccionado.organismo & "-" & expediente_seleccionado.numero & "/" & expediente_seleccionado.year)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", expediente_seleccionado.fecha)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", expediente_seleccionado.descripcion)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordenpago", expediente_seleccionado.ordenpago & "/" & expediente_seleccionado.ordenpagoyear)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordencargo", expediente_seleccionado.ordencargo & "/" & expediente_seleccionado.ordencargoyear)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", 0)
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Claveexpteprincipal", expediente_seleccionado.claveprincipal)
                    'Expteoriginario_label.text
                    Select Case Agregar
                        Case True
                            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `expediente` " &
                        "(Clave_expediente,CLAVE_TO_EXPEDIENTE(clave_expediente) as Expediente_N,Fecha,Detalle,Ordenpago,Ordencargo,Monto,Claveexpteprincipal,Usuario) " &
                        "VALUES (@Clave_expediente,@Expediente_N,@Fecha,@Detalle,@Ordenpago,@Ordencargo,@Monto,@Claveexpteprincipal,@Usuario) "
                        Case False
                            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = " UPDATE `expediente` SET " &
                        "Expediente_N=@Expediente_N,Fecha=@Fecha,Detalle=@Detalle,Ordenpago=@Ordenpago,ordencargo=@OrdenCargo,
Claveexpteprincipal=@Claveexpteprincipal,Usuario=@Usuario Where Clave_expediente=@Clave_expediente"
                    End Select
                    '    'carga de partida presupuestaria
                    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    '    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    refreshgeneral()
            End Select
        End If
        'Else
        '    Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString()
        '    MessageBox.Show("Compruebe en el formulario los datos que ha ingresado")
        'End If
        '    Else
        '    For x = 0 To Errores.Count - 1
        '        If Not (Errores(x) = "") Then
        '            Total_errores = Total_errores & vbCrLf & "-" & Errores(x)
        '        End If
        '    Next
        '    MessageBox.Show("El expediente no se puede cargar por contener los siguiente errores " & vbCrLf & Total_errores)
        'End If
    End Sub

    Private Sub Botoneliminar_Click(sender As Object, e As EventArgs) Handles Botoneliminar.Click
        Select Case Listado_.SelectedRows.Count
            Case > 0
                Select Case Inicio.Verificacionasociacionpedidofondo(Listado_.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                    Case = ""
                        Select Case MsgBox("Confirma que desea BORRAR este Expediente Nº" & Listado_.SelectedRows(0).Cells.Item("Expediente N").Value, MsgBoxStyle.YesNoCancel, " ")
                            Case MsgBoxResult.Yes
                                'Dim borrartabla As New DataTable
                                'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                                'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                                'Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Expediente_N,Fecha,Detalle,Ordenpago,FORMAT(Monto,2, 'es_AR') as Monto,Claveasociada,ClaveExpteprincipal,clave_pedidofondo,Cuenta_N,Clave_expediente from expediente where clave_expediente=@clave_expediente", borrartabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                '    For x = 0 To borrartabla.Rows.Count - 1
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente2", borrartabla.Rows(x).Item("Clave_expediente"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", borrartabla.Rows(x).Item("Expediente_N"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", borrartabla.Rows(x).Item("Fecha"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", borrartabla.Rows(x).Item("Detalle"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordenpago", borrartabla.Rows(x).Item("Ordenpago"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", borrartabla.Rows(x).Item("Monto"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Claveasociada", borrartabla.Rows(x).Item("Claveasociada"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ClaveExpteprincipal", borrartabla.Rows(x).Item("ClaveExpteprincipal"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", borrartabla.Rows(x).Item("clave_pedidofondo"))
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta_N", borrartabla.Rows(x).Item("Cuenta_N"))
                                '        'Usuario apellido y nombre en computadora X
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@USUARIO", Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString & "@" & My.Computer.Name)
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_borrado", Date.Now)
                                '        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `expediente_BORRADOS` (Clave_expediente,CLAVE_TO_EXPEDIENTE(clave_expediente) as Expediente_N,Fecha,Detalle,Ordenpago,Monto,Claveasociada,ClaveExpteprincipal,clave_pedidofondo,Cuenta_N,Usuario,Fecha_borrado)" &
                                '"VALUES (@Clave_expediente2,@Expediente_N,@Fecha,@Detalle,@Ordenpago,@Monto,@Claveasociada,@ClaveExpteprincipal,@clave_pedidofondo,@Cuenta_N,@Usuario,@Fecha_borrado)"
                                '        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                '    Next
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Listado_.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `expediente` WHERE (Clave_expediente=@Clave_expediente)"
                                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                refreshgeneral()
                        End Select
                    Case Else
                        MsgBox(Inicio.Verificacionasociacionpedidofondo(Listado_.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString), MsgBoxStyle.OkOnly, "ADVERTENCIA EXPEDIENTE ASOCIADO A PEDIDO DE FONDO")
                End Select
            Case = 0
                MessageBox.Show("Debe seleccionar un expediente para borrar")
        End Select
    End Sub

    Private Sub Nuevoexpediente_boton_Click(sender As Object, e As EventArgs) Handles Nuevoexpediente_boton.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()
        Dim expediente_nuevo As New Expediente
        Dialogo_Nuevoexpediente.General_cargaexpediente(expediente_nuevo, Color.LightCyan)
        refreshgeneral()
    End Sub

    Private Sub Datos_datagrid_MouseUp(sender As Object, e As MouseEventArgs) Handles Listado_.MouseUp
        MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        refreshgeneral()
    End Sub

    Private Sub Tesoreria_Expedientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If Inicio.Contabilidadmenu.Visible Then
        '    BotonOrdenProvision.Visible = True
        'Else
        '    BotonOrdenProvision.Visible = False
        'End If
    End Sub

    Public Sub MESADEENTRADAS()
        TableLayoutPanelbotones.Visible = False
        BotonCUITS.Visible = False
        'BotonOrdenProvision.Visible = False
        Me.MdiParent = Inicio
        Me.Show()
    End Sub

    Private Sub Tesoreria_Expedientes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F12
            Case Is = Keys.F11
            Case Is = Keys.F10
            Case Is = Keys.F5
                MyBase.SuspendLayout()
                refreshgeneral()
                MyBase.ResumeLayout()
        End Select
    End Sub

    Private Sub BotonOrdenProvision_Click(sender As Object, e As EventArgs)
        Suministros_OrdenProvision.Todoacero()
        Suministros_OrdenProvision.OrdenProvision.Expediente = Listado_.SelectedRows(0).Cells.Item("EXPEDIENTE N").Value
        Suministros_OrdenProvision.OrdenProvision.Iniciador = Listado_.SelectedRows(0).Cells.Item("DETALLE").Value
        Mostrardialogo(Suministros_OrdenProvision)
        'Suministros_OrdenProvision.ShowDialog()
    End Sub

End Class