Public Class Contabilidad_DialogoOrdenpago_multiple
    Public ORDENPAGO As New Ordendepago
    Dim ordendeprovision As New OrdenProvision
    Dim actarecepcion As New ACTARECEPCION
    Dim TOTALACTASRECEPCION As Decimal = 0
    Dim TOTALPARTIDAS As Decimal = 0
    Dim TOTALORDENESPROVISION As Decimal = 0
    Dim valoresiniciales As Boolean = True
    Dim OPparamodificar As Boolean = False
    Dim valoresmodificados As Boolean = False
    Dim claveguardada As Long = 0
    Dim TABLAORIGEN As New DataTable
    Dim TABLAINSTRUMENTOLEGAL As New DataTable
    'NECESARIOS PARA CARGA AUTOMATICA FONDOS PERMANENTES
    Dim EFECTOR_FONDOPERMANENTE As String = ""
    Dim ORDENCARGO_FONDOPERMANENTE As String = ""
    Dim EXPEDIENTE_FONDOPERMANENTE As String = ""
    '/NECESARIOS PARA CARGA AUTOMATICA FONDOS PERMANENTES
    Dim NUEVAOP As Boolean = False
    Dim ordenpagovieja As New Ordendepago  'en caso de modificar se verifica los valores básicos necesarios.

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs)
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        If valoresmodificados Then
            Select Case MsgBox("ha introducido cambios a la Orden de pago que se encuentran sin guardar, esta seguro de salir?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    Me.Close()
                Case MsgBoxResult.No
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Numeroexpediente_numericupdown_Enter(sender As Object, e As EventArgs) Handles Numeroexpediente_numericupdown.Enter
        If (sender.GetType.ToString = "System.Windows.Forms.TextBox") Or (sender.GetType.ToString = "System.Windows.Forms.MaskedTextBox") Then
        Else
            sender.Select(0, sender.text.ToString.Length)
        End If
    End Sub

    Private Sub Suministros_ordenpago_Load(sender As Object, e As EventArgs)
        Dim lugares As New DataTable
        '  Inicio.Cargadetextboxautcompleteonload2(ordenpago_LUGARENTREGA, "Select nombre from suministros_lugar_entrega order by lugar_clave ", "Nombre")
        ' unidad_terminonumericupdown.Items.AddRange({"DÍAS", "DÍAS HÁBILES", "SEMANAS", "MESES"})
        CARGADETABLAS()
    End Sub

    Private Sub Suministros_ordenpago_Shown(sender As Object, e As EventArgs)
        If OPparamodificar Then
        Else
            'cambiosdatostexto()
        End If
        'Datos_ordenpago.Columns("Reng.").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'Datos_ordenpago.Columns("Cant.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_ordenpago.Columns("Un.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_ordenpago.Columns("Prec.Unit.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_ordenpago.Columns("Prec.Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_ordenpago.Columns("Articulos.").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'Datos_ordenpago.Columns("Detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ''Todo a cero
    End Sub

    Private Sub cambiosdatostexto()
        Select Case ORDENPAGO.Ordenpago_tipo.ToUpper
            Case Is = "ARANCELAMIENTO"
            Case Is = "HABERES"
            Case Is = "PAGO"
            Case Is = "PAGO MULTIPLES EFECTORES"
            Case Is = "TRANSFERENCIA"
            Case Is = "REDETERMINACIÓN"
            Case Is = "RENDICIÓN"
            Case Is = "RENDICIÓN FINAL"
            Case Is = "RENDICIÓN PARCIAL"
            Case Is = "RECONOCIMIENTO"
                'ordenpago_detalles.Text = " Pago por comisión de servicios iniciado por "
                DETALLESUGERENCIAVALORES()
            Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                DETALLESUGERENCIAVALORES()
            Case Is = "VIÁTICOS"
                ordenpago_detalles.Text = " Pago por comisión de servicios iniciado por "
            Case Is = "REPOSICIÓN"
                Dim DECRETOS() As String = Nothing
                Dim RESOLUCIONES() As String = Nothing
                ordenpago_detalles.Text = " DE FONDOS PERMANENTES INSTITUIDO POR "
                For X = 0 To Datos_Ordenesprovision.Rows.Count - 1
                    Select Case Datos_Ordenesprovision.Rows(X).Cells.Item("TIPO_INSTRUMENTOLEGAL").Value.ToString.Replace(" ", "").ToUpper
                        Case Is = "DECRETO"
                            DECRETOS.Add(Datos_Ordenesprovision.Rows(X).Cells.Item("NUMERO_INSTRUMENTOLEGAL").Value.ToString & "/" & Datos_Ordenesprovision.Rows(X).Cells.Item("YEAR_INSTRUMENTO_LEGAL").Value.ToString)
                        Case Is = "RESOLUCIÓN"
                            RESOLUCIONES.Add(Datos_Ordenesprovision.Rows(X).Cells.Item("NUMERO_INSTRUMENTOLEGAL").Value.ToString & "/" & Datos_Ordenesprovision.Rows(X).Cells.Item("YEAR_INSTRUMENTO_LEGAL").Value.ToString)
                    End Select
                Next
                'DECRETOS
                If Not IsNothing(DECRETOS) Then
                    Select Case DECRETOS.Count
                        Case = 0
                        Case = 1
                            ordenpago_detalles.Text += "DECRETO Nº " & DECRETOS(0)
                        Case Else
                            For Z = 0 To DECRETOS.Count - 1
                                If Z = DECRETOS.Count - 1 Then
                                    ordenpago_detalles.Text += " y " & DECRETOS(Z)
                                ElseIf Z = 0 Then
                                    ordenpago_detalles.Text += "DECRETO Nº " & DECRETOS(0)
                                Else
                                    ordenpago_detalles.Text += ", " & DECRETOS(Z)
                                End If
                            Next
                    End Select
                End If
                'RESOLUCIONES
                If Not IsNothing(RESOLUCIONES) Then
                    Select Case RESOLUCIONES.Count
                        Case = 0
                        Case = 1
                            ordenpago_detalles.Text += " - RESOLUCIÓN Nº " & RESOLUCIONES(0)
                        Case Else
                            For Z = 0 To RESOLUCIONES.Count - 1
                                If Z = RESOLUCIONES.Count - 1 Then
                                    ordenpago_detalles.Text += " y " & RESOLUCIONES(Z)
                                ElseIf Z = 0 Then
                                    ordenpago_detalles.Text += " - RESOLUCIÓN Nº" & RESOLUCIONES(0)
                                Else
                                    ordenpago_detalles.Text += ", " & RESOLUCIONES(Z)
                                End If
                            Next
                    End Select
                End If
                ordenpago_detalles.Text += " ORDEN DE CARGO Nº " & ORDENCARGO_FONDOPERMANENTE & vbCrLf & " EXPTE. INST. N° 6300-098/2019"
                Dim VARIABLE As String() = Divisordetresvariables(EXPEDIENTE_FONDOPERMANENTE)
                If Not EXPEDIENTE_FONDOPERMANENTE = "" Then
                    Organismo_numericupdown.Value = VARIABLE(0)
                    Numeroexpediente_numericupdown.Value = VARIABLE(1)
                    Year_numericupdown.Value = VARIABLE(2)
                End If
            Case Is = "CONTRATOS"
            Case Is = "BECAS"
            Case Is = "COMISIÓN BANCARIA"
        End Select
    End Sub

    Private Sub DETALLESUGERENCIAVALORES()
        Dim textodetalle As String = ""
        Dim DESTINOS As New List(Of String)
        Dim ORDENES As New List(Of String)
        Dim ORIGEN As New List(Of String)
        Dim INSTRUMENTOLEGAL As New List(Of String)
        Dim EFECTORES As New List(Of String)
        Dim PERIODOS As New List(Of String)
        'Orden_provision
        'Monto
        'Tipo_Legal
        'Num_instrumento
        'Tipo_origen
        'num_origen
        'CUIT
        'Acta_recepcion
        'Fecha_acta
        'Monto_acta
        'Detalle_acta
        'Periodo
        'Efector
        Dim ACTASRECEPCION As List(Of String) = Nothing
        Select Case ORDENPAGO.SINACTAS.Count > 0
            Case True
                For Each SINACTA As SINACTARECEPCION In ORDENPAGO.SINACTAS
                    'CARGA CADA UNO DE LOS DESTINOS
                    If IsNothing(DESTINOS) Then
                        DESTINOS.Add(SINACTA.ACTARECEPCION_EFECTOR)
                    Else
                        If Not DESTINOS.Contains(SINACTA.ACTARECEPCION_EFECTOR) Then
                            DESTINOS.Add(SINACTA.ACTARECEPCION_EFECTOR)
                        End If
                    End If
                    'CARGA CADA UNO DE LOS EFECTORES
                    If IsNothing(EFECTORES) Then
                        EFECTORES.Add(SINACTA.EFECTOR)
                    Else
                        If Not EFECTORES.Contains(SINACTA.EFECTOR) Then
                            EFECTORES.Add(SINACTA.EFECTOR)
                        End If
                    End If
                    'CARGA CADA UNO DE LOS PERIODOS
                    If IsNothing(PERIODOS) Then
                        PERIODOS.Add(SINACTA.PERIODO)
                    Else
                        If Not PERIODOS.Contains(SINACTA.PERIODO) Then
                            PERIODOS.Add(SINACTA.PERIODO)
                        End If
                    End If
                    'CARGA LOS  INSTRUMENTOS LEGALES
                    If IsNothing(INSTRUMENTOLEGAL) Then
                        INSTRUMENTOLEGAL.Add(SINACTA.Tipo_instrumentolegal & " Nº " & SINACTA.Numero_instrumentolegal & "/" & SINACTA.Year_instrumento_legal)
                    Else
                        If Not INSTRUMENTOLEGAL.Contains(SINACTA.Tipo_instrumentolegal & " Nº " & SINACTA.Numero_instrumentolegal & "/" & SINACTA.Year_instrumento_legal) Then
                            INSTRUMENTOLEGAL.Add(SINACTA.Tipo_instrumentolegal & " Nº " & SINACTA.Numero_instrumentolegal & "/" & SINACTA.Year_instrumento_legal)
                        End If
                    End If
                Next
                ''CARGA LAS ACTAS DE RECEPCIÓN
                'For Each AC As ACTARECEPCION In ORDENPAGO.ACTAS
                '    If Not ACTASRECEPCION.Contains(AC.ACTARECEPCION_NUMERO & "/" & AC.ACTARECEPCION_YEAR) Then
                '        ACTASRECEPCION.Add(AC.ACTARECEPCION_NUMERO & "/" & AC.ACTARECEPCION_YEAR)
                '    End If
                'Next
                Select Case ORDENPAGO.SINACTAS.Count
                    Case = 0
                        textodetalle += "POR  "
                       ' textodetalle += " SEGÚN ORD. PROV. Nº 0/" & ORDENPAGO.Ordenpago_Year
                    Case = 1
                        textodetalle += "POR   " & Datos_Ordenesprovision.Rows(0).Cells.Item("DETALLE").Value
                        'textodetalle += " SEGÚN ORD. PROV. Nº " & ORDENES(0)
                    Case Else
                        textodetalle += "POR  "
                        'textodetalle += " SEGÚN LAS ORD. PROV. Nros: "
                        For x = 0 To ORDENPAGO.SINACTAS.Count - 1
                            If x = ORDENPAGO.SINACTAS.Count - 1 Then
                                textodetalle += ORDENPAGO.SINACTAS(x).Detalle & " "
                                If ORDENPAGO.SINACTAS(x).EFECTOR.Length > 0 Then
                                    textodetalle += ORDENPAGO.SINACTAS(x).EFECTOR & " "
                                End If
                            Else
                                textodetalle += ORDENPAGO.SINACTAS(x).Detalle & " , "
                            End If
                        Next
                End Select
                Select Case PERIODOS.Count
                    Case = 0
                        textodetalle += " "
                    Case = 1
                        textodetalle += " EN EL PERIODO " & PERIODOS(0) & " "
                    Case Else
                        textodetalle += " EN LOS PERIODOS: "
                        For x = 0 To PERIODOS.Count - 1
                            If x = PERIODOS.Count - 1 Then
                                textodetalle += " y " & PERIODOS(x) & " "
                            Else
                                textodetalle += " (" & PERIODOS(x) & "),"
                            End If
                        Next
                End Select
                Select Case EFECTORES.Count
                    Case = 0
                        textodetalle += " "
                    Case = 1
                        textodetalle += " PARA " & EFECTORES(0) & " "
                    Case Else
                        textodetalle += " PARA: "
                        For x = 0 To EFECTORES.Count - 1
                            If x = EFECTORES.Count - 1 Then
                                textodetalle += " " & EFECTORES(x) & " "
                            Else
                                textodetalle += " " & EFECTORES(x) & ","
                            End If
                        Next
                End Select
                Select Case INSTRUMENTOLEGAL.Count
                    Case = 0
                        textodetalle += " INSTRUMENTO_LEGAL Nº 0/" & ORDENPAGO.Ordenpago_Year
                    Case = 1
                        textodetalle += " AUTORIZADO POR: " & INSTRUMENTOLEGAL(0)
                    Case Else
                        textodetalle += " AUTORIZADO POR: "
                        For x = 0 To INSTRUMENTOLEGAL.Count - 1
                            If x = INSTRUMENTOLEGAL.Count - 1 Then
                                textodetalle += INSTRUMENTOLEGAL(x) & " "
                            Else
                                textodetalle += INSTRUMENTOLEGAL(x) & " , "
                            End If
                        Next
                End Select
            Case False
                'For Each row In Datos_Ordenesprovision.Rows
                '    textodetalle += ""
                'Next
                textodetalle = " (INGRESAR DESTINO) SEGUN ORD. PROV. Nº " &
                   "0/" & ORDENPAGO.Ordenpago_Year & ", " &
               "(PAGO/RENDICIÓN) (TIPO DE ADQUISICIÓN )Nº 0/" & ORDENPAGO.Ordenpago_Year &
                    "(INSTRUMENTO LEGAL) Nº 0/" & ORDENPAGO.Ordenpago_Year
        End Select
        ORDENPAGO.ordenpago_Detalle = textodetalle
        ordenpago_detalles.Text = ORDENPAGO.ordenpago_Detalle
        'ordenpago_detalles2.Text = ORDENPAGO.ordenpago_Detalle2
    End Sub

    Private Sub CARGADETABLAS()
        With TABLAINSTRUMENTOLEGAL
            .Columns.Add("TIPO")
            .Rows.Add("RESOLUCIÓN")
            .Rows.Add("DECRETO")
        End With
        With TABLAORIGEN
            .Columns.Add("TIPO")
            .Rows.Add("COMPRA DIRECTA")
            .Rows.Add("CONCURSO DE PRECIOS")
            .Rows.Add("CONTADO CONTRA ENTREGA")
            .Rows.Add("CONTRATACIÓN DIRECTA")
            .Rows.Add("CONTRATACIÓN DIRECTA art 3ero")
            .Rows.Add("CONTRATO")
            .Rows.Add("LICITACIÓN PRIVADA")
            .Rows.Add("LICITACIÓN PÚBLICA")
        End With
    End Sub

    Private Sub tablanueva()
        'datosordenpago.Columns.Add("Reng.", System.Type.GetType("System.Int32"))
        'datosordenpago.Columns.Add("Cant.", System.Type.GetType("System.Decimal"))
        'datosordenpago.Columns.Add("Un.", System.Type.GetType("System.String"))
        'datosordenpago.Columns.Add("Articulos.", System.Type.GetType("System.String"))
        'datosordenpago.Columns.Add("Prec.Unit.", System.Type.GetType("System.Decimal"))
        'datosordenpago.Columns.Add("Prec.Total", System.Type.GetType("System.Decimal"))
        'datosordenpago.Columns.Add("Detalle", System.Type.GetType("System.String"))
        OPyear_numericupdown.Value = Date.Now.Year
        'OP_year_tipo_numericupdown.Value = Date.Now.Year
        'yearinstrumentolegal_numericupdown.Value = Date.Now.Year
        ordenpago_detalles.Text = ""
        Datos_Partidas.DataSource = PartidaPresupuestaria.estructurapartidadatatable()
        '  Datos_ActasRecepcion.DataSource = ACTARECEPCION.estructuraActaRecepcion
        '  Datos_Ordenesprovision.DataSource = OrdenProvision.Estructura_Seleccionordenprovision
    End Sub

    Public Sub Todoacero()
        'OP_num_tipo_numericupdown.Value = 0
        'OPNumero_numericupdown.Value = ORDENPAGO.Buscarmaximo_ordenpago(Date.Now.Year)
        'OP_year_tipo_numericupdown.Value = Date.Now.Year
        'Fecharealizada_datetimepicker.Value = Date.Now
        'ordenpago_INICIADOR.Text = ""
        '' ordenpago_CONCEPTO.Text = ""
        'Cuitdelbeneficiario_textbox.Text = ""
        'Montototal.Value = 0
        'Instrumentolegal_combobox.SelectedIndex = 0
        'Instrumentolegal_numericupdown.Value = 0
        'yearinstrumentolegal_numericupdown.Value = Date.Now.Year
        'ordenpago_TIPO.SelectedIndex = 0
        'cantidad_terminonumericupdown.Value = 5
        'unidad_terminonumericupdown.SelectedIndex = 0
    End Sub

    Public Sub Cargarordenpago(ByVal orden As Ordendepago)
        Todoacero()
        ORDENPAGO = orden
        OPparamodificar = False 'Es una orden de pago nueva
        encabezadodialogo()
        OPNumero_numericupdown.Value = ORDENPAGO.ordenpago_numero
        OPyear_numericupdown.Value = ORDENPAGO.Ordenpago_Year
        Fechaconfeccion_datetimepicker.Value = ORDENPAGO.ordenpago_fecha
        tablanueva()
        Mostrardialogo(Me)
    End Sub

    Private Sub encabezadodialogo()
        Label_ordenpagoasociada.Text = " Orden de Pago Nº" & ORDENPAGO.ordenpago_numero & " en Expte: " & ORDENPAGO.expediente_op.Expediente_N
    End Sub

    Private Sub Cuit_boton_KeyDown(sender As Object, e As KeyEventArgs)
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

    Private Sub Guardar_eimprimir_boton_Click(sender As Object, e As EventArgs) Handles Guardar_eimprimir_boton.Click
        Select Case MsgBox("Desea Guardar los Cambios introducidos?", MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                If ADVERTENCIA_COHERENCIA() = "" And Not (Datos_Partidas.Rows.Count = 0) Then
                    guardardatosOP()
                    '   IMPRESION(ORDENPAGO)
                    PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)
                    '   PDF_ORDENPAGO_Pago(ORDENPAGO) 'PDF_ORDENPAGO_Pago(ORDENPAGO, "LEGAL")
                Else
                    If Datos_Partidas.Rows.Count = 0 Then
                        MessageBox.Show("No se puede Generar(imprimir) una orden de pago sin Partida Presupuestaria," & vbCrLf &
                                        " Si lo desea puede Guardarla para su posterior uso con el Botón 'Guardar'")
                    Else
                        MessageBox.Show(ADVERTENCIA_COHERENCIA())
                    End If
                End If
            Case MsgBoxResult.No
                MessageBox.Show("Los datos no se guardaron")
        End Select
    End Sub

    Private Sub IMPRESION(ByVal ORDENPAGOS As Ordendepago)
        Select Case ORDENPAGOS.Ordenpago_tipo
            Case Is = "ARANCELAMIENTO"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "TRANSFERENCIA"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "PAGO MULTIPLES EFECTORES"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RENDICIÓN"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RENDICIÓN FINAL"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RENDICIÓN PARCIAL"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RECONOCIMIENTO"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "VIÁTICOS"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "REPOSICIÓN"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "CONTRATOS"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "BECAS"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
            Case Is = "COMISIÓN BANCARIA"
                PDF_ORDENPAGO_MULTIPLEv2(ORDENPAGO)  'PDF_ORDENPAGO_MULTIPLE(ORDENPAGO, "LEGAL")
        End Select
    End Sub

    Private Sub guardardatosOP()
        ORDENPAGO.ordenpago_numero = OPNumero_numericupdown.Value
        ORDENPAGO.Ordenpago_Year = OPyear_numericupdown.Value
        ORDENPAGO.ordenpago_Detalle = ordenpago_detalles.Text
        ORDENPAGO.ordenpago_Detalle2 = OBSERVACIONES.Text
        ORDENPAGO.ordenpago_fecha = Fechaconfeccion_datetimepicker.Value
        ORDENPAGO.Ordenpago_tipo = LABELTIPODEORODEN.Text
        ORDENPAGO.ordenpago_montototal = PARTIDAS_TOTALNUMERICAUPDOWN.Value
        ORDENPAGO.CLASE_FONDO = CLASEOP.Text
        ORDENPAGO.ESTADO = ESTADOOP.Text
        ORDENPAGO.novalido = SINMOVIMIENTOS_CHECKBOX.Checked
        ORDENPAGO.Clave_ordenpago = CType(ORDENPAGO.Ordenpago_Year & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(ORDENPAGO.ordenpago_numero), "00000"), Long)
        If Numeroexpediente_numericupdown.Value > 0 And Organismo_numericupdown.Value > 0 Then
            ORDENPAGO.ClaveExpediente_principal = CType(Year_numericupdown.Value & Organismo_numericupdown.Value & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
        Else
        End If
        If numeroexpediente_asociado_NumericUpDown.Value > 0 And Organismo_asociado_NumericUpDown.Value > 0 Then
            ORDENPAGO.expediente_op2.claveexpediente = CType(Year_asociado_NumericUpDown.Value & Organismo_asociado_NumericUpDown.Value & Format(Convert.ToInt32(numeroexpediente_asociado_NumericUpDown.Value), "00000"), Long)
        Else
        End If
        ORDENPAGO.ACTAS.Clear()
        ORDENPAGO.SINACTAS.Clear()
        'ORDENPAGO.Datatable_a_ACTAS(CType(Datos_Ordenesprovision.DataSource, DataTable))
        ORDENPAGO.Partida_datatable = CType(Datos_Partidas.DataSource, DataTable)
        ORDENPAGO.Partidas.Clear()
        Dim indiceaborrar As New List(Of DataRow)
        Select Case ORDENPAGO.Ordenpago_tipo
            Case Is = "ARANCELAMIENTO"
                For Each ROW As DataRow In ORDENPAGO.Partida_datatable.Rows
                    If ROW.Item("IMPORTE") = 0 Then
                        indiceaborrar.Add(ROW)
                    End If
                Next
                For Each ROW As DataRow In indiceaborrar
                    ORDENPAGO.Partida_datatable.Rows.Remove(ROW)
                Next
                Datos_Partidas.DataSource = ORDENPAGO.Partida_datatable
                ORDENPAGO.Datatable_a_SINACTAS_ARANCELAMIENTO(CType(Datos_Ordenesprovision.DataSource, DataTable))
            Case Else
                For Each ROW As DataRow In ORDENPAGO.Partida_datatable.Rows
                    If ROW.Item("IMPORTE") = 0 Then
                        indiceaborrar.Add(ROW)
                    End If
                Next
                For Each ROW As DataRow In indiceaborrar
                    ORDENPAGO.Partida_datatable.Rows.Remove(ROW)
                Next
                ORDENPAGO.Datatable_a_SINACTAS(CType(Datos_Ordenesprovision.DataSource, DataTable))
                Select Case ORDENPAGO.Ordenpago_tipo
                    Case Is = "VIÁTICOS"
                        ORDENPAGO.VIATICOS_datatable = CType(Datos_Ordenesprovision.DataSource, DataTable)
                        ORDENPAGO.Datatable_A_VIATICOS(ORDENPAGO.VIATICOS_datatable)
                    Case Else
                        ORDENPAGO.VIATICOS_datatable = New DataTable
                End Select
        End Select
        ORDENPAGO.Datatable_a_Partidas()
        'ORDENPAGO.Datatable_a_insertarordenesprovision(CType(Datos_Ordenesprovision.DataSource, DataTable))
        Dim clave As String = ""
        Dim tabla As New DataTable
        'tabla = CType(Datos_Ordenesprovision.DataSource, DataTable)
        ORDENPAGO.ORDENESPROVISION.Clear()
        ORDENPAGO.Datatable_A_OPROVISION(tabla)
        'ORDENPAGO.ordenpago_montototal = Montototal.Value
        'tabla de orden de provisión
        ORDENPAGO.DatosOrdenPago = CType(Datos_Partidas.DataSource, DataTable)
        '/tabla de orden de provisión
        '   Try
        ORDENPAGO.Insertar_ordenpago()
        claveguardada = ORDENPAGO.Clave_ordenpago
        Select Case ORDENPAGO.Ordenpago_tipo
            Case Is = "REPOSICIÓN"
                ORDENPAGO.expediente_op.ActualizarExptePrincipal(ORDENPAGO.expediente_op.claveexpediente, ORDENPAGO.ClaveExpediente_principal)
            Case Else
                'ORDENPAGO.expediente_op.actualizarexpteprincipal(ORDENPAGO.expediente_op.claveexpediente, ORDENPAGO.ClaveExpediente_principal)
        End Select
        Guardar_boton.Text = "GUARDADO"
        OPNumero_numericupdown.Enabled = False
        OPyear_numericupdown.Enabled = False
        Guardar_eimprimir_boton.Text = "IMPRIMIR"
        NUEVAOP = False
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub Carga_orden_pago()
        If NUEVAOP Then
            If Not valoresiniciales Then
                ORDENPAGO.ordenpago_numero = OPNumero_numericupdown.Value
                ORDENPAGO.Ordenpago_Year = OPyear_numericupdown.Value
                ORDENPAGO.Clave_ordenpago = CType(ORDENPAGO.Ordenpago_Year & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(ORDENPAGO.ordenpago_numero), "00000"), Long)
            End If
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

    Private Sub Label10_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Cuit_boton_Click(sender As Object, e As EventArgs)
        '  Dialogo_CUIT.Cargadetextbox(Cuitdelbeneficiario_textbox)
        '  Dialogo_CUIT.Cargadecuits(ORDENPAGO.Clave_expediente)
    End Sub

    Private Sub Label_montonombre_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Monto_factura_textbox_ValueChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Cuitdelbeneficiario_textbox_TextChanged(sender As Object, e As EventArgs)
        '   VerificarCUIT(sender, sender.text, Beneficiario_label, DOMICILIO)
    End Sub

    Private Sub Datos_ordenpago_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
        CALCULAR()
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
        For x = 0 To Datos_Partidas.Rows.Count - 1
            Try
                'If Not IsDBNull(Datos_Partidas.Rows(x).Cells.Item("PREC.TOTAL").Value) And Not (Datos_Partidas.Rows(x).Cells.Item("PREC.TOTAL").Value = 0) Then
                '    IMPORTETOTAL += Datos_Partidas.Rows(x).Cells.Item("PREC.TOTAL").Value
                'End If
            Catch ex As Exception
            End Try
        Next
        Return IMPORTETOTAL
    End Function

    'Private Sub Datos_ordenpago_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Partidas.RowEnter
    '    'If Datos_Partidas.Rows.Count > 0 And Not (Datos_Partidas.Rows(e.RowIndex).Cells.Item("RENG.").Value > 0) Then
    '    '    'Datos_Partidas.Rows(e.RowIndex).Cells.Item("RENG.").Value = e.RowIndex + 1
    '    'End If
    'End Sub
    Private Sub cantidad_terminonumericupdown_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub OPNumero_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles OPNumero_numericupdown.ValueChanged
        encabezadodialogo()
        ORDENPAGO.ordenpago_numero = OPNumero_numericupdown.Value
        Carga_orden_pago()
    End Sub

    Private Sub OPyear_numericupdown_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub ordenpago_INICIADOR_TextChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub ordenpago_DESTINO_TextChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub ordenpago_LUGARENTREGA_TextChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub Instrumentolegal_combobox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub Instrumentolegal_numericupdown_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub yearinstrumentolegal_numericupdown_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub Fecha_documento_DATETIMEPICKER_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub ordenpago_TIPO_SelectedIndexChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub OP_num_tipo_numericupdown_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub OP_year_tipo_numericupdown_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub Fecharealizada_datetimepicker_ValueChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub Beneficiario_label_Click(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub unidad_terminonumericupdown_SelectedIndexChanged(sender As Object, e As EventArgs)
        Carga_orden_pago()
    End Sub

    Private Sub OPNumero_numericupdown_Leave(sender As Object, e As EventArgs)
        encabezadodialogo()
    End Sub

    Private Sub Datos_ordenpago_KeyDown(sender As Object, e As KeyEventArgs) Handles Datos_Partidas.KeyDown
        If e.KeyCode = Keys.Delete Then
            Select Case Datos_Partidas.SelectionMode
                Case Is = 1 'full row
                    'For Each DataGridViewRow In Datos_Partidas.SelectedRows
                    '    Datos_Partidas.Rows.Remove(DataGridViewRow)
                    'Next
                Case Is = 0 ' cell select
                    For Each DataGridViewCell In Datos_Partidas.SelectedCells
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
        Else
            Select Case e.KeyValue
                Case Is = Keys.Escape
                    sender.CurrentCell = Nothing
                    e.Handled = True
                Case Else
                    If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
                        PasteFromClipboard(sender, e)
                    End If
            End Select
        End If
    End Sub

    'Private Sub Datos_ordenpago_DataError(sender As DataGridView, e As DataGridViewDataErrorEventArgs) Handles Datos_Partidas.DataError, Datos_Ordenesprovision.DataError
    '    sender.Rows(e.RowIndex).ErrorText = "La celda no admite este tipo de datos, presione Escape si desea cancelar la modificación"
    '    MessageBox.Show(sender.Rows(e.RowIndex).ErrorText)
    '    e.Cancel = True
    '    'Select Case e.Exception.Message
    '    '    Case Is = "La cadena de entrada no tiene el formato correcto."
    '    '        Select Case sender.VALUEtype.GetType.ToString
    '    '            Case Is = "System.Int32"
    '    '                MessageBox.Show("Esta celda solo admite números enteros")
    '    '            Case Is = "System.Decimal"
    '    '                MessageBox.Show("Esta celda solo admite números")
    '    '            Case Is = "System.String"
    '    '                MessageBox.Show("Texto")
    '    '        End Select
    '    '    Case Else
    '    '        MessageBox.Show(e.Exception.Message)
    '    'End Select
    'End Sub
    Private Sub textoordenpago()
        ordenpago_detalles.Text = ""
    End Sub

    'Private Sub Datos_ordenpago_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_Partidas.RowHeaderMouseClick
    '    Select Case Datos_Partidas.SelectionMode
    '        Case Is = 1 'fullrow
    '            Datos_Partidas.SelectionMode = DataGridViewSelectionMode.CellSelect
    '        Case Is = 0 ' cellselect
    '            Datos_Partidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            Datos_Partidas.Rows(e.RowIndex).Selected = True
    '    End Select
    'End Sub
    Private Sub Guardar_boton_Click(sender As Object, e As EventArgs) Handles Guardar_boton.Click
        Select Case MsgBox("Desea Guardar los Cambios introducidos?", MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                If ADVERTENCIA_COHERENCIA() = "" Then
                    guardardatosOP()
                    valoresmodificados = False
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
        '    If NUEVAOP And ORDENPAGO.Clave_ordenpago <> claveguardada Then
        If NUEVAOP Then
            If ORDENPAGO.verificarexistencia(CType(ORDENPAGO.Ordenpago_Year & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(ORDENPAGO.ordenpago_numero), "00000"), Long)) Then
                Message += " ESTE NÚMERO DE ORDEN DE PAGO ESTA EN USO, POR FAVOR MODIFIQUELO " & vbCrLf &
                "DISPONIBLE " & ORDENPAGO.AGREGARMAXIMO_ordenpago(Autorizaciones.Year).ToString & "/" & Autorizaciones.Year
            End If
        End If
        '  End If
        If (Montototal.Value = PARTIDAS_TOTALNUMERICAUPDOWN.Value) Or Datos_Partidas.Rows.Count = 0 Then
            Message += ""
        Else
            Message += " Actualmente existe una diferencia de " & CType(Math.Abs(Montototal.Value - PARTIDAS_TOTALNUMERICAUPDOWN.Value), Decimal).ToString("C", Globalization.CultureInfo.GetCultureInfo("es-AR")) & vbCrLf & " No se guardaran los datos por favor verifique"
        End If
        Return Message
    End Function

    Private Sub Datos_ordenpago_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_Ordenesprovision.MouseUp, Datos_Partidas.MouseUp
        Inicio.MOUSEDERECHO(sender, e, sender)
    End Sub

    Private Sub Datos_Partidas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Datos_Partidas.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Datos_ordenpago_KeyPress
        'Dim editingControl As TextBox = TryCast(e.Control, TextBox)
        'If editingControl IsNot Nothing Then
        '    e.Control.KeyPress = New KeyPressEventHandler(Datos_ordenpago_KeyPress)
        '    editingControl.CharacterCasing = CharacterCasing.Upper
        'End If
    End Sub

    Private Sub Datos_ordenpago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Datos_Ordenesprovision.KeyPress
        'If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = "," Or e.KeyChar = ".") Then
        '    e.Handled = True
        'Else
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub DOBLE_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Datos_Partidas.MouseDoubleClick, Datos_Ordenesprovision.MouseDoubleClick, Datos_Partidas.CellMouseDoubleClick
        'Cargaymodificaciondatatable(Me, CType(sender.DataSource, DataTable), sender)
        Dialogo_ModificarDatatable.CargarDatatable(Me, CType(sender.DataSource, DataTable), sender, ORDENPAGO.expediente_op.claveexpediente)
        sender.Refresh()
        CALCULAR()
    End Sub

    'Private Sub Datos_Ordenesprovision_MouseDoubleClick(sender As Object, e As MouseEventArgs)
    '    AGREGARORDENPROVISION()
    'End Sub
    'Private Sub AGREGARORDENPROVISION()
    '    'Dim ORDENPROV As New OrdenProvision
    '    DialogDialogo_Datagridview.Carga_General(OrdenProvision.Ordenesprovision_expediente(ORDENPAGO.expediente_op.claveexpediente), "Seleccione por Favor la orden de Provisión", "Seleccionar", "Cancelar", 11)
    '    If DialogDialogo_Datagridview.Datosdialogo_datagridview.Rows.Count > 0 Then
    '        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
    '            CType(Datos_Ordenesprovision.DataSource, DataTable).Rows.Add({DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value,
    '                                                                     DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value,
    '                                                                     DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value,
    '                                                                     DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(3).Value,
    '                                                                     DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(4).Value,
    '                                                                     DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(5).Value,
    '                                                                     DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(6).Value})
    '            'ORDENPROV.Destino = ""
    '            'ORDENPROV.ordenprovision_numero = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(0).Value.ToString, "/").FirstOrDefault, Integer)
    '            'ORDENPROV.ordenprovision_year = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(0).Value.ToString, "/").Skip(1).FirstOrDefault, Integer)
    '            'ORDENPROV.Tipo_origen = Datos_Ordenesprovision.Rows(0).Cells.Item(4).Value.ToString
    '            'ORDENPROV.Numero_origen = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(5).Value.ToString, "/").FirstOrDefault, Integer)
    '            'ORDENPROV.Year_origen = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(5).Value.ToString, "/").Skip(1).FirstOrDefault, Integer)
    '            'ORDENPROV.Tipo_instrumentolegal = Datos_Ordenesprovision.Rows(0).Cells.Item(2).Value.ToString
    '            'ORDENPROV.Numero_instrumentolegal = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(3).Value.ToString, "/").FirstOrDefault, Integer)
    '            'ORDENPROV.Year_instrumentolegal = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(3).Value.ToString, "/").Skip(1).FirstOrDefault, Integer)
    '            'ORDENPROV.CUIT = Datos_Ordenesprovision.Rows(0).Cells.Item(6).Value
    '            'ORDENPROV.Cargardatos()
    '            'ORDENPAGO.ORDENESPROVISION.Add(ORDENPROV)
    '            CARGADEORDENESPROVISION()
    '            'cambiosdatostexto()
    '        Else
    '        End If
    '    Else
    '        Dialogo_ModificarDatatable.CargarDatatable(Me, CType(Datos_Ordenesprovision.DataSource, DataTable), Datos_Ordenesprovision, ORDENPAGO.expediente_op.claveexpediente)
    '    End If
    'End Sub
    Private Sub CALCULAR()
        TOTALACTASRECEPCION = 0
        TOTALPARTIDAS = 0
        TOTALORDENESPROVISION = 0
        For O As Integer = 0 To Datos_Ordenesprovision.Rows.Count - 1
            Select Case ORDENPAGO.Ordenpago_tipo.ToUpper
                Case Is = "ARANCELAMIENTO"
                    If Not IsDBNull(Datos_Ordenesprovision.Rows(O).Cells.Item("GASTOS").Value) Then
                        TOTALACTASRECEPCION += Datos_Ordenesprovision.Rows(O).Cells.Item("GASTOS").Value
                    End If
                Case Is = "REPOSICIÓN"
                Case Is = "COMISIÓN BANCARIA"
                Case Else
                    If Not IsDBNull(Datos_Ordenesprovision.Rows(O).Cells.Item("TOTAL").Value) Then
                        TOTALACTASRECEPCION += Datos_Ordenesprovision.Rows(O).Cells.Item("TOTAL").Value
                    End If
            End Select
        Next
        For P As Integer = 0 To Datos_Partidas.Rows.Count - 1
            If Not IsDBNull(Datos_Partidas.Rows(P).Cells.Item("IMPORTE").Value) Then
                TOTALPARTIDAS += Datos_Partidas.Rows(P).Cells.Item("IMPORTE").Value
            End If
        Next
        'For Q As Integer = 0 To Datos_Ordenesprovision.Rows.Count - 1
        '    If Not IsDBNull(Datos_Ordenesprovision.Rows(Q).Cells.Item("MONTO").Value) Then
        '        TOTALORDENESPROVISION += Datos_Ordenesprovision.Rows(Q).Cells.Item("MONTO").Value
        '    End If
        'Next
        Select Case ORDENPAGO.Ordenpago_tipo.ToUpper
            Case Is = "ARANCELAMIENTO"
                Montototal.Value = TOTALACTASRECEPCION
            Case Is = "REPOSICIÓN"
                Montototal.Value = TOTALPARTIDAS
            Case Is = "COMISIÓN BANCARIA"
                Montototal.Value = TOTALPARTIDAS
            Case Else
                Montototal.Value = TOTALACTASRECEPCION
        End Select
        PARTIDAS_TOTALNUMERICAUPDOWN.Value = TOTALPARTIDAS
    End Sub

    Public Sub Cargardatosamodificar(ByVal ORDENPAGOS As Ordendepago, ByVal NUEVO As Boolean, Optional RECONOCIMIENTOCOMOPAGO As Boolean = False)
        NUEVAOP = NUEVO
        OPparamodificar = Not NUEVO 'Es una orden de pago para modificar
        ORDENPAGO = ORDENPAGOS
        datosordenpagodatatable = ORDENPAGO.DatosOrdenPago
        OPNumero_numericupdown.Value = ORDENPAGO.ordenpago_numero
        OPyear_numericupdown.Value = ORDENPAGO.Ordenpago_Year
        ordenpago_detalles.Text = ORDENPAGO.ordenpago_Detalle
        OBSERVACIONES.Text = ORDENPAGO.ordenpago_Detalle2
        LABELTIPODEORODEN.Text = ORDENPAGO.Ordenpago_tipo
        Fechaconfeccion_datetimepicker.Value = ORDENPAGO.ordenpago_fecha
        CLASEOP.Text = ORDENPAGO.CLASE_FONDO
        ESTADOOP.Text = ORDENPAGO.ESTADO
        If OPparamodificar Then
            OPNumero_numericupdown.Enabled = False
            OPyear_numericupdown.Enabled = False
        Else
            OPNumero_numericupdown.Enabled = True
            OPyear_numericupdown.Enabled = True
        End If
        'expediente principal orden de pago
        If ORDENPAGO.ClaveExpediente_principal > 0 Then
            Organismo_numericupdown.Value = CType(ORDENPAGO.ClaveExpediente_principal.ToString.Substring(4, 4), UInteger)
            Numeroexpediente_numericupdown.Value = CType(ORDENPAGO.ClaveExpediente_principal.ToString.Substring(8, 5), UInteger)
            Year_numericupdown.Value = CType(ORDENPAGO.ClaveExpediente_principal.ToString.Substring(0, 4), UInteger)
        Else
            Organismo_numericupdown.Value = 0
            Numeroexpediente_numericupdown.Value = 0
            Year_numericupdown.Value = Autorizaciones.Year
        End If
        If ORDENPAGO.expediente_op2.claveexpediente > 0 Then
            Organismo_asociado_NumericUpDown.Value = CType(ORDENPAGO.expediente_op2.claveexpediente.ToString.Substring(4, 4), UInteger)
            numeroexpediente_asociado_NumericUpDown.Value = CType(ORDENPAGO.expediente_op2.claveexpediente.ToString.Substring(8, 5), UInteger)
            Year_asociado_NumericUpDown.Value = CType(ORDENPAGO.expediente_op2.claveexpediente.ToString.Substring(0, 4), UInteger)
        Else
            Organismo_asociado_NumericUpDown.Value = 0
            numeroexpediente_asociado_NumericUpDown.Value = 0
            Year_asociado_NumericUpDown.Value = Autorizaciones.Year
        End If
        Montototal.Value = ORDENPAGO.ordenpago_montototal
        'tabla de datos
        'Datos_ActasRecepcion.DataSource = ACTARECEPCION.estructuraActaRecepcion(ORDENPAGO.Clave_ordenpago)
        Datos_Partidas.DataSource = PartidaPresupuestaria.estructurapartidadatatable(ORDENPAGO.Clave_ordenpago)
        Select Case ORDENPAGO.Ordenpago_tipo
            Case Is = "VIÁTICOS"
                Datos_Ordenesprovision.DataSource = ORDENPAGO.Estructura_SeleccionVIATICOS(ORDENPAGO.Clave_ordenpago)
            Case Else
                Datos_Ordenesprovision.DataSource = SINACTARECEPCION.Estructura_SeleccionSINACTARECEPCION(ORDENPAGO.Clave_ordenpago, ORDENPAGO)
        End Select
        If NUEVO And ORDENPAGOS.Ordenpago_tipo = "REPOSICIÓN" Then
            Dim tabladefondos As DataTable = ORDENPAGOS.Fondos_permanentes
            DialogDialogo_Datagridview.Carga_General(tabladefondos, "Seleccione el fondo permanente que desea reponer", "Seleccionar", "Cancelar", 9)
            If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                EFECTOR_FONDOPERMANENTE = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                ORDENCARGO_FONDOPERMANENTE = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value.ToString.ToUpper
                EXPEDIENTE_FONDOPERMANENTE = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value.ToString.ToUpper
                Datos_Partidas.DataSource = PartidaPresupuestaria.estructurapartidadatatable_FONDOSPERMANENTES(EFECTOR_FONDOPERMANENTE)
            End If
            Organismo_numericupdown.Value = 3809
        End If
        Select Case ORDENPAGO.Ordenpago_tipo
            Case Is = ""
            Case Else
                CARGADATAGRIDVIEW()
        End Select
        valoresiniciales = False
        'DAR FORMATO A LAS COLUMNAS
        Formatocolumnas(Datos_Partidas, CType(Datos_Partidas.DataSource, DataTable))
        Formatocolumnas(Datos_Ordenesprovision, CType(Datos_Ordenesprovision.DataSource, DataTable))
        encabezadodialogo()
        CALCULAR()
        Mostrardialogo(Me)
    End Sub

    Private Sub CARGADATAGRIDVIEW()
        Select Case ORDENPAGO.Ordenpago_tipo
            Case Is = "ARANCELAMIENTO"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = False
                'Datos_Ordenesprovision.Columns("Total").Visible = False
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = True
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = True
                Sugerencia_partidas.Visible = True
                If IsNothing(ORDENPAGO.ordenpago_Detalle2) Then
                    OBSERVACIONES.Text = "Se interviene al solo efecto de la prosecución del trámite. Deslindando toda responsabilidad de este Servicio Administrativo. De acuerdo a lo establecido en el art. 25 del Decreto 488/00"
                    ordenpago_detalles.Text = "DE GASTOS Y RECURSOS CORRESPONDIENTES A LA CUENTA DE ARANCELAMIENTO HOSPITALARIO  - LEY 2925 - SEGÚN DECRETO Nº 488/00.-"
                End If
            Case Is = "TRANSFERENCIA"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = False
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = False
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").DisplayIndex = 0
            Case Is = "PAGO MULTIPLES EFECTORES"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = True
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = True
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = True
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
            Case Is = "RENDICIÓN"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = True
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = True
                If IsNothing(ORDENPAGO.ordenpago_Detalle2) Then
                    OBSERVACIONES.Text = "Se interviene al solo efecto de la prosecución del trámite. Deslindando toda responsabilidad de este Servicio Administrativo. De acuerdo a lo establecido en el art. 25 del Decreto 488/00"
                    ordenpago_detalles.Text = "DE GASTOS Y RECURSOS CORRESPONDIENTES A LA CUENTA DE ARANCELAMIENTO HOSPITALARIO  - LEY 2925 - SEGÚN DECRETO Nº 488/00.-"
                End If
            Case Is = "RENDICIÓN FINAL"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = True
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = True
                If ORDENPAGO.ordenpago_Detalle2.Length = 0 Then
                    OBSERVACIONES.Text = "Se interviene al solo efecto de la prosecución del trámite. Deslindando toda responsabilidad de este Servicio Administrativo. De acuerdo a lo establecido en el art. 25 del Decreto 488/00"
                    ordenpago_detalles.Text = "DE GASTOS Y RECURSOS CORRESPONDIENTES A LA CUENTA DE ARANCELAMIENTO HOSPITALARIO  - LEY 2925 - SEGÚN DECRETO Nº 488/00.-"
                End If
            Case Is = "RENDICIÓN PARCIAL"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = True
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = True
                If ORDENPAGO.ordenpago_Detalle2.Length = 0 Then
                    OBSERVACIONES.Text = "Se interviene al solo efecto de la prosecución del trámite. Deslindando toda responsabilidad de este Servicio Administrativo. De acuerdo a lo establecido en el art. 25 del Decreto 488/00"
                    ordenpago_detalles.Text = "DE GASTOS Y RECURSOS CORRESPONDIENTES A LA CUENTA DE ARANCELAMIENTO HOSPITALARIO  - LEY 2925 - SEGÚN DECRETO Nº 488/00.-"
                End If
            Case Is = "RECONOCIMIENTO"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = True
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = True
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = True
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
            Case Is = "RECONOCIMIENTO Y REAPROPIACIÓN"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = True
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = True
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = True
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = False
                'Datos_Ordenesprovision.Columns("Total").Visible = False
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = False
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = False
                'Datos_Ordenesprovision.Columns("CUIT").Visible = True
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = True
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
            Case Is = "VIÁTICOS"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = False
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = False
                'Datos_Ordenesprovision.Columns("Total").Visible = False
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = False
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = False
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
            Case Is = "PUBLICIDAD"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = True
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
                If ORDENPAGO.ordenpago_Detalle.Length = 0 Then
                    OBSERVACIONES.Text = ""
                    ordenpago_detalles.Text = ""
                End If
            Case Is = "REPOSICIÓN"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = False
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
                If NUEVAOP Then
                    CARGARINSTRUMENTOLEGAL()
                End If
            Case Is = "CONTRATOS"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
            Case Is = "BECAS"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
                If ORDENPAGO.ordenpago_Detalle.Length = 0 Then
                    OBSERVACIONES.Text = ""
                    ordenpago_detalles.Text = "PAGO BECAS EN EL MARCO DEL PROGRAMA DE FORMACIÓN DE AGENTES SANITARIOS APROVADO POR DECRETO 076 RES. 355/2020, CORRESPONDIENTE AL MES DE FEBRERO 2020"
                End If
            Case Is = "COMISIÓN BANCARIA"
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = False
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = False
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = False
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = False
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = False
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = False
                If ORDENPAGO.ordenpago_Detalle.Length = 0 Then
                    OBSERVACIONES.Text = ""
                    ordenpago_detalles.Text = "SERVICIO BANCARIZADO PAGO BECAS PROGRAMA DE FORMACIÓN DE AGENTES SANITARIOS MES ENERO/2020, SEGÚN DECRETO 76/2020, RESOLUCIÓN 191/2020.-"
                End If
            Case Else
                'Datos_Ordenesprovision.Columns("Tipo_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Numero_instrumentolegal").Visible = True
                'Datos_Ordenesprovision.Columns("Year_instrumento_legal").Visible = True
                'Datos_Ordenesprovision.Columns("Total").Visible = True
                'Datos_Ordenesprovision.Columns("Detalle").Visible = True
                'Datos_Ordenesprovision.Columns("EFECTOR").Visible = True
                'Datos_Ordenesprovision.Columns("PERIODO").Visible = True
                'Datos_Ordenesprovision.Columns("CUIT").Visible = True
                'Datos_Ordenesprovision.Columns("ACTA_RECEPCION").Visible = True
                'Datos_Ordenesprovision.Columns("RECURSOS").Visible = True
                'Datos_Ordenesprovision.Columns("GASTOS").Visible = True
        End Select
    End Sub

    Private Sub CARGARINSTRUMENTOLEGAL()
        Dim datos As New DataTable
        Dim DATOSACARGAR As DataTable = CType(Datos_Ordenesprovision.DataSource, DataTable)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@EFECTOR", EFECTOR_FONDOPERMANENTE)
        Dim consultasql As String = "SELECT
