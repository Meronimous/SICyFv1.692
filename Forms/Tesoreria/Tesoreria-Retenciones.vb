Public Class Tesoreria_Retenciones
    Dim Datosgenerales_datatable As New DataTable
    Dim Datosdetallados_datatable As New DataTable

    Private Sub Tesoreria_Retenciones_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Refreshgeneral()
    End Sub

    Private Sub Refreshgeneral()
        Dim consultasql As String = ""
        Dim resultado As Decimal = 0
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Proveedor,a.CUIT,Monto AS 'Acumulado',`Pagos realizados`, DATE_FORMAT(FECHADELMOVIMIENTO,'%d/%m/%Y') as 'Fecha'
 from (Select CUIT,SUM(monto) AS 'MONTO',count(Clave_expediente_detalle) as 'Pagos realizados',detalle,fechadelmovimiento from expediente_Detalle where CODINP=1  GROUP BY CUIT)A
left join
(Select CUIT,PROVEEDOR,NOMBREFANTASIA from proveedores)B
on a.cuit=b.cuit",
                             Datosgenerales_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_Generales.DataSource = Datosgenerales_datatable
        Datos_Generales.Columns("Acumulado").DefaultCellStyle.Format = "C"
    End Sub

    Private Sub Refresh_detallado()
        'Datosdetallados_datatable
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
        '   SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Desde", Desde_datetimepicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        '   SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Hasta", Hasta_DateTimePicker.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", Datos_Generales.SelectedRows(0).Cells.Item("CUIT").Value)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Monto AS 'Monto Factura', DATE_FORMAT(FECHADELMOVIMIENTO,'%d/%m/%Y') as 'Fecha' ,
CONCAT(Substring(Clave_expediente_detalle From 5 for 4),'-',cast(Substring(Clave_expediente_detalle From 9 for 5)AS UNSIGNED),'/',Substring(Clave_expediente_detalle From 1 for 4)) as Expediente,detalle
 from (Select CUIT,monto,Clave_expediente_detalle,detalle,fechadelmovimiento from expediente_Detalle where CUIT=@CUIT  and CODINP=1 )A
left join
(Select CUIT,PROVEEDOR,NOMBREFANTASIA from proveedores)B
on a.cuit=b.cuit
Order by Fechadelmovimiento desc",
                             Datosdetallados_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datos_Detallados.DataSource = Datosdetallados_datatable
        Datos_Detallados.Columns("Monto Factura").DefaultCellStyle.Format = "C"
    End Sub

    Private Sub Tesoreria_Retenciones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F12
            Case Is = Keys.F11
            Case Is = Keys.F10
            Case Is = Keys.F5
                MyBase.SuspendLayout()
                Refreshgeneral()
                MyBase.ResumeLayout()
        End Select
    End Sub

    Private Sub Datos_Generales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Generales.CellEnter, Datos_Generales.CellClick, Datos_Generales.CellContentClick
        If Datos_Generales.SelectedRows.Count = 1 Then
            Refresh_detallado()
        Else
            Datos_Detallados.DataSource = Nothing
        End If
    End Sub

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(sender, Datosgenerales_datatable, Datos_Generales)
    End Sub

    Private Sub Tesoreria_Retenciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        MyBase.SuspendLayout()
        Refreshgeneral()
        MyBase.ResumeLayout()
    End Sub

    Private Sub Datos_Detallados_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_Detallados.MouseUp, Datos_Generales.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub precarga(ByVal forma As Windows.Forms.Form, ByRef panelubicacion As Object)
        Dim nuevopanel As New PANEL_sinFlicker
        Dim formx As New Form()
        formx = forma
        With formx
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .WindowState = FormWindowState.Maximized
        End With
        'Me.SuspendLayout()
        For Each Controls As Control In panelubicacion.Controls
            'Me.Controls.Remove(Controls)
            Controls.Visible = False
        Next
        panelubicacion.Controls.Add(nuevopanel)
        With nuevopanel
            .Parent = panelubicacion
            .Dock = DockStyle.Fill
            .BackColor = Color.White
            formx.MdiParent = Inicio
            .Controls.Add(formx)
            formx.Show()
        End With
        'Me.ResumeLayout()
    End Sub

    Private Sub Borrar_contenido()
    End Sub

    Private Sub Flicker_Split_General_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Flicker_Split_General.SplitterMoved
    End Sub

    Private Sub Recibos_boton_Click(sender As Object, e As EventArgs) Handles Recibos_boton.Click
        'nuevo_recibo()
        precarga(Tesoreria_recibos_retenciones, Flicker_Split_General.Panel2)
    End Sub

    Private Sub nuevo_recibo()
        Dim X As New Form
        Dim Nro_serie As New SICyF.Flicker_Numericcontrol_Numero
        With Nro_serie
            .Value = 0
            .Location = New Point(20, 20)
            .Width = 100
        End With
        Dim Nro_recibo As New SICyF.Flicker_Numericcontrol_Numero
        With Nro_recibo
            .Value = 0
            .Location = New Point(Nro_serie.Location.X + Nro_serie.Width + 50, 20)
            .Width = 100
        End With
        Dim Fecha_recibo As New DateTimePicker
        With Fecha_recibo
            .Value = Date.Now
            .Format = DateTimePickerFormat.Short
            .Width = 100
            .Location = New Point(Nro_recibo.Location.X + Nro_recibo.Width + 50, 20)
        End With
        Dim boton As New Button
        With boton
            .Text = "AGREGAR"
            .Width = 100
            .Location = New Point(Fecha_recibo.Location.X + Fecha_recibo.Width + 50, 20)
        End With
        With X
            .BackColor = Color.White
            .Size = New Size(500, 250)
            .StartPosition = FormStartPosition.CenterScreen
            .Controls.Add(Nro_serie)
            .Controls.Add(Nro_recibo)
            .Controls.Add(Fecha_recibo)
            .Controls.Add(boton)
        End With
        Mostrardialogo(X)
        'precarga(X, Flicker_Split_General.Panel2)
    End Sub

    Private Sub Retenciones_numero_Click(sender As Object, e As EventArgs) Handles Retenciones_numero.Click
        'Retenciones.Show()
        precarga(Retenciones, Flicker_Split_General.Panel2)
    End Sub

    Private Sub Generacion_AFIP_boton_Click(sender As Object, e As EventArgs) Handles Generacion_AFIP_boton.Click
    End Sub

End Class