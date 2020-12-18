Public Class Dialogo_Nuevoexpediente
    '----------------------------------------
    Dim Existenciaexpediente As New DataTable
    Dim Esnuevoexpediente As Boolean = False
    Dim Expediente_seleccionado As New Expediente
    Dim Claveactual As Long = 0

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    '----------------------------------------
    Private Sub Organismo_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Organismo_numericupdown.KeyDown, Numeroexpediente_numericupdown.KeyDown, Year_numericupdown.KeyDown, Fechaingreso_datetimepicker.KeyDown, N_ordenpago_integerupdown.KeyDown, Year_ordenpago_integerupdown.KeyDown, N_ordencargo_integerupdown.KeyDown, Year_ordencargo_integerupdown.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Public Sub General_cargaexpediente(ByVal Expediente_seleccionados As Expediente, ByVal colorfondo As Color)
        '
        Me.BackColor = colorfondo
        Expediente_seleccionado = Expediente_seleccionados
        Select Case Expediente_seleccionado.numero
            Case 0
                Esnuevoexpediente = True
                BotonCUITS.Visible = False
                OK_Button.Text = "GUARDAR NUEVO EXPEDIENTE"
                Label_expedienteasociados.Text = "NUEVO EXPEDIENTE"
                Me.Width = 435
            Case Else
                Esnuevoexpediente = False
                BotonCUITS.Visible = True
                OK_Button.Text = "GUARDAR CAMBIOS EN EXPEDIENTE EXISTENTE"
                Label_expedienteasociados.Text = "Expte: " & Expediente_seleccionado.organismo & "-" & Expediente_seleccionado.numero & "/" & Expediente_seleccionado.year
                Me.Width = 879
        End Select
        Label_expedienteasociados.Location = New Point((Me.Width / 2) - (Label_expedienteasociados.Width / 2), Label_expedienteasociados.Location.Y)
        'MessageBox.Show(Label_expedienteasociados.Location.X & vbCrLf & Label_expedienteasociados.Location.Y)
        Organismo_numericupdown.Value = Expediente_seleccionado.organismo
        Numeroexpediente_numericupdown.Value = Expediente_seleccionado.numero
        'Year_numericupdown.Value = Expediente_seleccionado.year
        If Expediente_seleccionado.year > 1999 Then
            Year_numericupdown.Value = Expediente_seleccionado.year
        Else
            Year_numericupdown.Value = Date.Now.Year
        End If
        Detalleexpediente_textbox.Text = Expediente_seleccionado.descripcion
        Fechaingreso_datetimepicker.Value = Expediente_seleccionado.fecha
        N_ordenpago_integerupdown.Value = Expediente_seleccionado.ordenpago
        Year_ordenpago_integerupdown.Value = Expediente_seleccionado.ordenpagoyear
        N_ordencargo_integerupdown.Value = Expediente_seleccionado.ordencargo
        Year_ordencargo_integerupdown.Value = Expediente_seleccionado.ordencargoyear
        Tieneexpteprincipal_checkbox.Checked = Expediente_seleccionado.tieneprincipal
        Labelcuentaespecialasignada.Text = Expediente_seleccionado.Asignarcuentaespecial
        Organismoprincipal_NumericUpDown.Value = Expediente_seleccionado.principalorganismo
        Numeroprincipal_NumericUpDown.Value = Expediente_seleccionado.principalnumero
        Claveactual = CType(Expediente_seleccionado.clave(), Long)
        Exptehaberes_checkbox.Checked = Expediente_seleccionado.haberes
        'Plan_cuentas_tesoro_textbox.Text = Expediente_seleccionado.Rubro
        'Montodelexpediente_textbox.Text = Expediente_seleccionado.monto
        If Expediente_seleccionado.principalyear > 1999 Then
            Yearprincipal_NumericUpDown.Value = Expediente_seleccionado.principalyear
        Else
            Yearprincipal_NumericUpDown.Value = Date.Now.Year
        End If
        'If Panel_pedidoFondo.Visible Then
        '    Expediente_seleccionado.pedidofondo
        'Else
        'End If
        Labelcuentaespecialasignada.Text = Expediente_seleccionado.cuentaespecial
        Detalleprincipal_textbox.Text = Expediente_seleccionado.principaldescripcion
        cargadatosproveedores(Expediente_seleccionado.haberes)
        If Me.Visible = False Then
            Mostrardialogo(Me)
        End If
    End Sub

    Private Sub General_nuevoexpediente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Year_numericupdown.Value < 2016 Then
            Year_numericupdown.Value = Date.Now.Year
            Year_ordencargo_integerupdown.Value = Date.Now.Year
            Year_ordenpago_integerupdown.Value = Date.Now.Year
            BotonCUITS.Visible = Not (Esnuevoexpediente)
        End If
    End Sub

    Private Sub General_nuevoexpediente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    End Sub

    Private Sub nuevoexpediente()
        OK_Button.Text = "GUARDAR NUEVO EXPEDIENTE"
        Label_expedienteasociados.Text = "NUEVO EXPEDIENTE"
        Detalleexpediente_textbox.Text = ""
        Fechaingreso_datetimepicker.Value = Date.Now
        N_ordenpago_integerupdown.Value = 0
        Year_ordenpago_integerupdown.Value = Date.Now.Year
        N_ordencargo_integerupdown.Value = 0
        Year_ordencargo_integerupdown.Value = Date.Now.Year
        'BotonCUITS.Visible = False
        'Proveedores_datagrid.Visible = False
        If Me.Width > 500 Then
            Me.Width = Width - (BotonCUITS.Width + Proveedores_datagrid.Width + 12)
        End If
    End Sub

    Private Sub expedienteactual()
        Dim ordenpago As String() = Nothing
        Dim ordencargo As String() = Nothing
        OK_Button.Text = "GUARDAR CAMBIOS EN EXPEDIENTE EXISTENTE"
        cargadatosproveedores()
        'BotonCUITS.Visible = True
        Proveedores_datagrid.Visible = True
        'If Me.Width < 500 Then
        '    Me.Width = Me.Width + (BotonCUITS.Width + Proveedores_datagrid.Width + 12)
        'End If
        Label_expedienteasociados.Text = "EXPTE:" & Existenciaexpediente.Rows(0).Item("Expediente_N") & " " & Existenciaexpediente.Rows(0).Item("DETALLE")
        Detalleexpediente_textbox.Text = Existenciaexpediente.Rows(0).Item("DETALLE")
        Fechaingreso_datetimepicker.Value = Existenciaexpediente.Rows(0).Item("FECHA")
        'hay que dividir la orden de pago en 2 partes para que quepan en los controles.
        ordenpago = Divisordedosvariables(Existenciaexpediente.Rows(0).Item("Ordenpago").ToString)
        If Not IsNothing(ordenpago) Then
            If ordenpago.Length > 1 Then
                'en caso de que haya sido ingresada su longitud al dividir es mayor a 1, el caracter que determina la división del mismo es "/"
                If ordenpago(0).Length > 0 Then
                    N_ordenpago_integerupdown.Value = CType(ordenpago(0), Decimal)
                Else
                    N_ordenpago_integerupdown.Value = 0
                End If
                Year_ordenpago_integerupdown.Value = CType(ordenpago(1), Decimal)
            Else
                N_ordenpago_integerupdown.Value = 0
                Year_ordenpago_integerupdown.Value = Date.Now.Year
            End If
        Else
            N_ordenpago_integerupdown.Value = 0
            Year_ordenpago_integerupdown.Value = Date.Now.Year
        End If
        'hay que dividir la orden de cargo si existe en 2 partes para que quepan en los controles.
        ordencargo = Divisordedosvariables(Existenciaexpediente.Rows(0).Item("Ordencargo").ToString)
        'en caso de que haya sido ingresada su longitud al dividir es mayor a 1, el caracter que determina la división del mismo es "/"
        If Not IsNothing(ordencargo) Then
            If ordencargo.Length > 1 Then
                If ordencargo(0).Length > 0 Then
                    N_ordencargo_integerupdown.Value = CType(ordencargo(0), Decimal)
                Else
                    N_ordencargo_integerupdown.Value = 0
                End If
                Year_ordencargo_integerupdown.Value = CType(ordencargo(1), Decimal)
            Else
                N_ordencargo_integerupdown.Value = 0
                Year_ordencargo_integerupdown.Value = Date.Now.Year
            End If
        Else
            N_ordencargo_integerupdown.Value = 0
            Year_ordencargo_integerupdown.Value = Date.Now.Year
        End If
    End Sub

    Public Sub cargadatosproveedores(Optional ByVal haberes As Boolean = False)
        Dim consultaasociada As String = ""
        Dim datosasociados As New DataTable
        Dim consultaNoasociada As String = ""
        Dim datosnoasociados As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Expediente_seleccionado.clave)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"))
        If haberes = True Then
            consultaasociada = "Select Proveedor,CUIT,MONTO,MD5HASH FROM (SElect CUIT,MONTO,Clave_expediente,MD5HASH from CUIT_expediente where Clave_expediente=@clave_expediente)A
