Public Class Datospersonales
    Dim Personal As New DataTable
    Dim Menu_autorizadodatatable As New DataTable
    Dim Menu_totales As New DataTable

    Private Sub Datospersonales_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Direccion", Autorizaciones.Organismo.ToString.Substring(0, 4))
        Select Case Autorizaciones.Usuario.Rows(0).Item("nivel").ToString
            Case Is = "0"
                Inicio.SQLPARAMETROS("Contaduria_usuarios", "Select Apellidos,Nombres,Usuario,Nivel from usuarios order by apellidos,nombres,usuario", Personal, "DATOSpersonales_load")
            Case Is = ""
            Case Else
                Inicio.SQLPARAMETROS("Contaduria_usuarios", "Select Apellidos,Nombres,Usuario,Nivel from usuarios where Direccion=@Direccion order by apellidos,nombres,usuario ", Personal, "DATOSpersonales_load")
        End Select
        Usuarios_servicioadministrativo.DataSource = Personal
        Usuarios_servicioadministrativo.CurrentCell = Nothing
    End Sub

    Private Sub Usuarios_servicioadministrativo_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Usuarios_servicioadministrativo.CellEnter
        Select Case Usuarios_servicioadministrativo.SelectedRows.Count = 1
            Case True
                Flicker_Split_panel1.Visible = True
                refresh_elementos()
            Case False
                Flicker_Split_panel1.Visible = False
                'refresh_elementos()
        End Select
    End Sub

    Private Sub refresh_elementos()
        Menusasociados.DataSource = Nothing
        MenuELEMENTOS.DataSource = Nothing
        Menu_autorizadodatatable.Clear()
        Menu_totales.Clear()
        Busqueda_sinasociar.Text = ""
        Select Case Usuarios_servicioadministrativo.SelectedRows.Count = 1
            Case True
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Usuario", Usuarios_servicioadministrativo.SelectedRows(0).Cells.Item("Usuario").Value)
                Inicio.SQLPARAMETROS("Contaduria_usuarios", "Select Nombre,Autorizado_por,fecha,Nombre_elemento as 'Menu' from (Select Menu,Autorizado_por,fecha from autorizaciones_menu where Usuario=@Usuario)A
LEFT JOIN (Select Menu as 'Nombre',Nombre_elemento from elemento_menu)B ON A.MENU=B.Nombre_elemento", Menu_autorizadodatatable, "Usuarios_servicioadministrativo_CellEnter")
                Menusasociados.DataSource = Menu_autorizadodatatable
                Menusasociados.Columns("MENU").Visible = False
                Menusasociados.CurrentCell = Nothing
                SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Usuario", Usuarios_servicioadministrativo.SelectedRows(0).Cells.Item("Usuario").Value)
                Inicio.SQLPARAMETROS("Contaduria_usuarios", "Select Menu as 'Nombre',Nombre_elemento as 'Menu' from elemento_menu WHERE Nombre_elemento NOT IN (Select MENU from autorizaciones_menu where Usuario=@Usuario) ", Menu_totales, "Usuarios_servicioadministrativo_CellEnter")
                MenuELEMENTOS.DataSource = Menu_totales
                MenuELEMENTOS.Columns("MENU").Visible = False
                MenuELEMENTOS.CurrentCell = Nothing
            Case False
        End Select
    End Sub

    Private Sub Datospersonales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Busqueda_textbox_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_textbox.TextChanged
        Buscar_datagrid_TIMER(sender, Personal, Usuarios_servicioadministrativo)
    End Sub

    Private Sub Busqueda_sinasociar_TextChanged(sender As Object, e As EventArgs) Handles Busqueda_sinasociar.TextChanged
        Buscar_datagrid_TIMER(sender, Menu_totales, MenuELEMENTOS)
    End Sub

    Private Sub BrindarAutorizacion_button_Click(sender As Object, e As EventArgs) Handles BrindarAutorizacion_button.Click
        autorizar_tipo(True, MenuELEMENTOS)
    End Sub

    Private Sub QuitarAutorizacion_button_Click(sender As Object, e As EventArgs) Handles QuitarAutorizacion_button.Click
        autorizar_tipo(False, Menusasociados)
    End Sub

    Private Sub autorizar_tipo(ByVal Agregar As Boolean, ByVal sender As DataGridView)
        For X = 0 To sender.SelectedRows.Count - 1
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Usuarios", Usuarios_servicioadministrativo.SelectedRows(0).Cells.Item("Usuario").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Menu", sender.SelectedRows(X).Cells.Item("MENU").Value)
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@autorizado_por", Autorizaciones.Usuario.Rows(0).Item("Apellidos").ToString & "  " & Autorizaciones.Usuario.Rows(0).Item("nombres").ToString)
            Select Case Agregar
                Case Is = True
                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO autorizaciones_menu (usuario,menu,Autorizado_por) " &
                    " VALUES (@usuarios,@menu,@Autorizado_por) " & " ON DUPLICATE KEY UPDATE usuario=@usuarios,menu=@menu,Autorizado_por=@Autorizado_por"
                    Inicio.INSERTSQLPARAMETROS("Contaduria_usuarios", System.Reflection.MethodBase.GetCurrentMethod.Name)
                Case Is = False
                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE FROM  autorizaciones_menu  where usuario=@Usuarios AND menu=@Menu"
                    Inicio.INSERTSQLPARAMETROS("Contaduria_usuarios", System.Reflection.MethodBase.GetCurrentMethod.Name)
                Case Else
                    'no debería ser posible
            End Select
        Next
        refresh_elementos()
    End Sub

End Class