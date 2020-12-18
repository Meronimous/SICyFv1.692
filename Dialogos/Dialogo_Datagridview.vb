Public Class DialogDialogo_Datagridview
    Dim TEXTOBUSCADO As String = ""
    Dim Datos_importados_datatable As New DataTable
    Public Property FilaSeleccionada As DataGridViewRow
    Dim resultadoseleccion_temporal As String = ""

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If Datosdialogo_datagridview.SelectedRows.Count > 0 Then
            FilaSeleccionada = Datosdialogo_datagridview.SelectedRows(0)
        End If
        Resultadoseleccion = resultadoseleccion_temporal
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        FilaSeleccionada = Nothing
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Carga_General(ByVal Datos As DataTable, ByVal NombredelMessage As String, ByVal Ok_boton As String, ByVal Cancelar_boton As String, Optional ByVal tamaniofuente As Single = 8.25, Optional ByVal listacolumnas As List(Of DataGridViewColumn) = Nothing, Optional ByVal textobuscador As String = "")
        'Seleccion_listbox.Items.Clear()
        'For x = 0 To Lista.Count - 1
        '    Seleccion_listbox.Items.Add(Lista(x))
        'Next
        'Encabezado del dialogo
        Datos_importados_datatable = Datos
        FilaSeleccionada = Nothing
        Datosdialogo_datagridview.DataSource = Datos_importados_datatable
        NombredelMessage_label.Text = NombredelMessage
        Dim fuente As Font = New Font(Datosdialogo_datagridview.DefaultCellStyle.Font.Name, tamaniofuente, FontStyle.Bold)
        Datosdialogo_datagridview.DefaultCellStyle.Font = fuente
        For x = 0 To Datos_importados_datatable.Columns.Count - 1
            Select Case Datos_importados_datatable.Columns(x).DataType.ToString.ToUpper
                Case Is = "SYSTEM.DATETIME"
                    Datosdialogo_datagridview.Columns(x).DefaultCellStyle.Format = "dd/MM/yyyy"
                Case Is = "SYSTEM.DECIMAL"
                    Datosdialogo_datagridview.Columns(x).DefaultCellStyle.Format = "C"
                    Datosdialogo_datagridview.Columns(x).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Is = "SYSTEM.DBNULL"
                Case Else
                    'MessageBox.Show(Tabladatos.Columns(x).DataType.ToString.ToUpper)
            End Select
        Next
        'If Not IsNothing(listacolumnas) Then
        '    For X = 0 To Datos.Columns.Count - 1
        '        Datosdialogo_datagridview.Columns(X).AutoSizeMode = listacolumnas.Item(X).AutoSizeMode
        '    Next
        'End If
        Datosdialogo_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Datosdialogo_datagridview.AutoResizeRows()
        If (Datosdialogo_datagridview.PreferredSize.Width + 25 > 525) Then
            If Datosdialogo_datagridview.PreferredSize.Width + 25 > My.Computer.Screen.Bounds.Width Then
                'Me.Width = 1050
                Me.WindowState = FormWindowState.Maximized
            Else
                Me.Width = Datosdialogo_datagridview.PreferredSize.Width + 25
            End If
        Else
            Me.Width = 525
        End If
        'Message de los botones de aceptar o no
        OK_Button.Text = Ok_boton
        Cancel_Button.Text = Cancelar_boton
        Busqueda_dialogo.Focus()
        TEXTOBUSCADO = textobuscador
    End Sub

    'Private Sub Seleccion_listbox_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If Seleccion_listbox.SelectedIndex >= 0 Then
    '        OK_Button.Enabled = True
    '        resultadoseleccion_temporal = Seleccion_listbox.SelectedItem.ToString
    '        Label_seleccionactiva.Text = Seleccion_listbox.SelectedItem.ToString
    '    End If
    'End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub NombredelMessage_label_MouseMove(sender As Object, e As MouseEventArgs) Handles NombredelMessage_label.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Datosdialogo_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosdialogo_datagridview.CellEnter
        OK_Button.Enabled = True
        If Datosdialogo_datagridview.SelectedRows.Count > 0 Then
            OK_Button.Enabled = True
            FilaSeleccionada = Datosdialogo_datagridview.SelectedRows(0)
        End If
    End Sub

    Private Sub Busqueda_dialogo_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_dialogo.TextChanged
        Buscar_datagrid_TIMER(sender, Datos_importados_datatable, Datosdialogo_datagridview)
    End Sub

    Private Sub Datosdialogo_datagridview_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Datosdialogo_datagridview.CellMouseDoubleClick
        OK_Button.PerformClick()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub DialogDialogo_Datagridview_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        With Inicio
            .Opacity = 1
            '.Enabled = False
        End With
    End Sub

    Private Sub DialogDialogo_Datagridview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Busqueda_dialogo.Text = ""
        With Inicio
            .Opacity = 0.9
            '.Enabled = False
        End With
        Me.BringToFront()
    End Sub

    Private Sub Datosdialogo_datagridview_KeyDown(sender As Object, e As KeyEventArgs) Handles Datosdialogo_datagridview.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            OK_Button.PerformClick()
        End If
    End Sub

    Private Sub DialogDialogo_Datagridview_BindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
    End Sub

    Private Sub FullScreen_boton_Click(sender As Object, e As EventArgs) Handles FullScreen_boton.Click
        Select Case Me.WindowState
            Case = WindowState.Maximized
                Me.WindowState = FormWindowState.Normal
            Case Else
                Me.WindowState = FormWindowState.Maximized
        End Select
    End Sub

    Private Sub DialogDialogo_Datagridview_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub DialogDialogo_Datagridview_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Busqueda_dialogo.Text = TEXTOBUSCADO
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

End Class