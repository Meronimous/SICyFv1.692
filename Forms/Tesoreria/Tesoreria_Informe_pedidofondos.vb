Public Class Tesoreria_Informe_pedidofondos

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
    End Sub

    Private Sub Informe_pedidofondos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Pedidodefondos_datagridview_LocationChanged(sender As Object, e As EventArgs) Handles Pedidodefondos_datagridview.LocationChanged
        '  MessageBox.Show(Pedidodefondos_datagridview.Location.X & "," & Pedidodefondos_datagridview.Location.Y & vbCrLf & Pedidodefondos_datagridview.Height & "," & Pedidodefondos_datagridview.Width)
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove, Label2.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class