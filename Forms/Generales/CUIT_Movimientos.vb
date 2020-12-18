Public Class Cuit_Movimientos
    Dim backupcomando As New MySql.Data.MySqlClient.MySqlCommand
    Dim datosnoasociados As New DataTable
    Dim datosasociados As New DataTable
    Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    Dim activartimer As Boolean = False
    Dim clave_expediente As Long
    Dim Datagridlocal As DataGridView
    Dim montolocal As Object
    'DECLARADO PARA PODER MOVER EL DIALOGO Dim Pos As Point
    Dim Pos As Point

    Private Sub Tiempodetecleo_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Select Case activartimer
            Case True
                BusquedaexpedientesNOasociados_textbox.Enabled = False
                Inicio.OBJETOCARGANDO(DatosNOasociados_datagridview, Me, "Cargando Pedidos de fondos")
                Refreshcuitnoasociados()
                Inicio.OBJETOFINALIZAR(DatosNOasociados_datagridview, Me)
                'freno de mano al timer
                Tiempodetecleo.Stop()
                BusquedaexpedientesNOasociados_textbox.Enabled = True
                BusquedaexpedientesNOasociados_textbox.Select()
                activartimer = False
            Case False
        End Select
    End Sub

    Public Sub Asociarcuit(ByVal clave_expediente_long As Long, ByRef Datagrid As DataGridView, ByRef monto As Object)
        clave_expediente = clave_expediente_long
        Datagridlocal = Datagrid
        montolocal = monto
        Me.ShowDialog()
    End Sub

    Private Sub Salidayactualizacion()
        Dim valoresencero = False
        Dim Proveedorencero As New List(Of String)
        Dim totaldeproveedores As String = ""
        For x = 0 To Datosasociados_datagridview.Rows.Count - 1
            If Datosasociados_datagridview.Rows(x).Cells.Item("Monto").Value = 0 Then
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                Proveedorencero.Add(Datosasociados_datagridview.Rows(x).Cells.Item("Proveedor").Value.ToString)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                valoresencero = True
            End If
        Next
        If valoresencero Then
            For Z = 0 To Proveedorencero.Count - 1
                totaldeproveedores = totaldeproveedores & vbCrLf & Proveedorencero(Z)
            Next
            Select Case MsgBox("Los Siguientes proveedores tienen un monto Asignado de $0,00" & vbCrLf & totaldeproveedores & vbCrLf & "¿Es correcto?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                    'verificación
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                    Tesoreria_Expedientes.refreshgeneral()
                Case MsgBoxResult.Cancel
                Case MsgBoxResult.No
            End Select
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Datosasociados_datagridview.DataSource = Nothing
            'Select Case ventanaorigen.Name
            '    Case Is = Tesoreria_Expedientes.Name
            '    Case Is = General_nuevoexpediente.Name
            'End Select
            Me.Close()
            Dialogo_Nuevoexpediente.cargadatosproveedores()
            Tesoreria_Expedientes.refreshgeneral()
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Salidayactualizacion()
    End Sub

    'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End Sub
    Private Sub refreshcuit()
        ' If Expedientes.BusquedaWPF1.Datos_datagrid.SelectedItems.Count > 0 Then
        refreshcuitasociados()
        Refreshcuitnoasociados()
        '  Else
        '  MessageBox.Show("Debe seleccionar un expediente para agregarle sus proveedores")
        '  End If
        '
    End Sub

    Private Sub refreshcuitasociados()
        Dim consultaasociada As String = ""
        Dim datosasociados As New DataTable
        Dim consultaNoasociada As String = ""
        Dim datosnoasociados As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        consultaasociada = "Select Proveedor,CUIT,MONTO,MD5HASH FROM (SElect CUIT,MONTO,Clave_expediente,MD5HASH from CUIT_expediente where Clave_expediente=@clave_expediente)A
LEFT JOIN
(Select Proveedor,CUIT as 'Cuitproveedores' from proveedores) B ON
A.CUIT=B.Cuitproveedores"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultaasociada, datosasociados, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datosasociados_datagridview.DataSource = datosasociados
        Datosasociados_datagridview.Columns("MD5HASH").Visible = False
        Dim sumadelexpediente As Decimal = 0
        For x = 0 To Datosasociados_datagridview.Rows.Count - 1
            sumadelexpediente += CType(Datosasociados_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal)
        Next
        Montodelexpediente(sumadelexpediente, Datagridlocal, montolocal)
    End Sub

    Private Sub Refreshcuitnoasociados()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Busqueda", "%" & BusquedaexpedientesNOasociados_textbox.Text & "%")
        consultaNoasociada = "Select Proveedor,CUIT from proveedores where Cuit Not in (Select Cuit from cuit_expediente where Clave_expediente=@clave_expediente) AND
(Cuit like @Busqueda OR Proveedor like @busqueda)"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultaNoasociada, datosnoasociados, System.Reflection.MethodBase.GetCurrentMethod.Name)
        DatosNOasociados_datagridview.DataSource = datosnoasociados
    End Sub

    Private Sub Montodelexpediente(ByVal sumadelexpediente As Decimal, ByRef Datagrid As DataGridView, ByRef Monto As Object)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", sumadelexpediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = " UPDATE `expediente` SET Monto=@Monto,Usuario=@Usuario Where Clave_expediente=@Clave_expediente"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'Select Case Datagrid.GetType.ToString.ToUpper
        '    Case "SYSTEM.WINDOWS.CONTROLS.DATAGRID"
        '        Datagrid.SelectedCells.Item(0).Item("Monto") = sumadelexpediente
        '    Case "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
        'End Select
        ' Datagrid.SelectedRows(0).Cells.Item("Monto").Value = sumadelexpediente
        Select Case Monto.GetType.ToString
            Case "CURRENCYTEXTBOXCONTROL.CURRENCYTEXTBOX"
                Monto.Number = sumadelexpediente
            Case "SYSTEM.WINDOWS.FORMS.TEXTBOX"
                Monto.text = sumadelexpediente
        End Select
        '   MessageBox.Show(Monto.GetType.ToString)
        ' MessageBox.Show(Expedientes.BusquedaWPF1.Datos_datagrid.GetType.ToString)
        '        Expedientes.Control_ExpedientesWPF1.Montodelexpediente_textbox.Number = sumadelexpediente
        '        Expedientes.BusquedaWPF1.Datos_datagrid.SelectedCells.Item(0).Item("Monto") = sumadelexpediente
        Sumadelexpedientelocal.Monto_textbox.Number = sumadelexpediente
    End Sub

    Private Sub Asociar()
        For x = 0 To DatosNOasociados_datagridview.SelectedRows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Inicio.GenerateHash(DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("CUIT").Value.ToString & clave_expediente))
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("CUIT").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", 0)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", clave_expediente)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
            '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO cuit_expediente (MD5HASH,CUIT,Monto,Clave_expediente,Usuario) values(@MD5HASH,@CUIT,@Monto,@Clave_expediente,@Usuario) ;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        refreshcuit()
    End Sub

    Private Sub Quitarasociacion()
        Dim sumadelexpediente As Decimal = 0
        For x = 0 To Datosasociados_datagridview.SelectedRows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Datosasociados_datagridview.SelectedRows(x).Cells.Item("MD5HASH").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
            '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Delete from cuit_expediente where MD5HASH=@MD5HASH ;"
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        refreshcuit()
        For x = 0 To Datosasociados_datagridview.Rows.Count - 1
            sumadelexpediente = sumadelexpediente + CType(Datosasociados_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal)
        Next
        Montodelexpediente(sumadelexpediente, Datagridlocal, montolocal)
    End Sub

    Public Sub cargadeproveedores(ByVal backupsqlnoasociado As MySql.Data.MySqlClient.MySqlCommand, ByVal backupsqlasociado As MySql.Data.MySqlClient.MySqlCommand, ByVal Consultanoasociada As String, ByVal Consultaasociada As String)
        SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
        For x = 0 To backupsqlnoasociado.Parameters.Count - 1
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue(backupsqlnoasociado.Parameters.Item(x).ParameterName, backupsqlnoasociado.Parameters.Item(x).Value)
        Next
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultanoasociada, datosnoasociados, System.Reflection.MethodBase.GetCurrentMethod.Name)
        For x = 0 To backupsqlasociado.Parameters.Count - 1
            SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue(backupsqlnoasociado.Parameters.Item(x).ParameterName, backupsqlasociado.Parameters.Item(x).Value)
        Next
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, Consultaasociada, datosasociados, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datosasociados_datagridview.DataSource = datosasociados
        DatosNOasociados_datagridview.DataSource = datosnoasociados
    End Sub

    Private Sub Cuit_expedientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Inicio.Enabled = False
    End Sub

    Private Sub Cuit_expedientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Select Case MsgBox("Hay al menos un proveedor cuyo monto Asignado es $0,00", MsgBoxStyle.YesNoCancel, " ")
        '    Case MsgBoxResult.Yes
        '        'verificación
        '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '        Datosasociados_datagridview.DataSource = Nothing
        '        DatosNOasociados_datagridview.DataSource = Nothing
        '        Tesoreria_Expedientes.refreshgeneral()
        '        Me.Close()
        '    Case MsgBoxResult.Cancel
        '    Case MsgBoxResult.No
        'End Select
    End Sub

    Private Sub Asociarexpediente_boton_Click(sender As Object, e As EventArgs) Handles Asociarexpediente_boton.Click
        Asociar()
    End Sub

    Private Sub Quitarasociacion_boton_Click(sender As Object, e As EventArgs) Handles Quitarasociacion_boton.Click
        Quitarasociacion()
    End Sub

    Private Sub Cuit_expedientes_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        refreshcuit()
    End Sub

    Private Sub Datosasociados_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosasociados_datagridview.CellEnter
        If Datosasociados_datagridview.SelectedRows.Count > 0 Then
            Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").Selected = True
            Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").ReadOnly = False
        End If
    End Sub

    Private Sub Datosasociados_datagridview_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Datosasociados_datagridview.CellValueChanged, Datosasociados_datagridview.CellLeave
        'If Datosasociados_datagridview.SelectedRows.Count > 0 Then
        '    If Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").IsInEditMode Then
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Datosasociados_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Value)
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").Value)
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Expedientes.BusquedaWPF1.Datos_datagrid.SelectedCells.Item(0).Item("Clave_expediente").ToString)
        '        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
        '        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
        '        '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE cuit_expediente SET MONTO=@MONTO WHERE MD5HASH=@MD5HASH;"
        '        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        '    End If
        'End If
    End Sub

    Private Sub Datosasociados_datagridview_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
    End Sub

    Private Sub Datosasociados_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datosasociados_datagridview.DataError
        MessageBox.Show("Debe ingresar unicamente números")
    End Sub

    Private Sub Datosasociados_datagridview_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Datosasociados_datagridview.KeyPress
        If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = "," Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub Datosasociados_datagridview_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Datosasociados_datagridview.CellEndEdit
        'Dim sumadelexpediente As Decimal = 0
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Datosasociados_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Value)
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").Value)
        'Datosasociados_datagridview.SelectedRows(0).DefaultCellStyle.BackColor = Color.LightGreen
        'Datosasociados_datagridview.SelectedRows(0).DefaultCellStyle.SelectionBackColor = Color.Green
        'Datosasociados_datagridview.SelectedRows(0).DefaultCellStyle.SelectionForeColor = Color.White
        ''SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
        ''SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
        ''     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
        'SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE cuit_expediente SET MONTO=@MONTO WHERE MD5HASH=@MD5HASH;"
        'Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        'For x = 0 To Datosasociados_datagridview.Rows.Count - 1
        '    sumadelexpediente = sumadelexpediente + CType(Datosasociados_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal)
        'Next
        'Montodelexpediente(sumadelexpediente)
    End Sub

    Private Sub Datosasociados_datagridview_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Datosasociados_datagridview.CellBeginEdit
        Datosasociados_datagridview.SelectedRows(0).DefaultCellStyle.SelectionBackColor = Color.Yellow
        '  Datosasociados_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Style.BackColor = Color.LightYellow
    End Sub

    Private Sub BusquedaexpedientesNOasociados_textbox_TextChanged(sender As Object, e As EventArgs) Handles BusquedaexpedientesNOasociados_textbox.TextChanged
        '  DispatcherTimer setup
        activartimer = True
        RemoveHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        AddHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        Tiempodetecleo.Interval = TimeSpan.FromMilliseconds(300)
        ' = New TimeSpan(0, 0, 1)
        Tiempodetecleo.Start()
    End Sub

    Private Sub Boton_Nuevo_Click(sender As Object, e As EventArgs) Handles Boton_Nuevo.Click
        CUIT_agregarnuevo.llamado(Me, 0)
        Refreshcuitnoasociados()
    End Sub

    Private Sub Label_expedienteasociados_Click(sender As Object, e As EventArgs) Handles Label_expedienteasociados.Click
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub DatosNOasociados_datagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatosNOasociados_datagridview.CellContentClick
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label_expedienteasociados.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Datosasociados_datagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datosasociados_datagridview.CellContentClick
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Salidayactualizacion()
    End Sub

End Class