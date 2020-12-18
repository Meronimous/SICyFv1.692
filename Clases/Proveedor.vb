'/////////////////////////////////////////////////////////*************************************************************************************************************************
Public Class Proveedor
    Public CUIT As String
    Public Nombre As String
    Public Domicilio_real As String
    Public Nombre_Fantasia As String
    Public Domicilio_legal As String
    Public Rubro As String
    Public Registroproveedores_numero As String
    Public Vencimiento As Date
    Public CAE_AFIP As String
    Public Respuesta_AFIP As String
    'Public Property Respuesta_AFIP() As String
    '    Get
    '        Return Respuesta_AFIP
    '    End Get
    '    Set(ByVal value As String)
    '        _Respuesta_AFIP = value
    '    End Set
    'End Property
    Private _Ultimaconsulta_AFIP As Date
    Public Property Ultimaconsulta_AFIP() As Date
        Get
            Return Ultimaconsulta_AFIP
        End Get
        Set(ByVal value As Date)
            _Ultimaconsulta_AFIP = value
        End Set
    End Property
    Private _registrationReportUrl As String
    Public Property registrationReportUrl() As String
        Get
            Return _registrationReportUrl
        End Get
        Set(ByVal value As String)
            _registrationReportUrl = value
        End Set
    End Property

    Public Sub New()
        Me.clear()
    End Sub

    Public Sub clear()
        CUIT = ""
        Nombre = "DEBE REGISTRAR LOS DATOS"
        Domicilio_legal = ""
        Domicilio_real = ""
        Nombre_Fantasia = ""
        Rubro = ""
        Registroproveedores_numero = ""
        Vencimiento = Date.Now
        CAE_AFIP = ""
        Respuesta_AFIP = ""
    End Sub

    Public Sub Cargardatos()
        Dim Tabla_temporal As New DataTable
        If Not CUIT = "" Then
            Select Case ValidarCuit(CUIT)
                Case True
                    Dim CUIT_datatable As New DataTable
                    SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", CUIT)
                    Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, "Select * from proveedores Where CUIT=@CUIT", Tabla_temporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
                    If Tabla_temporal.Rows.Count > 0 Then
                        Nombre = Tabla_temporal.Rows(0).Item("Proveedor").ToString
                        If Not IsNothing(Tabla_temporal.Rows(0).Item("DOMICILIOREAL")) Then
                            Domicilio_legal = Tabla_temporal.Rows(0).Item("DOMICILIOREAL").ToString
                        End If
                        Domicilio_real = Tabla_temporal.Rows(0).Item("DOMICILIOREAL").ToString
                        Nombre_Fantasia = Tabla_temporal.Rows(0).Item("NOMBREFANTASIA").ToString
                        Rubro = Tabla_temporal.Rows(0).Item("RUBRO").ToString
                        Registroproveedores_numero = Tabla_temporal.Rows(0).Item("NUMERO").ToString
                        CAE_AFIP = Tabla_temporal.Rows(0).Item("CAE").ToString
                        Respuesta_AFIP = Tabla_temporal.Rows(0).Item("RESPUESTA").ToString
                        'Vencimiento = Tabla_temporal.Rows(0).Item("VENCIMIENTO")
                    Else
                        Nombre = "DEBE REGISTRAR LOS DATOS"
                        If Not IsNothing(Tabla_temporal.Rows(0).Item("DOMICILIOREAL")) Then
                            Domicilio_legal = ""
                        End If
                        Domicilio_real = ""
                        Nombre_Fantasia = ""
                        Rubro = ""
                        Registroproveedores_numero = ""
                        Vencimiento = Date.Now
                    End If
                Case False
            End Select
        Else
        End If
    End Sub

    Public Shared Function Proveedor_de_Nrotransferencia(ByVal nrotransferencia As Double, Optional cuit As String = "") As DataTable
        Dim tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@Nrotransferencia", nrotransferencia)
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", cuit)
        If Not cuit = "" Then
            SERVIDORMYSQL.COMMANDSQL.CommandText = "
select a.cuit,prov.proveedor from
/*Datos del movimiento*/
(Select cuit from expediente_detalle where nrotransferencia=@nrotransferencia and cuit=@CUIT group by cuit)A
/*Datos del proveedor*/
left join
(Select Proveedor,cuit from proveedores)prov
on a.cuit=prov.cuit"
        Else
            SERVIDORMYSQL.COMMANDSQL.CommandText = "
