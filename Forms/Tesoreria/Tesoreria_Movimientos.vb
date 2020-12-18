Imports System.Text.RegularExpressions

Public Class Tesoreria_Movimientos
    Dim datagridseleccionado As Object
    Dim datosExpediente As New DataTable
    Dim datosExpedienteIntermedio As New DataTable
    Dim datosexpediente_detalle As New DataTable
    Dim Busquedasql As String = ""
    Dim Pedidodefondosql As String = ""
    Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    Dim Cargainicial As Boolean = True
    Dim Esmodificado As Boolean = True
    Dim fechamovimientobloqueada As Boolean = False
    Dim tipodemovimiento_datatable As New DataTable
    'declaración de expediente
    Dim Expediente_actual As New Expediente
    Dim Movimiento_actual As New Movimiento
    Dim Factura_actual As New Factura
    Dim CARGANDOCODIGOS As Boolean = False
    'manejo de botones
    Dim codorden(5) As Button
    Dim clasefondos(2) As Button
    Dim codimputacion(4) As Button
    Dim botonesbreadcrumb(13) As Button
    Dim cuentabancariaguardar As String = ""
    Private Structure detalles
        Shared detalle As String
        Shared fecha As Date
        Shared tipomovimiento As String
        Shared beneficiario As String
    End Structure
    Dim detalle_estructura As New detalles

    Private Sub Datosexpedientes_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosexpedientes_datagridview.CellEnter
        '   'Datos del expediente deben ser cargados al seleccionar uno de las celdas
        If Datosexpedientes_datagridview.SelectedRows.Count = 1 Then
            Retenciones_Datagridview.DataSource = Nothing
            Inicio.OBJETOCARGANDO(SplitContainer_superior.Panel2, Me, "Cargando...",, New Point(SplitContainer_superior.SplitterDistance, 0))
            refreshnowdetallado()
            Inicio.OBJETOFINALIZAR(SplitContainer_superior.Panel2, Me)
        Else
            Datosexpedientesdetalle_datagridview.DataSource = Nothing
            Retenciones_Datagridview.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Datosexpedientes_datagridview.MouseWheel, Datosexpedientesdetalle_datagridview.MouseWheel
        Flicker_Datagridview.Flicker_Datagrid_MouseWheel(sender, e)
    End Sub

    'public sub MOUSE DERECHO, sujeto a mejoras
    Private Sub MOUSEDERECHO(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object)
        datagridseleccionado = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf MENUCONTEXTUAL
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf MENUCONTEXTUAL
        'Opciones especificas de cada datagridview
        If datagridseleccionado.selectedrows.count > 0 Then
            Select Case datagridseleccionado.name.ToString.ToUpper
                Case Is = Datosexpedientesdetalle_datagridview.Name.ToUpper
                    Dim item10 = cms.Items.Add("Ver movimiento en MFyV")
                    item10.Tag = 10
                    AddHandler item10.Click, AddressOf MENUCONTEXTUAL
                    Dim item11 = cms.Items.Add("buscar monto en MFyV")
                    item11.Tag = 11
                    AddHandler item11.Click, AddressOf MENUCONTEXTUAL
                    Dim item12 = cms.Items.Add("Ver Historial de modificación de este movimiento")
                    item12.Tag = 12
                    AddHandler item12.Click, AddressOf MENUCONTEXTUAL
                    If datagridseleccionado.selectedrows(0).cells.item("CODINP").value = 1 Then
                        Dim item13 = cms.Items.Add("Generar Certificado de Retenciones")
                        item13.Tag = 13
                        AddHandler item13.Click, AddressOf MENUCONTEXTUAL
                    End If
                    Dim item14 = cms.Items.Add("Certificado de retenciones y totales para el Nro de cheque o Transf")
                    item14.Tag = 14
                    AddHandler item14.Click, AddressOf MENUCONTEXTUAL
                    Dim item15 = cms.Items.Add("Total sobre Nro de cheque o transf")
                    item15.Tag = 15
                    AddHandler item15.Click, AddressOf MENUCONTEXTUAL
                    Dim item16 = cms.Items.Add("Certificado sobre Nro de cheque o transf")
                    item16.Tag = 16
                    AddHandler item16.Click, AddressOf MENUCONTEXTUAL
                    Dim item17 = cms.Items.Add("Certificado sobre CUIT en la fecha del movimiento")
                    item17.Tag = 17
                    AddHandler item17.Click, AddressOf MENUCONTEXTUAL
                Case Is = Datosexpedientes_datagridview.Name.ToUpper
                    Dim item080 = cms.Items.Add("Ver Historial de modificación de este Expediente")
                    item080.Tag = 80
                    AddHandler item080.Click, AddressOf MENUCONTEXTUAL
                    'Para ver los expedientes que conforman el pedido de fondo
                    Dim item08 = cms.Items.Add("Ver Composición de Pedido de fondo")
                    item08.Tag = 8
                    AddHandler item08.Click, AddressOf MENUCONTEXTUAL
                    'Para ver los movimientos que coinciden con el numero de expediente
                    Dim item09 = cms.Items.Add("Ver Detalle de MFyV")
                    item09.Tag = 9
                    AddHandler item09.Click, AddressOf MENUCONTEXTUAL
                    'Para realizar la rendición
                    Dim item10 = cms.Items.Add("Realizar Rendición de este Expediente")
                    item10.Tag = 10
                    AddHandler item10.Click, AddressOf MENUCONTEXTUAL
                Case Else
                    Dim item10 = cms.Items.Add("Ver movimiento en MFyV")
                    item10.Tag = 10
                    AddHandler item10.Click, AddressOf MENUCONTEXTUAL
            End Select
        End If
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub MENUCONTEXTUAL(ByVal sender As Object, ByVal e As EventArgs)
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
                Select Case datagridseleccionado.name.ToString.ToUpper
                    Case Is = Datosexpedientesdetalle_datagridview.Name.ToUpper
                    Case Is = Datosexpedientes_datagridview.Name.ToUpper
                        For X = 0 To datagridseleccionado.ROWS.COUNT - 1
                            PINTARFILA(X)
                        Next
                    Case Else
                        'EN CASO DE QUE Ninguno de los nombres esperados
                        MessageBox.Show(datagridseleccionado.name.ToString.ToUpper)
                End Select
                Exportaraexceltest(datagridseleccionado)
                'Select Case datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Is = "SICYF.FLICKER_DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(datagridseleccionado.GetType.ToString)
                'End Select
            Case Is = 2
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
            Case Is = 3
                PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 8
                Dim tabla_datos As New DataTable
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value)
                Inicio.SQLPARAMETROS(Organismotabla, "  SELECT	CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N, Fecha, Detalle, Ordenpago, Monto
FROM Expediente
WHERE
	Clave_pedidofondo = @Clave_pedidofondo
ORDER BY
	clave_expediente DESC,
	fecha DESC ", tabla_datos, Reflection.MethodBase.GetCurrentMethod.Name)
                Dialogo_datos.mostrardatatable(tabla_datos)
            Case Is = 80
                Dim tabla_datos As New DataTable
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("clave_expediente").Value.ToString & "%")
                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select *
From expediente_detalle_historial where Clave_expediente_detalle like @Clave_expediente order by Fechadelmovimiento desc", tabla_datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Dialogo_datos.mostrardatatable(tabla_datos)
            Case Is = 9
                Dim tabla_datos As New DataTable
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("clave_expediente").Value)
                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Fecha,Detalle,
CASE when not(ingresos=0) and not(codinp=2) then Ingresos else
CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
Concat(cod_orden,Cfdo,CodInp) as 'MFyV',
PedidoFondo_N,Nrotransferencia
From MFyV where clave_expediente=@clave_expediente order by Fecha desc", tabla_datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Dialogo_datos.mostrardatatable(tabla_datos)
            Case Is = 10
                Select Case datagridseleccionado.selectedrows.count
                    Case Is = 1
                        Select Case datagridseleccionado.name.ToString.ToUpper
                            Case Is = Datosexpedientesdetalle_datagridview.Name.ToUpper
                                Dim tabla_datos As New DataTable
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Nrotransferencia").Value)
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("clave_expediente").Value)
                                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Fecha,Detalle,
CASE when not(ingresos=0) and not(codinp=2) then Ingresos else
CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
Concat(cod_orden,Cfdo,CodInp) as 'MFyV',
PedidoFondo_N,Nrotransferencia
From MFyV where clave_expediente=@clave_expediente and NroTransferencia=@Nrotransferencia order by Fecha desc", tabla_datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                Dialogo_datos.mostrardatatable(tabla_datos)
                            Case Is = Datosexpedientes_datagridview.Name.ToUpper
                                'Para realizar la rendición
                                todoacero()
                                Panel_botones.Visible = True
                                COD__ORDEN1.PerformClick()
                                Select Case datagridseleccionado.selectedrows(0).cells.item("Tipo").ToString.ToUpper
                                    Case Is = "EJERCICIO"
                                        Clasefondo2.PerformClick()
                                    Case Else
                                        Clasefondo9.PerformClick()
                                End Select
                                Codigoimputacion2.PerformClick()
                                Cargartotalfactura.PerformClick()
                                Panel_retenciones.Height = 0
                                Movmientos_y_retenciones_splitpanel.SplitterDistance = (Movmientos_y_retenciones_splitpanel.Height) - (Panel_retenciones.Height + Panel_botones.Height + 10)
                                Panel_Formulario.Visible = True
                            Case Else
                                'EN CASO DE QUE Ninguno de los nombres esperados
                                MessageBox.Show(datagridseleccionado.name.ToString.ToUpper)
                        End Select
                    Case Is = 0
                        MessageBox.Show("Debe seleccionar un expediente para poder realizar la rendición del mismo")
                    Case Is > 1
                        MessageBox.Show("Debe seleccionar SOLO un expediente para poder realizar la rendición del mismo")
                End Select
            Case Is = 11
                Select Case datagridseleccionado.selectedrows.count
                    Case Is = 1
                        Select Case datagridseleccionado.name.ToString.ToUpper
                            Case Is = Datosexpedientesdetalle_datagridview.Name.ToUpper
                                Dim tabla_datos As New DataTable
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Nrotransferencia").Value)
                                'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@fechadelmovimiento ", CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("fechadelmovimiento").Value, Date).ToString("yyyy-MM-dd"))
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Monto", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("monto").Value)
                                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select
 CONCAT(Substring(clave_expediente From 5 for 4),'-',
cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as 'Expediente_N',
PedidoFondo_N,
 Fecha,Detalle,
CASE when not(ingresos=0) and not(codinp=2) then Ingresos else
CASE when not(egresos=0) and not(codinp=2) then egresos else 0 END END as 'Monto',
Concat(cod_orden,Cfdo,CodInp) as 'MFyV',Nrotransferencia
From MFyV where (Ingresos=@monto or Egresos=@monto or ingresos=abs(@monto) or egresos=abs(@monto)) order by Fecha desc", tabla_datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                Dialogo_datos.mostrardatatable(tabla_datos)
                            Case Is = Datosexpedientes_datagridview.Name.ToUpper
                                'Para realizar la rendición
                                Nuevomovimiento_boton.PerformClick()
                                COD__ORDEN1.PerformClick()
                                Select Case datagridseleccionado.selectedrows(0).cells.item("Tipo").ToString.ToUpper
                                    Case Is = "EJERCICIO"
                                        Clasefondo2.PerformClick()
                                    Case Else
                                        Clasefondo9.PerformClick()
                                        'FONDOS PERMANENTES VER CASOS
                                        'Clasefondo1.Click.performclick
                                End Select
                                Codigoimputacion2.PerformClick()
                                Cargartotalfactura.PerformClick()
                            Case Else
                                'EN CASO DE QUE Ninguno de los nombres esperados
                                MessageBox.Show(datagridseleccionado.name.ToString.ToUpper)
                        End Select
                    Case Is = 0
                        MessageBox.Show("Debe seleccionar un expediente para poder realizar la rendición del mismo")
                    Case Is > 1
                        MessageBox.Show("Debe seleccionar SOLO un expediente para poder realizar la rendición del mismo")
                End Select
            Case Is = 12
                Select Case datagridseleccionado.selectedrows.count
                    Case Is = 1
                        Select Case datagridseleccionado.name.ToString.ToUpper
                            Case Is = Datosexpedientesdetalle_datagridview.Name.ToUpper
                                Dim tabla_datos As New DataTable
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("clave_expediente_detalle").Value)
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Nrotransferencia").Value)
                                'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@fechadelmovimiento ", CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("fechadelmovimiento").Value, Date).ToString("yyyy-MM-dd"))
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Monto", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("monto").Value)
                                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
