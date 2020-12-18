Public Class Dialogo_Solicitarnumero
    Dim Movimientomodificado As New Movimiento()
    Dim Movimientooriginal As New Movimiento()
    Public Property Numeroretorno As Long

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        DialogResult = DialogResult.Abort
    End Sub

    Private Sub Borrar_boton_Click(sender As Object, e As EventArgs) Handles Cancelar_boton.Click
        DialogResult = DialogResult.Abort
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

    'Private Sub Datos_datagridview_DataError(sender As SICyF.Flicker_Datagridview, e As DataGridViewDataErrorEventArgs) Handles Datos_datagridview.DataError
    '    MessageBox.Show("El valor ingresado es incorrecto, verifique por favor")
    '    Dim curException As Exception = e.Exception
    '    Dim curCell As DataGridViewCell = sender(e.ColumnIndex, e.RowIndex)
    '    curCell.Style.BackColor = Color.Yellow 'Setting the background color of the cell to yello
    '    'Colorcelda(sender.Rows(0).Cells.Item(sender.Columns(e.ColumnIndex).Name), Color.Red)
    '    'sender.Refresh()
    '    'sender.Rows(sender.SelectedCells(0).RowIndex).Cells.Item(sender.Columns(e.ColumnIndex).Name).Style.BackColor = Color.Yellow
    'End Sub
    Private Sub Datos_datagridview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        'sender.Rows(sender.SelectedCells(0).RowIndex).Cells.Item(sender.Columns(e.ColumnIndex).Name).Style.BackColor = Color.White
    End Sub

    Private Sub Datos_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
    End Sub

    Private Sub Dialogo_Solicitarnumero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Modificar_boton_Click(sender As Object, e As EventArgs) Handles Modificar_boton.Click
        Numeroretorno = Numerodetransaccionnuevo_numeric.Value
        DialogResult = DialogResult.OK
    End Sub

End Class