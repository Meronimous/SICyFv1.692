Imports System.Globalization

Public Class Tesoreria_AjustesMFyV
    Dim cargando As Boolean = True
    Dim Formas_visualizacion As New DataTable
    Dim View_Mode As String = "Expediente"
    Dim Datosgenerales_datatable As New DataTable
    Dim DatosSICyF_datatable As New DataTable
    Dim DatosMFyV_datatable As New DataTable

    Private Sub Tesoreria_AjustesMFyV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Desde_datetimepicker.Value = CType("01-" & Date.Now.AddMonths(-1).Month & "-" & Date.Now.AddMonths(-1).Year, Date)
        Hasta_DateTimePicker.Value = CType(Date.DaysInMonth(Date.Now.AddMonths(-1).Year, Date.Now.AddMonths(-1).Month) & "-" & Date.Now.AddMonths(-1).Month & "-" & Date.Now.AddMonths(-1).Year, Date)
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
        Formas_visualizacion.Columns.Add("Ver por:")
        Formas_visualizacion.Rows.Add().Item("Ver por:") = "Expediente"
        Formas_visualizacion.Rows.Add().Item("Ver por:") = "Nro Transferencia"
        Formas_visualizacion.Rows.Add().Item("Ver por:") = "por día"
        'Formas_visualizacion.Rows.Add().Item("Ver por:") = "por día"
        Cuenta_N_Label.Text = Autocompletetables.Cuentas.Rows(0).Item(0).ToString
    End Sub

    Private Sub Tesoreria_AjustesMFyV_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cargando = False
    End Sub

    Private Sub Refresh_General()
        If Not IsNothing(Cuentas_combobox.SelectedIndex) Then
            Select Case View_Mode
                Case Is = "Expediente"
                    Por_expediente()
                Case Is = "Nro Transferencia"
                    Por_transferencia()
                Case Is = "por día"
                    Por_dia()
            End Select
        End If
        Columnas_decimales(Datos_Generales)
    End Sub

    Private Sub Por_expediente()
        Dim consultasql As String = "Select
CONCAT(Substring(A.clave_expediente From 5 for 4),
'-',cast(Substring(A.clave_expediente From 9 for 5)AS UNSIGNED),'/'
,Substring(A.clave_expediente From 1 for 4)) as 'Expediente_N',
exp.monto as 'Importe',
A.NROTRANSFERENCIA,
IFNULL(A.`INGRESOS SICYF`,0) AS 'INGRESOS SICyF',
IFNULL(INGRESOS,0) AS 'INGRESOS',
IFNULL(A.`INGRESOS SICYF`,0)-IFNULL(INGRESOS,0) AS 'DIF. INGRESOS',
IFNULL(A.`Egresos SicyF`,0) AS 'EGRESOS SICyF',
IFNULL(EGRESOS,0) AS 'EGRESOS',
IFNULL(A.`Egresos SicyF`,0)-IFNULL(EGRESOS,0) AS 'DIF. EGRESOS',
IFNULL(A.`MOV. SICYF`,0) AS 'MOV. SICyF',
IFNULL(B.`MOV MFyV`,0) AS 'MOV. MFyV',
IFNULL(A.`MOV. SICYF`,0)-IFNULL(B.`MOV MFyV`,0) AS 'DIF MOVIMIENTOS',A.CLAVE_EXPEDIENTE
from
(Select CAST(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS UNSIGNED) AS CLAVE_EXPEDIENTE,
IFNULL(SUM(CASE when codinp=1 or codinp=4 then (monto) else 0 end),0) as 'Egresos SicyF',
IFNULL(SUM(Case when codinp=3 then (monto) else 0 end),0) as 'INGRESOS SICYF',
Nrotransferencia,COUNT(Nrotransferencia) AS 'MOV. SICYF'
from expediente_detalle WHERE (Fechadelmovimiento BETWEEN @DESDE AND @HASTA) and (not codinp=2) AND
/*FILTRO de Busqueda de expedientes en condicione de de ser cargados */
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
group by `CLAVE_EXPEDIENTE` )A
left join
(select CLAVE_EXPEDIENTE,EXPEDIENTE_n,Expediente_year,Nrotransferencia,IFNULL(SUM(ingresos),0) AS 'INGRESOS', IFNULL(SUM(egresos),0) AS 'EGRESOS',COUNT(Nrotransferencia) AS 'MOV MFyV' from mfyv
WHERE (FECHA BETWEEN @DESDE AND @HASTA) AND CUENTA_N=@Cuenta AND NOT (CodInp=2)
group by CLAVE_EXPEDIENTE)B
ON
A.CLAVE_EXPEDIENTE=b.Clave_expediente
left join
(select * from Expediente )EXP
ON
A.CLAVE_EXPEDIENTE=EXP.Clave_expediente"
        Datos_Generales.DataSource = Consulta_Datatable(consultasql, Datosgenerales_datatable)
        Datos_Generales.Columns("CLAVE_EXPEDIENTE").Visible = False
    End Sub

    Private Sub Por_transferencia()
        Dim consultasql As String = "Select
