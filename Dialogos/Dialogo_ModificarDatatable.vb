Public Class Dialogo_ModificarDatatable
    Dim cargainicial As Boolean = True
    Dim tabladedatosold As New DataTable
    Dim tabladedatosactual As New DataTable
    Dim datagridoriginal As New DataGridView
    Dim clave_ordenpagoactual As Long
    Dim clave_expediente As Long = 0
    Dim TABLAORIGEN As New DataTable
    Dim TABLAINSTRUMENTOLEGAL As New DataTable
    Dim TIPODETABLA As String = ""
    Dim TIPODECARGA As String = "CargarDatatable"
    Dim FILAORIGINAL As New DataGridViewRow

    Private Sub Dialogo_ModificarDatatable_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cargainicial = False
    End Sub

    Private Sub Panelsuperior_MouseMove(sender As Object, e As MouseEventArgs) Handles Panelsuperior.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Public Sub CargarDatatable(ByRef formulario As System.Windows.Forms.Form, ByRef tabladedatos As DataTable, ByRef datagrid As DataGridView, Optional ByVal claveExpediente As Long = 0, Optional ByVal clave_ordenpago As Long = 0)
        tabladedatosold = tabladedatos.Copy
        tabladedatosactual = tabladedatos
        datagridoriginal = datagrid
        Datos_datagridview.DataSource = tabladedatosactual
        For X = 0 To Datos_datagridview.Columns.Count - 1
            Datos_datagridview.Columns(X).Visible = datagrid.Columns(X).Visible
            If Datos_datagridview.Columns(X).Name = "SPL01" Or
        Datos_datagridview.Columns(X).Name = "SPL02" Or
        Datos_datagridview.Columns(X).Name = "SPL03" Or
        Datos_datagridview.Columns(X).Name = "SPL04" Or
        Datos_datagridview.Columns(X).Name = "SPL05" Or
        Datos_datagridview.Columns(X).Name = "SPL06" Or
        Datos_datagridview.Columns(X).Name = "SPL07" Then
                Datos_datagridview.Columns(X).Visible = True
            End If
        Next
        Label_titulo.BackColor = formulario.BackColor
        FullScreen_boton.BackColor = formulario.BackColor
        Cerrar_boton.BackColor = formulario.BackColor
        Me.BackColor = formulario.BackColor
        Panelsuperior.BackColor = formulario.BackColor
        Label_titulo.Text = Me.Text & " " & datagrid.Name
        clave_expediente = claveExpediente
        clave_ordenpagoactual = clave_ordenpago
        'pintar las columnas con clave primaria
        Formatocolumnas(Datos_datagridview, CType(Datos_datagridview.DataSource, DataTable))
        Mostrardialogo(Me)
    End Sub

    Public Sub CargarSOLODatatable(ByRef formulario As System.Windows.Forms.Form, ByRef tabladedatos As DataTable, ByRef FILA As DataGridViewRow, Optional ByVal clave_ordenpago As Long = 0)
        tabladedatosold = tabladedatos.Copy
        tabladedatosactual = tabladedatos
        FILAORIGINAL = FILA
        Datos_datagridview.DataSource = tabladedatosactual
        TIPODECARGA = "CargarSOLODatatable"
        'For x = 0 To Datos_datagridview.Columns.Count - 1
        '    Select Case Datos_datagridview.Columns(x).DAataType.ToString.ToUpper
        '        Case Is = "SYSTEM.DATETIME"
        '            Datos_datagridview.Columns(x).DefaultCellStyle.Format = "dd/MM/yyyy"
        '        Case Is = "SYSTEM.DECIMAL"
        '            Datos_datagridview.Columns(x).DefaultCellStyle.Format = "C"
        '        Case Is = "SYSTEM.DBNULL"
        '        Case Else
        '            'MessageBox.Show(Tabladatos.Columns(x).DataType.ToString.ToUpper)
        '    End Select
        'Next
        For X = 0 To Datos_datagridview.Columns.Count - 1
            Datos_datagridview.Columns(X).Visible = True
        Next
        Label_titulo.BackColor = formulario.BackColor
        FullScreen_boton.BackColor = formulario.BackColor
        Cerrar_boton.BackColor = formulario.BackColor
        Me.BackColor = formulario.BackColor
        Panelsuperior.BackColor = formulario.BackColor
        clave_ordenpagoactual = clave_ordenpago
        'pintar las columnas con clave primaria
        Formatocolumnas(Datos_datagridview, CType(Datos_datagridview.DataSource, DataTable))
        Mostrardialogo(Me)
    End Sub

    Private Sub Guardar_boton_Click(sender As Object, e As EventArgs) Handles Guardar_boton.Click
        Guardar()
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Cancelar()
    End Sub

    Private Sub Guardar()
        Select Case TIPODECARGA
            Case Is = "CargarSOLODatatable"
                Dim SUMADEIMPORTES As Decimal = 0
                For Each ITEM As DataGridViewRow In Datos_datagridview.Rows
                    If ITEM.Cells.Item("monto").Value > 0 Then
                        SUMADEIMPORTES += ITEM.Cells.Item("monto").Value
                    End If
                Next
                FILAORIGINAL.Cells.Item("IMPORTE").Value = SUMADEIMPORTES
                Dim concatpartidas As String = ""
                For x = 0 To FILAORIGINAL.Cells.Count - 2
                    concatpartidas += FILAORIGINAL.Cells.Item(x).Value.ToString
                Next
                Ordendepago.guardarcalculosauxiliareshaberes(clave_ordenpagoactual, concatpartidas, tabladedatosactual)
            Case Is = ""
                datagridoriginal.DataSource = tabladedatosactual
        End Select
        Me.Close()
    End Sub

    Private Sub Cancelar()
        tabladedatosactual = tabladedatosold
        datagridoriginal.DataSource = tabladedatosold
        Me.Close()
    End Sub

    Private Sub Cancelar_boton_Click(sender As Object, e As EventArgs) Handles Cancelar_boton.Click
        Cancelar()
    End Sub

    Private Sub Dialogo_ModificarDatatable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGADETABLAS()
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

    Private Sub Datos_datagridview_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Datos_datagridview.EditingControlShowing
        Select Case CType(sender, DataGridView).SelectedCells(0).ValueType.ToString
            Case Is = "System.Int32"
               ' MessageBox.Show("Esta celda solo admite números enteros")
            Case Is = "System.Decimal"
                AddHandler e.Control.KeyPress, AddressOf Datos_datagridview_KeyPress
            Case Is = "System.String"
            Case Is = "System.DateTime"
                '    Dialog_fecha.cargageneral(CType(sender, DataGridView).SelectedCells(0))
        End Select
    End Sub

    Private Sub Datos_datagridview_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

    Private Sub Datos_datagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_datagridview.CellContentClick
    End Sub

    Private Sub Datos_datagridview_CellMouseDoubleClick(sender As DataGridView, e As DataGridViewCellMouseEventArgs) Handles Datos_datagridview.CellMouseDoubleClick
        If Not e.ColumnIndex < 0 Then
            Select Case sender.Columns(e.ColumnIndex).Name.ToUpper
                Case Is = "CUIT"
                    Dialogo_CUIT.Cargadetextbox(sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex))
                    Dialogo_CUIT.Cargadecuits(clave_expediente)
                Case Is = "CARAC"
                    DialogDialogo_Datagridview.Carga_General(Autocompletetables.Cuentas, "Seleccione por Favor la CUENTA BANCARIA", "Seleccionar", "Cancelar", 10)
                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                        sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(2).Value
                    Else
                    End If
                Case Is = "TIPO_LEGAL"
                    DialogDialogo_Datagridview.Carga_General(TABLAINSTRUMENTOLEGAL, "Seleccione por Favor el tipo de instrumento Legal habilitante", "Seleccionar", "Cancelar", 10)
                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                        sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
                    Else
                    End If
                Case Is = "TIPO_ORIGEN"
                    DialogDialogo_Datagridview.Carga_General(TABLAORIGEN, "Seleccione por Favor la forma de contratación utilizada", "Seleccionar", "Cancelar", 10)
                    If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) And DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows.Count = 1 Then
                        sender.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Value = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value
                    Else
                    End If
            End Select
        End If
    End Sub

    Private Sub FullScreen_boton_Click(sender As Object, e As EventArgs) Handles FullScreen_boton.Click
        Select Case Me.WindowState
            Case = WindowState.Maximized
                Me.WindowState = FormWindowState.Normal
            Case Else
                Me.WindowState = FormWindowState.Maximized
        End Select
    End Sub

    Private Sub Datos_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datos_datagridview.DataError
        '  Datos_datagridview.Rows(e.RowIndex).ErrorText = "La celda en columna " & Datos_datagridview.Columns(e.ColumnIndex).Name.ToUpper & " y fila Nº" & e.RowIndex + 1 & " no admite este tipo de datos, presione la tecla Escape para cancelar la modificación"
        ''MessageBox.Show(e.RowIndex.ToString & " " + e.ColumnIndex.ToString)
        'MessageBox.Show("Error happened " & e.Context.ToString())
        'If e.Context = DataGridViewDataErrorContexts.Commit Then
        '    MessageBox.Show("Commit error")
        'End If
        'If e.Context = DataGridViewDataErrorContexts.CurrentCellChange Then
        '    MessageBox.Show("Cell change")
        'End If
        'If e.Context = DataGridViewDataErrorContexts.Parsing Then
        '    MessageBox.Show("parsing error")
        'End If
        'If e.Context = DataGridViewDataErrorContexts.LeaveControl Then
        '    MessageBox.Show("leave control error")
        'End If
        'If TypeOf (e.Exception) Is ConstraintException Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    Datos_datagridview.Rows(e.RowIndex).ErrorText = "an error"
        '    Datos_datagridview.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
        '    e.ThrowException = False
        'End If
        Datos_datagridview.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Style.BackColor = Color.LightCoral
        e.Cancel = True
    End Sub

    Private Sub CALCULAR(ByVal rownumber As Integer, ByVal columnnumber As Integer)
        Try
            If Datos_datagridview.Columns(columnnumber).Name = "SPL01" Or
        Datos_datagridview.Columns(columnnumber).Name = "SPL02" Or
        Datos_datagridview.Columns(columnnumber).Name = "SPL03" Or
        Datos_datagridview.Columns(columnnumber).Name = "SPL04" Or
        Datos_datagridview.Columns(columnnumber).Name = "SPL05" Or
        Datos_datagridview.Columns(columnnumber).Name = "SPL06" Or
        Datos_datagridview.Columns(columnnumber).Name = "SPL07" Then
                Datos_datagridview.Rows(rownumber).Cells.Item("IMPORTE").Value = 0
                For x = 4 To 10
                    Datos_datagridview.Rows(rownumber).Cells.Item("IMPORTE").Value += CType(Datos_datagridview.Rows(rownumber).Cells.Item(x).Value, Decimal)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Datos_datagridview_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_datagridview.CellValidated
        Datos_datagridview.Rows(e.RowIndex).Cells.Item(e.ColumnIndex).Style.BackColor = Color.White
        If Not cargainicial Then
            CALCULAR(e.RowIndex, e.ColumnIndex)
        End If
    End Sub

    Private Sub Datos_datagridview_KeyDown(sender As Object, e As KeyEventArgs) Handles Datos_datagridview.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            e.Handled = True
            PasteFromClipboard(sender, e)
        Else
            If e.KeyCode = Keys.Delete Then
                Select Case Datos_datagridview.SelectionMode
                    Case Is = 1 'full row
                        'For Each DataGridViewRow As DataGridViewRow In Datos_datagridview.SelectedRows
                        '    If Not DataGridViewRow.IsNewRow Then
                        '        Datos_datagridview.Rows.Remove(DataGridViewRow)
                        '    End If
                        'Next
                    Case Is = 0 ' cell select
                        For Each DataGridViewCell In Datos_datagridview.SelectedCells
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
        End If
    End Sub

    Private Sub Datos_datagridview_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_datagridview.RowHeaderMouseClick
        Select Case sender.SelectionMode
            Case Is = 1 'fullrow
                sender.SelectionMode = DataGridViewSelectionMode.CellSelect
            Case Is = 0 ' cellselect
                sender.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                sender.Rows(e.RowIndex).Selected = True
        End Select
    End Sub

    Private Sub Label_titulo_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_titulo.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Datos_datagridview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Datos_datagridview.CellEndEdit
        ' Datos_datagridview.AutoResizeRow(Datos_datagridview.SelectedRows(0).Index, DataGridViewAutoSizeRowMode.AllCellsExceptHeader)
    End Sub

    Private Sub Datos_datagridview_MouseUp(sender As DataGridView, e As MouseEventArgs) Handles Datos_datagridview.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim nombresdecolumna As New List(Of String)
            Dim evaluartiposeleccion As Boolean = False
            Dim fila As New DataGridViewRow
            For Each item As DataGridViewColumn In sender.Columns
                nombresdecolumna.Add(item.HeaderText)
            Next
            Select Case sender.SelectionMode
                Case Is = DataGridViewSelectionMode.FullRowSelect
                    If sender.SelectedRows.Count = 1 Then
                        evaluartiposeleccion = True
                        fila = sender.SelectedRows(0)
                    End If
                Case Is = DataGridViewSelectionMode.CellSelect
                    If sender.SelectedCells.Count = 1 Then
                        evaluartiposeleccion = True
                        fila = sender.Rows(sender.SelectedCells(0).RowIndex)
                    End If
            End Select
            If evaluartiposeleccion And nombresdecolumna.Contains("PDAPCIAL") And clave_ordenpagoactual > 0 Then
                Select Case fila.Cells.Item("PDAPCIAL").Value.ToString
                    Case Is = "01140"
                        Dim concatpartidas As String = ""
                        For x = 0 To sender.Columns.Count - 2
                            concatpartidas += fila.Cells.Item(x).Value.ToString
                        Next
                        Dim Calculos_auxiliares As New Dialogo_ModificarDatatable
                        Dim tabladedatos As DataTable = Ordendepago.CargarHaberesCALCULOSAUXILIARES(clave_ordenpagoactual, concatpartidas)
                        Calculos_auxiliares.CargarSOLODatatable(Me, tabladedatos, fila, clave_ordenpagoactual)
                        'With Calculos_auxiliares
                        '    .MdiParent = Inicio
                        'End With
                        'Calculos_auxiliares.ShowDialog()
                        '  Calculos_auxiliares.CargarSOLODatatable(Me, tabladedatos, fila)
                    Case Else
                End Select
            End If
        End If
    End Sub

    Private Sub Datos_datagridview_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Datos_datagridview.CellMouseDoubleClick
    End Sub

    Private Sub Datos_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Datos_datagridview.MouseUp
    End Sub

End Class