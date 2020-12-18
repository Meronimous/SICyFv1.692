Public Class Direccion_reportes
    Dim reportes_datatables As New DataTable
    Dim Datatable_general As New DataTable
    Dim Datatable_detallado As New DataTable

    Private Sub Direccion_reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With reportes_datatables
            With .Columns
                .Add("Tipo reporte")
                .Add("Descripción")
            End With
            With .Rows
                .Add("Expedientes", "Listado de Expedientes con movimientos dentro  del período seleccionado")
                .Add("Transferencias", "Transferencias realizada por Tesorería dentro del período seleccionado")
                .Add("Pagos_Registrados", "Pagos registrados dentro del período seleccionado")
                .Add("Proveedores", "Proveedores con movimientos dentro del período seleccionado")
                .Add("PEDIDOS_FONDO", "Pedidos de Fondos dentro del período seleccionado ")
                .Add("PEDIDOS_FONDOMFyV", "MFyV Pedidos de Fondos dentro del período seleccionado ")
                .Add("EXPEDIENTESMFYV", "Listado de Expedientes mfyv")
                .Add("pendiente...", "pendiente...")
                .Add("pendiente...", "pendiente...")
            End With
        End With
    End Sub

    Private Sub Seleccionarcuenta_boton_Click(sender As Object, e As EventArgs) Handles Seleccionarcuenta_boton.Click
        DialogDialogo_Datagridview.Carga_General(reportes_datatables, "Seleccione el tipo de reporte a visualizar", "Tipo de reporte", "Cancelar")
        '  Dialogo_listbox.Cargalistboxgeneral(listadecuentasbancarias, "Seleccione la cuenta a ser asignada", "Asignar Cuenta Especial", "Borrar asignación")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            'Tipo de reporte seleccionado
            Label_Tiporeporte.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
            refresh_a_0()
        Else
            Label_Tiporeporte.Text = ""
        End If
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        refreshreporte()
    End Sub

    Private Sub Desde_monthcalendarA_ValueChanged(sender As Object, e As EventArgs) Handles Desde_monthcalendarA.ValueChanged
        refresh_a_0()
    End Sub

    Private Sub Hasta_monthcalendarA_ValueChanged(sender As Object, e As EventArgs) Handles Hasta_monthcalendarA.ValueChanged
        refresh_a_0()
    End Sub

    Private Sub Generar_reporte_Click(sender As Object, e As EventArgs) Handles Generar_reporte.Click
        Inicio.OBJETOCARGANDO(Splitcontainer_Datos, Me, "Cargando Reporte...")
        refreshreporte()
        Inicio.OBJETOFINALIZAR(Splitcontainer_Datos, Me)
    End Sub

    Private Sub refreshreporte()
        COMMANDSQL.Parameters.Clear()
        COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
        Select Case Label_Tiporeporte.Text.ToUpper
            Case Is = "EXPEDIENTES"
                Expedientes_refresh()
            Case Is = "EXPEDIENTESMFYV"
                Expedientes_refresh()
            Case Is = "TRANSFERENCIAS"
                Transferencias_refresh()
            Case Is = "PAGOS_REGISTRADOS"
                Pagos_Registrados_refresh()
            Case Is = "PROVEEDORES"
                Proveedores_refresh()
            Case Is = "PEDIDOS_FONDO"
                PEDIDOS_FONDO_refresh()
            Case Is = "PEDIDOS_FONDOMFYV"
                PEDIDOS_FONDOMFyv_refresh()
            Case Else
                COMMANDSQL.Parameters.Clear()
                MessageBox.Show("No ha seleccionado ninguna vista de información ")
        End Select
    End Sub

    Private Sub refresh_a_0()
        Datagrid_General.DataSource = Nothing
        Datagrid_Detalles.DataSource = Nothing
    End Sub

    Private Sub Buscador_general_TextChanged(sender As Object, e As EventArgs) Handles Buscador_general.TextChanged
        Buscar_datagrid_TIMER(sender, Datatable_general, Datagrid_General)
    End Sub

    Private Sub Buscador_detallado_TextChanged(sender As Object, e As EventArgs) Handles Buscador_detallado.TextChanged
        Buscar_datagrid_TIMER(sender, Datatable_detallado, Datagrid_Detalles)
    End Sub

    Private Sub Expedientes_refresh()
        Inicio.SQLPARAMETROS(Organismotabla, "
SELECT expediente,
CASE WHEN isnull(Monto) then 'VERIFICAR VERIFICAR' else detalle end as 'Detalle',
`Ped.Fondo`,
Fecha_pedido as 'Fecha Ped.Fondo',
  Ingresos,
  Egresos,
(Retenciones) as 'Retenciones pendientes de pago',
descripcion,
clave_expediente,
((ingresos)- ((egresos)+(retenciones))) as diferencia,
sum(total_recibo) as total_recibo,
CASE WHEN isnull(Monto) then 0 else monto end as 'Total de expediente',
Clave_pedidofondo,
Monto_pedidofondo as 'TG. Solicitado Ped.Fondo', Fecha_pedido,
saldo as 'TG. Saldo Ped.Fondo',
GROUP_CONCAT(DISTINCT PROVEEDOR)  AS 'Proveedores',
GROUP_CONCAT(DISTINCT cuit)  AS 'CUIT'
FROM
(
select expediente,CLAVE_TO_NUMEROYANIO(Exped.clave_pedidofondo)  as 'Ped.Fondo',
exped.detalle,
INGRESOS,EGRESOS,RETENCIONES,
recibos.monto as total_recibo,
cuenta.descripcion,
SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13) as clave_expediente,
exped.monto,
Pedfondo.Clave_pedidofondo,
TGral.Saldo,
TGral.Monto_pedidofondo,
TGral.Fecha_pedido,
proveedores.Proveedor, proveedores.cuit
FROM
(SELECT
CONCAT(Substring(x.clave_expedientE_Detalle From 5 for 4),'-',cast(Substring(x.clave_expedientE_Detalle From 9 for 5)AS UNSIGNED),'/',Substring(x.clave_expedientE_Detalle From 1 for 4)) as Expediente,
clave_expediente_Detalle
 FROM
(select clave_expediente_Detalle from expediente_Detalle where (CodInp=1 or codinp=3) and date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
 )x
group by SUBSTRING(x.clave_expedientE_Detalle FROM 1 FOR 13)
 )AA
LeFT JOIN
/* Ingresos, Egresos y Retenciones agrupados por expedientes, se compone de 3 union all y un agrupador*/
(Select SUM(INGRESOS) AS INGRESOS,SUM(EGRESOS) AS EGRESOS,SUM(RETENCIONES) AS RETENCIONES,Clave_expediente_detalle from (
select clave_expedientE_Detalle,0 as ingresos,sum(monto) as egresos,0 as retenciones,codinp from expediente_Detalle where CodInp=1
group by  SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
union ALL
select clave_expedientE_Detalle,sum(monto) as ingresos,0 as egresos,0 as retenciones,codinp from expediente_Detalle where CodInp=3
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
union ALL
select clave_expedientE_Detalle,0 as ingresos,0 as egresos,sum(monto_retenido) as retenciones,1 as codinp from Retenciones where isnull(Retencion_Clave_detalle)
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
)INGRESOSEGRESOS
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
)BB
ON SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=SUBSTRING(bb.clave_expedientE_Detalle FROM 1 FOR 13)
LEFT JOIN
(select * from expediente)Exped
on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=Exped.Clave_expediente
LEFT JOIN
(select * from expediente_Detalle where not isnull(nro_recibo) and nro_recibo<>'')recibos
on recibos.clave_expedientE_Detalle=aa.clave_expedientE_Detalle
LEFT JOIN
(SELECT CUIT,MONTO,Clave_expediente,rubro FROM cuit_expediente )cuitexpes
on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)= cuitexpes.Clave_expediente
LEFT JOIN
(Select Proveedor,CUIT,NUMERO,NOMBREFANTASIA from proveedores) Proveedores ON
cuitexpes.CUIT=proveedores.CUIT
LEFT JOIN
(select * from pedido_fondos)Pedfondo
on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
LEFT JOIN
(select * from pedido_fondos_tg)TGral
on Pedfondo.clave_pedidofondo=TGral.clave_pedidofondo
LEFT JOIN
(select * From Cuenta_Bancaria)Cuenta
on Pedfondo.cuenta_pedidofondo=Cuenta.cuenta)dd
group by clave_expediente
order by clave_pedidofondo desc,clave_expediente,descripcion
", Datatable_general, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_General.DataSource = Nothing
        Datagrid_General.DataSource = Datatable_general
        Formatocolumnas(Datagrid_General, Datatable_general)
        'Datagrid_General.Columns("clave_expediente").Visible = False
        'Datagrid_General.Columns("INGRESOS").DefaultCellStyle.Format = "c"
        'Datagrid_General.Columns("EGRESOS").DefaultCellStyle.Format = "c"
        'Datagrid_General.Columns("Retenciones pendientes de pago").DefaultCellStyle.Format = "c"
        'Datagrid_General.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        'Datagrid_General.Columns("Total de expediente").DefaultCellStyle.Format = "c"
        Datagrid_General.CurrentCell = Nothing
    End Sub

    Private Sub Transferencias_refresh()
        Inicio.SQLPARAMETROS(Organismotabla, "
select Nrotransferencia,Fechadelmovimiento as FECHA,
INGRESOS,EGRESOS,
CONCAT(cast(Substring(Exped.clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Exped.clave_pedidofondo From 1 for 4)) as 'Ped.Fondo',
cuenta.descripcion,
SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13) as clave_expediente
FROM
(SELECT
CONCAT(Substring(clave_expedientE_Detalle From 5 for 4),'-',cast(Substring(clave_expedientE_Detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expedientE_Detalle From 1 for 4)) as Expediente,
sum(ingresos) as Ingresos,
sum(egresos) as Egresos,
clave_expediente_Detalle,
Nrotransferencia,Fechadelmovimiento
 FROM
(
select clave_expedientE_Detalle,sum(monto) as ingresos,0 as egresos,codinp,Nrotransferencia,Fechadelmovimiento  from expediente_Detalle where CodInp=3 and DATE(Creado_o_modificado) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
)a
group by Nrotransferencia)AA
LEFT JOIN
(select * from expediente)Exped
on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=Exped.Clave_expediente
LEFT JOIN
(select * from pedido_fondos)Pedfondo
on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
LEFT JOIN
(select * From Cuenta_Bancaria)Cuenta
on Pedfondo.cuenta_pedidofondo=Cuenta.cuenta
order by clave_expediente_Detalle
", Datatable_general, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_General.DataSource = Nothing
        Datagrid_General.DataSource = Datatable_general
        Datagrid_General.Columns("clave_expediente").Visible = False
        Datagrid_General.Columns("INGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("EGRESOS").DefaultCellStyle.Format = "c"
        ' Datagrid_General.Columns("RETENCIONES").DefaultCellStyle.Format = "c"
        'Datagrid_General.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        '     Datagrid_General.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        Datagrid_General.CurrentCell = Nothing
    End Sub

    Private Sub Pagos_Registrados_refresh()
        Inicio.SQLPARAMETROS(Organismotabla, "
select Nrotransferencia,Fechadelmovimiento as FECHA,
INGRESOS,EGRESOS,
CONCAT(cast(Substring(Exped.clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Exped.clave_pedidofondo From 1 for 4)) as 'Ped.Fondo',
cuenta.descripcion,
SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13) as clave_expediente
FROM
(SELECT
CONCAT(Substring(clave_expedientE_Detalle From 5 for 4),'-',cast(Substring(clave_expedientE_Detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expedientE_Detalle From 1 for 4)) as Expediente,
sum(ingresos) as Ingresos,
sum(egresos) as Egresos,
clave_expediente_Detalle,
Nrotransferencia,Fechadelmovimiento
 FROM
(
select clave_expedientE_Detalle,0 as ingresos,sum(monto) as egresos,codinp,Nrotransferencia,Fechadelmovimiento  from expediente_Detalle where CodInp=1 and DATE(Creado_o_modificado) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
)a
group by Nrotransferencia)AA
LEFT JOIN
(select * from expediente)Exped
on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=Exped.Clave_expediente
LEFT JOIN
(select * from pedido_fondos)Pedfondo
on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
LEFT JOIN
(select * From Cuenta_Bancaria)Cuenta
on Pedfondo.cuenta_pedidofondo=Cuenta.cuenta
order by clave_expediente_Detalle
", Datatable_general, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_General.DataSource = Nothing
        Datagrid_General.DataSource = Datatable_general
        Datagrid_General.Columns("clave_expediente").Visible = False
        Datagrid_General.Columns("INGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("EGRESOS").DefaultCellStyle.Format = "c"
        '      Datagrid_General.Columns("RETENCIONES").DefaultCellStyle.Format = "c"
        ' Datagrid_General.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        Datagrid_General.CurrentCell = Nothing
    End Sub

    Private Sub Proveedores_refresh()
        Inicio.SQLPARAMETROS(Organismotabla, "
select
prov.proveedor,aa.CUIT,
CONCAT(cast(Substring(Exped.clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Exped.clave_pedidofondo From 1 for 4)) as 'Ped.Fondo',
sum(INGRESOS) as INGRESOS,
sum(EGRESOS) as EGRESOS,
CASE WHEN ISNULL(RETENCIONES) THEN 0 ELSE RETENCIONES END AS 'RETENCIONES',
sum(pagado) as 'Pagos realizados',
(sum(INGRESOS)-(sum(EGRESOS)+CASE WHEN ISNULL(RETENCIONES) THEN 0 ELSE RETENCIONES END)) AS DIFERENCIA,
group_concat( distinct Expediente) as Expedientes
FROM
(SELECT
sum(ingresos) as Ingresos,
sum(egresos) as Egresos,
(pagado) as 'pagado',
clave_expediente_Detalle,cuit
 FROM
(select clave_expedientE_Detalle,0 as ingresos,sum(monto) as egresos,codinp,cuit,count(monto) as 'pagado' from expediente_Detalle where CodInp=1 and date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
and not (cuit like '%999999-9%' or cuit='  -        -' or Cuit='')
group by cuit,SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
union ALL
select clave_expedientE_Detalle,sum(monto) as ingresos,0 as egresos,codinp,cuit,count(monto) as 'pagado' from expediente_Detalle where CodInp=3 and DATE(Creado_o_modificado) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
and not (cuit like '%999999-9%' or cuit='  -        -' or Cuit='')
group by CUIT,SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
)a
group by CUIT,SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
)aa
LEFT JOIN
(select * from
(
select clave_expediente,
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente,
clave_pedidofondo from expediente
UNION ALL
select clave_expediente,
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente,
clave_pedidofondo from cuit_movimiento group by clave_expediente)expedint
group by clave_expediente,Clave_pedidofondo
)Exped
on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=Exped.Clave_expediente
LEFT JOIN
(select * from pedido_fondos)Pedfondo
on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
LEFT JOIN
(select SUM(Monto_retenido)AS 'RETENCIONES',CUIT from RETENCIONES WHERE
 date(fecha_retencion) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
GROUP BY RETENCIONES.CUIT)RETENCIONES
on RETENCIONES.CUIT=aa.cuit
LEFT JOIN
(select * from proveedores)prov
on prov.cuit=aa.cuit
group by cuit
order by Proveedor asc
", Datatable_general, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_General.DataSource = Nothing
        Datagrid_General.DataSource = Datatable_general
        '   Datagrid_General.Columns("clave_expediente").Visible = False
        Datagrid_General.Columns("INGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("EGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("RETENCIONES").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        Datagrid_General.CurrentCell = Nothing
    End Sub

    Private Sub PEDIDOS_FONDO_refresh()
        Inicio.SQLPARAMETROS(Organismotabla, "
/**Select de varias tablas*/
select
CONCAT(cast(Substring(Exped.CLAVEPEDIDO From 9 for 5)AS UNSIGNED),'/',Substring(Exped.CLAVEPEDIDO From 1 for 4)) as 'Ped.Fondo',
Pedfondo.DESCRIPCION,
sum(ingresos) as INGRESOS,
sum(egresos) as EGRESOS,
(sum(ingresos)-sum(EGRESOS))AS DIFERENCIA,
MONTO_PEDIDOFONDO AS 'TOTAL_PEDIDO',
cuenta.descripcion,
SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13) as clave_expediente,Exped.clave_pedidofondo
FROM
/* Select de ingresos y egresos*/
(SELECT
CONCAT(Substring(clave_expedientE_Detalle From 5 for 4),'-',cast(Substring(clave_expedientE_Detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expedientE_Detalle From 1 for 4)) as Expediente,
sum(ingresos) as Ingresos,
sum(egresos) as Egresos,
clave_expediente_Detalle
 FROM
(select clave_expedientE_Detalle,0 as ingresos,sum(monto) as egresos,codinp from
expediente_Detalle where CodInp=1 and date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
union ALL
select clave_expedientE_Detalle,sum(monto) as ingresos,0 as egresos,codinp from
expediente_Detalle where CodInp=3 and DATE(Creado_o_modificado) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13)
)a
/* Agrupado por Expediente*/
group by SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13))AA
/* Left join de Expediente */
LEFT JOIN
(select *,CASE WHEN ISNULL(CLAVE_PEDIDOFONDO) THEN CUENTA_ESPECIAL ELSE CLAVE_PEDIDOFONDO END AS CLAVEPEDIDO from expediente)Exped
on SUBSTRING(aa.clave_expedientE_Detalle FROM 1 FOR 13)=Exped.Clave_expediente
/* Left join de Pedidos de fondo */
LEFT JOIN
(select * from pedido_fondos)Pedfondo
on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
/* Left join de Cuenta Bancaria */
LEFT JOIN
(select * From Cuenta_Bancaria)Cuenta
on Pedfondo.cuenta_pedidofondo=Cuenta.cuenta
GROUP BY Exped.clave_pedidofondo
/* Ordenado por número de expediente y por movimiento */
order by clave_pedidofondo DESC
", Datatable_general, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_General.DataSource = Nothing
        Datagrid_General.DataSource = Datatable_general
        Datagrid_General.Columns("clave_pedidofondo").Visible = False
        Datagrid_General.Columns("clave_expediente").Visible = False
        Datagrid_General.Columns("INGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("EGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("TOTAL_PEDIDO").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        Datagrid_General.CurrentCell = Nothing
    End Sub

    Private Sub PEDIDOS_FONDOMFyv_refresh()
        Inicio.SQLPARAMETROS(Organismotabla, "
/**Select de varias tablas*/
select
CONCAT(cast(Substring(Exped.CLAVEPEDIDO From 9 for 5)AS UNSIGNED),'/',Substring(Exped.CLAVEPEDIDO From 1 for 4)) as 'Ped.Fondo',
Pedfondo.DESCRIPCION,
sum(ingresos) as INGRESOS,
sum(egresos) as EGRESOS,
(sum(ingresos)-sum(EGRESOS))AS DIFERENCIA,
MONTO_PEDIDOFONDO AS 'TOTAL_PEDIDO',
cuenta.descripcion,
SUBSTRING(aa.clave_expediente FROM 1 FOR 13) as clave_expediente,Exped.clave_pedidofondo
FROM
/* Select de ingresos y egresos*/
(SELECT
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente,
sum(ingresos) as Ingresos,
sum(egresos) as Egresos,
a.clave_expediente
 FROM
(
select clave_expediente,sum(ingresos) as ingresos,sum(egresos) as egresos from (
select clave_expediente,0 as ingresos,sum(egresos) as egresos,codinp from
mfyv where CodInp=1 and date(FECHA) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
group by clave_expediente
union ALL
select clave_expediente,sum(ingresos) as ingresos,0 as egresos,codinp from
mfyv where CodInp=3 and date(FECHA) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
group by clave_expediente)a1
group by clave_expediente
)a
/* Agrupado por Expediente*/
group by SUBSTRING(clave_expediente FROM 1 FOR 13))AA
/* Left join de Expediente */
LEFT JOIN
(select *,CASE WHEN ISNULL(CLAVE_PEDIDOFONDO) THEN CUENTA_ESPECIAL ELSE CLAVE_PEDIDOFONDO END AS CLAVEPEDIDO from expediente)Exped
on SUBSTRING(aa.clave_expediente FROM 1 FOR 13)=Exped.Clave_expediente
/* Left join de Pedidos de fondo */
LEFT JOIN
(select * from pedido_fondos)Pedfondo
on Pedfondo.clave_pedidofondo=Exped.clave_pedidofondo
/* Left join de Cuenta Bancaria */
LEFT JOIN
(select * From Cuenta_Bancaria)Cuenta
on Pedfondo.cuenta_pedidofondo=Cuenta.cuenta
GROUP BY Exped.clave_pedidofondo
/* Ordenado por número de expediente y por movimiento */
order by clave_pedidofondo DESC
", Datatable_general, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_General.DataSource = Nothing
        Datagrid_General.DataSource = Datatable_general
        Datagrid_General.Columns("clave_pedidofondo").Visible = False
        Datagrid_General.Columns("clave_expediente").Visible = False
        Datagrid_General.Columns("INGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("EGRESOS").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("TOTAL_PEDIDO").DefaultCellStyle.Format = "c"
        Datagrid_General.Columns("DIFERENCIA").DefaultCellStyle.Format = "c"
        Datagrid_General.CurrentCell = Nothing
    End Sub

    Private Sub Datagrid_General_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datagrid_General.CellEnter
        verdetalles()
    End Sub

    Private Sub verdetalles()
        If Datagrid_General.SelectedRows.Count > 0 Then
            COMMANDSQL.Parameters.Clear()
            COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
            COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
            Select Case Ver_todos_movimientos_checkbox.Checked
                Case True
                    COMMANDSQL.Parameters.Clear()
                    COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.Year.ToString & "-01-01")
                    COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
                    Select Case Label_Tiporeporte.Text.ToUpper
                        Case Is = "EXPEDIENTES"
                            Expedientes_detalle_refresh()
                        Case Is = "EXPEDIENTESMFYV"
                            Expedientes_detalle_refresh()
                        Case Is = "TRANSFERENCIAS"
                            Transferencias_detalle_refresh()
                        Case Is = "PAGOS_REGISTRADOS"
                            Pagos_Registrados_detalle_refresh()
                        Case Is = "PROVEEDORES"
                            Proveedores_detalle_refresh()
                        Case Is = "PEDIDOS_FONDO"
                            PEDIDOS_FONDO_detalle_refresh()
                        Case Is = "PEDIDOS_FONDOMFYV"
                            PEDIDOS_FONDO_detalle_refresh()
                        Case Else
                    End Select
                Case False
                    Select Case Label_Tiporeporte.Text.ToUpper
                        Case Is = "EXPEDIENTES"
                            Expedientes_detalle_refresh()
                        Case Is = "EXPEDIENTESMFYV"
                            Expedientes_detalle_refresh()
                        Case Is = "TRANSFERENCIAS"
                            Transferencias_detalle_refresh()
                        Case Is = "PAGOS_REGISTRADOS"
                            Pagos_Registrados_detalle_refresh()
                        Case Is = "PROVEEDORES"
                            Proveedores_detalle_refresh()
                        Case Is = "PEDIDOS_FONDO"
                            PEDIDOS_FONDO_detalle_refresh()
                        Case Is = "PEDIDOS_FONDOMFYV"
                            PEDIDOS_FONDO_detalle_refresh()
                        Case Else
                    End Select
            End Select
        End If
    End Sub

    Private Sub Expedientes_detalle_refresh()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Datagrid_General.SelectedRows(0).Cells.Item("Clave_expediente").Value.ToString & "%")
        Inicio.SQLPARAMETROS(Organismotabla, "
Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where
(Clave_expediente_detalle like @clave_expediente
AND
(date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
or DATE(Creado_o_modificado) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
)   ))A)A1
  order by clave_expediente_detalle desc,Monto desc
", Datatable_detallado, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_Detalles.DataSource = Datatable_detallado
        Datagrid_Detalles.Columns("monto").DefaultCellStyle.Format = "c"
        Datagrid_Detalles.Columns("nrotransferencia").DefaultCellStyle.Format = "N0"
        Datagrid_Detalles.Columns("Clave_expediente_detalle").Visible = False
        Datagrid_Detalles.Columns("DETALLE").Width = 250
        Datagrid_Detalles.Columns("Expediente_N").Visible = False
        Datagrid_Detalles.CurrentCell = Nothing
    End Sub

    Private Sub Transferencias_detalle_refresh()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datagrid_General.SelectedRows(0).Cells.Item("Nrotransferencia").Value.ToString)
        Inicio.SQLPARAMETROS(Organismotabla, "
Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where
Nrotransferencia=@Nrotransferencia)A)A1
  order by clave_expediente_detalle desc,Monto desc
", Datatable_detallado, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_Detalles.DataSource = Datatable_detallado
        Datagrid_Detalles.Columns("monto").DefaultCellStyle.Format = "C"
        'Datagrid_Detalles.Columns("nrotransferencia").DefaultCellStyle.Format = "N0"
        Datagrid_Detalles.Columns("Clave_expediente_detalle").Visible = False
        Datagrid_Detalles.Columns("DETALLE").Width = 250
        Datagrid_Detalles.Columns("Expediente_N").Visible = False
        Datagrid_Detalles.CurrentCell = Nothing
    End Sub

    Private Sub Pagos_Registrados_detalle_refresh()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datagrid_General.SelectedRows(0).Cells.Item("Nrotransferencia").Value)
        Inicio.SQLPARAMETROS(Organismotabla, "
Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where
Nrotransferencia=@Nrotransferencia)A)A1
  order by clave_expediente_detalle desc,Monto desc
", Datatable_detallado, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_Detalles.DataSource = Datatable_detallado
        Datagrid_Detalles.Columns("monto").DefaultCellStyle.Format = "C"
        Datagrid_Detalles.Columns("nrotransferencia").DefaultCellStyle.Format = "N0"
        Datagrid_Detalles.Columns("Clave_expediente_detalle").Visible = False
        Datagrid_Detalles.Columns("DETALLE").Width = 250
        Datagrid_Detalles.Columns("Expediente_N").Visible = False
        Datagrid_Detalles.CurrentCell = Nothing
    End Sub

    Private Sub Proveedores_detalle_refresh()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Datagrid_General.SelectedRows(0).Cells.Item("CUIT").Value.ToString)
        Inicio.SQLPARAMETROS(Organismotabla, "
Select * From
(select CONCAT(Substring(clave_expedientE_Detalle From 5 for 4),'-',cast(Substring(clave_expedientE_Detalle From 9 for 5)AS UNSIGNED),'/',Substring(clave_expedientE_Detalle From 1 for 4)) as 'Expediente',
A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where
(CUIT=@CUIT
AND
(date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
or DATE(Creado_o_modificado) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
)   ))A)A1
  order by CodInp desc,clave_expediente_detalle desc,Fechadelmovimiento desc,Monto desc
", Datatable_detallado, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_Detalles.DataSource = Datatable_detallado
        Datagrid_Detalles.Columns("monto").DefaultCellStyle.Format = "c"
        Datagrid_Detalles.Columns("nrotransferencia").DefaultCellStyle.Format = "N0"
        Datagrid_Detalles.Columns("Clave_expediente_detalle").Visible = False
        Datagrid_Detalles.Columns("DETALLE").Width = 250
        Datagrid_Detalles.Columns("Expediente_N").Visible = False
        Datagrid_Detalles.CurrentCell = Nothing
    End Sub

    Private Sub PEDIDOS_FONDO_detalle_refresh()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_PEDIDOFONDO", Datagrid_General.SelectedRows(0).Cells.Item("clave_pedidofondo").Value)
        Inicio.SQLPARAMETROS(Organismotabla, "
Select * From
(select A.Clave_expediente_detalle,Expediente_N,Detalle,A.Monto,Fechadelmovimiento,Cod_orden,CFdo,
CodInp,Mov_tipo,Rendido,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,
CASE WHEN A.Total_Factura>-1 THEN A.Total_Factura ELSE Monto END AS MONTO_FACTURA FROM
(Select
Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_Factura,Fechadelmovimiento,Cod_orden,
CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Tipoorden,Orden_N,Orden_year,rendido
from Expediente_detalle where
(SUBSTRING(clave_expedientE_Detalle FROM 1 FOR 13) IN
(select clave_expediente from expediente where clave_pedidofondo=@clave_PEDIDOFONDO)
AND
(date(Fechadelmovimiento) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
or DATE(Creado_o_modificado) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
)   ))A)A1
  order by clave_expediente_detalle desc,Monto desc
", Datatable_detallado, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_Detalles.DataSource = Datatable_detallado
        Datagrid_Detalles.Columns("monto").DefaultCellStyle.Format = "C"
        Datagrid_Detalles.Columns("nrotransferencia").DefaultCellStyle.Format = "N0"
        Datagrid_Detalles.Columns("Clave_expediente_detalle").Visible = False
        Datagrid_Detalles.Columns("DETALLE").Width = 250
        'Datagrid_Detalles.Columns("Expediente_N").Visible = False
        Datagrid_Detalles.CurrentCell = Nothing
    End Sub

    Private Sub PEDIDOS_FONDOMFYV_detalle_refresh()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_PEDIDOFONDO", Datagrid_General.SelectedRows(0).Cells.Item("clave_pedidofondo").Value)
        Inicio.SQLPARAMETROS(Organismotabla, "
Select * From
(Select clave_expediente,mfyv.Expediente_N,Detalle,ingresos,egresos ,Cod_orden,
CFdo,CodInp,Nrotransferencia from mfyv where
(clave_expediente) IN
(select clave_expediente from expediente where clave_pedidofondo=@clave_PEDIDOFONDO)
AND
(date(fecha) BETWEEN DATE(@DESDE) AND DATE(@HASTA)
)   )A
  order by clave_expediente desc
", Datatable_detallado, Reflection.MethodBase.GetCurrentMethod.Name)
        Datagrid_Detalles.DataSource = Datatable_detallado
        Formatocolumnas(Datagrid_Detalles, Datatable_detallado)
        'Datagrid_Detalles.Columns("monto").DefaultCellStyle.Format = "C"
        'Datagrid_Detalles.Columns("nrotransferencia").DefaultCellStyle.Format = "N0"
        'Datagrid_Detalles.Columns("Clave_expediente_detalle").Visible = False
        'Datagrid_Detalles.Columns("DETALLE").Width = 250
        'Datagrid_Detalles.Columns("Expediente_N").Visible = False
        Datagrid_Detalles.CurrentCell = Nothing
    End Sub

    Private Sub Datagrid_Detalles_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datagrid_Detalles.RowPrePaint
        If Datagrid_Detalles.Rows.Count > 0 Then
            Select Case Label_Tiporeporte.Text.ToUpper
                Case Is = "EXPEDIENTES"
                    EXPEDIENTES_detalles_paint(sender, e)
                Case Is = "EXPEDIENTESMFYV"
                    EXPEDIENTES_detalles_paint(sender, e)
                Case Is = "TRANSFERENCIAS"
                    TRANSFERENCIAS_detalles_paint(sender, e)
                Case Is = "PAGOS_REGISTRADOS"
                    PAGOS_REGISTRADOS_detalles_paint(sender, e)
                Case Is = "PROVEEDORES"
                    PROVEEDORES_detalles_paint(sender, e)
                Case Is = "PEDIDOS_FONDOMFyV"
                    EXPEDIENTES_detalles_paint(sender, e)
                Case Else
            End Select
        End If
    End Sub

    Private Sub EXPEDIENTES_detalles_paint(ByVal sender As Object, ByRef e As DataGridViewRowPrePaintEventArgs)
        Select Case Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Value
            Case Is = 3
                Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Style.BackColor = Color.Yellow
            Case Is = 1
                Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Style.BackColor = Color.LightCoral
            Case Else
        End Select
    End Sub

    Private Sub TRANSFERENCIAS_detalles_paint(ByVal sender As Object, ByRef e As DataGridViewRowPrePaintEventArgs)
        Select Case Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Value
            Case Is = 3
                Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Style.BackColor = Color.Yellow
            Case Is = 1
                Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Style.BackColor = Color.LightCoral
            Case Else
        End Select
    End Sub

    Private Sub PAGOS_REGISTRADOS_detalles_paint(ByVal sender As Object, ByRef e As DataGridViewRowPrePaintEventArgs)
        TRANSFERENCIAS_detalles_paint(sender, e)
    End Sub

    Private Sub PROVEEDORES_detalles_paint(ByVal sender As Object, ByRef e As DataGridViewRowPrePaintEventArgs)
        Select Case Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Value
            Case Is = 3
                Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Style.BackColor = Color.Yellow
            Case Is = 1
                Datagrid_Detalles.Rows(e.RowIndex).Cells.Item("codinp").Style.BackColor = Color.LightCoral
            Case Else
        End Select
    End Sub

    Private Sub Datagrid_Detalles_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datagrid_Detalles.CellEnter
        If Datagrid_Detalles.SelectedRows.Count > 0 Then
            Seleccion_a_table()
        End If
    End Sub

    Private Sub Seleccion_a_table()
        Select Case Ver_todos_movimientos_checkbox.Checked
            Case True
                COMMANDSQL.Parameters.Clear()
                COMMANDSQL.Parameters.AddWithValue("@desde", Desde_monthcalendarA.Value.Year.ToString & "-01-01")
                COMMANDSQL.Parameters.AddWithValue("@hasta", Hasta_monthcalendarA.Value.ToString("yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture))
                Select Case Label_Tiporeporte.Text.ToUpper
                    Case Is = "EXPEDIENTES"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "EXPEDIENTESMFYV"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "TRANSFERENCIAS"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PAGOS_REGISTRADOS"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PROVEEDORES"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PEDIDOS_FONDO"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PEDIDOS_FONDOMFyV"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Else
                End Select
            Case False
                Select Case Label_Tiporeporte.Text.ToUpper
                    Case Is = "EXPEDIENTES"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "EXPEDIENTESMFYV"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "TRANSFERENCIAS"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PAGOS_REGISTRADOS"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PROVEEDORES"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PEDIDOS_FONDO"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Is = "PEDIDOS_FONDOMFyV"
                        EXPEDIENTES_DETALLE_SELECCION()
                    Case Else
                End Select
        End Select
    End Sub

    Private Sub EXPEDIENTES_DETALLE_SELECCION()
        Dim RESUMEN As New DataTable
        Dim INGRESOS As Decimal = 0
        Dim EGRESOS As Decimal = 0
        Dim DIFERENCIA As Decimal = 0
        For x As Integer = 0 To Datagrid_Detalles.SelectedRows.Count - 1
            Select Case Datagrid_Detalles.SelectedRows(x).Cells.Item("codinp").Value
                Case Is = 3
                    INGRESOS += Datagrid_Detalles.SelectedRows(x).Cells.Item("Monto").Value
                Case Is = 1
                    EGRESOS += Datagrid_Detalles.SelectedRows(x).Cells.Item("Monto").Value
                Case Else
            End Select
        Next
        DIFERENCIA = INGRESOS - EGRESOS
        With RESUMEN
            .Columns.Add("TIPO")
            .Columns.Add("MONTO", GetType(System.Decimal))
            If INGRESOS > 0 Then
                .Rows.Add("Ingresos", INGRESOS)
            End If
            If EGRESOS > 0 Then
                .Rows.Add("Egresos", EGRESOS)
            End If
            If (INGRESOS > 0) And (EGRESOS > 0) Then
                .Rows.Add("Diferencia", DIFERENCIA)
            End If
        End With
        Datagrid_totales.DataSource = RESUMEN
        Datagrid_totales.Columns("MONTO").DefaultCellStyle.Format = "C"
        Datagrid_totales.CurrentCell = Nothing
    End Sub

    Private Sub Datagrid_General_MouseUp(sender As Object, e As MouseEventArgs) Handles Datagrid_General.MouseUp, Datagrid_Detalles.MouseUp
        If e.Button = MouseButtons.Right Then
            For x = 0 To CType(sender, DataGridView).Rows.Count - 1
                ColorearCeldas(x)
            Next
        End If
        Inicio.MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub Ver_todos_movimientos_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles Ver_todos_movimientos_checkbox.CheckedChanged
        Select Case sender.checked
            Case True
                sender.backcolor = Color.LightGreen
            Case False
                sender.backcolor = Color.White
        End Select
        verdetalles()
    End Sub

    Private Sub ColorearCeldas(ByVal Index As Integer)
        Select Case Label_Tiporeporte.Text.ToUpper
            Case Is = "EXPEDIENTES"
                If Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value = 0 Then
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"))
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"))
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("Retenciones pendientes de pago"))
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"))
                    Colorceldaok2(Datagrid_General.Rows(Index).Cells.Item("Total de expediente"))
                    If Datagrid_General.Rows(Index).Cells.Item("Total de expediente").Value = Datagrid_General.Rows(Index).Cells.Item("INGRESOS").Value Then
                        Colorceldaok3(Datagrid_General.Rows(Index).Cells.Item("EXPEDIENTE"))
                    Else
                        Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("EXPEDIENTE"))
                        Colorcelda(Datagrid_General.Rows(Index).Cells.Item("Total de expediente"), Color.LightYellow)
                    End If
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value > 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.White)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("Retenciones pendientes de pago"), Color.White)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EXPEDIENTE"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("Total de expediente"), Color.Yellow)
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value < 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.White)
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"))
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("Retenciones pendientes de pago"))
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"))
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("EXPEDIENTE"))
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("Total de expediente"))
                Else
                End If
                If Datagrid_General.Rows(Index).Cells.Item("Total de expediente").Value < 1 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EXPEDIENTE"), Color.DarkRed)
                End If
            Case Is = "TRANSFERENCIAS"
            Case Is = "PAGOS_REGISTRADOS"
            Case Is = "PROVEEDORES"
                If Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value = 0 Then
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"))
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"))
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"))
                    Colorceldaok1(Datagrid_General.Rows(Index).Cells.Item("PROVEEDOR"))
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value > 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.White)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("PROVEEDOR"), Color.Yellow)
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value < 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.White)
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"))
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"))
                    Colorceldano1(Datagrid_General.Rows(Index).Cells.Item("PROVEEDOR"))
                Else
                End If
            Case Is = "PEDIDOS_FONDO"
                If Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value = 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.LightGreen)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.LightGreen)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.LightGreen)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("PED.FONDO"), Color.LightGreen)
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value > 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.White)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("PED.FONDO"), Color.Yellow)
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value < 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.White)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.LightCoral)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.LightCoral)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("PED.FONDO"), Color.LightCoral)
                Else
                End If
            Case Is = "PEDIDOS_FONDOMFYV"
                If Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value = 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.LightGreen)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.LightGreen)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.LightGreen)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("PED.FONDO"), Color.LightGreen)
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value > 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.White)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.Yellow)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("PED.FONDO"), Color.Yellow)
                ElseIf Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA").Value < 0 Then
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("INGRESOS"), Color.White)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("EGRESOS"), Color.LightCoral)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("DIFERENCIA"), Color.LightCoral)
                    Colorcelda(Datagrid_General.Rows(Index).Cells.Item("PED.FONDO"), Color.LightCoral)
                Else
                End If
            Case Else
        End Select
    End Sub

    Private Sub Datagrid_General_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datagrid_General.RowPrePaint
        ColorearCeldas(e.RowIndex)
    End Sub

    Private Sub Label_Tiporeporte_TextChanged(sender As Object, e As EventArgs) Handles Label_Tiporeporte.TextChanged
        Select Case Label_Tiporeporte.Text
            Case Is = "-"
                Generar_reporte.Visible = False
                Splitcontainer_Datos.Visible = False
            Case Else
                Generar_reporte.Visible = True
                Splitcontainer_Datos.Visible = True
        End Select
    End Sub

End Class