Tipo_instrumentolegal,
LEFT(Instrumentolegal,LOCATE('/',Instrumentolegal) - 1) AS Numero_instrumentolegal,
SUBSTRING(INSTRUMENTOLEGAL FROM LOCATE('/',Instrumentolegal)+1 FOR 4) AS Year_instrumento_legal,EFECTOR
FROM _fondopermanentelegal  WHERE EFECTOR=@EFECTOR
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos, System.Reflection.MethodBase.GetCurrentMethod.Name)
        For Each ROW As DataRow In datos.Rows
            DATOSACARGAR.Rows.Add()
            DATOSACARGAR.Rows(DATOSACARGAR.Rows.Count - 1).Item("Numero_instrumentolegal") = ROW("Numero_instrumentolegal")
            DATOSACARGAR.Rows(DATOSACARGAR.Rows.Count - 1).Item("Year_instrumento_legal") = ROW("Year_instrumento_legal")
            DATOSACARGAR.Rows(DATOSACARGAR.Rows.Count - 1).Item("Tipo_instrumentolegal") = ROW("Tipo_instrumentolegal")
            DATOSACARGAR.Rows(DATOSACARGAR.Rows.Count - 1).Item("EFECTOR") = ROW("EFECTOR")
        Next
        Datos_Ordenesprovision.DataSource = DATOSACARGAR
        cambiosdatostexto()
    End Sub

    'Private Sub Datos_ActasRecepcion_DataSourceChanged(sender As Object, e As EventArgs) Handles Datos_ActasRecepcion.DataSourceChanged
    '    CALCULAR()
    'End Sub
    'Private Sub Datos_Ordenesprovision_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Partidas.RowValidated
    '    Try
    '        If sender.Name = Datos_Ordenesprovision.Name Then
    '            CARGADEORDENESPROVISION()
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    CALCULAR()
    'End Sub
    'Private Sub CARGADEORDENESPROVISION()
    '    Dim LISTADECODIGOS As New List(Of Long)
    '    ORDENPAGO.ORDENESPROVISION.Clear()
    '    For x = 0 To Datos_Ordenesprovision.Rows.Count - 1
    '        clave = Split(Datos_Ordenesprovision.Rows(x).Cells.Item("Orden_Provision").Value, "/").Skip(1).FirstOrDefault
    '        clave += Autorizaciones.Organismo
    '        clave += CType(Split(Datos_Ordenesprovision.Rows(x).Cells.Item("Orden_Provision").Value, "/").FirstOrDefault, Integer).ToString("00000")
    '        If Not LISTADECODIGOS.Contains(CType(clave, Long)) Then
    '            LISTADECODIGOS.Add(CType(clave, Long))
    '        End If
    '    Next
    '    For Z = 0 To LISTADECODIGOS.Count - 1
    '        ORDENPAGO.ORDENESPROVISION.Add(New OrdenProvision)
    '        ORDENPAGO.ORDENESPROVISION.Item(Z).cargar_OP(LISTADECODIGOS.Item(Z))
    '    Next
    'End Sub
    Private Sub DOBLE_MouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_Partidas.CellMouseDoubleClick
    End Sub

    Private Sub Datos_Ordenesprovision_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        Select Case sender.SelectionMode
            Case Is = 1 'fullrow
                sender.SelectionMode = DataGridViewSelectionMode.CellSelect
            Case Is = 0 ' cellselect
                sender.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                sender.Rows(e.RowIndex).Selected = True
        End Select
    End Sub

    Private Sub Datos_Ordenesprovision_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        datosmodificados()
    End Sub

    Private Sub Datos_ordenpago_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
    End Sub

    Private Sub Datos_Ordenesprovision_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        Datos_Ordenesprovision.Rows(e.RowIndex).Cells.Item("Tipo_instrumentolegal").Value = "DECRETO"
        Datos_Ordenesprovision.Rows(e.RowIndex).Cells.Item("Numero_instrumentolegal").Value = "488"
        Datos_Ordenesprovision.Rows(e.RowIndex).Cells.Item("Year_instrumento_legal").Value = "2000"
        '  datosmodificados()
    End Sub

    Private Sub Datos_Ordenesprovision_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs)
        datosmodificados()
    End Sub

    Private Sub datosmodificados()
        If valoresiniciales Then
            valoresmodificados = True
        Else
        End If
    End Sub

    Private Sub Datos_Partidas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Datos_Partidas.MouseDoubleClick
    End Sub

    Private Sub Datos_Ordenesprovision_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
    End Sub

    Private Sub Datos_datagridview_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub Datos_Ordenesprovision_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        'Select Case sender.Columns(e.ColumnIndex).Name.ToUpper
        '    Case Is = "CUIT"
        '        Dialogo_CUIT.Cargadetextbox(sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex))
        '        Dialogo_CUIT.Cargadecuits(ORDENPAGO.expediente_op.claveexpediente)
        '    Case Is = "CARAC"
        '        DialogDialogo_Datagridview.Carga_General(Autocompletetables.Cuentas, "Seleccione por Favor la CUENTA BANCARIA", "Seleccionar", "Cancelar", 10)
        '        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
        '            sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
        '        Else
        '        End If
        '    Case Is = "TIPO_LEGAL"
        '        DialogDialogo_Datagridview.Carga_General(TABLAINSTRUMENTOLEGAL, "Seleccione por Favor el tipo de instrumento Legal habilitante", "Seleccionar", "Cancelar", 10)
        '        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
        '            sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
        '        Else
        '        End If
        '    Case Is = "TIPO_ORIGEN"
        '        DialogDialogo_Datagridview.Carga_General(TABLAORIGEN, "Seleccione por Favor la forma de contratación utilizada", "Seleccionar", "Cancelar", 10)
        '        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
        '            sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
        '        Else
        '        End If
        'End Select
    End Sub

    Private Sub ASISTENCIADECARGA(ByVal SENDER As DataGridView)
        Select Case SENDER.Columns(SENDER.CurrentCell.ColumnIndex).Name.ToUpper
            Case Is = "CUIT"
                Dialogo_CUIT.Cargadetextbox(SENDER.Rows(SENDER.CurrentCell.RowIndex).Cells.Item(SENDER.CurrentCell.ColumnIndex))
                Dialogo_CUIT.Cargadecuits(ORDENPAGO.expediente_op.claveexpediente)
            Case Is = "CARAC"
                DialogDialogo_Datagridview.Carga_General(Autocompletetables.Cuentas, "Seleccione por Favor la CUENTA BANCARIA", "Seleccionar", "Cancelar", 10)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    SENDER.Rows(SENDER.CurrentCell.RowIndex).Cells.Item(SENDER.CurrentCell.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
                Else
                End If
            Case Is = "TIPO_LEGAL"
                DialogDialogo_Datagridview.Carga_General(TABLAINSTRUMENTOLEGAL, "Seleccione por Favor el tipo de instrumento Legal habilitante", "Seleccionar", "Cancelar", 10)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    SENDER.Rows(SENDER.CurrentCell.RowIndex).Cells.Item(SENDER.CurrentCell.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
                Else
                End If
            Case Is = "TIPO_INSTRUMENTOLEGAL"
                DialogDialogo_Datagridview.Carga_General(TABLAINSTRUMENTOLEGAL, "Seleccione por Favor el tipo de instrumento Legal habilitante", "Seleccionar", "Cancelar", 10)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    SENDER.Rows(SENDER.CurrentCell.RowIndex).Cells.Item(SENDER.CurrentCell.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
                Else
                End If
            Case Is = "TIPO_ORIGEN"
                DialogDialogo_Datagridview.Carga_General(TABLAORIGEN, "Seleccione por Favor la forma de contratación utilizada", "Seleccionar", "Cancelar", 10)
                If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                    SENDER.Rows(SENDER.CurrentCell.RowIndex).Cells.Item(SENDER.CurrentCell.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
                Else
                End If
            Case Is = "FECHA_ACTA"
                Dialog_fecha.cargageneral(CType(SENDER, DataGridView).SelectedCells(0))
        End Select
    End Sub

    Private Sub Datos_Ordenesprovision_KeyDown(sender As Object, e As KeyEventArgs)
    End Sub

    Private Sub Boton_SUGERENCIA_Click(sender As Object, e As EventArgs) Handles Boton_SUGERENCIA.Click
        cambiosdatostexto()
    End Sub

    Private Sub Datos_Ordenesprovision_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Datos_Ordenesprovision.KeyDown
        If e.KeyCode = Keys.Delete Then
            Select Case Datos_Ordenesprovision.SelectionMode
                Case Is = 1 'full row
                    'For Each DataGridViewRow In Datos_Ordenesprovision.SelectedRows
                    '    Datos_Ordenesprovision.Rows.Remove(DataGridViewRow)
                    'Next
                Case Is = 0 ' cell select
                    For Each DataGridViewCell In Datos_Ordenesprovision.SelectedCells
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

    Private Sub Datos_Ordenesprovision_RowHeaderMouseClick_1(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_Ordenesprovision.RowHeaderMouseClick
        Select Case sender.SelectionMode
            Case Is = 1 'fullrow
                sender.SelectionMode = DataGridViewSelectionMode.CellSelect
            Case Is = 0 ' cellselect
                sender.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                sender.Rows(e.RowIndex).Selected = True
        End Select
    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub FullScreen_boton_Click(sender As Object, e As EventArgs) Handles FullScreen_boton.Click
        Select Case Me.WindowState
            Case = WindowState.Maximized
                Me.WindowState = FormWindowState.Normal
            Case Else
                Me.WindowState = FormWindowState.Maximized
        End Select
    End Sub

    Private Sub Sugerencia_partidas_Click(sender As Object, e As EventArgs) Handles Sugerencia_partidas.Click
        CARGAR_PARTIDAS_SUGERIDAS()
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
        datos.Columns.Add("PDA PCIAL.", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA PPAL", System.Type.GetType("System.String"))
        datos.Columns.Add("PDA SUB PAR", System.Type.GetType("System.String"))
        datos.Columns.Add("SCD", System.Type.GetType("System.String"))
        datos.Columns.Add("IMPORTE", System.Type.GetType("System.Decimal"))
        Select Case ORDENPAGO.Ordenpago_tipo
            Case Is = "ARANCELAMIENTO"
                datos.Rows.Add({"06", "01", "2-02", "3", "10", "1", "01", "011", "01110", "", "", 0})
                datos.Rows.Add({"06", "01", "2-02", "3", "10", "1", "01", "011", "01120", "", "", 0})
                datos.Rows.Add({"06", "01", "2-02", "3", "10", "1", "01", "012", "01210", "225", "", 0})
                datos.Rows.Add({"06", "01", "2-02", "3", "10", "1", "01", "012", "01220", "230", "", 0})
                datos.Rows.Add({"06", "01", "2-02", "3", "10", "1", "03", "031", "03160", "", "", 0})
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
            Case Else
                Datos_Partidas.DataSource = PartidaPresupuestaria.partidasmasutilizadastipo(ORDENPAGO)
        End Select
    End Sub

    Private Sub Datos_Partidas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Partidas.CellValueChanged
        CALCULAR()
    End Sub

    Private Sub Panel1_MouseMove_1(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Label_ordenpagoasociada_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_ordenpagoasociada.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

End Class