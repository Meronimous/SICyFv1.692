'Imports System.Runtime.CompilerServices
'Imports System.Windows.Media
'Imports System.Net.Sockets
'Imports iTextSharp.text.pdf
'Imports iTextSharp.text
'Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography

'Imports ClosedXML.Excel
Imports System.Text

'Imports System.Threading
'Imports System.ComponentModel
'Imports Microsoft.Win32
Imports ZXing
Imports ZXing.QrCode.Internal
Imports ZXing.Rendering

'Imports System.Reflection
'Imports PdfiumViewer
'Imports System.Text.RegularExpressions
'Imports ComponentFactory.Krypton.Toolkit
'Imports SICyF
'Imports System.Deployment.Application
'Imports Spire.Xls
'Imports System
Public Class AES_basededatos
    Dim EncryptionKey As String = "CONTADURIA"

    'Función Encriptar actualizada al 02/10/2018
    Public Function Encriptarbd(clearText As String) As String
        'La línea siguiente:
        '(Dim BYTESVACIO As Byte() = Encoding.UTF8.GetBytes(clearText))
        'Es detectada por diversos Antivirus como parte de un Virus al 20/03/2018, por lo cual se crea la función UNICODESTRINGTOBYTES
        'Private Function UnicodeStringToBytes(ByVal str As String) As Byte()
        '      Return System.Text.Encoding.Unicode.GetBytes(str)
        'End Function
        'Dim BYTESVACIO As Byte() = Nothing
        'Problema con Antivirus solucionado al 02/10/2018.
        Dim BYTESVACIO As Byte() = Encoding.UTF8.GetBytes(clearText)
        'Using encryptor As RijndaelManaged = RijndaelManaged.Create() 'Compatibilidad con Net.Framework 2.0
        Using encryptor As Aes = Aes.Create() 'Compatibilidad con Net.Framework a partir del 3.5
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                   &H65, &H64, &H76, &H65, &H64, &H65,
                   &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(BYTESVACIO, 0, BYTESVACIO.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    'Función Desencriptar actualizada al 02/10/2018
    Public Function Desencriptarbd(cipherText As String) As String
        'Actualización al 20-03-2018
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        'utilizo el RijndaelManaged por utilizar el net.framework 2.0 que lo denomina así, a partir de las versiones iguales o superiores a 3.5 el encriptador se denomina AES
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                   &H65, &H64, &H76, &H65, &H64, &H65,
                   &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.UTF8.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

End Class

Public Module QRv2

    Public Function GenerateQR(ByVal width As Integer, ByVal height As Integer, ByVal text As String, ByVal LOGO As Bitmap) As Bitmap
        Dim bw = New ZXing.BarcodeWriter()
        Dim encOptions = New ZXing.Common.EncodingOptions With {
            .Width = width * 2,
            .Height = height * 2,
            .Margin = 0,
        .PureBarcode = False
        }
        encOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H)
        bw.Renderer = New BitmapRenderer()
        bw.Options = encOptions
        bw.Format = ZXing.BarcodeFormat.QR_CODE
        Dim bm As Bitmap = bw.Write(text)
        Dim overlay As Bitmap = LOGO
        ''-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        ''Esto es necesario para calcular la posición del logo e insertarlo delante del código QR, se "anula" para colocar el código Qr puro
        'Dim deltaHeigth As Integer = bm.Height - (overlay.Height / 2)
        'Dim deltaWidth As Integer = bm.Width - (overlay.Width / 2)
        'Dim g As Graphics = Graphics.FromImage(bm)
        'g.DrawImage(overlay, New Point(deltaWidth / 2, deltaHeigth / 2))
        ''Esto es necesario para calcular la posición del logo e insertarlo delante del código QR, se "anula" para colocar el código Qr puro
        ''-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        Return bm
    End Function

    'Public Function ResizeImage(ByVal InputImage As Image) As Bitmap
    '    Return New Bitmap(InputImage, New Size(64, 64))
    'End Function
End Module