SELECT
ESTADO,
autor,
Expediente_N,
Detalle,
Monto,
Fechadelmovimiento,
Nrotransferencia,
Mov_tipo,
CUIT,
Tipoorden,
Orden_year,
Cod_orden,
CFdo,
CodInp,
rendido,
Creado_o_modificado as 'ultima actualización',
case when isnull(Creado_o_modificado2) then Creado_o_modificado else Creado_o_modificado2 end as 'cargado el:'
FROM
(Select 'MOV. ACTUAL' AS ESTADO,
Expediente_N,
Detalle,
Monto,
Fechadelmovimiento,
Nrotransferencia,
Mov_tipo,
CUIT,
Tipoorden,
Orden_year,
TOTAL_FACTURA,
Cod_orden,
CFdo,
CodInp,
rendido,
Creado_o_modificado,
null as 'Creado_o_modificado2',
USUARIO
FROM expediente_detalle where Clave_expediente_detalle=@Clave_expediente_detalle
UNION ALL
Select 'MOV. ANTERIOR' AS ESTADO,
Expediente_N,
Detalle,
Monto,
Fechadelmovimiento,
Nrotransferencia,
Mov_tipo,
CUIT,
Tipoorden,
Orden_year,
TOTAL_FACTURA,
Cod_orden,
CFdo,
CodInp,
rendido,
Creado_o_modificado,
Creado_o_modificado2,
USUARIO
From expediente_detalle_historial where Clave_expediente_detalle=@Clave_expediente_detalle)DETALLES
left join
(Select concat(nombres,' ',apellidos) as autor,usuario from contaduria_usuarios.usuarios)usuarios
on DETALLES.usuario=usuarios. usuario", tabla_datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                Dialogo_datos.mostrardatatable(tabla_datos)
                            Case Is = Datosexpedientes_datagridview.Name.ToUpper
                            Case Else
                                'EN CASO DE QUE Ninguno de los nombres esperados
                                MessageBox.Show(datagridseleccionado.name.ToString.ToUpper)
                        End Select
                    Case Is = 0
                        MessageBox.Show("Debe seleccionar un expediente para poder realizar la rendición del mismo")
                    Case Is > 1
                        MessageBox.Show("Debe seleccionar SOLO un expediente para poder realizar la rendición del mismo")
                End Select
            Case Is = 13
                Select Case datagridseleccionado.selectedrows.count
                    Case Is = 1
                        If datagridseleccionado.selectedrows(0).cells.item("codinp").value = 1 And Retenciones_Datagridview.Rows.Count > 0 Then
                            Movimiento_actual.Generarcertificado(Movimiento_actual)
                        Else
                            MessageBox.Show("El movimiento seleccionado no requiere de Certificado de retenciones")
                        End If
                    Case Is = 0
                        MessageBox.Show("Debe seleccionar un expediente para generar el certificado de retención")
                    Case Is > 1
                        MessageBox.Show("Debe seleccionar SOLO un expediente para generar el certificado de retención")
                End Select
            Case Is = 14
                Select Case datagridseleccionado.selectedrows.count
                    Case Is = 1
                        If datagridseleccionado.selectedrows(0).cells.item("codinp").value = 1 Then
                            Inicio.OBJETOCARGANDO(SplitContainer_superior, Me, "Cargando Certificados",, New Point(SplitContainer_superior.SplitterDistance, 0))
                            Movimiento_actual.Generarcertificadosmultiple(Movimiento_actual)
                            Inicio.OBJETOFINALIZAR(SplitContainer_superior, Me)
                        Else
                            MessageBox.Show("El movimiento seleccionado no requiere de Certificado de retenciones")
                        End If
                    Case Is = 0
                        MessageBox.Show("Debe seleccionar un expediente para generar el certificado de retención")
                    Case Is > 1
                        MessageBox.Show("Debe seleccionar SOLO un expediente para generar el certificado de retención")
                End Select
            Case Is = 15
                Select Case datagridseleccionado.selectedrows.count
                    Case Is = 1
                        Movimiento_actual.Vertotalespornrotransferencia(datagridseleccionado.selectedrows(0).cells.item("nrotransferencia").value)
                    Case Is = 0
                        MessageBox.Show("Debe seleccionar un expediente para ver los totales")
                    Case Is > 1
                        MessageBox.Show("Debe seleccionar un expediente para ver los totales")
                End Select
            Case Is = 16
                Select Case datagridseleccionado.selectedrows.count
                    Case Is = 1
                        Dim NROS As New List(Of Double)
                        NROS.Add(datagridseleccionado.selectedrows(0).cells.item("nrotransferencia").value)
                        Movimiento_actual.Generarcertificadopago(NROS)
                    Case Is = 0
                        MessageBox.Show("Debe seleccionar un expediente para ver los totales")
                    Case Is > 1
                        MessageBox.Show("Debe seleccionar un expediente para ver los totales")
                End Select
            Case Is = 17
                MessageBox.Show("Aún no implementado por favor utilice el certificado que se encuentra en el modulo RETENCIONES -Recibo " & vbCrLf & "Informe sobre los expedientes Seleccionados")
            Case Else
                MessageBox.Show("Aún no implementado---")
        End Select
        '-- etc
    End Sub

    '/public sub MOUSE DERECHO
    Private Sub botones_invisibles()
        If Not IsNothing(codimputacion(0)) Then
            For x = 0 To 4
                codimputacion(x).Visible = False
            Next
        End If
        If Not IsNothing(clasefondos(0)) Then
            For x = 0 To 2
                clasefondos(x).Visible = False
            Next
        End If
    End Sub

    'verificarrrrr
    Private Sub coloresdeboton(ByVal sender_boton As Button, ByVal lista_boton() As Button)
        Dim X As Integer = 0
        For Each item In lista_boton
            lista_boton(X).BackColor = Color.FromArgb(165, 220, 243)
            lista_boton(X).ForeColor = Color.FromArgb(28, 77, 134)
            X = X + 1
        Next
        sender_boton.BackColor = Color.FromArgb(28, 77, 134)
        sender_boton.ForeColor = Color.FromArgb(165, 220, 243)
        If lista_boton(0).Name = codimputacion(0).Name Then
        End If
    End Sub

    Private Sub coloresdebotonallgray(ByRef lista_boton() As Button)
        Dim X As Integer = 0
        If Not IsNothing(lista_boton(X)) Then
            For Each item In lista_boton
                'Try
                lista_boton(X).BackColor = Color.FromArgb(211, 221, 221)
                'Catch ex As Exception
                'End Try
                '
                X += 1
            Next
            Select Case lista_boton(0).Name
                Case Is = "COD__ORDEN1"
                    Label_Codorden.Text = "-"
                Case Is = "Clasefondo1"
                    LabelClasefondo.Text = "-"
                Case Is = "Codigoimputacion1"
                    Label_Codimp.Text = "-"
            End Select
        End If
    End Sub

    '/verificarrrrrr
    Private Sub Botones_colores()
        For x = 0 To 12
            botonesbreadcrumb(x).BackColor = Color.FromArgb(211, 221, 221)
        Next
    End Sub

    Private Sub Cuitdialogomostrar()
        Dialogo_CUIT.Cargadetextbox(Cuitdelbeneficiario_textbox)
        Dialogo_CUIT.Cargadecuits(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
    End Sub

    Private Sub IVAdatos()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitdelbeneficiario_textbox.Text)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, Date.DaysInMonth(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month)))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, 1))
        Mostrar_info_retenciones("Datos de las retenciones por IVA en el mes para este CUIT", "
Select Proveedor,FORMAT(Monto,2,'es_AR') AS 'Monto Factura', DATE_FORMAT(FECHADELMOVIMIENTO,'%d/%m/%Y') as 'Fecha' ,
CONCAT(Substring(Clave_expediente_detalle From 5 for 4),'-',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(Clave_expediente_detalle From 1 for 4)) as Expediente,detalle
 from (Select CUIT,monto,Clave_expediente_detalle,detalle,fechadelmovimiento from expediente_Detalle where CUIT=@CUIT and (fechadelmovimiento between @SD AND @ED) and CODINP=1 )A
left join
(Select CUIT,PROVEEDOR,NOMBREFANTASIA from proveedores)B
on a.cuit=b.cuit", "IVAdatos")
    End Sub

    Private Sub SUSSdatos()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitdelbeneficiario_textbox.Text)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, Date.DaysInMonth(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month)))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, 1))
        Mostrar_info_retenciones("Datos de las retenciones por SUSS en el mes para este CUIT", "Select Proveedor,FORMAT(Monto,2,'es_AR') AS 'Monto Factura', DATE_FORMAT(FECHADELMOVIMIENTO,'%d/%m/%Y') as 'Fecha' ,
CONCAT(Substring(Clave_expediente_detalle From 5 for 4),'-',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(Clave_expediente_detalle From 1 for 4)) as Expediente,detalle
 from (Select CUIT,monto,Clave_expediente_detalle,detalle,fechadelmovimiento from expediente_Detalle where CUIT=@CUIT and (fechadelmovimiento between @SD AND @ED) and CODINP=1 )A
left join
(Select CUIT,PROVEEDOR,NOMBREFANTASIA from proveedores)B
on a.cuit=b.cuit", "IVAdatos")
    End Sub

    Private Sub GANANCIASdatos()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitdelbeneficiario_textbox.Text)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, Date.DaysInMonth(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month)))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, 1))
        Mostrar_info_retenciones("Datos de las retenciones por GANANCIAS en el mes para este CUIT", "Select Proveedor,FORMAT(Monto,2,'es_AR') AS 'Monto Factura', DATE_FORMAT(FECHADELMOVIMIENTO,'%d/%m/%Y') as 'Fecha' ,
CONCAT(Substring(Clave_expediente_detalle From 5 for 4),'-',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(Clave_expediente_detalle From 1 for 4)) as Expediente,detalle
 from (Select CUIT,monto,Clave_expediente_detalle,detalle,fechadelmovimiento from expediente_Detalle where CUIT=@CUIT and (fechadelmovimiento between @SD AND @ED) and CODINP=1 )A
left join
(Select CUIT,PROVEEDOR,NOMBREFANTASIA from proveedores)B
on a.cuit=b.cuit
", "IVAdatos")
    End Sub

    Private Sub RENTASdatos()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitdelbeneficiario_textbox.Text)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@ED", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, Date.DaysInMonth(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month)))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@SD", New Date(Movimientofecha_calendar.Value.Year, Movimientofecha_calendar.Value.Month, 1))
        Mostrar_info_retenciones("Datos de las retenciones por RENTAS en el mes para este CUIT", "Select Proveedor,FORMAT(Monto,2,'es_AR') AS 'Monto Factura', DATE_FORMAT(FECHADELMOVIMIENTO,'%d/%m/%Y') as 'Fecha' ,
CONCAT(Substring(Clave_expediente_detalle From 5 for 4),'-',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(Clave_expediente_detalle From 1 for 4)) as Expediente,detalle
 from (Select CUIT,monto,Clave_expediente_detalle,detalle,fechadelmovimiento from expediente_Detalle where CUIT=@CUIT and (fechadelmovimiento between @SD AND @ED) and CODINP=1 )A
left join
(Select CUIT,PROVEEDOR,NOMBREFANTASIA from proveedores)B
on a.cuit=b.cuit", "IVAdatos")
    End Sub

    Private Sub wait(ByVal miliseconds As Integer)
        For i As Integer = 0 To miliseconds * 1
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        Select Case Cuentas_combobox.SelectedIndex >= 0
            Case True
                If Not Cargainicial Then
                    Inicio.OBJETOCARGANDO(Panel13, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
                    refreshnowgeneral()
                    Inicio.OBJETOFINALIZAR(Panel13, Me)
                End If
                ' Numero_cuentalabel.Text = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(1).ToString
        End Select
    End Sub

    Private Sub Expedientes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Nrotransferencia_textbox.Controls(0).Visible = False
        'Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-AR")
        Inicio.Fondosplittercolor(SplitContainer_superior)
        'Inicio.Fondosplittercolor(SplitContainervertical)
        codorden(0) = COD__ORDEN1
        codorden(1) = COD__ORDEN2
        codorden(2) = COD__ORDEN3
        codorden(3) = COD__ORDEN4
        codorden(4) = COD__ORDEN5
        codorden(5) = COD__ORDEN9
        clasefondos(0) = Clasefondo1
        clasefondos(1) = Clasefondo2
        clasefondos(2) = Clasefondo9
        codimputacion(0) = Codigoimputacion1
        codimputacion(1) = Codigoimputacion2
        codimputacion(2) = Codigoimputacion3
        codimputacion(3) = Codigoimputacion4
        codimputacion(4) = Codigoimputacion9
        botones_invisibles()
        botonesbreadcrumb(0) = COD__ORDEN1
        botonesbreadcrumb(1) = COD__ORDEN2
        botonesbreadcrumb(2) = COD__ORDEN3
        botonesbreadcrumb(3) = COD__ORDEN4
        botonesbreadcrumb(4) = COD__ORDEN5
        botonesbreadcrumb(5) = COD__ORDEN9
        botonesbreadcrumb(6) = Clasefondo1
        botonesbreadcrumb(7) = Clasefondo2
        botonesbreadcrumb(8) = Clasefondo9
        botonesbreadcrumb(9) = Codigoimputacion1
        botonesbreadcrumb(10) = Codigoimputacion2
        botonesbreadcrumb(11) = Codigoimputacion3
        botonesbreadcrumb(12) = Codigoimputacion4
        botonesbreadcrumb(13) = Codigoimputacion9
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
        ' wait(1)
        Inicio.OBJETOCARGANDO(Panel13, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        refreshnowgeneral()
        Inicio.OBJETOFINALIZAR(Panel13, Me)
        Aniominimonumeric.Value = Autorizaciones.Year - 3
    End Sub

    Private Function Cdec2(ByRef texto As String, ByRef valorminimo As Integer) As Decimal
        Select Case IsNumeric(texto)
            Case True
                Return CType(texto, Decimal)
            Case False
                Return valorminimo
        End Select
    End Function

    Private Sub Codigoimputacion_combobox_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub refreshnowgeneral()
        Dim valordebusqueda As String = Busqueda.Text
        Busqueda.Text = ""

        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@EJERCICIO", Autorizaciones.Year)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("primerdia", MySql.Data.MySqlClient.MySqlDbType.Date).Value = CType(Aniominimonumeric.Value & "-01-01", Date)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("MINIMUNYEAR", MySql.Data.MySqlClient.MySqlDbType.VarChar, 13).Value = Aniominimonumeric.Value.ToString & "000000000"
        Select Case VISTABOTON.Text
            Case Is = "Vista Simple"
                Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_MOVIMIENTOS_EXPEDIENTES_SIMPLE", datosExpediente, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Case Is = "Vista Detallada"
                Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_MOVIMIENTOS_EXPEDIENTES", datosExpediente, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Select

        Datosexpedientes_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Datosexpedientes_datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Datosexpedientes_datagridview.DataSource = datosExpediente

        Select Case VISTABOTON.Text
            Case Is = "Vista Simple"
            Case Is = "Vista Detallada"
                Datosexpedientes_datagridview.Columns("EXPTEv2").Visible = False
                Datosexpedientes_datagridview.Columns("Cuenta_pedidofondo").Visible = False
                Datosexpedientes_datagridview.Columns("CUENTA").Visible = False
                Datosexpedientes_datagridview.Columns("PedidofondosEXpte").Visible = False
                Datosexpedientes_datagridview.Columns("Clave_expediente").Visible = False
                Datosexpedientes_datagridview.Columns("TIPO").Visible = False
                Datosexpedientes_datagridview.Columns("Descripcion").Visible = False
                Datosexpedientes_datagridview.Columns("Fecha_pedido").Visible = False
                Datosexpedientes_datagridview.Columns("Clase_fondo").Visible = False
                'Datosexpedientes_datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        End Select
        Formatocolumnas(Datosexpedientes_datagridview, datosExpediente)
        Datosexpedientes_datagridview.Columns("Detalle").Width = 210
        Datosexpedientes_datagridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Datosexpedientes_datagridview.CurrentCell = Nothing
        Datosexpedientes_datagridview.Refresh()
        Cargainicial = False
        Busqueda.Text = valordebusqueda
    End Sub

    Private Sub refreshnowdetallado(Optional nada As Boolean = False)
        If Not nada Then
            Select Case Datosexpedientes_datagridview.SelectedRows.Count = 1
                Case True
                    Expediente_actual.clear()

                    Dim IngresosMovimientos As Decimal = 0
                    Dim EgresosMovimientos As Decimal = 0
                    Dim RendidoMovimientos As Decimal = 0
                    Dim Retpendientes As Decimal = 0
                    Dim SaldoExpte As Decimal = 0
                    IngresosMovimientos_textbox.Text = IngresosMovimientos.ToString("C")
                    EgresosMovimientos_textbox.Text = EgresosMovimientos.ToString("C")
                    RendidoMovimientos_textbox.Text = RendidoMovimientos.ToString("C")
                    Retpendientes_textbox.Text = Retpendientes.ToString("C")
                    SaldoExpte_textbox.Text = SaldoExpte.ToString("C")
                    Expediente_actual.claveexpediente = Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value
                    Expediente_actual.Cargar_expediente(Expediente_actual.claveexpediente)

                    Label_pedidofondo.Text = "Pedido de Fondo:" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("NUM PEDIDO FONDO").Value
                    Label_ordenpago.Text = "Orden de Pago Nº" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("ordenpago").Value
                    If Not IsDBNull(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("tipo").Value) Then
                        Label_tipo.Text = Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("tipo").Value
                    Else
                        Label_tipo.Text = ""
                    End If
                    Expediente_actual.Desglose_clave()
                    Movimiento_actual.claveexpediente = Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value

                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("claveindiceminimo", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString & "0000")
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("claveindicemaximo", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString & "9999")
                    Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_MOVIMIENTOS_EXPEDIENTES_DETALLADO", datosexpediente_detalle, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Datosexpedientesdetalle_datagridview.DataSource = Nothing
                    Datosexpedientesdetalle_datagridview.SuspendLayout()
                    Datosexpedientesdetalle_datagridview.DataSource = datosexpediente_detalle
                    Datosexpedientesdetalle_datagridview.CurrentCell = Nothing
                    Datosexpedientesdetalle_datagridview.Columns("Monto").DefaultCellStyle.Format = "c"
                    Datosexpedientesdetalle_datagridview.Columns("nrotransferencia").DefaultCellStyle.Format = "N0"
                    Datosexpedientesdetalle_datagridview.Columns("Clave_expediente_detalle").Visible = False
                    Datosexpedientesdetalle_datagridview.Columns("Clave_expediente_detalle_principal").Visible = False
                    Datosexpedientesdetalle_datagridview.Columns("DETALLE").Width = 250
                    Datosexpedientesdetalle_datagridview.Columns("Expediente_N").Visible = False
                    Inicio.Expedientesdividir(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value, Strings.stringorganismo, Strings.stringnumero, Strings.stringyear)

                    Dim EXPEDIENTESVALORES As New DataTable
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("CLAVE_EXPEDIENTE", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                    Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_MOVIMIENTOS_VALORESEXPEDIENTE", EXPEDIENTESVALORES, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Try
                        IngresosMovimientos = EXPEDIENTESVALORES.Rows(0).Item("INGRESOS")
                        RendidoMovimientos = EXPEDIENTESVALORES.Rows(0).Item("INGRESOS") - (EXPEDIENTESVALORES.Rows(0).Item("EGRESOS") + EXPEDIENTESVALORES.Rows(0).Item("RETENCIONES"))
                        EgresosMovimientos = EXPEDIENTESVALORES.Rows(0).Item("EGRESOS")
                        Retpendientes = EXPEDIENTESVALORES.Rows(0).Item("RETENCIONES")
                        SaldoExpte = EXPEDIENTESVALORES.Rows(0).Item("SALDO")
                    Catch ex As Exception
                    End Try
                    EXPEDIENTESVALORES.Dispose()
                    'SaldoExpte = Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value - EgresosMovimientos
                    IngresosMovimientos_textbox.Text = IngresosMovimientos.ToString("C")
                    EgresosMovimientos_textbox.Text = EgresosMovimientos.ToString("C")
                    RendidoMovimientos_textbox.Text = RendidoMovimientos.ToString("C")
                    Retpendientes_textbox.Text = Retpendientes.ToString("C")
                    SaldoExpte_textbox.Text = SaldoExpte.ToString("C")
                    Select Case IngresosMovimientos
                        Case Is > (EgresosMovimientos + Retpendientes)
                            Colortextbox(IngresosMovimientos_textbox, Color.Yellow)
                            Colortextbox(EgresosMovimientos_textbox, Color.Yellow)
                        Case Is = (EgresosMovimientos + Retpendientes)
                            Colortextbox(IngresosMovimientos_textbox, Color.LightGreen)
                            Colortextbox(EgresosMovimientos_textbox, Color.LightGreen)
                        Case Is < (EgresosMovimientos + Retpendientes)
                            Colortextbox(IngresosMovimientos_textbox, Color.FromArgb(255, 248, 210, 210))
                            Colortextbox(EgresosMovimientos_textbox, Color.FromArgb(255, 248, 210, 210))
                    End Select
                    Select Case RendidoMovimientos
                        Case Is > 0
                            Colortextbox(RendidoMovimientos_textbox, Color.Yellow)
                            'Colortextbox(EgresosMovimientos_textbox, Color.FromArgb(255, 248, 210, 210))
                        Case Is = 0
                            '    Colortextbox(RendidoMovimientos_textbox, Color.LightGreen)
                            Colortextbox(RendidoMovimientos_textbox, Color.LightGreen)
                        Case Is < 0
                            Colortextbox(RendidoMovimientos_textbox, Color.FromArgb(255, 248, 210, 210))
                            '  Colortextbox(EgresosMovimientos_textbox, Color.FromArgb(255, 248, 210, 210))
                    End Select
                    Select Case SaldoExpte
                        Case Is > 0
                            Colortextbox(SaldoExpte_textbox, Color.Cyan)
                        Case Is = 0
                            Colortextbox(SaldoExpte_textbox, Color.LightGreen)
                        Case Is < 0
                            Colortextbox(SaldoExpte_textbox, Color.FromArgb(255, 248, 210, 210))
                    End Select
                    Select Case Retpendientes
                        Case Is > 0
                            Colortextbox(Retpendientes_textbox, Color.Yellow)
                        Case Is = 0
                            Colortextbox(Retpendientes_textbox, Color.LightGreen)
                        Case Is < 0
                            Colortextbox(Retpendientes_textbox, Color.FromArgb(255, 248, 210, 210))
                    End Select
                    Paneldetalle2_panel.Visible = True
                    Datosexpedientesdetalle_datagridview.ResumeLayout()
                Case False
                    'Paneldetalle3_panel.Visible = False
                    '   Paneldetalle2_panel.Visible = False
                    'ElementHostmovimiento.Visible = False
            End Select
            Datosexpedientesdetalle_datagridview.CurrentCell = Nothing
            Reubicacion()
        Else
            'si no esta nada seleccionado
            IngresosMovimientos_textbox.Text = 0.ToString("C")
            EgresosMovimientos_textbox.Text = 0.ToString("C")
            RendidoMovimientos_textbox.Text = 0.ToString("C")
            Retpendientes_textbox.Text = 0.ToString("C")
            SaldoExpte_textbox.Text = 0.ToString("C")
            Datosexpedientesdetalle_datagridview.DataSource = Nothing
        End If
        'MFyV_evaluacion()
        ' DNICUIT_textbox.Text = ""
    End Sub


    Private Function Permitirmodificacion() As Boolean
        Dim temporalus As New DataTable
        Select Case Datosexpedientesdetalle_datagridview.SelectedRows.Count > 0
            Case True
                Select Case (CInt(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Rendido").Value) = 0)
                    Case True 'se podría modificar
                        Return True
                    Case False 'ya fue rendido no se permite la modificación en principio
                        'verificación por posibilidad de una modificación espurea
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("clave_expediente_detalle").Value)
                        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select rendido from expedientes_detalle where clave_expediente_detalle=@clave_expediente_detalle", temporalus, System.Reflection.MethodBase.GetCurrentMethod.Name)
                        Select Case temporalus.Rows.Count > 0 'si aún existe el movimiento
                            Case True
                                Select Case temporalus.Rows(0).Item(0).ToString
                                    Case Is = "0" 'aún no fue rendido, permite la modificación
                                        Return True
                                    Case Is = "1" 'ya fue rendido, no se permite su posterior modificación
                                        Return False
                                End Select
                            Case False
                                Return True
                        End Select
                End Select
            Case False
        End Select
    End Function

    Public Sub refreshNowGeneralIntermedio()
        datosExpedienteIntermedio.Clear()
        Select Case Cuentas_combobox.SelectedIndex >= 0
            Case True
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
                Pedidodefondosql = " (SELECT Clave_pedidofondo, N_pedidofondo, Year_pedidofondo, Monto_pedidofondo, Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo FROM PEDIDO_fondos where cuenta_pedidofondo=@Cuenta)B"
            Case False
                Pedidodefondosql = " (SELECT Clave_pedidofondo, N_pedidofondo, Year_pedidofondo, Monto_pedidofondo, Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo FROM PEDIDO_fondos)B"
        End Select
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "select a.Expediente_N,Fecha,A.Detalle,Ordenpago,A.Monto,
CONCAT(N_pedidofondo,'/', Year_pedidofondo) AS 'Num Pedido Fondo',
Monto_pedidofondo as 'Monto Total Pedido Fondo',
(select CASE when C.INGRESOS>=0 THEN INGRESOS ELSE 0 END) AS INGRESOS,
(select CASE when D.EGRESOS>=0 THEN EGRESOS ELSE 0 END) AS EGRESOS,
(select CASE when E.RENDIDO>=0 THEN RENDIDO ELSE 0 END) AS RENDIDO
,Claveexpteprincipal,Clave_expediente,Cuenta_pedidofondo as 'Cuenta',
A.Clave_pedidofondo,  Cuenta_pedidofondo, Descripcion, Fecha_pedido, Clase_fondo
from (Select Expediente_N,Fecha,Detalle,Ordenpago,Monto,clave_pedidofondo,Claveexpteprincipal,Clave_expediente from Expediente Where Clave_expediente=@clave)A
inner JOIN
" & Pedidodefondosql & "
ON A.clave_pedidofondo=B.CLAVE_PEDIDOFONDO
left JOIN
( select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS INGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where (Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=3 or CodInp=4 or CodInp=9) GROUP BY Clave_expedientetrim)C
ON C.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS EGRESOS, SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where (Cod_orden=1 or Cod_orden=2 or Cod_orden=3 or Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=1 ) GROUP BY Clave_expedientetrim)D
ON D.Clave_expedientetrim=A.Clave_expediente
left JOIN
(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END AS RENDIDO,  SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS Clave_expedientetrim
 from expediente_detalle where ( CodInp=2 ) GROUP BY Clave_expedientetrim) E
ON E.Clave_expedientetrim=A.Clave_expediente", datosExpedienteIntermedio, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case datosExpedienteIntermedio.Rows.Count
            Case = 1
                Select Case VISTABOTON.Text
                    Case Is = "Vista Simple"
                    Case Is = "Vista Detallada"
                        Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("INGRESOS").Value = datosExpedienteIntermedio.Rows(0).Item("INGRESOS")
                        Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("EGRESOS").Value = datosExpedienteIntermedio.Rows(0).Item("EGRESOS")
                        Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("RENDIDO").Value = datosExpedienteIntermedio.Rows(0).Item("RENDIDO")
                End Select
            Case Else
                MessageBox.Show(datosExpedienteIntermedio.Rows.Count)
        End Select
    End Sub

    Private Sub Boton_aceptar_Click(sender As Object, e As EventArgs)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Claveexpteprincipal").Value)
        Inicio.Expedientesdividir(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value, Strings.stringorganismo, Strings.stringnumero, Strings.stringyear)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", Strings.stringorganismo & "-" & Strings.stringnumero & "/" & Strings.stringyear)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", Date.Now)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", Detalle_textbox.Text)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordenpago", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Ordenpago").Value)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Claveexptepedidodefondos", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("ClavePedidofondo").Value)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `expediente` " &
        "(Clave_expediente,Expediente_N,Fecha,Detalle,Ordenpago,Monto,Claveexptepedidodefondos,Usuario) " &
        "VALUES (@Clave_expediente,@Expediente_N,@Fecha,@Detalle,@Ordenpago,@Monto,@Claveexptepedidodefondos,@Usuario) " &
        "ON DUPLICATE KEY UPDATE " &
        "Clave_expediente=@Clave_expediente,Expediente_N=@Expediente_N,Fecha=@Fecha,Detalle=@Detalle,Ordenpago=@Ordenpago,Monto=@Monto, Claveexptepedidodefondos=@Claveexptepedidodefondos,Usuario=@Usuario"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If Not Cargainicial Then
            Inicio.OBJETOCARGANDO(Panel13, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
            refreshnowgeneral()
            Inicio.OBJETOFINALIZAR(Panel13, Me)
        End If
    End Sub

    Private Sub Boton_borrar_Click(sender As Object, e As EventArgs)
        Select Case Datosexpedientes_datagridview.SelectedRows.Count > 0
            Case True
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `expediente` WHERE Clave_expediente=@Clave_expediente"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                If Not Cargainicial Then
                    Inicio.OBJETOCARGANDO(Panel13, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
                    refreshnowgeneral()
                    Inicio.OBJETOFINALIZAR(Panel13, Me)
                End If
            Case False
                MessageBox.Show("No ha seleccionado ningún expediente para que sea borrado")
        End Select
    End Sub

    Private Function validarporcentaje(ByRef Textocontrol As NumericUpDown, ByRef Message As String) As String
        Select Case Textocontrol.Value > 100
            Case True
                Return Message
            Case False
                Return ""
        End Select
    End Function

    Private Function validarvalores(ByRef Textocontrol1 As String, ByRef Textocontrol2 As String, ByRef Message As String) As String
        Select Case CType(Textocontrol1, Decimal) > CType(Textocontrol2, Decimal)
            Case True
                Return Message
            Case False
                Return ""
        End Select
    End Function

    Private Sub todoacero()
        Detalle_textbox.Text = ""
        Cuitdelbeneficiario_textbox.Text = ""
        Ordendeentrega_integerupdown.Value = 0
        Ordendeentregayear_integerupdown.Value = Date.Now.Year
        Nrotransferencia_textbox.Value = Nothing
        'Rendido_checkbox.Checked = False
        Movimientofecha_calendar.Value = Date.Now
        'MONTO TOTAL DE LA FACTURA
        Monto_factura_textbox.Value = 0
        Tipodemovimiento_label.Text = ""
    End Sub

    Private Sub Agregarmovimiento(ByVal Agregaromodificar As String)
        Dim Datos_validos As Boolean = True
        Dim Errores(8) As String
        Dim Total_errores As String = ""
        If Not ValidarCuit("") Then
            Errores(0) = "El CUIT " & Cuitdelbeneficiario_textbox.Text & " es invalido verifique su validez (puede utilizar 99-99999999-9 si no conoce el CUIT pero debe ser actualizado luego con el número correcto )"
        End If
        If (Not Label_Codorden.Text = "-") And (Not LabelClasefondo.Text = "-") And (Not Label_Codimp.Text = "-") Then
        Else
            Datos_validos = False
            Errores(1) = "Debe registrar el código del movimiento"
        End If
        Dim totalestemporales As New DataTable
        totalestemporales = Expediente_actual.retornartotales(Expediente_actual.claveexpediente)
        Dim total As Decimal = 0
        Select Case Agregaromodificar = "MODIFICAR"
            Case True
                'hay que verificar la forma de control de estos valores, al ser una modificación la suma debe incluir el valor modificado...
                If Label_Codimp.Text = 1 Then
                    If Monto_factura_textbox.Value = 0 Then
                    Else
                        total = totalestemporales.Rows(0).Item("INGRESOS") - (totalestemporales.Rows(0).Item("EGRESOS") + totalestemporales.Rows(0).Item("RETENCIONES") + ((Monto_factura_textbox.Value - Movimiento_actual.Monto_movimiento)))
                    End If
                Else
                End If
            Case False
                If Label_Codimp.Text = 1 Then
                    total = totalestemporales.Rows(0).Item("INGRESOS") - (totalestemporales.Rows(0).Item("EGRESOS") + totalestemporales.Rows(0).Item("RETENCIONES"))
                Else
                End If
                Select Case VISTABOTON.Text
                    Case Is = "Vista Simple"
                    Case Is = "Vista Detallada"
                        Select Case Label_Codimp.Text
                            Case Is = "1"
                                If (Monto_factura_textbox.Value + Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("EGRESOS").Value) > Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value Then
                                    Datos_validos = False
                                    MsgBox("El monto ingresado  (" &
                                   Monto_factura_textbox.Value.ToString & ") para este pago y sumado a los pagos existentes (" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("EGRESOS").Value & ")  " & vbNewLine &
                                   " supera el monto del expediente " & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value)
                                    Errores(0) = "EL MONTO INGRESADO SUPERA LO DISPONIBLE EN EL EXPEDIENTE"
                                End If
                            Case Is = "3"
                                If Not IsDBNull(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value) Then
                                    If (Monto_factura_textbox.Value + Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("INGRESOS").Value) > Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value Then
                                        Datos_validos = False
                                        MsgBox("El monto ingresado  (" &
                                       Monto_factura_textbox.Value.ToString & ") para este ingreso y sumado a los ingresos anteriores (" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("EGRESOS").Value & ")  " & vbNewLine &
                                       " supera el monto del expediente (" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value & ")")
                                        'Errores(0) = "El monto ingresado para el movimiento supera los valores actuales"
                                    End If
                                End If
                        End Select
                End Select
        End Select
        Dim TextoMessage As String = ""
        Select Case Agregaromodificar.ToString.Contains("MODIFICAR")
            Case True
                TextoMessage = "Confirma que desea ACTUALIZAR este Movimiento"
            Case False
                TextoMessage = "Confirma que desea CARGAR NUEVO Movimiento"
        End Select
        If (total >= 0) Then
        Else
            Datos_validos = False
            Errores(0) = "EL MONTO DEL MOVIMIENTO SUPERA LO INGRESADO EN EL EXPEDIENTE"
        End If
        Select Case MsgBox(TextoMessage, MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                Select Case Datos_validos
                    Case True
                        With Movimiento_actual
                            'moviento
                            .CUIT = Cuitdelbeneficiario_textbox.Text
                            Select Case Agregaromodificar = "MODIFICAR"
                                Case True
                                    If Movimiento_actual.cod_inp = 0 Then
                                        Datos_validos = False
                                        Errores(3) = "Este es un movimiento interno, debe dirigirse al expediente madre para realizar la modificación"
                                    End If
                                    .Clave_expediente_detalle = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value
                                Case Else
                                    .Clave_expediente_detalle = Movimiento_actual.NUEVOMOVIMIENTO(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("clave_expediente").Value)
                            End Select
                            .Descripcion_movimiento = Detalle_textbox.Text
                            If Datosexpedientesdetalle_datagridview.SelectedRows.Count > 0 Then
                                If Not IsDBNull(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle_principal").Value) Then
                                    .Clave_expediente_detalle_principal = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle_principal").Value
                                End If
                            End If
                            ' Movimiento_actual.Clave_expediente_detalle_principal
                            .Expediente_N = Expediente_actual.Expediente_N
                            .Cod_orden = Label_Codorden.Text
                            .Clase_fondo = LabelClasefondo.Text
                            .cod_inp = Label_Codimp.Text
                            ' expediente_year = Nothing
                            .Transferencia = Regex.Replace(Nrotransferencia_textbox.Value.ToString, "[^0-9]", "")
                            .Fecha_movimiento = Movimientofecha_calendar.Value
                            .Orden = Ordendeentrega_integerupdown.Value
                            .Orden_year = Ordendeentregayear_integerupdown.Value
                            .Monto_movimiento = Monto_factura_textbox.Value
                            Select Case Tipodemovimiento_label.Text.ToUpper
                                Case Is = "IPS"
                                    .Tipo_Movimiento = "IPS"
                                Case Is = "NORMAL"
                                    .Tipo_Movimiento = Orden_label.Text
                                Case Else
                                    .Tipo_Movimiento = Tipodemovimiento_label.Text.ToUpper
                            End Select
                            Try
                                .Total_factura = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MONTO_FACTURA").Value
                            Catch ex As Exception
                                .Total_factura = Monto_factura_textbox.Value
                            End Try
                        End With
                        Dim Claveexpediente_temp As Int64 = Nothing
                        Dim temporalus As New DataTable
                        Select Case Agregaromodificar = "MODIFICAR"
                            Case True
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value)
                            Case Else
                                Claveexpediente_temp = Movimiento_actual.NUEVOMOVIMIENTO(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("clave_expediente").Value)
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Claveexpediente_temp)
                        End Select
                        Movimiento_actual.Descripcion_movimiento = Detalle_textbox.Text
                        Movimiento_actual.monto = Monto_factura_textbox.Value
                        Inicio.Expedientesdividir(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value, Strings.stringorganismo, Strings.stringnumero, Strings.stringyear)
                        Select Case Agregaromodificar = "MODIFICAR"
                            Case True
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value)
                            Case Else
                                Claveexpediente_temp = Movimiento_actual.NUEVOMOVIMIENTO(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("clave_expediente").Value)
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Clave_expediente_detalle", Claveexpediente_temp)
                        End Select
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Expediente_N", Strings.stringorganismo & "-" & Strings.stringnumero & "/" & Strings.stringyear)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Detalle", Movimiento_actual.Descripcion_movimiento)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Monto", Movimiento_actual.monto)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Add("_Cod_orden", MySql.Data.MySqlClient.MySqlDbType.Int16, 1).Value = CType(Label_Codorden.Text, Integer)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Add("_CFdo", MySql.Data.MySqlClient.MySqlDbType.Int16, 1).Value = CType(LabelClasefondo.Text, Integer)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Add("_CodInp", MySql.Data.MySqlClient.MySqlDbType.Int16, 1).Value = CType(Label_Codimp.Text, Integer)
                        Select Case Tipodemovimiento_label.Text.ToUpper
                            Case Is = "IPS"
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Mov_tipo", "IPS")
                            Case Is = "NORMAL"
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Mov_tipo", Orden_label.Text)
                            Case Else
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Mov_tipo", Tipodemovimiento_label.Text.ToUpper)
                        End Select
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_CUIT", Cuitdelbeneficiario_textbox.Text)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Nrotransferencia", Regex.Replace(Nrotransferencia_textbox.Value.ToString, "[^0-9]", ""))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Fechadelmovimiento", Movimientofecha_calendar.Value)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_tipoorden", Orden_label.Text)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Orden_N", Ordendeentrega_integerupdown.Value)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("_Orden_year", Ordendeentregayear_integerupdown.Value)
                        Movimiento_actual.claveexpediente = Movimiento_actual.NUEVOMOVIMIENTO(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("clave_expediente").Value)
                        'AQUI INSERTA EL MOVIMIENTO DE LIBRO--------------------------------------------------------------
                        'Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                        Dim CLAVEEXPEDIENTESWAP As Long = Nothing
                        Dim CLAVEEXPEDIENTESWAPprincipal As Long = Nothing
                        Select Case Movimiento_actual.Tipo_Movimiento
                            Case Is = "IPS"
                                Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                Select Case Movimiento_actual.cod_inp = 3
                                    Case True
                                        Movimiento_actual.cod_inp = 1
                                        Movimiento_actual.Cod_orden = 1
                                    Case False
                                End Select
                                Movimiento_actual.Clave_expediente_detalle = Movimiento_actual.NUEVOMOVIMIENTO(Expediente_actual.claveexpediente)
                                Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                            Case Is = "FONDOS PERMANENTES PAGO EFECTORES"
                                Movimiento_actual.CUIT = Autorizaciones.CUIT_servicioadministrativo
                                Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                Dim TEXTOAGUARDAR As String = Movimiento_actual.Descripcion_movimiento
                                Select Case Agregaromodificar = "MODIFICAR"
                                    Case True
                                        CLAVEEXPEDIENTESWAP = Movimiento_actual.Clave_expediente_detalle
                                        CLAVEEXPEDIENTESWAPprincipal = Movimiento_actual.Clave_expediente_detalle_principal
                                        Movimiento_actual.cod_inp = 0
                                        Movimiento_actual.Cod_orden = 4
                                        Movimiento_actual.Descripcion_movimiento = "*MOVIMIENTO INTERNO*-" & Movimiento_actual.Descripcion_movimiento
                                        Movimiento_actual.claveexpediente = Movimiento_actual.Movimientosasociados(CLAVEEXPEDIENTESWAP, Movimiento_actual.Cod_orden)
                                        Movimiento_actual.Clave_expediente_detalle_principal = CLAVEEXPEDIENTESWAP
                                        Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                        'CARGA EL EGRESO AL EXPEDIENTE SELECCIONADO
                                        Movimiento_actual.cod_inp = 1
                                        Movimiento_actual.Cod_orden = 2
                                        Movimiento_actual.Descripcion_movimiento = TEXTOAGUARDAR
                                        Movimiento_actual.Clave_expediente_detalle = Movimiento_actual.Movimientosasociados(CLAVEEXPEDIENTESWAP, Movimiento_actual.Cod_orden)
                                        Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                    Case Else
                                        CLAVEEXPEDIENTESWAP = Movimiento_actual.claveexpediente
                                        Movimiento_actual.claveexpediente = Movimiento_actual.principalclaveexpediente
                                        Movimiento_actual.Clave_expediente_detalle_principal = CLAVEEXPEDIENTESWAP
                                        Movimiento_actual.cod_inp = 0
                                        Movimiento_actual.Cod_orden = 4
                                        Movimiento_actual.Descripcion_movimiento = "*MOVIMIENTO INTERNO*-" & Movimiento_actual.Descripcion_movimiento
                                        Movimiento_actual.Clave_expediente_detalle = Movimiento_actual.NUEVOMOVIMIENTO(Movimiento_actual.claveexpediente)
                                        Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                        'CARGA EL EGRESO AL EXPEDIENTE SELECCIONADO
                                        Movimiento_actual.Clave_expediente_detalle = Movimiento_actual.NUEVOMOVIMIENTO(Movimiento_actual.claveexpediente)
                                        Movimiento_actual.cod_inp = 1
                                        Movimiento_actual.Cod_orden = 2
                                        Movimiento_actual.Descripcion_movimiento = TEXTOAGUARDAR
                                        Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                End Select
                            Case Is = "TRANSFERENCIA ENTRE CUENTAS"
                                Movimiento_actual.CUIT = Autorizaciones.CUIT_servicioadministrativo
                                Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                Dim TEXTOAGUARDAR As String = Movimiento_actual.Descripcion_movimiento
                                Select Case Agregaromodificar = "MODIFICAR"
                                    Case True
                                        CLAVEEXPEDIENTESWAP = Movimiento_actual.Clave_expediente_detalle
                                        CLAVEEXPEDIENTESWAPprincipal = Movimiento_actual.Clave_expediente_detalle_principal
                                        Movimiento_actual.cod_inp = 3
                                        Movimiento_actual.Cod_orden = 4
                                        '  Movimiento_actual.Descripcion_movimiento = "*MOVIMIENTO INTERNO*-" & Movimiento_actual.Descripcion_movimiento
                                        Movimiento_actual.claveexpediente = Movimiento_actual.Movimientosasociados(CLAVEEXPEDIENTESWAP, Movimiento_actual.Cod_orden)
                                        Movimiento_actual.Clave_expediente_detalle_principal = CLAVEEXPEDIENTESWAP
                                        Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                    Case Else
                                        CLAVEEXPEDIENTESWAP = Movimiento_actual.claveexpediente
                                        Movimiento_actual.principalclaveexpediente = vbNull
                                        Movimiento_actual.claveexpediente = Movimiento_actual.principalclaveexpediente
                                        Movimiento_actual.Clave_expediente_detalle_principal = CLAVEEXPEDIENTESWAP
                                        Movimiento_actual.cod_inp = 3
                                        Movimiento_actual.Cod_orden = 4
                                        ' Movimiento_actual.Descripcion_movimiento = "*MOVIMIENTO INTERNO*-" & Movimiento_actual.Descripcion_movimiento
                                        Movimiento_actual.Clave_expediente_detalle = Movimiento_actual.NUEVOMOVIMIENTO(CType(Autorizaciones.Year & "9999" & cuentabancariaguardar.ToString.Substring(cuentabancariaguardar.Length - 5, 5), Long))
                                        Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                                End Select
                                '
                            Case Else
                                Movimiento.INSERTARMOVIMIENTO(Movimiento_actual)
                        End Select

                        Select Case Label_Codimp.Text
                            Case = "1"
                                Dim rowss As Integer = 0
                                For x = 0 To Autocompletetables.SFyV_CodClasefondo.Rows.Count - 1
                                    If Autocompletetables.SFyV_CodClasefondo.Rows(x).Item(0).ToString = LabelClasefondo.Text Then
                                        rowss = x
                                        Exit For
                                    End If
                                Next
                            Case Else
                        End Select
                        '                            Case False
                        '                        End Select
                        refreshNowGeneralIntermedio()
                        refreshnowdetallado()
                    Case False
                        For x = 0 To Errores.Count - 1
                            If Not (Errores(x) = "") Then
                                Total_errores = Total_errores & vbCrLf & "-" & Errores(x)
                            End If
                        Next
                        MessageBox.Show("Actualmente el Movimiento contiene - " & vbCrLf & Total_errores)
                End Select
            Case MsgBoxResult.Cancel
            Case MsgBoxResult.No
                MessageBox.Show("Los datos no van a ser cargados")
        End Select
        totalestemporales.Dispose()
    End Sub


    Private Sub Cancelarmovimiento()
        refreshnowdetallado()
    End Sub

    Private Sub Borrar_detalle_expediente_Click(sender As Object, e As EventArgs)
        Select Case MsgBox("Confirma que desea BORRAR el movimiento seleccionado del Expediente N" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value.ToString, MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                Select Case Permitirmodificacion()
                    Case True
                        Select Case Datosexpedientesdetalle_datagridview.Enabled
                            Case True
                                Select Case Datosexpedientesdetalle_datagridview.SelectedRows.Count > 0
                                    Case True
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value)
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `Expediente_detalle` WHERE Clave_expediente_detalle=@Clave_expediente_detalle"
                                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value)
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `retenciones` WHERE Clave_expediente_detalle=@Clave_expediente_detalle"
                                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                        refreshNowGeneralIntermedio()
                                        refreshnowdetallado()
                                    Case False
                                        MessageBox.Show("No ha seleccionado ningún detalle del expediente para que sea borrado")
                                End Select
                            Case False
                                MessageBox.Show("El expediente actual no cuenta con un pedido de fondos")
                        End Select
                    Case False
                        MsgBox("El movimiento se ha rendido " & "No puede ser modificado", MsgBoxStyle.Information, "El movimiento no se puede modificar")
                End Select
        End Select
    End Sub

    Private Sub Datosexpedientesdetalle_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosexpedientesdetalle_datagridview.CellContentClick, Datosexpedientesdetalle_datagridview.CellEnter
        Movimiento_seleccion_viejo()
        'Clave_expediente_detalle
        'Expediente_N
        'Detalle
        'Monto
        'Fechadelmovimiento
        'Cod_orden
        'CFdo
        'CodInp
        'Mov_tipo
        'rendido
        'CUIT
        'Nrotransferencia
        'Tipoorden
        'Orden_N
        'Orden_year
        'IVA_MONTO
        'IVA_PORCENTAJE
        'SUSS_MONTO
        'SUSS_PORCENTAJE
        'GANANCIAS_MONTO
        'GANANCIAS_PORCENTAJE
        'MNI
        'DGR_MONTO
        'DGR_PORCENTAJE
        'MONTO_FACTURA
        Select Case Datosexpedientesdetalle_datagridview.SelectedRows.Count > 0
            Case True
                With Movimiento_actual
                    .New_fromExpediente(Expediente_actual)
                    Movimiento_actual.Monto_movimiento = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value
                    Movimiento_actual.Transferencia = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("nrotransferencia").Value
                    If (Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MONTO_FACTURA").Value >= 0) Then
                        Movimiento_actual.Total_factura = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MONTO_FACTURA").Value
                    Else
                        Movimiento_actual.Total_factura = 0
                    End If
                    Movimiento_actual.Fecha_movimiento = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Fechadelmovimiento").Value
                    Movimiento_actual.Clave_expediente_detalle = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value
                    Movimiento_actual.cod_inp = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CodInp").Value
                    Movimiento_actual.Clase_fondo = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CFdo").Value
                    Movimiento_actual.Cod_orden = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Cod_orden").Value
                    If Not IsDBNull(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Orden_N").Value) Then
                        Movimiento_actual.Orden = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Orden_N").Value
                    Else
                        Movimiento_actual.Orden = 0
                    End If
                    If Not IsDBNull(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("orden_year").Value) Then
                        Movimiento_actual.Orden_year = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("orden_year").Value
                    Else
                        Movimiento_actual.Orden_year = 0
                    End If
                    Movimiento_actual.CUIT = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CUIT").Value
                    Movimiento_actual.Descripcion_movimiento = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Detalle").Value.ToString
                    Movimiento_actual.Expediente_N = Expediente_actual.Expediente_N
                    'Movimiento_actual.Expediente = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Expediente_N").Value
                    Movimiento_actual.Monto_movimiento = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value
                    If Not IsDBNull(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("USUARIO").Value) Then
                        Movimiento_actual.Usuario = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("USUARIO").Value
                    Else
                        Movimiento_actual.Usuario = 0
                    End If
                    If Not IsDBNull(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Mov_tipo").Value) Then
                        Movimiento_actual.Tipo_Movimiento = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Mov_tipo").Value
                    Else
                        Movimiento_actual.Tipo_Movimiento = ""
                    End If
                End With
                If IsNothing(Movimiento_actual.Clase_fondo) Then
                    If Not Movimiento_actual.Clase_fondo > 0 Then
                        Select Case Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("tipo").Value.ToString.Contains("RP")
                            Case True
                                Movimiento_actual.Clase_fondo = 9
                            Case False
                                Movimiento_actual.Clase_fondo = 2
                        End Select
                    End If
                End If
                cargar_retenciones()
                Reubicacion()
            Case False
                'Debería hacer invisible al control medio donde se encuentra el boton modificar
                With Tablelayout_Botones_aceptar.ColumnStyles(1)
                    .SizeType = SizeType.Percent
                    .Width = 0
                End With
        End Select
    End Sub

    Private Sub cargar_retenciones()
        Movimiento_actual.Ver_retenciones()
        Retenciones_Datagridview.DataSource = Movimiento_actual.tablaretenciones
        With Retenciones_Datagridview
            .Columns("Monto_Retenido").DefaultCellStyle.Format = "C"
            .Columns("MNI").DefaultCellStyle.Format = "C"
            .Columns("alicuota").DefaultCellStyle.Format = "N"
            'columnas invisibles
            .Columns("IVA").Visible = False
            .Columns("total_factura").Visible = False
            .Columns("neto_factura").Visible = False
            .Columns("porc_IVA").Visible = False
            .Columns("Nro_transaccion").Visible = False
            .Columns("Cuit_recaudador").Visible = False
            .Columns("fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns("MNI").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns("alicuota").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns("concepto").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Columns("detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("detalle").MinimumWidth = 50
        End With
        With Tablelayout_Botones_aceptar.ColumnStyles(1)
            .SizeType = SizeType.Percent
            .Width = 33
        End With
    End Sub

    Private Sub Reubicacion(Optional nuevo As Boolean = False)
        Dim tamaniopanel1 As Integer = 0
        Dim tamaniopanel2 As Integer = 0
        SplitContainer_superior.SuspendLayout()
        If Datosexpedientesdetalle_datagridview.SelectedRows.Count = 1 Or nuevo Then
            If (Retenciones_Datagridview.Rows.Count > 0) Then
                Panel_retenciones.Height = 53 + (Retenciones_Datagridview.Rows.Count * (Retenciones_Datagridview.Rows(0).Height))
                Movmientos_y_retenciones_splitpanel.SplitterDistance = (Movmientos_y_retenciones_splitpanel.Height) - (Panel_retenciones.Height + 10)
                Panel_Formulario.Visible = False
                Panel_botones.Visible = False
            Else
                Panel_retenciones.Height = 0
                Movmientos_y_retenciones_splitpanel.SplitterDistance = (Movmientos_y_retenciones_splitpanel.Height) - (Panel_retenciones.Height + Panel_botones.Height + 10)
                Panel_Formulario.Visible = True
                Panel_botones.Visible = True
            End If
            Try
                Datosexpedientesdetalle_datagridview.FirstDisplayedScrollingRowIndex = Datosexpedientesdetalle_datagridview.SelectedRows(0).Index
            Catch ex As Exception
            End Try
        Else
            Movmientos_y_retenciones_splitpanel.SplitterDistance = (Movmientos_y_retenciones_splitpanel.Height + 55)
            Panel_Formulario.Visible = False
            Panel_botones.Visible = False
        End If
        SplitContainer_superior.ResumeLayout()
    End Sub

    Private Sub Movimiento_seleccion_viejo()
        Select Case Datosexpedientesdetalle_datagridview.SelectedRows.Count > 0
            Case True
                Select Case Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CUIT").Value.ToString
                    Case Is = "33-69345023-9"
                        Panel_retenciones.Visible = False
                        'ElementHostmovimiento.Visible = False
                    Case Is = "30-67238712-0"
                        Panel_retenciones.Visible = False
                    Case Else
                        Cargadevalores()
                        Panel_retenciones.Visible = True
                        'SplitContainervertical.Panel2.Refresh()
                End Select
            Case False
        End Select
    End Sub

    Private Sub Cargadevalores()
        Botonaceptar_button.Text = "Agregar movimiento"
        Tipodemovimiento_label.Text = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MOV_TIPO").Value.ToString
        Nuevomovimiento_boton.Visible = True
        Cuitdelbeneficiario_textbox.Text = Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CUIT").Value.ToString
        Movimientofecha_calendar.Value = Convert.ToDateTime(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Fechadelmovimiento").Value.ToString).Date
        Codigosbotones(CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("cod_orden").Value, Integer), CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CFdo").Value, Integer), CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CodInp").Value, Integer))
        Nrotransferencia_textbox.Text = CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Nrotransferencia").Value, Long)
        'Orden_label.Text = (Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Tipoorden").Value.ToString)
        Detalle_textbox.Text = (Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Detalle").Value.ToString)
        Select Case IsNumeric(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Orden_N").Value)
            Case True
                Ordendeentrega_integerupdown.Value = CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Orden_N").Value.ToString, Integer)
            Case False
                Ordendeentrega_integerupdown.Value = 0
        End Select
        Try
            Select Case IsNumeric(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Orden_year").Value)
                Case True
                    Ordendeentregayear_integerupdown.Value = CType(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Orden_year").Value, Integer)
                Case False
                    Ordendeentregayear_integerupdown.Value = 0
            End Select
        Catch ex As Exception
        End Try
        Select Case Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("CodInp").Value.ToString
            Case = "1"
                '---------------------------------------------RETENCIONES ASOCIADAS AL MOVIMIENTO------------------------------------------------------
                'MONTO TOTAL DE LA FACTURA
                If Not IsDBNull(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MONTO_FACTURA").Value) Then
                    If (Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MONTO_FACTURA").Value >= 0) Then
                        Monto_factura_textbox.Value = Inicio.Cdecimal(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value)
                    Else
                        Monto_factura_textbox.Value = Inicio.Cdecimal(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value)
                    End If
                Else
                    Monto_factura_textbox.Value = Inicio.Cdecimal(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value)
                End If
            Case Else
                If Not IsDBNull(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MONTO_FACTURA").Value) Then
                    If (Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("MONTO_FACTURA").Value >= 0) Then
                        Monto_factura_textbox.Value = Inicio.Cdecimal(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value)
                    Else
                        Monto_factura_textbox.Value = Inicio.Cdecimal(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value)
                    End If
                Else
                    Monto_factura_textbox.Value = Inicio.Cdecimal(Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Monto").Value)
                End If
        End Select
    End Sub

    Private Sub Modificarseleccionado_boton_Click(sender As Object, e As EventArgs)
        If Datosexpedientesdetalle_datagridview.SelectedRows.Count = 1 Then
            Select Case Permitirmodificacion()
                Case True
                    Select Case Datosexpedientesdetalle_datagridview.Enabled
                        Case True
                            Select Case Datosexpedientesdetalle_datagridview.SelectedRows.Count
                                Case = 0
                                    MessageBox.Show("No ha seleccionado ningún expediente")
                                Case > 0
                                    Datosexpedientesdetalle_datagridview.Enabled = False
                                    Cargadevalores()
                                    'Datosexpedientesdetalle_datagridview.Enabled = False
                                    '   Paneldetalle2_panel.Enabled = True
                                    For x = 0 To Datosexpedientesdetalle_datagridview.Parent.Controls.Count - 1
                                        Datosexpedientesdetalle_datagridview.Parent.Controls(x).Enabled = True
                                    Next
                            End Select
                        Case False
                            MessageBox.Show("El expediente actual no cuenta con un pedido de fondos")
                    End Select
                Case False
                    MsgBox("El movimiento se ha rendido " & "No puede ser modificado", MsgBoxStyle.Information, "El movimiento no se puede modificar")
            End Select
        End If
    End Sub

    Private Sub Codigosbotones(ByVal cordena As Integer, ByVal clasefondosa As Integer, ByVal codimputaciona As Integer)
        codorden(0) = COD__ORDEN1
        codorden(1) = COD__ORDEN2
        codorden(2) = COD__ORDEN3
        codorden(3) = COD__ORDEN4
        codorden(4) = COD__ORDEN5
        codorden(5) = COD__ORDEN9
        clasefondos(0) = Clasefondo1
        clasefondos(1) = Clasefondo2
        clasefondos(2) = Clasefondo9
        codimputacion(0) = Codigoimputacion1
        codimputacion(1) = Codigoimputacion2
        codimputacion(2) = Codigoimputacion3
        codimputacion(3) = Codigoimputacion4
        codimputacion(4) = Codigoimputacion9
        botones_invisibles()
        ' botonesbreadcrumb(0) = c
        botonesbreadcrumb(0) = COD__ORDEN1
        botonesbreadcrumb(1) = COD__ORDEN2
        botonesbreadcrumb(2) = COD__ORDEN3
        botonesbreadcrumb(3) = COD__ORDEN4
        botonesbreadcrumb(4) = COD__ORDEN5
        botonesbreadcrumb(5) = COD__ORDEN9
        botonesbreadcrumb(6) = Clasefondo1
        botonesbreadcrumb(7) = Clasefondo2
        botonesbreadcrumb(8) = Clasefondo9
        botonesbreadcrumb(9) = Codigoimputacion1
        botonesbreadcrumb(10) = Codigoimputacion2
        botonesbreadcrumb(11) = Codigoimputacion3
        botonesbreadcrumb(12) = Codigoimputacion4
        botonesbreadcrumb(13) = Codigoimputacion9
        coloresdebotonallgray(codorden)
        coloresdebotonallgray(clasefondos)
        coloresdebotonallgray(codimputacion)
        For x = 0 To codorden.Count - 1
            codorden(x).Visible = True
        Next
        For x = 0 To clasefondos.Count - 1
            clasefondos(x).Visible = True
        Next
        For x = 0 To codimputacion.Count - 1
            codimputacion(x).Visible = True
        Next
        Select Case cordena
            Case = 1
                coloresdeboton(codorden(0), codorden)
              '  Codorden_combobox.SelectedIndex = 0
            Case = 2
                coloresdeboton(codorden(1), codorden)
               ' Codorden_combobox.SelectedIndex = 1
            Case = 3
                coloresdeboton(codorden(2), codorden)
                'Codorden_combobox.SelectedIndex = 2
            Case = 4
                coloresdeboton(codorden(3), codorden)
                'Codorden_combobox.SelectedIndex = 3
            Case = 5
                coloresdeboton(codorden(4), codorden)
                'Codorden_combobox.SelectedIndex = 4
            Case = 9
                coloresdeboton(codorden(5), codorden)
                'Codorden_combobox.SelectedIndex = 5
        End Select
        Select Case clasefondosa
            Case = 1
                coloresdeboton(clasefondos(0), clasefondos)
               ' Clasefondo_combobox.SelectedIndex = 0
            Case = 2
                coloresdeboton(clasefondos(1), clasefondos)
             '   Clasefondo_combobox.SelectedIndex = 1
            Case = 9
                coloresdeboton(clasefondos(2), clasefondos)
                '  Clasefondo_combobox.SelectedIndex = 2
        End Select
        Select Case codimputaciona
            Case = 1
                coloresdeboton(codimputacion(0), codimputacion)
             '   Codigoimputacion_combobox.SelectedIndex = 0
                'Pregunta sobre retenciones, comenta la Cra Galia  que el Expte contiene todos los datos necesarios para saber si el proveedor es sujeto de retenciones.
            Case = 2
                coloresdeboton(codimputacion(1), codimputacion)
             '   Codigoimputacion_combobox.SelectedIndex = 1
            Case = 3
                coloresdeboton(codimputacion(2), codimputacion)
               ' Codigoimputacion_combobox.SelectedIndex = 2
            Case = 4
                coloresdeboton(codimputacion(3), codimputacion)
               ' Codigoimputacion_combobox.SelectedIndex = 3
            Case = 9
                coloresdeboton(codimputacion(4), codimputacion)
                '  Codigoimputacion_combobox.SelectedIndex = 4
        End Select
        Label_Codorden.Text = cordena
        LabelClasefondo.Text = clasefondosa
        Label_Codimp.Text = codimputaciona
    End Sub

    Public Sub todoCero(ByVal Detalle_movimiento As String, ByVal OrdenpagoN As Integer, ByVal Ordenpagoanio As Integer)
        Nrotransferencia_textbox.Value = 0
        If fechamovimientobloqueada = True Then
            Movimientofecha_calendar.Value = Movimientofecha_calendar.Value
        Else
            Movimientofecha_calendar.Value = Date.Now
        End If
        Ordendeentrega_integerupdown.Value = Expediente_actual.ordenpago
        Ordendeentregayear_integerupdown.Value = Expediente_actual.ordenpagoyear
        ' Rendido_checkbox.Checked = False
        Cuitdelbeneficiario_textbox.Text = ""
        '  Montodelmovimiento_textbox.Value = 0
        Detalle_textbox.Text = ""
        Tipodemovimiento_label.Text = ""
        Monto_factura_textbox.Value = 0
    End Sub

    Private Sub Nuevomovimiento_boton_Click(sender As Object, e As EventArgs) Handles Nuevomovimiento_boton.Click
        Movimiento_actual.clearmovimiento()
        Movimiento_actual.claveexpediente = Expediente_actual.claveexpediente
        nuevomovimiento_viejo()
    End Sub

    Private Sub Modificarmovimiento_boton_Click(sender As Object, e As EventArgs) Handles Modificarmovimiento_boton.Click
        Movimiento_actual.claveexpediente = Expediente_actual.claveexpediente
        tipodemovimiento_seleccion()
    End Sub

    Private Sub nuevomovimiento_viejo()
        Dim Expedientepedidofondo As String() = Divisordetresvariables(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("PedidofondosEXpte").Value.ToString)
        Dim pedidofondovalido As Boolean = True
        If Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("PedidofondosEXpte").Value.ToString = "" Then
            pedidofondovalido = False
        Else
            If Expedientepedidofondo.Count > 2 Then
                If CType(Expedientepedidofondo(1), Decimal) > 0 Then
                Else
                    pedidofondovalido = False
                End If
            Else
                pedidofondovalido = False
            End If
        End If
        Dim ordenpagon As String = "0"
        Dim ordenpagoyear As String = Date.Now.Year.ToString
        Datosexpedientesdetalle_datagridview.Enabled = False
        Botonaceptar_button.Text = "Agregar movimiento"
        Label_Codorden.Text = "-"
        Label_Codimp.Text = "-"
        LabelClasefondo.Text = "-"
        todoCero(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Detalle").Value.ToString, 0, Date.Now.Year)
        Inicio.divisoruniversal(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString, ordenpagon, ordenpagoyear)
        For x = 0 To Datosexpedientesdetalle_datagridview.Parent.Controls.Count - 1
            Datosexpedientesdetalle_datagridview.Parent.Controls(x).Enabled = True
        Next
        tipodemovimiento_seleccion()
        tipodemovimiento_botones()
    End Sub

    Private Sub botones_codigoMFyV(ByVal tipoorden As Integer, ByVal EJERCICIO As String, ByVal codigoimputacion As Integer)
        CARGANDOCODIGOS = True
        Panel_botones.Visible = True
        If Movimiento_actual.Clave_expediente_detalle = 0 Then
            Reubicacion(True)
        End If
        If tipoorden = 9 Then
            tipoorden = 6
        End If
        If codigoimputacion = 9 Then
            codigoimputacion = 5
        End If
        codorden(tipoorden - 1).PerformClick()
        '     wait(10)
        'ELEGIR CLASE DE FONDO
        Select Case EJERCICIO.ToUpper
            Case Is = "EJERCICIO"
                Clasefondo2.PerformClick() 'de la clase Ejercicio actual
            Case Else
                Clasefondo9.PerformClick() ' de la clase Residuos Pasivos
        End Select
        '    wait(10)
        If Not codigoimputacion = 0 Then
            codimputacion(codigoimputacion - 1).PerformClick()
        Else
            Label_Codimp.Text = "0"
            Panel_botones.Visible = False
        End If
        CARGANDOCODIGOS = False
        Modificacion_detalle("CODIGO IMPUTACION")
    End Sub

    Private Sub tipodemovimiento_botones()
        Select Case Tipodemovimiento_label.Text.ToUpper
            Case Is = "PAGO"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "TRANSFERENCIA DE FONDOS"
                botones_codigoMFyV(4, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 3)
            Case Is = "IPS"
                botones_codigoMFyV(4, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 3)
            Case Is = "GANANCIAS"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "IVA"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "SUSS"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "SEGUROS"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "GANANCIAS DEL PERSONAL"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "HABERES"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "REINTEGROS"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "GREMIOS"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "JUDICIALES"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "ENTIDADES FINANCIERAS"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Is = "FONDOS PERMANENTES PAGO EFECTORES"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 0)
            Case Is = "TRANSFERENCIA ENTRE CUENTAS"
                botones_codigoMFyV(1, Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("TIPO").Value.ToString.ToUpper, 1)
            Case Else
        End Select
    End Sub

    Private Sub Coloreardatagridview()
        For X As Integer = 0 To Datosexpedientesdetalle_datagridview.Rows.Count - 1
            Select Case Datosexpedientesdetalle_datagridview.Rows(X).Cells.Item("CodInp").Value
                '1 Egresos
                Case = 1
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 176, 184)
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.ForeColor = Inicio.GetContrastColor(Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor)
                '2 Rendiciones
                Case = 2
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor = Color.FromArgb(255, 105, 178, 122)
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.ForeColor = Inicio.GetContrastColor(Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor)
                '3 Ingresos
                Case = 3
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 255, 214)
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.ForeColor = Inicio.GetContrastColor(Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor)
                '4 Reintegros
                Case = 4
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255, 255)
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.ForeColor = Inicio.GetContrastColor(Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor)
                '9 Ingreso por Recaudación Propia
                Case = 9
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255, 255)
                    Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.ForeColor = Inicio.GetContrastColor(Datosexpedientesdetalle_datagridview.Rows(X).DefaultCellStyle.BackColor)
            End Select
        Next
    End Sub

    Private Sub DNICUIT_Leave(sender As Object, e As EventArgs)
        Select Case sender.textlength = 0
            Case True
                sender.backcolor = Color.White
            Case False
                Inicio.Purificaciondedatos(sender)
                Select Case Inicio.Evaluardocumento(sender)
                    Case True
                        sender.backcolor = Color.LightGreen
                    Case False
                        sender.backcolor = Color.FromArgb(255, 248, 210, 210)
                End Select
        End Select
    End Sub

    Private Sub Busquedabeneficiario_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub DNICUIT_textbox_TextChanged(sender As Object, e As EventArgs)
        Select Case sender.TextLength = 13
            Case True
                Dim datosaborrar As New DataTable
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", sender.text)
                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Proveedor from proveedores WHERE CUIT=@CUIT", datosaborrar, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Select Case datosaborrar.Rows.Count
                    Case = 1
                        '   Nombreproveedor_label.Text = datosaborrar.Rows(0).Item(0).ToString
                    Case Else
                        '   Nombreproveedor_label.Text = "No se encuentra registrado el CUIT mencionado"
                        MessageBox.Show("No se encuentra registrado el CUIT mencionado")
                        '  Dialogo_CUIT.ShowDialog()
                        Mostrardialogo(Dialogo_CUIT)
                End Select
                datosaborrar.Dispose()
        End Select
    End Sub

    Private Sub Montomovimientodetalle_textbox_TextChanged(sender As Object, e As EventArgs)
        Select Case IsNumeric(sender.text)
            Case True
            '    Montomovimientoletras_label.Text = Inicio.Numerosatextopesosconcorreccion(sender.text)
            Case False
                '     Montomovimientoletras_label.Text = "Verifique Monto"
        End Select
    End Sub

    Private Sub Fechamovimiento_monthcalendar_DateChanged(sender As Object, e As DateRangeEventArgs)
        '   Fechamovimiento_label.Text = "FECHA:" & Fechamovimiento_monthcalendar.SelectionStart.ToString("        /yyyy")
    End Sub

    Private Sub Montomovimientodetalle_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Organismo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Expte_numero_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Year_expediente_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Descripcion_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub OrdenExpediente_combobox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub N_ordenpagocargo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Year_ordenpagocargo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Monto_solicitado_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Codorden_label_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Movimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode = Keys.F5
            Case True
                If Not Cargainicial Then
                    Busqueda.Text = ""
                    Inicio.OBJETOCARGANDO(Panel13, Me, "Actualizando, por Favor espere")
                    refreshnowgeneral()
                    Inicio.OBJETOFINALIZAR(Panel13, Me)
                End If
        End Select
    End Sub

    Private Sub Datosexpedientesdetalle_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Datosexpedientesdetalle_datagridview.MouseUp, Datosexpedientes_datagridview.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub Datosexpedientesdetalle_datagridview_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datosexpedientesdetalle_datagridview.RowPrePaint
        '        Cdo_orden
        '       Cfdo
        '      CodInp
        '     mov_tipo
        Select Case Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Monto").Value
            Case Is = 0
                Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGray
            Case Is > 0
                Select Case Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("CodInp").Value
                    Case Is = 3
                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("CodInp"), Color.Yellow)
                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Detalle"), Color.Yellow)
                    Case Is = 2
                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("CodInp"), Color.LightGreen)
                    Case Is = 1
                        Select Case Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("CUIT").Value.ToString
                            Case Is = "33-69345023-9"
                                Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                                Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Detalle").Style.BackColor = Color.Aqua
                                Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
                            Case Is = "30-67238712-0"
                                Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                                Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Detalle").Style.BackColor = Color.LightGoldenrodYellow
                                Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
                            Case Else
                                Select Case Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("mov_tipo").Value.ToString.ToUpper
                                    Case Is = "IVA"
                                        Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                                        Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Detalle").Style.BackColor = Color.Aqua
                                        Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
                                    Case Else
                                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("CodInp"), Color.FromArgb(255, 248, 210, 210))
                                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Detalle"), Color.FromArgb(255, 248, 210, 210))
                                End Select
                        End Select
                    Case Is = 0
                        Colorfila(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex), Color.Pink)
                     '   Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("CodInp"), Color.Pink)
                    Case Is < 0
                End Select
            Case Is < 0
                Colorfila(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex), Color.IndianRed)
        End Select
        If (Datosexpedientes_datagridview.SelectedRows.Count > 0) Then
            Select Case Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Tipo").Value.ToString.ToUpper
                Case Is = "EJERCICIO"
                    If Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Cfdo").Value.ToString = "2" Then
                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Cfdo"), Color.LightGreen)
                    Else
                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Cfdo"), Color.Black)
                    End If
                Case Else
                    If Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Cfdo").Value.ToString = "9" Then
                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Cfdo"), Color.LightGreen)
                    Else
                        Colorcelda(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).Cells.Item("Cfdo"), Color.Black)
                    End If
            End Select
        End If
        '¡  Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Inicio.GetContrastColor(Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor)
    End Sub

    Private Sub PINTARFILA(ByVal INDICE As Integer)
        '20/07/2020 Modificación realizada para incluir la representación visual de la vista simple y la vista detallada.
        Select Case VISTABOTON.Text
            Case Is = "Vista Simple"
            Case Is = "Vista Detallada"
                '11/03/2019    Modificación realizada para manejar la representación visual de los expedientes y sus movimientos declarados.
                'Valores de los montos solicitados
                If Not IsDBNull(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente").Value) Then
                    'Verifica que no exitan valores nulos en la ceda seleccionada
                    Select Case True
                        Case Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente").Value = 0
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente"), Color.LightGray)
                        Case Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente").Value > 0
                            Colorceldanormal(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente"))
                        Case Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente").Value < 0
                            With Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente")
                                .Style.BackColor = Color.Red
                                .Style.ForeColor = Color.White
                                .Style.SelectionForeColor = Color.Black
                            End With
                    End Select
                Else
                    '   Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente"), Color.Red)
                    With Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Expediente")
                        .Style.BackColor = Color.Red
                        .Style.ForeColor = Color.White
                        .Style.SelectionForeColor = Color.Black
                    End With
                End If
                If Not Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value.ToString = "ASIG.ESP" Then
                    Select Case True
                        Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value) = 0
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo"), Color.LightGray)
                        Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value) > 0
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo"), Color.Honeydew)
                        Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value) < 0
                            With Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo")
                                .Style.BackColor = Color.Red
                                .Style.ForeColor = Color.White
                                .Style.SelectionForeColor = Color.Black
                            End With
                    End Select
                End If
                If Not Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value.ToString = "ASIG.ESP" Then
                    'Comparación Ingresos con Monto Total Pedido Fondo al expediente
                    Select Case True
                        Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value) > (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value)
                            'el ingreso es superior al monto total del pedido de fondo
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS"), Color.FromArgb(255, 248, 210, 210))
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo"), Color.FromArgb(255, 248, 210, 210))
                        Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value) = (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value)
                            If (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value) = 0 Then
                                Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS"), Color.White)
                            Else
                                Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS"), Color.Green)
                            End If
                        Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value) < (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value)
                            Select Case Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value > 0
                                Case True
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS"), Color.White)
                                Case False
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS"), Color.White)
                            End Select
                    End Select
                End If
                'Comparación Egresos con Ingresos
                Select Case True
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) > (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value)
                        'El monto de egresos supera  los ingresos
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.FromArgb(255, 248, 210, 210))
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS"), Color.FromArgb(255, 248, 210, 210))
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) = (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value)
                        If (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) = 0 Then
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.White)
                        Else
                            If Not Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value.ToString = "ASIG.ESP" Then
                                If (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) > Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value Then
                                    Select Case Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value > 0
                                        Case True
                                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.FromArgb(255, 248, 210, 210))
                                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo"), Color.FromArgb(255, 248, 210, 210))
                                        Case False
                                            ' Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.FromArgb(255, 248, 210, 210))
                                            '  Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo"), Color.FromArgb(255, 248, 210, 210))
                                    End Select
                                Else
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS"), Color.Green)
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.Green)
                                End If
                            End If
                        End If
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) < (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value)
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.Yellow)
                End Select
                Select Case True
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value) > (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS").Value)
                        'El monto de egresos supera  los ingresos
                        'Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.FromArgb(255, 248, 210, 210))
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS"), Color.FromArgb(255, 248, 210, 210))
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS").Value) = (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value)
                        If (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS").Value) = 0 Then
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS"), Color.White)
                        Else
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS"), Color.Green)
                        End If
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value) < (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS").Value)
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("MFYV INGRESOS"), Color.FromArgb(255, 248, 210, 210))
                End Select
                'Comparación Egresos con Rendido
                Select Case True
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO").Value) > (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value)
                        'El monto de egresos supera  los ingresos
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO"), Color.FromArgb(255, 248, 210, 210))
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.FromArgb(255, 248, 210, 210))
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) = (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO").Value)
                        If (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO").Value) = 0 Then
                            Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO"), Color.White)
                        Else
                            If Not Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value.ToString = "ASIG.ESP" Then
                                If ((Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) = (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO").Value) And
                                                        (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value) = (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) And
                                                        (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo").Value) = (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("INGRESOS").Value)) Then
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EXPEDIENTE"), Color.Green)
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("Monto Total Pedido Fondo"), Color.Green)
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO"), Color.Green)
                                Else
                                    Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO"), Color.Green)
                                End If
                            End If
                        End If
                    Case (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS").Value) < (Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO").Value)
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("RENDIDO"), Color.Yellow)
                        Colorcelda(Datosexpedientes_datagridview.Rows(INDICE).Cells.Item("EGRESOS"), Color.Yellow)
                End Select
        End Select
    End Sub

    Private Sub Datosexpedientes_datagridview_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datosexpedientes_datagridview.RowPrePaint
        PINTARFILA(e.RowIndex)
    End Sub

    Private Sub Busqueda_movimientos_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_movimientos.TextChanged
        Buscar_datagrid_TIMER(sender, datosexpediente_detalle, Datosexpedientesdetalle_datagridview)
    End Sub

    Private Sub ElementHostmovimiento_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
    End Sub

    Private Sub Aceptarnuevo_boton_Click(sender As Object, e As EventArgs) Handles Botonaceptar_button.Click
        Agregarmovimiento("agregar")
    End Sub

    Private Sub Modificar_boton_Click(sender As Object, e As EventArgs) Handles Modificar_boton.Click
        Agregarmovimiento("MODIFICAR")
    End Sub

    Private Sub Movimientos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        '
    End Sub

    Private Sub Tesoreria_Movimientos_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        ' Me.SuspendLayout()
    End Sub

    Private Sub Movimientos_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        '   Me.ResumeLayout()
        Select Case Me.Size.Width > 900
            Case True
                ''TableLayout_movimientos.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80%))
                'TableLayout_movimientos.ColumnStyles(0).SizeType.AutoSize = 0
                'TableLayout_movimientos.ColumnStyles(1).SizeType = SizeType.Absolute
                'TableLayout_movimientos.ColumnStyles(2).SizeType = SizeType.AutoSize
            Case False
        End Select
    End Sub

    Private Sub COD__ORDEN1_Click(sender As Button, e As EventArgs) Handles _
        COD__ORDEN1.Click, COD__ORDEN2.Click, COD__ORDEN3.Click, COD__ORDEN4.Click, COD__ORDEN5.Click, COD__ORDEN9.Click
        coloresdebotonallgray(codorden)
        If Not CARGANDOCODIGOS Then
            coloresdebotonallgray(clasefondos)
            coloresdebotonallgray(codimputacion)
        End If
        For x = 0 To codorden.Count - 1
            If sender.Name = codorden(x).Name Then
                sender.BackColor = Color.LightGreen
                Select Case x + 1
                    Case 1
                        Label_Codorden.Text = "1"
                    Case 2
                        Label_Codorden.Text = "2"
                    Case 3
                        Label_Codorden.Text = "3"
                    Case 4
                        Label_Codorden.Text = "4"
                    Case 5
                        Label_Codorden.Text = "5"
                    Case Else
                        Label_Codorden.Text = "9"
                End Select
            End If
        Next
    End Sub

    Private Sub Clasefondo1_Click(sender As Button, e As EventArgs) Handles Clasefondo1.Click, Clasefondo2.Click, Clasefondo9.Click
        ' coloresdebotonallgray(codorden)
        coloresdebotonallgray(clasefondos)
        If Not CARGANDOCODIGOS Then
            coloresdebotonallgray(codimputacion)
        End If
        For x = 0 To clasefondos.Count - 1
            If sender.Name = clasefondos(x).Name Then
                sender.BackColor = Color.LightGreen
                Select Case x + 1
                    Case 1
                        LabelClasefondo.Text = "1"
                    Case 2
                        LabelClasefondo.Text = "2"
                    Case Else
                        LabelClasefondo.Text = "9"
                End Select
            End If
        Next
    End Sub

    Private Sub Codigoimputacion1_Click(sender As Button, e As EventArgs) Handles Codigoimputacion1.Click, Codigoimputacion2.Click, Codigoimputacion3.Click, Codigoimputacion4.Click, Codigoimputacion9.Click
        ' coloresdebotonallgray(codorden)
        'coloresdebotonallgray(clasefondos)
        coloresdebotonallgray(codimputacion)
        'Calculosauxiliares_boton.Visible = False
        For x = 0 To codimputacion.Count - 1
            If sender.Name = codimputacion(x).Name Then
                sender.BackColor = Color.LightGreen
                Select Case x + 1
                    Case 1
                        Label_Codimp.Text = "1"
                        'Calculosauxiliares_boton.Visible = True
                    Case 2
                        Label_Codimp.Text = "2"
                    Case 3
                        Label_Codimp.Text = "3"
                    Case 4
                        Label_Codimp.Text = "4"
                    Case Else
                        Label_Codimp.Text = "9"
                End Select
            End If
        Next
    End Sub

    Private Sub Cuit_boton_Click(sender As Object, e As EventArgs) Handles Cuit_boton.Click
        Cuitdialogomostrar()
    End Sub

    Private Sub Cuitdelbeneficiario_textbox_TextChanged(sender As Object, e As EventArgs) Handles Cuitdelbeneficiario_textbox.TextChanged
        Beneficiario_label.Text = ""
        VerificarCUIT(sender, sender.text, Beneficiario_label)
        Modificacion_detalle("CUIT")
        Movimiento_actual.CUIT = Cuitdelbeneficiario_textbox.Text
        '  Coloresdelformulario()
    End Sub

    Private Sub Nrotransferencia_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles _
        Nrotransferencia_textbox.KeyDown,
        Cuentas_combobox.KeyDown,
        Movimientofecha_calendar.KeyDown,
        Cuitdelbeneficiario_textbox.KeyDown,
        Ordendeentrega_integerupdown.KeyDown,
        Ordendeentregayear_integerupdown.KeyDown,
        Nrotransferencia_textbox.KeyDown,
        Busqueda_movimientos.KeyDown,
        RendidoMovimientos_textbox.KeyDown,
        EgresosMovimientos_textbox.KeyDown,
        IngresosMovimientos_textbox.KeyDown,
        Detalle_textbox.KeyDown
        Select Case e.KeyCode = Keys.Space
            Case True
                If sender.Name = "Nrotransferencia_textbox" Then
                    CARGARCHEQUES()
                End If
            Case Else
                Inicio.SIGUIENTECONTROL(Me, sender, e)
        End Select
    End Sub

    Private Sub Label_Codorden_TextChanged(sender As Object, e As EventArgs) Handles Label_Codorden.TextChanged
        Try
            Select Case Label_Codorden.Text
                Case "1"
                    'codigo1
                    clasefondos(0).Visible = True
                    'codigo2
                    clasefondos(1).Visible = True
                    'codigo9
                    clasefondos(2).Visible = True
                    Orden_label.Text = "Orden de pago"
                    Label_montonombre.Text = "Monto de la Factura $"
                Case "2"
                    'codigo1
                    clasefondos(0).Visible = True
                    'codigo2
                    clasefondos(1).Visible = True
                    'codigo9
                    clasefondos(2).Visible = False
                    Orden_label.Text = "Orden de cargo"
                    Label_montonombre.Text = "Monto de la Factura $"
                Case "3"
                    'codigo1
                    clasefondos(0).Visible = True
                    'codigo2
                    clasefondos(1).Visible = True
                    'codigo9
                    clasefondos(2).Visible = False
                    Orden_label.Text = "Compra directa"
                    Label_montonombre.Text = "Monto de la Factura $"
                Case "4"
                    'codigo1
                    clasefondos(0).Visible = True
                    'codigo2
                    clasefondos(1).Visible = True
                    'codigo9
                    clasefondos(2).Visible = True
                    Orden_label.Text = "Orden de pago"
                    Label_montonombre.Text = "Monto de la Factura $"
                Case "5"
                    'codigo1
                    clasefondos(0).Visible = True
                    'codigo2
                    clasefondos(1).Visible = True
                    'codigo9
                    clasefondos(2).Visible = False
                    Orden_label.Text = "Orden de entrega"
                    Label_montonombre.Text = "Monto del comprobante"
                Case "6"
                    'codigo1
                    clasefondos(0).Visible = True
                    'codigo2
                    clasefondos(1).Visible = True
                    'codigo9
                    clasefondos(2).Visible = False
                    Orden_label.Text = "Orden de entrega"
                    Label_montonombre.Text = "Monto del comprobante"
                Case "-"
                    botones_invisibles()
                    coloresdebotonallgray(codorden)
                    coloresdebotonallgray(clasefondos)
                Case Else
            End Select
            LabelClasefondo.Text = "-"
            Label_Codimp.Text = "-"
        Catch ex As Exception
            Inicio.ToolStripDebug.Text = ex.Message & "@" & System.Reflection.MethodBase.GetCurrentMethod.Name
        End Try
        Select Case sender.name
            Case = "COD__ORDEN1"
            Case = "COD__ORDEN2"
            Case = "COD__ORDEN3"
            Case = "COD__ORDEN4"
            Case Else
                Orden_label.Text = "Orden"
        End Select
        If IsNumeric(Label_Codorden.Text) Then
            Movimiento_actual.Cod_orden = Label_Codorden.Text
        End If
    End Sub

    Private Sub LabelClasefondo_TextChanged(sender As Object, e As EventArgs) Handles LabelClasefondo.TextChanged
        Try
            Select Case LabelClasefondo.Text
                Case "1"
                    'codigo1
                    codimputacion(0).Visible = True
                    'codigo2
                    codimputacion(1).Visible = True
                    'codigo3
                    codimputacion(2).Visible = True
                    'codigo4
                    codimputacion(3).Visible = False
                    'codigo9
                    codimputacion(4).Visible = False
                Case "2"
                    'codigo1
                    codimputacion(0).Visible = True
                    'codigo2
                    codimputacion(1).Visible = True
                    'codigo3
                    codimputacion(2).Visible = True
                    'codigo4
                    codimputacion(3).Visible = True
                    'codigo9
                    codimputacion(4).Visible = True
                Case "9"
                    'codigo1
                    codimputacion(0).Visible = True
                    'codigo2
                    codimputacion(1).Visible = True
                    'codigo3
                    codimputacion(2).Visible = True
                    'codigo4
                    codimputacion(3).Visible = True
                    'codigo9
                    codimputacion(4).Visible = False
                Case "-"
                    coloresdebotonallgray(codimputacion)
                    Label_Codimp.Text = "-"
                Case Else
            End Select
            If IsNumeric(LabelClasefondo.Text) Then
                Movimiento_actual.Clase_fondo = LabelClasefondo.Text
            End If
        Catch ex As Exception
            Inicio.ToolStripDebug.Text = ex.Message & "@" & System.Reflection.MethodBase.GetCurrentMethod.Name
        End Try
    End Sub

    Private Sub Nrotransferencia_textbox_Enter(sender As Object, e As EventArgs) Handles Ordendeentrega_integerupdown.Enter,
        Ordendeentregayear_integerupdown.Enter,
        Nrotransferencia_textbox.Enter,
        Monto_factura_textbox.Enter
        sender.Select(0, sender.Text.Length)
    End Sub

    Private Sub Calculoporcentaje(ByRef Porcentaje As NumericUpDown, ByRef Resultadoretenciones As NumericUpDown, ByVal Minimonoimponible As Decimal, ByVal netoaconsiderar As NumericUpDown)
        Select Case Porcentaje.Value > 0
            Case True
                Select Case Minimonoimponible > 0
                    Case True
                        If (netoaconsiderar.Value * Porcentaje.Value) > Minimonoimponible Then
                            Resultadoretenciones.Value = netoaconsiderar.Value * (Porcentaje.Value / 100)
                            ' Inicio.TOOLTIPS(sender, "Resultado= Neto estimado (" & Netoestimado_textbox.Value & ") x (porcentaje aplicado (" & Porcentaje.Value & ") x 100)")
                        End If
                    Case False
                        Resultadoretenciones.Value = netoaconsiderar.Value * (Porcentaje.Value / 100)
                        '     Inicio.TOOLTIPS(sender, "Resultado= Neto estimado (" & Netoestimado_textbox.Value & ") x (porcentaje aplicado (" & Porcentaje.Value & ") x 100)")
                End Select
            Case False
                Resultadoretenciones.Value = 0
                '       Inicio.TOOLTIPS(sender, "Resultado=0")
        End Select
    End Sub

    Private Sub Monto_factura_textbox_Click(sender As Object, e As EventArgs) Handles Ordendeentrega_integerupdown.Click,
        Ordendeentregayear_integerupdown.Click,
        Nrotransferencia_textbox.Click,
        Monto_factura_textbox.Click
        sender.Select(0, sender.Text.Length)
    End Sub

    Private Sub Label_Codimp_TextChanged(sender As Object, e As EventArgs) Handles Label_Codimp.TextChanged
        Select Case Label_Codimp.Text
            Case Is = "1"
                If Label_Codorden.Text = "2" Then
                    Orden_label.Text = "Orden de Cargo"
                Else
                    Orden_label.Text = "Orden de Pago"
                End If
                Label_montonombre.Text = "Monto de la Factura $"
            Case Is = "2"
                Orden_label.Text = "Orden de Pago"
                Label_montonombre.Text = "Monto "
            Case Is = "3"
                Orden_label.Text = "Orden de Entrega"
                Label_montonombre.Text = "Monto "
            Case Is = "4"
                Orden_label.Text = "Orden"
                Label_montonombre.Text = "Monto "
            Case Is = "9"
                Orden_label.Text = "Orden"
                Label_montonombre.Text = "Monto "
            Case Else
                Orden_label.Text = "Orden"
                Label_montonombre.Text = "Monto "
        End Select
        If IsNumeric(Label_Codimp.Text) Then
            Movimiento_actual.cod_inp = Label_Codimp.Text
        End If
        Coloresdelformulario()
        'If Label_Codimp.Text = "1" Then
        '    Panel_Calculosauxiliares.Visible = True
        'Else
        '    Panel_Calculosauxiliares.Visible = False
        'End If
    End Sub

    'Private Sub Calculosauxiliares_boton_Click(sender As Object, e As EventArgs) Handles Calculosauxiliares_boton.Click
    '    Montodelmovimiento_textbox.Value = Monto_factura_textbox.Value
    'End Sub
    Private Sub Constancia_Boton_Click(sender As Object, e As EventArgs) Handles Constancia_Boton.Click
        AbrirsitioWEB("https://www.cuitonline.com/constancia/inscripcion/" & Cuitdelbeneficiario_textbox.Text.Replace("-", ""))
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        Inicio.OBJETOCARGANDO(SplitContainer_superior, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        refreshnowgeneral()
        Inicio.OBJETOFINALIZAR(SplitContainer_superior, Me)
    End Sub

    Private Sub Candado_fechaboton_Click(sender As Object, e As EventArgs)
        fechamovimientobloqueada = Not fechamovimientobloqueada
    End Sub

    ''' <summary>
    ''' Tablas temporales contiene las tablas que se desprenden de las opciones consideradas
    ''' </summary>
    ''' <param name="tipotabla"></param>
    ''' <returns>para seleccionar el tipo de tabla requerido</returns>
    Private Function tablastemporales(ByVal tipotabla As String) As DataTable
        Dim tabla_temporal As New DataTable
        With tabla_temporal
            Select Case tipotabla
                Case Is = "SEGUROS"
                    With .Columns
                        .Add("Tipo ")
                        .Add("Descripción")
                        .Add("CUIT")
                    End With
                    With .Rows
                        .Add("SEGURO OBLIGATORIO ", " Seguro Obligatorio (NACION) ", "30-67856116-5")
                        .Add("SEGURO SEPELIO ", " Seguro para Sepelio (NACION)", "30-67856116-5")
                        .Add("SEGURO COLECTIVO ", " Seguro para Sepelio (IPS)", "33-56318869-9")
                    End With
                Case Is = "GREMIOS"
                    With .Columns
                        .Add("GREMIO")
                        .Add("Descripción")
                        .Add("CUIT")
                    End With
                    With .Rows
                        .Add("ATE ", "ASOCIACION TRABAJADORES DEL ESTADO ", "30-53001357-6")
                        .Add("UPCN ", "UNION DEL PERSONAL CIVIL DE LA NACION ", "30-53848945-6")
                    End With
                Case Is = "JUDICIALES"
                    With .Columns
                        .Add("TIPO")
                        .Add("Descripción")
                    End With
                    With .Rows
                        .Add("ALIMENTOS ", " Pago de alimentos ")
                        .Add("EMBARGOS ", " Embargos Judiciales ")
                    End With
                Case Is = "HABERES"
                    With .Columns
                        .Add("TIPO")
                        .Add("Descripción")
                        .Add("CUIT")
                    End With
                    With .Rows
                        .Add("SUPLEMENTARIA  ( ) Nº /" & Autorizaciones.Year & " ", " Pago de SUPLEMENTARIAS", Autorizaciones.CUIT_servicioadministrativo)
                        .Add("HABERES ", "Pago de Haberes", Autorizaciones.CUIT_servicioadministrativo)
                        .Add("SAC ", "Sueldo Anual Complementario", Autorizaciones.CUIT_servicioadministrativo)
                        .Add("Bono ", "Bono Extraordinario", Autorizaciones.CUIT_servicioadministrativo)
                    End With
                Case Is = "ENTIDADES FINANCIERAS"
                    With .Columns
                        .Add("TIPO")
                        .Add("Descripción")
                        .Add("CUIT")
                    End With
                    With .Rows
                        .Add("TARJETA NATURAL ", "IPLYC-MP HOGAR-CONSORCIO DE COOPERACION", "30-71173815-7")
                        .Add("IPRODHA ", "INSTITUTO PROVINCIAL DE DESARROLLO HABITACIONAL", "30-99905419-2")
                        .Add("PRESTAFACIL ", "GRUPO PRESTAFACIL S.A.", "30-71436630-7")
                        .Add("FEDERACIÓN MUTUAL ", "FEDERACIÓN MUTUAL", "33-57449458-9")
                        .Add("ASOCIACIÓN MUTUAL ", "ASOCIACIÓN MUTUAL", "30-69366417-5")
                        .Add(" OTRO ", "", "")
                    End With
                Case Is = "SITUACION DE EMPLEO"
                    With .Columns
                        .Add("SITUACIÓN")
                    End With
                    With .Rows
                        .Add("PLANTA PERMANENTE ")
                        .Add("PLANTA TEMPORARIA ")
                        .Add("RETIROS VOLUNTARIOS ")
                        .Add("RESIDENTES MÉDICOS ")
                        .Add("AGENTES SANITARIOS ")
                        .Add("GUARDIAS PLANTA PERMANENTE ")
                        .Add("GUARDIAS PLANTA TEMPORARIA ")
                        .Add("GUARDIAS RESIDENTES MÉDICOS ")
                    End With
                Case Is = "COMPLETAR2"
                Case Is = "COMPLETAR3"
                Case Is = "COMPLETAR4"
                Case Else
            End Select
            Return tabla_temporal
        End With
    End Function

    Private Sub Tesoreria_Movimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With tipodemovimiento_datatable
            With .Columns
                .Add("Tipo ")
                .Add("Descripción")
            End With
            With .Rows
                .Add("PAGO", " Realización de un pago ")
                .Add("TRANSFERENCIA DE FONDOS", " TRANSFERENCIA DE TESORERÍA GENERAL ")
                .Add("IPS", " Agrega los movimientos correspondientes a la transferencia y el pago correspondiente al Instituto de Previsión Social")
                .Add("PAGO CON RETENCIONES", "PAGO CON CALCULO DE RETENCIONES")
                .Add("HABERES", " HABERES y SUPLEMENTARIAS DEL PERSONAL")
                .Add("GANANCIAS DEL PERSONAL", " Pago de Ganancias del personal")
                .Add("SEGUROS", " SEGUROS DE VIDA Y SEPELIO BANCO NACIÓN")
                .Add("JUDICIALES", " Movimiento correspondiente a Embargos, Petición de alimentos y similares")
                .Add("REINTEGROS", " REINTEGROS")
                .Add("GREMIOS", " Movimientos correspondientes a Gremios (ATE,UPCN,Etc.)")
                .Add("ENTIDADES FINANCIERAS", " Pago a Entidades financieras, Iprodha,etc.")
                .Add("FONDOS PERMANENTES PAGO EFECTORES", " Designado para transferir a los efectores el pago correspondiente")
                .Add("TRANSFERENCIA ENTRE CUENTAS", "Opción para registrar el pago a otra Cuenta Bancaria")
            End With
        End With
    End Sub

    Private Sub CreacionFormulariocarga()
        Dim Tabla_formulario As New DataTable
        With Tabla_formulario
            .Columns.Add("Nro Transferencia", GetType(System.Int32))
            .Columns.Add("FECHA", GetType(System.DateTime))
            .Columns.Add("ORDEN", GetType(System.String))
            .Columns.Add("CUIT", GetType(System.String))
        End With
        Tabla_formulario.Columns.Add()
    End Sub

    Private Sub Codigoimputacion1_Click(sender As Object, e As EventArgs) Handles Codigoimputacion9.Click, Codigoimputacion4.Click, Codigoimputacion3.Click, Codigoimputacion2.Click, Codigoimputacion1.Click
        If CARGANDOCODIGOS Then
        Else
            Modificacion_detalle("CODIGO IMPUTACION")
        End If
        'Coloresdelformulario()
    End Sub

    'Private Sub Codigoimputacion1_MouseClick(sender As Object, e As MouseEventArgs) Handles Codigoimputacion1.MouseClick
    '    Modificacion_detalle("CODIGO IMPUTACION")
    'End Sub
    Private Sub Coloresdelformulario()
        Select Case Label_Codimp.Text
            Case Is = "1"
                Panel_Formulario.BackColor = Color.FromArgb(255, 248, 210, 210)
            Case Is = "2"
                Panel_Formulario.BackColor = Color.LightGreen
            Case Is = "3"
                Panel_Formulario.BackColor = Color.LightYellow
            Case Else
                Panel_Formulario.BackColor = Color.LightCyan
        End Select
    End Sub

    Private Sub Modificacion_detalle(ByVal tipodecambio As String)
        Dim detalle As String = ""
        Dim listadecolumnas As New List(Of DataGridViewColumn)
        listadecolumnas.Clear()
        listadecolumnas.Add(New DataGridViewColumn)
        listadecolumnas.Add(New DataGridViewColumn)
        listadecolumnas.Add(New DataGridViewColumn)
        listadecolumnas.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        listadecolumnas.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        listadecolumnas.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If Not CARGANDOCODIGOS Then
            Select Case tipodecambio
                Case Is = "CODIGO IMPUTACION"
                    Select Case Label_Codimp.Text
                        Case Is = "1"
                            Select Case Tipodemovimiento_label.Text.ToUpper
                                Case Is = "NORMAL"
                                    detalle += "PAGO "
                                Case Is = "IPS"
                                    detalle += "PAGO "
                                Case Is = "GREMIOS"
                                    DialogDialogo_Datagridview.Carga_General(tablastemporales("GREMIOS"), "Seleccione el Gremio", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                        detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Cuitdelbeneficiario_textbox.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
                                        'Carga la situación de empleo del personal
                                        DialogDialogo_Datagridview.Carga_General(tablastemporales("SITUACION DE EMPLEO"), "Seleccione la situación del personal a pagar", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                            detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Else
                                        End If
                                        detalle += "  (" & Format(Expediente_actual.fecha, "MMMM").ToUpper & "/" & Expediente_actual.fecha.AddMonths(0).Year & ")"
                                    Else
                                        detalle += "GREMIOS "
                                    End If
                                Case Is = "JUDICIALES"
                                    DialogDialogo_Datagridview.Carga_General(tablastemporales("JUDICIALES"), "Seleccione el tipo de Seguro", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                        detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Cuitdelbeneficiario_textbox.Text = "99-99999999-9"
                                        'Carga la situación de empleo del personal
                                        DialogDialogo_Datagridview.Carga_General(tablastemporales("SITUACION DE EMPLEO"), "Seleccione la situación del personal a pagar", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                            detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Else
                                        End If
                                    Else
                                        detalle += "JUDICIALES "
                                    End If
                                Case Is = "REINTEGROS"
                                    detalle += "REINTEGRO Nº /" & Date.Now.Year & " "
                                Case Is = "SEGUROS"
                                    DialogDialogo_Datagridview.Carga_General(tablastemporales("SEGUROS"), "Seleccione el tipo de Seguro", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                        detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Cuitdelbeneficiario_textbox.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
                                        'Carga la situación de empleo del personal
                                        DialogDialogo_Datagridview.Carga_General(tablastemporales("SITUACION DE EMPLEO"), "Seleccione la situación del personal a pagar", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                            detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Else
                                        End If
                                        detalle += "  (" & Format(Expediente_actual.fecha, "MMMM").ToUpper & "/" & Expediente_actual.fecha.AddMonths(0).Year & ")"
                                    Else
                                        detalle += "SEGURO "
                                    End If
                                Case Is = "HABERES"
                                    DialogDialogo_Datagridview.Carga_General(tablastemporales("HABERES"), "Seleccion el tipo de Haberes a cargar", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                        detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Cuitdelbeneficiario_textbox.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
                                        'Carga la situación de empleo del personal
                                        DialogDialogo_Datagridview.Carga_General(tablastemporales("SITUACION DE EMPLEO"), "Seleccione la situación del personal a pagar", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                            detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Else
                                        End If
                                        detalle += "  (" & Format(Expediente_actual.fecha, "MMMM").ToUpper & "/" & Expediente_actual.fecha.AddMonths(0).Year & ")"
                                    Else
                                        detalle += "HABERES "
                                    End If
                                Case Is = "ENTIDADES FINANCIERAS"
                                    DialogDialogo_Datagridview.Carga_General(tablastemporales("ENTIDADES FINANCIERAS"), "Seleccion la Entidad Financiera", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                        detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Cuitdelbeneficiario_textbox.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
                                        'Carga la situación de empleo del personal
                                        DialogDialogo_Datagridview.Carga_General(tablastemporales("SITUACION DE EMPLEO"), "Seleccione la situación del personal a pagar", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                            detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                        Else
                                        End If
                                        detalle += "  (" & Format(Expediente_actual.fecha, "MMMM").ToUpper & "/" & Expediente_actual.fecha.AddMonths(0).Year & ")"
                                    Else
                                        detalle += "EF "
                                    End If
                                Case Is = "GANANCIAS DEL PERSONAL"
                                    detalle += " GANANCIAS "
                                    Cuitdelbeneficiario_textbox.Text = "33-69345023-9"
                                    'Carga la situación de empleo del personal
                                    DialogDialogo_Datagridview.Carga_General(tablastemporales("SITUACION DE EMPLEO"), "Seleccione la situación del personal a pagar", "Seleccionar", "Cancelar", 9, listadecolumnas)
                                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                                        detalle += DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                                    Else
                                    End If
                                    detalle += "  (" & Format(Expediente_actual.fecha, "MMMM").ToUpper & "/" & Expediente_actual.fecha.AddMonths(0).Year & ")"
                                Case Is = "TRANSFERENCIA ENTRE CUENTAS"
                                    Cuitdelbeneficiario_textbox.Text = CUIT_servicioadministrativo
                                    detalle = "Transferencia a la cuenta -(" & DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value.ToString & ")- Expte:" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value & " Guardado en 9999-" &
                                      DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.Substring(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.Length - 6, 5) & "/" & Autorizaciones.Year
                                    'Carga la situación de empleo del personal
                                Case Else
                                    detalle += "PAGO "
                            End Select
                        Case Is = "2"
                            detalle += "REND. Expte " & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value & " "
                            Monto_factura_textbox.Value = Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Monto Expediente").Value
                        Case Is = "3"
                            detalle += "TRANSF. "
                        Case Is = "0"
                        Case Else
                            detalle += ""
                    End Select
                    detalle_estructura.detalle = detalle
                Case Is = "FECHA"
                    detalle_estructura.fecha = Movimientofecha_calendar.Value
                Case Is = "CUIT"
                    detalle_estructura.beneficiario = " (" & Beneficiario_label.Text & ")"
            End Select
            If Not Label_Codimp.Text = "0" Then
                Detalle_textbox.Text = detalle_estructura.detalle & detalle_estructura.beneficiario & detalle_estructura.fecha.ToShortDateString
            End If
        End If
        'Return detalle
    End Sub

    Private Sub Cargartotalfactura_Click(sender As Object, e As EventArgs) Handles Cargartotalfactura.Click
        Dim totalestemporales As New DataTable
        totalestemporales = Expediente_actual.retornartotales(Expediente_actual.claveexpediente)
        Monto_factura_textbox.Value = totalestemporales.Rows(0).Item("SALDO")
        totalestemporales.Dispose()
    End Sub

    Private Sub COD__ORDEN1_Click(sender As Object, e As EventArgs) Handles COD__ORDEN9.Click, COD__ORDEN5.Click, COD__ORDEN4.Click, COD__ORDEN3.Click, COD__ORDEN2.Click, COD__ORDEN1.Click
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Nrotransferencia_textbox_ValueChanged(sender As Object, e As EventArgs) Handles Nrotransferencia_textbox.ValueChanged
        sender.Text = String.Format("{0:N0}", sender.Value)
        Movimiento_actual.Transferencia = Nrotransferencia_textbox.Value
    End Sub

    Private Sub Beneficiario_label_TextChanged(sender As Object, e As EventArgs) Handles Beneficiario_label.TextChanged
    End Sub

    Private Sub Movimientofecha_calendar_ValueChanged(sender As Object, e As EventArgs) Handles Movimientofecha_calendar.ValueChanged
        Movimiento_actual.Fecha_movimiento = Movimientofecha_calendar.Value
        Modificacion_detalle("FECHA")
        'Coloresdelformulario()
    End Sub

    Private Sub IPS_CHECKBOX_CheckedChanged(sender As Object, e As EventArgs)
        If sender.checked = True Then
            If Not (Cuitdelbeneficiario_textbox.Text = "33-56318869-9") Then
                Cuitdelbeneficiario_textbox.Text = "33-56318869-9"
            End If
        End If
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged, Busqueda.KeyDown
        Buscar_datagrid_TIMER(Busqueda, datosExpediente, Datosexpedientes_datagridview)
        Datosexpedientesdetalle_datagridview.DataSource = Nothing
    End Sub

    Private Sub Borrarmovimiento_boton_Click(sender As Object, e As EventArgs) Handles Borrar_boton.Click
        Select Case MsgBox("Confirma que desea BORRAR el movimiento seleccionado del Expediente N" & Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value.ToString, MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                Select Case Permitirmodificacion()
                    Case True
                        Select Case Datosexpedientesdetalle_datagridview.Enabled
                            Case True
                                Select Case Datosexpedientesdetalle_datagridview.SelectedRows.Count > 0
                                    Case True
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value)
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `Expediente_detalle` WHERE Clave_expediente_detalle=@Clave_expediente_detalle"
                                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Datosexpedientesdetalle_datagridview.SelectedRows(0).Cells.Item("Clave_expediente_detalle").Value)
                                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `retenciones` WHERE Clave_expediente_detalle=@Clave_expediente_detalle"
                                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                        refreshNowGeneralIntermedio()
                                        refreshnowdetallado()
                                    Case False
                                        MessageBox.Show("No ha seleccionado ningún detalle del expediente para que sea borrado")
                                End Select
                            Case False
                                MessageBox.Show("El expediente actual no cuenta con un pedido de fondos")
                        End Select
                    Case False
                        MsgBox("El movimiento se ha rendido " & "No puede ser modificado", MsgBoxStyle.Information, "El movimiento no se puede modificar")
                End Select
        End Select
    End Sub

    Private Sub Borrar_boton_Click(sender As Object, e As EventArgs) Handles Borrar_boton.Click
    End Sub

    Private Sub pagoconretencionesllamado()
        If IsNothing(Movimiento_actual.Clase_fondo) Then
            If Not Movimiento_actual.Clase_fondo > 0 Then
                Select Case Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("tipo").Value.ToString.Contains("RP")
                    Case True
                        Movimiento_actual.Clase_fondo = 9
                    Case False
                        Movimiento_actual.Clase_fondo = 2
                End Select
            End If
        Else
            Select Case Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("tipo").Value.ToString.Contains("RP")
                Case True
                    Movimiento_actual.Clase_fondo = 9
                Case False
                    Movimiento_actual.Clase_fondo = 2
            End Select
        End If
        If Not Movimiento_actual.Clave_expediente_detalle = 0 Then
            Movimiento_actual.cargarmovimiento(Movimiento_actual.Clave_expediente_detalle)
            Tesoreria_Dialogoretenciones.Carga_general(Movimiento_actual, Expediente_actual, Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
            cargar_retenciones()
        Else
            Movimiento_actual.Cargar_expediente(Movimiento_actual.claveexpediente)
            Tesoreria_Dialogoretenciones.Carga_general(Movimiento_actual, Expediente_actual, Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        End If
        refreshnowdetallado()
        Datosexpedientesdetalle_datagridview.CurrentCell = Nothing
    End Sub

    Private Sub tipodemovimiento_acciones()
        Select Case Tipodemovimiento_label.Text.ToUpper
            Case Is = "PAGO"
            Case Is = "TRANSFERENCIA DE FONDOS"
            Case Is = "IPS"
                If Not (Cuitdelbeneficiario_textbox.Text = "33-56318869-9") Then
                    Cuitdelbeneficiario_textbox.Text = "33-56318869-9"
                End If
            Case Is = "PAGO CON RETENCIONES"
                'REALIZAR PAGO CON RETENCIONES
                pagoconretencionesllamado()
            Case Is = "SEGUROS"
                If Not (Cuitdelbeneficiario_textbox.Text = "30-67856116-5") Then
                    Cuitdelbeneficiario_textbox.Text = "30-67856116-5"
                End If
            Case Is = "DGR"
                If Not (Cuitdelbeneficiario_textbox.Text = "30-67238712-0") Then
                    Cuitdelbeneficiario_textbox.Text = "30-67238712-0"
                End If
            Case Is = "JUDICIALES"
                'cambiaarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr
                'Mostrardialogo(Dialogoretenciones)
            Case Is = "REINTEGROS"
            Case Is = "GREMIOS"
            Case Is = "FONDOS PERMANENTES PAGO EFECTORES"
                Cuitdelbeneficiario_textbox.Text = Autorizaciones.CUIT_servicioadministrativo
                Dim SEPARADOR As String() = Nothing
                Dim tabladefondos As DataTable = Ordendepago.Fondos_permanentes(True)
                DialogDialogo_Datagridview.Carga_General(tabladefondos, "Seleccione el fondo permanente que desea reponer", "Seleccionar", "Cancelar", 9)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    Detalle_textbox.Text = "FONDOS PERMANENTES -" & DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper & " Expte:" &
                     SICyFC.Expediente.ClavetoExpediente(Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value)
                    Ordendeentrega_integerupdown.Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(3).Value
                    ORDENCARGO_FONDOPERMANENTE = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value.ToString.ToUpper
                    EXPEDIENTE_FONDOPERMANENTE = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value.ToString.ToUpper
                    SEPARADOR = DIVISORUNIVERSAL(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("EXPEDIENTE").Value.ToString.ToUpper)
                    If Not IsNothing(SEPARADOR) Then
                        Movimiento_actual.principalclaveexpediente = SEPARADOR(2) & SEPARADOR(0) & Format(Convert.ToInt32(SEPARADOR(1)), "00000")
                    End If
                End If
            Case Is = "TRANSFERENCIA ENTRE CUENTAS"
                Cuitdelbeneficiario_textbox.Text = Autorizaciones.CUIT_servicioadministrativo
                Dim SEPARADOR As String() = Nothing
                Dim Cuentasbancarias As DataTable = Cuentas
                DialogDialogo_Datagridview.Carga_General(Cuentasbancarias, "Seleccione la cuenta Bancaria de destino", "Seleccionar", "Cancelar", 9)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    Detalle_textbox.Text = "Transferencia a la cuenta -(" & DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value.ToString & ") - Expte:" &
                    Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Expediente").Value
                    ' Ordendeentrega_integerupdown.Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(3).Value
                    cuentabancariaguardar = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
                    If Not IsNothing(SEPARADOR) Then
                        Movimiento_actual.principalclaveexpediente = SEPARADOR(2) & SEPARADOR(0) & Format(Convert.ToInt32(SEPARADOR(1)), "00000")
                    End If
                End If
            Case Else
        End Select
    End Sub

    Private Sub Tipo_movimiento_boton_Click(sender As Object, e As EventArgs) Handles Tipo_movimiento_boton.Click
        tipodemovimiento_seleccion()
    End Sub

    Private Sub tipodemovimiento_seleccion()
        If Retenciones_Datagridview.Rows.Count > 0 Then
            pagoconretencionesllamado()
        Else
            DialogDialogo_Datagridview.Carga_General(tipodemovimiento_datatable, "Seleccione el tipo de movimiento", "Seleccionar", "Cancelar")
            DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            If Retenciones_Datagridview.Rows.Count > 0 Then
                For x = 0 To tipodemovimiento_datatable.Rows.Count - 1
                    Select Case tipodemovimiento_datatable.Rows(x).Item(0).ToString.ToUpper
                        Case Is = "PAGO CON RETENCIONES"
                            DialogDialogo_Datagridview.Datosdialogo_datagridview.Rows(x).Selected = True
                            Exit For
                    End Select
                Next
            End If
            If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                Tipodemovimiento_label.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                tipodemovimiento_acciones()
            Else
                '   Labelcuentaespecialasignada.Text = ""
            End If
        End If
    End Sub

    Private Sub Clasefondo1_Click(sender As Object, e As EventArgs) Handles Clasefondo9.Click, Clasefondo2.Click, Clasefondo1.Click
    End Sub

    Private Sub Detalle_textbox_TextChanged(sender As Object, e As EventArgs) Handles Detalle_textbox.TextChanged
        Movimiento_actual.descripcion = Detalle_textbox.Text
    End Sub

    Private Sub Ordendeentrega_integerupdown_ValueChanged(sender As Object, e As EventArgs) Handles Ordendeentrega_integerupdown.ValueChanged
        'Movimiento_actual.Orden = Ordendeentrega_integerupdown.Value
        'Movimiento_actual.Orden_year = Ordendeentregayear_integerupdown.Value
    End Sub

    Private Sub IngresosMovimientos_textbox_TextChanged(sender As Object, e As EventArgs) Handles IngresosMovimientos_textbox.TextChanged
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
    End Sub

    Private Sub EgresosMovimientos_textbox_TextChanged(sender As Object, e As EventArgs) Handles EgresosMovimientos_textbox.TextChanged
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
    End Sub

    Private Sub RendidoMovimientos_textbox_TextChanged(sender As Object, e As EventArgs) Handles RendidoMovimientos_textbox.TextChanged
    End Sub

    Private Sub Panel_datosmovimiento_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Datosexpedientes_datagridview_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datosexpedientes_datagridview.ColumnHeaderMouseClick
        Click_ordenar_columna_Datagridview(sender, e, "Num Pedido Fondo", "Clave_pedidofondo")
    End Sub

    Private Sub Monto_factura_textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Monto_factura_textbox.KeyPress
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub Nrotransferencia_textbox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Nrotransferencia_textbox.MouseDoubleClick
        CARGARCHEQUES()
    End Sub

    Private Sub CARGARCHEQUES()
        Nrotransferencia_textbox.Value = Movimiento.Cargartransferencias(Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
    End Sub

    Private Sub Datosexpedientesdetalle_datagridview_SelectionChanged(sender As Object, e As EventArgs) Handles Datosexpedientesdetalle_datagridview.SelectionChanged
        If Not Datosexpedientesdetalle_datagridview.SelectedRows.Count = 1 Then
            Retenciones_Datagridview.DataSource = Nothing
        End If
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As KeyEventArgs)
    End Sub

    Private Sub Transferenciaspendientes_boton_Click(sender As Object, e As EventArgs) Handles Transferenciaspendientes_boton.Click
        transferenciaspendientes()
    End Sub

    Private Sub transferenciaspendientes()
        Dim transferenciaspendientes_datatable As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", New DateTime(Autorizaciones.Year, 1, 1))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
select
CONCAT(Substring(Clave_expediente_detalle From 5 for 4),'-',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(Clave_expediente_detalle From 1 for 4)) as Expediente_N,
fechadelmovimiento as Fecha,
Detalle,
Monto
  from
(select * from expediente_detalle where Nrotransferencia=0 and codinp=1 and monto  >0 and fechadelmovimiento>@primerdia
   AND
        (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)))
        OR (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE CUENTA_ESPECIAL=@CUENTA) )
)detalle
order by fechadelmovimiento desc
 ", transferenciaspendientes_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        DialogDialogo_Datagridview.Carga_General(transferenciaspendientes_datatable, "Movimientos con Nro de transferencia 0 (cero)", "Seleccionar", "Cancelar")
        'DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Busqueda.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
        End If
    End Sub

    Private Sub IMPUESTOSPENDIENTES()
        Dim transferenciaspendientes_datatable As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", New DateTime(Autorizaciones.Year, 1, 1))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@primerdia", Datosexpedientes_datagridview.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
select
CONCAT(Substring(detalle.Clave_expediente_detalle From 5 for 4),'-',cast(Substring(detalle.Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(detalle.Clave_expediente_detalle From 1 for 4)) as Expediente_N,
fechadelmovimiento as Fecha,
Detalle,
Monto,
CASE WHEN ISNULL(GANANCIAS.Monto_retenido) THEN 0 ELSE GANANCIAS.Monto_retenido END AS 'GANANCIAS',
CASE WHEN ISNULL(GANANCIAS.PAGADO) THEN '-' ELSE GANANCIAS.PAGADO END AS 'GCIAS PAGADO',
CASE WHEN ISNULL(SUSS.Monto_retenido) THEN 0 ELSE SUSS.Monto_retenido END AS 'SUSS',
CASE WHEN ISNULL(SUSS.PAGADO) THEN '-' ELSE SUSS.PAGADO END AS 'SUSS PAGADO',
CASE WHEN ISNULL(IVA.Monto_retenido) THEN 0 ELSE IVA.Monto_retenido END AS 'IVA',
CASE WHEN ISNULL(IVA.PAGADO) THEN '-' ELSE IVA.PAGADO END AS 'IVA PAGADO',
CASE WHEN ISNULL(DGR.Monto_retenido) THEN 0 ELSE DGR.Monto_retenido END AS 'DGR',
CASE WHEN ISNULL(DGR.PAGADO) THEN '-' ELSE DGR.PAGADO END AS 'DGR PAGADO'
  from
(select * from expediente_detalle where Nrotransferencia>0 and codinp=1 and monto  >0 and fechadelmovimiento>@primerdia AND ISNULL(NRO_RECIBO)
   AND
        ((SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
                (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)))
        OR (SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN (SELECT Clave_expediente FROM expediente WHERE CUENTA_ESPECIAL=@CUENTA) ))
				and
				clave_expediente_detalle in (select clave_expediente_detalle from retenciones where isnull(nro_recibo))
)detalle
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
order by fechadelmovimiento desc
 ", transferenciaspendientes_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        DialogDialogo_Datagridview.Carga_General(transferenciaspendientes_datatable, "Movimientos con retenciones sin Recibo", "Seleccionar", "Cancelar")
        'DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Busqueda.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
        End If
    End Sub

    Private Sub Impuestospendientes_boton_Click(sender As Object, e As EventArgs) Handles Impuestospendientes_boton.Click
        IMPUESTOSPENDIENTES()
    End Sub

    Private Sub VISTABOTON_Click(sender As Object, e As EventArgs) Handles VISTABOTON.Click
        cambiarvista(sender)
        Inicio.OBJETOCARGANDO(Panel13, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        refreshnowgeneral()
        Inicio.OBJETOFINALIZAR(Panel13, Me)
    End Sub

    Private Sub cambiarvista(ByRef Sender As Button)
        Select Case Sender.Name.ToUpper
            Case Is = "VISTABOTON"
                Select Case Sender.Text
                    Case Is = "Vista Simple"
                        Sender.Text = "Vista Detallada"
                    Case Is = "Vista Detallada"
                        Sender.Text = "Vista Simple"
                End Select
            Case Is = "MOV_VISION"
                Select Case Sender.Text
                    Case Is = "EJERCICIO"
                        Sender.Text = "RP/EJ"
                    Case Is = "RP/EJ"
                        Sender.Text = "EJERCICIO"
                End Select
        End Select
    End Sub

    Private Sub Mov_vision_Click(sender As Object, e As EventArgs) Handles Mov_vision.Click
        cambiarvista(sender)
        Inicio.OBJETOCARGANDO(Panel13, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        refreshnowdetallado()
        Inicio.OBJETOFINALIZAR(Panel13, Me)
    End Sub

    Private Sub Datosexpedientes_datagridview_SelectionChanged(sender As Object, e As EventArgs) Handles Datosexpedientes_datagridview.SelectionChanged
        If Not Datosexpedientes_datagridview.SelectedRows.Count > 0 Then
            refreshnowdetallado(True)
            '  Datosexpedientesdetalle_datagridview.DataSource = Nothing
        End If
    End Sub

    Private Sub Datosexpedientes_datagridview_DataSourceChanged(sender As Object, e As EventArgs) Handles Datosexpedientes_datagridview.DataSourceChanged
        Datosexpedientesdetalle_datagridview.DataSource = Nothing
        Retenciones_Datagridview.DataSource = Nothing
    End Sub

End Class