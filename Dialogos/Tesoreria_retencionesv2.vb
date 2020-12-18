Public Class Tesoreria_retencionesV2
    ' Dim movimiento_actual As New Movimiento
    Dim Listamovimientos As List(Of Movimiento)
    Dim Factura_ACTUAL As New Factura
    Dim Expediente_Actual As New Expediente
    Dim Proveedor_actual As New Proveedor
    Dim Inscripcionafip As New DataTable
    Dim Porcentajes_IVA As New DataTable
    Dim SUSS_RETENCIONES As New DataTable
    Dim DGR_RETENCIONES As New DataTable
    Dim Cuentabancaria As String = ""
    Dim listadodecontroles As New List(Of Tesoreria_Control_Retenciones)
    Dim listadodebotones As New List(Of Button)

    Private Sub BotonAgregarMov_Click(sender As Object, e As EventArgs) Handles BotonAgregarMov.Click
        Dim ubicacion As Integer = 0
        'ubicacion = Encabezado_groupbox.Height
        ubicacion = 0
        For x = 0 To listadodecontroles.Count - 1
            ubicacion += listadodecontroles.Item(x).Height
        Next
        listadodecontroles.Add(New Tesoreria_Control_Retenciones)
        With listadodecontroles(listadodecontroles.Count - 1)
            .Width = Me.Width
            .Dock = DockStyle.Top
            '.Anchor = AnchorStyles.Right Or AnchorStyles.Left Or AnchorStyles.Top
            .CUIT = Cuitdelbeneficiario_textbox.Text
            .Cuentabancaria = Cuentabancaria
            .situacionfrenteafip = Responsabletipo_boton.Text.ToUpper
            .Fecharetencion = Fecha_factura.Value
            .Proveedor_actual = Proveedor_actual
            '.Controls.Add(New Button)
        End With
        PanelSplitGeneal.Panel2.Controls.Add(listadodecontroles(listadodecontroles.Count - 1))
        PanelSplitGeneal.Panel2.AutoScroll = True
        'Me.Controls.Add()
        Me.Text = ubicacion
        listadodecontroles.Item(listadodecontroles.Count - 1).Location = New Point(0, ubicacion)
    End Sub

    Private Function ubicacionytamanioboton(ByRef control As Tesoreria_Control_Retenciones) As Button
        Dim boton As New Button
        Return boton
    End Function

    Private Sub Cuit_boton_Click(sender As Object, e As EventArgs) Handles Cuit_boton.Click
        '  Cuitdialogomostrar()
        Dialogo_CUIT.Cargadetextbox(Cuitdelbeneficiario_textbox)
        Dialogo_CUIT.Cargadecuits("")
        AcumuladosCUIT()
        Beneficiario_label.Text = Proveedor_actual.Nombre
        For x = 0 To listadodecontroles.Count - 1
            If Me.Controls.Contains(listadodecontroles(x)) Then
                Me.Controls.Remove(listadodecontroles(x))
            End If
        Next
        listadodecontroles = New List(Of Tesoreria_Control_Retenciones)
    End Sub

    Private Sub AcumuladosCUIT(Optional clave_expediente_Detalle As Long = 0)
        Factura_ACTUAL.CUIT = Cuitdelbeneficiario_textbox.Text
        Proveedor_actual.CUIT = Factura_ACTUAL.CUIT
        Proveedor_actual.Cargardatos()
        Factura_ACTUAL.Fecha = Fecha_factura.Value
        Factura_ACTUAL.totalmesencurso = Factura_ACTUAL.mesencurso(0)
        Factura_ACTUAL.total12meses = Factura_ACTUAL.Calculo12meses(0)
        Factura_ACTUAL.totalaniocalendario = Factura_ACTUAL.calculocalendario(0)
        Facturadomes_label.Text = Factura_ACTUAL.calculocalendario(0).ToString("C")
        Facturado12meses_label.Text = Factura_ACTUAL.Calculo12meses(0).ToString("C")
        Facturadoanio_label.Text = Factura_ACTUAL.mesencurso(0).ToString("C")
    End Sub

    Private Sub Facturadomes_label_Click(sender As Object, e As EventArgs) Handles Facturadomes_label.Click
        Dialogo_datos.mostrardatatable(Factura_ACTUAL.mesencursodesglose, "Pagos realizados mes en Curso", DataGridViewAutoSizeColumnsMode.Fill)
    End Sub

    Private Sub Facturado12meses_label_Click(sender As Object, e As EventArgs) Handles Facturado12meses_label.Click
        Dialogo_datos.mostrardatatable(Factura_ACTUAL.Calculo12mesesdesglose, "Pagos realizados en los 12 meses anteriores", DataGridViewAutoSizeColumnsMode.Fill)
    End Sub

    Private Sub Facturadoanio_label_Click(sender As Object, e As EventArgs) Handles Facturadoanio_label.Click
        Dialogo_datos.mostrardatatable(Factura_ACTUAL.calculocalendariodesglose, "Pagos realizados en el año calendario", DataGridViewAutoSizeColumnsMode.Fill)
    End Sub

    Private Sub Responsabletipo_boton_Click(sender As Object, e As EventArgs) Handles Responsabletipo_boton.Click
        Cargadevariableopciones(sender, Inscripcionafip, "Seleccione situación frente a la AFIP", "Seleccionar", "Cancelar")
        If Not IsNothing(DialogDialogo_Datagridview.FilaSeleccionada) Then
            Responsabletipo_boton.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
        Else
        End If
        ' situacionyempleadorafip()
    End Sub

    Private Sub Cargadevariableopciones(ByVal boton As Object, ByVal tabla As DataTable, ByVal titulo As String, ByVal aceptarstring As String, ByVal cancelarstring As String)
        'Inscripcionafip
        DialogDialogo_Datagridview.Carga_General(tabla, titulo, aceptarstring, cancelarstring, 10)
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            boton.text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
        Else
        End If
        DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub Pagosacumulados()
        Factura_ACTUAL.CUIT = Cuitdelbeneficiario_textbox.Text
        Factura_ACTUAL.Fecha = Fecha_factura.Value
        Factura_ACTUAL.totalmesencurso = Factura_ACTUAL.mesencurso()
        Factura_ACTUAL.total12meses = Factura_ACTUAL.Calculo12meses()
        Factura_ACTUAL.totalaniocalendario = Factura_ACTUAL.calculocalendario()
    End Sub

    Private Sub Tesoreria_retencionesV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaiva()
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
    End Sub

    Private Sub cargaiva()
        'Porcentaje de IVA
        With Porcentajes_IVA
            With .Columns
                .Add("IVA porcentaje ", GetType(Decimal))
            End With
            With .Rows
                .Add(0)
                .Add(10.5)
                .Add(21)
                .Add(27)
            End With
        End With
        'tipo inscripcion
        With Inscripcionafip
            With .Columns
                .Add("Inscripcion ")
            End With
            With .Rows
                .Add("INSCRIPTO")
                .Add("NO INSCRIPTO")
                .Add("MONOTRIBUTISTA")
            End With
        End With
    End Sub

    Private Sub Cuitdelbeneficiario_textbox_TextChanged(sender As Object, e As EventArgs) Handles Cuitdelbeneficiario_textbox.TextChanged
        Pagosacumulados()
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        Cuentabancaria = Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
    End Sub

    Private Sub Tesoreria_retencionesV2_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        BotonAgregarMov.Location = New Point(BotonAgregarMov.Location.X, Me.Size.Height - 55)
    End Sub

End Class