select a.cuit,prov.proveedor from
/*Datos del movimiento*/
(Select cuit from expediente_detalle where nrotransferencia=@nrotransferencia group by cuit)A
/*Datos del proveedor*/
left join
(Select Proveedor,cuit from proveedores)prov
on a.cuit=prov.cuit"
        End If
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, SERVIDORMYSQL.COMMANDSQL.CommandText, tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        Return tablatemporal
    End Function

    Public Shared Function Nombre_proveedor(ByVal CUITS As String) As String
        Dim tablatemporal As New DataTable
        SERVIDORMYSQL.COMMANDSQL.Parameters.Clear()
        SERVIDORMYSQL.COMMANDSQL.Parameters.AddWithValue("@CUIT", CUITS)
        SERVIDORMYSQL.COMMANDSQL.CommandText = "select * from proveedores where CUIT=@CUIT"
        Inicio.SQLPARAMETROS(Autorizaciones.Organismotabla, SERVIDORMYSQL.COMMANDSQL.CommandText, tablatemporal, System.Reflection.MethodBase.GetCurrentMethod.Name)
        If tablatemporal.Rows.Count > 0 Then
            Return tablatemporal.Rows(0).Item("proveedor")
        Else
            Return "Sin Datos"
        End If
    End Function

    Public Sub updateproveedorregistro(ByVal datosregistro As RegProveedores)
        INSERTCOMMANDSQL.Parameters.Clear()
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@CUIT", datosregistro.cuit.Substring(0, 2) & "-" & datosregistro.cuit.Substring(2, 8) & "-" & datosregistro.cuit.Substring(10, 1))
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Proveedor", datosregistro.companyName)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@NOMBREFANTASIA", datosregistro.fantasyName)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Rubro", "A IMPLEMENTAR")
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DOMICILIOREAL", $"{datosregistro.realAddress(1)}")
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DOMICILIOREALLOCALIDAD", datosregistro.realAddress(0).first.value.ToString)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DOMICILIOREALPROVINCIA", "''")
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DOMICILIOLEGAL", datosregistro.legalAddress(1))
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@DOMICILIOLEGALLOCALIDAD", datosregistro.legalAddress(0).first.value.ToString)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@TELEFONO", datosregistro.phoneNumber)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@EMAIL", datosregistro.email)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@NUMERO", vbNull)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Vencimiento", CType(datosregistro.endDate, Date))
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@SITUACION", datosregistro.status)
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@Observaciones", "'actualizado'")
        SERVIDORMYSQL.INSERTCOMMANDSQL.Parameters.AddWithValue("@registrationReportUrl", datosregistro.registrationReportUrl)
        SERVIDORMYSQL.INSERTCOMMANDSQL.CommandText = "INSERT INTO PROVEEDORES
(PROVEEDOR,
NOMBREFANTASIA,
CUIT,
RUBRO,
DOMICILIOREAL,
DOMICILIOREALLOCALIDAD,
DOMICILIOREALPROVINCIA,
DOMICILIOLEGAL,
DOMICILIOLEGALLOCALIDAD,
TELEFONO,
EMAIL,
NUMERO,
VENCIMIENTO,
SITUACION,
Observaciones,
registrationReportUrl)
VALUES
(@PROVEEDOR,
@NOMBREFANTASIA,
@CUIT,
@RUBRO,
@DOMICILIOREAL,
@DOMICILIOREALLOCALIDAD,
@DOMICILIOREALPROVINCIA,
@DOMICILIOLEGAL,
@DOMICILIOLEGALLOCALIDAD,
@TELEFONO,
@EMAIL,
@NUMERO,
@VENCIMIENTO,
@SITUACION,
@Observaciones,
@registrationReportUrl)
ON DUPLICATE KEY UPDATE
PROVEEDOR=@PROVEEDOR,
NOMBREFANTASIA=@NOMBREFANTASIA,
RUBRO=@RUBRO,
DOMICILIOREAL=@DOMICILIOREAL,
DOMICILIOREALLOCALIDAD=@DOMICILIOREALLOCALIDAD,
DOMICILIOREALPROVINCIA=@DOMICILIOREALPROVINCIA,
DOMICILIOLEGAL=@DOMICILIOLEGAL,
DOMICILIOLEGALLOCALIDAD=@DOMICILIOLEGALLOCALIDAD,
TELEFONO=@TELEFONO,
EMAIL=@EMAIL,
VENCIMIENTO=@VENCIMIENTO,
SITUACION=@SITUACION,
Observaciones=@Observaciones,
registrationReportUrl=@registrationReportUrl"
        Inicio.INSERTSQLPARAMETROS(Autorizaciones.Organismotabla, System.Reflection.MethodBase.GetCurrentMethod.Name)
    End Sub

End Class