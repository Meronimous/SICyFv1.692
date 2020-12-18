Public Class Cuit_Expedientes
    Dim backupcomando As New MySql.Data.MySqlClient.MySqlCommand
    Dim expediente_actual As New Expediente
    Dim datosnoasociados As New DataTable
    Dim datosasociados As New DataTable
    Dim haberes As Integer = 0
    ' Dim Tiempodetecleo As New Windows.Threading.DispatcherTimer()
    '  Dim activartimer As Boolean = False
    Dim clave_expediente As Long
    Dim DATAGRIDSELECCIONADO As DataGridView
    Dim Datagridlocal As DataGridView
    Dim montolocal As Object
    'DECLARADO PARA PODER MOVER EL DIALOGO Dim Pos As Point
    Dim Pos As Point

    'Private Sub Tiempodetecleo_Tick(ByVal sender As Object, ByVal e As EventArgs)
    '    Select Case activartimer
    '        Case True
    '            BusquedaexpedientesNOasociados_textbox.Enabled = False
    '            Inicio.OBJETOCARGANDO(DatosNOasociados_datagridview, Me, "Cargando Pedidos de fondos")
    '            Refreshcuitnoasociados()
    '            Inicio.OBJETOFINALIZAR(DatosNOasociados_datagridview, Me)
    '            'freno de mano al timer
    '            Tiempodetecleo.Stop()
    '            BusquedaexpedientesNOasociados_textbox.Enabled = True
    '            BusquedaexpedientesNOasociados_textbox.Select()
    '            activartimer = False
    '        Case False
    '    End Select
    'End Sub
    Public Sub Asociarcuit(ByVal expediente_seleccionado As Expediente, ByRef Datagrid As DataGridView, ByRef monto As Object, Optional ByVal haberes_local As Integer = 0)
        expediente_actual = expediente_seleccionado
        clave_expediente = expediente_seleccionado.claveexpediente
        haberes = haberes_local
        Datagridlocal = Datagrid
        montolocal = monto
        Mostrardialogo(Me)
        '        Me.ShowDialog()
    End Sub

    Private Sub Borrar_haberes()
        Datosasociados_datagridview.CurrentCell = Nothing
        Datosasociados_datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        For x = 0 To Datosasociados_datagridview.Rows.Count - 1
            If Datosasociados_datagridview.Rows(x).Cells.Item("Monto").Value = 0 Then
                Datosasociados_datagridview.Rows(x).Selected = True
            End If
        Next
        Quitarasociacion()
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
                    If expediente_actual.haberes = 0 Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                        Tesoreria_Expedientes.refreshgeneral()
                    Else
                        Borrar_haberes()
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                        Tesoreria_Expedientes.refreshgeneral()
                    End If
                    'BORRAR LO QUE ESTA EN 0
                Case MsgBoxResult.Cancel
                Case MsgBoxResult.No
            End Select
        Else
            BusquedaexpedientesNOasociados_textbox.Text = ""
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
    Private Sub Refreshcuit()
        ' If Expedientes.BusquedaWPF1.Datos_datagrid.SelectedItems.Count > 0 Then
        Refreshcuitasociados()
        Refreshcuitnoasociados()
        Valoresbasicossueldo()
        '  Else
        '  MessageBox.Show("Debe seleccionar un expediente para agregarle sus proveedores")
        '  End If
        '
    End Sub

    Private Sub Refreshcuitasociados()
        Dim consultaasociada As String = ""
        Dim datosasociados As New DataTable
        Dim consultaNoasociada As String = ""
        Dim datosnoasociados As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        If haberes = 0 Then
            consultaasociada = "Select Proveedor,CUIT,MONTO,MD5HASH,NOMBREFANTASIA  FROM (SElect CUIT,MONTO,Clave_expediente,MD5HASH from CUIT_expediente where Clave_expediente=@clave_expediente)A
