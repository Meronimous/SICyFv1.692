Public Class Informatica_Servicioadministrativo
    Dim MODO As String = ""

    Private Sub Selecciondeservicioadministrativo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Serv_Adm_datagridview.CurrentCell = Nothing
    End Sub

    Public Sub Cargadeopciones_ServAdm(ByVal Opciones As String)
        Select Case Opciones.ToUpper
            Case Is = "BASE DE DATOS"
                MODO = Opciones.ToUpper
                Panel_superior.BackColor = Color.SteelBlue
                Label_detalle.Text = "Ejercicio Financiero"
                OK_Button.BackColor = Color.SteelBlue
                OK_Button.Text = "Seleccionar Ejercicio Financiero"
                Serv_Adm_datagridview.BackgroundColor = Color.SteelBlue
            Case Is = "CONEXION"
                'CONEXION()
                MODO = Opciones.ToUpper
                Panel_superior.BackColor = Color.SaddleBrown
                Label_detalle.Text = "FORMA DE CONEXIÓN"
                OK_Button.BackColor = Color.SaddleBrown
                OK_Button.Text = "Seleccionar Conexión"
        End Select
        SeleccionBasededatos()
        Serv_Adm_datagridview.CurrentCell = Nothing
    End Sub

    Private Sub SeleccionBasededatos()
        Select Case MODO
            Case Is = "BASE DE DATOS"
                If Autorizaciones.Usuario.Rows.Count > 0 Then
                    'SELECCION DE BASE DE DATOS Y EJERCICIO FINANCIERO TOOD EN UNO
                    Dim Tablabase As New DataTable
                    Inicio.SQLPARAMETROS("", "Select Nombre_direccion as 'Servicio Administrativo',year as 'Ejercicio',table_schema as 'Nombre Base de datos',N_direccion,tables as Archivos,CUIT,`SELLO ABREVIADO`,DOMICILIO from
(Select
  table_schema,
  sum(table_type = 'base table') tables,
  sum(table_type = 'view') views,
  sum(table_type = 'system view') system_views
from information_schema.tables where table_schema like 'serv_adm%'
group by table_schema)A
inner JOIN
(select * from contaduria_usuarios.direccion)B
on A.table_schema=B.nombre_database
order by Nombre_direccion,ejercicio desc", Tablabase, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    Serv_Adm_datagridview.DataSource = Tablabase
                    Select Case Autorizaciones.Usuario.Rows(0).Item("nivel") = 0
                        Case True
                            Serv_Adm_datagridview.Columns(0).Visible = True
                            Serv_Adm_datagridview.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            Serv_Adm_datagridview.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        Case Else
                            Serv_Adm_datagridview.Columns(0).Visible = False
                            Serv_Adm_datagridview.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    End Select
                    Serv_Adm_datagridview.Columns(1).Visible = True
                    Serv_Adm_datagridview.Columns(1).DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    Serv_Adm_datagridview.Columns(2).Visible = False
                    Serv_Adm_datagridview.Columns(3).Visible = False
                    Serv_Adm_datagridview.Columns(4).Visible = False
                    Serv_Adm_datagridview.Columns(5).Visible = False
                    Serv_Adm_datagridview.Columns(6).Visible = False
                    Serv_Adm_datagridview.Columns(7).Visible = False
                    If Inicio.Visible = True Then
                        Me.Hide()
                    End If
                End If
            Case Is = "CONEXION"
                Dim Conexion_datatable As New DataTable
                Conexion_datatable.Columns.Add("N")
                Conexion_datatable.Columns.Add("Conexion")
                Conexion_datatable.Columns.Add("Descripcion")
                'Carga de tipos de conexión
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Servidores Roberto"
                    .Item("Descripcion") = "Servidores locales de prueba"
                End With
                '-----------------------------------------------------------------
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Notebook Galia"
                    .Item("Descripcion") = "Servidores Mysql en Notebook Galia"
                End With
                '-----------------------------------------------------------------
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Servidores UFI"
                    .Item("Descripcion") = "Conexion a los servidores Galia/Celano dentro de Contaduría"
                End With
                '-----------------------------------------------------------------
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Servidores Salud publica"
                    .Item("Descripcion") = "Servidores Servicio Administrativo de Salud Publica"
                End With
                '-----------------------------------------------------------------
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Servidores Desarrollo Social"
                    .Item("Descripcion") = "Servidores Servicio Administrativo de Desarrollo Social"
                End With
                '-----------------------------------------------------------------
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Tunel Salud Pública"
                    .Item("Descripcion") = "Tunel TCP consultar con Roberto Romero"
                End With
                '-----------------------------------------------------------------
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Servidores Acción Cooperativa"
                    .Item("Descripcion") = "Servidores Servicio Administrativo de Accion Cooperativa"
                End With
                '-----------------------------------------------------------------
                Conexion_datatable.Rows.Add()
                With Conexion_datatable.Rows(Conexion_datatable.Rows.Count - 1)
                    .Item("N") = Conexion_datatable.Rows.Count
                    .Item("Conexion") = "Servidor Externo"
                    .Item("Descripcion") = "Servidor Externo (Nube)"
                End With
                '-----------------------------------------------------------------
                Serv_Adm_datagridview.DataSource = Conexion_datatable
                Serv_Adm_datagridview.CurrentCell = Nothing
                Serv_Adm_datagridview.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Serv_Adm_datagridview.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Serv_Adm_datagridview.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Select
        '    userdatabase = "Contaduria_usuarios"
        If Me.Visible = True Then
            Serv_Adm_datagridview.CurrentCell = Nothing
        Else
            Me.ShowDialog()
            Me.BringToFront()
            Serv_Adm_datagridview.CurrentCell = Nothing
        End If
    End Sub

    Private Sub seleccion()
        Select Case MODO
            Case Is = "BASE DE DATOS"
                If Serv_Adm_datagridview.Rows.Count > 0 Then
                    If Serv_Adm_datagridview.SelectedRows.Count = 1 Then
                        Autorizaciones.Organismo = Serv_Adm_datagridview.SelectedRows(0).Cells.Item("N_DIRECCION").Value.ToString
                        Autorizaciones.Year = Serv_Adm_datagridview.SelectedRows(0).Cells.Item("EJERCICIO").Value
                        Inicio.Label_EJERCICIOFINANCIERO.Text = " Ejercicio " & Serv_Adm_datagridview.SelectedRows(0).Cells.Item("EJERCICIO").Value.ToString
                        Inicio.Usuariotoolstrip_label.Text = Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString
                        Nombrecompletodelservicio = Serv_Adm_datagridview.SelectedRows(0).Cells.Item("Servicio Administrativo").Value.ToString
                        CUIT_servicioadministrativo = Autorizaciones.Usuario.Rows(0).Item("CUIT").ToString
                        DOMICILIOdelservicioadm = Autorizaciones.Usuario.Rows(0).Item("DOMICILIO").ToString
                        Inicio.Direcciontoolstrip_label.Text = Nombrecompletodelservicio
                        Autorizaciones.Organismotabla = Serv_Adm_datagridview.SelectedRows(0).Cells.Item("Nombre Base de Datos").Value.ToString
                        Autorizaciones.Nombreabreviadodelservicio = Serv_Adm_datagridview.SelectedRows(0).Cells.Item("SELLO ABREVIADO").Value.ToString
                        Autorizaciones.CUIT_servicioadministrativo = Serv_Adm_datagridview.SelectedRows(0).Cells.Item("CUIT").Value.ToString
                    End If
                End If
            Case Is = "CONEXION"
                If Serv_Adm_datagridview.SelectedRows.Count > 0 Then
                    Dim ServerActivo1 As ServerMysql = HarcodedServers.Servidores(Serv_Adm_datagridview.SelectedRows(0).Cells.Item("Conexion").Value.ToString)


                    SERVIDORMYSQL.ServermysqltoModulo(HarcodedServers.Servidores(Serv_Adm_datagridview.SelectedRows(0).Cells.Item("Conexion").Value.ToString))

                    'SERVIDORMYSQL.ServerActivo = ServerActivo1.Server
                    'SERVIDORMYSQL.USUARIOactivo = ServerActivo1.Usuario
                    'SERVIDORMYSQL.PWDactivo = ServerActivo1.Pwd
                    SERVIDORMYSQL.DATABASE = "Contaduria_usuarios"
                    'SERVIDORMYSQL.PORT = ServerActivo1.Port


                    'SERVIDORMYSQL.ServermysqltoModulo(HarcodedServers.Servidores(Serv_Adm_datagridview.SelectedRows(0).Cells.Item("Conexion").Value.ToString))

                End If
        End Select
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        If Serv_Adm_datagridview.SelectedRows.Count > 0 Then
            Select Case MODO
                Case Is = "CONEXION"
                    seleccion()
                    INGRESO.Show()
                Case Else
                    'MessageBox.Show("Por favor seleccione una opción")
                    'VERIFICAR CAMBIO DE EJERCICIO FINANCIERO Y SI NO COINCIDE CERRAR TODAS LAS VENTANAS Y RECONECTAR-
                    If Inicio.Visible = True Then
                        If (Autorizaciones.Year > 0) And (Autorizaciones.Year <> Serv_Adm_datagridview.SelectedRows(0).Cells.Item("EJERCICIO").Value) Then
                            For Each form In Inicio.MdiChildren
                                If Not form.Name.ToUpper = "PRESENTACION" Then
                                    form.Close()
                                Else
                                    form.WindowState = FormWindowState.Maximized
                                End If
                            Next
                        Else
                            'en caso de que el año sea igual
                        End If
                        Autorizaciones.Year = Serv_Adm_datagridview.SelectedRows(0).Cells.Item("EJERCICIO").Value
                    Else
                        Inicio.Show()
                    End If
                    seleccion()
                    Inicio.Recargardatosprincipales()
            End Select
            Me.Hide()
        Else
            Serv_Adm_datagridview.CurrentCell = Nothing
            MessageBox.Show("Por favor seleccione una opción")
        End If
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Select Case MODO
            Case Is = "CONEXION"
                Me.Hide()
            Case Else
                INGRESO.Close()
                Me.Hide()
        End Select
    End Sub

    Private Sub Serv_Adm_datagridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Serv_Adm_datagridview.CellDoubleClick
        OK_Button.PerformClick()
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel_superior.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Serv_Adm_datagridview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Serv_Adm_datagridview.CellContentClick
    End Sub

    Private Sub Serv_Adm_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Serv_Adm_datagridview.CellEnter
    End Sub

End Class