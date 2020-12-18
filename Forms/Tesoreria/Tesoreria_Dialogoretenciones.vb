Public Class Tesoreria_Dialogoretenciones
    Dim tablatemporal As New DataTable
    Dim Ganancias_retenciones_ResponsableInscripto As New DataTable
    Dim Ganancias_retenciones_ResponsableNOInscripto As New DataTable
    Dim Ganancias_retenciones_Monotributista As New DataTable
    Dim Inscripcionafip As New DataTable
    Dim Porcentajes_IVA As New DataTable
    Dim SUSS_RETENCIONES As New DataTable
    Dim DGR_RETENCIONES As New DataTable
    Dim Factura_ACTUAL As New Factura
    Dim Expediente_Actual As New Expediente
    Dim movimiento_actual As New Movimiento
    Dim Ganancias_impuesto As New Retencion
    Dim SUSS_impuesto As New Retencion
    Dim IVA_impuesto As New Retencion
    Dim DGR_impuesto As New Retencion
    Dim proveedor_actual As New Proveedor
    Dim IMPUESTOS_LISTA As New List(Of Retencion)
    Dim CUENTABANCARIA As String = ""
    Dim CARGAREALIZADA As Boolean = False

    'Dim dv As DataView
    Public Sub IniciadorDatos(ByVal Consultasql As String, ByVal Nombredatos As String)
        Dim Tablatemporal2 As New DataTable
        'MessageBox.Show(Consultamysqlsinparametros)
        SERVIDORMYSQL.COMMANDSQL.CommandText = Consultasql
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultasql, Tablatemporal2, System.Reflection.MethodBase.GetCurrentMethod.Name)
        tablatemporal = Tablatemporal2
        'Ganancias_datagridview.DataSource = tablatemporal
        '        Label_Informacion.Text = Nombredatos
        Label_expedienteasociados.Text = Nombredatos
        Me.ShowDialog()
    End Sub

    Public Sub Carga_general(ByVal movimiento As Movimiento, ByVal Expediente As Expediente, ByVal CUENTA As String)
        Expediente_Actual = Expediente
        movimiento_actual = movimiento
        Label_expedienteasociados.Text = "Retenciones expte: " & Expediente_Actual.Expediente_N
        For Each ret As Retencion In movimiento_actual.retenciones
            If ret.Nombre_retencion = "GANANCIAS" Then
                Ganancias_impuesto = ret
            ElseIf ret.Nombre_retencion = "SUSS" Then
                SUSS_impuesto = ret
            ElseIf ret.Nombre_retencion = "IVA" Then
                IVA_impuesto = ret
            ElseIf ret.Nombre_retencion = "DGR" Then
                DGR_impuesto = ret
            Else
                MessageBox.Show("Error al cargar retención: " & ret.Nombre_retencion)
            End If
        Next
        CUENTABANCARIA = CUENTA
        Mostrardialogo(Me)
    End Sub

    Private Sub Dialogoretenciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tipo_clasefondo_combobox.Items.Add("Fondos Permanentes")
        Tipo_clasefondo_combobox.Items.Add("Fondos especiales")
        Tipo_clasefondo_combobox.Items.Add("Residuos pasivos")
        If Ordendeentregayear_integerupdown.Value = 2000 Then
            Ordendeentregayear_integerupdown.Value = Date.Now.Year
        End If
        TODOACERO()
        IMPUESTOS_LISTA.Clear()
        IMPUESTOS_LISTA.Add(Ganancias_impuesto)
        IMPUESTOS_LISTA.Add(SUSS_impuesto)
        IMPUESTOS_LISTA.Add(DGR_impuesto)
        IMPUESTOS_LISTA.Add(IVA_impuesto)
    End Sub

    Private Sub Dialogoretenciones_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cargadetablas()
        GRUPOSINVISIBLES()
        AcumuladosCUIT(movimiento_actual.Clave_expediente_detalle)
        CARGAREALIZADA = True
        If Not Cuitdelbeneficiario_textbox.Text = "  -        -" Then
            Factura_ACTUAL.CUIT = Cuitdelbeneficiario_textbox.Text
            Factura_ACTUAL.Fecha = Fecha_factura.Value
            Factura_ACTUAL.totalmesencurso = Factura_ACTUAL.mesencurso(movimiento_actual.Clave_expediente_detalle)
            Factura_ACTUAL.total12meses = Factura_ACTUAL.Calculo12meses(movimiento_actual.Clave_expediente_detalle)
            Factura_ACTUAL.totalaniocalendario = Factura_ACTUAL.calculocalendario(movimiento_actual.Clave_expediente_detalle)
            Facturadomes_label.Text = Factura_ACTUAL.totalmesencurso.ToString("C")
            Facturado12meses_label.Text = Factura_ACTUAL.total12meses.ToString("C")
            Facturadoanio_label.Text = Factura_ACTUAL.totalaniocalendario.ToString("C")
        End If
        '  AcumuladosCUIT()
    End Sub

    Private Sub cargadetablas()
        cargaganancias()
        cargasuss()
        cargaiva()
        cargadgr()
        If IsNothing(movimiento_actual.Clave_expediente_detalle) Or movimiento_actual.Clave_expediente_detalle = 0 Then
            cargavaloresdefault()
        Else
            Cargavalores_a_modificar()
            If movimiento_actual.retenciones.Count > 0 Then
                Dim iva_sino As Integer = 0 'implica el valor "NO" del combobox de iva
                For x = 0 To movimiento_actual.retenciones.Count - 1
                    Select Case movimiento_actual.retenciones(x).Nombre_retencion
                        Case Is = "GANANCIAS"
                            Ganancias_impuesto = movimiento_actual.retenciones(x)
                            Cargadeimpuesto_engroupbox(Ganancias_impuesto, GANANCIAS_GROUPBOX)
                            Ganancias_Flicker_Numericupdown.Value = movimiento_actual.retenciones(x).Monto_retenido
                        Case Is = "SUSS"
                            Empleador_combobox.Text = "SI"
                            SUSS_impuesto = movimiento_actual.retenciones(x)
                            Cargadeimpuesto_engroupbox(SUSS_impuesto, SUSS_GROUPBOX)
                            SUSS_Flicker_Numericupdown.Value = movimiento_actual.retenciones(x).Monto_retenido
                        Case Is = "DGR"
                            DGR_impuesto = movimiento_actual.retenciones(x)
                            Cargadeimpuesto_engroupbox(DGR_impuesto, DGR_GROUPBOX)
                            DGR_Flicker_Numericupdown.Value = movimiento_actual.retenciones(x).Monto_retenido
                        Case Is = "IVA"
                            iva_sino = 1  'implica el valor "SI" del combobox de iva
                            IVA_impuesto = movimiento_actual.retenciones(x)
                            Cargadeimpuesto_engroupbox(IVA_impuesto, IVA_GROUPBOX)
                            IVA_Flicker_Numericupdown.Value = movimiento_actual.retenciones(x).Monto_retenido
                    End Select
                Next
                Sujeto_iva_Combobox.SelectedIndex = iva_sino
                Responsabletipo_boton.Text = movimiento_actual.retenciones(0).Situacionfrente_afip
                NetoAFTERIVA_textbox.Value = movimiento_actual.retenciones(0).Neto_IVA
                IVA_boton.Text = movimiento_actual.retenciones(0).Porcentaje_iva
                Factura_ACTUAL.Porcentaje_iva = movimiento_actual.retenciones(0).Porcentaje_iva
            End If
        End If
    End Sub

    Private Sub cargavaloresdefault()
        'cARGA DE VALORES HABITUALMENTE MÁS USADOS
        movimiento_actual.agregaromodificarmovimiento()
        Responsabletipo_boton.Text = "INSCRIPTO"
        IVA_boton.Text = "21"
        Empleador_combobox.SelectedIndex = 0
        Tipo_orden_combobox.SelectedIndex = 0
        ' Tipo_clasefondo_combobox.SelectedIndex = 2
        Select Case movimiento_actual.Clase_fondo
            Case Is = 1
                Tipo_clasefondo_combobox.SelectedIndex = 0
            Case Is = 2
                Tipo_clasefondo_combobox.SelectedIndex = 1
            Case Is = 9
                Tipo_clasefondo_combobox.SelectedIndex = 2
            Case Else
                Tipo_clasefondo_combobox.SelectedIndex = 1
        End Select
        'Ordendeentregayear_integerupdown.Value = Date.Now.Year
    End Sub

    Private Sub Cargavalores_a_modificar()
        Cuitdelbeneficiario_textbox.Text = movimiento_actual.CUIT
        Nro_Transferencia_numericupdown.Value = movimiento_actual.Transferencia
        Tipo_orden_combobox.SelectedIndex = ELEGIRCOMBOBOX(Tipo_orden_combobox, ELEGIRdatatable(Autocompletetables.Clasefondo, movimiento_actual.Cod_orden.ToString, 0, 1))
        Ordendeentrega_integerupdown.Value = movimiento_actual.Orden
        Ordendeentregayear_integerupdown.Value = movimiento_actual.Orden_year
        Monto_factura_textbox.Value = movimiento_actual.Total_factura
        Chequetotal_numeric.Value = movimiento_actual.Monto_movimiento
        Fecha_factura.Value = movimiento_actual.Fecha_movimiento
        Factura_ACTUAL.Total_factura = movimiento_actual.Total_factura
        Select Case movimiento_actual.Clase_fondo
            Case Is = 1
                Tipo_clasefondo_combobox.SelectedIndex = 0
            Case Is = 2
                Tipo_clasefondo_combobox.SelectedIndex = 1
            Case Is = 9
                Tipo_clasefondo_combobox.SelectedIndex = 2
            Case Else
                Tipo_clasefondo_combobox.SelectedIndex = 1
        End Select
        'Tipo_clasefondo_combobox.SelectedIndex = movimiento_actual.Clase_fondo
        Detalle_textbox.Text = movimiento_actual.Descripcion_movimiento
        Responsabletipo_boton.Text = Factura_ACTUAL.Situacionfrente_afip
        AcumuladosCUIT(movimiento_actual.Clave_expediente_detalle)
        CALCULOIVA()
    End Sub

    Private Sub cargaganancias()
        'tipo de retenciones ganancias
        With Ganancias_retenciones_ResponsableInscripto
            With .Columns
                .Add("Tipo")
                .Add("Minimo_no_imponible", GetType(Decimal))
                .Add("Ret_Min", GetType(Decimal))
                .Add("Alicuota", GetType(Decimal))
            End With
            With .Rows
                .Add("", 0, 0, 0)
                .Add("ENAJENACION DE BS MUEBLES Y BS DE CAMBIO", 224000, 240, 2)
                .Add("Loc OB Y SERV.", 67170, 240, 2)
                .Add("LOCACION BS INMUEBLES", 11200, 240, 6)
                .Add("PROFESIONES LIBERALES", 16830, 240, 0)
                .Add("SUBSIDIOS VTA COSA MUEBLE", 76140, 240, 2)
                .Add("SUBSIDIOS OB Y SERV", 31460, 240, 2)
            End With
        End With
        With Ganancias_retenciones_ResponsableNOInscripto
            With .Columns
                .Add("Tipo ")
                .Add("Minimo_no_imponible", GetType(Decimal))
                .Add("Ret_Min", GetType(Decimal))
                .Add("Alicuota", GetType(Decimal))
            End With
            With .Rows
                .Add("", 0, 0, 0)
                .Add("ENAJENACION DE BS MUEBLES Y BS DE CAMBIO", 224000, 1020, 10)
                .Add("Loc OB Y SERV.", 67170, 1020, 28)
                .Add("LOCACION BS INMUEBLES", 11200, 1020, 28)
                .Add("PROFESIONES LIBERALES", 16830, 1020, 28)
                .Add("SUBSIDIOS VTA COSA MUEBLE", 76140, 1020, 10)
                .Add("SUBSIDIOS OB Y SERV", 31460, 1020, 28)
            End With
        End With
        With Ganancias_retenciones_Monotributista
            With .Columns
                .Add("Tipo ")
                .Add("Minimo_no_imponible", GetType(Decimal))
                .Add("Ret_Min", GetType(Decimal))
                .Add("Alicuota", GetType(Decimal))
            End With
            With .Rows
                .Add("", 0, 0, 0)
                .Add("ENAJENACION DE BS MUEBLES Y BS DE CAMBIO", 1726599.88, 0, 35) 'IMPUESTO 217 REGIMEN 355
                .Add("Loc OB Y SERV.", 1151066.58, 0, 35)
                .Add("LOCACION BS INMUEBLES", 0, 0, 35)
                .Add("PROFESIONES LIBERALES", 0, 0, 35) 'IMPUESTO 217 REGIMEN 116
                .Add("SUBSIDIOS VTA COSA MUEBLE", 0, 0, 35)
                .Add("SUBSIDIOS OB Y SERV", 0, 0, 35)
            End With
        End With
    End Sub

    Private Sub cargasuss()
        'SUSS RETENCIONES
        With SUSS_RETENCIONES
            With .Columns
                .Add("TIPO")
                .Add("Minimo_no_imponible", GetType(Decimal))
                .Add("Ret_Min", GetType(Decimal))
                .Add("Alicuota", GetType(Decimal))
                .Add("cod.regimen", GetType(Integer))
                .Add("cod.impuesto", GetType(Integer))
            End With
            With .Rows
                .Add("", 0, 0, 0)
                .Add("LIMPIEZA", 0, 400, 6, 748, 353)
                .Add("SEGURIDAD E INVESTIG", 80000, 0, 6, 754, 353)
                .Add("VTA COSA MUEBLE, Loc OBRA Y/O SERV.", 0, 0, 1, 755, 353)
                .Add("OBRAS DE INGENIERÍA", 1500000, 0, 1.2, 740, 353)
                .Add("OBRAS DE ARQUITECTURA", 1500000, 0, 2.5, 740, 353)
            End With
        End With
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

    Private Sub cargadgr()
        'DGR RETENCIONES
        With DGR_RETENCIONES
            With .Columns
                .Add("TIPO")
                .Add("Minimo_no_imponible", GetType(Decimal))
                .Add("Ret_Min", GetType(Decimal))
                .Add("Alicuota", GetType(Decimal))
            End With
            With .Rows
                .Add("", 0, 0, 0)
                .Add("COMPRA O CONTRATACION DE BIENES O PRESTACION DE OBRAS O SERVICIOS ", 203.9, 0, 4.29)
                .Add("CONVENIO MULTILATERAL CON SEDE EN OTRAS PROVINCIAS ", 203.9, 0, 1.96)
                .Add("CONVENIO MULTILATERAL QUE INICIAN ACTIVIDAD EN ESTA JURISDICCION CUANDO REALICEN OPERACIONES CON CONSUMIDORES FINALES (ESTADO)", 203.9, 0, 4.29)
                .Add("REGIMENES ESPECIALES ART 6 A 13 DE CONVENIO MULTILATERAL  SERA LA  MISMA QUE ART 5 - 1* PARR. SALVO CONSTRUCCION ", 203.9, 0, 1.96)
                .Add("REGIMENES ESPECIALES DE CONSTRUCCION Y SIMILARES EJECUTADAS EN ESTA JURISD POR EMPRESAS CON SEDE EN OTRAS PCIAS SU SU ADM U OFICINA EN MNES", 203.9, 0, 4.29)
            End With
        End With
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

    Private Sub Cargadevariablesimpuesto(ByVal boton As Object, ByVal tabla As DataTable, ByVal titulo As String, ByVal aceptarstring As String, ByVal cancelarstring As String,
                                         ByRef impuesto As Retencion)
        '  Cargadevaloresimpuesto_estructura(impuesto)
        'Inscripcionafip
        If CARGAREALIZADA Then
            DialogDialogo_Datagridview.Carga_General(tabla, titulo, aceptarstring, cancelarstring, 10)
            DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                impuesto.Nombre_retencion_detalle = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
                Cargadevaloresimpuesto_estructura(impuesto)
            Else
                impuesto.Nombre_retencion_detalle = ""
            End If
        End If
    End Sub

    Private Sub Cargadevaloresimpuesto_estructura(ByRef impuesto As Retencion)
        If Not IsNothing(DialogDialogo_Datagridview.FilaSeleccionada) Then
            impuesto.Nombre_retencion_detalle = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
            impuesto.Retencion_minima = 0
            impuesto.Minimo_no_imponible = 0
            impuesto.Alicuota = 0
            If IsNothing(impuesto.CUIT) Then
                impuesto.CUIT = Factura_ACTUAL.CUIT
            End If
            For x = 0 To DialogDialogo_Datagridview.Datosdialogo_datagridview.Columns.Count - 1
                If Not IsDBNull(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(x).Value) Then
                    Select Case DialogDialogo_Datagridview.Datosdialogo_datagridview.Columns(x).Name.ToUpper
                        Case Is = "RET_MIN"
                            impuesto.Retencion_minima = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(x).Value
                        Case Is = "MINIMO_NO_IMPONIBLE"
                            impuesto.Minimo_no_imponible = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(x).Value
                        Case Is = "ALICUOTA"
                            impuesto.Alicuota = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(x).Value
                        Case Is = "COD.REGIMEN"
                            impuesto.cod_regimen = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(x).Value
                        Case Is = "COD.IMPUESTO"
                            impuesto.Cod_impuesto = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(x).Value
                    End Select
                End If
            Next
        Else
        End If
    End Sub

    Private Sub situacionyempleadorafip()
        Factura_ACTUAL.Situacionfrente_afip = Responsabletipo_boton.Text
        If Not IsNothing(Empleador_combobox.SelectedItem) Then
            If Empleador_combobox.SelectedItem.ToString.ToUpper = "SI" Then
                Factura_ACTUAL.Empleador = True
            Else
                Factura_ACTUAL.Empleador = False
            End If
            'visibilidad de elementos relacionados al SUSS
            For x = 0 To SUSS_GROUPBOX.Controls.Count - 1
                Select Case SUSS_GROUPBOX.Controls(x).Name
                    Case Is = Empleador_combobox.Name
                        SUSS_GROUPBOX.Controls(x).Visible = True
                    Case Is = Label26.Name
                        SUSS_GROUPBOX.Controls(x).Visible = True
                    Case Else
                        SUSS_GROUPBOX.Controls(x).Visible = Factura_ACTUAL.Empleador
                End Select
            Next
        End If
        CALCULOIVA()
    End Sub

    'Private Sub Cambiarvisibilidadelementos(ByVal control() As Object, ByRef grupo As Object, ByVal visible As Boolean)
    '    For x = 0 To grupo.Controls.Count - 1
    '        If grupo.Controls(x).Name = control.name Then
    '            grupo.Controls(x).visible = Not (visible)
    '        Else
    '            grupo.Controls(x).visible = (visible)
    '        End If
    '    Next
    'End Sub
    Private Sub TODOACERO()
        Ordendeentrega_integerupdown.Value = Expediente_Actual.ordenpago
        Ordendeentregayear_integerupdown.Value = Expediente_Actual.ordenpagoyear
        If CARGAREALIZADA Then
            Ganancias_impuesto.clearretencion()
            SUSS_impuesto.clearretencion()
            IVA_impuesto.clearretencion()
            DGR_impuesto.clearretencion()
        End If
    End Sub

    Private Sub Responsabletipo_boton_Click(sender As Object, e As EventArgs) Handles Responsabletipo_boton.Click
        'Inscripcionafip
        Cargadevariableopciones(sender, Inscripcionafip, "Seleccione situación frente a la AFIP", "Seleccionar", "Cancelar")
        If Not IsNothing(DialogDialogo_Datagridview.FilaSeleccionada) Then
            Responsabletipo_boton.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
        Else
        End If
        situacionyempleadorafip()
    End Sub

    Private Sub Responsabletipo_boton_TextChanged(sender As Object, e As EventArgs) Handles Responsabletipo_boton.TextChanged
        Factura_ACTUAL.Situacionfrente_afip = Responsabletipo_boton.Text
    End Sub

    Private Sub Empleador_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Empleador_combobox.SelectedIndexChanged
        situacionyempleadorafip()
    End Sub

    Private Sub Cargadeimpuesto_engroupbox(ByRef impuesto As Retencion, ByRef tipo As GroupBox)
        ', ByRef alicuota As Object, ByRef mni As Object
        'If CARGAREALIZADA Then
        For Each item As Control In tipo.Controls
            If item.Name.Contains("_tipo_boton") Then
                item.Text = impuesto.Nombre_retencion_detalle
            ElseIf item.Name.Contains("_PORCENTAJE_LABEL") Then
                item.Text = impuesto.Alicuota.ToString & "%"
            ElseIf item.Name.Contains("MNI_label_") Then
                item.Text = Format(impuesto.Minimo_no_imponible, ("C"))
            End If
        Next
        CALCULOIVA()
        'End If
    End Sub

    Private Sub GANANCIAStipo_boton_Click(sender As Object, e As EventArgs) Handles GANANCIAS_tipo_boton.Click
        'Tipo_retenciones
        Ganancias_impuesto.clearretencion()
        Cargadevaloresimpuesto_estructura(Ganancias_impuesto)
        Ganancias_impuesto.Nombre_retencion = "GANANCIAS"
        Ganancias_impuesto.Nombre_retencion_detalle = sender.text
        Select Case Responsabletipo_boton.Text.ToUpper
            Case Is = "MONOTRIBUTISTA"
                Cargadevariablesimpuesto(sender, Ganancias_retenciones_Monotributista, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", Ganancias_impuesto)
            Case Is = "INSCRIPTO"
                Cargadevariablesimpuesto(sender, Ganancias_retenciones_ResponsableInscripto, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", Ganancias_impuesto)
            Case Is = "NO INSCRIPTO"
                Cargadevariablesimpuesto(sender, Ganancias_retenciones_ResponsableNOInscripto, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", Ganancias_impuesto)
        End Select
        Cargadeimpuesto_engroupbox(Ganancias_impuesto, GANANCIAS_GROUPBOX)
    End Sub

    Private Sub SUSS_TIPO_Click(sender As Object, e As EventArgs) Handles SUSS_tipo_boton.Click
        'SUSS PORCENTAJES IVA
        SUSS_impuesto.clearretencion()
        Cargadevaloresimpuesto_estructura(SUSS_impuesto)
        SUSS_impuesto.Nombre_retencion = "SUSS"
        SUSS_impuesto.Nombre_retencion_detalle = sender.text
        Select Case Responsabletipo_boton.Text.ToUpper
            Case Is = "MONOTRIBUTISTA"
                Cargadevariablesimpuesto(sender, SUSS_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", SUSS_impuesto)
            Case Is = "INSCRIPTO"
                Cargadevariablesimpuesto(sender, SUSS_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", SUSS_impuesto)
            Case Is = "NO INSCRIPTO"
                Cargadevariablesimpuesto(sender, SUSS_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", SUSS_impuesto)
        End Select
        Cargadeimpuesto_engroupbox(SUSS_impuesto, SUSS_GROUPBOX)
        'DialogDialogo_Datagridview.Carga_General(SUSS_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", 9)
        'DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
        '    sender.text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
        '    SUSS_PORCENTAJE_LABEL.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value.ToString.ToUpper
        'Else
        '    '   Labelcuentaespecialasignada.Text = ""
        'End If
    End Sub

    Private Sub IVA_boton_Click(sender As Object, e As EventArgs) Handles IVA_boton.Click
        'Porcentajes_IVA
        Cargadevariableopciones(sender, Porcentajes_IVA, "Porcentaje de IVA aplicado", "Seleccionar", "Cancelar")
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Private Sub Monto_factura_textbox_ValueChanged(sender As Object, e As EventArgs) Handles Monto_factura_textbox.ValueChanged, IVA_boton.TextChanged
        If CARGAREALIZADA Then
            If Not (Monto_factura_textbox.Value = 0) Then
                CALCULOIVA()
                Factura_ACTUAL.Porcentaje_iva = IVA_boton.Text
                Factura_ACTUAL.Neto_IVA = NetoAFTERIVA_textbox.Value
                movimiento_actual.Total_factura = Monto_factura_textbox.Value
                Factura_ACTUAL.Total_factura = Monto_factura_textbox.Value
                'CalculoAfterIVA()
                'movimiento_actual.Monto_movimiento = Chequetotal_numeric.Value - Verificar_retenciones()
                'Cargadeimpuesto_engroupbox(Ganancias_impuesto, GANANCIAS_GROUPBOX)
                'Cargadeimpuesto_engroupbox(SUSS_impuesto, SUSS_GROUPBOX)
                'Cargadeimpuesto_engroupbox(DGR_impuesto, DGR_GROUPBOX)
                'Cargadeimpuesto_engroupbox(IVA_impuesto, IVA_GROUPBOX)
                'CALCULOIVA()
                CalculoAfterIVA()
            Else
                TODOACERO()
                GANANCIAS_tipo_boton.Text = ""
                SUSS_tipo_boton.Text = ""
                DGR_tipo_boton.Text = ""
                Sujeto_iva_Combobox.SelectedIndex = 0
                Empleador_combobox.SelectedIndex = 0
                Cargadeimpuesto_engroupbox(Ganancias_impuesto, GANANCIAS_GROUPBOX)
                Cargadeimpuesto_engroupbox(SUSS_impuesto, SUSS_GROUPBOX)
                Cargadeimpuesto_engroupbox(DGR_impuesto, DGR_GROUPBOX)
                Cargadeimpuesto_engroupbox(IVA_impuesto, IVA_GROUPBOX)
                CALCULOIVA()
                CalculoAfterIVA()
            End If
        End If
        NETOTOTAL()
    End Sub

    Private Sub NetoAFTERIVA_textbox_ValueChanged(sender As Object, e As EventArgs) Handles NetoAFTERIVA_textbox.ValueChanged
        GRUPOSINVISIBLES()
    End Sub

    Private Sub GRUPOSINVISIBLES()
        GANANCIAS_GROUPBOX.Visible = True
        IVA_GROUPBOX.Visible = True
        SUSS_GROUPBOX.Visible = True
        DGR_GROUPBOX.Visible = True
        'Select Case NetoAFTERIVA_textbox.Value
        '    Case Is > 1500000
        '        GANANCIAS_GROUPBOX.Visible = True
        '        IVA_GROUPBOX.Visible = True
        '        SUSS_GROUPBOX.Visible = True
        '        DGR_GROUPBOX.Visible = True
        '    Case Is > 1500 'BORRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        '        GANANCIAS_GROUPBOX.Visible = True
        '        SUSS_GROUPBOX.Visible = True
        '        DGR_GROUPBOX.Visible = True
        '    Case Is > 400
        '        GANANCIAS_GROUPBOX.Visible = True
        '        '     IVA_GROUPBOX.Visible = True
        '        SUSS_GROUPBOX.Visible = True
        '        '    DGR_GROUPBOX.Visible = True
        'End Select
    End Sub

    Private Sub CALCULOIVA()
        If CARGAREALIZADA Then
            Select Case Monto_factura_textbox.Value >= 0
                Case True
                    Factura_ACTUAL.Total_factura = Monto_factura_textbox.Value
                    Factura_ACTUAL.Neto_IVA = Monto_factura_textbox.Value / (1 + (CType(IVA_boton.Text, Decimal) / 100))
                    NetoAFTERIVA_textbox.Value = Factura_ACTUAL.Neto_IVA
                    ' movimiento_actual.Monto_movimiento = Chequetotal_numeric.Value
                    CalculoAfterIVA()
                    NETOTOTAL()
                Case False
            End Select
        End If
    End Sub

    Private Sub CalculoAfterIVA()
        If CARGAREALIZADA Then
            'GANANCIAS
            Ganancias_Flicker_Numericupdown.Value = GANANCIAS()
            'IVA
            IVAS_Flicker_Numericupdown.Value = IVA_NETO() 'NETO SOBRE LA FACTURA
            IVA_Flicker_Numericupdown.Value = IVA() 'RETENCION IVA
            'SUSS
            SUSS_Flicker_Numericupdown.Value = SUSS()
            'DGR
            DGR_Flicker_Numericupdown.Value = DGR()
            'DESCRIPCION DEL MOVIMIENTO
        Else
        End If
        'Chequetotal_numeric.Value = movimiento_actual.Monto_movimiento
    End Sub

    Private Sub NETOTOTAL()
        Chequetotal_numeric.Value = (Math.Round(Monto_factura_textbox.Value, 2) - (Math.Round(Ganancias_Flicker_Numericupdown.Value, 2) + Math.Round(IVA_Flicker_Numericupdown.Value, 2) + Math.Round(SUSS_Flicker_Numericupdown.Value, 2) + Math.Round(DGR_Flicker_Numericupdown.Value, 2)))
        valoresennumeros()
    End Sub

    Private Sub asignaciondevaloresenimpuestos()
        For x = 0 To IMPUESTOS_LISTA.Count - 1
            IMPUESTOS_LISTA.Item(x).CUIT = Factura_ACTUAL.CUIT
            IMPUESTOS_LISTA.Item(x).totalmesencurso = Factura_ACTUAL.totalmesencurso
            IMPUESTOS_LISTA.Item(x).total12meses = Factura_ACTUAL.total12meses
            IMPUESTOS_LISTA.Item(x).totalaniocalendario = Factura_ACTUAL.totalaniocalendario
        Next
    End Sub

    Private Function GANANCIAS() As Decimal
        Dim total As Decimal = 0
        Ganancias_impuesto.Cuit_recaudador = "33-69345023-9"
        If Not IsNothing(Factura_ACTUAL.Situacionfrente_afip) Then
            Select Case Factura_ACTUAL.Situacionfrente_afip.ToString.ToUpper
                Case Is = "MONOTRIBUTISTA"
                    If (Factura_ACTUAL.total12meses + Factura_ACTUAL.Neto_IVA > Ganancias_impuesto.Minimo_no_imponible) Then
                        IVA_boton.Text = "21"
                        total = (Factura_ACTUAL.Neto_IVA - Ganancias_impuesto.Minimo_no_imponible) * (Ganancias_impuesto.Alicuota / 100)
                    Else
                        total = 0
                    End If
                Case Else
                    If Factura_ACTUAL.totalmesencurso = 0 Then
                        total = (Factura_ACTUAL.Neto_IVA - Ganancias_impuesto.Minimo_no_imponible) * (Ganancias_impuesto.Alicuota / 100)
                    Else
                        If (Factura_ACTUAL.totalmesencurso + Factura_ACTUAL.Neto_IVA) >= Ganancias_impuesto.Minimo_no_imponible Then
                            If (Ganancias_impuesto.Minimo_no_imponible - Factura_ACTUAL.totalmesencurso) > 0 Then
                                total = (Factura_ACTUAL.Neto_IVA - (Ganancias_impuesto.Minimo_no_imponible - Factura_ACTUAL.totalmesencurso)) * (Ganancias_impuesto.Alicuota / 100)
                            Else
                                total = (Factura_ACTUAL.Neto_IVA) * (Ganancias_impuesto.Alicuota / 100)
                            End If
                        Else
                            total = (Factura_ACTUAL.Neto_IVA - (Ganancias_impuesto.Minimo_no_imponible - Factura_ACTUAL.totalmesencurso)) * (Ganancias_impuesto.Alicuota / 100)
                        End If
                    End If
                    If total < Ganancias_impuesto.Retencion_minima Then
                        total = 0
                    End If
            End Select
        Else
            total = 0
        End If
        Return total
    End Function

    Private Function SUSS() As Decimal
        Dim total As Decimal = 0
        SUSS_impuesto.Cuit_recaudador = "33-69345023-9"
        SUSS_impuesto.Nombre_retencion = "SUSS"
        If Not IsNothing(Factura_ACTUAL.Situacionfrente_afip) Then
            If (Not (Factura_ACTUAL.Situacionfrente_afip.ToUpper = "MONOTRIBUTISTA")) And (Factura_ACTUAL.Empleador) And (Not IsNothing(SUSS_impuesto.Nombre_retencion_detalle)) Then
                Select Case SUSS_impuesto.Nombre_retencion_detalle.ToUpper
                    Case Is = "LIMPIEZA"
                        total = Factura_ACTUAL.Neto_IVA * (SUSS_impuesto.Alicuota / 100)
                        SUSS_impuesto.Descripciondelcalculo = ("Cálculo de retención (" & Factura_ACTUAL.Neto_IVA & " x " & SUSS_impuesto.Alicuota & "/100) = $" & total)
                        If Not (total >= SUSS_impuesto.Retencion_minima) Then ' SI EL TOTAL NO SUPERA LA RETENCIÓN MINIMA
                            SUSS_impuesto.Descripciondelcalculo = ("El cálculo de retención (" & Factura_ACTUAL.Neto_IVA & " x " & SUSS_impuesto.Alicuota & "/100) = $" & total & " no supera la retención minima de $" & SUSS_impuesto.Retencion_minima)
                            total = 0
                        End If
                    Case Is = "SEGURIDAD E INVESTIG"
                        If Factura_ACTUAL.totalmesencurso + Factura_ACTUAL.Total_factura > 80000 Then
                            total = Factura_ACTUAL.Neto_IVA * (SUSS_impuesto.Alicuota / 100)
                            If Not (total >= SUSS_impuesto.Retencion_minima) Then ' SI EL TOTAL NO SUPERA LA RETENCIÓN MINIMA de $400"
                                total = 0
                            End If
                        Else
                            total = 0
                        End If
                    Case Is = "VTA COSA MUEBLE, LOC OBRA Y/O SERV."
                        Select Case Factura_ACTUAL.Situacionfrente_afip.ToUpper
                            Case Is = "INSCRIPTO"
                                'If Factura_ACTUAL.totalaniocalendario + Factura_ACTUAL.Total_factura > 1500000 Then
                                total = Factura_ACTUAL.Neto_IVA * (SUSS_impuesto.Alicuota / 100)
                                If Not (total >= SUSS_impuesto.Retencion_minima) Then ' SI EL TOTAL NO SUPERA LA RETENCIÓN MINIMA
                                    total = 0
                                End If
                                ' Else
                'total = 0
            'End If
                            Case Is = "NO INSCRIPTO"
                                total = 0
                            Case Else
                        End Select
                    Case Is = "OBRAS DE INGENIERÍA"
                        Select Case Factura_ACTUAL.Situacionfrente_afip.ToUpper
                            Case Is = "INSCRIPTO"
                                If Factura_ACTUAL.totalaniocalendario + Factura_ACTUAL.Total_factura > 1500000 Then
                                    total = Factura_ACTUAL.Neto_IVA * (SUSS_impuesto.Alicuota / 100)
                                Else
                                    total = 0
                                End If
                            Case Is = "NO INSCRIPTO"
                                total = 0
                        End Select
                    Case Is = "OBRAS DE ARQUITECTURA"
                        Select Case Factura_ACTUAL.Situacionfrente_afip.ToUpper
                            Case Is = "INSCRIPTO"
                                If Factura_ACTUAL.totalaniocalendario > 1500000 Then
                                    total = Factura_ACTUAL.Neto_IVA * (SUSS_impuesto.Alicuota / 100)
                                Else
                                    total = 0
                                End If
                            Case Is = "NO INSCRIPTO"
                                total = 0
                        End Select
                End Select
            Else
                total = 0
            End If
        Else
        End If
        '  Label9.Text = SUSS_impuesto.Descripciondelcalculo
        Return total
    End Function

    Private Function IVA() As Decimal
        Dim VALORTEMPORAL As Decimal = 0
        If Not IsNothing(Sujeto_iva_Combobox.SelectedItem) Then
            Select Case Sujeto_iva_Combobox.SelectedItem.ToString.ToUpper
                Case Is = ""
                Case Is = "SI"
                    IVA_impuesto.Alicuota = CType(8.68, Decimal)
                    IVA_impuesto.Nombre_retencion_detalle = "Ret. 8,68%"
                    IVA_impuesto.Nombre_retencion = "IVA"
                    VALORTEMPORAL = (Factura_ACTUAL.Total_factura * (IVA_impuesto.Alicuota / 100))
                Case Is = "NO"
            End Select
        End If
        Return VALORTEMPORAL
    End Function

    Private Function IVAtemporal_borrar(ByVal DESCUENTO As Single) As Decimal
        Dim VALORTEMPORAL As Decimal = 0
        '  If Not IsNothing(Sujeto_iva_Combobox.SelectedItem) Then
        IVA_impuesto.Alicuota = CType(DESCUENTO, Decimal)
        IVA_impuesto.Nombre_retencion_detalle = "Ret. " & DESCUENTO & "%"
        IVA_impuesto.Nombre_retencion = "IVA"
        If Factura_ACTUAL.Total_factura > 23999 Then
            VALORTEMPORAL = (Factura_ACTUAL.Total_factura - (Factura_ACTUAL.Total_factura / (1 + (Factura_ACTUAL.Porcentaje_iva / 100)))) * (DESCUENTO / 100)
        Else
            VALORTEMPORAL = 0
            IVA_PORCENTAJE_LABEL.Text = "No corresponde retención (RG AFIP Nº 2854/2010 art 9 inc.b.)"
        End If
        '  End If
        Return VALORTEMPORAL
    End Function

    Private Function IVA_NETO() As Decimal
        Return Factura_ACTUAL.Total_factura - Factura_ACTUAL.Neto_IVA
    End Function

    Private Function DGR() As Decimal
        Dim total As Decimal = 0
        DGR_impuesto.Cuit_recaudador = "30-67238712-0"
        DGR_impuesto.Nombre_retencion = "DGR"
        DGR_impuesto.Nombre_retencion_detalle = DGR_tipo_boton.Text
        total = Factura_ACTUAL.Neto_IVA * (DGR_impuesto.Alicuota / 100)
        If Not (total >= DGR_impuesto.Retencion_minima) Then ' SI EL TOTAL NO SUPERA LA RETENCIÓN MINIMA
            total = 0
        End If
        Return total
    End Function

    Private Sub Cuitdelbeneficiario_textbox_TextChanged(sender As Object, e As EventArgs) Handles Cuitdelbeneficiario_textbox.TextChanged, Cuitdelbeneficiario_textbox.KeyDown
        If CARGAREALIZADA Then
            VerificarCUIT(sender, sender.text, Beneficiario_label)
            movimiento_actual.CUIT = sender.text
            AcumuladosCUIT(movimiento_actual.Clave_expediente_detalle)
        Else
            sender.TEXT = movimiento_actual.CUIT
            AcumuladosCUIT(movimiento_actual.Clave_expediente_detalle)
        End If
        proveedor_actual.CUIT = sender.text
        proveedor_actual.Cargardatos()
        LabelIVAAFIP.Text = proveedor_actual.Respuesta_AFIP
    End Sub

    'Private Sub Cuitdelbeneficiario_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Cuitdelbeneficiario_textbox.KeyDown
    '    VerificarCUIT(sender, sender.text, Beneficiario_label)
    '    AcumuladosCUIT()
    'End Sub
    Private Sub Cuitdialogomostrar()
        'Dialogo_CUIT.Busqueda.Text =  Cuitdelbeneficiario_textbox.Text
        '  Dialogo_CUIT.Cargadetextbox( Cuitdelbeneficiario_textbox)
        Dialogo_CUIT.Cargadetextbox(Cuitdelbeneficiario_textbox)
        Dialogo_CUIT.Cargadecuits(0)
        'Dialogo_CUIT.ShowDialog()
        'Dialogo_CUIT.ShowDialog()
    End Sub

    Private Sub Cuit_boton_Click(sender As Object, e As EventArgs) Handles Cuit_boton.Click
        '  Cuitdialogomostrar()
        Dialogo_CUIT.Cargadetextbox(Cuitdelbeneficiario_textbox)
        Dialogo_CUIT.Cargadecuits(movimiento_actual.claveexpediente)
        AcumuladosCUIT(movimiento_actual.Clave_expediente_detalle)
    End Sub

    Private Sub Constancia_Boton_Click(sender As Object, e As EventArgs) Handles Constancia_Boton.Click
        AbrirsitioWEB("https://www.cuitonline.com/constancia/inscripcion/" & Cuitdelbeneficiario_textbox.Text.Replace("-", ""))
    End Sub

    Private Sub Monto_factura_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Monto_factura_textbox.KeyDown, Cuitdelbeneficiario_textbox.KeyDown, NetoAFTERIVA_textbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Inicio.SIGUIENTECONTROL(Me, sender, e)
        Else
        End If
    End Sub

    Private Sub valoresennumeros()
        If Chequetotal_numeric.Value > 0 Then
            Monto_numeros_label.Text = Inicio.Numerosatextopesosconcorreccion(Chequetotal_numeric.Value.ToString)
        Else
            Monto_numeros_label.Text = ""
        End If
    End Sub

    Private Function Verificar_Coherenciacarga() As String
        Dim Message As String = ""
        If Monto_factura_textbox.Value < 0 Then
            Message += "-El MONTO de la factura es incorrecto" & vbCrLf
        End If
        If Cuitdelbeneficiario_textbox.Text = "  -        -" Then
            Message += "-El CUIT no tiene un formato correcto" & vbCrLf
        Else
        End If
        If Ordendeentrega_integerupdown.Value < 1 Then
            Message += "-El número de Orden de pago no puede ser 0 (por favor verifique)" & vbCrLf
        End If
        If Ordendeentregayear_integerupdown.Value < 2016 Then
            Message += "-El año ingresado es incorrecto (por favor verifique)" & vbCrLf
        End If
        If Ordendeentregayear_integerupdown.Value < 2016 Then
            Message += "-El año ingresado es incorrecto (por favor verifique)" & vbCrLf
        End If
        Return Message
    End Function

    Private Function ADVERTENCIA_COHERENCIA() As String
        Dim Message As String = ""
        If (movimiento_actual.Monto_movimiento + (Ganancias_impuesto.Monto_retenido) + (SUSS_impuesto.Monto_retenido) + (IVA_impuesto.Monto_retenido) + (DGR_impuesto.Monto_retenido)) = Factura_ACTUAL.Total_factura Then
            Message = ""
        Else
            Message = " Actualmente se registra una incoherencia en la suma de los montos: " & vbCrLf &
                "NETO A PAGAR: " & movimiento_actual.Monto_movimiento.ToString("C") & vbCrLf &
                  "GANANCIAS: " & Ganancias_impuesto.Monto_retenido.ToString("C") & vbCrLf &
                  "SUSS: " & SUSS_impuesto.Monto_retenido.ToString("C") & vbCrLf &
                  "IVA: " & IVA_impuesto.Monto_retenido.ToString("C") & vbCrLf &
                  "DGR: " & DGR_impuesto.Monto_retenido.ToString("C") & vbCrLf &
                  "diferencia: " & ((movimiento_actual.Monto_movimiento + (Ganancias_impuesto.Monto_retenido) + (SUSS_impuesto.Monto_retenido) + (IVA_impuesto.Monto_retenido) + (DGR_impuesto.Monto_retenido)) - (movimiento_actual.Total_factura)).ToString("C") & vbCrLf &
                "FACTURA MONTO TOTAL:" & movimiento_actual.Total_factura.ToString("C")
        End If
        Return Message
    End Function

    Private Function Verificar_retenciones() As Decimal
        '        el error en un expediente de segen por ejemplo con un pago de 1728669, 85
        'neto    1464329, 8
        'ret1 150048, 54
        'ret2 28573, 6
        'ret3 85719, 17
        'total Factura 1728669, 85
        Dim sumatotal As Decimal = 0
        Dim sumaderetenciones As Decimal = 0
        Dim diferencia As Decimal = 0
        sumatotal += Math.Round(movimiento_actual.Monto_movimiento, 2)
        For x As Integer = 0 To movimiento_actual.retenciones.Count - 1
            sumaderetenciones += Math.Round(movimiento_actual.retenciones(x).Monto_retenido, 2)
        Next
        diferencia = Math.Round((sumatotal + sumaderetenciones) - movimiento_actual.Total_factura, 2)
        Label_expedienteasociados.Text = "redondeo $" & diferencia
        Return diferencia
    End Function

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Carga_movimiento()
    End Sub

    Private Sub Carga_movimiento()
        If Monto_factura_textbox.Value = 0 Then
            Select Case MsgBox("Al colocar 0 (cero) en el Monto de la Factura equivale a Anular el cheque/transferencia " & vbCrLf & "Esta seguro?", MsgBoxStyle.YesNo, "----ADVERTENCIA----")
                Case MsgBoxResult.Yes
                Case MsgBoxResult.No
                    Exit Sub
            End Select
        Else
            Ganancias_impuesto.Monto_retenido = Math.Round(Ganancias_Flicker_Numericupdown.Value, 2)
            SUSS_impuesto.Monto_retenido = Math.Round(SUSS_Flicker_Numericupdown.Value, 2)
            IVA_impuesto.Monto_retenido = Math.Round(IVA_Flicker_Numericupdown.Value, 2)
            DGR_impuesto.Monto_retenido = Math.Round(DGR_Flicker_Numericupdown.Value, 2)
        End If
        If Verificar_Coherenciacarga.Length = 0 Then
            'verifica que la inserción se realizó correctamente
            If Not ADVERTENCIA_COHERENCIA().Length = 0 Then
                Select Case MsgBox(ADVERTENCIA_COHERENCIA(), MsgBoxStyle.YesNo, "Esta seguro?")
                    Case MsgBoxResult.Yes
                    Case MsgBoxResult.No
                        Exit Sub
                End Select
            End If
            movimiento_actual.Monto_movimiento = movimiento_actual.Monto_movimiento
            movimiento_actual.Tipo_Movimiento = "ORDEN DE PAGO"
            movimiento_actual.Cod_orden = Tipo_orden_combobox.SelectedIndex + 1
            If insertarmovimiento(Factura_ACTUAL, movimiento_actual) Then
                MessageBox.Show("Carga Exitosa")
                Me.Close()
                Tesoreria_Movimientos.refreshNowGeneralIntermedio()
            Else
            End If
        Else
            MessageBox.Show(Verificar_Coherenciacarga)
        End If
    End Sub

    Private Function insertarmovimiento(ByVal Factura_modif As Factura, ByVal Movimiento_modif As Movimiento) As Boolean
        Dim Claveexpediente_temp As Int64 = Nothing
        Dim temporalus As New DataTable
        'Try
        If Movimiento_modif.Clave_expediente_detalle > 0 Then
        Else
            Movimiento_modif.Clave_expediente_detalle = Movimiento_modif.agregaromodificarmovimiento
        End If
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Movimiento_modif.Clave_expediente_detalle)
        Movimiento_modif.Total_factura = Monto_factura_textbox.Value
        Movimiento_modif.cod_inp = 1
        Movimiento_modif.Desglose_clave()
        'Movimiento_modif.insertar_movimiento()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", (Movimiento_modif.organismo.ToString & "-" & Movimiento_modif.numero.ToString & "-" & "/" & Movimiento_modif.year.ToString).ToString)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", Movimiento_modif.Descripcion_movimiento)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Movimiento_modif.Monto_movimiento)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total_factura", Movimiento_modif.Total_factura)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cod_orden", Movimiento_modif.Cod_orden)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CFdo", Movimiento_modif.Clase_fondo)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CodInp", Movimiento_modif.cod_inp)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Mov_tipo", Movimiento_modif.Tipo_Movimiento)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Movimiento_modif.CUIT)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", Movimiento_modif.Transferencia)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fechadelmovimiento", Movimiento_modif.Fecha_movimiento).DbType = DbType.Date
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@tipoorden", "Pago Neto al Proveedor")
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_N", Movimiento_modif.Orden)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_year", Movimiento_modif.Orden_year)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `Expediente_detalle` " &
    "(Clave_expediente_detalle,Expediente_N,Detalle,Monto,Total_factura,Cod_orden,CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Fechadelmovimiento,tipoorden,Orden_N,Orden_year,Usuario) " &
    "VALUES (@Clave_expediente_detalle,@Expediente_N,@Detalle,@Monto,@Total_factura,@Cod_orden,@CFdo,@CodInp,@Mov_tipo,@CUIT,@Nrotransferencia,@Fechadelmovimiento,@tipoorden,@Orden_N,@Orden_year,@Usuario) " &
    "ON DUPLICATE KEY UPDATE " &
    "Expediente_N=@Expediente_N,Detalle=@Detalle,Monto=@Monto,Total_factura=@Total_factura,Cod_orden=@Cod_orden,CFdo=@CFdo,CodInp=@CodInp,Mov_tipo=@Mov_tipo,CUIT=@CUIT,Nrotransferencia=@Nrotransferencia,Fechadelmovimiento=@Fechadelmovimiento,tipoorden=@tipoorden,Orden_N=@Orden_N,Orden_year=@Orden_year,Usuario=@Usuario"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Movimiento_modif.Clave_expediente_detalle)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `Expediente_detalle` " &
     " WHERE Clave_expediente_Detalle_principal=@Clave_expediente_detalle"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", Movimiento_modif.Clave_expediente_detalle)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM `Retenciones` " &
     " WHERE Clave_expediente_Detalle=@Clave_expediente_detalle"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'INSERCION DE RETENCIONES
        guardar_retenciones(Ganancias_impuesto, Movimiento_modif)
        guardar_retenciones(SUSS_impuesto, Movimiento_modif)
        guardar_retenciones(IVA_impuesto, Movimiento_modif)
        guardar_retenciones(DGR_impuesto, Movimiento_modif)
        'IMPUESTOS_LISTA.Clear()
        'IMPUESTOS_LISTA.Add(Ganancias_impuesto)
        'IMPUESTOS_LISTA.Add(SUSS_impuesto)
        'IMPUESTOS_LISTA.Add(DGR_impuesto)
        'IMPUESTOS_LISTA.Add(IVA_impuesto)
        For x = 0 To IMPUESTOS_LISTA.Count - 1
            If IMPUESTOS_LISTA(x).Nrotransferencia > 0 And (IMPUESTOS_LISTA(x).Monto_retenido > 0) Then
                IMPUESTOS_LISTA(x).clave_expediente_detalle = Movimiento_modif.NUEVOMOVIMIENTO(Movimiento_modif.clave_detalle_a__clave_expediente((CType(IMPUESTOS_LISTA(x).clave_expediente_detalle, Long))))
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_detalle", IMPUESTOS_LISTA(x).clave_expediente_detalle)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente_Detalle_principal", Movimiento_modif.Clave_expediente_detalle)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", (Movimiento_modif.organismo.ToString & "-" & Movimiento_modif.numero.ToString & "-" & "/" & Movimiento_modif.year.ToString).ToString)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", "PAGO " & Movimiento_modif.Fecha_movimiento.ToShortDateString & "(" & IMPUESTOS_LISTA(x).Nombre_retencion & ")")
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", IMPUESTOS_LISTA(x).Monto_retenido)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Total_factura", movimiento_actual.Total_factura)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cod_orden", Movimiento_modif.Cod_orden)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CFdo", Movimiento_modif.Clase_fondo)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CodInp", Movimiento_modif.cod_inp)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Mov_tipo", IMPUESTOS_LISTA(x).Nombre_retencion)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Movimiento_modif.CUIT)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", IMPUESTOS_LISTA(x).Nrotransferencia)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fechadelmovimiento", Movimiento_modif.Fecha_movimiento).DbType = DbType.Date
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@tipoorden", "RETENCIÓN " & IMPUESTOS_LISTA(x).Nombre_retencion)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_N", Movimiento_modif.Orden)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Orden_year", Movimiento_modif.Orden_year)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `Expediente_detalle` " &
            "(Clave_expediente_detalle,Clave_expediente_Detalle_principal,Expediente_N,Detalle,Monto,Cod_orden,CFdo,CodInp,Mov_tipo,CUIT,Nrotransferencia,Fechadelmovimiento,tipoorden,Orden_N,Orden_year,Usuario) " &
            "VALUES (@Clave_expediente_detalle,@Clave_expediente_Detalle_principal,@Expediente_N,@Detalle,@Monto,@Cod_orden,@CFdo,@CodInp,@Mov_tipo,@CUIT,@Nrotransferencia,@Fechadelmovimiento,@tipoorden,@Orden_N,@Orden_year,@Usuario) " &
            "ON DUPLICATE KEY UPDATE " &
            "Clave_expediente_Detalle_principal=@Clave_expediente_Detalle_principal,Expediente_N=@Expediente_N,Detalle=@Detalle,Monto=@Monto,Cod_orden=@Cod_orden,CFdo=@CFdo,CodInp=@CodInp,Mov_tipo=@Mov_tipo,CUIT=@CUIT,Nrotransferencia=@Nrotransferencia,Fechadelmovimiento=@Fechadelmovimiento,tipoorden=@tipoorden,Orden_N=@Orden_N,Orden_year=@Orden_year,Usuario=@Usuario"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Else
            End If
        Next
        Return True
        'Catch ex As Exception
        '    Return False
        '    MessageBox.Show("Carga Fallida " & ex.Message)
        'End Try
    End Function

    Private Sub guardar_retenciones(ByVal impuesto As Retencion, ByVal movimiento_modif As Movimiento)
        If Not IsNothing(impuesto.Monto_retenido) And impuesto.Monto_retenido > 0 Then
            impuesto.Porcentaje_iva = Factura_ACTUAL.Porcentaje_iva
            impuesto.Neto_IVA = Factura_ACTUAL.Neto_IVA
            impuesto.Total_factura = Factura_ACTUAL.Total_factura
            impuesto.CUIT = movimiento_modif.CUIT
            impuesto.Fecha = movimiento_modif.Fecha_movimiento
            impuesto.Situacionfrente_afip = Factura_ACTUAL.Situacionfrente_afip
            Select Case impuesto.Nombre_retencion.ToUpper
                Case Is = "GANANCIAS"
                    '20, 23, 24 y 27 para Personas Físicas
                    '30, 33 y 34 para Empresas.
                    If (movimiento_modif.CUIT.ToString.Substring(0, 2) = 20 Or movimiento_modif.CUIT.ToString.Substring(0, 2) = 23 Or movimiento_modif.CUIT.ToString.Substring(0, 2) = 24 Or movimiento_modif.CUIT.ToString.Substring(0, 2) = 27) Then
                        impuesto.Cod_impuesto = 11
                    ElseIf (movimiento_modif.CUIT.ToString.Substring(0, 2) = 30 Or movimiento_modif.CUIT.ToString.Substring(0, 2) = 33 Or movimiento_modif.CUIT.ToString.Substring(0, 2) = 34) Then
                        impuesto.Cod_impuesto = 10
                    Else
                        MessageBox.Show(impuesto.Cod_impuesto)
                    End If
                    impuesto.cod_regimen = 0
                Case Is = "SUSS"
                    impuesto.Cod_impuesto = 353
                Case Is = "IVA"
                    impuesto.Cod_impuesto = 30
                    impuesto.cod_regimen = 0
                Case Is = "DGR"
                    impuesto.Cod_impuesto = 0
                    impuesto.cod_regimen = 0
            End Select
            impuesto.insertarretencion(movimiento_modif.Clave_expediente_detalle)
        End If
    End Sub

    Private Sub Fecha_factura_ValueChanged(sender As Object, e As EventArgs) Handles Fecha_factura.ValueChanged
        AcumuladosCUIT(movimiento_actual.Clave_expediente_detalle)
    End Sub

    Private Sub AcumuladosCUIT(Optional clave_expediente_Detalle As Long = 0)
        If CARGAREALIZADA Then
            If IsNumeric(Cuitdelbeneficiario_textbox.Text.Substring(0, 2)) Then
                Factura_ACTUAL.CUIT = Cuitdelbeneficiario_textbox.Text
                Factura_ACTUAL.Fecha = Fecha_factura.Value
                Factura_ACTUAL.totalmesencurso = Factura_ACTUAL.mesencurso(movimiento_actual.Clave_expediente_detalle)
                Factura_ACTUAL.total12meses = Factura_ACTUAL.Calculo12meses(movimiento_actual.Clave_expediente_detalle)
                Factura_ACTUAL.totalaniocalendario = Factura_ACTUAL.calculocalendario(movimiento_actual.Clave_expediente_detalle)
                ' cargar datos en movimiento
                'movimiento_actual.CUIT = Factura_ACTUAL.CUIT
                movimiento_actual.Fecha_movimiento = Factura_ACTUAL.Fecha
                asignaciondevaloresenimpuestos()
            Else
                Factura_ACTUAL.totalmesencurso = 0
                Factura_ACTUAL.total12meses = 0
                Factura_ACTUAL.totalaniocalendario = 0
            End If
            SELECCION_CODIGO("", "")
        Else
            Factura_ACTUAL.CUIT = movimiento_actual.CUIT
        End If
        Facturadomes_label.Text = Factura_ACTUAL.totalmesencurso.ToString("C")
        Facturado12meses_label.Text = Factura_ACTUAL.total12meses.ToString("C")
        Facturadoanio_label.Text = Factura_ACTUAL.totalaniocalendario.ToString("C")
    End Sub

    Private Sub IVA_tipo_boton_Click(sender As Object, e As EventArgs)
        CALCULOIVA()
    End Sub

    Private Sub DGR_tipo_boton_Click(sender As Object, e As EventArgs) Handles DGR_tipo_boton.Click
        'SUSS PORCENTAJES IVA
        DGR_impuesto.clearretencion()
        Cargadevaloresimpuesto_estructura(DGR_impuesto)
        DGR_impuesto.Nombre_retencion = "DGR"
        DGR_impuesto.Nombre_retencion_detalle = sender.text
        Select Case Responsabletipo_boton.Text.ToUpper
            Case Is = "MONOTRIBUTISTA"
                Cargadevariablesimpuesto(sender, DGR_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", DGR_impuesto)
            Case Is = "INSCRIPTO"
                Cargadevariablesimpuesto(sender, DGR_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", DGR_impuesto)
            Case Is = "NO INSCRIPTO"
                Cargadevariablesimpuesto(sender, DGR_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", DGR_impuesto)
        End Select
        Cargadeimpuesto_engroupbox(DGR_impuesto, DGR_GROUPBOX)
    End Sub

    Private Sub Ganancias_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Ganancias_Flicker_Numericupdown.ValueChanged
        Ganancias_impuesto.Monto_retenido = Math.Round(Ganancias_Flicker_Numericupdown.Value, 2)
    End Sub

    Private Sub SUSS_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles SUSS_Flicker_Numericupdown.ValueChanged
        SUSS_impuesto.Monto_retenido = Math.Round(SUSS_Flicker_Numericupdown.Value, 2)
    End Sub

    Private Sub IVA_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles IVA_Flicker_Numericupdown.ValueChanged
        IVA_impuesto.Monto_retenido = Math.Round(sender.value, 2)
    End Sub

    Private Sub DGR_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles DGR_Flicker_Numericupdown.ValueChanged
        DGR_impuesto.Monto_retenido = Math.Round(DGR_Flicker_Numericupdown.Value, 2)
    End Sub

    Private Sub Detalle_textbox_TextChanged(sender As Object, e As EventArgs) Handles Detalle_textbox.TextChanged
        If CARGAREALIZADA Then
            movimiento_actual.Descripcion_movimiento = Detalle_textbox.Text
        End If
    End Sub

    Private Sub Ordendeentrega_integerupdown_ValueChanged(sender As Object, e As EventArgs) Handles Ordendeentrega_integerupdown.ValueChanged
        'If CARGAREALIZADA Then
        movimiento_actual.Orden = Ordendeentrega_integerupdown.Value
        movimiento_actual.Orden_year = Ordendeentregayear_integerupdown.Value
        'Else
        'End If
    End Sub

    Private Sub Ordendeentregayear_integerupdown_ValueChanged(sender As Object, e As EventArgs) Handles Ordendeentregayear_integerupdown.ValueChanged
        'If CARGAREALIZADA Then
        movimiento_actual.Orden = Ordendeentrega_integerupdown.Value
        movimiento_actual.Orden_year = Ordendeentregayear_integerupdown.Value
        'Else
        'End If
    End Sub

    Private Sub Tipo_orden_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tipo_orden_combobox.SelectedIndexChanged
        If CARGAREALIZADA Then
            SELECCION_CODIGO(Tipo_orden_combobox.SelectedItem.ToString.ToUpper, "COD_ORDEN")
        End If
    End Sub

    Private Sub SELECCION_CODIGO(ByVal TIPO As String, ByVal CLASE_CODIGO As String)
        Select Case CLASE_CODIGO
            Case Is = "COD_ORDEN"
                Select Case TIPO
                    Case Is = "ORDEN DE PAGO"
                        movimiento_actual.Cod_orden = 1
                    Case Is = "ORDEN DE CARGO"
                        movimiento_actual.Cod_orden = 2
                    Case Is = "COMPRA DIRECTA"
                        movimiento_actual.Cod_orden = 3
                End Select
                movimiento_actual.Tipo_Movimiento = TIPO
            Case Is = "CLASE_FONDO"
                Select Case TIPO
                    Case Is = "PERMANENTE"
                        movimiento_actual.Clase_fondo = 1
                    Case Is = "EJERCICIO"
                        movimiento_actual.Clase_fondo = 2
                    Case Is = "RESIDUOS PASIVOS"
                        movimiento_actual.Clase_fondo = 9
                End Select
        End Select
        If CARGAREALIZADA Then
            Detalle_textbox.Text = "PAGO " & Fecha_factura.Value.ToShortDateString & " (" & Beneficiario_label.Text & ") "
        End If
    End Sub

    Private Sub Tipo_clasefondo_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tipo_clasefondo_combobox.SelectedIndexChanged
        If CARGAREALIZADA Then
            SELECCION_CODIGO(Tipo_clasefondo_combobox.SelectedItem.ToString.ToUpper, "CLASE_FONDO")
        End If
    End Sub

    Private Sub Nro_Transferencia_numericupdown_KeyDown(sender As Object, e As KeyEventArgs) Handles Nro_Transferencia_numericupdown.KeyDown,
        Fecha_factura.KeyDown,
        Tipo_clasefondo_combobox.KeyDown, Ordendeentrega_integerupdown.KeyDown, Cuitdelbeneficiario_textbox.KeyDown,
        Monto_factura_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Nro_Transferencia_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Nro_Transferencia_numericupdown.ValueChanged
        movimiento_actual.Transferencia = CType(Nro_Transferencia_numericupdown.Value, Long)
    End Sub

    Private Sub Label_expedienteasociados_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_expedienteasociados.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
    End Sub

    Private Sub NetoAFTERIVA_textbox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles NetoAFTERIVA_textbox.PreviewKeyDown
        valoresennumeros()
    End Sub

    'Private Sub Ganancias_Nro_cheque_ValueChanged(sender As Object, e As EventArgs)
    '    Ganancias_impuesto.Nrotransferencia = Ganancias_Nro_cheque.Value
    'End Sub
    'Private Sub SUSS_Nro_cheque_ValueChanged(sender As Object, e As EventArgs)
    '    SUSS_impuesto.Nrotransferencia = SUSS_Nro_cheque.Value
    'End Sub
    'Private Sub DGR_Nro_cheque_ValueChanged(sender As Object, e As EventArgs)
    '    DGR_impuesto.Nrotransferencia = DGR_Nro_cheque.Value
    'End Sub
    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
    End Sub

    Private Sub MNI_SUSS_LABEL_Click(sender As Object, e As EventArgs) Handles MNI_label_SUSS.Click
    End Sub

    Private Sub GananciasRetenido_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Label_expedienteasociados_Click(sender As Object, e As EventArgs) Handles Label_expedienteasociados.Click
    End Sub

    Private Sub SUSS_GROUPBOX_Enter(sender As Object, e As EventArgs) Handles SUSS_GROUPBOX.Enter
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
    End Sub

    Private Sub Empresa_iva_Combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Sujeto_iva_Combobox.SelectedIndexChanged
        CALCULOIVA()
    End Sub

    Private Sub Chequetotal_numeric_ValueChanged(sender As Object, e As EventArgs) Handles Chequetotal_numeric.ValueChanged
        movimiento_actual.Monto_movimiento = Chequetotal_numeric.Value
    End Sub

    Private Sub IVA_Flicker_Numericupdown_ValueChanged_1(sender As Object, e As EventArgs) Handles IVA_Flicker_Numericupdown.ValueChanged
    End Sub

    Private Sub Boton_totalExpediente_Click(sender As Object, e As EventArgs) Handles Boton_totalExpediente.Click
        Dim totalestemporales As New DataTable
        totalestemporales = Expediente_Actual.retornartotales(Expediente_Actual.claveexpediente)
        Monto_factura_textbox.Value = totalestemporales.Rows(0).Item("SALDO")
        totalestemporales.Dispose()
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

    Private Sub SUSS_tipo_boton_TextChanged(sender As Object, e As EventArgs) Handles SUSS_tipo_boton.TextChanged
        SUSS_impuesto.Nombre_retencion = "SUSS"
        SUSS_impuesto.Nombre_retencion_detalle = sender.text
    End Sub

    Private Sub DGR_tipo_boton_TextChanged(sender As Object, e As EventArgs) Handles DGR_tipo_boton.TextChanged
        DGR_impuesto.Nombre_retencion = "DGR"
        DGR_impuesto.Nombre_retencion_detalle = sender.text
    End Sub

    Private Sub GANANCIAStipo_boton_TextChanged(sender As Object, e As EventArgs) Handles GANANCIAS_tipo_boton.TextChanged
        Ganancias_impuesto.Nombre_retencion = "GANANCIAS"
        Ganancias_impuesto.Nombre_retencion_detalle = sender.text
    End Sub

    Private Sub GANANCIAS_GROUPBOX_Enter(sender As Object, e As EventArgs) Handles GANANCIAS_GROUPBOX.Enter
    End Sub

    Private Sub Ganancias_Flicker_Numericupdown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Ganancias_Flicker_Numericupdown.KeyPress, IVAS_Flicker_Numericupdown.KeyPress, SUSS_Flicker_Numericupdown.KeyPress, NetoAFTERIVA_textbox.KeyPress, IVA_Flicker_Numericupdown.KeyPress, DGR_Flicker_Numericupdown.KeyPress, Chequetotal_numeric.KeyPress, Monto_factura_textbox.KeyPress
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub Nro_Transferencia_numericupdown_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Nro_Transferencia_numericupdown.MouseDoubleClick
        Nro_Transferencia_numericupdown.Value = Movimiento.Cargartransferencias(CUENTABANCARIA)
    End Sub

    Private Sub Boton_temporal_iva_Click(sender As Object, e As EventArgs) Handles Boton_temporal_iva50.Click
        IVA_Flicker_Numericupdown.Value = IVAtemporal_borrar(50)
        IVA_impuesto.Nombre_retencion_detalle = "Ret. 50% IVA"
        IVA_PORCENTAJE_LABEL.Text = "50%"
        NETOTOTAL()
    End Sub

    Private Sub Boton_temporal_iva80_Click(sender As Object, e As EventArgs) Handles Boton_temporal_iva80.Click
        IVA_Flicker_Numericupdown.Value = IVAtemporal_borrar(80)
        IVA_impuesto.Nombre_retencion_detalle = "Ret. 80% IVA"
        IVA_PORCENTAJE_LABEL.Text = "80%"
        NETOTOTAL()
    End Sub

    Private Sub Recalcular_boton_Click(sender As Object, e As EventArgs) Handles Recalcular_boton.Click
        AcumuladosCUIT(movimiento_actual.Clave_expediente_detalle)
        CALCULOIVA()
        CalculoAfterIVA()
    End Sub

    Private Sub Boton_temporal_iva100_Click(sender As Object, e As EventArgs) Handles Boton_temporal_iva100.Click
        IVA_Flicker_Numericupdown.Value = IVAtemporal_borrar(100)
        IVA_impuesto.Nombre_retencion_detalle = "Ret. 100% IVA"
        IVA_PORCENTAJE_LABEL.Text = "100%"
        NETOTOTAL()
    End Sub

End Class