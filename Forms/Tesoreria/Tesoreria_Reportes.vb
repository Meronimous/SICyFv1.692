Imports System.Globalization
Imports System.Threading

Imports OpenQA.Selenium

Public Class Tesoreria_Reportes
    ' Dim Tablatemporal As New DataTable
    Dim datagridseleccionado As Object
    Dim reportes_datatables As New DataTable
    Dim reportes_datatables_menu As New DataTable
    Dim TIPO_REPORTE As String = ""
    Dim cuenta_seleccionada As New Cuenta_Bancaria
    Dim user As String = ""
    Dim Pwdss As String = ""

    Public Sub CARGAGENERAL(ByVal TIPOREPORTE As String)
        TIPO_REPORTE = TIPOREPORTE
        Me.Show()
    End Sub

    Private Sub MOUSEDERECHOCONCILIACION(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object)
        datagridseleccionado = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf Menucontextualconciliacion
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf Menucontextualconciliacion
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf Menucontextualconciliacion
        Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf Menucontextualconciliacion
        'detalle del reporte
        Dim itemsafi = cms.Items.Add("Cargar valores en SAFI")
        itemsafi.Tag = 6
        Select Case True
            Case TipoReporte.Text.ToUpper.Contains("REPORTE CARGA SAFI")
                AddHandler itemsafi.Click, AddressOf Menucontextualconciliacion
            Case TipoReporte.Text.ToUpper.Contains("HOJA DE LIBRO BANCO RETENCIONES")
                AddHandler itemsafi.Click, AddressOf Menucontextualconciliacion
            Case Else
        End Select
        If Not ((datagridseleccionado.selectedrows(0).cells.item(0).value.ToString = "-CHEQUES SIN COBRAR EN BANCO") Or
                    (datagridseleccionado.selectedrows(0).cells.item(0).value.ToString = "LIBRO:") Or
                    (datagridseleccionado.selectedrows(0).cells.item(0).value.ToString = "BANCO:")) Then
            Dim item5 = cms.Items.Add("Ver detalle de " & datagridseleccionado.selectedrows(0).cells.item(0).value.ToString)
            item5.Tag = 4
            AddHandler item5.Click, AddressOf Menucontextualconciliacion
            cms.Show(CONTROL, MOUSE.Location)
            Select Case True
                Case TipoReporte.Text.ToUpper.Contains("HOJA DE LIBRO BANCO")
                    Dim item9 = cms.Items.Add("Ver detalle expediente en FyV")
                    item9.Tag = 9
                    AddHandler item9.Click, AddressOf Menucontextualconciliacion
                Case Else
            End Select
        Else
        End If
        'detalle del reporte
        Dim item6 = cms.Items.Add("Buscar Conciliación")
        item6.Tag = 5
        AddHandler item6.Click, AddressOf Menucontextualconciliacion
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub Menucontextualconciliacion(ByVal sender As Object, ByVal e As EventArgs)
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
            Case Is = 2
                'IMPRESIÓN DE HOJA HORIZONTAL
                hojahorizontal(datagridseleccionado)
            Case Is = 3
                'IMPRESIÓN DE HOJA VERTICAL
                hojavertical(datagridseleccionado)
            Case Is = 4
                If Not ((datagridseleccionado.selectedrows(0).cells.item(0).value.ToString = "-CHEQUES SIN COBRAR EN BANCO") Or
                    (datagridseleccionado.selectedrows(0).cells.item(0).value.ToString = "LIBRO:") Or
                    (datagridseleccionado.selectedrows(0).cells.item(0).value.ToString = "BANCO:")) Then
                    Dialogo_datos.IniciadorDatos(GeneracionCONSULTAdetalle(datagridseleccionado.selectedrows(0).cells.item(0).value.ToString), "Detalle del item -" & datagridseleccionado.selectedrows(0).cells.item(0).value.ToString)
                Else
                    MessageBox.Show(
                        datagridseleccionado.selectedrows(0).cells.item(0).value.ToString & vbCrLf & " NO TIENE UN REPORTE DETALLADO")
                End If
            Case Is = 5
                Inicio.MENULLAMADO(Conciliacion_Bancaria)
                Conciliacion_Bancaria.Desde_monthcalendarA.Value = Desde_datetimepicker.Value
                Conciliacion_Bancaria.Hasta_monthcalendarA.Value = Hasta_DateTimePicker.Value
                If Conciliacion_Bancaria.Cuentas_combobox.Items.Count > 0 Then
                    Conciliacion_Bancaria.Cuentas_combobox.SelectedIndex = Cuentas_combobox.SelectedIndex
                Else
                End If
            Case Is = 6
                Dim t As Task = (New Task(Sub() SAFI_fillwebform()))
                t.Start()
                'SAFI_fillwebform()
            Case Is = 9
                If TipoReporte.Text.ToUpper.Contains("HOJA DE LIBRO BANCO") Or TipoReporte.Text.ToUpper.Contains("SAFI") Then
                    Dim tabla_datos As New DataTable
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", datagridseleccionado.SelectedRows(0).Cells.Item("clave_expediente").Value)
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Fecha,Detalle,
CASE when not(ingresos=0) and not(codinp=2) then Ingresos else
CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
Concat(cod_orden,Cfdo,CodInp) as 'MFyV',
PedidoFondo_N,Nrotransferencia
From MFyV where clave_expediente=@clave_expediente order by Fecha desc", tabla_datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Dialogo_datos.mostrardatatable(tabla_datos)
                End If
        End Select
        '-- etc
    End Sub

    Private Sub hojavertical(ByVal datagridseleccionado As DataGridView)
        Select Case True
            Case TipoReporte.Text.ToUpper.Contains("HOJA DE LIBRO BANCO")
                CType(datagridseleccionado, DataGridView).Columns.Item("Autor").Visible = False
                CType(datagridseleccionado, DataGridView).Columns.Item("Cargado el:").Visible = False
                HOJALIBROBANCOPDF(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, False, "LEGAL", Desde_datetimepicker.Value.Date, Hasta_DateTimePicker.Value.Date, cuenta_seleccionada)
                CType(datagridseleccionado, DataGridView).Columns.Item("Autor").Visible = True
                CType(datagridseleccionado, DataGridView).Columns.Item("Cargado el:").Visible = True
            Case Else
                PDFDatagridview(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, False, "LEGAL")
        End Select
    End Sub

    Private Sub hojahorizontal(ByVal datagridseleccionado As DataGridView)
        If datagridseleccionado.Columns.Contains("Autor") And (datagridseleccionado.Columns.Contains("Cargado el:")) Then
            CType(datagridseleccionado, DataGridView).Columns.Item("Autor").Visible = False
            CType(datagridseleccionado, DataGridView).Columns.Item("Cargado el:").Visible = False
        End If
        Select Case True
            Case TipoReporte.Text.ToUpper.Contains("INGRESOS")
                HOJALIBROBANCOPDF(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, True, "LEGAL", Desde_datetimepicker.Value.Date, Hasta_DateTimePicker.Value.Date, cuenta_seleccionada)
            Case TipoReporte.Text.ToUpper.Contains("EGRESOS")
                HOJALIBROBANCOPDF(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, True, "LEGAL", Desde_datetimepicker.Value.Date, Hasta_DateTimePicker.Value.Date, cuenta_seleccionada)
            Case TipoReporte.Text.ToUpper.Contains("INGRESOS")
                HOJALIBROBANCOPDF(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, True, "LEGAL", Desde_datetimepicker.Value.Date, Hasta_DateTimePicker.Value.Date, cuenta_seleccionada)
            Case TipoReporte.Text.ToUpper.Contains("INGRESOS")
                HOJALIBROBANCOPDF(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, True, "LEGAL", Desde_datetimepicker.Value.Date, Hasta_DateTimePicker.Value.Date, cuenta_seleccionada)
            Case TipoReporte.Text.ToUpper.Contains("SAFI")
                HOJALIBROBANCOPDF(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, True, "LEGAL", Desde_datetimepicker.Value.Date, Hasta_DateTimePicker.Value.Date, cuenta_seleccionada)
            Case TipoReporte.Text.ToUpper.Contains("HOJA DE LIBRO BANCO RETENCIONES")
                HOJALIBROBANCOPDF(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, True, "LEGAL", Desde_datetimepicker.Value.Date, Hasta_DateTimePicker.Value.Date, cuenta_seleccionada)
            Case Else
                PDFDatagridview(CType(datagridseleccionado, DataGridView), TipoReporte.Text.ToUpper, True, "LEGAL")
        End Select
        If datagridseleccionado.Columns.Contains("Autor") And (datagridseleccionado.Columns.Contains("Cargado el:")) Then
            CType(datagridseleccionado, DataGridView).Columns.Item("Autor").Visible = True
            CType(datagridseleccionado, DataGridView).Columns.Item("Cargado el:").Visible = True
        End If
    End Sub

    Private Sub DataGridView1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Reportes_datagridview.MouseWheel
        DataGridView_MouseWheel(sender, e)
    End Sub

    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Desde_datetimepicker.Value = Date.Now
        Hasta_DateTimePicker.Value = Date.Now
        'Desde_datetimepicker.Value = CType("01-" & Date.Now.AddMonths(-1).Month & "-" & Date.Now.AddMonths(-1).Year, Date)
        Year_numeric.Value = Desde_datetimepicker.Value.Year
        'Hasta_DateTimePicker.Value = CType(Date.DaysInMonth(Date.Now.AddMonths(-1).Year, Date.Now.AddMonths(-1).Month) & "-" & Date.Now.AddMonths(-1).Month & "-" & Date.Now.AddMonths(-1).Year, Date)
        'With Tiporeporte_combobox.Items
        '    .AddRange(New Object() {
        '              "LIBRO BANCO",
        '              "CONCILIACION EN FECHAS SELECCIONADAS",
        '              "CONCILIACION CHEQUES NO COBRADOS",
        '              "CONCILIACION INGRESOS NO REGISTRADOS",
        '              "CONCILIACION DETALLADO",
        '              "CONCILIACION DETALLADO VERSION PARA EXCEL",
        '              "CONCILIACION BANCO UNIFICADO",
        '              "ESTADO POR PEDIDOS DE FONDOS",
        '              "ESTADO POR EXPEDIENTES",
        '              "MOVIMIENTOS DE FONDOS Y VALORES",
        '              "LISTADO DE EXPEDIENTES",
        '              "CUENTA BANCARIA TOTALES",
        '              "CUENTA BANCARIA TOTALES POR PERIODO",
        '              "REPORTE DE LO ACTUADO"
        '              })
        'End With
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
        With reportes_datatables_menu
            With .Columns
                .Add("Tipo reporte")
                .Add("Descripción")
            End With
            With .Rows
                Select Case TIPO_REPORTE
                    Case Is = "CONCILIACIÓN"
                        .Add("CONCILIACION EN FECHAS SELECCIONADAS", " Reporte de Conciliación basado en modelo 1")
                        .Add("CONCILIACIÓN EN LAS FECHAS SELECCIONADAS 2", " Reporte de Conciliación basado en modelo 2")
                        .Add("CONCILIACION CHEQUES NO COBRADOS", " Cheques registrados en libro no cobrados en Banco")
                        .Add("CONCILIACION INGRESOS NO REGISTRADOS", " Transferencias registradas en libro no reflejadas en Banco")
                        .Add("CONCILIACION DETALLADO", "Reporte Detallado por Movimiento de la Conciliación en las fechas seleccionadas")
                        .Add("CONCILIACION DETALLADO VERSION PARA EXCEL", "Reporte ajustado para Ms. Excel del Reporte de Conciliación detallado")
                        .Add("CONCILIACION BANCO UNIFICADO", "")
                    Case Is = "REPORTES DIARIOS"
                        '   .Add("HOJA DE LIBRO BANCO INGRESOS", "TRANSFERENCIAS DE TES. GRAL.")
                        '   .Add("HOJA DE LIBRO BANCO EGRESOS", "PAGOS REALIZADOS SIN CONTABILIZAR RETENCIONES")
                        .Add("REPORTE CARGA SAFI INGRESOS", "Reporte para cargar en SAFI")
                        .Add("REPORTE CARGA SAFI EGRESOS", "Reporte para cargar en SAFI")
                        .Add("HOJA DE LIBRO BANCO RETENCIONES", "RETENCIONES EN EL PERIODO SELECCIONADO")
                        .Add("HOJA DE LIBRO BANCO RENDICIONES", "Hoja para colocar en libro Banco")
                        .Add("HOJA DE LIBRO BANCO HABERES", "HOJA DE LIBRO DE HABERES")
                        .Add("VERIFICAR INGRESOS TESORERIA", "Reporte detallado de los Ingresos Registrados- Tesorería General")
                        .Add("VERIFICAR INGRESOS POR DIA TESORERIA GENERAL", "Reporte de los Ingresos Registrados- Tesorería General")
                        '.Add("PRUEBA EGRESOS", "prueba de reporte con negativos")
                    Case Is = "OTROS REPORTES"
                        .Add("ESTADO POR PEDIDOS DE FONDOS", "Estado de Cada pedido de fondo basado en los datos registrados")
                        .Add("ESTADO POR EXPEDIENTES", "Estado de Cada Expediente basado en los datos registrados")
                        .Add("MOVIMIENTOS DE FONDOS Y VALORES", "Hoja para realizar la carga de movimientos en MFyV")
                        .Add("LISTADO DE EXPEDIENTES", "Listado completo de Expedientes")
                        .Add("CUENTA BANCARIA TOTALES", "Totales en cada cuenta Bancaria")
                        .Add("CUENTA BANCARIA TOTALES POR PERIODO", "Totales en cada cuenta Bancaria por período")
                        .Add("PEDIDO DE FONDOS DETALLE POR FECHA", "Pedido de fondos detallados imputación por fecha")
                        .Add("MFyV AGRUPADOS POR Nº TRANSFERENCIA", "Listado de Nº con la suma de sus movimientos en la fechas seleccionadas")
                        .Add("MFyV AGRUPADOS POR EXPEDIENTE", "Listado de Expedientes con la suma de sus movimientos en la fechas seleccionadas")
                        .Add("RETENCIONES EN EL PERIODO SELECCIONADO", " Listado de Recibos y sus retenciones asociadas en el período seleccionado")
                End Select
            End With
        End With
        ' SplitContainergeneral.SplitterDistance = Tiporeporte_combobox.Width + 2
    End Sub

    Private Sub Desde_datetimepicker_ValueChanged(sender As Object, e As EventArgs)
        Reportes_datagridview.DataSource = Nothing
    End Sub

    Private Sub Hasta_datetimepicker_ValueChanged(sender As Object, e As EventArgs)
        Reportes_datagridview.DataSource = Nothing
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        cuenta_seleccionada.CuentaN = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
        cuenta_seleccionada.nombrecuenta = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(1).ToString
        Reportes_datagridview.DataSource = Nothing
    End Sub

    Private Sub Reportes_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Reportes_datagridview.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Select Case TipoReporte.Text.ToUpper
                    Case Is = "HOJA DE LIBRO BANCO INGRESOS"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "HOJA DE LIBRO BANCO EGRESOS"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "HOJA DE LIBRO BANCO RENDICIONES"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "HOJA DE LIBRO BANCO RETENCIONES"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "HOJA DE LIBRO BANCO HABERES"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "VERIFICAR INGRESOS TESORERIA"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "VERIFICAR INGRESOS POR DIA TESORERIA GENERAL"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    'Case Is = "PRUEBA EGRESOS"
                    '    MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "HOJA DE LIBRO BANCO AJUSTES"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "CONCILIACION EN FECHAS SELECCIONADAS"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "CONCILIACIÓN EN LAS FECHAS SELECCIONADAS 2"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "ESTADO POR PEDIDOS DE FONDOS"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "ESTADO POR EXPEDIENTES"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "MOVIMIENTOS DE FONDOS Y VALORES"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "LISTADO DE EXPEDIENTES"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "CUENTA BANCARIA TOTALES"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "CUENTA BANCARIA TOTALES POR PERIODO"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "PEDIDO DE FONDOS DETALLE POR FECHA"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "CONCILIACION CHEQUES NO COBRADOS"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "CONCILIACION INGRESOS NO REGISTRADOS"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "CONCILIACION DETALLADO"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "CONCILIACION DETALLADO VERSION PARA EXCEL"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "CONCILIACION BANCO UNIFICADO"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "REPORTE CARGA SAFI INGRESOS"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "REPORTE CARGA SAFI EGRESOS"
                        MOUSEDERECHOCONCILIACION(sender, e, sender)
                    Case Is = "MFYV AGRUPADOS POR Nº TRANSFERENCIA"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "MFYV AGRUPADOS POR EXPEDIENTE"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                    Case Is = "RETENCIONES EN EL PERIODO SELECCIONADO"
                        Inicio.MOUSEDERECHO(sender, e, sender)
                End Select
        End Select
    End Sub

    Private Sub Desde_datetimepicker_ValueChanged_1(sender As Object, e As EventArgs) Handles Desde_datetimepicker.ValueChanged
        Reportes_datagridview.DataSource = Nothing
        If Not IsNothing(TipoReporte.Text.ToUpper) Then
            Select Case TipoReporte.Text.ToUpper
                'Case Is = "MOVIMIENTOS DE FONDOS Y VALORES"
                '    If Not Hasta_DateTimePicker.Value = Desde_datetimepicker.Value Then
                '        Hasta_DateTimePicker.Value = Desde_datetimepicker.Value
                '    End If
                Case Else
                    If Hasta_DateTimePicker.Value < Desde_datetimepicker.Value Then
                        Hasta_DateTimePicker.Value = Desde_datetimepicker.Value
                    End If
            End Select
        End If
    End Sub

    Private Sub Hasta_DateTimePicker_ValueChanged_1(sender As Object, e As EventArgs) Handles Hasta_DateTimePicker.ValueChanged
        Reportes_datagridview.DataSource = Nothing
        If Not IsNothing(TipoReporte.Text.ToUpper) Then
            Select Case TipoReporte.Text.ToUpper
                Case Is = "MOVIMIENTOS DE FONDOS Y VALORES"
                    If Not Hasta_DateTimePicker.Value = Desde_datetimepicker.Value Then
                        Desde_datetimepicker.Value = Hasta_DateTimePicker.Value
                    End If
                Case Else
                    If Hasta_DateTimePicker.Value < Desde_datetimepicker.Value Then
                        Desde_datetimepicker.Value = Hasta_DateTimePicker.Value
                    End If
            End Select
        End If
    End Sub

    'Private Sub Tiporeporte_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tiporeporte_combobox.SelectedIndexChanged
    '    Reportes_datagridview.DataSource = Nothing
    '    Select Case TipoReporte.Text.ToUpper
    '        Case Is = "MOVIMIENTOS DE FONDOS Y VALORES"
    '            If Not Hasta_DateTimePicker.Value = Desde_datetimepicker.Value Then
    '                Hasta_DateTimePicker.Value = Desde_datetimepicker.Value
    '            End If
    '        Case Else
    '            If Hasta_DateTimePicker.Value < Desde_datetimepicker.Value Then
    '                Hasta_DateTimePicker.Value = Desde_datetimepicker.Value
    '            End If
    '    End Select
    'End Sub
    Private Sub Recalcular()
        Panelfechas.Visible = True
        Cuentas_combobox.Visible = True
        If Not IsNothing(TipoReporte.Text.ToUpper) Then
            ' EL NOMBRE DEL REPORTE DEBE ESTAR EN MAYUSCULAS
            reportes_datatables = Nothing
            Accionesalmodificartiporeporte()
            Reportes_datagridview.DataSource = reportes_datatables
        End If
        Select Case TipoReporte.Text.ToUpper
            Case Is = "HOJA DE LIBRO BANCO EGRESOS"
            Case Else
        End Select
        Formatocolumnas(Reportes_datagridview, reportes_datatables)
    End Sub

    Private Function GeneracionCONSULTAdetalle(ByVal nombrereporte As String) As String
        Dim Consultasql As String = ""
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType(Year_numeric.Value & "-01-01", Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ultimodia", CType(Year_numeric.Value & "-12-31", Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@year", Year_numeric.Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@MOV_TIPO", nombrereporte.Replace("-", ""))
        ' MessageBox.Show(datagridseleccionado.selectedrows(0).cells.item(0).value.ToString)
        '   BANCO:
        '-SALDO INICIAL
        '-MOVIMIENTOS
        '-SALDO AL 29/03/2020
        '-CHEQUES COBRADOS, NO REGISTRADOS EN LIBRO       x
        '-INGRESOS NO REGISTRADOS EN LIBRO
        '-CHEQUES RECHAZADOS
        '-COMISIONES BANCARIAS
        '-DEBITO FISCAL IVA BASICO
        'LIBRO:
        '-SALDO INICIAL
        '-MOVIMIENTOS
        '-SALDO AL 29/03/2020 (Incluyendo IPS)
        '-IPS ACUMULADO
        '-IPS
        '-CHEQUES SIN COBRAR EN BANCO
        '-----ORDEN DE PAGO
        '-----HABERES
        '-----PAGO
        '-----JUDICIALES
        '-----SEGUROS
        '-INGRESOS AÚN NO REGISTRADOS EN BANCO
        Select Case nombrereporte
            Case Is = "-SALDO INICIAL"
                '0 BANCO:  SALDO INICIAL
                Consultasql = "Select
DATE_FORMAT(fecha,'%d/%m/%Y')as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,Importe As 'Importe mov.'
FROM reportebanco
WHERE
	Cuenta =@cuenta
AND (
	fecha BETWEEN @primerdia
	AND DATE_SUB(@desde,INTERVAL 1 day))"
            Case Is = "-MOVIMIENTOS"
                '
                Select Case Reportes_datagridview.SelectedRows(0).Index > 3
                    Case True
                        'libro
                        Consultasql = "Select DATE_FORMAT(fechadelmovimiento,'%d/%m/%Y')as 'Fecha',
                                                           Nrotransferencia as 'Nro comprobante',
Expediente_N,
                    CASE WHEN MONTO=0 THEN   CASE WHEN ISNULL(MONTO_HISTORIAL) THEN DETALLE ELSE CONCAT('**ANULADO EL ',DATE_FORMAT(Creado_o_modificado2,'%d/%m/%Y'),'** ',DETALLE) END    ELSE DETALLE END  as 'Extracto',
                    Case WHEN MONTO=0 THEN MONTO_HISTORIAL ELSE MONTO END as 'IMPORTE',
                    Creado_o_modificado as 'ultima modificación',autor,MONTO_HISTORIAL
                FROM
                (select * from 	expediente_detalle
                WHERE
                (fechadelmovimiento BETWEEN @desde And @HASTA)
                            And
        (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @CUENTA)) Or
        SUBSTRING(Clave_expediente_detalle FROM 1 For CHAR_LENGTH(Clave_expediente_detalle) - 4) In
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @CUENTA))
        )original
       left join
				( select fechadelmovimiento as fechadelmovimiento_historial,MOV_TIPO as MOV_TIPO_historial,monto as monto_historial,clave_expediente_detalle as clave_expediente_detalle_historial,md5_relacionado as md5_relacionado_historial,Creado_o_modificado2 from
	expediente_detalle_historial where fechadelmovimiento BETWEEN @DESDE	AND @HASTA AND Creado_o_modificado2 > @HASTA group by clave_expediente_Detalle )historial
	on original.clave_expediente_detalle=historial.clave_expediente_detalle_historial
