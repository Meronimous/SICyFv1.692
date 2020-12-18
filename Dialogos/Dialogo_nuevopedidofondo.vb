Public Class Dialogo_nuevopedidofondo

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Private Sub N_pedidofondo_numeric_KeyDown(sender As Object, e As KeyEventArgs) Handles N_pedidofondo_numeric.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Year_pedidofondo_numeric_KeyDown(sender As Object, e As KeyEventArgs) Handles Year_pedidofondo_numeric.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Fecha_pedido_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Fecha_pedido.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Descripcion_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Descripcion_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Cuentas_datagrid_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Organismo_numericupdown_KeyDown(sender As Object, e As KeyEventArgs) Handles Organismo_numericupdown.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Numeroexpediente_numericupdown_KeyDown(sender As Object, e As KeyEventArgs) Handles Numeroexpediente_numericupdown.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Year_numericupdown_KeyDown(sender As Object, e As KeyEventArgs) Handles Year_numericupdown.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Clasefondo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Pedidoparcialcheckbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Pedidoparcial_checkbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Public Sub General_cargapedidofondo(ByRef Ped_fondo As PedidoFondos, ByRef ventana As Windows.Forms.Form, ByVal Nuevo As Boolean)
        If Nuevo Then
            OK_Button.Text = "GUARDAR NUEVO PEDIDO DE FONDOS"
            Label_pedidofondo.Text = "NUEVO PEDIDO DE FONDOS"
            Anioejecucion.Value = Date.Now.Year
            Ejercicioactual_checkbox.Checked = True
        Else
            OK_Button.Text = "GUARDAR CAMBIOS EN PEDIDO DE FONDOS EXISTENTE"
            Label_pedidofondo.Text = "PEDIDO DE FONDOS Nº" & Ped_fondo.N_PedidoFondo
            'N_pedidofondo_numeric.Enabled = False
            'N_pedidofondo_numeric.Enabled = False
        End If
        N_pedidofondo_numeric.Value = Ped_fondo.N_PedidoFondo
        If Not Year_pedidofondo_numeric.Value = 0 Then
            Year_pedidofondo_numeric.Value = Ped_fondo.YearPedidoFondo
        End If
        Fecha_pedido.Value = Ped_fondo.Fecha_Pedido
        Descripcion_textbox.Text = Ped_fondo.Descripcion
        Organismo_numericupdown.Value = Ped_fondo.ExpteOrganismo
        Numeroexpediente_numericupdown.Value = Ped_fondo.ExpteNumero
        Year_numericupdown.Value = Ped_fondo.ExpteYear
        Anioejecucion.Value = Ped_fondo.Clase_fondo
        'evaluacion_ejercicio_residuos
        Pedidoparcial_checkbox.Checked = Ped_fondo.Parcial
        Pedidohaberes_checkbox.Checked = Ped_fondo.Haberes
        Cuentas_datagrid.DataSource = Autocompletetables.Cuentas
        For z = 0 To Cuentas_datagrid.Rows.Count - 1
            If Ped_fondo.Cuenta_PedidoFondo = Cuentas_datagrid.Rows(z).Cells.Item(0).Value.ToString Then
                'Cuentas_datagrid.CurrentCell = Nothing
                'Cuentas_datagrid.Rows(z).Selected = True
                Cuentas_datagrid.CurrentCell = Cuentas_datagrid.Rows(z).Cells.Item(0)
                ' Cuentas_datagrid.SelectedRows(0) = Cuentas_datagrid.Rows(z)
                Exit For
            End If
        Next
        For z = 0 To Cuentas_datagrid.Rows.Count - 1
            If Ped_fondo.Cuenta_PedidoFondo = Cuentas_datagrid.Rows(z).Cells.Item(0).Value.ToString Then
                'Cuentas_datagrid.CurrentCell = Nothing
                'Cuentas_datagrid.Rows(z).Selected = True
                Cuentas_datagrid.CurrentCell = Cuentas_datagrid.Rows(z).Cells.Item(0)
                ' Cuentas_datagrid.SelectedRows(0) = Cuentas_datagrid.Rows(z)
                Exit For
            End If
        Next
        'Cuentas_datagrid.CurrentCell = Nothing
        Mostrardialogo(Me)
        'Me.ShowDialog()
        'Organismo_numericupdown.Value = Expediente_seleccionado.organismo
        'Numeroexpediente_numericupdown.Value = Expediente_seleccionado.numero
        'If Expediente_seleccionado.principalyear > 1999 Then
        '    Year_numericupdown.Value = Expediente_seleccionado.year
        'Else
        '    Year_numericupdown.Value = Date.Now.Year
        'End If
        'Detalleexpediente_textbox.Text = Expediente_seleccionado.Descripcion
        'Fechaingreso_datetimepicker.Value = Expediente_seleccionado.Fecha
        'N_ordenpago_integerupdown.Value = Expediente_seleccionado.ordenpago
        'Year_ordenpago_integerupdown.Value = Expediente_seleccionado.ordenpagoyear
        'N_ordencargo_integerupdown.Value = Expediente_seleccionado.ordencargo
        'Year_ordencargo_integerupdown.Value = Expediente_seleccionado.ordencargoyear
        'Tieneexpteprincipal_checkbox.Checked = Expediente_seleccionado.tieneprincipal
        'Organismoprincipal_NumericUpDown.Value = Expediente_seleccionado.principalorganismo
        'Numeroprincipal_NumericUpDown.Value = Expediente_seleccionado.principalnumero
        'If Expediente_seleccionado.principalyear > 1999 Then
        '    Yearprincipal_NumericUpDown.Value = Expediente_seleccionado.principalyear
        'Else
        '    Yearprincipal_NumericUpDown.Value = Date.Now.Year
        'End If
        'Detalleprincipal_textbox.Text = Expediente_seleccionado.principaldescripcion
    End Sub

    'Private Sub Evaluacion_ejercicio_residuos()
    '    If Anioejecucion.Value = Year_pedidofondo_numeric.Value Then
    '        Ejercicioactual_checkbox.Checked = True
    '        Residuospasivos_checkbox.Checked = False
    '    Else
    '        If (Anioejecucion.Value < Year_pedidofondo_numeric.Value) And Not (Anioejecucion.Value < Year_pedidofondo_numeric.Value - 2) Then
    '            Residuospasivos_checkbox.Checked = True
    '            Ejercicioactual_checkbox.Checked = False
    '        Else
    '            Ejercicioactual_checkbox.Checked = True
    '            Residuospasivos_checkbox.Checked = False
    '            MsgBox("EL DATO INGRESADO SUGIERE QUE LOS RESIDUOS PASIVOS SON ANTERIORES A LOS 2(DOS) AÑOS DE EL EJERCICIO ACTUAL, LO CUAL ESTA PROHIBIDO" & vbNewLine & "POR FAVOR VERIFIQUE")
    '        End If
    '    End If
    '    Residuosopasivos_groupbox.Visible = Residuospasivos_checkbox.Checked
    'End Sub
    Private Sub Residuospasivos_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles Residuospasivos_checkbox.CheckedChanged
        Ejercicioactual_checkbox.Checked = Not (Residuospasivos_checkbox.Checked)
        Residuosopasivos_groupbox.Visible = Residuospasivos_checkbox.Checked
    End Sub

    Private Sub Ejercicioactual_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles Ejercicioactual_checkbox.CheckedChanged
        Residuospasivos_checkbox.Checked = Not (Ejercicioactual_checkbox.Checked)
        Residuosopasivos_groupbox.Visible = Not (Ejercicioactual_checkbox.Checked)
    End Sub

    Private Sub General_nuevopedidofondo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Inicio.Enabled = False
    End Sub

    Private Sub General_nuevopedidofondo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Inicio.Enabled = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Dim Total_Errores As String = ""
        Dim Datos_validos As Boolean = True
        Dim Datos_advertencia As Boolean = True
        Dim Errores(8) As String
        Dim Advertencias(8) As String
        Dim pedidofondo_verificar As New DataTable
        If Label_pedidofondo.Text = "NUEVO PEDIDO DE FONDOS" Then
            pedidofondo_verificar = Verificacionpedidofondo(0)
        Else
            pedidofondo_verificar = Verificacionpedidofondo(CType(Year_pedidofondo_numeric.Text & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"), Long))
        End If
        'Select Case Not (pedidofondo_verificar.Rows.Count > 0)
        '    Case = True
        Select Case MsgBox("Confirma que desea Cargar este pedido de Fondo Nº" & N_pedidofondo_numeric.Value, MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                'verificación
                Select Case Descripcion_textbox.TextLength > 0
                    Case True
                    Case False
                        Datos_validos = False
                        Errores(0) = "La descripción de este pedido de fondo se encuentra vacía por favor completela"
                End Select
                'If (Anioejecucion.Value < Year_pedidofondo_numeric.Value) And Not (Anioejecucion.Value < Year_pedidofondo_numeric.Value - 2) Then
                'Else
                '    Datos_validos = False
                '    Errores(1) = "EL DATO INGRESADO SUGIERE QUE LOS RESIDUOS PASIVOS " & Anioejecucion.Value & " SON ANTERIORES A LOS 2(DOS) AÑOS DE EL EJERCICIO ACTUAL " & Year_pedidofondo_numeric.Value & " , LO CUAL ESTA PROHIBIDO" & vbNewLine & "POR FAVOR VERIFIQUE"
                'End If
                'Select Case Organismo_numericupdown.Value.ToString.Length > 0
                '    Case True
                '        Select Case IsNumeric(Organismo_textbox.Text)
                '            Case True
                '            Case False
                '                Datos_validos = False
                '                Advertencias(1) = "El Código de Organismo en El expediente de pedido de fondos es un número de 4 cifras"
                '        End Select
                '    Case False
                '        Datos_validos = False
                '        Advertencias(1) = "El Número correspondiente al organismo esta vacío"
                'End Select
                'Select Case Numeroexpediente_numericupdown.Value > 0
                '    Case False
                '        Datos_advertencia = False
                '        Advertencias(0) = "El Número de expediente actualmente es 0. La impresión no va a contener este dato."
                'End Select
                Select Case Year_numericupdown.Value < Date.Now.Year
                    Case True
                        Datos_advertencia = False
                        Advertencias(1) = "El año del expediente del pedido de fondos, es menor al año en curso."
                    Case False
                End Select
                'Select Case Year_expediente_textbox.TextLength > 0
                '    Case True
                '        Select Case Year_expediente_textbox.TextLength = 4
                '            Case True
                '            Case False
                '                Datos_validos = False
                '                Errores(3) = "El año del expediente debe ser ingresado con 4 cifras  ej." & Date.Now.Year
                '        End Select
                '    Case False
                '        Datos_validos = False
                '        Errores(3) = "El año del expediente se encuentra vacío, por favor complete."
                'End Select
                'Select Case Anioejecucion.TextLength > 0
                '    Case True
                '    Case False
                '        Datos_validos = False
                '        Errores(4) = "La Clase de fondo se encuentra vacía por favor completela"
                'End Select
                Select Case Cuentas_datagrid.SelectedRows.Count > 0
                    Case True
                    Case False
                        Datos_validos = False
                        Errores(6) = "Recuerde seleccionar una cuenta bancaria asociada"
                End Select
                If Datos_advertencia = True Then
                Else
                    For x = 0 To Advertencias.Count - 1
                        If Not (Advertencias(x) = "") Then
                            Total_Errores = Total_Errores & vbCrLf & "-" & Advertencias(x)
                        End If
                    Next
                    Select Case MsgBox("Confirma que desea Cargar este pedido de Fondo Nº" & N_pedidofondo_numeric.Value & " aún con las siguiente inconsistencias" & vbCrLf & Total_Errores, MsgBoxStyle.YesNoCancel, " ")
                        Case True
                            Datos_advertencia = True
                        Case False
                            Datos_advertencia = False
                    End Select
                    Total_Errores = ""
                End If
                If Datos_advertencia = True Then
                    Select Case Datos_validos
                        Case True
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Text & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@N_pedidofondo", N_pedidofondo_numeric.Value)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_pedidofondo", Year_pedidofondo_numeric.Value)
                            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto_pedidofondo", Pedidodefondosmontowpf.Monto_textbox.Number)
                            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@N_ordenpago", N_ordenpagocargo_textbox.Value)
                            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_ordenpago", Year_ordenpagocargo_textbox.Text)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta_pedidofondo", Cuentas_datagrid.SelectedRows(0).Cells.Item(0).Value)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", Organismo_numericupdown.Value & "-" & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000") & "/" & Year_numericupdown.Value)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Descripcion", Descripcion_textbox.Text)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_pedido", Fecha_pedido.Value)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clase_fondo", Anioejecucion.Value)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Parcial", Pedidoparcial_checkbox.Checked)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Haberes", Pedidohaberes_checkbox.Checked)
                            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `Pedido_fondos` " &
                                        "(Clave_pedidofondo,N_pedidofondo,Year_pedidofondo,Monto_pedidofondo,Cuenta_pedidofondo,Descripcion,Fecha_pedido,Clase_fondo,Expediente_N,Parcial,Haberes,Usuario) " &
                                        "VALUES
                                    (@Clave_pedidofondo,@N_pedidofondo,@Year_pedidofondo,0,@Cuenta_pedidofondo,@Descripcion,@Fecha_pedido,@Clase_fondo,@Expediente_N,@Parcial,@Haberes,@Usuario) " &
                                        "ON DUPLICATE KEY UPDATE " &
                                        "Clave_pedidofondo=@Clave_pedidofondo,N_pedidofondo=@N_pedidofondo,Year_pedidofondo=@Year_pedidofondo,Cuenta_pedidofondo=@Cuenta_pedidofondo,Descripcion=@Descripcion,
