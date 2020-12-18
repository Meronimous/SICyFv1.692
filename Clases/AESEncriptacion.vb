'/**
'* La Class AESencriptacion Gestiona la encriptación dentro del programa y provee obfuscación a las interacciones inseguras.
'*
'* @author (Roberto H. Romero)
'* @version (2018-01-05)
'*/
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class AESencriptacion
    Dim EncryptionKey As String = Math.PI.ToString.Substring(0, 1) & "," & Math.PI.ToString.Substring(2, 8)

    'Función Encriptar actualizada al 02/10/2018
    Public Function Encriptar(clearText As String) As String
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
    Public Function Desencriptar(cipherText As String) As String
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