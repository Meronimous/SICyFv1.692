Public Class Tesoreria_agregarcheques
    Dim datos_datatable As New DataTable

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        agregar()
    End Sub

    Private Sub agregar()
        Select Case MsgBox("Confirma que quiere agregar los cheques del " & vbCrLf & "Nº" & Inicial.Value & " al " & vbCrLf & "Nº" & Final.Value, MsgBoxStyle.YesNoCancel, "Agregamos cheques?")
            Case MsgBoxResult.Yes
                INSERTARCHEQUES()
                MsgBox("finalizado")
            Case MsgBoxResult.No
            Case MsgBoxResult.Cancel
        End Select
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Tesoreria_agregarcheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicio.CARGACOMBOBOX(Cuentas_combobox, Autocompletetables.Cuentas, "Cuenta", "Descripcion")
        Cuentas_combobox.SelectedIndex = 0
    End Sub

    Private Sub Cuentas_combobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cuentas_combobox.SelectedIndexChanged
        Inicial.Value = 0
        Final.Value = 0
    End Sub

    Private Sub evaluar()
        Listadocheques_valores.DataSource = Nothing
        If Final.Value < Inicial.Value Then
            Final.BackColor = Color.LightCoral
        Else
            Final.BackColor = Color.White
            refresh()
        End If
    End Sub

    Private Sub refresh()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Inicio", Inicial.Value)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Fin", Final.Value)
        Dim consultasql As String = "SELECT NRO_CHEQUE AS 'Nº' FROM TESORERIA_CHEQUES WHERE CUENTA=@CUENTA AND NRO_CHEQUE BETWEEN @INICIO AND @FIN"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, consultasql, datos_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Listadocheques_valores.DataSource = datos_datatable
    End Sub

    Private Sub INSERTARCHEQUES()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta", Autocompletetables.Cuentas.Rows(Cuentas_combobox.SelectedIndex).Item(0).ToString())
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Inicio", Inicial.Value)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fin", Final.Value)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT IGNORE into tesoreria_cheques (NRO_CHEQUE,CUENTA)
Select *,@CUENTA from (
select (i0.i+i1.i*2 +i2.i*4+i3.i*8 +i4.i*16 +i5.i*32 +i6.i*64 +i7.i*128 +i8.i*256 +i9.i*512)+@inicio as i From
(select 0 as i union select 1) as i0
    cross join (select 0 as i union select 1) as i1
    cross join (select 0 as i union select 1) as i2
    cross join (select 0 as i union select 1) as i3
    cross join (select 0 as i union select 1) as i4
    cross join (select 0 as i union select 1) as i5
    cross join (select 0 as i union select 1) as i6
    cross join (select 0 as i union select 1) as i7
    cross join (select 0 as i union select 1) as i8
    cross join (select 0 as i union select 1) as i9)A
		WHERE i between @inicio and @fin"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        refresh()
    End Sub

    Private Sub Inicial_ValueChanged(sender As Object, e As EventArgs) Handles Inicial.ValueChanged
        evaluar()
    End Sub

    Private Sub Final_ValueChanged(sender As Object, e As EventArgs) Handles Final.ValueChanged
        evaluar()
    End Sub

    Private Sub agregar50_boton_Click(sender As Object, e As EventArgs) Handles agregar50_boton.Click
        Final.Value = Inicial.Value + 49
    End Sub

    Private Sub Inicial_KeyDown(sender As Object, e As KeyEventArgs) Handles Inicial.KeyDown, Final.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub sgte_chequera_boton_Click(sender As Object, e As EventArgs) Handles sgte_chequera_boton.Click
        Inicial.Value = Final.Value + 1
        Final.Value = Inicial.Value + 49
        agregar()
    End Sub

End Class