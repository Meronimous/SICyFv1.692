Public Class Dialogo_Movimientoscambio
    Dim Movimientomodificado As New Movimiento()
    Dim Movimientooriginal As New Movimiento()

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        DialogResult = DialogResult.Abort
    End Sub

    Private Sub Modificar_boton_Click(sender As Object, e As EventArgs) Handles Modificar_boton.Click
        If (Movimientomodificado.fecha = Movimientooriginal.fecha) And (Movimientomodificado.Transferencia = Movimientooriginal.Transferencia) And (Movimientomodificado.monto = Movimientooriginal.monto) Then
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", Strings.stringorganismo & "-" & Strings.stringnumero & "/" & Strings.stringyear)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", Detalle_textbox.Text)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Datos_datagridview.Rows(0).Cells.Item("Monto").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cod_orden", Label_Codorden.Text)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CFdo", LabelClasefondo.Text)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CodInp", Label_Codimp.Text)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Mov_tipo", Autocompletetables.SFyV_Codorden.Rows(CType(Label_Codorden.Text, Integer)).Item(1).ToString)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitdelbeneficiario_textbox.Text)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Datos_datagridview.Rows(0).Cells.Item("Transferencia").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fechadelmovimiento", Datos_datagridview.Rows(0).Cells.Item("FECHA").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave", Movimientooriginal.Clave_expediente_detalle)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@tipoorden", TipoOrden_groupbox.Text)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_N", Ordendeentrega_integerupdown.Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_year", Ordendeentregayear_integerupdown.Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = " UPDATE `Expediente_detalle` SET  " &
    "Monto=@Monto,Nrotransferencia=@Nrotransferencia,Fechadelmovimiento=@Fechadelmovimiento,Usuario=@Usuario where Clave_expediente_detalle=@Clave"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub Borrar_boton_Click(sender As Object, e As EventArgs) Handles Cancelar_boton.Click
        DialogResult = DialogResult.Abort
    End Sub

    Public Sub Modificarmovimiento(ByVal Movimientos As Movimiento)
        'Nrotransferencia_textbox.Value = Movimientos.Transferencia
        'Movimientofecha_calendar.Value = Movimientos.Fecha
        'Montodelmovimiento_textbox.Value = Movimientos.Monto
        Movimientooriginal = Movimientos
        Movimientomodificado = Movimientos
        Dim DTB = New DataTable
        DTB.Columns.Add("FECHA", GetType(System.DateTime))
        DTB.Columns.Add("Transferencia", GetType(System.Int32))
        DTB.Columns.Add("Monto", GetType(System.Decimal))
        DTB.Rows.Add()
        DTB.Rows(0).Item("FECHA") = Movimientos.fecha
        DTB.Rows(0).Item("Transferencia") = Movimientos.Transferencia
        DTB.Rows(0).Item("Monto") = Movimientos.monto
        Datos_datagridview.DataSource = DTB
        Datos_datagridview.Columns("mONTO").DefaultCellStyle.Format = "c"
        '  Mostrardialogo(Me)
    End Sub

    'Private Sub Nrotransferencia_textbox_ValueChanged(sender As Object, e As EventArgs)
    '    Movimientomodificado.Transferencia = Nrotransferencia_textbox.Value
    'End Sub
    'Private Sub Movimientofecha_calendar_ValueChanged(sender As Object, e As EventArgs)
    '    Movimientomodificado.Fecha = Movimientofecha_calendar.Value
    'End Sub
    Private Sub Nrotransferencia_textbox_Enter(sender As Object, e As EventArgs)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Label_expedienteasociados_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_expedienteasociados.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Montodelmovimiento_textbox_ValueChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Datos_datagridview_DataError(sender As SICyF.Flicker_Datagridview, e As DataGridViewDataErrorEventArgs) Handles Datos_datagridview.DataError
        MessageBox.Show("El valor ingresado es incorrecto, verifique por favor")
        Dim curException As Exception = e.Exception
        Dim curCell As DataGridViewCell = sender(e.ColumnIndex, e.RowIndex)
        curCell.Style.BackColor = Color.Yellow 'Setting the background color of the cell to yello
        'Colorcelda(sender.Rows(0).Cells.Item(sender.Columns(e.ColumnIndex).Name), Color.Red)
        'sender.Refresh()
        'sender.Rows(sender.SelectedCells(0).RowIndex).Cells.Item(sender.Columns(e.ColumnIndex).Name).Style.BackColor = Color.Yellow
    End Sub

    Private Sub Datos_datagridview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_datagridview.CellEndEdit
        'sender.Rows(sender.SelectedCells(0).RowIndex).Cells.Item(sender.Columns(e.ColumnIndex).Name).Style.BackColor = Color.White
    End Sub

    Private Sub Datos_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datos_datagridview.DataError
    End Sub

End Class