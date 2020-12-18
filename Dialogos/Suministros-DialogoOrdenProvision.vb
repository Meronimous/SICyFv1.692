Public Class Suministros_OrdenProvision
    Public OrdenProvision As New OrdenProvision
    Dim datosordenprovision As New DataTable
    Dim valoresiniciales As Boolean = True
    Dim OPparamodificar As Boolean = False
    Dim ordenprovisionvieja As New OrdenProvision  'en caso de modificar se verifica los valores básicos necesarios.

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label_ordenprovisionasociada.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles yearinstrumentolegal_numericupdown.KeyDown, OP_year_tipo_numericupdown.KeyDown, ORDENPROVISION_TIPO.KeyDown, OP_num_tipo_numericupdown.KeyDown, ORDENPROVISION_INICIADOR.KeyDown, Montototal.KeyDown, Instrumentolegal_numericupdown.KeyDown, Instrumentolegal_combobox.KeyDown, Fecharealizada_datetimepicker.KeyDown, Cuitdelbeneficiario_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Numeroexpediente_numericupdown_Enter(sender As Object, e As EventArgs) Handles OP_num_tipo_numericupdown.Enter, yearinstrumentolegal_numericupdown.Enter, OP_year_tipo_numericupdown.Enter, ORDENPROVISION_INICIADOR.Enter, Montototal.Enter, Instrumentolegal_numericupdown.Enter, Cuitdelbeneficiario_textbox.Enter
        If (sender.GetType.ToString = "System.Windows.Forms.TextBox") Or (sender.GetType.ToString = "System.Windows.Forms.MaskedTextBox") Then
        Else
            sender.Select(0, sender.text.ToString.Length)
        End If
    End Sub

    Private Sub Suministros_OrdenProvision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lugares As New DataTable
        Inicio.Cargadetextboxautcompleteonload2(ORDENPROVISION_LUGARENTREGA, "Select nombre from suministros_lugar_entrega order by lugar_clave ", "Nombre")
        ' unidad_terminonumericupdown.Items.AddRange({"DÍAS", "DÍAS HÁBILES", "SEMANAS", "MESES"})
    End Sub

    Private Sub Suministros_OrdenProvision_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Datos_ordenprovision.Columns("Reng.").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Datos_ordenprovision.Columns("Cant.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Un.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Prec.Unit.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Prec.Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Articulos.").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Datos_ordenprovision.Columns("Detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Datos_ordenprovision.Columns("Encabezado").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ''Todo a cero
    End Sub

    Private Sub tablanueva()
        datosordenprovision.Columns.Add("Reng.", System.Type.GetType("System.Int32"))
        datosordenprovision.Columns.Add("Cant.", System.Type.GetType("System.Decimal"))
        datosordenprovision.Columns.Add("Un.", System.Type.GetType("System.String"))
        datosordenprovision.Columns.Add("Articulos.", System.Type.GetType("System.String"))
        datosordenprovision.Columns.Add("Prec.Unit.", System.Type.GetType("System.Decimal"))
        datosordenprovision.Columns.Add("Prec.Total", System.Type.GetType("System.Decimal"))
        datosordenprovision.Columns.Add("Detalle", System.Type.GetType("System.String"))
        datosordenprovision.Columns.Add("Encabezado", System.Type.GetType("System.String"))
        OPyear_numericupdown.Value = Date.Now.Year
        OP_year_tipo_numericupdown.Value = Date.Now.Year
        yearinstrumentolegal_numericupdown.Value = Date.Now.Year
        ORDENPROVISION_INICIADOR.Text = OrdenProvision.Iniciador
        cargadedatagridview()
    End Sub

    Private Sub cargadedatagridview()
        Datos_ordenprovision.DataSource = New DataView(datosordenprovision)
        For x = 0 To Datos_ordenprovision.Columns.Count - 1
            With Datos_ordenprovision.Columns(x).DefaultCellStyle
                .FormatProvider = Globalization.CultureInfo.GetCultureInfo("es-AR")
            End With
        Next
        Datos_ordenprovision.Columns("Cant.").DefaultCellStyle.Format = "N4"
        'Datos_ordenprovision.Columns("Cant.").DefaultCellStyle.Format = "N2"
        Datos_ordenprovision.Columns("Prec.Unit.").DefaultCellStyle.Format = "C"
        Datos_ordenprovision.Columns("Prec.Total").DefaultCellStyle.Format = "C"
        Datos_ordenprovision.Columns("Reng.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Cant.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Un.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Prec.Unit.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Prec.Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Datos_ordenprovision.Columns("Articulos.").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Datos_ordenprovision.Columns("Detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Datos_ordenprovision.Columns("Encabezado").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Public Sub Todoacero()
        OP_num_tipo_numericupdown.Value = 0
        OPNumero_numericupdown.Value = OrdenProvision.Buscarmaximo_ordenprovision(Date.Now.Year)
        OP_year_tipo_numericupdown.Value = Date.Now.Year
        Fecharealizada_datetimepicker.Value = Date.Now
        ORDENPROVISION_INICIADOR.Text = ""
        ' ORDENPROVISION_CONCEPTO.Text = ""
        Cuitdelbeneficiario_textbox.Text = ""
        Montototal.Value = 0
        Instrumentolegal_combobox.SelectedIndex = 0
        Instrumentolegal_numericupdown.Value = 0
        yearinstrumentolegal_numericupdown.Value = Date.Now.Year
        ORDENPROVISION_TIPO.SelectedIndex = 0
        cantidad_terminonumericupdown.Value = 5
        unidad_terminonumericupdown.SelectedIndex = 0
    End Sub

    Public Sub Cargarordenprovision(ByVal orden As OrdenProvision)
        Todoacero()
        OrdenProvision = orden
        OPparamodificar = False 'Es una orden de provisión para modificar
        encabezadodialogo()
        tablanueva()
        Mostrardialogo(Me)
    End Sub

    Private Sub encabezadodialogo()
        Label_ordenprovisionasociada.Text = " Orden de Provisión Nº" & OrdenProvision.OrdenProvisionNumero & " en Expte: " & OrdenProvision.Expediente
    End Sub

    Public Sub Cargardatosamodificar(ByVal ORDENPROVISIONS As OrdenProvision)
        OPparamodificar = True 'Es una orden de provisión para modificar
        OrdenProvision = ORDENPROVISIONS
        datosordenprovision = OrdenProvision.DATOSORDENPROVISION
        OPNumero_numericupdown.Value = OrdenProvision.OrdenProvisionNumero
        OPyear_numericupdown.Value = OrdenProvision.OrdenProvisionYear
        Fechaconfeccion_datetimepicker.Value = OrdenProvision.Fechaconfeccionada_ordenprovision
        ORDENPROVISION_INICIADOR.Text = OrdenProvision.Iniciador
        ORDENPROVISION_DESTINO.Text = OrdenProvision.Destino
        ORDENPROVISION_LUGARENTREGA.Text = OrdenProvision.LugarEntrega
        'instrumento legal
        Instrumentolegal_combobox.SelectedIndex = ELEGIRCOMBOBOX(Instrumentolegal_combobox, OrdenProvision.TipoInstrumentoLegal)
        Instrumentolegal_numericupdown.Value = OrdenProvision.NumeroInstrumentoLegal
        Fecha_documento_DATETIMEPICKER.Value = OrdenProvision.FechaInstrumentoLegal
        yearinstrumentolegal_numericupdown.Value = OrdenProvision.YearInstrumentoLegal
        'Forma de adquisicion
        ORDENPROVISION_TIPO.SelectedIndex = ELEGIRCOMBOBOX(ORDENPROVISION_TIPO, OrdenProvision.TipoOrigen)
        OP_num_tipo_numericupdown.Value = OrdenProvision.NumeroOrigen
        OP_year_tipo_numericupdown.Value = OrdenProvision.YearOrigen
        Fecharealizada_datetimepicker.Value = OrdenProvision.fecharealizada_ordenprovision
        'TIEMPO DE ENTREGA
        cantidad_terminonumericupdown.Value = OrdenProvision.ValorTiempoEntrega
        unidad_terminonumericupdown.SelectedIndex = ELEGIRCOMBOBOX(unidad_terminonumericupdown, OrdenProvision.UnidadTiempoEntrega)
        Plazo_termino_textbox.Text = OrdenProvision.fechaobservaciones_ordenprovision
        'datos del proveedor
        Cuitdelbeneficiario_textbox.Text = OrdenProvision.CUIT
        'total de la orden de provisión
        Montototal.Value = OrdenProvision.Total
        'tabla de datos
        cargadedatagridview()
        Mostrardialogo(Me)
        encabezadodialogo()
        valoresiniciales = False
    End Sub

    Private Sub Cuit_boton_KeyDown(sender As Object, e As KeyEventArgs) Handles Cuit_boton.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Function Datagridview_todatatable(ByVal Datagrid As DataGridView) As DataTable
        Dim Tabladedatos As New DataTable
        'agrega las columnas y su tipo
        For x = 0 To Datagrid.Columns.Count - 1
            Tabladedatos.Columns.Add(Datagrid.Columns(x).Name)
        Next
        'Agrega las filas del datagridview celda por celda
        For Z = 0 To Datagrid.Rows.Count - 1
            For x = 0 To Datagrid.Columns.Count - 1
                Tabladedatos.Rows.Add()
                If Not IsNothing(Datagrid.Rows(Z).Cells.Item(x).Value) Then
                    Tabladedatos.Rows(Z).Item(x) = Datagrid.Rows(Z).Cells.Item(x).Value.ToString
                Else
                    Tabladedatos.Rows(Z).Item(x) = ""
                End If
            Next
        Next
        Return Tabladedatos
    End Function

    Private Sub guardardatosOP()
        OrdenProvision.OrdenProvisionNumero = OPNumero_numericupdown.Value
        OrdenProvision.OrdenProvisionYear = OPyear_numericupdown.Value
        OrdenProvision.ClaveOrdenProvision = CType(OrdenProvision.OrdenProvisionYear & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(OrdenProvision.OrdenProvisionNumero), "00000"), Long)
        'tabla de orden de provisión
        Datos_ordenprovision.EndEdit()
        Select Case Datos_ordenprovision.DataSource.GetType.FullName.ToString
            Case Is = "System.Data.DataTable"
                OrdenProvision.DATOSORDENPROVISION = Datos_ordenprovision.DataSource
            Case Is = "System.Data.DataView"
                OrdenProvision.DATOSORDENPROVISION = CType(Datos_ordenprovision.DataSource, DataView).ToTable
        End Select
        '/tabla de orden de provisión
        'Datos básicos de la orden de provisión
        OrdenProvision.Iniciador = ORDENPROVISION_INICIADOR.Text
        OrdenProvision.Destino = ORDENPROVISION_DESTINO.Text
        OrdenProvision.LugarEntrega = ORDENPROVISION_LUGARENTREGA.Text
        OrdenProvision.Fechaconfeccionada_ordenprovision = Fechaconfeccion_datetimepicker.Value
        'Datos del proveedor
        OrdenProvision.CUIT = Cuitdelbeneficiario_textbox.Text
        OrdenProvision.Nombre = Beneficiario_label.Text
        OrdenProvision.Domicilio_real = DOMICILIO.Text
        'Datos del tipo de acción utilizada para realizar el pedido
        OrdenProvision.fecharealizada_ordenprovision = Fecharealizada_datetimepicker.Value
        OrdenProvision.TipoOrigen = ORDENPROVISION_TIPO.SelectedItem.ToString
        OrdenProvision.NumeroOrigen = OP_num_tipo_numericupdown.Value
        OrdenProvision.YearOrigen = OP_year_tipo_numericupdown.Value
        'Instrumento legal habilitante a la acción de pedido
        OrdenProvision.TipoInstrumentoLegal = Instrumentolegal_combobox.SelectedItem.ToString
        OrdenProvision.NumeroInstrumentoLegal = Instrumentolegal_numericupdown.Value
        OrdenProvision.YearInstrumentoLegal = yearinstrumentolegal_numericupdown.Value
        OrdenProvision.FechaInstrumentoLegal = Fecha_documento_DATETIMEPICKER.Value
        'Tiempo de entrega determinado por la acción de pedido
        OrdenProvision.ValorTiempoEntrega = cantidad_terminonumericupdown.Value
        OrdenProvision.UnidadTiempoEntrega = unidad_terminonumericupdown.SelectedItem.ToString
        OrdenProvision.fechaobservaciones_ordenprovision = Plazo_termino_textbox.Text
        OrdenProvision.Cargardatos()
        'cantidad_terminonumericupdown
        'unidad_terminonumericupdown
        'Plazo_termino_textbox
        OrdenProvision.INSERTARORDENPROVISION()
    End Sub

    Private Sub Carga_orden_provision()
        If Not valoresiniciales Then
            OrdenProvision.OrdenProvisionNumero = OPNumero_numericupdown.Value
            OrdenProvision.OrdenProvisionYear = OPyear_numericupdown.Value
            OrdenProvision.ClaveOrdenProvision = CType(OrdenProvision.OrdenProvisionYear & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(OrdenProvision.OrdenProvisionNumero), "00000"), Long)
            'Datos básicos de la orden de provisión
            OrdenProvision.Iniciador = ORDENPROVISION_INICIADOR.Text
            OrdenProvision.Destino = ORDENPROVISION_DESTINO.Text
            OrdenProvision.LugarEntrega = ORDENPROVISION_LUGARENTREGA.Text
            'Datos del proveedor
            OrdenProvision.CUIT = Cuitdelbeneficiario_textbox.Text
            OrdenProvision.Nombre = Beneficiario_label.Text
            OrdenProvision.Domicilio_real = DOMICILIO.Text
            'Datos del tipo de acción utilizada para realizar el pedido
            OrdenProvision.fecharealizada_ordenprovision = Fecharealizada_datetimepicker.Value
            OrdenProvision.TipoOrigen = manejonothing(ORDENPROVISION_TIPO.SelectedItem)
            OrdenProvision.NumeroOrigen = OP_num_tipo_numericupdown.Value
            OrdenProvision.YearOrigen = OP_year_tipo_numericupdown.Value
            'Instrumento legal habilitante a la acción de pedido
            OrdenProvision.TipoInstrumentoLegal = manejonothing(Instrumentolegal_combobox.SelectedItem)
            OrdenProvision.NumeroInstrumentoLegal = Instrumentolegal_numericupdown.Value
            OrdenProvision.YearInstrumentoLegal = yearinstrumentolegal_numericupdown.Value
            OrdenProvision.FechaInstrumentoLegal = Fecha_documento_DATETIMEPICKER.Value
            'Tiempo de entrega determinado por la acción de pedido
            OrdenProvision.ValorTiempoEntrega = cantidad_terminonumericupdown.Value
            OrdenProvision.UnidadTiempoEntrega = manejonothing(unidad_terminonumericupdown.SelectedItem)
            OrdenProvision.fechaobservaciones_ordenprovision = Plazo_termino_textbox.Text
        Else
        End If
    End Sub

    Private Function manejonothing(ByVal elemento As Object) As String
        Dim valorretornado As String = ""
        If IsNothing(elemento) Then
            valorretornado = ""
        Else
            valorretornado = elemento.ToString
        End If
        Return valorretornado
    End Function

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
    End Sub

    Private Sub Cuit_boton_Click(sender As Object, e As EventArgs) Handles Cuit_boton.Click
        Dialogo_CUIT.Cargadetextbox(Cuitdelbeneficiario_textbox)
        Dialogo_CUIT.Cargadecuits(OrdenProvision.ClaveExpediente)
    End Sub

    Private Sub Label_montonombre_Click(sender As Object, e As EventArgs) Handles Label_montonombre.Click
    End Sub

    Private Sub Monto_factura_textbox_ValueChanged(sender As Object, e As EventArgs) Handles Montototal.ValueChanged
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Cuitdelbeneficiario_textbox_TextChanged(sender As Object, e As EventArgs) Handles Cuitdelbeneficiario_textbox.TextChanged
        cuit(sender)
    End Sub

    Private Sub cuit(ByVal sender As Object)
        If OPparamodificar And (sender.text.ToString.Replace("-", "").ToString.Replace(" ", "").Length > 10) Then
            VerificarCUIT(sender, sender.text, Beneficiario_label, DOMICILIO)
        Else
            PROVEEDORESCUIT(sender, sender.text, Beneficiario_label, DOMICILIO)
        End If
    End Sub

    Private Sub Datos_ordenprovision_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenprovision.CellValueChanged
        Select Case Datos_ordenprovision.Columns(e.ColumnIndex).Name.ToUpper
            Case Is = "RENG."
            Case Is = "CANT."
                Datos_ordenprovision.Rows(e.RowIndex).Cells.Item("PREC.TOTAL").Value = CALCULO_CANTIDADES(Datos_ordenprovision.Rows(e.RowIndex))
            Case Is = "UN."
            Case Is = "ARTICULOS."
            Case Is = "PREC.UNIT."
                Datos_ordenprovision.Rows(e.RowIndex).Cells.Item("PREC.TOTAL").Value = CALCULO_CANTIDADES(Datos_ordenprovision.Rows(e.RowIndex))
            Case Is = "PREC.TOTAL"
            Case Is = "DETALLE"
            Case Is = "ENCABEZADO"
        End Select
        Montototal.Value = Calculo_total()
    End Sub

    Private Function CALCULO_CANTIDADES(ByVal FILA As DataGridViewRow) As Decimal
        Dim PRECIOTOTAL As Decimal = 0
        If Not IsDBNull(FILA.Cells.Item("CANT.").Value) And Not IsDBNull(FILA.Cells.Item("PREC.UNIT.").Value) Then
            If FILA.Cells.Item("CANT.").Value > 0 And FILA.Cells.Item("PREC.UNIT.").Value > 0 Then
                PRECIOTOTAL = FILA.Cells.Item("CANT.").Value * FILA.Cells.Item("PREC.UNIT.").Value
            Else
                PRECIOTOTAL = 0
            End If
        Else
            PRECIOTOTAL = 0
        End If
        Return Math.Round(PRECIOTOTAL, 2)
    End Function

    Private Function Calculo_total() As Decimal
        Dim IMPORTETOTAL As Decimal = 0
        For x = 0 To Datos_ordenprovision.Rows.Count - 1
            Try
                If Not IsDBNull(Datos_ordenprovision.Rows(x).Cells.Item("PREC.TOTAL").Value) And Not (Datos_ordenprovision.Rows(x).Cells.Item("PREC.TOTAL").Value = 0) Then
                    ' IMPORTETOTAL += Datos_ordenprovision.Rows(x).Cells.Item("PREC.TOTAL").Value
                    IMPORTETOTAL += Datos_ordenprovision.Rows(x).Cells.Item("CANT.").Value * Datos_ordenprovision.Rows(x).Cells.Item("PREC.UNIT.").Value
                End If
            Catch ex As Exception
            End Try
        Next
        Return Math.Round(IMPORTETOTAL, 2)
    End Function

    Private Sub Datos_ordenprovision_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenprovision.RowEnter
        If Datos_ordenprovision.Rows.Count > 0 And Not (Datos_ordenprovision.Rows(e.RowIndex).Cells.Item("RENG.").Value > 0) Then
            Datos_ordenprovision.Rows(e.RowIndex).Cells.Item("RENG.").Value = e.RowIndex + 1
        End If
    End Sub

    Private Sub cantidad_terminonumericupdown_ValueChanged(sender As Object, e As EventArgs) Handles cantidad_terminonumericupdown.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub OPNumero_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles OPNumero_numericupdown.ValueChanged
        encabezadodialogo()
    End Sub

    Private Sub OPyear_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles OPyear_numericupdown.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub ORDENPROVISION_INICIADOR_TextChanged(sender As Object, e As EventArgs) Handles ORDENPROVISION_INICIADOR.TextChanged
        Carga_orden_provision()
    End Sub

    Private Sub ORDENPROVISION_DESTINO_TextChanged(sender As Object, e As EventArgs) Handles ORDENPROVISION_DESTINO.TextChanged
        Carga_orden_provision()
    End Sub

    Private Sub ORDENPROVISION_LUGARENTREGA_TextChanged(sender As Object, e As EventArgs) Handles ORDENPROVISION_LUGARENTREGA.TextChanged
        Carga_orden_provision()
    End Sub

    Private Sub Instrumentolegal_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Instrumentolegal_combobox.SelectedIndexChanged
        Carga_orden_provision()
        Decoradores()
    End Sub

    Private Sub Instrumentolegal_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Instrumentolegal_numericupdown.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub yearinstrumentolegal_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles yearinstrumentolegal_numericupdown.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub Fecha_documento_DATETIMEPICKER_ValueChanged(sender As Object, e As EventArgs) Handles Fecha_documento_DATETIMEPICKER.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub ORDENPROVISION_TIPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ORDENPROVISION_TIPO.SelectedIndexChanged
        Carga_orden_provision()
        Decoradores()
    End Sub

    Private Sub OP_num_tipo_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles OP_num_tipo_numericupdown.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub OP_year_tipo_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles OP_year_tipo_numericupdown.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub Fecharealizada_datetimepicker_ValueChanged(sender As Object, e As EventArgs) Handles Fecharealizada_datetimepicker.ValueChanged
        Carga_orden_provision()
    End Sub

    Private Sub Beneficiario_label_Click(sender As Object, e As EventArgs) Handles Beneficiario_label.Click
        Carga_orden_provision()
    End Sub

    Private Sub unidad_terminonumericupdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unidad_terminonumericupdown.SelectedIndexChanged
        Carga_orden_provision()
    End Sub

    Private Sub OPNumero_numericupdown_Leave(sender As Object, e As EventArgs) Handles OPNumero_numericupdown.Leave
        encabezadodialogo()
    End Sub

    Private Sub Decoradores()
        'Decoradores
        LabelFechaDocumentoLegal.Text = "Fecha " & manejonothing(Instrumentolegal_combobox.SelectedItem)
        LabelFechaAdquisicion.Text = "Fecha " & manejonothing(ORDENPROVISION_TIPO.SelectedItem)
    End Sub

    Private Sub Datos_ordenprovision_KeyDown(sender As Object, e As KeyEventArgs) Handles Datos_ordenprovision.KeyDown
        If e.KeyCode = Keys.Delete Then
            Select Case Datos_ordenprovision.SelectionMode
                Case Is = 1 'full row
                    For Each DataGridViewRow In Datos_ordenprovision.SelectedRows
                        Datos_ordenprovision.Rows.Remove(DataGridViewRow)
                    Next
                Case Is = 0 ' cell select
                    For Each DataGridViewCell In Datos_ordenprovision.SelectedCells
                        Select Case DataGridViewCell.value.GetType.ToString
                            Case Is = "System.Int32"
                                DataGridViewCell.VALUE = 0
                            Case Is = "System.Decimal"
                                DataGridViewCell.VALUE = 0
                            Case Is = "System.String"
                                DataGridViewCell.VALUE = ""
                            Case Is = ""
                            Case Else
                                DataGridViewCell.VALUE = Nothing
                        End Select
                        DataGridViewCell.VALUE = Nothing
                    Next
            End Select
        End If
    End Sub

    Private Sub Datos_ordenprovision_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datos_ordenprovision.DataError
        Datos_ordenprovision.Rows(e.RowIndex).ErrorText = "La celda no admite este tipo de datos, presione Escape si desea cancelar la modificación"
        MessageBox.Show(Datos_ordenprovision.Rows(e.RowIndex).ErrorText)
        e.Cancel = True
        'Select Case e.Exception.Message
        '    Case Is = "La cadena de entrada no tiene el formato correcto."
        '        Select Case sender.VALUEtype.GetType.ToString
        '            Case Is = "System.Int32"
        '                MessageBox.Show("Esta celda solo admite números enteros")
        '            Case Is = "System.Decimal"
        '                MessageBox.Show("Esta celda solo admite números")
        '            Case Is = "System.String"
        '                MessageBox.Show("Texto")
        '        End Select
        '    Case Else
        '        MessageBox.Show(e.Exception.Message)
        'End Select
    End Sub

    Private Sub Datos_ordenprovision_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_ordenprovision.RowHeaderMouseClick
        Select Case Datos_ordenprovision.SelectionMode
            Case Is = 1 'fullrow
                Datos_ordenprovision.SelectionMode = DataGridViewSelectionMode.CellSelect
            Case Is = 0 ' cellselect
                Datos_ordenprovision.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Datos_ordenprovision.Rows(e.RowIndex).Selected = True
        End Select
    End Sub

    Private Sub Guardar_boton_Click(sender As Object, e As EventArgs) Handles Guardar_boton.Click
        Select Case MsgBox("Desea Guardar los Cambios introducidos?", MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                If ADVERTENCIA_COHERENCIA() = "" Then
                    guardardatosOP()
                    MessageBox.Show("Guardado exitosamente")
                Else
                    MessageBox.Show(ADVERTENCIA_COHERENCIA())
                    MessageBox.Show("Los datos no se guardaron")
                End If
            Case MsgBoxResult.No
                MessageBox.Show("Los datos no se guardaron")
        End Select
    End Sub

    Private Sub Guardar_eimprimir_boton_Click(sender As Object, e As EventArgs) Handles Guardar_eimprimir_boton.Click
        Select Case MsgBox("Desea Guardar los Cambios introducidos?", MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                If ADVERTENCIA_COHERENCIA() = "" Then
                    guardardatosOP()
                    MessageBox.Show("Guardado exitosamente")
                    'PDF_ordenProvision(ORDENPROVISION, "A4", tamaniofuente_numericupdown.Value)
                    PDF_ordenProvisionv2(OrdenProvision)
                Else
                    MessageBox.Show(ADVERTENCIA_COHERENCIA())
                    MessageBox.Show("Los datos no se guardaron")
                End If
            Case MsgBoxResult.No
                MessageBox.Show("Los datos no se guardaron")
        End Select
    End Sub

    Private Function ADVERTENCIA_COHERENCIA() As String
        Dim listadeMessages As New List(Of String)
        Dim Message As String = ""
        'If OPyear_numericupdown.Value <> Autorizaciones.Year Then
        '    listadeMessages.Add("El año ingresado para la orden de Provisión (" & OPyear_numericupdown.Value & ") es distinto del año del ejercicio financiero (" & Autorizaciones.Year & ")")
        'End If
        For Each item As String In listadeMessages
            Message += item & vbCrLf
        Next
        Return Message
    End Function

    Private Sub Datos_ordenprovision_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_ordenprovision.MouseUp
        Inicio.MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub Datos_ordenprovision_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenprovision.CellLeave
    End Sub

    Private Sub Datos_ordenprovision_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_ordenprovision.CellEndEdit
    End Sub

    Private Sub Datos_ordenprovision_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Datos_ordenprovision.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Datos_ordenprovision_KeyPress
        'Dim editingControl As TextBox = TryCast(e.Control, TextBox)
        'If editingControl IsNot Nothing Then
        '    e.Control.KeyPress = New KeyPressEventHandler(Datos_ordenprovision_KeyPress)
        '    editingControl.CharacterCasing = CharacterCasing.Upper
        'End If
    End Sub

    Private Sub Datos_ordenprovision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Datos_ordenprovision.KeyPress
        'If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = "," Or e.KeyChar = ".") Then
        '    e.Handled = True
        'Else
        If e.KeyChar = "." Then
            For Each DataGridViewCell In Datos_ordenprovision.SelectedCells
                Select Case DataGridViewCell.value.GetType.ToString
                    Case Is = "System.Decimal"
                        e.KeyChar = ","
                    Case Else
                        e.KeyChar = "."
                End Select
            Next
        End If
    End Sub

    Private Sub Datos_ordenprovision_MouseDoubleClick(sender As DataGridView, e As MouseEventArgs) Handles Datos_ordenprovision.MouseDoubleClick
        Select Case sender.DataSource.GetType.Name
            Case Is = "DataView"
                Dialogo_ModificarDatatable.CargarDatatable(Me, CType(sender.DataSource, DataView).ToTable, sender, OrdenProvision.ClaveExpediente)
            Case Else
                Dialogo_ModificarDatatable.CargarDatatable(Me, CType(sender.DataSource, DataTable), sender, OrdenProvision.ClaveExpediente)
        End Select
        For x = 0 To Datos_ordenprovision.Rows.Count - 1
            Datos_ordenprovision.Rows(x).Cells.Item("PREC.TOTAL").Value = CALCULO_CANTIDADES(Datos_ordenprovision.Rows(x))
        Next
        sender.Refresh()
    End Sub

    Private Sub FullScreen_boton_Click(sender As Object, e As EventArgs) Handles FullScreen_boton.Click
        Select Case Me.WindowState
            Case = WindowState.Maximized
                Me.WindowState = FormWindowState.Normal
            Case Else
                Me.WindowState = FormWindowState.Maximized
        End Select
    End Sub

    Private Sub Constancia_Boton_Click(sender As Object, e As EventArgs) Handles Constancia_Boton.Click
    End Sub

End Class