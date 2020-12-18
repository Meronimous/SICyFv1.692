Public Class HarcodedServers



    Private _Mysqlserv As ServerMysql
    Public Property Mysqlserv() As ServerMysql
        Get
            Return _Mysqlserv
        End Get
        Set(ByVal value As ServerMysql)
            _Mysqlserv = value
        End Set
    End Property
    Public Sub New()
        _Mysqlserv = HarcodedServers.Servidores("")

    End Sub



    Public Shared Function Servidores(Servidor As String) As ServerMysql
        Dim ServidorSeleccionado As New ServerMysql
        Dim EncriptacionAES As New AESencriptacion
        Select Case Servidor
            Case Is = "Servidores Roberto"
                'SERVIDORES LOCALES DE PRUEBA
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado.Pwd = ""
                ServidorSeleccionado.Port = 3308
                ServidorSeleccionado.Database = ""
            Case Is = "Notebook Galia"
                '  Notebook Galia
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado.Pwd = ""
                ServidorSeleccionado.Port = 3308
                ServidorSeleccionado.Database = ""
            Case Is = "Servidores UFI"
                ' UNIDAD DE FORTALECIMIENTO INSTITUCIONAL
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado.Pwd = ""
                ServidorSeleccionado.Port = 3308
                ServidorSeleccionado.Database = ""
            Case Is = "Servidores Salud publica"
                'SERVICIO ADMINISTRATIVO DE SALUD PUBLICA
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado.Pwd = ""
                ServidorSeleccionado.Port = 3308
                ServidorSeleccionado.Database = ""
            Case Is = "Servidores Desarrollo Social"
                'SERVICIO ADMINISTRATIVO DE DESARROLLO SOCIAL
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado.Pwd = ""
                ServidorSeleccionado.Port = 3308
                ServidorSeleccionado.Database = ""
            Case Is = "Tunel Salud Pública"
                'TUNEL ANYDESK SALUD PUBLICA
                '  SERVIDOR1
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado.Pwd = ""
                ServidorSeleccionado.Port = 3309
                ServidorSeleccionado.Database = ""
            Case Is = "Servidores Acción Cooperativa"
                            '  SERVIDOR1
                            'SERVIDOR2
            Case Is = "Servidor Externo"
                'Servicio Administrativo de Gobierno
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Port = 3308
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado.Pwd = ""
                ServidorSeleccionado.Database = ""
            Case Else
                'Servicio Administrativo de Gobierno
                ServidorSeleccionado.Server = ""
                ServidorSeleccionado.Port = 3308
                ServidorSeleccionado.Usuario = ""
                ServidorSeleccionado
                ServidorSeleccionado.Database = ""

        End Select
        Return ServidorSeleccionado
    End Function

End Class
