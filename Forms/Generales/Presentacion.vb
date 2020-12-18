Public Class Presentacion

    Private Sub Presentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Seleccionbase()
    End Sub

    Private Sub Presentacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Select Case MsgBox("Utilizar base de datos en blanco?", MsgBoxStyle.YesNoCancel, "Selección de Base de Datos")
        '    Case MsgBoxResult.Yes
        '        SERVIDORMYSQL.DATABASE = "SERV_ADM_3830"
        '        Autorizaciones.Organismo.tostring.substring(0,4) = "3830"
        '        Autorizaciones.Organismotabla = "serv_adm_3830"
        '        Autorizaciones.Nombrecompletodelservicio = "SERVICIO ADMINISTRATIVO DE ACCIÓN COOPERATIVA, MUTUAL, COMERCIO E INTEGRACIÓN, ENERGÍA Y AGRICULTURA"
        '        MessageBox.Show("Se utiliza la Base de datos en blanco")
        '    Case MsgBoxResult.Cancel
        '        MessageBox.Show("Se utiliza la Base de datos de ejemplo")
        '        SERVIDORMYSQL.DATABASE = "SERV_ADM_3804"
        '        Autorizaciones.Organismo.tostring.substring(0,4) = "3804"
        '        Autorizaciones.Organismotabla = "serv_adm_3804"
        '        Autorizaciones.Nombrecompletodelservicio = "SERVICIO ADMINISTRATIVO DE POLICÍA Y SERVICIO PENITENCIARIO PROVINCIAL"
        '    Case MsgBoxResult.No
        '        MessageBox.Show("Se utiliza la Base de datos de ejemplo")
        '        SERVIDORMYSQL.DATABASE = "SERV_ADM_3804"
        '        Autorizaciones.Organismo.tostring.substring(0,4) = "3804"
        '        Autorizaciones.Organismotabla = "serv_adm_3804"
        '        Autorizaciones.Nombrecompletodelservicio = "SERVICIO ADMINISTRATIVO DE POLICÍA Y SERVICIO PENITENCIARIO PROVINCIAL"
        'End Select
        INGRESO.Close()
        INGRESO.Dispose()
        'Inicio.autorizaciones_control()
        '  cargasuplementaria()
        Fondopicturebox.Visible = True
    End Sub

    Private Sub Seleccionbase()
        'Select Case Baseejemplo_boton.BackColor
        '    Case Color.Gainsboro
        '        Baseejemplo_boton.BackColor = Color.LightGreen
        '        Basevacia_boton.BackColor = Color.Gainsboro
        '        SERVIDORMYSQL.DATABASE = "SERV_ADM_3804"
        '        Autorizaciones.Organismo.tostring.substring(0,4) = "3804"
        '        Autorizaciones.Organismotabla = "serv_adm_3804"
        '        Autorizaciones.Nombrecompletodelservicio = "SERVICIO ADMINISTRATIVO DE POLICÍA Y SERVICIO PENITENCIARIO PROVINCIAL"
        '        Labelbasededatos.Text = ("Se utiliza la " & vbCrLf & " Base de datos de ejemplo")
        ''    Case Color.LightGreen
        'Baseejemplo_boton.BackColor = Color.Gainsboro
        '        Basevacia_boton.BackColor = Color.LightGreen
        '        SERVIDORMYSQL.DATABASE = "SERV_ADM_3830"
        '        Autorizaciones.Organismo.tostring.substring(0,4) = "3830"
        '        Autorizaciones.Organismotabla = "serv_adm_3830"
        '        Autorizaciones.Nombrecompletodelservicio = "SERVICIO ADMINISTRATIVO DE ACCIÓN COOPERATIVA, MUTUAL, COMERCIO E INTEGRACIÓN, ENERGÍA Y AGRICULTURA"
        '        Labelbasededatos.Text = ("Se utiliza la " & vbCrLf & " Base de datos en blanco")
        'End Select
        'servicio administrativo de acción cooperativa
        'SERVIDORMYSQL.DATABASE = "SERV_ADM_3830"
        'Autorizaciones.Organismo.tostring.substring(0,4) = "3830"
        'Autorizaciones.Organismotabla = "serv_adm_3830"
        'Autorizaciones.Nombrecompletodelservicio = "SERVICIO ADMINISTRATIVO DE ACCIÓN COOPERATIVA, MUTUAL, COMERCIO E INTEGRACIÓN, ENERGÍA Y AGRICULTURA"
        'Labelbasededatos.Text = ("Se utiliza la " & vbCrLf & " Base de datos en blanco")
    End Sub

    Private Sub Baseejemplo_boton_Click(sender As Object, e As EventArgs)
        Seleccionbase()
    End Sub

    Private Sub Basevacia_boton_Click(sender As Object, e As EventArgs)
        Seleccionbase()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub Fondopicturebox_Click(sender As Object, e As EventArgs) Handles Fondopicturebox.Click
    End Sub

    'Private Sub cargasuplementaria()
    '    Inicio.SQLPARAMETROSgrafico(Autorizaciones.Organismotabla, "select 'Ingresos' as tipo,(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END from expediente_detalle where (Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=3 or CodInp=4 or CodInp=9)) as 'Monto'
    '    union all
    '    select 'Egresos' as tipo,(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END from expediente_detalle where (Cod_orden=1 or Cod_orden=2 or Cod_orden=3 or Cod_orden=4 or Cod_orden=9) and (CFdo=1 or CFdo=2 or CFdo=9) and (CodInp=1 )) as 'Monto'
    '    union all
    '    select 'Rendido' as tipo,(select CASE when sum(monto)>=0 THEN sum(monto) ELSE 0 END from expediente_detalle where ( CodInp=2 )) as 'Monto'", Chartdeprueba, DataVisualization.Charting.SeriesChartType.Column, "Ingresos y egresos", "tipo", "Monto", System.Reflection.MethodBase.GetCurrentMethod.Name)
    'End Sub
    'Private Sub Presentacion_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
    '    cargasuplementaria()
    'End Sub
End Class