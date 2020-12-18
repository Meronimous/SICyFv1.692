Public Class Dialogo_listbox
    Public Property Resultadoseleccion As String
    Dim resultadoseleccion_temporal As String = ""

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Resultadoseleccion = resultadoseleccion_temporal
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Cargalistboxgeneral(ByVal Lista As List(Of String), ByVal NombredelMessage As String, ByVal Ok_boton As String, ByVal Cancelar_boton As String)
        Seleccion_listbox.Items.Clear()
        For x = 0 To Lista.Count - 1
            Seleccion_listbox.Items.Add(Lista(x))
        Next
        'Encabezado del dialogo
        NombredelMessage_label.Text = NombredelMessage
        'Message de los botones de aceptar o no
        OK_Button.Text = Ok_boton
        Cancel_Button.Text = Cancelar_boton
    End Sub

    Private Sub Seleccion_listbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Seleccion_listbox.SelectedIndexChanged
        If Seleccion_listbox.SelectedIndex >= 0 Then
            OK_Button.Enabled = True
            resultadoseleccion_temporal = Seleccion_listbox.SelectedItem.ToString
            Label_seleccionactiva.Text = Seleccion_listbox.SelectedItem.ToString
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub NombredelMessage_label_MouseMove(sender As Object, e As MouseEventArgs) Handles NombredelMessage_label.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

End Class