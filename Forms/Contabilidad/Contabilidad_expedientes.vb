Public Class Contabilidad_expedientes
    Dim Expedientes_datatable As New DataTable
    Dim ordenprovision_datatable As New DataTable
    Dim ordenpago_datatable As New DataTable
    Dim filadatatable As New DataTable
    Dim ordendeprovision As New OrdenProvision
    Dim expediente_seleccionado As New Expediente
    Dim ORDENPAGO_ACTUAL As New Ordendepago

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(Busqueda_textbox, Expedientes_datatable, Datos_datagrid)
    End Sub

    ''' <summary>
    ''' Utilizado para Cargar o recargar los datos de los expedientes en forma general
    ''' </summary>
    ''' <param name="parcial"> Define si la actualización es completa o solamente la fila seleccionada</param>
    Private Sub Cargar_expedientes(Optional parcial As Boolean = False)
        Dim BUSQUEDAGUARDADA As String = ""
        If Busqueda_textbox.Text.Length > 0 Then
            BUSQUEDAGUARDADA = Busqueda_textbox.Text
            Busqueda_textbox.Text = ""
        End If
        Dim consultasql As String = "
Select
case when isnull(ordPAGO.`TIPO`) then '' else ordPAGO.`Orden_PAGO` END as 'O.Pago',
`Expediente N`,
FECHA,
DETALLE,
MONTO,
Case when isnull(ordPAGO.`TIPO`) then '' else ordPAGO.`TIPO` END as 'Tipos',
case when isnull(ordPAGO.`TIPO`) then 0 else ordPAGO.total END AS 'Total acumulado O.P.',
GROUP_CONCAT(distinct `Orden_PROVISION`) as 'O.Prov.',
`Pedido Fondo N`,
EXP.CLAVE_EXPEDIENTE,
Clave_pedidofondo,
cuenta_especial,
	ClaveExpteprincipal,
	case when isnull(ordPAGO.`TIPO`) then '' else ordPAGO.`Orden_PAGO` END as 'Ordenpago',
	OrdenCargo,
columnaordenpago	from
(SELECT
	CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as 'Expediente N',
	Fecha,
	Detalle,
	Monto,
	Clave_pedidofondo,
	Clave_expediente,ClaveExpteprincipal,
	Ordenpago,
	OrdenCargo,
CONCAT(cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) as 'Pedido Fondo N',
Cuenta_especial,CASE WHEN HABERES>0 THEN 'SUELDO' ELSE '' END AS 'HABERES'
FROM
	Expediente order by FECHA desc )exp
LEFT join
(Select
GROUP_CONCAT(DISTINCT  concat(cast(Substring(Clave_Ordenpago From 9 for 5)AS UNSIGNED),'/',Substring(Clave_Ordenpago From 1 for 4)) )  as 'Orden_PAGO',
GROUP_CONCAT(DISTINCT  TIPO  )  as 'TIPO',
sum(MONTO) AS 'TOTAL',clave_expediente,
#POSIBLE FUENTE DE RETRASO EN LA CARGA
MAX(Clave_Ordenpago) as 'columnaordenpago'
 from contabilidad_ordenpago
 group by clave_expediente
 )ordPAGO
on exp.clave_expediente=ordPAGO.clave_expediente
LEFT join
(Select
 concat(cast(Substring(Clave_ordenprovision  From 9 for 5)AS UNSIGNED),'/',Substring(Clave_ordenprovision From 1 for 4)) as 'Orden_PROVISION',
TOTAL AS 'TOTAL_OP',Clave_ordenprovision,clave_expediente
 from suministros_orden_provision)ORDPROV
on exp.clave_expediente=ORDPROV.clave_expediente
group by `Expediente N`
ORDER BY columnaordenpago DESC "
        If Not parcial Then
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Expedientes_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Else
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
            consultasql = "
Select
case when isnull(ordPAGO.`TIPO`) then '' else ordPAGO.`Orden_PAGO` END as 'O.Pago',
`Expediente N`,
FECHA,
DETALLE,
MONTO,
Case when isnull(ordPAGO.`TIPO`) then '' else ordPAGO.`TIPO` END as 'Tipos',
case when isnull(ordPAGO.`TIPO`) then 0 else ordPAGO.total END AS 'Total acumulado O.P.',
GROUP_CONCAT(distinct `Orden_PROVISION`) as 'O.Prov.',
`Pedido Fondo N`,
EXP.CLAVE_EXPEDIENTE,
Clave_pedidofondo,
cuenta_especial,
	ClaveExpteprincipal,
	case when isnull(ordPAGO.`TIPO`) then '' else ordPAGO.`Orden_PAGO` END as 'Ordenpago',
	OrdenCargo,