CASE WHEN not isnull( a.Nrotransferencia) then
a.Nrotransferencia else
b.Nrotransferencia
end as 'Nrotransferencia',
IFNULL(A.`INGRESOS SICYF`,0) AS 'INGRESOS SICyF',
IFNULL(INGRESOS,0) AS 'INGRESOS',
IFNULL(A.`INGRESOS SICYF`,0)-IFNULL(INGRESOS,0) AS 'DIF. INGRESOS',
IFNULL(A.`Egresos SicyF`,0) AS 'EGRESOS SICyF',
IFNULL(EGRESOS,0) AS 'EGRESOS',
IFNULL(A.`Egresos SicyF`,0)-IFNULL(EGRESOS,0) AS 'DIF. EGRESOS',
IFNULL(A.`MOV. SICYF`,0) AS 'MOV. SICyF',
IFNULL(B.`MOV MFyV`,0) AS 'MOV. MFyV',
IFNULL(A.`MOV. SICYF`,0)-IFNULL(B.`MOV MFyV`,0) AS 'DIF MOVIMIENTOS'
from
(Select CAST(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS UNSIGNED) AS CLAVE_EXPEDIENTE,
IFNULL(SUM(CASE when codinp=1 then (monto) else 0 end),0) as 'Egresos SicyF',
IFNULL(SUM(Case when codinp=3 then (monto) else 0 end),0) as 'INGRESOS SICYF',
Nrotransferencia,
COUNT(Nrotransferencia) AS 'MOV. SICYF'
from expediente_detalle WHERE (Fechadelmovimiento BETWEEN @DESDE AND @HASTA) AND NOT (CodInp=2) AND
/*FILTRO de Busqueda de expedientes en condicione de de ser cargados */
(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE clave_pedidofondo IN (SELECT clave_pedidofondo FROM pedido_fondos WHERE Cuenta_pedidofondo = @Cuenta)) OR
SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) IN
        (SELECT Clave_expediente FROM expediente WHERE Cuenta_especial = @Cuenta))
group by `Nrotransferencia` )A
left join
(select CLAVE_EXPEDIENTE,EXPEDIENTE_n,Expediente_year,Nrotransferencia,IFNULL(SUM(ingresos),0) AS 'INGRESOS', IFNULL(SUM(egresos),0) AS 'EGRESOS',COUNT(Nrotransferencia) AS 'MOV MFyV' from mfyv
WHERE (FECHA BETWEEN @DESDE AND @HASTA) AND CUENTA_N=@Cuenta AND NOT (CodInp=2)
group by Nrotransferencia)B
ON
A.Nrotransferencia=b.Nrotransferencia
order by Nrotransferencia"
        Datos_Generales.DataSource = Consulta_Datatable(consultasql, Datosgenerales_datatable)
    End Sub

    Private Sub Por_dia()
    End Sub

    Private Sub Refresh_SICyF()
        '
        Dim consultasql As String = ""
        Select Case View_Mode
            Case Is = "Expediente"
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Datos_Generales.SelectedRows(0).Cells.Item("clave_expediente").Value)
                consultasql = "Select
Fechadelmovimiento as  Fecha,Expediente_N,Detalle,Cod_orden,Cfdo,Codinp,Nrotransferencia,Monto,Orden_N,Creado_o_modificado,CASE when isnull(MD5_relacionado) then 'NO' else 'SI' END as Conciliado,MD5_relacionado,Clave_expediente_detalle
from Expediente_detalle where CAST(SUBSTRING(Clave_expediente_detalle FROM 1 FOR CHAR_LENGTH(Clave_expediente_detalle) - 4) AS UNSIGNED) =@clave_expediente and (not codinp=2) and
(FECHADELMOVIMIENTO BETWEEN @DESDE AND @HASTA)"
                Datos_SICyF.DataSource = Consulta_Datatable(consultasql, DatosSICyF_datatable)
                Columnas_decimales(Datos_SICyF)
                Datos_SICyF.Columns("MD5_relacionado").Visible = False
                Datos_SICyF.Columns("Clave_expediente_detalle").Visible = False
            Case Is = "Nro Transferencia"
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datos_Generales.SelectedRows(0).Cells.Item("Nrotransferencia").Value)
                consultasql = "Select
