Public Module Informatica_Backup
    Dim serverorigen As New ServerMysql
    Dim serverdestino As New ServerMysql

    Sub Main()
        Dim today As String = Date.Now.Year & "-" & Date.Now.Month & "-" & Date.Now.Day
        Dim PATHMYSQL As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.7", "Location", 0)
        Seleccionar()
        Dim Directory As String = "C:\CONTADURIA\salud_publica_backup"
        'comprobamos la existencia del Directory y si no lo crea
        If Not System.IO.Directory.Exists(Directory) Then
            System.IO.Directory.CreateDirectory(Directory)
        End If
        '   Dim PATHMYSQL As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.7", "Location", 0)
        If PATHMYSQL = Nothing Then
            PATHMYSQL = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\MySQL AB\MYSQL Server 5.7", "Location", 0)
            If PATHMYSQL = "0" Then
                PATHMYSQL = "C:\Program Files\MySQL\MySQL Server 5.7"
            End If
        End If
        IMPORT(PATHMYSQL)
        EXPORT(PATHMYSQL)

    End Sub

    Private Sub IMPORT(ByVal PATHMYSQL As String)
        Dim FileToDelete As String
        Dim Directory As String = "C:\CONTADURIA\ARCHIVOS_SALUD_PUBLICA\backup_BD\" & Autorizaciones.Organismo.ToString.Substring(0, 4)
        FileToDelete = Directory & "\DB." & Format(Today, "yyyy-MM-dd") & ".sql"
        'Si existe el archivo de hoy lo borra
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
        'Comenzamos con el mysqldump
        Dim pProperties As New ProcessStartInfo
        With pProperties
            .FileName = PATHMYSQL & "bin\mysqldump.exe"
            .WorkingDirectory = PATHMYSQL & "bin"
            .Arguments = " --databases " & serverorigen.Database.ToLower & " --result-file=" & Directory & "\DB." & Format(Today, "yyyy-MM-dd") & ".sql --user=" & serverorigen.Usuario & " --password=" & serverorigen.Pwd & " --host=" & serverorigen.Server & " --port=" & serverorigen.Port & " "
            .UseShellExecute = False
            .RedirectStandardOutput = False
        End With
        Dim p As New Process With {
            .StartInfo = pProperties
        }
        Try
            'My.Computer.Clipboard.SetText(p.StartInfo.FileName & p.StartInfo.Arguments)
            p.Start()
            p.WaitForExit()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ''
    End Sub

    Private Sub EXPORT(ByVal PATHMYSQL As String)
        'copiar en base de datos
        Dim Directory As String = "C:\CONTADURIA\ARCHIVOS_SALUD_PUBLICA\backup_BD\" & Autorizaciones.Organismo.ToString.Substring(0, 4)
        Dim pProperties_destino As New ProcessStartInfo
        With pProperties_destino
            .FileName = PATHMYSQL & "bin\mysql.exe"
            .WorkingDirectory = PATHMYSQL & "bin"
            .Arguments = " -u " & serverdestino.Usuario & " -p" & serverdestino.Pwd & " --port " & serverdestino.Port & " -h " & serverdestino.Server & " < " & Directory & "\DB." & Format(Today, "yyyy-MM-dd") & ".sql"
            .UseShellExecute = False
            .RedirectStandardOutput = False
        End With
        Using p_destino As New Process
            p_destino.StartInfo = pProperties_destino
            p_destino.Start()
            p_destino.WaitForExit()
        End Using
        IO.File.Delete(Directory & "\databases." & Format(Today, "yyyy-mmm-dd") & ".sql")
    End Sub

    Private Sub Seleccionar()
        Dim Conexion_datatable As New DataTable
        With Conexion_datatable
            .Columns.Add("N")
            .Columns.Add("Conexion")
            .Columns.Add("Descripcion")
            'Carga de tipos de conexión
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Servidores Roberto"
                .Item("Descripcion") = "Servidores locales de prueba"
            End With
            '-----------------------------------------------------------------
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Notebook Galia"
                .Item("Descripcion") = "Servidores Mysql en Notebook Galia"
            End With
            '-----------------------------------------------------------------
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Servidores UFI"
                .Item("Descripcion") = "Conexion a los servidores Galia/Celano dentro de Contaduría"
            End With
            '-----------------------------------------------------------------
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Servidores Salud publica"
                .Item("Descripcion") = "Servidores Servicio Administrativo de Salud Publica"
            End With
            '-----------------------------------------------------------------
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Servidores Desarrollo Social"
                .Item("Descripcion") = "Servidores Servicio Administrativo de Desarrollo Social"
            End With
            '-----------------------------------------------------------------
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Servidores Gobierno"
                .Item("Descripcion") = "Servidores Servicio Administrativo de Gobierno"
            End With
            '-----------------------------------------------------------------
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Servidores Acción Cooperativa"
                .Item("Descripcion") = "Servidores Servicio Administrativo de Accion Cooperativa"
            End With
            '-----------------------------------------------------------------
            .Rows.Add()
            With .Rows(.Rows.Count - 1)
                .Item("N") = Conexion_datatable.Rows.Count
                .Item("Conexion") = "Servidor Externo"
                .Item("Descripcion") = "Servidor Externo (Nube)"
            End With
        End With

        DialogDialogo_Datagridview.Carga_General(Conexion_datatable, "ORIGEN", "Seleccionar", "cancelar")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            serverorigen = HarcodedServers.Servidores(DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows(0).Cells.Item("Conexion").Value.ToString)
            DialogDialogo_Datagridview.Carga_General(Conexion_datatable, "DESTINO", "Seleccionar", "cancelar")
            If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
                serverdestino = HarcodedServers.Servidores(DialogDialogo_Datagridview.Datosdialogo_datagridview.SelectedRows(0).Cells.Item("Conexion").Value.ToString)
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub


End Module