left join
(Select concat(nombres,' ',apellidos) as autor,usuario as usuario2 from contaduria_usuarios.usuarios)usuarios
on original.usuario=usuarios. usuario2;"
                    Case False
                        'banco
                        Consultasql = "Select
DATE_FORMAT(fecha,'%d/%m/%Y')as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,Importe As 'Importe mov.'
FROM reportebanco
WHERE
	Cuenta =@cuenta
AND (
	fecha BETWEEN @DESDE
	AND @HASTA)
	ORDER BY FECHA ASC"
                End Select
            Case Is = "-SALDO AL " & Hasta_DateTimePicker.Value.Date.ToShortDateString
                '2 BANCO:  SALDO AL 28/02/2019
                Select Case Reportes_datagridview.SelectedRows(0).Index > 3
                    Case True
                        'libro
                        Consultasql = "Select DATE_FORMAT(fechadelmovimiento,'%d/%m/%Y')as 'Fecha',
Expediente_N,Detalle as 'Extracto',
Case when CodInp=3 then Orden_N else '-' END as 'Entrega Fondo',
Cod_orden as 'CODIGO ORDEN',
Case when CodInp=3 then '-' else Orden_N END as 'Numero Orden',
CFDO,CodInp,Nrotransferencia as 'Nro comprobante',monto as 'IMPORTE',Creado_o_modificado
from
(select * from 	expediente_detalle
                WHERE
                ( Fechadelmovimiento BETWEEN @primerdia
	AND DATE_SUB(@desde,INTERVAL 1 day) )
                            And
        (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @CUENTA)) Or
        SUBSTRING(Clave_expediente_detalle FROM 1 For CHAR_LENGTH(Clave_expediente_detalle) - 4) In
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @CUENTA))
        )original
       left join
				( select fechadelmovimiento as fechadelmovimiento_historial,MOV_TIPO as MOV_TIPO_historial,monto as monto_historial,clave_expediente_detalle as clave_expediente_detalle_historial,md5_relacionado as md5_relacionado_historial,Creado_o_modificado2 from
	expediente_detalle_historial where fechadelmovimiento BETWEEN @DESDE	AND @HASTA AND Creado_o_modificado2 > @HASTA group by clave_expediente_Detalle )historial
	on original.clave_expediente_detalle=historial.clave_expediente_detalle_historial
left join
(Select concat(nombres,' ',apellidos) as autor,usuario as usuario2 from contaduria_usuarios.usuarios)usuarios
on original.usuario=usuarios. usuario2;
order by fechadelmovimiento asc
"
                    Case False
                        'banco
                        Consultasql = "Select
DATE_FORMAT(fecha,'%d/%m/%Y')as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,Importe As 'Importe mov.',SALDO
FROM reportebanco
WHERE
	Cuenta =@cuenta
AND (
	fecha BETWEEN @primerdia
	AND @HASTA)
	ORDER BY FECHA ASC"
                End Select
            Case Is = "-CHEQUES SIN COBRAR EN BANCO "
                '6 LIBRO:  Cheques SIN COBRAR EN BANCO
                Consultasql = "Select DATE_FORMAT(fechadelmovimiento,'%d/%m/%Y')as 'Fecha',
Nrotransferencia as 'Nro comprobante',
Expediente_N,
CASE WHEN MONTO=0 THEN CONCAT('**ANULADO EL ',DATE_FORMAT(CREADO_O_MODIFICADO,'%d/%m/%Y'),'** ',DETALLE) ELSE DETALLE END as 'Extracto',
CASE WHEN MONTO=0 THEN MONTO_HISTORIAL ELSE MONTO END as 'IMPORTE',
Creado_o_modificado as 'ultima modificación',autor
FROM
(select * from 	expediente_detalle
WHERE
(ISNULL(MD5_RELACIONADO) OR Md5_relacionado not in (
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH'
FROM reportebanco where Fecha between @DESDE and @HASTA group by nro_transaccion )))
AND (MONTO <>0 OR CREADO_O_MODIFICADO>@HASTA)
AND
codinp=1
AND
(fechadelmovimiento BETWEEN @DESDE	AND @HASTA)
and Nrotransferencia in (select NRO_CHEQUE from tesoreria_cheques where CUENTA=@CUENTA)
	 AND NOT Mov_tipo='IPS'
AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @CUENTA)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @CUENTA)))original
				left join
				( select fechadelmovimiento as fechadelmovimiento_historial,MOV_TIPO as MOV_TIPO_historial,monto as monto_historial,clave_expediente_detalle as clave_expediente_detalle_historial,md5_relacionado as md5_relacionado_historial from
	expediente_detalle_historial where fechadelmovimiento BETWEEN @DESDE	AND @HASTA group by clave_expediente_Detalle )historial
	on original.clave_expediente_detalle=historial.clave_expediente_detalle_historial
left join
(Select concat(nombres,' ',apellidos) as autor,usuario from contaduria_usuarios.usuarios)usuarios
on original.usuario=usuarios. usuario
"
            Case Is = "-INGRESOS AÚN NO REGISTRADOS EN BANCO"
                '7 LIBRO:  INGRESOS SIN INGRESAR EN BANCO
                Consultasql = "Select DATE_FORMAT(fechadelmovimiento,'%d/%m/%Y')as 'Fecha',
Expediente_N,Detalle as 'Extracto',
Case when CodInp=3 then Orden_N else '-' END as 'Entrega Fondo',
Cod_orden as 'CODIGO ORDEN',
Case when CodInp=3 then '-' else Orden_N END as 'Numero Orden',
CFDO,CodInp,Nrotransferencia as 'Nro comprobante',monto as 'IMPORTE',Creado_o_modificado
from
(Select  SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,Fechadelmovimiento,Expediente_N,Detalle,Cod_orden,Orden_N,CFDO,CodInp,Nrotransferencia,monto,Creado_o_modificado,MD5_relacionado FROM expediente_detalle Where
 (Fechadelmovimiento BETWEEN @desde
	AND @hasta) AND Codinp=3  AND NOT Mov_tipo='IPS'  AND
	(ISNULL(MD5_relacionado) OR
(md5_relacionado in (Select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH' from reportebanco where fecha >@HASTA
 group by nro_transaccion
))) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo
				FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
				)A
order by fechadelmovimiento asc"
            Case Is = "-CHEQUES COBRADOS, NO REGISTRADOS EN LIBRO"
                '8 BANCO:  Cheques COBRADOS, NO REGISTRADOS EN LIBRO
                Consultasql = "Select
fecha as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,importe As 'Importe mov.'
FROM
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH',Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,SUM(IMPORTE) AS IMPORTE,SALDO as 'Saldo',
CASE WHEN importe>0 THEN md5(Nro_Transaccion+importe) ELSE md5(Nro_Transaccion+importe *-1) END as 'MD5S',CASE WHEN COUNT(CUENTA)=1 THEN '' ELSE
GROUP_CONCAT(Format(importe,2, 'es_AR'),' (',DATE_FORMAT(FECHA,'%d/%m/%Y'),' ', Descripcion,' ) ') END  as 'movimientos'
FROM reportebanco where CUENTA=@cuenta and Fecha BETWEEN @Desde AND @Hasta group by nro_transaccion )A
WHERE IMPORTE <0 AND
	 MD5HASH NOT IN (SELECT (CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE MD5_relacionado END) FROM expediente_detalle WHERE (fechadelmovimiento   BETWEEN @Desde AND @Hasta) GROUP BY MD5_RELACIONADO)
"
            Case Is = "-INGRESOS NO REGISTRADOS EN LIBRO"
                '9 BANCO:  INGRESOS NO REGISTRADOS EN LIBRO
                Consultasql = "Select
fecha as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,importe As 'Importe mov.'
FROM
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH',Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,SUM(IMPORTE) AS IMPORTE,SALDO as 'Saldo',
CASE WHEN importe>0 THEN md5(Nro_Transaccion+importe) ELSE md5(Nro_Transaccion+importe *-1) END as 'MD5S',CASE WHEN COUNT(CUENTA)=1 THEN '' ELSE
GROUP_CONCAT(Format(importe,2, 'es_AR'),' (',DATE_FORMAT(FECHA,'%d/%m/%Y'),' ', Descripcion,' ) ') END  as 'movimientos'
FROM reportebanco where CUENTA=@cuenta AND Fecha BETWEEN @Desde AND @Hasta group by nro_transaccion )A
	WHERE
IMPORTE >0 AND
	 MD5HASH NOT IN (SELECT (CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE MD5_relacionado END) FROM expediente_detalle WHERE (fechadelmovimiento   BETWEEN @Desde AND @Hasta) GROUP BY MD5_RELACIONADO)
"
            Case Is = "-CHEQUES RECHAZADOS"
                '10 BANCO:  Cheques RECHAZADOS
                Consultasql = "Select
fecha as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,importe As 'Importe mov.' FROM reportebanco
WHERE
	Cuenta =@cuenta
AND (
	fecha BETWEEN @DESDE
	AND @HASTA)  And CATEGORIA='CHEQUE RECHAZADO'"
            Case Is = "-COMISIONES BANCARIAS"
                '11 BANCO:  COMISIONES BANCARIAS
                Consultasql = "Select
fecha as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,importe As 'Importe mov.' FROM reportebanco
WHERE
	Cuenta =@cuenta
AND (
	fecha BETWEEN @DESDE
	AND @HASTA)  And CATEGORIA='COMISION BANCARIA'"
            Case Is = "-DEBITO FISCAL IVA BASICO"
                '12 BANCO:  DEBITO FISCAL IVA BASICO
                Consultasql = "Select
fecha as Fecha,Nro_Transaccion,Descripcion,CATEGORIA,importe As 'Importe mov.' FROM reportebanco
WHERE
	Cuenta =@cuenta
AND (
	fecha BETWEEN @DESDE
	AND @HASTA)  And CATEGORIA='DEBITO FISCAL IVA BASICO'"
            Case Is = "-MOVIMIENTOS SIN IPS"
                Consultasql = "Select DATE_FORMAT(fechadelmovimiento,'%d/%m/%Y')as 'Fecha',
Nrotransferencia as 'Nro comprobante',
Expediente_N,
CASE WHEN MONTO=0 THEN CONCAT('**ANULADO EL ',DATE_FORMAT(CREADO_O_MODIFICADO,'%d/%m/%Y'),'** ',DETALLE) ELSE DETALLE END as 'Extracto',
CASE WHEN MONTO=0 THEN MONTO_HISTORIAL ELSE MONTO END as 'IMPORTE',
Creado_o_modificado as 'ultima modificación',autor,MONTO_HISTORIAL
FROM
(select * from 	expediente_detalle
WHERE
(fechadelmovimiento BETWEEN @desde AND @HASTA)
and Nrotransferencia in (select NRO_CHEQUE from tesoreria_cheques where CUENTA=@CUENTA)
	 AND NOT Mov_tipo='IPS'
AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @CUENTA)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @CUENTA))
)DETALLE
left join
(Select concat(nombres,' ',apellidos) as autor,usuario from contaduria_usuarios.usuarios)usuarios
on DETALLE.usuario=usuarios. usuario
left join
				( select fechadelmovimiento as fechadelmovimiento_historial,MOV_TIPO as MOV_TIPO_historial,monto as monto_historial,clave_expediente_detalle as clave_expediente_detalle_historial,md5_relacionado as md5_relacionado_historial from
	expediente_detalle_historial where fechadelmovimiento BETWEEN @primerdia	AND @hasta group by clave_expediente_Detalle )historial
	on DETALLE.clave_expediente_detalle=historial.clave_expediente_detalle_historial"
            Case Is = "-IPS ACUMULADO"
                '13 LIBRO: IPS ACUMULADO
                'SERVIDORMYSQL.COMMANDSQL.Parameters.Remove("@MOV_TIPO")
                'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@MOV_TIPO", "IPS")
                Consultasql = "SELECT
