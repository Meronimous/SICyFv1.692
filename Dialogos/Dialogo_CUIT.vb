Public Class Dialogo_CUIT
    Dim Datosdebeneficiario As New DataTable
    Dim CUIT_textual As Object
    Dim Clave_expediente As String = ""

    Private Sub Dialogo_Beneficiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Public Sub Cargadetextbox(ByVal textboxCUIT As Object)
        CUIT_textual = textboxCUIT
        '   MessageBox.Show(textboxCUIT.GetType().Name.ToString)
    End Sub

    Public Sub Cargadecuits(Optional ByVal Clave_expediente1 As String = Nothing)
        'Datosdebeneficiario.Clear()
        Datosbeneficiarios_datagridview.DataSource = Nothing
        Clave_expediente = Clave_expediente1
        Mostrardialogo(Me)
        'Me.ShowDialog()
    End Sub

    Private Sub Dialogo_Beneficiario_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Refreshproveedores(Busqueda.Text)
    End Sub

    Private Sub Refreshproveedores(ByVal terminodebusqueda As String)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT_textual)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", Clave_expediente)
        'Dim busquedasql As String = ""
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", terminodebusqueda)
        'SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@busquedalike", "%" & terminodebusqueda & "%")
        busquedasql = " Select Proveedor,CUIT,Rubro,DOMICILIOREAL from proveedores  WHERE
