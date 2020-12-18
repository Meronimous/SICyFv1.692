Public Class Contabilidad_DialogoContratos
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
    Dim NUEVAOP As Boolean = False
    Dim ordenpagovieja As New Ordendepago  'en caso de modificar se verifica los valores básicos necesarios.

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label_ordenpagoasociada.MouseMove
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

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ordenpago_detalles.KeyDown, Montototal.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Numeroexpediente_numericupdown_Enter(sender As Object, e As EventArgs) Handles ordenpago_detalles.Enter, Montototal.Enter
        If (sender.GetType.ToString = "System.Windows.Forms.TextBox") Or (sender.GetType.ToString = "System.Windows.Forms.MaskedTextBox") Then
        Else
            sender.Select(0, sender.text.ToString.Length)
        End If
    End Sub

    Private Sub Suministros_ordenpago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lugares As New DataTable
        '  Inicio.Cargadetextboxautcompleteonload2(ordenpago_LUGARENTREGA, "Select nombre from suministros_lugar_entrega order by lugar_clave ", "Nombre")
        ' unidad_terminonumericupdown.Items.AddRange({"DÍAS", "DÍAS HÁBILES", "SEMANAS", "MESES"})
        CARGADETABLAS()
    End Sub

    Private Sub Suministros_ordenpago_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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
        Dim textodetalle As String = ""
        Dim DESTINOS As New List(Of String)
        Dim ORDENES As New List(Of String)
        Dim ORIGEN As New List(Of String)
        Dim INSTRUMENTOLEGAL As New List(Of String)
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
        'Select Case Datos_Ordenesprovision.Rows.Count > 0
        '    Case True
        '        For Each OP As DataGridViewRow In Datos_Ordenesprovision.Rows
        '            'CARGA CADA UNO DE LOS DESTINOS
        '            If IsNothing(DESTINOS) Then
        '                DESTINOS.Add(OP.Cells.Item(""))
        '            Else
        '                If Not DESTINOS.Contains(OP.Destino) Then
        '                    DESTINOS.Add(OP.Destino)
        '                End If
        '            End If
        '            'CARGA CADA UNA DE LAS ORDENES DE PROVISION
        '            If IsNothing(ORDENES) Then
        '                ORDENES.Add(OP.ordenprovision_numero & "/" & OP.ordenprovision_year)
        '            Else
        '                If Not ORDENES.Contains(OP.ordenprovision_numero & "/" & OP.ordenprovision_year) Then
        '                    ORDENES.Add(OP.ordenprovision_numero & "/" & OP.ordenprovision_year)
        '                End If
        '            End If
        '            'CARGA LOS TIPOS DE INSTRUMENTOS DE ADQUISICIÓN
        '            If IsNothing(ORIGEN) Then
        '                ORIGEN.Add(OP.Tipo_origen & " Nº " & OP.Numero_origen & "/" & OP.Year_origen)
        '            Else
        '                If Not ORIGEN.Contains(OP.Tipo_origen & " Nº " & OP.Numero_origen & "/" & OP.Year_origen) Then
        '                    ORIGEN.Add(OP.Tipo_origen & " Nº " & OP.Numero_origen & "/" & OP.Year_origen)
        '                End If
        '            End If
        '            'CARGA LOS  INSTRUMENTOS LEGALES
        '            If IsNothing(INSTRUMENTOLEGAL) Then
        '                INSTRUMENTOLEGAL.Add(OP.Tipo_instrumentolegal & " Nº " & OP.Numero_instrumentolegal & "/" & OP.Year_instrumentolegal)
        '            Else
        '                If Not INSTRUMENTOLEGAL.Contains(OP.Tipo_instrumentolegal & " Nº " & OP.Numero_instrumentolegal & "/" & OP.Year_instrumentolegal) Then
        '                    INSTRUMENTOLEGAL.Add(OP.Tipo_instrumentolegal & " Nº " & OP.Numero_instrumentolegal & "/" & OP.Year_instrumentolegal)
        '                End If
        '            End If
        '        Next
        '        ''CARGA LAS ACTAS DE RECEPCIÓN
        '        'For Each AC As ACTARECEPCION In ORDENPAGO.ACTAS
        '        '    If Not ACTASRECEPCION.Contains(AC.ACTARECEPCION_NUMERO & "/" & AC.ACTARECEPCION_YEAR) Then
        '        '        ACTASRECEPCION.Add(AC.ACTARECEPCION_NUMERO & "/" & AC.ACTARECEPCION_YEAR)
        '        '    End If
        '        'Next
        '        textodetalle += "POR -MOTIVO_DE_LA_ORDEN_DE_PAGO- "
        '        Select Case ORDENES.Count
        '            Case = 0
        '                textodetalle += " SEGÚN ORD. PROV. Nº 0/" & ORDENPAGO.Ordenpago_Year
        '            Case = 1
        '                textodetalle += " SEGÚN ORD. PROV. Nº " & ORDENES(0)
        '            Case Else
        '                textodetalle += " SEGÚN LAS ORD. PROV. Nros: "
        '                For x = 0 To ORDENES.Count - 1
        '                    If x = ORDENES.Count - 1 Then
        '                        textodetalle += ORDENES(x) & " "
        '                    Else
        '                        textodetalle += ORDENES(x) & " , "
        '                    End If
        '                Next
        '        End Select
        '        Select Case ORIGEN.Count
        '            Case = 0
        '                textodetalle += " TIPO_ADQUISICIÓN Nº 0/" & ORDENPAGO.Ordenpago_Year
        '            Case = 1
        '                textodetalle += " (" & ORIGEN(0) & ") "
        '            Case Else
        '                textodetalle += " REALIZADOS POR: "
        '                For x = 0 To ORIGEN.Count - 1
        '                    If x = ORIGEN.Count - 1 Then
        '                        textodetalle += ORIGEN(x) & " "
        '                    Else
        '                        textodetalle += ORIGEN(x) & " , "
        '                    End If
        '                Next
        '        End Select
        '        Select Case INSTRUMENTOLEGAL.Count
        '            Case = 0
        '                textodetalle += " INSTRUMENTO_LEGAL Nº 0/" & ORDENPAGO.Ordenpago_Year
        '            Case = 1
        '                textodetalle += " AUTORIZADO POR: " & INSTRUMENTOLEGAL(0)
        '            Case Else
        '                textodetalle += " AUTORIZADO POR: "
        '                For x = 0 To INSTRUMENTOLEGAL.Count - 1
        '                    If x = INSTRUMENTOLEGAL.Count - 1 Then
        '                        textodetalle += INSTRUMENTOLEGAL(x) & " "
        '                    Else
        '                        textodetalle += INSTRUMENTOLEGAL(x) & " , "
        '                    End If
        '                Next
        '        End Select
        '    Case False
        'End Select
        Select Case ORDENPAGO.ORDENESPROVISION.Count > 0
            Case True
                For Each OP As OrdenProvision In ORDENPAGO.ORDENESPROVISION
                    'CARGA CADA UNO DE LOS DESTINOS
                    If IsNothing(DESTINOS) Then
                        DESTINOS.Add(OP.Destino)
                    Else
                        If Not DESTINOS.Contains(OP.Destino) Then
                            DESTINOS.Add(OP.Destino)
                        End If
                    End If
                    'CARGA CADA UNA DE LAS ORDENES DE PROVISION
                    If IsNothing(ORDENES) Then
                        ORDENES.Add(OP.OrdenProvisionNumero & "/" & OP.OrdenProvisionYear)
                    Else
                        If Not ORDENES.Contains(OP.OrdenProvisionNumero & "/" & OP.OrdenProvisionYear) Then
                            ORDENES.Add(OP.OrdenProvisionNumero & "/" & OP.OrdenProvisionYear)
                        End If
                    End If
                    'CARGA LOS TIPOS DE INSTRUMENTOS DE ADQUISICIÓN
                    If IsNothing(ORIGEN) Then
                        ORIGEN.Add(OP.TipoOrigen & " Nº " & OP.NumeroOrigen & "/" & OP.YearOrigen)
                    Else
                        If Not ORIGEN.Contains(OP.TipoOrigen & " Nº " & OP.NumeroOrigen & "/" & OP.YearOrigen) Then
                            ORIGEN.Add(OP.TipoOrigen & " Nº " & OP.NumeroOrigen & "/" & OP.YearOrigen)
                        End If
                    End If
                    'CARGA LOS  INSTRUMENTOS LEGALES
                    If IsNothing(INSTRUMENTOLEGAL) Then
                        INSTRUMENTOLEGAL.Add(OP.TipoInstrumentoLegal & " Nº " & OP.NumeroInstrumentoLegal & "/" & OP.YearInstrumentoLegal)
                    Else
                        If Not INSTRUMENTOLEGAL.Contains(OP.TipoInstrumentoLegal & " Nº " & OP.NumeroInstrumentoLegal & "/" & OP.YearInstrumentoLegal) Then
                            INSTRUMENTOLEGAL.Add(OP.TipoInstrumentoLegal & " Nº " & OP.NumeroInstrumentoLegal & "/" & OP.YearInstrumentoLegal)
                        End If
                    End If
                Next
                ''CARGA LAS ACTAS DE RECEPCIÓN
                'For Each AC As ACTARECEPCION In ORDENPAGO.ACTAS
                '    If Not ACTASRECEPCION.Contains(AC.ACTARECEPCION_NUMERO & "/" & AC.ACTARECEPCION_YEAR) Then
                '        ACTASRECEPCION.Add(AC.ACTARECEPCION_NUMERO & "/" & AC.ACTARECEPCION_YEAR)
                '    End If
                'Next
                Select Case ORDENES.Count
                    Case = 0
                        textodetalle += "POR ADQUISICIÓN DE ***************** "
                        textodetalle += " SEGÚN ORD. PROV. Nº 0/" & ORDENPAGO.Ordenpago_Year
                    Case = 1
                        textodetalle += "POR ADQUISICIÓN DE " & Datos_Ordenesprovision.Rows(0).Cells.Item("DETALLE_ACTA").Value
                        textodetalle += " SEGÚN ORD. PROV. Nº " & ORDENES(0)
                    Case Else
                        textodetalle += "POR ADQUISICIÓN DE LOS ITEMS DETALLADOS "
                        textodetalle += " SEGÚN LAS ORD. PROV. Nros: "
                        For x = 0 To ORDENES.Count - 1
                            If x = ORDENES.Count - 1 Then
                                textodetalle += ORDENES(x) & " "
                            Else
                                textodetalle += ORDENES(x) & " , "
                            End If
                        Next
                End Select
                Select Case ORIGEN.Count
                    Case = 0
                        textodetalle += " TIPO_ADQUISICIÓN Nº 0/" & ORDENPAGO.Ordenpago_Year
                    Case = 1
                        textodetalle += " (" & ORIGEN(0) & ") "
                    Case Else
                        textodetalle += " REALIZADOS POR: "
                        For x = 0 To ORIGEN.Count - 1
                            If x = ORIGEN.Count - 1 Then
                                textodetalle += ORIGEN(x) & " "
                            Else
                                textodetalle += ORIGEN(x) & " , "
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
        cargadedatagridview()
        Datos_Partidas.DataSource = PartidaPresupuestaria.estructurapartidadatatable()
        '  Datos_ActasRecepcion.DataSource = ACTARECEPCION.estructuraActaRecepcion
        Datos_Ordenesprovision.DataSource = OrdenProvision.Estructura_Seleccionordenprovision
    End Sub

    Private Sub cargadedatagridview()
        'Datos_Partidas.DataSource = New DataView(datosordenpago)
        'For x = 0 To Datos_Partidas.Columns.Count - 1
        '    With Datos_Partidas.Columns(x).DefaultCellStyle
        '        .FormatProvider = Globalization.CultureInfo.GetCultureInfo("es-AR")
        '    End With
        'Next
        'Datos_Partidas.Columns("Cant.").DefaultCellStyle.Format = "N2"
        ''Datos_ordenpago.Columns("Cant.").DefaultCellStyle.Format = "N2"
        'Datos_Partidas.Columns("Prec.Unit.").DefaultCellStyle.Format = "C"
        'Datos_Partidas.Columns("Prec.Total").DefaultCellStyle.Format = "C"
        'Datos_Partidas.Columns("Reng.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_Partidas.Columns("Cant.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_Partidas.Columns("Un.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_Partidas.Columns("Prec.Unit.").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_Partidas.Columns("Prec.Total").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datos_Partidas.Columns("Articulos.").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'Datos_Partidas.Columns("Detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

    Public Sub Cargardatosamodificar(ByVal ORDENPAGOS As Ordendepago, ByVal NUEVO As Boolean)
        NUEVAOP = NUEVO
        OPparamodificar = Not NUEVO 'Es una orden de pago para modificar
        ORDENPAGO = ORDENPAGOS
        datosordenpagodatatable = ORDENPAGO.DatosOrdenPago
        OPNumero_numericupdown.Value = ORDENPAGO.ordenpago_numero
        OPyear_numericupdown.Value = ORDENPAGO.Ordenpago_Year
        ordenpago_detalles.Text = ORDENPAGO.ordenpago_Detalle
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
        Montototal.Value = ORDENPAGO.ordenpago_montototal
        'tabla de datos
        Datos_Partidas.DataSource = PartidaPresupuestaria.estructurapartidadatatable(ORDENPAGO.Clave_ordenpago)
        'Datos_ActasRecepcion.DataSource = ACTARECEPCION.estructuraActaRecepcion(ORDENPAGO.Clave_ordenpago)
        Datos_Ordenesprovision.DataSource = OrdenProvision.Estructura_Seleccionordenprovision(ORDENPAGO.Clave_ordenpago)
        cargadedatagridview()
        valoresiniciales = False
        Mostrardialogo(Me)
        encabezadodialogo()
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
                    PDF_ORDENPAGO_PagoV2(ORDENPAGO) 'PDF_ORDENPAGO_Pago(ORDENPAGO, "LEGAL")
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

    Private Sub guardardatosOP()
        ORDENPAGO.ordenpago_numero = OPNumero_numericupdown.Value
        ORDENPAGO.Ordenpago_Year = OPyear_numericupdown.Value
        ORDENPAGO.ordenpago_Detalle = ordenpago_detalles.Text
        ORDENPAGO.ordenpago_fecha = Fechaconfeccion_datetimepicker.Value
        ORDENPAGO.Ordenpago_tipo = "PAGO"
        ORDENPAGO.CLASE_FONDO = CLASEOP.Text
        ORDENPAGO.ESTADO = ESTADOOP.Text
        ORDENPAGO.Clave_ordenpago = CType(ORDENPAGO.Ordenpago_Year & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(ORDENPAGO.ordenpago_numero), "00000"), Long)
        If Numeroexpediente_numericupdown.Value > 0 And Organismo_numericupdown.Value > 0 Then
            ORDENPAGO.ClaveExpediente_principal = CType(Year_numericupdown.Value & Organismo_numericupdown.Value & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
        Else
        End If
        ORDENPAGO.ACTAS.Clear()
        ORDENPAGO.Datatable_a_ACTAS(CType(Datos_Ordenesprovision.DataSource, DataTable))
        ORDENPAGO.Partida_datatable = CType(Datos_Partidas.DataSource, DataTable)
        ORDENPAGO.Partidas.Clear()
        ORDENPAGO.Datatable_a_Partidas()
        ORDENPAGO.Datatable_a_insertarordenesprovision(CType(Datos_Ordenesprovision.DataSource, DataTable))
        Dim clave As String = ""
        Dim tabla As DataTable
        tabla = CType(Datos_Ordenesprovision.DataSource, DataTable)
        ORDENPAGO.ORDENESPROVISION.Clear()
        ORDENPAGO.Datatable_A_OPROVISION(tabla)
        ORDENPAGO.ordenpago_montototal = Montototal.Value
        'tabla de orden de provisión
        ORDENPAGO.DatosOrdenPago = CType(Datos_Partidas.DataSource, DataTable)
        '/tabla de orden de provisión
        ORDENPAGO.Insertar_ordenpago()
        claveguardada = ORDENPAGO.Clave_ordenpago
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

    Private Function ManejoNothing(ByVal Elemento As Object) As String
        Dim ValorRetornado As String
        If IsNothing(Elemento) Then
            ValorRetornado = ""
        Else
            ValorRetornado = Elemento.ToString
        End If
        Return ValorRetornado
    End Function

    Private Sub Label10_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Cuit_boton_Click(sender As Object, e As EventArgs)
        '  Dialogo_CUIT.Cargadetextbox(Cuitdelbeneficiario_textbox)
        '  Dialogo_CUIT.Cargadecuits(ORDENPAGO.Clave_expediente)
    End Sub

    Private Sub Label_montonombre_Click(sender As Object, e As EventArgs) Handles Label_montonombre.Click
    End Sub

    Private Sub Monto_factura_textbox_ValueChanged(sender As Object, e As EventArgs) Handles Montototal.ValueChanged
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Cuitdelbeneficiario_textbox_TextChanged(sender As Object, e As EventArgs)
        '   VerificarCUIT(sender, sender.text, Beneficiario_label, DOMICILIO)
    End Sub

    Private Sub Datos_ordenpago_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Partidas.CellValueChanged
        CALCULAR()
    End Sub

    Private Function CALCULO_CANTIDADES(ByVal FILA As DataGridViewRow) As Decimal
        Dim PrecioTotal As Decimal
        If Not IsDBNull(FILA.Cells.Item("CANT.").Value) And Not IsDBNull(FILA.Cells.Item("PREC.UNIT.").Value) Then
            If FILA.Cells.Item("CANT.").Value > 0 And FILA.Cells.Item("PREC.UNIT.").Value > 0 Then
                PrecioTotal = FILA.Cells.Item("CANT.").Value * FILA.Cells.Item("PREC.UNIT.").Value
            Else
                PrecioTotal = 0
            End If
        Else
            PrecioTotal = 0
        End If
        Return Math.Round(PrecioTotal, 2)
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
        Carga_orden_pago()
    End Sub

    Private Sub OPyear_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles OPyear_numericupdown.ValueChanged
        Carga_orden_pago()
    End Sub

    Private Sub ordenpago_INICIADOR_TextChanged(sender As Object, e As EventArgs) Handles ordenpago_detalles.TextChanged
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

    Private Sub OPNumero_numericupdown_Leave(sender As Object, e As EventArgs) Handles OPNumero_numericupdown.Leave
        encabezadodialogo()
    End Sub

    Private Sub Datos_ordenpago_KeyDown(sender As Object, e As KeyEventArgs) Handles Datos_Partidas.KeyDown
        If e.KeyCode = Keys.Delete Then
            Select Case Datos_Partidas.SelectionMode
                Case Is = 1 'full row
                    For Each DataGridViewRow In Datos_Partidas.SelectedRows
                        Datos_Partidas.Rows.Remove(DataGridViewRow)
                    Next
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
        End If
    End Sub

    Private Sub Datos_ordenpago_DataError(sender As DataGridView, e As DataGridViewDataErrorEventArgs) Handles Datos_Partidas.DataError, Datos_Ordenesprovision.DataError
        sender.Rows(e.RowIndex).ErrorText = "La celda no admite este tipo de datos, presione Escape si desea cancelar la modificación"
        MessageBox.Show(sender.Rows(e.RowIndex).ErrorText)
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
        If NUEVAOP And ORDENPAGO.Clave_ordenpago <> claveguardada Then
            If ORDENPAGO.verificarexistencia(CType(ORDENPAGO.Ordenpago_Year & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(ORDENPAGO.ordenpago_numero), "00000"), Long)) Then
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

    Private Sub Datos_ordenpago_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_Partidas.MouseUp
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

    Private Sub Datos_ordenpago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Datos_Partidas.KeyPress
        'If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = "," Or e.KeyChar = ".") Then
        '    e.Handled = True
        'Else
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub DOBLE_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Datos_Partidas.MouseDoubleClick, Datos_Partidas.CellMouseDoubleClick
        'Cargaymodificaciondatatable(Me, CType(sender.DataSource, DataTable), sender)
        Dialogo_ModificarDatatable.CargarDatatable(Me, CType(sender.DataSource, DataTable), sender, ORDENPAGO.expediente_op.claveexpediente)
        sender.Refresh()
        CALCULAR()
    End Sub

    Private Sub Datos_Ordenesprovision_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Datos_Ordenesprovision.MouseDoubleClick
        AGREGARORDENPROVISION()
    End Sub

    Private Sub AGREGARORDENPROVISION()
        'Dim ORDENPROV As New OrdenProvision
        DialogDialogo_Datagridview.Carga_General(OrdenProvision.Ordenesprovision_expediente(ORDENPAGO.expediente_op.claveexpediente), "Seleccione por Favor la orden de Provisión", "Seleccionar", "Cancelar", 11)
        If DialogDialogo_Datagridview.Datosdialogo_datagridview.Rows.Count > 0 Then
            If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                CType(Datos_Ordenesprovision.DataSource, DataTable).Rows.Add({DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value,
                                                                         DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value,
                                                                         DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value,
                                                                         DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(3).Value,
                                                                         DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(4).Value,
                                                                         DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(5).Value,
                                                                         DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(6).Value})
                'ORDENPROV.Destino = ""
                'ORDENPROV.ordenprovision_numero = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(0).Value.ToString, "/").FirstOrDefault, Integer)
                'ORDENPROV.ordenprovision_year = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(0).Value.ToString, "/").Skip(1).FirstOrDefault, Integer)
                'ORDENPROV.Tipo_origen = Datos_Ordenesprovision.Rows(0).Cells.Item(4).Value.ToString
                'ORDENPROV.Numero_origen = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(5).Value.ToString, "/").FirstOrDefault, Integer)
                'ORDENPROV.Year_origen = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(5).Value.ToString, "/").Skip(1).FirstOrDefault, Integer)
                'ORDENPROV.Tipo_instrumentolegal = Datos_Ordenesprovision.Rows(0).Cells.Item(2).Value.ToString
                'ORDENPROV.Numero_instrumentolegal = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(3).Value.ToString, "/").FirstOrDefault, Integer)
                'ORDENPROV.Year_instrumentolegal = CType(Split(Datos_Ordenesprovision.Rows(0).Cells.Item(3).Value.ToString, "/").Skip(1).FirstOrDefault, Integer)
                'ORDENPROV.CUIT = Datos_Ordenesprovision.Rows(0).Cells.Item(6).Value
                'ORDENPROV.Cargardatos()
                'ORDENPAGO.ORDENESPROVISION.Add(ORDENPROV)
                CARGADEORDENESPROVISION()
                'cambiosdatostexto()
            Else
            End If
        Else
            Dialogo_ModificarDatatable.CargarDatatable(Me, CType(Datos_Ordenesprovision.DataSource, DataTable), Datos_Ordenesprovision, ORDENPAGO.expediente_op.claveexpediente)
        End If
    End Sub

    Private Sub CALCULAR()
        TOTALACTASRECEPCION = 0
        TOTALPARTIDAS = 0
        TOTALORDENESPROVISION = 0
        For O As Integer = 0 To Datos_Ordenesprovision.Rows.Count - 1
            If Not IsDBNull(Datos_Ordenesprovision.Rows(O).Cells.Item("MONTO_ACTA").Value) Then
                TOTALACTASRECEPCION += Datos_Ordenesprovision.Rows(O).Cells.Item("MONTO_ACTA").Value
                If Not IsDBNull(Datos_Ordenesprovision.Rows(O).Cells.Item("MULTA_MONTO").Value) Then
                    TOTALACTASRECEPCION += Datos_Ordenesprovision.Rows(O).Cells.Item("MULTA_MONTO").Value
                End If
            End If
        Next
        For P As Integer = 0 To Datos_Partidas.Rows.Count - 1
            If Not IsDBNull(Datos_Partidas.Rows(P).Cells.Item("IMPORTE").Value) Then
                TOTALPARTIDAS += Datos_Partidas.Rows(P).Cells.Item("IMPORTE").Value
            End If
        Next
        For Q As Integer = 0 To Datos_Ordenesprovision.Rows.Count - 1
            If Not IsDBNull(Datos_Ordenesprovision.Rows(Q).Cells.Item("MONTO").Value) Then
                TOTALORDENESPROVISION += Datos_Ordenesprovision.Rows(Q).Cells.Item("MONTO").Value
            End If
        Next
        Montototal.Value = TOTALACTASRECEPCION
        PARTIDAS_TOTALNUMERICAUPDOWN.Value = TOTALPARTIDAS
    End Sub

    'Private Sub Datos_ActasRecepcion_DataSourceChanged(sender As Object, e As EventArgs) Handles Datos_ActasRecepcion.DataSourceChanged
    '    CALCULAR()
    'End Sub
    Private Sub Datos_Ordenesprovision_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Ordenesprovision.RowValidated, Datos_Partidas.RowValidated
        Try
            If sender.Name = Datos_Ordenesprovision.Name Then
                CARGADEORDENESPROVISION()
            End If
        Catch ex As Exception
        End Try
        CALCULAR()
    End Sub

    Private Sub CARGADEORDENESPROVISION()
        Dim LISTADECODIGOS As New List(Of Long)
        ORDENPAGO.ORDENESPROVISION.Clear()
        For x = 0 To Datos_Ordenesprovision.Rows.Count - 1
            clave = Split(Datos_Ordenesprovision.Rows(x).Cells.Item("Orden_Provision").Value, "/").Skip(1).FirstOrDefault
            clave += Autorizaciones.Organismo
            clave += CType(Split(Datos_Ordenesprovision.Rows(x).Cells.Item("Orden_Provision").Value, "/").FirstOrDefault, Integer).ToString("00000")
            If Not LISTADECODIGOS.Contains(CType(clave, Long)) Then
                LISTADECODIGOS.Add(CType(clave, Long))
            End If
        Next
        For Z = 0 To LISTADECODIGOS.Count - 1
            ORDENPAGO.ORDENESPROVISION.Add(New OrdenProvision)
            ORDENPAGO.ORDENESPROVISION.Item(Z).cargar_OP(LISTADECODIGOS.Item(Z))
        Next
    End Sub

    Private Sub FullScreen_boton_Click(sender As Object, e As EventArgs) Handles FullScreen_boton.Click
        Select Case Me.WindowState
            Case = WindowState.Maximized
                Me.WindowState = FormWindowState.Normal
            Case Else
                Me.WindowState = FormWindowState.Maximized
        End Select
    End Sub

    Private Sub Boton_SUGERENCIA_Click(sender As Object, e As EventArgs) Handles Boton_SUGERENCIA.Click
        cambiosdatostexto()
    End Sub

    Private Sub Datos_Ordenesprovision_KeyDown(sender As DataGridView, e As KeyEventArgs) Handles Datos_Ordenesprovision.KeyDown
        If e.Alt Then
            If Not sender.IsCurrentCellInEditMode Then
                ASISTENCIADECARGA(sender)
            End If
        Else
            Select Case e.KeyCode
                Case Is = Keys.Delete
                    Select Case Datos_Ordenesprovision.SelectionMode
                        Case Is = 1 'full row
                            For Each DataGridViewRow In Datos_Ordenesprovision.SelectedRows
                                Datos_Ordenesprovision.Rows.Remove(DataGridViewRow)
                            Next
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
            End Select
        End If
    End Sub

    Private Sub DOBLE_MouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_Partidas.CellMouseDoubleClick
    End Sub

    Private Sub Datos_Ordenesprovision_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_Ordenesprovision.RowHeaderMouseClick, Datos_Partidas.RowHeaderMouseClick
        Select Case sender.SelectionMode
            Case Is = 1 'fullrow
                sender.SelectionMode = DataGridViewSelectionMode.CellSelect
            Case Is = 0 ' cellselect
                sender.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                sender.Rows(e.RowIndex).Selected = True
        End Select
    End Sub

    Private Sub Datos_Ordenesprovision_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles Datos_Ordenesprovision.CurrentCellDirtyStateChanged, Datos_Partidas.CurrentCellDirtyStateChanged
        datosmodificados()
    End Sub

    Private Sub Datos_ordenpago_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datos_Partidas.DataError, Datos_Ordenesprovision.DataError
    End Sub

    Private Sub Datos_Ordenesprovision_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles Datos_Ordenesprovision.RowsAdded
        '  datosmodificados()
    End Sub

    Private Sub Datos_Ordenesprovision_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles Datos_Ordenesprovision.UserDeletedRow
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

    Private Sub Datos_Ordenesprovision_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Datos_Ordenesprovision.EditingControlShowing
        Select Case CType(sender, DataGridView).SelectedCells(0).ValueType.ToString
            Case Is = "System.Int32"
               ' MessageBox.Show("Esta celda solo admite números enteros")
            Case Is = "System.Decimal"
                AddHandler e.Control.KeyPress, AddressOf Datos_datagridview_KeyPress
            Case Is = "System.String"
            Case Is = "System.DateTime"
                Dialog_fecha.cargageneral(CType(sender, DataGridView).SelectedCells(0))
        End Select
    End Sub

    Private Sub Datos_datagridview_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub Datos_Ordenesprovision_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_Ordenesprovision.CellDoubleClick
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

    Private Sub Datos_Ordenesprovision_KeyDown(sender As Object, e As KeyEventArgs) Handles Datos_Ordenesprovision.KeyDown
    End Sub

End Class