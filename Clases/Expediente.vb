'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class Expediente
    Public claveexpediente As Long
    Public organismo As Integer
    Public Expediente_N As String
    Public numero As Integer
    Public year As Integer
    Public monto As Decimal
    Public fecha As Date
    Public descripcion As String
    Public ordenpago As Integer
    Public ordenpagoyear As Integer
    Public ordencargo As Integer
    Public ordencargoyear As Integer
    Public tieneprincipal As Boolean
    Public haberes As Boolean
    Public principalclaveexpediente As String
    Public principalorganismo As Integer
    Public principalnumero As Integer
    Public principalyear As Integer
    Public principaldescripcion As String
    Public Asignarcuentaespecial As String
    Public cuentaespecial As String
    Public pedidofondo As String
    Public Totales_expediente As New DataTable

    Public Sub New()
        clear()
    End Sub

    'dentro de la estructura retorna la clave del expediente
    Public Function clave() As String
        Return year & organismo & Format(Convert.ToInt32(numero.ToString), "00000")
    End Function

    Public Function claveprincipal() As String
        If principalclaveexpediente.Length < 7 Then
            If (principalnumero > 0) And (principalyear > 0) Then
                Return year & organismo & Format(Convert.ToInt32(numero.ToString), "00000")
            Else
                Return ""
            End If
        Else
            Return principalclaveexpediente
        End If
    End Function

    Public Sub Desglose_clave()
        If claveexpediente.ToString.Length > 12 Then
            organismo = CType(claveexpediente.ToString.Substring(4, 4), Integer)
            numero = CType(claveexpediente.ToString.Substring(8, 5), Integer)
            year = CType(claveexpediente.ToString.Substring(0, 4), Integer)
        Else
            organismo = 0
            numero = 0
            year = Date.Now.Year
        End If
    End Sub

    Public Sub Desglose_clave_principal()
        If principalclaveexpediente.Length > 7 Then
            principalorganismo = CType(principalclaveexpediente.ToString.Substring(4, 4), Integer)
            principalnumero = CType(principalclaveexpediente.ToString.Substring(8, 5), Integer)
            principalyear = CType(principalclaveexpediente.ToString.Substring(0, 4), Integer)
        Else
            principalorganismo = 0
            principalnumero = 0
            principalyear = Date.Now.Year
        End If
    End Sub

    Public Sub clear()
        'organismo = Nothing
        'numero = Nothing
        'year = Nothing
        'Expediente = Nothing
        'monto = Nothing
        'fecha = Nothing
        'descripcion = Nothing
        'ordenpago = Nothing
        'ordenpagoyear = Nothing
        'ordencargo = Nothing
        'ordencargoyear = Nothing
        'tieneprincipal = Nothing
        'principalorganismo = Nothing
        'principalnumero = Nothing
        'principalyear = Nothing
        'principaldescripcion = Nothing
        'Asignarcuentaespecial = Nothing
        'cuentaespecial = Nothing
        'principalclaveexpediente = Nothing
        claveexpediente = 0
        organismo = 0
        Expediente_N = ""
        numero = 0
        year = 0
        monto = 0
        fecha = Date.Now
        descripcion = ""
        ordenpago = 0
        ordenpagoyear = Date.Now.Year
        ordencargo = 0
        ordencargoyear = Date.Now.Year
        tieneprincipal = False
        haberes = False
        principalclaveexpediente = ""
        principalorganismo = 0
        principalnumero = 0
        principalyear = 0
        principaldescripcion = ""
        Asignarcuentaespecial = ""
        cuentaespecial = ""
        pedidofondo = ""
    End Sub

    Public Sub insertar_expediente()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", claveexpediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Expediente_N", Expediente_N)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Fecha", fecha)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Detalle", descripcion)
        If ordenpago > 0 Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordenpago", ordenpago & "/" & ordenpagoyear)
        Else
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordenpago", "")
        End If
        If ordencargo > 0 Then
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordencargo", ordencargo & "/" & ordencargoyear)
        Else
            SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Ordencargo", "")
        End If
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Claveexpteprincipal", principalclaveexpediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Haberes", haberes)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Cuenta_especial", cuentaespecial)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `expediente` " &
                    "(Clave_expediente,Expediente_N,Fecha,Detalle,Ordenpago,Ordencargo,Monto,Claveexpteprincipal,Cuenta_especial,haberes,usuario) " &
                    "VALUES (@Clave_expediente,@Expediente_N,@Fecha,@Detalle,@Ordenpago,@Ordencargo,@Monto,@Claveexpteprincipal,@Cuenta_especial,@Haberes,@usuario)