columnaordenpago	from
(SELECT
	CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as 'Expediente N',
	Fecha,
	Detalle,
	Monto,
	Clave_pedidofondo,
	Clave_expediente,ClaveExpteprincipal,
	Ordenpago,
	OrdenCargo,
CONCAT(cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) as 'Pedido Fondo N',
Cuenta_especial,CASE WHEN HABERES>0 THEN 'SUELDO' ELSE '' END AS 'HABERES'
FROM
	Expediente order by FECHA desc )exp
LEFT join
(Select
GROUP_CONCAT(DISTINCT  concat(cast(Substring(Clave_Ordenpago From 9 for 5)AS UNSIGNED),'/',Substring(Clave_Ordenpago From 1 for 4)) )  as 'Orden_PAGO',
GROUP_CONCAT(DISTINCT  TIPO  )  as 'TIPO',
sum(MONTO) AS 'TOTAL',clave_expediente,
#POSIBLE FUENTE DE RETRASO EN LA CARGA
MAX(Clave_Ordenpago) as 'columnaordenpago'
 from contabilidad_ordenpago
 group by clave_expediente
 )ordPAGO
on exp.clave_expediente=ordPAGO.clave_expediente
LEFT join
(Select
 concat(cast(Substring(Clave_ordenprovision  From 9 for 5)AS UNSIGNED),'/',Substring(Clave_ordenprovision From 1 for 4)) as 'Orden_PROVISION',
TOTAL AS 'TOTAL_OP',Clave_ordenprovision,clave_expediente
 from suministros_orden_provision)ORDPROV
on exp.clave_expediente=ORDPROV.clave_expediente
group by `Expediente N`
ORDER BY columnaordenpago DESC
 "
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, filadatatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
            If filadatatable.Rows.Count > 0 Then
                For x = 0 To Datos_datagrid.Columns.Count - 1
                    Datos_datagrid.SelectedRows(0).Cells.Item(x).Value = filadatatable.Rows(0).Item(x)
                Next
            End If
        End If
        Datos_datagrid.DataSource = Expedientes_datatable
        With Datos_datagrid
            .Columns("O.pago").DefaultCellStyle.Font = New Font(Datos_datagrid.DefaultCellStyle.Font.Name, Datos_datagrid.DefaultCellStyle.Font.Size + 4, FontStyle.Bold)
            .Columns("O.pago").DefaultCellStyle.BackColor = Color.White
            .Columns("O.pago").DefaultCellStyle.ForeColor = Color.FromArgb(100, 254, 79, 16)
            .Columns("O.Prov.").DefaultCellStyle.BackColor = Color.White
            .Columns("O.Prov.").DefaultCellStyle.ForeColor = Color.Blue
            'Pedido Fondo N
            .Columns("Pedido Fondo N").DefaultCellStyle.BackColor = Color.White
            .Columns("Pedido Fondo N").DefaultCellStyle.ForeColor = Color.Green
        End With
        Formatocolumnas(Datos_datagrid, CType(Datos_datagrid.DataSource, DataTable))
        Busqueda_textbox.Text = BUSQUEDAGUARDADA
    End Sub

    Private Sub CargarOrdenespago(ByVal clave_expediente As Long)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        Dim consultasql As String = "Select CLAVE_ORDENPAGO,
concat(cast(substring(CLAVE_ORDENPAGO from 9 for 5) as unsigned),'/',cast(substring(CLAVE_ORDENPAGO from 1 for 4) as unsigned)) as 'NUM.OP' ,
DETALLE,MONTO AS 'TOTAL',TIPO FROM CONTABILIDAD_ORDENPAGO where Clave_expediente=@clave_expediente or Clave_expediente_2=@clave_expediente"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, ordenpago_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_ordenpago.DataSource = ordenpago_datatable
        Formatocolumnas(Datos_ordenpago, CType(Datos_ordenpago.DataSource, DataTable))
        Datos_ordenpago.Columns("CLAVE_ORDENPAGO").Visible = False
        Datos_ordenpago.CurrentCell = Nothing
    End Sub

    Private Sub CargarActasderecepcion(ByVal clave_expediente As Long)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        Dim consultasql As String = "Select concat(cast(substring(Clave_actarecepcion from 9 for 5) as unsigned),'/',cast(substring(Clave_actarecepcion from 1 for 4) as unsigned)) as 'NUM.AR' ,
