Imports System.Configuration

Public Module SERVIDORMYSQL

    Public COMMANDSQL As New MySql.Data.MySqlClient.MySqlCommand
    Public conn2 As New MySql.Data.MySqlClient.MySqlConnection
    Public DATABASE As String = "SERV_ADM_3809_" & Date.Now.Year
    Public ENCRIPTACION As New AESencriptacion
    Public HASH_AES_BD As New AES_basededatos
    Public INSERTCOMMANDSQL As New MySql.Data.MySqlClient.MySqlCommand
    Public LECTORSQL As MySql.Data.MySqlClient.MySqlDataAdapter
    Public PORT As String = ""
    Public PWD1 As String = ""
    Public PWD2 As String = ""
    Public PWDactivo As String = ""
    Public SERVER1 As String = ""

    'SERVIDOR2
    Public SERVER2 As String = ""
    Public ServerActivo As String = ""
    Public USUARIO1 As String = ""
    Public USUARIO2 As String = ""
    Public USUARIOactivo As String = ""

    Public Function ServermysqltoModulo(Servidores As ServerMysql)

        PORT = Servidores.Port.ToString
        PWD1 = Servidores.Pwd
        PWD2 = Servidores.Pwd
        PWDactivo = Servidores.Pwd
        SERVER1 = Servidores.Server

        'SERVIDOR2
        SERVER2 = Servidores.Server
        ServerActivo = Servidores.Server
        USUARIO1 = Servidores.Usuario
        USUARIO2 = Servidores.Usuario
        USUARIOactivo = Servidores.Usuario
    End Function
    Public Function Errormysql(ByRef Numeroerror As Integer) As String
        Select Case Numeroerror
            Case 0
                Return ("BD Offline")
            Case 1042
                Return ("BD Offline-1042")
            Case 1045
                Return ("Pass Incorrecto")
            Case 1046
                Return ("No se ha seleccionado Tabla de datos")
            Case Else
                Return (Numeroerror.ToString & "-ERROR DESC")
        End Select
    End Function

End Module