Fechadelmovimiento as  Fecha,Expediente_N,Detalle,Cod_orden,Cfdo,Codinp,Nrotransferencia,Monto,Orden_N,Creado_o_modificado,CASE when isnull(MD5_relacionado) then 'NO' else 'SI' END as Conciliado,MD5_relacionado,Clave_expediente_detalle
from Expediente_detalle where Nrotransferencia =@Nrotransferencia and (not codinp=2) and
(FECHADELMOVIMIENTO BETWEEN @DESDE AND @HASTA)"
                Datos_SICyF.DataSource = Consulta_Datatable(consultasql, DatosSICyF_datatable)
                Columnas_decimales(Datos_SICyF)
                Datos_SICyF.Columns("MD5_relacionado").Visible = False
                Datos_SICyF.Columns("Clave_expediente_detalle").Visible = False
            Case Is = "por día"
                Por_dia()
        End Select
        Datos_SICyF.CurrentCell = Nothing
    End Sub

    Private Sub Refresh_MFyV()
        Dim consultasql As String = ""
        Select Case View_Mode
            Case Is = "Expediente"
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Datos_Generales.SelectedRows(0).Cells.Item("clave_expediente").Value)
                consultasql = "Select
FEcha,CONCAT(Expediente_N,'/',Expediente_year) as 'Expediente_N',detalle,Cod_orden,Cfdo,Codinp,Nrotransferencia,(Ingresos+Egresos) as 'Monto',Clave_expediente,cUENTA_N
from MFyV where clave_expediente=@clave_expediente and (FECHA BETWEEN @DESDE AND @HASTA) and (not codinp=2)"
                Datos_MFyV.DataSource = Consulta_Datatable(consultasql, DatosMFyV_datatable)
                Columnas_decimales(Datos_MFyV)
                Datos_MFyV.Columns("Clave_expediente").Visible = False
                Datos_MFyV.CurrentCell = Nothing
            Case Is = "Nro Transferencia"
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datos_Generales.SelectedRows(0).Cells.Item("Nrotransferencia").Value)
                consultasql = "Select