LEFT JOIN
(Select Proveedor,CUIT as 'Cuitproveedores',NOMBREFANTASIA from proveedores) B ON
A.CUIT=B.Cuitproveedores"
        Else
            consultaasociada = "Select detalle as 'Proveedor',CUIT,MONTO,MD5HASH FROM (SElect CUIT,MONTO,Clave_expediente,MD5HASH,detalle from CUIT_expediente where Clave_expediente=@clave_expediente)A ORDER BY CUIT ASC"
        End If
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultaasociada, datosasociados, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datosasociados_datagridview.DataSource = datosasociados
        Datosasociados_datagridview.Columns("MD5HASH").Visible = False
        'Datosasociados_datagridview.Columns("NOMBREFANTASIA").Visible = False
        If haberes = 0 Then
            Datosasociados_datagridview.Columns("CUIT").Visible = True
        Else
            Datosasociados_datagridview.Columns("CUIT").Visible = False
        End If
        Dim sumadelexpediente As Decimal = 0
        For x = 0 To Datosasociados_datagridview.Rows.Count - 1
            sumadelexpediente += CType(Datosasociados_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal)
        Next
        Montodelexpediente(sumadelexpediente, Datosasociados_datagridview, montolocal)
        Datosasociados_datagridview.Columns("MONTO").DefaultCellStyle.Format = "C"
    End Sub

    Private Sub Valoresbasicossueldo()
        If haberes = 1 And Datosasociados_datagridview.Rows.Count = 0 And DatosNOasociados_datagridview.Rows.Count > 0 Then
            For x = 0 To DatosNOasociados_datagridview.Rows.Count - 1
                Select Case DatosNOasociados_datagridview.Rows(x).Cells.Item("CUIT").Value.ToString
                    Case Is = "30-64978909-2" 'NETO-COMPLETAR CON DETALLE
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "30-64978909-7" 'JUB. AP.ESTATAL
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "30-64978910-1" 'OBRA SOC. AP. PERSONAL IPS
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "99-38090000-1" 'SEGURO OBLIG. NACIÓN
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "99-38090000-5" 'SEGURO SEPELIO NACIÓN
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "30-64979909-6" 'RET TARJETA NATURAL - FED MUTUALES -  PRESTAFACIL
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "99-38090000-2" 'RET. GREMIOS
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "99-38090000-3" 'IPRODHA
                        DatosNOasociados_datagridview.Rows(x).Selected = True
                    Case Is = "" '
                    Case Is = "" '
                    Case Else
                End Select
            Next
            Asociar()
            For x = 0 To Datosasociados_datagridview.Rows.Count - 1
                Select Case Datosasociados_datagridview.Rows(x).Cells.Item("CUIT").Value.ToString
                    Case Is = "30-64978909-2" 'NETO-COMPLETAR CON DETALLE
                        Datosasociados_datagridview.Rows(x).Cells.Item("PROVEEDOR").Value = expediente_actual.descripcion
                    Case Is = "30-64978909-7" 'JUB. AP.ESTATAL
                        Datosasociados_datagridview.Rows(x).Cells.Item("PROVEEDOR").Value = "OBRA SOCIAL AP. ESTATAL"
                    Case Is = "30-64978910-1" 'OBRA SOC. AP. PERSONAL IPS
                        Datosasociados_datagridview.Rows(x).Cells.Item("PROVEEDOR").Value = "OBRA SOCIAL AP. PERSONAL"
                    Case Is = "99-38090000-1" 'SEGURO OBLIG. NACIÓN
                    Case Is = "99-38090000-5" 'SEGURO SEPELIO NACIÓN
                    Case Is = "30-64979909-6" 'RET TARJETA NATURAL - FED MUTUALES -  PRESTAFACIL
                    Case Is = "99-38090000-2" 'RET. GREMIOS
                    Case Is = "99-38090000-3" 'IPRODHA
                    Case Is = "" '
                    Case Is = "" '
                    Case Else
                End Select
            Next
        End If
    End Sub

    Private Sub Refreshcuitnoasociados()
        BusquedaexpedientesNOasociados_textbox.Text = ""
        Dim consultanoasociada As String = ""
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@clave_expediente", clave_expediente)
        ' SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Busqueda", "%" & BusquedaexpedientesNOasociados_textbox.Text & "%")
        If haberes = 0 Then
            consultanoasociada = "Select Proveedor,CUIT from proveedores where Cuit Not in (Select Cuit from cuit_expediente where Clave_expediente=@clave_expediente) "
        Else
            consultanoasociada = "Select Proveedor,CUIT from proveedores_haberes where Cuit Not in (Select Cuit from cuit_expediente where Clave_expediente=@clave_expediente) "
        End If
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultanoasociada, datosnoasociados, System.Reflection.MethodBase.GetCurrentMethod.Name)
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
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DETALLE", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("PROVEEDOR").Value)
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
            'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
            '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
            If haberes = 0 Then
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO cuit_expediente (MD5HASH,CUIT,Monto,Clave_expediente,Usuario) values(@MD5HASH,@CUIT,@Monto,@Clave_expediente,@Usuario) ;"
            Else
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO cuit_expediente (MD5HASH,CUIT,Monto,Clave_expediente,DETALLE,Usuario) values(@MD5HASH,@CUIT,@Monto,@Clave_expediente,@DETALLE,@Usuario) ;"
            End If
            Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Next
        Refreshcuit()
    End Sub

    Private Sub Quitarasociacion()
        Dim sumadelexpediente As Decimal = 0
        If Datosasociados_datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect Then
            For x = 0 To Datosasociados_datagridview.SelectedRows.Count - 1
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Datosasociados_datagridview.SelectedRows(x).Cells.Item("MD5HASH").Value)
                'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
                'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
                '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Delete from cuit_expediente where MD5HASH=@MD5HASH ;"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
            Next
        Else
            Dim FILAMODIFICADA As Integer = Nothing
            For x = 0 To Datosasociados_datagridview.SelectedCells.Count - 1
                If FILAMODIFICADA = Nothing Then
                    FILAMODIFICADA = Datosasociados_datagridview.SelectedCells(x).RowIndex
                    SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Datosasociados_datagridview.Rows(FILAMODIFICADA).Cells.Item("MD5HASH").Value)
                    'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
                    'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
                    '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Delete from cuit_expediente where MD5HASH=@MD5HASH ;"
                    Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Else
                    If Not (FILAMODIFICADA = Datosasociados_datagridview.SelectedCells(x).RowIndex) Then
                        FILAMODIFICADA = Datosasociados_datagridview.SelectedCells(x).RowIndex
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Datosasociados_datagridview.Rows(FILAMODIFICADA).Cells.Item("MD5HASH").Value)
                        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
                        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
                        '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
                        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Delete from cuit_expediente where MD5HASH=@MD5HASH ;"
                        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                        FILAMODIFICADA = Nothing
                    End If
                End If
            Next
        End If
        Refreshcuit()
        For x = 0 To Datosasociados_datagridview.Rows.Count - 1
            sumadelexpediente += CType(Datosasociados_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal)
        Next
        Montodelexpediente(sumadelexpediente, Datosasociados_datagridview, montolocal)
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
        Refreshcuit()
    End Sub

    Private Sub Datosasociados_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosasociados_datagridview.CellEnter, Datosasociados_datagridview.CellClick
        If Datosasociados_datagridview.SelectedRows.Count > 0 Then
            If haberes = 0 Then
                Datosasociados_datagridview.ReadOnly = True
                Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").Selected = True
                Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").ReadOnly = False
            Else
                Datosasociados_datagridview.SelectedRows(0).Cells.Item("MONTO").Selected = True
                Datosasociados_datagridview.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub Datosasociados_datagridview_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Datosasociados_datagridview.CellLeave
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

    Private Sub Datosasociados_datagridview_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Datosasociados_datagridview.CellValueChanged
        Dim sumadelexpediente As Decimal = 0
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@MD5HASH", Datosasociados_datagridview.Rows(Datosasociados_datagridview.SelectedCells(0).RowIndex).Cells.Item("MD5HASH").Value)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Datosasociados_datagridview.Rows(Datosasociados_datagridview.SelectedCells(0).RowIndex).Cells.Item("MONTO").Value)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DETALLE", Datosasociados_datagridview.Rows(Datosasociados_datagridview.SelectedCells(0).RowIndex).Cells.Item("PROVEEDOR").Value)
        Datosasociados_datagridview.Rows(Datosasociados_datagridview.SelectedCells(0).RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
        Datosasociados_datagridview.Rows(Datosasociados_datagridview.SelectedCells(0).RowIndex).DefaultCellStyle.SelectionBackColor = Color.Green
        Datosasociados_datagridview.Rows(Datosasociados_datagridview.SelectedCells(0).RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", DatosNOasociados_datagridview.SelectedRows(x).Cells.Item("Clave_expediente").Value))
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", "")
        '     SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_pedidofondo", Year_pedidofondo_numeric.Value & Autorizaciones.Organismo.tostring.substring(0,4) & Format(Convert.ToInt32(N_pedidofondo_numeric.Value), "00000"))
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE cuit_expediente SET MONTO=@MONTO,DETALLE=@DETALLE,Usuario=@Usuario WHERE MD5HASH=@MD5HASH;"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        For x = 0 To Datosasociados_datagridview.Rows.Count - 1
            sumadelexpediente += CType(Datosasociados_datagridview.Rows(x).Cells.Item("MONTO").Value, Decimal)
        Next
        Montodelexpediente(sumadelexpediente, Datagridlocal, montolocal)
    End Sub

    Private Sub Datosasociados_datagridview_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Datosasociados_datagridview.DataError
        MessageBox.Show("Debe ingresar unicamente números")
    End Sub

    Private Sub Datosasociados_datagridview_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Datosasociados_datagridview.CellBeginEdit
        'Datosasociados_datagridview.SelectedRows(0).DefaultCellStyle.SelectionBackColor = Color.Yellow
        Datosasociados_datagridview.SelectedCells(0).Style.SelectionBackColor = Color.YellowGreen
        '  Datosasociados_datagridview.SelectedRows(0).Cells.Item("MD5HASH").Style.BackColor = Color.LightYellow
    End Sub

    Private Sub BusquedaexpedientesNOasociados_textbox_TextChanged(sender As Object, e As EventArgs) Handles BusquedaexpedientesNOasociados_textbox.TextChanged
        Buscar_datagrid_TIMER(sender, datosnoasociados, DatosNOasociados_datagridview)
        ''  DispatcherTimer setup
        'activartimer = True
        'RemoveHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'AddHandler Tiempodetecleo.Tick, AddressOf Tiempodetecleo_Tick
        'Tiempodetecleo.Interval = TimeSpan.FromMilliseconds(300)
        '' = New TimeSpan(0, 0, 1)
        'Tiempodetecleo.Start()
    End Sub

    Private Sub Boton_Nuevo_Click(sender As Object, e As EventArgs) Handles Boton_Nuevo.Click
        CUIT_agregarnuevo.llamado(Me, haberes)
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

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Salidayactualizacion()
    End Sub

    Private Sub DatosNOasociados_datagridview_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DatosNOasociados_datagridview.CellMouseDoubleClick
        Asociarexpediente_boton.PerformClick()
    End Sub

    Private Sub DatosNOasociados_datagridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatosNOasociados_datagridview.CellDoubleClick
        'If DatosNOasociados_datagridview.SelectedRows.Count = 1 Then
        '    '            Asociarexpediente_boton.PerformClick()
        '    Asociar()
        'End If
    End Sub

    Private Sub DatosNOasociados_datagridview_MouseClick(sender As Object, e As MouseEventArgs)
    End Sub

    Private Sub DatosNOasociados_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles DatosNOasociados_datagridview.MouseUp, Datosasociados_datagridview.MouseUp
        If e.Button = MouseButtons.Right Then
            MOUSEDERECHO(sender, e, sender)
        End If
    End Sub

    'public sub MOUSE DERECHO, sujeto a mejoras
    Private Sub MOUSEDERECHO(ByRef CONTROL As System.Object, ByRef MOUSE As System.Windows.Forms.MouseEventArgs, ByRef datagridgestor As Object)
        DATAGRIDSELECCIONADO = Nothing
        If MOUSE.Button <> Windows.Forms.MouseButtons.Right Then Return
        DATAGRIDSELECCIONADO = datagridgestor
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Copiar")
        item1.Tag = 0
        ' AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        AddHandler item1.Click, AddressOf MENUCONTEXTUAL
        Dim item2 = cms.Items.Add("Exportar toda la tablar a Excel")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf MENUCONTEXTUAL
        Dim item3 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja horizontal)")
        item3.Tag = 2
        AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        Dim item4 = cms.Items.Add("Guardar Tabla Reporte PDF (hoja vertical)")
        item4.Tag = 3
        AddHandler item4.Click, AddressOf MENUCONTEXTUAL
        'Dim item3 = cms.Items.Add("VERIFICAR ADICIONALES")
        'item3.Tag = 2
        'AddHandler item3.Click, AddressOf MENUCONTEXTUAL
        Dim item10 = cms.Items.Add("MODIFICAR CUIT")
        item10.Tag = 10
        AddHandler item10.Click, AddressOf MENUCONTEXTUAL
        '-- etc
        '..
        cms.Show(CONTROL, MOUSE.Location)
    End Sub

    Private Sub MENUCONTEXTUAL(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        Select Case selection
            Case Is = 0
                Clipboard.SetDataObject(DATAGRIDSELECCIONADO.GetClipboardContent())
                Dim objData As DataObject = DATAGRIDSELECCIONADO.GetClipboardContent
                If objData IsNot Nothing Then
                    Clipboard.SetDataObject(objData)
                End If
            Case Is = 1
                Exportaraexceltest(DATAGRIDSELECCIONADO)
                'Select Case datagridseleccionado.GetType.ToString.ToUpper
                '    Case Is = "SYSTEM.WINDOWS.FORMS.DATAGRIDVIEW"
                '        Exportaraexceltest(datagridseleccionado)
                '    Case Is = "COMPONENTFACTORY.KRYPTON.TOOLKIT.KRYPTONDATAGRIDVIEW"
                '        Exportaraexceltestkrypton(datagridseleccionado)
                '    Case Else
                '        MessageBox.Show(datagridseleccionado.GetType.ToString)
                'End Select
                'MessageBox.Show(datagridseleccionado.GetType.ToString)
                'Select Case
                '    Case Is = "Datagridview"
                '        Exportaraexceltest(datagridseleccionado)
                'End Select
            Case Is = 2
                'Reportesgenerales.ExportDataToPDFTable2(datagridseleccionado, "Reporte Rapido")
                'Reportesgenerales.PDFDatagridview(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(DATAGRIDSELECCIONADO, DataGridView), "Reporte Rapido", True, "LEGAL")
                'PDFDatagridview()
            Case Is = 3
                'Reportesgenerales.PDFDatagridviewvertical(CType(datagridseleccionado, DataGridView), "Reporte Rapido")
                PDFDatagridview(CType(DATAGRIDSELECCIONADO, DataGridView), "Reporte Rapido", False, "LEGAL")
            Case Is = 10
                Dim PROVE As New Proveedor
                Select Case DATAGRIDSELECCIONADO.SelectionMode
                    Case = DataGridViewSelectionMode.FullRowSelect
                        PROVE.CUIT = DATAGRIDSELECCIONADO.SelectedRows(0).Cells.Item("CUIT").Value.ToString
                        CUIT_agregarnuevo.CARGARCUIT_MODIFICAR(PROVE, Me)        '
                    Case = DataGridViewSelectionMode.CellSelect
                        PROVE.CUIT = DATAGRIDSELECCIONADO.Rows(DATAGRIDSELECCIONADO.SelectedCells(0).RowIndex).Cells.Item("CUIT").Value.ToString
                        CUIT_agregarnuevo.CARGARCUIT_MODIFICAR(PROVE, Me)
                End Select
                'CUIT_agregarnuevo.ShowDialog()
                'EXPERIMENTAL DEBE SER CORREGIDO
                'PDFPEDIDODEFONDO(CType(datagridseleccionado, DataGridView), "Reporte Rapido", False, "LEGAL")
        End Select
        '-- etc
    End Sub

    Private Sub Datosasociados_datagridview_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Datosasociados_datagridview.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Datosasociados_datagridview_KeyPress
    End Sub

    Private Sub Datosasociados_datagridview_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Datosasociados_datagridview.KeyPress
        'If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = ".") Then
        '    e.Handled = True
        'Else
        'End If
        If e.KeyChar = "." Then
            e.KeyChar = ","
        End If
    End Sub

End Class