ON DUPLICATE KEY UPDATE" &
                    "Expediente_N=@Expediente_N,Fecha=@Fecha,Detalle=@Detalle,Ordenpago=@Ordenpago,ordencargo=@OrdenCargo,
        Claveexpteprincipal=@Claveexpteprincipal,Cuenta_especial=@Cuenta_especial,Haberes=@haberes,Usuario=@Usuario Where Clave_expediente=@Clave_expediente"
        'Select Case Esnuevoexpediente
        '    Case True
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO `expediente` " &
        '            "(Clave_expediente,Expediente_N,Fecha,Detalle,Ordenpago,Ordencargo,Monto,Claveexpteprincipal,Cuenta_especial,haberes,usuario) " &
        '            "VALUES (@Clave_expediente,@Expediente_N,@Fecha,@Detalle,@Ordenpago,@Ordencargo,@Monto,@Claveexpteprincipal,@Cuenta_especial,@Haberes,@usuario) "
        '    Case False
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = " UPDATE `expediente` SET " &
        '            "Expediente_N=@Expediente_N,Fecha=@Fecha,Detalle=@Detalle,Ordenpago=@Ordenpago,ordencargo=@OrdenCargo,
        'Claveexpteprincipal=@Claveexpteprincipal,Cuenta_especial=@Cuenta_especial,Haberes=@haberes,Usuario=@Usuario Where Clave_expediente=@Clave_expediente"
        'End Select
        '    'carga de partida presupuestaria
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Public Sub ActualizarMontoExpedienteconOrdenProvision()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", claveexpediente)
        '        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Monto", Expediente_N)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "UPDATE Expediente
INNER JOIN
(Select sum(TOTAL) as Monto,clave_expediente from suministros_orden_provision group by clave_expediente )OrdenesProvision
ON Expediente.clave_expediente = OrdenesProvision.clave_expediente
SET Expediente.Monto = IF(OrdenesProvision.Monto > 0, OrdenesProvision.Monto, Expediente.Monto)
Where Expediente.clave_expediente=@Clave_expediente"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Public Sub ActualizarExptePrincipal(ByVal claveexpediente As Long, ByVal clave_expediente_principal As Long)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Clave_expediente", claveexpediente)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Claveexpteprincipal", clave_expediente_principal)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "
UPDATE `expediente` SET  Claveexpteprincipal=@Claveexpteprincipal Where Clave_expediente=@Clave_expediente
"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

    Public Sub Cargar_expediente(ByVal clave As Long)
        Dim expedientes_datatable As New DataTable
        Dim splitter As String()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", clave)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "
SELECT
CONCAT(Substring(clave_expediente From 5 for 4),'-',cast(Substring(clave_expediente From 9 for 5)AS UNSIGNED),'/',Substring(clave_expediente From 1 for 4)) as 'Expediente N',
CONCAT(Substring(clave_expediente From 5 for 4)) as 'ORGANISMO',
CAST(Substring(clave_expediente From 9 for 5)AS UNSIGNED) as 'Numero',
Substring(clave_expediente From 1 for 4) as 'Year',
Fecha,
Detalle,
Monto,
Clave_pedidofondo,
Clave_expediente,
CUENTA_ESPECIAL,
ClaveExpteprincipal,
Ordenpago,
OrdenCargo,
CONCAT(cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) as 'Pedido Fondo N',
Cuenta_especial,HABERES FROM
Expediente WHERE clave_expediente=@clave_expediente",
                             expedientes_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        claveexpediente = clave
        organismo = expedientes_datatable.Rows(0).Item("organismo")
        Expediente_N = expedientes_datatable.Rows(0).Item("Expediente N")
        numero = expedientes_datatable.Rows(0).Item("Numero")
        year = expedientes_datatable.Rows(0).Item("Year")
        monto = expedientes_datatable.Rows(0).Item("monto")
        fecha = expedientes_datatable.Rows(0).Item("Fecha")
        descripcion = expedientes_datatable.Rows(0).Item("Detalle")
        splitter = Split(expedientes_datatable.Rows(0).Item("ordenpago").ToString, "/")
        If splitter.Count > 1 Then
            ordenpago = splitter(0)
            ordenpagoyear = splitter(1)
        End If
        'ordencargo = 0
        'ordencargoyear = Date.Now.Year
        'tieneprincipal = False
        haberes = expedientes_datatable.Rows(0).Item("haberes")
        ' principalclaveexpediente = ""
        ' principalorganismo = 0
        ' principalnumero = 0
        ' principalyear = 0
        ' principaldescripcion = ""
        ' Asignarcuentaespecial = ""
        ' cuentaespecial = ""
        If Not IsNothing(expedientes_datatable.Rows(0).Item("Clave_pedidofondo")) Or Not IsNothing(expedientes_datatable.Rows(0).Item("Pedido Fondo N")) Then
            pedidofondo = expedientes_datatable.Rows(0).Item("Pedido Fondo N").ToString
        Else
            If Not IsNothing(expedientes_datatable.Rows(0).Item("CUENTA_ESPECIAL")) Then
                pedidofondo = " - asignación especial -"
            Else
                pedidofondo = ""
            End If
        End If
        Totales_expediente = retornartotales(clave)
    End Sub

    Public Function retornartotales(ByVal clave As Long) As DataTable
        Dim TABLA_TEMPORAL As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("CLAVE_EXPEDIENTE", clave.ToString)
        Inicio.SQLPARAMETROS_STOREDPROCEDURE(Autorizaciones.Organismotabla, "TESORERIA_MOVIMIENTOS_VALORESEXPEDIENTE", TABLA_TEMPORAL, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return TABLA_TEMPORAL
    End Function

    Public Function Ver_pedidofondo(ByVal clave As Long) As String
        Dim expedientes_datatable As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Clave_expediente", clave)
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "SELECT
	CONCAT(cast(Substring(Clave_pedidofondo From 9 for 5)AS UNSIGNED),'/',Substring(Clave_pedidofondo From 1 for 4)) as 'Pedido Fondo N' FROM
	Expediente WHERE clave_expediente=@clave_expediente",
                             expedientes_datatable, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If Not IsNothing(expedientes_datatable) Then
            Return expedientes_datatable.Rows(0).Item(0).ToString
        Else
            Return ""
        End If
    End Function

    Public Sub Cambiar_expediente(ByVal clave As Long)
        Dim Carga As New Form
        Dim carga_datatable As New DataTable
        carga_datatable.Columns.Add("Tipo")
        carga_datatable.Columns.Add("Valor")
        Dim t As Type = Me.GetType
        With Carga
            For Each item In t.GetFields
                carga_datatable.Rows.Add(item.Name, "")
            Next
        End With
        Dim carga_datagridview As New DataGridView
        Carga.Controls.Add(carga_datagridview)
        carga_datagridview.DataSource = carga_datatable
        Carga.ShowDialog()
    End Sub

End Class

'/////////////////////////////////////////////////////////*************************************************************************************************************************