Public Class Tesoreria_Control_Retenciones
    'sección proveedor
    Public CUIT As String = ""
    Public Proveedor_actual As New Proveedor
    Public Fecharetencion As Date = Date.Now
    Public situacionfrenteafip As String = ""
    Dim Inscripcionafip As New DataTable
    Dim Clave_expediente As Long = Nothing
    Public Cuentabancaria As String = ""
    Dim expediente_actual As New Expediente
    Dim Ganancias_retenciones As New DataTable
    Dim Suss_retenciones As New DataTable
    Dim IVA_retenciones As New DataTable
    Dim DGR_retenciones As New DataTable
    Public movimiento_actual As New Movimiento
    Public Ganancias_impuesto As New Retencion
    Public SUSS_impuesto As New Retencion
    Public IVA_impuesto As New Retencion
    Public DGR_impuesto As New Retencion
    Dim tablatemporal As New DataTable
    Dim listadodeexpedientes As New DataTable

    'Dim Porcentajes_IVA As New DataTable
    'Dim SUSS_RETENCIONES As New DataTable
    'Dim DGR_RETENCIONES As New DataTable
    Private Sub Boton_expediente_Click(sender As Object, e As EventArgs) Handles Boton_expediente.Click
        PaneL_impuestos.Visible = True
        listadodeexpedientes = New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("EJERCICIO", Autorizaciones.Year)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUENTAS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 18).Value = Cuentabancaria
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("primerdia", MySql.Data.MySqlClient.MySqlDbType.Date).Value = CType(Autorizaciones.Year - 3 & "-01-01", Date)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("MINIMUNYEAR", MySql.Data.MySqlClient.MySqlDbType.VarChar, 13).Value = Autorizaciones.Year - 3 & "000000000"
        SERVIDORMYSQL.COMMANDSQL.Parameters.Add("CUITS", MySql.Data.MySqlClient.MySqlDbType.VarChar, 13).Value = CUIT
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_MOVIMIENTOS_EXPEDIENTES_SIMPLE2", listadodeexpedientes, System.Reflection.MethodBase.GetCurrentMethod.Name)
        DialogDialogo_Datagridview.Carga_General(listadodeexpedientes, "Expedientes", "Seleccionar", "Cancelar")
        'DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Boton_expediente.Text = "Expediente:" & DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Expediente").Value.ToString &
                "- " & DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Detalle").Value.ToString
            Clave_expediente = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Clave_expediente").Value
            expediente_actual.Cargar_expediente(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Clave_expediente").Value)
            Descripcion_textbox.Text = "PAGO " & Proveedor_actual.Nombre & " (" & Fecharetencion.ToShortDateString & ")"
            Ordendeentrega_integerupdown.Value = expediente_actual.ordenpago
            Ordendeentregayear_integerupdown.Value = expediente_actual.ordenpagoyear
            Monto_factura_textbox.Value = expediente_actual.Totales_expediente.Rows(0).Item("INGRESOS") - (expediente_actual.Totales_expediente.Rows(0).Item("EGRESOS") + expediente_actual.Totales_expediente.Rows(0).Item("RETENCIONES"))
            IngresosMovimientos_textbox.Text = CType(expediente_actual.Totales_expediente.Rows(0).Item("INGRESOS"), Decimal).ToString("C")
            EgresosMovimientos_textbox.Text = CType(expediente_actual.Totales_expediente.Rows(0).Item("EGRESOS"), Decimal).ToString("C")
            RetencionesMovimientos_textbox.Text = CType(expediente_actual.Totales_expediente.Rows(0).Item("RETENCIONES"), Decimal).ToString("C")
            Descripcion_textbox.Text = "PAGO " & Proveedor_actual.Nombre & " (" & Fecharetencion.ToShortDateString & ")"
            ' MessageBox.Show(DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString)
        End If
    End Sub

    Private Sub GANANCIAS_tipo_boton_Click(sender As Object, e As EventArgs) Handles GANANCIAS_tipo_boton.Click
        Cargadevaloresimpuesto_estructura(Ganancias_impuesto)
        Ganancias_impuesto.Nombre_retencion = "GANANCIAS"
        Cargadevariablesimpuesto(sender, Ganancias_retenciones, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", Ganancias_impuesto, Ganancias_Flicker_Numericupdown)
        'Select Case Ganancias_impuesto.Situacionfrente_afip.ToUpper
        '    Case Is = "MONOTRIBUTISTA"
        '        Cargadevariablesimpuesto(sender, Ganancias_retenciones_Monotributista, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", Ganancias_impuesto, Ganancias_Flicker_Numericupdown)
        '    Case Is = "INSCRIPTO"
        '        Cargadevariablesimpuesto(sender, Ganancias_retenciones_ResponsableInscripto, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", Ganancias_impuesto, Ganancias_Flicker_Numericupdown)
        '    Case Is = "NO INSCRIPTO"
        '        Cargadevariablesimpuesto(sender, Ganancias_retenciones_ResponsableNOInscripto, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", Ganancias_impuesto, Ganancias_Flicker_Numericupdown)
        'End Select
    End Sub

    Private Sub SUSS_tipo_boton_Click(sender As Object, e As EventArgs) Handles SUSS_tipo_boton.Click
        Cargadevaloresimpuesto_estructura(SUSS_impuesto)
        SUSS_impuesto.Nombre_retencion = "SUSS"
        Cargadevariablesimpuesto(sender, Suss_retenciones, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", SUSS_impuesto, SUSS_Flicker_Numericupdown)
        'Select Case SUSS_impuesto.Situacionfrente_afip.ToUpper
        '    Case Is = "MONOTRIBUTISTA"
        '        Cargadevariablesimpuesto(sender, SUSS_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", SUSS_impuesto, SUSS_Flicker_Numericupdown)
        '    Case Is = "INSCRIPTO"
        '        Cargadevariablesimpuesto(sender, SUSS_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", SUSS_impuesto, SUSS_Flicker_Numericupdown)
        '    Case Is = "NO INSCRIPTO"
        '        Cargadevariablesimpuesto(sender, SUSS_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", SUSS_impuesto, SUSS_Flicker_Numericupdown)
        'End Select
    End Sub

    Private Sub IVA_tipo_boton_Click(sender As Object, e As EventArgs) Handles IVA_tipo_boton.Click
        Cargadevaloresimpuesto_estructura(IVA_impuesto)
        IVA_impuesto.Nombre_retencion = "IVA"
        Cargadevariablesimpuesto(sender, IVA_retenciones, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", IVA_impuesto, IVA_Flicker_Numericupdown)
        'Cargadevariableopciones(sender, Porcentajes_IVA, "Porcentaje de IVA aplicado", "Seleccionar", "Cancelar")
    End Sub

    Private Sub DGR_tipo_boton_Click(sender As Object, e As EventArgs) Handles DGR_tipo_boton.Click
        DGR_impuesto.clearretencion()
        Cargadevaloresimpuesto_estructura(DGR_impuesto)
        DGR_impuesto.Nombre_retencion = "DGR"
        DGR_impuesto.Nombre_retencion_detalle = sender.text
        Cargadevariablesimpuesto(sender, DGR_retenciones, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", DGR_impuesto, DGR_Flicker_Numericupdown)
        'Select Case DGR_impuesto.Situacionfrente_afip.ToUpper
        '    Case Is = "MONOTRIBUTISTA"
        '    Case Is = "INSCRIPTO"
        '        Cargadevariablesimpuesto(sender, DGR_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", DGR_impuesto, DGR_Flicker_Numericupdown)
        '    Case Is = "NO INSCRIPTO"
        '        Cargadevariablesimpuesto(sender, DGR_RETENCIONES, "Seleccione Regimen de retención", "Seleccionar", "Cancelar", DGR_impuesto, DGR_Flicker_Numericupdown)
        'End Select
    End Sub

    Private Sub Cargadevariablesimpuesto(ByRef boton As Button, ByVal tabla As DataTable, ByVal titulo As String, ByVal aceptarstring As String, ByVal cancelarstring As String,
                                         ByRef impuesto As Retencion, ByRef total_retenido As NumericUpDown)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nombre_retencion", impuesto.Nombre_retencion)
        If impuesto.Nombre_retencion.ToUpper = "DGR" Then
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@situacionfrente_afip", "TODOS")
        Else
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@situacionfrente_afip", impuesto.Situacionfrente_afip)
        End If
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@fecha", Fecharetencion)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select * from
Retencion_TIPOS where Nombre_retencion=@Nombre_retencion and situacionfrente_afip=@situacionfrente_afip and @fecha between inicio_vigencia and Final_vigencia", Ganancias_retenciones, "Cargadevariablesimpuesto")
        DialogDialogo_Datagridview.Carga_General(Ganancias_retenciones, titulo, aceptarstring, cancelarstring, 10)
        DialogDialogo_Datagridview.Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            impuesto.Nombre_retencion_detalle = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item("Nombre_retencion_detalle").Value.ToString.ToUpper
            Cargadevaloresimpuesto_estructura(impuesto)
        Else
            impuesto.Nombre_retencion_detalle = ""
        End If
        impuesto.Total_factura = Monto_factura_textbox.Value
        boton.Text = impuesto.Nombre_retencion_detalle
        'BORRAR Y MEJORAR
        impuesto.Monto_retenido = (impuesto.Total_factura / 100) * impuesto.Alicuota
        'Calculo de los montos retenidos
        'End If
        total_retenido.Value = impuesto.Monto_retenido
        RECALCULAR()
    End Sub

    Private Sub RECALCULAR()
        Chequetotal_numeric.Value = Monto_factura_textbox.Value - (
        Ganancias_Flicker_Numericupdown.Value +
        SUSS_Flicker_Numericupdown.Value +
        IVA_Flicker_Numericupdown.Value +
        DGR_Flicker_Numericupdown.Value)
    End Sub

    'Private Sub cargaganancias()
    '    'tipo de retenciones ganancias
    '    With Ganancias_retenciones_ResponsableInscripto
    '        With .Columns
    '            .Add("Tipo")
    '            .Add("Minimo_no_imponible", GetType(Decimal))
    '            .Add("Ret_Min", GetType(Decimal))
    '            .Add("Alicuota", GetType(Decimal))
    '        End With
    '        With .Rows
    '            .Add("", 0, 0, 0)
    '            .Add("ENAJENACION DE BS MUEBLES Y BS DE CAMBIO", 224000, 240, 2)
    '            .Add("Loc OB Y SERV.", 67170, 240, 2)
    '            .Add("LOCACION BS INMUEBLES", 11200, 240, 6)
    '            .Add("PROFESIONES LIBERALES", 16830, 240, 0)
    '            .Add("SUBSIDIOS VTA COSA MUEBLE", 76140, 240, 2)
    '            .Add("SUBSIDIOS OB Y SERV", 31460, 240, 2)
    '        End With
    '    End With
    '    With Ganancias_retenciones_ResponsableNOInscripto
    '        With .Columns
    '            .Add("Tipo ")
    '            .Add("Minimo_no_imponible", GetType(Decimal))
    '            .Add("Ret_Min", GetType(Decimal))
    '            .Add("Alicuota", GetType(Decimal))
    '        End With
    '        With .Rows
    '            .Add("", 0, 0, 0)
    '            .Add("ENAJENACION DE BS MUEBLES Y BS DE CAMBIO", 224000, 1020, 10)
    '            .Add("Loc OB Y SERV.", 67170, 1020, 28)
    '            .Add("LOCACION BS INMUEBLES", 11200, 1020, 28)
    '            .Add("PROFESIONES LIBERALES", 16830, 1020, 28)
    '            .Add("SUBSIDIOS VTA COSA MUEBLE", 76140, 1020, 10)
    '            .Add("SUBSIDIOS OB Y SERV", 31460, 1020, 28)
    '        End With
    '    End With
    '    With Ganancias_retenciones_Monotributista
    '        With .Columns
    '            .Add("Tipo ")
    '            .Add("Minimo_no_imponible", GetType(Decimal))
    '            .Add("Ret_Min", GetType(Decimal))
    '            .Add("Alicuota", GetType(Decimal))
    '        End With
    '        With .Rows
    '            .Add("", 0, 0, 0)
    '            .Add("ENAJENACION DE BS MUEBLES Y BS DE CAMBIO", 1726599.88, 0, 35) 'IMPUESTO 217 REGIMEN 355
    '            .Add("Loc OB Y SERV.", 1151066.58, 0, 35)
    '            .Add("LOCACION BS INMUEBLES", 0, 0, 35)
    '            .Add("PROFESIONES LIBERALES", 0, 0, 35) 'IMPUESTO 217 REGIMEN 116
    '            .Add("SUBSIDIOS VTA COSA MUEBLE", 0, 0, 35)
    '            .Add("SUBSIDIOS OB Y SERV", 0, 0, 35)
    '        End With
    '    End With
    'End Sub
    'Private Sub cargasuss()
    '    'SUSS RETENCIONES
    '    With SUSS_RETENCIONES
    '        With .Columns
    '            .Add("TIPO")
    '            .Add("Minimo_no_imponible", GetType(Decimal))
    '            .Add("Ret_Min", GetType(Decimal))
    '            .Add("Alicuota", GetType(Decimal))
    '            .Add("cod.regimen", GetType(Integer))
    '            .Add("cod.impuesto", GetType(Integer))
    '        End With
    '        With .Rows
    '            .Add("", 0, 0, 0)
    '            .Add("LIMPIEZA", 0, 400, 6, 748, 353)
    '            .Add("SEGURIDAD E INVESTIG", 80000, 0, 6, 754, 353)
    '            .Add("VTA COSA MUEBLE, Loc OBRA Y/O SERV.", 0, 0, 1, 755, 353)
    '            .Add("OBRAS DE INGENIERÍA", 1500000, 0, 1.2, 740, 353)
    '            .Add("OBRAS DE ARQUITECTURA", 1500000, 0, 2.5, 740, 353)
    '        End With
    '    End With
    'End Sub
    'Private Sub cargadgr()
    '    'DGR RETENCIONES
    '    With DGR_RETENCIONES
    '        With .Columns
    '            .Add("TIPO")
    '            .Add("Minimo_no_imponible", GetType(Decimal))
    '            .Add("Ret_Min", GetType(Decimal))
    '            .Add("Alicuota", GetType(Decimal))
    '        End With
    '        With .Rows
    '            .Add("", 0, 0, 0)
    '            .Add("COMPRA O CONTRATACION DE BIENES O PRESTACION DE OBRAS O SERVICIOS ", 203.9, 0, 4.29)
    '            .Add("CONVENIO MULTILATERAL CON SEDE EN OTRAS PROVINCIAS ", 203.9, 0, 1.96)
    '            .Add("CONVENIO MULTILATERAL QUE INICIAN ACTIVIDAD EN ESTA JURISDICCION CUANDO REALICEN OPERACIONES CON CONSUMIDORES FINALES (ESTADO)", 203.9, 0, 4.29)
    '            .Add("REGIMENES ESPECIALES ART 6 A 13 DE CONVENIO MULTILATERAL  SERA LA  MISMA QUE ART 5 - 1* PARR. SALVO CONSTRUCCION ", 203.9, 0, 1.96)
    '            .Add("REGIMENES ESPECIALES DE CONSTRUCCION Y SIMILARES EJECUTADAS EN ESTA JURISD POR EMPRESAS CON SEDE EN OTRAS PCIAS SU SU ADM U OFICINA EN MNES", 203.9, 0, 4.29)
    '        End With
    '    End With
    'End Sub
    Private Sub Cargadevaloresimpuesto_estructura(ByRef impuesto As Retencion)
        If Not IsNothing(DialogDialogo_Datagridview.FilaSeleccionada) Then
            'impuesto.Nombre_retencion_detalle = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString.ToUpper
            impuesto.Retencion_minima = 0
            impuesto.Minimo_no_imponible = 0
            impuesto.Alicuota = 0
            If IsNothing(impuesto.CUIT) Then
                impuesto.CUIT = CUIT
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

    Private Sub Tesoreria_Control_Retenciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cargaganancias()
        'cargasuss()
        'cargadgr()
        Ganancias_impuesto.Situacionfrente_afip = situacionfrenteafip
        SUSS_impuesto.Situacionfrente_afip = situacionfrenteafip
        DGR_impuesto.Situacionfrente_afip = situacionfrenteafip
        IVA_impuesto.Situacionfrente_afip = situacionfrenteafip
    End Sub

    Private Sub Ganancias_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Ganancias_Flicker_Numericupdown.ValueChanged
        RECALCULAR()
    End Sub

    Private Sub SUSS_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles SUSS_Flicker_Numericupdown.ValueChanged
        RECALCULAR()
    End Sub

    Private Sub DGR_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles DGR_Flicker_Numericupdown.ValueChanged
        RECALCULAR()
    End Sub

    Private Sub IVA_Flicker_Numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles IVA_Flicker_Numericupdown.ValueChanged
        RECALCULAR()
    End Sub

    Private Sub Monto_factura_textbox_ValueChanged(sender As Object, e As EventArgs) Handles Monto_factura_textbox.ValueChanged
        RECALCULAR()
    End Sub

    Private Sub Chequetotal_numeric_ValueChanged(sender As Object, e As EventArgs) Handles Chequetotal_numeric.ValueChanged
    End Sub

End Class