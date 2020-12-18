Imports System.Globalization
Imports System.IO
Imports System.Threading

Public Class INGRESO
    Dim culture As CultureInfo

    ' TODO: Insert code to perform custom authentication using the provided username and password
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).
    ' The custom principal can then be attached to the current thread's principal as follows:
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication.
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Private Sub versionar()
        Try
            Dim ds As DataSet = New DataSet()
            ds.ReadXml(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SICyF.application"))
            Dim dt As DataTable = New DataTable()
            If ds.Tables.Count > 1 Then
                dt = ds.Tables(1)
                Versionlabel.Text = dt.Rows(0).Item("version").ToString()
            End If
        Catch ex As Exception
            If My.Application.IsNetworkDeployed Then
                Versionlabel.Text = My.Application.Deployment.CurrentVersion.ToString()
            End If
        End Try
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        conexion()
    End Sub

    Private Async Sub conexion()
        If (Not (UsernameTextBox.Text = "")) And (IsNumeric(UsernameTextBox.Text) And (Not (PasswordTextBox.Text = ""))) Then
            Me.Enabled = False
            Inicio.autorizaciones_control(CType(UsernameTextBox.Text, Double), PasswordTextBox.Text)
            If Servidor1_label.BackColor = Color.FromArgb(172, 200, 29) Then
                Servidor1_label.Text = "CONECTANDO"
                Conectando_panel.BringToFront()
                Conectando_panel.Visible = True
                'OK.BackColor = Color.Blue
                'OK.ForeColor = Color.White
                ''Servidor1_label.BackColor = Color.LightCyan
                ''Servidor2_label.BackColor = Color.LightGray
                'Panel_Login.BackColor = Color.LightGray
                'Labeltitulo.BackColor = Color.LightGray
            Else
                Servidor2_label.Text = "CONECTANDO"
                'OK.BackColor = Color.Blue
                'OK.ForeColor = Color.White
                ''Servidor1_label.BackColor = Color.LightGray
                ''Servidor2_label.BackColor = Color.LightCyan
                'Panel_Login.BackColor = Color.LightGray
                'Labeltitulo.BackColor = Color.LightGray
                Conectando_panel.BringToFront()
                Conectando_panel.Visible = True
            End If
            Select Case Autorizaciones.Usuario.Rows.Count > 0
                Case True
                    Await Inicio.Conexion_verificar(Inicio.Servidor1toolstrip_label, Inicio.Servidor2toolstrip_label)
                    If Servidor1_label.BackColor = Color.FromArgb(172, 200, 29) Or Servidor2_label.BackColor = Color.FromArgb(172, 200, 29) Then
                        Autorizaciones.Organismo = Autorizaciones.Usuario.Rows(0).Item("N_DIRECCION").ToString
                        Inicio.Usuariotoolstrip_label.Text = Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString
                        Inicio.Direcciontoolstrip_label.Text = Nombrecompletodelservicio
                        Autorizaciones.Organismotabla = Autorizaciones.Usuario.Rows(0).Item("Nombre_database").ToString
                        Select Case Autorizaciones.Usuario.Rows(0).Item("nivel")
                            Case Is > -1
                                Informatica_Servicioadministrativo.Cargadeopciones_ServAdm("BASE DE DATOS")
                                Informatica_Servicioadministrativo.BringToFront()
                            Case Else
                                Inicio.Show()
                        End Select
                    Else
                        MessageBox.Show("Actualmente no se puede conectar con la base de datos, por favor verifique su conexión")
                        Me.Enabled = True
                        Refresh.Visible = True
                    End If
                Case False
                    If Servidor1_label.BackColor = Color.FromArgb(172, 200, 29) Then
                        Servidor1_label.Text = "Online"
                    End If
                    If Servidor2_label.BackColor = Color.FromArgb(172, 200, 29) Then
                        Servidor2_label.Text = "Online"
                    End If
                    MessageBox.Show("El nombre de usuario y contraseña no coinciden, por favor verifique" & vbCrLf & "En caso de duda consulte a la Dirección de Informática")
                    Conectando_panel.SendToBack()
                    Conectando_panel.Visible = False
                    Me.Enabled = True
            End Select
        Else
            MessageBox.Show("Debe ingresar su DNI y contraseña asignada para tener acceso al sistema")
            Me.Enabled = True
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub UsernameTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles UsernameTextBox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub PasswordTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PasswordTextBox.KeyDown
        If UsernameTextBox.TextLength > 0 And PasswordTextBox.TextLength > 0 Then
            Select Case e.KeyCode = Keys.Enter
                Case True
                    e.SuppressKeyPress = True
                    e.Handled = True
                    OK.PerformClick()
                Case False
            End Select
        Else
            Inicio.SIGUIENTECONTROL(Me, sender, e)
        End If
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case My.Computer.Name.ToUpper
            Case "MERONETBOOK"
                Me.Size = New Size(488, 307)
                Mododepuracion.Visible = True
            Case "MEROSUPERPC"
                Me.Size = New Size(488, 307)
                Mododepuracion.Visible = True
        End Select
        culture = CultureInfo.CreateSpecificCulture("es-AR")
        CultureInfo.DefaultThreadCurrentCulture = culture
        Me.culture = culture
        Thread.CurrentThread.CurrentCulture = culture
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        TOOLTIPSlogin(UsernameTextBox, "Ingrese su USUARIO, que consiste en su Nº de Documento")
        TOOLTIPSlogin(PasswordTextBox, "Ingrese la Contraseña que ha designado para su usuario")
        TOOLTIPSlogin(Servidor1_label, "Estado actual del Servidor 1")
        TOOLTIPSlogin(Servidor2_label, "Estado actual del Servidor 2")
        'If (ApplicationDeployment.IsNetworkDeployed) Then
        versionar()
        Panel_CENTRAL.Enabled = False
        Me.CheckForIllegalCrossThreadCalls = False
    End Sub

    Public Sub TOOLTIPSlogin(ByVal sender As Object, ByVal textotool As String)
        Try
            Select Case sender.GetType
                Case Is = GetType(Button)
                    Me.Messagetooltip.Show(textotool, sender)
                Case Is = GetType(ToolStrip)
                    Me.Messagetooltip.Show(textotool, sender)
                Case Is = GetType(TextBox)
                    ' Me.MessageTooltip.Show(textotool, sender)
                    Me.Messagetooltip.SetToolTip(sender, textotool)
                Case Else
                    Me.Messagetooltip.SetToolTip(sender, textotool)
                    ' Me.Messagetooltip.SetToolTip(sender, sender.tooltiptext)
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'ERRORES(1, ex.Message & vbCrLf & "  " & sender.GetType.ToString, Reflection.MethodBase.GetCurrentMethod.Name, sender.GetType.ToString)
        End Try
    End Sub

    Private Async Sub rapidconnection()
        Await Inicio.Conexion_verificar(Servidor1_label, Servidor2_label)
    End Sub

    Private Sub LoginForm1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Threading.Thread.Sleep(500)
        Dim Computadoras(10) As String
        'NOTEBOOK ROBERTO ROMERO DESARROLLO
        Computadoras(0) = "MERONETBOOK"
        'PC DE ESCRITORIO ROBERTO ROMERO DESARROLLO
        Computadoras(1) = "MEROSUPERPC"
        'NOTEBOOK GALIA LEVITT
        Computadoras(2) = "DESKTOP-EP56LKM"
        'PC ESCRITORIO GALIA LEVITT
        Computadoras(3) = "GALIA"
        'PC ESCRITORIO GABRIELA CELANO
        Computadoras(4) = "GABY"
        'NOTEBOOK SILVANA ALVAREZ
        Computadoras(5) = "LAPTOP-N9SA45M8"
        'VACIO
        Computadoras(6) = "SEBASTIAN-PC"
        'PC ESCRITORIO PAOLA YACHUK
        Computadoras(7) = "PAOLAYACHUK"
        'VACIO
        Computadoras(8) = "DARIO"
        'VACIO
        Computadoras(9) = "GABRIELA"
        'VACIO
        Computadoras(10) = "NOTEBOOOOOK"
        If Computadoras.Contains(My.Computer.Name.ToUpper, StringComparer.CurrentCultureIgnoreCase) Then
            Informatica_Servicioadministrativo.Cargadeopciones_ServAdm("CONEXION")
            Informatica_Servicioadministrativo.BringToFront()
        Else

            SERVIDORMYSQL.ServermysqltoModulo(HarcodedServers.Servidores("Servidores Salud publica"))
        End If
        Workerinicial.RunWorkerAsync()
    End Sub

    Private Sub Nuevousuario_boton_Click(sender As Object, e As EventArgs) Handles Nuevousuario_boton.Click
        Usuarios_nuevousuario.ShowDialog()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel_CENTRAL.Paint
    End Sub

    Private Sub Workerinicial_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Workerinicial.DoWork
        'se implementa el worker asincronico debido al problema generado por los threads en ejecución y el freeze de 2 segundos a la interfase al inicio de la aplicación.
        rapidconnection()
    End Sub

    Private Sub Workerinicial_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Workerinicial.RunWorkerCompleted
        If Servidor1_label.BackColor = Color.FromArgb(172, 200, 29) Or Servidor2_label.BackColor = Color.FromArgb(172, 200, 29) Then
            Useridpic.Visible = True
            Pwdidpic.Visible = True
            UsernameTextBox.Visible = True
            PasswordTextBox.Visible = True
            OK.Visible = True
            Cancel.Visible = True
            Nuevousuario_boton.Visible = True
            Panel_CENTRAL.Enabled = True
        Else
            MessageBox.Show("Actualmente no se puede conectar con ninguno de los servidores asignados")
            Panel_CENTRAL.Enabled = True
            Cancel.Visible = True
            Refresh.Visible = True
        End If
        UsernameTextBox.Select()
        Select Case My.Computer.Name.ToUpper
            Case "MERONETBOOK"
                UsernameTextBox.Text = "28403735"
                PasswordTextBox.Text = "mero"
              '  OK.PerformClick()
            Case "MEROSUPERPC"
                UsernameTextBox.Text = "28403735"
                PasswordTextBox.Text = "mero"
                '  OK.PerformClick()
            Case "DESKTOP-EP56LKM"
                UsernameTextBox.Text = "17980049"
                PasswordTextBox.Text = "123"
                '  OK.PerformClick()
            Case "GALIA"
                UsernameTextBox.Text = "17980049"
                PasswordTextBox.Text = "123"
                '  OK.PerformClick()
            Case Else
        End Select
    End Sub

    Private Sub Mododepuracion_CheckedChanged(sender As Object, e As EventArgs) Handles Mododepuracion.CheckedChanged
        If Mododepuracion.Checked Then
            Estadodedepuracion = True
        Else
            Estadodedepuracion = False
        End If
    End Sub

    Private Sub Labeltitulo_Click(sender As Object, e As EventArgs) Handles Labeltitulo.Click
    End Sub

    Private Sub Labeltitulo_MouseMove(sender As Object, e As MouseEventArgs) Handles Labeltitulo.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    End Sub

    Private Sub INGRESO_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        Refresh.Visible = False
        versionar()
        Workerinicial.RunWorkerAsync()
    End Sub

    'Private Sub UsernameTextBox_Enter(sender As Object, e As EventArgs) Handles UsernameTextBox.Enter
    '    Select Case UsernameTextBox.Text
    '        Case = "Ingrese su Usuario"
    '            UsernameTextBox.ForeColor = Color.Black
    '            UsernameTextBox.Text = ""
    '        Case Else
    '            If UsernameTextBox.Text = "" Then
    '                UsernameTextBox.ForeColor = Color.LightGray
    '                UsernameTextBox.Text = "Ingrese su Usuario"
    '            End If
    '    End Select
    'End Sub
    'Private Sub PasswordTextBox_Enter(sender As Object, e As EventArgs) Handles PasswordTextBox.Enter
    '    Select Case PasswordTextBox.Text
    '        Case = "Ingrese su contraseña"
    '            PasswordTextBox.ForeColor = Color.Black
    '            PasswordTextBox.Text = ""
    '            PasswordTextBox.PasswordChar = CType("*", Char)
    '            PasswordTextBox.UseSystemPasswordChar = True
    '        Case Else
    '            If PasswordTextBox.Text = "" Then
    '                PasswordTextBox.ForeColor = Color.LightGray
    '                PasswordTextBox.Text = "Ingrese su contraseña"
    '                PasswordTextBox.UseSystemPasswordChar = False
    '            End If
    '    End Select
    'End Sub
    'Private Function IsPortOpen(ByVal Host As String, ByVal PortNumber As Integer) As Boolean
    '    Dim Client As TcpClient = Nothing
    '    Try
    '        Client = New TcpClient(Host, PortNumber) With {
    '            .ReceiveTimeout = 100,
    '            .SendTimeout = 100
    '        }
    '        Return True
    '    Catch ex As SocketException
    '        Return False
    '    Finally
    '        If Not Client Is Nothing Then
    '            Client.Close()
    '        End If
    '    End Try
    'End Function
End Class