Fecha_pedido=@Fecha_pedido,Clase_fondo=@Clase_fondo,Expediente_N=@Expediente_N,Parcial=@Parcial,Haberes=@Haberes,Usuario=@Usuario "
                            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                            Tesoreria_Pedidofondos.refreshnow()
                            N_pedidofondo_numeric.Value = Buscarmaximo_pedidofondo(Date.Now.Year)
                            Year_pedidofondo_numeric.Value = Date.Now.Year
                            Fecha_pedido.Value = Date.Now
                            Cuentas_datagrid.CurrentCell = Nothing
                            Organismo_numericupdown.Value = CType(Autorizaciones.Organismo.ToString.Substring(0, 4), Integer).ToString.Substring(0, 4).ToString.Substring(0, 4)
                            Numeroexpediente_numericupdown.Value = 0
                            Year_numericupdown.Value = Date.Now.Year
                            Descripcion_textbox.Text = ""
                            Anioejecucion.Value = Date.Now.Year
                            Pedidoparcial_checkbox.Checked = False
                            Residuospasivos_checkbox.Checked = False
                            Ejercicioactual_checkbox.Checked = True
                            Tesoreria_Pedidofondos.refreshnow()
                            Me.Close()
                        ' Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
                        ' Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
                        'SplitContainer2.Panel2.Enabled = False
                        'Panelnuevopedido.Enabled = False
                        ''ActivarControlesenpanel(SplitContainer2.Panel2, False)
                        'Boton_Modificar.Enabled = True
                        'Boton_borrar.Enabled = True
                        'Boton_Nuevo.Enabled = True
                        'Guardarcambios_boton.Visible = False
                        'Cancelarcambios_boton.Visible = False
                        'SplitContainer2.Panel1.Enabled = True
                        'SplitContainer3.Panel1.Enabled = True
                        'SplitContainer3.Panel2.Enabled = True
                        Case False
                            For x = 0 To Errores.Count - 1
                                If Not (Errores(x) = "") Then
                                    Total_Errores = Total_Errores & vbCrLf & "-" & Errores(x)
                                End If
                            Next
                            MessageBox.Show("Actualmente el pedido de fondo contiene los siguientes errores " & vbCrLf & Total_Errores & vbCrLf & "Hasta que no se corrijan estos errores no se puede continuar")
                    End Select
                Else
                    MessageBox.Show("Los datos no van a ser cargados")
                End If
            Case Else
                MessageBox.Show("los datos se guardaron en la base de datos")
        End Select
        '    Case Else
        '        MessageBox.Show("El pedido de fondos ya existe, por favor verifique el mismo")
        'End Select
    End Sub

    Private Sub Cuentas_datagrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Label_pedidofondo_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_pedidofondo.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Year_pedidofondo_numeric_ValueChanged(sender As Object, e As EventArgs) Handles Year_pedidofondo_numeric.ValueChanged
        ' Evaluacion_ejercicio_residuos()
    End Sub

    Private Sub Anioejecucion_ValueChanged(sender As Object, e As EventArgs) Handles Anioejecucion.ValueChanged
    End Sub

    Private Sub Pedidohaberes_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles Pedidohaberes_checkbox.CheckedChanged
    End Sub

    Private Sub Pedidoparcial_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles Pedidoparcial_checkbox.CheckedChanged
    End Sub

    Private Sub Label_pedidofondo_Click(sender As Object, e As EventArgs) Handles Label_pedidofondo.Click
    End Sub

End Class