Clave_actarecepcion,
Clave_ordenprovision,
Clave_expediente,
Iniciador,
Destino,
Tipo_origen,
Numero_origen,
Year_origen,
Fecha_origen,
CUIT,
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumentolegal,
Fecha_instrumentolegal,
Total,
Lugar_entrega,
valor_tiempoentrega,
Unidad_tiempoentrega,
fecharealizada_ordenprovision,
Fechaconfeccionada_ordenprovision
from suministros_orden_provision where Clave_expediente=@clave_expediente"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, ordenprovision_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_ordenprovision.DataSource = ordenprovision_datatable
        Datos_ordenprovision.Columns("Clave_actarecepcion").Visible = False
        Datos_ordenprovision.Columns("Clave_ordenprovision").Visible = False
        Datos_ordenprovision.Columns("Clave_expediente").Visible = False
        Datos_ordenprovision.Columns("Iniciador").Visible = True
        Datos_ordenprovision.Columns("Destino").Visible = True
        Datos_ordenprovision.Columns("Tipo_origen").Visible = False
        Datos_ordenprovision.Columns("Numero_origen").Visible = False
        Datos_ordenprovision.Columns("Year_origen").Visible = False
        Datos_ordenprovision.Columns("Fecha_origen").Visible = False
        Datos_ordenprovision.Columns("CUIT").Visible = False
        Datos_ordenprovision.Columns("Tipo_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Numero_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Year_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Fecha_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Total").Visible = True
        Datos_ordenprovision.Columns("Lugar_entrega").Visible = False
        Datos_ordenprovision.Columns("valor_tiempoentrega").Visible = False
        Datos_ordenprovision.Columns("Unidad_tiempoentrega").Visible = False
        Datos_ordenprovision.Columns("fecharealizada_ordenprovision").Visible = False
        Datos_ordenprovision.Columns("Fechaconfeccionada_ordenprovision").Visible = False
    End Sub

    Private Sub cargarordenesdeprovision(ByVal clave_expediente As Long)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        Dim consultasql As String = "Select concat(cast(substring(Clave_ordenprovision from 9 for 5) as unsigned),'/',cast(substring(Clave_ordenprovision from 1 for 4) as unsigned)) as 'NUM.OP' ,