case when @clave_expediente='' then
CUIT IN ((SELECT CUIT FROM proveedores WHERE CUIT =@CUIT)) else
CUIT IN ((SELECT CUIT FROM CUIT_EXPEDIENTE WHERE CLAVE_EXPEDIENTE =@clave_expediente))
end;
"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, busquedasql, Datosdebeneficiario, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If Datosdebeneficiario.Rows.Count < 1 Then
            MsgBox("El expediente no tiene actualmente ningún CUIT asociado, a continuación se provee la lista completa")
            Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Proveedor,CUIT,Rubro,DOMICILIOREAL from proveedores  order by proveedor asc", Datosdebeneficiario, System.Reflection.MethodBase.GetCurrentMethod.Name)
        End If
        Datosbeneficiarios_datagridview.DataSource = Datosdebeneficiario
    End Sub

    Private Sub Boton_busqueda_Click(sender As Object, e As EventArgs) Handles Boton_busqueda.Click
        Refreshproveedores(Busqueda.Text)
    End Sub

    Private Sub Datosexpedientes_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datosbeneficiarios_datagridview.CellEnter
        Select Case Datosbeneficiarios_datagridview.SelectedRows.Count > 0
            Case True
                CUITadevolver_textbox.Text = Datosbeneficiarios_datagridview.SelectedRows(0).Cells.Item("CUIT").Value.ToString()
            Case False
                CUITadevolver_textbox.Text = ""
        End Select
    End Sub

    Private Sub BotondevolverCuit_Click(sender As Object, e As EventArgs) Handles BotondevolverCuit.Click
        '   Movimientos.DNICUIT_textbox.Text = CUITadevolver_textbox.Text
        ' Movimientos.ControldecargamovimientoWPF.Cuitdelbeneficiario_textbox.Text = CUITadevolver_textbox.Text
        Select Case CUIT_textual.GetType().Name
            Case Is = "DataGridViewTextBoxCell"
                Select Case ValidarCuit(CUITadevolver_textbox.Text)
                    Case True
                        CUIT_textual.value = CUITadevolver_textbox.Text
                        '        CUITadevolver_textbox = CUIT_textual
                        Me.Close()
                    Case False
                End Select
            Case Else
                Select Case ValidarCuit(CUITadevolver_textbox.Text)
                    Case True
                        CUIT_textual.Text = CUITadevolver_textbox.Text
                        '        CUITadevolver_textbox = CUIT_textual
                        Me.Close()
                    Case False
                End Select
        End Select
    End Sub

    Private Sub Botoncancelardevolver_Click(sender As Object, e As EventArgs) Handles Botoncancelardevolver.Click
        Me.Close()
    End Sub

    Private Sub Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Busqueda.KeyDown
        'Boton_busqueda.PerformClick()
        Buscar_datagrid_TIMER(Busqueda, Datosdebeneficiario, Datosbeneficiarios_datagridview)
    End Sub

    Private Sub AgregarCUIT_boton_Click(sender As Object, e As EventArgs) Handles AgregarCUIT_boton.Click
        Dim valorCorrecto(1) As Boolean
        Dim valorFinal As Boolean = True
        Dim MessageError(valorCorrecto.Length - 1) As String
        Dim MessageFinal As String = ""
        Select Case CBU_Nro.Text.Length
            Case = 22
                valorCorrecto(0) = True
                MessageError(0) = ""
            Case = 0
                valorCorrecto(0) = True
                MessageError(0) = ""
            Case Else
                valorCorrecto(0) = False
                MessageError(0) = "El número de CBU no contiene la longitud correcta, por favor verifique"
        End Select
        Select Case ValidarCuit(Cuitadd_textbox.Text)
            Case True
                valorCorrecto(1) = True
                MessageError(1) = ""
            Case False
                valorCorrecto(1) = False
                MessageError(1) = "El número de CUIT es incorrecto"
        End Select
        'Select Case Cuitadd_textbox.Text.Length
        '    Case
        'End Select
        For x = 0 To valorCorrecto.Length - 1
            valorFinal = valorFinal And valorCorrecto(x)
        Next
        For x = 0 To MessageError.Length - 1
            MessageFinal = MessageFinal & vbCrLf & MessageError(x)
        Next
        Select Case valorFinal
            Case True
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitadd_textbox.Text)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@NOMBRE", Nombrebeneficiario_textbox.Text)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CBU", CBU_Nro.Text)
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CBUALIAS", CBU_alias.Text)
                SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO proveedores (PROVEEDOR,CUIT,CBU,CBUALIAS,Usuario) " &
            "VALUES (@NOMBRE,@CUIT,@CBU,@CBUALIAS,@Usuario) " &
            " ON DUPLICATE KEY UPDATE PROVEEDOR=@NOMBRE, CUIT=@CUIT,CBU=@CBU,CBUALIAS=@CBUALIAS,Usuario=@Usuario;"
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                Datosbeneficiarios_Panel.Enabled = True
                Boton_busqueda.PerformClick()
            Case False
                MsgBox(MessageFinal, MsgBoxStyle.Information)
        End Select
    End Sub

    Private Sub CancelarCUIT_boton_Click(sender As Object, e As EventArgs) Handles CancelarCUIT_boton.Click
        DatosnuevoCUIT_panel.Visible = False
        Datosbeneficiarios_Panel.Enabled = True
    End Sub

    Private Sub Cuitadd_textbox_TextChanged(sender As Object, e As EventArgs) Handles Cuitadd_textbox.TextChanged
        Inicio.Verificar(sender, sender.Text, "CUIT")
        Select Case sender.BackColor = Color.FromArgb(255, 229, 245, 232)
            Case True
                AgregarCUIT_boton.Enabled = True
            Case False
                AgregarCUIT_boton.Enabled = False
        End Select
    End Sub

    Private Sub Cargarnuevocuit_boton_Click(sender As Object, e As EventArgs) Handles Cargarnuevocuit_boton.Click
        CUIT_agregarnuevo.llamado(Me, 0)
    End Sub

    Private Sub Datosbeneficiarios_datagridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datosbeneficiarios_datagridview.CellDoubleClick
        BotondevolverCuit.PerformClick()
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
    End Sub

    Private Sub Cerrar_boton_Click(sender As Object, e As EventArgs) Handles Cerrar_boton.Click
        Me.Close()
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label_expedienteasociados.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub registroproveedores_Click(sender As Object, e As EventArgs) Handles registroproveedores.Click
        Dim prove As RegProveedores() = RespuestaProveedores.DevolverRegistroProveedor(CUITadevolver_textbox.Text)
        MessageBox.Show($" el nombre de este proveedor es {prove(0).companyName.ToString  }")
    End Sub

End Class