SUBSTRING(Clave_expediente_detalle	FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4),Nrotransferencia,
DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
format(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
format(	sum(CASE WHEN CodInp=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
format(	(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN CodInp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
FROM
	expediente_detalle
WHERE ISNULL(MD5_RELACIONADO) AND
SUBSTRING(Clave_expediente_detalle	FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)   IN
(SELECT Clave_expediente	FROM	expediente WHERE clave_pedidofondo IN (SELECT	clave_pedidofondo	FROM	pedido_fondos	WHERE	Cuenta_pedidofondo = @cuenta))
AND (	fechadelmovimiento BETWEEN @primerdia	AND @hasta) AND Mov_tipo=@MOV_TIPO
GROUP BY nrotransferencia"
            Case Is = "-IPS"
                '13 LIBRO: IPS
                'SERVIDORMYSQL.COMMANDSQL.Parameters.Remove("@MOV_TIPO")
                'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@MOV_TIPO", "IPS")
                Consultasql = "SELECT
DETALLE,Nrotransferencia,
DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde',
DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
format((CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
format(	(CASE WHEN CodInp=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
format(	((CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END )-(CASE WHEN CodInp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
FROM
	expediente_detalle
WHERE ISNULL(MD5_RELACIONADO) AND
SUBSTRING(Clave_expediente_detalle	FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)   IN
(SELECT Clave_expediente	FROM	expediente WHERE clave_pedidofondo IN (SELECT	clave_pedidofondo	FROM	pedido_fondos	WHERE	Cuenta_pedidofondo = @cuenta))
AND (	fechadelmovimiento BETWEEN @DESDE	AND @hasta) AND Mov_tipo=@MOV_TIPO"
            Case Else
                'SERVIDORMYSQL.COMMANDSQL.Parameters.Remove("@MOV_TIPO")
                'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@MOV_TIPO", nombrereporte.Replace("-", ""))
                Consultasql = "Select DATE_FORMAT(fechadelmovimiento,'%d/%m/%Y')as 'Fecha',
Nrotransferencia as 'Nro comprobante',
Expediente_N,
CASE WHEN MONTO=0 THEN CONCAT('**ANULADO EL ',DATE_FORMAT(CREADO_O_MODIFICADO,'%d/%m/%Y'),'** ',DETALLE) ELSE DETALLE END as 'Extracto',
CASE WHEN MONTO=0 THEN MONTO_HISTORIAL ELSE MONTO END as 'IMPORTE',
Creado_o_modificado as 'ultima modificación',autor,MONTO_HISTORIAL
FROM
(select * from 	expediente_detalle
WHERE
(ISNULL(MD5_RELACIONADO) OR Md5_relacionado not in (
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH'
FROM reportebanco where Fecha between @DESDE and @HASTA group by nro_transaccion )))
AND (MONTO <>0 OR CREADO_O_MODIFICADO>@HASTA)
AND
codinp=1
AND
(fechadelmovimiento BETWEEN @DESDE	AND @HASTA)
and Nrotransferencia in (select NRO_CHEQUE from tesoreria_cheques where CUENTA=@CUENTA)
AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @CUENTA)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @CUENTA)))original
left join
(Select concat(nombres,' ',apellidos) as autor,usuario from contaduria_usuarios.usuarios)usuarios
on original.usuario=usuarios. usuario
				left join
				( select fechadelmovimiento as fechadelmovimiento_historial,MOV_TIPO as MOV_TIPO_historial,monto as monto_historial,clave_expediente_detalle as clave_expediente_detalle_historial,md5_relacionado as md5_relacionado_historial from
	expediente_detalle_historial where fechadelmovimiento BETWEEN @DESDE	AND @HASTA group by clave_expediente_Detalle )historial
	on original.clave_expediente_detalle=historial.clave_expediente_detalle_historial"
        End Select
        Return Consultasql
    End Function

    Private Function Generaciondatatable(ByRef consultasql As String) As DataTable
        Dim Tablatemporal As New DataTable
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Libro_Banco(ByVal TIPO As Integer) As DataTable
        Dim Tablatemporal As New DataTable
        'FECHA
        'OP
        'PF
        'CLASE
        'Expediente
        'CHEQUE
        'IMPORTE
        'BENEFICIARIO
        '99 ES RETENCIONES
        '98 ES HABERES
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@EJERCICIO", Autorizaciones.Year)
        Select Case TIPO
            Case Is = 98
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CODINP", 1)
            Case Is = 33
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CODINP", 3)
            Case Else
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CODINP", TIPO)
        End Select
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@YEAR", Autorizaciones.Year)
        Dim consultasql As String
        Select Case TIPO
            Case Is = 99
                consultasql = "
Select
Fechadelmovimiento AS 'FECHA',
 CASE WHEN (MONTO<>0) THEN ( CASE WHEN (MONTO<0) THEN CONCAT(Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat(b.ordencargo) else '' END	END	) ELSE
 (Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat(b.ordencargo) else '0' END	END	) END)	ELSE 'ANULADO' END AS 'ORDEN',
 CASE WHEN (MONTO<>0) THEN	(CASE WHEN NOT ISNULL(B.clave_pedidofondo) THEN  CONCAT (CONVERT((SUBSTRING(B.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(B.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(B.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(B.clave_pedidofondo) - 9) )  ELSE 'S/D' END )	ELSE 'ANULADO' END AS 'PF',
 CASE WHEN (MONTO<>0) THEN	(D.CLASE 	)	ELSE 'ANULADO' END AS 'CLASE',
(Expediente_N 	) 'Expediente',
 Nrotransferencia AS 'Nro Transferencia',
 MONTO AS 'IMPORTE',
 CASE WHEN (MONTO<>0) THEN
 (
 CASE WHEN ISNULL(C.PROVEEDOR) OR (C.PROVEEDOR='AFIP') OR (C.PROVEEDOR LIKE '%SERVICIO ADMINISTRATIVO%') THEN
CASE WHEN (MONTO>0) THEN CONCAT(A.DETALLE,  '*')  ELSE CONCAT('[REVERSIÓN]',CONCAT(A.DETALLE,  '*') ) END
 ELSE
  CASE WHEN (MONTO>0) THEN C.PROVEEDOR ELSE CONCAT('[REVERSIÓN]',C.PROVEEDOR) END
 END
 )
 ELSE 'ANULADO' END AS 'BENEFICIARIO',
 Cod_orden,cfdo,CodInp,TOTAL_TRANSF,
Concat(u.apellidos,' ',u.nombres) as 'Autor',Creado_o_modificado as 'Cargado el:',A.Clave_expedientetrim as 'Clave_expediente',cuenta_pedidofondo
from
(
select * from
/* Movimientos creados dentro de la fecha */
(select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where  NOT(NROTRANSFERENCIA=0)   and
/*DETERMINACIÓN DE QUE EL MOVIMIENTO SE ENCUENTRA DENTRO LA CUENTA SELECCIONADA*/
/* SE DETERMINA QUE EL PEDIDO DE FONDO ASOCIADO AL MOVIMIENTO SE ENCUENTRA DENTRO DE LA CUENTA SELECCIONADA*/
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
IN
        (
Select clave_expediente from
((select clave_expediente,clave_pedidofondo from cuit_movimiento
union all
select clave_expediente,clave_pedidofondo  from expediente where not isnull(clave_pedidofondo)
)cuites
inner join
(select clave_pedidofondo from pedido_fondos)pedfon
on cuites.clave_pedidofondo=pedfon.clave_pedidofondo
)
)
/* FIN - SE DETERMINA QUE EL PEDIDO DE FONDO ASOCIADO AL MOVIMIENTO SE ENCUENTRA DENTRO DE LA CUENTA SELECCIONADA*/
				OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE not ISNULL(cuenta_especial))
/*FIN - DETERMINACIÓN DE QUE EL MOVIMIENTO SE ENCUENTRA DENTRO LA CUENTA SELECCIONADA*/
				)
AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) OR
(date(Creado_o_modificado)= date(@DESDE) OR date(Creado_o_modificado)=date(@HASTA))
)
				union all
/* Movimientos MODIFICADOS dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where  NOT(NROTRANSFERENCIA=0)   AND
(
not (date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo )) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
						AND Fechadelmovimiento>CONCAT(@YEAR -1,'-12-31')
				union all
				/* Movimientos EN NEGATIVO dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto *-1,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle_HISTORIAL
where   NOT(NROTRANSFERENCIA=0) AND NOT(MOV_TIPO='IPS') AND  CLAVE_EXPEDIENTE_DETALLE IN
(select Clave_expediente_detalle
 from expediente_detalle
where
   NOT(NROTRANSFERENCIA=0)   AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN
					(SELECT clave_pedidofondo FROM pedido_fondos )) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente )))
				AND Fechadelmovimiento>CONCAT(@YEAR -1,'-12-31')
				)
				GROUP BY CLAVE_EXPEDIENTE_DETALLE
				)J
where CLAVE_EXPEDIENTE_DETALLE  in (select Retencion_Clave_detalle from retenciones where not isnull(Retencion_Clave_detalle))
				)A
/* DATOS DE LOS EXPEDIENTES*/
LEFT JOIN
(
select Clave_pedidofondo,pedfondos.CLAVE_EXPEDIENTE,
CASE WHEN NOT ISNULL(clave_ordenpago) THEN
CASE WHEN LENGTH(Clave_Ordenpago)>8 THEN
CLAVE_TO_NUMEROYANIO(clave_ordenpago)
ELSE
ORDENPAGO
END
ELSE
ORDENPAGO END
AS ORDENPAGO,
ORDENCARGO
 from
(
select max(clave_pedidofondo)as Clave_pedidofondo,clave_expediente,max(Ordenpago) AS Ordenpago,max(ordencargo) AS ordencargo from
(select CLAVE_EXPEDIENTE,Clave_pedidofondo,NULL as Ordenpago, NULL as ordencargo  from cuit_movimiento
union all
select clave_expediente,Clave_pedidofondo,Ordenpago,ordencargo from expediente
)pedfondos1
group by clave_expediente)pedfondos
left join
(select max(clave_ordenpago) as clave_ordenpago,clave_expediente from contabilidad_ordenpago group by clave_expediente)ordenespago
on pedfondos.clave_expediente=ordenespago.clave_expediente
)b
On A.Clave_expedientetrim=B.Clave_expediente
/* DATOS DE LOS CHEQUES */
LEFT JOIN
(SELECT Nrotransferencia AS CHEQUE, SUM(MONTO) AS 'TOTAL_TRANSF' FROM expediente_detalle GROUP BY Nrotransferencia)T
On A.Nrotransferencia=T.CHEQUE
/* DATOS DE LOS PROVEEDORES*/
LEFT JOIN
(SELECT CUIT,PROVEEDOR FROM proveedores WHERE NOT CUIT=0)C
On A.CUIT=C.CUIT
/* DATOS DE PEDIDOS DE FONDOS*/
LEFT JOIN
(SELECT clave_pedidofondo,CASE WHEN (CLASE_FONDO=@EJERCICIO) THEN 'EJ.' ELSE CONCAT('RP/',CLASE_FONDO) END   AS 'CLASE',CLASE_FONDO FROM pedido_fondos WHERE NOT CLASE_FONDO=1)D
On B.CLAVE_PEDIDOFONDO=D.CLAVE_PEDIDOFONDO
/* DATOS DE USUARIOS*/
LEFT JOIN
(SELECT usuario,apellidos,nombres FROM contaduria_usuarios.usuarios )U
On A.usuario=U.usuario
LEFT JOIN
(SELECT Cuenta_pedidofondo,clave_pedidofondo FROM pedido_fondos )pffodos
On pffodos.clave_pedidofondo=b.clave_pedidofondo
 ORDER BY CLAVE_EXPEDIENTE_DETALLE,MONTO ASC
"
                'CASO HABERES
            Case Is = 98
                consultasql = "Select
Creado_o_modificado AS 'FECHA',
 CASE WHEN (MONTO<>0) THEN ( CASE WHEN (MONTO<0) THEN CONCAT('*MODIF.*',Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) ELSE
				(Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) END)	ELSE 'ANULADO' END AS 'ORDEN',
 CASE WHEN (MONTO<>0) THEN	(CASE WHEN NOT ISNULL(B.clave_pedidofondo) THEN  CONCAT (CONVERT((SUBSTRING(B.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(B.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(B.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(B.clave_pedidofondo) - 9) )  ELSE 'S/D' END )	ELSE 'ANULADO' END AS 'PF',
 CASE WHEN (MONTO<>0) THEN	(D.CLASE 	)	ELSE 'ANULADO' END AS 'CLASE',
(Expediente_N 	) 'Expediente',
 Nrotransferencia AS 'Nro Transferencia',
 MONTO AS 'IMPORTE',
 CASE WHEN (MONTO<>0) THEN
 ( CASE WHEN ISNULL(C.PROVEEDOR) OR (C.PROVEEDOR='AFIP') OR (C.PROVEEDOR LIKE '%SERVICIO ADMINISTRATIVO%') THEN CONCAT(A.DETALLE,  '*') ELSE C.PROVEEDOR END )
 ELSE 'ANULADO' END AS 'BENEFICIARIO',
 Cod_orden,cfdo,CodInp,TOTAL_TRANSF,
Concat(u.apellidos,' ',u.nombres) as 'Autor',Creado_o_modificado as 'Cargado el:',A.Clave_expedientetrim as 'Clave_expediente'
from
(
select * from
/* Movimientos creados dentro de la fecha */
(select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where (MOV_TIPO= 'GANANCIAS DEL PERSONAL' OR
MOV_TIPO= 'GREMIOS' OR
MOV_TIPO= 'HABERES' OR
MOV_TIPO= 'JUDICIALES' OR
MOV_TIPO= 'SEGUROS' OR
MOV_TIPO= 'REINTEGROS')  AND NOT(NROTRANSFERENCIA=0) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) OR
(date(Creado_o_modificado)= date(@DESDE) OR date(Creado_o_modificado)=date(@HASTA))
)
								union all
/* Movimientos MODIFICADOS dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where (MOV_TIPO= 'GANANCIAS DEL PERSONAL' OR
MOV_TIPO= 'GREMIOS' OR
MOV_TIPO= 'HABERES' OR
MOV_TIPO= 'JUDICIALES' OR
MOV_TIPO= 'SEGUROS' OR
MOV_TIPO= 'REINTEGROS') AND NOT(NROTRANSFERENCIA=0) AND
(
not (date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
				union all
				/* Movimientos EN NEGATIVO dentro de la fecha */
				select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto *-1,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle_HISTORIAL
where    NOT(NROTRANSFERENCIA=0) AND  CLAVE_EXPEDIENTE_DETALLE IN
(select Clave_expediente_detalle
 from expediente_detalle
where
 (MOV_TIPO= 'GANANCIAS DEL PERSONAL' OR
MOV_TIPO= 'GREMIOS' OR
MOV_TIPO= 'HABERES' OR
MOV_TIPO= 'JUDICIALES' OR
MOV_TIPO= 'SEGUROS' OR
MOV_TIPO= 'REINTEGROS') AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN
					(SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
				)
				GROUP BY CLAVE_EXPEDIENTE_DETALLE
				)J
where CLAVE_EXPEDIENTE_DETALLE not in (select Retencion_Clave_detalle from retenciones where not isnull(Retencion_Clave_detalle))
				)A
/* DATOS DE LOS EXPEDIENTES*/
LEFT JOIN
(SELECT Clave_expediente,clave_pedidofondo,Ordenpago,ordencargo FROM EXPEDIENTE)b
On A.Clave_expedientetrim=B.Clave_expediente
/* DATOS DE LOS CHEQUES */
LEFT JOIN
(SELECT Nrotransferencia AS CHEQUE, SUM(MONTO) AS 'TOTAL_TRANSF' FROM expediente_detalle GROUP BY Nrotransferencia)T
On A.Nrotransferencia=T.CHEQUE
/* DATOS DE LOS PROVEEDORES*/
LEFT JOIN
(SELECT CUIT,PROVEEDOR FROM proveedores WHERE NOT CUIT=0)C
On A.CUIT=C.CUIT
/* DATOS DE PEDIDOS DE FONDOS*/
LEFT JOIN
(SELECT clave_pedidofondo,CASE WHEN (CLASE_FONDO=@EJERCICIO) THEN 'EJ.' ELSE CONCAT('RP/',CLASE_FONDO) END   AS 'CLASE',CLASE_FONDO FROM pedido_fondos WHERE NOT CLASE_FONDO=1)D
On B.CLAVE_PEDIDOFONDO=D.CLAVE_PEDIDOFONDO
/* DATOS DE USUARIOS*/
LEFT JOIN
(SELECT usuario,apellidos,nombres FROM contaduria_usuarios.usuarios )U
On A.usuario=U.usuario
 ORDER BY CLAVE_EXPEDIENTE_DETALLE,MONTO ASC"
            Case Is = 97
                consultasql = ""
            Case Is = 3
                consultasql = "Select
Creado_o_modificado AS 'FECHA',
 CASE WHEN (MONTO<>0) THEN ( CASE WHEN (MONTO<0) THEN CONCAT('*MODIF.*',Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) ELSE
				(Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) END)	ELSE 'ANULADO' END AS 'ORDEN',
 CASE WHEN (MONTO<>0) THEN	(CASE WHEN NOT ISNULL(B.clave_pedidofondo) THEN  CONCAT (CONVERT((SUBSTRING(B.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(B.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(B.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(B.clave_pedidofondo) - 9) )  ELSE 'S/D' END )	ELSE 'ANULADO' END AS 'PF',
 CASE WHEN (MONTO<>0) THEN	(D.CLASE 	)	ELSE 'ANULADO' END AS 'CLASE',
(Expediente_N 	) 'Expediente',
 Nrotransferencia AS 'Nro Transferencia',
 MONTO AS 'IMPORTE',
 CASE WHEN (MONTO<>0) THEN
 ( CASE WHEN ISNULL(C.PROVEEDOR) OR (C.PROVEEDOR='AFIP') OR (C.PROVEEDOR LIKE '%SERVICIO ADMINISTRATIVO%') THEN CONCAT(A.DETALLE,  '*') ELSE C.PROVEEDOR END )
 ELSE 'ANULADO' END AS 'BENEFICIARIO',
 Cod_orden,cfdo,CodInp,TOTAL_TRANSF,
Concat(u.apellidos,' ',u.nombres) as 'Autor',Creado_o_modificado as 'Cargado el:',A.Clave_expedientetrim as 'Clave_expediente'
from
(
select * from
/* Movimientos creados dentro de la fecha */
(select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where CODINP=@CODINP  AND NOT(NROTRANSFERENCIA=0)   and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) OR
(date(Creado_o_modificado)= date(@DESDE) OR date(Creado_o_modificado)=date(@HASTA))
)
				union all
/* Movimientos MODIFICADOS dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where CODINP=@CODINP AND NOT(NROTRANSFERENCIA=0)   AND
(
not (date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
				union all
				/* Movimientos EN NEGATIVO dentro de la fecha */
				select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto *-1,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle_HISTORIAL
where   NOT(NROTRANSFERENCIA=0)   AND  CLAVE_EXPEDIENTE_DETALLE IN
(select Clave_expediente_detalle
 from expediente_detalle
where
 CODINP=@CODINP AND NOT(NROTRANSFERENCIA=0)   AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN
					(SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
				)
				GROUP BY CLAVE_EXPEDIENTE_DETALLE
				)J
where CLAVE_EXPEDIENTE_DETALLE not in (select Retencion_Clave_detalle from retenciones where not isnull(Retencion_Clave_detalle))
				)A
/* DATOS DE LOS EXPEDIENTES*/
LEFT JOIN
(SELECT Clave_expediente,clave_pedidofondo,Ordenpago,ordencargo FROM EXPEDIENTE)b
On A.Clave_expedientetrim=B.Clave_expediente
/* DATOS DE LOS CHEQUES */
LEFT JOIN
(SELECT Nrotransferencia AS CHEQUE, SUM(MONTO) AS 'TOTAL_TRANSF' FROM expediente_detalle GROUP BY Nrotransferencia)T
On A.Nrotransferencia=T.CHEQUE
/* DATOS DE LOS PROVEEDORES*/
LEFT JOIN
(SELECT CUIT,PROVEEDOR FROM proveedores WHERE NOT CUIT=0)C
On A.CUIT=C.CUIT
/* DATOS DE PEDIDOS DE FONDOS*/
LEFT JOIN
(SELECT clave_pedidofondo,CASE WHEN (CLASE_FONDO=@EJERCICIO) THEN 'EJ.' ELSE CONCAT('RP/',CLASE_FONDO) END   AS 'CLASE',CLASE_FONDO FROM pedido_fondos WHERE NOT CLASE_FONDO=1)D
On B.CLAVE_PEDIDOFONDO=D.CLAVE_PEDIDOFONDO
/* DATOS DE USUARIOS*/
LEFT JOIN
(SELECT usuario,apellidos,nombres FROM contaduria_usuarios.usuarios )U
On A.usuario=U.usuario
 ORDER BY CLAVE_EXPEDIENTE_DETALLE,MONTO ASC"
            Case Is = 33
                consultasql = "Select
CASE WHEN (MONTO<>0) THEN	(CASE WHEN NOT ISNULL(B.clave_pedidofondo) THEN  CONCAT (CONVERT((SUBSTRING(B.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(B.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(B.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(B.clave_pedidofondo) - 9) )  ELSE 'S/D' END )	ELSE 'ANULADO' END AS 'N. PED. FONDO',
 CASE WHEN (MONTO<>0) THEN ( CASE WHEN (MONTO<0) THEN CONCAT('*MODIF.*',Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) ELSE (Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) END)	ELSE 'ANULADO' END AS 'O.ENT',
CASE WHEN (MONTO<>0) THEN	(D.CLASE 	)	ELSE 'ANULADO' END AS 'IMPUTAC.',
'' AS 'TRANSF.TG.',
CASE WHEN ISNULL(D.Cuenta_pedidofondo) THEN CONCAT(SUBSTRING(B.Cuenta_especial FROM 6 FOR 9),'/',SUBSTRING(D.B.Cuenta_especial FROM 15 FOR 1))  ELSE
CONCAT(SUBSTRING(D.Cuenta_pedidofondo FROM 6 FOR 9),'/',SUBSTRING(D.Cuenta_pedidofondo FROM 15 FOR 1)) END AS 'CTA.CTE',
 Nrotransferencia AS 'COMPROB.',
 '' AS 'FECHA DE INGRESO',
Fechadelmovimiento AS 'FECHA DE PAGO',
(Expediente_N 	) 'Expediente',
 MONTO AS 'IMPORTE',
 CASE WHEN (MONTO<>0) THEN
 ( CASE WHEN ISNULL(C.PROVEEDOR) OR (C.PROVEEDOR='AFIP') OR (C.PROVEEDOR LIKE '%SERVICIO ADMINISTRATIVO%') THEN CONCAT(A.DETALLE,  '*') ELSE C.PROVEEDOR END )
 ELSE 'ANULADO' END AS 'DETALLE',
TOTAL_TRANSF,
Concat(u.apellidos,' ',u.nombres) as 'Autor',Creado_o_modificado as 'Cargado el:',A.Clave_expedientetrim as 'Clave_expediente'
from
(
select * from
/* Movimientos creados dentro de la fecha */
(select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where CODINP=@CODINP  AND NOT(NROTRANSFERENCIA=0)   and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos )) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente ))
AND
((date(Fechadelmovimiento)>= date(@DESDE) and date(Fechadelmovimiento)<=date(@HASTA)) OR
(date(Fechadelmovimiento)= date(@DESDE) OR date(Fechadelmovimiento)=date(@HASTA))
)
				union all
/* Movimientos MODIFICADOS dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where CODINP=@CODINP AND NOT(NROTRANSFERENCIA=0)   AND
(
not (date(Fechadelmovimiento)>= date(@DESDE) and date(Fechadelmovimiento)<=date(@HASTA)) and
(date(Fechadelmovimiento)>= date(@DESDE) and date(Fechadelmovimiento)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos )) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente )))
				union all
				/* Movimientos EN NEGATIVO dentro de la fecha */
				select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto *-1,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle_HISTORIAL
where   NOT(NROTRANSFERENCIA=0)   AND  CLAVE_EXPEDIENTE_DETALLE IN
(select Clave_expediente_detalle
 from expediente_detalle
where
 CODINP=@CODINP AND NOT(NROTRANSFERENCIA=0)   AND
((date(Fechadelmovimiento)>= date(@DESDE) and date(Fechadelmovimiento)<=date(@HASTA)) and
(date(Fechadelmovimiento)>= date(@DESDE) and date(Fechadelmovimiento)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN
					(SELECT clave_pedidofondo FROM pedido_fondos )) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente  )))
				)
				GROUP BY CLAVE_EXPEDIENTE_DETALLE
				)J
where CLAVE_EXPEDIENTE_DETALLE not in (select Retencion_Clave_detalle from retenciones where not isnull(Retencion_Clave_detalle))
				)A
/* DATOS DE LOS EXPEDIENTES*/
LEFT JOIN
(SELECT Clave_expediente,clave_pedidofondo,Ordenpago,ordencargo,Cuenta_especial  FROM EXPEDIENTE)b
On A.Clave_expedientetrim=B.Clave_expediente
/* DATOS DE LOS CHEQUES */
LEFT JOIN
(SELECT Nrotransferencia AS CHEQUE, SUM(MONTO) AS 'TOTAL_TRANSF' FROM expediente_detalle GROUP BY Nrotransferencia)T
On A.Nrotransferencia=T.CHEQUE
/* DATOS DE LOS PROVEEDORES*/
LEFT JOIN
(SELECT CUIT,PROVEEDOR FROM proveedores WHERE NOT CUIT=0)C
On A.CUIT=C.CUIT
/* DATOS DE PEDIDOS DE FONDOS*/
LEFT JOIN
(SELECT clave_pedidofondo,CASE WHEN (CLASE_FONDO=@EJERCICIO) THEN 'EJ.' ELSE CONCAT('RP/',CLASE_FONDO) END   AS 'CLASE',CLASE_FONDO,Cuenta_pedidofondo FROM pedido_fondos WHERE NOT CLASE_FONDO=1)D
On B.CLAVE_PEDIDOFONDO=D.CLAVE_PEDIDOFONDO
/* DATOS DE USUARIOS*/
LEFT JOIN
(SELECT usuario,apellidos,nombres FROM contaduria_usuarios.usuarios )U
On A.usuario=U.usuario
 ORDER BY D.CLAVE_PEDIDOFONDO,CLAVE_EXPEDIENTE_DETALLE,MONTO ASC"
            Case Is = 34
                consultasql = "SELECT
	TESGRAL.FECHA,
	TESGRAL.MOVIMIENTOS,
	TESGRAL.MONTO_CARGADO,
	BANCO,SIN_IPS,IPS,
	TESGRAL.SIN_IPS - BANCO AS 'DIFERENCIA BANCO',
	GROUP_CONCAT(AgrupadoSum) as 'sumado por cuenta'
FROM
	(
	SELECT
		FECHADELMOVIMIENTO AS 'FECHA',
		COUNT( FECHADELMOVIMIENTO ) AS 'MOVIMIENTOS',
		sum(MONTO) AS 'MONTO_CARGADO',
		sum(case when not mov_tipo='IPS' then  MONTO else 0 end) AS 'SIN_IPS',
		sum(case when mov_tipo='IPS' then  MONTO else 0 end) AS 'IPS'
	FROM
		EXPEDIENTE_DETALLE
	WHERE
	FECHADELMOVIMIENTO BETWEEN @DESDE AND @HASTA
		AND CODINP = 3
	GROUP BY
		DATE( FECHADELMOVIMIENTO )
	ORDER BY
		Fechadelmovimiento
	) TESGRAL
	LEFT JOIN ( SELECT SUM( Importe ) AS 'BANCO', Fecha FROM reportebanco WHERE IMPORTE > 0 GROUP BY FECHA ) BANCO ON TESGRAL.FECHA = BANCO.FECHA
		LEFT JOIN ( SELECT concat(SUM( Importe ),' (',cuenta,')') as 'AgrupadoSum',SUM( Importe ) AS 'BANCO2', Fecha,cuenta FROM reportebanco WHERE IMPORTE > 0 GROUP BY FECHA,Cuenta) BANCO2 ON TESGRAL.FECHA = BANCO.FECHA
		group by TESGRAL.FECHA
"
            Case Else
                consultasql = "
Select
Creado_o_modificado AS 'FECHA',
 CASE WHEN (MONTO<>0) THEN ( CASE WHEN (MONTO<0) THEN CONCAT(Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat(b.ordencargo) else '' END	END	) ELSE
				(Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) END)	ELSE 'ANULADO' END AS 'ORDEN',
 CASE WHEN (MONTO<>0) THEN	(CASE WHEN NOT ISNULL(B.clave_pedidofondo) THEN  CONCAT (CONVERT((SUBSTRING(B.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(B.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(B.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(B.clave_pedidofondo) - 9) )  ELSE 'S/D' END )	ELSE 'ANULADO' END AS 'PF',
 CASE WHEN (MONTO<>0) THEN	(D.CLASE 	)	ELSE 'ANULADO' END AS 'CLASE',
(Expediente_N 	) 'Expediente',
 Nrotransferencia AS 'Nro Transferencia',
 MONTO AS 'IMPORTE',
 CASE WHEN (MONTO<>0) THEN
 (
 CASE WHEN ISNULL(C.PROVEEDOR) OR (C.PROVEEDOR='AFIP') OR (C.PROVEEDOR LIKE '%SERVICIO ADMINISTRATIVO%') THEN
CASE WHEN (MONTO>0) THEN CONCAT(A.DETALLE,  '*')  ELSE CONCAT('[REVERSIÓN]',CONCAT(A.DETALLE,  '*') ) END
 ELSE
  CASE WHEN (MONTO>0) THEN C.PROVEEDOR ELSE CONCAT('[REVERSIÓN]',C.PROVEEDOR) END
 END
 )
 ELSE 'ANULADO' END AS 'BENEFICIARIO',
 Cod_orden,cfdo,CodInp,TOTAL_TRANSF,
Concat(u.apellidos,' ',u.nombres) as 'Autor',Creado_o_modificado as 'Cargado el:',A.Clave_expedientetrim as 'Clave_expediente'
from
(
select * from
/* Movimientos creados dentro de la fecha */
(select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where CODINP=@CODINP  AND NOT(NROTRANSFERENCIA=0) AND NOT(MOV_TIPO='IPS') and
/*DETERMINACIÓN DE QUE EL MOVIMIENTO SE ENCUENTRA DENTRO LA CUENTA SELECCIONADA*/
/* SE DETERMINA QUE EL PEDIDO DE FONDO ASOCIADO AL MOVIMIENTO SE ENCUENTRA DENTRO DE LA CUENTA SELECCIONADA*/
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
IN
        (select clave_expediente from
((select clave_expediente,clave_pedidofondo from cuit_movimiento
union all
select clave_expediente,clave_pedidofondo  from expediente where not isnull(clave_pedidofondo)
)cuites
inner join
(select clave_pedidofondo from pedido_fondos where Cuenta_pedidofondo=@cuenta)pedfon
on cuites.clave_pedidofondo=pedfon.clave_pedidofondo
)
)
/* FIN - SE DETERMINA QUE EL PEDIDO DE FONDO ASOCIADO AL MOVIMIENTO SE ENCUENTRA DENTRO DE LA CUENTA SELECCIONADA*/
				OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)
/*FIN - DETERMINACIÓN DE QUE EL MOVIMIENTO SE ENCUENTRA DENTRO LA CUENTA SELECCIONADA*/
				)
AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) OR
(date(Creado_o_modificado)= date(@DESDE) OR date(Creado_o_modificado)=date(@HASTA))
)
				union all
/* Movimientos MODIFICADOS dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where CODINP=@CODINP AND NOT(NROTRANSFERENCIA=0) AND NOT(MOV_TIPO='IPS') AND
(
not (date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
						AND Fechadelmovimiento>CONCAT(@YEAR -1,'-12-31')
				union all
				/* Movimientos EN NEGATIVO dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto *-1,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle_HISTORIAL
where   NOT(NROTRANSFERENCIA=0) AND NOT(MOV_TIPO='IPS') AND  CLAVE_EXPEDIENTE_DETALLE IN
(select Clave_expediente_detalle
 from expediente_detalle
where
 CODINP=@CODINP AND NOT(NROTRANSFERENCIA=0) AND NOT(MOV_TIPO='IPS') AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN
					(SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
				AND Fechadelmovimiento>CONCAT(@YEAR -1,'-12-31')
				)
				GROUP BY CLAVE_EXPEDIENTE_DETALLE
				)J
where CLAVE_EXPEDIENTE_DETALLE not in (select Retencion_Clave_detalle from retenciones where not isnull(Retencion_Clave_detalle))
				)A
/* DATOS DE LOS EXPEDIENTES*/
LEFT JOIN
(SELECT Clave_expediente,clave_pedidofondo,Ordenpago,ordencargo FROM EXPEDIENTE)b
On A.Clave_expedientetrim=B.Clave_expediente
/* DATOS DE LOS CHEQUES */
LEFT JOIN
(SELECT Nrotransferencia AS CHEQUE, SUM(MONTO) AS 'TOTAL_TRANSF' FROM expediente_detalle GROUP BY Nrotransferencia)T
On A.Nrotransferencia=T.CHEQUE
/* DATOS DE LOS PROVEEDORES*/
LEFT JOIN
(SELECT CUIT,PROVEEDOR FROM proveedores WHERE NOT CUIT=0)C
On A.CUIT=C.CUIT
/* DATOS DE PEDIDOS DE FONDOS*/
LEFT JOIN
(SELECT clave_pedidofondo,CASE WHEN (CLASE_FONDO=@EJERCICIO) THEN 'EJ.' ELSE CONCAT('RP/',CLASE_FONDO) END   AS 'CLASE',CLASE_FONDO FROM pedido_fondos WHERE NOT CLASE_FONDO=1)D
On B.CLAVE_PEDIDOFONDO=D.CLAVE_PEDIDOFONDO
/* DATOS DE USUARIOS*/
LEFT JOIN
(SELECT usuario,apellidos,nombres FROM contaduria_usuarios.usuarios )U
On A.usuario=U.usuario
 ORDER BY CLAVE_EXPEDIENTE_DETALLE,MONTO ASC
"
                'consultasql = "Select
                'Creado_o_modificado AS 'FECHA',
                ' CASE WHEN (MONTO<>0) THEN ( CASE WHEN (MONTO<0) THEN CONCAT('*MODIF.*',Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) ELSE
                '				(Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat('O.C-' ,b.ordencargo) else 'S/D' END	END	) END)	ELSE 'ANULADO' END AS 'ORDEN',
                ' CASE WHEN (MONTO<>0) THEN	(CASE WHEN NOT ISNULL(B.clave_pedidofondo) THEN  CONCAT (CONVERT((SUBSTRING(B.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(B.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(B.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(B.clave_pedidofondo) - 9) )  ELSE 'S/D' END )	ELSE 'ANULADO' END AS 'PF',
                ' CASE WHEN (MONTO<>0) THEN	(D.CLASE 	)	ELSE 'ANULADO' END AS 'CLASE',
                'CASE WHEN (MONTO<>0) THEN	(Expediente_N 	)	ELSE 'ANULADO' END AS 'Expediente',
                ' Nrotransferencia AS 'Nro Transferencia',
                ' MONTO AS 'IMPORTE',
                ' CASE WHEN (MONTO<>0) THEN	( CASE WHEN ISNULL(C.PROVEEDOR) OR (C.PROVEEDOR='AFIP') OR (C.PROVEEDOR LIKE '%SERVICIO ADMINISTRATIVO%') THEN REPLACE(A.DETALLE, C.PROVEEDOR, '*') ELSE C.PROVEEDOR END )	ELSE 'ANULADO' END AS 'BENEFICIARIO',
                ' Cod_orden,cfdo,CodInp,TOTAL_TRANSF,
                'Concat(u.apellidos,' ',u.nombres) as 'Autor',Creado_o_modificado as 'Cargado el:',A.Clave_expedientetrim as 'Clave_expediente'
                'from
                '(
                'select * from
                '/* Movimientos creados dentro de la fecha */
                '(select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
                'Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
                'Creado_o_modificado,MD5_relacionado,Usuario
                ' from expediente_detalle
                'where CODINP=1  and
                '(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
                'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
                'AND
                '((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) OR
                '(date(Creado_o_modificado)= date(@DESDE) OR date(Creado_o_modificado)=date(@HASTA))
                ')
                '				union all
                '/* Movimientos MODIFICADOS dentro de la fecha */
                'select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
                'Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
                'Creado_o_modificado,MD5_relacionado,Usuario
                ' from expediente_detalle
                'where CODINP=1 AND
                '(
                'not (date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
                '(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
                '(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
                'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
                '				union all
                '				/* Movimientos EN NEGATIVO dentro de la fecha */
                '				select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
                'Clave_expediente_detalle,Expediente_N,Detalle,Monto *-1,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
                'Creado_o_modificado,MD5_relacionado,Usuario
                ' from expediente_detalle_HISTORIAL
                'where CLAVE_EXPEDIENTE_DETALLE IN
                '(select Clave_expediente_detalle
                ' from expediente_detalle
                'where
                ' CODINP=1 AND
                '(not (date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
                '(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
                '(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
                'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
                '				)
                '				GROUP BY CLAVE_EXPEDIENTE_DETALLE
                '				)J
                'where CLAVE_EXPEDIENTE_DETALLE not in (select Retencion_Clave_detalle from retenciones where not isnull(Retencion_Clave_detalle))
                '				)A
                '/* DATOS DE LOS EXPEDIENTES*/
                'LEFT JOIN
                '(SELECT Clave_expediente,clave_pedidofondo,Ordenpago,ordencargo FROM EXPEDIENTE)b
                'On A.Clave_expedientetrim=B.Clave_expediente
                '/* DATOS DE LOS CHEQUES */
                'LEFT JOIN
                '(SELECT Nrotransferencia AS CHEQUE, SUM(MONTO) AS 'TOTAL_TRANSF' FROM expediente_detalle GROUP BY Nrotransferencia)T
                'On A.Nrotransferencia=T.CHEQUE
                '/* DATOS DE LOS PROVEEDORES*/
                'LEFT JOIN
                '(SELECT CUIT,PROVEEDOR FROM proveedores WHERE NOT CUIT=0)C
                'On A.CUIT=C.CUIT
                '/* DATOS DE PEDIDOS DE FONDOS*/
                'LEFT JOIN
                '(SELECT clave_pedidofondo,CASE WHEN (CLASE_FONDO=@EJERCICIO) THEN 'EJ.' ELSE CONCAT('RP/',CLASE_FONDO) END   AS 'CLASE',CLASE_FONDO FROM pedido_fondos WHERE NOT CLASE_FONDO=1)D
                'On B.CLAVE_PEDIDOFONDO=D.CLAVE_PEDIDOFONDO
                '/* DATOS DE USUARIOS*/
                'LEFT JOIN
                '(SELECT usuario,apellidos,nombres FROM contaduria_usuarios.usuarios )U
                'On A.usuario=U.usuario
                ' ORDER BY CLAVE_EXPEDIENTE_DETALLE,MONTO ASC"
        End Select
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'LIBRO DE BANCO HOJA 1
        Return Tablatemporal
    End Function

    Private Function Generaciondeconciliacion() As DataTable
        Dim Tablatemporal As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType(Year_numeric.Value & "-01-01", Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("start_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Desde_datetimepicker.Value.Date
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("last_date", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Hasta_DateTimePicker.Value.Date
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("primerdia", MySql.Data.MySqlClient.MySqlDbType.Date).Value = CType(Year_numeric.Value & "-01-01", Date)
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_REPORTES_CONCILIACION", Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '        Dim Consultasql As String = "
        '   SELECT
        '	'BANCO: ' AS 'TIPO',
        'NULL AS 'Desde',
        'NULL AS  'Hasta',
        'NULL AS  INGRESOS,
        'NULL AS  EGRESOS,
        'NULL AS  SALDO
        'UNION ALL
        '    SELECT
        '    '-SALDO INICIAL' AS 'TIPO',
        '            DATE_FORMAT(@primerdia,'%d/%m/%Y') AS 'Desde',
        'DATE_FORMAT(DATE_SUB(@desde,INTERVAL 1 day),'%d/%m/%Y') AS 'Hasta','' AS INGRESOS,
        ''' AS EGRESOS,
        'format(	sum(IMPORTE),2,
        ''es_AR') AS SALDO
        'FROM
        '	reportebanco
        'WHERE
        '	Cuenta =@cuenta
        'AND (
        '	fecha BETWEEN @primerdia
        '	AND DATE_SUB(@desde,INTERVAL 1 day))
        'union all
        'SELECT
        '	'-MOVIMIENTOS' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(sum(CASE WHEN importe > 0 THEN	importe	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	abs(sum(CASE WHEN importe < 0 THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
        'format(	sum(IMPORTE),2,'es_AR') AS SALDO
        'FROM
        '	reportebanco
        'WHERE
        '	Cuenta =@cuenta
        'AND (
        '	fecha BETWEEN @desde
        '	AND @hasta
        ')
        'UNION ALL
        'SELECT
        '	CONCAT('-SALDO AL ', DATE_FORMAT(@Hasta,'%d/%m/%Y')) AS 'TIPO',
        'DATE_FORMAT(@primerdia,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(sum(CASE WHEN importe > 0 THEN	importe	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	abs(sum(CASE WHEN importe < 0 THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
        'format(	sum(IMPORTE),2,'es_AR') AS SALDO
        'FROM
        '	reportebanco
        'WHERE
        '	Cuenta =@cuenta
        'AND (
        '	fecha BETWEEN @primerdia
        '	AND @hasta
        ')
        'UNION ALL
        'SELECT
        '	'-CHEQUES COBRADOS, NO REGISTRADOS EN LIBRO' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format((0),2,'es_AR') AS INGRESOS,
        'format(	abs(sum(CASE WHEN importe < 0 THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
        'format(	(0),2,'es_AR') AS SALDO
        'FROM
        '	reportebanco WHERE (CATEGORIA !='COMISIONES BANCARIAS' OR CATEGORIA !='DEBITO FISCAL IVA BASICO'  OR CATEGORIA !='CHEQUE RECHAZADO')
        'AND
        '	Cuenta =@cuenta AND (
        '	fecha BETWEEN @desde AND @hasta)
        ' AND MD5HASH NOT IN (SELECT (CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE MD5_relacionado END) FROM expediente_detalle WHERE (fechadelmovimiento BETWEEN @desde AND @hasta) GROUP BY MD5_RELACIONADO)
        'UNION ALL
        'SELECT
        '	'-INGRESOS NO REGISTRADOS EN LIBRO' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(	abs(sum(CASE WHEN importe > 0 THEN	importe	ELSE	0	END)),2,'es_AR') AS INGRESOS,
        'format((0),2,'es_AR') AS EGRESOS,
        'format(	(0),2,'es_AR') AS SALDO
        'FROM
        '	reportebanco
        'WHERE
        '	Cuenta =@cuenta AND (
        '	fecha BETWEEN @desde AND @hasta)
        ' AND MD5HASH NOT IN (SELECT (CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE MD5_relacionado END) FROM expediente_detalle WHERE (fechadelmovimiento BETWEEN @desde AND @hasta)   GROUP BY MD5_RELACIONADO)
        'UNION ALL
        'SELECT
        '	'-CHEQUES RECHAZADOS' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(	abs(sum(CASE WHEN CATEGORIA like '%RECH%' THEN	importe	ELSE	0	END)),2,'es_AR') AS INGRESOS,
        'format(	abs(sum(CASE WHEN CATEGORIA like '%RECH%' THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
        'format(	(0),2, 'es_AR') AS SALDO
        'FROM
        '	reportebanco
        'WHERE
        '	Cuenta =@cuenta AND (
        '	fecha BETWEEN @desde AND @hasta)
        ' AND MD5HASH NOT IN (SELECT (CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE MD5_relacionado END) FROM expediente_detalle WHERE (fechadelmovimiento BETWEEN @desde AND @hasta)   GROUP BY MD5_RELACIONADO)
        'UNION ALL
        'SELECT
        '	'-COMISIONES BANCARIAS' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(	(0),2,'es_AR') AS INGRESOS,
        'format(	abs(sum(CASE WHEN CATEGORIA like '%COMISION%' THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
        'format(	(0),2,'es_AR')AS SALDO
        'FROM
        '	reportebanco
        'WHERE
        '	Cuenta =@cuenta AND (
        '	fecha BETWEEN @desde AND @hasta)
        'UNION ALL
        'SELECT
        '	'-DEBITO FISCAL IVA BASICO' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(	(0),2,'es_AR') AS INGRESOS,
        'format(	abs(sum(CASE WHEN DESCRIPCION='DEBITO FISCAL IVA BASICO' THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
        'format(	(0),2,'es_AR')AS SALDO
        'FROM
        '	reportebanco
        'WHERE
        '	Cuenta =@cuenta AND (
        '	fecha BETWEEN @desde AND @hasta)
        '	UNION ALL
        'SELECT
        '	'LIBRO: ' AS 'TIPO',
        'NULL AS 'Desde',
        'NULL AS  'Hasta',
        'NULL AS  INGRESOS,
        'NULL AS  EGRESOS,
        'NULL AS  SALDO
        'UNION ALL
        'SELECT
        '	'-SALDO INICIAL' AS 'TIPO',
        'DATE_FORMAT(@primerdia,'%d/%m/%Y') AS 'Desde',
        'DATE_FORMAT(DATE_SUB(@desde,INTERVAL 1 day),'%d/%m/%Y') AS 'Hasta',
        '	'' AS INGRESOS,
        ''' AS EGRESOS,
        'format(	(sum(CASE WHEN codinp =3 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN codinp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE
        ' (
        '	fechadelmovimiento BETWEEN @primerdia
        '	AND DATE_SUB(@desde,INTERVAL 1 day)
        '	and
        '	(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
        ')
        'UNION ALL
        'SELECT
        '	'-MOVIMIENTOS' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	sum(CASE WHEN CodInp=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
        'format(	(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN CodInp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE
        '	(fechadelmovimiento BETWEEN @desde	AND @hasta   ) and
        '	(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
        '				UNION ALL
        'SELECT
        '	'-MOVIMIENTOS SIN IPS' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        '	format(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	sum(CASE WHEN CodInp=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
        'format(	(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN CodInp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE NOT(Mov_tipo='IPS') AND
        '	(fechadelmovimiento BETWEEN @desde	AND @hasta   ) and
        '	(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
        'UNION ALL
        'SELECT
        '	CONCAT('-SALDO AL ',DATE_FORMAT(@hasta,'%d/%m/%Y'),' (Incluyendo IPS) ' ) AS 'TIPO',
        'DATE_FORMAT(@primerdia,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        'format(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	sum(CASE WHEN CodInp=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
        'format(	(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN CodInp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE   (
        '	(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)) and
        '	fechadelmovimiento BETWEEN @primerdia
        '	AND @hasta
        '	)
        '	UNION ALL
        'SELECT
        '	'-IPS ACUMULADO' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        'format(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	sum(CASE WHEN CodInp=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
        'format(	(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN CodInp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE ISNULL(MD5_RELACIONADO) AND
        '(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
        'AND (	fechadelmovimiento BETWEEN @primerdia	AND @hasta) AND Mov_tipo='IPS'
        'UNION ALL
        'SELECT
        '	'-IPS' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        'format(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	sum(CASE WHEN CodInp=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
        'format(	(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN CodInp =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE ISNULL(MD5_RELACIONADO) AND
        '(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
        'AND (	fechadelmovimiento BETWEEN @DESDE	AND @hasta) AND Mov_tipo='IPS'
        '	UNION ALL
        'SELECT
        '	'-CHEQUES SIN COBRAR EN BANCO ' AS 'TIPO',
        'NULL AS 'Desde',
        'NULL AS  'Hasta',
        'NULL AS  INGRESOS,
        'NULL AS  EGRESOS,
        'NULL AS  SALDO
        'UNION ALL
        'SELECT
        '	CONCAT('-----',MOV_TIPO) AS 'TIPO',
        'DATE_FORMAT(@primerdia,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        'NULL AS INGRESOS,
        'format(	sum(monto),2,'es_AR') AS EGRESOS,
        'NULL AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE
        'ISNULL(MD5_RELACIONADO) AND
        'codinp=1
        'AND
        '(fechadelmovimiento BETWEEN @primerdia	AND @hasta)
        'and Nrotransferencia in (select NRO_CHEQUE from tesoreria_cheques where CUENTA=@cuenta)
        'AND MONTO<>0
        '	 AND NOT Mov_tipo='IPS'
        'AND
        '(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
        '				group by mov_tipo
        'UNION ALL
        'SELECT
        '	'-INGRESOS AÚN NO REGISTRADOS EN BANCO' AS 'TIPO',
        'DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
        'format(sum(CASE WHEN CodInp =3 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS,
        'format(	sum(CASE WHEN CodInp=99 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS,
        'format(	0,2,'es_AR') AS SALDO
        'FROM
        '	expediente_detalle
        'WHERE ISNULL(MD5_RELACIONADO) AND
        '(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
        'SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        '        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
        'AND (
        '	fechadelmovimiento BETWEEN @desde
        '	AND @hasta
        ') AND NOT Mov_tipo='IPS'
        '   "
        '        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Generaciondeconciliacion2() As DataTable
        Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", CType(Year_numeric.Value & "-01-01", Date))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@year", Year_numeric.Value)
        Dim Consultasql As String = "
SELECT TIPO as BANCO, Saldo as '_ ',TIPO_libro AS LIBRO,SALDO_libro AS ' __'
From
((SELECT
	'a' as 'union',CONCAT('SALDO BANCO AL ', DATE_FORMAT(@Hasta,'%d/%m/%Y')) AS 'TIPO',
DATE_FORMAT(@primerdia,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
	format(sum(CASE WHEN importe > 0 THEN	importe	ELSE 0 END ),2,'es_AR') AS INGRESOS,
format(	abs(sum(CASE WHEN importe < 0 THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
format(	sum(IMPORTE),2,'es_AR') AS SALDO
FROM
	reportebanco
WHERE
	Cuenta =@cuenta
AND (
	fecha BETWEEN @primerdia
	AND @hasta
))A
Left join
(SELECT
	'a' as 'union',CONCAT('SALDO LIBRO AL ',DATE_FORMAT(@hasta,'%d/%m/%Y') ) AS 'TIPO_libro',
DATE_FORMAT(@primerdia,'%d/%m/%Y') AS 'Desde_libro', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta2',
	format(sum(CASE WHEN Cod_orden =4 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS_libro,
format(	sum(CASE WHEN Cod_orden=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS_libro,
format(	(sum(CASE WHEN Cod_orden =4 THEN	MONTO	ELSE 0 END )-sum(CASE WHEN Cod_orden =1 THEN	MONTO	ELSE 0 END )),2,'es_AR') AS SALDO_libro
FROM
	expediente_detalle
WHERE
(
	fechadelmovimiento BETWEEN @primerdia
	AND @hasta AND NOT (DETALLE LIKE '%TRAN%' and DETALLE LIKE '% IPS%')
))B
on a.union=b.union)
union ALL
SELECT 'Más Transferencias Reg. en Libro No Ingresados en Banco' as BANCO,INGRESOS_libro as '','MÁS TRANSFERENCIAS NO REGISTRADAS EN LIBROS' AS LIBRO,INGRESOS AS ' '
from
(
SELECT
	'a' as 'union','LIBRO: INGRESOS SIN INGRESAR EN BANCO' AS 'TIPO_libro',
DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde_libro', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta_libro',
	format(sum(CASE WHEN Cod_orden =4 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS_libro,
format(	sum(CASE WHEN Cod_orden=99 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS_libro,
format(	0,2,'es_AR') AS SALDO_libro
FROM
	expediente_detalle
WHERE ISNULL(MD5_RELACIONADO) AND
SUBSTRING(Clave_expediente_detalle	FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AND NOT (DETALLE LIKE '%TRAN%' and DETALLE LIKE '% IPS%') IN
(SELECT Clave_expediente	FROM	expediente WHERE clave_pedidofondo IN (SELECT	clave_pedidofondo	FROM	pedido_fondos	WHERE	Cuenta_pedidofondo = @cuenta))
AND (
	fechadelmovimiento BETWEEN @desde
	AND @hasta
))A
LEFT JOIN
(SELECT
	'a' as 'union','BANCO: INGRESOS NO REGISTRADOS EN LIBRO' AS 'TIPO',
DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
	format(	abs(sum(CASE WHEN importe > 0 THEN	importe	ELSE	0	END)),2,'es_AR') AS INGRESOS,
format((0),2,'es_AR') AS EGRESOS,
format(	(0),2,'es_AR') AS SALDO
FROM
	reportebanco
WHERE
	Cuenta =@cuenta AND (
	fecha BETWEEN @desde AND @hasta)
 AND MD5HASH NOT IN (SELECT (CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE MD5_relacionado END) FROM expediente_detalle WHERE (fechadelmovimiento BETWEEN @desde AND @hasta) AND NOT (DETALLE LIKE '%TRAN%' and DETALLE LIKE '% IPS%') GROUP BY MD5_RELACIONADO))B
on a.union=b.union
union ALL
SELECT 'Menos PAGOS NO DEBITADOS EN BANCO' as BANCO,Egresos_libro as '','Menos Cheques no Registrados en Libros' AS LIBRO,Egresos AS ' ' from
(SELECT
	'a' as 'union','LIBRO: CHEQUES SIN COBRAR EN BANCO' AS 'TIPO',
DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
	format(sum(CASE WHEN Cod_orden =99 THEN	MONTO	ELSE 0 END ),2,'es_AR') AS INGRESOS_libro,
format(	sum(CASE WHEN Cod_orden=1 THEN	MONTO	ELSE	0	END),2,'es_AR') AS EGRESOS_libro,
format(	0,2,'es_AR') AS SALDO_libro
FROM
	expediente_detalle
WHERE ISNULL(MD5_RELACIONADO) AND
SUBSTRING(Clave_expediente_detalle	FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AND NOT (DETALLE LIKE '%TRAN%' and DETALLE LIKE '% IPS%') IN
(SELECT Clave_expediente	FROM	expediente WHERE clave_pedidofondo IN (SELECT	clave_pedidofondo	FROM	pedido_fondos	WHERE	Cuenta_pedidofondo = @cuenta))
AND (
	fechadelmovimiento BETWEEN @desde
	AND @hasta
))A
LEFT JOIN
(SELECT
	'a' as 'union','BANCO: CHEQUES COBRADOS, NO REGISTRADOS EN LIBRO' AS 'TIPO',
DATE_FORMAT(@desde,'%d/%m/%Y') AS 'Desde', DATE_FORMAT(@hasta,'%d/%m/%Y') AS 'Hasta',
	format((0),2,'es_AR') AS INGRESOS,
format(	abs(sum(CASE WHEN importe < 0 THEN	importe	ELSE	0	END)),2,'es_AR') AS EGRESOS,
format(	(0),2,'es_AR') AS SALDO
FROM
	reportebanco WHERE (CATEGORIA !='COMISIONES BANCARIAS' OR CATEGORIA !='DEBITO FISCAL IVA BASICO'  OR CATEGORIA !='CHEQUE RECHAZADO')
AND
	Cuenta =@cuenta AND (
	fecha BETWEEN @desde AND @hasta)
 AND MD5HASH NOT IN (SELECT (CASE WHEN ISNULL(MD5_RELACIONADO) THEN 0 ELSE MD5_relacionado END) FROM expediente_detalle WHERE (fechadelmovimiento BETWEEN @desde AND @hasta) GROUP BY MD5_RELACIONADO))B
on a.union=b.union
union ALL
SELECT 'AJUSTES' as BANCO,' ' as '',' ' AS LIBRO,' ' AS ' '
union ALL
SELECT 'DIFERENCIA' as BANCO,' ' as '',' ' AS LIBRO,' ' AS ' '
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function pedidosdefondo() As DataTable
        Dim Tablatemporal As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@year", Year_numeric.Value)
        Dim consultasql As String =
            "Select
CONCAT(N_pedidofondo,'/', Year_pedidofondo) AS 'Num Pedido Fondo',
	CASE when Year_pedidofondo=Clase_fondo THEN 'Ejercicio' else
				CASE when Year_pedidofondo='' THEN 'Ejercicio*' else
				CONCAT('RP-',Clase_fondo) end END as 'CLASE' ,Fecha_pedido,
format(Monto_pedidofondo,2, 'es_AR') as 'Monto Solicitado',
Format((select CASE when C.INGRESOS>=0 THEN SUM(INGRESOS) ELSE 0 END),2,'es_AR') AS INGRESOS,
Format((select CASE when D.EGRESOS>=0 THEN SUM(EGRESOS) ELSE 0 END),2,'es_AR') AS EGRESOS,
Format((select CASE when E.RENDIDO>=0 THEN SUM(RENDIDO) ELSE 0 END),2,'es_AR') AS RENDIDO,
 CONCAT(format(((select CASE when D.EGRESOS>=0 THEN SUM(EGRESOS) ELSE 0 END)/(select CASE when C.INGRESOS>=0 THEN SUM(INGRESOS) ELSE 0 END))*100,2, 'es_AR'),'%') as 'ejecutado S/ing',
B.Expediente_N as 'Expte Ped. fondo',
B.Descripcion,
Ordenpago as 'Orden de Pago',
Cuenta_pedidofondo as 'Cuenta',
 Clase_fondo
from (Select Expediente_N,Fecha,Detalle,Ordenpago,Monto,clave_pedidofondo,Claveexpteprincipal,Clave_expediente from Expediente where not Isnull(clave_pedidofondo))A
LEFT JOIN
(SELECT Clave_pedidofondo, N_pedidofondo, Year_pedidofondo, Monto_pedidofondo, Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo,Expediente_N FROM PEDIDO_fondos)B
ON A.clave_pedidofondo=B.CLAVE_PEDIDOFONDO
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS INGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where (Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=3 or CodInp=4 or CodInp=9) GROUP BY Clave_expedientetrim)C
ON C.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS EGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where (Cod_orden=1 or Cod_orden=2 or Cod_orden=3 or Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=1 ) GROUP BY Clave_expedientetrim)D
ON D.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS RENDIDO,  SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where ( CodInp=2 ) GROUP BY Clave_expedientetrim) E
ON E.Clave_expedientetrim=A.Clave_expediente
Group by `Num Pedido Fondo`
order by N_pedidoFondo ASC"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function porexpedientes() As DataTable
        Dim Tablatemporal As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String = "Select
CONCAT(SUBSTRING(A.Clave_expediente FROM 5 FOR 4),'-',cast(Substring(A.Clave_expediente From 9 for 5)AS UNSIGNED),'/',SUBSTRING(A.Clave_expediente FROM 1 FOR 4)) AS 'EXPEDIENTE',Clave_expediente,
Fecha,
A.Detalle,
Ordenpago,
CONCAT(SUBSTRING(A.clave_pedidofondo FROM 5 FOR 4),'-',cast(Substring(A.clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',SUBSTRING(A.clave_pedidofondo FROM 1 FOR 4)) AS 'EXPTEv2',
CASE WHEN ISNULL(N_pedidofondo) THEN CONCAT('ASIGNADO A: ', case when isnull(CUENTABANCARIA.DESCRIPCION) then CUENTA_ESPECIAL else CUENTABANCARIA.DESCRIPCION end) ELSE CONCAT(N_pedidofondo,'/', Year_pedidofondo) END  AS 'Num Pedido Fondo',
Monto as 'Monto Solicitado',
 INGRESOS,
EGRESOS,
INGRESOS-EGRESOS as 'Dif.(Ing. - Egres.)',
RENDIDO,
EGRESOS-RENDIDO as 'Dif.(Egres. - Rend.)',
 CONCAT(fOrmat(EGRESOS/INGRESOS*100,2, 'es_AR'),'%') as 'Porcentaje ejecutado',
Cuenta_pedidofondo, Clase_fondo
from
(Select Expediente_N,Fecha,Detalle,Ordenpago,Monto,Claveexpteprincipal,Clave_expediente,clave_pedidofondo,CUENTA_ESPECIAL from Expediente where (not Isnull(clave_pedidofondo) AND NOT Clave_pedidofondo=0) OR (NOT ISNULL(Cuenta_especial) AND NOT CUENTA_ESPECIAL='')
)A
LEFT JOIN
(SELECT Clave_pedidofondo, N_pedidofondo, Year_pedidofondo, Monto_pedidofondo, Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo FROM PEDIDO_fondos)B
ON A.clave_pedidofondo=B.CLAVE_PEDIDOFONDO
LEFT JOIN
(SELECT
SUM(INGRESOS) AS INGRESOS,SUM(EGRESOS) AS EGRESOS,SUM(RENDIDO) AS RENDIDO,Clave_expedientetrim
FROM
(SELECT
CASE WHEN CODINP=1 THEN SUM(CASE WHEN ISNULL(MONTO) THEN 0 ELSE MONTO END) ELSE 0 END AS INGRESOS,
CASE WHEN CODINP=1 THEN SUM(CASE WHEN ISNULL(MONTO) THEN 0 ELSE MONTO END) ELSE 0 END AS EGRESOS,
CASE WHEN CODINP=1 THEN SUM(CASE WHEN ISNULL(MONTO) THEN 0 ELSE MONTO END) ELSE 0 END AS RENDIDO,
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
FROM EXPEDIENTE_DETALLE WHERE
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
(Select Clave_expediente from Expediente where (not Isnull(clave_pedidofondo) AND NOT Clave_pedidofondo=0) OR (NOT ISNULL(Cuenta_especial) AND NOT CUENTA_ESPECIAL=''))
GROUP BY Clave_expedientetrim,CODINP)D1
GROUP BY Clave_expedientetrim
)D
ON D.Clave_expedientetrim=A.Clave_expediente
LEFT JOIN
(SELECT * From Cuenta_Bancaria)CUENTABANCARIA
ON CUENTABANCARIA.Cuenta=A.Cuenta_especial
Order by Year_pedidofondo asc,N_pedidofondo asc"
        '        Dim CONSULTASS As String =
        '            "select a.Expediente_N,Fecha,A.Detalle,Ordenpago,
        'CONCAT(N_pedidofondo,'/', Year_pedidofondo) AS 'Num Pedido Fondo',
        'Monto as 'Monto Solicitado',
        '(select CASE when E.INGRESOS>=0 THEN SUM(INGRESOS) ELSE 0 END) AS INGRESOS,
        '(select CASE when E.EGRESOS>=0 THEN SUM(EGRESOS) ELSE 0 END) AS EGRESOS,
        'CASE WHEN NOT ISNULL(SUM(INGRESOS)-SUM(EGRESOS)) THEN (SUM(INGRESOS)-SUM(EGRESOS)) ELSE 0 END as 'Dif.(Ing. - Egres.)',
        ' CONCAT(format(((select CASE when E.EGRESOS>=0 THEN SUM(EGRESOS) ELSE 0 END)/(select CASE when E.INGRESOS>=0 THEN SUM(INGRESOS) ELSE 0 END))*100,2, 'es_AR'),'%') as 'Porcentaje ejecutado',
        'Cuenta_pedidofondo, Clase_fondo
        'from (Select Expediente_N,Fecha,Detalle,Ordenpago,Monto,clave_pedidofondo,Claveexpteprincipal,Clave_expediente from Expediente where not Isnull(clave_pedidofondo))A
        'LEFT JOIN
        '(SELECT Clave_pedidofondo, N_pedidofondo, Year_pedidofondo, Monto_pedidofondo, Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo FROM PEDIDO_fondos)B
        'ON A.clave_pedidofondo=B.CLAVE_PEDIDOFONDO
        'left JOIN
        '(select SUM(INGRESOS) AS 'INGRESOS',SUM(EGRESOS) AS 'EGRESOS',CLAVE_EXPEDIENTE
        ' from MFYV GROUP BY CLAVE_EXPEDIENTE)E
        'ON E.CLAVE_EXPEDIENTE=A.Clave_expediente
        'GROUP BY A.Clave_expediente
        'Order by Year_pedidofondo asc,N_pedidofondo asc"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Movimientodefondosyvalores() As DataTable
        Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String = "SELECT * FROM
(Select DATE_FORMAT(Fechadelmovimiento,'%d/%m/%Y') as FECHA,
Cod_orden as 'Cod orden',Case when CodInp=3 then '-' else Orden_N END as 'Orden P.',CFDO,
CONCAT (CONVERT((SUBSTRING(b.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(b.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(b.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(b.clave_pedidofondo) - 9) )AS 'Pedido de Fondo' ,
Case when CodInp=3 then Orden_N else '-' END as 'Orden E.',CodInp,SUBSTRING(A.Clave_expediente_detalle FROM 5 FOR 4) as 'Org.',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED) as 'Num',
SUBSTRING(A.Clave_expediente_detalle   FROM 1 FOR 4) as 'Año',
Nrotransferencia as 'Comprobante',
Concat(
CASE WHEN CodInp =3 THEN 'TRANSF. ' ELSE
			CASE WHEN CodInp = 1 THEN 'PAGO ' ELSE
				CASE WHEN CodInp= 2 THEN 'REND. ' ELSE
CASE WHEN CodInp= 4 THEN 'REINTEG. ' ELSE 'VERIFICAR COD INP'
				END
			END
END
END,'del ',DATE_FORMAT(Fechadelmovimiento,'%d/%m/%Y'),' (' ,Proveedor,')') AS 'EXTRACTO',
monto as 'IMPORTE',
'                                     ' AS OBSERVACIONES
,DATE_FORMAT(Creado_o_modificado,'%d/%m/%Y') AS 'CARGADO EL:'
from
(Select
 SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Fechadelmovimiento,Expediente_N,Detalle,Cod_orden,Orden_N,CFDO,CodInp,Nrotransferencia,monto,Creado_o_modificado,CUIT
FROM expediente_detalle Where
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) in (Select clave_expediente from expediente where clave_pedidofondo in
 (select clave_pedidofondo from pedido_fondos where cuenta_pedidofondo=@cuenta)) AND
 (date(Fechadelmovimiento) BETWEEN @desde and @hasta)and not (CodInp=2) )A
LEFT JOIN
(SELECT Clave_expediente,clave_pedidofondo FROM EXPEDIENTE  where not isnull(clave_pedidofondo))b
On A.Clave_expedientetrim=B.Clave_expediente
LEFT JOIN
(SELECT Proveedor,CUIT FROM Proveedores WHERE not isnull(CUIT))P
On A.CUIT=P.CUIT
LEFT JOIN
(SELECT clave_pedidofondo,cuenta_pedidofondo FROM pedido_fondos where not isnull(clave_pedidofondo))C
On B.clave_pedidofondo=C.clave_pedidofondo
order by  Cod_orden desc,CFDO DESC,CODINP DESC, COMPROBANTE,SUBSTRING(A.Clave_expediente_detalle FROM 5 FOR 4),
cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),
SUBSTRING(A.Clave_expediente_detalle   FROM 1 FOR 4)
 DESC
)U1
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Listadoexpedientes() As DataTable
        Dim Tablatemporal As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            "SELECT Expediente_N FROM EXPEDIENTE ORDER BY MONTO DESC"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Cuentabancariatotales() As DataTable
        Dim Tablatemporal As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            "Select Cuenta_pedidofondo as 'Cuenta',Descripcion_cuenta,
Count(N_pedidofondo) AS 'Cantidad P. Fondos',Sum(Monto_pedidofondo) as 'Fondos Solicitados',
(select CASE when C.INGRESOS>=0 THEN SUM(INGRESOS) ELSE 0 END) AS Ingresos,
(select CASE when D.EGRESOS>=0 THEN SUM(EGRESOS) ELSE 0 END) AS Egresos,
(select CASE when E.RENDIDO>=0 THEN SUM(RENDIDO) ELSE 0 END) AS Rendido
from (Select Expediente_N,Fecha,Detalle,Ordenpago,Monto,clave_pedidofondo,Claveexpteprincipal,Clave_expediente from Expediente where not Isnull(clave_pedidofondo))A
LEFT JOIN
(SELECT Clave_pedidofondo, N_pedidofondo, Year_pedidofondo, Monto_pedidofondo, Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo,Expediente_N FROM PEDIDO_fondos)B
ON A.clave_pedidofondo=B.CLAVE_PEDIDOFONDO
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS INGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where (Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=3 or CodInp=4 or CodInp=9) GROUP BY Clave_expedientetrim)C
ON C.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS EGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where (Cod_orden=1 or Cod_orden=2 or Cod_orden=3 or Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=1 ) GROUP BY Clave_expedientetrim)D
ON D.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS RENDIDO,  SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where ( CodInp=2 ) GROUP BY Clave_expedientetrim) E
ON E.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select Cuenta as 'CuentaBancaria',descripcion as 'Descripcion_cuenta' From Cuenta_Bancaria) F
ON F.CuentaBancaria=B.Cuenta_pedidofondo
Group by Cuenta"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Cuentabancariatotalesfechas() As DataTable
        Dim Tablatemporal As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            "Select Cuenta_pedidofondo as 'Cuenta',Descripcion_cuenta,
Count(N_pedidofondo) AS 'Cantidad P. Fondos',Sum(Monto_pedidofondo) as 'Fondos Solicitados',
(select CASE when C.INGRESOS>=0 THEN SUM(INGRESOS) ELSE 0 END) AS Ingresos,
(select CASE when D.EGRESOS>=0 THEN SUM(EGRESOS) ELSE 0 END) AS Egresos,
(select CASE when E.RENDIDO>=0 THEN SUM(RENDIDO) ELSE 0 END) AS Rendido
from (Select Expediente_N,Fecha,Detalle,Ordenpago,Monto,clave_pedidofondo,Claveexpteprincipal,Clave_expediente from Expediente where not Isnull(clave_pedidofondo))A
LEFT JOIN
(SELECT Clave_pedidofondo, N_pedidofondo, Year_pedidofondo, Monto_pedidofondo, Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo,Expediente_N FROM PEDIDO_fondos where (fecha_pedido between @desde and @hasta))B
ON A.clave_pedidofondo=B.CLAVE_PEDIDOFONDO
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS INGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where ((Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=3 or CodInp=4 or CodInp=9) and (fechadelmovimiento between @desde and @hasta)) GROUP BY Clave_expedientetrim)C
ON C.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS EGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where ((Cod_orden=1 or Cod_orden=2 or Cod_orden=3 or Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=1 ))  and (fechadelmovimiento between @desde and @hasta) GROUP BY Clave_expedientetrim)D
ON D.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS RENDIDO,  SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where (( CodInp=2 ))and (fechadelmovimiento between @desde and @hasta) GROUP BY Clave_expedientetrim) E
ON E.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select Cuenta as 'CuentaBancaria',descripcion as 'Descripcion_cuenta' From Cuenta_Bancaria) F
ON F.CuentaBancaria=B.Cuenta_pedidofondo
Group by Cuenta"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function pedidosfondodetalle() As DataTable
        Dim Tablatemporal As New DataTable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            "  select concat(n_pedidofondo,'/',year_pedidofondo) as 'N_pedido_fondo',
fecha_pedido,
Monto,
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N
,detalle,
proveedor as 'Corresponde a:',
 d.descripcion as 'Cuenta Banc.' from
(select * from cuit_movimiento where Clave_pedidofondo
in (select Clave_pedidofondo from pedido_fondos where Fecha_pedido between @desde and @hasta))a
inner JOIN
(select * from pedido_fondos where haberes= 0)B
on a.clave_pedidofondo=b.clave_pedidofondo
left JOIN
(select * from proveedores)C
on a.CUIT=C.CUIT
left JOIN
(select * From Cuenta_Bancaria)D
on B.cuenta_pedidofondo=D.cuenta
union all
select concat(n_pedidofondo,'/',year_pedidofondo) as 'N_pedido_fondo',
fecha_pedido,
SUM(Monto) as Monto,
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N
,detalle,
'HABERES' as 'Corresponde a:',
 d.descripcion as 'Cuenta Banc.' from
(select * from cuit_movimiento where Clave_pedidofondo
in (select Clave_pedidofondo from pedido_fondos where Fecha_pedido between @desde and @hasta))a
inner JOIN
(select * from pedido_fondos where haberes= 1)B
on a.clave_pedidofondo=b.clave_pedidofondo
left JOIN
(select * From Cuenta_Bancaria)D
on B.cuenta_pedidofondo=D.cuenta
group by a.clave_expediente
order by fecha_pedido desc,N_pedido_fondo desc"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Chequessincobrar() As DataTable
        Dim Tablatemporal As New DataTable
        'If Cuentas_combobox.SelectedIndex > 0 Then
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            "Select DATE_FORMAT(fechadelmovimiento,'%d/%m/%Y')as 'Fecha',
Nrotransferencia as 'Nro comprobante',
Expediente_N,
CASE WHEN MONTO=0 THEN CONCAT('**ANULADO EL ',DATE_FORMAT(CREADO_O_MODIFICADO,'%d/%m/%Y'),'** ',DETALLE) ELSE DETALLE END as 'Extracto',
CASE WHEN MONTO=0 THEN MONTO_HISTORIAL ELSE MONTO END as 'IMPORTE',
Creado_o_modificado as 'ultima modificación',autor
FROM
(select * from 	expediente_detalle
WHERE
(ISNULL(MD5_RELACIONADO) OR Md5_relacionado not in (
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH'
FROM reportebanco where Fecha between @DESDE and @HASTA group by nro_transaccion )))
AND (MONTO <>0 OR CREADO_O_MODIFICADO>@HASTA)
AND
codinp=1
AND
(fechadelmovimiento BETWEEN @DESDE	AND @HASTA)
and Nrotransferencia in (select NRO_CHEQUE from tesoreria_cheques where CUENTA=@CUENTA)
	 AND NOT Mov_tipo='IPS'
AND
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @CUENTA)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @CUENTA)))original
				left join
				( select fechadelmovimiento as fechadelmovimiento_historial,MOV_TIPO as MOV_TIPO_historial,monto as monto_historial,clave_expediente_detalle as clave_expediente_detalle_historial,md5_relacionado as md5_relacionado_historial from
	expediente_detalle_historial where fechadelmovimiento BETWEEN @DESDE	AND @HASTA group by clave_expediente_Detalle )historial
	on original.clave_expediente_detalle=historial.clave_expediente_detalle_historial
left join
(Select concat(nombres,' ',apellidos) as autor,usuario from contaduria_usuarios.usuarios)usuarios
on original.usuario=usuarios. usuario
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
        'Else
        '    Return Nothing
        'End If
    End Function

    Private Function Ingresossinregistrar() As DataTable
        Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            "Select Nrotransferencia,Detalle,Fechadelmovimiento,Monto,Expediente_N from expediente_detalle where
SUBSTRING(Clave_expediente_detalle	FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN ( SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta))
AND
(fechadelmovimiento >= @desde and fechadelmovimiento <=@hasta)
AND  Monto>0 AND
(Md5_relacionado not in (
(select CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH'
FROM reportebanco where Fecha between @desde and @hasta group by nro_transaccion )
)or ISNULL(MD5_relacionado)
)
AND
CodINP=3
AND
CLAVE_EXPEDIENTE_DETALLE NOT IN (SELECT CLAVE_EXPEDIENTE_DETALLE FROM EXPEDIENTE_DETALLE WHERE MOV_TIPO='IPS'  )
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function Detallecompletoconciliacion(ByVal Paraexcel As Boolean) As DataTable
        If Cuentas_combobox.SelectedIndex >= 0 Then
            Dim Tablatemporal As New DataTable
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
            Dim consultasql As String =
                "Select
DATE_FORMAT(banco_fecha,'%d/%m/%Y') AS 'Banco Fecha',
Banco_Nro,
Banco_Descrip,
CATEGORIA AS 'CATEGORIA BCO',
CASE WHEN ISNULL(Banco_Importe) THEN 0.00 ELSE BANCO_IMPORTE END AS BANCO_IMPORTE,
Libro_Fecha,
Libro_Expte,
Libro_Nro,
Libro_Descrip,
MOV_TIPO,
CASE WHEN ISNULL(Libro_Importe) THEN 0.00 ELSE Libro_Importe END AS Libro_Importe,
COD,
CASE WHEN ISNULL(MONTO_ASOCIADO) THEN 0.00 ELSE MONTO_ASOCIADO END AS   Asociado,
CASE WHEN ISNULL((MONTO_ASOCIADO-abs(IMPORTE))) THEN 0.00 ELSE (MONTO_ASOCIADO-abs(IMPORTE)) END AS 'Diferencia'
,concat(CAST(SUBSTRING(EXPEDIENTE.Clave_Pedidofondo	FROM 9 FOR 13)AS SIGNED),'/',SUBSTRING(EXPEDIENTE.Clave_Pedidofondo	FROM 1 FOR 4) ) aS 'Pedido de Fondo'
 from
#DETALLE DE LOS MOVIMIENTOS
( Select
fecha AS 'Banco_Fecha',
NRO_TRANSACCION AS 'Banco_Nro',
DESCRIPCION AS 'Banco_Descrip',
CATEGORIA,
IMPORTE AS 'Banco_Importe',
FECHADELMOVIMIENTO AS 'Libro_Fecha',
NROTRANSFERENCIA AS 'Libro_Nro',
DETALLE AS 'Libro_Descrip',
MONTO  AS 'Libro_Importe' ,
concat(Cod_orden,CFdo,CodInp) as 'cod',
EXPEDIENTE_N AS 'Libro_Expte',
MD5hash,
IMPORTE,
A.md5_relacionado,
CLAVE_EXPEDIENTE_DETALLE,
A.MOV_TIPO
from
(Select
CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH' ,
Cuenta,
Fecha,
Nro_Transaccion,
group_concat(distinct Descripcion) as Descripcion,
SUM(IMPORTE) AS 'IMPORTE',
Saldo,
group_concat(distinct CATEGORIA) as 'Categoria',
Usuario,
actualizacion
from reportebanco where cuenta=@cuenta AND
(fecha between @desde and @hasta)
 group by nro_transaccion
)B
LEFT JOIN
(Select *
from expediente_detalle where
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
AND
(fechadelmovimiento between @desde and @hasta) AND NOT ISNULL(MD5_RELACIONADO)
)A
on a.md5_relacionado=b.MD5hash
#UNION BANCO LIBRO
UNION ALL
Select
fecha AS 'Banco_Fecha',
NRO_TRANSACCION AS 'Banco_Nro',
DESCRIPCION AS 'BANCO_DESCRIP',
CATEGORIA,
IMPORTE AS 'Banco_Importe',
FECHADELMOVIMIENTO AS 'Libro_Fecha',
NROTRANSFERENCIA AS 'Libro_Nro',
DETALLE AS 'Libro_Descrip',
MONTO AS 'Libro_Importe' ,
concat(Cod_orden,CFdo,CodInp) as 'MFyV',
EXPEDIENTE_N AS 'Libro_Expte',
MD5hash,
IMPORTE,
C.md5_relacionado,
ClavePedidofondo,
C.MOV_TIPO
from
(Select *
from expediente_detalle where
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @CUENTA)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
AND
(fechadelmovimiento between @desde and @hasta) AND ISNULL(MD5_RELACIONADO)  order by fechadelmovimiento ASC,NROTRANSFERENCIA ASC
)C
left JOIN
(Select
CASE WHEN COUNT(CUENTA)=1 THEN MD5HASH else MD5(GROUP_CONCAT(DISTINCT MD5HASH)) END as 'MD5HASH' ,
Cuenta,
Fecha,
Nro_Transaccion,
group_concat(distinct Descripcion) as Descripcion,
SUM(IMPORTE) AS 'IMPORTE',
Saldo,
group_concat(distinct CATEGORIA) as 'Categoria',
Usuario,
actualizacion
from reportebanco where cuenta=@cuenta AND
(fecha between @desde and @hasta)
 group by nro_transaccion)D
on C.md5_relacionado=D.MD5hash
Left Join
(SELECT SUM(MONTO) AS 'MONTO_ASOCIADO',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)f
on f.md5_relacionado=D.MD5hash
order by -banco_fecha desc,md5_relacionado,Banco_Nro)D
#/DETALLE DE LOS MOVIMIENTOS
Left Join
(SELECT SUM(MONTO) AS 'MONTO_ASOCIADO',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) and (fechadelmovimiento between @desde and @hasta)  group by MD5_relacionado)f
on f.md5_relacionado=D.MD5hash
Left Join
(SELECT * FROM EXPEDIENTE)EXPEDIENTE
on EXPEDIENTE.CLAVE_EXPEDIENTE=SUBSTRING(D.Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(D.Clave_expediente_detalle) - 4)
"
            Dim Valoresrepetidos As Integer = 0
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Dim nuevatablatemporal As New DataTable
            For x = 0 To Tablatemporal.Columns.Count - 1
                nuevatablatemporal.Columns.Add(Tablatemporal.Columns(x).ColumnName)
            Next
            For x = 0 To Tablatemporal.Rows.Count - 1
                Valoresrepetidos = 0
                nuevatablatemporal.Rows.Add()
                For Z = 0 To Tablatemporal.Columns.Count - 1
                    nuevatablatemporal.Rows(x).Item(Z) = Tablatemporal.Rows(x).Item(Z).ToString
                Next
                If x > 0 Then
                    For Z = 0 To 4
                        If (Tablatemporal.Rows(x).Item(Z).ToString = Tablatemporal.Rows(x - 1).Item(Z).ToString) Then
                            Valoresrepetidos += 1
                        End If
                    Next
                    If Valoresrepetidos = 5 Then
                        If Paraexcel = False Then
                            If nuevatablatemporal.Rows(x).Item("BANCO_NRO").ToString.Length > 0 Then
                                '                        nuevatablatemporal.Rows(x).Item("BANCO_NRO") = "S/D"
                                nuevatablatemporal.Rows(x).Item("BANCO FECHA") = ""
                                nuevatablatemporal.Rows(x).Item("BANCO_NRO") = "*"
                                nuevatablatemporal.Rows(x).Item("BANCO_DESCRIP") = "*"
                                nuevatablatemporal.Rows(x).Item("CATEGORIA") = "*"
                                nuevatablatemporal.Rows(x).Item("BANCO_IMPORTE") = "*"
                                nuevatablatemporal.Rows(x).Item("Asociado") = "-"
                                nuevatablatemporal.Rows(x).Item("Diferencia") = "-"
                            End If
                        End If
                    Else
                        If (nuevatablatemporal.Rows(x).Item("CATEGORIA BCO").ToString = "COMISIONES BANCARIAS") Or (nuevatablatemporal.Rows(x).Item("CATEGORIA BCO").ToString = "DEBITO FISCAL IVA BASICO") Then
                            '                        nuevatablatemporal.Rows(x).Item("BANCO_NRO") = "S/D"
                            nuevatablatemporal.Rows(x).Item("libro_fecha") = nuevatablatemporal.Rows(x).Item("BANCO FECHA").ToString
                            nuevatablatemporal.Rows(x).Item("Libro_Nro") = "-"
                            nuevatablatemporal.Rows(x).Item("Libro_Descrip") = nuevatablatemporal.Rows(x).Item("CATEGORIA BCO").ToString
                            nuevatablatemporal.Rows(x).Item("Libro_Importe") = "-"
                            nuevatablatemporal.Rows(x).Item("COD") = "-"
                            nuevatablatemporal.Rows(x).Item("Libro_Expte") = "-"
                            nuevatablatemporal.Rows(x).Item("Asociado") = "-"
                            nuevatablatemporal.Rows(x).Item("Diferencia") = "0,00"
                        Else
                            If nuevatablatemporal.Rows(x).Item("Libro_Nro").ToString.Length = 0 Then
                                '                        nuevatablatemporal.Rows(x).Item("BANCO_NRO") = "S/D"
                                nuevatablatemporal.Rows(x).Item("libro_fecha") = "S/D"
                                nuevatablatemporal.Rows(x).Item("Libro_Nro") = "S/D"
                                nuevatablatemporal.Rows(x).Item("Libro_Descrip") = "S/D"
                                nuevatablatemporal.Rows(x).Item("Libro_Importe") = "S/D"
                                nuevatablatemporal.Rows(x).Item("COD") = "S/D"
                                nuevatablatemporal.Rows(x).Item("Libro_Expte") = "S/D"
                                nuevatablatemporal.Rows(x).Item("Asociado") = "0,00"
                                nuevatablatemporal.Rows(x).Item("Diferencia") = nuevatablatemporal.Rows(x).Item("BANCO_IMPORTE")
                            End If
                        End If
                        '   MessageBox.Show(Valoresrepetidos)
                    End If
                End If
            Next
            '    For x = Reportes_datagridview.Rows.Count - 1 To 0 Step -1
            '        'banco_fecha
            '        'banco_nro
            '        'BANCO_DESCRIP
            '        'Banco_importe
            '        If Not x = 0 Then
            '            If (Reportes_datagridview.Rows(x).Cells.Item("Banco_fecha").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("Banco_fecha").Value.ToString) Then
            '                If (Reportes_datagridview.Rows(x).Cells.Item("Banco_Nro").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("Banco_Nro").Value.ToString) Then
            '                    If (Reportes_datagridview.Rows(x).Cells.Item("BANCO_DESCRIP").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("BANCO_DESCRIP").Value.ToString) Then
            '                        If (Reportes_datagridview.Rows(x).Cells.Item("Banco_importe").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("Banco_importe").Value.ToString) Then
            '                            'Reportes_datagridview.Rows(x).Cells.Item("Banco_fecha").Value = DBNull.Value
            '                            'Reportes_datagridview.Rows(x).Cells.Item("Banco_Nro").Value = DBNull.Value
            '                            Reportes_datagridview.Rows(x).Cells.Item("BANCO_DESCRIP").Value = DBNull.Value
            '                            Reportes_datagridview.Rows(x).Cells.Item("Banco_importe").Value = DBNull.Value
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        End If
            '    Next
            Return nuevatablatemporal
        Else
            Return Nothing
        End If
    End Function

    Private Function Detallecompletoconciliacion2(ByVal Paraexcel As Boolean) As DataTable
        If Cuentas_combobox.SelectedIndex >= 0 Then
            Dim Tablatemporal As New DataTable
            SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
            SERVIDORMYSQL.COMMANDSQL.Parameters.Add("Desde", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Desde_datetimepicker.Value.Date
            SERVIDORMYSQL.COMMANDSQL.Parameters.Add("Hasta", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Hasta_DateTimePicker.Value.Date
            Dim consultasql As String =
"TESORERIA_REPORTES_CONCILIACION_DETALLADO"
            Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Return Tablatemporal
        Else
            Return Nothing
        End If
    End Function

    Private Function conciliacionbancounificado() As DataTable
        If Cuentas_combobox.SelectedIndex >= 0 Then
            Dim Tablatemporal As New DataTable
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
MD5HASH,Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,Format(Importe,2, 'es_AR') As 'Importe mov.',Format(Saldo,2, 'es_AR') as 'Saldo',
format(MONTO_ASOCIADO,2, 'es_AR') as Monto_asociar,CASE WHEN ABS(MONTO_ASOCIADO) >0 THEN monto_asociado ELSE 0 END as 'MONTO_ASOCIADO',importe,C.Fechadelmovimiento,c.orden,monto,Clave_expediente_detalle FROM
(select MD5HASH,Cuenta,Fecha,Nro_Transaccion,Descripcion,CATEGORIA,IMPORTE,SALDO as 'Saldo',
CASE WHEN importe>0 THEN md5(Nro_Transaccion+importe) ELSE md5(Nro_Transaccion+importe *-1) END as 'MD5S' FROM reportebanco )A
Left Join
(SELECT SUM(MONTO) AS 'MONTO_ASOCIADO',MD5_relacionado FROM expediente_detalle where NOT ISNULL(MD5_relacionado) group by MD5_relacionado)B
On A.MD5HASH=B.MD5_RELACIONADO
LEFT JOIN
(SELECT md5(Nrotransferencia+Monto) AS MD5CONCILIACION,Fechadelmovimiento,CONCAT(Tipoorden,' N',Orden_N,'/',Orden_year) as Orden,Monto,Clave_expediente_detalle FROM expediente_detalle  where ISNULL(MD5_relacionado)  )C
on A.MD5S=C.MD5CONCILIACION
WHERE ((not (MONTO_ASOCIADO=ABS(IMPORTE))) OR ISNULL(MONTO_ASOCIADO)) AND
(((Fecha BETWEEN @desde AND @hasta)) OR (Fecha=@desde) OR (Fecha=@hasta)) AND
Cuenta=@Cuenta
ORDER BY FECHA DESC, NRO_TRANSACCION DESC", Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Reportes_datagridview.DataSource = Tablatemporal
            Reportes_datagridview.CurrentCell = Nothing
            '    For x = Reportes_datagridview.Rows.Count - 1 To 0 Step -1
            '        'banco_fecha
            '        'banco_nro
            '        'BANCO_DESCRIP
            '        'Banco_importe
            '        If Not x = 0 Then
            '            If (Reportes_datagridview.Rows(x).Cells.Item("Banco_fecha").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("Banco_fecha").Value.ToString) Then
            '                If (Reportes_datagridview.Rows(x).Cells.Item("Banco_Nro").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("Banco_Nro").Value.ToString) Then
            '                    If (Reportes_datagridview.Rows(x).Cells.Item("BANCO_DESCRIP").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("BANCO_DESCRIP").Value.ToString) Then
            '                        If (Reportes_datagridview.Rows(x).Cells.Item("Banco_importe").Value.ToString = Reportes_datagridview.Rows(x - 1).Cells.Item("Banco_importe").Value.ToString) Then
            '                            'Reportes_datagridview.Rows(x).Cells.Item("Banco_fecha").Value = DBNull.Value
            '                            'Reportes_datagridview.Rows(x).Cells.Item("Banco_Nro").Value = DBNull.Value
            '                            Reportes_datagridview.Rows(x).Cells.Item("BANCO_DESCRIP").Value = DBNull.Value
            '                            Reportes_datagridview.Rows(x).Cells.Item("Banco_importe").Value = DBNull.Value
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        End If
            '    Next
            Return Tablatemporal
        Else
            Return Nothing
        End If
    End Function

    Private Function ReporteSafi(ByVal tipo As String) As DataTable
        Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", Autorizaciones.Year & "-01-01")
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@YEAR", Autorizaciones.Year)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Ejercicio", Autorizaciones.Year)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@filtro", tipo)
        Dim consultasql As String =
            "
 Select
Fechadelmovimiento AS 'FECHA',
 case when Cod_orden='4' then concat(Orden_N,'/',Orden_year) else  CASE WHEN (MONTO<>0) THEN ( CASE WHEN (MONTO<0) THEN CONCAT(Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat(b.ordencargo) else '' END	END	) ELSE
 (Case when (LENGTH(B.ORDENPAGO)  OR NOT(b.Ordenpago='')) then b.Ordenpago else case when not isnull(b.ordencargo) then concat(b.ordencargo) else '0' END	END	) END)	ELSE 'ANULADO' END END AS 'ORDEN',
 CASE WHEN (MONTO<>0) THEN	(CASE WHEN NOT ISNULL(B.clave_pedidofondo) THEN  CONCAT (CONVERT((SUBSTRING(B.clave_pedidofondo FROM 9 FOR CHAR_LENGTH(B.clave_pedidofondo) - 4)),UNSIGNED),'/',SUBSTRING(B.clave_pedidofondo FROM 1 FOR CHAR_LENGTH(B.clave_pedidofondo) - 9) )  ELSE 'S/D' END )	ELSE 'ANULADO' END AS 'PF',
 CASE WHEN (MONTO<>0) THEN	(D.CLASE 	)	ELSE 'ANULADO' END AS 'CLASE',
(Expediente_N 	) 'Expediente',
 Nrotransferencia AS 'Nro Transferencia',
 MONTO AS 'IMPORTE',
 CASE WHEN (MONTO<>0) THEN
 (
 CASE WHEN ISNULL(C.PROVEEDOR) OR (C.PROVEEDOR='AFIP') OR (C.PROVEEDOR LIKE '%SERVICIO ADMINISTRATIVO%') THEN
CASE WHEN (MONTO>0) THEN CONCAT(A.DETALLE,  '*')  ELSE CONCAT('[REVERSIÓN]',CONCAT(A.DETALLE,  '*') ) END
 ELSE
  CASE WHEN (MONTO>0) THEN C.PROVEEDOR ELSE CONCAT('[REVERSIÓN]',C.PROVEEDOR) END
 END
 )
 ELSE 'ANULADO' END AS 'BENEFICIARIO',
 Cod_orden,cfdo,CodInp,TOTAL_TRANSF,
Concat(u.apellidos,' ',u.nombres) as 'Autor',Creado_o_modificado as 'Cargado el:',A.Clave_expedientetrim as 'Clave_expediente',cuenta_pedidofondo
from
(
select * from
/* Movimientos creados dentro de la fecha */
(select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where  NOT(NROTRANSFERENCIA=0)   and
CASE WHEN @filtro='INGRESOS' THEN CODINP=3
ELSE CASE WHEN @filtro='EGRESOS' THEN CODINP=1 ELSE CASE WHEN @filtro='RETENCIONES' THEN CODINP=1 ELSE NOT CODINP=0 END
END
END
and
/*DETERMINACIÓN DE QUE EL MOVIMIENTO SE ENCUENTRA DENTRO LA CUENTA SELECCIONADA*/
/* SE DETERMINA QUE EL PEDIDO DE FONDO ASOCIADO AL MOVIMIENTO SE ENCUENTRA DENTRO DE LA CUENTA SELECCIONADA*/
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4)
IN
        (
Select clave_expediente from
((select clave_expediente,clave_pedidofondo from cuit_movimiento
union all
select clave_expediente,clave_pedidofondo  from expediente where not isnull(clave_pedidofondo)
)cuites
inner join
(select clave_pedidofondo from pedido_fondos)pedfon
on cuites.clave_pedidofondo=pedfon.clave_pedidofondo
)
)
/* FIN - SE DETERMINA QUE EL PEDIDO DE FONDO ASOCIADO AL MOVIMIENTO SE ENCUENTRA DENTRO DE LA CUENTA SELECCIONADA*/
				OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE not ISNULL(cuenta_especial))
/*FIN - DETERMINACIÓN DE QUE EL MOVIMIENTO SE ENCUENTRA DENTRO LA CUENTA SELECCIONADA*/
				)
AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) OR
(date(Creado_o_modificado)= date(@DESDE) OR date(Creado_o_modificado)=date(@HASTA))
)
				union all
/* Movimientos MODIFICADOS dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle
where  NOT(NROTRANSFERENCIA=0)   and
CASE WHEN @filtro='INGRESOS' THEN CODINP=3
ELSE CASE WHEN @filtro='EGRESOS' THEN CODINP=1 ELSE CASE WHEN @filtro='RETENCIONES' THEN CODINP=1 ELSE NOT CODINP=0 END
END
END
and
(
not (date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo )) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta)))
						AND Fechadelmovimiento>CONCAT(@YEAR -1,'-12-31')
				union all
				/* Movimientos EN NEGATIVO dentro de la fecha */
select SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim,
Clave_expediente_detalle,Expediente_N,Detalle,Monto *-1,Cod_orden,CFdo,CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Fechadelmovimiento,Total_factura,Clave_expediente_detalle_principal,ClavePedidofondo,Tipoorden,Orden_N,Orden_year,
Creado_o_modificado,MD5_relacionado,Usuario
 from expediente_detalle_HISTORIAL
where   NOT(NROTRANSFERENCIA=0) and
CASE WHEN @filtro='INGRESOS' THEN CODINP=3
ELSE CASE WHEN @filtro='EGRESOS' THEN CODINP=1 ELSE CASE WHEN @filtro='RETENCIONES' THEN CODINP=1 ELSE NOT CODINP=0 END
END
END
and    CLAVE_EXPEDIENTE_DETALLE IN
(select Clave_expediente_detalle
 from expediente_detalle
where
   NOT(NROTRANSFERENCIA=0)   AND
((date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(date(Creado_o_modificado)>= date(@DESDE) and date(Creado_o_modificado)<=date(@HASTA)) and
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN
					(SELECT clave_pedidofondo FROM pedido_fondos )) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente )))
				AND Fechadelmovimiento>CONCAT(@YEAR -1,'-12-31')
				)
				GROUP BY CLAVE_EXPEDIENTE_DETALLE
				)J
where CLAVE_EXPEDIENTE_DETALLE not in (select Retencion_Clave_detalle from retenciones where not isnull(Retencion_Clave_detalle))
				)A
/* DATOS DE LOS EXPEDIENTES*/
LEFT JOIN
(
select Clave_pedidofondo,pedfondos.CLAVE_EXPEDIENTE,
CASE WHEN NOT ISNULL(clave_ordenpago) THEN
CASE WHEN LENGTH(Clave_Ordenpago)>8 THEN
CLAVE_TO_NUMEROYANIO(clave_ordenpago)
ELSE
ORDENPAGO
END
ELSE
ORDENPAGO END
AS ORDENPAGO,
ORDENCARGO
 from
(
select max(clave_pedidofondo)as Clave_pedidofondo,clave_expediente,max(Ordenpago) AS Ordenpago,max(ordencargo) AS ordencargo from
(select CLAVE_EXPEDIENTE,Clave_pedidofondo,NULL as Ordenpago, NULL as ordencargo  from cuit_movimiento
union all
select clave_expediente,Clave_pedidofondo,Ordenpago,ordencargo from expediente
)pedfondos1
group by clave_expediente)pedfondos
left join
(select max(clave_ordenpago) as clave_ordenpago,clave_expediente from contabilidad_ordenpago group by clave_expediente)ordenespago
on pedfondos.clave_expediente=ordenespago.clave_expediente
)b
On A.Clave_expedientetrim=B.Clave_expediente
/* DATOS DE LOS CHEQUES */
LEFT JOIN
(SELECT Nrotransferencia AS CHEQUE, SUM(MONTO) AS 'TOTAL_TRANSF' FROM expediente_detalle GROUP BY Nrotransferencia)T
On A.Nrotransferencia=T.CHEQUE
/* DATOS DE LOS PROVEEDORES*/
LEFT JOIN
(SELECT CUIT,PROVEEDOR FROM proveedores WHERE NOT CUIT=0)C
On A.CUIT=C.CUIT
/* DATOS DE PEDIDOS DE FONDOS*/
LEFT JOIN
(SELECT clave_pedidofondo,CASE WHEN (CLASE_FONDO=@EJERCICIO) THEN 'EJ.' ELSE CONCAT('RP/',CLASE_FONDO) END   AS 'CLASE',CLASE_FONDO FROM pedido_fondos WHERE NOT CLASE_FONDO=1)D
On B.CLAVE_PEDIDOFONDO=D.CLAVE_PEDIDOFONDO
/* DATOS DE USUARIOS*/
LEFT JOIN
(SELECT usuario,apellidos,nombres FROM contaduria_usuarios.usuarios )U
On A.usuario=U.usuario
LEFT JOIN
(SELECT Cuenta_pedidofondo,clave_pedidofondo FROM pedido_fondos )pffodos
On pffodos.clave_pedidofondo=b.clave_pedidofondo
 ORDER BY CLAVE_EXPEDIENTE_DETALLE,MONTO ASC
"
        '  dfsdfsdfsd
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function MFYV_GROUP_NROTRANSFERENCIA() As DataTable
        Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            " SELECT * FROM
(SELECT Nrotransferencia,SUM(INGRESOS) AS 'INGRESOS',
SUM(EGRESOS) AS 'EGRESOS',
(SUM(INGRESOS)-SUM(EGRESOS)) AS 'DIFERENCIA',
GROUP_CONCAT( DISTINCT CONCAT(Expediente_N,'/',Expediente_year,' ')) AS 'EXPEDIENTES INVOLUCRADOS',
GROUP_CONCAT( DISTINCT CONCAT(PEDIDOFONDO_n,' ')) AS 'PF',
Cuenta_N FROM MFYV  where Cuenta_N=@Cuenta
and fecha BETWEEN @desde and @hasta
GROUP BY Nrotransferencia)MFYV
ORDER BY ABS(DIFERENCIA) "
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function MFYV_GROUP_EXPEDIENTE() As DataTable
        Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            " SELECT * FROM
(SELECT CONCAT(Expediente_N,'/',Expediente_year) AS 'Expediente Nº',SUM(INGRESOS) AS 'INGRESOS',
SUM(EGRESOS) AS 'EGRESOS',
(SUM(INGRESOS)-SUM(EGRESOS)) AS 'DIFERENCIA',
GROUP_CONCAT( DISTINCT CONCAT(' ',Nrotransferencia,' ')) AS 'Nros Transf. involucrados',
Cuenta_N FROM MFYV  where Cuenta_N=@Cuenta
and fecha BETWEEN @desde and @hasta
 GROUP BY clave_expediente )MFYV
ORDER BY ABS(DIFERENCIA) "
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function SICYF_RETENCIONESSELECCIONADAS() As DataTable
        Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Dim consultasql As String =
            " select recibos.Nro_recibo,recibos.TOTAL,recibos.cuit,PROVEEDOR.PROVEEDOR,
CASE WHEN movimientos.Nombre_retencion='SUSS' THEN
case when sum(movimientos.monto_retenido)>0 then sum(movimientos.monto_retenido) else 0 end ELSE 0 END AS 'SUSS',
CASE WHEN movimientos.Nombre_retencion='GANANCIAS' THEN
case when sum(movimientos.monto_retenido)>0 then sum(movimientos.monto_retenido) else 0 end ELSE 0 END AS 'GANANCIAS',
CASE WHEN movimientos.Nombre_retencion='DGR' THEN
case when sum(movimientos.monto_retenido)>0 then sum(movimientos.monto_retenido) else 0 end ELSE 0 END AS 'DGR',
CASE WHEN movimientos.Nombre_retencion='IVA' THEN
case when sum(movimientos.monto_retenido)>0 then sum(movimientos.monto_retenido) else 0 end ELSE 0 END AS 'IVA',
CASE WHEN movimientos2.Nombre_retencion='SUSS' THEN
case when sum(movimientos2.monto_retenido)>0 then sum(movimientos2.monto_retenido) else 0 end ELSE 0 END AS 'PAGADO SUSS',
CASE WHEN movimientos2.Nombre_retencion='GANANCIAS' THEN
case when sum(movimientos2.monto_retenido)>0 then sum(movimientos2.monto_retenido) else 0 end ELSE 0 END AS 'PAGADO GANANCIAS',
CASE WHEN movimientos2.Nombre_retencion='DGR' THEN
case when sum(movimientos2.monto_retenido)>0 then sum(movimientos2.monto_retenido) else 0 end ELSE 0 END AS 'PAGADO DGR',
CASE WHEN movimientos2.Nombre_retencion='IVA' THEN
case when sum(movimientos2.monto_retenido)>0 then sum(movimientos2.monto_retenido) else 0 end ELSE 0 END AS 'PAGADO IVA'
FROM
(select * from tesoreria_recibos  where FECHA_RECIBO between @desde and @hasta)recibos
left join
(select * from retenciones where not isnull(nro_recibo) AND ISNULL(Retencion_Clave_detalle))movimientos
on concat(recibos.Nro_recibo,recibos.cuit)=concat(movimientos.nro_recibo,movimientos.cuit)
left join
(select * from retenciones where not isnull(nro_recibo) AND NOT ISNULL(Retencion_Clave_detalle))movimientos2
on concat(recibos.Nro_recibo,recibos.cuit)=concat(movimientos2.nro_recibo,movimientos2.cuit)
left join
(select * from proveedores)PROVEEDOR
on PROVEEDOR.CUIT=RECIBOS.CUIT
 group by recibos.Nro_recibo,recibos.cuit
 ORDER BY PROVEEDOR ASC "
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tablatemporal
    End Function

    Private Function panelabmp(ByVal panele As Panel, ByVal rect As System.Drawing.Rectangle) As Bitmap
        Dim BMPs As New Bitmap(rect.Width, rect.Height)
        panele.DrawToBitmap(BMPs, rect)
        Return BMPs
    End Function

    Private Sub Paneldeimpresion_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Reportes_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Reportes_datagridview.DataError
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Reportesgenerales.ExportDataToPDFTable(Reportes_datagridview, TipoReporte.Text.ToUpper)
    End Sub

    Private Sub Year_pedidofondo_numeric_ValueChanged(sender As Object, e As EventArgs) Handles Year_numeric.ValueChanged
        Reportes_datagridview.DataSource = Nothing
    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        If TipoReporte.Text.Length > 2 Then
            Dim textual As String = ""
            Inicio.OBJETOCARGANDO(SplitContainergeneral.Panel2, Me, "Generando reporte...")
            Reportes_datagridview.BackgroundColor = Color.White
            textual = Busqueda_textbox.Text
            Busqueda_textbox.Text = ""
            Recalcular()
            Inicio.OBJETOFINALIZAR(SplitContainergeneral.Panel2, Me)
            Busqueda_textbox.Text = textual
            Reportes_datagridview.Enabled = True
        Else
            MsgBox("Por favor seleccione el tipo de Reporte que desea Visualizar")
        End If
    End Sub

    Private Sub Cargando()
        Dim tt As Thread = New Thread(AddressOf Recalcular)
        tt.Start()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Boton_Seleccionreporte.Click
        DialogDialogo_Datagridview.Carga_General(reportes_datatables_menu, "Seleccione la vista deseada", "Seleccionar", "Cancelar")
        DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            TipoReporte.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
            Me.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
            'If Cargando() = False Then
            '    Refresh_General()
            'End If
        Else
            '   Labelcuentaespecialasignada.Text = ""
        End If
        If TipoReporte.Text.Length > 2 Then
            Panelfechas.Visible = True
        Else
            Panelfechas.Visible = False
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
    End Sub

    Private Sub Reportes_datagridview_KeyDown(sender As Object, e As KeyEventArgs) Handles Reportes_datagridview.KeyDown
        Try
            Select Case e.KeyValue
                Case Is = Keys.F10
                    For x = 0 To Cuentas_combobox.Items.Count - 1
                        Cuentas_combobox.SelectedIndex = x
                        Recalcular()
                        If Reportes_datagridview.Rows.Count > 0 Then
                            hojahorizontal(Reportes_datagridview)
                        End If
                    Next
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(Busqueda_textbox, CType(Reportes_datagridview.DataSource, DataTable), CType(Reportes_datagridview, DataGridView))
        Reportes_datagridview.DataSource = Nothing
    End Sub

    Private Sub ActualizarusuarioSafi(ByVal _user As String, ByVal _pwd As String)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@UsuarioSafi", _user)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@PwdSafi", SERVIDORMYSQL.ENCRIPTACION.Encriptar(_pwd))
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@usuario2", Autorizaciones.Usuario.Rows(0).Item("usuario").ToString)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "update Usuarios set UsuarioSafi=@UsuarioSafi,PwdSafi=@PwdSafi WHERE usuario=@usuario2"
        Inicio.INSERTSQLPARAMETROS("Contaduria_usuarios", System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Private Function DatagridtoMovimientoSafi(ByVal Reportes_datagridview As DataGridView) As nuevomovimiento_safi()
        Dim CONTROL As DataGridViewRow = Nothing
        Dim M() As nuevomovimiento_safi = Nothing
        For Each item As DataGridViewRow In Reportes_datagridview.SelectedRows
            If item.Cells.Item("IMPORTE").Value <> 0 Then
                CONTROL = item
                M.Add(New nuevomovimiento_safi)
                M(M.Length - 1).Ejercicio = Autorizaciones.Year
                M(M.Length - 1).Cuentabancaria = item.Cells.Item("CUENTA_PEDIDOFONDO").Value.ToString.Substring(5)
                'Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Substring(5) & "-"
                '& Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(1).ToString
                M(M.Length - 1).codorden = item.Cells.Item("cod_orden").Value
                M(M.Length - 1).clasefondo = item.Cells.Item("Cfdo").Value
                M(M.Length - 1).codinp = item.Cells.Item("codinp").Value
                M(M.Length - 1).Nropedidofondo = Divisordedosvariables(item.Cells.Item("PF").Value.ToString)(0)
                Select Case M(M.Length - 1).codinp
                    Case = 1
                        M(M.Length - 1).Nroorden = Divisordedosvariables(item.Cells.Item("ORDEN").Value.ToString)(0)
                    Case = 3
                        M(M.Length - 1).Nroentregafondo = Divisordedosvariables(item.Cells.Item("ORDEN").Value.ToString)(0)
                End Select
                M(M.Length - 1).Codigoexpediente = DIVISORUNIVERSAL(item.Cells.Item("expediente").Value.ToString.Replace("-/", "/"))(0)
                M(M.Length - 1).Correlativo = DIVISORUNIVERSAL(item.Cells.Item("expediente").Value.ToString.Replace("-/", "/"))(1)
                M(M.Length - 1).Anio = DIVISORUNIVERSAL(item.Cells.Item("expediente").Value.ToString.Replace("-/", "/"))(2)
                M(M.Length - 1).Nrocomprobante = item.Cells.Item("Nro Transferencia").Value
                M(M.Length - 1).Fechadecomprobante = CType(item.Cells.Item("FECHA").Value, Date).ToString("dd/MM/yyyy")
                M(M.Length - 1).Descripcion = item.Cells.Item("BENEFICIARIO").Value & " (" & Inicialesstring(item.Cells.Item("AUTOR").Value) & ")"
                M(M.Length - 1).Importe = item.Cells.Item("IMPORTE").Value
            End If
        Next
        Return M
    End Function

    Private Sub SAFI_fillwebform()
        'Try
        Dim CONEXION As New dialogo_login
        CONEXION.UsernameTextBox.Text = Autorizaciones.Usuario.Rows(0).Item("UsuarioSafi").ToString
        CONEXION.PasswordTextBox.Text = SERVIDORMYSQL.ENCRIPTACION.Desencriptar(Autorizaciones.Usuario.Rows(0).Item("PwdSafi"))
        If (CONEXION.ShowDialog() = DialogResult.OK) Then
            Dim M() As nuevomovimiento_safi = DatagridtoMovimientoSafi(Reportes_datagridview)
            Dim S As New Safi_webform
            If Not ((CONEXION.UsernameTextBox.Text = Autorizaciones.Usuario.Rows(0).Item("UsuarioSafi").ToString) And (CONEXION.PasswordTextBox.Text = SERVIDORMYSQL.ENCRIPTACION.Desencriptar(Autorizaciones.Usuario.Rows(0).Item("PwdSafi").ToString))) Then
                If CONEXION.Recordarme_checkbox.Checked Then
                    ActualizarusuarioSafi(CONEXION.UsernameTextBox.Text, CONEXION.PasswordTextBox.Text)
                End If
            End If
            If user.Length = 0 Then
                user = CONEXION.UsernameTextBox.Text
                Pwdss = CONEXION.PasswordTextBox.Text
            End If
            S.User = user
            S.PWD = Pwdss
            S.Ejecutarlogin()
            S.Iranuevomovimiento()
            For Each MovimientoSafi As nuevomovimiento_safi In M
                'cargar?
                S.Cargarnuevomovimientov2(MovimientoSafi)
                Thread.Sleep(1000)
                S.GuardarIrNuevoFormulario()
            Next
            Thread.Sleep(1500)
            S.Close()
            Dim Message As New MessageToastie
            With Message
                .MessageTexto = "Finalizada la Carga"
                .TituloMessage = "Carga Safi"
            End With
            Message.Message()
            Me.BringToFront()
            MessageBox.Show("FINALIZADO")
        Else
            MessageBox.Show("CANCELADO")
        End If
    End Sub

    Private Sub TipoReporte_TextChanged(sender As Object, e As EventArgs) Handles TipoReporte.TextChanged
        Accionesalmodificartiporeporte()
    End Sub

    Private Sub Accionesalmodificartiporeporte()
        Select Case TipoReporte.Text.ToUpper
            Case Is = "HOJA DE LIBRO BANCO INGRESOS"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Libro_Banco(3)
            Case Is = "HOJA DE LIBRO BANCO EGRESOS"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Libro_Banco(1)
            Case Is = "HOJA DE LIBRO BANCO RENDICIONES"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Libro_Banco(2)
            Case Is = "HOJA DE LIBRO BANCO RETENCIONES"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Libro_Banco(99)
            Case Is = "HOJA DE LIBRO BANCO HABERES"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Libro_Banco(98)
            Case Is = "VERIFICAR INGRESOS TESORERIA"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = False
                reportes_datatables = Libro_Banco(33)
            Case Is = "VERIFICAR INGRESOS POR DIA TESORERIA GENERAL"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = False
                reportes_datatables = Libro_Banco(34)
                    'Reportes_datagridview.Columns("Clave_expediente").Visible = False
            Case Is = "CONCILIACION EN FECHAS SELECCIONADAS"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Generaciondeconciliacion()
            Case Is = "CONCILIACIÓN EN LAS FECHAS SELECCIONADAS 2"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Generaciondeconciliacion2()
            Case Is = "ESTADO POR PEDIDOS DE FONDOS"
                Cuentas_combobox.Visible = True
                reportes_datatables = pedidosdefondo()
            Case Is = "ESTADO POR EXPEDIENTES"
                Cuentas_combobox.Visible = True
                reportes_datatables = porexpedientes()
            Case Is = "MOVIMIENTOS DE FONDOS Y VALORES"
                Cuentas_combobox.Visible = True
                Panelfechas.Visible = True
                Reportes_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                reportes_datatables = Movimientodefondosyvalores()
                    'Tamaños de Columnas
            Case Is = "MODIFICADO MOVIMIENTOS DE FONDOS Y VALORES"
                Cuentas_combobox.Visible = True
                Panelfechas.Visible = True
                Reportes_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                reportes_datatables = Movimientodefondosyvalores()
            Case Is = "LISTADO DE EXPEDIENTES"
                Cuentas_combobox.Visible = True
                reportes_datatables = Listadoexpedientes()
            Case Is = "CUENTA BANCARIA TOTALES"
                Cuentabancariatotales()
            Case Is = "CUENTA BANCARIA TOTALES POR PERIODO"
                Panelfechas.Visible = True
                reportes_datatables = Cuentabancariatotalesfechas()
            Case Is = "PEDIDO DE FONDOS DETALLE POR FECHA"
                Panelfechas.Visible = True
                reportes_datatables = pedidosfondodetalle()
            Case Is = "CONCILIACION CHEQUES NO COBRADOS"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Chequessincobrar()
            Case Is = "CONCILIACION INGRESOS NO REGISTRADOS"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Ingresossinregistrar()
            Case Is = "CONCILIACION DETALLADO"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Detallecompletoconciliacion2(False)
            Case Is = "CONCILIACION DETALLADO VERSION PARA EXCEL"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = Detallecompletoconciliacion2(True)
            Case Is = "CONCILIACION BANCO UNIFICADO"
                MessageBox.Show("Reporte para completar")
            Case Is = "REPORTE CARGA SAFI INGRESOS"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = False
                Reportes_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                reportes_datatables = ReporteSafi("INGRESOS")
            Case Is = "REPORTE CARGA SAFI EGRESOS"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = False
                Reportes_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                reportes_datatables = ReporteSafi("EGRESOS")
                    'ingresos,egresos,rendido,ingresos MFyV,egresos MFyV,Diferencia Ingresos, Diferencia Egresos
            Case Is = "MFYV AGRUPADOS POR Nº TRANSFERENCIA"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                Reportes_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                reportes_datatables = MFYV_GROUP_NROTRANSFERENCIA()
            Case Is = "MFYV AGRUPADOS POR EXPEDIENTE"
                Panelfechas.Visible = True
                Cuentas_combobox.Visible = True
                reportes_datatables = MFYV_GROUP_EXPEDIENTE()
            Case Is = "RETENCIONES EN EL PERIODO SELECCIONADO"
                Panelfechas.Visible = True
                'Cuentas_combobox.Visible = True
                reportes_datatables = SICYF_RETENCIONESSELECCIONADAS()
        End Select
    End Sub

End Class