Clave_ordenprovision,
Clave_expediente,
Iniciador,
Destino,
Tipo_origen,
Numero_origen,
Year_origen,
Fecha_origen,
CUIT,
Tipo_instrumentolegal,
Numero_instrumentolegal,
Year_instrumentolegal,
Fecha_instrumentolegal,
Total,
Lugar_entrega,
valor_tiempoentrega,
Unidad_tiempoentrega,
fecharealizada_ordenprovision,
Fechaconfeccionada_ordenprovision
from suministros_orden_provision where Clave_expediente=@clave_expediente"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, ordenprovision_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_ordenprovision.DataSource = ordenprovision_datatable
        Datos_ordenprovision.CurrentCell = Nothing
        Datos_ordenprovision.Columns("Clave_ordenprovision").Visible = False
        Datos_ordenprovision.Columns("Clave_expediente").Visible = False
        Datos_ordenprovision.Columns("Iniciador").Visible = True
        Datos_ordenprovision.Columns("Destino").Visible = True
        Datos_ordenprovision.Columns("Tipo_origen").Visible = False
        Datos_ordenprovision.Columns("Numero_origen").Visible = False
        Datos_ordenprovision.Columns("Year_origen").Visible = False
        Datos_ordenprovision.Columns("Fecha_origen").Visible = False
        Datos_ordenprovision.Columns("CUIT").Visible = False
        Datos_ordenprovision.Columns("Tipo_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Numero_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Year_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Fecha_instrumentolegal").Visible = False
        Datos_ordenprovision.Columns("Total").Visible = True
        Datos_ordenprovision.Columns("Lugar_entrega").Visible = False
        Datos_ordenprovision.Columns("valor_tiempoentrega").Visible = False
        Datos_ordenprovision.Columns("Unidad_tiempoentrega").Visible = False
        Datos_ordenprovision.Columns("fecharealizada_ordenprovision").Visible = False
        Datos_ordenprovision.Columns("Fechaconfeccionada_ordenprovision").Visible = False
    End Sub

    Private Sub CARGAR_ORDENPROVISION()
        Suministros_OrdenProvision.Todoacero()
        Suministros_OrdenProvision.OrdenProvision.ClaveExpediente = Datos_datagrid.SelectedRows(0).Cells.Item("EXPEDIENTE N").Value
        Suministros_OrdenProvision.OrdenProvision.Iniciador = Datos_datagrid.SelectedRows(0).Cells.Item("INICIADOR").Value
        Mostrardialogo(Suministros_OrdenProvision)
    End Sub

    Private Sub Datos_datagrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_datagrid.CellEnter
        If Datos_datagrid.SelectedRows.Count = 1 Then
            Paneldatosexpedientes.Visible = True
            modificar_boton.Visible = True
            Botoneliminar.Visible = True
            Cargadedatos()
            REFRESHDETALLES()
        Else
            Paneldatosexpedientes.Visible = False
            modificar_boton.Visible = False
            Botoneliminar.Visible = False
        End If
    End Sub

    Private Sub Cargadedatos()
        Dim Informacion_General As New List(Of String)
        Dim Expedienteprincipal As Claveexpediente_separar
        Dim expedienteprincipal_string As String = ""
        Dim totalEjecutadoExptePrincipal As Decimal = 0
        Dim Tablatemporalpedidofondo As New DataTable
        Dim tablatemporalexpedientesrelacionados_principal As New DataTable
        Dim tablatemporalexpedientesrelacionados_hijos As New DataTable
        Dim ordenentabcontrol As Integer = 0
        expediente_seleccionado.clear()
        expediente_seleccionado.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value.ToString
        expediente_seleccionado.Desglose_clave()
        'Inicio.Expedientesdividir(Datos_datagrid.SelectedRows(0).Cells.Item("Expediente N").Value.ToString, expediente_seleccionado.organismo, expediente_seleccionado.numero, expediente_seleccionado.year)
        '----------------------------------------------------------------------------------------------------------------
        Select Case Datos_datagrid.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString.Length > 0
            Case True
                If Not Datos_datagrid.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString.StartsWith("/") Then
                    Try
                        Inicio.divisoruniversal(Datos_datagrid.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString, expediente_seleccionado.ordenpago, expediente_seleccionado.ordenpagoyear)
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
        Select Case Datos_datagrid.SelectedRows(0).Cells.Item("Ordencargo").Value.ToString.Length > 0
            Case True
                Inicio.divisoruniversal(Datos_datagrid.SelectedRows(0).Cells.Item("Ordencargo").Value.ToString, expediente_seleccionado.ordencargo, expediente_seleccionado.ordencargoyear)
            Case False
        End Select
        '----------------------------------------------------------------------------------------------------------------
        Select Case Datos_datagrid.SelectedRows(0).Cells.Item("Fecha").Value.ToString.Length > 0
            Case True
                expediente_seleccionado.fecha = Convert.ToDateTime(Datos_datagrid.SelectedRows(0).Cells.Item("Fecha").Value.ToString).Date
            Case Else
                expediente_seleccionado.fecha = Date.Now
        End Select
        '----------------------------------------------------------------------------------------------------------------
        expediente_seleccionado.principalclaveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString
        expediente_seleccionado.Desglose_clave_principal()
        With expediente_seleccionado
            .descripcion = Datos_datagrid.SelectedRows(0).Cells.Item("Detalle").Value.ToString
        End With
    End Sub

    Private Sub Suministros_expedientes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Cargar_expedientes()
        Inicio.OBJETOFINALIZAR(Me, Me)
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Cargar_expedientes()
        Inicio.OBJETOFINALIZAR(Me, Me)
    End Sub

    Private Sub REFRESHDETALLES()
        CargarOrdenespago(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
        Select Case Selecciondetallestab.SelectedTab.Name
            Case Is = "Ordenesprovision"
                cargarordenesdeprovision(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
            Case Is = "Expedienteshijos"
                Datos_ordenprovision.DataSource = ORDENPAGO_ACTUAL.Expedientes_hijos(expediente_seleccionado.claveexpediente)
                Formatocolumnas(Datos_ordenprovision, CType(Datos_ordenprovision.DataSource, DataTable))
        End Select
    End Sub

    Private Sub Busqueda_OP_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_OP.TextChanged
        Buscar_datagrid_TIMER(Busqueda_OP, ordenprovision_datatable, Datos_ordenprovision)
    End Sub

    Private Sub Nueva_ordenprovision_boton_Click(sender As Object, e As EventArgs)
        ' ordendeprovision.Todoacero()
        ordendeprovision.ClaveExpediente = Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value
        ordendeprovision.Expediente = Datos_datagrid.SelectedRows(0).Cells.Item("EXPEDIENTE N").Value
        ordendeprovision.Iniciador = Datos_datagrid.SelectedRows(0).Cells.Item("DETALLE").Value
        Suministros_OrdenProvision.Cargarordenprovision(ordendeprovision)
        CargarOrdenespago(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
        cargarordenesdeprovision(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
        Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Cargar_expedientes(True)
        Inicio.OBJETOFINALIZAR(Me, Me)
        'Suministros_OrdenProvision.ShowDialog()
    End Sub

    Private Sub Modificar_ordenprovision_boton_Click(sender As Object, e As EventArgs)
        Contabilidad_DialogoOrdenPago.ShowDialog()
    End Sub

    Private Sub Borrar_ordenprovision_boton_Click(sender As Object, e As EventArgs)
        If Datos_ordenprovision.SelectedRows.Count > 0 Then
            Select Case MsgBox("Desea Borrar la orden de Provisión Nº" & Datos_ordenprovision.SelectedRows(0).Cells.Item("NUM.OP").Value & "?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    ordendeprovision.ClaveOrdenProvision = Datos_ordenprovision.SelectedRows(0).Cells.Item("Clave_ordenprovision").Value
                    ordendeprovision.Borrarordenprovision()
                    CargarOrdenespago(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
                    'CargarActasderecepcion(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
                    cargarordenesdeprovision(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
                    Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
                    Cargar_expedientes(True)
                    Inicio.OBJETOFINALIZAR(Me, Me)
                Case MsgBoxResult.No
            End Select
        End If
    End Sub

    Private Sub Nuevoexpediente_boton_Click(sender As Object, e As EventArgs) Handles Nuevoexpediente_boton.Click
        Dim expediente_nuevo As New Expediente
        Dialogo_Nuevoexpediente.General_cargaexpediente(expediente_nuevo, Color.Bisque)
        Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Cargar_expedientes()
        Inicio.OBJETOFINALIZAR(Me, Me)
    End Sub

    Private Sub modificar_boton_Click(sender As Object, e As EventArgs) Handles modificar_boton.Click
        Modificar()
        Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
        Cargar_expedientes()
        Inicio.OBJETOFINALIZAR(Me, Me)
    End Sub

    Private Sub Modificar()
        If Datos_datagrid.SelectedRows.Count > 0 Then
            'clave general de expediente
            Dim claveexpediente As Claveexpediente_separar
            claveexpediente.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString()
            claveexpediente.Desglose_clave(Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString())
            'Clave Expediente principal
            Dim expediente_principal As Claveexpediente_separar
            If Not IsDBNull(Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value) Then
                If Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString.Length > 5 Then
                    expediente_principal.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString()
                    expediente_principal.Desglose_clave(Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString())
                Else
                    expediente_principal.claveexpediente = "0"
                End If
            Else
                expediente_principal.claveexpediente = "0"
            End If
            'declaracion de orden de pago
            Dim ordenpago_div As String() = Divisordedosvariables(Datos_datagrid.SelectedRows(0).Cells.Item("Ordenpago").Value.ToString())
            Dim ordencargo_div As String() = Divisordedosvariables(Datos_datagrid.SelectedRows(0).Cells.Item("OrdenCargo").Value.ToString())
            With expediente_seleccionado
                .organismo = claveexpediente.organismo
                .numero = claveexpediente.numero
                .year = claveexpediente.year
                .monto = CType(Datos_datagrid.SelectedRows(0).Cells.Item("Monto").Value, Decimal)
                .fecha = CType(Datos_datagrid.SelectedRows(0).Cells.Item("Fecha").Value, Date)
                .descripcion = CType(Datos_datagrid.SelectedRows(0).Cells.Item("Detalle").Value, String)
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
                If Not IsDBNull(Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value) And Datos_datagrid.SelectedRows(0).Cells.Item("ClaveExpteprincipal").Value.ToString.Length > 8 Then
                    .tieneprincipal = True
                Else
                    .tieneprincipal = False
                End If
                .cuentaespecial = Datos_datagrid.SelectedRows(0).Cells.Item("Cuenta_especial").Value.ToString
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
            Dialogo_Nuevoexpediente.General_cargaexpediente(expediente_seleccionado, Color.Bisque)
            '
            ' General_nuevoexpediente.ShowDialog()
        Else
            MessageBox.Show("No se encuentra seleccionado ningún expediente")
        End If
    End Sub

    Private Sub Botoneliminar_Click(sender As Object, e As EventArgs) Handles Botoneliminar.Click
        Select Case Datos_datagrid.SelectedRows.Count
            Case > 0
                Select Case Inicio.Verificacionasociacionpedidofondo(Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                    Case = ""
                        Select Case MsgBox("Confirma que desea BORRAR este Expediente Nº" & Datos_datagrid.SelectedRows(0).Cells.Item("Expediente N").Value, MsgBoxStyle.YesNoCancel, " ")
                            Case MsgBoxResult.Yes
                                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString)
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `expediente` WHERE (Clave_expediente=@Clave_expediente)"
                                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                                Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
                                Cargar_expedientes()
                                Inicio.OBJETOFINALIZAR(Me, Me)
                        End Select
                    Case Else
                        MsgBox(Inicio.Verificacionasociacionpedidofondo(Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString), MsgBoxStyle.OkOnly, "ADVERTENCIA EXPEDIENTE ASOCIADO A PEDIDO DE FONDO")
                End Select
                Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
                Cargar_expedientes()
                Inicio.OBJETOFINALIZAR(Me, Me)
            Case = 0
                MessageBox.Show("Debe seleccionar un expediente para borrar")
        End Select
    End Sub

    Private Sub Refresh_op_Click(sender As Object, e As EventArgs) Handles Refresh_op.Click
    End Sub

    Private Sub Contabilidad_expedientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Paneldatosexpedientes_Paint(sender As Object, e As PaintEventArgs) Handles Paneldatosexpedientes.Paint
    End Sub

    Private Sub nuevaordendepago()
        Dim Clase_ordenpago As String = ""
        Dim tabla_temporal As New DataTable
        With tabla_temporal
            With .Columns
                .Add("TIPO")
                .Add("Descripción")
            End With
            With .Rows
                .Add("PAGO", " ORDEN PARA PAGO DE PROVEEDORES DE BIENES Y SERVICIOS ")
                '.Add("PAGO MULTIPLES EFECTORES", " ORDEN PARA PAGO DE UN PROVEEDOR Y MULTIPLES EFECTORES. ")
                .Add("ARANCELAMIENTO", " RENDICIÓN CUENTA DE ARANCELAMIENTO  ")
                .Add("RECONOCIMIENTO", " ORDEN DE RECONOCIMIENTO DE GASTOS  ")
                .Add("RECONOCIMIENTO Y REAPROPIACIÓN", "   ")
                .Add("REDETERMINACIÓN", " ORDEN DE REDETERMINACIÓN DE COSTOS  ")
                .Add("VIÁTICOS", " ORDEN PARA PAGO DE VIATICOS ")
                .Add("PUBLICIDAD", " ORDEN PARA PAGO DE PUBLICIDAD ")
                .Add("CONTRATOS", " ORDEN DE PAGO DE CONTRATOS DE PERSONAL")
                .Add("BECAS", " ORDEN DE PAGO DE CONTRATOS DE PERSONAL")
                .Add("COMISIÓN BANCARIA", "COMISIÓN BANCARIA ASOCIADA BANCO MACRO")
                .Add("REPOSICIÓN", "*ORDEN DE REPOSICIÓN DE FONDOS PERMANENTES")
                .Add("HABERES", " ORDEN DE PAGO PARA HABERES ")
                .Add("TRANSFERENCIA", " ORDEN DE PAGO PARA REALIZAR TRANSFERENCIAS")
                .Add("RENDICIÓN", " ORDEN DE RENDICIÓN ")
                .Add("RENDICIÓN PARCIAL", " ORDEN DE RENDICIÓN PARCIAL ")
                .Add("RENDICIÓN FINAL", " ORDEN DE RENDICIÓN FINAL ")
            End With
        End With
        DialogDialogo_Datagridview.Carga_General(tabla_temporal, "Seleccione el tipo de ORDEN DE PAGO", "Seleccionar", "Cancelar", 9)
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Clase_ordenpago = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
            Dim ORDENPAGO As New Ordendepago
            ORDENPAGO.ordenpago_numero = ORDENPAGO.AGREGARMAXIMO_ordenpago(Autorizaciones.Year)
            ORDENPAGO.Ordenpago_Year = Autorizaciones.Year
            ORDENPAGO.Clave_ordenpago = CType(Autorizaciones.Year & Autorizaciones.Organismo & ORDENPAGO.ordenpago_numero.ToString("00000"), Long)
            ORDENPAGO.expediente_op.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value
            ORDENPAGO.expediente_op.Cargar_expediente(ORDENPAGO.expediente_op.claveexpediente)
            ORDENPAGO.ordenpago_USUARIO = Autorizaciones.Usuario.Rows(0).Item("USUARIO")
            ORDENPAGO.Ordenpago_tipo = Clase_ordenpago
            ORDENPAGO.ordenpago_fecha = Date.Now
            ORDENPAGO.ordenpago_montototal = 0
            ORDENPAGO.ordenpago_Detalle = ""
            ORDENPAGO.ESTADO = "ACTIVO"
            Select Case Autorizaciones.Year > ORDENPAGO.expediente_op.year
                Case True
                    ORDENPAGO.CLASE_FONDO = "RESIDUOS PASIVOS/" & ORDENPAGO.expediente_op.year
                Case False
                    ORDENPAGO.CLASE_FONDO = "EJERCICIO"
            End Select
            ORDENPAGO.HABERES_DETALLE = ORDENPAGO.Cargar_Haberes_Estructura_detalles(ORDENPAGO.Clave_ordenpago)
            'REALIZA LA SELECCIÓN DEL CUADRO DE DIALOGO
            Tipoordenpago(ORDENPAGO, True)
        Else
            MessageBox.Show("NO se creará una nueva Orden de Pago")
            Exit Sub
        End If
    End Sub

    Private Sub Nueva_ordenpago_boton_Click(sender As Object, e As EventArgs) Handles Nueva_ordenpago_boton.Click
        If Datos_datagrid.SelectedRows.Count = 1 Then
            nuevaordendepago()
            REFRESHDETALLES()
        Else
            MessageBox.Show("Debe seleccionar 1 (un) Expediente")
        End If
    End Sub

    Private Sub Tipoordenpago(ByVal ORDENPAGO As Ordendepago, Optional ByVal nuevo As Boolean = False)
        'If nuevo Then
        '    ORDENPAGO.Insertar_ordenpago()
        'End If
        Select Case ORDENPAGO.Ordenpago_tipo.ToUpper
            Case Is = "ARANCELAMIENTO"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "HABERES"
                Contabilidad_DialogoHaberes.Cargadedatos(ORDENPAGO, nuevo)
            Case Is = "PAGO"
                Contabilidad_DialogoOrdenPago.Cargardatosamodificar(ORDENPAGO, nuevo)
            'Case Is = "PAGO MULTIPLES EFECTORES"
            '    Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "TRANSFERENCIA"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "RENDICIÓN"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "RENDICIÓN FINAL"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "REDETERMINACIÓN"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "RENDICIÓN PARCIAL"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "RECONOCIMIENTO"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "VIÁTICOS"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "PUBLICIDAD"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "REPOSICIÓN"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "CONTRATOS"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "BECAS"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
            Case Is = "COMISIÓN BANCARIA"
                Contabilidad_DialogoOrdenpago_multiple.Cargardatosamodificar(ORDENPAGO, nuevo)
        End Select
    End Sub

    Private Sub Modificar_ordenpago_boton_Click(sender As Object, e As EventArgs) Handles Modificar_ordenpago_boton.Click
        If Datos_ordenpago.SelectedRows.Count = 1 Then
            Dim ORDENPAGO As New Ordendepago
            ORDENPAGO.Clave_ordenpago = Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value
            ORDENPAGO.expediente_op.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value
            ORDENPAGO.cargar_ordepago(Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value)
            ORDENPAGO.SINACTAS_DATATABLE = SINACTARECEPCION.Estructura_SeleccionSINACTARECEPCION(ORDENPAGO.Clave_ordenpago)
            ORDENPAGO.Datatable_a_SINACTAS(ORDENPAGO.SINACTAS_DATATABLE)
            Tipoordenpago(ORDENPAGO)
            REFRESHDETALLES()
        Else
        End If
    End Sub

    Private Sub Borrar_ordenpago_boton_Click(sender As Object, e As EventArgs) Handles Borrar_ordenpago_boton.Click
        If Datos_ordenpago.SelectedRows.Count > 0 Then
            Dim ORDENPAGO As New Ordendepago
            Select Case MsgBox("Desea Borrar la orden de PAGO Nº" & Datos_ordenpago.SelectedRows(0).Cells.Item("NUM.OP").Value & "?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    ORDENPAGO_ACTUAL.Clave_ordenpago = Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value
                    ORDENPAGO_ACTUAL.Borrar_ORDENPAGO()
                    Inicio.OBJETOCARGANDO(Me, Me, "Por favor espere," & vbCrLf & " tomara unos segundos...")
                    Cargar_expedientes(True)
                    Inicio.OBJETOFINALIZAR(Me, Me)
                    REFRESHDETALLES()
                Case MsgBoxResult.No
            End Select
        End If
    End Sub

    Private Sub Datos_ordenpago_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenpago.CellEnter
        If Datos_ordenpago.SelectedRows.Count = 1 Then
            ' Dim ORDENPAGO As New Ordendepago
            Modificar_ordenpago_boton.Visible = True
            IMPRIMIR_BOTON.Visible = True
            Borrar_ordenpago_boton.Visible = True
            If Not IsNothing(ORDENPAGO_ACTUAL.Clave_ordenpago) Then
                If Not ORDENPAGO_ACTUAL.Clave_ordenpago = Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value Then
                    ORDENPAGO_ACTUAL.Clave_ordenpago = Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value
                    ORDENPAGO_ACTUAL.expediente_op.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value
                    ORDENPAGO_ACTUAL.cargar_ordepago(Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value)
                    'Tipoordenpago(ORDENPAGO_ACTUAL)
                End If
            End If
        Else
            Modificar_ordenpago_boton.Visible = False
            IMPRIMIR_BOTON.Visible = False
            Borrar_ordenpago_boton.Visible = False
        End If
    End Sub

    Private Sub Datos_datagrid_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_datagrid.MouseUp, Datos_ordenpago.MouseUp, Datos_ordenprovision.MouseUp
        Inicio.MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub IMPRIMIR_BOTON_Click(sender As Object, e As EventArgs) Handles IMPRIMIR_BOTON.Click
        If Datos_ordenpago.SelectedRows.Count > 0 Then
            Dim ORDENPAGO As New Ordendepago
            For x = 0 To Datos_ordenpago.SelectedRows.Count - 1
                ORDENPAGO = New Ordendepago
                ORDENPAGO.Clave_ordenpago = Datos_ordenpago.SelectedRows(0).Cells.Item("clave_Ordenpago").Value
                ORDENPAGO.expediente_op.claveexpediente = Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value
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
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "HABERES"
                'PDF_ORDENPAGO_HABERES(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_HABERESv2(ORDENPAGO)
                'Contabilidad_DialogoHaberes.Cargadedatos(ORDENPAGO)
            Case Is = "PAGO"
                'PDF_ORDENPAGO_Pago(ORDENPAGO) 'PDF_ORDENPAGO_Pago(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_PagoV2(ORDENPAGO)
            Case Is = "TRANSFERENCIA"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
                'Contabilidad_DialogoOrdenPago.Cargardatosamodificar(ORDENPAGO)
            'Case Is = "PAGO MULTIPLES EFECTORES"
            '    PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "REDETERMINACIÓN"
                ' PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "RENDICIÓN"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "RENDICIÓN FINAL"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "RENDICIÓN PARCIAL"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "RECONOCIMIENTO"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "VIÁTICOS"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "PUBLICIDAD"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "REPOSICIÓN"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "CONTRATOS"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "BECAS"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
            Case Is = "COMISIÓN BANCARIA"
                'PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dialogo_impresion.Show()
    End Sub

    Private Sub BotonOProv_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Selecciondetallestab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Selecciondetallestab.SelectedIndexChanged
        Dim tabPageItem As TabPage = Selecciondetallestab.SelectedTab
        Select Case tabPageItem.Controls.Contains(Datos_ordenprovision)
            Case True
            Case False
                Datos_ordenprovision.Parent = tabPageItem
                Select Case Selecciondetallestab.SelectedTab.Name
                    Case Is = "Ordenesprovision"
                        cargarordenesdeprovision(Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
                    Case Is = "Expedienteshijos"
                        Datos_ordenprovision.DataSource = ORDENPAGO_ACTUAL.Expedientes_hijos(expediente_seleccionado.claveexpediente)
                        Formatocolumnas(Datos_ordenprovision, CType(Datos_ordenprovision.DataSource, DataTable))
                End Select
        End Select
    End Sub

End Class