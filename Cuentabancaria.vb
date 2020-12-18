Imports System.Globalization
Public Class Cuentabancaria

    Dim Datoscuenta_datatable As New DataTable
    Private Sub Refreshnow()

        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select Cuenta,Descripcion,Instrumento_legal,Fecha_apertura,Ejercicio,Chequeinicial,Tipodecuenta,caracter FROM Cuenta_bancaria ORDER BY Fecha_apertura desc", Datoscuenta_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Datoscuenta_datagridview.DataSource = Datoscuenta_datatable
        Datoscuenta_datagridview.CurrentCell = Nothing

        Cuenta_textbox.Text = ""
        Descripcion_textbox.Text = ""
        Instrumento_legal_textbox.Text = ""
        'Control_DatetimepickerFechaapertura.Fecha_datetimepicker.SelectedDate = Date.Now
        Ejercicio_numeric.Value = CInt(Date.Now.Year)

    End Sub

    Private Sub Cuenta_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Cuenta_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Descripcion_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Descripcion_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Instrumento_legal_textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Instrumento_legal_textbox.KeyDown
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Fecha_apertura_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub

    Private Sub Ejercicio_textbox_KeyDown(sender As Object, e As KeyEventArgs)
        Inicio.SIGUIENTECONTROL(Me, sender, e)
    End Sub
    Private Sub Insercionymodificacion()
        'numero de cuenta bancaria Cuenta_textbox
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta", Cuenta_textbox.Text)
        'descripcion Descripcion_textbox
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Descripcion", Descripcion_textbox.Text)
        'Instrumento legal que habilita su creación Instrumento_legal_textbox
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Instrumento_legal", Instrumento_legal_textbox.Text)
        'Fecha en la que se abre la cuenta Fecha_apertura_textbox
        'SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_apertura", Convert.ToDateTime(Fecha_apertura_textbox.Text).ToString("yyyy-MM-dd"))
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha_apertura", Control_DatetimepickerFechaapertura.Value)
        'Ejercicio al que pertenece esta Ejercicio_textbox
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ejercicio", Ejercicio_numeric.Value)
        'Primer cheque de la cuenta Chequeinicial_textbox
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Chequeinicial", Chequeinicial_textbox.Text)
        'Tipo de cuenta que pertenece
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Tipodecuenta", Tipodecuenta_Combobox.SelectedValue.ToString)
        'Caracter de la cuenta 
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Caracter", CARACTER_COMBOBOX.SelectedItem.ToString)

        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "Insert Into `cuenta_bancaria` " &
        "(Cuenta,Descripcion,Instrumento_legal,Fecha_apertura,Ejercicio,Chequeinicial,Tipodecuenta,Caracter,Usuario) VALUES " &
        "(@Cuenta,@Descripcion,@Instrumento_legal,@Fecha_apertura,@Ejercicio,@Chequeinicial,@Tipodecuenta,@Caracter,@Usuario) ON DUPLICATE KEY UPDATE " &
        "Cuenta=@Cuenta,Descripcion=@Descripcion,Instrumento_legal=@Instrumento_legal,Fecha_apertura=@Fecha_apertura,Ejercicio=@Ejercicio,Chequeinicial=@Chequeinicial,Tipodecuenta=@Tipodecuenta,Caracter=@Caracter,Usuario=@Usuario"

        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Refreshnow()

    End Sub
    Private Sub Boton_aceptar_Click(sender As Object, e As EventArgs) Handles Boton_aceptar.Click
        Dim verificacion As Boolean = False
        Dim datoscorrectos As Integer = 0
        Dim mensajedeerror As String = ""

        Select Case Chequeinicial_textbox.TextLength
            Case = 8
                datoscorrectos += 1
            Case = 0
                '   mensajedeerror = mensajedeerror & "Debe ingresar el número del primer cheque, por favor verifique"
                Chequeinicial_textbox.Text = "0"
                datoscorrectos += 1
            Case = 1
                '   mensajedeerror = mensajedeerror & "Debe ingresar el número del primer cheque, por favor verifique"
                Chequeinicial_textbox.Text = "0"
                datoscorrectos += 1
            Case Else
                mensajedeerror += "el número de cheque debe contener exactamente 10 números, por favor verifique"
        End Select
        '1

        Select Case Cuenta_textbox.TextLength
            Case = 15
                datoscorrectos += 1
            Case = 0
                mensajedeerror += vbCrLf & "Es imprescindible que ingrese el número de Cuenta, por favor ingreselo"
            Case Else
                mensajedeerror += vbCrLf & "el número de cuenta debe contener   exactamente 15 caracteres, por favor verifique"
        End Select

        '2

        For x = 0 To Autocompletetables.SFyV_CodClasefondo.Rows.Count - 1
            Select Case Tipodecuenta_Combobox.SelectedValue.ToString = Autocompletetables.SFyV_CodClasefondo.Rows(x).Item("Descripcion").ToString
                Case True
                    datoscorrectos += 1
            End Select
        Next

        '3



        Select Case datoscorrectos
            Case = 3
                Insercionymodificacion()
            Case Else
                MessageBox.Show(mensajedeerror & datoscorrectos)
        End Select



    End Sub
    Private Sub Boton_borrar_Click(sender As Object, e As EventArgs) Handles Boton_borrar.Click
        'numero de cuenta bancaria Cuenta_textbox
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta", Cuenta_textbox.Text)

        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "DELETE from `cuenta_bancaria` " &
        " WHERE cuenta=@cuenta"

        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Refreshnow()
    End Sub


    Private Sub Datoscuenta_datagridview_MouseUp(sender As Object, e As MouseEventArgs) Handles Datoscuenta_datagridview.MouseUp
        Select Case e.Button = MouseButtons.Right
            Case True
                Inicio.MOUSEDERECHO(sender, e, sender)
        End Select

    End Sub

    Private Sub Cuentabancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicio.CARGACOMBOBOX(Tipodecuenta_Combobox, Autocompletetables.SFyV_CodClasefondo, "Descripcion", "Descripcion")

        Refreshnow()
        Inicio.Fondosplittercolor(SplitContainer1)

    End Sub

    Private Sub Datoscuenta_datagridview_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Datoscuenta_datagridview.CellEnter
        Select Case Datoscuenta_datagridview.SelectedRows.Count > 0
            Case True
                Cuenta_textbox.Text = Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Cuenta").Value.ToString
                Descripcion_textbox.Text = Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Descripcion").Value.ToString
                Instrumento_legal_textbox.Text = Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Instrumento_legal").Value.ToString
                '                Fecha_apertura_textbox.Text = Convert.ToDateTime(Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Fecha_apertura").Value).ToShortDateString
                '    Control_DatetimepickerFechaapertura.Fecha_datetimepicker.SelectedDate = Convert.ToDateTime(Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Fecha_apertura").Value)
                Ejercicio_numeric.Value = Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Ejercicio").Value
                Chequeinicial_textbox.Text = Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Chequeinicial").Value.ToString

                For x = 0 To Tipodecuenta_Combobox.Items.Count - 1
                    Select Case Tipodecuenta_Combobox.Items(x).ToString = Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Tipodecuenta").Value.ToString
                        Case True
                            Tipodecuenta_Combobox.SelectedIndex = x
                        Case False

                    End Select

                Next
                For x = 0 To CARACTER_COMBOBOX.Items.Count - 1
                    Select Case Datoscuenta_datagridview.SelectedRows(0).Cells.Item("Caracter").Value.ToString = CARACTER_COMBOBOX.Items(x).ToString
                        Case True
                            CARACTER_COMBOBOX.SelectedIndex = x
                            x = CARACTER_COMBOBOX.Items.Count
                        Case False
                    End Select
                Next

            Case Else
                Cuenta_textbox.Text = ""
                Descripcion_textbox.Text = ""
                Instrumento_legal_textbox.Text = ""
                'Fecha_apertura_textbox.Text = Convert.ToDateTime(Date.Now).ToShortDateString
                'Control_DatetimepickerFechaapertura.Fecha_datetimepicker.SelectedDate = Date.Now
                Ejercicio_numeric.Value = CInt(Date.Now.Year)
                Chequeinicial_textbox.Text = 0
        End Select
    End Sub

    Private Sub Cuentabancaria_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode = Keys.F5
            Case True



                Inicio.OBJETOCARGANDO(SplitContainer1, Me, "Actualizando, por Favor espere")
                Refreshnow()
                Inicio.OBJETOFINALIZAR(SplitContainer1, Me)
        End Select
    End Sub




End Class