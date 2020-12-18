Public Class Contabilidad_DialogoHaberes
    'Public ORDENPAGO As New Ordendepago
    Dim ordenpago_actual As New Ordendepago
    Dim NUEVAOP As Boolean = False
    Dim valoresiniciales As Boolean = True
    Dim claveguardada As Long = 0

    Private Sub Datos_ActasRecepcion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_DetalleHaberes.CellContentClick
    End Sub

    Public Sub Cargadedatos(ByVal ordenpago As Ordendepago, ByVal NUEVO As Boolean)
        valoresiniciales = True
        NUEVAOP = NUEVO
        OPNumero_numericupdown.Value = ordenpago.ordenpago_numero
        OPyear_numericupdown.Value = ordenpago.Ordenpago_Year
        If Not NUEVO Then
            OPNumero_numericupdown.Enabled = False
            OPyear_numericupdown.Enabled = False
        Else
            OPNumero_numericupdown.Enabled = True
            OPyear_numericupdown.Enabled = True
        End If
        If ordenpago.ClaveExpediente_principal > 0 Then
            Organismo_numericupdown.Value = CType(ordenpago.ClaveExpediente_principal.ToString.Substring(4, 4), UInteger)
            Numeroexpediente_numericupdown.Value = CType(ordenpago.ClaveExpediente_principal.ToString.Substring(8, 5), UInteger)
            Year_numericupdown.Value = CType(ordenpago.ClaveExpediente_principal.ToString.Substring(0, 4), UInteger)
        Else
            Organismo_numericupdown.Value = 0
            Numeroexpediente_numericupdown.Value = 0
            Year_numericupdown.Value = Autorizaciones.Year
        End If
        Fechaconfeccion_datetimepicker.Value = ordenpago.ordenpago_fecha
        ordenpago_detalles.Text = ordenpago.ordenpago_Detalle
        LIQUIDACIONAPAGAR_NUMERICUPDOWN.Value = ordenpago.Haberes_liquidacionapagar
        Datos_DetalleHaberes.DataSource = ordenpago.Cargar_Haberes_Estructura_detalles(ordenpago.Clave_ordenpago)
        Datos_DetalleHaberes.Columns("IMPORTE").DefaultCellStyle.Format = "C"
        Datos_DetalleHaberes.Columns("SPL01").Visible = False
        Datos_DetalleHaberes.Columns("SPL02").Visible = False
        Datos_DetalleHaberes.Columns("SPL03").Visible = False
        Datos_DetalleHaberes.Columns("SPL04").Visible = False
        Datos_DetalleHaberes.Columns("SPL05").Visible = False
        Datos_DetalleHaberes.Columns("SPL06").Visible = False
        Datos_DetalleHaberes.Columns("SPL07").Visible = False
        Datos_Partidas.DataSource = PartidaPresupuestaria.estructurapartidadatatable(ordenpago.Clave_ordenpago)
        Datos_Partidas.Columns("IMPORTE").DefaultCellStyle.Format = "C"
        ordenpago_actual = ordenpago
        valoresiniciales = False
        Me.ShowDialog()
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Private Sub Contabilidad_DialogoHaberes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub

    Private Sub DOBLE_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Datos_Partidas.CellMouseDoubleClick, Datos_DetalleHaberes.CellMouseDoubleClick
        'Cargaymodificaciondatatable(Me, CType(sender.DataSource, DataTable), sender)
        Dialogo_ModificarDatatable.CargarDatatable(Me, CType(sender.DataSource, DataTable), sender, ordenpago_actual.expediente_op.claveexpediente)
        sender.Refresh()
        sender.CurrentCell = Nothing
    End Sub

    Private Sub Row_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_DetalleHaberes.RowValidated, Datos_Partidas.RowValidated
        Calcular()
    End Sub

    Private Sub Calcular()
        Dim TOTALDETALLEHABERES As Decimal = 0
        Dim TOTALPARTIDAS As Decimal = 0
        For O As Integer = 0 To Datos_DetalleHaberes.Rows.Count - 1
            TOTALDETALLEHABERES += Datos_DetalleHaberes.Rows(O).Cells.Item("IMPORTE").Value
        Next
        For P As Integer = 0 To Datos_Partidas.Rows.Count - 1
            TOTALPARTIDAS += Datos_Partidas.Rows(P).Cells.Item("IMPORTE").Value
        Next
        Montototal.Value = TOTALDETALLEHABERES + LIQUIDACIONAPAGAR_NUMERICUPDOWN.Value
        PARTIDAS_TOTALNUMERICAUPDOWN.Value = TOTALPARTIDAS
    End Sub

    Private Sub Datos_DetalleHaberes_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_DetalleHaberes.ColumnHeaderMouseDoubleClick
    End Sub

    'Private Sub DOBLE_MouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_Partidas.CellMouseDoubleClick, Datos_DetalleHaberes.CellMouseDoubleClick
    'End Sub
    Private Sub Datos_Partidas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Datos_Partidas.MouseDoubleClick, Datos_DetalleHaberes.MouseDoubleClick
        If sender.ROWS.COUNT > -1 Then
            Dialogo_ModificarDatatable.CargarDatatable(Me, CType(sender.DataSource, DataTable), sender, ordenpago_actual.expediente_op.claveexpediente, ordenpago_actual.Clave_ordenpago)
            sender.Refresh()
        End If
    End Sub

    Private Sub Guardar_boton_Click(sender As Object, e As EventArgs) Handles Guardar_boton.Click
        Select Case MsgBox("Desea Guardar los Cambios introducidos?", MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                If ADVERTENCIA_COHERENCIA() = "" Then
                    guardardatosOP()
                    MessageBox.Show("GUARDADO EXITOSAMENTE.")
                Else
                    MessageBox.Show(ADVERTENCIA_COHERENCIA())
                End If
            Case MsgBoxResult.No
                MessageBox.Show("Los datos no se guardaron")
        End Select
    End Sub

    Private Function ADVERTENCIA_COHERENCIA() As String
        Dim Message As String = ""
        If NUEVAOP Or OPNumero_numericupdown.Enabled Then
            If ordenpago_actual.verificarexistencia(ordenpago_actual.Clave_ordenpago) Then
                Message += " ESTE NÚMERO DE ORDEN DE PAGO ESTA EN USO, POR FAVOR MODIFIQUELO "
            End If
        End If
        If (Montototal.Value = PARTIDAS_TOTALNUMERICAUPDOWN.Value) Or Datos_Partidas.Rows.Count = 0 Then
            Message += ""
        Else
            Message += " Actualmente existe una diferencia de " & CType(Math.Abs(Montototal.Value - PARTIDAS_TOTALNUMERICAUPDOWN.Value), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & vbCrLf & " No se guardaran los datos por favor verifique"
        End If
        Return Message
    End Function

    Private Sub Guardar_eimprimir_boton_Click(sender As Object, e As EventArgs) Handles Guardar_eimprimir_boton.Click
        Select Case MsgBox("Desea Guardar los Cambios introducidos?", MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                If ADVERTENCIA_COHERENCIA() = "" Then
                    guardardatosOP()
                    PDF_ORDENPAGO_HABERESv2(ordenpago_actual) 'PDF_ORDENPAGO_HABERES(ordenpago_actual, "LEGAL")
                Else
                    MessageBox.Show(ADVERTENCIA_COHERENCIA())
                End If
            Case MsgBoxResult.No
                MessageBox.Show("Los datos no se guardaron")
        End Select
    End Sub

    Private Sub guardardatosOP()
        Dim indiceaborrar As New List(Of DataRow)
        ordenpago_actual.ordenpago_numero = OPNumero_numericupdown.Value
        ordenpago_actual.ordenpago_Detalle = ordenpago_detalles.Text
        ordenpago_actual.ordenpago_Detalle2 = ordenpago_detalles2.Text
        ordenpago_actual.Ordenpago_Year = OPyear_numericupdown.Value
        ordenpago_actual.Ordenpago_tipo = "HABERES"
        ordenpago_actual.Clave_ordenpago = CType(OPyear_numericupdown.Value & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(OPNumero_numericupdown.Value), "00000"), Long)
        ordenpago_actual.Haberes_liquidacionapagar = LIQUIDACIONAPAGAR_NUMERICUPDOWN.Value
        ordenpago_actual.Haberes_recuperovarios = Recupero_varios_numericupdown.Value
        ordenpago_actual.ACTAS.Clear()
        ordenpago_actual.HABERES_DETALLE = (CType(Datos_DetalleHaberes.DataSource, DataTable))
        If Numeroexpediente_numericupdown.Value > 0 And Organismo_numericupdown.Value > 0 Then
            ordenpago_actual.ClaveExpediente_principal = CType(Year_numericupdown.Value & Organismo_numericupdown.Value & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
        Else
        End If
        ordenpago_actual.Partida_datatable = CType(Datos_Partidas.DataSource, DataTable)
        For Each ROW As DataRow In ordenpago_actual.Partida_datatable.Rows
            If ROW.Item("IMPORTE") = 0 Then
                indiceaborrar.Add(ROW)
            End If
        Next
        For Each ROW As DataRow In indiceaborrar
            ordenpago_actual.Partida_datatable.Rows.Remove(ROW)
        Next
        ordenpago_actual.Partidas.Clear()
        ordenpago_actual.Datatable_a_Partidas()
        ordenpago_actual.ordenpago_montototal = Montototal.Value
        ordenpago_actual.ordenpago_USUARIO = Autorizaciones.Usuario.Rows(0).Item("USUARIO")
        'tabla de orden de provisión
        ordenpago_actual.DatosOrdenPago = CType(Datos_Partidas.DataSource, DataTable)
        '/tabla de orden de provisión
        ordenpago_actual.Insertar_ordenpago()
        claveguardada = ordenpago_actual.Clave_ordenpago
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter
    End Sub

    Private Sub Recupero_varios_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Recupero_varios_numericupdown.ValueChanged
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub FullScreen_boton_Click(sender As Object, e As EventArgs) Handles FullScreen_boton.Click
        Select Case Me.WindowState
            Case = WindowState.Maximized
                Me.WindowState = FormWindowState.Normal
            Case Else
                Me.WindowState = FormWindowState.Maximized
        End Select
    End Sub

    Private Sub Recupero_varios_numericupdown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Recupero_varios_numericupdown.KeyPress
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub LIQUIDACIONAPAGAR_NUMERICUPDOWN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LIQUIDACIONAPAGAR_NUMERICUPDOWN.KeyPress
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub OPNumero_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles OPNumero_numericupdown.ValueChanged
        If Not valoresiniciales Then
            ordenpago_actual.Clave_ordenpago = CType(OPyear_numericupdown.Value & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(OPNumero_numericupdown.Value), "00000"), Long)
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub CARGAR_PARTIDAS_SUGERIDAS()
        'Datos_Partidas
        Dim DATOS_PARTIDAS_TABLA As New DataTable
        DATOS_PARTIDAS_TABLA = CType(Datos_Partidas.DataSource, DataTable)
        Dim datos As New DataTable
        datos.Columns.Add("JUR", System.Type.GetType("System.String"))
        datos.Columns.Add("U.O", System.Type.GetType("System.String"))
        datos.Columns.Add("CARAC", System.Type.GetType("System.String"))
        datos.Columns.Add("FIN", System.Type.GetType("System.String"))
        datos.Columns.Add("FUN", System.Type.GetType("System.String"))
        datos.Columns.Add("SECC", System.Type.GetType("System.String"))
        datos.Columns.Add("SECT", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA PPAL", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA PCIAL.", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA SUB PAR", System.Type.GetType("System.String"))
        datos.Columns.Add("SCD", System.Type.GetType("System.String"))
        datos.Columns.Add("IMPORTE", System.Type.GetType("System.Decimal"))
        Select Case ordenpago_actual.Ordenpago_tipo
            Case Is = "HABERES"
                Dim tabla_temporal As New DataTable
                With tabla_temporal
                    With .Columns
                        .Add("TIPO")
                        .Add("Descripción")
                    End With
                    With .Rows
                        .Add("PLANTA PERMANENTE", "   ")
                        .Add("GUARDIAS PLANTA PERMANENTE", "   ")
                        .Add("PLANTA TEMPORARIA", "   ")
                        .Add("GUARDIAS PLANTA TEMPORARIA", "   ")
                        .Add("RETIRO VOLUNTARIO", "   ")
                        .Add("RESIDENCIAS MEDICAS Y GUARDIAS DE RESIDENTES", "   ")
                        .Add("AGENTES SANITARIOS Y GUARDIAS AGENTES SANITARIOS", "   ")
                        .Add("PTA PERMANENTE SEC.DE ESTADO DE PREV. DE ADICCIONES Y CONTROL DE DROGAS", "   ")
                        .Add("PTA TEMPORARIA SEC.DE ESTADO DE PREV. DE ADICCIONES Y CONTROL DE DROGAS", "   ")
                        .Add("GUARDIAS PERSONAL TEMPORARIO PARTE DE LA SALUD RAMON MADARIAGA", "   ")
                    End With
                End With
                Dim Tipo As String = ""
                DialogDialogo_Datagridview.Carga_General(tabla_temporal, "Seleccione por el tipo de formulario de HAberes", "Seleccionar", "Cancelar", 10)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    Tipo = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
                Else
                End If
                'Select Case Tipo
                '    Case
                'End Select
                'DialogDialogo_Datagridview()
                Select Case Tipo
                    Case Is = "PLANTA PERMANENTE"
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01110", "", "", 0})
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01140", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01110", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01140", "", "", 0})
                    Case Is = "GUARDIAS PLANTA PERMANENTE"
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01110", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01110", "", "", 0})
                    Case Is = "PLANTA TEMPORARIA"
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01120", "", "", 0})
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01140", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01120", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01140", "", "", 0})
                    Case Is = "GUARDIAS PLANTA TEMPORARIA"
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01120", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01120", "", "", 0})
                    Case Is = "RETIRO VOLUNTARIO"
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "03", "031", "03180", "", "", 0})
                    Case Is = "RESIDENCIAS MEDICAS Y GUARDIAS DE RESIDENTES"
                        datos.Rows.Add({"06", "01", "0-02", "3", "10", "1", "01", "011", "01120", "", "", 0})
                    Case Is = "AGENTES SANITARIOS Y GUARDIAS AGENTES SANITARIOS"
                        datos.Rows.Add({"06", "01", "0-03", "3", "10", "1", "01", "011", "01120", "", "", 0})
                    Case Is = "PTA PERMANENTE SEC.DE ESTADO DE PREV. DE ADICCIONES Y CONTROL DE DROGAS"
                        datos.Rows.Add({"20", "01", "0", "4", "90", "1", "01", "011", "01110", "", "", 0})
                    Case Is = "PTA TEMPORARIA SEC.DE ESTADO DE PREV. DE ADICCIONES Y CONTROL DE DROGAS"
                        datos.Rows.Add({"20", "01", "0", "4", "90", "1", "01", "011", "01120", "", "", 0})
                    Case Is = "GUARDIAS PERSONAL TEMPORARIO PARTE DE LA SALUD RAMON MADARIAGA"
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01120", "", "", 0})
                    Case Else
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01120", "", "", 0})
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01110", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01120", "", "", 0})
                        datos.Rows.Add({"06", "01", "0-03", "3", "10", "1", "01", "011", "01120", "", "", 0})
                        datos.Rows.Add({"06", "01", "0-02", "3", "10", "1", "01", "011", "01120", "", "", 0})
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01100", "", "", 0})
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "01", "011", "01140", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01140", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "90", "0", "01", "011", "01110", "", "", 0})
                        datos.Rows.Add({"20", "01", "0", "4", "90", "1", "01", "011", "01110", "", "", 0})
                        datos.Rows.Add({"06", "01", "0", "3", "10", "1", "03", "031", "03180", "", "", 0})
                        datos.Rows.Add({"06", "02", "0", "4", "9", "0", "01", "011", "01110", "", "", 0})
                End Select
            Case Else
        End Select
        Dim CONTROLEXISTENCIA As Boolean
        Dim PARCIALCARGADO As String = ""
        Dim PARCIALACARGAR As String = ""
        For X = 0 To datos.Rows.Count - 1
            For N = 0 To datos.Columns.Count - 2
                PARCIALACARGAR += datos.Rows(X).Item(N).ToString
            Next
            CONTROLEXISTENCIA = True
            For Z = 0 To Datos_Partidas.Rows.Count - 1
                For N = 0 To Datos_Partidas.Columns.Count - 2
                    PARCIALCARGADO += Datos_Partidas.Rows(Z).Cells.Item(N).Value.ToString
                    'PARCIALACARGAR += datos.Rows(X).Item(N).ToString
                Next
                If PARCIALCARGADO = PARCIALACARGAR Then
                    CONTROLEXISTENCIA = False
                    Exit For
                End If
            Next
            If CONTROLEXISTENCIA Then
                DATOS_PARTIDAS_TABLA.Rows.Add()
                For N = 0 To Datos_Partidas.Columns.Count - 1
                    DATOS_PARTIDAS_TABLA.Rows(DATOS_PARTIDAS_TABLA.Rows.Count - 1).Item(N) = datos.Rows(X).Item(N)
                Next
            End If
            PARCIALCARGADO = ""
            PARCIALACARGAR = ""
        Next
        Datos_Partidas.DataSource = DATOS_PARTIDAS_TABLA
    End Sub

    Private Sub Sugerencia_partidas_Click(sender As Object, e As EventArgs) Handles Sugerencia_partidas.Click
        CARGAR_PARTIDAS_SUGERIDAS()
    End Sub

    Private Sub Datos_Partidas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datos_Partidas.DataError
    End Sub

End Class