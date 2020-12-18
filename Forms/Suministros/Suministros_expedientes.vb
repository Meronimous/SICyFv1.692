Public Class Suministros_expedientes
    Dim Expedientes_datatable As New DataTable
    Dim ordenprovision_datatable As New DataTable
    Dim filadatatable As New DataTable
    Dim ordendeprovision As New OrdenProvision
    Dim expediente_seleccionado As New Expediente
    Dim impresionpagina As New Impresion

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(Busqueda_textbox, Expedientes_datatable, Datos_datagrid)
    End Sub

    ''' <summary>
    ''' Utilizado para Cargar o recargar los datos de los expedientes en forma general
    ''' </summary>
    ''' <param name="parcial"> Define si la actualización es completa o solamente la fila seleccionada</param>
    Private Sub Cargar_expedientes(Optional parcial As Boolean = False)
        Dim BUSQUEDATEXT = Busqueda_textbox.Text
        Busqueda_textbox.Text = ""
        Dim consultasql As String = "Select
GROUP_CONCAT(`Orden_provision_N`) as 'O.P.',
`Expediente N`,
FECHA,
DETALLE,
MONTO,
GROUP_CONCAT(distinct Destino) as Destino,sum(TOTAL) AS 'Total acumulado O.P.',
GROUP_CONCAT(distinct INICIADOR) as INICIADOR,GROUP_CONCAT(distinct proveedor) as Proveedores,
EXP.CLAVE_EXPEDIENTE,clave_ordenprovision,Clave_pedidofondo,cuenta_especial,
ClaveExpteprincipal,
Ordenpago,
OrdenCargo,Tipo_origen as 'Forma'
from
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
 concat(cast(Substring(clave_ordenprovision From 9 for 5)AS UNSIGNED),'/',Substring(clave_ordenprovision From 1 for 4)) as 'Orden_provision_N',
total,destino,iniciador,clave_ordenprovision,clave_expediente,CUIT,Tipo_origen
 from suministros_orden_provision)ordprov
on exp.clave_expediente=ordprov.clave_expediente
LEFT join
(Select
  proveedor ,cuit
  from proveedores)provv
on provv.cuit=ordprov.CUIT
group by `Expediente N`
order by Clave_ordenprovision desc"
        If Not parcial Then
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, Expedientes_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Datos_datagrid.DataSource = Expedientes_datatable
        Else
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
            consultasql = "Select GROUP_CONCAT(`Orden_provision_N`) as 'O.P.',`Expediente N`,FECHA,DETALLE,MONTO,GROUP_CONCAT(distinct Destino) as Destino,sum(TOTAL) AS 'Total acumulado O.P.',
GROUP_CONCAT(distinct INICIADOR) as INICIADOR,GROUP_CONCAT(distinct proveedor) as Proveedores,
EXP.CLAVE_EXPEDIENTE,clave_ordenprovision,Clave_pedidofondo,cuenta_especial,
	ClaveExpteprincipal,
	Ordenpago,
	OrdenCargo,
tipo_origen as 'Forma'
from
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
	Expediente WHERE clave_expediente=@clave_expediente order by FECHA desc )exp
LEFT join
(Select
 concat(cast(Substring(clave_ordenprovision From 9 for 5)AS UNSIGNED),'/',Substring(clave_ordenprovision From 1 for 4)) as 'Orden_provision_N',
total,destino,iniciador,clave_ordenprovision,clave_expediente,CUIT,tipo_origen
 from suministros_orden_provision)ordprov
on exp.clave_expediente=ordprov.clave_expediente
LEFT join
(Select
  proveedor ,cuit
  from proveedores)provv
