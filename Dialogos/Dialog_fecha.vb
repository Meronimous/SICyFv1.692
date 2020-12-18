Public Class Dialog_fecha
    Public fechas As DateTime = Date.Now
    Dim fechaestimada As Object

    Public Sub cargageneral(ByRef fechador As Object)
        fechaestimada = fechador
        Select Case fechador.GetType().Name
            Case Is = "DataGridViewTextBoxCell"
                If Not IsDBNull(fechaestimada.value) Then
                    fechas = fechaestimada.value
                Else
                    VALORFECHA_Datetimepicker.Value = Date.Now
                End If
                VALORFECHA_Datetimepicker.Value = fechas
            Case Else
        End Select
        Me.ShowDialog()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        evaluar()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub evaluar()
        Select Case fechaestimada.GetType().Name
            Case Is = "DataGridViewTextBoxCell"
                fechaestimada.value = fechas.Date
            Case Else
        End Select
    End Sub

    Private Sub fechaseleccion(sender As Object, e As MouseEventArgs)
        OK_Button.PerformClick()
    End Sub

    Private Sub VALORFECHA_Datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles VALORFECHA_Datetimepicker.ValueChanged
        fechas = VALORFECHA_Datetimepicker.Value
        evaluar()
    End Sub

End Class