Public Class Suministros_listadoordenesprovision
    Dim ordenprovision_datatable As New DataTable
    Dim ordendeprovision As New OrdenProvision

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Refresh()
        '        "Select concat(cast(substring(Clave_ordenprovision from 9 for 5) as unsigned),'/',cast(substring(Clave_ordenprovision from 1 for 4) as unsigned)) as 'NUM.OP' ,
        'Clave_ordenprovision,
        'Clave_expediente,
        'Iniciador,
        'Destino,
        'Tipo_origen,
        'Numero_origen,
        'Year_origen,
        'Fecha_origen,
        'op.CUIT,Prov.proveedor,
        'Tipo_instrumentolegal,
        'Numero_instrumentolegal,
        'Year_instrumentolegal,
        'Fecha_instrumentolegal,
        'Total,
        'Lugar_entrega,
        'valor_tiempoentrega,
        'Unidad_tiempoentrega,
        'fecharealizada_ordenprovision,
        'Fechaconfeccionada_ordenprovision FROM
        '(Select * from suministros_orden_provision)op
        'LEFT JOIN
        '(select * from proveedores)prov
        'on op.cuit=prov.cuit
        'order by clave_ordenprovision desc"
        Dim consultasql As String = "select CONCAT(
cast(Substring(ordenesprovision.clave_ordenprovision From 9 for 5)AS UNSIGNED),'/',Substring(ordenesprovision.clave_ordenprovision From 1 for 4)) as 'O.Prov.',
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) AS 'Expediente',
DESTINO,
CAST(CANTIDAD AS UNSIGNED) as 'CANTIDAD',
UNIDAD,
descripcionart AS 'DETALLE',
Precio_total  from
(
Select *
from suministros_orden_provision )ordenesprovision
INNER join
(
select * from
suministros_orden_provision_detalle
)DETALLE
ON ordenesprovision.Clave_ordenprovision=DETALLE.Clave_ordenprovision"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, ordenprovision_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_ordenprovision.DataSource = ordenprovision_datatable
        'Datos_ordenprovision.Columns("Clave_ordenprovision").Visible = False
        'Datos_ordenprovision.Columns("Clave_expediente").Visible = False
        'Datos_ordenprovision.Columns("Total").DefaultCellStyle.Format = "C"
        'Datos_ordenprovision.Columns("Iniciador").Visible = True
        'Datos_ordenprovision.Columns("Destino").Visible = True
        'Datos_ordenprovision.Columns("Tipo_origen").Visible = False
        'Datos_ordenprovision.Columns("Numero_origen").Visible = False
        'Datos_ordenprovision.Columns("Year_origen").Visible = False
        'Datos_ordenprovision.Columns("Fecha_origen").Visible = False
        'Datos_ordenprovision.Columns("CUIT").Visible = False
        'Datos_ordenprovision.Columns("Tipo_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Numero_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Year_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Fecha_instrumentolegal").Visible = False
        'Datos_ordenprovision.Columns("Total").Visible = True
        'Datos_ordenprovision.Columns("Lugar_entrega").Visible = False
        'Datos_ordenprovision.Columns("valor_tiempoentrega").Visible = False
        'Datos_ordenprovision.Columns("Unidad_tiempoentrega").Visible = False
        'Datos_ordenprovision.Columns("fecharealizada_ordenprovision").Visible = False
        'Datos_ordenprovision.Columns("Fechaconfeccionada_ordenprovision").Visible = False
        'Datos_datagrid.Columns("IMPORTE O.P.").DefaultCellStyle.Format = "C"
        'Datos_datagrid.Columns("Monto").DefaultCellStyle.Format = "C"
        'Datos_datagrid.Columns("clave_expediente").Visible = False
        'Datos_datagrid.Columns("clave_ordenprovision").Visible = False
        'Datos_datagrid.Columns("Clave_expediente").Visible = False
        'Datos_datagrid.Columns("Clave_expediente").Visible = False
        'Datos_datagrid.Columns("Cuenta_especial").Visible = False
    End Sub

    Private Sub Refresh_op_Click(sender As Object, e As EventArgs) Handles Refresh_op.Click
        Refresh()
    End Sub

    Private Sub Datos_ordenprovision_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenprovision.CellEnter
        cargarordenprovisiondata()
    End Sub

    Private Sub cargarordenprovisiondata()
        If Datos_ordenprovision.SelectedRows.Count > 0 Then
            ordendeprovision.ClaveOrdenProvision = Datos_ordenprovision.SelectedRows(0).Cells.Item("Clave_ordenprovision").Value
            ordendeprovision.cargar_OP(ordendeprovision.ClaveOrdenProvision)
            Datos_ordenprovision_detalle.DataSource = ordendeprovision.DATOSORDENPROVISION
            Datos_ordenprovision_detalle.Columns("Cant.").DefaultCellStyle.Format = "N2"
            'Datos_ordenprovision.Columns("Cant.").DefaultCellStyle.Format = "N2"
            Datos_ordenprovision_detalle.Columns("Prec.Unit.").DefaultCellStyle.Format = "C"
            Datos_ordenprovision_detalle.Columns("Prec.Total").DefaultCellStyle.Format = "C"
        End If
    End Sub

    Private Sub Datos_ordenprovision_detalle_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_ordenprovision_detalle.MouseUp, Datos_ordenprovision.MouseUp
        Inicio.MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub Busqueda_OP_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_OP.TextChanged
        Buscar_datagrid_TIMER(sender, ordenprovision_datatable, Datos_ordenprovision)
    End Sub

    Private Sub Suministros_listadoordenesprovision_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Refresh()
    End Sub

End Class