on provv.cuit=ordprov.CUIT
group by `Expediente N`
order by Clave_ordenprovision desc"
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, filadatatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
            If filadatatable.Rows.Count > 0 Then
                For x = 0 To Datos_datagrid.Columns.Count - 1
                    Datos_datagrid.SelectedRows(0).Cells.Item(x).Value = filadatatable.Rows(0).Item(x)
                Next
            End If
        End If
        With Datos_datagrid
            .Columns("O.P.").DefaultCellStyle.Font = New Font(Datos_datagrid.DefaultCellStyle.Font.Name, Datos_datagrid.DefaultCellStyle.Font.Size + 4, FontStyle.Bold)
            .Columns("O.P.").DefaultCellStyle.BackColor = Color.White
            .Columns("O.P.").DefaultCellStyle.ForeColor = Color.Blue
        End With
        Datos_datagrid.Columns("Total acumulado O.P.").DefaultCellStyle.Format = "C"
        Datos_datagrid.Columns("clave_expediente").Visible = False
        Datos_datagrid.Columns("clave_ordenprovision").Visible = False
        Datos_datagrid.Columns("Clave_pedidofondo").Visible = False
        Datos_datagrid.Columns("ClaveExpteprincipal").Visible = False
        Datos_datagrid.Columns("Ordenpago").Visible = False
        Datos_datagrid.Columns("OrdenCargo").Visible = False
        ' Formatocolumnas(Datos_datagrid, CType(Datos_datagrid.DataSource, DataTable))
        Busqueda_textbox.Text = BUSQUEDATEXT
    End Sub

    Private Sub cargarordenesdeprovision()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value)
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
Fechaconfeccionada_ordenprovision,
Estado
from suministros_orden_provision where Clave_expediente=@clave_expediente"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, ordenprovision_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_ordenprovision.DataSource = ordenprovision_datatable
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
        Datos_ordenprovision.Columns("Estado").Visible = True
    End Sub

    Private Sub CargarOrdenProvision()
        Suministros_OrdenProvision.Todoacero()
        Suministros_OrdenProvision.OrdenProvision.ClaveExpediente = Datos_datagrid.SelectedRows(0).Cells.Item("EXPEDIENTE N").Value
        Suministros_OrdenProvision.OrdenProvision.Iniciador = Datos_datagrid.SelectedRows(0).Cells.Item("INICIADOR").Value
        Mostrardialogo(Suministros_OrdenProvision)
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
        'Inicio.Divisordecodigo(Datos_datagrid.SelectedRows(0).Cells.Item("Claveexpteprincipal").Value.ToString, expediente_seleccionado.principalorganismo, expediente_seleccionado.principalnumero, expediente_seleccionado.principalyear)
        expediente_seleccionado.Desglose_clave_principal()
        With expediente_seleccionado
            .descripcion = Datos_datagrid.SelectedRows(0).Cells.Item("Detalle").Value.ToString
        End With
    End Sub

    Private Sub Suministros_expedientes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Cargar_expedientes()
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        Cargar_expedientes()
    End Sub

    Private Sub Datos_datagrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_datagrid.CellEnter
        If Datos_datagrid.SelectedRows.Count > 0 Then
            Paneldatosexpedientes.Visible = True
            Cargadedatos()
            cargarordenesdeprovision()
        Else
            Paneldatosexpedientes.Visible = False
        End If
    End Sub

    Private Sub Busqueda_OP_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_OP.TextChanged
        Buscar_datagrid_TIMER(Busqueda_OP, ordenprovision_datatable, Datos_ordenprovision)
    End Sub

    Private Sub Nueva_ordenprovision_boton_Click(sender As Object, e As EventArgs) Handles Nueva_ordenprovision_boton.Click
        ' ordendeprovision.Todoacero()
        ordendeprovision.ClaveExpediente = Datos_datagrid.SelectedRows(0).Cells.Item("clave_expediente").Value
        ordendeprovision.Expediente = Datos_datagrid.SelectedRows(0).Cells.Item("EXPEDIENTE N").Value
        ordendeprovision.Iniciador = Datos_datagrid.SelectedRows(0).Cells.Item("DETALLE").Value
        'Mostrardialogo(Suministros_OrdenProvision)
        Suministros_OrdenProvision.Cargarordenprovision(ordendeprovision)
        cargarordenesdeprovision()
        Cargar_expedientes(True)
        'Suministros_OrdenProvision.ShowDialog()
    End Sub

    Private Sub Modificar_ordenprovision_boton_Click(sender As Object, e As EventArgs) Handles Modificar_ordenprovision_boton.Click
        If Datos_ordenprovision.SelectedRows.Count > 0 Then
            ordendeprovision.ClaveOrdenProvision = Datos_ordenprovision.SelectedRows(0).Cells.Item("Clave_ordenprovision").Value
            ordendeprovision.cargar_OP(ordendeprovision.ClaveOrdenProvision)
            Suministros_OrdenProvision.Cargardatosamodificar(ordendeprovision)
            cargarordenesdeprovision()
            Cargar_expedientes(True)
        End If
    End Sub

    Private Sub Borrar_ordenprovision_boton_Click(sender As Object, e As EventArgs) Handles Borrar_ordenprovision_boton.Click
        If Datos_ordenprovision.SelectedRows.Count > 0 Then
            Select Case MsgBox("Desea Borrar la orden de Provisión Nº" & Datos_ordenprovision.SelectedRows(0).Cells.Item("NUM.OP").Value & "?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    ordendeprovision.ClaveOrdenProvision = Datos_ordenprovision.SelectedRows(0).Cells.Item("Clave_ordenprovision").Value
                    ordendeprovision.Borrarordenprovision()
                    cargarordenesdeprovision()
                    Cargar_expedientes(True)
                Case MsgBoxResult.No
            End Select
        End If
    End Sub

    Private Sub Datos_ordenprovision_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenprovision.CellEnter
    End Sub

    Private Sub Nuevoexpediente_boton_Click(sender As Object, e As EventArgs) Handles Nuevoexpediente_boton.Click
        Dim expediente_nuevo As New Expediente
        Dialogo_Nuevoexpediente.General_cargaexpediente(expediente_nuevo, Color.Bisque)
        Cargar_expedientes()
    End Sub

    Private Sub modificar_boton_Click(sender As Object, e As EventArgs) Handles modificar_boton.Click
        Modificar()
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
                                Cargar_expedientes()
                        End Select
                    Case Else
                        MsgBox(Inicio.Verificacionasociacionpedidofondo(Datos_datagrid.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString), MsgBoxStyle.OkOnly, "ADVERTENCIA EXPEDIENTE ASOCIADO A PEDIDO DE FONDO")
                End Select
            Case = 0
                MessageBox.Show("Debe seleccionar un expediente para borrar")
        End Select
    End Sub

    Private Sub Refresh_op_Click(sender As Object, e As EventArgs) Handles Refresh_op.Click
    End Sub

    Private Sub IMPRIMIR_BOTON_Click(sender As Object, e As EventArgs) Handles IMPRIMIR_BOTON.Click
        If Datos_ordenprovision.SelectedRows.Count > 0 Then
            ordendeprovision.ClaveOrdenProvision = Datos_ordenprovision.SelectedRows(0).Cells.Item("Clave_ordenprovision").Value
            ordendeprovision.cargar_OP(ordendeprovision.ClaveOrdenProvision)
            '  Suministros_OrdenProvision.Cargardatosamodificar(ordendeprovision)
            '    cargarordenesdeprovision()
            ' PDF_ordenProvision(ordendeprovision, "LEGAL", 8, 8)
            PDF_ordenProvisionv2(ordendeprovision)
            Cargar_expedientes(True)
        End If
    End Sub

    Private Sub Suministros_expedientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

End Class