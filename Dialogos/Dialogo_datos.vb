Imports System.Reflection

Public Class Dialogo_datos
    Dim tablatemporal As New DataTable

    'Dim dv As DataView
    Public Sub IniciadorDatos(ByVal Consultasql As String, ByVal Nombredatos As String)
        Dim Tablatemporal2 As New DataTable
        'MessageBox.Show(Consultamysqlsinparametros)
        SERVIDORMYSQL.COMMANDSQL.CommandText = Consultasql
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultasql, Tablatemporal2, System.Reflection.MethodBase.GetCurrentMethod.Name)
        tablatemporal = Tablatemporal2
        Datosdialogo_datagridview.DataSource = tablatemporal
        For x = 0 To tablatemporal.Columns.Count - 1
            Select Case tablatemporal.Columns(x).DataType.ToString.ToUpper
                Case Is = "SYSTEM.DATETIME"
                    Datosdialogo_datagridview.Columns(x).DefaultCellStyle.Format = "dd/MM/yyyy"
                Case Is = "SYSTEM.DECIMAL"
                    Datosdialogo_datagridview.Columns(x).DefaultCellStyle.Format = "C"
                Case Is = "SYSTEM.DBNULL"
                Case Else
                    'MessageBox.Show(Tabladatos.Columns(x).DataType.ToString.ToUpper)
            End Select
        Next
        '        Label_Informacion.Text = Nombredatos
        Label_titulo.Text = Nombredatos
        Mostrardialogo(Me)
        'Me.ShowDialog()
    End Sub

    Public Sub mostrardatatable(ByRef Tabladatos As DataTable, Optional ByVal Titulo As String = "", Optional ByVal ordencolumnas As DataGridViewAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None)
        Datosdialogo_datagridview.DataSource = Tabladatos
        For x = 0 To Tabladatos.Columns.Count - 1
            Select Case Tabladatos.Columns(x).DataType.ToString.ToUpper
                Case Is = "SYSTEM.DATETIME"
                    Datosdialogo_datagridview.Columns(x).DefaultCellStyle.Format = "dd/MM/yyyy"
                Case Is = "SYSTEM.DECIMAL"
                    Datosdialogo_datagridview.Columns(x).DefaultCellStyle.Format = "C"
                Case Is = "SYSTEM.DBNULL"
                Case Else
                    'MessageBox.Show(Tabladatos.Columns(x).DataType.ToString.ToUpper)
            End Select
        Next
        '        Label_Informacion.Text = Nombredatos
        Label_titulo.Text = Titulo
        Datosdialogo_datagridview.AutoSizeColumnsMode = ordencolumnas
        If Datosdialogo_datagridview.Columns.Contains("clave_expediente_detalle") Then
            Datosdialogo_datagridview.Columns("clave_expediente_detalle").Visible = False
        End If
        Datosdialogo_datagridview.CurrentCell = Nothing
        Mostrardialogo(Me)
        'Me.ShowDialog()
    End Sub

    Public Sub mostrardatatablemfYV(ByRef Tabladatos As DataTable)
        Datosdialogo_datagridview.DataSource = Tabladatos
        If Not IsNothing(Tabladatos) Then
            If (Tabladatos.Rows.Count > 0) Then
                Datosdialogo_datagridview.Columns(8).DefaultCellStyle.Format = "C"
                Datosdialogo_datagridview.Columns(9).DefaultCellStyle.Format = "C"
                Label_titulo.Text = ""
                Mostrardialogo(Me)
            Else
                MessageBox.Show("No contiene datos")
            End If
        Else
            MessageBox.Show("Tabla de datos vacía")
        End If
        'Me.ShowDialog()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Datosdialogo_datagridview.DataSource = Nothing
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Datosdialogo_datagridview.DataSource = Nothing
        Me.Close()
    End Sub

    Public Sub EnableDoubleBuffered(ByVal dgv As DataGridView)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, True, Nothing)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        EnableDoubleBuffered(Datosdialogo_datagridview)
    End Sub

    Private Sub DataGridView1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Datosdialogo_datagridview.MouseWheel
        DataGridView_MouseWheel(sender, e)
    End Sub

    Private Sub Datosdialogo_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Datosdialogo_datagridview.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
        'Select Case Busqueda.Text.Length
        '    Case Is = 0
        '        Datosdialogo_datagridview.DataSource = tablatemporal
        '    Case Else
        '        Dim Filtro As String = ""
        '        For x = 0 To Aclaratorios.Items.Count - 1
        '            Select Case x
        '                Case = 0
        '                    Filtro = " (CONVERT([" & Aclaratorios.Items(x).ToString & "], 'System.String') like '%" & Busqueda.Text & "%') OR  "
        '                Case Is = Aclaratorios.Items.Count - 1
        '                    Filtro = Filtro & " (CONVERT([" & Aclaratorios.Items(x).ToString & "], 'System.String') like '%" & Busqueda.Text & "%') "
        '                Case Else
        '                    Filtro = Filtro & " (CONVERT([" & Aclaratorios.Items(x).ToString & "], 'System.String') like '%" & Busqueda.Text & "%') OR  "
        '            End Select
        '        Next
        '        '  MessageBox.Show(Filtro)
        '        dv = New DataView(tablatemporal, Filtro, "[" & tablatemporal.Columns(0).ColumnName.ToString & "] Desc", DataViewRowState.CurrentRows)
        '        Datosdialogo_datagridview.DataSource = dv
        '        'If Aclaratorios.SelectedIndex > -1 Then
        '        '
        '        '    'dv = New DataView(tablatemporal, "CONVERT([" & Aclaratorios.SelectedItem.ToString & "], 'System.String') like '%" & Busqueda.Text & "%' ", "[" & Aclaratorios.SelectedItem.ToString & "] Desc", DataViewRowState.CurrentRows)
        '        '    Datosdialogo_datagridview.DataSource = dv
        '        'Else
        '        '    Datosdialogo_datagridview.DataSource = tablatemporal
        '        'End If
        'end select
        Buscar_datagrid_TIMER(sender, tablatemporal, CType(Datosdialogo_datagridview, DataGridView))
    End Sub

    Private Sub Aclaratorios_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Dialogo_datos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    End Sub

    Private Sub Datosdialogo_datagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datosdialogo_datagridview.CellContentClick
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Label_titulo_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_titulo.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

End Class