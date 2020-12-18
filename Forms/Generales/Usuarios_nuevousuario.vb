Public Class Usuarios_nuevousuario

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Direccion_label.Text.Length = 4 Then
            nuevousuario()
            Select Case MsgBox("¿Desea Agregar otro usuario?", MsgBoxStyle.YesNoCancel, " ")
                Case MsgBoxResult.Yes
                Case Else
                    Me.Close()
            End Select
        Else
            MessageBox.Show("No ha seleccionado una Dirección para asignar")
        End If
    End Sub

    Private Sub nuevousuario()
        Dim Messagesdeerror As String = "No se puede proceder con el registro del nuevo usuario porque:"
        Dim errores As New List(Of String)
        If Apellido_textbox.Text = "" Then
            errores.Add(errores.Count + 1 & "-Debe completar el/los Apellido/s para poder continuar")
        End If
        If Nombres_textbox.Text = "" Then
            errores.Add(errores.Count + 1 & "-Debe completar el/los nombre/s para poder continuar")
        End If
        'If Direccion_combobox.SelectedIndex < 0 Then
        '    errores.Add(errores.Count + 1 & "-Debe seleccionar una Dirección a la cual pertenece el usuario")
        'End If
        If DNI_usuario_textbox.Text = "" Then
            errores.Add(errores.Count + 1 & "-Es INDISPENSABLE que coloque el DNI para poder registrarse")
        End If
        If Not (Password1_textbox.Text = Password2_textbox.Text) Then
            errores.Add(errores.Count + 1 & "-LAS CONTRASEÑAS INGRESADAS NO COINCIDEN")
        End If
        Select Case errores.Count = 0
            Case True
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Usuario", CType(DNI_usuario_textbox.Value, Double))
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Apellidos", Apellido_textbox.Text.ToUpper)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Nombres", Nombres_textbox.Text.ToUpper)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Direccion", Direccion_label.Text)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Departamento", "")
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Oficina", "")
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Funcion", "")
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Rol", " ")
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Pwd", ENCRIPTACION.Encriptar(Password1_textbox.Text))
                'SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Insert into Usuarios
                '(Usuario,Apellidos,Nombres,Direccion,Departamento,Oficina,Funcion,Rol,Pwd) values
                '(@Usuario,@Apellidos,@Nombres,@Direccion,@Departamento,@Oficina,@Funcion,@Rol,@Pwd) ON DUPLICATE KEY UPDATE PWD=@PWD"
                'Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, "OK_Button_Click")
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO USUARIOS (Usuario,Apellidos,Nombres,Direccion,Departamento,Oficina,Funcion,Rol,Pwd) VALUES (@Usuario,@Apellidos,@Nombres,@Direccion,@Departamento,@Oficina,@Funcion,@Rol,@Pwd)
ON DUPLICATE KEY UPDATE Usuario=@Usuario,Apellidos=@Apellidos,Nombres=@Nombres,Direccion=@Direccion,Departamento=@Departamento,Oficina=@Oficina,Funcion=@Funcion,Rol=@Rol,PWD=IF(ISNULL(Pwd),@Pwd,PWD)
"
                Dim filasafectadas As Integer = Inicio.InsertSQLFunction(Autorizaciones.userdatabase, "OK_Button_Click")
                Select Case filasafectadas > 0
                    Case True
                        MessageBox.Show("Agregado el usuario " & Apellido_textbox.Text.ToUpper & " " & Nombres_textbox.Text.ToUpper)
                        volvertodoacero()
                    Case False
                        MessageBox.Show("Error al agregar el usuario " & vbCrLf & Apellido_textbox.Text.ToUpper & " " & Nombres_textbox.Text.ToUpper & vbCrLf & " o ya se encuentra en la base de datos" & vbCrLf & "Si desea generar una nueva Contraseña consulte con " & vbCrLf &
                                        "-Dirección de Informática " & vbCrLf & "o Fortalecimiento Institucional ")
                End Select
            Case False
                For x = 0 To errores.Count - 1
                    Messagesdeerror = Messagesdeerror & vbCrLf & errores(x)
                Next
                MessageBox.Show(Messagesdeerror)
        End Select
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
    End Sub

    Private Sub Password1_textbox_TextChanged(sender As Object, e As EventArgs) Handles Password1_textbox.TextChanged, Password2_textbox.TextChanged
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    End Sub

    Private Sub Password2_textbox_TextChanged(sender As Object, e As EventArgs) Handles Password2_textbox.TextChanged
    End Sub

    Private Sub DNI_Usuario_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Apellido_textbox.KeyDown, Nombres_textbox.KeyDown, Password1_textbox.KeyDown, Password2_textbox.KeyDown
        Select Case e.KeyCode = Keys.Enter
            Case True
                e.Handled = True
                Inicio.SIGUIENTECONTROL(Me, sender, e)
            Case False
        End Select
    End Sub

    Private Sub Nuevousuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Nuevousuario_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        DNI_usuario_textbox.Select()
        Dim tablatemporalcombobox As New DataTable
        ' Autorizaciones.userdatabase = "CONTADURIA_USUARIOS"
        '  Autorizaciones.Organismotabla = "CONTADURIA_USUARIOS"
        Inicio.SQLPARAMETROS("CONTADURIA_USUARIOS", "Select N_direccion,Nombre_direccion from Direccion order by Nombre_direccion asc", tablatemporalcombobox, "Nuevousuario_Shown")
        ' Inicio.CARGACOMBOBOX(Direccion_combobox, tablatemporalcombobox, "N_direccion", "Nombre_direccion")
    End Sub

    Private Sub volvertodoacero()
        Apellido_textbox.Text = ""
        Nombres_textbox.Text = ""
        Password1_textbox.Text = ""
        Password2_textbox.Text = ""
    End Sub

    Private Sub AsignarDIRECCION_boton_Click(sender As Object, e As EventArgs) Handles AsignarDIRECCION_boton.Click
        Dim tablatemporal As New DataTable
        Inicio.SQLPARAMETROS("Contaduria_usuarios", "SELECT N_DIRECCION,NOMBRE_DIRECCION FROM contaduria_usuarios.direccion GROUP BY CUIT", tablatemporal, "AsignarDIRECCION_boton_Click")
        DialogDialogo_Datagridview.Carga_General(tablatemporal, "Seleccione la Dirección", "OK", "Cancelar")
        If (DialogDialogo_Datagridview.ShowDialog() = DialogResult.OK) Then
            Direccion_label.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(0).Value.ToString
            Nombre_Direccionlabel.Text = DialogDialogo_Datagridview.FilaSeleccionada.Cells.Item(1).Value.ToString
        Else
            Direccion_label.Text = ""
            Nombre_Direccionlabel.Text = ""
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Label_pedidofondo_MouseMove(sender As Object, e As MouseEventArgs) Handles Label_pedidofondo.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Private Sub DNI_usuario_textbox_ValueChanged(sender As Object, e As EventArgs) Handles DNI_usuario_textbox.ValueChanged
        If DNI_usuario_textbox.Text.Length > 0 Then
            If IsNumeric(DNI_usuario_textbox.Text) Then
                Select Case DNI_usuario_textbox.Text.Length > 6
                    Case True
                        Dim tablatemporal As New DataTable
                        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Usuario", CType(DNI_usuario_textbox.Text, Double))
                        Inicio.SQLPARAMETROS("Contaduria_usuarios", "Select * from usuarios where usuario=@usuario", tablatemporal, "DNI_Usuario_textbox.TextChanged")
                        Select Case tablatemporal.Rows.Count = 1
                            Case True
                                Apellido_textbox.Text = tablatemporal.Rows(0).Item("Apellidos").ToString
                                Nombres_textbox.Text = tablatemporal.Rows(0).Item("Nombres").ToString
                                tablatemporal.Dispose()
                            Case False
                                tablatemporal.Dispose()
                        End Select
                    Case False
                End Select
            Else
                volvertodoacero()
            End If
        End If
    End Sub

    Private Sub DNI_usuario_textbox_KeyDown_1(sender As Object, e As KeyEventArgs) Handles DNI_usuario_textbox.KeyDown
        Select Case e.KeyCode = Keys.Enter
            Case True
                e.Handled = True
                Inicio.SIGUIENTECONTROL(Me, sender, e)
            Case False
        End Select
    End Sub

    Private Sub DNI_usuario_textbox_Enter(sender As Object, e As EventArgs) Handles DNI_usuario_textbox.Enter
        DNI_usuario_textbox.Select(0, DNI_usuario_textbox.ToString.Length)
    End Sub

End Class