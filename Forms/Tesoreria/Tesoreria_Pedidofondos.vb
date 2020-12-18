Imports System.IO
Imports System.Threading

Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class Tesoreria_Pedidofondos
    Dim pedidofondos_datatable As New DataTable
    Dim Expedientesasociados_datatable As New DataTable
    Dim Expedientenoasociados_datatable As New DataTable
    Dim busquedasqlasociada As String = ""
    Dim busquedasqlnoasociada As String = ""
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False
    Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    Dim activartimer As Boolean = False
    Dim Datospedidosfondos_datatable As New DataTable
    Dim Datagridseleccionado As New DataGridView
    Dim Tiempoconsulta As New Windows.Threading.DispatcherTimer()
    Dim pedfondoseleccionado As PedidoFondos

    Private Sub Consulta_tick(ByVal sender As Object, ByVal e As EventArgs)
        'iniciar busqueda de datos
        Inicio.OBJETOCARGANDO(splitContainerGeneral.Panel2, Me, "Cargando datos...",, New Point(0, splitContainerGeneral.SplitterDistance))
        Cargadedatos()
        Inicio.OBJETOFINALIZAR(splitContainerGeneral.Panel2, Me)
        'mostrar en pantalla
        'apagar timer
        'freno de mano al timer
        Tiempoconsulta.Stop()
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
        Buscar_datagrid_TIMER(sender, pedidofondos_datatable, Datosspedidofondo_datagridview)
        ''  DispatcherTimer setup
        ''color para mostrar que se ha activado el proceso de busqueda
        'Busqueda.BackColor = Color.Yellow
        'activartimer = True
        'RemoveHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'AddHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'Tiempodetecleo.Interval = TimeSpan.FromMilliseconds(300)
        '' = New TimeSpan(0, 0, 1)
        'Tiempodetecleo.Start()
    End Sub

    Private Sub Pedidofondos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Inicio.recargardatosprincipales()
        ''Inicio.Colorearobjetos(Boton_aceptar, Boton_aceptar.Text.ToUpper)
        ''Inicio.Colorearobjetos(Boton_modificar, Boton_modificar.Text.ToUpper)
        ''Inicio.Colorearobjetos(Boton_borrar, Boton_borrar.Text.ToUpper)
        '  Inicio.Cargadetextboxautcompleteonload(Clasefondo_textbox, Autocompletetables.Clasefondo)
        '' Inicio.Cargadetextboxautcompleteonload(Cuenta_pedidofondo_textbox, Autocompletetables.Cuentas)
        '' Inicio.Cargadetextboxautcompleteonload(Organismo_textbox, Autocompletetables.Organismos)
        'Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
        Panelnuevopedido.Enabled = False
        'Inicio.Fondosplittercolor(SplitContainer2)
        Inicio.Fondosplittercolor(SplitContainer3)
        Inicio.Fondosplittercolor(splitContainerGeneral)
    End Sub

    Private Sub Pedidofondos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Inicio.Recargardatosprincipales()
        Inicio.Cargadetextboxautcompleteonload(Clasefondo_textbox, Clasefondo)
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Cuentas, "Cuenta", "Descripcion")
    End Sub

    'Valores unicamente validos para la pantalla de PEDIDO DE FONDOS, el menu se compone de opciones básicas y se agrega la posibilidad Modificar datos del Pedido de fondos.
    Private Sub Mousederecho_PedidoFondos(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As DataGridView)
        Datagridseleccionado = Nothing
        If MOUSE.Button <> MouseButtons.Right Then Return
        Datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf MenuContextual_PedidoFondos
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf MenuContextual_PedidoFondos
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf MenuContextual_PedidoFondos
        Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf MenuContextual_PedidoFondos
        Dim item5 = cms.Items.Add("Modificar Pedido de Fondos")
        item5.Tag = 4
        AddHandler item5.Click, AddressOf MenuContextual_PedidoFondos
        'Dim item3 = cms.Items.Add("VERIFICAR ADICIONALES")
        'item3.Tag = 2
        'AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        '-- etc
        '..
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub MenuContextual_PedidoFondos(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Clipboard.SetDataObject(Datagridseleccionado.GetClipboardContent())
                Dim objData As DataObject = Datagridseleccionado.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(Datagridseleccionado)
                'Select Case Datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(Datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(Datagridseleccionado)
                '    Case Else
                '        Exportaraexceltest(Datagridseleccionado)
                'End Select
                'MessageBox.Show(datagridseleccionado.GetType.ToString)
                'Select Case
                '    Case Is = "Datagridview"
                '        Exportaraexceltest(datagridseleccionado)
                'End Select
            Case Is = 2
                'Reportesgenerales.ExportDataToPDFTable2(datagridseleccionado, "Reporte Rapido")
                'Reportesgenerales.PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
                'PDFDatagridview()
            Case Is = 3
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 4
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                modificarpedidofondos()
        End Select
    End Sub

    Private Sub Mousederecho_Expedientesasociados(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As DataGridView)
        Datagridseleccionado = Nothing
        If MOUSE.Button <> MouseButtons.Right Then Return
        Datagridseleccionado = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf MenuContextual_Expedientesasociados
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf MenuContextual_Expedientesasociados
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf MenuContextual_Expedientesasociados
        Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf MenuContextual_Expedientesasociados
        If Datagridseleccionado.SelectedRows.Count > 0 Then
            Dim item5 = cms.Items.Add("Modificar Rubro")
            item5.Tag = 4
            AddHandler item5.Click, AddressOf MenuContextual_Expedientesasociados
        End If
        'Dim item3 = cms.Items.Add("VERIFICAR ADICIONALES")
        'item3.Tag = 2
        'AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        '-- etc
        '..
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub MenuContextual_Expedientesasociados(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Clipboard.SetDataObject(Datagridseleccionado.GetClipboardContent())
                Dim objData As DataObject = Datagridseleccionado.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(Datagridseleccionado)
                'Select Case Datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(Datagridseleccionado)
                '    Case Is = "SICYF.FLICKER_DATAGRIDVIEW"
                '        Exportaraexceltest(Datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(Datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(Datagridseleccionado.GetType.ToString)
                'End Select
                'MessageBox.Show(datagridseleccionado.GetType.ToString)
                'Select Case
                '    Case Is = "Datagridview"
                '        Exportaraexceltest(datagridseleccionado)
                'End Select
            Case Is = 2
                'Reportesgenerales.ExportDataToPDFTable2(datagridseleccionado, "Reporte Rapido")
                'Reportesgenerales.PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", True, "LEGAL")
                'PDFDatagridview()
            Case Is = 3
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(Datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 4
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                Asignar_rubro()
        End Select
    End Sub

    Private Sub Asignar_rubro()
        Dim casos As New List(Of String)
        Dim rubros As New List(Of String)
        Dim textobuscador As String = ""
        casos.Add("HABERES")
        rubros.Add("11-200")
        casos.Add("OBRA SOCIAL AP. ESTATAL")
        rubros.Add("11-290")
        casos.Add("OBRA SOCIAL AP. PERSONAL")
        rubros.Add("11-210")
        casos.Add("PETICIÓN DE ALIMENTOS")
        rubros.Add("11-260")
        casos.Add("UPCN")
        rubros.Add("11-141")
        casos.Add("ATE")
        rubros.Add("11-142")
        casos.Add("SEGURO OBLIG.NACIÓN")
        rubros.Add("11-581")
        casos.Add("TARJETA NATURAL")
        rubros.Add("11-113")
        casos.Add("FED MUT CUOTA SOCIAL")
        rubros.Add("11-113")
        casos.Add("EMBARGOS")
        rubros.Add("11-113")
        casos.Add("FED. MUT. MISIONES")
        rubros.Add("11-113")
        casos.Add("SEGURO OBLIG. NACIÓN")
        rubros.Add("11-170")
        casos.Add("IPRODHA")
        rubros.Add("11-157")
        casos.Add("IMPUESTO GANANCIAS")
        rubros.Add("11-155")
        casos.Add("SEGURO SEPELIO NACIÓN")
        rubros.Add("11-581")
        casos.Add("PRESTA FACIL")
        rubros.Add("11-113")
        For X = 0 To casos.Count - 1
            If Datagridseleccionado.SelectedRows(0).Cells.Item("DETALLE").Value.ToString.ToUpper.Contains(casos(X)) Then
                textobuscador = rubros(X)
                Exit For
            End If
        Next
        DialogDialogo_Datagridview.Carga_General(Plan_Cuenta_Tesoro, "Seleccione el código a ser asignado", "Seleccionar código", "Cancelar",,, textobuscador)
        Dim Rubro As String = ""
        '  Dialogo_listbox.Cargalistboxgeneral(listadecuentasbancarias, "Seleccione la cuenta a ser asignada", "Asignar Cuenta Especial", "Borrar asignación")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Rubro = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
            For x = 0 To Datagridseleccionado.SelectedRows.Count - 1
                Datagridseleccionado.SelectedRows(x).Cells.Item("Rubro").Value = Rubro
            Next
        Else
            For x = 0 To Datagridseleccionado.SelectedRows.Count - 1
                Datagridseleccionado.SelectedRows(x).Cells.Item("Rubro").Value = ""
            Next
        End If
    End Sub

    Private Sub modificarpedidofondos()
        ' If Cantidad_Movimientos_pedidofondo(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value) = 0 Then
        Dim pedfondo As New PedidoFondos(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString, Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Numero de Expediente").Value)
        pedfondo.N_PedidoFondo = pedfondo.N_PedidoFondo
        pedfondo.YearPedidoFondo = pedfondo.YearPedidoFondo
        pedfondo.Fecha_Pedido = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Fecha_pedido").Value
        pedfondo.Cuenta_PedidoFondo = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Cuenta_pedidofondo").Value
        pedfondo.ExpteOrganismo = pedfondo.ExpteOrganismo
        pedfondo.ExpteNumero = pedfondo.ExpteNumero
        pedfondo.ExpteYear = pedfondo.ExpteYear
        pedfondo.Descripcion = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Descripcion").Value
        pedfondo.Clase_fondo = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("clase_fondo").Value
        pedfondo.Parcial = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Parcial").Value
        pedfondo.Haberes = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Haberes").Value
        Dialogo_nuevopedidofondo.General_cargapedidofondo(pedfondo, Me, False)
        '
        '     Else
        '          'Cambiar a una info que devuelva los expedientes dentro del pedido de fondo.
        '     MessageBox.Show("Actualmente este pedido de fondos registra movimiento en alguno de los expedientes que lo componen")
        '     End If
    End Sub

    Private Sub Tiempodetecleo_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case activartimer
            Case True
                Busqueda.Enabled = False
                Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
                refreshnow()
                Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
                'freno de mano al timer
                Tiempodetecleo.Stop()
                'color para mostrar que ha finalizado el proceso de busqueda
                Busqueda.BackColor = Color.White
                'liberación del control
                Busqueda.Enabled = True
                'selección del control
                Busqueda.Select()
                activartimer = False
            Case False
        End Select
    End Sub

    Private Sub N_pedidofondo_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles N_pedidofondo_numeric.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Year_pedidofondo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.Verificar(sender, sender.text, "YEAR")
    End Sub

    Private Sub Beneficiario_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Descripcion_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Monto_solicitado_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.Verificar(sender, sender.text, "NUMERICO")
    End Sub

    Private Sub N_ordenpagocargo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.controldeguiones(Me, sender, e)
        '  Inicio.Verificar(sender, sender.text, "NUMERICO")
    End Sub

    Private Sub Year_ordenpagocargo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.Verificar(sender, sender.text, "YEAR")
    End Sub

    Private Sub Fecha_solicitud_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.Verificar(sender, sender.text, "FECHA")
    End Sub

    Private Sub Clasefondo_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Clasefondo_textbox.KeyDown
        Select Case e.KeyCode = Keys.Enter
            Case True
                ' Guardarcambios_boton.Select()
            Case Else
        End Select
    End Sub

    Private Sub Organismo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.controldeguiones(Me, sender, e)
        Inicio.Verificar(sender, sender.text, "NUMERICO")
    End Sub

    Private Sub Expte_numero_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.controldeguiones(Me, sender, e)
        '      Inicio.Verificar(sender, sender.text, "NUMERICO")
    End Sub

    Private Sub Year_expediente_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
        Inicio.Verificar(sender, sender.text, "YEAR")
    End Sub

    Private Sub Cuenta_pedidofondo_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Cargadedatos()
        BusquedaexpedientesNOasociados_textbox.Text = ""
        Busquedaexpedientesasociados_textbox.Text = ""
        pedfondoseleccionado = New PedidoFondos(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString, (Autorizaciones.Year.ToString & Autorizaciones.Organismo.ToString & "00000"))
        pedfondoseleccionado.CargarDatos(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString)
        Organismo_textbox.Text = pedfondoseleccionado.ExpteOrganismo
        Expte_numero_numericupdown.Value = pedfondoseleccionado.ExpteNumero
        Year_expediente_textbox.Text = pedfondoseleccionado.ExpteYear
        pedfondoseleccionado.Datospedidofondos_datatable = CType(Expedientesasociados_datagridview.DataSource, DataTable)
        Try
            pedfondoseleccionado.Descripcion = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Descripcion").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            pedfondoseleccionado.Clase_fondo = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CLASE_FONDO").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            pedfondoseleccionado.Parcial = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Parcial").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            pedfondoseleccionado.Haberes = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("haberes").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Guardarcambios_boton.Visible = False
        Select Case Datosspedidofondo_datagridview.SelectedRows.Count = 1
            Case True
                '   If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value = 0 Then
                Expedientesasociados_datagridview.AllowUserToAddRows = False
                Expedientesasociados_datagridview.AllowUserToDeleteRows = False
                Expedientesasociados_datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Expedientesasociados_datagridview.EditMode = DataGridViewEditMode.EditOnF2
                Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Parcial").Value = 1
                    Case True
                        Expedientesasociados_datagridview.ReadOnly = False
                        'agregado el 20/07/2020
                        Expedientesasociados_datagridview.SelectionMode = DataGridViewSelectionMode.CellSelect
                        'en caso de que el pedido de fondos sea parcial con respecto al expediente y esta relacionad por CUITs del proveedor dentro del pedido.
                        Label_expedienteasociados.Text = "Busqueda de CUIT asociados al pedido de fondo"
                    Case False
                        Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1 = False
                        Expedientesasociados_datagridview.ReadOnly = True
                        'Caso de que el expediente tenga el formato tradicional de asociación por expediente.
                        Label_expedienteasociados.Text = "Busqueda de expedientes en el pedido de fondo"
                End Select
                Labelexpedientessinasociar.Text = "Busqueda de expedientes SIN PEDIDO DE FONDO ASIGNADO"
                COMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value)
                Inicio.SQLPARAMETROS(Organismotabla, "SELECT Clave_pedidofondo,N_pedidofondo,Year_pedidofondo,Monto_pedidofondo as `Monto_pedidofondo`,
Cuenta_pedidofondo,Expediente_N,Descripcion,Fecha_pedido,Clase_fondo from pedido_fondos where clave_pedidofondo=@clave_pedidofondo", Datospedidosfondos_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                N_pedidofondo_numeric.Value = Datospedidosfondos_datatable.Rows(0).Item("N_pedidofondo").ToString
                Year_pedidofondo_numeric.Value = Datospedidosfondos_datatable.Rows(0).Item("Year_pedidofondo")
                If IsDBNull(Datospedidosfondos_datatable.Rows(0).Item("Monto_pedidofondo")) Then
                    Pedidodefondosmontowpf.Monto_textbox.Number = 0
                Else
                    Select Case Decimal.TryParse(Datospedidosfondos_datatable.Rows(0).Item("Monto_pedidofondo").ToString, Pedidodefondosmontowpf.Monto_textbox.Number)
                        Case True
                            Pedidodefondosmontowpf.Monto_textbox.Number = Convert.ToDecimal(Datospedidosfondos_datatable.Rows(0).Item("Monto_pedidofondo").ToString)
                        Case False
                            Pedidodefondosmontowpf.Monto_textbox.Number = 0
                    End Select
                End If
                If Not IsDBNull(Datospedidosfondos_datatable.Rows(0).Item("Fecha_pedido")) Then
                    Fecha_pedido_textbox.Value = CType(Datospedidosfondos_datatable.Rows(0).Item("Fecha_pedido"), Date)
                Else
                    Fecha_pedido_textbox.Value = Date.Now
                End If
                Clasefondo_textbox.Text = Datospedidosfondos_datatable.Rows(0).Item("Clase_fondo").ToString
                refreshexpedientes()
                Quitarasociacion_boton.Enabled = True
                Asociarexpediente_boton.Enabled = True
                Boton_borrar.Enabled = True
                Boton_Modificar.Visible = True
                SplitContainer3.Visible = True
                Verexpedientesasociados("")
            Case False
                SplitContainer3.Visible = False
        End Select
    End Sub

    Private Sub Datoscuenta_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosspedidofondo_datagridview.CellEnter
        SplitContainer3.Visible = False
        Select Case sender.SelectedRows.Count = 1
            Case True
                ' DispatcherTimer setup
                Inicio.Label_EJERCICIOFINANCIERO.Text = ""
                SplitContainer3.Visible = True
                RemoveHandler Tiempoconsulta.Tick, AddressOf Consulta_tick
                AddHandler Tiempoconsulta.Tick, AddressOf Consulta_tick
                Tiempoconsulta.Interval = TimeSpan.FromMilliseconds(120)
                ' = New TimeSpan(0, 0, 1)
                Tiempoconsulta.Start()
            Case False
                SplitContainer3.Visible = False
        End Select
    End Sub

    Private Sub Verexpedientesasociados(ByVal Ver As String)
        Select Case Datosspedidofondo_datagridview.SelectedRows.Count
            Case = 1
                Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("impreso").Value
                    Case True
                        Select Case SplitContainer3.Visible
                            Case True
                             '   SplitContainer3.Visible = False
                               ' sender.text = "VER EXPEDIENTES ASOCIADOS"
                            Case False
                                '    SplitContainer3.Visible = True
                                ' sender.text = "OCULTAR EXPEDIENTES ASOCIADOS"
                                Inicio.OBJETOCARGANDO(SplitContainer3, Me, "cargando expedientes relacionados")
                                refreshexpedientes()
                                Inicio.OBJETOFINALIZAR(SplitContainer3, Me)
                        End Select
                        'Quitarasociacion_boton.Enabled = False
                        'Asociarexpediente_boton.Enabled = False
                    Case False
                        Select Case SplitContainer3.Visible
                            Case True
                           '     SplitContainer3.Visible = False
                             '   sender.text = "VER EXPEDIENTES ASOCIADOS"
                            Case False
                                '  SplitContainer3.Visible = True
                                '    sender.text = "OCULTAR EXPEDIENTES ASOCIADOS"
                                Inicio.OBJETOCARGANDO(SplitContainer3, Me, "cargando expedientes relacionados")
                                refreshexpedientes()
                                Inicio.OBJETOFINALIZAR(SplitContainer3, Me)
                        End Select
                        Quitarasociacion_boton.Enabled = True
                        Asociarexpediente_boton.Enabled = True
                    Case Else
                        Select Case Ver
                            Case "NUEVO"
                                'Quitarasociacion_boton.Enabled = False
                                'Asociarexpediente_boton.Enabled = False
                            Case Else
                                MessageBox.Show(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("impreso").Value)
                        End Select
                End Select
            Case Else
                Select Case Ver
                    Case "NUEVO"
                        'Quitarasociacion_boton.Enabled = False
                        'Asociarexpediente_boton.Enabled = False
                        refreshexpedientes()
                    Case Else
                        MessageBox.Show("Debe SELECCIONAR un pedido de fondos para obtener el detalle")
                End Select
        End Select
    End Sub

    Private Sub Quitarasociacion_parcial()
        Dim sumaexpedientes As Decimal = Convert.ToDecimal(0.00)
        'Clave_expediente
        For X = 0 To Expedientesasociados_datagridview.SelectedRows.Count - 1
            INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("CUIT").Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            '   SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", DBNull.Value)
            INSERTCOMMANDSQL.CommandText = "DELETE FROM CUIT_Movimiento  WHERE Clave_expediente=@Clave_expediente AND Cuit=@CUIT;"
            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        Next
    End Sub

    Private Sub Quitarasociacion_completo()
        Dim sumaexpedientes As Decimal = Convert.ToDecimal(0.00)
        'Clave_expediente
        '   If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("EXPEDIENTES").Value > 0 Then
        'Caso en el que el pedido de fondo contenga Cuit asociados
        For X = 0 To Expedientesasociados_datagridview.SelectedRows.Count - 1
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", DBNull.Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", DBNull.Value)
            INSERTCOMMANDSQL.CommandText = "UPDATE `expediente` SET Clave_pedidofondo=@Clave_pedidofondo,Usuario=@Usuario WHERE Clave_expediente=@Clave_expediente;"
            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
            '  INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", DBNull.Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@RUBRO", DBNull.Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("CUIT").Value)
            ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", DBNull.Value)
            INSERTCOMMANDSQL.CommandText = " UPDATE `CUIT_EXPEDIENTE` SET RUBRO=@RUBRO,Usuario=@Usuario WHERE Clave_expediente=@Clave_expediente AND CUIT=@CUIT;"
            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("CUIT").Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            INSERTCOMMANDSQL.CommandText = "DELETE FROM CUIT_Movimiento  WHERE Clave_expediente=@Clave_expediente AND Cuit=@CUIT;"
            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        'Else
        '    'Caso de Expedientes relacionados unicamente en MFyV
        '    For X = 0 To Expedientesasociados_datagridview.SelectedRows.Count - 1
        '        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", DBNull.Value)
        '        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
        '        ' SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", DBNull.Value)
        '        INSERTCOMMANDSQL.CommandText = "UPDATE `expediente` SET Clave_pedidofondo=@Clave_pedidofondo,Usuario=@Usuario WHERE Clave_expediente=@Clave_expediente;"
        '        Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        '    Next
        'End If
    End Sub

    Private Sub Quitarasociacion_boton_Click(sender As Object, e As EventArgs) Handles Quitarasociacion_boton.Click
        Select Case MsgBox("Confirma que desea quitar de este pedido lo seleccionado? " & N_pedidofondo_numeric.Value, MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                splitContainerGeneral.SuspendLayout()
                Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
                    Case True
                        Quitarasociacion_parcial()
                    Case False
                        Quitarasociacion_completo()
                End Select
                'refreshexpedientes()
                'For x = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                '    sumaexpedientes = sumaexpedientes + Convert.ToDecimal(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO2").Value)
                'Next
                INSERTCOMMANDSQL.Parameters.AddWithValue("@sumaexpedientes", sumaasociada)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_expediente_textbox.Text & Organismo_textbox.Text & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
                INSERTCOMMANDSQL.CommandText = "UPDATE `pedido_fondos` SET Monto_pedidofondo=@sumaexpedientes,Usuario=@Usuario WHERE Clave_pedidofondo=@Clave_pedidofondo;"
                Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                'ACTUALIZACIÓN DE MONTO EN EXPEDIENTE DE PEDIDO DE FONDO
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Year_expediente_textbox.Text & Organismo_textbox.Text & Format(Convert.ToInt32(Expte_numero_numericupdown.Value), "00000"))
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", sumaasociada)
                INSERTCOMMANDSQL.CommandText = "UPDATE `expediente` SET Monto=@Monto,Usuario=@Usuario WHERE Clave_expediente=@Clave_expediente;"
                Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Monto_pedidofondo").Value = sumaasociada()
                Inicio.OBJETOCARGANDO(SplitContainer3, Me, "cargando expedientes relacionados")
                refreshexpedientes()
                Inicio.OBJETOFINALIZAR(SplitContainer3, Me)
            Case MsgBoxResult.No
            Case MsgBoxResult.Cancel
        End Select
    End Sub

    Private Function sumaasociada() As Decimal
        Dim sumaexpedientes As Decimal = 0
        For x = 0 To Expedientesasociados_datagridview.Rows.Count - 1
            'If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value > 0 Then
            '    If Not IsDBNull(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value) Or (Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value = Nothing) Then
            '        If Regex.IsMatch(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value.ToString, "^[+-]?([0-9]{1,3}(\.[0-9]{3})*(\,[0-9]+)?|\d*\.\d+|\d+)$") Then
            '            sumaexpedientes += CDec(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value)
            '        Else
            '            S_to_dec(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value)
            '        End If
            '    End If
            'Else
            sumaexpedientes += Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value
            'If Not Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value.ToString = "" Then
            '    sumaexpedientes = sumaexpedientes + CDec(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO2").Value)
            'End If
            '   End If
        Next
        Return sumaexpedientes
    End Function

    Private Sub Asociarexpediente_boton_Click(sender As Object, e As EventArgs) Handles Asociarexpediente_boton.Click
        'Clave_expediente
        Select Case MsgBox("Confirma que desea asociar los expedientes seleccionados al Pedido de fondo N" & N_pedidofondo_numeric.Value, MsgBoxStyle.YesNo, " ")
            Case MsgBoxResult.Yes
                splitContainerGeneral.SuspendLayout()
                Inicio.OBJETOCARGANDO(SplitContainer3, Me, "cargando expedientes relacionados")
                Select Case N_pedidofondo_numeric.Value > 0
                    Case True
                        '----------------------------------------------------------------------
                        Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
                            Case True
                                'CARGA DE PEDIDO DE FONDO PARCIAL
                                asociarparcial()
                            Case False
                                'CARGA DE PEDIDO DE FONDO COMPLETO
                                asociarcompleto()
                        End Select
                        '----------------------------------------------------------------------
                    Case False
                        MessageBox.Show("No se registra numero de pedido de fondos.")
                End Select
                Inicio.OBJETOFINALIZAR(SplitContainer3, Me)
            Case MsgBoxResult.No
        End Select
    End Sub

    Private Sub asociarparcial()
        For X = 0 To ExpedientesNOasociados_datagridview.SelectedRows.Count - 1
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Organismo & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", ExpedientesNOasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@DETALLE", "PEDIDO DE FONDOS Nº " & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000") & "/" & Year_pedidofondo_numeric.Value)
            INSERTCOMMANDSQL.CommandText = "INSERT INTO CUIT_MOVIMIENTO (	MD5HASH, CUIT, Monto, Detalle, Clave_expediente, Clave_pedidofondo,Usuario)	SELECT
MD5(CONCAT(CUIT,@Clave_pedidofondo,@Clave_expediente)),CUIT,0,@DETALLE, @Clave_expediente, @Clave_pedidofondo,@Usuario FROM CUIT_EXPEDIENTE WHERE CLAVE_EXPEDIENTE = @Clave_expediente
 ON DUPLICATE KEY UPDATE DETALLE=@DETALLE,Usuario=@Usuario;"
            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        INSERTCOMMANDSQL.Parameters.AddWithValue("@sumaexpedientes", sumaasociada)
        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Organismo & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
        INSERTCOMMANDSQL.CommandText = "UPDATE `pedido_fondos` SET Monto_pedidofondo=@sumaexpedientes,Usuario=@Usuario WHERE Clave_pedidofondo=@Clave_pedidofondo;"
        Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        refreshexpedientes()
        Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Monto_pedidofondo").Value = sumaasociada()
    End Sub

    Private Sub asociarcompleto()
        For X = 0 To ExpedientesNOasociados_datagridview.SelectedRows.Count - 1
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Organismo & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", ExpedientesNOasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@DETALLE", ExpedientesNOasociados_datagridview.SelectedRows(X).Cells.Item("Detalle").Value)
            INSERTCOMMANDSQL.CommandText = "INSERT INTO CUIT_MOVIMIENTO (MD5HASH, CUIT, Monto, Detalle, Clave_expediente, Clave_pedidofondo,Usuario) SELECT
MD5(CONCAT(CUIT,@Clave_pedidofondo,@Clave_expediente)),CUIT,MONTO,@DETALLE, @Clave_expediente, @Clave_pedidofondo,@Usuario FROM CUIT_EXPEDIENTE WHERE CLAVE_EXPEDIENTE= @Clave_expediente
 ON DUPLICATE KEY UPDATE DETALLE=@DETALLE,Clave_pedidofondo=@Clave_pedidofondo,Usuario=@Usuario;"
            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", ExpedientesNOasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE `expediente` SET Clave_pedidofondo=@Clave_pedidofondo,Usuario=@Usuario WHERE Clave_expediente=@Clave_expediente;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        refreshexpedientes()
        INSERTCOMMANDSQL.Parameters.AddWithValue("@sumaexpedientes", sumaasociada)
        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Organismo & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
        INSERTCOMMANDSQL.CommandText = "UPDATE `pedido_fondos` SET Monto_pedidofondo=@sumaexpedientes,Usuario=@Usuario WHERE Clave_pedidofondo=@Clave_pedidofondo;"
        Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        refreshexpedientes()
        Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Monto_pedidofondo").Value = sumaasociada()
    End Sub

    Private Sub Asociarhaberes()
        For X = 0 To ExpedientesNOasociados_datagridview.SelectedRows.Count - 1
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Organismo & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", ExpedientesNOasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            INSERTCOMMANDSQL.Parameters.AddWithValue("@DETALLE", "PEDIDO DE FONDOS Nº " & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000") & "/" & Year_pedidofondo_numeric.Value)
            INSERTCOMMANDSQL.CommandText = "INSERT INTO HABERES_MOVIMIENTOS (MD5HASH, CUIT, Monto, Detalle, Clave_expediente, Clave_pedidofondo,Usuario) SELECT