FEcha,CONCAT(Expediente_N,'/',Expediente_year) as 'Expediente_N',detalle,Cod_orden,Cfdo,Codinp,Nrotransferencia,(Ingresos+Egresos) as 'Monto',Clave_expediente,cUENTA_N
from MFyV where Nrotransferencia=@Nrotransferencia and (FECHA BETWEEN @DESDE AND @HASTA) and (not codinp=2) "
                Datos_MFyV.DataSource = Consulta_Datatable(consultasql, DatosMFyV_datatable)
                Columnas_decimales(Datos_MFyV)
                Datos_MFyV.Columns("Clave_expediente").Visible = False
                Datos_MFyV.CurrentCell = Nothing
            Case Is = "por día"
                Por_dia()
        End Select
    End Sub

    Private Function Consulta_Datatable(ByVal consulta As String, ByRef Tabladedatos As DataTable) As DataTable
        'Dim Tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consulta, Tabladedatos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return Tabladedatos
    End Function

    Private Sub Desde_datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles Desde_datetimepicker.ValueChanged, Hasta_DateTimePicker.ValueChanged, Cuentas_combobox.SelectedIndexChanged
        If cargando = False Then
            If Cuentas_combobox.SelectedIndex > -1 Then
                Cuenta_N_Label.Text = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
                Refresh_General()
            End If
        End If
    End Sub

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(sender, Datosgenerales_datatable, Datos_Generales)
    End Sub

    Private Sub Busqueda_SICyF_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_SICyF.TextChanged
        Buscar_datagrid_TIMER(sender, DatosSICyF_datatable, Datos_SICyF)
    End Sub

    Private Sub Busqueda_MFyV_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_MFyV.TextChanged
        Buscar_datagrid_TIMER(sender, DatosMFyV_datatable, Datos_MFyV)
    End Sub

    Private Sub Datos_Generales_CellEnter(sender As SICyF.Flicker_Datagridview, e As DataGridViewCellEventArgs) Handles Datos_Generales.CellEnter
        If cargando = False Then
            If sender.SelectedRows.Count > 0 Then
                Refresh_SICyF()
                Refresh_MFyV()
            End If
        End If
    End Sub

    Private Sub Columnas_decimales(sender As SICyF.Flicker_Datagridview)
        For x = 0 To sender.Columns.Count - 1
            If sender.Columns(x).ValueType.FullName.ToUpper = "SYSTEM.DECIMAL" Then
                sender.Columns(x).DefaultCellStyle.Format = "C"
            End If
        Next
    End Sub

    Private Sub Datos_MFyV_RowPrePaint(sender As SICyF.Flicker_Datagridview, e As DataGridViewRowPrePaintEventArgs) Handles Datos_MFyV.RowPrePaint
    End Sub

    Private Sub Datos_SICyF_RowPrePaint(sender As SICyF.Flicker_Datagridview, e As DataGridViewRowPrePaintEventArgs) Handles Datos_SICyF.RowPrePaint
    End Sub

    Private Sub Datos_Generales_RowPrePaint(sender As SICyF.Flicker_Datagridview, e As DataGridViewRowPrePaintEventArgs) Handles Datos_Generales.RowPrePaint
        If sender.Rows(e.RowIndex).Cells.Item("DIF. INGRESOS").Value = 0 Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("DIF. INGRESOS"), Color.LightGreen)
        Else
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("DIF. INGRESOS"), Color.LightCoral)
        End If
        If sender.Rows(e.RowIndex).Cells.Item("DIF. EGRESOS").Value = 0 Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("DIF. EGRESOS"), Color.LightGreen)
        Else
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("DIF. EGRESOS"), Color.LightCoral)
        End If
        If sender.Rows(e.RowIndex).Cells.Item("DIF MOVIMIENTOS").Value = 0 Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("DIF MOVIMIENTOS"), Color.LightGreen)
        Else
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("DIF MOVIMIENTOS"), Color.LightCoral)
        End If
        If (sender.Rows(e.RowIndex).Cells.Item("INGRESOS").Value - sender.Rows(e.RowIndex).Cells.Item("EGRESOS").Value) = 0 Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("INGRESOS"), Color.LightGreen)
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("EGRESOS"), Color.LightGreen)
        Else
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("INGRESOS"), Color.LightYellow)
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("EGRESOS"), Color.LightYellow)
        End If
        If (sender.Rows(e.RowIndex).Cells.Item("INGRESOS SICyF").Value - sender.Rows(e.RowIndex).Cells.Item("EGRESOS SICyF").Value) = 0 Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("INGRESOS SICyF"), Color.LightGreen)
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("EGRESOS SICyF"), Color.LightGreen)
        Else
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("INGRESOS SICyF"), Color.LightYellow)
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("EGRESOS SICyF"), Color.LightYellow)
        End If
        If (sender.Rows(e.RowIndex).Cells.Item("INGRESOS SICyF").Value = sender.Rows(e.RowIndex).Cells.Item("IMPORTE").Value) Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("IMPORTE"), Color.LightGreen)
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("IMPORTE"), Color.LightGreen)
        Else
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("IMPORTE"), Color.LightYellow)
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("IMPORTE"), Color.LightYellow)
        End If
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        If cargando = False Then
            Refresh_General()
        End If
    End Sub

    Private Sub Formavisualizacion_Click(sender As Object, e As EventArgs) Handles Formavisualizacion.Click
        DialogDialogo_Datagridview.Carga_General(Formas_visualizacion, "Seleccione la vista deseada", "Seleccionar", "Cancelar")
        DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            View_Mode = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
            If cargando = False Then
                Refresh_General()
            End If
        Else
            '   Labelcuentaespecialasignada.Text = ""
        End If
    End Sub

    Private Sub Datos_Generales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Generales.CellEnter
    End Sub

    Private Sub Datos_Generales_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datos_Generales.RowPrePaint
    End Sub

    Private Sub Datos_SICyF_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datos_SICyF.RowPrePaint
        If sender.Rows(e.RowIndex).Cells.Item("CONCILIADO").Value.ToString = "SI" Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("CONCILIADO"), Color.LightGreen)
        Else
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("CONCILIADO"), Color.LightYellow)
        End If
    End Sub

    Private Sub Datos_MFyV_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datos_MFyV.RowPrePaint
        If sender.Rows(e.RowIndex).Cells.Item("MONTO").Value < 0 Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("MONTO"), Color.LightCoral)
        Else
        End If
        If Not (Cuenta_N_Label.Text.ToString = sender.Rows(e.RowIndex).Cells.Item("CUENTA_n").Value.ToString) Then
            Colorcelda(sender.Rows(e.RowIndex).Cells.Item("CUENTA_n"), Color.LightCoral)
        End If
    End Sub

    Private Sub Datos_Generales_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_Generales.MouseUp, Datos_MFyV.MouseUp, Datos_SICyF.MouseUp
        Inicio.MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub Tesoreria_AjustesMFyV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
    End Sub

    Private Sub Tesoreria_AjustesMFyV_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode = Keys.F5
            Case True
                If Not cargando Then
                    Inicio.OBJETOCARGANDO(Flicker_Split_General, Me, "Actualizando, por Favor espere")
                    Refresh_General()
                    Inicio.OBJETOFINALIZAR(Flicker_Split_General, Me)
                End If
        End Select
    End Sub

    Private Sub Datos_Generales_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datos_Generales.DataError
        MessageBox.Show("verifique los datos ingresados en las celdas")
    End Sub

End Class