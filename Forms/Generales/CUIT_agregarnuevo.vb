Public Class CUIT_agregarnuevo
    Dim ventanabloqueada As Object
    Dim haberes As Integer = 0

    'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    Me.Close()
    'End Sub
    'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End Sub
    Public Sub llamado(ByRef ventanabloquear As Object, ByVal haberes As Integer)
        ventanabloquear.enabled = False
        ventanabloqueada = ventanabloquear
        Me.ShowDialog()
        If haberes = 1 Then
            Cuitadd_textbox.Visible = False
        Else
            Cuitadd_textbox.Visible = True
        End If
        Nombrebeneficiario_textbox.Select()
    End Sub

    Public Sub CARGARCUIT_MODIFICAR(ByVal PROV As Proveedor, ByRef ventanabloquear As Object)
        PROV.Cargardatos()
        Nombrebeneficiario_textbox.Text = PROV.Nombre
        Cuitadd_textbox.Text = PROV.CUIT
        'Nombrebeneficiario_textbox.Text =
        Nombrefantasiabeneficiario_textbox.Text = PROV.Nombre_Fantasia
        Domicilio_textbox.Text = PROV.Domicilio_real
        ventanabloqueada = ventanabloquear
        Me.ShowDialog()
        Nombrebeneficiario_textbox.Select()
    End Sub

    Private Sub CUIT_agregarnuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        For x = 0 To valorCorrecto.Length - 1
            valorFinal = valorFinal And valorCorrecto(x)
        Next
        For x = 0 To MessageError.Length - 1
            MessageFinal = MessageFinal & vbCrLf & MessageError(x)
        Next
        Select Case valorFinal
            Case True
                Select Case Cuitadd_textbox.Text.Contains("-")
                    Case True
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitadd_textbox.Text)
                    Case False
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", Cuitadd_textbox.Text.Substring(0, 2) & "-" & Cuitadd_textbox.Text.Substring(2, 8) & "-" & Cuitadd_textbox.Text.Substring(10, 1))
                End Select
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@NOMBRE", Nombrebeneficiario_textbox.Text)
                Select Case CBU_Nro.Text.Length = 0
                    Case True
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CBU", vbNull)
                    Case False
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CBU", CBU_Nro.Text)
                End Select
                Select Case CBU_alias.Text.Length = 0
                    Case True
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CBUALIAS", vbNull)
                    Case False
                        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CBUALIAS", CBU_alias.Text)
                End Select
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DOMICILIOREAL", Domicilio_textbox.Text)
                'NOMBRE DE FANTASIA
                SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@NOMBREFANTASIA", Nombrefantasiabeneficiario_textbox.Text)
                If haberes = 0 Then
                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO proveedores (PROVEEDOR,CUIT,CBU,CBUALIAS,NOMBREFANTASIA,DOMICILIOREAL,Usuario) " &
            "VALUES (@NOMBRE,@CUIT,@CBU,@CBUALIAS,@NOMBREFANTASIA,@DOMICILIOREAL,@Usuario) " &
            " ON DUPLICATE KEY UPDATE PROVEEDOR=@NOMBRE, CUIT=@CUIT,CBU=@CBU,CBUALIAS=@CBUALIAS,NOMBREFANTASIA=@NOMBREFANTASIA,DOMICILIOREAL=@DOMICILIOREAL,Usuario=@Usuario;"
                Else
                    SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO proveedores_haberes (PROVEEDOR,CUIT,CBU,CBUALIAS,NOMBREFANTASIA,Usuario) " &
            "VALUES (@NOMBRE,@CUIT,@CBU,@CBUALIAS,@NOMBREFANTASIA,@Usuario) " &
            " ON DUPLICATE KEY UPDATE PROVEEDOR=@NOMBRE, CUIT=@CUIT,CBU=@CBU,CBUALIAS=@CBUALIAS,NOMBREFANTASIA=@NOMBREFANTASIA,Usuario=@Usuario;"
                End If
                Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
                MessageBox.Show("Actualizado " & Nombrebeneficiario_textbox.Text & vbCrLf & "Con el CUIT" & Cuitadd_textbox.Text)
                TODOACERO()
            Case False
                MsgBox(MessageFinal, MsgBoxStyle.Information)
        End Select
    End Sub

    Private Sub TODOACERO()
        Nombrebeneficiario_textbox.Text = ""
        Cuitadd_textbox.Text = ""
        CBU_Nro.Text = ""
        CBU_alias.Text = ""
        Nombrebeneficiario_textbox.Text = ""
        Cuitadd_textbox.Text = ""
        Nombrefantasiabeneficiario_textbox.Text = ""
        Domicilio_textbox.Text = ""
        CBU_Nro.Text = ""
        CBU_alias.Text = ""
    End Sub

    Private Sub CancelarCUIT_boton_Click(sender As Object, e As EventArgs) Handles CancelarCUIT_boton.Click
        'VOLVER TODO A CERO
        TODOACERO()
        Me.Close()
    End Sub

    Private Sub CUIT_agregarnuevo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ventanabloqueada.enabled = True
    End Sub

    Private Sub Cuitadd_textbox_TextChanged(sender As Object, e As EventArgs) Handles Cuitadd_textbox.TextChanged
        If Cuitadd_textbox.Text.Length > 0 Then
            CUIT_verificador.Visible = True
            Dim valorCorrecto(1) As Boolean
            Select Case ValidarCuit(Cuitadd_textbox.Text)
                Case True
                    valorCorrecto(1) = True
                    CUIT_verificador.Image = My.Resources.checkmark
                'MessageError(1) = ""
                Case False
                    valorCorrecto(1) = False
                    CUIT_verificador.Image = My.Resources.checkbox_cross
                    'MessageError(1) = "El número de CUIT es incorrecto"
            End Select
            If (Cuitadd_textbox.Text.Length = 7) Or (Cuitadd_textbox.Text.Length = 8) Then
                If IsNumeric(Cuitadd_textbox.Text) Then
                    CUITLABELMASCULINO.Text = (GenerarCUIT_DNI(CType(Cuitadd_textbox.Text, Double), "MASCULINO"))
                    CUITLABELTEORICOfEMENINO.Text = (GenerarCUIT_DNI(CType(Cuitadd_textbox.Text, Double), "FEMENINO"))
                End If
            Else
                CUITLABELMASCULINO.Text = ""
                CUITLABELTEORICOfEMENINO.Text = ""
            End If
        Else
            CUIT_verificador.Visible = False
            CUITLABELMASCULINO.Text = ""
            CUITLABELTEORICOfEMENINO.Text = ""
        End If
    End Sub

    Private Sub Nombrebeneficiario_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Nombrebeneficiario_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Cuitadd_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Cuitadd_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub CBU_Nro_KeyDown(sender As Object, e As KeyEventArgs) Handles CBU_Nro.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub CBU_alias_KeyDown(sender As Object, e As KeyEventArgs) Handles CBU_alias.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, Label_expedienteasociados.MouseMove
        Moverventanasinborde(sender, e, Me)
    End Sub

    Private Sub CUITLABELTEORICO_Click(sender As Label, e As EventArgs) Handles CUITLABELTEORICOfEMENINO.Click, CUITLABELMASCULINO.Click
        Cuitadd_textbox.Text = sender.Text
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
    End Sub

    Private Sub CBU_Nro_TextChanged(sender As Object, e As EventArgs) Handles CBU_Nro.TextChanged
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
    End Sub

    Private Sub CBU_alias_TextChanged(sender As Object, e As EventArgs) Handles CBU_alias.TextChanged
    End Sub

    Private Sub Nombrefantasiabeneficiario_textbox_TextChanged(sender As Object, e As EventArgs) Handles Nombrefantasiabeneficiario_textbox.TextChanged
    End Sub

End Class