LEFT JOIN
(Select Proveedor,CUIT as 'Cuitproveedores' from proveedores_haberes) B ON
A.CUIT=B.Cuitproveedores"
        Else
            consultaasociada = "Select Proveedor,CUIT,MONTO,MD5HASH FROM (SElect CUIT,MONTO,Clave_expediente,MD5HASH from CUIT_expediente where Clave_expediente=@clave_expediente)A
LEFT JOIN
(Select Proveedor,CUIT as 'Cuitproveedores' from proveedores ) B ON
A.CUIT=B.Cuitproveedores"
        End If
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultaasociada, datosasociados, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Proveedores_datagrid.DataSource = datosasociados
        If datosasociados.Rows.Count > 0 Then
            Proveedores_datagrid.Columns("MD5HASH").Visible = False
            Proveedores_datagrid.Columns("MONTO").DefaultCellStyle.Format = "C"
            Dim sumadelexpediente As Decimal = 0
            For x = 0 To Proveedores_datagrid.Rows.Count - 1
                sumadelexpediente += CType(Proveedores_datagrid.Rows(x).Cells.Item("MONTO").Value, Decimal)
            Next
            Montodelexpediente_textbox.Text = sumadelexpediente.ToString("C")
            BotonCUITS.Visible = True
        Else
            ' Proveedores_datagrid.Columns.Add("Detalle")
            Montodelexpediente_textbox.Text = Expediente_seleccionado.monto
            BotonCUITS.Visible = False
        End If
        'Montodelexpediente(sumadelexpediente, Proveedores_datagrid, Montodelexpediente_textbox)
    End Sub

    'Private Sub Montodelexpediente(ByVal sumadelexpediente As Decimal, ByRef Datagrid As Object, ByRef Monto As Object)
    '    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_expediente", Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"))
    '    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", sumadelexpediente)
    '    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = " UPDATE `expediente` SET Monto=@Monto Where Clave_expediente=@Clave_expediente"
    '    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    '    Select Case Datagrid.GetType.ToString.ToUpper
    '        Case "SYSTEM.WINDOWS.CONTROLS.DATAGRID"
    '            Datagrid.SelectedCells.Item(0).Item("Monto") = sumadelexpediente
    '        Case "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
    '            Datagrid.selectedrows(0).cells.item("Monto").value = sumadelexpediente
    '    End Select
    '    Select Case Monto.GetType.ToString
    '        Case "CURRENCYTEXTBOXCONTROL.CURRENCYTEXTBOX"
    '            Monto.Number = sumadelexpediente
    '        Case "SYSTEM.WINDOWS.FORMS.TEXTBOX"
    '            Monto.text = sumadelexpediente
    '    End Select
    '    '   MessageBox.Show(Monto.GetType.ToString)
    '    ' MessageBox.Show(Expedientes.BusquedaWPF1.Datos_datagrid.GetType.ToString)
    '    '        Expedientes.Control_ExpedientesWPF1.Montodelexpediente_textbox.Number = sumadelexpediente
    '    '        Expedientes.BusquedaWPF1.Datos_datagrid.SelectedCells.Item(0).Item("Monto") = sumadelexpediente
    '    Montodelexpediente_textbox.Text = sumadelexpediente
    'End Sub
    'Private Sub Numeroexpediente_numericupdown_Leave(sender As Object, e As EventArgs) Handles Numeroexpediente_numericupdown.Leave
    '    If Numeroexpediente_numericupdown.Value > 0 Then
    '        verificarexpediente(CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long))
    '        Claveactual = CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
    '    Else
    '        verificarexpediente(0)
    '    End If
    '    '
    'End Sub
    Private Sub Numeroexpediente_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Numeroexpediente_numericupdown.ValueChanged
        Expediente_seleccionado.numero = Numeroexpediente_numericupdown.Value
    End Sub

    Private Sub Organismo_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Organismo_numericupdown.ValueChanged
        Expediente_seleccionado.organismo = Organismo_numericupdown.Value
    End Sub

    Private Sub Year_numericupdown_ValueChanged(sender As Object, e As EventArgs) Handles Year_numericupdown.ValueChanged
        Expediente_seleccionado.year = Year_numericupdown.Value
    End Sub

    Private Sub Organismo_numericupdown_Leave(sender As Object, e As EventArgs) Handles Organismo_numericupdown.Leave, Year_numericupdown.Leave, Numeroexpediente_numericupdown.Leave
        If Not (Claveactual = CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)) Then
            If (Year_numericupdown.Value.ToString.Length = 4) And (Numeroexpediente_numericupdown.Value > 0) And (Organismo_numericupdown.Value.ToString.Length = 4) Then
                verificarexpediente(CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long))
                Claveactual = CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
            Else
                verificarexpediente(0)
            End If
        Else
        End If
    End Sub

    'Private Sub Year_textbox_Leave(sender As Object, e As EventArgs) Handles Year_numericupdown.Leave
    '    If Not (Claveactual = CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)) Then
    '        If Year_numericupdown.Value.ToString.Length = 4 Then
    '            verificarexpediente(CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long))
    '            Claveactual = CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
    '        Else
    '            verificarexpediente(0)
    '        End If
    '    Else
    '    End If
    'End Sub
    Private Sub verificarexpediente(Optional ByVal clave As Long = 0)
        'Existenciaexpediente = Verificacionexpediente(CType(Year_numericupdown.Value & Organismo_numericupdown.Value & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long))
        Existenciaexpediente = Verificacionexpediente(clave)
        If Existenciaexpediente.Rows.Count > 0 Then
            'en caso de que exista el expediente hay que cargar los datos al resto de los campos
            expedienteactual()
            Esnuevoexpediente = False
            Me.Width = 879
        Else
            'en caso de que el expediente no exista hay que poner los valores de botones y labels a nuevo
            nuevoexpediente()
            Esnuevoexpediente = True
            Me.Width = 435
        End If
    End Sub

    Private Sub Organismo_numericupdown_Enter(sender As Object, e As EventArgs) Handles Organismo_numericupdown.Enter
        sender.Select(0, sender.Value.ToString.Length)
    End Sub

    Private Sub Numeroexpediente_numericupdown_Enter(sender As Object, e As EventArgs) Handles Numeroexpediente_numericupdown.Enter
        sender.Select(0, sender.Value.ToString.Length)
    End Sub

    Private Sub Detalleexpediente_textbox_Enter(sender As Object, e As EventArgs) Handles Detalleexpediente_textbox.Enter
        Detalleexpediente_textbox.SelectAll()
    End Sub

    Private Sub N_ordenpago_integerupdown_Enter(sender As Object, e As EventArgs) Handles N_ordenpago_integerupdown.Enter
        sender.Select(0, sender.Value.ToString.Length)
    End Sub

    Private Sub Year_ordenpago_integerupdown_Enter(sender As Object, e As EventArgs) Handles Year_ordenpago_integerupdown.Enter
        sender.Select(0, sender.Value.ToString.Length)
    End Sub

    Private Sub N_ordencargo_integerupdown_Enter(sender As Object, e As EventArgs) Handles N_ordencargo_integerupdown.Enter
        sender.Select(0, sender.Value.ToString.Length)
    End Sub

    Private Sub Year_ordencargo_integerupdown_Enter(sender As Object, e As EventArgs) Handles Year_ordencargo_integerupdown.Enter
        sender.Select(0, sender.Value.ToString.Length)
    End Sub

    Private Sub Fechaingreso_datetimepicker_Enter(sender As Object, e As EventArgs) Handles Fechaingreso_datetimepicker.Enter
    End Sub

    Private Sub OK_Button_Enter(sender As Object, e As EventArgs) Handles OK_Button.Enter
        OK_Button.BackColor = Color.LightGreen
        OK_Button.Font = New Font("Segoe UI", 16, Font.Style.Bold)
    End Sub

    Private Sub OK_Button_Leave(sender As Object, e As EventArgs) Handles OK_Button.Leave
        OK_Button.BackColor = Color.SkyBlue
        OK_Button.Font = New Font("Segoe UI", 16, Font.Style.Bold)
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Agregaromodificar()
        Organismo_numericupdown.Select()
    End Sub

    Private Sub Agregaromodificar()
        Dim Datos_validos As Boolean = True
        Dim Errores(7) As String
        Dim Total_errores As String = ""
        'verificación
        'ORGANISMO NUMERO DE 4 CIFRAS
        If Organismo_numericupdown.Value > 999 And Organismo_numericupdown.Value < 10000 Then
            Organismo_numericupdown.BackColor = Color.White
        Else
            Datos_validos = False
            Errores(0) = "El Código de Organismo en El expediente de pedido de fondos es un número de 4 cifras, por favor verifique"
            Organismo_numericupdown.BackColor = Color.LightCoral
        End If
        'NUMERO DE EXPEDIENTE MAYOR A CERO MENOR A 100000
        If Numeroexpediente_numericupdown.Value > 0 And Numeroexpediente_numericupdown.Value < 100000 Then
            Numeroexpediente_numericupdown.BackColor = Color.White
        Else
            Datos_validos = False
            If Numeroexpediente_numericupdown.Value > 100000 Then
                Errores(1) = "El Número de expediente es mayor a lo tolerado actualmente por el sistema"
            Else
                Errores(1) = "El Número de expediente es ilógico verifique"
            End If
            Numeroexpediente_numericupdown.BackColor = Color.LightCoral
        End If
        'AÑO DEL EXPEDIENTE VALORES COHERENTES
        If Year_numericupdown.Value > 2000 And Year_numericupdown.Value <= Date.Now.Year Then
            Year_numericupdown.BackColor = Color.White
        Else
            Datos_validos = False
            If Date.Now.Year < 2019 Then
                Errores(2) = "VERIFIQUE LA FECHA DE SU MÁQUINA -El año del expediente contiene una inconsistencia"
            Else
                Errores(2) = "El año del expediente contiene una inconsistencia"
            End If
            Year_numericupdown.BackColor = Color.LightCoral
        End If
        If (N_ordenpago_integerupdown.Value > 0 And Year_ordenpago_integerupdown.Value > 2000) Or ((N_ordencargo_integerupdown.Value > 0 And Year_ordencargo_integerupdown.Value > 2000)) Then
            N_ordenpago_integerupdown.BackColor = Color.White
            N_ordencargo_integerupdown.BackColor = Color.White
        Else
            If Me.BackColor = Color.LightCyan Then
                Datos_validos = False
                Errores(3) = "EL EXPEDIENTE DEBE CONTENER UN NÚMERO DE ORDEN DE PAGO O DE CARGO, VERIFIQUE POR FAVOR"
                N_ordenpago_integerupdown.BackColor = Color.LightCoral
                N_ordencargo_integerupdown.BackColor = Color.LightCoral
            Else
                N_ordenpago_integerupdown.BackColor = Color.Yellow
                N_ordencargo_integerupdown.BackColor = Color.Yellow
            End If
        End If
        'DESCRIPCION DEL EXPEDIENTE
        If Detalleexpediente_textbox.Text.Length > 0 Then
            Detalleexpediente_textbox.BackColor = Color.White
        Else
            Datos_validos = False
            Errores(4) = "Debe ingresar un detalle o descripción del expediente"
            Detalleexpediente_textbox.BackColor = Color.LightCoral
        End If
        'Select Case Montodelexpediente_textbox.Number > 0
        '    Case True
        '    Case False
        '        Datos_validos = False
        '        Errores(5) = "El monto del expediente debe ser Mayor a 0 (cero)"
        'End Select
        If Datos_validos = True Then
            If (Organismo_numericupdown.Text.Length = 4) And (IsNumeric(Numeroexpediente_numericupdown.Value.ToString)) And ((IsNumeric(Year_numericupdown.Value.ToString)) And (Year_numericupdown.Text.Length = 4)) Then
                Select Case MsgBox(Inicio.Verificacionexistenciaexpediente(Year_numericupdown.Value.ToString & Organismo_numericupdown.Text & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Text), "00000")), MsgBoxStyle.YesNoCancel, " ")
                    Case MsgBoxResult.Yes
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Year_numericupdown.Text & Organismo_numericupdown.Value & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value.ToString), "00000"))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", Organismo_numericupdown.Value & "-" & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value.ToString), "00000") & "/" & Year_numericupdown.Text)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", Fechaingreso_datetimepicker.Value)
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", Detalleexpediente_textbox.Text)
                        If N_ordenpago_integerupdown.Value > 0 Then
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordenpago", N_ordenpago_integerupdown.Value & "/" & Year_ordenpago_integerupdown.Value)
                        Else
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordenpago", "")
                        End If
                        If N_ordencargo_integerupdown.Value > 0 Then
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordencargo", N_ordencargo_integerupdown.Value & "/" & Year_ordencargo_integerupdown.Value)
                        Else
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordencargo", "")
                        End If
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", 0)
                        If Yearprincipal_NumericUpDown.Value.ToString.Length = 4 And Organismoprincipal_NumericUpDown.Value.ToString.Length = 4 And IsNumeric(Numeroprincipal_NumericUpDown.Value) Then
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Claveexpteprincipal", Yearprincipal_NumericUpDown.Value & Organismoprincipal_NumericUpDown.Value & Format(Convert.ToInt32(Numeroprincipal_NumericUpDown.Value.ToString), "00000"))
                        Else
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Claveexpteprincipal", vbNull)
                        End If
                        If Exptehaberes_checkbox.Checked Then
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Haberes", 1)
                        Else
                            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Haberes", 0)
                        End If
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta_especial", Labelcuentaespecialasignada.Text)
                        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Rubro", Plan_cuentas_tesoro_textbox.Text)
                        'Expteoriginario_label.text
                        Select Case Esnuevoexpediente
                            Case True
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `expediente` " &
                    "(Clave_expediente,Expediente_N,Fecha,Detalle,Ordenpago,Ordencargo,Monto,Claveexpteprincipal,Cuenta_especial,haberes,usuario) " &
                    "VALUES (@Clave_expediente,@Expediente_N,@Fecha,@Detalle,@Ordenpago,@Ordencargo,@Monto,@Claveexpteprincipal,@Cuenta_especial,@Haberes,@usuario) "
                            Case False
                                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = " UPDATE `expediente` SET " &
                    "Expediente_N=@Expediente_N,Fecha=@Fecha,Detalle=@Detalle,Ordenpago=@Ordenpago,ordencargo=@OrdenCargo,
        Claveexpteprincipal=@Claveexpteprincipal,Cuenta_especial=@Cuenta_especial,Haberes=@haberes,Usuario=@Usuario Where Clave_expediente=@Clave_expediente"
                        End Select
                        '    'carga de partida presupuestaria
                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                        Dim pedidofondo As New PedidoFondos("0", "0")
                        '    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                        Select Case MsgBox("EXPEDIENTE GUARDADO..." & vbNewLine &
                                           "DESEA AGREGAR LOS PROVEEDORES DE ESTE EXPEDIENTE?", MsgBoxStyle.YesNoCancel, " ")
                            Case MsgBoxResult.Yes
                                Expediente_seleccionado.organismo = Organismo_numericupdown.Value
                                Expediente_seleccionado.claveexpediente = CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
                                Expediente_seleccionado.numero = Numeroexpediente_numericupdown.Value
                                Expediente_seleccionado.year = Year_numericupdown.Value
                                Expediente_seleccionado.descripcion = Detalleexpediente_textbox.Text
                                Expediente_seleccionado.fecha = Fechaingreso_datetimepicker.Value
                                Expediente_seleccionado.ordenpago = N_ordenpago_integerupdown.Value
                                Expediente_seleccionado.ordenpagoyear = Year_ordenpago_integerupdown.Value
                                Expediente_seleccionado.ordencargo = N_ordencargo_integerupdown.Value
                                Expediente_seleccionado.ordencargoyear = Year_ordencargo_integerupdown.Value
                                Expediente_seleccionado.tieneprincipal = Tieneexpteprincipal_checkbox.Checked
                                Expediente_seleccionado.Asignarcuentaespecial = Labelcuentaespecialasignada.Text
                                Expediente_seleccionado.principalorganismo = Organismoprincipal_NumericUpDown.Value
                                Expediente_seleccionado.principalnumero = Numeroprincipal_NumericUpDown.Value
                                Expediente_seleccionado.haberes = Exptehaberes_checkbox.Checked
                                If Expediente_seleccionado.principalyear > 1999 Then
                                    Yearprincipal_NumericUpDown.Value = Expediente_seleccionado.principalyear
                                Else
                                    Yearprincipal_NumericUpDown.Value = Date.Now.Year
                                End If
                                Expediente_seleccionado.cuentaespecial = Labelcuentaespecialasignada.Text
                                Expediente_seleccionado.principaldescripcion = Detalleprincipal_textbox.Text
                                cargadatosproveedores()
                                If Exptehaberes_checkbox.Checked = False Then
                                    Cuit_Expedientes.Asociarcuit(Expediente_seleccionado, Proveedores_datagrid, Montodelexpediente_textbox)
                                Else
                                    Cuit_Expedientes.Asociarcuit(Expediente_seleccionado, Proveedores_datagrid, Montodelexpediente_textbox, 1)
                                End If
                                'Cuit_Expedientes.Asociarcuit(CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long), Proveedores_datagrid, Montodelexpediente_textbox)
                                Tesoreria_Expedientes.refreshgeneral()
                                ' Dim expediente_nuevo As Expediente
                                'volver todos los valores a cero 0
                                With Expediente_seleccionado
                                    .organismo = 0
                                    .numero = 0
                                    .year = 0
                                    .monto = 0
                                    .fecha = Date.Now.Date
                                    .descripcion = ""
                                    .ordenpago = 0
                                    .ordenpagoyear = Date.Now.Year
                                    .ordencargo = 0
                                    .ordencargoyear = Date.Now.Year
                                    .tieneprincipal = False
                                    .principalorganismo = 0
                                    .principalnumero = 0
                                    .principalyear = Date.Now.Year
                                    .principaldescripcion = ""
                                    .cuentaespecial = ""
                                End With
                                'General_cargaexpediente()
                                General_cargaexpediente(Expediente_seleccionado, Me.BackColor)
                        'RaiseEvent Aceptar()
                            Case MsgBoxResult.No
                                Detalleexpediente_textbox.Select()
                            Case MsgBoxResult.Cancel
                                Detalleexpediente_textbox.Select()
                        End Select
                        If pedidofondo.Existe_pedidofondo(Pedidofondo_numero.Value, Pedidofondo_year.Value) Then
                        Else
                            Select Case MsgBox("No existe el pedido de fondo seleccionado " & Pedidofondo_numero.Value & "/" & Pedidofondo_year.Value & "Desea crear este pedido de fondo y asociar los proveesodres y movimientos al mismo?", MsgBoxStyle.YesNoCancel, " ")
                                Case MsgBoxResult.Yes
                                Case MsgBoxResult.No
                                Case MsgBoxResult.Cancel
                            End Select
                        End If
                End Select
            Else
                MessageBox.Show("Compruebe en el formulario los datos que ha ingresado")
            End If
        Else
            For x = 0 To Errores.Count - 1
                If Not (Errores(x) = "") Then
                    Total_errores = Total_errores & vbCrLf & "-" & Errores(x)
                End If
            Next
            MessageBox.Show("El expediente no se puede cargar por contener los siguiente errores " & vbCrLf & Total_errores)
            Detalleexpediente_textbox.Select()
        End If
    End Sub

    Private Sub Tieneexpteprincipal_checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles Tieneexpteprincipal_checkbox.CheckedChanged
        Select Case Tieneexpteprincipal_checkbox.Checked
            Case True
                Me.Height += (Panelexpteprincipal.Height + 12)
                Panelexpteprincipal.Visible = True
            Case False
                Me.Height = Me.Height - (Panelexpteprincipal.Height + 12)
                Panelexpteprincipal.Visible = False
        End Select
    End Sub

    Private Sub BotonCUITS_Click(sender As Object, e As EventArgs) Handles BotonCUITS.Click
        'CType(Year_numericupdown.Value.ToString & Organismo_numericupdown.Value.ToString & Format(Convert.ToInt32(Numeroexpediente_numericupdown.Value), "00000"), Long)
        If Exptehaberes_checkbox.Checked = False Then
            Cuit_Expedientes.Asociarcuit(Expediente_seleccionado, Proveedores_datagrid, Montodelexpediente_textbox)
        Else
            Cuit_Expedientes.Asociarcuit(Expediente_seleccionado, Proveedores_datagrid, Montodelexpediente_textbox, 1)
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Montodelexpediente_textbox_MouseHover(sender As Object, e As EventArgs) Handles Montodelexpediente_textbox.MouseHover
        Inicio.TOOLTIPS(sender, "El monto del expediente es la suma de lo solicitado por los proveedores en el expediente")
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Label_expedienteasociados_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_expedienteasociados.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Asignarcuentaespecial_boton.Click
        ' Expediente_seleccionado.Cambiar_expediente(Expediente_seleccionado.claveexpediente)
        DialogDialogo_Datagridview.Carga_General(Autocompletetables.Cuentas, "Seleccione la cuenta a ser asignada", "Asignar Cuenta Especial", "Borrar asignación")
        '  Dialogo_listbox.Cargalistboxgeneral(listadecuentasbancarias, "Seleccione la cuenta a ser asignada", "Asignar Cuenta Especial", "Borrar asignación")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Labelcuentaespecialasignada.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
        Else
            Labelcuentaespecialasignada.Text = ""
        End If
    End Sub

    Private Sub Asignar_rubro_boton_Click(sender As Object, e As EventArgs)
        DialogDialogo_Datagridview.Carga_General(Autocompletetables.Plan_Cuenta_Tesoro, "Seleccione el código a ser asignado", "Seleccionar código", "Cancelar")
        '  Dialogo_listbox.Cargalistboxgeneral(listadecuentasbancarias, "Seleccione la cuenta a ser asignada", "Asignar Cuenta Especial", "Borrar asignación")
    End Sub

    Private Sub Label_expedienteasociados_Click(sender As Object, e As EventArgs) Handles Label_expedienteasociados.Click
    End Sub

    Private Sub Pedidof_ValueChanged(sender As Object, e As EventArgs) Handles Pedidofondo_year.ValueChanged
    End Sub

End Class