MD5(CONCAT(CUIT,@Clave_pedidofondo,@Clave_expediente)),CUIT,MONTO,@DETALLE, @Clave_expediente, @Clave_pedidofondo,@Usuario FROM CUIT_EXPEDIENTE WHERE CLAVE_EXPEDIENTE= @Clave_expediente
 ON DUPLICATE KEY UPDATE DETALLE=@DETALLE,Clave_pedidofondo=@Clave_pedidofondo,Usuario=@Usuario;"
            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.ToString.Substring(0, 4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", ExpedientesNOasociados_datagridview.SelectedRows(X).Cells.Item("Clave_expediente").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE `expediente` SET Clave_pedidofondo=@Clave_pedidofondo,Usuario=@Usuario WHERE Clave_expediente=@Clave_expediente;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        refreshexpedientes()
        INSERTCOMMANDSQL.Parameters.AddWithValue("@sumaexpedientes", sumaasociada)
        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Organismo & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
        INSERTCOMMANDSQL.CommandText = "UPDATE `pedido_fondos` SET Monto_pedidofondo=@sumaexpedientes,Usuario=@Usuario WHERE Clave_pedidofondo=@Clave_pedidofondo;"
        Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        refreshexpedientes()
        Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Monto_pedidofondo").Value = sumaasociada()
    End Sub

    Private Sub Pedidofondos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Inicio.OBJETOCARGANDO(SplitContainer2.Panel1, Me, "Cargando Pedidos de fondos")
        refreshnow()
        'Inicio.OBJETOFINALIZAR(SplitContainer2.Panel1, Me)
    End Sub

    Private Sub borradoanuevo()
        N_pedidofondo_numeric.Value = 0
        Year_pedidofondo_numeric.Value = Date.Now.Year
        Descripcion_textbox.Text = ""
        Pedidodefondosmontowpf.Monto_textbox.Number = Convert.ToDecimal(0.00)
        'N_ordenpagocargo_textbox.Value = 0
        'Year_ordenpagocargo_textbox.Text = Date.Now.Year.ToString
        Fecha_pedido_textbox.Value = Date.Now
        Clasefondo_textbox.Text = ""
        Organismo_textbox.Text = Organismo
        Expte_numero_numericupdown.Value = 0
        Year_expediente_textbox.Text = Date.Now.Year.ToString
    End Sub

    Public Sub refreshnow()
        ' COMMANDSQL.Parameters.AddWithValue("@busquedalike", "%" & Busqueda.Text & "%")
        '        Select Case Busqueda.Text.Length > 0
        '            Case True
        '            Case False
        '                Inicio.SQLPARAMETROS(Organismotabla, "SELECT Concat(N_pedidofondo,'/',Year_pedidofondo) AS 'Pedido de fondos',A.fecha_pedido,
        'A.descripcion,
        '	Monto_pedidofondo AS `Monto_pedidofondo`,
        '	Cuenta_pedidofondo,B.descripcion as Cuentadescripcion,
        '	Expediente_N AS 'Numero de Expediente',Clase_fondo,
        '	IMPRESO,A.Clave_pedidofondo,B.Caracter,G.Expedientes as 'Expedientes',Parcial,Haberes,
        'G.MOVIMIENTOS,
        'G.CUITS FROM
        '(Select * FROM Pedido_fondos)A
        'inner JOIN
        '(Select e.Clave_expediente,
        'CASE WHEN Expedientes >0  then Expedientes else 0 END as Expedientes,
        'CASE WHEN cuits >0  then CUITS else 0 END as CUITS,e.clave_pedidofondo,
        'CASE WHEN C.Movimientos >0  then C.Movimientos else 0 END as MOVIMIENTOS
        'from
        '(select Clave_expediente,clave_pedidofondo from expediente where not isnull(clave_pedidofondo))E
        'left JOIN
        '(select count(Clave_expediente) as 'Expedientes',Clave_expediente from expediente where not isnull(clave_pedidofondo) group by clave_pedidofondo )F
        'on E.Clave_expediente=F.Clave_expediente
        'left join
        '(select count(clave_expediente) as 'CUITs',
        'Clave_expediente from cuit_expediente group by Clave_expediente )D
        'on E.Clave_expediente=D.Clave_expediente
        'left join
        '(select CASE WHEN Count(Clave_expediente_detalle) >0  then Count(Clave_expediente_detalle) else 0 END as 'Movimientos',
        'ClavePedidofondo,Clave_expediente_detalle  from expediente_detalle group by ClavePedidofondo )C
        'on e.Clave_pedidofondo=C.ClavePedidofondo)G
        'on A.Clave_Pedidofondo=G.Clave_Pedidofondo
        'left JOIN
        '(select * From Cuenta_Bancaria)B
        'on A.cuenta_pedidofondo=b.Cuenta
        'GROUP BY Clave_pedidofondo
        'UNION ALL
        'SELECT Concat(N_pedidofondo,'/',Year_pedidofondo) AS 'Pedido de fondos',AA.fecha_pedido,
        'AA.descripcion,
        '	Monto_pedidofondo AS `Monto_pedidofondo`,
        '	Cuenta_pedidofondo,BB.descripcion as Cuentadescripcion,
        '	Expediente_N AS 'Numero de Expediente',Clase_fondo,
        '	IMPRESO,AA.Clave_pedidofondo,BB.Caracter,0 as 'Expedientes',Parcial,Haberes,
        '0 as 'MOVIMIENTOS',
        '0 AS 'CUITS' FROM
        '(Select * FROM Pedido_fondos WHERE Clave_pedidofondo NOT IN (select clave_pedidofondo from expediente where  NOT isnull(clave_pedidofondo)) )AA
        'left JOIN
        '(select * From Cuenta_Bancaria)BB
        'on AA.cuenta_pedidofondo=bB.Cuenta
        'GROUP BY Clave_pedidofondo
        'ORDER BY clave_pedidofondo desc", pedidofondos_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
        'End Select
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_PEDIDODS_FONDOS_GENERAL", pedidofondos_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '        Inicio.SQLPARAMETROS(Organismotabla, "SELECT
        'Concat(N_pedidofondo,'/',Year_pedidofondo) AS 'Nº Ped.de fondos',
        'A.fecha_pedido,
        'A.descripcion,G.DETALLE ,
        '	case when isnull(Monto_pedidofondo) then 0 else Monto_pedidofondo end  AS `Total Pedido Fondo`,
        '	B.descripcion as `Cuenta Bancaria`,
        '	Clase_fondo,
        '	IMPRESO,A.Clave_pedidofondo,B.Caracter,G.Expedientes as 'Expedientes',Parcial,Haberes,
        'G.MOVIMIENTOS,
        'G.CUITS FROM
        '(Select * FROM Pedido_fondos )A
        'inner JOIN
        '(Select e.Clave_expediente,
        'CASE WHEN Expedientes >0  then Expedientes else 0 END as Expedientes,
        'CASE WHEN cuits >0  then CUITS else 0 END as CUITS,e.clave_pedidofondo,
        'DETALLE,
        'CASE WHEN C.Movimientos >0  then C.Movimientos else 0 END as MOVIMIENTOS
        'from
        '(select Clave_expediente,clave_pedidofondo from expediente where not isnull(clave_pedidofondo))E
        'left JOIN
        '(select count(Clave_expediente) as 'Expedientes',Clave_expediente from expediente where not isnull(clave_pedidofondo) group by clave_pedidofondo )F
        'on E.Clave_expediente=F.Clave_expediente
        'left join
        '(select count(clave_expediente) as 'CUITs',GROUP_CONCAT(DISTINCT DETALLE) AS DETALLE,
        'Clave_expediente from CUIT_MOVIMIENTO group by Clave_expediente )D
        'on E.Clave_expediente=D.Clave_expediente
        'left join
        '(select CASE WHEN Count(Clave_expediente_detalle) >0  then Count(Clave_expediente_detalle) else 0 END as 'Movimientos',
        'ClavePedidofondo,Clave_expediente_detalle  from expediente_detalle group by ClavePedidofondo )C
        'on e.Clave_pedidofondo=C.ClavePedidofondo)G
        'on A.Clave_Pedidofondo=G.Clave_Pedidofondo
        'left JOIN
        '(select * From Cuenta_Bancaria)B
        'on A.cuenta_pedidofondo=b.Cuenta
        'GROUP BY Clave_pedidofondo
        'UNION ALL
        'SELECT Concat(N_pedidofondo,'/',Year_pedidofondo) AS 'Pedido de fondos',
        'AA.fecha_pedido,
        'AA.descripcion,
        ''' AS DETALLE,
        '	case when isnull(Monto_pedidofondo) then 0 else Monto_pedidofondo end  AS `Total Pedido Fondo`,
        '	BB.descripcion as Cuentadescripcion,
        '	Clase_fondo,
        '	IMPRESO,AA.Clave_pedidofondo,BB.Caracter,0 as 'Expedientes',Parcial,Haberes,
        '0 as 'MOVIMIENTOS',
        '0 AS 'CUITS'
        'FROM
        '(Select * FROM Pedido_fondos WHERE Clave_pedidofondo NOT IN (select clave_pedidofondo from expediente where  NOT isnull(clave_pedidofondo)) )AA
        'left JOIN
        '(select * From Cuenta_Bancaria)BB
        'on AA.cuenta_pedidofondo=bB.Cuenta
        'GROUP BY Clave_pedidofondo
        'ORDER BY fecha_pedido DESC,clave_pedidofondo desc", pedidofondos_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
        Datosspedidofondo_datagridview.DataSource = pedidofondos_datatable
        'Datosspedidofondo_datagridview.Columns("Monto_pedidofondo").DefaultCellStyle.Format = "C"
        'Datosspedidofondo_datagridview.Columns("Clave_pedidofondo").Visible = False
        'Datosspedidofondo_datagridview.Columns("Impreso").Visible = False
        'Datosspedidofondo_datagridview.Columns("Parcial").Visible = False
        'Datosspedidofondo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Formatocolumnas(Datosspedidofondo_datagridview, pedidofondos_datatable)
        Datosspedidofondo_datagridview.Columns(0).DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Datosspedidofondo_datagridview.CurrentCell = Nothing
    End Sub

    Private Sub colorearceldasasociadas()
        For x = 0 To Expedientesasociados_datagridview.Rows.Count - 1
            If Not (IsDBNull(Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto").Value)) Then
                Select Case Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto").Value
                    Case Is = 0
                        'Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto").Style.BackColor = Color.Yellow
                        'Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto").Style.SelectionBackColor = Color.Yellow
                        Colorcelda(Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto"), Color.Yellow)
                    Case > 0
                        'Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto").Style.BackColor = Color.PaleGreen
                        'Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto").Style.SelectionBackColor = Color.PaleGreen
                        Colorcelda(Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto"), Color.PaleGreen)
                End Select
            End If
        Next
    End Sub

    Private Sub refreshexpedientes()
        'Select Case SplitContainer3.Visible
        '    Case True
        Dim sumaexpedientes As Decimal = 0
        Select Case Datosspedidofondo_datagridview.SelectedRows.Count > 0
            Case True
                busquedasqlasociada = ""
                Expedientesasociados_datagridview.ReadOnly = True
                Expedientesasociados_datagridview.BackgroundColor = Color.White
                Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
                    Case True
                        'PEDIDO DE FONDO PARCIAL DONDE SE SOLICITAN MONTOS PARCIALES A TODOS O A ALGUNOS PROVEEDORES DENTRO DEL MISMO
                        'Select Case Busquedaexpedientesasociados_textbox.TextLength > 0
                        '    Case True
                        '        busquedasqlasociada = " AND (Proveedor LIKE @Busqueda OR CUIT LIKE @Busqueda) "
                        '        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Busqueda", "%" & Busquedaexpedientesasociados_textbox.Text & "%")
                        '    Case False
                        '        busquedasqlasociada = ""
                        'End Select
                        COMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value)
                        COMMANDSQL.Parameters.AddWithValue("@row_number", 0)
                        Inicio.SQLPARAMETROS(Organismotabla, "  Select
0 AS 'N',CONCAT(Substring(a.Clave_expediente From 5 for 4),'-',cast(Substring(a.Clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(a.Clave_expediente From 1 for 4)) as 'Expediente_N',
A.CUIT,D.Rubro,CASE WHEN (SUBSTRING(B.CUIT FROM 1 FOR 2)=30 OR SUBSTRING(B.CUIT FROM 1 FOR 2)=33 OR SUBSTRING(B.CUIT FROM 1 FOR 2)=34) THEN
B.PROVEEDOR ELSE
CASE WHEN (B.NOMBREFANTASIA='' OR ISNULL(B.NOMBREFANTASIA)) THEN B.Proveedor ELSE CONCAT(B.NOMBREFANTASIA,' de ',B.PROVEEDOR) END
 END as Detalle,A.MONTO,a.monto AS monto2,
c.Clave_expediente,A.MONTO AS `Total Expediente`,format(E.MONTO,2,'es_AR') AS `ACUMULADO`,
format(D.MONTO-E.MONTO,2,'es_AR') AS `RESTANTE`,NUMERO,C.Fecha,CASE WHEN C.Ordenpago='' THEN C.ORDENCARGO ELSE C.ORDENPAGO END AS ORDENPAGO,C.DETALLE AS 'ACLARACION' FROM
(Select CUIT,Monto,Clave_expediente,Clave_pedidofondo from Cuit_Movimiento Where Clave_pedidofondo=@Clave_pedidofondo ) A
LEFT JOIN
(Select Expediente_N,Fecha,Detalle,Ordenpago,ORDENCARGO,Clave_expediente from expediente) C ON
A.clave_expediente=C.Clave_expediente
LEFT JOIN
(Select Proveedor,CUIT,NUMERO,NOMBREFANTASIA from proveedores) B ON
A.CUIT=B.CUIT
LEFT JOIN
(SELECT CUIT,MONTO,Clave_expediente,rubro FROM cuit_expediente )D
on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(D.CUIT,D.Clave_expediente)
LEFT JOIN
(SELECT CUIT,SUM(MONTO) AS MONTO,Clave_expediente FROM cuit_movimiento GROUP BY CLAVE_EXPEDIENTE,CUIT)E
on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(E.CUIT,E.Clave_expediente)  order by clave_expediente desc,detalle asc,fecha desc", Expedientesasociados_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                        For x = 0 To Expedientesasociados_datatable.Rows.Count - 1
                            Expedientesasociados_datatable.Rows(x).Item("N") = x + 1
                            If Expedientesasociados_datatable.Rows(x).Item("CUIT").ToString = "30-68325640-0" Then
                                Expedientesasociados_datatable.Rows(x).Item("Detalle") = Expedientesasociados_datatable.Rows(x).Item("ACLARACION").ToString
                            End If
                        Next
                        'For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                        '    If Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT").Value.ToString = "30-68325640-0" Then
                        '        Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value = Expedientesasociados_datagridview.Rows(X).Cells.Item("ACLARACION").Value.ToString &
                        '            "(" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString & ")"
                        '    End If
                        'Next
                        Expedientesasociados_datagridview.DataSource = Expedientesasociados_datatable
                        'Expedientesasociados_datagridview.Columns("Clave_expediente").Visible = False
                        'Expedientesasociados_datagridview.Columns("Monto").DefaultCellStyle.Format = "C"
                        Formatocolumnas(Expedientesasociados_datagridview, Expedientesasociados_datatable)
                        Expedientesasociados_datagridview.ReadOnly = False
                        'Expedientesasociados_datagridview.SelectionMode = DataGridViewSelectionMode.CellSelect
                        Expedientesasociados_datagridview.BackgroundColor = Color.YellowGreen
                        If Expedientesasociados_datagridview.Columns.Contains("monto") Then
                            Expedientesasociados_datagridview.Columns("monto").Visible = False
                            Expedientesasociados_datagridview.Columns("ACLARACION").Visible = False
                        End If
                        busquedasqlnoasociada = ""
                        Select Case BusquedaexpedientesNOasociados_textbox.TextLength > 0
                            Case True
                                busquedasqlnoasociada = " AND (EXPEDIENTE_N LIKE @busquedaEXPEDIENTEnoasociada OR Detalle LIKE @busquedaEXPEDIENTEnoasociada) "
                                COMMANDSQL.Parameters.AddWithValue("@busquedaEXPEDIENTEnoasociada", "%" & BusquedaexpedientesNOasociados_textbox.Text & "%")
                            Case False
                                busquedasqlnoasociada = ""
                        End Select
                        If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value = 0 Then
                            Inicio.SQLPARAMETROS(Organismotabla, "SELECT CONCAT(Substring(a.clave_expediente From 5 for 4),'-',cast(Substring(a.clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(a.clave_expediente From 1 for 4)) as Expediente_N,Fecha,Detalle,Ordenpago,format(Monto,2, 'es_AR') as `Monto`,A.Clave_expediente,A.monto as monto2 FROM
(Select clave_expediente,FEcha,DEtalle,ORdenpago,Monto from Expediente where
ISNULL(Clave_pedidofondo) and not (monto=0) )A order by a.clave_expediente desc,detalle asc,fecha desc", Expedientenoasociados_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                        Else
                            Inicio.SQLPARAMETROS(Organismotabla, "SELECT CONCAT(Substring(a.clave_expediente From 5 for 4),'-',cast(Substring(a.clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(a.clave_expediente From 1 for 4)) as Expediente_N,Fecha,Detalle,Ordenpago,format(Monto,2, 'es_AR') as `Monto`,A.Clave_expediente,A.monto as monto2 FROM
(Select clave_expediente,FEcha,DEtalle,ORdenpago,Monto from Expediente where
ISNULL(Clave_pedidofondo) and not (monto=0) AND HABERES=1  )A
 order by CUIT ASC,detalle asc,fecha desc", Expedientenoasociados_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                        End If
                        ExpedientesNOasociados_datagridview.DataSource = Expedientenoasociados_datatable
                        'ExpedientesNOasociados_datagridview.Columns("Clave_expediente").Visible = False
                        Formatocolumnas(ExpedientesNOasociados_datagridview, Expedientenoasociados_datatable)
                        ExpedientesNOasociados_datagridview.Columns("monto2").Visible = False
                        colorearceldasasociadas()
                    Case False
                        'PEDIDO DE FONDO TRADICIONAL DONDE SE IMPUTA TODO EL EXPEDIENTE
                        COMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value)
                        COMMANDSQL.Parameters.AddWithValue("@row_number", 0)
                        'debido a la presencia de datos de fonddos y valores primero se comprueba la existencia de cuits dentro de los pedidos de fondos, con lo cual se puede dividir el pedido en 2
                        'los viejos que provienen de fondos y valores y los nuevos que provienen del SICyF
                        If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value = 0 Then
                            Inicio.SQLPARAMETROS(Organismotabla, "   Select
0 AS 'N',CONCAT(Substring(a.Clave_expediente From 5 for 4),'-',cast(Substring(a.Clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(a.Clave_expediente From 1 for 4)) as 'Expediente_N',
A.CUIT,D.Rubro,CASE WHEN (SUBSTRING(B.CUIT FROM 1 FOR 2)=30 OR SUBSTRING(B.CUIT FROM 1 FOR 2)=33 OR SUBSTRING(B.CUIT FROM 1 FOR 2)=34) THEN
B.PROVEEDOR ELSE
CASE WHEN (B.NOMBREFANTASIA='' OR ISNULL(B.NOMBREFANTASIA)) THEN B.Proveedor ELSE CONCAT(B.NOMBREFANTASIA,' de ',B.PROVEEDOR) END
 END as Detalle,a.Monto AS `Monto`,a.monto AS monto2,
c.Clave_expediente,D.MONTO AS `Total Expediente`,format(E.MONTO,2,'es_AR') AS `ACUMULADO`,
format(D.MONTO-E.MONTO,2,'es_AR') AS `RESTANTE`,NUMERO,C.Fecha,CASE WHEN C.Ordenpago='' THEN C.ORDENCARGO ELSE C.ORDENPAGO END AS ORDENPAGO,C.DETALLE AS 'ACLARACION' FROM
(Select CUIT,Monto,Clave_expediente,Clave_pedidofondo from Cuit_Movimiento Where Clave_pedidofondo=@Clave_pedidofondo ) A
LEFT JOIN
(Select CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N,
Fecha,Detalle,Ordenpago,ORDENCARGO,Clave_expediente from expediente) C ON
A.clave_expediente=C.Clave_expediente
LEFT JOIN
(Select Proveedor,CUIT,NUMERO,NOMBREFANTASIA from proveedores) B ON
A.CUIT=B.CUIT
LEFT JOIN
(SELECT CUIT,MONTO,Clave_expediente,rubro FROM cuit_expediente )D
on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(D.CUIT,D.Clave_expediente)
LEFT JOIN
(SELECT CUIT,SUM(MONTO) AS MONTO,Clave_expediente FROM cuit_movimiento GROUP BY CLAVE_EXPEDIENTE,CUIT)E
on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(E.CUIT,E.Clave_expediente)  order by clave_expediente desc,detalle asc,fecha desc", Expedientesasociados_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                        Else
                            Inicio.SQLPARAMETROS(Organismotabla, "   Select
                                0 AS 'N',CONCAT(Substring(a.Clave_expediente From 5 for 4),'-',cast(Substring(a.Clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(a.Clave_expediente From 1 for 4)) as 'Expediente_N',
                                '-' as 'CUIT.',D.Rubro,d.detalle,a.Monto AS `Monto`,a.monto AS monto2,
                                c.Clave_expediente,D.MONTO AS `Total Expediente`,format(E.MONTO,2,'es_AR') AS `ACUMULADO`,
                                format(D.MONTO-E.MONTO,2,'es_AR') AS `RESTANTE`,'-' as Numero,C.Fecha,C.Ordenpago,C.DETALLE AS 'ACLARACION',A.CUIT FROM
                                (Select CUIT,Monto,Clave_expediente,Clave_pedidofondo from Cuit_Movimiento Where Clave_pedidofondo=@Clave_pedidofondo ) A
                                LEFT JOIN
                                (Select CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N,Fecha,Detalle,Ordenpago,Clave_expediente from expediente) C ON
                                A.clave_expediente=C.Clave_expediente
                                LEFT JOIN
                                (Select Proveedor,CUIT,NUMERO,NOMBREFANTASIA from proveedores_haberes) B ON
                                A.CUIT=B.CUIT
                                LEFT JOIN
                                (SELECT CUIT,MONTO,Clave_expediente,rubro,detalle FROM cuit_expediente )D
                                on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(D.CUIT,D.Clave_expediente)
                                LEFT JOIN
                                (SELECT CUIT,SUM(MONTO) AS MONTO,Clave_expediente FROM cuit_movimiento GROUP BY CLAVE_EXPEDIENTE,CUIT)E
                                on CONCAT(A.CUIT,A.Clave_expediente)= CONCAT(E.CUIT,E.Clave_expediente)  order by clave_expediente desc,CUIT ASC,numero asc,fecha desc", Expedientesasociados_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                        End If
                        If Expedientesasociados_datatable.Rows.Count > 0 Then
                            If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value = 0 Then
                                For x = 0 To Expedientesasociados_datatable.Rows.Count - 1
                                    Expedientesasociados_datatable.Rows(x).Item("N") = x + 1
                                    If Expedientesasociados_datatable.Rows(x).Item("CUIT").ToString = "30-68325640-0" Then
                                        Expedientesasociados_datatable.Rows(x).Item("Detalle") = Expedientesasociados_datatable.Rows(x).Item("ACLARACION").ToString
                                    End If
                                Next
                            Else
                            End If
                            Expedientesasociados_datagridview.DataSource = Expedientesasociados_datatable
                            Formatocolumnas(Expedientesasociados_datagridview, Expedientesasociados_datatable)
                            If Expedientesasociados_datagridview.Rows.Count > 0 Then
                                Expedientesasociados_datagridview.Columns("CUIT").Visible = False
                            End If
                            Expedientesasociados_datagridview.Columns("Clave_expediente").Visible = False
                            Expedientesasociados_datagridview.Columns("ACLARACION").Visible = False
                            If Expedientesasociados_datagridview.Columns.Contains("monto2") Then
                                Expedientesasociados_datagridview.Columns("monto2").Visible = False
                            End If
                            busquedasqlnoasociada = ""
                            Select Case BusquedaexpedientesNOasociados_textbox.TextLength > 0
                                Case True
                                    busquedasqlnoasociada = " AND (EXPEDIENTE_N LIKE @busquedaEXPEDIENTEnoasociada OR Detalle LIKE @busquedaEXPEDIENTEnoasociada) "
                                    COMMANDSQL.Parameters.AddWithValue("@busquedaEXPEDIENTEnoasociada", "%" & BusquedaexpedientesNOasociados_textbox.Text & "%")
                                Case False
                                    busquedasqlnoasociada = ""
                            End Select
                        Else
                            '  en caso de que sea un pedido de fondos viejo
                            If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value = 0 Then
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value)
                                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@row_number", 0)
                                Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT
	0 AS 'N',
	CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as Expediente_N,
	Fecha,
	Detalle,
	Ordenpago,
	 Monto AS `Monto`,
	Clave_expediente,
	monto AS monto2
FROM
	Expediente
WHERE
	Clave_pedidofondo = @Clave_pedidofondo
ORDER BY
	clave_expediente DESC,
	fecha DESC ", Expedientesasociados_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
                            End If
                            ' End If
                            'Expedientesasociados_datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                            Expedientesasociados_datagridview.EditMode = DataGridViewEditMode.EditOnF2
                            Expedientesasociados_datagridview.ReadOnly = True
                            Expedientesasociados_datagridview.BackgroundColor = Color.White
                            Expedientesasociados_datagridview.DataSource = Expedientesasociados_datatable
                            Formatocolumnas(Expedientesasociados_datagridview, Expedientesasociados_datatable)
                            Expedientesasociados_datagridview.Columns("Clave_expediente").Visible = False
                            Expedientesasociados_datagridview.Columns("monto2").Visible = False
                            busquedasqlnoasociada = ""
                            Select Case BusquedaexpedientesNOasociados_textbox.TextLength > 0
                                Case True
                                    busquedasqlnoasociada = " AND (EXPEDIENTE_N LIKE @busquedaEXPEDIENTEnoasociada OR Detalle LIKE @busquedaEXPEDIENTEnoasociada) "
                                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@busquedaEXPEDIENTEnoasociada", "%" & BusquedaexpedientesNOasociados_textbox.Text & "%")
                                Case False
                                    busquedasqlnoasociada = ""
                            End Select
                        End If
                        If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value = 0 Then
                            Inicio.SQLPARAMETROS(Organismotabla, "SELECT CONCAT(Substring(a.clave_expediente From 5 for 4),'-',cast(Substring(a.clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(a.clave_expediente From 1 for 4)) as Expediente_N,Fecha,Detalle,Ordenpago,format(Monto,2, 'es_AR') as `Monto`,A.Clave_expediente,A.monto as monto2 FROM
(Select clave_expediente,FEcha,DEtalle,ORdenpago,Monto from Expediente where
ISNULL(Clave_pedidofondo) and not (monto=0) )A order by a.clave_expediente desc,detalle asc,fecha desc", Expedientenoasociados_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                        Else
                            Inicio.SQLPARAMETROS(Organismotabla, "SELECT CONCAT(Substring(a.clave_expediente From 5 for 4),'-',cast(Substring(a.clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(a.clave_expediente From 1 for 4)) as Expediente_N,Fecha,Detalle,Ordenpago,format(Monto,2, 'es_AR') as `Monto`,A.Clave_expediente,A.monto as monto2,SOLICITADO,(MONTO-SOLICITADO) AS RESTANTE FROM
(Select * from Expediente where
ISNULL(Clave_pedidofondo) and not (monto=0) and HABERES=1  )A
left JOIN
(SELECT SUM(MONTO) AS 'SOLICITADO',Clave_expediente FROM cuit_movimiento)B
ON A.Clave_expediente=B.Clave_expediente " & busquedasqlnoasociada & " order by clave_expediente desc,detalle asc,fecha desc", Expedientenoasociados_datatable, Reflection.MethodBase.GetCurrentMethod.Name)
                        End If
                        ExpedientesNOasociados_datagridview.DataSource = Expedientenoasociados_datatable
                        Formatocolumnas(ExpedientesNOasociados_datagridview, Expedientenoasociados_datatable)
                        '             ExpedientesNOasociados_datagridview.Columns("Clave_expediente").Visible = False
                        '            ExpedientesNOasociados_datagridview.Columns("monto2").Visible = False
                        ' ExpedientesNOasociados_datagridview.Columns("expediente_N").Visible = False
                        For x = 0 To Expedientesasociados_datatable.Rows.Count - 1
                            Expedientesasociados_datatable.Rows(x).Item("N") = x + 1
                        Next
                        colorearceldasasociadas()
                End Select
            Case False
                Expedientesasociados_datagridview.DataSource = Nothing
                ExpedientesNOasociados_datagridview.DataSource = Nothing
        End Select
        Dim s As Decimal = 0
        For x = 0 To Expedientesasociados_datagridview.Rows.Count - 1
            If Not IsDBNull(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value) Then
                sumaexpedientes += Convert.ToDecimal(Expedientesasociados_datagridview.Rows(x).Cells.Item("MONTO").Value)
            Else
                sumaexpedientes = sumaexpedientes + 0
            End If
        Next
        pedfondoseleccionado.Monto_pedidofondo = sumaexpedientes
        Pedidodefondosmontowpf.Monto_textbox.Number = pedfondoseleccionado.Monto_pedidofondo
        If sumaexpedientes > 0 Then
            Label_MontoSolicitado.Text = "Monto Solicitado  " & Pedidodefondosmontowpf.Monto_textbox.Text & vbCrLf&
            Inicio.Num2Text(sumaexpedientes)
        Else
            Label_MontoSolicitado.Text = ""
        End If
        '    Case False
        'End Select
        splitContainerGeneral.ResumeLayout()
    End Sub

    Private Sub Organismo_textbox_TextChanged(sender As Object, e As EventArgs)
        Select Case sender.textlength = 4
            Case True
                Select Case IsNumeric(sender.text)
                    Case True
                        Dim organismocargador As New DataTable
                        COMMANDSQL.Parameters.AddWithValue("@codigo", sender.text)
                        Inicio.SQLPARAMETROS(Organismotabla, "select Organismo from Organismos Where codigo = @codigo group by codigo; ", organismocargador, Reflection.MethodBase.GetCurrentMethod.Name)
                        Select Case organismocargador.Rows.Count
                            Case > 0
                                Organismolabel.Text = organismocargador.Rows(0).Item(0).ToString
                                organismocargador.Dispose()
                        End Select
                    Case False
                End Select
            Case False
        End Select
    End Sub

    Private Sub Datosspedidofondo_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Datosspedidofondo_datagridview.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Mousederecho_PedidoFondos(sender, e, sender)
        End Select
    End Sub

    Private Sub Expedientes_asociados_datagridview_MouseUp(sender As Object, e As MouseEventArgs)
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        Select Case Cuentas_combobox.SelectedIndex > -1
            Case True
                Numero_cuentalabel.Text = Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString
        End Select
    End Sub

    Private Sub Boton_borrar_Click(sender As Object, e As EventArgs) Handles Boton_borrar.Click
        If Cantidad_Movimientos_pedidofondo(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value) = 0 Then
            Select Case Datosspedidofondo_datagridview.SelectedRows.Count
                Case > 0
                    Dim clavepedido As String = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString
                    Select Case MsgBox("DESEA BORRAR EL PEDIDO DE FONDO N" & N_pedidofondo_numeric.Value, MsgBoxStyle.YesNoCancel, " ")
                        Case MsgBoxResult.Yes
                            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value)
                            INSERTCOMMANDSQL.CommandText = "DELETE FROM `Pedido_fondos` " &
                    " WHERE Clave_pedidofondo=@Clave_pedidofondo"
                            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                            INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", clavepedido)
                            INSERTCOMMANDSQL.CommandText = "UPDATE `expediente` SET Clave_pedidofondo=NULL,CUENTA_N=NULL,Usuario=@Usuario WHERE Clave_pedidofondo=@Clave_pedidofondo;"
                            Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                            Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
                            refreshnow()
                            Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
                        Case MsgBoxResult.Cancel
                        Case MsgBoxResult.No
                            MessageBox.Show("Los datos no van a ser cargados")
                    End Select
                Case Else
                    MessageBox.Show("Si desea borrar un pedido de fondo debe borrar al menos uno de ellos")
            End Select
        Else
            'Cambiar a una info que devuelva los expedientes dentro del pedido de fondo.
            MessageBox.Show("Actualmente este pedido de fondos registra movimiento en alguno de los expedientes que lo componen")
        End If
    End Sub

    Private Sub Expedientesasociados_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Expedientesasociados_datagridview.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Mousederecho_Expedientesasociados(sender, e, sender)
        End Select
    End Sub

    Private Sub ExpedientesNOasociados_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles ExpedientesNOasociados_datagridview.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    'Private Sub Fecha_pedido_textbox_TextChanged(sender As Object, e As EventArgs)
    '    Inicio.Verificar(sender, sender.TEXT, "FECHA")
    'End Sub
    Private Sub BusquedaexpedientesNOasociados_textbox_TextChanged(sender As Object, e As EventArgs) Handles BusquedaexpedientesNOasociados_textbox.TextChanged
        Buscar_datagrid_TIMER(sender, Expedientenoasociados_datatable, ExpedientesNOasociados_datagridview)
        'refreshexpedientes()
    End Sub

    Private Sub Generaciondepedidodefondos()
        Dim Pedidodefondos_datatable As New DataTable
        Dim Numdecuenta_datatable As New DataTable
        Dim Caracterdecuenta1 As New DataTable
        Dim Caracterdecuenta2 As New DataTable
        Dim Cuentadepresupuesto_datatable As New DataTable
        Dim Transferidoportesoreríageneral_datatable As New DataTable
        'Dim Pedidoactualdefondo As New Pedidofondo
        'Pedidoactualdefondo.Numeropedidofondo =
        'Pedidoactualdefondo.Yearpedidofondo =
        'Pedidoactualdefondo.Fecha =
        'Pedidoactualdefondo.CuentaPedidofondo =
        'Pedidoactualdefondo.Exptecompleto =
        'Pedidoactualdefondo.ExpteOrganismo =
        'Pedidoactualdefondo.ExpteNumero =
        'Pedidoactualdefondo.ExpteYear =
        'Pedidoactualdefondo.Descripcion =
        'Pedidoactualdefondo.ClaseFondo =
        'Pedidoactualdefondo.Pedidofondoparcial = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
        'Pedidoactualdefondo.clavepedidofondo =
        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Tesoreria_Informe_pedidofondos.Numeroordendeentregafondos_textbox.Text = ""
        Tesoreria_Informe_pedidofondos.Yearordendeentregafondos_textbox.Text = ""
        Tesoreria_Informe_pedidofondos.Fechadeentregadefondos_label.Text = ""
        Tesoreria_Informe_pedidofondos.Fechapedidodefondo_label.Text = "FECHA:" & Convert.ToDateTime(Fecha_pedido_textbox.Value).ToString("dd/MM/yyyy")
        Tesoreria_Informe_pedidofondos.Servicioadministrativo_textbox.Text = Nombrecompletodelservicio
        Tesoreria_Informe_pedidofondos.Numeropedidofondos_textbox.Text = Convert.ToInt16(N_pedidofondo_numeric.Value).ToString("0000")
        Tesoreria_Informe_pedidofondos.Yearpedidodefondos_textbox.Text = Year_pedidofondo_numeric.Value.ToString
        Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
            Case True
                'estructura de pedidos de fondos en caso de ser parcial
                Pedidodefondos_datatable.Columns.Add("N")
                Pedidodefondos_datatable.Columns.Add("RUBRO")
                Pedidodefondos_datatable.Columns.Add("PROVEEDOR")
                Pedidodefondos_datatable.Columns.Add("Expediente N")
                Pedidodefondos_datatable.Columns.Add("CUIT")
                Pedidodefondos_datatable.Columns.Add("CONCEPTO")
                Pedidodefondos_datatable.Columns.Add("IMPORTE")
                For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                    Pedidodefondos_datatable.Rows.Add()
                    Pedidodefondos_datatable.Rows(X).Item("N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("RUBRO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Rubro").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("Expediente N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("expediente_N").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("CUIT") = Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("CONCEPTO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString &
                "( O.N" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ")"
                    Pedidodefondos_datatable.Rows(X).Item("IMPORTE") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto").Value.ToString), 2,, TriState.True, TriState.True)
                Next
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.DataSource = Pedidodefondos_datatable
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("N").Width = 22
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("RUBRO").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("Expediente N").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CUIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("IMPORTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '/estructura de pedidos de fondos
            Case False
                'estructura de fondos en caso de ser habitual, con el nuevo tipo de formato
                Pedidodefondos_datatable.Columns.Add("N")
                Pedidodefondos_datatable.Columns.Add("RUBRO")
                Pedidodefondos_datatable.Columns.Add("PROVEEDOR")
                Pedidodefondos_datatable.Columns.Add("Expediente N")
                Pedidodefondos_datatable.Columns.Add("CUIT")
                Pedidodefondos_datatable.Columns.Add("CONCEPTO")
                Pedidodefondos_datatable.Columns.Add("IMPORTE")
                For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                    Pedidodefondos_datatable.Rows.Add()
                    Pedidodefondos_datatable.Rows(X).Item("N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("RUBRO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Rubro").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("Expediente N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("expediente_N").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("CUIT") = Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
                    Pedidodefondos_datatable.Rows(X).Item("CONCEPTO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString &
                "( O.N" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ")"
                    Pedidodefondos_datatable.Rows(X).Item("IMPORTE") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto").Value.ToString), 2,, TriState.True, TriState.True)
                Next
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.DataSource = Pedidodefondos_datatable
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("N").Width = 22
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("RUBRO").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("Expediente N").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CUIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("IMPORTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                ''estructura de pedidos de fondos caso habitual
                'Pedidodefondos_datatable.Columns.Add("N")
                'Pedidodefondos_datatable.Columns.Add("RUBRO")
                'Pedidodefondos_datatable.Columns.Add("PROVEEDOR")
                'Pedidodefondos_datatable.Columns.Add("CONCEPTO")
                'Pedidodefondos_datatable.Columns.Add("IMPORTE")
                'For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                '    Pedidodefondos_datatable.Rows.Add()
                '    Pedidodefondos_datatable.Rows(X).Item("N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
                '    Pedidodefondos_datatable.Rows(X).Item("RUBRO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Rubro").Value.ToString
                '    ' If IsNothing(Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value) Or IsDBNull(Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value) Then
                '    ' Se desactiva el número de proveedor para los casos de pedido de fondo por no poder controlar el hecho de que pueden existir expedientes con más de 20 o 30 proveedores lo que derrota el proposito del control
                '    Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = "-"
                '    '  Else
                '    '       Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
                '    ' End If
                '    Pedidodefondos_datatable.Rows(X).Item("CONCEPTO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString &
                '"-(" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Expediente_N").Value.ToString & ")" &
                '"( O.N" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ")"
                '    Pedidodefondos_datatable.Rows(X).Item("IMPORTE") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto2").Value.ToString), 2,, TriState.True, TriState.True)
                'Next
                'Select Case Expedientesasociados_datagridview.Rows.Count
                '    Case = 1
                '        Tesoreria_Informe_pedidofondos.Contadorgeneraltexto_label.Text = "Sr. CONTADOR GENERAL DE LA PROVINCIA. De acuerdo a la LEY DE CONTABILIDAD, solicitamos la siguiente TRANSFERENCIA de Fondos:"
                '    Case Else
                '        Tesoreria_Informe_pedidofondos.Contadorgeneraltexto_label.Text = "Sr. CONTADOR GENERAL DE LA PROVINCIA. De acuerdo a la LEY DE CONTABILIDAD, solicitamos las siguientes TRANSFERENCIAS de Fondos:"
                'End Select
                'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.DataSource = Pedidodefondos_datatable
                'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("N").Width = 22
                ''Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item(" ").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("RUBRO").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("PROVEEDOR").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("IMPORTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                ''/estructura de pedidos de fondos
        End Select
        'estructura de numero de cuenta
        For x = 0 To Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Length - 1
            Numdecuenta_datatable.Columns.Add("")
        Next
        Numdecuenta_datatable.Rows.Add()
        For x = 0 To Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Length - 1
            Numdecuenta_datatable.Rows(0).Item(x) = Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Chars(x)
        Next
        '/estructura de numero de cuenta
        'Estructura de Caracter de la Cuenta
        For x = 0 To 3
            Caracterdecuenta1.Columns.Add("")
        Next
        Caracterdecuenta1.Rows.Add()
        Caracterdecuenta1.Rows(0).Item(0) = "CÁRACTER"
        Caracterdecuenta1.Rows(0).Item(1) = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
        Caracterdecuenta1.Rows(0).Item(2) = "CUENTA:"
        Caracterdecuenta1.Rows(0).Item(3) = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Cuentadescripcion").Value.ToString
        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.DataSource = Caracterdecuenta1
        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For x = 0 To 3
            Caracterdecuenta2.Columns.Add("")
        Next
        Caracterdecuenta2.Rows.Add()
        Caracterdecuenta2.Rows(0).Item(0) = "CÁRACTER"
        Caracterdecuenta2.Rows(0).Item(1) = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
        Caracterdecuenta2.Rows(0).Item(2) = "CUENTA"
        Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
            Case Is = "0"
                Caracterdecuenta2.Rows(0).Item(3) = "SIN AFECTACIÓN ESPECIAL"
            Case Else
                Caracterdecuenta2.Rows(0).Item(3) = "CON AFECTACIÓN ESPECIAL -" & vbNewLine & Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(1).ToString()
        End Select
        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.DataSource = Caracterdecuenta2
        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        '/Estructura de Caracter de la Cuenta
        'estructura de cuentadepresupuesto
        Cuentadepresupuesto_datatable.Columns.Add("CONCEPTO")
        Cuentadepresupuesto_datatable.Columns.Add("IMPORTES")
        Cuentadepresupuesto_datatable.Rows.Add()
        Cuentadepresupuesto_datatable.Rows(0).Item("CONCEPTO") = "CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value
        Cuentadepresupuesto_datatable.Rows(0).Item("IMPORTES") = FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True)
        Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview.DataSource = Cuentadepresupuesto_datatable
        Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview.Columns.Item("IMPORTES").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '/estructura de cuentadepresupuesto
        'estructura de Tesorería General de la provincia
        Transferidoportesoreríageneral_datatable.Columns.Add("FECHA")
        Transferidoportesoreríageneral_datatable.Columns.Add("CUENTA N")
        Transferidoportesoreríageneral_datatable.Columns.Add("CHEQUE N")
        Transferidoportesoreríageneral_datatable.Columns.Add("IMPORTES")
        For x = 0 To 6
            Transferidoportesoreríageneral_datatable.Rows.Add()
        Next
        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.DataSource = Transferidoportesoreríageneral_datatable
        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("FECHA").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("IMPORTES").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("CUENTA N").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("CHEQUE N").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '/estructura de Tesorería General de la provincia
        Dim expedientepedidofondo As String() = Nothing
        expedientepedidofondo = Divisordetresvariables(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Numero de Expediente").Value.ToString)
        If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Numero de Expediente").Value.ToString = "" Then
            Tesoreria_Informe_pedidofondos.Expedienteorganismo_textbox.Text = Organismo
            Tesoreria_Informe_pedidofondos.Expedientenumero_textbox.Text = ""
            Tesoreria_Informe_pedidofondos.Expedienteyear_textbox.Text = ""
            Tesoreria_Informe_pedidofondos.EncabezadoYear.Text = Encabezadodelyear(Date.Now.Year)
        Else
            If expedientepedidofondo.Count > 0 Then
                Tesoreria_Informe_pedidofondos.Expedienteorganismo_textbox.Text = expedientepedidofondo(0)
                Tesoreria_Informe_pedidofondos.Expedientenumero_textbox.Text = expedientepedidofondo(1)
                Tesoreria_Informe_pedidofondos.Expedienteyear_textbox.Text = expedientepedidofondo(2)
                Tesoreria_Informe_pedidofondos.EncabezadoYear.Text = Encabezadodelyear(CType(expedientepedidofondo(2), Integer))
            Else
                Tesoreria_Informe_pedidofondos.Expedienteorganismo_textbox.Text = Organismo
                Tesoreria_Informe_pedidofondos.Expedientenumero_textbox.Text = ""
                Tesoreria_Informe_pedidofondos.Expedienteyear_textbox.Text = ""
            End If
        End If
        Tesoreria_Informe_pedidofondos.Fechadevencimiento_textbox.Text = ""
        Tesoreria_Informe_pedidofondos.Deudaconajuste_textbox.Text = ""
        Tesoreria_Informe_pedidofondos.Numcuenta_datagridview.DataSource = Numdecuenta_datatable
        'tamaño Cuentadepresupuesto_datagridview
        ' Informe_pedidofondos.Cuentadepresupuesto_datagridview.Size = New Size(Informe_pedidofondos.Pedidodefondos_datagridview.Width, Inicio.Tamaniodatagridview(Informe_pedidofondos.Cuentadepresupuesto_datagridview).Height)
        Tesoreria_Informe_pedidofondos.Totaltransferenciasolicitada_textbox.Text = FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True)
        'numeros en letras (se usa decimal por contener mayor precisión, las opciones de punto flotante contienen errores de redondeo que son intolerables dentro de un calculo financiero)
        'Tesoreria_Informe_pedidofondos.Montoennumeros_textbox.Text = "SON PESOS: " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Pedidodefondosmontowpf.Monto_textbox.Number))) & " CON " &
        '    ((Convert.ToDecimal(Pedidodefondosmontowpf.Monto_textbox.Number) - Math.Truncate(Convert.ToDecimal(Pedidodefondosmontowpf.Monto_textbox.Number))) * 100).ToString("00") & "/100.-", font10Bold)))
        'ajustar tamaños
        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Size = New Size(Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Width, Inicio.Tamaniodatagridview(Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview).Height)
        Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview.Size = New Size(Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview.Width, Inicio.Tamaniodatagridview(Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview).Height)
        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Size = New Size(Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Width, Inicio.Tamaniodatagridview(Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview).Height)
        Tesoreria_Informe_pedidofondos.Totaltransferidotesoreria_label.Location = Inicio.localizaciondecontrol(Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview, Tesoreria_Informe_pedidofondos.Totaltransferidotesoreria_label)
        Tesoreria_Informe_pedidofondos.Totaltransferidotesoreria_textbox.Location = Inicio.localizaciondecontrol(Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview, Tesoreria_Informe_pedidofondos.Totaltransferidotesoreria_textbox)
        'textboxasociados y labeltext
        Tesoreria_Informe_pedidofondos.Pedidodefondostotal_textbox.Text = FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True)
        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Location = New Point(2, Tesoreria_Informe_pedidofondos.Contadorgeneraltexto_label.Height + Tesoreria_Informe_pedidofondos.Contadorgeneraltexto_label.Location.Y + 2)
        Dim borrarx As Integer = 0
        Dim borrary As Integer = 0
        Tesoreria_Informe_pedidofondos.Pedidodefondostotal_textbox.Location =
            New Point(Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Location.X +
            (Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Width - Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns(4).Width),
            Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Location.Y + Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Size.Height)
        Tesoreria_Informe_pedidofondos.Pedidodefondostotal_textbox.Width = Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns(4).Width
        Tesoreria_Informe_pedidofondos.Totallabel.Location = New Point(Tesoreria_Informe_pedidofondos.Pedidodefondosdetallado_panel.Width - (Tesoreria_Informe_pedidofondos.Pedidodefondostotal_textbox.Size.Width + Tesoreria_Informe_pedidofondos.Totallabel.Width + 4),
                                                             Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Location.Y + Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Size.Height + 2)
        'panel adentro del panel
        Tesoreria_Informe_pedidofondos.Paneldatos_panel.Location = Inicio.localizaciondecontrol(Tesoreria_Informe_pedidofondos.Pedidodefondostotal_textbox, Tesoreria_Informe_pedidofondos.Paneldatos_panel)
        Tesoreria_Informe_pedidofondos.Pedidodefondosdetallado_panel.Height = 0
        Tesoreria_Informe_pedidofondos.Pedidodefondosdetallado_panel.Size = Inicio.Tamaniopanel(Tesoreria_Informe_pedidofondos.Pedidodefondosdetallado_panel)
        'panel de delegado fiscal
        Tesoreria_Informe_pedidofondos.PanelDelegadofiscal_panel.Location = Inicio.localizaciondecontrol(Tesoreria_Informe_pedidofondos.Pedidodefondosdetallado_panel, Tesoreria_Informe_pedidofondos.PanelDelegadofiscal_panel)
        'panel de Tesoreria
        Tesoreria_Informe_pedidofondos.PanelTesoreria.Location = Inicio.localizaciondecontrol(Tesoreria_Informe_pedidofondos.PanelDelegadofiscal_panel, Tesoreria_Informe_pedidofondos.PanelTesoreria)
        'panel de transferido por tesoreria
        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_panel.Location = Inicio.localizaciondecontrol(Tesoreria_Informe_pedidofondos.PanelTesoreria, Tesoreria_Informe_pedidofondos.Transferidoportesoreria_panel)
        Tesoreria_Informe_pedidofondos.Size = New Size(764,
                                                             Inicio.Tamaniodatagridview(Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview).Height + Tesoreria_Informe_pedidofondos.Transferidoportesoreriageneral_label.Size.Height + 2 +
                                                             Tesoreria_Informe_pedidofondos.Totaltransferidotesoreria_label.Height + 2 + Tesoreria_Informe_pedidofondos.Totaltransferidotesoreria_textbox.Size.Height + 2)
        '/ajustar tamaños
        Tesoreria_Informe_pedidofondos.Pedidodefondos_panel.Visible = True
        Tesoreria_Informe_pedidofondos.StartPosition = FormStartPosition.CenterParent
        Select Case Tesoreria_Informe_pedidofondos.ShowDialog()
            Case DialogResult.OK
                Tesoreria_Informe_pedidofondos.Visible = True
                Tesoreria_Informe_pedidofondos.Logo_picturebox.Select()
                generacionpdf_actualizarpedido()
                'PDFPEDIDODEFONDO(CType(Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview, DataGridView), "Reporte Rapido", False, "LEGAL")
                'GeneraciondepedidodefondosPDF()
        End Select
        Tesoreria_Informe_pedidofondos.Pedidodefondos_panel.Visible = False
        Tesoreria_Informe_pedidofondos.Visible = False
    End Sub

    Private Function CeldaFirmaPDF(ByVal Cargo_Nombre As String) As iTextSharp.text.pdf.PdfPCell
        Dim font10BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        'Dim Phrasetemporal As New iTextSharp.text.Phrase()
        'Phrasetemporal.Add(New iTextSharp.text.Chunk("__________________________" & vbNewLine, font12Bold))
        'Phrasetemporal.Add(New iTextSharp.text.Chunk(Cargo_Nombre, font12BoldSUAVE))
        Dim PdfPCellfirma As New iTextSharp.text.pdf.PdfPCell
        PdfPCellfirma.AddElement(New iTextSharp.text.Phrase("__________________________" & vbNewLine, font10Bold))
        PdfPCellfirma.AddElement(New iTextSharp.text.Phrase(Cargo_Nombre, font10BoldSUAVE))
        With PdfPCellfirma
            .BorderWidth = 0
            .FixedHeight = 60.0F
        End With
        PdfPCellfirma.VerticalAlignment = Element.ALIGN_BOTTOM
        PdfPCellfirma.HorizontalAlignment = Element.ALIGN_CENTER
        Return PdfPCellfirma
    End Function

    Private Function Datospedidofondos_datatable() As DataTable
        Dim Pedidodefondos_datatable As New DataTable
        'Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
        '    Case True
        'estructura de pedidos de fondos en caso de ser parcial
        Pedidodefondos_datatable.Columns.Add("Nº")
        Pedidodefondos_datatable.Columns.Add("Rubro")
        Pedidodefondos_datatable.Columns.Add("Proveedor")
        Pedidodefondos_datatable.Columns.Add("Expediente Nº")
        Pedidodefondos_datatable.Columns.Add("CUIT")
        Pedidodefondos_datatable.Columns.Add("Concepto")
        Pedidodefondos_datatable.Columns.Add("Orden Pago/Cargo")
        Pedidodefondos_datatable.Columns.Add("Importe", System.Type.GetType("System.Decimal"))
        For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
            Pedidodefondos_datatable.Rows.Add()
            Pedidodefondos_datatable.Rows(X).Item("Nº") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("RUBRO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Rubro").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("Expediente Nº") = Expedientesasociados_datagridview.Rows(X).Cells.Item("expediente_N").Value.ToString
            If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("HABERES").Value = 0 Then
                Pedidodefondos_datatable.Rows(X).Item("CUIT") = Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT").Value.ToString
            Else
                Pedidodefondos_datatable.Rows(X).Item("CUIT") = Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT.").Value.ToString
            End If
            Pedidodefondos_datatable.Rows(X).Item("Proveedor") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("Concepto") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString
            If Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString.Length > 0 Then
                Pedidodefondos_datatable.Rows(X).Item("Orden Pago/Cargo") = "O.Nº " & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ""
            Else
                ' If Expedientesasociados_datagridview.Rows(X).Cells.Item("OrdenCargo").Value.ToString.Length > 0 Then
                '    Pedidodefondos_datatable.Rows(X).Item("Orden") = "O.C.Nº " & Expedientesasociados_datagridview.Rows(X).Cells.Item("OrdenCargo").Value.ToString & ""
                'Else
                Pedidodefondos_datatable.Rows(X).Item("Orden Pago/Cargo") = ""
                '    End If
            End If
            'Pedidodefondos_datatable.Rows(X).Item("Importe") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto2").Value.ToString), 2,, TriState.True, TriState.True)
            Pedidodefondos_datatable.Rows(X).Item("Importe") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto").Value
        Next
        Return (Pedidodefondos_datatable)
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.DataSource = Pedidodefondos_datatable
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("N").Width = 22
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("RUBRO").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("Expediente N").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CUIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("IMPORTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '/estructura de pedidos de fondos
        'Case False
        '    'estructura de pedidos de fondos caso habitual
        '    Pedidodefondos_datatable.Columns.Add("N")
        '    Pedidodefondos_datatable.Columns.Add("RUBRO")
        '    Pedidodefondos_datatable.Columns.Add("PROVEEDOR")
        '    Pedidodefondos_datatable.Columns.Add("CONCEPTO")
        '    Pedidodefondos_datatable.Columns.Add("IMPORTE")
        '    For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
        '        Pedidodefondos_datatable.Rows.Add()
        '        Pedidodefondos_datatable.Rows(X).Item("N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
        '        Pedidodefondos_datatable.Rows(X).Item("RUBRO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Rubro").Value.ToString
        '        ' If IsNothing(Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value) Or IsDBNull(Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value) Then
        '        ' Se desactiva el número de proveedor para los casos de pedido de fondo por no poder controlar el hecho de que pueden existir expedientes con más de 20 o 30 proveedores lo que derrota el proposito del control
        '        Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = "-"
        '        '  Else
        '        '       Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
        '        ' End If
        '        Pedidodefondos_datatable.Rows(X).Item("CONCEPTO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString &
        '    "-(" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Expediente_N").Value.ToString & ")" &
        '    "( O.N" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ")"
        '        Pedidodefondos_datatable.Rows(X).Item("IMPORTE") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto2").Value.ToString), 2,, TriState.True, TriState.True)
        '    Next
        Return (Pedidodefondos_datatable)
        'End Select
    End Function

    Private Function Clasedefondo() As DataTable
        Dim Pedidodefondos_datatable As New DataTable
        'Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
        '    Case True
        'estructura de pedidos de fondos en caso de ser parcial
        Pedidodefondos_datatable.Columns.Add("Nº")
        Pedidodefondos_datatable.Columns.Add("Rubro")
        Pedidodefondos_datatable.Columns.Add("Proveedor")
        Pedidodefondos_datatable.Columns.Add("Expediente Nº")
        Pedidodefondos_datatable.Columns.Add("CUIT")
        Pedidodefondos_datatable.Columns.Add("Concepto")
        Pedidodefondos_datatable.Columns.Add("Orden")
        Pedidodefondos_datatable.Columns.Add("Importe")
        For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
            Pedidodefondos_datatable.Rows.Add()
            Pedidodefondos_datatable.Rows(X).Item("Nº") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("RUBRO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Rubro").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("Expediente Nº") = Expedientesasociados_datagridview.Rows(X).Cells.Item("expediente_N").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("CUIT") = Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("Proveedor") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
            Pedidodefondos_datatable.Rows(X).Item("Concepto") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString
            If Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString.Length > 0 Then
                Pedidodefondos_datatable.Rows(X).Item("Orden") = "O.Nº " & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ""
            Else
                Pedidodefondos_datatable.Rows(X).Item("Orden") = "O.C.Nº " & Expedientesasociados_datagridview.Rows(X).Cells.Item("OrdenCargo").Value.ToString & ""
            End If
            Pedidodefondos_datatable.Rows(X).Item("Importe") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto").Value.ToString), 2,, TriState.True, TriState.True)
        Next
        Return (Pedidodefondos_datatable)
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.DataSource = Pedidodefondos_datatable
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("N").Width = 22
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("RUBRO").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("Expediente N").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CUIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("IMPORTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        'Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '/estructura de pedidos de fondos
        'Case False
        '    'estructura de pedidos de fondos caso habitual
        '    Pedidodefondos_datatable.Columns.Add("N")
        '    Pedidodefondos_datatable.Columns.Add("RUBRO")
        '    Pedidodefondos_datatable.Columns.Add("PROVEEDOR")
        '    Pedidodefondos_datatable.Columns.Add("CONCEPTO")
        '    Pedidodefondos_datatable.Columns.Add("IMPORTE")
        '    For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
        '        Pedidodefondos_datatable.Rows.Add()
        '        Pedidodefondos_datatable.Rows(X).Item("N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
        '        Pedidodefondos_datatable.Rows(X).Item("RUBRO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Rubro").Value.ToString
        '        ' If IsNothing(Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value) Or IsDBNull(Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value) Then
        '        ' Se desactiva el número de proveedor para los casos de pedido de fondo por no poder controlar el hecho de que pueden existir expedientes con más de 20 o 30 proveedores lo que derrota el proposito del control
        '        Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = "-"
        '        '  Else
        '        '       Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
        '        ' End If
        '        Pedidodefondos_datatable.Rows(X).Item("CONCEPTO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString &
        '    "-(" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Expediente_N").Value.ToString & ")" &
        '    "( O.N" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ")"
        '        Pedidodefondos_datatable.Rows(X).Item("IMPORTE") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto2").Value.ToString), 2,, TriState.True, TriState.True)
        '    Next
        Return (Pedidodefondos_datatable)
        'End Select
    End Function

    Private Sub generacionpdf_actualizarpedido()
        '
        Inicio.GENERARPDF(Tesoreria_Informe_pedidofondos.Panelgeneralpedidofondos_panel, "pedidodefondos-" & Convert.ToInt16(N_pedidofondo_numeric.Value).ToString("0000") & "-" & Tesoreria_Informe_pedidofondos.Yearpedidodefondos_textbox.Text, "prueba")
        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value)
        INSERTCOMMANDSQL.CommandText = "UPDATE PEDIDO_FONDOS SET IMPRESO=1,Usuario=@Usuario WHERE Clave_pedidofondo=@Clave_pedidofondo"
        Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
        Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
        refreshnow()
        Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
    End Sub

    Private Sub Cargatesoreriagral()
        '        Dim pedfondo As PedidoFondos
        '        Dim consulta2 As String = "Tesoreriagral;"
        '        Dim consulta As String =
        '        "DELIMITER $$
        'DROP PROCEDURE IF EXISTS `Tesoreriagral`$$
        'CREATE DEFINER = `root`@`%` PROCEDURE `Tesoreriagral`(
        'IN `@pedidofondo` char (10),
        'IN `@idorigen` int (10),
        'IN `@ordenentrega` char (10),
        'IN `@fechaing` date,
        'IN `@fechaven` date,
        'IN `@fechault` date,
        'IN `@desdeuda` varchar (60),
        'IN `@observa` varchar (40),
        'IN `@cuenta` varchar (15),
        'IN `@Importe_solicitado` decimal (15),
        'IN `@expediente` char (10),
        'IN `@ejercicio` int (10),
        'IN `@idimputac1` int (10),
        'IN `@idimputac2` int (10),
        'IN `@idimputac3` int (10),
        'IN `@idimputac4` int (10),
        'IN `@detalle` varchar (60),
        'IN `@contpedifondo` varchar (10),
        'IN `@contano` varchar (10)
        ')
        'BEGIN
        'If NOT EXISTS   (Select idpedidofondo from pedidos where pedidofondo=@pedidofondo and idorigen=@idorigen)  THEN
        'Insert INTO pedidos
        '(pedidofondo,
        'idorigen,
        'ordenentrega,
        'fechaing,
        'fechaven,
        'fechault,
        'desdeuda,
        'observa,
        'cuenta,
        'Importe_solicitado,
        'expediente,
        'ejercicio,
        'idimputac1,
        'idimputac2,
        'idimputac3,
        'idimputac4,
        'detalle,
        'contpedifondo,
        'contano
        ')
        'VALUES
        '(@pedidofondo,
        '@idorigen,
        '@ordenentrega,
        '@fechaing,
        '@fechaven,
        '@fechault,
        '@desdeuda,
        '@observa,
        '@cuenta,
        '@Importe_solicitado,
        '@expediente,
        '@ejercicio,
        '@idimputac1,
        '@idimputac2,
        '@idimputac3,
        '@idimputac4,
        '@detalle,
        '@contpedifondo,
        '@contano);
        'ELSE
        'UPDATE
        'pedidos SET
        'ordenentrega=@ordenentrega,
        'observa=@observa,
        'cuenta=@cuenta,
        'Importe_solicitado=@Importe_solicitado,
        'expediente=@expediente,
        'ejercicio=@ejercicio,
        'detalle=@detalle
        'where pedidofondo=@pedidofondo and idorigen=@idorigen ;
        'END IF;
        'END $$
        'DELIMITER ;"
        '        For x = 0 To Datosspedidofondo_datagridview.Rows.Count - 1
        '            'SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = consulta2
        '            'SERVIDORMYSQL.INSERTCOMMANDSQL.CommandType = CommandType.Text
        '            'Inicio.INSERTSQLPARAMETROS("Tesoantesala", "Carga TesoreriaGral")
        '            pedfondo = New PedidoFondos(Datosspedidofondo_datagridview.Rows(x).Cells.Item("Clave_pedidofondo").Value.ToString, Datosspedidofondo_datagridview.Rows(x).Cells.Item("Numero de Expediente").Value)
        '            pedfondo.N_pedidofondo = pedfondo.N_pedidofondo
        '            pedfondo.YearPedidoFondo = pedfondo.Year_pedidofondo
        '            pedfondo.Fecha_pedido = Datosspedidofondo_datagridview.Rows(x).Cells.Item("Fecha_pedido").Value
        '            pedfondo.Cuenta_pedidofondo = Datosspedidofondo_datagridview.Rows(x).Cells.Item("Cuenta_pedidofondo").Value
        '            pedfondo.ExpteOrganismo = pedfondo.ExpteOrganismo
        '            pedfondo.ExpteNumero = pedfondo.ExpteNumero
        '            pedfondo.ExpteYear = pedfondo.ExpteYear
        '            pedfondo.Descripcion = Datosspedidofondo_datagridview.Rows(x).Cells.Item("Descripcion").Value
        '            pedfondo.Monto_pedidofondo = Datosspedidofondo_datagridview.Rows(x).Cells.Item("Monto_pedidofondo").Value
        '            If Datosspedidofondo_datagridview.Rows(x).Cells.Item("clase_fondo").Value.ToString.Length = 4 Then
        '                pedfondo.Clase_fondo = Datosspedidofondo_datagridview.Rows(x).Cells.Item("clase_fondo").Value
        '            Else
        '                pedfondo.Clase_fondo = Date.Now.Year
        '            End If
        '            pedfondo.Parcial = Datosspedidofondo_datagridview.Rows(x).Cells.Item("Parcial").Value
        '            pedfondo.Haberes = Datosspedidofondo_datagridview.Rows(x).Cells.Item("Haberes").Value
        '            ''  SERVIDORMYSQL.INSERTCOMMANDSQL.CommandType = CommandType.StoredProcedure
        '            'SERVIDORMYSQL.INSERTCOMMANDSQL.
        '            Dim parametros(19) As MySql.Data.MySqlClient.MySqlParameter
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@N_pedidofondo", CType(N_pedidofondo_numeric.Text, Integer))
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Pedidofondo", CType(pedfondo.N_pedidofondo.ToString, Integer))
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idorigen", CType(Autorizaciones.Organismo.tostring.substring(0,4), Integer))
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ordenentrega", CType(0, Integer))
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fechaing", CType(Date.Now, Date))
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fechaven", CType(Date.Now, Date))
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@fechault", CType(Date.Now, Date))
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@desdeuda", DBNull.Value)
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@observa", DBNull.Value)
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@cuenta", pedfondo.Cuenta_pedidofondo.ToString)
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Importe_solicitado", pedfondo.Monto_pedidofondo.ToString)
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente", pedfondo.ExpteNumero)
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@ejercicio", pedfondo.Year_pedidofondo)
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac1", "0")
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac2", "0")
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac3", "0")
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@idimputac4", "0")
        '            If pedfondo.Descripcion.ToString.Length > 60 Then
        '                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@detalle", pedfondo.Descripcion.ToString.Substring(0, 60))
        '            Else
        '                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@detalle", pedfondo.Descripcion.ToString)
        '            End If
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@contpedifondo", "s/d")
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@contano", "s/d")
        '            For Z = 0 To SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Count - 1
        '                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.Item(Z).Direction = ParameterDirection.Input
        '            Next
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandType = CommandType.Text
        '            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = consulta
        '            Inicio.INSERTSQLPARAMETROS("Tesoantesala", "Carga TesoreriaGral")
        '        Nextb
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandType = CommandType.Text
        Dim VALORES As String = " "
        Dim consulta As String = " INSERT INTO Contaduria_pedidosfondos_detalle
(N_pedidoFondo,
        A_pedidoFondo,
        Orden,
        Org_Origen,
        Origenexpcod,
        Origenexpnum,
        FechaIngreso,
        ordendeentrega,
        Clase_fondo,
        Cuit_proveedor,
        Detalle_proveedor,
        Monto,
        Rubro)
VALUES "
        For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@N_pedidoFondo" & X, CInt(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CLAVE_PEDIDOFONDO").Value.ToString.Substring(8, 5)))
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@A_pedidoFondo" & X, CInt(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CLAVE_PEDIDOFONDO").Value.ToString.Substring(0, 4)))
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Orden" & X, Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value)
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Org_Origen" & X, Autorizaciones.Organismo.ToString.Substring(0, 4))
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Origenexpcod" & X, Expedientesasociados_datagridview.Rows(X).Cells.Item("CLAVE_EXPEDIENTE").Value.ToString.Substring(4, 4))
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Origenexpnum" & X, CInt(Expedientesasociados_datagridview.Rows(X).Cells.Item("CLAVE_EXPEDIENTE").Value.ToString.Substring(8, 5)))
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@FechaIngreso" & X, Date.Now)
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@ordendeentrega" & X, 0)
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Clase_fondo" & X, Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CLASE_FONDO").Value)
            If pedfondoseleccionado.Haberes Then
                TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Cuit_proveedor" & X, "99")
            Else
                TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Cuit_proveedor" & X, Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT").Value)
            End If
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Detalle_proveedor" & X, Expedientesasociados_datagridview.Rows(X).Cells.Item("DETALLE").Value)
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Monto" & X, Expedientesasociados_datagridview.Rows(X).Cells.Item("MONTO").Value)
            TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.AddWithValue("@Rubro" & X, Expedientesasociados_datagridview.Rows(X).Cells.Item("RUBRO").Value)
            VALORES += "
(@N_pedidoFondo" & X & "," &
        "@A_pedidoFondo" & X & "," &
        "@Orden" & X & "," &
        "@Org_Origen" & X & "," &
        "@Origenexpcod" & X & "," &
        "@Origenexpnum" & X & "," &
        "@FechaIngreso" & X & "," &
        "@ordendeentrega" & X & "," &
        "@Clase_fondo" & X & "," &
        "@Cuit_proveedor" & X & "," &
        "@Detalle_proveedor" & X & "," &
        "@Monto" & X & "," &
        "@Rubro" & X & ")"
            If Not X = Expedientesasociados_datagridview.Rows.Count - 1 Then
                VALORES += " , "
            Else
                VALORES += " ON DUPLICATE KEY UPDATE
Origenexpcod=VALUES(Origenexpcod),
Clase_fondO=VALUES(Clase_fondo),
CUIT_PROVEEDOR=VALUES(CUIT_PROVEEDOR),
DETALLE_PROVEEDOR=VALUES(DETALLE_PROVEEDOR),
MONTO=VALUES(MONTO),
RUBRO=VALUES(RUBRO)"
            End If
        Next
        TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.CommandText = consulta & VALORES
        'Inicio.INSERTSQLPARAMETROSTesoreria("Tesoantesala", "Carga TesoreriaGral")
        Select Case SERVIDORMYSQL.SERVER1
            Case Is = ""
                Inicio.INSERTSQLPARAMETROSTesoreria("Tesoantesala", "Carga TesoreriaGral")
            Case Else
                TESO_SERVIDORMYSQL.INSERTCOMMANDSQLx.Parameters.Clear()
        End Select
    End Sub

    Private Sub Generarpedidodefondo_boton_Click(sender As Object, e As EventArgs) Handles Generarpedidodefondo_boton.Click
        'pedfondoseleccionado
        Dim Datos_validos As Boolean = True
        Dim Errores(8) As String
        Dim Total_errores As String = ""
        '    pedfondoseleccionado.Monto_solicitado = Convert.ToDecimal(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Monto_pedidofondo").Value.ToString)
        If Expedientesasociados_datagridview.Rows.Count > 16 Then
            If Not pedfondoseleccionado.Haberes Then
                Errores(0) = "-La cantidad de expedientes asociados a este pedido de fondo (" & Expedientesasociados_datagridview.Rows.Count & ") supera lo aceptable" & "Actualmente el límite es 12 expedientes"
                Datos_validos = False
            End If
        Else
            For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                'como estan conviviendo los datos de fondos y valores y los datos nuevos se bifurca en 2
                If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CUITs").Value.ToString = "" Then
                    If Errores(4) = "" Then
                        If Expedientesasociados_datagridview.Rows(X).Cells.Item("RUBRO").Value.ToString = "" Then
                            If Errores(4) = "" Then
                                Errores(4) = "VERIFIQUE EL RUBRO DE:"
                                Errores(4) = Errores(4) & vbNewLine & "EXPEDIENTE " & Expedientesasociados_datagridview.Rows(X).Cells.Item("Expediente_N").Value.ToString
                            Else
                                Errores(4) = Errores(4) & vbNewLine & "EXPEDIENTE " & Expedientesasociados_datagridview.Rows(X).Cells.Item("Expediente_N").Value.ToString
                            End If
                        End If
                    Else
                    End If
                End If
            Next
        End If
        If Expedientesasociados_datagridview.Rows.Count = 0 Then
            Errores(1) = "- NINGÚN EXPEDIENTE SE ENCUENTRA ASOCIADO a este pedido de fondo, por lo cual no podrá generarse"
            Datos_validos = False
        End If
        If Pedidodefondosmontowpf.Monto_textbox.Number = 0 Then
            Errores(2) = "- No se puede generar un PEDIDO DE FONDOS DE $0.00, verifique por favor los expedientes asociados y sus montos."
            Datos_validos = False
        Else
        End If
        If Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1 = True Then
            'If sumaasociada() > Verificacionmontopedidofondo(pedfondoseleccionado.clavepedidofondo) Then
            '    Errores(3) = "- El monto ingresado ($" & sumaasociada().ToString & ") para el pedido de fondo actual supera lo solicitado. ($" & Verificacionmontopedidofondo(pedfondoseleccionado.clavepedidofondo) & ")"
            '    Datos_validos = False
            'Else
            'End If
        Else
        End If
        If Datos_validos Then
            'Traslado de datos a Tesoreria General
            Cargadedatos()
            'Generar pedido de fondos
            'Generaciondepedidodefondos()
            Generaciondepedidodefondos2()
            'Try
            '    Generaciondepedidodefondosv2(pedfondoseleccionado)
            'Catch ex As Exception
            'End Try
            'Verificar Existencia y Cargar de ser necesario en BD  antesala MYSQL  Tesorería General
            'Cargatesoreriagral()
            'CARGA MEDIANTE API A TESORERÍA GENERAL
            'CARGA DE PARTIDAS SI EXISTIESEN
            pedfondoseleccionado.CargarDatosPartidas_datatable()
            'CARGA EN LA BASE DE DATOS
            'Informatica_Servidor.ApiNuevo(pedfondoseleccionado)
            Informatica_Servidor.ApiNuevo2(pedfondoseleccionado)
        Else
            For x = 0 To Errores.Count - 1
                If Not (Errores(x) = "") Then
                    Total_errores = Total_errores & vbCrLf & "-" & Errores(x)
                End If
            Next
            MessageBox.Show("Actualmente el pedido de fondo contiene los siguientes errores " & vbCrLf & Total_errores)
        End If
        '------------------------------------------------------------------------
        'Select Case Pedidodefondosmontowpf.Monto_textbox.Number > 0
        '    Case True
        '        '------------------------------------------------------------------------
        '        If pedfondoseleccionado.Monto_solicitado > Pedidodefondosmontowpf.Monto_textbox.Number Then
        '            Select Case Expedientesasociados_datagridview.Rows.Count > 12
        '                Case True
        '                    MessageBox.Show("La cantidad de expedientes asociados a este pedido de fondo (" & Expedientesasociados_datagridview.Rows.Count & ") supera lo aceptable" & "Actualmente el límite es 12 expedientes")
        '                Case False
        '                    '------------------------------------------------------------------------
        '                    Select Case Expedientesasociados_datagridview.Rows.Count = 0
        '                        Case True
        '                            MessageBox.Show("Actualmente NINGÚN EXPEDIENTE SE ENCUENTRA ASOCIADO a este pedido de fondo, por lo cual no podrá generarse")
        '                        Case False
        '                            '------------------------------------------------------------------------
        '                            Select Case MsgBox("Confirma que desea Cargar este pedido de Fondo N" & N_pedidofondo_numeric.Value, MsgBoxStyle.YesNoCancel, " ")
        '                                Case MsgBoxResult.Yes
        '                                    Generaciondepedidodefondos()
        '                                Case Else
        '                            End Select
        '                            '************************************************************************
        '                    End Select
        '                    '******************************************************************************
        '            End Select
        '            '******************************************************************************
        '        End If
        '    Case False
        '        MessageBox.Show("No se puede generar un PEDIDO DE FONDOS DE $0.00, verifique por favor los expedientes asociados y sus montos.")
        'End Select
        '******************************************************************************
    End Sub

    Private Sub Generaciondepedidodefondos2()
        Dim Pedidodefondos_datatable As New DataTable
        Dim Numdecuenta_datatable As New DataTable
        Dim Caracterdecuenta1 As New DataTable
        Dim Caracterdecuenta2 As New DataTable
        Dim Cuentadepresupuesto_datatable As New DataTable
        Dim Transferidoportesoreríageneral_datatable As New DataTable
        Dim fuente18 As Single = 18
        Dim fuente12 As Single = 12
        Dim fuente10 As Single = 10
        Dim fuente7 As Single = 7
        'declaración de Fuentes a utilizar en el archivo
        'para insertar un espacio entre las celdas
        Dim PdfpCell_espaciovacio As iTextSharp.text.pdf.PdfPCell = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente18, iTextSharp.text.Font.BOLD, BaseColor.BLACK))))
        PdfpCell_espaciovacio.BorderWidth = 0
        PdfpCell_espaciovacio.FixedHeight = 2.0F
        Dim Doc As New Document(PageSize.LEGAL, 75, 35, 18, 18)
        'Dim FileName As String = FileName
        Dim Anchopagina As Single = Doc.PageSize.Width
        Select Case Datospedidofondos_datatable.Rows.Count
            Case Is > 10
                fuente18 = 14
                fuente12 = 9
                fuente10 = 7
                fuente7 = 5
                PdfpCell_espaciovacio.FixedHeight = 1.0F
                Doc = New Document(PageSize.LEGAL, 60, 20, 10, 10)
            Case Is > 6
                fuente18 = 16
                fuente12 = 10
                fuente10 = 9
                fuente7 = 6
                PdfpCell_espaciovacio.FixedHeight = 0.0F
                Doc = New Document(PageSize.LEGAL, 70, 30, 10, 10)
            Case Else
        End Select
        Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente18, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12BoldSUAVE As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente12, iTextSharp.text.Font.BOLD Or iTextSharp.text.Font.BOLDITALIC, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")))
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font10Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font07bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, fuente7, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        PdfpCell_espaciovacio = New PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", font10Normal)))
        Dim Controlguardado As New SaveFileDialog
        With Controlguardado
            Select Case System.IO.Directory.Exists("C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & Year_pedidofondo_numeric.Value & "\")
                Case True
                Case False
                    System.IO.Directory.CreateDirectory("C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & Year_pedidofondo_numeric.Value & "\")
            End Select
            .Filter = "ARCHIVO PDF|*.pdf"
            .Title = "Guardar en archivo PDF"
            .FileName = N_pedidofondo_numeric.Value & "-" & Year_pedidofondo_numeric.Value & ".pdf"
            .RestoreDirectory = True
            .InitialDirectory = "C:" & "\" & "PEDIDOS_DE_FONDO" & "\" & Year_pedidofondo_numeric.Value & "\"
        End With
        Controlguardado.Filter = "ARCHIVO PDF|*.pdf"
        Controlguardado.Title = "Guardar en archivo PDF"
        Controlguardado.ShowDialog()
        If Controlguardado.FileName = "" Then
            MsgBox("Para poder proceder a la creación del archivo se requiere un nombre")
            Exit Sub
        Else
            Dim FileName As String = Controlguardado.FileName
            Using wri = PdfWriter.GetInstance(Doc, New FileStream(FileName, FileMode.Create))
                'Abrir el documento para el uso
                Doc.Open()
                'Insertar una página en blanco nueva
                Doc.NewPage()
                'Crear tabla General para cargar los bordes
                Dim Tabla_total As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1)
                Tabla_total.TotalWidth = Anchopagina - Doc.LeftMargin
                Tabla_total.LockedWidth = True
                Dim tamaniocolumna_total As Single() = New Single(0) {}
                tamaniocolumna_total(0) = Convert.ToSingle(Anchopagina - Doc.LeftMargin * 1)
                Tabla_total.SetWidths(tamaniocolumna_total)
                'Creación de la celda que manejaria cada uno de los cuadros
                Dim PARRAFOCOMPLETO As New iTextSharp.text.Paragraph()
                Dim Phrasetemporal As New iTextSharp.text.Phrase()
                'Crear tabla para manejar los encabezados---------------------------------------------------------------------------------------------
                Dim Encabezadosx As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                Encabezadosx.TotalWidth = Anchopagina - Doc.LeftMargin
                Encabezadosx.LockedWidth = True
                'Declaración variable de ancho de columnas
                Dim tamaniocolumna As Single() = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.8)
                Encabezadosx.SetWidths(tamaniocolumna)
                'crear imagen con logo a la izquierda
                Dim manejadorimagen As iTextSharp.text.Image = Image.GetInstance(My.Resources.Logo, Imaging.ImageFormat.Jpeg)
                'asignar la imagen itextsharp a la celda
                Dim PdfPCell As iTextSharp.text.pdf.PdfPCell = New PdfPCell(manejadorimagen, True)
                PdfPCell.Rowspan = 2
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                PdfPCell.FixedHeight = 70.0F
                Encabezadosx.AddCell(PdfPCell)
                'Encabezado del año
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Encabezadodelyear(Fecha_pedido_textbox.Value.Year), font10Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------NOMBRE DEL SERVICIO ADMINISTRATIVO------------------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, PDF_fuente_variable(12, True))))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.FixedHeight = 25.0F
                Encabezadosx.AddCell(PdfPCell)
                '----------------------AGREGA EL ENCABEZADO Completo------------------------------
                ' Frase_total.Clear()
                PARRAFOCOMPLETO.Add(Encabezadosx)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                ' Doc.Add(Encabezadosx)
                '----------------------ORDEN DE ENTREGA DE FONDOS------------------------------
                Dim Ordenentregafondos As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(4)
                Ordenentregafondos.TotalWidth = Anchopagina - Doc.LeftMargin
                Ordenentregafondos.LockedWidth = True
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.3)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.2)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.3)
                Ordenentregafondos.SetWidths(tamaniocolumna)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("ORDEN DE ENTREGA DE FONDOS Nº", font07Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                Ordenentregafondos.AddCell(PdfPCell)
                '
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", font10Normal)))
                PdfPCell.BorderWidth = 1
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                Ordenentregafondos.AddCell(PdfPCell)
                '
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", font10Normal)))
                PdfPCell.BorderWidth = 1
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                Ordenentregafondos.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("     FECHA:", font10Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_LEFT
                Ordenentregafondos.AddCell(PdfPCell)
                '----------------------AGREGA ORDEN DE ENTREGA------------------------------
                'Frase_total.Clear()
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(Ordenentregafondos)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                '----------------------Nº pedido de fondos------------------------------
                Dim Espaciodescripcionpedidofondo As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                Espaciodescripcionpedidofondo.TotalWidth = Anchopagina - Doc.LeftMargin
                Espaciodescripcionpedidofondo.LockedWidth = True
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.33)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.34)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.33)
                Espaciodescripcionpedidofondo.SetWidths(tamaniocolumna)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("PEDIDO DE FONDOS Nº", font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 30
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Rowspan = 1
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                '----------------------TABLA CENTRAL DE PEDIDO DE FONDOS CON NRO ----------------------
                Dim Nropedidofondo As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(6)
                'nro de pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(N_pedidofondo_numeric.Value.ToString, titleFont)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 3
                PdfPCell.FixedHeight = 25
                Nropedidofondo.AddCell(PdfPCell)
                'año de pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Year_pedidofondo_numeric.Value, titleFont)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 3
                PdfPCell.FixedHeight = 25
                Nropedidofondo.AddCell(PdfPCell)
                '----------------------numero del organismo del expediente del pedido de fondo----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Organismo, font10Bold)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                'numero del expediente dentro del organismo del pedido de fondos----------------------
                '   PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Expte_numero_numericupdown.Value.ToString, font10Bold)))
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", font10Bold)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                'Año del expediente de pedido de fondos.----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Year_pedidofondo_numeric.Value.ToString, font10Bold)))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 2
                PdfPCell.FixedHeight = 15
                Nropedidofondo.AddCell(PdfPCell)
                tamaniocolumna = New Single(5) {}
                tamaniocolumna(0) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(1) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(2) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(3) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(4) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                tamaniocolumna(5) = Convert.ToSingle((Anchopagina * 0.33 * 0.33) / 2)
                Nropedidofondo.SetWidths(tamaniocolumna)
                '----------------------AGREGA LA TABLA DE DATOS DEL PEDIDO DE FONDOS----------------------
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(Nropedidofondo)
                PdfPCell.BorderWidth = 0
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Rowspan = 2
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                'AGREGA LA FECHA DEL PEDIDO DE FONDOS
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("FECHA:" & Convert.ToDateTime(Fecha_pedido_textbox.Value).ToString("dd/MM/yyyy"), font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.Rowspan = 2
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                'AGREGA LA fRASE EXPEDIENTE Nro
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Expediente Nº", font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Rowspan = 1
                Espaciodescripcionpedidofondo.AddCell(PdfPCell)
                '----------------------AGREGA DATOS FORMALES PEDIDO DE FONDO-----------------------------
                'Frase_total.Clear()
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(Espaciodescripcionpedidofondo)
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("Sr.CONTADOR GENERAL DE LA PROVINCIA ", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("De acuerdo a la ", font10Normal))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("LEY DE CONTABILIDAD", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(", solicitamos las siguientes TRANSFERENCIAS de Fondos: ", font10Normal))
                'tabla: pedido de fondos con total (5 columnas, con una ultima que tiene un column span de 4 sin borde y el total con borde
                'Evaluar el caso del tipo de pedido de fondo para realizar la confección
                'Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
                '    Case True
                'para lograr la adaptación completa debo disminuir el margen necesario
                Dim anchoutil As Single = Anchopagina - Doc.LeftMargin
                tamaniocolumna = New Single(7) {}
                tamaniocolumna(0) = Convert.ToSingle(anchoutil * 0.03) 'Nº
                tamaniocolumna(1) = Convert.ToSingle(anchoutil * 0.05) 'Rubro
                tamaniocolumna(2) = Convert.ToSingle(anchoutil * 0.07) 'Proveedor
                tamaniocolumna(3) = Convert.ToSingle(anchoutil * 0.15) ' EXPEDIENTE
                tamaniocolumna(4) = Convert.ToSingle(anchoutil * 0.1) ' CUIT
                tamaniocolumna(5) = Convert.ToSingle(anchoutil * 0.3) 'Concepto
                tamaniocolumna(6) = Convert.ToSingle(anchoutil * 0.12) 'orden
                tamaniocolumna(7) = Convert.ToSingle(anchoutil * 0.15) 'IMPORTE
                '    Case False
                '        tamaniocolumna = New Single(4) {}
                '        tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.05) 'Nº
                '        tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.1) 'Rubro
                '        tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1) 'Proveedor
                '        tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.65) ' Concepto
                '        tamaniocolumna(4) = Convert.ToSingle(Anchopagina * 0.1) ' Importe
                'End Select
                '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
                Dim tablapedidodefondos As iTextSharp.text.pdf.PdfPTable
                Select Case Datospedidofondos_datatable.Rows.Count
                    Case Is > 12
                        tablapedidodefondos = PDFDatatable(Datospedidofondos_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 6, True)
                    Case Is > 7
                        tablapedidodefondos = PDFDatatable(Datospedidofondos_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 7, True)
                    Case Else
                        tablapedidodefondos = PDFDatatable(Datospedidofondos_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, True, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 8, True)
                End Select
                '---------------------------------------------TABLA CON TODOS LOS DATOS-----------------------------------------------------------------------------------------------
                'agrega la celda de Valor total a la tabla
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = tamaniocolumna.Count - 1
                'agrega la celda total
                tablapedidodefondos.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True), font10Bold))
                PdfPCell.BorderWidth = 0.5
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 1
                'Agrega la celda con el total sumado
                tablapedidodefondos.AddCell(PdfPCell)
                'Agrega tabla de pedido de fondos
                PARRAFOCOMPLETO.Add(tablapedidodefondos)
                'Tabla: Caracter de la cuenta
                'Tabla+--------------------------------------------------------------------------------------------------------------------------------------------
                Dim Deudaconoajuste_fechavencimiento As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3)
                tamaniocolumna = New Single(2) {}
                tamaniocolumna(0) = Convert.ToSingle((Anchopagina * 0.2))
                tamaniocolumna(1) = Convert.ToSingle((Anchopagina * 0.2))
                tamaniocolumna(2) = Convert.ToSingle((Anchopagina * 0.6))
                Deudaconoajuste_fechavencimiento.SetWidths(tamaniocolumna)
                Deudaconoajuste_fechavencimiento.TotalWidth = Anchopagina - Doc.LeftMargin
                Deudaconoajuste_fechavencimiento.LockedWidth = True
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("Fecha de Vencimiento  ", font07Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("__/__/____", font10Bold)))
                PdfPCell.BorderWidth = 0.25
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                'Anteriormente Deuda con ajuste, pero debido aque no existen actualmente ajustes por inflación  se Vacia
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(" ", font07Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Deudaconoajuste_fechavencimiento.AddCell(PdfPCell)
                PARRAFOCOMPLETO.Add(Deudaconoajuste_fechavencimiento)
                'PARRAFOCOMPLETO.Add(New iTextSharp.text.Phrase(" " & vbNewLine, font07Normal))
                'Tabla+--------------------------------------------------------CUENTA BANCARIA N°------------------------------------------------------------------------------------
                Dim CuentaBancariatabla_wrap As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
                CuentaBancariatabla_wrap.TotalWidth = Anchopagina - Doc.LeftMargin
                Dim tamaniocolumna_CuentaBancariatabla_wrap As Single() = New Single(1) {}
                tamaniocolumna_CuentaBancariatabla_wrap(0) = Convert.ToSingle((Anchopagina * 0.3))
                tamaniocolumna_CuentaBancariatabla_wrap(1) = Convert.ToSingle((Anchopagina * 0.7))
                CuentaBancariatabla_wrap.SetWidths(tamaniocolumna_CuentaBancariatabla_wrap)
                CuentaBancariatabla_wrap.LockedWidth = True
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("A DEPOSITAR EN LA CUENTA N°", font07Normal)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 15
                PdfPCell.Colspan = 1
                'agrega la celda total
                CuentaBancariatabla_wrap.AddCell(PdfPCell)
                Dim CuentaBancariatabla As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CUENTA_PEDIDOFONDO").Value.ToString.Length)
                tamaniocolumna = New Single(Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Length - 1) {}
                For X = 0 To Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Length - 1
                    tamaniocolumna(X) = Convert.ToSingle((Anchopagina * 0.7) / Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Length - 1)
                Next
                CuentaBancariatabla.SetWidths(tamaniocolumna)
                For x = 0 To Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString.Length - 1
                    'CuentaBancariatabla.AddCell((New iTextSharp.text.Phrase(New iTextSharp.text.Chunk(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CUENTA_PEDIDOFONDO").Value.ToString.Chars(x), font12Bold))))
                    CuentaBancariatabla.AddCell(Phrasepdf(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CUENTA_PEDIDOFONDO").Value.ToString.Chars(x), 10, True, 0.5, 1, 1, Element.ALIGN_CENTER, 2, Element.ALIGN_MIDDLE))
                Next
                CuentaBancariatabla.SetWidths(tamaniocolumna)
                With CuentaBancariatabla
                    .HorizontalAlignment = 1
                End With
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(CuentaBancariatabla)
                PdfPCell.BorderWidth = 0.5
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                CuentaBancariatabla_wrap.AddCell(PdfPCell)
                PARRAFOCOMPLETO.Add(CuentaBancariatabla_wrap)
                'agrega el caracter de la cuenta al parrafo
                'estructura de Caracter
                Caracterdecuenta1.Columns.Add("CARACTER")
                Caracterdecuenta1.Columns.Add("NUMERO")
                Caracterdecuenta1.Columns.Add("CUENTA")
                Caracterdecuenta1.Columns.Add("CUENTA_DETALLE")
                Caracterdecuenta1.Rows.Add()
                Caracterdecuenta1.Rows(0).Item("CARACTER") = "CÁRACTER"
                Caracterdecuenta1.Rows(0).Item("NUMERO") = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
                Caracterdecuenta1.Rows(0).Item("CUENTA") = "CUENTA:"
                Caracterdecuenta1.Rows(0).Item("CUENTA_DETALLE") = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Cuentadescripcion").Value.ToString
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.05)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.75)
                Dim Caracterdecuenta1pdftable As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Caracterdecuenta1, tamaniocolumna, 2, Anchopagina - (Doc.LeftMargin + 4), False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9)
                PARRAFOCOMPLETO.Add(Caracterdecuenta1pdftable)
                '                autorizadas Por el servicio administrativo
                ''agregar las tablas DE firmas al parrafo
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "TESORERO", "DIRECTOR"))
                End With
                'agregar parrafo de datos del pedido de fondo al documento
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 0, 3)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'Parrafo de Certificación por el Delegado Fiscal
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("CERTIFICO: ", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("Que la documentación pertinente del Pedido ha sido verificada en forma integral, no mereciendo observaciones que formular", font10Normal))
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "", "DELEGADO FISCAL"))
                End With
                'agregar las tablas DE firmas al parrafo
                'agregar parrafo de Certificación por el Delegado Fiscal
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 0, 3)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                'Parrafo correspondiente a la Tesorería General de la provincia
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("TRANSFIERESE POR LA TESORERIA GENERAL DE LA PROVINCIA ", font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(": a favor del ", font10Normal))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(Nombrecompletodelservicio.ToUpper, font10Bold))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(" con cargo de oportuna y documentada rendición de cuentas con ", font10Normal))
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("IMPUTACIÓN ", font10Bold))
                'agrega el caracter de la cuenta al parrafo
                'estructura de Caracter
                Caracterdecuenta2.Columns.Add("CARACTER")
                Caracterdecuenta2.Columns.Add("NUMERO")
                Caracterdecuenta2.Columns.Add("CUENTA")
                Caracterdecuenta2.Columns.Add("CUENTA_DETALLE")
                Caracterdecuenta2.Rows.Add()
                Caracterdecuenta2.Rows(0).Item("CARACTER") = "CÁRACTER"
                Caracterdecuenta2.Rows(0).Item("NUMERO") = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
                Caracterdecuenta2.Rows(0).Item("CUENTA") = "CUENTA:"
                Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
                    Case Is = "0"
                        Caracterdecuenta2.Rows(0).Item(3) = "SIN AFECTACIÓN ESPECIAL"
                    Case Else
                        Caracterdecuenta2.Rows(0).Item("CUENTA_DETALLE") = "CON AFECTACIÓN ESPECIAL -" & vbNewLine & Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("CUENTADESCRIPCION").Value
                End Select
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.05)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.75)
                Dim Caracterdecuenta2pdftable As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Caracterdecuenta2, tamaniocolumna, 2, Anchopagina - (Doc.LeftMargin + 4), False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9)
                PARRAFOCOMPLETO.Add(Caracterdecuenta2pdftable)
                ''estructura de cuentadepresupuesto
                'Cuentadepresupuesto_datatable.Columns.Add("CONCEPTO")
                'Cuentadepresupuesto_datatable.Columns.Add("IMPORTES")
                'Cuentadepresupuesto_datatable.Rows.Add()
                'If Year_pedidofondo_numeric.Value.ToString = Clasefondo_textbox.Text Then
                '    Cuentadepresupuesto_datatable.Rows(0).Item("CONCEPTO") = "CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value
                'Else
                '    Cuentadepresupuesto_datatable.Rows(0).Item("CONCEPTO") = "CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value & vbNewLine & "RESIDUOS PASIVOS AÑO " & Clasefondo_textbox.Text
                'End If
                'Cuentadepresupuesto_datatable.Rows(0).Item("IMPORTES") = FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True)
                ''/estructura de cuentadepresupuesto
                'tamaniocolumna = New Single(1) {}
                'tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.7)
                'tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.3)
                'Dim Cuentadepresupuesto As iTextSharp.text.pdf.PdfPTable = PDFDatatable(Cuentadepresupuesto_datatable, tamaniocolumna, 2, Anchopagina - Doc.LeftMargin, False, New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0")), 9)
                Dim parrafotemporal As New iTextSharp.text.Paragraph
                '---------------------------------------------------------------------
                tamaniocolumna = New Single(1) {}
                tamaniocolumna(0) = Convert.ToSingle((Anchopagina - Doc.LeftMargin) * 0.7)
                tamaniocolumna(1) = Convert.ToSingle((Anchopagina - Doc.LeftMargin) * 0.3)
                Dim Cuentadepresupuesto As iTextSharp.text.pdf.PdfPTable = New PdfPTable(tamaniocolumna.Length)
                'fix the absolute width of the table
                Cuentadepresupuesto.TotalWidth = Anchopagina - Doc.LeftMargin
                Cuentadepresupuesto.SetWidths(tamaniocolumna)
                Cuentadepresupuesto.LockedWidth = True
                'relative col widths in proportions
                ' PdfTable.SetWidths(widths)
                Cuentadepresupuesto.HorizontalAlignment = 1 ' 0 --> Left, 1 --> Center, 2 --> Right
                Cuentadepresupuesto.SpacingBefore = 2
                'Declaración de celdas.
                'Agregar los datos del DATATABLE a la tabla ITEXTSHARP_PDF
                PdfPCell = Nothing
                If Clasefondo_textbox.Text.Length = 4 Then
                    If Year_pedidofondo_numeric.Value.ToString = Clasefondo_textbox.Text Then
                        parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value, PDF_fuente_variable(9, False))))
                    Else
                        'parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value, PDF_fuente_variable(9, False))))
                        parrafotemporal.Add((New Phrase(vbNewLine & "RESIDUOS PASIVOS AÑO " & Clasefondo_textbox.Text, PDF_fuente_variable(9, True))))
                    End If
                Else
                    parrafotemporal.Add((New Phrase("CUENTA DE PRESUPUESTO EJERCICIO AÑO " & Year_pedidofondo_numeric.Value, PDF_fuente_variable(9, False))))
                End If
                parrafotemporal.Add((New Phrase("", PDF_fuente_variable(9, False))))
                parrafotemporal.Alignment = 1
                PdfPCell = ((Elementopdf_a_Celda_conborde(parrafotemporal, 0.5, 1, 1, 1, 3)))
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Cuentadepresupuesto.AddCell(PdfPCell)
                parrafotemporal.Clear()
                '
                PdfPCell = Nothing
                parrafotemporal.Add((New Phrase(FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True), PDF_fuente_variable(9, False))))
                parrafotemporal.Add((New Phrase("", PDF_fuente_variable(9, False))))
                parrafotemporal.Alignment = 1
                PdfPCell = ((Elementopdf_a_Celda_conborde(parrafotemporal, 0.5, 1, 1, Element.ALIGN_RIGHT, 3, 5)))
                PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE
                Cuentadepresupuesto.AddCell(PdfPCell)
                '----------------------------------------------------------------------
                parrafotemporal.Clear()
                '
                PdfPCell = Nothing
                'agrega la celda de Valor total a la tabla
                PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("TOTAL", font10Bold)))
                PdfPCell.BorderWidth = 0
                PdfPCell.FixedHeight = 18
                PdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT
                PdfPCell.Colspan = 1
                'agrega la celda total
                Cuentadepresupuesto.AddCell(PdfPCell)
                'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True), font10Bold))
                'PdfPCell.BorderWidth = 0.5
                'PdfPCell.FixedHeight = 18
                'PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER
                'PdfPCell.Colspan = 1
                'Agrega la celda con el total sumado
                'Cuentadepresupuesto.AddCell(PdfPCell)
                Cuentadepresupuesto.AddCell(Phrasepdf(FormatCurrency(Pedidodefondosmontowpf.Monto_textbox.Number, 2,, TriState.True, TriState.True), 10, True, 0.5, 2, 1, Element.ALIGN_CENTER, 4, Element.ALIGN_MIDDLE))
                With PARRAFOCOMPLETO
                    .Add(Cuentadepresupuesto)
                End With
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("SON PESOS: " & Inicio.Num2Text(Math.Truncate(Convert.ToDecimal(Pedidodefondosmontowpf.Monto_textbox.Number))) & " CON " &
            ((Convert.ToDecimal(Pedidodefondosmontowpf.Monto_textbox.Number) - Math.Truncate(Convert.ToDecimal(Pedidodefondosmontowpf.Monto_textbox.Number))) * 100).ToString("00") & "/100.-", font10Bold))
                'Firmas autorizadas Por cONTADURIA
                With PARRAFOCOMPLETO
                    .Add(PDFFIRMAS(Anchopagina - Doc.LeftMargin, "Responsable Transf. Fondos", "CONTADOR GENERAL"))
                End With
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5, 1, 1, 0, 2)))
                Tabla_total.AddCell(PdfpCell_espaciovacio)
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk("TRANSFERIDO POR LA TESORERÍA GENERAL", font10Bold))
                '------------------------------------------------------------------------------------
                'estructura de Tesorería General de la provincia
                PdfPCell = Nothing
                Transferidoportesoreríageneral_datatable.Columns.Add("FECHA")
                Transferidoportesoreríageneral_datatable.Columns.Add("CUENTA Nº")
                Transferidoportesoreríageneral_datatable.Columns.Add("CHEQUE Nº")
                Transferidoportesoreríageneral_datatable.Columns.Add("IMPORTE")
                Dim Transferidoportesoreríageneral As iTextSharp.text.pdf.PdfPTable = New PdfPTable(4)
                Transferidoportesoreríageneral.TotalWidth = Anchopagina - (Doc.LeftMargin + 6)
                Transferidoportesoreríageneral.LockedWidth = True
                tamaniocolumna = New Single(3) {}
                tamaniocolumna(0) = Convert.ToSingle(Anchopagina * 0.1)
                tamaniocolumna(1) = Convert.ToSingle(Anchopagina * 0.4)
                tamaniocolumna(2) = Convert.ToSingle(Anchopagina * 0.4)
                tamaniocolumna(3) = Convert.ToSingle(Anchopagina * 0.1)
                Transferidoportesoreríageneral.SetWidths(tamaniocolumna)
                '----------------------------------------------ENCABEZADO DE TABLA DE TRANSFERENCIA TESORERIA GENERAL-----------------
                For X = 0 To Transferidoportesoreríageneral_datatable.Columns.Count - 1
                    'Asignación de valores a cada celda como frases.
                    PdfPCell = New PdfPCell(New Phrase(New Chunk(Transferidoportesoreríageneral_datatable.Columns(X).Caption, font10Bold)))
                    'Alignment of phrase in the pdfcell
                    PdfPCell.HorizontalAlignment = 1
                    PdfPCell.BackgroundColor = New iTextSharp.text.BaseColor(ColorTranslator.FromHtml("#c5c7c0"))
                    'Add pdfcell in pdftable
                    Transferidoportesoreríageneral.AddCell(PdfPCell)
                Next
                Transferidoportesoreríageneral.HeaderRows = 1
                PdfPCell = New PdfPCell(New Phrase(New Chunk(" ", font07Normal)))
                PdfPCell.FixedHeight = 12
                For x = 0 To 23
                    Transferidoportesoreríageneral.AddCell(PdfPCell)
                Next
                With PARRAFOCOMPLETO
                    .Add(Transferidoportesoreríageneral)
                    .Alignment = Element.ALIGN_CENTER
                End With
                Tabla_total.AddCell(New PdfPCell(Elementopdf_a_Celda_conborde(PARRAFOCOMPLETO, 0.5)))
                '/estructura de Tesorería General de la provincia
                'Agregar Tabla al final de la generación del documento
                Doc.Add(Tabla_total)
                Dim textoQR As String = Autorizaciones.Nombrecompletodelservicio.ToUpper & vbNewLine & "Pedido de Fondos Nº" & N_pedidofondo_numeric.Value & "/" & Year_pedidofondo_numeric.Value & vbNewLine & " por:" & Pedidodefondosmontowpf.Monto_textbox.Text.ToString
                For x = 0 To Expedientesasociados_datagridview.Rows.Count - 1
                    textoQR = textoQR & vbNewLine & Expedientesasociados_datagridview.Rows(x).Cells.Item("expediente_N").Value.ToString & " / " &
                        Expedientesasociados_datagridview.Rows(x).Cells.Item("CUIT").Value.ToString & " / " & FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(x).Cells.Item("Monto").Value.ToString), 2,, TriState.True, TriState.True)
                Next
                ''Agregar imagen QR
                'Dim TablaQR As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(3) With {
                '    .TotalWidth = Convert.ToSingle(Doc.PageSize.Width) - 70,
                '    .SpacingBefore = 15.0F}
                'Dim tamaniocolumnaqr As Single() = New Single(2) {}
                'tamaniocolumnaqr(0) = Convert.ToSingle(Doc.PageSize.Width * 0.4)
                'tamaniocolumnaqr(1) = Convert.ToSingle(Doc.PageSize.Width * 0.4)
                'tamaniocolumnaqr(2) = Convert.ToSingle(Doc.PageSize.Width * 0.2)
                ''Primer celda
                'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", titleFont)))
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER
                'PdfPCell.FixedHeight = 70.0F
                'TablaQR.AddCell(PdfPCell)
                ''Segunda Celda centro imagen
                'manejadorimagen = iTextSharp.text.Image.GetInstance(GenerateQR(My.Resources.LOGO_Contaduria.Width, My.Resources.LOGO_Contaduria.Height, textoQR, My.Resources.LOGO_Contaduria), System.Drawing.Imaging.ImageFormat.Png)
                ''asignar la imagen QR a la celda
                'manejadorimagen.ScaleToFit(My.Resources.LOGO_Contaduria.Height * 0.15, My.Resources.LOGO_Contaduria.Height * 0.15)
                'PdfPCell = New PdfPCell(manejadorimagen, True)
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_RIGHT
                'PdfPCell.FixedHeight = 70.0F
                'TablaQR.AddCell(PdfPCell)
                ''Tercer Celda
                'PdfPCell = New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("", titleFont)))
                'PdfPCell.BorderWidth = 0
                'PdfPCell.HorizontalAlignment = iTextSharp.text.pdf.PdfPCell.ALIGN_CENTER
                'PdfPCell.FixedHeight = 70.0F
                'TablaQR.AddCell(PdfPCell)
                ''---------------------------------AGREGAR CODIGO QR-----------------------------------------
                ''agrega un espacio entre el código QR y la ultima tabla
                '' Doc.Add(PdfpCell_espaciovacio)
                ''agrega la tabla QR
                ''    Doc.Add(TablaQR)
                ''/---------------------------------AGREGAR CODIGO QR-----------------------------------------
                '  Doc.Add(imagenpdf)
                ''//Close our document
                PARRAFOCOMPLETO.Clear()
                PARRAFOCOMPLETO.Add(New iTextSharp.text.Chunk(Inicio.GenerateHash(textoQR), font07Normal))
                Doc.Add(PARRAFOCOMPLETO)
                Dim COLUMNA2 As New ColumnText(wri.DirectContent)
                'the Phrase
                'the lower left x corner (left)
                'the lower left y corner (bottom)
                'the upper right x corner (right)
                'the upper right y corner (top)
                'line height(leading)
                'alignment.
                Dim font14Bolds As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14.0F, iTextSharp.text.Font.BOLD, BaseColor.GRAY)
                COLUMNA2.SetSimpleColumn(New iTextSharp.text.Phrase(New iTextSharp.text.Chunk("SICyF", font14Bolds)),
                                            Doc.Left, Doc.Bottom,
                                          Doc.Right, 0,
                                            15, Element.ALIGN_RIGHT)
                COLUMNA2.Go()
                Doc.Close()
            End Using
            Select Case MsgBox("Abrir el archivo generado?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo(Controlguardado.FileName) With {
                                             .UseShellExecute = True
    })
            End Select
        End If
    End Sub

    Private Sub GeneraciondepedidodefondosPDF()
        Dim Listadodatagridviewprueba(5) As DataGridView
        Listadodatagridviewprueba(0) = Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview
        Listadodatagridviewprueba(1) = Tesoreria_Informe_pedidofondos.Numcuenta_datagridview
        Listadodatagridviewprueba(2) = Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview
        Listadodatagridviewprueba(3) = Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview
        Listadodatagridviewprueba(4) = Tesoreria_Informe_pedidofondos.Cuentadepresupuesto_datagridview
        Listadodatagridviewprueba(5) = Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview
        PDFPEDIDODEFONDO(Listadodatagridviewprueba, "Reporte Rapido", False, "LEGAL")
        'Dim Pedidodefondos_datatable As New DataTable
        'Dim Numdecuenta_datatable As New DataTable
        'Dim Caracterdecuenta1 As New DataTable
        'Dim Caracterdecuenta2 As New DataTable
        'Dim Cuentadepresupuesto_datatable As New DataTable
        'Dim Transferidoportesoreríageneral_datatable As New DataTable
        'Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
        '    Case True
        '        'estructura de pedidos de fondos en caso de ser parcial
        '        Pedidodefondos_datatable.Columns.Add("N")
        '        Pedidodefondos_datatable.Columns.Add("RUBRO")
        '        Pedidodefondos_datatable.Columns.Add("PROVEEDOR")
        '        Pedidodefondos_datatable.Columns.Add("Expediente N")
        '        Pedidodefondos_datatable.Columns.Add("CUIT")
        '        Pedidodefondos_datatable.Columns.Add("CONCEPTO")
        '        Pedidodefondos_datatable.Columns.Add("IMPORTE")
        '        For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
        '            Pedidodefondos_datatable.Rows.Add()
        '            Pedidodefondos_datatable.Rows(X).Item("N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
        '            Pedidodefondos_datatable.Rows(X).Item("RUBRO") = " "
        '            Pedidodefondos_datatable.Rows(X).Item("Expediente N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("expediente_N").Value.ToString
        '            Pedidodefondos_datatable.Rows(X).Item("CUIT") = Expedientesasociados_datagridview.Rows(X).Cells.Item("CUIT").Value.ToString
        '            Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = Expedientesasociados_datagridview.Rows(X).Cells.Item("NUMERO").Value.ToString
        '            Pedidodefondos_datatable.Rows(X).Item("CONCEPTO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString &
        '        "-( O.P.N" & ")"
        '            Pedidodefondos_datatable.Rows(X).Item("IMPORTE") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto2").Value.ToString), 2,, TriState.True, TriState.True)
        '        Next
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.DataSource = Pedidodefondos_datatable
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("N").Width = 22
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("RUBRO").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("Expediente N").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CUIT").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("IMPORTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ''/estructura de pedidos de fondos
        '    Case False
        '        'estructura de pedidos de fondos caso habitual
        '        Pedidodefondos_datatable.Columns.Add("N")
        '        Pedidodefondos_datatable.Columns.Add("RUBRO")
        '        Pedidodefondos_datatable.Columns.Add("PROVEEDOR")
        '        Pedidodefondos_datatable.Columns.Add("CONCEPTO")
        '        Pedidodefondos_datatable.Columns.Add("IMPORTE")
        '        For X = 0 To Expedientesasociados_datagridview.Rows.Count - 1
        '            Pedidodefondos_datatable.Rows.Add()
        '            Pedidodefondos_datatable.Rows(X).Item("N") = Expedientesasociados_datagridview.Rows(X).Cells.Item("N").Value.ToString
        '            Pedidodefondos_datatable.Rows(X).Item("RUBRO") = " "
        '            Pedidodefondos_datatable.Rows(X).Item("PROVEEDOR") = " "
        '            Pedidodefondos_datatable.Rows(X).Item("CONCEPTO") = Expedientesasociados_datagridview.Rows(X).Cells.Item("Detalle").Value.ToString &
        '        "-(" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Expediente_N").Value.ToString & ")" &
        '        "( O.N" & Expedientesasociados_datagridview.Rows(X).Cells.Item("Ordenpago").Value.ToString & ")"
        '            Pedidodefondos_datatable.Rows(X).Item("IMPORTE") = FormatCurrency(Convert.ToDecimal(Expedientesasociados_datagridview.Rows(X).Cells.Item("Monto2").Value.ToString), 2,, TriState.True, TriState.True)
        '        Next
        '        Select Case Expedientesasociados_datagridview.Rows.Count
        '            Case = 1
        '                Tesoreria_Informe_pedidofondos.Contadorgeneraltexto_label.Text = "Sr. CONTADOR GENERAL DE LA PROVINCIA. De acuerdo a la LEY DE CONTABILIDAD, solicitamos la siguiente TRANSFERENCIA de Fondos:"
        '            Case Else
        '                Tesoreria_Informe_pedidofondos.Contadorgeneraltexto_label.Text = "Sr. CONTADOR GENERAL DE LA PROVINCIA. De acuerdo a la LEY DE CONTABILIDAD, solicitamos las siguientes TRANSFERENCIAS de Fondos:"
        '        End Select
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.DataSource = Pedidodefondos_datatable
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("N").Width = 22
        '        'Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item(" ").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("RUBRO").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("PROVEEDOR").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("IMPORTE").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.Pedidodefondos_datagridview.Columns.Item("CONCEPTO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        '/estructura de pedidos de fondos
        '        For x = 0 To 3
        '            Caracterdecuenta1.Columns.Add("")
        '        Next
        '        Caracterdecuenta1.Rows.Add()
        '        Caracterdecuenta1.Rows(0).Item(0) = "CÁRACTER"
        '        Caracterdecuenta1.Rows(0).Item(1) = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
        '        Caracterdecuenta1.Rows(0).Item(2) = "CUENTA:"
        '        Caracterdecuenta1.Rows(0).Item(3) = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Cuentadescripcion").Value.ToString
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.DataSource = Caracterdecuenta1
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta2_datagridview.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '        For x = 0 To 3
        '            Caracterdecuenta2.Columns.Add("")
        '        Next
        '        Caracterdecuenta2.Rows.Add()
        '        Caracterdecuenta2.Rows(0).Item(0) = "CÁRACTER"
        '        Caracterdecuenta2.Rows(0).Item(1) = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
        '        Caracterdecuenta2.Rows(0).Item(2) = "CUENTA"
        '        Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString
        '            Case Is = "0"
        '                Caracterdecuenta2.Rows(0).Item(3) = "SIN AFECTACIÓN ESPECIAL"
        '            Case Else
        '                Caracterdecuenta2.Rows(0).Item(3) = "AFECTACIÓN ESPECIAL"
        '        End Select
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.DataSource = Caracterdecuenta2
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        Tesoreria_Informe_pedidofondos.CaracterCuenta_datagridview.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
        '        '/Estructura de Caracter de la Cuenta
        '        'estructura de Tesorería General de la provincia
        '        Transferidoportesoreríageneral_datatable.Columns.Add("FECHA")
        '        Transferidoportesoreríageneral_datatable.Columns.Add("CUENTA N")
        '        Transferidoportesoreríageneral_datatable.Columns.Add("CHEQUE N")
        '        Transferidoportesoreríageneral_datatable.Columns.Add("IMPORTES")
        '        For x = 0 To 5
        '            Transferidoportesoreríageneral_datatable.Rows.Add()
        '        Next
        '        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.DataSource = Transferidoportesoreríageneral_datatable
        '        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("FECHA").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("IMPORTES").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("CUENTA N").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        Tesoreria_Informe_pedidofondos.Transferidoportesoreria_datagridview.Columns.Item("CHEQUE N").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        '/estructura de Tesorería General de la provincia
        '        Tesoreria_Informe_pedidofondos.Numcuenta_datagridview.DataSource = Numdecuenta_datatable
        'End Select
    End Sub

    Private Sub Busquedaexpedientesasociados_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busquedaexpedientesasociados_textbox.TextChanged
        Buscar_datagrid_TIMER(sender, Expedientesasociados_datatable, Expedientesasociados_datagridview)
        'refreshexpedientes()
    End Sub

    Private Function buscarmaximo_pedidofondo(ByRef Year As Integer) As Int16
        Dim temporal As New DataTable
        COMMANDSQL.Parameters.AddWithValue("@Year_pedidofondo", Year)
        Inicio.SQLPARAMETROS(Organismotabla,
                             "Select max(N_pedidofondo) from pedido_fondos where Year_pedidofondo=@Year_pedidofondo",
                             temporal, Reflection.MethodBase.GetCurrentMethod.Name)
        Select Case IsDBNull(temporal.Rows(0).Item(0))
            Case True
                Return 1
            Case False
                Return Convert.ToInt16(temporal.Rows(0).Item(0)) + 1
        End Select
    End Function

    'Private Function buscarmaximoanio() As Int16
    '    Dim temporal As New DataTable
    '    COMMANDSQL.Parameters.AddWithValue("@Year_pedidofondo", Date.Now.Year)
    '    Inicio.SQLPARAMETROS(Organismotabla,
    '                         "Select max(N_pedidofondo) from pedido_fondos where Year_pedidofondo=@Year_pedidofondo",
    '                         temporal, Reflection.MethodBase.GetCurrentMethod.Name)
    '    Select Case IsDBNull(temporal.Rows(0).Item(0))
    '        Case True
    '            Return 1
    '        Case False
    '            Return Convert.ToInt16(temporal.Rows(0).Item(0)) + 1
    '    End Select
    'End Function
    Private Sub Boton_Nuevo_Click(sender As Object, e As EventArgs) Handles Boton_Nuevo.Click
        '' End Select
        Dim pedfondo As New PedidoFondos("0", "0")
        'sdfsdfsdf
        'pedfondo.N_pedidofondo = buscarmaximoanio()
        'pedfondo.YearPedidoFondo = Date.Now.Year
        'pedfondo.Fecha_pedido = Date.Now
        'pedfondo.Cuenta_pedidofondo = 0
        'pedfondo.ExpteOrganismo = Organismo
        'pedfondo.ExpteNumero = 0
        'pedfondo.ExpteYear = Date.Now.Year
        'pedfondo.Descripcion = ""
        'pedfondo.Clase_fondo = Date.Now.Year
        'pedfondo.Parcial = False
        'pedfondo.haberes = False
        'Dialogo_nuevopedidofondo.General_cargapedidofondo(pedfondo, Me, True)
        pedfondo.Nuevo_pedido_dialogo()
    End Sub

    Private Sub verificaciondatosbasicos(ByRef datosvalidos As Boolean, ByRef errores() As String)
    End Sub

    Private Sub Guardarcambios_boton_Click(sender As Object, e As EventArgs)
        Dim Datos_validos As Boolean = True
        Dim Errores(8) As String
        Dim Total_errores As String = ""
        'Select Case verificarexistencia("pedido_fondos", "clave_pedidofondo", Year_expediente_textbox.Text & Organismo_textbox.Text & Format(Convert.ToInt32(N_pedidofondo_textbox.Value), "00000"))
        '    Case True
        '        MessageBox.Show("Ya existe ese pedido de fondos")
        '    Case False
        'Select Case Not (Expte_numero_numericupdown.Value = 0)
        '    Case True
        '        Select Case verificarexistencia("Pedido_fondos", "Expediente_N", Organismo_textbox.Value & "-" & Format(Convert.ToInt32(Expte_numero_numericupdown.Value), "00000") & "/" & Year_expediente_textbox.Value, Year_expediente_textbox.Value & Organismo_textbox.Value & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
        '            Case True
        '                Datos_validos = False
        '            Case False
        '                Datos_validos = True
        '                MessageBox.Show("Ya existe un expediente asociado a otro pedido de fondos")
        '        End Select
        '    Case False
        Select Case MsgBox("Confirma que desea Cargar este pedido de Fondo N" & N_pedidofondo_numeric.Value, MsgBoxStyle.YesNoCancel, " ")
            Case MsgBoxResult.Yes
                'verificación
                Select Case Descripcion_textbox.TextLength > 0
                    Case True
                    Case False
                        Datos_validos = False
                        Errores(0) = "La descripción de este pedido de fondo se encuentra vacía por favor completela"
                End Select
                'Select Case Organismo_textbox.TextLength > 0
                '    Case True
                '        Select Case IsNumeric(Organismo_textbox.Text)
                '            Case True
                '            Case False
                '                Datos_validos = False
                '                Errores(1) = "El Código de Organismo en El expediente de pedido de fondos es un número de 4 cifras, por favor verifique"
                '        End Select
                '    Case False
                '        Datos_validos = False
                '        Errores(1) = "El Número correspondiente al organismo esta vacío, por favor completelo"
                'End Select
                'Select Case Expte_numero_textbox.Value > 0
                '    Case False
                '        Datos_validos = False
                '        Errores(2) = "El Número correspondiente al número de expediente esta vacío, por favor completelo"
                'End Select
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
                Select Case Clasefondo_textbox.TextLength > 0
                    Case True
                    Case False
                        Datos_validos = False
                        Errores(4) = "La Clase de fondo se encuentra vacía por favor completela"
                End Select
                'Select Case Fecha_pedido_textbox.TextLength > 0
                '    Case True
                '        Select Case IsDate(Fecha_pedido_textbox.Text)
                '            Case True
                '            Case False
                '                Datos_validos = False
                '                Errores(5) = "La fecha de la solicitud debe ingresarse en el formato dd/mm/aaaa por ej. " & Date.Now.ToShortDateString
                '        End Select
                '    Case False
                '        Datos_validos = False
                '        Errores(5) = "La fecha de la solicitud se encuentra vacía recuerde completarla."
                'End Select
                Select Case Cuentas_combobox.SelectedItem.ToString = ""
                    Case True
                        Datos_validos = False
                        Errores(6) = "Recuerde seleccionar una cuenta bancaria asociada"
                    Case False
                End Select
                'Select Case N_ordenpagocargo_textbox.Value > 0
                '    Case True
                '                        'correcto
                '    Case False
                '        Datos_validos = False
                '        Errores(7) = "El número de orden de pago debe ser mayor a 0 (cero)"
                'End Select
                'Select Case Year_expediente_textbox.TextLength > 0
                '    Case True
                '        Select Case Year_expediente_textbox.TextLength = 4
                '            Case True
                '            Case False
                '                Datos_validos = False
                '                Errores(8) = "El año de la orden de pago debe ser ingresado con 4 cifras  ej." & Date.Now.Year
                '        End Select
                '    Case False
                '        Datos_validos = False
                '        Errores(8) = "El año de la orden de pago se encuentra vacío, por favor completelo."
                'End Select
                'End Select
                Select Case Datos_validos
                    Case True
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_expediente_textbox.Text & Organismo_textbox.Text & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@N_pedidofondo", N_pedidofondo_numeric.Value)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_pedidofondo", Year_pedidofondo_numeric.Value)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto_pedidofondo", Pedidodefondosmontowpf.Monto_textbox.Number)
                        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@N_ordenpago", N_ordenpagocargo_textbox.Value)
                        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Year_ordenpago", Year_ordenpagocargo_textbox.Text)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta_pedidofondo", Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", Organismo_textbox.Value & "-" & Format(Convert.ToInt32(Expte_numero_numericupdown.Value), "00000") & "/" & Year_expediente_textbox.Value)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Descripcion", Descripcion_textbox.Text)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_pedido", Fecha_pedido_textbox.Value)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Clase_fondo", Clasefondo_textbox.Text)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Parcial", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1)
                        INSERTCOMMANDSQL.Parameters.AddWithValue("@Haberes", Pedidohaberes_checkbox.Checked)
                        INSERTCOMMANDSQL.CommandText = "INSERT INTO `Pedido_fondos` " &
                                    "(Clave_pedidofondo,N_pedidofondo,Year_pedidofondo,Monto_pedidofondo,Cuenta_pedidofondo,Descripcion,Fecha_pedido,Clase_fondo,Expediente_N,Parcial,Haberes,Usuario) " &
                                    "VALUES
                                    (@Clave_pedidofondo,@N_pedidofondo,@Year_pedidofondo,@Monto_pedidofondo,@Cuenta_pedidofondo,@Descripcion,@Fecha_pedido,@Clase_fondo,@Expediente_N,@Parcial,@Haberes,@Usuario) " &
                                    "ON DUPLICATE KEY UPDATE " &
                                    "Clave_pedidofondo=@Clave_pedidofondo,N_pedidofondo=@N_pedidofondo,Year_pedidofondo=@Year_pedidofondo,Monto_pedidofondo=@Monto_pedidofondo,
Cuenta_pedidofondo=@Cuenta_pedidofondo,Descripcion=@Descripcion,Fecha_pedido=@Fecha_pedido,Clase_fondo=@Clase_fondo,Expediente_N=@Expediente_N,Parcial=@Parcial,Haberes=@Haberes,Usuario=@Usuario "
                        Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                        Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
                        refreshnow()
                        Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
                        'SplitContainer2.Panel2.Enabled = False
                        Panelnuevopedido.Enabled = False
                        'ActivarControlesenpanel(SplitContainer2.Panel2, False)
                        Boton_Modificar.Enabled = True
                        Boton_borrar.Enabled = True
                        Boton_Nuevo.Enabled = True
                        ' Guardarcambios_boton.Visible = False
                        '  Cancelarcambios_boton.Visible = False
                        '  SplitContainer2.Panel1.Enabled = True
                        SplitContainer3.Panel1.Enabled = True
                        SplitContainer3.Panel2.Enabled = True
                    Case False
                        For x = 0 To Errores.Count - 1
                            If Not (Errores(x) = "") Then
                                Total_errores = Total_errores & vbCrLf & "-" & Errores(x)
                            End If
                        Next
                        MessageBox.Show("Actualmente el pedido de fondo contiene los siguientes errores " & vbCrLf & Total_errores)
                End Select
            Case MsgBoxResult.Cancel
            Case MsgBoxResult.No
                MessageBox.Show("Los datos no van a ser cargados")
                Boton_Modificar.Enabled = True
                Boton_borrar.Enabled = True
                Boton_Nuevo.Enabled = True
                ' Guardarcambios_boton.Visible = False
                '  Cancelarcambios_boton.Visible = False
                '  SplitContainer2.Panel1.Enabled = True
                SplitContainer3.Panel1.Enabled = True
                SplitContainer3.Panel2.Enabled = True
        End Select
        '  End Select
        Panelnuevopedido.BackColor = Color.White
    End Sub

    Private Sub ActivarControlesenpanel(ByVal panelatrabajar As Panel, ByVal enableds As Boolean)
        For x = 0 To panelatrabajar.Controls.Count - 1
            panelatrabajar.Controls(x).Enabled = enableds
        Next
    End Sub

    Private Sub Datosspedidofondo_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosspedidofondo_datagridview.CellEnter
        'Select Case Datosspedidofondo_datagridview.SelectedRows.Count > 0
        '    Case True
        '        Label_MontoSolicitado.Text = "Monto Solicitado $ " & Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Monto_pedidofondo").Value.ToString
        '    Case False
        'End Select
    End Sub

    Private Sub Pedidofondos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F5
                Busqueda.Text = ""
                Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
                refreshnow()
                Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
            Case Is = Keys.F12
                Select Case Autorizaciones.Usuario.Rows(0).Item("nivel").ToString
                    Case Is = "0"
                        For X = 0 To Me.Controls.Count - 1
                            For m = 0 To Me.Controls(X).Controls.Count - 1
                                If Me.Controls(X).Controls(m).GetType.Name = "SICyF.Flicker_Datagridview" Then
                                    For z = 0 To CType(Me.Controls(X).Controls(m), SICyF.Flicker_Datagridview).Columns.Count - 1
                                        CType(Me.Controls(X).Controls(m), SICyF.Flicker_Datagridview).Columns(z).Visible = True
                                    Next
                                End If
                            Next
                        Next
                    Case Else
                End Select
            Case Is = Keys.F11
                For X = 0 To Datosspedidofondo_datagridview.Rows.Count - 1
                    Datosspedidofondo_datagridview.FirstDisplayedScrollingRowIndex = X
                    Datosspedidofondo_datagridview.Rows(X).Selected = True
                    Cargadedatos()
                    Cargatesoreriagral()
                Next
        End Select
    End Sub

    Private Sub Boton_Modificar_Click(sender As Object, e As EventArgs) Handles Boton_Modificar.Click
        modificarpedidofondos()
        ''Select Case Datosspedidofondo_datagridview.SelectedRows.Count
        ''    Case > 0
        ''        Select Case Convert.ToBoolean(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("IMPRESO").Value)
        ''            Case True
        ''                MessageBox.Show("Ya se ha generado el pedido de fondos, Por tanto no es posible MODIFICAR el mismo")
        ''            Case False
        ''                Panelnuevopedido.Enabled = True
        ''                SplitContainer2.Panel2.Enabled = True
        ''                Guardarcambios_boton.Visible = True
        ''                Cancelarcambios_boton.Visible = True
        ''                SplitContainer2.Panel2.Enabled = True
        ''                ' ActivarControlesenpanel(SplitContainer2.Panel2, True)
        ''                SplitContainer2.Panel1.Enabled = False
        ''                SplitContainer3.Panel1.Enabled = False
        ''                SplitContainer3.Panel2.Enabled = False
        ''            Case Else
        ''                MessageBox.Show(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("IMPRESO").Value.ToString)
        ''        End Select
        ''End Select
        'Select Case Datosspedidofondo_datagridview.SelectedRows.Count
        '    Case > 0
        '        Select Case Convert.ToBoolean(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("IMPRESO").Value)
        '            Case True
        '                MessageBox.Show("Ya se ha generado el pedido de fondos, Por tanto no es posible MODIFICAR el mismo")
        '            Case False
        '                'creo la estructura del pedido de fondos
        '                'Dim pedfondo As Pedidofondo
        '                Dim ped_fondo As PedidoFondos = New PedidoFondos(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString, Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Numero de Expediente").Value.ToString)
        '                'creo el separador de nombre del expediente y ejecuto la función divisor de 3 variables
        '                'Dim exptepedidofondo() As String = Divisordetresvariables(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Fecha_pedido").Value.ToString)
        '                'creo el separador de clavepedidofondo
        '                ' Dim Clavepedidofondo As Pedidofondo
        '                '  Clavepedidofondo.clavepedidofondo = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString
        '                'Clavepedidofondo.Desglose_clave()
        '                ped_fondo.Numeropedidofondo = ped_fondo.Numeropedidofondo
        '                ped_fondo.Yearpedidofondo = ped_fondo.Yearpedidofondo
        '                ped_fondo.Fecha = CType(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Fecha_pedido").Value, Date)
        '                ped_fondo.CuentaPedidofondo = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Cuenta_pedidofondo").Value.ToString
        '                ped_fondo.ExpteOrganismo = ped_fondo.ExpteOrganismo
        '                ped_fondo.ExpteNumero = ped_fondo.ExpteNumero
        '                ped_fondo.ExpteYear = ped_fondo.ExpteYear
        '                ped_fondo.Descripcion = Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Descripcion").Value.ToString
        '                ped_fondo.ClaseFondo = 1
        '                ped_fondo.Pedidofondoparcial = CType(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value, Integer)
        '                Dialogo_nuevopedidofondo.General_cargapedidofondo(ped_fondo, Me, True)
        '                'Panelnuevopedido.Enabled = True
        '                'SplitContainer2.Panel2.Enabled = True
        '                'Guardarcambios_boton.Visible = True
        '                'Cancelarcambios_boton.Visible = True
        '                'SplitContainer2.Panel2.Enabled = True
        '                '' ActivarControlesenpanel(SplitContainer2.Panel2, True)
        '                'SplitContainer2.Panel1.Enabled = False
        '                'SplitContainer3.Panel1.Enabled = False
        '                'SplitContainer3.Panel2.Enabled = False
        '            Case Else
        '                MessageBox.Show(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("IMPRESO").Value.ToString)
        '        End Select
        'End Select
    End Sub

    Private Sub Cancelarcambios_boton_Click(sender As Object, e As EventArgs)
        Select Case MsgBox("Confirma que NO DESEA CARGAR LOS DATOS del pedido de Fondo N" & N_pedidofondo_numeric.Value, MsgBoxStyle.YesNoCancel, "CANCELAR LOS CAMBIOS ")
            Case MsgBoxResult.Yes
                borradoanuevo()
                ' Guardarcambios_boton.Visible = False
                '  Cancelarcambios_boton.Visible = False
                '   SplitContainer2.Panel2.Enabled = False
                ' ActivarControlesenpanel(SplitContainer2.Panel2, True)
                ' SplitContainer2.Panel1.Enabled = True
                SplitContainer3.Panel1.Enabled = True
                SplitContainer3.Panel2.Enabled = True
                Boton_borrar.Enabled = True
                Boton_Nuevo.Enabled = True
                Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
                refreshnow()
                Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
                Panelnuevopedido.BackColor = Color.White
            Case MsgBoxResult.No
            Case MsgBoxResult.Cancel
        End Select
    End Sub

    Private Sub Descripcion_textbox_Leave(sender As Object, e As EventArgs) Handles Descripcion_textbox.Leave
        Inicio.Verificar(sender, sender.text, "TEXTO")
    End Sub

    Private Sub Organismo_textbox_Leave(sender As Object, e As EventArgs)
        Inicio.Verificar(sender, sender.value.ToString, "ORGANISMO")
    End Sub

    Private Sub Expte_numero_textbox_Leave(sender As Object, e As EventArgs)
        'Inicio.Verificar(sender, sender.text, "NUMERICO")
    End Sub

    Private Sub Year_expediente_textbox_Leave(sender As Object, e As EventArgs)
        Inicio.Verificar(sender, sender.value.ToString, "YEAR")
    End Sub

    Private Sub Clasefondo_textbox_Leave(sender As Object, e As EventArgs) Handles Clasefondo_textbox.Leave
        Inicio.Verificar(sender, sender.text, "TEXTO")
    End Sub

    Private Sub N_ordenpagocargo_textbox_Leave(sender As Object, e As EventArgs)
        '    Inicio.Verificar(sender, sender.text, "NUMERICO")
    End Sub

    Private Sub Year_ordenpagocargo_textbox_Leave(sender As Object, e As EventArgs)
        Inicio.Verificar(sender, sender.text, "YEAR")
    End Sub

    Private Sub Expte_numero_textbox_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Expte_numero_numericupdown.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Cuentas_combobox_KeyDown(sender As Object, e As KeyEventArgs) Handles Cuentas_combobox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub N_ordenpagocargo_textbox_KeyDown_1(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Year_ordenpagocargo_textbox_KeyDown_1(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Fecha_pedido_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Fecha_pedido_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Organismo_textbox_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Organismo_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Year_expediente_textbox_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Year_expediente_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Pedidofondos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
    End Sub

    Private Sub Expedientesasociados_datagridview_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Expedientesasociados_datagridview.CellValueChanged
        Select Case Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("parcial").Value = 1
            Case True
                INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("CUIT").Value)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Clave_expediente").Value)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", CType(Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("MONTO").Value, Decimal))
                '  SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Rubro", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Rubro").Value)
                '   SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", DBNull.Value)
                INSERTCOMMANDSQL.CommandText = "UPDATE CUIT_Movimiento SET Monto=@Monto   WHERE Clave_expediente=@Clave_expediente AND Cuit=@CUIT;"
                Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("CUIT").Value)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Clave_expediente").Value)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Rubro", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Rubro").Value)
                '   SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", DBNull.Value)
                INSERTCOMMANDSQL.CommandText = "UPDATE CUIT_Expediente SET  Rubro=@Rubro,Usuario=@Usuario  WHERE Clave_expediente=@Clave_expediente AND Cuit=@CUIT;"
                Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("clave_pedidofondo").Value)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", sumaasociada)
                '   SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_pedidofondo", DBNull.Value)
                INSERTCOMMANDSQL.CommandText = "UPDATE pedido_fondos SET MONTO_pedidofondo=@MONTO,Usuario=@Usuario  WHERE clave_pedidofondo=@Clave_pedidofondo;"
                Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Monto_pedidofondo").Value = sumaasociada()
                Pedidodefondosmontowpf.Monto_textbox.Number = sumaasociada()
                Expedientesasociados_datagridview.EndEdit()
                colorearceldasasociadas()
                    '  End If
                'End If
            Case False
                If Not IsDBNull(Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Total Expediente").Value) Then
                    If Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("MONTO").Value > Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Total Expediente").Value Then
                        Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("MONTO").Value = Expedientesasociados_datatable.Rows(e.RowIndex).Item("Total Expediente").VALUE
                        MessageBox.Show("El monto ingresado supera lo solicitado en el expediente, se coloca el maximo valor del expediente")
                    Else
                    End If
                End If
                Dim sumadelexpediente As Decimal = 0
                Expedientesasociados_datagridview.SelectedRows(0).DefaultCellStyle.BackColor = Color.LightGreen
                Expedientesasociados_datagridview.SelectedRows(0).DefaultCellStyle.SelectionBackColor = Color.Green
                Expedientesasociados_datagridview.SelectedRows(0).DefaultCellStyle.SelectionForeColor = Color.White
                'Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("CUIT").Value)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Clave_expediente").Value)
                INSERTCOMMANDSQL.Parameters.AddWithValue("@Rubro", Expedientesasociados_datagridview.Rows(e.RowIndex).Cells.Item("Rubro").Value.ToString)
                INSERTCOMMANDSQL.CommandText = "UPDATE CUIT_Expediente SET Rubro=@Rubro,Usuario=@Usuario  WHERE Clave_expediente=@Clave_expediente AND Cuit=@CUIT;"
                Inicio.INSERTSQLPARAMETROS(Organismotabla, Reflection.MethodBase.GetCurrentMethod.Name)
                Pedidodefondosmontowpf.Monto_textbox.Number = sumaasociada()
                colorearceldasasociadas()
                '  End If
        End Select
        '  End If
    End Sub

    Private Sub Datosspedidofondo_datagridview_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles Datosspedidofondo_datagridview.RowPrePaint
        Select Case Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("Movimientos").Value
            Case Is > 0
                Datosspedidofondo_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.PaleTurquoise
                'Datosspedidofondo_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Yellow
            Case Else
                Select Case Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("parcial").Value = 1
                    Case True
                        Datosspedidofondo_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightSeaGreen
                        Datosspedidofondo_datagridview.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
                        Datosspedidofondo_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.LightSeaGreen
                        Datosspedidofondo_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
                    Case False
                        Datosspedidofondo_datagridview.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                End Select
        End Select
        If Not IsNothing(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("CLASE_FONDO").Value) Then
            If Not IsNothing(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("FECHA_PEDIDO").Value) Then
                Select Case CType(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("FECHA_PEDIDO").Value, Date).Year - CType(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("CLASE_FONDO").Value, Integer)
                    Case Is = 0
                        Colorcelda(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("CLASE_FONDO"), Color.PaleGreen)
                    Case Is = 1
                        Colorcelda(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("CLASE_FONDO"), Color.LightSkyBlue)
                    Case Is = 2
                        Colorcelda(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("CLASE_FONDO"), Color.Goldenrod)
                    Case Is > 2
                        Colorcelda(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("CLASE_FONDO"), Color.Red)
                    Case Is < 0
                        Colorcelda(Datosspedidofondo_datagridview.Rows(e.RowIndex).Cells.Item("CLASE_FONDO"), Color.Black)
                End Select
            End If
        End If
        '    Datosexpedientesdetalle_datagridview.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Black
    End Sub

    Private Sub Expedientesasociados_datagridview_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Expedientesasociados_datagridview.MouseDoubleClick
    End Sub

    Private Sub Expedientesasociados_datagridview_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles Expedientesasociados_datagridview.CurrentCellDirtyStateChanged
        Inicio.ToolStripDebug.Text = e.ToString
    End Sub

    Private Sub Datosspedidofondo_datagridview_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datosspedidofondo_datagridview.ColumnHeaderMouseClick
        Click_ordenar_columna_Datagridview(sender, e, "Pedido de fondos", "Clave_pedidofondo")
    End Sub

    Private Sub Expedientesasociados_datagridview_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles Expedientesasociados_datagridview.UserAddedRow
    End Sub

    Private Sub Expedientesasociados_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Expedientesasociados_datagridview.DataError
    End Sub

    Private Sub Datosspedidofondo_datagridview_KeyDown(sender As Object, e As KeyEventArgs) Handles Datosspedidofondo_datagridview.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F10
                'For index = 1 To 1
                '    Datosspedidofondo_datagridview.Rows(index - 1).Selected = True
                Cargadedatos()
                pedfondoseleccionado.CargarDatos(Datosspedidofondo_datagridview.SelectedRows(0).Cells.Item("Clave_pedidofondo").Value.ToString)
                pedfondoseleccionado.CargarDatosPartidas_datatable()
                'fix temporal borrar------------------------------------------------------------------------------------
                'If SERVIDORMYSQL.SERVER1 = "" Then
                Dim t As New Task(Sub() Informatica_Servidor.ApiNuevo2(pedfondoseleccionado))
                t.Start()
                t.Wait()
                    'End If
                'Next
            Case Is = Keys.F12
            Case Is = Keys.F9
                Taskf9()
        End Select
    End Sub

    Private Sub SubTaskf9(ByVal Inicio As Integer, ByVal Final As Integer, ByVal Year As Integer, ByVal Conexion As dialogo_login)
        Dim tg As New Tesoreriageneral_webform
        Dim reloj As New Stopwatch
        reloj.Start()
        tg.User = Conexion.UsernameTextBox.Text
        tg.PWD = Conexion.PasswordTextBox.Text
        tg.Ejecutarlogin()
        Dim Pedidosfondos As TesoreriaGralPedidoFondo() = Nothing
        Dim PedidoFondoTg As TesoreriaGralPedidoFondo
        For x = Inicio To Final
            Pedidosfondos.Add(New TesoreriaGralPedidoFondo)
            Pedidosfondos(Pedidosfondos.Length - 1).NumeroPedido = x
            Pedidosfondos(Pedidosfondos.Length - 1).YearPedidoFondo = Year
            ' tg.MovimientosExpedientes(PedidoFondoTg)
            Pedidosfondos(Pedidosfondos.Length - 1) = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(Pedidosfondos(Pedidosfondos.Length - 1))
            If Pedidosfondos(Pedidosfondos.Length - 1).Saldo = -1 Then
                Pedidosfondos(Pedidosfondos.Length - 1) = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(Pedidosfondos(Pedidosfondos.Length - 1), True)
                '  PedidoFondoTg.InsertarBaseDatos(PedidoFondoTg, M(Posicion))
            Else
                ' PedidoFondoTg.InsertarBaseDatos(PedidoFondoTg, M(Posicion))
            End If
        Next
        reloj.Stop()
        Dim MessageIcon As New MessageToastie
        With MessageIcon
            .TituloMessage = "Evaluación pedidos de fondo"
            .MessageTexto = "Finalizado " & Inicio & " a " & Final & " (" & reloj.ElapsedMilliseconds & " ms)"
        End With
        MessageIcon.Message()
        tg.CloseWeb()
        Dim M As MySql.Data.MySqlClient.MySqlCommand() = Nothing
        Dim Posicion As Integer = 0
        If Not IsNothing(Pedidosfondos) Then
            For x = 0 To Pedidosfondos.Length - 1
                M.Add(New MySql.Data.MySqlClient.MySqlCommand())
                Posicion = M.Length - 1
                M(M.Length - 1) = SERVIDORMYSQL.COMMANDSQL
                Pedidosfondos(x).InsertarBaseDatos(Pedidosfondos(x), M(Posicion))
            Next
        End If
    End Sub

    Private Sub AsignadorTasksF9(ByVal ValorInicial As Integer, ByVal ValorFinal As Integer, ByVal Year As Integer, ByVal Hilos As Integer, ByVal CONEXION As dialogo_login)
        Dim Paso As Integer = Math.Truncate((ValorFinal - (ValorInicial - 1)) / Hilos) - 1
        Dim t As Task() = Nothing
        Dim Message As New MessageToastie
        With Message
            .TituloMessage = "Evaluación"
            .MessageTexto = "Comenzando proceso de Evaluación desde Pedido de Fondo " & ValorInicial & " al " & ValorFinal & " Utilizando " & Hilos & " Hilos "
        End With
        Message.Message()
        For x = 0 To Hilos - 1
            ' SubTaskf9((Paso * x) + ValorInicial + 1, ValorFinal, CONEXION)
            If x = Hilos - 1 Then
                'MessageBox.Show((ValorFinal - (Paso * x)) + ValorInicial & vbNewLine & ValorFinal)
                t.Add(New Task(Sub() SubTaskf9((Paso * x) + ValorInicial + 1, ValorFinal, Year, CONEXION)))
                Thread.Sleep(1000)
                t(t.Length - 1).Start()
            ElseIf x = 0 Then
                ' MessageBox.Show((Paso * x) + ValorInicial & vbNewLine & ValorFinal)
                t.Add(New Task(Sub() SubTaskf9(ValorInicial, ValorInicial + Paso, Year, CONEXION)))
                Thread.Sleep(900)
                t(t.Length - 1).Start()
            Else
                ' MessageBox.Show((Paso * x) + ValorInicial & vbNewLine & ValorFinal)
                t.Add(New Task(Sub() SubTaskf9((Paso * x) + ValorInicial + 1, (Paso * x) + ValorInicial + Paso, Year, CONEXION)))
                Thread.Sleep(1200)
                t(t.Length - 1).Start()
            End If
        Next
        t = Nothing
    End Sub

    Private Sub Taskf9()
        Dim CONEXION As New dialogo_login
        CONEXION.UsernameTextBox.Text = "usupubli"
        CONEXION.PasswordTextBox.Text = "Salu9655"
        Dim NucleosUtilizados As New TrackBar
        With NucleosUtilizados
            .Minimum = 1
            .Maximum = Environment.ProcessorCount
            .AutoSize = True
        End With
        Dim MinimoPf As New NumericUpDown
        With MinimoPf
            .Minimum = 1
            .Maximum = 5000
            .Value = 1
        End With
        Dim MaximoPf As New NumericUpDown
        With MaximoPf
            .Minimum = 1
            .Maximum = 5000
            .Value = 1000
        End With
        Dim Yearpf As New NumericUpDown
        With Yearpf
            .Minimum = 2018
            .Maximum = Date.Now.Year
            .Value = Date.Now.Year
        End With
        CONEXION.Controls.Add(NucleosUtilizados)
        CONEXION.Controls.Add(MinimoPf)
        CONEXION.Controls.Add(MaximoPf)
        CONEXION.Controls.Add(Yearpf)
        NucleosUtilizados.Location = New Point(CONEXION.Recordarme_checkbox.Location.X + CONEXION.Recordarme_checkbox.Width + 7, CONEXION.PasswordTextBox.Location.Y + CONEXION.PasswordTextBox.Height + 5)
        MinimoPf.Location = New Point(CONEXION.PasswordTextBox.Location.X + 20, NucleosUtilizados.Location.Y + NucleosUtilizados.Height + 5)
        MaximoPf.Location = New Point(MinimoPf.Location.X + MinimoPf.Size.Width + 2, NucleosUtilizados.Location.Y + NucleosUtilizados.Height + 5)
        Yearpf.Location = New Point(CONEXION.PasswordTextBox.Location.X + 20, MinimoPf.Location.Y + MinimoPf.Height + 5)
        CONEXION.Size = New Size(CONEXION.Size.Width, CONEXION.Size.Height + NucleosUtilizados.Height + 5 + MinimoPf.Size.Height + 5 + MaximoPf.Size.Height + 5 + Yearpf.Size.Height + 5)
        If (CONEXION.ShowDialog() = DialogResult.OK) Then
            Dim Hilos As Integer = NucleosUtilizados.Value
            Dim ValorInicial As Integer = MinimoPf.Value
            Dim ValorFinal As Integer = MaximoPf.Value
            Dim YearEvaluado As Integer = Yearpf.Value
            AsignadorTasksF9(ValorInicial, ValorFinal, YearEvaluado, Hilos, CONEXION)
            'ValorInicial = 1000
            'ValorFinal = 1500
            'AsignadorTasksF9(ValorInicial, ValorFinal, Hilos, CONEXION)
            'ValorInicial = 2000
            'ValorFinal = 2500
            'AsignadorTasksF9(ValorInicial, ValorFinal, Hilos, CONEXION)
            ''  For X = 0 To Datosspedidofondo_datagridview.Rows.Count - 1
            'Dim tg As New Tesoreriageneral_webform
            'tg.User = CONEXION.UsernameTextBox.Text
            'tg.PWD = CONEXION.PasswordTextBox.Text
            'tg.Ejecutarlogin()
            'Dim PedidoFondoTg As New TesoreriaGralPedidoFondo
            'For x = 1 To 1500
            '    PedidoFondoTg = New TesoreriaGralPedidoFondo
            '    PedidoFondoTg.NumeroPedido = x
            '    ' tg.MovimientosExpedientes(PedidoFondoTg)
            '    PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg)
            '    If PedidoFondoTg.Saldo = -1 Then
            '        PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg, True)
            '        PedidoFondoTg.InsertarBaseDatos()
            '    Else
            '        PedidoFondoTg.InsertarBaseDatos()
            '    End If
            'Next
            'For x = 2000 To 2500
            '    PedidoFondoTg = New TesoreriaGralPedidoFondo
            '    PedidoFondoTg.NumeroPedido = x
            '    ' tg.MovimientosExpedientes(PedidoFondoTg)
            '    PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg)
            '    If PedidoFondoTg.Saldo = -1 Then
            '        PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg, True)
            '        PedidoFondoTg.InsertarBaseDatos()
            '    Else
            '        PedidoFondoTg.InsertarBaseDatos()
            '    End If
            'Next
            'For x = 1 To 1500
            '    PedidoFondoTg = New TesoreriaGralPedidoFondo
            '    PedidoFondoTg.YearPedidoFondo = Date.Now.Year - 1
            '    PedidoFondoTg.NumeroPedido = x
            '    ' tg.MovimientosExpedientes(PedidoFondoTg)
            '    PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg)
            '    If PedidoFondoTg.Saldo = -1 Then
            '        PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg, True)
            '        PedidoFondoTg.InsertarBaseDatos()
            '    Else
            '        PedidoFondoTg.InsertarBaseDatos()
            '    End If
            'Next
            'For x = 2000 To 2500
            '    PedidoFondoTg = New TesoreriaGralPedidoFondo
            '    PedidoFondoTg.NumeroPedido = x
            '    PedidoFondoTg.YearPedidoFondo = Date.Now.Year - 1
            '    ' tg.MovimientosExpedientes(PedidoFondoTg)
            '    PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg)
            '    If PedidoFondoTg.Saldo = -1 Then
            '        PedidoFondoTg = tg.Converter_WebTGtoTesoreriaGralPedidoFondo(PedidoFondoTg, True)
            '        PedidoFondoTg.InsertarBaseDatos()
            '    Else
            '        PedidoFondoTg.InsertarBaseDatos()
            '    End If
            'Next
            ' Next
        End If
    End Sub

    Private Sub Refresh_boton_Click(sender As Object, e As EventArgs) Handles Refresh_boton.Click
        Inicio.OBJETOCARGANDO(Datosspedidofondo_datagridview, Me, "Cargando Pedidos de fondos")
        refreshnow()
        Inicio.OBJETOFINALIZAR(Datosspedidofondo_datagridview, Me)
    End Sub

    Private Sub Expedientesasociados_datagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Expedientesasociados_datagridview.CellContentClick
    End Sub

End Class