Public Module TESO_SERVIDORMYSQL
    Public ENCRIPTACIONx As New AESencriptacion
    Public HASH_AES_BDx As New AES_basededatos
    Public PORTx As String = "3306"
    Public DATABASEx As String = " "
    Public SERVERx As String = "66.97.38.62"
    Public USUARIOx As String = "usr_tesoantesala"
    Public PWDx As String = "jc92_xSl20_s4tdW"
    'SERVIDORACTIVO
    Public ServerActivox As String = SERVERx
    Public USUARIOactivox As String = USUARIOx
    Public PWDactivox As String = PWDx
    Public COMMANDSQLx As New MySql.Data.MySqlClient.MySqlCommand
    Public INSERTCOMMANDSQLx As New MySql.Data.MySqlClient.MySqlCommand
    Public conn2x As New MySql.Data.MySqlClient.MySqlConnection
    Public LECTORSQLx As MySql.Data.MySqlClient.MySqlDataAdapter

    Public Function Errormysqlx(ByRef Numeroerror As Integer) As String
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
Public Module Autocompletetables
    Public Proveedores As New DataTable
    Public Organismos As New DataTable
    Public Cuentas As New DataTable
    Public Plan_Cuenta_Tesoro As New DataTable
    Public Clasefondo As New DataTable
    Public Tabla_detallada As New DataTable
    Public SFyV_Codorden As New DataTable
    Public SFyV_CodClasefondo As New DataTable
    Public SFyV_Codimputacion As New DataTable
End Module
Public Module Autorizaciones
    Public Usuario As New DataTable
    Public Menuautorizado As New DataTable
    Public userdatabase As String = "CONTADURIA_USUARIOS"
    Public Organismo As String = ""
    Public Organismotabla As String = ""
    Public Year As Integer = 0
    Public Nombrecompletodelservicio As String
    Public Nombreabreviadodelservicio As String
    Public CUIT_servicioadministrativo As String
    Public DOMICILIOdelservicioadm As String
End Module
'Public Module Extensions2
'    <DllImport("USER32.dll")>
'    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Boolean, ByVal lParam As IntPtr) As Integer
'    End Function
'    Private Const WM_SETREDRAW As Integer = 11
'    ' Extension methods for Control
'    <Extension()>
'    Public Sub ResumeDrawing(ByVal Target As Control, ByVal Redraw As Boolean)
'        SendMessage(Target.Handle, WM_SETREDRAW, True, 0)
'        If Redraw Then
'            Target.Refresh()
'        End If
'    End Sub
'    <Extension()>
'    Public Sub SuspendDrawing(ByVal Target As Control)
'        SendMessage(Target.Handle, WM_SETREDRAW, False, 0)
'    End Sub
'    <Extension()>
'    Public Sub ResumeDrawing(ByVal Target As Control)
'        ResumeDrawing(Target, True)
'    End Sub
'End Module
Public Structure MFyV_movimientos
    Public Cuenta As String
    Public FECHA As Date
    Public CODIGO_IMPUTAC As String
    Public CODIGO_ORDEN As String
    Public NUMERO_COMPROBANTE As String
    Public EXTRACTO As String
    Public CLASE_FONDO As String
    Public PEDIDO_DE_FONDO As String
    Public EXPEDIENTE As String
    Public INGRESOS As String
    Public EGRESOS As String

    Public Function MD5hash() As String
        Return Inicio.GenerateHash(Cuenta.ToString & FECHA.ToString & CODIGO_IMPUTAC.ToString & CODIGO_ORDEN.ToString & NUMERO_COMPROBANTE.ToString & EXTRACTO.ToString & CLASE_FONDO.ToString & PEDIDO_DE_FONDO.ToString & EXPEDIENTE.ToString & INGRESOS.ToString & EGRESOS.ToString)
    End Function

End Structure
Public Structure Claveexpediente_separar
    '2018 0,4
    '3809 4,4
    '00739 8,5
    Public claveexpediente As String
    Public organismo As Integer
    Public numero As Integer
    Public year As Integer

    Public Sub Desglose_clave(ByVal claveexpediente As String)
        If claveexpediente.Length > 7 Then
            organismo = CType(claveexpediente.ToString.Substring(4, 4), Integer)
            numero = CType(claveexpediente.ToString.Substring(8, 5), Integer)
            year = CType(claveexpediente.ToString.Substring(0, 4), Integer)
        Else
            organismo = 0
            numero = 0
            year = Date.Now.Year
        End If
    End Sub

End Structure
Public Structure Claveexpedientedetalle_separar
    '2014 0,4
    '6220 4,4
    '00045 8,5
    '0000 13,4
    Public claveexpedientedetalle As String
    Public organismo As Integer
    Public numero As Integer
    Public year As Integer
    Public Nromovimiento As Integer

    Public Sub Desglose_clave()
        If claveexpedientedetalle.Length > 13 Then
            organismo = CType(claveexpedientedetalle.Substring(4, 4), Integer)
            numero = CType(claveexpedientedetalle.Substring(8, 5), Integer)
            year = CType(claveexpedientedetalle.Substring(0, 4), Integer)
            Nromovimiento = CType(claveexpedientedetalle.Substring(13, 4), Integer)
        Else
            organismo = 0
            numero = 0
            year = Date.Now.Year
            Nromovimiento = 0
        End If
    End Sub

End Structure